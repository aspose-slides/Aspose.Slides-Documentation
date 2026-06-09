---
title: Διαχείριση BLOBs σε Παρουσιάσεις με Python για Αποδοτική Χρήση Μνήμης
linktitle: Διαχείριση BLOB
type: docs
weight: 10
url: /el/python-net/manage-blob/
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
- Aspose.Slides
description: "Διαχειριστείτε δεδομένα BLOB στο Aspose.Slides για Python μέσω .NET ώστε να βελτιώσετε τις λειτουργίες αρχείων PowerPoint και OpenDocument για αποδοτική διαχείριση παρουσιάσεων."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει διαχείριση με βάση το BLOB για μεγάλα δυαδικά δεδομένα σε παρουσιάσεις, ώστε να μειώσει την κατανάλωση μνήμης κατά την εργασία με μεγάλες εικόνες, ήχο, βίντεο και αρχεία παρουσιάσεων.

Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε επεξεργασία με βάση το BLOB για να προσθέσετε μεγάλα μέσα σε μια παρουσίαση, να εξάγετε μεγάλα μέσα από μια παρουσίαση και να φορτώσετε μεγάλες παρουσιάσεις πιο αποδοτικά. Επίσης εξηγεί πώς μπορούν να χρησιμοποιηθούν προσωρινά αρχεία κατά τη διάρκεια της επεξεργασίας και πώς να αλλάξετε το φάκελο που χρησιμοποιείται για την αποθήκευσή τους.

## **Σχετικά με το BLOB**

**BLOB** (**Binary Large Object**) είναι συνήθως ένα μεγάλο αντικείμενο (φωτογραφία, παρουσίαση, έγγραφο ή μέσο) που αποθηκεύεται σε δυαδικές μορφές.

Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να χρησιμοποιήσετε BLOBs για αντικείμενα με τρόπο που μειώνει την κατανάλωση μνήμης όταν υπάρχουν μεγάλα αρχεία.

## **Χρήση BLOB για Μείωση Κατανάλωσης Μνήμης**

### **Προσθήκη Μεγάλου Αρχείου μέσω BLOB σε Παρουσίαση**

[Aspose.Slides](/slides/el/python-net/) για .NET σας επιτρέπει να προσθέσετε μεγάλα αρχεία (συγκεκριμένα, ένα μεγάλο αρχείο βίντεο) μέσω μιας διαδικασίας που χρησιμοποιεί BLOBs για τη μείωση της κατανάλωσης μνήμης.

Αυτό το παράδειγμα Python σας δείχνει πώς να προσθέσετε ένα μεγάλο αρχείο βίντεο μέσω της διαδικασίας BLOB σε μια παρουσίαση:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί το βίντεο
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Ας προσθέσουμε το βίντεο στην παρουσίαση - επιλέξαμε τη συμπεριφορά KeepLocked επειδή
        # δεν προοριζόμαστε να προσπελάσουμε το αρχείο "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Αποθηκεύει την παρουσίαση. Ενώ μια μεγάλη παρουσίαση εξάγεται, η κατανάλωση μνήμης
        # παραμένει χαμηλή κατά τη διάρκεια ζωής του αντικειμένου pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Εξαγωγή Μεγάλου Αρχείου μέσω BLOB από Παρουσίαση**
Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να εξάγετε μεγάλα αρχεία (σε αυτήν την περίπτωση, ένα αρχείο ήχου ή βίντεο) μέσω μιας διαδικασίας που χρησιμοποιεί BLOBs από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστεί να εξάγετε ένα μεγάλο αρχείο μέσου από μια παρουσίαση αλλά δεν θέλετε το αρχείο να φορτωθεί στη μνήμη του υπολογιστή σας. Εξάγοντας το αρχείο μέσω της διαδικασίας BLOB διατηρείτε τη χρήση μνήμης χαμηλή.

