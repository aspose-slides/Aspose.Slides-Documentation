---
title: Διαχείριση βιβλίων εργασίας διαγραμμάτων σε παρουσιάσεις με JavaScript
linktitle: Βιβλίο εργασίας διαγράμματος
type: docs
weight: 70
url: /el/nodejs-java/chart-workbook/
keywords:
- βιβλίο εργασίας διαγράμματος
- δεδομένα διαγράμματος
- κελί βιβλίου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό βιβλίο εργασίας
- εξωτερικά δεδομένα
- κρυφή μνήμη διαγράμματος
- αποκατάσταση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Node.js μέσω Java: διαχειριστείτε εύκολα βιβλία εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να βελτιστοποιήσετε τα δεδομένα των παρουσιάσεών σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να αποκτάτε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να ορίσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που είναι συνδεδεμένο με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

Για κελιά βιβλίου εργασίας που αντιπροσωπεύουν ελλιπείς τιμές, δείτε [Έλεγχος της εμφάνισης κενών κυψελών](/slides/el/nodejs-java/chart-series/) για τη διαφορά μεταξύ ενός κενού κελιού και του μηδενός, καθώς και για σύγκριση γραμμικού διαγράμματος των διαθέσιμων τρόπων εμφάνισης.

## **Συμπερίληψη δεδομένων από κρυμμένες σειρές και στήλες**

Χρησιμοποιήστε [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) για να ελέγξετε εάν ένα διάγραμμα σχεδιάζει δεδομένα από κρυμμένες σειρές και στήλες φύλλου εργασίας. Ορίστε το σε `true` για να σχεδιάζετε μόνο ορατά κελιά ή σε `false` για να συμπεριλάβετε τόσο ορατά όσο και κρυμμένα κελιά. Αυτή η ρύθμιση ελέγχει την σχεδίαση του διαγράμματος· δεν κρύβει ή αποκρύβει σειρές ή στήλες φύλλου εργασίας.

Η [δειγματική παρουσίαση](hidden-source-data.pptx) περιέχει ένα ραβδογράφημα ως το πρώτο σχήμα στην πρώτη διαφάνειά της. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιέχει την εξής περιοχή προέλευσης, `A1:C4`. Η σειρά 3 και η στήλη C είναι κρυμμένες, αλλά τα κελιά τους συνεχίζουν να περιέχουν τιμές.

| Σειρά φύλλου εργασίας | A: Μήνας | B: Λιανική | C: Χονδρική (κρυφή στήλη) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (κρυφή σειρά) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Προσπελάστε τα κελιά προέλευσης μέσω [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) και διαβάστε [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) για να ελέγξετε την κρυφή τους κατάσταση. Αυτή η μέθοδος αναφέρει την κρυφή κατάσταση χωρίς να την αλλάζει. Σε αυτό το αρχείο, το B2 είναι ορατό, το B3 ανήκει στη κρυφή σειρά και το C2 ανήκει στη κρυφή στήλη· το παράδειγμα εκτυπώνει `false`, `true` και `true`, αντίστοιχα.

Για αυτό το παράδειγμα, ανανεώστε τα δεδομένα του διαγράμματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε το ενσωματωμένο βιβλίο εργασίας με [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) και επαναφορτώστε το με [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/). Όταν συμπεριλαμβάνονται όλα τα κελιά, χρησιμοποιήστε επίσης [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) για να αποκαταστήσετε την πλήρη περιοχή, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουαρίου. Η απλή αλλαγή της σημαίας δεν είναι επαρκής για την ανανέωση των δεδομένων και των ετικετών κατηγοριών του δείγματος. Το παράδειγμα μετατρέπει το επιστρεφόμενο buffer Node.js σε πίνακα byte Java πριν το περάσει στη μέθοδο εγγραφής.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Ανανέωση των δεδομένων του διαγράμματος από το ενσωματωμένο βιβλίο εργασίας.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Επαναφορά της πλήρους περιοχής προέλευσης, συμπεριλαμβανομένων των κρυφών κατηγοριών.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Το παράδειγμα αποθηκεύει δύο εκδόσεις της παρουσίασης: μία με μόνο τις ορατές τιμές Λιανικής (10 και 20) και μία με όλες τις έξι τιμές. Οι παρακάτω εικόνες απεικονίζουν τις δύο λειτουργίες σχεδίασης. Η σειρά 3 και η στήλη C παραμένουν κρυμμένες και στις δύο ενσωματωμένες βιβλιοθήκες εργασίας.

