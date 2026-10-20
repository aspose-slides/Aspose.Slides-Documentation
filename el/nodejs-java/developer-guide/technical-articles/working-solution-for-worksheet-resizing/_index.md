---
title: Λύση για την Αλλαγή Μεγέθους Φύλλου Εργασίας
type: docs
weight: 20
url: /el/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- εικόνα προεπισκόπησης
- αλλαγή μεγέθους εικόνας
- Excel
- φύλλο εργασίας
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διορθώστε την αλλαγή μεγέθους OLE φύλλου εργασίας Excel σε παρουσιάσεις: δύο τρόποι για να διατηρήσετε σταθερά τα πλαίσια αντικειμένων—κλιμακώνετε το πλαίσιο ή το φύλλο—σε μορφές PPT και PPTX."
---
{{% alert color="info" title="Note" %}}

Τα φύλλα εργασίας του Excel ενσωματωμένα ως αντικείμενα OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας τα εξαρτήματα Aspose μπορεί να αλλάζουν μέγεθος απροσδόκητα μετά την πρώτη ενεργοποίησή τους. Αυτή η συμπεριφορά δημιουργεί μια εμφανή οπτική διαφορά μεταξύ του αντικειμένου OLE πριν και μετά την ενεργοποίηση. Αυτό το άρθρο εξηγεί το πρόβλημα και περιγράφει δύο τρόπους αντιμετώπισής του.

{{% /alert %}}

## **Ιστορικό**

