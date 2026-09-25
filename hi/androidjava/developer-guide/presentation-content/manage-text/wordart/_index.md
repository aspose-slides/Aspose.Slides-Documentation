---
title: Android पर WordArt प्रभाव बनाएं और लागू करें
linktitle: WordArt
type: docs
weight: 110
url: /hi/androidjava/wordart/
keywords:
- WordArt
- WordArt बनाएं
- WordArt टेम्पलेट
- WordArt प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- WordArt परिवर्तन
- 3D प्रभाव
- बाहरी छाया प्रभाव
- आंतरिक छाया प्रभाव
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में WordArt प्रभाव बनाएं और अनुकूलित करें। यह चरण-दर-चरण मार्गदर्शिका डेवलपर्स को Android पर पेशेवर टेक्स्ट के साथ प्रस्तुतियों को बेहतर बनाने में मदद करती है।"
---
## **सारांश**

WordArt प्रभाव आपको टेक्स्ट को फ़िल, आउटलाइन, शैडो, रिफ्लेक्शन, ग्लो, ट्रांसफ़ॉर्मेशन और 3D फ़ॉर्मेटिंग के साथ स्टाइल करने देते हैं। यह लेख PowerPoint प्रस्तुतियों में Aspose.Slides for Android via Java का उपयोग करके इन प्रभावों को बनाने और अनुकूलित करने के तरीकों को बताता है, बिना Microsoft Office स्थापित किए।

## **एक सरल WordArt टेम्पलेट बनाएं और इसे पाठ पर लागू करें**

निम्नलिखित उदाहरण टेक्स्ट, फ़ॉन्ट, पैटर्न फ़िल और आउटलाइन सेट करके एक सरल WordArt शैली बनाते हैं।

प्रत्येक उदाहरण एक नया प्रेजेंटेशन बनाता है और इसकी पहली स्लाइड पर एक आयत जोड़ता है; कोई इनपुट फ़ाइल आवश्यक नहीं है। पहला उदाहरण टेक्स्ट को **Aspose.Slides** पर सेट करता है। आकार की स्थिति और आयाम पॉइंट में मापे जाते हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

फ़ॉर्मेटिंग को अधिक स्पष्ट बनाने के लिए फ़ॉन्ट को Arial Black, 36 पॉइंट पर सेट करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

