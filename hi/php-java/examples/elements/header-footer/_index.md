---
title: हेडरफ़ुटर
type: docs
weight: 220
url: /hi/php-java/examples/elements/header-footer/
keywords:
- हेडर फ़ुटर
- हेडर फ़ुटर जोड़ें
- हेडर फ़ुटर अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में हेडर और फ़ुटर नियंत्रित करें: तिथि/समय, स्लाइड नंबर और फ़ुटर टेक्स्ट जोड़ें या संपादित करें, और PPT, PPTX और ODP में प्लेसहोल्डर को दिखाएँ या छुपाएँ।"
---
Aspose.Slides for PHP via Java का उपयोग करके फ़ुटर जोड़ने और तिथि व समय प्लेसहोल्डर अपडेट करने का तरीका दर्शाता है।

## **फ़ुटर जोड़ें**

स्लाइड के फ़ुटर क्षेत्र में टेक्स्ट जोड़ें और इसे दृश्यमान बनाएं।

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **तिथि और समय अपडेट करें**

स्लाइड में तिथि और समय प्लेसहोल्डर को संशोधित करें।

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```