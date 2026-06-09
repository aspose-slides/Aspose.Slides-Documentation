---
title: Διαχείριση BLOB Παρουσιάσεων σε Android για Αποτελεσματική Χρήση Μνήμης
linktitle: Διαχείριση BLOB
type: docs
weight: 10
url: /el/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Διαχείριση δεδομένων BLOB στο Aspose.Slides για Android μέσω Java για την εφευρετική διαχείριση αρχείων PowerPoint και OpenDocument με αποδοτικό χειρισμό παρουσίασης."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει διαχείριση βασισμένη σε BLOB για μεγάλα δυαδικά δεδομένα σε παρουσιάσεις, προκειμένου να βοηθήσει στη μείωση της κατανάλωσης μνήμης όταν εργάζεστε με μεγάλες εικόνες, ήχο, βίντεο και αρχεία παρουσιάσεων.

Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε επεξεργασία βασισμένη σε BLOB για να προσθέσετε μεγάλα μέσα σε μια παρουσίαση, να εξάγετε μεγάλα μέσα από μια παρουσίαση και να φορτώνετε μεγάλες παρουσιάσεις πιο αποδοτικά. Επίσης εξηγεί πώς μπορούν να χρησιμοποιηθούν προσωρινά αρχεία κατά την επεξεργασία και πώς να αλλάξετε το φάκελο που χρησιμοποιείται για την αποθήκευσή τους.

## **Σχετικά με το BLOB**

**BLOB** (**Binary Large Object**) είναι συνήθως ένα μεγάλο αντικείμενο (φωτογραφία, παρουσίαση, έγγραφο ή πολυμέσο) αποθηκευμένο σε δυαδικές μορφές.

Το Aspose.Slides for Android μέσω Java σας επιτρέπει να χρησιμοποιείτε BLOBs για αντικείμενα με τρόπο που μειώνει την κατανάλωση μνήμης όταν εμπλέκονται μεγάλα αρχεία.

{{% alert title="Info" color="info" %}}
Για να παρακάμψετε ορισμένους περιορισμούς κατά την αλληλεπίδραση με ροές, το Aspose.Slides μπορεί να αντιγράψει το περιεχόμενο της ροής. Η φόρτωση μιας μεγάλης παρουσίασης μέσω της ροής της θα οδηγήσει στην αντιγραφή των περιεχομένων της παρουσίασης και θα προκαλέσει αργή φόρτωση. Συνεπώς, όταν σκοπεύετε να φορτώσετε μια μεγάλη παρουσίαση, συνιστούμε έντονα να χρησιμοποιήσετε τη διαδρομή του αρχείου παρουσίασης και όχι τη ροή της.
{{% /alert %}}

## **Χρήση BLOB για Μείωση Κατανάλωσης Μνήμης**

### **Προσθήκη Μεγάλου Αρχείου μέσω BLOB σε Παρουσίαση**

