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
- चमक प्रभाव
- नरम किनारे प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को रूपांतरित करें—सेकंडों में आकर्षक, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

जबकि PowerPoint में प्रभावों का उपयोग करके किसी आकार को प्रमुख बनाया जा सकता है, वे [भराव](/slides/hi/php-java/shape-formatting/#gradient-fill) या रूपरेखाओं से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर प्रभावी प्रतिबिंब, आकार की चमक आदि बना सकते हैं।

![आकार प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप किसी आकार पर एक या अधिक प्रभाव लागू कर सकते हैं।

कुछ प्रभाव संयोजन अन्य की तुलना में बेहतर दिखते हैं। इस कारण PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के ऐसे संयोजन होते हैं जो सामान्यतः अच्छा दिखते हैं। इस तरह, प्रीसेट चुनने से आपको विभिन्न प्रभावों का परीक्षण या संयोजन करके उपयुक्त संयोजन खोजने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) क्लास के अंतर्गत प्रॉपर्टी और मेथड प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर वही प्रभाव लागू करने की अनुमति देता है।

## **छाया प्रभाव लागू करें**

Aspose.Slides for PHP via Java आकारों के लिए बाहरी और भीतरी छायाएँ समर्थन करता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिज़ाइन के अनुसार कस्टमाइज़ कर सकते हैं।

### **बाहरी छाया लागू करें**

स्लाइड पृष्ठभूमि के विरुद्ध कार्ड या पैनल को उजागर करने के लिए बाहरी छाया का उपयोग करें। छाया आकार की किनारों से परे विस्तारित होती है, जिससे ऐसा लगता है कि आकार स्लाइड से ऊपर उठा हुआ है। अपने टेम्पलेट की प्रकाश व्यवस्था और शैली से मेल खाने के लिए इसका रंग, दिशा, दूरी और ब्लर त्रिज्या समायोजित करें।

यह PHP कोड दिखाता है कि कैसे [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) को एक आयत पर लागू किया जाए:

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

![छाया प्रभाव](shadow_effect.png)

### **भीतरी छाया लागू करें**

टेम्पलेट की दृश्य शैली को पुनः पेश करने के लिए भीतरी छाया का उपयोग करके कार्ड या पैनल को गहरा दिखाएँ। बाहरी छाया आकार के बाहर विस्तारित होती है और उसे उठे हुए जैसा दिखाती है, जबकि भीतरी छाया किनारों के अंदर हिस्से को शेड करती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) द्वारा प्राप्त छाया को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान नरम किनारे उत्पन्न करते हैं।

यह PHP उदाहरण हल्के नीले कार्ड को गहरे ग्रे भीतरी छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री, दूरी 7 पॉइंट, और ब्लर त्रिज्या 6 पॉइंट है:

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

![भीतरी छाया के साथ हल्का नीला आयत](inner_shadow_effect.png)

भीतरी छाया हटाने के लिए, shape के effect format पर [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) को कॉल करें।

## **परावर्तन प्रभाव लागू करें**

Aspose.Slides for PHP via Java में परावर्तन प्रभाव लागू करने के लिए आप आकारों में एक दर्पण जैसी प्रतिबिंब जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसी पैरामीटर समायोजित कर सकते हैं। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को अधिक परिष्कृत बनाता है। इसे सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर निरंतर डिज़ाइन लागू करना तेज़ हो जाता है।

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

## **चमक प्रभाव लागू करें**

Aspose.Slides for PHP via Java में आकार पर चमक प्रभाव लागू करने के लिए आप आकार के चारों ओर एक नरम, प्रकाशित आभा जोड़ सकते हैं, रंग और आकार जैसी प्रॉपर्टी समायोजित कर सकते हैं। यह प्रभाव आकार को प्रमुख बनाता है और आपकी प्रस्तुति में आकर्षक दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे स्लाइड्स की समग्र उपस्थिति सुधरती है।

यह PHP कोड दिखाता है कि कैसे [चमक प्रभाव](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) को एक आकार पर लागू किया जाए:

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

![चमक प्रभाव](glow_effect.png)

## **नरम किनारे प्रभाव लागू करें**

Aspose.Slides for PHP via Java में नरम किनारे प्रभाव लागू करने के लिए आप आकार के किनारों के चारों ओर एक स्मूथ, धुंधली संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत लुक देता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिन्हें हल्की, नरम उपस्थिति चाहिए। आप विभिन्न आकारों में इच्छित प्रभाव प्राप्त करने के लिए त्रिज्या जैसी पैरामीटर आसानी से समायोजित कर सकते हैं।

यह PHP कोड दिखाता है कि कैसे [नरम किनारे प्रभाव](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) को एक आकार पर लागू किया जाए:

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

![नरम किनारे प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

आकार ब्लर का उपयोग करके आप आकार की भराव और रूपरेखा को नरम कर सकते हैं जबकि आकार को संपादन योग्य रखते हैं। shape के effect format पर [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करें। त्रिज्या पॉइंट में मापी जाती है (1/72 इंच): गैर-ऋणात्मक मान उपयोग करें, बड़ी मान अधिक तेज़ ब्लर उत्पन्न करती है। शून्य त्रिज्या का अर्थ है कोई परिवर्तन नहीं।

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `false` होने पर ब्लर मूल पेंटेड सीमा (रूपरेखा सहित) तक सीमित रहता है। `true` होने पर ब्लर उन सीमाओं से बाहर तक विस्तारित हो सकता है। दोनों सेटिंग्स आकार की स्थिति या आकार को नहीं बदलतीं।

नीचे दिया गया तुलना समान भराव, रूपरेखा और आकार आयामों का प्रयोग करता है। शीर्ष पंक्ति में `grow = false`; निचली पंक्ति में `grow = true` है।

![मूल आयत की तुलना 5 और 15 पॉइंट ब्लर त्रिज्या के साथ, grow निष्क्रिय और सक्रिय अवस्था में](shape_blur_comparison.png)

यह PHP उदाहरण एक नारंगी आयत को गहरे नीले रूपरेखा के साथ बनाता है, 5 पॉइंट ब्लर लागू करता है, फिर फिर से [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करके इसे 15 पॉइंट ब्लर में बदलता है। यह दोनों ब्लर वाली अवस्थाओं को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) को कॉल करके ब्लर के बिना आकार को सहेजता है।

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

Shape blur भराव और रूपरेखा दोनों को एक साथ प्रभावित करता है। नरम किनारे प्रभाव आकार की किनारों को धुंधला करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। छवि रूपांतरण प्रभाव छवि सामग्री पर कार्य करते हैं; यह उदाहरण shape को छवि में बदलें बिना सीधे shape के effect format पर ब्लर लागू करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर विभिन्न प्रभाव, जैसे छाया, परावर्तन और चमक, को संयोजित करके अधिक गतिशील लुक बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिनमें ऑटोषेप, चार्ट, तालिका, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अधिक शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।