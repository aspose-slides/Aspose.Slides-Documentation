---
title: जावा का उपयोग करके प्रस्तुतियों में आकार इफ़ेक्ट लागू करें
linktitle: आकार इफ़ेक्ट
type: docs
weight: 30
url: /hi/java/shape-effect/
keywords:
- आकार इफ़ेक्ट
- छाया इफ़ेक्ट
- प्रतिबिंब इफ़ेक्ट
- ग्लो इफ़ेक्ट
- नरम किनारे इफ़ेक्ट
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके उन्नत आकार इफ़ेक्ट के साथ अपनी PPT और PPTX फ़ाइलों को बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड्स बनाएँ।"
---
## **परिचय**

PowerPoint में इफ़ेक्ट्स का उपयोग किसी आकार को उभारने के लिए किया जा सकता है, लेकिन वे [भराव](/slides/hi/java/shape-formatting/#gradient-fill) या रूपरेखाएँ से अलग होते हैं। PowerPoint इफ़ेक्ट्स का प्रयोग करके आप एक आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैला सकते हैं, आदि।

![आकार प्रभाव](shape-effect.png)

PowerPoint शैप्स पर लागू किए जा सकने वाले छह इफ़ेक्ट्स प्रदान करता है। आप एक या अधिक इफ़ेक्ट्स किसी आकार पर लागू कर सकते हैं।

कुछ इफ़ेक्ट संयोजन अन्य की तुलना में बेहतर दिखते हैं। इसी कारण, PowerPoint **Preset** के अंतर्गत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक इफ़ेक्ट्स के ऐसे संयोजन हैं जो अच्छे दिखने के लिए ज्ञात हैं। इस प्रकार, एक प्रीसेट चुनकर, आपको विभिन्न इफ़ेक्ट्स का परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) क्लास के अंतर्गत प्रॉपर्टी और मेथड प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान इफ़ेक्ट्स लागू करने की अनुमति देते हैं।

## **छाया इफ़ेक्ट लागू करें**

Aspose.Slides for Java आकारों के लिए बाहरी और आंतरिक छाया का समर्थन करता है। आप उनके रंग, दिशा, दूरी, और ब्लर रैडियस को अपनी प्रस्तुति के डिजाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

बाहरी छाया का उपयोग करके आप कार्ड या पैनल को स्लाइड पृष्ठभूमि में उभरा दिखा सकते हैं। छाया आकार की किनारों से बाहर तक फैलती है, जिससे ऐसा प्रभाव बनता है कि आकार स्लाइड के ऊपर उठाया गया है। उसके रंग, दिशा, दूरी, और ब्लर रैडियस को अपनी टेम्पलेट की लाइटिंग और स्टाइलिंग के अनुसार समायोजित करें।

यह Java कोड दर्शाता है कि कैसे एक आयत पर [बाहरी छाया इफ़ेक्ट](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) लागू किया जाए:

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

![छाया इफ़ेक्ट](shadow_effect.png)

### **आंतरीय छाया लागू करें**

जब आप टेम्पलेट की दृश्य शैली को दोहराते हैं, तो कार्ड या पैनल को छिद्रित रूप देने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर तक विस्तारित होती है और उसे उभरा दिखाती है, जबकि आंतरिक छाया उसके किनारों के भीतर छाया देती है।

आंतरिक छाया प्रभाव को सक्षम करने के लिए [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) द्वारा लौटाए गए छाया को कॉन्फ़िगर करें। बड़े ब्लर रैडियस मान नरम किनारे बनाते हैं।

यह Java उदाहरण हल्के नीले कार्ड को गहरे धूसर आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री है, उसकी दूरी 7 पॉइंट्स है, और ब्लर रैडियस 6 पॉइंट्स है:

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

![आंतरिक छाया के साथ हल्का नीला आयत](inner_shadow_effect.png)

आंतरिक छाया को हटाने के लिए, आकार के इफ़ेक्ट फ़ॉर्मेट पर [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) को कॉल करें।

## **प्रतिबिंब इफ़ेक्ट लागू करें**

Aspose.Slides for Java में प्रतिबिंब इफ़ेक्ट लागू करने के लिए, आप आकारों पर दर्पण जैसी प्रतिबिंब जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह इफ़ेक्ट आपके प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, आकारों को अधिक चमकदार और परिष्कृत रूप देता है। इसे सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर तेज़ी से एकसमान डिज़ाइन लागू किया जा सके।

यह Java कोड दिखाता है कि कैसे एक आकार पर [प्रतिबिंब इफ़ेक्ट](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) लागू किया जाए:

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

