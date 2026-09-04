---
title: आधुनिक API के साथ पायथन में इमेज प्रोसेसिंग को उन्नत बनाएं
linktitle: आधुनिक API
type: docs
weight: 237
url: /hi/python-java/modern-api/
keywords:
- आधुनिक API
- चित्रण
- स्लाइड थंबनेल
- स्लाइड से इमेज
- आकृति थंबनेल
- आकृति से इमेज
- प्रेज़ेंटेशन थंबनेल
- प्रेज़ेंटेशन से छवियों में
- छवि जोड़ें
- तस्वीर जोड़ें
- पायथन
- जावा
- Aspose.Slides
description: "जावा के माध्यम से पायथन में इमेज प्रोसेसिंग को आधुनिक बनाएं: स्लाइड और आकृति को रेंडर करें, तस्वीरें जोड़ें, और डिप्रिकेटेड इमेजिंग कॉल्स को Aspose.Slides के आधुनिक API में माइग्रेट करें।"
---
## **परिचय**

Aspose.Slides for Python via Java JPype के माध्यम से जावा लाइब्रेरी तक पहुँचता है। इसका पुराना इमेज‑प्रोसेसिंग API `java.awt` से [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) और [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) का उपयोग करता था।

जावा लाइब्रेरी ने संस्करण 24.4 से इन इमेजिंग API को डिप्रिकेट कर दिया। आधुनिक API छवियों को लोड, रेंडर और सेव करने के लिए [IImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/) का उपयोग करता है। नए पायथन कोड के लिए और मौजूदा इमेज‑प्रोसेसिंग वर्कफ़्लो को माइग्रेट करने के समय इसे उपयोग करें।

{{% alert color="info" title="Note" %}}
नीचे दिए गए पुराने मेथड नाम माइग्रेशन संदर्भ हैं। वे वर्तमान रिलीज़ में उपलब्ध नहीं हैं। कार्यान्वयन उदाहरण आधुनिक API का उपयोग करते हैं।
{{% /alert %}}

## **आधुनिक API**

मुख्य इमेज‑प्रोसेसिंग प्रकार हैं:

