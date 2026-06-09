---
title: Προσαρμογή Κυκλικών Διαγραμμάτων σε Παρουσιάσεις με .NET
linktitle: Κυκλικό Διάγραμμα
type: docs
url: /el/net/pie-chart/
keywords:
- κυκλικό διάγραμμα
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές σχεδίασης
- χρώμα φέτας
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να δημιουργήσετε και να προσαρμόσετε κυκλικά διαγράμματα σε .NET με το Aspose.Slides, εξαγώγιμα σε PowerPoint, ενισχύοντας την αφήγηση των δεδομένων σας σε δευτερόλεπτα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με κυκλικά διαγράμματα (pie charts) στο Aspose.Slides. Δείχνει πώς να ρυθμίσετε τις επιλογές δευτερεύοντος πλάνου για διαγράμματα Pie of Pie και Bar of Pie, καθώς και πώς να ενεργοποιήσετε την αυτόματη χρωματισμό των φέτες σε ένα τυπικό κυκλικό διάγραμμα.

Τα παραδείγματα εστιάζουν σε πρακτικά βήματα προσαρμογής του διαγράμματος, όπως η προσθήκη διαγράμματος σε διαφάνεια, η προσαρμογή ρυθμίσεων σειρών και ετικετών, η αντικατάσταση των προεπιλογών δεδομένων του διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Δευτερεύουσες Επιλογές Πλάνου για Διαγράμματα Pie of Pie και Bar of Pie**
Το Aspose.Slides for .NET πλέον υποστηρίζει δευτερεύουσες επιλογές πλάνου για διαγράμματα Pie of Pie ή Bar of Pie. Σε αυτό το θέμα, θα δούμε με παράδειγμα πώς να καθορίσουμε αυτές τις επιλογές χρησιμοποιώντας το Aspose.Slides. Για να καθορίσετε τις ιδιότητες, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Προσθέστε διάγραμμα στη διαφάνεια.
1. Καθορίστε τις δευτερεύουσες επιλογές πλάνου του διαγράμματος.
1. Αποθηκεύστε την παρουσίαση στον δίσκο.

Στο παρακάτω παράδειγμα, ορίσαμε διαφορετικές ιδιότητες του διαγράμματος Pie of Pie.

```c#
 // Δημιουργήστε μια παρουσία της κλάσης Presentation
 Presentation presentation = new Presentation();

 // Προσθέστε διάγραμμα στη διαφάνεια
 IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
      
 // Ορίστε διάφορες ιδιότητες
 chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
 chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
 chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
 chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

 // Αποθηκεύστε την παρουσίαση στο δίσκο
 presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **Ορισμός Αυτόματων Χρωμάτων Φέτας Κυκλικού Διαγράμματος**
Το Aspose.Slides for .NET παρέχει ένα απλό API για τον αυτόματο καθορισμό χρωμάτων των φετών σε κυκλικό διάγραμμα. Ο δείγμα κώδικας εφαρμόζει τις ανωτέρω ιδιότητες.

1. Δημιουργήστε μια παρουσία της κλάσης Presentation.
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθήκη διαγράμματος με προεπιλεγμένα δεδομένα.
1. Ορισμός τίτλου διαγράμματος.
1. Ορισμός της πρώτης σειράς ώστε να εμφανίζει τιμές.
1. Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος.
1. Λήψη του φύλλου εργασίας δεδομένων του διαγράμματος.
1. Διαγραφή των προεπιλεγμένων σειρών και κατηγοριών.
1. Προσθήκη νέων κατηγοριών.
1. Προσθήκη νέας σειράς.

Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```c#
 // Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
using (Presentation presentation = new Presentation())
{
	// Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
	Presentation presentation = new Presentation();

	// Πρόσβαση στην πρώτη διαφάνεια
	ISlide slides = presentation.Slides[0];

	// Προσθήκη διαγράμματος με προεπιλεγμένα δεδομένα
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Ορισμός τίτλου διαγράμματος
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Ορίστε την πρώτη σειρά ώστε να εμφανίζει τιμές
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος
	int defaultWorksheetIndex = 0;

	// Λήψη του φύλλου εργασίας δεδομένων του διαγράμματος
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Διαγραφή των προεπιλεγμένων σειρών και κατηγοριών
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Προσθήκη νέων κατηγοριών
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Προσθήκη νέας σειράς
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Τώρα γεμίζουμε τα δεδομένα της σειράς
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζονται οι παραλλαγές 'Pie of Pie' και 'Bar of Pie';**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/el/net/aspose.slides.charts/charttype/) ένα δευτερεύον πλάνο για κυκλικά διαγράμματα, συμπεριλαμβανομένων των τύπων 'Pie of Pie' και 'Bar of Pie'.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το ίδιο το διάγραμμα ως εικόνα](https://reference.aspose.com/slides/el/net/aspose.slides/shape/getimage/) (όπως PNG) χωρίς ολόκληρη την παρουσίαση.