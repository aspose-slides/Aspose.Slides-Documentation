---
title: Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσίασης PowerPoint σε .NET
linktitle: Δημιουργία ή Ενημέρωση Διαγραμμάτων
type: docs
weight: 10
url: /el/net/create-chart/
keywords:
- προσθήκη διαγράμματος
- δημιουργία διαγράμματος
- επεξεργασία διαγράμματος
- αλλαγή διαγράμματος
- ενημέρωση διαγράμματος
- διάγραμμα διασποράς
- διάγραμμα πίτας
- διάγραμμα γραμμής
- διάγραμμα χάρτη δέντρου
- διάγραμμα μετοχών
- διάγραμμα κουτιού-βούσκα
- διάγραμμα χωνίου
- διάγραμμα ηλιακής έκρηξης
- διάγραμμα ιστογράμματος
- διάγραμμα ραντάρ
- διάγραμμα πολλαπλών κατηγοριών
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για .NET. Προσθέστε, μορφοποιήστε και επεξεργαστείτε διαγράμματα με πρακτικά παραδείγματα κώδικα σε C#."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργήσετε και να προσαρμόσετε διαγράμματα χρησιμοποιώντας το Aspose.Slides για .NET. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει στις συγκεκριμένες απαιτήσεις του σχεδίου σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα παρουσιάζουν κάθε βήμα, από την έναρξη της παρουσίασης και του αντικειμένου διαγράμματος μέχρι τη ρύθμιση σειρών, αξόνων και υπομνήματος. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε βαθιά κατανόηση του πώς να ενσωματώσετε δυναμική δημιουργία διαγραμμάτων στις εφαρμογές .NET, απλοποιώντας τη διαδικασία δημιουργίας παρουσιάσεων με δεδομένα.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα τα δεδομένα και να αντλούν πληροφορίες που ίσως να μην είναι άμεσα εμφανείς από έναν πίνακα ή λογιστικό φύλλο.

**Γιατί να δημιουργούμε διαγράμματα;**

Με τα διαγράμματα μπορείτε:

* να συγκεντρώνετε, συμπτυχίζετε ή συνοψίζετε μεγάλες ποσότητες δεδομένων σε μία μόνο διαφάνεια μιας παρουσίασης·
* να αποκαλύπτετε μοτίβα και τάσεις στα δεδομένα·
* να προσδιορίζετε την κατεύθυνση και την ώθηση των δεδομένων κατά το χρόνο ή σε σχέση με μια συγκεκριμένη μονάδα μέτρησης·
* να εντοπίζετε εξαιρέσεις, αποκλίσεις, σφάλματα και ασυνεπή δεδομένα·
* να επικοινωνείτε ή να παρουσιάζετε πολύπλοκα δεδομένα.

Στο PowerPoint, μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας *Insert*, η οποία παρέχει πρότυπα για σχεδίαση πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά διαγράμματα (βασισμένα σε δημοφιλείς τύπους) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="info" title="Note" %}}
Χρησιμοποιήστε την αρίθμηση [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) κάτω από το namespace [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/). Οι τιμές σε αυτήν την αρίθμηση αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.
{{% /alert %}}

### **Δημιουργία Ομαδοποιημένων Στήλης Διαγραμμάτων**

Αυτό το παράδειγμα χρησιμοποιεί το [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να δημιουργήσει ένα ομαδοποιημένο στήλη διάγραμμα που συγκρίνει δύο σειρές σε τρεις κατηγορίες. Οι σειρές χρησιμοποιούν κόκκινα και πράσινα γεμίσματα, και ξεχωριστές ετικέτες επιδεικνύουν τα ονόματα των κατηγοριών, των σειρών και τις τιμές. Ο δείκτης φύλλου εργασίας 0 αναφέρεται στο πρώτο φύλλο του ενσωματωμένου βιβλίου διαγραμμάτων.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series[0];

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

series = chart.ChartData.Series[1];

valueCell = workbook.GetCell(worksheetIndex, 1, 2, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 2, 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 2, 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

var label = series.DataPoints[0].Label;
label.DataLabelFormat.ShowCategoryName = true;

label = series.DataPoints[1].Label;
label.DataLabelFormat.ShowSeriesName = true;

label = series.DataPoints[2].Label;
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.ShowSeriesName = true;
label.DataLabelFormat.Separator = "/";

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διάγραμμα στήλης ομαδοποιημένου τύπου](clustered_column_chart.png)

### **Δημιουργία Διαγραμμάτων Scatter**

Τα διαγράμματα scatter (γνωστά επίσης ως scatter plots ή διαγράμματα x‑y) χρησιμοποιούνται συχνά για να ελέγξετε μοτίβα ή να δείξετε συσχετίσεις μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε ένα διάγραμμα scatter όταν:

* Διαθέτετε ζεύγος αριθμητικών δεδομένων·
* Διαθέτετε δύο μεταβλητές που ταιριάζουν καλά μεταξύ τους·
* Θέλετε να καθορίσετε εάν οι δύο μεταβλητές είναι σχετικές·
* Διαθέτετε μια ανεξάρτητη μεταβλητή που έχει πολλαπλές τιμές για μια εξαρτημένη μεταβλητή.

Αυτό το παράδειγμα σχεδιάζει δύο σύνολα τιμών x‑y. Η πρώτη σειρά χρησιμοποιεί ευθείες γραμμές με δείκτες αστέρων, ενώ η δεύτερη χρησιμοποιεί ομαλές γραμμές με δείκτες κύκλων· και οι δύο χρησιμοποιούν ένα [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) 10. Η ιδιότητα [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) ελέγχει το σχήμα του δείκτη.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 1, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 1, 3, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var series = chart.ChartData.Series[0];

var xValueCell = workbook.GetCell(worksheetIndex, 2, 1, 1);
var yValueCell = workbook.GetCell(worksheetIndex, 2, 2, 3);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 1, 2);
yValueCell = workbook.GetCell(worksheetIndex, 3, 2, 10);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

