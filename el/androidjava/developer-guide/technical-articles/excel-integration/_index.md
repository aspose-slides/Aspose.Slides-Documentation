---
title: Ενσωμάτωση Δεδομένων Excel σε Παρουσιάσεις PowerPoint
linktitle: Ενσωμάτωση Excel
type: docs
weight: 330
url: /el/androidjava/excel-integration/
keywords:
- Excel
- βιβλίο εργασίας
- ανάγνωση Excel
- ενσωμάτωση Excel
- πηγή δεδομένων
- συγχώνευση αλληλογραφίας
- εισαγωγή πίνακα
- Excel σε PowerPoint
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ανάγνωση δεδομένων από βιβλία εργασίας Excel στο Aspose.Slides χρησιμοποιώντας το API ExcelDataWorkbook. Φορτώστε φύλλα και κελιά και χρησιμοποιήστε τις τιμές για να δημιουργήσετε παρουσιάσεις PowerPoint βάσει δεδομένων."
---
## **Εισαγωγή**

PowerPoint παρουσιάσεις είναι ένας ισχυρός τρόπος για να εμφανίζετε και να επικοινωνείτε πληροφορίες. Συχνά χρησιμοποιούνται σε συνδυασμό με βιβλία εργασίας του Excel, όπου το Excel λειτουργεί ως εξαιρετική πηγή δομημένων δεδομένων και το PowerPoint διαπρέπει στην οπτικοποίηση αυτών των δεδομένων για το κοινό.

Υπάρχουν πολλές πρακτικές περιπτώσεις όπου η συνδυαστική χρήση του Excel και του PowerPoint είναι απαραίτητη: συγχωνεύσεις αλληλογραφίας, γέμισμα πινάκων δεδομένων, δημιουργία μιας διαφάνειας ανά εγγραφή δεδομένων (παρτίδα δημιουργίας διαφανειών), δημιουργία εκπαιδευτικού υλικού, και ενοποίηση πολλαπλών εκθέσεων Excel σε μία παρουσίαση, για να αναφέρουμε μερικά.

Μέχρι τώρα, η υλοποίηση τέτοιων λειτουργιών με το Aspose.Slides API απαιτούσε την εξάρτηση από τρίτες λύσεις όπως το Aspose.Cells. Αν και αυτά τα εργαλεία είναι ισχυρά, μπορεί να είναι υπερβολικά πολύπλοκα και δαπανηρά για χρήστες που χρειάζονται μόνο βασική λειτουργικότητα ενσωμάτωσης δεδομένων.

## **Πώς Λειτουργεί**

Για να γίνει η εργασία με δεδομένα Excel πιο εύκολη και πιο απλοποιημένη, το Aspose.Slides εισήγαγε νέες κλάσεις για ανάγνωση δεδομένων από βιβλία εργασίας του Excel και εισαγωγή περιεχομένου σε μια παρουσίαση. Αυτή η δυνατότητα ανοίγει ισχυρές νέες δυνατότητες για χρήστες του API που θέλουν να χρησιμοποιήσουν το Excel ως πηγή δεδομένων μέσα στις ροές εργασίας των παρουσιάσεων τους.

Η νέα λειτουργικότητα σχεδιάστηκε για γενικού σκοπού πρόσβαση δεδομένων και δεν είναι ενσωματωμένη στο Presentation Document Object Model (DOM). Αυτό σημαίνει *ότι δεν επιτρέπει την επεξεργασία ή αποθήκευση αρχείων Excel* — ο μοναδικός της σκοπός είναι να ανοίγει βιβλία εργασίας και να περιηγείται στο περιεχόμενό τους για την ανάκτηση δεδομένων κελιών.

Στον πυρήνα αυτής της δυνατότητας βρίσκεται η νέα κλάση [ExcelDataWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/exceldataworkbook/). Αυτή η κλάση σάς επιτρέπει να φορτώσετε ένα βιβλίο εργασίας Excel από τοπικό αρχείο ή ροή. Μόλις φορτωθεί, παρέχει πολλές υπερφορτώσεις της μεθόδου [getCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) που μπορείτε να χρησιμοποιήσετε για να ανακτήσετε συγκεκριμένα κελιά με τη θέση τους (π.χ. δείκτες γραμμής και στήλης ή ονομαστικές περιοχές).

