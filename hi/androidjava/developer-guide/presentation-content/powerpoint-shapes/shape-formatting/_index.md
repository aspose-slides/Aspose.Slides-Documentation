---
title: Android पर PowerPoint आकृतियों को स्वरूपित करें
linktitle: आकृति स्वरूपण
type: docs
weight: 20
url: /hi/androidjava/shape-formatting/
keywords:
- आकार स्वरूपण
- रेखा स्वरूपण
- स्केच प्रभाव
- स्केच आकृति रेखा
- जॉइन शैली स्वरूपण
- ग्रेडिएंट भराव
- पैटर्न भराव
- चित्र भराव
- टेक्सचर भराव
- सॉलिड रंग भराव
- आकार पारदर्शिता
- काला-श्वेत आकार रेंडरिंग
- ग्रेस्केल आकार रेंडरिंग
- आकृति घुमाएँ
- 3D बिवल प्रभाव
- 3D घूर्णन प्रभाव
- फ़ॉर्मेटिंग रीसेट करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Android पर PowerPoint आकृतियों को स्वरूपित करना सीखें—PPT और PPTX फाइलों के लिए भराव, रेखा, और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में आकृतियों को उनके रूपरेखा, भराई और प्रभावों को समायोजित करके स्वरूपित करें। Aspose.Slides for Android via Java आपको इन सेटिंग्स को प्रोग्रैमेटिक रूप से नियंत्रित करने देता है, जिसमें पारदर्शिता, घूर्णन और 3D स्वरूपण शामिल है।

![PowerPoint में आकार स्वरूपण विकल्प](format-shape-powerpoint.png)

Aspose.Slides for Android via Java इंटरफ़ेस और मेथड प्रदान करता है जो आपको PowerPoint में उपलब्ध वही विकल्पों का उपयोग करके आकृतियों को स्वरूपित करने की अनुमति देते हैं।

## **लाइन स्वरूपित करें**

आकृति की रूपरेखा को नियंत्रित करने के लिए [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) का उपयोग करें। यह उदाहरण एक अनभरी आयत बनाता है जिसमें नीला, बिंदीदार रूपरेखा है। [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) एक मोटी‑पतली संयुक्त रेखा चुनता है, जबकि [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) उसकी चौड़ाई 7 पॉइंट सेट करता है और [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) डैश पैटर्न चुनता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![प्रस्तुति में स्वरूपित रेखाएँ](formatted-lines.png)

### **कस्टम लाइन डैश पैटर्न सेट करें**

जब पूर्वनिर्धारित लाइन शैलियाँ आवश्यक डैश लंबाई और गैप प्रदान नहीं करतीं, जैसे ब्रांडेड रूपरेखा या तकनीकी आरेख, तो [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) का उपयोग करें। पैटर्न असाइन करने से लाइन डैश शैली स्वतः [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) में बदल जाती है।

ऐरे एंट्रीज़ डैश और गैप लंबाइयों के बीच बारी‑बारी से बदलती हैं, डैश से शुरू होती हैं। प्रत्येक मान लाइन की चौड़ाई का गुणक है: `{ 4, 2 }` चौड़ाई 3 पॉइंट पर 12‑पॉइंट डैश के बाद 6‑पॉइंट गैप बनाता है। पूर्ण डैश‑एंड‑गैप सेगमेंट परिभाषित करने के लिए सीमित, गैर‑नकारात्मक मानों की जोड़ी प्रयोग करें। उदाहरण में सभी डैश और गैप दिखाने के लिए सकारात्मक मानों का उपयोग किया गया है।

यह उदाहरण समान लंबाई और फ्लैट कैप्स वाले पाँच नीले रेखाएँ बनाता है। पहले तीन 3 पॉइंट की चौड़ाई पर पैटर्न की तुलना करते हैं। चौथा पहली पैटर्न को दोगुनी चौड़ाई पर दोहराता है, जिससे डैश और गैप दोनों की लंबाई दोगुनी हो जाती है। पाँचवाँ कस्टम पैटर्न से सॉलिड लाइन पर स्विच करता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // अंतिम रेखा को सॉलिड शैली में बदलें।
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

