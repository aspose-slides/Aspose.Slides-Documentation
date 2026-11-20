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

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τους άξονες διαγραμμάτων με το Aspose.Slides for Android μέσω Java. Καλύπτει τις υπολογιζόμενες τιμές άξονα, την εναλλαγή σειρών και στηλών διαγράμματος, την ορατότητα άξονα, τα διαστήματα ετικετών κατηγορίας και σημείων σκαλοστιγμών, τις ημερολογιακές κατηγορίες και τη διαμόρφωσή τους, την περιστροφή του τίτλου, τη θέση του άξονα, τις μονάδες εμφάνισης και την λογαριθμική κλιμάκωση.

## **Λήψη των Μέγιστων Τιμών στον Κατακόρυφο Άξονα σε Διαγράμματα**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) και προσθέστε ένα διάγραμμα περιοχής με προεπιλεγμένα δεδομένα. Καλέστε [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) πριν διαβάσετε τις υπολογιζόμενες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) και [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) για τα όρια του άξονα, καθώς και [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) και [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) για τα διαστήματα σημείων σκαλοστιγμών. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) και [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) παρέχουν κλίμακες μονάδων χρόνου, που είναι σχετικές με άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

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

## **Ανταλλαγή Δεδομένων μεταξύ Αξόνων**