series = chart.ChartData.Series[1];

xValueCell = workbook.GetCell(worksheetIndex, 2, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 2, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 3, 3);
yValueCell = workbook.GetCell(worksheetIndex, 3, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 4, 3, 2);
yValueCell = workbook.GetCell(worksheetIndex, 4, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 5, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 5, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διάγραμμα scatter](scatter_chart.png)

### **Δημιουργία Δικατογράμματα**

Τα διχοτομικά διαγράμματα (pie charts) είναι ιδανικά για την εμφάνιση της σχέσης μέρους προς όλο στα δεδομένα, ιδιαίτερα όταν τα δεδομένα περιέχουν κατηγοριοποιημένες ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιέχουν πολλά τμήματα ή ετικέτες, ίσως θελήσετε να χρησιμοποιήσετε ένα ραβδόγραμμα αντί αυτού.

Αυτό το παράδειγμα δημιουργεί ένα διχοτομικό διάγραμμα με τρεις τριμηνιαίες τιμές. Κάθε φέτα έχει προσαρμοσμένο γέμισμα και περίγραμμα, και οι ετικέτες εμφανίζουν διαφορετικούς συνδυασμούς τιμών, ποσοστών και πληροφοριών σειράς. Η ιδιότητα [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) ορίζει την πρώτη φέτα να ξεκινάει στις 180 μοίρες.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var categoryCell = workbook.GetCell(0, 1, 0, "1st Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "2nd Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "3rd Qtr");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForPieSeries(valueCell);

chart.ChartData.SeriesGroups[0].IsColorVaried = true;

var firstSlice = series.DataPoints[0];
firstSlice.Format.Fill.FillType = FillType.Solid;
firstSlice.Format.Fill.SolidFillColor.Color = Color.Cyan;

firstSlice.Format.Line.FillFormat.FillType = FillType.Solid;
firstSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
firstSlice.Format.Line.Width = 3.0;
firstSlice.Format.Line.Style = LineStyle.ThinThick;
firstSlice.Format.Line.DashStyle = LineDashStyle.LargeDash;

var secondSlice = series.DataPoints[1];
secondSlice.Format.Fill.FillType = FillType.Solid;
secondSlice.Format.Fill.SolidFillColor.Color = Color.Brown;

secondSlice.Format.Line.FillFormat.FillType = FillType.Solid;
secondSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
secondSlice.Format.Line.Width = 3.0;
secondSlice.Format.Line.Style = LineStyle.Single;
secondSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

var thirdSlice = series.DataPoints[2];
thirdSlice.Format.Fill.FillType = FillType.Solid;
thirdSlice.Format.Fill.SolidFillColor.Color = Color.Coral;

thirdSlice.Format.Line.FillFormat.FillType = FillType.Solid;
thirdSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
thirdSlice.Format.Line.Width = 2.0;
thirdSlice.Format.Line.Style = LineStyle.ThinThin;
thirdSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

var firstLabel = series.DataPoints[0].Label;
firstLabel.DataLabelFormat.ShowValue = true;

var secondLabel = series.DataPoints[1].Label;
secondLabel.DataLabelFormat.ShowValue = true;
secondLabel.DataLabelFormat.ShowLegendKey = true;
secondLabel.DataLabelFormat.ShowPercentage = true;

var thirdLabel = series.DataPoints[2].Label;
thirdLabel.DataLabelFormat.ShowSeriesName = true;
thirdLabel.DataLabelFormat.ShowPercentage = true;

series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

