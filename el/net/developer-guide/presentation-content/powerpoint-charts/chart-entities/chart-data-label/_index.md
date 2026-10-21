---
title: Διαχείριση ετικετών δεδομένων διαγράμματος σε παρουσιάσεις στο .NET
linktitle: Ετικέτα Δεδομένων
type: docs
url: /el/net/chart-data-label/
keywords:
- διάγραμμα
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
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων διαγραμμάτων σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για .NET, ώστε οι διαφάνειες να γίνονται πιο ελκυστικές."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων εμφανίζουν πληροφορίες σχετικά με τις σειρές του διαγράμματος και τα μεμονωμένα σημεία δεδομένων, βοηθώντας τους αναγνώστες να αναγνωρίζουν τις τιμές και να κατανοούν το διάγραμμα. Αυτό το άρθρο εξηγεί πώς να μορφοποιείτε τις τιμές, να εμφανίζετε τα ποσοστά, να διαβάζετε το κείμενο των ετικετών, να ελέγχετε τις ετικέτες πέρα από το μέγιστο του άξονα, να ρυθμίζετε την απόσταση των ετικετών του άξονα κατηγορίας και να τοποθετείτε τις ετικέτες σε διάγραμμα πίτας.

## **Ορισμός ακρίβειας δεδομένων στις ετικέτες δεδομένων του διαγράμματος**

Χρησιμοποιήστε [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) για να μορφοποιήσετε τις τιμές της σειράς. Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα, εμφανίζει τον πίνακα δεδομένων του και ενεργοποιεί τις ετικέτες τιμών για την πρώτη σειρά. Η μορφή `#,##0.00` εμφανίζει διαχωριστικό χιλιάδων και δύο δεκαδικά ψηφία χωρίς να αλλάζει τις υποκείμενες τιμές.

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

