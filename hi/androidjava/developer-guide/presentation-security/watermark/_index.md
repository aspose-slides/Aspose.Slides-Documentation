---
title: Android पर प्रस्तुतियों में वॉटरमार्क जोड़ना
linktitle: वॉटरमार्क
type: docs
weight: 40
url: /hi/androidjava/watermark/
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
- Android
- Java
- Aspose.Slides
description: "Android पर Java में PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट और इमेज वॉटरमार्क का प्रबंधन करें ताकि ड्राफ्ट, गोपनीय जानकारी आदि दर्शाया जा सके।"
---
## **परिचय**

**एक वॉटरमार्क** प्रस्तुति में टेक्स्ट या इमेज स्टैम्प होता है जो स्लाइड पर या सभी स्लाइड्स में उपयोग किया जाता है। आमतौर पर वॉटरमार्क यह दर्शाने के लिए उपयोग किया जाता है कि प्रस्तुति एक ड्राफ्ट है (उदाहरण — "Draft" वॉटरमार्क), इसमें गोपनीय जानकारी है (उदाहरण — "Confidential" वॉटरमार्क), यह किस कंपनी से संबंधित है (उदाहरण — "Company Name" वॉटरमार्क), प्रस्तुति लेखक को पहचानने के लिए, आदि। वॉटरमार्क यह संकेत देकर कॉपीराइट उल्लंघन को रोकने में मदद करता है कि प्रस्तुति को कॉपी नहीं किया जाना चाहिए। वॉटरमार्क PowerPoint और OpenOffice दोनों प्रस्तुति फॉर्मेट में प्रयोग किए जाते हैं। Aspose.Slides में आप PowerPoint PPT, PPTX, और OpenOffice ODP फ़ाइल फ़ॉर्मेट में वॉटरमार्क जोड़ सकते हैं।

[**Aspose.Slides**](https://products.aspose.com/slides/hi/android-java/) में विभिन्न तरीकों से आप PowerPoint या OpenOffice दस्तावेज़ों में वॉटरमार्क बना सकते हैं और उनके डिज़ाइन व व्यवहार को संशोधित कर सकते हैं। सामान्य बात यह है कि टेक्स्ट वॉटरमार्क जोड़ने के लिए आपको [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) इंटरफ़ेस का उपयोग करना चाहिए, और इमेज वॉटरमार्क जोड़ने के लिए [PictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pictureframe/) क्लास या वॉटरमार्क आकार को इमेज से भरना चाहिए। `PictureFrame` [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस को लागू करता है, जिससे आप आकार ऑब्जेक्ट की सभी लचीली सेटिंग्स उपयोग कर सकते हैं। चूँकि `ITextFrame` एक आकार नहीं है और इसकी सेटिंग्स सीमित हैं, इसे एक [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) ऑब्जेक्ट में रैप किया जाता है।

वॉटरमार्क दो तरीकों से लागू किया जा सकता है: एकल स्लाइड पर या सभी प्रस्तुति स्लाइड्स पर। सभी स्लाइड्स पर वॉटरमार्क लागू करने के लिए स्लाइड मास्टर का उपयोग किया जाता है — वॉटरमार्क को स्लाइड मास्टर में जोड़ा जाता है, वहाँ पूरी तरह से डिज़ाइन किया जाता है, और सभी स्लाइड्स पर लागू किया जाता है, जबकि व्यक्तिगत स्लाइड्स पर वॉटरमार्क को संशोधित करने की अनुमति नहीं बदलती।

वॉटरमार्क आमतौर पर अन्य उपयोगकर्ताओं द्वारा संपादन के लिये उपलब्ध नहीं माना जाता। वॉटरमार्क (या वॉटरमार्क के पैरेंट आकार) को संपादन से रोकने के लिये Aspose.Slides आकार लॉकिंग फ़ंक्शन प्रदान करता है। एक विशिष्ट आकार को सामान्य स्लाइड या स्लाइड मास्टर पर लॉक किया जा सकता है। जब स्लाइड मास्टर पर वॉटरमार्क आकार लॉक किया जाता है, तो वह सभी प्रस्तुति स्लाइड्स पर लॉक हो जाता है।

आप वॉटरमार्क को एक नाम दे सकते हैं ताकि भविष्य में इसे हटाने की आवश्यकता पड़े तो आप स्लाइड के आकारों में नाम द्वारा उसे खोज सकें।

आप वॉटरमार्क को किसी भी तरीके से डिज़ाइन कर सकते हैं; हालांकि सामान्यतः वॉटरमार्क में कुछ विशेषताएँ होती हैं, जैसे केंद्र संरेखण, घुमाव, सामने की स्थिति आदि। हम नीचे दिए गए उदाहरणों में इन्हें कैसे उपयोग करें, इसे देखेंगे।

## **टेक्स्ट वॉटरमार्क**

### **स्लाइड में टेक्स्ट वॉटरमार्क जोड़ना**

PPT, PPTX, या ODP में टेक्स्ट वॉटरमार्क जोड़ने के लिये आप पहले स्लाइड में एक आकार जोड़ें, फिर उस आकार में एक टेक्स्ट फ़्रेम जोड़ें। टेक्स्ट फ़्रेम को [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) इंटरफ़ेस द्वारा दर्शाया जाता है। यह प्रकार [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) से विरासत में नहीं मिला है, जिसके पास वॉटरमार्क को लचीले ढंग से स्थित करने के लिये कई प्रॉपर्टीज़ होती हैं। इसलिए, [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) ऑब्जेक्ट को एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) ऑब्जेक्ट में रैप किया जाता है। आकार में वॉटरमार्क टेक्स्ट जोड़ने के लिये नीचे दिखाए अनुसार [addTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) मेथड का प्रयोग करें।

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="और देखें" %}} 
- [TextFrame क्लास का उपयोग कैसे करें](/slides/hi/androidjava/text-formatting/)
{{% /alert %}}

