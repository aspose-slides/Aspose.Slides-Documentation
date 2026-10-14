---
title: Android पर PowerPoint आकारों को फ़ॉर्मेट करें
linktitle: आकार फ़ॉर्मेटिंग
type: docs
weight: 20
url: /hi/androidjava/shape-formatting/
keywords:
- आकार फ़ॉर्मेट
- रेखा फ़ॉर्मेट
- स्केच प्रभाव
- आकार रेखा स्केच
- जॉइन शैली फ़ॉर्मेट
- ग्रेडिएंट भराव
- पैटर्न भराव
- चित्र भराव
- टेक्सचर भराव
- सॉलिड रंग भराव
- आकार पारदर्शिता
- काला‑सफ़ेद आकार रेंडरिंग
- ग्रेस्केल आकार रेंडरिंग
- आकार घुमाएँ
- 3D बीवेल प्रभाव
- 3D घूर्णन प्रभाव
- फ़ॉर्मेट रीसेट करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Android पर PowerPoint आकारों को फ़ॉर्मेट करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिए भराव, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकार ( shapes ) जोड़ सकते हैं। चूँकि आकार रेखाओं से बनते हैं, आप उनके रूपरेखा ( outline ) को संशोधित करके या प्रभाव लागू करके उन्हें फ़ॉर्मेट कर सकते हैं। इसके अतिरिक्त, आप आकार के भीतर के भाग को कैसे भरा जाए, यह नियंत्रित करने वाली सेटिंग्स निर्दिष्ट करके भी आकार को फ़ॉर्मेट कर सकते हैं।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java ऐसी इंटरफ़ेस और मेथड्स प्रदान करता है जो आपको PowerPoint में उपलब्ध वही विकल्पों का उपयोग करके आकारों को फ़ॉर्मेट करने में सक्षम बनाते हैं।

## **रेखा फ़ॉर्मेट करें**

Aspose.Slides का उपयोग करके आप किसी आकार के लिए कस्टम रेखा शैली निर्दिष्ट कर सकते हैं। नीचे दिए गये चरण प्रक्रिया को दर्शाते हैं:

1. [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. उसके अनुक्रमांक द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [रेखा शैली](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) सेट करें।
1. रेखा की मोटाई सेट करें।
1. रेखा की [डैश शैली](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) सेट करें।
1. आकार की रेखा का रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित कोड दिखाता है कि कैसे एक आयत `AutoShape` को फ़ॉर्मेट किया जाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation क्लास का एक उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो आकार जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Rectangle आकार से भराव हटाएँ ताकि केवल उसकी रेखाएँ दिखाई दें।
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Rectangle की रेखाओं पर फ़ॉर्मेटिंग लागू करें।
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

![The formatted lines in the presentation](formatted-lines.png)

## **आकार की रेखाओं पर स्केच प्रभाव लागू करें**

एक स्केच प्रभाव आकार की रेखा को हाथ से बने जैसा दिखाता है। रेखा सेटिंग्स तक पहुँचने के लिए [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) का उपयोग करें, स्केच सेटिंग्स तक पहुँचने के लिए [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) और स्केच प्रकार चुनने के लिए [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) का प्रयोग करें, और [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) एनीमरेशन से मान चुनें।

निम्नलिखित जावा कोड दिखाता है कि कैसे [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) प्रभाव लागू किया जाता है, स्पष्ट रूप से निर्धारित मान पढ़ा जाता है, और [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) के साथ प्रभाव हटाया जाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // आकार के रेखा फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुँचें।
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

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) द्वारा लौटाया गया मान सीधे आकार को सौंपे गए सेटिंग को दर्शाता है। यदि रेखा फ़ॉर्मेटिंग थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में प्राप्त की जा सकती है, तो [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) का उपयोग करें, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/) तक पहुँचें, और [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/) पढ़ें। प्रभावी मान वह फ़ॉर्मेट दर्शाता है जो विरासत समाधान के बाद वास्तव में लागू होता है:

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

## **जॉइन शैलियों को फ़ॉर्मेट करें**

तीन जॉइन प्रकार विकल्प हैं:

* गोल
* मीटर
* बिवेल

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोने ( जैसे कि आकार के कोने पर ) पर जोड़ता है, तो वह **गोल** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोनों वाला आकार बना रहे हैं, तो आप **मीटर** विकल्प को प्राथमिकता दे सकते हैं।

![The join style in the presentation](join-style-powerpoint.png)

निम्नलिखित जावा कोड दर्शाता है कि कैसे ऊपर दिखाए गये चित्र में तीन आयतें क्रमशः मीटर, बिवेल और गोल जॉइन प्रकार सेटिंग का उपयोग करके बनाई गईं:

```java
import com.aspose.slides.*;
import java.awt.Color;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार के तीन ऑटो आकार जोड़ें।
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

    // रेखा की मोटाई सेट करें।
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

## **ग्रेडिएंट भरें**

PowerPoint में, ग्रेडिएंट भरना एक फ़ॉर्मेटिंग विकल्प है जो आपको किसी आकार पर निरंतर रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिये, आप दो या अधिक रंगों को इस प्रकार लगा सकते हैं कि एक धीरे‑धीरे दूसरे में मिल जाए।

Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट भरने के लिए नीचे दिए गये चरण अपनाएँ:

1. [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. उसके अनुक्रमांक द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) को `Gradient` सेट करें।
1. ग्रेडिएंट स्टॉप संग्रह के `add` मेथड्स का उपयोग करके दो वांछित रंगों को परिभाषित स्थितियों के साथ जोड़ें, जो [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/) इंटरफ़ेस द्वारा एक्सपोज़ किए जाते हैं।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे एक दीर्घवृत्त पर ग्रेडिएंट भरने का प्रभाव लागू किया जाता है:

```java
import com.aspose.slides.*;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse प्रकार का एक ऑटो आकार जोड़ें।
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

यदि निर्यात की गई छवि में ग्रेडिएंट PowerPoint में दिखने वाले से अलग दिखता है, तो देखें [Choose a Gradient Rendering Style](/slides/hi/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)। आप प्रस्तुति में संग्रहीत ग्रेडिएंट भर को बदले बिना रेंडरिंग शैली चुन सकते हैं।

## **पैटर्न भरें**

PowerPoint में, पैटर्न भर एक फ़ॉर्मेटिंग विकल्प है जो आपको दो‑रंगी डिज़ाइन—जैसे बिंदु, धारियाँ, क्रॉसहैच या चेक—को आकार पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए अनुकूलित रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप आकारों पर लागू करके अपने प्रस्तुति की दृश्य आकर्षण बढ़ा सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप ठीक‑ठीक वही रंग निर्दिष्ट कर सकते हैं जो वह उपयोग करे।

Aspose.Slides का उपयोग करके आकार पर पैटर्न भरने के लिए नीचे दिए गये चरण अपनाएँ:

1. [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. उसके अनुक्रमांक द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) को `Pattern` सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न की [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) सेट करें।
1. पैटर्न की [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे एक आयत पर पैटर्न भर लागू किया जाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो आकार जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // भराव प्रकार को Pattern सेट करें।
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

## **चित्र भरें**

PowerPoint में, चित्र भर एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार के भीतर एक छवि सम्मिलित करने देता है—अर्थात् छवि को आकार की पृष्ठभूमि के रूप में उपयोग किया जाता है।

Aspose.Slides का उपयोग करके आकार पर चित्र भरने के लिए नीचे दिए गये चरण अपनाएँ:

1. [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. उसके अनुक्रमांक द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) को `Picture` सेट करें।
1. चित्र भर मोड को `Tile` (या कोई अन्य वांछित मोड) सेट करें।
1. अपनी इच्छित छवि से एक [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) ऑब्जेक्ट बनाएं।
1. छवि को `ISlidesPicture.setImage` मेथड में पास करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास "lotus.png" नामक फ़ाइल है जिसमें निम्नलिखित चित्र है:

![The lotus picture](lotus.png)

निम्नलिखित जावा कोड दिखाता है कि कैसे आकार को चित्र से भरा जाता है:

```java
import com.aspose.slides.*;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो आकार जोड़ें।
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // भराव प्रकार को Picture सेट करें।
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

![The shape with picture fill](picture-fill.png)

### **टाइल चित्र को बनावट के रूप में सेट करें**

यदि आप टाइल की गई छवि को बनावट के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) वर्ग के निम्न मेथड्स का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): चित्र भर मोड को सेट करता है—या तो `Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): आकार के भीतर टाइलों की संरेखण निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): निर्धारित करता है कि टाइल को क्षैतिज, ऊर्ध्वाधर या दोनों दिशा में फ़्लिप किया जाए।
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): आकार की मूलबिंदु से टाइल का क्षैतिज ऑफ़सेट (प्वाइंट में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): आकार की मूलबिंदु से टाइल का ऊर्ध्वाधर ऑफ़सेट (प्वाइंट में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): टाइल के क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): टाइल के ऊर्ध्वाधर स्केल को प्रतिशत में परिभाषित करता है।

