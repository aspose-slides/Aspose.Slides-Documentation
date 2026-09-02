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
- κρυφή μνήμη διαγράμματος
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Java: διαχειριστείτε άψογα βιβλία εργασίας διαγράμματος σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να προσπελάζετε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Επίσης καλύπτει την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αναθέσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που έχει συνδεθεί με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**
Aspose.Slides παρέχει τις μεθόδους [ReadWorkbookStream](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData#readWorkbookStream--) και [WriteWorkbookStream](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) που επιτρέπουν την ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα του διαγράμματος πρέπει να οργανωθούν με τον ίδιο τρόπο ή να έχουν μια δομή παρόμοια με αυτή της πηγής.

Αυτός ο κώδικας Java δείχνει μια ενδεικτική λειτουργία:

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

### **Επικύρωση Διάταξης Διαγράμματος μετά την Τροποποίηση του Βιβλίου Εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυνέπεια μπορεί να προκαλέσει το `chart.validateChartLayout()` να ρίξει ένα `ArgumentOutOfRangeException` (παράμετρος: index). Για να αποφύγετε την εξαίρεση, εκκαθαρίστε τις υπάρχουσες σειρές και κατηγορίες **πριν** γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο διάγραμμα.

```java
// Μετά την τροποποίηση της ροής βιβλίου εργασίας (π.χ., χρησιμοποιώντας Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Διαγραφή υπαρχόντων αναφορών δεδομένων.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// Εγγραφή του ενημερωμένου βιβλίου εργασίας πίσω στο διάγραμμα.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// Τώρα η επικύρωση επιτυγχάνει.
chart.validateChartLayout();
```

Η εκκαθάριση των συλλογών εξασφαλίζει ότι η δομή των δεδομένων του διαγράμματος ευθυγραμμίζεται με το νέο βιβλίο εργασίας, επιτρέποντας στο `validateChartLayout()` να ολοκληρωθεί χωρίς σφάλματα.

## **Ορισμός Κελιού Βιβλίου Εργασίας ως Ετικέτας Δεδομένων Διαγράμματος**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://apireference.aspose.com/slides/el/java/com.aspose.slides/presentation) .
2. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα Bubble με κάποια δεδομένα.
4. Προσπελάστε τις σειρές του διαγράμματος.
5. Ορίστε το κελί του βιβλίου εργασίας ως ετικέτα δεδομένων.
6. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων διαγράμματος:

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

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

Αυτός ο κώδικας Java δείχνει μια λειτουργία όπου η μέθοδος [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) χρησιμοποιείται για την πρόσβαση σε μια συλλογή φύλλων εργασίας:

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

Αυτός ο κώδικας Java δείχνει πώς να καθορίσετε έναν τύπο για την πηγή δεδομένων:

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

Το Aspose.Slides δεν υποστηρίζει τη δυαδική μορφή βιβλίου εργασίας Excel (.xlsb) που μπορεί να ενσωματωθεί σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `getEmbeddedWorkbookType` στο [IChartData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartData) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/java/com.aspose.slides/WorkbookType) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα.

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
            // Το ενσωματωμένο βιβλίο εργασίας είναι μορφής .xlsb, η οποία δεν υποστηρίζεται.
            continue;
        }

        // Διαβάστε ή τροποποιήστε τα δεδομένα του βιβλίου εργασίας του διαγράμματος εδώ.
    }
} finally {
    presentation.dispose();
}
```

## **Εξωτερικό Βιβλίο Εργασίας**

{{% alert color="info" %}} 
Στο [Aspose.Slides 19.4](https://docs.aspose.com/slides/el/java/aspose-slides-for-java-19-4-release-notes/), υλοποιήσαμε υποστήριξη για εξωτερικά βιβλία εργασίας ως πηγή δεδομένων για διαγράμματα.
{{% /alert %}} 

### **Δημιουργία Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τις μεθόδους **`readWorkbookStream`** και **`setExternalWorkbook`**, μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από το μηδέν είτε να κάνετε ένα εσωτερικό βιβλίο εργασίας εξωτερικό.

Αυτός ο κώδικας Java δείχνει τη διαδικασία δημιουργίας εξωτερικού βιβλίου εργασίας:

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

Χρησιμοποιώντας τη μέθοδο **`setExternalWorkbook`**, μπορείτε να αναθέσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Η μέθοδος αυτή μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση μιας διαδρομής προς το εξωτερικό βιβλίο εργασίας (εάν το τελευταίο έχει μετακινηθεί).

Παρόλο που δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας αποθηκευμένα σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να χρησιμοποιήσετε τέτοια βιβλία ως εξωτερική πηγή δεδομένων. Εάν παρέχεται η σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

```java
import com.aspose.slides.*;

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
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

