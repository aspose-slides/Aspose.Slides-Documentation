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
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड अग्रसरता कॉन्फ़िगर करें, और Morph तथा अन्य ट्रांज़िशन इफ़ेक्ट को अनुकूलित करें।"
---
## **समीक्षा**

Slide transitions नियंत्रित करते हैं कि स्लाइड शो के दौरान स्लाइडें कैसे प्रदर्शित होती हैं। Aspose.Slides for PHP via Java के साथ आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा स्लाइड आगे बढ़ाने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट‑विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह लेख PHP उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग प्रबंधित करता है, और दो स्लाइडों के बीच एक Morph ट्रांज़िशन बनाता है। उदाहरण यह भी दर्शाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

एक ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास से प्रेज़ेंटेशन लोड करें और [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) के माध्यम से स्लाइड की ट्रांज़िशन सेटिंग्स तक पहुँचें। [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) को [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) एनीमरेशन में से किसी मान के साथ उपयोग करें, फिर प्रेज़ेंटेशन को सहेजें।

निम्न उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइडों वाली एक `input.pptx` फ़ाइल का उपयोग करें।

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

[setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) मेथड निर्धारित करता है कि लक्ष्य स्लाइड को प्रकट करने के लिए कितने रेडियल सेक्टर उपयोग किए जाएँ। [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) को [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) से Wheel चुनने के लिए उपयोग करें, फिर [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) को कॉल करके [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) सेटिंग्स तक पहुँचें।

उदाहरण दो समान स्लाइड जोड़ों को बनाता है। प्रत्येक जोड़ी एक काली स्लाइड से शुरू होती है और एक सोने के आयत द्वारा ढकी हुई स्लाइड पर समाप्त होती है। स्लाइड 2 में एक स्पोक और स्लाइड 4 में आठ स्पोक उपयोग किए गए हैं। दोनों ट्रांज़िशन समान धीमी गति का उपयोग करते हैं, जिसे [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) से सेट किया जाता है, और 8 000 मिलीसेकंड की स्पष्ट अवधि, जिसे [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) से सेट किया जाता है।

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

सहेजे गए प्रेज़ेंटेशन को PowerPoint में खोलें और स्लाइड शो शुरू करें। स्लाइड 1 से स्लाइड 2 पर आगे बढ़ें ताकि एकल clockwise स्वेप देखें। फिर स्लाइड 3 से स्लाइड 4 पर आगे बढ़ें ताकि आठ रेडियल सेक्टर एक साथ आयत को प्रकट करें।

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप यह कॉन्फ़िगर कर सकते हैं कि एक स्लाइड स्क्रीन पर कितनी देर तक रहे और क्या माउस क्लिक से स्लाइड शो आगे बढ़े। निम्न मेथड्स इस व्यवहार को नियंत्रित करते हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) दर्शक को माउस क्लिक करके आगे बढ़ाने की अनुमति देता है।
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) स्वचालित आगे बढ़ाने को सक्षम करता है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) स्वचालित आगे बढ़ाने से पहले का विलंब (मिलीसेकंड में) निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों आगे बढ़ाने को सक्षम करें ताकि दर्शक क्लिक करके आगे बढ़ सके या टाइमर का इंतज़ार कर सके। केवल टाइमर का उपयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) को `false` पास करें। विलंब इस बात को नियंत्रित करता है कि स्लाइड शो कब आगे बढ़े; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि सेट नहीं करता।

यह उदाहरण पहले तीन स्लाइडों को विभिन्न इफ़ेक्ट्स असाइन करता है और क्रमशः 3, 5, और 7 सेकंड के बाद स्वचालित आगे बढ़ाने को सक्षम करता है। माउस क्लिक भी इन स्लाइडों को आगे बढ़ा सकता है। कम से कम तीन स्लाइडों वाली एक `input.pptx` फ़ाइल का उपयोग करें।

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

