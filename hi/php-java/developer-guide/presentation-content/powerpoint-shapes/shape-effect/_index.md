---
title: PHP का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/php-java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- नरम किनारे प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके उन्नत आकार प्रभावों के साथ आपके PPT और PPTX फ़ाइलों को बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकार को उभारा बनाने के लिए किया जा सकता है, लेकिन वे [भरण](/slides/hi/php-java/shape-formatting/#gradient-fill) या outlines से भिन्न होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर विश्वसनीय परावर्तन बना सकते हैं, आकार की चमक फैलाना आदि।

![Shape effect](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक आकार पर एक या अधिक प्रभाव लागू कर सकते हैं।

कुछ प्रभाव संयोजन दूसरों से बेहतर दिखते हैं। इसी कारण PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के संयोजन होते हैं जो दिखने में अच्छे माने जाते हैं। इस तरह, एक प्रीसेट चुनकर आपको विभिन्न प्रभावों का परीक्षण या संयोजन करके एक अच्छा संयोजन खोजने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides प्रोपरटीज़ और मेथड्स [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) क्लास के तहत प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की अनुमति देते हैं।

## **शैडो प्रभाव लागू करें**

Aspose.Slides for PHP via Java आकारों के लिए बाहरी और आंतरिक शैडो का समर्थन करता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिज़ाइन के अनुरूप कस्टमाइज़ कर सकते हैं।

### **बाहरी शैडो लागू करें**

एक बाहरी शैडो का उपयोग करके कार्ड या पैनल को स्लाइड पृष्ठभूमि के विरुद्ध उभारा बना सकते हैं। शैडो आकार की किनारों से बाहर तक विस्तारित होती है, जिससे यह लगते हैं कि आकार स्लाइड से ऊपर उठा हुआ है। रंग, दिशा, दूरी और ब्लर त्रिज्या को टेम्पलेट की लाइटिंग और शैली से मिलाने के लिए समायोजित करें।

यह PHP कोड दिखाता है कि कैसे [बाहरी शैडो प्रभाव](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) को एक आयत पर लागू किया जाए:

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

![शैडो प्रभाव](shadow_effect.png)

### **आंतरिक शैडो लागू करें**

जब टेम्पलेट की दृश्य शैली को पुनः प्रस्तुत कर रहे हों, तो कार्ड या पैनल को संकुचित रूप देने के लिए आंतरिक शैडो का उपयोग करें। बाहरी शैडो आकार के बाहर तक विस्तारित होती है और इसे उठे हुए दिखाती है, जबकि आंतरिक शैडो किनारों के अंदर को शेड करती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) द्वारा लौटाई गई शैडो को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान नरम किनारे उत्पन्न करते हैं।

यह PHP उदाहरण हल्के नीले कार्ड को गहरा ग्रे आंतरिक शैडो के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। शैडो की दिशा 225 डिग्री है, उसकी दूरी 7 पॉइंट है, और ब्लर त्रिज्या 6 पॉइंट है:

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

![हल्के नीले आयत के साथ आंतरिक शैडो](inner_shadow_effect.png)

आंतरिक शैडो को हटाने के लिए, आकार के इफ़ेक्ट फ़ॉर्मेट पर [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) को कॉल करें।

### **प्रिसेट शैडो लागू करें, बदलें और हटाएँ**

[enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) को कॉल करके एक प्रिसेट शैडो सक्षम करें। एक [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) चुनने के लिए [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) का उपयोग करें या उसी आकार पर किसी अन्य शैली पर स्विच करें। शैडो को हटाने और भराव एवं रूपरेखा को बरकरार रखने के लिए [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) को कॉल करें।

यह PHP उदाहरण पहले तीन चरणों के बाद आयत को क्लोन करता है ताकि आप सभी चार चरणों की एक ही स्लाइड पर पड़ताल कर सकें। दोनों शैडो 10 पॉइंट द्वारा ऑफ़सेट हैं। 225° दिशा पहला शैडो आयत के ऊपर और बाएँ रखती है, और 45° दिशा दूसरा शैडो नीचे और दाएँ रखती है।

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

| मूल | पहला प्रिसेट | दूसरा प्रिसेट | हटाने के बाद |
| :---: | :---: | :---: | :---: |
| ![कोई शैडो नहीं](preset_shadow_original.png) | ![ऊपरी बायां ड्रॉप शैडो](preset_shadow_top_left.png) | ![नीचे दायां ड्रॉप शैडो](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई शैडो नहीं](preset_shadow_removed.png) |

## **परावर्तन प्रभाव लागू करें**

परावर्तन प्रभाव Aspose.Slides for PHP via Java में लागू करने के लिए, आप आकारों पर दर्पण जैसी परावर्तन जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह प्रभाव आपकी प्रस्तुतियों को अधिक परिष्कृत और सुशोभित दिखाता है। सरल कोड के साथ इसे लागू करना आसान है, जिससे कई तत्वों पर समान डिजाइन तेज़ी से लागू किया जा सकता है।

यह PHP कोड दिखाता है कि कैसे [परावर्तन प्रभाव](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) को एक आकार पर लागू किया जाए:

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

![परावर्तन प्रभाव](reflection_effect.png)

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for PHP via Java में किसी आकार पर ग्लो प्रभाव लागू करने के लिए, आप आकार के चारों ओर कोमल, चमकदार आभा जोड़ सकते हैं, रंग और आकार जैसी प्रॉपर्टीज़ को समायोजित कर सकते हैं। यह प्रभाव आकार को उभारा बनाता है और प्रस्तुति में आकर्षक दृश्य घटक जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे स्लाइड की कुल दिखावट बेहतर होती है।

यह PHP कोड दिखाता है कि कैसे [ग्लो प्रभाव](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) को एक आकार पर लागू किया जाए:

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

![ग्लो प्रभाव](glow_effect.png)

## **सॉफ्ट एजेस प्रभाव लागू करें**

Aspose.Slides for PHP via Java में सॉफ्ट एजेस प्रभाव लागू करने के लिए, आप आकार के किनारों के चारों ओर एक सुगम, धुंधला संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत दिखावट जोड़ता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिन्हें कोमल, नरम रूप चाहिए। आप विभिन्न आकारों में इच्छित प्रभाव पाने के लिए त्रिज्या जैसे पैरामीटर को आसानी से समायोजित कर सकते हैं।

यह PHP कोड दिखाता है कि कैसे [सॉफ्ट एजेस प्रभाव](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) को एक आकार पर लागू किया जाए:

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

![सॉफ्ट एजेस प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

आकार ब्लर का उपयोग करके आप आकार की भराव और रूपरेखा को नरम कर सकते हैं जबकि आकार संपादित योग्य रहता है। आकार के इफ़ेक्ट फ़ॉर्मेट पर [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करें। त्रिज्या पॉइंट में मापी जाती है (1/72 इंच): नकारात्मक नहीं होने वाला मान उपयोग करें, बड़ी मान अधिक तीव्र ब्लर उत्पन्न करती हैं। शून्य त्रिज्या का अर्थ कोई परिवर्तन नहीं।

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `false` होने पर ब्लर मूल पेंट किए गए सीमाओं में ही सीमित रहता है, जिसमें रूपरेखा भी शामिल है। `true` होने पर ब्लर उन सीमाओं से बाहर तक विस्तारित हो सकता है। इन सेटिंग्स में से कोई भी आकार की स्थिति या आयाम नहीं बदलती।

नीचे का तुलना समान भराव, रूपरेखा और आकार आयामों को पूरे परीक्षण में उपयोग करती है। शीर्ष पंक्ति `grow = false` के साथ; नीचे पंक्ति `grow = true` के साथ।

![हालिया आयत की तुलना 5 और 15 पॉइंट ब्लर त्रिज्या के साथ, grow निष्क्रिय और सक्रिय है](shape_blur_comparison.png)

यह PHP उदाहरण नारंगी आयत को डार्क ब्लू रूपरेखा के साथ बनाता है, 5 पॉइंट ब्लर लागू करता है, और फिर फिर से [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करके 15 पॉइंट ब्लर में अपडेट करता है। दोनों ब्लर स्थितियों को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) को कॉल करके ब्लर के बिना आकार को सहेजता है।

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

आकार ब्लर भराव और रूपरेखा को साथ में प्रभावित करता है। सॉफ्ट एजेस प्रभाव आकार के किनारों को फेड करता है, जबकि शैडो ब्लर केवल शैडो को नरम करता है। इमेज ट्रांसफ़ॉर्मेशन प्रभाव इमेज सामग्री पर कार्य करते हैं; यह उदाहरण आकार को इमेज में बदलें बिना सीधे आकार के इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **FAQ**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप शैडो, परावर्तन और ग्लो जैसे विभिन्न प्रभावों को एक ही आकार पर संयोजित करके अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिनमें ऑटोशेप्स, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अधिक शामिल हैं।

**क्या मैं ग्रुप किए गए आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप ग्रुप किए गए आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।