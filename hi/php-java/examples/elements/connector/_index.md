---
title: कनेक्टर
type: docs
weight: 190
url: /hi/php-java/examples/elements/connector/
keywords:
- कनेक्टर
- कनेक्टर जोड़ें
- कनेक्टर पहुँचें
- कनेक्टर हटाएँ
- शेप्स को पुनः कनेक्ट करें
- कोड उदाहरण
- पावरपॉइंट
- ओपनडॉक्युमेंट
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के साथ Aspose.Slides में कनेक्टर्स बनाएं और नियंत्रित करें: जोड़ें, मार्ग निर्धारित करें, पुनः मार्ग निर्धारित करें, कनेक्शन पॉइंट सेट करें, तीर और शैली निर्धारित करें ताकि PPT, PPTX और ODP में आकारों को जोड़ सकें।"
---
यह दिखाता है कि कैसे शेप्स को कनेक्टर्स के साथ जोड़ें और उनके लक्ष्य को बदलें **Aspose.Slides for PHP via Java** का उपयोग करके।

## **कनेक्टर जोड़ें**

स्लाइड पर दो बिंदुओं के बीच एक कनेक्टर शेप डालें।

```php
function addConnector() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $connector = $slide->Shapes->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $presentation->save("connector.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **कनेक्टर तक पहुँचें**

स्लाइड में जोड़ा गया पहला कनेक्टर शेप प्राप्त करें।

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड पर पहला कनेक्टर एक्सेस करें।
        $firstConnector = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $firstConnector = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **कनेक्टर हटाएँ**

स्लाइड से एक कनेक्टर हटाएँ।

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि स्लाइड पर पहला आकार एक कनेक्टर है।
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **शेप्स को पुनः कनेक्ट करें**

शुरुआत और अंत लक्ष्यों को असाइन करके दो शेप्स को एक कनेक्टर से जोड़ें।

```php
function reconnectShapes() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
        $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $connector->setStartShapeConnectedTo($shape1);
        $connector->setEndShapeConnectedTo($shape2);

        $presentation->save("shapes_reconnected.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```