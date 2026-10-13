---
title: Προσαρμογή αξόνων διαγράμματος σε παρουσιάσεις στο Android
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
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για Android μέσω Java για να προσαρμόσετε τους άξονες διαγράμματος σε παρουσιάσεις PowerPoint για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τους άξονες των διαγραμμάτων με το Aspose.Slides για Android μέσω Java. Καλύπτει τις υπολογισμένες τιμές των άξονων, την εναλλαγή γραμμών και στηλών του διαγράμματος, την ορατότητα του άξονα, τα διαστήματα ετικετών κατηγορίας και σημαδιών, τις ημερομηνιακές κατηγορίες και τη μορφοποίηση, την περιστροφή του τίτλου, τη θέση του άξονα, τις μονάδες εμφάνισης και τη λογαριθμική κλιμάκωση.

## **Λήψη των μέγιστων τιμών στον κατακόρυφο άξονα των διαγραμμάτων**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) και προσθέστε ένα γράφημα περιοχής με προεπιλεγμένα δεδομένα. Καλέστε το [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) πριν διαβάσετε τις υπολογισμένες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε το [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) και το [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) για τα όρια του άξονα, και το [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) και το [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) για τα διαστήματα των σημείων. Το [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) και το [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) παρέχουν κλίμακες χρονικής μονάδας, οι οποίες είναι σχετικές με άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

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

## **Ανταλλαγή των δεδομένων μεταξύ των αξόνων**

