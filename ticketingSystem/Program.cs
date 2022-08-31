namespace ticketingSystem;

internal class Program
{
    private static void Main(string[] args)
    {
        var ticket = "ticket.csv"; //string variable that stores name of file
        string choice = "";
        var headers = "Ticket ID, Summary, Status, Priority, Submitter, Assigned, Watching";
        var testing = "1, This is a bug ticket, Open, High, Drew Kjell, Jane Doe, Drew Kjell|John Smith|Bill Jones";


        Console.WriteLine("1) output ticket records.");
        Console.WriteLine("2) Add ticket record.");

        choice = Console.ReadLine();
        var stream = "";

        if (choice == "2")
        {
            var recordstr = "";
            var recordstring = "";
            var record = new string[7];


            Console.Write("Ticket ID: ");
            var id = Console.ReadLine();
            record[0] = id;

            Console.Write("Summary: ");
            var summary = Console.ReadLine();
            record[1] = summary;

            Console.Write("Status (Open|Close): ");
            var status = Console.ReadLine();
            record[2] = status;

            Console.Write("Priority (High|Medium|low): ");
            var priority = Console.ReadLine();
            record[3] = priority;

            Console.Write("Submitter: ");
            var submitter = Console.ReadLine();
            record[4] = submitter;

            Console.Write("Assigned: ");
            var assigned = Console.ReadLine();
            record[5] = assigned;

            Console.Write("Watching: ");
            var watching = Console.ReadLine();
            record[6] = watching;
            

            //**above** all these gather ticket info 

            if (!File.Exists(ticket))
            {
                var sw = new StreamWriter(ticket);
                var arr = ticket.Split('|');


                sw.WriteLine("{0} {1} {2} {3} {4} {5} {6}", id, summary, status, priority, submitter, assigned, watching); //writing column headers to csv
                sw.WriteLine(testing); //writing column headers to csv

                foreach (var index in record)
                {
                    recordstr += index;
                    recordstr += ", ";
                }

                if (recordstr.Length > 1) recordstring = recordstr.Substring(0, recordstr.Length - 1);
                

                sw.Write(recordstring);
                sw.Close();
            }
            else

            {
                var sr = new StreamReader(ticket);


                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    stream += line;
                    stream += "\n";
                    //line.Split();

                }

                sr.Close();

                var sw = new StreamWriter(ticket);
                sw.Write(stream);


                foreach (var index in record)
                {
                    recordstr += index;
                    recordstr += ", ";
            
                }

                if (recordstr.Length > 1) recordstring = recordstr.Substring(0, recordstr.Length - 1);

                sw.Write(recordstring);
                sw.Close();
            }
        }
        else

        {
            var sr = new StreamReader(ticket);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                stream += line + '\n';
                Console.WriteLine(line);
                
            }

            sr.Close();
        }
    }
}