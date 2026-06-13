---
title: जावास्क्रिप्ट में प्रस्तुतियों में वॉटरमार्क जोड़ें
linktitle: वॉटरमार्क
type: docs
weight: 40
url: /hi/nodejs-java/watermark/
keywords:
- वॉटरमार्क
- टेक्स्ट वॉटरमार्क
- इमेज वॉटरमार्क
- वॉटरमार्क जोड़ें
- वॉटरमार्क बदलें
- वॉटरमार्क हटाएँ
- वॉटरमार्क मिटाएँ
- PPT में वॉटरमार्क जोड़ें
- PPTX में वॉटरमार्क जोड़ें
- ODP में वॉटरमार्क जोड़ें
- PPT से वॉटरमार्क हटाएँ
- PPTX से वॉटरमार्क हटाएँ
- ODP से वॉटरमार्क हटाएँ
- PPT से वॉटरमार्क मिटाएँ
- PPTX से वॉटरमार्क मिटाएँ
- ODP से वॉटरमार्क मिटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js में PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट और इमेज वॉटरमार्क प्रबंधित करें ताकि ड्राफ्ट, संवेदनशील जानकारी, कॉपीराइट आदि संकेतित हो सके।"
---
## **परिचय**

**वॉटरमार्क** एक प्रस्तुति में वह टेक्स्ट या इमेज स्टैंप होता है जो किसी स्लाइड पर या सभी प्रस्तुति स्लाइडों में प्रयोग किया जाता है। आमतौर पर वॉटरमार्क यह संकेत देने के लिए उपयोग किया जाता है कि प्रस्तुति ड्राफ्ट है (जैसे, "Draft" वॉटरमार्क), उसमें संवेदनशील जानकारी है (जैसे, "Confidential" वॉटरमार्क), यह किस कंपनी की है (जैसे, "Company Name" वॉटरमार्क), प्रस्तुति के लेखक की पहचान के लिए आदि। वॉटरमार्क यह दर्शाकर कॉपीराइट उल्लंघन को रोकने में मदद करता है कि प्रस्तुति को कॉपी नहीं किया जाना चाहिए। वॉटरमार्क दोनों PowerPoint और OpenOffice प्रस्तुति फ़ॉर्मेट में उपयोग किया जाता है। Aspose.Slides में आप PowerPoint PPT, PPTX और OpenOffice ODP फ़ाइल फ़ॉर्मेट में वॉटरमार्क जोड़ सकते हैं।

