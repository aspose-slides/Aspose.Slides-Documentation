---
title: Λύση Λειτουργική για Αλλαγή Μεγέθους Φύλλου Εργασίας
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
description: "Διορθώστε την αλλαγή μεγέθους OLE φύλλου εργασίας Excel σε παρουσιάσεις: δύο τρόποι για να διατηρήσετε τα πλαίσια αντικειμένων συνεπή—κλιμακώστε το πλαίσιο ή το φύλλο—σε μορφές PPT και PPTX."
---
{{% alert color="info" title="Σημείωση" %}}

Τα φύλλα εργασίας του Excel ενσωματωμένα ως αντικείμενα OLE σε παρουσίαση PowerPoint χρησιμοποιώντας συστατικά Aspose μπορεί να αλλάξουν μέγεθος απροσδόκητα μετά την πρώτη ενεργοποίησή τους. Αυτή η συμπεριφορά δημιουργεί μια αισθητή οπτική διαφορά μεταξύ του αντικειμένου OLE πριν και μετά την ενεργοποίηση. Το άρθρο αυτό εξηγεί το πρόβλημα και περιγράφει δύο τρόπους αντιμετώπισής του.

{{% /alert %}}

## **Ιστορικό**

Στο άρθρο [Διαχείριση OLE](/slides/el/java/manage-ole/), εξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for Java. Για να αντιμετωπίσουμε το [πρόβλημα προεπισκόπησης αντικειμένου](/slides/el/java/object-preview-issue-when-adding-oleobjectframe/), εκχωρήσαμε μια εικόνα της επιλεγμένης περιοχής του φύλλου εργασίας στο πλαίσιο του αντικειμένου OLE. Στην παραγόμενη παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο του αντικειμένου OLE που εμφανίζει την εικόνα του φύλλου, το βιβλίο εργασίας του Excel ενεργοποιείται. Οι τελικοί χρήστες μπορούν να κάνουν όποιες αλλαγές στο πραγματικό βιβλίο εργασίας του Excel και, στη συνέχεια, να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας. Το μέγεθος του πλαισίου του αντικειμένου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο παράγοντας αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου του αντικειμένου OLE και του ενσωματωμένου βιβλίου εργασίας του Excel.

## **Αιτία Αλλαγής Μεγέθους**

Καθώς το βιβλίο εργασίας του Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο του αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας του Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διατηρείται η σωστή αναλογία ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους εμφανίζεται βάσει των διαφορών μεταξύ του μεγέθους του παραθύρου του Excel και του μεγέθους και της θέσης του πλαισίου του αντικειμένου OLE.

## **Λειτουργική Λύση**

Υπάρχουν δύο δυνατές λύσεις για την αποφυγή του φαινομένου αλλαγής μεγέθους.

- Κλιμάκωση του πλαισίου OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στηλών.
- Διατήρηση σταθερού μεγέθους του πλαισίου OLE και κλιμάκωση των επιλεγμένων γραμμών και στηλών ώστε να χωράνε μέσα σε αυτό.

### **Κλιμάκωση του Μεγέθους του Πλαισίου OLE**

