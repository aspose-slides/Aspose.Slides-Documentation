---
title: Java में PowerPoint आकार फॉर्मेट करें
linktitle: आकार फॉर्मेटिंग
type: docs
weight: 20
url: /hi/java/shape-formatting/
keywords:
  - आकार फॉर्मेट
  - रेखा फॉर्मेट
  - स्केच प्रभाव
  - स्केच आकार रेखा
  - जॉइन स्टाइल फॉर्मेट
  - ग्रेडिएंट फ़िल
  - पैटर्न फ़िल
  - पिक्चर फ़िल
  - टेक्सचर फ़िल
  - सॉलिड कलर फ़िल
  - आकार पारदर्शिता
  - आकार घुमाएँ
  - 3d बीवेल प्रभाव
  - 3d घुमाव प्रभाव
  - फ़ॉर्मेटिंग रीसेट
  - PowerPoint
  - प्रस्तुति
  - Java
  - Aspose.Slides
description: "Aspose.Slides का उपयोग करके Java में PowerPoint आकार को कैसे फॉर्मेट करें सीखें—PPT, PPTX और ODP फ़ाइलों के लिए भराव, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकार जोड़ सकते हैं। चूँकि आकार रेखाओं से बने होते हैं, आप उनके आउटलाइन को संशोधित करके या प्रभाव लागू करके उन्हें फ़ॉर्मेट कर सकते हैं। इसके अतिरिक्त, आप आकारों को इस प्रकार फ़ॉर्मेट कर सकते हैं कि उनके आंतरिक भाग को भरने के सेटिंग्स को निर्दिष्ट किया जाए।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java इंटरफ़ेस और मेथड्स प्रदान करता है जो आपको PowerPoint में उपलब्ध वही विकल्पों का उपयोग करके आकारों को फ़ॉर्मेट करने की अनुमति देते हैं।

## **रेखाओं को फ़ॉर्मेट करें**

