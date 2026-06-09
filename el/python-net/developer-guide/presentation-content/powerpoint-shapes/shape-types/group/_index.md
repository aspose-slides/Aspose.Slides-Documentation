---
title: "Ομαδική Παρουσίαση Σχημάτων με Python"
linktitle: "Ομάδα Σχημάτων"
type: docs
weight: 40
url: /el/python-net/group/
keywords:
- "σχήμα ομάδας"
- "ομάδα σχημάτων"
- "προσθήκη ομάδας"
- "εναλλακτικό κείμενο"
- "PowerPoint"
- "παρουσίαση"
- "Python"
- "Aspose.Slides"
description: "Μάθετε πώς να ομαδοποιείτε και να απομαδοποιείτε σχήματα σε παρουσιάσεις PowerPoint και σε δεξαμενές OpenDocument χρησιμοποιώντας το Aspose.Slides για Python—γρήγορος, βήμα-βήμα οδηγός με δωρεάν κώδικα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με ομάδες σχημάτων στο Aspose.Slides. Δείχνει πώς να προσθέσετε ένα σχήμα ομάδας σε μια διαφάνεια, να τοποθετήσετε σχήματα εντός του και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επίσης, παρουσιάζει πώς να έχετε πρόσβαση σε σχήματα που αποθηκεύονται σε μια ομάδα και να διαβάζετε τις τιμές `alternative_text`. Επιπλέον, το άρθρο καλύπτει εν συντομία σχετικές δυνατότητες ομάδων σχημάτων όπως ενσωματωμένες ομάδες, σειρά z και επιλογές κλειδώματος.

## **Προσθήκη Ομάδων Σχημάτων**

Το Aspose.Slides υποστηρίζει εργασία με ομάδες σχημάτων σε μια διαφάνεια. Αυτή η δυνατότητα σας επιτρέπει να δημιουργείτε πιο πλούσιες παρουσιάσεις αντιμετωπίζοντας πολλά σχήματα ως ένα ενιαίο αντικείμενο. Μπορείτε να προσθέσετε νέες ομάδες σχημάτων, να έχετε πρόσβαση σε υπάρχουσες, να τις γεμίσετε με υποσχήματα και να διαβάσετε ή να τροποποιήσετε οποιαδήποτε από τις ιδιότητές τους. Για να προσθέσετε ένα σχήμα ομάδας σε μια διαφάνεια:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη.
3. Προσθέστε ένα [GroupShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/) στη διαφάνεια.
4. Προσθέστε σχήματα στη νέα ομάδα σχήματος.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα δείχνει πώς να προσθέσετε ένα σχήμα ομάδας σε μια διαφάνεια.

```py
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο Presentation.
with slides.Presentation() as presentation:
    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα σχήμα ομάδας στη διαφάνεια.
    group_shape = slide.shapes.add_group_shape()

    # Προσθέστε σχήματα μέσα στο σχήμα ομάδας.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση στην Ιδιότητα Alt Text**

Αυτή η ενότητα εξηγεί πώς να διαβάσετε το Alt Text των σχημάτων που περιλαμβάνονται σε ένα σχήμα ομάδας σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides. Για να αποκτήσετε πρόσβαση στο Alt Text των σχημάτων:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για να αντιπροσωπεύσετε ένα αρχείο PPTX.
2. Αποκτήστε μια αναφορά στη διαφάνεια με βάση τον δείκτη της.
3. Προσπελάστε τη συλλογή σχημάτων της διαφάνειας.
4. Προσπελάστε το [GroupShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/).
5. Διαβάστε την ιδιότητα Alt Text.

Το παρακάτω παράδειγμα ανακτά το Alt Text των σχημάτων που περιέχονται σε ομάδες σχημάτων.

```py
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο Presentation για το άνοιγμα του αρχείου PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Πρόσβαση στο σχήμα ομάδας.
            for child_shape in shape.shapes:
                # Πρόσβαση στην ιδιότητα Alt Text.
                print(child_shape.alternative_text)
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται η ένθετη ομαδοποίηση (μια ομάδα μέσα σε άλλη ομάδα);**

Ναι. Το [GroupShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/) διαθέτει την ιδιότητα [parent_group](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/parent_group/), η οποία δείχνει άμεσα την υποστήριξη της ιεραρχίας (μια ομάδα μπορεί να είναι παιδί μιας άλλης ομάδας).

**Πώς ελέγχω τη σειρά z της ομάδας σε σχέση με άλλα αντικείμενα στη διαφάνεια;**

Χρησιμοποιήστε την ιδιότητα [z_order_position](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/z_order_position/) του [GroupShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/) για να ελέγξετε τη θέση του στην στοίβα εμφάνισης.

**Μπορώ να εμποδίσω τη μετακίνηση/επεξεργασία/αποομαδωση;**

Ναι. Η ενότητα κλειδώματος της ομάδας εκτίθεται μέσω του [group_shape_lock](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/group_shape_lock/), η οποία σας επιτρέπει να περιορίσετε τις ενέργειες στο αντικείμενο.