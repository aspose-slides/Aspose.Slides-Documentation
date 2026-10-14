---
title: Προσαρμογή Διαγραμμάτων Πίτας σε Παρουσιάσεις Χρησιμοποιώντας JavaScript
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/nodejs-java/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές σχεδίου
- χρώμα φέτας
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα πίτας σε JavaScript με το Aspose.Slides για Node.js μέσω Java. Διαμορφώστε δευτερεύουσες γραφικές απεικονίσεις, εμφανίστε ετικέτες δεδομένων και εφαρμόστε αυτόματα χρώματα φετών στο PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με διαγράμματα πίτας στο Aspose.Slides. Δείχνει πώς να διαμορφώσετε τις επιλογές δευτερεύοντος διαγράμματος για διαγράμματα Pie of Pie και Bar of Pie, και πώς να ενεργοποιήσετε την αυτόματη χρωματισμό των φετών για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα εστιάζουν σε εργασίες προσαρμογής διαγράμματος όπως η προσθήκη διαγράμματος σε μια διαφάνεια, η προσαρμογή των ρυθμίσεων σειρών και ετικετών, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Δευτερεύουσες Επιλογές Διαγράμματος για Pie of Pie και Bar of Pie**

Το Aspose.Slides for Node.js via Java υποστηρίζει δευτερεύουσες επιλογές διαγράμματος για διαγράμματα Pie of Pie και Bar of Pie. Αυτές οι επιλογές ελέγχουν το μέγεθος του δευτερεύοντος διαγράμματος και πώς τα σημεία δεδομένων χωρίζονται μεταξύ των δύο διαγραμμάτων.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα Pie of Pie σε μια νέα παρουσίαση και εμφανίζει τις τιμές των σημείων δεδομένων ως ετικέτες. Η μέθοδος [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) ορίζει το μέγεθος του δευτερεύοντος διαγράμματος στο 149% του κύριου διαγράμματος. Η [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) επιλέγει διαχωρισμό βάσει ποσοστών, και η [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) ορίζει το όριο στο 53%.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Εμφάνιση τιμών και διαμόρφωση του δευτερεύοντος διαγράμματος.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Επιλογή Κατηγοριών για το Δευτερεύον Διάγραμμα**

Χρησιμοποιήστε προσαρμοσμένο διαχωρισμό όταν θέλετε να ομαδοποιήσετε συγκεκριμένες κατηγορίες στο δευτερεύον διάγραμμα ανεξάρτητα από τις τιμές ποσοστών τους. Για παράδειγμα, μια αναφορά πωλήσεων μπορεί να δείχνει Online και Events μαζί ώστε οι αναγνώστες να μπορούν να συγκρίνουν αυτά τα δύο κανάλια, ακόμη και αν αντιστοιχούν στο 35% και το 10% των συνολικών πωλήσεων.

Καλέστε τη [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) με το [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) και επιλέξτε τα σημεία μέσω της [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Η μέθοδος [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) της συλλογής δέχεται έναν δείκτη μηδενικής βάσης στη σειρά· χρησιμοποιήστε τη [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) για να προσθέσετε ένα αντικείμενο σημείου δεδομένων. Σε αυτό το παράδειγμα, ο δείκτης 1 επιλέγει το Online, και το σημείο στον δείκτη 3 επιλέγει το Events. Το Partners προστίθεται επίσης προσωρινά, μετά αφαιρείται χρησιμοποιώντας τη [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Αντικατάσταση των προεπιλεγμένων δεδομένων με πωλήσεις ανά κανάλι.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Επιλογή του Online με βάση το μηδενικό του δείκτη και του Events με το αντικείμενο σημείου δεδομένων.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Αποκλεισμός του Partners από την επιλογή χωρίς διαγραφή των πηγαίων δεδομένων του.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το Online (35) και το Events (10) εμφανίζονται ως ξεχωριστές φέτες στο δευτερεύον διάγραμμα. Στο κύριο διάγραμμα, αντιπροσωπεύονται από μία συνδυασμένη φέτα με τιμή 45, μαζί με το Retail (40) και το Partners (15). Η αφαίρεση του Partners από την προσαρμοσμένη επιλογή το διατηρεί στο κύριο διάγραμμα· δεν αφαιρεί την κατηγορία ή την τιμή της από τα πηγαία δεδομένα του διαγράμματος.

Η παρακάτω εικόνα δείχνει την αποθηκευμένη παρουσίαση στο PowerPoint:

![Διάγραμμα Pie of Pie με Online και Events στο δευτερεύον διάγραμμα και τη συνδυασμένη τους τιμή 45 στο κύριο διάγραμμα](pie_of_pie_custom.png)

## **Ορίστε Αυτόματους Χρωμούς Φετών Διαγράμματος Πίτας**

Το Aspose.Slides for Node.js via Java μπορεί να αναθέσει αυτόματα διαφορετικά χρώματα στις φέτες ενός διαγράμματος πίτας. Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα πίτας με κεντρικό τίτλο και αντικαθιστά τα προεπιλεγμένα δεδομένα με τρεις τριμηνιαίες κατηγορίες και τις τιμές τους. Η μέθοδος [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) εμφανίζει τις τιμές 20, 50 και 30 ως ετικέτες, ενώ η [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) ενεργοποιεί ένα διακριτό χρώμα για κάθε φέτα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Προσθήκη κεντραρισμένου τίτλου διαγράμματος.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Αντικατάσταση των προεπιλεγμένων δεδομένων χρησιμοποιώντας το πρώτο φύλλο εργασίας.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Εμφάνιση τιμών και ανάθεση διαφορετικών χρωμάτων στις φετες.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Υποστηρίζονται οι παραλλαγές Pie of Pie και Bar of Pie;**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ένα δευτερεύον διάγραμμα για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων Pie of Pie και Bar of Pie.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το διάγραμμα ως εικόνα](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (όπως PNG) χωρίς να εξάγετε ολόκληρη την παρουσίαση.