---
title: Λύση λειτουργίας για αλλαγή μεγέθους φύλλου εργασίας
type: docs
weight: 20
url: /el/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- εικόνα προεπισκόπησης
- αλλαγή μεγέθους εικόνας
- Excel
- φύλλο εργασίας
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διορθώστε τη αλλαγή μεγέθους OLE φύλλου εργασίας Excel σε παρουσιάσεις: δύο τρόποι για να διατηρήσετε τα πλαίσια αντικειμένων συνεπή—κλιμακώνετε το πλαίσιο ή το φύλλο—σε μορφές PPT και PPTX."
---
{{% alert color="info" title="Note" %}}

Τα φύλλα εργασίας Excel που ενσωματώνονται ως αντικείμενα OLE σε παρουσίαση PowerPoint χρησιμοποιώντας τα στοιχεία Aspose ενδέχεται να αλλάζουν μέγεθος απροσδόκητα μετά την πρώτη ενεργοποίησή τους. Αυτή η συμπεριφορά δημιουργεί μια εμφανή οπτική διαφορά μεταξύ του αντικειμένου OLE πριν και μετά την ενεργοποίηση. Αυτό το άρθρο εξηγεί το πρόβλημα και περιγράφει δύο τρόπους αντιμετώπισής του.

{{% /alert %}}

## **Ιστορικό**

Στο άρθρο [Διαχείριση OLE](/slides/el/python-java/manage-ole/), εξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Για την αντιμετώπιση του [προβλήματος προεπισκόπησης αντικειμένου](/slides/el/python-java/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε μια εικόνα της επιλεγμένης περιοχής του φύλλου εργασίας στο πλαίσιο αντικειμένου OLE. Στην τελική παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του φύλλου εργασίας, ενεργοποιείται το βιβλίο εργασίας Excel. Οι τελικοί χρήστες μπορούν να κάνουν οποιεσδήποτε επιθυμητές αλλαγές στο πραγματικό βιβλίο εργασίας Excel και, στη συνέχεια, να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας Excel. Το μέγεθος του πλαισίου αντικειμένου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο συντελεστής αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου αντικειμένου OLE και του ενσωματωμένου βιβλίου εργασίας Excel.

## **Αιτία αλλαγής μεγέθους**

Επειδή το βιβλίο εργασίας Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διασφαλιστεί ότι διατηρεί τις σωστές αναλογίες ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους πραγματοποιείται βάσει των διαφορών μεταξύ του μεγέθους του παραθύρου Excel και του μεγέθους και της θέσης του πλαισίου αντικειμένου OLE.

## **Λειτουργική λύση**

Υπάρχουν δύο δυνατές λύσεις για να αποφεύγετε το φαινόμενο αλλαγής μεγέθους.

- Κλιμακώστε το πλαίσιο OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στηλών.
- Διατηρήστε το μέγεθος του πλαισίου OLE σταθερό και κλιμακώστε τις επιλεγμένες γραμμές και στήλες ώστε να χωρέσουν μέσα του.

### **Κλιμάκωση του Μεγέθους Πλαισίου OLE**

Αυτή η προσέγγιση ορίζει το μέγεθος του πλαισίου OLE ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στηλών στο ενσωματωμένο φύλλο εργασίας Excel.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλου εργασίας του, χρησιμοποιώντας δείκτες μηδενικής βάσης. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) ορίζει την εμφανιζόμενη περιοχή. Η προεπισκόπηση αποδίδεται στα 96 DPI και οι διαστάσεις της σε εικονοστοιχεία μετατρέπονται σε πόντους χρησιμοποιώντας 72 πόντους ανά ίντσα. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) ενσωματώνει το τροποποιημένο βιβλίο εργασίας σε ένα πλαίσιο με αυτές τις διαστάσεις. Η προεπισκόπηση αντιστοιχίζεται μέσω [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) για να αντικαταστήσει το σύμβολο κράτησης θέσης "EMBEDDED OLE OBJECT" στην αποθηκευμένη παρουσίαση.

Ο βοηθός προεπισκόπησης ορίζει το [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) στην επιλεγμένη περιοχή και αφαιρεί τα περιθώρια, τις κεφαλίδες και τα υποσέλιδα. Με ενεργοποιημένο το [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea), το [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) αποδίδει την περιοχή ως εικόνα PNG. Ο βοηθός επιστρέφει ένα νέο ροή εισόδου που περιέχει την εικόνα PNG, τοποθετημένη στην αρχή του για χρήση στην παρουσίαση.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Ορίστε το εμφανιζόμενο μέγεθος όταν το βιβλίο εργασίας χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Αποκτήστε το πλάτος και το ύψος της εικόνας OLE σε πόντους.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Χρησιμοποιήστε το τροποποιημένο βιβλίο εργασίας.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Προσθέστε την εικόνα OLE στους πόρους της παρουσίασης.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Δημιουργήστε το πλαίσιο αντικειμένου OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **Κλιμάκωση του Μεγέθους Περιοχής Κελιών**

