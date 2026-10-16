---
title: Δημιουργία ή Ενημέρωση Γραφημάτων Παρουσίασης PowerPoint σε .NET
linktitle: Δημιουργία ή Ενημέρωση Γραφημάτων
type: docs
weight: 10
url: /el/net/create-chart/
keywords:
- προσθήκη γραφήματος
- δημιουργία γραφήματος
- επεξεργασία γραφήματος
- αλλαγή γραφήματος
- ενημέρωση γραφήματος
- γράφημα scatter
- γράφημα πίτας
- γράφημα γραμμής
- γράφημα δέντρου
- γράφημα μετοχών
- γράφημα box‑and‑whisker
- γράφημα χωνιού
- γράφημα ηλιακής έκρηξης
- γράφημα ιστογράμματος
- γράφημα ραντάρ
- πολυκατηγορικό γράφημα
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε γραφήματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για .NET. Προσθέστε, μορφοποιήστε και επεξεργαστείτε γραφήματα με πρακτικά παραδείγματα κώδικα σε C#."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργήσετε και να προσαρμόσετε γραφήματα χρησιμοποιώντας το Aspose.Slides για .NET. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα γράφημα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει στις συγκεκριμένες απαιτήσεις σχεδιασμού σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα απεικονίζουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου γραφήματος μέχρι τη διαμόρφωση σειρών, αξόνων και υπομνημάτων. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε μια σταθερή κατανόηση του πώς να ενσωματώσετε δυναμική δημιουργία γραφημάτων στις .NET εφαρμογές σας, βελτιώνοντας τη διαδικασία δημιουργίας παρουσιάσεων βασισμένων σε δεδομένα.

## **Δημιουργία Γραφήματος**

Τα γραφήματα βοηθούν τους χρήστες να απεικονίζουν γρήγορα δεδομένα και να ανακαλύπτουν πληροφορίες που μπορεί να μην είναι άμεσα προφανείς από έναν πίνακα ή ένα λογιστικό φύλλο.

**Γιατί να Δημιουργούμε Γραφήματα;**

Χρησιμοποιώντας γραφήματα, μπορείτε:

* να συγκεντρώσετε, συμπτύξετε ή συνοψίσετε μεγάλα σύνολα δεδομένων σε μία διαφάνεια παρουσίασης·
* να αποκαλύψετε μοτίβα και τάσεις στα δεδομένα·
* να καταλάβετε τη διεύθυνση και την ορμή των δεδομένων με την πάροδο του χρόνου ή ως προς μια συγκεκριμένη μονάδα μέτρησης·
* να εντοπίσετε εξαιρέματα, αποκλίσεις, σφάλματα και άσχετα δεδομένα·
* να επικοινωνήσετε ή να παρουσιάσετε σύνθετα δεδομένα.

Στο PowerPoint, μπορείτε να δημιουργήσετε γραφήματα μέσω της λειτουργίας *Insert*, η οποία παρέχει πρότυπα για το σχεδιασμό πολλών τύπων γραφημάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά γραφήματα (βάσει δημοφιλών τύπων) όσο και προσαρμοσμένα γραφήματα.

{{% alert color="info" title="Note" %}}
Χρησιμοποιήστε την απαρίθμηση [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) στο χώρο ονομάτων [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/). Οι τιμές σε αυτήν την απαρίθμηση αντιστοιχούν σε διαφορετικούς τύπους γραφημάτων.
{{% /alert %}}

### **Δημιουργία Συγκεντρωτικών Γραφημάτων Στήλης**

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να δημιουργήσει ένα συγκεντρωτικό γράφημα στήλης που συγκρίνει δύο σειρές σε τρεις κατηγορίες. Οι σειρές χρησιμοποιούν κόκκινο και πράσινο γέμισμα, και τα μεμονωμένα ετικέτες δείχνουν τα ονόματα κατηγοριών, σειρών και τιμών. Ο δείκτης φύλλου εργασίας 0 αναφέρεται στο πρώτο φύλλο του ενσωματωμένου βιβλίου γραφήματος.

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

![Το συγκεντρωτικό γράφημα στήλης](clustered_column_chart.png)

### **Δημιουργία Γραφημάτων Απόσπασμα (Scatter)**