presentation.Save("PieChart.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διχοτομικό διάγραμμα](pie_chart.png)

Για να βελτιώσετε την αναγνωσιμότητα των ετικετών εκτός του διχοτομικού, δείτε το [Format Leader Lines](/slides/el/net/chart-data-label/#format-leader-lines) για ένα παράδειγμα που τοποθετεί ετικέτες και προσαρμόζει το χρώμα, το πλάτος, τη διαφάνεια και το στιλ παύλας των γραμμών.

### **Δημιουργία Διαγραμμάτων Γραμμής**

Τα διαγράμματα γραμμής (line charts) είναι ιδανικά όταν θέλετε να δείξετε αλλαγές στην τιμή με την πάροδο του χρόνου. Με ένα διάγραμμα γραμμής, μπορείτε να συγκρίνετε μεγάλο όγκο δεδομένων μονομιάς, να παρακολουθείτε αλλαγές και τάσεις με την πάροδο του χρόνου, να υπογραμμίζετε ανωμαλίες σε σειρές δεδομένων και πολλά άλλα.

Αυτό το παράδειγμα χρησιμοποιεί το [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να δημιουργήσει ένα διάγραμμα γραμμής με τις προεπιλεγμένες σειρές και κατηγορίες, στη συνέχεια αποθηκεύει την παρουσίαση ως PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

Από προεπιλογή, τα σημεία ενός διαγράμματος γραμμής ενώνονται με ευθείες συνεχείς γραμμές. Εάν θέλετε τα σημεία να ενώνονται με παύλες, ορίστε το [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) σε μια τιμή από το [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

foreach (var series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Το αποτέλεσμα:

![Το διάγραμμα γραμμής](line_chart.png)

### **Δημιουργία Διαγραμμάτων Tree Map**

Τα διαγράμματα tree map είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών δεδομένων και να τραβήξετε γρήγορα την προσοχή σε στοιχεία που συμβάλλουν σημαντικά μέσα σε κάθε κατηγορία.

Αυτό το παράδειγμα δημιουργεί ένα tree map με οκτώ φύλλα ομαδοποιημένα σε τέσσερα στελέχη και δύο κλαδιά. Η μέθοδος [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) εκχωρεί στελέχη στο επίπεδο ομαδοποίησης 1 και κλαδιά στο επίπεδο 2. Οι τιμές καθορίζουν τα σχετικά μεγέθη των ορθογωνίων, ενώ οι ετικέτες κατηγορίας και οι επικαλυπτόμενες γονικές ετικέτες προσδιορίζουν την ιεραρχία.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Κλαδί 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Κλαδί 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Treemap);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);

series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

presentation.Save("Treemap.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διάγραμμα treemap](treemap_chart.png)

### **Δημιουργία Διαγραμμάτων Waterfall**

Ένα διάγραμμα waterfall δείχνει πώς οι θετικές και αρνητικές αλλαγές συνεισφέρουν σε μια τελική τιμή. Για παράδειγμα, μια ανάλυση κέρδους μπορεί να ξεκινήσει με τα έσοδα, να αφαιρέσει τα κόστη και να προσθέσει άλλα έσοδα. Οι στήλες αλλαγής “πλέουν” μεταξύ της προηγούμενης και της νέας τρέχουσας τιμής, ενώ οι στήλες σύνολο εκτείνονται από το μηδέν έως την συσσωρευμένη τιμή.

Το παρακάτω παράδειγμα χρησιμοποιεί ποσά σε χιλιάδες δολαρίων ΗΠΑ:

| Κατηγορία | Τιμή βιβλίου εργασίας | Τύπος στήλης |
| --- | ---: | --- |
| Έσοδα | 1000 | Αύξηση |
| Κόστος πωλήσεων | -400 | Μείωση |
| Ακαθάριστο κέρδος | 600 | Ενδιάμεσο σύνολο |
| Λειτουργικά έξοδα | -200 | Μείωση |
| Άλλα έσοδα | 50 | Αύξηση |
| Καθαρό κέρδος | 450 | Τελικό σύνολο |

Για να χαρακτηρίσετε ένα σημείο ως ενδιάμεσο ή τελικό σύνολο, ορίστε την ιδιότητα [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) του σε `true`. Παρέχετε το πραγματικό συσσωρευμένο ποσό στο κελί βιβλίου εργασίας του σημείου: `600` για το ακαθάριστο κέρδος (`1000 - 400`) και `450` για το καθαρό κέρδος (`600 - 200 + 50`). Η ιδιότητα σηματοδοτεί τη στήλη ως σύνολο· δεν υπολογίζει ούτε συμπληρώνει την τιμή του κελιού. Μην χρησιμοποιείτε το μηδέν ως θέση κράτησης ή άλλο τύπο αλλαγής για σημείο σύνολο. Μια στήλη σύνολο εμφανίζει την συσσωρευμένη τιμή χωρίς να την προσθέτει ξανά στην τρέχουσα τιμή.

Αυτό το πλήρες παράδειγμα C# δημιουργεί ένα διάγραμμα χρησιμοποιώντας το μέλος `Waterfall` του [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/), καθαρίζει τα προεπιλεγμένα δεδομένα και γεμίζει το ενσωματωμένο βιβλίο εργασίας. Ο δείκτης φύλλου `0` επιλέγει το πρώτο φύλλο· η στήλη A περιέχει ονόματα κατηγοριών και η στήλη B τιμές. Κάθε κελί τιμής προστίθεται με το [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/). Οι δείκτες σημείων `2` και `5` (μηδενικής βάσης) αναγνωρίζουν τα ενδιάμεσα και τα τελικά σύνολα. Η ενεργοποίηση του [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) εμφανίζει τα ποσά στις στήλες. Δεν απαιτείται παρουσίαση ή βιβλίο εργασίας εισόδου.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Waterfall, 20, 20, 680, 200);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Profit breakdown (USD thousands)");
chart.ChartTitle.Overlay = false;
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

workbook.Clear(worksheetIndex);

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Profit");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Waterfall);
var categories = new[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
var values = new double[] { 1000, -400, 600, -200, 50, 450 };

for (var i = 0; i < categories.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categories[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForWaterfallSeries(valueCell);
}

// Τα τρίτο και έκτο σημεία αντιπροσωπεύουν σύνολα, όχι επιπλέον αλλαγές.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

Ορίστε την ιδιότητα [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) σε `true` για να εμφανίζονται γραμμές σύνδεσης των διαδοχικών στηλών και να γίνεται πιο εύκολο να ακολουθήσετε την τρέχουσα τιμή. Για να κρύψετε αυτές τις γραμμές, αντικαταστήστε την εκχώρηση στο παράδειγμα με `series.ShowConnectorLines = false;` πριν αποθηκεύσετε. Αυτό αλλάζει μόνο την ορατότητα των γραμμών, όχι τα δεδομένα ή τα σύνολα.

Η αποθηκευμένη παρουσίαση δείχνει ακαθάριστο κέρδος 600 και καθαρό κέρδος 450, με και τα δύο σύνολα να ξεκινούν από το μηδέν:

![Διάγραμμα waterfall που δείχνει έσοδα, κόστη, ακαθάριστο κέρδος 600 και καθαρό κέρδος 450, με ετικέτες τιμών και γραμμές σύνδεσης](waterfall_chart.png)

### **Δημιουργία Διαγραμμάτων Stock**

Τα διαγράμματα stock χρησιμοποιούνται για την εμφάνιση χρηματοοικονομικών δεδομένων όπως τιμές άνοιγμα, υψηλή, χαμηλή και κλείσιμο, βοηθώντας στην ανάλυση τάσεων αγοράς και μεταβλητότητας. Παρέχουν ουσιώδεις πληροφορίες για την απόδοση των μετοχών, βοηθώντας επενδυτές και αναλυτές να λαμβάνουν τεκμηριωμένες αποφάσεις.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα open‑high‑low‑close με τέσσερις σειρές σε αυτή τη σειρά και τρεις κατηγορίες. Η ιδιότητα [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) ενεργοποιεί τις μπάρες up/down, και το [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) ελέγχει τις γραμμές high‑low που δείχνουν τα εύρη τιμών, ενώ οι ατομικές γραμμές σειρών και οι οριζόντιες γραμμές πλέγματος είναι κρυμμένες.

Ο διαχειριστής [UpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/updownbars/) εκθέτει ξεχωριστές αντικείμενα [UpBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/upbarsformat/) και [DownBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/downbarsformat/). Χρησιμοποιήστε τις ιδιότητες [Fill](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/fill/) και [Line](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/line/) κάθε αντικειμένου για να ορίσετε το γέμισμα και το περίγραμμα ανεξάρτητα. Αυτό το παράδειγμα χρησιμοποιεί πράσινες μπάρες με σκούρο‑πράσινο περίγραμμα για αυξητικά διαστήματα και πορτοκαλί‑κόκκινες μπάρες με σκούρο‑κόκκινο περίγραμμα για μειωτικά διαστήματα.

Παρέχετε αριθμητικές τιμές για όλες τις τέσσερις σειρές σε κάθε κατηγορία, με High και Low να περικλείουν Open και Close. Οι μπάρες συγκρίνουν το Close με το Open **στην ίδια κατηγορία**, όχι με την προηγούμενη: το A πτρέπει από 72 σε 25, ενώ το B αυξάνεται από 25 σε 38 και το C από 38 σε 50. Ισες τιμές Open και Close δεν παράγουν ορατό γεμάτο διάστημα. Οι μπάρες up/down καλύπτουν το Open‑Close· οι γραμμές high‑low καλύπτουν το Low‑High. Αυτές οι μπάρες ανήκουν στην ομάδα σειρών και δεν είναι κανονικές σειρές ραβδίου.

Αυτή η μορφοποίηση λειτουργεί επίσης με διαγράμματα [Line and LineWithMarkers](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) που περιέχουν τουλάχιστον δύο σειρές στην ίδια ομάδα και αντίστοιχες αριθμητικές τιμές για κάθε κατηγορία. Για αυτά τα μη‑συσσωρευμένα διαγράμματα γραμμής, οι μπάρες up/down συγκρίνουν την πρώτη και την τελευταία σειρά: μια υψηλότερη τελική τιμή παράγει μπρά up, και μια χαμηλότερη τελική τιμή παράγει μπρά down. Αντιστρέφοντας αυτές τις σειρές αντιστρέφεται και η ταξινόμηση. Το παράδειγμα παρακάτω χρησιμοποιεί το [OpenHighLowClose](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/); μην υποθέτετε ότι άλλες παραλλαγές stock, stacked‑line ή 3D χρησιμοποιούν την ίδια διάταξη δεδομένων ή ερμηνεία διαστημάτων.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

var workbook = chart.ChartData.ChartDataWorkbook;

var categoryCell = workbook.GetCell(0, 1, 0, "A");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "B");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "C");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Open");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 2, "High");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 3, "Low");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 4, "Close");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);

var series = chart.ChartData.Series[0];
var valueCell = workbook.GetCell(0, 1, 1, 72);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 1, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 1, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[1];
valueCell = workbook.GetCell(0, 1, 2, 172);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[2];
valueCell = workbook.GetCell(0, 1, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 3, 13);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[3];
valueCell = workbook.GetCell(0, 1, 4, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 4, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 4, 50);
series.DataPoints.AddDataPointForStockSeries(valueCell);

var upDownBars = chart.ChartData.SeriesGroups[0].UpDownBars;
upDownBars.HasUpDownBars = true;

upDownBars.UpBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Fill.SolidFillColor.Color = Color.LimeGreen;
upDownBars.UpBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkGreen;
upDownBars.UpBarsFormat.Line.Width = 2;

upDownBars.DownBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Fill.SolidFillColor.Color = Color.OrangeRed;
upDownBars.DownBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkRed;
upDownBars.DownBarsFormat.Line.Width = 2;

chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα, εξαγόμενο από το PowerPoint:

![Διάγραμμα stock με πορτοκαλί‑κόκκινο μειωτικό διάστημα για το A και πράσινα αυξητικά διαστήματα για το B και το C](stock_chart.png)

### **Δημιουργία Διαγραμμάτων Box and Whisker**

Τα διαγράμματα box and whisker χρησιμοποιούνται για την εμφάνιση της κατανομής των δεδομένων μέσω συνοπτικών βασικών στατιστικών μέτρων, όπως η διάμεσος, τα τεταρτημόρια και οι πιθανές εξαιρέσεις. Είναι ιδιαίτερα χρήσιμα στην εξερευνητική ανάλυση δεδομένων και στις στατιστικές μελέτες για την γρήγορη κατανόηση της μεταβλητότητας των δεδομένων και την ταυτοποίηση τυχόν ανωμαλιών.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα box and whisker από έξι τιμές. Η ιδιότητα [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) επιλέγει τον αποκλειστικό υπολογισμό τεταρτημορίων. Το παράδειγμα ενεργοποιεί επίσης γραμμές μέσου όρου, δείκτες μέσου, εσωτερικά σημεία και σημεία εξαιρέσεων.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

series.QuartileMethod = QuartileMethodType.Exclusive;
series.ShowMeanLine = true;
series.ShowMeanMarkers = true;
series.ShowInnerPoints = true;
series.ShowOutlierPoints = true;

var valueCell = workbook.GetCell(0, "B1", 15);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 41);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 10);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 23);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);

presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
```

### **Δημιουργία Διαγραμμάτων Funnel**

Τα διαγράμματα funnel χρησιμοποιούνται για την οπτικοποίηση διαδικασιών που περιλαμβάνουν διαδοχικά στάδια, όπου ο όγκος των δεδομένων μειώνεται καθώς προχωρά από το ένα βήμα στο επόμενο. Είναι ιδιαίτερα χρήσιμα για την ανάλυση ποσοστών μετατροπής, την ταυτοποίηση bottlenecks και την παρακολούθηση της αποδοτικότητας διαδικασιών πωλήσεων ή μάρκετινγκ.

Αυτό το παράδειγμα χρησιμοποιεί το [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να προσθέσει ένα funnel διάγραμμα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Αντικαθιστά τα προεπιλεγμένα δεδομένα με έξι κατηγορίες και τιμές από 50 έως 500, στη συνέχεια αποθηκεύει την ενημερωμένη παρουσίαση. Η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Funnel);

var valueCell = workbook.GetCell(0, "B1", 50);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 100);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 200);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 300);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 400);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 500);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);

presentation.Save("Funnel.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διάγραμμα funnel](funnel_chart.png)

### **Δημιουργία Διαγραμμάτων Sunburst**

Τα διαγράμματα sunburst χρησιμοποιούνται για την οπτικοποίηση ιεραρχικών δεδομένων, εμφανίζοντας τα επίπεδα ως συγκεντρωτικούς δακτυλίους. Βοηθούν στην απεικόνιση σχέσεων μέρους προς όλο και είναι ιδανικά για την αναπαράσταση ένθετων κατηγοριών και υποκατηγοριών με σαφή και συμπαγή μορφή.

Αυτό το παράδειγμα δημιουργεί ένα sunburst διάγραμμα με οκτώ φύλλα ομαδοποιημένα σε τέσσερα στελέχη και δύο κλαδιά. Η μέθοδος [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) εκχωρεί στελέχη στο επίπεδο ομαδοποίησης 1 και κλαδιά στο επίπεδο 2. Οι ετικέτες κατηγορίας προσδιορίζουν τα τμήματα, και οι τιμές καθορίζουν τα σχετικά μεγέθη τους.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Κλαδί 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Κλαδί 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Sunburst);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);

presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διάγραμμα sunburst](sunburst_chart.png)

### **Δημιουργία Διαγραμμάτων Ιστόγραμμα (Histogram)**

Τα διαγράμματα ιστογράμματος δείχνουν πώς οι αριθμητικές τιμές κατανέμονται σε διαστήματα (bins). Για μηνιαίες αναφορές χρόνου επεξεργασίας παραγγελιών, χρησιμοποιήστε το ίδιο πλάτος διαστήματος και τα ίδια όρια ώστε να διατηρηθούν τα διαστήματα συνεπή και οι κατανομές εύκολα συγκρίσιμες.

Ορίστε την οριζόντια άξονα [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) σε μια λειτουργία από το [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/). Το [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) ισχύει μόνο για `ByBinWidth`; το [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) ισχύει μόνο για `ByNumberOfBins`. Χρησιμοποιήστε `Automatic` ώστε το διάγραμμα να επιλέγει αυτόματα τα bins.

#### **Χρήση Σταθερού Πλάτους Bin**

Αυτό το παράδειγμα ομαδοποιεί χρόνους επεξεργασίας σε διαστήματα 10 λεπτών, με ξεχωριστά bins για χρόνους ≤ 10 λεπτά και > 40 λεπτά. Ενεργοποιήστε αυτά τα bins με τα [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) και [IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/). Όταν ορίζετε ρητά τα όρια [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/) και [OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/), θέστε τις ιδιότητες [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) και [IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) σε `false`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByBinWidth;
axis.BinWidth = 10;
axis.IsUnderflowBin = true;
axis.IsAutomaticUnderflowBin = false;
axis.UnderflowBin = 10;
axis.IsOverflowBin = true;
axis.IsAutomaticOverflowBin = false;
axis.OverflowBin = 40;

presentation.Save("Histogram-bin-width.pptx", SaveFormat.Pptx);
```

