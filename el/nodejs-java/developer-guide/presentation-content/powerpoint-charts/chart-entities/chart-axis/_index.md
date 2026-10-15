---
title: "Προσαρμογή Αξόνων Διαγράμματος σε Παρουσιάσεις χρησιμοποιώντας JavaScript"
linktitle: "Άξονας Διαγράμματος"
type: docs
url: /el/nodejs-java/chart-axis/
keywords:
- "άξονας διαγράμματος"
- "κάθετος άξονας"
- "οριζόντιος άξονας"
- "προσαρμογή άξονα"
- "χειρισμός άξονα"
- "διαχείριση άξονα"
- "ιδιότητες άξονα"
- "μέγιστη τιμή"
- "ελάχιστη τιμή"
- "γραμμή άξονα"
- "μορφή ημερομηνίας"
- "τίτλος άξονα"
- "θέση άξονα"
- "PowerPoint"
- "παρουσίαση"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε τη JavaScript με το Aspose.Slides για Node.js μέσω Java για να προσαρμόσετε τους άξονες διαγράμματος σε παρουσιάσεις PowerPoint για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες διαγραμμάτων με το Aspose.Slides για Node.js μέσω Java. Καλύπτει τις υπολογιζόμενες τιμές άξονα, την εναλλαγή γραμμών και στηλών διαγράμματος, την ορατότητα του άξονα, τα διαστήματα ετικετών κατηγορίας και σημείων σκαλοπατιών, τις ημερομηνίες κατηγοριών και τη μορφοποίηση, την περιστροφή του τίτλου, τη θέση του άξονα, τις μονάδες εμφάνισης και την λογαριθμική κλιμάκωση.

## **Λήψη των Μέγιστων Τιμών στον Κάθετο Άξονα των Διαγραμμάτων**

Δημιουργήστε ένα [Παρουσίαση](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) και προσθέστε ένα γράφημα περιοχής με προεπιλεγμένα δεδομένα. Καλέστε το [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) πριν διαβάσετε τις υπολογιζόμενες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε το [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) και το [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) για τα όρια του άξονα, και τα [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) και [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) για τα διαστήματα σημείων. Τα [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) και [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) παρέχουν κλίμακες μονάδας χρόνου, οι οποίες είναι σχετικές με άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ανταλλαγή των Δεδομένων μεταξύ των Αξόνων**