Κάθε κλήση στη μέθοδο [getCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) επιστρέφει μια παρουσία της κλάσης [ExcelDataCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/exceldatacell/). Αυτό το αντικείμενο αντιπροσωπεύει ένα μόνο κελί στο βιβλίο εργασίας Excel και σας δίνει πρόσβαση στην τιμή του με έναν απλό και διαισθητικό τρόπο.

#### **Εισαγωγή Διαγράμματος Excel**

Το επόμενο βήμα για την επέκταση της λειτουργικότητας είναι η κλάση [ExcelWorkbookImporter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/excelworkbookimporter/). Αυτή η βοηθητική κλάση παρέχει λειτουργίες για την εισαγωγή περιεχομένου από ένα βιβλίο εργασίας Excel σε μια παρουσίαση. Περιέχει πολλές υπερφορτώσεις της μεθόδου [addChartFromWorkbook](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) που σας βοηθούν να ανακτήσετε το επιλεγμένο διάγραμμα από το καθορισμένο βιβλίο εργασίας Excel και να το προσθέσετε στο τέλος της δεδομένης συλλογής σχημάτων στις καθορισμένες συντεταγμένες.

Με λίγα λόγια, είναι ένα ελαφρύ και απλό API για ανάγνωση δεδομένων Excel — ακριβώς αυτό που πολλοί προγραμματιστές χρειάζονται χωρίς το βάρος μιας πλήρους βιβλιοθήκης επεξεργασίας λογιστικών φύλλων.

## **Ας Κωδικοποιήσουμε**

### **Παράδειγμα Σεναρίου Συγχώνευσης Αλληλογραφίας**

Στο παρακάτω παράδειγμα, θα υλοποιήσουμε ένα απλό σενάριο Συγχώνευσης Αλληλογραφίας δημιουργώντας πολλαπλές παρουσιάσεις βάσει των δεδομένων που αποθηκεύονται σε ένα βιβλίο εργασίας Excel.

Για να ξεκινήσουμε, χρειαζόμαστε δύο πράγματα:
1. Ένα βιβλίο εργασίας Excel που περιέχει τα δεδομένα

![Παράδειγμα δεδομένων Excel](example1_image0.png)

2. Πρότυπο παρουσίασης PowerPoint

![Παράδειγμα προτύπου PowerPoint](example1_image1.png)

```java
// Φόρτωση του βιβλίου εργασίας Excel με δεδομένα υπαλλήλων.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Φόρτωση του προτύπου παρουσίασης.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Επανάληψη στις γραμμές του Excel (εξαιρώντας την κεφαλίδα στη γραμμή 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Δημιουργία νέας παρουσίασης για κάθε εγγραφή υπαλλήλου.
        Presentation employeePresentation = new Presentation();

        try {
            // Αφαίρεση της προεπιλεγμένης κενής διαφάνειας.
            employeePresentation.getSlides().removeAt(0);

            // Κλωνοποίηση της διαφάνειας προτύπου στην νέα παρουσίαση.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Λήψη παραγράφων από το στοχευμένο σχήμα (υποθέτει ότι χρησιμοποιείται δείκτης σχήματος 1).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Αντικατάσταση των δεσμευτικών σημείων με δεδομένα από το Excel.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Αποθήκευση της προσωποποιημένης παρουσίασης σε ξεχωριστό αρχείο.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Αποτέλεσμα](example1_image2.png)

### **Παράδειγμα Πίνακα Excel**

Στο δεύτερο παράδειγμα, απλώς αντιγράφουμε δεδομένα από έναν πίνακα Excel και τα εμφανίζουμε σε μια διαφάνεια PowerPoint με πιο οπτικά ελκυστική μορφή.

Σε αυτό το παράδειγμα, επαναχρησιμοποιούμε το ίδιο βιβλίο εργασίας Excel από το πρώτο παράδειγμα, το οποίο περιέχει έναν απλό πίνακα εργαζομένων.

```java
// Φόρτωση του βιβλίου εργασίας Excel που περιέχει τα δεδομένα υπαλλήλου.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Δημιουργία νέας παρουσίασης PowerPoint.
Presentation presentation = new Presentation();

