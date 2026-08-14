---
title: PHP का उपयोग करके प्रस्तुतियों में आकृति एनीमेशन लागू करना
linktitle: आकृति एनीमेशन
type: docs
weight: 60
url: /hi/php-java/shape-animation/
keywords:
- आकृति
- एनीमेशन
- प्रभाव
- एनिमेटेड आकृति
- एनिमेटेड पाठ
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
description: "Aspose.Slides for PHP via Java के साथ आकृति एनीमेशन, टाइमिंग, ध्वनियों, एनीमेशन‑के‑बाद व्यवहार, और एनिमेटेड टेक्स्ट को जोड़ना, निरीक्षण करना और अनुकूलित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java स्लाइड एनिमेशन को स्लाइड टाइमलाइन में इफ़ेक्ट्स के रूप में प्रस्तुत करता है। एक इफ़ेक्ट में लक्ष्य आकृति, एनीमेशन प्रकार और उपप्रकार, ट्रिगर, टाइमिंग सेटिंग्स, और वैकल्पिक गुण जैसे ध्वनि या एनीमेशन‑के‑बाद का व्यवहार शामिल होते हैं।

टाइमलाइन दो प्रकार के अनुक्रम रखती है:

- **मुख्य अनुक्रम** स्लाइड आगे बढ़ते समय चलता है।
- **इंटरैक्टिव अनुक्रम** तब शुरू होता है जब उसका ट्रिगर आकृति क्लिक की जाती है।

क्योंकि टेक्स्ट बॉक्स, चित्र, चार्ट, तालिका और अन्य स्लाइड वस्तुएँ आकृतियों के रूप में होती हैं, आप अधिकांश स्लाइड सामग्री के लिए वही [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) विधि का उपयोग करते हैं। उपलब्ध इफ़ेक्ट्स [EffectType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effecttype/) वर्ग में सूचीबद्ध हैं।

## **आकृति एनीमेशन जोड़ें**

एक एनीमेशन जोड़ने के लिए, स्लाइड के मुख्य अनुक्रम को प्राप्त करें और लक्ष्य आकृति, इफ़ेक्ट प्रकार, उपप्रकार और ट्रिगर के साथ [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) को कॉल करें। किसी ऐसे इफ़ेक्ट के लिए जो दूसरे आकृति पर क्लिक करने पर शुरू होता है, एक इंटरैक्टिव अनुक्रम बनाएं जिसका ट्रिगर वह अन्य आकृति हो।

निम्न उदाहरण दोनों प्रकार के एनीमेशन बनाता है और परिणाम को `shape-animations.pptx` में सहेजता है।

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

ट्रिगर नियंत्रित करता है कि इफ़ेक्ट कब शुरू होता है:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effecttriggertype/) मुख्य अनुक्रम में क्लिक की प्रतीक्षा करता है, या इंटरैक्टिव अनुक्रम में ट्रिगर आकृति पर क्लिक।
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effecttriggertype/) पिछले इफ़ेक्ट के साथ शुरू होता है।
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effecttriggertype/) जब पूर्व इफ़ेक्ट समाप्त हो जाता है, तब शुरू होता है।

एक चित्र, चार्ट या अन्य आकृति प्रकार को एनीमेट करने के लिए, `$targetShape` के बजाय उस वस्तु को [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) को पास करें। चार्ट‑विशिष्ट समूह विकल्पों के लिए देखें [Animated Charts](/slides/hi/php-java/animated-charts/)।

## **आकृति एनीमेशन पढ़ें**

जब आपको लक्ष्य आकृति पता हो, तो [Sequence::getEffectsByShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/geteffectsbyshape/) का उपयोग करें। सभी इफ़ेक्ट्स की जाँच करने हेतु मुख्य अनुक्रम और प्रत्येक इंटरैक्टिव अनुक्रम को क्रमबद्ध करें। क्रमबद्ध करना यह मानने से बचाता है कि अनुक्रम में इंडेक्स `0` पर हमेशा एक इफ़ेक्ट मौजूद हो।

