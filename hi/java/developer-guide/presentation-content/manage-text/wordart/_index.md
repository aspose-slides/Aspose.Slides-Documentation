---
title: Java में WordArt प्रभाव बनाएं और लागू करें
linktitle: वर्डआर्ट
type: docs
weight: 110
url: /hi/java/wordart/
keywords:
- वर्डआर्ट
- वर्डआर्ट बनाना
- वर्डआर्ट टेम्पलेट
- वर्डआर्ट प्रभाव
- शैडो प्रभाव
- डिस्प्ले प्रभाव
- ग्लो प्रभाव
- वर्डआर्ट ट्रांसफ़ॉर्मेशन
- 3D प्रभाव
- बाहरी शैडो प्रभाव
- आंतरिक शैडो प्रभाव
- पावरपॉइंट
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में WordArt प्रभाव बनाएं और अनुकूलित करें। यह चरण‑दर‑चरण गाइड डेवलपर्स को Java में पेशेवर टेक्स्ट के साथ प्रस्तुतियों को बेहतर बनाने में मदद करता है।"
---
## **सारांश**

WordArt प्रभाव आपको अपने PowerPoint प्रस्तुतियों में दृश्यात्मक रूप से आकर्षक, शैलीबद्ध टेक्स्ट जोड़ने की अनुमति देते हैं। Aspose.Slides के साथ, डेवलपर्स प्रोग्रामैटिक रूप से WordArt को बनाए, अनुकूलित और प्रबंधित कर सकते हैं, बिल्कुल Microsoft PowerPoint की तरह—बिना Office स्थापित किए। यह लेख WordArt के साथ काम करने का एक सारांश प्रदान करता है, जिसमें टेक्स्ट ट्रांसफ़ॉर्मेशन, फ़िल स्टाइल, आउटलाइन, शैडो और अन्य फ़ॉर्मेटिंग विकल्पों को लागू करने की विधियाँ शामिल हैं, ताकि आपके प्रस्तुति सामग्री अधिक अभिव्यक्तिपूर्ण और आकर्षक बन सके। WordArt आपको टेक्स्ट को एक ग्राफ़िकल ऑब्जेक्ट की तरह मानने की अनुमति देता है। यह प्रभावों या विशेष संशोधनों से बनता है जो टेक्स्ट को अधिक आकर्षक या उल्लेखनीय बनाते हैं।

## **एक सरल WordArt टेम्पलेट बनाना और इसे टेक्स्ट पर लागू करना**

**Aspose.Slides का उपयोग करके** 

पहले, हम इस Java कोड का उपयोग करके एक साधा टेक्स्ट बनाते हैं: 

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
अब, हम इस कोड के द्वारा टेक्स्ट का फ़ॉन्ट आकार बड़ा सेट करते हैं जिससे प्रभाव अधिक दर्शनीय हो। 

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Microsoft PowerPoint का उपयोग करके**

Microsoft PowerPoint में WordArt प्रभाव मेनू पर जाएँ:

![todo:image_alt_text](image-20200930113926-1.png)

दाएँ वाले मेनू से आप एक पूर्वनिर्धारित WordArt प्रभाव चुन सकते हैं। बाएँ वाले मेनू से आप नए WordArt के सेटिंग्स निर्दिष्ट कर सकते हैं। 

ये उपलब्ध पैरामीटर या विकल्पों में से कुछ हैं:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides का उपयोग करके**

