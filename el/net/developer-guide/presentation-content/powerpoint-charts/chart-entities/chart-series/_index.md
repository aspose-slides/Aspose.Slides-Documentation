---
title: Διαχείριση Σειρών Δεδομένων Διαγράμματος σε Παρουσιάσεις στο .NET
linktitle: Σειρές Δεδομένων
type: docs
url: /el/net/chart-series/
keywords:
- σειρά διαγράμματος
- επικάλυψη σειράς
- χρώμα σειράς
- χρώμα κατηγορίας
- όνομα σειράς
- σημείο δεδομένων
- κενό σειράς
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σειρές διαγράμματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος κενού και αρνητικές τιμές σε παρουσιάσεις με C#."
---
## **Επισκόπηση**

Ένα διάγραμμα αποθηκεύει τα σχεδιασμένα του δεδομένα σε ένα βιβλίο εργασίας δεδομένων διαγράμματος. Ένα [IChartSeries](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [IChartDataPoint](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/) στη σειρά αναφέρεται σε ένα ή περισσότερα κελιά του βιβλίου εργασίας. Τα αντικείμενα [IChartCategory](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται από τις σειρές. Το όνομα της σειράς, οι κατηγορίες και οι τιμές των σημείων συνδέονται, λοιπόν, με αντικείμενα [IChartDataCell](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/) αντί να αποθηκεύονται μόνο ως κείμενο εμφάνισης.

Για ένα τυπικό διάγραμμα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για ονόματα σειρών, τη στήλη 0 για ονόματα κατηγοριών και τα υπόλοιπα κελιά για τιμές σειρών. Οι δείκτες φύλλου, γραμμής και στήλης που περνιούνται στο [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/getcell/) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα διάγραμμα με προεπιλεγμένα δεδομένα, αλλά δεν πρέπει να θεωρήσετε ότι κάθε υπάρχον διάγραμμα τη χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά που αναφέρονται από τις σειρές, τις κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές στο βιβλίο εργασίας.

Οι ρυθμίσεις του διαγράμματος έχουν τρία διαφορετικά επίπεδα:

- Ρυθμίσεις σε επίπεδο σειράς, όπως το [IChartSeries.Format](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/format/), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία σε μία σειρά.
- Ρυθμίσεις σημείου δεδομένου, όπως το [IChartDataPoint.Format](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/format/), παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στην ίδια [IChartSeriesGroup](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseriesgroup/). Πρόσβαση στην ομάδα μέσω του [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/parentseriesgroup/) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος κενών.

Όταν δεν έχει οριστεί ρητά γέμισμα σημείου ή σειράς, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν είναι παρόν τόσο το γέμισμα σειράς όσο και το γέμισμα σημείου, το γέμισμα σημείου έχει προτεραιότητα για εκείνο το σημείο.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός της Επικάλυψης Σειράς Διαγράμματος**

[IChartSeries.Overlap](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/overlap/) αναφέρει πόσο επικάλλονται οι ράβδοι ή οι στήλες σε ένα 2Δ διάγραμμα, από -100 έως 100 τοις εκατό. Είναι μια μόνο για ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειράς. Ορίστε το [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseriesgroup/overlap/) για να ενημερώσετε κάθε συμβατή σειρά σε εκείνη την ομάδα. Αυτή η επιλογή εφαρμόζεται σε τύπους διαγραμμάτων που εμφανίζουν ομαδοποιημένους ράβδους ή στήλες· δεν επηρεάζει μη σχετικές ομάδες σειρών σε ένα συνδυαστικό διάγραμμα.

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

// Το νέο διάγραμμα περιλαμβάνει δείγμα σειρών, κατηγοριών και τιμών.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η επικάλυψη των σειρών](series_overlap.png)

## **Αλλαγή Χρώματος Γεμίσματος Σειράς**

Χρησιμοποιήστε το [IChartSeries.Format](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/format/) για να ορίσετε το προεπιλεγμένο γέμισμα για ολόκληρη τη σειρά. Εάν ένα σημείο έχει ήδη ρητό γέμισμα, η ρύθμιση του [IChartDataPoint.Format](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/format/) παρακάμπτει το γέμισμα της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει γεμιστό στεγνό μπλε στην πρώτη σειρά:

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

![Το χρώμα της σειράς](series_color.png)

## **Αλλαγή Ονόματος Σειράς**

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων διαγράμματος και εμφανίζεται κανονικά στη λεζάντα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα διάγραμμα στήλης με ομάδες, το κελί B1 βρίσκεται στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι ονομαστικές σταθερές στο παρακάτω παράδειγμα κάνουν αυτή τη δομή σαφή:

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

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [IChartSeries.Name](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/name/). Αυτή η προσέγγιση αποφεύγει την υπόθεση μιας συγκεκριμένης γραμμής και στήλης σε υπάρχον διάγραμμα:

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

![Το όνομα της σειράς](series_name.png)

## **Λήψη του Αυτόματου Χρώματος Γεμίσματος Σειράς**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) επιστρέφει το χρώμα που υπολογίζεται από το δείκτη της σειράς και το στυλ του διαγράμματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν αναθέτει νέο γέμισμα.

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

## **Ορισμός Αντιστροφής Χρώματος Γεμίσματος για Σειρά Διαγράμματος**

Για ράβδους, στήλες και σφαίρες, το [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/invertifnegative/) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα της σειράς σε στεγνό, ενεργοποιήστε την αντιστροφή και ορίστε το χρώμα αρνητικής τιμής μέσω του [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· αλλάζει μόνο το χρώμα εμφάνισης.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με μία σειρά. Η γραμμή 0 του φύλλου περιέχει το όνομα της σειράς, η στήλη 0 περιέχει ονόματα κατηγοριών και η στήλη 1 περιέχει τις τιμές:

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

![Το αντιστροφή στεγνού γεμίσματος](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Το σημείο λαμβάνει επίσης μια αρνητική τιμή ώστε το εφέ να είναι ορατό:

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

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το αντίστοιχο κελί του βιβλίου εργασίας σε `null`. Για ένα διάγραμμα στήλης, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [IChartDataPoint.YValue](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/yvalue/). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το διάγραμμα το αντιμετωπίζει ως κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

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

Τα διαγράμματα scatter χρησιμοποιούν ξεχωριστά κελιά X και Y, ενώ τα διαγράμματα φυσαλίδων χρησιμοποιούν επίσης κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapointcollection/clear/) όταν θέλετε να διατηρήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Ορισμός Πλάτους Κενού Ομάδας Σειρών**

Το πλάτος κενού είναι το κενό μεταξύ γειτονικών ομάδων ράβδων ή στήλων, εκφρασμένο ως ποσοστό του πλάτους της ράβδου ή στήλης. Όπως η επικάλυψη, ανήκει στην γονική ομάδα σειρών και όχι σε μία σειρά. Ορίστε το [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) μια φορά για την ομάδα. Μία μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μια μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος κενού και αποθηκεύει μόνο την τελική παρουσίαση:

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

![Το πλάτος κενού](gap_width.png)

## **ΣΥΝΗΘΕΣΜΕΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγραμμάτων που αντιπροσωπεύονται από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλοι την ίδια δομή τιμών ή τις ίδιες ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διαγράμματα scatter χρησιμοποιούν τιμές X και Y, και τα διαγράμματα φυσαλίδων προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει στον τύπο σειράς. Οι επιλογές όπως η επικάλυψη και το πλάτος κενού εφαρμόζονται μόνο σε συμβατές ομάδες ράβδων ή στηλών.

**Τι είναι μια ομάδα σειρών διαγράμματος;**

Μια [IChartSeriesGroup](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις σχεδιασμού επιπέδου ομάδας. Ένα συνδυαστικό διάγραμμα μπορεί να περιέχει περισσότερες από μία ομάδες, έτσι η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει απαραίτητα κάθε σειρά στο διάγραμμα.

**Μήπως ένα νεοδημιουργημένο διάγραμμα περιέχει προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, το [IShapeCollection.AddChart](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addchart/) δημιουργεί δείγμα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και κατηγοριών πριν προσθέσετε ένα πλήρως προσαρμοσμένο σύνολο δεδομένων. Ένα υπερφορτωμένο API μπορεί επίσης να δημιουργήσει διάγραμμα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα διαγράμματος με κελιά βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/). Η αλλαγή ενός αναφερόμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του διαγράμματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις γραμμές κατηγοριών και τις γραμμές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από την επιθυμητή κατηγορία.

**Πώς να καθαρίσω ένα σημείο αντί ολόκληρης της σειράς;**

Ορίστε το σχετικό κελί τιμής σε `null` για να διατηρήσετε τη θέση κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapointcollection/clear/) μόνο όταν επιθυμείτε να αφαιρέσετε όλα τα σημεία από εκείνη τη σειρά. Εάν αφαιρείτε επίσης κατηγορίες, ενημερώστε κάθε σειρά ώστε οι τιμές τους να παραμένουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος και το [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/displayblanksas/). Τα υποστηριζόμενα διαγράμματα μπορούν να εμφανίζουν τα κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει στη σημασία των ελλιπών δεδομένων στην παρουσίασή σας.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για υποστηριζόμενες σειρές ράβδων, στηλών και φυσαλίδων, ενεργοποιήστε το [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/invertifnegative/) και ορίστε το [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Μπορείτε να παρακάμψετε τη συμπεριφορά για μια ατομική σημείο με το [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Αυτές οι ιδιότητες επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση επικρατεί όταν τόσο η σειρά όσο και το σημείο είναι μορφοποιημένα;**

Η ρητή μορφοποίηση σημείου δεδομένου έχει προτεραιότητα για εκείνο το σημείο. Τα υπόλοιπα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση σειράς ή, όταν η μορφοποίηση σειράς δεν είναι ορισμένη, το αυτόματο στυλ και θέμα του διαγράμματος. Οι ιδιότητες ομάδας όπως η επικάλυψη και το πλάτος κενού ελέγχουν τη διάταξη και δεν αποτελούν παρακάμψεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα διάγραμμα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, οι περιορισμοί του αρχείου παρουσίασης, η διαθέσιμη μνήμη, ο χρόνος απόδοσης και η αναγνωσιμότητα του διαγράμματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά μεταξύ τους;**

Ορίστε το [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) στην κατάλληλη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το διάστημα μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά η μία στην άλλη.