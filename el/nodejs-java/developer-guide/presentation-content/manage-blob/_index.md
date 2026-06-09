---
title: Διαχείριση BLOB Παρουσίασης σε JavaScript για Αποδοτική Χρήση Μνήμης
linktitle: Διαχείριση BLOB
type: docs
weight: 10
url: /el/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε δεδομένα BLOB σε JavaScript με το Aspose.Slides for Node.js για βελτιστοποίηση των λειτουργιών αρχείων PowerPoint και OpenDocument για αποδοτική διαχείριση παρουσιάσεων."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει διαχείριση με βάση BLOB για μεγάλα δυαδικά δεδομένα σε παρουσιάσεις, ώστε να μειώνεται η κατανάλωση μνήμης όταν εργάζεστε με μεγάλες εικόνες, ήχους, βίντεο και αρχεία παρουσίασης.

Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε την επεξεργασία με BLOB για να προσθέσετε μεγάλο μέσο σε μια παρουσίαση, να εξάγετε μεγάλο μέσο από μια παρουσίαση και να φορτώνετε μεγάλες παρουσιάσεις πιο αποδοτικά. Επίσης εξηγεί πώς μπορούν να χρησιμοποιηθούν προσωρινά αρχεία κατά την επεξεργασία και πώς να αλλάξετε τον φάκελο αποθήκευσης τους.

## **Σχετικά με το BLOB**

**BLOB** (**Binary Large Object**) είναι συνήθως ένα μεγάλο αντικείμενο (φωτογραφία, παρουσίαση, έγγραφο ή μέσο) αποθηκευμένο σε δυαδική μορφή.

Το Aspose.Slides for Node.js via Java σας επιτρέπει να χρησιμοποιήσετε BLOB για αντικείμενα με τρόπο που μειώνει την κατανάλωση μνήμης όταν εμπλέκονται μεγάλα αρχεία.

{{% alert title="Πληροφορίες" color="info" %}}

Για να παρακάμψετε ορισμένους περιορισμούς κατά την αλληλεπίδραση με ροές, το Aspose.Slides ενδέχεται να αντιγράψει το περιεχόμενο της ροής. Η φόρτωση μιας μεγάλης παρουσίασης μέσω της ροής της θα οδηγήσει στην αντιγραφή των περιεχομένων της παρουσίασης και θα προκαλέσει αργή φόρτωση. Επομένως, όταν σκοπεύετε να φορτώσετε μια μεγάλη παρουσίαση, συνιστούμε έντονα να χρησιμοποιήσετε τη διαδρομή του αρχείου παρουσίασης και όχι τη ροή της.

{{% /alert %}}

## **Χρήση BLOB για Μείωση Κατανάλωσης Μνήμης**

### **Προσθήκη Μεγάλου Αρχείου μέσω BLOB σε Παρουσίαση**

[Aspose.Slides](/slides/el/nodejs-java/) for Node.js via Java σας επιτρέπει να προσθέσετε μεγάλα αρχεία (σε αυτήν την περίπτωση, ένα μεγάλο αρχείο βίντεο) μέσω διαδικασίας που περιλαμβάνει BLOB για μείωση της κατανάλωσης μνήμης.

Αυτό το JavaScript σας δείχνει πώς να προσθέσετε ένα μεγάλο αρχείο βίντεο μέσω της διαδικασίας BLOB σε μια παρουσίαση:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί το βίντεο
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Ας προσθέσουμε το βίντεο στην παρουσίαση - επιλέξαμε τη συμπεριφορά KeepLocked επειδή κάνουμε
        // μη πρόθεση πρόσβασης στο αρχείο "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Αποθηκεύει την παρουσίαση. Ενώ μια μεγάλη παρουσίαση εξάγεται, η κατανάλωση μνήμης
        // παραμένει χαμηλή καθ' όλη τη διάρκεια ζωής του αντικειμένου pres
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Εξαγωγή Μεγάλου Αρχείου μέσω BLOB από Παρουσίαση**

Το Aspose.Slides for Node.js via Java σας επιτρέπει να εξάγετε μεγάλα αρχεία (στην περίπτωση αυτή, αρχείο ήχου ή βίντεο) μέσω διαδικασίας που περιλαμβάνει BLOB από παρουσιάσεις. Για παράδειγμα, ίσως χρειαστεί να εξαγάγετε ένα μεγάλο αρχείο μέσου από μια παρουσίαση αλλά δεν θέλετε το αρχείο να φορτωθεί στη μνήμη του υπολογιστή σας. Εξάγοντας το αρχείο μέσω της διαδικασίας BLOB, διατηρείτε τη χρήση μνήμης χαμηλή.

