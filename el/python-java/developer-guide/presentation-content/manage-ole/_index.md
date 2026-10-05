---
title: Διαχείριση OLE σε Παρουσιάσεις με Python
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/python-java/manage-ole/
keywords:
- Αντικείμενο OLE
- Σύνδεση και Ενσωμάτωση Αντικειμένων
- προσθήκη OLE
- ενσωμάτωση OLE
- προσθήκη αντικειμένου
- ενσωμάτωση αντικειμένου
- προσθήκη αρχείου
- ενσωμάτωση αρχείου
- συνδεδεμένο αντικείμενο
- συνδεδεμένο αρχείο
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
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE σε αρχεία PowerPoint και OpenDocument με το Aspose.Slides for Python via Java. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE άψογα."
---
## **Εισαγωγή**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) είναι μια τεχνολογία της Microsoft που επιτρέπει τα δεδομένα και τα αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης.
{{% /alert %}}

Θεωρήστε ένα διάγραμμα που δημιουργήθηκε στο MS Excel. Το διάγραμμα τοποθετείται στη συνέχεια μέσα σε μια διαφάνεια του PowerPoint. Αυτό το διάγραμμα Excel θεωρείται αντικείμενο OLE.

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτή την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το διάγραμμα ανοίγει στην σχετική εφαρμογή (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου.
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα δεδομένα ενός διαγράμματος. Σε αυτή την περίπτωση, το διάγραμμα ενεργοποιείται στο PowerPoint, φορτώνεται η διεπαφή του διαγράμματος, και μπορείτε να τροποποιήσετε τα δεδομένα του διαγράμματος μέσα στο PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/) σας επιτρέπει να εισάγετε αντικείμενα OLE σε διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)).

## **Προσθήκη Πλαισίων Αντικειμένων OLE σε Διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα διάγραμμα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for Python via Java, μπορείτε να το κάνετε με τον εξής τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με το δείκτη της.
1. Διαβάστε το αρχείο Excel ως πίνακα byte.
1. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) στη διαφάνεια που περιέχει τον πίνακα byte και άλλες πληροφορίες για το αντικείμενο OLE.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα διάγραμμα από αρχείο Excel σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. **Σημείωση** ότι ο κατασκευαστής του [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) δέχεται μια επέκταση ενσωματώσιμου αντικειμένου ως δεύτερη παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύσει σωστά τον τύπο αρχείου και να επιλέξει τη σωστή εφαρμογή για το άνοιγμα του αντικειμένου OLE.

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

### **Προσθήκη Συνδεδεμένων Πλαισίων Αντικειμένου OLE**

Το Aspose.Slides for Python via Java σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) με σύνδεσμο προς το αρχείο αντί για ενσωματωμένα δεδομένα.

Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) με ένα συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

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

## **Πρόσβαση σε Πλαίσια Αντικειμένου OLE**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το εντοπίσετε ή να το προσπελάσετε με αυτόν τον τρόπο:

1. Φορτώστε μια παρουσία που περιέχει το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
3. Προσπελάστε το σχήμα [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενα δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια ελέγξαμε ότι το αντικείμενο ήταν ένα [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE που πρέπει να προσπελαστεί.
4. Μonce που το πλαίσιο αντικειμένου OLE έχει προσπελαστεί, μπορείτε να εκτελέσετε οποιαδήποτε ενέργεια πάνω του.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (αντικείμενο διαγράμματος Excel ενσωματωμένο σε μια διαφάνεια) και τα δεδομένα αρχείου του προσπεπθήκαν.

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

        # Αποκτήστε τα δεδομένα του ενσωματωμένου αρχείου.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Αποκτήστε την επέκταση του ενσωματωμένου αρχείου.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Πρόσβαση στις Ιδιότητες Συνδεδεμένου Πλαισίου Αντικειμένου OLE**

Το Aspose.Slides σας επιτρέπει να προσπελάσετε τις ιδιότητες των συνδεδεμένων πλαισίων αντικειμένου OLE.

Αυτός ο κώδικας Python σας δείχνει πώς να ελέγξετε αν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να λάβετε τη διαδρομή του συνδεδεμένου αρχείου:

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
            # Εκτυπώστε το πλήρες μονοπάτι του συνδεδεμένου αρχείου.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Εκτυπώστε το σχετικό μονοπάτι του συνδεδεμένου αρχείου αν υπάρχει.
            # Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν το σχετικό μονοπάτι.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Αλλαγή Δεδομένων Αντικειμένου OLE**

{{% alert color="info" title="Note" %}}
Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να προσπελάσετε αυτό το αντικείμενο και να τροποποιήσετε τα δεδομένα του με αυτόν τον τρόπο:

1. Φορτώστε μια παρουσία που περιέχει το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
3. Προσπελάστε το σχήμα πλαισίου OLE. Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενα δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια ελέγξαμε ότι το αντικείμενο ήταν ένα [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE που πρέπει να προσπελαστεί.
4. Μonce που το πλαίσιο αντικειμένου OLE έχει προσπελαστεί, μπορείτε να εκτελέσετε οποιαδήποτε ενέργεια πάνω του.
5. Δημιουργήστε ένα αντικείμενο [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) και προσπελάστε τα δεδομένα OLE.
6. Προσπελάστε το επιθυμητό [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) και τροποποιήστε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) σε μια ροή (stream).
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, προσπεπθήκε ένα πλαίσιο αντικειμένου OLE (αντικείμενο διαγράμματος Excel ενσωματωμένο σε μια διαφάνεια) και τα δεδομένα αρχείου του τροποποιήθηκαν για την ενημέρωση των δεδομένων του διαγράμματος.

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

## **Ενσωμάτωση Άλλων Τύπων Αρχείων σε Διαφάνειες**

Εκτός από διαγράμματα Excel, το Aspose.Slides for Python via Java σας επιτρέπει να ενσωματώσετε άλλους τύπους αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε αρχεία HTML, PDF και ZIP ως αντικείμενα. Όταν ένας χρήστης κάνει διπλό κλικ στο εισαχθέν αντικείμενο, αυτό ανοίγει αυτόματα στο σχετικό πρόγραμμα, ή ο χρήστης καλείται να επιλέξει το κατάλληλο πρόγραμμα για το άνοιγμά του.

Αυτός ο κώδικας Python σας δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

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

## **Ορισμός Τύπων Αρχείων για Ενσωματωμένα Αντικείμενα**

Κατά τη δουλειά με παρουσιάσεις, ίσως χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με καινούρια ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for Python via Java σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντάς σας να ενημερώσετε τα δεδομένα του πλαισίου OLE ή την επέκτασή του.

Αυτός ο κώδικας Python σας δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE σε `zip`:

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

## **Ορισμός Εικόνων Εικονιδίου και Τίτλων για Ενσωματωμένα Αντικείμενα**

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από μια εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι αυτό που βλέπουν οι χρήστες πριν προσπελάσουν ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides for Python via Java.

Αυτός ο κώδικας Python σας δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο:

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

## **Αποτροπή Αλλαγής Μεγέθους και Θέσης Πλαισίου Αντικειμένου OLE**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίγετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί ένα μήνυμα που σας ζητά να ενημερώσετε τις συνδέσεις. Κάνοντας κλικ στο κουμπί «Update Links» (Ενημέρωση Συνδέσεων) μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση του αντικειμένου. Για να αποτρέψετε το PowerPoint από την προτροπή ενημέρωσης των δεδομένων του αντικειμένου, καλέστε τη μέθοδο [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) της κλάσης [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) με τιμή `False`:

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

## **Εξαγωγή Ενσωματωμένων Αρχείων**

Το Aspose.Slides for Python via Java σας επιτρέπει να εξάγετε τα αρχεία που είναι ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE με τον ακόλουθο τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) που περιέχει τα αντικείμενα OLE που σκοπεύετε να εξάγετε.
2. Διέλθετε όλα τα σχήματα στην παρουσία και προσπελάστε τα σχήματα [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/).
3. Προσπελάστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένου OLE και γράψτε τα στον δίσκο.

Αυτός ο κώδικας Python σας δείχνει πώς να εξαχθούν τα αρχεία που είναι ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

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

## **Συχνές Ερωτήσεις**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται—το εικονίδιο/εικόνα υποκατάστασης (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Εάν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης για να διασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF. Για να διατηρήσετε επίσης το ενσωματωμένο αρχείο ως συνημμένο PDF, κλήστε τη [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) με `True`. Αυτή η επιλογή είναι απενεργοποιημένη εξ ορισμού. Για παράδειγμα και οδηγίες ελέγχου του συνημμένου, δείτε [Preserve Embedded OLE Files as PDF Attachments](/slides/el/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει [shape-level locks](/slides/el/python-java/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες επεμβάσεις και μετακινήσεις.

**Γιατί ένα συνδεδεμένο αντικείμενο Excel «πηδά» ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;**

Το PowerPoint μπορεί να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/python-java/working-solution-for-worksheet-resizing/)—είτε προσαρμόστε το πλαίσιο στο εύρος, είτε κλιμακώστε το εύρος σε σταθερό πλαίσιο και ορίστε μια κατάλληλη εικόνα υποκατάστασης.

**Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, οι πληροφορίες «σχετικής διαδρομής» δεν είναι διαθέσιμες—υπάρχει μόνο η πλήρης διαδρομή. Οι σχετικές διαδρομές υπάρχουν στη παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/προσβάσιμα URIs ή ενσωμάτωση.