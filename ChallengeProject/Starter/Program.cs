/* 
This C# console application is designed to:
- Use arrays to store student names and assignment scores.
- Use a `foreach` statement to iterate through the student names as an outer program loop.
- Use an `if` statement within the outer loop to identify the current student name and access that student's assignment scores.
- Use a `foreach` statement within the outer loop to iterate though the assignment scores array and sum the values.
- Use an algorithm within the outer loop to calculate the average exam score for each student.
- Use an `if-elseif-else` construct within the outer loop to evaluate the average exam score and assign a letter grade automatically.
- Integrate extra credit scores when calculating the student's final score and letter grade as follows:
    - detects extra credit assignments based on the number of elements in the student's scores array.
    - divides the values of extra credit assignments by 10 before adding extra credit scores to the sum of exam scores.
- use the following report format to report student grades: 

    Student         Grade

    Sophia:         92.2    A-
    Andrew:         89.6    B+
    Emma:           85.6    B
    Logan:          91.2    A-
*/
int examAssignments = 5;

string[] studentNames = ["Sophia", "Andrew", "Emma", "Logan"];

int[] sophiaScores = [90, 86, 87, 98, 100, 94, 90];
int[] andrewScores = [92, 89, 81, 96, 90, 89];
int[] emmaScores = [90, 85, 87, 98, 68, 89, 89, 89];
int[] loganScores = [90, 95, 87, 88, 96, 96];

int[] studentScores = new int[10];

string currentStudentLetterGrade;

// display the header row for scores/grades
Console.Clear();
Console.WriteLine("Student\t\tExam Score\tOverall\t\tGrade\tExtra Credit\n");

/*
The outer foreach loop is used to:
- iterate through student names 
- assign a student's grades to the studentScores array
- sum assignment scores (inner foreach loop)
- calculate numeric and letter grade
- write the score report information
*/
foreach (string name in studentNames)
{
    string currentStudent = name;

    if (currentStudent == "Sophia")
        studentScores = sophiaScores;

    else if (currentStudent == "Andrew")
        studentScores = andrewScores;

    else if (currentStudent == "Emma")
        studentScores = emmaScores;

    else if (currentStudent == "Logan")
        studentScores = loganScores;

    double sumAssignmentScores = 0;

    decimal overallScore = 0;

    int gradedAssignments = 0;

    // The sum of the exam-only score
    decimal sumExamScore = 0;

    // Variable to store the exam score
    decimal examScore = 0;

    decimal extraCredit = 0;
    decimal currentExtraCredit = 0;

    decimal extraCreditPoints = 0;

    /* 
    the inner foreach loop sums assignment scores
    extra credit assignments are worth 10% of an exam score
    */
    foreach (int score in studentScores)
    {
        gradedAssignments += 1;

        if (gradedAssignments <= examAssignments)
        {
            sumAssignmentScores += score;
            sumExamScore += score;
        }
        else
        {
            sumAssignmentScores = (double)sumAssignmentScores + (score * 0.1);
            extraCredit += score;
        }
    }

    /*
    Extra credit calculation
    Sum of extra credit score divided by the number of extra credit assignments completed
    */
    currentExtraCredit = extraCredit / (studentScores.Length - examAssignments);

    // Overall score including extra credit
    overallScore = (((decimal)0.1 * extraCredit) + sumExamScore) / examAssignments;

    /*
    Exam-only score
    Sum of the exam score divided by the number of exams completed
    */
    examScore = sumExamScore / examAssignments;

    // Extra credit points earned
    extraCreditPoints = (decimal)0.1 * extraCredit / examAssignments;

    if (overallScore >= 97)
        currentStudentLetterGrade = "A+";

    else if (overallScore >= 93)
        currentStudentLetterGrade = "A";

    else if (overallScore >= 90)
        currentStudentLetterGrade = "A-";

    else if (overallScore >= 87)
        currentStudentLetterGrade = "B+";

    else if (overallScore >= 83)
        currentStudentLetterGrade = "B";

    else if (overallScore >= 80)
        currentStudentLetterGrade = "B-";

    else if (overallScore >= 77)
        currentStudentLetterGrade = "C+";

    else if (overallScore >= 73)
        currentStudentLetterGrade = "C";

    else if (overallScore >= 70)
        currentStudentLetterGrade = "C-";

    else if (overallScore >= 67)
        currentStudentLetterGrade = "D+";

    else if (overallScore >= 63)
        currentStudentLetterGrade = "D";

    else if (overallScore >= 60)
        currentStudentLetterGrade = "D-";

    else
        currentStudentLetterGrade = "F";

    Console.WriteLine($"{currentStudent}\t\t{examScore}\t\t{overallScore}\t\t{currentStudentLetterGrade}\t{currentExtraCredit} ({extraCreditPoints}pts)");
}

// required for running in VS Code (keeps the Output windows open to view results)
Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();
