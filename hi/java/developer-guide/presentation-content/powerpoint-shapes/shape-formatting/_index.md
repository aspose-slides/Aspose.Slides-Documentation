---
title: Java में PowerPoint आकृतियों को स्वरूपित करें
linktitle: आकार स्वरूपण
type: docs
weight: 20
url: /hi/java/shape-formatting/
keywords:
- आकार स्वरूपित करना
- रेखा स्वरूपित करना
- स्केच प्रभाव
- स्केच आकार रेखा
- जॉइन शैली स्वरूपित करना
- ग्रेडिएंट भराव
- पैटर्न भराव
- चित्र भराव
- टेक्सचर भराव
- एकरंगी भराव
- आकार पारदर्शिता
- काली-सफ़ेद आकार रेंडरिंग
- ग्रेस्केल आकार रेंडरिंग
- आकार घुमाना
- 3D बेवेल प्रभाव
- 3D घुमाव प्रभाव
- फ़ॉर्मेट रीसेट
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Java में PowerPoint आकारों को कैसे स्वरूपित करें—PPT, PPTX, और ODP फ़ाइलों के लिए भराव, रेखा, और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकार जोड़ सकते हैं। चूँकि आकार रेखाओं से बने होते हैं, आप उनकी रूपरेखा को संशोधित करके या प्रभाव लागू करके फ़ॉर्मेट कर सकते हैं। अतिरिक्त रूप से, आप आकार को उनके आंतरिक भाग को भरने वाली सेटिंग्स निर्दिष्ट करके फ़ॉर्मेट कर सकते हैं।

![फ़ॉर्मेट-शेप-पावरपॉइंट](format-shape-powerpoint.png)

Aspose.Slides for Java उन इंटरफ़ेसेस और मेथड्स को प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकार को फ़ॉर्मेट करने की अनुमति देते हैं।

## **लाइन फ़ॉर्मेटिंग**

Aspose.Slides का उपयोग करके, आप किसी आकार के लिए कस्टम लाइन स्टाइल निर्दिष्ट कर सकते हैं। नीचे दिए गए चरण प्रक्रिया को दर्शाते हैं:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the [line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) of the shape.
1. Set the line width.
1. Set the [dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) of the line.
1. Set the line color for the shape.
1. Save the modified presentation as a PPTX file.

निम्न कोड एक आयत `AutoShape` को फ़ॉर्मेट करने का तरीका दर्शाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // आयताकार आकार के लिए भराव रंग सेट करें।
    shape.getFillFormat().setFillType(FillType.NoFill);

    // आयत की रेखाओं पर फ़ॉर्मेटिंग लागू करें।
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // आयत की रेखा का रंग सेट करें।
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![प्रस्तुति में फ़ॉर्मेटेड लाइन्स](formatted-lines.png)

## **आकार लाइन्स पर स्केच इफ़ेक्ट लागू करें**

एक स्केच इफ़ेक्ट आकार की रेखा को हाथ से खींची हुई दिखाता है। लाइन सेटिंग्स तक पहुँचने के लिए [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) का उपयोग करें, स्केच सेटिंग्स के लिए [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) और [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) का उपयोग करके [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) एन्यूमेरेशन से मान चुनें।

निम्न Java कोड दिखाता है कि कैसे [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) इफ़ेक्ट लागू किया जाए, स्पष्ट रूप से निर्धारित मान पढ़ा जाए, और [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) के साथ इफ़ेक्ट हटाया जाए:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // आकार के रेखा फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुँचें।
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // एक स्केच इफ़ेक्ट लागू करें।
    sketchFormat.setSketchType(LineSketchType.Curved);

    // आकार को सीधे असाइन किए गए स्केच इफ़ेक्ट को पढ़ें।
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // स्केच इफ़ेक्ट हटाएँ।
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) द्वारा लौटाया गया मान सीधे आकार को असाइन किया गया सेटिंग दर्शाता है। यदि लाइन फ़ॉर्मेटिंग थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में प्राप्त की जा सकती है, तो [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) का उपयोग करके, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/) तक पहुँचें, और फिर [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/) पढ़ें। प्रभावी मान वह फ़ॉर्मेटिंग दर्शाता है जो विरासत समाधान के बाद वास्तव में लागू होती है:

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