[**Aspose.Slides**](https://products.aspose.com/slides/hi/nodejs-java/) में कई तरीकों से आप PowerPoint या OpenOffice दस्तावेज़ों में वॉटरमार्क बना सकते हैं और उनके डिज़ाइन एवं व्यवहार को संशोधित कर सकते हैं। सामान्य बात यह है कि टेक्स्ट वॉटरमार्क जोड़ने के लिए आपको [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) प्रकार का उपयोग करना चाहिए, और इमेज वॉटरमार्क के लिए [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) क्लास या वॉटरमार्क आकार को इमेज से भरना चाहिए। `PictureFrame` [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) प्रकार को लागू करता है, जिससे आप आकार ऑब्जेक्ट की सभी लचीली सेटिंग्स का उपयोग कर सकते हैं। क्योंकि `TextFrame` कोई आकार नहीं है और इसकी सेटिंग्स सीमित हैं, इसे एक [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) ऑब्जेक्ट में लपेटा जाता है।

वॉटरमार्क लागू करने के दो तरीके हैं: एकल स्लाइड पर या सभी प्रस्तुति स्लाइडों पर। सभी स्लाइडों पर वॉटरमार्क लागू करने के लिए स्लाइड मास्टर का उपयोग किया जाता है — वॉटरमार्क को स्लाइड मास्टर में जोड़ा जाता है, वहाँ पूरी तरह से डिज़ाइन किया जाता है, और सभी स्लाइडों पर लागू किया जाता है बिना व्यक्तिगत स्लाइडों पर वॉटरमार्क को संशोधित करने की अनुमति को प्रभावित किए।

वॉटरमार्क को आमतौर पर अन्य उपयोगकर्ताओं द्वारा संपादन योग्य नहीं माना जाता। वॉटरमार्क (या बल्कि वॉटरमार्क के पैरेंट आकार) को संपादन से बचाने के लिए Aspose.Slides आकार लॉकिंग कार्यक्षमता प्रदान करता है। एक विशिष्ट आकार को सामान्य स्लाइड या स्लाइड मास्टर पर लॉक किया जा सकता है। जब स्लाइड मास्टर पर वॉटरमार्क आकार लॉक किया जाता है, तो यह सभी प्रस्तुति स्लाइडों पर लॉक हो जाता है।

आप वॉटरमार्क को एक नाम दे सकते हैं ताकि भविष्य में यदि आप इसे हटाना चाहते हैं, तो आप इसे स्लाइड के आकारों में नाम द्वारा खोज सकें।

आप वॉटरमार्क को किसी भी तरीके से डिज़ाइन कर सकते हैं; हालांकि, वॉटरमार्क में आमतौर पर कुछ सामान्य विशेषताएँ होती हैं, जैसे केंद्र संरेखण, घुमाव, सामने की स्थिति आदि। हम नीचे दिए गए उदाहरणों में इन्हें कैसे उपयोग किया जाए, इस पर विचार करेंगे।

## **टेक्स्ट वॉटरमार्क**

### **स्लाइड में टेक्स्ट वॉटरमार्क जोड़ें**
PPT, PPTX या ODP में टेक्स्ट वॉटरमार्क जोड़ने के लिए आप पहले स्लाइड में एक आकार जोड़ सकते हैं, फिर उस आकार में एक टेक्स्ट फ्रेम जोड़ सकते हैं। टेक्स्ट फ्रेम को [**TextFrame**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrame) प्रकार द्वारा दर्शाया जाता है। यह प्रकार [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape) से विरासत में नहीं मिला है, जिसमें वॉटरमार्क को लचीले तरीके से स्थित करने के लिए विस्तृत प्रॉपर्टी सेट होते हैं। इसलिए, [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrame) ऑब्जेक्ट को एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) ऑब्जेक्ट में लपेटा जाता है। आकार में वॉटरमार्क टेक्स्ट जोड़ने के लिए, वॉटरमार्क टेक्स्ट को पास करते हुए [**addTextFrame**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) मेथड का उपयोग करें:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- कैसे उपयोग करें [TextFrame](/slides/hi/nodejs-java/text-formatting/)।
{{% /alert %}}

### **प्रस्तुति में टेक्स्ट वॉटरमार्क जोड़ें**

यदि आप पूरे प्रस्तुति (अर्थात, सभी स्लाइडों) में टेक्स्ट वॉटरमार्क जोड़ना चाहते हैं, तो इसे [**MasterSlide**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MasterSlide) में जोड़ें। बाकी लॉजिक वही है जैसा कि एकल स्लाइड में वॉटरमार्क जोड़ते समय होता है — एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) ऑब्जेक्ट बनाएँ और फिर [**addTextFrame**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) मेथड का उपयोग करके वॉटरमार्क जोड़ें:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [कैसे उपयोग करें ](/slides/hi/nodejs-java/slide-master/)[Slide Master](/slides/hi/nodejs-java/slide-master/) 
{{% /alert %}}

### **वॉटरमार्क आकार की पारदर्शिता सेट करें**

डिफ़ॉल्ट रूप से, आयताकार आकार को भराव और रेखा रंगों के साथ स्टाइल किया जाता है। निम्नलिखित कोड लाइनें आकार को पारदर्शी बनाती हैं।

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **टेक्स्ट वॉटरमार्क के लिए फ़ॉन्ट सेट करें**

निम्नानुसार आप टेक्स्ट वॉटरमार्क का फ़ॉन्ट बदल सकते हैं।

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **वॉटरमार्क टेक्स्ट का रंग सेट करें**

वॉटरमार्क टेक्स्ट का रंग सेट करने के लिए इस कोड का उपयोग करें:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **टेक्स्ट वॉटरमार्क को केंद्रित करें**
स्लाइड पर वॉटरमार्क को केंद्र में लाने के लिए आप निम्नलिखित कर सकते हैं:

```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

नीचे चित्र अंतिम परिणाम दर्शाता है।

![टेक्स्ट वॉटरमार्क](text_watermark.png)

## **इमेज वॉटरमार्क**

### **प्रस्तुति में इमेज वॉटरमार्क जोड़ें**

सभी प्रस्तुति स्लाइडों में इमेज वॉटरमार्क जोड़ने के लिए आप निम्न कार्य कर सकते हैं:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **वॉटरमार्क को संपादन से लॉक करें**

यदि वॉटरमार्क को संपादित होने से रोकना आवश्यक है, तो आकार पर [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape#getShapeLock--) मेथड का प्रयोग करें। इस प्रॉपर्टी के साथ आप आकार को चयन, आकार बदलने, पुनर्स्थापन, अन्य तत्वों के साथ समूह बनाने, टेक्स्ट को संपादन से लॉक करने आदि से बचा सकते हैं:

```javascript
// वाटरमार्क आकार को संशोधित करने से लॉक करें
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **वॉटरमार्क को आगे ले जाएँ**

Aspose.Slides में, आकारों की Z-क्रम को [**SlideCollection.reorder**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) मेथड से सेट किया जा सकता है। ऐसा करने के लिए, प्रस्तुति स्लाइड सूची से इस मेथड को कॉल करें और आकार का रेफ़रेंस तथा उसका क्रमांक पास करें। इस तरह आप आकार को स्लाइड के आगे या पीछे ले जा सकते हैं। यह सुविधा विशेष रूप से उपयोगी है जब आपको वॉटरमार्क को प्रस्तुति के सामने रखना हो:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **वॉटरमार्क का घुमाव सेट करें**

यहाँ एक कोड उदाहरण है जो वॉटरमार्क को स्लाइड के तिरछे स्थित करने के लिए घुमाव समायोजित करता है:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **वॉटरमार्क के लिए नाम सेट करें**

Aspose.Slides आपको आकार का नाम सेट करने की अनुमति देता है। आकार नाम का उपयोग करके आप भविष्य में इसे संशोधित या हटाने के लिए पहुँच सकते हैं। वॉटरमार्क आकार का नाम सेट करने के लिए इसे [**AutoShape.getName**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getName--) मेथड को असाइन करें:

```javascript
watermarkShape.setName("watermark");
```

### **वॉटरमार्क हटाएँ**

वॉटरमार्क आकार को हटाने के लिए, स्लाइड आकारों में इसे खोजने हेतु [AutoShape.getName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getName--) मेथड का उपयोग करें। फिर वॉटरमार्क आकार को [**ShapeCollection.remove**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) मेथड में पास करें:

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**वॉटरमार्क क्या है और मुझे इसे क्यों उपयोग करना चाहिए?**

वॉटरमार्क एक टेक्स्ट या इमेज ओवरले है जो स्लाइडों पर लागू किया जाता है और बौद्धिक संपदा की रक्षा, ब्रांड पहचान बढ़ाने या अनधिकृत उपयोग को रोकने में मदद करता है।

**क्या मैं प्रस्तुति की सभी स्लाइडों में वॉटरमार्क जोड़ सकता हूँ?**

हाँ, Aspose.Slides आपको प्रस्तुति की हर स्लाइड में वॉटरमार्क जोड़ने की अनुमति देता है। आप सभी स्लाइडों पर लूप करके वॉटरमार्क सेटिंग्स व्यक्तिगत रूप से लागू कर सकते हैं।

**मैं वॉटरमार्क की पारदर्शिता कैसे समायोजित करूँ?**

आप आकार की [fill सेटिंग्स](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getfillformat/) को संशोधित करके वॉटरमार्क की पारदर्शिता समायोजित कर सकते हैं। यह सुनिश्चित करता है कि वॉटरमार्क हल्का रहे और स्लाइड सामग्री से ध्यान न हटाए।

**वॉटरमार्क के लिए किन इमेज फ़ॉर्मेट्स का समर्थन किया जाता है?**

Aspose.Slides PNG, JPEG, GIF, BMP, SVG आदि जैसे विभिन्न इमेज फ़ॉर्मेट्स का समर्थन करता है।

**क्या मैं टेक्स्ट वॉटरमार्क के फ़ॉन्ट और शैली को कस्टमाइज़ कर सकता हूँ?**

हाँ, आप अपनी प्रस्तुति के डिज़ाइन और ब्रांड संगतता के अनुसार कोई भी फ़ॉन्ट, आकार और शैली चुन सकते हैं।

**मैं वॉटरमार्क की स्थिति या अभिविन्यास कैसे बदलूँ?**

आप आकार के निर्देशांक, आकार और घुमाव प्रॉपर्टीज़ को बदलकर वॉटरमार्क की स्थिति और अभिविन्यास समायोजित कर सकते हैं।