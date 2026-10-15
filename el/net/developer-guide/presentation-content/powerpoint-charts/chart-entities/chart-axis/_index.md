---
title: Προσαρμογή αξόνων διαγράμματος σε παρουσιάσεις στο .NET
linktitle: Άξονας διαγράμματος
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
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για .NET για να προσαρμόσετε τους άξονες διαγράμματος σε παρουσιάσεις PowerPoint για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τους άξονες των διαγραμμάτων με το Aspose.Slides για .NET. Καλύπτει τις υπολογισμένες τιμές άξονα, την εναλλαγή γραμμών και στηλών του διαγράμματος, τη ορατότητα του άξονα, τα διαστήματα ετικέτας κατηγορίας και στίγματος, τις κατηγορίες ημερομηνίας και τη μορφοποίηση, την περιστροφή του τίτλου, τη θέση του άξονα, τις μονάδες εμφάνισης και την λογαριθμική κλιμάκωση.

## **Λήψη των μέγιστων τιμών στον κάθετο άξονα των διαγραμμάτων**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) και προσθέστε ένα γράφημα περιοχής με τα προεπιλεγμένα δεδομένα. Καλέστε το [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) πριν διαβάσετε τις υπολογισμένες τιμές του άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε το [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) και το [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) για τα όρια του άξονα, και το [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) και το [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) για τα διαστήματα στίγματος. Τα [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) και [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) παρέχουν κλίμακες μονάδας χρόνου, οι οποίες είναι σχετικές με άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το γράφημα.

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

## **Ανταλλαγή των δεδομένων μεταξύ των αξόνων**

