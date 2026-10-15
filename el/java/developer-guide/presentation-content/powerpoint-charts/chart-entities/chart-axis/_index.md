---
title: Προσαρμογή Αξόνων Διαγραμμάτων σε Παρουσιάσεις με Java
linktitle: Άξονας Διαγράμματος
type: docs
url: /el/java/chart-axis/
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
- μορφότυπος ημερομηνίας
- τίτλος άξονα
- θέση άξονα
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides for Java για να προσαρμόσετε τους άξονες διαγραμμάτων σε παρουσιάσεις PowerPoint για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες των διαγραμμάτων με το Aspose.Slides for Java. Καλύπτει τις υπολογισμένες τιμές αξόνων, την εναλλαγή γραμμών και στηλών διαγράμματος, την ορατότητα του άξονα, τα διαστήματα ετικετών κατηγορίας και σημείων εισαγωγής, τις κατηγορίες ημερομηνίας και τη μορφοποίηση, την περιστροφή του τίτλου, τη θέση του άξονα, τις μονάδες εμφάνισης και την λογαριθμική κλιμάκωση.

## **Λήψη των μέγιστων τιμών στον κατακόρυφο άξονα των διαγραμμάτων**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) και προσθέστε ένα διάγραμμα περιοχής με προεπιλεγμένα δεδομένα. Καλέστε το [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) πριν διαβάσετε τις υπολογισμένες τιμές του άξονα, ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) και [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) για τα όρια του άξονα, και [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) και [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) για τα διαστήματα των σημείων. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) και [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) παρέχουν κλίμακες μονάδων χρόνου, οι οποίες είναι σχετικές με άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ανταλλαγή των δεδομένων μεταξύ αξόνων**