Aspose.Slides का उपयोग करके, आप किसी आकार के लिए कस्टम लाइन शैली निर्दिष्ट कर सकते हैं। नीचे दिए गए चरण इस प्रक्रिया को दर्शाते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स के आधार पर एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [line style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. लाइन का [dash style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए लाइन का रंग सेट करें।
1. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

```java
    // प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
    Presentation presentation = new Presentation();
    try {
        // पहले स्लाइड प्राप्त करें।
        ISlide slide = presentation.getSlides().get_Item(0);

        // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

        // Rectangle आकार के लिए फिल रंग सेट करें।
        shape.getFillFormat().setFillType(FillType.NoFill);

        // Rectangle की रेखाओं पर फ़ॉर्मेटिंग लागू करें।
        shape.getLineFormat().setStyle(LineStyle.ThickThin);
        shape.getLineFormat().setWidth(7);
        shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

        // Rectangle की रेखा का रंग सेट करें।
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

        // PPTX फ़ाइल को डिस्क पर सेव करें।
        presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

परिणाम:

![The formatted lines in the presentation](formatted-lines.png)

## **आकार रेखाओं पर स्केच प्रभाव लागू करें**

स्केच प्रभाव एक आकार की रेखा को हाथ से बना हुआ दिखाता है। लाइन सेटिंग्स तक पहुँचने के लिए [IShape.getLineFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) का उपयोग करें, स्केच सेटिंग्स तक पहुँचने के लिए [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilineformat/) का उपयोग करें, और [LineSketchType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/linesketchtype/) एन्उमरेशन से मान चुनने के लिए [ISketchFormat.setSketchType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isketchformat/) का उपयोग करें।

निम्नलिखित जावा कोड दर्शाता है कि कैसे [LineSketchType.Curved](https://reference.aspose.com/slides/hi/java/com.aspose.slides/linesketchtype/) प्रभाव लागू किया जाए, स्पष्ट रूप से निर्धारित मान पढ़ा जाए, और प्रभाव को [LineSketchType.None](https://reference.aspose.com/slides/hi/java/com.aspose.slides/linesketchtype/) से हटाया जाए:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // आकार के लाइन फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुँचें।
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // एक स्केच प्रभाव लागू करें।
    sketchFormat.setSketchType(LineSketchType.Curved);

    // आकार को सीधे सौंपा गया स्केच प्रभाव पढ़ें।
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // स्केच प्रभाव हटाएँ।
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isketchformat/) द्वारा लौटाया गया मान सीधे आकार को सौंपे गए सेटिंग को दर्शाता है। यदि लाइन फ़ॉर्मेटिंग थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में मिल सकती है, तो [ILineFormat.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilineformat/), [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilineformateffectivedata/), और [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isketchformateffectivedata/) का उपयोग करें। प्रभावी मान वह फ़ॉर्मेटिंग दिखाता है जो विरासत समाधान के बाद वास्तविक रूप से लागू होती है:

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

## **जॉइन स्टाइल फ़ॉर्मेट करें**

यहाँ तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे आकार के कोने पर), यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाले आकार बनाते हैं, तो आप **Miter** विकल्प को पसंद कर सकते हैं।

![The join style in the presentation](join-style-powerpoint.png)

निम्नलिखित जावा कोड दर्शाता है कि ऊपर की छवि में दिखाए गए तीन आयतों को Meter, Bevel, और Round जॉइन प्रकार सेटिंग्स का उपयोग करके कैसे बनाया गया था:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    // पहले स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार के तीन ऑटो शैप जोड़ें।
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // प्रत्येक Rectangle आकार के लिए फ़िल रंग सेट करें।
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // लाइन की चौड़ाई सेट करें।
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // प्रत्येक Rectangle की रेखा का रंग सेट करें।
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // जॉइन स्टाइल सेट करें।
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // प्रत्येक Rectangle में टेक्स्ट जोड़ें।
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

PowerPoint में, Gradient Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार पर लगातार रंगों का मिश्रण लागू करने देता है। उदाहरण के लिए, आप दो या अधिक रंग इस तरह लागू कर सकते हैं कि एक धीरे-धीरे दूसरे में मिल जाए।

Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट फ़िल कैसे लागू करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स के आधार पर एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) को `Gradient` सेट करें।
1. ग्रेडिएंट स्टॉप कलेक्शन की `add` मेथड्स का उपयोग करके, आप दो पसंदीदा रंगों को परिभाषित स्थितियों के साथ जोड़ सकते हैं, जो कि [IGradientFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igradientformat/) इंटरफ़ेस द्वारा उजागर किए गए हैं।
1. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // एलिप्स पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
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

![The ellipse with gradient fill](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में, Pattern Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार पर दो-रंगीय डिज़ाइन—जैसे बिंदु, धारी, क्रॉसहैच, या चेक—लगाने देता है। आप पैटर्न की अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप अपने प्रेज़ेंटेशन की दृश्य अपील बढ़ाने के लिए आकारों पर लागू कर सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप सटीक रंग निर्दिष्ट कर सकते हैं।

Aspose.Slides का उपयोग करके आकार पर पैटर्न फ़िल कैसे लागू किया जाए, यह यहाँ बताया गया है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स के आधार पर एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) को `Pattern` सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न के [Background Color](https://reference.aspose.com/slides/hi/java/com.aspose.slides/patternformat/#getBackColor--) को सेट करें।
1. पैटर्न के [Foreground Color](https://reference.aspose.com/slides/hi/java/com.aspose.slides/patternformat/#getForeColor--) को सेट करें।
1. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Fill प्रकार को Pattern सेट करें।
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

![The rectangle with pattern fill](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में, Picture Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार के अंदर एक छवि डालने देता है—अर्थात छवि को आकार की पृष्ठभूमि के रूप में उपयोग किया जाता है।

किस प्रकार Aspose.Slides का उपयोग करके आकार पर पिक्चर फ़िल लागू किया जाए, यह यहाँ है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स के आधार पर एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) को `Picture` सेट करें।
1. पिक्चर फ़िल मोड को `Tile` (या कोई अन्य पसंदीदा मोड) सेट करें।
1. उस छवि से एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) ऑब्जेक्ट बनाएँ जिसे आप उपयोग करना चाहते हैं।
1. छवि को `ISlidesPicture.setImage` मेथड में पास करें।
1. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास एक "lotus.png" फ़ाइल है जिसमें निम्नलिखित चित्र है:

![The lotus picture](lotus.png)

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Fill प्रकार को Picture सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // पिक्चर फ़िल मोड सेट करें।
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // एक इमेज लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // पिक्चर सेट करें।
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The shape with picture fill](picture-fill.png)

### **टाइल पिक्चर को टेक्सचर के रूप में**

यदि आप टाइल किया हुआ चित्र को टेक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को कस्टमाइज़ करना चाहते हैं, तो आप [IPictureFillFormat] इंटरफ़ेस और [PictureFillFormat] क्लास की निम्नलिखित मेथड्स का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): चित्र फ़िल मोड सेट करता है—या तो `Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): आकार के भीतर टाइल्स का संरेखण निर्धारित करता है।
- [setTileFlip](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): टाइल को क्षैतिज, लंबवत या दोनों दिशा में फ़्लिप करने को नियंत्रित करता है।
- [setTileOffsetX](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): आकार की मूल से टाइल का क्षैतिज ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): आकार की मूल से टाइल का लंबवत ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): टाइल का क्षैतिज स्केल प्रतिशत के रूप में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): टाइल का लंबवत स्केल प्रतिशत के रूप में परिभाषित करता है।

निम्नलिखित कोड नमूना दर्शाता है कि टाइल पिक्चर फ़िल के साथ आयत आकार कैसे जोड़ें और टाइल विकल्प कैसे कॉन्फ़िगर करें:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // एक Rectangle ऑटो शेप जोड़ें।
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // आकार का Fill प्रकार Picture सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // इमेज लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // इमेज को आकार को असाइन करें।
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // पिक्चर फ़िल मोड और टाइलिंग प्रॉपर्टीज़ कॉन्फ़िगर करें।
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

![The tile options](tile-options.png)

## **सॉलिड कलर फ़िल**

