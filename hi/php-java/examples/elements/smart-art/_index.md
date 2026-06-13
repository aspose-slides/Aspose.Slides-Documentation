---
title: स्मार्टआर्ट
type: docs
weight: 140
url: /hi/php-java/examples/elements/smartart/
keywords:
- स्मार्टआर्ट
- स्मार्टआर्ट जोड़ें
- स्मार्टआर्ट एक्सेस करें
- स्मार्टआर्ट हटाएँ
- स्मार्टआर्ट लेआउट
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में SmartArt बनाएं और संपादित करें: नोड जोड़ें, लेआउट और शैली बदलें, सटीकता के साथ शेप में बदलें, और PPT, PPTX और ODP के लिए निर्यात करें।"
---
स्मार्टआर्ट ग्राफिक्स को जोड़ने, उन्हें एक्सेस करने, हटाने और लेआउट बदलने का तरीका दिखाता है **Aspose.Slides for PHP via Java** का उपयोग करके।

## **स्मार्टआर्ट जोड़ें**

निर्मित लेआउट्स में से एक का उपयोग करके स्मार्टआर्ट ग्राफिक डालें।

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **स्मार्टआर्ट एक्सेस करें**

एक स्लाइड पर पहले स्मार्टआर्ट ऑब्जेक्ट को प्राप्त करें।

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड पर पहला SmartArt एक्सेस करें।
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **स्मार्टआर्ट हटाएँ**

स्लाइड से स्मार्टआर्ट शेप को डिलीट करें।

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि स्लाइड पर पहला आकार SmartArt है।
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **स्मार्टआर्ट लेआउट बदलें**

मौजूदा स्मार्टआर्ट ग्राफिक के लेआउट प्रकार को अपडेट करें।

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि स्लाइड पर पहला आकार SmartArt है।
        $smartArt = $slide->getShapes()->get_Item(0);

        // SmartArt का लेआउट बदलें।
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```