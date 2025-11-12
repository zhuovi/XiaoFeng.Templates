# 请参阅 https://aka.ms/customizecontainer 以了解如何自定义调试容器，以及 Visual Studio 如何使用此 Dockerfile 生成映像以更快地进行调试。

# 此阶段用于在快速模式(默认为调试配置)下从 VS 运行时
#if (Framework == "net6.0")
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#elseif (Framework == "net7.0")
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#elseif (Framework == "net8.0")
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#elseif (Framework == "net9.0")
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
#elseif (Framework == "net10.0")
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
#endif
USER app
WORKDIR /app
EXPOSE ELFHttpPort
EXPOSE ELFHttpsPort


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
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ELF.Cube.Web/ELF.Cube.Web.csproj", "ELF.Cube.Web/"]
RUN dotnet restore "./ELF.Cube.Web/ELF.Cube.Web.csproj"
COPY . .
WORKDIR "/src/ELF.Cube.Web"
RUN dotnet build "./ELF.Cube.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 此阶段用于发布要复制到最终阶段的服务项目
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ELF.Cube.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 此阶段在生产中使用，或在常规模式下从 VS 运行时使用(在不使用调试配置时为默认值)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ELF.Cube.Web.dll"]