import java.io.Serializable;

public interface ITask extends Serializable {
    ResultType compute();
}
