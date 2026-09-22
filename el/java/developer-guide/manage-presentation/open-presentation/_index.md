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
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε Java, να παρέχετε κωδικούς πρόσβασης ανοίγματος, να ελέγχετε τη φόρτωση πόρων και να μειώσετε τη χρήση μνήμης με το Aspose.Slides για Java."
---
## **Εισαγωγή**

[Aspose.Slides for Java](https://products.aspose.com/slides/el/java/) μπορεί να φορτώνει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Αφού φορτωθεί μια παρουσίαση, μπορείτε να εξετάσετε τη δομή της, να επεξεργαστείτε τις διαφάνειες, να διαχειριστείτε τους πόρους και να την αποθηκεύσετε στην αρχική ή σε άλλη υποστηριζόμενη μορφή.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να παρέχετε έναν κωδικό πρόσβασης ανοίγματος, να διατηρείτε μεγάλα δυαδικά αντικείμενα εκτός της μνήμης Java heap, να ελέγχετε εξωτερικούς πόρους ή να παραλείψετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα Παρουσιάσεων**

Μετά τη φόρτωση ενός αρχείου ή ροής, μπορείτε να [καθορίσετε την αρχική μορφή της παρουσίασης](/slides/el/java/detect-presentation-source-format/) ώστε να επιλέξετε πώς θα την επεξεργαστεί η εφαρμογή σας.

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή αρχείου στην κατασκευή [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Αποδεσμεύστε την παρουσίαση μετά τη χρήση ώστε οι χειριστές αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι να απελευθερωθούν άμεσα.

Το παρακάτω παράδειγμα Java δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών της:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Άνοιγμα Παρουσιάσεων με Προστασία Κωδικού**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε ολόκληρη την παρουσίαση, περάστε τον σωστό κωδικό στην μέθοδο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) και παρέχετε τις επιλογές στην κατασκευή [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Η φόρτωση αποτυγχάνει εάν ο κωδικός λείπει ή είναι λανθασμένος.

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

Για διαδικασίες ανίχνευσης, επαλήθευσης και κρυπτογράφησης κωδικού πρόσβασης, δείτε το [Προστασία Παρουσιάσεων με Κωδικό](/slides/el/java/password-protected-presentation/). Εάν μια κρυπτογραφημένη παρουσίαση αποθηκεύτηκε σκόπιμα με δημόσια χαρακτηριστικά εγγράφου, αυτά τα χαρακτηριστικά μπορούν να διαβαστούν χωρίς κωδικό πρόσβασης· δείτε το [Διαχείριση Ιδιοτήτων Παρουσίασης](/slides/el/java/presentation-properties/).

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

Η μέθοδος [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) επιστρέφει επιλογές που ελέγχουν πώς το Aspose.Slides διαχειρίζεται μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχο και βίντεο. Μπορείτε να κρατήσετε το αρχείο προέλευσης κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε την ποσότητα των δεδομένων BLOB που διατηρούνται στη μνήμη.

Το παρακάτω κώδικα Java δείχνει τη φόρτωση μιας μεγάλης παρουσίασης (π.χ., 2 GB):

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

{{% alert color="info" title="Note" %}}
Με το [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked), το αρχείο προέλευσης παραμένει κλειδωμένο μέχρι να αποδεσμευθεί το αντικείμενο παρουσίασης. Μην μετακινείτε, αντικαθιστάτε ή διαγράφετε το αρχείο προέλευσης όσο αυτό το αντικείμενο είναι ενεργό.

Το Aspose.Slides μπορεί να αντιγράψει το περιεχόμενο μιας ροής εισόδου κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, η διαδρομή αρχείου είναι γενικά πιο αποδοτική από τη ροή. Δείτε το [Manage BLOBs](/slides/el/java/manage-blob/) για πρόσθετες επιλογές αποθήκευσης και διαχείρισης μνήμης.
{{% /alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

Η μέθοδος [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) δέχεται μια υλοποίηση του [IResourceLoadingCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iresourceloadingcallback/). Η κλήση μπορεί να παρέχει αντικαταστατικά δεδομένα, να ανακατευθύνει έναν πόρο, να χρησιμοποιήσει τον προεπιλεγμένο φορτωτή ή να παραλείψει τον πόρο. Αυτό είναι χρήσιμο όταν οι παρουσιάσεις περιέχουν εξωτερικές εικόνες που πρέπει να επιλυθούν σύμφωνα με κανόνες ασφαλείας ή αποθήκευσης της εφαρμογής.

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

Μια παρουσίαση μπορεί να περιέχει ενσωματωμένα δυαδικά δεδομένα που μια εφαρμογή δεν χρειάζεται ή δεν θέλει να διατηρήσει. Παραδείγματα περιλαμβάνουν:

- έργα VBA, διαθέσιμα μέσω του [IPresentation.getVbaProject](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getVbaProject--);
- ενσωματωμένα δεδομένα OLE, διαθέσιμα μέσω του [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω του [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/el/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Ορίστε το [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) σε `true` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα φορτία, αλλά δεν αποτελεί πλήρες σύστημα ανίχνευσης κακόλογου ή καθαρισμού περιεχομένου.

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

**Πώς μπορώ να γνωρίζω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχτεί;**

Το Aspose.Slides εγείρει εξαίρεση ανάλυσης ή μορφής κατά τη φόρτωση. Διαχειριστείτε αυτήν την αποτυχία ξεχωριστά από σφάλμα λανθασμένου κωδικού πρόσβασης, ώστε η εφαρμογή να μπορεί να αναφέρει την αιτία με ακρίβεια.

**Τι συμβαίνει εάν λείπουν οι απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί ακόμα να φορτωθεί, αλλά η απόδοση και η εξαγωγή ενδέχεται να αντικαταστήσουν τις γραμματοσειρές. Μπορείτε να [ρυθμίσετε την αντικατάσταση γραμματοσειρών](/slides/el/java/font-substitution/) ή να [παρέχετε προσαρμοσμένες γραμματοσειρές](/slides/el/java/custom-font/) για να κάνετε το αποτέλεσμα πιο προβλέψιμο.

**Η φόρτωση μιας παρουσίασης φορτώνει επίσης τα ενσωματωμένα μέσα;**

Τα ενσωματωμένα ηχητικά και βίντεο γίνονται διαθέσιμα μέσω του αντικειμενοστραφούς μοντέλου της παρουσίασης. Οι εξωτερικοί πόροι επιλύονται σύμφωνα με τη ρυθμισμένη συμπεριφορά φόρτωσης πόρων και ενδέχεται να μην είναι διαθέσιμοι εάν δεν είναι δυνατή η πρόσβαση στις τοποθεσίες τους.