Χρησιμοποιήστε το [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα διαγράμματος. Κάθε προηγούμενη κατηγορία γίνεται σειρά, και κάθε προηγούμενη σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κατακόρυφους άξονες. Το παράδειγμα χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) για να συνδέσει τα προεπιλεγμένα δεδομένα με `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγορίας, πριν την εναλλαγή σειρών και στηλών. Αποθηκεύει ένα γράφημα με τέσσερις σειρές και τρεις κατηγορίες.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αντιστροφή της Σειράς Σχεδίασης ενός Άξονα**

Χρησιμοποιήστε το [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) για να αντιστρέψετε έναν άξονα κατηγορίας ή τιμής. Για παράδειγμα, ένα οριζόντιο γράφημα ράβδων μπορεί να εμφανίζει τα στάδια του έργου από πάνω προς τα κάτω με την ίδια σειρά όπως το φύλλο εργασίας: Σχεδιασμός, Ανάπτυξη, Δοκιμές. Η αντιστροφή ενός άξονα αλλάζει την κατεύθυνση σχεδίασης· δεν ταξινομεί ή ανασυντάσσει τα δεδομένα του βιβλίου εργασίας. Σε σύγκριση, το [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) ανταλλάσσει τους ρόλους των σειρών και των κατηγοριών.

Το παρακάτω παράδειγμα δημιουργεί ένα οριζόντιο γράφημα ράβδων με τρία στάδια και μια σειρά. Αποθηκεύει μια παρουσίαση με τρία διαφάνειες: κανονική σειρά, αντιστροφή κατηγοριών, και αντιστροφή τιμών. Κάθε αντίγραφο χρησιμοποιεί το ίδιο σύνολο δεδομένων, και μόνο ένας άξονας είναι αντιστραμμένος σε κάθε αντίγραφο.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Διαφάνεια 2: εμφανίστε την πρώτη κατηγορία στην κορυφή.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Διατηρήστε τον οριζόντιο άξονα τιμής στο κάτω μέρος.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Διαφάνεια 3: αντιστρέψτε μόνο την οριζόντια αριθμητική κλίμακα.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αντιστροφή ενός άξονα μπορεί επίσης να μετακινήσει τον κάθετο άξονα στην αντίθετη πλευρά του γραφήματος. Το [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) ελέγχει πού ο άλλος άξονας διασχίζει τον άξονα που διαμορφώνεται. Στη διαφάνεια 2, καλώντας το με `aspose.slides.CrossesType.Maximum` στον αντιστραμμένο άξονα κατηγορίας κρατά τον οριζόντιο άξονα τιμής στο κάτω μέρος. Για συγκεκριμένο σημείο διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Ελέγξτε τις ρυθμίσεις διασταύρωσης όταν αλλάζετε κατεύθυνση, ιδιαίτερα αν το γράφημα έχει ήδη προσαρμοσμένο σημείο διασταύρωσης. Καλέστε `setPlotOrderReversed` με `false` για να επαναφέρετε την κανονική κατεύθυνση σχεδίασης· οι ρυθμίσεις διασταύρωσης είναι ξεχωριστές.

| Κανονική σειρά (διαφάνεια 1) | Αντιστροφή κατηγοριών (διαφάνεια 2) | Αντιστροφή τιμών (διαφάνεια 3) |
| --- | --- | --- |
| ![Οριζόντιο γράφημα ράβδων με κανονική σειρά κατηγορίας και αξόνων τιμής](axis-order-normal.png) | ![Οριζόντιο γράφημα ράβδων με κατηγορίες που εμφανίζονται από πάνω προς τα κάτω](axis-order-categories-reversed.png) | ![Οριζόντιο γράφημα ράβδων με αντιστραμμένο άξονα τιμής και μηδέν στα δεξιά](axis-order-values-reversed.png) |
| Οι κατηγορίες τρέχουν από κάτω προς τα πάνω· οι τιμές αυξάνονται από αριστερά προς δεξιά. | Σχεδιασμός, Ανάπτυξη και Δοκιμές τρέχουν από πάνω προς τα κάτω. Οι τιμές και η σειρά των γραμμών του βιβλίου εργασίας παραμένουν αμετάβλητες. | Οι κατηγορίες διατηρούν την κανονική τους σειρά· οι τιμές αυξάνονται από δεξιά προς αριστερά. Ο άξονας κατηγορίας διαστέλλεται στο μηδέν στα δεξιά. |

## **Απενεργοποίηση του Κάθετου Άξονα για Γραμμικά Διαγράμματα**

Καλέστε το [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) με `false` στον κάθετο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γραμμικό γράφημα με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κάθετο άξονα κρυφό.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Απενεργοποίηση του Οριζόντιου Άξονα για Γραμμικά Διαγράμματα**

Καλέστε το [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) με `false` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γραμμικό γράφημα με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυφό.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αλλαγή Άξονα Κατηγορίας**

Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) για να επιλέξετε έναν άξονα κατηγορίας ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα γράφημα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τα κελιά κατηγορίας να περιέχουν αριθμητικές τιμές ημερομηνίας Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Καλώντας το [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) με `false`, το [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) με `1`, και το [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) με `TimeUnitType.Months` τοποθετεί τα κύρια σημεία σε διαστήματα ενός μήνα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Διαστημάτων Ετικετών Άξονα Κατηγορίας**

Όταν ένα γράφημα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Καλέστε το [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) με `false`, στη συνέχεια περάστε το επιθυμητό διάστημα κατηγορίας στο [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Για κατηγορίες κειμένου στην κανονική τους σειρά, η αρίθμηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Κατηγορία 1, Κατηγορία 2, Κατηγορία 3, ... Κατηγορία 24 |
| `2` | Κατηγορία 1, Κατηγορία 3, Κατηγορία 5, ... Κατηγορία 23 |
| `3` | Κατηγορία 1, Κατηγορία 4, Κατηγορία 7, ... Κατηγορία 22 |

Ένα διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων ετικετών. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη απόσταση επιλέγει διάστημα βάσει του διαθέσιμου χώρου· δεν εμφανίζει απαραίτητα κάθε ετικέτα.

Τα σημεία σκαλοπατιών έχουν ξεχωριστούς ελέγχους. Καλέστε το [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) με `false` και χρησιμοποιήστε το [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) για να ορίσετε το διάστημά τους. Για παράδειγμα, `1` διατηρεί ένα σημείο σκαλοπατιού σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) με ένα ορατό στυλ ώστε να μπορείτε να δείτε το αποτέλεσμα. Η κλήση οποιουδήποτε αυτόματου ρυθμιστή με `true` ξανά επιτρέπει στο γράφημα να επιλέξει ξανά αυτό το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, μετά αποθηκεύει τρεις διαφάνειες στο `CategoryAxisIntervals.pptx`: αυτόματη απόσταση, χειροκίνητη απόσταση ετικετών με ανεξάρτητα σημεία σκαλοπατιών, και επαναφορά της αυτόματης απόστασης. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται παρουσίαση εισόδου. Το οριζόντιο κείμενο ετικέτας κάνει τη διαφορά στην πυκνότητα εύκολα ορατή.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Διαφάνεια 2: εμφανίστε κάθε τρίτη ετικέτα, αλλά διατηρήστε σημείο σκαλοπατιού για κάθε κατηγορία.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Διαφάνεια 3: αφήστε το γράφημα να επιλέξει ξανά και τα δύο διαστήματα.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Αυτόματη απόσταση (διαφάνεια 1):** Σε αυτήν την απόδοση, κάθε δεύτερη ετικέτα κατηγορίας εμφανίζεται και τυλίγεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και το σύστημα απόδοσης.

![Αυτόματη απόσταση ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητη απόσταση (διαφάνεια 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μία γραμμή, ενώ τα σημεία σκαλοπατιών παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων των εκείνων χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Χειροκίνητο διάστημα ετικετών κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλογή του Σωστού Άξονα και Διαστήματος**

Χρησιμοποιήστε αυτό το διάστημα καταμέτρησης κατηγοριών για έναν άξονα κειμενικής κατηγορίας, όπως ο άξονας κατηγορίας σε γράφημα στήλης, γραμμής, περιοχής ή ράβδου. Σε γράφημα στήλης, είναι ο οριζόντιος άξονας. Σε οριζόντιο γράφημα ράβδων, ο άξονας κατηγορίας είναι κάθετος, οπότε εφαρμόστε αυτές τις ρυθμίσεις στον άξονα που επιστρέφει το [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Η απόσταση σημείων σκαλοπατιών ισχύει επίσης για άξονα σειράς σε γραφήματα που τον έχουν.

Μην χρησιμοποιείτε την απόσταση ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμής. Σε άξονα τιμής, το [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) καθορίζει διαφορά τιμών: για παράδειγμα, μια κύρια μονάδα `10` δημιουργεί σημεία στα 0, 10, 20 κλπ. όταν ο άξονας ξεκινά από το μηδέν. Μια ετικέτα κατηγορίας με διάστημα `3` μετρά τις θέσεις κατηγορίας, ανεξάρτητα από τις τιμές δεδομένων. Τα γράφηματα διασποράς και φυσαλίδων χρησιμοποιούν άξονες τιμής αντί για άξονα κειμενικής κατηγορίας. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες και κλίμακες βάσει χρόνου όπως περιγράφεται στην [Αλλαγή Άξονα Κατηγορίας](#change-a-category-axis).

## **Ορισμός Μορφής Ημερομηνίας για Τιμές Άξονα Κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα του διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειρές αριθμών OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`), υπολογιζόμενες ως ο αριθμός ημερών από τις 30 Δεκεμβρίου 1899 για αυτές τις ημερομηνίες. Η JavaScript υπολογισμός χρησιμοποιεί χρονικές σφραγίδες UTC και διαιρεί τη διαφορά με 86 400 000 χιλιοστά του δευτερολέπτου ανά ημέρα. Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) με `CategoryAxisType.Date`, καλέστε το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) με `false`, και περάστε `yyyy` στο [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) ώστε οι ετικέτες κατηγορίας να εμφανίζουν έτη τετραψήφια ανεξάρτητα από τη μορφοποίηση των κελιών.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Γωνίας Περιστροφής για Τίτλο Άξονα Διαγράμματος**

