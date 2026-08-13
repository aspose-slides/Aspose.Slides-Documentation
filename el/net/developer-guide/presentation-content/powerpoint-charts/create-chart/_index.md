---
title: Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσίασης PowerPoint σε .NET
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
- διάγραμμα χάρτη δέντρου
- διάγραμμα μετοχών
- διάγραμμα box‑and‑whisker
- διάγραμμα χωνιού
- διάγραμμα ηλιακού κύκλου
- ιστόγραμμα
- διάγραμμα ραντάρ
- πολυκατηγορικό διάγραμμα
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για .NET. Προσθέστε, μορφοποιήστε και επεξεργαστείτε διαγράμματα με πρακτικά παραδείγματα κώδικα σε C#."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργήσετε και να προσαρμόσετε διαγράμματα χρησιμοποιώντας το Aspose.Slides για .NET. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει στις συγκεκριμένες απαιτήσεις σχεδίασής σας. Καθ’ όλη τη διάρκεια του άρθρου, λεπτομερή παραδείγματα κώδικα απεικονίζουν κάθε βήμα, από την έναρξη της παρουσίασης και του αντικειμένου διαγράμματος μέχρι τη ρύθμιση σειρών, αξόνων και υπομνημάτων. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε στέρεη κατανόηση του πώς να ενσωματώσετε δυναμική δημιουργία διαγραμμάτων στις εφαρμογές .NET, βελτιστοποιώντας τη διαδικασία δημιουργίας παρουσιάσεων που βασίζονται σε δεδομένα.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα τα δεδομένα και να εξάγουν πληροφορίες που μπορεί να μην είναι άμεσα εμφανείς από έναν πίνακα ή ένα φύλλο εργασίας.

**Γιατί να δημιουργήσετε διαγράμματα;**

Με τα διαγράμματα μπορείτε:

* να συγκεντρώσετε, συμπιέσετε ή συνοψίσετε μεγάλες ποσότητες δεδομένων σε μία μόνο διαφάνεια παρουσίασης·
* να αποκαλύψετε μοτίβα και τάσεις στα δεδομένα·
* να κατανοήσετε την κατεύθυνση και τη δυναμική των δεδομένων με την πάροδο του χρόνου ή σε σχέση με συγκεκριμένη μονάδα μέτρησης·
* να εντοπίσετε ακραίες τιμές, αποκλίσεις, σφάλματα και ακατανόητα δεδομένα·
* να επικοινωνήσετε ή να παρουσιάσετε πολύπλοκα δεδομένα.

