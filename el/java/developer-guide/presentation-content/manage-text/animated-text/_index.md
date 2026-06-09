---
title: Κινούμενο κείμενο PowerPoint σε Java
linktitle: Κινούμενο κείμενο
type: docs
weight: 60
url: /el/java/animated-text/
keywords:
- κινούμενο κείμενο
- κίνηση κειμένου
- κινούμενη παράγραφος
- κίνηση παραγράφου
- εφέ κίνησης
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε δυναμικό κινούμενο κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Java, με παραδείγματα κώδικα Java εύκολα στην κατανόηση και βελτιστοποιημένα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με κείμενο με κινούμενα σχέδια στο Aspose.Slides εφαρμόζοντας εφέ κίνησης σε μεμονωμένες παραγράφους και ανακτώντας τα εφέ που έχουν ήδη ανατεθεί σε παραγράφους σε ένα πλαίσιο κειμένου. Επικεντρώνεται στις μεθόδους API που χρησιμοποιούνται για την προσθήκη κίνησης σε επίπεδο παραγράφου και την επιθεώρηση των υπαρχόντων εφέ κίνησης παραγράφων σε μια παρουσίαση.

## **Προσθήκη Εφέ Κίνησης σε Παραγράφους**

Προσθέσαμε τη μέθοδο [**addEffect()**](https://reference.aspose.com/slides/el/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) στις κλάσεις [**Sequence**](https://reference.aspose.com/slides/el/java/com.aspose.slides/Sequence) και [**ISequence**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISequence). Αυτή η μέθοδος σας επιτρέπει να προσθέτετε εφέ κίνησης σε μία μόνο παράγραφο. Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε ένα εφέ κίνησης σε μία μόνο παράγραφο:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // επιλέξτε παράγραφο για προσθήκη εφέ
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // προσθέστε το εφέ κίνησης Fly στην επιλεγμένη παράγραφο
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Λήψη Εφέ Κίνησης Παραγράφων**

Μπορεί να θέλετε να ανακαλύψετε τα εφέ κίνησης που προστέθηκαν σε μια παράγραφο — για παράδειγμα, σε ένα σενάριο, θέλετε να λάβετε τα εφέ κίνησης σε μια παράγραφο επειδή σχεδιάζετε να εφαρμόσετε αυτά τα εφέ σε άλλη παράγραφο ή σχήμα. Το Aspose.Slides for Java σας επιτρέπει να λάβετε όλα τα εφέ κίνησης που εφαρμόζονται σε παραγράφους που περιέχονται σε ένα πλαίσιο κειμένου (σχήμα). Αυτό το παράδειγμα κώδικα δείχνει πώς να λάβετε τα εφέ κίνησης σε μια παράγραφο:

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

## **Συχνές Ερωτήσεις**

**Πώς διαφέρουν οι κειμενικές κινήσεις από τις μεταβάσεις διαφανειών και μπορούν να συνδυαστούν;**

Οι κειμενικές κινήσεις ελέγχουν τη συμπεριφορά του αντικειμένου με την πάροδο του χρόνου σε μια διαφάνεια, ενώ οι [μεταβάσεις](/slides/el/java/slide-transition/) ελέγχουν πώς αλλάζουν οι διαφάνειες. Είναι ανεξάρτητες και μπορούν να χρησιμοποιηθούν μαζί· η σειρά αναπαραγωγής καθορίζεται από τη χρονογραμμή των κινήσεων και τις ρυθμίσεις μεταβάσεων.

**Διατηρούνται οι κειμενικές κινήσεις κατά την εξαγωγή σε PDF ή εικόνες;**

Όχι. Τα PDF και οι ραστερ εικόνες είναι στατικά, έτσι θα δείτε μόνο μια κατάσταση της διαφάνειας χωρίς κίνηση. Για να διατηρήσετε την κίνηση, χρησιμοποιήστε εξαγωγή σε [βίντεο](/slides/el/java/convert-powerpoint-to-video/) ή [HTML](/slides/el/java/export-to-html5/).

**Λειτουργούν οι κειμενικές κινήσεις σε διατάξεις και τον κύριο προδιαγραφέα διαφάνειας;**

Τα εφέ που εφαρμόζονται σε αντικείμενα διάταξης/κύριου προδιαγραφέα κληρονομούνται από τις διαφάνειες, αλλά ο χρονισμός τους και η αλληλεπίδραση με τις κινήσεις σε επίπεδο διαφάνειας εξαρτώνται από την τελική ακολουθία στη διαφάνεια.