Αυτός ο κώδικας Python επιδεικνύει τη περιγραφείσα λειτουργία:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Ας αποθηκεύσουμε κάθε βίντεο σε αρχείο. Για να αποτρέψουμε υψηλή χρήση μνήμης, χρειαζόμαστε ένα buffer που θα χρησιμοποιηθεί
	# για τη μεταφορά των δεδομένων από τη ροή βίντεο της παρουσίασης σε ροή για ένα νεοδημιουργημένο αρχείο βίντεο.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Επανάληψη μέσω των βίντεο
    index = 0
    # Αν χρειαστεί, μπορείτε να εφαρμόσετε τα ίδια βήματα για αρχεία ήχου. 
    for video in pres.videos:
		# Ανοίγει τη ροή βίντεο της παρουσίασης. Παρακαλώ, σημειώστε ότι αποφεύγουμε σκόπιμα την πρόσβαση σε ιδιότητες
		# όπως video.BinaryData - επειδή αυτή η ιδιότητα επιστρέφει έναν πίνακα byte που περιέχει ολόκληρο το βίντεο, το οποίο στη συνέχεια
		# προκαλεί τη φόρτωση των byte στη μνήμη. Χρησιμοποιούμε το video.GetStream, το οποίο επιστρέφει Stream - και ΔΕΝ
		#  απαιτεί να φορτώσουμε ολόκληρο το βίντεο στη μνήμη.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Προσθήκη Εικόνας ως BLOB σε Παρουσίαση**
Με τις μεθόδους της κλάσης [**ImageCollection**](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/), μπορείτε να προσθέσετε μια μεγάλη εικόνα ως ροή ώστε να θεωρηθεί BLOB.

Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε μια μεγάλη εικόνα μέσω της διαδικασίας BLOB:

```py
import aspose.slides as slides

# δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί η εικόνα.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Μνήμη και Μεγάλες Παρουσιάσεις**

Συνήθως, για να φορτώσετε μια μεγάλη παρουσίαση, οι υπολογιστές απαιτούν πολλή προσωρινή μνήμη. Όλο το περιεχόμενο της παρουσίασης φορτώνεται στη μνήμη και το αρχείο (από το οποίο φορτώθηκε η παρουσίαση) σταματά να χρησιμοποιείται.

Σκεφτείτε μια μεγάλη παρουσίαση PowerPoint (large.pptx) που περιέχει ένα αρχείο βίντεο 1,5 GB. Η τυπική μέθοδος φόρτωσης της παρουσίασης περιγράφεται σε αυτόν τον κώδικα Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Ωστόσο, αυτή η μέθοδος καταναλώνει περίπου 1,6 GB προσωρινής μνήμης.

### **Φόρτωση Μεγάλης Παρουσίασης ως BLOB**

Μέσω της διαδικασίας που περιλαμβάνει BLOB, μπορείτε να φορτώσετε μια μεγάλη παρουσίαση χρησιμοποιώντας λίγη μνήμη. Αυτός ο κώδικας Python περιγράφει την υλοποίηση όπου η διαδικασία BLOB χρησιμοποιείται για τη φόρτωση ενός μεγάλου αρχείου παρουσίασης (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Αλλαγή Φακέλου για Προσωρινά Αρχεία**

Όταν χρησιμοποιείται η διαδικασία BLOB, ο υπολογιστής σας δημιουργεί προσωρινά αρχεία στον προεπιλεγμένο φάκελο προσωρινών αρχείων. Εάν θέλετε τα προσωρινά αρχεία να αποθηκεύονται σε διαφορετικό φάκελο, μπορείτε να αλλάξετε τις ρυθμίσεις αποθήκευσης χρησιμοποιώντας `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
Όταν χρησιμοποιείτε το `temp_files_root_path`, το Aspose.Slides δεν δημιουργεί αυτόματα φάκελο για την αποθήκευση προσωρινών αρχείων. Πρέπει να δημιουργήσετε το φάκελο χειροκίνητα.
{{% /alert %}}

### **Καταστροφή Αντικειμένων Παρουσίασης για Απελευθέρωση Μνήμης**