प्रीडिफाइंड डैश्ड शैली पर वापस जाने के लिए, [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) को [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) में पास करें। चयनित शैली लाइन की उपस्थिति को नियंत्रित करती है।

PowerPoint में परिणाम, शीर्ष से नीचे: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; और **Solid, 3 pt**।

![PowerPoint में तीन कस्टम डैश पैटर्न, पहली पैटर्न का उपयोग करके एक चौड़ी रेखा, और एक ठोस रेखा](custom-dash-patterns.png)

### **लाइन कैप्स सेट करें**

खुली रेखा के अंत को सेट करने के लिए [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) का उपयोग करें। [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) क्लास तीन स्पष्ट कैप शैलियाँ प्रदान करती है:

- `Flat`: स्ट्रोक अंत बिंदु पर रुकता है।
- `Round`: अर्द्ध‑वृत्तीय कैप अंत बिंदु से आधी लाइन चौड़ाई तक बाहर बढ़ता है।
- `Square`: वर्गाकार कैप अंत बिंदु से आधी लाइन चौड़ाई तक बाहर बढ़ता है।

`NotDefined` भी शामिल है, जिसका अर्थ है कि कोई स्पष्ट कैप शैली असाइन नहीं की गई है।

कैप्स एरोहेड्स से अलग होते हैं, जो रेखा के अंत में प्रतीक जोड़ते हैं, और जोइन्स से अलग होते हैं, जो रेखा खंडों के बीच कोनों को नियंत्रित करते हैं। यह उदाहरण [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) और [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) के द्वारा एरोहेड्स को निष्क्रिय करता है ताकि केवल कैप आकारों की तुलना की जा सके।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint में परिणाम, शीर्ष से नीचे: **Flat**, **Round**, और **Square**।

![PowerPoint में समान मोटी रेखाओं पर फ्लैट, राउंड, और स्क्वायर कैप्स](line-caps.png)

## **आकार रेखाओं पर स्केच प्रभाव लागू करें**

एक स्केच प्रभाव आकार की रेखा को हाथ‑से‑खींची हुई दिखाता है। लाइन सेटिंग्स तक पहुँचने के लिए [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) का उपयोग करें, स्केच सेटिंग्स तक पहुँचने के लिए [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) का उपयोग करें, और [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) का उपयोग करके [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) क्लास से मान चुनें।

निम्नलिखित जावा कोड दिखाता है कि कैसे [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) प्रभाव लागू किया जाए, स्पष्ट रूप से असाइन किया गया मान पढ़ा जाए, और [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) से प्रभाव हटाया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) द्वारा लौटाया गया मान सीधे आकार को असाइन किए गए सेटिंग का प्रतिनिधित्व करता है। यदि लाइन फ़ॉर्मेट थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में मिल सकता है, तो [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) का उपयोग करें, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) तक पहुँचें, और [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--) पढ़ें। प्रभावी मान विरासत हल होने के बाद वास्तव में लागू फ़ॉर्मेट को दर्शाता है। यह उदाहरण पहले स्लाइड पर कम से कम एक आकार वाला मौज़ूद प्रस्तुति आवश्यक करता है और दोनों मान प्रिंट करता है:

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

## **जॉइन शैलियों को स्वरूपित करें**

Here are the three join type options:

* Round
* Miter
* Bevel

जॉइन स्टाइल निर्धारित करता है कि दो रूपरेखा खंड कोना पर कैसे मिलते हैं। गोल कोनों के लिए **Round**, तीखे कोनों के लिए **Miter**, या सपाट कोनों के लिए **Bevel** उपयोग करें।

![प्रस्तुति में जॉइन स्टाइल](join-style-powerpoint.png)

