---
title: Android पर प्रस्तुतियों में वॉटरमार्क जोड़ें
linktitle: वॉटरमार्क
type: docs
weight: 40
url: /hi/androidjava/watermark/
keywords:
- वॉटरमार्क
- पाठ वॉटरमार्क
- छवि वॉटरमार्क
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
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Android पर Java में PowerPoint और OpenDocument प्रस्तुतियों में पाठ और छवि वॉटरमार्क प्रबंधित करें ताकि ड्राफ्ट, गोपनीय जानकारी आदि को दर्शाया जा सके।"
---
## **परिचय**

**एक वॉटरमार्क** प्रस्तुति में वह पाठ या छवि स्टैम्प है जो किसी स्लाइड पर या सभी प्रस्तुति स्लाइड्स में उपयोग किया जाता है। आमतौर पर, वॉटरमार्क का उपयोग यह दर्शाने के लिए किया जाता है कि प्रस्तुति एक ड्राफ्ट है (उदाहरण के लिए, "Draft" वॉटरमार्क), इसमें गोपनीय जानकारी है (उदाहरण के लिए, "Confidential" वॉटरमार्क), यह किस कंपनी की है (उदाहरण के लिए, "Company Name" वॉटरमार्क), प्रस्तुति लेखक की पहचान करने आदि। वॉटरमार्क यह संकेत देकर कॉपीराइट उल्लंघन को रोकने में मदद करता है कि प्रस्तुति को कॉपी नहीं किया जाना चाहिए। वॉटरमार्क दोनों PowerPoint और OpenOffice प्रस्तुति स्वरूपों में उपयोग होते हैं। Aspose.Slides में आप PowerPoint PPT, PPTX और OpenOffice ODP फ़ाइल स्वरूपों में वॉटरमार्क जोड़ सकते हैं।

[**Aspose.Slides**](https://products.aspose.com/slides/hi/android-java/) में PowerPoint या OpenOffice दस्तावेज़ों में वॉटरमार्क बनाने और उनके डिज़ाइन तथा व्यवहार को संशोधित करने के कई तरीके हैं। सामान्य बात यह है कि पाठ वॉटरमार्क जोड़ने के लिए आपको [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) इंटरफ़ेस का उपयोग करना चाहिए, और चित्र वॉटरमार्क जोड़ने के लिए [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) क्लास या वॉटरमार्क आकार को छवि से भरना चाहिए। `PictureFrame` [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस को लागू करता है, जिससे आप आकार ऑब्जेक्ट की सभी लचीली सेटिंग्स का उपयोग कर सकते हैं। चूँकि `ITextFrame` एक आकार नहीं है और इसकी सेटिंग्स सीमित हैं, इसे एक [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) ऑब्जेक्ट में लिपटा जाता है।

वॉटरमार्क को लागू करने के दो तरीके हैं: एकल स्लाइड पर या सभी प्रस्तुति स्लाइड्स पर। सभी प्रस्तुति स्लाइड्स पर वॉटरमार्क लागू करने के लिए Slide Master का उपयोग किया जाता है — वॉटरमार्क को Slide Master में जोड़ा जाता है, वहां पूरी तरह से डिज़ाइन किया जाता है, और सभी स्लाइड्स पर लागू किया जाता है बिना व्यक्तिगत स्लाइड्स पर वॉटरमार्क के संशोधन की अनुमति को प्रभावित किए।

वॉटरमार्क को आम तौर पर अन्य उपयोगकर्ताओं द्वारा संपादन के लिए अनुपलब्ध माना जाता है। वॉटरमार्क (या मूलतः वॉटरमार्क के पैरेंट आकार) को संपादन से रोकने के लिए, Aspose.Slides आकार लॉक करने की सुविधा प्रदान करता है। किसी विशिष्ट आकार को सामान्य स्लाइड या Slide Master पर लॉक किया जा सकता है। जब वॉटरमार्क आकार Slide Master पर लॉक किया जाता है, तो यह सभी प्रस्तुति स्लाइड्स पर लॉक हो जाता है।

आप वॉटरमार्क का नाम सेट कर सकते हैं जिससे भविष्य में यदि आप इसे हटाना चाहते हैं, तो स्लाइड के आकारों में नाम द्वारा इसे खोज सकें।

आप वॉटरमार्क को किसी भी रूप में डिज़ाइन कर सकते हैं; हालांकि, वॉटरमार्क में आमतौर पर कुछ सामान्य विशेषताएँ होती हैं, जैसे केंद्र संरेखण, घुमाव, अग्र स्थिति आदि। हम नीचे दिए गए उदाहरणों में इनका उपयोग कैसे करें, इसे देखेंगे।

## **पाठ वॉटरमार्क**

### **स्लाइड पर पाठ वॉटरमार्क जोड़ें**

PPT, PPTX या ODP में पाठ वॉटरमार्क जोड़ने के लिए आप पहले स्लाइड में एक आकार जोड़ सकते हैं, फिर उस आकार में एक टेक्स्ट फ्रेम जोड़ सकते हैं। टेक्स्ट फ्रेम [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) इंटरफ़ेस द्वारा प्रतिनिधित्व किया जाता है। यह प्रकार [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) से विरासत में नहीं मिला है, जिसमें वॉटरमार्क को लचीले तरीके से स्थित करने के लिए व्यापक प्रॉपर्टीज़ सेट है। इसलिए, [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) ऑब्जेक्ट को एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) ऑब्जेक्ट में लिपटा जाता है। आकार में वॉटरमार्क टेक्स्ट जोड़ने के लिए, नीचे दिखाए अनुसार [addTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) मेथड का उपयोग करें।

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="और देखें" %}} 
- [TextFrame क्लास का उपयोग कैसे करें](/slides/hi/androidjava/text-formatting/)
{{% /alert %}}