Χρησιμοποιήστε το [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα του διαγράμματος. Κάθε προηγούμενη κατηγορία γίνεται σειρά, και κάθε προηγούμενη σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάζει τους οριζόντιους και κατακόρυφους άξονες. Το παράδειγμα χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) για να συνδέσει τα προεπιλεγμένα δεδομένα με το `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγοριών, πριν την εναλλαγή γραμμών και στηλών. Αποθηκεύει ένα διάγραμμα με τέσσερις σειρές και τρεις κατηγορίες.

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

## **Απενεργοποίηση του κατακόρυφου άξονα για διαγράμματα γραμμής**

Καλέστε το [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) με `false` στον κατακόρυφο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με κρυφό τον κατακόρυφο άξονα.

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

Καλέστε το [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) με `false` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με κρυφό τον οριζόντιο άξονα.

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

Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) για να επιλέξετε έναν άξονα κατηγορίας ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας του Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Καλώντας το [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) με `false`, το [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) με `1` και το [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) με `TimeUnitType.Months` τοποθετεί μεγάλες σημαδίες σε διαστήματα ενός μήνα.

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

Όταν ένα διάγραμμα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών του άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Καλέστε το [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) με `false`, μετά περάστε το επιθυμητό διάστημα κατηγοριών στο [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Για κατηγορίες κειμένου στη φυσική τους σειρά, η μέτρηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Ένα διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη απόσταση επιλέγει ένα διάστημα βάσει του διαθέσιμου χώρου· δεν εμφανίζει απαραίτητα κάθε ετικέτα.

Οι σημαδίες των σημείων έχουν ξεχωριστούς ελέγχους. Καλέστε το [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) με `false` και χρησιμοποιήστε το [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) για να ορίσετε το διάστημά τους. Για παράδειγμα, το `1` διατηρεί μια σημαδία σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) με ένα ορατό στυλ ώστε να μπορείτε να δείτε το αποτέλεσμα. Η κλήση οποιουδήποτε από τους αυτόματους ρυθμιστές με `true` ξανά επιτρέπει στο διάγραμμα να επιλέξει ξανά αυτό το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, μετά αποθηκεύει τρεις διαφάνειες στο `CategoryAxisIntervals.pptx`: αυτόματη διάσταση, χειροκίνητη διάσταση ετικετών με ανεξάρτητες σημαδίες σημείων και επαναφορά της αυτόματης διάστασης. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται εισαγωγική παρουσίαση. Το οριζόντιο κείμενο ετικέτας κάνει τη διαφορά στην πυκνότητα εύκολα ορατή.

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

**Αυτόματη διάσταση (διαφάνεια 1):** Σε αυτήν την απόδοση, εμφανίζεται κάθε δεύτερη ετικέτα κατηγορίας και εμφανίζεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και το πρόγραμμα απόδοσης.

![Αυτόματη διάσταση ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητη διάσταση (διαφάνεια 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μία γραμμή, ενώ οι σημαδίες παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων αυτών χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Χειροκίνητο διάστημα ετικετών κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλέξτε τον σωστό άξονα και το διάστημα**

Χρησιμοποιήστε αυτό το διάστημα καταμέτρησης κατηγοριών για έναν άξονα κατηγορίας κειμένου, όπως ο άξονας κατηγορίας ενός ραβδίου, γραμμής, περιοχής ή ραβδου. Σε διάγραμμα στήλης, είναι ο οριζόντιος άξονας. Σε οριζόντιο διάγραμμα ράβδων, ο άξονας κατηγορίας είναι κατακόρυφος, επομένως εφαρμόστε αυτές τις ρυθμίσεις στον άξονα που επιστρέφει το [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Η απόσταση σημαδιών εφαρμόζεται επίσης σε άξονα σειράς σε διαγράμματα που έχουν έναν.

Μην χρησιμοποιείτε τη διάσταση ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμών. Σε άξονα τιμών, το [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) καθορίζει τη διαφορά τιμών: για παράδειγμα, μια κύρια μονάδα `10` παράγει σημεία στα 0, 10, 20 κλπ όταν ο άξονας ξεκινά από το μηδέν. Ένα διάστημα ετικετών κατηγορίας `3` μετρά αντίθετα τις θέσεις κατηγορίας, ανεξάρτητα από τις τιμές των δεδομένων τους. Τα διαγράμματα σκόρπισης και φυσαλίδας χρησιμοποιούν άξονες τιμών αντί για άξονα κειμένου. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες και κλίμακες βασισμένες στον χρόνο όπως περιγράφεται στο [Change a Category Axis](#change-a-category-axis).

## **Ορισμός μορφής ημερομηνίας για τιμές άξονα κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα του διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`), υπολογιζόμενοι ως ο αριθμός ημερών από τις 30 Δεκεμβρίου 1899 για αυτές τις ημερομηνίες. Και τα δύο ημερολόγια χρησιμοποιούν UTC και καθαρίζονται πριν οριστούν οι ημερομηνίες ώστε η θερινή ώρα και η τρέχουσα ώρα της ημέρας να μην επηρεάζουν τον υπολογισμό. Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) με `CategoryAxisType.Date`, καλέστε το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) με `false` και περάστε `yyyy` στο [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) ώστε οι ετικέτες κατηγορίας να εμφανίζουν έτη τετραψήφια ανεξάρτητα από τη μορφοποίηση των κελιών.

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

## **Ορισμός γωνίας περιστροφής για τον τίτλο άξονα διαγράμματος**

Καλέστε το [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) με `true` στον κατακόρυφο άξονα, δώστε το κείμενο του τίτλου και χρησιμοποιήστε το [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα στήλης με τον τίτλο του άξονα τιμών περιστραμμένο κατά 90 μοίρες.

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

Χρησιμοποιήστε το [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) για να ελέγξετε αν ο άξονας τιμών διασχίζει τον άξονα κατηγορίας μεταξύ κατηγοριών ή στα σημεία των κατηγοριών. Αυτή η ρύθμιση εφαρμόζεται σε άξονες κατηγορίας. Το παράδειγμα το θέτει σε `true` στον οριζόντιο άξονα κατηγορίας ενός διαγράμματος στήλης και αποθηκεύει το αποτέλεσμα.

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

## **Ορισμός μονάδας εμφάνισης σε άξονα τιμών διαγράμματος**

Χρησιμοποιήστε το [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) για να κλιμακώσετε τις ετικέτες σε άξονα τιμών χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) ορισμένο σε `Millions`, μια τιμή των 60.000.000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα διάγραμμα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κατακόρυφο άξονα του.

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