निम्न उदाहरण एक आकृति के साथ मुख्य‑अनुक्रम और इंटरैक्टिव इफ़ेक्ट्स बनाता है, आकृति को लक्षित करने वाले इफ़ेक्ट्स प्राप्त करता है, और फिर स्लाइड पर प्रत्येक अनुक्रम को क्रमबद्ध करता है।

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

यदि आपको केवल एक आकृति के इफ़ेक्ट्स चाहिए, तो पहले आकृति को नाम, प्लेसहोल्डर प्रकार या किसी स्थिर गुण से पहचानें; फिर [Sequence::getEffectsByShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/geteffectsbyshape/) को कॉल करें। यह मान लेना सुरक्षित नहीं है कि [ShapeCollection::get_Item](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/get_item/) में इंडेक्स `0` हमेशा इच्छित वस्तु है।

## **विरासत वाले प्लेसहोल्डर इफ़ेक्ट्स के साथ काम करें**

सामान्य स्लाइड पर एक प्लेसहोल्डर अपने लेआउट स्लाइड और मास्टर स्लाइड पर संबंधित प्लेसहोल्डर से एनीमेशन व्यवहार विरासत में ले सकता है। [Shape::getBasePlaceholder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getbaseplaceholder/) वह पैरेंट प्लेसहोल्डर लौटाता है, या जब कोई पैरेंट न हो तो `null`।

निम्न उदाहरण प्रस्तुति में, फुटर के पास सामान्य स्लाइड पर **Random Bars**, लेआउट स्लाइड पर **Split**, और मास्टर स्लाइड पर **Fly In** है।

![सामान्य स्लाइड पर फुटर एनीमेशन इफ़ेक्ट](slide-shape-animation.png)

![लेआउट स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन इफ़ेक्ट](layout-shape-animation.png)

![मास्टर स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन इफ़ेक्ट](master-shape-animation.png)

अगला उदाहरण नई प्रस्तुति से एक प्लेसहोल्डर पदानुक्रम का उपयोग करता है। यह मास्टर प्लेसहोल्डर, लेआउट प्लेसहोल्डर और सामान्य स्लाइड पर संबंधित प्लेसहोल्डर को इफ़ेक्ट्स जोड़ता है। प्रत्येक बार [Shape::getBasePlaceholder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getbaseplaceholder/) को कॉल करने से पहले परिणाम की जाँच की जाती है।

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

PowerPoint **Timing** संवाद [Timing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/) की विशेषताओं से मैप होता है।

![एनीमेशन इफ़ेक्ट के लिए PowerPoint Timing संवाद](shape-animation.png)

- **Start** का मानचित्रण [Timing::getTriggerType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/gettriggertype/) से होता है।
- **Duration** का मानचित्रण [Timing::getDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getduration/) से है, सेकंड में।
- **Delay** का मानचित्रण [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/gettriggerdelaytime/) से है, सेकंड में।
- **Repeat** का मानचित्रण [Timing::getRepeatCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getrepeatuntilnextclick/) या [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getrepeatuntilendslide/) से है।
- **Rewind when done playing** का मानचित्रण [Timing::getRewind](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/getrewind/) से है।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट जोड़ता है, उसे [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) द्वारा लौटाए गए ऑब्जेक्ट के माध्यम से टाइमिंग बदलता है, और परिणाम सहेजता है। लौटाए गए [Effect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/) संदर्भ को रख कर अनावश्यक संग्रह इंडेक्स से बचा जाता है।

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

एक ही रिपीट मोड का इरादे से उपयोग करें। रिपीट काउंट को "until" फ़्लैग के साथ मिलाने से विभिन्न व्यूअर्स में भ्रमित करने वाले परिणाम मिल सकते हैं। रिपीट मोड बदलते समय पहले [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/setrepeatuntilnextclick/) और [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/setrepeatuntilendslide/) को सेट करें, फिर [Timing::setRepeatCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/setrepeatcount/) को सेट करें, क्योंकि किसी भी फ़्लैग को सेट करने से सक्रिय रिपीट मोड भी बदल जाता है।

