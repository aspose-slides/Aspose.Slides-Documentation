---
title: Απόδοση Διαφανειών Παρουσίασης ως Εικόνες SVG σε Python μέσω Java
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
description: "Εξαγωγή διαφανειών PowerPoint ως εικόνες SVG σε Python μέσω Java και έλεγχος γραμματοσειρών, κειμένου, εικόνων, IDs και συμβάντων με Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μια κλιμακώσιμη μορφή εικόνας βασισμένη σε XML η οποία λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, διαδικασίες προσβασιμότητας και αυτοματοποιημένη μετα-επεξεργασία. Το Aspose.Slides εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγχετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) όταν το εξαχθέν SVG πρέπει να είναι συμπαγές, προβλέψιμο σε διαφορετικά προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή χρησιμοποιώντας το [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Τα παραδείγματα απαιτούν ένα υπάρχον αρχείο `presentation.pptx`. Κάθε παράδειγμα ξεκινά τη JVM αν χρειάζεται και κλείνει τις ροές εξόδου. Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια μιας παρουσίασης σε ξεχωριστό αρχείο SVG.

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

Το όνομα αρχείου χρησιμοποιεί το [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) αντί για τον δείκτη του βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο αυτό το σχήμα.

## **Διαμόρφωση εξόδου SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) ελέγχει τη σχεδίαση του SVG. Για πλαίσια κειμένου, το [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή σχεδίασης, και το [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) καθορίζει αν η περιστροφή του πλαισίου εφαρμόζεται. Ορίστε το [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) σε `True` όταν το κείμενο πρέπει να αποδίδεται χωρίς λιγατούρες.

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

## **Έλεγχος περικοπής άκρων γραμμής στα άκρα βελών**

Το SVG 1.1 δεν διαθέτει ρύθμιση εσοχής σημαδιού για τον καθορισμό του σημείου όπου μια γραμμή πρέπει να σταματήσει κάτω από ένα βέλος. Από προεπιλογή, το Aspose.Slides συντομεύει την εξαχθείσα γραμμή ώστε η γραμμή δεν διαπλέει το σήμα. Καλέστε το [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) με `True` για να σχεδιάσετε τη γραμμή μέχρι το αρχικό άκρο της. Αυτή η ρύθμιση επηρεάζει μόνο την έξοδο SVG. Η γραμμή διατηρεί τη θέση και το μήκος της στη διαφάνεια.

Το παράδειγμα σχεδιάζει τριγωνικά και διαμαντικά άκρα βελών σε γραμμές πλάτους 2 και 10 σημεία. Εξάγει την ίδια διαφάνεια δύο φορές, αλλάζοντας μόνο την επιλογή περικοπής.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Η σύγκριση δείχνει το τριγωνικό άκρο βέλους στη γραμμή 10 σημείων. Με την περικοπή ενεργοποιημένη, η άκρη είναι κοφτερή. Με την περικοπή ανενεργή, η γραμμή διαπλέει τις πλαϊνές πλευρές του σημείου και αφήνει ένα επίπεδο άκρο.

![Μεγέθυνση τριγώνου 10 σημείων με αιχμή κοφτερή όταν η περικοπή είναι ενεργή και επίπεδο άκρο όταν η περικοπή είναι ανενεργή](line-end-cropping.png)

Στις άλλες γραμμές του παραδείγματος, η διαπρεστέα γραμμή είναι λιγότερο ορατή στο τριγωνικό άκρο 2 σημείων. Το γεμιστό διαμάντι καλύπτει το άκρο της γραμμής και στις δύο διαστάσεις.

## **Έλεγχος κειμένου και γραμματοσειρών**

Κατά την εξαγωγή διαφανειών σε SVG, μπορείτε να ελέγξετε αν το κείμενο παραμένει ως κείμενο ή μετατρέπεται σε διανυσματικά γραφικά, και πώς περιλαμβάνονται ή παραπέμπονται οι εξωτερικές γραμματοσειρές. Οι ακόλουθες επιλογές βοηθούν στην εξισορρόπηση της οπτικής συνέπειας, της επιλογής κειμένου και των εξαρτήσεων γραμματοσειρών στο εξαχθέν SVG.

### **Διάνυσμα Όλων του Κειμένου**

Ορίστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) σε `True` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις γραμματοσειρών και κάνει το οπτικό αποτέλεσμα πιο συνεπές μεταξύ των προγραμμάτων περιήγησης, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

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

### **Επιλέξτε Πώς Διαχειρίζονται οι Εξωτερικές Γραμματοσειρές**

Το [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) για γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να παραπέμψετε σε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να συμπεριλάβετε τα δεδομένα γραμματοσειράς στο SVG, ή `Vectorize` για να αποδώσετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε την άδεια χρήσης της γραμματοσειράς πριν την ενσωματώσετε.

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

## **Μείωση Μεγέθους Ενσωματωμένων Εικόνων**

Χρησιμοποιήστε το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) για να παραλείψετε περιοχές της πηγής που έχουν περικοπεί, και το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος στην πιστότητα της εικόνας ή στα δεδομένα που διατηρούνται.

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

