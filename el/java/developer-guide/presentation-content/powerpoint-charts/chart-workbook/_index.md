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
- ετικέτα δεδομένου
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
description: "Ανακαλύψτε το Aspose.Slides για Java: διαχειριστείτε με ευκολία τα βιβλία εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Εμφανίζει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να προβάλλετε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης τη χρήση εξωτερικών βιβλίων εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα επιδεικνύουν πώς να δημιουργήσετε και να αναθέσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που συνδέεται με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

Για κελιά βιβλίου εργασίας που αντιπροσωπεύουν ελλιπή δεδομένα, δείτε [Έλεγχος της Εμφάνισης Κενών Κυττάρων](/slides/el/java/chart-series/) για τη διαφορά μεταξύ κενής κυψέλης και μηδενός, καθώς και μια σύγκριση γραμμικού διαγράμματος των διαθέσιμων τρόπων εμφάνισης.

## **Συμπερίληψη Δεδομένων από Κρυφές Γραμμές και Στήλες**

Χρησιμοποιήστε [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) για να ελέγξετε εάν ένα διάγραμμα σχεδιάζει δεδομένα από κρυφές γραμμές και στήλες φύλλου εργασίας. Ορίστε το σε `true` για να σχεδιάζονται μόνο ορατά κελιά ή σε `false` για να συμπεριληφθούν τόσο ορατά όσο και κρυφά κελιά. Αυτή η ρύθμιση ελέγχει τη σχεδίαση του διαγράμματος· δεν κρύβει ή αποκρύβει γραμμές ή στήλες του φύλλου εργασίας.

Η [δείγμα παρουσίασης](hidden-source-data.pptx) περιέχει ένα διάγραμμα στήλης ως πρώτο σχήμα στην πρώτη διαφάνεια. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιέχει την εξής περιοχή πηγής, `A1:C4`. Η γραμμή 3 και η στήλη C είναι κρυφές, αλλά τα κελιά τους εξακολουθούν να περιέχουν τιμές.

| Γραμμή φύλλου εργασίας | A: Μήνας | B: Λιανική | C: Χονδρική (κρυφή στήλη) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (κρυφή γραμμή) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Πρόσβαση στα κελιά πηγής μέσω [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) και ανάγνωση του [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) για τον έλεγχο της κρυφής κατάστασης. Αυτή η μέθοδος αναφέρει την κρυφή κατάσταση χωρίς να την αλλάξει. Στο συγκεκριμένο αρχείο, το B2 είναι ορατό, το B3 ανήκει στην κρυφή γραμμή και το C2 στην κρυφή στήλη· το παράδειγμα εκτυπώνει `false`, `true` και `true` αντίστοιχα.

