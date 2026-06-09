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
description: "Ανοίξτε παρουσιάσεις PowerPoint (.pptx, .ppt) και OpenDocument (.odp) με άνεση χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET—γρήγορο, αξιόπιστο, πλήρως εξοπλισμένο."
---
## **Εισαγωγή**

Πέρα από τη δημιουργία παρουσιάσεων PowerPoint από το μηδέν, το Aspose.Slides σας επιτρέπει επίσης να ανοίξετε υπάρχουσες παρουσιάσεις. Αφού φορτώσετε μια παρουσίαση, μπορείτε να ανακτήσετε πληροφορίες για αυτήν, να επεξεργαστείτε το περιεχόμενο των διαφανειών, να προσθέσετε νέες διαφάνειες, να αφαιρέσετε υπάρχουσες και πολλά άλλα.

## **Άνοιγμα Παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και περάστε τη διαδρομή του αρχείου στον κατασκευαστή της.

Το παρακάτω παράδειγμα Python δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών της:

```python
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation και περάστε μια διαδρομή αρχείου στον κατασκευαστή του.
with slides.Presentation("sample.pptx") as presentation:
    # Εκτυπώστε το συνολικό αριθμό διαφανειών στην παρουσίαση.
    print(presentation.slides.length)
```

## **Άνοιγμα Παρουσιάσεων με Κωδικό Πρόσβασης**

Όταν χρειάζεται να ανοίξετε μια παρουσίαση που είναι προστατευμένη με κωδικό, περάστε τον κωδικό μέσω της ιδιότητας [password](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/password/) της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/) για να την αποκρυπτογραφήσετε και να τη φορτώσετε. Το παρακάτω κώδικας Python επιδεικνύει αυτή τη λειτουργία:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Πραγματοποιήστε λειτουργίες στην αποκρυπτογραφημένη παρουσίαση.
```

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

Το Aspose.Slides παρέχει επιλογές—ιδιαίτερα την ιδιότητα [blob_management_options](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/blob_management_options/) στην κλάση [LoadOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/)—για να σας βοηθήσει να φορτώσετε μεγάλες παρουσιάσεις.

Αυτός ο κώδικας Python επιδεικνύει τη φόρτωση μιας μεγάλης παρουσίασης (για παράδειγμα, 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Επιλέξτε τη συμπεριφορά KeepLocked—το αρχείο παρουσίασης θα παραμείνει κλειδωμένο για τη διάρκεια της 
# της παρουσίας Presentation, αλλά δεν χρειάζεται να φορτωθεί στη μνήμη ή να αντιγραφεί σε προσωρινό αρχείο.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # Η μεγάλη παρουσίαση έχει φορτωθεί και μπορεί να χρησιμοποιηθεί, ενώ η κατανάλωση μνήμης παραμένει χαμηλή.

    # Κάντε αλλαγές στην παρουσίαση.
    presentation.slides[0].name = "Large presentation"

    # Αποθηκεύστε την παρουσίαση σε άλλο αρχείο. Η κατανάλωση μνήμης παραμένει χαμηλή κατά τη διάρκεια αυτής της λειτουργίας.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Μην το κάνετε αυτό! Θα προκληθεί εξαίρεση I/O επειδή το αρχείο είναι κλειδωμένο μέχρι να διαγραφεί το αντικείμενο παρουσίασης.
    os.remove(file_path)

# Εντάξει να το κάνετε εδώ. Το αρχείο προέλευσης δεν είναι πλέον κλειδωμένο από το αντικείμενο παρουσίασης.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
Για να παρακαμφθούν ορισμένοι περιορισμοί κατά την εργασία με ροές, το Aspose.Slides ενδέχεται να αντιγράψει τα περιεχόμενα μιας ροής. Η φόρτωση μιας μεγάλης παρουσίασης από ροή προκαλεί αντιγραφή της παρουσίασης και μπορεί να επιβραδύνει τη διαδικασία. Συνεπώς, όταν χρειάζεται να φορτώσετε μια μεγάλη παρουσίαση, συνιστούμε ανεπιφύλακτα τη χρήση της διαδρομής αρχείου της παρουσίασης αντί για ροή.

Κατά τη δημιουργία μιας παρουσίασης που περιέχει μεγάλα αντικείμενα (βίντεο, ήχο, εικόνες υψηλής ανάλυσης κ.λπ.), μπορείτε να χρησιμοποιήσετε τη [BLOB management](/slides/el/python-net/manage-blob/) για μείωση της κατανάλωσης μνήμης.
{{%/alert %}}

## **Φόρτωση Παρουσιάσεων Χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση PowerPoint μπορεί να περιέχει τους εξής τύπους ενσωματωμένων δυαδικών αντικειμένων:

- VBA project (προσβάσιμο μέσω [Presentation.vba_project](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/vba_project/));
- OLE object embedded data (προσβάσιμο μέσω [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/el/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- ActiveX control binary data (προσβάσιμο μέσω [Control.active_x_control_binary](https://reference.aspose.com/slides/el/python-net/aspose.slides/control/active_x_control_binary/)).

Χρησιμοποιώντας την ιδιότητα [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/), μπορείτε να φορτώσετε μια παρουσίαση χωρίς κανένα ενσωματωμένο δυαδικό αντικείμενο.

Αυτή η ιδιότητα είναι χρήσιμη για την αφαίρεση ενδεχομένως κακόβουλου δυαδικού περιεχομένου. Το παρακάτω κώδικας Python δείχνει πώς να φορτώσετε μια παρουσίαση χωρίς ενσωματωμένο δυαδικό περιεχόμενο:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Εκτελέστε λειτουργίες στην παρουσίαση.
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανο открывается?**

Θα λάβετε εξαίρεση επαλήθευσης σύνταξης/μορφής κατά τη φόρτωση. Τέτοια σφάλματα συχνά αναφέρουν μη έγκυρη δομή ZIP ή χαλασμένες εγγραφές PowerPoint.

**Τι συμβαίνει αν λείπουν τα απαιτούμενα γραμματοσειρά όταν ανοίγουμε το αρχείο;**

Το αρχείο θα ανοίξει, αλλά αργότερα η [απόδοση/εξαγωγή](/slides/el/python-net/convert-presentation/) ενδέχεται να αντικαταστήσει τις γραμματοσειρές. [Διαμορφώστε τις υποκαταστάσεις γραμματοσειρών](/slides/el/python-net/font-substitution/) ή [προσθέστε τις απαιτούμενες γραμματοσειρές](/slides/el/python-net/custom-font/) στο περιβάλλον εκτέλεσης.

**Τι γίνεται με τα ενσωματωμένα μέσα (βίντεο/ήχος) κατά το άνοιγμα;**

Γίνονται διαθέσιμα ως πόροι της παρουσίασης. Εάν τα μέσα αναφέρονται μέσω εξωτερικών διαδρομών, βεβαιωθείτε ότι αυτές οι διαδρομές είναι προσβάσιμες στο περιβάλλον σας· διαφορετικά η [απόδοση/εξαγωγή](/slides/el/python-net/convert-presentation/) ενδέχεται να παραλείψει τα μέσα.