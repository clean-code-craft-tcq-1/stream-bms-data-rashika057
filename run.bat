pushd "%~dp0"

java -ea -cp "src;lib\*" main.java.sender.BmsDataStream 25 | dotnet run --project src\Receiver\Receiver\Receiver.csproj

popd
