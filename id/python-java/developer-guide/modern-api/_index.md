---
title: API Modern
type: docs
weight: 237
url: /id/python-java/modern-api/
keywords: "API Modern Lintas Platform"
description: "API Modern"
---
## Pengantar

Secara historis, Aspose Slides memiliki ketergantungan pada java.awt dan dalam API publik memiliki kelas berikut dari sana:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Mulai versi 24.4, API publik ini dinyatakan usang.

Untuk menghilangkan ketergantungan pada kelas‑kelas ini, kami menambahkan apa yang disebut “Modern API” – yaitu API yang harus digunakan menggantikan yang usang, yang tanda tangan metodenya mengandung ketergantungan pada BufferedImage. Graphics2D dinyatakan usang dan dukungannya dihapus dari API Slides publik.

Penghapusan API publik yang usang dengan ketergantungan pada System.Drawing akan terjadi pada rilis 24.8.

## Modern API

Menambahkan kelas dan enum berikut ke API publik:

- IImage - mewakili gambar raster atau vektor.
- ImageFormat - mewakili format file gambar.
- Images - metode untuk membuat instansi dan bekerja dengan antarmuka IImage.

Harap dicatat bahwa IImage bersifat disposable (menerapkan antarmuka IDisposable dan penggunaannya harus dibungkus dengan using atau dibuang dengan cara yang lain yang nyaman).

Skenario tipikal penggunaan API baru dapat terlihat sebagai berikut:

``` python
from asposeslides.api import Presentation, SaveFormat, Images, ShapeType, ImageFormat
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension

pres = Presentation();

# buat instance IImage yang dapat dibuang dari file di disk.
image = Images.fromFile("image.png");

# buat gambar PowerPoint dengan menambahkan instance IImage ke gambar presentasi.
ppImage = pres.getImages().addImage(image);
image.dispose();

# tambahkan shape gambar pada slide #1
pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

# dapatkan sebuah instance IImage yang mewakili slide #1.
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));

# simpan gambar ke disk.
slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
slideImage.dispose();

pres.dispose();
```

## Mengganti kode lama dengan Modern API

Secara umum, Anda perlu mengganti panggilan ke metode lama yang menggunakan ImageIO dengan yang baru.

Old:
``` python
image_format = "PNG"
buffImage = pres.getSlides().get_Item(0).getThumbnail(Dimension(1920, 1080))
ImageIO.write(buffImage, image_format, File("image.png"))
```
New:
``` python
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));
slideImage.save("image.png", ImageFormat.Png);
```

### Mendapatkan thumbnail slide

Kode yang menggunakan API usang:

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

### Mendapatkan thumbnail shape

Kode yang menggunakan API usang:

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

### Mendapatkan thumbnail presentasi

Kode yang menggunakan API usang:

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

### Menambahkan gambar ke presentasi

Kode yang menggunakan API usang:

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

## Metode yang akan dihapus dan penggantiannya dalam Modern API

### Presentation
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### Shape
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### Slide
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Akan dihapus sepenuhnya |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Akan dihapus sepenuhnya |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Akan dihapus sepenuhnya |

### Output
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### ImageCollection
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---|---|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### PatternFormat
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### PatternFormatEffectiveData
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## Dukungan API untuk Graphics2D akan dihentikan

Metode dengan [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dinyatakan usang dan dukungannya akan dihapus dari API publik.

Bagian API yang menggunakannya akan dihapus:

[Slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)