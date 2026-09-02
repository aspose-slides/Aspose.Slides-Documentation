---
title: Διαχείριση Βιβλίων Εργασίας Γραφημάτων σε Παρουσιάσεις με Java
linktitle: Βιβλίο Εργασίας Γραφήματος
type: docs
weight: 70
url: /el/java/chart-workbook/
keywords:
- βιβλίο εργασίας γραφήματος
- δεδομένα γραφήματος
- κελί βιβλίου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό βιβλίο εργασίας
- εξωτερικά δεδομένα
- κρύπτη γραφήματος
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Java: διαχειριστείτε εύκολα τα βιβλία εργασίας γραφημάτων σε μορφές PowerPoint και OpenDocument για να απλοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας γραφημάτων στο Aspose.Slides. Εμφανίζει πώς να διαβάζετε και να γράφετε δεδομένα γραφήματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων γραφήματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του γραφήματος.

Επίσης καλύπτει την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων γραφήματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αναθέσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που συνδέεται με ένα γράφημα και να επεξεργαστείτε τα δεδομένα του γραφήματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

## **Ανάγνωση και Εγγραφή Δεδομένων Γραφήματος από Βιβλίο Εργασίας**
Το Aspose.Slides παρέχει τις μεθόδους [ReadWorkbookStream](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData#readWorkbookStream--) και [WriteWorkbookStream](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) που σας επιτρέπουν να διαβάζετε και να γράφετε βιβλία εργασίας δεδομένων γραφήματος (που περιέχουν δεδομένα γραφήματος που επεξεργάστηκαν με το Aspose.Cells). **Σημείωση** ότι τα δεδομένα του γραφήματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν μια δομή παρόμοια με την πηγή.

Αυτός ο κώδικας Java επιδεικνύει μια ενδεικτική λειτουργία:

```java
import com.aspose.slides.*;

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

### **Επικύρωση Διάταξης Γραφήματος μετά την Τροποποίηση του Βιβλίου Εργασίας**

Όταν αντικαταστήσετε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το γράφημα διατηρεί τις αρχικές σειρές και τις συλλογές κατηγοριών του. Αυτή η ασυνέπεια μπορεί να προκαλέσει το [IChart.validateChartLayout](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichart/#validateChartLayout--) να ρίξει μια `ArgumentOutOfRangeException` (παράμετρος: index). Για να αποφύγετε την εξαίρεση, εκκαθαρίστε τις υπάρχουσες σειρές και κατηγορίες **πριν** γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο γράφημα.

```java
// Μετά την τροποποίηση του ρεύματος βιβλίου εργασίας (π.χ., χρησιμοποιώντας Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Καθαρισμός υπαρχόντων αναφορών δεδομένων.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Η εκκαθάριση των συλλογών διασφαλίζει ότι η δομή των δεδομένων του γραφήματος ευθυγραμμίζεται με το νέο βιβλίο εργασίας, επιτρέποντας στο `validateChartLayout` να ολοκληρωθεί χωρίς σφάλματα.

## **Ορισμός Κελιού Βιβλίου Εργασίας ως Ετικέτας Δεδομένων Γραφήματος**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://apireference.aspose.com/slides/el/java/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Προσθέστε ένα γράφημα Bubble με μερικά δεδομένα.
1. Προσπελάστε τις σειρές του γραφήματος.
1. Ορίστε το κελί του βιβλίου εργασίας ως ετικέτα δεδομένων.
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας Java σας δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων γραφήματος:

```java
import com.aspose.slides.*;

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

Αυτός ο κώδικας Java επιδεικνύει μια λειτουργία όπου η μέθοδος [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) χρησιμοποιείται για πρόσβαση σε μια συλλογή φύλλων εργασίας:

```java
import com.aspose.slides.*;

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

Αυτός ο κώδικας Java σας δείχνει πώς να καθορίσετε έναν τύπο για μια πηγή δεδομένων:

```java
import com.aspose.slides.*;

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

Το Aspose.Slides δεν υποστηρίζει τη δυαδική μορφή βιβλίου εργασίας Excel (.xlsb) που μπορεί να ενσωματωθεί σε ορισμένα γραφήματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `getEmbeddedWorkbookType` στο [IChartData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/java/com.aspose.slides/WorkbookType) για να ανιχνεύσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα γραφήματα.

```java
import com.aspose.slides.*;

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

        // Διαβάστε ή τροποποιήστε εδώ τα δεδομένα του βιβλίου εργασίας του γραφήματος.
    }
} finally {
    presentation.dispose();
}
```

## **Εξωτερικό Βιβλίο Εργασίας**
{{% alert color="info" %}} 
Στο [Aspose.Slides 19.4](https://docs.aspose.com/slides/el/java/aspose-slides-for-java-19-4-release-notes/), υλοποιήσαμε υποστήριξη για εξωτερικά βιβλία εργασίας ως πηγή δεδομένων για γραφήματα.
{{% /alert %}} 

### **Δημιουργία Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τις μεθόδους **`readWorkbookStream`** και **`setExternalWorkbook`**, μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από το μηδέν είτε να κάνετε ένα εσωτερικό βιβλίο εργασίας εξωτερικό.

Αυτός ο κώδικας Java επιδεικνύει τη διαδικασία δημιουργίας εξωτερικού βιβλίου εργασίας:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

Χρησιμοποιώντας τη μέθοδο **`setExternalWorkbook`**, μπορείτε να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας σε ένα γράφημα ως την πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για ενημέρωση της διαδρομής προς το εξωτερικό βιβλίο εργασίας (εάν αυτό μετακινήθηκε).

Αν και δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας που αποθηκεύονται σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να χρησιμοποιήσετε τέτοια βιβλία ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετικά διαδρομή για ένα εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτός ο κώδικας Java σας δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

```java
import com.aspose.slides.*;

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