Η παρουσίαση στο PowerPoint δείχνει αριθμούς bins **3, 4, 4, 4, και 2**. Το bin υποροής περιλαμβάνει `5, 10, 10`, οπότε το όριό του είναι περιληπτικό. Το bin υπερπροεξόφλησης περιλαμβάνει μόνο `41, 50`, οπότε το όριό του είναι αποκλειστικό· οι τιμές ίσες με `40` παραμένουν στο προηγούμενο διάστημα. Τα ενδιάμεσα bins περιέχουν τιμές μεγαλύτερες από το κατώτερο όριο και μικρότερες ή ίσες με το άνω όριο.

![Ιστόγραμμα με bins 10 λεπτών και ρητά όρια υποροής/υπερπροεξόφλησης](histogram_bin_width.png)

#### **Καθορισμός Αριθμού Bins**

Για σταθερό επίπεδο λεπτομέρειας αντί για σταθερά διαστήματα, ζητήστε πέντε bins για τα ίδια δεδομένα. Αυτό το παράδειγμα αφήνει τα bins υποροής και υπερπροεξόφλησης απενεργοποιημένα. Το διάγραμμα καθορίζει το πλάτος από το εύρος των δεδομένων, οπότε τα όρια μπορούν να αλλάξουν μεταξύ αναφορών.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByNumberOfBins;
axis.NumberOfBins = 5;

