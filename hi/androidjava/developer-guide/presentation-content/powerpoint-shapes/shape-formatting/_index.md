---
title: एंड्रॉइड पर PowerPoint आकार स्वरूपित करें
linktitle: आकार स्वरूपण
type: docs
weight: 20
url: /hi/androidjava/shape-formatting/
keywords:
- आकार फ़ॉर्मेट
- रेखा फ़ॉर्मेट
- जॉइन शैली फ़ॉर्मेट
- ग्रेडिएंट फ़िल
- पैटर्न फ़िल
- चित्र फ़िल
- टेक्सचर फ़िल
- सॉलिड कलर फ़िल
- आकार पारदर्शिता
- आकार घुमाएँ
- 3D बिवेल इफ़ेक्ट
- 3D रोटेशन इफ़ेक्ट
- फ़ॉर्मेट रीसेट करें
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Android पर PowerPoint आकारों को फ़ॉर्मेट करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिए फ़िल, रेखा और इफ़ेक्ट शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकार जोड़ सकते हैं। चूँकि आकार रेखाओं से बनते हैं, आप उनकी रूपरेखा को संशोधित करके या प्रभाव लागू करके उनका स्वरूप बदल सकते हैं। अतिरिक्त रूप से, आप आकारों को इस तरह के सेटिंग्स निर्दिष्ट करके स्वरूपित कर सकते हैं जो नियंत्रित करती हैं कि उनका अंदरूनी भाग कैसे भरा गया है।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java ऐसी इंटरफ़ेस और मेथड्स प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकारों को स्वरूपित करने की अनुमति देते हैं।

## **रेखाओं का स्वरूप**

Aspose.Slides का उपयोग करके आप एक आकार के लिए कस्टम लाइन शैली निर्दिष्ट कर सकते हैं। नीचे दी गई चरणों में प्रक्रिया का विवरण है:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [line style](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. लाइन के [dash style](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए लाइन का रंग सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करें।

निम्नलिखित कोड दर्शाता है कि कैसे एक आयत `AutoShape` का स्वरूप बदलें:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // आयत आकार के लिए फ़िल रंग सेट करें।
    shape.getFillFormat().setFillType(FillType.NoFill);

    // आयत की रेखाओं पर फ़ॉर्मेटिंग लागू करें।
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // आयत की रेखा के लिए रंग सेट करें।
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX फ़ाइल को डिस्क में सहेजें।
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![प्रेजेंटेशन में स्वरूपित रेखाएँ](formatted-lines.png)

## **जॉइन शैलियों का स्वरूप**

यहाँ तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो लाइनों को कोण पर जोड़ता है (जैसे आकार के कोने पर), यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाले आकार बना रहे हैं, तो आप **Miter** विकल्प को पसंद कर सकते हैं।

![प्रेजेंटेशन में जॉइन शैली](join-style-powerpoint.png)

निम्नलिखित Java कोड दर्शाता है कि ऊपर की छवि में दिखाए गए तीन आयत (Miter, Bevel, और Round जॉइन प्रकार सेटिंग्स का उपयोग करके) कैसे बनाए गए:

```java
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार के तीन ऑटो शेप जोड़ें।
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयत आकार के लिए फ़िल रंग सेट करें।
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

    // प्रत्येक आयत की रेखा के लिए रंग सेट करें।
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

    // PPTX फ़ाइल को डिस्क में सहेजें।
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ग्रेडिएंट फ़िल**

PowerPoint में, ग्रेडिएंट फ़िल एक स्वरूपण विकल्प है जो आपको एक आकार पर निरंतर रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंग इस प्रकार लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में मिल जाए।

Aspose.Slides का उपयोग करके एक आकार पर ग्रेडिएंट फ़िल लागू करने के चरण इस प्रकार हैं:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Gradient` सेट करें।
1. अपनी पसंदीदा दो रंगों को उनके स्थानों के साथ जोड़ें, इसके लिए [IGradientFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igradientformat/) इंटरफ़ेस द्वारा प्रदर्शित ग्रेडिएंट स्टॉप कलेक्शन के `add` मेथड का उपयोग करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करें।

निम्नलिखित Java कोड दर्शाता है कि एक दीर्घवृत्त पर ग्रेडिएंट फ़िल प्रभाव कैसे लागू किया जाए:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse प्रकार का ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // दीर्घवृत्त पर ग्रेडिएंट फ़ॉर्मेट लागू करें।
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // ग्रेडिएंट की दिशा सेट करें।
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // दो ग्रेडिएंट स्टॉप जोड़ें।
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX फ़ाइल को डिस्क में सहेजें।
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ग्रेडिएंट भराव वाला लंबवृत्त](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में, पैटर्न फ़िल एक स्वरूपण विकल्प है जो आपको दो‑रंगीय डिज़ाइन—जैसे बिंदु, धारियां, क्रॉसहैच या चेक—को आकार पर लागू करने देता है। आप पैटर्न की अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियों को प्रदान करता है जिन्हें आप अपने प्रस्तुतियों की दृश्य अपील बढ़ाने के लिए आकारों पर लागू कर सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप सटीक रंग निर्दिष्ट कर सकते हैं।

पैटर्न फ़िल को लागू करने के चरण इस प्रकार हैं:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Pattern` सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न के [Background Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/patternformat/#getBackColor--) को सेट करें।
1. पैटर्न के [Foreground Color](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/patternformat/#getForeColor--) को सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करें।

निम्नलिखित Java कोड दर्शाता है कि एक आयत पर पैटर्न फ़िल कैसे लागू किया जाए:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Pattern सेट करें।
    shape.getFillFormat().setFillType(FillType.Pattern);

    // पैटर्न शैली सेट करें।
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // पैटर्न की पृष्ठभूमि और अग्रभूमि रंग सेट करें।
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // PPTX फ़ाइल को डिस्क में सहेजें।
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैटर्न फ़िल वाला आयत](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में, पिक्चर फ़िल एक स्वरूपण विकल्प है जो आपको एक चित्र को आकार के भीतर सम्मिलित करने देता है—अर्थात् चित्र को आकार की पृष्ठभूमि के रूप में उपयोग किया जाता है।

Aspose.Slides का उपयोग करके पिक्चर फ़िल को लागू करने के चरण इस प्रकार हैं:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Picture` सेट करें।
1. पिक्चर फ़िल मोड को `Tile` (या अन्य पसंदीदा मोड) सेट करें।
1. इच्छित चित्र से एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) ऑब्जेक्ट बनाएं।
1. चित्र को `ISlidesPicture.setImage` मेथड में पास करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करें।

मान लें कि हमारे पास "lotus.png" फ़ाइल निम्नलिखित चित्र के साथ है:

![लोटस चित्र](lotus.png)

निम्नलिखित Java कोड दर्शाता है कि आकार को चित्र से कैसे भरें:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // फ़िल प्रकार को Picture सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // चित्र फ़िल मोड सेट करें।
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // एक इमेज लोड करें और उसे प्रेजेंटेशन संसाधनों में जोड़ें।
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // चित्र सेट करें।
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX फ़ाइल को डिस्क में सहेजें।
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पिक्चर फ़िल वाला आकार](picture-fill.png)

