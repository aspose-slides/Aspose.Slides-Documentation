---
title: जावा में प्रस्तुतियों में वॉटरमार्क जोड़ें
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
- पावरपॉइंट
- ओपनडॉक्युमेंट
- प्रस्तुति
- जावा
- Aspose.Slides
description: "जावा में पावरपॉइंट और ओपनडॉक्युमेंट प्रस्तुतियों में टेक्स्ट और इमेज वॉटरमार्क को प्रबंधित करें ताकि ड्राफ़्ट, गोपनीय जानकारी, कॉपीराइट आदि को दर्शाया जा सके।"
---
## **परिचय**

**एक वॉटरमार्क** प्रस्तुति में वह टेक्स्ट या इमेज स्टैंप है जो किसी स्लाइड या सभी प्रस्तुति स्लाइड्स पर उपयोग किया जाता है। आम तौर पर वॉटरमार्क यह संकेत देने के लिए उपयोग किया जाता है कि प्रस्तुति ड्राफ्ट है (जैसे, "Draft" वॉटरमार्क), इसमें गोपनीय जानकारी है (जैसे, "Confidential" वॉटरमार्क), यह किस कंपनी की है (जैसे, "Company Name" वॉटरमार्क), प्रस्तुति लेखक की पहचान के लिए आदि। वॉटरमार्क यह दर्शाकर कॉपीराइट उल्लंघन को रोकने में मदद करता है कि प्रस्तुति को कॉपी नहीं किया जाना चाहिए। वॉटरमार्क PowerPoint और OpenOffice दोनों प्रस्तुति फॉर्मेट में उपयोग किए जाते हैं। Aspose.Slides में आप PowerPoint PPT, PPTX और OpenOffice ODP फ़ाइल फ़ॉर्मेट में वॉटरमार्क जोड़ सकते हैं।

[**Aspose.Slides**](https://products.aspose.com/slides/hi/java/) में विभिन्न तरीकों से आप PowerPoint या OpenOffice दस्तावेज़ों में वॉटरमार्क बना सकते हैं और उनके डिजाइन एवं व्यवहार को बदल सकते हैं। सामान्य बात यह है कि टेक्स्ट वॉटरमार्क जोड़ने के लिए आपको [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) इंटरफ़ेस का उपयोग करना चाहिए, और इमेज वॉटरमार्क जोड़ने के लिए [PictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pictureframe/) क्लास या वॉटरमार्क शेप को इमेज से भरना चाहिए। `PictureFrame` [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) इंटरफ़ेस को लागू करता है, जिससे आप शेप ऑब्जेक्ट की सभी लचीली सेटिंग्स का उपयोग कर सकते हैं। चूँकि `ITextFrame` एक शेप नहीं है और उसकी सेटिंग्स सीमित हैं, इसे एक [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) ऑब्जेक्ट में लपेटा जाता है।

वॉटरमार्क दो तरीकों से लागू किया जा सकता है: एकल स्लाइड पर या सभी प्रस्तुति स्लाइड्स पर। सभी स्लाइड्स पर वॉटरमार्क लागू करने के लिए स्लाइड मास्टर का उपयोग किया जाता है — वॉटरमार्क स्लाइड मास्टर में जोड़ा जाता है, वहाँ पूरी तरह डिजाइन किया जाता है, और सभी स्लाइड्स पर लागू किया जाता है बिना व्यक्तिगत स्लाइड्स पर वॉटरमार्क को संशोधित करने की अनुमति को प्रभावित किए।

वॉटरमार्क आम तौर पर अन्य उपयोगकर्ताओं के लिए संपादन योग्य नहीं माना जाता। वॉटरमार्क (या अधिक सही शब्द में वॉटरमार्क की पैरेंट शेप) को संपादन से बचाने के लिए Aspose.Slides शेप लॉकिंग फ़ंक्शन प्रदान करता है। एक विशिष्ट शेप को सामान्य स्लाइड या स्लाइड मास्टर पर लॉक किया जा सकता है। जब स्लाइड मास्टर पर वॉटरमार्क शेप लॉक किया जाता है, तो वह सभी प्रस्तुति स्लाइड्स पर लॉक रह जाता है।

आप वॉटरमार्क का नाम सेट कर सकते हैं ताकि भविष्य में यदि आप इसे हटाना चाहें, तो आप इसे स्लाइड के शेप्स में नाम से खोज सकें।

आप वॉटरमार्क को किसी भी तरीके से डिजाइन कर सकते हैं; toutefois, आमतौर पर वॉटरमार्क में कुछ सामान्य विशेषताएँ होती हैं, जैसे केंद्र संरेखण, घुमाव, सामने की स्थिति आदि। हम नीचे दिए गए उदाहरणों में इनका उपयोग कैसे करें, इस पर विचार करेंगे।

## **टेक्स्ट वॉटरमार्क**

### **स्लाइड में टेक्स्ट वॉटरमार्क जोड़ें**

PPT, PPTX या ODP में टेक्स्ट वॉटरमार्क जोड़ने के लिए आप पहले स्लाइड में एक शेप जोड़ सकते हैं, फिर उस शेप में एक टेक्स्ट फ्रेम जोड़ सकते हैं। टेक्स्ट फ्रेम [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) इंटरफ़ेस द्वारा प्रदर्शित होता है। यह प्रकार [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) से विरासत में प्राप्त नहीं है, जिसमें वॉटरमार्क को लचीले तरीके से पोजिशन करने के लिए कई प्रॉपर्टीज़ हैं। इसलिए, [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) ऑब्जेक्ट को एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) ऑब्जेक्ट में लपेटा जाता है। शेप में वॉटरमार्क टेक्स्ट जोड़ने के लिए नीचे दिखाए गए अनुसार [addTextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) मेथड का उपयोग करें।

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [टेक्स्टफ़्रेम क्लास का उपयोग कैसे करें](/slides/hi/java/text-formatting/)
{{% /alert %}}

