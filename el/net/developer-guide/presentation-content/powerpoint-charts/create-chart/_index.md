---
title: Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσιάσεων PowerPoint σε .NET
linktitle: Δημιουργία ή Ενημέρωση Διαγραμμάτων
type: docs
weight: 10
url: /el/net/create-chart/
keywords:
- προσθήκη διαγράμματος
- δημιουργία διαγράμματος
- επεξεργασία διαγράμματος
- αλλαγή διαγράμματος
- ενημέρωση διαγράμματος
- διάγραμμα διασποράς
- διάγραμμα πίτας
- γραμμικό διάγραμμα
- διάγραμμα χάρτη δένδρου
- διάγραμμα μετοχών
- διάγραμμα κουτιού και χορδής
- διάγραμμα χωνιού
- διάγραμμα ηλιοστασίου
- ιστογραμματικό διάγραμμα
- διάγραμμα ραδίου
- πολύκατηγορικό διάγραμμα
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για .NET. Προσθέστε, μορφοποιήστε και επεξεργαστείτε διαγράμματα με πρακτικά παραδείγματα κώδικα σε C#."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργήσετε και να προσαρμόσετε διαγράμματα χρησιμοποιώντας το Aspose.Slides για .NET. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει με τις συγκεκριμένες απαιτήσεις σχεδιασμού σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα απεικονίζουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου διαγράμματος έως τη ρύθμιση σειρών, αξόνων και υπομνήματος. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε μια στέρεη κατανόηση του πώς να ενσωματώσετε δυναμική δημιουργία διαγραμμάτων στις εφαρμογές .NET, απλοποιώντας τη διαδικασία δημιουργίας παρουσιάσεων βασισμένων σε δεδομένα.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους χρήστες να οπτικοποιούν γρήγορα τα δεδομένα και να αποκομίζουν πληροφορίες που μπορεί να μην είναι άμεσα εμφανείς από έναν πίνακα ή λογιστικό φύλλο.

**Γιατί να δημιουργείτε διαγράμματα;**

Με τα διαγράμματα, μπορείτε:

* να συγκεντρώνετε, συμπτύσσετε ή συνοψίζετε μεγάλες ποσότητες δεδομένων σε μία διαφάνεια της παρουσίασης·
* να αποκαλύπτετε μοτίβα και τάσεις στα δεδομένα·
* να κατανοείτε την κατεύθυνση και την ορμή των δεδομένων με το πέρασμα του χρόνου ή σε σχέση με μια συγκεκριμένη μονάδα μέτρησης·
* να εντοπίζετε αποκλίσεις, ανωμαλίες, σφάλματα και ακατανόητα δεδομένα·
* να επικοινωνείτε ή να παρουσιάζετε σύνθετα δεδομένα.

