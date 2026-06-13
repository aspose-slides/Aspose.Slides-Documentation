---
title: "Java में PowerPoint आकारों को फ़ॉर्मेट करें"
linktitle: "आकार फ़ॉर्मेटिंग"
type: docs
weight: 20
url: /hi/java/shape-formatting/
keywords:
- "आकार फ़ॉर्मेट करें"
- "रेखा फ़ॉर्मेट करें"
- "जॉइन स्टाइल फ़ॉर्मेट करें"
- "ग्रेडिएंट फ़िल"
- "पैटर्न फ़िल"
- "पिक्चर फ़िल"
- "टेक्सचर फ़िल"
- "सॉलिड रंग फ़िल"
- "आकार पारदर्शिता"
- "आकार घुमाएँ"
- "3D बीवेल इफ़ेक्ट"
- "3D घुमाव इफ़ेक्ट"
- "फ़ॉर्मेट रीसेट करें"
- PowerPoint
- "प्रस्तुति"
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Java में PowerPoint आकारों को फ़ॉर्मेट करना सीखें—PPT, PPTX, और ODP फ़ाइलों के लिए फ़िल, रेखा और इफ़ेक्ट शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकार (शेप्स) जोड़ सकते हैं। चूंकि आकार रेखाओं से बने होते हैं, आप उनके रूपरेखा को संशोधित करके या प्रभाव लागू करके उन्हें फ़ॉर्मेट कर सकते हैं। अतिरिक्त रूप से, आप आकार को उनके आंतरिक भाग को कैसे भरा जाए, नियंत्रित करने वाली सेटिंग्स निर्दिष्ट करके फ़ॉर्मेट कर सकते हैं।

![फ़ॉर्मेट-शेप-पावरपॉइंट](format-shape-powerpoint.png)

Aspose.Slides for Java उन इंटरफ़ेस और मेथड्स को प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकारों को फ़ॉर्मेट करने की अनुमति देते हैं।

