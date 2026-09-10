---
title: Δημιουργία ή ενημέρωση διαγραμμάτων παρουσίασης PowerPoint σε .NET
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
- διάσπαρτο διάγραμμα
- κειμενικό διάγραμμα
- γραμμικό διάγραμμα
- διάγραμμα δέντρου χάρτη
- διάγραμμα μετοχών
- διάγραμμα κουτι-καρδιά
- διάγραμμα χωνίου
- ηλιακό-αστροειδές διάγραμμα
- ιστόγραμμα
- ακτινωτό διάγραμμα
- πολύ-κατηγορικό διάγραμμα
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για .NET. Προσθέστε, μορφοποιήστε και επεξεργαστείτε διαγράμματα με πρακτικά παραδείγματα κώδικα σε C#."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα χρησιμοποιώντας το Aspose.Slides for .NET. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης για να ταιριάζει με τις συγκεκριμένες απαιτήσεις του σχεδίου σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα απεικονίζουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου διαγράμματος μέχρι τη διαμόρφωση σειρών, αξόνων και υπομνήματος. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε σταθερή κατανόηση του πώς να ενσωματώσετε δυναμική δημιουργία διαγραμμάτων στις .NET εφαρμογές σας, βελτιώνοντας τη διαδικασία δημιουργίας παρουσιάσεων βασισμένων σε δεδομένα.

## **Δημιουργία διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα δεδομένα και να αποκτούν διορατικότητα που δεν είναι άμεσα εμφανής από έναν πίνακα ή ένα λογιστικό φύλλο.

**Γιατί να δημιουργούμε διαγράμματα;**

Με τα διαγράμματα μπορείτε:

* να συγκεντρώσετε, συμπιέσετε ή συνοψίσετε μεγάλες ποσότητες δεδομένων σε μια μόνο διαφάνεια παρουσίασης·
* να αποκαλύψετε μοτίβα και τάσεις στα δεδομένα·
* να εκτιμήσετε την κατεύθυνση και την ορμή των δεδομένων με την πάροδο του χρόνου ή σε σχέση με μια συγκεκριμένη μονάδα μέτρησης·
* να εντοπίσετε ακραίες τιμές, αποκλίσεις, σφάλματα και ανορθόδοξα δεδομένα·
* να επικοινωνήσετε ή να παρουσιάσετε πολύπλοκα δεδομένα.