Στο PowerPoint, μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας *Insert*, η οποία προσφέρει πρότυπα για το σχεδιασμό πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά διαγράμματα (βασισμένα σε δημοφιλείς τύπους) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="primary" %}} 
Χρησιμοποιήστε την απαρίθμηση [ChartType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/charttype/) στο χώρο ονομάτων [Aspose.Slides.Charts](https://reference.aspose.com/slides/el/net/aspose.slides.charts/). Οι τιμές σε αυτήν την απαρίθμηση αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.
{{% /alert %}} 

### **Δημιουργία Συγκροτημένων Στήλης Διαγραμμάτων**

Αυτή η ενότητα εξηγεί πώς να δημιουργήσετε συγκροτημένα στήλης διαγράμματα χρησιμοποιώντας το Aspose.Slides για .NET. Θα μάθετε να αρχικοποιείτε μια παρουσίαση, να προσθέτετε ένα διάγραμμα και να προσαρμόζετε τα στοιχεία του, όπως τίτλο, δεδομένα, σειρά, κατηγορίες και στυλ. Ακολουθήστε τα παρακάτω βήματα για να δείτε πώς δημιουργείται ένα τυπικό συγκροτημένο στήλης διάγραμμα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.ClusteredColumn`.
1. Προσθέστε έναν τίτλο στο διάγραμμα.
1. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
1. Καθαρίστε όλες τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
1. Εφαρμόστε χρώμα γεμίσματος στις σειρές του διαγράμματος.
1. Προσθέστε ετικέτες στις σειρές του διαγράμματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα συγκροτημένο στήλης διάγραμμα:

```c#
// Δημιουργία αντικειμένου Presentation.
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη συγκροτημένου διαγράμματος στήλης με τα προεπιλεγμένα δεδομένα.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Ορισμός τίτλου διαγράμματος.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Ορισμός πρώτης σειράς να εμφανίζει τιμές.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Ορισμός δείκτη φύλλου δεδομένων διαγράμματος.
    int worksheetIndex = 0;

    // Λήψη βιβλίου δεδομένων διαγράμματος.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Διαγραφή προεπιλεγμένων σειρών και κατηγοριών.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Προσθήκη νέων σειρών.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Προσθήκη νέων κατηγοριών.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Λήψη πρώτης σειράς διαγράμματος.
    IChartSeries series = chart.ChartData.Series[0];

    // Γέμισμα δεδομένων σειράς.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Ορισμός χρώματος γεμίσματος για τη σειρά.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Λήψη δεύτερης σειράς διαγράμματος.
    series = chart.ChartData.Series[1];

    // Γέμισμα δεδομένων σειράς.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Ορισμός χρώματος γεμίσματος για τη σειρά.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Ορισμός πρώτης ετικέτας να δείχνει το όνομα κατηγορίας.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Ορισμός σειράς να δείχνει την τιμή για την τρίτη ετικέτα.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Αποθήκευση παρουσίασης σε αρχείο PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το γράφημα Συγκροτημένων Στηλών](clustered_column_chart.png)

### **Δημιουργία Διαγραμμάτων Διάσπασης**

Τα διαγράμματα διάσπασης (γνωστά επίσης ως scatter plots ή x‑y διαγράμματα) χρησιμοποιούνται συχνά για την ανίχνευση μοτίβων ή την εμφάνιση συσχετίσεων μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε διάγραμμα διάσπασης όταν:

* Διαθέτετε ζεύγη αριθμητικών δεδομένων·
* Έχετε δύο μεταβλητές που ταιριάζουν μεταξύ τους·
* Θέλετε να καθορίσετε αν οι δύο μεταβλητές σχετίζονται·
* Έχετε μια ανεξάρτητη μεταβλητή που έχει πολλές τιμές για μια εξαρτημένη μεταβλητή.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα διάσπασης με διαφορετική σειρά δεικτών:

```c#
// Δημιουργία αντικειμένου Presentation.
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Δημιουργία προεπιλεγμένου διαγράμματος διασποράς.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Ορισμός δείκτη φύλλου δεδομένων διαγράμματος.
    int worksheetIndex = 0;

    // Λήψη βιβλίου δεδομένων διαγράμματος.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Διαγραφή της προεπιλεγμένης σειράς.
    chart.ChartData.Series.Clear();

    // Προσθήκη νέων σειρών.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Λήψη της πρώτης σειράς διαγράμματος.
    IChartSeries series = chart.ChartData.Series[0];

    // Προσθήκη νέου σημείου (1:3) στη σειρά.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Προσθήκη νέου σημείου (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Αλλαγή τύπου σειράς.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Αλλαγή δείκτη σειράς διαγράμματος.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // Λήψη της δεύτερης σειράς διαγράμματος.
    series = chart.ChartData.Series[1];

    // Προσθήκη νέου σημείου (5:2) στη σειρά διαγράμματος.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Προσθήκη νέου σημείου (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Προσθήκη νέου σημείου (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Προσθήκη νέου σημείου (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Αλλαγή δείκτη σειράς διαγράμματος.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Αποθήκευση παρουσίασης σε αρχείο PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διάγραμμα Διάσπασης](scatter_chart.png)

### **Δημιουργία Κυκλικών Διαγραμμάτων**

Τα κυκλικά διαγράμματα είναι ιδανικά για την εμφάνιση της σχέσης μέρος‑συνολικό σε δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγορηματικές ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιέχουν πολλά τμήματα ή ετικέτες, ίσως θελήσετε να εξετάσετε τη χρήση ράβδου διαγράμματος.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.Pie`.
1. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
1. Προσθέστε νέους σημείους στο διάγραμμα και εφαρμόστε προσαρμοσμένα χρώματα στους τομείς του κυκλικού διαγράμματος.
1. Ορίστε ετικέτες για τις σειρές.
1. Ενεργοποιήστε τις γραμμές οδηγούς για τις ετικέτες των σειρών.
1. Ορίστε τη γωνία περιστροφής του κυκλικού διαγράμματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα κυκλικό διάγραμμα:

```c#
// Δημιουργία αντικειμένου Presentation.
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη διαγράμματος με τα προεπιλεγμένα δεδομένα.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Ορισμός τίτλου διαγράμματος.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Ορισμός πρώτης σειράς να εμφανίζει τιμές.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Ορισμός δείκτη φύλλου δεδομένων διαγράμματος.
    int worksheetIndex = 0;

    // Λήψη βιβλίου δεδομένων διαγράμματος.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Διαγραφή των προεπιλεγμένων δημιουργηθέντων σειρών και κατηγοριών.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Προσθήκη νέων κατηγοριών.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Προσθήκη νέων σειρών.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Γέμισμα δεδομένων σειράς.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Ορισμός χρώματος τμήματος.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Ορισμός περιγράμματος τμήματος.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Ορισμός περιγράμματος τμήματος.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Ορισμός περιγράμματος τμήματος.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Δημιουργία προσαρμοσμένων ετικετών για κάθε κατηγορία στη νέα σειρά.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // Ορισμός σειράς να δείχνει γραμμές οδηγό στο διάγραμμα.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Ορισμός γωνίας περιστροφής για τα τμήματα του κυκλικού διαγράμματος.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Αποθήκευση παρουσίασης σε αρχείο PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το κυκλικό διάγραμμα](pie_chart.png)

### **Δημιουργία Γραμμικών Διαγραμμάτων**

Τα γραμμικά διαγράμματα (γνωστά επίσης ως line graphs) είναι κατάλληλα για καταστάσεις όπου θέλετε να επιδείξετε αλλαγές στην τιμή με την πάροδο του χρόνου. Με ένα γραμμικό διάγραμμα, μπορείτε να συγκρίνετε μεγάλο όγκο δεδομένων ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις στον χρόνο, να επισημαίνετε ανωμαλίες σε σειρές δεδομένων και πολλά άλλα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.Line`.
1. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα γραμμικό διάγραμμα:

```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Από προεπιλογή, τα σημεία σε ένα γραμμικό διάγραμμα ενώνονται με συνεχείς ευθείες γραμμές. Εάν θέλετε τα σημεία να ενώνονται με παύλες, μπορείτε να ορίσετε τον προτιμώμενο τύπο παύλας ως εξής:

```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Το αποτέλεσμα:

![Το γραμμικό διάγραμμα](line_chart.png)

### **Δημιουργία Διαγραμμάτων Δένδρων (Tree Map)**

Τα διαγράμματα δένδρων είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να εμφανίσετε το σχετικό μέγεθος των κατηγοριών δεδομένων και να εστιάσετε γρήγορα σε στοιχεία που προσφέρουν σημαντική συμβολή εντός κάθε κατηγορίας.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.Treemap`.
1. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα δένδρου:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Κλάδος 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Κλάδος 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διάγραμμα Δένδρου](treemap_chart.png)

### **Δημιουργία Διαγραμμάτων Αποθεμάτων (Stock Charts)**

Τα διαγράμματα αποθεμάτων χρησιμοποιούνται για την απεικόνιση χρηματικών δεδομένων όπως τιμές ανοίγματος, υψηλής, χαμηλής και κλεισίματος, βοηθώντας στην ανάλυση τάσεων της αγοράς και της μεταβλητότητας. Παρέχουν κρίσιμες πληροφορίες για την απόδοση των μετοχών, υποστηρίζοντας επενδυτές και αναλυτές στη λήψη τεκμηριωμένων αποφάσεων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.OpenHighLowClose`.
1. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
1. Ορίστε τη μορφή HiLowLines.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα αποθεμάτων:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διάγραμμα Αποθεμάτων](stock_chart.png)

