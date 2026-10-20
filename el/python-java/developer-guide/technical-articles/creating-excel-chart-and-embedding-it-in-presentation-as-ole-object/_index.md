---
title: Δημιουργία διαγραμμάτων Excel και ενσωμάτωση τους σε παρουσιάσεις ως αντικείμενα OLE
type: docs
weight: 30
url: /el/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Διάγραμμα Excel
- ενσωμάτωση διαγράμματος
- αντικείμενο OLE
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε ένα διάγραμμα Excel με το Aspose.Cells για Python μέσω Java και ενσωματώστε το βιβλίο εργασίας σε μια παρουσίαση PowerPoint με το Aspose.Slides, συμπεριλαμβανομένης μιας προεπισκόπησης διαγράμματος."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε ένα γράφημα στήλης Excel με το Aspose.Cells για Python μέσω Java και να ενσωματώσετε το βιβλίο εργασίας του σε μια παρουσίαση PowerPoint με το Aspose.Slides για Python μέσω Java. Το ενσωματωμένο βιβλίο εργασίας περιέχει τόσο τα δεδομένα προέλευσης όσο και το γράφημα. Μια ξεχωριστή προεπισκόπηση PNG εμφανίζει το γράφημα στη διαφάνεια πριν ενεργοποιηθεί το αντικείμενο OLE.

Το αποτέλεσμα είναι ένα ενσωματωμένο αντικείμενο Excel, όχι ένα ενσωματωμένο γράφημα PowerPoint. Η επεξεργασία του βιβλίου εργασίας μέσω OLE απαιτεί μια εφαρμογή υπολογιστή που υποστηρίζει ενεργοποίηση OLE και μια συμβατή εγκατάσταση Excel.

## **Προαπαιτούμενα**

Εγκαταστήστε τα πακέτα Python `aspose-cells` και `aspose-slides-java` και ένα συμβατό χρόνο εκτέλεσης Java. Εισάγετε και τα δύο πακέτα πριν εκκινήσετε το JVM ώστε οι βιβλιοθήκες Java τους να είναι διαθέσιμες στο JPype. Το Microsoft Office δεν απαιτείται για τη δημιουργία της παρουσίασης με αυτές τις βιβλιοθήκες.

Δεν απαιτούνται αρχεία εισόδου: το παράδειγμα δημιουργεί τα δεδομένα και το γράφημα στη μνήμη, στη συνέχεια γράφει το `OutputChart.pptx` στον τρέχοντα φάκελο εργασίας. Εφαρμόστε άδειες και για τα δύο προϊόντα όταν τρέχετε εκτός λειτουργίας αξιολόγησης.

## **Πως λειτουργεί η ενσωμάτωση**

1. Δημιουργήστε ένα βιβλίο εργασίας με φύλλο δεδομένων και φύλλο γραφήματος.  
1. Κάντε ενεργό το φύλλο γραφήματος ώστε το βιβλίο εργασίας να ανοίγει στο γράφημα.  
1. Ορίστε την περιοχή εμφάνισης OLE του βιβλίου εργασίας και αποδώστε το γράφημα σε PNG.  
1. Αποθηκεύστε το βιβλίο εργασίας ως XLSX στη μνήμη και ενσωματώστε τα byte σε μια διαφάνεια.  
1. Αναθέστε το PNG ως προεπισκόπηση του αντικειμένου OLE και αποθηκεύστε την παρουσίαση ως PPTX.

Η περιοχή εμφάνισης του βιβλίου εργασίας και το πλαίσιο στη διαφάνεια έχουν διαφορετικούς ρόλους. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) δέχεται δείκτες γραμμής/στήλης μείωσης βάση μηδενικού. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) αντίθετα δέχεται την επάνω γραμμή, την αριστερή στήλη, την κάτω γραμμή και τη δεξιά στήλη. Το παράδειγμα χρησιμοποιεί δείκτη γραμμής 55 και δείκτη στήλης 25 ως τα κάτω‑δεξιά όρια· αυτές οι τιμές είναι επιλογές διάταξης, όχι ο αριθμός των γραμμών ή στηλών δεδομένων.

Το πλαίσιο της διαφάνειας χρησιμοποιεί σημεία. Το παράδειγμα το προσαρμόζει μέσα στη διαφάνεια και το κεντράρει διατηρώντας την αναλογία διαστάσεων του PNG, αντί να τεντώσει την προεπισκόπηση ώστε να γεμίσει τη διαφάνεια.

## **Δημιουργία και Ενσωμάτωση του Διαγράμματος**

