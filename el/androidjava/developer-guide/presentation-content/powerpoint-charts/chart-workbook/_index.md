---
title: Διαχείριση Βιβλίων Εργασίας Διαγραμμάτων σε Παρουσιάσεις στο Android
linktitle: Βιβλίο Εργασίας Διαγράμματος
type: docs
weight: 70
url: /el/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Android μέσω Java: διαχειριστείτε με ευκολία τα βιβλία εργασίας διαγραμμάτων στα μορφότυπα PowerPoint και OpenDocument για να βελτιστοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Επιπλέον, καλύπτει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγών δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αντιστοιχίσετε ένα εξωτερικό βιβλίων εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που είναι συνδεδεμένο σε διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

Για κελιά βιβλίου εργασίας που αντιπροσωπεύουν ελλιπή δεδομένα, δείτε [Έλεγχος της Εμφάνισης Κενού Κελιού](/slides/el/androidjava/chart-series/) για τη διαφορά μεταξύ κενού κελιού και μηδενός, και μια σύγκριση διαγράμματος γραμμής των διαθέσιμων τρόπων εμφάνισης.

## **Συμπερίληψη Δεδομένων από Κρυμμένες Γραμμές και Στήλες**

Χρησιμοποιήστε [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) για να ελέγξετε αν ένα διάγραμμα σχεδιάζει δεδομένα από κρυμμένες γραμμές και στήλες φύλλου εργασίας. Ορίστε το σε `true` για να σχεδιαζονται μόνο τα ορατά κελιά, ή σε `false` για να συμπεριλαμβάνονται τόσο τα ορατά όσο και τα κρυμμένα κελιά. Αυτή η ρύθμιση ελέγχει την σχεδίαση του διαγράμματος· δεν κρύβει ή αποκρυπτώνει γραμμές ή στήλες του φύλλου εργασίας.

Κατεβάστε το αρχείο [hidden-source-data.pptx](hidden-source-data.pptx) και τοποθετήστε το στον τρέχοντα φάκελο εργασίας. Η πρώτη του διαφάνεια περιέχει ένα γράφημα στήλης ως το πρώτο σχήμα. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιέχει την ακόλουθη περιοχή προέλευσης, `A1:C4`. Η γραμμή 3 και η στήλη C είναι κρυμμένες, αλλά τα κελιά τους εξακολουθούν να περιέχουν τιμές.

| Worksheet row | A: Month | B: Retail | C: Wholesale (hidden column) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (hidden row) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Πρόσβαση στα κελιά προέλευσης μέσω του [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) και ανάγνωση του [IChartDataCell.isHidden](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) για να εξετάσετε την κρυφή τους κατάσταση. Αυτή η μέθοδος αναφέρει την κρυφή κατάσταση χωρίς να την αλλάξει. Σε αυτό το αρχείο, το B2 είναι ορατό, το B3 ανήκει στη κρυφή γραμμή και το C2 ανήκει στη κρυφή στήλη· το παράδειγμα εκτυπώνει `false`, `true` και `true`, αντίστοιχα.

Για αυτό το παράδειγμα, ανανεώστε τα δεδομένα του διαγράμματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε το ενσωματωμένο βιβλίο εργασίας με το [readWorkbookStream](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) και φορτώστε το ξανά με το [writeWorkbookStream](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). Όταν συμπεριλαμβάνονται όλα τα κελιά, χρησιμοποιήστε επίσης το [setRange](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) για να επαναφέρετε το πλήρες εύρος, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουάριος. Η απλή αλλαγή της σημαίας δεν αρκεί για την ανανέωση των προσωρινα αποθηκευμένων δεδομένων του διαγράμματος και των ετικετών κατηγοριών σε αυτό το δείγμα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Ανανέωση των δεδομένων του διαγράμματος από το ενσωματωμένο βιβλίο εργασίας.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Επαναφορά του πλήρους εύρους προέλευσης, συμπεριλαμβανομένων των κρυμμένων κατηγοριών.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Το παράδειγμα αποθηκεύει το `hidden_cells_true.pptx` μόνο με τις ορατές τιμές Λιανικής (10 και 20), και το `hidden_cells_false.pptx` με όλες τις έξι τιμές. Οι εικόνες παρακάτω απεικονίζουν τις δύο λειτουργίες σχεδίασης. Η γραμμή 3 και η στήλη C παραμένουν κρυμμένες και στα δύο ενσωματωμένα βιβλία εργασίας.

