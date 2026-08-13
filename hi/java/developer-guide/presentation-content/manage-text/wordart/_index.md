---
title: Java में WordArt प्रभाव बनाएं और लागू करें
linktitle: WordArt
type: docs
weight: 110
url: /hi/java/wordart/
keywords:
- WordArt
- WordArt बनाएं
- WordArt टेम्प्लेट
- WordArt प्रभाव
- छाया प्रभाव
- डिस्प्ले प्रभाव
- ग्लो प्रभाव
- WordArt रूपांतरण
- 3D प्रभाव
- बाहरी छाया प्रभाव
- आंतरिक छाया प्रभाव
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में WordArt प्रभाव बनाएं और अनुकूलित करें। यह चरण-दर-चरण मार्गदर्शिका डेवलपर्स को Java में पेशेवर पाठ के साथ प्रस्तुतियों को बेहतर बनाने में मदद करती है।"
---
## **अवलोकन**

WordArt प्रभाव आपको अपने PowerPoint प्रस्तुतियों में दृश्य रूप से आकर्षक, शैलीबद्ध पाठ जोड़ने की अनुमति देते हैं। Aspose.Slides के साथ, डेवलपर प्रोग्रामेटिकली WordArt बना, अनुकूलित और प्रबंधित कर सकते हैं, जैसे Microsoft PowerPoint में—बिना Office स्थापित किए। यह लेख WordArt के साथ काम करने का एक अवलोकन प्रदान करता है, जिसमें पाठ रूपांतरण, भराव शैलियों, रूपरेखाओं, छायाओं और अन्य स्वरूपण विकल्पों को लागू करने की विधियाँ शामिल हैं, जिससे आपकी प्रस्तुति सामग्री अधिक अभिव्यंजक और आकर्षक बनती है। WordArt आपको पाठ को ग्राफिकल ऑब्जेक्ट के रूप में मानने की अनुमति देता है। यह उन प्रभावों या विशेष संशोधनों से बना होता है जो पाठ को अधिक आकर्षक या उल्लेखनीय बनाते हैं।

## **एक सरल WordArt टेम्पलेट बनाना और उसे पाठ पर लागू करना**

**Using Aspose.Slides** 

पहले, हम इस Java कोड का उपयोग करके एक सरल पाठ बनाते हैं: 

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
अब, हम इस कोड के माध्यम से प्रभाव को अधिक स्पष्ट बनाने के लिए पाठ का फ़ॉन्ट ऊँचाई बड़ी मान पर सेट करते हैं: 

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

दाएँ मेनू से आप एक पूर्वनिर्धारित WordArt प्रभाव चुन सकते हैं। बाएँ मेनू से आप एक नए WordArt के लिए सेटिंग्स निर्दिष्ट कर सकते हैं। 

ये उपलब्ध पैरामीटर या विकल्पों में से कुछ हैं: 

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

