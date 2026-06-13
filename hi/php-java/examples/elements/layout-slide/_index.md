---
title: लेआउट स्लाइड
type: docs
weight: 20
url: /hi/php-java/examples/elements/layout-slide/
keywords:
- लेआउट स्लाइड
- लेआउट स्लाइड जोड़ें
- लेआउट स्लाइड एक्सेस करें
- लेआउट स्लाइड हटाएँ
- अप्रयुक्त लेआउट स्लाइड
- लेआउट स्लाइड क्लोन करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ लेआउट स्लाइड्स को प्रबंधित करने के लिए PHP का उपयोग करें: PPT, PPTX और ODP के लिए प्रस्तुतियों में प्लेसहोल्डर्स और थीम को बनाएं, लागू करें, क्लोन करें, नाम बदलें और अनुकूलित करें।"
---
यह लेख Aspose.Slides for PHP via Java में **Layout Slides** के साथ काम करने का प्रदर्शन करता है। एक लेआउट स्लाइड वह डिज़ाइन और फ़ॉर्मेटिंग परिभाषित करती है जो सामान्य स्लाइड्स द्वारा विरासत में मिलती है। आप लेआउट स्लाइड्स को जोड़, एक्सेस, क्लोन और हटाने के साथ-साथ उपयोग में न आने वाली स्लाइड्स को साफ़ करके प्रस्तुति का आकार घटा सकते हैं।

## **लेआउट स्लाइड जोड़ें**

आप पुन: उपयोग योग्य फ़ॉर्मेटिंग निर्धारित करने के लिए एक कस्टम लेआउट स्लाइड बना सकते हैं। उदाहरण के लिए, आप इस लेआउट का उपयोग करने वाली सभी स्लाइड्स पर दिखाई देने वाला एक टेक्स्ट बॉक्स जोड़ सकते हैं।

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // एक ब्लैंक लेआउट प्रकार और एक कस्टम नाम के साथ लेआउट स्लाइड बनाएँ।
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** लेआउट स्लाइड्स व्यक्तिगत स्लाइड्स के लिए टेम्पलेट जैसी कार्य करती हैं। आप सामान्य तत्वों को एक बार परिभाषित करके कई स्लाइड्स में पुन: उपयोग कर सकते हैं।

> 💡 **Tip 2:** जब आप लेआउट स्लाइड में आकार या टेक्स्ट जोड़ते हैं, तो उस लेआउट पर आधारित सभी स्लाइड्स स्वचालित रूप से यह साझा सामग्री प्रदर्शित करेंगे।  
> नीचे दिया गया स्क्रीनशॉट दो स्लाइड्स दिखाता है, जिनमें से प्रत्येक समान लेआउट स्लाइड से एक टेक्स्ट बॉक्स विरासत में प्राप्त करता है।

![लेआउट सामग्री विरासत में लेने वाली स्लाइड्स](layout-slide-result.png)

## **लेआउट स्लाइड तक पहुँचें**

लेआउट स्लाइड्स को इंडेक्स या लेआउट प्रकार (जैसे `Blank`, `Title`, `SectionHeader`, आदि) द्वारा एक्सेस किया जा सकता है।

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // इंडेक्स द्वारा एक्सेस करें.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // लेआउट प्रकार द्वारा एक्सेस करें.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **लेआउट स्लाइड हटाएँ**

यदि किसी विशेष लेआउट स्लाइड की अब आवश्यकता नहीं है तो आप उसे हटा सकते हैं।

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // प्रकार द्वारा लेआउट स्लाइड प्राप्त करें और उसे हटाएँ।
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

प्रस्तुति का आकार घटाने के लिए आप उन लेआउट स्लाइड्स को हटाना चाह सकते हैं जो किसी सामान्य स्लाइड द्वारा उपयोग नहीं की गई हैं।

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // सभी लेआउट स्लाइड्स को स्वचालित रूप से हटाता है जो किसी भी स्लाइड द्वारा संदर्भित नहीं हैं।
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **लेआउट स्लाइड क्लोन करें**

आप `addClone` मेथड का उपयोग करके लेआउट स्लाइड को डुप्लीकेट कर सकते हैं।

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // प्रकार द्वारा मौजूदा लेआउट स्लाइड प्राप्त करें.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // लेआउट स्लाइड संग्रह के अंत में लेआउट स्लाइड को क्लोन करें.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **सारांश:** लेआउट स्लाइड्स स्लाइड्स के बीच सुसंगत फ़ॉर्मेटिंग प्रबंधित करने के लिए एक शक्तिशाली साधन हैं। Aspose.Slides लेआउट स्लाइड्स को बनाने, प्रबंधित करने और अनुकूलित करने पर पूर्ण नियंत्रण प्रदान करता है।