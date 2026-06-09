---
title: Ενσωμάτωση δεδομένων Excel σε παρουσιάσεις PowerPoint
linktitle: Ενσωμάτωση Excel
type: docs
weight: 330
url: /el/php-java/excel-integration/
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
- PHP
- Aspose.Slides
description: "Ανάγνωση δεδομένων από βιβλία εργασίας Excel χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Φόρτωση φύλλων και κελιών και χρήση τιμών για τη δημιουργία παρουσιάσεων PowerPoint βασισμένων σε δεδομένα."
---
## **Εισαγωγή**

Οι παρουσιάσεις PowerPoint είναι ένας ισχυρός τρόπος για την προβολή και την επικοινωνία πληροφοριών. Συχνά χρησιμοποιούνται σε συνδυασμό με βιβλία εργασίας Excel, όπου το Excel λειτουργεί ως εξαιρετική πηγή δομημένων δεδομένων και το PowerPoint διακρίνεται στην οπτικοποίηση αυτών των δεδομένων για το κοινό.

Υπάρχουν πολλές πρακτικές περιπτώσεις όπου ο συνδυασμός Excel και PowerPoint είναι απαραίτητος: συγχωνεύσεις αλληλογραφίας, πλημμύρωση πινάκων δεδομένων, δημιουργία μιας διαφάνειας ανά εγγραφή δεδομένων (παραγωγή παρτίδων διαφανειών), δημιουργία εκπαιδευτικού υλικού και ενοποίηση πολλαπλών αναφορών Excel σε μία παρουσίαση, μεταξύ άλλων.

Μέχρι τώρα, η υλοποίηση τέτοιων λειτουργιών με το API του Aspose.Slides απαιτούσε την εξάρτηση από λύσεις τρίτων, όπως το Aspose.Cells. Ενώ αυτά τα εργαλεία είναι ισχυρά, μπορούν να είναι υπερβολικά πολύπλοκα και δαπανηρά για χρήστες που χρειάζονται μόνο βασική λειτουργικότητα ενοποίησης δεδομένων.

## **Πώς λειτουργεί**

Για να διευκολυνθεί η εργασία με δεδομένα Excel και να γίνει πιο απλή, το Aspose.Slides παρουσίασε νέες κλάσεις για ανάγνωση δεδομένων από βιβλία εργασίας Excel και εισαγωγή περιεχομένου σε μια παρουσίαση. Αυτή η δυνατότητα ανοίγει ισχυρές νέες προοπτικές για χρήστες του API που θέλουν να αξιοποιήσουν το Excel ως πηγή δεδομένων στις ροές εργασίας των παρουσιάσεών τους.

Η νέα λειτουργία σχεδιάστηκε για γενική πρόσβαση σε δεδομένα και δεν ενσωματώνεται στο Presentation Document Object Model (DOM). Αυτό σημαίνει ότι *δεν επιτρέπει την επεξεργασία ή την αποθήκευση αρχείων Excel* — ο μοναδικός σκοπός της είναι το άνοιγμα βιβλίων εργασίας και η πλοήγηση στο περιεχόμενό τους για την ανάκτηση δεδομένων κελιών.

