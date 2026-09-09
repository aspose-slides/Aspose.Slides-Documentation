---
title: Διαχειριστείτε τα BLOB Παρουσίασης σε Python μέσω Java για Αποδοτική Χρήση Μνήμης
linktitle: Διαχείριση BLOB
type: docs
weight: 10
url: /el/python-java/manage-blob/
keywords:
- μεγάλο αντικείμενο
- μεγάλο στοιχείο
- μεγάλο αρχείο
- προσθήκη BLOB
- εξαγωγή BLOB
- προσθήκη εικόνας ως BLOB
- μείωση μνήμης
- κατανάλωση μνήμης
- μεγάλη παρουσίαση
- προσωρινό αρχείο
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα δεδομένα BLOB στο Aspose.Slides για Python μέσω Java για να βελτιστοποιήσετε τις λειτουργίες αρχείων PowerPoint και OpenDocument για αποδοτικό χειρισμό παρουσιάσεων."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει επεξεργασία βάσει BLOB για μεγάλα δυαδικά δεδομένα σε παρουσιάσεις, ώστε να μειώνεται η κατανάλωση μνήμης όταν εργάζεστε με μεγάλες εικόνες, ήχους, βίντεο και αρχεία παρουσιάσεων.

Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε επεξεργασία βάσει BLOB για να προσθέσετε μεγάλα μέσα σε μια παρουσίαση, να εξάγετε μεγάλα μέσα από μια παρουσίαση και να φορτώσετε μεγάλες παρουσιάσεις πιο αποδοτικά. Εξηγεί επίσης πώς μπορούν να χρησιμοποιηθούν προσωρινά αρχεία κατά την επεξεργασία και πώς να αλλάξετε το φάκελο που χρησιμοποιείται για την αποθήκευσή τους.

## **Σχετικά με BLOB**

Ένα **BLOB** (**Binary Large Object**, Δυαδικό Μεγάλο Αντικείμενο) είναι συνήθως ένα μεγάλο στοιχείο (φωτογραφία, παρουσίαση, έγγραφο ή μέσο) αποθηκευμένο σε δυαδικές μορφές.

Το Aspose.Slides for Python via Java σάς επιτρέπει να χρησιμοποιείτε BLOBs για αντικείμενα με τρόπο που μειώνει την κατανάλωση μνήμης όταν εμπλέκονται μεγάλα αρχεία.

{{% alert color="info" title="Σημείωση" %}}
Για να παρακάμψετε ορισμένους περιορισμούς κατά την αλληλεπίδραση με ροές, το Aspose.Slides ενδέχεται να αντιγράψει το περιεχόμενο της ροής. Η φόρτωση μιας μεγάλης παρουσίασης μέσω της ροής της θα προκαλέσει την αντιγραφή των περιεχομένων της παρουσίασης και θα επιφέρει αργή φόρτωση. Συνεπώς, όταν σκοπεύετε να φορτώσετε μια μεγάλη παρουσίαση, συνιστούμε ανεπιφύλακτα να χρησιμοποιήσετε τη διαδρομή του αρχείου παρουσίασης και όχι τη ροή της.
{{% /alert %}}

## **Χρήση BLOB για μείωση της κατανάλωσης μνήμης**

### **Προσθήκη μεγάλου αρχείου σε παρουσίαση χρησιμοποιώντας BLOBs**

