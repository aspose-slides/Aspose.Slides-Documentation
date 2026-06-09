---
title: "Διαχείριση Φύλλων Εργασίας Διαγραμμάτων σε Παρουσιάσεις στο .NET"
linktitle: "Φύλλο Εργασίας Διαγράμματος"
type: docs
weight: 70
url: /el/net/chart-workbook/
keywords:
- "φύλλο εργασίας διαγράμματος"
- "δεδομένα διαγράμματος"
- "κελί φύλλου εργασίας"
- "ετικέτα δεδομένων"
- "φύλλο εργασίας"
- "πηγή δεδομένων"
- "εξωτερικό φύλλο εργασίας"
- "εξωτερικά δεδομένα"
- "PowerPoint"
- "παρουσίαση"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Ανακαλύψτε το Aspose.Slides για .NET: διαχειριστείτε εύκολα τα φύλλα εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τη διαχείριση των δεδομένων της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με φύλλα εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών φύλλου εργασίας, να χρησιμοποιείτε κελιά φύλλου εργασίας ως ετικέτες δεδομένων διαγράμματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης εργασία με εξωτερικά φύλλα εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να εκχωρήσετε ένα εξωτερικό φύλλο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού φύλλου εργασίας που συνδέεται με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το φύλλο εργασίας είναι διαθέσιμο.

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Φύλλο Εργασίας**
Το Aspose.Slides παρέχει τις μεθόδους [ReadWorkbookStream](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdata/readworkbookstream/) και [WriteWorkbookStream](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdata/writeworkbookstream/) που σας επιτρέπουν να διαβάζετε και να γράφετε φύλλα εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με το Aspose.Cells). **Σημείωση** ότι τα δεδομένα του διαγράμματος πρέπει να οργανώνονται με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

Αυτός ο κώδικας C# δείχνει μια παράδειγμα λειτουργίας:

```c#
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

## **Ορισμός Κελιού Φύλλου Εργασίας ως Ετικέτα Δεδομένων Διαγράμματος**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Προσθέστε ένα διάγραμμα Bubble με κάποια δεδομένα.
1. Πρόσβαση στη σειρά του διαγράμματος.
1. Ορίστε το κελί του φύλλου εργασίας ως ετικέτα δεδομένων.
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε ένα κελί φύλλου εργασίας ως ετικέτα δεδομένων διαγράμματος:

```c#
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

## **Διαχείριση Φύλλων Εργασίας**
Αυτός ο κώδικας C# δείχνει μια λειτουργία όπου η ιδιότητα [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) χρησιμοποιείται για πρόσβαση σε μια συλλογή φύλλων εργασίας:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Καθορισμός Τύπου Πηγής Δεδομένων**
Αυτός ο κώδικας C# δείχνει πώς να καθορίσετε έναν τύπο για πηγή δεδομένων:

```c#
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

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Φύλλου Εργασίας**
Το Aspose.Slides δεν υποστηρίζει τη μορφή Excel δυαδικού φύλλου εργασίας (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε την ιδιότητα `EmbeddedWorkbookType` στο [IChartData](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα.

```csharp
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
            // Το ενσωματωμένο φύλλο εργασίας είναι σε μορφή .xlsb, η οποία δεν υποστηρίζεται.
            continue;
        }

        // Διαβάστε ή τροποποιήστε τα δεδομένα του φύλλου εργασίας διαγράμματος εδώ.
    }
}
```

## **Εξωτερικό Φύλλο Εργασίας**
{{% alert color="primary" %}} 
Στο [Aspose.Slides 19.4](https://docs.aspose.com/slides/el/net/aspose-slides-for-net-19-4-release-notes/) υλοποιήσαμε την υποστήριξη για εξωτερικά φύλλα εργασίας ως πηγή δεδομένων για διαγράμματα.
{{% /alert %}} 

### **Δημιουργία Εξωτερικού Φύλλου Εργασίας**
Χρησιμοποιώντας τις μεθόδους **`ReadWorkbookStream`** και **`SetExternalWorkbook`**, μπορείτε είτε να δημιουργήσετε ένα εξωτερικό φύλλο εργασίας από την αρχή είτε να κάνετε ένα εσωτερικό φύλλο εργασίας εξωτερικό.

Αυτός ο κώδικας C# δείχνει τη διαδικασία δημιουργίας εξωτερικού φύλλου εργασίας:

```c#
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

