---
title: Διαχείριση σειρών δεδομένων γραφήματος στις παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Σειρές δεδομένων
type: docs
url: /el/nodejs-java/chart-series/
keywords:
- σειρές γραφήματος
- επικάλυψη σειράς
- χρώμα σειράς
- όνομα σειράς
- σημείο δεδομένων
- κελί βιβλίου εργασίας
- διάστημα σειράς
- αρνητική τιμή
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σειρές γραφήματος, σημεία δεδομένων, κελιά βιβλίου εργασίας, μορφοποίηση, επικάλυψη, πλάτος κενών και αρνητικές τιμές σε παρουσιάσεις με JavaScript."
---
## **Επισκόπηση**

Ένα γράφημα μπορεί να αποθηκεύει τις σχεδιασμένες του τιμές σε κελιά βιβλίου εργασίας ή απευθείας ως αριθμητικά λήμματα. Ένα [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) αντιπροσωπεύει ένα σύνολο σχετιζόμενων τιμών, και κάθε [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) αντιπροσωπεύει ένα σημείο σε αυτή τη σειρά. Τα αντικείμενα [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται οι σειρές. Σε γραφήματα που δημιουργούνται με προεπιλεγμένα δεδομένα, τα ονόματα σειρών, οι κατηγορίες και οι τιμές σημείων χρησιμοποιούν αντικείμενα [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) από το βιβλίο εργασίας του γραφήματος.

Για ένα τυπικό γράφημα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για τα ονόματα σειρών, τη στήλη 0 για τα ονόματα κατηγοριών και τα υπόλοιπα κελιά για τις τιμές σειρών. Οι δείκτες φύλλου, γραμμής και στήλης που περνούν στο [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) είναι μηδενικά‑βάση. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα γράφημα με προεπιλεγμένα δεδομένα, αλλά μην υποθέτετε ότι κάθε υπάρχον γράφημα τη χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, ελέγξτε τα κελιά στα οποία αναφέρονται οι σειρές, οι κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις γραφήματος έχουν τρία διαφορετικά πεδία:

- Ρυθμίσεις σε επίπεδο σειράς, όπως το [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία μιας σειράς.
- Ρυθμίσεις σημείου δεδομένων, όπως το [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), υπερισχύουν της εμφάνισης της σειράς για ένα σημείο.
- Ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στο ίδιο [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/). Πρόσβαση στην ομάδα μέσω του [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) όταν χρειάζεται να ορίσετε επιλογές όπως επικάλυψη ή πλάτος κενού.

Όταν δεν έχει οριστεί ρητά γέμισμα σημείου ή σειράς, το στυλ και το θέμα του γραφήματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν και μορφοποίηση σειράς και σημείου, η μορφοποίηση του σημείου έχει προτεραιότητα για εκείνο το σημείο.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός τιμών σειράς χρησιμοποιώντας αριθμητικά λήμματα**

Χρησιμοποιήστε αριθμητικά λήμματα όταν οι τιμές της σειράς προέρχονται από δεδομένα ή υπολογισμούς της εφαρμογής και δεν χρειάζονται παραπομπές σε κελιά φύλλου εργασίας. Καλέστε το [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) με το [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) πριν αντιστοιχίσετε το αποτέλεσμα του [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) κάθε σημείου μέσω του [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Η ρύθμιση συλλογής ελέγχει τον τύπο πηγής όλων των τιμών σημείων σε εκείνη τη σειρά. Η μέθοδος [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) κάθε τιμής σημείου αναφέρει τον επιλεγμένο τύπο· αλλάξτε την μέσω της ρύθμισης συλλογής. Με `Worksheet`, χρησιμοποιήστε το [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) για πρόσβαση στο παρατιθέμενο κελί. Με `DoubleLiterals`, χρησιμοποιήστε το [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) ή το `setAsLiteralDouble` για ανάγνωση ή εγγραφή του αριθμού απευθείας.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα στήλης με προεπιλεγμένες σειρές και κατηγορίες, στη συνέχεια αντιστοιχίζει τις υπολογισμένες τιμές 10, 20 κ.λπ. στα υπάρχοντα σημεία της πρώτης σειράς. Αποθηκεύει την παρουσίαση, τη ξανανοίγει και εκτυπώνει τις αποθηκευμένες τιμές.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Ο τύπος πηγής τιμής σημείου είναι διαχωρισμένος από το [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), το οποίο καταδεικνύει τη διαμόρφωση του εσωτερικού ή εξωτερικού βιβλίου εργασίας του γραφήματος. Η χρήση αριθμητικών λημμάτων δεν αφαιρεί, από μόνο της, το ενσωματωμένο βιβλίο εργασίας. Σε αυτό το παράδειγμα, το βιβλίο εργασίας παραμένει διαθέσιμο για ετικέτες κατηγοριών, ονόματα σειρών και τις άλλες σειρές. Δείτε το [Chart Workbook](/slides/el/nodejs-java/chart-workbook/) για διαχείριση βιβλίου εργασίας.

Για γραφήματα scatter και bubble, χρησιμοποιήστε το [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) και το [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) για επιλογή των πηγών για το [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) και το [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/). Τα γραφήματα bubble χρησιμοποιούν επίσης το [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) για το [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/). Ορίστε κάθε σχετική πηγή σε `DoubleLiterals` πριν αντιστοιχίσετε αριθμούς μέσω της μεθόδου `setAsLiteralDouble` της τιμής.

## **Ορισμός επικάλυψης σειράς γραφήματος**

Το [ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) αναφέρει πόσο οι ράβδοι ή στήλες επικαλύπτονται σε ένα 2Δ γράφημα, από -100 έως 100 %· είναι μια ανάγνωση μόνο της ρύθμισης στην γονική ομάδα σειρών. Χρησιμοποιήστε το [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) για να ενημερώσετε κάθε συμβατή σειρά στην ομάδα. Αυτή η επιλογή ισχύει για τύπους γραφημάτων που εμφανίζουν ομαδοποιημένους ράβδους ή στήλες· δεν επηρεάζει ανεξάρτητες ομάδες σειρών σε ένα συνδυαστικό γράφημα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιέχει την πρώτη σειρά:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Το νέο γράφημα περιέχει δείγμα σειρών, κατηγοριών και τιμών.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The series overlap](series_overlap.png)

## **Αλλαγή χρώματος γεμίσματος σειράς**

Χρησιμοποιήστε το [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) για να ορίσετε το προεπιλεγμένο γέμισμα ολόκληρης μιας σειράς. Εάν ένα σημείο έχει ήδη ρητό γέμισμα, η ρύθμιση του [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) υπερισχύει του γεμίσματος της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει συμπαγές μπλε γέμισμα στην πρώτη σειρά:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The color of the series](series_color.png)

## **Αλλαγή ονόματος σειράς**

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων του γραφήματος και εμφανίζεται συνήθως στην υπόμνηση. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα γράφημα στήλης με ομαδοποίηση, το κελί B1 είναι στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι σταθερές ονόματος στο παρακάτω παράδειγμα κάνουν αυτή τη δομή σαφή:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής και στήλης σε υπάρχον γράφημα:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The series name](series_name.png)

