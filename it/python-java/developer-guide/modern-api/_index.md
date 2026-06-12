---
title: API moderna
type: docs
weight: 237
url: /it/python-java/modern-api/
keywords: "CrossPlatform API moderna"
description: "API moderna"
---
## Introduzione

Storicamente, Aspose Slides ha una dipendenza da java.awt e ha nell'API pubblica le seguenti classi provenienti da lì:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partire dalla versione 24.4, questa API pubblica è dichiarata obsoleta.

Per eliminare le dipendenze da queste classi, abbiamo aggiunto la cosiddetta "Modern API", cioè l'API che dovrebbe essere utilizzata al posto di quella obsoleta, le cui firme contengono dipendenze da BufferedImage. Graphics2D è dichiarata obsoleta e il suo supporto è stato rimosso dall'API pubblica di Slides.

La rimozione dell'API pubblica obsoleta con dipendenze da System.Drawing sarà nella versione 24.8.

## API moderna

Sono state aggiunte le seguenti classi ed enum all'API pubblica:

- IImage – rappresenta l'immagine raster o vettoriale.
- ImageFormat – rappresenta il formato file dell'immagine.
- Images – metodi per istanziare e lavorare con l'interfaccia IImage.

Si noti che IImage è disposable (implementa l'interfaccia IDisposable e il suo utilizzo dovrebbe essere avvolto in using o eliminato in altro modo conveniente).

Uno scenario tipico di utilizzo della nuova API può apparire come segue:

``` python
from asposeslides.api import Presentation, SaveFormat, Images, ShapeType, ImageFormat
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension

pres = Presentation();

# istanziare un'istanza disposable di IImage dal file su disco.
image = Images.fromFile("image.png");

# creare un'immagine PowerPoint aggiungendo un'istanza di IImage alle immagini della presentazione.
ppImage = pres.getImages().addImage(image);
image.dispose();

# aggiungere una forma immagine sulla diapositiva #1
pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

# ottenere un'istanza di IImage che rappresenta la diapositiva #1.
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));

# salvare l'immagine sul disco.
slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
slideImage.dispose();

pres.dispose();
```

## Sostituire il codice legacy con l'API moderna

In generale, sarà necessario sostituire la chiamata al metodo legacy che utilizza ImageIO con la nuova.

Vecchio:
``` python
image_format = "PNG"
buffImage = pres.getSlides().get_Item(0).getThumbnail(Dimension(1920, 1080))
ImageIO.write(buffImage, image_format, File("image.png"))
```
Nuovo:
``` python
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));
slideImage.save("image.png", ImageFormat.Png);
```

### Ottenere una miniatura di una diapositiva

Codice che utilizza un'API obsoleta:

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

API moderna:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

slideImage = pres.getSlides().get_Item(0).getImage();
slideImage.save("slide1.png", ImageFormat.Png);
slideImage.dispose();

pres.dispose();
```

### Ottenere una miniatura di una forma

Codice che utilizza un'API obsoleta:

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

API moderna:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
shapeImage.save("shape.png", ImageFormat.Png);
shapeImage.dispose();

pres.dispose();
```

### Ottenere una miniatura di una presentazione

Codice che utilizza un'API obsoleta:

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

API moderna:

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

### Aggiungere un'immagine a una presentazione

Codice che utilizza un'API obsoleta:

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

API moderna:

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

## Metodi da rimuovere e loro sostituzione nell'API moderna

### Presentazione
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### Forma
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### Diapositiva
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
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
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### ImageCollection
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### PatternFormat
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### PatternFormatEffectiveData
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## Il supporto dell'API per Graphics2D sarà interrotto

I metodi con [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sono dichiarati obsoleti e il loro supporto sarà rimosso dall'API pubblica.

La parte dell'API che lo utilizza sarà rimossa:

[Slide](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)