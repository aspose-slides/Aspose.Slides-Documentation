---
title: Σχήματα παρουσίασης ομάδας σε Python μέσω Java
linktitle: Ομάδα Σχημάτων
type: docs
weight: 40
url: /el/python-java/group/
keywords:
- ομαδικό σχήμα
- ομάδα σχημάτων
- προσθήκη ομάδας
- εναλλακτικό κείμενο
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να ομαδοποιείτε και να αποομαδοποιείτε σχήματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Python μέσω Java—οδηγός βήμα προς βήμα με δωρεάν κώδικα Python."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με ομαδικά σχήματα στο Aspose.Slides. Δείχνει πώς να προσθέσετε ένα ομαδικό σχήμα σε μια διαφάνεια, να τοποθετήσετε σχήματα μέσα του και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επίσης, επιδεικνύει πώς να έχετε πρόσβαση σε σχήματα που είναι αποθηκευμένα μέσα σε μια ομάδα και να διαβάσετε το εναλλακτικό κείμενό τους χρησιμοποιώντας [getAlternativeText](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getAlternativeText). Επιπλέον, το άρθρο καλύπτει εν συντομία σχετικές δυνατότητες ομαδικών σχημάτων όπως ένθετες ομάδες, σειρά z και επιλογές κλειδώματος.

## **Προσθήκη Ομαδικού Σχήματος**

Το Aspose.Slides υποστηρίζει την εργασία με ομαδικά σχήματα σε διαφάνειες. Αυτή η δυνατότητα βοηθά τους προγραμματιστές να δημιουργούν πλουσιότερες παρουσιάσεις. Το Aspose.Slides for Python via Java υποστηρίζει την προσθήκη και την πρόσβαση σε ομαδικά σχήματα. Μπορείτε να γεμίσετε ένα ομαδικό σχήμα με σχήματα ή να έχετε πρόσβαση στις ιδιότητές του. Για να προσθέσετε ένα ομαδικό σχήμα σε μια διαφάνεια χρησιμοποιώντας Aspose.Slides for Python via Java:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα ομαδικό σχήμα στη διαφάνεια.
1. Προσθέστε σχήματα στο ομαδικό σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει ένα ομαδικό σχήμα σε μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Δημιουργία αντικειμένου της κλάσης Presentation.
presentation = Presentation()
try:
    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Πρόσβαση στη συλλογή σχημάτων της διαφάνειας.
    slide_shapes = slide.getShapes()

    # Προσθήκη ομαδικού σχήματος στη διαφάνεια.
    group_shape = slide_shapes.addGroupShape()

    # Προσθήκη σχημάτων μέσα στο ομαδικό σχήμα.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Ορισμός πλαισίου του ομαδικού σχήματος.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Πρόσβαση στο Εναλλακτικό Κείμενο**

Αυτή η ενότητα δείχνει πώς να έχετε πρόσβαση στο εναλλακτικό κείμενο των σχημάτων μέσα σε μια ομάδα σε μια διαφάνεια. Για να αποκτήσετε πρόσβαση σε αυτό το κείμενο χρησιμοποιώντας Aspose.Slides for Python via Java:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που αντιπροσωπεύει ένα αρχείο PPTX.
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Πρόσβαση στη συλλογή σχημάτων της διαφάνειας.
1. Πρόσβαση στο ομαδικό σχήμα.
1. Διαβάστε το εναλλακτικό κείμενο των σχημάτων του χρησιμοποιώντας [getAlternativeText](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getAlternativeText).

Το παρακάτω παράδειγμα αποκτά πρόσβαση στο εναλλακτικό κείμενο των σχημάτων μέσα σε μια ομάδα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο PPTX.
presentation = Presentation("AltText.pptx")
try:
    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Πρόσβαση σε σχήμα στη συλλογή σχημάτων της διαφάνειας.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Πρόσβαση στα σχήματα μέσα στην ομάδα.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Ανάγνωση του εναλλακτικού κειμένου.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται η ένθετη ομαδοποίηση (μια ομάδα μέσα σε άλλη ομάδα);**

Ναι. Η κλάση [GroupShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/groupshape/) διαθέτει τη μέθοδο [getParentGroup](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getParentGroup), η οποία υποδεικνύει υποστήριξη ιεραρχίας: μια ομάδα μπορεί να είναι παιδί άλλης ομάδας.

**Πώς μπορώ να ελέγξω τη σειρά z της ομάδας σε σχέση με άλλα αντικείμενα στη διαφάνεια;**

Χρησιμοποιήστε τη μέθοδο [getZOrderPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getZOrderPosition) του αντικειμένου [GroupShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/groupshape/) για να ελέγξετε τη θέση του στην στοίβα εμφάνισης.

**Μπορώ να αποτρέψω τη μετακίνηση, την επεξεργασία ή την αποομαδοποίηση;**

Ναι. Τα κλειδώματα της ομάδας εκτίθενται μέσω της μεθόδου [getGroupShapeLock](https://reference.aspose.com/slides/el/python-java/aspose.slides/groupshape/#getGroupShapeLock), η οποία σας επιτρέπει να περιορίσετε τις λειτουργίες στο αντικείμενο.