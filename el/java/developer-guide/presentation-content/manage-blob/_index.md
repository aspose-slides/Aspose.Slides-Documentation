---
title: Διαχείριση BLOB Παρουσιάσεων σε Java για Αποτελεσματική Χρήση Μνήμης
linktitle: Διαχείριση BLOB
type: docs
weight: 10
url: /el/java/manage-blob/
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
- Java
- Aspose.Slides
description: "Διαχειριστείτε δεδομένα BLOB στο Aspose.Slides για Java ώστε να βελτιστοποιήσετε τις λειτουργίες αρχείων PowerPoint και OpenDocument για αποδοτική διαχείριση παρουσιάσεων."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει διαχείριση βάσει BLOB για μεγάλα δυαδικά δεδομένα σε παρουσιάσεις, βοηθώντας στη μείωση της κατανάλωσης μνήμης όταν εργάζεστε με μεγάλες εικόνες, ήχο, βίντεο και αρχεία παρουσιάσεων.

Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε την επεξεργασία βάσει BLOB για να προσθέσετε μεγάλα μέσα σε μια παρουσίαση, να εξάγετε μεγάλα μέσα από μια παρουσίαση και να φορτώσετε μεγάλες παρουσιάσεις πιο αποδοτικά. Εξηγεί επίσης πώς μπορούν να χρησιμοποιηθούν προσωρινά αρχεία κατά την επεξεργασία και πώς να αλλάξετε το φάκελο που χρησιμοποιείται για την αποθήκευσή τους.

## **Σχετικά με το BLOB**

**BLOB** (**Binary Large Object**) είναι συνήθως ένα μεγάλο αντικείμενο (φωτογραφία, παρουσίαση, έγγραφο ή μέσο) αποθηκευμένο σε δυαδικές μορφές.

Το Aspose.Slides for Java σας επιτρέπει να χρησιμοποιείτε BLOBs για αντικείμενα με τρόπο που μειώνει την κατανάλωση μνήμης όταν εμπλέκονται μεγάλα αρχεία.

{{% alert title="Info" color="info" %}}
Για να ξεπεράσετε ορισμένους περιορισμούς κατά την αλληλεπίδραση με ροές, το Aspose.Slides ενδέχεται να αντιγράψει το περιεχόμενο της ροής. Η φόρτωση μιας μεγάλης παρουσίασης μέσω της ροής της θα οδηγήσει σε αντιγραφή του περιεχομένου της παρουσίασης και θα προκαλέσει αργή φόρτωση. Επομένως, όταν σκοπεύετε να φορτώσετε μια μεγάλη παρουσίαση, συνιστούμε έντονα να χρησιμοποιείτε τη διαδρομή του αρχείου της παρουσίασης και όχι τη ροή της.
{{% /alert %}}

## **Χρήση BLOB για Μείωση Κατανάλωσης Μνήμης**

### **Προσθήκη Μεγάλου Αρχείου μέσω BLOB σε Παρουσίαση**

