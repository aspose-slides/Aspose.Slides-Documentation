---
title: Ενσωμάτωση Δεδομένων Excel σε Παρουσιάσεις PowerPoint
linktitle: Ενσωμάτωση Excel
type: docs
weight: 330
url: /el/nodejs-java/excel-integration/
keywords:
- Excel
- βιβλίο εργασίας
- διάβασε Excel
- ενσωμάτωσε Excel
- πηγή δεδομένων
- συγχώνευση αλληλογραφίας
- εισαγωγή πίνακα
- Excel σε PowerPoint
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαβάστε δεδομένα από βιβλία εργασίας Excel σε JavaScript με το Aspose.Slides. Φορτώστε φύλλα και κελιά και χρησιμοποιήστε τις τιμές για να δημιουργήσετε παρουσιάσεις PowerPoint βασισμένες σε δεδομένα."
---
## **Εισαγωγή**

Οι παρουσιάσεις PowerPoint είναι ένας ισχυρός τρόπος για την εμφάνιση και επικοινωνία πληροφοριών. Συχνά χρησιμοποιούνται σε συνδυασμό με βιβλία εργασίας Excel, όπου το Excel λειτουργεί ως εξαιρετική πηγή δομημένων δεδομένων και το PowerPoint διαπρέπει στην οπτικοποίηση αυτών των δεδομένων για το κοινό.

Υπάρχουν πολλά πρακτικά σενάρια όπου ο συνδυασμός Excel και PowerPoint είναι απαραίτητος: συγχωνεύσεις αλληλογραφίας, γέμιση πινάκων δεδομένων, δημιουργία μίας διαφάνειας ανά αρχείο δεδομένων (μαζική δημιουργία διαφανειών), δημιουργία εκπαιδευτικού υλικού και ενοποίηση πολλαπλών αναφορών Excel σε μία παρουσίαση, μεταξύ άλλων.

Μέχρι τώρα, η υλοποίηση τέτοιων λειτουργιών με το API Aspose.Slides απαιτούσε την εξάρτηση από λύσεις τρίτων, όπως το Aspose.Cells. Αν και αυτά τα εργαλεία είναι ισχυρά, μπορούν να είναι υπερβολικά σύνθετα και δαπανηρά για χρήστες που χρειάζονται μόνο βασικές λειτουργίες ενσωμάτωσης δεδομένων.

## **Πώς Λειτουργεί**

Για να γίνει η εργασία με δεδομένα Excel πιο εύκολη και πιο ομαλή, το Aspose.Slides εισήγαγε νέες κλάσεις για ανάγνωση δεδομένων από βιβλία εργασίας Excel και εισαγωγή περιεχομένου σε παρουσίαση. Αυτή η δυνατότητα ανοίγει ισχυρές νέες δυνατότητες για χρήστες του API που θέλουν να εκμεταλλευτούν το Excel ως πηγή δεδομένων στις ροές εργασίας των παρουσιάσεών τους.

Η νέα λειτουργικότητα σχεδιάστηκε για γενική πρόσβαση σε δεδομένα και δεν είναι ενσωματωμένη στο Presentation Document Object Model (DOM). Αυτό σημαίνει ότι *δεν επιτρέπει την επεξεργασία ή την αποθήκευση αρχείων Excel* — σκοπός της είναι μόνο το άνοιγμα βιβλίων εργασίας και η πλοήγηση στο περιεχόμενό τους για την ανάκτηση δεδομένων κελιών.

