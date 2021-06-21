pushd "%~dp0"

java -ea -cp "src;lib\*" sender.BmsDataStream | dotnet run --project src\Receiver\Receiver\Receiver.csproj

popd