[Aspose.Slides](/slides/el/java/) for Java σας επιτρέπει να προσθέσετε μεγάλα αρχεία (στην περίπτωση αυτή, ένα μεγάλο αρχείο βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs για μείωση της κατανάλωσης μνήμης.

Αυτό το παράδειγμα Java δείχνει πώς να προσθέσετε ένα μεγάλο αρχείο βίντεο μέσω της διαδικασίας BLOB σε μια παρουσίαση:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

 // Δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί το βίντεο
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Ας προσθέσουμε το βίντεο στην παρουσίαση - επιλέξαμε τη συμπεριφορά KeepLocked επειδή
        // δεν προτίθεμεναι να προσπελάσουμε το αρχείο "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Αποθηκεύει την παρουσίαση. Καθώς μια μεγάλη παρουσίαση εξάγεται,
        // η χρήση μνήμης παραμένει χαμηλή κατά τη διάρκεια ζωής του αντικειμένου pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Εξαγωγή Μεγάλου Αρχείου μέσω BLOB από Παρουσίαση**

Το Aspose.Slides for Java σας επιτρέπει να εξάγετε μεγάλα αρχεία (συγκεκριμένα, ένα αρχείο ήχου ή βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs από παρουσιάσεις. Για παράδειγμα, ίσως χρειαστεί να εξάγετε ένα μεγάλο αρχείο μέσων από μια παρουσίαση αλλά δεν θέλετε το αρχείο να φορτωθεί στη μνήμη του υπολογιστή σας. Εξάγοντας το αρχείο μέσω της διαδικασίας BLOB, διατηρείτε τη χρήση μνήμης χαμηλή.

Αυτός ο κώδικας σε Java δείχνει τη περιγραφόμενη λειτουργία:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Κλειδώνει το αρχείο πηγής και ΔΕΝ το φορτώνει στη μνήμη
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Δημιουργεί το στιγμιότυπο του Presentation και κλειδώνει το αρχείο "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Ας αποθηκεύσουμε κάθε βίντεο σε αρχείο. Για να αποτρέψουμε υψηλή χρήση μνήμης, χρειαζόμαστε ένα buffer που θα χρησιμοποιηθεί
    // για τη μεταφορά των δεδομένων από τη ροή βίντεο της παρουσίασης σε ροή ενός νεοδημιουργημένου αρχείου βίντεο.
    byte[] buffer = new byte[8 * 1024];

    // Επανάληψη μέσω των βίντεο
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Ανοίγει τη ροή βίντεο της παρουσίασης. Παρακαλώ σημειώστε ότι αποφεύγουμε σκόπιμα την πρόσβαση σε ιδιότητες
        // όπως video.BinaryData - επειδή αυτή η ιδιότητα επιστρέφει έναν πίνακα byte που περιέχει ολόκληρο το βίντεο, το οποίο στη συνέχεια
        // φορτώνει byte στη μνήμη. Χρησιμοποιούμε το video.GetStream, το οποίο επιστρέφει Stream - και ΔΕΝ
        //  απαιτεί να φορτώσουμε ολόκληρο το βίντεο στη μνήμη.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Η κατανάλωση μνήμης θα παραμείνει χαμηλή ανεξαρτήτως του μεγέθους του βίντεο ή της παρουσίασης.
    }
    // Αν χρειαστεί, μπορείτε να εφαρμόσετε τα ίδια βήματα για αρχεία ήχου. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Προσθήκη Εικόνας ως BLOB σε Παρουσίαση**

Με τις μεθόδους από τη διεπαφή [**IImageCollection**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IImageCollection) και την κλάση [**ImageCollection**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ImageCollection), μπορείτε να προσθέσετε μια μεγάλη εικόνα ως ροή ώστε να θεωρηθεί BLOB.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε μια μεγάλη εικόνα μέσω της διαδικασίας BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί η εικόνα.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Ας προσθέσουμε την εικόνα στην παρουσίαση - επιλέγουμε τη συμπεριφορά KeepLocked επειδή
		// ΔΕΝ προτίθεμαι να προσπελάσω το αρχείο "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Αποθηκεύει την παρουσίαση. Καθώς μια μεγάλη παρουσίαση εξάγεται, η κατανάλωση μνήμης
		// παραμένει χαμηλή καθ' όλη τη διάρκεια ζωής του αντικειμένου pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Μνήμη και Μεγάλες Παρουσιάσεις**

Κανονικά, για τη φόρτωση μιας μεγάλης παρουσίασης, οι υπολογιστές απαιτούν πολύ προσωρινή μνήμη. Ολόκληρο το περιεχόμενο της παρουσίασης φορτώνεται στη μνήμη και το αρχείο (από το οποίο φορτώθηκε η παρουσίαση) δεν χρησιμοποιείται πλέον.

Σκεφτείτε μια μεγάλη παρουσίαση PowerPoint (large.pptx) που περιέχει αρχείο βίντεο 1,5 GB. Η τυπική μέθοδος φόρτωσης της παρουσίασης περιγράφεται στον παρακάτω κώδικα Java:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Αλλά αυτή η μέθοδος καταναλώνει περίπου 1,6 GB προσωρινής μνήμης.

### **Φόρτωση Μεγάλης Παρουσίασης ως BLOB**

Μέσω της διαδικασίας που περιλαμβάνει BLOB, μπορείτε να φορτώσετε μια μεγάλη παρουσίαση χρησιμοποιώντας λίγη μνήμη. Αυτός ο κώδικας Java περιγράφει την υλοποίηση όπου η διαδικασία BLOB χρησιμοποιείται για τη φόρτωση ενός μεγάλου αρχείου παρουσίασης (large.pptx):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Αλλαγή Φακέλου για Προσωρινά Αρχεία**

Όταν χρησιμοποιείται η διαδικασία BLOB, ο υπολογιστής σας δημιουργεί προσωρινά αρχεία στον προεπιλεγμένο φάκελο για προσωρινά αρχεία. Εάν θέλετε τα προσωρινά αρχεία να διατηρηθούν σε διαφορετικό φάκελο, μπορείτε να αλλάξετε τις ρυθμίσεις αποθήκευσης χρησιμοποιώντας `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Όταν χρησιμοποιείτε το `TempFilesRootPath`, το Aspose.Slides δεν δημιουργεί αυτόματα φάκελο για την αποθήκευση προσωρινών αρχείων. Πρέπει να δημιουργήσετε τον φάκελο χειροκίνητα.
{{% /alert %}}

### **Αποδέσμευση Αντικειμένων Παρουσίασης για Απελευθέρωση Μνήμης**

Κατά την επεξεργασία μεγάλων παρουσιάσεων, βεβαιωθείτε ότι το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) έχει αποδεσμευθεί σωστά ώστε η μνήμη που κατείχε να απελευθερωθεί. Καλέστε `dispose()` αφού ολοκληρώσετε τη χρήση της παρουσίασης για να ελευθερώσετε μη διαχειριζόμενους πόρους.

```java
Presentation presentation = new Presentation("large.pptx");

// ...επεξεργαστείτε την παρουσίαση...
presentation.save("large.pdf", SaveFormat.Pdf);

// Απελευθερώστε ρητά τους πόρους.
presentation.dispose();
```

## **Συχνές Ερωτήσεις**

**Ποια δεδομένα σε μια παρουσίαση Aspose.Slides αντιμετωπίζονται ως BLOB και ελέγχονται από τις επιλογές BLOB;**

Τα μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχος και βίντεο αντιμετωπίζονται ως BLOB. Ολόκληρο το αρχείο παρουσίασης επίσης εμπλέκεται στην διαχείριση BLOB όταν φορτώνεται ή αποθηκεύεται. Αυτά τα αντικείμενα διέπονται από πολιτικές BLOB που σας επιτρέπουν να διαχειρίζεστε τη χρήση μνήμης και να καταφεύγετε σε προσωρινά αρχεία όταν χρειάζεται.

**Πού μπορώ να ρυθμίσω τους κανόνες διαχείρισης BLOB κατά τη φόρτωση παρουσίασης;**

Χρησιμοποιήστε το [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/) μαζί με το [BlobManagementOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/blobmanagementoptions/). Εκεί ορίζετε το όριο μνήμης για BLOB, επιτρέπετε ή απαγορεύετε τα προσωρινά αρχεία, επιλέγετε τη ρίζα διαδρομή για τα προσωρινά αρχεία και ορίζετε τη συμπεριφορά κλειδώματος της πηγής.

**Επηρεάζουν οι ρυθμίσεις BLOB την απόδοση, και πώς μπορώ να ισορροπήσω την ταχύτητα με τη μνήμη;**

Ναι. Η διατήρηση των BLOB στη μνήμη μεγιστοποιεί την ταχύτητα αλλά αυξάνει την κατανάλωση RAM· η μείωση του ορίου μνήμης μεταφέρει περισσότερη εργασία σε προσωρινά αρχεία, μειώνοντας τη RAM με κόστος επιπλέον I/O. Χρησιμοποιήστε τη μέθοδο [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/el/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) για να επιτύχετε τη σωστή ισορροπία για το φορτίο εργασίας και το περιβάλλον σας.

**Βοηθούν οι επιλογές BLOB κατά το άνοιγμα εξαιρετικά μεγάλων παρουσιάσεων (π.χ. gigabytes);**

Ναι. Τα [BlobManagementOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/blobmanagementoptions/) έχουν σχεδιαστεί για τέτοια σενάρια: η ενεργοποίηση των προσωρινών αρχείων και η χρήση κλειδώματος πηγής μπορούν να μειώσουν σημαντικά τη μέγιστη χρήση RAM και να σταθεροποιήσουν την επεξεργασία πολύ μεγάλων παρουσιάσεων.

**Μπορώ να χρησιμοποιήσω πολιτικές BLOB όταν φορτώνω από ροές αντί για αρχεία δίσκου;**

Ναι. Οι ίδιες κανόνες ισχύουν για τις ροές: το αντικείμενο παρουσίασης μπορεί να κατέχει και να κλειδώνει τη ροή εισόδου (ανάλογα με τη λειτουργία κλειδώματος που έχει επιλεγεί), και τα προσωρινά αρχεία χρησιμοποιούνται όταν επιτρέπεται, διατηρώντας τη χρήση μνήμης προβλέψιμη κατά την επεξεργασία.