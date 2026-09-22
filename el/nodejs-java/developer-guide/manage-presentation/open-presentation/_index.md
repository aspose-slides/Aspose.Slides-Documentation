---
title: Άνοιγμα παρουσιάσεων σε JavaScript
linktitle: Άνοιγμα παρουσίασης
type: docs
weight: 20
url: /el/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε JavaScript, να παρέχετε κωδικούς πρόσβασης ανοίγματος, να ελέγχετε τη φόρτωση πόρων και να μειώσετε τη χρήση μνήμης με το Aspose.Slides για Node.js μέσω Java."
---
## **Εισαγωγή**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/el/nodejs-java/) μπορεί να φορτώσει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Αφού φορτωθεί μια παρουσίαση, μπορείτε να εξετάσετε τη δομή της, να επεξεργαστείτε τις διαφάνειες, να διαχειριστείτε τους πόρους και να την αποθηκεύσετε στο αρχικό ή σε άλλο υποστηριζόμενο φορμάτ.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να δώσετε κωδικό πρόσβασης ανοίγματος, να κρατήσετε μεγάλα δυαδικά αντικείμενα εκτός μνήμης Node.js, να ελέγξετε εξωτερικούς πόρους ή να παραλείψετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα παρουσιάσεων**

Μετά τη φόρτωση ενός αρχείου ή ροής, μπορείτε να [καθορίσετε το αρχικό φορμάτ παρουσίασης](/slides/el/nodejs-java/detect-presentation-source-format/) για να επιλέξετε πώς η εφαρμογή σας θα το επεξεργαστεί.

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Αποδεσμεύστε την παρουσίαση μετά τη χρήση ώστε τα handles αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι να απελευθερώνονται άμεσα.

Το παρακάτω παράδειγμα JavaScript δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών της:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Άνοιγμα παρουσιάσεων με προστασία κωδικού**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε ολόκληρη την παρουσίαση, περάστε τον σωστό κωδικό στην [LoadOptions.setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setPassword) και δώστε τις επιλογές στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Η φόρτωση αποτυγχάνει όταν λείπει ή είναι λανθασμένος ο κωδικός.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Για εντοπισμό, επικύρωση και ροές εργασίας κρυπτογράφησης κωδικού, δείτε την ενότητα [Password-Protect Presentations](/slides/el/nodejs-java/password-protected-presentation/). Εάν μια κρυπτογραφημένη παρουσίαση αποθηκεύτηκε σκόπιμα με δημόσια ιδιότητες εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό πρόσβασης· δείτε [Manage Presentation Properties](/slides/el/nodejs-java/presentation-properties/).

## **Άνοιγμα μεγάλων παρουσιάσεων**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) επιστρέφει επιλογές που ελέγχουν τον τρόπο με τον οποίο το Aspose.Slides διαχειρίζεται μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχο και βίντεο. Μπορείτε να διατηρήσετε το πηγαίο αρχείο κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε το μέγεθος των δεδομένων BLOB που διατηρούνται στη μνήμη.

Το παρακάτω κώδικα JavaScript δείχνει τη φόρτωση μιας μεγάλης παρουσίασης (π.χ., 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Με το [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked), το πηγαίο αρχείο παραμένει κλειδωμένο μέχρι να αποδεσμευθεί η παρουσίαση. Μην μετακινείτε, αντικαθιστάτε ή διαγράψετε το πηγαίο αρχείο όσο η παρουσίαση είναι ενεργή.

Το Aspose.Slides μπορεί να αντιγράψει τα περιεχόμενα μιας ροής εισόδου κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, η διαδρομή αρχείου είναι γενικά πιο αποδοτική από τη ροή. Δείτε την ενότητα [Manage BLOBs](/slides/el/nodejs-java/manage-blob/) για πρόσθετες επιλογές αποθήκευσης και διαχείρισης μνήμης.
{{% /alert %}}

## **Έλεγχος εξωτερικών πόρων**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) δέχεται μια υλοποίηση του [IResourceLoadingCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iresourceloadingcallback/). Η κλήση μπορεί να παρέχει αντικατάσταση δεδομένων, να ανακατευθύνει έναν πόρο, να χρησιμοποιήσει τον προεπιλεγμένο φορτωτή ή να παραλείψει τον πόρο. Αυτό είναι χρήσιμο όταν οι παρουσιάσεις περιέχουν εξωτερικές εικόνες που πρέπει να επιλυθούν σύμφωνα με κανόνες ασφαλείας ή αποθήκευσης ειδικά για την εφαρμογή.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Φόρτωση παρουσιάσεων χωρίς ενσωματωμένα δυαδικά αντικείμενα**

Μια παρουσίαση μπορεί να περιέχει ενσωματωμένα δυαδικά δεδομένα που μια εφαρμογή δεν χρειάζεται ή δεν θέλει να διατηρήσει. Παραδείγματα περιλαμβάνουν:

- έργα VBA, διαθέσιμα μέσω [Presentation.getVbaProject](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getVbaProject);
- ενσωματωμένα δεδομένα OLE, διαθέσιμα μέσω [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω [Control.getActiveXControlBinary](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Ορίστε [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) σε `true` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το εξαγμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα payloads, αλλά δεν αποτελεί ολοκληρωμένο σύστημα ανίχνευσης κακόβουλου λογισμικού ή εξυγίανσης περιεχομένου.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να διαπιστώ ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχτεί;**

Το Aspose.Slides ρίχνει εξαίρεση ανάλυσης ή μορφής κατά τη φόρτωση. Διαχειριστείτε αυτήν την αποτυχία ξεχωριστά από σφάλμα λανθασμένου κωδικού πρόσβασης ώστε η εφαρμογή να μπορεί να αναφέρει την αιτία με ακρίβεια.

**Τι συμβαίνει αν λείπουν οι απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί ακόμη να φορτωθεί, αλλά η απόδοση και η εξαγωγή μπορεί να υποκαταστήσουν γραμματοσειρές. Μπορείτε να [ρυθμίσετε την αντικατάσταση γραμματοσειρών](/slides/el/nodejs-java/font-substitution/) ή να [παρέχετε προσαρμοσμένες γραμματοσειρές](/slides/el/nodejs-java/custom-font/) για πιο προβλέψιμο αποτέλεσμα.

**Φορτώνει η φόρτωση μιας παρουσίασης επίσης τα ενσωματωμένα μέσα;**

Τα ενσωματωμένα ήχο και βίντεο γίνονται διαθέσιμα μέσω του αντικειμενοστραφούς μοντέλου της παρουσίασης. Οι εξωτερικοί πόροι επιλύονται σύμφωνα με τη ρυθμισμένη συμπεριφορά φόρτωσης πόρων και μπορεί να μην είναι διαθέσιμοι εάν οι τοποθεσίες τους δεν είναι προσβάσιμες.