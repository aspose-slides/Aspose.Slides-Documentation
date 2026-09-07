---
title: Εικόνα
type: docs
weight: 50
url: /el/python-java/examples/elements/picture/
keywords:
- παράδειγμα κώδικα
- εικόνα
- προσθήκη εικόνας
- πρόσβαση σε εικόνα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εισαγωγή και πρόσβαση σε εικόνες που δημιουργούνται στη μνήμη χρησιμοποιώντας Aspose.Slides για Python μέσω Java, με παραδείγματα για παρουσιάσεις PowerPoint και OpenDocument."
---
Αυτό το άρθρο δείχνει πώς να εισάγετε και να προσπελάσετε εικόνες από εικόνες στη μνήμη χρησιμοποιώντας **Aspose.Slides for Python via Java**. Τα παραδείγματα παρακάτω δημιουργούν μια εικόνα στη μνήμη, την τοποθετούν σε μία διαφάνεια και στη συνέχεια ανακτούν το πλαίσιο εικόνας.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Εγκατάσταση](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει `asposeslides` πριν την εκκίνηση του JVM, έπειτα εισάγει το API μετά την έναρξη του JVM.

## **Προσθήκη εικόνας**

Αυτός ο κώδικας δημιουργεί ένα μικρό bitmap, το μετατρέπει σε ροή και το εισάγει ως πλαίσιο εικόνας στην πρώτη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Δημιουργία μιας απλής εικόνας στη μνήμη.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # Μετατροπή του bitmap σε πίνακα byte.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # Προσθήκη της εικόνας στην παρουσίαση.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # Εισαγωγή πλαισίου εικόνας που εμφανίζει την εικόνα στην πρώτη διαφάνεια.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε εικόνα**

Αυτό το παράδειγμα εξασφαλίζει ότι μια διαφάνεια περιέχει ένα πλαίσιο εικόνας και στη συνέχεια προσπελαύνει το πρώτο που εντοπίζει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import PictureFrame, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    bitmap = BufferedImage(40, 40, BufferedImage.TYPE_INT_ARGB)
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image)

    picture_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is None:
        print("The slide contains no picture frames.")
finally:
    presentation.dispose()
```