Aspose.Slides for Java में किसी आकार पर ग्लो इफ़ेक्ट लागू करने के लिए, आप आकारों के चारों ओर एक नरम, चमकदार आभा जोड़ सकते हैं, रंग और आकार जैसी प्रॉपर्टीज़ को समायोजित कर सकते हैं। यह इफ़ेक्ट आकारों को उभरने में मदद करता है और आपकी प्रस्तुति में एक आकर्षक, आंखों को पकड़ने वाला दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड के साथ आसानी से लागू किया जा सकता है, जिससे स्लाइड्स की समग्र उपस्थिति सुधरती है।

यह Java कोड दिखाता है कि कैसे एक आकार पर [ग्लो इफ़ेक्ट](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) लागू किया जाए:

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

![ग्लो इफ़ेक्ट](glow_effect.png)

## **सॉफ़्ट एज इफ़ेक्ट लागू करें**

Aspose.Slides for Java में सॉफ़्ट एज इफ़ेक्ट लागू करने के लिए, आप आकार के किनारों के चारों ओर एक स्मूथ, ब्लर ट्रांज़िशन बना सकते हैं। यह इफ़ेक्ट एक अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, जो उन डिज़ाइनों के लिए उत्तम है जिन्हें कोमल, नरम दिखावट की आवश्यकता है। आप अपनी प्रस्तुति में विभिन्न आकारों पर वांछित इफ़ेक्ट हासिल करने के लिए आसानी से रैडियस जैसे पैरामीटर समायोजित कर सकते हैं।

यह Java कोड दिखाता है कि कैसे एक आकार पर [सॉफ़्ट एज इफ़ेक्ट](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) लागू किया जाए:

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

![सॉफ़्ट एज इफ़ेक्ट](soft_edges_effect.png)

## **ब्लर इफ़ेक्ट लागू करें**

आकार ब्लर का उपयोग करके आप आकार के फ़िल और रूपरेखा को नरम कर सकते हैं जबकि आकार को संपादन योग्य बनाए रख सकते हैं। आकार के इफ़ेक्ट फ़ॉर्मेट पर [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को कॉल करें। रैडियस पॉइंट्स में मापा जाता है (1/72 इंच): गैर-नकारात्मक मान उपयोग करें, बड़े मान अधिक तीव्र ब्लर उत्पन्न करेंगे। शून्य रैडियस दिखावट को अपरिवर्तित रखता है।

यह [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) सेटिंग इफ़ेक्ट की दृश्य सीमा को नियंत्रित करती है। `false` होने पर, ब्लर मूल पेंटेड सीमा तक सीमित रहता है, जिसमें रूपरेखा शामिल है। `true` होने पर, ब्लर उन्हीं सीमाओं से बाहर तक विस्तारित हो सकता है। इन दोनों सेटिंग्स में से कोई भी आकार की स्थिति या आयामों को नहीं बदलती।

नीचे दिया गया तुलना समान फ़िल, रूपरेखा, और आकार के आयामों का उपयोग करती है। शीर्ष पंक्ति `grow = false` प्रयोग करती है; निचली पंक्ति `grow = true` प्रयोग करती है।

![ग्रो अक्षम/सक्षम के साथ 5 और 15 पॉइंट्स ब्लर रैडियस वाले मूल आयत की तुलना](shape_blur_comparison.png)

यह Java उदाहरण संतरी रंग के आयत को गहरे नीले आउटलाइन के साथ बनाता है, 5 पॉइंट्स ब्लर लागू करता है, और फिर [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) को पुनः कॉल करके इसे 15 पॉइंट्स ब्लर में अपडेट करता है। यह दोनों ब्लर वाली अवस्थाओं को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) को कॉल करके ब्लर के बिना आकार को सहेजता है।

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

आकार ब्लर फ़िल और रूपरेखा दोनों को एक साथ प्रभावित करता है। सॉफ़्ट एज इफ़ेक्ट आकार के किनारों को फीका करता है, जबकि शैडो ब्लर केवल छाया को मुलायम बनाता है। इमेज ट्रांसफ़ॉर्मेशन इफ़ेक्ट इमेज सामग्री पर कार्य करते हैं; यह उदाहरण आकार को इमेज में बदलें बिना सीधे आकार के इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **FAQ**

**क्या मैं समान आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हां, आप एक ही आकार पर विभिन्न इफ़ेक्ट्स, जैसे छाया, प्रतिबिंब, और ग्लो, को संयोजित करके अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न आकारों पर इफ़ेक्ट्स लागू कर सकते हैं, जिसमें ऑटोशेप्स, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट्स, OLE ऑब्जेक्ट्स, और अधिक शामिल हैं।

**क्या मैं समूहित आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हां, आप समूहित आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। इफ़ेक्ट पूरे समूह पर लागू होगा।