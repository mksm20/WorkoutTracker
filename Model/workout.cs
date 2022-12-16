namespace WorkoutTracker.Model
{
    using System;
    using System.Collections.Generic;
    // Contains a single excercise, for example bench press
    public class Excercise
    {
        public int Id { get; }
        public string Name { get; }
        public list<string> MuscleGroup { get; }
        public Excercise(int id, string name, list<string> muscleGroup, string description)
        {
            Id = NewGuid();
            Name = name;
            MuscleGroup = muscleGroup;
        }
    }

    // Contains a single excercise with reps and weight, for example 10 reps with 20kg
    public class ExcerciseSet
    {
        public int Id { get; }
        public Excercise Excercise { get; }
        public int Reps { get; }
        public float Weight { get; }
        public excerciseSet(excercise excercise, int reps, float weight)
        {
            Id = NewGuid();
            Excercise = excercise;
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

    // Contains a list of excerciseSets which represent a complete excercise
    // So every excerciseSet in this list is the same excercise, but with different reps and weights, 
    // for example 3 sets of 10 reps with 20kg
    public class CompleteexcerciseSet
    {
        public int Id { get; }
        public List<ExcerciseSet> excerciseSets = new List<excerciseSet>();
        public CompleteexcerciseSet()
        {
            Id = NewGuid();
        }
        public void addexcercise(ExcerciseSet excercise)
        {
            excerciseSets.Add(excercise);
        }
        public void removeexcercise(ExcerciseSet excercise)
        {
            excercise.Remove(excercise);
        }
    }


    // Contains a list of completeexcerciseSets which represent a complete workout
    // So every completeexcerciseSet in this list is a different excercise.
    public class Workout
    {
        public int Id { get; }
        public List<completeexcerciseSet> excercisesSets = new List<CompleteexcerciseSet>();
        public Workout()
        {
            Id = NewGuid();
        }
        public void addexcercise(CompleteexcerciseSet excercise)
        {
            excercisesSets.Add(excercise);
        }
        public void removeexcercise(CompleteexcerciseSet excercise)
        {
            excercisesSets.Remove(excercise);
        }
        public CompleteexcerciseSet getexcerciseSet(int id)
        {
            return excercisesSets.Find(x => x.Id == id);
        }
        public void replaceexcerciseSet(CompleteexcerciseSet excerciseSet)
        {
            excercisesSets.Remove(getexcerciseSet(excerciseSet.Id));
            excercisesSets.Add(excerciseSet);
        }
    }
}