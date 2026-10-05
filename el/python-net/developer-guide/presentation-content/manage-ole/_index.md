---
title: Διαχείριση OLE σε Παρουσιάσεις με Python
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/python-net/manage-ole/
keywords:
- Αντικείμενο OLE
- Σύνδεση & Ενσωμάτωση Αντικειμένων
- Προσθήκη OLE
- Ενσωμάτωση OLE
- Προσθήκη αντικειμένου
- Ενσωμάτωση αντικειμένου
- Προσθήκη αρχείου
- Ενσωμάτωση αρχείου
- Συνδεδεμένο αντικείμενο
- Συνδεδεμένο αρχείο
- Αλλαγή OLE
- Εικονίδιο OLE
- Τίτλος OLE
- Εξαγωγή OLE
- Εξαγωγή αντικειμένου
- Εξαγωγή αρχείου
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE στο PowerPoint και σε αρχεία OpenDocument με το Aspose.Slides για Python μέσω .NET. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE άψογα."
---
## **Εισαγωγή**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)** είναι μια τεχνολογία της Microsoft που επιτρέπει στα δεδομένα και στα αντικείμενα που δημιουργούνται σε μια εφαρμογή να συνδέονται ή να ενσωματώνονται σε άλλη.

{{% /alert %}}

Για παράδειγμα, ένα γράφημα που δημιουργήθηκε στο Microsoft Excel και τοποθετήθηκε σε μια διαφάνεια του PowerPoint είναι ένα αντικείμενο OLE.

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Με διπλό κλικ στο εικονίδιο, ανοίγει το αντικείμενο στην συσχετισμένη του εφαρμογή (π.χ., Excel) ή εμφανίζεται προτροπή για την επιλογή μιας εφαρμογής για άνοιγμα ή επεξεργασία.
- Ένα αντικείμενο OLE μπορεί να εμφανίζει τα περιεχόμενά του (π.χ., ένα γράφημα). Στην περίπτωση αυτή, το PowerPoint ενεργοποιεί το ενσωματωμένο αντικείμενο, φορτώνει τη διεπαφή του γραφήματος και σας επιτρέπει να επεξεργαστείτε τα δεδομένα του γραφήματος μέσα στο PowerPoint.

Η Aspose.Slides για Python σας επιτρέπει να εισάγετε αντικείμενα OLE σε διαφάνειες ως πλαίσια αντικειμένου OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Προσθήκη αντικειμένων OLE σε διαφάνειες**

Εάν έχετε ήδη δημιουργήσει ένα γράφημα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας την Aspose.Slides για Python, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
1. Διαβάστε το αρχείο Excel σε έναν πίνακα byte.
1. Προσθέστε ένα [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) στη διαφάνεια, παρέχοντας τον πίνακα byte και άλλα στοιχεία του αντικειμένου OLE.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, ένα γράφημα από αρχείο Excel ενσωματώνεται σε μια διαφάνεια ως [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Σημείωση:** Ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) λαμβάνει ως δεύτερη παράμετρο την επέκταση αρχείου του ενσωματώσιμου αντικειμένου. Το PowerPoint χρησιμοποιεί αυτήν την επέκταση για να προσδιορίσει τον τύπο αρχείου και να επιλέξει την κατάλληλη εφαρμογή για άνοιγμα του αντικειμένου OLE.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Προετοιμάστε τα δεδομένα για το αντικείμενο OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Προσθέστε ένα πλαίσιο αντικειμένου OLE στη διαφάνεια.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Προσθήκη συνδεδεμένων αντικειμένων OLE**

Η Aspose.Slides για Python σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) που συνδέεται σε ένα αρχείο αντί για την ενσωμάτωση των δεδομένων του.

Το παρακάτω παράδειγμα Python δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) που συνδέεται σε αρχείο Excel σε μια διαφάνεια:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθέστε ένα πλαίσιο αντικειμένου OLE με ένα συνδεδεμένο αρχείο Excel.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε αντικείμενα OLE**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε να έχετε πρόσβαση σε αυτό ως εξής:

1. Φορτώστε την παρουσία που περιέχει το ενσωματωμένο αντικείμενο OLE δημιουργώντας ένα στιγμιότυπο της κλάσης Presentation.
1. Αποκτήστε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
1. Πρόσβαση στο σχήμα OleObjectFrame.
1. Μόλις έχετε το πλαίσιο αντικειμένου OLE, εκτελέστε τυχόν απαιτούμενες λειτουργίες πάνω του.

Το παρακάτω παράδειγμα έχει πρόσβαση στο πλαίσιο αντικειμένου OLE — ένα ενσωματωμένο γράφημα Excel — και ανακτά τα δεδομένα αρχείου του. Σε αυτό το παράδειγμα, χρησιμοποιούμε ένα PPTX που έχει ένα μόνο σχήμα στην πρώτη διαφάνεια.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Αποκτήστε τα ενσωματωμένα δεδομένα αρχείου.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Αποκτήστε την επέκταση του ενσωματωμένου αρχείου.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Πρόσβαση σε ιδιότητες συνδεδεμένου αντικειμένου OLE**

Η Aspose.Slides σας επιτρέπει να έχετε πρόσβαση στις ιδιότητες ενός συνδεδεμένου πλαισίου αντικειμένου OLE.

Το παρακάτω παράδειγμα Python ελέγχει αν ένα αντικείμενο OLE είναι συνδεδεμένο και, εάν είναι, ανακτά τη διαδρομή του συνδεδεμένου αρχείου:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Ελέγξτε εάν το αντικείμενο OLE είναι συνδεδεμένο.
        if ole_frame.is_object_link:
            # Εκτυπώστε την πλήρη διαδρομή του συνδεδεμένου αρχείου.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Εκτυπώστε τη σχετική διαδρομή του συνδεδεμένου αρχείου, εάν υπάρχει.
            # Μόνο παρουσιάσεις .ppt μπορούν να περιέχουν σχετική διαδρομή.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Αλλαγή δεδομένων αντικειμένου OLE**

{{% alert color="info" title="Note" %}}

Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).

