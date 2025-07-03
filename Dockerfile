# Etapa 1: build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia APENAS o arquivo .csproj do diretório do seu projeto.
# O primeiro "CadastroDeCliente/" é o nome da pasta onde o .csproj está no seu repositório.
# O segundo "CadastroDeCliente/" é o nome da pasta que será criada DENTRO do contêiner.
# Isso garante que o dotnet restore tenha apenas o que precisa no cache de build.
COPY ["CadastroDeCliente/CadastroDeCliente.csproj", "CadastroDeCliente/"]

# Executa dotnet restore especificando o caminho completo do csproj dentro do contêiner.
RUN dotnet restore "CadastroDeCliente/CadastroDeCliente.csproj"

# Copia o restante dos arquivos do seu projeto da pasta 'CadastroDeCliente'
# O primeiro 'CadastroDeCliente/.' copia TUDO que está dentro da sua pasta de projeto.
# O segundo './CadastroDeCliente/' indica o destino DENTRO do contêiner.
COPY CadastroDeCliente/. ./CadastroDeCliente/

# Publica a aplicação. Ajuste o caminho do .csproj aqui também.
RUN dotnet publish "CadastroDeCliente/CadastroDeCliente.csproj" -c Release -o out --no-restore

# Etapa 2: imagem final para rodar
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

COPY --from=build /app/out .

# Expõe a porta da API (ajuste se necessário)
EXPOSE 80

# Comando para rodar a API
# Verifique se o nome da DLL principal está correto (geralmente é o nome do projeto.dll)
ENTRYPOINT ["dotnet", "CadastroDeCliente.dll"]