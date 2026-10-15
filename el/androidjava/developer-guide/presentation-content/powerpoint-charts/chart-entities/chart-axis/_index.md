---
title: Προσαρμογή Αξόνων Διαγράμματος σε Παρουσιάσεις σε Android
linktitle: Άξονας Διαγράμματος
type: docs
url: /el/androidjava/chart-axis/
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
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για Android μέσω Java για να προσαρμόσετε τους άξονες διαγράμματος σε παρουσιάσεις PowerPoint για εκθέσεις και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες των διαγραμμάτων με το Aspose.Slides για Android μέσω Java. Καλύπτει υπολογισμένες τιμές άξονα, εναλλαγή γραμμών και στηλών του διαγράμματος, ορατότητα άξονα, διαστήματα ετικετών κατηγορίας και σημείων σημαδιών, ημερολογιακές κατηγορίες και μορφοποίηση, περιστροφή τίτλου, θέση άξονα, μονάδες εμφάνισης και λογαριθμική κλιμάκωση.

## **Λήψη των Μέγιστων Τιμών στον Κάθετο Άξονα σε Διαγράμματα**

Δημιουργήστε μια [Παρουσίαση](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) και προσθέστε ένα διάγραμμα περιοχής με προεπιλεγμένα δεδομένα. Καλέστε το [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) πριν διαβάσετε τις υπολογισμένες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε το [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) και το [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) για τα όρια του άξονα, και τα [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) και [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) για τα διαστήματα σημείων. Τα [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) και [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) παρέχουν κλίμακες μονάδων χρόνου, που είναι σχετικές με άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

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

## **Ανταλλαγή των Δεδομένων μεταξύ των Αξόνων**

