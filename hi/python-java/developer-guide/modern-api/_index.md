---
title: "आधुनिक API"
type: docs
weight: 237
url: /hi/python-java/modern-api/
keywords: "क्रॉसप्लेटफ़ॉर्म आधुनिक API"
description: "आधुनिक API"
---
## परिचय

ऐतिहासिक रूप से, Aspose Slides का java.awt पर निर्भरता है और सार्वजनिक API में वहाँ से निम्नलिखित क्लासेस शामिल हैं:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

संस्करण 24.4 से, इस सार्वजनिक API को विसंक्रमित (deprecated) घोषित किया गया है।

इन क्लासेस पर निर्भरता से मुक्त होने के लिए, हमने तथाकथित "Modern API" जोड़ा है - अर्थात् वह API जिसे विसंक्रमित वाले के बजाय उपयोग किया जाना चाहिए, जिसकी हस्ताक्षर (signatures) BufferedImage पर निर्भरता रखती हैं। Graphics2D को विसंक्रमित घोषित किया गया है और इसका समर्थन सार्वजनिक Slides API से हटा दिया गया है।

System.Drawing पर निर्भरता वाले विसंक्रमित सार्वजनिक API का हटाना संस्करण 24.8 में होगा।

## Modern API

सार्वजनिक API में निम्नलिखित क्लासेस और एन्यूम जोड़े गए हैं:

- IImage - रास्टर या वेक्टर इमेज को दर्शाता है।
- ImageFormat - इमेज के फ़ाइल फ़ॉर्मेट को दर्शाता है।
- Images - IImage इंटरफ़ेस को इंस्टैंशिएट करने और उसके साथ काम करने के मेथड्स।

कृपया ध्यान दें कि IImage डिस्पोज़ेबल है (यह IDisposable इंटरफ़ेस को इम्प्लीमेंट करता है और इसका उपयोग using ब्लॉक में या किसी अन्य सुविधाजनक तरीके से डिस्पोज़ करके किया जाना चाहिए)।

नए API का एक सामान्य उपयोग परिदृश्य इस प्रकार हो सकता है:

``` python
from asposeslides.api import Presentation, SaveFormat, Images, ShapeType, ImageFormat
from javax.imageio import ImageIO
from java.io import File
from java.awt import Dimension

pres = Presentation();

# डिस्क पर फ़ाइल से IImage का विसर्जन योग्य इंस्टेंस बनाएं।
image = Images.fromFile("image.png");

# प्रेजेंटेशन की इमेजेस में IImage का इंस्टेंस जोड़कर एक PowerPoint इमेज बनाएं।
ppImage = pres.getImages().addImage(image);
image.dispose();

# स्लाइड #1 पर एक चित्र आकार (picture shape) जोड़ें।
pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

# स्लाइड #1 का प्रतिनिधित्व करने वाला IImage का इंस्टेंस प्राप्त करें।
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));

# इमेज को डिस्क पर सहेजें।
slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
slideImage.dispose();

pres.dispose();
```

## Modern API के साथ पुराने कोड को बदलना

सामान्यतः, आपको ImageIO का उपयोग करने वाले पुराने मेथड को नए मेथड से बदलना होगा।

पुराना:
``` python
image_format = "PNG"
buffImage = pres.getSlides().get_Item(0).getThumbnail(Dimension(1920, 1080))
ImageIO.write(buffImage, image_format, File("image.png"))
```
नया:
``` python
slideImage = pres.getSlides().get_Item(0).getImage(Dimension(1920, 1080));
slideImage.save("image.png", ImageFormat.Png);
```

### स्लाइड थंबनेल प्राप्त करना

विसंक्रमित API का कोड:

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

### शैप थंबनेल प्राप्त करना

विसंक्रमित API का कोड:

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

### प्रेजेंटेशन थंबनेल प्राप्त करना

विसंक्रमित API का कोड:

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

### प्रेजेंटेशन में चित्र जोड़ना

विसंक्रमित API का कोड:

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

## हटाए जाने वाले मेथड्स और Modern API में उनका प्रतिस्थापन

### Presentation
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### Shape
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### Slide
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
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
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### ImageCollection
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### PatternFormat
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### PatternFormatEffectiveData
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## Graphics2D के लिए API समर्थन समाप्त किया जाएगा

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) वाले मेथड्स को विसंक्रमित (deprecated) घोषित किया गया है और उनका समर्थन सार्वजनिक API से हटा दिया जाएगा।

जो हिस्सा API का इसका उपयोग करता है, वह हटा दिया जाएगा:

[Slide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)