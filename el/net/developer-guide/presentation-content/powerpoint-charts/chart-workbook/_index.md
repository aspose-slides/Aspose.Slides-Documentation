---
title: Διαχείριση βιβλίου εργασίας γραφημάτων σε παρουσιάσεις σε .NET
linktitle: Βιβλίο Εργασίας Γραφήματος
type: docs
weight: 70
url: /el/net/chart-workbook/
keywords:
- βιβλίο εργασίας γραφήματος
- δεδομένα γερήματος
- κελί βιβλίου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό βιβλίο εργασίας
- εξωτερικά δεδομένα
- κρυφή μνήμη γραφήματος
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για .NET: διαχειριστείτε με ευκολία τα βιβλία εργασίας γραφημάτων σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με βιβλία εργασίας γραφημάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα γραφήματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων γραφήματος, να αποκτάτε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του γραφήματος.

Καλύπτει επίσης τη χρήση εξωτερικών βιβλίων εργασίας ως πηγών δεδομένων γραφήματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αναθέσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που συνδέεται με ένα γράφημα και να επεξεργαστείτε τα δεδομένα του γραφήματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

Για κελιά βιβλίου εργασίας που αντιπροσωπεύουν ελλιπή δεδομένα, δείτε [Control the Display of Empty Cells](/slides/el/net/chart-series/) για τη διαφορά μεταξύ κενού κελιού και μηδενικής τιμής, καθώς και για μια σύγκριση γραμμικού γραφήματος των διαθέσιμων τρόπων απεικόνισης.

## **Συμπερίληψη δεδομένων από κρυφές γραμμές και στήλες**

Χρησιμοποιήστε [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) για να ελέγξετε εάν ένα γράφημα σχεδιάζει δεδομένα από κρυφές γραμμές και στήλες του φύλλου εργασίας. Ορίστε το σε `true` για να σχεδιάζονται μόνο τα ορατά κελιά ή σε `false` για να συμπεριληφθούν και τα ορατά και τα κρυφά κελιά. Αυτή η ρύθμιση ελέγχει την σχεδίαση του γραφήματος· δεν κρύβει ή αποκαλύπτει γραμμές ή στήλες του φύλλου εργασίας.

Η [sample presentation](hidden-source-data.pptx) περιέχει ένα γράφημα στήλης ως το πρώτο σχήμα στην πρώτη της διαφάνεια. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιέχει την ακόλουθη πηγή δεδομένων, `A1:C4`. Η γραμμή 3 και η στήλη C είναι κρυφές, αλλά τα κελιά τους εξακολουθούν να περιέχουν τιμές.

| Γραμμή φύλλου εργασίας | A: Μήνας | B: Λιανική | C: Χονδρική (κρυφή στήλη) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (κρυφή γραμμή) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Πρόσβαση στα κελιά πηγής μέσω [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) και ανάγνωση του [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) για να ελέγξετε την κρυφή τους κατάσταση. Αυτή η ιδιότητα είναι μόνο για ανάγνωση. Σε αυτό το αρχείο, το B2 είναι ορατό, το B3 ανήκει στη κρυφή γραμμή και το C2 στην κρυφή στήλη· το παράδειγμα εκτυπώνει `False`, `True` και `True`, αντίστοιχα.

