---
title: जावास्क्रिप्ट में WordArt प्रभाव बनाएं और लागू करें
linktitle: WordArt
type: docs
weight: 110
url: /hi/nodejs-java/wordart/
keywords:
- WordArt
- WordArt बनाएं
- WordArt टेम्प्लेट
- WordArt प्रभाव
- छाया प्रभाव
- डिस्प्ले प्रभाव
- ग्लो प्रभाव
- WordArt परिवर्तन
- 3D प्रभाव
- बाहरी छाया प्रभाव
- आंतरिक छाया प्रभाव
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में WordArt प्रभाव बनाएं और कस्टमाइज़ करें। यह चरण-दर-चरण गाइड डेवलपर्स को पेशेवर पाठ के साथ प्रस्तुतियों को बेहतर बनाने में मदद करता है।"
---
## **अवलोकन**

WordArt इफ़ेक्ट्स आपको अपनी PowerPoint प्रस्तुतियों में दृश्यात्मक रूप से आकर्षक, शैलीबद्ध पाठ जोड़ने की अनुमति देते हैं। Aspose.Slides के साथ, डेवलपर्स प्रोग्रामेटिक रूप से WordArt को बना, अनुकूलित और प्रबंधित कर सकते हैं, बिल्कुल Microsoft PowerPoint की तरह—बिना Office स्थापित किए। यह लेख WordArt के साथ काम करने का एक अवलोकन प्रदान करता है, जिसमें पाठ रूपांतरण, भराव शैलियाँ, रूपरेखा, छायाएँ और अन्य स्वरूपण विकल्प लागू करने के बारे में बताया गया है ताकि आपकी प्रस्तुति सामग्री अधिक अभिव्यक्तिपूर्ण और आकर्षक बन सके। WordArt आपको पाठ को एक ग्राफ़िकल ऑब्जेक्ट के रूप में व्यवहार करने की सुविधा देता है। यह प्रभावों या विशेष संशोधनों का संग्रह है जो पाठ को अधिक आकर्षक या ध्यानाकर्षक बनाने के लिए लागू किए जाते हैं।

## **एक साधारण WordArt टेम्प्लेट बनाना और इसे पाठ पर लागू करना**

**Using Aspose.Slides** 

पहले, हम इस JavaScript कोड का उपयोग करके एक साधारण पाठ बनाते हैं:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
अब, हम इस कोड के माध्यम से प्रभाव को अधिक स्पष्ट बनाने के लिए पाठ के फ़ॉन्ट की ऊँचाई को बड़ा मान सेट करते हैं:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Using Microsoft PowerPoint**

Microsoft PowerPoint में WordArt इफ़ेक्ट्स मेनू पर जाएँ:

![todo:image_alt_text](image-20200930113926-1.png)

दाएँ मेनू से, आप एक पूर्वनिर्धारित WordArt इफ़ेक्ट चुन सकते हैं। बाएँ मेनू से, आप नए WordArt के सेटिंग्स निर्दिष्ट कर सकते हैं।

ये कुछ उपलब्ध पैरामीटर या विकल्प हैं:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

