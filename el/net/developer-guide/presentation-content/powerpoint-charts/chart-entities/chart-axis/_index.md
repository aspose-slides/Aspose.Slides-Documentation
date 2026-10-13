---
title: Προσαρμογή αξόνων διαγράμματος σε παρουσιάσεις με .NET
linktitle: Άξονας Διαγράμματος
type: docs
url: /el/net/chart-axis/
keywords:
- άξονας διαγράμματος
- κάθετος άξονας
- οριζόντιος άξονας
- προσαρμογή άξονα
- χειρισμός άξονα
- διαχείριση άξονα
- ιδιότητες άξονα
- μέγιστη τιμή
- ελάχιστη τιμή
- γραμμή άξονα
- μορφή ημερομηνίας
- τίτλος άξονα
- θέση άξονα
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιείτε το Aspose.Slides για .NET για την προσαρμογή των αξόνων διαγράμματος σε παρουσιάσεις PowerPoint για αναφορές και απεικονίσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τους άξονες διαγραμμάτων με το Aspose.Slides for .NET. Καλύπτει τις υπολογιζόμενες τιμές άξονα, την εναλλαγή γραμμών και στηλών του διαγράμματος, την ορατότητα του άξονα, τα διαστήματα ετικετών κατηγοριών και των γραμμών σημείων, τις κατηγορίες ημερομηνίας και τη μορφοποίηση, την περιστροφή του τίτλου, τη θέση του άξονα, τις μονάδες εμφάνισης και την λογαριθμική κλίμακα.

## **Λάβετε τις Μέγιστες Τιμές στον Κάθετο Άξονα στα Διαγράμματα**