### **Δημιουργία Διαγραμμάτων Box and Whisker**

Τα διαγράμματα Box and Whisker χρησιμοποιούνται για την εμφάνιση της κατανομής των δεδομένων συνοψίζοντας βασικά στατιστικά μέτρα, όπως η διάμεσος, τα τεταρτημόρια και οι πιθανοί εξαιρετικοί τιμές. Είναι ιδιαίτερα χρήσιμα στην εξερευνητική ανάλυση δεδομένων και στις στατιστικές μελέτες για την γρήγορη κατανόηση της διακύμανσης των δεδομένων και την αναγνώριση τυχόν ανωμαλιών.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.BoxAndWhisker`.
1. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα Box and Whisker:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **Δημιουργία Διάγραμμα Σχεδίου Πυραμίδας (Funnel Charts)**

Τα διαγράμματα πυραμίδας χρησιμοποιούνται για την οπτικοποίηση διαδικασιών που περιλαμβάνουν διαδοχικά στάδια, όπου ο όγκος των δεδομένων μειώνεται καθώς προχωρά από το ένα βήμα στο επόμενο. Είναι ιδιαίτερα χρήσιμα για την ανάλυση ποσοστών μετατροπής, την αναγνώριση bottleneck και την παρακολούθηση της αποτελεσματικότητας των διαδικασιών πωλήσεων ή μάρκετινγκ.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.Funnel`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα πυραμίδας:

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διάγραμμα Πυραμίδας](funnel_chart.png)