### **प्रेजेंटेशन में टेक्स्ट वॉटरमार्क जोड़ें**

यदि आप पूरे प्रेजेंटेशन (यानी सभी स्लाइड्स एक साथ) में टेक्स्ट वॉटरमार्क जोड़ना चाहते हैं, तो उसे [MasterSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/masterslide/) में जोड़ें। बाकी लॉजिक वही है जैसा एकल स्लाइड में वॉटरमार्क जोड़ते समय होता है — एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) ऑब्जेक्ट बनाएं और फिर [addTextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) मेथड का उपयोग करके वॉटरमार्क जोड़ें।

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [स्लाइड मास्टर का उपयोग कैसे करें](/slides/hi/java/slide-master/)
{{% /alert %}}

### **वॉटरमार्क शेप की ट्रांसपैरेंसी सेट करें**

डिफ़ॉल्ट रूप से, आयताकार शेप को फ़िल और लाइन रंगों से स्टाइल किया जाता है। नीचे दिया गया कोड शेप को ट्रांसपैरेंट बनाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **टेक्स्ट वॉटरमार्क के लिए फ़ॉन्ट सेट करें**

नीचे दिखाए अनुसार आप टेक्स्ट वॉटरमार्क का फ़ॉन्ट बदल सकते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **वॉटरमार्क टेक्स्ट का रंग सेट करें**

वॉटरमार्क टेक्स्ट का रंग सेट करने के लिए इस कोड का उपयोग करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **टेक्स्ट वॉटरमार्क को केंद्र में रखें**

वॉटरमार्क को स्लाइड के केंद्र में लाया जा सकता है, इसके लिए आप नीचे दिया गया कोड उपयोग कर सकते हैं:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

नीचे की छवि अंतिम परिणाम दिखाती है।

![The text watermark](text_watermark.png)

## **इमेज वॉटरमार्क**

### **प्रेजेंटेशन में इमेज वॉटरमार्क जोड़ें**

प्रेजेंटेशन स्लाइड में इमेज वॉटरमार्क जोड़ने के लिए आप नीचे दिया गया कोड उपयोग कर सकते हैं:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **वॉटरमार्क को संपादन से लॉक करें**