| Μόνο ορατά κελιά (`true`) | Όλα τα κελιά (`false`) |
| --- | --- |
| ![Μόνο ορατά κελιά: τιμές Λιανικής 10 και 20 για Ιανουάριο και Μάρτιο.](hidden_cells_True.png) | ![Όλα τα κελιά: τιμές Λιανικής και Χονδρικής για Ιανουάριο, Φεβρουάριο και Μάρτιο.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή αποκλείει κρυφά δεδομένα προέλευσης. Δείτε [Έλεγχος της εμφάνισης κενών κυψελών](/slides/el/nodejs-java/chart-series/#control-the-display-of-empty-cells) για ένα παράδειγμα.

## **Ανάκτηση της περιοχής δεδομένων ενός διαγράμματος**

Πριν ενημερώσετε τα δεδομένα βιβλίου εργασίας σε μια υπάρχουσα παρουσίαση, ελέγξτε τις περιοχές προέλευσης για να εντοπίσετε ποια κελιά φύλλου εργασίας χρησιμοποιεί κάθε διάγραμμα. Η μέθοδος [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) επιστρέφει την τρέχουσα περιοχή δεδομένων ως τύπο φύλλου εργασίας, π.χ. `Sheet1!$A$1:$D$5`. Εδώ, το `Sheet1` είναι το όνομα του φύλλου, το `!` το διαχωρίζει από την περιοχή κυψελών και το `$A$1:$D$5` προσδιορίζει τα κελιά A1 έως D5, συμπεριλαμβανομένων. Τα σύμβολα δόλλα υποδεικνύουν απόλυτες αναφορές σειράς και στήλης.

Η μέθοδος διαβάζει την τρέχουσα περιοχή χωρίς να αλλάζει το διάγραμμα ή το βιβλίο εργασίας του. Εάν το διάγραμμα δεν χρησιμοποιεί βιβλίο εργασίας ως πηγή δεδομένων, ρίχνει `InvalidOperationException`. Για περισσότερες πληροφορίες, δείτε το [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

Αυτό το παράδειγμα ανοίγει μια παρουσίαση και ελέγχει τα σχήματα απευθείας σε κάθε διαφάνεια για διαγράμματα. Εκτυπώνει το όνομα και την περιοχή προέλευσης του κάθε διαγράμματος. Εάν ένα διάγραμμα δεν χρησιμοποιεί βιβλίο εργασίας, εκτυπώνει ένα μήνυμα και συνεχίζει με το επόμενο διάγραμμα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ανάγνωση και εγγραφή δεδομένων διαγράμματος από βιβλίο εργασίας**

Το Aspose.Slides for Node.js via Java παρέχει τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) και [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) που σας επιτρέπουν να διαβάζετε και να γράφετε βιβλία εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα του διαγράμματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν παρόμοια δομή με την πηγή.

Αυτό το παράδειγμα χρησιμοποιεί μια παρουσίαση με ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη της διαφάνεια. Διαβάζει το ενσωματωμένο βιβλίο εργασίας σε μια σειρά byte, διαγράφει τις υπάρχουσες σειρές και κατηγορίες και γράφει το ίδιο βιβλίο πίσω. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσίαση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Επαλήθευση διάταξης διαγράμματος μετά την τροποποίηση βιβλίου εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να προκαλέσει αποτυχία του [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) με σφάλμα «index-out-of-range». Διαγράψτε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο διάγραμμα. Αυτό το παράδειγμα χρησιμοποιεί ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια. Το σχόλιο δείχνει πού θα γινόταν η επεξεργασία του βιβλίου εργασίας· το εκτελέσιμο παράδειγμα γράφει το αρχικό βιβλίο πίσω και επαληθεύει τη διάταξη στη μνήμη.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Τροποποιήστε τα byte του βιβλίου εργασίας εδώ, για παράδειγμα, χρησιμοποιώντας το Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Η εκκαθάριση των συλλογών αφαιρεί παλαιές αναφορές δεδομένων πριν το βιβλίο εργασίας γραφεί πίσω. Αναδημιουργήστε τυχόν απαιτούμενες αντιστοιχίσεις σειρών και κατηγοριών για το ενημερωμένο βιβλίο εργασίας πριν τη χρήση του διαγράμματος.

## **Ορισμός προσαρμοσμένων μορφών αριθμών για κελιά βιβλίου εργασίας**

Χρησιμοποιήστε [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) για να ελέγξετε πώς εμφανίζονται αριθμητικές τιμές σε ένα ενσωματωμένο βιβλίο εργασίας διαγράμματος. Για παράδειγμα, μια αναφορά μπορεί να χρειάζεται ένα ποσοστό μετατροπής να εμφανίζεται ως ποσοστό με τέσσερα δεκαδικά ψηφία και ένας συντελεστής με πέντε δεκαδικά ψηφία. Διατηρήστε και τις δύο τιμές αριθμητικές ώστε να παραμένουν διαθέσιμες για υπολογισμούς και σχεδίαση διαγράμματος.

Μια μορφή αριθμού αλλάζει την εμφάνιση, όχι την αποθηκευμένη τιμή. Η μορφή `0.0000%` εμφανίζει το `0.125` ως `12.5000%`; δεν αντικαθιστά τον αποθηκευμένο αριθμό με `12.5`. Ομοίως, το `0.00000` εμφανίζει το `0.1234567` ως `0.12346` χωρίς στρογγυλοποίηση της αποθηκευμένης τιμής. Εάν η προσαρμοσμένη μορφή είναι κενή συμβολοσειρά (`""`), χρησιμοποιείται η μορφή που επιστρέφεται από το [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/).

Το παρακάτω παράδειγμα δημιουργεί ένα ραβδογράφημα και προσπελάζει τα κελιά του μέσω [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/). Στο φύλλο 0, το B2 περιέχει το ποσοστό μετατροπής και το C2 περιέχει τον συντελεστή. Και τα δύο κελιά παρέχουν τιμές διαγράμματος. Το παράδειγμα ενεργοποιεί επίσης ετικέτες τιμών συνδεδεμένες με τις μορφές προέλευσης.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Οι μορφές κελιών βιβλίου εργασίας είναι ξεχωριστές από τις μορφές που ορίζονται άμεσα στους άξονες ή στις ετικέτες δεδομένων του διαγράμματος. Σε αυτό το παράδειγμα, κάθε ετικέτα εμφανίζει την τιμή του κελιού προέλευσης επειδή το [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) είναι ορισμένο σε `true` και ακολουθεί τη μορφή αριθμού προέλευσης επειδή το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) είναι επίσης `true`. Μετά την αποθήκευση και ανοίγμα

α της παρουσίασης, οι ετικέτες εμφανίζουν `12.5000%` και `0.12346`, όπως φαίνεται παρακάτω. Ο κατακόρυφος άξονας χρησιμοποιεί την δική του μορφή αριθμού, ορισμένη με το [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) ως `0.00`, με το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) ορισμένο σε `false`.

