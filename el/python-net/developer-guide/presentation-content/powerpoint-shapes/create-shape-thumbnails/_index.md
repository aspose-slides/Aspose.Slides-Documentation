---
title: Δημιουργία μικρογραφιών σχήματος παρουσίασης σε Python
linktitle: Μικρογραφίες Σχήματος
type: docs
weight: 70
url: /el/python-net/create-shape-thumbnails/
keywords:
- μικρογραφία σχήματος
- εικόνα σχήματος
- απόδοση σχήματος
- απόδοση σχήματος
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε υψηλής ποιότητας μικρογραφίες σχήματος από διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides for Python μέσω .NET – δημιουργήστε και εξάγετε εύκολα μικρογραφίες παρουσίασης."
---
## **Εισαγωγή**

Το Aspose.Slides for Python μέσω .NET χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης στα οποία κάθε σελίδα είναι μια διαφάνεια. Μπορείτε να προβάλετε αυτές τις διαφάνειες στο Microsoft PowerPoint ανοίγοντας το αρχείο παρουσίασης. Ωστόσο, οι προγραμματιστές ενδέχεται μερικές φορές να χρειάζονται να προβάλλουν εικόνες σχημάτων ξεχωριστά σε προβολέα εικόνων. Σε τέτοιες περιπτώσεις, το Aspose.Slides μπορεί να δημιουργήσει μικρογραφίες για τα σχήματα της διαφάνειας. Αυτό το άρθρο εξηγεί πώς να χρησιμοποιήσετε αυτή τη λειτουργία.

## **Δημιουργία μικρογραφιών σχήματος από διαφάνειες**

Όταν χρειάζεστε μια προεπισκόπηση ενός συγκεκριμένου αντικειμένου αντί για ολόκληρη τη διαφάνεια, μπορείτε να αποδώσετε μια μικρογραφία για ένα μεμονωμένο σχήμα. Το Aspose.Slides σας επιτρέπει να εξάγετε οποιοδήποτε σχήμα σε εικόνα, καθιστώντας εύκολη τη δημιουργία ελαφριών προεπισκοπήσεων, εικονιδίων ή πόρων για περαιτέρω επεξεργασία.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το ID ή το δείκτη της.
1. Αποκτήστε μια αναφορά σε ένα σχήμα σε αυτή τη διαφάνεια.
1. Αποδώστε τη μικρογραφία της εικόνας του σχήματος.
1. Αποθηκεύστε τη μικρογραφία στην επιθυμητή μορφή.

```py
import aspose.slides as slides

# Δημιουργία αντικειμένου της κλάσης Presentation για άνοιγμα του αρχείου παρουσίασης.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Δημιουργία εικόνας με την προεπιλεγμένη κλίμακα.
    with shape.get_image() as thumbnail:
        # Αποθήκευση της εικόνας στο δίσκο σε μορφή PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Δημιουργία μικρογραφιών με προσαρμοσμένο συντελεστή κλιμάκωσης**

Αυτή η ενότητα δείχνει πώς να δημιουργήσετε μικρογραφίες σχήματος με έναν από τον χρήστη καθορισμένο συντελεστή κλιμάκωσης στο Aspose.Slides. Ελέγχοντας την κλίμακα, μπορείτε να ρυθμίσετε ακριβώς το μέγεθος της μικρογραφίας ώστε να ταιριάζει σε προεπισκοπήσεις, εξαγωγές ή οθόνες υψηλής ανάλυσης (high-DPI).

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Αποκτήστε μια διαφάνεια με βάση το ID ή το δείκτη της.
1. Αποκτήστε το επιθυμητό σχήμα σε αυτή τη διαφάνεια.
1. Αποδώστε τη μικρογραφία του σχήματος με την καθορισμένη κλίμακα.
1. Αποθηκεύστε τη μικρογραφία στην επιθυμητή μορφή.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Δημιουργία αντικειμένου της κλάσης Presentation για άνοιγμα του αρχείου παρουσίασης.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Δημιουργία εικόνας με τον ορισμένο συντελεστή κλίμακας.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Αποθήκευση της εικόνας στο δίσκο σε μορφή PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Δημιουργία μικρογραφιών χρησιμοποιώντας τα όρια εμφάνισης του σχήματος**

Αυτή η ενότητα δείχνει πώς να δημιουργήσετε μια μικρογραφία εντός των ορίων εμφάνισης ενός σχήματος. Λαμβάνει υπόψη όλα τα εφέ του σχήματος. Η δημιουργημένη μικρογραφία περιορίζεται από τα όρια της διαφάνειας.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Αποκτήστε μια διαφάνεια με βάση το ID ή το δείκτη της.
1. Αποκτήστε το επιθυμητό σχήμα σε αυτή τη διαφάνεια.
1. Αποδώστε τη μικρογραφία του σχήματος με τα καθορισμένα όρια.
1. Αποθηκεύστε τη μικρογραφία στην επιθυμητή μορφή εικόνας.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Δημιουργία αντικειμένου της κλάσης Presentation για άνοιγμα του αρχείου παρουσίασης.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Δημιουργία εικόνας σχήματος με όρια εμφάνισης.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Αποθήκευση της εικόνας στο δίσκο σε μορφή PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Συχνές ερωτήσεις**

**Ποιες μορφές εικόνας μπορούν να χρησιμοποιηθούν κατά την αποθήκευση μικρογραφιών σχήματος;**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/el/python-net/aspose.slides/imageformat/), και άλλες. Τα σχήματα μπορούν επίσης να [εξαχθούν ως διανυσματικό SVG](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/write_as_svg/) αποθηκεύοντας το περιεχόμενο του σχήματος ως SVG.

**Ποια είναι η διαφορά μεταξύ των ορίων SHAPE και APPEARANCE κατά την απόδοση μιας μικρογραφίας;**

`SHAPE` χρησιμοποιεί τη γεωμετρία του σχήματος· `APPEARANCE` λαμβάνει υπόψη [οπτικά εφέ](/slides/el/python-net/shape-effect/) (σκιές, λάμψεις κ.λπ.).

**Τι συμβαίνει αν ένα σχήμα είναι επισημασμένο ως κρυφό; Θα εξακολουθήσει να αποδίδεται ως μικρογραφία;**

Ένα κρυφό σχήμα παραμένει μέρος του μοντέλου και μπορεί να αποδοθεί· η σημαία κρυφής εμφάνισης επηρεάζει την παρουσίαση της διαφάνειας αλλά δεν εμποδίζει τη δημιουργία της εικόνας του σχήματος.

**Υποστηρίζονται τα ομαδικά σχήματα, τα διαγράμματα, το SmartArt και άλλα σύνθετα αντικείμενα;**

Ναι. Οποιοδήποτε αντικείμενο που αναπαρίσταται ως [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) (συμπεριλαμβανομένων των [GroupShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/), και [SmartArt](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartart/)) μπορεί να αποθηκευτεί ως μικρογραφία ή ως SVG.

**Επηρεάζουν οι εγκατεστημένες στο σύστημα γραμματοσειρές την ποιότητα των μικρογραφιών για σχήματα κειμένου;**

Ναι. Θα πρέπει να [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/python-net/custom-font/) (ή να [ρυθμίσετε τις υποκαταστάσεις γραμματοσειρών](/slides/el/python-net/font-substitution/)) για να αποφύγετε ανεπιθύμητες εναλλακτικές και την αναδιάταξη κειμένου.