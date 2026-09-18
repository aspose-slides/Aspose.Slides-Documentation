---
title: PHP का उपयोग करके प्रस्तुतियों में आकार एनीमेशन लागू करें
linktitle: आकार एनीमेशन
type: docs
weight: 60
url: /hi/php-java/shape-animation/
keywords:
- आकार
- एनीमेशन
- प्रभाव
- एनीमेटेड आकार
- एनीमेटेड पाठ
- एनीमेशन जोड़ें
- एनीमेशन प्राप्त करें
- एनीमेशन निकालें
- प्रभाव जोड़ें
- प्रभाव प्राप्त करें
- प्रभाव निकालें
- प्रभाव ध्वनि
- एनीमेशन लागू करें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ आकार एनीमेशन, टाइमिंग, ध्वनियों, एनीमेशन‑के‑बाद व्यवहार, और एनीमेटेड टेक्स्ट को जोड़ना, निरीक्षण करना और अनुकूलित करना सीखें।"
---
## **अवलोकन**

एक प्रभाव के भीतर व्यक्तिगत व्यवहारों के साथ काम करने या मोशन‑पाथ खंडों को संपादित करने के लिए, देखें [कस्टम एनीमेशन](/slides/hi/php-java/custom-animation/)।

Aspose.Slides for PHP via Java स्लाइड एनीमेशन को स्लाइड टाइमलाइन में प्रभावों (effects) के रूप में दर्शाता है। एक प्रभाव में लक्ष्य आकार, एनीमेशन प्रकार और उपप्रकार, ट्रिगर, टाइमिंग सेटिंग्स, और वैकल्पिक गुण जैसे ध्वनि या एनीमेशन‑के‑बाद व्यवहार होते हैं।

टाइमलाइन में दो प्रकार के क्रम होते हैं:

- **मुख्य क्रम** स्लाइड आगे बढ़ते समय चलता है।
- **इंटरएक्टिव क्रम** तब शुरू होता है जब उसके ट्रिगर आकार पर क्लिक किया जाता है।

क्योंकि टेक्स्ट बॉक्स, चित्र, चार्ट, तालिकाएँ और अन्य स्लाइड वस्तुएँ आकार (shapes) हैं, आप अधिकांश स्लाइड सामग्री के लिए वही [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) मेथड उपयोग करते हैं। उपलब्ध प्रभावों की सूची [EffectType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effecttype/) क्लास में दी गई है।

## **शेप एनीमेशन जोड़ें**

एक एनीमेशन जोड़ने के लिए, स्लाइड के मुख्य क्रम को प्राप्त करें और लक्ष्य आकार, प्रभाव प्रकार, उपप्रकार, और ट्रिगर के साथ [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) कॉल करें। किसी प्रभाव को तभी शुरू करने के लिए जब कोई अन्य आकार क्लिक किया जाए, उस अन्य आकार को ट्रिगर बनाकर एक इंटरएक्टिव क्रम बनाएं।

निम्न उदाहरण दोनों प्रकार का एनीमेशन बनाता है और परिणाम को `shape-animations.pptx` में सहेजता है।

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Click to animate this shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $entranceEffect = $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $entranceEffect->getTiming()->setDuration(1.5);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $presentation->save("shape-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ट्रिगर नियंत्रित करता है कि प्रभाव कब शुरू होता है:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effecttriggertype/) मुख्य क्रम में क्लिक या इंटरएक्टिव क्रम में ट्रिगर आकार पर क्लिक का इंतजार करता है।
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effecttriggertype/) पूर्व प्रभाव के साथ शुरू होता है।
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effecttriggertype/) पूर्व प्रभाव समाप्त होने पर शुरू होता है।

एक चित्र, चार्ट, या अन्य कोई आकार एनीमेट करने के लिए, `$targetShape` के बजाय उस वस्तु को [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) में पास करें। चार्ट‑विशिष्ट ग्रुपिंग विकल्पों के लिए देखें [एनिमेटेड चार्ट](/slides/hi/php-java/animated-charts/)।