## **एनीमेशन ध्वनि जोड़ें और निकालें**

एक एनीमेशन इफ़ेक्ट एम्बेडेड ऑडियो को [Effect::getSound](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/getsound/) के माध्यम से संदर्भित कर सकता है। [Effect::setStopPreviousSound](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/setstopprevioussound/) किसी इफ़ेक्ट को बताता है कि वह पूर्व इफ़ेक्ट द्वारा शुरू की गई ध्वनि को रोक दे।

### **इफ़ेक्ट में ध्वनि जोड़ें**

निम्न उदाहरण एक स्थानीय ऑडियो फ़ाइल `animation-sound.wav` की अपेक्षा करता है। यह दो इफ़ेक्ट बनाता है, पहली इफ़ेक्ट के लिए उस फ़ाइल को ध्वनि के रूप में एम्बेड करता है, और दूसरी इफ़ेक्ट को ध्वनि रोकने के लिए कॉन्फ़िगर करता है। यह [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) द्वारा लौटाए गए ऑब्जेक्ट का उपयोग करता है, इसलिए कोई अनुक्रम इंडेक्स आवश्यक नहीं है।

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

### **एम्बेडेड इफ़ेक्ट ध्वनियों को निकालें**

निम्न उदाहरण एक स्थानीय प्रस्तुति `presentation-with-animation-sounds.pptx` की अपेक्षा करता है। यह मुख्य और इंटरैक्टिव दोनों अनुक्रमों को स्कैन करता है और प्रत्येक एम्बेडेड इफ़ेक्ट ध्वनि को `extracted-animation-sounds` निर्देशिका में लिखता है। एक्सटेंशन ऑडियो MIME टाइप से चुना जाता है जो [Audio::getContentType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audio/getcontenttype/) द्वारा प्रदर्शित होता है।

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

बड़ी ऑडियो वस्तुओं के लिए, [Audio::getStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audio/getstream/) का उपयोग करके स्ट्रीम को फ़ाइल में कॉपी करें, बजाय पूरी वस्तु को बाइट एरे में लोड किए।

## **एनीमेशन‑के‑बाद व्यवहार सेट करें**

**After animation** विकल्प नियंत्रित करता है कि इफ़ेक्ट समाप्त होने के बाद आकृति के साथ क्या होता है।

![PowerPoint Effect Options संवाद जिसमें After animation सेटिंग्स दिखायी गई हैं](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/afteranimationtype/) वर्ग आकृति को अपरिवर्तनित रहने, उसका रंग बदलने, एनीमेशन के बाद छिपाने, या अगले क्लिक पर छिपाने की अनुमति देता है। जब प्रकार [AfterAnimationType::Color](https://reference.aspose.com/slides/hi/php-java/aspose.slides/afteranimationtype/) हो, तो साथ ही [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/getafteranimationcolor/) सेट करें।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट बनाता है, लौटाए गए इफ़ेक्ट ऑब्जेक्ट के माध्यम से उसके एनीमेशन‑के‑बाद व्यवहार को सेट करता है, और परिणाम सहेजता है।

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

[AfterAnimationType::Color](https://reference.aspose.com/slides/hi/php-java/aspose.slides/afteranimationtype/) से प्रकार बदलने पर एनीमेशन‑के‑बाद रंग सेटिंग साफ़ हो जाती है।

## **टेक्स्ट एनीमेट करें**

टेक्स्ट एनीमेशन के दो संबंधित नियंत्रण हैं:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textanimation/getbuildtype/) निर्धारित करता है कि अनुच्छेद एक साथ दिखें या पैराग्राफ स्तर पर।
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/getanimatetexttype/) निर्धारित करता है कि टेक्स्ट एक बार, शब्द‑वाक्य‑पर‑शब्द या अक्षर‑पर‑अक्षर दिखे। [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/getdelaybetweentextparts/) शब्दों या अक्षरों के बीच देरी निर्धारित करता है। सकारात्मक मान इफ़ेक्ट अवधि का प्रतिशत है; नकारात्मक मान सेकंड में देरी है।

