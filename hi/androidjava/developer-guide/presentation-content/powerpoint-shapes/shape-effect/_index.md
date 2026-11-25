---
title: एंड्रॉइड पर प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/androidjava/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- प्रतिबिंब प्रभाव
- चमक प्रभाव
- नरम किनारे प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकंडों में आकर्षक, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

PowerPoint में इफ़ेक्ट्स का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, लेकिन वे [भरण](/slides/hi/androidjava/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint इफ़ेक्ट्स का उपयोग करके आप आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैलाए आदि।

![आकार प्रभाव](shape-effect.png)

PowerPoint में छह इफ़ेक्ट्स उपलब्ध हैं जिन्हें आकारों पर लागू किया जा सकता है। आप किसी आकार पर एक या अधिक इफ़ेक्ट्स लागू कर सकते हैं।

कुछ इफ़ेक्ट संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक इफ़ेक्ट्स के ऐसे संयोजन हैं जो अच्छा दिखने के लिए ज्ञात हैं। इस तरह, एक प्रीसेट चुनकर आपको उचित संयोजन खोजने के लिए विभिन्न इफ़ेक्ट्स को आज़माने या मिलाने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides के पास [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) वर्ग के तहत प्रॉपर्टीज़ और मेथड्स हैं जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान इफ़ेक्ट्स लागू करने की अनुमति देते हैं।

## **छाया इफ़ेक्ट लागू करें**

Aspose.Slides for Android via Java आकारों के लिए बाहरी और आंतरिक छायाएं समर्थन करता है। आप इनके रंग, दिशा, दूरी और ब्लर रेडियस को अपनी प्रस्तुति के डिजाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

स्लाइड बैकग्राउंड के विरुद्ध कार्ड या पैनल को प्रमुख बनाने के लिए बाहरी छाया का उपयोग करें। छाया आकार के किनारों से बाहर तक विस्तारित होती है, जिससे ऐसा प्रभाव मिलता है कि आकार स्लाइड से ऊपर उठा हुआ है। इसके रंग, दिशा, दूरी और ब्लर रेडियस को अपने टेम्पलेट की रोशनी और स्टाइलिंग के अनुसार समायोजित करें।

यह Java कोड दिखाता है कि कैसे एक आयत पर [बाहरी छाया इफ़ेक्ट](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) लागू किया जाए:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![छाया इफ़ेक्ट](shadow_effect.png)

### **आंतरिक छाया लागू करें**

जब टेम्पलेट की दृश्य शैली को दोहराते हैं, तो कार्ड या पैनल को गहराई वाला रूप देने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर विस्तारित होती है और इसे उठे हुए दिखाती है, जबकि आंतरिक छाया इसके किनारों के अंदर को शेड देती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) द्वारा प्राप्त छाया को कॉन्फ़िगर करें। बड़े ब्लर रेडियस मान नरम किनारे उत्पन्न करते हैं।

यह Java उदाहरण हल्के नीले कार्ड को गहरे ग्रे आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री है, दूरी 7 पॉइंट है, और ब्लर रेडियस 6 पॉइंट है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![आंतरिक छाया के साथ हल्का नीला आयत](inner_shadow_effect.png)

आंतरिक छाया को हटाने के लिए, आकार के इफ़ेक्ट फ़ॉर्मेट पर [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) को कॉल करें।

### **प्रिसेट छाया लागू करें, बदलें और हटाएं**

[enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) को कॉल करें और [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) का उपयोग करके एक [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/) चुनें। शैली बदलने के लिए, एक ही आकार पर प्रिसेट बदलें। छाया को हटाने के लिए जबकि भराव और रूपरेखा को बनाए रखते हुए, [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) को कॉल करें।

