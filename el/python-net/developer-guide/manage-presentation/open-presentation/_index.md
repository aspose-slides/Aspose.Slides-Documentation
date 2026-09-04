---
title: Άνοιγμα Παρουσιάσεων σε Python
linktitle: Άνοιγμα Παρουσιάσεων
type: docs
weight: 20
url: /el/python-net/open-presentation/
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
- Aspose.Slides
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε Python, να παρέχετε κωδικούς πρόσβασης ανοίγματος και να μειώσετε τη χρήση μνήμης με το Aspose.Slides για Python μέσω .NET."
---
## **Εισαγωγή**

[Aspose.Slides για Python μέσω .NET](https://products.aspose.com/slides/el/python-net/) μπορεί να φορτώσει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Αφού φορτωθεί μια παρουσίαση, μπορείτε να εξετάσετε τη δομή της, να επεξεργαστείτε διαφάνειες, να διαχειριστείτε πόρους και να την αποθηκεύσετε στην αρχική ή σε άλλη υποστηριζόμενη μορφή.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να παρέχετε κωδικό πρόσβασης ανοίγματος, να διατηρήσετε μεγάλα δυαδικά αντικείμενα εκτός μνήμης ή να παραλείψετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα Παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/)`. Χρησιμοποιήστε μια δήλωση `with` ώστε τα χειριστήρια αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι να απελευθερώνονται αμέσως.

Το παρακάτω παράδειγμα Python δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών της:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Άνοιγμα Παρουσιάσεων με Κωδικό Πρόσβασης**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε ολόκληρη την παρουσίαση, ορίστε τον σωστό κωδικό στην ιδιότητα [LoadOptions.password](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/password/) και περάστε τις επιλογές στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Η φόρτωση αποτυγχάνει όταν ο κωδικός λείπει ή είναι λανθασμένος.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Για ανίχνευση κωδικών, επικύρωση και ροές εργασίας κρυπτογράφησης, δείτε [Password-Protect Presentations](/slides/el/python-net/password-protected-presentation/). Εάν μια κρυπτογραφημένη παρουσίαση αποθηκεύτηκε εκ προθέσεως με δημόσια ιδιότητα εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό· δείτε [Manage Presentation Properties](/slides/el/python-net/presentation-properties/).

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/blob_management_options/) ελέγχει πώς το Aspose.Slides διαχειρίζεται μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχο και βίντεο. Μπορείτε να διατηρήσετε το αρχείο προέλευσης κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε την ποσότητα δεδομένων BLOB που διατηρούνται στη μνήμη.

Αυτός ο κώδικας Python δείχνει τη φόρτωση μιας μεγάλης παρουσίασης (π.χ. 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Σημείωση" %}}

Με την τιμή `PresentationLockingBehavior.KEEP_LOCKED`, το αρχείο προέλευσης παραμένει κλειδωμένο μέχρι το αντικείμενο `Presentation` να απελευθερωθεί. Μην μετακινείτε, αντικαθιστάτε ή διαγράφετε το αρχείο προέλευσης ενώ το αντικείμενο είναι ενεργό.

Το Aspose.Slides ενδέχεται να αντιγράψει τα περιεχόμενα μιας ροής εισόδου κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, μια διαδρομή αρχείου είναι γενικά πιο αποδοτική από μια ροή. Δείτε το [Manage BLOBs](/slides/el/python-net/manage-blob/) για πρόσθετες επιλογές αποθήκευσης και διαχείρισης μνήμης.

{{% /alert %}}

## **Φόρτωση Παρουσιάσεων χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση μπορεί να περιέχει ενσωματωμένα δυαδικά δεδομένα που μια εφαρμογή δεν χρειάζεται ή δεν θέλει να διατηρήσει. Παραδείγματα περιλαμβάνουν:

- έργα VBA, διαθέσιμα μέσω [Presentation.vba_project](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/vba_project/);
- ενσωματωμένα δεδομένα OLE, διαθέσιμα μέσω [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/el/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω [Control.active_x_control_binary](https://reference.aspose.com/slides/el/python-net/aspose.slides/control/active_x_control_binary/).

Ορίστε [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) σε `True` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα φορτία, αλλά δεν αποτελεί πλήρες σύστημα ανίχνευσης κακόβουλου λογισμικού ή καθαρισμού περιεχομένου.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διαπιστώ ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχθεί;**

Το Aspose.Slides εγείρει εξαίρεση παρα/parsing ή μορφοποίησης κατά τη φόρτωση. Διαχειριστείτε αυτήν την αποτυχία ξεχωριστά από σφάλμα λανθασμένου κωδικού πρόσβασης ώστε η εφαρμογή να μπορεί να αναφέρει ακριβώς το αίτιο.

**Τι συμβαίνει αν λείπουν απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί ακόμα να φορτωθεί, αλλά η απόδοση και η εξαγωγή μπορεί να αντικαταστήσουν τις γραμματοσειρές. Μπορείτε να [configure font substitution](/slides/el/python-net/font-substitution/) ή να [provide custom fonts](/slides/el/python-net/custom-font/) για να κάνετε το αποτέλεσμα πιο προβλέψιμο.

**Φορτώνει η παρουσίαση επίσης τα ενσωματωμένα μέσα της;**

Τα ενσωματωμένα ηχητικά και βίντεο γίνονται διαθέσιμα μέσω του μοντέλου αντικειμένων παρουσίασης. Οι εξωτερικοί πόροι επιλύονται σύμφωνα με τη προεπιλεγμένη συμπεριφορά φόρτωσης πόρων και μπορεί να μην είναι διαθέσιμοι εάν δεν είναι προσπελάσιμοι οι προορισμοί τους.