---
title: Μετατροπή παρουσιάσεων PowerPoint σε SWF Flash με JavaScript
linktitle: PowerPoint σε SWF
type: docs
weight: 80
url: /el/nodejs-java/convert-powerpoint-to-swf-flash/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε SWF
- παρουσίαση σε SWF
- διαφάνεια σε SWF
- PPT σε SWF
- PPTX σε SWF
- PowerPoint σε Flash
- παρουσίαση σε Flash
- διαφάνεια σε Flash
- PPT σε Flash
- PPTX σε Flash
- αποθήκευση PPT ως SWF
- αποθήκευση PPTX ως SWF
- εξαγωγή PPT σε SWF
- εξαγωγή PPTX σε SWF
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: Μετατρέψτε το PowerPoint (PPT/PPTX) σε SWF Flash με Aspose.Slides για Node.js. Παραδείγματα κώδικα βήμα προς βήμα, γρήγορο υψηλής ποιότητας αποτέλεσμα, χωρίς αυτοματισμό PowerPoint.
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε SWF χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο SWF με τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) και πώς να διαμορφώσετε την εξαγωγή με [SwfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/swfoptions/), συμπεριλαμβανομένων των ρυθμίσεων του προβολέα και της διάταξης σημειώσεων ή σχολίων.

## **Μετατροπή PPT(X) σε SWF**
Η μέθοδος [save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) μπορεί να χρησιμοποιηθεί για να μετατρέψει ολόκληρη την παρουσίαση σε έγγραφο **SWF**. Το παρακάτω παράδειγμα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο **SWF** χρησιμοποιώντας τις επιλογές που παρέχει η κλάση [**SWFOptions**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SwfOptions). Μπορείτε επίσης να συμπεριλάβετε σχόλια στο παραγόμενο SWF χρησιμοποιώντας την κλάση [**SWFOptions**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SwfOptions) και την κλάση [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions).

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Αποθήκευση παρουσίασης
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στο SWF;**

Ναι. Χρησιμοποιήστε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) στην κλάση [SwfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/swfoptions/). Από προεπιλογή, οι κρυφές διαφάνειες δεν εξάγονται.

**Πώς μπορώ να ελέγξω τη συμπίεση και το τελικό μέγεθος του SWF;**

Χρησιμοποιήστε τη μέθοδο [setCompressed](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/swfoptions/setcompressed/) και [setJpegQuality](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/swfoptions/setjpegquality/) για να εξισορροπήσετε το μέγεθος του αρχείου και την πιστότητα της εικόνας.

**Για τι χρησιμεύει το 'setViewerIncluded' και πότε πρέπει να το χρησιμοποιήσω;**

Το [setViewerIncluded](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) προσθέτει ενσωματωμένο UI αναπαραγωγού (πλήκτρα πλοήγησης, πίνακες, αναζήτηση). Χρησιμοποιήστε το εάν σκοπεύετε να χρησιμοποιήσετε δικό σας player ή χρειάζεστε ένα καθαρό πλαίσιο SWF χωρίς UI.

**Τι συμβαίνει αν μια πηγή γραμματοσειράς λείπει στο μηχάνημα εξαγωγής;**

Το Aspose.Slides θα αντικαταστήσει τη γραμματοσειρά που καθορίζετε μέσω του [setDefaultRegularFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) στην κλάση [SwfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/swfoptions/) για να αποφύγει μια ανεπιθύμητη εναλλακτική.