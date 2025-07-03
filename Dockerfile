# Etapa 1: build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia os arquivos do projeto
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: imagem final para rodar
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

COPY --from=build /app/out .

# Expõe a porta da API (ajuste se necessário)
EXPOSE 80

# Comando para rodar a API
ENTRYPOINT ["dotnet", "CadastroDeCliente.dll"]
