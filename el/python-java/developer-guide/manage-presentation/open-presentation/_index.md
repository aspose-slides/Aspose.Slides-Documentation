---
title: Άνοιγμα Παρουσιάσεων σε Python μέσω Java
linktitle: Άνοιγμα Παρουσίασης
type: docs
weight: 20
url: /el/python-java/open-presentation/
keywords:
- άνοιγμα PowerPoint
- άνοιγμα παρουσίασης
- άνοιγμα PPTX
- άνοιγμα PPT
- άνοιγμα ODP
- φόρτωση παρουσίασης
- φόρτωση PPTX
- φόρτωση PPT
- φόρτωση ODP
- προστατευμένη παρουσίαση
- μεγάλη παρουσίαση
- εξωτερικός πόρος
- δυαδικό αντικείμενο
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε Python μέσω Java, να παρέχετε κωδικούς πρόσβασης ανοίγματος, να ελέγχετε τη φόρτωση πόρων και να μειώνετε την κατανάλωση μνήμης με το Aspose.Slides για Python μέσω Java."
---
## **Εισαγωγή**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/el/python-java/) μπορεί να φορτώνει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Αφού φορτωθεί μια παρουσίαση, μπορείτε να ελέγξετε τη δομή της, να επεξεργαστείτε τις διαφάνειες, να διαχειριστείτε πόρους και να την αποθηκεύσετε στην αρχική ή σε άλλη υποστηριζόμενη μορφή.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να παρέχετε κωδικό πρόσβασης ανοίγματος, να διατηρείτε μεγάλα δυαδικά αντικείμενα εκτός της μνήμης heap της Java, να ελέγχετε εξωτερικούς πόρους ή να παραλείψετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα Παρουσιάσεων**

Μετά τη φόρτωση ενός αρχείου ή ροής, μπορείτε να [προσδιορίσετε τη μορφή της αρχικής παρουσίασης](/slides/el/python-java/detect-presentation-source-format/) για να επιλέξετε πώς η εφαρμογή σας την επεξεργάζεται.

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/). Αποδεσμεύστε την παρουσίαση μετά τη χρήση ώστε οι χειριστές αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι να απελευθερωθούν άμεσα.

Το παρακάτω παράδειγμα Python δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών της:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Άνοιγμα Παρουσιάσεων με Προστασία Κωδικού**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε ολόκληρη την παρουσίαση, περάστε τον σωστό κωδικό στη μέθοδο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setPassword) και δώστε τις επιλογές στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/). Η φόρτωση αποτυγχάνει όταν ο κωδικός λείπει ή είναι λανθασμένος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

Για διαδικασίες ανίχνευσης, επικύρωσης και κρυπτογράφησης κωδικού πρόσβασης, δείτε το [Προστασία Παρουσιαστικών με Κωδικό](/slides/el/python-java/password-protected-presentation/). Εάν μια κρυπτογραφημένη παρουσίαση αποθηκεύθηκε σκόπιμα με δημόσια ιδιότητες εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό πρόσβασης· δείτε το [Διαχείριση Ιδιοτήτων Παρουσίασης](/slides/el/python-java/presentation-properties/).

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

Η μέθοδος [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) επιστρέφει επιλογές που ελέγχουν πώς το Aspose.Slides διαχειρίζεται μεγάλα δυαδικά αντικείμενα (BLOB) όπως εικόνες, ήχο και βίντεο. Μπορείτε να διατηρήσετε το αρχείο προέλευσης κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε το ποσό των δεδομένων BLOB που διατηρούνται στη μνήμη.

Το παρακάτω κώδικας Python δείχνει τη φόρτωση μιας μεγάλης παρουσίασης (π.χ., 2 GB):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Με το [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked), το αρχείο προέλευσης παραμένει κλειδωμένο μέχρι να αποδεσμευθεί η παρουσίαση. Μην μετακινήσετε, αντικαταστήσετε ή διαγράψετε το αρχείο προέλευσης όσο η παρουσίαση είναι ζωντανή.

Το Aspose.Slides μπορεί να αντιγράψει το περιεχόμενο μιας εισαγόμενης ροής κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, η διαδρομή αρχείου είναι γενικά πιο αποδοτική από μια ροή. Δείτε το [Διαχείριση BLOB](/slides/el/python-java/manage-blob/) για πρόσθετες επιλογές αποθήκευσης και διαχείρισης μνήμης.
{{% /alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

Η μέθοδος [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) δέχεται έναν διαμεσολαβητή JPype που υλοποιεί τη διεπαφή κλήσης επαναφόρτωσης πόρων της Java. Η κλήση μπορεί να παρέχει δεδομένα αντικατάστασης, να ανακατευθύνει έναν πόρο, να χρησιμοποιήσει τον προεπιλεγμένο φορτωτή ή να παραλείψει τον πόρο. Αυτό είναι χρήσιμο όταν οι παρουσιάσεις περιέχουν εξωτερικές εικόνες που πρέπει να επιλυθούν σύμφωνα με κανόνες ασφαλείας ή αποθήκευσης ειδικοί για την εφαρμογή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Φόρτωση Παρουσιάσεων χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση μπορεί να περιέχει ενσωματωμένα δυαδικά δεδομένα που μια εφαρμογή δεν χρειάζεται ή δεν θέλει να διατηρήσει. Παραδείγματα περιλαμβάνουν:

- VBA projects, διαθέσιμα μέσω [Presentation.getVbaProject](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getVbaProject);
- ενσωματωμένα OLE δεδομένα, διαθέσιμα μέσω [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/el/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω [Control.getActiveXControlBinary](https://reference.aspose.com/slides/el/python-java/aspose.slides/control/#getActiveXControlBinary).

Ορίστε την μέθοδο [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) σε `True` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα φορτία, αλλά δεν αποτελεί πλήρες σύστημα ανίχνευσης κακόβουλου λογισμικού ή καθαρισμού περιεχομένου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ΣΥΝΗΘΕΣΜΕΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να καταλάβω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχθεί;**

Το Aspose.Slides εγείρει εξαίρεση ανάλυσης ή μορφής κατά τη φόρτωση. Διαχειριστείτε αυτήν την αποτυχία ξεχωριστά από σφάλμα λανθασμένου κωδικού πρόσβασης, ώστε η εφαρμογή να μπορεί να αναφέρει ακριβώς την αιτία.

**Τι συμβαίνει αν λείπουν οι απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί ακόμα να φορτωθεί, αλλά η απόδοση και η εξαγωγή ενδέχεται να αντικαταστήσουν τις γραμματοσειρές. Μπορείτε να [ρυθμίσετε την αντικατάσταση γραμματοσειρών](/slides/el/python-java/font-substitution/) ή να [παρέχετε προσαρμοσμένες γραμματοσειρές](/slides/el/python-java/custom-font/) ώστε η έξοδος να είναι πιο προβλέψιμη.

**Φορτώνει η φόρτωση μιας παρουσίασης και τα ενσωματωμένα μέσα της;**

Τα ενσωματωμένα ήχο και βίντεο γίνονται διαθέσιμα μέσω του μοντέλου αντικειμένων της παρουσίασης. Οι εξωτερικοί πόροι επιλύονται σύμφωνα με τη ρυθμισμένη συμπεριφορά φόρτωσης πόρων και μπορεί να μην είναι διαθέσιμοι εάν δεν είναι προσβάσιμες οι τοποθεσίες τους.