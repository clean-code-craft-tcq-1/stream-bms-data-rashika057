pushd "%~dp0"

java -ea -classpath src\ sender.BmsDataStream | dotnet run --project src\Receiver\Receiver\Receiver.csproj

popd