Στο PowerPoint μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας *Insert*, η οποία προσφέρει πρότυπα για το σχεδιασμό πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο τυπικά διαγράμματα (βασισμένα σε δημοφιλείς τύπους) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="info" %}} 
Χρησιμοποιήστε την απαρίθμηση [ChartType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/charttype/) στο χώρο ονομάτων [Aspose.Slides.Charts](https://reference.aspose.com/slides/el/net/aspose.slides.charts/). Οι τιμές σε αυτήν την απαρίθμηση αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.
{{% /alert %}} 

### **Δημιουργία Συγκεντρωτικών Στηλών (Clustered Column)**
Αυτό το τμήμα εξηγεί πώς να δημιουργήσετε συγκεντρωτικά διαγράμματα στήλης χρησιμοποιώντας το Aspose.Slides για .NET. Θα μάθετε να αρχικοποιείτε μια παρουσίαση, να προσθέτετε ένα διάγραμμα και να προσαρμόζετε στοιχεία όπως τίτλο, δεδομένα, σειρές, κατηγορίες και στυλ. Ακολουθήστε τα παρακάτω βήματα για να δείτε πώς παράγεται ένα τυπικό συγκεντρωτικό διάγραμμα στήλης:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.  
3. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.ClusteredColumn`.  
4. Προσθέστε τίτλο στο διάγραμμα.  
5. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.  
6. Καθαρίστε όλες τις προεπιλεγμένες σειρές και κατηγορίες.  
7. Προσθέστε νέες σειρές και κατηγορίες.  
8. Προσθέστε νέα δεδομένα στο διάγραμμα για τις σειρές.  
9. Εφαρμόστε χρώμα γέμισμα στις σειρές του διαγράμματος.  
10. Προσθέστε ετικέτες στις σειρές του διαγράμματος.  
11. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα συγκεντρωτικό διάγραμμα στήλης:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη συγκεντρωτικού διαγράμματος στήλης με τα προεπιλεγμένα δεδομένα του.
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

    // Διαγραφή των προεπιλεγμένων σειρών και κατηγοριών που δημιουργήθηκαν.
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

    // Συμπλήρωση των δεδομένων της σειράς.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Ορισμός του χρώματος γεμίσματος για τη σειρά.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Λήψη της δεύτερης σειράς του διαγράμματος.
    series = chart.ChartData.Series[1];

    // Συμπλήρωση των δεδομένων της σειράς.
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

### **Δημιουργία Διαγραμμάτων Διασποράς (Scatter)**
Τα διαγράμματα διασποράς (επίσης γνωστά ως scatter plots ή διαγράμματα x‑y) χρησιμοποιούνται συχνά για τον έλεγχο μοτίβων ή την επίδειξη συσχετίσεων μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε διάγραμμα διασποράς όταν:

* Διαθέτετε αριθμητικά δεδομένα σε ζεύγη.  
* Έχετε δύο μεταβλητές που συνδυάζονται λογικά.  
* Θέλετε να καθορίσετε εάν οι δύο μεταβλητές σχετίζονται μεταξύ τους.  
* Έχετε μια ανεξάρτητη μεταβλητή με πολλαπλές τιμές για μια εξαρτημένη μεταβλητή.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα διάγραμμα διασποράς με διαφορετική σειρά δεικτών:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Αρχικοποίηση της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Δημιουργία του προεπιλεγμένου διαγράμματος διασποράς.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
    int worksheetIndex = 0;

    // Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Διαγραφή της προεπιλεγμένης σειράς.
    chart.ChartData.Series.Clear();

    // Προσθήκη νέας σειράς.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Λήψη της πρώτης σειράς του διαγράμματος.
    IChartSeries series = chart.ChartData.Series[0];

    // Προσθήκη νέου σημείου (1:3) στη σειρά.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Προσθήκη νέου σημείου (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Αλλαγή του τύπου της σειράς.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Αλλαγή του δείκτη (marker) της σειράς διαγράμματος.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // Λήψη της δεύτερης σειράς του διαγράμματος.
    series = chart.ChartData.Series[1];

    // Προσθήκη νέου σημείου (5:2) στη σειρά του διαγράμματος.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Προσθήκη νέου σημείου (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Προσθήκη νέου σημείου (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Προσθήκη νέου σημείου (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Αλλαγή του δείκτη (marker) της σειράς διαγράμματος.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Αποθήκευση της παρουσίασης στο δίσκο ως αρχείο PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![The Scatter chart](scatter_chart.png)

### **Δημιουργία Πίτας (Pie)**
Τα διαγράμματα πίτας είναι ιδανικά για την εμφάνιση της σχέσης μέρος‑σε‑ολό σε δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγορίες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιέχουν πολλά τμήματα ή ετικέτες, ίσως θελήσετε να χρησιμοποιήσετε ένα ραβδόγραμμα.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.Pie`.  
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).  
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
6. Προσθέστε νέες σειρές και κατηγορίες.  
7. Προσθέστε νέα δεδομένα για τις σειρές του διαγράμματος.  
8. Προσθέστε νέες σημεία στο διάγραμμα και εφαρμόστε προσαρμοσμένα χρώματα στους τομείς της πίτας.  
9. Ορίστε ετικέτες για τις σειρές.  
10. Ενεργοποιήστε τις γραμμές οδηγούς για τις ετικέτες των σειρών.  
11. Ορίστε τη γωνία περιστροφής της πίτας.  
12. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να δημιουργήσετε ένα διάγραμμα πίτας:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Αρχικοποίηση της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη διαγράμματος με τα προεπιλεγμένα δεδομένα του.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Ορισμός του τίτλου του διαγράμματος.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Ορισμός της πρώτης σειράς για εμφάνιση τιμών.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
    int worksheetIndex = 0;

    // Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Διαγραφή των προεπιλεγμένων σειρών και κατηγοριών.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Προσθήκη νέων κατηγοριών.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Προσθήκη νέας σειράς.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Συμπλήρωση των δεδομένων της σειράς.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Ορισμός του χρώματος του τομέα.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Ορισμός του περιγράμματος του τομέα.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Ορισμός του περιγράμματος του τομέα.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Ορισμός του περιγράμματος του τομέα.
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

    // Ορισμός της σειράς ώστε να εμφανίζει γραμμές οδηγικής (leader) στο διάγραμμα.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Ορισμός της γωνίας περιστροφής για τους τομείς του διαγράμματος πίτας.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Αποθήκευση της παρουσίασης στο δίσκο ως αρχείο PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![The Pie chart](pie_chart.png)