Η δεύτερη (boolean) παράμετρος της μεθόδου `setExternalWorkbook` χρησιμοποιείται για να καθοριστεί εάν θα φορτωθεί ή όχι ένα βιβλίο εργασίας Excel.

* Όταν η τιμή της οριστεί σε `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας — τα δεδομένα του διαγράμματος δεν θα φορτωθούν ή ενημερωθούν από το στοχευόμενο βιβλίο εργασίας. Αυτό μπορεί να είναι χρήσιμο όταν το στοχευόμενο βιβλίο εργασίας δεν υπάρχει ή δεν είναι προσβάσιμο.
* Όταν η τιμή της οριστεί σε `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το στοχευόμενο βιβλίο εργασίας.

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

### **Ανάκτηση Διαδρομής Εξωτερικής Πηγής Δεδομένων Βιβλίου Εργασίας ενός Διαγράμματος**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://apireference.aspose.com/slides/el/java/com.aspose.slides/presentation) .
2. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της.
3. Δημιουργήστε ένα αντικείμενο για το σχήμα του διαγράμματος.
4. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής (`ChartDataSourceType`) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
5. Καθορίστε την σχετική συνθήκη βάσει του τύπου πηγής που είναι ίδιος με τον τύπο πηγής εξωτερικού βιβλίου εργασίας.

Αυτός ο κώδικας Java δείχνει τη λειτουργία:

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

### **Επεξεργασία Δεδομένων Διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, ρίχνεται μια εξαίρεση.

Αυτός ο κώδικας Java υλοποιεί τη διαδικασία που περιγράφεται:

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

### **Ανάκτηση Βιβλίου Εργασίας από την Κρυφή Μνήμη Διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανακατασκευάσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που είναι αποθηκευμένα στην κρυφή μνήμη της παρουσίασης. Δημιουργήστε ένα αντικείμενο [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/), ρυθμίστε το με [SpreadsheetOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/spreadsheetoptions/), και καλέστε την μέθοδο [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) με `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα Java ανοίγει μια παρουσίαση της οποίας το διάγραμμα αναφέρεται σε ένα μη διαθέσιμο εξωτερικό βιβλίο εργασίας και προσπελάζει τα ανακτημένα δεδομένα μέσω των μεθόδων [IChart.getChartData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichart/#getChartData--) και [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Διαβάστε ή τροποποιήστε τα δεδομένα του ανακτημένου βιβλίου εργασίας εδώ.
} finally {
    presentation.dispose();
}
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει μια εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων από την κρυφή μνήμη αποτελεί αποδεκτή εναλλακτική, καθώς η κρυφή μνήμη μπορεί να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [τύπο πηγής δεδομένων](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getDataSourceType--) και μια [διαδρομή σε εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό είναι βολικό για φορητότητα του έργου· όμως η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η άμεση επεξεργασία απομακρυσμένων βιβλίων εργασίας από το Aspose.Slides δεν υποστηρίζεται· μπορούν να χρησιμοποιηθούν μόνο ως πηγή.

**Αν το Aspose.Slides αποθηκεύει την παρουσίαση, αντικαθιστά το εξωτερικό XLSX;**

Όχι. Η παρουσίαση αποθηκεύει έναν [σύνδεσμο προς το εξωτερικό αρχείο](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) και το χρησιμοποιεί για ανάγνωση δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται κατά την αποθήκευση της παρουσίασης.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια κοινή προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/java/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντανακλάται σε κάθε διάγραμμα την επόμενη φορά που θα φορτωθούν τα δεδομένα.