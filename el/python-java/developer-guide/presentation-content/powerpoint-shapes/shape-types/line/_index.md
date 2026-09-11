---
title: Προσθήκη Σχημάτων Γραμμής σε Παρουσιάσεις με Python μέσω Java
linktitle: Γραμμή
type: docs
weight: 50
url: /el/python-java/line/
keywords:
- γραμμή
- δημιουργία γραμμής
- προσθήκη γραμμής
- απλή γραμμή
- διαμόρφωση γραμμής
- προσαρμογή γραμμής
- στυλ παύλας
- κεφαλή βέλους
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να χειρίζεστε τη μορφοποίηση γραμμών σε παρουσιάσεις PowerPoint με Aspose.Slides για Python μέσω Java. Ανακαλύψτε ιδιότητες, μεθόδους και παραδείγματα."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να προσθέτετε σχήματα γραμμής στις διαφάνειες του PowerPoint προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια απλή γραμμή και πώς να προσαρμόσετε μια γραμμή ώστε να εμφανίζεται ως βέλος.

Θα μάθετε πώς να προσθέσετε ένα σχήμα γραμμής σε μια διαφάνεια, να προσαρμόσετε την οπτική του εμφάνιση και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Τα παραδείγματα εστιάζουν σε πρακτικές ρυθμίσεις μορφοποίησης γραμμής όπως το στυλ, το πάχος, το μοτίβο διακεκομμένων, οι επιλογές κεφαλής βέλους και το χρώμα γεμίσματος.

## **Δημιουργία Απλής Γραμμής**

Για να προσθέσετε μια απλή γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
- Λάβετε μια αναφορά σε μια διαφάνεια κατά το δείκτη της.
- Προσθέστε ένα σχήμα γραμμής χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addAutoShape) του αντικειμένου [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/).
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει μια γραμμή στην πρώτη διαφάνεια της παρουσίασης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει το αρχείο PPTX.
presentation = Presentation()
try:
    # Αποκτήστε την πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Προσθέστε ένα σχήμα γραμμής.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Δημιουργία Γραμμής σε Σχήμα Βέλους**

Το Aspose.Slides for Python via Java επίσης επιτρέπει στους προγραμματιστές να διαμορφώσουν τις ιδιότητες μιας γραμμής ώστε αυτή να φαίνεται πιο ελκυστική. Για να διαμορφώσετε μια γραμμή ώστε να μοιάζει με βέλος, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
- Λάβετε μια αναφορά σε μια διαφάνεια κατά το δείκτη της.
- Προσθέστε ένα σχήμα γραμμής χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addAutoShape) του αντικειμένου [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/).
- Ορίστε το [line style](https://reference.aspose.com/slides/el/python-java/aspose.slides/linestyle/) σε ένα από τα στυλ που προσφέρει το Aspose.Slides for Python via Java.
- Ορίστε το πλάτος της γραμμής.
- Ορίστε το [dash style](https://reference.aspose.com/slides/el/python-java/aspose.slides/linedashstyle/) σε ένα από τα στυλ που προσφέρει το Aspose.Slides for Python via Java.
- Ορίστε το [arrowhead style](https://reference.aspose.com/slides/el/python-java/aspose.slides/linearrowheadstyle/) και το [length](https://reference.aspose.com/slides/el/python-java/aspose.slides/linearrowheadlength/) στην αρχή της γραμμής.
- Ορίστε το [arrowhead style](https://reference.aspose.com/slides/el/python-java/aspose.slides/linearrowheadstyle/) και το [length](https://reference.aspose.com/slides/el/python-java/aspose.slides/linearrowheadlength/) στο τέλος της γραμμής.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει το αρχείο PPTX.
presentation = Presentation()
try:
    # Αποκτήστε την πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Προσθέστε ένα σχήμα γραμμής.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Εφαρμόστε μορφοποίηση στη γραμμή.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια κανονική γραμμή σε σύνδεσμο ώστε να «προσαρμόζεται» σε σχήματα;**

Όχι. Μια κανονική γραμμή (ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) τύπου [Line](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/)) δεν μετατρέπεται αυτόματα σε σύνδεσμο. Για να την προσαρμόσετε σε σχήματα, χρησιμοποιήστε τον ειδικό τύπο [Connector](https://reference.aspose.com/slides/el/python-java/aspose.slides/connector/) και τις [corresponding APIs](/slides/el/python-java/connector/) για συνδέσεις.

**Τι πρέπει να κάνω αν οι ιδιότητες μιας γραμμής κληρονομούνται από το θέμα και είναι δύσκολο να προσδιοριστούν οι τελικές τιμές;**

Διαβάστε τις [αποτελεσματικές ιδιότητες](/slides/el/python-java/shape-effective-properties/) της γραμμής και του γεμίσματος—αυτά ήδη λαμβάνουν υπόψη την κληρονομικότητα και τα στυλ θέματος.

**Μπορώ να κλειδώσω μια γραμμή ώστε να μην μπορεί να επεξεργαστεί (μετακινηθεί, αλλάξει το μέγεθός της);**

Ναι. Τα σχήματα παρέχουν [αντικείμενα κλειδώματος](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/#getAutoShapeLock) που σας επιτρέπουν να [απαγορεύσετε τις λειτουργίες επεξεργασίας](/slides/el/python-java/applying-protection-to-presentation/).