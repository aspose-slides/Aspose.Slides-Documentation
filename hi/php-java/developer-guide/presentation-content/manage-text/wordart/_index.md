---
title: PHP में WordArt प्रभाव बनाएं और लागू करें
linktitle: WordArt
type: docs
weight: 110
url: /hi/php-java/wordart/
keywords:
- WordArt
- WordArt बनाएं
- WordArt टेम्पलेट
- WordArt प्रभाव
- छाया प्रभाव
- प्रदर्शन प्रभाव
- चमक प्रभाव
- WordArt रूपांतरण
- 3D प्रभाव
- बाहरी छाया प्रभाव
- आंतरिक छाया प्रभाव
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: Aspose.Slides for PHP via Java में WordArt प्रभाव बनाएं और अनुकूलित करें। यह चरण-दर-चरण मार्गदर्शिका डेवलपर्स को पेशेवर पाठ के साथ प्रस्तुतियों को सुधारने में मदद करती है।
---
## **अवलोकन**

WordArt प्रभाव आपको आपकी PowerPoint प्रस्तुतियों में दृश्यात्मक रूप से आकर्षक, शैलीबद्ध पाठ जोड़ने की अनुमति देते हैं। Aspose.Slides के साथ, डेवलपर्स Microsoft PowerPoint की तरह ही WordArt को प्रोग्रामmatically बनाते, अनुकूलित करते और प्रबंधित करते हैं—बिना Office स्थापित किए। यह लेख WordArt के साथ काम करने का एक अवलोकन प्रदान करता है, जिसमें पाठ रूपांतरण, भराव शैलियों, रूपरेखा, छाया और अन्य स्वरूपण विकल्पों को लागू करने के तरीके शामिल हैं, ताकि आपकी प्रस्तुति की सामग्री अधिक अभिव्यक्तिपूर्ण और आकर्षक बन सके। WordArt आपको पाठ को एक ग्राफिकल वस्तु के रूप में मानने की सुविधा देता है। यह प्रभावों या विशेष संशोधनों का समुच्चय है जो पाठ को अधिक आकर्षक या उल्लेखनीय बनाता है।

## **एक सरल WordArt टेम्पलेट बनाएं और उसे पाठ पर लागू करें**

**Aspose.Slides का उपयोग करके** 

सबसे पहले, इस PHP कोड के साथ एक सरल पाठ बनाते हैं:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
अब, हम इस कोड के माध्यम से प्रभाव को अधिक स्पष्ट बनाने के लिए पाठ के फ़ॉन्ट की ऊँचाई को बड़ा सेट करते हैं:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**Microsoft PowerPoint का उपयोग करके**

Microsoft PowerPoint में WordArt प्रभाव मेन्यू पर जाएँ:

![todo:image_alt_text](image-20200930113926-1.png)

दाएँ मेन्यू से आप एक पूर्वनिर्धारित WordArt प्रभाव चुन सकते हैं। बाएँ मेन्यू से आप नए WordArt की सेटिंग्स निर्दिष्ट कर सकते हैं।

उपलब्ध पैरामीटर या विकल्पों में से कुछ इस प्रकार हैं:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides का उपयोग करके**

यहाँ, हम पाठ पर [SmallGrid](https://reference.aspose.com/slides/hi/php-java/aspose.slides/patternstyle/#SmallGrid) पैटर्न रंग लागू करते हैं और इस कोड के साथ 1‑चौड़ाई की काली पाठ सीमा जोड़ते हैं:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

परिणामी पाठ:

![todo:image_alt_text](image-20200930114108-4.png)

## **अन्य WordArt प्रभाव लागू करें**

**Microsoft PowerPoint का उपयोग करके**

प्रोग्राम के इंटरफ़ेस से आप इन प्रभावों को पाठ, पाठ ब्लॉक, आकार या समान तत्व पर लागू कर सकते हैं:

![todo:image_alt_text](image-20200930114129-5.png)

उदाहरण के लिए, Shadow, Reflection और Glow प्रभाव को पाठ पर, 3D Format और 3D Rotation प्रभाव को पाठ ब्लॉक पर, Soft Edges गुण को Shape वस्तु पर लागू किया जा सकता है (भले ही 3D Format गुण सेट न हो)।

### **छाया प्रभाव लागू करें**

यहाँ, हम केवल पाठ से संबंधित गुण सेट करने का इरादा रखते हैं। हम इस कोड के साथ पाठ पर छाया प्रभाव लागू करते हैं:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);
```

Aspose.Slides API तीन प्रकार की छायाओं का समर्थन करता है: OuterShadow, InnerShadow और PresetShadow।

PresetShadow के साथ, आप (पूर्वनिर्धारित मानों का उपयोग करके) पाठ के लिए छाया लागू कर सकते हैं।

**Microsoft PowerPoint का उपयोग करके**

PowerPoint में आप एक प्रकार की छाया का उपयोग कर सकते हैं। यहाँ एक उदाहरण है:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides का उपयोग करके**

Aspose.Slides वास्तव में एक साथ दो प्रकार की छायाएँ लागू करने की अनुमति देता है: InnerShadow और PresetShadow।

**ध्यान दें:**

- जब OuterShadow और PresetShadow को साथ में उपयोग किया जाता है, तो केवल OuterShadow प्रभाव लागू होता है।
- यदि OuterShadow और InnerShadow एक साथ उपयोग किए जाते हैं, तो लागू प्रभाव PowerPoint संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में प्रभाव दोहरा हो जाता है, जबकि PowerPoint 2007 में OuterShadow प्रभाव लागू होता है।

### **पाठ पर प्रतिबिंब प्रभाव लागू करें**

हम इस कोड नमूने के साथ पाठ में प्रतिबिंब जोड़ते हैं:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```

