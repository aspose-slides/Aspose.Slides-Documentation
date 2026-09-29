---
title: Διαχείριση Σειρών Δεδομένων Γραφήματος σε Παρουσιάσεις στο Android
linktitle: Σειρές Δεδομένων
type: docs
url: /el/androidjava/chart-series/
keywords:
- σειρά γραφήματος
- επικάλυψη σειράς
- χρώμα σειράς
- όνομα σειράς
- σημείο δεδομένων
- κελί βιβλίου εργασίας
- διάστημα σειράς
- αρνητική τιμή
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σειρές γραφήματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος διαστήματος και αρνητικές τιμές σε παρουσιάσεις στο Android."
---
## **Επισκόπηση**

Ένα γράφημα αποθηκεύει τα δεδομένα του σε ένα βιβλίο εργασίας δεδομένων γραφήματος. Ένα [IChartSeries](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [IChartDataPoint](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapoint/) στη σειρά αναφέρεται σε ένα ή περισσότερα κελιά του βιβλίου εργασίας. Τα αντικείμενα [IChartCategory](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται από τις σειρές. Επομένως, το όνομα της σειράς, οι κατηγορίες και οι τιμές των σημείων συνδέονται με αντικείμενα [IChartDataCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/) αντί να αποθηκεύονται μόνο ως κείμενο εμφάνισης.

Για ένα τυπικό γράφημα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη σειρά 0 για ονόματα σειρών, τη στήλη 0 για ονόματα κατηγοριών και τα υπόλοιπα κελιά για τιμές σειρών. Οι δείκτες φύλλου, σειράς και στήλης που περνούν στο [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα γράφημα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον γράφημα τη χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά στα οποία αναφέρονται οι σειρές, οι κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις του γραφήματος έχουν τρεις διαφορετικές εμβέλειες:

- Ρυθμίσεις σε επίπεδο σειράς, όπως το [IChartSeries.getFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#getFormat--), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία σε μία σειρά.
- Ρυθμίσεις σε επίπεδο σημείου δεδομένου, όπως το [IChartDataPoint.getFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), παρακάμπουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στην ίδια [IChartSeriesGroup](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseriesgroup/). Πρόσβαση στην ομάδα μέσω του [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος διαστήματος.

Όταν δεν έχει οριστεί ρητά γέμισμα σημείου ή σειράς, το στυλ και το θέμα του γραφήματος καθορίζουν αυτόματα την εμφάνιση. Όταν υπάρχουν μορφοποιήσεις τόσο σειράς όσο και σημείου, η μορφοποίηση του σημείου έχει προτεραιότητα για εκείνο το σημείο.

![σειρά-γράφηματος-powerpoint](chart-series-powerpoint.png)

## **Ορισμός της Επικάλυψης Σειράς Γραφήματος**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#getOverlap--) αναφέρει πόσο πολύ τα ράβδια ή οι στήλες επικαλύπτονται σε ένα 2Δ γράφημα, από -100 έως 100 τοις εκατό. Είναι μια μόνο για ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειρών. Χρησιμοποιήστε το [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) για να ενημερώσετε κάθε συμβατή σειρά σε εκείνη την ομάδα. Αυτή η επιλογή εφαρμόζεται σε τύπους γραφημάτων που εμφανίζουν ομαδοποιημένα ράβδια ή στήλες· δεν επηρεάζει ανεξάρτητες ομάδες σειρών σε ένα σύνθετο γράφημα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Το νέο γράφημα περιέχει δείγμα σειρών, κατηγοριών και τιμών.
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

Χρησιμοποιήστε το [IChartSeries.getFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#getFormat--) για να ορίσετε το προεπιλεγμένο γέμισμα για ολόκληρη τη σειρά. Εάν ένα σημείο έχει ήδη ρητό γέμισμα, η ρύθμιση του [IChartDataPoint.getFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) παρακάμπτει το γέμισμα της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει ένα συμπαγές μπλε γέμισμα στην πρώτη σειρά:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων γραφήματος και συνήθως εμφανίζεται στο υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα γράφημα ομαδισμένων στηλών, το κελί B1 βρίσκεται στη σειρά 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι σταθερές ονομασίες στο παρακάτω παράδειγμα κάνουν αυτή τη δομή ρητή:

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

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [IChartSeries.getName](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#getName--). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης σειράς και στήλης σε ένα υπάρχον γράφημα:

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

## **Λήψη Αυτόματου Χρώματος Γεμίσματος Σειράς**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) επιστρέφει το χρώμα που υπολογίζεται από τον δείκτη σειράς και το στυλ του γραφήματος ως ακέραιο χρώμα Android ARGB. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν αναθέτει νέο γέμισμα.

Το παρακάτω παράδειγμα εκτυπώνει το αυτόματο ακέραιο χρώματος για κάθε προεπιλεγόμενη σειρά:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Οι ακριβείς ακέραιες τιμές εξαρτώνται από το στυλ και το θέμα του γραφήματος.

## **Ορισμός Αντιστροφής Γεμίσματος για Σειρά Γραφήματος**

Για σειρές ράβδων, στηλών και φυσαλίδων, το [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα σειράς σε συμπαγές, ενεργοποιήστε την αντιστροφή και ορίστε το χρώμα αρνητικής τιμής μέσω του [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· μόνο το χρώμα εμφάνισης αλλάζει.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα γραφήματος με μία σειρά. Η σειρά 0 του φύλλου περιέχει το όνομα της σειράς, η στήλη 0 περιέχει τα ονόματα κατηγοριών και η στήλη 1 τις τιμές:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

![Το αντιστροφεμένο συμπαγές χρώμα γεμίσματος](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Το σημείο του δίνεται επίσης αρνητική τιμή ώστε το εφέ να είναι ορατό:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το αντίστοιχο κελί του βιβλίου εργασίας σε `null`. Για ένα γράφημα στηλών, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [IChartDataPoint.getValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το γράφημα το θεωρεί κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του γραφήματος.

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

Τα γραφήματα διασποράς χρησιμοποιούν ξεχωριστά κελιά X και Y, και τα γραφήματα φυσαλίδων επίσης ένα κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει τη τιμή που θέλετε να αφαιρέσετε. Μην καλέτε το [IChartDataPointCollection.clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) όταν θέλετε να διατηρήσετε τα άλλα σημεία, διότι αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος Εμφάνισης Κελιών Κενών**

Τα κρυφά κελιά που περιέχουν τιμές αποτελούν ξεχωριστή περίπτωση από τα κενά κελιά. Για να συμπεριλάβετε ή να αποκλείσετε δεδομένα από κρυφές σειρές και στήλες φύλλου, δείτε το [Include Data from Hidden Rows and Columns](/slides/el/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί βιβλίου εργασίας αντιπροσωπεύει δεδομένα που λείπουν· ένα κελί με `0` αντιπροσωπεύει γνωστή αριθμητική τιμή. Καλέστε το [IChartDataCell.setValue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) με `null` για να κάνετε το κελί κενό. Ένας μηδενικός αριθμός παραμένει μηδενικός ανεξάρτητα από τη ρύθμιση κενών κελιών.

Χρησιμοποιήστε το [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) για να επιλέξετε πώς το γράφημα εμφανίζει τα κενά κελιά. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρο το γράφημα. Αλλάζει τον τρόπο που σχεδιάζονται τα κενά, χωρίς να γεμίζει το κενό κελί του βιβλίου εργασίας με μηδέν ή με παρεμβαλλόμενη τιμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γραμμικό γράφημα με μία σειρά, αφαιρεί την τιμή για την Ημέρα 3, και αποθηκεύει το ίδιο γράφημα με κάθε τρόπο. Δεν απαιτείται αρχείο εισόδου. Η [IChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/) χρησιμοποιεί το φύλλο 0, τη στήλη 0 για ετικέτες κατηγοριών και τη στήλη 1 για τιμές· η σειρά 0 κρατά το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

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

    // Αφήστε την Ημέρα 3 πραγματικά κενή, διατηρώντας την κατηγορία και το σημείο δεδομένων.
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

Κάθε αρχείο εξόδου αποθηκεύει τον τρόπο που ορίστηκε πριν την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για αποθήκευση μόνο μιας έκδοσης, ορίστε τον επιθυμητό τρόπο και αποθηκεύστε την παρουσίαση μία φορά αντί για επαναλήψεις των τρόπων.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Γραφήματα γραμμής με τα ίδια δεδομένα: Το Gap διακόπτει τη γραμμή στην Ημέρα 3, το Zero την κατεβάζει στο μηδέν, και το Span συνδέει τη Ημέρα 2 με τη Ημέρα 4.](display_blanks_as.png)

Το οπτικό αποτέλεσμα εξαρτάται από τον τύπο γραφήματος. Ένα γραμμικό γράφημα κάνει εύκολη τη σύγκριση και των τριών τρόπων. Τα ραβδόγραμμα και τα στήλες δεν έχουν γραμμή για σύνδεση μεταξύ μιας ελλιπής κατηγορίας, επομένως το `Span` δεν μπορεί να δημιουργήσει το τμήμα σύνδεσης που φαίνεται παραπάνω· μια στήλη που λείπει και μια στήλη μηδενικού ύψους μπορεί επίσης να φαίνονται όμοιες. Ανάλογα, ένα γράφημα διασποράς μόνο με δείκτες δεν έχει γραμμή σύνδεσης. Μην αναμένετε τρία διαφορετικά αποτελέσματα για κάθε τύπο γραφήματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Διαστήματος Σειράς**

Το πλάτος διαστήματος είναι το κενό μεταξύ γειτονικών ομάδων ράβδων ή στηλών, εκφρασμένο ως ποσοστό του πλάτους της ράβδου ή της στήλης. Όπως η επικάλυψη, ανήκει στην γονική ομάδα σειρών παρά σε μία σειρά. Καλέστε το [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) μια φορά για την ομάδα. Μια μεγαλύτερη τιμή δημιουργεί περισσότερο κενό μεταξύ των ομάδων· μια μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος διαστήματος και αποθηκεύει μόνο η τελική παρουσίαση:

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

![Το πλάτος διαστήματος](gap_width.png)

## **Συχνές Ερωτήσεις**

**Ποιους τύπους γραφημάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι γραφημάτων που αντιπροσωπεύονται από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/) χρησιμοποιούν δεδομένα γραφήματος, αλλά οι σειρές τους δεν έχουν πάντα την ίδια δομή τιμών ή ρυθμίσεις. Για παράδειγμα, τα γραφήματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διασποράς χρησιμοποιούν τιμές X και Y, και τα φυσαλίδων προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείων που ταιριάζει με τον τύπο σειράς. Επιλογές όπως η επικάλυψη και το πλάτος διαστήματος ισχύουν μόνο για συμβατές ομάδες ράβδων ή στηλών.

**Τι είναι μια ομάδα σειρών γραφήματος;**

Μια [IChartSeriesGroup](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις σχεδίασης επιπέδου ομάδας. Ένα σύνθετο γράφημα μπορεί να περιέχει περισσότερες από μία ομάδες, επομένως η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει απαραίτητα κάθε σειρά στο γράφημα.

**Ένα νεοδημιουργημένο γράφημα περιέχει προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, η [IShapeCollection.addChart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) δημιουργεί δείγμα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και κατηγοριών πριν προσθέσετε ένα εντελώς προσαρμοσμένο σύνολο δεδομένων. Μια υπερφόρτωση μπορεί επίσης να δημιουργήσει ένα γράφημα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα γραφήματος με τα κελιά του βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά σε μια [IChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/). Η αλλαγή ενός κελιού που αναφέρεται ενημερώνει το αντίστοιχο στοιχείο του γραφήματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, κρατήστε τις σειρές κατηγοριών και τις σειρές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από την επιθυμητή κατηγορία.

**Πώς να καθαρίσω ένα σημείο αντί ολόκληρης σειράς;**

Ορίστε το σχετικό κελί τιμής σε `null` ώστε να διατηρηθεί η θέση της κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [IChartDataPointCollection.clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) μόνο όταν σκοπεύετε να αφαιρέσετε όλα τα σημεία από αυτή τη σειρά. Εάν αφαιρείτε επίσης κατηγορίες, ενημερώστε κάθε σειρά ώστε οι τιμές τους να παραμένουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο γραφήματος και την τιμή που έχει ρυθμιστεί μέσω του [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Τα υποστηριζόμενα γραφήματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει με το νόημα των λειψανόντων δεδομένων στην παρουσίασή σας. Δείτε το **Control the Display of Empty Cells** για πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για τις υποστηριζόμενες σειρές ράβδων, στηλών και φυσαλίδων, καλέστε το [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) και ορίστε το χρώμα που επιστρέφει το [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα μεμονωμένο σημείο με το [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Αυτές οι μέθοδοι επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση κερδίζει όταν τόσο η σειρά όσο και το σημείο έχουν μορφοποιηθεί;**

Η ρητή μορφοποίηση σημείου έχει προτεραιότητα για εκείνο το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση σειράς ή, όταν η μορφοποίηση σειράς δεν ορίζεται, το αυτόματο στυλ και θέμα του γραφήματος. Οι ρυθμίσεις ομάδας όπως η επικάλυψη και το πλάτος διαστήματος ελέγχουν τη διάταξη και δεν είναι παρακάμψεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα γράφημα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, περιορισμοί του αρχείου παρουσίασης, διαθέσιμη μνήμη, χρόνος απόδοσης και αναγνωσιμότητα του γραφήματος καθορίζουν ένα χρήσιμο όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά;**

Καλέστε το [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) στη σχετική γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το κενό μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά η μία στην άλλη.