यह उदाहरण एक स्लाइड पर चार चरणों को एक साथ दिखाता है। दोनों छायाओं का ऑफ़सेट 10 पॉइंट है। 225° दिशा पहला छाया आयत के ऊपर और बाएँ रखती है, और 45° दिशा दूसरा छाया नीचे और दाएँ रखती है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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
| ![कोई छाया नहीं](preset_shadow_original.png) | ![ऊपर-बाएँ ड्रॉप शैडो](preset_shadow_top_left.png) | ![नीचे-दाएँ ड्रॉप शैडो](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **प्रतिबिंब इफ़ेक्ट लागू करें**

Aspose.Slides for Android via Java में प्रतिबिंब इफ़ेक्ट लागू करने के लिए आप आकारों में दर्पण जैसी प्रतिबिंब जोड़ सकते हैं, जिसमें दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित किए जाते हैं। यह इफ़ेक्ट आपके प्रस्तुतियों की सौंदर्य को बढ़ाता है, आकारों को अधिक polished और परिष्कृत रूप देता है। इसे सरल कोड के साथ लागू करना आसान है, जिससे कई तत्वों में तेज़ी से समान डिज़ाइन लागू किया जा सकता है।

यह Java कोड दिखाता है कि कैसे एक आकार पर [reflection effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) लागू किया जाए:

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

![प्रतिबिंब इफ़ेक्ट](reflection_effect.png)

## **ग्लो इफ़ेक्ट लागू करें**

Aspose.Slides for Android via Java में आकार पर ग्लो इफ़ेक्ट लागू करने के लिए आप आकारों के चारों ओर एक नरम, चमकदार आभा जोड़ सकते हैं, जिसमें रंग और आकार जैसी प्रॉपर्टीज़ समायोजित की जाती हैं। यह इफ़ेक्ट आकारों को प्रमुख बनाने में मदद करता है और आपकी प्रस्तुति में एक आकर्षक, ध्यान आकर्षित करने वाला दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड के साथ लागू करना आसान है, जिससे आपके स्लाइड्स की समग्र दिखावट बढ़ती है।

यह Java कोड दिखाता है कि कैसे एक आकार पर [glow effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) लागू किया जाए:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![ग्लो इफ़ेक्ट](glow_effect.png)

## **सॉफ्ट एजेज़ इफ़ेक्ट लागू करें**

Aspose.Slides for Android via Java में सॉफ्ट एजेज़ इफ़ेक्ट लागू करने के लिए आप आकार के किनारों के आसपास एक स्मूथ, ब्लर संक्रमण बना सकते हैं। यह इफ़ेक्ट एक अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, जो उन डिजाइन के लिए उपयुक्त है जिन्हें नरम, अधिक कोमल दिखावट चाहिए। आप आसानी से रेडियस जैसे पैरामीटर को समायोजित करके अपनी प्रस्तुति में विभिन्न आकारों पर वांछित प्रभाव प्राप्त कर सकते हैं।

यह Java कोड दिखाता है कि कैसे एक आकार पर [soft edges effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) लागू किया जाए:

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

![सॉफ्ट एजेज़ इफ़ेक्ट](soft_edges_effect.png)

## **ब्लर इफ़ेक्ट लागू करें**

आकार ब्लर का उपयोग करके आकार की भराव और रूपरेखा को नरम किया जा सकता है, जबकि आकार को संपादनीय रखा जाता है। आकार के इफ़ेक्ट फ़ॉर्मेट पर [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को कॉल करें। रेडियस पॉइंट्स (1/72 इंच) में मापा जाता है: एक गैर-नकारात्मक मान उपयोग करें, बड़े मान अधिक मजबूत ब्लर उत्पन्न करेंगे। शून्य रेडियस होने पर दिखावट अपरिवर्तित रहती है।

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `false` के साथ, ब्लर मूल पेंटेड सीमा तक ही सीमित रहता है, जिसमें रूपरेखा भी शामिल है। `true` के साथ, ब्लर उन सीमाओं से परे भी विस्तार कर सकता है। कोई भी सेटिंग आकार की स्थिति या आयामों को नहीं बदलती।

नीचे दिया गया तुलना समान भराव, रूपरेखा और आकार आयामों का उपयोग करता है। शीर्ष पंक्ति `grow = false` उपयोग करती है; नीचे की पंक्ति `grow = true` उपयोग करती है।

![5 और 15 पॉइंट ब्लर रेडियस के साथ मूल आयत, जिसमें grow निष्क्रिय और सक्रिय है](shape_blur_comparison.png)

यह Java उदाहरण एक नारंगी आयत को गहरे नीले रूपरेखा के साथ बनाता है, 5 पॉइंट ब्लर लागू करता है, और फिर [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को फिर से कॉल करके इसे 15 पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर स्थितियों को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) को कॉल करता है और आकार को बिना ब्लर के सहेजता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

आकार ब्लर भराव और रूपरेखा दोनों को एक साथ प्रभावित करता है। सॉफ्ट एजेज़ इफ़ेक्ट आकार के किनारों को फेड करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। इमेज ट्रांसफ़ॉर्मेशन इफ़ेक्ट्स इमेज कंटेंट पर काम करते हैं; यह उदाहरण आकार को इमेज में बदलें बिना सीधे आकार के इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर अलग-अलग इफ़ेक्ट्स, जैसे छाया, प्रतिबिंब और ग्लो, को मिलाकर अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न आकारों पर इफ़ेक्ट्स लागू कर सकते हैं, जिसमें ऑटोशेप्स, चार्ट, तालिकाएँ, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अधिक शामिल हैं।

**क्या मैं ग्रुप किए गए आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप ग्रुप किए गए आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।