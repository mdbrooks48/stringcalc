FROM microsoft/dotnet:2-sdk AS build
WORKDIR /app

# copy everything and build app
COPY . ./
RUN dotnet publish ./StringCalc.webapi/StringCalc.webapi.csproj -c Release -o out

FROM microsoft/dotnet:2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/StringCalc.webapi/out ./
ENTRYPOINT ["dotnet", "StringCalc.webapi.dll"]