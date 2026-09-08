---
title: Διαχείριση BLOB παρουσίασης σε Python μέσω Java για αποτελεσματική χρήση μνήμης
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
description: "Διαχειριστείτε τα δεδομένα BLOB στο Aspose.Slides για Python μέσω Java προκειμένου να βελτιώσετε τις λειτουργίες αρχείων PowerPoint και OpenDocument για αποτελεσματική διαχείριση παρουσιάσεων."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει διαχείριση βασισμένη σε BLOB για μεγάλα δυαδικά δεδομένα στις παρουσιάσεις, ώστε να μειώνεται η κατανάλωση μνήμης κατά την εργασία με μεγάλες εικόνες, ήχο, βίντεο και αρχεία παρουσιάσεων.

Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε την επεξεργασία με BLOB για να προσθέσετε μεγάλα πολυμέσα σε μια παρουσίαση, να εξάγετε μεγάλα πολυμέσα από μια παρουσίαση και να φορτώσετε μεγάλες παρουσιάσεις πιο αποδοτικά. Εξηγεί επίσης πώς μπορούν να χρησιμοποιηθούν προσωρινά αρχεία κατά τη διάρκεια της επεξεργασίας και πώς να αλλάξετε το φάκελο όπου αποθηκεύονται.

## **Σχετικά με το BLOB**

**BLOB** (**Binary Large Object**) είναι συνήθως ένα μεγάλο αντικείμενο (φωτογραφία, παρουσίαση, έγγραφο ή μέσον) αποθηκευμένο σε δυαδικές μορφές.

Το Aspose.Slides for Python via Java σας επιτρέπει να χρησιμοποιήσετε BLOBs για αντικείμενα με τρόπο που μειώνει την κατανάλωση μνήμης όταν εμπλέκονται μεγάλα αρχεία.

{{% alert color="info" title="Σημείωση" %}}
Για να παρακάμψετε ορισμένους περιορισμούς κατά την αλληλεπίδραση με ροές, το Aspose.Slides μπορεί να αντιγράψει το περιεχόμενο της ροής. Η φόρτωση μιας μεγάλης παρουσίασης μέσω της ροής της θα έχει ως αποτέλεσμα την αντιγραφή του περιεχομένου της παρουσίασης και θα προκαλέσει αργή φόρτωση. Επομένως, όταν σκοπεύετε να φορτώσετε μια μεγάλη παρουσίαση, συνιστούμε έντονα να χρησιμοποιήσετε τη διαδρομή του αρχείου παρουσίασης και όχι τη ροή της.
{{% /alert %}}

## **Χρήση του BLOB για Μείωση Κατανάλωσης Μνήμης**

### **Προσθήκη Μεγάλου Αρχείου μέσω BLOB σε Παρουσίαση**

