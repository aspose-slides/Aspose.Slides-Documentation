---
title: Android पर प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/androidjava/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- नरम किनारे प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेंकों में आकर्षक, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जबकि PowerPoint में प्रभावों का उपयोग किसी आकार को अलग दिखाने के लिए किया जा सकता है, वे [भरण](/slides/hi/androidjava/shape-formatting/#gradient-fill) या रूपरेखाओं से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैलाएँ, आदि।

![आकार प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक या अधिक प्रभाव किसी आकार पर लागू कर सकते हैं।

कुछ प्रभाव संयोजन अन्य की तुलना में बेहतर दिखते हैं। इसलिए PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के ऐसे संयोजन होते हैं जो दिखने में अच्छे होते हैं। इस प्रकार, कोई preset चुनकर आप विभिन्न प्रभावों को परखने या संयोजित करने में समय बर्बाद नहीं करेंगे।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) क्लास के तहत गुण और विधियाँ प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की सुविधा देता है।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Android via Java आकारों के लिए बाहरी और आंतरिक छाया का समर्थन करता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुतियों के डिजाइन के अनुरूप अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

बाहरी छाया का उपयोग करके कार्ड या पैनल को स्लाइड पृष्ठभूमि के खिलाफ बाहर निकालें। छाया आकार की किनारों से बाहर तक फैली होती है, जिससे ऐसा प्रभाव पैदा होता है कि आकार स्लाइड से ऊपर उठी हुई है। अपने टेम्पलेट की प्रकाश व्यवस्था और शैली से मेल खाने के लिए रंग, दिशा, दूरी और ब्लर त्रिज्या को समायोजित करें।

यह Java कोड दिखाता है कि कैसे एक आयत में [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) लागू किया जाए:

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

टेम्पलेट की दृश्य शैली को दोहराते समय, कार्ड या पैनल को गहराई प्रदान करने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर तक विस्तृत होती है और उसे उठाया हुआ दिखाती है, जबकि आंतरिक छाया किनारों के अंदर को शेड करती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) द्वारा लौटाए गए छाया को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान नरम किनारे बनाते हैं।

यह Java उदाहरण हल्के नीले कार्ड पर गहरा ग्रे आंतरिक छाया बनाता है और उसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री, दूरी 7 पॉइंट और ब्लर त्रिज्या 6 पॉइंट है:

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

## **परावर्तन प्रभाव लागू करें**

Aspose.Slides for Android via Java में परावर्तन प्रभाव लागू करने के लिए, आप आकारों में दर्पण जैसी परावर्तन जोड़ सकते हैं, और दूरी, पारदर्शिता व आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह प्रभाव आपकी प्रस्तुतियों को अधिक परिष्कृत और आकर्षक बनाता है। सरल कोड के साथ इसे लागू करना आसान है, जिससे कई तत्वों में सुसंगत डिजाइन जल्दी प्राप्त किया जा सकता है।

यह Java कोड दिखाता है कि कैसे एक आकार में [परावर्तन प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) लागू किया जाए:

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

Aspose.Slides for Android via Java में आकार पर ग्लो प्रभाव लागू करने के लिए, आप आकार के चारों ओर एक नरम प्रकाश आभा जोड़ सकते हैं, और रंग तथा आकार जैसी विशेषताओं को समायोजित कर सकते हैं। यह प्रभाव आकार को प्रमुख बनाता है और आपकी प्रस्तुति में आकर्षक दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे स्लाइड की समग्र रूपरेखा बेहतर होती है।

यह Java कोड दिखाता है कि कैसे एक आकार में [ग्लो प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) लागू किया जाए:

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

Aspose.Slides for Android via Java में नरम किनारे प्रभाव लागू करने के लिए, आप आकार के किनारों के आसपास एक स्मूथ, धुंधला परिवर्तन बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत दिखावट जोड़ता है, जो हल्की, नरम उपस्थिति चाहिए वाले डिज़ाइनों के लिए उपयुक्त है। आप विभिन्न आकारों में इच्छित प्रभाव पाने के लिए त्रिज्या जैसी पैरामीटर आसानी से समायोजित कर सकते हैं।

यह Java कोड दिखाता है कि कैसे एक आकार में [नरम किनारे प्रभाव](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) लागू किया जाए:

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

## **FAQ**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर छाया, परावर्तन, ग्लो आदि विभिन्न प्रभावों को संयोजित करके अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिनमें ऑटॉशेप्स, चार्ट, टेबल, चित्र, SmartArt वस्तुएँ, OLE वस्तुएँ आदि शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।