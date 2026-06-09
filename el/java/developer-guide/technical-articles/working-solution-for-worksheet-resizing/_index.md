---
title: Λύση Εργασίας για την Αλλαγή Μεγέθους Φύλλου Εργασίας
type: docs
weight: 20
url: /el/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- εικόνα προεπισκόπησης
- αλλαγή μεγέθους εικόνας
- Excel
- φύλλο εργασίας
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Διορθώστε την αλλαγή μεγέθους OLE του φύλλου εργασίας Excel σε παρουσιάσεις: δύο τρόποι για να διατηρήσετε σταθερά τα πλαίσια αντικειμένων—να κλιμακώσετε το πλαίσιο ή το φύλλο—σε μορφές PPT και PPTX."
---
{{% alert color="primary" %}}

Έχει παρατηρηθεί ότι τα φύλλα εργασίας Excel ενσωματωμένα ως αντικείμενα OLE σε μια παρουσίαση PowerPoint μέσω των στοιχείων Aspose αλλάζουν μέγεθος σε άγνωστη κλίμακα μετά την πρώτη ενεργοποίηση. Αυτή η συμπεριφορά δημιουργεί οπτική διαφορά στην παρουσίαση μεταξύ των καταστάσεων προ‑και μετά‑ενεργοποίησης του αντικειμένου OLE. Έχουμε διερευνήσει λεπτομερώς το πρόβλημα και παρέχουμε λύση, η οποία καλύπτεται σε αυτό το άρθρο.

{{% /alert %}}

## **Ιστορικό**

