---
title: Άνοιγμα Παρουσιάσεων σε JavaScript
linktitle: Άνοιγμα Παρουσίασης
type: docs
weight: 20
url: /el/nodejs-java/open-presentation/
keywords:
- άνοιγμα PowerPoint
- άνοιγμα OpenDocument
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
description: "Άνοιγμα παρουσιάσεων PowerPoint (.pptx, .ppt) και OpenDocument (.odp) με απόλυτη ευκολία χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java—γρήγορο, αξιόπιστο, πλήρως εξοπλισμένο."
---
## **Εισαγωγή**

Πέρα από τη δημιουργία παρουσιάσεων PowerPoint από το μηδέν, το Aspose.Slides σάς επιτρέπει επίσης να ανοίγετε υπάρχουσες παρουσιάσεις. Αφού φορτώσετε μια παρουσίαση, μπορείτε να ανακτήσετε πληροφορίες σχετικά με αυτήν, να επεξεργαστείτε το περιεχόμενο των διαφάνειων, να προσθέσετε νέες διαφάνειες, να αφαιρέσετε υπάρχουσες και πολλά άλλα.

## **Άνοιγμα Παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και περάστε τη διαδρομή του αρχείου στον κατασκευαστή του.

Το παρακάτω παράδειγμα JavaScript δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών της:

```js
// Δημιουργήστε το αντικείμενο της κλάσης Presentation και περάστε τη διαδρομή ενός αρχείου στον κατασκευαστή του.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Εκτυπώστε το συνολικό αριθμό διαφανειών στην παρουσίαση.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Άνοιγμα Παρουσιάσεων με Κωδικό Πρόσβασης**

Όταν χρειάζεται να ανοίξετε μια παρουσίαση με κωδικό προστασίας, περάστε τον κωδικό μέσω της μεθόδου [setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setPassword) της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/) για να την αποκρυπτογραφήσετε και να τη φορτώσετε. Το παρακάτω κώδικας JavaScript δείχνει αυτή τη λειτουργία:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Εκτελέστε λειτουργίες στην αποκρυπτογραφημένη παρουσίαση.
} finally {
    presentation.dispose();
}
```

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

Το Aspose.Slides προσφέρει επιλογές—ιδιαίτερα τη μέθοδο [getBlobManagementOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) στην κλάση [LoadOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/)—για να σας βοηθήσουν να φορτώσετε μεγάλες παρουσιάσεις.

Το παρακάτω κώδικας JavaScript δείχνει τη φόρτωση μιας μεγάλης παρουσίασης (π.χ., 2 GB):

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Επιλέξτε τη συμπεριφορά KeepLocked—το αρχείο της παρουσίασης θα παραμείνει κλειδωμένο για τη διάρκεια του
// του αντικειμένου Presentation, αλλά δεν χρειάζεται να φορτωθεί στη μνήμη ή να αντιγραφεί σε προσωρινό αρχείο.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // Η μεγάλη παρουσίαση έχει φορτωθεί και μπορεί να χρησιμοποιηθεί, ενώ η κατανάλωση μνήμης παραμένει χαμηλή.
    
    // Κάντε αλλαγές στην παρουσίαση.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Αποθηκεύστε την παρουσίαση σε άλλο αρχείο. Η κατανάλωση μνήμης παραμένει χαμηλή κατά τη διάρκεια αυτής της λειτουργίας.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Μην το κάνετε αυτό! Θα προκληθεί εξαίρεση I/O επειδή το αρχείο είναι κλειδωμένο μέχρι να διαγραφεί το αντικείμενο παρουσίασης.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Είναι εντάξει να το κάνετε εδώ. Το αρχείο προέλευσης δεν είναι πλέον κλειδωμένο από το αντικείμενο παρουσίασης.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