निम्न स्वतंत्र उदाहरण एक टेक्स्ट बॉक्स के शब्दों को एनीमेट करता है। [BuildType::AsOneObject](https://reference.aspose.com/slides/hi/php-java/aspose.slides/buildtype/) पैराग्राफ‑बाय‑पैराग्राफ निर्माण को निष्क्रिय करता है ताकि शब्द सेटिंग पूरे टेक्स्ट फ्रेम पर लागू हो।

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

पैराग्राफ द्वारा टेक्स्ट बॉक्स बनाने के लिए, [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/hi/php-java/aspose.slides/buildtype/) (या कोई अन्य पैराग्राफ स्तर) सेट करें। एक ही पैराग्राफ को उसके अपने इफ़ेक्ट के साथ लक्ष्य करने के लिए, उस [Sequence::addEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/addeffect/) ओवरलोड का उपयोग करें जो एक [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) स्वीकार करता है। पैराग्राफ‑स्तर के उदाहरणों के लिये देखें [Animated Text](/slides/hi/php-java/animated-text/)।

## **निर्यात और संगतता नोट्स**

- PPT या PPTX में सहेजने से एनीमेशन मॉडल संरक्षित रहता है, लेकिन अंतिम प्लेबैक प्रस्तुति दर्शक द्वारा नियंत्रित होता है।
- PDF और स्थिर छवियों में एनीमेशन नहीं चलते। जब आउटपुट में गति दिखानी हो, तो [HTML5 export](/slides/hi/php-java/export-to-html5/), एनिमेटेड GIF, या [वीडियो रूपांतरण](/slides/hi/php-java/convert-powerpoint-to-video/) का उपयोग करें।
- HTML5 के लिये, [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/html5options/setanimateshapes/) को सक्षम करें और आवश्यक होने पर [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/html5options/setanimatetransitions/) को भी।
- वीडियो रेंडरिंग कई सामान्य प्रवेश, ज़ोर, निकास, और मोशन‑पाथ इफ़ेक्ट्स को सपोर्ट करता है, परन्तु हर PowerPoint इफ़ेक्ट समर्थित नहीं है। वर्तमान [supported animations and effects](/slides/hi/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) देखें और अपने लक्षित Aspose.Slides संस्करण के साथ महत्वपूर्ण प्रस्तुतियों का परीक्षण करें।
- उन्नत कस्टम इफ़ेक्ट्स और अन्य प्रस्तुतियों से आयातित इफ़ेक्ट्स फ़ाइल में संरक्षित रह सकते हैं, पर PowerPoint, HTML5, या वीडियो में अलग‑अलग रेंडर हो सकते हैं। केवल इफ़ेक्ट नाम पर भरोसा करने के बजाय निर्यातित परिणाम को सत्यापित करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में एनीमेशन दिखता है लेकिन PDF में क्यों नहीं?**

PDF एक स्थिर स्वरूप है, इसलिए एनीमेशन और स्लाइड ट्रांज़िशन नहीं चलते। जब गति बरकरार रखनी हो तो HTML5, एनिमेटेड GIF, या वीडियो में निर्यात करें।

**वीडियो में इफ़ेक्ट अलग‑अलग क्यों चलता है?**

वीडियो निर्यात एनीमेशन को रेंडर करता है, न कि मूल PowerPoint व्यवहार को संग्रहीत करता। कुछ उन्नत इफ़ेक्ट्स असमर्थित या मोटा‑मोटा अनुमानित होते हैं। समर्थित‑इफ़ेक्ट तालिका देखें और उत्पादन उपयोग से पहले वास्तविक प्रस्तुति का परीक्षण करें।

**क्या आकृति को आगे या पीछे ले जाने से उसकी एनीमेशन क्रम बदलता है?**

नहीं। आकृति का z‑order ओवरलैप को नियंत्रित करता है, जबकि अनुक्रम क्रम और ट्रिगर एनीमेशन प्लेबैक को नियंत्रित करते हैं। यदि अलग प्लेबैक क्रम चाहिए तो टाइमलाइन बदलें।