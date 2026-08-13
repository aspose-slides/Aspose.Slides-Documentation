---
title: Android पर WordArt प्रभाव बनाएं और लागू करें
linktitle: WordArt
type: docs
weight: 110
url: /hi/androidjava/wordart/
keywords:
- WordArt
- WordArt बनाएं
- WordArt टेम्प्लेट
- WordArt प्रभाव
- शैडो प्रभाव
- प्रदर्शन प्रभाव
- ग्लो प्रभाव
- WordArt ट्रांसफ़ॉर्मेशन
- 3D प्रभाव
- आउटर शैडो प्रभाव
- इनर शैडो प्रभाव
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में WordArt प्रभाव बनाएं और कस्टमाइज़ करें। यह चरण‑दर‑चरण गाइड डेवलपर्स को Java में पेशेवर टेक्स्ट के साथ प्रस्तुतियों को बेहतर बनाने में मदद करता है।"
---
## **अवलोकन**

WordArt प्रभाव आपको अपने PowerPoint प्रस्तुतियों में दृश्य रूप से आकर्षक, शैलीबद्ध टेक्स्ट जोड़ने की सुविधा देता है। Aspose.Slides के साथ, डेवलपर्स प्रोग्रामेटिकली WordArt बना, अनुकूलित और प्रबंधित कर सकते हैं, बिलकुल Microsoft PowerPoint की तरह—भले ही Office इंस्टॉल न हो। यह लेख WordArt के साथ काम करने का एक अवलोकन प्रदान करता है, जिसमें टेक्स्ट ट्रांसफ़ॉर्मेशन, फिल स्टाइल, आउटलाइन, शैडो और अन्य फ़ॉर्मेटिंग विकल्पों को लागू करके आपकी प्रस्तुति सामग्री को अधिक अभिव्यक्तिपूर्ण और आकर्षक बनाने के तरीके शामिल हैं। WordArt आपको टेक्स्ट को एक ग्राफ़िकल ऑब्जेक्ट के रूप में मानने की अनुमति देता है। यह टेक्स्ट पर लागू किए गए प्रभावों या विशेष संशोधनों का एक समूह है, जिससे वह अधिक आकर्षक या ध्यान आकर्षित करने वाला बन जाता है।

## **एक सरल WordArt टेम्प्लेट बनाएं और इसे टेक्स्ट पर लागू करें**

**Using Aspose.Slides** 

सबसे पहले, हम इस Java कोड का उपयोग करके एक साधारण टेक्स्ट बनाते हैं:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
अब, हम इस कोड के माध्यम से प्रभाव को अधिक स्पष्ट बनाने के लिए टेक्स्ट का फ़ॉन्ट आकार बड़ा सेट करते हैं:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Using Microsoft PowerPoint**

Microsoft PowerPoint में WordArt प्रभाव मेनू पर जाएँ:

![todo:image_alt_text](image-20200930113926-1.png)

दाएँ मेनू से आप एक प्री‑डिफाइन्ड WordArt प्रभाव चुन सकते हैं। बाएँ मेनू से आप नए WordArt के लिए सेटिंग्स निर्दिष्ट कर सकते हैं।

उपलब्ध पैरामीटर या विकल्पों में से कुछ इस प्रकार हैं:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

