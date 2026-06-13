---
title: Java में प्रस्तुतीकरण में वॉटरमार्क जोड़ें
linktitle: वॉटरमार्क
type: docs
weight: 40
url: /hi/java/watermark/
keywords:
- वॉटरमार्क
- टेक्स्ट वॉटरमार्क
- छवि वॉटरमार्क
- वॉटरमार्क जोड़ें
- वॉटरमार्क बदलें
- वॉटरमार्क हटाएँ
- वॉटरमार्क हटाएँ
- PPT में वॉटरमार्क जोड़ें
- PPTX में वॉटरमार्क जोड़ें
- ODP में वॉटरमार्क जोड़ें
- PPT से वॉटरमार्क हटाएँ
- PPTX से वॉटरमार्क हटाएँ
- ODP से वॉटरमार्क हटाएँ
- PPT से वॉटरमार्क हटाएँ
- PPTX से वॉटरमार्क हटाएँ
- ODP से वॉटरमार्क हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Java
- Aspose.Slides
description: "Java में PowerPoint और OpenDocument प्रस्तुतीकरण में टेक्स्ट और इमेज वॉटरमार्क प्रबंधित करें ताकि ड्राफ्ट, गोपनीय जानकारी, कॉपीराइट आदि दर्शाए जा सकें।"
---
## **परिचय**

**A watermark** एक प्रस्तुतीकरण में टेक्स्ट या छवि स्टैंप होता है जो एक स्लाइड पर या सभी प्रस्तुतीकरण स्लाइड्स में उपयोग किया जाता है। आमतौर पर, वॉटरमार्क का उपयोग यह दर्शाने के लिए किया जाता है कि प्रस्तुतीकरण ड्राफ्ट है (जैसे, "Draft" वॉटरमार्क), इसमें गोपनीय जानकारी है (जैसे, "Confidential" वॉटरमार्क), यह किस कंपनी से संबंधित है (जैसे, "Company Name" वॉटरमार्क), प्रस्तुतीकरण लेखक की पहचान करने के लिए आदि। वॉटरमार्क कॉपीराइट उल्लंघनों को रोकने में मदद करता है यह संकेत देकर कि प्रस्तुतीकरण को कॉपी नहीं किया जाना चाहिए। वॉटरमार्क दोनों PowerPoint और OpenOffice प्रस्तुतीकरण फ़ॉर्मेट में उपयोग किए जाते हैं। Aspose.Slides में, आप PowerPoint PPT, PPTX, और OpenOffice ODP फ़ाइल फ़ॉर्मेट में वॉटरमार्क जोड़ सकते हैं।

