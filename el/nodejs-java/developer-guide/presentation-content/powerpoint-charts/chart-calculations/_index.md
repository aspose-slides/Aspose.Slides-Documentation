---
title: Βελτιστοποίηση υπολογισμών γραφήματος για παρουσιάσεις σε JavaScript
linktitle: Υπολογισμοί γραφήματος
type: docs
weight: 50
url: /el/nodejs-java/chart-calculations/
keywords:
- υπολογισμοί γραφήματος
- στοιχεία γραφήματος
- θέση στοιχείου
- πραγματική θέση
- θυγατρικό στοιχείο
- γονικό στοιχείο
- τιμές γραφήματος
- πραγματική τιμή
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Κατανοήστε τους υπολογισμούς γραφήματος, τις ενημερώσεις δεδομένων και τον έλεγχο ακρίβειας στο Aspose.Slides για Node.js για PPT και PPTX, με πρακτικά παραδείγματα κώδικα JavaScript."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει APIs για εργασία με τους υπολογισμούς γραφημάτων και τα δεδομένα διάταξης σε παρουσιάσεις. Αυτό το άρθρο δείχνει πώς να ανακτήσετε τις πραγματικές τιμές των στοιχείων του γραφήματος, συμπεριλαμβανομένης της πραγματικής θέσης και μεγέθους των στοιχείων και των πραγματικών τιμών των αξόνων του γραφήματος. Επίσης εξηγεί ότι αυτές οι τιμές γεμίζουν μετά την επικύρωση της διάταξης του γραφήματος.

Επιπλέον, το άρθρο δείχνει πώς να λάβετε τη πραγματική θέση των γονικών στοιχείων του γραφήματος και πώς να κρύψετε τα στοιχεία του γραφήματος όπως ο τίτλος, οι άξονες, το υπόμνημα και οι γραμμές πλέγματος. Μαζί, αυτά τα παραδείγματα σας βοηθούν να ελέγξετε τις πληροφορίες διάταξης του γραφήματος και να ελέγξετε την ορατότητα των στοιχείων του γραφήματος σε παρουσιάσεις PowerPoint προγραμματικά.

## **Υπολογισμός Πραγματικών Τιμών Στοιχείων Γραφήματος**

Το Aspose.Slides for Node.js μέσω Java παρέχει ένα απλό API για την λήψη αυτών των ιδιοτήτων. Οι ιδιότητες της κλάσης [Axis](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Axis) παρέχουν πληροφορίες για την πραγματική θέση του στοιχείου άξονα του γραφήματος ([Axis.getActualMaxValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Είναι απαραίτητο να καλέσετε τη μέθοδο [Chart.validateChartLayout()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Chart#validateChartLayout--) προηγουμένως για να γεμίσουν οι ιδιότητες με τις πραγματικές τιμές.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Υπολογισμός Πραγματικής Θέσης Γονικών Στοιχείων Γραφήματος**

Το Aspose.Slides for Node.js μέσω Java παρέχει ένα απλό API για την λήψη αυτών των ιδιοτήτων. Οι ιδιότητες της κλάσης `ActualLayout` παρέχουν πληροφορίες για την πραγματική θέση του γονικού στοιχείου του γραφήματος `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. Είναι απαραίτητο να καλέσετε τη μέθοδο [Chart.validateChartLayout()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Chart#validateChartLayout--) προηγουμένως για να γεμίσουν οι ιδιότητες με τις πραγματικές τιμές.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Απόκρυψη Πληροφοριών από το Γράφημα**

Αυτό το θέμα σας βοηθά να καταλάβετε πώς να κρύψετε πληροφορίες από το γράφημα. Χρησιμοποιώντας το Aspose.Slides for Node.js μέσω Java μπορείτε να κρύψετε **Τίτλο, Κάθετο Άξονα, Οριζόντιο Άξονα** και **Γραμμές Πλέγματος** από το γράφημα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να χρησιμοποιήσετε αυτές τις ιδιότητες.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Απόκρυψη τίτλου γραφήματος
    chart.setTitle(false);
    // /Απόκρυψη άξονα τιμών
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Ορατότητα άξονα κατηγορίας
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Απόκρυψη λεζάντας
    chart.setLegend(false);
    // Απόκρυψη κύριων γραμμών πλέγματος
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Ορισμός χρώματος γραμμής σειράς
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορούν εξωτερικά βιβλία εργασίας Excel να λειτουργούν ως πηγή δεδομένων, και πώς αυτό επηρεάζει τον επαναϋπολογισμό;**

Ναι. Ένα γράφημα μπορεί να κάνει αναφορά σε εξωτερικό βιβλίο εργασίας: όταν συνδέεστε ή ανανεώνετε την εξωτερική πηγή, οι τύποι και οι τιμές λαμβάνονται από εκείνο το βιβλίο, και το γράφημα αντανακλά τις ενημερώσεις κατά τις λειτουργίες ανοίγματος/επεξεργασίας. Το API σας επιτρέπει να [να καθορίσετε το εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) path και να διαχειριστείτε τα συνδεδεμένα δεδομένα.

**Μπορώ να υπολογίσω και να εμφανίσω γραμμές τάσης χωρίς να υλοποιήσω εγώ τη παλινδρόμηση;**

Ναι. [Γραμμές τάσης](/slides/el/nodejs-java/trend-line/) (γραμμικές, εκθετικές και άλλες) προστίθενται και ενημερώνονται από το Aspose.Slides· οι παράμετροι τους επαναϋπολογίζονται αυτόματα από τα δεδομένα της σειράς, έτσι δεν χρειάζεται να υλοποιήσετε τους δικούς σας υπολογισμούς.

**Εάν μια παρουσίαση έχει πολλά γραφήματα με εξωτερικούς συνδέσμους, μπορώ να ελέγξω ποιο βιβλίο εργασίας χρησιμοποιεί κάθε γράφημα για τις υπολογιζόμενες τιμές;**

Ναι. Κάθε γράφημα μπορεί να δείχνει στο δικό του [εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), ή μπορείτε να δημιουργήσετε/αντικαταστήσετε ένα εξωτερικό βιβλίο εργασίας ανά γράφημα ανεξάρτητα από τα άλλα.