Τα γραφήματα scatter (επίσης γνωστά ως scatter plots ή x‑y γραφήματα) χρησιμοποιούνται συχνά για να ελέγξουν μοτίβα ή να επιδείξουν συσχέτιση μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε ένα γράφημα scatter όταν:

* Έχετε ζευγάρια αριθμητικών δεδομένων·
* Έχετε δύο μεταβλητές που ταιριάζουν καλά μεταξύ τους·
* Θέλετε να διαπιστώσετε εάν οι δύο μεταβλητές είναι σχετικές·
* Έχετε μια ανεξάρτητη μεταβλητή με πολλές τιμές για μια εξαρτημένη μεταβλητή.

Αυτό το παράδειγμα σχεδιάζει δύο σύνολα τιμών x‑y. Η πρώτη σειρά χρησιμοποιεί ευθείες γραμμές με αστέρια ως δείκτες, ενώ η δεύτερη χρησιμοποιεί ομαλές γραμμές με κύκλους· και οι δύο χρησιμοποιούν [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) 10. Η ιδιότητα [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) ελέγχει το σχήμα του δείκτη.

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

![Το γράφημα scatter](scatter_chart.png)

### **Δημιουργία Κυκλικών Γραφημάτων (Pie)**

Τα κυκλικά γραφήματα χρησιμοποιούνται καλύτερα για να δείξουν τη σχέση μέρος‑προς‑ολό σε δεδομένα, ιδίως όταν τα δεδομένα περιέχουν κατηγορίες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιέχουν πολλά μέρη ή ετικέτες, ίσως θέλετε να εξετάσετε τη χρήση ενός ραβδικού γραφήματος.

Αυτό το παράδειγμα δημιουργεί ένα κυκλικό γράφημα με τρεις τριμηνιαίες τιμές. Κάθε φέτα έχει προσαρμοσμένο γέμισμα και περίγραμμα, και οι ετικέτες εμφανίζουν διαφορετικούς συνδυασμούς τιμών, ποσοστών και πληροφοριών σειράς. Η ιδιότητα [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) θέτει την πρώτη φέτα να ξεκινάει από 180 μοίρες.

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

![Το κυκλικό γράφημα](pie_chart.png)

