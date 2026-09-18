---
title: PHP में कस्टम एनीमेशन व्यवहार बनाएं और संशोधित करें
linktitle: कस्टम एनीमेशन
type: docs
weight: 151
url: /hi/php-java/custom-animation/
keywords:
- कस्टम एनीमेशन
- एनीमेशन व्यवहार
- गति पथ
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुतियों में कस्टम एनीमेशन व्यवहार और संपादन योग्य गति पथ बनाएं, निरीक्षण करें और संशोधित करें।"
---
## **अवलोकन**

कस्टम एनिमेशन व्यवहार आपको एक एनिमेशन इफ़ेक्ट के भीतर व्यक्तिगत ऑपरेशनों को नियंत्रित करने की अनुमति देते हैं, जैसे रंग बदलना, आकार को घुमाना, या संपादन योग्य मोशन पथ का अनुसरण करना। यह गाइड दिखाता है कि व्यवहारों को कैसे बनाया और जोड़ा जाए, उनका टाइमिंग कैसे कॉन्फ़िगर किया जाए, मौजूदा एनिमेशन का निरीक्षण और संशोधन कैसे किया जाए, और यह सत्यापित किया जाए कि उनके गुण प्रस्तुति को सहेजने और फिर खोलने के बाद भी बरकरार रहें।

पूर्वनिर्धारित इफ़ेक्ट्स और क्लिक ट्रिगर्स के लिए, देखें [शेप एनीमेशन](/slides/hi/php-java/shape-animation/)।

## **एनिमेशन मॉडल को समझें**

एक एनिमेशन को **Timeline → Sequence → Effect → Behaviors** के रूप में व्यवस्थित किया जाता है:

- प्रत्येक स्लाइड में एक टाइमलाइन होती है जिसमें उसका मुख्य अनुक्रम और इंटरैक्टिव अनुक्रम शामिल होते हैं।
- एक [Sequence](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/) में इफ़ेक्ट्स होते हैं, जो संभावित रूप से विभिन्न आकारों को लक्ष्य बना सकते हैं।
- एक [Effect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/) लक्ष्य आकार, प्रीसेट, उपप्रकार, और इफ़ेक्ट टाइमिंग को पहचानता है।
- जो संग्रह [Effect::getBehaviors](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/getbehaviors/) द्वारा लौटाया जाता है, उसमें वे ऑपरेशन होते हैं जो इफ़ेक्ट को लागू करते हैं: रंग बदलना, स्थानांतरित करना, घुमाना, एक गुण सेट करना, आदि।

## **व्यक्तिगत व्यवहार बनाएं**

एक इफ़ेक्ट बनाने और [getBehaviors](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/getbehaviors/) संग्रह तक पहुँचने के लिए [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) को कॉल करें। एक प्रीसेट इस संग्रह को स्वचालित रूप से भर सकता है। प्रीसेट को विस्तारित करते समय उसके ऑपरेशन रखें, या जानबूझकर उन्हें बदलते समय [clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorcollection/clear/) का उपयोग करें।

