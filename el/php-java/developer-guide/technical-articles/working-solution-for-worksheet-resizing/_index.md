---
title: Λειτουργική λύση για αλλαγή μεγέθους φύλλου εργασίας
type: docs
weight: 20
url: /el/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- εικόνα προεπισκόπησης
- αλλαγή μεγέθους εικόνας
- Excel
- φύλλο εργασίας
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διορθώστε την αλλαγή μεγέθους OLE φύλλου εργασίας Excel σε παρουσιάσεις: δύο τρόποι για να διατηρήσετε σταθερά τα πλαίσια αντικειμένων — κλιμακώνετε το πλαίσιο ή το φύλλο — σε μορφές PPT και PPTX."
---
{{% alert color="info" title="Σημείωση" %}}

Τα φύλλα εργασίας Excel που ενσωματώνονται ως αντικείμενα OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας τα στοιχεία Aspose ενδέχεται να αλλάξουν το μέγεθός τους απροσδόκητα μετά την πρώτη ενεργοποίηση. Αυτή η συμπεριφορά δημιουργεί μια αισθητή οπτική διαφορά μεταξύ του αντικειμένου OLE πριν και μετά την ενεργοποίηση. Το άρθρο αυτό εξηγεί το πρόβλημα και περιγράφει δύο τρόπους αντιμετώπισής του.

{{% /alert %}}

## **Ιστορικό**

Στο άρθρο [Διαχείριση OLE](/slides/el/php-java/manage-ole/), εξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for PHP μέσω Java. Για να αντιμετωπίσουμε το [πρόβλημα προεπισκόπησης αντικειμένου](/slides/el/php-java/object-preview-issue-when-adding-oleobjectframe/), εκχωρήσαμε μια εικόνα της επιλεγμένης περιοχής του φύλλου εργασίας στο πλαίσιο αντικειμένου OLE. Στην τελική παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του φύλλου εργασίας, το βιβλίο εργασίας Excel ενεργοποιείται. Οι τελικοί χρήστες μπορούν να κάνουν τις επιθυμητές αλλαγές στο πραγματικό βιβλίο εργασίας Excel και στη συνέχεια να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας Excel. Το μέγεθος του πλαισίου αντικειμένου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο παράγοντας αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου αντικειμένου OLE και του ενσωματωμένου βιβλίου εργασίας Excel.

## **Αιτία Αλλαγής Μεγέθους**

Δεδομένου ότι το βιβλίο εργασίας Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διασφαλίσουν ότι διατηρείται η σωστή αναλογία ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους συμβαίνει με βάση τις διαφορές μεταξύ του μεγέθους του παραθύρου του Excel και του μεγέθους και της θέσης του πλαισίου αντικειμένου OLE.

## **Λειτουργική Λύση**

Υπάρχουν δύο πιθανές λύσεις για να αποφύγετε το φαινόμενο αλλαγής μεγέθους.

- Κλιμακώστε το πλαίσιο OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στήλων.
- Διατηρήστε το μέγεθος του πλαισίου OLE σταθερό και κλιμακώστε τις επιλεγμένες γραμμές και στήλες ώστε να ταιριάζουν μέσα του.

### **Κλιμάκωση του Μεγέθους Πλαισίου OLE**

Αυτή η προσέγγιση ορίζει το μέγεθος του πλαισίου OLE ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στήλων στο ενσωματωμένο φύλλο εργασίας Excel.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες μηδενικής βάσης. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) ορίζει την εμφανιζόμενη περιοχή. Η προεπισκόπηση αποδίδεται σε 96 DPI και οι διαστάσεις των εικονοστοιχείων μετατρέπονται σε πόντους χρησιμοποιώντας 72 πόντους ανά ίντσα. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) ενσωματώνει το τροποποιημένο βιβλίο εργασίας σε ένα πλαίσιο με αυτές τις διαστάσεις. Η προεπισκόπηση εκχωρείται μέσω [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) για να αντικαταστήσει το σύμβολο κράτησης θέσης "EMBEDDED OLE OBJECT" στην αποθηκευμένη παρουσίαση.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Ενσωματώστε το τροποποιημένο βιβλίο εργασίας και διατηρήστε τα δυαδικά δεδομένα σε πίνακες byte της Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Ο βοηθός προεπισκόπησης ορίζει το [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) στην επιλεγμένη περιοχή και αφαιρεί τα περιθώρια, τις κεφαλίδες και τα υποσέλιδα. Με ενεργοποιημένο το [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea), το [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) αποδίδει την περιοχή ως εικόνα PNG. Ο βοηθός επιστρέφει ένα νέο ροή εισόδου που περιέχει την εικόνα PNG, τοποθετημένη στην αρχή της για χρήση στην παρουσίαση.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **Κλιμάκωση του Μεγέθους Περιοχής Κελιών**

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες μηδενικής βάσης. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) ορίζει την εμφανιζόμενη περιοχή, και ο παρακάτω βοηθός κλιμακώνει αυτήν την περιοχή ώστε να ταιριάζει σε ένα πλαίσιο 400 πόντων πλάτος και 100 πόντων ύψος. Μετά την αποθήκευση του τροποποιημένου βιβλίου εργασίας σε ροή, το [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) το ενσωματώνει στο καθορισμένο μέγεθος. Μια προεπισκόπηση αποδίδεται σε 96 DPI και εκχωρείται μέσω [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), ώστε η αποθηκευμένη παρουσίαση να εμφανίζει τα επιλεγμένα κελιά αντί του προεπιλεγμένου σύμβολου κράτησης θέσης.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Ενσωματώστε το τροποποιημένο βιβλίο εργασίας και διατηρήστε τα δυαδικά δεδομένα σε πίνακες byte της Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Ο βοηθός κλιμάκωσης υπολογίζει ξεχωριστές αναλογίες πλάτους και ύψους για την επιλεγμένη περιοχή, διατηρώντας τις σχετικές τιμές πλάτους των στηλών της και τις σχετικές τιμές ύψους των γραμμών της. Μετατρέπει τις υπολογισμένες διαστάσεις από πόντους σε ίντσες πριν τις εφαρμόσει με [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) και [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). Η επιλεγμένη περιοχή πρέπει να έχει μη μηδενικό πλάτος και ύψος.