Χρησιμοποιήστε το [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα του διαγράμματος. Κάθε προηγούμενη κατηγορία γίνεται σειρά, και κάθε προηγούμενη σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κάθετους άξονες. Το παράδειγμα χρησιμοποιεί το [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) για να δεσμεύσει τα προεπιλεγμένα δεδομένα στο `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής επικεφαλίδας και της στήλης κατηγορίας, πριν από την εναλλαγή γραμμών και στηλών. Αποθηκεύει ένα γράφημα με τέσσερις σειρές και τρεις κατηγορίες.

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

## **Αντιστροφή της σειράς σχεδίασης ενός άξονα**

Χρησιμοποιήστε το [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) για να αντιστρέψετε έναν άξονα κατηγορίας ή τιμής. Για παράδειγμα, ένα οριζόντιο ραβδόγραμμα μπορεί να εμφανίζει τα στάδια ενός έργου από πάνω προς τα κάτω με την ίδια σειρά όπως στο φύλλο εργασίας: Σχεδιασμός, Ανάπτυξη, Δοκιμή. Η αντιστροφή ενός άξονα αλλάζει την κατεύθυνση σχεδίασης· δεν ταξινομεί ή αναδιοργανώνει τα δεδομένα του φύλλου. Σε σύγκριση, το [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) ανταλλάζει τους ρόλους των σειρών και των κατηγοριών.

Το παρακάτω παράδειγμα δημιουργεί ένα οριζόντιο ραβδόγραμμα με τρία στάδια και μία σειρά. Αποθηκεύει μια παρουσίαση με τρεις διαφάνειες: κανονική σειρά, αντιστρομμένες κατηγορίες και αντιστρομμένες τιμές. Κάθε αντίγραφο χρησιμοποιεί το ίδιο σύνολο δεδομένων, και μόνο ένας άξονας είναι αντιστροφημένος σε κάθε αντίγραφο.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Διαφάνεια 2: εμφανίστε την πρώτη κατηγορία στην κορυφή.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Διατηρήστε τον οριζόντιο άξονα τιμών στο κάτω μέρος.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Διαφάνεια 3: αντιστρέψτε μόνο την οριζόντια αριθμητική κλίμακα.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Η αντιστροφή ενός άξονα μπορεί επίσης να μετακινήσει τον κάθετο άξονα στην αντίθετη πλευρά του διαγράμματος. Το [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) ελέγχει πού ο άλλος άξονας διασχίζει τον άξονα που διαμορφώνεται. Στη διαφάνεια 2, ορίζοντάς το σε `Maximum` στον αντιστρομμένο άξονα κατηγορίας διατηρεί τον οριζόντιο άξονα τιμών στο κάτω μέρος. Για συγκεκριμένο σημείο διασταύρωσης, χρησιμοποιήστε το [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Ελέγξτε τις ρυθμίσεις διασταύρωσης όταν αλλάζετε κατεύθυνση, ειδικά αν το γράφημα έχει ήδη προσαρμοσμένο σημείο διασταύρωσης. Θέστε το `IsPlotOrderReversed` πάλι σε `false` για να επαναφέρετε την κανονική κατεύθυνση σχεδίασης· οι ρυθμίσεις διασταύρωσης είναι ξεχωριστές.

| Κανονική σειρά (διαφάνεια 1) | Αντεστραμμένες κατηγορίες (διαφάνεια 2) | Αντεστραμμένες τιμές (διαφάνεια 3) |
| --- | --- | --- |
| ![Γράφημα οριζόντιου ραβδού με κανονική σειρά άξονα κατηγορίας και τιμής](axis-order-normal.png) | ![Γράφημα οριζόντιου ραβδού με κατηγορίες που εμφανίζονται από πάνω προς τα κάτω](axis-order-categories-reversed.png) | ![Γράφημα οριζόντιου ραβδού με αντεστραμμένο άξονα τιμών και μηδέν στα δεξιά](axis-order-values-reversed.png) |
| Οι κατηγορίες εκτελούνται από κάτω προς τα πάνω· οι τιμές αυξάνονται από αριστερά προς δεξιά. | Ο προγραμματισμός, η ανάπτυξη και οι δοκιμές εκτελούνται από πάνω προς τα κάτω. Οι τιμές και η σειρά γραμμών του φύλλου εργασίας παραμένουν αμετάβλητες. | Οι κατηγορίες διατηρούν την κανονική τους σειρά· οι τιμές αυξάνονται από δεξιά προς αριστερά. Ο άξονας κατηγορίας διασχίζει στο μηδέν στα δεξιά. |

## **Απενεργοποίηση του κάθετου άξονα για γραφήματα γραμμής**

Ορίστε το [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) σε `false` στον κάθετο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γράφημα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κάθετο άξονα κρυμμένο.

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

## **Απενεργοποίηση του οριζόντιου άξονα για γραφήματα γραμμής**

Ορίστε το [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) σε `false` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γράφημα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυμμένο.

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

## **Αλλαγή άξονα κατηγορίας**

Ορίστε το [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) για να επιλέξετε άξονα ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα γράφημα ως το πρώτο σχήμα στην πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας του Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Ορίζοντας το [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) σε `false`, το [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) σε `1` και το [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) σε μήνες, τοποθετεί τα κύρια στίγματα σε διαστήματα ενός μήνα.

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

## **Έλεγχος διαστημάτων ετικετών άξονα κατηγορίας**

Όταν ένα γράφημα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Ορίστε το [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) σε `false`, έπειτα ορίστε το [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) στο επιθυμητό διάστημα κατηγορίας. Για κειμενικές κατηγορίες στη φυσική τους σειρά, η αρίθμηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Κατηγορία 1, Κατηγορία 2, Κατηγορία 3, ... Κατηγορία 24 |
| `2` | Κατηγορία 1, Κατηγορία 3, Κατηγορία 5, ... Κατηγορία 23 |
| `3` | Κατηγορία 1, Κατηγορία 4, Κατηγορία 7, ... Κατηγορία 22 |

Διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη διάταξη επιλέγει διάστημα βάσει του διαθέσιμου χώρου· δεν εμφανίζει απαραίτητα κάθε ετικέτα.

Τα στίγματα έχουν ξεχωριστό έλεγχο. Ορίστε το [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) σε `false` και χρησιμοποιήστε το [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) για να ορίσετε το διάστημά τους. Για παράδειγμα, `1` διατηρεί ένα στίγμα σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο σε κάθε τρίτη κατηγορία. Ορίστε το [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) σε ορατό στυλ ώστε να δείτε το αποτέλεσμα. Επαναφέροντας οποιαδήποτε αυτόματη ιδιότητα σε `true` επιτρέπει στο γράφημα να επιλέξει ξανά το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, κατόπιν αποθηκεύει τρεις διαφάνειες στο `CategoryAxisIntervals.pptx`: αυτόματη διάταξη, χειροκίνητη διάταξη ετικετών με ανεξάρτητα στίγματα, και επαναφορά στην αυτόματη διάταξη. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του γραφήματος. Δεν απαιτείται εισαγωγική παρουσίαση. Το οριζόντιο κείμενο ετικετών καθιστά εύκολο τον οπτικό διαχωρισμό της πυκνότητας.

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

// Διαφάνεια 2: εμφανίστε κάθε τρίτη ετικέτα, αλλά διατηρήστε ένα στίγμα για κάθε κατηγορία.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Διαφάνεια 3: επιτρέψτε στο γράφημα να επιλέξει ξανά και τα δύο διαστήματα.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Αυτόματη διάταξη (διαφάνεια 1):** Σε αυτή την αναπαράσταση, εμφανίζεται κάθε δεύτερη ετικέτα κατηγορίας και τυλίγεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και τον renderer.

![Αυτόματη διευθέτηση ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητη διάταξη (διαφάνεια 2):** Εμφανίζεται κάθε τρίτη ετικέτα σε μία γραμμή, ενώ τα στίγματα παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων των χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται πιο πάνω.

![Χειροκίνητο διάστημα ετικετών κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλογή του σωστού άξονα και διαστήματος**

Χρησιμοποιήστε αυτό το διάστημα μετρήσεων κατηγορίας για άξονα κειμένου, όπως ο άξονας κατηγορίας ενός ραβδογράμματος, γραμμικού, περιοχής ή ραβδού. Σε ραβδόγραμμα, είναι ο οριζόντιος άξονας. Σε οριζόντιο ραβδόγραμμα, ο άξονας κατηγορίας είναι κάθετος, επομένως εφαρμόστε αυτές τις ρυθμίσεις στο [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Η διάταξη στίγματος ισχύει επίσης για άξονα σειράς σε διαγράμματα που τον διαθέτουν.

Μην χρησιμοποιείτε τη διάταξη ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμών. Σε άξονα τιμών, το [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) ορίζει τη διαφορά μεταξύ τιμών: π.χ., κύρια μονάδα `10` παράγει στίγματα στα 0, 10, 20 κ.λπ. όταν ο άξονας ξεκινά από το μηδέν. Διάστημα ετικέτας κατηγορίας `3` μετράει θέσεις κατηγορίας, ανεξάρτητα από τις τιμές τους. Διαγράμματα διασποράς και φυσαλίδων χρησιμοποιούν άξονες τιμών αντί για άξονα κειμένου. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες και κλίμακες χρόνου όπως περιγράφεται στην [Αλλαγή άξονα κατηγορίας](#change-a-category-axis).

## **Ορισμός μορφής ημερομηνίας για τιμές άξονα κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα του διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`). Ορίστε το [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) σε άξονα ημερομηνίας, απενεργοποιήστε το [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) και αντιστοιχίστε `yyyy` στο [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) ώστε οι ετικέτες κατηγορίας να εμφανίζουν τέσσερα ψηφία έτους ανεξάρτητα από τη μορφή του κελιού.

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

