FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

COPY ./src/. ./

RUN dotnet publish ./Server/*.csproj -c Release

CMD ASPNETCORE_URLS=http://*:$PORT dotnet NoteToSelf.Server.dll
