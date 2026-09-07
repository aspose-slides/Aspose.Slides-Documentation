---
title: Απόδοση διαφανειών παρουσίασης ως εικόνες SVG σε Python μέσω Java
linktitle: Διαφάνεια σε SVG
type: docs
weight: 50
url: /el/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint σε SVG
- παρουσίαση σε SVG
- διαφάνεια σε SVG
- PPT σε SVG
- PPTX σε SVG
- επιλογές εξαγωγής SVG
- διαδραστικό SVG
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εξαγωγή διαφανειών PowerPoint ως εικόνες SVG σε Python μέσω Java και έλεγχος γραμματοσειρών, κειμένου, εικόνων, ταυτοτήτων και συμβάντων με Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μορφή εικόνας βασισμένη σε κλιμακώσιμο XML που λειτουργεί καλά για τη δημοσίευση στον ιστό, προβολείς διαφανειών, ροές εργασίας προσβασιμότητας και αυτοματοποιημένη μετα-επεξεργασία. Το Aspose.Slides εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγχετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/) όταν το εξαγόμενο SVG πρέπει να είναι συμπαγές, προβλέψιμο μεταξύ προγραμμάτων περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή με την [Slide.writeAsSvg](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/). Τα παραδείγματα απαιτούν ένα υπάρχον αρχείο `presentation.pptx`. Κάθε παράδειγμα ξεκινά το JVM αν χρειάζεται και κλείνει τις ροές εξόδου του. Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια σε μια παρουσίαση ως ξεχωριστό αρχείο SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Το όνομα αρχείου χρησιμοποιεί το [Slide.getSlideNumber](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getSlideNumber) αντί του δείκτη βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [Shape.writeAsSvg](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο αυτό το σχήμα.

## **Διαμόρφωση εξόδου SVG**

Το [SVGOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαίσια κειμένου, το [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setUseFrameSize) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και το [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setUseFrameRotation) καθορίζει αν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) σε `True` όταν το κείμενο πρέπει να αποδοθεί χωρίς λιγκατούρες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Έλεγχος κειμένου και γραμματοσειρών**

### **Διανυσματοποίηση όλου του κειμένου**

Ορίστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setVectorizeText) σε `True` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις από γραμματοσειρές και κάνει το οπτικό αποτέλεσμα πιο συνεπές μεταξύ προγραμμάτων περιήγησης, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Επιλέξτε πώς θα διαχειριστούν οι εξωτερικές γραμματοσειρές**

Το [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgexternalfontshandling/) για γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να αναφέρετε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να ενσωματώσετε τα δεδομένα γραμματοσειράς στο SVG, ή `Vectorize` για να αποδώσετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε την άδεια χρήσης των γραμματοσειρών πριν τις ενσωματώσετε.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Μείωση του μεγέθους ενσωματωμένων εικόνων**

Χρησιμοποιήστε το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setPicturesCompression) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) για να παραλείψετε τις περικομμένες περιοχές προέλευσης, και το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setJpegQuality) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου εις βάρος της πιστότητας της εικόνας ή των διατηρημένων δεδομένων εικόνας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Ανάθεση σταθερών ταυτοτήτων σε σχήματα και κείμενο**

Χρησιμοποιήστε έναν ελεγκτή μορφοποίησης Python που καταχωρίζεται μέσω του `jpype.JProxy` για να αναθέσετε τιμές [SvgShape.setId](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgshape/#setId) σε σχήματα και τιμές [SvgTSpan.setId](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgtspan/#setId) σε στοιχεία κειμένου `tspan`. Αναθέστε το διαμεσολαβητή με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Ο παρακάτω ελεγκτής χρησιμοποιεί το [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getOfficeInteropShapeId), το οποίο είναι σταθερό για τη διάρκεια ζωής του σχήματος, και έναν επαναλαμβανόμενο μετρητή για τα κείμενα του. Αυτό καθιστά τα παραγόμενα IDs κατάλληλα για μετα-επεξεργασία μιας αμετάβλητης παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Προσθήκη χειριστών συμβάντων SVG**

Σε έναν ελεγκτή μορφοποίησης Python, καλέστε το [SvgShape.setEventHandler](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgshape/#setEventHandler) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgevent/) για να προσθέσετε έναν χειριστή JavaScript σε ένα εξαγόμενο σχήμα. Καταχωρίστε τον ελεγκτή μέσω του `jpype.JProxy` και αναθέστε τον με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Ορίστε τη λειτουργία JavaScript στη σελίδα ή στο έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

Η σελίδα‑υποδοχέα μπορεί να ορίσει τη λειτουργία JavaScript που αναφέρεται από το χειριστή. Η ανάθεση IDs και χειριστών συμβάντων ενεργοποιεί τους προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **Συχνές ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setVectorizeText) αντί του [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgexternalfontshandling/#Vectorize);**

Χρησιμοποιήστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgoptions/#setVectorizeText) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος για να μειώσετε το μέγεθος ενός SVG;**

Ξεκινήστε με τη συμπίεση των ενσωματωμένων εικόνων, τη διαγραφή των περικομμένων περιοχών εικόνας και την επιλογή συνδεδεμένων αρχείων γραμματοσειρών όταν το περιβάλλον-στόχος μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα, γιατί η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και το κείμενο που έχει διανυσματοποιηθεί έχουν διαφορετικές ανταλλαγές ποιότητας‑μεγέθους.

**Μπορώ να τροποποιήσω τα εξαγόμενα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Αναθέστε IDs μέσω ενός ελεγκτή μορφοποίησης, στη συνέχεια επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο μετα-επεξεργασίας ή στο σενάριο του προγράμματος περιήγησης.