Στο άρθρο [Διαχείριση OLE](/slides/el/java/manage-ole/), εξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for Java. Για την αντιμετώπιση του [προβλήματος προεπισκόπησης αντικειμένου](/slides/el/java/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε μια εικόνα της επιλεγμένης περιοχής του φύλλου εργασίας στο πλαίσιο αντικειμένου OLE. Στην έξοδο παρουσίασης, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του φύλλου, ενεργοποιείται το βιβλίο εργασίας Excel. Οι τελικοί χρήστες μπορούν να πραγματοποιήσουν οποιεσδήποτε επιθυμητές αλλαγές στο πραγματικό βιβλίο εργασίας Excel και στη συνέχεια να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας Excel. Το μέγεθος του πλαισίου αντικειμένου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο παράγοντας αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου αντικειμένου OLE και του ενσωματωμένου βιβλίου εργασίας Excel.

## **Αιτία Αλλαγής Μεγέθους**

Δεδομένου ότι το βιβλίο εργασίας Excel διαθέτει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διασφαλίζουν ότι διατηρεί τις σωστές αναλογίες ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους πραγματοποιείται βάσει των διαφορών μεταξύ του μεγέθους του παραθύρου Excel και του μεγέθους και της θέσης του πλαισίου αντικειμένου OLE.

## **Λύση Εργασίας**

Υπάρχουν δύο δυνατές λύσεις για την αποφυγή του φαινομένου αλλαγής μεγέθους.

- Κλιμακώστε το μέγεθος του πλαισίου OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το ύψος και το πλάτος του επιθυμητού αριθμού γραμμών και στηλών στο πλαίσιο OLE.
- Διατηρήστε το μέγεθος του πλαισίου OLE σταθερό και κλιμακώστε το μέγεθος των συμμετεχουσών γραμμών και στηλών ώστε να χωράει μέσα στο επιλεγμένο μέγεθος πλαισίου OLE.

### **Κλιμάκωση Μεγέθους Πλαισίου OLE**

Σε αυτήν την προσέγγιση, θα μάθουμε πώς να ορίσουμε το μέγεθος πλαισίου OLE του ενσωματωμένου βιβλίου εργασίας Excel ώστε να ταιριάζει με το συνολικό μέγεθος των συμμετεχουσών γραμμών και στηλών στο φύλλο εργασίας Excel.

Ας υποθέσουμε ότι διαθέτουμε ένα πρότυπο φύλλο Excel και θέλουμε να το προσθέσουμε σε μια παρουσίαση ως πλαίσιο OLE. Σε αυτό το σενάριο, το μέγεθος του πλαισίου αντικειμένου OLE θα υπολογιστεί αρχικά με βάση το συνολικό ύψος των γραμμών και το πλάτος των στηλών των συμμετεχουσών γραμμών και στηλών στο βιβλίο εργασίας. Στη συνέχεια, θα ορίσουμε το μέγεθος του πλαισίου OLE σε αυτήν την υπολογισμένη τιμή. Για να αποφύγουμε το κόκκινο μήνυμα «EMBEDDED OLE OBJECT» για το πλαίσιο OLE στο PowerPoint, θα καταγράψουμε επίσης μια εικόνα των επιθυμητών τμημάτων των γραμμών και στηλών στο βιβλίο εργασίας και θα τη θέσουμε ως εικόνα πλαισίου OLE.

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

// Λάβετε το πλάτος και το ύψος της εικόνας OLE σε μονάδες point.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Πρέπει να χρησιμοποιήσουμε το τροποποιημένο βιβλίο εργασίας.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Προσθέστε την εικόνα OLE στους πόρους της παρουσίασης.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Δημιουργήστε το πλαίσιο αντικειμένου OLE.
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

### **Κλιμάκωση Μεγέθους Περιοχής Κελιών**

Σε αυτήν την προσέγγιση, θα μάθουμε πώς να κλιμακώσουμε τα ύψη των συμμετεχουσών γραμμών και το πλάτος των συμμετεχουσών στηλών ώστε να ταιριάζουν με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Ας υποθέσουμε ότι διαθέτουμε ένα πρότυπο φύλλο Excel και θέλουμε να το προσθέσουμε σε μια παρουσίαση ως πλαίσιο OLE. Σε αυτό το σενάριο, θα ορίσουμε το μέγεθος του πλαισίου OLE και θα κλιμακώσουμε το μέγεθος των γραμμών και στηλών που συμμετέχουν στην περιοχή του πλαισίου OLE. Στη συνέχεια, θα αποθηκεύσουμε το βιβλίο εργασίας σε ροή για να εφαρμόσουμε τις αλλαγές και θα το μετατρέψουμε σε πίνακα byte για να το προσθέσουμε στο πλαίσιο OLE. Για να αποφύγουμε το κόκκινο μήνυμα «EMBEDDED OLE OBJECT» για το πλαίσιο OLE στο PowerPoint, θα καταγράψουμε επίσης μια εικόνα των επιθυμητών τμημάτων των γραμμών και στηλών στο βιβλίο εργασίας και θα τη θέσουμε ως εικόνα πλαισίου OLE.

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

// Κλιμακώστε την περιοχή κελιών ώστε να ταιριάζει με το μέγεθος του πλαισίου.
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

Υπάρχουν δύο προσεγγίσεις για την επίλυση του προβλήματος αλλαγής μεγέθους του φύλλου εργασίας. Η επιλογή της κατάλληλης προσέγγισης εξαρτάται από τις συγκεκριμένες απαιτήσεις και την περίπτωση χρήσης. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από το μηδέν. Επιπλέον, δεν υπάρχει περιορισμός στο μέγεθος του πλαισίου αντικειμένου OLE σε αυτήν τη λύση.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Γιατί ένα ενσωματωμένο φύλλο εργασίας Excel αλλάζει μέγεθος όταν ενεργοποιείται για πρώτη φορά στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος του παραθύρου όταν ενεργοποιείται, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει την αλλαγή μεγέθους.

**Μπορεί να αποφευχθεί πλήρως το πρόβλημα αλλαγής μεγέθους;**

Ναι. Με το να κλιμακώσετε το πλαίσιο OLE ώστε να ταιριάζει με το μέγεθος της περιοχής κελιών του Excel ή με το να κλιμακώσετε την περιοχή κελιών ώστε να ταιριάζει με το επιθυμητό μέγεθος πλαισίου OLE, μπορείτε να αποτρέψετε την ανεπιθύμητη αλλαγή μεγέθους.

**Ποια μέθοδο κλιμάκωσης πρέπει να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση περιοχής κελιών;**

Επιλέξτε **OLE frame scaling** εάν θέλετε να διατηρήσετε τα αρχικά μεγέθη γραμμών και στηλών του Excel. Επιλέξτε **cell range scaling** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργούν αυτές οι λύσεις αν η παρουσίασή μου βασίζεται σε πρότυπο;**

Ναι. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα και από το μηδέν.

**Υπάρχει όριο στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**

Όχι. Μπορείτε να ορίσετε το πλαίσιο αντικειμένου OLE σε οποιοδήποτε μέγεθος, αρκεί να καθορίσετε την κλίμακα σωστά.

**Υπάρχει τρόπος να αποφευχθεί το κείμενο placeholder "EMBEDDED OLE OBJECT" στο PowerPoint;**

Ναι. Με τη λήψη στιγμιότυπου της επιλεγμένης περιοχής κελιών του Excel και τη ρύθμιση του ως εικόνα placeholder του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη προεπισκόπηση αντί του προεπιλεγμένου placeholder.

## **Σχετικά Άρθρα**

[Δημιουργία Γραφήματος Excel και Ενσωμάτωση σε Παρουσίαση ως Αντικείμενο OLE](/slides/el/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Αυτόματη Ενημέρωση Αντικειμένων OLE Χρησιμοποιώντας Πρόσθετο MS PowerPoint](/slides/el/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)