---
title: Διαχείριση Προειδοποιήσεων Παρουσίασης σε Node.js
type: docs
weight: 90
url: /el/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- κλήση προειδοποίησης
- πολιτική προειδοποίησης
- απώλεια δεδομένων
- διαφθορά πηγής
- ζήτημα συμβατότητας
- αντικατάσταση γραμματοσειράς
- ψηφιακή υπογραφή
- φόρτωση παρουσίασης
- απόδοση παρουσίασης
- μετατροπή παρουσίασης
- αποθήκευση παρουσίασης
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "Μάθετε πώς να συλλέγετε, κατηγοριοποιείτε και αντιδράτε σε προειδοποιήσεις κατά τη φόρτωση, απόδοση, μετατροπή και αποθήκευση παρουσιάσεων με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να αναφέρει επανορθώσιμα προβλήματα κατά τη φόρτωση, απόδοση, μετατροπή ή αποθήκευση μιας παρουσίασης. Παραδείγματα περιλαμβάνουν κατεστραμμένα αρχεία προέλευσης, περιεχόμενο που δεν μπορεί να διατηρηθεί, αντικατάσταση γραμματοσειράς και περιορισμούς του μορφότυπου προορισμού. Ένα callback προειδοποίησης επιτρέπει σε μια εφαρμογή να καταγράψει αυτές τις συνθήκες και να αποφασίσει αν η τρέχουσα ενέργεια μπορεί να συνεχιστεί.

