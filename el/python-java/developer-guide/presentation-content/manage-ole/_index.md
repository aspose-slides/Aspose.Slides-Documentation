---
title: Διαχείριση OLE σε Παρουσιάσεις με Python
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/python-java/manage-ole/
keywords:
- αντικείμενο OLE
- Σύνδεση & Ενσωμάτωση Αντικειμένων
- προσθήκη OLE
- ενσωμάτωση OLE
- προσθήκη αντικειμένου
- ενσωμάτωση αντικειμένου
- προσθήκη αρχείου
- ενσωμάτωση αρχείου
- συνδεδεμένο αντικείμενο
- συνδεμένο αρχείο
- αλλαγή OLE
- εικονίδιο OLE
- τίτλος OLE
- εξαγωγή OLE
- εξαγωγή αντικειμένου
- εξαγωγή αρχείου
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE στο PowerPoint και σε αρχεία OpenDocument με το Aspose.Slides για Python μέσω Java. Ενσωματώστε, ενημερώστε και εξαγάγετε το περιεχόμενο OLE άψογα."
---
## **Εισαγωγή**

{{% alert color="info" title="Σημείωση" %}}

OLE (Object Linking & Embedding) είναι μια τεχνολογία της Microsoft που επιτρέπει τα δεδομένα και τα αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης.

{{% /alert %}}

Θεωρήστε ένα γράφημα που δημιουργήθηκε στο MS Excel. Το γράφημα τοποθετείται στη συνέχεια σε μια διαφάνεια PowerPoint. Αυτό το γράφημα Excel θεωρείται αντικείμενο OLE.

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτήν την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το γράφημα ανοίγει στην σχετική του εφαρμογή (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου.
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα δεδομένα ενός γραφήματος. Σε αυτήν την περίπτωση, το γράφημα ενεργοποιείται στο PowerPoint, η διεπαφή του γραφήματος φορτώνεται και μπορείτε να τροποποιήσετε τα δεδομένα του γραφήματος μέσα στο PowerPoint.

[Aspose.Slides για Python μέσω Java](https://products.aspose.com/slides/el/python-java/) σας επιτρέπει να εισάγετε αντικείμενα OLE σε διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/)).

## **Προσθήκη πλαισίων αντικειμένων OLE σε διαφάνειες**

Αν έχετε ήδη δημιουργήσει ένα γράφημα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides για Python μέσω Java, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
3. Διαβάστε το αρχείο Excel ως πίνακα bytes.
4. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) στη διαφάνεια περιέχοντας τον πίνακα bytes και άλλες πληροφορίες για το αντικείμενο OLE.
5. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα γράφημα από αρχείο Excel σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides για Python μέσω Java.  
**Σημείωση** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleembeddeddatainfo/) λαμβάνει την επέκταση του ενσωματωμένου αντικειμένου ως δεύτερο παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύει σωστά τον τύπο του αρχείου και να επιλέγει την κατάλληλη εφαρμογή για το άνοιγμα του αντικειμένου OLE.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Προετοιμάστε τα δεδομένα για το αντικείμενο OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Προσθέστε το πλαίσιο αντικειμένου OLE στη διαφάνεια.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Προσθήκη συνδεδεμένων πλαισίων αντικειμένων OLE**

Το Aspose.Slides για Python μέσω Java σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) με σύνδεσμο προς το αρχείο αντί για ενσωματωμένα δεδομένα.

Αυτός ο κώδικας Python δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) με συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Προσθέστε ένα πλαίσιο αντικειμένου OLE με συνδεδεμένο αρχείο Excel.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε πλαίσια αντικειμένων OLE**

Αν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το προσπελάσετε με αυτόν τον τρόπο:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά στη διαφάνεια με βάση τον δείκτη της.
3. Προσπελάστε το σχήμα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) . Στο παράδειγμά μας, χρησιμοποιήσαμε το PPTX που δημιουργήθηκε προηγουμένως και έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια ελέγξαμε ότι το αντικείμενο ήταν ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις το πλαίσιο αντικειμένου OLE προσεγγιστεί, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία πάνω του.

Στο παρακάτω παράδειγμα, προσπελάζεται ένα πλαίσιο αντικειμένου OLE (αντικείμενο γραφήματος Excel ενσωματωμένο σε διαφάνεια) και τα δεδομένα του αρχείου του.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Λάβετε τα ενσωματωμένα δεδομένα αρχείου.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Λάβετε την επέκταση του ενσωματωμένου αρχείου.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Πρόσβαση σε ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE**

Το Aspose.Slides σας επιτρέπει να προσπελάσετε τις ιδιότητες του συνδεδεμένου πλαισίου αντικειμένου OLE.

Αυτός ο κώδικας Python δείχνει πώς να ελέγξετε αν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να λάβετε τη διαδρομή του συνδεδεμένου αρχείου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Ελέγξτε αν το αντικείμενο OLE είναι συνδεδεμένο.
        if ole_frame.isObjectLink():
            # Εκτυπώστε τη πλήρη διαδρομή του συνδεδεμένου αρχείου.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Εκτυπώστε τη σχετική διαδρομή του συνδεδεμένου αρχείου αν υπάρχει.
            # Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν τη σχετική διαδρομή.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Αλλαγή δεδομένων αντικειμένου OLE**

