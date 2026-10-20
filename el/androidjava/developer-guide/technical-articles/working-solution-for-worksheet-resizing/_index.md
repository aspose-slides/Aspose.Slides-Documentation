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
description: "Διορθώστε την αλλαγή μεγέθους OLE φύλλου εργασίας Excel στις παρουσιάσεις: δύο τρόποι για να διατηρήσετε τα πλαίσια αντικειμένων συνεπή—κλιμακώστε το πλαίσιο ή το φύλλο—σε μορφές PPT και PPTX."
---
{{% alert color="info" title="Σημείωση" %}}

Τα φύλλα εργασίας του Excel που ενσωματώνονται ως αντικείμενα OLE σε παρουσίαση PowerPoint με χρήση των συστατικών Aspose ενδέχεται να αλλάζουν μέγεθος απροσδόκητα μετά την πρώτη ενεργοποίησή τους. Αυτή η συμπεριφορά δημιουργεί μια εμφανή οπτική διαφορά μεταξύ του αντικειμένου OLE πριν και μετά την ενεργοποίηση. Αυτό το άρθρο εξηγεί το πρόβλημα και περιγράφει δύο τρόπους αντιμετώπισής του.

{{% /alert %}}

## **Ιστορικό**

Στο άρθρο [Διαχείριση OLE](/slides/el/androidjava/manage-ole/), εξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for Android μέσω Java. Για την αντιμετώπιση του [θέματος προεπισκόπησης αντικειμένου](/slides/el/androidjava/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε μια εικόνα της επιλεγμένης περιοχής του φύλλου εργασίας στο πλαίσιο του αντικειμένου OLE. Στην έξοδο της παρουσίασης, όταν κάνετε διπλό κλικ στο πλαίσιο OLE που εμφανίζει την εικόνα του φύλλου εργασίας, το βιβλίο εργασίας Excel ενεργοποιείται. Οι τελικοί χρήστες μπορούν να κάνουν τις επιθυμητές αλλαγές στο πραγματικό βιβλίο εργασίας Excel και στη συνέχεια να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας Excel. Το μέγεθος του πλαισίου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο παράγοντας αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου OLE και το ενσωματωμένο βιβλίο εργασίας Excel.

## **Αιτία της Αλλαγής Μεγέθους**

Επειδή το βιβλίο εργασίας Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο του αντικειμένου OLE έχει τις δικές του διαστάσεις. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διατηρηθεί η σωστή αναλογία ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους προκύπτει βάσει των διαφορών μεταξύ του μεγέθους του παραθύρου Excel και του μεγέθους και της θέσης του πλαισίου OLE.

## **Λύση Εργασίας**

Υπάρχουν δύο δυνατότητες για την αποφυγή του φαινομένου αλλαγής μεγέθους.

- Κλιμακώστε το πλαίσιο OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στηλών.
- Διατηρήστε το μέγεθος του πλαισίου OLE σταθερό και κλιμακώστε τις επιλεγμένες γραμμές και στήλες ώστε να χωράνε μέσα του.

### **Κλιμακώστε το Μέγεθος Πλαισίου OLE**

Αυτή η προσέγγιση ορίζει το μέγεθος του πλαισίου OLE ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στηλών στο ενσωματωμένο φύλλο εργασίας Excel.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες που ξεκινούν από το μηδέν. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) ορίζει το εμφανιζόμενο εύρος. Η προεπισκόπηση αποδίδεται στα 96 DPI και οι διαστάσεις των εικονοστοιχείων μετατρέπονται σε σημειακές μονάδες χρησιμοποιώντας 72 σημεία ανά ίντσα. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ενσωματώνει το τροποποιημένο βιβλίο εργασίας σε ένα πλαίσιο με αυτές τις διαστάσεις. Η προεπισκόπηση αντιστοιχίζεται μέσω του [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) για να αντικαταστήσει το στοιχείο κράτησης θέσης "EMBEDDED OLE OBJECT" στην αποθηκευμένη παρουσίαση.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

// Λάβετε το πλάτος και το ύψος της εικόνας OLE σε σημειακές μονάδες.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

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

Η βοηθητική διαδικασία προεπισκόπησης ορίζει το [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) στο επιλεγμένο εύρος και αφαιρεί περιθώρια, κεφαλίδες και υποσέλιδα. Με ενεργοποιημένο το [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) , το [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) αποδίδει το εύρος ως εικόνα PNG. Η βοηθητική μέθοδος επιστρέφει μια νέα ροή εισόδου που περιέχει την εικόνα PNG, τοποθετημένη στην αρχή της για χρήση στην παρουσίαση.

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

### **Κλιμακώστε το Μέγεθος Εύρους Κελιών**

