---
title: Διαχείριση Σειρών Δεδομένων Διαγράμματος σε Παρουσιάσεις σε Java
linktitle: Σειρές Δεδομένων
type: docs
url: /el/java/chart-series/
keywords:
- σειρές διαγράμματος
- επικάλυψη σειράς
- χρώμα σειράς
- όνομα σειράς
- σημείο δεδομένων
- κελί βιβλίου εργασίας
- διάστημα σειράς
- αρνητική τιμή
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σειρές διαγράμματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος κενών και αρνητικές τιμές σε παρουσιάσεις με Java."
---
## **Επισκόπηση**

Ένα διάγραμμα αποθηκεύει τα δεδομένα που σχεδιάζει σε ένα βιβλίο δεδομένων διαγράμματος. Ένα [IChartSeries](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [IChartDataPoint](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatapoint/) στη σειρά αναφέρεται σε ένα ή περισσότερα κελιά του βιβλίου. Τα αντικείμενα [IChartCategory](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται από τις σειρές. Το όνομα της σειράς, οι κατηγορίες και οι τιμές των σημείων είναι επομένως συνδεδεμένα με αντικείμενα [IChartDataCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/) αντί να αποθηκεύονται μόνο ως κείμενο εμφάνισης.

Για ένα τυπικό διάγραμμα κατηγορίας, το προεπιλεγμένο βιβλίο δεδομένων χρησιμοποιεί τη σειρά 0 για τα ονόματα των σειρών, τη στήλη 0 για τα ονόματα των κατηγοριών και τα υπόλοιπα κελιά για τις τιμές των σειρών. Οι δείκτες φύλλου εργασίας, σειράς και στήλης που περνούν στο [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) είναι μηδενικής βασής. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα διάγραμμα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον διάγραμμα το χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά που αναφέρονται από τις σειρές, τις κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου.

Οι ρυθμίσεις διαγράμματος έχουν τρία διαφορετικά πεδία εφαρμογής:
- Ρυθμίσεις επιπέδου σειράς, όπως [IChartSeries.getFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseries/#getFormat--), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία σε μία σειρά.
- Ρυθμίσεις σημείου δεδομένων, όπως [IChartDataPoint.getFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatapoint/#getFormat--), παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στο ίδιο [IChartSeriesGroup](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseriesgroup/). Πρόσβαση στην ομάδα μέσω του [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) όταν χρειάζεται να ορίσετε επιλογές όπως επικάλυψη ή πλάτος κενών.

Όταν δεν έχει οριστεί ρητό γέμισμα σημείου ή σειράς, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο μορφοποίηση σειράς όσο και σημείου, η μορφοποίηση του σημείου προλαμβάνει για εκείνο το σημείο.

![Σειρές-διαγράμματος-PowerPoint](chart-series-powerpoint.png)

## **Ορισμός Επικάλυψης Σειράς Διαγράμματος**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseries/#getOverlap--) αναφέρει πόσο οι μπάρες ή οι στήλες επικαλύπτονται σε ένα διάγραμμα 2Δ, από -100 έως 100 τοις εκατό. Είναι μια ανάγνωση μόνο της ρύθμισης στην γονική ομάδα σειρών. Χρησιμοποιήστε [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) για να ενημερώσετε κάθε συμβατή σειρά σε αυτήν την ομάδα. Αυτή η επιλογή εφαρμόζεται σε τύπους διαγραμμάτων που εμφανίζουν ομαδοποιημένες μπάρες ή στήλες· δεν επηρεάζει ανεξάρτητες ομάδες σειρών σε ένα συνδυαστικό διάγραμμα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Το νέο διάγραμμα περιέχει δείγμα σειρών, κατηγοριών και τιμών.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η επικάλυψη της σειράς](series_overlap.png)

## **Αλλαγή Χρώματος Γεμίσματος Σειράς**

Χρησιμοποιήστε [IChartSeries.getFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseries/#getFormat--) για να ορίσετε το προεπιλεγμένο γέμισμα για ολόκληρη τη σειρά. Εάν ένα σημείο έχει ήδη ρητό γέμισμα, η ρύθμιση του [IChartDataPoint.getFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatapoint/#getFormat--) παρακάμπτει το γέμισμα της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει γεμιστό συμπαγές μπλε στην πρώτη σειρά:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το χρώμα της σειράς](series_color.png)

## **Αλλαγή Ονόματος Σειράς**

Ένα όνομα σειράς αποθηκεύεται στο βιβλίο δεδομένων του διαγράμματος και συνήθως εμφανίζεται στο υπόμνημα. Στο προεπιλεγμένο βιβλίο που δημιουργείται για ένα διάγραμμα στοίβαξης στήλης, το κελί B1 βρίσκεται στη σειρά 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι ονομαστικές σταθερές στο παρακάτω παράδειγμα κάνουν αυτή τη δομή σαφή:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [IChartSeries.getName](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseries/#getName--). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης σειράς και στήλης σε ένα υπάρχον διάγραμμα:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το όνομα της σειράς](series_name.png)

## **Λήψη Αυτοματικού Χρώματος Γεμίσματος Σειράς**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) επιστρέφει το χρώμα που υπολογίζεται από το δείκτη της σειράς και το στυλ του διαγράμματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν αναθέτει νέο γέμισμα.

Το παρακάτω παράδειγμα εκτυπώνει το αυτόματο χρώμα κάθε προεπιλεγμένης σειράς:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Παράδειγμα εξόδου για το προεπιλεγμένο στυλ διαγράμματος:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Τα ακριβή χρώματα εξαρτώνται από το στυλ και το θέμα του διαγράμματος.

## **Ορισμός Αντιστροφής Χρώματος Γεμίσματος για Σειρά Διαγράμματος**

Για σειρές μπάρας, στήλης και φυσαλίδας, το [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα της σειράς σε συμπαγές, ενεργοποιήστε την αντιστροφή και ορίστε το χρώμα αρνητικής τιμής μέσω του [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Οι αρνητικές αριθμοί παραμένουν αμετάβλητοι στο βιβλίο δεδομένων· αλλάζει μόνο το χρώμα εμφάνισης.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με μία σειρά. Η σειρά 0 του φύλλου εργασίας περιέχει το όνομα της σειράς, η στήλη 0 περιέχει τα ονόματα των κατηγοριών, και η στήλη 1 περιέχει τις τιμές:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το ανεστραμμένο συμπαγές χρώμα γεμίσματος](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιημένη μόνο για το επιλεγμένο σημείο. Το σημείο έχει επίσης ανατεθεί μια αρνητική τιμή ώστε το αποτέλεσμα να είναι εμφανές:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Καθαρισμός Συγκεκριμένης Τιμής Σημείου Δεδομένων**

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το κελί του βιβλίου δεδομένων που το υποστηρίζει σε `null`. Για διάγραμμα στήλης, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [IChartDataPoint.getValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatapoint/#getValue--). Το σημείο δεδομένων παραμένει στην ίδια θέση κατηγορίας, αλλά το διάγραμμα το αντιμετωπίζει ως κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

Το παρακάτω παράδειγμα καθαρίζει μόνο το δεύτερο σημείο στην πρώτη σειρά:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Τα διαγράμματα διασποράς χρησιμοποιούν ξεχωριστά κελιά X και Y, και τα διαγράμματα φυσαλίδας χρησιμοποιούν επίσης κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [IChartDataPointCollection.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatapointcollection/#clear--) όταν θέλετε να διατηρήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί κάθε σημείο δεδομένων από τη συλλογή.

## **Έλεγχος Εμφάνισης Κελιών Κενών**

Ένα κενό κελί του βιβλίου δεδομένων αντιπροσωπεύει ελλιπή δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει γνωστή αριθμητική τιμή. Καλέστε το [IChartDataCell.setValue](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) με `null` για να κάνετε ένα κελί κενό. Ένας αριθμητικός μηδέν παραμένει μηδέν ανεξάρτητα από τη ρύθμιση κελιών κενών.

Χρησιμοποιήστε το [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) για να επιλέξετε πώς το διάγραμμα εμφανίζει κενά κελιά. Αυτή η ρύθμιση εφαρμόζεται σε όλο το διάγραμμα. Αλλάζει τον τρόπο που τα κενά σχεδιάζονται, χωρίς να γεμίζει το κενό κελί του βιβλίου με μηδέν ή με μια παρεμβατική τιμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με μία σειρά, καθαρίζει την τιμή για την Ημέρα 3, και αποθηκεύει το ίδιο διάγραμμα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [IChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/) χρησιμοποιεί το φύλλο εργασίας 0, στήλη 0 για ετικέτες κατηγοριών, και στήλη 1 για τιμές· η σειρά 0 περιέχει το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Αφήστε την Ημέρα 3 πραγματικά κενή, διατηρώντας την κατηγορία και το σημείο δεδομένων της.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που εκχωρήθηκε πριν από την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μια έκδοση, ορίστε την επιθυμητή λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί να επαναλαμβάνετε τις λειτουργίες.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο δεδομένων σε κάθε περίπτωση:

![Διαγράμματα γραμμής με ίδια δεδομένα: Gap κόβει τη γραμμή στην Ημέρα 3, Zero κατεβάζει τη γραμμή στο μηδέν, και Span συνδέει την Ημέρα 2 με την Ημέρα 4.](display_blanks_as.png)

Το ορατό αποτέλεσμα εξαρτάται από τον τύπο του διαγράμματος. Ένα διάγραμμα γραμμής καθιστά εύκολη τη σύγκριση των τριών λειτουργιών. Τα διαγράμματα μπάρας και στήλης δεν έχουν γραμμή για σύνδεση μέσω μιας ελλιπής κατηγορίας, έτσι το `Span` δεν μπορεί να δημιουργήσει το συνδετικό τμήμα που φαίνεται παραπάνω· μια ελλιπής στήλη και μια στήλη μηδενικού ύψους μπορεί επίσης να φαίνονται παρόμοια. Ομοίως, ένα διάγραμμα διασποράς μόνο με δείκτες δεν έχει γραμμή σύνδεσης. Μην περιμένετε τρία διαφορετικά αποτελέσματα για κάθε τύπο διαγράμματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Κενών Σειράς**

Το πλάτος κενών είναι το διάστημα μεταξύ γειτονικών ομάδων μπάρας ή στήλης, εκφρασμένο ως ποσοστό του πλάτους της μπάρας ή στήλης. Όπως και η επικάλυψη, ανήκει στην γονική ομάδα σειρών και όχι σε μία σειρά. Καλέστε το [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) μία φορά για την ομάδα. Μία μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μια μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος κενών και αποθηκεύει μόνο η τελική παρουσίαση:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το πλάτος κενών](gap_width.png)

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγραμμάτων που αντιστοιχούν στην απαρίθμηση [ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλα την ίδια δομή τιμών ή τις ίδιες ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διαγράμματα διασποράς χρησιμοποιούν τιμές X και Y, και τα διαγράμματα φυσαλίδας προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο σειράς. Επιλογές όπως η επικάλυψη και το πλάτος κενών ισχύουν μόνο για συμβατές ομάδες μπάρας ή στήλης.

**Τι είναι μια ομάδα σειρών διαγράμματος;**

Μια [IChartSeriesGroup](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις σχεδιασμού επιπέδου ομάδας. Ένα συνδυαστικό διάγραμμα μπορεί να περιέχει περισσότερες από μία ομάδες, έτσι η αλλαγή της ομάδας που προέρχεται από μια σειρά δεν αλλάζει απαραίτητα όλες τις σειρές στο διάγραμμα.

**Έχει ένα νεοδημιουργημένο διάγραμμα προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, το [IShapeCollection.addChart](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) δημιουργεί δείγμα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και κατηγοριών πριν προσθέσετε ένα εντελώς προσαρμοσμένο σύνολο δεδομένων. Μια υπερφόρτωση μπορεί επίσης να δημιουργήσει διάγραμμα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα διαγράμματος με τα κελιά του βιβλίου δεδομένων;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [IChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdataworkbook/). Η αλλαγή ενός αναφερόμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του διαγράμματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις σειρές κατηγοριών και τις σειρές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από την επιθυμητή κατηγορία.

**Πώς μπορώ να καθαρίσω ένα σημείο αντί ολόκληρης της σειράς;**

Ορίστε το σχετικό κελί τιμής σε `null` για να διατηρήσετε τη θέση κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [IChartDataPointCollection.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatapointcollection/#clear--) μόνο όταν σκοπεύετε να αφαιρέσετε όλα τα σημεία από εκείνη τη σειρά. Εάν αφαιρέσετε επίσης τις κατηγορίες, ενημερώστε όλες τις σειρές ώστε οι τιμές τους να παραμένουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο του διαγράμματος και την τιμή που έχει οριστεί μέσω του [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Τα υποστηριζόμενα διαγράμματα μπορούν να εμφανίζουν κενά ως διαστήματα, ως μηδενικές τιμές ή συνδέοντας γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει με το νόημα των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε το «Έλεγχος Εμφάνισης Κελιών Κενών» για ένα πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για τις υποστηριζόμενες σειρές μπάρας, στήλης και φυσαλίδας, καλέστε το [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) και ορίστε το χρώμα που επιστρέφεται από το [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα μεμονωμένο σημείο με το [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Αυτές οι μέθοδοι επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση προτεραιότητα όταν τόσο η σειρά όσο και το σημείο έχουν μορφοποιηθεί;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση της σειράς ή, εάν η μορφοποίηση της σειράς δεν ορίζεται, το αυτόματο στυλ και θέμα του διαγράμματος. Οι ρυθμίσεις ομάδας όπως η επικάλυψη και το πλάτος κενών ελέγχουν τη διάταξη και δεν αποτελούν παρακάμψεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα διάγραμμα;**

Το Aspose.Slides δεν θέτει ξεχωριστό περιορισμό στον αριθμό σειρών. Στην πράξη, οι περιορισμοί του αρχείου παρουσίασης, η διαθέσιμη μνήμη, ο χρόνος απόδοσης και η ευαναγνωσία του διαγράμματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά;**

Καλέστε το [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) στην κατάλληλη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το διάστημα μεταξύ των ομάδων, ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.