Το παρακάτω πλήρες παράδειγμα γεμίζει το `DataSheet` με τέσσερις γραμμές και πέντε στήλες τιμών. Κάθε γραμμή γίνεται σειρά γραφήματος. Το `ChartSheet` επιλέγεται ως ενεργό φύλλο πριν αποθηκευτεί το βιβλίο εργασίας.

Το βιβλίο εργασίας αποθηκεύεται ρητά ως XLSX, ταιριάζοντας με την επέκταση `xlsx` που περνάται στο [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). Τα ρεύματα byte‑array της Java διατηρούν το βιβλίο εργασίας και την εικόνα στη μνήμη και παρέχουν τα byte arrays που απαιτούνται από τις Java APIs. Το PNG φορτώνεται απευθείας από τα byte του χωρίς ενδιάμεση μετατροπή bitmap. Η ανάθεσή του μέσω του [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) αντικαθιστά το προεπιλεγμένο σύμβολο κράτησης θέσης OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Δημιουργήστε την προεπισκόπηση του γραφήματος και σειροποιήστε το επεξεργάσιμο βιβλίο εργασίας ξεχωριστά.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Προσαρμόστε την προεπισκόπηση μέσα στη διαφάνεια χωρίς να αλλάξετε την αναλογία διαστάσεων.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Αναμενόμενο Αποτέλεσμα**

`OutputChart.pptx` περιέχει μία διαφάνεια με ενσωματωμένο βιβλίο εργασίας Excel και προεπισκόπηση γραφήματος. Το βιβλίο εργασίας περιέχει τα αρχικά δεδομένα και ένα γράφημα στήλης με τέσσερις σειρές. Η προεπισκόπηση είναι κεντραρισμένη στη διαφάνεια και διατηρεί τις αναλογίες της.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

Σε ένα συμβατό περιβάλλον PowerPoint σε υπολογιστή με διαθέσιμο Excel, κάντε διπλό κλικ στο αντικείμενο για ενεργοποίηση και επεξεργασία του ενσωματωμένου βιβλίου εργασίας. Η ενεργοποίηση και η επεξεργασία εξαρτώνται από την υποστήριξη OLE της εφαρμογής-φιλοξενητή και τις ρυθμίσεις ασφαλείας.

## **Συχνές Ερωτήσεις**

**Γιατί χρειάζεται εικόνα προεπισκόπησης;**

Το ενσωματωμένο βιβλίο εργασίας και η προεπισκόπηση στη διαφάνεια είναι ξεχωριστό περιεχόμενο. Παρέχετε μια εικόνα γραφήματος ώστε η διαφάνεια να δείχνει το γράφημα αντί του προεπιλεγμένου συμβόλου «EMBEDDED OLE OBJECT». Δείτε το [Object Preview Issue when Adding OleObjectFrame](/slides/el/python-java/object-preview-issue-when-adding-oleobjectframe/).

**Ενημερώνεται αυτόματα η προεπισκόπηση όταν αλλάζω το βιβλίο εργασίας στον κώδικα;**

Θεωρήστε την προεπισκόπηση ως στιγμιότυπο. Όταν ενημερώνετε τα δεδομένα του βιβλίου εργασίας προγραμματιστικά, δημιουργήστε ξανά την εικόνα του γραφήματος και αντικαταστήστε την προεπισκόπηση καθώς και τα δεδομένα του ενσωματωμένου βιβλίου εργασίας.

**Μπορώ να χρησιμοποιήσω XLS αντί για XLSX;**

Ναι. Αποθηκεύστε το βιβλίο εργασίας σε μορφή XLS και χρησιμοποιήστε το `xls` ως επέκταση δεδομένων ενσωμάτωσης. Η επέκταση πρέπει να ταιριάζει με τη πραγματική μορφή του βιβλίου εργασίας· η αλλαγή μόνο της επέκτασης δεν μετατρέπει τα δεδομένα.

**Γιατί το αντικείμενο μπορεί να αλλάξει μέγεθος μετά την ενεργοποίηση;**

Η εφαρμογή-φιλοξενητής μπορεί να ενημερώσει την παρουσίαση του αντικειμένου OLE όταν ενεργοποιεί το βιβλίο εργασίας. Η περιοχή εμφάνισης OLE του βιβλίου εργασίας και οι διαστάσεις του πλαισίου στη διαφάνεια είναι και οι δύο σημαντικές. Δείτε το [Working Solution for Chart Resizing in PPTX](/slides/el/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Σχετικές Ενότητες**

- [Working Solution for Chart Resizing in PPTX](/slides/el/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/el/python-java/object-preview-issue-when-adding-oleobjectframe/)