Χρησιμοποιήστε [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) για να ανταλλάξετε τους ρόλους σειρών και κατηγοριών στα δεδομένα του διαγράμματος. Κάθε προηγούμενη κατηγορία γίνεται σειρά, και κάθε προηγούμενη σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κατακόρυφους άξονες. Το παράδειγμα χρησιμοποιεί [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) για να συνδέσει τα προεπιλεγμένα δεδομένα στο `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγορίας, πριν την εναλλαγή σειρών και στηλών. Αποθηκεύει ένα διάγραμμα με τέσσερις σειρές και τρεις κατηγορίες.

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

## **Αναστροφή Τάξης Σχεδίασης ενός Άξονα**

Χρησιμοποιήστε [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) για να αντιστρέψετε έναν άξονα κατηγορίας ή τιμής. Για παράδειγμα, ένα οριζόντιο γράφημα ράβδων μπορεί να εμφανίζει τα στάδια του έργου από πάνω προς τα κάτω με την ίδια σειρά όπως στο φύλλο εργασίας: Προγραμματισμός, Ανάπτυξη, Δοκιμή. Η αντιστροφή ενός άξονα αλλάζει την κατεύθυνση σχεδίασης· δεν ταξινομεί ή αναδιοργανώνει τα δεδομένα του βιβλίου εργασίας. Αντίθετα, το [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) ανταλλάσσει τους ρόλους σειρών και κατηγοριών.

Το παρακάτω παράδειγμα δημιουργεί ένα οριζόντιο γράφημα ράβδων με τρία στάδια και μία σειρά. Αποθηκεύει μια παρουσίαση με τρία σλαϊντ: κανονική σειρά, αντιστροφή κατηγοριών και αντιστροφή τιμών. Κάθε αντίγραφο χρησιμοποιεί το ίδιο σύνολο δεδομένων, και μόνο ένας άξονας είναι αντιστραμμένος σε κάθε αντίγραφο.

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

    // Διαφάνεια 2: εμφανίστε την πρώτη κατηγορία στο πάνω μέρος.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Διατηρήστε τον οριζόντιο άξονα τιμής στο κάτω μέρος.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Διαφάνεια 3: αντιστρέψτε μόνο την οριζόντια αριθμητική κλίμακα.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αντιστροφή ενός άξονα μπορεί επίσης να μετακινήσει τον κάθετο άξονα στην αντίθετη πλευρά του σχεδίου. Το [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) ελέγχει πού ο άλλος άξονας διασχίζει τον άξονα που ρυθμίζεται. Στο σλαϊντ 2, καλώντας το με `CrossesType.Maximum` στον αντιστραμμένο άξονα κατηγορίας διατηρεί τον οριζόντιο άξονα τιμής στο κάτω μέρος. Για συγκεκριμένο σημείο διασταύρωσης, χρησιμοποιήστε [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Ελέγξτε τις ρυθμίσεις διασταύρωσης όταν αλλάζετε κατεύθυνση, ειδικά αν το διάγραμμα έχει ήδη προσαρμοσμένο σημείο διασταύρωσης. Καλέστε `setPlotOrderReversed` με `false` για να επαναφέρετε την κανονική κατεύθυνση σχεδίασης· οι ρυθμίσεις διασταύρωσης είναι ξεχωριστές.

| Κανονική σειρά (σλαϊντ 1) | Αντίστροφα κατηγορίες (σλαϊντ 2) | Αντίστροφα τιμές (σλαϊντ 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| Οι κατηγορίες τρέχουν από το κάτω προς το πάνω· οι τιμές αυξάνονται από αριστερά προς δεξιά. | Προγραμματισμός, Ανάπτυξη και Δοκιμή τρέχουν από πάνω προς τα κάτω. Οι τιμές και η σειρά των γραμμών του βιβλίου εργασίας παραμένουν αμετάβλητες. | Οι κατηγορίες διατηρούν την κανονική τους σειρά· οι τιμές αυξάνονται από δεξιά προς αριστερά. Ο άξονας κατηγορίας διασχίζει στο μηδέν στα δεξιά. |

## **Απενεργοποίηση Κατακόρυφου Άξονα για Γραφήματα Γραμμών**

Καλέστε [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) με `false` στον κατακόρυφο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γράφημα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κατακόρυφο άξονα κρυμμένο.

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

## **Απενεργοποίηση Οριζόντιου Άξονα για Γραφήματα Γραμμών**

Καλέστε [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) με `false` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα γράφημα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυμμένο.

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

## **Εμφάνιση ή Απόκρυψη Πλέγματος Διαγράμματος**

Καλέστε [getShowMajorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMajorGridLines--) και [getShowMinorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMinorGridLines--) για να ελέγξετε ποιες γραμμές πλέγματος εμφανίζει ένας άξονας. Αυτές οι μέθοδοι αναφέρουν την τρέχουσα ορατότητα. Για να εμφανίσετε μικρές γραμμές πλέγματος, χρησιμοποιήστε [getMinorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) και ορίστε τη γέμιση γραμμής σε συμπαγές, ορατό χρώμα. Για να τις κρύψετε, ορίστε τη γεμίσμα σε [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/#NoFill). Χρησιμοποιήστε [getMajorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) για να αλλάξετε τη γεμίσμα γραμμής για τις κύριες γραμμές πλέγματος με τον ίδιο τρόπο. Η αλλαγή της γεμίσματος διατηρεί την ορατότητα του άξονα και τις σημειώσεις σκαλοστιγμών.

Ο κατακόρυφος άξονας αυτού του συγκεντρωτικού διαγράμματος στηλών αρχικά εμφανίζει μόνο τις κύριες γραμμές πλέγματος. Το παράδειγμα εμφανίζει τις μικρές γραμμές πλέγματος σε σκούρο πορτοκαλί, μετά τις κρύβει ξανά πριν αποθηκεύσει την παρουσίαση. Εκτυπώνει την ορατότητα των γραμμών πλέγματος σε κάθε βήμα.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(Color.rgb(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Μικρές γραμμές πλέγματος ενεργοποιημένες | Μικρές γραμμές πλέγματος κρυμμένες |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **Αλλαγή Άξονα Κατηγορίας**

Χρησιμοποιήστε [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) για να επιλέξετε άξονα ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας του Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Καλώντας το [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) με `false`, το [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) με `1`, και το [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) με `TimeUnitType.Months` τοποθετεί τις κύριες σημάνσεις σε διαστήματα ενός μήνα.

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

### **Καθορισμός Τύπου Άξονα Κατηγορίας από Δεδομένα**

Καλέστε [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) μετά την πληθώρα των κατηγοριών, έπειτα διαβάστε το [getCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getCategoryAxisType--) για να ελέγξετε την επιλογή. Αυτό είναι χρήσιμο όταν το ίδιο διάγραμμα λαμβάνει είτε ετικέτες κειμένου είτε αριθμητικές τιμές ημερομηνίας. Η μέθοδος καθορίζει τον τύπο όταν κληθεί· δεν ενεργοποιεί μόνιμη λειτουργία που επανεκτιμά μεταγενέστερες αλλαγές δεδομένων. Καλέστε την ξανά μετά την αντικατάσταση των κατηγοριών.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα με κειμενικές κατηγορίες και εκτυπώνει `true` όταν ο επιλεγμένος τύπος είναι `CategoryAxisType.Text`. Στη συνέχεια αντικαθιστά τις τιμές των κελιών κατηγορίας με ημερομηνίες και καλεί τη μέθοδο ξανά, εκτυπώνοντας `true` όταν ο επιλεγμένος τύπος είναι `CategoryAxisType.Date`. Οι ημερομηνίες αποθηκεύονται ως αριθμητικές τιμές OLE Automation, υπολογισμένες ως ο αριθμός των ημερών από τις 30 Δεκεμβρίου 1899, αντί για συμβολοσειρές ημερομηνίας. Και τα δύο ημερολογιακά συστήματα χρησιμοποιούν UTC και εκκαθαρίζονται πριν τον ορισμό των ημερομηνιών ώστε η θερινή ώρα και η τρέχουσα ώρα της ημέρας να μην επηρεάζουν τον υπολογισμό. Το [setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) ελέγχει πώς εμφανίζονται αυτές οι τιμές· δεν μετατρέπει κείμενο σε αριθμητικές ημερομηνίες. Για περισσότερα σχετικά με κελιά κατηγορίας, δείτε το [Chart Workbook](/slides/el/androidjava/chart-workbook/).

Χρησιμοποιήστε αυτόματη καθορισμό όταν η είσοδος περιέχει γνωστές κειμενικές κατηγορίες ή αριθμητικές ημερομηνίες, όπως σε αυτό το παράδειγμα. Για απλές αριθμητικές ετικέτες, ανάμικτες κατηγορίες ή κενά δεδομένα, καλέστε ρητά το [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisType-int-) για να ταιριάξετε την προθέσμία σημασίας. Μόνο οι αριθμητικές τιμές δεν καθορίζουν ότι οι κατηγορίες αντιπροσωπεύουν ημερομηνίες.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // αληθές

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);
    int[][] dates = { { 2026, Calendar.JANUARY, 1 }, { 2026, Calendar.JANUARY, 2 }, { 2026, Calendar.FEBRUARY, 1 } };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(dates[i][0], dates[i][1], dates[i][2]);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        categoryCell.setValue(serialDate);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // αληθές

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Διαστημάτων Ετικετών Άξονα Κατηγορίας**

Όταν ένα διάγραμμα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Καλέστε [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) με `false`, στη συνέχεια περάστε το επιθυμητό διάστημα κατηγορίας στο [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Για κειμενικές κατηγορίες στη κανονική τους σειρά, η αρίθμηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη απόσταση επιλέγει διάστημα βάσει του διαθέσιμου χώρου· δεν εμφανίζει υποχρεωτικά κάθε ετικέτα.

Οι σημάνσεις σκαλοστιγμών έχουν ξεχωριστό έλεγχο. Καλέστε [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) με `false` και χρησιμοποιήστε το [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) για να θέσετε το διάστημα τους. Για παράδειγμα, `1` διατηρεί μια σημάνση σκαλοστιγμού σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) με ορατό στυλ για να δείτε το αποτέλεσμα. Η επαναφορά του αυτόματου διαστήματος με `true` επιτρέπει στο διάγραμμα να επιλέξει ξανά αυτό το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, έπειτα αποθηκεύει τρία σλαϊντ στο `CategoryAxisIntervals.pptx`: αυτόματη απόσταση, χειροκίνητη απόσταση ετικετών με ανεξάρτητες σημάνσεις σκαλοστιγμών, και επαναφορά αυτόματης απόστασης. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται εισαγωγική παρουσίαση. Το οριζόντιο κείμενο των ετικετών κάνει τη διαφορά στην πυκνότητα εύκολα αντιληπτή.

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

    // Διαφάνεια 2: εμφάνιση κάθε τρίτης ετικέτας, αλλά διατήρηση σημάνσεως σκαλοστιγμού για κάθε κατηγορία.
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

**Αυτόματη απόσταση (σλαϊντ 1):** Σε αυτή την απόδοση, εμφανίζεται κάθε δεύτερη ετικέτα κατηγορίας και τυλίγεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και τον renderer.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Χειροκίνητη απόσταση (σλαϊντ 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μια γραμμή, ενώ οι σημάνσεις σκαλοστιγμών παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων αυτών χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Το σλαϊντ 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Επιλογή Σωστού Άξονα και Διαστήματος**

Χρησιμοποιήστε αυτό το διάστημα αριθμού κατηγοριών για άξονα κειμενικής κατηγορίας, όπως ο άξονας κατηγορίας ενός διαγράμματος στήλης, γραμμής, περιοχής ή ράβδας. Σε διάγραμμα στήλης, είναι ο οριζόντιος άξονας. Σε οριζόντιο διάγραμμα ράβδων, ο άξονας κατηγορίας είναι κατακόρυφος, οπότε εφαρμόστε αυτές τις ρυθμίσεις στον άξονα που επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Η απόσταση σημάνσεων σκαλοστιγμών ισχύει επίσης για άξονα σειράς σε διαγράμματα που έχουν έναν.

Μην χρησιμοποιείτε την απόσταση ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμής. Σε άξονα τιμής, το [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) ορίζει τη διαφορά τιμών: π.χ., μια κύρια μονάδα `10` παράγει σημάνσεις στα 0, 10, 20 κ.ο.κ. όταν ο άξονας ξεκινά στο μηδέν. Διάστημα ετικέτας κατηγορίας `3` αντίθετα μετρά τις θέσεις κατηγορίας, ανεξάρτητα από τις τιμές των δεδομένων. Τα διαγράμματα scatter και bubble χρησιμοποιούν άξονες τιμής αντί για άξονα κειμενικής κατηγορίας. Για άξονα ημερομηνίας, χρησιμοποιήστε μονάδες χρόνου και κλίμακες όπως περιγράφεται στην ενότητα [Change a Category Axis](#change-a-category-axis).

## **Ορισμός Μορφής Ημερομηνίας για Τιμές Άξονα Κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`), υπολογιζόμενοι ως ο αριθμός των ημερών από τις 30 Δεκεμβρίου 1899 για αυτές τις ημερομηνίες. Και τα δύο ημερολόγια χρησιμοποιούν UTC και εκκαθαρίζονται πριν τον ορισμό των ημερομηνιών ώστε η θερινή ώρα και η τρέχουσα ώρα της ημέρας να μην επηρεάζουν τον υπολογισμό. Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) με `CategoryAxisType.Date`, καλέστε το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) με `false`, και περάστε `yyyy` στο [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) ώστε οι ετικέτες κατηγορίας να εμφανίζουν τέσσερα ψηφία έτους ανεξάρτητα από τη μορφή κελιού.

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

