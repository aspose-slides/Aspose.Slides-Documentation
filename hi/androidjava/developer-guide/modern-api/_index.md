---
title: आधुनिक API के साथ इमेज प्रोसेसिंग को बेहतर बनाएं
linktitle: आधुनिक API
type: docs
weight: 237
url: /hi/androidjava/modern-api/
keywords:
- android.graphics
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
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "डिप्रिकेटेड इमेजिंग API को जावा आधुनिक API के साथ बदलकर स्लाइड इमेज प्रोसेसिंग को आधुनिक बनाएं, जिससे पावरपॉइंट और ओपनडॉक्युमेंट ऑटोमेशन सहज हो जाए।"
---
## **परिचय**

ऐतिहासिक रूप से, Aspose Slides का android.graphics पर निर्भरता है और सार्वजनिक API में वहां से निम्नलिखित क्लासेस हैं:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

संस्करण 24.4 से, इस सार्वजनिक API को अप्रचलित (deprecated) घोषित किया गया है।

इन क्लासों पर निर्भरता से मुक्त होने के लिए, हमने तथाकथित "Modern API" जोड़ा है – अर्थात् वह API जिसे अप्रचलित API की जगह उपयोग किया जाना चाहिए, जिसके सिग्नेचर में [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) पर निर्भरता होती है। [Canvas](https://developer.android.com/reference/android/graphics/Canvas) को अप्रचलित घोषित किया गया है और इसका समर्थन सार्वजनिक Slides API से हटा दिया गया है।

वर्तमान संस्करणों में, android.graphics प्रकारों पर निर्भर सार्वजनिक API को पुराना/अवमूल्यित मानें। नए कोड के लिए Modern API का उपयोग करें और मौजूदा इमेज-प्रोसेसिंग वर्कफ़्लो को माइग्रेट करते समय इसका उपयोग करें।

## **आधुनिक API**

सार्वजनिक API में निम्नलिखित क्लास और एन्नम जोड़े गए हैं:

- [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) - रास्टर या वेक्टर इमेज का प्रतिनिधित्व करता है।
- [ImageFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imageformat/) - इमेज के फ़ाइल फ़ॉर्मेट का प्रतिनिधित्व करता है।
- [Images](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) इंटरफ़ेस को इंस्टैंसिएट और उपयोग करने के मेथड्स प्रदान करता है।

कृपया ध्यान दें कि [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) डिस्पोज़ेबल है और इसके उपयोग के बाद `dispose()` कॉल या किसी अन्य सुविधाजनक डिस्पोज़ल पैटर्न का पालन किया जाना चाहिए।

एकल स्लाइड या शेप को रेंडर करने के लिए `getImage` का उपयोग करें। कई प्रेजेंटेशन स्लाइड्स को रेंडर करने के लिए `getImages` का उपयोग करें। इमेज लोड करने के लिए [Images](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/images/) मेथड्स, प्रेजेंटेशन में इमेज जोड़ने के लिए `addImage` के साथ [IImage] और मौजूदा प्रेजेंटेशन इमेज को अपडेट करने के लिए `replaceImage` के साथ [IImage] का उपयोग करें।

नए API के उपयोग का एक सामान्य परिदृश्य इस प्रकार दिख सकता है:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // डिस्क पर फाइल से IImage का डिस्पोज़ेबल इंस्टेंस बनाएं।
    IImage image = Images.fromFile("image.png");
    try {
        // IImage का एक इंस्टेंस प्रेजेंटेशन की इमेजेज में जोड़कर PowerPoint इमेज बनाएं।
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // स्लाइड #1 पर एक पिक्चर शेप जोड़ें
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // स्लाइड #1 का प्रतिनिधित्व करने वाला IImage का इंस्टेंस प्राप्त करें।
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
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

## **पुराने कोड को आधुनिक API के साथ बदलना**

सामान्य तौर पर, आपको उन कॉल्स को बदलना होगा जो [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) का उपयोग करती हैं, उन्हें नई मेथड्स से बदलना होगा जो [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) का उपयोग करती हैं।

पारंपरिक/अवमूल्यित API:
``` java
Presentation pres = new Presentation();
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail(new Size(1920, 1080));
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("image.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
आधुनिक API:
``` java
Presentation pres = new Presentation();
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        slideImage.save("image.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **स्लाइड थंबनेल प्राप्त करना**

पारंपरिक/अवमूल्यित API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("slide1.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

आधुनिक API:

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

### **शेप थंबनेल प्राप्त करना**

पारंपरिक/अवमूल्यित API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("shape.png");
        shapeImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

आधुनिक API:

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

पारंपरिक/अवमूल्यित API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Size(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        android.graphics.Bitmap thumbnail = bitmaps[index];
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("slide" + index + ".png");
            thumbnail.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

आधुनिक API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Size(1980, 1028));
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

पारंपरिक/अवमूल्यित API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    File file = new File("image.png");
    Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
    ppImage = pres.getImages().addImage(bitmap);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

आधुनिक API:

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

## **अवमूल्यित मेथड्स और उनके Modern API में प्रतिस्थापन**

### **Presentation**
| विधि सिग्नेचर | प्रतिस्थापन विधि सिग्नेचर |
|---|---|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| विधि सिग्नेचर | प्रतिस्थापन विधि सिग्नेचर |
|---|---|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| विधि सिग्नेचर | प्रतिस्थापन विधि सिग्नेचर |
|---|---|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | कोई Modern API प्रतिस्थापन नहीं |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | कोई Modern API प्रतिस्थापन नहीं |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | कोई Modern API प्रतिस्थापन नहीं |

### **Output**
| विधि सिग्नेचर | प्रतिस्थापन विधि सिग्नेचर |
|---|---|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| विधि सिग्नेचर | प्रतिस्थापन विधि सिग्नेचर |
|---|---|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| विधि सिग्नेचर | प्रतिस्थापन विधि सिग्नेचर |
|---|---|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| विधि सिग्नेचर | प्रतिस्थापन विधि सिग्नेचर |
|---|---|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| विधि सिग्नेचर | प्रतिस्थापन विधि सिग्नेचर |
|---|---|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Canvas के लिए API समर्थन**

[Canvas](https://developer.android.com/reference/android/graphics/Canvas) वाले मेथड्स को अवमूल्यित घोषित किया गया है और उनका कोई प्रत्यक्ष Modern API प्रतिस्थापन नहीं है।

[Canvas](https://developer.android.com/reference/android/graphics/Canvas) को रेंडर करने वाले API के बजाय Modern API इमेज-रेंडरिंग मेथड्स का उपयोग करें:

- [स्लाइड](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **अक्सर पूछे जाने वाले प्रश्न**

**android.graphics.Canvas को क्यों हटाया गया?**

[Canvas](https://developer.android.com/reference/android/graphics/Canvas) को सार्वजनिक API में अवमूल्यित किया गया है ताकि रेंडरिंग और इमेज कार्य को एकीकृत किया जा सके, प्लेटफ़ॉर्म-विशिष्ट निर्भरताओं से बचा जा सके, और [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) के साथ क्रॉस‑प्लेटफ़ॉर्म अप्रोच अपनाई जा सके। [Canvas](https://developer.android.com/reference/android/graphics/Canvas) के बजाय `getImage` या `getImages` का उपयोग करें।

**[IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) का [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) की तुलना में व्यावहारिक लाभ क्या है?**

[IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) रास्टर और वेक्टर दोनों प्रकार की इमेज को एकीकृत करता है और [ImageFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imageformat/) के माध्यम से विभिन्न फ़ॉर्मेट में सेविंग को सरल बनाता है।

**क्या Modern API थंबनेल जनरेट करने के प्रदर्शन को प्रभावित करेगा?**

`getThumbnail` से `getImage` पर स्विच करने से परिदृश्यों में कोई गिरावट नहीं आती: नई मेथड्स विकल्पों और आकारों के साथ इमेज बनाने की समान क्षमताएँ प्रदान करती हैं, जबकि रेंडरिंग ऑप्शन का समर्थन बरकरार रहता है। विशिष्ट लाभ या हानि परिदृश्य पर निर्भर करती है, लेकिन कार्यात्मक रूप से प्रतिस्थापन समान हैं।