### **पूरी प्रस्तुति में पाठ वॉटरमार्क जोड़ें**

यदि आप पूरी प्रस्तुति (अर्थात सभी स्लाइड्स एक साथ) में पाठ वॉटरमार्क जोड़ना चाहते हैं, तो इसे [MasterSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/masterslide/) में जोड़ें। बाकी लॉजिक वही है जैसा कि एकल स्लाइड में वॉटरमार्क जोड़ते समय होता है — एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) ऑब्जेक्ट बनाएं और फिर [addTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) मेथड का उपयोग करके वॉटरमार्क उसे जोड़ें।

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="और देखें" %}} 
- [Slide Master का उपयोग कैसे करें](/slides/hi/androidjava/slide-master/)
{{% /alert %}}

### **वॉटरमार्क आकार की पारदर्शिता सेट करें**

डिफ़ॉल्ट रूप से, आयताकार आकार को भराव और रेखा रंगों के साथ स्टाइल किया जाता है। नीचे दिया गया कोड आकार को पारदर्शी बनाता है।

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **पाठ वॉटरमार्क के फ़ॉन्ट को सेट करें**

नीचे दिखाए अनुसार आप पाठ वॉटरमार्क के फ़ॉन्ट को बदल सकते हैं।

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **वॉटरमार्क टेक्स्ट का रंग सेट करें**

वॉटरमार्क टेक्स्ट का रंग सेट करने के लिए, निम्न कोड का उपयोग करें:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **पाठ वॉटरमार्क को केंद्रित करें**

स्लाइड पर वॉटरमार्क को केंद्रित करना संभव है, और इसके लिए आप निम्न कर सकते हैं:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

![पाठ वॉटरमार्क](text_watermark.png)

## **छवि वॉटरमार्क**

### **प्रस्तुति में छवि वॉटरमार्क जोड़ें**

प्रस्तुति स्लाइड में छवि वॉटरमार्क जोड़ने के लिए आप निम्न कर सकते हैं:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **वॉटरमार्क को संपादन से लॉक करें**

यदि वॉटरमार्क को संपादन से रोकना आवश्यक है, तो आकार पर [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) मेथड का उपयोग करें। इस प्रॉपर्टी के साथ, आप आकार को चयन, आकार बदलने, पुनःस्थिति, अन्य तत्वों के साथ समूह बनाने, उसके टेक्स्ट को संपादन से लॉक करने आदि से बचा सकते हैं:

```java
// वॉटरमार्क आकार को संशोधित करने से रोकें
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **वॉटरमार्क को सामने लाएँ**

Aspose.Slides में आकारों के Z-ऑर्डर को [IShapeCollection.reorder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) मेथड के माध्यम से सेट किया जा सकता है। इसके लिए आपको प्रस्तुति स्लाइड्स की सूची से इस मेथड को कॉल करना होगा और आकार संदर्भ तथा उसका क्रम संख्या पास करनी होगी। इस तरह आप आकार को स्लाइड के सामने ला सकते हैं या पीछे भेज सकते हैं। यह सुविधा विशेष रूप से तब उपयोगी होती है जब आपको प्रस्तुति में वॉटरमार्क को सामने रखना हो:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **वॉटरमार्क का घुमाव सेट करें**

यहाँ एक कोड उदाहरण है जिसमें दिखाया गया है कि कैसे वॉटरमार्क का घुमाव समायोजित करें ताकि वह स्लाइड में तिरछे स्थित हो:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **वॉटरमार्क का नाम सेट करें**

Aspose.Slides आपको आकार का नाम सेट करने की अनुमति देता है। आकार के नाम का उपयोग करके आप भविष्य में उसे संशोधित या हटाने के लिए एक्सेस कर सकते हैं। वॉटरमार्क आकार का नाम सेट करने के लिए, इसे [IAutoShape.setName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) मेथड को असाइन करें:

```java
watermarkShape.setName("watermark");
```

### **वॉटरमार्क हटाएँ**

वॉटरमार्क आकार को हटाने के लिए, स्लाइड आकारों में इसे खोजने हेतु [IAutoShape.getName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getName--) मेथड का उपयोग करें। फिर, वॉटरमार्क आकार को [IShapeCollection.remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) मेथड में पास करें:

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**वॉटरमार्क क्या है और मुझे इसे क्यों उपयोग करना चाहिए?**

वॉटरमार्क स्लाइड्स पर लागू किया गया एक पाठ या छवि ओवरले है जो बौद्धिक संपदा की सुरक्षा, ब्रांड पहचान को बढ़ाने, या अनधिकृत उपयोग को रोकने में मदद करता है।

**क्या मैं प्रस्तुति की सभी स्लाइड्स में वॉटरमार्क जोड़ सकता हूँ?**

हां, Aspose.Slides आपको प्रोग्रामmatically प्रत्येक स्लाइड में वॉटरमार्क जोड़ने की अनुमति देता है। आप सभी स्लाइड्स पर क्रमशः इटररेट करके वॉटरमार्क सेटिंग्स लागू कर सकते हैं।

**मैं वॉटरमार्क की पारदर्शिता कैसे समायोजित कर सकता हूँ?**

आप आकार की भराव सेटिंग्स ([getFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getFillFormat--)) को संशोधित करके वॉटरमार्क की पारदर्शिता समायोजित कर सकते हैं। इस प्रकार वॉटरमार्क सूक्ष्म रहता है और स्लाइड सामग्री से ध्यान नहीं हटाता।

**वॉटरमार्क के लिए कौन से छवि स्वरूप समर्थित हैं?**

Aspose.Slides विभिन्न छवि स्वरूपों जैसे PNG, JPEG, GIF, BMP, SVG आदि को समर्थन देता है।

**क्या मैं पाठ वॉटरमार्क के फ़ॉन्ट और शैली को अनुकूलित कर सकता हूँ?**

हां, आप अपने प्रस्तुति के डिज़ाइन के अनुसार कोई भी फ़ॉन्ट, आकार और शैली चुन सकते हैं और ब्रांड स्थिरता बनाए रख सकते हैं।

**मैं वॉटरमार्क की स्थिति या अभिविन्यास कैसे बदल सकता हूँ?**

आप आकार के निर्देशांक, आकार और घुमाव गुणों को संशोधित करके प्रोग्रामmatically वॉटरमार्क की स्थिति और अभिविन्यास बदल सकते हैं।