presentation.Save("Histogram-bin-count.pptx", SaveFormat.Pptx);
```

Τα πέντε bins έχουν αριθμούς **4, 4, 4, 4, και 1**. Συγκρίνετε αυτήν την κατανομή με το αποτέλεσμα σταθερού πλάτους παραπάνω: οι εισαγόμενες τιμές είναι ίδιες, αλλά τα όρια διαφέρουν.

![Ιστόγραμμα με πέντε bins υπολογισμένα από τα ίδια δεδομένα](histogram_bin_count.png)

### **Δημιουργία Διαγραμμάτων Radar**

Τα διαγράμματα radar χρησιμοποιούνται για την εμφάνιση πολυπαραμετρικών δεδομένων σε δισδιάστατη μορφή, επιτρέποντας εύκολη σύγκριση πολλαπλών μεταβλητών ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα για την αναγνώριση μοτίβων, δυνατών και αδύναμων σημείων σε πολλαπλές μετρήσεις απόδοσης ή χαρακτηριστικά.

Αυτό το παράδειγμα χρησιμοποιεί το [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να δημιουργήσει ένα radar διάγραμμα με τις προεπιλεγμένες σειρές και κατηγορίες, στη συνέχεια αποθηκεύει την παρουσίαση ως PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);

presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διάγραμμα radar](radar_chart.png)

### **Δημιουργία Πολυκατηγορικών Διαγραμμάτων**

Τα πολυκατηγορικά διαγράμματα χρησιμοποιούνται για την εμφάνιση δεδομένων που περιλαμβάνουν περισσότερες από μία κατηγοριοποιημένες ομάδες, επιτρέποντας τη σύγκριση τιμών κατά πολλαπλές διαστάσεις ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα όταν χρειάζεται να αναλύσετε τάσεις και σχέσεις μέσα σε σύνθετα, πολυεπίπεδα σύνολα δεδομένων.

Αυτό το παράδειγμα δημιουργεί ένα ομαδοποιημένο στήλη διάγραμμα με οκτώ κατηγορίες διατεταγμένες σε τέσσερα ζεύγη. Η μέθοδος [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) δίνει σε κάθε ζεύγος μια κοινή ετικέτα στο επίπεδο ομαδοποίησης 1, παράγοντας έναν άξονα κατηγοριών με ατομικές και ομαδικές ετικέτες.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var worksheetIndex = 0;

var categoryCell = workbook.GetCell(0, "c2", "A");
var category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group1");
categoryCell = workbook.GetCell(0, "c3", "B");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c4", "C");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group2");
categoryCell = workbook.GetCell(0, "c5", "D");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c6", "E");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group3");
categoryCell = workbook.GetCell(0, "c7", "F");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c8", "G");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group4");
categoryCell = workbook.GetCell(0, "c9", "H");
category = chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, "D1", "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

var valueCell = workbook.GetCell(worksheetIndex, "D2", 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D3", 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D4", 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D5", 40);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D6", 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D7", 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D8", 70);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D9", 80);
series.DataPoints.AddDataPointForBarSeries(valueCell);

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το πολυκατηγορικό διάγραμμα](multi_category_chart.png)

#### **Αφαίρεση Ετικέτας Τριμήνου**

Κατεβάστε το [quarters.pptx](quarters.pptx) και τοποθετήστε το στον κατάλογο εργασίας. Το διάγραμμα του περιέχει εννιά μήνες και μια σειρά πωλήσεων με τιμές από 10 έως 18. Ο άξονας κατηγορίας έχει τρεις ετικέτες τριμήνου: Q1 καλύπτει Jan‑Mar, Q2 καλύπτει Apr‑Jun και Q3 καλύπτει Jul‑Sep.

Ο Απρίλιος είναι η τέταρτη κατηγορία και η οποία είχε ρητά οριστεί ως Q2. Καλέστε το [DeleteGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/deletegroupingitem/) στη συλλογή [GroupingLevels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/groupinglevels/) του Απριλίου. Το επίπεδο είναι σχετικό με τον Απρίλιο: το επίπεδο 1 είναι το τρίμηνό του, και το επίπεδο 0 είναι ο ίδιος ο μήνας. Η μέθοδος δεν μπορεί να αφαιρέσει την κατηγορία φύλλου στο επίπεδο 0.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (var presentation = new Presentation("quarters.pptx"))
{
    var chart = (IChart)presentation.Slides[0].Shapes[0];
    var april = chart.ChartData.Categories[3];
    april.GroupingLevels.DeleteGroupingItem(1);

    presentation.Save("quarters-updated.pptx", SaveFormat.Pptx);
}

using var reopened = new Presentation("quarters-updated.pptx");
var updatedChart = (IChart)reopened.Slides[0].Shapes[0];
var data = updatedChart.ChartData;

Console.WriteLine(string.Join(", ", data.Categories.Select(month => month.AsCell.Value)));
Console.WriteLine(string.Join(", ", data.Series[0].DataPoints.Select(point => point.Value.Data)));
```

