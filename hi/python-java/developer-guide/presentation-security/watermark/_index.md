---
title: Python में प्रस्तुतियों में वॉटरमार्क जोड़ें
linktitle: वॉटरमार्क
type: docs
weight: 40
url: /hi/python-java/watermark/
keywords:
- वॉटरमार्क
- टेक्स्ट वॉटरमार्क
- इमेज वॉटरमार्क
- वॉटरमार्क जोड़ें
- वॉटरमार्क बदलें
- वॉटरमार्क हटाएं
- वॉटरमार्क मिटाएं
- PPT में वॉटरमार्क जोड़ें
- PPTX में वॉटरमार्क जोड़ें
- ODP में वॉटरमार्क जोड़ें
- PPT से वॉटरमार्क हटाएं
- PPTX से वॉटरमार्क हटाएं
- ODP से वॉटरमार्क हटाएं
- PPT से वॉटरमार्क मिटाएं
- PPTX से वॉटरमार्क मिटाएं
- ODP से वॉटरमार्क मिटाएं
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Python में PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट और इमेज वॉटरमार्क प्रबंधित करें ताकि ड्राफ्ट, गोपनीय जानकारी, कॉपीराइट आदि दर्शाए जा सकें।"
---
## **परिचय**

**एक वाटरमार्क** प्रस्तुति में एक टेक्स्ट या इमेज स्टैंप होता है जो स्लाइड या सभी स्लाइड्स पर प्रयोग किया जाता है। आम तौर पर वाटरमार्क का उपयोग यह दर्शाने के लिए किया जाता है कि प्रस्तुति ड्राफ्ट है (जैसे "Draft" वाटरमार्क), इसमें गोपनीय जानकारी है (जैसे "Confidential" वाटरमार्क), यह किस कंपनी की है (जैसे "Company Name" वाटरमार्क), लेखक को पहचानने आदि। वाटरमार्क कॉपीराइट उल्लंघन को रोकने में मदद करता है यह संकेत देकर कि प्रस्तुति को कॉपी नहीं किया जाना चाहिए। वाटरमार्क PowerPoint और OpenOffice दोनों प्रारूपों में उपयोग होते हैं। Aspose.Slides में आप PowerPoint PPT, PPTX और OpenOffice ODP फ़ाइल प्रारूपों में वाटरमार्क जोड़ सकते हैं।

