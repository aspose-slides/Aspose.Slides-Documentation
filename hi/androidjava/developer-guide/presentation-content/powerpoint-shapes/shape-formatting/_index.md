---
title: एंड्रॉइड पर PowerPoint आकृतियों का स्वरूपण
linktitle: आकृति स्वरूपण
type: docs
weight: 20
url: /hi/androidjava/shape-formatting/
keywords:
- आकृति स्वरूपण
- रेखा स्वरूपण
- स्केच प्रभाव
- स्केच आकृति रेखा
- जॉइन शैली स्वरूपण
- ग्रेडिएंट फ़िल
- पैटर्न फ़िल
- चित्र फ़िल
- टेक्सचर फ़िल
- सॉलिड रंग फ़िल
- आकृति पारदर्शिता
- आकृति घुमाएँ
- 3D बीवल प्रभाव
- 3D घुमाव प्रभाव
- स्वरूपण रीसेट
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Android पर PowerPoint आकृतियों को स्वरूपित करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिए फ़िल, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड में आकृतियाँ जोड़ सकते हैं। चूँकि आकृतियाँ रेखाओं से बनी होती हैं, आप उनके रूपरेखा को संशोधित या प्रभाव लागू करके स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप आकृतियों को उनके आंतरिक भाग को भरने के सेटिंग्स निर्दिष्ट करके स्वरूपित कर सकते हैं।

![पावरपॉइंट में आकृति स्वरूपण](format-shape-powerpoint.png)

Aspose.Slides for Android via Java ऐसे इंटरफेस और मेथड्स प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकृतियों को स्वरूपित करने की अनुमति देते हैं।

## **रेखाओं का स्वरूपण**

Aspose.Slides का उपयोग करके, आप किसी आकृति के लिए कस्टम रेखा शैली निर्दिष्ट कर सकते हैं। नीचे दिए गए चरण प्रक्रिया को दर्शाते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. उसकी अनुक्रमांक द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [line style](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linestyle/) सेट करें।
1. रेखा की चौड़ाई सेट करें।
1. रेखा का [dash style](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linedashstyle/) सेट करें।
1. आकृति के लिए रेखा रंग सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित कोड दिखाता है कि एक आयत `AutoShape` को कैसे स्वरूपित किया जाए:

```java
// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार की ऑटो शैप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Rectangle आकृति के लिए फ़िल रंग सेट करें।
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Rectangle की रेखाओं पर स्वरूपण लागू करें।
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Rectangle की रेखा का रंग सेट करें।
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![प्रस्तुति में स्वरूपित रेखाएँ](formatted-lines.png)

## **आकृति रेखाओं पर स्केच प्रभाव लागू करें**

स्केच प्रभाव एक आकृति रेखा को हाथ से खींची हुई दिखाता है। रेखा सेटिंग्स तक पहुंचने के लिए [IShape.getLineFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) का उपयोग करें, स्केच सेटिंग्स तक पहुंचने के लिए [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilineformat/) का उपयोग करें, और [LineSketchType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linesketchtype/) एन्उमरेशन से मान चुनने के लिए [ISketchFormat.setSketchType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isketchformat/) का उपयोग करें।

निम्नलिखित जावा कोड दिखाता है कि कैसे [LineSketchType.Curved](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linesketchtype/) प्रभाव लागू किया जाए, स्पष्ट रूप से असाइन किए गए मान को पढ़ा जाए, और प्रभाव को [LineSketchType.None](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linesketchtype/) के साथ हटाया जाए:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // आकृति के रेखा स्वरूप और उसके स्केच स्वरूप तक पहुँचें।
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // एक स्केच प्रभाव लागू करें।
    sketchFormat.setSketchType(LineSketchType.Curved);

    // आकृति को सीधे असाइन किए गए स्केच प्रभाव को पढ़ें।
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // स्केच प्रभाव को हटाएँ।
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isketchformat/) द्वारा लौटाया गया मान सीधे आकृति को असाइन की गई सेटिंग का प्रतिनिधित्व करता है। यदि रेखा स्वरूपण थीम, मास्टर स्लाइड, या लेआउट स्लाइड से विरासत में मिला हो, तो [ILineFormat.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilineformat/) का उपयोग करें, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilineformateffectivedata/) तक पहुंचें, और [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isketchformateffectivedata/) पढ़ें। प्रभावी मान वह स्वरूपण दर्शाता है जो विरासत के समाधान के बाद वास्तव में लागू होता है:

```java
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

## **ज्वाइन शैली स्वरूपण**

यहाँ तीन ज्वाइन प्रकार विकल्प हैं:

* गोल
* मिटर
* बीवेल

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को किसी कोण पर (जैसे आकृति के कोने पर) जोड़ता है, तो यह **गोल** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाली आकृति बना रहे हैं, तो आप **मिटर** विकल्प को प्राथमिकता दे सकते हैं।

![प्रस्तुति में ज्वाइन शैली](join-style-powerpoint.png)

