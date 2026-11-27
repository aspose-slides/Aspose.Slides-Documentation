---
title: PHP का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/php-java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- प्रतिबिंब प्रभाव
- ग्लो प्रभाव
- नरम किनारे प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकंडों में आकर्षक, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

जबकि PowerPoint में इफ़ेक्ट्स का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, वे [fills](/slides/hi/php-java/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint इफ़ेक्ट्स का उपयोग करके आप किसी आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैलाना आदि।

![Shape effect](shape-effect.png)

PowerPoint छह इफ़ेक्ट्स प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक आकार पर एक या अधिक इफ़ेक्ट्स लागू कर सकते हैं।

कुछ इफ़ेक्ट संयोजन अन्य की तुलना में बेहतर दिखते हैं। इसी कारण PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक इफ़ेक्ट्स के संयोजन होते हैं जो दिखने में अच्छे माने जाते हैं। इस प्रकार, एक preset चुनकर आपको विभिन्न इफ़ेक्ट्स को परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) क्लास के तहत गुण और विधियाँ प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान इफ़ेक्ट्स लागू करने की अनुमति देती हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for PHP via Java आकारों के लिए बाहरी और आंतरिक छायाएँ समर्थन करता है। आप उनका रंग, दिशा, दूरी और ब्लर रेडियस को अपनी प्रस्तुति के डिज़ाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

बाहरी छाया का उपयोग करके आप कार्ड या पैनल को स्लाइड बैकग्राउंड के विरुद्ध प्रमुख बना सकते हैं। छाया आकार की किनारों से आगे निकलती है, जिससे ऐसा प्रभाव बनता है कि आकार स्लाइड से ऊपर उठा हो। अपने टेम्पलेट की रोशनी और शैली से मेल खाने के लिए उसका रंग, दिशा, दूरी और ब्लर रेडियस समायोजित करें।

यह PHP कोड दिखाता है कि कैसे आयत पर [outer shadow effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) लागू किया जाए:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Shadow effect](shadow_effect.png)

#### **आकार के घुमाव पर छाया दिशा को नियंत्रित करें**

डिफ़ॉल्ट रूप से, बाहरी छाया आकार के साथ घूमती है। विभिन्न घुमाव वाले आकारों को एक ही दिशा से प्रकाशित दिखाने के लिए, `false` के साथ [setRotateShadowWithShape](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setRotateShadowWithShape) को कॉल करें और उनकी छायाओं को समान दिशा देने के लिए [setDirection](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setDirection) का उपयोग करें।

उदाहरण दो नीली तीर बनाता है जिनकी ग्रे छाया दाएँ 42 पॉइंट (0°) पर ऑफ़सेट है। फिर स्लाइड को डुप्लिकेट करके दोनों तीरों को 90° घड़ी की दिशा में घुमाया जाता है।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $before = $presentation->getSlides()->get_Item(0);
    
    $left = $before->getShapes()->addAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
    $left->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $left->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $left->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $left->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $left->getEffectFormat()->getOuterShadowEffect();
    $shadow->getShadowColor()->setColor(java("java.awt.Color")->GRAY);
    $shadow->setDirection(0);
    $shadow->setDistance(42);
    $shadow->setBlurRadius(0);
    $shadow->setRotateShadowWithShape(true);

    $right = $before->getShapes()->addClone($left);
    $right->setX(395);
    $right->getEffectFormat()->getOuterShadowEffect()->setRotateShadowWithShape(false);

    $after = $presentation->getSlides()->addClone($before);
    foreach ($after->getShapes()->toArray() as $arrow) {
        $arrow->setRotation(90);
    }

    $presentation->save("arrow_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

दूसरी स्लाइड पर, बायाँ तीर अपनी छाया नीचे की ओर डालता है, जबकि दायाँ तीर अभी भी अपनी छाया दाएँ की ओर डालता है। कॉन्फ़िगर की गई दिशा दोनों छायाओं के लिए 0° बनी रहती है।

![PowerPoint rendering before and after a 90° rotation. Both shadows start on the right. After rotation, the shadow moves below the left arrow and stays to the right of the right arrow.](arrow-shadow-rotation.png)

### **आंतरिक छाया लागू करें**

किसी टेम्पलेट की दृश्य शैली को पुनः निर्मित करने के लिए, आंतरिक छाया का उपयोग करके कार्ड या पैनल को अवसादित रूप दे सकते हैं। बाहरी छाया आकार के बाहर विस्तार करती है और उसे उठे हुए दिखाती है, जबकि आंतरिक छाया उसके किनारों के अंदर के हिस्से को शेड करती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) द्वारा लौटाए गए छाया को कॉन्फ़िगर करें। बड़े ब्लर रेडियस मान नरम किनारे उत्पन्न करते हैं।

यह PHP उदाहरण हल्के नीले कार्ड पर गहरा ग्रे आंतरिक छाया बनाता है और उसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री, उसकी दूरी 7 पॉइंट, और ब्लर रेडियस 6 पॉइंट है:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

आंतरिक छाया हटाने के लिए, आकार के इफ़ेक्ट फ़ॉर्मेट पर [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) को कॉल करें।

### **Preset छाया लागू करें, बदलें और हटाएँ**

