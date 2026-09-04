---
title: Άνοιγμα Παρουσιάσεων σε Android
linktitle: Άνοιγμα Παρουσίασης
type: docs
weight: 20
url: /el/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε Android, να παρέχετε κωδικούς πρόσβασης ανοίγματος, να ελέγχετε τη φόρτωση πόρων και να μειώνετε τη χρήση μνήμης με το Aspose.Slides για Android μέσω Java."
---
## **Εισαγωγή**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/el/androidjava/) μπορεί να φορτώσει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Αφού φορτωθεί μια παρουσίαση, μπορείτε να επιθεωρήσετε τη δομή της, να επεξεργαστείτε τις διαφάνειες, να διαχειριστείτε τους πόρους και να την αποθηκεύσετε στην αρχική ή σε άλλη υποστηριζόμενη μορφή.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να παρέχετε κωδικό πρόσβασης ανοίγματος, να κρατήσετε μεγάλα δυαδικά αντικείμενα εκτός της μνήμης heap της Java, να ελέγξετε εξωτερικούς πόρους ή να παραλείψετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα Παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/). Αποδεσμεύστε την παρουσίαση μετά τη χρήση ώστε οι χειριστές αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι να απελευθερωθούν άμεσα.

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

## **Άνοιγμα Παρουσιάσεων με Κωδικό Πρόσβασης**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε ολόκληρη την παρουσίαση, περάστε τον σωστό κωδικό πρόσβασης στην μέθοδο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) και παρέχετε τις επιλογές στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/). Η φόρτωση αποτυγχάνει όταν λείπει ή είναι λανθασμένος ο κωδικός.

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

Για ανίχνευση κωδικών, επικύρωση και ροές εργασίας κρυπτογράφησης, δείτε [Password-Protect Presentations](/slides/el/androidjava/password-protected-presentation/). Εάν μια κρυπτογραφημένη παρουσίαση αποθηκεύτηκε σκόπιμα με δημόσια ιδιότητα εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό πρόσβασης· δείτε [Manage Presentation Properties](/slides/el/androidjava/presentation-properties/).

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) επιστρέφει επιλογές που ελέγχουν πώς το Aspose.Slides διαχειρίζεται μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχο και βίντεο. Μπορείτε να κρατήσετε το πηγαίο αρχείο κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε το ποσό των δεδομένων BLOB που διατηρούνται στη μνήμη.

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

Με τη χρήση του [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked), το πηγαίο αρχείο παραμένει κλειδωμένο μέχρι να αποδεσμευτεί η παρουσίαση. Μην μετακινείτε, αντικαθιστάτε ή διαγράφετε το πηγαίο αρχείο ενώ το αντικείμενο είναι ζωντανό.

Το Aspose.Slides μπορεί να αντιγράψει τα περιεχόμενα μιας εισόδου ροής κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, η διαδρομή αρχείου είναι γενικά πιο αποδοτική από μια ροή. Δείτε το [Manage BLOBs](/slides/el/androidjava/manage-blob/) για πρόσθετες επιλογές αποθήκευσης και διαχείρισης μνήμης.

{{% /alert %}}

## **Διαχείριση Εξωτερικών Πόρων**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) δέχεται μια υλοποίηση του [IResourceLoadingCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iresourceloadingcallback/). Η κλήση μπορεί να παρέχει δεδομένα αντικατάστασης, να ανακατευθύνει έναν πόρο, να χρησιμοποιήσει τον προεπιλεγμένο φορτωτή ή να παραλείψει τον πόρο. Αυτό είναι χρήσιμο όταν οι παρουσιάσεις περιέχουν εξωτερικές εικόνες που πρέπει να λυθούν σύμφωνα με ειδικούς κανόνες ασφαλείας ή αποθήκευσης της εφαρμογής.

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

- έργα VBA, διαθέσιμα μέσω του [IPresentation.getVbaProject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- ενσωματωμένα δεδομένα OLE, διαθέσιμα μέσω του [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω του [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Ορίστε το [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) σε `true` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα φορτία, αλλά δεν αποτελεί πλήρες σύστημα ανίχνευσης κακόβουλου λογισμικού ή καθαρισμού περιεχομένου.

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

## **ΣΥΝΑΝΤΗΣΕΙΣ (FAQ)**

**Πώς μπορώ να εξακριβώσω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχθεί;**

Το Aspose.Slides ρίχνει εξαίρεση ανάλυσης ή μορφής κατά τη φόρτωση. Χειριστείτε αυτήν την αποτυχία ξεχωριστά από το σφάλμα λανθασμένου κωδικού πρόσβασης ώστε η εφαρμογή να μπορεί να αναφέρει την αιτία με ακρίβεια.

**Τι συμβαίνει αν λείπουν απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί ακόμη να φορτωθεί, αλλά η απόδοση και η εξαγωγή μπορεί να αντικαταστήσουν τις γραμματοσειρές. Μπορείτε να [ρυθμίσετε αντικατάσταση γραμματοσειρών](/slides/el/androidjava/font-substitution/) ή [παρέχετε προσαρμοσμένες γραμματοσειρές](/slides/el/androidjava/custom-font/) για πιο προβλέψιμα αποτελέσματα.

**Φορτώνεται επίσης τα ενσωματωμένα μέσα κατά τη φόρτωση της παρουσίασης;**

Τα ενσωματωμένα ήχο και βίντεο γίνονται προσβάσιμα μέσω του αντικειμενοστραφούς μοντέλου της παρουσίασης. Οι εξωτερικοί πόροι επιλύονται σύμφωνα με τη ρυθμισμένη συμπεριφορά φόρτωσης πόρων και μπορεί να μη είναι διαθέσιμοι εάν οι τοποθεσίες τους δεν είναι προσβάσιμες.