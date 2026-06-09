---
title: Προσαρμογή των αξόνων διαγράμματος σε παρουσιάσεις σε .NET
linktitle: Άξονας Διαγράμματος
type: docs
url: /el/net/chart-axis/
keywords:
- άξονας διαγράμματος
- κατακόρυφος άξονας
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

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες των διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να λάβετε τις πραγματικές τιμές των αξόνων, να ανταλλάξετε δεδομένα μεταξύ αξόνων, να αποκρύψετε τον κάθετο ή οριζόντιο άξονα για διαγράμματα γραμμής, να αλλάξετε τον τύπο του άξονα κατηγορίας, να ορίσετε τη μορφή ημερομηνίας για τις τιμές του άξονα κατηγορίας, να περιστρέψετε τον τίτλο του άξονα, να ορίσετε τη θέση του άξονα και να εμφανίσετε ετικέτα μονάδας στον άξονα τιμών.

## **Λάβετε τις Μέγιστες Τιμές στον Κατακόρυφο Άξονα στα Διαγράμματα**
Το Aspose.Slides για .NET σας επιτρέπει να λάβετε τις ελάχιστες και τις μέγιστες τιμές σε έναν κατακόρυφο άξονα. Ακολουθήστε αυτά τα βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης[Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα.
1. Λάβετε την πραγματική μέγιστη τιμή του άξονα.
1. Λάβετε την πραγματική ελάχιστη τιμή του άξονα.
1. Λάβετε τη πραγματική κύρια μονάδα του άξονα.
1. Λάβετε τη πραγματική δευτερεύουσα μονάδα του άξονα.
1. Λάβετε την πραγματική κλίμακα κύριας μονάδας του άξονα.
1. Λάβετε την πραγματική κλίμακα δευτερεύουσας μονάδας του άξονα.

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Αποθηκεύει την παρουσίαση
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Ανταλλαγή Δεδομένων μεταξύ Αξόνων**
Το Aspose.Slides σας επιτρέπει να ανταλλάξετε γρήγορα τα δεδομένα μεταξύ των αξόνων—τα δεδομένα που εμφανίζονται στον κατακόρυφο άξονα (y‑axis) μετακινούνται στον οριζόντιο άξονα (x‑axis) και αντίστροφα.

```c#
 // Δημιουργεί κενή παρουσίαση
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Αλλάζει γραμμές και στήλες
	chart.ChartData.SwitchRowColumn();
		   
	// Αποθηκεύει παρουσίαση
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Απενεργοποίηση Κατακόρυφου Άξονα για Διαγράμματα Γραμμής**

Αυτός ο κώδικας C# δείχνει πώς να αποκρύψετε τον κατακόρυφο άξονα για ένα διάγραμμα γραμμής:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Απενεργοποίηση Οριζόντιου Άξονα για Διαγράμματα Γραμμής**

Αυτός ο κώδικας δείχνει πώς να αποκρύψετε τον οριζόντιο άξονα για ένα διάγραμμα γραμμής:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Αλλαγή Άξονα Κατηγορίας**

Χρησιμοποιώντας την ιδιότητα **CategoryAxisType**, μπορείτε να καθορίσετε τον προτιμώμενο τύπο άξονα κατηγορίας (**date** ή **text**). Αυτός ο κώδικας σε C# δείχνει τη λειτουργία:

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Μορφής Ημερομηνίας για Τιμές Άξονα Κατηγορίας**
Το Aspose.Slides για .NET σας επιτρέπει να ορίσετε τη μορφή ημερομηνίας για μια τιμή άξονα κατηγορίας. Η λειτουργία παρουσιάζεται σε αυτόν τον κώδικα C#:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Γωνίας Περιστροφής για Τίτλο Άξονα Διαγράμματος**
Το Aspose.Slides για .NET σας επιτρέπει να ορίσετε τη γωνία περιστροφής για τον τίτλο άξονα ενός διαγράμματος. Αυτός ο κώδικας C# δείχνει τη λειτουργία:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Θέσης Άξονα σε Άξονα Κατηγορίας ή Τιμής**
Το Aspose.Slides για .NET σας επιτρέπει να ορίσετε τη θέση του άξονα σε άξονα κατηγορίας ή τιμής. Αυτός ο κώδικας C# δείχνει πώς να εκτελέσετε την εργασία:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Ενεργοποίηση Εμφάνισης Ετικέτας Μονάδας στον Άξονα Τιμών Διαγράμματος**
Το Aspose.Slides για .NET σας επιτρέπει να διαμορφώσετε ένα διάγραμμα ώστε να εμφανίζει ετικέτα μονάδας στον άξονα τιμών του. Αυτός ο κώδικας C# δείχνει τη λειτουργία:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Οι άξονες παρέχουν μια [ρύθμιση διασταύρωσης](https://reference.aspose.com/slides/el/net/aspose.slides.charts/axis/crosstype/): μπορείτε να επιλέξετε διασταύρωση στο μηδέν, στο μέγιστο της κατηγορίας/τιμής, ή σε μια συγκεκριμένη αριθμητική τιμή. Αυτό είναι χρήσιμο για τη μετακίνηση του άξονα X πάνω ή κάτω ή για την έμφαση μιας βασικής γραμμής.

**Πώς μπορώ να τοποθετήσω τις ετικέτες των σημείων (tick labels) σε σχέση με τον άξονα (δίπλα, έξω, μέσα);**

Ορίστε τη [θέση ετικέτας](https://reference.aspose.com/slides/el/net/aspose.slides.charts/axis/majortickmark/) σε "cross", "outside" ή "inside". Αυτό επηρεάζει την αναγνωσιμότητα και βοηθά στη διατήρηση χώρου, ειδικά σε μικρά διαγράμματα.