तीन जॉइन टाइप विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे आकार के कोने पर), तो यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाले आकार बना रहे हैं, तो आप **Miter** विकल्प को प्राथमिकता दे सकते हैं।

![प्रस्तुति में जॉइन स्टाइल](join-style-powerpoint.png)

निम्न Java कोड दिखाता है कि कैसे ऊपर दिखाए गए चित्र में तीन आयतें Miter, Bevel और Round जॉइन टाइप सेटिंग्स का उपयोग करके बनाई गईं:

```java
import com.aspose.slides.*;
import java.awt.Color;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार के तीन ऑटो शेप जोड़ें।
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयताकार आकार के लिए भराव रंग सेट करें।
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

    // प्रत्येक आयत में पाठ जोड़ें।
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

PowerPoint में, Gradient Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार पर निरंतर रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंग इस तरह लागू कर सकते हैं कि एक धीरे-धीरे दूसरे में मिल जाए।

Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट फ़िल लागू करने के चरण:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the shape's [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) to `Gradient`.
1. Add your two preferred colors with defined positions using the `add` methods of the gradient stop collection exposed by the [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/) interface.
1. Save the modified presentation as a PPTX file.

निम्न Java कोड एक एलिप्स पर ग्रेडिएंट फ़िल इफ़ेक्ट लागू करने का तरीका दर्शाता है:

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
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

![ग्रेडिएंट फ़िल वाला एलिप्स](gradient-fill.png)

यदि ग्रेडिएंट निर्यात की गई छवि में PowerPoint से अलग दिखता है, तो देखें [Choose a Gradient Rendering Style](/slides/hi/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)। आप प्रस्तुति में संग्रहीत ग्रेडिएंट फ़िल को बदले बिना रेंडरिंग स्टाइल चुन सकते हैं।

## **पैटर्न फ़िल**

PowerPoint में, Pattern Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको दो‑रंगी डिजाइन—जैसे डॉट्स, स्ट्राइप्स, क्रॉसहैचेज़ या चेक्स—आकार पर लागू करने देता है। आप पैटर्न के फ़ोरग्राउंड और बैकग्राउंड के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न स्टाइल प्रदान करता है जिन्हें आप अपने प्रस्तुतियों की दृश्य अपील बढ़ाने के लिए आकार पर लागू कर सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप सटीक रंग निर्दिष्ट कर सकते हैं।

Aspose.Slides का उपयोग करके आकार पर पैटर्न फ़िल लागू करने के चरण:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the shape’s [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) to `Pattern`.
1. Choose a pattern style from the predefined options.
1. Set the [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) of the pattern.
1. Set the [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) of the pattern.
1. Save the modified presentation as a PPTX file.

निम्न Java कोड दिखाता है कि कैसे एक आयत पर पैटर्न फ़िल लागू किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // भरण प्रकार को Pattern पर सेट करें।
    shape.getFillFormat().setFillType(FillType.Pattern);

    // पैटर्न शैली सेट करें।
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // पैटर्न पृष्ठभूमि और अग्रभूमि रंग सेट करें।
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैटर्न फ़िल वाला आयत](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में, Picture Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार के भीतर छवि डालने की अनुमति देता है—व्यावहारिक रूप से छवि को आकार की पृष्ठभूमि बनाकर।

Aspose.Slides का उपयोग करके आकार पर पिक्चर फ़िल लागू करने के चरण:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the shape's [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) to `Picture`.
1. Set the picture fill mode to `Tile` (or another preferred mode).
1. Create an [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) object from the image you want to use.
1. Pass the image to the `ISlidesPicture.setImage` method.
1. Save the modified presentation as a PPTX file.

मान लें हमारे पास "lotus.png" फ़ाइल है जिसमें निम्न चित्र है:

![लोटस चित्र](lotus.png)

निम्न Java कोड दिखाता है कि कैसे आकार को चित्र से भरें:

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // भरण प्रकार को Picture पर सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // चित्र भराव मोड सेट करें।
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // एक छवि लोड करें और इसे प्रस्तुति संसाधनों में जोड़ें।
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

![पिक्चर फ़िल वाला आकार](picture-fill.png)

### **टाइल पिक्चर को टेक्सचर के रूप में उपयोग करें**

यदि आप टाइल की गई छवि को टेक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को कस्टमाइज़ करना चाहते हैं, तो आप [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) क्लास की निम्न विधियों का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): सेट करता है पिक्चर फ़िल मोड—`Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): आकार के भीतर टाइलों के संरेखण को निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): निर्धारित करता है कि टाइल को क्षैतिज, ऊर्ध्वाधर या दोनों तरीके से फ़्लिप किया जाए।
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): आकार की मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): आकार की मूल बिंदु से टाइल का लंबवत ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): टाइल के क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): टाइल के लंबवत स्केल को प्रतिशत में परिभाषित करता है।