In [**Aspose.Slides**](https://products.aspose.com/slides/hi/java/), आप PowerPoint या OpenOffice दस्तावेज़ों में वॉटरमार्क बनाने और उनके डिज़ाइन एवं व्यवहार को संशोधित करने के कई तरीके हैं। सामान्य बात यह है कि टेक्स्ट वॉटरमार्क जोड़ने के लिए आपको [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) इंटरफ़ेस का उपयोग करना चाहिए, और छवि वॉटरमार्क जोड़ने के लिए [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) क्लास या वॉटरमार्क आकार को छवि से भरना चाहिए। `PictureFrame` [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) इंटरफ़ेस को लागू करता है, जिससे आप आकार ऑब्जेक्ट की सभी लचीली सेटिंग्स का उपयोग कर सकते हैं। चूँकि `ITextFrame` एक आकार नहीं है और इसकी सेटिंग्स सीमित हैं, इसे एक [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) ऑब्जेक्ट में लपेटा जाता है।

वॉटरमार्क को लागू करने के दो तरीके हैं: एकल स्लाइड पर या सभी प्रस्तुतीकरण स्लाइड्स पर। सभी प्रस्तुतीकरण स्लाइड्स पर वॉटरमार्क लागू करने के लिए स्लाइड मास्टर का उपयोग किया जाता है — वॉटरमार्क को स्लाइड मास्टर में जोड़ा जाता है, वहाँ पूर्ण रूप से डिज़ाइन किया जाता है, और सभी स्लाइड्स पर लागू होता है बिना व्यक्तिगत स्लाइड्स पर वॉटरमार्क को संशोधित करने की अनुमति को प्रभावित किए।

वॉटरमार्क आमतौर पर अन्य उपयोगकर्ताओं द्वारा संपादन के लिए उपलब्ध नहीं माना जाता है। वॉटरमार्क (या बल्कि वॉटरमार्क के पैरेंट आकार) को संपादन से रोकने के लिए Aspose.Slides आकार लॉकिंग कार्यक्षमता प्रदान करता है। एक विशिष्ट आकार को सामान्य स्लाइड या स्लाइड मास्टर पर लॉक किया जा सकता है। जब वॉटरमार्क आकार स्लाइड मास्टर पर लॉक किया जाता है, तो यह सभी प्रस्तुतीकरण स्लाइड्स पर लॉक हो जाता है।

आप वॉटरमार्क के लिए एक नाम सेट कर सकते हैं ताकि भविष्य में इसे हटाने की आवश्यकता होने पर आप इसे स्लाइड के आकारों में नाम से खोज सकें।

आप वॉटरमार्क को किसी भी तरह डिज़ाइन कर सकते हैं; हालांकि, वॉटरमार्क में आमतौर पर सामान्य विशेषताएँ होती हैं, जैसे केंद्र संरेखण, घूर्णन, आगे की स्थिति आदि। हम नीचे दिए गए उदाहरणों में इनका उपयोग कैसे करें, इसे देखेंगे।

## **पाठ वॉटरमार्क**

### **स्लाइड में टेक्स्ट वॉटरमार्क जोड़ें**

PPT, PPTX, या ODP में टेक्स्ट वॉटरमार्क जोड़ने के लिए, आप पहले स्लाइड में एक आकार जोड़ सकते हैं, फिर इस आकार में एक टेक्स्ट फ्रेम जोड़ सकते हैं। टेक्स्ट फ्रेम को [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) इंटरफ़ेस द्वारा दर्शाया जाता है। यह प्रकार [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) से विरासत में नहीं मिला है, जिसके पास आकार को लचीले तरीके से स्थित करने के लिए व्यापक गुण होते हैं। इसलिए, [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) ऑब्जेक्ट को एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) ऑब्जेक्ट में लपेटा जाता है। आकार में वॉटरमार्क टेक्स्ट जोड़ने के लिए, नीचे दिखाए अनुसार [addTextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) मेथड का उपयोग करें।

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [टेक्स्टफ़्रेम क्लास का उपयोग कैसे करें](/slides/hi/java/text-formatting/)
{{% /alert %}}

### **पूरे प्रस्तुतीकरण में टेक्स्ट वॉटरमार्क जोड़ें**

यदि आप पूरे प्रस्तुतीकरण (अर्थात, सभी स्लाइड्स एक साथ) में टेक्स्ट वॉटरमार्क जोड़ना चाहते हैं, तो इसे [MasterSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/masterslide/) में जोड़ें। बाकी लॉजिक वही है जैसा कि एकल स्लाइड में वॉटरमार्क जोड़ते समय होता है — एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) ऑब्जेक्ट बनाएं और फिर [addTextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) मेथड का उपयोग करके वॉटरमार्क जोड़ें।

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [स्लाइड मास्टर का उपयोग कैसे करें](/slides/hi/java/slide-master/)
{{% /alert %}}

### **वॉटरमार्क आकार की पारदर्शिता सेट करें**

डिफ़ॉल्ट रूप से, आयत आकार को फ़िल और लाइन रंगों के साथ शैलीबद्ध किया जाता है। नीचे दिया गया कोड आकार को पारदर्शी बनाता है।

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **टेक्स्ट वॉटरमार्क के लिए फ़ॉन्ट सेट करें**

आप नीचे दिखाए अनुसार टेक्स्ट वॉटरमार्क का फ़ॉन्ट बदल सकते हैं।

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **वॉटरमार्क टेक्स्ट का रंग सेट करें**

वॉटरमार्क टेक्स्ट का रंग सेट करने के लिए यह कोड उपयोग करें:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **टेक्स्ट वॉटरमार्क को केंद्रित करें**

वॉटरमार्क को स्लाइड के केंद्र में रखें, इसके लिए आप नीचे दिया गया कोड उपयोग कर सकते हैं:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

नीचे की छवि अंतिम परिणाम दिखाती है।

![टेक्स्ट वॉटरमार्क](text_watermark.png)

## **छवि वॉटरमार्क**

### **प्रस्तुतीकरण में छवि वॉटरमार्क जोड़ें**

प्रस्तुतीकरण स्लाइड में छवि वॉटरमार्क जोड़ने के लिए आप नीचे दिया गया कोड उपयोग कर सकते हैं:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **वॉटरमार्क को संपादन से लॉक करें**

