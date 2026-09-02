---
title: Android पर PowerPoint आकारों को स्वरूपित करें
linktitle: आकार स्वरूपण
type: docs
weight: 20
url: /hi/androidjava/shape-formatting/
keywords:
- आकार स्वरूपित करें
- रेखा स्वरूपित करें
- स्केच प्रभाव
- आकार रेखा पर स्केच
- जॉइन शैली स्वरूपित करें
- ग्रेडिएंट फ़िल
- पैटर्न फ़िल
- चित्र फ़िल
- टेक्सचर फ़िल
- सॉलिड रंग फ़िल
- आकार पारदर्शिता
- काला-सफेद आकार रेंडरिंग
- ग्रेस्केल आकार रेंडरिंग
- आकार घुमाएँ
- 3D बिवेल प्रभाव
- 3D घूर्णन प्रभाव
- स्वरूपण रीसेट करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Android पर PowerPoint आकारों को स्वरूपित करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिए भरावट, रेखा और प्रभाव शैलियों को सटीकता और पूरी नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड में आकार (शेप) जोड़ सकते हैं। चूँकि आकार रेखाओं से बनते हैं, आप उनके रूपरेखा को संशोधित करके या प्रभाव लागू करके उन्हें स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप आकार के आंतरिक भाग को भरने के सेटिंग्स निर्धारित करके भी स्वरूपित कर सकते हैं।

![format-shape-powerpoint](format-shape-powerpoint.png)

Java के माध्यम से Android के लिए Aspose.Slides वही इंटरफ़ेस और मेथड प्रदान करता है जिससे आप PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकारों को स्वरूपित कर सकते हैं।

## **रेखाओं का स्वरूपण**

Aspose.Slides का उपयोग करके आप आकार के लिए एक कस्टम लाइन शैली निर्दिष्ट कर सकते हैं। नीचे प्रक्रिया को दर्शाते चरण दिए गए हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [line style](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. लाइन के [dash style](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए लाइन का रंग सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित कोड दिखाता है कि कैसे एक आयत `AutoShape` को स्वरूपित किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

// एक Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Rectangle आकार से भराव हटाएँ ताकि केवल उसकी रेखाएँ दिखाई दें।
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Rectangle की रेखाओं पर स्वरूपण लागू करें।
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Rectangle की रेखा के लिए रंग सेट करें।
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![presentation में स्वरूपित रेखाएँ](formatted-lines.png)

## **आकार रेखाओं पर स्केच इफ़ेक्ट लागू करें**

स्केच इफ़ेक्ट एक आकार की रेखा को हाथ से बनायी हुई जैसा दिखाता है। लाइन सेटिंग्स तक पहुँचने के लिए [IShape.getLineFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) का उपयोग करें, स्केच सेटिंग्स तक पहुँचने के लिए [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilineformat/) का उपयोग करें, और [ISketchFormat.setSketchType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isketchformat/) का उपयोग करके [LineSketchType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linesketchtype/) एनीमरेशन से एक मान चुनें।

निम्नलिखित जावा कोड दिखाता है कि कैसे [LineSketchType.Curved](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linesketchtype/) इफ़ेक्ट लागू किया जाए, स्पष्ट रूप से निर्धारित मान पढ़ा जाए, और [LineSketchType.None](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linesketchtype/) से इफ़ेक्ट हटाया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // आकार के लाइन फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुँचें।
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // एक स्केच प्रभाव लागू करें।
    sketchFormat.setSketchType(LineSketchType.Curved);

    // आकार को सीधे असाइन किए गए स्केच प्रभाव को पढ़ें।
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // स्केच प्रभाव हटाएँ।
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isketchformat/) द्वारा लौटाया गया मान वह सेटिंग दर्शाता है जो सीधे आकार को असाइन की गई है। यदि लाइन स्वरूपण थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में प्राप्त हो सकता है, तो [ILineFormat.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilineformat/) का उपयोग करें, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilineformateffectivedata/) तक पहुँचें, और [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isketchformateffectivedata/) पढ़ें। प्रभावी मान उस स्वरूपण को दर्शाता है जो विरासत समाधान के बाद वास्तव में लागू होता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **जॉइन स्टाइल का स्वरूपण**

तीन जॉइन प्रकार विकल्प इस प्रकार हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को एक कोण पर जोड़ता है (जैसे आकार के कोना पर), तो यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोणों वाले आकार बना रहे हैं, तो आप **Miter** विकल्प को प्राथमिकता दे सकते हैं।

