---
title: Moderní API
type: docs
weight: 237
url: /cs/python-java/modern-api/
keywords: "CrossPlatform Moderní API"
description: "Moderní API"
---
## Úvod

Historicky má Aspose Slides závislost na java.awt a má v veřejném API následující třídy z něj:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Od verze 24.4 je toto veřejné API označeno jako zastaralé.

Abychom se zbavili závislostí na těchto třídách, přidali jsme takzvané „Moderní API“ – tj. API, které by se mělo používat místo zastaralého, jehož podpisy obsahují závislosti na BufferedImage. Graphics2D je označeno jako zastaralé a jeho podpora je odebrána z veřejného API Slides.

Odstranění zastaralého veřejného API se závislostí na System.Drawing bude ve vydání 24.8.

## Moderní API

Do veřejného API byly přidány následující třídy a výčty:

- IImage – představuje rastrový nebo vektorový obrázek.
- ImageFormat – představuje formát souboru obrázku.
- Images – metody pro vytvoření a práci s rozhraním IImage.

Všimněte si, že IImage je odhazovatelný (implementuje rozhraní IDisposable a jeho použití by mělo být zabalené do using nebo jiným vhodným způsobem uvolněno).

Typický scénář použití nového API může vypadat následovně:

``` python
from asposeslides.api import Presentation, SaveFormat, Images, ShapeType, ImageFormat
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension

pres = Presentation();

# vytvořit odhazovatelnou instanci IImage ze souboru na disku.
image = Images.fromFile("image.png");

# vytvořit PowerPoint obrázek přidáním instance IImage do obrázků prezentace.
ppImage = pres.getImages().addImage(image);
image.dispose();

# přidat obrázkový tvar na snímek #1
pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

# získat instanci IImage představující snímek #1.
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));

# uložit obrázek na disk.
slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
slideImage.dispose();

pres.dispose();
```

## Nahrazení starého kódu Moderním API

Obecně budete muset nahradit volání staré metody používající ImageIO novou metodou.

Staré:
``` python
image_format = "PNG"
buffImage = pres.getSlides().get_Item(0).getThumbnail(Dimension(1920, 1080))
ImageIO.write(buffImage, image_format, File("image.png"))
```
Nové:
``` python
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));
slideImage.save("image.png", ImageFormat.Png);
```

### Získání náhledu snímku

Kód používající zastaralé API:

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

Moderní API:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

slideImage = pres.getSlides().get_Item(0).getImage();
slideImage.save("slide1.png", ImageFormat.Png);
slideImage.dispose();

pres.dispose();
```

### Získání náhledu tvaru

Kód používající zastaralé API:

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

Moderní API:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
shapeImage.save("shape.png", ImageFormat.Png);
shapeImage.dispose();

pres.dispose();
```

### Získání náhledu prezentace

Kód používající zastaralé API:

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

Moderní API:

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

### Přidání obrázku do prezentace

Kód používající zastaralé API:

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

Moderní API:

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

## Metody, které budou odstraněny, a jejich náhrada v Moderním API

### Presentation
| Podpis metody | Podpis nahrazující metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### Shape
| Podpis metody | Podpis nahrazující metody |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### Slide
| Podpis metody | Podpis nahrazující metody |
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

### Output
| Podpis metody | Podpis nahrazující metody |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### ImageCollection
| Podpis metody | Podpis nahrazující metody |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| Podpis metody | Podpis nahrazující metody |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### PatternFormat
| Podpis metody | Podpis nahrazující metody |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### PatternFormatEffectiveData
| Podpis metody | Podpis nahrazující metody |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## Podpora API pro Graphics2D bude ukončena

Metody s [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) jsou označeny jako zastaralé a jejich podpora bude odebrána z veřejného API.

Část API, která jej používá, bude odstraněna:

[Slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)