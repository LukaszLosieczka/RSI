import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class Worker extends UnicastRemoteObject implements IWorker{

    public Worker() throws RemoteException {
        super();
    }

    @Override
    public ResultType compute(ITask task) throws RemoteException {
        return task.compute();
    }
}
