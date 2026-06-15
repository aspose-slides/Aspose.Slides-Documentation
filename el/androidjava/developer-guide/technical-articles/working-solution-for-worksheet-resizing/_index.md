---
title: Λύση Εργασίας για Αλλαγή Μεγέθους Φύλλου Εργασίας
type: docs
weight: 20
url: /el/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- εικόνα προεπισκόπησης
- αλλαγή μεγέθους εικόνας
- Excel
- φύλλο εργασίας
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διορθώστε την αλλαγή μεγέθους OLE φύλλου εργασίας Excel σε παρουσιάσεις: δύο τρόποι για να διατηρήσετε τα πλαίσια αντικειμένων συνεπή—κλιμακώνστε το πλαίσιο ή το φύλλο—στους μορφές PPT και PPTX."
---
{{% alert color="primary" %}}
Έχει παρατηρηθεί ότι τα φύλλα εργασίας του Excel ενσωματωμένα ως αντικείμενα OLE σε παρουσίαση PowerPoint μέσω των συ components του Aspose αλλάζουν μέγεθος σε άγνωστη κλίμακα μετά την πρώτη ενεργοποίηση. Αυτή η συμπεριφορά δημιουργεί εμφανή οπτική διαφορά στην παρουσίαση μεταξύ των καταστάσεων πριν και μετά την ενεργοποίηση του αντικειμένου OLE. Εξετάσαμε λεπτομερώς αυτό το ζήτημα και παρείχαμε μια λύση, η οποία καλύπτεται σε αυτό το άρθρο.
{{% /alert %}}

## **Ιστορικό**

Στο άρθρο [Διαχείριση OLE](/slides/el/androidjava/manage-ole/), εξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for Android μέσω Java. Για την αντιμετώπιση του [προβλήματος προεπισκόπησης αντικειμένου](/slides/el/androidjava/object-preview-issue-when-adding-oleobjectframe/), εκχωρήσαμε μια εικόνα της επιλεγμένης περιοχής του φύλλου εργασίας στο πλαίσιο του αντικειμένου OLE. Στην τελική παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο του αντικειμένου OLE που εμφανίζει την εικόνα του φύλλου, ενεργοποιείται το βιβλίο εργασίας Excel. Οι τελικοί χρήστες μπορούν να κάνουν τυχόν επιθυμητές αλλαγές στο πραγματικό βιβλίο εργασίας Excel και στη συνέχεια να επιστρέψουν στη διαφάνεια κάνοντας κλικ έξω από το ενεργό βιβλίο εργασίας Excel. Το μέγεθος του πλαισίου του αντικειμένου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο παράγοντας αλλαγής μεγέθους θα ποικίλει ανάλογα με το μέγεθος του πλαισίου του αντικειμένου OLE και το ενσωματωμένο βιβλίο εργασίας Excel.

## **Αιτία αλλαγής μεγέθους**

Δεδομένου ότι το βιβλίο εργασίας Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο του αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν ενεργοποιείται το βιβλίο εργασίας Excel, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διατηρήσουν τις σωστές αναλογίες ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους γίνεται με βάση τις διαφορές μεταξύ του μεγέθους του παραθύρου του Excel και του μεγέθους και της θέσης του πλαισίου του αντικειμένου OLE.

## **Λύση**

Υπάρχουν δύο πιθανά λύσεις για την αποφυγή του φαινομένου αλλαγής μεγέθους.

- Κλιμακώστε το μέγεθος του πλαισίου OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το ύψος και το πλάτος του επιθυμητού αριθμού γραμμών και στήλων στο πλαίσιο OLE.
- Διατηρήστε το μέγεθος του πλαισίου OLE σταθερό και κλιμακώστε το μέγεθος των συμμετέχοντων γραμμών και στηλών ώστε να χωρέσει στο επιλεγμένο μέγεθος πλαισίου OLE.

### **Κλιμάκωση του Μεγέθους Πλαισίου OLE**

Σε αυτήν την προσέγγιση, θα μάθουμε πώς να ορίσουμε το μέγεθος του πλαισίου OLE του ενσωματωμένου βιβλίου εργασίας Excel ώστε να ταιριάζει με το συνολικό μέγεθος των συμμετέχοντων γραμμών και στηλών στο φύλλο εργασίας Excel.

Ας υποθέσουμε ότι έχουμε ένα πρότυπο φύλλο Excel και θέλουμε να το προσθέσουμε σε μια παρουσίαση ως πλαίσιο OLE. Σε αυτό το σενάριο, το μέγεθος του πλαισίου του αντικειμένου OLE θα υπολογιστεί πρώτα με βάση το άθροισμα των υψών των γραμμών και των πλάτων των στηλών των συμμετέχοντων γραμμών και στηλών στο βιβλίο εργασίας. Στη συνέχεια, θα ορίσουμε το μέγεθος του πλαισίου OLE σε αυτήν την υπολογισμένη τιμή. Για να αποτρέψουμε το κόκκινο μήνυμα «EMBEDDED OLE OBJECT» για το πλαίσιο OLE στο PowerPoint, θα καταγράψουμε επίσης μια εικόνα των επιθυμητών τμημάτων των γραμμών και των στηλών στο βιβλίο εργασίας και θα τη ορίσουμε ως εικόνα του πλαισίου OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Ορίστε το εμφανιζόμενο μέγεθος όταν το αρχείο βιβλίου εργασίας χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Λάβετε το πλάτος και το ύψος της εικόνας OLE σε σημεία.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Πρέπει να χρησιμοποιήσουμε το τροποποιημένο βιβλίο εργασίας.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Κλιμάκωση του Μεγέθους Περιοχής Κελιών**