### **Δημιουργία Διάγραμμα Ηλιοστασιακού (Sunburst Charts)**

Τα διαγράμματα ηλιοστασίου χρησιμοποιούνται για την οπτικοποίηση ιεραρχικών δεδομένων, παρουσιάζοντας τα επίπεδα ως συγκρότημα δακτυλίων. Βοηθούν στην απεικόνιση σχέσεων μέρος‑συνολικό και είναι ιδανικά για την αναπαράσταση ενσωματωμένων κατηγοριών και υποκατηγοριών με σαφή, συμπαγή μορφή.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.Sunburst`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα ηλιοστασίου:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Κλάδος 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Κλάδος 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διάγραμμα Ηλιοστασίου](sunburst_chart.png)

### **Δημιουργία Ιστογραμματικών Διαγραμμάτων (Histogram Charts)**

Τα ιστογραμματικά διαγράμματα χρησιμοποιούνται για την αναπαράσταση της κατανομής αριθμητικών δεδομένων ομαδοποιώντας τιμές σε εύρη ή κάδους. Είναι ιδιαίτερα χρήσιμα για την ταυτοποίηση μοτίβων όπως συχνότητα, ασυμμετρία και εύρος, καθώς και για τον εντοπισμό αποκλίσεων σε σύνολο δεδομένων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.Histogram`.
1. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα ιστογραμματικό διάγραμμα:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το Ιστογραμματικό διάγραμμα](histogram_chart.png)

### **Δημιουργία Διαγραμμάτων Ραδίου (Radar Charts)**

