---
title: Διαχείριση γραφικών SmartArt σε παρουσιάσεις με Python
linktitle: Γραφικά SmartArt
type: docs
weight: 20
url: /el/python-net/manage-smartart-shape/
keywords:
- Αντικείμενο SmartArt
- Γραφικό SmartArt
- Στυλ SmartArt
- Χρώμα SmartArt
- Δημιουργία SmartArt
- Προσθήκη SmartArt
- Επεξεργασία SmartArt
- Αλλαγή SmartArt
- Πρόσβαση SmartArt
- Τύπος διάταξης SmartArt
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Αυτοματοποιήστε τη δημιουργία, την επεξεργασία και το στυλ των SmartArt στο PowerPoint με Python μέσω .NET χρησιμοποιώντας Aspose.Slides, με σύντα παραδείγματα κώδικα και οδηγίες επικεντρωμένες στην απόδοση."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να δημιουργείτε και να διαχειρίζεστε γραφικά SmartArt σε παρουσιάσεις PowerPoint προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να προσθέσετε ένα σχήμα SmartArt σε μια διαφάνεια, να αποκτήσετε πρόσβαση σε υπάρχοντα σχήματα SmartArt, να βρείτε SmartArt με συγκεκριμένο τύπο διάταξης και να ενημερώσετε την εμφάνισή του αλλάζοντας το στυλ SmartArt ή το χρωματικό στυλ.

Τα παραδείγματα δείχνουν πώς να εργάζεστε με σχήματα SmartArt μέσω της συλλογής σχημάτων της διαφάνειας της παρουσίασης, να ελέγξετε εάν ένα σχήμα είναι SmartArt και στη συνέχεια να τροποποιήσετε ή να ελέγξετε τις ιδιότητές του.

## **Δημιουργία σχημάτων SmartArt**

Το Aspose.Slides for Python via .NET σας επιτρέπει να προσθέσετε προσαρμοσμένα σχήματα SmartArt σε διαφάνειες από το μηδέν. Το API το καθιστά εύκολο. Για να προσθέσετε ένα σχήμα SmartArt σε μια διαφάνεια:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Αποκτήστε τη διαφάνεια‑στόχο με το δείκτη της.
1. Προσθέστε ένα σχήμα SmartArt, καθορίζοντας τον τύπο διάταξής του.
1. Αποθηκεύστε τη τροποποιημένη παρουσία ως αρχείο PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Δημιουργήστε αντικείμενο της κλάσης Presentation.
with slides.Presentation() as presentation:
    # Πρόσβαση στη διαφάνεια της παρουσίασης.
    slide = presentation.slides[0]
    # Προσθήκη σχήματος SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Αποθήκευση της παρουσίασης στον δίσκο.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε σχήματα SmartArt σε διαφάνειες**