Στον πυρήνα αυτής της δυνατότητας βρίσκεται η νέα κλάση [ExcelDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/exceldataworkbook/). Αυτή η κλάση επιτρέπει τη φόρτωση ενός βιβλίου εργασίας Excel από τοπικό αρχείο ή ροή. Μόλις φορτωθεί, παρέχει πολλαπλές υπερφόρτωσεις της μεθόδου [getCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/exceldataworkbook/#getCell), τις οποίες μπορείτε να χρησιμοποιήσετε για την ανάκτηση συγκεκριμένων κελιών με βάση τη θέση τους (π.χ., δείκτες σειράς και στήλης ή ονομαστικές περιοχές).

Κάθε κλήση στη μέθοδο [getCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/exceldataworkbook/#getCell) επιστρέφει μια παρουσία της κλάσης [ExcelDataCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/exceldatacell/). Αυτό το αντικείμενο αντιπροσωπεύει ένα μόνο κελί στο βιβλίο εργασίας Excel και παρέχει πρόσβαση στην τιμή του με απλό και διαισθητικό τρόπο.

#### **Εισαγωγή διαγράμματος Excel**

Το επόμενο βήμα για την επέκταση της λειτουργικότητας είναι η κλάση [ExcelWorkbookImporter](https://reference.aspose.com/slides/el/php-java/aspose.slides/excelworkbookimporter/). Αυτή η βοηθητική κλάση παρέχει λειτουργίες για την εισαγωγή περιεχομένου από βιβλίο εργασίας Excel σε μια παρουσίαση. Περιέχει πολλές υπερφορτώσεις της μεθόδου [addChartFromWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), οι οποίες σας βοηθούν να ανακτήσετε το επιλεγμένο διάγραμμα από το καθορισμένο βιβλίο εργασίας Excel και να το προσθέσετε στο τέλος της δοσμένης συλλογής σχήματος στις καθορισμένες συντεταγμένες.

Συνοπτικά, είναι ένα ελαφρύ και απλό API για την ανάγνωση δεδομένων Excel — ακριβώς ό,τι χρειάζονται πολλοί προγραμματιστές χωρίς το βάρος μιας πλήρους βιβλιοθήκης επεξεργασίας λογιστικού φύλλου.

## **Ας γράψουμε κώδικα**

### **Παράδειγμα σεναρίου συγχώνευσης αλληλογραφίας**

Στο παρακάτω παράδειγμα, θα υλοποιήσουμε ένα απλό σενάριο συγχώνευσης αλληλογραφίας δημιουργώντας πολλαπλές παρουσιάσεις βάσει δεδομένων που αποθηκεύονται σε ένα βιβλίο εργασίας Excel.

Για να ξεκινήσουμε, χρειάζονται δύο πράγματα:
1. Ένα βιβλίο εργασίας Excel που περιέχει τα δεδομένα

![Παράδειγμα δεδομένων Excel](example1_image0.png)

2. Πρότυπο παρουσίασης PowerPoint

![Παράδειγμα προτύπου PowerPoint](example1_image1.png)

```php
// Φορτώστε το βιβλίο εργασίας Excel με δεδομένα υπαλλήλων.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Φορτώστε το πρότυπο παρουσίασης.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Επανάληψη στις σειρές του Excel (εξαιρώντας την επικεφαλίδα στη σειρά 0).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // Δημιουργήστε μια νέα παρουσίαση για κάθε εγγραφή υπαλλήλου.
        $employeePresentation = new Presentation();

        try {
            // Αφαιρέστε την προεπιλεγμένη κενή διαφάνεια.
            $employeePresentation->getSlides()->removeAt(0);

            // Κλωνοποιήστε τη διαφάνεια προτύπου στη νέα παρουσίαση.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // Λάβετε τις παραγράφους από το σχήμα-στόχο (υποθέτει ότι χρησιμοποιείται ο δείκτης σχήματος 1).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // Αντικαταστήστε τα σύμβολα κράτησης θέσης με δεδομένα από το Excel.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // Αποθηκεύστε την εξατομικευμένη παρουσίαση σε ξεχωριστό αρχείο.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![Αποτέλεσμα](example1_image2.png)

### **Παράδειγμα πίνακα Excel**

Στο δεύτερο παράδειγμα, αντιγράφουμε απλώς δεδομένα από έναν πίνακα Excel και τα εμφανίζουμε σε μια διαφάνεια PowerPoint με πιο ελκυστική οπτική μορφή.

Σε αυτό το παράδειγμα, ξαναχρησιμοποιούμε το ίδιο βιβλίο εργασίας Excel από το πρώτο παράδειγμα, το οποίο περιέχει έναν απλό πίνακα υπαλλήλων.

```php
// Φορτώστε το βιβλίο εργασίας Excel που περιέχει τα δεδομένα υπαλλήλων.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
$presentation = new Presentation();

try {
    // Προσθέστε ένα σχήμα πίνακα στην πρώτη διαφάνεια.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // Συμπληρώστε τον πίνακα PowerPoint με δεδομένα από το βιβλίο εργασίας Excel.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Αποτέλεσμα](example2_image0.png)

### **Παράδειγμα εισαγωγής διαγράμματος Excel**

Σε αυτό το παράδειγμα, εισάγουμε ένα διάγραμμα από το πρώτο φύλλο εργασίας του βιβλίου εργασίας Excel που χρησιμοποιήθηκε στο προηγούμενο παράδειγμα. Το διάγραμμα θα συνδεθεί με το εξωτερικό βιβλίο εργασίας στην τελική παρουσίαση.

Αρχικά, προσθέτουμε ένα διάγραμμα πίτας στο βιβλίο εργασίας Excel βάσει του πίνακα υπαλλήλων.

![Παράδειγμα διαγράμματος Excel](example3_image0.png)

```php
// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
$presentation = new Presentation();
try {
    // Λάβετε τη συλλογή σχημάτων της πρώτης διαφάνειας.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // Εισάγετε το διάγραμμα με όνομα "Chart 1" από το πρώτο φύλλο του βιβλίου εργασίας και προσθέστε το στη συλλογή σχημάτων.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Αποτέλεσμα](example3_image1.png)

### **Παράδειγμα εισαγωγής όλων των διαγραμμάτων Excel**

Ας υποθέσουμε ότι έχετε ένα βιβλίο εργασίας Excel γεμάτο διαγράμματα και πρέπει να τα εισάγετε όλα σε μια παρουσίαση. Κάθε διάγραμμα θα πρέπει να τοποθετηθεί σε μια νέα διαφάνεια.

Ο παρακάτω κώδικας διασχίζει όλα τα φύλλα εργασίας στο πηγή αρχείο Excel, εξάγει τα διαγράμματα από κάθε φύλλο και προσθέτει κάθε διάγραμμα σε ξεχωριστή διαφάνεια χρησιμοποιώντας μια κενή διάταξη διαφάνειας. Στην τελική παρουσίαση, θα ενσωματωθούν μόνο τα δεδομένα του διαγράμματος, όχι ολόκληρο το βιβλίο εργασίας.

```php
// Φορτώστε το βιβλίο εργασίας Excel που περιέχει τα δεδομένα υπαλλήλων.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Δημιουργήστε μια νέα παρουσίαση PowerPoint.
$presentation = new Presentation();
try {
    // Ανάκτηση της κενής διάταξης διαφάνειας.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Λάβετε τα ονόματα όλων των φύλλων εργασίας που περιέχονται στο βιβλίο εργασίας Excel.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // Ανακτήστε έναν χάρτη που αντιστοιχεί τους δείκτες διαγραμμάτων σε ονόματα διαγραμμάτων για το φύλλο εργασίας.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // Προσθέστε μια νέα διαφάνεια χρησιμοποιώντας την κενή διάταξη.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // Εισάγετε το καθορισμένο διάγραμμα από το βιβλίο εργασίας Excel στη συλλογή σχημάτων της διαφάνειας.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // Αποθηκεύστε την προκύπτουσα παρουσίαση σε αρχείο.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Σύνοψη**

Αυτός ο μηχανισμός, διαθέσιμος απευθείας στο Aspose.Slides, συνδυάζει την εργασία με δεδομένα Excel και παρουσιάσεις σε ένα μέρος. Σας επιτρέπει να δημιουργείτε διαφάνειες με οπτικά διαγράμματα και δεδομένα που παρουσιάζονται ως πίνακες Excel — χωρίς πρόσθετες βιβλιοθήκες ή πολύπλοκες ενσωματώσεις.