Για να μορφοποιήσετε μια ετικέτα δεδομένων ανεξάρτητα, ορίστε τη σημαία σύνδεσης με την προέλευση σε `false` και ορίστε μια μορφή με το [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/). Αυτό δεν αλλάζει τη μορφή του κελιού στο βιβλίο εργασίας. Για παράδειγμα, μια ανεξάρτητη μορφή ετικέτας `0.00` εμφανίζει την πρώτη τιμή ως `0.13`, ενώ το B2 εξακολουθεί να εμφανίζει `12.5000%`. Δείτε [Ετικέτες δεδομένων διαγράμματος](/slides/el/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) για άμεση μορφοποίηση ετικετών.

Η παρακάτω εικόνα δημιουργήθηκε από την αποθηκευμένη παρουσίαση μετά το ξαναάνοιγμά της:

![Ραβδογράφημα με ετικέτες συνδεδεμένες με την προέλευση που δείχνουν 12.5000% και 0.12346 και άξονα αριθμών μορφοποιημένο ανεξάρτητα.](custom-cell-formats.png)

## **Ορισμός κελιού βιβλίου εργασίας ως ετικέτας δεδομένων διαγράμματος**

Μπορείτε να χρησιμοποιήσετε κείμενο από κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος.

Αυτό το παράδειγμα προσθέτει ένα φυσαλίδα διάγραμμα με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο 0 για τις πρώτες τρεις ετικέτες της πρώτης σειράς, ενεργοποιεί τις ετικέτες από κελιά και αποθηκεύει την ενημερωμένη παρουσίαση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διαχείριση φύλλων εργασίας**

