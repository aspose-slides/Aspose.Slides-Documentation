---
title: Κινούμενο κείμενο PowerPoint σε Python μέσω Java
linktitle: Κινούμενο κείμενο
type: docs
weight: 60
url: /el/python-java/animated-text/
keywords:
- κινούμενο κείμενο
- κίνηση κειμένου
- κινούμενη παράγραφος
- κίνηση παραγράφου
- εφέ κίνησης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε δυναμικό κινούμενο κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω Java, με παραδείγματα κώδικα Python εύκολα στην κατανόηση και βελτιστοποιημένα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με κείμενο με κίνηση στο Aspose.Slides εφαρμόζοντας εφέ κίνησης σε μεμονωμένες παραγράφους και ανακτώντας τα εφέ που έχουν ήδη ανατεθεί σε παραγράφους σε ένα πλαίσιο κειμένου. Επικεντρώνεται στις μεθόδους API που χρησιμοποιούνται για την προσθήκη κίνησης σε επίπεδο παραγράφου και τον έλεγχο των υφιστάμενων εφέ κίνησης παραγράφων σε μια παρουσίαση.

## **Προσθήκη εφέ κίνησης σε παραγράφους**

Η μέθοδος [addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) της κλάσης [Sequence](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/) σας επιτρέπει να προσθέτετε εφέ κίνησης σε μία μόνο παράγραφο. Αυτό το δείγμα κώδικα σας δείχνει πώς να προσθέσετε ένα εφέ κίνησης σε μία παράγραφο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Επιλέξτε την παράγραφο στην οποία θα προσθέσετε ένα εφέ.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Προσθέστε ένα εφέ κίνησης Fly στην επιλεγμένη παράγραφο.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Λήψη εφέ κίνησης παραγράφων**

Μπορεί να θέλετε να εντοπίσετε τα εφέ κίνησης που έχουν προστεθεί σε μια παράγραφο — για παράδειγμα, σε ένα σενάριο, μπορεί να θέλετε να λάβετε τα εφέ κίνησης σε μια παράγραφο επειδή σκοπεύετε να τα εφαρμόσετε σε άλλη παράγραφο ή σχήμα.

Το Aspose.Slides for Python μέσω Java σας επιτρέπει να αποκτήσετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί σε παραγράφους που περιλαμβάνονται σε ένα πλαίσιο κειμένου (σχήμα). Αυτό το δείγμα κώδικα σας δείχνει πώς να λάβετε τα εφέ κίνησης σε μια παράγραφο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Πώς διαφέρουν οι κινήσεις κειμένου από τις μεταβάσεις διαφάνειας και μπορούν να συνδυαστούν;**

Οι κινήσεις κειμένου ελέγχουν τη συμπεριφορά του αντικειμένου σε χρόνο σε μια διαφάνεια, ενώ οι [transitions](/slides/el/python-java/slide-transition/) ελέγχουν πώς αλλάζουν οι διαφάνειες. Είναι ανεξάρτητες και μπορούν να χρησιμοποιηθούν μαζί· η σειρά αναπαραγωγής καθορίζεται από τη γραμμή χρόνου της κίνησης και τις ρυθμίσεις μεταβάσεων.

**Διατηρούνται οι κινήσεις κειμένου κατά την εξαγωγή σε PDF ή εικόνες;**

Όχι. Τα PDF και οι ραστερικές εικόνες είναι στατικά, έτσι θα δείτε μια μόνο κατάσταση της διαφάνειας χωρίς κίνηση. Για να διατηρήσετε την κίνηση, χρησιμοποιήστε την εξαγωγή σε [video](/slides/el/python-java/convert-powerpoint-to-video/) ή [HTML](/slides/el/python-java/export-to-html5/).

**Λειτουργούν οι κινήσεις κειμένου σε διατάξεις και στο μάστερ διαφάνειας;**

Τα εφέ που εφαρμόζονται σε αντικείμενα διάταξης/μάστερ κληρονομούνται από τις διαφάνειες, αλλά το χρονισμό τους και η αλληλεπίδρασή τους με τις κινήσεις σε επίπεδο διαφάνειας εξαρτώνται από την τελική ακολουθία στη διαφάνεια.