निम्नलिखित जावा कोड दर्शाता है कि ऊपर दिखाई गई छवि में दर्शाए गए तीन आयतों को Miter, Bevel, और Round ज्वाइन प्रकार सेटिंग्स का उपयोग करके कैसे बनाया गया:

```java
// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार की तीन ऑटो शैप जोड़ें।
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयत आकृति के लिए फ़िल रंग सेट करें।
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

    // ज्वाइन शैली सेट करें।
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

## **ग्रेडिएंट फिल**

PowerPoint में, ग्रेडिएंट फ़िल एक स्वरूपण विकल्प है जो आपको एक आकृति पर निरंतर रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंग इस तरह लागू कर सकते हैं कि एक धीरे-धीरे दूसरे में मिल जाता है।

यहाँ Aspose.Slides का उपयोग करके किसी आकृति पर ग्रेडिएंट फ़िल लागू करने का तरीका है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. उसकी अनुक्रमांक द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Gradient` पर सेट करें।
1. ग्रेडिएंट स्टॉप कलेक्शन द्वारा प्रदर्शित `add` मेथड्स का उपयोग करके परिभाषित स्थितियों के साथ अपने दो पसंदीदा रंग जोड़ें, जो [IGradientFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igradientformat/) इंटरफ़ेस द्वारा उजागर होते हैं।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```java
// एक प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse प्रकार की एक ऑटो शैप जोड़ें।
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

![ग्रेडिएंट फ़िल के साथ दीर्घवृत्त](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में, पैटर्न फ़िल एक स्वरूपण विकल्प है जो आपको दो-रंग डिज़ाइन—जैसे बिंदु, धारियों, क्रॉसहैच, या जाँच—को आकृति पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप आकृतियों पर लागू करके अपनी प्रस्तुतियों की दृश्य आकर्षण को बढ़ा सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी, आप अभी भी उन रंगों को निर्दिष्ट कर सकते हैं जो इसका उपयोग करेगी।

यहाँ Aspose.Slides का उपयोग करके किसी आकृति पर पैटर्न फ़िल लागू करने का तरीका है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. उसकी अनुक्रमांक द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Pattern` पर सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न का [Background Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/patternformat/#getBackColor--) सेट करें।
1. पैटर्न का [Foreground Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/patternformat/#getForeColor--) सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```java
// एक प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Pattern पर सेट करें।
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

![पैटर्न फ़िल के साथ आयत](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में, पिक्चर फ़िल एक स्वरूपण विकल्प है जो आपको किसी आकृति के भीतर एक छवि सम्मिलित करने देता है—जिससे छवि प्रभावी रूप से आकृति की पृष्ठभूमि बन जाती है।

यहाँ Aspose.Slides का उपयोग करके किसी आकृति पर पिक्चर फ़िल लागू करने का तरीका है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. उसकी अनुक्रमांक द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Picture` पर सेट करें।
1. पिक्चर फ़िल मोड को `Tile` (या कोई अन्य पसंदीदा मोड) पर सेट करें।
1. आपने उपयोग करने वाली छवि से एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) ऑब्जेक्ट बनाएं।
1. छवि को `ISlidesPicture.setImage` मेथड में पास करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास नीचे दिखाई गई "lotus.png" फ़ाइल है:

![लोटस चित्र](lotus.png)

```java
// एक प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // फ़िल प्रकार को Picture पर सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // चित्र फ़िल मोड सेट करें।
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // एक छवि लोड करें और उसे प्रेजेंटेशन संसाधनों में जोड़ें।
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

![पिक्चर फ़िल के साथ आकृति](picture-fill.png)

### **टाइल चित्र को टेक्सचर के रूप में**

यदि आप टाइल्ड चित्र को टेक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/picturefillformat/) क्लास की निम्नलिखित मेथड्स का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): चित्र फ़िल मोड सेट करता है—या तो `Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): आकृति के भीतर टाइलों के संरेखण को निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): टाइल को क्षैतिज, उर्ध्वाधर या दोनों दिशा में उलटा करने को नियंत्रित करता है।
- [setTileOffsetX](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): आकृति की मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): आकृति की मूल बिंदु से टाइल का ऊर्ध्वाधर ऑफ़सेट (पॉइंट में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): टाइल के क्षैतिज स्केल को प्रतिशत के रूप में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): टाइल के ऊर्ध्वाधर स्केल को प्रतिशत के रूप में परिभाषित करता है।

निम्नलिखित कोड नमूना दर्शाता है कि कैसे टाइल्ड पिक्चर फ़िल वाले आयत आकृति को जोड़ें और टाइल विकल्पों को कॉन्फ़िगर करें:

```java
// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // एक आयत ऑटो शैप जोड़ें।
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // आकृति के फ़िल प्रकार को Picture पर सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // छवि लोड करें और उसे प्रेजेंटेशन संसाधनों में जोड़ें।
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // छवि को आकृति में असाइन करें।
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // चित्र फ़िल मोड और टाइलिंग गुणों को कॉन्फ़िगर करें।
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

PowerPoint में, सॉलिड कलर फ़िल एक स्वरूपण विकल्प है जो आकृति को एकल, समान रंग से भरता है। यह साधारण पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू किया जाता है।

Aspose.Slides का उपयोग करके किसी आकृति पर सॉलिड कलर फ़िल लागू करने के लिए, निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. उसकी अनुक्रमांक द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Solid` पर सेट करें।
1. अपना पसंदीदा फ़िल रंग आकृति को असाइन करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```java
// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Solid पर सेट करें।
    shape.getFillFormat().setFillType(FillType.Solid);

    // फ़िल रंग सेट करें।
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![सॉलिड कलर फ़िल के साथ आकृति](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में, जब आप आकृतियों पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिए पारदर्शिता स्तर भी सेट कर सकते हैं। उच्च पारदर्शिता मान आकृति को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे की वस्तुएँ आंशिक रूप से दिखती हैं।

Aspose.Slides आपको फ़िल में उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने देता है। इसे करने का तरीका इस प्रकार है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. उसकी अनुक्रमांक द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Solid` पर सेट करें।
1. `Color` का उपयोग करके पारदर्शिता वाले रंग को परिभाषित करें ( `alpha` घटक पारदर्शिता को नियंत्रित करता है)。
1. प्रस्तुति को सहेजें।

```java
// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // एक ठोस आयत ऑटो शैप जोड़ें।
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ठोस आकृति पर एक पारदर्शी आयत ऑटो शैप जोड़ें।
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

![पारदर्शी आकृति](shape-transparency.png)

## **आकृतियों को घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकृतियों को घुमाने की अनुमति देता है। यह विशिष्ट संरेखण या डिज़ाइन आवश्यकताओं वाले दृश्य तत्वों की स्थिति निर्धारित करने में उपयोगी हो सकता है।

स्लाइड पर किसी आकृति को घुमाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. उसकी अनुक्रमांक द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकृति की rotation प्रॉपर्टी को इच्छित कोण पर सेट करें।
1. प्रस्तुति को सहेजें।

```java
// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // आकृति को 5 डिग्री घुमाएँ।
    shape.setRotation(5);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![आकृति का घुमाव](shape-rotation.png)

## **3D बीवल प्रभाव जोड़ें**

Aspose.Slides आपको आकृतियों पर 3D बीवल प्रभाव लागू करने की अनुमति देता है, उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करके।

आकृति पर 3D बीवल प्रभाव जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. उसकी अनुक्रमांक द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. बीवल सेटिंग्स को परिभाषित करने के लिए आकृति के [ThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/) को कॉन्फ़िगर करें।
1. प्रस्तुति को सहेजें।

```java
// Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // स्लाइड में एक आकृति जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // आकृति की ThreeDFormat गुण सेट करें।
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

![3D बीवल प्रभाव](3D-bevel-effect.png)

## **3D घुमाव प्रभाव जोड़ें**

Aspose.Slides आपको आकृतियों पर 3D घुमाव प्रभाव लागू करने की अनुमति देता है, उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करके।

आकृति पर 3D घुमाव लागू करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. उसकी अनुक्रमांक द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. 3D घुमाव को परिभाषित करने के लिए [setCameraType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icamera/#setCameraType-int-) और [setLightType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) का उपयोग करें।
1. प्रस्तुति को सहेजें।

```java
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

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D घुमाव प्रभाव](3D-rotation-effect.png)

## **स्वरूपण रीसेट करें**

निम्नलिखित जावा कोड दर्शाता है कि कैसे स्लाइड की स्वरूपण को रीसेट किया जाए और [LayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/layoutslide/) पर सभी प्लेसहोल्डर वाली आकृतियों की स्थिति, आकार, और स्वरूपण को उनके डिफ़ॉल्ट सेटिंग्स में वापस लाया जाए:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // लेआउट पर प्लेसहोल्डर वाली स्लाइड पर प्रत्येक आकृति को रीसेट करें।
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**क्या आकृति स्वरूपण अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करता है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियाँ और मीडिया फ़ाइलें अधिकांश फ़ाइल स्थान लेती हैं, जबकि रंग, प्रभाव, और ग्रेडिएंट जैसी आकृति पैरामीटर मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पता लगा सकता हूँ कि स्लाइड पर कौन-सी आकृतियों का स्वरूपण समान है ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकृति की मुख्य स्वरूपण विशेषताओं—फ़िल, लाइन, और इफेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाएँ, तो उनके स्टाइल को समान मानें और उन आकृतियों को तार्किक रूप से समूहित करें, जिससे बाद में शैली प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकृति शैलियों का एक सेट अलग फ़ाइल में सहेज सकता हूँ ताकि अन्य प्रस्तुतियों में पुन: उपयोग किया जा सके?**

हां। वांछित शैलियों के साथ नमूना आकृतियों को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में संग्रहित करें। नई प्रस्तुति बनाते समय, टेम्पलेट खोलें, आवश्यक स्टाइल्ड आकृतियों को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो उनके स्वरूपण को पुनः लागू करें।