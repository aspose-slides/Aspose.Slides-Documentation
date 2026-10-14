---
title: Προσαρμογή διαγραμμάτων πίτας σε παρουσιάσεις σε .NET
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/net/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές απεικόνισης
- χρώμα φέτας
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα πίτας σε .NET με Aspose.Slides. Διαμορφώστε δευτερεύουσες απεικονίσεις, εμφανίστε ετικέτες δεδομένων και εφαρμόστε αυτόματο χρώμα φετών σε PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με διαγράμματα πίτας στο Aspose.Slides. Δείχνει πώς να διαμορφώσετε τις επιλογές δευτερεύουσας απεικόνισης για τα διαγράμματα Pie of Pie και Bar of Pie, καθώς και πώς να ενεργοποιήσετε τον αυτόματο χρωματισμό των φετών για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα επικεντρώνονται σε εργασίες προσαρμογής διαγράμματος, όπως η προσθήκη διαγράμματος σε μια διαφάνεια, η προσαρμογή των ρυθμίσεων σειράς και ετικέτας, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Δεύτερες Επιλογές Απεικόνισης για Διαγράμματα Pie of Pie και Bar of Pie**

Το Aspose.Slides for .NET υποστηρίζει επιλογές δευτερεύουσας απεικόνισης για διαγράμματα Pie of Pie και Bar of Pie. Αυτές οι επιλογές ελέγχουν το μέγεθος της δευτερεύουσας απεικόνισης και πώς τα σημεία δεδομένων διαχωρίζονται μεταξύ των δύο απεικονίσεων.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα Pie of Pie σε νέα παρουσίαση και εμφανίζει τις τιμές των σημείων δεδομένων ως ετικέτες. Η ιδιότητα [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) ορίζει το μέγεθος της δευτερεύουσας απεικόνισης στο 149 % της κύριας. Η [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) επιλέγει διαχωρισμό βάσει ποσοστών, και η [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) ορίζει το κατώφλι στο 53 %.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Επιλέξτε Κατηγορίες για τη Δευτερεύουσα Απεικόνιση**

Χρησιμοποιήστε προσαρμοσμένο διαχωρισμό όταν θέλετε να ομαδοποιήσετε συγκεκριμένες κατηγορίες στη δευτερεύουσα απεικόνιση ανεξάρτητα από τις ποσοστιαίες τους τιμές. Για παράδειγμα, μια αναφορά πωλήσεων μπορεί να εμφανίζει τα Online και Events μαζί ώστε οι αναγνώστες να μπορούν να συγκρίνουν αυτά τα δύο κανάλια, ακόμη και αν αντιπροσωπεύουν το 35 % και το 10 % των συνολικών πωλήσεων.

Ορίστε τη [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) σε [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) και επιλέξτε τα σημεία μέσω της [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). Η μέθοδος [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) της συλλογής δέχεται είτε έναν μηδενικό δείκτη στη σειρά είτε ένα αντικείμενο σημείου δεδομένων. Σε αυτό το παράδειγμα, ο δείκτης 1 επιλέγει Online και το σημείο στη θέση 3 επιλέγει Events. Η Partners προστίθεται προσωρινά, στη συνέχεια αποκλείεται με τη μέθοδο [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Αντικαταστήστε τα προεπιλεγμένα δεδομένα με τις πωλήσεις ανά κανάλι.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Επιλέξτε το Online με τον μηδενικό δείκτη του και το Events με το αντικείμενο σημείου δεδομένων.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Εξαίρετε το Partners από την επιλογή χωρίς να διαγράψετε τα προερχόμενα δεδομένα του.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) και Events (10) εμφανίζονται ως ξεχωριστές φέτες στη δευτερεύουσα απεικόνιση. Στην κύρια απεικόνιση, αντιπροσωπεύονται από μία ενωμένη φέτα με τιμή 45, μαζί με Retail (40) και Partners (15). Η αφαίρεση των Partners από την προσαρμοσμένη επιλογή τα διατηρεί στην κύρια απεικόνιση· δεν αφαιρεί την κατηγορία ή την τιμή της από τα δεδομένα προέλευσης του διαγράμματος.

Η παρακάτω εικόνα δείχνει την αποθηκευμένη παρουσίαση στο PowerPoint:

![Διάγραμμα Pie of Pie με Online και Events στη δευτερεύουσα απεικόνιση και τη συνδυασμένη τους τιμή 45 στην κύρια απεικόνιση](pie_of_pie_custom.png)

## **Ορίστε Αυτόματους Χρωματισμούς Φετών Διαγράμματος Πίτας**

Το Aspose.Slides for .NET μπορεί αυτόματα να αναθέσει διαφορετικά χρώματα στις φέτες ενός διαγράμματος πίτας. Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα πίτας με κεντραρισμένο τίτλο και αντικαθιστά τα προεπιλεγμένα δεδομένα με τρεις τριμηνιαίες κατηγορίες και τις τιμές τους. Η ιδιότητα [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) εμφανίζει τις τιμές 20, 50 και 30 ως ετικέτες, ενώ η [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) ενεργοποιεί διαφορετικό χρώμα για κάθε φέτα.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Προσθέστε έναν κεντραρισμένο τίτλο διαγράμματος.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Αντικαταστήστε τα προεπιλεγμένα δεδομένα χρησιμοποιώντας το πρώτο φύλλο εργασίας.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Εμφανίστε τις τιμές και εκχωρήστε διαφορετικά χρώματα στις φέτες.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζονται οι παραλλαγές Pie of Pie και Bar of Pie;**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) μια δευτερεύουσα απεικόνιση για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων Pie of Pie και Bar of Pie.

**Μπορώ να εξαγωθώ μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξαγωγή του διαγράμματος ως εικόνα](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (π.χ. PNG) χωρίς να εξάγετε ολόκληρη την παρουσίαση.