```php
use aspose\cells\CellsUnitType;

// Το πλάτος και το ύψος είναι οι αναμενόμενες διαστάσεις της περιοχής κελιών σε πόντους.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

Αυτός ο βοηθός προεπισκόπησης αποδίδει την αλλαγμένη περιοχή χρησιμοποιώντας το [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Περιορίζει το [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) σε αυτήν την περιοχή, αφαιρεί τα περιθώρια, τις κεφαλίδες και τα υποσέλιδα, και επιστρέφει μια ροή PNG τοποθετημένη στην αρχή της.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **Συμπέρασμα**

{{% alert color="info" title="Σημείωση" %}}

Υπάρχουν δύο προσεγγίσεις για να διορθώσετε το πρόβλημα αλλαγής μεγέθους του φύλλου εργασίας. Επιλέξτε την προσέγγιση που ταιριάζει καλύτερα στις απαιτήσεις και την περίπτωσή σας. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από την αρχή. Επιπλέον, δεν υπάρχει όριο στο μέγεθος του πλαισίου αντικειμένου OLE σε αυτή τη λύση.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Γιατί ένα ενσωματωμένο φύλλο εργασίας Excel αλλάζει μέγεθος όταν ενεργοποιείται για πρώτη φορά στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος του παραθύρου όταν ενεργοποιείται, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει την αλλαγή μεγέθους.

**Μπορεί να αποτραπεί εντελώς αυτό το πρόβλημα αλλαγής μεγέθους;**

Ναι. Με το σχήμα κλιμάκωσης του πλαισίου OLE ώστε να ταιριάζει στο μέγεθος της περιοχής κελιών του Excel ή κλιμακώνοντας την περιοχή κελιών ώστε να ταιρίζεται στο επιθυμητό μέγεθος του πλαισίου OLE, μπορείτε να αποτρέψετε ανεπιθύμητες αλλαγές μεγέθους.

**Ποια μέθοδο κλιμάκωσης πρέπει να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση περιοχής κελιών;**

Επιλέξτε **OLE frame scaling** εάν θέλετε να διατηρήσετε τα αρχικά μεγέθη γραμμών και στηλών του Excel. Επιλέξτε **cell range scaling** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργούν αυτές οι λύσεις εάν η παρουσίασή μου βασίζεται σε πρότυπο;**

Ναί. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα και από την αρχή.

**Υπάρχει όριο στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**

Όχι. Μπορείτε να κάνετε το πλαίσιο αντικειμένου OLE οποιουδήποτε μεγέθους, εφόσον ορίσετε την κλίμακα κατάλληλα.

**Υπάρχει τρόπος να αποφευχθεί το κείμενο κράτησης θέσης "EMBEDDED OLE OBJECT" στο PowerPoint;**

Ναι. Με τη λήψη ενός στιγμιότυπου της επιλεγμένης περιοχής κελιών του Excel και ορίζοντάς το ως εικόνα κράτησης θέσης του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη εικόνα προεπισκόπησης αντί του προεπιλεγμένου σύμβολου κράτησης θέσης.

## **Σχετικά Άρθρα**

[Δημιουργία γραφήματος Excel και ενσωμάτωσή του σε παρουσίαση ως αντικείμενο OLE](/slides/el/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Αυτόματη ενημέρωση αντικειμένων OLE χρησιμοποιώντας πρόσθετο MS PowerPoint](/slides/el/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)