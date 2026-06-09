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
description: "Προσθέστε και προσαρμόστε γρήγορα γραμμές τάσης σε διαγράμματα PowerPoint με Aspose.Slides για .NET — ένας πρακτικός οδηγός για να εντυπωσιάσετε το κοινό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης σε σειρές διαγράμματος και να εργαστείτε με πολλούς τύπους γραμμών τάσης, όπως εκθετικές, γραμμικές, λογαριθμικές, κινητό μέσο, πολυωνυμικές και δύναμη.

Περιγράφει επίσης πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας σχήμα γραμμής, και περιλαμβάνει μια σύντομη Συχνές Ερωτήσεις σχετικά με τις τιμές προβολής των γραμμών τάσης «forward» και «backward» καθώς και αν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά την απόδοση των διαγραμμάτων ως εικόνες.

## **Προσθήκη Γραμμής Τάσης**
Aspose.Slides for .NET παρέχει ένα απλό API για διαχείριση διαφορετικών Γραμμών Τάσης σε διαγράμματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας με το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και έναν από τους επιθυμητούς τύπους (σε αυτό το παράδειγμα χρησιμοποιείται ChartType.ClusteredColumn).
1. Προσθήκη εκθετικής γραμμής τάσης στη σειρά 1 του διαγράμματος.
1. Προσθήκη γραμμικής γραμμής τάσης στη σειρά 1 του διαγράμματος.
1. Προσθήκη λογαριθμικής γραμμής τάσης στη σειρά 2 του διαγράμματος.
1. Προσθήκη γραμμής τάσης κινητού μέσου στη σειρά 2 του διαγράμματος.
1. Προσθήκη πολυωνυμικής γραμμής τάσης στη σειρά 3 του διαγράμματος.
1. Προσθήκη γραμμής τάσης δύναμης στη σειρά 3 του διαγράμματος.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Ο ακόλουθος κώδικας χρησιμοποιείται για τη δημιουργία ενός διαγράμματος με Γραμμές Τάσης.

```c#
// Δημιουργία κενής παρουσίασης
Presentation pres = new Presentation();

// Δημιουργία διαγράμματος συγκεντρωμένων στηλών
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Προσθήκη εκθετικής γραμμής τάσης για τη σειρά 1 του διαγράμματος
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Προσθήκη γραμμικής γραμμής τάσης για τη σειρά 1 του διαγράμματος
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Προσθήκη λογαριθμικής γραμμής τάσης για τη σειρά 2 του διαγράμματος
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Προσθήκη γραμμής τάσης κινητού μέσου για τη σειρά 2 του διαγράμματος
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Προσθήκη πολυωνυμικής γραμμής τάσης για τη σειρά 3 του διαγράμματος
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Προσθήκη γραμμής τάσης δύναμης για τη σειρά 3 του διαγράμματος
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Αποθήκευση παρουσίασης
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Προσαρμοσμένης Γραμμής**
Aspose.Slides for .NET παρέχει ένα απλό API για την προσθήκη προσαρμοσμένων γραμμών σε διάγραμμα. Για να προσθέσετε μια απλή απλή γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης Presentation
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της
- Δημιουργήστε ένα νέο διάγραμμα χρησιμοποιώντας τη μέθοδο AddChart που εκτίθεται από το αντικείμενο Shapes
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο AddAutoShape που εκτίθεται από το αντικείμενο Shapes
- Ορίστε το χρώμα των γραμμών του σχήματος.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX

Ο ακόλουθος κώδικας χρησιμοποιείται για τη δημιουργία ενός διαγράμματος με Προσαρμοσμένες Γραμμές.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Τι σημαίνουν τα 'forward' και 'backward' για μια γραμμή τάσης;**

Αυτά είναι τα μήκη της γραμμής τάσης που προβάλλονται προς τα εμπρός/προσωπικά: για διαγράμματα διασποράς (XY) — σε μονάδες άξονα· για μη-διαγράμματα διασποράς — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG, ή κατά την απόδοση μιας διαφάνειας σε εικόνα;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/net/convert-powerpoint-to-pdf/)/[SVG](/slides/el/net/render-a-slide-as-an-svg-image/) και αποδίδει τα διαγράμματα σε εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά τη διάρκεια αυτών των λειτουργιών. Διατίθεται επίσης μέθοδος για την [εξαγωγή εικόνας του διαγράμματος](/slides/el/net/create-shape-thumbnails/) ίδιας.