Για να βελτιώσετε την αναγνωσιμότητα των ετικετών έξω από το κυκλικό γράφημα, δείτε το [Format Leader Lines](/slides/el/net/chart-data-label/#format-leader-lines) για ένα παράδειγμα που τοποθετεί ετικέτες και προσαρμόζει το χρώμα, το πλάτος, τη διαφάνεια και το στυλ παύλας των γραμμών.

### **Δημιουργία Γραμμικών Γραφημάτων**

Τα γραμμικά γραφήματα (επίσης γνωστά ως line graphs) είναι ιδανικά όταν θέλετε να δείξετε αλλαγές τιμής με την πάροδο του χρόνου. Με ένα γραμμικό γράφημα, μπορείτε να συγκρίνετε μεγάλο όγκο δεδομένων μονομιάς, να παρακολουθείτε αλλαγές και τάσεις με το χρόνο, να επισημαίνετε ανωμαλίες σε σειρές δεδομένων, κ.ά.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να δημιουργήσει ένα γραμμικό γράφημα με τις προεπιλεγμένες σειρές και κατηγορίες, κατόπιν αποθηκεύει την παρουσίαση ως PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

Από προεπιλογή, τα σημεία σε ένα γραμμικό γράφημα συνδέονται με συνεχείς ευθείες γραμμές. Εάν θέλετε τα σημεία να συνδέονται με διακεκομμένες γραμμές, ορίστε την ιδιότητα [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) σε μία τιμή από το [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/):

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

![Το γραμμικό γράφημα](line_chart.png)

### **Δημιουργία Γραφημάτων Δέντρου (Tree Map)**

Τα γραφήματα δέντρου είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών δεδομένων και να εστιάσετε γρήγορα σε στοιχεία που συνεισφέρουν σημαντικά μέσα σε κάθε κατηγορία.

Αυτό το παράδειγμα δημιουργεί ένα δένδρο με οκτώ φύλλα ομαδοποιημένα σε τέσσερα κλαδιά και δύο κλαδούς. Η μέθοδος [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) αντιστοιχίζει τα κλαδιά στο επίπεδο ομαδοποίησης 1 και τα κλαδιά στο επίπεδο 2. Οι τιμές καθορίζουν τα σχετικά μεγέθη των ορθογωνίων, ενώ οι ετικέτες κατηγοριών και οι επικάλυψεις γονικών ετικετών προσδιορίζουν την ιεραρχία.

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

![Το γράφημα δέντρου](treemap_chart.png)

### **Δημιουργία Γραφημάτων Καταρράκτου (Waterfall)**

Ένα γράφημα καταρράκτου δείχνει πώς οι θετικές και αρνητικές αλλαγές συμβάλλουν σε μια τελική τιμή. Για παράδειγμα, η ανάλυση κέρδους μπορεί να ξεκινά με τα έσοδα, να αφαιρέσει τα κόστη και να προσθέσει άλλα έσοδα. Οι στήλες αλλαγής «ποτσώνουν» μεταξύ των προηγούμενων και των νέων τιμών, ενώ οι συνολικές στήλες επεκτείνονται από το μηδέν στην αθροιστική τιμή.

Το παρακάτω παράδειγμα χρησιμοποιεί ποσά σε χιλιάδες δολάρια ΗΠΑ:

| Κατηγορία | Τιμή βιβλίου εργασίας | Τύπος στήλης |
| --- | ---: | --- |
| Έσοδα | 1000 | Αύξηση |
| Κόστος πωλήσεων | -400 | Μείωση |
| Μικτό κέρδος | 600 | Ενδιάμεσο σύνολο |
| Λειτουργικά έξοδα | -200 | Μείωση |
| Άλλα έσοδα | 50 | Αύξηση |
| Καθαρό κέρδος | 450 | Τελικό σύνολο |

Για να χαρακτηρίσετε ένα σημείο ως ενδιάμεσο ή τελικό σύνολο, ορίστε την ιδιότητα [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) σε `true`. Παρέχετε το πραγματικό αθροιστικό ποσό στο κελί βιβλίου εργασίας του σημείου: `600` για το μικτό κέρδος (`1000 - 400`) και `450` για το καθαρό κέρδος (`600 - 200 + 50`). Η ιδιότητα χαρακτηρίζει τη στήλη ως σύνολο· δεν υπολογίζει ή γεμίζει την τιμή του κελιού. Μην χρησιμοποιείτε το μηδέν ως σύμβολο κράτησης ή να παρέχετε άλλη αλλαγή για σημείο σύνολου. Μια στήλη σύνολου εμφανίζει την αθροιστική τιμή χωρίς να την προσθέτει ξανά στην τρέχουσα τιμή.

Αυτό το πλήρες παράδειγμα C# δημιουργεί ένα γράφημα χρησιμοποιώντας το μέλος `Waterfall` του [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/), καθαρίζει τα προεπιλεγμένα δεδομένα και γεμίζει το ενσωματωμένο βιβλίο εργασίας. Ο δείκτης φύλλου `0` επιλέγει το πρώτο φύλλο; η στήλη Α περιέχει ονόματα κατηγοριών και η στήλη Β τιμές. Κάθε κελί τιμής προστίθεται με τη μέθοδο [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/). Οι δείκτες σημείων μηδενικής βάσης `2` και `5` προσδιορίζουν τα ενδιάμεσα και τα τελικά σύνολα. Η ενεργοποίηση του [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) εμφανίζει τα ποσά στις στήλες. Δεν απαιτείται εισερχόμενη παρουσίαση ή βιβλίο εργασίας.

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

// Το τρίτο και το έκτο σημείο αντιπροσωπεύουν σύνολα, όχι πρόσθετες αλλαγές.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

Ορίστε την ιδιότητα επιπέδου σειράς [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) σε `true` για να εμφανίζονται γραμμές που συνδέουν διαδοχικές στήλες και να διευκολύνεται η παρακολούθηση της τρέχουσας τιμής. Για να κρύψετε αυτές τις γραμμές, αντικαταστήστε την ανάθεση στο παράδειγμα με `series.ShowConnectorLines = false;` πριν αποθηκεύσετε. Αυτό αλλάζει μόνο την ορατότητα των γραμμών, όχι τα δεδομένα ή τα σύνολα.

Η αποθηκευμένη παρουσίαση εμφανίζει το μικτό κέρδος των 600 και το καθαρό κέρδος των 450, με τα δύο σύνολα να αρχίζουν από το μηδέν:

![Γράφημα καταρράκτου που δείχνει έσοδα, κόστη, μικτό κέρδος 600 και καθαρό κέρδος 450, με ετικέτες τιμών και γραμμές σύνδεσης](waterfall_chart.png)

### **Δημιουργία Γραφημάτων Μετοχών (Stock)**

Τα γραφήματα μετοχών χρησιμοποιούνται για την εμφάνιση χρηματοοικονομικών δεδομένων όπως τιμές ανοίγματος, υψηλής, χαμηλής και κλεισίματος, βοηθώντας στην ανάλυση τάσεων και μεταβλητότητας της αγοράς. Παρέχουν κρίσιμες πληροφορίες για την απόδοση των μετοχών, βοηθώντας επενδυτές και αναλυτές να λαμβάνουν τεκμηριωμένες αποφάσεις.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα ανοίγματος‑υψηλής‑χαμηλής‑κλεισίματος με τέσσερις σειρές με αυτή τη σειρά και τ three κατηγορίες. Η ιδιότητα [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) ενεργοποιεί τις ράβδους ανοδικής/καθοδικής κίνησης, και η [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) ελέγχει τις γραμμές υψηλής‑χαμηλής που δείχνουν το εύρος τιμών, ενώ οι μεμονωμένες γραμμές σειρών και οι μικρές οριζόντιες γραμμές πλέγματος κρύβονται.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

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

chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το γράφημα μετοχών](stock_chart.png)

