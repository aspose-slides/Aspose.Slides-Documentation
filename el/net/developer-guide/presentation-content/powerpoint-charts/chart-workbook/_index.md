---
title: Διαχείριση βιβλίων εργασίας διαγραμμάτων σε παρουσιάσεις σε .NET
linktitle: Βιβλίο εργασίας διαγράμματος
type: docs
weight: 70
url: /el/net/chart-workbook/
keywords:
- βιβλίο εργασίας διαγράμματος
- δεδομένα διαγράμματος
- κελί βιβλίου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό βιβλίο εργασίας
- εξωτερικά δεδομένα
- κρυφή μνήμη διαγράμματος
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για .NET: διαχειριστείτε με ευκολία τα βιβλία εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ρευμάτων βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αναθέσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που είναι συνδεδεμένο με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

## **Διαβάστε και γράψτε δεδομένα διαγράμματος από βιβλίο εργασίας**
Το Aspose.Slides παρέχει τις μεθόδους [ReadWorkbookStream](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdata/readworkbookstream/) και [WriteWorkbookStream](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdata/writeworkbookstream/) που επιτρέπουν την ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα του διαγράμματος πρέπει να οργανώνονται με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

Αυτός ο κώδικας C# παρουσιάζει ένα παράδειγμα λειτουργίας:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

### **Επικύρωση διάταξης διαγράμματος μετά την τροποποίηση βιβλίου εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να προκαλέσει αποτυχία του [IChart.ValidateChartLayout](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/validatechartlayout/) με σφάλμα «index-out-of-range». Καθαρίστε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο διάγραμμα.

```csharp
// Αφού τροποποιήσετε τη ροή του βιβλίου εργασίας (π.χ., χρησιμοποιώντας Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// Καθαρίστε τις υπάρχουσες αναφορές δεδομένων.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

Ο καθαρισμός των συλλογών εξασφαλίζει ότι η δομή των δεδομένων του διαγράμματος είναι συνεπής με το νέο βιβλίο εργασίας, επιτρέποντας στο `ValidateChartLayout` να ολοκληρωθεί χωρίς σφάλματα.

## **Ορισμός κελιού βιβλίου εργασίας ως ετικέτας δεδομένων διαγράμματος**
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα Bubble με κάποια δεδομένα.
4. Προσπελάστε τις σειρές του διαγράμματος.
5. Ορίστε το κελί του βιβλίου εργασίας ως ετικέτα δεδομένων.
6. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων διαγράμματος:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης 

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Διαχείριση φύλλων εργασίας**

Αυτός ο κώδικας C# παρουσιάζει μια λειτουργία όπου η ιδιότητα [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) χρησιμοποιείται για πρόσβαση σε μια συλλογή φύλλων εργασίας:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Καθορισμός τύπου πηγής δεδομένων**

Αυτός ο κώδικας C# δείχνει πώς να καθορίσετε έναν τύπο για μια πηγή δεδομένων:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Ανίχνευση μη υποστηριζόμενων ενσωματωμένων φορμάτ βιβλίων εργασίας**

Το Aspose.Slides δεν υποστηρίζει το φορμάτ βιβλίου εργασίας Excel binary (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε την ιδιότητα `EmbeddedWorkbookType` στο [IChartData](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdata/) μαζί με την αργουμεντική τιμή [WorkbookType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/workbooktype/) για να ανιχνεύσετε μη υποστηριζόμενα φορμάτ και να παραλείψετε αυτά τα διαγράμματα.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Το ενσωματωμένο βιβλίο εργασίας είναι σε μορφή .xlsb, η οποία δεν υποστηρίζεται.
            continue;
        }

        // Διαβάστε ή τροποποιήστε τα δεδομένα του βιβλίου εργασίας του διαγράμματος εδώ.
    }
}
```

## **Εξωτερικό βιβλίο εργασίας**

