---
title: आधुनिक API के साथ इमेज प्रोसेसिंग को बेहतर बनाएं
linktitle: आधुनिक API
type: docs
weight: 237
url: /hi/nodejs-java/modern-api/
keywords:
- आधुनिक API
- ड्रॉइंग
- स्लाइड थंबनेल
- स्लाइड से इमेज
- शेप थंबनेल
- शेप से इमेज
- प्रेजेंटेशन थंबनेल
- प्रेजेंटेशन से इमेज
- इमेज जोड़ें
- चित्र जोड़ें
- Node.js
- JavaScript
- Aspose.Slides
description: "डिप्रिकेटेड इमेजिंग APIs को JavaScript के आधुनिक API से बदलकर स्लाइड इमेज प्रोसेसिंग को आधुनिक बनाएं, जिससे PowerPoint और OpenDocument ऑटोमेशन सहज हो जाए।"
---
## **परिचय**

इतिहास में, Aspose Slides का java.awt पर निर्भरता थी और सार्वजनिक API में वहाँ से निम्नलिखित क्लासेज़ शामिल थीं:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

संस्करण 24.4 से, यह सार्वजनिक API अप्रचलित घोषित किया गया है।

इन क्लासेज़ पर निर्भरताओं को हटाने के लिए हमने तथाकथित "आधुनिक API" जोड़ी है – अर्थात वह API जिसे अब अप्रचलित वाले के स्थान पर उपयोग किया जाना चाहिए, जिसके हस्ताक्षर में [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) जैसी निर्भरताएँ नहीं हैं। [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) को भी अप्रचलित घोषित कर दिया गया है और इसका समर्थन सार्वजनिक Slides API से हटा दिया गया है।

वर्तमान संस्करणों में, java.awt प्रकारों पर निर्भर सार्वजनिक API को लिगेसी/अप्रचलित माना जाना चाहिए। नए कोड के लिए और मौजूदा इमेज‑प्रोसेसिंग कार्यप्रवाहों को माइग्रेट करते समय आधुनिक API का उपयोग करें।

## **आधुनिक API**

सार्वजनिक API में निम्नलिखित क्लासेज़ और एन्यूम जोड़ी गई हैं:

- [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) – रास्टर या वेक्टर इमेज को दर्शाता है।
- [ImageFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imageformat/) – इमेज के फ़ाइल फ़ॉर्मेट को दर्शाता है।
- [Images](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/images/) – [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) क्लास को इंस्टैंसिएट करने और उसके साथ काम करने के मेथड्स।

कृपया ध्यान दें कि [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) डिस्पोज़ेबल है और इसका उपयोग करने के बाद `dispose()` कॉल या कोई अन्य सुविधाजनक डिस्पोज़ल पैटर्न अपनाया जाना चाहिए।

`getImage` का उपयोग करके एकल स्लाइड या शैप को रेंडर करें। `getImages` का उपयोग करके कई प्रेजेन्टेशन स्लाइड्स को रेंडर करें। इमेज लोड करने के लिए [Images](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/images/) मेथड्स, प्रस्तुति में जोड़ने के लिए `addImage` के साथ [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/), और मौजूदा प्रस्तुति इमेज को अपडेट करने के लिए `replaceImage` के साथ [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) का प्रयोग करें।

नया API उपयोग करने का एकTypical परिदृश्य इस प्रकार हो सकता है:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // डिस्क पर फ़ाइल से IImage का एक डिस्पोज़ेबल इंस्टेंस बनाएँ।
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // प्रस्तुति की इमेजेज में IImage का एक इंस्टेंस जोड़कर एक PowerPoint इमेज बनाएं।
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // स्लाइड #1 पर एक चित्र शैप जोड़ें
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // स्लाइड #1 को दर्शाने वाला IImage का एक इंस्टेंस प्राप्त करें।
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // इमेज को डिस्क पर सहेजें।
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **पुराने कोड को आधुनिक API के साथ बदलना**

सामान्यतः, आपको वह कॉल्स बदलने होंगे जो [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) और [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) का उपयोग करते हैं, उन्हें नए मेथड्स से बदलें जो [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) का उपयोग करते हैं।

लिगेसी/अप्रचलित API:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
आधुनिक API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **स्लाइड थंबनेल प्राप्त करना**

लिगेसी/अप्रचलित API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

आधुनिक API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **शेप थंबनेल प्राप्त करना**

लिगेसी/अप्रचलित API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

आधुनिक API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **प्रेजेंटेशन थंबनेल प्राप्त करना**

लिगेसी/अप्रचलित API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

आधुनिक API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **प्रेजेंटेशन में तस्वीर जोड़ना**

लिगेसी/अप्रचलित API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

आधुनिक API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अप्रचलित मेथड्स और उनका प्रतिस्थापन आधुनिक API में**

### **Presentation**
| विधि हस्ताक्षर | प्रतिस्थापन विधि हस्ताक्षर |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| विधि हस्ताक्षर | प्रतिस्थापन विधि हस्ताक्षर |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| विधि हस्ताक्षर | प्रतिस्थापन विधि हस्ताक्षर |
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
| विधि हस्ताक्षर | प्रतिस्थापन विधि हस्ताक्षर |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| विधि हस्ताक्षर | प्रतिस्थापन विधि हस्ताक्षर |
|-------------------------------------------|--------------------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| विधि हस्ताक्षर | प्रतिस्थापन विधि हस्ताक्षर |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| विधि हस्ताक्षर | प्रतिस्थापन विधि हस्ताक्षर |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| विधि हस्ताक्षर | प्रतिस्थापन विधि हस्ताक्षर |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D के लिए API समर्थन**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) वाले मेथड्स को अप्रचलित घोषित किया गया है और उनका सीधा आधुनिक API प्रतिस्थापन नहीं है।

Graphics2D पर रेंडर करने वाले API के बजाय आधुनिक API इमेज‑रेंडरिंग मेथड्स का उपयोग करें:

[Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**[IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) का व्यावहारिक लाभ [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) की तुलना में क्या है?**

[IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) रास्टर और वेक्टर दोनों इमेज के साथ काम करना एकीकृत करता है और विभिन्न फ़ॉर्मेट में सहेजने को [ImageFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imageformat/) के माध्यम से सरल बनाता है।

**क्या आधुनिक API थंबनेल निर्माण के प्रदर्शन को प्रभावित करेगी?**

`getThumbnail` से `getImage` में बदलाव करने से प्रदर्शन पर कोई नकारात्मक प्रभाव नहीं पड़ता: नई मेथड्स विकल्पों और आकारों के साथ इमेज उत्पन्न करने के समान क्षमताएँ प्रदान करती हैं, और रेंडरिंग विकल्पों का समर्थन बनाए रखती हैं। विशिष्ट लाभ या ह्रास परिदृश्य पर निर्भर करता है, लेकिन कार्यात्मक रूप से प्रतिस्थापन समान हैं।