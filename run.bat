pushd "%~dp0"

java -ea -classpath -classpath ".:.\lib\*" sender.BmsDataStream | dotnet run --project src\Receiver\Receiver\Receiver.csproj

popd
