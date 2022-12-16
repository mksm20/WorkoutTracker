import uuid from 'uuid/v4';

// Contains a single excerise, for example bench press
public class excerise
{
    public int Id { get; }
    public string Name { get; }
    public list<string> MuscleGroup { get; }
    public excerise(int id, string name, list<string> muscleGroup, string description)
    {
        Id = id;
        Name = name;
        MuscleGroup = muscleGroup;
    }
}

// Contains a single excerise with reps and weight, for example 10 reps with 20kg
public class exceriseSet
{
    public int Id { get; }
    public excerise Excerise { get; }
    public int Reps { get; }
    public float Weight { get; }
    public exceriseSet(excerise excerise, int reps, float weight)
    {
        Id = uuid();
        Excerise = excerise;
        Reps = reps;
        Weight = weight;
    }
    public void changeReps(int reps)
    {
        Reps = reps;
    }
    public void changeWeight(float weight)
    {
        Weight = weight;
    }
}

// Contains a list of exceriseSets which represent a complete excerise
// So every exceriseSet in this list is the same excerise, but with different reps and weights, 
// for example 3 sets of 10 reps with 20kg
public class completeExceriseSet
{
    public int Id { get; }
    public List<exceriseSet> Excerise = new List<exceriseSet>();
    public completeExceriseSet()
    {
        Id = uuid();
    }
    public void addExcerise(exceriseSet excerise)
    {
        Excerise.Add(excerise);
    }
    public void removeExcerise(exceriseSet excerise)
    {
        Excerise.Remove(excerise);
    }
}


// Contains a list of completeExceriseSets which represent a complete workout
// So every completeExceriseSet in this list is a different excerise.
public class Workout
{
    public int Id { get; }
    public List<completeExceriseSet> ExcerisesSets = new List<completeExceriseSet>();
    public Workout()
    {
        Id = uuid();
    }
    public void addExcerise(completeExceriseSet excerise)
    {
        ExcerisesSets.Add(excerise);
    }
    public void removeExcerise(completeExceriseSet excerise)
    {
        ExcerisesSets.Remove(excerise);
    }
    public completeExceriseSet getExceriseSet(int id)
    {
        return ExcerisesSets.Find(x => x.Id == id);
    }
    public void replaceExceriseSet(completeExceriseSet exceriseSet)
    {
        ExcerisesSets.Remove(getExceriseSet(exceriseSet.Id));
        ExcerisesSets.Add(exceriseSet);
    }
}