Για αυτό το παράδειγμα, ανανεώστε τα δεδομένα του γραφήματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε το ενσωματωμένο βιβλίο εργασίας με [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) και φορτώστε το ξανά με [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Όταν συμπεριλαμβάνονται όλα τα κελιά, χρησιμοποιήστε επίσης το [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) για να επαναφέρετε το πλήρες εύρος, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουάριος. Η απλή αλλαγή της σημαίας δεν είναι επαρκής για την ανανέωση των δεδομένων γραφήματος και των ετικετών κατηγοριών της παρούσας εμφάνισης.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // Ανανέωση των δεδομένων γραφήματος από το ενσωματωμένο βιβλίο εργασίας.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Επαναφορά του πλήρους εύρους πηγής, συμπεριλαμβανομένων των κρυφών κατηγοριών.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Το παράδειγμα αποθηκεύει δύο εκδόσεις της παρουσίασης: μία με μόνο τις ορατές τιμές Λιανικής (10 και 20) και μια άλλη με όλες τις έξι τιμές. Οι εικόνες παρακάτω δημιουργήθηκαν από τις αποθηκευμένες παρουσιάσεις μετά το άνοιγμά τους· και τα δύο αρχεία διατηρούν τη ρύθμιση σχεδίασης που είχε οριστεί. Η γραμμή 3 και η στήλη C παραμένουν κρυφές και στα δύο ενσωματωμένα βιβλία εργασίας.

| Μόνο ορατά κελιά (`true`) | Όλα τα κελιά (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. Το [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή εξαιρεί κρυφά δεδομένα πηγής. Δείτε [Control the Display of Empty Cells](/slides/el/net/chart-series/#control-the-display-of-empty-cells) για ένα παράδειγμα.

## **Ανάκτηση εύρους δεδομένων γραφήματος**

Πριν ενημερώσετε τα δεδομένα βιβλίου εργασίας σε μια υπάρχουσα παρουσίαση, ελέγξτε τα εύρη πηγών για να προσδιορίσετε ποια κελιά φύλλου εργασίας χρησιμοποιεί κάθε γράφημα. Η μέθοδος [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) επιστρέφει το τρέχον εύρος δεδομένων ως τύπο που αναγνωρίζεται από το φύλλο εργασίας, π.χ. `Sheet1!$A$1:$D$5`. Εδώ, το `Sheet1` είναι το όνομα του φύλλου, το `!` το διαχωρίζει από το εύρος κελιών και το `$A$1:$D$5` υποδεικνύει τα κελιά A1 έως D5, συμπεριλαμβανομένων. Τα σύμβολα δολαρίου υποδεικνύουν απόλυτες αναφορές γραμμής και στήλης.

Η μέθοδος διαβάζει το τρέχον εύρος χωρίς να αλλάξει το γράφημα ή το βιβλίο εργασίας του. Εάν το γράφημα δεν χρησιμοποιεί βιβλίο εργασίας ως πηγή δεδομένων, προκαλεί [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Για περισσότερες πληροφορίες, δείτε την [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Αυτό το παράδειγμα ανοίγει μια παρουσίαση και ελέγχει τα σχήματα άμεσα σε κάθε διαφάνεια για γραφήματα. Εκτυπώνει το όνομα κάθε γραφήματος και το εύρος πηγής του. Εάν ένα γράφημα δεν χρησιμοποιεί βιβλίο εργασίας, εκτυπώνει ένα μήνυμα και συνεχίζει στο επόμενο γράφημα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **Ανάγνωση και εγγραφή δεδομένων γραφήματος από βιβλίο εργασίας**

Το Aspose.Slides for .NET παρέχει τις μεθόδους [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) και [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) που επιτρέπουν την ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων γραφήματος (που περιέχουν δεδομένα γραφήματος επεξεργασμένα με Aspose.Cells). **Note** ότι τα δεδομένα του γραφήματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν παρόμοια δομή με την πηγή.

Αυτό το παράδειγμα χρησιμοποιεί μια παρουσίαση με ένα γράφημα ως το πρώτο σχήμα στην πρώτη διαφάνειά της. Διαβάζει το ενσωματωμένο βιβλίο εργασίας σε μια ροή, διαγράφει τις υπάρχουσες σειρές και κατηγορίες και γράφει ξανά το ίδιο βιβλίο εργασίας. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσίαση.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Επικύρωση διάταξης γραφήματος μετά την τροποποίηση του βιβλίου εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το γράφημα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Η ασυμφωνία αυτή μπορεί να κάνει το [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) να αποτύχει με σφάλμα «index-out-of-range». Διαγράψτε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο γράφημα. Αυτό το παράδειγμα χρησιμοποιεί ένα γράφημα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια. Το σχόλιο σημειώνει πού θα γινόταν η επεξεργασία του βιβλίου εργασίας· το εκτελέσιμο παράδειγμα γράφει το αρχικό βιβλίο εργασίας πίσω και επικυρώνει τη διάταξη στη μνήμη.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // Τροποποιήστε τη ροή του βιβλίου εργασίας εδώ, για παράδειγμα, χρησιμοποιώντας το Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Η εκκαθάριση των συλλογών αφαιρεί παλιές αναφορές δεδομένων πριν το βιβλίο εργασίας γραφτεί ξανά. Ανακατασκευάστε τυχόν απαιτούμενες αντιστοιχίες σειρών και κατηγοριών για το ενημερωμένο βιβλίο εργασίας πριν χρησιμοποιήσετε το γράφημα.

## **Ορισμός κελιού βιβλίου εργασίας ως ετικέτας δεδομένων γραφήματος**

Μπορείτε να χρησιμοποιήσετε κείμενο από κελιά βιβλίου εργασίας ως ετικέτες δεδομένων γραφήματος.

Αυτό το παράδειγμα προσθέτει ένα γράφημα φυσαλίδων με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο 0 για τις πρώτες τρεις ετικέτες της πρώτης σειράς, ενεργοποιεί τις ετικέτες από κελιά και αποθηκεύει την ενημερωμένη παρουσίαση.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **Διαχείριση φύλλων εργασίας**

Η ιδιότητα [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) παρέχει πρόσβαση στα φύλλα εργασίας ενός βιβλίου εργασίας γραφήματος. Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με προεπιλεγμένα δεδομένα και εκτυπώνει το όνομα κάθε φύλλου εργασίας στην κονσόλα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **Καθορισμός τύπου πηγής δεδομένων**

Αυτό το παράδειγμα δημιουργεί ένα 3D γράφημα στήλης με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειρών χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί κυριολεκτικό συμβολοσειρά· το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο 0. Η απαρίθμηση [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το παράδειγμα αποθηκεύει την παρουσίαση με τα ενημερωμένα ονόματα σειρών.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Ανίχνευση μη υποστηριζόμενων μορφών ενσωματωμένου βιβλίου εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη μορφή δυαδικού βιβλίου εργασίας Excel (.xlsb) που μπορεί να ενσωματωθεί σε μερικά γραφήματα. Μπορείτε να χρησιμοποιήσετε την ιδιότητα [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) στο [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα γραφήματα. Αυτό το παράδειγμα ελέγχει τα σχήματα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης, παραλείπει μη‑γράφημα σχήματα και εκτυπώνει ένα διαγνωστικό μήνυμα για κάθε γράφημα με ενσωματωμένο βιβλίο εργασίας .xlsb.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Διαβάστε ή τροποποιήστε τα υποστηριζόμενα δεδομένα βιβλίου εργασίας γραφήματος εδώ.
}
```

## **Εξωτερικό βιβλίο εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για γραφήματα.

### **Δημιουργία εξωτερικού βιβλίου εργασίας**

Χρησιμοποιήστε τις μεθόδους [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) και [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) για να εξάγετε ένα ενσωματωμένο βιβλίο εργασίας γραφήματος σε αρχείο και να συνδέσετε το γράφημα με αυτό το εξωτερικό βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με προεπιλεγμένα δεδομένα και εξάγει το βιβλίο εργασίας του. Κλείνει τη ροή εξόδου πριν αναθέσει το εξωτερικό βιβλίο εργασίας ως πηγή δεδομένων του γραφήματος, έπειτα αποθηκεύει την συνδεδεμένη παρουσίαση.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **Ορισμός εξωτερικού βιβλίου εργασίας**

Με τη μέθοδο [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) μπορείτε να αναθέσετε ένα εξωτερικό βιβλίο εργασίας σε ένα γράφημα ως πηγή δεδομένων. Η μέθοδος αυτή μπορεί επίσης να χρησιμοποιηθεί για να ενημερώσετε τη διαδρομή προς το εξωτερικό βιβλίο εργασίας (αν έχει μετακινηθεί).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας αποθηκευμένα σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε να τα χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για το εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή.

Αυτό το παράδειγμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας του οποίου το φύλλο με όνομα `Sheet1` περιέχει ένα όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4 και αριθμητικές τιμές στο B2:B4. Δημιουργεί ένα γράφημα πίτας, συνδέει το βιβλίο εργασίας και χρησιμοποιεί το [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) για να αντιστοιχίσει το A1:B4 σε μία σειρά και τρεις κατηγορίες. Αποθηκεύει την παρουσίαση με το συνδεδεμένο γράφημα.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

Η παράμετρος `updateChartData` της μεθόδου [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) ελέγχει εάν το βιβλίο εργασίας θα φορτωθεί.

* Όταν `updateChartData` είναι `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας. Τα δεδομένα του γραφήματος δεν φορτώνονται ή ενημερώνονται από το προορισμένο βιβλίο, επομένως το βιβλίο μπορεί να μην είναι διαθέσιμο.
* Όταν `updateChartData` είναι `true`, τα δεδομένα του γραφήματος ενημερώνονται από το προορισμένο βιβλίο εργασίας.

Το παρακάτω παράδειγμα αναθέτει μια εικονική διεύθυνση URL με `updateChartData` ορισμένο σε `false`. Διατηρεί τα προεπιλεγμένα δεδομένα του γραφήματος πίτας και αποθηκεύει την παρουσίαση χωρίς να φορτώσει το μη διαθέσιμο βιβλίο εργασίας.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **Ανάκτηση διαδρομής εξωτερικού βιβλίου εργασίας γραφήματος**

Για να προσδιορίσετε το βιβλίο εργασίας που συνδέεται με ένα γράφημα, ελέγξτε αν το γράφημα χρησιμοποιεί εξωτερική πηγή δεδομένων και ανακτήστε τη διαδρομή του βιβλίου εργασίας.

Αυτό το παράδειγμα ελέγχει το πρώτο σχήμα στην πρώτη διαφάνεια μιας παρουσίασης με εξωτερικό βιβλίο εργασίας. Εάν είναι γράφημα συνδεδεμένο σε εξωτερικό βιβλίο εργασίας, εκτυπώνει το [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **Επεξεργασία δεδομένων γραφήματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στο περιεχόμενο εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, ρίχνεται εξαίρεση.

Αυτό το παράδειγμα χρησιμοποιεί ένα γράφημα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και είναι συνδεδεμένο σε προσβάσιμο εξωτερικό βιβλίο εργασίας. Ορίζει την τιμή του πρώτου σημείου δεδομένων στην πρώτη σειρά στο 100 και αποθηκεύει την ενημερωμένη παρουσίαση. Η επεξεργασία τιμών κελιών μπορεί να ενημερώσει το εξωτερικό αρχείο XLSX· χρησιμοποιήστε ένα αντίγραφο αν χρειάζεται να διατηρήσετε το αρχικό βιβλίο εργασίας.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Ανάκτηση βιβλίου εργασίας από την κρυφή μνήμη γραφήματος**

Εάν ένα γράφημα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανακτήσει το βιβλίο εργασίας του γραφήματος από τα δεδομένα που είναι αποθηκευμένα στην παρουσίαση. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), ρυθμίστε τις [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) του και ορίστε το [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) σε `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα C# ανακτά δεδομένα βιβλίου εργασίας για ένα γράφημα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και αναφέρεται σε μη διαθέσιμο εξωτερικό βιβλίο εργασίας. Πρόσβαση στα ανακτημένα δεδομένα γίνεται μέσω του [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) και του [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Διαβάστε ή τροποποιήστε τα ανακτημένα δεδομένα βιβλίου εργασίας εδώ.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει ένα [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων από την κρυφή μνήμη του γραφήματος είναι αποδεκτή, επειδή η κρυφή μνήμη μπορεί να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **FAQ**

**Μπορώ να προσδιορίσω αν ένα συγκεκριμένο γράφημα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα γράφημα διαθέτει έναν [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) και μια [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε την πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν ορίσετε σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη. Η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX, επομένως η μετακίνηση του βιβλίου εργασίας μπορεί να απαιτήσει ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/μερίδες;**

Ναι, τέτοια βιβλία μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX όταν αποθηκεύει την παρουσίαση;**

Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Η επεξεργασία δεδομένων γραφήματος που προέρχονται από κελιά μπορεί επίσης να ενημερώσει το συνδεδεμένο τοπικό αρχείο XLSX. Χρησιμοποιήστε αντίγραφο του βιβλίου εργασίας εάν πρέπει να παραμείνει αμετάβλητο.

**Τι να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Συνήθης προσέγγιση είναι η αφαίρεση της προστασίας εκ των προτέρων ή η προετοιμασία ενός αποκρυπτογραφημένου αντιγράφου (π.χ. με το [Aspose.Cells](https://reference.aspose.com/cells/net/)) και η σύνδεση σε αυτό το αντίγραφο.

**Μπορούν πολλά γραφήματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε γράφημα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε γράφημα την επόμενη φορά που θα φορτωθούν τα δεδομένα.