Καλέστε [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) με `true` στον κατακόρυφο άξονα, παράσχετε κείμενο τίτλου, και χρησιμοποιήστε το [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα στήλης με τον τίτλο του άξονα τιμής περιστραμμένο κατά 90 μοίρες.

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

Χρησιμοποιήστε το [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) για να ελέγξετε αν ο άξονας τιμής διασχίζει τον άξονα κατηγορίας μεταξύ κατηγοριών ή σε σημάνσεις κατηγορίας. Αυτή η ρύθμιση ισχύει για άξονες κατηγορίας. Το παράδειγμα το ορίζει σε `true` στον οριζόντιο άξονα κατηγορίας ενός διαγράμματος στήλης και αποθηκεύει το αποτέλεσμα.

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

Χρησιμοποιήστε το [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) για να κλιμακώσετε τις ετικέτες ενός άξονα τιμής χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) ορισμένο σε `Millions`, μια τιμή των 60 000 000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα διάγραμμα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κατακόρυφο άξονά του.

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

Ένας λογαριθμικός άξονας τιμής είναι χρήσιμος όταν θετικές τιμές εκτείνονται σε πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1 000, 10 000 και 100 000 αιτήματα σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται κοντά στη μηδενική τιμή. Μια λογαριθμική κλίμακα κάνει τη σχετική τους αύξηση πιο εύκολη στη σύγκριση: ίσες αποστάσεις αντιπροσωπεύουν ίσους λόγους αντί για ίσες διαφορές.

