---
title: स्लाइड ट्रांज़िशन
type: docs
weight: 110
url: /hi/php-java/examples/elements/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन तक पहुँचें
- स्लाइड ट्रांज़िशन हटाएँ
- ट्रांज़िशन अवधि
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में स्लाइड ट्रांज़िशन को नियंत्रित करें: प्रकार, गति, ध्वनि और टाइमिंग चुनें ताकि PPT, PPTX और ODP में प्रस्तुतियों को बेहतर बनाया जा सके।"
---
स्लाइड ट्रांज़िशन इफ़ेक्ट और टाइमिंग को लागू करने का प्रदर्शन **Aspose.Slides for PHP via Java** के साथ करता है।

## **स्लाइड ट्रांज़िशन जोड़ें**

पहली स्लाइड पर फ़ेड ट्रांज़िशन इफ़ेक्ट लागू करें।

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // फ़ेड ट्रांज़िशन लागू करें।
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **स्लाइड ट्रांज़िशन तक पहुँचें**

स्लाइड को सौंपे गए ट्रांज़िशन प्रकार को पढ़ें।

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // ट्रांज़िशन प्रकार तक पहुँचें।
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **स्लाइड ट्रांज़िशन हटाएँ**

`None` प्रकार सेट करके किसी भी ट्रांज़िशन इफ़ेक्ट को साफ़ करें।

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // कोई ट्रांज़िशन नहीं सेट करके हटाएँ।
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ट्रांज़िशन अवधि सेट करें**

स्लाइड को स्वचालित रूप से आगे बढ़ने से पहले कितनी देर दिखाना है, यह निर्धारित करें।

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // मिलीसेकंड में।

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```