[Aspose.Slides](/slides/el/python-java/) for Python via Java σας επιτρέπει να προσθέσετε μεγάλα αρχεία (σε αυτή την περίπτωση, ένα μεγάλο αρχείο βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs για να μειώσετε την κατανάλωση μνήμης.

Αυτός ο κώδικας Python δείχνει πώς να προσθέσετε ένα μεγάλο αρχείο βίντεο μέσω της διαδικασίας BLOB σε μια παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Δημιουργήστε μια νέα παρουσίαση στην οποία θα προστεθεί το βίντεο.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Κρατήστε τη ροή κλειδωμένη επειδή δεν προτιθέμεθα να προσπελάσουμε το αρχείο βίντεο.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Αποθηκεύστε την παρουσίαση ενώ διατηρείτε τη χρήση μνήμης χαμηλή.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Εξαγωγή Μεγάλου Αρχείου μέσω BLOB από Παρουσίαση**

Το Aspose.Slides for Python via Java σας επιτρέπει να εξάγετε μεγάλα αρχεία (σε αυτή την περίπτωση, ένα αρχείο ήχου ή βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστεί να εξάγετε ένα μεγάλο αρχείο πολυμέσων από μια παρουσίαση χωρίς το αρχείο να φορτώνεται στη μνήμη του υπολογιστή σας. Εξάγοντας το αρχείο μέσω της διαδικασίας BLOB, διατηρείτε τη χρήση μνήμης χαμηλή.

Αυτός ο κώδικας σε Python demonstre τη λειτουργία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Κλειδώστε το αρχείο πηγής αντί να το φορτώσετε στη μνήμη.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Μεταφέρετε τα δεδομένα βίντεο μέσω ενός buffer για να διατηρήσετε τη χρήση μνήμης χαμηλή.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Χρησιμοποιήστε τη ροή αντί να φορτώσετε ολόκληρο το βίντεο σε έναν πίνακα bytes.
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
    # Αν είναι απαραίτητο, εφαρμόστε τα ίδια βήματα στα αρχεία ήχου.
finally:
    presentation.dispose()
```

### **Προσθήκη Εικόνας ως BLOB σε Παρουσίαση**

Με τις μεθόδους από την κλάση [ImageCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagecollection/) μπορείτε να προσθέσετε μια μεγάλη εικόνα ως ροή ώστε να αντιμετωπιστεί ως BLOB.

Αυτός ο κώδικας Python δείχνει πώς να προσθέσετε μια μεγάλη εικόνα μέσω της διαδικασίας BLOB:

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
        # Κρατήστε τη ροή κλειδωμένη επειδή δεν προτίθεσθε να προσπελάσετε το αρχείο εικόνας.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Αποθηκεύστε την παρουσίαση διατηρώντας τη χρήση μνήμης χαμηλή.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Μνήμη και Μεγάλες Παρουσιάσεις**

Κανονικά, για τη φόρτωση μιας μεγάλης παρουσίασης, οι υπολογιστές απαιτούν πολύ προσωρινή μνήμη. Όλο το περιεχόμενο της παρουσίασης φορτώνεται στη μνήμη και το αρχείο (από το οποίο φορτώθηκε η παρουσίαση) σταματά να χρησιμοποιείται.

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

### **Φόρτωση Μεγάλης Παρουσίασης ως BLOB**

Μέσω της διαδικασίας που περιλαμβάνει BLOB, μπορείτε να φορτώσετε μια μεγάλη παρουσίαση χρησιμοποιώντας πολύ λίγη μνήμη. Αυτός ο κώδικας Python περιγράφει την υλοποίηση όπου η διαδικασία BLOB χρησιμοποιείται για τη φόρτωση ενός μεγάλου αρχείου παρουσίασης (large.pptx):

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

### **Αλλαγή Φακέλου για Προσωρινά Αρχεία**

Όταν χρησιμοποιείται η διαδικασία BLOB, ο υπολογιστής σας δημιουργεί προσωρινά αρχεία στον προεπιλεγμένο φάκελο προσωρινών αρχείων. Εάν θέλετε τα προσωρινά αρχεία να αποθηκεύονται σε διαφορετικό φάκελο, μπορείτε να αλλάξετε τις ρυθμίσεις αποθήκευσης χρησιμοποιώντας [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

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
Όταν χρησιμοποιείτε [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), το Aspose.Slides δεν δημιουργεί αυτόματα φάκελο για την αποθήκευση των προσωρινών αρχείων. Πρέπει να δημιουργήσετε το φάκελο χειροκίνητα.
{{% /alert %}}

### **Καθαρισμός Αντικειμένων Παρουσίασης για Απελευθέρωση Μνήμης**

Κατά την επεξεργασία μεγάλων παρουσιάσεων, βεβαιωθείτε ότι η παρουσίαση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) διαχειρίζεται σωστά τη διακοπή της ώστε η μνήμη που κατείχε να απελευθερωθεί. Καλέστε [Presentation.dispose](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#dispose) μετά την ολοκλήρωση της χρήσης της παρουσίασης για να απελευθερώσετε μη διαχειριζόμενους πόρους.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...επεξεργασία της παρουσίασης...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Απελευθερώστε ρητά τους πόρους.
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Ποια δεδομένα σε μια παρουσίαση Aspose.Slides αντιμετωπίζονται ως BLOB και ελέγχονται από τις επιλογές BLOB;**

Μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχος και βίντεο αντιμετωπίζονται ως BLOB. Ολόκληρο το αρχείο παρουσίασης επίσης εμπλέκεται σε διαχείριση BLOB όταν φορτώνεται ή αποθηκεύεται. Αυτά τα αντικείμενα διέπονται από πολιτικές BLOB που σας επιτρέπουν να διαχειρίζεστε τη χρήση μνήμης και την αποθήκευση σε προσωρινά αρχεία όταν χρειάζεται.

**Πού ρυθμίζω τους κανόνες διαχείρισης BLOB κατά τη φόρτωση της παρουσίασης;**

Χρησιμοποιήστε το [LoadOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/) μαζί με το [BlobManagementOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/blobmanagementoptions/). Εκεί ορίζετε το όριο μνήμης για BLOB, επιτρέπετε ή αποτρέπετε προσωρινά αρχεία, επιλέγετε τη ρίζα διαδρομή για τα προσωρινά αρχεία και καθορίζετε τη συμπεριφορά κλειδώματος της πηγής.

**Επηρεάζουν οι ρυθμίσεις BLOB την απόδοση, και πώς ισορροπώ ταχύτητα vs μνήμη;**

Ναι. Η διατήρηση των BLOB στη μνήμη μεγιστοποιεί την ταχύτητα αλλά αυξάνει την κατανάλωση RAM· η μείωση του ορίου μνήμης μεταφέρει περισσότερη εργασία σε προσωρινά αρχεία, μειώνοντας τη RAM με κόστος πρόσθετης I/O. Χρησιμοποιήστε τη μέθοδο [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/el/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) για να βρείτε τη σωστή ισορροπία για το φορτίο εργασίας και το περιβάλλον σας.

**Βοηθούν οι επιλογές BLOB κατά το άνοιγμα εξαιρετικά μεγάλων παρουσιάσεων (π.χ., σεγεμμέτρια gigabytes);**

Ναι. Τα [BlobManagementOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/blobmanagementoptions/) σχεδιάζονται για τέτοια σενάρια: η ενεργοποίηση προσωρινών αρχείων και η χρήση κλειδώματος πηγής μπορούν να μειώσουν σημαντικά τη μέγιστη χρήση RAM και να σταθεροποιήσουν την επεξεργασία πολύ μεγάλων διαφανειών.

**Μπορώ να χρησιμοποιήσω πολιτικές BLOB όταν φορτώνω από ροές αντί για αρχεία δίσκου;**

Ναι. Οι ίδιες κανόνες ισχύουν για ροές: η παρουσίαση μπορεί να κατέχει και να κλειδώνει τη ροή εισόδου (ανάλογα με την επιλεγμένη λειτουργία κλειδώματος), και τα προσωρινά αρχεία χρησιμοποιούνται όταν επιτρέπεται, διατηρώντας τη χρήση μνήμης προβλέψιμη κατά την επεξεργασία.