Στο PowerPoint, μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας *Insert*, η οποία παρέχει πρότυπα για τον σχεδιασμό πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο τακτικά διαγράμματα (βασισμένα σε δημοφιλείς τύπους) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="info" %}} 
Χρησιμοποιήστε την αρίθμηση [ChartType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/charttype/) στο χώρο ονομάτων [Aspose.Slides.Charts](https://reference.aspose.com/slides/el/net/aspose.slides.charts/). Οι τιμές σε αυτήν την αρίθμηση αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.
{{% /alert %}} 

### **Δημιουργία Σωρευτών Στήλων (Clustered Column Charts)**

Αυτή η ενότητα εξηγεί πώς να δημιουργήσετε σωρευτές στήλες χρησιμοποιώντας το Aspose.Slides for .NET. Θα μάθετε να αρχικοποιείτε μια παρουσίαση, να προσθέτετε ένα διάγραμμα και να προσαρμόζετε τα στοιχεία του όπως τίτλο, δεδομένα, σειρές, κατηγορίες και στυλ. Ακολουθήστε τα παρακάτω βήματα για να δείτε πώς δημιουργείται ένα τυπικό σωρευτικό διάγραμμα στήλης:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον τύπο `ChartType.ClusteredColumn`.
1. Προσθέστε έναν τίτλο στο διάγραμμα.
1. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
1. Καταργήστε όλες τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές διαγράμματος.
1. Εφαρμόστε χρώμα γεμίσματος στις σειρές διαγράμματος.
1. Προσθέστε ετικέτες στις σειρές διαγράμματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα σωρευτικό διάγραμμα στήλης:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη διαγράμματος σωρευτικών στηλών με τα προεπιλεγμένα του δεδομένα.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Ορισμός του τίτλου του διαγράμματος.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
    int worksheetIndex = 0;

    // Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Διαγραφή των προεπιλεγμένων παραγόμενων σειρών και κατηγοριών.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Προσθήκη νέων σειρών.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Προσθήκη νέων κατηγοριών.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Λήψη της πρώτης σειράς του διαγράμματος.
    IChartSeries series = chart.ChartData.Series[0];

    // Γέμισμα των δεδομένων της σειράς.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Ορισμός του χρώματος γεμίσματος για τη σειρά.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Λήψη της δεύτερης σειράς του διαγράμματος.
    series = chart.ChartData.Series[1];

    // Γέμισμα των δεδομένων της σειράς.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Ορισμός του χρώματος γεμίσματος για τη σειρά.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Ορισμός της πρώτης ετικέτας ώστε να εμφανίζει το όνομα της κατηγορίας.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Ορισμός της σειράς ώστε η τρίτη ετικέτα να εμφανίζει την τιμή.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Αποθήκευση της παρουσίασης στο δίσκο ως αρχείο PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![The Clustered Column chart](clustered_column_chart.png)

### **Δημιουργία Διάσπαρτων Διαγραμμάτων (Scatter Charts)**

Τα διάσπαρτα διαγράμματα (επίσης γνωστά ως scatter plots ή x‑y γραφήματα) χρησιμοποιούνται συχνά για την ανίχνευση μοτίβων ή την εμφάνιση συσχετίσεων μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε ένα διάσπαρτο διάγραμμα όταν:

* Έχετε αριθμητικά δεδομένα σε ζεύγη·
* Έχετε δύο μεταβλητές που συνδυάζονται καλά·
* Θέλετε να καθορίσετε αν οι δύο μεταβλητές σχετίζονται·
* Διαθέτετε μια ανεξάρτητη μεταβλητή με πολλαπλές τιμές για μια εξαρτημένη μεταβλητή.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάσπαρτο διάγραμμα με διαφορετική σειρά δεικτών:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Δημιουργία προεπιλεγμένου διασπαρτικού διαγράμματος.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
    int worksheetIndex = 0;

    // Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
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

    // Αποθήκευση της παρουσίασης στο δίσκο ως αρχείο PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![The Scatter chart](scatter_chart.png)

### **Δημιουργία Κειμενικών Διαγραμμάτων (Pie Charts)**

Τα κειμενικά διαγράμματα είναι ιδανικά για την απεικόνιση της σχέσης μέρος‑σε‑ολό σε δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγοριοποιημένες ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιέχουν πολλά τμήματα ή ετικέτες, ίσως θελήσετε να χρησιμοποιήσετε ένα ραβδόγραμμα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο `ChartType.Pie`.
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές διαγράμματος.
1. Προσθέστε νέα σημεία για το διάγραμμα και εφαρμόστε προσαρμοσμένα χρώματα στους τομείς του κειμενικού διαγράμματος.
1. Ορίστε ετικέτες για τις σειρές.
1. Ενεργοποιήστε τις γραμμές οδηγού για τις ετικέτες σειρών.
1. Ορίστε τη γωνία περιστροφής για το κειμενικό διάγραμμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα κειμενικό διάγραμμα:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη διαγράμματος με τα προεπιλεγμένα του δεδομένα.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Ορισμός του τίτλου του διαγράμματος.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Ορισμός της πρώτης σειράς ώστε να εμφανίζει τιμές.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
    int worksheetIndex = 0;

    // Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Διαγραφή των προεπιλεγμένων παραγόμενων σειρών και κατηγοριών.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Προσθήκη νέων κατηγοριών.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Προσθήκη νέων σειρών.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Γέμισμα των δεδομένων της σειράς.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Ορισμός του χρώματος του τμήματος.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Ορισμός του περιγράμματος του τμήματος.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Ορισμός του περιγράμματος του τμήματος.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Ορισμός του περιγράμματος του τμήματος.
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

    // Ορισμός της σειράς ώστε να εμφανίζει γραμμές οδηγού για το διάγραμμα.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Ορισμός της γωνίας περιστροφής για τα τμήματα του κειμενικού διαγράμματος.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Αποθήκευση της παρουσίασης στο δίσκο ως αρχείο PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![The Pie chart](pie_chart.png)

### **Δημιουργία Γραμμικών Διαγραμμάτων (Line Charts)**

Τα γραμμικά διαγράμματα (επίσης γνωστά ως line graphs) είναι ιδανικά σε καταστάσεις όπου θέλετε να παρουσιάσετε αλλαγές στην τιμή με την πάροδο του χρόνου. Χρησιμοποιώντας ένα γραμμικό διάγραμμα, μπορείτε να συγκρίνετε μεγάλο όγκο δεδομένων μονομιάς, να παρακολουθείτε αλλαγές και τάσεις στο χρόνο, να επισημαίνετε ανωμαλίες σε σειρές δεδομένων κ.ά.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο `ChartType.Line`.
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές διαγράμματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα γραμμικό διάγραμμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Από προεπιλογή, τα σημεία σε ένα γραμμικό διάγραμμα συνδέονται με στεγές συνεχείς γραμμές. Εάν θέλετε τα σημεία να συνδέονται με παύλες, μπορείτε να ορίσετε τον προτιμώμενο τύπο παύλας ως εξής:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

Το αποτέλεσμα:

![The Line chart](line_chart.png)

### **Δημιουργία Διαγραμμάτων Δέντρο-Χάρτη (Tree Map Charts)**

Τα διαγράμματα δέντρο‑χάρτη είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών δεδομένων και να εστιάσετε γρήγορα στα στοιχεία που συνεισφέρουν σημαντικά σε κάθε κατηγορία.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο `ChartType.Treemap`.
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές διαγράμματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα δέντρο‑χάρτη:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Κλαδί 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Κλαδί 2
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

![The Treemap chart](treemap_chart.png)

### **Δημιουργία Διαγραμμάτων Μετοχών (Stock Charts)**

Τα διαγράμματα μετοχών χρησιμοποιούνται για την παρουσίαση χρηματοοικονομικών δεδομένων όπως τιμές ανοίγματος, υψηλές, χαμηλές και κλεισίματος, βοηθώντας στην ανάλυση των τάσεων της αγοράς και της μεταβλητότητας. Παρέχουν ουσιώδεις πληροφορίες για την απόδοση των μετοχών, βοηθώντας επενδυτές και αναλυτές να λαμβάνουν ενημερωμένες αποφάσεις.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο `ChartType.OpenHighLowClose`.
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές διαγράμματος.
1. Καθορίστε τη μορφή HiLowLines.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα μετοχών:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![The Stock chart](stock_chart.png)

### **Δημιουργία Διαγραμμάτων Κουτί‑Καρδιά (Box and Whisker Charts)**

Τα διαγράμματα κουτί‑καρδιά χρησιμοποιούνται για την εμφάνιση της κατανομής των δεδομένων συνοψίζοντας βασικά στατιστικά μέτρα όπως το μεσαίο, τα τεταρτημόρια και τις πιθανές ακραίες τιμές. Είναι ιδιαίτερα χρήσιμα στην εξερευνητική ανάλυση δεδομένων και σε στατιστικές μελέτες για την γρήγορη κατανόηση της μεταβλητότητας των δεδομένων και την ταυτοποίηση ανωμαλιών.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο `ChartType.BoxAndWhisker`.
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές διαγράμματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα κουτί‑καρδιά:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

### **Δημιουργία Διάγραμμα Στρογγυλής Κατακόρυφης (Funnel Charts)**

Τα διαγράμματα στρογγυλής κατακόρυφης χρησιμοποιούνται για την οπτικοποίηση διαδικασιών που περιλαμβάνουν διαδοχικά στάδια, όπου ο όγκος των δεδομένων μειώνεται καθώς προχωρά από το ένα βήμα στο επόμενο. Είναι ιδιαίτερα χρήσιμα για την ανάλυση ποσοστών μετατροπής, τον εντοπισμό στενών σημείων και την παρακολούθηση της αποδοτικότητας των διαδικασιών πωλήσεων ή μάρκετινγκ.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο `ChartType.Funnel`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα στρογγυλής κατακόρυφης:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![The Funnel chart](funnel_chart.png)

### **Δημιουργία Ηλιακό-Αστροειδών Διαγραμμάτων (Sunburst Charts)**

Τα ηλιακό‑αστροειδή διαγράμματα χρησιμοποιούνται για την οπτικοποίηση ιεραρχικών δεδομένων, εμφανίζοντας τα επίπεδα ως κυκλικές εσωτερικές δακτύλιοι. Βοηθούν στην απεικόνιση σχέσεων μέρος‑σε‑ολό και είναι ιδανικά για την αναπαράσταση ενσωματωμένων κατηγοριών και υποκατηγοριών με σαφή, συμπαγή μορφή.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο `ChartType.Sunburst`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα ηλιακό‑αστροειδές διάγραμμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Κλαδί 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Κλαδί 2
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

![The Sunburst chart](sunburst_chart.png)

### **Δημιουργία Ιστογράμματος (Histogram Charts)**

Τα ιστογράμματα χρησιμοποιούνται για την αναπαράσταση της κατανομής αριθμητικών δεδομένων ομαδοποιώντας τις τιμές σε διαστήματα ή «κουβάδες». Είναι ιδιαίτερα χρήσιμα για την αναγνώριση μοτίβων όπως συχνότητα, ασυμμετρία και εξάπλωση, καθώς και για τον εντοπισμό ακραίων τιμών σε ένα σύνολο δεδομένων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον τύπο `ChartType.Histogram`.
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα ιστόγραμμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![The Histogram chart](histogram_chart.png)

### **Δημιουργία Ακτινωτών Διαγραμμάτων (Radar Charts)**

Τα ακτινωτά διαγράμματα χρησιμοποιούνται για την εμφάνιση πολυμεταβλητών δεδομένων σε δύο διαστάσεις, επιτρέποντας εύκολη σύγκριση πολλών μεταβλητών ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα για την αναγνώριση προτύπων, δυνατών και αδύναμων σημείων σε πολλαπλές μετρήσεις απόδοσης ή χαρακτηριστικά.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον τύπο `ChartType.Radar`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα ακτινικό διάγραμμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![The Radar chart](radar_chart.png)

### **Δημιουργία Πολυ‑Κατηγορικών Διαγραμμάτων (Multi-Category Charts)**

Τα πολυ‑κατηγορικά διαγράμματα χρησιμοποιούνται για την παρουσίαση δεδομένων που περιλαμβάνουν περισσότερα από ένα κατηγοριοποιημένα σύνολα, επιτρέποντας τη σύγκριση τιμών σε πολλαπλές διαστάσεις ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα όταν χρειάζεται να αναλύσετε τάσεις και σχέσεις σε σύνθετα, πολυεπίπεδα σύνολα δεδομένων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο `ChartType.ClusteredColumn`.
1. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές διαγράμματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα πολυ‑κατηγορικό διάγραμμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![The multi category chart](multi_category_chart.png)

### **Δημιουργία Διαγραμμάτων Χάρτη (Map Charts)**

Τα διαγράμματα χάρτη χρησιμοποιούνται για την οπτικοποίηση γεωγραφικών δεδομένων εντοπίζοντας πληροφορίες σε συγκεκριμένες τοποθεσίες όπως χώρες, πολιτεια ή πόλεις. Είναι ιδιαίτερα χρήσιμα για την ανάλυση περιφερειακών τάσεων, δημογραφικών δεδομένων και χωρικής κατανομής με σαφή, ελκυστικό τρόπο.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα χάρτη:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![The Map chart](map_chart.png)

{{% alert color="info" %}} 
Η εικόνα παραπάνω δείχνει την αποθηκευμένη παρουσίαση ανοιγμένη στο PowerPoint. Το Aspose.Slides γράφει σωστά το διάγραμμα χάρτη και τα δεδομένα του, αλλά δεν σχεδιάζει τα διαγράμματα χάρτη από μόνο του: όταν μια διαφάνεια που το περιέχει αποτυπώνεται σε εικόνα ή μετατρέπεται σε PDF ή SVG, η περιοχή του διαγράμματος εμφανίζεται κενή. Τα υπόλοιπα σχήματα στην ίδια διαφάνεια δεν επηρεάζονται.
{{% /alert %}} 

### **Δημιουργία Συνδυαστικών Διαγραμμάτων (Combination Charts)**

Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα μόνο γράφημα. Αυτό το διάγραμμα σας επιτρέπει να τονίσετε, να συγκρίνετε ή να εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.

![The combination chart](combination_chart.png)

Ο παρακάτω κώδικας C# δείχνει πώς να δημιουργήσετε το συνδυαστικό διάγραμμα που φαίνεται παραπάνω σε μια παρουσίαση PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

    // Διαγράφει τις προεπιλεγμένες παραγόμενες σειρές και κατηγορίες
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

    // Ορίζει τον κάθετο άξονα
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Ορίζει το χρώμα των κύριων κατακόρυφων πλέγματος
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

    // Ορίζει τον δευτερεύοντα κάθετο άξονα
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

## **Ενημέρωση Διαγραμμάτων (Update Charts)**

Το Aspose.Slides for .NET σας επιτρέπει να ενημερώνετε διαγράμματα PowerPoint τροποποιώντας τα δεδομένα, τη μορφοποίηση και το στυλ του διαγράμματος. Αυτή η λειτουργία απλοποιεί τη διαδικασία διατήρησης των παρουσιάσεων ενημερωμένων με δυναμικό περιεχόμενο και εξασφαλίζει ότι τα διαγράμματα αντικατοπτρίζουν ακριβώς τα τρέχοντα δεδομένα και τα οπτικά πρότυπα.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα.
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το διάγραμμα.
1. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
1. Τροποποιήστε τις σειρές δεδομένων του διαγράμματος αλλάζοντας τις τιμές των σειρών.
1. Προσθέστε μια νέα σειρά και συμπληρώστε τα δεδομένα της.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να ενημερώσετε ένα διάγραμμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
            int worksheetIndex = 0;

            // Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Αλλαγή των ονομάτων των κατηγοριών του διαγράμματος.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Λήψη της πρώτης σειράς διαγράμματος.
            IChartSeries series = chart.ChartData.Series[0];

            // Ενημέρωση των δεδομένων της σειράς.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Τροποποίηση του ονόματος της σειράς.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Λήψη της δεύτερης σειράς διαγράμματος.
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

## **Ορισμός Εύρους Δεδομένων για Διάγραμμα (Set Data Range for a Chart)**

Το Aspose.Slides for .NET παρέχει την ευελιξία να ορίζετε ένα συγκεκριμένο εύρος δεδομένων από ένα φύλλο εργασίας ως πηγή για τα δεδομένα του διαγράμματος. Αυτό σημαίνει ότι μπορείτε απευθείας να αντιστοιχίσετε ένα τμήμα του φύλλου εργασίας σας στο διάγραμμα, ελέγχοντας ποιες κελιά συμβάλλουν στις σειρές και τις κατηγορίες του διαγράμματος. Έτσι, μπορείτε εύκολα να ενημερώνετε και να συγχρονίζετε τα διαγράμματά σας με τις πιο πρόσφατες αλλαγές στα δεδομένα, διασφαλίζοντας ότι οι παρουσιάσεις PowerPoint αντανακλούν ακριβείς πληροφορίες.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα.
1. Λάβετε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το διάγραμμα.
1. Πρόσβαση στα δεδομένα του διαγράμματος και ορισμός του εύρους.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε το εύρος δεδομένων για ένα διάγραμμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
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

## **Χρήση Προεπιλεγμένων Δεικτών στα Διαγράμματα (Use Default Markers in Charts)**

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες στα διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό προεπιλεγμένο σύμβολο δείκτη.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε αυτόματα έναν δείκτη σειράς διαγράμματος:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

**Ποιοι τύποι διαγραμμάτων υποστηρίζονται από το Aspose.Slides for .NET;**

Το Aspose.Slides for .NET υποστηρίζει μια ευρεία γκάμα τύπων διαγραμμάτων, συμπεριλαμβανομένων των στηλών, γραμμών, κειμενικών, περιοχής, διάσπαρτων, ιστογραμμάτων, ακτινωτών και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διαγράμματος για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς μπορώ να προσθέσω ένα νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε ένα διάγραμμα, πρώτα δημιουργείτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation), ανακτάτε τη ζητούμενη διαφάνεια χρησιμοποιώντας το δείκτη της και, στη συνέχεια, καλείτε τη μέθοδο για την προσθήκη διαγράμματος, καθορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος αποκτώντας πρόσβαση στο βιβλίο εργασίας δεδομένων του ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)), διαγράφοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες και, στη συνέχεια, προσθέτοντας τα δικά σας προσαρμοσμένα δεδομένα. Αυτό σας επιτρέπει να ανανεώσετε προγραμματιστικά το διάγραμμα ώστε να αντικατοπτρίζει τα πιο πρόσφατα δεδομένα.

**Είναι δυνατόν να προσαρμόσω την εμφάνιση του διαγράμματος;**

Ναι, το Aspose.Slides for .NET παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα στοιχεία μορφοποίησης για να προσαρμόσετε την εμφάνιση του διαγράμματος στις συγκεκριμένες απαιτήσεις του σχεδίου σας.