### **Δημιουργία σειράς με όνομα από πολλαπλά κελιά**

Ένα σύνθετο όνομα σειράς είναι χρήσιμο όταν το όνομα προϊόντος και η αναφορά περιόδου αποθηκεύονται σε ξεχωριστά κελιά βιβλίου εργασίας. Για παράδειγμα, μπορείτε να συνδυάσετε το `Product A` στο B1 και το `2026` στο C1 σε ένα ενιαίο όνομα σειράς διατηρώντας και τα δύο μέρη συνδεδεμένα με τα πηγαία κελιά τους.

Χρησιμοποιήστε το [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) για να ανακτήσετε το εύρος ονομάτων, στη συνέχεια περάστε αυτή τη συλλογή στο [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/). Το επιχείρημα `skipHiddenCells` ελέγχει εάν τα κρυφά κελιά περιλαμβάνονται: `true` τα εξαιρεί, ενώ `false` τα περιλαμβάνει. Αυτό το παράδειγμα χρησιμοποιεί `false` για να συμπεριλάβει κάθε κελί στο εύρος ονόματος.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με μία σειρά και δύο σημεία δεδομένων. Τα κελιά B1:C1 παρέχουν μόνο το όνομα σειράς· τα A2:A3 παρέχουν τις ετικέτες κατηγοριών, και τα B2:B3 παρέχουν τις αριθμητικές τιμές.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Αυτά τα δύο κελιά παρέχουν το όνομα της σειράς.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // Ξεχωριστά κελιά παρέχουν τις κατηγορίες και τα αριθμητικά σημεία δεδομένων.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το παραγόμενο όνομα σειράς είναι `Product A 2026`, με κενό μεταξύ των δύο τιμών κελιών. Η υπόμνηση το εμφανίζει ως μία καταχώρηση για και τις δύο στήλες. Η εικόνα παρακάτω δείχνει το αποτέλεσμα:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Λήψη αυτόματου χρώματος γεμίσματος σειράς**

