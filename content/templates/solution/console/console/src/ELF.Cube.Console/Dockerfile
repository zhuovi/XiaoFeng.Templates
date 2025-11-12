dot# 请参阅 https://aka.ms/customizecontainer 以了解如何自定义调试容器，以及 Visual Studio 如何使用此 Dockerfile 生成映像以更快地进行调试。

# 通过这些 ARG，可以在从 VS 进行调试时交换用于生成最终映像的基础
ARG LAUNCHING_FROM_VS
# 此操作会设置最终的基础映像，但仅当已定义 LAUNCHING_FROM_VS 时才会如此
ARG FINAL_BASE_IMAGE=${LAUNCHING_FROM_VS:+aotdebug}

# 此阶段用于在快速模式(默认为调试配置)下从 VS 运行时
#if (Framework == "net6.0")
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
#elseif (Framework == "net7.0")
FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
#elseif (Framework == "net8.0")
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
#elseif (Framework == "net9.0")
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
#elseif (Framework == "net10.0")
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
#endif
USER app
WORKDIR /app


# 此阶段用于生成服务项目
#if (Framework == "net6.0")
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#elseif (Framework == "net7.0")
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#elseif (Framework == "net8.0")
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#elseif (Framework == "net9.0")
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
#elseif (Framework == "net10.0")
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
#endif
# 安装 clang/zlib1g 开发依赖项以发布到本机
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ELF.Cube.Console/ELF.Cube.Console.csproj", "ELF.Cube.Console/"]
RUN dotnet restore "./ELF.Cube.Console/ELF.Cube.Console.csproj"
COPY . .
WORKDIR "/src/ELF.Cube.Console"
RUN dotnet build "./ELF.Cube.Console.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 此阶段用于发布要复制到最终阶段的服务项目
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ELF.Cube.Console.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

# 从 VS 启动以支持常规模式(不使用调试配置时为默认值)下的调试时，此阶段用作最终阶段的基础
FROM base as aotdebug
USER root
# 安装 GDB 以支持本机调试
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    gdb
USER app

# 此阶段在生产中使用，或在常规模式下从 VS 运行时使用(在不使用调试配置时为默认值)
#if (Framework == "net6.0")
FROM ${FINAL_BASE_IMAGE:-mcr.microsoft.com/dotnet/runtime-deps:6.0} AS final
#elseif (Framework == "net7.0")
FROM ${FINAL_BASE_IMAGE:-mcr.microsoft.com/dotnet/runtime-deps:7.0} AS final
#elseif (Framework == "net8.0")
FROM ${FINAL_BASE_IMAGE:-mcr.microsoft.com/dotnet/runtime-deps:8.0} AS final
#elseif (Framework == "net9.0")
FROM ${FINAL_BASE_IMAGE:-mcr.microsoft.com/dotnet/runtime-deps:9.0} AS final
#elseif (Framework == "net10.0")
FROM ${FINAL_BASE_IMAGE:-mcr.microsoft.com/dotnet/runtime-deps:10.0} AS final
#endif
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./ELF.Cube.Console"]