Το ξανανοιγμένο διάγραμμα εμφανίζει τους αρχικούς μήνες (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) και τις τιμές πωλήσεων (`10, 11, 12, 13, 14, 15, 16, 17, 18`) με την ίδια σειρά. Ανοίξτε το `quarters‑updated.pptx` στο PowerPoint για να συγκρίνετε τις ετικέτες άξονα. Η ετικέτα Q2 και το όριο ομάδας πριν τον Απρίλιο εξαφανίζονται, έτσι το Q1 καλύπτει τον Ιανουάριο έως Ιούνιο. Το Q3 εξακολουθεί να ξεκινάει τον Ιούλιο.

![Ετικέτες τριμήνου πριν και μετά την αφαίρεση. Στα αριστερά, το Q2 καλύπτει Απρίλιο‑Ιούνιο. Στα δεξιά, το Q1 καλύπτει Ιανουάριο‑Ιούνιο.](quarter-label-comparison.png)

### **Δημιουργία Διαγραμμάτων Χάρτη**

Τα διαγράμματα χάρτη χρησιμοποιούνται για την οπτικοποίηση γεωγραφικών δεδομένων, αντιστοιχίζοντας πληροφορίες σε συγκεκριμένες τοποθεσίες όπως χώρες, πολιτείες ή πόλεις. Είναι ιδιαίτερα χρήσιμα για την ανάλυση περιφερειακών τάσεων, δημογραφικών δεδομένων και χωρικών κατανομών με σαφή, ελκυστική οπτική παρουσίαση.

Αυτό το παράδειγμα χρησιμοποιεί το [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να δημιουργήσει ένα διάγραμμα χάρτη με τα προεπιλεγμένα γεωγραφικά δεδομένα και το αποθηκεύει για προβολή στο PowerPoint.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);

presentation.Save("mapChart.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διάγραμμα χάρτη](map_chart.png)

{{% alert color="info" title="Note" %}}
Η εικόνα παραπάνω δείχνει την αποθηκευμένη παρουσίαση ανοιγμένη στο PowerPoint. Το Aspose.Slides γράφει σωστά το διάγραμμα χάρτη και τα δεδομένα του, αλλά δεν σχεδιάζει τα χάρτες αυτόνομα: όταν μια διαφάνεια που περιέχει ένα τέτοιο διάγραμμα αποτυπώνεται σε εικόνα ή μετατρέπεται σε PDF ή SVG, η περιοχή του διαγράμματος παραμένει κενή. Τα άλλα σχήματα στην ίδια διαφάνεια δεν επηρεάζονται.
{{% /alert %}}

### **Δημιουργία Συνδυαστικών Διαγραμμάτων**

Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα γράφημα. Αυτό το διάγραμμα σας επιτρέπει να τονίσετε, να συγκρίνετε ή να εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.

![Το συνδυαστικό διάγραμμα](combination_chart.png)

Αυτό το παράδειγμα συνδυάζει δύο ομαδοποιημένες στήλες με μια σειρά γραμμής επί τέσσερις κατηγορίες. Οι στήλες χρησιμοποιούν τον κύριο κάθετο άξονα, ενώ το [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) τοποθετεί τη γραμμή σε έναν δευτερεύοντα κάθετο άξονα στα δεξιά. Οι βοηθητικές λειτουργίες διαμορφώνουν τον τίτλο, το υπόμνημα, τις ετικέτες άξονα και τις γραμμές πλέγματος.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

CreateComboChart();

static void CreateComboChart()
{
    using var presentation = new Presentation();
    var chart = CreateChartWithFirstSeries(presentation.Slides[0]);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
}

static IChart CreateChartWithFirstSeries(ISlide slide)
{
    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    var portionFormat = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    var worksheetIndex = 0;

    var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 4, 0, "Category 4");
    chart.ChartData.Categories.Add(categoryCell);

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
    var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 4.3);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 1, 2.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 1, 3.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 1, 4.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);

    return chart;
}

static void AddSecondSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 2, 2.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 2, 4.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 2, 1.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 2, 2.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

static void AddThirdSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Line);

    var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 3, 3.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 3, 5.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);

    series.PlotOnSecondAxis = true;
}

static void SetPrimaryAxesFormat(IChart chart)
{
    var horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    var verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    var majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

static void SetSecondaryAxesFormat(IChart chart)
{
    var secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    var secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    var titlePortionFormat = axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Ενημέρωση Διαγραμμάτων**

Το Aspose.Slides για .NET σας επιτρέπει να ενημερώνετε διαγράμματα PowerPoint τροποποιώντας δεδομένα διαγράμματος, μορφοποίηση και στυλ. Αυτή η λειτουργικότητα απλοποιεί τη διαδικασία διατήρησης των παρουσιάσεων ενημερωμένων με δυναμικό περιεχόμενο και εξασφαλίζει ότι τα διαγράμματα αντανακλούν ακριβώς τα τρέχοντα δεδομένα και τα οπτικά πρότυπα.

Αυτό το παράδειγμα ενημερώνει το διάγραμμα με όνομα «My chart» στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Απαιτούνται δύο στήλες σειρών με τρία σημεία δεδομένων η κάθε μια, με ετικέτες κατηγοριών στη στήλη A και ονόματα σειρών στην πρώτη γραμμή του πρώτου φύλλου. Το παράδειγμα χρησιμοποιεί τη μέθοδο [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) για να αλλάξει τα κελιά βιβλίου, ενημερώνει τις τιμές σειρών, προσθέτει τρίτη σειρά και αλλάζει το διάγραμμα σε ομαδοποιημένους κυλίνδρους μέσω της ιδιότητας [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        var worksheetIndex = 0;

        var workbook = chart.ChartData.ChartDataWorkbook;

        workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
        workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

        var series = chart.ChartData.Series[0];

        workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1");
        series.DataPoints[0].Value.Data = 90;
        series.DataPoints[1].Value.Data = 123;
        series.DataPoints[2].Value.Data = 44;

        series = chart.ChartData.Series[1];

        workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2");
        series.DataPoints[0].Value.Data = 23;
        series.DataPoints[1].Value.Data = 67;
        series.DataPoints[2].Value.Data = 99;

        var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
        series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

        var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 20);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 2, 3, 50);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 3, 3, 30);
        series.DataPoints.AddDataPointForBarSeries(valueCell);

        chart.Type = ChartType.ClusteredCylinder;
    }
}

