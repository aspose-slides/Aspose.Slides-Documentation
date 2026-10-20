---
title: Δημιουργία διαγραμμάτων Excel και ενσωμάτωσή τους σε παρουσιάσεις ως αντικείμενα OLE
type: docs
weight: 30
url: /el/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Διάγραμμα Excel
- ενσωμάτωση διαγράμματος
- αντικείμενο OLE
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε ένα διάγραμμα Excel με το Aspose.Cells for PHP via Java και ενσωματώστε το βιβλίο εργασίας σε μια παρουσίαση PowerPoint με το Aspose.Slides for PHP via Java, συμπεριλαμβανομένης μιας προεπισκόπησης διαγράμματος."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε ένα διάγραμμα στήλης Excel με Aspose.Cells for PHP via Java και να ενσωματώσετε το βιβλίο εργασίας του σε μια παρουσίαση PowerPoint με Aspose.Slides for PHP via Java. Το ενσωματωμένο βιβλίο εργασίας περιέχει τόσο τα πηγαία δεδομένα όσο και το διάγραμμα. Μια ξεχωριστή προεπισκόπηση PNG εμφανίζει το διάγραμμα στη διαφάνεια πριν ενεργοποιηθεί το αντικείμενο OLE.

Το αποτέλεσμα είναι ένα ενσωματωμένο αντικείμενο Excel, όχι ένα εγγενές διάγραμμα PowerPoint. Η επεξεργασία του βιβλίου εργασίας μέσω OLE απαιτεί μια εφαρμογή επιφάνειας εργασίας που υποστηρίζει ενεργοποίηση OLE και μια συμβατή εγκατάσταση του Excel.

## **Προαπαιτούμενα**

Ρυθμίστε το Aspose.Cells for PHP via Java και το Aspose.Slides for PHP via Java με το ίδιο παράδειγμα PHP/Java Bridge. Φορτώστε και τα δύο PHP wrappers και κάντε τις βιβλιοθήκες Java των προϊόντων διαθέσιμες στη γέφυρα. Δεν απαιτείται το Microsoft Office για τη δημιουργία της παρουσίασης με αυτές τις βιβλιοθήκες.

Δεν απαιτούνται αρχεία εισόδου: το παράδειγμα δημιουργεί τα δεδομένα και το διάγραμμα στη μνήμη, στη συνέχεια γράφει `OutputChart.pptx` στον τρέχοντα φάκελο εργασίας. Εφαρμόστε άδειες για τα δύο προϊόντα όταν εκτελείται εκτός λειτουργίας αξιολόγησης.

## **Πώς Λειτουργεί η Ενσωμάτωση**

1. Δημιουργήστε ένα βιβλίο εργασίας με φύλλο δεδομένων και φύλλο διαγράμματος.  
2. Κάντε το φύλλο διαγράμματος ενεργό ώστε το βιβλίο εργασίας να ανοίγει στο διάγραμμα.  
3. Ορίστε το εύρος εμφάνισης OLE του βιβλίου εργασίας και αποδώστε το διάγραμμα σε PNG.  
4. Αποθηκεύστε το βιβλίο εργασίας ως XLSX στη μνήμη και ενσωματώστε τα byte σε μια διαφάνεια.  
5. Ορίστε το PNG ως προεπισκόπηση του αντικειμένου OLE και αποθηκεύστε την παρουσίαση ως PPTX.

Το εύρος εμφάνισης του βιβλίου εργασίας και το πλαίσιο στη διαφάνεια έχουν διαφορετικούς ρόλους. Η μέθοδος [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) δέχεται δείκτες γραμμής/στήλης αρχής/τέλους με βάση το μηδέν. Η μέθοδος [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) αντίθετα δέχεται την επάνω γραμμή, αριστερή στήλη, κάτω γραμμή και δεξιά στήλη. Το παράδειγμα χρησιμοποιεί δείκτη γραμμής 55 και δείκτη στήλης 25 ως κάτω‑δεξιά όρια· αυτές οι τιμές είναι επιλογές διάταξης, όχι ο αριθμός των γραμμών ή στηλών δεδομένων.

Το πλαίσιο της διαφάνειας χρησιμοποιεί μονάδες σημείων. Το παράδειγμα το εντάσσει μέσα στη διαφάνεια και το κεντράρει διατηρώντας την αναλογία διαστάσεων του PNG, αντί να το τεντώσει ώστε να καλύψει ολόκληρη τη διαφάνεια.

## **Δημιουργία και Ενσωμάτωση του Διαγράμματος**

