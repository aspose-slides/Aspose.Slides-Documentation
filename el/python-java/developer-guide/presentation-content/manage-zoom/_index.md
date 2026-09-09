---
title: Διαχείριση Ζουμ Παρουσίασης σε Python μέσω Java
linktitle: Διαχείριση Ζουμ
type: docs
weight: 60
url: /el/python-java/manage-zoom/
keywords:
- ζουμ
- πλαίσιο ζουμ
- ζουμ διαφάνειας
- ζουμ ενότητας
- ζουμ σύνοψης
- προσθήκη ζουμ
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε το Ζουμ με Aspose.Slides για Python μέσω Java - μεταβείτε μεταξύ ενοτήτων, προσθέστε μικρογραφίες και μεταβάσεις σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Τα Zoom στο PowerPoint σάς επιτρέπουν να μεταβείτε προς και από συγκεκριμένες διαφάνειες, ενότητες και τμήματα μιας παρουσίασης. Όταν παρουσιάζετε, αυτή η δυνατότητα γρήγορης πλοήγησης στο περιεχόμενο μπορεί να αποδειχθεί πολύ χρήσιμη.

![overview_image](overview.png)

* Για να συνοψίσετε ολόκληρη την παρουσίαση σε μια μοναδική διαφάνεια, χρησιμοποιήστε ένα [Summary Zoom](#summary-zoom).
* Για να εμφανίσετε μόνο επιλεγμένες διαφάνειες, χρησιμοποιήστε ένα [Slide Zoom](#slide-zoom).
* Για να εμφανίσετε μόνο μια ενότητα, χρησιμοποιήστε ένα [Section Zoom](#section-zoom).

## **Zoom Διαφάνειας**

Ένα zoom διαφάνειας μπορεί να κάνει την παρουσίασή σας πιο δυναμική, επιτρέποντάς σας να πλοηγηθείτε ελεύθερα μεταξύ των διαφανειών σε οποιαδήποτε σειρά επιλέξετε χωρίς να διακόπτετε τη ροή της παρουσίασής σας. Τα zoom διαφανειών είναι ιδανικά για σύντομες παρουσιάσεις χωρίς πολλές ενότητες, αλλά μπορείτε να τα χρησιμοποιήσετε και σε διάφορα σενάρια παρουσίασης.

Τα zoom διαφανειών σας βοηθούν να εμβαθύνετε σε πολλαπλά κομμάτια πληροφοριών ενώ αισθάνεστε ότι βρίσκεστε σε ένα ενιαίο καμβά.

![overview_image](slidezoomsel.png)

Για αντικείμενα zoom διαφάνειας, το Aspose.Slides παρέχει την απαρίθμηση [ZoomImageType](https://reference.aspose.com/slides/el/python-java/aspose.slides/zoomimagetype/) , την κλάση [ZoomFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/zoomframe/) , και μερικές μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/) .

### **Δημιουργία Πλαισίων Zoom**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom σε μια διαφάνεια με τον ακόλουθο τρόπο:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Δημιουργήστε νέες διαφάνειες στις οποίες σκοπεύετε να συνδέσετε τα πλαίσια zoom.
3. Προσθέστε κειμενική ταυτοποίηση και φόντο στις δημιουργημένες διαφάνειες.
4. Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σε μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Προσθέτει νέες διαφάνειες στην παρουσίαση
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Δημιουργεί φόντο για την τρίτη διαφάνεια
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Προσθέτει αντικείμενα ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Αποθηκεύει την παρουσίαση
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Δημιουργία Πλαισίων Zoom με Προσαρμοσμένες Εικόνες**

Με το Aspose.Slides για Python μέσω Java, μπορείτε να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα προεπισκόπησης διαφάνειας ως εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Δημιουργήστε μια νέα διαφάνεια στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom.
3. Προσθέστε κείμενο ταυτοποίησης και φόντο στη διαφάνεια.
4. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή εικόνων που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και θα χρησιμοποιηθεί για τη γέμιση του πλαισίου.
5. Προσθέστε πλαίσια zoom (που περιέχουν την αναφορά στη δημιουργημένη διαφάνεια) στην πρώτη διαφάνεια.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Προσθέτει νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Δημιουργεί νέα εικόνα για το αντικείμενο ζουμ
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Προσθέτει το αντικείμενο ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Αποθηκεύει την παρουσίαση
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Μορφοποίηση Πλαισίων Zoom**

Στις προηγούμενες ενότητες, σας δείξαμε πώς να δημιουργήσετε απλά πλαίσια zoom. Για να δημιουργήσετε πιο περίπλοκα πλαίσια zoom, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο zoom.

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου zoom σε μια διαφάνεια ως εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Δημιουργήστε νέες διαφάνειες στις οποίες σκοπεύετε να συνδέσετε τα πλαίσια zoom.
3. Προσθέστε κείμενο ταυτοποίησης και φόντο στις δημιουργημένες διαφάνειες.
4. Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή εικόνων του αντικειμένου [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που θα χρησιμοποιηθεί για την πλήρωση του πλαισίου.
6. Ορίστε μια προσαρμοσμένη εικόνα για το πρώτο αντικείμενο πλαισίου zoom.
7. Αλλάξτε τη μορφοποίηση γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
8. Αφαιρέστε το φόντο από μια εικόνα του δεύτερου αντικειμένου πλαισίου zoom.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να αλλάξετε τη μορφοποίηση ενός πλαισίου zoom σε μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Προσθέτει νέες διαφάνειες στην παρουσίαση
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Δημιουργεί φόντο για την τρίτη διαφάνεια
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Προσθέτει αντικείμενα ZoomFrame
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Δημιουργεί νέα εικόνα για το αντικείμενο ζουμ
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Ορίζει προσαρμοσμένη εικόνα για το αντικείμενο first_zoom_frame
    first_zoom_frame.setZoomImage(picture)

    #  Ορίζει μορφοποίηση πλαισίου ζουμ για το αντικείμενο second_zoom_frame
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Ρύθμιση για μη εμφάνιση φόντου στο αντικείμενο second_zoom_frame
    second_zoom_frame.setShowBackground(False)

    #  Αποθηκεύει την παρουσίαση
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom Ενότητας**

Το zoom ενότητας είναι ένας σύνδεσμος προς μια ενότητα στην παρουσίασή σας. Μπορείτε να χρησιμοποιήσετε τα zoom ενότητας για να επιστρέψετε σε ενότητες που θέλετε να τονίσετε ιδιαίτερα. Ή μπορείτε να τα χρησιμοποιήσετε για να αναδείξετε πώς συγκεκριμένα τμήματα της παρουσίασής σας συνδέονται.

![overview_image](seczoomsel.png)

Για αντικείμενα zoom ενότητας, το Aspose.Slides παρέχει την κλάση [SectionZoomFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/sectionzoomframe/) , καθώς και μερικές μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/) .

### **Δημιουργία Πλαισίων Zoom Ενότητας**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom ενότητας σε μια διαφάνεια ως εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Δημιουργήστε μια νέα διαφάνεια.
3. Προσθέστε ένα ξεχωριστό φόντο στη δημιουργημένη διαφάνεια.
4. Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom.
5. Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σε μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα Ενότητα στην παρουσίαση
    presentation.getSections().addSection("Section 1", slide)

    #  Προσθέτει ένα αντικείμενο SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Αποθηκεύει την παρουσίαση
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Δημιουργία Πλαισίων Zoom Ενότητας με Προσαρμοσμένες Εικόνες**

Χρησιμοποιώντας το Aspose.Slides για Python μέσω Java, μπορείτε να δημιουργήσετε ένα πλαίσιο zoom ενότητας με διαφορετική εικόνα προεπισκόπησης διαφάνειας ως εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Δημιουργήστε μια νέα διαφάνεια.
3. Προσθέστε ένα ξεχωριστό φόντο στη δημιουργημένη διαφάνεια.
4. Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom.
5. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή εικόνων που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και θα χρησιμοποιηθεί για τη γέμιση του πλαισίου.
6. Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει μια αναφορά στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Προσθέτει νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα Ενότητα στην παρουσίαση
    presentation.getSections().addSection("Section 1", slide)

    #  Δημιουργεί μια νέα εικόνα για το αντικείμενο ζουμ
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Προσθέτει αντικείμενο SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Αποθηκεύει την παρουσίαση
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Μορφοποίηση Πλαισίων Zoom Ενότητας**

Για να δημιουργήσετε πιο περίπλοκα πλαίσια zoom ενότητας, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο zoom ενότητας.

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου zoom ενότητας σε μια διαφάνεια ως εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Δημιουργήστε μια νέα διαφάνεια.
3. Προσθέστε ένα ξεχωριστό φόντο στη δημιουργημένη διαφάνεια.
4. Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom.
5. Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6. Αλλάξτε το μέγεθος και τη θέση του δημιουργημένου αντικειμένου zoom ενότητας.
7. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή εικόνων του αντικειμένου [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που θα χρησιμοποιηθεί για την πλήρωση του πλαισίου.
8. Ορίστε μια προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο πλαισίου zoom ενότητας.
9. Ορίστε τη δυνατότητα *επιστροφής στην αρχική διαφάνεια από την συνδεδεμένη ενότητα*.
10. Αφαιρέστε το φόντο από μια εικόνα του αντικειμένου πλαισίου zoom ενότητας.
11. Αλλάξτε τη μορφοποίηση γραμμής για το αντικείμενο πλαισίου zoom ενότητας.
12. Αλλάξτε τη διάρκεια της μετάβασης.
13. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να αλλάξετε τη μορφοποίηση ενός πλαισίου zoom ενότητας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα Ενότητα στην παρουσίαση
    presentation.getSections().addSection("Section 1", slide)

    #  Προσθέτει αντικείμενο SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Μορφοποίηση για SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Αποθηκεύει την παρουσίαση
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom Σύνοψης**

Το zoom σύνοψης λειτουργεί σαν μια αρχική σελίδα όπου όλα τα τμήματα της παρουσίασής σας εμφανίζονται ταυτόχρονα. Όταν παρουσιάζετε, μπορείτε να χρησιμοποιήσετε το zoom για να μεταβείτε από ένα σημείο της παρουσίασης σε άλλο με οποιαδήποτε σειρά επιθυμείτε. Μπορείτε να είστε δημιουργικοί, να προχωρήσετε μπροστά ή να επιστρέψετε σε τμήματα της παρουσίασής σας χωρίς να διακόψετε τη ροή.

![overview_image](sumzoomsel.png)

Για αντικείμενα zoom σύνοψης, το Aspose.Slides παρέχει τις κλάσεις [SummaryZoomFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/summaryzoomframe/) , [SummaryZoomSection](https://reference.aspose.com/slides/el/python-java/aspose.slides/summaryzoomsection/) , και [SummaryZoomSectionCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/summaryzoomsectioncollection/) , καθώς και μερικές μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/) .

### **Δημιουργία Zoom Σύνοψης**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom σύνοψης σε μια διαφάνεια ως εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Δημιουργήστε νέες διαφάνειες με ξεχωριστό φόντο και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3. Προσθέστε το πλαίσιο zoom σύνοψης στην πρώτη διαφάνεια.
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σύνοψης σε μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα ενότητα στην παρουσίαση
    presentation.getSections().addSection("Section 1", slide)

    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα ενότητα στην παρουσίαση
    presentation.getSections().addSection("Section 2", slide)

    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα ενότητα στην παρουσίαση
    presentation.getSections().addSection("Section 3", slide)

    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα ενότητα στην παρουσίαση
    presentation.getSections().addSection("Section 4", slide)

    #  Προσθέτει αντικείμενο SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Αποθηκεύει την παρουσίαση
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Προσθήκη και Αφαίρεση Ενότητας Zoom Σύνοψης**

Όλες οι ενότητες σε ένα πλαίσιο zoom σύνοψης αναπαρίστανται από αντικείμενα [SummaryZoomSection], τα οποία αποθηκεύονται στο αντικείμενο [SummaryZoomSectionCollection]. Μπορείτε να προσθέσετε ή να αφαιρέσετε ένα αντικείμενο ενότητας zoom σύνοψης μέσω της κλάσης [SummaryZoomSectionCollection] ως εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Δημιουργήστε νέες διαφάνειες με ξεχωριστό φόντο και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3. Προσθέστε ένα πλαίσιο zoom σύνοψης στην πρώτη διαφάνεια.
4. Προσθέστε μια νέα διαφάνεια και ενότητα στην παρουσίαση.
5. Προσθέστε τη δημιουργημένη ενότητα στο πλαίσιο zoom σύνοψης.
6. Αφαιρέστε την πρώτη ενότητα από το πλαίσιο zoom σύνοψης.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να προσθέσετε και να αφαιρέσετε ενότητες σε ένα πλαίσιο zoom σύνοψης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα ενότητα στην παρουσίαση
    presentation.getSections().addSection("Section 1", slide)

    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα ενότητα στην παρουσίαση
    presentation.getSections().addSection("Section 2", slide)

    #  Προσθέτει αντικείμενο SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα ενότητα στην παρουσίαση
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Προσθέτει μια ενότητα στο Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Αφαιρεί ενότητα από το Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Αποθηκεύει την παρουσίαση
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Μορφοποίηση Ενοτήτων Zoom Σύνοψης**

Για να δημιουργήσετε πιο περίπλοκα αντικείμενα ενότητας zoom σύνοψης, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα αντικείμενο ενότητας zoom σύνοψης.

Μπορείτε να ελέγξετε τη μορφοποίηση ενός αντικειμένου ενότητας zoom σύνοψης σε ένα πλαίσιο zoom σύνοψης ως εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Δημιουργήστε νέες διαφάνειες με ξεχωριστό φόντο και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3. Προσθέστε ένα πλαίσιο zoom σύνοψης στην πρώτη διαφάνεια.
4. Αποκτήστε το πρώτο αντικείμενο ενότητας zoom σύνοψης από το [SummaryZoomSectionCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/summaryzoomsectioncollection/) .
5. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή εικόνων του αντικειμένου [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που θα χρησιμοποιηθεί για την πλήρωση του πλαισίου.
6. Ορίστε μια προσαρμοσμένη εικόνα για το αντικείμενο ενότητας zoom σύνοψης.
7. Ορίστε τη δυνατότητα *επιστροφής στην αρχική διαφάνεια από την συνδεδεμένη ενότητα*.
8. Αλλάξτε τη μορφοποίηση γραμμής για το αντικείμενο ενότητας zoom σύνοψης.
9. Αλλάξτε τη διάρκεια της μετάβασης.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να αλλάξετε τη μορφοποίηση ενός αντικειμένου ενότητας zoom σύνοψης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα ενότητα στην παρουσίαση
    presentation.getSections().addSection("Section 1", slide)

    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Προσθέτει μια νέα ενότητα στην παρουσίαση
    presentation.getSections().addSection("Section 2", slide)

    #  Προσθέτει αντικείμενο SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Αποκτά το πρώτο αντικείμενο SummaryZoomSection
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Μορφοποίηση για το αντικείμενο SummaryZoomSection
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Αποθηκεύει την παρουσίαση
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την επιστροφή στη 'γονική' διαφάνεια μετά την εμφάνιση του στόχου;**

Ναι. Το [ZoomFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/zoomframe/) ή το [SectionZoomFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/sectionzoomframe/) υποστηρίζει την επιστροφή στη διαφάνεια προέλευσης μέσω του [setReturnToParent](https://reference.aspose.com/slides/el/python-java/aspose.slides/zoomobject/#setReturnToParent), το οποίο επιστρέφει τους θεατές μετά την επίσκεψη στο στοχευόμενο περιεχόμενο όταν είναι ενεργοποιημένο.

**Μπορώ να ρυθμίσω την 'ταχύτητα' ή τη διάρκεια της μετάβασης Zoom;**

Ναι. Το Zoom υποστηρίζει τον καθορισμό διάρκειας μετάβασης με τη μέθοδο [setTransitionDuration](https://reference.aspose.com/slides/el/python-java/aspose.slides/zoomobject/#setTransitionDuration) ώστε μπορείτε να ελέγξετε πόσο διαρκεί η κίνηση μετάβασης.

**Υπάρχουν περιορισμοί στον αριθμό των αντικειμένων Zoom που μπορεί να περιέχει μια παρουσίαση;**

Δεν υπάρχει τεκμηριωμένος σκληρός περιορισμός στο API. Οι πρακτικοί περιορισμοί εξαρτώνται από τη συνολική πολυπλοκότητα της παρουσίασης και την απόδοση του προγράμματος προβολής. Μπορείτε να προσθέσετε πολλά πλαίσια Zoom, αλλά λάβετε υπόψη το μέγεθος του αρχείου και το χρόνο απόδοσης.