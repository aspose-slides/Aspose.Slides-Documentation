---
title: जावा का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- प्रतिकृति प्रभाव
- चमक प्रभाव
- नरम किनारों का प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके उन्नत आकार प्रभावों के साथ अपनी PPT और PPTX फ़ाइलों को रूपांतरित करें—सेकंडों में प्रभावी, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जब PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जाता है, तो वे [भरण](/slides/hi/java/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर प्रभावी प्रतिबिंब बना सकते हैं, आकार की चमक फैला सकते हैं, आदि।

![आकार प्रभाव](shape-effect.png)

PowerPoint आकारों पर लागू की जा सकने वाले छह प्रभाव प्रदान करता है। आप एक या अधिक प्रभाव एक आकार पर लागू कर सकते हैं।

कुछ प्रभाव संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इस कारण, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के ऐसे संयोजन हैं जिन्हें अच्छा माना जाता है। इस प्रकार, एक Preset चुनकर, आपको विभिन्न प्रभावों को परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides प्रॉपर्टीज़ और मेथड्स [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) क्लास के तहत प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर वही प्रभाव लागू करने की अनुमति देते हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Java आकारों के लिए बाहरी और आन्तरिक छाया का समर्थन करता है। आप उनका रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिज़ाइन के अनुरूप अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

बाहरी छाया का उपयोग करके कार्ड या पैनल को स्लाइड पृष्ठभूमि के विरुद्ध प्रमुख बनाएं। छाया आकार के किनारों से बाहर तक विस्तारित होती है, जिससे आकार स्लाइड से उठी हुई दिखती है। इसे अपने टेम्पलेट की रोशनी और शैली से मेल रखने के लिए रंग, दिशा, दूरी और ब्लर त्रिज्या समायोजित करें।

यह Java कोड दिखाता है कि कैसे आयत पर [outer shadow effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) लागू किया जाए:

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

### **आन्तरिक छाया लागू करें**

टेम्पलेट की दृश्य शैली को दोहराते समय, कार्ड या पैनल को गहरा करने के लिए आन्तरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर विस्तार करती है और इसे उठी हुई दिखाती है, जबकि आन्तरिक छाया किनारों के अंदर छाया डालती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) द्वारा वापस मिलने वाली छाया को कॉन्फ़िगर करें। बड़े ब्लर त्रिज्या मान नरम किनारे उत्पन्न करते हैं।

यह Java उदाहरण हल्के नीले कार्ड को गहरे ग्रे आन्तरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री है, दूरी 7 पॉइंट, और ब्लर त्रिज्या 6 पॉइंट है:

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

![आन्तरिक छाया के साथ हल्का नीला आयत](inner_shadow_effect.png)

आन्तरिक छाया को हटाने के लिए, आकार के effect format पर [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) को कॉल करें।

### **Preset छाया लागू करें, बदलें और हटाएँ**

[enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) को कॉल करें और [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) का उपयोग करके एक [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) चुनें। शैली बदलने के लिए, उसी आकार पर preset बदलें। छाया को हटाने और fill व outline को बनाए रखने के लिए [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) को कॉल करें।

यह उदाहरण एक ही स्लाइड पर चार चरणों को साइड बाय साइड दिखाता है। दोनों छायाएँ 10 पॉइंट से ऑफ़सेट हैं। 225° दिशा पहली छाया को आयत के ऊपर और बाएँ रखती है, और 45° दिशा दूसरी छाया को नीचे और दाएँ रखती है।

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

