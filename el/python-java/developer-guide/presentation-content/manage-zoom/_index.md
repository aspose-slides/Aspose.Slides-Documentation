---
title: Διαχείριση Zoom παρουσίασης σε Python μέσω Java
linktitle: Διαχείριση Zoom
type: docs
weight: 60
url: /el/python-java/manage-zoom/
keywords:
- ζουμ
- πλαίσιο ζουμ
- ζουμ διαφάνειας
- ζουμ ενότητας
- ζουμ περίληψης
- προσθήκη ζουμ
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε το Zoom με το Aspose.Slides για Python μέσω Java — μεταβείτε μεταξύ ενοτήτων, προσθέστε μικρογραφίες και μεταβάσεις σε παρουσιάσεις PowerPoint."
---
## **Εισαγωγή**

Τα Zoom του PowerPoint σάς επιτρέπουν να μεταβείτε μεταξύ συγκεκριμένων διαφανειών και ενοτήτων κατά τη διάρκεια μιας παρουσίασης διαφανειών. Με το Aspose.Slides για Python μέσω Java, μπορείτε να δημιουργήσετε zoom διαφανειών, ενοτήτων και περίληψης και να προσαρμόσετε τις προεπισκοπήσεις, τα περιγράμματα και τις μεταβάσεις τους.

![PowerPoint zoom overview](overview.png)

