---
title: Modern API
type: docs
weight: 237
url: /tr/python-java/modern-api/
keywords: "Çapraz Platform Modern API"
description: "Modern API"
---
## Giriş

Tarihsel olarak, Aspose Slides java.awt'e bağımlıdır ve genel API'sinde aşağıdaki sınıfları barındırır:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

24.4 sürümünden itibaren, bu genel API kullanımdan kaldırılmış olarak ilan edilmiştir.

Bu sınıflara olan bağımlılıkları ortadan kaldırmak amacıyla, sözde "Modern API"yi ekledik – yani, kullanımdan kaldırılan API yerine kullanılacak, imzalarında BufferedImage bağımlılığı bulunan API. Graphics2D kullanımdan kaldırılmış olarak ilan edildi ve destek, genel Slides API'sinden kaldırıldı.

System.Drawing bağımlılıklarına sahip kullanımdan kaldırılmış genel API'nin kaldırılması 24.8 sürümünde gerçekleştirilecektir.

## Modern API

Aşağıdaki sınıflar ve enumlar genel API'ye eklendi:

- IImage - raster veya vektör görüntüyü temsil eder.
- ImageFormat - görüntünün dosya biçimini temsil eder.
- Images - IImage arayüzünü oluşturmak ve onunla çalışmak için yöntemler.

Not: IImage, IDisposable arayüzünü uyguladığı için atılabilir bir nesnedir ve kullanımı `using` ifadesiyle sarmalanmalı ya da uygun başka bir şekilde `Dispose` edilmelidir.

Yeni API'yi kullanmanın tipik bir senaryosu şu şekilde görünebilir:

``` python
from asposeslides.api import Presentation, SaveFormat, Images, ShapeType, ImageFormat
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension

pres = Presentation();

# diskteki dosyadan IImage'ın kullanılabilir bir örneğini oluştur.
image = Images.fromFile("image.png");

# sunumun görsellerine IImage örneği ekleyerek bir PowerPoint resmi oluştur.
ppImage = pres.getImages().addImage(image);
image.dispose();

# slayt #1'e bir resim şekli ekle
pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

# slayt #1'i temsil eden IImage örneğini al.
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));

# resmi diske kaydet.
slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
slideImage.dispose();

pres.dispose();
```

## Eski kodu Modern API ile değiştirme

Genel olarak, ImageIO kullanan eski metod çağrısını yenisiyle değiştirmeniz gerekir.

Eski:
``` python
image_format = "PNG"
buffImage = pres.getSlides().get_Item(0).getThumbnail(Dimension(1920, 1080))
ImageIO.write(buffImage, image_format, File("image.png"))
```
Yeni:
``` python
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));
slideImage.save("image.png", ImageFormat.Png);
```

### Slayt küçük resmi alma

Kullanımdan kaldırılmış bir API kullanan kod:

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

Modern API:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

slideImage = pres.getSlides().get_Item(0).getImage();
slideImage.save("slide1.png", ImageFormat.Png);
slideImage.dispose();

pres.dispose();
```

### Şekil küçük resmi alma

Kullanımdan kaldırılmış bir API kullanan kod:

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

Modern API:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
shapeImage.save("shape.png", ImageFormat.Png);
shapeImage.dispose();

pres.dispose();
```

### Sunum küçük resmi alma

Kullanımdan kaldırılmış bir API kullanan kod:

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

Modern API:

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

### Sunuma resim ekleme

Kullanımdan kaldırılmış bir API kullanan kod:

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

Modern API:

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

## Kaldırılacak yöntemler ve Modern API'deki yerine geçecekleri

### Sunum
| Metod İmzası                               | Yerine Kullanılan Metod İmzası                             |
|--------------------------------------------|-----------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### Şekil
| Metod İmzası                                                      | Yerine Kullanılan Metod İmzası                                       |
|-------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                         | public final IImage getImage()                                        |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### Slayt
| Metod İmzası                                                      | Yerine Kullanılan Metod İmzası                                           |
|-------------------------------------------------------------------|---------------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                         | public final IImage getImage()                                            |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY)                 |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options)                  |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options)                  |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options)    | public final IImage getImage(ITiffOptions options)                       |
| public final BufferedImage getThumbnail(Dimension imageSize)     | public final IImage getImage(Dimension imageSize)                        |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Will be deleted completely  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Will be deleted completely  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Will be deleted completely  |

### Çıktı
| Metod İmzası                                                | Yerine Kullanılan Metod İmzası                                |
|-------------------------------------------------------------|---------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### ImageCollection
| Metod İmzası                          | Yerine Kullanılan Metod İmzası               |
|---------------------------------------|----------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| Metod İmzası                     | Yerine Kullanılan Metod İmzası   |
|----------------------------------|----------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### PatternFormat
| Metod İmzası                                          | Yerine Kullanılan Metod İmzası                        |
|-------------------------------------------------------|-------------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### PatternFormatEffectiveData
| Metod İmzası                                          | Yerine Kullanılan Metod İmzası                        |
|-------------------------------------------------------|-------------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## Graphics2D için API desteği sonlandırılacak

Graphics2D ([Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)) içeren yöntemler kullanımdan kaldırılmış olarak ilan edilir ve destekleri genel API'den kaldırılacaktır.

Bunu kullanan API bölümü kaldırılacak:

[Slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)