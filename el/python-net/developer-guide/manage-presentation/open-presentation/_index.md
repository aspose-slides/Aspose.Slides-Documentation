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
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε Python, να παρέχετε κωδικούς πρόσβασης ανοίγματος και να μειώσετε τη χρήση μνήμης με το Aspose.Slides για Python via .NET."
---
## **Εισαγωγή**

[ Aspose.Slides for Python via .NET](https://products.aspose.com/slides/el/python-net/) μπορεί να φορτώνει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Αφού φορτωθεί μια παρουσίαση, μπορείτε να εξετάσετε τη δομή της, να επεξεργαστείτε διαφάνειες, να διαχειριστείτε πόρους και να την αποθηκεύσετε στην αρχική ή σε άλλη υποστηριζόμενη μορφή.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να παρέχετε έναν κωδικό πρόσβασης ανοίγματος, να διατηρείτε μεγάλα δυαδικά αντικείμενα εκτός μνήμης ή να παραλείψετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα Παρουσιάσεων**

Μετά τη φόρτωση ενός αρχείου ή ροής, μπορείτε να [προσδιορίσετε την αρχική μορφή της παρουσίασης](/slides/el/python-net/detect-presentation-source-format/) για να επιλέξετε πώς η εφαρμογή σας τη επεξεργάζεται.

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Χρησιμοποιήστε μια δήλωση `with` ώστε οι χειριστές αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι να απελευθερώνονται άμεσα.

Το παρακάτω παράδειγμα Python δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών:

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

Για διαδικασίες ανίχνευσης, επαλήθευσης και κρυπτογράφησης κωδικού πρόσβασης, δείτε το [Προστασία Παρουσιάσεων με Κωδικό](/slides/el/python-net/password-protected-presentation/). Εάν μια κρυπτογραφημένη παρουσίαση αποθηκεύτηκε σκόπιμα με δημόσιες ιδιότητες εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό πρόσβασης· δείτε το [Διαχείριση Ιδιοτήτων Παρουσίασης](/slides/el/python-net/presentation-properties/).

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

Η ιδιότητα [LoadOptions.blob_management_options](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/blob_management_options/) ελέγχει τον τρόπο με τον οποίο το Aspose.Slides διαχειρίζεται μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχο και βίντεο. Μπορείτε να διατηρήσετε το αρχικό αρχείο κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε την ποσότητα των δεδομένων BLOB που διατηρούνται στη μνήμη.

Αυτός ο κώδικας Python δείχνει τη φόρτωση μιας μεγάλης παρουσίασης (π.χ., 2 GB):

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

{{% alert color="info" title="Note" %}}
Με το `PresentationLockingBehavior.KEEP_LOCKED`, το αρχικό αρχείο παραμένει κλειδωμένο μέχρι να απορριφθεί το αντικείμενο `Presentation`. Μην μετακινήσετε, αντικαταστήσετε ή διαγράψετε το αρχικό αρχείο ενώ αυτό το αντικείμενο είναι σε λειτουργία.

Το Aspose.Slides μπορεί να αντιγράψει το περιεχόμενο μιας ροής εισόδου κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, η διαδρομή αρχείου είναι συνήθως πιο αποδοτική από τη ροή. Δείτε το [Διαχείριση BLOBs](/slides/el/python-net/manage-blob/) για επιπλέον επιλογές αποθήκευσης και διαχείρισης μνήμης.
{{% /alert %}}

## **Φόρτωση Παρουσιάσεων χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση μπορεί να περιέχει ενσωματωμένα δυαδικά δεδομένα που μια εφαρμογή δεν χρειάζεται ή δεν θέλει να διατηρήσει. Παραδείγματα περιλαμβάνουν:

- Προγραμματιστικά έργα VBA, διαθέσιμα μέσω [Presentation.vba_project](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/vba_project/);
- ενσωματωμένα δεδομένα OLE, διαθέσιμα μέσω [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/el/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω [Control.active_x_control_binary](https://reference.aspose.com/slides/el/python-net/aspose.slides/control/active_x_control_binary/).

Ορίστε το [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) σε `True` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε τη φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα φορτία, αλλά δεν αποτελεί πλήρη σύστημα ανίχνευσης κακόβουλων λογισμικών ή καθαρισμού περιεχομένου.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διακρίνω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχθεί;**

Το Aspose.Slides εγείρει εξαίρεση ανάλυσης ή μορφής κατά τη φόρτωση. Διαχειριστείτε αυτή την αποτυχία ξεχωριστά από σφάλμα λανθασμένου κωδικού πρόσβασης ώστε η εφαρμογή να μπορεί να αναφέρει την αιτία με ακρίβεια.

**Τι συμβαίνει αν λείπουν οι απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί ακόμη να φορτωθεί, αλλά η απόδοση και η εξαγωγή ενδέχεται να αντικαταστήσουν τις γραμματοσειρές. Μπορείτε να [διαμορφώσετε την αντικατάσταση γραμματοσειρών](/slides/el/python-net/font-substitution/) ή να [παρέχετε προσαρμοσμένες γραμματοσειρές](/slides/el/python-net/custom-font/) για να κάνετε το αποτέλεσμα πιο προβλέψιμο.

**Φορτώνει η φόρτωση μιας παρουσίασης επίσης τα ενσωματωμένα μέσα της;**

Τα ενσωματωμένα ήχοι και βίντεο γίνονται διαθέσιμα μέσω του μοντέλου αντικειμένων της παρουσίασης. Οι εξωτερικοί πόροι επιλύονται σύμφωνα με την προεπιλεγμένη συμπεριφορά φόρτωσης πόρων και ενδέχεται να μην είναι διαθέσιμοι εάν δεν είναι προσβάσιμες οι τοποθεσίες τους.