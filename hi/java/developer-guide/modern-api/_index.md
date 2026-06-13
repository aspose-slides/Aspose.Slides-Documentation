---
title: आधुनिक API के साथ छवि प्रसंस्करण को उन्नत बनाएं
linktitle: आधुनिक API
type: docs
weight: 237
url: /hi/java/modern-api/
keywords:
- आधुनिक API
- चित्रांकन
- स्लाइड थंबनेल
- स्लाइड को छवि में
- आकृति थंबनेल
- आकृति को छवि में
- प्रस्तुति थंबनेल
- प्रस्तुति को छवियों में
- छवि जोड़ें
- चित्र जोड़ें
- Java
- Aspose.Slides
description: "डिप्रिकेटेड इमेजिंग API को Java Modern API से बदलकर स्लाइड इमेज प्रोसेसिंग को आधुनिक बनाएँ, जिससे PowerPoint और OpenDocument ऑटोमेशन सहज हो जाएगा।"
---
## **परिचय**

ऐतिहासिक रूप से, Aspose Slides को java.awt पर निर्भरता थी और सार्वजनिक API में वहाँ से निम्नलिखित क्लासेस शामिल थीं:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

संस्करण 24.4 से, इस सार्वजनिक API को अप्रचलित घोषित किया गया है।

इन क्लासेस पर निर्भरता हटाने के लिए, हमने तथाकथित “आधुनिक API” जोड़ा - अर्थात वह API जिसे अप्रचलित वाले के बजाय उपयोग किया जाना चाहिए, जिसकी हस्ताक्षरों में [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) पर निर्भरता होती है। [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) को अप्रचलित घोषित किया गया है और इसका समर्थन सार्वजनिक Slides API से हटा दिया गया है।

वर्तमान संस्करणों में, java.awt प्रकारों पर निर्भर सार्वजनिक API को पुरानी/अप्रचलित मानें। नया कोड लिखते समय और मौजूदा इमेज‑प्रोसेसिंग वर्कफ़्लो को माइग्रेट करते समय आधुनिक API का उपयोग करें।

## **आधुनिक API**

सार्वजनिक API में निम्नलिखित क्लास और एनम जोड़ें:

- [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) - रास्टर या वेक्टर इमेज का प्रतिनिधित्व करता है।
- [ImageFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imageformat/) - इमेज का फ़ाइल फ़ॉर्मेट दर्शाता है।
- [Images](https://reference.aspose.com/slides/hi/java/com.aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) इंटरफ़ेस को इंस्टैंशिएट करने और उसके साथ काम करने के मेथड्स।

कृपया ध्यान दें कि [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) को डिस्पोज़ेबल माना गया है और इसके प्रयोग के बाद `dispose()` कॉल या कोई अन्य सुविधाजनक डिस्पोज़ल पैटर्न का उपयोग किया जाना चाहिए।

एकल स्लाइड या आकार को रेंडर करने के लिए `getImage` का उपयोग करें। कई प्रस्तुति स्लाइड्स को रेंडर करने के लिए `getImages` का उपयोग करें। इमेज लोड करने, प्रस्तुति में जोड़ने के लिए `addImage` के साथ [IImage] का उपयोग, और मौजूदा प्रस्तुति इमेज को अपडेट करने के लिए `replaceImage` के साथ [IImage] का उपयोग करने के लिए [Images] मेथड्स का उपयोग करें।

नई API के उपयोग का एक सामान्य परिदृश्य इस प्रकार हो सकता है:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // डिस्क पर फ़ाइल से IImage का डिस्पोज़ेबल इंस्टैंस बनाएं।
    IImage image = Images.fromFile("image.png");
    try {
        // प्रेजेंटेशन की इमेजेज में IImage का इंस्टैंस जोड़कर PowerPoint इमेज बनाएं।
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // स्लाइड #1 पर एक चित्र आकार जोड़ें
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // स्लाइड #1 का प्रतिनिधित्व करने वाला IImage का इंस्टैंस प्राप्त करें।
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // इमेज को डिस्क पर सहेजें।
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **पुराने कोड को आधुनिक API से बदलना**

सामान्यतः, आपको उन कॉल्स को बदलना होगा जो [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) और ImageIO का उपयोग करती हैं, और उन्हें नए मेथड्स से बदलना होगा जो [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) का उपयोग करते हैं।

Legacy/deprecated API:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
Modern API:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **स्लाइड थंबनेल प्राप्त करना**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail();
    try {
        ImageIO.write(slideImage, "PNG", new File("slide1.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **आकार थंबनेल प्राप्त करना**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    try {
        ImageIO.write(shapeImage, "PNG", new File("shape.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **प्रेजेंटेशन थंबनेल प्राप्त करना**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide" + index + ".png"));
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Dimension(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **प्रेजेंटेशन में चित्र जोड़ना**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    try {
        BufferedImage bufferedImages = ImageIO.read(new File("image.png"));
        ppImage = pres.getImages().addImage(bufferedImages);
    } catch (IOException e) {
        e.printStackTrace();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अप्रचलित मेथड्स और उनके आधुनिक API में प्रतिस्थापन**

### **Presentation**
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|----------------|---------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|----------------|---------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|----------------|---------------------------|
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
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|----------------|---------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|----------------|---------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|----------------|---------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|----------------|---------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| मेथड हस्ताक्षर | प्रतिस्थापन मेथड हस्ताक्षर |
|----------------|---------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D के लिए API समर्थन**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) वाले मेथड्स को अप्रचलित घोषित किया गया है और उनका कोई प्रत्यक्ष आधुनिक API प्रतिस्थापन नहीं है।

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) को रेंडर करने वाले API के बजाय आधुनिक API इमेज‑रेंडरिंग मेथड्स का उपयोग करें:

[Slide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **अक्सर पूछे जाने वाले प्रश्न**

**[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) को छोड़ने का कारण क्या है?**

सार्वजनिक API में [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) का समर्थन अप्रचलित कर दिया गया है ताकि रेंडरिंग और इमेज के साथ काम को एकीकृत किया जा सके, प्लेटफ़ॉर्म‑विशिष्ट निर्भरताओं को समाप्त किया जा सके, और [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) के साथ एक क्रॉस‑प्लेटफ़ॉर्म दृष्टिकोण अपनाया जा सके। [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) के बजाय `getImage` या `getImages` का उपयोग करें।

**[IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) का [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) की तुलना में व्यावहारिक लाभ क्या है?**

[IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) रास्टर और वेक्टर दोनों इमेज के साथ काम को एकीकृत करता है और विभिन्न फ़ॉर्मेट्स में सहेजने को सरल बनाता है, जो [ImageFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imageformat/) द्वारा संभव है।

**क्या आधुनिक API थंबनेल जनरेशन की प्रदर्शन पर असर डालेगा?**

`getThumbnail` से `getImage` में स्विच करने से प्रदर्शन में कोई गिरावट नहीं आती; नई मेथड्स विकल्पों और आकारों के साथ इमेज बनाने की समान क्षमताएँ प्रदान करती हैं, जबकि रेंडरिंग विकल्पों का समर्थन बनाए रखती हैं। विशिष्ट लाभ या हानि परिदृश्य पर निर्भर करती है, लेकिन कार्यात्मक रूप से प्रतिस्थापन समान हैं।