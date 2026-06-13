---
title: चार्ट
type: docs
weight: 60
url: /hi/php-java/examples/elements/chart/
keywords:
- चार्ट
- चार्ट जोड़ें
- चार्ट एक्सेस करें
- चार्ट हटाएँ
- चार्ट अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में चार्ट बनाएं और कस्टमाइज़ करें: डेटा जोड़ें, सीरीज़, एक्सिस और लेबल फ़ॉर्मेट करें, प्रकार बदलें, और एक्सपोर्ट करें—PPT, PPTX और ODP के साथ काम करता है।"
---
**Aspose.Slides for PHP via Java** के साथ विभिन्न चार्ट प्रकारों को जोड़ने, एक्सेस करने, हटाने और अपडेट करने के उदाहरण। नीचे दिए गए स्निपेट्स बुनियादी चार्ट संचालन को दर्शाते हैं।

## **एक चार्ट जोड़ें**

यह मेथड पहली स्लाइड पर एक साधारण एरिया चार्ट जोड़ता है।

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड में एक साधारण कॉलम चार्ट जोड़ें।
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **एक चार्ट एक्सेस करें**

शेप कलेक्शन से चार्ट को प्राप्त करें।

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड पर पहला चार्ट एक्सेस करें।
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **एक चार्ट हटाएँ**

निम्नलिखित कोड एक स्लाइड से चार्ट को हटाता है।

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लीजिए कि स्लाइड पर पहला आकार चार्ट है।
        $chart = $slide->getShapes()->get_Item(0);

        // चार्ट हटाएँ।
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **चार्ट डेटा अपडेट करें**

आप शीर्षक जैसे चार्ट प्रॉपर्टीज़ को बदल सकते हैं।

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि स्लाइड पर पहला आकार चार्ट है।
        $chart = $slide->getShapes()->get_Item(0);

        // चार्ट शीर्षक बदलें।
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```