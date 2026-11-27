---
title: जावा का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- चमक प्रभाव
- नरम किनारा प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकृति को उभारा बनाने के लिए किया जा सकता है, लेकिन ये [भरण](/slides/hi/java/shape-formatting/#gradient-fill) या रूपरेखा से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकृति पर विश्वसनीय परावर्तन, आकृति की चमक आदि बना सकते हैं।

![शेप प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकृतियों पर लागू किया जा सकता है। आप किसी आकृति पर एक या अधिक प्रभाव लागू कर सकते हैं।

कुछ प्रभाव संयोजन अन्य की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के ऐसे संयोजन हैं जो अच्छे दिखने के लिए ज्ञात हैं। इस प्रकार, एक प्रीसेट चुनकर आपको विभिन्न प्रभावों को परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) क्लास में प्रॉपर्टीज़ और मेथड्स प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकृतियों पर समान प्रभाव लागू करने की अनुमति देता है।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Java आकृतियों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिजाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

एक बाहरी छाया का उपयोग करके कार्ड या पैनल को स्लाइड पृष्ठभूमि से उभारा जा सकता है। छाया आकृति की किनारों से बाहर तक बढ़ती है, जिससे ऐसा प्रभाव मिलता है कि आकृति स्लाइड से ऊपर उठी हुई है। अपने टेम्पलेट की रोशनी और शैली के अनुसार इसके रंग, दिशा, दूरी और ब्लर त्रिज्या को समायोजित करें।

यह Java कोड दिखाता है कि कैसे किसी आयत पर [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) लागू किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![छाया प्रभाव](shadow_effect.png)

#### **जब आकृति घुमती है तो छाया दिशा को नियंत्रित करें**

डिफ़ॉल्ट रूप से, बाहरी छाया आकृति के साथ घुमती है। विभिन्न घुमावों वाली आकृतियों को समान दिशा से प्रकाशित दिखाने के लिए, `false` के साथ [setRotateShadowWithShape](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) को कॉल करें और उनके छायाओं को समान दिशा देने के लिए [setDirection](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setDirection-float-) का उपयोग करें।

उदाहरण दो नीले तीर बनाता है जिनके धूसर छाया 42 पॉइंट दाईं ओर (0°) ऑफ़सेट है। फिर स्लाइड को डुप्लिकेट करके दोनों तीरों को 90° घड़ी की दिशा में घुमाया जाता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.GRAY);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

दूसरी स्लाइड पर, बायें तीर की छाया नीचे की ओर गिरती है, जबकि दायें तीर की छाया अभी भी दाईं ओर रहती है। दोनों छायाओं की कॉन्फ़िगर की गई दिशा 0° बनी रहती है।

![PowerPoint rendering before and after a 90° rotation. Both shadows start on the right. After rotation, the shadow moves below the left arrow and stays to the right of the right arrow.](arrow-shadow-rotation.png)

### **आंतरिक छाया लागू करें**

टेम्पलेट की दृश्य शैली को पुन: प्रस्तुत करने के समय, एक कार्ड या पैनल को समेकित रूप देने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकृति के बाहर विस्तार करती है और इसे उठे हुए दिखाती है, जबकि आंतरिक छाया उसके किनारों के अंदर हिस्से को शेड करती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) द्वारा लौटाई गई छाया को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान नरम किनारे उत्पन्न करती हैं।

यह Java उदाहरण एक हल्के नीले कार्ड को गहरे धूसर आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री, दूरी 7 पॉइंट, और ब्लर त्रिज्या 6 पॉइंट है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

आंतरिक छाया हटाने के लिए, आकृति के इफ़ेक्ट फ़ॉर्मेट पर [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) को कॉल करें।

### **प्रीसेट छाया लागू करें, बदलें और हटाएँ**

[enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) को कॉल करें और [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) का उपयोग करके किसी [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) को चुनें। शैली बदलने के लिए, उसी आकृति पर प्रीसेट बदलें। छाया को हटाने और भराव व रूपरेखा को बनाए रखने के लिए [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) को कॉल करें।