{{% alert color="info" title="Σημείωση" %}}

Σε αυτή την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells για Python μέσω Java](https://products.aspose.com/cells/python-java/) .

{{% /alert %}}

Αν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να προσπελάσετε αυτό το αντικείμενο και να τροποποιήσετε τα δεδομένα του με τον εξής τρόπο:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά στη διαφάνεια με βάση τον δείκτη της.
3. Προσπελάστε το σχήμα του πλαισίου αντικειμένου OLE. Στο παράδειγμά μας, χρησιμοποιήσαμε το PPTX που δημιουργήθηκε προηγουμένως και έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια ελέγξαμε ότι το αντικείμενο ήταν ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις το πλαίσιο αντικειμένου OLE προσεγγιστεί, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία πάνω του.
5. Δημιουργήστε ένα αντικείμενο [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) και προσπελάστε τα δεδομένα OLE.
6. Προσπελάστε το επιθυμητό [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) και τροποποιήστε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) σε ροή.
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (αντικείμενο γραφήματος Excel ενσωματωμένο σε διαφάνεια) προσπελάζεται και τα δεδομένα του αρχείου του τροποποιούνται ώστε να ενημερωθούν τα δεδομένα του γραφήματος.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Διαβάστε τα δεδομένα του αντικειμένου OLE ως αντικείμενο Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Τροποποιήστε τα δεδομένα του workbook.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Αλλάξτε τα δεδομένα του αντικειμένου πλαισίου OLE.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ενσωμάτωση άλλων τύπων αρχείων σε διαφάνειες**

Εκτός από γραφήματα Excel, το Aspose.Slides για Python μέσω Java σας επιτρέπει να ενσωματώσετε άλλους τύπους αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε HTML, PDF και ZIP αρχεία ως αντικείμενα. Όταν ο χρήστης κάνει διπλό κλικ στο εισαχθέν αντικείμενο, αυτό ανοίγει αυτόματα στο σχετικό πρόγραμμα, ή του ζητείται να επιλέξει ένα κατάλληλο πρόγραμμα για το άνοιγμα.

Αυτός ο κώδικας Python δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός τύπων αρχείων για ενσωματωμένα αντικείμενα**

Κατά την εργασία με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides για Python μέσω Java σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντάς σας να ενημερώσετε τα δεδομένα του πλαισίου OLE ή την επέκτασή του.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE σε `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Αλλάξτε τον τύπο αρχείου σε ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός εικόνων εικονιδίων και τίτλων για ενσωματωμένα αντικείμενα**

Αφού ενσωματωθεί ένα αντικείμενο OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι αυτό που βλέπουν οι χρήστες πριν αποκτήσουν πρόσβαση ή ανοίξουν το αντικείμενο OLE. Αν θέλετε να χρησιμοποιήσετε συγκεκριμένη εικόνα και κείμενο ως στοιχεία της προεπισκόπησης, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides για Python μέσω Java.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Προσθέστε μια εικόνα στους πόρους της παρουσίασης.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Ορίστε έναν τίτλο και την εικόνα για την προεπισκόπηση OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αποτροπή αλλαγής μεγέθους και θέσης πλαισίου αντικειμένου OLE**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίξετε την παρουσίαση σε PowerPoint, μπορεί να εμφανιστεί μήνυμα που ζητά την ενημέρωση των συνδέσμων. Κάνοντας κλικ στο κουμπί «Update Links» μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση. Για να αποτρέψετε το PowerPoint από το να ζητά ενημέρωση των δεδομένων του αντικειμένου, ορίστε τη μέθοδο [setUpdateAutomatic](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) της κλάσης [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) σε `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Εξαγωγή ενσωματωμένων αρχείων**

Το Aspose.Slides για Python μέσω Java σας επιτρέπει να εξάγετε τα αρχεία που είναι ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE με τον εξής τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που περιέχει τα αντικείμενα OLE που θέλετε να εξάγετε.
2. Περάστε από όλα τα σχήματα στην παρουσία και προσπελάστε τα σχήματα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) .
3. Προσπελάστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένων OLE και γράψτε τα στο δίσκο.

Αυτός ο κώδικας Python δείχνει πώς να εξάγετε αρχεία που είναι ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Θα αποδίδεται το περιεχόμενο OLE κατά την εξαγωγή διαφανειών σε PDF/εικόνες;**

Αυτό που εμφανίζεται στη διαφάνεια αποδίδεται — το εικονίδιο/εικόνα υποκατάστασης (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Αν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης για να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει [κλειδώματα επιπέδου σχήματος](/slides/el/python-java/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες επεμβάσεις και μετακινήσεις.

**Γιατί ένα συνδεδεμένο αντικείμενο Excel «πηδά» ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;**

Το PowerPoint μπορεί να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/python-java/working-solution-for-worksheet-resizing/) — είτε προσαρμόστε το πλαίσιο στην περιοχή, είτε κλιμακώστε την περιοχή σε σταθερό πλαίσιο και ορίστε μια κατάλληλη εικόνα υποκατάστασης.

**Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, οι πληροφορίες «σχετική διαδρομή» δεν είναι διαθέσιμες — μόνο η πλήρης διαδρομή. Οι σχετικές διαδρομές υπάρχουν στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/προσβάσιμες URI ή ενσωμάτωση.