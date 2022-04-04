import java.net.MalformedURLException;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.Scanner;

public class MyClient {
    public static void main(String[] args) {
        MyData.info();

        ResultType result1;
        ResultType result2;

        double finalResult;

        IWorker worker1;
        IWorker worker2;

        if(args.length < 2){
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name //host_address/service_name");
            return;
        }

        String address1 = args[0];
        String address2 = args[1];

        if(System.getSecurityManager() == null)
            System.setSecurityManager(new SecurityManager());

        Scanner scanner = new Scanner(System.in);

        try{
            worker1 = (IWorker) java.rmi.Naming.lookup(address1);
        } catch (MalformedURLException | NotBoundException | RemoteException e) {
            System.out.println("Nie mozna pobreac refernecji do " + address1);
            e.printStackTrace();
            return;
        }
        System.out.println("Referencja do " + address1 + " jest pobrana");

        try{
            worker2 = (IWorker) java.rmi.Naming.lookup(address2);
        } catch (MalformedURLException | NotBoundException | RemoteException e) {
            System.out.println("Nie mozna pobreac refernecji do " + address2);
            e.printStackTrace();
            return;
        }
        System.out.println("Referencja do " + address2 + " jest pobrana");


        System.out.println(args[0]);
        System.out.print("Podaj dokladnosc liczby pi w miejscach po przecinku: ");
        int n = scanner.nextInt();

        try{
            int numberOfIteration = (int)Math.pow(10, 7)/2;

            result1 = worker1.compute(new Task(numberOfIteration));
            result2 = worker2.compute(new Task(result1.sum, result1.value, result1.sign, numberOfIteration));

            double exp = Math.pow(10, n);

            finalResult = Math.round(result2.sum * 4 * exp) / exp;
        } catch (RemoteException e) {
            System.out.println("Blad zdalnego wywowolania.");
            e.printStackTrace();
            return;
        }
        System.out.println("Wynik = " + finalResult);
    }
}