## **Ορισμός γωνίας περιστροφής για τίτλο άξονα διαγράμματος**

Ενεργοποιήστε το [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) στον κάθετο άξονα, παρέχετε κείμενο τίτλου και ορίστε το [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα ραβδογράφημα με τον τίτλο του άξονα τιμών περιστραμμένο κατά 90 μοίρες.

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

## **Ορισμός θέσης άξονα σε άξονα κατηγορίας ή τιμής**

Χρησιμοποιήστε το [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) για να ελέγξετε εάν ο άξονας τιμών διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα στίγματα κατηγορίας. Η ιδιότητα αυτή ισχύει για άξονες κατηγορίας. Το παράδειγμα την ορίζει σε `true` στον οριζόντιο άξονα κατηγορίας ενός ραβδογράμματος και αποθηκεύει το αποτέλεσμα.

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

## **Ορισμός μονάδας εμφάνισης σε άξονα τιμών διαγράμματος**

Ορίστε το [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) για να κλιμακώσετε τις ετικέτες ενός άξονα τιμών χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) ορισμένο σε `Millions`, μια τιμή 60 000 000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα ραβδογράφημα και εφαρμόζει τη μονάδα εκατομμυρίων στον κάθετο άξονα.

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

## **Διαμόρφωση λογαριθμικού άξονα τιμών**

