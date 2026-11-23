---
title: PHP का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/php-java/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मॉर्फ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ने को कॉन्फ़िगर करें, और Morph तथा अन्य ट्रांज़िशन प्रभावों को अनुकूलित करें।"
---
## **अवलोकन**

स्लाइड ट्रांज़िशन स्लाइड शो के दौरान स्लाइड्स के दिखावे को नियंत्रित करता है। Aspose.Slides for PHP via Java के साथ, आप प्रत्येक स्लाइड के लिए ट्रांज़िशन प्रभाव चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और प्रभाव के विशिष्ट विकल्प समायोजित कर सकते हैं। यह लेख PHP उदाहरणों का उपयोग करके ट्रांज़िशन लागू करने, सटीक ट्रांज़िशन अवधि सेट करने, स्लाइड टाइमिंग प्रबंधित करने, और दो स्लाइड्स के बीच एक Morph ट्रांज़िशन बनाने को दर्शाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें और [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) के माध्यम से स्लाइड की ट्रांज़िशन सेटिंग्स तक पहुँचें। [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) एनीमरेशन से मान के साथ [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) का उपयोग करें, फिर प्रस्तुति सहेजें।

निम्न उदाहरण प्रथम स्लाइड में Circle ट्रांज़िशन और द्वितीय स्लाइड में Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **व्हील ट्रांज़िशन**

[setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) मेथड यह नियंत्रित करता है कि लक्ष्य स्लाइड को कितने रेडियल सेक्टर उजागर करेंगे। [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) से Wheel चुनने के लिए [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) का उपयोग करें, फिर [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) सेटिंग्स तक पहुंचने के लिए [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) को कॉल करें।

उदाहरण दो समान स्लाइड जोड़े बनाता है। प्रत्येक जोड़े की शुरुआत काली स्लाइड से होती है और अंत में सुनहरे आयत द्वारा ढकी हुई स्लाइड होती है। स्लाइड 2 में एक स्पोक और स्लाइड 4 में आठ स्पोक होते हैं। दोनों ट्रांज़िशन समान धीमी गति का उपयोग करते हैं, जिसे [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) से सेट किया गया है, और 8 000 मिलीसेकंड की स्पष्ट अवधि, जिसे [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) से सेट किया गया है।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

सहेजी गई प्रस्तुति को PowerPoint में खोलें और स्लाइड शो शुरू करें। स्लाइड 1 से स्लाइड 2 पर जाएँ और एकल घड़ी‑सँधि घूर्णन देखें। फिर स्लाइड 3 से स्लाइड 4 पर जाएँ और आठ रेडियल सेक्टर एक साथ आयत को उजागर होते देखें।

## **Reveal ट्रांज़िशन के साथ ब्लैक थ्रू फेड**

लक्ष्य स्लाइड का ट्रांज़िशन प्रकार Reveal सेट करें, फिर उसके [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/) सेटिंग्स पर [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) को कॉल करें। उदाहरण एक टील स्रोत स्लाइड और एक कोरल लक्ष्य स्लाइड बनाता है, फिर दोनों को क्लोन करता है। प्रत्येक जोड़े में दो‑सेकंड का Reveal ट्रांज़िशन समान है। केवल दूसरे जोड़े में ब्लैक थ्रू फेड होता है।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

सहेजी गई प्रस्तुति को PowerPoint में खोलें और स्लाइड शो शुरू करें। स्लाइड 1 से स्लाइड 2 पर जाएँ और टील सीधे कोरल में फेड होते देखें। फिर स्लाइड 3 से स्लाइड 4 पर जाएँ। स्क्रीन तुरंत काली के करीब घटती है, उसके बाद कोरल स्लाइड दिखाई देती है। दोनों स्लाइड्स अपने मूल पृष्ठभूमि रंग बनाए रखती हैं।

नीचे की पंक्तियों में आधे‑सेकंड अंतराल पर PowerPoint से प्राप्त फ्रेम दिखाए गए हैं। प्रत्येक पंक्ति के मध्य फ्रेम की तुलना करके प्रभाव देखें।

