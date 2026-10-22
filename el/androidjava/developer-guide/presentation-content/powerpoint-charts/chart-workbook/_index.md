---
title: Διαχείριση βιβλίων εργασίας διαγράμματος σε παρουσιάσεις σε Android
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
- προσωρινή μνήμη διαγράμματος
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Android μέσω Java: διαχειριστείτε εύκολα βιβλία εργασίας διαγράμματος σε μορφές PowerPoint και OpenDocument για να απλοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίων εργασίας, να χρησιμοποιείτε τα κελιά του βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να αποκτάτε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα επιδεικνύουν πώς να δημιουργήσετε και να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που είναι συνδεδεμένο με ένα γράφημα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

Για κελιά βιβλίου εργασίας που αντιπροσωπεύουν ελλιπή δεδομένα, δείτε [Έλεγχος της εμφάνισης των κενών κελιών](/slides/el/androidjava/chart-series/) για τη διαφορά μεταξύ κενών κελιών και μηδενικού, καθώς και για σύγκριση γραμμικού διαγράμματος των διαθέσιμων τρόπων εμφάνισης.

## **Συμπερίληψη δεδομένων από κρυφές γραμμές και στήλες**

Χρησιμοποιήστε [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) για να ελέγξετε εάν το γράφημα σχεδιάζει δεδομένα από κρυφές γραμμές και στήλες φύλλου εργασίας. Ορίστε το σε `true` για να σχεδιάζονται μόνο τα ορατά κελιά ή σε `false` για να συμπεριλαμβάνονται τόσο τα ορατά όσο και τα κρυφά κελιά. Αυτή η ρύθμιση ελέγχει την απόδοση του διαγράμματος· δεν κρύβει ή αποκρύβει γραμμές ή στήλες του φύλλου εργασίας.

Η [παράδειγμα παρουσίαση](hidden-source-data.pptx) περιέχει ένα γράφημα στήλης ως το πρώτο σχήμα στην πρώτη της διαφάνεια. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιέχει την παρακάτω περιοχή πηγής, `A1:C4`. Η γραμμή 3 και η στήλη C είναι κρυφές, αλλά τα κελιά τους εξακολουθούν να περιέχουν τιμές.

| Γραμμή φύλλου εργασίας | A: Μήνας | B: Λιανική | C: Χονδρική (κρυφή στήλη) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (κρυφή γραμμή) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Πρόσβαση στα κελιά πηγής μέσω [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) και ανάγνωση του [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) για να ελέγξετε την κρυφή τους κατάσταση. Αυτή η μέθοδος αναφέρει την κρυφή κατάσταση χωρίς να την αλλάξει. Σε αυτό το αρχείο, το B2 είναι ορατό, το B3 ανήκει στην κρυφή γραμμή και το C2 ανήκει στην κρυφή στήλη· το παράδειγμα εκτυπώνει `false`, `true` και `true` αντίστοιχα.