### **Δημιουργία Γραφημάτων Box και Whisker**

Τα γραφήματα Box και Whisker χρησιμοποιούνται για την απεικόνιση της κατανομής δεδομένων συνοψίζοντας βασικά στατιστικά μέτρα, όπως η διάμεσος, τα τεταρτημόρια και οι πιθανές εξαιρέσεις. Είναι ιδιαίτερα χρήσιμα στην εξερευνητική ανάλυση δεδομένων και στις στατιστικές μελέτες για την γρήγορη κατανόηση της μεταβλητότητας των δεδομένων και την αναγνώριση τυχόν ανωμαλιών.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα box και whisker από έξι τιμές. Η ιδιότητα [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) επιλέγει την αποκλειστική μέθοδο υπολογισμού τεταρτημορίων. Το παράδειγμα ενεργοποιεί επίσης τις γραμμές μέσου όρου, τους δείκτες μέσου, τα εσωτερικά σημεία και τα σημεία εξαιρέσεων.

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

### **Δημιουργία Γραφημάτων Funnel**

Τα γραφήματα Funnel χρησιμοποιούνται για την οπτικοποίηση διαδικασιών που περιλαμβάνουν διαδοχικά στάδια, όπου ο όγκος των δεδομένων μειώνεται καθώς προχωρά από το ένα βήμα στο επόμενο. Είναι ιδιαίτερα χρήσιμοι για την ανάλυση ποσοστών μετατροπής, την ταυτοποίηση “στεφάνων” (bottlenecks) και την παρακολούθηση της αποδοτικότητας διαδικασιών πωλήσεων ή μάρκετινγκ.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να προσθέσει ένα γράφημα funnel στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Αντικαθιστά τα προεπιλεγμένα δεδομένα με έξι κατηγορίες και τιμές από 50 έως 500, κατόπιν αποθηκεύει την ενημερωμένη παρουσίαση. Η εισερχόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

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

![Το γράφημα funnel](funnel_chart.png)

### **Δημιουργία Γραφημάτων Sunburst**

Τα γραφήματα Sunburst χρησιμοποιούνται για την οπτικοποίηση ιεραρχικών δεδομένων, παρουσιάζοντας επίπεδα ως συγκεντρικούς δακτύλιους. Βοηθούν στην απεικόνιση σχέσεων μέρος‑προς‑ολό και είναι ιδανικά για την αναπαράσταση ένθετων κατηγοριών και υποκατηγοριών με σαφή, συμπαγή μορφή.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα sunburst με οκτώ φύλλα ομαδοποιημένα σε τέσσερα κλαδιά και δύο κλαδούς. Η μέθοδος [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) αντιστοιχίζει τα κλαδιά στο επίπεδο ομαδοποίησης 1 και τα κλαδούς στο επίπεδο 2. Οι ετικέτες κατηγοριών προσδιορίζουν τα τμήματα, και οι τιμές καθορίζουν τα σχετικά μεγέθη τους.

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