यह उदाहरण समान नीले रूपरेखा वाले 15 पॉइंट चौड़ी तीन काली आयतें बनाता है। यह क्रमशः [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) के मिटर, बिवेल और राउंड मानों को लागू करने के लिए [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) का उपयोग करता है, ताकि कोनों के निर्मित स्वरूप की तुलना की जा सके।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **तीखे कोनों पर मिटर जॉइन सीमित करें**

तीखे कोने कितनी दूर तक विस्तारित हो सकते हैं, इसे सीमित करने के लिए [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) पर सेट किए हुए [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) के साथ [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) का उपयोग करें।

सीमा जॉइन के आंतरिक और बाहरी कोनों के बीच दूरी के अनुपात को लाइन की चौड़ाई से दर्शाती है। उदाहरण के लिए, `8` मान लाइन चौड़ाई के आठ गुना तक मिटर लंबाई की अनुमति देता है; यह पॉइंट में माप नहीं है। यदि कोना इस सीमा से अधिक हो जाता है, तो PowerPoint उस कोने पर बिवेल्ड जॉइन उपयोग करता है। बड़ी सीमा तेज़ बिंदु की अनुमति देती है। यह सेटिंग केवल मिटर जॉइन को प्रभावित करती है, और सीमा के भीतर रहने पर दृश्य प्रभाव नहीं बदलता।

यह उदाहरण 20 पॉइंट चौड़ी रूपरेखा वाली दो समान, अनभरी त्रिकोण बनाता है। बायाँ त्रिकोण `2` सीमा उपयोग करता है, और दायाँ `8` का। प्रत्येक त्रिकोण 80 पॉइंट चौड़ा और 160 पॉइंट ऊँचा है, जिससे शीर्ष कोने का मिटर‑लंबाई‑से‑लाइन‑चौड़ाई अनुपात लगभग `4.12` होता है। परिणामस्वरूप, PowerPoint बायाँ शिखर बिवेल करता है और दायाँ शिखर बरकरार रखता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint में परिणाम: बाएँ **Miter limit 2** और दाएँ **miter limit 8**।

![PowerPoint में मिटर लिमिट 2 के साथ बिवेल्ड एपेक्स और मिटर लिमिट 8 के साथ नुकीला एपेक्स](miter-limits.png)

## **ग्रेडिएंट भराव**

एक ग्रेडिएंट भराव आकार के भीतर रंगों को मिश्रित करता है। यह उदाहरण लाल से बैंगनी तक 45‑डिग्री कोण पर रैखिक ग्रेडिएंट का उपयोग करके एक दीर्घवृत्त को भरता है, जिसमें [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--) प्रयोग किया गया है। [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) मेथड रंग स्टॉप को 0 और 1 पर रखता है, अर्थात ग्रेडिएंट की शुरुआत और अंत। मौजूदा स्टॉप को साफ़ करने से केवल ये दो रंग उपयोग होते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ग्रेडिएंट भराव वाला दीर्घवृत्त](gradient-fill.png)

यदि ग्रेडिएंट निर्यातित छवि में PowerPoint की तुलना में अलग दिखता है, तो देखें [ग्रेडिएंट रेंडरिंग शैली चुनें](/slides/hi/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)। आप प्रस्तुति में संग्रहीत ग्रेडिएंट भराव को बदले बिना एक रेंडरिंग शैली चुन सकते हैं।

### **रेखीय ग्रेडिएंट कोण सेट करें**

[ IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) का उपयोग करके [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) भराव की अभिविन्यास को नियंत्रित करें। कोण को डिग्री में मापा जाता है और घड़ी की दिशा में बढ़ता है: `0` बाएँ से दाएँ, `90` ऊपर से नीचे, `180` दाएँ से बाएँ, `270` नीचे से ऊपर। अंशीय कोण समर्थित हैं। `[0, 360)` के बाहर के सीमित कोण एक चक्र में सामान्यीकृत होते हैं; उदाहरण के लिए, `-45` बन जाता है `315` और `360` बन जाता है `0`।

