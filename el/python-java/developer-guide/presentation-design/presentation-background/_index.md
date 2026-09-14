---
title: Διαχείριση Φόντου Παρουσίασης σε Python μέσω Java
linktitle: Φόντο Διαφάνειας
type: docs
weight: 20
url: /el/python-java/presentation-background/
keywords:
- φόντο παρουσίασης
- φόντο διαφάνειας
- στερεό χρώμα
- χρώμα διαβάθμισης
- φόντο εικόνας
- διαφάνεια φόντου
- ιδιότητες φόντου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να ορίζετε δυναμικά φόντα σε αρχεία PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω Java, με συμβουλές κώδικα για να ενισχύσετε τις παρουσιάσεις σας."
---
## **Εισαγωγή**

Σταθερά χρώματα, διαβαθμίσεις και εικόνες χρησιμοποιούνται συχνά ως φόντο διαφανειών. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μια μοναδική διαφάνεια) ή για μια **διαφάνεια προτύπου** (εφαρμόζεται σε πολλές διαφάνειες ταυτόχρονα).

![φόντο PowerPoint](powerpoint-background.png)

## **Ορισμός Σταθερού Χρώματος Φόντου για Κανονική Διαφάνεια**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα στερεό χρώμα ως φόντο για συγκεκριμένη διαφάνεια σε μια παρουσίαση — ακόμη και αν η παρουσίαση χρησιμοποιεί διαφάνεια προτύπου. Η αλλαγή εφαρμόζεται μόνο στην επιλεγμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/python-java/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-java/aspose.slides/filltype/) του φόντου διαφάνειας σε `Solid` .
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/#getsolidfillcolor) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/) για να καθορίσετε το στερεό χρώμα φόντου .
5. Αποθηκεύστε τη τροποποιημένη παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Δημιουργείστε μια παρουσία της κλάσης Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ορίστε το χρώμα φόντου της διαφάνειας σε μπλε.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Αποθηκεύστε την παρουσίαση στον δίσκο.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Σταθερού Χρώματος Φόντου για Διαφάνεια Προτύπου**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα στερεό χρώμα ως φόντο για τη διαφάνεια προτύπου σε μια παρουσίαση. Η διαφάνεια προτύπου λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση όλων των διαφανειών, έτσι όταν επιλέγετε ένα στερεό χρώμα για το φόντο της διαφάνειας προτύπου, αυτό εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/python-java/aspose.slides/backgroundtype/) της διαφάνειας προτύπου (μέσω του [getMasters](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getmasters)) σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-java/aspose.slides/filltype/) του φόντου διαφάνειας προτύπου σε `Solid` .
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/#getsolidfillcolor) για να καθορίσετε το στερεό χρώμα φόντου .
5. Αποθηκεύστε τη τροποποιημένη παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Δημιουργείστε μια παρουσία της κλάσης Presentation.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Ορίστε το χρώμα φόντου για τη διαφάνεια προτύπου σε πράσινο.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Αποθηκεύστε την παρουσίαση στον δίσκο.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Διαβαθμισμένου Φόντου για Διαφάνεια**