Χρησιμοποιήστε το [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα του διαγράμματος. Κάθε προηγούμενη κατηγορία γίνεται σειρά, και κάθε προηγούμενη σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κάθετους άξονες. Το παράδειγμα χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) για να συνδέσει τα προεπιλεγμένα δεδομένα με `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγορίας, προτού αλλάξει τις γραμμές και τις στήλες. Αποθηκεύει ένα διάγραμμα με τέσσερις σειρές και τρεις κατηγορίες.

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

## **Αντιστροφή της Σειράς Σχεδίασης ενός Άξονα**

Χρησιμοποιήστε το [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) για να αντιστρέψετε έναν άξονα κατηγορίας ή τιμής. Για παράδειγμα, ένα οριζόντιο γράφημα μπάρας μπορεί να εμφανίσει τα στάδια του έργου από πάνω προς τα κάτω με την ίδια σειρά όπως στο φύλλο εργασίας: Προγραμματισμός, Ανάπτυξη, Δοκιμή. Η αντιστροφή ενός άξονα αλλάζει την κατεύθυνση σχεδίασης· δεν ταξινομεί ή αναδιοργανώνει τα δεδομένα του βιβλίου εργασίας. Σε σύγκριση, το [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) ανταλλάσσει τους ρόλους των σειρών και των κατηγοριών.

Το παρακάτω παράδειγμα δημιουργεί ένα οριζόντιο γράφημα μπάρας με τρία στάδια και μία σειρά. Αποθηκεύει μια παρουσίαση με τρία διαφάνειες: κανονική σειρά, αντιστραμμένες κατηγορίες και αντιστραμμένες τιμές. Κάθε αντίγραφο χρησιμοποιεί το ίδιο σύνολο δεδομένων, και μόνο ένας άξονας είναι αντιστραμμένος σε κάθε αντίγραφο.

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
    // Διατηρήστε τον οριζόντιο άξονα τιμών στο κάτω μέρος.
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

Η αντιστροφή ενός άξονα μπορεί επίσης να μετακινήσει τον κάθετο άξονα στην αντίθετη πλευρά του διαγράμματος. Το [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) ελέγχει πού ο άλλος άξονας διασχίζει τον άξονα που διαμορφώνεται. Στη διαφάνεια 2, η κλήση του με `CrossesType.Maximum` στον αντιστραμμένο άξονα κατηγορίας διατηρεί τον οριζόντιο άξονα τιμής στο κάτω μέρος. Για συγκεκριμένο σημείο διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Ελέγξτε τις ρυθμίσεις διασταύρωσης όταν αλλάζετε κατεύθυνση, ειδικά εάν το διάγραμμα έχει ήδη προσαρμοσμένο σημείο διασταύρωσης. Καλέστε το `setPlotOrderReversed` με `false` για να επαναφέρετε την κανονική κατεύθυνση σχεδίασης· οι ρυθμίσεις διασταύρωσης είναι ξεχωριστές.

| Κανονική σειρά (διαφάνεια 1) | Αντιστροφή κατηγοριών (διαφάνεια 2) | Αντιστροφή τιμών (διαφάνεια 3) |
| --- | --- | --- |
| ![Οριζόντιο γράφημα μπάρας με κανονική σειρά άξονα κατηγορίας και τιμής](axis-order-normal.png) | ![Οριζόντιο γράφημα μπάρας με κατηγορίες εμφανιζόμενες από πάνω προς τα κάτω](axis-order-categories-reversed.png) | ![Οριζόντιο γράφημα μπάρας με αντεστραμμένο άξονα τιμής και μηδέν στα δεξιά](axis-order-values-reversed.png) |
| Οι κατηγορίες τρέχουν από κάτω προς τα πάνω· οι τιμές αυξάνονται από αριστερά προς τα δεξιά. | Ο Προγραμματισμός, η Ανάπτυξη και η Δοκιμή τρέχουν από πάνω προς τα κάτω. Οι τιμές και η σειρά των γραμμών του βιβλίου εργασίας παραμένουν αμετάβλητες. | Οι κατηγορίες διατηρούν την κανονική τους σειρά· οι τιμές αυξάνονται από τα δεξιά προς τα αριστερά. Ο άξονας κατηγορίας διασχίζει στο μηδέν στα δεξιά. |

## **Απενεργοποίηση του Κάθετου Άξονα για Διαγράμματα Γραμμών**

Καλέστε το [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) με `false` στον κάθετο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κάθετο άξονα κρυμμένο.

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

## **Απενεργοποίηση του Οριζόντιου Άξονα για Διαγράμματα Γραμμών**

Καλέστε το [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) με `false` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυμμένο.

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

## **Αλλαγή Άξονα Κατηγορίας**

Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) για να επιλέξετε άξονα κατηγορίας ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα διάγραμμα ως το πρώτο σχήμα στη πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας του Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Η κλήση του [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) με `false`, του [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) με `1`, και του [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) με `TimeUnitType.Months` τοποθετεί τα κύρια σημεία σε διαστήματα ενός μήνα.

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

## **Έλεγχος Διαστημάτων Ετικετών Άξονα Κατηγορίας**

Όταν ένα διάγραμμα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Καλέστε το [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) με `false`, έπειτα περάστε το επιθυμητό διάστημα κατηγορίας στο [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Για κειμενικές κατηγορίες στη φυσική τους σειρά, η αρίθμηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Κατηγορία 1, Κατηγορία 2, Κατηγορία 3, … Κατηγορία 24 |
| `2` | Κατηγορία 1, Κατηγορία 3, Κατηγορία 5, … Κατηγορία 23 |
| `3` | Κατηγορία 1, Κατηγορία 4, Κατηγορία 7, … Κατηγορία 22 |

Διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη τοποθέτηση επιλέγει διάστημα βάσει του διαθέσιμου χώρου· δεν εμφανίζει απαραίτητα κάθε ετικέτα.

Τα σημεία σήμανσης έχουν ξεχωριστό έλεγχο. Καλέστε το [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) με `false` και χρησιμοποιήστε το [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) για να ορίσετε το διάστημά τους. Για παράδειγμα, το `1` διατηρεί ένα σημείο σήμανσης σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) με εμφανισιμό στυλ ώστε να δείτε το αποτέλεσμα. Η επαναφορά του αυτόματου ρυθμιστή με `true` επιτρέπει στο διάγραμμα να επιλέξει ξανά το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, έπειτα αποθηκεύει τρεις διαφάνειες σε `CategoryAxisIntervals.pptx`: αυτόματη τοποθέτηση, χειροκίνητη τοποθέτηση ετικετών με ανεξάρτητα σημεία σήμανσης, και επαναφορά αυτόματης τοποθέτησης. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται εισαγωγική παρουσίαση. Το κείμενο ετικετών οριζόντια κάνει τη διαφορά στην πυκνότητα εύκολα ορατή.

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

    // Διαφάνεια 2: εμφάνιση κάθε τρίτης ετικέτας, αλλά διατήρηση σημείου σήμανσης για κάθε κατηγορία.
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

**Αυτόματος διαχωρισμός (διαφάνεια 1):** Σε αυτήν την απόδοση, κάθε δεύτερη ετικέτα κατηγορίας εμφανίζεται και καταγράφεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και το εργαλείο απόδοσης.

![Αυτόματος διαχωρισμός ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητος διαχωρισμός (διαφάνεια 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μία γραμμή, ενώ τα σημεία διατηρούνται σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων αυτών χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Χειροκίνητο διάστημα ετικετών κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλογή του Σωστού Άξονα και Διαστήματος**

Χρησιμοποιήστε αυτό το διάστημα καταμέτρησης κατηγοριών για άξονα κατηγορίας κειμένου, όπως ο άξονας κατηγορίας ενός ραβδίου, γραμμής, περιοχής ή ράβδου. Σε ραβδικό διάγραμμα, είναι ο οριζόντιος άξονας. Σε οριζόντιο ραβδί, ο άξονας κατηγορίας είναι κάθετος, επομένως εφαρμόστε αυτές τις ρυθμίσεις στον άξονα που επιστρέφει το [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Η τοποθέτηση σημείων σήμανσης ισχύει επίσης για άξονα σειράς σε διαγράμματα που τον έχουν.

Μην χρησιμοποιείτε το διάστημα ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμής. Σε άξονα τιμής, το [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) προσδιορίζει τη διαφορά τιμών: π.χ., μια κύρια μονάδα `10` παράγει σημεία στα 0, 10, 20 κ.λπ. όταν ο άξονας αρχίζει από το μηδέν. Ένα διάστημα ετικέτας κατηγορίας `3` μετράει θέσεις κατηγορίας, ανεξάρτητα από τις τιμές των δεδομένων. Τα διαγράμματα διασκορπισμού και φούσκας χρησιμοποιούν άξονες τιμής αντί για άξονα κατηγορίας κειμένου. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες και κλίμακες βάσει χρόνου όπως περιγράφεται στην [Αλλαγή Άξονα Κατηγορίας](#change-a-category-axis).

## **Ορισμός Μορφής Ημερομηνίας για Τιμές Άξονα Κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα του διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`), υπολογιζόμενοι ως ο αριθμός ημερών από τις 30 Δεκεμβρίου 1899. Και τα δύο ημερολόγια χρησιμοποιούν UTC και καθαρίζονται πριν οριστούν οι ημερομηνίες ώστε η θερινή ώρα και η τρέχουσα ώρα της ημέρας να μην επηρεάσουν τον υπολογισμό. Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) με `CategoryAxisType.Date`, καλέστε το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) με `false`, και περάστε `yyyy` στο [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) ώστε οι ετικέτες κατηγορίας να εμφανίζουν έτη τετραψήφια ανεξάρτητα από τη μορφοποίηση των κελιών.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
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

