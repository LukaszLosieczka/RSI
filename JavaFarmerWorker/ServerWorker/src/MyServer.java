import java.net.MalformedURLException;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class MyServer {
    public static void main(String[] args) {
        MyData.info();

        if (args.length < 2) {
            System.out.println("You have to enter two RMI object address in the form: //host_address/service_name //host_address/service_name");
            return;
        }

        if(System.getSecurityManager() == null){
            System.setSecurityManager(new SecurityManager());
        }

        try {
            Registry reg = LocateRegistry.createRegistry(1099);
        } catch (RemoteException e) {
            e.printStackTrace();
        }

        try {
            Worker worker1 = new Worker();
            Worker worker2 = new Worker();
            java.rmi.Naming.rebind(args[0], worker1);
            java.rmi.Naming.rebind(args[1], worker2);
            System.out.println("Server is registered now :-)");
            System.out.println("press Crl+c to stop...");
        } catch (MalformedURLException | RemoteException e) {
            System.err.println("SERVER CAN'T BE REGISTERED");
            e.printStackTrace();
            return;
        }
    }
}