Το [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) επιστρέφει το χρώμα που υπολογίζεται από τον δείκτη της σειράς και το στυλ του γραφήματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογιζόμενο χρώμα· δεν ορίζει νέο γέμισμα.

Το παρακάτω παράδειγμα εκτυπώνει το αυτόματο χρώμα κάθε προεπιλεγμένης σειράς:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Παράδειγμα εξόδου για το προεπιλεγμένο στυλ γραφήματος:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Τα ακριβή χρώματα εξαρτώνται από το στυλ και το θέμα του γραφήματος.

## **Ορισμός αντιστροφής χρώματος γεμίσματος για σειρά γραφήματος**

Για σειρές ράβδου, στήλης και bubble, το [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα σειράς σε συμπαγές, ενεργοποιήστε την αντιστροφή και αντιστοιχίστε το χρώμα αρνητικής τιμής μέσω του [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· μόνο το χρώμα εμφάνισής τους αλλάζει.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα γραφήματος με μία σειρά. Η γραμμή 0 του φύλλου εργασίας περιέχει το όνομα της σειράς, η στήλη 0 περιέχει τα ονόματα κατηγοριών και η στήλη 1 τις τιμές:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The inverted solid fill color](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιείται μόνο για το επιλεγμένο σημείο. Το σημείο επίσης λαμβάνει μια αρνητική τιμή ώστε το εφέ να είναι ορατό:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Καθαρισμός συγκεκριμένης τιμής σημείου δεδομένων**

Για να κάνετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα σημεία, ορίστε το αντίστοιχο κελί του βιβλίου εργασίας σε `null`. Σε ένα γράφημα στήλης, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το γράφημα το αντιμετωπίζει ως κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του γραφήματος.

Το παρακάτω παράδειγμα καθαρίζει μόνο το δεύτερο σημείο στην πρώτη σειρά:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Τα γραφήματα scatter χρησιμοποιούν ξεχωριστά κελιά X και Y, και τα bubble επίσης ένα κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) όταν θέλετε να κρατήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος εμφάνισης κενών κελιών**

Κρυφά κελιά που περιέχουν τιμές αποτελούν ξεχωριστό σενάριο από κενά κελιά. Για να περιλάβετε ή να εξαιρέσετε δεδομένα από κρυμμένες γραμμές και στήλες φύλλου εργασίας, δείτε το [Συμπερίληψη δεδομένων από κρυμμένες γραμμές και στήλες](/slides/el/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί βιβλίου εργασίας αντιπροσωπεύει ελλιπή δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει γνωστή αριθμητική τιμή. Καλέστε το [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) με `null` για να κάνετε ένα κελί κενό. Ένας αριθμητικός μηδέν παραμένει μηδέν ανεξάρτητα από τη ρύθμιση κενών κελιών.

Χρησιμοποιήστε το [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) για να επιλέξετε πώς θα εμφανίζεται το γράφημα τα κενά κελιά. Αυτή η ρύθμιση ισχύει για ολόκληρο το γράφημα. Αλλάζει τον τρόπο που σχεδιάζονται τα κενά, χωρίς να γεμίζει το κενό κελί του βιβλίου εργασίας με μηδέν ή με παρεμβατική τιμή.

Το παρακάτω αυτοσυνεπές παράδειγμα δημιουργεί ένα γράφημα γραμμής με μία σειρά, αφαιρεί την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο γράφημα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) χρησιμοποιεί το φύλλο 0, τη στήλη 0 για ετικέτες κατηγοριών και τη στήλη 1 για τιμές· η γραμμή 0 κρατά το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Αφήστε την Ημέρα 3 πραγματικά κενή, διατηρώντας την κατηγορία και το σημείο δεδομένων.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που έχει ανατεθεί πριν την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για αποθήκευση μόνο μιας έκδοσης, ορίστε την επιθυμητή λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί να επαναλάβετε τις λειτουργίες.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε κάθε περίπτωση:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Το οπτικό αποτέλεσμα εξαρτάται από τον τύπο γραφήματος. Ένα γράφημα γραμμής καθιστά εύκολη τη σύγκριση των τριών λειτουργιών. Τα γραφήματα ράβδου και στήλης δεν έχουν γραμμή για σύνδεση μέσω μιας ελλιπούσας κατηγορίας, επομένως το `Span` δεν μπορεί να δημιουργήσει το σύνδεσμο που φαίνεται παραπάνω· ένα κενό σύστημα στήλης και μια στήλη μηδενικού ύψους μπορούν επίσης να φαίνονται παρόμοια. Ομοίως, ένα γράφημα scatter με μόνο σημεία δεν έχει γραμμή σύνδεσης. Μην περιμένετε τρία διακριτά αποτελέσματα για κάθε τύπο γραφήματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός πλάτους κενού σειράς**

Το πλάτος κενού είναι το διάστημα μεταξύ διαδοχικών ομάδων ράβδων ή στηλών, εκφρασμένο ως ποσοστό του πλάτους της ράβδου ή στήλης. Όπως και η επικάλυψη, ανήκει στην γονική ομάδα σειρών και όχι σε μία σειρά. Καλέστε το [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) μία φορά για την ομάδα. Μια μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μια μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος κενού και αποθηκεύει μόνο την τελική παρουσίαση:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The gap width](gap_width.png)