Αυτή η προσέγγιση κλιμακώνει τα ύψη των επιλεγμένων γραμμών και το πλάτος των επιλεγμένων στηλών ώστε να ταιριάζουν με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες που ξεκινούν από το μηδέν. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) ορίζει το εμφανιζόμενο εύρος, και η παρακάτω βοηθητική μέθοδος κλιμακώνει αυτό το εύρος ώστε να χωρά σε πλαίσιο πλάτους 400 σημείων και ύψους 100 σημείων. Μετά την αποθήκευση του τροποποιημένου βιβλίου εργασίας σε ροή, το [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) το ενσωματώνει στο καθορισμένο μέγεθος. Μια προεπισκόπηση που αποδίδεται στα 96 DPI αντιστοιχίζεται μέσω του [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) ώστε η αποθηκευμένη παρουσίαση να εμφανίζει τα επιλεγμένα κελιά αντί του προεπιλεγμένου στοιχείου κράτησης θέσης.

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

// Κλιμακώστε το εύρος κελιών ώστε να ταιριάζει με το μέγεθος του πλαισίου.
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

Η βοηθητική μέθοδος κλιμάκωσης υπολογίζει ξεχωριστούς λόγους πλάτους και ύψους για το επιλεγμένο εύρος, διατηρώντας τις σχετικές αναλογίες των στηλών και των γραμμών του. Μετατρέπει τις υπολογισμένες διαστάσεις από σημεία σε ίντσες πριν τις εφαρμόσει με τις μεθόδους [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) και [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Το επιλεγμένο εύρος πρέπει να έχει μη μηδενικό πλάτος και ύψος.

```java
/**
 * @param width     Η αναμενόμενη πλάτος του εύρους κελιών σε σημεία.
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

Αυτή η βοηθητική μέθοδος προεπισκόπησης αποδίδει το αλλαγμένο μέγεθος εύρους χρησιμοποιώντας το [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Περιορίζει το [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) σε αυτό το εύρος, αφαιρεί περιθώρια, κεφαλίδες και υποσέλιδα, και επιστρέφει μια ροή PNG τοποθετημένη στην αρχή της.

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

## **Συμπέρασμα**

{{% alert color="info" title="Σημείωση" %}}

Υπάρχουν δύο προσεγγίσεις για την επίλυση του ζητήματος αλλαγής μεγέθους του φύλλου εργασίας. Επιλέξτε την προσέγγιση που ταιριάζει καλύτερα στις απαιτήσεις και την περίπτωσή σας. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από το μηδέν. Επιπλέον, δεν υπάρχει όριο στο μέγεθος του πλαισίου OLE σε αυτήν τη λύση.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Γιατί ένα ενσωματωμένο φύλλο εργασίας Excel αλλάζει μέγεθος όταν ενεργοποιείται για πρώτη φορά στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος του παραθύρου κατά την ενεργοποίηση, ενώ το πλαίσιο OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει αλλαγή μεγέθους.

**Μπορεί να αποτραπεί πλήρως αυτό το πρόβλημα αλλαγής μεγέθους;**

Ναί. Κλιμακώνοντας το πλαίσιο OLE ώστε να ταιριάζει με το μέγεθος του εύρους κελιών Excel ή κλιμακώνοντας το εύρος κελιών ώστε να ταιριάζει με το επιθυμητό μέγεθος πλαισίου OLE, μπορείτε να αποτρέψετε ανεπιθύμητες αλλαγές μεγέθους.

**Ποια μέθοδο κλιμάκωσης πρέπει να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση εύρους κελιών;**

Επιλέξτε **κλιμάκωση πλαισίου OLE** εάν θέλετε να διατηρήσετε τις αρχικές διαστάσεις των γραμμών και στηλών του Excel. Επιλέξτε **κλιμάκωση εύρους κελιών** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργούν αυτές οι λύσεις αν η παρουσίασή μου βασίζεται σε πρότυπο;**

Ναί. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα και από το μηδέν.

**Υπάρχει όριο στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**

Όχι. Μπορείτε να ορίσετε το πλαίσιο OLE σε οποιοδήποτε μέγεθος, αρκεί να ρυθμίσετε τη κλιμάκωση κατάλληλα.

**Υπάρχει τρόπος να αποφευχθεί το κείμενο κράτησης θέσης «EMBEDDED OLE OBJECT» στο PowerPoint;**

Ναί. Λαμβάνοντας ένα στιγμιότυπο του επιθυμητού εύρους κελιών Excel και ορίζοντας το ως εικόνα κράτησης θέσης του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη εικόνα προεπισκόπησης αντί του προεπιλεγμένου στοιχείου κράτησης θέσης.

## **Σχετικά Άρθρα**

[Δημιουργία Γραφήματος Excel και Ενσωμάτωσή του σε Παρουσίαση ως Αντικείμενο OLE](/slides/el/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Αυτόματη Ενημέρωση Αντικειμένων OLE Χρησιμοποιώντας Πρόσθετο MS PowerPoint](/slides/el/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)