---
title: Προσαρμογή διαγραμμάτων πίτας σε παρουσιάσεις χρησιμοποιώντας Java
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/java/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές παραστάσεων
- χρώμα φέτας
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα πίτας σε Java με Aspose.Slides. Ρυθμίστε δευτερεύουσες παραστάσεις, εμφανίστε τις ετικέτες δεδομένων και εφαρμόστε αυτόματα χρώματα φετών σε PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλέψετε με διαγράμματα πίτας στο Aspose.Slides. Δείχνει πώς να ρυθμίσετε τις επιλογές δευτερεύουσας παράστασης για τα διαγράμματα Pie of Pie και Bar of Pie, καθώς και πώς να ενεργοποιήσετε τον αυτόματο χρωματισμό των φετών για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα εστιάζουν σε εργασίες προσαρμογής διαγραμμάτων όπως η προσθήκη ενός διαγράμματος σε μια διαφάνεια, η προσαρμογή των ρυθμίσεων σειράς και ετικέτας, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Δεύτερες Επιλογές Παραστάσεων για Διαγράμματα Pie of Pie και Bar of Pie**

Το Aspose.Slides for Java υποστηρίζει επιλογές δευτερεύουσας παράστασης για τα διαγράμματα Pie of Pie και Bar of Pie. Αυτές οι επιλογές ελέγχουν το μέγεθος της δευτερεύουσας παράστασης και πώς τα σημεία δεδομένων χωρίζονται μεταξύ των δύο παραστάσεων.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα Pie of Pie σε μια νέα παρουσίαση και εμφανίζει τις τιμές των σημείων δεδομένων ως ετικέτες. Η μέθοδος [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) ορίζει το μέγεθος της δευτερεύουσας παράστασης στο 149% της κύριας παράστασης. Η [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) επιλέγει διαίρεση βάσει ποσοστού, και η [setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) ορίζει το όριο στο 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Εμφάνιση τιμών και διαμόρφωση της δευτερεύουσας παράστασης.
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

### **Επιλέξτε Κατηγορίες για τη Δευτερεύουσα Παράσταση**

Χρησιμοποιήστε προσαρμοσμένη διαίρεση όταν θέλετε να ομαδοποιήσετε συγκεκριμένες κατηγορίες στη δευτερεύουσα παράσταση ανεξάρτητα από τις τιμές ποσοστών τους. Για παράδειγμα, μια αναφορά πωλήσεων μπορεί να εμφανίζει το Online και τα Events μαζί ώστε οι αναγνώστες να μπορούν να συγκρίνουν αυτά τα δύο κανάλια, ακόμη κι αν αντιπροσωπεύουν το 35% και το 10% των συνολικών πωλήσεων.

Καλείτε τη [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) με την [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) και επιλέγετε τα σημεία μέσω της [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Η μέθοδος [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-) της συλλογής δέχεται έναν δείκτη μηδενικής βάσης στη σειρά· χρησιμοποιήστε τη [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) για να προσθέσετε ένα αντικείμενο σημείου δεδομένων. Σε αυτό το παράδειγμα, ο δείκτης 1 επιλέγει το Online, και το σημείο στη θέση 3 επιλέγει το Events. Το Partners προστίθεται επίσης προσωρινά, στη συνέχεια αποκλείεται χρησιμοποιώντας τη [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Αντικατάσταση των προεπιλεγμένων δεδομένων με τις πωλήσεις ανά κανάλι.
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

    // Επιλέξτε Online με τον δείκτη μηδενικής βάσης του και Events με το αντικείμενο σημείου δεδομένων.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Αποκλείστε το Partners από την επιλογή χωρίς να διαγράψετε τα πηγαία δεδομένα του.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το Online (35) και τα Events (10) εμφανίζονται ως ξεχωριστές φέτες στη δευτερεύουσα παράσταση. Στην κύρια παράσταση, αντιπροσωπεύονται από μία συνδυασμένη φέτα με τιμή 45, μαζί με το Retail (40) και το Partners (15). Η αφαίρεση του Partners από την προσαρμοσμένη επιλογή το κρατά στην κύρια παράσταση· δεν αφαιρεί την κατηγορία ή την τιμή της από τα δεδομένα προέλευσης του διαγράμματος.

Η παρακάτω εικόνα δείχνει την αποθηκευμένη παρουσίαση στο PowerPoint:

![Διάγραμμα Pie of Pie με Online και Events στη δευτερεύουσα παράσταση και την συνδυασμένη τιμή τους 45 στην κύρια παράσταση](pie_of_pie_custom.png)

## **Ορισμός Αυτόματων Χρωμάτων Φετών Διαγράμματος Πίτας**

Το Aspose.Slides for Java μπορεί αυτόματα να αναθέσει διαφορετικά χρώματα στις φέτες του διαγράμματος πίτας. Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα πίτας με κεντραρισμένο τίτλο και αντικαθιστά τα προεπιλεγμένα δεδομένα με τρεις τριμηνιαίες κατηγορίες και τις τιμές τους. Η μέθοδος [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) εμφανίζει τις τιμές 20, 50 και 30 ως ετικέτες, ενώ η [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) ενεργοποιεί διαφορετικό χρώμα για κάθε φέτα.

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

Ναι, η βιβλιοθήκη [supports](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) μια δευτερεύουσα παράσταση για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων Pie of Pie και Bar of Pie.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (για παράδειγμα, PNG);**

Ναι, μπορείτε να [export the chart itself as an image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (όπως PNG) χωρίς να εξάγετε ολόκληρη την παρουσίαση.