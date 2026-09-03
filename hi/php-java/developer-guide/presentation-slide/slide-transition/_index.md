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
- Morph ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ने को कॉन्फ़िगर करें, और Morph और अन्य ट्रांज़िशन इफ़ेक्ट को अनुकूलित करें।"
---
## **समीक्षा**

स्लाइड ट्रांज़िशन स्लाइड शो के दौरान स्लाइड्स के प्रकट होने को नियंत्रित करता है। Aspose.Slides for PHP via Java का उपयोग करके आप प्रत्येक स्लाइड के लिए ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर से आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट‑विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह लेख PHP उदाहरणों के माध्यम से ट्रांज़िशन लागू करना, सटीक ट्रांज़िशन अवधि सेट करना, स्लाइड टाइमिंग प्रबंधन, तथा दो स्लाइड्स के बीच Morph ट्रांज़िशन बनाना दिखाता है। उदाहरण यह भी दर्शाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

ट्रांज़िशन लागू करने के लिए, [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें और [getSlideShowTransition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/#getSlideShowTransition) के माध्यम से स्लाइड की ट्रांज़िशन सेटिंग्स तक पहुंचें। फिर [setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setType) को [TransitionType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitiontype/) एन्यूमरेशन के मान के साथ उपयोग करके ट्रांज़िशन प्रकार निर्धारित करें, और प्रस्तुति सहेजें।

निम्न उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप निर्धारित कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर तक बनी रहे और क्या माउस क्लिक से स्लाइड शो आगे बढ़े। निम्न विधियां इस व्यवहार को नियंत्रित करती हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) दर्शक को माउस क्लिक से आगे बढ़ने देता है।
- [setAdvanceAfter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) स्वचालित रूप से आगे बढ़ने को सक्षम करता है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) स्वचालित आगे बढ़ने से पहले की देरी (मिलीसेकंड में) निर्दिष्ट करता है।

क्लिक और टाइमर दोनों को सक्षम करें ताकि दर्शक क्लिक करके आगे बढ़ सके या टाइमर का इंतजार कर सके। केवल टाइमर का उपयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) को `false` पास करें। देरी निर्धारित करती है कि स्लाइड शो कब आगे बढ़ेगा; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि निर्धारित नहीं करता।

यह उदाहरण पहले तीन स्लाइड्स को विभिन्न इफ़ेक्ट देता है और क्रमशः 3, 5, और 7 सेकंड की स्वचालित आगे बढ़ने की अवधि सेट करता है। माउस क्लिक से भी इन स्लाइड्स को आगे बढ़ाया जा सकता है। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

टाइमर सक्रिय है या नहीं, यह जांचने के लिए [getAdvanceAfter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) को कॉल करें। केवल संग्रहीत देरी यह संकेत नहीं देती कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्रिय टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक की देरी वाली स्लाइड्स के लिए स्वचालित आगे बढ़ने को निष्क्रिय करता है। इन स्लाइड्स के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

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

ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई (मिलीसेकंड में) निर्दिष्ट करने के लिए [setDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setDuration) का उपयोग करें। स्लाइड की [getSlideShowTransition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/#getSlideShowTransition) विधि इन सेटिंग्स को [SlideShowTransition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/) के माध्यम से उजागर करती है:

| विधि | प्रयोजन |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setDuration) | ट्रांज़िशन इफ़ेक्ट की अवधि (मिलीसेकंड) निर्धारित करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | स्लाइड के स्वचालित आगे बढ़ने से पहले की देरी (मिलीसेकंड) निर्धारित करता है। इस टाइमर को सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) को `true` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitionspeed/) के प्री‑डिफ़ाइंड गति वर्ग (Slow, Medium, Fast) में से एक चुनता है। जब सटीक अवधि निर्दिष्ट नहीं होती तो इसका उपयोग होता है। |

[setDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setDuration) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह नहीं तय करता कि स्लाइड कितनी देर तक दृश्यमान रहे। स्वचालित आगे बढ़ने की देरी को अलग से कॉन्फ़िगर करें। यदि स्पष्ट अवधि नहीं दी गई है, तो Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#getSpeed) मान से इफ़ेक्ट अवधि निर्धारित करता है।

### **हर स्लाइड पर समान अवधि लागू करें**

समान गति बनाए रखने के लिए हर स्लाइड पर एक ही इफ़ेक्ट और समान अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन की अवधि 750 मिलीसेकंड सेट करता है। यह स्वचालित आगे बढ़ने को 5,000 मिलीसेकंड बाद सक्षम करता है और माउस क्लिक से आगे बढ़ने को निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

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

        // स्वचालित आगे बढ़ने को प्रभाव अवधि से स्वतंत्र रूप से कॉन्फ़िगर करें।
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **विभिन्न स्लाइड्स के लिए अलग-अलग अवधि सेट करें**

विभिन्न स्लाइड्स में अलग-अलग इफ़ेक्ट अवधि हो सकती है। उदाहरण के लिए, शीर्षक स्लाइड के लिए छोटा ट्रांज़िशन और सेक्शन परिचय के लिए लंबा ट्रांज़िशन उपयोग करें। यह उदाहरण पहले स्लाइड की अवधि 500 मिलीसेकंड और दूसरे स्लाइड की 1,200 मिलीसेकंड सेट करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन समन्वय करें**