## **Ορισμός Γωνίας Περιστροφής για Τίτλο Άξονα Διαγράμματος**

Καλέστε το [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) με `true` στον κάθετο άξονα, δώστε κείμενο τίτλου και χρησιμοποιήστε το [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· το παράδειγμα αποθηκεύει ένα ραβδικό διάγραμμα με τον τίτλο του άξονα τιμής περιστραφέντα 90 μοίρες.

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

## **Ορισμός Θέσης Άξονα σε Άξονα Κατηγορίας ή Τιμής**

Χρησιμοποιήστε το [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) για να ελέγξετε εάν ο άξονας τιμής διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία σήμανσης κατηγορίας. Αυτή η ρύθμιση ισχύει για άξονες κατηγορίας. Το παράδειγμα το ορίζει σε `true` στον οριζόντιο άξονα κατηγορίας ενός ραβδικού διαγράμματος και αποθηκεύει το αποτέλεσμα.

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

## **Ορισμός Μονάδας Εμφάνισης σε Άξονα Τιμής Διαγράμματος**

Χρησιμοποιήστε το [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) για να κλιμακώσετε τις ετικέτες σε άξονα τιμής χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) ορισμένο σε `Millions`, μια τιμή των 60 000 000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα ραβδικό διάγραμμα και εφαρμόζει τη μονάδα εμφάνισης «εκατομμύρια» στον κάθετο άξονα του.

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