## **शेप एनीमेशन पढ़ें**

जब आप लक्ष्य आकार जानते हैं, तो [Sequence::getEffectsByShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/geteffectsbyshape/) का उपयोग करें। सभी प्रभावों का निरीक्षण करने के लिए, मुख्य क्रम और प्रत्येक इंटरएक्टिव क्रम को क्रमबद्ध करें। क्रमबद्ध करना इस धारणा से बचता है कि किसी क्रम में इंडेक्स `0` पर प्रभाव मौजूद है।

निम्न उदाहरण मुख्य‑क्रम और इंटरएक्टिव प्रभावों के साथ एक आकार बनाता है, आकार को लक्षित करने वाले प्रभाव प्राप्त करता है, और फिर स्लाइड पर प्रत्येक क्रम को क्रमबद्ध करता है।

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function printSequence($label, $sequence)
{
    $effectCount = java_values($sequence->getCount());

    echo "  " . $label . ": " . $effectCount . " effect(s)" . PHP_EOL;

    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $targetShape = $effect->getTargetShape();
        $targetName = java_is_null($targetShape) ? "unknown" : java_values($targetShape->getName());
        $effectType = java_values($effect->getType());
        $effectSubtype = java_values($effect->getSubtype());
        $triggerType = java_values($effect->getTiming()->getTriggerType());
        echo "    type: " . $effectType . "; subtype: " . $effectSubtype . "; target: " . $targetName . "; trigger: " . $triggerType . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Animated shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $targetEffects = $mainSequence->getEffectsByShape($targetShape);
    $Array = new JavaClass("java.lang.reflect.Array");
    echo "The main sequence contains " . java_values($Array->getLength($targetEffects)) . " effect(s) for " . java_values($targetShape->getName()) . "." . PHP_EOL;

    printSequence("Main sequence", $mainSequence);

    $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
    $interactiveCount = java_values($interactiveSequences->getCount());
    for ($interactiveIndex = 0; $interactiveIndex < $interactiveCount; $interactiveIndex++) {
        $sequence = $interactiveSequences->get_Item($interactiveIndex);
        $sequenceTrigger = $sequence->getTriggerShape();
        $triggerName = java_is_null($sequenceTrigger) ? "unknown" : java_values($sequenceTrigger->getName());
        printSequence("Interactive sequence " . ($interactiveIndex + 1) . ", trigger: " . $triggerName, $sequence);
    }
} finally {
    $presentation->dispose();
}
```

यदि आपको केवल एक आकार के प्रभाव चाहिए, तो पहले नाम, प्लेसहोल्डर प्रकार, या किसी अन्य स्थिर गुण से आकार की पहचान करें; फिर [Sequence::getEffectsByShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/geteffectsbyshape/) को कॉल करें। यह न मानें कि इंडेक्स `0` पर स्थित [ShapeCollection::get_Item](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/get_item/) हमेशा इच्छित वस्तु है।

## **उत्तराधिकारित प्लेसहोल्डर प्रभावों के साथ काम करें**

सामान्य स्लाइड पर एक प्लेसहोल्डर अपने लेआउट स्लाइड और मास्टर स्लाइड पर संबंधित प्लेसहोल्डर से एनीमेशन व्यवहार को विरासत में ले सकता है। [Shape::getBasePlaceholder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getbaseplaceholder/) वह पैरेन्ट प्लेसहोल्डर लौटाता है, या जब कोई पैरेंट न हो तो `null` लौटाता है।

निम्न उदाहरण प्रस्तुति में, फुटर में सामान्य स्लाइड पर **Random Bars**, लेआउट स्लाइड पर **Split**, और मास्टर स्लाइड पर **Fly In** हैं।

![साधारण स्लाइड पर फुटर एनीमेशन प्रभाव](slide-shape-animation.png)

![लेआउट स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन प्रभाव](layout-shape-animation.png)

![मास्टर स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन प्रभाव](master-shape-animation.png)

अगला उदाहरण नई प्रस्तुति से एक प्लेसहोल्डर पदानुक्रम का उपयोग करता है। यह मास्टर प्लेसहोल्डर, लेआउट प्लेसहोल्डर, और सामान्य स्लाइड पर संबंधित प्लेसहोल्डर को प्रभाव जोड़ता है। प्रत्येक बार [Shape::getBasePlaceholder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getbaseplaceholder/) को कॉल करने से पहले वापसी आकार की जाँच की जाती है।

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

function findLayoutPlaceholderWithBase($layoutSlide)
{
    $shapes = $layoutSlide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_is_null($shape->getBasePlaceholder())) {
            return $shape;
        }
    }

    return null;
}

function findSlidePlaceholderWithBase($slide, $expectedBase)
{
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $basePlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($basePlaceholder) && java_values($basePlaceholder->equals($expectedBase))) {
            return $shape;
        }
    }

    return null;
}

function printEffects($source, $effects)
{
    $Array = new JavaClass("java.lang.reflect.Array");
    echo $source . ": " . java_values($Array->getLength($effects)) . " effect(s)" . PHP_EOL;

    foreach ($effects as $effect) {
        echo "  type: " . java_values($effect->getType()) . "; subtype: " . java_values($effect->getSubtype()) . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);
    $layoutPlaceholder = findLayoutPlaceholderWithBase($layoutSlide);

    if ($layoutPlaceholder === null) {
        throw new RuntimeException("The layout slide does not contain a placeholder linked to its master slide.");
    }

    $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
    $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->addEffect($masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    $layoutSlide->getTimeline()->getMainSequence()->addEffect($layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

    $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $slidePlaceholder = findSlidePlaceholderWithBase($slide, $layoutPlaceholder);

    if ($slidePlaceholder === null) {
        throw new RuntimeException("The slide does not contain a placeholder linked to its layout slide.");
    }

    $slide->getTimeline()->getMainSequence()->addEffect($slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
    printEffects("Normal slide", $slide->getTimeline()->getMainSequence()->getEffectsByShape($slidePlaceholder));

    $baseLayoutPlaceholder = $slidePlaceholder->getBasePlaceholder();
    if (!java_is_null($baseLayoutPlaceholder)) {
        printEffects("Layout slide", $layoutSlide->getTimeline()->getMainSequence()->getEffectsByShape($baseLayoutPlaceholder));

        $baseMasterPlaceholder = $baseLayoutPlaceholder->getBasePlaceholder();
        if (!java_is_null($baseMasterPlaceholder)) {
            printEffects("Master slide", $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($baseMasterPlaceholder));
        }
    }

    $presentation->save("placeholder-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **एनीमेशन टाइमिंग बदलें**

PowerPoint **Timing** डायलॉग [Timing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/) की प्रॉपर्टीज़ से मैप होता है।

![एनिमेशन प्रभाव के लिए PowerPoint टाइमिंग डायलॉग](shape-animation.png)

- **Start** को [Timing::getTriggerType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/gettriggertype/) से मैप किया जाता है।
- **Duration** को [Timing::getDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getduration/) से मैप किया जाता है, सेकंड में।
- **Delay** को [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/gettriggerdelaytime/) से मैप किया जाता है, सेकंड में।
- **Repeat** को [Timing::getRepeatCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getrepeatuntilnextclick/), या [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getrepeatuntilendslide/) से मैप किया जाता है।
- **Rewind when done playing** को [Timing::getRewind](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getrewind/) से मैप किया जाता है।

यह स्वतंत्र उदाहरण एक प्रभाव जोड़ता है, उसके टाइमिंग को [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) द्वारा लौटाए गए ऑब्जेक्ट के माध्यम से बदलता है, और परिणाम सहेजता है। लौटाए गए [Effect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/) रेफ़रेंस को रखकर अनावश्यक संग्रह इंडेक्स से बचा जाता है।

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Timed animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    $effect->getTiming()->setDuration(2.0);
    $effect->getTiming()->setTriggerDelayTime(0.5);
    $effect->getTiming()->setRepeatUntilNextClick(false);
    $effect->getTiming()->setRepeatUntilEndSlide(false);
    $effect->getTiming()->setRepeatCount(2.0);
    $effect->getTiming()->setRewind(true);

    $presentation->save("shape-animation-timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

एक ही रिपीट मोड का जानबूझकर उपयोग करें। रिपीट कॉउंट को “until” फ़्लैग के साथ मिलाने से विभिन्न व्यूअर्स में भ्रमित करने वाला परिणाम मिल सकता है। रिपीट मोड बदलते समय पहले [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/setrepeatuntilnextclick/) और [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/setrepeatuntilendslide/) सेट करें, फिर [Timing::setRepeatCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/setrepeatcount/) सेट करें, क्योंकि किसी भी फ़्लैग को सेट करने से सक्रिय रिपीट मोड बदल जाता है।

## **एनीमेशन साउंड जोड़ें और निकालें**

एक एनीमेशन प्रभाव एम्बेडेड ऑडियो को [Effect::getSound](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/getsound/) के माध्यम से संदर्भित कर सकता है। [Effect::setStopPreviousSound](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/setstopprevioussound/) प्रभाव को बताता है कि पहले शुरू हुए ऑडियो को रोकना है।

### **एक प्रभाव में साउंड जोड़ें**

निम्न उदाहरण एक स्थानीय ऑडियो फ़ाइल `animation-sound.wav` की अपेक्षा करता है। यह दो प्रभाव बनाता है, पहली प्रभाव के लिए उस फ़ाइल को साउंड के रूप में एम्बेड करता है, और दूसरे प्रभाव को साउंड रोकने के लिए कॉन्फ़िगर करता है। यह [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) द्वारा लौटाए गए ऑब्जेक्ट्स का उपयोग करता है, इसलिए क्रम इंडेक्स की आवश्यकता नहीं है।

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$Files = new JavaClass("java.nio.file.Files");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 100, 240, 80);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 400, 100, 240, 80);
    $firstShape->addTextFrame("Starts sound");
    $secondShape->addTextFrame("Stops sound");

    $sequence = $slide->getTimeline()->getMainSequence();
    $firstEffect = $sequence->addEffect($firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $secondEffect = $sequence->addEffect($secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $baseDirectory = getcwd();
    $audioPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "animation-sound.wav"))->toPath();
    $audioData = $Files->readAllBytes($audioPath);
    $effectSound = $presentation->getAudios()->addAudio($audioData);
    $firstEffect->setSound($effectSound);
    $secondEffect->setStopPreviousSound(true);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "shape-animation-sound.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **एम्बेडेड इफेक्ट साउंड निकालें**

निम्न उदाहरण एक स्थानीय प्रस्तुति `presentation-with-animation-sounds.pptx` की अपेक्षा करता है। यह मुख्य और इंटरएक्टिव दोनों क्रमों को स्कैन करता है और प्रत्येक एम्बेडेड इफेक्ट साउंड को `extracted-animation-sounds` निर्देशिका में लिखता है। एक्सटेंशन ऑडियो MIME प्रकार से चुना जाता है जो [Audio::getContentType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audio/getcontenttype/) द्वारा उपलब्ध कराया गया है।

```php
use aspose\slides\Presentation;

