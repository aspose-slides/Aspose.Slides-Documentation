---
title: Δημιουργία Σχημάτων Γραμμής σε Παρουσιάσεις με Python
linktitle: Γραμμή
type: docs
weight: 50
url: /el/python-net/line/
keywords:
- γραμμή
- δημιουργία γραμμής
- προσθήκη γραμμής
- απλή γραμμή
- ρύθμιση γραμμής
- προσαρμογή γραμμής
- στυλ παύλας
- κεφαλή βέλους
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τη μορφοποίηση γραμμών σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω .NET. Ανακαλύψτε ιδιότητες, μεθόδους και παραδείγματα."
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω .NET υποστηρίζει την προσθήκη διαφορετικών τύπων σχήματων στις διαφάνειες. Σε αυτό το θέμα, θα αρχίσουμε να δουλεύουμε με σχήματα προσθέτοντας γραμμές στις διαφάνειες. Χρησιμοποιώντας το Aspose.Slides, οι προγραμματιστές μπορούν όχι μόνο να δημιουργούν απλές γραμμές, αλλά μπορούν επίσης να σχεδιάζουν μερικές πολύπλοκες γραμμές στις διαφάνειες.

## **Δημιουργία Απλών Γραμμών**

Χρησιμοποιήστε το Aspose.Slides για να προσθέσετε μια απλή γραμμή σε μια διαφάνεια ως απλό διαχωριστικό ή σύνδεσμο. Για να προσθέσετε μια απλή γραμμή σε μια επιλεγμένη διαφάνεια σε μια παρουσίαση, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά στη διαφάνεια με βάση το δείκτη.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) τύπου `LINE` χρησιμοποιώντας τη μέθοδο `add_auto_shape` στο αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/).
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, μια γραμμή προστίθεται στην πρώτη διαφάνεια της παρουσίασης.

```py
import aspose.slides as slides

# Δημιουργία (αρχικοποίηση) της κλάσης Presentation.
with slides.Presentation() as presentation:

    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.slides[0]

    # Προσθήκη αυτοσχήματος τύπου LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Δημιουργία Γραμμών Σε Σχήμα Βέλους**

Το Aspose.Slides σας επιτρέπει να διαμορφώσετε τις ιδιότητες της γραμμής ώστε να είναι πιο ελκυστικές οπτικά. Παρακάτω, διαμορφώνουμε μερικές ιδιότητες μιας γραμμής ώστε να μοιάζει με βέλος. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) τύπου `LINE` χρησιμοποιώντας τη μέθοδο `add_auto_shape` στο αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/).
1. Ορίστε το [στυλ γραμμής](https://reference.aspose.com/slides/el/python-net/aspose.slides/linestyle/).
1. Ορίστε το πλάτος της γραμμής.
1. Ορίστε το [στυλ παύλας](https://reference.aspose.com/slides/el/python-net/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το [στυλ κεφαλής βέλους](https://reference.aspose.com/slides/el/python-net/aspose.slides/linearrowheadstyle/) και το μήκος για το αρχικό σημείο της γραμμής.
1. Ορίστε το στυλ κεφαλής βέλους και το μήκος για το τελικό σημείο της γραμμής.
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργία (αρχικοποίηση) της κλάσης Presentation που αντιπροσωπεύει το αρχείο PPTX.
with slides.Presentation() as presentation:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.slides[0]

    # Προσθήκη αυτοσχήματος τύπου LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Εφαρμογή μορφοποίησης στη γραμμή.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια κανονική γραμμή σε σύνδεσμο ώστε να «προσαρμόζεται» στα σχήματα;**

Όχι. Μια κανονική γραμμή (ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) τύπου [LINE](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapetype/)) δεν μετατρέπεται αυτόματα σε σύνδεσμο. Για να προσαρμόζεται στα σχήματα, χρησιμοποιήστε τον εξειδικευμένο τύπο [Connector](https://reference.aspose.com/slides/el/python-net/aspose.slides/connector/) και τις [αντίστοιχες API](/slides/el/python-net/connector/) για συνδέσεις.

**Τι πρέπει να κάνω εάν οι ιδιότητες μιας γραμμής κληρονομούνται από το θέμα και είναι δύσκολο να προσδιοριστούν οι τελικές τιμές;**

Διαβάστε τις αποτελεσματικές ιδιότητες [/slides/el/python-net/shape-effective-properties/] μέσω των κλάσεων [ILineFormatEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ilinefillformateffectivedata/)—αυτές ήδη λαμβάνουν υπόψη την κληρονομιά και τα στυλ του θέματος.

**Μπορώ να κλειδώσω μια γραμμή ώστε να μην μπορεί να επεξεργαστεί (να μετακινηθεί, να αλλάξει μέγεθος);**

Ναι. Τα σχήματα παρέχουν [αντικείμενα κλειδαριάς](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/auto_shape_lock/) που σας επιτρέπουν να [απαγορεύσετε τις λειτουργίες επεξεργασίας](/slides/el/python-net/applying-protection-to-presentation/).