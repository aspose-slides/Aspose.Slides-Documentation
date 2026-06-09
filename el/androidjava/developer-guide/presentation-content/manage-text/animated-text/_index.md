---
title: Κινούμενο κείμενο PowerPoint σε Android
linktitle: Κινούμενο κείμενο
type: docs
weight: 60
url: /el/androidjava/animated-text/
keywords:
- κινούμενο κείμενο
- κίνηση κειμένου
- κινούμενη παράγραφος
- κίνηση παραγράφου
- εφέ κίνησης
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε δυναμικό κινούμενο κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android, με εύκολα κατανοητά, βελτιστοποιημένα παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με κείμενο με κίνηση στο Aspose.Slides εφαρμόζοντας εφέ κίνησης σε μεμονωμένες παραγράφους και ανακτώντας τα εφέ που έχουν ήδη ανατεθεί στις παραγράφους σε ένα πλαίσιο κειμένου. Επικεντρώνεται στις μεθόδους API που χρησιμοποιούνται για την προσθήκη κίνησης σε επίπεδο παραγράφου και την επιθεώρηση των ήδη υπαρχόντων εφέ κίνησης παραγράφων σε μια παρουσίαση.

## **Προσθήκη εφέ κίνησης σε παραγράφους**

Προσθέσαμε τη μέθοδο [**addEffect()**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) στις κλάσεις [**Sequence**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Sequence) και [**ISequence**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISequence). Αυτή η μέθοδος σάς επιτρέπει να προσθέτετε εφέ κίνησης σε μια μόνο παράγραφο. Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε ένα εφέ κίνησης σε μια μόνο παράγραφο:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // επιλέξτε παράγραφο για προσθήκη εφέ
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // προσθέστε εφέ κίνησης Fly στην επιλεγμένη παράγραφο
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ανάκτηση εφέ κίνησης από παραγράφους**

Μπορεί να θέλετε να ανακαλύψετε τα εφέ κίνησης που έχουν προστεθεί σε μια παράγραφο — για παράδειγμα, σε μία κατάσταση, ίσως θέλετε να λάβετε τα εφέ κίνησης σε μια παράγραφο επειδή σχεδιάζετε να τα εφαρμόσετε σε άλλη παράγραφο ή σχήμα.

Το Aspose.Slides for Android via Java σάς επιτρέπει να λάβετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί σε παραγράφους που περιέχονται σε ένα πλαίσιο κειμένου (σχήμα). Αυτό το παράδειγμα κώδικα δείχνει πώς να λάβετε τα εφέ κίνησης σε μια παράγραφο:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Πώς διαφέρουν οι κειμενικές κινήσεις από τις μεταβάσεις διαφάνειας, και μπορούν να συνδυαστούν;**

Οι κειμενικές κινήσεις ελέγχουν τη συμπεριφορά των αντικειμένων με το χρόνο σε μια διαφάνεια, ενώ οι [μεταβάσεις](/slides/el/androidjava/slide-transition/) ελέγχουν πώς αλλάζουν οι διαφάνειες. Είναι ανεξάρτητες και μπορούν να χρησιμοποιηθούν μαζί· η σειρά αναπαραγωγής καθορίζεται από τη χρονογραμμή των κινήσεων και τις ρυθμίσεις των μεταβάσεων.

**Διατηρούνται οι κειμενικές κινήσεις όταν εξάγονται σε PDF ή εικόνες;**

Όχι. Τα PDF και οι ραστερ εικόνες είναι στατικά, έτσι θα δείτε μια μόνο κατάσταση της διαφάνειας χωρίς κίνηση. Για να διατηρήσετε την κίνηση, χρησιμοποιήστε εξαγωγή σε [βίντεο](/slides/el/androidjava/convert-powerpoint-to-video/) ή [HTML](/slides/el/androidjava/export-to-html5/).

**Λειτουργούν οι κειμενικές κινήσεις σε διατάξεις και στο κύριο πρότυπο διαφάνειας;**

Τα εφέ που εφαρμόζονται σε αντικείμενα διάταξης/προτύπου κληρονομούνται από τις διαφάνειες, αλλά ο συγχρονισμός και η αλληλεπίδρασή τους με τις κινήσεις σε επίπεδο διαφάνειας εξαρτώνται από την τελική ακολουθία στη διαφάνεια.