Δημιουργήστε μια [Παρουσίαση](https://reference.aspose.com/slides/net/aspose.slides/presentation/) και προσθέστε ένα διάγραμμα περιοχής με προεπιλεγμένα δεδομένα. Καλέστε το [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) πριν διαβάσετε τις υπολογιζόμενες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Αναγνώστε το [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) και το [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) για τα όρια του άξονα, και το [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) και το [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) για τα διαστήματα των σημείων. Τα [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) και [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) παρέχουν κλιμάκωση μονάδων χρόνου, που είναι σχετικές με τους άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Ανταλλαγή των Δεδομένων μεταξύ Αξόνων**

Χρησιμοποιήστε το [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα του διαγράμματος. Κάθε προηγούμενη κατηγορία γίνεται σειρά, και κάθε προηγούμενη σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κάθετους άξονες. Το παράδειγμα χρησιμοποιεί το [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) για να συνδέσει τα προεπιλεγμένα δεδομένα με `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγοριών, πριν την εναλλαγή γραμμών και στηλών. Αποθηκεύει ένα διάγραμμα με τέσσερις σειρές και τρεις κατηγορίες.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Απενεργοποίηση του Κάθετου Άξονα για Γραμμικά Διαγράμματα**

Ορίστε το [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) σε `false` στον κάθετο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γραμμικό διάγραμμα με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κάθετο άξονα κρυμμένο.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Απενεργοποίηση του Οριζόντιου Άξονα για Γραμμικά Διαγράμματα**

Ορίστε το [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) σε `false` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γραμμικό διάγραμμα με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυμμένο.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Αλλαγή Άξονα Κατηγορίας**

Ορίστε το [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) για να επιλέξετε έναν άξονα ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα διάγραμμα ως το πρώτο σχήμα της πρώτης διαφάνειας και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας του Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Ορίζοντας το [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) σε `false`, το [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) σε `1` και το [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) σε μήνες τοποθετούν τα κύρια σημεία σε διαστήματα ενός μήνα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **Έλεγχος Διαστημάτων Ετικετών Άξονα Κατηγορίας**

Όταν ένα διάγραμμα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Ορίστε το [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) σε `false`, έπειτα ορίστε το [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) στο επιθυμητό διάστημα κατηγορίας. Για κατηγορίες κειμένου στη φυσική τους σειρά, η μέτρηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Κατηγορία 1, Κατηγορία 2, Κατηγορία 3, ... Κατηγορία 24 |
| `2` | Κατηγορία 1, Κατηγορία 3, Κατηγορία 5, ... Κατηγορία 23 |
| `3` | Κατηγορία 1, Κατηγορία 4, Κατηγορία 7, ... Κατηγορία 22 |

Ένα διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη διάταξη επιλέγει διάστημα με βάση τον διαθέσιμο χώρο· δεν εμφανίζει απαραίτητα κάθε ετικέτα.

Οι γραμμές σημείων έχουν ξεχωριστούς ελέγχους. Ορίστε το [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) σε `false` και χρησιμοποιήστε το [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) για να ορίσετε το διάστημά τους. Για παράδειγμα, το `1` διατηρεί μια γραμμή σημείου σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Ορίστε το [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) σε ένα ορατό στυλ ώστε να δείτε το αποτέλεσμα. Επαναφέροντας οποιαδήποτε ιδιότητα αυτόματης διάταξης σε `true` αφήνετε το διάγραμμα να επιλέξει πάλι αυτό το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, έπειτα αποθηκεύει τρεις διαφάνειες στο `CategoryAxisIntervals.pptx`: αυτόματη διάταξη, χειροκίνητη διάταξη ετικετών με ανεξάρτητες γραμμές σημείων, και επαναφορά της αυτόματης διάταξης. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται εισαγωγική παρουσίαση. Το κείμενο ετικετών οριζόντια κάνει εύκολη την παρατήρηση της πυκνότητας.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Διαφάνεια 2: εμφάνιση κάθε τρίτης ετικέτας, αλλά διατήρηση γραμμής σημείου για κάθε κατηγορία.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Διαφάνεια 3: αφήστε το διάγραμμα να επιλέξει ξανά και τα δύο διαστήματα.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Αυτόματη διάταξη (διαφάνεια 1):** Σε αυτήν την αναπαράσταση, κάθε δεύτερη ετικέτα κατηγορίας εμφανίζεται και τυλίγεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και τον αποτυπωτή.

![Αυτόματη διάταξη ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητη διάταξη (διαφάνεια 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μία γραμμή, ενώ οι γραμμές σημείων παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων εκείνων χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Χειροκίνητη διαδοχή ετικετών κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλογή του Σωστού Άξονα και Διαστήματος**

Χρησιμοποιήστε αυτό το διάστημα μετρήσεων κατηγορίας για άξονα κειμένου, όπως ο άξονας κατηγορίας ενός ράβδο, γραμμικού, περιοχής ή στήλης διαγράμματος. Σε διάγραμμα στήλης, είναι ο οριζόντιος άξονας. Σε οριζόντιο οριζόντιο ράβδισμα, ο άξονας κατηγορίας είναι κάθετος, επομένως εφαρμόστε αυτές τις ρυθμίσεις στο [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Η διάταξη των γραμμών σημείων ισχύει επίσης για άξονα σειράς σε διαγράμματα που το έχουν.

Μην χρησιμοποιείτε τη διάταξη ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμής. Σε άξονα τιμής, το [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) καθορίζει τη διαφορά τιμών: για παράδειγμα, μια κύρια μονάδα `10` παράγει γραμμές σημείων στα 0, 10, 20 κλπ όταν ο άξονας ξεκινά από το μηδέν. Ένα διάστημα ετικέτας κατηγορίας `3` μετρά θέσεις κατηγορίας, ανεξάρτητα από τις τιμές τους. Τα διαγράμματα διασποράς και φυσαλίδων χρησιμοποιούν άξονες τιμής αντί για άξονα κειμένου. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες και κλίμακες βάσει χρόνου όπως περιγράφεται στην [Αλλαγή Άξονα Κατηγορίας](#change-a-category-axis).

## **Ορισμός Μορφής Ημερομηνίας για Τιμές Άξονα Κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα του διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`). Ορίστε το [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) σε άξονα ημερομηνίας, απενεργοποιήστε το [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/), και εκχωρήστε `yyyy` στο [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) ώστε οι ετικέτες κατηγορίας να εμφανίζουν τέσσερα ψηφία έτους ανεξάρτητα από τη μορφοποίηση του κελιού.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Ορισμός Γωνίας Περιστροφής για Τίτλο Άξονα Διαγράμματος**

Ενεργοποιήστε το [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) στον κάθετο άξονα, δώστε κείμενο τίτλου, και ορίστε το [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· το παράδειγμα αποθηκεύει ένα διάγραμμα στήλης με τον τίτλο του άξονα τιμής περιστραμμένο κατά 90 μοίρες.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **Ορισμός Θέσης Άξονα σε Άξονα Κατηγορίας ή Τιμής**

Χρησιμοποιήστε το [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) για να ελέγξετε αν ο άξονας τιμής διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία των κατηγοριών. Αυτή η ιδιότητα εφαρμόζεται σε άξονες κατηγορίας. Το παράδειγμα το ορίζει σε `true` στον οριζόντιο άξονα κατηγορίας ενός διαγράμματος στήλης και αποθηκεύει το αποτέλεσμα.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Ορισμός Μονάδας Εμφάνισης σε Άξονα Τιμής Διαγράμματος**

Ορίστε το [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) για να κλιμακώσετε τις ετικέτες σε άξονα τιμής χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) ορισμένο σε `Millions`, μια τιμή των 60 000 000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα διάγραμμα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κάθετο άξονά του.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **Διαμόρφωση Λογαριθμικού Άξονα Τιμής**

Ένας λογαριθμικός άξονας τιμής είναι χρήσιμος όταν θετικές τιμές καλύπτουν πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1 000, 10 000 και 100 000 αιτήσεις σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται κοντά στη μηδενική τιμή. Μια λογαριθμική κλίμακα καθιστά πιο εύκολη τη σύγκριση της σχετικής ανάπτυξής τους: ίσες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες αντί για ίσες διαφορές.

Ορίστε το [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) σε `true` στον άξονα τιμής και χρησιμοποιήστε το [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υφιστάμενων τιμών· δεν αλλάζει τα δεδομένα ούτε προσθέτει λογαριθμική γραμμή τάσης. Μια γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστή λειτουργία.

### **Επιλογή του Άξονα Τιμής και Βάσης**

Για ένα γραμμικό ή στήλης διάγραμμα, ο άξονας τιμής είναι ο [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Για οριζόντιο ραβδόγραμμα, είναι ο [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Τα διαγράμματα διασποράς και φυσαλίδων έχουν δύο άξονες τιμής, οπότε επιλέξτε τον οριζόντιο άξονα για τις τιμές X, τον κάθετο άξονα για τις τιμές Y ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένων· υποστηρίζονται επίσης κλασματικές βάσεις όπως `2.5`. Με βάση `10`, οι διαδοχικές δυνάμεις όπως 10, 100, 1 000 και 10 000 είναι εξίσου διαχωρισμένες.

### **Σύγκριση Γραμμικής και Λογαριθμικής Κλίμακας**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γραμμικό διάγραμμα με τις πέντε μετρήσεις αιτήσεων στην πρώτη διαφάνεια, μετά κλωνοποιεί τη διαφάνειά του και ενεργοποιεί λογαριθμικό άξονα τιμής βάσης‑10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Keep the first slide linear and change only the copy's value-axis scale.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Γραμμική κλίμακα (διαφάνεια 1):** Ισάξιες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτήσεων. Η μεγαλύτερη τιμή κυριαρχεί στο διάγραμμα, καθιστώντας τις μικρότερες τιμές δύσκολο να διακριθούν.

![Γραμμικό διάγραμμα στο PowerPoint που δείχνει πέντε μετρήσεις αιτήσεων σε γραμμικό άξονα τιμής](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ισάξιες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες. Κάθε περίοδος έχει δέκα φορές περισσότερες αιτήσεις από την προηγούμενη, έτσι τα σημεία σχηματίζουν μια ευθεία ανερχόμενη γραμμή στην κλίμακα βάσης‑10. Οι ετικέτες του άξονα εξακολουθούν να εμφανίζουν τις αρχικές μετρήσεις αιτήσεων.

![Οι ίδιες πέντε μετρήσεις αιτήσεων στο PowerPoint σε λογαριθμικό άξονα τιμής βάσης‑10](value-axis-logarithmic.png)

### **Διαχείριση Μηδενικών και Αρνητικών Τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο απόλυτα θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Αν μηδενικές ή αρνητικές τιμές έχουν νόημα, κρατήστε μια γραμμική κλίμακα ή εμφανίστε τες χωριστά. Αν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μην αντικαθιστάτε σιωπηρά τις τιμές με μικρούς θετικούς αριθμούς, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιοδήποτε χειροκίνητα ρυθμισμένο ελάχιστο ή μέγιστο για λογαριθμικό άξονα πρέπει επίσης να είναι θετικό.

## **Συχνές Ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Χρησιμοποιήστε το [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να ορίσετε μια αριθμητική τιμή διασταύρωσης, ορίστε το [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση του άξονα σε μια κατάλληλη βάση.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημείων σε σχέση με τον άξονα;**

Ορίστε το [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για να ελέγξετε τις γραμμές σημείων καθ' αυτά, χρησιμοποιήστε το [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) ή το [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); αυτές είναι ξεχωριστές από τη θέση των ετικετών.