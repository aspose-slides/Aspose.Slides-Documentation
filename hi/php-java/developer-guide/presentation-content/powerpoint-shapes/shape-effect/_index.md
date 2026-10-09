---
title: PHP का उपयोग करके प्रस्तुतियों में आकृति प्रभाव लागू करें
linktitle: आकृति प्रभाव
type: docs
weight: 30
url: /hi/php-java/shape-effect/
keywords:
- आकृति प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- दीप्ति प्रभाव
- नरम किनारों प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके अपने PPT और PPTX फ़ाइलों को उन्नत आकृति प्रभावों के साथ बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जाता है, लेकिन वे [फिल](/slides/hi/php-java/shape-formatting/#gradient-fill) या आउटलाइन से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैला सकते हैं आदि।

![Shape effect](shape-effect.png)

PowerPoint आकारों पर लागू किए जा सकने वाले छह प्रभाव प्रदान करता है। आप किसी आकार पर एक या अधिक प्रभाव लागू कर सकते हैं।

कुछ प्रभाव संयोजन अन्य की तुलना में बेहतर दिखते हैं। इसी कारण PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के ऐसे संयोजन हैं जो अच्छे दिखते हैं। इस प्रकार, प्रीसेट चुनकर आपको विभिन्न प्रभावों को परीक्षण या संयोजन करने में समय नहीं बर्बाद करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) क्लास के अंतर्गत प्रॉपर्टीज़ और मेथड्स प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की अनुमति देते हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for PHP via Java आकारों के लिए बाहरी और भीतरी छाया का समर्थन करता है। आप उनके रंग, दिशा, दूरी, और ब्लर रेडियस को अपनी प्रस्तुति के डिज़ाइन के अनुरूप कस्टमाइज़ कर सकते हैं।

### **बाहरी छाया लागू करें**

स्लाइड पृष्ठभूमि के मुकाबले कार्ड या पैनल को प्रमुख बनाने के लिए बाहरी छाया उपयोग करें। छाया आकार की किनारों से बाहर तक फैली होती है, जिससे यह प्रतीत होता है कि आकार स्लाइड से उठी हुई है। रंग, दिशा, दूरी, और ब्लर रेडियस को अपने टेम्प्लेट की रोशनी और शैली से मेल करने के लिए समायोजित करें।

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

टेम्प्लेट की दृश्य शैली को पुन: उत्पन्न करते समय, कार्ड या पैनल को गहरी दिखावट देने के लिए भीतरी छाया उपयोग करें। बाहरी छाया आकार के बाहर तक फैली होती है और इसे उठी हुई दिखाती है, जबकि भीतरी छाया किनारों के अंदर हिस्से को छाया देती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) द्वारा लौटाए गए छाया को कॉन्फ़िगर करें। बड़े ब्लर रेडियस मान मुलायम किनारे बनाते हैं।

यह PHP उदाहरण एक हल्के नीले कार्ड को गहरे धूसर भीतरी छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री है, दूरी 7 पॉइंट है, और ब्लर रेडियस 6 पॉइंट है:

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

भीतरी छाया को हटाने के लिए, shape के effect format पर [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) को कॉल करें।

## **प्रतिबिंब प्रभाव लागू करें**

Aspose.Slides for PHP via Java में प्रतिबिंब प्रभाव लागू करने के लिए, आप आकारों में दर्पण जैसी प्रतिबिंब जोड़ सकते हैं, पैरामीटर जैसे दूरी, पारदर्शिता, और आकार समायोजित करके। यह प्रभाव आपके प्रस्तुतियों की सजावट को बेहतर बनाता है, आकारों को अधिक परिष्कृत और आकर्षक दिखाता है। यह सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों में तेज़ी से समान डिजाइन लागू किया जा सके।

यह PHP कोड दिखाता है कि कैसे [प्रतिबिंब प्रभाव](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) को एक आकार पर लागू किया जाए:

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

![प्रतिबिंब प्रभाव](reflection_effect.png)

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for PHP via Java में आकार पर ग्लो प्रभाव लागू करने के लिए, आप आकार के आसपास एक नरम, चमकदार आभा जोड़ सकते हैं, रंग और आकार जैसी प्रॉपर्टीज़ को समायोजित करके। यह प्रभाव आकारों को प्रमुख बनाता है और आपकी प्रस्तुति में आकर्षक, ध्यान खींचने वाला दृश्य तत्व जोड़ता है। यह न्यूनतम कोड के साथ आसानी से लागू किया जा सकता है, जिससे आपकी स्लाइड्स की समग्र रूपरेखा सुधरती है।

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

Aspose.Slides for PHP via Java में सॉफ्ट एजेस प्रभाव लागू करने के लिए, आप आकार के किनारों के आसपास एक स्मूथ, ब्लर ट्रांज़िशन बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, उन डिज़ाइनों के लिए उपयुक्त है जिन्हें नरम, हल्की दिखावट चाहिए। आप आसानी से रेडियस जैसे पैरामीटर समायोजित करके अपनी प्रस्तुति में विभिन्न आकारों पर वांछित प्रभाव प्राप्त कर सकते हैं।

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

## **FAQ**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर विभिन्न प्रभावों, जैसे छाया, प्रतिबिंब, और ग्लो, को मिलाकर अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लगा सकते हैं, जिसमें ऑटोशेप्स, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट्स, OLE ऑब्जेक्ट्स, आदि शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लगा सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लगा सकते हैं। प्रभाव पूरे समूह पर लागू होगा।