Για αυτό το παράδειγμα, ανανεώστε τα δεδομένα του διαγράμματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε το ενσωματωμένο βιβλίο εργασίας με [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) και φορτώστε το ξανά με [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Όταν συμπεριλαμβάνονται όλα τα κελιά, χρησιμοποιήστε επίσης το [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) για να αποκαταστήσετε την πλήρη περιοχή, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουαρίου. Η απλή αλλαγή της σημαίας δεν είναι επαρκής για την ανανέωση των δεδομένων του διαγράμματος και των ετικετών κατηγορίας στην κρυφή μνήμη.

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

            // Ανανεώστε τα δεδομένα του διαγράμματος από το ενσωματωμένο βιβλίο εργασίας.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Αποκαταστήστε την πλήρη περιοχή προέλευσης, συμπεριλαμβανομένων των κρυφών κατηγοριών.
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

Το παράδειγμα αποθηκεύει δύο εκδόσεις της παρουσίασης: μία με μόνο τις ορατές τιμές Λιανικής (10 και 20) και μία με όλες τις έξι τιμές. Οι εικόνες παρακάτω απεικονίζουν τις δύο λειτουργίες σχεδίασης. Η γραμμή 3 και η στήλη C παραμένουν κρυφές και στα δύο ενσωματωμένα βιβλία εργασίας.

| Μόνο ορατά κελιά (`true`) | Όλα τα κελιά (`false`) |
| --- | --- |
| ![Μόνο ορατά κελιά: τιμές Λιανικής 10 και 20 για Ιανουάριο και Μάρτιο.](hidden_cells_True.png) | ![Όλα τα κελιά: τιμές Λιανικής και Χονδρικής για Ιανουάριο, Φεβρουάριο και Μάρτιο.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. Το [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή εξαιρεί κρυφά δεδομένα πηγής. Δείτε ξανά το [Έλεγχος της Εμφάνισης Κενών Κυττάρων](/slides/el/java/chart-series/#control-the-display-of-empty-cells) για ένα παράδειγμα.

## **Ανάκτηση της Περιοχής Δεδομένων ενός Διαγράμματος**

Πριν ενημερώσετε τα δεδομένα του βιβλίου εργασίας σε μια υπάρχουσα παρουσίαση, ελέγξτε τις περιοχές πηγής για να εντοπίσετε ποια κελιά φύλλου εργασίας χρησιμοποιεί κάθε διάγραμμα. Η μέθοδος [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) επιστρέφει την τρέχουσα περιοχή δεδομένων ως τύπο τύπου φύλλου εργασίας, π.χ. `Sheet1!$A$1:$D$5`. Εδώ, το `Sheet1` είναι το όνομα του φύλλου, το `!` το χωρίζει από την περιοχή κυττάρων και το `$A$1:$D$5` δηλώνει τα κελιά A1 μέχρι D5, συμπεριλαμβανομένων. Τα σύμβολα δολαρίου υποδεικνύουν απόλυτες αναφορές σε γραμμή και στήλη.

Η μέθοδος διαβάζει την τρέχουσα περιοχή χωρίς να αλλάξει το διάγραμμα ή το βιβλίο εργασίας του. Εάν το διάγραμμα δεν χρησιμοποιεί βιβλίο εργασίας ως πηγή δεδομένων, τοποθετεί `InvalidOperationException`. Για περισσότερες πληροφορίες, δείτε την [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/).

Αυτό το παράδειγμα ανοίγει μια παρουσίαση και ελέγχει τα σχήματα απευθείας σε κάθε διαφάνεια για διαγράμματα. Εκτυπώνει το όνομα κάθε διαγράμματος και την περιοχή πηγής του. Εάν ένα διάγραμμα δεν χρησιμοποιεί βιβλίο εργασίας, εκτυπώνει ένα μήνυμα και προχωρά στο επόμενο διάγραμμα.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**

Το Aspose.Slides for Java παρέχει τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) και [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) που επιτρέπουν την ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα του διαγράμματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν παρόμοια δομή με την πηγή.

Αυτό το παράδειγμα χρησιμοποιεί μια παρουσίαση με ένα διάγραμμα ως πρώτο σχήμα στην πρώτη διαφάνεια. Διαβάζει το ενσωματωμένο βιβλίο εργασίας σε έναν πίνακα byte, διακαθαρίζει τις υπάρχουσες σειρά και κατηγορίες και γράφει ξανά το ίδιο βιβλίο εργασίας. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσίαση.

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

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές συλλογές σειράς και κατηγοριών. Αυτή η ασυμφωνία μπορεί να κάνει το [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) να αποτύχει με σφάλμα “index‑out‑of‑range”. Διακαθαρίστε τις υπάρχουσες σειρά και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο διάγραμμα. Αυτό το παράδειγμα χρησιμοποιεί ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια. Το σχόλιο δείχνει πού θα γινόταν η επεξεργασία του βιβλίου εργασίας· το εκτελέσιμο παράδειγμα γράφει το αρχικό βιβλίο εργασίας πίσω και επικυρώνει τη διάταξη στη μνήμη.

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

        // Τροποποιήστε τα byte του βιβλίου εργασίας εδώ, για παράδειγμα, χρησιμοποιώντας το Aspose.Cells.

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

Η διαγραφή των συλλογών αφαιρεί παλαιές αναφορές δεδομένων πριν το βιβλίο εργασίας γραφτεί πίσω. Ανακατασκευάστε τυχόν απαιτούμενες αντιστοιχίσεις σειράς και κατηγορίας για το ενημερωμένο βιβλίο εργασίας πριν χρησιμοποιήσετε το διάγραμμα.

## **Ορισμός Προσαρμοσμένων Μορφών Αριθμών για Κελιά Βιβλίου Εργασίας**

Χρησιμοποιήστε [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) για να ελέγξετε πώς εμφανίζονται οι αριθμητικές τιμές σε ένα ενσωματωμένο βιβλίο εργασίας διαγράμματος. Για παράδειγμα, μια αναφορά μπορεί να χρειάζεται να εμφανίζει το ποσοστό μετατροπής ως ποσοστό με τέσσερα δεκαδικά ψηφία και έναν συντελεστή με πέντε δεκαδικά ψηφία. Κρατήστε και τις δύο τιμές αριθμητικές ώστε να παραμένουν διαθέσιμες για υπολογισμούς και σχεδίαση διαγράμματος.

Μια μορφή αριθμού αλλάζει μόνο την εμφάνιση, όχι την αποθηκευμένη τιμή. Η μορφή `0.0000%` εμφανίζει το `0.125` ως `12.5000%`; δεν αντικαθιστά τον αποθηκευμένο αριθμό με `12.5`. Ανάλογα, το `0.00000` εμφανίζει το `0.1234567` ως `0.12346` χωρίς στρογγυλοποίηση της αποθηκευμένης τιμής. Εάν η προσαρμοσμένη μορφή είναι κενή συμβολοσειρά (`""`), χρησιμοποιείται η μορφή που επιστρέφει το [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--).

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα στήλης και προσπελαύνει τα κελιά του μέσω [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--). Στο φύλλο 0, το B2 περιέχει το ποσοστό μετατροπής και το C2 το συντελεστή. Και τα δύο κελιά τροφοδοτούν τιμές διαγράμματος. Το παράδειγμα ενεργοποιεί επίσης ετικέτες τιμών συνδεδεμένες με τις μορφές πηγής.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Οι μορφές κελιών βιβλίου εργασίας είναι ξεχωριστές από τις μορφές που ορίζονται απευθείας σε άξονες ή ετικέτες δεδομένων διαγράμματος. Σε αυτό το παράδειγμα, κάθε ετικέτα εμφανίζει την τιμή του κελιού πηγής επειδή το [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) είναι `true`, και ακολουθεί τη μορφή αριθμού πηγής επειδή το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) είναι `true`. Μετά την αποθήκευση και ξανά το άνοιγμα της παρουσίασης, οι ετικέτες εμφανίζουν `12.5000%` και `0.12346`, όπως φαίνεται παρακάτω. Ο κατακόρυφος άξονας χρησιμοποιεί τη δική του μορφή αριθμού, ορισμένη με [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) ως `0.00`, με το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) ορισμένο σε `false`.

Για ανεξάρτητη μορφοποίηση ετικέτας δεδομένων, ορίστε τη σημαία σύνδεσης πηγής σε `false` και αναθέστε μια μορφή με [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Αυτό δεν αλλάζει τη μορφή του κελιού βιβλίου εργασίας. Για παράδειγμα, μια ανεξάρτητη μορφή ετικέτας `0.00` εμφανίζει την πρώτη τιμή ως `0.13`, ενώ το B2 εξακολουθεί να εμφανίζει `12.5000%`. Δείτε το [Chart Data Labels](/slides/el/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) για άμεση μορφοποίηση ετικετών.

Η παρακάτω εικόνα προέκυψε από την αποθηκευμένη παρουσίαση μετά το άνοιγμά της:

![Διάγραμμα στήλης με ετικέτες συνδεδεμένες στην πηγή που εμφανίζουν 12.5000% και 0.12346 και έναν ανεξάρτητα μορφοποιημένο αριθμητικό άξονα.](custom-cell-formats.png)

## **Ορισμός Κελίου Βιβλίου Εργασίας ως Ετικέτας Δεδομένων Διαγράμματος**

Μπορείτε να χρησιμοποιήσετε το κείμενο από κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος.

Αυτό το παράδειγμα προσθέτει ένα διάγραμμα φυσαλίδων με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο 0 για τις τρεις πρώτες ετικέτες της πρώτης σειράς, ενεργοποιεί ετικέτες από κελιά και αποθηκεύει την ενημερωμένη παρουσίαση.

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

Η μέθοδος [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) παρέχει πρόσβαση στα φύλλα εργασίας ενός βιβλίου εργασίας διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα πίτας με προεπιλεγμένα δεδομένα και εκτυπώνει το όνομα κάθε φύλλου εργασίας στην κονσόλα.

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

Οι τιμές σημείων σειράς μπορούν επίσης να αποθηκευτούν απευθείας ως αριθμητικά literals. Δείτε το [Set Series Values Using Numeric Literals](/slides/el/java/chart-series/#set-series-values-using-numeric-literals) για ένα πλήρες παράδειγμα που τα αποθηκεύει και τα διαβάζει. Ο τύπος πηγής των τιμών είναι ξεχωριστός από τη διαμόρφωση εσωτερικού ή εξωτερικού βιβλίου εργασίας του διαγράμματος· η χρήση αριθμητικών literals από μόνα τους δεν αφαιρεί το ενσωματωμένο βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα 3D διάγραμμα στήλης με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειράς χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί string literal· το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο 0. Η αρίθμηση [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το παράδειγμα αποθηκεύει την παρουσίαση με τα ενημερωμένα ονόματα σειράς.

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

## **Ανίχνευση Μη Υποστηριζόμενων Μορφών Ενσωματωμένου Βιβλίου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη μορφή βιβλίου εργασίας Excel binary (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) στο [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) μαζί με την αρίθμηση [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα. Αυτό το παράδειγμα ελέγχει τα σχήματα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης, παραλείπει μη‑διάγραμμα σχήματα και εκτυπώνει διαγνωστικό μήνυμα για κάθε διάγραμμα με ενσωματωμένο βιβλίο εργασίας .xlsb.

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

Χρησιμοποιήστε το [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) και το [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) για να εξάγετε ένα ενσωματωμένο βιβλίο εργασίας διαγράμματος σε αρχείο και να συνδέσετε το διάγραμμα με αυτό το εξωτερικό βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα πίτας με προεπιλεγμένα δεδομένα και εξάγει το βιβλίο εργασίας του. Ολοκληρώνει την εγγραφή του αρχείου πριν αναθέσει το εξωτερικό βιβλίο εργασίας ως πηγή δεδομένων διαγράμματος, έπειτα αποθηκεύει την συνδεδεμένη παρουσίαση.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Ορισμός Εξωτερικού Βιβλίου Εργασίας**

Με τη μέθοδο [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) μπορείτε να αναθέσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων. Η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για ενημέρωση της διαδρομής προς το εξωτερικό βιβλίο εργασίας (αν το αρχείο έχει μετακινηθεί).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας αποθηκευμένα σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να τα χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για το εξωτερικό βιβλίο εργασίας, μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτό το παράδειγμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας του οποίου το φύλλο με όνομα `Sheet1` περιέχει όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4 και αριθμητικές τιμές στο B2:B4. Το παράδειγμα δημιουργεί ένα διάγραμμα πίτας, συνδέει το βιβλίο εργασίας και χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) για να αντιστοιχίσει το A1:B4 σε μία σειρά και τρεις κατηγορίες. Αποθηκεύει την παρουσίαση με το συνδεδεμένο διάγραμμα.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η παράμετρος `updateChartData` της [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) ελέγχει εάν το βιβλίο εργασίας θα φορτωθεί.

* Όταν `updateChartData` είναι `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας. Τα δεδομένα του διαγράμματος δεν φορτώνονται ή ενημερώνονται από το στόχο, επομένως το βιβλίο εργασίας μπορεί να είναι μη διαθέσιμο.
* Όταν `updateChartData` είναι `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το στόχο.

Το επόμενο παράδειγμα ορίζει μια εικονική διεύθυνση URL με `updateChartData` σε `false`. Διατηρεί τα προεπιλεγμένα δεδομένα του διαγράμματος πίτας και αποθηκεύει την παρουσίαση χωρίς να φορτώσει το μη διαθέσιμο βιβλίο εργασίας.

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

### **Λήψη της Διαδρομής του Εξωτερικού Πηγαίου Βιβλίου Εργασίας ενός Διαγράμματος**

Για να εντοπίσετε το βιβλίο εργασίας που συνδέεται με ένα διάγραμμα, ελέγξτε εάν το διάγραμμα χρησιμοποιεί εξωτερική πηγή δεδομένων και ανακτήστε τη διαδρομή του βιβλίου εργασίας.

Αυτό το παράδειγμα ελέγχει το πρώτο σχήμα στην πρώτη διαφάνεια μιας παρουσίασης με εξωτερικό βιβλίο εργασίας συνδεδεμένο. Εάν είναι διάγραμμα συνδεδεμένο με εξωτερικό βιβλίο εργασίας, το παράδειγμα εκτυπώνει το [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης.

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

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στο περιεχόμενο εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, προβάλλεται εξαίρεση.

Αυτό το παράδειγμα χρησιμοποιεί ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και είναι συνδεδεμένο με ένα προσβάσιμο εξωτερικό βιβλίο εργασίας. Ορίζει την τιμή του πρώτου σημείου δεδομένων στην πρώτη σειρά σε 100 και αποθηκεύει την ενημερωμένη παρουσίαση. Η επεξεργασία τιμών κελιών μπορεί να ενημερώσει το συνδεδεμένο εξωτερικό αρχείο XLSX, γι’ αυτό χρησιμοποιήστε αντίγραφο εάν πρέπει να διατηρήσετε το αρχικό βιβλίο εργασίας.

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

### **Ανάκτηση Βιβλίου Εργασίας από την Cache του Διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανασυνθέσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που είναι αποθηκευμένα στην cache της παρουσίασης. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), καλέστε το [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), και ορίστε το [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) σε `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα Java ανακτά δεδομένα βιβλίου εργασίας για ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και αναφέρεται σε μη διαθέσιμο εξωτερικό βιβλίο εργασίας. Πρόσβαση στα ανακτημένα δεδομένα μέσω [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) και [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Διαβάστε ή τροποποιήστε τα δεδομένα του ανακτημένου βιβλίου εργασίας εδώ.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Εάν το εξωτερικό βιβλίο εργασίας είναι μη διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων της cache του διαγράμματος είναι αποδεκτή εναλλακτική λύση, επειδή η cache ενδέχεται να μην περιλαμβάνει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) και μια [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε την πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν ορίσετε σχετική διαδρομή, μετατρέπεται αυτόματα σε απόλυτη. Η παρουσίαση αποθηκεύει τη διαδρομή στο αρχείο PPTX, επομένως η μετακίνηση του βιβλίου εργασίας μπορεί να απαιτήσει ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας τοποθετημένα σε δικτυακούς πόρους/μοιρασμένες μονάδες;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η άμεση επεξεργασία απομακρυσμένων βιβλίων εργασίας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Η επεξεργασία των τιμών που προέρχονται από κελιά μπορεί επίσης να ενημερώσει το συνδεδεμένο τοπικό αρχείο XLSX. Χρησιμοποιήστε αντίγραφο του βιβλίου εργασίας εάν το αρχικό πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο προστατεύεται με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Συνήθη πρακτική είναι η αφαίρεση της προστασίας εκ των προτέρων ή η δημιουργία ενός αποκρυπτογραφημένου αντιγράφου (π.χ., με το [Aspose.Cells](https://reference.aspose.com/cells/java/)) και η σύνδεση σε αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που θα φορτωθούν τα δεδομένα.