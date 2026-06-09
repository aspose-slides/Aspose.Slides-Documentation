---
title: Λειτουργική Λύση για τη Αλλαγή Μεγέθους Φύλλου Εργασίας
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
description: "Διορθώστε την αλλαγή μεγέθους OLE φύλλου εργασίας Excel σε παρουσιάσεις: δύο τρόπους για να διατηρήσετε τα πλαίσια αντικειμένων σταθερά—κλιμακώστε το πλαίσιο ή το φύλλο—σε μορφές PPT και PPTX."
---
{{% alert color="primary" %}} 

Έχει παρατηρηθεί ότι τα φύλλα εργασίας του Excel που ενσωματώνονται ως αντικείμενα OLE σε μια παρουσίαση PowerPoint μέσω των στοιχείων Aspose αλλάζουν μέγεθος σε άγνωστη κλίμακα μετά την πρώτη ενεργοποίηση. Αυτή η συμπεριφορά δημιουργεί εμφανή οπτική διαφορά στην παρουσίαση μεταξύ των καταστάσεων πριν και μετά την ενεργοποίηση του αντικειμένου OLE. Έχουμε ερευνήσει λεπτομερώς αυτό το ζήτημα και παρέχουμε μια λύση, η οποία καλύπτεται σε αυτό το άρθρο.

{{% /alert %}} 

## **Background**

Στο άρθρο [Manage OLE](/slides/el/python-net/manage-ole/), επεξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for Python μέσω .NET. Για να αντιμετωπίσουμε το [object preview issue](/slides/el/python-net/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε μια εικόνα της επιλεγμένης περιοχής του φύλλου εργασίας στο πλαίσιο αντικειμένου OLE. Στην τελική παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του φύλλου, το βιβλίο εργασίας του Excel ενεργοποιείται. Οι τελικοί χρήστες μπορούν να κάνουν οποιεσδήποτε επιθυμητές αλλαγές στο πραγματικό βιβλίο εργασίας του Excel και στη συνέχεια να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας. Το μέγεθος του πλαισίου αντικειμένου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο παράγοντας αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου αντικειμένου OLE και του ενσωματωμένου βιβλίου εργασίας του Excel. 

## **Cause of Resizing**

Καθώς το βιβλίο εργασίας του Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας του Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διασφαλίσουν ότι διατηρεί τις σωστές αναλογίες ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους λαμβάνει χώρα βάσει των διαφορών μεταξύ του μεγέθους του παραθύρου του Excel και του μεγέθους και της θέσης του πλαισίου αντικειμένου OLE. 

## **Working Solution**

Υπάρχουν δύο πιθανές λύσεις για να αποφευχθεί το φαινόμενο αλλαγής μεγέθους.

- Κλιμακώστε το μέγεθος του πλαισίου OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το ύψος και το πλάτος του επιθυμητού αριθμού σειρών και στηλών στο πλαίσιο OLE.
- Διατηρήστε το μέγεθος του πλαισίου OLE σταθερό και κλιμακώστε το μέγεθος των συμμετεχόντων σειρών και στηλών ώστε να χωράει στο επιλεγμένο μέγεθος πλαισίου OLE.

### **Scale the OLE Frame Size**

Σε αυτήν την προσέγγιση, θα μάθουμε πώς να ορίσουμε το μέγεθος του πλαισίου OLE του ενσωματωμένου βιβλίου εργασίας του Excel ώστε να ταιριάζει με το συνολικό μέγεθος των συμμετεχόντων σειρών και στηλών στο φύλλο εργασίας του Excel.

Ας υποθέσουμε ότι έχουμε ένα πρότυπο φύλλο Excel και θέλουμε να το προσθέσουμε σε μια παρουσίαση ως πλαίσιο OLE. Σε αυτό το σενάριο, το μέγεθος του πλαισίου αντικειμένου OLE θα υπολογιστεί αρχικά βάσει του συνολικού ύψους των σειρών και του πλάτους των στηλών των συμμετεχόντων στη βιβλιοθήκη. Στη συνέχεια, θα ορίσουμε το μέγεθος του πλαισίου OLE στην υπολογισμένη αυτή τιμή. Για να αποφύγουμε το κόκκινο μήνυμα "EMBEDDED OLE OBJECT" για το πλαίσιο OLE στο PowerPoint, θα καταγράψουμε επίσης μια εικόνα των επιθυμητών τμημάτων των σειρών και στηλών στο βιβλίο εργασίας και θα την ορίσουμε ως εικόνα του πλαισίου OLE.

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Ορίστε το εμφανιζόμενο μέγεθος όταν το αρχείο βιβλίου εργασίας χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Λάβετε το πλάτος και το ύψος της εικόνας OLE σε σημεία.
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

### **Scale the Cell Range Size**

Σε αυτήν την προσέγγιση, θα μάθουμε πώς να κλιμακώσουμε τα ύψος των συμμετεχόντων σειρών και το πλάτος των συμμετεχόντων στηλών ώστε να ταιριάζουν με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Ας υποθέσουμε ότι έχουμε ένα πρότυπο φύλλο Excel και θέλουμε να το προσθέσουμε σε μια παρουσίαση ως πλαίσιο OLE. Σε αυτό το σενάριο, θα ορίσουμε το μέγεθος του πλαισίου OLE και θα κλιμακώσουμε το μέγεθος των σειρών και στηλών που συμμετέχουν στην περιοχή του πλαισίου OLE. Στη συνέχεια, θα αποθηκεύσουμε το βιβλίο εργασίας σε ροή για να εφαρμόσουμε τις αλλαγές και θα το μετατρέψουμε σε πίνακα byte για την προσθήκη του στο πλαίσιο OLE. Για να αποφύγουμε το κόκκινο μήνυμα "EMBEDDED OLE OBJECT" για το πλαίσιο OLE στο PowerPoint, θα καταγράψουμε επίσης μια εικόνα των επιθυμητών τμημάτων των σειρών και στηλών στο βιβλίο εργασίας και θα την ορίσουμε ως εικόνα του πλαισίου OLE.

```py
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

```py
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

```py
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

## **Conclusion**

{{% alert color="primary" %}}

Υπάρχουν δύο προσεγγίσεις για τη διόρθωση του προβλήματος αλλαγής μεγέθους του φύλλου εργασίας. Η επιλογή της κατάλληλης προσέγγισης εξαρτάται από τις συγκεκριμένες απαιτήσεις και τη χρήση. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από το μηδέν. Επιπλέον, δεν υπάρχει όριο στο μέγεθος του πλαισίου αντικειμένου OLE σε αυτή τη λύση.

{{% /alert %}}