## **Έλεγχος Ανάλυσης Rasterization Μετααρχείου**

Το [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) ορίζει το χαμηλότερο όριο ανάλυσης για τη rasterization μετααρχείων κατά την εξαγωγή SVG. Χρησιμοποιήστε το για να ισορροπήσετε λεπτομέρεια και μέγεθος αρχείου όταν μια εικόνα EMF ή WMF rasterizes. Δεν ορίζει μια καθολική τιμή DPI για το SVG ούτε εξαναγκάζει κάθε αντικείμενο στη διαφάνεια να γίνει raster εικόνα.

Κατεβάστε το [metafile-rasterization.pptx](metafile-rasterization.pptx), το οποίο περιλαμβάνει μια εικόνα EMF με στενά διαδοχικές διαγώνιες γραμμές. Το παρακάτω παράδειγμα εξάγει την πρώτη του διαφάνεια σε τρεις αναλύσεις rasterization μέσω του [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Όλες οι άλλες ρυθμίσεις εξαγωγής παραμένουν ίδιες ώστε τα αποτελέσματα να μπορούν να συγκριθούν.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Στην έξοδο, το EMF μετατράπηκε σε ένα ενσωματωμένο PNG σε κάθε SVG. Οι παρακάτω μετρήσεις αφορούν την παρεχόμενη παρουσίαση· δεν αποτελούν γενικό τύπο μετατροπής DPI σε διαστάσεις εικονοστοιχείου.

| DPI rasterization Μετααρχείου | Διαστάσεις ενσωματωμένου PNG | Μέγεθος αρχείου SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Η σύγκριση παρακάτω δείχνει την ίδια περιοχή του ενσωματωμένου raster στην ίδια μεγενθυμένη προβολή. Οι διαγώνιες γραμμές εμφανίζουν ορατό pixelation στα 72 DPI και πιο ομαλές άκρες σε υψηλότερες αναλύσεις, ενώ το αρχείο SVG μεγαλώνει. Η αύξηση της τιμής δεν βελτιώνει απαραίτητα κάθε λεπτομέρεια ή δεν αλλάζει κάθε εξαχθείσα εικόνα.

![Μεγέθυνση λεπτομέρειας διαγώνιων γραμμών σε 72, 150 και 300 DPI](metafile-rasterization-comparison.png)

Το [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) ελέγχει τη μείωση ανάλυσης εικόνας και μπορεί να καλύψει το αποτέλεσμα της αλλαγής της ανάλυσης rasterization μετααρχείου. Το [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) ελέγχει την ποιότητα κωδικοποίησης JPEG, όχι την ανάλυση rasterization μετααρχείου.

## **Ανάθεση Σταθερών IDs σε Σχήματα και Κείμενο**

Χρησιμοποιήστε έναν ελεγκτή μορφοποίησης Python εγγεγραμμένο μέσω `jpype.JProxy` για να αναθέσετε τιμές [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) σε σχήματα και τιμές [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) σε στοιχεία κειμένου `tspan`. Αναθέστε τον διαμεσολαβητή με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Ο παρακάτω ελεγκτής χρησιμοποιεί το [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), το οποίο είναι σταθερό για τη διάρκεια ζωής του σχήματος, και έναν επαναλήψιμο μετρητή για τα κειμενικά spans. Αυτό καθιστά τα παραγόμενα IDs κατάλληλα για μετα-επεξεργασία μιας αμετάβλητης παρουσίασης.

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

## **Προσθήκη Χειριστών Συμβάντων SVG**

Σε έναν ελεγκτή μορφοποίησης Python, καλέστε το [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) για να προσθέσετε έναν χειριστή JavaScript σε ένα εξαχθέν σχήμα. Εγγεγραψτε τον ελεγκτή μέσω `jpype.JProxy` και αναθέστε τον με το [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Ορίστε τη λειτουργία JavaScript στη σελίδα ή στο έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

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

Η σελίδα-ξενιστής μπορεί να ορίσει τη λειτουργία JavaScript που γίνεται αναφορά από τον χειριστή. Η ανάθεση IDs και χειριστών συμβάντων καθιστά δυνατές προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πότε θα πρέπει να χρησιμοποιήσω [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) αντί για [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize);**

Χρησιμοποιήστε το [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος να κάνω ένα SVG μικρότερο;**

Ξεκινήστε με τη συμπίεση των ενσωματωμένων εικόνων, τη διαγραφή των περικομμένων περιοχών εικόνας και την επιλογή συνδεδεμένων αρχείων γραμματοσειρών όταν το περιβάλλον-στόχος μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και το διανυσματικό κείμενο έχουν διαφορετικές ανταλλαγές ποιότητας‑μεγέθους.

**Μπορώ να τροποποιήσω τα εξαχθέντα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Αναθέστε IDs μέσω ενός ελεγκτή μορφοποίησης και, στη συνέχεια, επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο μετα‑επεξεργασίας ή στο σενάριο του προγράμματος περιήγησης.