using System.Drawing;
using System.Windows.Forms;

namespace RAGWinApp.Helpers
{
    /// <summary>
    /// Converts markdown-like output into formatted RichTextBox UI
    /// </summary>
    public static class ResponseFormatter
    {
        public static void Format(RichTextBox box, string text)
        {
            box.Clear();

            var lines = text.Split('\n');

            foreach (var line in lines)
            {
                // Bold headings (**text**)
                if (line.StartsWith("**") && line.EndsWith("**"))
                {
                    var clean = line.Replace("**", "").Trim();

                    box.SelectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
                    box.AppendText(clean + "\n\n");
                }
                // Bullet points
                else if (line.TrimStart().StartsWith("-"))
                {
                    var clean = line.Replace("-", "•").Trim();

                    box.SelectionFont = new Font("Segoe UI", 10);
                    box.AppendText("   " + clean + "\n");
                }
                else
                {
                    box.SelectionFont = new Font("Segoe UI", 10);
                    box.AppendText(line + "\n");
                }
            }
        }
    }
}