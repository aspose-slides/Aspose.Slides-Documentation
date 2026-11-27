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
- ग्लो प्रभाव
- सॉफ्ट एजेज़ प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- पावरपॉइंट
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके अपने PPT और PPTX फ़ाइलों को उन्नत आकार प्रभावों के साथ बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, लेकिन वे [भरण](/slides/hi/androidjava/shape-formatting/#gradient-fill) या रूपरेखा से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक को फैला सकते हैं, आदि।

![आकार प्रभाव](shape-effect.png)

PowerPoint आकारों पर लागू किए जा सकने वाले छह प्रभाव प्रदान करता है। आप एक आकार पर एक या अधिक प्रभाव लागू कर सकते हैं।

कुछ प्रभाव संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के संयोजन होते हैं जो अच्छी दिखने के लिए ज्ञात हैं। इस प्रकार, एक Preset को चुनकर, आपको विभिन्न प्रभावों को परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) वर्ग के अंतर्गत गुण और विधियां प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की अनुमति देती हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Android via Java आकारों के लिए बाहरी और आंतरिक छायाएं समर्थित करता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिजाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

बाहरी छाया का उपयोग करके आप एक कार्ड या पैनल को स्लाइड पृष्ठभूमि से प्रमुख बना सकते हैं। छाया आकार की किनारों से आगे तक बढ़ती है, जिससे ऐसा प्रतीत होता है कि आकार स्लाइड से उठाया गया है। अपने टेम्पलेट की प्रकाश व्यवस्था और शैली के अनुसार रंग, दिशा, दूरी और ब्लर त्रिज्या को समायोजित करें।

यह Java कोड दिखाता है कि कैसे [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) को एक आयत में लागू किया जाए:

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

![छाया प्रभाव](shadow_effect.png)

#### **जब आकार घुमाया जाता है तो छाया की दिशा नियंत्रित करें**

डिफ़ॉल्ट रूप से, बाहरी छाया आकार के साथ घूमती है। विभिन्न घूर्णन वाले आकारों को समान दिशा से प्रकाशित दिखाने के लिए, [setRotateShadowWithShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) को `false` के साथ कॉल करें और [setDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setDirection-float-) का उपयोग करके उनकी छायाओं को समान दिशा दें।

यह उदाहरण दो नीले तीर बनाता है जिनकी धूसर छायाएँ 42 पॉइंट दाईं ओर (0°) ऑफसेट हैं। फिर यह स्लाइड को डुप्लिकेट करता है और दोनों तीरों को 90° घड़ी की दिशा में घुमाता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(128, 128, 128));
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

दूसरी स्लाइड पर, बायाँ तीर अपनी छाया नीचे की ओर डालता है, जबकि दायाँ तीर अभी भी अपनी छाया दाएँ की ओर डालता है। दोनों छायाओं के लिये कॉन्फ़िगर की गई दिशा 0° बनी रहती है।

![90° घूर्णन से पहले और बाद में PowerPoint रेंडरिंग। दोनों छायाएँ दाएँ से शुरू होती हैं। घूर्णन के बाद, बाएँ तीर के नीचे छाया आती है और दाएँ तीर के दाएँ बनी रहती है।](arrow-shadow-rotation.png)

### **आंतरिक छाया लागू करें**

जब किसी टेम्पलेट की दृश्य शैली को दोहराते हैं, तो आंतरिक छाया का उपयोग करके कार्ड या पैनल को एक गहरी हुई उपस्थिति दी जा सकती है। बाहरी छाया आकार के बाहर विस्तारित होती है, जबकि आंतरिक छाया इसके किनारों के अंदर छाया डालती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) द्वारा लौटाए गए छाया को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान नरम किनारे प्रदान करते हैं।

यह Java उदाहरण एक हल्के नीले कार्ड को गहरे धूसर आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री है, दूरी 7 पॉइंट है, और ब्लर त्रिज्या 6 पॉइंट है:

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

आंतरिक छाया को हटाने के लिए, आकार के प्रभाव फ़ॉर्मेट पर [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) को कॉल करें।

### **Preset छाया लागू करें, बदलें और हटाएं**

[enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) को कॉल करें और [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) का उपयोग करके एक [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/) चुनें। शैली बदलने के लिए, उसी आकार पर प्रीसेट बदलें। छाया को हटाने के लिये [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) को कॉल करें, जिससे भराव और रूपरेखा बनी रहती है।

