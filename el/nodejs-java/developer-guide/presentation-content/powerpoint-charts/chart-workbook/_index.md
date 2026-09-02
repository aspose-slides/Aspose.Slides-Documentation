---
title: "Διαχείριση βιβλίων εργασίας διαγραμμάτων σε παρουσιάσεις χρησιμοποιώντας JavaScript"
linktitle: "Βιβλίο εργασίας διαγράμματος"
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
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Node.js μέσω Java: διαχειριστείτε εύκολα βιβλία εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να απλοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να προσπελάζετε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης τη χρήση εξωτερικών βιβλίων εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα επιδεικνύουν πώς να δημιουργήσετε και να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που είναι συνδεδεμένο με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

## **Ανάγνωση και εγγραφή δεδομένων διαγράμματος από βιβλίο εργασίας**

Το Aspose.Slides παρέχει τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) και [writeWorkbookStream](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) που σας επιτρέπουν να διαβάζετε και να γράφετε βιβλία εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα του διαγράμματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

Αυτός ο κώδικας JavaScript δείχνει ένα παράδειγμα λειτουργίας:

```javascript
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός κελιού βιβλίου εργασίας ως ετικέτας δεδομένων διαγράμματος**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://apireference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) .
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Προσθέστε ένα διάγραμμα Bubble με κάποια δεδομένα.
1. Προσπελάστε τη σειρά διαγράμματος.
1. Ορίστε το κελί βιβλίου εργασίας ως ετικέτα δεδομένων.
1. Αποθηκεύστε την παρουσία.

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων διαγράμματος:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Διαχείριση φύλλων εργασίας**

Αυτός ο κώδικας JavaScript επιδεικνύει μια λειτουργία όπου η μέθοδος [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) χρησιμοποιείται για πρόσβαση σε συλλογή φύλλων εργασίας:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Καθορισμός τύπου πηγής δεδομένων**

Αυτός ο κώδικας JavaScript δείχνει πώς να καθορίσετε έναν τύπο για μια πηγή δεδομένων:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ανίχνευση μη υποστηριζόμενων ενσωματωμένων μορφών βιβλίου εργασίας**

Το Aspose.Slides δεν υποστηρίζει το δυαδικό μορφότυπο βιβλίου εργασίας Excel (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `getEmbeddedWorkbookType` στην κλάση [ChartData](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/workbooktype/) για να ανιχνεύσετε μη υποστηριζόμενες μορφές και να παραλείψετε εκείνα τα διαγράμματα.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // Το ενσωματωμένο βιβλίο εργασίας είναι σε μορφή .xlsb, η οποία δεν υποστηρίζεται.
            continue;
        }

        // Διαβάστε ή τροποποιήστε εδώ τα δεδομένα βιβλίου εργασίας του διαγράμματος.
    }
} finally {
    presentation.dispose();
}
```

## **Εξωτερικό βιβλίο εργασίας**

Το Aspose.Slides υποστηρίζει εξωτερικά βιβλία εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Δημιουργία εξωτερικού βιβλίου εργασίας**

Με τις μεθόδους **`readWorkbookStream`** και **`setExternalWorkbook`**, μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από το μηδέν είτε να κάνετε ένα εσωτερικό βιβλίο εργασίας εξωτερικό.

Αυτός ο κώδικας JavaScript δείχνει τη διαδικασία δημιουργίας εξωτερικού βιβλίου εργασίας:

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ορισμός εξωτερικού βιβλίου εργασίας**

Με τη μέθοδο **`setExternalWorkbook`**, μπορείτε να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Η μέθοδος αυτή μπορεί επίσης να χρησιμοποιηθεί για ενημέρωση της διαδρομής προς το εξωτερικό βιβλίο εργασίας (εάν το τελευταίο μετακινήθηκε).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας που αποθηκεύονται σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμα να τα χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή.

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

```javascript
// Δημιουργεί μια παρουσία της κλάσης Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Η παράμετρος `ChartData` (στη μέθοδο `setExternalWorkbook`) χρησιμοποιείται για να καθοριστεί εάν θα φορτωθεί ή όχι ένα βιβλίο εργασίας Excel.

* Όταν η τιμή `ChartData` οριστεί σε `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας — τα δεδομένα του διαγράμματος δεν θα φορτωθούν ή ενημερωθούν από το βιβλίο εργασίας προορισμού. Αυτό είναι χρήσιμο όταν το βιβλίο εργασίας προορισμού δεν υπάρχει ή δεν είναι διαθέσιμο. 
* Όταν η τιμή `ChartData` οριστεί σε `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το βιβλίο εργασίας προορισμού.

```javascript
// Δημιουργεί μια παρουσία της κλάσης Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Λήψη διαδρομής βιβλίου εργασίας εξωτερικής πηγής δεδομένων διαγράμματος**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://apireference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) .
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Δημιουργήστε ένα αντικείμενο για το σχήμα του διαγράμματος.
1. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής (`ChartDataSourceType`) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
1. Καθορίστε τη σχετική συνθήκη με βάση τον τύπο πηγής που είναι ίδιος με τον τύπο εξωτερικού βιβλίου εργασίας.

Αυτός ο κώδικας JavaScript επιδεικνύει τη λειτουργία:

```javascript
// Δημιουργεί μια παρουσία της κλάσης Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Αποθηκεύει την παρουσίαση
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Επεξεργασία δεδομένων διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα εσωτερικών βιβλίων εργασίας. Όταν δεν μπορεί να φορτωθεί ένα εξωτερικό βιβλίο εργασίας, ρίχνεται εξαίρεση.

Αυτός ο κώδικας JavaScript υλοποιεί τη διαδικασία που περιγράφεται:

```javascript
// Δημιουργεί μια παρουσία της κλάσης Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ανάκτηση βιβλίου εργασίας από την κρυφή μνήμη διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να αναστηθεί το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που έχουν αποθηκευτεί στην παρουσία. Δημιουργήστε ένα αντικείμενο [LoadOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/), ρυθμίστε το με [SpreadsheetOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/spreadsheetoptions/), και καλέστε τη μέθοδο [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) με τιμή `true` πριν ανοίξετε την παρουσία.

Το παρακάτω παράδειγμα JavaScript ανοίγει μια παρουσία της οποίας το διάγραμμα αναφέρεται σε ένα μη διαθέσιμο εξωτερικό βιβλίο εργασίας και προσπελαύει τα ανακτηθέντα δεδομένα μέσω της μεθόδου [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Διαβάστε ή τροποποιήστε εδώ τα δεδομένα του ανακτηθέντος βιβλίου εργασίας.
} finally {
    presentation.dispose();
}
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των κρυφών δεδομένων διαγράμματος αποτελεί αποδεκτή εναλλακτική, επειδή η κρυφή μνήμη ενδέχεται να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές ερωτήσεις**

**Μπορώ να καθορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [τύπο πηγής δεδομένων](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) και μια [διαδρομή προς εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν προσδιορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη. Αυτό είναι βολικό για φορητότητα του έργου· ωστόσο, η παρουσία αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσία αποθηκεύει έναν [σύνδεσμο προς το εξωτερικό αρχείο](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) και το χρησιμοποιεί για ανάγνωση δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται όταν αποθηκεύεται η παρουσία.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό πρόσβασης;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Ένας κοινός τρόπος είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/nodejs-java/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλαπλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που θα φορτωθούν τα δεδομένα.