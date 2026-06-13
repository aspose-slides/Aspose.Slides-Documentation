---
title: "आधुनिक API के साथ इमेज प्रोसेसिंग को बढ़ाएँ"
linktitle: "आधुनिक API"
type: docs
weight: 237
url: /hi/php-java/modern-api/
keywords:
- "आधुनिक API"
- "ड्राइंग"
- "स्लाइड थंबनेल"
- "स्लाइड से इमेज"
- "आकृति थंबनेल"
- "आकृति से इमेज"
- "प्रेजेंटेशन थंबनेल"
- "प्रेजेंटेशन से इमेजेज"
- "इमेज जोड़ें"
- "चित्र जोड़ें"
- PHP
- Aspose.Slides
description: "डिप्रिकेटेड इमेजिंग API को PHP के आधुनिक API से बदलकर स्लाइड इमेज प्रोसेसिंग को आधुनिकीकरण करें, जिससे PowerPoint और OpenDocument ऑटोमेशन सहज हो।"
---
## **परिचय**

इतिहास में, Aspose Slides का java.awt पर निर्भरता थी और सार्वजनिक API में यहां से निम्नलिखित क्लासेज़ हैं:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

संस्करण 24.4 से, इस सार्वजनिक API को अप्रचलित घोषित किया गया है।

इन क्लासेज़ पर निर्भरता को हटाने के लिए, हमने तथाकथित "Modern API" जोड़ा – यानी वह API जिसे अप्रचलित वाले के बजाय उपयोग किया जाना चाहिए, जिसकी सिग्नेचर में [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) पर निर्भरता होती है। [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) को अप्रचलित घोषित किया गया है और इसका समर्थन सार्वजनिक Slides API से हटा दिया गया है।

वर्तमान संस्करणों में, java.awt प्रकारों पर निर्भर सार्वजनिक API को लेगेसी/अप्रचलित मानें। नए कोड के लिए और मौजूदा इमेज‑प्रॉसेसिंग कार्यप्रवाहों को माइग्रेट करते समय Modern API का उपयोग करें।

## **आधुनिक API**

सार्वजनिक API में निम्नलिखित क्लासेज़ और एनेम जोड़े गए:

- [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) - रास्टर या वेक्टर इमेज को दर्शाता है।
- [ImageFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imageformat/) - इमेज का फ़ाइल फ़ॉर्मेट दर्शाता है।
- [Images](https://reference.aspose.com/slides/hi/php-java/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) क्लास को इंस्टैंसिएट और उपयोग करने के मेथड्स।

ध्यान दें कि [IImage] डिस्पोज़ेबल है (इसे उपयोग के बाद डिस्पोज़ करना चाहिए)।

एकल स्लाइड या शेप को रेंडर करने के लिए `getImage` का उपयोग करें। कई प्रेजेंटेशन स्लाइड्स को रेंडर करने के लिए `getImages` का उपयोग करें। इमेज लोड करने, उन्हें प्रेजेंटेशन में जोड़ने के लिए `addImage` के साथ [IImage] का उपयोग करने, और मौजूदा प्रेजेंटेशन इमेज को अपडेट करने के लिए `replaceImage` के साथ [IImage] का उपयोग करने के लिए [Images](https://reference.aspose.com/slides/hi/php-java/aspose.slides/images/) मेथड्स का उपयोग करें।

नया API उपयोग करने का एक सामान्य परिदृश्य इस प्रकार हो सकता है:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# डिस्क पर फ़ाइल से IImage का डिस्पोज़ेबल इंस्टेंस बनाएं।
$image = Images::fromFile("image.png");

# IImage के इंस्टेंस को प्रेजेंटेशन की इमेजेज में जोड़कर एक PowerPoint इमेज बनाएं।
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# स्लाइड #1 पर एक तस्वीर शेप जोड़ें
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# स्लाइड #1 का प्रतिनिधित्व करने वाला IImage का इंस्टेंस प्राप्त करें।
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# इमेज को डिस्क पर सहेजें।
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **पुराने कोड को Modern API के साथ बदलना**

सामान्य तौर पर, आपको उन कॉल्स को बदलना होगा जो [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) और [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) का उपयोग करती हैं, उन्हें नए मेथड्स से बदलना होगा जो [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) का उपयोग करते हैं।

Legacy/deprecated API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Modern API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **स्लाइड थंबनेल प्राप्त करना**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **शेप थंबनेल प्राप्त करना**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **प्रेजेंटेशन थंबनेल प्राप्त करना**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$bitmaps = $pres->getThumbnails($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($bitmaps)); $i++)
{
    $thumbnail = $bitmaps[$i];
    $imageio = new Java("javax.imageio.ImageIO");
    $javafile = new Java("java.io.File", "slide" . $i . ".png");
    $imageio->write($thumbnail, "PNG", $javafile);
}

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **प्रेजेंटेशन में चित्र जोड़ना**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;


$pres = new Presentation();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");

$bufferedImages = $imageio->read($javafile);
$ppImage = $pres->getImages()->addImage($bufferedImages);

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\Images;
use aspose\slides\ShapeType;


$pres = new Presentation();

$image = Images::fromFile("image.png");
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

## **अप्रचलित मेथड्स और उनका Modern API में प्रतिस्थापन**

### **Presentation**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

### **Output**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D के लिए API समर्थन**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) वाले मेथड्स को अप्रचलित घोषित किया गया है और उनका कोई प्रत्यक्ष Modern API प्रतिस्थापन नहीं है।

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) को रेंडर करने वाले API के बजाय Modern API इमेज‑रेंडरिंग मेथड्स का उपयोग करें:

[Slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **अक्सर पूछे जाने वाले प्रश्न**

**[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) को क्यों हटा दिया गया?**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) के समर्थन को सार्वजनिक API में अप्रचलित किया गया है ताकि रेंडरिंग और इमेज के कार्य को एकीकृत किया जा सके, प्लेटफ़ॉर्म‑विशिष्ट निर्भरताओं को समाप्त किया जा सके, और [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) के साथ क्रॉस‑प्लेटफ़ॉर्म दृष्टिकोण अपनाया जा सके। [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) को रेंडर करने के बजाय `getImage` या `getImages` का उपयोग करें।

**[IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) के उपयोग का व्यावहारिक लाभ क्या है, जब तुलना में [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) है?**

[IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) रास्टर और वेक्टर दोनों इमेज के साथ काम करने को एकीकृत करता है और [ImageFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imageformat/) के माध्यम से विभिन्न फ़ॉर्मेट में सहेजना सरल बनाता है।

**क्या Modern API थंबनेल जनरेट करने के प्रदर्शन को प्रभावित करेगा?**

`getThumbnail` से `getImage` में स्विच करने से परिदृश्यों में कोई नुकसान नहीं होता: नए मेथड्स विकल्पों और आकारों के साथ इमेज बनाने की समान क्षमताएँ प्रदान करते हैं, जबकि रेंडरिंग विकल्पों के समर्थन को बनाए रखते हैं। विशिष्ट लाभ या घटाव परिदृश्य पर निर्भर करता है, लेकिन कार्यात्मक रूप से प्रतिस्थापन समान हैं।