Καλέστε [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) με `true` στον άξονα τιμής και χρησιμοποιήστε το [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υπαρχουσών τιμών· δεν αλλάζει τα δεδομένα ή προσθέτει λογαριθμική γραμμή τάσης. Μια γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστό χαρακτηριστικό.

### **Επιλογή Άξονα Τιμής και Βάσης**

Για ένα γράφημα γραμμής ή στήλης, ο άξονας τιμής επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Για ένα οριζόντιο γράφημα ράβδων, επιστρέφεται από το [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Τα διαγράμματα scatter και bubble έχουν δύο άξονες τιμής, οπότε επιλέξτε τον οριζόντιο άξονα για τις τιμές X, τον κατακόρυφο για τις τιμές Y, ή και τους δύο. Μην εφαρμόσετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένων· υποστηρίζονται επίσης κλασματικές βάσεις όπως `2.5`. Με βάση `10`, διαδοχικές δυνάμεις όπως 10, 100, 1 000 και 10 000 είναι εξίσου διαστημένες.

### **Σύγκριση Γραμμικής και Λογαριθμικής Κλιμάκωσης**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γράφημα γραμμής με τις πέντε μετρήσεις αιτήσεων στην πρώτη διαφάνεια, έπειτα κλωνοποιεί αυτή τη διαφάνεια και ενεργοποιεί λογαριθμικό άξονα τιμής βάσης‑10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

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

    // Διατηρήστε την πρώτη διαφάνεια γραμμική και αλλάξτε μόνο την κλίμακα του άξονα τιμής του αντιγράφου.
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

**Γραμμική κλίμακα (σλαϊντ 1):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτήσεων. Η μεγαλύτερη τιμή κυριαρχεί στο διάγραμμα, καθιστώντας δύσκολη τη διάκριση των μικρότερων τιμών.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Λογαριθμική κλίμακα (σλαϊντ 2):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσους λόγους. Κάθε περίοδος έχει δέκα φορές περισσότερα αιτήματα από την προηγούμενη, οπότε τα σημεία σχηματίζουν μια ευθεία ανερχόμενη γραμμή στη βάση‑10 κλίμακα. Οι ετικέτες του άξονα εξακολουθούν να δείχνουν τις αρχικές μετρήσεις.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Διαχείριση Μηδενικών και Αρνητικών Τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν μηδενικά ή αρνητικές τιμές είναι σημαντικές, διατηρήστε μια γραμμική κλίμακα ή εμφανίστε τις χωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παροχή. Μην αντικαθιστάτε σιωπηλά τις τιμές με μικρούς θετικούς αριθμούς, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιοδήποτε χειροκίνητα καθορισμένο ελάχιστο ή μέγιστο για λογαριθμικό άξονα πρέπει επίσης να είναι θετικό.

## **Συχνές Ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Χρησιμοποιήστε το [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να προσδιορίσετε αριθμητική τιμή διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Αυτές οι ρυθμίσεις σάς επιτρέπουν να μετακινήσετε τη διασταύρωση του άξονα σε μια κατάλληλη βάση.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σκαλοστιγμών σχετικώς με τον άξονα;**

Καλέστε το [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για να ελέγξετε τις ίδια τις σημάνσεις σκαλοστιγμών, χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) ή το [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); αυτά είναι ξεχωριστά από τη θέση των ετικετών.