- [IImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/) — एक रास्टर या वेक्टर छवि को दर्शाता है।  
- [ImageFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imageformat/) — छवि फ़ाइल फ़ॉर्मेट कॉन्स्टैंट प्रदान करता है।  
- [Images](https://reference.aspose.com/slides/hi/python-java/aspose.slides/images/) — छवियों का निर्माण करता है, उदाहरण के लिए [Images.fromFile](https://reference.aspose.com/slides/hi/python-java/aspose.slides/images/#fromFile) के साथ।

एक स्लाइड या शेप रेंडर करने के लिए [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) या [Shape.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) उपयोग करें। कई स्लाइड्स रेंडर करने के लिए विकल्पों के साथ [Presentation.getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) उपयोग करें। बिना आर्ग्युमेंट वाले ओवरलोड से प्रेज़ेंटेशन की इमेज कलेक्शन वापस मिलती है।

छवि लोड करने के लिए [Images.fromFile](https://reference.aspose.com/slides/hi/python-java/aspose.slides/images/#fromFile) प्रयोग करें, उसे [ImageCollection.addImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/#addImage) से जोड़ें, या मौजूदा प्रेज़ेंटेशन की छवि को [PPImage.replaceImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#replaceImage) से अपडेट करें। दोनों इमेज‑कलेक्शन ऑपरेशन [IImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/) को स्वीकार करते हैं।

लोड या रेंडर की गई प्रत्येक छवि को `finally` ब्लॉक में उसकी `dispose` मेथड बुलाकर रिलीज़ करें। प्रेज़ेंटेशन को [Presentation.dispose](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#dispose) से रिलीज़ करें।

### **Python पर्यावरण तैयार करें**

[Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार पैकेज इंस्टॉल करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` इम्पोर्ट करता है, फिर JVM चलने पर API इम्पोर्ट करता है। उदाहरण JVM को चलाते रहने देते हैं ताकि इसे पुन: उपयोग किया जा सके। नोटबुक और JVM लाइफसाइकिल मार्गदर्शन के लिए [Limitations and API Differences](/slides/hi/python-java/limitations-and-api-differences/#import-the-library) देखें।

`pres.pptx` खोलने वाले उदाहरणों को वर्किंग डायरेक्टरी में एक प्रेज़ेंटेशन चाहिए। `image.png` लोड करने वाले उदाहरणों को मौजूदा इमेज फ़ाइल चाहिए।

### **एक तस्वीर लोड करें और स्लाइड रेंडर करें**

यह उदाहरण पहली स्लाइड में एक तस्वीर जोड़ता है और स्लाइड को JPEG छवि के रूप में सहेजता है। [IImage.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/#save) रेंडर की गई छवि को निर्दिष्ट फ़ॉर्मेट में लिखता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **पुराने कोड को आधुनिक API से बदलना**

पुराने थंबनेल कॉल को उन मेथड्स से बदलें जो [IImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/) लौटाते हैं, फिर परिणाम को [IImage.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/#save) से सहेजें। इससे [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-) को पास करने की आवश्यकता नहीं रहती।

### **निर्दिष्ट आकार में स्लाइड रेंडर करें**

पुराने `slide.getThumbnail(image_size)` कॉल को उसी इमेज साइज के साथ [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) से बदलें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **स्लाइड थंबनेल प्राप्त करना**

पुराने `slide.getThumbnail()` कॉल को बिना आर्ग्युमेंट के [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) से बदलें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **शेप थंबनेल प्राप्त करना**

पुराने `shape.getThumbnail()` कॉल को [Shape.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) से बदलें। शेष पहुँचने से पहले सुनिश्चित करें कि स्लाइड में वह शेप मौजूद है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **प्रेज़ेंटेशन थंबनेल प्राप्त करना**

पुराने `presentation.getThumbnails(options, image_size)` कॉल को [Presentation.getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) से बदलें। रेंडरिंग को कॉन्फ़िगर करने के लिए [RenderingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/renderingoptions/) उपयोग करें।

Python के `enumerate` के साथ लौटाई गई एरे पर सीधे इटेरेट करें। सहेजने में विफलता होने पर बची छवियों को अनडिस्पोज़ न रहने देने हेतु प्रत्येक लौटाई गई छवि को `finally` ब्लॉक में डिस्पोज़ करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **प्रेज़ेंटेशन में तस्वीर जोड़ना**

[ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) से लोड करने के बजाय [Images.fromFile](https://reference.aspose.com/slides/hi/python-java/aspose.slides/images/#fromFile) उपयोग करें, फिर परिणाम को [ImageCollection.addImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/#addImage) को पास करें। तस्वीर को स्लाइड में जोड़ें और प्रेज़ेंटेशन सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **डिप्रिकेटेड मेथड्स और उनका आधुनिक API में प्रतिस्थापन**

टेबल में Python कॉल नोटेशन उपयोग किया गया है। लेगेसी कॉलम में हटाए गए API के नाम दिखाए गये हैं; लिंक किए गए प्रतिस्थापन मेथड्स का उपयोग करें। आधुनिक इमेज‑रेंडरिंग मेथड्स Java BufferedImage की बजाय [IImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/) ऑब्जेक्ट लौटाते हैं।

### **Presentation**

टेबल में Python कॉल नोटेशन उपयोग किया गया है। लेगेसी कॉलम में हटाए गए API के नाम दिखाए गये हैं; लिंक किए गए प्रतिस्थापन मेथड्स का उपयोग करें। आधुनिक इमेज‑रेंडरिंग मेथड्स Java BufferedImage की बजाय [IImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/) ऑब्जेक्ट लौटाते हैं।

| Legacy call | Modern replacement |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) with `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) with `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) with `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) with `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) with `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) with `options, image_size` |

यहाँ `slides` एक Java `int[]` है जिसमें 1‑आधारित स्लाइड नंबर होते हैं; इसे `jpype.JArray(jpype.JInt)([1, 3])` से बनाकर स्लाइड 1 और 3 चुनें। `image_size` एक [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) है।

### **Shape**

| Legacy call | Modern replacement |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) with no arguments |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) with `bounds, scale_x, scale_y` |

### **Slide**

