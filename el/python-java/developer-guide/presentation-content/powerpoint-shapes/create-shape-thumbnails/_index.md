---
title: Δημιουργία μικρογραφιών σχημάτων παρουσίασης σε Python μέσω Java
linktitle: Μικρογραφίες Σχημάτων
type: docs
weight: 70
url: /el/python-java/create-shape-thumbnails/
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
- Java
- Aspose.Slides
description: "Δημιουργήστε υψηλής ποιότητας μικρογραφίες σχημάτων από διαφάνειες PowerPoint με Aspose.Slides για Python μέσω Java – δημιουργήστε και εξάγετε εύκολα μικρογραφίες παρουσιάσεων."
---
## **Εισαγωγή**

Το Aspose.Slides for Python via Java μπορεί να χρησιμοποιηθεί για τη δημιουργία αρχείων παρουσίασης στα οποία κάθε σελίδα αντιστοιχεί σε μια διαφάνεια. Οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τα αρχεία παρουσίασης με το Microsoft PowerPoint. Ωστόσο, μερικές φορές οι προγραμματιστές χρειάζονται να δουν τις εικόνες των σχημάτων ξεχωριστά σε προβολέα εικόνων. Σε τέτοιες περιπτώσεις, το Aspose.Slides for Python via Java τους βοηθά να δημιουργήσουν μικρογραφίες εικόνων των σχημάτων της διαφάνειας.

Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε μικρογραφίες σχημάτων με διαφορετικούς τρόπους:

- Δημιουργία μικρογραφίας σχήματος μέσα σε μια διαφάνεια.
- Δημιουργία μικρογραφίας σχήματος για σχήμα διαφάνειας με διαστάσεις που καθορίζονται από το χρήστη.
- Δημιουργία μικρογραφίας σχήματος στα όρια της εμφάνισης ενός σχήματος.

## **Δημιουργία μικρογραφίας σχήματος από διαφάνεια**

Για να δημιουργήσετε μια μικρογραφία σχήματος από οποιαδήποτε διαφάνεια χρησιμοποιώντας το Aspose.Slides for Python via Java, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ID ή τον δείκτη της.
1. Αποκτήστε την [εικόνα μικρογραφίας του σχήματος](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage) ενός σχήματος στη σχετική διαφάνεια στην προεπιλεγμένη κλίμακα.
1. Αποθηκεύστε την εικόνα μικρογραφίας στη προτιμώμενη μορφή εικόνας.

Αυτό το δείγμα κώδικα σας δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος από μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Δημιουργήστε ένα αντικείμενο κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης.
presentation = Presentation("Thumbnail.pptx")
try:
    # Δημιουργία εικόνας πλήρους κλίμακας.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Αποθήκευση της εικόνας στο δίσκο σε μορφή PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Δημιουργία μικρογραφίας με παράγοντα κλιμάκωσης που καθορίζεται από το χρήστη**

Για να δημιουργήσετε τη μικρογραφία σχήματος μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides for Python via Java, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ID ή τον δείκτη της.
1. Αποκτήστε την [εικόνα μικρογραφίας του σχήματος](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage) ενός σχήματος στη σχετική διαφάνεια με διαστάσεις που ορίζονται από το χρήστη.
1. Αποθηκεύστε την εικόνα μικρογραφίας στη προτιμώμενη μορφή εικόνας.

Αυτό το δείγμα κώδικα σας δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος βασισμένη σε καθορισμένο παράγοντα κλιμάκωσης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Δημιουργήστε ένα αντικείμενο κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης.
presentation = Presentation("Thumbnail.pptx")
try:
    # Δημιουργήστε μια εικόνα κλιμακωμένη με συντελεστή 2 και στις δύο κατευθύνσεις.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Αποθηκεύστε την εικόνα στο δίσκο σε μορφή PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Δημιουργία μικρογραφίας εμφάνισης σχήματος βάσει ορίων**

Αυτή η μέθοδος δημιουργίας μικρογραφιών σχημάτων επιτρέπει στους προγραμματιστές να δημιουργήσουν μια μικρογραφία στα όρια της εμφάνισης του σχήματος. Λαμβάνει υπόψη όλα τα εφέ του σχήματος. Η παραγόμενη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας. Για να δημιουργήσετε μια μικρογραφία σχήματος διαφάνειας εντός των ορίων της εμφάνισής του, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ID ή τον δείκτη της.
1. Αποκτήστε την εικόνα μικρογραφίας ενός σχήματος στη σχετική διαφάνεια χρησιμοποιώντας τα όρια της εμφάνειάς του.
1. Αποθηκεύστε την εικόνα μικρογραφίας στη προτιμώμενη μορφή εικόνας.

Αυτό το δείγμα κώδικα βασίζεται στα παραπάνω βήματα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Δημιουργήστε ένα αντικείμενο κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης.
presentation = Presentation("Thumbnail.pptx")
try:
    # Δημιουργήστε μια εικόνα πλήρους κλίμακας.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Αποθηκεύστε την εικόνα στο δίσκο σε μορφή PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Λήψη των πραγματικών οπτικών ορίων ενός σχήματος**

