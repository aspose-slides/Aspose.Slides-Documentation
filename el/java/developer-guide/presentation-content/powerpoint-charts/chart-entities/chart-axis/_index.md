---
title: "Προσαρμογή άξονων διαγράμματος σε παρουσιάσεις με Java"
linktitle: "Άξονας γραφήματος"
type: docs
url: /el/java/chart-axis/
keywords:
- άξονας γραφήματος
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
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για Java ώστε να προσαρμόσετε τους άξονες γραφημάτων σε παρουσιάσεις PowerPoint για εκθέσεις και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τους άξονες των διαγραμμάτων με το Aspose.Slides για Java. Καλύπτει τις υπολογισμένες τιμές άξονα, την εναλλαγή γραμμών και στηλών του διαγράμματος, την ορατότητα άξονα, τα διαστήματα ετικετών κατηγορίας και σημείων σήμανσης, τις ημερομηνίες κατηγοριών και τη μορφοποίησή τους, την περιστροφή του τίτλου, τη θέση του άξονα, τις μονάδες εμφάνισης και τη λογαριθμική κλίμακα.

## **Λήψη των μέγιστων τιμών στον κατακόρυφο άξονα των διαγραμμάτων**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) και προσθέστε ένα διάγραμμα περιοχής με προεπιλεγμένα δεδομένα. Καλέστε [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) πριν διαβάσετε τις υπολογισμένες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) και [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) για τα όρια του άξονα, και [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) και [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) για τα διαστήματα των σημείων σήμανσης. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) και [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) παρέχουν κλίμακες μονάδων χρόνου, οι οποίες είναι σχετικές με τους άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

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

## **Αντιμετάθεση των δεδομένων μεταξύ των αξόνων**

Χρησιμοποιήστε [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα του διαγράμματος. Κάθε προηγούμενη κατηγορία γίνεται σειρά, και κάθε προηγούμενη σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κατακόρυφους άξονες. Το παράδειγμα χρησιμοποιεί [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) για να συνδέσει τα προεπιλεγμένα δεδομένα με `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής επικεφαλίδας και της στήλης κατηγορίας, πριν την εναλλαγή γραμμών και στηλών. Αποθηκεύει ένα διάγραμμα με τέσσερις σειρές και τρεις κατηγορίες.

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

## **Απενεργοποίηση του κατακόρυφου άξονα σε γραμμικά διαγράμματα**

Καλέστε [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) με `false` στον κατακόρυφο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γραμμικό διάγραμμα με προεπιλεγμένα δεδομένα και το αποθηκεύει με κρυφό τον κατακόρυφο άξονα.

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

## **Απενεργοποίηση του οριζόντιου άξονα σε γραμμικά διαγράμματα**

Καλέστε [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) με `false` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γραμμικό διάγραμμα με προεπιλεγμένα δεδομένα και το αποθηκεύει με κρυφό τον οριζόντιο άξονα.

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

Χρησιμοποιήστε [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) για να επιλέξετε άξονα ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα διάγραμμα ως πρώτο σχήμα στην πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας του Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Καλώντας [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) με `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) με `1`, και [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) με `TimeUnitType.Months` τοποθετούν τα κύρια σημεία σήμανσης σε διαστήματα ενός μήνα.

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