| Legacy call | Modern replacement |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) with no arguments |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) with `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) with `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) with `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) with `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) with `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) with `image_size` |
| `slide.renderToGraphics(options, graphics)` | कोई सीधा प्रतिस्थापन नहीं; इसके बजाय इमेज में रेंडर करें |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | कोई सीधा प्रतिस्थापन नहीं; इसके बजाय इमेज में रेंडर करें |
| `slide.renderToGraphics(options, graphics, image_size)` | कोई सीधा प्रतिस्थापन नहीं; इसके बजाय इमेज में रेंडर करें |

यहाँ `options` एक [RenderingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/renderingoptions/) है, और `tiff_options` एक [TiffOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/) है।

### **Output**

| Legacy call | Modern replacement |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/output/#add) with `path, image`, जहाँ `image` एक [IImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/) है |

### **ImageCollection**

| Legacy call | Modern replacement |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/#addImage) with an [IImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/) |

### **PPImage**

| Legacy call | Modern replacement |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#getImage) |

मौजूदा प्रेज़ेंटेशन इमेज की सामग्री बदलने के लिए, एक [IImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/) के साथ [PPImage.replaceImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/#replaceImage) प्रयोग करें।

### **PatternFormat**

| Legacy call | Modern replacement |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/hi/python-java/aspose.slides/patternformat/#getTile) with `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/hi/python-java/aspose.slides/patternformat/#getTile) with `background, foreground` |

रंग आर्ग्युमेंट अभी भी Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) ऑब्जेक्ट होते हैं।

### **PatternFormatEffectiveData**

Java API से JPype के माध्यम से प्राप्त प्रभावी पैटर्न डेटा के लिए, प्रतिस्थापन मेथड का नाम `getTileIImage` ही रहता है।

| Legacy call | Modern replacement |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, जो एक [IImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/) लौटाता है |

## **Graphics2D के लिए API समर्थन**

पुराने `renderToGraphics` ओवरलोड कॉलर‑प्रदान किए गए [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) कॉन्टेक्स्ट में ड्रॉ करते थे। आधुनिक API में ऐसा कोई सीधा प्रतिस्थापन नहीं है जो उसी कॉन्टेक्स्ट में ड्रॉ करे।

स्लाइड रेंडर करने के लिए [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) या कई स्लाइड्स के लिए [Presentation.getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) उपयोग करें, फिर लौटाई गई छवियों को [IImage.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/#save) से सहेजें। जिन अनुप्रयोगों ने स्लाइड रेंडरिंग को कस्टम Java ड्रॉइंग के साथ मिलाया था, उन्हें अपने कंपोज़िटिंग स्टेप को अनुकूलित करना होगा।

## **अक्सर पूछे जाने वाले प्रश्न**

**पुरानी Java इमेजिंग API को क्यों बदल दिया गया?**  
आधुनिक API छवि लोड, रेंडर और सेव को [IImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/iimage/) में ले जाता है। इससे इन वर्कफ़्लो में एक सामान्य छवि एब्स्ट्रैक्शन मिलती है, न कि Java BufferedImage या Java Graphics कॉन्टेक्स्ट।

**क्या अभी भी Java और JPype की आवश्यकता है?**  
हां। Aspose.Slides for Python via Java अभी भी JVM पर चलता है। आधुनिक API केवल इमेज‑प्रोसेसिंग कॉल्स को बदलता है, रन‑टाइम आवश्यकताओं को नहीं। देखें [System Requirements](/slides/hi/python-java/system-requirements/)।

**Python में छवियों को कैसे रिलीज़ करें?**  
प्रत्येक छवि को `finally` ब्लॉक में उसकी `dispose` मेथड कॉल करके रिलीज़ करें। यदि आप कई स्लाइड रेंडर करते हैं तो लौटाई गई एरे में प्रत्येक छवि को रिलीज़ करें। प्रेज़ेंटेशन को अलग से [Presentation.dispose](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#dispose) से रिलीज़ करें।

**क्या आधुनिक API पर स्विच करने से थंबनेल जेनरेशन तेज़ होगा?**  
कोई गारंटीकृत प्रदर्शन सुधार नहीं है। प्रतिस्थापन रेंडरिंग विकल्प, स्केलिंग और इमेज साइज को सपोर्ट करते हैं; प्रदर्शन को अपने प्रेज़ेंटेशन और आउटपुट सेटिंग्स के साथ मापें।

**छवि गेटर कभी-कभी कलेक्शन क्यों लौटाता है?**  
`options` के बिना [Presentation.getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) एम्बेडेड प्रेज़ेंटेशन छवियों को लौटाता है। रेंडरिंग विकल्पों के साथ ओवरलोड कॉल रेंडर की गई स्लाइड छवियों को लौटाता है।