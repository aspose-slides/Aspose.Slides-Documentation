---
title: Διαχείριση Βιβλίων Εργασίας Διαγραμμάτων σε Παρουσιάσεις με Java
linktitle: Βιβλίο Εργασίας Διαγράμματος
type: docs
weight: 70
url: /el/java/chart-workbook/
keywords:
- βιβλίο εργασίας διαγράμματος
- δεδομένα διαγράμματος
- κελί βιβλίου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό βιβλίο εργασίας
- εξωτερικά δεδομένα
- λανθάνουσα μνήμη διαγράμματος
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Java: διαχειριστείτε με ευκολία τα βιβλία εργασίας διαγραμμάτων στο PowerPoint και σε μορφές OpenDocument, για να βελτιστοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να αποκτήσετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίσετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Επιπλέον, καλύπτει την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αναθέσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που συνδέεται με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**
Το Aspose.Slides παρέχει τις μεθόδους [ReadWorkbookStream](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData#readWorkbookStream--) και [WriteWorkbookStream](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) που επιτρέπουν την ανάγνωση και την εγγραφή βιβλίων εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με το Aspose.Cells). **Σημείωση** ότι τα δεδομένα του διαγράμματος πρέπει να οργανώνονται με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

Αυτός ο κώδικας Java δείχνει μια παράδειγμα λειτουργίας:

```java
Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Κελιού WorkBook ως Ετικέτα Δεδομένων Διαγράμματος**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://apireference.aspose.com/slides/el/java/com.aspose.slides/presentation).
1. Λάβετε μια αναφορά στη διαφάνεια μέσω του δείκτη της.
1. Προσθέστε ένα διάγραμμα Bubble με κάποια δεδομένα.
1. Πρόσβαση στην σειρά του διαγράμματος.
1. Ορίστε το κελί του βιβλίου εργασίας ως ετικέτα δεδομένων.
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων διαγράμματος:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαχείριση Φύλλων Εργασίας**

Αυτός ο κώδικας Java δείχνει μια λειτουργία όπου η μέθοδος [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) χρησιμοποιείται για πρόσβαση σε μια συλλογή φύλλων εργασίας:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Καθορισμός Τύπου Πηγής Δεδομένων**

Αυτός ο κώδικας Java δείχνει πώς να καθορίσετε έναν τύπο για μια πηγή δεδομένων:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εντοπισμός Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Workbook**

Το Aspose.Slides δεν υποστηρίζει τη μορφή δυαδικού βιβλίου Excel (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `getEmbeddedWorkbookType` στο [IChartData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/java/com.aspose.slides/WorkbookType) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Το ενσωματωμένο βιβλίο εργασίας είναι σε μορφή .xlsb, η οποία δεν υποστηρίζεται.
            continue;
        }

        // Διαβάστε ή τροποποιήστε τα δεδομένα του βιβλίου εργασίας του διαγράμματος εδώ.
    }
} finally {
    presentation.dispose();
}
```

## **Εξωτερικό Workbook**

{{% alert color="primary" %}} 
Στο [Aspose.Slides 19.4](https://docs.aspose.com/slides/el/java/aspose-slides-for-java-19-4-release-notes/) υλοποιήσαμε την υποστήριξη για εξωτερικά βιβλία εργασίας ως πηγή δεδομένων για διαγράμματα.
{{% /alert %}} 

### **Δημιουργία Εξωτερικού Workbook**

Χρησιμοποιώντας τις μεθόδους **`readWorkbookStream`** και **`setExternalWorkbook`**, μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από την αρχή είτε να κάνετε ένα εσωτερικό βιβλίο εργασίας εξωτερικό.

Αυτός ο κώδικας Java δείχνει τη διαδικασία δημιουργίας εξωτερικού βιβλίου εργασίας:

```java
Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ορισμός Εξωτερικού Workbook**

Χρησιμοποιώντας τη μέθοδο **`setExternalWorkbook`**, μπορείτε να αναθέσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Η μέθοδος αυτή μπορεί επίσης να χρησιμοποιηθεί για να ενημερώσει τη διαδρομή προς το εξωτερικό βιβλίο εργασίας (αν αυτό μετακινήθηκε).

Αν και δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας που αποθηκεύονται σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να χρησιμοποιήσετε τέτοια βιβλία εργασίας ως εξωτερική πηγή δεδομένων. Εάν παρέχεται η σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

```java
// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Η παράμετρος `ChartData` (μετά τη μέθοδο `setExternalWorkbook`) χρησιμοποιείται για να καθορίσει αν θα φορτωθεί ή όχι ένα βιβλίο εργασίας Excel.

* Όταν η τιμή του `ChartData` οριστεί σε `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας — τα δεδομένα του διαγράμματος δεν θα φορτωθούν ή ενημερωθούν από το βιβλίο προορισμού. Μπορείτε να χρησιμοποιήσετε αυτήν τη ρύθμιση όταν το βιβλίο εργασίας προορισμού δεν υπάρχει ή δεν είναι διαθέσιμο.
* Όταν η τιμή του `ChartData` οριστεί σε `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το βιβλίο προορισμού.

```java
// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ανάκτηση της Διαδρομής Εξωτερικής Πηγής Workbook ενός Διαγράμματος**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://apireference.aspose.com/slides/el/java/com.aspose.slides/presentation).
1. Λάβετε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Δημιουργήστε ένα αντικείμενο για το σχήμα του διαγράμματος.
1. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής (`ChartDataSourceType`) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
1. Καθορίστε την αντίστοιχη κατάσταση με βάση τον τύπο πηγής που είναι ίδιος με τον τύπο πηγής εξωτερικού βιβλίου εργασίας.

Αυτός ο κώδικας Java δείχνει τη λειτουργία:

```java
// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Αποθηκεύει την παρουσίαση
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Επεξεργασία Δεδομένων Διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα εσωτερικών βιβλίων εργασίας. Όταν δεν είναι δυνατό το φόρτωμα ενός εξωτερικού βιβλίου εργασίας, ρίχνεται εξαίρεση.

Αυτός ο κώδικας Java είναι μια υλοποίηση της περιγραφόμενης διαδικασίας:

```java
// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ανάκτηση Βιβλίου Εργασίας από την Λανθάνουσα Μνήμη Διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανακατασκευάσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που είναι αποθηκευμένα στην παρουσίαση. Δημιουργήστε το [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/), διαμορφώστε το με το [SpreadsheetOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/spreadsheetoptions/), και καλέστε την [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) με την τιμή `true` πριν ανοίξετε την παρουσίαση.

Το ακόλουθο παράδειγμα Java ανοίγει μια παρουσίαση του οποίου το διάγραμμα αναφέρεται σε ένα μη διαθέσιμο εξωτερικό βιβλίο εργασίας και προσπελαύει τα ανακτημένα δεδομένα μέσω των [IChart.getChartData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichart/#getChartData--) και [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Διαβάστε ή τροποποιήστε τα ανακτήμένα δεδομένα του βιβλίου εργασίας εδώ.
} finally {
    presentation.dispose();
}
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των αποθηκευμένων δεδομένων διαγράμματος αποτελεί αποδεκτό εναλλακτικό, καθώς η λανθάνουσα μνήμη ενδέχεται να μην περιέχει τις αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να καθορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [τύπο πηγής δεδομένων](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getDataSourceType--) και μια [διαδρομή σε εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται οι σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό είναι βολικό για τη φορητότητα του έργου· ωστόσο, να γνωρίζετε ότι η παρουσίαση θα αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται — μπορούν να χρησιμοποιηθούν μόνο ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό αρχείο XLSX κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσίαση αποθηκεύει έναν [σύνδεσμο προς το εξωτερικό αρχείο](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) και τον χρησιμοποιεί για την ανάγνωση των δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται κατά την αποθήκευση της παρουσίασης.

**Τι πρέπει να κάνω αν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια συνήθης προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/java/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που θα φορτωθούν τα δεδομένα.