Χρησιμοποιήστε `java.newProxy` για να υλοποιήσετε το [IWarningCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarningcallback/) Java interface σε JavaScript και εξετάστε τις τιμές [getWarningType](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/#getWarningType--) και [getDescription](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/#getDescription--) που παρέχονται μέσω του [IWarningInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/). Επιστρέψτε [ReturnAction.Continue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/returnaction/#Continue) για να αποδεχθείτε την προειδόηση ή [ReturnAction.Abort](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/returnaction/#Abort) για να διακόψετε τη λειτουργία.

Χρησιμοποιήστε [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) για προειδοποιήσεις που προκύπτουν κατά το άνοιγμα μιας παρουσίασης. Οι κλάσεις επιλογών απόδοσης και εξαγωγής κληρονομούν το [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), το οποίο λαμβάνει προειδοποιήσεις από την απόδοση διαφάνειας, τη μετατροπή και την αποθήκευση. Επειδή η προειδοποίηση από μόνη της δεν προσδιορίζει τη λειτουργία της εφαρμογής, συσχετίστε κάθε αντικείμενο callback με ένα στάδιο λειτουργίας όταν δημιουργείτε έναν συνδυασμένο αναφορά.

## **Προειδοποιήσεις και Εξαιρέσεις**

Μια προειδοποίηση περιγράφει μια κατάσταση από την οποία το Aspose.Slides μπορεί να ανακάμψει εάν το callback επιστρέψει `ReturnAction.Continue`. Μια εξαίρεση σημαίνει ότι η ζητούμενη λειτουργία δεν μπορεί να ολοκληρωθεί κανονικά· οι εξαιρέσεις δεν μετατρέπονται σε προειδοποιήσεις και δεν μπορούν να διαχειριστούν από πολιτική προειδοποίησης.

Η επιστροφή `ReturnAction.Abort` ζητά από τον διαχειριστή προειδοποιήσεων να τερματίσει τη τρέχουσα λειτουργία ρίχνοντας μια εξαίρεση. Η δημόσια εξαίρεση εξαρτάται από τη λειτουργία και το μορφότυπο παρουσίασης. Για παράδειγμα, η φόρτωση μπορεί να προκαλέσει ένα [PptxReadException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxreadexception/) ή [PptReadException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptreadexception/), ενώ η αποθήκευση ή εξαγωγή μπορεί να προκαλέσει ένα [PptxException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxexception/). Πιάστε το σφάλμα από τη γέφυρα Java στα όρια της λειτουργίας και χρησιμοποιήστε την αναφορά προειδοποιήσεων για να καθορίσετε εάν η πολιτική της εφαρμογής προκάλεσε τον τερματισμό αντί να βασίζεστε σε έναν τύπο εξαίρεσης ή μήνυμα. Το callback καταγράφει την προειδοποίηση πριν επιστρέψει `ReturnAction.Abort`, διασφαλίζοντας ότι ο λόγος παραμένει διαθέσιμος στην εφαρμογή.

## **Κατηγορίες Προειδοποιήσεων**

Η κλάση [WarningType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/warningtype/) παρέχει ακέραιες σταθερές για τις παρακάτω κατηγορίες:

| Warning type | Meaning | Typical policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | Η πηγαία παρουσίαση περιέχει φθορές που μπορούν να κάνουν ένα έγγραφο αποθηκευμένο στην αρχική μορφή αχρησιμοποίητο. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/warningtype/#DataLoss) | Κείμενο, γραφήματα, εικόνες ή άλλα δεδομένα μπορεί να λείπουν μετά τη φόρτωση ή αποθήκευση. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | Η παρουσίαση μπορεί να χάσει σημαντική μορφοποίηση. | Abort in strict validation mode; otherwise record and continue. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Μπορεί να εμφανιστεί περιορισμένη διαφορά μορφοποίησης. | Record for diagnostics and continue. |
| [CompatibilityIssue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Το αποτέλεσμα ενδέχεται να μην ανοίξει ή να λειτουργήσει σωστά σε ορισμένες εφαρμογές ή παλαιότερες εκδόσεις. | Log and continue unless compatibility is mandatory. |
| [UnexpectedContent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | Η πηγή περιέχει μη υποστηριζόμενο ή άγνωστο περιεχόμενο του οποίου η επίδραση ενδέχεται να μην είναι ακόμη γνωστή. | Record and continue, or treat as an error in a strict policy. |

Η κατηγορία θα πρέπει να καθορίζει την πολιτική λήψης απόφασης. Αποθηκεύστε την τιμή που επιστρέφεται από το [getDescription](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/#getDescription--) για διαγνωστικούς σκοπούς, αλλά μην βασίζεστε στη διατύπωσή της για λογική εφαρμογής, καθώς το κείμενο του μηνύματος μπορεί να διαφέρει μεταξύ σεναρίων προειδοποίησης και εκδόσεων προϊόντος.

## **Συλλογή και Κατηγοριοποίηση Προειδοποιήσεων**

Το παρακάτω παράδειγμα JavaScript χρησιμοποιεί μια αναφορά επιπέδου εφαρμογής για ολόκληρη τη διαδικασία επεξεργασίας. Ένα ξεχωριστό αντικείμενο callback ετικετοποιεί προειδοποιήσεις από φόρτωση, απόδοση, μετατροπή σε PDF και αποθήκευση PPTX. Η πολιτική απαντά με διακοπή σε φθορές πηγής ή απώλεια δεδομένων, προαιρετικά διακόπτει σε σοβαρή απώλεια μορφοποίησης και συνεχίζει για άλλες προειδοποιήσεις.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Περάστε `false` για το `abortOnMajorFormattingLoss` όταν δημιουργείτε το `WarningPolicy` εάν οι σημαντικές διαφορές μορφοποίησης είναι αποδεκτές. Τα ζητήματα συμβατότητας, η μικρή απώλεια μορφοποίησης και το μη αναμενόμενο περιεχόμενο παραμένουν στην αναφορά ακόμα και όταν η λειτουργία συνεχίζεται. Επεκτείνετε το `WarningPolicy.getAction` εάν η εφαρμογή πρέπει να απορρίψει οποιαδήποτε από αυτές τις κατηγορίες.

## **Κοινά Σενάρια Προειδοποίησης**

Οι προειδοποιήσεις μπορεί να εμφανιστούν σε διαφορετικά στάδια μιας ροής εργασίας:

- **Ψηφιακές υπογραφές:** Μια υπογεγραμμένη παρουσίαση μπορεί να παράγει προειδοποίηση κατά τη φόρτωση ότι η υπογραφή θα χαθεί κατά την επεξεργασία. Το Aspose.Slides αναφέρει αυτή τη κατάσταση `DataLoss` μέσω του [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationsignedwarninginfo/). Ένα callback στο στάδιο φόρτωσης επιτρέπει στην εφαρμογή να απορρίψει το αρχείο ή να αποδεχτεί ρητά την αναφερόμενη απώλεια.
- **Αντικατάσταση γραμματοσειράς:** Μια μη διαθέσιμη γραμματοσειρά μπορεί να αντικατασταθεί ενώ μια διαφάνεια αποδίδεται ή εξάγεται. Οι προειδοποιήσεις αντικατάστασης γραμματοσειράς αναφέρονται ως `DataLoss`, έτσι η αυστηρή πολιτική παραπάνω διακόπτει ακόμη και αν η εφαρμογή θεωρούσε την αντικατάσταση οπτικά αποδεκτή. Για να παρατηρήσετε αυτή τη συμπεριφορά, χρησιμοποιήστε μια παρουσίαση εισόδου που περιέχει κείμενο σε γραμματοσειρά μη διαθέσιμη στο runtime. Η περιγραφή της προειδοποίησης προσδιορίζει την αντικατάσταση· ρυθμίστε τις απαιτούμενες γραμματοσειρές ή τις [font substitution rules](/slides/el/nodejs-java/font-substitution/) πριν επαναλάβετε.
- **Μη υποστηριζόμενο ή μη αναμενόμενο περιεχόμενο:** Ένας φορτωτής μπορεί να αντιμετωπίσει εγγραφές παρουσίασης ή λειτουργίες που δεν αναγνωρίζει. Τέτοιες προειδοποιήσεις μπορεί να χρησιμοποιούν το `UnexpectedContent` ή μια πιο σοβαρή κατηγορία όταν γνωρίζεται ότι δεδομένα ή μορφοποίηση επηρεάζονται.
- **Συμβατότητα μορφότυπου:** Η αποθήκευση σε διαφορετικό μορφότυπο παρουσίασης μπορεί να παραλείψει λειτουργίες ή να παραγάγει αποτέλεσμα που συμπεριφέρεται διαφορετικά σε ορισμένες εφαρμογές. Για παράδειγμα, η αποθήκευση μιας παρουσίασης με περισσότερα από οκτώ οριζόντια ή κάθετα οδηγούς σχεδίασης σε κληροδοτημένο PPT αναφέρει ένα `CompatibilityIssue`. Το callback στο στάδιο αποθήκευσης μπορεί να καταγράψει την απώλεια και να συνεχίσει, ή να την απορρίψει εάν η διατήρηση όλων των οδηγών είναι απαραίτητη.
- **Συμπεριφορά φόρτωσης:** Οι επιλογές φόρτωσης και οι κληροδοτημένες συμπεριφορές μπορούν επίσης να δημιουργήσουν προειδοποιήσεις. Για παράδειγμα, το [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) προσδιορίζει τη χρήση μιας παρωχημένης συμπεριφοράς κλειδώματος παρουσίασης ως `CompatibilityIssue`.

Οι προειδοποιήσεις εξαρτώνται από το πηγαίο έγγραφο, το μορφότυπο προορισμού, τη λειτουργία και την έκδοση του Aspose.Slides. Μην υποθέσετε ότι κάθε αρχείο παράγει προειδοποίηση ή ότι ένα σενάριο αντιστοιχεί πάντα σε μία κατηγορία.

## **Ασφαλής Διαχείριση Ακυρωμένων Λειτουργιών**

Όταν ένα callback επιστρέφει `ReturnAction.Abort`, μην χρησιμοποιήσετε ένα αντικείμενο που δεν φορτώθηκε και μην υποθέσετε ότι η έξοδος απόδοσης ή αποθήκευσης είναι πλήρης. Η λειτουργία μπορεί να τερματιστεί μετά τη δημιουργία ενός αρχείου εξόδου αλλά πριν ολοκληρωθεί.

Αποθηκεύστε τα επικυρωμένα αποτελέσματα σε ξεχωριστό μονοπάτι όπως `validated-output.pptx`. Αντικαταστήστε μια υπάρχουσα παρουσίαση μόνο αφού η λειτουργία ολοκληρωθεί επιτυχώς, η αναφορά προειδοποίησης ικανοποιεί την πολιτική της εφαρμογής και το αποτέλεσμα μπορεί να ανοίξει και να ελεγχθεί. Αυτό αποτρέπει την αντικατάσταση ενός έγκυρου πηγαίου αρχείου με ένα μερικό ή απορριπτέο αποτέλεσμα.

Μία κενή αναφορά προειδοποίησης δεν εγγυάται ότι κάθε πηγαία λειτουργία έχει διατηρηθεί. Εφαρμόστε τυχόν πρόσθετους ελέγχους περιεχομένου και οπτικούς ελέγχους που απαιτούνται από την εφαρμογή. Δείτε επίσης [Open Presentations](/slides/el/nodejs-java/open-presentation/) και [Save Presentations](/slides/el/nodejs-java/save-presentation/).

## **Συχνές Ερωτήσεις**

**Μπορεί ένα callback προειδοποίησης να διαχειριστεί κάθε σφάλμα του Aspose.Slides;**

Όχι. Διαχειρίζεται μόνο επανορθώσιμες συνθήκες που αναφέρονται ως προειδοποιήσεις. Οι εξαιρέσεις που εμφανίζονται ανεξάρτητα από το callback πρέπει να διαχειριστούν από την εφαρμογή γύρω από την κλήση φόρτωσης, απόδοσης, μετατροπής ή αποθήκευσης.

**Η επιστροφή `ReturnAction.Continue` εγγυάται ταυτόστροφο αποτέλεσμα;**

Όχι. Επιτρέπει μόνο τη συνέχεια της επεξεργασίας. Η αναφερόμενη κατάσταση μπορεί ακόμη να προκαλέσει διαφορές σε δεδομένα, μορφοποίηση ή συμβατότητα, επομένως εξετάστε τους τύπους και τις περιγραφές των συλλεγμένων προειδοποιήσεων.

**Πώς μπορεί μια εφαρμογή να προσδιορίσει τη λειτουργία που παρήγαγε μια προειδοποίηση;**

Δημιουργήστε ένα αντικείμενο callback για κάθε λειτουργία και αποθηκεύστε ένα επίπεδο που ορίζετε εσείς μαζί με τις τιμές που επιστρέφονται από το [getWarningType](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/#getWarningType--) και το [getDescription](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/#getDescription--), όπως φαίνεται στο παράδειγμα.