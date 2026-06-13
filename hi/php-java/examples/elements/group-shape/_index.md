---
title: GroupShape
type: docs
weight: 170
url: /hi/php-java/examples/elements/group-shape/
keywords:
- समूह
- समूह आकृति जोड़ें
- समूह आकृति तक पहुँचें
- समूह आकृति हटाएँ
- समूह रहित आकृतियाँ
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके PHP में समूह आकृतियों के साथ काम करें: बनाइए और समूह‑रहित कीजिए, चाइल्ड आकृतियों को पुनः क्रमबद्ध कीजिए, PowerPoint और OpenDocument में ट्रांसफ़ॉर्म और बाउंड्स सेट कीजिए।"
---
**Aspose.Slides for PHP via Java** का उपयोग करके आकृतियों के समूह बनाना, उनका अभिगमन, समूह‑रहित करना और हटाना के उदाहरण।

## **समूह आकृति जोड़ें**

दो बुनियादी आकृतियों को शामिल करने वाला समूह बनाएं।

```php
function addGroupShape() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $group = $slide->getShapes()->addGroupShape();
        $group->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $group->getShapes()->addAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

        $presentation->save("group_shape.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **समूह आकृति तक पहुँचें**

स्लाइड से पहली समूह आकृति प्राप्त करें।

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड पर पहली समूह आकृति तक पहुँचें।
        $firstGroup = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $firstGroup = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **समूह आकृति हटाएँ**

स्लाइड से एक समूह आकृति हटाएं।

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // मान लेते हैं कि स्लाइड पर पहला आकार एक समूह आकृति है।
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **आकृतियों को समूह‑रहित करें**

आकृतियों को समूह कंटेनर से बाहर ले जाएँ।

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि स्लाइड पर पहला आकार एक समूह आकृति है।
        $group = $slide->getShapes()->get_Item(0);

        // समूह से प्रत्येक आकार को क्लोन करें और उसे स्लाइड में जोड़ें।
        $shapeCount = java_values($group->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $group->getShapes()->get_Item($index);
            $slide->getShapes()->addClone($shape);
        }

        $slide->getShapes()->remove($group);

        $presentation->save("ungrouped_shapes.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```