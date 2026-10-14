---
title: Προσαρμογή Διαγραμμάτων Πίτας σε Παρουσιάσεις στο Android
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/androidjava/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές απεικόνισης
- χρώμα φέτας
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα πίτας στο Android με το Aspose.Slides for Android via Java. Διαμορφώστε δευτερεύουσες απεικονίσεις, εμφανίστε ετικέτες δεδομένων και εφαρμόστε αυτόματη χρωματική απόδοση φετών στο PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με διαγράμματα πίτας στο Aspose.Slides. Δείχνει πώς να διαμορφώσετε τις επιλογές δευτερεύουσας απεικόνισης για διαγράμματα Pie of Pie και Bar of Pie, και πώς να ενεργοποιήσετε την αυτόματη χρωματική απόδοση των φετών για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα εστιάζουν σε εργασίες προσαρμογής διαγράμματος, όπως η προσθήκη διαγράμματος σε διαφάνεια, η ρύθμιση σειρών και ετικετών, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Δευτερεύουσες Επιλογές Απεικόνισης για Διαγράμματα Pie of Pie και Bar of Pie**

Το Aspose.Slides for Android μέσω Java υποστηρίζει επιλογές δευτερεύουσας απεικόνισης για διαγράμματα Pie of Pie και Bar of Pie. Αυτές οι επιλογές ελέγχουν το μέγεθος της δευτερεύουσας απεικόνισης και τον τρόπο διαχωρισμού των σημείων δεδομένων μεταξύ των δύο απεικονίσεων.

Το ακόλουθο παράδειγμα δημιουργεί ένα διάγραμμα Pie of Pie σε μια νέα παρουσίαση και εμφανίζει τις τιμές των σημείων δεδομένων ως ετικέτες. Η [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) μέθοδος ορίζει το μέγεθος της δευτερεύουσας απεικόνισης στο 149% της κύριας απεικόνισης. Η [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) επιλέγει διαχωρισμό βάσει ποσοστών, και η [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) ορίζει το όριο στο 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Εμφάνιση τιμών και διαμόρφωση της δευτερεύουσας απεικόνισης.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Επιλογή Κατηγοριών για τη Δευτερεύουσα Απεικόνιση**

Χρησιμοποιήστε προσαρμοσμένο διαχωρισμό όταν θέλετε να ομαδοποιήσετε συγκεκριμένες κατηγορίες στη δευτερεύουσα απεικόνιση ανεξάρτητα από τα ποσοστά τους. Για παράδειγμα, μια αναφορά πωλήσεων μπορεί να εμφανίζει τα Online και Events μαζί ώστε οι αναγνώστες να μπορούν να συγκρίνουν αυτά τα δύο κανάλια, παρόλο που αντιστοιχούν σε 35% και 10% των συνολικών πωλήσεων.

Καλέστε τη [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) με την [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) και επιλέξτε τα σημεία μέσω της [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Η μέθοδος [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) της συλλογής δέχεται έναν δείκτη που ξεκινά από το μηδέν στη σειρά· χρησιμοποιήστε τη [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) για να προσθέσετε ένα αντικείμενο σημείου δεδομένων. Σε αυτό το παράδειγμα, ο δείκτης 1 επιλέγει Online και το σημείο με δείκτη 3 επιλέγει Events. Η κατηγορία Partners προστίθεται επίσης προσωρινά, και στη συνέχεια εξαιρείται χρησιμοποιώντας τη [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Αντικατάσταση των προεπιλεγμένων δεδομένων με πωλήσεις ανά κανάλι.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Επίλεξε το Online με τον μηδενικό του δείκτη και τα Events με το αντικείμενο σημείου δεδομένων.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Εξαίρεση των Partners από την επιλογή χωρίς διαγραφή των δεδομένων προέλευσής τους.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το Online (35) και τα Events (10) εμφανίζονται ως ξεχωριστές φέτες στη δευτερεύουσα απεικόνιση. Στην κύρια απεικόνιση, αντιπροσωπεύονται από μία ενιαία φέτα με τιμή 45, μαζί με το Retail (40) και τους Partners (15). Η αφαίρεση των Partners από την προσαρμοσμένη επιλογή τα διατηρεί στην κύρια απεικόνιση· δεν αφαιρεί την κατηγορία ή την τιμή της από τα δεδομένα προέλευσης του διαγράμματος.

Η ακόλουθη εικόνα δείχνει την αποθηκευμένη παρουσίαση στο PowerPoint:

![Διάγραμμα Pie of Pie με Online και Events στη δευτερεύουσα απεικόνιση και τη συνδυασμένη τιμή τους 45 στην κύρια απεικόνιση](pie_of_pie_custom.png)

## **Ρύθμιση Αυτόματων Χρωμάτων Φετών Διαγράμματος Πίτας**

Το Aspose.Slides for Android μέσω Java μπορεί αυτόματα να αντιστοιχίσει διαφορετικά χρώματα στις φέτες του διαγράμματος πίτας. Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα πίτας με κεντρικό τίτλο και αντικαθιστά τα προεπιλεγμένα δεδομένα με τρεις τριμηνιαίες κατηγορίες και τις τιμές τους. Η [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) μέθοδος εμφανίζει τις τιμές 20, 50 και 30 ως ετικέτες, ενώ η [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) ενεργοποιεί διαφορετικό χρώμα για κάθε φέτα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Προσθήκη κεντραρισμένου τίτλου διαγράμματος.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Αντικατάσταση των προεπιλεγμένων δεδομένων χρησιμοποιώντας το πρώτο φύλλο εργασίας.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Εμφάνιση τιμών και ανάθεση διαφορετικών χρωμάτων στις φέτες.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζονται οι παραλλαγές Pie of Pie και Bar of Pie;**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) μια δευτερεύουσα απεικόνιση για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων Pie of Pie και Bar of Pie.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το ίδιο το διάγραμμα ως εικόνα](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (π.χ. PNG) χωρίς να εξάγετε ολόκληρη την παρουσίαση.