![Το γράφημα sunburst](sunburst_chart.png)

### **Δημιουργία Ιστογραμμάτων (Histogram)**

Τα ιστογράμματα δείχνουν πώς οι αριθμητικές τιμές κατανέμονται σε διαστήματα (bins). Για μηνιαίες αναφορές χρόνου επεξεργασίας παραγγελιών, χρησιμοποιήστε το ίδιο πλάτος bin και τα ίδια όρια για να διατηρήσετε τα διαστήματα συνεπή και να κάνετε τις κατανομές πιο συγκρίσιμες.

Ορίστε τον οριζόντιο άξονα [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) σε μια λειτουργία από το [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/). Το [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) εφαρμόζεται μόνο όταν είναι `ByBinWidth`; το [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) εφαρμόζεται μόνο όταν είναι `ByNumberOfBins`. Χρησιμοποιήστε `Automatic` για να αφήσετε το γράφημα να επιλέξει τα bins.

#### **Χρήση Σταθερού Πλάτους Bin**

Αυτό το παράδειγμα ομαδοποιεί χρόνους επεξεργασίας σε διαστήματα 10 λεπτών, με ξεχωριστά bins για χρόνους ≤10 λεπτών και >40 λεπτών. Ενεργοποιήστε αυτά τα bins με τις ιδιότητες [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) και [IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/). Όταν παρέχετε ρητά τα όρια [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/) και [OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/), ορίστε τις ιδιότητες [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) και [IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) σε `false`.

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

Η παρουσίαση που εμφανίζεται στο PowerPoint δείχνει αριθμούς bins **3, 4, 4, 4, και 2**. Το bin υποροής περιλαμβάνει `5, 10, 10`, οπότε το όριο είναι συμπεριληπτικό. Το bin υπερροής περιλαμβάνει μόνο `41, 50`, οπότε το όριο είναι αποκλειστικό· και οι τιμές ίσες με `40` παραμένουν στο προηγούμενο διάστημα. Τα εσωτερικά bins περιέχουν τιμές μεγαλύτερες από το κατώτερο όριό τους και μικρότερες ή ίσες με το ανώτερο όριό τους.

![Ιστογράφημα με bins των 10 λεπτών και ρητά όρια υποροής και υπερροής](histogram_bin_width.png)

#### **Καθορισμός Αριθμού Bins**

Για ένα σταθερό επίπεδο λεπτομέρειας αντί για σταθερά διαστήματα, ζητήστε πέντε bins για τα ίδια δεδομένα. Αυτό το παράδειγμα αφήνει τα bins υποροής και υπερροής ανενεργά. Το γράφημα καθορίζει το πλάτος από την εμβέλεια των δεδομένων, έτσι τα όρια μπορούν να αλλάξουν μεταξύ των εκθέσεων.

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

Τα πέντε bins έχουν αριθμούς **4, 4, 4, 4, και 1**. Συγκρίνετε αυτήν την κατανομή με το αποτέλεσμα σταθερού πλάτους παραπάνω: οι εισερχόμενες τιμές είναι ταυτόσημες, αλλά τα όρια διαφέρουν.

![Ιστογράφημα με πέντε bins υπολογισμένα από τα ίδια δεδομένα](histogram_bin_count.png)

### **Δημιουργία Γραφημάτων Radar**

Τα γραφήματα radar χρησιμοποιούνται για την προβολή πολυμεταβλητών δεδομένων σε δισδιάστατη μορφή, επιτρέποντας εύκολη σύγκριση πολλών μεταβλητών ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα για την αναγνώριση προτύπων, δυνάμεων και αδυναμιών σε πολλαπλές μετρικές απόδοσης ή χαρακτηριστικά.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να δημιουργήσει ένα γράφημα radar με τις προεπιλεγμένες σειρές και κατηγορίες, κατόπιν αποθηκεύει την παρουσίαση ως PPTX.

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

![Το γράφημα radar](radar_chart.png)

### **Δημιουργία Πολλαπλών Κατηγορικών Γραφημάτων**

Τα πολλαπλά κατηγορικά γραφήματα χρησιμοποιούνται για την απεικόνιση δεδομένων που περιλαμβάνουν περισσότερους από έναν ομαδοποιητικούς άξονες, επιτρέποντας να συγκρίνετε τιμές σε πολλές διαστάσεις ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα όταν χρειάζεται να αναλύσετε τάσεις και σχέσεις μέσα σε σύνθετα, πολυστρωματικά σύνολα δεδομένων.

