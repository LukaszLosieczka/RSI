import java.rmi.RemoteException;

public interface IWorker extends java.rmi.Remote{
    ResultType compute(ITask task) throws RemoteException;
}
