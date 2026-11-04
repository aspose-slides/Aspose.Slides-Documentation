---
title: Android पर प्रस्तुतियों में आकृति प्रभाव लागू करें
linktitle: आकृति प्रभाव
type: docs
weight: 30
url: /hi/androidjava/shape-effect/
keywords:
- आकृति प्रभाव
- छाया प्रभाव
- प्रतिबिंब प्रभाव
- ग्लो प्रभाव
- नरम किनारे प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके उन्नत आकृति प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकंड में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकृति को प्रमुख बनाने के लिए किया जा सकता है, लेकिन ये [भराव](/slides/hi/androidjava/shape-formatting/#gradient-fill) या आउटलाइन से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप आकृति पर प्रभावी प्रतिबिंब बना सकते हैं, आकृति की चमक फैला सकते हैं, आदि।

![आकार प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जो आकृतियों पर लागू किए जा सकते हैं। आप किसी आकृति पर एक या अधिक प्रभाव लागू कर सकते हैं।

कुछ प्रभाव संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के संयोजन हैं जो अच्छी दिखावट वाले माने जाते हैं। इस तरह, एक प्रीसेट चुनकर, आपको विभिन्न प्रभावों को परीक्षण या संयोजन करने में समय बरबाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) क्लास के तहत प्रॉपर्टीज़ और मेथड्स प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकृतियों पर समान प्रभाव लागू करने की अनुमति देते हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Android via Java आकृतियों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप उनके रंग, दिशा, दूरी, और ब्लर त्रिज्या को अपनी प्रस्तुति के डिजाइन के अनुसार कस्टमाइज़ कर सकते हैं।

### **बाहरी छाया लागू करें**

स्लाइड पृष्ठभूमि के खिलाफ कार्ड या पैनल को प्रमुख बनाने के लिए बाहरी छाया का उपयोग करें। छाया आकृति के किनारों से परे फैलती है, जिससे यह प्रभाव पैदा होता है कि आकृति स्लाइड के ऊपर उठी हुई है। इसे अपने टेम्पलेट की रोशनी और शैली के अनुसार रंग, दिशा, दूरी, और ब्लर त्रिज्या को समायोजित करें।

यह Java कोड दिखाता है कि कैसे एक आयत पर [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) लागू किया जाए:

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

### **आंतरिक छाया लागू करें**

जब टेम्पलेट की दृश्य शैली को दोहराते हैं, तो कार्ड या पैनल को गहरा दिखने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकृति के बाहर विस्तारित होती है और इसे उठी हुई बनाती है, जबकि आंतरिक छाया इसके किनारों के अंदर छायादार बनाती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) द्वारा लौटाए गए छाया को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान नरम किनारे उत्पन्न करते हैं।

यह Java उदाहरण हल्के नीले कार्ड को गहरे ग्रे आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री है, उसकी दूरी 7 पॉइंट है, और उसकी ब्लर त्रिज्या 6 पॉइंट है:

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

आंतरिक छाया को हटाने के लिए, shape के effect format पर [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) को कॉल करें।

## **प्रतिबिंब प्रभाव लागू करें**

Aspose.Slides for Android via Java में प्रतिबिंब प्रभाव लागू करने के लिए, आप आकृतियों में दर्पण जैसे प्रतिबिंब जोड़ सकते हैं, दूरी, पारदर्शिता, और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह प्रभाव आपकी प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, जिससे आकृतियों को अधिक परिष्कृत और सुसंस्कृत लुक मिलता है। इसे सरल कोड के साथ लागू करना आसान है, जिससे कई तत्वों में शीघ्र और समान डिज़ाइन के लिए लागू किया जा सके।

यह Java कोड दिखाता है कि कैसे एक आकृति पर [प्रतिबिंब प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) लागू किया जाए:

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