जब आप [animated GIF](/slides/hi/php-java/convert-powerpoint-to-animated-gif/), [HTML5 प्रस्तुति](/slides/hi/php-java/export-to-html5/) या [वीडियो](/slides/hi/php-java/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600 मिलीसेकंड का फ़ेड उपयोग करें और प्रत्येक स्लाइड की आगे बढ़ने की देरी अलग से समायोजित करें ताकि उसकी वचन या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिए, फ्रेम रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 मिलीसेकंड = 30 fps पर 18 फ़्रेम। HTML5 में, निर्यात सेटिंग्स में एनीमेटेड ट्रांज़िशन को सक्षम करें। चुने गए निर्यात स्वरूप द्वारा समर्थित इफ़ेक्ट और टाइमिंग विकल्प देखें, और सिंक्रनाइज़ेशन की पुष्टि करने के लिए आउटपुट का पूर्वावलोकन करें।

### **मौज़ूद ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को बदलने से पहले [getDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#getDuration) को कॉल करके देखें कि कोई स्पष्ट मान संग्रहीत है या नहीं। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि निर्धारित नहीं है; गैर‑नकारात्मक मान मिलीसेकंड में संग्रहीत अवधि दर्शाता है। यह सेट नहीं किया गया मान गणना की गई प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#getSpeed) मान से वही अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से अवधि प्रारंभ हो सकती है, इसलिए मूल सेटिंग्स को पहले जांचें।

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

Morph ट्रांज़िशन क्रमागत स्लाइड्स पर वस्तुओं के बीच परिवर्तन को एनीमेट करता है। एक सरल Morph इफ़ेक्ट बनाने के लिए, स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को स्थानांतरित या आकार बदलें, और दूसरे स्लाइड पर Morph ट्रांज़िशन लागू करें। इससे ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और संशोधित स्थितियों के बीच एनीमेट करता है।

निम्न उदाहरण एक टेक्स्ट आयत वाले स्लाइड को बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत का स्थान व आकार बदलता है। फिर दूसरा स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitiontype/) एन्यूमरेशन से Morph चुनता है। Morph को समर्थन देने वाले प्रस्तुति व्यूअर में सहेजी गई फ़ाइल खोलें ताकि स्लाइड शो के दौरान प्रभाव देख सकें।

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

[TransitionMorphType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitionmorphtype/) एन्यूमरेशन यह नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकार को एक पूर्ण वस्तु के रूप में लेता है।
- [ByWord](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitionmorphtype/#ByWord) जहाँ संभव हो शब्दों को मिलाकर टेक्स्ट एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitionmorphtype/#ByChar) जहाँ संभव हो अक्षरों को मिलाकर टेक्स्ट एनीमेट करता है।

[setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setType) का उपयोग करके Morph चुनें, फिर [getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#getValue) को कॉल करें। यह एक [MorphTransition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/morphtransition/) ऑब्जेक्ट प्रदान करता है, जिसका [setMorphType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/morphtransition/#setMorphType) मेथड मिलान मोड चुनता है।

यह उदाहरण पिछले सेक्शन में बनाई गई प्रस्तुति को खोलता है और दूसरे स्लाइड को शब्द-आधारित Morph एनीमेशन के लिए कॉन्फ़िगर करता है।

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

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या इफ़ेक्ट का काली स्क्रीन से शुरू होना। उपलब्ध विकल्प उस ट्रांज़िशन पर निर्भर करते हैं जिसे आपने [setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setType) से चुना है। पहले प्रकार सेट करें, फिर [getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#getValue) से उचित ट्रांज़िशन ऑब्जेक्ट का उपयोग करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [OptionalBlackTransition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/optionalblacktransition/) के माध्यम से [setFromBlack](https://reference.aspose.com/slides/hi/php-java/aspose.slides/optionalblacktransition/#setFromBlack) को कॉल करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

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

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?**

हां। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए तो [setDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setDuration) को प्राथमिकता दें। जब प्री‑डिफ़ाइंड [TransitionSpeed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitionspeed/) (Slow, Medium, Fast) पर्याप्त हो और कोई स्पष्ट अवधि सेट न हो तो [setSpeed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setSpeed) का उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित आगे बढ़ने की देरी से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन के साथ ऑडियो संलग्न कर उसे लूप कर सकता हूँ?**

हां। [setSound](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setSound) से एंबेडेड ऑडियो असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitionsoundmode/) से `StartSound` को [setSoundMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setSoundMode) में पास करें, और `true` के साथ [setSoundLoop](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setSoundLoop) को सक्षम करें। ऑडियो अगले साउंड इवेंट तक लूप रहेगा।

**सभी स्लाइड्स पर एक ही ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेजेंटेशन की [getSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSlides) कलेक्शन के माध्यम से लूप करें और प्रत्येक स्लाइड के ट्रांज़िशन पर समान मान के साथ [setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#setType) कॉल करें। उसी लूप में टाइमिंग और इफ़ेक्ट विकल्प भी सेट करें ताकि सभी स्लाइड्स में व्यवहार समान रहे।

**मैं कैसे जांचूँ कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [getSlideShowTransition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/#getSlideShowTransition) परिणाम पर [getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/#getType) को कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitiontype/) एन्यूमरेशन से मान लौटाता है; `None` का मतलब है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।