---
title: Άνοιγμα Παρουσιάσεων σε Java
linktitle: Άνοιγμα Παρουσίασης
type: docs
weight: 20
url: /el/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε Java, να παρέχετε κωδικούς πρόσβασης ανοίγματος, να ελέγχετε τη φόρτωση πόρων και να μειώνετε τη χρήση μνήμης με το Aspose.Slides για Java."
---
## **Εισαγωγή**

[Aspose.Slides for Java](https://products.aspose.com/slides/el/java/) μπορεί να φορτώσει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Μετά τη φόρτωση μιας παρουσίασης, μπορείτε να εξετάσετε τη δομή της, να επεξεργαστείτε τις διαφάνειες, να διαχειριστείτε πόρους και να την αποθηκεύσετε στο αρχικό ή σε άλλο υποστηριζόμενο μορφότυπο.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να καθορίσετε έναν κωδικό πρόσβασης ανοίγματος, να διατηρήσετε μεγάλα δυαδικά αντικείμενα εκτός μνήμης Java heap, να ελέγχετε εξωτερικούς πόρους ή να παραλείψετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα Παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στην κατασκευάστρια μέθοδο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Αποδεσμεύστε την παρουσίαση μετά τη χρήση ώστε να απελευθερωθούν άμεσα τα χειριστήρια αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Άνοιγμα Παρουσιάσεων με Κωδικό Πρόσβασης**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε ολόκληρη την παρουσίαση, περάστε τον σωστό κωδικό στην μέθοδο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) και παραχωρήστε τις επιλογές στην κατασκευάστρια μέθοδο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Η φόρτωση αποτυγχάνει όταν λείπει ή είναι λανθασμένος ο κωδικός.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Για ανίχνευση κωδικού, επικύρωση και ροές κρυπτογράφησης, δείτε [Password-Protect Presentations](/slides/el/java/password-protected-presentation/). Εάν μια κρυπτογραφημένη παρουσίαση έχει αποθηκευτεί εκούσια με δημόσια ιδιότητα εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό· δείτε [Manage Presentation Properties](/slides/el/java/presentation-properties/).

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) επιστρέφει επιλογές που ελέγχουν πώς το Aspose.Slides διαχειρίζεται μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχο και βίντεο. Μπορείτε να κρατήσετε το πηγαίο αρχείο κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε την ποσότητα των δεδομένων BLOB που διατηρούνται στη μνήμη.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Σημείωση" %}}
Με την επιλογή [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked), το πηγαίο αρχείο παραμένει κλειδωμένο μέχρι να αποδεσμευθεί η παρουσίαση. Μην μετακινείτε, αντικαθιστάτε ή διαγράφετε το πηγαίο αρχείο ενώ αυτό το αντικείμενο είναι ενεργό.

Το Aspose.Slides ενδέχεται να αντιγράψει τα περιεχόμενα μιας εισαγόμενης ροής κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, μια διαδρομή αρχείου είναι γενικά πιο αποδοτική από μια ροή. Δείτε [Manage BLOBs](/slides/el/java/manage-blob/) για πρόσθετες επιλογές αποθήκευσης και διαχείρισης μνήμης.
{{% /alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) δέχεται μια υλοποίηση του [IResourceLoadingCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iresourceloadingcallback/). Η κλήση μπορεί να παρέχει αντικαταστατικά δεδομένα, να ανακατευθύνει έναν πόρο, να χρησιμοποιήσει τον προεπιλεγμένο φορτωτή ή να παραλείψει τον πόρο. Αυτό είναι χρήσιμο όταν οι παρουσιάσεις περιέχουν εξωτερικές εικόνες που πρέπει να λυθούν σύμφωνα με τους κανόνες ασφαλείας ή αποθήκευσης της εφαρμογής.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Φόρτωση Παρουσιάσεων χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση μπορεί να περιέχει ενσωματωμένα δυαδικά δεδομένα που μια εφαρμογή δεν χρειάζεται ή δεν επιθυμεί να διατηρήσει. Παραδείγματα περιλαμβάνουν:

- Έργα VBA, διαθέσιμα μέσω [IPresentation.getVbaProject](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getVbaProject--);
- ενσωματωμένα δεδομένα OLE, διαθέσιμα μέσω [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/el/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Ορίστε [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) σε `true` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητες ενσωματωμένες επιθέσεις, αλλά δεν αποτελεί πλήρες σύστημα ανίχνευσης κακόβουλου λογισμικού ή εξάλειψης περιεχομένου.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχθεί;**

Το Aspose.Slides εγείρει εξαίρεση ανάλυσης ή μορφοποίησης κατά τη φόρτωση. Χειριστείτε αυτήν την αποτυχία ξεχωριστά από σφάλμα λανθασμένου κωδικού πρόσβασης ώστε η εφαρμογή να μπορεί να αναφέρει ακριβώς την αιτία.

**Τι συμβαίνει εάν λείπουν οι απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί ακόμη να φορτωθεί, αλλά η απόδοση και η εξαγωγή ενδέχεται να αντικαταστήσουν τις γραμματοσειρές. Μπορείτε να [configure font substitution](/slides/el/java/font-substitution/) ή να [provide custom fonts](/slides/el/java/custom-font/) για πιο προβλέψιμη έξοδο.

**Φορτώνεται επίσης το ενσωματωμένο πολυμέσο μιας παρουσίασης κατά τη φόρτωση;**

Τα ενσωματωμένα ήχο και βίντεο γίνονται διαθέσιμα μέσω του αντικειμενικού μοντέλου της παρουσίασης. Οι εξωτερικοί πόροι λογοδοτούνται σύμφωνα με τη ρυθμισμένη συμπεριφορά φόρτωσης πόρων και ενδέχεται να μην είναι διαθέσιμοι εάν οι τοποθεσίες τους δεν είναι προσβάσιμες.