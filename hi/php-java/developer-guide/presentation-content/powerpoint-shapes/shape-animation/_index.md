---
title: PHP का उपयोग करके प्रस्तुतियों में आकार एनीमेशन लागू करना
linktitle: आकार एनीमेशन
type: docs
weight: 60
url: /hi/php-java/shape-animation/
keywords:
- आकार
- एनीमेशन
- प्रभाव
- एनिमेटेड आकार
- एनीमेटेड टेक्स्ट
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
description: "Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुतियों में आकार एनीमेशन बनाना और अनुकूलित करना कैसे सीखें। अलग दिखें!"
---
## **परिचय**

एनिमेशन दृश्य प्रभाव हैं जिन्हें पाठ, चित्र, आकार, या [charts](https://docs.aspose.com/slides/hi/php-java/animated-charts/) पर लागू किया जा सकता है। वे प्रस्तुतियों या उनके घटकों को जीवन देते हैं।

## **प्रस्तुतियों में एनिमेशन का उपयोग क्यों करें?**

* जानकारी के प्रवाह को नियंत्रित करें  
* महत्वपूर्ण बिंदुओं को उजागर करें  
* अपने दर्शकों में रुचि या भागीदारी बढ़ाएँ  
* सामग्री को पढ़ने, समझने या प्रक्रिया करने में आसान बनाएं  
* अपने पाठकों या दर्शकों का ध्यान प्रस्तुति के महत्वपूर्ण हिस्सों की ओर आकर्षित करें  

PowerPoint एनिमेशन और एनिमेशन प्रभावों के लिए **entrance**, **exit**, **emphasis**, और **motion paths** श्रेणियों में कई विकल्प और टूल प्रदान करता है।

## **Aspose.Slides में एनिमेशन**

* Aspose.Slides वह वर्ग और प्रकार प्रदान करता है जिनकी आपको `Aspose.Slides.Animation` नेमस्पेस के तहत एनिमेशन के साथ काम करने की आवश्यकता है,  
* Aspose.Slides **150** से अधिक एनीमेशन इफ़ेक्ट्स को [EffectType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effecttype) enumeration के तहत प्रदान करता है। ये इफ़ेक्ट्स मूल रूप से PowerPoint में उपयोग किए जाने वाले समान (या बराबर) इफ़ेक्ट्स हैं।

## **टेक्स्टबॉक्स पर एनिमेशन लागू करें**

Aspose.Slides for PHP via Java आपको आकार में टेक्स्ट पर एनीमेशन लागू करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड रेफ़रेंस प्राप्त करें।  
3. एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।  
4. `AutoShape` की [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/#getTextFrame) में टेक्स्ट जोड़ें।  
5. इफ़ेक्ट्स की मुख्य क्रम प्राप्त करें।  
6. [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) में एक एनीमेशन इफ़ेक्ट जोड़ें।  
7. `TextAnimation.setBuildType` मेथड और `BuildType` enumeration के मान का उपयोग करें।  
8. प्रेजेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह PHP कोड दिखाता है कि कैसे `Fade` इफ़ेक्ट को AutoShape पर लागू किया जाए और टेक्स्ट एनीमेशन को *By 1st Level Paragraphs* मान पर सेट किया जाए:

```php
  # एक प्रस्तुति वर्ग का उदाहरण बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # टेक्स्ट के साथ नई AutoShape जोड़ता है
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
    $sequence = $sld->getTimeline()->getMainSequence();
    # shape में Fade एनीमेशन प्रभाव जोड़ता है
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # shape के टेक्स्ट को पहली स्तर के पैराग्राफ द्वारा एनीमेट करता है
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # PPTX फ़ाइल को डिस्क पर सहेजें
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 
टेक्स्ट पर एनीमेशन लागू करने के अलावा, आप एकल [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) पर भी एनीमेशन लागू कर सकते हैं। देखें [**Animated Text**](/slides/hi/php-java/animated-text/).
{{% /alert %}} 

## **PictureFrame पर एनिमेशन लागू करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड रेफ़रेंस प्राप्त करें।  
3. स्लाइड पर एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe) जोड़ें या प्राप्त करें।  
4. इफ़ेक्ट्स की मुख्य क्रम प्राप्त करें।  
5. [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe) में एक एनीमेशन इफ़ेक्ट जोड़ें।  
6. प्रेजेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह PHP कोड दिखाता है कि कैसे `Fly` इफ़ेक्ट को एक picture frame पर लागू किया जाए:

```php
  # एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले प्रस्तुति वर्ग का उदाहरण बनाता है।
  $pres = new Presentation();
  try {
    # प्रस्तुति की छवि संग्रह में जोड़ने के लिए चित्र लोड करता है।
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # स्लाइड में पिक्चर फ्रेम जोड़ता है।
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # स्लाइड की मुख्य क्रम प्राप्त करता है।
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # पिक्चर फ्रेम पर बाएँ से फ़्लाई एनीमेशन प्रभाव जोड़ता है।
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # PPTX फ़ाइल को डिस्क पर सहेजता है।
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Shape पर एनिमेशन लागू करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड रेफ़रेंस प्राप्त करें।  
3. एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।  
4. एक बिवेल [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें (जब इस ऑब्जेक्ट पर क्लिक किया जाता है, तो एनीमेशन चलाया जाता है)।  
5. बिवेल आकार पर इफ़ेक्ट्स की एक क्रम बनाएं।  
6. एक कस्टम `UserPath` बनाएं।  
7. `UserPath` पर जाने के लिए कमांड जोड़ें।  
8. प्रेजेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह PHP कोड दिखाता है कि कैसे `PathFootball` (path football) इफ़ेक्ट को एक shape पर लागू किया जाए:

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाला Presentation वर्ग बनाता है।
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # मौजूदा shape के लिए शून्य से PathFootball इफ़ेक्ट बनाता है।
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # PathFootBall एनीमेशन इफ़ेक्ट जोड़ता है
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # कुछ प्रकार का "बटन" बनाता है।
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # इस बटन के लिए इफ़ेक्ट्स की क्रम बनाता है।
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # एक कस्टम यूज़र पाथ बनाता है। हमारा ऑब्जेक्ट केवल बटन क्लिक होने के बाद ही स्थानांतरित किया जाएगा।
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # चूंकि निर्मित पाथ खाली है, इसलिए मूविंग के लिए कमांड जोड़ता है।
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # PPTX फ़ाइल को डिस्क पर लिखता है।
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **एक Shape पर लागू किए गए एनिमेशन इफ़ेक्ट्स प्राप्त करें**

निम्नलिखित उदाहरण दिखाते हैं कि कैसे [Sequence](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sequence/) वर्ग की `getEffectsByShape` मेथड का उपयोग करके किसी shape पर लागू सभी एनिमेशन इफ़ेक्ट्स प्राप्त किए जाएं।

**उदाहरण 1: सामान्य स्लाइड पर किसी shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करें**

पहले, आपने PowerPoint प्रस्तुतियों में shapes पर एनीमेशन इफ़ेक्ट्स जोड़ना सीखा था। निम्नलिखित नमूना कोड दिखाता है कि कैसे प्रस्तुति `AnimExample_out.pptx` की पहली सामान्य स्लाइड में पहली shape पर लागू इफ़ेक्ट्स प्राप्त किए जाएँ।

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # स्लाइड की मुख्य एनीमेशन क्रम प्राप्त करता है।
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # पहली स्लाइड पर पहला shape प्राप्त करता है।
    $shape = $firstSlide->getShapes()->get_Item(0);

    # shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करता है।
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

**उदाहरण 2: सभी एनीमेशन इफ़ेक्ट्स प्राप्त करें, जिसमें placeholders से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं**

यदि कोई shape सामान्य स्लाइड पर उन placeholders को रखता है जो layout स्लाइड और/या master स्लाइड पर हैं, और इन placeholders पर एनीमेशन इफ़ेक्ट्स जोड़े गए हैं, तो स्लाइड शो के दौरान shape के सभी इफ़ेक्ट्स चलाए जाएंगे, जिसमें placeholders से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

मान लीजिए हमारे पास `sample.pptx` नामक एक PowerPoint प्रस्तुति फ़ाइल है, जिसमें एक स्लाइड केवल एक footer shape शामिल है, जिसमें टेक्स्ट "Made with Aspose.Slides" है और shape पर **Random Bars** इफ़ेक्ट लागू किया गया है।

![Slide shape animation effect](slide-shape-animation.png)

यह भी मान लीजिए कि **layout** स्लाइड पर footer placeholder पर **Split** इफ़ेक्ट लागू किया गया है।

![Layout shape animation effect](layout-shape-animation.png)

अंत में, **master** स्लाइड पर footer placeholder पर **Fly In** इफ़ेक्ट लागू किया गया है।

![Master shape animation effect](master-shape-animation.png)

निम्नलिखित नमूना कोड दिखाता है कि कैसे [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) वर्ग की `getBasePlaceholder` मेथड का उपयोग करके shape placeholders तक पहुंचा जाए और footer shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त किए जाएँ, जिसमें layout और master स्लाइड पर स्थित placeholders से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// सामान्य स्लाइड पर shape के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// लेआउट स्लाइड पर placeholder के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// मास्टर स्लाइड पर placeholder के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // फ़्लाई, नीचे
Type: 134, subtype: 45            // स्प्लिट, वर्टिकलइन
Type: 126, subtype: 22            // रैंडमबार्स, हॉरिज़ोन्टल
```

## **एनीमेशन इफ़ेक्ट टाइमिंग विधियों को बदलें**

Aspose.Slides for PHP via Java आपको एनीमेशन इफ़ेक्ट की Timing प्रॉपर्टीज़ को बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन टाइमिंग पेन है:

![example1_image](shape-animation.png)

यहाँ PowerPoint Timing और [Effect Timing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/#getTiming) प्रॉपर्टीज़ के बीच समकक्षता है:

- PowerPoint Timing **Start** ड्रॉप-डाउन सूची [Timing::getTriggerType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/#getTriggerType) मेथड से मेल खाती है।  
- PowerPoint Timing **Duration** [Timing::getDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/#getDuration) मेथड से मेल खाती है। एनीमेशन की अवधि (सेकंड में) वह कुल समय है जो एनीमेशन को एक साइकिल पूरी करने में लेता है।  
- PowerPoint Timing **Delay** [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/timing/#getTriggerDelayTime) मेथड से मेल खाती है।  

इफ़ेक्ट टाइमिंग प्रॉपर्टीज़ को बदलने का तरीका यह है:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें।  
2. ज़रूरी नई मानों को सेट करें, इसके लिए [Effect::getTiming](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/#getTiming) मेथड का उपयोग करें।  
3. संशोधित PPTX फ़ाइल को सहेजें।  

यह PHP कोड संचालन को दर्शाता है:

```php
  # एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला प्रस्तुति वर्ग बनाता है।
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # स्लाइड की मुख्य क्रम प्राप्त करता है।
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है।
    $effect = $sequence->get_Item(0);
    # इफ़ेक्ट का TriggerType बदलकर क्लिक पर शुरू करता है।
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # इफ़ेक्ट की अवधि बदलता है।
    $effect->getTiming()->setDuration(3.0);
    # इफ़ेक्ट का TriggerDelayTime बदलता है।
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # PPTX फ़ाइल को डिस्क पर सहेजता है।
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **एनीमेशन इफ़ेक्ट साउंड**

Aspose.Slides एनीमेशन इफ़ेक्ट्स में ध्वनियों के साथ काम करने के लिए निम्नलिखित मेथड्स प्रदान करता है: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **एनीमेशन इफ़ेक्ट साउंड जोड़ें**

यह PHP कोड दिखाता है कि कैसे एनीमेशन इफ़ेक्ट साउंड जोड़ा जाए और अगला इफ़ेक्ट शुरू होने पर उसे रोक दिया जाए:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # प्रेजेंटेशन ऑडियो संग्रह में ऑडियो जोड़ता है
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # स्लाइड की मुख्य क्रम प्राप्त करता है।
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    $firstEffect = $sequence->get_Item(0);
    # इफ़ेक्ट में "नो साउंड" के लिए जांच करता है
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # पहले इफ़ेक्ट के लिए ध्वनि जोड़ता है
      $firstEffect->setSound($effectSound);
    }
    # स्लाइड की पहली इंटरैक्टिव क्रम प्राप्त करता है।
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # इफ़ेक्ट "पिछला ध्वनि रोकें" फ्लैग सेट करता है
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # PPTX फ़ाइल को डिस्क पर लिखता है
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **एनीमेशन इफ़ेक्ट साउंड निकालें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड रेफ़रेंस प्राप्त करें।  
3. इफ़ेक्ट्स की मुख्य क्रम प्राप्त करें।  
4. प्रत्येक एनीमेशन इफ़ेक्ट में एम्बेडेड [setSound(IAudio value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) निकालें।  

यह PHP कोड दिखाता है कि कैसे एनीमेशन इफ़ेक्ट में एम्बेडेड साउंड निकाला जाए:

```php
  # एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला प्रस्तुति वर्ग बनाता है।
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # स्लाइड की मुख्य क्रम प्राप्त करता है।
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # इफ़ेक्ट ध्वनि को बाइट एरे में निकालता है
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **एनीमेशन के बाद**

Aspose.Slides for PHP via Java आपको एनीमेशन इफ़ेक्ट की After animation प्रॉपर्टी को बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन इफ़ेक्ट पैन और विस्तारित मेन्यू है:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** ड्रॉप-डाउन सूची इन मेथड्स से मेल खाती है: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/#setAfterAnimationType) मेथड जो After animation प्रकार का वर्णन करता है:  
  * PowerPoint **More Colors** [AfterAnimationType::Color](https://reference.aspose.com/slides/hi/php-java/aspose.slides/afteranimationtype/#Color) प्रकार से मेल खाती है;  
  * PowerPoint **Don't Dim** आइटम [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/hi/php-java/aspose.slides/afteranimationtype/#DoNotDim) प्रकार से मेल खाती है (डिफ़ॉल्ट after animation प्रकार);  
  * PowerPoint **Hide After Animation** आइटम [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) प्रकार से मेल खाती है;  
  * PowerPoint **Hide on Next Mouse Click** आइटम [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) प्रकार से मेल खाती है;  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/#setAfterAnimationColor) मेथड जो after animation रंग फ़ॉर्मेट को परिभाषित करता है। यह मेथड [AfterAnimationType::Color](https://reference.aspose.com/slides/hi/php-java/aspose.slides/afteranimationtype/#Color) प्रकार के साथ कार्य करता है। यदि आप प्रकार को किसी अन्य में बदलते हैं, तो after animation रंग साफ़ हो जाएगा।

यह PHP कोड दिखाता है कि कैसे after animation इफ़ेक्ट को बदला जाए:

```php
  # एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला प्रस्तुति वर्ग बनाता है
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # after animation प्रकार को Color में बदलता है
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # after animation डिम रंग सेट करता है
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # PPTX फ़ाइल को डिस्क पर लिखता है
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टेक्स्ट को एनीमेट करें**

Aspose.Slides एनीमेशन इफ़ेक्ट के *Animate text* ब्लॉक के साथ काम करने के लिए निम्नलिखित मेथड्स प्रदान करता है:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/#setAnimateTextType) जो इफ़ेक्ट के एनीमेट टेक्स्ट प्रकार का वर्णन करता है। shape टेक्स्ट को इस प्रकार एनीमेट किया जा सकता है:  
  - All at once ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/hi/php-java/aspose.slides/animatetexttype/#AllAtOnce) प्रकार)  
  - By word ([AnimateTextType::ByWord](https://reference.aspose.com/slides/hi/php-java/aspose.slides/animatetexttype/#ByWord) प्रकार)  
  - By letter ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/animatetexttype/#ByLetter) प्रकार)  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/#setDelayBetweenTextParts) एनीमेटेड टेक्स्ट हिस्सों (शब्दों या अक्षरों) के बीच देरी सेट करता है। सकारात्मक मान इफ़ेक्ट अवधि का प्रतिशत दर्शाता है। नकारात्मक मान सेकंड में देरी दर्शाता है।

इफ़ेक्ट Animate text प्रॉपर्टीज़ को बदलने का तरीका यह है:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें।  
2. [setBuildType(int value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textanimation/#setBuildType) मेथड और [BuildType::AsOneObject](https://reference.aspose.com/slides/hi/php-java/aspose.slides/buildtype/#AsOneObject) मान का उपयोग करके *By Paragraphs* एनीमेशन मोड बंद करें।  
3. नई मानों को सेट करने के लिए [setAnimateTextType(int value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/#setAnimateTextType) और [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effect/#setDelayBetweenTextParts) मेथड्स का उपयोग करें।  
4. संशोधित PPTX फ़ाइल को सहेजें।  

यह PHP कोड संचालन को दर्शाता है:

```php
  # एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला प्रस्तुति वर्ग बनाता है।
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # इफ़ेक्ट के Text animation प्रकार को "As One Object" में बदलता है
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # इफ़ेक्ट के Animate text प्रकार को "By word" में बदलता है
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # शब्दों के बीच देरी को इफ़ेक्ट अवधि के 20% पर सेट करता है
    $firstEffect->setDelayBetweenTextParts(20.0);
    # PPTX फ़ाइल को डिस्क पर लिखता है
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे सुनिश्चित करूँ कि वेब पर प्रस्तुति प्रकाशित करने पर एनीमेशन संरक्षित रहें?**  
[Export to HTML5](/slides/hi/php-java/export-to-html5/) और वह [options](https://reference.aspose.com/slides/hi/php-java/aspose.slides/html5options/) सक्षम करें जो shape ([setAnimateShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/html5options/setanimateshapes/)) और transition ([setAnimateTransitions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/html5options/setanimatetransitions/)) एनीमेशन के लिए जिम्मेदार हैं। साधारण HTML स्लाइड एनीमेशन नहीं चलाता, जबकि HTML5 करता है।

**शेप्स के z‑order (लेयर ऑर्डर) को बदलने से एनीमेशन पर क्या प्रभाव पड़ता है?**  
एनीमेशन और ड्रॉइंग क्रम स्वतंत्र होते हैं: एक इफ़ेक्ट आने/जाने के टाइमिंग और प्रकार को नियंत्रित करता है, जबकि [z‑order](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getzorderposition/) तय करता है कि क्या क्या कवर करता है। दृश्य परिणाम उनका संयोजन तय करता है। (यह सामान्य PowerPoint व्यवहार है; Aspose.Slides के इफ़ेक्ट‑और‑शेप मॉडल भी इसी तर्क का पालन करता है।)

**कुछ इफ़ेक्ट्स के लिए एनीमेशन को वीडियो में कनवर्ट करने पर सीमाएँ हैं क्या?**  
सामान्यतः, [animations are supported](/slides/hi/php-java/convert-powerpoint-to-video/), लेकिन दुर्लभ मामलों या विशिष्ट इफ़ेक्ट्स का रेंडर अलग हो सकता है। उपयोग किए जाने वाले इफ़ेक्ट्स और लाइब्रेरी संस्करण के साथ परीक्षण करने की सलाह दी जाती है।