यदि वॉटरमार्क को संपादन से रोकना आवश्यक हो, तो शेप पर [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) मेथड का उपयोग करें। इस प्रॉपर्टी के माध्यम से आप शेप को चयन, आकार बदलना, पुनःस्थिति, अन्य तत्वों के साथ समूह बनाना, उसके टेक्स्ट को संपादन से लॉक करना आदि से बचा सकते हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// वॉटरमार्क शेप को संशोधित करने से लॉक करें
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **वॉटरमार्क को आगे ले जाएँ**

Aspose.Slides में शेप्स का Z‑order [IShapeCollection.reorder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) मेथड द्वारा सेट किया जा सकता है। इसे करने के लिए आपको प्रेजेंटेशन स्लाइड्स की सूची से इस मेथड को कॉल करना होगा और शेप रेफ़रेंस तथा उसका क्रमांक पास करना होगा। इस तरह आप शेप को स्लाइड के सामने ला सकते हैं या पीछे भेज सकते हैं। यह विशेषता विशेष रूप से तब उपयोगी होती है जब आपको वॉटरमार्क को प्रेजेंटेशन की सामने रखनी हो:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **वॉटरमार्क का घुमाव सेट करें**

नीचे दिया गया कोड उदाहरण दिखाता है कि वॉटरमार्क का घुमाव कैसे समायोजित कर उसे स्लाइड में तिरछी स्थिति में रखा जाए:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **वॉटरमार्क का नाम सेट करें**

Aspose.Slides आपको शेप का नाम सेट करने की अनुमति देता है। शेप नाम का उपयोग करके आप भविष्य में इसे संशोधित या हटाने के लिए एक्सेस कर सकते हैं। वॉटरमार्क शेप का नाम सेट करने के लिए इसे [IAutoShape.setName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setName-java.lang.String-) मेथड में असाइन करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **वॉटरमार्क हटाएँ**

वॉटरमार्क शेप को हटाने के लिए पहले [IAutoShape.getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getName--) मेथड से इसे स्लाइड शेप्स में खोजें। फिर शेप को [IShapeCollection.remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) मेथड में पास करके हटाएँ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **FAQ**

### वॉटरमार्क क्या है और मुझे इसे क्यों उपयोग करना चाहिए?

वॉटरमार्क वह टेक्स्ट या इमेज ओवरले है जो स्लाइड्स पर लागू किया जाता है और यह बौद्धिक संपदा की रक्षा, ब्रांड पहचान बढ़ाने, या अनधिकृत उपयोग को रोकने में मदद करता है।

### क्या मैं प्रेजेंटेशन की सभी स्लाइड्स में वॉटरमार्क जोड़ सकता हूँ?

हाँ, Aspose.Slides आपको प्रोग्रामmatically प्रत्येक स्लाइड में वॉटरमार्क जोड़ने की सुविधा देता है। आप सभी स्लाइड्स पर लूप करके वॉटरमार्क सेटिंग्स लागू कर सकते हैं।

### मैं वॉटरमार्क की ट्रांसपैरेंसी कैसे समायोजित करूँ?

आप शेप के फ़िल सेटिंग्स ([getFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getFillFormat--)) को बदलकर वॉटरमार्क की ट्रांसपैरेंसी को नियंत्रित कर सकते हैं। इससे वॉटरमार्क सूक्ष्म रहता है और स्लाइड सामग्री से ध्यान नहीं हटाता।

### वॉटरमार्क के लिए कौन से इमेज फ़ॉर्मेट सपोर्टेड हैं?

Aspose.Slides PNG, JPEG, GIF, BMP, SVG आदि सहित विभिन्न इमेज फ़ॉर्मेट का समर्थन करता है।

### क्या मैं टेक्स्ट वॉटरमार्क के फ़ॉन्ट और स्टाइल को कस्टमाइज़ कर सकता हूँ?

हाँ, आप किसी भी फ़ॉन्ट, आकार और स्टाइल का चयन कर सकते हैं जो आपके प्रेजेंटेशन डिजाइन और ब्रांड संगतता से मेल खाता हो।

### मैं वॉटरमार्क की स्थिति या अभिविन्यास कैसे बदलूँ?

आप प्रोग्रामmatically शेप के कोऑर्डिनेट्स, आकार और घुमाव प्रॉपर्टीज़ को बदलकर वॉटरमार्क की स्थिति और अभिविन्यास समायोजित कर सकते हैं।