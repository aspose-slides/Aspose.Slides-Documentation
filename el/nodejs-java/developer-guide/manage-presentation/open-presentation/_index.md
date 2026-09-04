---
title: Άνοιγμα Παρουσιάσεων σε JavaScript
linktitle: Άνοιγμα Παρουσίασης
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
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε JavaScript, να παρέχετε κωδικούς ανοίγματος, να ελέγχετε τη φόρτωση πόρων και να μειώνετε τη χρήση μνήμης με το Aspose.Slides για Node.js μέσω Java."
---
## **Εισαγωγή**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/el/nodejs-java/) μπορεί να φορτώσει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Αφού φορτωθεί μια παρουσίαση, μπορείτε να ελέγξετε τη δομή της, να επεξεργαστείτε τις διαφάνειες, να διαχειριστείτε τους πόρους και να την αποθηκεύσετε στην αρχική ή σε άλλη υποστηριζόμενη μορφή.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να παρέχετε κωδικό ανοίγματος, να κρατήσετε μεγάλα δυαδικά αντικείμενα εκτός μνήμης Node.js, να ελέγξετε εξωτερικούς πόρους ή να παραλείψετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα Παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Απορρίψτε (dispose) την παρουσίαση μετά τη χρήση ώστε οι χειριστές αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι να απελευθερωθούν άμεσα.

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

## **Άνοιγμα Παρουσιάσεων με Προστασία Κωδικού**

Ένας κωδικός ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε ολόκληρη την παρουσίαση, περάστε τον σωστό κωδικό στη μέθοδο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setPassword) και παρέχετε τις επιλογές στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Η φόρτωση αποτυγχάνει όταν λείπει ή είναι λανθασμένος ο κωδικός.

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

Για ανίχνευση κωδικού, επικύρωση και διαδικασίες κρυπτογράφησης, δείτε [Password‑Protect Presentations](/slides/el/nodejs-java/password-protected-presentation/). Εάν μια κρυπτογραφημένη παρουσίαση αποθηκεύτηκε σκόπιμα με δημόσια ιδιότητα εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό· δείτε [Manage Presentation Properties](/slides/el/nodejs-java/presentation-properties/).

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) επιστρέφει επιλογές που ελέγχουν πώς το Aspose.Slides διαχειρίζεται μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχο και βίντεο. Μπορείτε να κρατήσετε το αρχείο προέλευσης κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε το ποσό των δεδομένων BLOB που διατηρούνται στη μνήμη.

Το παρακάτω κομμάτι JavaScript δείχνει τη φόρτωση μιας μεγάλης παρουσίασης (π.χ., 2 GB):

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
Με το [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked), το αρχείο προέλευσης παραμένει κλειδωμένο μέχρι να απορριφθεί (dispose) η παρουσίαση. Μην μετακινήσετε, αντικαταστήσετε ή διαγράψετε το αρχείο προέλευσης ενώ το αντίστοιχο αντικείμενο είναι ενεργό.

Το Aspose.Slides ενδέχεται να αντιγράψει τα περιεχόμενα μιας ροής εισόδου κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, η διαδρομή αρχείου είναι γενικά πιο αποδοτική από τη ροή. Δείτε το [Manage BLOBs](/slides/el/nodejs-java/manage-blob/) για επιπλέον επιλογές αποθήκευσης και διαχείρισης μνήμης.
{{% /alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) δέχεται μια υλοποίηση του [IResourceLoadingCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iresourceloadingcallback/). Η κλήση μπορεί να παρέχει εναλλακτικά δεδομένα, να ανακατευθύνει έναν πόρο, να χρησιμοποιήσει τον προεπιλεγμένο φορτωτή ή να παραλείψει τον πόρο. Αυτό είναι χρήσιμο όταν οι παρουσιάσεις περιέχουν εξωτερικές εικόνες που πρέπει να επιλυθούν βάσει κανόνων ασφαλείας ή αποθήκευσης της εφαρμογής.

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

## **Φόρτωση Παρουσιάσεων χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση μπορεί να περιλαμβάνει ενσωματωμένα δυαδικά δεδομένα που μια εφαρμογή δεν χρειάζεται ή δεν θέλει να διατηρήσει. Παραδείγματα περιλαμβάνουν:

- έργα VBA, διαθέσιμα μέσω [Presentation.getVbaProject](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getVbaProject);
- ενσωματωμένα δεδομένα OLE, διαθέσιμα μέσω [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω [Control.getActiveXControlBinary](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Ορίστε [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) σε `true` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα payloads, αλλά δεν αποτελεί πλήρες σύστημα ανίχνευσης κακόβουλου λογισμικού ή καθαρισμού περιεχομένου.

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

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διαπιστώ ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοίξει;**

Το Aspose.Slides ρίχνει εξαίρεση ανάλυσης ή μορφής κατά τη φόρτωση. Διαχειριστείτε αυτήν την αποτυχία ξεχωριστά από σφάλμα λανθασμένου κωδικού ώστε η εφαρμογή να μπορεί να αναφέρει ακριβώς την αιτία.

**Τι συμβαίνει αν λείπουν απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί ακόμη να φορτωθεί, αλλά η απόδοση και η εξαγωγή ενδέχεται να υποκαταστήσουν τις γραμματοσειρές. Μπορείτε να [ρυθμίσετε την αντικατάσταση γραμματοσειρών](/slides/el/nodejs-java/font-substitution/) ή να [παρέχετε προσαρμοσμένες γραμματοσειρές](/slides/el/nodejs-java/custom-font/) για πιο προβλέψιμο αποτέλεσμα.

**Φορτώνει η φόρτωση μιας παρουσίασης επίσης τα ενσωματωμένα μέσα της;**

Τα ενσωματωμένα audio και video διατίθενται μέσω του μοντέλου αντικειμένου της παρουσίασης. Οι εξωτερικοί πόροι επιλύονται σύμφωνα με τη ρυθμισμένη συμπεριφορά φόρτωσης πόρων και μπορεί να μην είναι διαθέσιμοι εάν οι τοποθεσίες τους δεν είναι προσβάσιμες.