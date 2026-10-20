---
title: Δημιουργία διαγραμμάτων Excel και ενσωμάτωση τους σε παρουσιάσεις ως αντικείμενα OLE
type: docs
weight: 50
url: /el/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Διάγραμμα Excel
- ενσωμάτωση διαγράμματος
- αντικείμενο OLE
- PowerPoint
- παρουσίαση
- Python
- Python μέσω .NET
- Aspose.Slides
description: "Δημιουργήστε ένα διάγραμμα Excel με το Aspose.Cells για Python μέσω .NET και ενσωματώστε το βιβλίο εργασίας σε μια παρουσίαση PowerPoint με το Aspose.Slides, συμπεριλαμβανομένης μιας προεπισκόπησης διαγράμματος."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε ένα γράφημα στήλης του Excel με το Aspose.Cells για Python μέσω .NET και να ενσωματώσετε το βιβλίο εργασίας του σε μια παρουσίαση PowerPoint με το Aspose.Slides για Python μέσω .NET. Το ενσωματωμένο βιβλίο εργασίας περιέχει τόσο τα αρχικά δεδομένα όσο και το γράφημα. Μια ξεχωριστή προεπισκόπηση PNG εμφανίζει το γράφημα στη διαφάνεια πριν ενεργοποιηθεί το αντικείμενο OLE.

Το αποτέλεσμα είναι ένα ενσωματωμένο αντικείμενο Excel, όχι ένα εγγενές γράφημα PowerPoint. Η επεξεργασία του βιβλίου εργασίας μέσω OLE απαιτεί μια εφαρμογή desktop που υποστηρίζει την ενεργοποίηση OLE και μια συμβατή εγκατάσταση του Excel.

## **Προαπαιτούμενα**

Εγκαταστήστε τα πακέτα `aspose-cells-python` και `aspose-slides` στο περιβάλλον Python σας. Δεν απαιτείται το Microsoft Office για τη δημιουργία της παρουσίασης με αυτές τις βιβλιοθήκες.

Δεν απαιτούνται αρχεία εισόδου: το παράδειγμα δημιουργεί τα δεδομένα και το γράφημα στη μνήμη, έπειτα γράφει το `OutputChart.pptx` στον τρέχοντα φάκελο εργασίας. Εφαρμόστε άδειες για και τα δύο προϊόντα όταν εκτελείται εκτός λειτουργίας αξιολόγησης.

## **Πώς λειτουργεί η ενσωμάτωση**

1. Δημιουργήστε ένα βιβλίο εργασίας με ένα φύλλο δεδομένων και ένα φύλλο γραφήματος.
1. Κάντε το φύλλο γραφήματος ενεργό ώστε το βιβλίο εργασίας να ανοίγει στο γράφημα.
1. Ορίστε το εύρος εμφάνισης OLE του βιβλίου εργασίας και αποδώστε το γράφημα σε PNG.
1. Αποθηκεύστε το βιβλίο εργασίας ως XLSX στη μνήμη και ενσωματώστε αυτά τα bytes σε μια διαφάνεια.
1. Ορίστε το PNG ως προεπισκόπηση του αντικειμένου OLE και αποθηκεύστε την παρουσίαση ως PPTX.

Το εύρος εμφάνισης του βιβλίου εργασίας και το πλαίσιο στη διαφάνεια έχουν διαφορετικούς ρόλους. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) λαμβάνει δείκτες γραμμής/στήλης αρχής/τέλους με βάση το μηδέν. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) λαμβάνει αντ' αυτού την άνω γραμμή, την αριστερή στήλη, την κάτω γραμμή και τη δεξιά στήλη. Το παράδειγμα χρησιμοποιεί δείκτη γραμμής 55 και δείκτη στήλης 25 ως τα κάτω-δεξιά όρια· αυτές οι τιμές είναι επιλογές διάταξης, όχι ο αριθμός των γραμμών ή στηλών δεδομένων.

Το πλαίσιο της διαφάνειας χρησιμοποιεί μονάδες σημείων. Το παράδειγμα το προσαρμόζει μέσα στη διαφάνεια και το κεντράρει διατηρώντας την αναλογία διαστάσεων του PNG, αντί να τεντώσει την προεπισκόπηση για να καλύψει τη διαφάνεια.

## **Δημιουργία και ενσωμάτωση του γραφήματος**

Το παρακάτω πλήρες παράδειγμα γεμίζει το `DataSheet` με τέσσερις γραμμές και πέντε στήλες τιμών. Κάθε γραμμή γίνεται σειρά γραφήματος. Το `ChartSheet` επιλέγεται ως ενεργό φύλλο πριν αποθηκευτεί το βιβλίο εργασίας.