यह उदाहरण समान लाल, हरे, और नीले स्टॉप को स्थितियों `0`, `0.5`, और `1` पर रखकर छह आयतें बनाता है। स्केलिंग निष्क्रिय है ताकि कोण को आयतों के अनुपात से स्वतंत्र रूप से तुलना किया जा सके। बाएँ से दाएँ कोने में कोण क्रमशः पहली पंक्ति में `0`, `45`, `90` और दूसरी पंक्ति में `135`, `180`, `270` हैं।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint में परिणाम:

![ऊपर पंक्ति में 0, 45, और 90 डिग्री पर रैखिक ग्रेडिएंट, और नीचे पंक्ति में 135, 180, और 270 डिग्री पर रैखिक ग्रेडिएंट](linear-gradient-angles.png)

### **आकार के साथ रैखिक ग्रेडिएंट स्केल करें**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) एक [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) मान स्वीकार करता है। इसे स्पष्ट रूप से `False` सेट करने से आकार के अनुपात बदलने पर ज्यामितीय ग्रेडिएंट कोण बरकरार रहता है, या `True` सेट करने से ग्रेडिएंट आकार की चौड़ाई और ऊँचाई के साथ स्केल होता है। स्केलिंग सक्षम होने पर, गैर‑स्क्वायर आकार पर दिखाई देने वाला कोण असाइन किए गए कोण से भिन्न हो सकता है।

निम्नलिखित उदाहरण `45`‑डिग्री कोण और समान रंग स्टॉप का उपयोग करता है। बाएँ कॉलम `False` उपयोग करता है; दाएँ कॉलम `True` उपयोग करता है। प्रत्येक कॉलम में चौड़ी आयत के ऊपर लंबी आयत होती है। दोनों प्रारम्भिक चौड़े आयाम से शुरू होते हैं; दूसरी आयत की चौड़ाई और ऊँचाई बदलने से दिखता है कि भराव आकार बदलने पर कैसे प्रतिक्रिया देता है बिना ग्रेडिएंट सेटिंग बदले।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint में परिणाम, बाएँ पर स्केलिंग निष्क्रिय और दाएँ पर सक्रिय:

![बाएँ पर LinearGradientScaled False और दाएँ पर True के साथ 45‑डिग्री ग्रेडिएंट वाले चौड़े और लंबे आयत](linear-gradient-scaling.png)

स्केलिंग निष्क्रिय होने पर, तिरछी रंग पट्टियाँ दोनों आयतों में समान अभिविन्यास रखती हैं। स्केलिंग सक्रिय होने पर, पट्टियाँ आकार के अनुपात के साथ फैलती हैं। यह विभिन्न आकारों पर आकार को अनुकूलित करते समय टेम्पलेट के ग्रेडिएंट को पुन: उत्पन्न करने में मदद करता है। स्क्वायर पर, स्केलिंग सक्षम करने से इस `45`‑डिग्री ग्रेडिएंट का स्वरूप नहीं बदलता।

कोण और स्केलिंग सेटिंग दोनों रैखिक ग्रेडिएंट पर लागू होते हैं। वे [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) भराव को नियंत्रित नहीं करते।

### **कोण को ग्रेडिएंट दिशा के साथ मिलाएँ**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/) क्लास से एक ग्रेडिएंट शैली चुनता है; यह संख्यात्मक कोण का विकल्प नहीं है। रैखिक ग्रेडिएंट के लिए, कोना शैलियाँ रंगों के वितरण क्षेत्र को बदल सकती हैं बिना [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) से असाइन किए गए कोण को बदले। कोण या स्केलिंग की तुलना करते समय दिशा को अपरिवर्तित रखें।

निम्नलिखित उदाहरण समान सेटिंग्स को विपरीत क्रम में लागू करता है। दोनों आयतों की दिखावट समान रहती है: दिशा को पहले या बाद में असाइन करने से परिणाम नहीं बदलता।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **पैटर्न भराव**

