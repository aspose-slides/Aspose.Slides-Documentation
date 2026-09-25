---
title: PHP में WordArt प्रभाव बनाएं और लागू करें
linktitle: WordArt
type: docs
weight: 110
url: /hi/php-java/wordart/
keywords:
- WordArt
- WordArt बनाएं
- WordArt टेम्प्लेट
- WordArt प्रभाव
- शैडो प्रभाव
- रेफ़्लेक्शन प्रभाव
- ग्लो प्रभाव
- WordArt रूपांतरण
- 3D प्रभाव
- बाहरी शैडो प्रभाव
- आंतरिक शैडो प्रभाव
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में WordArt प्रभाव बनाएं और अनुकूलित करें। यह क्रमवार गाइड डेवलपर्स को PHP में पेशेवर टेक्स्ट के साथ प्रेजेंटेशन को बेहतर बनाने में मदद करता है।"
---
## **अवलोकन**

WordArt प्रभाव आपको टेक्स्ट को फ़िल, आउटलाइन, शैडो, रेफ़्लेक्शन, ग्लो, ट्रांसफ़ॉर्मेशन, और 3D फ़ॉर्मेटिंग के साथ स्टाइल करने की अनुमति देते हैं। यह लेख PowerPoint प्रज़ेंटेशन में Aspose.Slides for PHP via Java का उपयोग करके, बिना Microsoft Office स्थापित किए, इन प्रभावों को बनाने और अनुकूलित करने का तरीका बताता है।

## **एक साधारण WordArt टेम्प्लेट बनائیں और इसे टेक्स्ट पर लागू करें**

निम्नलिखित उदाहरण टेक्स्ट, फ़ॉन्ट, पैटर्न फ़िल, और आउटलाइन सेट करके एक साधारण WordArt शैली बनाते हैं।

प्रत्येक उदाहरण एक नई प्रज़ेंटेशन बनाता है और उसकी पहली स्लाइड में एक आयत जोड़ता है; कोई इनपुट फ़ाइल आवश्यक नहीं है। पहला उदाहरण टेक्स्ट को "Aspose.Slides" पर सेट करता है। आकार की स्थिति और आयाम पॉइंट में मापे जाते हैं:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

फ़ॉर्मेटिंग को अधिक स्पष्ट बनाने के लिए फ़ॉन्ट को Arial Black, 36 पॉइंट पर सेट करें:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