Όταν ένα διάγραμμα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Καλέστε [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) με `false`, έπειτα περάστε το επιθυμητό διάστημα κατηγορίας στο [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Για κειμενικές κατηγορίες με τη φυσική τους σειρά, η μέτρηση ξεκινά από την πρώτη κατηγορία:

| Interval | Labels displayed in the example |
| --- | --- |
| `1` | Κατηγορία 1, Κατηγορία 2, Κατηγορία 3, ... Κατηγορία 24 |
| `2` | Κατηγορία 1, Κατηγορία 3, Κατηγορία 5, ... Κατηγορία 23 |
| `3` | Κατηγορία 1, Κατηγορία 4, Κατηγορία 7, ... Κατηγορία 22 |

Ένα διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη απόσταση επιλέγει διάστημα βάσει του διαθέσιμου χώρου· δεν εμφανίζει απαραίτητα κάθε ετικέτα.

Τα σημεία σήμανσης έχουν ξεχωριστό έλεγχο. Καλέστε [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) με `false` και χρησιμοποιήστε [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) για να ορίσετε το διάστημά τους. Για παράδειγμα, το `1` διατηρεί ένα σημείο σήμανσης σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Χρησιμοποιήστε [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) με ορατό στυλ ώστε να δείτε το αποτέλεσμα. Καλώντας ξανά οποιονδήποτε από τους αυτόματους ρυθμιστές με `true` επιτρέπει στο διάγραμμα να επιλέξει ξανά το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, έπειτα αποθηκεύει τρεις διαφάνειες σε `CategoryAxisIntervals.pptx`: αυτόματη απόσταση, χειροκίνητη απόσταση ετικετών με ανεξάρτητα σημεία σήμανσης, και επαναφορά της αυτόματης απόστασης. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα διαγράμματος. Δεν απαιτείται παρουσίαση εισόδου. Το οριζόντιο κείμενο ετικέτας κάνει εύκολα ορατή τη διαφορά στην πυκνότητα.

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

    // Διαφάνεια 2: εμφανίστε κάθε τρίτη ετικέτα, αλλά διατηρήστε ένα σημείο σήμανσης για κάθε κατηγορία.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Διαφάνεια 3: αφήστε το διάγραμμα να επιλέξει ξανά και τα δύο διαστήματα.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatic spacing (slide 1):** Σε αυτήν την απόδοση, εμφανίζεται κάθε δεύτερη ετικέτα κατηγορίας και τυλίγεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και το σύστημα απόδοσης.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Manual spacing (slide 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μία γραμμή, ενώ τα σημεία σήμανσης παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων αυτών χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Επιλέξτε τον σωστό άξονα και το διάστημα**

Χρησιμοποιήστε αυτό το διάστημα αριθμού κατηγοριών για άξονα κειμενικής κατηγορίας, όπως ο άξονας κατηγορίας σε στυλό, γραμμή, περιοχή ή ραβδογράφημα. Σε στυλό διάγραμμα είναι ο οριζόντιος άξονας. Σε οριζόντιο ραβδογράφημα, ο άξονας κατηγορίας είναι κατακόρυφος, οπότε εφαρμόστε αυτές τις ρυθμίσεις στον άξονα που επιστρέφεται από [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Η απόσταση σημείων σήμανσης εφαρμόζεται επίσης σε άξονα σειράς σε διαγράμματα που το διαθέτουν.

Μην χρησιμοποιείτε την απόσταση ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμής. Σε άξονα τιμής, το [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) ορίζει τη διαφορά στις τιμές: για παράδειγμα, μια κύρια μονάδα `10` παράγει σημεία σήμανσης στα 0, 10, 20 κ.λπ. όταν ο άξονας ξεκινά από το μηδέν. Αντίθετα, ένα διάστημα ετικετών κατηγορίας `3` μετρά θέσεις κατηγορίας, ανεξάρτητα από τις τιμές των δεδομένων. Τα διαγράμματα διασποράς και φυσαλίδας χρησιμοποιούν άξονες τιμών αντί για άξονα κειμενικής κατηγορίας. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες και κλίμακες βάσει χρόνου όπως περιγράφεται στην [Change a Category Axis](#change-a-category-axis).

## **Ορισμός της μορφής ημερομηνίας για τιμές άξονα κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`), υπολογιζόμενοι ως αριθμός ημερών από τις 30 Δεκεμβρίου 1899. Χρησιμοποιήστε [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) με `CategoryAxisType.Date`, καλέστε [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) με `false`, και περάστε `yyyy` στο [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) ώστε οι ετικέτες κατηγορίας να εμφανίζουν τα τέσσερα ψηφία του έτους ανεξάρτητα από τη μορφοποίηση του κελιού.

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

## **Ορισμός γωνίας περιστροφής για τον τίτλο άξονα διαγράμματος**

Καλέστε [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) με `true` στον κατακόρυφο άξονα, παρέχετε το κείμενο του τίτλου και χρησιμοποιήστε [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα στυλό διάγραμμα με τον τίτλο του άξονα τιμής περιστρεφόμενο κατά 90 μοίρες.

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

Χρησιμοποιήστε [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) για να ελέγχετε αν ο άξονας τιμής διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία σήμανσης της κατηγορίας. Αυτή η ρύθμιση εφαρμόζεται σε άξονες κατηγορίας. Το παράδειγμα το θέτει σε `true` στον οριζόντιο άξονα κατηγορίας ενός στυλό διαγράμματος και αποθηκεύει το αποτέλεσμα.

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

Χρησιμοποιήστε [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) για να κλιμακώσετε τις ετικέτες ενός άξονα τιμής χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) ρυθμισμένο σε `Millions`, μια τιμή των 60 000 000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα στυλό διάγραμμα και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κατακόρυφο άξονα.

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

Ένας λογαριθμικός άξονας τιμής είναι χρήσιμος όταν θετικές τιμές εκτείνονται σε πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λάβει 10, 100, 1 000, 10 000 και 100 000 αιτήματα σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται πολύ κοντά στην μηδενική τιμή. Μια λογαριθμική κλίμακα κάνει τη σχετική αύξηση πιο ευανάγνωστη: ίσες αποστάσεις αντιστοιχούν σε ίσους λόγους αντί για ίσες διαφορές.

Καλέστε [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) με `true` στον άξονα τιμής και χρησιμοποιήστε [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υπάρχουσων τιμών· δεν αλλάζει τα δεδομένα ή προσθέτει λογαριθμική γραμμή τάσης. Μια γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστή λειτουργία.

### **Επιλέξτε τον άξονα τιμής και τη βάση**

Για ένα γραμμικό ή στυλό διάγραμμα, ο άξονας τιμής επιστρέφεται από [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Για ένα οριζόντιο ραβδογράφημα, επιστρέφεται από [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Τα διαγράμματα διασποράς και φυσαλίδας έχουν δύο άξονες τιμής, οπότε επιλέξτε τον οριζόντιο άξονα για τις τιμές X, τον κατακόρυφο άξονα για τις τιμές Y, ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για PPTX διαγράμματα, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένων· υποστηρίζονται και κλασματικές βάσεις όπως `2.5`. Με βάση `10`, οι διαδοχικές δυνάμεις όπως 10, 100, 1 000 και 10 000 είναι εξίσου απομακρυσμένες.

### **Σύγκριση γραμμικής και λογαριθμικής κλίμακας**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γραμμικό διάγραμμα με τις πέντε μετρήσεις αιτημάτων στην πρώτη διαφάνεια, έπειτα κλωνοποιεί αυτήν τη διαφάνεια και ενεργοποιεί έναν λογαριθμικό άξονα τιμής βάσης‑10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

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

    // Κρατήστε τη πρώτη διαφάνεια γραμμική και αλλάξτε μόνο την κλίμακα του άξονα τιμής του αντιγράφου.
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

**Linear scale (slide 1):** Ισόποσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτημάτων. Η μεγαλύτερη τιμή κυριαρχεί στο διάγραμμα, καθιστώντας τις μικρότερες τιμές δύσκολες στη διάκριση.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logarithmic scale (slide 2):** Ισόποσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες. Κάθε περίοδος έχει δέκα φορές περισσότερα αιτήματα από την προηγούμενη, οπότε τα σημεία σχηματίζουν μια ευθεία ανηφόρα στη βάση‑10 κλίμακα. Οι ετικέτες του άξονα εξακολουθούν να δείχνουν τις αρχικές μετρήσεις αιτημάτων.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Διαχείριση μηδενικών και αρνητικών τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίζει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν μηδενικές ή αρνητικές τιμές είναι σημαντικές, διατηρήστε τη γραμμική κλίμακα ή εμφανίστε τις ξεχωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την αποχή. Μην αντικαθιστάτε σιωπηρά τις τιμές με μικρούς θετικούς αριθμούς, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιοδήποτε χειροκίνητα καθορισμένο ελάχιστο ή μέγιστο για λογαριθμικό άξονα πρέπει επίσης να είναι θετικό.

## **Συχνές ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Χρησιμοποιήστε [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να ορίσετε μια αριθμητική τιμή διασταύρωσης, χρησιμοποιήστε [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση του άξονα σε ένα κατάλληλο βάση.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημείων σήμανσης σε σχέση με τον άξονα;**

Καλέστε [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για να ελέγξετε τα ίδια τα σημεία σήμανσης, χρησιμοποιήστε [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) ή [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); αυτά είναι ξεχωριστά από τη θέση των ετικετών.