### **पाठ पर चमक (Glow) प्रभाव लागू करें**

हम इस कोड के साथ पाठ पर चमक प्रभाव लागू करते हैं ताकि वह चमके या अलग दिखे:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

ऑपरेशन का परिणाम:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
आप छाया, प्रतिबिंब और चमक के पैरामीटर बदल सकते हैं। प्रभावों की गुणधर्म प्रत्येक पाठ भाग पर अलग‑अलग सेट होते हैं। 
{{% /alert %}} 

### **WordArt में रूपांतरण (Transformations) का उपयोग करें**

हम इस कोड के माध्यम से Transform गुण (पूरे पाठ ब्लॉक में निहित) लागू करते हैं:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```

परिणाम:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint और Aspose.Slides for PHP via Java दोनों कुछ पूर्वनिर्धारित रूपांतरण प्रकार प्रदान करते हैं। 
{{% /alert %}} 

**PowerPoint का उपयोग करके**

पूर्वनिर्धारित रूपांतरण प्रकारों तक पहुंचने के लिए, **Format** → **TextEffect** → **Transform** पर जाएँ।

**Aspose.Slides का उपयोग करके**

रूपांतरण प्रकार चुनने के लिए TextShapeType enum का उपयोग करें।

### **पाठ और आकार पर 3D प्रभाव लागू करें**

हम इस नमूना कोड के साथ पाठ आकार पर 3D प्रभाव सेट करते हैं:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

परिणामी पाठ और उसका आकार:

![todo:image_alt_text](image-20200930114816-9.png)

हम इस PHP कोड के साथ पाठ पर 3D प्रभाव लागू करते हैं:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

ऑपरेशन का परिणाम:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
पाठ या उनके आकार पर 3D प्रभावों का अनुप्रयोग तथा प्रभावों के बीच अन्तःक्रिया कुछ नियमों पर आधारित होती है। 

एक दृश्य को उस पाठ और उसके आकार के लिये विचार करें। 3D प्रभाव में 3D वस्तु का प्रतिनिधित्व और वह दृश्य शामिल होता है जिस पर वस्तु रखी गई है। 

- जब दृश्य दोनों ही आकृति और पाठ दोनों के लिये सेट हो, तो आकृति का दृश्य उच्च प्राथमिकता लेता है—पाठ का दृश्य अनदेखा हो जाता है। 
- जब आकृति का अपना दृश्य नहीं होता लेकिन उसका 3D प्रतिनिधित्व है, तो पाठ का दृश्य उपयोग होता है। 
- अन्यथा—जब मूल रूप से आकार में कोई 3D प्रभाव नहीं होता—तो आकार समतल रहता है और 3D प्रभाव केवल पाठ पर लागू होता है। 

ये विवरण ThreeDFormat.getLightRig() और ThreeDFormat.getCamera() तरीकों से जुड़े हैं। 
{{% /alert %}} 

## **पाठ पर बाहरी छाया (Outer Shadow) प्रभाव लागू करें**
Aspose.Slides for PHP via Java [OuterShadow](https://reference.aspose.com/slides/hi/php-java/aspose.slides/outershadow/) और [InnerShadow](https://reference.aspose.com/slides/hi/php-java/aspose.slides/innershadow/) क्लास प्रदान करता है जो आपको [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) द्वारा ले जाया गया पाठ पर छाया प्रभाव लागू करने की सुविधा देता है। इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।  
2. उसके सूचकांक का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड में Rectangle प्रकार की एक AutoShape जोड़ें।  
4. AutoShape से जुड़े TextFrame तक पहुँचें।  
5. AutoShape की FillType को NoFill सेट करें।  
6. OuterShadow क्लास का एक उदाहरण बनाएँ।  
7. छाया का BlurRadius सेट करें।  
8. छाया की Direction सेट करें।  
9. छाया की Distance सेट करें।  
10. RectanglelAlign को TopLeft सेट करें।  
11. छाया का PresetColor काला सेट करें।  
12. प्रेजेंटेशन को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

यह नमूना कोड—ऊपर दिए गए चरणों का कार्यान्वयन—आपको दिखाता है कि कैसे पाठ पर बाहरी छाया प्रभाव लागू किया जाता है:

```php
  $pres = new Presentation();
  try {
    # स्लाइड का संदर्भ प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # Rectangle प्रकार का AutoShape जोड़ें
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Rectangle में TextFrame जोड़ें
    $ashp->addTextFrame("Aspose TextBox");
    # यदि हम टेक्स्ट की छाया चाहते हैं तो आकार की भराई अक्षम करें
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # बाहरी छाया जोड़ें और सभी आवश्यक पैरामीटर सेट करें
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # प्रस्तुति को डिस्क पर सहेजें
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **आकार पर आंतरिक छाया (Inner Shadow) प्रभाव लागू करें**
इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।  
2. स्लाइड का संदर्भ प्राप्त करें।  
3. Rectangle प्रकार की एक AutoShape जोड़ें।  
4. InnerShadowEffect सक्रिय करें।  
5. सभी आवश्यक पैरामीटर सेट करें।  
6. ColorType को Scheme सेट करें।  
7. Scheme Color सेट करें।  
8. प्रेजेंटेशन को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

यह नमूना कोड (ऊपर दिखाए गए चरणों के आधार पर) आपको दो आकारों के बीच कनेक्टर जोड़ना दिखाता है:

```php
  $pres = new Presentation();
  try {
    # स्लाइड का संदर्भ प्राप्त करें
    $slide = $pres->getSlides()->get_Item(0);
    # Rectangle प्रकार का AutoShape जोड़ें
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Rectangle में TextFrame जोड़ें
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # InnerShadowEffect सक्षम करें
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # सभी आवश्यक पैरामीटर सेट करें
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # ColorType को Scheme के रूप में सेट करें
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Scheme Color सेट करें
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # प्रस्तुति सहेजें
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**क्या मैं WordArt प्रभाव विभिन्न फोंट या लिपियों (जैसे अरबी, चीनी) के साथ उपयोग कर सकता हूँ?**

हाँ, Aspose.Slides यूनिकोड का समर्थन करता है और सभी प्रमुख फोंट व लिपियों के साथ काम करता है। छाया, भराव और रूपरेखा जैसे WordArt प्रभाव भाषा की परवाह किए बिना लागू किए जा सकते हैं, हालांकि फोंट की उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट्स पर निर्भर हो सकती है।

**क्या मैं स्लाइड मास्टर तत्वों पर WordArt प्रभाव लागू कर सकता हूँ?**

हाँ, आप मास्टर स्लाइड्स पर आकारों, शीर्षक प्लेसहोल्डर, फ़ूटर या पृष्ठभूमि पाठ सहित WordArt प्रभाव लागू कर सकते हैं। मास्टर लेआउट में किए गए परिवर्तन सभी सम्बद्ध स्लाइड्स में परिलक्षित होते हैं।

**क्या WordArt प्रभाव प्रेजेंटेशन फ़ाइल आकार को प्रभावित करते हैं?**

थोड़ा। छाया, चमक और ग्रेडिएंट भराव जैसे WordArt प्रभाव अतिरिक्त फ़ॉर्मेटिंग मेटाडाटा जोड़ते हैं, जिससे फ़ाइल आकार में हल्का वृद्धि हो सकती है, लेकिन आमतौर पर यह नगण्य रहती है।

**क्या मैं प्रेजेंटेशन सहेजे बिना WordArt प्रभाव का परिणाम पूर्वावलोकन कर सकता हूँ?**

हाँ, आप [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) या [Slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) क्लास के `getImage` मेथड का उपयोग करके WordArt वाली स्लाइड्स को PNG, JPEG आदि इमेज में रेंडर कर सकते हैं। यह आपको पूर्ण प्रेजेंटेशन सहेजने या निर्यात करने से पहले मेमोरी या स्क्रीन पर परिणाम का पूर्वावलोकन करने देता है।