### **पूरी प्रस्तुति में टेक्स्ट वॉटरमार्क जोड़ना**

यदि आप पूरे प्रस्तुति (अर्थात् सभी स्लाइड्स) में टेक्स्ट वॉटरमार्क जोड़ना चाहते हैं, तो इसे [MasterSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/masterslide/) में जोड़ें। बाकी लॉजिक वही है जैसा कि एकल स्लाइड में वॉटरमार्क जोड़ते समय होता है — एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) ऑब्जेक्ट बनाएं और फिर [addTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) मेथड से वॉटरमार्क जोड़ें।

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="और देखें" %}} 
- [Slide Master का उपयोग कैसे करें](/slides/hi/androidjava/slide-master/)
{{% /alert %}}

### **वॉटरमार्क आकार की पारदर्शिता सेट करना**

डिफ़ॉल्ट रूप से, आयताकार आकार को फ़िल और लाइन रंगों से स्टाइल किया जाता है। नीचे दिया कोड आकार को पारदर्शी बनाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **टेक्स्ट वॉटरमार्क के लिए फ़ॉन्ट सेट करना**

आप नीचे दिखाए अनुसार टेक्स्ट वॉटरमार्क का फ़ॉन्ट बदल सकते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **वॉटरमार्क टेक्स्ट का रंग सेट करना**

वॉटरमार्क टेक्स्ट का रंग सेट करने के लिये यह कोड उपयोग करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **टेक्स्ट वॉटरमार्क को केंद्रित करना**

वॉटरमार्क को स्लाइड पर केंद्रित करना संभव है, इसके लिये आप नीचे दर्शाए अनुसार कर सकते हैं:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

नीचे की छवि अंतिम परिणाम दिखाती है।

![टेक्स्ट वॉटरमार्क](text_watermark.png)

## **इमेज वॉटरमार्क**

### **प्रस्तुति में इमेज वॉटरमार्क जोड़ना**

प्रस्तुति स्लाइड में इमेज वॉटरमार्क जोड़ने के लिये आप नीचे दर्शाए अनुसार कर सकते हैं:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **वॉटरमार्क को संपादन से लॉक करना**