![presentation में जॉइन स्टाइल](join-style-powerpoint.png)

निम्नलिखित जावा कोड दिखाता है कि ऊपर की छवि में दिखाए गए तीन आयतों को Miter, Bevel और Round जॉइन प्रकार सेटिंग्स का उपयोग करके कैसे बनाया गया:

```java
import com.aspose.slides.*;
import java.awt.Color;

// एक Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार के तीन ऑटो शेप जोड़ें।
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयत आकार के लिए भराव रंग सेट करें।
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // रेखा की चौड़ाई सेट करें।
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // प्रत्येक आयत की रेखा का रंग सेट करें।
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // जॉइन शैली सेट करें।
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // प्रत्येक आयत में टेक्स्ट जोड़ें।
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ग्रेडिएंट फ़िल**

PowerPoint में, ग्रेडिएंट फ़िल एक स्वरूपण विकल्प है जो आपको आकार पर लगातार रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंगों को इस तरह लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में मिल जाए।

Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट फ़िल लागू करने के चरण इस प्रकार हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Gradient` सेट करें।
1. [IGradientFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igradientformat/) इंटरफ़ेस द्वारा उजागर ग्रेडिएंट स्टॉप संग्रह के `add` मेथड का उपयोग करके परिभाषित स्थितियों के साथ अपनी दो इच्छित रंग जोड़ें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे एक दीर्घवृत्त पर ग्रेडिएंट फ़िल इफ़ेक्ट लागू किया जाए:

```java
import com.aspose.slides.*;

// Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Ellipse पर ग्रेडिएंट स्वरूपण लागू करें।
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // ग्रेडिएंट की दिशा सेट करें।
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // दो ग्रेडिएंट स्टॉप जोड़ें।
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![दीर्घवृत्त पर ग्रेडिएंट फ़िल](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में, पैटर्न फ़िल एक स्वरूपण विकल्प है जो आपको दो‑रंगीय डिज़ाइन—जैसे बिंदु, धारियाँ, क्रॉसहैच, या चेकर—आकार पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वपरिभाषित पैटर्न शैलियों प्रदान करता है जिन्हें आप अपनी प्रस्तुतियों के दृश्यात्मक आकर्षण को बढ़ाने के लिए आकारों पर लागू कर सकते हैं। पूर्वपरिभाषित पैटर्न चुनने के बाद भी आप निश्चित रंग निर्दिष्ट कर सकते हैं।

Aspose.Slides का उपयोग करके आकार पर पैटर्न फ़िल लागू करने के चरण इस प्रकार हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Pattern` सेट करें।
1. पूर्वपरिभाषित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न की [Background Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/patternformat/#getBackColor--) सेट करें।
1. पैटर्न की [Foreground Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/patternformat/#getForeColor--) सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे एक आयत पर पैटर्न फ़िल लागू किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // भरण प्रकार को Pattern सेट करें।
    shape.getFillFormat().setFillType(FillType.Pattern);

    // पैटर्न शैली सेट करें।
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // पैटर्न की पृष्ठभूमि और अग्रभूमि रंग सेट करें।
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![आयत पर पैटर्न फ़िल](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में, पिक्चर फ़िल एक स्वरूपण विकल्प है जो आपको आकार के भीतर एक चित्र सम्मिलित करने देता है—प्रभावतः चित्र को आकार की पृष्ठभूमि के रूप में उपयोग करता है।

Aspose.Slides का उपयोग करके आकार पर पिक्चर फ़िल लागू करने के चरण इस प्रकार हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Picture` सेट करें।
1. पिक्चर फ़िल मोड को `Tile` (या कोई अन्य वांछित मोड) सेट करें।
1. जिस चित्र का उपयोग करना है, उससे एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) ऑब्जेक्ट बनाएं।
1. छवि को `ISlidesPicture.setImage` मेथड में पास करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास "lotus.png" फ़ाइल है जिसका चित्र नीचे दिखाया गया है:

![lotus चित्र](lotus.png)

निम्नलिखित जावा कोड दिखाता है कि कैसे आकार को चित्र से भरा जाए:

```java
import com.aspose.slides.*;

// Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // भरण प्रकार को Picture सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // चित्र भराव मोड सेट करें।
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // एक छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // चित्र सेट करें।
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![चित्र फ़िल वाले आकार](picture-fill.png)

### **टाइल चित्र को टेक्सचर के रूप में व्यवस्थित करना**

यदि आप टाइल किए गए चित्र को टेक्सचर के रूप में सेट करना और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप निम्नलिखित [IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/picturefillformat/) क्लास के मेथड का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): चित्र फ़िल मोड सेट करता है—`Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): आकार के भीतर टाइलों का संरेखण निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): निर्धारित करता है कि टाइल को क्षैतिज, ऊर्ध्वाधर या दोनों दिशा में फ़्लिप किया जाए।
- [setTileOffsetX](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): आकार की उत्पत्ति से टाइल का क्षैतिज ऑफ़सेट (पॉइंट में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): आकार की उत्पत्ति से टाइल का ऊर्ध्वाधर ऑफ़सेट (पॉइंट में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): टाइल का क्षैतिज स्केल प्रतिशत में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): टाइल का ऊर्ध्वाधर स्केल प्रतिशत में परिभाषित करता है।

निम्नलिखित कोड नमूना दिखाता है कि टाइल चित्र फ़िल के साथ एक आयत आकार कैसे जोड़ा जाए और टाइल विकल्प कैसे कॉन्फ़िगर किए जाएँ:

```java
import com.aspose.slides.*;

// Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // आयत ऑटो शेप जोड़ें।
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // आकार के भराव प्रकार को Picture सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // चित्र को आकार को असाइन करें।
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // चित्र भराव मोड और टाइलिंग गुण कॉन्फ़िगर करें।
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टाइल विकल्प](tile-options.png)

## **सॉलिड कलर फ़िल**

PowerPoint में, सॉलिड कलर फ़िल एक स्वरूपण विकल्प है जो आकार को एक समान रंग से भरता है। यह सादा पृष्ठभूमि रंग ग्रेडिएंट, टेक्सचर या पैटर्न के बिना लागू किया जाता है।

Aspose.Slides का उपयोग करके आकार पर सॉलिड कलर फ़िल लागू करने के चरण इस प्रकार हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Solid` सेट करें।
1. आवश्यक फ़िल रंग आकार को सौंपें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे एक आयत पर सॉलिड कलर फ़िल लागू किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // भराव प्रकार को Solid सेट करें।
    shape.getFillFormat().setFillType(FillType.Solid);

    // भराव रंग सेट करें।
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![सॉलिड कलर फ़िल वाला आकार](solid-color-fill.png)

## **पारदर्शिता सेट करना**

PowerPoint में, जब आप आकार पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिए पारदर्शिता स्तर भी सेट कर सकते हैं। अधिक पारदर्शिता मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या अंतर्निहित वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल के लिए उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने की अनुमति देता है। इस प्रकार करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Solid` सेट करें।
1. पारदर्शिता वाले रंग को परिभाषित करने के लिए `Color` का उपयोग करें (अल्फा घटक पारदर्शिता नियंत्रित करता है)।
1. प्रस्तुति को सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे एक आयत पर पारदर्शी फ़िल रंग लागू किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // एक ठोस आयत ऑटो शेप जोड़ें।
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ठोस आकार के ऊपर एक पारदर्शी आयत ऑटो शेप जोड़ें।
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी आकार](shape-transparency.png)

## **आकार घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकार घुमाने की अनुमति देता है। यह दृश्य तत्वों को विशिष्ट संरेखण या डिज़ाइन आवश्यकताओं के साथ स्थित करने में सहायक हो सकता है।

एक स्लाइड पर आकार घुमाने के लिए निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की घूर्णन प्रॉपर्टी को इच्छित कोण पर सेट करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे आकार को 5 डिग्री घुमाया जाए:

```java
import com.aspose.slides.*;

// Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // आकार को 5 डिग्री घुमाएँ।
    shape.setRotation(5);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![आकार घुमाव](shape-rotation.png)

## **3D बिवेल इफ़ेक्ट जोड़ें**

Aspose.Slides आपको आकारों पर 3D बिवेल इफ़ेक्ट लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/) गुण को कॉन्फ़िगर करते हैं।

आकार पर 3D बिवेल इफ़ेक्ट जोड़ने के लिए निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार के [ThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/) को कॉन्फ़िगर करके बिवेल सेटिंग्स परिभाषित करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे आकार पर 3D बिवेल इफ़ेक्ट लागू किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // स्लाइड में एक आकार जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // आकार की ThreeDFormat प्रॉपर्टीज सेट करें।
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D बिवेल इफ़ेक्ट](3D-bevel-effect.png)

## **3D घूर्णन इफ़ेक्ट जोड़ें**

Aspose.Slides आपको आकारों पर 3D घूर्णन इफ़ेक्ट लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/) गुण को कॉन्फ़िगर करते हैं।

आकार पर 3D घूर्णन लागू करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. [setCameraType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icamera/#setCameraType-int-) और [setLightType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) का उपयोग करके 3D घूर्णन परिभाषित करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे आकार पर 3D घूर्णन इफ़ेक्ट लागू किया जाए:

```java
import com.aspose.slides.*;

// Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D घूर्णन इफ़ेक्ट](3D-rotation-effect.png)

## **आकारों के लिए काले‑सफेद रेंडरिंग नियंत्रित करें**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) मेथड निर्धारित करता है कि जब प्रस्तुति को काले‑सफेद मोड में देखा या संसाधित किया जाता है तो व्यक्तिगत आकार कैसे रेंडर किया जाता है। यह स्वयं काले‑सफेद प्रदर्शन को सक्षम नहीं करता, और यह सामान्य रंग मोड में आकार के फ़िल, लाइन या अन्य स्वरूपण को नहीं बदलता।

[BlackWhiteMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/blackwhitemode/) क्लास से मान चुनें ताकि वांछित व्यवहार निर्दिष्ट हो सके। उदाहरण के लिए, `Automatic` रेंडरिंग अनुप्रयोग को रूपांतरण चुनने देता है, `Gray` और `LightGray` ग्रे रंग का उपयोग करते हैं, `BlackWhite` केवल काला और सफेद उपयोग करता है, `Black` और `White` एकल रंग लागू करते हैं, `Color` सामान्य रंग को बरकरार रखता है, और `Hidden` काले‑सफेद मोड में आकार को छोड़ देता है। `NotDefined` का अर्थ है कि कोई आकार‑स्तर मोड असाइन नहीं किया गया है।

निम्नलिखित जावा कोड एक रंगीन आकार बनाता है और उसे काले‑सफेद प्रदर्शन मोड में ग्रे दिखाता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // रंग मोड में नारंगी भराव रखें, लेकिन काले-सफेद मोड में आकार को ग्रे रंग में रेंडर करें।
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सामान्य रंग मोड में, आयत अपनी नारंगी फ़िल बनाए रखता है। काले‑सफेद प्रदर्शन कार्यप्रवाह में, उसका मोड `Gray` होने के कारण ग्रे रंग दिखाया जाता है। यह आपको पूर्ण‑रंग स्लाइड को संरक्षित रखने और प्रिंटिंग, पूर्वावलोकन या अन्य कार्यप्रवाहों के लिए अलग दिखावट परिभाषित करने की अनुमति देता है जो प्रस्तुति के काले‑सफेद प्रदर्शन सेटिंग्स को सम्मानित करते हैं।

## **स्वरूपण रीसेट करें**

निम्नलिखित जावा कोड दिखाता है कि कैसे स्लाइड के स्वरूपण को रीसेट किया जाए और [LayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/layoutslide/) पर प्लेसहोल्डर वाले सभी आकारों की स्थिति, आकार और स्वरूपण को उनकी डिफ़ॉल्ट सेटिंग्स पर पुनर्स्थापित किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // लेआउट पर प्लेसहोल्डर वाले स्लाइड पर प्रत्येक आकार को रीसेट करें।
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकार का स्वरूपण अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करता है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियों और मीडिया का अधिकांश फ़ाइल स्थान लेता है, जबकि रंग, इफ़ेक्ट और ग्रेडिएंट जैसे आकार पैरामीटर मेटाडेटा के रूप में संग्रहीत होते हैं और व्यावहारिक रूप से कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे उन आकारों का पता लगा सकता हूँ जो समान स्वरूपण साझा करते हैं ताकि उन्हें समूहित किया जा सके?**

प्रत्येक आकार की मुख्य स्वरूपण प्रॉपर्टियों—फ़िल, लाइन और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके शैलियों को समान मानें और उन आकारों को तार्किक रूप से समूहित करें, जिससे बाद में शैली प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकार शैलियों का एक सेट अलग फ़ाइल में सहेज कर अन्य प्रस्तुतियों में पुनः उपयोग कर सकता हूँ?**

हां। इच्छित शैलियों वाले नमूना आकारों को एक टेम्प्लेट स्लाइड डेक या .POTX टेम्प्लेट फ़ाइल में सहेजें। नई प्रस्तुति बनाते समय टेम्प्लेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो उनके स्वरूपण को पुनः लागू करें।