### **Δημιουργία Γραμμικών Διαγραμμάτων (Line)**
Τα γραμμικά διαγράμματα (συχνά αποκαλούμενα line graphs) είναι ιδανικά όταν θέλετε να δείξετε αλλαγές στην τιμή με την πάροδο του χρόνου. Με ένα γραμμικό διάγραμμα μπορείτε να συγκρίνετε μεγάλη ποσότητα δεδομένων ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις, να επισημαίνετε ανωμαλίες στις σειρές δεδομένων κ.λπ.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.Line`.  
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).  
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
6. Προσθέστε νέες σειρές και κατηγορίες.  
7. Προσθέστε νέα δεδομένα για τις σειρές του διαγράμματος.  
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να δημιουργήσετε ένα γραμμικό διάγραμμα:

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

Από προεπιλογή, τα σημεία σε ένα γραμμικό διάγραμμα συνδέονται με συνεχείς ευθείες γραμμές. Εάν θέλετε τα σημεία να συνδέονται με παύλες, μπορείτε να ορίσετε τον τύπο παύλας ως εξής:

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

### **Δημιουργία Διαγραμμάτων Δελτίων (Tree Map)**
Τα διαγράμματα δέντρου (tree map) είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών δεδομένων και να τραβήξετε γρήγορα την προσοχή σε στοιχεία που συμβάλλουν σημαντικά εντός κάθε κατηγορίας.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.Treemap`.  
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).  
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
6. Προσθέστε νέες σειρές και κατηγορίες.  
7. Προσθέστε νέα δεδομένα για τις σειρές του διαγράμματος.  
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να δημιουργήσετε ένα διάγραμμα δέντρου:

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

### **Δημιουργία Διαγραμμάτων Μετοχών (Stock)**
Τα διαγράμματα μετοχών χρησιμοποιούνται για την προβολή χρηματοοικονομικών δεδομένων όπως τιμές ανοίγματος, υψηλής, χαμηλής και κλεισίματος, βοηθώντας στην ανάλυση τάσεων της αγοράς και της μεταβλητότητας. Παρέχουν κρίσιμες γνώσεις για την απόδοση των μετοχών, βοηθώντας επενδυτές και αναλυτές να λαμβάνουν ενημερωμένες αποφάσεις.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.OpenHighLowClose`.  
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).  
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
6. Προσθέστε νέες σειρές και κατηγορίες.  
7. Προσθέστε νέα δεδομένα για τις σειρές του διαγράμματος.  
8. Ορίστε τη μορφή HiLowLines.  
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να δημιουργήσετε ένα διάγραμμα μετοχών:

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

### **Δημιουργία Διαγραμμάτων Κουτιού‑Καμπύλης (Box and Whisker)**
Τα διαγράμματα Box and Whisker χρησιμοποιούνται για την παρουσίαση της κατανομής των δεδομένων, συνοψίζοντας βασικά στατιστικά μέτρα όπως η διάμεσος, τα τεταρτημόρια και οι πιθανές ακραίες τιμές. Είναι ιδιαίτερα χρήσιμα στην εξερευνητική ανάλυση δεδομένων και σε στατιστικές μελέτες για την γρήγορη κατανόηση της μεταβλητότητας και την ταυτοποίηση ανωμαλιών.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.BoxAndWhisker`.  
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).  
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
6. Προσθέστε νέες σειρές και κατηγορίες.  
7. Προσθέστε νέα δεδομένα για τις σειρές του διαγράμματος.  
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να δημιουργήσετε ένα διάγραμμα Box and Whisker:

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

### **Δημιουργία Διαγραμμάτων Χωνιού (Funnel)**
Τα διαγράμματα χωνιού χρησιμοποιούνται για την οπτικοποίηση διαδικασιών που περιλαμβάνουν διαδοχικά στάδια, στα οποία ο όγκος δεδομένων μειώνεται καθώς προχωρά από το ένα βήμα στο επόμενο. Είναι ιδιαίτερα χρήσιμα για την ανάλυση ποσοστών μετατροπής, τον εντοπισμό bottleneck και την παρακολούθηση της αποδοτικότητας των διαδικασιών πώλησης ή μάρκετινγκ.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.Funnel`.  
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να δημιουργήσετε ένα διάγραμμα χωνιού:

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

### **Δημιουργία Διαγραμμάτων Ηλιακού Κύκλου (Sunburst)**
Τα διαγράμματα ηλιακού κύκλου (sunburst) χρησιμοποιούνται για την οπτικοποίηση ιεραρχικών δεδομένων, εμφανίζοντας τα επίπεδα ως συγκρότημα δακτυλίων. Βοηθούν στην απεικόνιση σχέσεων μέρος‑σε‑ολό και είναι ιδανικά για την αναπαράσταση ένθετων κατηγοριών με σαφή και συμπαγή μορφή.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.Sunburst`.  
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να δημιουργήσετε ένα διάγραμμα ηλιακού κύκλου:

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

