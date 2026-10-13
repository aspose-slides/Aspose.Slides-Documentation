---
title: Προσαρμογή των αξόνων των διαγραμμάτων σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Άξονας διαγράμματος
type: docs
url: /el/nodejs-java/chart-axis/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε JavaScript με το Aspose.Slides για Node.js μέσω Java για να προσαρμόσετε τους άξονες των διαγραμμάτων σε παρουσιάσεις PowerPoint για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες των διαγραμμάτων με το Aspose.Slides για Node.js μέσω Java. Καλύπτει υπολογισμένες τιμές άξονα, εναλλαγή σειρών και στηλών διαγράμματος, ορατότητα άξονα, διαστήματα ετικετών κατηγορίας και σημείων στίγματος, ημερομηνίες κατηγοριών και μορφοποίηση, περιστροφή τίτλου, τοποθέτηση άξονα, μονάδες εμφάνισης και λογαριθμική κλιμάκωση.

## **Λήψη των μέγιστων τιμών στον κατακόρυφο άξονα στα διαγράμματα**

Δημιουργήστε μια [Παρουσίαση](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) και προσθέστε ένα διάγραμμα περιοχής με προεπιλεγμένα δεδομένα. Καλέστε το [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) πριν διαβάσετε τις υπολογισμένες τιμές του άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε τα [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) και [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) για τα όρια του άξονα, και τα [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) και [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) για τα διαστήματα των σημείων στίγματος. Τα [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) και [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) παρέχουν κλίμακες μονάδων χρόνου, οι οποίες είναι σχετικές με τους άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

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

## **Αντάλλαγμα των δεδομένων μεταξύ άξονων**

