---
title: Ενσωμάτωση Δεδομένων Excel σε Παρουσιάσεις PowerPoint
linktitle: Ενσωμάτωση Excel
type: docs
weight: 330
url: /el/java/excel-integration/
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
- Java
- Aspose.Slides
description: "Διαβάστε δεδομένα από βιβλία εργασίας Excel στο Aspose.Slides χρησιμοποιώντας το API ExcelDataWorkbook. Φορτώστε φύλλα και κελιά και χρησιμοποιήστε τις τιμές για να δημιουργήσετε παρουσιάσεις PowerPoint βασισμένες σε δεδομένα."
---
## **Εισαγωγή**

Οι παρουσιάσεις PowerPoint είναι ένας ισχυρός τρόπος προβολής και επικοινωνίας πληροφοριών. Συχνά χρησιμοποιούνται σε συνδυασμό με βιβλία εργασίας Excel, όπου το Excel λειτουργεί ως εξαιρετική πηγή δομημένων δεδομένων και το PowerPoint εξειδικεύεται στην οπτικοποίηση αυτών των δεδομένων για το κοινό.

Υπάρχουν πολλές πρακτικές περιπτώσεις όπου ο συνδυασμός Excel και PowerPoint είναι απαραίτητος: συγχωνεύσεις αλληλογραφίας, πλήρωση πινάκων δεδομένων, δημιουργία μιας διαφάνειας ανά εγγραφή δεδομένων (δημιουργία διαφανειών κατά παρτίδα), δημιουργία εκπαιδευτικού υλικού και ενοποίηση πολλαπλών αναφορών Excel σε μία παρουσίαση, για να αναφέρουμε μερικές.

Μέχρι τώρα, η υλοποίηση τέτοιων λειτουργιών με το API Aspose.Slides απαιτούσε την εξάρτηση από τρίτες λύσεις όπως το Aspose.Cells. Ενώ αυτά τα εργαλεία είναι ισχυρά, μπορεί να είναι υπερβολικά πολύπλοκα και δαπανηρά για χρήστες που χρειάζονται μόνο βασικές λειτουργίες ενσωμάτωσης δεδομένων.

## **Πώς Λειτουργεί**

Για να γίνει πιο εύκολη και απλοϊκή η εργασία με δεδομένα Excel, η Aspose.Slides παρουσίασε νέες κλάσεις για ανάγνωση δεδομένων από βιβλία εργασίας Excel και εισαγωγή περιεχομένου σε μια παρουσίαση. Αυτή η δυνατότητα ανοίγει ισχυρές νέες προοπτικές για τους χρήστες του API που θέλουν να αξιοποιήσουν το Excel ως πηγή δεδομένων στις ροές εργασίας των παρουσιάσεων τους.

Η νέα λειτουργικότητα έχει σχεδιαστεί για γενική πρόσβαση σε δεδομένα και δεν είναι ενσωματωμένη στο Presentation Document Object Model (DOM). Αυτό σημαίνει *ότι δεν επιτρέπει την επεξεργασία ή αποθήκευση αρχείων Excel* — ο μοναδικός της σκοπός είναι το άνοιγμα βιβλίων εργασίας και η περιήγηση στο περιεχόμενό τους για την ανάκτηση τιμών κελιών.

Στην καρδιά αυτής της δυνατότητας βρίσκεται η νέα κλάση [ExcelDataWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/exceldataworkbook/). Αυτή η κλάση σας επιτρέπει να φορτώσετε ένα βιβλίο εργασίας Excel από τοπικό αρχείο ή ροή. Μόλις φορτωθεί, παρέχει πολλές υπερφορτώσεις της μεθόδου [getCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) που μπορείτε να χρησιμοποιήσετε για να ανακτήσετε συγκεκριμένα κελιά βάσει της θέσης τους (π.χ. δείκτες γραμμής και στήλης ή ονομαστικές περιοχές).

Κάθε κλήση στη [getCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) επιστρέφει μια παρουσία της κλάσης [ExcelDataCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/exceldatacell/). Αυτό το αντικείμενο αντιπροσωπεύει ένα μόνο κελί στο βιβλίο εργασίας Excel και σας παρέχει πρόσβαση στην τιμή του με έναν απλό και διαισθητικό τρόπο.