Χρησιμοποιήστε το [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα του διαγράμματος. Κάθε πρώην κατηγορία γίνεται σειρά, και κάθε πρώην σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κάθετους άξονες. Το παράδειγμα χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) για να δεσμεύσει τα προεπιλεγμένα δεδομένα στο `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγορίας, πριν γίνει η εναλλαγή γραμμών και στηλών. Αποθηκεύει ένα διάγραμμα με τέσσερις σειρές και τρεις κατηγορίες.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αντιστροφή της σειράς σχεδίασης ενός άξονα**

Χρησιμοποιήστε το [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) για να αντιστρέψετε έναν άξονα κατηγορίας ή τιμής. Για παράδειγμα, ένα οριζόντιο διάγραμμα ράβδων μπορεί να εμφανίζει τα στάδια ενός έργου από πάνω προς τα κάτω στην ίδια σειρά με το φύλλο εργασίας: Planning, Development, Testing. Η αντιστροφή ενός άξονα αλλάζει την κατεύθυνση σχεδίασης· δεν ταξινομεί ή αναδιοργανώνει τα δεδομένα του φύλλου. Σε σύγκριση, το [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) ανταλλάσσει τους ρόλους των σειρών και των κατηγοριών.

Το παρακάτω παράδειγμα δημιουργεί ένα οριζόντιο διάγραμμα ράβδων με τρία στάδια και μια σειρά. Αποθηκεύει μια παρουσίαση με τρεις διαφάνειες: κανονική σειρά, αντεστραμμένες κατηγορίες και αντεστραμμένες τιμές. Κάθε αντίγραφο χρησιμοποιεί τα ίδια δεδομένα, και μόνο ένας άξονας είναι αντεστραμμένος σε κάθε αντίγραφο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Διαφάνεια 2: εμφάνιση της πρώτης κατηγορίας στην κορυφή.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Διατήρηση του οριζόντιου άξονα τιμών στο κάτω μέρος.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Διαφάνεια 3: αντιστροφή μόνο της οριζόντιας αριθμητικής κλίμακας.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αντιστροφή ενός άξονα μπορεί επίσης να μετακινήσει τον κάθετο άξονα στην αντίθετη πλευρά του γραφήματος. Το [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) ελέγχει πού ο άλλος άξονας διασχίζει τον άξονα που ρυθμίζεται. Στη διαφάνεια 2, η κλήση του με `CrossesType.Maximum` στον αντεστραμμένο άξονα κατηγορίας κρατά τον οριζόντιο άξονα τιμής στις βάσεις. Για συγκεκριμένο σημείο διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Ελέγξτε τις ρυθμίσεις διασταύρωσης όταν αλλάζετε κατεύθυνση, ειδικά αν το διάγραμμα έχει ήδη προσαρμοσμένο σημείο διασταύρωσης. Καλέστε το `setPlotOrderReversed` με `false` για να επαναφέρετε την κανονική κατεύθυνση σχεδίασης· οι ρυθμίσεις διασταύρωσης είναι ξεχωριστές.

| Κανονική σειρά (διαφάνεια 1) | Αντεστραμμένες κατηγορίες (διαφάνεια 2) | Αντεστραμμένες τιμές (διαφάνεια 3) |
| --- | --- | --- |
| ![Διάγραμμα οριζόντιων ραβδών με κανονική σειρά άξονα κατηγορίας και τιμής](axis-order-normal.png) | ![Διάγραμμα οριζόντιων ραβδών με κατηγορίες που εμφανίζονται από πάνω προς τα κάτω](axis-order-categories-reversed.png) | ![Διάγραμμα οριζόντιων ραβδών με αντεστραμμένο άξονα τιμής και μηδέν στα δεξιά](axis-order-values-reversed.png) |
| Οι κατηγορίες τρέχουν από κάτω προς τα πάνω· οι τιμές αυξάνονται από αριστερά προς δεξιά. | Οι φάσεις Προγραμματισμός, Ανάπτυξη και Δοκιμή τρέχουν από πάνω προς τα κάτω. Οι τιμές και η σειρά των γραμμών του φύλλου εργασίας παραμένουν αμετάβλητες. | Οι κατηγορίες διατηρούν τη φυσική τους σειρά· οι τιμές αυξάνονται από δεξιά προς τα αριστερά. Ο άξονας κατηγορίας διασχίζει στο μηδέν στα δεξιά. |

## **Απενεργοποίηση του κατακόρυφου άξονα για διαγράμματα γραμμής**

Καλέστε το [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) με `false` στον κατακόρυφο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κατακόρυφο άξονα κρυμμένο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Απενεργοποίηση του οριζόντιου άξονα για διαγράμματα γραμμής**

Καλέστε το [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) με `false` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυμμένο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αλλαγή άξονα κατηγορίας**

Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) για να επιλέξετε άξονα κατηγορίας τύπου ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με διάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας του Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Η κλήση του [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) με `false`, του [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) με `1` και του [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) με `TimeUnitType.Months` τοποθετεί τα κύρια σημεία σε διαστήματα ενός μήνα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος διαστημάτων ετικετών άξονα κατηγορίας**

Όταν ένα διάγραμμα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Καλέστε το [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) με `false`, έπειτα περάστε το επιθυμητό διάστημα κατηγορίας στο [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Για κειμενικές κατηγορίες με τη φυσική τους σειρά, η αρίθμηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη τοποθέτηση επιλέγει διάστημα βάσει του διαθέσιμου χώρου· δεν εμφανίζει υποχρεωτικά κάθε ετικέτα.

Τα σημεία εισαγωγής έχουν ξεχωριστό έλεγχο. Καλέστε το [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) με `false` και χρησιμοποιήστε το [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) για να ορίσετε το διάστημά τους. Για παράδειγμα, το `1` διατηρεί σημείο εισαγωγής σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) με εμφανές στυλ ώστε να δείτε το αποτέλεσμα. Η επαναφορά ενός από τους αυτόματους οριστές σε `true` επιτρέπει στο διάγραμμα να επιλέξει ξανά το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, μετά αποθηκεύει τρεις διαφάνειες στο `CategoryAxisIntervals.pptx`: αυτόματη τοποθέτηση, χειροκίνητη τοποθέτηση ετικετών με ανεξάρτητα σημεία εισαγωγής, και επαναφορά της αυτόματης τοποθέτησης. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται εισαγωγική παρουσίαση. Το οριζόντιο κείμενο ετικέτας κάνει τη διαφορά στην πυκνότητα εύκολα ορατή.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Διαφάνεια 2: εμφάνιση κάθε τρίτης ετικέτας, αλλά διατήρηση σημείου εισαγωγής για κάθε κατηγορία.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Διαφάνεια 3: άφησε το διάγραμμα να επιλέξει ξανά και τα δύο διαστήματα.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Αυτόματη τοποθέτηση (διαφάνεια 1):** Σε αυτήν την απόδοση, εμφανίζεται κάθε δεύτερη ετικέτα κατηγορίας και γίνεται αναδίπλωση σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και το πρόγραμμα απόδοσης.

![Αυτόματη τοποθέτηση ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητη τοποθέτηση (διαφάνεια 2):** Εμφανίζεται κάθε τρίτη ετικέτα σε μία γραμμή, ενώ τα σημεία εισαγωγής παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων εκείνων χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Χειροκίνητο διάστημα ετικετών κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλέξτε τον σωστό άξονα και διάστημα**

Χρησιμοποιήστε αυτό το διάστημα μετρητή κατηγοριών για άξονα κειμενικής κατηγορίας, όπως ο άξονας κατηγορίας στήλης, γραμμής, περιοχής ή ράβδους. Σε στήλη, είναι ο οριζόντιος άξονας. Σε οριζόντια ράβδο, ο άξονας κατηγορίας είναι κατακόρυφος, οπότε εφαρμόστε αυτές τις ρυθμίσεις στον άξονα που επιστρέφει το [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Η τοποθέτηση σημείων εισαγωγής εφαρμόζεται επίσης σε άξονα σειράς όταν το διάγραμμα το διαθέτει.

Μην χρησιμοποιείτε την τοποθέτηση ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμής. Σε άξονα τιμής, το [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) ορίζει διαφορά τιμών: π.χ., μονάδα `10` παράγει σημεία στο 0, 10, 20 κλπ όταν ο άξονας αρχίζει από μηδέν. Διάστημα ετικέτας κατηγορίας `3` μετρά θέσεις κατηγοριών, ανεξάρτητα από τις τιμές τους. Τα διαγράμματα scatter και bubble χρησιμοποιούν άξονες τιμής αντί για κειμενικό άξονα κατηγορίας. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες και κλίμακες βάσει χρόνου όπως περιγράφεται στην [Αλλαγή άξονα κατηγορίας](#change-a-category-axis).

## **Ορισμός μορφοτύπου ημερομηνίας για τιμές άξονα κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο (δείκτης `0`), υπολογιζόμενοι ως αριθμός ημερών από 30 Δεκεμβρίου 1899. Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) με `CategoryAxisType.Date`, καλέστε το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) με `false` και περάστε `yyyy` στο [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) ώστε οι ετικέτες κατηγορίας να εμφανίζουν τετραψήφια έτη ανεξάρτητα από τη μορφοποίηση κελιού.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός γωνίας περιστροφής για τίτλο άξονα διαγράμματος**

Καλέστε το [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) με `true` στον κατακόρυφο άξονα, δώστε κείμενο τίτλου, και χρησιμοποιήστε το [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) για να περιστρέψετε τον τίτλο. Η γωνία μετριέται σε μοίρες· το παράδειγμα αποθηκεύει ένα διάγραμμα στήλης με τον τίτλο του άξονα τιμής περιστραμμένο κατά 90 μοίρες.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός θέσης άξονα σε άξονα κατηγορίας ή τιμής**

Χρησιμοποιήστε το [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) για να ελέγξετε αν ο άξονας τιμής διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία εισαγωγής της κατηγορίας. Αυτή η ρύθμιση ισχύει για άξονες κατηγορίας. Το παράδειγμα το θέτει σε `true` στον οριζόντιο άξονα κατηγορίας ενός διαγράμματος στήλης και αποθηκεύει το αποτέλεσμα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός μονάδας εμφάνισης σε άξονα τιμής διαγράμματος**

Χρησιμοποιήστε το [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) για να κλιμακώσετε τις ετικέτες ενός άξονα τιμής χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) ορισμένο σε `Millions`, μια τιμή των 60 000 000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα διάγραμμα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κατακόρυφο άξονά του.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διαμόρφωση λογαριθμικού άξονα τιμής**

Ένας λογαριθμικός άξονας τιμής είναι χρήσιμος όταν θετικές τιμές καλύπτουν πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1 000, 10 000 και 100 000 αιτήματα σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται κοντά μεταξύ τους κοντά στο μηδέν. Η λογαριθμική κλίμακα κάνει τη σχετική αύξηση πιο συγκρίσιμη: ίσες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες αντί για ίσες διαφορές.

Καλέστε το [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) με `true` στον άξονα τιμής και χρησιμοποιήστε το [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) για να επιλέξετε τη βάση. Αυτό αλλάζει πώς εμφανίζονται οι υπάρχουσες τιμές· δεν αλλάζει τα δεδομένα ή προσθέτει μια λογαριθμική γραμμή τάσης. Μια γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστό χαρακτηριστικό.

### **Επιλέξτε τον άξονα τιμής και τη βάση**

Για διάγραμμα γραμμής ή στήλης, ο άξονας τιμής επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Για οριζόντιο διάγραμμα ράβδων, επιστρέφεται από το [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Τα διαγράμματα scatter και bubble έχουν δύο άξονες τιμής, οπότε επιλέξτε τον οριζόντιο άξονα για τιμές X, τον κατακόρυφο για τιμές Y, ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένης· υποστηρίζονται και κλασματικές βάσεις όπως `2.5`. Με βάση `10`, οι διαδοχικές δυνάμεις όπως 10, 100, 1 000 και 10 000 είναι εξίσου διασκορπισμένες.

### **Σύγκριση γραμμικής και λογαριθμικής κλιμάκωσης**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με τους πέντε μετρητές αιτημάτων στην πρώτη διαφάνεια, στη συνέχεια κλωνοποιεί αυτή τη διαφάνεια και ενεργοποιεί λογαριθμικό άξονα τιμής βάσης 10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Διατηρήστε την πρώτη διαφάνεια γραμμική και αλλάξτε μόνο την κλίμακα του άξονα τιμής του αντίγραφου.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Γραμμική κλίμακα (διαφάνεια 1):** Ίσες κάθετες αποστάσεις αντιπροσωπεύουν ίσες διαφορές σε αριθμό αιτημάτων. Η μεγαλύτερη τιμή κυριαρχεί στο διάγραμμα, καθιστώντας τις μικρότερες τιμές δύσκολο να διακριθούν.

![Διάγραμμα γραμμής στο PowerPoint που δείχνει πέντε μετρήσεις αιτημάτων σε γραμμικό άξονα τιμής](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ίσες κάθετες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες. Κάθε περίοδος έχει δέκα φορές περισσότερα αιτήματα από την προηγούμενη, έτσι τα σημεία σχηματίζουν μια ευθεία αυξανόμενη γραμμή στην κλίμακα βάσης 10. Οι ετικέτες του άξονα εξακολουθούν να δείχνουν τους αρχικούς μετρητές αιτημάτων.

![Οι ίδιες πέντε μετρήσεις αιτημάτων στο PowerPoint σε λογαριθμικό άξονα τιμής βάσης 10](value-axis-logarithmic.png)

### **Διαχείριση μηδενικών και αρνητικών τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν μηδενικές ή αρνητικές τιμές έχουν νόημα, διατηρήστε τη γραμμική κλίμακα ή εμφανίστε τις ξεχωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μην αντικαθιστάτε σιωπηρά τις τιμές με μικρούς θετικούς αριθμούς, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιοδήποτε χειροκίνητα ρυθμισμένο ελάχιστο ή μέγιστο για λογαριθμικό άξονα πρέπει επίσης να είναι θετικό.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Χρησιμοποιήστε το [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να ορίσετε αριθμητική τιμή διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση του άξονα σε μια κατάλληλη βάση.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημείων σε σχέση με τον άξονα;**

Καλέστε το [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για έλεγχο των σημείων εισαγωγής, χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) ή το [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); αυτές είναι ξεχωριστές από τη θέση ετικετών.