यह उदाहरण एक स्लाइड पर चार चरणों को साथ-साथ दिखाता है। दोनों छायाएँ 10 पॉइंट ऑफसेट हैं। 225° दिशा पहली छाया को आयत के ऊपर और बाएँ रखती है, और 45° दिशा दूसरी छाया को नीचे और दाएँ रखती है।

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
| ![कोई छाया नहीं](preset_shadow_original.png) | ![ऊपरी बायां ड्रॉप छाया](preset_shadow_top_left.png) | ![नीचा दायां ड्रॉप छाया](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **परावर्तन प्रभाव लागू करें**

Aspose.Slides for Android via Java में परावर्तन प्रभाव लागू करने के लिए, आप आकारों में दर्पण जैसी परावर्तन जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को बेहतर बनाता है, आकारों को अधिक परिष्कृत और सुगम दिखाता है। इसे सरल कोड के साथ लागू किया जा सकता है, जिससे कई तत्वों में निरंतर डिजाइन के लिए तेज़ी से लागू किया जा सके।

यह Java कोड दिखाता है कि कैसे [परावर्तन प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) को एक आकार पर लागू किया जाए:

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

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for Android via Java में एक आकार पर ग्लो प्रभाव लागू करने के लिए, आप आकारों के चारों ओर एक मुलायम, चमकदार आभा जोड़ सकते हैं, रंग और आकार जैसी विशेषताओं को समायोजित कर सकते हैं। यह प्रभाव आकारों को प्रमुख बनाता है और आपके प्रस्तुति में एक आकर्षक दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड के साथ आसानी से लागू किया जा सकता है, जिससे स्लाइड्स की समग्र लुक बेहतर बनती है।

यह Java कोड दिखाता है कि कैसे [ग्लो प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) को एक आकार पर लागू किया जाए:

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

![ग्लो प्रभाव](glow_effect.png)

## **सॉफ़्ट एजेज़ प्रभाव लागू करें**

Aspose.Slides for Android via Java में सॉफ़्ट एजेज़ प्रभाव लागू करने के लिए, आप आकार के किनारों के आसपास एक स्मूद, ब्लर ट्रांज़िशन बना सकते हैं। यह प्रभाव एक कोमल और परिष्कृत लुक देता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिनमें नाजुक, नरम उपस्थिति चाहिए। आप आसानी से त्रिज्या जैसे पैरामीटर समायोजित करके विभिन्न आकारों में वांछित प्रभाव प्राप्त कर सकते हैं।

यह Java कोड दिखाता है कि कैसे [सॉफ़्ट एजेज़ प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) को एक आकार पर लागू किया जाए:

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

आकार ब्लर का उपयोग करके आप आकार की भरावट और रूपरेखा को नरम बना सकते हैं, जबकि आकार को संपादन योग्य रखते हैं। आकार के प्रभाव फ़ॉर्मेट पर [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को कॉल करें। त्रिज्या पॉइंट में मापी जाती है (1/72 इंच): गैर-नकारात्मक मान उपयोग करें, बड़ी मान अधिक तेज़ ब्लर देते हैं। शून्य त्रिज्या का अर्थ रूप नहीं बदला गया है।

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `false` के साथ, ब्लर मूल चित्रित सीमा, जिसमें रूपरेखा शामिल है, तक सीमित रहता है। `true` के साथ, ब्लर उन सीमाओं से बाहर तक विस्तारित हो सकता है। कोई भी सेटिंग आकार की स्थिति या आयामों को नहीं बदलती।

नीचे दिया गया तुलना समान भराव, रूपरेखा और आकार आयामों का उपयोग करता है। शीर्ष पंक्ति में `grow = false` है; नीचे की पंक्ति में `grow = true` है।

![5 और 15 पॉइंट ब्लर त्रिज्या के साथ मूल आयत, grow अक्षम और सक्षम के साथ तुलना](shape_blur_comparison.png)

यह Java उदाहरण एक नारंगी आयत को गहरे नीले रूपरेखा के साथ बनाता है, 5 पॉइंट ब्लर लागू करता है, और फिर [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को फिर से कॉल करके इसे 15 पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर स्थितियों को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) को कॉल करता है और ब्लर के बिना आकार को सहेजता है।

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

आकार ब्लर भराव और रूपरेखा दोनों को एक साथ प्रभावित करता है। सॉफ़्ट एजेज़ प्रभाव आकार के किनारों को धुंधला करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। इमेज ट्रांसफ़ॉर्मेशन प्रभाव इमेज सामग्री पर काम करते हैं; यह उदाहरण आकार को इमेज में बदलें बिना सीधे आकार के प्रभाव फ़ॉर्मेट पर ब्लर लागू करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर एक से अधिक प्रभाव लागू कर सकता हूँ?**

हाँ, आप विभिन्न प्रभावों को, जैसे छाया, परावर्तन और ग्लो, एक ही आकार पर संयोजित करके अधिक गतिशील उपस्थिति बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटोषेप्स, चार्ट, टेबल, चित्र, स्मार्टआर्ट ऑब्जेक्ट्स, OLE ऑब्जेक्ट्स और अन्य शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।