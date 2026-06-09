---
title: Κινούμενο κείμενο PowerPoint σε JavaScript
linktitle: Κινούμενο Κείμενο
type: docs
weight: 60
url: /el/nodejs-java/animated-text/
keywords:
- κινούμενο κείμενο
- κίνηση κειμένου
- κινούμενη παράγραφος
- κίνηση παραγράφου
- εφέ κίνησης
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε δυναμικό κινούμενο κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Node.js, με εύκολα προς ακολούθηση, βελτιστοποιημένα παραδείγματα κώδικα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με κείμενο με κίνηση στο Aspose.Slides εφαρμόζοντας εφέ κίνησης σε μεμονωμένες παραγράφους και ανακτώντας τα εφέ που έχουν ήδη ανατεθεί σε παραγράφους σε ένα πλαίσιο κειμένου. Επικεντρώνεται στις μεθόδους API που χρησιμοποιούνται για την προσθήκη κίνησης σε επίπεδο παραγράφου και την επιθεώρηση των υπαρχόντων εφέ κίνησης παραγράφων σε μια παρουσίαση.

## **Προσθήκη Εφέ Κίνησης σε Παραγράφους**

Προσθέσαμε τη μέθοδο [**addEffect()**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) στην κλάση [**Sequence**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Sequence) και [**Sequence**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Sequence). Αυτή η μέθοδος σας επιτρέπει να προσθέσετε εφέ κίνησης σε μία μόνο παράγραφο. Αυτό το δείγμα κώδικα σας δείχνει πώς να προσθέσετε ένα εφέ κίνησης σε μία μόνο παράγραφο:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // επιλέξτε την παράγραφο για προσθήκη εφέ
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // προσθέστε το εφέ κίνησης Fly στην επιλεγμένη παράγραφο
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Λήψη των Εφέ Κίνησης σε Παραγράφους**

Μπορεί να θέλετε να ανακαλύψετε τα εφέ κίνησης που προστέθηκαν σε μια παράγραφο - για παράδειγμα, σε ένα σενάριο, θέλετε να λάβετε τα εφέ κίνησης σε μια παράγραφο επειδή σχεδιάζετε να εφαρμόσετε αυτά τα εφέ σε άλλη παράγραφο ή σχήμα.

Το Aspose.Slides for Node.js via Java σας επιτρέπει να λάβετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί σε παραγράφους που περιέχονται σε ένα πλαίσιο κειμένου (σχήμα). Αυτό το δείγμα κώδικα σας δείχνει πώς να λάβετε τα εφέ κίνησης σε μια παράγραφο:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}

```

## **Συχνές Ερωτήσεις**

**Πώς διαφέρουν οι κειμενικές κινήσεις από τις μεταβάσεις διαφανειών και μπορούν να συνδυαστούν;**

Οι κειμενικές κινήσεις ελέγχουν τη συμπεριφορά του αντικειμένου με την πάροδο του χρόνου σε μια διαφάνεια, ενώ οι [transitions](/slides/el/nodejs-java/slide-transition/) ελέγχουν πώς αλλάζουν οι διαφάνειες. Είναι ανεξάρτητες και μπορούν να χρησιμοποιηθούν μαζί· η σειρά αναπαραγωγής καθορίζεται από τη χρονοπρογραμματισμένη κίνηση και τις ρυθμίσεις μετάβασης.

**Διατηρούνται οι κειμενικές κινήσεις κατά την εξαγωγή σε PDF ή εικόνες;**

Όχι. Τα PDF και οι raster εικόνες είναι στατικές, επομένως θα δείτε μια ενιαία κατάσταση της διαφάνειας χωρίς κίνηση. Για να διατηρήσετε την κίνηση, χρησιμοποιήστε εξαγωγή σε [video](/slides/el/nodejs-java/convert-powerpoint-to-video/) ή [HTML](/slides/el/nodejs-java/export-to-html5/).

**Λειτουργούν οι κειμενικές κινήσεις σε διατάξεις και στο master της διαφάνειας;**

Τα εφέ που εφαρμόζονται σε αντικείμενα διάταξης/ master κληρονομούνται από τις διαφάνειες, αλλά το χρονοδιάγραμμα και η αλληλεπίδρασή τους με κινήσεις επιπέδου διαφάνειας εξαρτώνται από την τελική ακολουθία στη διαφάνεια.