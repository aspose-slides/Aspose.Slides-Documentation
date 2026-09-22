---
title: "Άνοιγμα Παρουσιάσεων στο Android"
linktitle: "Άνοιγμα Παρουσίασης"
type: docs
weight: 20
url: /el/androidjava/open-presentation/
keywords:
- "άνοιγμα PowerPoint"
- "άνοιγμα παρουσίασης"
- "άνοιγμα PPTX"
- "άνοιγμα PPT"
- "άνοιγμα ODP"
- "φόρτωση παρουσίασης"
- "φόρτωση PPTX"
- "φόρτωση PPT"
- "φόρτωση ODP"
- "προστατευμένη παρουσίαση"
- "μεγάλη παρουσίαση"
- "εξωτερικός πόρος"
- "δυαδικό αντικείμενο"
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε Android, να παρέχετε κωδικούς πρόσβασης ανοίγματος, να ελέγχετε τη φόρτωση πόρων και να μειώνετε τη χρήση μνήμης με το Aspose.Slides για Android μέσω Java."
---
## **Εισαγωγή**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/el/androidjava/) μπορεί να φορτώνει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Μετά τη φόρτωση μιας παρουσίασης, μπορείτε να επιθεωρείτε τη δομή της, να επεξεργάζεστε διαφάνειες, να διαχειρίζεστε πόρους και να την αποθηκεύετε στην αρχική ή σε άλλη υποστηριζόμενη μορφή.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να παρέχετε κωδικό πρόσβασης ανοίγματος, να διατηρείτε μεγάλα δυαδικά αντικείμενα εκτός της heap μνήμης της Java, να ελέγχετε εξωτερικούς πόρους ή να παραλείπετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα Παρουσιάσεων**

Μετά τη φόρτωση ενός αρχείου ή ροής, μπορείτε να [καθορίσετε την αρχική μορφή παρουσίασης](/slides/el/androidjava/detect-presentation-source-format/) για να επιλέξετε πώς η εφαρμογή σας θα την επεξεργαστεί.

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/). Αποδεσμεύστε την παρουσίαση μετά τη χρήση ώστε οι χειριστές αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι να απελευθερωθούν αμέσως.

Το ακόλουθο παράδειγμα Java δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό διαφανειών της:

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

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε πλήρως την παρουσίαση, περάστε τον σωστό κωδικό στην μέθοδο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) και παρέχετε τις επιλογές στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/). Η φόρτωση αποτυγχάνει όταν λείπει ή είναι λανθασμένος ο κωδικός.

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

Για εντοπισμό κωδικού, επικύρωση και εργασίες κρυπτογράφησης, δείτε το [Password‑Protect Presentations](/slides/el/androidjava/password-protected-presentation/). Αν μια κρυπτογραφημένη παρουσίαση αποθηκεύτηκε σκόπιμα με δημόσια ιδιότητες εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό· δείτε το [Manage Presentation Properties](/slides/el/androidjava/presentation-properties/).

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) επιστρέφει επιλογές που ελέγχουν πώς το Aspose.Slides διαχειρίζεται μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχο και βίντεο. Μπορείτε να κρατήσετε το αρχικό αρχείο κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε την ποσότητα των δεδομένων BLOB που παραμένουν στη μνήμη.

Το ακόλουθο κώδικα Java δείχνει τη φόρτωση μιας μεγάλης παρουσίασης (π.χ., 2 GB):

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
Με το [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked), το αρχικό αρχείο παραμένει κλειδωμένο μέχρι να αποδεσμευθεί το παράδειγμα παρουσίασης. Μην μετακινείτε, αντικαθιστείτε ή διαγράψετε το αρχικό αρχείο ενώ το αντίγραφο είναι ενεργό.

Το Aspose.Slides ενδέχεται να αντιγράψει το περιεχόμενο μιας εισαγόμενης ροής κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, μια διαδρομή αρχείου είναι γενικά πιο αποδοτική από μια ροή. Δείτε το [Manage BLOBs](/slides/el/androidjava/manage-blob/) για επιπλέον επιλογές αποθήκευσης και διαχείρισης μνήμης.
{{% /alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) δέχεται μια υλοποίηση του [IResourceLoadingCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iresourceloadingcallback/). Η κλήση μπορεί να παρέχει δεδομένα αντικατάστασης, να ανακατευθύνει έναν πόρο, να χρησιμοποιήσει τον προεπιλεγμένο φορτωτή ή να παραλείψει τον πόρο. Αυτό είναι χρήσιμο όταν οι παρουσιάσεις περιέχουν εξωτερικές εικόνες που πρέπει να λυθούν σύμφωνα με κανόνες ασφάλειας ή αποθήκευσης της εφαρμογής.

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

- έργα VBA, διαθέσιμα μέσω [IPresentation.getVbaProject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- ενσωματωμένα δεδομένα OLE, διαθέσιμα μέσω [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Ορίστε το [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) σε `true` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα πακέτα, αλλά δεν αποτελεί πλήρες σύστημα ανίχνευσης κακόβουλου λογισμικού ή καθαρισμού περιεχομένου.

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

**Πώς μπορώ να καταλάβω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοίξει;**

Το Aspose.Slides πετάει εξαίρεση解析或格式错误 κατά τη φόρτωση. Χειριστείτε αυτήν την αποτυχία ξεχωριστά από σφάλμα λανθασμένου κωδικού πρόσβασης ώστε η εφαρμογή να μπορεί να αναφέρει με ακρίβεια την αιτία.

**Τι συμβαίνει αν λείπουν οι απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί ακόμη να φορτωθεί, αλλά η απόδοση και η εξαγωγή μπορεί να αντικαταστήσουν τις γραμματοσειρές. Μπορείτε να [configure font substitution](/slides/el/androidjava/font-substitution/) ή να [provide custom fonts](/slides/el/androidjava/custom-font/) για πιο προβλέψιμο αποτέλεσμα.

**Η φόρτωση μιας παρουσίασης φορτώνει επίσης τα ενσωματωμένα μέσα;**

Τα ενσωματωμένα ήχος και βίντεο γίνονται διαθέσιμα μέσω του μοντέλου αντικειμένων της παρουσίασης. Οι εξωτερικοί πόροι λύνουν σύμφωνα με τη ρυθμισμένη συμπεριφορά φόρτωσης πόρων και μπορεί να μην είναι διαθέσιμοι εάν οι θέσεις τους δεν είναι προσβάσιμες.