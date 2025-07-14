# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia o arquivo de projeto (use o caminho correto se não estiver na raiz)
COPY CadastroClientesAPI.csproj ./

# Restaura dependências especificando o projeto
RUN dotnet restore CadastroClientesAPI.csproj

# Copia o restante do código
COPY . ./

# Publica explicitamente o projeto
RUN dotnet publish CadastroClientesAPI.csproj -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "CadastroClientesAPI.dll"]
