import java.net.Inet4Address;
import java.text.SimpleDateFormat;
import java.util.Date;

public class MyData {
    private static String getDate(){
        SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd 'at' HH:mm:ss  z");
        Date date = new Date(System.currentTimeMillis());
        return formatter.format(date);
    }

    public static void info(){
        System.out.println("My data");
        System.out.println(getDate());
        System.out.println(System.getProperty("user.name"));
        System.out.println(System.getProperty("os.name"));
        System.out.println(System.getProperty("java.version"));
        try{
            System.out.println(Inet4Address.getLocalHost().getHostAddress());
        }catch(Exception e){
            System.out.println("Error");
        }
    }
}