* Για να συνοψίσετε ολόκληρη την παρουσίαση σε μία διαφάνεια, χρησιμοποιήστε ένα [Summary Zoom](#summary-zoom).
* Για να εμφανίσετε μόνο επιλεγμένες διαφάνειες, χρησιμοποιήστε ένα [Slide Zoom](#slide-zoom).
* Για να εμφανίσετε μόνο μία ενότητα, χρησιμοποιήστε ένα [Section Zoom](#section-zoom).

## **Zoom Διαφάνειας**

Το zoom διαφάνειας μπορεί να κάνει την παρουσίασή σας πιο δυναμική, επιτρέποντάς σας να μεταβαίνετε ελεύθερα μεταξύ διαφανειών με οποιαδήποτε σειρά χωρίς να διακόπτετε τη ροή της παρουσίασης. Τα zoom διαφάνειας είναι ιδανικά για σύντομες παρουσιάσεις χωρίς πολλές ενότητες, αλλά μπορείτε να τα χρησιμοποιήσετε και σε διαφορετικά σενάρια παρουσίασης.

Τα zoom διαφάνειας σάς επιτρέπουν να εξερευνήσετε σχετικές πληροφορίες από μία μοναδική διαφάνεια επισκόπησης.

![Selecting slides for a slide zoom](slidezoomsel.png)

Για αντικείμενα zoom διαφάνειας, το Aspose.Slides παρέχει την απαρίθμηση [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/), την κλάση [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) και μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Δημιουργία Καρέ Zoom**

Χρησιμοποιήστε [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) για να τοποθετήσετε συνδέσμους προς μεμονωμένες διαφάνειες σε μία διαφάνεια επισκόπησης. Αυτό το παράδειγμα δημιουργεί δύο διαφάνειες προορισμού με διαφορετικά παρασκήνια και ετικέτες, προσθέτει προεπισκόπηση της κάθε μιας στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση ως PPTX. Οι θέσεις και οι διαστάσεις των καρέ ορίζονται σε points.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Καρέ Zoom με Προσαρμοσμένες Εικόνες**

Περιλάβετε μια προσαρμοσμένη εικόνα στο [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) για να αντικαταστήσετε την προεπιλογή προεπισκόπησης της διαφάνειας-στόχου. Αυτό το παράδειγμα απαιτεί τοπική εικόνα, τη φορτώνει με το [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) και την προσθέτει στην παρουσίαση χρησιμοποιώντας το [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Το δημιουργημένο καρέ εμφανίζει αυτήν την εικόνα ενώ παραμένει συνδεδεμένο με τη δεύτερη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Μορφοποίηση Καρέ Zoom**

Αυτό το παράδειγμα προσαρμόζει δύο καρέ zoom διαφάνειας. Αναθέτει μια τοπική εικόνα στο πρώτο καρέ μέσω του [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) και δίνει στο δεύτερο καρέ ένα 5‑point, dash‑dot ροζ περίγραμμα μέσω του [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat). Με το `False` στο [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) κρύβεται το παρασκήνιο του δεύτερου καρέ. Απαιτείται μια τοπική εικόνα για την προσαρμοσμένη προεπισκόπηση· και τα δύο καρέ διατηρούν τους στόχους των διαφανειών τους στο αποθηκευμένο PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom Ενότητας**

Το zoom ενότητας συνδέεται με μια ενότητα στην παρουσίασή σας. Χρησιμοποιήστε το για να επιστρέψετε σε ένα θέμα ή να δείξετε πώς συνδέονται διαφορετικά τμήματα της παρουσίασης.

![Selecting a section for a section zoom](seczoomsel.png)

Για αντικείμενα zoom ενότητας, το Aspose.Slides παρέχει την κλάση [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) και μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Δημιουργία Καρέ Zoom Ενότητας**

Δημιουργήστε μια ενότητα με το [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection), στη συνέχεια περάστε την επιστρεφόμενη ενότητα στο [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame). Αυτό το παράδειγμα τοποθετεί ένα zoom ενότητας στην πρώτη διαφάνεια και το συνδέει με μια ενότητα που ξεκινά με μια χρωματιστή διαφάνεια. Η θέση και οι διαστάσεις του καρέ ορίζονται σε points, και η παρουσίαση αποθηκεύεται ως PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Δημιουργία Καρέ Zoom Ενότητας με Προσαρμοσμένες Εικόνες**

Η υπερφόρτωση εικόνας του [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) σας επιτρέπει να εμφανίσετε μια προσαρμοσμένη προεπισκόπηση χωρίς να αλλάξετε την προορισμένη ενότητα. Αυτό το παράδειγμα απαιτεί μια τοπική εικόνα, η οποία φορτώνεται με το [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) και προστίθεται μέσω του [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Η αποθηκευμένη παρουσίαση περιέχει ένα zoom ενότητας στην πρώτη διαφάνεια συνδεδεμένο με τη νεοδημιουργημένη ενότητα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Αλλαγή Στόχου Ενότητας Zoom**

Χρησιμοποιήστε το [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection) για να αναπροσανατολίσετε ένα υπάρχον zoom ενότητας χωρίς επαναδημιουργία. Επιλέξτε μια πλημμυρισμένη ενότητα από τη συλλογή [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) της ίδιας παρουσίασης. Η ανάθεση μιας κενής ενότητας αφήνει αμετάβλητο τον τρέχοντα στόχο, γι' αυτό ελέγξτε το [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) πριν το κάνετε. Δείτε το [Manage Slide Sections](/slides/el/python-java/slide-section/) για περισσότερα σχετικά με τις ενότητες.

Το παρακάτω παράδειγμα φορτώνει ένα αρχείο παρουσίασης, το οποίο πρέπει να περιέχει πολλές πλημμυρισμένες ενότητες, ένα υπάρχον zoom ενότητας με όνομα `Section navigation` και μια ενότητα με μοναδικό όνομα `Results`. Αναζητά το zoom σε όλες τις διαφάνειες και βρίσκει τον προορισμό με βάση το όνομα αντί για δείκτη συλλογής που μπορεί να αλλάξει όταν οι ενότητες αναδιαταχθούν. Αν τα ονόματα δεν είναι μοναδικά, χρησιμοποιήστε το [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId) για να εντοπίσετε τον προορισμό.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Μορφοποίηση Καρέ Zoom Ενότητας**

Αυτό το παράδειγμα μετακινεί και αλλάζει μέγεθος ενός zoom ενότητας σε 100 × 75 points, αναθέτει μια τοπική εικόνα μέσω του [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) και εφαρμόζει ένα 2.5‑point, dash‑dot καφέ περίγραμμα. Ενεργοποιεί το [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) ώστε να επιστρέφει στην αρχική διαφάνεια μετά την ενότητα, απενεργοποιεί το [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) και ορίζει το [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) στα 1.5 δευτερόλεπτα. Απαιτείται μια τοπική εικόνα για την προσαρμοσμένη προεπισκόπηση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom Περίληψης**

Το zoom περίληψης παρέχει μια επισκόπηση των ενοτήτων της παρουσίασης. Κατά τη διάρκεια μιας παρουσίασης διαφανειών, μπορείτε να το χρησιμοποιήσετε για να μεταβείτε σε μια ενότητα, να προχωρήσετε μπροστά ή να επιστρέψετε σε ένα θέμα χωρίς να ακολουθήσετε τη σειρά των διαφανειών.

![Selecting sections for a summary zoom](sumzoomsel.png)

Για αντικείμενα zoom περίληψης, το Aspose.Slides παρέχει τις κλάσεις [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) και [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) καθώς και μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Δημιουργία Zoom Περίληψης**

Χρησιμοποιήστε το [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame) για να δημιουργήσετε μια επισκόπηση των ενοτήτων της παρουσίασης. Αυτό το παράδειγμα δημιουργεί τέσσερις ενότητες με διαφορετικά παρασκήνια διαφανειών και προσθέτει ένα zoom περίληψης στην πρώτη διαφάνεια. Η θέση και οι διαστάσεις του καρέ ορίζονται σε points, και η τελική επισκόπηση αποθηκεύεται σε μια παρουσίαση PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Προσθήκη και Αφαίρεση Ενότητας Zoom Περίληψης**

Το zoom περίληψης αποθηκεύει τα αντικείμενα [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) στη συλλογή [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). Αυτό το παράδειγμα δημιουργεί μια επισκόπηση δύο ενοτήτων, προσθέτει μια τρίτη ενότητα χρησιμοποιώντας το [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) και αφαιρεί την καταχώριση της πρώτης ενότητας μέσω του [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). Η αφαίρεση της καταχώρισης αφήνει την ενότητα παρουσίασης και τις διαφάνειές της αμετάβλητες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Μορφοποίηση Ενοτήτων Zoom Περίληψης**

Αυτό το παράδειγμα μορφοποιεί την πρώτη καταχώριση στο [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection), χρησιμοποιώντας το μηδενικό (zero‑based) ευρετήριο `0`. Απαιτείται μια τοπική εικόνα για το [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage), εφαρμόζει ένα 1.5‑point, dash‑dot μαύρο περίγραμμα και ορίζει το [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) στα 1.5 δευτερόλεπτα. Με το `False` στο [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) απενεργοποιείται η αυτόματη επιστροφή στη διαφάνεια περίληψης για αυτήν την καταχώριση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την επιστροφή στη «μητρική» διαφάνεια μετά την εμφάνιση του στόχου;**

Ναι. Καλέστε το [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) με `True` για να επιστρέψετε στην αρχική διαφάνεια μετά την εμφάνιση του περιεχομένου του στόχου.

**Μπορώ να ρυθμίσω την «ταχύτητα» ή τη διάρκεια της μετάβασης Zoom;**

Ναι. Χρησιμοποιήστε το [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) για να ελέγξετε τη διάρκεια της μετάβασης σε δευτερόλεπτα.

**Υπάρχουν όρια στον αριθμό των αντικειμένων Zoom που μπορεί να περιέχει μια παρουσίαση;**

Δεν υπάρχει σκληρό όριο API που να έχει τεκμηριωθεί. Τα πρακτικά όρια εξαρτώνται από τη συνολική πολυπλοκότητα της παρουσίασης και τις επιδόσεις του προβολέα. Μπορείτε να προσθέσετε πολλά καρέ Zoom, αλλά λάβετε υπόψη το μέγεθος του αρχείου και τον χρόνο απόδοσης.