{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε να το προσπελάσετε και να τροποποιήσετε τα δεδομένα του ως εξής:

1. Φορτώστε την παρουσία δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Αποκτήστε τη στοχευμένη διαφάνεια με βάση το δείκτη της.
1. Πρόσβαση στο σ shape [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. Μόλις έχετε το πλαίσιο αντικειμένου OLE, εκτελέστε τις απαιτούμενες λειτουργίες πάνω του.
1. Δημιουργήστε ένα αντικείμενο `Workbook` και διαβάστε τα δεδομένα OLE.
1. Ανοίξτε το επιθυμητό `Worksheet` και επεξεργαστείτε τα δεδομένα.
1. Αποθηκεύστε το ενημερωμένο `Workbook` σε μια ροή.
1. Αντικαταστήστε τα δεδομένα του αντικειμένου OLE χρησιμοποιώντας αυτή τη ροή.

Στο παρακάτω παράδειγμα, το πλαίσιο αντικειμένου OLE (ένα ενσωματωμένο γράφημα Excel) προσπελάζεται και τα δεδομένα αρχείου του τροποποιούνται για να ενημερώσουν το γράφημα. Το δείγμα χρησιμοποιεί ένα προηγούμενα δημιουργημένο PPTX που περιέχει ένα μόνο σχήμα στην πρώτη διαφάνεια.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Διαβάστε τα δεδομένα του αντικειμένου OLE ως αντικείμενο Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Τροποποιήστε τα δεδομένα του βιβλίου εργασίας.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Αλλάξτε τα δεδομένα του αντικειμένου πλαισίου OLE.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ενσωμάτωση αρχείων σε διαφάνειες**

Εκτός από τα γραφήματα Excel, η Aspose.Slides για Python σας επιτρέπει να ενσωματώνετε άλλα είδη αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε αρχεία HTML, PDF και ZIP ως αντικείμενα. Όταν ένας χρήστης κάνει διπλό κλικ σε ένα εισαχθέν αντικείμενο, ανοίγει αυτόματα στην συσχετισμένη εφαρμογή ή του ζητείται να επιλέξει ένα κατάλληλο πρόγραμμα.

Ο παρακάτω κώδικας Python δείχνει πώς να ενσωματώσετε αρχεία HTML και ZIP σε μια διαφάνεια:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός τύπων αρχείων για ενσωματωμένα αντικείμενα**

Κατά τη δουλειά με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με καινούργια ή να ανταλλάξετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Η Aspose.Slides για Python σας επιτρέπει να ορίσετε τον τύπο αρχείου ενός ενσωματωμένου αντικειμένου, επιτρέποντας την ενημέρωση των δεδομένων του πλαισίου OLE ή της επέκτασής του.

Ο παρακάτω κώδικας Python δείχνει πώς να ορίσετε τον τύπο αρχείου του ενσωματωμένου αντικειμένου OLE σε `zip`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Αλλάξτε τον τύπο αρχείου σε ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός εικόνων εικονιδίων και τίτλων για ενσωματωμένα αντικείμενα**

Αφού ενσωματώσετε ένα αντικείμενο OLE, προστίθεται αυτόματα μια προεπισκόπηση βασισμένη σε εικονίδιο. Αυτή η προεπισκόπηση είναι αυτή που βλέπουν οι χρήστες πριν αποκτήσουν πρόσβαση ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας την Aspose.Slides για Python.

Ο παρακάτω κώδικας Python δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Προσθέστε μια εικόνα στους πόρους της παρουσίασης.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Ορίστε έναν τίτλο και την εικόνα για την προεπισκόπηση OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Αποτροπή αλλαγής μεγέθους και μετακίνησης πλαισίων αντικειμένου OLE**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια, το PowerPoint μπορεί να σας ζητήσει να ενημερώσετε τους συνδέσμους όταν ανοίγετε την παρουσία. Η επιλογή «Update Links» μπορεί να αλλάξει το μέγεθος και τη θέση του πλαισίου αντικειμένου OLE επειδή το PowerPoint ανανεώνει την προεπισκόπηση με δεδομένα από το συνδεδεμένο αντικείμενο. Για να αποτρέψετε το PowerPoint από το να σας ζητήσει την ενημέρωση των δεδομένων του αντικειμένου, ορίστε την ιδιότητα `update_automatic` της κλάσης [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) σε `False`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Εξαγωγή ενσωματωμένων αρχείων**

Η Aspose.Slides για Python σας επιτρέπει να εξάγετε αρχεία ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE ως εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) που περιέχει τα αντικείμενα OLE που θέλετε να εξαγάγετε.
1. Διατρέξτε όλα τα σχήματα στην παρουσία και εντοπίστε τα σχήματα OLEObjectFrame.
1. Ανακτήστε τα ενσωματωμένα δεδομένα αρχείου από κάθε [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) και γράψτε τα στο δίσκο.

Ο παρακάτω κώδικας Python δείχνει πώς να εξάγετε αρχεία ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **Συχνές ερωτήσεις**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται—το εικονίδιο/εικονική εικόνα (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Εάν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης για να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

Για επίσης να διατηρήσετε το ενσωματωμένο αρχείο ως συνημμένο PDF, ορίστε το [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) σε `True`. Αυτή η επιλογή είναι ανενεργή εξ ορισμού. Για ένα παράδειγμα και οδηγίες ελέγχου του συνημμένου, δείτε [Διατήρηση ενσωματωμένων αρχείων OLE ως συνημμένα PDF](/slides/el/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: η Aspose.Slides παρέχει [κλειδώματα επιπέδου σχήματος](/slides/el/python-net/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά ακούσιες επεμβάσεις και μετακινήσεις.

**Γιατί ένα συνδεδεμένο αντικείμενο Excel «πηδά» ή αλλάζει μέγεθος όταν ανοίγω την παρουσία;**

Το PowerPoint ενδέχεται να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Λύση λειτουργίας για την αλλαγή μεγέθους φύλλου εργασίας](/slides/el/python-net/working-solution-for-worksheet-resizing/) — είτε προσαρμόστε το πλαίσιο στο εύρος, είτε κλιμακώστε το εύρος σε σταθερό πλαίσιο και ορίστε μια κατάλληλη εικονική εικόνα.

**Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, δεν διατίθενται πληροφορίες «σχετικής διαδρομής»—μόνο η πλήρης διαδρομή. Σχετικές διαδρομές υπάρχουν μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/πρόσβαση σε URI ή ενσωμάτωση.