निम्न कोड नमूना दिखाता है कि कैसे टाइल पिक्चर फ़िल वाला आयत आकार जोड़ें और टाइल विकल्प कॉन्फ़िगर करें:

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // एक आयताकार ऑटो शेप जोड़ें।
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // आकार का भराव प्रकार Picture पर सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // छवि को आकार को असाइन करें।
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // चित्र भराव मोड और टाइलिंग गुणों को कॉन्फ़िगर करें।
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

PowerPoint में, Solid Color Fill एक फ़ॉर्मेटिंग विकल्प है जो आकार को एकरंगीय रंग से भरता है। यह सामान्य पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू किया जाता है।

Aspose.Slides का उपयोग करके आकार पर सॉलिड कलर फ़िल लागू करने के चरण:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the shape’s [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) to `Solid`.
1. Assign your preferred fill color to the shape.
1. Save the modified presentation as a PPTX file.

निम्न Java कोड दिखाता है कि कैसे PowerPoint स्लाइड में आयत पर सॉलिड कलर फ़िल लागू करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // भरण प्रकार को Solid पर सेट करें।
    shape.getFillFormat().setFillType(FillType.Solid);

    // भरण रंग सेट करें।
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![सॉलिड कलर फ़िल वाला आकार](solid-color-fill.png)

## **ट्रांस्पेरेन्सी सेट करें**

PowerPoint में, जब आप आकार पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता स्तर सेट कर सकते हैं ताकि भराव की पारदर्शिता नियंत्रित हो सके। उच्च ट्रांस्पेरेन्सी मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे के ऑब्जेक्ट भागतः दिखाई देते हैं।

Aspose.Slides आपको फ़िल के लिए उपयोग किए गए रंग की अल्फा वैल्यू को समायोजित करके ट्रांस्पेरेन्सी स्तर सेट करने देता है। ऐसा करने के चरण:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) to `Solid`.
1. Use `Color` to define a color with transparency (the `alpha` component controls transparency).
1. Save the presentation.

निम्न Java कोड दिखाता है कि कैसे आयत पर ट्रांस्पेरेन्ट फ़िल रंग लागू करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // एक ठोस आयताकार ऑटो शेप जोड़ें।
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ठोस आकार के ऊपर एक पारदर्शी आयताकार ऑटो शेप जोड़ें।
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

![ट्रांस्पेरेन्ट आकार](shape-transparency.png)

## **आकार घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकार घुमाने देता है। यह दृश्यमान तत्वों को विशिष्ट संरेखण या डिज़ाइन आवश्यकताओं के साथ स्थित करने के लिए उपयोगी हो सकता है।

स्लाइड पर आकार घुमाने के चरण:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the shape’s rotation property to the desired angle.
1. Save the presentation.

निम्न Java कोड दिखाता है कि कैसे आकार को 5 डिग्री घुमाएँ:

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
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

## **3D बेवेल इफ़ेक्ट जोड़ें**

Aspose.Slides आपको आकार पर 3D बेवेल इफ़ेक्ट लागू करने देता है जिससे आप उनके [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) गुणों को कॉन्फ़िगर कर सकते हैं।

आकार पर 3D बेवेल इफ़ेक्ट जोड़ने के चरण:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Configure the shape’s [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) to define bevel settings.
1. Save the presentation.

निम्न Java कोड दिखाता है कि कैसे आकार पर 3D बेवेल इफ़ेक्ट लागू करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation क्लास का एक इंस्टैंस बनाएं।
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

परिणाम:

![3D बेवेल इफ़ेक्ट](3D-bevel-effect.png)

## **3D घुमाव इफ़ेक्ट जोड़ें**

Aspose.Slides आपको आकार पर 3D घुमाव इफ़ेक्ट लागू करने देता है जिससे आप उनके [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) गुणों को कॉन्फ़िगर कर सकते हैं।

