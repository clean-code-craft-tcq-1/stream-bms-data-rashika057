package sender;

import java.io.FileReader;
import java.io.IOException;
import java.io.StringWriter;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.json.Json;
import javax.json.JsonObject;
import javax.json.JsonWriter;
import javax.json.JsonWriterFactory;

import org.apache.commons.lang3.math.NumberUtils;
import org.apache.commons.lang3.StringUtils;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

public class BmsDataStream {

	static Logger logger = Logger.getLogger(BmsDataStream.class.getName());

	static final Map<String, String> FUNC_LIST;
	static final Map<String, String> FUNC_PARAM_LIST;
	static {
		FUNC_LIST = new LinkedHashMap<>();
		FUNC_LIST.put("F", "sendParamListFromFile");
		FUNC_LIST.put("R", "sendRandomParamList");
		FUNC_PARAM_LIST = new LinkedHashMap<>();
		FUNC_PARAM_LIST.put("F", ".src/resources/BatteryParameters.json");
		FUNC_PARAM_LIST.put("R", "0");
	}

	public static void sendRandomParamList(String maxCount) {
		int count = 1;
		int maxCountNumber = NumberUtils.toInt(maxCount);
		while (!(maxCountNumber > 0 ? count > maxCountNumber : Boolean.FALSE)) {
			count++;
			double temp = Math.round(Math.random() * (100) * 100.0) / 100.0;
			double soc = Math.round(Math.random() * (100) * 100.0) / 100.0;
			printJson(temp, soc);
		}

	}

	public static void sendParamListFromFile(String filePath) {

		// JSON parser object to parse read file
		JSONParser jsonParser = new JSONParser();
		try (FileReader reader = new FileReader(filePath)) {
			// Read JSON file
			Object obj = jsonParser.parse(reader);
			JSONArray paramList = (JSONArray) obj;
			// Iterate over parameter array
			paramList.forEach(param -> {
				parseParamObject((JSONObject) param);
			});
		} catch (IOException | ParseException e) {
			logger.log(Level.SEVERE, e.getCause().toString());
		}
	}

	private static void parseParamObject(JSONObject param) {
		// Get temperature
		Double temp = (Double) param.get("temperature");

		// Get soc
		Double soc = (Double) param.get("soc");

		// print json object on console
		printJson(temp, soc);

	}

	public static void printJson(Double temp, Double soc) {
		JsonObject json = Json.createObjectBuilder().add("temperature", temp).add("soc", soc).build();
		HashMap<String, Boolean> config = new HashMap<>();
		JsonWriterFactory jwf = Json.createWriterFactory(config);
		StringWriter sw = new StringWriter();

		try (JsonWriter jsonWriter = jwf.createWriter(sw)) {
			jsonWriter.writeObject(json);
			printToConsole(sw.toString());
		}
	}

	public static void printToConsole(String jsonObject) {
		System.out.println(jsonObject);
	}

	public static void main(String[] arg) {
		Method method;
		String dataGenerationType = arg.length >0 && !StringUtils.isNumeric(arg[0])? arg[0] : "R";
		if(dataGenerationType.equals("R")){
		String dataGenerationCount = arg.length == 1 && StringUtils.isNumeric(arg[0]) ? arg[0] : arg.length >1 ? arg[1]:"0";
		FUNC_PARAM_LIST.put(dataGenerationType, dataGenerationCount);
		}
		try {
			method = BmsDataStream.class.getMethod(FUNC_LIST.get(dataGenerationType), String.class);
			method.invoke(BmsDataStream.class, FUNC_PARAM_LIST.get(dataGenerationType));
		} catch (NoSuchMethodException | SecurityException | IllegalAccessException | IllegalArgumentException
				| InvocationTargetException e) {
			logger.log(Level.SEVERE, e.getMessage());
		}

	}
}