try {
    // Προσθήκη σχήματος πίνακα στην πρώτη διαφάνεια.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Συμπλήρωση του πίνακα PowerPoint με δεδομένα από το βιβλίο εργασίας Excel.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Αποθήκευση της παραγόμενης παρουσίασης σε αρχείο.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Αποτέλεσμα](example2_image0.png)

### **Παράδειγμα Εισαγωγής Διαγράμματος Excel**

Σε αυτό το παράδειγμα, εισάγουμε ένα διάγραμμα από το πρώτο φύλλο του βιβλίου εργασίας Excel που χρησιμοποιήθηκε στο προηγούμενο παράδειγμα. Το διάγραμμα θα συνδεθεί με το εξωτερικό βιβλίο εργασίας στην τελική παρουσίαση.

Πρώτα, προσθέτουμε ένα διάγραμμα Πίτας στο βιβλίο εργασίας Excel βάσει του πίνακα εργαζομένων.

![Παράδειγμα διαγράμματος Excel](example3_image0.png)

```java
// Δημιουργία νέας παρουσίασης PowerPoint.
Presentation presentation = new Presentation();
try {
    // Λήψη συλλογής σχημάτων της πρώτης διαφάνειας.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Εισαγωγή του διαγράμματος με όνομα "Chart 1" από το πρώτο φύλλο του βιβλίου εργασίας και προσθήκη του στη συλλογή σχημάτων.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Αποθήκευση της παραγόμενης παρουσίασης σε αρχείο.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Αποτέλεσμα](example3_image1.png)

### **Παράδειγμα Εισαγωγής Όλων των Διαγραμμάτων Excel**

Ας φανταστούμε ότι έχετε ένα βιβλίο εργασίας Excel γεμάτο διαγράμματα και χρειάζεται να τα εισαγάγετε όλα σε μια παρουσίαση. Κάθε διάγραμμα πρέπει να τοποθετηθεί σε νέα διαφάνεια.

Ο παρακάτω κώδικας διατρέχει όλα τα φύλλα εργασίας στο πηγαίο αρχείο Excel, εξάγει τα διαγράμματα από κάθε φύλλο και προσθέτει κάθε διάγραμμα σε ξεχωριστή διαφάνεια χρησιμοποιώντας μια κενή διάταξη διαφάνειας. Στην τελική παρουσίαση, θα ενσωματωθούν μόνο τα δεδομένα του διαγράμματος, όχι ολόκληρο το βιβλίο εργασίας.

```java
// Φόρτωση του βιβλίου εργασίας Excel που περιέχει τα δεδομένα του υπαλλήλου.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Δημιουργία νέας παρουσίασης PowerPoint.
Presentation presentation = new Presentation();
try {
    // Ανάκτηση του κενής διάταξης διαφάνειας.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Λήψη των ονομάτων όλων των φύλλων εργασίας που περιέχονται στο βιβλίο εργασίας Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Ανάκτηση χάρτη που αντιστοιχίζει δείκτες διαγραμμάτων σε ονόματα διαγραμμάτων για το φύλλο εργασίας.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Προσθήκη νέας διαφάνειας χρησιμοποιώντας την κενή διάταξη.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Εισαγωγή του καθορισμένου διαγράμματος από το βιβλίο εργασίας Excel στη συλλογή σχημάτων της διαφάνειας.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Αποθήκευση της παραγόμενης παρουσίασης σε αρχείο.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Σύνοψη**

Αυτός ο μηχανισμός, διαθέσιμος άμεσα στο Aspose.Slides, συνδυάζει την εργασία με δεδομένα Excel και παρουσιάσεις σε ένα μέρος. Σας επιτρέπει να δημιουργήσετε διαφάνειες με οπτικά διαγράμματα και δεδομένα που παρουσιάζονται ως πίνακες Excel — χωρίς πρόσθετες βιβλιοθήκες ή πολύπλοκες ενσωματώσεις.