आकार पर 3D घुमाव लागू करने के चरण:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Use the [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) and [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) to define the 3D rotation.
1. Save the presentation.

निम्न Java कोड दिखाता है कि कैसे आकार पर 3D घुमाव इफ़ेक्ट लागू करें:

```java
import com.aspose.slides.*;

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

परिणाम:

![3D घुमाव इफ़ेक्ट](3D-rotation-effect.png)

## **आकार की काली‑सफ़ेद रेंडरिंग नियंत्रित करें**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) मेथड यह निर्दिष्ट करता है कि प्रस्तुति को काली‑सफ़ेद मोड में देखा या प्रोसेस किया जाता है तो व्यक्तिगत आकार को कैसे रेंडर किया जाए। यह स्वयं काली‑सफ़ेद डिस्प्ले को सक्षम नहीं करता और सामान्य रंग मोड में आकार की फ़िल, लाइन या अन्य फ़ॉर्मेटिंग को नहीं बदलता।

वांछित व्यवहार चुनने के लिए आप [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) क्लास से मान उपयोग कर सकते हैं। उदाहरण के लिए, `Automatic` रेंडरिंग एप्लिकेशन को रूपांतरण चुनने देता है, `Gray` और `LightGray` ग्रे रंग का उपयोग करते हैं, `BlackWhite` केवल काला‑सफ़ेद, `Black` और `White` एकल रंग लागू करते हैं, `Color` सामान्य रंग को बरकरार रखता है, और `Hidden` काली‑सफ़ेद मोड में आकार को छोड़ देता है। `NotDefined` का अर्थ है कि कोई आकार‑स्तर मोड असाइन नहीं किया गया है।

निम्न Java कोड एक रंगीन आकार बनाता है और उसे काली‑सफ़ेद डिस्प्ले मोड में ग्रे दिखाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // रंग मोड में नारंगी भराव रखें, लेकिन काली-सफ़ेद मोड में आकार को ग्रे रंग में रेंडर करें।
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सामान्य रंग मोड में, आयत अपना नारंगी फ़िल बनाए रखता है। काली‑सफ़ेद डिस्प्ले वर्कफ़्लो में, इसका मोड `Gray` सेट होने के कारण यह ग्रे रंग दिखाता है। यह आपको पूरी‑रंग स्लाइड को संरक्षित करने की अनुमति देता है जबकि प्रिंटिंग, प्रीव्यू या अन्य वर्कफ़्लो में अलग‑अलग काली‑सफ़ेद डिस्प्ले सेटिंग्स को परिभाषित करता है।

## **फ़ॉर्मेट रीसेट करें**

निम्न Java कोड दर्शाता है कि कैसे स्लाइड की फ़ॉर्मेटिंग रीसेट करें और सभी प्लेसहोल्डर वाले आकारों की स्थिति, आकार और फ़ॉर्मेटिंग को उनके मूल [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) सेटिंग्स पर लौटाएँ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // लेआउट पर प्लेसहोल्डर वाले स्लाइड के प्रत्येक आकार को रीसेट करें।
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकार फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करती है?**

बहुत कम। एंबेडेड इमेज और मीडिया बड़ी फ़ाइल स्थान लेते हैं, जबकि रंग, इफ़ेक्ट और ग्रेडिएंट जैसी आकार पैरामीटर्स मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे उन आकारों का पता लगा सकता हूँ जो समान फ़ॉर्मेटिंग साझा करते हैं ताकि उन्हें समूहित किया जा सके?**

प्रत्येक आकार की मुख्य फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके स्टाइल को समान मानें और उन आकारों को लॉजिकल रूप से समूहित करें, जिससे बाद में स्टाइल प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकार स्टाइल्स का एक सेट अलग फ़ाइल में सहेज सकता हूँ ताकि अन्य प्रस्तुतियों में पुनः उपयोग किया जा सके?**

हाँ। टेम्प्लेट स्लाइड डेक या .POTX टेम्प्लेट फ़ाइल में इच्छित स्टाइल वाले नमूना आकार रखें। नई प्रस्तुति बनाते समय टेम्प्लेट खोलें, आवश्यक स्टाइल वाले आकार क्लोन करें और जहाँ भी ज़रूरत हो फ़ॉर्मेटिंग पुनः लागू करें।