PowerPoint में, Solid Color Fill एक फ़ॉर्मेटिंग विकल्प है जो आकार को एकल, समान रंग से भरता है। यह सादा पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू किया जाता है।

Aspose.Slides का उपयोग करके आकार पर सॉलिड कलर फ़िल लागू करने के लिए, इन चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स के आधार पर एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) को `Solid` सेट करें।
1. आकार को अपना इच्छित फ़िल रंग असाइन करें।
1. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Fill प्रकार को Solid सेट करें।
    shape.getFillFormat().setFillType(FillType.Solid);

    // Fill रंग सेट करें।
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The shape with solid color fill](solid-color-fill.png)

## **ट्रांसपेरेंसी सेट करें**

PowerPoint में, जब आप आकारों पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिए ट्रांसपेरेंसी स्तर भी सेट कर सकते हैं। उच्च ट्रांसपेरेंसी मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे की वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल के लिए उपयोग किए गए रंग में अल्फा मान को समायोजित करके ट्रांसपेरेंसी स्तर सेट करने की अनुमति देता है। इसे करने का तरीका इस प्रकार है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स के आधार पर एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) को `Solid` सेट करें।
1. `Color` का उपयोग करके अल्फा घटक के साथ पारदर्शी रंग परिभाषित करें।
1. प्रेज़ेंटेशन को सहेजें।

```java
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // एक सॉलिड Rectangle ऑटो शैप जोड़ें।
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // सॉलिड आकार के ऊपर एक पारदर्शी Rectangle ऑटो शैप जोड़ें।
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

![The transparent shape](shape-transparency.png)

## **आकार घुमाएँ**

Aspose.Slides आपको PowerPoint प्रेज़ेंटेशन में आकार घुमाने देता है। यह विशेष संरेखण या डिज़ाइन आवश्यकताओं के साथ दृश्य तत्वों को स्थित करने में उपयोगी हो सकता है।

आकार को स्लाइड पर घुमाने के लिए, इन चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स के आधार पर एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार के घुमाव प्रॉपर्टी को वांछित कोण पर सेट करें।
1. प्रेज़ेंटेशन को सहेजें।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
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

![The shape rotation](shape-rotation.png)

## **3D बीवेल प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर [ThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करके 3D बीवेल प्रभाव लागू करने देता है।

3D बीवेल प्रभाव जोड़ने के लिए, इन चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स के आधार पर एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [ThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/threedformat/) को कॉन्फ़िगर करके बीवेल सेटिंग्स निर्धारित करें।
1. प्रेज़ेंटेशन को सहेजें।

```java
// Presentation क्लास का इंस्टेंस बनाएं।
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

    // आकार की ThreeDFormat प्रॉपर्टीज़ सेट करें।
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D घुमाव प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर [ThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करके 3D घुमाव प्रभाव लागू करने देता है।

3D घुमाव प्रभाव लागू करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स के आधार पर एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
1. 3D घुमाव को परिभाषित करने के लिए [setCameraType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icamera/#setCameraType-int-) और [setLightType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilightrig/#setLightType-int-) का उपयोग करें।
1. प्रेज़ेंटेशन को सहेजें।

```java
// Presentation क्लास का एक इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The 3D rotation effect](3D-rotation-effect.png)

## **फ़ॉर्मेटिंग रीसेट करें**

निम्नलिखित जावा कोड दर्शाता है कि स्लाइड की फ़ॉर्मेटिंग कैसे रीसेट करें और [LayoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/layoutslide/) पर प्लेसहोल्डर वाले सभी आकारों की स्थिति, आकार और फ़ॉर्मेटिंग को उनकी डिफ़ॉल्ट सेटिंग्स में कैसे वापस लाएँ:

```java
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

**क्या आकार की फ़ॉर्मेटिंग अंतिम प्रेज़ेंटेशन फ़ाइल आकार को प्रभावित करती है?**

केवल न्यूनतम रूप में। एम्बेडेड इमेजेज़ और मीडिया फ़ाइल के अधिकांश स्थान को लेते हैं, जबकि आकार के पैरामीटर जैसे रंग, प्रभाव, और ग्रेडिएंट मेटाडेटा के रूप में सहेजे जाते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पहचानूँ कि स्लाइड पर कौन से आकार समान फ़ॉर्मेटिंग साझा करते हैं ताकि मैं उन्हें समूहबद्ध कर सकूँ?**

प्रत्येक आकार की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन, और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके स्टाइल को समान मानें और उन आकारों को तार्किक रूप से समूहित करें, जिससे बाद के स्टाइल प्रबंधन को सरल बनाया जा सके।

**क्या मैं कस्टम आकार स्टाइल्स का एक सेट अलग फ़ाइल में सहेज सकता हूँ ताकि इसे अन्य प्रेज़ेंटेशन्स में पुनः उपयोग किया जा सके?**

हाँ। इच्छित स्टाइल वाले सैंपल आकारों को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में रखें। नई प्रेज़ेंटेशन बनाते समय टेम्पलेट खोलें, आवश्यक स्टाइल वाले आकारों को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो वहाँ उनके फ़ॉर्मेटिंग को फिर से लागू करें।