Κατά την επεξεργασία μεγάλων παρουσιάσεων, βεβαιωθείτε ότι η παρουσίαση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) εκτελείται σωστά ώστε η μνήμη που κατείχε να απελευθερωθεί. Η προτεινόμενη μέθοδος είναι η χρήση του διαχειριστή περιβάλλοντος (`with slides.Presentation(...) as presentation:`) όπως φαίνεται στα παραπάνω παραδείγματα· κλείνει αυτόματα την παρουσίαση και ελευθερώνει μη διαχειριζόμενους πόρους όταν τερματίζεται το μπλοκ.

Εάν δημιουργήσετε μια παρουσίαση χωρίς μπλοκ `with`, καλέστε ρητά το `presentation.dispose()` αφού ολοκληρώσετε τη χρήση της και αφαιρέστε τυχόν υπόλοιπες αναφορές ώστε ο συλλέκτης απορριμμάτων της Python να μπορεί να ανακτήσει τη μνήμη.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...επεξεργασία της παρουσίασης...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Απελευθέρωση πόρων ρητά.
presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Ποια δεδομένα σε μια παρουσίαση Aspose.Slides αντιμετωπίζονται ως BLOB και ελέγχονται από τις επιλογές BLOB;**

Τα μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχος και βίντεο αντιμετωπίζονται ως BLOB. Ολόκληρο το αρχείο παρουσίασης συμμετέχει επίσης στη διαχείριση BLOB κατά τη φόρτωση ή αποθήκευση. Αυτά τα αντικείμενα διέπονται από πολιτικές BLOB που σας επιτρέπουν να διαχειρίζεστε τη χρήση μνήμης και να αποθηκεύετε προσωρινά αρχεία όταν χρειάζεται.

**Πού ρυθμίζω τους κανόνες διαχείρισης BLOB κατά τη φόρτωση της παρουσίασης;**

Χρησιμοποιήστε το [LoadOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/) μαζί με το [BlobManagementOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/blobmanagementoptions/). Εκεί ορίζετε το όριο μνήμης για τα BLOB, επιτρέπετε ή όχι προσωρινά αρχεία, επιλέγετε τον ριζικό φάκελο για τα προσωρινά αρχεία και επιλέγετε τη συμπεριφορά κλειδώματος της πηγής.

**Επηρεάζουν οι ρυθμίσεις BLOB την απόδοση, και πώς ισορροπώ την ταχύτητα vs μνήμη;**

Ναι. Η διατήρηση του BLOB στη μνήμη μεγιστοποιεί την ταχύτητα αλλά αυξάνει την κατανάλωση RAM· η μείωση του ορίου μνήμης μεταφέρει περισσότερη εργασία σε προσωρινά αρχεία, μειώνοντας τη RAM με κόστος πρόσθετων εισόδων/εξόδων I/O. Ρυθμίστε το όριο [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/el/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) ώστε να επιτύχετε τη σωστή ισορροπία για το φόρτο εργασίας και το περιβάλλον σας.

**Βοηθούν οι επιλογές BLOB όταν ανοίγουμε εξαιρετικά μεγάλες παρουσιάσεις (π.χ. γιγαμπάιτς);**

Ναι. Οι [BlobManagementOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/blobmanagementoptions/) είναι σχεδιασμένες για τέτοια σενάρια: η ενεργοποίηση προσωρινών αρχείων και η χρήση κλειδώματος πηγής μπορούν να μειώσουν σημαντικά το μέγιστο χρήσης RAM και να σταθεροποιήσουν την επεξεργασία πολύ μεγάλων παρουσιάσεων.

**Μπορώ να χρησιμοποιήσω πολιτικές BLOB όταν φορτώνω από ροές αντί για αρχεία δίσκου;**

Ναι. Οι ίδιες κανόνες ισχύουν για τις ροές: η παρουσίαση μπορεί να κατέχει και να κλειδώνει την εισαγώμενη ροή (ανάλογα με την επιλεγμένη λειτουργία κλειδώματος), και τα προσωρινά αρχεία χρησιμοποιούνται όταν επιτρέπονται, διατηρώντας τη χρήση μνήμης προβλέψιμη κατά την επεξεργασία.