![PowerPoint playback with fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप यह कॉन्फ़िगर कर सकते हैं कि कोई स्लाइड स्क्रीन पर कितनी देर तक रहे और क्या माउस क्लिक से स्लाइड शो आगे बढ़े। निम्न मेथड्स इस व्यवहार को नियंत्रित करते हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) दर्शक को माउस क्लिक द्वारा आगे बढ़ने की अनुमति देता है।
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) स्वचालित आगे बढ़ने को सक्षम करता है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) स्वचालित आगे बढ़ने से पहले की देर को मिलीसेकंड में निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों आगे बढ़ना सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर का इंतजार कर सके। केवल टाइमर उपयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) को `false` पास करें। देर निर्धारित करती है कब स्लाइड शो आगे बढ़े; यह दृश्य ट्रांज़िशन प्रभाव की अवधि नहीं सेट करती।

यह उदाहरण प्रथम तीन स्लाइड्स को विभिन्न प्रभाव देता है और क्रमशः 3, 5, और 7 सेकंड के बाद स्वचालित आगे बढ़ना सक्षम करता है। माउस क्लिक से भी इन स्लाइड्स को आगे बढ़ाया जा सकता है। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

जाँचने के लिए कि टाइम्ड आगे बढ़ना सक्षम है या नहीं, [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) को कॉल करें। केवल संग्रहीत देर यह संकेत नहीं देती कि टाइमर सक्रिय है।

अगला उदाहरण उपर्युक्त सहेजी गई फ़ाइल खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक देर वाले स्लाइड्स के लिए स्वचालित आगे बढ़ना निष्क्रिय करता है। उन स्लाइड्स के लिए माउस क्लिक सक्षम करता है और अपडेटेड सेटिंग्स सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ट्रांज़िशन टाइमिंग को सटीक रूप से नियंत्रित करें**

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) का उपयोग करके आप ट्रांज़िशन प्रभाव की लंबाई को मिलीसेकंड में निर्दिष्ट कर सकते हैं। स्लाइड का [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) मेथड इन सेटिंग्स को [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) के माध्यम से उजागर करता है:

| मेथड | उद्देश्य |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | ट्रांज़िशन प्रभाव की अवधि स्वयं को मिलीसेकंड में सेट करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | स्लाइड के स्वचालित आगे बढ़ने से पहले के देर को मिलीसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) को `true` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) से पूर्वनिर्धारित गति श्रेणी (Slow, Medium, या Fast) का चयन करता है। यह तब उपयोग होता है जब सटीक अवधि निर्दिष्ट नहीं की गई हो। |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) केवल ट्रांज़िशन प्रभाव को नियंत्रित करता है; यह निर्धारित नहीं करता कि स्लाइड कितनी देर दृश्यमान रहेगी। स्वचालित आगे बढ़ने की देर को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि सेट नहीं होती, तो Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) मान से प्रभाव अवधि का निर्धारण करता है।

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **हर स्लाइड पर समान अवधि लागू करें**

समान गति बनाए रखने के लिए, प्रत्येक स्लाइड पर समान प्रभाव और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह स्वचालित आगे बढ़ना 5 000 मिलीसेकंड के बाद अलग से सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ना निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // इफ़ेक्ट अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ना कॉन्फ़िगर करें.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **व्यक्तिगत स्लाइड्स के लिए अलग-अलग अवधि निर्धारित करें**

विभिन्न स्लाइड्स विभिन्न प्रभाव अवधि का उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए संक्षिप्त ट्रांज़िशन और अनुभाग परिचय के लिए लंबी ट्रांज़िशन तय करें। यह उदाहरण प्रथम स्लाइड को 500 मिलीसेकंड और द्वितीय स्लाइड को 1 200 मिलीसेकंड की अवधि देता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन समन्वयित करें**