यदि वॉटरमार्क को संपादन से रोकना आवश्यक है, तो आकार पर [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) मेथड का उपयोग करें। इस प्रॉपर्टी के साथ आप आकार को चयन, आकार बदलने, पुनः स्थान देने, अन्य तत्वों के साथ समूह बनाने, उसके टेक्स्ट को संपादन से रोकने इत्यादि से सुरक्षित कर सकते हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // वॉटरमार्क आकार को संशोधन से लॉक करें
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **वॉटरमार्क को आगे लाना**

Aspose.Slides में आकारों का Z‑order [IShapeCollection.reorder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) मेथड द्वारा सेट किया जा सकता है। ऐसा करने के लिये आपको प्रस्तुतिकरण स्लाइड सूची से इस मेथड को कॉल करना होगा और आकार के रेफ़रेंस तथा उसका क्रमांक मेथड में पास करना होगा। इस तरह आप आकार को स्लाइड के सामने या पीछे ले जा सकते हैं। यह सुविधा विशेष रूप से तब उपयोगी होती है जब आपको वॉटरमार्क को प्रस्तुति के सामने रखना हो:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **वॉटरमार्क का घुमाव सेट करना**

नीचे कोड उदाहरण दिखाता है कि स्लाइड पर वॉटरमार्क को तिरछा रखने के लिये घुमाव कैसे समायोजित करें:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **वॉटरमार्क को नाम देना**

Aspose.Slides आपको आकार का नाम सेट करने की अनुमति देता है। आकार का नाम उपयोग करके आप भविष्य में उसे संशोधित या हटाने के लिये एक्सेस कर सकते हैं। वॉटरमार्क आकार का नाम सेट करने के लिये इसे [IAutoShape.setName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) मेथड को पास करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **वॉटरमार्क हटाना**

वॉटरमार्क आकार को हटाने के लिये, स्लाइड के आकारों में उसे खोजने हेतु [IAutoShape.getName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getName--) मेथड का प्रयोग करें। फिर वॉटरमार्क आकार को [IShapeCollection.remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) मेथड में पास करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### वॉटरमार्क क्या है और मुझे इसे क्यों उपयोग करना चाहिए?

वॉटरमार्क एक टेक्स्ट या इमेज ओवरले है जो स्लाइड्स पर लागू किया जाता है और बौद्धिक संपदा की सुरक्षा, ब्रांड पहचान को बढ़ावा देने, या अनधिकृत उपयोग रोकने में मदद करता है।

### क्या मैं प्रस्तुति की सभी स्लाइड्स में वॉटरमार्क जोड़ सकता हूँ?

हाँ, Aspose.Slides आपको प्रोग्रामेटिक रूप से प्रत्येक स्लाइड में वॉटरमार्क जोड़ने की सुविधा देता है। आप सभी स्लाइड्स के माध्यम से इटरेट करके वॉटरमार्क सेटिंग्स व्यक्तिगत रूप से लागू कर सकते हैं।

### मैं वॉटरमार्क की पारदर्शिता कैसे समायोजित कर सकता हूँ?

आप आकार की फ़िल सेटिंग्स ([getFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getFillFormat--)) को संशोधित करके वॉटरमार्क की पारदर्शिता बदल सकते हैं। इससे वॉटरमार्क सूक्ष्म रहता है और स्लाइड सामग्री से ध्यान नहीं हटाता।

### वॉटरमार्क के लिये कौन‑से इमेज फ़ॉर्मेट समर्थित हैं?

Aspose.Slides PNG, JPEG, GIF, BMP, SVG आदि विभिन्न इमेज फ़ॉर्मेट को समर्थन देता है।

### क्या मैं टेक्स्ट वॉटरमार्क का फ़ॉन्ट और शैली अनुकूलित कर सकता हूँ?

हाँ, आप कोई भी फ़ॉन्ट, आकार और शैली चुन सकते हैं जो आपकी प्रस्तुति के डिज़ाइन और ब्रांड सुसंगतता के साथ मेल खाती हो।

### मैं वॉटरमार्क की स्थिति या अभिविन्यास कैसे बदल सकता हूँ?

आप प्रोग्रामेटिक रूप से आकार के निर्देशांक, आकार और घुमाव प्रॉपर्टीज़ को बदलकर वॉटरमार्क की स्थिति और अभिविन्यास समायोजित कर सकते हैं।