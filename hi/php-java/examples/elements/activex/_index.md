---
title: ActiveX
type: docs
weight: 200
url: /hi/php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX कंट्रोल
- ActiveX जोड़ें
- ActiveX एक्सेस करें
- ActiveX हटाएँ
- ActiveX प्रॉपर्टी
- कोड उदाहरण
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में ActiveX कंट्रोल को खोजने, संपादित करने और हटाने का तरीका सीखें, जिसमें PowerPoint प्रस्तुतियों के लिए प्रॉपर्टी अपडेट शामिल हैं।"
---
एक प्रस्तुतिकरण में **Aspose.Slides for PHP via Java** का उपयोग करके ActiveX कंट्रोल को जोड़ने, एक्सेस करने, हटाने और कॉन्फ़िगर करने का प्रदर्शन करता है।

## **एक ActiveX कंट्रोल जोड़ें**

एक नया ActiveX कंट्रोल सम्मिलित करें।

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // एक नया ActiveX कंट्रोल जोड़ें।
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // प्रस्तुति को डिस्पोज़ करें।
        $presentation->dispose();
    }
}
```

## **एक ActiveX कंट्रोल एक्सेस करें**

स्लाइड पर पहले ActiveX कंट्रोल से जानकारी पढ़ें।

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // पहले ActiveX कंट्रोल तक पहुंचें।
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // प्रस्तुति को डिस्पोज़ करें।
        $presentation->dispose();
    }
}
```

## **एक ActiveX कंट्रोल हटाएँ**

स्लाइड से मौजूदा ActiveX कंट्रोल को हटा दें।

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // पहला ActiveX कंट्रोल हटाएँ।
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // प्रस्तुति को डिस्पोज़ करें।
        $presentation->dispose();
    }
}
```

## **ActiveX प्रॉपर्टी सेट करें**

कई ActiveX प्रॉपर्टियों को कॉन्फ़िगर करें।

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि पहला कंट्रोल वही है जिसे हमने जोड़ा है।
        $control = $slide->getControls()->get_Item(0);

        // प्रॉपर्टी कॉन्फ़िगर करें।
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // प्रस्तुति को डिस्पोज़ करें।
        $presentation->dispose();
    }
}
```