Σε αυτήν την προσέγγιση, θα μάθουμε πώς να κλιμακώσουμε τα ύψη των συμμετέχοντων γραμμών και το πλάτος των συμμετέχων στηλών ώστε να ταιριάζουν με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Ας υποθέσουμε ότι έχουμε ένα πρότυπο φύλλο Excel και θέλουμε να το προσθέσουμε σε μια παρουσίαση ως πλαίσιο OLE. Σε αυτό το σενάριο, θα ορίσουμε το μέγεθος του πλαισίου OLE και θα κλιμακώσουμε το μέγεθος των γραμμών και των στηλών που συμμετέχουν στην περιοχή του πλαισίου OLE. Στη συνέχεια, θα αποθηκεύσουμε το βιβλίο εργασίας σε μια ροή για να εφαρμόσουμε τις αλλαγές και θα το μετατρέψουμε σε πίνακα byte για να το προσθέσουμε στο πλαίσιο OLE. Για να αποτρέψουμε το κόκκινο μήνυμα «EMBEDDED OLE OBJECT» για το πλαίσιο OLE στο PowerPoint, θα καταγράψουμε επίσης μια εικόνα των επιθυμητών τμημάτων των γραμμών και των στηλών στο βιβλίο εργασίας και θα τη ορίσουμε ως εικόνα του πλαισίου OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Ορίστε το εμφανιζόμενο μέγεθος όταν το αρχείο βιβλίου εργασίας χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Κλιμακάστε το εύρος κελιών ώστε να ταιριάζει με το μέγεθος του πλαισίου.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Πρέπει να χρησιμοποιήσουμε το τροποποιημένο βιβλίο εργασίας.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Προσθέστε την εικόνα OLE στους πόρους της παρουσίασης.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Δημιουργήστε το πλαίσιο αντικειμένου OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     Το αναμενόμενο πλάτος του εύρους κελιών σε σημεία.
 * @param height    Το αναμενόμενο ύψος του εύρους κελιών σε σημεία.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Συμπέρασμα**

{{% alert color="primary" %}} 
Υπάρχουν δύο προσεγγίσεις για την επίλυση του προβλήματος αλλαγής μεγέθους του φύλλου εργασίας. Η επιλογή της κατάλληλης προσέγχη εξαρτάται από τις συγκεκριμένες απαιτήσεις και τη χρήση. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από την αρχή. Επιπλέον, δεν υπάρχει περιορισμός στο μέγεθος του πλαισίου του αντικειμένου OLE σε αυτήν τη λύση.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Γιατί ένα ενσωματωμένο φύλλο εργασίας Excel αλλάζει μέγεθος όταν ενεργοποιείται για πρώτη φορά στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος του παραθύρου όταν ενεργοποιείται, ενώ το πλαίσιο του αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει την αλλαγή μεγέθους.

**Μπορεί να αποτραπεί πλήρως αυτό το πρόβλημα αλλαγής μεγέθους;**

Ναι. Με την κλιμάκωση του πλαισίου OLE ώστε να ταιριάζει με το μέγεθος της περιοχής κελιών του Excel ή με την κλιμάκωση της περιοχής κελιών ώστε να ταιριάζει με το επιθυμητό μέγεθος πλαισίου OLE, μπορείτε να αποτρέψετε την ανεπιθύμητη αλλαγή μεγέθους.

**Ποια μέθοδο κλιμάκωσης πρέπει να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση περιοχής κελιών;**

Επιλέξτε **OLE frame scaling** εάν θέλετε να διατηρήσετε τα αρχικά μεγέθη των γραμμών και των στηλών του Excel. Επιλέξτε **cell range scaling** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργούν αυτές οι λύσεις αν η παρουσίασή μου βασίζεται σε πρότυπο;**

Ναι. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα και από την αρχή.

**Υπάρχει όριο στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**

Όχι. Μπορείτε να ορίσετε οποιοδήποτε μέγεθος στο πλαίσιο του αντικειμένου OLE, αρκεί να ρυθμίσετε την κλίμακα σωστά.

**Υπάρχει τρόπος να αποφευχθεί το κείμενο κράτησης θέσης «EMBEDDED OLE OBJECT» στο PowerPoint;**

Ναι. Καταγράφοντας μια εικόνα της επιλεγμένης περιοχής κελιών του Excel και ορίζοντάς την ως εικόνα κράτησης θέσης του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη εικόνα προεπισκόπησης αντί της προεπιλεγμένης κράτησης θέσης.