यहाँ, हम पाठ पर [SmallGrid](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PatternStyle#SmallGrid) पैटर्न रंग लागू करते हैं और इस कोड के द्वारा 1‑पिक्सेल चौड़ाई वाली काली पाठ सीमा जोड़ते हैं:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

परिणामी पाठ:

![todo:image_alt_text](image-20200930114108-4.png)

## **अन्य WordArt इफ़ेक्ट्स लागू करना**

**Using Microsoft PowerPoint**

प्रोग्राम की क्लास से आप इन इफ़ेक्ट्स को पाठ, पाठ ब्लॉक, आकार या समान तत्व पर लागू कर सकते हैं:

![todo:image_alt_text](image-20200930114129-5.png)

उदाहरण के लिए, Shadow, Reflection और Glow इफ़ेक्ट्स किसी पाठ पर लागू किए जा सकते हैं; 3D Format और 3D Rotation इफ़ेक्ट्स पाठ ब्लॉक पर लागू किए जा सकते हैं; Soft Edges प्रॉपर्टी Shape ऑब्जेक्ट पर लागू की जा सकती है (यह तब भी प्रभावी रहती है जब कोई 3D Format प्रॉपर्टी सेट न हो)।

### **Shadow इफ़ेक्ट्स लागू करना**

यहाँ, हम केवल पाठ से संबंधित प्रॉपर्टीज़ सेट करने का इरादा रखते हैं। हम इस JavaScript कोड के द्वारा पाठ पर छाया इफ़ेक्ट लागू करते हैं:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

Aspose.Slides API तीन प्रकार की छायाओं का समर्थन करता है: OuterShadow, InnerShadow और PresetShadow।

PresetShadow के साथ, आप पूर्वनिर्धारित मानों का उपयोग करके पाठ के लिए छाया लागू कर सकते हैं।

**Using Microsoft PowerPoint**

PowerPoint में, आप एक प्रकार की छाया का उपयोग कर सकते हैं। यहाँ एक उदाहरण है:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides वास्तव में आपको एक साथ दो प्रकार की छायाएँ लागू करने की अनुमति देता है: InnerShadow और PresetShadow।

**Notes:**

- जब OuterShadow और PresetShadow दोनों साथ में उपयोग होते हैं, तो केवल OuterShadow इफ़ेक्ट लागू होता है।  
- यदि OuterShadow और InnerShadow एक साथ उपयोग होते हैं, तो लागू इफ़ेक्ट PowerPoint के संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में इफ़ेक्ट दोगुना हो जाता है। लेकिन PowerPoint 2007 में OuterShadow इफ़ेक्ट लागू होता है।  

### **पाठों पर Display लागू करना**

हम इस JavaScript कोड नमूने के द्वारा पाठ में display जोड़ते हैं:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **पाठों पर Glow इफ़ेक्ट लागू करना**

हम इस कोड का उपयोग करके पाठ पर चमक (Glow) इफ़ेक्ट लागू करते हैं जिससे वह चमके या अधिक स्पष्ट दिखे:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

ऑपरेशन का परिणाम:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

आप छाया, display और glow के पैरामीटर बदल सकते हैं। प्रभावों की प्रॉपर्टीज़ प्रत्येक पाठ भाग पर अलग‑अलग सेट की जाती हैं। 

{{% /alert %}} 

### **WordArt में Transformations का उपयोग करना**

हम इस कोड के द्वारा Transform प्रॉपर्टी (पूरे पाठ ब्लॉक में निहित) का उपयोग करते हैं:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

परिणाम:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint और Aspose.Slides for Node.js via Java दोनों कुछ पूर्वनिर्धारित रूपांतरण प्रकार प्रदान करते हैं।

{{% /alert %}} 

**Using PowerPoint**

पूर्वनिर्धारित रूपांतरण प्रकार तक पहुँचने के लिए, **Format** -> **TextEffect** -> **Transform** पर जाएँ।

**Using Aspose.Slides**

रूपांतरण प्रकार चुनने के लिये, TextShapeType enum का उपयोग करें।

### **पाठों और आकारों पर 3D इफ़ेक्ट्स लागू करना**

हम इस नमूना कोड के द्वारा पाठ आकार पर 3D इफ़ेक्ट सेट करते हैं:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

परिणामी पाठ और उसका आकार:

![todo:image_alt_text](image-20200930114816-9.png)

हम इस JavaScript कोड के द्वारा पाठ पर 3D इफ़ेक्ट लागू करते हैं:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

ऑपरेशन का परिणाम:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

पाठों या उनके आकारों पर 3D इफ़ेक्ट्स का अनुप्रयोग तथा इफ़ेक्ट्स के बीच अंतःक्रिया कुछ नियमों पर आधारित है। 

एक दृश्य को पाठ और उस पाठ को शामिल करने वाले आकार के लिए विचार करें। 3D इफ़ेक्ट में 3D ऑब्जेक्ट प्रस्तुति और वह दृश्य शामिल होता है जहाँ ऑब्जेक्ट रखा गया है। 

- जब दृश्य दोनों आकृति और पाठ दोनों के लिए सेट किया जाता है, तो आकृति का दृश्य उच्च प्राथमिकता लेता है—पाठ का दृश्य अनदेखा किया जाता है।  
- जब आकृति का अपना दृश्य नहीं होता लेकिन 3D प्रस्तुति होती है, तो पाठ का दृश्य उपयोग किया जाता है।  
- अन्यथा—जब मूल रूप से आकार में कोई 3D इफ़ेक्ट नहीं होता—आकार सपाट रहता है और 3D इफ़ेक्ट केवल पाठ पर लागू होता है।  

ये विवरण ThreeDFormat.getLightRig() और ThreeDFormat.getCamera() मेथड्स से संबंधित हैं। 

{{% /alert %}} 

## **पाठों पर Outer Shadow इफ़ेक्ट लागू करना**

Aspose.Slides for Node.js via Java, [**OuterShadow**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/outershadow/) और [**InnerShadow**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/innershadow/) क्लासेज प्रदान करता है जो आपको [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) द्वारा धारण किए गए पाठ पर छाया इफ़ेक्ट लागू करने की अनुमति देते हैं। इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।  
2. उसके इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड में Rectangle प्रकार का एक AutoShape जोड़ें।  
4. AutoShape से जुड़ा TextFrame एक्सेस करें।  
5. AutoShape की FillType को NoFill सेट करें।  
6. OuterShadow क्लास का इंस्टैंस बनाएँ।  
7. छाया का BlurRadius सेट करें।  
8. छाया की Direction सेट करें।  
9. छाया की Distance सेट करें।  
10. RectanglelAlign को TopLeft सेट करें।  
11. छाया का PresetColor को Black सेट करें।  
12. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  

इन चरणों का जावा में कार्यान्वयन दिखाने वाला नमूना कोड यह दर्शाता है कि कैसे पाठ पर outer shadow इफ़ेक्ट लागू किया जाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // स्लाइड का संदर्भ प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // Rectangle प्रकार का AutoShape जोड़ें
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Rectangle में TextFrame जोड़ें
    ashp.addTextFrame("Aspose TextBox");
    // यदि हम पाठ की छाया प्राप्त करना चाहते हैं तो आकार की भराव को निष्क्रिय करें
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // बाहरी छाया जोड़ें और सभी आवश्यक पैरामीटर सेट करें
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // प्रस्तुति को डिस्क पर लिखें
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Shapes पर Inner Shadow इफ़ेक्ट लागू करना**

इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।  
2. स्लाइड का रेफ़रेंस प्राप्त करें।  
3. Rectangle प्रकार का एक AutoShape जोड़ें।  
4. InnerShadowEffect को सक्षम करें।  
5. सभी आवश्यक पैरामीटर सेट करें।  
6. ColorType को Scheme सेट करें।  
7. Scheme Color सेट करें।  
8. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  

ऊपर दिए गए चरणों के आधार पर यह नमूना कोड आपको JavaScript में दो आकारों के बीच कनेक्टर जोड़ने का तरीका दिखाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // स्लाइड का संदर्भ प्राप्त करें
    var slide = pres.getSlides().get_Item(0);
    // Rectangle प्रकार का AutoShape जोड़ें
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Rectangle में TextFrame जोड़ें
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // InnerShadowEffect को सक्षम करें
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // सभी आवश्यक पैरामीटर सेट करें
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // ColorType को Scheme के रूप में सेट करें
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Scheme रंग सेट करें
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // प्रस्तुति सहेजें
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं WordArt इफ़ेक्ट्स को विभिन्न फ़ॉन्ट्स या स्क्रिप्ट्स (जैसे, अरबी, चीनी) के साथ उपयोग कर सकता हूँ?**

हाँ, Aspose.Slides Unicode का समर्थन करता है और सभी प्रमुख फ़ॉन्ट्स और स्क्रिप्ट्स के साथ काम करता है। WordArt इफ़ेक्ट्स जैसे shadow, fill और outline भाषा की परवाह किए बिना लागू किए जा सकते हैं; हालाँकि फ़ॉन्ट उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट्स पर निर्भर हो सकती है।

**क्या मैं WordArt इफ़ेक्ट्स को स्लाइड मास्टर तत्वों पर लागू कर सकता हूँ?**

हाँ, आप मास्टर स्लाइड्स पर आकारों, जैसे शीर्षक प्लेसहोल्डर, फुटर या बैकग्राउंड टेक्स्ट पर WordArt इफ़ेक्ट्स लागू कर सकते हैं। मास्टर लेआउट में किए गए परिवर्तन सभी सम्बंधित स्लाइड्स में परिलक्षित होते हैं।

**क्या WordArt इफ़ेक्ट्स प्रस्तुति फ़ाइल के आकार को प्रभावित करते हैं?**

हलक़े से। शैडो, ग्लो और ग्रेडिएंट फ़िल जैसे WordArt इफ़ेक्ट्स अतिरिक्त स्वरूपण मेटाडाटा जोड़ते हैं, जिससे फ़ाइल आकार थोड़ा बढ़ सकता है, लेकिन अंतर आमतौर पर नगण्य होता है।

**क्या मैं WordArt इफ़ेक्ट्स के परिणाम को सहेजे बिना पूर्वावलोकन कर सकता हूँ?**

हाँ, आप [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) या [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/) क्लास के `getImage` मेथड का उपयोग करके WordArt सहित स्लाइड्स को छवियों (जैसे PNG, JPEG) में रेंडर कर सकते हैं। यह आपको संपूर्ण प्रस्तुति को सहेजने या निर्यात करने से पहले मेमोरी या स्क्रीन पर परिणाम का पूर्वावलोकन करने देता है।