[BehaviorFactory](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorfactory/) नीचे दिखाए गए आठ व्यवहार प्रकार बनाता है। मोशन को [Build a Motion Path](#build-a-motion-path) में कवर किया गया है। प्रत्येक स्निपेट में उसकी इम्पोर्ट्स शामिल हैं और मानता है कि PHP/Java Bridge और Aspose.Slides PHP लाइब्रेरी लोड हो चुका है। बाद में संपादन उदाहरण बताते हैं कि कौन सी आउटपुट फ़ाइल उपयोग की गई है।

### **घुमाव**

एक घुमाव बनाने के लिए [createRotationEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorfactory/createrotationeffect/) का प्रयोग करें। [getBy](https://reference.aspose.com/slides/hi/php-java/aspose.slides/rotationeffect/getby/) डिग्री में सापेक्ष कोण निर्दिष्ट करता है; [getFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/rotationeffect/getfrom/) और [getTo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/rotationeffect/getto/) अंत बिंदुओं को निर्धारित करते हैं।

उदाहरण एक Spin इफ़ेक्ट से शुरू होता है, उसके प्रीसेट ऑपरेशनों को एक घुमाव व्यवहार से बदलता है, और उस ऑपरेशन को दो सेकंड की अवधि देता है। 90 डिग्री का सापेक्ष कोण आकार की प्रारंभिक अभिविन्यास से एक चौथाई घुमाव दर्शाता है, इसलिए कोई स्पष्ट प्रारंभिक कोण आवश्यक नहीं है।

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` में एक आकार और एक घुमाव व्यवहार है। नीचे के संग्रह, टाइमिंग, और घुमाव-संपादन उदाहरण इस फ़ाइल का उपयोग करते हैं।

### **स्केल**

X/Y प्रतिशत के साथ [createScaleEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorfactory/createscaleeffect/) का प्रयोग करें: [getFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/scaleeffect/getfrom/) और [getTo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/scaleeffect/getto/) प्रारंभ और समाप्त आकार का वर्णन करते हैं, जबकि [getBy](https://reference.aspose.com/slides/hi/php-java/aspose.slides/scaleeffect/getby/) सापेक्ष परिवर्तन को बताता है। यहाँ, 100 मूल आकार को दर्शाता है।

उदाहरण दोनों आयामों को 100% से 125% तक दो सेकंड में बढ़ाता है। समान क्षैतिज और लंबवत प्रतिशत रखने से आकार के अनुपात बरकरार रहते हैं; अलग प्रतिशत एक आयाम को दूसरे से अधिक खींच देंगे।

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **रंग**

रंग को बदलने के लिए [createColorEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorfactory/createcoloreffect/) का उपयोग करें, जिससे भराव नीले से नारंगी में बदलता है। [getFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/coloreffect/getfrom/) और [getTo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/coloreffect/getto/) रंग हैं; [getBy](https://reference.aspose.com/slides/hi/php-java/aspose.slides/coloreffect/getby/) रंग का ऑफ़सेट है। व्यवहार की [BehaviorPropertyCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorpropertycollection/) वह गुण दर्शाती है जिसे एनिमेट किया जा रहा है।

आकार का सॉलिड भराव नीले रंग से आरम्भ किया गया है, जो एनिमेशन के प्रारंभिक रंग से मेल खाता है। भराव-रंग गुण चुनने से व्यवहार को पता चलता है कि आकार के कौन से भाग को बदलना है; केवल रंग अंत बिंदु उस गुण को नहीं दर्शाते। सहेजा गया इफ़ेक्ट दो सेकंड में नारंगी में संक्रमण दर्शाता है।

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **फ़िल्टर**

[createFilterEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorfactory/createfiltereffect/) का प्रयोग करके एक वाइप चुनें। [getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filtereffect/getsubtype/), और [getReveal](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filtereffect/getreveal/) क्रमशः फ़िल्टर, दिशा, और आकार को प्रकट या छुपाने को निर्दिष्ट करते हैं।

यह उदाहरण दो सेकंड की वाइप कॉन्फ़िगर करता है जो दाएँ दिशा उपप्रकार का प्रयोग करके आकार को प्रकट करता है। फ़िल्टर सेटिंग्स इफ़ेक्ट के भीतर व्यवहार से संबंधित होती हैं, इसलिए उन्हें प्रीसेट के मूल ऑपरेशनों को हटाने के बाद कॉन्फ़िगर किया जाता है।

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **प्रॉपर्टी**

ऑपेसिटी को एनिमेट करने के लिए [createPropertyEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) का उपयोग करें। [getFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/propertyeffect/getto/), और [getBy](https://reference.aspose.com/slides/hi/php-java/aspose.slides/propertyeffect/getby/) स्ट्रिंग्स हैं जो [getValueType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/propertyeffect/getvaluetype/) और [getCalcMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/propertyeffect/getcalcmode/) द्वारा व्याख्यायित होती हैं। सभी तीन को एक साथ बिना चयन के सेट करने के बजाय अंत बिंदु या सापेक्ष ऑफ़सेट चुनें।

यहाँ चयनित गुण ऑपेसिटी है, और संख्यात्मक स्ट्रिंग्स 25% ऑपेसिटी से पूर्ण ऑपेसिटी तक परिवर्तन दर्शाती हैं। लीनियर इंटरपोलेशन इन मानों के बीच क्रमिक परिवर्तन को दर्शाता है। जब इस उदाहरण को किसी अन्य गुण पर लागू किया जाता है, तो उस गुण के अनुसार उपयुक्त मूल्य प्रकार और अंत बिंदु मान चुनें।

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **सेट**

[createSetEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorfactory/createseteffect/) का उपयोग करके विज़िबिलिटी को [getTo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/seteffect/getto/) के माध्यम से असाइन करें। एक सेट व्यवहार अंत बिंदुओं के बीच इंटरपोलेशन नहीं करता।

उदाहरण विज़िबिलिटी गुण चुनता है और व्यवहार चलने पर स्ट्रिंग `visible` असाइन करता है। इस न्यूनतम प्रस्तुति में आयत पहले से ही दृश्यमान है, इसलिए यह असाइनमेंट स्वयं में स्पष्ट दृश्य परिवर्तन नहीं लाता। ऐसी ऑपरेशन बड़े इफ़ेक्ट का भाग बनाकर उपयोगी होती है जो यह भी नियंत्रित करता है कि कब आकार छुपाया या दिखाया जाए।

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **कमांड**

[createCommandEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorfactory/createcommandeffect/) का प्रयोग करके [getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commandeffect/getcommandstring/), और [getShapeTarget](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commandeffect/getshapetarget/) को कॉन्फ़िगर करें। कार्य निर्देशिका में `sample.wav` नामक WAV रिकॉर्डिंग रखें। यह उदाहरण इसे [addAudioFrameEmbedded](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addaudioframeembedded/) के साथ एम्बेड करता है और ऑडियो फ्रेम पर प्ले कमांड संलग्न करता है।

ऑडियो फ्रेम इफ़ेक्ट का लक्ष्य और कमांड का लक्ष्य दोनों है। यह प्ले अनुरोध को एम्बेडेड रिकॉर्डिंग से जोड़ता है; केवल कमांड स्ट्रिंग यह निर्धारित नहीं करती कि कौन से मीडिया ऑब्जेक्ट को नियंत्रित किया जाए। इफ़ेक्ट स्लाइडशो के दौरान क्लिक पर शुरू होने के लिए कॉन्फ़िगर किया गया है।

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

सेव करने पर कमांड `command.pptx` में संग्रहित होता है; यह रिकॉर्डिंग नहीं चलाता। प्लेबैक के लिए ऐसा स्लाइडशो प्लेयर आवश्यक है जो कमांड और उसकी मीडिया टार्गेट को समर्थन देता हो।

## **व्यवहार संग्रह को प्रबंधित करें**

[BehaviorCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorcollection/) में [add](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorcollection/remove/), और [removeAt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorcollection/removeat/) समर्थित हैं। यह उदाहरण `rotation.pptx` खोलता है, स्केलिंग जोड़ता है, इसे घुमाव से पहले ले जाता है, और घुमाव को हटाता है। वही ऑब्जेक्ट हटाकर पुनः सम्मिलित करने से उसकी संग्रहीत स्थिति बदलती है बिना किसी प्रतिलिपि के।

संपादन की श्रृंखला संग्रह को rotation–scale से scale–rotation में, फिर केवल scale में बदल देती है। सूचकांक वर्तमान संग्रह को दर्शाते हैं, इसलिए हटाना पुन: क्रमबद्धता के बाद घुमाव के नए सूचकांक का उपयोग करता है। अंतिम गणना पुष्टि करती है कि कौन सा व्यवहार सहेजा जाएगा।

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

आउटपुट `ScaleEffect` है: केवल स्केलिंग बचा है। संग्रह क्रम स्वयं व्यवहारों को क्रमशः चलाने की शेड्यूल नहीं बनाता। सभी ऑपरेशनों को बदलते समय ही संग्रह को साफ़ करें।

## **व्यवहार टाइमिंग कॉन्फ़िगर करें**

एक व्यवहार की अपनी [Timing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/) होती है, जो [Effect::getTiming](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/gettiming/) द्वारा लौटाए टाइमिंग से स्वतंत्र होती है। इफ़ेक्ट टाइमिंग सम्मिलित इफ़ेक्ट को शेड्यूल करता है; व्यवहार टाइमिंग उसके भीतर की ऑपरेशन को वर्णित करता है।

### **अवधि, विलंब, पुनरावृत्ति, और त्वरण सेट करें**

`rotation.pptx` खोलें और अवधि ([getDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getduration/)) तथा ट्रिगर विलंब ([getTriggerDelayTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/gettriggerdelaytime/)) सेकंड में सेट करें, फिर [setRepeatCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/setrepeatcount/) द्वारा पुनरावृत्ति गणना कॉन्फ़िगर करें। [getAccelerate](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getaccelerate/) और [getDecelerate](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getdecelerate/) अवधि के अंश होते हैं; उनका योग अधिकतम 1 रखें।

इनपुट फ़ाइल वह है जो घुमाव उदाहरण में बनाई गई थी, जहाँ पहला व्यवहार ज्ञात रूप से घुमाव है। यह उदाहरण केवल उसी व्यवहार के टाइमिंग को बदलता है; इसका 90-डिग्री कोण अपरिवर्तित रहता है। कोण और टाइमिंग को अलग रखने से गति को पुनः निर्माण किए बिना समायोजित करना आसान हो जाता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

व्यवहार दो सेकंड की अवधि, आधा सेकंड विलंब, और 3 की पुनरावृत्ति गणना का उपयोग करता है। उसकी अवधि का पहला और आखिरी 20% त्वरण और मंदन के लिए उपयोग किया जाता है।

अन्य पुनरावृत्ति नीतियों में [getRepeatDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getrepeatuntilendslide/), और [getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getrepeatuntilnextclick/) शामिल हैं; सभी को साथ में सक्षम करने के बजाय एक नीति चुनें। [getAutoReverse](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getautoreverse/) फ़ॉरवर्ड पास के बाद एनीमेशन को पीछे की दिशा में चलाता है। त्वरण और मंदन निरंतर परिवर्तनों पर लागू होते हैं, न कि डिस्क्रीट असाइनमेंट या कमांड पर।

## **मोशन पाथ बनाएं**

[createMotionEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorfactory/createmotioneffect/) का उपयोग करके मोशन बनाएं। इसके [getFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motioneffect/getto/), और [getBy](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motioneffect/getby/) प्रतिशत-आधारित निर्देशांक या ऑफ़सेट दर्शाते हैं। एक संपादन योग्य मार्ग के लिए, एक [MotionPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motionpath/) बनाएं और उसे [MotionEffect::setPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motioneffect/setpath/) से असाइन करें। [MotionPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motionpath/) पाथ कमांड्स संग्रहीत करता है।

| कमांड | बिंदु | अर्थ |
| --- | --- | --- |
| MoveTo | एक | प्रारंभिक स्थिति सेट करें। |
| LineTo | एक | सीधी रेखा खंड के साथ अंत बिंदु तक जाएँ। |
| CurveTo | तीन | दो नियंत्रण बिंदुओं और एक अंत बिंदु द्वारा परिभाषित क्यूबिक कर्व का अनुसरण करें। |
| CloseLoop | नहीं | प्रारंभिक स्थिति पर लौटें। |
| End | नहीं | पाथ समाप्त करें। |

[MotionPathPointsType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motionpathpointstype/) बिंदु-संपादन विशेषताओं जैसे कोना या स्मूथ बिंदु को वर्णित करता है। यह कमांड प्रकार को प्रतिस्थापित नहीं करता। नीचे के कर्व उदाहरण के लिए कर्व बिंदु प्रकार और सीधी खंडों के लिए कोना बिंदु प्रकार का प्रयोग करें।

पाथ निर्देशांक स्लाइड आयामों के सापेक्ष सामान्यीकृत होते हैं: X विस्थापन 0.25 स्लाइड की चौड़ाई का एक चौथाई दर्शाता है, न कि 0.25 प्वाइंट। Y सकारात्मक दिशा नीचे की ओर चलती है। एब्सोल्यूट कमांड पाथ निर्देशांक प्रणाली में स्थिति निर्दिष्ट करती है; रिलेटिव कमांड वर्तमान स्थिति से ऑफ़सेट बताती है। यह [getOrigin](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motioneffect/getorigin/) से अलग है, जो पाथ के रेफ़रेंस फ्रेम को चुनता है, और [getPathEditMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motioneffect/getpatheditmode/) से अलग है, जो आकार के स्थानांतरित होने पर पाथ के गतिशीलता को नियंत्रित करता है।

### **सीधा पाथ बनाएं**

एक मोशन व्यवहार को प्रारंभिक बिंदु, एक सीधा खंड, और अंत कमांड के साथ बनाएं। [MotionPath::add](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motionpath/add/) कमांड प्रकार, उसके बिंदु, बिंदु प्रकार, और सापेक्ष-निर्देशांक फ्लैग लेता है।

प्रारंभिक कमांड (0, 0) स्थापित करता है, और रेखा (0.25, 0) पर समाप्त होती है, जिससे पाथ स्लाइड की चौड़ाई के एक चौथाई क्षैतिज विस्थापन प्राप्त करता है। अंत कमांड में कोई बिंदु नहीं होते। पाथ असाइन करने के बाद, प्रभाव में मोशन व्यवहार जोड़ने से वह रूट आयत से जुड़ जाता है।

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` में एक मोशन व्यवहार है जिसमें तीन पाथ कमांड हैं। नीचे के फ़ाइल-संपादन उदाहरण इस ज्ञात संरचना का उपयोग करते हैं।

### **एब्सोल्यूट और रिलेटिव निर्देशांकों की तुलना**

ये दो पाथ ऑब्जेक्ट एक ही मार्ग वर्णित करते हैं। एब्सोल्यूट कमांड (0.3, 0.1) पर समाप्त होता है; रिलेटिव कमांड वर्तमान स्थिति में (0.1, 0.1) जोड़ता है, यानी (0.2, 0) बनता है।

दोनों पाथ समान स्थिति से शुरू होते हैं। रिलेटिव रेखा के लिए, X और Y ऑफ़सेट को वर्तमान स्थिति में जोड़कर अंत बिंदु प्राप्त करें; एब्सोल्यूट रेखा के लिए, अंत बिंदु सीधे पढ़ें। फ्लैग को बदले बिना निर्देशांकों को परिवर्तित किए जाना अलग मार्ग वर्णन करेगा।

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

किसी भी पाथ को मोशन व्यवहार को असाइन करें ताकि प्रस्तुति में उपयोग हो सके। अंतिम बूलियन तर्क उस कमांड के लिए रिलेटिव निर्देशांक चुनता है।

### **लाइन को कर्व से बदलें**

`motion.pptx` खोलें और उसकी लाइन कमांड को क्यूबिक कर्व से बदलें। पहले दो नियंत्रण बिंदु प्रदान करें, उसके बाद अंत बिंदु।

प्रारम्भिक स्थिति पूर्व कमांड से मिलती है। पहले दो बिंदु कर्व को आकार देते हैं, जबकि तीसरा उसका लक्ष्य है; ये तीन लगातार लक्ष्य नहीं हैं। कमांड प्रकार, बिंदु-सम्पादन प्रकार, और बिंदु ऐरे को साथ में अपडेट करने से खंड नई ज्यामिति के साथ संगत रहता है।

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`curve.pptx` में पाथ अभी भी तीन कमांड रखता है; उसका मध्य कमांड अब कर्व को परिभाषित करता है।

## **सहेजे गए पाथ का निरीक्षण और संपादन**

प्रत्येक [MotionCmdPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motioncmdpath/) में [getPoints](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motioncmdpath/getpointstype/), और [isRelative](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motioncmdpath/isrelative/) उपलब्ध हैं। नीचे के उदाहरण `motion.pptx` में ज्ञात तीन-कमांड पाथ का प्रयोग करते हैं। मनमाना इनपुट के लिए, इच्छित इफ़ेक्ट खोजें और इंडेक्स द्वारा संपादन से पहले कमांड प्रकार और बिंदु गणना की जाँच करें।

### **कमांड और निर्देशांक पढ़ें**

पाथ को बदले बिना पढ़ें। एंड और क्लोज-लूप कमांड को बिंदु चाहिए नहीं होते, इसलिए नल बिंदु ऐरे की अनुमति दें।

आउटपुट प्रत्येक संख्यात्मक कमांड प्रकार को उसके रिलेटिव-निर्देशांक फ्लैग के साथ जोड़ता है, फिर उसके बिंदुओं को सूचीबद्ध करता है। यह परिवर्तन से पहले अंत बिंदु और ऑफ़सेट को अलग करने में मदद करता है। कर्व तीन बिंदु सूचीबद्ध करेगा, जबकि इस फ़ाइल की सीधी रेखा केवल एक बिंदु दिखाएगी।

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

यह सूची प्रारंभिक बिंदु, (0.25, 0) पर समाप्त एब्सोल्यूट रेखा, और अंत कमांड शामिल करती है।

### **अंत बिंदु बदलें**

`motion.pptx` खोलें और रेखा के बिंदु ऐरे को बदलकर उसके अंत बिंदु को स्थानांतरित करें।

इनपुट फ़ाइल में, सूचकांक 0 प्रारंभिक कमांड है और सूचकांक 1 रेखा है। रेखा के एकल बिंदु को बदलने से उसकी गंतव्य बदल जाती है, बिना कमांड प्रकार, टाइमिंग, या संग्रह में उसकी स्थिति बदले। क्योंकि कमांड एब्सोल्यूट निर्देशांक का उपयोग करता है, नया जोड़ा गया जोड़ी एक स्थिति को दर्शाता है न कि एक अतिरिक्त ऑफ़सेट।

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion-endpoint.pptx` में रेखा (0.4, 0.1) पर समाप्त होती है; मूल फ़ाइल अपरिवर्तित रहती है।

### **सेगमेंट बदलें**

[insert](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motionpath/insert/) और [removeAt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/motionpath/removeat/) का प्रयोग करके `motion.pptx` में रेखा को बदलें। सम्मिलन पुराने रेखा को सूचकांक 2 पर ले जाता है।

यह कमांड ऑब्जेक्ट को बदलने को दर्शाता है, न कि उसके मौजूदा निर्देशांकों को संपादित करने को। सम्मिलन के बाद, संग्रह अस्थायी रूप से प्रारंभिक कमांड, नई रेखा, पुरानी रेखा, और अंत कमांड रखता है। सूचकांक 2 को हटाने से पुरानी रेखा हट जाती है और नई मार्ग स्थान पर रहती है।

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

सहेजा गया पाथ अभी भी तीन कमांड रखता है, नई रेखा (0.2, 0.1) पर समाप्त होती है और अंत कमांड आख़िर में होता है।

## **मौजूदा व्यवहार को संशोधित और सत्यापित करें**

जब व्यवहार का सूचकांक ज्ञात नहीं हो, तो उसे प्रकार से चुनें। यह उदाहरण `rotation.pptx` खोलता है, उसका [RotationEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/rotationeffect/) खोजता है, कोण बदलता है, और पुनः खोलने के बाद सहेजा गया मान जाँचता है।

प्रकार जाँच लूप को उन व्यवहारों को छोड़ने की अनुमति देती है जो घुमाव नहीं हैं। दूसरा लोड सहेजी गई फ़ाइल को एक अलग प्रस्तुति ऑब्जेक्ट में पढ़ता है, इसलिए तुलना स्थायी डेटा को जाँचती है न कि मेमोरी में रखे मान को। यह उदाहरण अभी भी मानता है कि ज्ञात इफ़ेक्ट मुख्य अनुक्रम में पहला है; प्रकार द्वारा व्यवहार चुनना मनमाने प्रस्तुति में सही इफ़ेक्ट नहीं ढूँढ़ता।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

आउटपुट `Rotation preserved: true` है। इसी प्रकार की प्रकार-चेकिंग पैटर्न को अन्य व्यवहारों पर लागू करें। पूर्ण संरक्षण जाँच के लिए लक्ष्य आकार, इफ़ेक्ट, व्यवहार प्रकार और क्रम, टाइमिंग, और पाथ कमांड की तुलना करें। फ्लोटिंग-पॉइंट मानों के लिए संख्यात्मक सहनशीलता उपयोग करें। अज्ञात एनिमेशन लेआउट वाली प्रस्तुति के लिए, देखें [Read Shape Animations](/slides/hi/php-java/shape-animation/#read-shape-animations) मुख्य और इंटरैक्टिव अनुक्रमों के traversal के लिए।

## **व्यवहार क्रम, प्रीसेट, और प्लेबैक**

[BehaviorCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behaviorcollection/) में क्रम प्रभाव के ऑपरेशनों का संग्रहीत क्रम है। यह एक प्लेलिस्ट नहीं है जहाँ प्रत्येक व्यवहार स्वचालित रूप से पूर्ववर्ती का इंतजार करे। टाइमिंग और सम्मिलित इफ़ेक्ट शेड्यूलिंग निर्धारित करते हैं। व्यवहार ओवरलैप हो सकते हैं, और समान गुण पर ऑपरेशनों में [additive](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behavioradditivetype/) और [accumulation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/behavioraccumulatetype/) सेटिंग्स के माध्यम से अंतःक्रिया हो सकती है। केवल संग्रह क्रम को बदलकर “स्थानांतरित, फिर घुमाएँ” जैसी शेड्यूलिंग न करें; जैसा कि [Shape Animation](/slides/hi/php-java/shape-animation/) में बताया गया है, स्पष्ट टाइमिंग या अलग-अलग इफ़ेक्ट्स का प्रयोग करें।

इफ़ेक्ट का [getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/gettype/) और [getSubtype](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/getsubtype/) उसका प्रीसेट वर्णित करते हैं। ये संशोधित व्यवहार वृक्ष का पूर्ण विवरण नहीं होते। व्यवहारों को अनुकूलित करने से पहले प्रीसेट और उपप्रकार चुनें: प्रीसेट बदलने से संग्रह पुनः निर्मित हो सकता है और आपके कस्टम ऑपरेशन हट सकते हैं। उदाहरण के लिए, कस्टम Spin इफ़ेक्ट को Fade में बदलने से घुमाव व्यवहार को सेट और फ़िल्टर व्यवहारों से बदल दिया जा सकता है। प्रीसेट या उपप्रकार बदलने के बाद संग्रह को फिर से जाँचें। प्रीसेट व्यवहार को साफ़ करने से विज़िबिलिटी या इनिशियलाइजेशन ऑपरेशनों को भी हटाया जा सकता है जो प्रीसेट को आवश्यक होते हैं। उदाहरण जानबूझकर विज़िबल शैप्स का उपयोग करते हैं और व्यवहारों को बदलते हैं; वे प्रत्येक प्रीसेट के कार्यान्वयन को पुनः नहीं बनाते।

## **फ़ॉर्मेट संगतता**

एक संरक्षित व्यवहार वृक्ष यह गारंटी नहीं देता कि सभी व्यूअर या निर्यात रेंडरर में बिल्कुल समान प्लेबैक हो। सहेजे गए डेटा और रेंडर किए गए आउटपुट को अलग-अलग जाँचें।

| फ़ॉर्मेट या आउटपुट | क्या जाँचना है |
| --- | --- |
| PPTX | इन उदाहरणों के लिए इसे प्राथमिक फ़ॉर्मेट के रूप में उपयोग करें। पुनः खोलें और संपादन योग्य व्यवहार वृक्ष सत्यापित करें, फिर इच्छित PowerPoint संस्करण में प्लेबैक जांचें। |
| PPT | लेगेसी बाइनरी प्रतिनिधित्व PPTX से अलग हो सकता है। अलग सहेज-और-पुनः खोल क्रम और प्लेबैक का परीक्षण करें; सफल PPTX आउटपुट से सभी कस्टम संयोजनों के समर्थन का अनुमान न लगाएँ। |
| PDF, PNG, JPEG, and other static slide images | स्थैतिक स्लाइड प्रतिनिधित्व रखते हैं, न कि प्लेएबल व्यवहार टाइमलाइन या निश्चित अंतिम एनीमेशन फ्रेम। |
| [HTML5](/slides/hi/php-java/export-to-html5/) | जब एक्सपोर्ट विकल्पों में शैप एनीमेशन सक्षम हो, तो समर्थित एनीमेशन चलाए जा सकते हैं। ब्राउज़र में कस्टम संयोजनों का परीक्षण करें। |
| [Animated GIF](/slides/hi/php-java/convert-powerpoint-to-animated-gif/) | रेंडर किए गए फ़्रेम्स को संग्रहीत करता है, न कि संपादन योग्य व्यवहार या क्लिक-ट्रिगर इंटरेक्शन। वास्तविक रेंडर मोशन जाँचें। |
| [Video](/slides/hi/php-java/convert-powerpoint-to-video/) | एनीमेशन फ़्रेम्स को रेंडर करता है और उन्हें वीडियो में एन्कोड करता है। समर्थन सीमित है रेंडरर की [supported animations and effects](/slides/hi/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) तक; कमांड और इंटरैक्टिव इवेंट्स एक संपादन योग्य टाइमलाइन नहीं बनते। |

## **अक्सर पूछे जाने वाले प्रश्न**

**मेरे इफ़ेक्ट में बिना किसी जोड़ के पहले से ही व्यवहार क्यों होते हैं?**

प्रीडिफ़ाइन्ड इफ़ेक्ट बनाते समय उसके अंतर्निहित ऑपरेशनों का निर्माण हो सकता है। उन्हें विस्तारित करने या व्यवहारों को बदलने से पहले जाँचें।

**क्या व्यवहार को शुरुआत में ले जाने से वह पहले चलता है?**

ज़रूरी नहीं। संग्रह क्रम टाइमिंग का विकल्प नहीं है। विलंब, अवधि, और समान गुण पर ऑपरेशनों के बीच अंतःक्रिया की जाँच करें।

**एंड कमांड में बिंदु क्यों नहीं होते?**

यह पाथ के अंत को चिह्नित करता है और कोई निर्देशांक आवश्यक नहीं होते। फ़ाइल से पढ़े गए पाथ का निरीक्षण करते समय नल बिंदु ऐरे की जाँच करें।

**क्या सफल राउंड-ट्रिप प्लेबैक की पुष्टि के लिए पर्याप्त है?**

नहीं। पुनः खोलना उन गुणों के संरक्षण की पुष्टि करता है जो आपने जाँचे। विज़ुअल व्यवहार की पुष्टि के लिए स्लाइडशो प्लेयर या एनीमेटेड निर्यात को अलग से परीक्षण करें।