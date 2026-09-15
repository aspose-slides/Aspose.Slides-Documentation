---
title: Δημιουργία Διαγραμμάτων Excel και Ενσωμάτωση τους σε Παρουσιάσεις ως Αντικείμενα OLE
type: docs
weight: 30
url: /el/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Διάγραμμα Excel
- ενσωμάτωση διαγράμματος
- αντικείμενο OLE
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε διαγράμματα Excel και ενσωματώστε τα ως αντικείμενα OLE σε παρουσιάσεις PowerPoint και OpenDocument με Python. Οδηγός βήμα προς βήμα με παραδείγματα κώδικα."
---
## **Ιστορικό**

Στο PowerPoint, η χρήση επεξεργάσιμων διαγραμμάτων για την γραφική παρουσίαση δεδομένων είναι κοινή πρακτική. Η Aspose υποστηρίζει τη δημιουργία διαγραμμάτων Excel με το Aspose.Cells for Python via Java, και αυτά τα διαγράμματα μπορούν στη συνέχεια να ενσωματωθούν ως αντικείμενα OLE σε διαφάνειες PowerPoint μέσω του Aspose.Slides for Python via Java. Αυτό το άρθρο καλύπτει τα απαραίτητα βήματα και παρέχει ένα δείγμα κώδικα Python για τη δημιουργία διαγράμματος Excel και την ενσωμάτωσή του ως αντικείμενο OLE σε παρουσίαση PowerPoint χρησιμοποιώντας Aspose.Cells και Aspose.Slides.

## **Απαιτούμενα Βήματα**

Η ακόλουθη σειρά βημάτων απαιτείται για τη δημιουργία και ενσωμάτωση ενός διαγράμματος Excel ως αντικείμενο OLE σε διαφάνεια PowerPoint:

1. Δημιουργήστε ένα διάγραμμα Excel χρησιμοποιώντας Aspose.Cells.
1. Ορίστε το μέγεθος OLE του διαγράμματος Excel χρησιμοποιώντας Aspose.Cells.
1. Λάβετε μια εικόνα του διαγράμματος Excel με Aspose.Cells.
1. Ενσωματώστε το διάγραμμα Excel ως αντικείμενο OLE σε μια παρουσίαση PPTX χρησιμοποιώντας Aspose.Slides.
1. Αντικαταστήστε την εικόνα "EMBEDDED OLE OBJECT" με την εικόνα που ελήφθη στο βήμα 3 για την αντιμετώπιση του [πρόβλημα προεπισκόπησης αντικειμένου](/slides/el/python-java/object-preview-issue-when-adding-oleobjectframe/).
1. Αποθηκεύστε την παρουσίαση στο δίσκο σε μορφή PPTX.

## **Υλοποίηση των Απαιτούμενων Βημάτων**

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # Μια σειρά από ονόματα κελιών.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Μια σειρά από δεδομένα κελιών.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Προσθήκη νέου φύλλου εργασίας για τη συμπλήρωση των κελιών με δεδομένα.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Συμπλήρωση του φύλλου δεδομένων με δεδομένα.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Προσθήκη φύλλου διαγράμματος.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Προσθήκη διαγράμματος στο φύλλο διαγράμματος με σειρές δεδομένων από το φύλλο δεδομένων.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Ορισμός του φύλλου διαγράμματος ως ενεργό φύλλο.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Περιγραφή του βιβλίου εργασίας ως ενσωματωμένα δεδομένα OLE.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Δημιουργία βιβλίου εργασίας.
workbook = Workbook()

# Προσθήκη διαγράμματος Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Ορισμός του μεγέθους OLE του διαγράμματος.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Λήψη της εικόνας του διαγράμματος και αποθήκευση σε ροή.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Αποθήκευση του βιβλίου εργασίας σε ροή.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Δημιουργία παρουσίασης.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη του βιβλίου εργασίας σε διαφάνεια.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Αποθήκευση της παρουσίασης στον δίσκο.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η παρουσίαση που δημιουργείται με τη παραπάνω μέθοδο θα περιέχει το διάγραμμα Excel ως αντικείμενο OLE που μπορεί να ενεργοποιηθεί με διπλό κλικ στο πλαίσιο αντικειμένου OLE.

## **Συμπέρασμα**

Με τη χρήση του Aspose.Cells for Python via Java σε συνδυασμό με το Aspose.Slides for Python via Java, μπορούμε να δημιουργήσουμε οποιοδήποτε διάγραμμα Excel που υποστηρίζεται από το Aspose.Cells και να το ενσωματώσουμε ως αντικείμενο OLE σε διαφάνεια PowerPoint. Το μέγεθος OLE του διαγράμματος Excel μπορεί επίσης να οριστεί. Οι τελικοί χρήστες μπορούν στη συνέχεια να επεξεργαστούν το διάγραμμα Excel όπως οποιοδήποτε άλλο αντικείμενο OLE.

## **Σχετικές Ενότητες**

- [Λύση λειτουργίας για αλλαγή μεγέθους διαγράμματος σε PPTX](/slides/el/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Πρόβλημα προεπισκόπησης αντικειμένου κατά την προσθήκη OleObjectFrame](/slides/el/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **Συχνές Ερωτήσεις**

**Ποιες βιβλιοθήκες χρησιμοποιούνται για τη δημιουργία και ενσωμάτωση του διαγράμματος Excel;**

Το Aspose.Cells for Python via Java δημιουργεί το διάγραμμα Excel, και το Aspose.Slides for Python via Java το ενσωματώνει ως αντικείμενο OLE σε διαφάνεια PowerPoint.

**Πώς μπορούν οι χρήστες να επεξεργαστούν το ενσωματωμένο διάγραμμα Excel;**

Οι χρήστες μπορούν να κάνουν διπλό κλικ στο πλαίσιο αντικειμένου OLE για να ενεργοποιήσουν το διάγραμμα και να το επεξεργαστούν όπως οποιοδήποτε άλλο αντικείμενο OLE.

**Πώς αντικαθίσταται η προεπιλεγμένη προεπισκόπηση αντικειμένου OLE;**

Το παράδειγμα λαμβάνει μια εικόνα του διαγράμματος Excel με Aspose.Cells και τη χρησιμοποιεί για την αντικατάσταση της εικόνας "EMBEDDED OLE OBJECT".