Preset छाया सक्षम करने के लिए [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) को कॉल करें। एक [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) चुनने या उसी आकार पर किसी अन्य शैली पर स्विच करने के लिए [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) का उपयोग करें। छाया को हटाने के लिए जबकि भराव और रूपरेखा बनी रहे, [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) को कॉल करें।

यह PHP उदाहरण पहले तीन चरणों के बाद आयत को क्लोन करता है ताकि आप एक ही स्लाइड पर चारों चरणों की तुलना साइड‑बाइ‑साइड कर सकें। दोनों छायाएँ 10 पॉइंट ऑफ़सेट हैं। 225° की दिशा पहली छाया को आयत के ऊपर‑बाएँ रखती है, और 45° की दिशा दूसरी छाया को नीचे‑दाएँ रखती है।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| मूल | पहला preset | दूसरा preset | हटाने के बाद |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **प्रतिबिंब प्रभाव लागू करें**

Aspose.Slides for PHP via Java में प्रतिबिंब प्रभाव लागू करने के लिए, आप आकारों पर परावर्तक‑समान प्रतिबिंब जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह प्रभाव आपकी प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, आकारों को अधिक परिष्कृत तथा आकर्षक बनाता है। इसे सरल कोड से लागू किया जा सकता है, जिससे कई तत्वों पर स्थिर डिज़ाइन के लिए तेज़ी से लागू किया जा सके।

यह PHP कोड दिखाता है कि कैसे [reflection effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) को किसी आकार पर लागू किया जाए:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Reflection effect](reflection_effect.png)

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for PHP via Java में किसी आकार पर ग्लो प्रभाव लागू करने के लिए, आप आकारों के चारों ओर एक नरम, उज्ज्वल आभा जोड़ सकते हैं, रंग और आकार जैसी विशेषताएँ समायोजित कर सकते हैं। यह प्रभाव आकारों को प्रमुख बनाता है और आपकी प्रस्तुति में एक आकर्षक दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड से आसानी से लागू किया जा सकता है, जिससे स्लाइडों की समग्र उपस्थिति में सुधार होता है।

यह PHP कोड दिखाता है कि कैसे [glow effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) को किसी आकार पर लागू किया जाए:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Glow effect](glow_effect.png)

## **नरम किनारे प्रभाव लागू करें**

Aspose.Slides for PHP via Java में नरम किनारे प्रभाव लागू करने के लिए, आप आकार के किनारों के चारों ओर एक सुगम, धुंधला संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत रूप देता है, विशेष रूप से उन डिज़ाइनों के लिये जो कोमल, मुलायम उपस्थिति चाहते हैं। आप विभिन्न आकारों में वांछित प्रभाव प्राप्त करने के लिये रेडियस जैसे पैरामीटर को आसानी से समायोजित कर सकते हैं।

यह PHP कोड दिखाता है कि कैसे [soft edges effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) को किसी आकार पर लागू किया जाए:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Soft edges effect](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

Shape blur का उपयोग करके आप आकार की भराव और रूपरेखा को नरम कर सकते हैं जबकि आकार को संपादन योग्य बनाए रखते हैं। आकार के इफ़ेक्ट फ़ॉर्मेट पर [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करें। रेडियस पॉइंट में मापी जाती है (1/72 इंच): एक गैर‑नकारात्मक मान प्रयोग करें, बड़े मान अधिक तीव्र ब्लर उत्पन्न करते हैं। शून्य रेडियस रहने पर उपस्थिति अपरिवर्तित रहती है।

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `false` के साथ, ब्लर को मूल पेंट की गई सीमा (रूपरेखा सहित) तक क्लिप किया जाता है। `true` के साथ, ब्लर उन सीमाओं से बाहर तक विस्तृत हो सकता है। कोई भी सेटिंग आकार की स्थिति या आयाम नहीं बदलती।

नीचे का तुलना वही भराव, रूपरेखा और आकार आयामों का उपयोग करता है। शीर्ष पंक्ति में `grow = false`; नीचे की पंक्ति में `grow = true` है।

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

यह PHP उदाहरण एक नारंगी आयत को डार्क ब्लू रूपरेखा के साथ बनाता है, 5‑पॉइंट ब्लर लागू करता है, फिर फिर से [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करके 15‑पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर किए हुए रूप सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) को कॉल करके बिना ब्लर के आकार को सहेजता है।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Shape blur भराव और रूपरेखा दोनों को प्रभावित करता है। नरम किनारे प्रभाव आकार के किनारों को फ़ेड करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। इमेज ट्रांसफ़ॉर्मेशन इफ़ेक्ट्स इमेज सामग्री पर काम करते हैं; यह उदाहरण आकार को इमेज में बदलें बिना सीधे आकार के इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **FAQ**

**क्या मैं एक ही आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हां, आप विभिन्न इफ़ेक्ट्स—जैसे छाया, प्रतिबिंब और ग्लो—को एक ही आकार पर संयोजित करके अधिक गतिशील उपस्थिति बना सकते हैं।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न प्रकार के आकारों, जैसे ऑटोशेप्स, चार्ट्स, टेबल्स, पिक्चर, SmartArt ऑब्जेक्ट्स, OLE ऑब्जेक्ट्स और अधिक पर इफ़ेक्ट्स लागू कर सकते हैं।

**क्या मैं समूहबद्ध आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हां, आप समूहबद्ध आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। इफ़ेक्ट पूरे समूह पर लागू होगा।