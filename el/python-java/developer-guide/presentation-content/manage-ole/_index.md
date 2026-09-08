---
title: Διαχείριση OLE σε Παρουσιάσεις με χρήση Python
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/python-java/manage-ole/
keywords:
- Αντικείμενο OLE
- Σύνδεση & Ενσωμάτωση Αντικειμένων
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
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE σε αρχεία PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω Java. Ενσωματώνετε, ενημερώνετε και εξάγετε το περιεχόμενο OLE απρόσκοπτα."
---
## **Εισαγωγή**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) είναι μια τεχνολογία της Microsoft που επιτρέπει τα δεδομένα και τα αντικείμενα που δημιουργούνται σε μία εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης.

{{% /alert %}}

Σκεφτείτε ένα γράφημα που δημιουργήθηκε στο MS Excel. Το γράφημα τοποθετείται στη συνέχεια μέσα σε διαφάνεια PowerPoint. Αυτό το γράφημα Excel θεωρείται αντικείμενο OLE.

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτή την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το γράφημα ανοίγει στην σχετική του εφαρμογή (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου.
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα δεδομένα ενός γραφήματος. Σε αυτήν την περίπτωση, το γράφημα ενεργοποιείται στο PowerPoint, φορτώνει η διεπαφή του γραφήματος, και μπορείτε να τροποποιήσετε τα δεδομένα του γραφήματος μέσα στο PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/el/python-java/) σας επιτρέπει να εισάγετε OLE Objects στις διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/)).

## **Προσθήκη πλαισίων αντικειμένων OLE στις διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα γράφημα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for Python via Java, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) class.
1. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Διαβάστε το αρχείο Excel ως πίνακα byte.
1. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) στη διαφάνεια που περιέχει τον πίνακα byte και άλλες πληροφορίες σχετικά με το αντικείμενο OLE.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα γράφημα από αρχείο Excel σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for Python via Java. **Σημείωση** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleembeddeddatainfo/) δέχεται μια επέκταση ενσωματωμένου αντικειμένου ως δεύτερη παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύει σωστά τον τύπο αρχείου και να επιλέγει τη σωστή εφαρμογή για το άνοιγμα αυτού του αντικειμένου OLE.

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

    # Προετοιμασία δεδομένων για το αντικείμενο OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Προσθήκη του πλαισίου αντικειμένου OLE στη διαφάνεια.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Προσθήκη συνδεδεμένων πλαισίων αντικειμένων OLE**

Το Aspose.Slides for Python via Java σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) χωρίς ενσωμάτωση δεδομένων, αλλά μόνο με σύνδεσμο στο αρχείο.

Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) με ένα συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpipe.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη πλαισίου αντικειμένου OLE με συνδεδεμένο αρχείο Excel.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε πλαίσια αντικειμένων OLE**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να έχετε πρόσβαση σε αυτό ως εξής:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) class.
2. Αποκτήστε την αναφορά της διαφάνειας χρησιμοποιώντας το δείκτη της.
3. Πρόσβαση στο σχήμα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/).
   Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια ελέγξαμε ότι το αντικείμενο ήταν ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις αποκτηθεί πρόσβαση στο πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε ενέργεια πάνω σε αυτό.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο γραφήματος Excel ενσωματωμένο σε μια διαφάνεια) και τα δεδομένα του αρχείου του προσεγγίζονται.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Ανάκτηση των ενσωματωμένων δεδομένων αρχείου.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Ανάκτηση της επέκτασης του ενσωματωμένου αρχείου.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Πρόσβαση σε ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE**

Το Aspose.Slides σάς επιτρέπει να αποκτήσετε πρόσβαση σε ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE.

Αυτός ο κώδικας Python σας δείχνει πώς να ελέγξετε αν ένα αντικείμενο OLE είναι συνδεδεμένο και έπειτα να λάβετε τη διαδρομή του συνδεδεμένου αρχείου:

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

        # Έλεγχος εάν το αντικείμενο OLE είναι συνδεδεμένο.
        if ole_frame.isObjectLink():
            # Εκτύπωση της πλήρους διαδρομής του συνδεδεμένου αρχείου.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Εκτύπωση της σχετικής διαδρομής του συνδεδεμένου αρχείου εάν υπάρχει.
            # Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν τη σχετική διαδρομή.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Αλλαγή δεδομένων αντικειμένου OLE**