## **Διαμόρφωση Λογαριθμικού Άξονα Τιμής**

Ένας λογαριθμικός άξονας τιμής είναι χρήσιμος όταν οι θετικές τιμές καλύπτουν πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1 000, 10 000 και 100 000 αιτήματα σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται κοντά στο μηδέν. Μια λογαριθμική κλίμακα κάνει τη σχετική τους ανάπτυξη πιο συγκρίσιμη: ίσες αποστάσεις αντιστοιχούν σε ίσες αναλογίες αντί για ίσες διαφορές.

Καλέστε το [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) με `true` στον άξονα τιμής και χρησιμοποιήστε το [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υπαρχόντων τιμών· δεν αλλάζει τα δεδομένα ούτε προσθέτει λογαριθμική γραμμή τάσης. Μία γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστό χαρακτηριστικό.

### **Επιλογή του Άξονα Τιμής και Βάσης**

Για διάγραμμα γραμμής ή ράβδου, ο άξονας τιμής επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Για οριζόντιο ραβδί, επιστρέφεται από το [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Τα διαγράμματα διασκορπισμού και φούσκας έχουν δύο άξονες τιμής, οπότε επιλέξτε τον οριζόντιο για τιμές X, τον κάθετο για τιμές Y, ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένων· υποστηρίζονται και κλασματικές βάσεις όπως `2.5`. Με βάση `10`, οι διαδοχικές δυνάμεις 10, 100, 1 000 και 10 000 είναι εξίσου απομακρυσμένες.

### **Σύγκριση Γραμμικής και Λογαριθμικής Κλιμάκωσης**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με τις πέντε μετρήσεις αιτήσεων στη πρώτη διαφάνεια, έπειτα κλωνοποιεί τη διαφάνεια και ενεργοποιεί λογαριθμικό άξονα τιμής βάσης‑10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

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

    // Διατηρήστε την πρώτη διαφάνεια γραμμική και αλλάξτε μόνο την κλίμακα του άξονα τιμών του αντιγράφου.
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

**Γραμμική κλίμακα (διαφάνεια 1):** Ίσες κάθετες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτήσεων. Η μεγαλύτερη τιμή κυριαρχεί στο διάγραμμα, καθιστώντας τις μικρότερες τιμές δύσκολο να διακριθούν.

![Διάγραμμα γραμμής σε PowerPoint που εμφανίζει πέντε μετρήσεις αιτήσεων σε γραμμικό άξονα τιμής](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ίσες κάθετες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες. Κάθε περίοδος έχει δέκα φορές περισσότερα αιτήματα από την προηγούμενη, έτσι τα σημεία σχηματίζουν μία ευθεία ανερχόμενη γραμμή στη βάση‑10 κλίμακα. Οι ετικέτες του άξονα εξακολουθούν να εμφανίζουν τις αρχικές μετρήσεις αιτήσεων.

![Οι ίδιες πέντε μετρήσεις αιτήσεων σε PowerPoint σε λογαριθμικό άξονα τιμής βάσης‑10](value-axis-logarithmic.png)

### **Χειρισμός Μηδενικών και Αρνητικών Τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν μηδενικές ή αρνητικές τιμές έχουν σημασία, διατηρήστε μια γραμμική κλίμακα ή εμφανίστε τις ξεχωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μην αντικαθιστάτε σιωπηλά τις τιμές με μικρούς θετικούς αριθμούς, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιοδήποτε χειροκίνητα ρυθμισμένο ελάχιστο ή μέγιστο για λογαριθμικό άξονα πρέπει επίσης να είναι θετικό.

## **Συχνές Ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Χρησιμοποιήστε το [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να καθορίσετε αριθμητική τιμή διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Αυτές οι ρυθμίσεις σάς επιτρέπουν να μετακινήσετε τη διασταύρωση του άξονα σε μια κατάλληλη βάση.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημείων στήριξης σε σχέση με τον άξονα;**

Καλέστε το [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για να ελέγξετε τα ίδια τα σημεία στήριξης, χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) ή το [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); αυτά είναι ξεχωριστά από την τοποθέτηση ετικετών.