Η δεύτερη παράμετρος (`boolean`) της μεθόδου `setExternalWorkbook` χρησιμοποιείται για να καθορίσει εάν ένα βιβλίο εργασίας Excel θα φορτωθεί ή όχι. 

* Όταν η τιμή της οριστεί σε `false`, μόνο η διαδρομή του βιβλίου ενημερώνεται — τα δεδομένα του γραφήματος δεν θα φορτωθούν ή ενημερωθούν από το στόχο. Αυτό μπορεί να είναι χρήσιμο όταν το στοχευόμενο βιβλίο δεν υπάρχει ή δεν είναι διαθέσιμο. 
* Όταν η τιμή της οριστεί σε `true`, τα δεδομένα του γραφήματος ενημερώνονται από το στόχο.

```java
import com.aspose.slides.*;

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

### **Ανάκτηση Διαδρομής Εξωτερικής Πηγής Βιβλίου Εργασίας ενός Γραφήματος**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://apireference.aspose.com/slides/el/java/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Δημιουργήστε ένα αντικείμενο για το σχήμα του γραφήματος.
1. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής (`ChartDataSourceType`) που αντιπροσωπεύει την πηγή δεδομένων του γραφήματος.
1. Καθορίστε τη σχετική κατάσταση με βάση το αν ο τύπος πηγής είναι ίδιος με τον τύπο εξωτερικού βιβλίου εργασίας.

Αυτός ο κώδικας Java επιδεικνύει τη λειτουργία:

```java
import com.aspose.slides.*;

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

### **Επεξεργασία Δεδομένων Γραφήματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα εσωτερικών βιβλίων εργασίας. Όταν δεν είναι δυνατό το φόρτωμα ενός εξωτερικού βιβλίου εργασίας, ρίχνεται μια εξαίρεση.

Αυτός ο κώδικας Java είναι μια υλοποίηση της περιγραφόμενης διαδικασίας:

```java
import com.aspose.slides.*;

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

### **Ανάκτηση Βιβλίου Εργασίας από την Κρυφή Μνήμη του Γραφήματος**

Εάν ένα γράφημα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανασυνθέσει το βιβλίο εργασίας του γραφήματος από τα δεδομένα που έχουν αποθηκευτεί στην παρουσίαση. Δημιουργήστε [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/), ρυθμίστε το με [SpreadsheetOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/spreadsheetoptions/), και καλέστε [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) με `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα Java ανοίγει μια παρουσίαση της οποίας το γράφημα παραπέμπει σε μη διαθέσιμο εξωτερικό βιβλίο εργασίας και προσπελαύνει τα ανακτημένα δεδομένα μέσω [IChart.getChartData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichart/#getChartData--) και [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Διαβάστε ή τροποποιήστε τα δεδομένα του ανακτηθέντος βιβλίου εργασίας εδώ.
} finally {
    presentation.dispose();
}
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει μια εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των αποθηκευμένων δεδομένων γραφήματος είναι αποδεκτή εναλλακτική λύση, επειδή η κρύψη ενδέχεται να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο γράφημα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα γράφημα έχει έναν [τύπο πηγής δεδομένων](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getDataSourceType--) και μια [διαδρομή προς εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε την πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται ένα εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό είναι βολικό για τη φορητότητα του έργου· όμως, να γνωρίζετε ότι η παρουσίαση θα αποθηκεύσει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινοποιήσεις;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσίαση αποθηκεύει έναν [σύνδεσμο στο εξωτερικό αρχείο](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) και τον χρησιμοποιεί για την ανάγνωση δεδομένων. Το ίδιο το εξωτερικό αρχείο δεν τροποποιείται κατά την αποθήκευση της παρουσίασης.

**Τι πρέπει να κάνω αν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια συνηθισμένη προσέγγιση είναι η αφαίρεση της προστασίας εκ των προτέρων ή η προετοιμασία ενός αποκρυπτογραφημένου αντιγράφου (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/java/)) και η σύνδεση σε αυτό το αντίγραφο.

**Μπορούν πολλά γραφήματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε γράφημα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε γράφημα την επόμενη φορά που θα φορτωθούν τα δεδομένα.