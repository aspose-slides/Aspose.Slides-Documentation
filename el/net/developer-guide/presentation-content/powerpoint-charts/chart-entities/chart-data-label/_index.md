---
title: Διαχείριση ετικετών δεδομένων γραφήματος σε παρουσιάσεις σε .NET
linktitle: Ετικέτα Δεδομένων
type: docs
url: /el/net/chart-data-label/
keywords:
- γράφημα
- ετικέτα δεδομένων
- ακρίβεια δεδομένων
- ποσοστό
- απόσταση ετικέτας
- θέση ετικέτας
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων γραφήματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για .NET για πιο ελκυστικές διαφάνειες."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων εμφανίζουν πληροφορίες σχετικά με τις σειρές γραφημάτων και μεμονωμένα σημεία δεδομένων, βοηθώντας τους αναγνώστες να αναγνωρίζουν τις τιμές και να κατανοούν το γράφημα. Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε τις τιμές, να εμφανίσετε ποσοστά, να διαβάσετε το κείμενο της ετικέτας, να ελέγξετε τις ετικέτες πέρα από το μέγιστο του άξονα, να προσαρμόσετε την απόσταση ετικετών του άξονα κατηγορίας και να τοποθετήσετε ετικέτες σε διαγράμματα πίτας.

## **Ορισμός Ακρίβειας Δεδομένων στις Ετικέτες Δεδομένων Γραφήματος**

Χρησιμοποιήστε [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) για να μορφοποιήσετε τις τιμές των σειρών. Αυτό το παράδειγμα δημιουργεί ένα διαγράγραμμα γραμμής με προεπιλεγμένα δεδομένα, εμφανίζει τον πίνακα δεδομένων του και ενεργοποιεί τις ετικέτες τιμών για την πρώτη σειρά. Η μορφή `#,##0.00` εμφανίζει διαχωριστικό χιλιάδων και δύο δεκαδικά ψηφία χωρίς να αλλάζει τις υποκείμενες τιμές.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

## **Εμφάνιση Ποσοστών ως Ετικέτες**

