---
title: Διαχείριση σειρών δεδομένων γραφήματος σε παρουσιάσεις με Java
linktitle: Σειρές Δεδομένων
type: docs
url: /el/java/chart-series/
keywords:
- σειρές γραφήματος
- επικάλυψη σειρών
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
description: "Μάθετε πώς να διαχειρίζεστε σειρές γραφήματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος κενών και αρνητικές τιμές σε παρουσιάσεις με Java."
---
## **Επισκόπηση**

Ένα γράφημα μπορεί να αποθηκεύει τις σχεδιασμένες του τιμές σε κελιά βιβλίου εργασίας ή απευθείας ως αριθμητικά κυριολεκτικά. Ένα [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) αντιπροσωπεύει ένα σημείο σε αυτή τη σειρά. Τα αντικείμενα [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται από τις σειρές. Σε διαγράμματα που δημιουργούνται με προεπιλεγμένα δεδομένα, τα ονόματα σειρών, οι κατηγορίες και οι τιμές σημείων χρησιμοποιούν αντικείμενα [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) από το βιβλίο εργασίας του διαγράμματος.

Για ένα τυπικό διάγραμμα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη σειρά 0 για τα ονόματα σειρών, τη στήλη 0 για τα ονόματα κατηγοριών και τα υπόλοιπα κελιά για τις τιμές των σειρών. Οι δείκτες φύλλου εργασίας, σειράς και στήλης που περνιούνται στο [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα γράφημα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον γράφημα το χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά στα οποία παραπέμπουν οι σειρές, οι κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις του διαγράμματος έχουν τρία διαφορετικά πεδία:

- Ρυθμίσεις σε επίπεδο σειράς, όπως [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία σε μία σειρά.
- Ρυθμίσεις σημείου δεδομένων, όπως [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--), παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στην ίδια [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/). Πρόσβαση στην ομάδα μέσω [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος κενών.

Όταν δεν έχει οριστεί ρητή γεμιστική τιμή για σημείο ή σειρά, το στυλ και το θέμα του διαγράμματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο μορφοποιήσεις σειράς όσο και σημείου, η μορφοποίηση του σημείου έχει προτεραιότητα για εκείνο το σημείο.

![Διάγραμμα σειράς PowerPoint](chart-series-powerpoint.png)

## **Ορισμός τιμών σειράς χρησιμοποιώντας αριθμητικά κυριολεκτικά**

Χρησιμοποιήστε αριθμητικά κυριολεκτικά όταν οι τιμές της σειράς προέρχονται από δεδομένα ή υπολογισμούς της εφαρμογής και δεν χρειάζονται αναφορές σε κελιά φύλλου εργασίας. Καλέστε [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) με [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) πριν αναθέσετε το αποτέλεσμα της μεθόδου [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) κάθε σημείου μέσω του [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

Η ρύθμιση της συλλογής ελέγχει τον τύπο προέλευσης όλων των τιμών σημείων σε αυτή τη σειρά. Η μέθοδος [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) κάθε τιμής σημείου αναφέρει τον επιλεγμένο τύπο· αλλάξτε τον μέσω της ρύθμισης της συλλογής. Με `Worksheet`, χρησιμοποιήστε το [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) για να αποκτήσετε πρόσβαση στο αναφερόμενο κελί. Με `DoubleLiterals`, χρησιμοποιήστε το [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) ή `setAsLiteralDouble` για να διαβάσετε ή να γράψετε άμεσα τον αριθμό.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα στηλών με προεπιλεγμένες σειρές και κατηγορίες, στη συνέχεια αναθέτει υπολογιζόμενες τιμές 10, 20 κ.λπ. στα υπάρχοντα σημεία της πρώτης του σειράς. Αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει τις αποθηκευμένες τιμές.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Ο τύπος προέλευσης της τιμής του σημείου είναι ξεχωριστός από το [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--), το οποίο καθορίζει την εσωτερική ή εξωτερική διαμόρφωση του βιβλίου εργασίας του διαγράμματος. Η χρήση αριθμητικών κυριολεκτικών δεν αφαιρεί, από μόνη της, το ενσωματωμένο βιβλίο εργασίας. Σε αυτό το παράδειγμα, το βιβλίο εργασίας παραμένει διαθέσιμο για τις ετικέτες κατηγοριών, τα ονόματα σειρών και τις άλλες σειρές. Δείτε το [Chart Workbook](/slides/el/java/chart-workbook/) για διαχείριση βιβλίου εργασίας.

Για διαγράμματα διασποράς και φυσαλίδων, χρησιμοποιήστε [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) και [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) για να επιλέξετε τις προελεύσεις των [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) και [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--). Τα γράφημα φυσαλίδων χρησιμοποιούν επίσης το [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) για το [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Ορίστε κάθε εφαρμοστέα προέλευση σε `DoubleLiterals` πριν αναθέσετε αριθμούς μέσω της μεθόδου `setAsLiteralDouble` της αντίστοιχης τιμής.

## **Ορισμός επικάλυψης σειρών γραφήματος**

Το [IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) αναφέρει πόσο οι μπάρες ή στήλες επικαλύπτονται σε 2Δ διάγραμμα, από -100 έως 100 τοις εκατό. Είναι μια μόνο ανάγνωση προβολής της ρύθμισης στην γονική ομάδα σειρών. Χρησιμοποιήστε το [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) για να ενημερώσετε κάθε συμβατή σειρά στην ομάδα. Αυτή η επιλογή εφαρμόζεται σε τύπους διαγραμμάτων που εμφανίζουν ομαδοποιημένες μπάρες ή στήλες· δεν επηρεάζει ανεξάρτητες ομάδες σειρών σε ένα συνδυαστικό γράφημα.

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

![Η επικάλυψη των σειρών](series_overlap.png)

## **Αλλαγή χρώματος γεμίσματος σειράς**

Χρησιμοποιήστε το [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) για να ορίσετε το προεπιλεγμένο γέμισμα ολόκληρης σειράς. Εάν ένα σημείο έχει ήδη ρητή γεμιστική τιμή, η ρύθμιση του [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) παρακάμπτει το γέμισμα της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει ένα συμπαγές μπλε γέμισμα στην πρώτη σειρά:

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

![Το χρώμα των σειρών](series_color.png)

## **Αλλαγή ονόματος σειράς**

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων του γραφήματος και συνήθως εμφανίζεται στο υπόμνημα. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα γράφημα ομαδοποιημένων στηλών, το κελί B1 βρίσκεται στη σειρά 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι σταθερές ονόματος στο παρακάτω παράδειγμα κάνουν αυτή τη δομή ρητή:

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

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη παραπέμπεται από το [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης σειράς και στήλης σε υπάρχον γράφημα:

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

### **Δημιουργία σειράς με όνομα από πολλαπλά κελιά**

Ένα σύνθετο όνομα σειράς είναι χρήσιμο όταν το όνομα προϊόντος και η περίοδος αναφοράς αποθηκεύονται σε ξεχωριστά κελιά του βιβλίου εργασίας. Για παράδειγμα, μπορείτε να συνδυάσετε το `Product A` στο B1 και το `2026` στο C1 σε ένα ενιαίο όνομα σειράς, διατηρώντας και τα δύο μέρη συνδεδεμένα με τα κελιά προέλευσής τους.

Χρησιμοποιήστε το [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) για να ανακτήσετε την περιοχή ονομάτων, έπειτα περάστε αυτή τη συλλογή στο [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Το όρισμα `skipHiddenCells` ελέγχει αν θα συμπεριληφθούν κρυμμένα κελιά: `true` τα εξαιρεί, ενώ `false` τα συμπεριλαμβάνει. Αυτό το παράδειγμα χρησιμοποιεί `false` για να συμπεριλάβει όλα τα κελιά στην περιοχή ονομάτων.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με μία σειρά και δύο σημεία δεδομένων. Τα κελιά B1:C1 παρέχουν μόνο το όνομα της σειράς· A2:A3 παρέχουν τις ετικέτες κατηγοριών, και B2:B3 παρέχουν τις αριθμητικές τιμές.

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

    // Χώριστα κελιά παρέχουν τις κατηγορίες και τα αριθμητικά σημεία δεδομένων.
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

Το προκύπτον όνομα σειράς είναι `Product A 2026`, με κενό μεταξύ των δύο τιμών κελιών. Το υπόμνημα το εμφανίζει ως μία καταχώρηση για τις δύο στήλες. Η εικόνα παρακάτω απεικονίζει το αποτέλεσμα:

![Γράφημα στηλών με τιμές Βορρά και Νότου και το σύνθετο όνομα σειράς Product A 2026 στο υπόμνημα](composite_series_name.png)

## **Ανάκτηση αυτόματου χρώματος γεμίσματος σειράς**

Το [IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) επιστρέφει το χρώμα που υπολογίζεται από το δείκτη σειράς και το στυλ του διαγράμματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν ορίζει νέο γέμισμα.

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

## **Ορισμός αναστροφής χρώματος γέμισματος για σειρά γραφήματος**

Για σειρές μπάρες, στήλες και φυσαλίδες, το [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα της σειράς σε συμπαγές, ενεργοποιήστε την αναστροφή και αναθέστε το χρώμα αρνητικής τιμής μέσω του [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· μόνο το χρώμα εμφάνισής τους αλλάζει.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα γραφήματος με μία σειρά. Η σειρά 0 του φύλλου εργασίας περιέχει το όνομα της σειράς, η στήλη 0 περιέχει ονόματα κατηγοριών και η στήλη 1 περιέχει τις τιμές:

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

![Το αναστροφή του συμπαγούς χρώματος γέμισματος](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αναστροφή για ένα σημείο μέσω του [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Στο παρακάτω παράδειγμα, η αναστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Το σημείο ανατίθεται επίσης με αρνητική τιμή ώστε το εφέ να είναι ορατό:

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

## **Καθαρισμός συγκεκριμένης τιμής σημείου δεδομένων**

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα, ορίστε το αντίστοιχο κελί του βιβλίου εργασίας σε `null`. Για ένα γράφημα στηλών, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το γράφημα το θεωρεί κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του διαγράμματος.

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

Τα διαγράμματα διασποράς χρησιμοποιούν ξεχωριστά κελιά X και Y, και τα διαγράμματα φυσαλίδων χρησιμοποιούν επίσης κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) όταν θέλετε να διατηρήσετε τα άλλα σημεία· αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος εμφάνισης κενών κελιών**

Τα κρυμμένα κελιά που περιέχουν τιμές αποτελούν ξεχωριστή περίπτωση από τα κενά κελιά. Για να συμπεριλάβετε ή να εξαιρέσετε δεδομένα από κρυμμένες σειρές και στήλες φύλλου εργασίας, δείτε το [Include Data from Hidden Rows and Columns](/slides/el/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί βιβλίου εργασίας αντιπροσωπεύει ελλιπή δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει γνωστή αριθμητική τιμή. Καλέστε το [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) με `null` για να κάνετε ένα κελί κενό. Ένας αριθμητικός μηδενισμός παραμένει μηδέν ανεξαρτήτων των ρυθμίσεων κενών κελιών.

Χρησιμοποιήστε το [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) για να επιλέξετε πώς το γράφημα εμφανίζει κενά κελιά. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρο το γράφημα. Αλλάζει τον τρόπο που τα κενά σχεδιάζονται, χωρίς να γεμίζει το κενό κελί του βιβλίου εργασίας με μηδέν ή με τιμή παρεμβολής.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα γράφημα γραμμής με μία σειρά, καθαρίζει την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο γράφημα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) χρησιμοποιεί το φύλλο εργασίας 0, στήλη 0 για ετικέτες κατηγοριών και στήλη 1 για τιμές· η σειρά 0 περιέχει το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

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

    // Να αφήσετε την Ημέρα 3 πραγματικά κενή, διατηρώντας την κατηγορία και το σημείο δεδομένων της.
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

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που είχε οριστεί πριν την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε τη ζητούμενη λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί για επαναλήψεις.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Γράφημα γραμμής με ταυτόσες δεδομένα: Gap διακόπτει τη γραμμή στην Ημέρα 3, Zero μειώνει τη γραμμή στο μηδέν, και Span συνδέει την Ημέρα 2 με την Ημέρα 4.](display_blanks_as.png)

Το οπτικό αποτέλεσμα εξαρτάται από τον τύπο του διαγράμματος. Ένα γράφημα γραμμής κάνει εύκολη τη σύγκριση των τριών λειτουργιών. Τα γράφημα μπάρες και στήλες δεν έχουν γραμμή για σύνδεση σε ελλιπή κατηγορία, επομένως το `Span` δεν μπορεί να παράγει το συνδετικό τμήμα όπως παραπάνω· μια κενή στήλη και μια στήλη μηδενικού ύψους μπορεί επίσης να φαίνονται όμοια. Παρόμοια, ένα γράφημα διασποράς μόνο με δείκτες δεν έχει σύνδεση γραμμής. Μην αναμένετε τρία διαφορετικά αποτελέσματα για κάθε τύπο διαγράμματος· ελέγξτε το αποτέλεσμα για τον τύπο που χρησιμοποιείτε.

## **Ορισμός πλάτους κενών μεταξύ σειρών**

Το πλάτος κενών είναι το διάστημα μεταξύ διαδοχικών ομάδων μπάρες ή στηλών, εκφρασμένο ως ποσοστό του πλάτους της μπάρας ή της στήλης. Όπως η επικάλυψη, ανήκει στην γονική ομάδα σειρών παρά σε μία σειρά. Καλέστε το [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) μία φορά για την ομάδα. Μία μεγαλύτερη τιμή δημιουργεί περισσότερο κενό μεταξύ των ομάδων· μια μικρότερη τιμή τα κάνει πιο πυκνά.

Το παρακάτω παράδειγμα αλλάζει το πλάτος κενών και αποθηκεύει μόνο την τελική παρουσίαση:

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

## **Συχνές ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι διαγραμμάτων που εκπροσωπεί η απαίτηση [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) χρησιμοποιούν δεδομένα διαγράμματος, αλλά οι σειρές τους δεν έχουν όλοι την ίδια δομή τιμών ή ρυθμίσεις. Για παράδειγμα, τα διαγράμματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διαγράμματα διασποράς χρησιμοποιούν τιμές X και Y, και τα διαγράμματα φυσαλίδων προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο σειράς. Επιλογές όπως η επικάλυψη και το πλάτος κενών εφαρμόζονται μόνο σε συμβατές ομάδες μπάρες ή στηλών.

**Τι είναι μια ομάδα σειρών γραφήματος;**

Μια [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις κατεργασίας επιπέδου ομάδας. Ένα συνδυαστικό γράφημα μπορεί να περιέχει περισσότερες από μία ομάδες, επομένως η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει υποχρεωτικά όλες τις σειρές στο γράφημα.

**Μήπως ένα νεοδημιουργημένο γράφημα περιέχει προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, το [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) δημιουργεί δείγμα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να τα καθαρίσετε πριν προσθέσετε ένα πλήρως προσαρμοσμένο σύνολο δεδομένων. Υπάρχει επίσης υπερφόρτωση που μπορεί να δημιουργήσει γράφημα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα γραφήματος με κελιά βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων παραπέμπουν σε κελιά ενός [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/). Η αλλαγή ενός αναφερόμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του γραφήματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις σειρές κατηγοριών και τις σειρές τιμών σειρών ευθυγραμμισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από την προαναγόμενη κατηγορία.

**Πώς μπορώ να καθαρίσω ένα σημείο αντί ολόκληρης σειράς;**

Ορίστε το σχετικό κελί τιμής σε `null` για να διατηρήσετε τη θέση της κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) μόνο όταν θέλετε να αφαιρέσετε όλα τα σημεία από εκείνη τη σειρά. Εάν αφαιρέσετε επίσης κατηγορίες, ενημερώστε όλες τις σειρές ώστε οι τιμές τους να παραμείνουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο του γραφήματος και την τιμή που έχει οριστεί μέσω του [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Τα υποστηριζόμενα γραφήματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει στην έννοια των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε το [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για υποστηριζόμενες σειρές μπάρες, στήλες και φυσαλίδες, καλέστε το [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) και ορίστε το χρώμα που επιστρέφει το [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα μεμονωμένο σημείο με το [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Αυτές οι μέθοδοι επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση υπερισχύει όταν μια σειρά και ένα σημείο είναι μορφοποιημένα;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση της σειράς ή, όταν η μορφοποίηση της σειράς δεν ορίζεται, το αυτόματο στυλ και θέμα του διαγράμματος. Οι ρυθμίσεις ομάδας όπως η επικάλυψη και το πλάτος κενών ελέγχουν τη διάταξη και δεν είναι αντικαταστάσεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα γράφημα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, οι περιορισμοί του αρχείου παρουσίασης, η διαθέσιμη μνήμη, ο χρόνος απόδοσης και η αναγνωσιμότητα του διαγράμματος καθορίζουν ένα πρακτικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά;**

Καλέστε το [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) στην κατάλληλη γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το διάστημα μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.