Αυτή η προσέγγιση κλιμακώνει τα ύψη των επιλεγμένων γραμμών και τα πλάτη των επιλεγμένων στηλών ώστε να ταιριάζουν με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλου εργασίας του, χρησιμοποιώντας δείκτες μηδενικής βάσης. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) ορίζει την εμφανιζόμενη περιοχή, και ο βοηθός scale_cell_range κλιμακώνει αυτήν την περιοχή ώστε να ταιριάζει σε ένα πλαίσιο 400 πόντων πλάτος και 100 πόντων ύψος. Μετά την αποθήκευση του τροποποιημένου βιβλίου εργασίας σε ροή, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) το ενσωματώνει στο καθορισμένο μέγεθος. Μια προεπισκόπηση που αποδίδεται στα 96 DPI αντιστοιχίζεται μέσω [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), ώστε η αποθηκευμένη παρουσίαση να εμφανίζει τα επιλεγμένα κελιά αντί του προεπιλεγμένου συμβόλου κράτησης.

Ο βοηθός κλιμάκωσης υπολογίζει ξεχωριστούς λόγους πλάτους και ύψους για την επιλεγμένη περιοχή, διατηρώντας τα σχετικά πλάτη των στηλών της και τα σχετικά ύψη των γραμμών της. Μετατρέπει τις υπολογισμένες διαστάσεις από πόντους σε ίντσες πριν τις εφαρμόσει με [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) και [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). Η επιλεγμένη περιοχή πρέπει να έχει μη μηδενικό πλάτος και ύψος.

Αυτός ο βοηθός προεπισκόπησης αποδίδει την κλιμακωμένη περιοχή χρησιμοποιώντας το [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Περιορίζει το [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) σε αυτήν την περιοχή, αφαιρεί τα περιθώρια, τις κεφαλίδες και τα υποσέλιδα, και επιστρέφει μια ροή PNG τοποθετημένη στην αρχή της.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # Το αναμενόμενο πλάτος και ύψος της περιοχής κελιών είναι σε πόντους.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Ορίστε το εμφανιζόμενο μέγεθος όταν το βιβλίο εργασίας χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Κλιμακώστε την περιοχή κελιών ώστε να ταιριάζει στο μέγεθος του πλαισίου.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Χρησιμοποιήστε το τροποποιημένο βιβλίο εργασίας.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Προσθέστε την εικόνα OLE στους πόρους της παρουσίασης.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Δημιουργήστε το πλαίσιο αντικειμένου OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Συμπέρασμα**

{{% alert color="info" title="Note" %}} 

Υπάρχουν δύο προσεγγίσεις για την επίλυση του προβλήματος αλλαγής μεγέθους του φύλλου εργασίας. Επιλέξτε την προσεγγίση που ταιριάζει καλύτερα στις απαιτήσεις και στην περίπτωση χρήσης σας. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από την αρχή. Επιπλέον, δεν υπάρχει περιορισμός στο μέγεθος του πλαισίου αντικειμένου OLE σε αυτή τη λύση.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Γιατί ένα ενσωματωμένο φύλλο εργασίας Excel αλλάζει μέγεθος όταν ενεργοποιείται πρώτη φορά στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος του παραθύρου όταν ενεργοποιείται, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει την αλλαγή μεγέθους.

**Μπορεί να αποφευχθεί εντελώς αυτό το πρόβλημα αλλαγής μεγέθους;**

Ναι. Με την κλιμάκωση του πλαισίου OLE ώστε να ταιριάζει στο μέγεθος της περιοχής κελιών του Excel ή με την κλιμάκωση της περιοχής κελιών ώστε να ταιριάζει στο επιθυμητό μέγεθος πλαισίου OLE, μπορείτε να αποτρέψετε την ανεπιθύμητη αλλαγή μεγέθους.

**Ποια μέθοδο κλιμάκωσης πρέπει να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση περιοχής κελιών;**

Επιλέξτε **κλιμάκωση πλαισίου OLE** εάν θέλετε να διατηρήσετε το αρχικό μέγεθος των γραμμών και στηλών του Excel. Επιλέξτε **κλιμάκωση περιοχής κελιών** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργούν αυτές οι λύσεις αν η παρουσίασή μου βασίζεται σε πρότυπο;**

Ναι. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα και από την αρχή.

**Υπάρχει περιορισμός στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**

Όχι. Μπορείτε να κάνετε το πλαίσιο αντικειμένου OLE οποιουδήποτε μεγέθους, αρκεί να ρυθμίσετε την κλίμακα αναλόγως.

**Υπάρχει τρόπος να αποφευχθεί το κείμενο κράτησης θέσης "EMBEDDED OLE OBJECT" στο PowerPoint;**

Ναι. Με το να τραβήξετε ένα στιγμιότυπο της επιθυμητής περιοχής κελιών του Excel και να το ορίσετε ως εικόνα κράτησης θέσης του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη εικόνα προεπισκόπησης αντί του προεπιλεγμένου συμβόλου κράτησης θέσης.

## **Σχετικά Άρθρα**

[Δημιουργία διαγράμματος Excel και ενσωμάτωσή του σε παρουσίαση ως αντικείμενο OLE](/slides/el/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Αυτόματη ενημέρωση αντικειμένων OLE χρησιμοποιώντας πρόσθετο MS PowerPoint](/slides/el/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)