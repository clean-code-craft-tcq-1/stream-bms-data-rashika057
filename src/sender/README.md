**SENDER**
The Sender Object is represented with the help of BmsDataStream class in "\src\sender\BmsDataStream.java"
In java, we need a main method as the entry point when executing class from command line. 
So, here entry point is this method: public static void main(String[] arg) {.....}
We can pass command line arguments in this way: java BmsDataStream X. This "X" will be stored in this String array arg. 
Here, we can either enter F(which denotes file reading) or R(which denotes random data generation). If no argument will be entered then by default, if will take R.

for file data reading, we have sendParamListFromFile(String filePath){...} which takes file path as paramter, reads data from json file and prints JSON stream on console. For example:
File path is : src/resources/BatteryParameters.json
Output on console will be :
{"temperature":15.23,"soc":59.92}
{"temperature":2.16,"soc":6.37}
{"temperature":36.56,"soc":13.96}
{"temperature":98.68,"soc":46.43}
{"temperature":93.65,"soc":63.09}
{"temperature":64.15,"soc":11.2}
{"temperature":85.31,"soc":67.39}
{"temperature":18.56,"soc":57.88}
{"temperature":89.02,"soc":64.91}
{"temperature":74.76,"soc":11.27}
{"temperature":66.31,"soc":16.3}
{"temperature":33.01,"soc":56.89}
......

for random data stream generation, we have sendRandomParamList(String maxCount){...} which takes maximum no. of streams to be printed on console as paramter, generates random double values with at maximum 2 decimal digits, till 100(values will be <=100) and prints JSON stream on console. For example:
maxCount is : "0"    (Note: if this count is 0 or blank then, streams will keep on printing on screen.)
Output on console will be :
{"temperature":58.4,"soc":59.89}
{"temperature":46.21,"soc":45.07}
{"temperature":76.12,"soc":22.9}
{"temperature":57.81,"soc":89.74}
{"temperature":55.01,"soc":22.98}
{"temperature":96.4,"soc":42.27}
{"temperature":26.73,"soc":60.1}
{"temperature":30.39,"soc":89.98}
{"temperature":52.47,"soc":96.1}
{"temperature":95.09,"soc":97.43}
{"temperature":37.73,"soc":10.08}
{"temperature":78.33,"soc":20.55}
{"temperature":3.2,"soc":12.02}
{"temperature":6.82,"soc":14.4}
{"temperature":9.52,"soc":52.74}
......


