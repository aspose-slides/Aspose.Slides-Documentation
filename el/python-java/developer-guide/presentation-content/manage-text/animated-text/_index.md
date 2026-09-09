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
description: "Δημιουργήστε δυναμικό κινούμενο κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω Java, με εύκολα κατανοητά, βελτιστοποιημένα παραδείγματα κώδικα Python."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με κείμενο με κίνηση στο Aspose.Slides εφαρμόζοντας εφέ κίνησης σε μεμονωμένες παραγράφους και ανακτώντας τα εφέ που έχουν ήδη εκχωρηθεί σε παραγράφους σε ένα πλαίσιο κειμένου. Επικεντρώνεται στις μεθόδους API που χρησιμοποιούνται για την προσθήκη κίνησης σε επίπεδο παραγράφου και την επιθεώρηση των υφιστάμενων εφέ κίνησης παραγράφων σε μια παρουσίαση.

## **Προσθήκη εφέ κίνησης σε παραγράφους**

Η μέθοδος [addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) της κλάσης [Sequence](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/) σάς επιτρέπει να προσθέσετε εφέ κίνησης σε μια μόνο παράγραφο. Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε ένα εφέ κίνησης σε μια μόνο παράγραφο:

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

## **Ανάκτηση εφέ κίνησης παραγράφων**

Μπορεί να θέλετε να ανακτήσετε τα εφέ κίνησης που έχουν εφαρμοστεί σε μια παράγραφο—για παράδειγμα, για να τα εφαρμόσετε σε άλλη παράγραφο ή σχήμα.

Το Aspose.Slides για Python μέσω Java σας επιτρέπει να λάβετε όλα τα εφέ κίνησης που εφαρμόζονται σε παραγράφους που περιέχονται σε ένα πλαίσιο κειμένου (σχήμα). Αυτό το δείγμα κώδικα δείχνει πώς να λάβετε τα εφέ κίνησης που έχουν εφαρμοστεί σε μια παράγραφο:

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

**Πώς διαφέρουν οι κειμενικές κινήσεις από τις μεταβάσεις διαφάνειας και μπορούν να συνδυαστούν;**

Οι κειμενικές κινήσεις ελέγχουν τη συμπεριφορά των αντικειμένων στο χρόνο σε μια διαφάνεια, ενώ οι [transitions](/slides/el/python-java/slide-transition/) ελέγχουν τον τρόπο αλλαγής των διαφανειών. Είναι ανεξάρτητες και μπορούν να χρησιμοποιηθούν μαζί· η σειρά αναπαραγωγής καθορίζεται από τη γραμμή χρόνου των κινήσεων και τις ρυθμίσεις των μεταβάσεων.

**Διατηρούνται οι κειμενικές κινήσεις κατά την εξαγωγή σε PDF ή εικόνες;**

Όχι. Τα PDF και οι ραστερ εικόνες είναι στατικά, επομένως βλέπετε μια μόνο κατάσταση της διαφάνειας χωρίς κίνηση. Για να διατηρήσετε την κίνηση, χρησιμοποιήστε εξαγωγή σε [video](/slides/el/python-java/convert-powerpoint-to-video/) ή [HTML](/slides/el/python-java/export-to-html5/).

**Λειτουργούν οι κειμενικές κινήσεις σε διάταξεις και στο master των διαφανειών;**

Τα εφέ που εφαρμόζονται σε αντικείμενα διάταξης/master κληρονομούνται από τις διαφάνειες, αλλά ο χρονισμός τους και η αλληλεπίδρασή τους με τις κινήσεις σε επίπεδο διαφάνειας εξαρτώνται από την τελική σειρά στην διαφάνεια.