Χρησιμοποιήστε το [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα του διαγράμματος. Κάθε παλιότερη κατηγορία γίνεται σειρά, και κάθε παλιότερη σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κατακόρυφους άξονες. Το παράδειγμα χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) για να συνδέσει τα προεπιλεγμένα δεδομένα με `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγοριών, πριν την εναλλαγή σειρών και στηλών. Αποθηκεύει ένα διάγραμμα με τέσσερις σειρές και τρεις κατηγορίες.

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

## **Απενεργοποίηση του κατακόρυφου άξονα για διαγράμματα γραμμής**

Καλέστε το [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) με `false` στον κατακόρυφο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κατακόρυφο άξονα κρυμμένο.

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

## **Απενεργοποίηση του οριζόντιου άξονα για διαγράμματα γραμμής**

Καλέστε το [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) με `false` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυμμένο.

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

## **Αλλαγή άξονα κατηγορίας**

Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) για να επιλέξετε ένα άξονα κατηγορίας ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας του Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Καλώντας το [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) με `false`, το [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) με `1` και το [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) με `TimeUnitType.Months` τοποθετεί τους κύριους στίγματες σε διαστήματα ενός μήνα.

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

## **Έλεγχος διαστημάτων ετικετών άξονα κατηγορίας**

Όταν ένα διάγραμμα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Καλέστε το [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) με `false`, και στη συνέχεια περάστε το επιθυμητό διάστημα κατηγορίας στο [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Για κατηγορίες κειμένου στην κανονική τους σειρά, η απαρίθμηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Κατηγορία 1, Κατηγορία 2, Κατηγορία 3, … Κατηγορία 24 |
| `2` | Κατηγορία 1, Κατηγορία 3, Κατηγορία 5, … Κατηγορία 23 |
| `3` | Κατηγορία 1, Κατηγορία 4, Κατηγορία 7, … Κατηγορία 22 |

Ένα διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυφές μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη απόσταση επιλέγει ένα διάστημα βάσει του διαθέσιμου χώρου· δεν εμφανίζει υποχρεωτικά κάθε ετικέτα.

Τα σημεία στίγματος έχουν ξεχωριστό έλεγχο. Καλέστε το [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) με `false` και χρησιμοποιήστε το [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) για να ορίσετε το διάστημά τους. Για παράδειγμα, το `1` διατηρεί ένα στίγμα σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) με ένα ορατό στυλ ώστε να δείτε το αποτέλεσμα. Καλώντας οποιονδήποτε από τους αυτόματους ρυθμιστές με `true` ξανά, επιτρέπει στο διάγραμμα να επιλέξει ξανά το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, και στη συνέχεια αποθηκεύει τρεις διαφάνειες στο `CategoryAxisIntervals.pptx`: αυτόματη απόσταση, χειροκίνητη απόσταση ετικετών με ανεξάρτητα σημεία στίγματος, και επαναφορά της αυτόματης απόστασης. Οι δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται παρουσίαση εισόδου. Το οριζόντιο κείμενο ετικετών κάνει τη διαφορά στην πυκνότητα εύκολα ορατή.

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

    // Διαφάνεια 2: εμφάνισε κάθε τρίτη ετικέτα, αλλά κράτησε ένα στίγμα για κάθε κατηγορία.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Διαφάνεια 3: άσε το διάγραμμα να επιλέξει ξανά και τα δύο διαστήματα.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Αυτόματη απόσταση (διαφάνεια 1):** Σε αυτή τη απόδοση, εμφανίζεται κάθε δεύτερη ετικέτα κατηγορίας και αναλύεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και τον renderer.

![Αυτόματη απόσταση ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητη απόσταση (διαφάνεια 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μία γραμμή, ενώ τα σημεία στίγματος παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων των χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση όπως φαίνεται παραπάνω.

![Χειροκίνητο διάστημα ετικέτας κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλέξτε τον σωστό άξονα και διάστημα**

Χρησιμοποιήστε αυτό το διάστημα αριθμού κατηγοριών για έναν άξονα κατηγορίας κειμένου, όπως ο άξονας κατηγορίας ενός διαγράμματος στήλης, γραμμής, περιοχής ή ράβδου. Σε διάγραμμα στήλης, είναι ο οριζόντιος άξονας. Σε οριζόντιο διάγραμμα ράβδου, ο άξονας κατηγορίας είναι κατακόρυφος, οπότε εφαρμόστε αυτές τις ρυθμίσεις στον άξονα που επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Η απόσταση των σημείων στίγματος ισχύει επίσης για άξονα σειράς σε διαγράμματα που έχουν έναν.

Μην χρησιμοποιείτε την απόσταση ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμών. Σε άξονα τιμών, το [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) καθορίζει τη διαφορά στις τιμές: για παράδειγμα, μια κύρια μονάδα `10` παράγει στίγματα στα 0, 10, 20 κ.ο.κ. όταν ο άξονας ξεκινά από το μηδέν. Ένα διάστημα ετικέτας κατηγορίας `3` μετρά αντίθετα τις θέσεις κατηγορίας, ανεξάρτητα από τις τιμές των δεδομένων. Τα διαγράμματα διασποράς και φυσαλίδων χρησιμοποιούν άξονες τιμών αντί για άξονα κατηγορίας κειμένου. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες και κλίμακες κύριων μονάδων βάσει χρόνου όπως περιγράφεται στην [Change a Category Axis](#change-a-category-axis).

## **Ορισμός μορφής ημερομηνίας για τιμές άξονα κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα του διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο (δείκτης `0`), υπολογιζόμενοι ως ο αριθμός των ημερών από τις 30 Δεκεμβρίου 1899 για αυτές τις ημερομηνίες. Ο υπολογισμός JavaScript χρησιμοποιεί χρονικές σφραγίσματα UTC και διαιρεί τη διαφορά με 86.400.000 χιλιοστά του δευτερολέπτου ανά ημέρα. Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) με `CategoryAxisType.Date`, καλέστε το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) με `false`, και περάστε `yyyy` στο [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) ώστε οι ετικέτες κατηγορίας να εμφανίζουν τέσσερις ψηφία έτους ανεξάρτητα από τη μορφοποίηση του κελιού.

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

## **Ορισμός γωνίας περιστροφής για τίτλο άξονα διαγράμματος**

Καλέστε το [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) με `true` στον κατακόρυφο άξονα, δώστε το κείμενο του τίτλου και χρησιμοποιήστε το [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα στήλης με τον τίτλο του άξονα τιμών του περιστραμμένο κατά 90 μοίρες.

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

## **Ορισμός θέσης άξονα σε άξονα κατηγορίας ή τιμών**

Χρησιμοποιήστε το [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) για να ελέγξετε αν ο άξονας τιμών διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία στίγματος κατηγορίας. Αυτή η ρύθμιση εφαρμόζεται σε άξονες κατηγορίας. Το παράδειγμα το ορίζει σε `true` στον οριζόντιο άξονα κατηγορίας ενός διαγράμματος στήλης και αποθηκεύει το αποτέλεσμα.

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

## **Ορισμός μονάδας εμφάνισης σε άξονα τιμών διαγράμματος**

Χρησιμοποιήστε το [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) για να κλιμακώσετε τις ετικέτες σε έναν άξονα τιμών χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) ορισμένο σε `Millions`, μια τιμή 60.000.000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα διάγραμμα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κατακόρυφο άξονά του.

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

## **Διαμόρφωση λογαριθμικού άξονα τιμών**

Ένας λογαριθμικός άξονας τιμών είναι χρήσιμος όταν οι θετικές τιμές καλύπτουν πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λάβει 10, 100, 1.000, 10.000 και 100.000 αιτήματα σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές φαίνονται κοντά μεταξύ τους κοντά στο μηδέν. Μια λογαριθμική κλίμακα καθιστά πιο εύκολη τη σύγκριση της σχετικής τους ανάπτυξης: ίσες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες αντί για ίσες διαφορές.

Καλέστε το [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) με `true` στον άξονα τιμών και χρησιμοποιήστε το [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υπαρχουσών τιμών· δεν αλλάζει τα δεδομένα ή προσθέτει λογαριθμική γραμμή τάσης. Μια γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστή λειτουργία.

### **Επιλέξτε τον άξονα τιμών και τη βάση**

Για διάγραμμα γραμμής ή στήλης, ο άξονας τιμών επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Για οριζόντιο διάγραμμα ράβδου, επιστρέφεται από το [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Τα διαγράμματα διασποράς και φυσαλίδων έχουν δύο άξονες τιμών, οπότε επιλέξτε τον οριζόντιο άξονα για τιμές X, τον κατακόρυφο άξονα για τιμές Y, ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε μια βάση από `2` έως `1000`, συμπεριλαμβανομένων· επίσης υποστηρίζονται κλασματικές βάσεις όπως `2.5`. Με βάση `10`, οι διαδοχικές δυνάμεις όπως 10, 100, 1.000 και 10.000 είναι εξίσου ορισμένες.

### **Σύγκριση γραμμικής και λογαριθμικής κλιμάκωσης**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με τις πέντε μετρήσεις αιτημάτων στην πρώτη διαφάνεια, στη συνέχεια κλωνοποιεί αυτή τη διαφάνεια και ενεργοποιεί έναν λογαριθμικό άξονα τιμών βάσης 10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

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

    // Κρατήστε την πρώτη διαφάνεια γραμμική και αλλάξτε μόνο την κλίμακα του άξονα τιμών του αντιγράφου.
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

**Γραμμική κλίμακα (διαφάνεια 1):** Ίσες κάθετες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτημάτων. Η μεγαλύτερη τιμή κυριαρχεί στο διάγραμμα, καθιστώντας τις μικρότερες τιμές δύσκολο να διακριθούν.

![Διάγραμμα γραμμής στο PowerPoint που δείχνει πέντε μετρήσεις αιτημάτων σε γραμμικό άξονα τιμών](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ίσες κάθετες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες. Κάθε περίοδος έχει δέκα φορές περισσότερα αιτήματα από την προηγούμενη, έτσι τα σημεία σχηματίζουν μια ευθεία ανυψωμένη γραμμή στη βάση-10 κλίμακα. Οι ετικέτες του άξονα εξακολουθούν να εμφανίζουν τις αρχικές μετρήσεις αιτημάτων.

![Οι ίδιες πέντε μετρήσεις αιτημάτων στο PowerPoint σε λογαριθμικό άξονα τιμών βάσης-10](value-axis-logarithmic.png)

### **Διαχείριση μηδενικών και αρνητικών τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν μηδενικές ή αρνητικές τιμές έχουν νόημα, διατηρήστε μια γραμμική κλίμακα ή εμφανίστε τις ξεχωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μην αντικαθιστάτε σιωπηλά τις τιμές με μικρούς θετικούς αριθμούς, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιοδήποτε χειροκίνητα ρυθμισμένο ελάχιστο ή μέγιστο για λογαριθμικό άξονα πρέπει επίσης να είναι θετικό.

## **Συχνές ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλον (διασταύρωση άξονα);**

Χρησιμοποιήστε το [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να ορίσετε μια αριθμητική τιμή διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση του άξονα σε μια κατάλληλη βάση.

**Πώς μπορώ να τοποθετήσω τις ετικέτες στίγματος σε σχέση με τον άξονα;**

Καλέστε το [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για να ελέγξετε τα ίδια τα σημεία στίγματος, χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) ή το [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); αυτά είναι ξεχωριστά από τη θέση των ετικετών.