function getAudioExtension($contentType)
{
    $normalizedType = strtolower($contentType === null ? "" : java_values($contentType));

    if ($normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if ($normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if ($normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if ($normalizedType === "audio/wav" || $normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds($sequence, $outputDirectory, $soundIndex)
{
    $effectCount = java_values($sequence->getCount());
    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $sound = $effect->getSound();
        if (java_is_null($sound)) {
            continue;
        }

        $extension = getAudioExtension($sound->getContentType());
        $outputPath = $outputDirectory->resolve("effect-sound-" . $soundIndex . $extension);
        $outputStream = new Java("java.io.FileOutputStream", $outputPath->toFile());
        try {
            $outputStream->write($sound->getBinaryData());
        } finally {
            $outputStream->close();
        }
        $soundIndex++;
    }

    return $soundIndex;
}

$baseDirectory = getcwd();
$inputPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "presentation-with-animation-sounds.pptx"))->toPath();
$outputDirectoryName = $baseDirectory . DIRECTORY_SEPARATOR . "extracted-animation-sounds";
if (!is_dir($outputDirectoryName)) {
    mkdir($outputDirectoryName, 0777, true);
}
$outputDirectory = (new Java("java.io.File", $outputDirectoryName))->toPath();

$presentation = new Presentation($inputPath->toString());
try {
    $soundIndex = 1;

    $slides = $presentation->getSlides();
    $slideCount = java_values($slides->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $slides->get_Item($slideIndex);
        $soundIndex = saveSounds($slide->getTimeline()->getMainSequence(), $outputDirectory, $soundIndex);

        $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
        $interactiveCount = java_values($interactiveSequences->getCount());
        for ($sequenceIndex = 0; $sequenceIndex < $interactiveCount; $sequenceIndex++) {
            $sequence = $interactiveSequences->get_Item($sequenceIndex);
            $soundIndex = saveSounds($sequence, $outputDirectory, $soundIndex);
        }
    }

    echo "Extracted " . ($soundIndex - 1) . " sound file(s) to " . java_values($outputDirectory->toAbsolutePath()->toString()) . "." . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

बड़ी ऑडियो वस्तुओं के लिए, [Audio::getStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audio/getstream/) का उपयोग करें और पूरे ऑब्जेक्ट को बाइट एरे में लोड करने के बजाय स्ट्रीम को फ़ाइल में कॉपी करें।

## **एनीमेशन‑के‑बाद व्यवहार सेट करें**

**After animation** विकल्प नियंत्रित करता है कि प्रभाव समाप्त होने के बाद आकार के साथ क्या होता है।

![After animation सेटिंग्स दिखाता हुआ PowerPoint इफ़ेक्ट ऑप्शन डायलॉग](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/afteranimationtype/) क्लास आकार को अपरिवर्तित रखने, उसके रंग को बदलने, एनीमेशन के बाद छुपाने, या अगले क्लिक पर छुपाने का समर्थन करता है। जब प्रकार [AfterAnimationType::Color](https://reference.aspose.com/slides/hi/php-java/aspose.slides/afteranimationtype/) हो, तो साथ ही [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/getafteranimationcolor/) सेट करें।

यह स्वतंत्र उदाहरण एक प्रभाव बनाता है, लौटाए गए प्रभाव ऑब्जेक्ट के माध्यम से उसके एनीमेशन‑के‑बाद व्यवहार को सेट करता है, और परिणाम सहेजता है।

```php
use aspose\slides\AfterAnimationType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Dim after animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->setAfterAnimationType(AfterAnimationType::Color);
    $effect->getAfterAnimationColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("shape-animation-after-effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[AfterAnimationType::Color] से प्रकार बदलने पर एनीमेशन‑के‑बाद रंग सेटिंग साफ हो जाती है।

## **टेक्स्ट एनीमेट करें**

टेक्स्ट एनीमेशन में दो संबंधित नियंत्रण होते हैं:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textanimation/getbuildtype/) नियंत्रित करता है कि पैराग्राफ एक साथ दिखें या पैराग्राफ स्तर पर।
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/getanimatetexttype/) नियंत्रित करता है कि टेक्स्ट एक बार में, शब्द द्वारा, या अक्षर द्वारा दिखे। [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/getdelaybetweentextparts/) शब्दों या अक्षरों के बीच देरी सेट करता है। सकारात्मक मान प्रभाव अवधि का प्रतिशत होता है; नकारात्मक मान सेकंड में देरी होता है।

निम्न स्वतंत्र उदाहरण टेक्स्ट बॉक्स में शब्दों को एनीमेट करता है। [BuildType::AsOneObject](https://reference.aspose.com/slides/hi/php-java/aspose.slides/buildtype/) पैराग्राफ‑दर‑पैराग्राफ बिल्डिंग को निष्क्रिय करता है ताकि शब्द सेटिंग पूरे टेक्स्ट फ्रेम पर लागू हो।

```php
use aspose\slides\AnimateTextType;
use aspose\slides\BuildType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 560, 100);
    $textBox->addTextFrame("Aspose.Slides animates this sentence word by word.");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    $effect->setAnimateTextType(AnimateTextType::ByWord);
    $effect->setDelayBetweenTextParts(20.0);

    $presentation->save("animated-text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

पैराग्राफ द्वारा टेक्स्ट बॉक्स बनाने के लिए, [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/hi/php-java/aspose.slides/buildtype/) (या कोई अन्य पैराग्राफ स्तर) सेट करें। किसी एक पैराग्राफ को उसके स्वयं के प्रभाव के साथ लक्षित करने के लिए, वह [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) ओवरलोड उपयोग करें जो एक [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) को स्वीकार करता है। पैराग्राफ‑स्तर के उदाहरणों के लिए देखें [एनिमेटेड टेक्स्ट](/slides/hi/php-java/animated-text/)।

## **निर्यात और संगतता नोट्स**

- PPT या PPTX में सहेजने से एनीमेशन मॉडल बरकरार रहता है, लेकिन अंतिम प्लेबैक प्रस्तुति व्यूअर द्वारा नियंत्रित होता है।
- PDF और स्थैतिक चित्र एनीमेशन नहीं चलाते। जब गति दिखाना आवश्यक हो, तो [HTML5 export](/slides/hi/php-java/export-to-html5/), एनिमेटेड GIF, या [video conversion](/slides/hi/php-java/convert-powerpoint-to-video/) का उपयोग करें।
- HTML5 के लिए, [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/html5options/setanimateshapes/) सक्षम करें और आवश्यक होने पर [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/html5options/setanimatetransitions/) सक्षम करें।
- वीडियो रेंडरिंग कई सामान्य प्रवेश, ज़ोर, निकास, और मोशन‑पाथ प्रभावों को समर्थन देता है, लेकिन हर PowerPoint प्रभाव समर्थित नहीं है। वर्तमान [supported animations and effects](/slides/hi/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) देखें और अपने लक्ष्य Aspose.Slides संस्करण के साथ महत्वपूर्ण प्रस्तुतियों का परीक्षण करें।
- उन्नत कस्टम प्रभाव और अन्य प्रस्तुति स्वरूपों से आयात किए गए प्रभाव फ़ाइल में संरक्षित रह सकते हैं लेकिन PowerPoint, HTML5, या वीडियो में अलग तरह से रेंडर हो सकते हैं। केवल प्रभाव नाम पर भरोसा न करके निर्यात परिणाम का सत्यापन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में एनीमेशन दिखाई देता है लेकिन PDF में नहीं दिखता, क्यों?**

PDF एक स्थैतिक स्वरूप है, इसलिए एनीमेशन और स्लाइड ट्रांज़िशन नहीं चलतीं। गतिशीलता बनाए रखने के लिए HTML5, एनिमेटेड GIF, या वीडियो निर्यात करें।

**वीडियो में प्रभाव अलग तरीके से चलता है, क्यों?**

वीडियो निर्यात एनीमेशन को रेंडर करता है, मूल PowerPoint व्यवहार को नहीं। कुछ उन्नत प्रभाव असमर्थित या अनुमानित होते हैं। निर्यात से पहले समर्थित‑इफ़ेक्ट तालिका देखें और वास्तविक प्रस्तुति का परीक्षण करें।

**क्या आकार को आगे या पीछे ले जाने से उसकी एनीमेशन क्रम बदलता है?**

नहीं। आकार का z‑order ओवरलैप को नियंत्रित करता है, जबकि क्रम और ट्रिगर एनीमेशन प्लेबैक को नियंत्रित करते हैं। अलग प्लेबैक क्रम चाहिए तो टाइमलाइन बदलें।