### **टाइल चित्र को टेक्सचर के रूप में सेट करें**

यदि आप टाइल किए गए चित्र को टेक्सचर के रूप में सेट करना और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप निम्नलिखित [IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/picturefillformat/) क्लास की मेथड्स का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): चित्र फ़िल मोड सेट करता है—`Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): आकार के भीतर टाइल की अभिविन्यास निर्धारित करता है।
- [setTileFlip](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): टाइल को क्षैतिज, लंबवत या दोनों दिशाओं में फ़्लिप करने को नियंत्रित करता है।
- [setTileOffsetX](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): आकार की मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): आकार की मूल बिंदु से टाइल का लंबवत ऑफ़सेट (पॉइंट में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): टाइल की क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): टाइल की लंबवत स्केल को प्रतिशत में परिभाषित करता है।

निम्नलिखित कोड नमूना दिखाता है कि टाइल्ड पिक्चर फ़िल के साथ एक आयत आकार कैसे जोड़ें और टाइल विकल्प कॉन्फ़िगर करें:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // एक आयत ऑटो शेप जोड़ें।
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // आकार की फ़िल प्रकार को Picture सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // इमेज लोड करें और इसे प्रेजेंटेशन संसाधनों में जोड़ें।
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // इमेज को आकार में असाइन करें।
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // चित्र फ़िल मोड और टाइलिंग गुण कॉन्फ़िगर करें।
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // PPTX फ़ाइल को डिस्क में सहेजें।
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टाइल विकल्प](tile-options.png)

## **सॉलिड कलर फ़िल**

PowerPoint में, सॉलिड कलर फ़िल एक स्वरूपण विकल्प है जो आकार को एक समान रंग से भरता है। यह सरल पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू किया जाता है।

Aspose.Slides का उपयोग करके सॉलिड कलर फ़िल लागू करने के चरण इस प्रकार हैं:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Solid` सेट करें।
1. आकार को अपनी पसंद का भराव रंग असाइन करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करें।

