# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Copia os arquivos do projeto
COPY . ./

# Restaura dependências e compila
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os arquivos compilados da etapa anterior
COPY --from=build /app/out .

# Define o comando de execução
ENTRYPOINT ["dotnet", "Projeto-Claro.dll"]