Αυτή η προσέγγιση ορίζει το μέγεθος του πλαισίου OLE ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στηλών στο ενσωματωμένο φύλλο Excel.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες που ξεκινούν από το μηδέν. Η μέθοδος [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) ορίζει την εμφανιζόμενη περιοχή. Η προεπισκόπηση αποδίδεται σε 96 DPI και οι διαστάσεις της σε εικονοστοιχεία μετατρέπονται σε σημεία χρησιμοποιώντας 72 σημεία ανά ίντσα. Η μέθοδος [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ενσωματώνει το τροποποιημένο βιβλίο εργασίας σε ένα πλαίσιο με αυτές τις διαστάσεις. Η προεπισκόπηση εκχωρείται μέσω του [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) για να αντικαταστήσει τον υπόδειγμα κειμένου «EMBEDDED OLE OBJECT» στην αποθηκευμένη παρουσίαση.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Ορίστε το εμφανιζόμενο μέγεθος όταν το αρχείο εργασιακού βιβλίου χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Λάβετε το πλάτος και το ύψος της εικόνας OLE σε σημεία.
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

Ο βοηθός προεπισκόπησης ορίζει το [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) στην επιλεγμένη περιοχή και αφαιρεί τα περιθώρια, τις κεφαλίδες και τα υποσέλιδα. Με το [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) ενεργό, η μέθοδος [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) αποδίδει την περιοχή ως εικόνα PNG. Ο βοηθός επιστρέφει μια νέα ροή εισόδου που περιέχει την εικόνα PNG, τοποθετημένη στην αρχή της ροής για χρήση στην παρουσίαση.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

### **Κλιμάκωση της Περιοχής Κελιών**

Αυτή η προσέγγιση κλιμακώνει τα ύψη των επιλεγμένων γραμμών και το πλάτος των επιλεγμένων στηλών ώστε να ταιριάζει με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες που ξεκινούν από το μηδέν. Η μέθοδος [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) ορίζει την εμφανιζόμενη περιοχή, και ο παρακάτω βοηθός κλιμακώνει αυτήν την περιοχή ώστε να χωράει σε ένα πλαίσιο 400 σημεία πλάτος και 100 σημεία ύψος. Μετά την αποθήκευση του τροποποιημένου βιβλίου εργασίας σε ροή, η μέθοδος [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) το ενσωματώνει στο καθορισμένο μέγεθος. Μια προεπισκόπηση αποδίδεται σε 96 DPI και εκχωρείται μέσω του [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) ώστε η αποθηκευμένη παρουσίαση να εμφανίζει τα επιλεγμένα κελιά αντί του προεπιλεγμένου υπόδειγματος.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

// Κλιμακώστε την περιοχή κελιών ώστε να ταιριάζει στο μέγεθος του πλαισίου.
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

Ο βοηθός κλιμάκωσης υπολογίζει ξεχωριστούς λόγους πλάτους και ύψους για την επιλεγμένη περιοχή, διατηρώντας τις σχετικές αναλογίες των στηλών της και των γραμμών της. Μετατρέπει τις υπολογισμένες διαστάσεις από σημεία σε ίντσες πριν τις εφαρμόσει με τις μεθόδους [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) και [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Η επιλεγμένη περιοχή πρέπει να έχει μη μηδενικό πλάτος και ύψος.

```java
/**
 * @param width     Το αναμενόμενο πλάτος της περιοχής κελιών σε σημεία.
 * @param height    Το αναμενόμενο ύψος της περιοχής κελιών σε σημεία.
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

Αυτός ο βοηθός προεπισκόπησης αποδίδει την κλιμακωμένη περιοχή χρησιμοποιώντας τη μέθοδο [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Περιορίζει το [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) σε αυτήν την περιοχή, αφαιρεί τα περιθώρια, τις κεφαλίδες και τα υποσέλιδα, και επιστρέφει μια ροή PNG τοποθετημένη στην αρχή της ροής.

```java
/**
 * @param width     Το αναμενόμενο πλάτος της περιοχής κελιών σε σημεία.
 * @param height    Το αναμενόμενο ύψος της περιοχής κελιών σε σημεία.
 */
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

{{% alert color="info" title="Σημείωση" %}}

Υπάρχουν δύο προσεγγίσεις για τη διόρθωση του προβλήματος αλλαγής μεγέθους του φύλλου εργασίας. Επιλέξτε την προσέγγιση που ταιριάζει καλύτερα στις απαιτήσεις και τη χρήση σας. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από το μηδέν. Επιπλέον, δεν υπάρχει περιορισμός στο μέγεθος του πλαισίου OLE σε αυτή τη λύση.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Γιατί ένα ενσωματωμένο φύλλο εργασίας Excel αλλάζει μέγεθος όταν ενεργοποιείται για πρώτη φορά στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος του παραθύρου κατά την ενεργοποίηση, ενώ το πλαίσιο του αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρηθεί η αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει αλλαγή μεγέθους.

**Μπορεί να αποτραπεί εντελώς αυτό το πρόβλημα αλλαγής μεγέθους;**

Ναι. Κλιμακώνοντας το πλαίσιο OLE ώστε να ταιριάζει με το μέγεθος της περιοχής κελιών του Excel ή κλιμακώνοντας την περιοχή κελιών ώστε να ταιριάζει με το επιθυμητό μέγεθος πλαισίου OLE, μπορείτε να αποτρέψετε ανεπιθύμητες αλλαγές μεγέθους.

**Ποια μέθοδο κλιμάκωσης να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση περιοχής κελιών;**

Επιλέξτε **Κλιμάκωση πλαισίου OLE** εάν θέλετε να διατηρήσετε τα αρχικά μεγέθη γραμμών και στηλών του Excel. Επιλέξτε **Κλιμάκωση περιοχής κελιών** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργούν αυτές οι λύσεις αν η παρουσίασή μου βασίζεται σε πρότυπο;**

Ναι. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα και από το μηδέν.

**Υπάρχει περιορισμός στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**

Όχι. Μπορείτε να κάνετε το πλαίσιο αντικειμένου OLE οποιουδήποτε μεγέθους, αρκεί να ορίσετε τη κλίμακα αναλόγως.

**Υπάρχει τρόπος να αποφευχθεί το κείμενο υπόδειγμα «EMBEDDED OLE OBJECT» στο PowerPoint;**

Ναι. Καταγράφοντας μια εικόνα της περιοχής κελιών του Excel-στόχου και ορίζοντας την ως εικόνα υποδείγματος του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη εικόνα προεπισκόπησης αντί του προεπιλεγμένου υποδείγματος.

## **Σχετικά Άρθρα**

[Δημιουργία διαγράμματος Excel και ενσωμάτωσή του σε παρουσίαση ως αντικείμενο OLE](/slides/el/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Αυτόματη ενημέρωση αντικειμένων OLE χρησιμοποιώντας πρόσθετο MS PowerPoint](/slides/el/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)