| मूल | पहला Preset | दूसरा Preset | हटाने के बाद |
| :---: | :---: | :---: | :---: |
| ![कोई छाया नहीं](preset_shadow_original.png) | ![ऊपर बाएँ ड्रॉप छाया](preset_shadow_top_left.png) | ![नीचे दाएँ ड्रॉप छाया](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **प्रतिकृति प्रभाव लागू करें**

Aspose.Slides for Java में प्रतिकृति प्रभाव लागू करने के लिए, आप आकारों में दर्पण जैसी प्रतिकृति जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, आकारों को अधिक परिष्कृत रूप देता है। इसे सरल कोड के साथ लागू करना आसान है, जिससे कई तत्वों में तेज़ी से समान डिज़ाइन लागू किया जा सकता है।

यह Java कोड दिखाता है कि कैसे एक आकार पर [reflection effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) लागू किया जाए:

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

![प्रतिकृति प्रभाव](reflection_effect.png)

## **Glow प्रभाव लागू करें**

Aspose.Slides for Java में आकार पर glow प्रभाव लागू करने के लिए, आप आकारों के चारों ओर एक नरम, चमकदार आभा जोड़ सकते हैं, रंग और आकार जैसी प्रॉपर्टीज़ समायोजित कर सकते हैं। यह प्रभाव आकारों को प्रमुख बनाता है और आपके प्रस्तुति में आकर्षक दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे स्लाइड्स की समग्र दिखावट सुधरती है।

यह Java कोड दिखाता है कि कैसे एक आकार पर [glow effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) लागू किया जाए:

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

![Glow प्रभाव](glow_effect.png)

## **Soft Edges प्रभाव लागू करें**

Aspose.Slides for Java में soft edges प्रभाव लागू करने के लिए, आप आकार के किनारों के चारों ओर एक सुगम, ब्लर ट्रांज़िशन बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत दिखावट जोड़ता है, जो हल्की, मुलायम उपस्थिति की आवश्यकता वाले डिज़ाइन के लिए उपयुक्त है। आप विभिन्न आकारों में वांछित प्रभाव प्राप्त करने के लिए radius जैसी पैरामीटर आसानी से समायोजित कर सकते हैं।

यह Java कोड दिखाता है कि कैसे एक आकार पर [soft edges effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) लागू किया जाए:

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

![Soft edges प्रभाव](soft_edges_effect.png)

## **Blur प्रभाव लागू करें**

shape blur का उपयोग करके आप आकार की fill और outline को नरम कर सकते हैं जबकि आकार को संपादित योग्य बनाए रख सकते हैं। shape के effect format पर [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को कॉल करें। त्रिज्या पॉइंट में मापी जाती है (1/72 इंच): एक गैर-नकारात्मक मान उपयोग करें, बड़ी मान अधिक तीव्र ब्लर उत्पन्न करेंगे। शून्य त्रिज्या से उपस्थिति अपरिवर्तित रहती है।

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) सेटिंग प्रभाव की दिखाई देने वाली सीमाओं को नियंत्रित करती है। `false` होने पर, ब्लर मूल पेंटेड सीमा तक सीमित रहता है, जिसमें outline भी शामिल है। `true` होने पर, ब्लर उन सीमाओं से परे विस्तार कर सकता है। कोई भी सेटिंग आकार की स्थिति या आयामों को नहीं बदलती।

नीचे की तुलना में पूरे समय समान fill, outline और आकार आयाम उपयोग किए गए हैं। शीर्ष पंक्तियों में `grow = false` है; नीचे की पंक्तियों में `grow = true` है।

![मूल आयत की तुलना 5 और 15 पॉइंट ब्लर त्रिज्या के साथ, grow अक्षम और सक्षम](shape_blur_comparison.png)

यह Java उदाहरण नारंगी आयत को डार्क ब्लू outline के साथ बनाता है, 5-पॉइंट blur लागू करता है, फिर फिर से [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को कॉल करके 15-पॉइंट blur में अपडेट करता है। यह दोनों blur स्थिति सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) को कॉल करके blur के बिना आकार को सहेजता है।

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

Shape blur fill और outline को साथ में प्रभावित करता है। Soft edges प्रभाव आकार के किनारों को फीका करता है, जबकि shadow blur केवल छाया को नरम करता है। Image transformation प्रभाव छवि सामग्री पर कार्य करते हैं; यह उदाहरण shape को image में बदलें बिना सीधे shape के effect format पर blur लागू करता है।

## **FAQ**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप विभिन्न प्रभावों जैसे shadow, reflection, और glow को एक ही आकार पर संयोजित करके अधिक गतिशील उपस्थिति बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप autoshapes, charts, tables, pictures, SmartArt objects, OLE objects, और अधिक सहित विभिन्न आकारों पर प्रभाव लागू कर सकते हैं।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।