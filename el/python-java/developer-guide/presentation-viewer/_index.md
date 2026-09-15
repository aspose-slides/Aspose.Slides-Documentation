---
title: Δημιουργία προβολέα παρουσίασης σε Python μέσω Java
linktitle: Προβολέας Παρουσίασης
type: docs
weight: 50
url: /el/python-java/presentation-viewer/
keywords:
- προβολή παρουσίασης
- προβολέας παρουσίασης
- δημιουργία προβολέα παρουσίασης
- προβολή PPT
- προβολή PPTX
- προβολή ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε έναν προσαρμοσμένο προβολέα παρουσίασης σε Python μέσω Java χρησιμοποιώντας το Aspose.Slides. Εμφανίστε εύκολα αρχεία PowerPoint και OpenDocument χωρίς το Microsoft PowerPoint."
---
## **Εισαγωγή**

Aspose.Slides for Python via Java χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης με διαφάνειες. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τις παρουσιάσεις σε Microsoft PowerPoint, για παράδειγμα. Ωστόσο, κάποιες φορές οι προγραμματιστές ενδέχεται να θέλουν να εμφανίσουν τις διαφάνειες ως εικόνες στον προτιμώμενο προβολέα εικόνων ή να δημιουργήσουν τον δικό τους προβολέα παρουσίασης. Σε τέτοιες περιπτώσεις, το Aspose.Slides επιτρέπει την εξαγωγή μιας μεμονωμένης διαφάνειας ως εικόνας. Αυτό το άρθρο περιγράφει πώς να το κάνετε.

## **Δημιουργία εικόνας SVG από διαφάνεια**

Για τη δημιουργία εικόνας SVG από διαφάνεια παρουσίασης με το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
1. Αποκτήστε την αναφορά στη διαφάνεια με το δείκτη της.
1. Ανοίξτε μια ροή byte.
1. Αποθηκεύστε τη διαφάνεια ως εικόνα SVG στη ροή και γράψτε την σε αρχείο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Δημιουργία SVG με προσαρμοσμένο αναγνωριστικό σχήματος**

Το Aspose.Slides μπορεί να χρησιμοποιηθεί για τη δημιουργία ενός [SVG](https://docs.fileformat.com/page-description-language/svg/) από μια διαφάνεια με προσαρμοσμένο αναγνωριστικό σχήματος. Για να το κάνετε αυτό, χρησιμοποιήστε τη μέθοδο [SvgShape.setId](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgshape/#setId) από το [SvgShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgshape/). Η κλάση `CustomSvgShapeFormattingController` μπορεί να χρησιμοποιηθεί για τον ορισμό του αναγνωριστικού σχήματος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Δημιουργία μικρογραφίας διαφάνειας**

Το Aspose.Slides σας βοηθά να δημιουργήσετε μικρογραφίες διαφάνειας. Για τη δημιουργία μικρογραφίας μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
1. Αποκτήστε την αναφορά στη διαφάνεια με το δείκτη της.
1. Λάβετε τη μικρογραφία της αναφερόμενης διαφάνειας σε καθορισμένο κλίμακα.
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Δημιουργία μικρογραφίας διαφάνειας με προσαρμοσμένες διαστάσεις**

Για τη δημιουργία μικρογραφίας διαφάνειας με προσαρμοσμένες διαστάσεις, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
1. Αποκτήστε την αναφορά στη διαφάνεια με το δείκτη της.
1. Λάβετε τη μικρογραφία της αναφερόμενης διαφάνειας με τις καθορισμένες διαστάσεις.
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Δημιουργία μικρογραφίας διαφάνειας με σημειώσεις ομιλητή**

Για τη δημιουργία μικρογραφίας μιας διαφάνειας με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [RenderingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/) .
1. Χρησιμοποιήστε τη μέθοδο [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) για τον καθορισμό της θέσης των σημειώσεων ομιλητή.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
1. Αποκτήστε την αναφορά στη διαφάνεια με το δείκτη της.
1. Λάβετε τη μικρογραφία της αναφερόμενης διαφάνειας με τις επιλογές απόδοσης.
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Ζωντανό Παράδειγμα**

Μπορείτε να δοκιμάσετε τη δωρεάν εφαρμογή [**Aspose.Slides Viewer**](https://products.aspose.app/slides/el/viewer/) για να δείτε τι μπορείτε να υλοποιήσετε με το API του Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **Συχνές ερωτήσεις**

**Μπορώ να ενσωματώσω έναν προβολέα παρουσίασης σε μια web εφαρμογή;**

Ναι. Μπορείτε να χρησιμοποιήσετε το Aspose.Slides στον διακομιστή για να αποδίδετε τις διαφάνειες ως εικόνες ή HTML και να τις εμφανίζετε στον φυλλομετρητή. Οι λειτουργίες πλοήγησης και ζουμ μπορούν να υλοποιηθούν με JavaScript για διαδραστική εμπειρία.

**Ποιος είναι ο καλύτερος τρόπος για να εμφανίσω τις διαφάνειες μέσα σε προσαρμοσμένο προβολέα;**

Η συνιστώμενη προσέγγιση είναι να αποδίδετε κάθε διαφάνεια ως εικόνα (π.χ., PNG ή SVG) ή να την μετατρέπετε σε HTML χρησιμοποιώντας το Aspose.Slides και στη συνέχεια να εμφανίζετε το αποτέλεσμα σε ένα picture box (για desktop) ή σε ένα HTML container (για web).

**Πώς μπορώ να διαχειριστώ μεγάλες παρουσιάσεις με πολλές διαφάνειες;**

Για μεγάλες συλλογές, εξετάστε την καθυστερημένη φόρτωση ή την απόδοση κατόπιν ζήτησης των διαφανειών. Αυτό σημαίνει ότι παράγετε το περιεχόμενο μιας διαφάνειας μόνο όταν ο χρήστης πλοηγηθεί σε αυτήν, μειώνοντας τη χρήση μνήμης και το χρόνο φόρτωσης.