यहाँ, हम पाठ पर [SmallGrid](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PatternStyle#SmallGrid) पैटर्न रंग लागू करते हैं और इस कोड का उपयोग करके 1-चौड़ाई की काली पाठ सीमा जोड़ते हैं: 

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

परिणामी पाठ: 

![todo:image_alt_text](image-20200930114108-4.png)

## **अन्य WordArt प्रभाव लागू करना**

**Using Microsoft PowerPoint**

प्रोग्राम के इंटरफ़ेस से आप इन प्रभावों को पाठ, पाठ ब्लॉक, आकार या समान तत्व पर लागू कर सकते हैं: 

![todo:image_alt_text](image-20200930114129-5.png)

उदाहरण के लिए, शैडो, रिफ्लेक्शन और ग्लो प्रभाव पाठ पर लागू किए जा सकते हैं; 3D फ़ॉर्मेट और 3D रोटेशन प्रभाव पाठ ब्लॉक पर लागू किए जा सकते हैं; सॉफ्ट एजेस प्रॉपर्टी Shape ऑब्जेक्ट पर लागू की जा सकती है (जब 3D फ़ॉर्मेट प्रॉपर्टी सेट नहीं होती है तब भी इसका प्रभाव रहता है)।

### **छाया प्रभाव लागू करना**

यहाँ, हम केवल पाठ से संबंधित प्रॉपर्टी सेट करने का इरादा रखते हैं। हम इस Java कोड का उपयोग करके पाठ पर छाया प्रभाव लागू करते हैं: 

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

Aspose.Slides API तीन प्रकार की छायाओं का समर्थन करता है: OuterShadow, InnerShadow, और PresetShadow. 

PresetShadow के साथ, आप (पूर्वनिर्धारित मानों का उपयोग करके) पाठ के लिए छाया लागू कर सकते हैं। 

**Using Microsoft PowerPoint**

PowerPoint में आप एक प्रकार की छाया का उपयोग कर सकते हैं। यहाँ एक उदाहरण है: 

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides वास्तव में एक साथ दो प्रकार की छायाएँ लागू करने की अनुमति देता है: InnerShadow और PresetShadow. 

ध्यान दें:
- जब OuterShadow और PresetShadow को साथ में उपयोग किया जाता है, तो केवल OuterShadow प्रभाव लागू होता है। 
- यदि OuterShadow और InnerShadow को साथ में उपयोग किया जाता है, तो परिणामस्वरूप या लागू प्रभाव PowerPoint के संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में प्रभाव दुगुना हो जाता है। लेकिन PowerPoint 2007 में OuterShadow प्रभाव लागू होता है। 

### **पाठों पर डिस्प्ले लागू करना**

हम इस Java कोड नमूने के माध्यम से पाठ में डिस्प्ले जोड़ते हैं: 

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

### **पाठों पर ग्लो प्रभाव लागू करना**

हम इस कोड का उपयोग करके पाठ पर ग्लो प्रभाव लागू करते हैं जिससे वह चमके या प्रमुख दिखे: 

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

आप छाया, डिस्प्ले और ग्लो के पैरामीटर बदल सकते हैं। प्रभावों की प्रॉपर्टी प्रत्येक पाठ हिस्से पर अलग-अलग सेट होती है। 

{{% /alert %}} 

### **WordArt में ट्रांसफ़ॉर्मेशन का उपयोग**

हम इस कोड के माध्यम से Transform प्रॉपर्टी (पूरे पाठ ब्लॉक में निहित) का उपयोग करते हैं: 
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Microsoft PowerPoint और Aspose.Slides for Java दोनों कुछ पूर्वनिर्धारित ट्रांसफ़ॉर्मेशन प्रकार प्रदान करते हैं। 

{{% /alert %}} 

**Using PowerPoint**

प्रीडिफाइंड ट्रांसफ़ॉर्मेशन प्रकारों तक पहुँचने के लिए, देखें: **Format** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

ट्रांसफ़ॉर्मेशन प्रकार चुनने के लिए, TextShapeType enum का उपयोग करें। 

### **पाठ और आकारों पर 3D प्रभाव लागू करना**

हम इस नमूना कोड का उपयोग करके पाठ आकार पर 3D प्रभाव सेट करते हैं: 

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

परिणामी पाठ और उसका आकार: 

![todo:image_alt_text](image-20200930114816-9.png)

हम इस Java कोड के साथ पाठ पर 3D प्रभाव लागू करते हैं: 

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

पाठों या उनके आकारों पर 3D प्रभावों का लागू करना और प्रभावों के बीच की इंटरैक्शन कुछ नियमों पर आधारित होते हैं।  

एक टेक्स्ट और उस टेक्स्ट को समेटने वाले आकार के लिए एक सीन पर विचार करें। 3D प्रभाव में 3D ऑब्जेक्ट प्रतिनिधित्व और वह सीन शामिल होता है जिस पर ऑब्जेक्ट रखा गया है।  

- जब दोनों फ़िगर और टेक्स्ट दोनों के लिए सीन सेट किया जाता है, तो फ़िगर सीन को उच्च प्राथमिकता मिलती है—टेक्स्ट सीन को अनदेखा किया जाता है।  
- जब फ़िगर का अपना सीन नहीं होता लेकिन उसके पास 3D प्रतिनिधित्व है, तो टेक्स्ट सीन प्रयोग किया जाता है।  
- अन्यथा—जब आकार में मूल रूप से कोई 3D प्रभाव नहीं होता—तो आकार सपाट रहता है और 3D प्रभाव केवल टेक्स्ट पर लागू होता है।  

ये विवरण ThreeDFormat.getLightRig() और ThreeDFormat.getCamera() मेथड्स से जुड़े हैं। 

{{% /alert %}} 

## **पाठों पर बाहरी छाया प्रभाव लागू करें**
Aspose.Slides for Java [**IOuterShadow**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioutershadow/) और [**IInnerShadow**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iinnershadow/) क्लास प्रदान करता है जो आपको [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) द्वारा ले जाने वाले पाठ पर छाया प्रभाव लागू करने की अनुमति देते हैं। इन चरणों को देखें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास की एक इंस्टैंस बनाएँ।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफरेंस प्राप्त करें।  
3. स्लाइड में Rectangle प्रकार का AutoShape जोड़ें।  
4. AutoShape से जुड़े TextFrame तक पहुँचें।  
5. AutoShape का FillType NoFill सेट करें।  
6. OuterShadow क्लास का इंस्टैंसिएट करें।  
7. छाया का BlurRadius सेट करें।  
8. छाया की Direction सेट करें।  
9. छाया की Distance सेट करें।  
10. RectanglelAlign को TopLeft सेट करें।  
11. छाया का PresetColor Black सेट करें।  
12. प्रेजेंटेशन को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  

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

    // यदि हम पाठ की छाया चाहते हैं तो आकार का भराव निष्क्रिय करें
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // बाहरी छाया जोड़ें और सभी आवश्यक पैरामीटर सेट करें
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // प्रेजेंटेशन को डिस्क पर सहेजें
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **आकारों पर आंतरिक छाया प्रभाव लागू करें**
इन चरणों को देखें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास की एक इंस्टैंस बनाएँ।  
2. स्लाइड का रेफरेंस प्राप्त करें।  
3. Rectangle प्रकार का AutoShape जोड़ें।  
4. InnerShadowEffect सक्रिय करें।  
5. सभी आवश्यक पैरामीटर सेट करें।  
6. ColorType को Scheme सेट करें।  
7. Scheme Color सेट करें।  
8. प्रेजेंटेशन को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  

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

    // ColorType को Scheme के रूप में सेट करें
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme Color सेट करें
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // प्रेजेंटेशन सहेजें
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### क्या मैं विभिन्न फ़ॉन्ट या लिपियों (जैसे अरबी, चीनी) के साथ WordArt प्रभाव उपयोग कर सकता हूँ?
हाँ, Aspose.Slides यूनिकोड का समर्थन करता है और सभी प्रमुख फ़ॉन्ट और लिपियों के साथ काम करता है। WordArt प्रभाव जैसे शैडो, फ़िल, और आउटलाइन भाषा की परवाह किए बिना लागू किए जा सकते हैं, हालांकि फ़ॉन्ट उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट पर निर्भर हो सकते हैं।

### क्या मैं स्लाइड मास्टर तत्वों पर WordArt प्रभाव लागू कर सकता हूँ?
हाँ, आप मास्टर स्लाइड्स पर मौजूद आकारों, जैसे टाइटल प्लेसहोल्डर्स, फुटर या बैकग्राउंड टेक्स्ट पर WordArt प्रभाव लागू कर सकते हैं। मास्टर लेआउट में किए गए बदलाव सभी संबंधित स्लाइड्स में प्रतिबिंबित होंगे।

### क्या WordArt प्रभाव प्रस्तुति फ़ाइल आकार को प्रभावित करते हैं?
थोड़ा। छाया, ग्लो तथा ग्रेडिएंट फ़िल जैसे WordArt प्रभाव फ़ाइल के आकार को थोड़ा बढ़ा सकते हैं क्योंकि अतिरिक्त फ़ॉर्मेटिंग मेटाडेटा जुड़ता है, पर अंतर आमतौर पर नगण्य होता है।

### क्या मैं प्रस्तुति को सेव किए बिना WordArt प्रभावों का परिणाम प्रीव्यू कर सकता हूँ?
हाँ, आप [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) या [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) इंटरफ़ेस के `getImage` मेथड का उपयोग करके WordArt वाले स्लाइड को इमेज (जैसे PNG, JPEG) में रेंडर कर सकते हैं। इससे आप पूरी प्रस्तुति को सेव या एक्सपोर्ट करने से पहले मेमोरी में या स्क्रीन पर परिणाम का प्रीव्यू ले सकते हैं।