---
title: Λειτουργική Λύση για την Αλλαγή Μεγέθους Φύλλου Εργασίας
type: docs
weight: 40
url: /el/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- εικόνα προεπισκόπησης
- αλλαγή μεγέθους εικόνας
- Excel
- φύλλο εργασίας
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Διορθώστε την αλλαγή μεγέθους OLE των φύλλων εργασίας Excel στις παρουσιάσεις: δύο τρόποι για να διατηρήσετε συνεπή τα πλαίσια αντικειμένων — κλιμακώστε το πλαίσιο ή το φύλλο — σε μορφές PPT και PPTX."
---
{{% alert color="info" title="Note" %}}
Τα φύλλα εργασίας του Excel ενσωματωμένα ως αντικείμενα OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας τα στοιχεία Aspose ενδέχεται να αλλάξουν μέγεθος απροσδόκητα μετά την πρώτη τους ενεργοποίηση. Αυτή η συμπεριφορά δημιουργεί μια εμφανή οπτική διαφορά μεταξύ του αντικειμένου OLE πριν και μετά την ενεργοποίηση. Αυτό το άρθρο εξηγεί το πρόβλημα και περιγράφει δύο τρόπους αντιμετώπισής του.
{{% /alert %}} 

## **Ιστορικό**

Στο άρθρο [Διαχείριση OLE](/slides/el/python-net/manage-ole/), εξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for Python via .NET. Για να αντιμετωπίσουμε το [ζήτημα προεπισκόπησης αντικειμένου](/slides/el/python-net/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε μια εικόνα της επιλεγμένης περιοχής του φύλλου εργασίας στο πλαίσιο αντικειμένου OLE. Στην έξοδο της παρουσίασης, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του φύλλου, το βιβλίο εργασίας του Excel ενεργοποιείται. Οι τελικοί χρήστες μπορούν να κάνουν τις επιθυμητές αλλαγές στο πραγματικό βιβλίο εργασίας του Excel και στη συνέχεια να επιστρέψουν στη διαφάνεια κάνοντας κλικ έξω από το ενεργοποιημένο βιβλίο εργασίας. Το μέγεθος του πλαισίου αντικειμένου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο παράγοντας αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου αντικειμένου OLE και του ενσωματωμένου βιβλίου εργασίας του Excel. 

## **Αιτία της αλλαγής μεγέθους**

Επειδή το βιβλίο εργασίας του Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας του Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διατηρείται η σωστή αναλογία ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους προκύπτει βάσει των διαφορών μεταξύ του μεγέθους του παραθύρου του Excel και του μεγέθους και της θέσης του πλαισίου αντικειμένου OLE.

## **Λύση λειτουργίας**

Υπάρχουν δύο πιθανές λύσεις για την αποφυγή του φαινομένου αλλαγής μεγέθους.

- Κλιμάκωση του πλαισίου OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων σειρών και στηλών.
- Διατήρηση του μεγέθους του πλαισίου OLE σταθερό και κλιμάκωση των επιλεγμένων σειρών και στηλών ώστε να χωράει μέσα του.

### **Κλιμάκωση του μεγέθους του πλαισίου OLE**

Αυτή η προσέγγιση ορίζει το μέγεθος του πλαισίου OLE ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων σειρών και στηλών στο ενσωματωμένο φύλλο εργασίας του Excel.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας του Excel και επιλέγει τις πρώτες 10 σειρές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες που ξεκινούν από το μηδέν. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) ορίζει την εμφανιζόμενη περιοχή. Η προεπισκόπηση αποδίδεται στα 96 DPI και οι διαστάσεις των pixel μετατρέπονται σε σημεία χρησιμοποιώντας 72 σημεία ανά ίντσα. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) ενσωματώνει το τροποποιημένο βιβλίο εργασίας σε ένα πλαίσιο με αυτές τις διαστάσεις. Η προεπισκόπηση αντιστοιχίζεται μέσω του [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) για την αντικατάσταση του αντικειμένου κράτησης θέσης "EMBEDDED OLE OBJECT" στην αποθηκευμένη παρουσίαση.

Ο βοηθός προεπισκόπησης ορίζει το [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) στην επιλεγμένη περιοχή και αφαιρεί τα περιθώρια, τις κεφαλίδες και τα υποσέλιδα. Με ενεργοποιημένο το [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/), το [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) αποδίδει την περιοχή ως εικόνα PNG. Ο βοηθός επαναφέρει τη ροή εικόνας πριν την επιστρέψει για χρήση στην παρουσίαση.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