Αυτό το παράδειγμα δημιουργεί ένα συγκεντρωτικό γράφημα στήλης με οκτώ κατηγορίες διατεταγμένες σε τέσσερα ζεύγη. Η μέθοδος [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) δίνει σε κάθε ζεύγος μια κοινή ετικέτα στο επίπεδο ομαδοποίησης 1, δημιουργώντας έναν άξονα κατηγοριών με τόσο μεμονωμένες όσο και ομαδικές ετικέτες.

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

![Το πολλαπλό κατηγορικό γράφημα](multi_category_chart.png)

### **Δημιουργία Χάρτη (Map) Γραφημάτων**

Τα χάρτη γραφήματα χρησιμοποιούνται για την οπτικοποίηση γεωγραφικών δεδομένων αντιστοιχίζοντας πληροφορίες σε συγκεκριμένες τοποθεσίες όπως χώρες, πολιτείες ή πόλεις. Είναι ιδιαίτερα χρήσιμα για την ανάλυση περιφερειακών τάσεων, δημογραφικών δεδομένων και χωρικών κατανομών με σαφή, οπτικά ελκυστικό τρόπο.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να δημιουργήσει ένα γράφημα χάρτη με τα προεπιλεγμένα γεωγραφικά δεδομένα και το αποθηκεύει για προβολή στο PowerPoint.

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

![Το γράφημα χάρτη](map_chart.png)

{{% alert color="info" title="Note" %}}
Η παραπάνω εικόνα δείχνει την αποθηκευμένη παρουσίαση ανοιγμένη στο PowerPoint. Το Aspose.Slides γράφει το γράφημα χάρτη και τα δεδομένα του σωστά, αλλά δεν σχεδιάζει το ίδιο το γράφημα χάρτη: όταν μια διαφάνεια που το περιέχει αποδίδεται σε εικόνα ή μετατρέπεται σε PDF ή SVG, η περιοχή του γραφήματος παραμένει κενή. Άλλα σχήματα στην ίδια διαφάνεια παραμένουν αμετάβλητα.
{{% /alert %}}

### **Δημιουργία Συνδυαστικών Γραφημάτων**

Ένα συνδυαστικό γράφημα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους γραφημάτων σε ένα μόνο γράφημα. Αυτό το γράφημα σάς επιτρέπει να επισημάνετε, συγκρίνετε ή εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας στην ταυτοποίηση σχέσεων μεταξύ τους.

![Το συνδυαστικό γράφημα](combination_chart.png)

Αυτό το παράδειγμα συνδυάζει δύο συγκεντρωτικές στήλες με μια γραμμή σε τέσσερις κατηγορίες. Οι στήλες χρησιμοποιούν τον κύριο κάθετο άξονα, ενώ η μέθοδος [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) τοποθετεί τη γραμμή σε έναν δευτερεύοντα κάθετο άξονα στα δεξιά. Οι βοηθητικές συναρτήσεις διαμορφώνουν τον τίτλο, το υπομνηματικό, τις ετικέτες άξονα και τις γραμμές πλέγματος.

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

## **Ενημέρωση Γραφημάτων**

Το Aspose.Slides για .NET σας επιτρέπει να ενημερώνετε γραφήματα PowerPoint τροποποιώντας τα δεδομένα, τη μορφοποίηση και το στυλ. Αυτή η λειτουργικότητα απλοποιεί τη διαδικασία διατήρησης των παρουσιάσεων ενημερωμένων με δυναμικό περιεχόμενο και εξασφαλίζει ότι τα γραφήματα αντανακλούν ακριβώς τα τρέχοντα δεδομένα και τα οπτικά πρότυπα.

Αυτό το παράδειγμα ενημερώνει το γράφημα με όνομα "My chart" στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Απαιτεί δύο σειρές στήλης με τρία σημεία δεδομένων η καθεμία, με ετικέτες κατηγοριών στη στήλη Α και ονόματα σειρών στην πρώτη σειρά του πρώτου φύλλου εργασίας. Το παράδειγμα χρησιμοποιεί τη μέθοδο [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) για να αλλάξει τα κελία του βιβλίου εργασίας, ενημερώνει τις τιμές των σειρών, προσθέτει μια τρίτη σειρά και αλλάζει το γράφημα σε συγκεντρωτικούς κυλίνδρους μέσω της ιδιότητας [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/).

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

