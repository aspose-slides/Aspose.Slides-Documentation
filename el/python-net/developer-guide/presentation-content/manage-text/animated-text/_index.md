---
title: Κινούμενο κείμενο PowerPoint σε Python
linktitle: Κινούμενο κείμενο
type: docs
weight: 60
url: /el/python-net/animated-text/
keywords:
- κινούμενο κείμενο
- κίνηση κειμένου
- κινούμενη παράγραφος
- κίνηση παραγράφου
- εφέ κίνησης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε δυναμικό κινούμενο κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET, με παραδείγματα κώδικα εύκολα κατανοητά και βελτιστοποιημένα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε κινούμενο κείμενο σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Python. Θα μάθετε να προσθέτετε εφέ σε επιμέρους παραγράφους, να ρυθμίζετε τους ενεργοποιητές και να διαβάζετε τις υπάρχουσες αλληλουχίες κίνησης. Στο τέλος, θα μπορείτε να δημιουργήσετε επαναχρησιμοποιήσιμες ροές εργασίας κίνησης κειμένου που εξάγονται σε τυπικό PPTX και παίζονται σωστά στο PowerPoint.

## **Προσθήκη εφέ κίνησης παραγράφου**

Η μέθοδος [add_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/add_effect/) της κλάσης [Sequence](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/) σάς επιτρέπει να εφαρμόσετε ένα εφέ κίνησης σε μία ενιαία παράγραφο. Ο παρακάτω κώδικας δείγματος παρουσιάζει πώς να το κάνετε:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Επιλέξτε την παράγραφο για να προσθέσετε το εφέ.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Προσθέστε ένα εφέ κίνησης Fly στην επιλεγμένη παράγραφο.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Λήψη εφέ κίνησης παραγράφου**

Μπορεί να θέλετε να προσδιορίσετε ποια εφέ κίνησης έχουν εφαρμοστεί σε μια παράγραφο — για παράδειγμα, αν σκοπεύετε να αντιγράψετε αυτά τα εφέ σε άλλη παράγραφο ή σχήμα.

Το Aspose.Slides για Python σας επιτρέπει να ανακτήσετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί στις παραγράφους ενός πλαισίου κειμένου (σχήμα). Ο παρακάτω κώδικας δείγματος δείχνει πώς να λάβετε τα εφέ κίνησης μιας παραγράφου:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **Συχνές ερωτήσεις**

**Πώς διαφέρουν οι κινήσεις κειμένου από τις μεταβάσεις διαφάνειας και μπορούν να συνδυαστούν;**

Οι κινήσεις κειμένου ελέγχουν τη συμπεριφορά του αντικειμένου με την πάροδο του χρόνου σε μια διαφάνεια, ενώ οι [transitions](/slides/el/python-net/slide-transition/) ελέγχουν πώς αλλάζουν οι διαφάνειες. Είναι ανεξάρτητες και μπορούν να χρησιμοποιηθούν μαζί· η σειρά αναπαραγωγής καθορίζεται από τη χρονολογία της κίνησης και τις ρυθμίσεις της μετάβασης.

**Διατηρούνται οι κινήσεις κειμένου κατά την εξαγωγή σε PDF ή εικόνες;**

Όχι. Τα PDF και οι raster εικόνες είναι στατικά, έτσι θα δείτε μια μόνο κατάσταση της διαφάνειας χωρίς κίνηση. Για να διατηρήσετε την κίνηση, χρησιμοποιήστε εξαγωγή σε [video](/slides/el/python-net/convert-powerpoint-to-video/) ή [HTML](/slides/el/python-net/export-to-html5/).

**Λειτουργούν οι κινήσεις κειμένου σε διατάξεις και στο master της διαφάνειας;**

Τα εφέ που εφαρμόζονται σε αντικείμενα διατάξεων/μαστέρ κληρονομούνται από τις διαφάνειες, αλλά ο χρόνος και η αλληλεπίδρασή τους με τις κινήσεις επιπέδου διαφάνειας εξαρτώνται από την τελική ακολουθία στη διαφάνεια.