#### **Εισαγωγή Γραφήματος Excel**

Το επόμενο βήμα για την επέκταση της λειτουργικότητας είναι η κλάση [ExcelWorkbookImporter](https://reference.aspose.com/slides/el/java/com.aspose.slides/excelworkbookimporter/). Αυτή η βοηθητική κλάση παρέχει δυνατότητα εισαγωγής περιεχομένου από ένα βιβλίο εργασίας Excel σε μια παρουσίαση. Περιλαμβάνει πολλές υπερφορτώσεις της μεθόδου [addChartFromWorkbook](https://reference.aspose.com/slides/el/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) που σας βοηθούν να ανακτήσετε το επιλεγμένο γράφημα από το καθορισμένο βιβλίο εργασίας Excel και να το προσθέσετε στο τέλος της δεδομένης συλλογής σχήματος στις καθορισμένες συντεταγμένες.

Συνοπτικά, πρόκειται για ένα ελαφρύ και απλό API ανάγνωσης δεδομένων Excel — ακριβώς αυτό που χρειάζονται πολλοί προγραμματιστές χωρίς το βάρος μιας πλήρους βιβλιοθήκης επεξεργασίας λογιστικών φύλλων.

## **Ας Κωδικοποιήσουμε**

### **Παράδειγμα Σεναρίου Συγχώνευσης Αλληλογραφίας**

Στο παρακάτω παράδειγμα, θα υλοποιήσουμε ένα απλό σενάριο συγχώνευσης αλληλογραφίας δημιουργώντας πολλαπλές παρουσιάσεις βασισμένες στα δεδομένα που αποθηκεύονται σε ένα βιβλίο εργασίας Excel.

Για να ξεκινήσουμε, χρειάζονται δύο πράγματα:
1. Ένα βιβλίο εργασίας Excel που περιέχει τα δεδομένα

![Παράδειγμα δεδομένων Excel](example1_image0.png)

2. Πρότυπο παρουσίασης PowerPoint

![Παράδειγμα προτύπου PowerPoint](example1_image1.png)

```java
// Φορτώστε το βιβλίο εργασίας Excel με δεδομένα υπαλλήλων.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Φορτώστε το πρότυπο παρουσίασης.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Επανάληψη στις γραμμές του Excel (εξαιρώντας την κεφαλίδα στη γραμμή 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Δημιουργήστε μια νέα παρουσίαση για κάθε εγγραφή υπαλλήλου.
        Presentation employeePresentation = new Presentation();

        try {
            // Αφαιρέστε την προεπιλεγμένη κενή διαφάνεια.
            employeePresentation.getSlides().removeAt(0);

            // Κλωνοποιήστε τη διαφάνεια προτύπου στη νέα παρουσίαση.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Πάρτε τις παραγράφους από το στόχο σχήμα (υποθέτει ότι χρησιμοποιείται το δείκτη σχήματος 1).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Αντικαταστήστε τα σύμβολα κράτησης θέσης με δεδομένα από το Excel.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Αποθηκεύστε την εξατομικευμένη παρουσίαση σε ξεχωριστό αρχείο.
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

Στο δεύτερο παράδειγμα, αντιγράψουμε απλώς δεδομένα από έναν πίνακα Excel και τα εμφανίζουμε σε μια διαφάνεια PowerPoint με πιο ελκυστική οπτική μορφή.

Σε αυτό το παράδειγμα, επαναχρησιμοποιούμε το ίδιο βιβλίο εργασίας Excel από το πρώτο παράδειγμα, το οποίο περιέχει έναν απλό πίνακα υπαλλήλων.

```java
// Φορτώστε το βιβλίο εργασίας Excel που περιέχει τα δεδομένα υπαλλήλων.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
Presentation presentation = new Presentation();

try {
    // Προσθέστε ένα σχήμα πίνακα στην πρώτη διαφάνεια.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Συμπληρώστε τον πίνακα PowerPoint με δεδομένα από το βιβλίο εργασίας Excel.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Αποθηκεύστε την τελική παρουσίαση σε αρχείο.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Αποτέλεσμα](example2_image0.png)

### **Παράδειγμα Εισαγωγής Γραφήματος Excel**

Σε αυτό το παράδειγμα, εισάγουμε ένα γράφημα από το πρώτο φύλλο εργασίας του βιβλίου εργασίας Excel που χρησιμοποιήθηκε στο προηγούμενο παράδειγμα. Το γράφημα θα συνδεθεί με το εξωτερικό βιβλίο εργασίας στην τελική παρουσίαση.

Πρώτα, προσθέτουμε ένα γράφημα Πίτας στο βιβλίο εργασίας Excel με βάση τον πίνακα υπαλλήλων.

![Παράδειγμα γραφήματος Excel](example3_image0.png)

```java
// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
Presentation presentation = new Presentation();
try {
    // Λάβετε τη συλλογή σχημάτων της πρώτης διαφάνειας.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Εισάγετε το γράφημα με όνομα "Chart 1" από το πρώτο φύλλο του βιβλίου εργασίας και προσθέστε το στη συλλογή σχημάτων.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Αποθηκεύστε την τελική παρουσίαση σε αρχείο.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Αποτέλεσμα](example3_image1.png)

### **Παράδειγμα Εισαγωγής Όλων των Γραφημάτων Excel**

Ας υποθέσουμε ότι έχετε ένα βιβλίο εργασίας Excel γεμάτο γραφήματα και πρέπει να τα εισάγετε όλα σε μια παρουσίαση. Κάθε γράφημα πρέπει να τοποθετηθεί σε νέα διαφάνεια.

Ο παρακάτω κώδικας επαναλαμβάνει όλα τα φύλλα εργασίας στο πηγαίο αρχείο Excel, εξάγει τα γραφήματα από κάθε φύλλο και προσθέτει κάθε γράφημα σε ξεχωριστή διαφάνεια χρησιμοποιώντας μια κενή διάταξη διαφάνειας. Στην τελική παρουσίαση, θα ενσωματωθούν μόνο τα δεδομένα του γραφήματος, όχι ολόκληρο το βιβλίο εργασίας.

```java
// Φορτώστε το βιβλίο εργασίας Excel που περιέχει τα δεδομένα υπαλλήλων.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
Presentation presentation = new Presentation();
try {
    // Ανακτήστε τη διάταξη κενής διαφάνειας.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Λάβετε τα ονόματα όλων των φύλλων εργασίας που περιέχονται στο βιβλίο εργασίας Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Ανακτήστε έναν χάρτη που αντιστοιχίζει τους δείκτες των γραφημάτων σε ονόματα γραφημάτων για το φύλλο εργασίας.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Προσθέστε μια νέα διαφάνεια χρησιμοποιώντας τη διάταξη κενής διαφάνειας.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Εισάγετε το καθορισμένο γράφημα από το βιβλίο εργασίας Excel στη συλλογή σχημάτων της διαφάνειας.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Αποθηκεύστε την τελική παρουσίαση σε αρχείο.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Σύνοψη**

Αυτός ο μηχανισμός, διαθέσιμος απευθείας στην Aspose.Slides, συνδυάζει την εργασία με δεδομένα Excel και παρουσιάσεις σε ένα σημείο. Σας επιτρέπει να δημιουργείτε διαφάνειες με οπτικά γραφήματα και δεδομένα που παρουσιάζονται ως πίνακες Excel — χωρίς πρόσθετες βιβλιοθήκες ή περίπλοκες ενσωματώσεις.

---
title: Ενσωμάτωση Δεδομένων Excel σε Παρουσιάσεις PowerPoint
linktitle: Ενσωμάτωση Excel
type: docs
weight: 330
url: /el/java/excel-integration/
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
- Java
- Aspose.Slides
description: "Διαβάστε δεδομένα από βιβλία εργασίας Excel στο Aspose.Slides χρησιμοποιώντας το API ExcelDataWorkbook. Φορτώστε φύλλα και κελιά και χρησιμοποιήστε τις τιμές για να δημιουργήσετε παρουσιάσεις PowerPoint βασισμένες σε δεδομένα."
---