---
title: Διαχείριση βιβλίων εργασίας διαγραμμάτων σε παρουσιάσεις με Java
linktitle: Βιβλίο εργασίας διαγράμματος
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
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Java: διαχειριστείτε άψογα βιβλία εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να βελτιστοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ρευμάτων βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος. Επίσης, καλύπτει την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που είναι συνδεδεμένο με ένα διάγραμμα, και να επεξεργαστείτε τα δεδομένα διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**

Το Aspose.Slides παρέχει τις μεθόδους [ReadWorkbookStream](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData#readWorkbookStream--) και [WriteWorkbookStream](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) που σας επιτρέπουν να διαβάζετε και να γράφετε βιβλία εργασίας διαγράμματος (που περιέχουν δεδομένα διαγράμματος που επεξεργάστηκαν με το Aspose.Cells). **Σημείωση** ότι τα δεδομένα του διαγράμματος πρέπει να οργανώνονται με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

Αυτός ο κώδικας Java δείχνει μια δείγματική λειτουργία:

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

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://apireference.aspose.com/slides/el/java/com.aspose.slides/presentation).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα Bubble με κάποια δεδομένα.
4. Πρόσβαση στη σειρά του διαγράμματος.
5. Ορίστε το κελί του βιβλίου εργασίας ως ετικέτα δεδομένων.
6. Αποθηκεύστε την παρουσίαση.

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

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλίου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη δυαδική μορφή βιβλίου εργασίας Excel (.xlsb) που μπορεί να ενσωματωθεί σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `getEmbeddedWorkbookType` στο [IChartData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/java/com.aspose.slides/WorkbookType) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε εκείνα τα διαγράμματα.

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

        // Διαβάστε ή τροποποιήστε τα δεδομένα του βιβλίου εργασίας διαγράμματος εδώ.
    }
} finally {
    presentation.dispose();
}
```

## **Εξωτερικό Βιβλίο Εργασίας**

{{% alert color="primary" %}} 
Στην έκδοση [Aspose.Slides 19.4](https://docs.aspose.com/slides/el/java/aspose-slides-for-java-19-4-release-notes/), προσθέσαμε υποστήριξη για εξωτερικά βιβλία εργασίας ως πηγή δεδομένων για διαγράμματα.
{{% /alert %}} 

### **Δημιουργία Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τις μεθόδους **`readWorkbookStream`** και **`setExternalWorkbook`**, μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από την αρχή είτε να μετατρέψετε ένα εσωτερικό βιβλίο εργασίας σε εξωτερικό.

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

### **Ορισμός Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τη μέθοδο **`setExternalWorkbook`**, μπορείτε να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση της διαδρομής προς το εξωτερικό βιβλίο εργασίας (εάν αυτό έχει μετακινηθεί).

Παρόλο που δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας που βρίσκονται σε απομακρυσμένες θέσεις ή πόρους, μπορείτε ακόμη να χρησιμοποιήσετε τέτοια βιβλία ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

```java
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
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

Η παράμετρος `ChartData` (στη μέθοδο `setExternalWorkbook`) χρησιμοποιείται για τον καθορισμό αν θα φορτωθεί ή όχι ένα βιβλίο εργασίας Excel.

* Όταν η τιμή του `ChartData` ορίζεται σε `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας —τα δεδομένα του διαγράμματος δεν φορτώνονται ούτε ενημερώνονται από το βιβλίο-στόχο. Μπορείτε να χρησιμοποιήσετε αυτή τη ρύθμιση όταν το βιβλίο-στόχο δεν υπάρχει ή δεν είναι διαθέσιμο.
* Όταν η τιμή του `ChartData` ορίζεται σε `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το βιβλίο-στόχο.

```java
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
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

### **Ανάκτηση Διαδρομής Εξωτερικής Πηγής Δεδομένων Βιβλίου Εργασίας για Διάγραμμα**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://apireference.aspose.com/slides/el/java/com.aspose.slides/presentation).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
3. Δημιουργήστε ένα αντικείμενο για το σχήμα του διαγράμματος.
4. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής (`ChartDataSourceType`) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
5. Καθορίστε την σχετική συνθήκη με βάση το ότι ο τύπος πηγής είναι ο ίδιος με τον τύπο εξωτερικής πηγής δεδομένων βιβλίου εργασίας.

Αυτός ο κώδικας Java δείχνει τη λειτουργία:

```java
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
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

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, προκύπτει εξαίρεση.

Αυτός ο κώδικας Java είναι μια υλοποίηση της περιγραφόμενης διαδικασίας:

```java
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
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

## **Συχνές Ερωτήσεις**

**Μπορώ να καθορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [data source type](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getDataSourceType--) και μια [path to an external workbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν ορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό είναι βολικό για τη φορητότητα του έργου· όμως, να γνωρίζετε ότι η παρουσίαση θα αποθηκεύσει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε κοινόχρηστους πόρους/δίκτυα;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται — μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Αντικαθιστά το εξωτερικό XLSX το Aspose.Slides κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) και το χρησιμοποιεί για την ανάγνωση των δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται όταν η παρουσίαση αποθηκεύεται.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό κατά τη σύνδεση. Μια συνήθης προσέγγιση είναι η αφαίρεση της προστασίας εκ των προτέρων ή η προετοιμασία ενός αποκρυπτογραφημένου αντιγράφου (π.χ., χρησιμοποιώντας το [Aspose.Cells](/cells/java/)) και η σύνδεση σε αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντανακλαστεί σε κάθε διάγραμμα την επόμενη φορά που θα φορτωθούν τα δεδομένα.