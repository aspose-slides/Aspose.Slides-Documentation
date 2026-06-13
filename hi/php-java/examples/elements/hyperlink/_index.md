---
title: हाइपरलिंक
type: docs
weight: 130
url: /hi/php-java/examples/elements/hyperlink/
keywords:
- हाइपरलिंक
- हाइपरलिंक जोड़ें
- हाइपरलिंक एक्सेस करें
- हाइपरलिंक हटाएँ
- हाइपरलिंक अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में हाइपरलिंक जोड़ें, संपादित करें और हटाएँ: लिंक टेक्स्ट, शेप्स, स्लाइड्स, यूआरएल और ईमेल; PPT, PPTX और ODP के लिए टार्गेट और एक्शन सेट करें।"
---
शेप्स पर हाइपरलिंक जोड़ने, एक्सेस करने, हटाने और अपडेट करने का प्रदर्शन करता है, **Aspose.Slides for PHP via Java** का उपयोग करके।

## **हाइपरलिंक जोड़ें**

एक बाह्य वेबसाइट की ओर संकेत करने वाले हाइपरलिंक के साथ एक आयताकार आकार बनाएँ।

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **हाइपरलिंक एक्सेस करें**

एक आकार के पाठ भाग से हाइपरलिंक जानकारी पढ़ें।

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि पहली आकृति में हाइपरलिंक है।
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **हाइपरलिंक हटाएँ**

एक आकार के पाठ से हाइपरलिंक साफ़ करें।

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि पहली आकृति में हाइपरलिंक है।
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **हाइपरलिंक अपडेट करें**

मौजूदा हाइपरलिंक के लक्ष्य को बदलें। `HyperlinkManager` का उपयोग करके वह पाठ संशोधित करें जिसमें पहले से हाइपरलिंक मौजूद है, जिससे PowerPoint हाइपरलिंक को सुरक्षित रूप से अपडेट करता है, इसका अनुकरण होता है।

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि पहली आकृति में हाइपरलिंक है।
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // मौजूदा टेक्स्ट में हाइपरलिंक बदलना HyperlinkManager के ज़रिए किया जाना चाहिए
        // प्रॉपर्टी को सीधे सेट करने की बजाय।
        // यह दर्शाता है कि PowerPoint सुरक्षित रूप से हाइपरलिंक कैसे अपडेट करता है।
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```