एक [SmallGrid](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/patternstyle/#SmallGrid) पैटर्न को गहरे नारंगी अग्रभूमि और सफेद पृष्ठभूमि के साथ लागू करें, फिर 1 पॉइंट चौड़ाई के साथ काले टेक्स्ट आउटलाइन जोड़ें:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    int darkOrange = Color.rgb(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

परिणामी टेक्स्ट:

![सरल WordArt टेम्पलेट](WordArt_template.png)

## **अन्य WordArt प्रभाव लागू करें**

निम्नलिखित उदाहरण दिखाते हैं कि टेक्स्ट पर शैडो, रिफ्लेक्शन, ग्लो, ट्रांसफ़ॉर्मेशन और 3D प्रभाव कैसे लागू करें।

### **बाहरी शैडो प्रभाव लागू करें**

एक बाहरी शैडो टेक्स्ट के पीछे शैडो रखकर गहराई जोड़ता है। आप इसके रंग, दिशा, दूरी, ब्लर रेडियस, स्केल और स्क्यू को अनुकूलित कर सकते हैं।

यह उदाहरण [enableOuterShadowEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--) को कॉल करता है और 4 पॉइंट ब्लर रेडियस, 230‑डिग्री दिशा, और 30 पॉइंट दूरी के साथ काली शैडो सेट करता है। स्केल मान 100 शैडो आकार को बनाए रखते हैं, जबकि क्षैतिज स्क्यू इसे 20 डिग्री घुमाता है। अल्फा ट्रांसफ़ॉर्म इसकी अपारदर्शिता को 32 % पर सेट करता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

परिणामी टेक्स्ट:

![द बाहरी शैडो प्रभाव](outer_shadow_effect.png)

{{% alert color="info" title="नोट" %}}
- जब बाहरी और प्रीसेट शैडो एक साथ उपयोग किए जाते हैं, तो केवल बाहरी शैडो लागू होती है।
- यदि बाहरी और داخلی शैडो एक ही समय में उपयोग किए जाते हैं, तो परिणामस्वरूप प्रभाव PowerPoint संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में प्रभाव दो गुना हो जाता है, जबकि PowerPoint 2007 में केवल बाहरी शैडो लागू होती है।
{{% /alert %}}

### **रिफ्लेक्शन प्रभाव लागू करें**

रिफ्लेक्शन टेक्स्ट की एक परावर्तित कॉपी बनाता है। उसकी स्थिति, स्केल, ब्लर और अपारदर्शिता को समायोजित करके आप दिखावट नियंत्रित कर सकते हैं।

यह उदाहरण [enableReflectionEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--) को कॉल करता है और रिफ्लेक्शन को वर्टिकली फ्लिप करके -100 % स्केल लागू करता है। यह 0.5‑पॉइंट ब्लर रेडियस और 4.72‑पॉइंट दूरी का उपयोग करता है। अपारदर्शिता 60 % से 0.9 % तक घटती है जब रिफ्लेक्शन की स्थिति 0 % से 60 % तक बदलती है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    presentation.dispose();
}
```

परिणामी टेक्स्ट:

![रिफ्लेक्शन प्रभाव](reflection_effect.png)

### **ग्लो प्रभाव लागू करें**

ग्लो टेक्स्ट के चारों ओर एक मुलायम रंगीन आउटलाइन जोड़ता है। उसकी रंग, अपारदर्शिता और रेडियस को समायोजित करके आप प्रभाव को नियंत्रित कर सकते हैं।

यह उदाहरण [enableGlowEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--) को कॉल करता है और 54 % अपारदर्शिता और 7 पॉइंट रेडियस के साथ लाल ग्लो लागू करता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

परिणामी टेक्स्ट:

![ग्लो प्रभाव](glow_effect.png)

### **WordArt ट्रांसफ़ॉर्मेशन लागू करें**

WordArt ट्रांसफ़ॉर्मेशन टेक्स्ट ब्लॉक को मोड़ते, खींचते या आकार देते हैं।

setTransform को [ArchUpPour](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textshapetype/#ArchUpPour) पर सेट करके पूरे टेक्स्ट फ्रेम को ऊपर की ओर कर्व करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

परिणामी टेक्स्ट:

![WordArt ट्रांसफ़ॉर्मेशन](transform_effect.png)

{{% alert color="info" title="नोट" %}}
Aspose.Slides for Android via Java पूर्वनिर्धारित ट्रांसफ़ॉर्मेशन प्रकारों का एक सेट प्रदान करता है।
{{% /alert %}}

### **आकार और टेक्स्ट पर 3D प्रभाव लागू करें**

आप आकार या उसके टेक्स्ट पर 3D प्रभाव लागू कर सकते हैं। बीवेल, एक्सट्रूज़न, लाइटिंग और कैमरा सेटिंग्स परिणामस्वरूप दिखावट को नियंत्रित करती हैं।

निम्नलिखित उदाहरण [ThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/) का उपयोग करके आयत में गोलाकार बीवेल, नारंगी एक्सट्रूज़न और गहरा लाल कंटूर जोड़ता है। बीवेल आयाम, एक्सट्रूज़न ऊँचाई, कंटूर चौड़ाई, और गहराई पॉइंट में मापी जाती हैं। एक प्लास्टिक सामग्री, Z-अक्ष के चारों ओर 40 डिग्री घुमाया गया संतुलित लाइटिंग, और एक पर्स्पेक्टिव कैमरा इसकी दिखावट को परिभाषित करता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

परिणामी आकार:

![आकार 3D प्रभाव](shape_3D_effect.png)

यह उदाहरण [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--) के माध्यम से टेक्स्ट पर समान 3D फ़ॉर्मेटिंग लागू करता है। छोटे बीवेल अक्षरों के किनारों को आकार देते हैं, जबकि एक्सट्रूज़न और लाइटिंग टेक्स्ट को गहराई प्रदान करती है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

परिणामी टेक्स्ट:

![टेक्स्ट 3D प्रभाव](text_3D_effect.png)

{{% alert color="info" title="नोट" %}}
3D प्रभावों का टेक्स्ट या उनके आकार पर लागू करना—और इन प्रभावों के बीच की अंतःक्रिया—विशिष्ट नियमों द्वारा नियंत्रित होती है। विचार करें कि टेक्स्ट और उसे सम्मिलित करने वाला आकार दोनों के साथ एक सीन मौजूद है। 3D प्रभाव में वस्तु का 3D प्रतिनिधित्व और वह सीन शामिल होता है जिसमें वह रखा गया है।

- यदि दोनों आकार और टेक्स्ट के लिए सीन सेट किया गया है, तो आकार का सीन प्राथमिकता लेता है और टेक्स्ट का सीन अनदेखा हो जाता है।
- यदि आकार के पास अपना सीन नहीं है लेकिन उसके पास 3D प्रतिनिधित्व है, तो टेक्स्ट का सीन उपयोग किया जाता है।
- यदि आकार के पास कोई 3D प्रभाव नहीं है, तो उसे फ्लैट माना जाता है, और 3D प्रभाव केवल टेक्स्ट पर लागू होता है।

ये व्यवहार [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/#getLightRig--) और [ThreeDFormat.getCamera](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/threedformat/#getCamera--) मेथड्स से संबंधित हैं।
{{% /alert %}}

पाठ को सपाट और पठनीय रखने के साथ-साथ उसके आकार की 3D फ़ॉर्मेटिंग बनाए रखने के लिए, दोनों सेटिंग्स की तुलना और एक पूर्ण Java उदाहरण के लिए देखें [Keep Text Flat on a 3D Shape](/slides/hi/androidjava/3d-presentation/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं विभिन्न फ़ॉन्ट्स या स्क्रिप्ट्स (जैसे अरबी, चीनी) के साथ WordArt प्रभाव उपयोग कर सकता हूँ?**

हाँ, Aspose.Slides for Android via Java Unicode को समर्थन देता है और सभी प्रमुख फ़ॉन्ट्स एवं स्क्रिप्ट्स के साथ काम करता है। शैडो, फ़िल और आउटलाइन जैसे WordArt प्रभाव भाषा की परवाह किए बिना लागू किए जा सकते हैं, हालांकि फ़ॉन्ट उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट्स पर निर्भर हो सकती है।

**क्या मैं स्लाइड मास्टर तत्वों पर WordArt प्रभाव लागू कर सकता हूँ?**

हाँ, आप मास्टर स्लाइड पर मौजूद आकारों, जैसे शीर्षक प्लेसहोल्डर, फुटर या पृष्ठभूमि टेक्स्ट पर WordArt प्रभाव लागू कर सकते हैं। मास्टर लेआउट में किए गए परिवर्तन सभी संबंधित स्लाइड्स में प्रतिबिंबित होते हैं।

**क्या WordArt प्रभाव प्रस्तुति फ़ाइल आकार को प्रभावित करते हैं?**

थोड़े से। शैडो, ग्लो और ग्रेडिएंट फ़िल जैसे WordArt प्रभाव फ़ॉर्मेटिंग मेटाडाटा जोड़ते हैं, जिससे फ़ाइल आकार में हल्का वृद्धि हो सकती है, लेकिन अंतर सामान्यतः नगण्य होता है।

**क्या मैं प्रस्तुति को सहेजे बिना WordArt प्रभावों के परिणाम का पूर्वावलोकन कर सकता हूँ?**

हाँ, आप [ISlide.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage--) का उपयोग करके WordArt वाली स्लाइड्स को छवियों (जैसे PNG, JPEG) में रेंडर कर सकते हैं, या व्यक्तिगत आकारों को [IShape.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getImage--) से रेंडर कर सकते हैं। यह आपको पूर्ण प्रस्तुति को सहेजने या एक्सपोर्ट करने से पहले मेमोरी या स्क्रीन पर परिणाम का पूर्वावलोकन करने की अनुमति देता है।