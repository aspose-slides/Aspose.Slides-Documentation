---
title: "Προσαρμογή των αξόνων διαγράμματος στις παρουσιάσεις χρησιμοποιώντας JavaScript"
linktitle: "Άξονας διαγράμματος"
type: docs
url: /el/nodejs-java/chart-axis/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε JavaScript με το Aspose.Slides για Node.js μέσω Java για να προσαρμόσετε τους άξονες διαγράμματος σε παρουσιάσεις PowerPoint για αναφορές και απεικονίσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να λάβετε τις πραγματικές τιμές του άξονα, να ανταλλάξετε δεδομένα μεταξύ άξονων, να κρύψετε τον κάθετο ή οριζόντιο άξονα για γραμμικά διαγράμματα, να αλλάξετε τον τύπο του άξονα κατηγορίας, να ορίσετε τη μορφή ημερομηνίας για τις τιμές του άξονα κατηγορίας, να περιστρέψετε τον τίτλο του άξονα, να ορίσετε τη θέση του άξονα και να εμφανίσετε ετικέτα μονάδας στον άξονα τιμών.

## **Λήψη των Μέγιστων Τιμών στον Κάθετο Άξονα στα Διαγράμματα**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να λαμβάνετε τις ελάχιστες και μέγιστες τιμές σε έναν κάθετο άξονα. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation)class.
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα.
4. Λάβετε τη πραγματική μέγιστη τιμή στον άξονα.
5. Λάβετε τη πραγματική ελάχιστη τιμή στον άξονα.
6. Λάβετε τη πραγματική κύρια μονάδα του άξονα.
7. Λάβετε τη πραγματική δευτερεύουσα μονάδα του άξονα.
8. Λάβετε την πραγματική κλίμακα κύριας μονάδας του άξονα.
9. Λάβετε την πραγματική κλίμακα δευτερεύουσας μονάδας του άξονα.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Αποθηκεύει την παρουσίαση
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ανταλλαγή Δεδομένων μεταξύ Άξονων**

Το Aspose.Slides σας επιτρέπει να ανταλλάξετε γρήγορα τα δεδομένα μεταξύ άξονων — τα δεδομένα που εμφανίζονται στον κάθετο άξονα (y‑axis) μετακινούνται στον οριζόντιο άξονα (x‑axis) και αντίστροφα.

Αυτός ο κώδικας JavaScript δείχνει πώς να εκτελέσετε τη διαδικασία ανταλλαγής δεδομένων μεταξύ άξονων σε ένα διάγραμμα:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Αλλάζει τις γραμμές και τις στήλες
    chart.getChartData().switchRowColumn();
    // Αποθηκεύει την παρουσίαση
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Απενεργοποίηση του Κάθετου Άξονα για Γραμμικά Διαγράμματα**

Αυτός ο κώδικας JavaScript δείχνει πώς να κρύψετε τον κάθετο άξονα για ένα γραμμικό διάγραμμα:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Απενεργοποίηση του Οριζόντιου Άξονα για Γραμμικά Διαγράμματα**

Αυτός ο κώδικας δείχνει πώς να κρύψετε τον οριζόντιο άξονα για ένα γραμμικό διάγραμμα:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αλλαγή Άξονα Κατηγορίας**

Χρησιμοποιώντας την ιδιότητα **CategoryAxisType**, μπορείτε να ορίσετε τον προτιμώμενο τύπο άξονα κατηγορίας (**date** ή **text**). Αυτός ο κώδικας JavaScript δείχνει τη λειτουργία:

```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ορισμός Μορφής Ημερομηνίας για Τιμή Άξονα Κατηγορίας**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να ορίσετε τη μορφή ημερομηνίας για μια τιμή άξονα κατηγορίας. Η λειτουργία επιδεικνύεται σε αυτόν τον κώδικα JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```

## **Ορισμός Γωνίας Περιστροφής για Τίτλο Άξονα Διαγράμματος**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να ορίσετε τη γωνία περιστροφής για τον τίτλο άξονα ενός διαγράμματος. Αυτός ο κώδικας JavaScript δείχνει τη λειτουργία:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Θέσης Άξονα σε Άξονα Κατηγορίας ή Τιμής**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να ορίσετε τη θέση άξονα σε άξονα κατηγορίας ή τιμής. Αυτός ο κώδικας JavaScript δείχνει πώς να εκτελέσετε την εργασία:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ενεργοποίηση Εμφάνισης Ετικέτας Μονάδας στον Άξονα Τιμών Διαγράμματος**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να διαμορφώσετε ένα διάγραμμα ώστε να εμφανίζει ετικέτα μονάδας στον άξονα τιμών του διαγράμματος. Αυτός ο κώδικας JavaScript δείχνει τη λειτουργία:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Πώς ορίζω τη τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Οι άξονες παρέχουν μια [ρυθμίση διασταύρωσης](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/axis/setcrosstype/): μπορείτε να επιλέξετε να διασχίσουν στο μηδέν, στο μέγιστο της κατηγορίας/τιμής, ή σε μια συγκεκριμένη αριθμητική τιμή. Αυτό είναι χρήσιμο για τη μετακίνηση του άξονα X πάνω ή κάτω ή για την ανάδειξη μιας βασικής γραμμής.

**Πώς μπορώ να τοποθετήσω τις ετικέτες των tick σε σχέση με τον άξονα (πλαϊνά, έξω, μέσα);**

Ορίστε τη [θέση ετικέτας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/axis/setmajortickmark/) σε "cross", "outside" ή "inside". Αυτό επηρεάζει την αναγνωσιμότητα και βοηθά στην εξοικονόμηση χώρου, ειδικά σε μικρά διαγράμματα.