Για να ξεπεράσετε ορισμένους περιορισμούς κατά τη χρήση ροών, το Aspose.Slides ενδέχεται να αντιγράψει τα περιεχόμενα μιας ροής. Η φόρτωση μιας μεγάλης παρουσίασης από ροή προκαλεί το αντίγραφο της παρουσίασης και μπορεί να επιβραδύνει τη φόρτωση. Συνεπώς, όταν χρειάζεται να φορτώσετε μια μεγάλη παρουσίαση, συνιστούμε ουσιαστικά να χρησιμοποιήσετε τη διαδρομή του αρχείου παρουσίασης αντί για ροή.

Κατά τη δημιουργία μιας παρουσίασης που περιέχει μεγάλα αντικείμενα (βίντεο, ήχο, εικόνες υψηλής ανάλυσης κ.λπ.), μπορείτε να χρησιμοποιήσετε τη [Διαχείριση BLOB](/slides/el/nodejs-java/manage-blob/) για να μειώσετε τη χρήση μνήμης.
{{%/alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

Το Aspose.Slides παρέχει τη διεπαφή [IResourceLoadingCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iresourceloadingcallback/) που σας επιτρέπει να διαχειρίζεστε εξωτερικούς πόρους. Το παρακάτω κώδικας JavaScript δείχνει πώς να χρησιμοποιήσετε τη διεπαφή `IResourceLoadingCallback`:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Φορτώστε μια εναλλακτική εικόνα.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Ορίστε ένα εναλλακτικό URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Παραλείψτε όλες τις άλλες εικόνες.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Φόρτωση Παρουσιάσεων Χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση PowerPoint μπορεί να περιέχει τους ακόλουθους τύπους ενσωματωμένων δυαδικών αντικειμένων:

- VBA project (προσιτό μέσω του [Presentation.getVbaProject](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getVbaProject));
- OLE object embedded data (προσιτό μέσω του [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ActiveX control binary data (προσιτό μέσω του [Control.getActiveXControlBinary](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Χρησιμοποιώντας τη μέθοδο [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), μπορείτε να φορτώσετε μια παρουσίαση χωρίς κανένα ενσωματωμένο δυαδικό αντικείμενο.

Αυτή η μέθοδος είναι χρήσιμη για την αφαίρεση ενδεχομένως κακόβουλου δυαδικού περιεχομένου. Το παρακάτω κώδικας JavaScript δείχνει πώς να φορτώσετε μια παρουσίαση χωρίς κανένα ενσωματωμένο δυαδικό περιεχόμενο:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Εκτελέστε λειτουργίες στην παρουσίαση.
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διαπιστώ ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχθεί;**

Θα λάβετε μια εξαίρεση ανάλυσης/επικύρωσης μορφής κατά τη φόρτωση. Συχνά τέτοια σφάλματα αναφέρουν μη έγκυρη δομή ZIP ή σπασμένες εγγραφές PowerPoint.

**Τι συμβαίνει αν λείπουν τα απαιτούμενα γραμματοσειρά όταν ανοίγετε;**

Το αρχείο θα ανοίξει, αλλά αργότερα η [απόδοση/εξαγωγή](/slides/el/nodejs-java/convert-presentation/) μπορεί να αντικαταστήσει τις γραμματοσειρές. [Διαμόρφωση αντικατάστασης γραμματοσειρών](/slides/el/nodejs-java/font-substitution/) ή [προσθήκη των απαιτούμενων γραμματοσειρών](/slides/el/nodejs-java/custom-font/) στο περιβάλλον εκτέλεσης.

**Τι γίνεται με τα ενσωματωμένα πολυμέσα (βίντεο/ήχος) κατά το άνοιγμα;**

Γίνονται διαθέσιμα ως πόροι της παρουσίασης. Εάν τα μέσα αναφέρονται μέσω εξωτερικών διαδρομών, βεβαιωθείτε ότι αυτές οι διαδρομές είναι προσβάσιμες στο περιβάλλον σας· διαφορετικά η [απόδοση/εξαγωγή](/slides/el/nodejs-java/convert-presentation/) μπορεί να παραλείψει τα μέσα.