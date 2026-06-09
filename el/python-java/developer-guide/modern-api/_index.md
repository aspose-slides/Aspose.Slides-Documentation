---
title: Σύγχρονο API
type: docs
weight: 237
url: /el/python-java/modern-api/
keywords: "Διαπλατφόρμα Σύγχρονο API"
description: "Σύγχρονο API"
---
## Εισαγωγή

Ιστορικά, το Aspose Slides εξαρτάται από το java.awt και περιέχει στο δημόσιο API τις ακόλουθες κλάσεις από εκεί:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Από την έκδοση 24.4, αυτό το δημόσιο API δηλώνεται ως παρωχημένο.

Για να απαλλαγούμε από τις εξαρτήσεις σε αυτές τις κλάσεις, προσθέσαμε το λεγόμενο «Σύγχρονο API» – δηλαδή το API που πρέπει να χρησιμοποιείται αντί του παρωχημένου, του οποίου οι υπογραφές περιέχουν εξαρτήσεις στο BufferedImage. Το Graphics2D δηλώνεται ως παρωχημένο και η υποστήριξή του αφαιρείται από το δημόσιο API του Slides.

Η αφαίρεση του παρωχημένου δημόσιου API με εξαρτήσεις στο System.Drawing θα γίνει στην έκδοση 24.8.

## Σύγχρονο API

Προστέθηκαν οι παρακάτω κλάσεις και πεδία enum στο δημόσιο API:

- IImage – αντιπροσωπεύει την εικόνα raster ή vector.
- ImageFormat – αντιπροσωπεύει τη μορφή αρχείου της εικόνας.
- Images – μέθοδοι για δημιουργία και εργασία με το interface IImage.

Παρακαλώ σημειώστε ότι το IImage είναι disposable (εφαρμόζει το interface IDisposable και η χρήση του πρέπει να τυλίγεται σε using ή να αποδεσμεύεται με άλλο κατάλληλο τρόπο).

Ένα τυπικό σενάριο χρήσης του νέου API μπορεί να μοιάζει ως εξής:

``` python
from asposeslides.api import Presentation, SaveFormat, Images, ShapeType, ImageFormat
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension

pres = Presentation();

# δημιουργεί μια αποδεσμεύσιμη παρουσία του IImage από το αρχείο στο δίσκο.
image = Images.fromFile("image.png");

# δημιουργεί μια εικόνα PowerPoint προσθέτοντας μια παρουσία του IImage στις εικόνες της παρουσίασης.
ppImage = pres.getImages().addImage(image);
image.dispose();

# προσθέτει ένα σχήμα εικόνας στη διαφάνεια #1
pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

# λαμβάνει μια παρουσία του IImage που αντιπροσωπεύει τη διαφάνεια #1.
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));

# αποθηκεύει την εικόνα στο δίσκο.
slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
slideImage.dispose();

pres.dispose();
```

## Αντικατάσταση του παλιού κώδικα με το Σύγχρονο API

Γενικά, θα πρέπει να αντικαταστήσετε την κλήση στην παλιά μέθοδο που χρησιμοποιεί ImageIO με τη νέα.

Παλιά:
``` python
image_format = "PNG"
buffImage = pres.getSlides().get_Item(0).getThumbnail(Dimension(1920, 1080))
ImageIO.write(buffImage, image_format, File("image.png"))
```
Νέα:
``` python
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));
slideImage.save("image.png", ImageFormat.Png);
```

### Λήψη μικρογραφίας διαφάνειας

Κώδικας που χρησιμοποιεί παρωχημένο API:

``` python
from asposeslides.api import Presentation
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension


pres = Presentation("pres.pptx");

slideImage = pres.getSlides().get_Item(0).getThumbnail();
image_format = "PNG"
ImageIO.write(slideImage, image_format, File("slide1.png"))

pres.dispose();
```

Σύγχρονο API:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

slideImage = pres.getSlides().get_Item(0).getImage();
slideImage.save("slide1.png", ImageFormat.Png);
slideImage.dispose();