यदि वॉटरमार्क को संपादन से रोकना आवश्यक है, तो आकार पर [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) मेथड का उपयोग करें। इस प्रॉपर्टी से आप आकार को चयन, आकार बदलने, स्थान बदलने, अन्य तत्वों के साथ समूह बनाने, टेक्स्ट को संपादन से लॉक करने आदि से सुरक्षा दे सकते हैं:

```java
// वॉटरमार्क आकार को संशोधित करने से लॉक करें
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **वॉटरमार्क को आगे लाएँ**

Aspose.Slides में, आकारों का Z‑order [IShapeCollection.reorder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) मेथड से सेट किया जा सकता है। इसके लिए आपको प्रस्तुतिकरण स्लाइड्स की सूची से इस मेथड को कॉल करना होगा और आकार के रेफ़रेंस तथा उसका क्रमांक पास करना होगा। इस तरह आप आकार को स्लाइड के सामने ला सकते हैं या पीछे भेज सकते हैं। यह विशेषता विशेष रूप से तब उपयोगी होती है जब आपको वॉटरमार्क को प्रस्तुतीकरण के सामने रखना हो:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **वॉटरमार्क घूर्णन सेट करें**

नीचे कोड उदाहरण दिखाता है कि कैसे वॉटरमार्क का घूर्णन समायोजित किया जा सकता है ताकि वह स्लाइड में तिरछा स्थित हो:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **वॉटरमार्क के लिए नाम सेट करें**

Aspose.Slides आपको आकार का नाम सेट करने की अनुमति देता है। आकार नाम का उपयोग करके आप भविष्य में इसे संशोधित या हटाने के लिए एक्सेस कर सकते हैं। वॉटरमार्क आकार का नाम सेट करने के लिए, इसे [IAutoShape.setName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setName-java.lang.String-) मेथड को असाइन करें:

```java
watermarkShape.setName("watermark");
```

### **वॉटरमार्क हटाएँ**

वॉटरमार्क आकार को हटाने के लिए, पहले [IAutoShape.getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getName--) मेथड से इसे स्लाइड आकारों में खोजें। फिर उस वॉटरमार्क आकार को [IShapeCollection.remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) मेथड में पास करें:

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

**वॉटरमार्क क्या है और मुझे इसका उपयोग क्यों करना चाहिए?**  
वॉटरमार्क एक टेक्स्ट या छवि ओवरले है जो स्लाइडों पर लगाया जाता है और यह बौद्धिक संपदा की रक्षा, ब्रांड पहचान बढ़ाने, या प्रस्तुतीकरण के अनधिकृत उपयोग को रोकने में मदद करता है।

**क्या मैं प्रस्तुतीकरण में सभी स्लाइड्स में वॉटरमार्क जोड़ सकता हूँ?**  
हाँ, Aspose.Slides आपको प्रोग्रामेटिक रूप से प्रत्येक स्लाइड में वॉटरमार्क जोड़ने की अनुमति देता है। आप सभी स्लाइड्स के माध्यम से लूप कर वॉटरमार्क सेटिंग्स को व्यक्तिगत रूप से लागू कर सकते हैं।

**मैं वॉटरमार्क की पारदर्शिता कैसे समायोजित कर सकता हूँ?**  
आप आकार के फ़िल सेटिंग्स ([getFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getFillFormat--)) को संशोधित करके वॉटरमार्क की पारदर्शिता बदल सकते हैं। इससे वॉटरमार्क सूक्ष्म रहता है और स्लाइड सामग्री से ध्यान नहीं हटाता।

**वॉटरमार्क के लिए कौन से छवि फ़ॉर्मेट समर्थित हैं?**  
Aspose.Slides विभिन्न छवि फ़ॉर्मेट जैसे PNG, JPEG, GIF, BMP, SVG और अन्य को समर्थन देता है।

**क्या मैं टेक्स्ट वॉटरमार्क के फ़ॉन्ट और शैली को अनुकूलित कर सकता हूँ?**  
हाँ, आप किसी भी फ़ॉन्ट, आकार और शैली को चुन सकते हैं जिससे यह आपके प्रस्तुतीकरण के डिज़ाइन और ब्रांड संगतता से मेल खाता हो।

**मैं वॉटरमार्क की स्थिति या अभिविन्यास कैसे बदलूँ?**  
आप आकार के निर्देशांक, आकार, और घूर्णन गुणों को प्रोग्रामेटिक रूप से संशोधित करके वॉटरमार्क की स्थिति और अभिविन्यास बदल सकते हैं।