---
title: Προσαρμογή Αξόνων Διαγράμματος σε Παρουσιάσεις Χρησιμοποιώντας Java
linktitle: Άξονας Διαγράμματος
type: docs
url: /el/java/chart-axis/
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
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides for Java για να προσαρμόσετε τους άξονες διαγράμματος σε παρουσιάσεις PowerPoint για εκθέσεις και απεικονίσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε άξονες διαγραμμάτων στο Aspose.Slides. Δειχνει πώς να λάβετε τις πραγματικές τιμές του άξονα, να ανταλλάξετε δεδομένα μεταξύ αξόνων, να αποκρύψετε τον κάθετο ή οριζόντιο άξονα για γραμμικά διαγράμματα, να αλλάξετε τον τύπο του άξονα κατηγορίας, να ορίσετε τη μορφή ημερομηνίας για τις τιμές του άξονα κατηγορίας, να περιστρέψετε έναν τίτλο άξονα, να ορίσετε τη θέση του άξονα και να εμφανίσετε μια ετικέτα μονάδας στον άξονα τιμών.

## **Λήψη των μέγιστων τιμών στον κάθετο άξονα σε διαγράμματα**
Aspose.Slides for Java σας επιτρέπει να λάβετε τις ελάχιστες και μέγιστες τιμές σε έναν κάθετο άξονα. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Πάρτε την πρώτη διαφάνεια.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα.
1. Λάβετε την πραγματική μέγιστη τιμή στον άξονα.
1. Λάβετε την πραγματική ελάχιστη τιμή στον άξονα.
1. Λάβετε την πραγματική κύρια μονάδα του άξονα.
1. Λάβετε την πραγματική δευτερεύουσα μονάδα του άξονα.
1. Λάβετε την πραγματική κλίμακα κύριας μονάδας του άξονα.
1. Λάβετε την πραγματική κλίμακα δευτερεύουσας μονάδας του άξονα.

Αυτό το δείγμα κώδικα—μια υλοποίηση των παραπάνω βημάτων—δείχνει πώς να λάβετε τις απαιτούμενες τιμές σε Java:

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

## **Ανταλλαγή Δεδομένων μεταξύ Αξόνων**
Το Aspose.Slides σας επιτρέπει να ανταλλάξετε γρήγορα τα δεδομένα μεταξύ των αξόνων—τα δεδομένα που εμφανίζονται στον κάθετο άξονα (y-άξονας) μετακινούνται στον οριζόντιο άξονα (x-άξονας) και αντίστροφα.

Αυτός ο κώδικας Java δείχνει πώς να εκτελέσετε την εργασία ανταλλαγής δεδομένων μεταξύ αξόνων σε ένα διάγραμμα:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Ανταλλάσσει γραμμές και στήλες
	// Αποθηκεύει παρουσίαση
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Απενεργοποίηση του Κάθετου Άξονα για Γραμμικά Διαγράμματα**

Αυτός ο κώδικας Java δείχνει πώς να αποκρύψετε τον κάθετο άξονα για ένα γραμμικό διάγραμμα:

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

## **Απενεργοποίηση του Οριζόντιου Άξονα για Γραμμικά Διαγράμματα**

Αυτός ο κώδικας δείχνει πώς να αποκρύψετε τον οριζόντιο άξονα για ένα γραμμικό διάγραμμα:

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

## **Αλλαγή Άξονα Κατηγορίας**

Χρησιμοποιώντας την ιδιότητα **CategoryAxisType**, μπορείτε να καθορίσετε τον προτιμώμενο τύπο άξονα κατηγορίας (**date** ή **text**). Αυτός ο κώδικας σε Java δείχνει τη λειτουργία:

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

## **Ορισμός Μορφής Ημερομηνίας για Τιμές Άξονα Κατηγορίας**
Το Aspose.Slides for Java σας επιτρέπει να ορίσετε τη μορφή ημερομηνίας για μια τιμή άξονα κατηγορίας. Η λειτουργία δείχνεται σε αυτόν τον κώδικα Java:

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

## **Ορισμός Γωνίας Περιστροφής για Τίτλο Άξονα Διαγράμματος**
Το Aspose.Slides for Java σας επιτρέπει να ορίσετε τη γωνία περιστροφής για έναν τίτλο άξονα διαγράμματος. Αυτός ο κώδικας Java δείχνει τη λειτουργία:

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

## **Ορισμός Θέσης Άξονα σε Άξονα Κατηγορίας ή Τιμής**
Το Aspose.Slides for Java σας επιτρέπει να ορίσετε τη θέση του άξονα σε άξονα κατηγορίας ή τιμής. Αυτός ο κώδικας Java δείχνει πώς να εκτελέσετε την εργασία:

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

## **Ενεργοποίηση Εμφάνισης Ετικέτας Μονάδας στον Άξονα Τιμών Διαγράμματος**
Το Aspose.Slides for Java σας επιτρέπει να διαμορφώσετε ένα διάγραμμα ώστε να εμφανίζει ετικέτα μονάδας στον άξονα τιμών του διαγράμματος. Αυτός ο κώδικας Java δείχνει τη λειτουργία:

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

## **FAQ**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασύνδεση άξονα);**

Οι άξονες παρέχουν μια [ρύθμιση διασύνδεσης](https://reference.aspose.com/slides/el/java/com.aspose.slides/axis/#setCrossType-int-): μπορείτε να επιλέξετε να διασχίσετε στο μηδέν, στο μέγιστο της κατηγορίας/τιμής, ή σε μια συγκεκριμένη αριθμητική τιμή. Αυτό είναι χρήσιμο για τη μετακίνηση του X‑άξονα προς τα πάνω ή κάτω ή για την ανάδειξη μιας βάσης.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημείων σχετικά με τον άξονα (πλάι, έξω, μέσα);**

Ορίστε τη [θέση ετικέτας](https://reference.aspose.com/slides/el/java/com.aspose.slides/axis/#setMajorTickMark-int-) σε "cross", "outside" ή "inside". Αυτό επηρεάζει την αναγνωσιμότητα και βοηθά στη εξοικονόμηση χώρου, ειδικά σε μικρά διαγράμματα.