pres.dispose();
```

### Λήψη μικρογραφίας σχήματος

Κώδικας που χρησιμοποιεί παρωχημένο API:

``` python
from asposeslides.api import Presentation
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension


pres = Presentation("pres.pptx");

shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
image_format = "PNG"
ImageIO.write(shapeImage, image_format, File("shape.png"))

pres.dispose();
```

Σύγχρονο API:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
shapeImage.save("shape.png", ImageFormat.Png);
shapeImage.dispose();

pres.dispose();
```

### Λήψη μικρογραφίας παρουσίασης

Κώδικας που χρησιμοποιεί παρωχημένο API:

``` python
from asposeslides.api import Presentation, RenderingOptions
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension


pres = Presentation("pres.pptx");

image_format = "PNG"
rendering_options = RenderingOptions();
bitmaps = pres.getThumbnails(rendering_options, Dimension(1980, 1028));

for index in range(bitmaps.length):
    thumbnail = bitmaps[index];
    ImageIO.write(thumbnail, "PNG", File("slide" + str(index) + ".png"));
    
pres.dispose();
```

Σύγχρονο API:

``` python
from asposeslides.api import Presentation, RenderingOptions, ImageFormat
from java.awt import Dimension


pres = Presentation("pres.pptx");

rendering_options = RenderingOptions();
images = pres.getImages(rendering_options, Dimension(1980, 1028));

for index in range(images.length):
    thumbnail = images[index];
    thumbnail.save("slide" + str(index) + ".png", ImageFormat.Png);
    thumbnail.dispose();

pres.dispose();
```

### Προσθήκη εικόνας σε παρουσίαση

Κώδικας που χρησιμοποιεί παρωχημένο API:

``` python
from asposeslides.api import Presentation, ShapeType
from javax.imageio import ImageIO
from java.io import File


pres = Presentation();

bufferedImages = ImageIO.read(File("image.png"));
ppImage = pres.getImages().addImage(bufferedImages);

pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

pres.dispose();
```

Σύγχρονο API:

``` python
from asposeslides.api import Presentation, ShapeType, Images
from java.awt import Dimension


pres = Presentation();

image = Images.fromFile("image.png");
ppImage = pres.getImages().addImage(image);
image.dispose();

pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

pres.dispose();
```

## Μέθοδοι που θα αφαιρεθούν και η αντικατάστασή τους στο Σύγχρονο API

### Presentation
| Υπογραφή Μεθόδου | Αντικαταστάτης Υπογραφή Μεθόδου |
|-------------------|---------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### Shape
| Υπογραφή Μεθόδου | Αντικαταστάτης Υπογραφή Μεθόδου |
|-------------------|---------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### Slide
| Υπογραφή Μεθόδου | Αντικαταστάτης Υπογραφή Μεθόδου |
|-------------------|---------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Will be deleted completely |

### Output
| Υπογραφή Μεθόδου | Αντικαταστάτης Υπογραφή Μεθόδου |
|-------------------|---------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### ImageCollection
| Υπογραφή Μεθόδου | Αντικαταστάτης Υπογραφή Μεθόδου |
|-------------------|---------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| Υπογραφή Μεθόδου | Αντικαταστάτης Υπογραφή Μεθόδου |
|-------------------|---------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### PatternFormat
| Υπογραφή Μεθόδου | Αντικαταστάτης Υπογραφή Μεθόδου |
|-------------------|---------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### PatternFormatEffectiveData
| Υπογραφή Μεθόδου | Αντικαταστάτης Υπογραφή Μεθόδου |
|-------------------|---------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## Η υποστήριξη του API για Graphics2D θα διακοπεί

Οι μέθοδοι με [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) δηλώνονται ως παρωχημένες και η υποστήριξή τους θα αφαιρεθεί από το δημόσιο API.

Το τμήμα του API που το χρησιμοποιεί θα αφαιρεθεί:

[Slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)