Για αυτό το παράδειγμα, ανανεώστε τα δεδομένα του διαγράμματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε το ενσωματωμένο βιβλίο εργασίας με [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) και φορτώστε το ξανά με [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Όταν συμπεριλαμβάνονται όλα τα κελιά, χρησιμοποιήστε επίσης το [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) για να επαναφέρετε την πλήρη περιοχή, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουαρίου. Η απλή αλλαγή της σημαίας δεν επαρκεί για την ανανέωση των δεδομένων του διαγράμματος που είναι στην κρύπτη και των ετικετών κατηγοριών σε αυτό το παράδειγμα.

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
                // Επαναφορά της πλήρους περιοχής πηγής, συμπεριλαμβανομένων των κρυφών κατηγοριών.
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

Το παράδειγμα αποθηκεύει δύο εκδόσεις της παρουσίασης: μία μόνο με τις ορατές τιμές Λιανικής (10 και 20) και μία άλλη με όλες τις έξι τιμές. Οι παρακάτω εικόνες απεικονίζουν τις δύο λειτουργίες σχεδίασης. Η γραμμή 3 και η στήλη C παραμένουν κρυφές και στα δύο ενσωματωμένα βιβλία εργασίας.

| Μόνο ορατά κελιά (`true`) | Όλα τα κελιά (`false`) |
| --- | --- |
| ![Μόνο ορατά κελιά: τιμές λιανικής 10 και 20 για Ιανουάριο και Μάρτιο.](hidden_cells_True.png) | ![Όλα τα κελιά: τιμές λιανικής και χονδρικής για Ιανουάριο, Φεβρουάριο και Μάρτιο.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. Το [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή εξαιρεί κρυφά δεδομένα πηγής. Δείτε [Έλεγχος της εμφάνισης των κενών κελιών](/slides/el/androidjava/chart-series/#control-the-display-of-empty-cells) για παράδειγμα.

## **Ανάκτηση περιοχής δεδομένων γραφήματος**

Πριν ενημερώσετε τα δεδομένα του βιβλίου εργασίας σε μια υπάρχουσα παρουσίαση, ελέγξτε τις περιοχές πηγής για να προσδιορίσετε ποια κελιά φύλλου εργασίας χρησιμοποιεί κάθε γράφημα. Η μέθοδος [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) επιστρέφει την τρέχουσα περιοχή δεδομένων ως τύπο που αναγνωρίζεται από το φύλλο, π.χ. `Sheet1!$A$1:$D$5`. Εδώ, το `Sheet1` είναι το όνομα του φύλλου, το `!` το διαχωρίζει από την περιοχή κελιών και το `$A$1:$D$5` προσδιορίζει τα κελιά A1 έως D5, συμπεριλαμβανομένων. Τα σύμβολα δολαρίου υποδεικνύουν απόλυτες αναφορές γραμμής και στήλης.

Η μέθοδος διαβάζει την τρέχουσα περιοχή χωρίς να αλλάζει το γράφημα ή το βιβλίο εργασίας του. Εάν το γράφημα δεν χρησιμοποιεί βιβλίο εργασίας ως πηγή δεδομένων, ρίχνει `InvalidOperationException`. Για περισσότερες πληροφορίες, δείτε την [Αναφορά API ChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Αυτό το παράδειγμα ανοίγει μια παρουσίαση και ελέγχει τα σχήματα απευθείας σε κάθε διαφάνεια για γραφήματα. Εκτυπώνει το όνομα κάθε γραφήματος και την περιοχή πηγής του. Εάν ένα γράφημα δεν χρησιμοποιεί βιβλίο εργασίας, εκτυπώνει ένα μήνυμα και συνεχίζει στο επόμενο γράφημα.

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

## **Ανάγνωση και εγγραφή δεδομένων γραφήματος από βιβλίο εργασίας**

Το Aspose.Slides for Android via Java παρέχει τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) και [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) που επιτρέπουν την ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων γραφήματος (περιέχοντα δεδομένα γραφήματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα του γραφήματος πρέπει να οργανωθούν με τον ίδιο τρόπο ή να έχουν μια δομή παρόμοια με την πηγή.

Αυτό το παράδειγμα χρησιμοποιεί μια παρουσίαση με ένα γράφημα ως πρώτο σχήμα στην πρώτη της διαφάνεια. Διαβάζει το ενσωματωμένο βιβλίο εργασίας σε έναν πίνακα byte, διαγράφει τις υπάρχουσες σειρές και κατηγορίες και γράφει το ίδιο βιβλίο εργασίας πίσω. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσίαση.

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

### **Επικύρωση διάταξης γραφήματος μετά την τροποποίηση του βιβλίου εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το γράφημα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να προκαλέσει αποτυχία του [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) με σφάλμα ευρετηρίου εκτός περιοχής. Διαγράψτε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο γράφημα. Το παράδειγμα χρησιμοποιεί ένα γράφημα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια. Το σχόλιο υποδεικνύει πού θα γίνει η επεξεργασία του βιβλίου εργασίας· η εκτελέσιμη εκδοχή γράφει το αρχικό βιβλίο εργασίας πίσω και επικυρώνει τη διάταξη στη μνήμη.

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

Η εκκαθάριση των συλλογών αφαιρεί παλιές αναφορές δεδομένων πριν το βιβλίο εργασίας γραφτεί πίσω. Ανακατασκευάστε τυχόν απαιτούμενες αντιστοιχίσεις σειρών και κατηγοριών για το ενημερωμένο βιβλίο εργασίας πριν χρησιμοποιήσετε το γράφημα.

## **Ορισμός προσαρμοσμένων μορφών αριθμών για κελιά βιβλίου εργασίας**

Χρησιμοποιήστε το [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) για να ελέγξετε πώς εμφανίζονται αριθμητικές τιμές σε ένα βιβλίο εργασίας που είναι ενσωματωμένο στο γράφημα. Για παράδειγμα, μια αναφορά μπορεί να χρειάζεται να εμφανίζει ένα ποσοστό μετατροπής ως ποσοστό με τέσσερα δεκαδικά ψηφία και έναν συντελεστή με πέντε δεκαδικά ψηφία. Κρατήστε και τις δύο τιμές αριθμητικές ώστε να παραμένουν διαθέσιμες για υπολογισμούς και σχεδίαση διαγράμματος.

Μία μορφή αριθμού αλλάζει την εμφάνιση, όχι την αποθηκευμένη τιμή. Η μορφή `0.0000%` εμφανίζει το `0.125` ως `12.5000%`; δεν αντικαθιστά τον αποθηκευμένο αριθμό με `12.5`. Ομοίως, η μορφή `0.00000` εμφανίζει το `0.1234567` ως `0.12346` χωρίς στρογγυλοποίηση της αποθηκευμένης τιμής. Εάν η προσαρμοσμένη μορφή είναι κενή συμβολοσειρά (`""`), χρησιμοποιείται η μορφή που επιστρέφει το [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--).

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα στήλης και προσπελαύνει τα κελιά του μέσω του [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--). Στο φύλλο εργασίας 0, το B2 περιέχει το ποσοστό μετατροπής και το C2 περιέχει τον συντελεστή. Και τα δύο κελιά τροφοδοτούν τις τιμές του διαγράμματος. Το παράδειγμα ενεργοποιεί επίσης ετικέτες τιμών που είναι συνδεδεμένες με τις μορφές πηγής.

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

Οι μορφές κελιών του βιβλίου εργασίας είναι ξεχωριστές από τις μορφές που ορίζονται απευθείας στους άξονες του διαγράμματος ή στις ετικέτες δεδομένων. Σε αυτό το παράδειγμα, κάθε ετικέτα εμφανίζει την τιμή του κελιού πηγής επειδή το [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) είναι ορισμένο σε `true`, και ακολουθεί τη μορφή αριθμού πηγής επειδή το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) είναι ορισμένο σε `true`. Μετά την αποθήκευση και επαναφόρτωση της παρουσίασης, οι ετικέτες εμφανίζουν `12.5000%` και `0.12346`, όπως φαίνεται παρακάτω. Ο κάθετος άξονας χρησιμοποιεί τη δική του μορφή αριθμού, ορισμένη με το [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) ως `0.00`, με το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) ορισμένο σε `false`.

Για να μορφοποιήσετε ανεξάρτητα μια ετικέτα δεδομένων, ορίστε τη σημαία σύνδεσης πηγής σε `false` και ορίστε μια μορφή με το [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Αυτό δεν αλλάζει τη μορφή του κελιού του βιβλίου εργασίας. Για παράδειγμα, μια ανεξάρτητη μορφή ετικέτας `0.00` εμφανίζει την πρώτη τιμή ως `0.13`, ενώ το B2 εξακολουθεί να εμφανίζει `12.5000%`. Δείτε την ενότητα [Chart Data Labels](/slides/el/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) για άμεση μορφοποίηση ετικετών.

Η εικόνα παρακάτω δημιουργήθηκε από την αποθηκευμένη παρουσίαση μετά την επαναφόρτωση της:

![Διαγράμμιση στήλης με ετικέτες συνδεδεμένες με την πηγή που εμφανίζουν 12.5000% και 0.12346 και αριθμητικό άξονα μορφοποιημένο ανεξάρτητα.](custom-cell-formats.png)

## **Ορισμός κελιού βιβλίου εργασίας ως ετικέτας δεδομένων γραφήματος**

Μπορείτε να χρησιμοποιήσετε κείμενο από κελιά βιβλίου εργασίας ως ετικέτες δεδομένων γραφήματος.

Αυτό το παράδειγμα προσθέτει ένα γράφημα φυσαλίδων με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο εργασίας 0 για τις τρεις πρώτες ετικέτες της πρώτης σειράς, ενεργοποιεί ετικέτες από κελιά και αποθηκεύει την ενημερωμένη παρουσίαση.

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

## **Διαχείριση φύλλων εργασίας**

Η μέθοδος [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) παρέχει πρόσβαση στα φύλλα εργασίας ενός βιβλίου εργασίας διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με προεπιλεγμένα δεδομένα και εκτυπώνει το όνομα κάθε φύλλου εργασίας στην κονσόλα.

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

## **Καθορισμός τύπου πηγής δεδομένων**

Οι τιμές σημείων σειράς μπορούν επίσης να αποθηκευτούν άμεσα ως αριθμητικά λεκτικά. Δείτε το [Ορισμός τιμών σειράς με αριθμητικούς λεκτικούς](/slides/el/androidjava/chart-series/#set-series-values-using-numeric-literals) για ένα πλήρες παράδειγμα που αποθηκεύει και διαβάζει αυτές τις τιμές. Ο τύπος πηγής των τιμών σημείων είναι ξεχωριστός από την εσωτερική ή εξωτερική ρύθμιση βιβλίου εργασίας του γραφήματος· η χρήση αριθμητικών λεκτικών από μόνη της δεν αφαιρεί το ενσωματωμένο βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα τρισδιάστατο γράφημα στήλης με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειρών χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί λεκτικό συμβολοσειράς· το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο εργασίας 0. Η απαρίθμηση [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το παράδειγμα αποθηκεύει την παρουσίαση με τα ενημερωμένα ονόματα σειρών.

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

## **Ανίχνευση μη υποστηριζόμενων ενσωματωμένων μορφών βιβλίου εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη μορφή δυαδικού βιβλίου εργασίας Excel (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) στο [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παρακάμψετε αυτά τα διαγράμματα. Αυτό το παράδειγμα ελέγχει τα σχήματα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης, παραλείπει τα μη-γράφημα σχήματα και εκτυπώνει ένα διαγνωστικό μήνυμα για κάθε γράφημα με ενσωματωμένο βιβλίο εργασίας .xlsb.

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

        // Διαβάστε ή τροποποιήστε τα υποστηριζόμενα δεδομένα βιβλίου εργασίας του γραφήματος εδώ.
    }
} finally {
    presentation.dispose();
}
```

## **Εξωτερικό βιβλίο εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για γραφήματα.

### **Δημιουργία εξωτερικού βιβλίου εργασίας**

Χρησιμοποιήστε τις [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) και [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) για να εξάγετε ένα ενσωματωμένο βιβλίο εργασίας διαγράμματος σε αρχείο και να συνδέσετε το γράφημα με αυτό το εξωτερικό βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με προεπιλεγμένα δεδομένα και εξάγει το βιβλίο εργασίας του. Ολοκληρώνει τη γραφή του αρχείου πριν αντιστοιχίσει το εξωτερικό βιβλίο εργασίας ως πηγή δεδομένων του διαγράμματος, μετά αποθηκεύει την συνδεδεμένη παρουσίαση.

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

### **Ορισμός εξωτερικού βιβλίου εργασίας**

Με τη μέθοδο [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), μπορείτε να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας σε ένα γράφημα ως πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση της διαδρομής προς το εξωτερικό βιβλίο εργασίας (εάν το τελευταίο μετακινηθεί).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας αποθηκευμένα σε απομακρυσμένες θέσεις ή πόρους, μπορείτε ακόμη να τα χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτό το παράδειγμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας του οποίου το φύλλο εργασίας με όνομα `Sheet1` περιέχει ένα όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4 και αριθμητικές τιμές στο B2:B4. Το παράδειγμα δημιουργεί ένα γράφημα πίτας, συνδέει το βιβλίο εργασίας και χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) για να αντιστοιχίσει το A1:B4 σε μια σειρά και τρεις κατηγορίες. Αποθηκεύει την παρουσίαση με το συνδεδεμένο γράφημα.

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

Η παράμετρος `updateChartData` της [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) ελέγχει εάν το βιβλίο εργασίας θα φορτωθεί.

* Όταν το `updateChartData` είναι `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας. Τα δεδομένα του διαγράμματος δεν φορτώνονται ή ενημερώνονται από το στόχο, οπότε το βιβλίο εργασίας μπορεί να είναι μη διαθέσιμο.
* Όταν το `updateChartData` είναι `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το στόχο.

Το παρακάτω παράδειγμα αντιστοιχίζει μια εικονική διεύθυνση URL με το `updateChartData` ορισμένο σε `false`. Διατηρεί τα προεπιλεγμένα δεδομένα του γραφήματος πίτας και αποθηκεύει την παρουσίαση χωρίς να φορτώσει το μη διαθέσιμο βιβλίο εργασίας.

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

### **Ανάκτηση διαδρομής εξωτερικού βιβλίου εργασίας πηγής δεδομένων ενός γραφήματος**

Για να προσδιορίσετε το βιβλίο εργασίας που είναι συνδεδεμένο με ένα γράφημα, ελέγξτε εάν το γράφημα χρησιμοποιεί εξωτερική πηγή δεδομένων και ανακτήστε τη διαδρομή του.

Αυτό το παράδειγμα ελέγχει το πρώτο σχήμα στην πρώτη διαφάνεια μιας παρουσίασης με συνδεδεμένο εξωτερικό βιβλίο εργασίας. Εάν είναι γράφημα συνδεδεμένο με εξωτερικό βιβλίο εργασίας, το παράδειγμα εκτυπώνει το [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης.

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

### **Επεξεργασία δεδομένων γραφήματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στο περιεχόμενο εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, ρίχνεται εξαίρεση.

Αυτό το παράδειγμα χρησιμοποιεί ένα γράφημα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και είναι συνδεδεμένο με ένα προσβάσιμο εξωτερικό βιβλίο εργασίας. Ορίζει την τιμή του πρώτου σημείου δεδομένων στην πρώτη σειρά σε 100 και αποθηκεύει την ενημερωμένη παρουσίαση. Η επεξεργασία τιμών κελιών μπορεί να ενημερώσει το συνδεδεμένο εξωτερικό αρχείο XLSX, οπότε χρησιμοποιήστε ένα αντίγραφο εάν χρειάζεται να διατηρήσετε το αρχικό βιβλίο εργασίας.

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

### **Ανάκτηση βιβλίου εργασίας από την προσωρινή μνήμη του διαγράμματος**

Εάν ένα γράφημα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανακατασκευάσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που είναι στην προσωρινή μνήμη της παρουσίασης. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), καλέστε το [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), και ορίστε το [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) σε `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα Java ανακτά δεδομένα βιβλίου εργασίας για ένα γράφημα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και αναφέρεται σε ένα μη διαθέσιμο εξωτερικό βιβλίο εργασίας. Πρόσβαση στα ανακτημένα δεδομένα μέσω του [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) και του [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων από την προσωρινή μνήμη είναι αποδεκτό εναλλακτικό, επειδή η προσωρινή μνήμη μπορεί να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο γράφημα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα γράφημα έχει έναν [τύπο πηγής δεδομένων](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) και μια [διαδρομή σε εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές σε εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε σχετική διαδρομή, μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX, έτσι η μετακίνηση του βιβλίου εργασίας μπορεί να απαιτήσει ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/ κοινόχρηστους δίσκους;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX όταν αποθηκεύει την παρουσίαση;**

Η παρουσίαση αποθηκεύει έναν [σύνδεσμο προς το εξωτερικό αρχείο](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Η επεξεργασία των δεδομένων του γραφήματος που προέρχονται από κελιά μπορεί επίσης να ενημερώσει το συνδεδεμένο τοπικό αρχείο XLSX. Χρησιμοποιήστε ένα αντίγραφο του βιβλίου εργασίας εάν το αρχικό πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό όταν συνδέεται. Μια συνήθης προσέγγιση είναι η κατάργηση της προστασίας εκ των προτέρων ή η προετοιμασία ενός αποκρυπτογραφημένου αντιγράφου (π.χ., χρησιμοποιώντας [Aspose.Cells](https://reference.aspose.com/cells/java/)) και η σύνδεση σε αυτό το αντίγραφο.

**Μπορούν πολλά γραφήματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε γράφημα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντανακλάται σε κάθε γράφημα την επόμενη φορά που τα δεδομένα θα φορτωθούν.