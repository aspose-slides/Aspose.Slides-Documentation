---
title: Προσθήκη Γραμμών Τάσης σε Διαγράμματα Παρουσίασης σε .NET
linktitle: Γραμμή Τάσης
type: docs
url: /el/net/trend-line/
keywords:
- διάγραμμα
- γραμμή τάσης
- εκθετική γραμμή τάσης
- γραμμική γραμμή τάσης
- λογαριθμική γραμμή τάσης
- γραμμή τάσης κινητού μέσου
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης δύναμης
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Προσθέστε και προσαρμόστε γρήγορα τις γραμμές τάσης σε διαγράμματα PowerPoint με το Aspose.Slides για .NET — ένας πρακτικός οδηγός για να εντυπωσιάσετε το κοινό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης σε σειρές διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσης, συμπεριλαμβανομένων των εκθετικών, γραμμικών, λογαριθμικών, κινητών μέσων, πολυωνυμικών και δύναμης.

Επίσης περιγράφει πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας ένα σχήμα γραμμής, και περιλαμβάνει μια σύντομη FAQ σχετικά με τις τιμές προώθησης και ανάστροφης προβολής της γραμμής τάσης και αν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά την απόδοση των διαγραμμάτων ως εικόνες.

## **Προσθήκη Γραμμής Τάσης**

Χρησιμοποιήστε [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) για να προσθέσετε μια γραμμή τάσης σε μια σειρά διαγράμματος, επιλέγοντας τον τύπο της με [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). Το παράδειγμα δημιουργεί ένα συγκεντρωτικό διάγραμμα στήλης με προεπιλεγμένα δεδομένα και προσθέτει δύο γραμμές τάσης σε κάθε μία από τις τρεις σειρές του.

Η εκθετική γραμμή τάσης κρύβει την εξίσωση και την τιμή R‑τετραγώνου μέσω [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) και [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), ενώ η γραμμική γραμμή τάσης είναι κόκκινη. Η λογαριθμική γραμμή τάσης χρησιμοποιεί [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) για προσαρμοσμένη ετικέτα. Το κινητό μέσο χρησιμοποιεί ένα [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) τριών σημείων δεδομένων και ένα προσαρμοσμένο [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/).

Η πολυωνυμική γραμμή τάσης έχει [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) ίσο με τρία και επεκτείνεται μία κατηγορία προς τα εμπρός μέσω [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). Η γραμμή τάσης δύναμης επεκτείνεται μία κατηγορία προς τα πίσω μέσω [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```
## **Ορισμός Σημείου Τομής Γραμμής Τάσης**

Χρησιμοποιήστε [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) για να σταθεροποιήσετε την τιμή Y μιας γραμμής τάσης στο X = 0. Αυτή η ρύθμιση υποστηρίζεται για γραμμικές, εκθετικές και πολυωνυμικές γραμμές τάσης.

Για παράδειγμα, ένα μοντέλο κόστους παραγωγής μπορεί να χρειάζεται να ξεκινά από γνωστά σταθερά κόστη 100, ακόμη και όταν οι μετρήσεις σε μη μηδενικούς όγκους παραγωγής υποδεικνύουν διαφορετική βάση. Για μια γραμμική γραμμή τάσης, η σταθεροποίηση του σημείου τομής περιορίζει την εξίσωση `y = ax + b` στο `b = 100`; η κλίση προσαρμόζεται στα δεδομένα υπό αυτήν την περιοριστική προϋπόθεση. Δεν μετακινεί απλώς μια ήδη προσαρμοσμένη γραμμή. Οι ρυθμίσεις διασταύρωσης αξόνων ελέγχουν πού συναντώνται οι άξονες του διαγράμματος, όχι τους συντελεστές της προσαρμοσμένης γραμμής τάσης.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα διασποράς (XY) με όγκους παραγωγής από 1 έως 4 και κόστη 170, 200, 230 και 260. Αποθηκεύει το διάγραμμα με το προεπιλεγμένο αυτόματο σημείο τομής, ορίζει το σημείο τομής στο 100 και αποθηκεύει ένα δεύτερο αρχείο PPTX. Τα δύο αρχεία διαφέρουν μόνο στη ρύθμιση του σημείου τομής. Η γραμμή τάσης εμφανίζει την εξίσωσή της και επεκτείνεται πίσω στο X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

Με αυτόματο υπολογισμό, αυτά τα δεδομένα παράγουν `y = 30x + 140`. Ορίζοντας το σημείο τομής στο 100 αντ' αυτού παράγει περίπου `y = 43.33x + 100`: η προσαρμοσμένη τιμή στο μηδέν ταιριάζει με τη γνωστή βάση, ενώ η γραμμή δεν περνά πλέον από κάθε σημείο δεδομένων.

| Αυτόματο σημείο τομής | Σταθερό σημείο τομής 100 |
| --- | --- |
| ![Γραμμική γραμμή τάσης με αυτόματα υπολογισμένο σημείο τομής 140](intercept-automatic.png) | ![Γραμμική γραμμή τάσης με σταθερό σημείο τομής 100](intercept-fixed.png) |

Και οι δύο εικόνες χρησιμοποιούν τα ίδια δεδομένα και κλίμακες άξονα. Οι γραμμές τάσης επεκτείνονται πίσω στο X = 0 για να εμφανίσουν τα σημεία τομής τους.

Από προεπιλογή, η ιδιότητα περιέχει `double.NaN`, που αντιπροσωπεύει ένα ακαθόριστο σημείο τομής αντί για μηδέν. Στη συνέχεια, το σημείο τομής υπολογίζεται αυτόματα από τα δεδομένα.

## **Προσθήκη Προσαρμοσμένης Γραμμής**

Μια προσαρμοσμένη γραμμή είναι ένα σχήμα σχεδιασμένο πάνω στο διάγραμμα, όχι μια γραμμή τάσης που υπολογίζεται από τα δεδομένα σειράς. Αυτό το παράδειγμα χρησιμοποιεί [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) για να προσθέσει μια οριζόντια γραμμή στη διαφάνεια πάνω από το διάγραμμα. Η θέση της γραμμής ορίζεται σε συντεταγμένες διαφάνειας, μετρημένες σε σημεία, έτσι ώστε να ξεκινά από την αριστερή άκρη του διαγράμματος και να βρίσκεται στο μέσο του διαγράμματος. Το πλάτος της ταιριάζει με το πλάτος του διαγράμματος. Το [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) δίνει στη γραμμή ένα ενιαίο κόκκινο χρώμα.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```
## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Τι σημαίνουν τα 'forward' και 'backward' για μια γραμμή τάσης;**

Αυτά είναι τα μήκη της γραμμής τάσης που προβάλλονται προς τα εμπρός/πίσω: για διαγράμματα διασποράς (XY) — σε μονάδες άξονα· για μη διαγράμματα διασποράς — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG, ή κατά την απόδοση μιας διαφάνειας σε εικόνα;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/net/convert-powerpoint-to-pdf/) ή [SVG](/slides/el/net/render-a-slide-as-an-svg-image/) και αποδίδει διαγράμματα σε εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά αυτές τις λειτουργίες. Μια μέθοδος είναι επίσης διαθέσιμη για [εξαγωγή εικόνας του διαγράμματος](/slides/el/net/create-shape-thumbnails/) του ίδιου διαγράμματος.