Η διαβάθμιση είναι ένα γραφικό εφέ που δημιουργείται από μια βαθμιαία αλλαγή χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, οι διαβαθμίσεις μπορούν να κάνουν τις παρουσιάσεις πιο καλλιτεχνικές και επαγγελματικές. Το Aspose.Slides σας επιτρέπει να ορίσετε ένα χρώμα διαβάθμισης ως φόντο για διαφάνειες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/python-java/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-java/aspose.slides/filltype/) του φόντου διαφάνειας σε `Gradient` .
4. Χρησιμοποιήστε τη μέθοδο [getGradientFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/#getgradientformat) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/) για να διαμορφώσετε τις προτιμώμενες ρυθμίσεις διαβάθμισης .
5. Αποθηκεύστε τη τροποποιημένη παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Δημιουργείστε μια παρουσία της κλάσης Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Εφαρμόστε ένα εφέ διαβάθμισης στο φόντο.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Προσθέστε τα χρώματα διαβάθμισης. Χωρίς σημεία διαβάθμισης, το φόντο επιστρέφει σε προεπιλεγμένη κλίμακα από μαύρο σε λευκό.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Αποθηκεύστε την παρουσίαση στον δίσκο.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Εικόνας ως Φόντο Διαφάνειας**

Εκτός από τα στερεά και διαβαθμισμένα γεμίσματα, το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε εικόνες ως φόντο διαφάνειας.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/python-java/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-java/aspose.slides/filltype/) του φόντου διαφάνειας σε `Picture` .
4. Φορτώστε την εικόνα που θέλετε να χρησιμοποιήσετε ως φόντο διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε τη μέθοδο [getPictureFillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/#getpicturefillformat) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/) για να ορίσετε την εικόνα ως φόντο.
7. Αποθηκεύστε τη τροποποιημένη παρουσίαση.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

    # Δημιουργείστε μια παρουσία της κλάσης Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ορίστε τις ιδιότητες εικόνας φόντου.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Φορτώστε την εικόνα.
    image = Images.fromFile("Tulips.jpg")
    # Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Αποθηκεύστε την παρουσίαση στον δίσκο.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Ορίστε την εικόνα που χρησιμοποιείται για το γέμισμα του φόντου.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Ορίστε τη λειτουργία γέμισματος εικόνας σε πλακίδιο και προσαρμόστε τις ιδιότητες του πλακιδίου.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Διαβάστε περισσότερα: [Tile Picture as Texture](/slides/el/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Αλλαγή Διαφάνειας Εικόνας Φόντου**

Μπορεί να θέλετε να προσαρμόσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο της διαφάνειας να ξεχωρίζει. Ο παρακάτω κώδικας Python δείχνει πώς να αλλάξετε τη διαφάνεια για μια εικόνα φόντου διαφάνειας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Για παράδειγμα.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Λάβετε τη συλλογή των λειτουργιών μετασχηματισμού εικόνας.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Βρείτε ένα υπάρχον εφέ διαφάνειας σταθερού ποσοστού.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Ορίστε τη νέα τιμή διαφάνειας.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Λήψη Τιμής Φόντου Διαφάνειας**

Το Aspose.Slides σας επιτρέπει να ανακτήσετε τις αποτελεσματικές τιμές φόντου μιας διαφάνειας χρησιμοποιώντας τη μέθοδο [getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/background/#geteffective) στην κλάση [Background](https://reference.aspose.com/slides/el/python-java/aspose.slides/background/). Τα επιστρεφόμενα δεδομένα εκθέτουν τις αποτελεσματικές μορφές γεμίσματος και εφέ.

Χρησιμοποιώντας τη μέθοδο [getBackground](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getbackground) της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/), μπορείτε να λάβετε το φόντο μιας διαφάνειας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Δημιουργείστε μια παρουσία της κλάσης Presentation.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Ανακτήστε το αποτελεσματικό φόντο, λαμβάνοντας υπόψη το master, το layout και το theme.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να επαναφέρω το φόντο θέματος/διάταξης;**

Ναι. Αφαιρέστε το προσαρμοσμένο γέμισμα της διαφάνειας και το φόντο θα κληρονομηθεί ξανά από τη σχετική διαφάνεια [layout](/slides/el/python-java/slide-layout/)/[master](/slides/el/python-java/slide-master/) (δηλαδή το [theme background](/slides/el/python-java/presentation-theme/)).

**Τι συμβαίνει με το φόντο αν αλλάξω αργότερα το θέμα της παρουσίασης;**

Αν μια διαφάνεια έχει το δικό της γέμισμα, αυτό θα παραμείνει αμετάβλητο. Αν το φόντο κληρονομείται από το [layout](/slides/el/python-java/slide-layout/)/[master](/slides/el/python-java/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [new theme](/slides/el/python-java/presentation-theme/).