Ο παρακάτω κώδικας δείχνει πώς να αποκτήσετε πρόσβαση σε σχήματα SmartArt σε μια διαφάνεια. Το παράδειγμα διατρέχει κάθε σχήμα στη διαφάνεια και ελέγχει εάν είναι αντικείμενο [SmartArt](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartart/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Φορτώστε ένα αρχείο παρουσίασης.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Διέλθετε σε κάθε σχήμα στην πρώτη διαφάνεια.
    for shape in presentation.slides[0].shapes:
        # Ελέγξτε αν το σχήμα είναι σχήμα SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Εκτυπώστε το όνομα του σχήματος.
            print("Shape name:", shape.name)
```

## **Πρόσβαση σε σχήματα SmartArt με καθορισμένο τύπο διάταξης**

Το παρακάτω παράδειγμα δείχνει πώς να αποκτήσετε πρόσβαση σε σχήμα SmartArt με καθορισμένο τύπο διάταξης. Σημειώστε ότι δεν μπορείτε να αλλάξετε τον τύπο διάταξης ενός SmartArt· είναι μόνο‑ανάγνωση και ορίζεται κατά τη δημιουργία του σχήματος.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την παρουσία που περιέχει το σχήμα SmartArt.
1. Αποκτήστε αναφορά στην πρώτη διαφάνεια με το δείκτη.
1. Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι αντικείμενο [SmartArt](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartart/).
1. Εάν ο τύπος διάταξης του σχήματος SmartArt ταιριάζει με αυτόν που χρειάζεστε, εκτελέστε τις απαιτούμενες ενέργειες.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
    for shape in presentation.slides[0].shapes:
        # Ελέγξτε εάν το σχήμα είναι σχήμα SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Ελέγξτε τον τύπο διάταξης του SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **Αλλαγή του στυλ σχήματος SmartArt**

Το παρακάτω παράδειγμα δείχνει πώς να εντοπίσετε σχήματα SmartArt και να αλλάξετε το στυλ τους:

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε το αρχείο που περιέχει το/τα σχήμα/α SmartArt.
1. Αποκτήστε αναφορά στην πρώτη διαφάνεια με το δείκτη.
1. Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
1. Βρείτε το σχήμα SmartArt με το καθορισμένο στυλ.
1. Αναθέστε το νέο στυλ στο σχήμα SmartArt.
1. Αποθηκεύστε την παρουσία.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
    for shape in presentation.slides[0].shapes:
        # Ελέγξτε εάν το σχήμα είναι σχήμα SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Ελέγξτε το στυλ του SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Αλλάξτε το στυλ του SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Αποθηκεύστε την παρουσίαση.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Αλλαγή του χρωματικού στυλ των σχημάτων SmartArt**

Αυτό το παράδειγμα δείχνει πώς να αλλάξετε το χρωματικό στυλ ενός σχήματος SmartArt. Ο κώδικας δείγματος εντοπίζει ένα σχήμα SmartArt με το καθορισμένο χρωματικό στυλ και το ενημερώνει.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την παρουσία που περιέχει το/τα σχήμα/α SmartArt.
1. Αποκτήστε αναφορά στην πρώτη διαφάνεια με το δείκτη.
1. Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι αντικείμενο [SmartArt](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartart/).
1. Εντοπίστε το σχήμα SmartArt με το καθορισμένο χρωματικό στυλ.
1. Ορίστε το νέο χρωματικό στυλ για αυτό το σχήμα SmartArt.
1. Αποθηκεύστε την παρουσία.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
    for shape in presentation.slides[0].shapes:
        # Ελέγξτε εάν το σχήμα είναι σχήμα SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Ελέγξτε τον τύπο χρώματος.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Αλλάξτε τον τύπο χρώματος.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Αποθηκεύστε την παρουσίαση.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Μπορώ να δημιουργήσω κίνηση (animation) για SmartArt ως ένα ενιαίο αντικείμενο;**

Ναι. Το SmartArt είναι ένα σχήμα, έτσι μπορείτε να εφαρμόσετε [standard animations](/slides/el/python-net/powerpoint-animation/) μέσω του API κινήσεων (είσοδος, έξοδος, έμφαση, διαδρομές κίνησης) όπως και για άλλα σχήματα.

**Πώς μπορώ να βρω ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν δεν γνωρίζω το εσωτερικό του αναγνωριστικό;**

Ορίστε και χρησιμοποιήστε το Εναλλακτικό Κείμενο (AltText) και ψάξτε για το σχήμα με αυτήν την τιμή· αυτή είναι η προτεινόμενη μέθοδος για να εντοπίσετε το σχήμα στόχο.

**Μπορώ να ομαδοποιήσω SmartArt με άλλα σχήματα;**

Ναί. Μπορείτε να ομαδοποιήσετε SmartArt με άλλα σχήματα (εικόνες, πίνακες κ.λπ.) και στη συνέχεια να [manipulate the group](/slides/el/python-net/group/).

**Πώς μπορώ να λάβω μια εικόνα από ένα συγκεκριμένο SmartArt (π.χ., για προεπισκόπηση ή αναφορά);**

Εξάγετε μια μικρογραφία/εικόνα του σχήματος· η βιβλιοθήκη μπορεί να [render individual shapes](/slides/el/python-net/create-shape-thumbnails/) σε αρχεία raster (PNG/JPG/TIFF).

**Θα διατηρηθεί η εμφάνιση του SmartArt κατά τη μετατροπή ολόκληρης της παρουσίασης σε PDF;**

Ναί. Η μηχανή απόδοσης στοχεύει σε υψηλή πιστότητα για [PDF export](/slides/el/python-net/convert-powerpoint-to-pdf/), με μια σειρά από επιλογές ποιότητας και συμβατότητας.