Καλέστε το [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) με `true` στον κάθετο άξονα, παρέχετε το κείμενο του τίτλου, και χρησιμοποιήστε το [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα γράφημα στήλης με τον τίτλο του άξονα τιμών περιστραμμένο κατά 90 μοίρες.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Θέσης Άξονα σε Άξονα Κατηγορίας ή Τιμής**

Χρησιμοποιήστε το [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) για να ελέγξετε αν ο άξονας τιμής διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία σκαλοπατιών των κατηγοριών. Αυτή η ρύθμιση εφαρμόζεται σε άξονες κατηγορίας. Το παράδειγμα το ορίζει σε `true` στον οριζόντιο άξονα κατηγορίας ενός διαγράμματος στήλης και αποθηκεύει το αποτέλεσμα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Μονάδας Εμφάνισης σε Άξονα Τιμής Διαγράμματος**

Χρησιμοποιήστε το [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) για να κλιμακώσετε τις ετικέτες σε άξονα τιμής χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) ορισμένο σε `Millions`, μια τιμή των 60 000 000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα γράφημα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κάθετο άξονά του.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διαμόρφωση Λογαριθμικού Άξονα Τιμής**

Ένας λογαριθμικός άξονας τιμής είναι χρήσιμος όταν θετικές τιμές καλύπτουν πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1 000, 10 000 και 100 000 αιτήσεις σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται κοντά μεταξύ τους κοντά στο μηδέν. Μια λογαριθμική κλίμακα κάνει τη σχετική τους αύξηση πιο συγκρίσιμη: ίσες αποστάσεις αντιπροσωπεύουν ίσους λόγους αντί για ίσες διαφορές.

