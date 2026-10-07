---
title: Διαχείριση Σειρών Δεδομένων Διαγράμματος σε Παρουσιάσεις Android
linktitle: Σειρές Δεδομένων
type: docs
url: /el/androidjava/chart-series/
keywords:
- σειρές διαγράμματος
- επικάλυψη σειρών
- χρώμα σειράς
- όνομα σειράς
- σημείο δεδομένων
- κελί φύλλου εργασίας
- διάστημα σειράς
- αρνητική τιμή
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σειρές διαγράμματος, σημεία δεδομένων, κελιά φύλλου εργασίας, μορφοποίηση, επικάλυψη, πλάτος διαστήματος και αρνητικές τιμές σε παρουσιάσεις σε Android."
---
## **Επισκόπηση**

Ένα διάγραμμα αποθηκεύει τα σχεδιασμένα δεδομένα του σε ένα φύλλο δεδομένων διαγράμματος. Ένα [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) στη σειρά αναφέρεται σε ένα ή περισσότερα κελιά του φύλλου εργασίας. Τα αντικείμενα [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομάδων που μοιράζονται από τις σειρές. Το όνομα της σειράς, οι κατηγορίες και οι τιμές των σημείων είναι έτσι συνδεδεμένα με αντικείμενα [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) αντί να αποθηκεύονται μόνο ως κείμενο εμφάνισης.

Για ένα τυπικό διάγραμμα κατηγορίας, το προεπιλεγμένο φύλλο εργασίας χρησιμοποιεί τη γραμμή 0 για ονόματα σειρών, τη στήλη 0 για ονόματα κατηγοριών και τα υπόλοιπα κελιά για τιμές σειρών. Οι δείκτες φύλλου εργασίας, γραμμής και στήλης που περνούν στο [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα διάγραμμα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον διάγραμμα το χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, εξετάστε τα κελιά που αναφέρονται από τις σειρές, τις κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του φύλλου εργασίας.

Οι ρυθμίσεις διαγράμματος έχουν τρία διαφορετικά επίπεδα:

- Ρυθμίσεις σε επίπεδο σειράς, όπως το [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία σε μία σειρά.
- Ρυθμίσεις σημείου δεδομένων, όπως το [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στην ίδια [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/). Πρόσβαση στην ομάδα μέσω του [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος διαστήματος.

Όταν δεν ορίζεται ρητή γέμιση σημείου ή σειράς, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχει τόσο μορφοποίηση σειράς όσο και σημείου, η μορφοποίηση του σημείου έχει προτεραιότητα για εκείνο το σημείο.

![διάγραμμα-σειράς-powerpoint](chart-series-powerpoint.png)

## **Ορισμός Επικάλυψης Σειρών Διαγράμματος**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) αναφέρει πόσο επικαλύπτονται ράβδοι ή στήλες σε διάγραμμα 2 Δ, από -100 μέχρι 100 % . Είναι μια μόνο για ανάγνωση προβολή της ρύθμισης στην γονική ομάδα σειρών. Χρησιμοποιήστε [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) για ενημέρωση κάθε συμβατής σειράς σε αυτή την ομάδα. Αυτή η επιλογή εφαρμόζεται σε τύπους διαγραμμάτων που εμφανίζουν ομαδοποιημένους ράβδους ή στήλες· δεν επηρεάζει μη σχετικές ομάδες σειρών σε συνδυαστικό διάγραμμα.

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

![Η επικάλυψη των σειρών](series_overlap.png)

## **Αλλαγή Χρώματος Γέμισμα Σειράς**

Χρησιμοποιήστε [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) για να ορίσετε τη προεπιλεγμένη γέμιση ολόκληρης μιας σειράς. Εάν ένα σημείο έχει ήδη ρητή γέμιση, η ρύθμιση του [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) παρακάμπτει τη γέμιση της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει συμπαγές μπλε γέμισμα στην πρώτη σειρά:

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

Ένα όνομα σειράς αποθηκεύεται στο φύλλο δεδομένων διαγράμματος και συνήθως εμφανίζεται στο υπόμνημα. Στο προεπιλεγμένο φύλλο που δημιουργείται για ένα ομαδοποιημένο διάγραμμα στήλης, το κελί B1 βρίσκεται στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι ονομαστικές σταθερές στο παρακάτω παράδειγμα κάνουν αυτή τη δομή σαφή:

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

Μπορείτε επίσης να ενημερώσετε το κελί το οποίο ήδη αναφέρεται από το [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής και στήλης σε υπάρχον διάγραμμα:

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

### **Δημιουργία Σειράς με Όνομα από Πολλαπλά Κελιά**

Ένα σύνθετο όνομα σειράς είναι χρήσιμο όταν το όνομα προϊόντος και η περίοδος αναφοράς αποθηκεύονται σε ξεχωριστά κελιά του φύλλου. Για παράδειγμα, μπορείτε να συνδυάσετε το `Product A` στο B1 και το `2026` στο C1 σε ένα ενιαίο όνομα σειράς ενώ διατηρείτε και τα δύο τμήματα συνδεδεμένα με τα πηγαία κελιά τους.

Χρησιμοποιήστε το [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) για να ανακτήσετε την περιοχή ονομάτων, μετά περάστε αυτή τη συλλογή στο [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Το όρισμα `skipHiddenCells` ελέγχει εάν θα συμπεριληφθούν κρυφά κελιά: `true` τα εξαιρεί, ενώ `false` τα συμπεριλαμβάνει. Το παράδειγμα αυτό χρησιμοποιεί `false` για να συμπεριλάβει κάθε κελί στην περιοχή ονομάτων.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με μια σειρά και δύο σημεία δεδομένων. Τα κελιά B1:C1 παρέχουν μόνο το όνομα της σειράς· τα A2:A3 παρέχουν τις ετικέτες κατηγοριών, και τα B2:B3 παρέχουν τις αριθμητικές τιμές.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Αυτά τα δύο κελιά παρέχουν το όνομα της σειράς.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Ξεχωριστά κελιά παρέχουν τις κατηγορίες και τις αριθμητικές τιμές δεδομένων.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το προκύπτον όνομα σειράς είναι `Product A 2026`, με ένα κενό μεταξύ των δύο τιμών κελιών. Το υπόμνημα το εμφανίζει ως μία είσοδο για και τις δύο στήλες. Η εικόνα παρακάτω απεικονίζει το αποτέλεσμα:

![Διάγραμμα στήλης με τιμές Βορρά και Νότου και το σύνθετο όνομα σειράς Product A 2026 στο υπόμνημα](composite_series_name.png)

## **Λήψη Αυτόματου Χρώματος Γέμισμα Σειράς**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) επιστρέφει το χρώμα που υπολογίζεται από το ευρετήριο της σειράς και το στυλ του διαγράμματος ως ακέραιο Android ARGB. Αυτό είναι το χρώμα που χρησιμοποιείται όταν η γέμιση της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν εκχωρεί νέα γέμιση.

Το παρακάτω παράδειγμα εκτυπώνει το ακέραιο αυτόματου χρώματος για κάθε προεπιλεγμένη σειρά:

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

Οι ακριβείς ακέραιες τιμές εξαρτώνται από το στυλ και το θέμα του διαγράμματος.

## **Ορισμός Αντίστροφης Γέμισμα Χρώματος για Σειρά Διαγράμματος**

Για σειρές ράβδου, στήλης και φυσαλίδων, το [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) μπορεί να εμφανίσει αρνητικές τιμές με διαφορετική γέμιση. Ορίστε τη συνηθισμένη γέμιση της σειράς σε συμπαγές, ενεργοποιήστε την αντιστροφή και αναθέστε το χρώμα αρνητικής τιμής μέσω του [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο φύλλο εργασίας· αλλάζει μόνο το χρώμα εμφάνισης.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με μία σειρά. Η γραμμή 0 του φύλλου περιέχει το όνομα της σειράς, η στήλη 0 τις ετικέτες κατηγοριών και η στήλη 1 τις τιμές:

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

![Το αντίστροφο συμπαγές χρώμα γέμισμα](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Στο παρακάτω παράδειγμα η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιημένη μόνο για το επιλεγμένο σημείο. Το σημείο έχει επίσης εκχωρηθεί σε αρνητική τιμή ώστε το αποτέλεσμα να είναι εμφανές:

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

## **Καθαρισμός Συγκεκριμένης Τιμής Στιγμής Δεδομένων**

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το κελί υποστήριξης στο φύλλο εργασίας σε `null`. Για διάγραμμα στήλης, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το διάγραμμα θεωρεί την τιμή του κενή σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

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

Τα διαγράμματα scatter χρησιμοποιούν χωριστά κελιά X και Y, και τα bubble charts επίσης χρησιμοποιούν κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) όταν θέλετε να διατηρήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί κάθε σημείο δεδομένων από τη συλλογή.

## **Έλεγχος Εμφάνισης Κενών Κελιών**

Τα κρυφά κελιά που περιέχουν τιμές είναι ξεχωριστή περίπτωση από τα κενά κελιά. Για να συμπεριλάβετε ή να εξαιρέσετε δεδομένα από κρυφές γραμμές και στήλες φύλλου εργασίας, δείτε το [Include Data from Hidden Rows and Columns](/slides/el/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί φύλλου εργασίας αντιπροσωπεύει ελλιπή δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει μια γνωστή αριθμητική τιμή. Καλέστε το [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) με `null` για να κάνετε ένα κελί κενό. Ένα αριθμητικό μηδέν παραμένει μηδέν ανεξαρτήτως της ρύθμισης κενών κελιών.

Χρησιμοποιήστε το [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) για να επιλέξετε πώς το διάγραμμα εμφανίζει κενά κελιά. Αυτή η ρύθμιση εφαρμόζεται σε όλο το διάγραμμα. Αλλάζει το πώς τα κενά σχεδιάζονται, χωρίς να γεμίζει το κενό κελί με μηδέν ή με παρεμβατική τιμή.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με μία σειρά, καθαρίζει την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο διάγραμμα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) χρησιμοποιεί φύλλο 0, στήλη 0 για ετικέτες κατηγοριών και στήλη 1 για τιμές· η γραμμή 0 περιέχει το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

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

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που είχε οριστεί πριν την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε την επιθυμητή λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί να κάνετε επαναλήψεις πάνω στις λειτουργίες.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο φύλλο εργασίας σε κάθε περίπτωση:

![Διαγράμματα γραμμής με πανομοιότυπα δεδομένα: το Gap διακόπτει τη γραμμή στην Ημέρα 3, το Zero μειώνει τη γραμμή στο μηδέν, και το Span συνδέει την Ημέρα 2 με την Ημέρα 4.](display_blanks_as.png)

Το ορατό αποτέλεσμα εξαρτάται από τον τύπο του διαγράμματος. Ένα διάγραμμα γραμμής καθιστά εύκολη τη σύγκριση και των τριών λειτουργιών. Τα διαγράμματα ράβδου και στήλης δεν έχουν γραμμή για σύνδεση μέσω μιας ελλιπούς κατηγορίας, επομένως το `Span` δεν μπορεί να δημιουργήσει το συνδετικό τμήμα που φαίνεται παραπάνω· μια ελλιπής στήλη και μια στήλη μηδενικού ύψους μπορεί επίσης να φαίνονται όμοιες. Παρομοίως, ένα διάγραμμα scatter μόνο με δείκτες δεν έχει γραμμή σύνδεσης. Μην περιμένετε τρία διαφορετικά αποτελέσματα για κάθε τύπο διαγράμματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Διαστήματος Σειράς**

Το πλάτος διαστήματος είναι το κενό μεταξύ γειτονικών ομάδων ράβδων ή στηλών, εκφρασμένο ως ποσοστό του πλάτους της ράβδου ή της στήλης. Όπως η επικάλυψη, ανήκει στην γονική ομάδα σειρών και όχι σε μία σειρά. Καλέστε το [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) μία φορά για την ομάδα. Μία μεγαλύτερη τιμή δημιουργεί περισσότερο κενό μεταξύ των ομάδων· μία μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος διαστήματος και αποθηκεύει μόνο την τελική παρουσίαση:

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

**Ποιους τύπους διαγράμματος υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγράμματος που αντιπροσωπεύονται από την κλήση [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλοι την ίδια δομή τιμών ή τις ίδιες ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα scatter charts χρησιμοποιούν τιμές X και Y, και τα bubble charts προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει στον τύπο της σειράς. Επιλογές όπως η επικάλυψη και το πλάτος διαστήματος ισχύουν μόνο σε συμβατές ομάδες ράβδων ή στηλών.

**Τι είναι μια ομάδα σειρών διαγράμματος;**

Μια [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις επιπέδου ομάδας. Ένα συνδυαστικό διάγραμμα μπορεί να περιέχει περισσότερες από μία ομάδες, επομένως η αλλαγή της ομάδας που προέρχεται από μια σειρά δεν αλλάζει υποχρεωτικά όλες τις σειρές στο διάγραμμα.

**Δημιουργεί ένα νέο διάγραμμα προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, το [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) δημιουργεί δείγμα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και κατηγοριών πριν προσθέσετε ένα εντελώς προσαρμοσμένο σύνολο δεδομένων. Υπάρχει επίσης υπερφόρτωση που μπορεί να δημιουργήσει διάγραμμα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα διαγράμματος με κελιά του φύλλου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/). Η αλλαγή ενός αναφερόμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του διαγράμματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, κρατήστε τις γραμμές κατηγοριών και τις γραμμές τιμών σειρών συντονισμένες, ώστε κάθε σημείο να σχεδιάζεται κάτω από την επιθυμητή κατηγορία.

**Πώς καθαρίζω ένα σημείο αντί ολόκληρης της σειράς;**

Ορίστε το σχετικό κελί τιμής σε `null` ώστε να διατηρήσετε τη θέση κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) μόνο όταν θέλετε να αφαιρέσετε όλα τα σημεία από αυτή τη σειρά. Εάν αφαιρείτε επίσης κατηγορίες, ενημερώστε κάθε σειρά ώστε οι τιμές τους να παραμείνουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο του διαγράμματος και την τιμή που έχετε ορίσει μέσω του [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Τα υποστηριζόμενα διαγράμματα μπορούν να εμφανίζουν κενά ως κενά μεταξύ (Gap), ως μηδενικές τιμές (Zero) ή συνδέοντας τα γειτονικά σημεία (Span). Επιλέξτε τη ρύθμιση που ταιριάζει στο νόημα των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε το [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για ένα πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για υποστηριζόμενες σειρές ράβδου, στήλης και φυσαλίδας, καλέστε το [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) και ορίστε το χρώμα που επιστρέφεται από το [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα επιμέρους σημείο με το [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Αυτές οι μέθοδοι επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση επικρατεί όταν τόσο μια σειρά όσο και ένα σημείο είναι μορφοποιημένα;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα υπόλοιπα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση σειράς ή, όταν η μορφοποίηση της σειράς δεν είναι ορισμένη, το αυτόματο στυλ και θέμα του διαγράμματος. Οι ρυθμίσεις ομάδας όπως η επικάλυψη και το πλάτος διαστήματος ελέγχουν τη διάταξη και δεν είναι παρακάμψεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα διάγραμμα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, οι περιορισμοί του αρχείου παρουσίασης, η διαθέσιμη μνήμη, ο χρόνος απόδοσης και η αναγνωσιμότητα του διαγράμματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά;**

Καλέστε το [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) στην κατάλληλη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το κενό μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά μεταξύ τους.