यहाँ, हम टेक्स्ट पर [SmallGrid](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PatternStyle#SmallGrid) पैटर्न रंग लागू करते हैं और इस कोड के द्वारा 1‑पिक्सेल चौड़ाई की काली टेक्स्ट बॉर्डर जोड़ते हैं:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

परिणामी टेक्स्ट:

![todo:image_alt_text](image-20200930114108-4.png)

## **अन्य WordArt प्रभाव लागू करना**

**Microsoft PowerPoint का उपयोग करके**

प्रोग्राम के इंटरफ़ेस से आप इन प्रभावों को टेक्स्ट, टेक्स्ट ब्लॉक, आकार या समान तत्व पर लागू कर सकते हैं:

![todo:image_alt_text](image-20200930114129-5.png)

उदाहरण के लिए, Shadow, Reflection और Glow प्रभाव टेक्स्ट पर लागू हो सकते हैं; 3D Format और 3D Rotation प्रभाव टेक्स्ट ब्लॉक पर लागू हो सकते हैं; Soft Edges प्रॉपर्टी Shape ऑब्जेक्ट पर लागू की जा सकती है (जब 3D Format प्रॉपर्टी सेट नहीं होती तब भी इसका प्रभाव रहता है)।

### **Shadow प्रभाव लागू करना**

यहाँ, हम केवल टेक्स्ट से संबंधित गुण सेट करने का इरादा रखते हैं। हम इस Java कोड का उपयोग करके टेक्स्ट पर शैडो प्रभाव लागू करते हैं:

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

Aspose.Slides API तीन प्रकार के शैडो को सपोर्ट करता है: OuterShadow, InnerShadow, और PresetShadow। 

PresetShadow के साथ, आप टेक्स्ट पर (प्रिसेट मानों का उपयोग करके) शैडो लागू कर सकते हैं। 

**Microsoft PowerPoint का उपयोग करके**

PowerPoint में आप एक प्रकार का शैडो उपयोग कर सकते हैं। यहाँ एक उदाहरण है:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides का उपयोग करके**

Aspose.Slides वास्तव में एक साथ दो प्रकार के शैडो लागू करने की अनुमति देता है: InnerShadow और PresetShadow।

**Notes:**
- जब OuterShadow और PresetShadow एक साथ उपयोग किए जाते हैं, तो केवल OuterShadow प्रभाव लागू होता है। 
- यदि OuterShadow और InnerShadow एक साथ उपयोग होते हैं, तो लागू प्रभाव PowerPoint के संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में प्रभाव दो गुना हो जाता है, जबकि PowerPoint 2007 में OuterShadow प्रभाव लागू होता है। 

### **डिस्प्ले प्रभाव को टेक्स्ट पर लागू करना**

हम इस Java कोड नमूने के द्वारा टेक्स्ट में डिस्प्ले जोड़ते हैं:

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

### **टेक्स्ट पर Glow प्रभाव लागू करना**

हम इस कोड का उपयोग करके टेक्स्ट पर ग्लो प्रभाव लागू करते हैं ताकि वह चमके या उभरे।

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

ऑपरेशन का परिणाम:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
आप शैडो, डिस्प्ले और ग्लो के पैरामीटर बदल सकते हैं। प्रभावों की प्रॉपर्टी प्रत्येक टेक्स्ट हिस्से में अलग‑अलग सेट की जाती है। 
{{% /alert %}} 

### **WordArt में Transformations का उपयोग करना**

हम इस कोड के द्वारा Transform प्रॉपर्टी (पूरे टेक्स्ट ब्लॉक में अंतर्निहित) का उपयोग करते हैं:

``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

परिणाम:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint और Aspose.Slides for Java दोनों कुछ पूर्वनिर्धारित ट्रांसफ़ॉर्मेशन प्रकार प्रदान करते हैं। 
{{% /alert %}} 

**PowerPoint का उपयोग करके**

पूर्वनिर्धारित ट्रांसफ़ॉर्मेशन प्रकारों तक पहुँचने के लिए, निम्नरूप देखें: **Format** -> **TextEffect** -> **Transform**

**Aspose.Slides का उपयोग करके**

ट्रांसफ़ॉर्मेशन प्रकार चुनने के लिए, TextShapeType enum का उपयोग करें। 

### **टेक्स्ट और आकार पर 3D प्रभाव लागू करना**

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

परिणामी टेक्स्ट और उसका आकार:

![todo:image_alt_text](image-20200930114816-9.png)

हम इस Java कोड के द्वारा टेक्स्ट पर 3D प्रभाव लागू करते हैं:

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
टेक्स्ट या उनके आकार पर 3D प्रभावों का अनुप्रयोग और प्रभावों के बीच की इंटरैक्शन कुछ नियमों पर आधारित होते हैं। 

एक टेक्स्ट और उसे सम्मिलित करने वाले आकार के लिए एक सीन पर विचार करें। 3D प्रभाव में 3D ऑब्जेक्ट प्रतिनिधित्व और वह सीन शामिल होता है जिस पर ऑब्जेक्ट रखा गया है। 

- जब सीन दोनों आकृति और टेक्स्ट दोनों के लिए सेट होता है, तो आकृति का सीन अधिक प्राथमिकता प्राप्त करता है—टेक्स्ट सीन अनदेखा किया जाता है। 
- जब आकृति का अपना सीन नहीं होता लेकिन उसका 3D प्रतिनिधित्व होता है, तो टेक्स्ट सीन उपयोग किया जाता है। 
- अन्यथा—जब आकार मूल रूप से कोई 3D प्रभाव नहीं रखता—तो आकार समतल रहता है और 3D प्रभाव केवल टेक्स्ट पर लागू होता है। 

इन विवरणों का संबंध ThreeDFormat.getLightRig() और ThreeDFormat.getCamera() मेथड्स से है। 
{{% /alert %}} 

## **टेक्स्ट पर Outer Shadow प्रभाव लागू करना**
Aspose.Slides for Java [**IOuterShadow**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioutershadow/) और [**IInnerShadow**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinnershadow/) क्लासें प्रदान करता है जो आपको [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) द्वारा ले जा रहे टेक्स्ट पर शैडो प्रभाव लागू करने देती हैं। निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टैंस बनाएं।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड में Rectangle प्रकार का AutoShape जोड़ें।  
4. AutoShape से जुड़ा TextFrame प्राप्त करें।  
5. AutoShape का FillType NoFill सेट करें।  
6. OuterShadow क्लास का इंस्टैंस बनाएं।  
7. शैडो का BlurRadius सेट करें।  
8. शैडो की Direction सेट करें।  
9. शैडो की Distance सेट करें।  
10. RectanglelAlign को TopLeft सेट करें।  
11. शैडो का PresetColor Black सेट करें।  
12. प्रेज़ेंटेशन को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  

यह Java नमूना कोड—ऊपर बताए गए चरणों का कार्यान्वयन—आपको दिखाता है कि टेक्स्ट पर Outer Shadow प्रभाव कैसे लागू करें:

```java
Presentation pres = new Presentation();
try {
    // स्लाइड का रेफ़रेंस प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // Rectangle प्रकार का AutoShape जोड़ें
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle में TextFrame जोड़ें
    ashp.addTextFrame("Aspose TextBox");

    // यदि हमें टेक्स्ट का शैडो चाहिए तो shape fill को निष्क्रिय करें
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // बाहरी शैडो जोड़ें और सभी आवश्यक पैरामीटर सेट करें
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // प्रेज़ेंटेशन को डिस्क पर सहेजें
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **आकार पर Inner Shadow प्रभाव लागू करना**
निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टैंस बनाएं।  
2. स्लाइड का रेफ़रेंस प्राप्त करें।  
3. Rectangle प्रकार का AutoShape जोड़ें।  
4. InnerShadowEffect सक्षम करें।  
5. सभी आवश्यक पैरामीटर सेट करें।  
6. ColorType को Scheme सेट करें।  
7. Scheme Color सेट करें।  
8. प्रेज़ेंटेशन को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  

यह नमूना कोड (ऊपर के चरणों के आधार पर) आपको दिखाता है कि Java में दो आकारों के बीच कनेक्टर कैसे जोड़ें:

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

    // ColorType को Scheme सेट करें
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme Color सेट करें
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // प्रेज़ेंटेशन सहेजें
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या मैं विभिन्न फ़ॉन्ट या स्क्रिप्ट (जैसे अरबी, चीनी) के साथ WordArt प्रभाव उपयोग कर सकता हूँ?**

हाँ, Aspose.Slides Unicode को सपोर्ट करता है और सभी प्रमुख फ़ॉन्ट एवं स्क्रिप्ट के साथ काम करता है। WordArt प्रभाव जैसे शैडो, फ़िल और आउटलाइन भाषा की परवाह किए बिना लागू किए जा सकते हैं, हालांकि फ़ॉन्ट उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट्स पर निर्भर हो सकती है।

**क्या मैं स्लाइड मास्टर तत्वों पर WordArt प्रभाव लागू कर सकता हूँ?**

हाँ, आप मास्टर स्लाइड्स पर स्थित आकारों, जैसे शीर्षक प्लेसहोल्डर, फूटर या बैकग्राउंड टेक्स्ट पर WordArt प्रभाव लागू कर सकते हैं। मास्टर लेआउट में किए गए परिवर्तन सभी संबंधित स्लाइड्स पर प्रतिबिंबित होंगे।

**क्या WordArt प्रभाव प्रस्तुति फ़ाइल के आकार को प्रभावित करते हैं?**

थोड़ा। शैडो, ग्लो और ग्रेडिएंट फ़िल जैसे WordArt प्रभाव फ़ॉर्मेटिंग मेटा‑डेटा जोड़ने के कारण फ़ाइल आकार को थोड़ा बढ़ा सकते हैं, लेकिन अंतर आमतौर पर नगण्य होता है।

**क्या मैं प्रस्तुति को सहेजे बिना WordArt प्रभावों का परिणाम पूर्वावलोकन कर सकता हूँ?**

हाँ, आप [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) या [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) इंटरफ़ेस के `getImage` मेथड का उपयोग करके WordArt वाले स्लाइड्स को छवियों (जैसे PNG, JPEG) में रेंडर कर सकते हैं। इससे आप पूर्ण प्रस्तुति को सहेजने या एक्सपोर्ट करने से पहले मेमोरी या स्क्रीन पर परिणाम का पूर्वावलोकन कर सकते हैं।