## **Ορισμός Εύρους Δεδομένων για Γράφημα**

Για να ελέγξετε το εύρος που χρησιμοποιείται ήδη από ένα υπάρχον γράφημα, δείτε το [Retrieve a Chart's Data Range](/slides/el/net/chart-workbook/#retrieve-a-charts-data-range).

Το Aspose.Slides για .NET προσφέρει την ευελιξία να ορίσετε ένα συγκεκριμένο εύρος δεδομένων από ένα φύλλο εργασίας ως πηγή για τα δεδομένα του γραφήματος. Αυτό σημαίνει ότι μπορείτε άμεσα να αντιστοιχίσετε ένα τμήμα του φύλλου εργασίας στο γράφημα, ελέγχοντας ποιες κυψέλες συμβάλλουν στις σειρές και τις κατηγορίες του γραφήματος. Συνεπώς, μπορείτε εύκολα να ενημερώνετε και να συγχρονίζετε τα γραφήματά σας με τις πιο πρόσφατες αλλαγές στα δεδομένα του φύλλου, διασφαλίζοντας ότι οι παρουσιάσεις PowerPoint αντανακλούν ακριβείς και επίκαιρες πληροφορίες.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) για να ορίσει την πηγή δεδομένων του γραφήματος με όνομα "My chart" στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης σε `Sheet1!A1:B4`. Το βιβλίο εργασίας του γραφήματος πρέπει να περιέχει αυτό το φύλλο και ένα πληθωρισμένο εύρος με κεφαλίδα σειράς στην πρώτη σειρά, ετικέτες κατηγοριών στη στήλη Α και τρεις τιμές στη στήλη Β.

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

## **Χρήση Προεπιλεγμένων Δεικτών σε Γραφήματα**

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες σε γραφήματα, κάθε σειρά γραφήματος λαμβάνει αυτόματα διαφορετικό προεπιλεγμένο σχήμα δείκτη.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) για να δημιουργήσει ένα γράφημα με δύο σειρές γραμμής και ένα υπομνηματικό. Οι ρυθμίσεις [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) διατηρούν τα αυτόματα εκχωρηθέντα σχήματα δεικτών. Η πρώτη σειρά περιλαμβάνει μια αρνητική τιμή και μια ελλιπή τιμή, που αναπαρίστανται από `null`, ενώ η δεύτερη έχει τιμή για κάθε κατηγορία.

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

## **ΣΥΝΗΘΗΜΑΤΙΚΕΣ ΕΡΩΤΗΣΕΙΣ (FAQ)**

**Ποιοι τύποι γραφημάτων υποστηρίζονται από το Aspose.Slides για .NET;**

Το Aspose.Slides για .NET υποστηρίζει ευρύ φάσμα τύπων γραφημάτων, όπως μπαρ, γραμμικά, κυκλικά, επιφανειακά, scatter, ιστογράμματα, radar και πολλά άλλα. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο γραφήματος για τις ανάγκες απεικόνισης των δεδομένων σας.

**Πώς προσθέτω νέο γράφημα σε μια διαφάνεια;**

Για να προσθέσετε γράφημα, πρώτα δημιουργείτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), ανακτάτε την επιθυμητή διαφάνεια με τον δείκτη της και, στη συνέχεια, καλείτε τη μέθοδο για προσθήκη γραφήματος, καθορίζοντας τον τύπο γραφήματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το γράφημα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που προβάλλονται σε ένα γράφημα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός γραφήματος προσπελάζοντας το βιβλίο δεδομένων του ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)), καθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες, και προσθέτοντας τα προσαρμοσμένα σας δεδομένα. Αυτό σας επιτρέπει να ανανεώσετε προγραμματιστικά το γράφημα ώστε να αντανακλά τα πιο πρόσφατα δεδομένα.

**Μπορεί να προσαρμοστεί η εμφάνιση του γραφήματος;**

Ναι, το Aspose.Slides για .NET παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα στοιχεία μορφοποίησης για να προσαρμόσετε την εμφάνιση του γραφήματος στο συγκεκριμένο σχεδιαστικό σας αίτημα.