## **Συχνές ερωτήσεις**

**Ποιοι τύποι γραφημάτων υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι γραφημάτων που αντιπροσωπεύονται από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) χρησιμοποιούν δεδομένα γραφήματος, αλλά οι σειρές τους δεν έχουν όλοι την ίδια δομή τιμών ή ρυθμίσεις. Για παράδειγμα, τα γραφήματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα scatter χρησιμοποιούν τιμές X και Y, και τα bubble προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο σειράς. Επιλογές όπως επικάλυψη και πλάτος κενού ισχύουν μόνο για συμβατές ομάδες ράβδων ή στηλών.

**Τι είναι μια ομάδα σειρών γραφήματος;**

Μια [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις επίπεδου σχεδίασης. Ένα συνδυαστικό γράφημα μπορεί να περιέχει περισσότερες από μία ομάδες, έτσι η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει υποχρεωτικά όλες τις σειρές στο γράφημα.

**Δημιουργεί ένα νεοδημιουργημένο γράφημα προεπιλεγμένα δεδομένα;**

Ναι. Από προεπιλογή, το [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) δημιουργεί δείγματα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να καθαρίσετε τόσο τις συλλογές σειρών όσο και τις συλλογές κατηγοριών πριν προσθέσετε ένα πλήρως προσαρμοσμένο σύνολο δεδομένων. Μια υπερφόρτωση μπορεί επίσης να δημιουργήσει ένα γράφημα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα γραφήματος με κελιά βιβλίου εργασίας;**

Τα ονόματα σειρών, ετικέτες κατηγοριών και τιμές σημείων δεδομένων παραπέμπουν σε κελιά σε ένα [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). Η αλλαγή ενός παρατιθέμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του γραφήματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις γραμμές κατηγορίας και τις γραμμές τιμών σειρών ευθυγραμμισμένες έτσι ώστε κάθε σημείο να σχεδιάζεται κάτω από την επιθυμητή κατηγορία.

**Πώς να καθαρίσω ένα σημείο αντί ολόκληρης σειράς;**

Ορίστε το σχετικό κελί τιμής σε `null` για να διατηρήσετε τη θέση της κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) μόνο όταν επιθυμείτε να αφαιρέσετε όλα τα σημεία από αυτή τη σειρά. Εάν αφαιρείτε επίσης κατηγορίες, ενημερώστε κάθε σειρά ώστε οι τιμές τους να παραμένουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο γραφήματος και τη ρύθμιση που έχει καθοριστεί μέσω του [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/). Τα υποστηριζόμενα γραφήματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει με το νόημα των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε το [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς μορφοποιούνται οι αρνητικές τιμές;**

Για υποστηριζόμενες σειρές ράβδου, στήλης και bubble, καλέστε το [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) και ορίστε το χρώμα που επιστρέφει το [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Μπορείτε να υπερισχύσετε της συμπεριφοράς για ένα επιπλέον σημείο με το [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). Αυτές οι μέθοδοι επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση υπερισχύει όταν τόσο σειρά όσο και σημείο έχουν μορφοποιηθεί;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφή της σειράς ή, όταν η μορφή σειράς δεν ορίζεται, το αυτόματο στυλ και θέμα του γραφήματος. Οι ρυθμίσεις ομάδας όπως επικάλυψη και πλάτος κενού ελέγχουν τη διάταξη και δεν είναι παρακάμψεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα γράφημα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, περιορισμοί του αρχείου παρουσίασης, διαθέσιμη μνήμη, χρόνος απόδοσης και η αναγνωσιμότητα του γραφήματος καθορίζουν ένα χρηστικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά μεταξύ τους;**

Καλέστε το [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) στη σχετική γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το διάστημα μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.