---
title: इंक
type: docs
weight: 180
url: /hi/php-java/examples/elements/ink/
keywords:
- इंक
- इंक तक पहुँचें
- इंक हटाएँ
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में स्लाइड्स पर डिजिटल इंक को संभालें: पेन स्ट्रोक जोड़ें, पाथ संपादित करें, रंग और चौड़ाई निर्धारित करें, और परिणामों को PowerPoint और OpenDocument के लिए निर्यात करें।"
---
**Aspose.Slides for PHP via Java** का उपयोग करके मौजूदा इंक आकारों तक पहुँचने और उन्हें हटाने के उदाहरण प्रदान करता है।

> ❗ **नोट:** इंक आकार विशिष्ट डिवाइसों से उपयोगकर्ता इनपुट का प्रतिनिधित्व करते हैं। Aspose.Slides प्रोग्रामेटिक रूप से नई इंक स्ट्रोक नहीं बना सकता, लेकिन आप मौजूदा इंक को पढ़ और संशोधित कर सकते हैं।

## **इंक तक पहुँचें**

स्लाइड पर पहला इंक आकार प्राप्त करें।

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड पर पहला इंक आकार एक्सेस करें।
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **इंक हटाएँ**

स्लाइड से एक इंक आकार हटाएँ।

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मानते हुए कि स्लाइड पर पहला आकार एक इंक आकार है।
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```