Η μέθοδος [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) παρέχει πρόσβαση στα φύλλα εργασίας ενός βιβλίου εργασίας διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα πίτα διάγραμμα με προεπιλεγμένα δεδομένα και εκτυπώνει το όνομα κάθε φύλλου εργασίας στην κονσόλα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Καθορισμός του τύπου πηγής δεδομένων**

Οι τιμές των σημείων σειράς μπορούν επίσης να αποθηκευτούν απευθείας ως αριθμητικές σταθερές. Δείτε [Ορισμός τιμών σειράς με αριθμητικές σταθερές](/slides/el/nodejs-java/chart-series/#set-series-values-using-numeric-literals) για ένα πλήρες παράδειγμα που τις αποθηκεύει και τις διαβάζει. Ο τύπος πηγής των τιμών σημείων είναι ξεχωριστός από την εσωτερική ή εξωτερική διαμόρφωση βιβλίου εργασίας του διαγράμματος· η χρήση αριθμητικών σταθερών δεν αφαιρεί από μόνη της το ενσωματωμένο βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα 3D ραβδογράφημα με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειράς χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί μια συμβολοσειρά, το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο 0. Η απαρίθμηση [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το παράδειγμα αποθηκεύει την παρουσίαση με τα ενημερωμένα ονόματα σειράς.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εντοπισμός μη υποστηριζόμενων μορφών ενσωματωμένου βιβλίου εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη μορφή βιβλίου εργασίας Excel binary (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `getEmbeddedWorkbookType` στο [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) για τον εντοπισμό μη υποστηριζόμενων μορφών και την παράλειψη αυτών των διαγραμμάτων. Αυτό το παράδειγμα εξετάζει τα σχήματα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης, παραλείπει τα σχήματα που δεν είναι διαγράμματα και εκτυπώνει ένα διαγνωστικό μήνυμα για κάθε διάγραμμα με ενσωματωμένο βιβλίο εργασίας .xlsb.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Διαβάστε ή τροποποιήστε τα υποστηριζόμενα δεδομένα βιβλίου εργασίας διαγράμματος εδώ.
    }
} finally {
    presentation.dispose();
}
```

## **Εξωτερικό βιβλίο εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Δημιουργία εξωτερικού βιβλίου εργασίας**

Χρησιμοποιήστε [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) και [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) για να εξάγετε ένα ενσωματωμένο βιβλίο εργασίας διαγράμματος σε αρχείο και να συνδέσετε το διάγραμμα με αυτό το εξωτερικό βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα πίτα διάγραμμα με προεπιλεγμένα δεδομένα και εξάγει το βιβλίο εργασίας του. Ολοκληρώνει τη συγγραφή του αρχείου πριν ορίσει το εξωτερικό βιβλίο εργασίας ως πηγή δεδομένων του διαγράμματος, στη συνέχεια αποθηκεύει την συνδεδεμένη παρουσίαση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Ορισμός εξωτερικού βιβλίου εργασίας**

Χρησιμοποιώντας τη μέθοδο [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), μπορείτε να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση της διαδρομής προς το εξωτερικό βιβλίο εργασίας (αν το τελευταίο έχει μετακινηθεί).

Αν και δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας που αποθηκεύονται σε απομακρυσμένες θέσεις ή πόρους, μπορείτε ακόμα να τα χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για το εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτό το παράδειγμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας του οποίου το φύλλο με όνομα `Sheet1` περιέχει ένα όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4 και αριθμητικές τιμές στο B2:B4. Το παράδειγμα δημιουργεί ένα πίτα διάγραμμα, συνδέει το βιβλίο εργασίας και χρησιμοποιεί [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) για να αντιστοιχίσει το A1:B4 σε μία σειρά και τρεις κατηγορίες. Αποθηκεύει την παρουσίαση με το συνδεδεμένο διάγραμμα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η παράμετρος `updateChartData` της [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) ελέγχει αν το βιβλίο εργασίας φορτώνεται.

* Όταν `updateChartData` είναι `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας. Τα δεδομένα του διαγράμματος δεν φορτώνονται ή ενημερώνονται από το προορισμένο βιβλίο εργασίας, έτσι το βιβλίο εργασίας μπορεί να μην είναι διαθέσιμο.
* Όταν `updateChartData` είναι `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το προορισμένο βιβλίο εργασίας.

Το παρακάτω παράδειγμα αντιστοιχεί μια εικονική διεύθυνση URL με `updateChartData` ορισμένο σε `false`. Διατηρεί τα προεπιλεγμένα δεδομένα του πίτα διαγράμματος και αποθηκεύει την παρουσίαση χωρίς να φορτώσει το μη διαθέσιμο βιβλίο εργασίας.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Λήψη της διαδρομής εξωτερικού βιβλίου εργασίας δεδομένων ενός διαγράμματος**

Για να εντοπίσετε το βιβλίο εργασίας που συνδέεται με ένα διάγραμμα, ελέγξτε εάν το διάγραμμα χρησιμοποιεί εξωτερική πηγή δεδομένων και ανακτήστε τη διαδρομή του βιβλίου εργασίας.

Αυτό το παράδειγμα εξετάζει το πρώτο σχήμα στην πρώτη διαφάνεια μιας παρουσίασης με συνδεδεμένο εξωτερικό βιβλίο εργασίας. Εάν πρόκειται για διάγραμμα συνδεδεμένο με εξωτερικό βιβλίο εργασίας, το παράδειγμα εκτυπώνει το [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Επεξεργασία δεδομένων διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, ρίχνεται εξαίρεση.

Αυτό το παράδειγμα χρησιμοποιεί ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και είναι συνδεδεμένο με ένα προσβάσιμο εξωτερικό βιβλίο εργασίας. Ορίζει την τιμή που προέρχεται από κελί του πρώτου σημείου δεδομένων στην πρώτη σειρά σε 100 και αποθηκεύει την ενημερωμένη παρουσίαση. Η επεξεργασία τιμών κελιών μπορεί να ενημερώσει το συνδεδεμένο εξωτερικό αρχείο XLSX, επομένως χρησιμοποιήστε ένα αντίγραφο εάν πρέπει να διατηρήσετε το αρχικό βιβλίο εργασίας.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Ανάκτηση βιβλίου εργασίας από την cache του διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανασυνθέσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που αποθηκεύονται στην cache της παρουσίασης. Δημιουργήστε [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), καλέστε [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) και ορίστε [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) σε `true` πριν ανοίξετε την παρουσίαση.

Το επόμενο παράδειγμα JavaScript ανακτά δεδομένα βιβλίου εργασίας για ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και αναφέρεται σε μη διαθέσιμο εξωτερικό βιβλίο εργασίας. Προσπελάζει τα ανακτημένα δεδομένα μέσω [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) και [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Διαβάστε ή τροποποιήστε τα επανακτημένα δεδομένα βιβλίου εργασίας εδώ.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων από την cache του διαγράμματος είναι αποδεκτή εναλλακτική, επειδή η cache ενδέχεται να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) και μια [διαδρομή σε εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάζετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται οι σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν ορίσετε σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX, επομένως η μετακίνηση του βιβλίου εργασίας μπορεί να απαιτήσει ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Η επεξεργασία τιμών διαγράμματος που προέρχονται από κελιά μπορεί επίσης να ενημερώσει το συνδεδεμένο τοπικό αρχείο XLSX. Χρησιμοποιήστε ένα αντίγραφο του βιβλίου εργασίας εάν το αρχικό πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια κοινή προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (π.χ., χρησιμοποιώντας [Aspose.Cells](https://reference.aspose.com/cells/java/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που φορτωθούν τα δεδομένα.