### **Δημιουργία Ιστόγραμμα (Histogram)**
Τα ιστογράμματα χρησιμοποιούνται για την απεικόνιση της κατανομής αριθμητικών δεδομένων, ομαδοποιώντας τις τιμές σε διαστήματα (bins). Είναι ιδιαίτερα χρήσιμα για την ταυτοποίηση προτύπων όπως συχνότητα, ασυμμετρία και εύρος, καθώς και για τον εντοπισμό ακραίων τιμών σε ένα σύνολο δεδομένων.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Προσθέστε διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.Histogram`.  
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).  
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
6. Προσθέστε νέες σειρές και κατηγορίες.  
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να δημιουργήσετε ένα ιστόγραμμα:

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

### **Δημιουργία Ακτινωτών Διαγραμμάτων (Radar)**
Τα ακτινωτά διαγράμματα (radar) χρησιμοποιούνται για την παρουσίαση πολυμεταβλητών δεδομένων σε δισδιάστατη μορφή, επιτρέποντας εύκολη σύγκριση πολλών μεταβλητών ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα για τον εντοπισμό προτύπων, ισχυρών και αδύναμων σημείων σε πολλαπλούς δείκτες απόδοσης ή χαρακτηριστικά.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Προσθέστε διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο `ChartType.Radar`.  
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να δημιουργήσετε ένα ακτινωτό διάγραμμα:

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

### **Δημιουργία Πολυ‑Κατηγορικών Διαγραμμάτων**
Τα πολυ‑κατηγορικά διαγράμματα χρησιμοποιούνται για την παρουσίαση δεδομένων που περιλαμβάνουν περισσότερες από μία κατηγορίες, επιτρέποντάς σας να συγκρίνετε τιμές κατά μήκος πολλαπλών διαστάσεων ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα όταν χρειάζεται να αναλύσετε τάσεις και σχέσεις μέσα σε σύνθετα, πολυεπίπεδα σύνολα δεδομένων.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα και ορίστε τον τύπο `ChartType.ClusteredColumn`.  
4. Πρόσβαση στο βιβλίο εργασίας δεδομένων του διαγράμματος ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)).  
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.  
6. Προσθέστε νέες σειρές και κατηγορίες.  
7. Προσθέστε νέα δεδομένα για τις σειρές του διαγράμματος.  
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να δημιουργήσετε ένα πολυ‑κατηγορικό διάγραμμα:

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

### **Δημιουργία Διαγραμμάτων Χάρτη (Map)**
Τα διαγράμματα χάρτη χρησιμοποιούνται για την οπτικοποίηση γεωγραφικών δεδομένων χαρτογραφώντας πληροφορίες σε συγκεκριμένες τοποθεσίες όπως χώρες, πολιτείες ή πόλεις. Είναι ιδιαίτερα χρήσιμα για την ανάλυση περιφερειακών τάσεων, δημογραφικών δεδομένων και χωρικής κατανομής με σαφή και ελκυστική παρουσίαση.

Ο κώδικας C# παρακάτω δείχνει πώς να δημιουργήσετε ένα διάγραμμα χάρτη:

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
Η εικόνα παραπάνω δείχνει την αποθηκευμένη παρουσίαση ανοιγμένη σε PowerPoint. Το Aspose.Slides γράφει σωστά το διάγραμμα χάρτη και τα δεδομένα του, αλλά δεν σχεδιάζει μόνο του διαγράμματα χάρτη: όταν μια διαφάνεια που το περιέχει αποτυπώνεται σε εικόνα ή μετατρέπεται σε PDF ή SVG, η περιοχή του διαγράμματος παραμένει κενή. Τα άλλα σχήματα στην ίδια διαφάνεια παραμένουν αμετάβλητα.
{{% /alert %}} 

### **Δημιουργία Συνδυαστικών Διαγραμμάτων**
Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγράμματος σε ένα γράφημα. Αυτό το διάγραμμα σας επιτρέπει να αναδείξετε, να συγκρίνετε ή να εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας στην αναγνώριση σχέσεων μεταξύ τους.

![The combination chart](combination_chart.png)

Ο παρακάτω κώδικας C# δείχνει πώς να δημιουργήσετε το παραπάνω συνδυαστικό διάγραμμα σε μια παρουσίαση PowerPoint:

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

    // Ορίζει τον κάθετο άξονα
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Ορίζει το χρώμα των κύριων κατακόρυφων γραμμών πλέγματος
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

## **Ενημέρωση Διαγραμμάτων**

Το Aspose.Slides για .NET επιτρέπει την ενημέρωση διαγραμμάτων PowerPoint τροποποιώντας δεδομένα, μορφοποίηση και στυλ. Αυτή η λειτουργικότητα απλοποιεί τη διατήρηση των παρουσιάσεων ενημερωμένων με δυναμικό περιεχόμενο και διασφαλίζει ότι τα διαγράμματα αντικατοπτρίζουν με ακρίβεια τα τρέχοντα δεδομένα και τα οπτικά πρότυπα.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει το διάγραμμα.  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Διασχίστε όλα τα σχήματα για να βρείτε το διάγραμμα.  
4. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.  
5. Τροποποιήστε τις σειρές δεδομένων του διαγράμματος αλλάζοντας τις τιμές των σειρών.  
6. Προσθέστε μια νέα σειρά και συμπληρώστε τα δεδομένα της.  
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να ενημερώσετε ένα διάγραμμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
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

            // Αλλαγή των ονομάτων κατηγοριών του διαγράμματος.
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

            // Συμπλήρωση των δεδομένων της σειράς.
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

Το Aspose.Slides για .NET προσφέρει την ευελιξία να ορίζετε μια συγκεκριμένη περιοχή δεδομένων από ένα φύλλο εργασίας ως πηγή για τα δεδομένα του διαγράμματος. Αυτό σημαίνει ότι μπορείτε άμεσα να αντιστοιχίσετε ένα τμήμα του φύλλου εργασίας στο διάγραμμα, ελέγχοντας ποιες κελιά συμβάλλουν στις σειρές και τις κατηγορίες του διαγράμματος. Ως αποτέλεσμα, μπορείτε εύκολα να ενημερώνετε και να συγχρονίζετε τα διαγράμμά σας με τις τελευταίες αλλαγές των δεδομένων, διασφαλίζοντας ότι οι παρουσιάσεις PowerPoint αντικατοπτρίζουν ακριβείς πληροφορίες.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει το διάγραμμα.  
2. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.  
3. Διασχίστε όλα τα σχήματα για να βρείτε το διάγραμμα.  
4. Πρόσβαση στα δεδομένα του διαγράμματος και ορίστε την περιοχή.  
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας C# παρακάτω δείχνει πώς να ορίσετε την περιοχή δεδομένων για ένα διάγραμμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
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

## **Χρήση Προεπιλεγμένων Σημείων σε Διαγράμματα**

Όταν χρησιμοποιείτε προεπιλεγμένα σημεία σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό προεπιλεγμένο σύμβολο σημείου.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε αυτόματα το σύμβολο σημείου για μια σειρά διαγράμματος:

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

    // Συμπλήρωση δεδομένων της σειράς.
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

### Ποιοί τύποι διαγραμμάτων υποστηρίζονται από το Aspose.Slides για .NET;
Το Aspose.Slides για .NET υποστηρίζει ευρύ φάσμα τύπων διαγραμμάτων, συμπεριλαμβανομένων bar, line, pie, area, scatter, histogram, radar και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο για τις ανάγκες οπτικοποίησης των δεδομένων σας.

### Πώς να προσθέσω νέο διάγραμμα σε μια διαφάνεια;
Για να προσθέσετε διάγραμμα, πρώτα δημιουργείτε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation), ανακτάτε τη ζητούμενη διαφάνεια με βάση το δείκτη της και, στη συνέχεια, καλείτε τη μέθοδο προσθήκης διαγράμματος, ορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

### Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;
Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος αποκτώντας πρόσβαση στο βιβλίο εργασίας δεδομένων του ([IChartDataWorkbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/)), καθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες και, στη συνέχεια, προσθέτοντας τα δικά σας δεδομένα. Αυτό σας επιτρέπει να ανανεώνετε προγραμματιστικά το διάγραμμα ώστε να αντικατοπτρίζει τα πιο πρόσφατα δεδομένα.

### Είναι δυνατόν να προσαρμόσω την εμφάνιση του διαγράμματος;
Ναι, το Aspose.Slides για .NET παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα στοιχεία μορφοποίησης ώστε να ταιριάζουν στις συγκεκριμένες απαιτήσεις σχεδίασής σας.