[**Aspose.Slides**](https://products.aspose.com/slides/hi/python-java/) में आप PowerPoint या OpenOffice दस्तावेज़ों में वाटरमार्क बनाने और उनके डिजाइन व व्यवहार को बदलने के कई तरीके पा सकते हैं। सामान्य बात यह है कि टेक्स्ट वाटरमार्क जोड़ने के लिए आपको [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) क्लास का उपयोग करना चाहिए, और इमेज वाटरमार्क के लिए [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) क्लास या वाटरमार्क शैप को इमेज से भरना चाहिए। [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/) [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) क्लास से विरासत में मिलता है, जिससे आप शैप ऑब्जेक्ट की सभी लचीली सेटिंग्स उपयोग कर सकते हैं। चूँकि [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) एक शैप नहीं है और इसकी सेटिंग्स सीमित हैं, इसे एक [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) ऑब्जेक्ट में लपेटा जाता है।

वाटरमार्क दो तरीकों से लागू किया जा सकता है: एकल स्लाइड पर या सभी स्लाइड्स पर। सभी स्लाइड्स पर वाटरमार्क लागू करने के लिए स्लाइड मास्टर का उपयोग किया जाता है — वाटरमार्क स्लाइड मास्टर में जोड़ा जाता है, वहाँ पूरी तरह डिज़ाइन किया जाता है, और सभी स्लाइड्स पर लागू हो जाता है बिना व्यक्तिगत स्लाइड्स पर वाटरमार्क को संशोधित करने की अनुमति को प्रभावित किए।

वाटरमार्क को आम तौर पर अन्य उपयोगकर्ताओं द्वारा संपादन योग्य नहीं माना जाता। वाटरमार्क (या उसके पैरेंट शैप) को संपादन से रोकने के लिए Aspose.Slides शैप लॉकिंग फ़ंक्शन प्रदान करता है। किसी विशेष शैप को सामान्य स्लाइड या स्लाइड मास्टर पर लॉक किया जा सकता है। जब स्लाइड मास्टर पर वाटरमार्क शैप लॉक किया जाता है, तो वह सभी स्लाइड्स पर लॉक रह जाता है।

आप वाटरमार्क के लिए एक नाम सेट कर सकते हैं ताकि भविष्य में इसे हटाना चाहें तो नाम द्वारा स्लाइड के शैप्स में आसानी से खोज सकें।

आप वाटरमार्क को किसी भी तरीके से डिज़ाइन कर सकते हैं; हालांकि आम तौर पर वाटरमार्क में कुछ सामान्य विशेषताएँ होती हैं, जैसे केंद्र संरेखन, घुमाव, सामने की स्थिति आदि। हम नीचे दिए गए उदाहरणों में इन्हें कैसे उपयोग करें, देखेंगे।

## **टेक्स्ट वाटरमार्क**

### **स्लाइड में टेक्स्ट वाटरमार्क जोड़ना**

PPT, PPTX या ODP में टेक्स्ट वाटरमार्क जोड़ने के लिए आप पहले स्लाइड में एक शैप जोड़ें, फिर उस शैप में एक टेक्स्ट फ्रेम जोड़ें। टेक्स्ट फ्रेम को [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) क्लास द्वारा दर्शाया जाता है। यह प्रकार [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) से विरासत में नहीं लिया गया है, जिसके पास वाटरमार्क को लचीले ढंग से रखने के लिए कई प्रॉपर्टीज़ हैं। इसलिए, [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) ऑब्जेक्ट को एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) ऑब्जेक्ट में लपेटा जाता है। शैप में वाटरमार्क टेक्स्ट जोड़ने के लिए नीचे दिखाए अनुसार [addTextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/#addTextFrame) मेथड का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [How to Use the TextFrame Class](/slides/hi/python-java/text-formatting/)
{{% /alert %}}

### **प्रेज़ेंटेशन में टेक्स्ट वाटरमार्क जोड़ना**

यदि आप पूरे प्रेज़ेंटेशन (अर्थात सभी स्लाइड्स) में टेक्स्ट वाटरमार्क जोड़ना चाहते हैं, तो इसे [MasterSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/) में जोड़ें। शेष लॉजिक वही है जैसा एकल स्लाइड में वाटरमार्क जोड़ते समय होता है — एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) ऑब्जेक्ट बनाएं और फिर [addTextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/#addTextFrame) मेथड से वाटरमार्क जोड़ें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [How to Use the Slide Master](/slides/hi/python-java/slide-master/)
{{% /alert %}}

### **वाटरमार्क शैप की पारदर्शिता सेट करना**

डिफ़ॉल्ट रूप से, आयताकार शैप को फ़िल और लाइन रंगों से स्टाइल किया जाता है। नीचे दिया गया कोड शैप को पारदर्शी बनाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **टेक्स्ट वाटरमार्क के लिए फ़ॉन्ट सेट करना**

आप नीचे दिखाए अनुसार टेक्स्ट वाटरमार्क का फ़ॉन्ट बदल सकते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **वाटरमार्क टेक्स्ट रंग सेट करना**

वाटरमार्क टेक्स्ट का रंग सेट करने के लिए इस कोड का उपयोग करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **टेक्स्ट वाटरमार्क को केंद्र में रखना**

वाटरमार्क को स्लाइड पर केंद्रित करना संभव है, इसके लिए आप नीचे दिया गया कोड उपयोग कर सकते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

नीचे चित्र अंतिम परिणाम दिखाता है।

![The text watermark](text_watermark.png)

## **इमेज वाटरमार्क**

### **प्रेज़ेंटेशन में इमेज वाटरमार्क जोड़ना**

प्रेज़ेंटेशन स्लाइड में इमेज वाटरमार्क जोड़ने के लिए आप नीचे दिया गया कोड उपयोग कर सकते हैं:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **वाटरमार्क को संपादन से लॉक करना**

यदि वाटरमार्क को संपादित होने से रोकना आवश्यक है, तो शैप पर [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/#getAutoShapeLock) मेथड का उपयोग करें। इस प्रॉपर्टी से आप शैप को चयनित, आकार बदलने, स्थिति बदलने, अन्य तत्वों के साथ समूह बनाने, टेक्स्ट को संपादन से लॉक करने आदि से बचा सकते हैं:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # वॉटरमार्क शैप को संशोधन से लॉक करें।
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **वाटरमार्क को आगे लाना**

Aspose.Slides में शैप्स का Z-ऑर्डर [ShapeCollection.reorder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#reorder) मेथड द्वारा सेट किया जा सकता है। इसके लिए आपको स्लाइड की शैप कलेक्शन से इस मेथड को कॉल करना होगा और शैप रेफरेंस व उसकी क्रमांक संख्या पास करनी होगी। इस तरह आप शैप को आगे या पीछे ले जा सकते हैं। यह सुविधा तब उपयोगी होती है जब आपको प्रेज़ेंटेशन में वाटरमार्क को सामने रखना हो:

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **वाटरमार्क घुमाव सेट करना**

निम्न कोड उदाहरण दिखाता है कि कैसे वाटरमार्क का घुमाव समायोजित करके उसे स्लाइड के द्विदिश रूप में स्थित किया जाए:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **वाटरमार्क के लिए नाम सेट करना**

Aspose.Slides आपको शैप का नाम सेट करने की अनुमति देता है। शैप नाम का उपयोग करके आप भविष्य में उसे संशोधित या हटाने के लिए एक्सेस कर सकते हैं। वाटरमार्क शैप का नाम सेट करने के लिए उसे [Shape.setName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#setName) मेथड में पास करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **वाटरमार्क हटाना**

वाटरमार्क शैप को हटाने के लिए पहले [Shape.getName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getName) मेथड से इसे स्लाइड शैप्स में खोजें। फिर वाटरमार्क शैप को [ShapeCollection.remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#remove) मेथड में पास कर दें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **FAQ**

**वॉटरमार्क क्या है और मुझे इसे क्यों उपयोग करना चाहिए?**

वॉटरमार्क स्लाइड्स पर लागू किया गया टेक्स्ट या इमेज ओवरले है जो बौद्धिक संपदा की सुरक्षा, ब्रांड पहचान बढ़ाने या प्रेज़ेंटेशन के अनधिकृत उपयोग को रोकने में मदद करता है।

**क्या मैं प्रेज़ेंटेशन की सभी स्लाइड्स में वॉटरमार्क जोड़ सकता हूं?**

हां, Aspose.Slides आपको प्रोग्रामेटिक रूप से प्रत्येक स्लाइड में वॉटरमार्क जोड़ने की सुविधा देता है। आप सभी स्लाइड्स पर इटरिट करके व्यक्तिगत रूप से वाटरमार्क सेटिंग्स लागू कर सकते हैं।

**मैं वाटरमार्क की पारदर्शिता कैसे समायोजित कर सकता हूं?**

आप शैप के फ़िल सेटिंग्स ([getFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getFillFormat)) को बदलकर वाटरमार्क की पारदर्शिता समायोजित कर सकते हैं। इससे वाटरमार्क सूक्ष्म रहता है और स्लाइड सामग्री से ध्यान नहीं भड़काता।

**वॉटरमार्क के लिए कौन से इमेज फ़ॉर्मेट सपोर्टेड हैं?**

Aspose.Slides PNG, JPEG, GIF, BMP, SVG आदि विभिन्न इमेज फ़ॉर्मेट को सपोर्ट करता है।

**क्या मैं टेक्स्ट वाटरमार्क का फ़ॉन्ट और स्टाइल कस्टमाइज़ कर सकता हूं?**

हां, आप कोई भी फ़ॉन्ट, आकार और स्टाइल चुन सकते हैं जिससे आपके प्रेज़ेंटेशन का डिज़ाइन और ब्रांड कॉन्सिस्टेंसी बनी रहे।

**मैं वाटरमार्क की स्थिति या दिशा कैसे बदलूं?**

आप प्रोग्रामेटिक रूप से शैप के कोऑर्डिनेट्स, आकार और घुमाव प्रॉपर्टीज़ को बदलकर वाटरमार्क की स्थिति और दिशा समायोजित कर सकते हैं।