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
- छाया प्रभाव
- प्रदर्शन प्रभाव
- चमक प्रभाव
- WordArt ट्रांसफ़ॉर्मेशन
- 3D प्रभाव
- बाहरी छाया प्रभाव
- आंतरिक छाया प्रभाव
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में WordArt प्रभाव बनाएं और अनुकूलित करें। यह चरणबद्ध मार्गदर्शिका डेवलपर्स को Java में पेशेवर टेक्स्ट के साथ प्रस्तुतियों को बेहतर बनाने में मदद करती है।"
---
## **सारांश**

WordArt प्रभाव आपको अपने PowerPoint प्रस्तुतियों में दृश्य रूप से आकर्षक, शैलीबद्ध टेक्स्ट जोड़ने की अनुमति देते हैं। Aspose.Slides के साथ, डेवलपर प्रोग्रामेटिक रूप से WordArt बना, अनुकूलित और प्रबंधित कर सकते हैं, बिल्कुल Microsoft PowerPoint की तरह—बिना Office स्थापित किए। यह लेख WordArt के साथ काम करने का एक अवलोकन प्रदान करता है, जिसमें टेक्स्ट ट्रांसफ़ॉर्मेशन, फिल शैली, आउटलाइन, छाया और अन्य फ़ॉर्मेटिंग विकल्प लागू करने के तरीके शामिल हैं, ताकि आपकी प्रस्तुति सामग्री अधिक अभिव्यक्त और आकर्षक बन सके। WordArt आपको टेक्स्ट को एक ग्राफ़िकल ऑब्जेक्ट के रूप में मानने की अनुमति देता है। यह प्रभाव या विशेष संशोधनों से बना होता है जो टेक्स्ट को अधिक आकर्षक या उल्लेखनीय बनाते हैं।

## **एक साधारण WordArt टेम्पलेट बनाएं और इसे टेक्स्ट पर लागू करें**

**Aspose.Slides का उपयोग करके** 

सबसे पहले, हम इस Java कोड का उपयोग करके एक साधारण टेक्स्ट बनाते हैं:

``` java
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
अब, हम इस कोड के माध्यम से प्रभाव को अधिक स्पष्ट बनाने के लिए टेक्स्ट का फ़ॉन्ट ऊँचाई बड़ा सेट करते हैं:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Microsoft PowerPoint का उपयोग करके**

Microsoft PowerPoint में WordArt प्रभाव मेनू पर जाएँ:

![todo:image_alt_text](image-20200930113926-1.png)

दाएँ मेनू से आप एक पूर्वनिर्धारित WordArt प्रभाव चुन सकते हैं। बाएँ मेनू से आप नए WordArt के सेटिंग्स निर्दिष्ट कर सकते हैं।

यहाँ कुछ उपलब्ध पैरामीटर या विकल्प हैं:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides का उपयोग करके**

यहाँ, हम टेक्स्ट पर [SmallGrid](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PatternStyle#SmallGrid) पैटर्न रंग लागू करते हैं और इस कोड का उपयोग करके 1‑पिक्सेल चौड़ी काली टेक्स्ट बॉर्डर जोड़ते हैं:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

परिणामस्वरूप टेक्स्ट:

![todo:image_alt_text](image-20200930114108-4.png)

## **अन्य WordArt प्रभाव लागू करें**

**Microsoft PowerPoint का उपयोग करके**

प्रोग्राम के इंटरफ़ेस से आप इन प्रभावों को टेक्स्ट, टेक्स्ट ब्लॉक, आकार या समान तत्व पर लागू कर सकते हैं:

![todo:image_alt_text](image-20200930114129-5.png)

उदाहरण के लिए, Shadow, Reflection, और Glow प्रभाव टेक्स्ट पर लागू किए जा सकते हैं; 3D फ़ॉर्मेट और 3D रोटेशन प्रभाव टेक्स्ट ब्लॉक पर लागू किए जा सकते हैं; Soft Edges गुण Shape ऑब्जेक्ट पर लागू किया जा सकता है (भले ही 3D फ़ॉर्मेट गुण सेट न हो)।

### **छाया प्रभाव लागू करें**

यहाँ, हम केवल टेक्स्ट से संबंधित गुण सेट करना चाहते हैं। हम इस Java कोड का उपयोग करके टेक्स्ट पर छाया प्रभाव लागू करते हैं:

``` java
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
```

Aspose.Slides API तीन प्रकार की छायाओं का समर्थन करता है: OuterShadow, InnerShadow, और PresetShadow।

PresetShadow के साथ, आप प्रीसेट मानों का उपयोग करके टेक्स्ट पर छाया लागू कर सकते हैं।

**Microsoft PowerPoint का उपयोग करके**

PowerPoint में आप एक प्रकार की छाया का उपयोग कर सकते हैं। यहाँ एक उदाहरण है:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides का उपयोग करके**

Aspose.Slides वास्तव में दो प्रकार की छायाएँ एक साथ लागू करने की अनुमति देता है: InnerShadow और PresetShadow।

**नोट्स:**
- जब OuterShadow और PresetShadow एक साथ उपयोग किए जाते हैं, तो केवल OuterShadow प्रभाव लागू होता है। 
- यदि OuterShadow और InnerShadow एक साथ उपयोग किए जाते हैं, तो लागू प्रभाव PowerPoint संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में प्रभाव दोगुना हो जाता है, जबकि PowerPoint 2007 में OuterShadow प्रभाव लागू होता है।

### **टेक्स्ट पर परावर्तन प्रभाव लागू करें**

हम इस Java कोड नमूने के माध्यम से टेक्स्ट में परावर्तन जोड़ते हैं:

``` java
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
```

### **टेक्स्ट पर ग्लो प्रभाव लागू करें**

हम इस कोड का उपयोग करके टेक्स्ट पर ग्लो प्रभाव लागू करते हैं ताकि वह चमके या उभरे:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

ऑपरेशन का परिणाम:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

आप छाया, परावर्तन और ग्लो के पैरामीटर बदल सकते हैं। प्रभावों की प्रॉपर्टी प्रत्येक टेक्स्ट भाग पर अलग‑अलग सेट होती है। 

{{% /alert %}} 

### **WordArt में ट्रांसफ़ॉर्मेशन का उपयोग करें**

हम इस कोड के माध्यम से Transform प्रॉपर्टी (पूरा टेक्स्ट ब्लॉक में निहित) का उपयोग करते हैं:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

परिणाम:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint और Aspose.Slides for Android via Java दोनों कुछ पूर्वनिर्धारित ट्रांसफ़ॉर्मेशन प्रकार प्रदान करते हैं। 

{{% /alert %}} 

**PowerPoint का उपयोग करके**

पूर्वनिर्धारित ट्रांसफ़ॉर्मेशन प्रकार तक पहुँचने के लिए जाएँ: **Format** -> **TextEffect** -> **Transform**

**Aspose.Slides का उपयोग करके**

ट्रांसफ़ॉर्मेशन प्रकार चुनने के लिए TextShapeType enum का उपयोग करें। 

### **टेक्स्ट और आकृतियों पर 3D प्रभाव लागू करें**

हम इस नमूना कोड का उपयोग करके टेक्स्ट आकार पर 3D प्रभाव सेट करते हैं:

``` java
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
```

परिणामस्वरूप टेक्स्ट और उसका आकार:

![todo:image_alt_text](image-20200930114816-9.png)

हम इस Java कोड के साथ टेक्स्ट पर 3D प्रभाव लागू करते हैं:

``` java
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
```

ऑपरेशन का परिणाम:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

टेक्स्ट या उनके आकार पर 3D प्रभावों का प्रयोग और प्रभावों के बीच अन्तःक्रिया कुछ नियमों पर आधारित होती है। 

एक दृश्य को टेक्स्ट और उसे सम्मिलित करने वाले आकार के रूप में विचार करें। 3D प्रभाव में 3D ऑब्जेक्ट प्रतिनिधित्व और वह दृश्य शामिल है जहाँ ऑब्जेक्ट रखा गया है। 

- जब दोनों आकृति और टेक्स्ट के लिए दृश्य निर्धारित हो, तो आकृति का दृश्य उच्च प्राथमिकता लेता है—टेक्स्ट का दृश्य अनदेखा किया जाता है। 
- जब आकृति का अपना दृश्य नहीं है लेकिन 3D प्रतिनिधित्व है, तो टेक्स्ट का दृश्य उपयोग होता है। 
- अन्यथा—जब आकार में मूल रूप से कोई 3D प्रभाव नहीं है—तो आकार समतल रहता है और 3D प्रभाव केवल टेक्स्ट पर लागू होता है। 

ये विवरण ThreeDFormat.getLightRig() और ThreeDFormat.getCamera() मेथड्स से जुड़े हैं। 

{{% /alert %}} 

## **टेक्स्ट पर बाहरी छाया प्रभाव लागू करें**
Aspose.Slides for Android via Java [**IOuterShadow**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioutershadow/) और [**IInnerShadow**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iinnershadow/) क्लासेस प्रदान करता है जो आपको [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) द्वारा ले जा रहे टेक्स्ट पर छाया प्रभाव लागू करने की अनुमति देते हैं। इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड में Rectangle प्रकार का एक AutoShape जोड़ें।  
4. AutoShape से जुड़ा TextFrame प्राप्त करें।  
5. AutoShape की FillType को NoFill पर सेट करें।  
6. OuterShadow क्लास का इंस्टेंशन बनाएं।  
7. छाया का BlurRadius सेट करें।  
8. छाया की Direction सेट करें।  
9. छाया की Distance सेट करें।  
10. RectanglelAlign को TopLeft पर सेट करें।  
11. छाया का PresetColor Black पर सेट करें।  
12. प्रेजेंटेशन को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  

इस Java नमूना कोड में उपरोक्त चरण दिखाए गए हैं और यह टेक्स्ट पर बाहरी छाया प्रभाव लागू करता है:

```java
Presentation pres = new Presentation();
try {
    // स्लाइड का रेफरेंस प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // Rectangle प्रकार का AutoShape जोड़ें
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle में TextFrame जोड़ें
    ashp.addTextFrame("Aspose TextBox");

    // यदि हम टेक्स्ट की छाया प्राप्त करना चाहते हैं, तो shape fill को अक्षम करें
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // बाहरी छाया जोड़ें और सभी आवश्यक पैरामीटर सेट करें
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // प्रेजेंटेशन को डिस्क पर लिखें
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **आकृतियों पर आंतरिक छाया प्रभाव लागू करें**
इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।  
2. स्लाइड का रेफ़रेंस प्राप्त करें।  
3. Rectangle प्रकार का एक AutoShape जोड़ें।  
4. InnerShadowEffect को सक्षम करें।  
5. सभी आवश्यक पैरामीटर सेट करें।  
6. ColorType को Scheme पर सेट करें।  
7. Scheme रंग सेट करें।  
8. प्रेजेंटेशन को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  

यह नमूना कोड (ऊपर दिए गए चरणों पर आधारित) Java में दो आकारों के बीच कनेक्टर जोड़ने का तरीका दिखाता है:

```java
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

    // ColorType को Scheme के रूप में सेट करें
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme रंग सेट करें
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // प्रस्तुति सहेजें
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या मैं विभिन्न फ़ॉन्ट या स्क्रिप्ट (जैसे अरबी, चीनी) के साथ WordArt प्रभाव उपयोग कर सकता हूँ?**

हां, Aspose.Slides यूनिकोड का समर्थन करता है और सभी प्रमुख फ़ॉन्ट और स्क्रिप्ट के साथ काम करता है। Shadow, Fill और Outline जैसे WordArt प्रभाव भाषा की परवाह किए बिना लागू किए जा सकते हैं, हालांकि फ़ॉन्ट उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट पर निर्भर हो सकती है।

**क्या मैं स्लाइड मास्टर तत्वों पर WordArt प्रभाव लागू कर सकता हूँ?**

हां, आप मास्टर स्लाइड पर स्थित आकारों, जैसे टाइटल प्लेसहोल्डर, फुटर या बैकग्राउंड टेक्स्ट पर WordArt प्रभाव लागू कर सकते हैं। मास्टर लेआउट में किए गए परिवर्तन सभी संबंधित स्लाइडों में प्रतिबिंबित होंगे।

**क्या WordArt प्रभाव प्रस्तुति फ़ाइल के आकार को प्रभावित करते हैं?**

थोड़ा सा। Shadows, Glows और Gradient Fill जैसे WordArt प्रभाव अतिरिक्त फ़ॉर्मेटिंग मेटाडेटा जोड़ने के कारण फ़ाइल आकार में हल्का वृद्धि कर सकते हैं, लेकिन अंतर आमतौर पर नगण्य रहता है।

**क्या मैं प्रस्तुति को सेव किए बिना WordArt प्रभाव का परिणाम पूर्वावलोकन कर सकता हूँ?**

हां, आप [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) या [ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) इंटरफ़ेस के `getImage` मेथड का उपयोग करके WordArt वाले स्लाइड को PNG या JPEG जैसी इमेज में रेंडर कर सकते हैं। यह आपको पूरी फ़ाइल को सेव या एक्सपोर्ट करने से पहले मेमोरी या स्क्रीन पर परिणाम का पूर्वावलोकन करने देता है।