Στο άρθρο [Διαχείριση OLE](/slides/el/nodejs-java/manage-ole/), εξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for Node.js via Java. Για την αντιμετώπιση του [προβλήματος προεπισκόπησης αντικειμένου](/slides/el/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε μια εικόνα της επιλεγμένης περιοχής του φύλλου εργασίας στο πλαίσιο του αντικειμένου OLE. Στην παραγόμενη παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο OLE που εμφανίζει την εικόνα του φύλλου εργασίας, ενεργοποιείται το βιβλίο εργασίας του Excel. Οι τελικοί χρήστες μπορούν να κάνουν οποιεσδήποτε επιθυμητές αλλαγές στο πραγματικό βιβλίο εργασίας του Excel και μετά να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας. Το μέγεθος του πλαισίου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο παράγοντας αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου OLE και του ενσωματωμένου βιβλίου εργασίας του Excel.

## **Αιτία της Αλλαγής Μεγέθους**

Επειδή το βιβλίο εργασίας του Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν ενεργοποιείται το βιβλίο εργασίας του Excel, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διατηρεί τις σωστές αναλογίες ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους συμβαίνει βάσει των διαφορών μεταξύ του μεγέθους του παραθύρου του Excel και του μεγέθους και της θέσης του πλαισίου αντικειμένου OLE.

## **Λύση**

Υπάρχουν δύο πιθανές λύσεις για την αποφυγή του φαινομένου αλλαγής μεγέθους.

- Κλιμάκωση του πλαισίου OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στηλών.
- Διατήρηση του μεγέθους του πλαισίου OLE σταθερό και κλιμάκωση των επιλεγμένων γραμμών και στηλών ώστε να ταιριάζουν μέσα του.

### **Κλιμάκωση του Μεγέθους του Πλαισίου OLE**

Αυτή η προσέγγιση ορίζει το μέγεθος του πλαισίου OLE ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στηλών στο ενσωματωμένο φύλλο εργασίας του Excel.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας του Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες με βάση το 0. Η μέθοδος [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) ορίζει το εμφανιζόμενο εύρος. Η προεπισκόπηση αποδίδεται στα 96 DPI και οι διαστάσεις των εικονοματών μετατρέπονται σε σημεία χρησιμοποιώντας 72 σημεία ανά ίντσα. Η μέθοδος [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) ενσωματώνει το τροποποιημένο βιβλίο εργασίας σε ένα πλαίσιο με αυτές τις διαστάσεις. Η προεπισκόπηση αντιστοιχίζεται μέσω της [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) για να αντικαταστήσει το χώρο κράτησης "EMBEDDED OLE OBJECT" στην αποθηκευμένη παρουσίαση.

Εγκαταστήστε τα πακέτα `aspose.cells`, `aspose.slides.via.java` και `java` και τοποθετήστε το `sample.xlsx` στον φάκελο εργασίας. Για κάθε προσέγγιση, εκτελέστε πρώτα το σενάριο προετοιμασίας και, στη συνέχεια, το σενάριο ενσωμάτωσης σε μια ξεχωριστή διεργασία Node.js στον ίδιο φάκελο. Τα δύο πακέτα Aspose αρχικοποιούν τη γέφυρα Java ξεχωριστά.

Αποθηκεύστε αυτό το σενάριο προετοιμασίας ως `prepare-frame-scaled.js` και εκτελέστε το με `node prepare-frame-scaled.js`. Θα γράψει τα αρχεία `frame-scaled.xlsx` και `frame-scaled.png`.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// Όλη η συγχρονισμένη εργασία ολοκληρώθηκε· σταματήστε τη διαδικασία γέφυρας Java.
process.exit(0);
```

Αποθηκεύστε αυτό το σενάριο ενσωμάτωσης ως `embed-frame-scaled.js` και εκτελέστε το με `node embed-frame-scaled.js`. Θα διαβάσει εκείνα τα αρχεία και θα γράψει το `frame-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// Όλη η συγχρονισμένη εργασία ολοκληρώθηκε· σταματήστε τη διαδικασία γέφυρας Java.
process.exit(0);
```

Ο βοηθός προεπισκόπησης ορίζει το [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) στο επιλεγμένο εύρος και αφαιρεί περιθώρια, κεφαλίδες και υποσέλιδα. Με την ενεργοποίηση της [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea), η μέθοδος [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) αποδίδει το εύρος ως εικόνα PNG. Ο βοηθός αποθηκεύει την εικόνα PNG σε αρχείο για χρήση στην παρουσίαση.

### **Κλιμάκωση του Μεγέθους της Περιοχής Κελών**

Αυτή η προσέγγιση κλιμακώνει τα ύψη των επιλεγμένων γραμμών και τα πλάτη των επιλεγμένων στηλών ώστε να ταιριάζουν με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας του Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες με βάση το 0. Η μέθοδος [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) ορίζει το εμφανιζόμενο εύρος, και ο βοηθός κλιμακώνει αυτό το εύρος ώστε να χωρά σε ένα πλαίσιο 400 σημεία πλάτος και 100 σημεία ύψος. Μετά την αποθήκευση του τροποποιημένου βιβλίου εργασίας σε αρχείο, η μέθοδος [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) το ενσωματώνει στο καθορισμένο μέγεθος. Μια προεπισκόπηση αποδίδεται στα 96 DPI μέσω της [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), έτσι ώστε η αποθηκευμένη παρουσίαση να εμφανίζει τα επιλεγμένα κελιά αντί του προεπιλεγμένου χώρου κράτησης.

Αποθηκεύστε αυτό το σενάριο προετοιμασίας ως `prepare-cells-scaled.js` και εκτελέστε το με `node prepare-cells-scaled.js`. Θα γράψει τα αρχεία `cells-scaled.xlsx` και `cells-scaled.png`.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// Όλη η συγχρονισμένη εργασία ολοκληρώθηκε· σταματήστε τη διαδικασία γέφυρας Java.
process.exit(cellsPrepared ? 0 : 1);
```

Αποθηκεύστε αυτό το σενάριο ενσωμάτωσης ως `embed-cells-scaled.js` και εκτελέστε το με `node embed-cells-scaled.js`. Θα διαβάσει εκείνα τα αρχεία και θα γράψει το `cells-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// Όλη η συγχρονισμένη εργασία ολοκληρώθηκε· σταματήστε τη διαδικασία γέφυρας Java.
process.exit(0);
```

Ο βοηθός κλιμάκωσης υπολογίζει ξεχωριστούς λόγους πλάτους και ύψους για το επιλεγμένο εύρος, διατηρώντας τις σχετικές αναλογίες των στηλών και των γραμμών του. Μετατρέπει τις υπολογιζόμενες διαστάσεις από σημεία σε ίντσες πριν τις εφαρμόσει μέσω των [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) και [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). Το επιλεγμένο εύρος πρέπει να έχει μη μηδενικό πλάτος και ύψος.

Αυτός ο βοηθός προεπισκόπησης αποδίδει το κλιμακωμένο εύρος χρησιμοποιώντας τη [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Περιορίζει το [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) σε αυτό το εύρος, αφαιρεί περιθώρια, κεφαλίδες και υποσέλιδα, και αποθηκεύει την εικόνα PNG σε αρχείο.

## **Συμπέρασμα**

{{% alert color="info" title="Note" %}}

Υπάρχουν δύο προσεγγίσεις για την επίλυση του ζητήματος αλλαγής μεγέθους των φύλλων εργασίας. Επιλέξτε την προσέγγιση που ταιριάζει καλύτερα στις απαιτήσεις και τη χρήση σας. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από το μηδέν. Επιπλέον, δεν υπάρχει περιορισμός στο μέγεθος του πλαισίου OLE σε αυτή τη λύση.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Γιατί ένα ενσωματωμένο φύλλο εργασίας του Excel αλλάζει μέγεθος όταν ενεργοποιείται για πρώτη φορά στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος του παραθύρου κατά την ενεργοποίηση, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει την αλλαγή μεγέθους.

**Μπορεί να αποφευχθεί εντελώς αυτό το πρόβλημα αλλαγής μεγέθους;**

Ναι. Κλιμακώνοντας το πλαίσιο OLE ώστε να ταιριάζει με το μέγεθος της περιοχής κελιών του Excel ή κλιμακώνοντας την περιοχή κελιών ώστε να ταιριάζει με το επιθυμητό μέγεθος του πλαισίου OLE, μπορείτε να αποτρέψετε ανεπιθύμητες αλλαγές μεγέθους.

**Ποια μέθοδο κλιμάκωσης πρέπει να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση περιοχής κελιών;**

Επιλέξτε **κλιμάκωση πλαισίου OLE** εάν θέλετε να διατηρήσετε τα αρχικά μεγέθη των γραμμών και στηλών του Excel. Επιλέξτε **κλιμάκωση περιοχής κελιών** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργούν αυτές οι λύσεις εάν η παρουσίασή μου βασίζεται σε πρότυπο;**

Ναί. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα και από το μηδέν.

**Υπάρχει όριο στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**

Όχι. Μπορείτε να δημιουργήσετε το πλαίσιο αντικειμένου OLE σε οποιοδήποτε μέγεθος, εφόσον ρυθμίσετε τη κλιμάκωση κατάλληλα.

**Υπάρχει τρόπος να αποφευχθεί το κείμενο χώρου κράτησης "EMBEDDED OLE OBJECT" στο PowerPoint;**

Ναί. Λαμβάνοντας μια στιγμιότυπη εικόνα της επιλεγμένης περιοχής κελιών του Excel και ορίζοντας την ως εικόνα θέσης κράτησης του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη εικόνα προεπισκόπησης αντί του προεπιλεγμένου χώρου κράτησης.

## **Σχετικά Άρθρα**

[Δημιουργία Γραφήματος Excel και Ενσωμάτωση του σε Παρουσίαση ως Αντικείμενο OLE](/slides/el/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Αυτόματη Ενημέρωση Αντικειμένων OLE με Χρήση Πρόσθετου MS PowerPoint](/slides/el/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)