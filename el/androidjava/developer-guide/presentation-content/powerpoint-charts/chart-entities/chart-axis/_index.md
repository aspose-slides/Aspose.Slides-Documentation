---
title: Προσαρμογή αξόνων διαγραμμάτων σε παρουσιάσεις σε Android
linktitle: Άξονας διαγράμματος
type: docs
url: /el/androidjava/chart-axis/
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
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για Android μέσω Java για την προσαρμογή των αξόνων διαγραμμάτων σε παρουσιάσεις PowerPoint για εκθέσεις και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες των διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να λάβετε τις πραγματικές τιμές των αξόνων, να ανταλλάξετε δεδομένα μεταξύ αξόνων, να κρύψετε τον κατακόρυφο ή οριζόντιο άξονα σε διαγράμματα γραμμής, να αλλάξετε τον τύπο του άξονα κατηγορίας, να ορίσετε τη μορφή ημερομηνίας για τις τιμές του άξονα κατηγορίας, να περιστρέψετε τον τίτλο ενός άξονα, να ορίσετε τη θέση του άξονα και να εμφανίσετε μια ετικέτα μονάδας στον άξονα τιμών.

## **Απόκτηση των μέγιστων τιμών στον κατακόρυφο άξονα στα διαγράμματα**
Aspose.Slides for Android via Java σάς επιτρέπει να λάβετε τις ελάχιστες και μέγιστες τιμές σε έναν κατακόρυφο άξονα. Ακολουθήστε αυτά τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα.
1. Λάβετε τη πραγματική μέγιστη τιμή του άξονα.
1. Λάβετε τη πραγματική ελάχιστη τιμή του άξονα.
1. Λάβετε τη πραγματική κύρια μονάδα του άξονα.
1. Λάβετε τη πραγματική δευτερεύουσα μονάδα του άξονα.
1. Λάβετε την πραγματική κλίμακα της κύριας μονάδας του άξονα.
1. Λάβετε την πραγματική κλίμακα της δευτερεύουσας μονάδας του άξονα.

Αυτός ο κώδικας δείγματος — μια υλοποίηση των παραπάνω βημάτων — δείχνει πώς να λάβετε τις απαιτούμενες τιμές σε Java:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Αποθηκεύει την παρουσίαση
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ανταλλαγή δεδομένων μεταξύ αξόνων**
Aspose.Slides σάς επιτρέπει να ανταλλάξετε γρήγορα τα δεδομένα μεταξύ των αξόνων — τα δεδομένα που εμφανίζονται στον κατακόρυφο άξονα (y‑axis) μεταφέρονται στον οριζόντιο άξονα (x‑axis) και αντίστροφα.

Αυτός ο κώδικας Java δείχνει πώς να πραγματοποιήσετε την ανταλλαγή δεδομένων μεταξύ αξόνων σε ένα γράφημα:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Ανταλλάσσει σειρές και στήλες
	//Αποθηκεύει την παρουσίαση
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Απενεργοποίηση του κατακόρυφου άξονα για διαγράμματα γραμμής**

Αυτός ο κώδικας Java δείχνει πώς να κρύψετε τον κατακόρυφο άξονα για ένα διάγραμμα γραμμής:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Απενεργοποίηση του οριζόντιου άξονα για διαγράμματα γραμμής**

Αυτός ο κώδικας δείχνει πώς να κρύψετε τον οριζόντιο άξονα για ένα διάγραμμα γραμμής:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Αλλαγή άξονα κατηγορίας**

Χρησιμοποιώντας την ιδιότητα **CategoryAxisType**, μπορείτε να ορίσετε τον προτιμώμενο τύπο άξονα κατηγορίας (**date** ή **text**). Αυτός ο κώδικας σε Java επιδεικνύει τη λειτουργία:

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

## **Ορισμός μορφής ημερομηνίας για τιμές άξονα κατηγορίας**
Aspose.Slides for Android via Java σάς επιτρέπει να ορίσετε τη μορφή ημερομηνίας για μια τιμή άξονα κατηγορίας. Η λειτουργία επιδεικνύεται σε αυτόν τον κώδικα Java:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **Ορισμός γωνίας περιστροφής για τίτλο άξονα γραφήματος**
Aspose.Slides for Android via Java σάς επιτρέπει να ορίσετε τη γωνία περιστροφής για έναν τίτλο άξονα γραφήματος. Αυτός ο κώδικας Java επιδεικνύει τη λειτουργία:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **Ορισμός θέσης άξονα σε άξονα κατηγορίας ή τιμής**
Aspose.Slides for Android via Java σάς επιτρέπει να ορίσετε τη θέση άξονα σε έναν άξονα κατηγορίας ή τιμής. Αυτός ο κώδικας Java δείχνει πώς να εκτελέσετε την εργασία:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ενεργοποίηση ετικέτας μονάδας εμφάνισης στον άξονα τιμής γραφήματος**
Aspose.Slides for Android via Java σάς επιτρέπει να διαμορφώσετε ένα γράφημα ώστε να εμφανίζει ετικέτα μονάδας στον άξονα τιμών του. Αυτός ο κώδικας Java επιδεικνύει τη λειτουργία:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση αξόνων);**

Οι άξονες παρέχουν μια [ρύθμιση διασταύρωσης](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/axis/#setCrossType-int-): μπορείτε να επιλέξετε διασταύρωση στο μηδέν, στη μέγιστη κατηγορία/τιμή ή σε συγκεκριμένη αριθμητική τιμή. Αυτό είναι χρήσιμο για μετακίνηση του άξονα X πάνω ή κάτω ή για έμφαση σε μια βασική γραμμή.

**Πώς μπορώ να τοποθετήσω τις ετικέτες των κεντών σε σχέση με τον άξονα (πλάι, έξω, μέσα);**

Ορίστε τη [θέση ετικέτας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) σε "cross", "outside" ή "inside". Αυτό επηρεάζει την αναγνωσιμότητα και βοηθά στη εξοικονόμηση χώρου, ειδικά σε μικρά διαγράμματα.