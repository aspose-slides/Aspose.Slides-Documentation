---
title: API สมัยใหม่
type: docs
weight: 237
url: /th/python-java/modern-api/
keywords: "CrossPlatform API สมัยใหม่"
description: "API สมัยใหม่"
---
## บทนำ

Historically, Aspose Slides มีการพึ่งพา java.awt และใน API สาธารณะมีคลาสต่อไปนี้จากที่นั้น:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

ตั้งแต่เวอร์ชัน 24.4 API สาธารณะนี้ถูกประกาศให้เลิกใช้แล้ว

เพื่อกำจัดการพึ่งพาเหล่านี้ เราได้เพิ่มที่เรียกว่า "Modern API" - คือ API ที่ควรใช้แทน API ที่เลิกใช้ ซึ่งลายเซ็นของมันยังมีการพึ่งพา BufferedImage อยู่. Graphics2D ถูกประกาศให้เลิกใช้และการสนับสนุนของมันถูกลบออกจาก API สาธารณะของ Slides

การลบ API สาธารณะที่เลิกใช้ซึ่งพึ่งพา System.Drawing จะเกิดในเวอร์ชัน 24.8

## Modern API

เพิ่มคลาสและ enum ต่อไปนี้เข้าสู่ API สาธารณะ:

- IImage - แทนภาพแบบราสเตอร์หรือเวคเตอร์
- ImageFormat - แทนรูปแบบไฟล์ของภาพ
- Images - วิธีการสร้างและทำงานกับอินเทอร์เฟซ IImage

โปรดทราบว่า IImage สามารถทำลายได้ (มัน implements อินเทอร์เฟซ IDisposable และการใช้งานควรห่อหุ้มด้วย using หรือทำการ dispose ในวิธีที่สะดวกอื่นๆ)

ตัวอย่างการใช้ API ใหม่อาจมีลักษณะดังนี้:

``` python
from asposeslides.api import Presentation, SaveFormat, Images, ShapeType, ImageFormat
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension

pres = Presentation();

# สร้างอินสแตนซ์ IImage ที่สามารถทำลายได้จากไฟล์บนดิสก์.
image = Images.fromFile("image.png");

# สร้างภาพ PowerPoint โดยเพิ่มอินสแตนซ์ IImage เข้าไปในคอลเลกชันภาพของงานนำเสนอ.
ppImage = pres.getImages().addImage(image);
image.dispose();

# เพิ่มรูปร่างรูปภาพบนสไลด์ที่ 1
pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

# รับอินสแตนซ์ IImage ที่เป็นตัวแทนของสไลด์ที่ 1.
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));

# บันทึกภาพลงบนดิสก์.
slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
slideImage.dispose();

pres.dispose();
```

## การแทนที่โค้ดเก่าด้วย Modern API

โดยทั่วไป คุณจะต้องแทนที่การเรียกใช้เมธอดเก่าที่ใช้ ImageIO ด้วยเมธอดใหม่

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

### การรับ Thumbnail ของสไลด์

โค้ดที่ใช้ API ที่เลิกใช้:

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

### การรับ Thumbnail ของ Shape

โค้ดที่ใช้ API ที่เลิกใช้:

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

### การรับ Thumbnail ของ Presentation

โค้ดที่ใช้ API ที่เลิกใช้:

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

### การเพิ่มรูปภาพลงใน Presentation

โค้ดที่ใช้ API ที่เลิกใช้:

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

## วิธีการที่จะถูกลบและการแทนที่ใน Modern API

### Presentation
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### Shape
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### Slide
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
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
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### ImageCollection
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### PatternFormat
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### PatternFormatEffectiveData
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## การสนับสนุน API สำหรับ Graphics2D จะถูกยุติ

เมธอดที่มี [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ถูกประกาศให้เลิกใช้และการสนับสนุนของมันจะถูกลบออกจาก API สาธารณะ

ส่วนของ API ที่ใช้มันจะถูกลบออก:

[Slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)