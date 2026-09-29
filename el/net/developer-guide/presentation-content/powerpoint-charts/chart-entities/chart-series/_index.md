---
title: Διαχείριση σειρών δεδομένων διαγράμματος σε παρουσιάσεις σε .NET
linktitle: Σειρές δεδομένων
type: docs
url: /el/net/chart-series/
keywords:
- σειρές διαγράμματος
- επικάλυψη σειρών
- χρώμα σειράς
- χρώμα κατηγορίας
- όνομα σειράς
- σημείο δεδομένων
- διάστημα σειράς
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σειρές διαγράμματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος κενού και αρνητικές τιμές σε παρουσιάσεις με C#."
---
## **Επισκόπηση**

Ένα διάγραμμα αποθηκεύει τα δεδομένα που σχεδιάζει σε ένα βιβλίο εργασίας δεδομένων διαγράμματος. Ένα [IChartSeries](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [IChartDataPoint](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/) στη σειρά αναφέρεται σε ένα ή περισσότερα κελιά του βιβλίου εργασίας. Τα αντικείμενα [IChartCategory](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται οι σειρές. Τα ονόματα των σειρών, οι κατηγορίες και οι τιμές των σημείων συνδέονται επομένως με αντικείμενα [IChartDataCell](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/) αντί να αποθηκεύονται μόνο ως κείμενο εμφάνισης.

Για ένα τυπικό διάγραμμα κατηγοριών, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για τα ονόματα των σειρών, τη στήλη 0 για τα ονόματα των κατηγοριών και τα υπόλοιπα κελιά για τις τιμές των σειρών. Οι δείκτες φύλλου, γραμμής και στήλης που περνούν στο [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/getcell/) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα διάγραμμα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον διάγραμμα το χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, επιθεωρήστε τα κελιά που αναφέρονται από τις σειρές, τις κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις του διαγράμματος έχουν τρεις διαφορετικές εμβέλειες:

- Ρυθμίσεις σε επίπεδο σειράς, όπως [IChartSeries.Format](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/format/), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία μιας σειράς.
- Ρυθμίσεις σημείου δεδομένων, όπως [IChartDataPoint.Format](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/format/), παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας ισχύουν για συμβατές σειρές που ανήκουν στην ίδια [IChartSeriesGroup](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseriesgroup/). Πρόσβαση στην ομάδα μέσω του [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/parentseriesgroup/) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το εύρος κενών.

Όταν δεν έχει οριστεί ρητό γέμισμα σημείου ή σειράς, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν και μορφοποίηση σειράς και σημείου, η μορφοποίηση σημείου έχει προτεραιότητα για εκείνο το σημείο.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός Επικάλυψης Σειρών Διαγράμματος**

[IChartSeries.Overlap](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/overlap/) αναφέρει πόσο επικάλυπται η μπάρα ή η στήλη σε ένα διάγραμμα 2Δ, από -100 μέχρι 100 τοις εκατό. Είναι μια μόνο για ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειρών. Ορίστε το [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseriesgroup/overlap/) για να ενημερώσετε όλες τις συμβατές σειρές σε αυτήν την ομάδα. Αυτή η επιλογή ισχύει για τύπους διαγράμματος που εμφανίζουν ομαδοποιημένες μπάρες ή στήλες· δεν επηρεάζει μη σχετιζόμενες ομάδες σειρών σε συνδυαστικό διάγραμμα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Το νέο διάγραμμα περιέχει δείγμα σειρών, κατηγοριών και τιμών.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![The series overlap](series_overlap.png)

## **Αλλαγή Χρώματος Γεμίσματος Σειράς**

Χρησιμοποιήστε το [IChartSeries.Format](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/format/) για να ορίσετε το προεπιλεγμένο γέμισμα για ολόκληρη τη σειρά. Εάν ένα σημείο έχει ήδη ρητό γέμισμα, η ρύθμιση του [IChartDataPoint.Format](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/format/) παρακάμπτει το γέμισμα της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει ένα συμπαγές μπλε γέμισμα στην πρώτη σειρά:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![The color of the series](series_color.png)

## **Αλλαγή Ονόματος Σειράς**

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων του διαγράμματος και συνήθως εμφανίζεται στο υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα διάγραμμα στήλης συγκεντρωμένων, το κελί B1 είναι στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι σταθερές ονομασίες στο παρακάτω παράδειγμα κάνουν αυτή τη δομή ρητή:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [IChartSeries.Name](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/name/). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής και στήλης σε υπάρχον διάγραμμα:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![The series name](series_name.png)

## **Λήψη Αυτόματου Χρώματος Γεμίσματος Σειράς**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) επιστρέφει το χρώμα που υπολογίζεται από τον δείκτη σειράς και το στυλ του διαγράμματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν εκχωρεί νέο γέμισμα.

Το παρακάτω παράδειγμα εκτυπώνει το αυτόματο χρώμα κάθε προεπιλεγμένης σειράς:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Παράδειγμα εξόδου για το προεπιλεγμένο στυλ διαγράμματος:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Τα ακριβή χρώματα εξαρτώνται από το στυλ και το θέμα του διαγράμματος.

## **Ορισμός Αναστροφής Χρώματος Γεμίσματος για Σειρά Διαγράμματος**

Για σειρές μπάρας, στήλης και φυσαλίδων, το [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/invertifnegative/) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα σειράς σε συμπαγές, ενεργοποιήστε την αναστροφή και ορίστε το χρώμα αρνητικής τιμής μέσω του [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· μόνο το χρώμα εμφάνισής τους αλλάζει.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με μία σειρά. Η γραμμή 0 του φύλλου περιέχει το όνομα της σειράς, η στήλη 0 περιέχει τα ονόματα κατηγοριών και η στήλη 1 περιέχει τις τιμές:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![The inverted solid fill color](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αναστροφή για ένα σημείο μέσω του [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Στο παρακάτω παράδειγμα, η αναστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Στο σημείο έχει επίσης οριστεί αρνητική τιμή ώστε το εφέ να είναι ορατό:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Καθαρισμός Συγκεκριμένης Τιμής Σημείου Δεδομένων**

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα υπόλοιπα σημεία, ορίστε το σχετικό κελί του βιβλίου εργασίας σε `null`. Για διάγραμμα στήλης, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [IChartDataPoint.YValue](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/yvalue/). Το σημείο παραμένει στη ίδια θέση κατηγορίας, αλλά το διάγραμμα θεωρεί την τιμή του ως κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

Το παρακάτω παράδειγμα καθαρίζει μόνο το δεύτερο σημείο στην πρώτη σειρά:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Τα διαγράμματα διασποράς χρησιμοποιούν ξεχωριστά κελιά X και Y, και τα διαγράμματα φυσαλίδων χρησιμοποιούν επίσης κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapointcollection/clear/) όταν θέλετε να διατηρήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος Εμφάνισης Κελιών χωρίς Περιεχόμενο**

Κρυμμένα κελιά που περιέχουν τιμές αποτελούν ξεχωριστή περίπτωση από κενά κελιά. Για να συμπεριλάβετε ή εξαιρέσετε δεδομένα από κρυμμένες γραμμές και στήλες του φύλλου, δείτε την ενότητα [Include Data from Hidden Rows and Columns](/slides/el/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί του βιβλίου εργασίας αντιπροσωπεύει ελλιπή δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει αριθμητική τιμή που είναι γνωστή. Ορίστε το [IChartDataCell.Value](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/value/) σε `null` για να κάνετε το κελί κενό. Ένα αριθμητικό μηδέν παραμένει μηδέν ανεξάρτητα από τη ρύθμιση κενών κελιών.

Χρησιμοποιήστε το [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/displayblanksas/) για να επιλέξετε πώς το διάγραμμα εμφανίζει κενά κελιά. Αυτή η ρύθμιση ισχύει σε ολόκληρο το διάγραμμα. Αλλάζει τον τρόπο που τα κενά σχεδιάζονται, χωρίς να γεμίζει το κενό κελί του βιβλίου εργασίας με μηδέν ή με παρεμβαλλόμενη τιμή.

Το παρακάτω αυτοσυνεπές παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με μία σειρά, καθαρίζει την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο διάγραμμα σε κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/) χρησιμοποιεί το φύλλο 0, στήλη 0 για ετικέτες κατηγοριών και στήλη 1 για τιμές· η γραμμή 0 περιέχει το όνομα σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που είχε οριστεί πριν την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε τη ζητούμενη λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί για επανάληψη στις λειτουργίες.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Το ορατό αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος. Ένα διάγραμμα γραμμής κάνει τις τρεις λειτουργίες εύκολα συγκρίσιμες. Τα διαγράμματα μπάρας και στήλης δεν έχουν γραμμή για σύνδεση δια μέσω ελλιπούς κατηγορίας, έτσι το `Span` δεν μπορεί να δημιουργήσει το συνδετικό τμήμα που φαίνεται παραπάνω· μια ελλιπής στήλη και μια στήλη μηδενικού ύψους μπορεί επίσης να μοιάζουν. Αντίστοιχα, ένα διάγραμμα διασποράς με δείκτες μόνο δεν έχει γραμμή σύνδεσης. Μην περιμένετε τρία διαφορετικά αποτελέσματα για κάθε τύπο διαγράμματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Κενού Μεταξύ Σειρών**

Το πλάτος κενού είναι το διάστημα μεταξύ διαδοχικών ομάδων μπαρά ή στήλης, εκφρασμένο ως ποσοστό του πλάτους της μπάρας ή της στήλης. Όπως η επικάλυψη, ανήκει στην γονική ομάδα σειρών και όχι σε μια μόνο σειρά. Ορίστε το [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) μία φορά για την ομάδα. Μια μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μια μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος του κενού και αποθηκεύει μόνο την τελική παρουσίαση:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![The gap width](gap_width.png)

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγραμμάτων που αντιπροσωπεύονται από την αρίθμηση [ChartType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλα την ίδια δομή τιμών ή τις ίδιες ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διαγράμματα διασποράς χρησιμοποιούν τιμές X και Y, και τα διαγράμματα φυσαλίδων προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο σειράς. Επιλογές όπως η επικάλυψη και το πλάτος κενού ισχύουν μόνο για συμβατές ομάδες μπαρά ή στήλης.

**Τι είναι μια ομάδα σειρών διαγράμματος;**

Μια [IChartSeriesGroup](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις ομαδικής σχεδίασης. Ένα σύνθετο διάγραμμα μπορεί να περιέχει περισσότερες από μία ομάδες, έτσι η αλλαγή της ομάδας που προέρχεται από μία σειρά δεν αλλάζει απαραίτητα όλες τις σειρές στο διάγραμμα.

**Ένα πρόσφατα δημιουργημένο διάγραμμα περιέχει προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, η μέθοδος [IShapeCollection.AddChart](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addchart/) δημιουργεί δείγμα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να διαγράψετε και τις συλλογές σειρών και κατηγοριών πριν προσθέσετε ένα εντελώς προσαρμοσμένο σύνολο δεδομένων. Μια υπερφόρτωση μπορεί επίσης να δημιουργήσει διάγραμμα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα διαγράμματος με τα κελιά του βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/). Η αλλαγή ενός αναφερόμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του διαγράμματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, κρατήστε τις γραμμές κατηγοριών και τις γραμμές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από τη σωστή κατηγορία.

**Πώς διαγράφω ένα σημείο αντί ολόκληρης σειράς;**

Ορίστε το σχετικό κελί τιμής σε `null` για να διατηρήσετε τη θέση κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapointcollection/clear/) μόνο όταν σκοπεύετε να αφαιρέσετε όλα τα σημεία από εκείνη τη σειρά. Εάν αφαιρέσετε επίσης κατηγορίες, ενημερώστε κάθε σειρά ώστε οι τιμές τους να παραμείνουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος και το [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/displayblanksas/). Τα υποστηριζόμενα διαγράμματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει με τη σημασία των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε την ενότητα [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για ένα πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για τις υποστηριζόμενες σειρές μπάρας, στήλης και φυσαλίδων, ενεργοποιήστε το [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/invertifnegative/) και ορίστε το [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα μεμονωμένο σημείο μέσω του [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Αυτές οι ιδιότητες επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση κερδίζει όταν τόσο η σειρά όσο και το σημείο μορφοποιούνται;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση σειράς ή, όταν δεν έχει οριστεί μορφοποίηση σειράς, το αυτόματο στυλ και θέμα του διαγράμματος. Οι ιδιότητες ομάδας όπως η επικάλυψη και το πλάτος κενού ελέγχουν τη διάταξη και δεν είναι παρακάμψεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα διάγραμμα;**

Το Aspose.Slides δεν θέτει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, οι περιορισμοί του αρχείου παρουσίασης, η διαθέσιμη μνήμη, ο χρόνος απόδοσης και η αναγνωσιμότητα του διαγράμματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά μεταξύ τους;**

Ορίστε το [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) στη κατάλληλη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το διάστημα μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.