{{% alert color="info" title="Note" %}}

Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να έχετε πρόσβαση σε αυτό το αντικείμενο και να τροποποιήσετε τα δεδομένα του ως εξής:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) class.
2. Αποκτήστε την αναφορά της διαφάνειας μέσω του δείκτη της.
3. Πρόσβαση στο σχήμα πλαισίου αντικειμένου OLE.
   Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια ελέγξαμε ότι το αντικείμενο ήταν ένα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις αποκτηθεί πρόσβαση στο πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε ενέργεια πάνω σε αυτό.
5. Δημιουργήστε ένα αντικείμενο [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) και αποκτήστε πρόσβαση στα δεδομένα OLE.
6. Αποκτήστε πρόσβαση στο επιθυμητό [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) και τροποποιήστε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) σε ροή.
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο γραφήματος Excel ενσωματωμένο σε μια διαφάνεια) προσεγγίζεται και τα δεδομένα του αρχείου του τροποποιούνται για την ενημέρωση των δεδομένων του γραφήματος.

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

## **Ενσωμάτωση άλλων τύπων αρχείων στις διαφάνειες**

Εκτός από γραφήματα Excel, το Aspose.Slides for Python via Java σας επιτρέπει να ενσωματώσετε άλλους τύπους αρχείων στις διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε αρχεία HTML, PDF και ZIP ως αντικείμενα. Όταν ένας χρήστης κάνει διπλό κλικ στο εισαχθέν αντικείμενο, ανοίγει αυτόματα στο σχετικό πρόγραμμα ή του ζητείται να επιλέξει ένα κατάλληλο πρόγραμμα για το άνοιγμά του.

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

## **Ορισμός τύπων αρχείων για ενσωματωμένα αντικείμενα**

Κατά τη δουλειά με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for Python via Java σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντάς σας να ενημερώσετε τα δεδομένα του πλαισίου OLE ή την επέκτασή του.

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

    # Αλλαγή του τύπου αρχείου σε ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός εικόνων εικονιδίων και τίτλων για ενσωματωμένα αντικείμενα**

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι ό,τι βλέπουν οι χρήστες πριν αποκτήσουν πρόσβαση ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides for Python via Java.

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

    # Προσθήκη εικόνας στους πόρους της παρουσίασης.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Ορισμός τίτλου και εικόνας για την προεπισκόπηση OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αποτροπή αλλαγής μεγέθους και επανατοποθέτησης πλαισίου αντικειμένου OLE**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίγετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί ένα μήνυμα που σας ζητά να ενημερώσετε τους συνδέσμους. Κάνοντας κλικ στο κουμπί «Update Links» ενδέχεται να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση του αντικειμένου. Για να αποτρέψετε το PowerPoint από το να ζητά ενημέρωση των δεδομένων του αντικειμένου, ορίστε τη μέθοδο [setUpdateAutomatic](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) της κλάσης [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/) σε `False`:

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

Το Aspose.Slides for Python via Java σας επιτρέπει να εξάγετε τα αρχεία που έχουν ενσωματωθεί σε διαφάνειες ως αντικείμενα OLE ως εξής:

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που περιέχει τα αντικείμενα OLE που σκοπεύετε να εξάγετε.
2. Διατρέξτε όλα τα σχήματα στην παρουσίαση και αποκτήστε πρόσβαση στα σχήματα [OleObjectFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleobjectframe/).
3. Αποκτήστε πρόσβαση στα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένων OLE και γράψτε τα στο δίσκο.

Αυτός ο κώδικας Python σας δείχνει πώς να εξάγετε αρχεία ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

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

## **Συχνές ερωτήσεις**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται—το εικονίδιο/αντικαταστάτη εικόνα (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Εάν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης για να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει [shape-level locks](/slides/el/python-java/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες επεμβάσεις και μετακινήσεις.

**Γιατί ένα συνδεδεμένο αντικείμενο Excel «πηδά» ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;**

Το PowerPoint μπορεί να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/python-java/working-solution-for-worksheet-resizing/)—είτε προσαρμόστε το πλαίσιο στην περιοχή, είτε κλιμακώστε την περιοχή σε σταθερό πλαίσιο και ορίστε μια κατάλληλη εναλλακτική εικόνα.

**Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, οι πληροφορίες «σχετικής διαδρομής» δεν είναι διαθέσιμες—υπάρχει μόνο η πλήρης διαδρομή. Σχετικές διαδρομές βρίσκονται μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/προσβάσιμα URI ή ενσωμάτωση.