Αυτός ο κώδικας σε JavaScript παρουσιάζει την περιγραφόμενη λειτουργία:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Locks the source file and does NOT load it into memory
// Κλειδώνει το αρχείο προέλευσης και δεν το φορτώνει στη μνήμη
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
// δημιουργεί το στιγμιότυπο Presentation, κλειδώνει το αρχείο "hugePresentationWithAudiosAndVideos.pptx" file.
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
    // Ας σώσουμε κάθε βίντεο σε αρχείο. Για την πρόληψη υψηλής χρήσης μνήμης, χρειαζόμαστε ένα buffer που θα χρησιμοποιηθεί
    // to transfer the data from the presentation's video stream to a stream for a newly created video file.
    // για τη μεταφορά των δεδομένων από τη ροή βίντεο της παρουσίασης σε ροή για ένα νεοδημιουργηθέν αρχείο βίντεο.
    var buffer = new byte[8 * 1024];
    // Iterates through the videos
    // Διατρέχει τα βίντεο
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
        // Ανοίγει τη ροή βίντεο της παρουσίασης. Παρακαλώ, σημειώστε ότι αποφεύγουμε σκόπιμα την πρόσβαση σε ιδιότητες
        // like video.BinaryData - because this property returns a byte array containing a full video, which then
        // όπως video.BinaryData - επειδή αυτή η ιδιότητα επιστρέφει έναν πίνακα byte που περιέχει ολόκληρο το βίντεο, το οποίο μετά
        // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
        // προκαλεί τη φόρτωση byte στη μνήμη. Χρησιμοποιούμε το video.GetStream, το οποίο επιστρέφει Stream - και δεν
        // require us to load the whole video into the memory.
        // απαιτεί να φορτώσουμε ολόκληρο το βίντεο στη μνήμη.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Memory consumption will remain low regardless of the size of the video or presentation.
        // Η κατανάλωση μνήμης θα παραμείνει χαμηλή ανεξάρτητα από το μέγεθος του βίντεο ή της παρουσίασης.
    }
    // If necessary, you can apply the same steps for audio files.
    // Αν χρειαστεί, μπορείτε να εφαρμόσετε τα ίδια βήματα για αρχεία ήχου.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Προσθήκη Εικόνας ως BLOB στην Παρουσίαση**

Με τις μεθόδους της κλάσης [**ImageCollection**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ImageCollection) και [**ImageCollection**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ImageCollection) μπορείτε να προσθέσετε μια μεγάλη εικόνα ως ροή ώστε να αντιμετωπίζεται ως BLOB.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε μια μεγάλη εικόνα μέσω της διαδικασίας BLOB:

```javascript
var pathToLargeImage = "large_image.jpg";
// Δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί η εικόνα.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Ας προσθέσουμε την εικόνα στην παρουσίαση - επιλέγουμε τη συμπεριφορά KeepLocked επειδή
        // ΔΕΝ προτίθεται να προσπελάσει το αρχείο "largeImage.png".
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Αποθηκεύει την παρουσίαση. Ενώ μια μεγάλη παρουσίαση εξάγεται, η κατανάλωση μνήμης
        // παραμένει χαμηλή καθ' όλη τη διάρκεια ζωής του αντικειμένου pres.
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Μνήμη και Μεγάλες Παρουσιάσεις**

Κατά κανόνα, για τη φόρτωση μιας μεγάλης παρουσίασης, οι υπολογιστές απαιτούν πολύ προσωρινή μνήμη. Όλο το περιεχόμενο της παρουσίασης φορτώνεται στη μνήμη και το αρχείο (από το οποίο φορτώθηκε η παρουσίαση) σταματά να χρησιμοποιείται.

Σκεφτείτε μια μεγάλη παρουσίαση PowerPoint (large.pptx) που περιέχει ένα αρχείο βίντεο 1,5 GB. Η τυπική μέθοδος φόρτωσης της παρουσίασης περιγράφεται σε αυτόν τον κώδικα JavaScript:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Αλλά αυτή η μέθοδος καταναλώνει περίπου 1,6 GB προσωρινής μνήμης.

### **Φόρτωση Μεγάλης Παρουσίασης ως BLOB**

Μέσω της διαδικασίας που περιλαμβάνει BLOB, μπορείτε να φορτώσετε μια μεγάλη παρουσίαση χρησιμοποιώντας ελάχιστη μνήμη. Αυτός ο κώδικας JavaScript περιγράφει την υλοποίηση όπου η διαδικασία BLOB χρησιμοποιείται για τη φόρτωση ενός μεγάλου αρχείου παρουσίασης (large.pptx):

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Αλλαγή Φακέλου για Προσωρινά Αρχεία**

Όταν χρησιμοποιείται η διαδικασία BLOB, ο υπολογιστής σας δημιουργεί προσωρινά αρχεία στον προεπιλεγμένο φάκελο προσωρινών αρχείων. Εάν θέλετε τα προσωρινά αρχεία να αποθηκεύονται σε διαφορετικό φάκελο, μπορείτε να αλλάξετε τις ρυθμίσεις αποθήκευσης χρησιμοποιώντας `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Πληροφορίες" color="info" %}}

