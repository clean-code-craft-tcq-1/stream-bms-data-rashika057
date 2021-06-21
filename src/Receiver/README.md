# Receiver

It has two components

- Receiver is the console application which prints output after reading
- Receiver.Test contians unit test for Receiver


## Receiver.Test

- JSONParameterParserTests.cs which parse the parameter of JSON data.
- ParameterParserTests.cs parser client class.
- ParameterStatisticsTests.cs which performs statistics on inputs given.

## Receiver

- This is console application. When user provide piping and runs this command or github action it prints in following way.
e.g.
Maximum of soc 45.6 and maximum of temperature 65.6
Minimum of soc 20.2 and minimum of temperature 25.3
Average of soc 33.5 and Average of temperature 26.5
..
..
..



#### Note: Maximum,minimum and avergae are calculated from sample of 15 readings and keeps repeating after 15. User can stop the printing with Ctrl+C.