![प्रतिबिंब प्रभाव](reflection_effect.png)

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for Android via Java में एक आकृति पर ग्लो प्रभाव लागू करने के लिए, आप आकृतियों के चारों ओर एक मुलायम, चमकदार आभा जोड़ सकते हैं, रंग और आकार जैसी प्रॉपर्टीज़ को समायोजित कर सकते हैं। यह प्रभाव आकृतियों को प्रमुख बनाता है और आपकी प्रस्तुति में एक आकर्षक, नेत्रसुखद दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे आपके स्लाइड्स की समग्र उपस्थिति सुधरती है।

यह Java कोड दिखाता है कि कैसे एक आकृति पर [ग्लो प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) लागू किया जाए:

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

## **नरम किनारे प्रभाव लागू करें**

Aspose.Slides for Android via Java में नरम किनारे प्रभाव लागू करने के लिए, आप आकृति के किनारों के आसपास एक सुगम, धुंधला संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत दिखावट जोड़ता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिन्हें नरम, कोमल उपस्थिति चाहिए। आप अपने प्रस्तुति में विभिन्न आकृतियों पर वांछित प्रभाव प्राप्त करने के लिए त्रिज्या जैसी पैरामीटर आसानी से समायोजित कर सकते हैं।

यह Java कोड दिखाता है कि कैसे एक आकृति पर [नरम किनारे प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) लागू किया जाए:

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

![नरम किनारे प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

आकृति ब्लर का उपयोग करके आप आकृति के भराव और आउटलाइन को मुलायम बना सकते हैं जबकि आकृति को संपादन योग्य रख सकते हैं। आकृति के effect format पर [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को कॉल करें। त्रिज्या पॉइंट में मापी जाती है (1/72 इंच): एक अपरिवर्तित मान उपयोग करें, बड़े मान अधिक तीव्र ब्लर बनाते हैं। शून्य त्रिज्या से उपस्थिति अपरिवर्तित रहती है।

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) सेटिंग प्रभाव की दृश्य सीमाओं को नियंत्रित करती है। `false` होने पर, ब्लर मूल पेंट की गई सीमाओं, जिसमें आउटलाइन शामिल है, तक ही सीमित रहता है। `true` होने पर, ब्लर उन सीमाओं से परे भी विस्तारित हो सकता है। इन सेटिंग्स में से कोई भी आकृति की स्थिति या आयाम नहीं बदलती।

नीचे का तुलना समान भराव, आउटलाइन और आकृति के आयामों का उपयोग करता है। शीर्ष पंक्ति `grow = false` का उपयोग करती है; नीचे की पंक्ति `grow = true` का उपयोग करती है।

![मूल आयत तुलना ब्लर त्रिज्या 5 और 15 पॉइंट के साथ, grow अक्षम और सक्षम](shape_blur_comparison.png)

यह Java उदाहरण एक नारंगी आयत को गहरे नीले आउटलाइन के साथ बनाता है, 5-पॉइंट ब्लर लागू करता है, और फिर [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को फिर से कॉल करके इसे 15-पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर स्थितियों को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) को कॉल करके ब्लर के बिना आकृति को सहेजता है।

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

आकृति ब्लर भराव और आउटलाइन दोनों को प्रभावित करता है। नरम किनारे प्रभाव आकृति के किनारों को फीका करता है, जबकि शैडो ब्लर केवल छाया को मुलायम करता है। इमेज ट्रांसफ़ॉर्मेशन प्रभाव इमेज सामग्री पर लागू होते हैं; यह उदाहरण ब्लर को सीधे आकृति के effect format पर लागू करता है बिना आकृति को इमेज में बदलें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकृति पर कई प्रभाव लागू कर सकता हूँ?**

हां, आप छाया, प्रतिबिंब, और ग्लो जैसे विभिन्न प्रभावों को एक ही आकृति पर संयोजित करके अधिक गतिशील उपस्थिति बना सकते हैं।

**मैं कौन-कौन सी आकृतियों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकृतियों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटोशेप्स, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट्स, OLE ऑब्जेक्ट्स, आदि शामिल हैं।

**क्या मैं समूहित आकृतियों पर प्रभाव लागू कर सकता हूँ?**

हां, आप समूहित आकृतियों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।