Για ένα στοίβαγμα στήλης, υπολογίστε κάθε τιμή ως ποσοστό του συνόλου της κατηγορίας της και εκχωρήστε το κείμενο στο [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Αυτό το παράδειγμα χρησιμοποιεί τα προεπιλογή δεδομένα του γραφήματος και εμφανίζει τα ποσοστά με δύο δεκαδικά ψηφία σε γραμματοσειρά 8 σημείων. Οι κατηγορίες με συνολικό άθροισμα μηδέν παραλείπονται για να αποφεύγεται η διαίρεση με το μηδέν. Επαναϋπολογίστε το προσαρμοσμένο κείμενο ετικέτας εάν τα δεδομένα του γραφήματος αλλάξουν.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Ορισμός Σημείας Ποσοστών με Ετικέτες Δεδομένων Γραφήματος**

Όταν οι τιμές αποθηκεύονται ως κλάσματα, χρησιμοποιήστε [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) για να εμφανίσετε τα ποσοστά. Ορίστε το [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) σε `false` για να εφαρμόσετε τη μορφοποίηση της ετικέτας ανεξάρτητα από τα κελιά προέλευσης. Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στοίβαξης στήλης 100% με κόκκινη και μπλε σειρά σε τέσσερις κατηγορίες. Κάθε ζεύγος τιμών αθίζει το 1. Η μορφή ετικέτας `0.0%` εμφανίζει το 0.30 ως 30.0%, ενώ ο κάθετος άξονας χρησιμοποιεί δύο δεκαδικά ψηφία. Και οι δύο σειρές χρησιμοποιούν λευκό κείμενο ετικέτας μεγέθους 10 σημείων.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Ανάγνωση του Πραγματικού Κειμένου των Ετικετών Δεδομένων**

Χρησιμοποιήστε [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) για να ανακτήσετε το κείμενο που δημιουργείται από τις ρυθμίσεις μιας ετικέτας δεδομένων. Αυτό είναι χρήσιμο όταν εξάγετε ετικέτες για αναφορές, αναζητάτε περιεχόμενο παρουσίασης ή επικυρώνετε δημιουργημένα γραφήματα. Στο παρακάτω παράδειγμα, η προεπιλεγμένη [μορφή ετικέτας δεδομένων](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) συνδυάζει το όνομα κάθε κατηγορίας, το όνομα σειράς και την τιμή. Ένα σημείο μορφοποιεί την τιμή του ως ποσοστό, και άλλο χρησιμοποιεί προσαρμοσμένο κείμενο από το [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

Ο αριθμός που αποθηκεύεται σε ένα σημείο δεδομένων παραμένει `0.75`, ακόμη και όταν η ετικέτα του εμφανίζει `75%` μαζί με τα ονόματα κατηγορίας και σειράς. Το προσαρμοσμένο κείμενο αντικαθιστά το παραγόμενο κείμενο ετικέτας. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) επιστρέφει τη δημιουργημένη συμβολοσειρά ετικέτας σε κάθε περίπτωση. Ελέγξτε το [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) ξεχωριστά, όπως φαίνεται παραπάνω, όταν θέλετε να εξαγάγετε μόνο τις ορατές ετικέτες.

## **Έλεγχος Ετικετών Δεδομένων Πέρα από το Μέγιστο του Άξονα**

Όταν περιορίζετε το εύρος ενός άξονα χειροκίνητα, ορισμένα σημεία δεδομένων μπορεί να υπερβούν το μέγιστό του. Χρησιμοποιήστε [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) για να ελέγξετε αν εμφανίζονται οι ετικέτες τους. Αυτή η ρύθμιση αλλάζει την ορατότητα των ετικετών· δεν αλλάζει το εύρος του άξονα ή τις υποκείμενες τιμές των δεδομένων. Το παρακάτω παράδειγμα δημιουργεί ένα 2D συσσωματωμένο διάγραμμα στήλης με τιμές 60 και 120. Ορίζει το [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) σε `false` και το [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) σε 100 στον κατακόρυφο άξονα. Η πρώτη διαφάνεια επιτρέπει ετικέτες πέρα από το μέγιστο· ένα αντίγραφο αυτής της διαφάνειας τις απενεργοποιεί. Και οι δύο διαφάνειες αποθηκεύονται στο `DataLabelsOverMaximum.pptx`. Ενεργοποιήστε τις ετικέτες τιμών με το [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Η ρύθμιση σε επίπεδο γραφήματος δεν ενεργοποιεί την εμφάνιση τιμών από μόνη της ούτε παρακάμπτει την απενεργοποιημένη εμφάνιση τιμής μιας μεμονωμένης ετικέτας. Αυτό το παράδειγμα ενεργοποιεί τις τιμές για ολόκληρη τη σειρά και χρησιμοποιεί το [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) για να τοποθετήσει τις ετικέτες στο εξωτερικό άκρο κάθε στήλης.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

Οι παρακάτω εικόνες δείχνουν τις αποθηκευμένες διαφάνειες που αποδίδονται από το Microsoft PowerPoint. Με `true`, η ετικέτα **120** είναι ορατή στο άνω όριο· με `false`, είναι κρυφή. Η ετικέτα **60** παραμένει ορατή, το μέγιστο του άξονα παραμένει στο **100**, και το δεύτερο σημείο δεδομένων παραμένει **120** και στις δύο περιπτώσεις.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![Διάγραμμα PowerPoint που εμφανίζει την ετικέτα τιμής 120 με μέγιστο άξονα 100](data-labels-over-maximum-true.png) | ![Διάγραμμα PowerPoint που κρύβει την ετικέτα τιμής 120 με μέγιστο άξονα 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Αυτό το παράδειγμα χρησιμοποιεί ένα 2D διάγραμμα στήλης με άξονα τιμών. Διαγράμματα χωρίς άξονα τιμών, όπως τα διαγράμματα πίτας και δακτυλίου, δεν έχουν μέγιστο άξονα που να μπορεί να περιοριστεί με αυτόν τον τρόπο.
{{% /alert %}}

## **Ορισμός Απόστασης Ετικέτας από Άξονα**

Χρησιμοποιήστε το [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) για να ελέγξετε την απόσταση μεταξύ των ετικετών του άξονα κατηγορίας και του άξονα. Η τιμή είναι ποσοστό του μέγιστου μεγέθους γραμματοσειράς των ετικετών του άξονα. Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στήλης με σύμπτυξη και ορίζει την απόσταση ετικέτας του οριζόντιου άξονα σε 500. Αυτή η ρύθμιση επηρεάζει τις ετικέτες του άξονα κατηγορίας παρά τις ετικέτες που συνδέονται με μεμονωμένα σημεία δεδομένων.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Προσαρμογή Θέσης Ετικέτας**

Σε ένα διάγραμμα πίτας, προσαρμόστε τις θέσεις των ετικετών δεδομένων για να βελτιώσετε την απόσταση και να δημιουργήσετε χώρο για τις γραμμές οδηγού. Αυτό το παράδειγμα εμφανίζει την τιμή του πρώτου σημείου δεδομένων, τοποθετεί την ετικέτα του έξω από την φέτα και προσαρμόζει τις μετατοπίσεις [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) και [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Αυτές οι μετατοπίσεις είναι σχετικές με το πλάτος και το ύψος του γραφήματος, αντίστοιχα.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![Διάγραμμα πίτας με προσαρμοσμένη θέση ετικέτας δεδομένων](pie-chart-adjusted-label.png)

## **Προσθήκη Πολλαπλών Γραμμών Ετικετών Δεδομένων Πάνω σε Διάγραμμα Στήλης**

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στήλης με δύο γραμμές ετικετών δεδομένων πάνω από την περιοχή σχεδίασης. Η Σειρά A εμφανίζει τις ορατές στήλες, ενώ οι Σειρές B και C παρέχουν τις πρόσθετες ετικέτες. Οι στήλες τους κρύβονται με την αφαίρεση του γεμίσματος και του περιγράμματος. Η ιδιότητα [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) ευθυγραμμίζει και τις τρεις σειρές στο ίδιο κέντρο κατηγορίας. Οι ρυθμίσεις του [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) διατηρούν χώρο για τις γραμμές ετικετών. Μετά ο υπολογισμός των προεπιλεγμένων θέσεων από το [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/), τα [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) και [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) διατηρούν την οριζόντια στοίχιση και εφαρμόζουν κατακόρυφες μετατοπίσεις για να οργανώσουν τις ετικέτες σε δύο γραμμές. Οι αριθμοί παραμένουν ετικέτες δεδομένων συνδεδεμένες με τις τιμές των σειρών· μόνο οι επικεφαλίδες των γραμμών είναι ξεχωριστά σχήματα κειμένου.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // Απόκρυψη των στηλών B και C, αλλά διατήρηση των ετικετών δεδομένων τους.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// Ευθυγράμμιση και των τριών σειρών με τα ίδια κέντρα κατηγοριών.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Χρήση λιγότερων γραμμών δικτύου για αυτό το συμπαγές παράδειγμα.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Δέσμευση χώρου πάνω από το γράφημα για δύο σειρές ετικετών δεδομένων.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // Διατήρηση της προεπιλεγμένης οριζόντιας θέσης. Το Y είναι μια μετατόπιση από
        // τη προεπιλεγμένη θέση ετικέτας, εκφρασμένη ως κλάσμα του ύψους του γραφήματος.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Μόνο η επικεφαλίδα της σειράς είναι ξεχωριστό σχήμα κειμένου.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![Διάγραμμα στήλης με δύο γραμμές ετικετών δεδομένων πάνω από την περιοχή σχεδίασης](multiple-rows-of-labels.png)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αποτρέψω την επικάλυψη των ετικετών δεδομένων σε πυκνά διαγράμματα;**  
Συνδυάστε την αυτόματη τοποθέτηση ετικετών, τις γραμμές οδηγού και τη μείωση του μεγέθους γραμματοσειράς· εάν χρειάζεται, κρύψτε ορισμένα πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραίες τιμές ή σημαντικά σημεία.

**Πώς μπορώ να απενεργοποιήσω τις ετικέτες μόνο για μηδενικές, αρνητικές ή κενές τιμές;**  
Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν καθορισμένο κανόνα.

**Πώς μπορώ να εξασφαλίσω συνεπές στυλ ετικετών κατά την εξαγωγή σε PDF/εικόνες;**  
Ορίστε ρητά την οικογένεια γραμματοσειράς και το μέγεθος και επαληθεύστε ότι η γραμματοσειρά είναι διαθέσιμη στο περιβάλλον απόδοσης για να αποφύγετε την εναλλαγή.