निम्नलिखित Java कोड दर्शाता है कि PowerPoint स्लाइड में एक आयत पर सॉलिड कलर फ़िल कैसे लागू किया जाए:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Solid सेट करें।
    shape.getFillFormat().setFillType(FillType.Solid);

    // फ़िल रंग सेट करें।
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX फ़ाइल को डिस्क में सहेजें।
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![सॉलिड कलर फ़िल वाला आकार](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में, जब आप आकारों पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिए पारदर्शिता स्तर भी सेट कर सकते हैं। उच्च पारदर्शिता मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या अंतर्निहित वस्तुएँ आंशिक रूप से दिखती हैं।

Aspose.Slides फ़िल में उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने की अनुमति देता है। इसे करने का तरीका इस प्रकार है:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Solid` सेट करें।
1. `Color` का उपयोग करके पारदर्शिता वाले रंग को परिभाषित करें (अल्फा घटक पारदर्शिता को नियंत्रित करता है)।
1. प्रेजेंटेशन को सेव करें।

निम्नलिखित Java कोड दर्शाता है कि आयत पर पारदर्शी फ़िल रंग कैसे लागू किया जाए:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
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

    // PPTX फ़ाइल को डिस्क में सहेजें।
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी आकार](shape-transparency.png)

## **आकारों को घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकारों को घुमाने की सुविधा देता है। यह विशेष रूप से दृश्यों को विशिष्ट संरेखण या डिजाइन आवश्यकताओं के साथ स्थित करने में उपयोगी है।

स्लाइड पर एक आकार को घुमाने के चरण इस प्रकार हैं:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की रोटेशन प्रॉपर्टी को इच्छित कोण पर सेट करें।
1. प्रेजेंटेशन को सेव करें।

निम्नलिखित Java कोड दर्शाता है कि आकार को 5 डिग्री के कोण पर कैसे घुमाएँ:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का ऑटो शेप जोड़ें.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // आकार को 5 डिग्री घुमाएँ.
    shape.setRotation(5);

    // PPTX फ़ाइल को डिस्क में सहेजें.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![आकार घुमाव](shape-rotation.png)

## **3D बिवेल इफ़ेक्ट जोड़ें**

Aspose.Slides आपको आकारों पर 3D बिवेल इफ़ेक्ट लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

3D बिवेल इफ़ेक्ट जोड़ने के चरण इस प्रकार हैं:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार के [ThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/) को कॉन्फ़िगर करके बिवेल सेटिंग्स निर्धारित करें।
1. प्रेजेंटेशन को सेव करें।

निम्नलिखित Java कोड दर्शाता है कि एक आकार पर 3D बिवेल इफ़ेक्ट कैसे लागू किया जाए:

```java
// Presentation क्लास का एक इंस्टांस बनाएं।
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

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D बिवेल इफ़ेक्ट](3D-bevel-effect.png)

## **3D रोटेशन इफ़ेक्ट जोड़ें**

Aspose.Slides आपको आकारों पर 3D रोटेशन इफ़ेक्ट लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

3D रोटेशन लागू करने के चरण इस प्रकार हैं:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स के द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. 3D रोटेशन को परिभाषित करने के लिए [setCameraType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icamera/#setCameraType-int-) और [setLightType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) का उपयोग करें।
1. प्रेजेंटेशन को सेव करें।

निम्नलिखित Java कोड दर्शाता है कि आकार पर 3D रोटेशन इफ़ेक्ट कैसे लागू किया जाए:

```java
// Presentation क्लास का एक इंस्टांस बनाएं।
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

![3D रोटेशन इफ़ेक्ट](3D-rotation-effect.png)

## **फ़ॉर्मेट रीसेट करें**

निम्नलिखित Java कोड दर्शाता है कि स्लाइड के फ़ॉर्मेट को कैसे रीसेट करें और सभी प्लेसहोल्डर वाले आकारों की स्थिति, आकार और फ़ॉर्मेट को [LayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/layoutslide/) पर उनकी डिफ़ॉल्ट सेटिंग्स पर वापस लाएँ:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // लेआउट पर प्लेसहोल्डर वाले स्लाइड में प्रत्येक आकार को रीसेट करें।
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकार स्वरूपण अंतिम प्रेजेंटेशन फ़ाइल आकार को प्रभावित करता है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियां और मीडिया फ़ाइलें अधिकांश स्थान लेती हैं, जबकि रंग, प्रभाव और ग्रेडिएंट जैसी आकार पैरामीटर मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पता लगा सकता हूँ कि कौन से आकार एक ही स्वरूपण साझा करते हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकार की प्रमुख स्वरूपण विशेषताओं—फ़िल, लाइन और प्रभाव सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो शैली को समान मानें और उन आकारों को तार्किक रूप से समूहित करें, जिससे बाद में शैली प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकार शैलियों को एक अलग फ़ाइल में सहेज सकता हूँ ताकि अन्य प्रेजेंटेशन में पुनः उपयोग कर सकूँ?**

हां। वांछित शैलियों वाले नमूना आकारों को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में सहेजें। नई प्रेजेंटेशन बनाते समय टेम्पलेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहाँ भी आवश्यक हो वहां उनका फ़ॉर्मेट पुनः लागू करें।