यहाँ, हम टेक्स्ट पर [SmallGrid](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PatternStyle#SmallGrid) पैटर्न रंग लागू करते हैं और इस कोड के साथ 1‑पिक्सेल चौड़ी काली टेक्स्ट सीमा जोड़ते हैं:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}

```

परिणामस्वरूप टेक्स्ट:

![todo:image_alt_text](image-20200930114108-4.png)

## **अन्य WordArt प्रभाव लागू करें**

**Using Microsoft PowerPoint**

प्रोग्राम के इंटरफ़ेस से आप टेक्स्ट, टेक्स्ट ब्लॉक, शैप या समान तत्व पर ये प्रभाव लागू कर सकते हैं:

![todo:image_alt_text](image-20200930114129-5.png)

उदाहरण के लिए, Shadow, Reflection, और Glow प्रभाव टेक्स्ट पर लागू किए जा सकते हैं; 3D Format और 3D Rotation प्रभाव टेक्स्ट ब्लॉक पर; Soft Edges प्रॉपर्टी शैप ऑब्जेक्ट पर लागू होती है (भले ही 3D Format प्रॉपर्टी सेट न हो)।

### **Shadow प्रभाव लागू करें**

यहाँ, हम केवल टेक्स्ट से संबंधित प्रॉपर्टीज़ सेट करना चाहते हैं। इस Java कोड के साथ हम टेक्स्ट पर शैडो प्रभाव लागू करते हैं:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    if (pres != null) pres.dispose();
}
```

Aspose.Slides API तीन प्रकार के शैडो को सपोर्ट करता है: OuterShadow, InnerShadow, और PresetShadow।

PresetShadow के साथ, आप प्रीसेट मानों का उपयोग करके टेक्स्ट के लिए शैडो लागू कर सकते हैं।

**Using Microsoft PowerPoint**

PowerPoint में आप केवल एक प्रकार का शैडो उपयोग कर सकते हैं। नीचे एक उदाहरण दिया गया है:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides वास्तव में एक साथ दो प्रकार के शैडो लागू करने की अनुमति देता है: InnerShadow और PresetShadow।

**Notes:**

- जब OuterShadow और PresetShadow एक साथ उपयोग होते हैं, तो केवल OuterShadow प्रभाव लागू होता है।  
- यदि OuterShadow और InnerShadow एक साथ उपयोग किए जाते हैं, तो लागू प्रभाव PowerPoint संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में प्रभाव दोगुना हो जाता है, जबकि PowerPoint 2007 में OuterShadow प्रभाव लागू होता है।  

### **टेक्स्ट पर Reflection प्रभाव लागू करें**

हम इस Java कोड स्निपेट के माध्यम से टेक्स्ट में रिफ्लेक्शन जोड़ते हैं:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
    if (pres != null) pres.dispose();
}
```

### **टेक्स्ट पर Glow प्रभाव लागू करें**

हम टेक्स्ट पर चमक (Glow) प्रभाव लागू करते हैं जिससे वह उज्ज्वल या प्रमुख दिखे, इस कोड का उपयोग करके:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

ऑपरेशन का परिणाम:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

आप शैडो, रिफ्लेक्शन और ग्लो के पैरामीटर बदल सकते हैं। प्रभावों की प्रॉपर्टीज़ प्रत्येक टेक्स्ट भाग पर अलग‑अलग सेट की जाती हैं। 

{{% /alert %}} 

### **WordArt में ट्रांसफ़ॉर्मेशन का उपयोग करें**

हम इस कोड के माध्यम से पूरे टेक्स्ट ब्लॉक पर लागू होने वाली Transform प्रॉपर्टी का उपयोग करते हैं:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

परिणाम:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Microsoft PowerPoint और Android के लिए Aspose.Slides (Java) दोनों कुछ प्री‑डिफाइन्ड ट्रांसफ़ॉर्मेशन प्रकार प्रदान करते हैं।

{{% /alert %}} 

**Using PowerPoint**

प्री‑डिफाइन्ड ट्रांसफ़ॉर्मेशन प्रकार तक पहुँचने के लिए जाएँ: **Format** → **TextEffect** → **Transform**

**Using Aspose.Slides**

ट्रांसफ़ॉर्मेशन प्रकार चुनने के लिए TextShapeType Enum का उपयोग करें। 

### **टेक्स्ट और शैप्स पर 3D प्रभाव लागू करें**

हम इस नमूना कोड के साथ टेक्स्ट शैप पर 3D प्रभाव सेट करते हैं:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

परिणामी टेक्स्ट और उसका शैप:

![todo:image_alt_text](image-20200930114816-9.png)

हम इस Java कोड के साथ टेक्स्ट पर 3D प्रभाव लागू करते हैं:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

ऑपरेशन का परिणाम:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

टेक्स्ट या उनके शैप्स पर 3D प्रभावों का अनुप्रयोग तथा प्रभावों के बीच की अंतःक्रिया कुछ नियमों पर आधारित है। 

एक टेक्स्ट और उसे सम्मिलित करने वाले शैप के लिए दृश्य (scene) पर विचार करें। 3D प्रभाव में 3D ऑब्जेक्ट प्रतिनिधित्व और वह दृश्य शामिल होता है जिसमें ऑब्जेक्ट रखी गई है। 

- जब दृश्य दोनों, फ़िगर और टेक्स्ट, दोनों के लिए सेट किया जाता है, तो फ़िगर दृश्य को अधिक प्राथमिकता मिलती है—टेक्स्ट दृश्य को अनदेखा किया जाता है।  
- जब फ़िगर के पास अपना स्वयं का दृश्य नहीं होता लेकिन 3D प्रतिनिधित्व होता है, तो टेक्स्ट दृश्य का उपयोग किया जाता है।  
- अन्यथा—जब शैप मूल रूप से कोई 3D प्रभाव नहीं रखता—शैप फ्लैट रहता है और 3D प्रभाव केवल टेक्स्ट पर लागू होता है।  

इन विवरणों का संबंध ThreeDFormat.getLightRig() और ThreeDFormat.getCamera() मेथड्स से है।

{{% /alert %}} 

## **टेक्स्ट पर Outer Shadow प्रभाव लागू करें**
Android (Java) के लिए Aspose.Slides [**IOuterShadow**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioutershadow/) और [**IInnerShadow**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinnershadow/) क्लासेज प्रदान करता है, जिससे आप [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) द्वारा प्रदत्त टेक्स्ट पर शैडो प्रभाव लगा सकते हैं। इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड पर Rectangle प्रकार का AutoShape जोड़ें।  
4. AutoShape से जुड़े TextFrame तक पहुँचें।  
5. AutoShape का FillType NoFill सेट करें।  
6. OuterShadow क्लास का इंस्टेंस बनाएं।  
7. शैडो का BlurRadius सेट करें।  
8. शैडो की Direction सेट करें।  
9. शैडो की Distance सेट करें।  
10. RectangleAlign को TopLeft सेट करें।  
11. शैडो का PresetColor Black सेट करें।  
12. प्रेजेंटेशन को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

नीचे Java में इस नमूना कोड का कार्यान्वयन दिखाया गया है, जो ऊपर बताए गए चरणों को लागू करते हुए टेक्स्ट पर Outer Shadow प्रभाव जोड़ता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // स्लाइड का रेफ़रेंस प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // Rectangle प्रकार का AutoShape जोड़ें
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle में TextFrame जोड़ें
    ashp.addTextFrame("Aspose TextBox");

    // टेक्स्ट की शैडो प्राप्त करने के लिए शैप फ़िल को निष्क्रिय करें
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // बाहरी शैडो जोड़ें और सभी आवश्यक पैरामीटर सेट करें
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // प्रस्तुति को डिस्क पर सहेजें
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Shapes पर Inner Shadow प्रभाव लागू करें**
इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।  
2. स्लाइड का रेफ़रेंस प्राप्त करें।  
3. Rectangle प्रकार का AutoShape जोड़ें।  
4. InnerShadowEffect को सक्षम करें।  
5. सभी आवश्यक पैरामीटर सेट करें।  
6. ColorType को Scheme सेट करें।  
7. Scheme Color सेट करें।  
8. प्रेजेंटेशन को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

उपरोक्त चरणों के आधार पर यह नमूना कोड दिखाता है कि Java में टेक्स्ट पर Inner Shadow प्रभाव कैसे लागू करें:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // स्लाइड का रेफ़रेंस प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle प्रकार का AutoShape जोड़ें
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Rectangle में TextFrame जोड़ें
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // InnerShadowEffect सक्षम करें
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // सभी आवश्यक पैरामीटर सेट करें
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ColorType को Scheme सेट करें
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme Color सेट करें
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // प्रस्तुति सहेजें
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### क्या मैं विभिन्न फ़ॉन्ट या स्क्रिप्ट (जैसे Arabic, Chinese) के साथ WordArt प्रभाव उपयोग कर सकता हूँ?

हां, Aspose.Slides Unicode को सपोर्ट करता है और सभी प्रमुख फ़ॉन्ट व स्क्रिप्ट के साथ काम करता है। Shadow, Fill और Outline जैसे WordArt प्रभाव भाषा की परवाह किए बिना लागू किए जा सकते हैं, हालांकि फ़ॉन्ट की उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट पर निर्भर हो सकती है।

### क्या मैं स्लाइड मास्टर तत्वों पर WordArt प्रभाव लागू कर सकता हूँ?

हां, आप मास्टर स्लाइड्स पर शैप्स, टाइटल प्लेसहोल्डर्स, फुटर्स या बैकग्राउंड टेक्स्ट सहित WordArt प्रभाव लागू कर सकते हैं। मास्टर लेआउट में किए गए परिवर्तन सभी संबंधित स्लाइड्स पर प्रतिबिंबित होते हैं।

### क्या WordArt प्रभाव प्रस्तुति फ़ाइल के आकार को प्रभावित करते हैं?

थोड़ा। Shadow, Glow और Gradient Fill जैसे WordArt प्रभाव फ़ॉर्मेटिंग मेटाडेटा जोड़ने के कारण फ़ाइल आकार को हल्का बढ़ा सकते हैं, लेकिन अंतर आम तौर पर नगण्य रहता है।

### क्या मैं प्रस्तुति को सहेजे बिना WordArt प्रभाव का परिणाम पूर्वावलोकन कर सकता हूँ?

हां, आप [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) या [ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) इंटरफ़ेस के `getImage` मेथड का उपयोग करके WordArt सहित स्लाइड्स को PNG, JPEG आदि इमेज फ़ॉर्मेट में रेंडर कर सकते हैं। यह आपको पूरी प्रस्तुति सहेजने या एक्सपोर्ट करने से पहले मेमोरी में या स्क्रीन पर परिणाम का पूर्वावलोकन करने देता है।