| Μόνο ορατά κελιά (`true`) | Όλα τα κελιά (`false`) |
| --- | --- |
| ![Μόνο ορατά κελιά: τιμές Λιανικής 10 και 20 για Ιανουάριο και Μάρτιο.](hidden_cells_True.png) | ![Όλα τα κελιά: τιμές Λιανικής και Χονδρικής για Ιανουάριο, Φεβρουάριο και Μάρτιο.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. Το [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή εξαιρεί κρυμμένα δεδομένα προέλευσης. Δείτε [Έλεγχος της Εμφάνισης Κενού Κελιού](/slides/el/androidjava/chart-series/#control-the-display-of-empty-cells) για ένα παράδειγμα.

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**

Το Aspose.Slides για Android μέσω Java παρέχει τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) και [writeWorkbookStream](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) που σας επιτρέπουν να διαβάζετε και να γράφετε βιβλία εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα του διαγράμματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή πρέπει να έχουν δομή παρόμοια με την πηγή.

Αυτό το παράδειγμα ανοίγει το `chart.pptx`, το οποίο πρέπει να περιέχει ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη του διαφάνεια. Διαβάζει το ενσωματωμένο βιβλίο εργασίας σε ένα πίνακα byte, διαγράφει τις υπάρχουσες σειρές και κατηγορίες, και γράφει πάλι το ίδιο βιβλίο εργασίας. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσίαση.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Επικύρωση Διάταξης Διαγράμματος μετά την Τροποποίηση του Βιβλίου Εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να προκαλέσει αποτυχία του [IChart.validateChartLayout](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/#validateChartLayout--) με σφάλμα index-out-of-range. Διαγράψτε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο διάγραμμα. Αυτό το παράδειγμα απαιτεί το `chart.pptx` με ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη του διαφάνεια. Το σχόλιο δηλώνει πού θα γίνει η επεξεργασία του βιβλίου εργασίας· το εκτελέσιμο παράδειγμα γράφει το αρχικό βιβλίο εργασίας πίσω και επικυρώνει τη διάταξη στη μνήμη.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Τροποποιήστε τα bytes του βιβλίου εργασίας εδώ, για παράδειγμα, χρησιμοποιώντας το Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Η εκκαθάριση των συλλογών αφαιρεί παλαιές αναφορές δεδομένων πριν το βιβλίο εργασίας γραφτεί ξανά. Ανακατασκευάστε τυχόν απαιτούμενες αντιστοιχίσεις σειρών και κατηγοριών για το ενημερωμένο βιβλίο εργασίας πριν χρησιμοποιήσετε το διάγραμμα.

## **Ορισμός Κελιού Βιβλίου Εργασίας ως Ετικέτας Δεδομένων Διαγράμματος**

Μπορείτε να χρησιμοποιήσετε κείμενο από κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος. Τα παρακάτω βήματα δείχνουν πώς να συνδέσετε τις ετικέτες σε ένα διάγραμμα φυσαλίδων με κελιά του βιβλίου δεδομένων του.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Προσπελάστε την πρώτη διαφάνεια με δείκτη μηδενικής βάσης.
3. Προσθέστε ένα διάγραμμα φυσαλίδων με προεπιλεγμένα δεδομένα.
4. Προσπελάστε τις σειρές του διαγράμματος.
5. Ορίστε το κελί του βιβλίου εργασίας ως ετικέτα δεδομένων.
6. Αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα ανοίγει το `chart2.pptx`, που πρέπει να περιέχει τουλάχιστον μία διαφάνεια, και προσθέτει ένα διάγραμμα φυσαλίδων με προεπιλεγμένα δεδομένα. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο εργασίας 0 για τις πρώτες τρεις ετικέτες στην πρώτη σειρά, ενεργοποιεί τις ετικέτες από κελιά, και αποθηκεύει το αποτέλεσμα στο `resultchart.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διαχείριση Φύλλων Εργασίας**

Η μέθοδος [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) παρέχει πρόσβαση στα φύλλα εργασίας ενός βιβλίου εργασίας διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με προεπιλεγμένα δεδομένα και εκτυπώνει το όνομα κάθε φύλλου εργασίας στην κονσόλα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Καθορισμός Τύπου Πηγής Δεδομένων**

Αυτό το παράδειγμα δημιουργεί ένα 3D γράφημα στήλης με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειρών χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί κυριολεκτικό συμβολοσειράς· το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο εργασίας 0. Η αριθμομηχανή [DataSourceType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το αποτέλεσμα αποθηκεύεται στο `pres.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εντοπισμός Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλίου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη δυαδική μορφή βιβλίου εργασίας Excel (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [getEmbeddedWorkbookType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) στο [IChartData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/) μαζί με την αριθμομηχανή [WorkbookType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα. Αυτό το παράδειγμα ελέγχει τα σχήματα στην πρώτη διαφάνεια του `sample.pptx`, παραλείπει σχήματα που δεν είναι διαγράμματα, και εκτυπώνει μηνύματα διάγνωσης για κάθε διάγραμμα με ενσωματωμένο βιβλίο εργασίας .xlsb.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Διαβάστε ή τροποποιήστε τα υποστηριζόμενα δεδομένα βιβλίου εργασίας διαγράμματος εδώ.
    }
} finally {
    presentation.dispose();
}
```

## **Εξωτερικό Βιβλίο Εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Δημιουργία Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιήστε τα [readWorkbookStream](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) και [setExternalWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) για να εξάγετε ένα ενσωματωμένο βιβλίο εργασίας διαγράμματος σε ένα αρχείο και να συνδέσετε το διάγραμμα με εκείνο το εξωτερικό βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με προεπιλεγμένα δεδομένα, γράφει το βιβλιο εργασίας του στο `externalWorkbook1.xlsx`, και ολοκληρώνει τη συγγραφή του αρχείου πριν το αντιστοιχίσει ως πηγή δεδομένων του διαγράμματος. Αποθηκεύει την συνδεδεμένη παρουσίαση στο `externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Ορισμός Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τη μέθοδο [setExternalWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), μπορείτε να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως την πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για να ενημερώσετε τη διαδρομή του εξωτερικού βιβλίου εργασίας (εάν αυτό μετακινήθηκε).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας αποθηκευμένα σε απομακρυσμένες θέσεις ή πόρους, μπορείτε ακόμη να χρησιμοποιήσετε αυτά τα βιβλία εργασίας ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτό το παράδειγμα απαιτεί το `externalWorkbook.xlsx` στον φάκελο εργασίας. Το φύλλο εργασίας του, με όνομα `Sheet1`, πρέπει να περιέχει ένα όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4 και αριθμητικές τιμές στο B2:B4. Το παράδειγμα δημιουργεί ένα γράφημα πίτας, συνδέει το βιβλίο εργασίας και χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) για να χαρτογραφήσει το A1:B4 σε μία σειρά και τρεις κατηγορίες. Αποθηκεύει το αποτέλεσμα στο `Presentation_with_externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η παράμετρος `updateChartData` της [setExternalWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) ελέγχει εάν το βιβλίο εργασίας θα φορτωθεί.

* Όταν η `updateChartData` είναι `false`, μόνο η διαδρομή του βιβλίου εργασίας ενημερώνεται. Τα δεδομένα του διαγράμματος δεν φορτώνονται ή ενημερώνονται από το στόχο βιβλίο εργασίας, έτσι ώστε το βιβλίο εργασίας να μπορεί να είναι μη διαθέσιμο.
* Όταν η `updateChartData` είναι `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το στόχο βιβλίου εργασίας.

Το ακόλουθο παράδειγμα αντιστοιχεί μια URL placeholder με `updateChartData` ορισμένη σε `false`. Διατηρεί τα προεπιλεγμένα δεδομένα του διαγράμματος πίτας και αποθηκεύει την παρουσίαση χωρίς να φορτώσει το μη διαθέσιμο βιβλίο εργασίας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ανάκτηση Διαδρομής Εξωτερικού Βιβλίου Εργασίας Πηγής Δεδομένων ενός Διαγράμματος**

Για να εντοπίσετε το βιβλίο εργασίας που συνδέεται με ένα διάγραμμα, πρώτα ελέγξτε εάν το διάγραμμα χρησιμοποιεί εξωτερική πηγή δεδομένων. Εάν ναι, μπορείτε να ανακτήσετε τη διαδρομή του βιβλίου εργασίας ακολουθώντας τα παρακάτω βήματα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Προσπελάστε την πρώτη διαφάνεια με δείκτη μηδενικής βάσης.
3. Ελέγξτε ότι το πρώτο σχήμα είναι διάγραμμα.
4. Διαβάστε τον τύπο πηγής δεδομένων του διαγράμματος.
5. Εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, διαβάστε τη διαδρομή του.

Αυτό το παράδειγμα ανοίγει το `externalWorkbook.pptx`, που δημιουργήθηκε στο προηγούμενο παράδειγμα, και ελέγχει το πρώτο σχήμα στην πρώτη διαφάνεια. Εάν είναι διάγραμμα συνδεδεμένο σε εξωτερικό βιβλίο εργασίας, το παράδειγμα εκτυπώνει το [getExternalWorkbookPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης στο `Result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Επεξεργασία Δεδομένων Διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, γίνεται εξαίρεση.

Αυτό το παράδειγμα απαιτεί το `presentation.pptx` με ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνεια και ένα προσάξιμο εξωτερικό βιβλίο εργασίας. Ορίζει την τιμή του πρώτου σημείου δεδομένων στην πρώτη σειρά σε 100 και αποθηκεύει την παρουσίαση στο `presentation_out.pptx`. Η επεξεργασία τιμών κελιών μπορεί να ενημερώσει το συνδεδεμένο εξωτερικό αρχείο XLSX, γι' αυτό χρησιμοποιήστε ένα αντίγραφο εάν χρειάζεται να διατηρήσετε το αρχικό βιβλίο εργασίας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Ανάκτηση Βιβλίου Εργασίας από την Κρυφή Μνήμη Διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να επαναχτίσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που αποθηκεύονται προσωρινά στην παρουσίαση. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/), καλέστε το [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), και ορίστε το [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) σε `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα Java ανοίγει το `presentation.pptx`, του οποίου το πρώτο σχήμα στην πρώτη διαφάνεια πρέπει να είναι ένα διάγραμμα που αναφέρεται σε μη διαθέσιμο εξωτερικό βιβλίο εργασίας, και προσπελάζει τα ανακτημένα δεδομένα μέσω των [IChart.getChartData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/#getChartData--) και [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Διαβάστε ή τροποποιήστε τα ανακτημένα δεδομένα βιβλίου εργασίας εδώ.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει μια εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων από τη κρυφή μνήμη του διαγράμματος είναι αποδεκτό εναλλακτικό, επειδή η κρυφή μνήμη μπορεί να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [data source type](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) καθώς και μια [path to an external workbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται οι σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX, έτσι ώστε η μετακίνηση του βιβλίου εργασίας να μπορεί να απαιτεί ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η άμεση επεξεργασία απομακρυσμένων βιβλίων εργασίας από το Aspose.Slides δεν υποστηρίζεται· μπορούν να χρησιμοποιηθούν μόνο ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό αρχείο XLSX όταν αποθηκεύεται η παρουσίαση;**

Η παρουσίαση αποθηκεύει ένα [link to the external file](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Η επεξεργασία των δεδομένων διαγράμματος που προέρχονται από κελιά μπορεί επίσης να ενημερώσει το συνδεδεμένο τοπικό αρχείο XLSX. Χρησιμοποιήστε ένα αντίγραφο του βιβλίου εργασίας εάν το πρωτότυπο πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό πρόσβασης;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια συνηθισμένη προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να ετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (π.χ., με το Aspose.Cells) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που τα δεδομένα φορτωθούν.