Για να μορφοποιήσετε τα αριθμητικά κελιά σε ενσωματωμένο βιβλίο εργασίας ενός διαγράμματος, δείτε [Set Custom Number Formats for Workbook Cells](/slides/el/net/chart-workbook/#set-custom-number-formats-for-workbook-cells). Αυτό το παράδειγμα δείχνει επίσης τις ετικέτες τιμών να ακολουθούν τις μορφές των κελιά τους ενώ διατηρούν τις αποθηκευμένες αριθμητικές τιμές.

## **Εμφάνιση ποσοστού ως ετικέτες**

Για ένα στοίβαγμα στηλών, υπολογίστε κάθε τιμή ως ποσοστό του συνολικού της κατηγορίας και εκχωρήστε το κείμενο στο [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Αυτό το παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα του διαγράμματος και εμφανίζει τα ποσοστά με δύο δεκαδικά ψηφία σε γραμματοσειρά 8 σημείων. Κατηγορίες με συνολικό μηδέν παραλείπονται για να αποφευχθεί διαίρεση με το μηδέν. Υπολογίστε ξανά το προσαρμοσμένο κείμενο ετικέτας εάν αλλάξουν τα δεδομένα του διαγράμματος.

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

## **Ορισμός του συμβόλου ποσοστού με τις ετικέτες δεδομένων του διαγράμματος**

Όταν οι τιμές αποθηκεύονται ως κλάσματα, χρησιμοποιήστε το [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) για να εμφανίσετε ποσοστά. Ορίστε το [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) σε `false` ώστε η μορφοποίηση της ετικέτας να εφαρμοστεί ανεξάρτητα από τα κελιά προέλευσης.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στοίβαξης στηλών 100% με κόκκινη και μπλε σειρά σε τέσσερις κατηγορίες. Κάθε ζεύγος τιμών αθροίζεται σε 1. Η μορφή ετικέτας `0.0%` εμφανίζει το 0.30 ως 30.0%, ενώ ο κατακόρυφος άξονας χρησιμοποιεί δύο δεκαδικά ψηφία. Και οι δύο σειρές χρησιμοποιούν λευκό κείμενο ετικέτας 10 σημείων.

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

## **Ανάγνωση του πραγματικού κειμένου των ετικετών δεδομένων**

Χρησιμοποιήστε το [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) για να ανακτήσετε το κείμενο που δημιουργείται από τις ρυθμίσεις μιας ετικέτας δεδομένων. Αυτό είναι χρήσιμο όταν εξάγετε ετικέτες για αναφορές, αναζητάτε περιεχόμενο παρουσίασης ή επαληθεύετε παραγόμενα διαγράμματα. Στο παρακάτω παράδειγμα, η προεπιλεγμένη [μορφή ετικέτας δεδομένων](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) συνδυάζει το όνομα κάθε κατηγορίας, το όνομα της σειράς και την τιμή. Ένα σημείο μορφοποιεί την τιμή του ως ποσοστό, και ένα άλλο χρησιμοποιεί προσαρμοσμένο κείμενο από το [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Ο αριθμός που αποθηκεύεται σε ένα σημείο δεδομένων παραμένει `0.75`, ακόμα και όταν η ετικέτα του δείχνει `75%` μαζί με τα ονόματα της κατηγορίας και της σειράς. Προσαρμοσμένο κείμενο αντικαθιστά το παραγόμενο κείμενο ετικέτας. Το [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) επιστρέφει το τελικό κείμενο ετικέτας σε κάθε περίπτωση. Ελέγξτε το [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) ξεχωριστά, όπως φαίνεται παραπάνω, όταν θέλετε να εξάγετε μόνο ορατές ετικέτες.

## **Έλεγχος ετικετών δεδομένων πέρα από το μέγιστο του άξονα**

Όταν περιορίζετε το εύρος ενός άξονα χειροκίνητα, ορισμένα σημεία δεδομένων ενδέχεται να υπερβούν το μέγιστο. Χρησιμοποιήστε το [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) για να ελέγξετε εάν οι ετικέτες δεδομένων τους εμφανίζονται. Αυτή η ρύθμιση αλλάζει την ορατότητα των ετικετών· δεν αλλάζει το εύρος του άξονα ή τις υποκείμενες τιμές δεδομένων.

Το παρακάτω παράδειγμα δημιουργεί ένα 2Δ στήλης ομαδοποιημένο διάγραμμα με τιμές 60 και 120. Ορίζει το [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) σε `false` και το [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) σε 100 στον κατακόρυφο άξονα. Η πρώτη διαφάνεια επιτρέπει ετικέτες πέρα από το μέγιστο· ένα αντίγραφο της διαφάνειας τις απενεργοποιεί. Και οι δύο διαφάνειες αποθηκεύονται στο `DataLabelsOverMaximum.pptx`.

Ενεργοποιήστε τις ετικέτες τιμών με το [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Η ρύθμιση σε επίπεδο διαγράμματος δεν ενεργοποιεί την εμφάνιση τιμών από μόνη της ή δεν παρακάμπτει την απενεργοποίηση εμφάνισης τιμής μιας μεμονωμένης ετικέτας. Αυτό το παράδειγμα ενεργοποιεί τις τιμές για ολόκληρη τη σειρά και χρησιμοποιεί το [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) για να τοποθετήσει τις ετικέτες στο εξωτερικό άκρο κάθε στήλης.

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

Οι παρακάτω εικόνες δείχνουν τις αποθηκευμένες διαφάνειες που αποδίδονται από το Microsoft PowerPoint. Με `true`, η ετικέτα **120** είναι ορατή στο άνω όριο· με `false`, κρύβεται. Η ετικέτα **60** παραμένει ορατή, το μέγιστο του άξονα παραμένει **100**, και το δεύτερο σημείο δεδομένων παραμένει **120** και στις δύο περιπτώσεις.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
This example uses a 2D column chart with a value axis. Charts without a value axis, such as pie and doughnut charts, do not have an axis maximum to limit in this way.
{{% /alert %}}

## **Ορισμός απόστασης ετικέτας από άξονα**

Χρησιμοποιήστε το [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) για να ελέγξετε την απόσταση μεταξύ των ετικετών του άξονα κατηγορίας και του άξονα. Η τιμή είναι ποσοστό του μέγιστου μεγέθους γραμματοσειράς των ετικετών του άξονα. Αυτό το παράδειγμα δημιουργεί ένα στήλης ομαδοποιημένο διάγραμμα και ορίζει την απόσταση ετικετών του οριζόντιου άξονα στα 500. Αυτή η ρύθμιση επηρεάζει τις ετικέτες του άξονα κατηγορίας αντί για τις ετικέτες που είναι προσαρτημένες σε μεμονωμένα σημεία δεδομένων.

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

## **Ρύθμιση θέσης ετικέτας**

Σε ένα κυκλικό διάγραμμα, προσαρμόστε τις θέσεις των ετικετών δεδομένων για να βελτιώσετε την απόσταση και να δημιουργήσετε χώρο για τις γραμμές καθοδήγησης.

Αυτό το παράδειγμα εμφανίζει την τιμή του πρώτου σημείου δεδομένων, τοποθετεί την ετικέτα του εκτός του τμήματος και προσαρμόζει τις μετατοπίσεις του [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) και [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Αυτές οι μετατοπίσεις είναι σχετικές με το πλάτος και το ύψος του διαγράμματος, αντίστοιχα.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Μορφοποίηση γραμμών καθοδήγησης**

Όταν οι ετικέτες ενός κυκλικού διαγράμματος βρίσκονται εκτός των τμημάτων τους, οι γραμμές καθοδήγησης βοηθούν τους αναγνώστες να αντιστοιχίσουν κάθε τιμή στο σωστό τμήμα. Ένα αντίθετο χρώμα και μια ελαφρώς πιο παχιά γραμμή μπορούν να κάνουν αυτές τις συνδέσεις πιο εύκολες στην παρακολούθηση, ενώ η διαφάνεια και το διακεκομμένο στυλ διατηρούν τις γραμμές οπτικά αδιάφορες.

Χρησιμοποιήστε το [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) για να μορφοποιήσετε τις γραμμές καθοδήγησης σε επίπεδο συλλογής ετικετών δεδομένων της σειράς. Οι ρυθμίσεις στο `series.Labels.LeaderLinesFormat.Line` εφαρμόζονται στη συλλογή, όχι σε μεμονωμένη ετικέτα.

Αυτό το παράδειγμα δημιουργεί ένα κυκλικό διάγραμμα με προεπιλεγμένα δεδομένα, εμφανίζει τις τιμές εκτός των τμημάτων και ενεργοποιεί το [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). Μετακινεί δύο ετικέτες πιο μακριά από τα τμήματά τους χρησιμοποιώντας τις μετατοπίσεις [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) και [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/), εκφρασμένες ως κλάσματα του πλάτους και του ύψους του διαγράμματος. Δεν απαιτείται παρουσίαση εισόδου.

Το [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) της γραμμής ορίζει ένα συμπαγές μπλε χρώμα με τιμή άλφα 191 από 255, παρέχοντας περίπου 25 % διαφάνεια. Το [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) ορίζει το πάχος στα 2 σημεία και το [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) κάνει τη γραμμή διακεκομμένη.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// Μετακινήστε δύο ετικέτες πιο μακριά από τα τμήματά τους.
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

Η ενεργοποίηση των γραμμών καθοδήγησης δεν εγγυάται ότι θα εμφανιστεί γραμμή για κάθε ετικέτα. Η ορατότητα εξαρτάται από τη θέση της ετικέτας και τη συμπεριφορά διάταξης του διαγράμματος. Σε αυτό το παράδειγμα, οι δύο μετατοπισμένες ετικέτες έχουν ορατές γραμμές καθοδήγησης· οι ετικέτες που παραμένουν κοντά στα τμήματά τους δεν τις χρειάζονται.

Η παρακάτω εικόνα δείχνει το αποθηκευμένο `FormattedLeaderLines.pptx` που αποδίδεται με το Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Προσθήκη πολλαπλών σειρών ετικετών δεδομένων πάνω από διάγραμμα στήλης**

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στήλης με δύο σειρές ετικετών δεδομένων πάνω από την περιοχή σχεδίασης. Η Σειρά A εμφανίζει τις ορατές στήλες, ενώ οι Σειρές B και C παρέχουν τις πρόσθετες ετικέτες. Οι στήλες τους κρύβονται αφαιρώντας το γέμισμα και το περίγραμμα. Η ιδιότητα [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) ευθυγραμμίζει και τις τρεις σειρές στο ίδιο κέντρο κατηγορίας.

Οι ρυθμίσεις του [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) διατηρούν χώρο για τις σειρές ετικετών. Μετά το [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) που υπολογίζει τις προεπιλεγμένες θέσεις, τα [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) και [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) διατηρούν την οριζόντια ευθυγράμμιση και εφαρμόζουν κατακόρυφες μετατοπίσεις για να οργανώσουν τις ετικέτες σε δύο σειρές. Οι αριθμοί παραμένουν ετικέτες δεδομένων συνδεδεμένες με τις τιμές των σειρών· μόνο οι επικεφαλίδες των σειρών είναι ξεχωριστά σχήματα κειμένου.

```csharp
using System.Drawing;
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
        // Κρύψτε τις στήλες των B και C, αλλά διατηρήστε τις ετικέτες δεδομένων τους.
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

// Ευθυγραμμίστε και τις τρεις σειρές με τα ίδια κέντρα κατηγοριών.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Χρησιμοποιήστε λιγότερες γραμμές πλέγματος για αυτό το συμπαγές παράδειγμα.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Κρατήστε χώρο πάνω από την περιοχή σχεδίασης για δύο σειρές ετικετών δεδομένων.
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
        // Διατηρήστε την προεπιλεγμένη οριζόντια θέση. Το Y είναι μετατόπιση από
        // την προεπιλεγμένη θέση ετικέτας, εκφρασμένη ως κλάσμα του ύψους του διαγράμματος.
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

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να αποτρέψω την επικάλυψη των ετικετών δεδομένων σε πυκνά διαγράμματα;**

Συνδυάστε την αυτόματη τοποθέτηση ετικετών, τις γραμμές καθοδήγησης και τη μείωση του μεγέθους γραμματοσειράς· εάν χρειαστεί, κρύψτε ορισμένα πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραίες τιμές ή βασικά σημεία.

**Πώς μπορώ να απενεργοποιήσω τις ετικέτες μόνο για μηδενικές, αρνητικές ή κενές τιμές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλείπουσες τιμές σύμφωνα με έναν καθορισμένο κανόνα.

**Πώς μπορώ να διασφαλίσω ένα συνεπές στυλ ετικετών κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά την οικογένεια γραμματοσειράς και το μέγεθος και βεβαιωθείτε ότι η γραμματοσειρά είναι διαθέσιμη στο περιβάλλον απόδοσης για να αποφύγετε την εναλλακτική.