एक पैटर्न भराव दो‑रंगीय डिज़ाइन लागू करता है, जैसे बिंदु, धारियाँ, या जाँच। यह उदाहरण [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) का उपयोग करके ट्रेलिस पैटर्न चुनता है। [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) हल्का ग्रे पृष्ठभूमि प्रदान करता है, और [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) पीला पैटर्न रंग प्रदान करता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैटर्न भराव वाला आयत](pattern-fill.png)

## **चित्र भराव**

एक चित्र भराव आकार के भीतर छवि का उपयोग करता है। यह उदाहरण स्थानीय छवि की आवश्यकता रखता है और [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) का उपयोग करके उसे प्रस्तुति की इमेज कलेक्शन में लोड करता है। [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) को टाइल्ड मोड पर सेट करने से आयत के भीतर छवि दोहराई जाती है। नीचे दिखाए गये स्रोत चित्र को देखें:

![कमल की तस्वीर](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![चित्र भराव वाला आकार](picture-fill.png)

### **चित्र को टाइल टेक्सचर के रूप में**

यदि आप टाइल्ड चित्र को टेक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप निम्नलिखित [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) क्लास के मेथड का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): चित्र भराव मोड सेट करता है—`Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): आकार के भीतर टाइलों का संरेखण निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): टाइल को क्षैतिज, ऊर्ध्वाधर या दोनों दिशा में फ्लिप करने को नियंत्रित करता है।
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): आकार की उत्पत्ति से टाइल का क्षैतिज ऑफसेट (पॉइंट में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): आकार की उत्पत्ति से टाइल का ऊर्ध्वाधर ऑफसेट (पॉइंट में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): टाइल के क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): टाइल के ऊर्ध्वाधर स्केल को प्रतिशत में परिभाषित करता है।

यह उदाहरण स्थानीय छवि की आवश्यकता रखता है और [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) को मूल आकार के 50 % पर दोहराने के लिए कॉन्फ़िगर करता है। `−32` पॉइंट का ऑफसेट टाइलों को क्षैतिज और ऊर्ध्विक दोनों रूप से शिफ्ट करता है; नीचे‑दाएँ संरेखण और दोनों दिशा में फ़्लिपिंग तय करता है कि दोहराया गया टेक्सचर कैसे व्यवस्थित हो।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टाइल विकल्प](tile-options.png)

## **सॉलिड रंग भराव**

एक सॉलिड भराव आकार को एकल, समान रंग देता है। यह उदाहरण [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) का उपयोग करके सॉलिड भराव मोड चुनता है और [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) के माध्यम से पीला असाइन करता है, फिर आयत को प्रस्तुति में सहेजता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![सॉलिड रंग भराव वाला आकार](solid-color-fill.png)

### **थीम रेफरेंसेज़ को बरकरार रखते हुए रंग कॉपी करें**

[IColorFormat.copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) का उपयोग करके रंग परिभाषा कॉपी करें, जिसमें उसका रंग प्रकार, थीम रेफ़रेंस और ट्रांसफ़ॉर्मेशन शामिल हैं। यह उन आकारों के बीच फ़िल रंग स्थानांतरित करने में उपयोगी है जो प्रस्तुति थीम का अनुसरण जारी रखना चाहिए। मेथड केवल रंग कॉपी करता है: यह भराव प्रकार, रूपरेखा, या अन्य आकार फ़ॉर्मेटिंग नहीं कॉपी करता। गंतव्य की भराव प्रकार को स्पष्ट रूप से [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) से सेट करें।

यह उदाहरण बाएँ से दाएँ तीन आयतें बनाता है: स्रोत, थीम‑सचेत कॉपी, तथा स्थायी RGB कॉपी। स्रोत [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setSchemeColor-int-) से पहला एक्सेंट रंग संदर्भित करता है और [IColorOperationCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icoloroperationcollection/#add-int-float-) से टिंट जोड़ता है। RGB कॉपी स्रोत के प्रभावी भराव रंग का उपयोग करती है, इसलिए प्रारम्भ में सभी तीन समान दिखते हैं। [IColorFormat.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setColor-java.lang.Integer-) को कॉल करने से स्थायी RGB मान सेट होता है और किसी भी मौजूदा रंग ट्रांसफ़ॉर्मेशन को साफ़ किया जाता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // थीम रेफ़रेंस नए एक्सेंट रंग को अपनाते हैं; निश्चित RGB मान नहीं बदलता।
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

थीम परिवर्तन से पहले, सभी तीन भराव समान हैं:

![स्रोत, copyFrom गंतव्य, और समान नीले भराव वाले निश्चित RGB गंतव्य](color-copy-before.png)

थीम परिवर्तन के बाद, स्रोत और थीम‑सचेत कॉपी नया एक्सेंट रंग अपनाते हैं और अपनी टिंट बरकरार रखते हैं। स्थायी RGB कॉपी नीला ही रहता है:

![स्रोत और copyFrom गंतव्य के नारंगी भराव, जबकि निश्चित RGB गंतव्य नीला रहता है](color-copy-after.png)

कॉपी की गई परिभाषा स्रोत से स्वतंत्र है। आगे स्रोत की थीम रेफ़रेंस बदलने, कोई अन्य रंग असाइन करने, या उसकी ट्रांसफ़ॉर्मेशन जोड़ने या हटाने से गंतव्य नहीं बदलता। थीम परिवर्तन अभी भी दोनों आकारों को प्रभावित करता है क्योंकि प्रत्येक स्वतंत्र रूप से उसी थीम रंग को संदर्भित करता है।

[PPTX सहेजने और पुनः खोलने] से कॉपी किए गए रंग के प्रकार, थीम रेफ़रेंस, और ट्रांसफ़ॉर्मेशन कलेक्शन [IColorFormat.getColorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorType--) तथा [IColorFormat.getColorTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorTransform--) द्वारा संरक्षित रहते हैं; यह परिभाषा को RGB में फ़्लैट नहीं करता।

विभिन्न थीम संदर्भों के बीच कॉपी करते समय, जैसे विभिन्न एक्सेंट पैलेट वाली प्रस्तुतियों में, कॉपी किया गया रेफ़रेंस गंतव्य की थीम के विरुद्ध हल होता है। वही रेफ़रेंस और ट्रांसफ़ॉर्मेशन अलग‑दिखाई रंग बना सकते हैं। अधिक जानकारी के लिए देखें [प्रेजेंटेशन थीम](/slides/hi/androidjava/presentation-theme/)।

## **स्लाइड पृष्ठभूमि को आकार भराव के रूप में उपयोग करें**

जब आकार को स्लाइड पृष्ठभूमि से मेल खाना चाहिए, तो [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) का उपयोग करें, उदाहरण के लिए किसी प्रस्तुति टेम्पलेट में। पहले किसी स्पष्ट भराव को हटाने के लिए [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) को [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) पर सेट करें। इस संयोजन से आकार स्लाइड पृष्ठभूमि को अपने शैली भराव की जगह उपयोग करता है। केवल फ़्लैग सक्षम करने से मौजूदा स्पष्ट भराव नहीं हटता।

यह [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) से अलग है: पृष्ठभूमि भराव आकार के पीछे के वस्तुओं को स्लाइड पृष्ठभूमि के संबंधित क्षेत्र से ढ़कता है, जबकि NoFill उन वस्तुओं को दृश्यमान रखता है। एक ग्रेडिएंट स्लाइड के साथ संरेखित रहता है, प्रत्येक आकार के अंदर पुनः शुरू नहीं होता।

निम्नलिखित उदाहरण मास्टर पृष्ठभूमि बनाता है जिसे स्लाइड विरासत में लेती है और तीन आयतों के पीछे मैजेंटा बैंड रखता है। बायाँ आयत पृष्ठभूमि उपयोग करता है, मध्य आयत का कोई भराव नहीं है, और दायाँ आयत पृष्ठभूमि भराव से स्पष्ट नारंगी भराव में स्विच करता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // मास्टर से ग्रेडिएंट विरासत में लें।
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // इस वस्तु को पहले जोड़ें ताकि यह आयतों के पीछे दिखाई दे।
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // स्पष्ट भराव लागू करने से पहले पृष्ठभूमि भराव अक्षम करें।
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम, बाएँ से दाएँ: **background fill**, **no fill**, और **explicit fill**। मैजेंटा बैंड बाएँ और दाएँ आयतों द्वारा छिपा हुआ है लेकिन मध्य आयत के माध्यम से दृश्यमान रहता है।

![पृष्ठभूमि भराव, कोई भराव, और स्पष्ट नारंगी भराव मैजेंटा बैंड के ऊपर](background-fill.png)

इसी व्यवहार को सीधे स्लाइड पर परिभाषित या लेआउट से विरासत में मिली पृष्ठभूमि पर भी लागू किया जाता है। आकार स्लाइड की निराकृत पृष्ठभूमि का उपयोग करता है; उदाहरण दोनों स्लाइड और लेआउट पृष्ठभूमि को अनिर्धारित छोड़ता है ताकि मास्टर इसे प्रदान करे।

## **पारदर्शिता सेट करें**

सॉलिड भराव के लिए, रंग के अल्फा घटक से अपारदर्शिता नियंत्रित होती है: 0 पूरी तरह पारदर्शी और 255 पूरी तरह अपारदर्शी है। यह उदाहरण पीले आयत के लिए 128 का अल्फा मान उपयोग करता है, जिससे यह लगभग 50 % पारदर्शी बन जाता है और नीचे का आयत दृश्यमान रहता है। रंग को [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) के माध्यम से असाइन किया गया है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी आकार](shape-transparency.png)

## **आकृतियों को घुमाएँ**

[IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) का उपयोग करके स्लाइड सतह पर आकार को घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण आयत को 5 डिग्री घड़ी की दिशा में घुमाता है और प्रस्तुति सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![आकृति घूर्णन](shape-rotation.png)

## **3D बिवल प्रभाव जोड़ें**

[IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) का उपयोग करके आकार को गहराई और बिवल किनारे दें। यह उदाहरण हरे रंग का दीर्घवृत्त नारंगी रूपरेखा के साथ बनाता है, [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) से गहराई 4 पॉइंट सेट करता है, और [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) से 6 पॉइंट चौड़ाई‑ऊँचाई वाला गोल शीर्ष बिवल लागू करता है। सामने‑मुखी ऑर्थोग्राफिक कैमरा और तीन‑बिंदु प्रकाशन बिवल को दृश्यमान बनाते हैं।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D बिवल प्रभाव](3D-bevel-effect.png)

## **3D घूर्णन प्रभाव जोड़ें**

आकार का 3D दृश्य उसके कैमरा सेटिंग्स से नियंत्रित होता है। यह उदाहरण [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) को क्रमशः 40°, 35°, और 20° के लैटीट्यूड, लॉन्गिट्यूड, और रिवॉल्यूशन कोणों के साथ उपयोग करता है। यह [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) के द्वारा इज़ोमेट्रिक कैमरा चुनता है और [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) के द्वारा संतुलित प्रकाशन, फिर स्वरूपित आयत को सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D घूर्णन प्रभाव](3D-rotation-effect.png)

## **आकृतियों के लिए काला-श्वेत रेंडरिंग नियंत्रित करें**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) मेथड निर्दिष्ट करता है कि प्रस्तुति को काला‑श्वेत मोड में देखा या प्रोसेस किया जाता है तो व्यक्तिगत आकार कैसे रेंडर होगा। यह स्वयं काला‑श्वेत डिस्प्ले को सक्षम नहीं करता, न ही सामान्य रंग मोड में आकार की भराव, लाइन, या अन्य फ़ॉर्मेटिंग को बदलता है।

[BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) क्लास से मान चुनें वांछित व्यवहार के लिए। उदाहरण के लिये, `Automatic` रेंडरिंग एप्लिकेशन को परिवर्तन चुनने देता है, `Gray` और `LightGray` ग्रे रंग प्रयोग करते हैं, `BlackWhite` केवल काला‑श्वेत उपयोग करता है, `Black` और `White` एकल रंग बल देते हैं, `Color` सामान्य रंग बरकरार रखता है, और `Hidden` काला‑श्वेत मोड में आकार को छोड़ देता है। `NotDefined` का अर्थ है कि कोई आकार‑स्तरीय मोड असाइन नहीं किया गया है।

यह उदाहरण नारंगी आयत बनाता है और ग्रे रंग चुनने के लिए [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) का उपयोग करता है। सहेजा गया आकार सामान्य रंग डिस्प्ले में अपनी नारंगी भराव रखता है और उन एप्लिकेशनों से ग्रे रंग की मांग करता है जो काला‑श्वेत डिस्प्ले सेटिंग्स का सम्मान करते हैं:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सामान्य रंग मोड में, आयत अपनी नारंगी भराव रखता है। काला‑श्वेत डिस्प्ले वर्कफ़्लो में, यह ग्रे रंग दिखाता है क्योंकि उसका मोड `Gray` पर सेट है। यह आपको पूर्ण‑रंग स्लाइड को संरक्षित रखने की अनुमति देता है जबकि प्रिंटिंग, प्रीव्यू या अन्य वर्कफ़्लो के लिये अलग रूप प्रदान करता है जो प्रस्तुति की काला‑श्वेत डिस्प्ले सेटिंग्स का सम्मान करते हैं।

## **स्वरूप रीसेट करें**

[ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) का उपयोग करके स्लाइड प्लेसहोल्डर्स की स्थिति, आकार, और स्वरूपण को उनके संबंधित लेआउट प्लेसहोल्डर्स से पुनर्स्थापित करें। यह उदाहरण लेआउट‑लिंक्ड प्लेसहोल्डर्स वाली मौज़ूद प्रस्तुति की आवश्यकता रखता है और सहेजने से पहले प्रत्येक स्लाइड को रीसेट करता है। जिन आकारों के पास समकक्ष लेआउट प्लेसहोल्डर नहीं है, वे रीसेट नहीं होते।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकार फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करती है?**  
रंग, लाइन शैलियों, और प्रभाव सेटिंग्स आमतौर पर एम्बेडेड छवियों और मीडिया की तुलना में कम डेटा जोड़ते हैं। चित्र भराव फ़ाइल आकार बढ़ा सकता है क्योंकि उसकी छवियां प्रस्तुति में संग्रहीत होती हैं।

**मैं कैसे उन आकारों का पता लगा सकूँ जो एक ही स्लाइड पर समान फ़ॉर्मेटिंग साझा करते हैं ताकि मैं उन्हें समूहित कर सकूँ?**  
प्रत्येक आकार की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—भराव, लाइन, और प्रभाव सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके स्टाइल को समान मानें और उन आकारों को तर्कसंगत रूप से समूहित करें, जिससे बाद में स्टाइल प्रबंधन आसान हो जाता है।

**क्या मैं कस्टम आकार शैलियों का सेट अलग फ़ाइल में सहेज सकता हूँ ताकि अन्य प्रस्तुतियों में पुन: उपयोग किया जा सके?**  
हाँ। वांछित शैलियों वाले नमूना आकारों को टेम्प्लेट स्लाइड डेक या .POTX टेम्प्लेट फ़ाइल में संग्रहीत करें। नई प्रस्तुति बनाते समय टेम्प्लेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो उनका फ़ॉर्मेटिंग पुनः लागू करें।