यह उदाहरण एक स्लाइड पर चार चरणों को बगल में दिखाता है। दोनों छायाएँ 10 पॉइंट ऑफ़सेट हैं। 225° की दिशा पहला छाया आयत के ऊपर और बाएँ रखती है, जबकि 45° की दिशा दूसरा नीचे और दाएँ रखती है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| मूल | पहला प्रीसेट | दूसरा प्रीसेट | हटाने के बाद |
| :---: | :---: | :---: | :---: |
| ![कोई छाया नहीं](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **परावर्तन प्रभाव लागू करें**

Aspose.Slides for Java में परावर्तन प्रभाव लागू करने के लिए, आप आकृतियों पर दर्पण जैसी परावर्तन जोड़ सकते हैं और दूरी, पारदर्शिता और आकार जैसे पैरामीटर को समायोजित कर सकते हैं। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, जिससे आकृतियों को अधिक पॉलिश्ड और परिष्कृत लुक मिलता है। इसे सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर सुसंगत डिजाइन के लिए तेज़ी से लागू किया जा सके।

यह Java कोड दिखाता है कि कैसे किसी आकृति पर [परावर्तन प्रभाव](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) लागू किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![परावर्तन प्रभाव](reflection_effect.png)

## **चमक प्रभाव लागू करें**

Aspose.Slides for Java में किसी आकृति पर चमक प्रभाव लागू करने के लिए, आप आकृति के चारों ओर एक नरम, उज्ज्वल आभा जोड़ सकते हैं, और रंग तथा आकार जैसे गुणों को समायोजित कर सकते हैं। यह प्रभाव आकृतियों को प्रमुख बनाता है और आपकी प्रस्तुति में आकर्षक दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड के साथ आसानी से लागू किया जा सकता है, जिससे आपके स्लाइड्स की कुल मिलाकर सुंदरता बढ़ती है।

यह Java कोड दिखाता है कि कैसे किसी आकृति पर [चमक प्रभाव](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) लागू किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![चमक प्रभाव](glow_effect.png)

## **सॉफ़्ट एजेज़ प्रभाव लागू करें**

Aspose.Slides for Java में सॉफ़्ट एजेज़ प्रभाव लागू करने के लिए, आप किसी आकृति के किनारों के आसपास एक स्मूद, धुंधला संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिन्हें एक कोमल, नरम स्वरूप चाहिए। आप विभिन्न आकृतियों में वांछित प्रभाव प्राप्त करने के लिए त्रिज्या जैसे पैरामीटर को आसानी से समायोजित कर सकते हैं।

यह Java कोड दिखाता है कि कैसे किसी आकृति पर [सॉफ़्ट एजेज़ प्रभाव](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) लागू किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![सॉफ़्ट एजेज़ प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

आकृति ब्लर का उपयोग करके आप आकृति की भराव और रूपरेखा को नरम बना सकते हैं जबकि आकृति को संपादन योग्य रख सकते हैं। आकृति के इफ़ेक्ट फ़ॉर्मेट पर [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को कॉल करें। त्रिज्या पॉइंट में मापी जाती है (1/72 इंच): एक गैर-नकारात्मक मान का उपयोग करें, बड़ी मान अधिक तीव्र ब्लर उत्पन्न करते हैं। शून्य त्रिज्या होने पर रूप बदलता नहीं है।

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `false` होने पर, ब्लर मूल पेंट किए गए सीमा में कट जाता है, जिसमें रूपरेखा भी शामिल है। `true` होने पर, ब्लर उन सीमाओं से परे भी विस्तारित हो सकता है। न तो स्थिति बदलती है और न ही आकार।

नीचे दिया गया तुलना समान भराव, रूपरेखा और आकृति आयामों के साथ किया गया है। ऊपर की पंक्ति में `grow = false` है; नीचे की पंक्ति में `grow = true` है।

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

यह Java उदाहरण एक नारंगी आयत बनाता है जिसमें गहरा नीला रूपरेखा है, 5 पॉइंट ब्लर लागू करता है, फिर फिर से [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को कॉल करके 15 पॉइंट ब्लर में अपडेट करता है। दोनों ब्लर किए हुए अवस्थाओं को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) को कॉल करके ब्लर के बिना आकृति को सहेजता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आकृति ब्लर भराव और रूपरेखा को एक साथ प्रभावित करता है। सॉफ़्ट एजेज़ प्रभाव आकृति के किनारों को धुंधला करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। इमेज ट्रांसफ़ॉर्मेशन प्रभाव इमेज सामग्री पर काम करते हैं; यह उदाहरण आकृति को इमेज में बदलें बिना सीधे उसके इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकृति पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकृति पर विभिन्न प्रभाव, जैसे छाया, परावर्तन और चमक, को संयोजित कर अधिक गतिशील रूप प्राप्त कर सकते हैं।

**मैं किन आकृतियों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न प्रकार की आकृतियों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटोशेप, चार्ट, तालिका, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट आदि शामिल हैं।

**क्या मैं समूहबद्ध आकृतियों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहबद्ध आकृतियों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।