Το πλήρες παράδειγμα παρακάτω συνδυάζει τους βοηθούς με την ενσωμάτωση του βιβλίου εργασίας και αποθηκεύει την παρουσίαση ως `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Ορίστε το εμφανιζόμενο μέγεθος όταν το αρχείο εργασίου χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Αποκτήστε το πλάτος και το ύψος της εικόνας OLE σε σημεία.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Πρέπει να χρησιμοποιήσουμε το τροποποιημένο βιβλίο εργασίας.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Προσθέστε την εικόνα OLE στους πόρους της παρουσίασης.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Δημιουργήστε το πλαίσιο αντικειμένου OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Κλιμάκωση του μεγέθους περιοχής κελιών**

Αυτή η προσέγγιση κλιμακώνει τα ύψη των επιλεγμένων σειρών και τα πλάτη των επιλεγμένων στηλών ώστε να ταιριάζουν με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας του Excel και επιλέγει τις πρώτες 10 σειρές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες που ξεκινούν από το μηδέν. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) ορίζει την εμφανιζόμενη περιοχή, και ο παρακάτω βοηθός κλιμακώνει αυτήν την περιοχή ώστε να ταιριάζει με ένα πλαίσιο πλάτους 400 σημεία και ύψους 100 σημείων. Αφού αποθηκευτεί το τροποποιημένο βιβλίο εργασίας σε ροή, το [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) το ενσωματώνει στο καθορισμένο μέγεθος. Μια προεπισκόπηση από 96 DPI αντιστοιχίζεται μέσω του [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), ώστε η αποθηκευμένη παρουσίαση να εμφανίζει τα επιλεγμένα κελιά αντί του προεπιλεγμένου αντικειμένου κράτησης θέσης.

Ο βοηθός κλιμάκωσης υπολογίζει ξεχωριστούς συντελεστές πλάτους και ύψους για την επιλεγμένη περιοχή, διατηρώντας τα σχετικά πλάτη των στηλών της και τα σχετικά ύψη των σειρών της. Μετατρέπει τις υπολογισμένες διαστάσεις από σημεία σε ίντσες πριν τις εφαρμόσει με τις μεθόδους [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) και [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). Η επιλεγμένη περιοχή πρέπει να έχει μη μηδενικό πλάτος και ύψος.

```py
import aspose.cells as cells

# <param name="width">Το αναμενόμενο πλάτος της περιοχής κελιών σε σημεία.</param>
# <param name="height">Το αναμενόμενο ύψος της περιοχής κελιών σε σημεία.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

Αυτός ο βοηθός προεπισκόπησης αποδίδει την κλιμακωμένη περιοχή χρησιμοποιώντας το [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Περιορίζει το [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) σε αυτήν την περιοχή, αφαιρεί τα περιθώρια, τις κεφαλίδες και τα υποσέλιδα και επιστρέφει μια ροή PNG τοποθετημένη στην αρχή της.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

Το πλήρες παράδειγμα παρακάτω συνδυάζει τους βοηθούς με την ενσωμάτωση του βιβλίου εργασίας και αποθηκεύει την παρουσίαση ως `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">Το αναμενόμενο πλάτος της περιοχής κελιών σε σημεία.</param>
# <param name="height">Το αναμενόμενο ύψος της περιοχής κελιών σε σημεία.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Ορίστε το εμφανιζόμενο μέγεθος όταν το αρχείο βιβλίου εργασίας χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Κλιμακώστε την περιοχή κελιών ώστε να ταιριάζει με το μέγεθος του πλαισίου.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Πρέπει να χρησιμοποιήσουμε το τροποποιημένο βιβλίο εργασίας.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Προσθέστε την εικόνα OLE στους πόρους της παρουσίασης.
            ole_image = presentation.images.add_image(image_stream)

            # Δημιουργήστε το πλαίσιο αντικειμένου OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Συμπέρασμα**

{{% alert color="info" title="Note" %}}
Υπάρχουν δύο προσεγγίσεις για την διόρθωση του ζητήματος αλλαγής μεγέθους των φύλλων εργασίας. Επιλέξτε την προσέγγιση που ταιριάζει καλύτερα στις απαιτήσεις και στην περίπτωση χρήσης σας. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από το μηδέν. Επιπλέον, δεν υπάρχει περιορισμός στο μέγεθος του πλαισίου αντικειμένου OLE σε αυτή τη λύση.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Γιατί ένα ενσωματωμένο φύλλο εργασίας του Excel αλλάζει μέγεθος όταν ενεργοποιείται για πρώτη φορά στο PowerPoint;**  
Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος του παραθύρου κατά την ενεργοποίησή του, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει την αλλαγή μεγέθους.

**Μπορεί κανείς να αποτρέψει εντελώς αυτό το πρόβλημα αλλαγής μεγέθους;**  
Ναι. Κλιμακώνοντας το πλαίσιο OLE ώστε να ταιριάζει με το μέγεθος της περιοχής κελιών του Excel ή κλιμακώνοντας την περιοχή κελιών ώστε να ταιριάζει με το επιθυμητό μέγεθος πλαισίου OLE, μπορείτε να αποτρέψετε την ανεπιθύμητη αλλαγή μεγέθους.

**Ποια μέθοδο κλιμάκωσης πρέπει να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση περιοχής κελιών;**  
Επιλέξτε **κλιμάκωση πλαισίου OLE** εάν θέλετε να διατηρήσετε τα αρχικά μεγέθη των σειρών και στηλών του Excel. Επιλέξτε **κλιμάκωση περιοχής κελιών** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργούν αυτές οι λύσεις αν η παρουσίασή μου βασίζεται σε πρότυπο;**  
Ναι. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα καθώς και από το μηδέν.

**Υπάρχει περιορισμός στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**  
Όχι. Μπορείτε να ορίσετε το πλαίσιο αντικειμένου OLE σε οποιοδήποτε μέγεθος, εφόσον ρυθμίσετε τη κλιμάκωση ανάλογα.

**Υπάρχει τρόπος να αποφευχθεί το κείμενο κράτησης θέσης "EMBEDDED OLE OBJECT" στο PowerPoint;**  
Ναι. Λαμβάνοντας ένα στιγμιότυπο της επιλεγμένης περιοχής κελιών του Excel και ορίζοντάς το ως εικόνα κράτησης θέσης του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη εικόνα προεπισκόπησης στη θέση του προεπιλεγμένου αντικειμένου κράτησης θέσης.