डार्क ऑरेंज फ़ोरग्राउंड और सफ़ेद बैकग्राउंड के साथ एक [SmallGrid](https://reference.aspose.com/slides/hi/php-java/aspose.slides/patternstyle/#SmallGrid) पैटर्न लागू करें, फिर 1 पॉइंट की चौड़ाई वाले काले टेक्स्ट आउटलाइन जोड़ें:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

परिणामी टेक्स्ट:

![सरल WordArt टेम्प्लेट](WordArt_template.png)

## **अन्य WordArt प्रभाव लागू करें**

निम्नलिखित उदाहरण दिखाते हैं कि टेक्स्ट पर शैडो, रेफ़्लेक्शन, ग्लो, ट्रांसफ़ॉर्मेशन और 3D प्रभाव कैसे लागू किए जाते हैं।

### **बाहरी शैडो प्रभाव लागू करें**

एक बाहरी शैडो टेक्स्ट के पीछे शैडो रखकर गहराई बनाता है। आप इसका रंग, दिशा, दूरी, ब्लर रेडियस, स्केल और स्क्यू कस्टमाइज़ कर सकते हैं।

यह उदाहरण [enableOuterShadowEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) को कॉल करता है और एक काले शैडो को 4‑पॉइंट ब्लर रेडियस, 230‑डिग्री दिशा, और 30‑पॉइंट दूरी के साथ सेट करता है। स्केल मान 100 शैडो का आकार बनाए रखता है, जबकि क्षैतिज स्क्यू इसे 20 डिग्री झुकाता है। अल्फ़ा ट्रांसफ़ॉर्म इसकी अपारदर्शिता को 32 % पर सेट करता है:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

परिणामी टेक्स्ट:

![बाहरी शैडो प्रभाव](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- जब बाहरी और प्रीसेट शैडो एक साथ उपयोग किए जाते हैं, तो केवल बाहरी शैडो लागू होता है।
- यदि बाहरी और आंतरिक शैडो एक साथ उपयोग किए जाते हैं, तो परिणामी प्रभाव PowerPoint संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में प्रभाव दुगुना हो जाता है, जबकि PowerPoint 2007 में केवल बाहरी शैडो लागू होता है।
{{% /alert %}}

### **रेफ़्लेक्शन प्रभाव लागू करें**

रेफ़्लेक्शन टेक्स्ट की एक प्रतिबिंबित कॉपी बनाता है। इसकी स्थिति, स्केल, ब्लर, और अपारदर्शिता को समायोजित करके आप दिखावट नियंत्रित कर सकते हैं।

यह उदाहरण [enableReflectionEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effectformat/#enableReflectionEffect--) को कॉल करता है और स्केल को -100 % सेट करके रेफ़्लेक्शन को लंबवत उलटा करता है। यह 0.5‑पॉइंट ब्लर रेडियस और 4.72‑पॉइंट दूरी का उपयोग करता है। अपारदर्शिता 60 % से 0.9 % तक घटती है जब रेफ़्लेक्शन की स्थिति 0 % से 60 % तक बदलती है:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

परिणामी टेक्स्ट:

![रेफ़्लेक्शन प्रभाव](reflection_effect.png)

### **ग्लो प्रभाव लागू करें**

ग्लो टेक्स्ट के चारों ओर एक मुलायम रंगीन आउटलाइन जोड़ता है। आप इसके रंग, अपारदर्शिता और रेडियस को समायोजित करके प्रभाव नियंत्रित कर सकते हैं।

यह उदाहरण [enableGlowEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effectformat/#enableGlowEffect--) को कॉल करता है और 54 % अपारदर्शिता तथा 7 पॉइंट रेडियस के साथ लाल ग्लो लागू करता है:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

परिणामी टेक्स्ट:

![ग्लो प्रभाव](glow_effect.png)

### **WordArt ट्रांसफ़ॉर्मेशन लागू करें**

WordArt ट्रांसफ़ॉर्मेशन टेक्स्ट के ब्लॉक को मोड़ते, खींचते या विकृत करते हैं।

[setTransform](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setTransform-int-) को [ArchUpPour](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textshapetype/#ArchUpPour) पर सेट करके पूरे टेक्स्ट फ़्रेम को ऊपर की ओर झुका सकते हैं:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

परिणामी टेक्स्ट:

![WordArt ट्रांसफ़ॉर्मेशन](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java पूर्वनिर्धारित [रूपांतरण प्रकार](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textshapetype/) का एक सेट प्रदान करता है।
{{% /alert %}}

### **आकार और टेक्स्ट पर 3D प्रभाव लागू करें**

आप आकार या उसके टेक्स्ट पर 3D प्रभाव लगा सकते हैं। बीवल, एक्सट्रूज़न, लाइटिंग, और कैमरा सेटिंग्स परिणामी दिखावट को नियंत्रित करती हैं।

निम्न उदाहरण [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) का उपयोग करके आयत में सर्कुलर बीवेल, नारंगी एक्सट्रूज़न, और डार्क रेड कंटूर जोड़ता है। बीवल आयाम, एक्सट्रूज़न ऊँचाई, कंटूर चौड़ाई, और गहराई पॉइंट में मापी जाती हैं। प्लास्टिक सामग्री, Z‑एक्सिस के चारों ओर 40 डिग्री घुमाया गया बैलेंस्ड लाइटिंग, और परिप्रेक्ष्य कैमरा इसकी दिखावट को परिभाषित करते हैं:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

परिणामी आकार:

![आकार 3D प्रभाव](shape_3D_effect.png)

यह उदाहरण [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#getThreeDFormat--) के माध्यम से टेक्स्ट पर समान 3D फ़ॉर्मेटिंग लागू करता है। छोटे बीवेल अक्षर किनारों को आकार देते हैं, जबकि एक्सट्रूज़न और लाइटिंग टेक्स्ट को गहराई प्रदान करती हैं:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

परिणामी टेक्स्ट:

![टेक्स्ट 3D प्रभाव](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
टेक्स्ट या उसके आकार पर 3D प्रभावों का अनुप्रयोग—और इन प्रभावों के बीच अंतःक्रिया—विशिष्ट नियमों द्वारा नियंत्रित होती है। विचार करें कि दोनों टेक्स्ट और उसके कंटेनर आकार के साथ एक दृश्य परिदृश्य है। 3D प्रभाव वस्तु की 3D प्रस्तुति और उस परिदृश्य दोनों को शामिल करता है।

- यदि एक ही परिदृश्य आकार और टेक्स्ट दोनों के लिए सेट किया गया है, तो आकार का परिदृश्य प्राथमिकता लेता है और टेक्स्ट का परिदृश्य अनदेखा किया जाता है।
- यदि आकार का अपना परिदृश्य नहीं है लेकिन उसकी 3D प्रस्तुति है, तो टेक्स्ट का परिदृश्य उपयोग किया जाता है।
- यदि आकार में कोई 3D प्रभाव नहीं है, तो इसे सपाट माना जाता है, और 3D प्रभाव केवल टेक्स्ट पर लागू होता है।

ये व्यवहार [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#getLightRig--) और [ThreeDFormat::getCamera](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/#getCamera--) विधियों से संबंधित हैं।
{{% /alert %}}

अधिक 3D फ़ॉर्मेटिंग उदाहरणों के लिए देखें [PHP का उपयोग करके प्रज़ेंटेशन में 3D प्रभाव बनाएं](/slides/hi/php-java/3d-presentation/)।

## **आम प्रश्न (FAQ)**

**क्या मैं विभिन्न फॉन्ट या स्क्रिप्ट (जैसे अरबी, चीनी) के साथ WordArt प्रभाव उपयोग कर सकता हूँ?**  
हाँ, Aspose.Slides for PHP via Java यूनिकोड का समर्थन करता है और सभी प्रमुख फॉन्ट और स्क्रिप्ट के साथ कार्य करता है। WordArt प्रभाव जैसे शैडो, फ़िल, और आउटलाइन भाषा की परवाह किए बिना लागू किए जा सकते हैं, हालांकि फॉन्ट उपलब्धता और रेंडरिंग सिस्टम फॉन्ट पर निर्भर हो सकती है।

**क्या मैं स्लाइड मास्टर तत्वों पर WordArt प्रभाव लागू कर सकता हूँ?**  
हाँ, आप मास्टर स्लाइड पर स्थित आकारों, जैसे शीर्षक प्लेसहोल्डर, फुटर, या बैकग्राउंड टेक्स्ट पर WordArt प्रभाव लगा सकते हैं। मास्टर लेआउट में किए गए परिवर्तन सभी संबंधित स्लाइडों में प्रतिबिंबित होंगे।

**क्या WordArt प्रभाव प्रज़ेंटेशन फ़ाइल आकार को प्रभावित करते हैं?**  
थोड़ा बहुत। शैडो, ग्लो, और ग्रेडिएंट फ़िल जैसे WordArt प्रभाव फ़ॉर्मेटिंग मेटा डेटा जोड़ने के कारण फ़ाइल आकार में हल्का बढ़ाव कर सकते हैं, लेकिन यह अंतर आमतौर पर नगण्य होता है।

**क्या मैं प्रज़ेंटेशन को सहेजे बिना WordArt प्रभाव का परिणाम पूर्वावलोकन कर सकता हूँ?**  
हाँ, आप [Slide::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getImage--) का उपयोग करके WordArt वाली स्लाइडों को इमेज (जैसे PNG, JPEG) में रेंडर कर सकते हैं, या [Shape::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage--) से व्यक्तिगत आकारों को इमेज में बदल सकते हैं। यह आपको पूरी प्रज़ेंटेशन को सहेजने या निर्यात करने से पहले मेमोरी या स्क्रीन पर परिणाम का पूर्वावलोकन करने देता है।