presentation.Save("AsposeChartModified.pptx", SaveFormat.Pptx);
```

## **Ορισμός Πεδίου Δεδομένων για Διάγραμμα**

Για να εξετάσετε το εύρος που χρησιμοποιείται ήδη από ένα υπάρχον διάγραμμα, δείτε το [Retrieve a Chart's Data Range](/slides/el/net/chart-workbook/#retrieve-a-charts-data-range).

Το Aspose.Slides για .NET παρέχει την ευελιξία να ορίσετε συγκεκριμένο πεδίο δεδομένων από ένα φύλλο εργασίας ως πηγή για τα δεδομένα του διαγράμματος. Αυτό σημαίνει ότι μπορείτε άμεσα να αντιστοιχίσετε ένα τμήμα του φύλλου εργασίας στο διάγραμμα, ελέγχοντας ποιες κύτταρα συνεισφέρουν στις σειρές και τις κατηγορίες. Ως αποτέλεσμα, μπορείτε εύκολα να ενημερώνετε και να συγχρονίζετε τα διαγράμματά σας με τις τελευταίες αλλαγές δεδομένων στο φύλλο εργασίας, διασφαλίζοντας ότι οι παρουσιάσεις PowerPoint σας αντικατοπτρίζουν τις πιο πρόσφατες και ακριβείς πληροφορίες.

Αυτό το παράδειγμα χρησιμοποιεί το [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) για να ορίσει την πηγή δεδομένων του διαγράμματος με όνομα «My chart» στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης στο `Sheet1!A1:B4`. Το βιβλίο διαγραμμάτων πρέπει να περιέχει το αντίστοιχο φύλλο και ένα πληθωρισμένο εύρος με τίτλο σειράς στην πρώτη γραμμή, ετικέτες κατηγοριών στη στήλη A και τρεις τιμές στη στήλη B.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        chart.ChartData.SetRange("Sheet1!A1:B4");
    }
}

presentation.Save("SetDataRange.pptx", SaveFormat.Pptx);
```

## **Χρήση Προεπιλεγμένων Δεικτών σε Διαγράμματα**

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό προεπιλεγμένο σύμβολο δείκτη.

Αυτό το παράδειγμα χρησιμοποιεί το [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να δημιουργήσει ένα διάγραμμα με δύο σειρές γραμμής και ένα υπόμνημα. Οι ρυθμίσεις [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) διατηρούν τα αυτόματα εκχωρημένα σύμβολα δείκτη. Η πρώτη σειρά περιλαμβάνει μια αρνητική τιμή και μια ελλιπή τιμή, που εκφράζεται με `null`, ενώ η δεύτερη έχει τιμή για κάθε κατηγορία.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(0, 1, 0, "C1");
chart.ChartData.Categories.Add(categoryCell);
var valueCell = workbook.GetCell(0, 1, 1, 24);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 2, 0, "C2");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 2, 1, 23);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 3, 0, "C3");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 3, 1, -10);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 4, 0, "C4");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 4, 1, null);
series.DataPoints.AddDataPointForLineSeries(valueCell);

seriesNameCell = workbook.GetCell(0, 0, 2, "Series 2");
var secondSeries = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

valueCell = workbook.GetCell(0, 1, 2, 30);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 10);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 60);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 4, 2, 40);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);

chart.HasLegend = true;
chart.Legend.Overlay = false;

presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Ποιοι τύποι διαγραμμάτων υποστηρίζονται από το Aspose.Slides για .NET;**

Το Aspose.Slides για .NET υποστηρίζει μια μεγάλη γκάμα τύπων διαγραμμάτων, συμπεριλαμβανομένων bar, line, pie, area, scatter, histogram, radar και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω ένα νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε ένα διάγραμμα, δημιουργείτε πρώτα μια εμφύτευση της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), ανακτάτε τη ζητούμενη διαφάνεια με το δείκτη της και στη συνέχεια καλείτε τη μέθοδο για προσθήκη διαγράμματος, προσδιορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος προσπελάζοντας το βιβλίο δεδομένων του ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)), καθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες και στη συνέχεια προσθέτοντας τα προσαρμοσμένα σας δεδομένα. Αυτό σας επιτρέπει να ανανεώνετε προγραμματιστικά το διάγραμμα ώστε να αντανακλά τα πιο πρόσφατα δεδομένα.

**Μπορώ να προσαρμόσω την εμφάνιση του διαγράμματος;**

Ναι, το Aspose.Slides για .NET παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα στοιχεία μορφοποίησης ώστε να προσαρμόσετε την εμφάνιση του διαγράμματος στις ειδικές απαιτήσεις του σχεδίου σας.

Σχετικό χαρακτηριστικό: [Create editable charts](/slides/el/features/create-charts/).