यह जांचने के लिए कि टाइम्ड आगे बढ़ाना सक्षम है या नहीं, [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) को कॉल करें। केवल संग्रहीत विलंब यह संकेत नहीं देता कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक विलंब वाली स्लाइडों के लिए स्वचालित आगे बढ़ाने को अक्षम करता है। उन स्लाइडों के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

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

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) का उपयोग करके ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई (मिलीसेकंड में) निर्दिष्ट करें। स्लाइड की [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) मेथड इन सेटिंग्स को [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) के माध्यम से उजागर करती है:

| विधि | उद्देश्य |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | ट्रांज़िशन इफ़ेक्ट की स्वयं की अवधि को मिलीसेकंड में सेट करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | स्लाइड के स्वचालित रूप से आगे बढ़ने से पहले का विलंब (मिलीसेकंड) सेट करता है। इस टाइमर को सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) को `true` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) में से Slow, Medium, या Fast जैसी पूर्वनिर्धारित गति श्रेणी का चयन करता है। यह तब उपयोग होता है जब कोई स्पष्ट अवधि निर्दिष्ट नहीं की गई हो। |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह नहीं निर्धारित करता कि स्लाइड कितनी देर तक दिखाई दे। स्वचालित आगे बढ़ाने के विलंब को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि सेट नहीं होती, तो Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) मान के आधार पर इफ़ेक्ट अवधि निर्धारित करता है।

<!-- visual-explanation:slide-transition:start -->
[![अलग-अलग बार 750 ms ट्रांज़िशन अवधि और 5 000 ms स्वचालित आगे बढ़ाने की सेटिंग को दर्शाते हैं।](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*साझा उदाहरण प्रत्येक स्लाइड को 750 ms Fade ट्रांज़िशन देता है और अलग से 5 000 ms पर स्वचालित आगे बढ़ाने को सक्षम करता है। ट्रांज़िशन अवधि इफ़ेक्ट को नियंत्रित करती है; आगे बढ़ाना तय करता है कि स्लाइड कब छोड़ी जाए। ये बार स्कीमैटिक सेटिंग्स हैं, न कि मापी गई संयुक्त टाइमलाइन।*
<!-- visual-explanation:slide-transition:end -->

### **हर स्लाइड पर समान अवधि लागू करें**

सुसंगत गति हेतु, हर स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह अलग से 5 000 मिलीसेकंड के बाद स्वचालित आगे बढ़ाने को सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ाने को अक्षम करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

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

        // इफ़ेक्ट अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ाने को कॉन्फ़िगर करें।
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **विभिन्न स्लाइडों के लिए अलग-अलग अवधि सेट करें**

विभिन्न स्लाइडें विभिन्न इफ़ेक्ट अवधि इस्तेमाल कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए छोटा ट्रांज़िशन और सेक्शन परिचय के लिए लंबा ट्रांज़िशन उपयोग करें। यह उदाहरण पहली स्लाइड के लिए 500 ms और दूसरी स्लाइड के लिए 1 200 ms सेट करता है। कम से कम दो स्लाइडों वाली एक `input.pptx` फ़ाइल का उपयोग करें।

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

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन को समन्वयित करें**

जब आप एक [animated GIF](/slides/hi/php-java/convert-powerpoint-to-animated-gif/) , [HTML5 presentation](/slides/hi/php-java/export-to-html5/) या [video](/slides/hi/php-java/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खा सके। उदाहरण के लिए, दृश्यों के बीच 600 ms फ़ेड उपयोग करें, और प्रत्येक स्लाइड के आगे बढ़ाने के विलंब को अलग से समायोजित करें ताकि वर्णन या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिए, आउटपुट फ्रेम रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 ms का मतलब 30 fps पर 18 फ्रेम है। HTML5 में, निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन को सक्षम करें। चुने गए निर्यात फ़ॉर्मेट द्वारा समर्थित इफ़ेक्ट्स और टाइमिंग विकल्पों की जाँच करें, और समक्रमण सुनिश्चित करने के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

[getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) को कॉल करके बदलाव करने से पहले यह निर्धारित करें कि क्या कोई स्पष्ट मान संग्रहीत है। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि सेट नहीं है; एक गैर‑नकारात्मक मान मिलीसेकंड में संग्रहीत अवधि को दर्शाता है। यह अनसेट मान गणना किए गए प्लेबैक अवधि के बराबर नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) मान से वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से एक अवधि प्रारंभ हो सकती है, इसलिए मूल सेटिंग्स को पहले जांचें।

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

Morph ट्रांज़िशन क्रमिक स्लाइडों पर वस्तुओं के बीच होने वाले परिवर्तनों को एनीमेट करता है। एक सरल Morph इफ़ेक्ट बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को ले जाएँ या उसका आकार बदलें, और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें। यह ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और संशोधित स्थितियों के बीच एनीमेट करने देता है।

निम्न उदाहरण एक टेक्स्ट आयत वाली स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर यह दूसरी स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) एनीमरेशन से Morph चुनता है। Morph का समर्थन करने वाले प्रेज़ेंटेशन व्यूअर में सहेजी गई फ़ाइल खोलें ताकि स्लाइड शो के दौरान इफ़ेक्ट देखें।

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

[TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) एनीमरेशन यह नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकार को पूरे वस्तु के रूप में मानता है।
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) जहाँ संभव हो शब्दों के आधार पर टेक्स्ट एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) जहाँ संभव हो अक्षरों के आधार पर टेक्स्ट एनीमेट करता है।

[setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) का उपयोग करके Morph चुनें, फिर [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) तक पहुँचें। यह मान एक [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) ऑब्जेक्ट प्रदान करता है, जिसका [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) मेथड मिलान मोड चुनता है।

यह उदाहरण पिछले अनुभाग में बनाई गई प्रेज़ेंटेशन खोलता है और दूसरी स्लाइड को शब्द‑आधारित Morph एनीमेशन उपयोग करने के लिए कॉन्फ़िगर करता है।

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

## **ट्रांज़िशन इफ़ेक्ट सेट करें**

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या क्या इफ़ेक्ट काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प इस पर निर्भर करते हैं कि आप [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) के साथ कौन सा ट्रांज़िशन चुनते हैं। पहले प्रकार सेट करें, फिर [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) से उपयुक्त ट्रांज़िशन ऑब्जेक्ट का उपयोग करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) के माध्यम से [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) को कॉल करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

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

## **FAQ**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक स्पीड को नियंत्रित कर सकता हूँ?**

हाँ। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए, तो [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) का उपयोग करें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) श्रेणी (Slow, Medium, या Fast) पर्याप्त हो और कोई स्पष्ट अवधि सेट नहीं है, तो [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) का उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित आगे बढ़ाने के विलंब से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन के साथ ऑडियो संलग्न कर उसे लूप कर सकता हूँ?**

हाँ। [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) के साथ एंबेडेड ऑडियो असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) एनीमरेशन से `StartSound` को [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) को पास करें, और `true` के साथ [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) को सक्षम करें। ऑडियो तब अगले साउंड इवेंट तक लूप में रहेगा।

**हर स्लाइड पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेज़ेंटेशन की [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) कलेक्शन पर लूप चलाएँ और प्रत्येक स्लाइड के ट्रांज़िशन के लिए एक ही मान के साथ [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) को कॉल करें। वही लूप में कोई भी टाइमिंग और इफ़ेक्ट विकल्प सेट करें ताकि सभी स्लाइडों में व्यवहार समान रहे।

**मैं कैसे जांचूँ कि वर्तमान में स्लाइड पर कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) परिणाम पर [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) को कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) एनीमरेशन से एक मान लौटाता है; `None` का मतलब है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।