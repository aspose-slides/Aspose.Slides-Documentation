---
title: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 237
url: /python-java/modern-api/
keywords: "واجهة برمجة التطبيقات الحديثة عبر المنصات"
description: "واجهة برمجة التطبيقات الحديثة"
---

## المقدمة

تاريخياً، كانت Aspose Slides تعتمد على java.awt وتحتوي في واجهة برمجة التطبيقات العامة على الفئات التالية من هناك:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

اعتبارًا من الإصدار 24.4، تم الإعلان عن هذه الواجهة العامة على أنها مهجورة.

للتخلص من الاعتماد على هذه الفئات، أضفنا ما يُسمى "واجهة برمجة التطبيقات الحديثة" - أي الواجهة التي يجب استخدامها بدلاً من المهجورة، التي تحتوي توقيعاتها على اعتماد على BufferedImage. تم إعلان Graphics2D مهجورة وتم إزالة دعمه من واجهة برمجة التطبيقات العامة للشرائح.

سيتم إزالة واجهة برمجة التطبيقات العامة المهجورة التي تعتمد على System.Drawing في الإصدار 24.8.

## واجهة برمجة التطبيقات الحديثة

تمت إضافة الفئات والتعدادات التالية إلى واجهة برمجة التطبيقات العامة:

- IImage - تمثل الصورة النقطية أو المتجهية.
- ImageFormat - تمثل صيغة ملف الصورة.
- Images - طرق لإنشاء واستخدام واجهة IImage.

يرجى ملاحظة أن IImage قابلة للتخلص (تنفذ واجهة IDisposable ويجب تغليف استخدامها في using أو التخلص منها بطريقة ملائمة أخرى).

قد يبدو سيناريو استخدام الواجهة الجديدة كما يلي:

``` python
from asposeslides.api import Presentation, SaveFormat, Images, ShapeType, ImageFormat
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension

pres = Presentation();

# إنشاء مثيل قابل للتخلص من IImage من الملف على القرص.
image = Images.fromFile("image.png");

# إنشاء صورة PowerPoint من خلال إضافة مثيل لـ IImage إلى صور العرض التقديمي.
ppImage = pres.getImages().addImage(image);
image.dispose();

# إضافة شكل صورة على الشريحة #1
pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

# الحصول على مثيل من IImage يمثل الشريحة #1.
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));

# حفظ الصورة على القرص.
slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
slideImage.dispose();

pres.dispose();
```

## استبدال الكود القديم بواجهة برمجة التطبيقات الحديثة

بشكل عام، ستحتاج إلى استبدال الاتصال بالأسلوب القديم باستخدام ImageIO بالجديد.

قديم:
``` python
image_format = "PNG"
buffImage = pres.getSlides().get_Item(0).getThumbnail(Dimension(1920, 1080))
ImageIO.write(buffImage, image_format, File("image.png"))
```
جديد:
``` python
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));
slideImage.save("image.png", ImageFormat.Png);
```

### الحصول على صورة مصغرة للشريحة

الكود باستخدام واجهة برمجة التطبيقات المهجورة:

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

واجهة برمجة التطبيقات الحديثة:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

slideImage = pres.getSlides().get_Item(0).getImage();
slideImage.save("slide1.png", ImageFormat.Png);
slideImage.dispose();

pres.dispose();
```

### الحصول على صورة مصغرة لشكل

الكود باستخدام واجهة برمجة التطبيقات المهجورة:

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

واجهة برمجة التطبيقات الحديثة:

``` python
from asposeslides.api import Presentation, ImageFormat


pres = Presentation("pres.pptx");

shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
shapeImage.save("shape.png", ImageFormat.Png);
shapeImage.dispose();

pres.dispose();
```

### الحصول على صورة مصغرة للتقديم

الكود باستخدام واجهة برمجة التطبيقات المهجورة:

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

واجهة برمجة التطبيقات الحديثة:

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

### إضافة صورة إلى عرض تقديمي

الكود باستخدام واجهة برمجة التطبيقات المهجورة:

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

واجهة برمجة التطبيقات الحديثة:

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

## الأساليب التي سيتم إزالتها واستبدالها في واجهة برمجة التطبيقات الحديثة

### تقديم
| توقيع الأسلوب                               | توقيع الأسلوب البديل                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### شكل
| توقيع الأسلوب                                                      | توقيع الأسلوب البديل                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                        | public final IImage getImage()                                                           |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### شريحة
| توقيع الأسلوب                                                      | توقيع الأسلوب البديل                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | سيتم حذفه بالكامل |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | سيتم حذفه بالكامل |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | سيتم حذفه بالكامل |

### الإخراج
| توقيع الأسلوب                                                | توقيع الأسلوب البديل                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### مجموعة الصور
| توقيع الأسلوب                          | توقيع الأسلوب البديل               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| توقيع الأسلوب                     | توقيع الأسلوب البديل   |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### تنسيق النمط
| توقيع الأسلوب                                          | توقيع الأسلوب البديل                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) |public final IImage getTile(Color background, Color foreground) |

### البيانات الفعالة لتنسيق النمط
| توقيع الأسلوب                                          | توقيع الأسلوب البديل                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## الدعم لرسومات Graphics2D سيتوقف

تم إعلان الأساليب التي تستخدم [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) مهجورة وسيتم إزالة دعمها من واجهة برمجة التطبيقات العامة.

ستتم إزالة الجزء من واجهة برمجة التطبيقات الذي يستخدمها:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)