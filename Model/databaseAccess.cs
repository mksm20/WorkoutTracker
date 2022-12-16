namespace WorkoutTracker.Model
{
    //Import a database creation tool from the System.Data.SQLite namespace
    using System.Data.SQLite;

    public class DatabaseAccess
    {
        private string connectionString = "Data Source=workoutTracker.db;Version=3;";
        public void createDB()
        {
            //Create a new database connection
            SQLiteConnection.CreateFile("workoutTracker.db");
            //Create a new database connection
            SQLiteConnection dbConnection = new SQLiteConnection(connectionString);
            //Open the database connection
            dbConnection.Open();
            //Create a new SQL command
            SQLiteCommand dbCommand = new SQLiteCommand(dbConnection);
            //Create a new table
            dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS workout (id INTEGER, name TEXT, date TEXT, description TEXT)";
            //Execute the SQL command
            dbCommand.ExecuteNonQuery();
            //Create a new table
            dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS excercise (id INTEGER, name TEXT, muscleGroup TEXT, description TEXT)";
            //Execute the SQL command
            dbCommand.ExecuteNonQuery();
            //Create a new table
            dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS excerciseSet (id INTEGER, excerciseSetID INTEGER, excerciseId INTEGER, reps INTEGER, weight FLOAT)";
            //Execute the SQL command
            dbCommand.ExecuteNonQuery();
            //Create a new table
            dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS completeexcerciseSet (id INTEGER, workoutId INTEGER, excerciseId INTEGER)";
            //Execute the SQL command
            dbCommand.ExecuteNonQuery();
            //Close the database connection
            dbConnection.Close();
        }

        public void addWorkout(Workout workout)
        {
            //Create a new database connection
            SQLiteConnection dbConnection = new SQLiteConnection(connectionString);
            //Open the database connection
            dbConnection.Open();
            //Create a new SQL command
            SQLiteCommand dbCommand = new SQLiteCommand(dbConnection);
            //Create a new table
            dbCommand.CommandText = "INSERT INTO workout (id, name, date) VALUES (@id, @name, @date)";
            //Add the parameters
            dbCommand.Parameters.AddWithValue("@id", workout.Id);
            dbCommand.Parameters.AddWithValue("@name", workout.Name);
            dbCommand.Parameters.AddWithValue("@date", workout.Date);
            addCompleteExcerciseSet(dbConnection, workout.CompleteExcerciseSet);
            //Execute the SQL command
            dbCommand.ExecuteNonQuery();
            //Close the database connection
            dbConnection.Close();
        }
        private void addCompleteExcerciseSet(SQLiteConnection dbConnection, CompleteexcerciseSet completeExcerciseSet)
        {
            //Create a new SQL command
            SQLiteCommand dbCommand = new SQLiteCommand(dbConnection);
            //Create a new table
            dbCommand.CommandText = "INSERT INTO completeexcerciseSet (id, workoutId, excerciseId) VALUES (@id, @workoutId, @excerciseId)";
            //Add the parameters
            dbCommand.Parameters.AddWithValue("@id", completeExcerciseSet.Id);
            dbCommand.Parameters.AddWithValue("@workoutId", completeExcerciseSet.WorkoutId);
            dbCommand.Parameters.AddWithValue("@excerciseId", completeExcerciseSet.ExcerciseId);
            //Execute the SQL command
            dbCommand.ExecuteNonQuery();
        }
        private void addExcerciseSet(SQLiteConnection dbConnection, ExcerciseSet excerciseSet)
        {
            //Create a new SQL command
            SQLiteCommand dbCommand = new SQLiteCommand(dbConnection);
            //Create a new table
            dbCommand.CommandText = "INSERT INTO excerciseSet (id, excerciseSetID, excerciseId, reps, weight) VALUES (@id, @excerciseSetID, @excerciseId, @reps, @weight)";
            //Add the parameters
            dbCommand.Parameters.AddWithValue("@id", excerciseSet.Id);
            dbCommand.Parameters.AddWithValue("@excerciseSetID", excerciseSet.ExcerciseSetID);
            dbCommand.Parameters.AddWithValue("@excerciseId", excerciseSet.ExcerciseId);
            dbCommand.Parameters.AddWithValue("@reps", excerciseSet.Reps);
            dbCommand.Parameters.AddWithValue("@weight", excerciseSet.Weight);
            //Execute the SQL command
            dbCommand.ExecuteNonQuery();
        }
    }
}