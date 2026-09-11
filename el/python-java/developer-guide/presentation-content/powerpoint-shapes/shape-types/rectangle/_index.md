---
title: Προσθήκη Ορθογωνίων σε Παρουσιάσεις σε Python μέσω Java
linktitle: Ορθογώνιο
type: docs
weight: 80
url: /el/python-java/rectangle/
keywords:
- προσθήκη ορθογωνίου
- δημιουργία ορθογωνίου
- σχήμα ορθογωνίου
- απλό ορθογώνιο
- μορφοποιημένο ορθογώνιο
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Βελτιώστε τις παρουσιάσεις PowerPoint προσθέτοντας ορθογώνια με το Aspose.Slides για Python μέσω Java—σχεδιάζετε και τροποποιείτε σχήματα προγραμματιστικά με ευκολία."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να προσθέσετε σχήματα ορθογωνίου σε διαφάνειες PowerPoint χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει τη δημιουργία ενός απλού ορθογωνίου, τη δημιουργία ενός μορφοποιημένου ορθογωνίου και την αποθήκευση της ενημερωμένης παρουσίασης ως αρχείο PPTX.

Θα δείτε επίσης πώς να εφαρμόσετε βασική μορφοποίηση ορθογωνίου, όπως συμπαγές χρώμα γεμίσματος, χρώμα γραμμής και πάχος γραμμής. Επιπλέον, η ΕΠ.Ρ.Α. του άρθρου παραπέμπει σε σχετικές εργασίες ορθογωνίου, όπως στρογγυλεμένες γωνίες, γεμίσματα εικόνας, οπτικά εφέ, υπερσυνδέσμους, κλειδώματα σχήματος, επιλογές εξαγωγής και αποτελεσματικές ιδιότητες.

## **Προσθήκη Ορθογωνίου σε Διαφάνεια**

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
- Πάρτε μια αναφορά σε μια διαφάνεια βάσει του δείκτη της.
- Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) τύπου ορθογωνίου χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addAutoShape) που παρέχεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/).
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, έχουμε προσθέσει ένα απλό ορθογώνιο στην πρώτη διαφάνεια της παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Δημιουργία του αντικειμένου Presentation που αντιπροσωπεύει το αρχείο PPTX.
presentation = Presentation()
try:
    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη σχήματος ορθογωνίου.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσθήκη Μορφοποιημένου Ορθογωνίου σε Διαφάνεια**

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
- Πάρτε μια αναφορά σε μια διαφάνεια βάσει του δείκτη της.
- Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) τύπου ορθογωνίου χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addAutoShape) που παρέχεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/).
- Ορίστε το [fill type] του ορθογωνίου σε συμπαγές.
- Ορίστε το χρώμα του ορθογωνίου χρησιμοποιώντας τη μέθοδο [setColor] στο συμπαγές χρώμα γεμίσματος του αντικειμένου [FillFormat] που συνδέεται με το αντικείμενο [Shape].
- Ορίστε το χρώμα του περιγράμματος του ορθογωνίου.
- Ορίστε το πάχος του περιγράμματος του ορθογωνίου.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Τα παραπάνω βήματα υλοποιούνται στο παρακάτω παράδειγμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Δημιουργία του αντικειμένου Presentation που αντιπροσωπεύει το αρχείο PPTX.
presentation = Presentation()
try:
    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη σχήματος ορθογωνίου.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Μορφοποίηση του γεμίσματος του ορθογωνίου.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Μορφοποίηση του περιγράμματος του ορθογωνίου.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να προσθέσω ένα ορθογώνιο με στρογγυλεμένες γωνίες;**

Χρησιμοποιήστε τον τύπο σχήματος [shape type] με στρογγυλεμένες γωνίες και προσαρμόστε την ακτίνα γωνίας στις ιδιότητες του σχήματος· η στρογγυλοποίηση μπορεί επίσης να εφαρμοστεί ανά γωνία μέσω γεωμετρικών ρυθμίσεων.

**Πώς μπορώ να γεμίσω ένα ορθογώνιο με εικόνα (υφή);**

Επιλέξτε τον τύπο γεμίσματος εικόνας [fill type], δώστε την πηγή της εικόνας και ρυθμίστε τους τρόπους [stretching/tiling modes].

**Μπορεί ένα ορθογώνιο να έχει σκιά και λάμψη;**

Ναι. Οι [Outer/inner shadow, glow, and soft edges](/slides/el/python-java/shape-effect/) είναι διαθέσιμες με παραμετρική ρύθμιση.

**Μπορώ να μετατρέψω ένα ορθογώνιο σε κουμπί με υπερσύνδεσμο;**

Ναι. [Assign a hyperlink](/slides/el/python-java/manage-hyperlinks/) στο κλικ του σχήματος (μετάβαση σε διαφάνεια, αρχείο, διεύθυνση ιστού ή e‑mail).

**Πώς μπορώ να προστατεύσω ένα ορθογώνιο από μετακίνηση και αλλαγές;**

[Use shape locks](/slides/el/python-java/applying-protection-to-presentation/): μπορείτε να απαγορεύσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή ή την επεξεργασία κειμένου για να διατηρήσετε τη διάταξη.

**Μπορώ να μετατρέψω ένα ορθογώνιο σε ραστερ εικόνα ή SVG;**

Ναι. Μπορείτε να [render the shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage) σε εικόνα με καθορισμένο μέγεθος/κλίμακα ή [export it as SVG](/slides/el/python-java/create-shape-thumbnails/) για διανυσματική χρήση.

**Πώς μπορώ γρήγορα να λάβω τις πραγματικές (αποτελεσματικές) ιδιότητες ενός ορθογωνίου λαμβάνοντας υπόψη το θέμα και την κληρονομικότητα;**

[Use the shape’s effective properties](/slides/el/python-java/shape-effective-properties/): το API επιστρέφει υπολογισμένες τιμές που λαμβάνουν υπόψη τα στυλ θέματος, τη διάταξη και τις τοπικές ρυθμίσεις, απλοποιώντας την ανάλυση μορφοποίησης.