{{% alert color="info" %}} 
Στο [Aspose.Slides 19.4](https://docs.aspose.com/slides/el/net/aspose-slides-for-net-19-4-release-notes/), υλοποιήσαμε υποστήριξη για εξωτερικά βιβλία εργασίας ως πηγή δεδομένων για διαγράμματα.
{{% /alert %}} 

### **Δημιουργία εξωτερικού βιβλίου εργασίας**
Χρησιμοποιώντας τις μεθόδους **`ReadWorkbookStream`** και **`SetExternalWorkbook`**, μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από το μηδέν είτε να κάνετε ένα εσωτερικό βιβλίο εργασίας εξωτερικό.

Αυτός ο κώδικας C# παρουσιάζει τη διαδικασία δημιουργίας εξωτερικού βιβλίου εργασίας:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Ορισμός εξωτερικού βιβλίου εργασίας**
Χρησιμοποιώντας τη μέθοδο **`SetExternalWorkbook`**, μπορείτε να αναθέσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για ενημέρωση της διαδρομής προς το εξωτερικό βιβλίο εργασίας (εφόσον αυτό έχει μετακινηθεί).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας αποθηκευμένα σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να τα χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Η διαδρομή προς τον κατάλογο εγγράφων.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

Η παράμετρος `ChartData` (στο πλαίσιο της μεθόδου `SetExternalWorkbook`) χρησιμοποιείται για να καθορίσει αν ένα βιβλίο εργασίας Excel θα φορτωθεί ή όχι.

* Όταν η τιμή `ChartData` ορίζεται σε `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας — τα δεδομένα του διαγράμματος δεν θα φορτωθούν ή ενημερωθούν από το βιβλίο εργασίας-στόχο. Μπορεί να θέλετε να χρησιμοποιήσετε αυτή τη ρύθμιση όταν το βιβλίο εργασίας-στόχος δεν υπάρχει ή δεν είναι διαθέσιμο.
* Όταν η τιμή `ChartData` ορίζεται σε `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το βιβλίο εργασίας-στόχο.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Ανάκτηση διαδρομής εξωτερικής πηγής δεδομένων βιβλίου εργασίας ενός διαγράμματος**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε διαφάνεια μέσω του δείκτη της.
3. Δημιουργήστε ένα αντικείμενο για το σχήμα του διαγράμματος.
4. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής (`ChartDataSourceType`) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
5. Καθορίστε τη σχετική κατάσταση με βάση το αν ο τύπος πηγής είναι ίδιος με τον τύπο εξωτερικής πηγής βιβλίου εργασίας.

Αυτός ο κώδικας C# παρουσιάζει τη λειτουργία:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Αποθηκεύει την παρουσίαση
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Επεξεργασία δεδομένων διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας όπως θα κάνατε με εσωτερικά βιβλία εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, πετιέται εξαίρεση.

Αυτός ο κώδικας C# υλοποιεί τη διαδικασία:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Ανάκτηση βιβλίου εργασίας από την κρυφή μνήμη διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να επανακατασκευάσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που είναι αποθηκευμένα στην παρουσίαση. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/), ρυθμίστε το [SpreadsheetOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/spreadsheetoptions/), και θέστε το [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) σε `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα C# ανοίγει μια παρουσίαση της οποίας το διάγραμμα αναφέρεται σε ένα μη διαθέσιμο εξωτερικό βιβλίο εργασίας και προσπελαύνει τα ανακτημένα δεδομένα μέσω [IChart.ChartData](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/chartdata/) και [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides πετιέται `InvalidOperationException`. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των κρυμμένων δεδομένων του διαγράμματος αποτελεί αποδεκτή εναλλακτική, επειδή η κρυφή μνήμη μπορεί να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω αν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [τύπο πηγής δεδομένων](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/datasourcetype/) και μια [διαδρομή προς εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/externalworkbookpath/). Εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν ορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη. Αυτό είναι βολικό για την φορητότητα του έργου· ωστόσο, η παρουσίαση θα αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Η απευθείας επεξεργασία απομακρυσμένων βιβλίων εργασίας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX όταν αποθηκεύει την παρουσίαση;**

Όχι. Η παρουσίαση αποθηκεύει έναν [σύνδεσμο προς το εξωτερικό αρχείο](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/externalworkbookpath/) και το χρησιμοποιεί για ανάγνωση των δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται όταν αποθηκεύεται η παρουσίαση.

**Τι πρέπει να κάνω αν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης όταν δημιουργεί σύνδεσμο. Συνήθως αφαιρείται η προστασία εκ των προτέρων ή δημιουργείται ένα αποκρυπτογραφημένο αντίγραφο (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/net/)) και γίνεται σύνδεση σε αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση αυτού του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα όταν φορτωθούν ξανά τα δεδομένα.