निम्नलिखित कोड नमूना दिखाता है कि कैसे एक आयत आकार को टाइल्ड चित्र भर के साथ जोड़ा जाता है और टाइल विकल्प कॉन्फ़िगर किए जाते हैं:

```java
import com.aspose.slides.*;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // एक आयत ऑटो आकार जोड़ें।
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // आकार का भराव प्रकार Picture सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture);

    // छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // छवि को आकार को असाइन करें।
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

![The tile options](tile-options.png)

## **सॉलिड रंग भरें**

PowerPoint में, सॉलिड रंग भर एक फ़ॉर्मेटिंग विकल्प है जो आकार को एक ही समान रंग से भर देता है। यह साधारण पृष्ठभूमि रंग ग्रेडिएंट, बनावट या पैटर्न के बिना लागू किया जाता है।

Aspose.Slides का उपयोग करके आकार पर सॉलिड रंग भरने के लिए नीचे दिए गये चरण अपनाएँ:

1. [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. उसके अनुक्रमांक द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) को `Solid` सेट करें।
1. आकार को अपना वांछित भराव रंग असाइन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे PowerPoint स्लाइड में एक आयत पर सॉलिड रंग भर लागू किया जाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो आकार जोड़ें।
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

![The shape with solid color fill](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में, जब आप सॉलिड रंग, ग्रेडिएंट, चित्र या बनावट भर को आकारों पर लागू करते हैं, तो आप भराव की अपारदर्शिता स्तर सेट कर सकते हैं जिससे भराव की पारदर्शिता नियंत्रित होती है। अधिक पारदर्शिता मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे की वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको भराव के लिए उपयोग किए गए रंग में अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने की अनुमति देता है। इसे करने के लिए नीचे दिए गये चरण अपनाएँ:

1. [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. उसके अनुक्रमांक द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) को `Solid` सेट करें।
1. `Color` का उपयोग करके एक ऐसा रंग परिभाषित करें जिसमें पारदर्शिता (alpha घटक) हो।
1. प्रस्तुति को सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे एक आयत पर पारदर्शी भराव रंग लागू किया जाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // एक ठोस आयत ऑटो आकार जोड़ें।
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ठोस आकार के ऊपर एक पारदर्शी आयत ऑटो आकार जोड़ें।
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

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकारों को घुमाने की सुविधा देता है। यह दृश्य तत्वों को विशेष संरेखण या डिजाइन आवश्यकता के साथ स्थित करने में उपयोगी हो सकता है।

स्लाइड पर किसी आकार को घुमाने के लिए नीचे दिए गये चरण अपनाएँ:

1. [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. उसके अनुक्रमांक द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार की घूर्णन प्रॉपर्टी को इच्छित कोण पर सेट करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे आकार को 5 डिग्री पर घुमाया जाता है:

```java
import com.aspose.slides.*;

// presentation फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो आकार जोड़ें।
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

Aspose.Slides आपको आकारों पर 3D बीवेल प्रभाव लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) गुण कॉन्फ़िगर करते हैं।

आकार पर 3D बीवेल प्रभाव जोड़ने के लिए नीचे दिए गये चरण अपनाएँ:

1. [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. उसके अनुक्रमांक द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. आकार के [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) को कॉन्फ़िगर करके बीवेल सेटिंग निर्धारित करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित जावा कोड दर्शाता है कि कैसे आकार पर 3D बीवेल प्रभाव लागू किया जाता है:

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

![The 3D bevel effect](3D-bevel-effect.png)

## **3D घूर्णन प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर 3D घूर्णन प्रभाव लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) गुण कॉन्फ़िगर करते हैं।

आकार पर 3D घूर्णन लागू करने के लिए:

1. [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. उसके अनुक्रमांक द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) जोड़ें।
1. [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) और [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) का उपयोग करके 3D घूर्णन परिभाषित करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित जावा कोड दिखाता है कि कैसे आकार पर 3D घूर्णन प्रभाव लागू किया जाता है:

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

![The 3D rotation effect](3D-rotation-effect.png)

## **आकारों के लिए काली‑सफ़ेद रेंडरिंग नियंत्रित करें**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) मेथड निर्धारित करता है कि व्यक्तिगत आकार को काली‑सफ़ेद मोड में प्रस्तुति देखे या प्रोसेस की जाने पर कैसे रेंडर किया जाएगा। यह स्वयं काली‑सफ़ेद डिस्प्ले को सक्षम नहीं करता, न ही सामान्य रंग मोड में आकार के भराव, रेखा या अन्य फ़ॉर्मेटिंग को बदलता है।

इच्छित व्यवहार चुनने के लिये [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) वर्ग से कोई मान उपयोग करें। उदाहरण के लिये, `Automatic` रेंडरिंग एप्लिकेशन को रूपांतरण चुनने देता है, `Gray` और `LightGray` धूसर रंग का उपयोग करते हैं, `BlackWhite` केवल काला‑सफ़ेद उपयोग करता है, `Black` और `White` एकल रंग लागू करते हैं, `Color` सामान्य रंग संरक्षित रखता है, तथा `Hidden` काली‑सफ़ेद मोड में आकार को छोड़ देता है। `NotDefined` का अर्थ है कि कोई आकार‑स्तरीय मोड नियुक्त नहीं है।

निम्नलिखित जावा कोड एक रंगीन आकार बनाता है और काली‑सफ़ेद डिस्प्ले मोड में इसे ग्रे दिखाता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // रंग मोड में नारंगी भराव रखें, लेकिन काली‑सफ़ेद मोड में आकार को ग्रे रंग में रेंडर करें।
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सामान्य रंग मोड में, आयत अपना नारंगी भराव रखता है। काली‑सफ़ेद डिस्प्ले वर्कफ़्लो में, उसका मोड `Gray` होने के कारण यह ग्रे रंग में प्रदर्शित होता है। इससे आप पूर्ण‑रंग स्लाइड को संरक्षित रखते हुए प्रिंटिंग, पूर्वावलोकन या अन्य वर्कफ़्लो के लिये अलग-अलग काली‑सफ़ेद रूप निर्दिष्ट कर सकते हैं।

## **फ़ॉर्मेट रीसेट करें**

निम्नलिखित जावा कोड दर्शाता है कि कैसे स्लाइड की फ़ॉर्मेटिंग रीसेट की जाए और [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) पर प्लेसहोल्डर के साथ सभी आकारों की स्थिति, आकार और फ़ॉर्मेटिंग को उनके डिफ़ॉल्ट सेटिंग्स पर पुनर्स्थापित किया जाए:

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

**क्या आकार फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करती है?**

केवल न्यूनतम स्तर पर। एम्बेडेड छवियाँ और मीडिया फ़ाइलें फ़ाइल आकार का अधिकांश भाग लेती हैं, जबकि रंग, प्रभाव और ग्रेडिएंट जैसी आकार पैरामीटर मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे उन आकारों का पता लगा सकता हूँ जो स्लाइड पर समान फ़ॉर्मेटिंग साझा करते हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकार की प्रमुख फ़ॉर्मेटिंग गुण—भराव, रेखा और प्रभाव सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके शैलियों को समान मानें और लॉजिकल रूप से उन आकारों को समूहित करें, जिससे बाद में शैली प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकार शैलियों का एक सेट अलग फ़ाइल में सहेजकर अन्य प्रस्तुतियों में पुनः उपयोग कर सकता हूँ?**

हाँ। वांछित शैलियों वाले नमूना आकारों को एक टेम्प्लेट स्लाइड डेक या .POTX टेम्प्लेट फ़ाइल में सहेजें। नई प्रस्तुति बनाते समय टेम्प्लेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो उनका फ़ॉर्मेटिंग पुनः‑लागू करें।