## **Διαμόρφωση λογαριθμικού άξονα τιμών**

Ένας λογαριθμικός άξονας τιμών είναι χρήσιμος όταν οι θετικές τιμές εκτείνονται σε πολλά επίπεδα μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1.000, 10.000 και 100.000 αιτήματα σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται κοντά μεταξύ τους κοντά στο μηδέν. Μια λογαριθμική κλίμακα κάνει τη σχετική ανάπτυξή τους πιο εύκολη στη σύγκριση: ίσες αποστάσεις αντιστοιχούν σε ίσες αναλογίες αντί για ίσες διαφορές.

Καλέστε το [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) με `true` στον άξονα τιμών και χρησιμοποιήστε το [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υπάρχουσων τιμών· δεν αλλάζει τα δεδομένα ή προσθέτει λογαριθμική γραμμή τάσης. Μία γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και αποτελεί ξεχωριστή λειτουργία.

### **Επιλέξτε τον άξονα τιμών και τη βάση**

Για διάγραμμα γραμμής ή στήλης, ο άξονας τιμών επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Για οριζόντιο διάγραμμα ράβδων, επιστρέφεται από το [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Τα διαγράμματα σκόρπισης και φυσαλίδας έχουν δύο άξονες τιμών, επομένως επιλέξτε τον οριζόντιο άξονα για τιμές X, τον κατακόρυφο άξονα για τιμές Y ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένου· υποστηρίζονται επίσης κλασματικές βάσεις όπως `2.5`. Με βάση `10`, διαδοχικές δυνάμεις όπως 10, 100, 1.000 και 10.000 είναι εξίσου διαστημένες.

### **Σύγκριση γραμμικής και λογαριθμικής κλιμάκωσης**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με τις πέντε μετρήσεις αιτημάτων στην πρώτη διαφάνεια, έπειτα κλωνοποιεί αυτή τη διαφάνεια και ενεργοποιεί έναν λογαριθμικό άξονα τιμών βάσης 10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

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

**Γραμμική κλίμακα (διαφάνεια 1):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτημάτων. Η μεγαλύτερη τιμή κυριαρχεί στο διάγραμμα, καθιστώντας τις μικρότερες τιμές δύσκολο να διακριθούν.

![Διάγραμμα γραμμής στο PowerPoint που δείχνει πέντε μετρήσεις αιτημάτων σε γραμμικό άξονα τιμών](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες αναλογίες. Κάθε περίοδος έχει δέκα φορές περισσότερα αιτήματα από την προηγούμενη, έτσι τα σημεία σχηματίζουν μια ευθεία ανερχόμενη γραμμή στη βάση-10 κλίμακα. Οι ετικέτες του άξονα εξακολουθούν να δείχνουν τις αρχικές μετρήσεις αιτημάτων.

![Οι ίδιες πέντε μετρήσεις αιτημάτων στο PowerPoint σε λογαριθμικό άξονα τιμών βάσης 10](value-axis-logarithmic.png)

### **Διαχείριση μηδενικών και αρνητικών τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν οι μηδενικές ή αρνητικές τιμές είναι σημαντικές, διατηρήστε μια γραμμική κλίμακα ή εμφανίστε τες χωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μην αντικαθιστάτε σιωπηρά τις με μικρούς θετικούς αριθμούς, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιοδήποτε χειροκίνητα ρυθμισμένο ελάχιστο ή μέγιστο για λογαριθμικό άξονα πρέπει επίσης να είναι θετικό.

## **Συχνές ερωτήσεις**

**Πώς ορίζω την τιμή όπου ένας άξονα διασχίζει τον άλλο (διασταύρωση άξονα);**

Χρησιμοποιήστε το [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να ορίσετε μια αριθμητική τιμή διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση του άξονα σε μια κατάλληλη βάση.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημάτων σε σχέση με τον άξονα;**

Καλέστε το [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για να ελέγξετε τις ίδιες τις σημαδίες, χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) ή το [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); αυτά είναι ξεχωριστά από τη θέση των ετικετών.