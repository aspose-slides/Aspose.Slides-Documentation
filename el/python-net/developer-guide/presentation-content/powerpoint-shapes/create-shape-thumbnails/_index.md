---
title: Δημιουργία Μικρογραφιών Σχημάτων Παρουσίασης σε Python
linktitle: Μικρογραφίες Σχημάτων
type: docs
weight: 70
url: /el/python-net/create-shape-thumbnails/
keywords:
- μικρογραφία σχήματος
- εικόνα σχήματος
- απόδοση σχήματος
- απόδοση σχήματος
- οπτικά όρια
- όρια σχήματος
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε υψηλής ποιότητας μικρογραφίες σχημάτων από διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides for Python via .NET – δημιουργήστε και εξάγετε εύκολα μικρογραφίες παρουσίασης."
---
## **Εισαγωγή**

Το Aspose.Slides for Python via .NET χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης στα οποία κάθε σελίδα είναι μια διαφάνεια. Μπορείτε να προβάλετε αυτές τις διαφάνειες στο Microsoft PowerPoint ανοίγοντας το αρχείο παρουσίασης. Ωστόσο, οι προγραμματιστές ενδέχεται μερικές φορές να χρειάζεται να προβάλλουν εικόνες σχημάτων ξεχωριστά σε έναν προβολέα εικόνων. Σε τέτοιες περιπτώσεις, το Aspose.Slides μπορεί να δημιουργήσει μικρογραφίες εικόνων για τα σχήματα των διαφανειών. Αυτό το άρθρο εξηγεί πώς να χρησιμοποιήσετε αυτή τη δυνατότητα.

## **Δημιουργία Μικρογραφιών Σχημάτων από Διαφάνειες**

Όταν χρειάζεστε μια προεπισκόπηση ενός συγκεκριμένου αντικειμένου αντί για ολόκληρη τη διαφάνεια, μπορείτε να αποδώσετε μια μικρογραφία για ένα μεμονωμένο σχήμα. Το Aspose.Slides σάς επιτρέπει να εξάγετε οποιοδήποτε σχήμα σε εικόνα, καθιστώντας εύκολη τη δημιουργία ελαφρών προεπισκοπήσεων, εικονιδίων ή πόρων για επακόλουθη επεξεργασία.

Για να δημιουργήσετε μια μικρογραφία από οποιοδήποτε σχήμα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με το ID ή το δείκτη της .
1. Αποκτήστε μια αναφορά σε ένα σχήμα σε αυτή τη διαφάνεια .
1. Αποδώστε την εικόνα μικρογραφίας του σχήματος .
1. Αποθηκεύστε την εικόνα μικρογραφίας στην επιθυμητή μορφή .

Το παρακάτω παράδειγμα δημιουργεί μια μικρογραφία σχήματος.