Στην καρδιά αυτής της δυνατότητας βρίσκεται η νέα κλάση [ExcelDataWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/exceldataworkbook/). Αυτή η κλάση σας επιτρέπει να φορτώσετε ένα βιβλίο εργασίας Excel από τοπικό αρχείο ή ροή. Μόλις φορτωθεί, παρέχει πολλές υπερφορτώσεις της μεθόδου [getCell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/exceldataworkbook/#getCell), την οποία μπορείτε να χρησιμοποιήσετε για την ανάκτηση συγκεκριμένων κελιών με βάση τη θέση τους (π.χ., δείκτες γραμμής και στήλης ή ονομαστικές περιοχές).

Κάθε κλήση στην [getCell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/exceldataworkbook/#getCell) επιστρέφει μια παρουσία της κλάσης [ExcelDataCell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/exceldatacell/). Αυτό το αντικείμενο αντιπροσωπεύει ένα μεμονωμένο κελί στο βιβλίο εργασίας Excel και σας δίνει πρόσβαση στην τιμή του με απλό και διαισθητικό τρόπο.

#### **Εισαγωγή Διαγράμματος Excel**

Το επόμενο βήμα για την επέκταση της λειτουργικότητας είναι η κλάση [ExcelWorkbookImporter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/excelworkbookimporter/). Αυτή η βοηθητική κλάση παρέχει λειτουργίες για εισαγωγή περιεχομένου από ένα βιβλίο εργασίας Excel σε παρουσίαση. Περιέχει πολλές υπερφορτώσεις της μεθόδου [addChartFromWorkbook](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), η οποία σας βοηθά να ανακτήσετε το επιλεγμένο διάγραμμα από το καθορισμένο βιβλίο εργασίας Excel και να το προσθέσετε στο τέλος της δεδομένης συλλογής σχήματος στις καθορισμένες συντεταγμένες.

Συνοπτικά, είναι ένα ελαφρύ και απλό API για ανάγνωση δεδομένων Excel — ακριβώς αυτό που χρειάζονται πολλοί προγραμματιστές χωρίς το βάρος μιας πλήρους βιβλιοθήκης επεξεργασίας λογιστικών φύλλων.

## **Ας Κωδικοποιήσουμε**

### **Παράδειγμα Σεναρίου Συγχώνευσης Ταχυδρομείου**

Στο παρακάτω παράδειγμα, θα υλοποιήσουμε ένα απλό σενάριο Συγχώνευσης Ταχυδρομείου δημιουργώντας πολλαπλές παρουσιάσεις βάσει δεδομένων που αποθηκεύονται σε ένα βιβλίο εργασίας Excel.

Για να ξεκινήσουμε, χρειάζονται δύο πράγματα:
1. Ένα βιβλίο εργασίας Excel που περιέχει τα δεδομένα

![Excel data example](example1_image0.png)

2.  Πρότυπο παρουσίασης PowerPoint

![PowerPoint template example](example1_image1.png)

```js
// Φορτώστε το βιβλίο εργασίας Excel με δεδομένα υπαλλήλων.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Φορτώστε το πρότυπο παρουσίασης.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Περάστε τις γραμμές του Excel (εκτός της κεφαλίδας στη γραμμή 0).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Δημιουργήστε μια νέα παρουσίαση για κάθε εγγραφή υπαλλήλου.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // Αφαιρέστε τη προεπιλεγμένη κενή διαφάνεια.
            employeePresentation.getSlides().removeAt(0);

            // Αντιγράψτε τη διαφάνεια προτύπου στη νέα παρουσίαση.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Λάβετε τις παραγράφους από το στόχο σχήμα (υποτίθεται ότι χρησιμοποιείται ο δείκτης σχήματος 1).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // Αντικαταστήστε τα σύμβολα κράτησης θέσης με δεδομένα από το Excel.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Αποθηκεύστε την εξατομικευμένη παρουσίαση σε ξεχωριστό αρχείο.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Result](example1_image2.png)

### **Παράδειγμα Πίνακα Excel**

Στο δεύτερο παράδειγμα, απλώς αντιγράφουμε δεδομένα από έναν πίνακα Excel και τα εμφανίζουμε σε μια διαφάνεια PowerPoint σε πιο ελκυστική οπτική μορφή.

Σε αυτό το παράδειγμα, επαναχρησιμοποιούμε το ίδιο βιβλίο εργασίας Excel από το πρώτο παράδειγμα, το οποίο περιέχει έναν απλό πίνακα εργαζομένων.

```js
// Φορτώστε το βιβλίο εργασίας Excel που περιέχει τα δεδομένα των υπαλλήλων.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
let presentation = new aspose.slides.Presentation();

try {
    // Προσθέστε ένα σχήμα πίνακα στην πρώτη διαφάνεια.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // Γεμίστε τον πίνακα PowerPoint με δεδομένα από το βιβλίο εργασίας Excel.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Result](example2_image0.png)

### **Παράδειγμα Εισαγωγής Διαγράμματος Excel**

Σε αυτό το παράδειγμα, εισάγουμε ένα διάγραμμα από το πρώτο φύλλο εργασίας του βιβλίου εργασίας Excel που χρησιμοποιήθηκε στο προηγούμενο παράδειγμα. Το διάγραμμα θα συνδεθεί με το εξωτερικό βιβλίο εργασίας στην τελική παρουσίαση.

Αρχικά, προσθέτουμε ένα διάγραμμα πίτας στο βιβλίο εργασίας Excel βασισμένο στον πίνακα εργαζομένων.

![Excel Chart example](example3_image0.png)

```js
// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
let presentation = new aspose.slides.Presentation();
try {
    // Λάβετε τη συλλογή σχημάτων της πρώτης διαφάνειας.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // Εισάγετε το διάγραμμα με όνομα "Chart 1" από το πρώτο φύλλο του βιβλίου εργασίας και προσθέστε το στη συλλογή σχημάτων.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Result](example3_image1.png)

### **Παράδειγμα Εισαγωγής Όλων των Διαγραμμάτων Excel**

Ας φαντασθούμε ότι έχετε ένα βιβλίο εργασίας Excel γεμάτο διαγράμματα και χρειάζεται να τα εισάγετε όλα σε μια παρουσίαση. Κάθε διάγραμμα πρέπει να τοποθετηθεί σε μια νέα διαφάνεια.

Ο παρακάτω κώδικας διατρέχει όλα τα φύλλα εργασίας στο πηγαίο αρχείο Excel, εξάγει τα διαγράμματα από κάθε φύλλο και προσθέτει κάθε διάγραμμα σε ξεχωριστή διαφάνεια χρησιμοποιώντας διαφάνεια κενής διάταξης. Στην τελική παρουσίαση, θα ενσωματωθούν μόνο τα δεδομένα του διαγράμματος, όχι ολόκληρο το βιβλίο εργασίας.

```js
// Φορτώστε το βιβλίο εργασίας Excel που περιέχει τα δεδομένα των υπαλλήλων.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
let presentation = new aspose.slides.Presentation();
try {
    // Ανακτήστε τη διάταξη κενής διαφάνειας.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Λάβετε τα ονόματα όλων των φύλλων εργασίας που περιέχονται στο βιβλίο εργασίας Excel.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // Ανακτήστε έναν χάρτη που αντιστοιχίζει δείκτες διαγραμμάτων σε ονόματα διαγραμμάτων για το φύλλο εργασίας.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // Προσθέστε μια νέα διαφάνεια χρησιμοποιώντας τη διάταξη κενής διαφάνειας.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // Εισάγετε το καθορισμένο διάγραμμα από το βιβλίο εργασίας Excel στη συλλογή σχημάτων της διαφάνειας.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Σύνοψη**

Αυτός ο μηχανισμός, διαθέσιμος απευθείας στο Aspose.Slides, συνδυάζει την εργασία με δεδομένα Excel και παρουσιάσεις σε ένα μέρος. Σας επιτρέπει να δημιουργήτε διαφάνειες με οπτικά διαγράμματα και δεδομένα που παρουσιάζονται ως πίνακες Excel — χωρίς επιπλέον βιβλιοθήκες ή σύνθετες ενσωματώσεις.