---
title: जावा का उपयोग करके प्रस्तुतियों में आकृति प्रभाव लागू करें
linktitle: आकृति प्रभाव
type: docs
weight: 30
url: /hi/java/shape-effect/
keywords:
- आकृति प्रभाव
- छाया प्रभाव
- परावर्तक प्रभाव
- चमक प्रभाव
- नरम किनारा प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके अपने PPT और PPTX फ़ाइलों को उन्नत आकृति प्रभावों से बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जबकि PowerPoint में प्रभावों का उपयोग किसी आकृति को उभारा गया बनाने के लिए किया जा सकता है, वे [भरण](/slides/hi/java/shape-formatting/#gradient-fill) या बाहरी रेखा से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप आकृति पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकृति की चमक फैलाने आदि कर सकते हैं।

![आकृति प्रभाव](shape-effect.png)

PowerPoint में छह प्रभाव उपलब्ध हैं जिन्हें आकृतियों पर लागू किया जा सकता है। आप किसी आकृति पर एक या अधिक प्रभाव लागू कर सकते हैं।

कुछ प्रभाव संयोजन दूसरों से बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के ऐसे संयोजन होते हैं जो सुन्दर दिखते हैं। इस प्रकार, प्रीसेट चुनकर आपको विभिन्न प्रभावों को आज़माने या मिलाने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides में [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) क्लास के अंतर्गत ऐसी प्रॉपर्टी और मेथड उपलब्ध हैं जो आपको PowerPoint प्रस्तुतियों में आकृतियों पर समान प्रभाव लागू करने की अनुमति देती हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Java आकृतियों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिज़ाइन से मिलाने के लिए अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

स्लाइड पृष्ठभूमि के मुकाबले कार्ड या पैनल को उभारा दिखाने के लिए बाहरी छाया का उपयोग करें। छाया आकृति की किनारों से बाहर तक फैलती है, जिससे ऐसा प्रभाव मिलता है कि आकृति स्लाइड के ऊपर उठी हुई है। अपने टेम्पलेट की रोशनी और शैली से मेल खाने के लिए उसके रंग, दिशा, दूरी और ब्लर त्रिज्या को समायोजित करें।

यह Java कोड दिखाता है कि कैसे [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) को एक आयत में लागू किया जाए:

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

### **आंतरिक छाया लागू करें**

जब टेम्पलेट की दृश्य शैली को दोहराते हैं, तो कार्ड या पैनल को प्रतिबिंबित दिखाने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकृति के बाहर फैलती है और उसे उठी हुई दिखाती है, जबकि आंतरिक छाया उसकी किनारों के अंदर भाग को घेरती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) के द्वारा लौटाई गई छाया को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान नरम किनारे बनाते हैं।

यह Java उदाहरण हल्के नीले रंग के कार्ड को गहरे ग्रे आंतरिक छाया के साथ बनाता है और उसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री, दूरी 7 पॉइंट और ब्लर त्रिज्या 6 पॉइंट है:

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

आंतरिक छाया हटाने के लिए, आकृति के प्रभाव स्वरूप पर [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) को कॉल करें।

## **परावर्तक प्रभाव लागू करें**

Aspose.Slides for Java में परावर्तक प्रभाव लागू करने के लिए, आप आकृतियों में दर्पण जैसी प्रतिबिंब जोड़ सकते हैं, और दूरी, पारदर्शिता तथा आकार जैसी पैरामीटर को समायोजित कर सकते हैं। यह प्रभाव आपके प्रस्तुतियों की सुंदरता को बढ़ाता है, जिससे आकृतियों को अधिक परिष्कृत रूप मिलता है। इसे सरल कोड से आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर सुसंगत डिज़ाइन के लिए तेज़ी से लागू किया जा सके।

यह Java कोड दिखाता है कि कैसे [परावर्तक प्रभाव](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) को एक आकृति में लागू किया जाए:

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

![परावर्तक प्रभाव](reflection_effect.png)

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for Java में किसी आकृति पर ग्लो प्रभाव लागू करने के लिए, आप आकृति के चारों ओर एक नरम, उज्ज्वल आभा जोड़ सकते हैं, और रंग तथा आकार जैसी प्रॉपर्टी को समायोजित कर सकते हैं। यह प्रभाव आकृतियों को प्रमुख बनाता है और आपके प्रस्तुतियों में एक आकर्षक दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड से आसानी से लागू किया जा सकता है, जिससे आपके स्लाइड्स की कुल रूपरेखा सुधरती है।

यह Java कोड दिखाता है कि कैसे [ग्लो प्रभाव](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) को एक आकृति में लागू किया जाए:

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

![ग्लो प्रभाव](glow_effect.png)

## **सॉफ्ट एजेज प्रभाव लागू करें**

Aspose.Slides for Java में सॉफ्ट एजेज प्रभाव लागू करने के लिए, आप आकृति के किनारों के चारों ओर एक मुलायम, धुंधला संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत लुक देता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिन्हें हल्का, नरम स्वरूप चाहिए। आप आसानी से त्रिज्या जैसी पैरामीटर को समायोजित करके अपने प्रस्तुतियों में विभिन्न आकृतियों पर वांछित प्रभाव प्राप्त कर सकते हैं।

यह Java कोड दिखाता है कि कैसे [सॉफ्ट एजेज प्रभाव](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) को एक आकृति में लागू किया जाए:

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

![सॉफ्ट एजेज प्रभाव](soft_edges_effect.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकृति पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकृति पर विभिन्न प्रभाव, जैसे छाया, प्रतिबिंब और ग्लो, को संयोजित करके अधिक गतिशील रूप बना सकते हैं।

**कौन सी आकृतियों पर मैं प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकृतियों पर प्रभाव लागू कर सकते हैं, जिनमें ऑटोशेप, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अधिक शामिल हैं।

**क्या मैं समूहित आकृतियों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकृतियों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।