```py
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για να ανοίξετε το αρχείο παρουσίασης.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Δημιουργήστε μια εικόνα με την προεπιλεγμένη κλίμακα.
    with shape.get_image() as thumbnail:
        # Αποθηκεύστε την εικόνα στο δίσκο σε μορφή PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Δημιουργία Μικρογραφιών με Προσαρμοσμένο Συντελεστή Κλιμάκωσης**

Αυτή η ενότητα δείχνει πώς να δημιουργήσετε μικρογραφίες σχήματος με έναν ορισμένο από τον χρήστη συντελεστή κλιμάκωσης στο Aspose.Slides. Με τον έλεγχο της κλίμακας, μπορείτε να ρυθμίσετε ακριβώς το μέγεθος της μικρογραφίας ώστε να ταιριάζει με προεπισκοπήσεις, εξαγωγές ή οθόνες υψηλής ανάλυσης.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Αποκτήστε μια διαφάνεια με το ID ή το δείκτη της .
1. Αποκτήστε το στοχευμένο σχήμα σε αυτή τη διαφάνεια .
1. Αποδώστε την εικόνα μικρογραφίας του σχήματος με την καθορισμένη κλίμακα .
1. Αποθηκεύστε την εικόνα μικρογραφίας στην επιθυμητή μορφή .

Το παρακάτω παράδειγμα δημιουργεί μια μικρογραφία με ορισμένο από τον χρήστη συντελεστή κλιμάκωσης.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για να ανοίξετε το αρχείο παρουσίασης.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Δημιουργήστε μια εικόνα με την ορισμένη κλίμακα.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Αποθηκεύστε την εικόνα στο δίσκο σε μορφή PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Δημιουργία Μικρογραφιών Χρησιμοποιώντας τα Όρια Εμφάνισης του Σχήματος**

Αυτή η ενότητα δείχνει πώς να δημιουργήσετε μια μικρογραφία εντός των ορίων εμφάνισης ενός σχήματος. Λαμβάνει υπόψη όλα τα εφέ του σχήματος. Η δημιουργημένη μικρογραφία περιορίζεται από τα όρια της διαφάνειας.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Αποκτήστε μια διαφάνεια με το ID ή το δείκτη της .
1. Αποκτήστε το στοχευμένο σχήμα σε αυτή τη διαφάνεια .
1. Αποδώστε την εικόνα μικρογραφίας του σχήματος με τα καθορισμένα όρια .
1. Αποθηκεύστε την εικόνα μικρογραφίας στην επιθυμητή μορφή εικόνας .

Το παρακάτω παράδειγμα δημιουργεί μια μικρογραφία με ορισμένα από τον χρήστη όρια.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για να ανοίξετε το αρχείο παρουσίασης.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Δημιουργήστε μια εικόνα σχήματος με τα όρια εμφάνισης.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Αποθηκεύστε την εικόνα στο δίσκο σε μορφή PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Λήψη των Πραγματικών Οπτικών Ορίων ενός Σχήματος**

Οι ιδιότητες πλαισίου ενός [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/)—`Shape.x`, `Shape.y`, `Shape.width` και `Shape.height`—περιγράφουν το ορθογώνιο που αποθηκεύεται στο μοντέλο παρουσίασης. Το περιεχόμενο που πραγματικά αποδίδεται μπορεί να εκτείνεται πέρα από αυτό το πλαίσιο ή να καταλαμβάνει διαφορετικό ορθογώνιο στοιχείο. Η περιστροφή, τα περιγράμματα, οι κεφαλές βέλους, η διάταξη και υπερχείλιση κειμένου, η παραγόμενη γεωμετρία SmartArt και άλλα εφέ απόδοσης μπορούν όλα να αλλάξουν την κατειλημμένη περιοχή.

Χρησιμοποιήστε το [Shape.get_visual_bounds](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_visual_bounds/) για να υπολογίσετε αυτήν την κατειλημμένη περιοχή χωρίς τη δημιουργία εικόνας. Η μέθοδος επιστρέφει ένα ορθογώνιο δεκαδικών αριθμών σε συντεταγμένες διαφάνειας. Το επιστρεφόμενο ορθογώνιο δεν είναι περικομμένο στη διαφάνεια, έτσι οι συντεταγμένες του μπορούν να είναι αρνητικές όταν το περιεχόμενο εκτείνεται πέρα από το αρχικό σημείο της διαφάνειας.

Το παρακάτω παράδειγμα λαμβάνει και συγκρίνει τα όρια πλαισίου και τα οπτικά όρια:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Το ίδιο ορθογώνιο μπορεί να χρησιμοποιηθεί για την ευθυγράμμιση γειτονικών σχημάτων προς την αριστερή, δεξιά, επάνω ή κάτω άκρη του· για τη διατήρηση επαρκούς χώρου σε μια παραγόμενη διάταξη· ή για την ανίχνευση περιεχομένου εκτός επιτρεπόμενης περιοχής. Τα οπτικά όρια είναι ιδιαίτερα χρήσιμα για SmartArt, πλαίσια κειμένου, βέλη, εικόνες, περιστρεφόμενα σχήματα και ομαδικά σχήματα, όπου το αποθηκευμένο πλαίσιο μπορεί να μην αντιπροσωπεύει το πλήρες αποτέλεσμα απόδοσης.

Χρησιμοποιήστε το [Shape.get_visual_bounds](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_visual_bounds/) όταν χρειάζεστε συντεταγμένες για διάταξη ή επικύρωση και δεν χρειάζεστε bitmap. Χρησιμοποιήστε το [Shape.get_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_image/) όταν χρειάζεστε να αποδώσετε το σχήμα. Με το [ShapeThumbnailBounds](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapethumbnailbounds/), το `ShapeThumbnailBounds.SHAPE` ορίζει το μέγεθος της εικόνας από τα όρια του σχήματος, συμπεριλαμβανομένων των ρυθμίσεων περιγράμματος, ενώ το `ShapeThumbnailBounds.APPEARANCE` ορίζει το μέγεθος από την εμφάνιση του σχήματος και περιορίζει το αποτέλεσμα στα όρια της διαφάνειας. Αντίθετα, το `Shape.get_visual_bounds` επιστρέφει μόνο το υπολογισμένο ορθογώνιο και δεν το περικόπτει στη διαφάνεια.

## **Συχνές Ερωτήσεις**

**Ποια μορφές εικόνας μπορούν να χρησιμοποιηθούν όταν αποθηκεύονται μικρογραφίες σχημάτων;**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/el/python-net/aspose.slides/imageformat/), και άλλες. Τα σχήματα μπορούν επίσης να [εξάγονται ως διανυσματικό SVG](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/write_as_svg/) αποθηκεύοντας το περιεχόμενο του σχήματος ως SVG.

**Ποια είναι η διαφορά μεταξύ των ορίων SHAPE και APPEARANCE κατά την απόδοση μιας μικρογραφίας;**

`SHAPE` χρησιμοποιεί τη γεωμετρία του σχήματος· `APPEARANCE` λαμβάνει υπόψη [οπτικές επιδράσεις](/slides/el/python-net/shape-effect/) (σκιές, λάμψεις κ.λπ.).

**Τι συμβαίνει αν ένα σχήμα επισημανθεί ως κρυφό; Θα εξακολουθεί να αποδίδεται ως μικρογραφία;**

Ένα κρυφό σχήμα παραμένει μέρος του μοντέλου και μπορεί να αποδοθεί· η σημαία κρυφού επηρεάζει την εμφάνιση της παρουσίασης, αλλά δεν εμποδίζει τη δημιουργία της εικόνας του σχήματος.

**Υποστηρίζονται ομαδικά σχήματα, γραφήματα, SmartArt και άλλα σύνθετα αντικείμενα;**

Ναι. Οποιοδήποτε αντικείμενο που αντιπροσωπεύεται ως [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) (συμπεριλαμβανομένων των [GroupShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/), και [SmartArt](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartart/)) μπορεί να αποθηκευτεί ως μικρογραφία ή ως SVG.

**Επηρεάζουν οι γραμματοσειρές που είναι εγκατεστημένες στο σύστημα την ποιότητα των μικρογραφιών για σχήματα κειμένου;**

Ναι. Θα πρέπει να [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/python-net/custom-font/) (ή να [ρυθμίσετε τις αντικαταστάσεις γραμματοσειρών](/slides/el/python-net/font-substitution/)) για να αποφύγετε ανεπιθύμητες εναλλαγές και επαναφοβίσεις κειμένου.