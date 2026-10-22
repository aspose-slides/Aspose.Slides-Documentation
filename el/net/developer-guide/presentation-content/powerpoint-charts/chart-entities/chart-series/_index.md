---
title: Διαχείριση Σειρών Δεδομένων Διαγράμματος σε Παρουσιάσεις σε .NET
linktitle: Σειρές Δεδομένων
type: docs
url: /el/net/chart-series/
keywords:
- σειρές διαγράμματος
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
description: "Μάθετε πώς να διαχειρίζεστε τις σειρές διαγράμματος, τα σημεία δεδομένων, τα κελιά του βιβλίου εργασίας, τη μορφοποίηση, την επικάλυψη, το πλάτος του κεννού και τις αρνητικές τιμές σε παρουσιάσεις με C#."
---
## **Επισκόπηση**

Ένα διάγραμμα μπορεί να αποθηκεύσει τις τιμές που σχεδιάζει σε κελιά του βιβλίου εργασίας ή άμεσα ως αριθμητικά κυριολεξικά. Ένα [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) αντιπροσωπεύει ένα σημείο σε αυτή τη σειρά. Τα αντικείμενα [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται οι σειρές. Σε διαγράμματα που δημιουργούνται με προεπιλεγμένα δεδομένα, τα ονόματα σειρών, οι κατηγορίες και οι τιμές σημείων χρησιμοποιούν αντικείμενα [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) από το βιβλίο εργασίας του διαγράμματος.

Για ένα τυπικό διάγραμμα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για τα ονόματα σειρών, τη στήλη 0 για τα ονόματα κατηγοριών και τα υπόλοιπα κελιά για τις τιμές σειρών. Οι δείκτες φύλλου εργασίας, γραμμής και στήλης που περνιούνται στο [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) είναι μηδενικές βάσεις. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα διάγραμμα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον διάγραμμα τη χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά που αναφέρονται από τις σειρές, τις κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις διαγράμματος έχουν τρεις διαφορετικές εμβέλειες:

- Ρυθμίσεις επιπέδου σειράς, όπως [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία σε μία σειρά.
- Ρυθμίσεις σημείου δεδομένων, όπως [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), αντικαθιστούν την εμφάνιση της σειράς για ένα συγκεκριμένο σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στο ίδιο [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). Πρόσβαση στην ομάδα μέσω του [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) όταν πρέπει να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος του κεννού.

Όταν δεν έχει οριστεί ρητό γέμισμα σημείου ή σειράς, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο μορφοποίηση σειράς όσο και σημείου, η μορφοποίηση του σημείου έχει προτεραιότητα για εκείνο το σημείο.

![Διαγράμματα-σειράς-PowerPoint](chart-series-powerpoint.png)

## **Ορισμός Τιμών Σειράς Χρησιμοποιώντας Αριθμητικά Κυριολεξικά**

Χρησιμοποιήστε αριθμητικά κυριολεξικά όταν οι τιμές σειράς προέρχονται από δεδομένα ή υπολογισμούς της εφαρμογής και δεν χρειάζεται να αναφέρονται σε κελιά του φύλλου εργασίας. Ορίστε [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) σε [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) πριν εκχωρήσετε σε κάθε σημείο την [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) μέσω του [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

Η ρύθμιση της συλλογής ελέγχει τον τύπο πηγής για όλες τις τιμές σημείων στη συγκεκριμένη σειρά. Κάθε σημείο αναφέρει τον τύπο πηγής του μέσω του [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/). Αλλάξτε τον μέσω της ρύθμισης της συλλογής. Με `Worksheet`, χρησιμοποιήστε το [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) για πρόσβαση στο αναφερόμενο κελί. Με `DoubleLiterals`, χρησιμοποιήστε το `AsLiteralDouble` για ανάγνωση ή εγγραφή του αριθμού απευθείας.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα στήλης με προεπιλεγμένες σειρές και κατηγορίες, στη συνέχεια εκχωρεί υπολογισμένες τιμές 10, 20 κλπ. στα υπάρχοντα σημεία της πρώτης σειράς. Αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει τις αποθηκευμένες τιμές.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

Ο τύπος πηγής τιμής σημείου είναι ξεχωριστός από το [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), το οποίο προσδιορίζει τη διαμόρφωση ενσωματωμένου ή εξωτερικού βιβλίου εργασίας του διαγράμματος. Η χρήση αριθμητικών κυριολεξικών δεν αφαιρεί αυτόματα το ενσωματωμένο βιβλίο εργασίας. Σε αυτό το παράδειγμα, το βιβλίο εργασίας παραμένει διαθέσιμο για ετικέτες κατηγοριών, ονόματα σειρών και τις άλλες σειρές. Δείτε το [Chart Workbook](/slides/el/net/chart-workbook/) για διαχείριση βιβλίου εργασίας.

Για διαγράμματα διασποράς και φούσκας, ορίστε [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) και [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) ώστε να επιλέξετε τις πηγές για τις [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) και [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Τα διαγράμματα φούσκας χρησιμοποιούν επίσης το [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) για το [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). Ορίστε κάθε σχετική πηγή σε `DoubleLiterals` πριν εκχωρήσετε αριθμούς μέσω της ιδιότητας `AsLiteralDouble` της αντίστοιχης τιμής.

## **Ορισμός Επικάλυψης Σειράς Διαγράμματος**

Το [IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) αναφέρει το πόσο επικάλυψη έχουν οι μπάρες ή στήλες σε ένα 2Δ διάγραμμα, από –100 έως 100 ποσοστό. Είναι μια μόνο‑ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειράς. Ορίστε το [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) για να ενημερώσετε όλες τις συμβατές σειρές στην ομάδα. Αυτή η επιλογή εφαρμόζεται σε τύπους διαγραμμάτων που εμφανίζουν ομαδοποιημένες μπάρες ή στήλες· δεν επηρεάζει άσχετες ομάδες σειρών σε ένα σύνθετο διάγραμμα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιλαμβάνει την πρώτη σειρά:

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

![Η επικάλυψη της σειράς](series_overlap.png)

## **Αλλαγή Χρώματος Γέμισης Σειράς**

Χρησιμοποιήστε το [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) για να ορίσετε το προεπιλεγμένο γέμισμα ολόκληρης της σειράς. Εάν ένα σημείο διαθέτει ήδη ρητό γέμισμα, η ρύθμιση του [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) αντικαθιστά το γέμισμα της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει στεγνό μπλε γέμισμα στην πρώτη σειρά:

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

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων του διαγράμματος και εμφανίζεται συνήθως στον υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα συγκεντρωτικό διάγραμμα στήλης, το κελί B1 βρίσκεται στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι ονομαστικές σταθερές του παρακάτω παραδείγματος κάνουν αυτή τη δομή ρητή:

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

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής και στήλης σε υπάρχον διάγραμμα:

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

### **Δημιουργία Σειράς με Όνομα από Πολλαπλά Κελιά**

Ένα σύνθετο όνομα σειράς είναι χρήσιμο όταν το όνομα προϊόντος και η περίοδος αναφοράς αποθηκεύονται σε ξεχωριστά κελιά του βιβλίου εργασίας. Για παράδειγμα, μπορείτε να συνδυάσετε το `Product A` στο B1 και το `2026` στο C1 σε ένα ενιαίο όνομα σειράς, διατηρώντας τα δύο τμήματα συνδεδεμένα με τα πηγαία κελιά.

Χρησιμοποιήστε το [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) για να ανακτήσετε το εύρος ονομάτων, κατόπιν περάστε αυτή τη συλλογή στο [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). Το όρισμα `skipHiddenCells` ελέγχει αν θα συμπεριληφθούν κρυμμένα κελιά: `true` τα εξαιρεί, ενώ `false` τα περιλαμβάνει. Το παράδειγμα χρησιμοποιεί `false` ώστε να συμπεριληφθούν όλα τα κελιά του εύρους ονομάτων.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με μία σειρά και δύο σημεία δεδομένων. Τα κελιά B1:C1 παρέχουν μόνο το όνομα σειράς· τα A2:A3 παρέχουν τις ετικέτες κατηγοριών, και τα B2:B3 παρέχουν τις αριθμητικές τιμές.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Αυτά τα δύο κελιά παρέχουν το όνομα της σειράς.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Ξεχωριστά κελιά παρέχουν τις κατηγορίες και τα αριθμητικά σημεία δεδομένων.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

Το προκύπτον όνομα σειράς είναι `Product A 2026`, με κενό μεταξύ των δύο τιμών κελιών. Ο υπόμνημα το εμφανίζει ως μία εγγραφή για και τις δύο στήλες. Η εικόνα παρακάτω αποδόθηκε από την αποθηκευμένη παρουσίαση:

![Διάγραμμα στήλης με τιμές Βορρά και Νότου και το σύνθετο όνομα σειράς Product A 2026 στον υπόμνημα](composite_series_name.png)

## **Λήψη Αυτόματου Χρώματος Γέμισης Σειράς**

Το [IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) επιστρέφει το χρώμα που υπολογίζεται από το δείκτη σειράς και το στυλ του διαγράμματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν εκχωρεί νέο γέμισμα.

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

Αποτέλεσμα εκτέλεσης για το προεπιλεγμένο στυλ διαγράμματος:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Τα ακριβή χρώματα εξαρτώνται από το στυλ και το θέμα του διαγράμματος.

## **Ορισμός Αντίστροφου Χρώματος Γέμισης για Σειρά Διαγράμματος**

Για σειρές μπάρας, στήλης και φούσκας, το [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα σειράς σε στεγνό, ενεργοποιήστε την αντιστροφή και εκχωρήστε το χρώμα αρνητικής τιμής μέσω του [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· αλλάζει μόνο το χρώμα εμφάνισης.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με μία σειρά. Η γραμμή 0 του φύλλου εργασίας περιέχει το όνομα σειράς, η στήλη 0 τις ετικέτες κατηγοριών και η στήλη 1 τις τιμές:

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

![Το αντιστροφή χρώματος γεμίσματος](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Στο σημείο έχει επίσης εκχωρηθεί μια αρνητική τιμή ώστε το εφέ να είναι ορατό:

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

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το κελί του βιβλίου εργασίας σε `null`. Σε διάγραμμα στήλης, η σχεδιασμένη τιμή είναι προσβάσιμη μέσω του [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το διάγραμμα θεωρεί την τιμή του ως κενή σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

Το παρακάτω παράδειγμα καθαρίζει μόνο το δεύτερο σημείο της πρώτης σειράς:

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

Τα διαγράμματα διασποράς χρησιμοποιούν ξεχωριστά κελιά X και Y, και τα διαγράμματα φούσκας επίσης ένα κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) όταν θέλετε να διατηρήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος Εμφάνισης Κενού Κελιών**

Τα κρυμμένα κελιά που περιέχουν τιμές αποτελούν ξεχωριστή περίπτωση από τα κενά κελιά. Για ένταξη ή εξαίρεση δεδομένων από κρυμμένες γραμμές και στήλες φύλλου εργασίας, δείτε την ενότητα [Include Data from Hidden Rows and Columns](/slides/el/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί βιβλίου εργασίας αντιπροσωπεύει ελλιπή δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει γνωστή αριθμητική τιμή. Ορίστε το [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) σε `null` για να κάνετε το κελί κενό. Ένας αριθμητικός μηδενισμός παραμένει μηδέν ανεξαρτήτως της ρύθμισης κενών κελιών.

Χρησιμοποιήστε το [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) για να επιλέξετε πώς το διάγραμμα εμφανίζει τα κενά κελιά. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρο το διάγραμμα. Αλλάζει τον τρόπο με τον οποίο τα κενά σχεδιάζονται, χωρίς να γεμίζει το κενό κελί με μηδέν ή με παρεμβατισμένη τιμή.

Το παρακάτω αυτοσχέδιο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με μία σειρά, καθαρίζει την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο διάγραμμα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) χρησιμοποιεί το φύλλο 0, στήλη 0 για ετικέτες κατηγοριών και στήλη 1 για τιμές· η γραμμή 0 περιέχει το όνομα σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

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

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που είχε οριστεί πριν από την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για αποθήκευση μόνο μιας έκδοσης, ορίστε την επιθυμητή λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί για επανάληψη των λειτουργιών.

Η παρακάτω σύγκριση δείχνει τα ίδια δεδομένα και στις τρεις αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Διαγράμματα γραμμής με ισότιμα δεδομένα: Το Gap διακόπτει τη γραμμή στην Ημέρα 3, το Zero κατεβάζει τη γραμμή στο μηδέν, και το Span συνδέει την Ημέρα 2 με την Ημέρα 4.](display_blanks_as.png)

Το οπτικό αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος. Ένα διάγραμμα γραμμής κάνει τους τρεις τρόπους εύκολα συγκρίσιμους. Τα διαγράμματα μπάρας και στήλης δεν έχουν γραμμή για σύνδεση μέσω ελλιπούς κατηγορίας, οπότε το `Span` δεν μπορεί να παράγει το συνδετικό τμήμα που φαίνεται παραπάνω· ένα κενότήσμένο ή μηδενικό φύλλο μπορεί επίσης να μοιάζει. Αντίστοιχα, ένα διάγραμμα διασποράς μόνο με δείκτες δεν έχει γραμμή σύνδεσης. Μην περιμένετε τρία διαφορετικά αποτελέσματα για κάθε τύπο διαγράμματος· ελέγξτε το αποτέλεσμα για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Κεννού μεταξύ Σειρών**

Το πλάτος του κεννού είναι το διάστημα μεταξύ γειτονικών ομάδων μπάρας ή στήλης, εκφρασμένο ως ποσοστό του πλάτους της μπάρας ή στήλης. Όπως η επικάλυψη, ανήκει στην γονική ομάδα σειρών και όχι σε μία σειρά. Ορίστε το [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) μία φορά για την ομάδα. Μία μεγαλύτερη τιμή δημιουργεί περισσότερο διάστημα μεταξύ των ομάδων· μία μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος του κεννού και αποθηκεύει μόνο την τελική παρουσίαση:

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

![Το πλάτος του κεννού](gap_width.png)

## **ΣΥΝΑΡΤΗΣΕΙΣ (FAQ)**

**Ποιοί τύποι διαγράμματος υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγράμματος που αντιπροσωπεύονται από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλες την ίδια δομή τιμών ή τις ίδιες ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διαγράμματα διασποράς χρησιμοποιούν τιμές X και Y, και τα διαγράμματα φούσκας προσθέτουν μεγέθη φούσκας. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο σειράς. Ρυθμίσεις όπως η επικάλυψη και το πλάτος κεννού ισχύουν μόνο σε συμβατές ομάδες μπάρας ή στήλης.

**Τι είναι μια ομάδα σειρών διαγράμματος;**

Μία [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται τις ρυθμίσεις ομαδοποίησης. Ένα σύνθετο διάγραμμα μπορεί να περιέχει περισσότερες από μία ομάδες, οπότε η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει απαραίτητα όλες τις σειρές στο διάγραμμα.

**Δημιουργείται προεπιλεγμένα δεδομένα το νέο διάγραμμα;**

Ναι. Από προεπιλογή, το [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) δημιουργεί δείγματες σειρές, κατηγορίες και τιμές. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και των κατηγοριών πριν προσθέσετε ένα εντελώς προσαρμοσμένο σύνολο δεδομένων. Υπάρχει υπερφόρτωση που μπορεί επίσης να δημιουργήσει διάγραμμα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα διαγράμματος με τα κελιά του βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Η αλλαγή ενός αναφερόμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του διαγράμματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις γραμμές κατηγοριών και τις σειρές τιμών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από την προοριζόμενη κατηγορία.

**Πώς να καθαρίσω ένα μόνο σημείο αντί όλης της σειράς;**

Ορίστε το σχετικό κελί τιμής σε `null` για να διατηρήσετε τη θέση της κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) μόνο όταν θέλετε να αφαιρέσετε όλα τα σημεία από τη σειρά. Εάν αφαιρέσετε επίσης τις κατηγορίες, ενημερώστε όλες τις σειρές ώστε οι τιμές τους να παραμένουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο διαγράμματος και το [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Τα υποστηριζόμενα διαγράμματα μπορούν να εμφανίζουν τα κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει με το νόημα των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε την ενότητα [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για ένα πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για τις υποστηριζόμενες σειρές μπάρας, στήλης και φούσκας, ενεργοποιήστε το [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) και ορίστε το [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα μεμονωμένο σημείο με το [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Αυτές οι ιδιότητες επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση κυριαρχεί όταν τόσο η σειρά όσο και το σημείο είναι μορφοποιημένα;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για το εν λόγω σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση της σειράς ή, όταν η μορφοποίηση της σειράς δεν είναι ορισμένη, το αυτόματο στυλ και θέμα του διαγράμματος. Οι ιδιότητες ομάδας όπως η επικάλυψη και το πλάτος κεννού ελέγχουν τη διάταξη και δεν υπερκαλύπτουν μορφοποίηση επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα διάγραμμα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, περιορισμοί του αρχείου παρουσίασης, η διαθέσιμη μνήμη, ο χρόνος απόδοσης και η αναγνωσιμότητα του διαγράμματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά;**

Ορίστε το [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) στην αντίστοιχη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το διάστημα μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.