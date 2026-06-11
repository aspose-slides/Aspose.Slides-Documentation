---
title: Modernt API
type: docs
weight: 237
url: /sv/python-java/modern-api/
keywords: "CrossPlatform Modernt API"
description: "Modernt API"
---
## Introduktion

Historiskt har Aspose Slides ett beroende av java.awt och har i det offentliga API:et följande klasser därifrån:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Från och med version 24.4 är detta offentliga API markerat som föråldrat.

För att bli av med beroenden på dessa klasser har vi lagt till det så kallade "Modern API" – dvs. det API som bör användas i stället för det föråldrade, vars signaturer innehåller beroenden på BufferedImage. Graphics2D är markerat som föråldrat och dess stöd har tagits bort från det offentliga Slides‑API:et.

Borttagning av det föråldrade offentliga API:et med beroenden på System.Drawing kommer att ske i version 24.8.

## Modernt API

Följande klasser och uppräkningar har lagts till i det offentliga API:et:

- IImage – representerar raster- eller vektorbilden.
- ImageFormat – representerar bildens filformat.
- Images – metoder för att skapa och arbeta med IImage‑gränssnittet.

Observera att IImage är disposable (den implementerar IDisposable‑gränssnittet och dess användning bör omslutas av using eller disposeras på annat lämpligt sätt).

Ett typiskt scenario för att använda det nya API:et kan se ut på följande sätt:

``` python
from asposeslides.api import Presentation, SaveFormat, Images, ShapeType, ImageFormat
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension

pres = Presentation();

# instansiera en engångsinstans av IImage från filen på disken.
image = Images.fromFile("image.png");

# skapa en PowerPoint-bild genom att lägga till en instans av IImage till presentationens bilder.
ppImage = pres.getImages().addImage(image);
image.dispose();

# lägg till en bildform på bildspel #1
pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

# hämta en instans av IImage som representerar bild #1.
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));

# spara bilden på disken.
slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
slideImage.dispose();

pres.dispose();
```

## Ersätta gammal kod med Modernt API

I allmänhet måste du ersätta anropet till den gamla metoden som använder ImageIO med den nya.

Gammal:
``` python
image_format = "PNG"
buffImage = pres.getSlides().get_Item(0).getThumbnail(Dimension(1920, 1080))
ImageIO.write(buffImage, image_format, File("image.png"))
```
Ny:
``` python
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));
slideImage.save("image.png", ImageFormat.Png);
```

### Hämta en miniatyrbild för en bildspelsida

Kod som använder ett föråldrat API:

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

Modernt API:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

slideImage = pres.getSlides().get_Item(0).getImage();
slideImage.save("slide1.png", ImageFormat.Png);
slideImage.dispose();

pres.dispose();
```

### Hämta en miniatyrbild för en form

Kod som använder ett föråldrat API:

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

Modernt API:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
shapeImage.save("shape.png", ImageFormat.Png);
shapeImage.dispose();

pres.dispose();
```

### Hämta en miniatyrbild för en presentation

Kod som använder ett föråldrat API:

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

Modernt API:

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

### Lägg till en bild i en presentation

Kod som använder ett föråldrat API:

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

Modernt API:

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

## Metoder som ska tas bort och deras ersättningar i Modernt API

### Presentation
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### Form
| Metodsignatur | Ersättningsmetodsignatur |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### Bild
| Metodsignatur | Ersättningsmetodsignatur |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
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

### Utdata
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### ImageCollection
| Metodsignatur | Ersättningsmetodsignatur |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| Metodsignatur | Ersättningsmetodsignatur |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### PatternFormat
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### PatternFormatEffectiveData
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## Stöd för Graphics2D i API:et kommer att upphöra

Metoder med [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) är markerade som föråldrade och deras stöd kommer att tas bort från det offentliga API:et.

Den del av API:et som använder den kommer att tas bort:

[Slide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)