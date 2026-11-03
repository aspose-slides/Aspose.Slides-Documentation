using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private sealed record Row(string Customer, decimal Amount, DateTime Date);
    private static List<Row> Read(string text)
    {
        var csv = Example.Csv(text, 3);
        string[] header = ["Customer", "Amount", "Date"];
        if (csv.Count == 0 || !csv[0].SequenceEqual(header))
            throw new InvalidDataException("Expected Customer,Amount,Date header.");
        var records = new List<Row>();
        foreach (var fields in csv.Skip(1))
        {
            string customer = fields[0];
            decimal amount = decimal.Parse(fields[1], NumberStyles.Number, CultureInfo.InvariantCulture);
            DateTime date = DateTime.ParseExact(fields[2], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            records.Add(new Row(customer, amount, date));
        }

        return records;
    }

    private static void Fill(ITable table, List<Row> rows)
    {
        const int customerColumn = 0;
        const int amountColumn = 1;
        const int dateColumn = 2;
        if (rows.Count == 0)
        {
            table.Rows.RemoveAt(1, false); // Keep only the header.
            return;
        }

        for (int i = 0; i < rows.Count; i++)
        {
            if (i > 0)
                table.Rows.AddClone(table.Rows[1], false);
            var record = rows[i];
            table[customerColumn, i + 1].TextFrame.Text = record.Customer;
            table[amountColumn, i + 1].TextFrame.Text = record.Amount.ToString("0.00", CultureInfo.InvariantCulture);
            table[dateColumn, i + 1].TextFrame.Text = record.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }

    private static void RunExample()
    {
        Example.Setup();
        string csv = Context.IsLicensed ? File.ReadAllText("records.csv") : "Customer,Amount,Date\n\"A,β\",12.30,2026-01-01\n東京,4.50,2026-01-02\n";
        var rows = Read(csv);
        using (var p = new Presentation())
        {
            var table = p.Slides[0].Shapes.AddTable(35, 50, new double[] { 280, 140, 180 }, new double[] { 50, 45 });
            table.Name = "Records";
            string[] labels =
            {
                "Customer",
                "Amount",
                "Date"
            };
            for (int c = 0; c < 3; c++)
            {
                table[c, 0].TextFrame.Text = labels[c];
                table[c, 0].TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold = NullableBool.True;
            }

            Fill(table, rows);
            p.Save("output/report.pptx", SaveFormat.Pptx);
            Example.Render(p, "output/preview.png");
        }

        using var reopened = new Presentation("output/report.pptx");
        var saved = Example.Named<ITable>(reopened.Slides[0], "Records");
        Example.Require(saved.Rows.Count == rows.Count + 1, "Wrong row count.");
        for (int i = 0; i < rows.Count; i++)
        {
            Example.Require(saved[0, i + 1].TextFrame.Text == rows[i].Customer, "Customer differs.");
            Example.Require(saved[1, i + 1].TextFrame.Text == rows[i].Amount.ToString("0.00", CultureInfo.InvariantCulture), "Amount differs.");
            Example.Require(saved[2, i + 1].TextFrame.Text == Example.ExpectedText(rows[i].Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)), "Date differs.");
        }

        Example.Require(saved[0, 0].TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold == NullableBool.True, "Header style lost.");
        using var empty = new Presentation();
        var emptyTable = empty.Slides[0].Shapes.AddTable(0, 0, new double[] { 100, 100, 100 }, new double[] { 30, 30 });
        Fill(emptyTable, Read("Customer,Amount,Date\n"));
        bool missing = Example.Throws(() => Read("Customer,Amount,Date\nAcme,10.00\n"));
        Example.Require(emptyTable.Rows.Count == 1 && missing, "Empty/missing-field behavior differs.");
        Example.Result(new { data_rows = rows.Count, quoted_comma_and_unicode_checked = true, invariant_numbers_checked = true, empty_keeps_header = true, missing_field_rejected = missing, header_format_retained = true });
    }
}