Τα διαγράμματα ραδίου χρησιμοποιούνται για την προβολή πολυμεταβλητών δεδομένων σε δισδιάστατη μορφή, επιτρέποντας εύκολη σύγκριση πολλών μεταβλητών ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα για την αναγνώριση μοτίβων, δυνατών και αδύναμων σημείων σε πολλαπλές μετρικές απόδοσης ή χαρακτηριστικά.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.Radar`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα ραδίου:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διάγραμμα Ραδίου](radar_chart.png)

### **Δημιουργία Πολυκατηγορικών Διαγραμμάτων (Multi-Category Charts)**

Τα πολυκατηγορικά διαγράμματα χρησιμοποιούνται για την εμφάνιση δεδομένων που περιλαμβάνουν περισσότερες από μία κατηγορίες, επιτρέποντας σύγκριση τιμών σε πολλαπλές διαστάσεις ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα όταν χρειάζεται να αναλύσετε τάσεις και σχέσεις μέσα σε σύνθετα, πολυεπίπεδα σύνολα δεδομένων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.ClusteredColumn`.
1. Πρόσβαση στο βιβλίο δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα πολυκατηγορικό διάγραμμα:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // Προσθήκη σειράς.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Αποθήκευση της παρουσίασης με το διάγραμμα.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το πολυκατηγορικό διάγραμμα](multi_category_chart.png)

### **Δημιουργία Χάρτη (Map Charts)**

Τα διαγράμματα χάρτη χρησιμοποιούνται για την οπτικοποίηση γεωγραφικών δεδομένων με χαρτογράφηση πληροφοριών σε συγκεκριμένες τοποθεσίες όπως χώρες, πολιτείες ή πόλεις. Είναι ιδιαίτερα χρήσιμα για την ανάλυση περιφερειακών τάσεων, δημογραφικών δεδομένων και χωρικών κατανομών με καθαρό, οπτικά ελκυστικό τρόπο.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα χάρτη:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διάγραμμα Χάρτη](map_chart.png)

### **Δημιουργία Συνδυαστικών Διαγραμμάτων (Combination Charts)**

Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγράμματος σε ένα μόνο γράφημα. Αυτό το διάγραμμα σας επιτρέπει να τονίσετε, να συγκρίνετε ή να εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.

![Το συνδυαστικό διάγραμμα](combination_chart.png)

Ο παρακάτω κώδικας C# δείχνει πώς να δημιουργήσετε το συνδυαστικό διάγραμμα που φαίνεται παραπάνω σε μια παρουσίαση PowerPoint:

```c#
private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Ορίζει τον τίτλο του διαγράμματος
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Ορίζει το υπόμνημα του διαγράμματος
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // Διαγράφει τις προεπιλεγμένες δημιουργημένες σειρές και κατηγορίες
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Προσθέτει νέες κατηγορίες
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // Προσθήκη της πρώτης σειράς
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // Ορίζει τον οριζόντιο άξονα
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Ορίζει τον κατακόρυφο άξονα
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Ορίζει το χρώμα των κύριων γραμμών πλέγματος του κατακόρυφου άξονα
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // Ορίζει τον δευτερεύοντα οριζόντιο άξονα
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // Ορίζει τον δευτερεύοντα κατακόρυφο άξονα
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Ενημέρωση Διαγραμμάτων**

Το Aspose.Slides για .NET σας επιτρέπει να ενημερώνετε διαγράμματα PowerPoint τροποποιώντας τα δεδομένα, τη μορφοποίηση και το στυλ τους. Αυτή η δυνατότητα απλοποιεί τη διαδικασία διατήρησης των παρουσιάσεων ενημερωμένων με δυναμικό περιεχόμενο και εξασφαλίζει ότι τα διαγράμματα αντανακλούν ακριβώς τα τρέχοντα δεδομένα και τις οπτικές προδιαγραφές.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα.
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Περπατήστε σε όλα τα σχήματα για να εντοπίσετε το διάγραμμα.
1. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
1. Τροποποιήστε τις σειρές δεδομένων του διαγράμματος αλλάζοντας τις τιμές των σειρών.
1. Προσθέστε μια νέα σειρά και συμπληρώστε τα δεδομένα της.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να ενημερώσετε ένα διάγραμμα:

```c#
const string chartName = "My chart";

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Ορισμός του δείκτη του φύλλου δεδομένων διαγράμματος.
            int worksheetIndex = 0;

            // Λήψη του βιβλίου δεδομένων του διαγράμματος.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Αλλαγή των ονομάτων των κατηγοριών του διαγράμματος.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Λήψη της πρώτης σειράς του διαγράμματος.
            IChartSeries series = chart.ChartData.Series[0];

            // Ενημέρωση των δεδομένων της σειράς.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Τροποποίηση του ονόματος της σειράς.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Λήψη της δεύτερης σειράς του διαγράμματος.
            series = chart.ChartData.Series[1];

            // Ενημέρωση των δεδομένων της σειράς.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Τροποποίηση του ονόματος της σειράς.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Προσθήκη νέας σειράς.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Γέμισμα των δεδομένων της σειράς.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Αποθήκευση της παρουσίασης με το διάγραμμα.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Περιοχής Δεδομένων για Διάγραμμα**