[Aspose.Slides](/slides/el/python-java/) for Python via Java σάς επιτρέπει να προσθέσετε μεγάλα αρχεία (σε αυτήν την περίπτωση, ένα μεγάλο αρχείο βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs ώστε να μειώσετε την κατανάλωση μνήμης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Δημιουργήστε μία νέα παρουσίαση στην οποία θα προστεθεί το βίντεο.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Κρατήστε τη ροή κλειδωμένη επειδή δεν σκοπεύουμε να προσπελάσουμε το αρχείο βίντεο.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Αποθηκεύστε την παρουσίαση διατηρώντας τη κατανάλωση μνήμης χαμηλή.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Εξαγωγή μεγάλου αρχείου από παρουσίαση χρησιμοποιώντας BLOBs**

Το Aspose.Slides for Python via Java σάς επιτρέπει να εξάγετε μεγάλα αρχεία (σε αυτήν την περίπτωση, ένα αρχείο ήχου ή βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστεί να εξαγάγετε ένα μεγάλο αρχείο μέσου από μια παρουσίαση χωρίς να φορτωθεί στη μνήμη του υπολογιστή σας. Εξάγοντας το αρχείο μέσω της διαδικασίας BLOB, διατηρείτε τη χρήση μνήμης χαμηλή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Κλειδώστε το αρχείο προέλευσης αντί να το φορτώσετε στη μνήμη.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Μεταφέρετε τα δεδομένα βίντεο μέσω ενός buffer για να διατηρήσετε τη κατανάλωση μνήμης χαμηλή.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Χρησιμοποιήστε τη ροή αντί να φορτώσετε ολόκληρο το βίντεο σε ένα πίνακα byte.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # Εάν είναι απαραίτητο, εφαρμόστε τα ίδια βήματα στα αρχεία ήχου.
finally:
    presentation.dispose()
```

### **Προσθήκη εικόνας ως BLOB σε παρουσίαση**

Με τις μεθόδους της κλάσης [ImageCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagecollection/), μπορείτε να προσθέσετε μια μεγάλη εικόνα ως ροή ώστε να αντιμετωπίζεται ως BLOB.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Δημιουργήστε μια νέα παρουσίαση στην οποία θα προστεθεί η εικόνα.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Κρατήστε τη ροή κλειδωμένη επειδή δεν σκοπεύουμε να προσπελάσουμε το αρχείο εικόνας.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Αποθηκεύστε την παρουσίαση διατηρώντας τη χρήση μνήμης χαμηλή.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Μνήμη και μεγάλες παρουσιάσεις**

Κατά κανόνα, για τη φόρτωση μιας μεγάλης παρουσίασης, οι υπολογιστές απαιτούν πολύ προσωρινή μνήμη. Όλο το περιεχόμενο της παρουσίασης φορτώνεται στη μνήμη και το αρχείο (από το οποίο φορτώθηκε η παρουσίαση) σταματά να χρησιμοποιείται.

Σκεφτείτε μια μεγάλη παρουσίαση PowerPoint (large.pptx) που περιέχει ένα αρχείο βίντεο 1,5 GB. Η τυπική μέθοδος φόρτωσης της παρουσίασης περιγράφεται σε αυτόν τον κώδικα Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Αλλά αυτή η μέθοδος καταναλώνει περίπου 1,6 GB προσωρινής μνήμης.

### **Φόρτωση μεγάλης παρουσίασης ως BLOB**

Με τη χρήση διαχείρισης BLOB, μπορείτε να φορτώσετε μια μεγάλη παρουσίαση χρησιμοποιώντας λίγη μνήμη. Αυτός ο κώδικας Python δείχνει πώς να χρησιμοποιήσετε τη διαχείριση BLOB για να φορτώσετε ένα μεγάλο αρχείο παρουσίασης (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Αλλαγή του φακέλου για προσωρινά αρχεία**

Κατά τη χρήση της διαδικασίας BLOB, ο υπολογιστής σας δημιουργεί προσωρινά αρχεία στο προεπιλεγμένο φάκελο προσωρινών αρχείων. Εάν θέλετε τα προσωρινά αρχεία να αποθηκεύονται σε διαφορετικό φάκελο, μπορείτε να αλλάξετε τις ρυθμίσεις αποθήκευσης χρησιμοποιώντας το [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Σημείωση" %}}
Όταν χρησιμοποιείτε το [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), το Aspose.Slides δεν δημιουργεί αυτόματα φάκελο για την αποθήκευση των προσωρινών αρχείων. Πρέπει να δημιουργήσετε το φάκελο με το χέρι.
{{% /alert %}}

### **Αποδέσμευση αντικειμένων Presentation για απελευθέρωση μνήμης**

Κατά την επεξεργασία μεγάλων παρουσιάσεων, βεβαιωθείτε ότι η παρουσίαση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) απελευθερώνεται σωστά ώστε η μνήμη που κατείχε να απελευθερωθεί. Καλέστε το [Presentation.dispose](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#dispose) αφού ολοκληρώσετε τη χρήση της παρουσίασης για να ελευθερώσετε μη διαχειριζόμενους πόρους.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ... επεξεργασία της παρουσίασης ...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Απελευθέρωση πόρων ρητά.
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Ποια δεδομένα σε μια παρουσίαση Aspose.Slides θεωρούνται BLOB και ελέγχονται από τις ρυθμίσεις BLOB;**

Μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχοι και βίντεο θεωρούνται BLOBs. Ολόκληρο το αρχείο παρουσίασης επίσης εμπλέκεται στη διαχείριση BLOB όταν φορτώνεται ή αποθηκεύεται. Αυτά τα αντικείμενα ελέγχονται από πολιτικές BLOB που σας επιτρέπουν να διαχειρίζεστε τη χρήση μνήμης και να αποθηκεύετε προσωρινά αρχεία όταν χρειάζεται.

**Που μπορώ να διαμορφώσω τους κανόνες διαχείρισης BLOB κατά τη φόρτωση της παρουσίασης;**

Χρησιμοποιήστε το [LoadOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/) μαζί με το [BlobManagementOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/blobmanagementoptions/). Εκεί ορίζετε το όριο μνήμης για BLOBs, επιτρέπετε ή απαγορεύετε τα προσωρινά αρχεία, επιλέγετε τη ρίζα διαδρομή για τα προσωρινά αρχεία και καθορίζετε τη συμπεριφορά κλειδώματος της πηγής.

**Επηρεάζουν οι ρυθμίσεις BLOB την απόδοση και πώς μπορώ να ισορροπήσω την ταχύτητα με τη μνήμη;**

Ναι. Η διατήρηση των BLOB στη μνήμη μεγιστοποιεί την ταχύτητα αλλά αυξάνει την κατανάλωση RAM· η μείωση του ορίου μνήμης μεταφέρει περισσότερη εργασία σε προσωρινά αρχεία, μειώνοντας τη RAM με κόστος πρόσθετων εισόδων/εξόδων. Χρησιμοποιήστε τη μέθοδο [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/el/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) για να βρείτε τη σωστή ισορροπία για το φορτίο εργασίας και το περιβάλλον σας.

**Βοηθούν οι ρυθμίσεις BLOB όταν ανοίγετε εξαιρετικά μεγάλες παρουσιάσεις (π.χ. σε γιγαμπάιτ);**

Ναι. Το [BlobManagementOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/blobmanagementoptions/) έχει σχεδιαστεί για τέτοια σενάρια: η ενεργοποίηση των προσωρινών αρχείων και η χρήση κλειδώματος πηγής μπορούν να μειώσουν σημαντικά τη μέγιστη χρήση RAM και να σταθεροποιήσουν την επεξεργασία πολύ μεγάλων παρουσιάσεων.

**Μπορώ να χρησιμοποιήσω πολιτικές BLOB όταν φορτώνω από ροές αντί για αρχεία δίσκου;**

Ναι. Οι ίδιοι κανόνες ισχύουν για τις ροές: η παρουσίαση μπορεί να κατέχει και να κλειδώνει την εισερχόμενη ροή (ανάλογα με το επιλεγμένο τρόπο κλειδώματος), και τα προσωρινά αρχεία χρησιμοποιούνται όταν επιτρέπεται, διατηρώντας την χρήση μνήμης προβλέψιμη κατά τη διάρκεια της επεξεργασίας.