Καλέστε το [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) με `true` στον άξονα τιμής και χρησιμοποιήστε το [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υπαρχουσών τιμών· δεν αλλάζει τα δεδομένα ή προσθέτει λογαριθμική γραμμή τάσεων. Μια γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και αποτελεί ξεχωριστή λειτουργία.

### **Επιλογή Άξονα Τιμής και Βάσης**

Για γραφικό γράφημα γραμμής ή στήλης, ο άξονας τιμής επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Για οριζόντιο γράφημα ράβδων, επιστρέφεται από το [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Τα γραφήματα διασποράς και φυσαλίδων έχουν δύο άξονες τιμής, οπότε επιλέξτε τον οριζόντιο άξονα για τις τιμές X, τον κάθετο για τις τιμές Y, ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλίμακα σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένης· υποστηρίζονται και κλασματικές βάσεις όπως `2.5`. Με βάση `10`, διαδοχικές δυνάμεις όπως 10, 100, 1 000 και 10 000 είναι ίσα διακριτά.

### **Σύγκριση Γραμμικής και Λογαριθμικής Κλιμάκωσης**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γράφημα γραμμής με τις πέντε μετρήσεις αιτήσεων στη πρώτη διαφάνεια, στη συνέχεια κλωνοποιεί τη διαφάνεια και ενεργοποιεί λογαριθμικό άξονα τιμής βάσης‑10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Διατηρήστε την πρώτη διαφάνεια γραμμική και αλλάξτε μόνο την κλίμακα του άξονα τιμών του αντιγράφου.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Γραμμική κλίμακα (διαφάνεια 1):** Ίσες κατακόρτιες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτήσεων. Η μεγαλύτερη τιμή κυριαρχεί στο γράφημα, καθιστώντας τις μικρότερες τιμές δύσκολες στην διάκριση.

![Γραμμικό γράφημα στο PowerPoint που εμφανίζει πέντε μετρήσεις αιτήσεων σε γραμμικό άξονα τιμής](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ίσες κατακόρτιες αποστάσεις αντιπροσωπεύουν ίσους λόγους. Κάθε περίοδος έχει δέκα φορές περισσότερες αιτήσεις από την προηγούμενη, έτσι τα σημεία σχηματίζουν μια ευθεία αυξανόμενη γραμμή στην κλίμακα βάσης‑10. Οι ετικέτες του άξονα εξακολουθούν να δείχνουν τις αρχικές μετρήσεις αιτήσεων.

![Οι ίδιες πέντε μετρήσεις αιτήσεων σε PowerPoint σε άξονα τιμής λογαριθμικό βάσης 10](value-axis-logarithmic.png)

### **Διαχείριση Μηδενικών και Αρνητικών Τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίζει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Αν μηδενικές ή αρνητικές τιμές είναι σημαντικές, διατηρήστε γραμμική κλίμακα ή παρουσιάστε τες ξεχωριστά. Αν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μην αντικαθιστάτε σιωπηρά τις τιμές με μικρά θετικά νούμερα, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιαδήποτε χειροκίνητη ρύθμιση ελάχιστου ή μέγιστου για λογαριθμικό άξονα πρέπει επίσης να είναι θετική.

## **Συχνές Ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (Διασταύρωση άξονα);**

Χρησιμοποιήστε το [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να ορίσετε αριθμητική τιμή διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση άξονα σε κατάλληλο βασικό σημείο.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημείων σκαλοπατιών σχετικά με τον άξονα;**

Καλέστε το [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για έλεγχο των σημείων σκαλοπατιών καθ' αυτά, χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) ή το [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); αυτά είναι ξεχωριστά από τη θέση των ετικετών.