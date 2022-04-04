import java.io.Serializable;
import java.rmi.RemoteException;

public class Task implements ITask {
    public static final long serialVersionUID = 102L;

    public double sum = 1;
    public double value = 3;
    public int sign = -1;
    public int numberOfIteration;

    public Task(int numberOfIteration){
        super();
        this.numberOfIteration = numberOfIteration;
    }

    public Task(double sum, double value, int sign, int numberOfIteration){
        super();
        this.sum = sum;
        this.value = value;
        this.sign = sign;
        this.numberOfIteration = numberOfIteration;
    }

    @Override
    public ResultType compute() {
        for(int i=0;i<numberOfIteration;i++)
        {
            sum = sum + sign / value;
            value = value + 2;
            sign = sign * -1;
        }
        ResultType result = new ResultType();
        result.sum = sum;
        result.value = value;
        result.sign = sign;
        result.result_description = "Subtask result";
        return result;
    }
}