Το Aspose.Slides for Java σας επιτρέπει να προσθέσετε μεγάλα αρχεία (σε αυτήν την περίπτωση, ένα μεγάλο αρχείο βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs για να μειώσετε την κατανάλωση μνήμης.

Αυτό το παράδειγμα Java σας δείχνει πώς να προσθέσετε ένα μεγάλο αρχείο βίντεο μέσω της διαδικασίας BLOB σε μια παρουσίαση:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί το βίντεο
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Ας προσθέσουμε το βίντεο στην παρουσίαση - επιλέξαμε τη συμπεριφορά KeepLocked επειδή
        // δεν προτίθενται να προσπελάσουμε το αρχείο "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Αποθηκεύει την παρουσίαση. Ενώ δημιουργείται μια μεγάλη παρουσίαση, η κατανάλωση μνήμης
        // παραμένει χαμηλή κατά τη διάρκεια του κύκλου ζωής του αντικειμένου pres 
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
Το Aspose.Slides for Android μέσω Java σας επιτρέπει να εξάγετε μεγάλα αρχεία (σε αυτήν την περίπτωση, ένα αρχείο ήχου ή βίντεο) μέσω μιας διαδικασίας που περιλαμβάνει BLOBs από παρουσιάσεις. Για παράδειγμα, ίσως χρειαστεί να εξάγετε ένα μεγάλο αρχείο πολυμέσου από μια παρουσίαση αλλά δεν θέλετε το αρχείο να φορτωθεί στη μνήμη του υπολογιστή σας. Εξάγοντας το αρχείο μέσω της διαδικασίας BLOB, διατηρείτε τη χρήση μνήμης χαμηλή.

Αυτός ο κώδικας σε Java δείχνει τη περιγραφόμενη λειτουργία:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Κλειδώνει το αρχείο πηγής και ΔΕΝ το φορτώνει στη μνήμη
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// δημιουργεί το αντικείμενο Presentation, κλειδώνει το αρχείο "hugePresentationWithAudiosAndVideos.pptx" file.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Ας αποθηκεύσουμε κάθε βίντεο σε αρχείο. Για να αποτρέψουμε υψηλή χρήση μνήμης, χρειαζόμεσ       
    // α ένα buffer που θα χρησιμοποιηθεί
    // για τη μεταφορά των δεδομένων από τη ροή βίντεο της παρουσίασης σε ροή ενός νεοδημιουργημένου αρχείου βίντεο.
    byte[] buffer = new byte[8 * 1024];

    // Διασχίζει τα βίντεο
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Ανοίγει τη ροή βίντεο της παρουσίασης. Παρακαλώ σημειώστε ότι εσκεμμένα αποφεύγαμε την πρόσβαση σε ιδιότητες
        // όπως video.BinaryData - επειδή αυτή η ιδιότητα επιστρέφει έναν πίνακα byte που περιέχει ολόκληρο το βίντεο, το οποίο
        // προκαλεί τη φόρτωση byte στη μνήμη. Χρησιμοποιούμε το video.GetStream, το οποίο θα επιστρέψει Stream - και ΔΕΝ
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
    // Εάν είναι απαραίτητο, μπορείτε να εφαρμόσετε τα ίδια βήματα για αρχεία ήχου. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Προσθήκη Εικόνας ως BLOB σε Παρουσίαση**
Με τις μεθόδους από το [**IImageCollection**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IImageCollection) interface και την κλάση [**ImageCollection**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ImageCollection), μπορείτε να προσθέσετε μια μεγάλη εικόνα ως ροή ώστε να αντιμετωπιστεί ως BLOB.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε μια μεγάλη εικόνα μέσω της διαδικασίας BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// δημιουργεί μια νέα παρουσίαση στην οποία θα προστεθεί η εικόνα.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Ας προσθέσουμε την εικόνα στην παρουσίαση - επιλέγουμε τη συμπεριφορά KeepLocked επειδή
		// ΔΕΝ προτιθέμεθα να προσπελάσουμε το αρχείο "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Αποθηκεύει την παρουσίαση. Ενώ δημιουργείται μια μεγάλη παρουσίαση, η κατανάλωση μνήμης
		// παραμένει χαμηλή κατά τη διάρκεια του κύκλου ζωής του αντικειμένου pres
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

Συνήθως, για τη φόρτωση μιας μεγάλης παρουσίασης, οι υπολογιστές απαιτούν πολύ προσωρινή μνήμη. Όλο το περιεχόμενο της παρουσίασης φορτώνεται στη μνήμη και το αρχείο (από το οποίο φορτώθηκε η παρουσίαση) δεν χρησιμοποιείται πλέον.

Σκεφτείτε μια μεγάλη παρουσίαση PowerPoint (large.pptx) που περιέχει ένα αρχείο βίντεο 1,5 GB. Η τυπική μέθοδος φόρτωσης της παρουσίασης περιγράφεται σε αυτόν τον κώδικα Java:

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

Μέσω της διαδικασίας που περιλαμβάνει BLOB, μπορείτε να φορτώσετε μια μεγάλη παρουσίαση χρησιμοποιώντας πολύ λίγη μνήμη. Αυτός ο κώδικας Java περιγράφει την υλοποίηση όπου η διαδικασία BLOB χρησιμοποιείται για τη φόρτωση ενός μεγάλου αρχείου παρουσίασης (large.pptx):

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

Όταν χρησιμοποιείται η διαδικασία BLOB, ο υπολογιστής σας δημιουργεί προσωρινά αρχεία στον προεπιλεγμένο φάκελο προσωρινών αρχείων. Εάν θέλετε τα προσωρινά αρχεία να αποθηκεύονται σε διαφορετικό φάκελο, μπορείτε να αλλάξετε τις ρυθμίσεις αποθήκευσης χρησιμοποιώντας `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Όταν χρησιμοποιείτε το `TempFilesRootPath`, το Aspose.Slides δεν δημιουργεί αυτόματα φάκελο για την αποθήκευση των προσωρινών αρχείων. Πρέπει να δημιουργήσετε τον φάκελο χειροκίνητα.
{{% /alert %}}

### **Αποδέσμευση Αντικειμένων Παρουσίασης για Απελευθέρωση Μνήμης**

Κατά την επεξεργασία μεγάλων παρουσιάσεων, βεβαιωθείτε ότι το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) αποδεσμεύεται σωστά ώστε η μνήμη που κατέχει να απελευθερωθεί. Καλέστε `dispose()` μετά το τέλος χρήσης της παρουσίασης για να απελευθερωθούν οι μη διαχειριζόμενοι πόροι.

```java
Presentation presentation = new Presentation("large.pptx");

// ...επεξεργασία της παρουσίασης...
presentation.save("large.pdf", SaveFormat.Pdf");

// Ρητή απελευθέρωση πόρων.
presentation.dispose();
```

## **Συχνές Ερωτήσεις**

**Ποια δεδομένα σε μια παρουσίαση Aspose.Slides θεωρούνται BLOB και ελέγχονται από τις επιλογές BLOB;**

Μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχος και βίντεο θεωρούνται BLOB. Ολόκληρο το αρχείο παρουσίασης επίσης εμπλέκεται σε διαχείριση BLOB όταν φορτώνεται ή αποθηκεύεται. Αυτά τα αντικείμενα διέπονται από πολιτικές BLOB που σας επιτρέπουν να διαχειρίζεστε τη χρήση μνήμης και την εκροή σε προσωρινά αρχεία όταν χρειάζεται.

**Πού ρυθμίζω τους κανόνες διαχείρισης BLOB κατά τη φόρτωση παρουσίασης;**

Χρησιμοποιήστε το [LoadOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/) μαζί με το [BlobManagementOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/blobmanagementoptions/). Εκεί ορίζετε το όριο μνήμης για BLOB, επιτρέπετε ή απαγορεύετε προσωρινά αρχεία, επιλέγετε τη ρίζα διαδρομή για τα προσωρινά αρχεία και καθορίζετε τη συμπεριφορά κλειδώματος της πηγής.

**Επηρεάζουν οι ρυθμίσεις BLOB την απόδοση και πώς ισορροπώ ταχύτητα‑μνήμη;**

Ναι. Η διατήρηση των BLOB στη μνήμη μεγιστοποιεί την ταχύτητα αλλά αυξάνει την κατανάλωση RAM· η μείωση του ορίου μνήμης μεταφέρει περισσότερη δουλειά σε προσωρινά αρχεία, μειώνοντας τη RAM με κόστος πρόσθετων I/O. Χρησιμοποιήστε τη μέθοδο [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) για να βρείτε τη σωστή ισορροπία για το φορτίο και το περιβάλλον σας.

**Βοηθούν οι επιλογές BLOB στο άνοιγμα εξαιρετικά μεγάλων παρουσιάσεων (π.χ. gigabytes);**

Ναι. Τα [BlobManagementOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/blobmanagementoptions/) είναι σχεδιασμένα για τέτοια σενάρια: η ενεργοποίηση των προσωρινών αρχείων και η χρήση κλειδώματος πηγής μπορούν να μειώσουν σημαντικά τη μέγιστη χρήση RAM και να σταθεροποιήσουν την επεξεργασία πολύ μεγάλων συλλογών.

**Μπορώ να χρησιμοποιήσω πολιτικές BLOB όταν φορτώνω από ροές αντί για αρχεία δίσκου;**

Ναι. Οι ίδιες κανόνες ισχύουν για τις ροές: η παρουσίαση μπορεί να κατέχει και να κλειδώνει την είσοδο ροής (ανάλογα με τη λειτουργία κλειδώματος) και τα προσωρινά αρχεία χρησιμοποιούνται όταν επιτρέπεται, διατηρώντας τη χρήση μνήμης προβλέψιμη κατά την επεξεργασία.