जब आप [animated GIF](/slides/hi/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/php-java/export-to-html5/), या [video](/slides/hi/php-java/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600 मिलीसेकंड का फेड उपयोग करें, और प्रत्येक स्लाइड की आगे बढ़ने की देर को अलग से समायोजित करें ताकि उसकी वार्ता या सामग्री के लिए समय मिले।

GIF और वीडियो के लिए, फ्रेम रेट को प्रभाव अवधि के साथ समन्वयित करें: 600 मिलीसेकंड 30 fps पर 18 फ़्रेम के बराबर है। HTML5 में निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन सक्षम करें। चुने गए निर्यात प्रारूप के समर्थित प्रभाव और टाइमिंग विकल्प जाँचें, और सिंक्रनाइज़ेशन सत्यापित करने के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन संशोधित करने से पहले [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) को कॉल करें ताकि पता चल सके कि कोई स्पष्ट मान संग्रहीत है या नहीं। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि सेट नहीं है; एक गैर‑नकारात्मक मान मिलिसे컨ड में संग्रहीत अवधि को दर्शाता है। अनसेट मान गणना की गई प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) मान से वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से अवधि प्रारंभ हो सकती है, इसलिए मूल सेटिंग्स की पहली जाँच करें।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Morph ट्रांज़िशन**

Morph ट्रांज़िशन क्रमिक स्लाइड्स पर वस्तुओं के बीच परिवर्तन को एनिमेट करता है। सरल Morph प्रभाव बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को स्थानांतरित या आकार बदलें, और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें। यह ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और संशोधित स्थितियों के बीच एनिमेट करता है।

निम्न उदाहरण एक टेक्स्ट आयत वाली स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति व आकार बदलता है। फिर द्वितीय स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) एनीमरेशन से Morph चुनता है। सहेजी गई फ़ाइल को Morph समर्थित प्रस्तुति दर्शक में खोलें और स्लाइड शो के दौरान प्रभाव देखें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Morph ट्रांज़िशन प्रकार**

[TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) एनीमरेशन यह नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता व एनिमेट करता है:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकार को एक पूर्ण वस्तु के रूप में मानता है।
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) जहाँ संभव हो, शब्दों को मिलाकर टेक्स्ट को एनिमेट करता है।
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) जहाँ संभव हो, अक्षरों को मिलाकर टेक्स्ट को एनिमेट करता है।

[setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) का उपयोग करके Morph चुनें, फिर [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) को कॉल करके [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) ऑब्जेक्ट प्राप्त करें, जिसका [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) मेथड मिलान मोड चुनता है।

यह उदाहरण पिछले भाग में बनाई गई प्रस्तुति खोलता है और द्वितीय स्लाइड को शब्द‑आधारित Morph एनिमेशन के लिए कॉन्फ़िगर करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **ट्रांज़िशन प्रभाव सेट करें**

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या क्या प्रभाव काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प उस ट्रांज़िशन पर निर्भर करते हैं जिसे [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) से चुना गया है। पहले प्रकार सेट करें, फिर [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) से उचित ट्रांज़िशन ऑब्जेक्ट का उपयोग करें।

निम्न उदाहरण `input.pptx` की प्रथम स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) के माध्यम से [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) को कॉल करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?**

हां। जब आपको मिलीसेकंड में सटीक प्रभाव अवधि चाहिए तो [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) उपयोग करें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) श्रेणी (Slow, Medium, या Fast) पर्याप्त हो और कोई स्पष्ट अवधि सेट नहीं है, तो [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) उपयोग करें। ये सेटिंग्स ट्रांज़िशन प्रभाव को स्वचालित आगे बढ़ने की देर से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन पर ऑडियो संलग्न कर सकता हूँ और उसे लूप कर सकता हूँ?**

हां। एंबेडेड ऑडियो को [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) से असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) से StartSound को [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) में पास करें, और `true` के साथ [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) सक्षम करें। ऑडियो स्लाइड शो में अगले साउंड इवेंट तक लूप रहेगा।

**सभी स्लाइड्स पर समान ट्रांज़िशन लागू करने का तेज़तम तरीका क्या है?**

प्रस्तुति की [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) संग्रह पर लूप करें और प्रत्येक स्लाइड की ट्रांज़िशन के लिए समान मान के साथ [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) कॉल करें। समान लूप में कोई भी टाइमिंग और प्रभाव विकल्प सेट करें ताकि व्यवहार सभी स्लाइड्स में समान रहे।

**मैं कैसे जाँचूँ कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) परिणाम पर [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) को कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) एनीमरेशन से मान लौटाता है; None का अर्थ है कि कोई ट्रांज़िशन प्रभाव लागू नहीं है।