Το Aspose.Slides για .NET προσφέρει την ευελιξία να ορίζετε μια συγκεκριμένη περιοχή δεδομένων από ένα φύλλο εργασίας ως πηγή για τα δεδομένα του διαγράμματος. Αυτό σημαίνει ότι μπορείτε να χαρτογραφήσετε άμεσα ένα τμήμα του φύλλου εργασίας στο διάγραμμα, ελέγχοντας ποιες κυψέλες συμβάλλουν στις σειρές και τις κατηγορίες του διαγράμματος. Ως αποτέλεσμα, μπορείτε εύκολα να ενημερώνετε και να συγχρονίζετε τα διαγράμματά σας με τις τελευταίες αλλαγές στα δεδομένα, διασφαλίζοντας ότι οι παρουσιάσεις PowerPoint αντικατοπτρίζουν ακριβείς και επικαιροποιημένες πληροφορίες.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα.
1. Ανακτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Περπατήστε σε όλα τα σχήματα για να εντοπίσετε το διάγραμμα.
1. Πρόσβαση στα δεδομένα του διαγράμματος και ορίστε την περιοχή.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε την περιοχή δεδομένων για ένα διάγραμμα:

```c#
const string chartName = "My chart";

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **Χρήση Προεπιλεγμένων Δεικτών σε Διαγράμματα**

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό προεπιλεγμένο σύμβολο δείκτη.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε αυτόματα έναν δείκτη σειράς διαγράμματος:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // Γεμίστε τα δεδομένα της σειράς.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις (FAQ)**

**Τι τύποι διαγραμμάτων υποστηρίζει το Aspose.Slides για .NET;**

Το Aspose.Slides για .NET υποστηρίζει μια ευρεία γκάμα τύπων διαγραμμάτων, συμπεριλαμβανομένων των ραβδών, γραμμών, πίτας, περιοχής, διασποράς, ιστογράμματος, ραδίου και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διαγράμματος για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω ένα νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε ένα διάγραμμα, πρώτα δημιουργείτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation), ανακτάτε τη ζητούμενη διαφάνεια χρησιμοποιώντας τον δείκτη της και, στη συνέχεια, καλείτε τη μέθοδο για προσθήκη διαγράμματος, καθορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος αποκτώντας πρόσβαση στο βιβλίο δεδομένων του ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)), καθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες και στη συνέχεια προσθέτοντας τα προσαρμοσμένα σας δεδομένα. Αυτό σας επιτρέπει να ανανεώνετε προγραμματιστικά το διάγραμμα ώστε να αντικατοπτρίζει τα πιο πρόσφατα δεδομένα.

**Μπορώ να προσαρμόσω την εμφάνιση του διαγράμματος;**

Ναι, το Aspose.Slides για .NET προσφέρει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα στοιχεία μορφοποίησης για να προσαρμόσετε την εμφάνιση του διαγράμματος στις συγκεκριμένες απαιτήσεις του σχεδίου σας.