Το ακόλουθο πλήρες παράδειγμα γεμίζει το `DataSheet` με τέσσερις γραμμές και πέντε στήλες τιμών. Κάθε γραμμή γίνεται σειρά διαγράμματος. Το `ChartSheet` επιλέγεται ως ενεργό φύλλο πριν αποθηκευτεί το βιβλίο εργασίας.

Το βιβλίο εργασίας αποθηκεύεται ρητά ως XLSX, ταιριάζοντας με την επέκταση `xlsx` που περνάται στο [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Τα αποτελέσματα αριθμών Java μετατρέπονται με `java_values` πριν το PHP κάνει αριθμητικές πράξεις, ενώ τα δυαδικά δεδομένα παραμένουν σε πίνακες byte Java. Το PNG φορτώνεται απευθείας από τα byte του χωρίς ενδιάμεση μετατροπή bitmap. Η ανάθεση μέσω της μεθόδου [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) αντικαθιστά την προεπιλεγμένη θέση αντικειμένου OLE.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Διατηρήστε το PNG και το XLSX ως byte array Java κατά τη μεταφορά τους στο Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Προσαρμόστε και κεντράρετε την προεπισκόπηση διατηρώντας την αναλογία διαστάσεών της.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Αναμενόμενο Αποτέλεσμα**

`OutputChart.pptx` περιέχει μία διαφάνεια με ενσωματωμένο βιβλίο εργασίας Excel και προεπισκόπηση διαγράμματος. Το βιβλίο εργασίας περιέχει τα αρχικά δεδομένα και ένα διάγραμμα στήλης με τέσσερις σειρές. Η προεπισκόπηση κεντρική στη διαφάνεια και διατηρεί τις αναλογίες της.

![Διάγραμμα στήλης Excel που εμφανίζεται ως προεπισκόπηση ενός ενσωματωμένου βιβλίου εργασίας](excel-chart-ole-preview.png)

Σε περιβάλλον PowerPoint σε υπολογιστή με εγκατεστημένο Excel, κάντε διπλό κλικ στο αντικείμενο για ενεργοποίηση και επεξεργασία του ενσωματωμένου βιβλίου εργασίας. Η ενεργοποίηση και η επεξεργασία εξαρτώνται από την υποστήριξη OLE και τις ρυθμίσεις ασφαλείας της εφαρμογής φιλοξενίας.

## **Συχνές Ερωτήσεις**

**Γιατί χρειάζεται εικόνα προεπισκόπησης;**

Το ενσωματωμένο βιβλίο εργασίας και η προεπισκόπηση στη διαφάνεια είναι ξεχωριστό περιεχόμενο. Παρέχετε μια εικόνα διαγράμματος ώστε η διαφάνεια να εμφανίζει το διάγραμμα αντί της προεπιλεγμένης ετικέτας «EMBEDDED OLE OBJECT». Δείτε το [Problem Preview Object when Adding OleObjectFrame](/slides/el/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Ενημερώνεται αυτόματα η προεπισκόπηση όταν αλλάζω το βιβλίο εργασίας μέσω κώδικα;**

Αντιμετωπίστε την προεπισκόπηση ως στιγμιότυπο. Όταν ενημερώνετε τα δεδομένα του βιβλίου εργασίας προγραμματικά, δημιουργήστε ξανά την εικόνα του διαγράμματος και αντικαταστήστε τόσο την προεπισκόπηση όσο και τα ενσωματωμένα δεδομένα του βιβλίου εργασίας.

**Μπορώ να χρησιμοποιήσω XLS αντί για XLSX;**

Ναι. Αποθηκεύστε το βιβλίο εργασίας σε μορφή XLS και χρησιμοποιήστε `xls` ως επέκταση ενσωματωμένων δεδομένων. Η επέκταση πρέπει να ταιριάζει με τη μορφή του πραγματικού βιβλίου εργασίας· η αλλαγή μόνο της επέκτασης δεν μετατρέπει τα δεδομένα.

**Γιατί το αντικείμενο μπορεί να αλλάξει μέγεθος μετά την ενεργοποίηση;**

Η εφαρμογή φιλοξενίας μπορεί να ενημερώσει την παρουσίαση του αντικειμένου OLE όταν ενεργοποιείται το βιβλίο εργασίας. Το εύρος εμφάνισης OLE του βιβλίου εργασίας και οι διαστάσεις του πλαισίου στη διαφάνεια έχουν σημασία. Δείτε το [Working Solution for Chart Resizing in PPTX](/slides/el/java/working-solution-for-chart-resizing-in-pptx/).

## **Σχετικές Ενότητες**

- [Working Solution for Chart Resizing in PPTX](/slides/el/java/working-solution-for-chart-resizing-in-pptx/)
- [Problem Preview Object when Adding OleObjectFrame](/slides/el/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Manage OLE Objects](/slides/el/php-java/manage-ole/)