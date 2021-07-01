package test;


import static org.junit.Assert.assertTrue;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PipedInputStream;
import java.io.PipedOutputStream;
import java.io.PrintStream;
import java.math.BigDecimal;
import java.util.logging.Level;
import java.util.logging.Logger;

import org.apache.commons.lang3.StringUtils;
import org.json.JSONObject;
import org.junit.Before;
import org.junit.Test;

import sender.BmsDataStream;

public class BmsDataStreamTest {

	private final PipedOutputStream outputStreamCaptor = new PipedOutputStream();
	private PipedInputStream inputStreamCaptor;
	static Logger logger = Logger.getLogger(BmsDataStreamTest.class.getName());
	@Before
    public void setup() throws IOException { 
		System.setOut(new PrintStream(outputStreamCaptor));		
		this.inputStreamCaptor = new PipedInputStream(outputStreamCaptor);
	}
	
	@Test(expected = NullPointerException.class)
	 public  void givenEmptyJsonFilePath_whenMatches_thenTrue() {
		 		//when
		 		BmsDataStream.sendParamListFromFile("");			 	
		    }
	
	@Test(expected = NullPointerException.class)
	 public  void givenWrongJsonFilePath_whenMatches_thenTrue() {
		 		//when
		 		BmsDataStream.sendParamListFromFile("src/resources/abc.json");			 	
		    }

	 @Test
	 public  void givenJsonFilePath_whenMatches_thenTrue() throws IOException {
				//given
		 		String line = null;
		 		int count = 0;
		 		Double[] temp = {15.23,2.16,36.56,98.68,78.03,41.26,32.65,3.73,85.82,25.95,59.34,41.65,5.48,95.62,22.63,28.26,4.56,51.49,1.0,5.96,73.65,72.45,16.24,21.22,69.76};
		 		BufferedReader reader = new BufferedReader(new InputStreamReader(inputStreamCaptor));
		 		//when
		 		BmsDataStream.sendParamListFromFile("src/resources/BatteryParametersTest.json");
				//verify
		 		while (count <= 20){
		                line = reader.readLine();
		                JSONObject json = new JSONObject(line); 
		                Double temperature = json.getDouble("temperature");
		                assertTrue(temperature.equals(temp[count++]));
		        }
			 	
			 	
		    }
	 
	 @Test
	 public  void givenMaxSize_whenCountMatches_thenTrue() throws IOException {
				//given
		 		String line = null;
		 		int count = 1;
		 		BufferedReader reader = new BufferedReader(new InputStreamReader(inputStreamCaptor));
		 		//when
		 		BmsDataStream.sendRandomParamList("20");
				//verify
		 		while (count <= 20){
		                line = reader.readLine();
		                JSONObject json = new JSONObject(line); 
		                Double temperature = json.getDouble("temperature");
		                count++;
		                assertTrue(temperature > 0);
		        }
		 		assertTrue(count == 21);
		    }
	 
	 @Test
	 public  void given1Size_whenCountMatches_thenTrue() throws IOException {
			//given
	 		String line = null;
	 		int count = 1;
	 		BufferedReader reader = new BufferedReader(new InputStreamReader(inputStreamCaptor));
	 		//when
	 		BmsDataStream.sendRandomParamList("1");
			//verify
	 		line = reader.readLine();
            JSONObject json = new JSONObject(line); 
            Double soc = json.getDouble("soc");
            assertTrue(soc > 0 && soc <= 100);
	    }
}