Όταν χρησιμοποιείτε `setTempFilesRootPath`, το Aspose.Slides δεν δημιουργεί αυτόματα φάκελο για την αποθήκευση των προσωρινών αρχείων. Πρέπει να δημιουργήσετε τον φάκελο χειροκίνητα.

{{% /alert %}}

### **Απελευθέρωση Αντικειμένων Παρουσίασης για Αποδέσμευση Μνήμης**

Κατά την επεξεργασία μεγάλων παρουσιάσεων, βεβαιωθείτε ότι η παρουσίαση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) απελευθερώνεται σωστά ώστε η μνήμη που κατείχε να απελευθερωθεί. Καλέστε `dispose()` αφού ολοκληρώσετε τη χρήση της παρουσίασης για να ελευθερώσετε μη διαχειριζόμενους πόρους.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια δεδομένα σε μια παρουσίαση Aspose.Slides αντιμετωπίζονται ως BLOB και ελέγχονται από τις επιλογές BLOB;**

Μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχος και βίντεο αντιμετωπίζονται ως BLOB. Ολόκληρο το αρχείο παρουσίασης επίσης εμπλέκεται στη διαχείριση BLOB όταν φορτώνεται ή αποθηκεύεται. Αυτά τα αντικείμενα διέπονται από πολιτικές BLOB που σας επιτρέπουν να διαχειρίζεστε τη χρήση μνήμης και τη μεταφορά σε προσωρινά αρχεία όταν χρειάζεται.

**Πού ρυθμίζω τους κανόνες διαχείρισης BLOB κατά τη φόρτωση μιας παρουσίασης;**

Χρησιμοποιήστε το [LoadOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/) με το [BlobManagementOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/blobmanagementoptions/). Εκεί ορίζετε το όριο μνήμης για BLOB, επιτρέπετε ή δεν επιτρέπετε προσωρινά αρχεία, επιλέγετε τη ρίζα του φακέλου για προσωρινά αρχεία και καθορίζετε τη συμπεριφορά κλειδώματος της πηγής.

**Επηρεάζουν οι ρυθμίσεις BLOB την απόδοση και πώς ισορροπώ την ταχύτητα με τη μνήμη;**

Ναι. Η διατήρηση των BLOB στη μνήμη μεγιστοποιεί την ταχύτητα αλλά αυξάνει την κατανάλωση RAM· η μείωση του ορίου μνήμης μεταφέρει περισσότερη εργασία σε προσωρινά αρχεία, μειώνοντας τη RAM με κόστος πρόσθετου I/O. Χρησιμοποιήστε τη μέθοδο [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) για να βρείτε τη σωστή ισορροπία για το φορτίο εργασίας και το περιβάλλον σας.

**Βοηθούν οι επιλογές BLOB όταν ανοίγω εξαιρετικά μεγάλες παρουσιάσεις (π.χ. gigabytes);**

Ναι. Οι [BlobManagementOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/blobmanagementoptions/) έχουν σχεδιαστεί για τέτοιες περιπτώσεις: η ενεργοποίηση προσωρινών αρχείων και η χρήση κλειδώματος πηγής μπορούν να μειώσουν σημαντικά τη μέγιστη χρήση RAM και να σταθεροποιήσουν την επεξεργασία πολύ μεγάλων παρουσιάσεων.

**Μπορώ να χρησιμοποιήσω πολιτικές BLOB κατά τη φόρτωση από ροές αντί για αρχεία δίσκου;**

Ναι. Οι ίδιες κανόνες ισχύουν για ροές: η παρουσίαση μπορεί να κατέχει και να κλειδώνει την είσοδο ροής (ανάλογα με την επιλεγμένη λειτουργία κλειδώματος) και τα προσωρινά αρχεία χρησιμοποιούνται όταν επιτρέπεται, διατηρώντας τη χρήση μνήμης προβλέψιμη κατά την επεξεργασία.