### **Ορισμός Εξωτερικού Φύλλου Εργασίας**
Χρησιμοποιώντας τη μέθοδο **`SetExternalWorkbook`**, μπορείτε να εκχωρήσετε ένα εξωτερικό φύλλο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση της διαδρομής προς το εξωτερικό φύλλο εργασίας (εάν το δεύτερο μετακινήθηκε).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε φύλλα εργασίας αποθηκευμένα σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να χρησιμοποιήσετε τέτοια φύλλα εργασίας ως εξωτερική πηγή δεδομένων. Εάν δοθεί σχετική διαδρομή για ένα εξωτερικό φύλλο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε ένα εξωτερικό φύλλο εργασίας:

```c#
// Η διαδρομή προς τον φάκελο εγγράφων.
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

Η παράμετρος `ChartData` (στη μέθοδο `SetExternalWorkbook`) χρησιμοποιείται για να καθορίσει εάν ένα φύλλο εργασίας Excel θα φορτωθεί ή όχι.

* Όταν η τιμή του `ChartData` είναι `false`, ενημερώνεται μόνο η διαδρομή του φύλλου εργασίας — τα δεδομένα του διαγράμματος δεν θα φορτωθούν ή ενημερωθούν από το προοριζόμενο φύλλο εργασίας. Μπορείτε να χρησιμοποιήσετε αυτή τη ρύθμιση όταν το προοριζόμενο φύλλο εργασίας δεν υπάρχει ή δεν είναι διαθέσιμο.
* Όταν η τιμή του `ChartData` είναι `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το προοριζόμενο φύλλο εργασίας.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Λήψη Διαδρομής Εξωτερικού Φύλλου Εργασίας Πηγής Δεδομένων για Διάγραμμα**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Δημιουργήστε ένα αντικείμενο για το σχήμα του διαγράμματος.
1. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής (`ChartDataSourceType`) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
1. Καθορίστε τη σχετική κατάσταση με βάση τον τύπο πηγής που είναι ίδιος με τον τύπο πηγής δεδομένων εξωτερικού φύλλου εργασίας.

Αυτός ο κώδικας C# δείχνει τη λειτουργία:

```c#
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

### **Επεξεργασία Δεδομένων Διαγράμματος**
Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά φύλλα εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα εσωτερικών φύλλων εργασίας. Όταν ένα εξωτερικό φύλλο εργασίας δεν μπορεί να φορτωθεί, ρίχνεται εξαίρεση.

Αυτός ο κώδικας C# είναι μια υλοποίηση της περιγραφόμενης διαδικασίας:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο φύλλο εργασίας;**

Ναι. Ένα διάγραμμα έχει έναν [τύπο πηγής δεδομένων](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/datasourcetype/) και μια [διαδρομή σε εξωτερικό φύλλο εργασίας](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/externalworkbookpath/). Εάν η πηγή είναι εξωτερικό φύλλο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή ώστε να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά φύλλα εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν ορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό είναι βολικό για τη φορητότητα του έργου· ωστόσο, να γνωρίζετε ότι η παρουσίαση θα αποθηκεύσει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω φύλλα εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια φύλλα εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων φύλλων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται – μπορούν να χρησιμοποιηθούν μόνο ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό αρχείο XLSX κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσίαση αποθηκεύει έναν [σύνδεσμο στο εξωτερικό αρχείο](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/externalworkbookpath/) και το χρησιμοποιεί για την ανάγνωση δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται όταν η παρουσίαση αποθηκεύεται.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό πρόσβασης;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια συνήθης προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/net/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό φύλλο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντανακλάται σε κάθε διάγραμμα την επόμενη φορά που τα δεδομένα θα φορτωθούν.