## **रेखाओं का फ़ॉर्मेट**

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [line style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/linestyle/) सेट करें।
1. रेखा की चौड़ाई सेट करें।
1. रेखा के [dash style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए रेखा का रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Rectangle आकार के लिए फ़िल रंग सेट करें।
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Rectangle की रेखाओं पर फ़ॉर्मेटिंग लागू करें।
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

![प्रस्तुति में फ़ॉर्मेटेड रेखाएँ](formatted-lines.png)

## **जॉइन स्टाइल्स का फ़ॉर्मेट**

यहाँ तीन जॉइन प्रकार विकल्प हैं:

* राउंड
* माइटर
* बीवेल

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर (जैसे आकार के कोने पर) जोड़ता है, तो यह **राउंड** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोणों वाला आकार बना रहे हैं, तो आप **माइटर** विकल्प पसंद कर सकते हैं।

![प्रस्तुति में जॉइन स्टाइल](join-style-powerpoint.png)

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
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

    // रेखा की चौड़ाई सेट करें।
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // प्रत्येक Rectangle की रेखा के लिए रंग सेट करें।
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

PowerPoint में, ग्रेडिएंट फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको एक आकार पर लगातार रंगों के मिश्रण को लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंग इस प्रकार लागू कर सकते हैं कि एक धीरे-धीरे दूसरे में मिल जाता है।

यहाँ Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट फ़िल लागू करने का तरीका बताया गया है:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार की [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) को `Gradient` सेट करें।
5. ग्रेडिएंट स्टॉप संग्रह द्वारा प्रदान किए गए `add` मेथड्स का उपयोग करके परिभाषित स्थितियों के साथ अपनी दो पसंदीदा रंग जोड़ें, जो [IGradientFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igradientformat/) इंटरफ़ेस में उजागर होते हैं।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // एलीप्स पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
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

![ग्रेडिएंट फ़िल वाले अण्डाकार](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में, पैटर्न फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको दो रंगों के डिजाइन—जैसे बिंदु, धारियाँ, क्रॉसहैच, या चेक—को आकार पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियां प्रदान करता है जिन्हें आप अपनी प्रस्तुतियों की दृश्य अपील बढ़ाने के लिए आकारों पर लागू कर सकते हैं। पहले से निर्धारित पैटर्न चुनने के बाद भी, आप उसमें उपयोग किए जाने वाले सटीक रंग निर्दिष्ट कर सकते हैं।

यहाँ Aspose.Slides का उपयोग करके आकार पर पैटर्न फ़िल लागू करने का तरीका बताया गया है:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार की [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) को `Pattern` सेट करें।
5. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
6. पैटर्न का [Background Color](https://reference.aspose.com/slides/hi/java/com.aspose.slides/patternformat/#getBackColor--) सेट करें।
7. पैटर्न का [Foreground Color](https://reference.aspose.com/slides/hi/java/com.aspose.slides/patternformat/#getForeColor--) सेट करें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Pattern सेट करें।
    shape.getFillFormat().setFillType(FillType.Pattern);

    // पैटर्न स्टाइल सेट करें।
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

![पैटर्न फ़िल वाला आयत](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में, पिक्चर फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको एक आकार के भीतर छवि डालने की अनुमति देता है—जिससे छवि प्रभावी रूप से आकार की पृष्ठभूमि बन जाती है।

यहाँ Aspose.Slides का उपयोग करके आकार पर पिक्चर फ़िल लागू करने का तरीका बताया गया है:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार की [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) को `Picture` सेट करें।
5. पिक्चर फ़िल मोड को `Tile` (या कोई अन्य पसंदीदा मोड) सेट करें।
6. उपयोग करने वाली छवि से एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) ऑब्जेक्ट बनाएं।
7. छवि को `ISlidesPicture.setImage` मेथड में पास करें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लेते हैं कि हमारे पास निम्नलिखित चित्र वाली "lotus.png" फ़ाइल है:

![लोटस चित्र](lotus.png)

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // फ़िल प्रकार को Picture सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // पिक्चर फ़िल मोड सेट करें।
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // एक इमेज लोड करें और उसे प्रेज़ेंटेशन संसाधनों में जोड़ें।
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

![पिक्चर फ़िल वाला आकार](picture-fill.png)

### **टाइल पिक्चर को टेक्सचर के रूप में**

यदि आप टाइल्ड पिक्चर को टेक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को कस्टमाइज़ करना चाहते हैं, तो आप [IPictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/picturefillformat/) क्लास के निम्नलिखित मेथड्स का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): पिक्चर फ़िल मोड सेट करता है—`Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): आकार के भीतर टाइलों के संरेखण को निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): टाइल को क्षैतिज, लंबवत या दोनों दिशाओं में फ़्लिप करने को नियंत्रित करता है।
- [setTileOffsetX](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): आकार की मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): आकार की मूल बिंदु से टाइल का लंबवत ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): टाइल का क्षैतिज स्केल प्रतिशत में निर्धारित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): टाइल का लंबवत स्केल प्रतिशत में निर्धारित करता है।

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // एक Rectangle ऑटो शैप जोड़ें।
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // आकार का फ़िल प्रकार Picture सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // इमेज लोड करें और उसे प्रेज़ेंटेशन संसाधनों में जोड़ें।
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // इमेज को आकार को असाइन करें।
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // पिक्चर फ़िल मोड और टाइलिंग गुणों को कॉन्फ़िगर करें।
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

![टाइल विकल्प](tile-options.png)

## **सॉलिड कलर फ़िल**

PowerPoint में, सॉलिड कलर फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आकार को एक ही, समान रंग से भरता है। यह सादा पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू किया जाता है।

Aspose.Slides का उपयोग करके आकार पर सॉलिड कलर फ़िल लागू करने के लिए, निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार की [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) को `Solid` सेट करें।
5. आकार को अपना इच्छित फ़िल रंग असाइन करें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Solid सेट करें।
    shape.getFillFormat().setFillType(FillType.Solid);

    // फ़िल रंग सेट करें।
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![सॉलिड कलर फ़िल वाला आकार](solid-color-fill.png)

## **ट्रांसपेरेंसी सेट करें**

PowerPoint में, जब आप आकारों पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अस्पष्टता स्तर को सेट कर सकते हैं ताकि भराव की अपारदर्शिता को नियंत्रित किया जा सके। अधिक ट्रांसपेरेंसी मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या अंतर्निहित वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल में उपयोग किए गए रंग के अल्फा मान को समायोजित करके ट्रांसपेरेंसी स्तर सेट करने की अनुमति देता है। इसे करने का तरीका यह है:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) को `Solid` सेट करें।
5. `Color` का उपयोग करके ट्रांसपेरेंसी वाला रंग परिभाषित करें ( `alpha` घटक ट्रांसपेरेंसी को नियंत्रित करता है)।
6. प्रस्तुति को सहेजें।

```java
    // प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
    Presentation presentation = new Presentation();
    try {
        // पहली स्लाइड प्राप्त करें।
        ISlide slide = presentation.getSlides().get_Item(0);

        // एक सॉलिड Rectangle ऑटो शैप जोड़ें।
        IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

        // ठोस आकार के ऊपर एक पारदर्शी Rectangle ऑटो शैप जोड़ें।
        IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
        transparentShape.getFillFormat().setFillType(FillType.Solid);
        transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

        // PPTX फ़ाइल को डिस्क पर सहेजें।
        presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

![पारदर्शी आकार](shape-transparency.png)

## **आकार घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकार घुमाने की सुविधा देता है। यह विशेष संरेखण या डिज़ाइन आवश्यकताओं के साथ दृश्य तत्वों को स्थित करने में उपयोगी हो सकता है।

स्लाइड पर किसी आकार को घुमाने के लिए, निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार की rotation प्रॉपर्टी को इच्छित कोण पर सेट करें।
5. प्रस्तुति को सहेजें।

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
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

![आकार घुमाव](shape-rotation.png)

## **3D बीवेल इफ़ेक्ट जोड़ें**

Aspose.Slides आपको आकारों पर 3D बीवेल इफ़ेक्ट लागू करने की अनुमति देता है, उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/threedformat/) प्रॉपर्टियों को कॉन्फ़िगर करके।

एक आकार पर 3D बीवेल इफ़ेक्ट जोड़ने के लिए, निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. आकार की [ThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/threedformat/) को कॉन्फ़िगर करके बीवेल सेटिंग्स निर्धारित करें।
5. प्रस्तुति को सहेजें।

```java
// Presentation क्लास का एक इंस्टेंस बनाएं।
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

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![3D बीवेल इफ़ेक्ट](3D-bevel-effect.png)

## **3D घुमाव इफ़ेक्ट जोड़ें**

Aspose.Slides आपको आकारों पर 3D घुमाव इफ़ेक्ट लागू करने की अनुमति देता है, उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/threedformat/) प्रॉपर्टियों को कॉन्फ़िगर करके।

एक आकार पर 3D घुमाव लागू करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) जोड़ें।
4. 3D घुमाव को परिभाषित करने के लिए [setCameraType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icamera/#setCameraType-int-) और [setLightType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilightrig/#setLightType-int-) का उपयोग करें।
5. प्रस्तुति को सहेजें।

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

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![3D घुमाव इफ़ेक्ट](3D-rotation-effect.png)

## **फ़ॉर्मेट रीसेट करें**

निम्नलिखित Java कोड दिखाता है कि कैसे स्लाइड का फ़ॉर्मेट रीसेट किया जाए और [LayoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/layoutslide/) पर प्लेसहोल्डर वाले सभी आकारों की स्थिति, आकार और फ़ॉर्मेट को उनकी डिफ़ॉल्ट सेटिंग्स पर लौटाया जाए:

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

## **FAQ**

**क्या आकार फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करती है?**

केवल न्यूनतम रूप से। एम्बेडेड इमेजेज़ और मीडिया फ़ाइलें फ़ाइल आकार का अधिकांश हिस्सा लेती हैं, जबकि रंग, इफ़ेक्ट और ग्रेडिएंट जैसी आकार पैरामीटर मेटाडाटा के रूप में संग्रहीत होते हैं और वास्तव में कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं स्लाइड पर ऐसे आकारों को कैसे पहचान सकता हूँ जो समान फ़ॉर्मेटिंग साझा करते हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकार की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, रेखा और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके स्टाइल को समान मानें और उन आकारों को तार्किक रूप से समूहित करें, जिससे बाद में स्टाइल प्रबंधन आसान हो जाता है।

**क्या मैं कस्टम आकार शैलियों का एक सेट अलग फ़ाइल में सहेज सकता हूँ ताकि उसे अन्य प्रस्तुतियों में पुन: उपयोग किया जा सके?**

हाँ। इच्छित शैलियों वाले नमूना आकारों को एक टेम्प्लेट स्लाइड डेक या .POTX टेम्प्लेट फ़ाइल में संग्रहीत करें। नई प्रस्तुति बनाते समय, टेम्प्लेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो वहाँ उनके फ़ॉर्मेटिंग को पुनः लागू करें।