Οι ιδιότητες πλαισίου του [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/)—οι μέθοδοι [getX](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getWidth) και [getHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getHeight)—περιγράφουν το ορθογώνιο που αποθηκεύεται στο μοντέλο παρουσίασης. Το περιεχόμενο που αποδίδεται πραγματικά μπορεί να εκτείνεται πέρα από αυτό το πλαίσιο ή να καταλαμβάνει διαφορετικό ορθογώνιο προσανατολισμένο στους άξονες. Η περιστροφή, τα περιγράμματα, τα άκρα βελών, η διάταξη κειμένου και η υπέρβαση, η παραγόμενη γεωμετρία SmartArt και άλλα εφέ απόδοσης μπορούν όλα να αλλάξουν την καταληφθείσα περιοχή.

Χρησιμοποιήστε το [Shape.getVisualBounds](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getVisualBounds) για να υπολογίσετε αυτήν την καταληφθείσα περιοχή χωρίς να δημιουργήσετε εικόνα. Η μέθοδος επιστρέφει ένα [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) σε συντεταγμένες διαφάνειας. Το επιστρεφόμενο ορθογώνιο δεν περικόπτεται από τη διαφάνεια, οπότε οι συντεταγμένες του μπορεί να είναι αρνητικές όταν το περιεχόμενο επεκτείνεται πέρα από την αρχή της διαφάνειας.

Το παρακάτω παράδειγμα λαμβάνει και συγκρίνει τα όρια πλαισίου και τα οπτικά όρια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Το ίδιο [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) μπορεί να χρησιμοποιηθεί για να ευθυγραμμιστεί ένα κοντινό σχήμα προς αριστερή, δεξιά, ανώτερη ή κατώτερη άκρη· να διατεθεί επαρκής χώρος σε μια παραγόμενη διάταξη· ή να ανιχνευτεί περιεχόμενο εκτός επιτρεπόμενης περιοχής. Τα οπτικά όρια είναι ιδιαίτερα χρήσιμα για SmartArt, πλαίσια κειμένου, βέλη, εικόνες, περιστρεφόμενα σχήματα και ομάδες σχημάτων, όπου το αποθηκευμένο πλαίσιο ενδέχεται να μην αντιπροσωπεύει το πλήρες αποδοθέν αποτέλεσμα.

Χρησιμοποιήστε το [Shape.getVisualBounds](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getVisualBounds) όταν χρειάζεστε συντεταγμένες για διάταξη ή επικύρωση και δεν χρειάζεστε bitmap. Χρησιμοποιήστε το [Shape.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage) όταν χρειάζεστε να αποδώσετε το σχήμα. Με το [ShapeThumbnailBounds](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapethumbnailbounds/), το [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapethumbnailbounds/#Shape) προσαρμόζει την εικόνα από τα όρια του σχήματος, συμπεριλαμβανομένων των ρυθμίσεων περιγράμματος, ενώ το [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapethumbnailbounds/#Appearance) την προσαρμόζει από την εμφάνιση του σχήματος και περιορίζει το αποτέλεσμα στα όρια της διαφάνειας. Αντίθετα, το [Shape.getVisualBounds](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getVisualBounds) επιστρέφει μόνο το υπολογισμένο ορθογώνιο και δεν το περικοπεί στη διαφάνεια.

## **Συχνές ερωτήσεις**

**Ποιοι τύποι εικόνας μπορούν να χρησιμοποιηθούν κατά την αποθήκευση μικρογραφιών σχήματος;**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/el/python-java/aspose.slides/imageformat/), και άλλα. Τα σχήματα μπορούν επίσης να [εξαχθούν ως διανυσματικό SVG](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#writeAsSvgToBytes) αποθηκεύοντας το περιεχόμενο του σχήματος ως SVG.

**Ποια είναι η διαφορά μεταξύ ορίων Shape και Appearance κατά την απόδοση μιας μικρογραφίας;**

`Shape` χρησιμοποιεί τη γεωμετρία του σχήματος· `Appearance` λαμβάνει υπόψη [οπτικά εφέ](/slides/el/python-java/shape-effect/) (σκιές, λάμψεις κ.λπ.).

**Τι συμβαίνει αν ένα σχήμα είναι σημειωμένο ως κρυφό; Θα εξακολουθεί να αποδίδεται ως μικρογραφία;**

Ένα κρυφό σχήμα παραμένει μέρος του μοντέλου και μπορεί να αποδοθεί· η σημαία κρυφής κατάστασης επηρεάζει την προβολή της παρουσίασης αλλά δεν εμποδίζει τη δημιουργία της εικόνας του σχήματος.

**Υποστηρίζονται τα ομαδικά σχήματα, τα γραφήματα, το SmartArt και άλλα σύνθετα αντικείμενα;**

Ναι. Οποιοδήποτε αντικείμενο που αντιπροσωπεύεται ως [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/) (συμπεριλαμβανομένων των [GroupShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/), και [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/)) μπορεί να αποθηκευτεί ως μικρογραφία ή ως SVG.

**Επηρεάζουν οι γραμματοσειρές που έχουν εγκατασταθεί στο σύστημα την ποιότητα των μικρογραφιών για σχήματα κειμένου;**

Ναι. Θα πρέπει να [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/python-java/custom-font/) (ή να [ρυθμίσετε τις αντικαταστάσεις γραμματοσειρών](/slides/el/python-java/font-substitution/)) για να αποφύγετε ανεπιθύμητες εναλλακτικές και επανακίνηση κειμένου.