Το βιβλίο εργασίας αποθηκεύεται ρητά ως XLSX, ταιριάζοντας με την επέκταση `xlsx` που περνιέται στο [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). Το PNG φορτώνεται άμεσα από τη ροή του χωρίς ενδιάμεση μετατροπή bitmap. Η ανάθεσή του μέσω του [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) αντικαθιστά το προεπιλεγμένο placeholder OLE.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Απόδοση της προεπισκόπησης του διαγράμματος και σειριοποίηση του επεξεργάσιμου βιβλίου εργασίας ξεχωριστά.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Προσαρμογή της προεπισκόπησης μέσα στη διαφάνεια χωρίς αλλαγή της αναλογίας διαστάσεων.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Αναμενόμενο αποτέλεσμα**

Το `OutputChart.pptx` περιέχει μία διαφάνεια με ενσωματωμένο βιβλίο εργασίας Excel και προεπισκόπηση γραφήματος. Το βιβλίο εργασίας περιέχει τα αρχικά δεδομένα και ένα γράφημα στήλης με τέσσερις σειρές. Η προεπισκόπηση βρίσκεται κεντραρισμένη στη διαφάνεια και διατηρεί τις αναλογίες της.

![Διάγραμμα στήλης Excel που εμφανίζεται ως προεπισκόπηση ενσωματωμένου βιβλίου εργασίας](excel-chart-ole-preview.png)

Σε ένα συμβατό περιβάλλον PowerPoint desktop με εγκατεστημένο Excel, κάντε διπλό κλικ στο αντικείμενο για να ενεργοποιήσετε και να επεξεργαστείτε το ενσωματωμένο βιβλίο εργασίας. Η ενεργοποίηση και η επεξεργασία εξαρτώνται από την υποστήριξη OLE της εφαρμογής-φιλοξενίας και τις ρυθμίσεις ασφαλείας.

## **Συχνές Ερωτήσεις**

**Γιατί χρειάζεται εικόνα προεπισκόπησης;**

Το ενσωματωμένο βιβλίο εργασίας και η προεπισκόπηση στη διαφάνειά του είναι ξεχωριστό περιεχόμενο. Παρέχετε μια εικόνα γραφήματος ώστε η διαφάνεια να εμφανίζει το γράφημα αντί του προεπιλεγμένου placeholder "EMBEDDED OLE OBJECT". Δείτε το [Object Preview Issue when Adding OleObjectFrame](/slides/el/python-net/object-preview-issue-when-adding-oleobjectframe/).

**Η προεπισκόπηση ενημερώνεται αυτόματα όταν αλλάζω το βιβλίο εργασίας στον κώδικα;**

Θεωρήστε την προεπισκόπηση ως στιγμιότυπο. Όταν ενημερώνετε τα δεδομένα του βιβλίου εργασίας προγραμματιστικά, δημιουργήστε ξανά την εικόνα του γραφήματος και αντικαταστήστε την προεπισκόπηση καθώς και τα δεδομένα του ενσωματωμένου βιβλίου εργασίας.

**Μπορώ να χρησιμοποιήσω XLS αντί για XLSX;**

Ναι. Αποθηκεύστε το βιβλίο εργασίας σε μορφή XLS και χρησιμοποιήστε `xls` ως την επέκταση ενσωματωμένων δεδομένων. Η επέκταση πρέπει να ταιριάζει με την πραγματική μορφή του βιβλίου εργασίας· η αλλαγή μόνο της επέκτασης δεν μετατρέπει τα δεδομένα.

**Γιατί το αντικείμενο μπορεί να αλλάξει μέγεθος μετά την ενεργοποίηση;**

Η εφαρμογή-φιλοξενία μπορεί να ενημερώσει την παρουσίαση του αντικειμένου OLE όταν ενεργοποιεί το βιβλίο εργασίας. Το εύρος εμφάνισης OLE του βιβλίου εργασίας και οι διαστάσεις του πλαισίου της διαφάνειας είναι και τα δύο σημαντικά. Δείτε το [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/el/python-net/working-solution-for-worksheet-resizing/).

## **Σχετικές Ενότητες**

- [Αυτόματη αλλαγή μεγέθους αντικειμένων OLE σε παρουσιάσεις PowerPoint](/slides/el/python-net/working-solution-for-worksheet-resizing/)
- [Πρόβλημα προεπισκόπησης αντικειμένου κατά την προσθήκη OleObjectFrame](/slides/el/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [Διαχείριση αντικειμένων OLE](/slides/el/python-net/manage-ole/)