Ένας λογαριθμικός άξονας τιμών είναι χρήσιμος όταν οι θετικές τιμές καλύπτουν πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1 000, 10 000 και 100 000 αιτήματα σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται πολύ κοντά μεταξύ τους κοντά στο μηδέν. Μια λογαριθμική κλίμακα κάνει την σχετική αύξηση πιο εύκολη στην σύγκριση: ίσες αποστάσεις αντιπροσωπεύουν ίσους λόγους αντί για ίσες διαφορές.

Ορίστε το [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) σε `true` στον άξονα τιμών και χρησιμοποιήστε το [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υπαρχουσών τιμών· δεν αλλάζει τα δεδομένα ή προσθέτει λογαριθμική ευθεία τάσης. Μια ευθεία τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστό χαρακτηριστικό.

### **Επιλογή του άξονα τιμών και της βάσης**

Για γραμμικό ή ραβδόγραμμα, ο άξονας τιμών είναι το [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Για οριζόντιο ραβδόγραμμα, είναι το [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Τα διαγράμματα διασποράς και φυσαλίδων έχουν δύο άξονες τιμών, οπότε επιλέξτε τον οριζόντιο άξονα για τις τιμές X, τον κάθετο για τις τιμές Y, ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για PPTX διαγράμματα, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένου· υποστηρίζονται επίσης δεκαδικές βάσεις όπως `2.5`. Με βάση `10`, οι διαδοχικές δυνάμεις όπως 10, 100, 1 000 και 10 000 είναι εξ ισόποστα.

### **Σύγκριση γραμμικής και λογαριθμικής κλιμάκωσης**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γράφημα γραμμής με τις πέντε μετρήσεις αιτήσεων στην πρώτη διαφάνεια, κατόπιν κλωνοποιεί τη διαφάνεια και ενεργοποιεί λογαριθμικό άξονα τιμών βάσης‑10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

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

// Διατηρήστε την πρώτη διαφάνεια γραμμική και αλλάξτε μόνο τη κλίμακα του άξονα τιμών του αντιγράφου.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Γραμμική κλίμακα (διαφάνεια 1):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτήσεων. Η μεγαλύτερη τιμή κυριαρχεί στο γράφημα, καθιστώντας τις μικρότερες τιμές δύσκολες στην διάκριση.

![Διάγραμμα γραμμής στο PowerPoint που δείχνει πέντε αριθμούς αιτήσεων σε γραμμικό άξονα τιμών](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσους λόγους. Κάθε περίοδος έχει δέκα φορές περισσότερα αιτήματα από την προηγούμενη, έτσι τα σημεία σχηματίζουν ευθεία άνοδο στη βάση‑10 κλίμακα. Οι ετικέτες του άξονα εξακολουθούν να δείχνουν τις αρχικές μετρήσεις.

![Οι ίδιες πέντε αριθμοί αιτήσεων στο PowerPoint σε λογαριθμικό άξονα τιμών βάσης 10](value-axis-logarithmic.png)

### **Διαχείριση μηδενικών και αρνητικών τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Αν μηδενικές ή αρνητικές τιμές έχουν νόημα, διατηρήστε τη γραμμική κλίμακα ή εμφανίστε τις ξεχωριστά. Αν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μην τις αντικαθιστάτε σιωπηρά με μικρές θετικές τιμές, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιοδήποτε χειροκίνητα ρυθμισμένο ελάχιστο ή μέγιστο για λογαριθμικό άξονα πρέπει επίσης να είναι θετικό.

## **Συχνές ερωτήσεις**

**Πώς ορίζω την τιμή όπου ένας άξονας διασχίζει τον άλλο (διαστροφή άξονα);**

Χρησιμοποιήστε το [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να ορίσετε αριθμητική τιμή διασταύρωσης, ορίστε το [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση του άξονα σε μια κατάλληλη βάση.

**Πώς μπορώ να τοποθετήσω τις ετικέτες στίγματος σε σχέση με τον άξονα;**

Ορίστε το [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για να ελέγξετε τα ίδια τα στίγματα, χρησιμοποιήστε το [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) ή το [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); αυτά είναι ξεχωριστά από τη θέση των ετικετών.