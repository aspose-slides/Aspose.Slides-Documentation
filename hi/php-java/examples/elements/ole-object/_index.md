---
title: OleObject
type: docs
weight: 210
url: /hi/php-java/examples/elements/ole-object/
keywords:
- OLE ऑब्जेक्ट
- OLE ऑब्जेक्ट जोड़ें
- OLE ऑब्जेक्ट तक पहुँचें
- OLE ऑब्जेक्ट हटाएँ
- OLE ऑब्जेक्ट अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में Aspose.Slides का उपयोग करके OLE ऑब्जेक्ट्स के साथ कार्य करें: अंतर्निहित फ़ाइलें डालें या अपडेट करें, आइकन या लिंक सेट करें, सामग्री निकालें, PPT, PPTX और ODP के लिये व्यवहार नियंत्रित करें।"
---
एक फ़ाइल को OLE ऑब्जेक्ट के रूप में एम्बेड करने और उसके डेटा को **Aspose.Slides for PHP via Java** का उपयोग करके अपडेट करने का प्रदर्शन करता है।

## **OLE ऑब्जेक्ट जोड़ें**

एक PDF फ़ाइल को प्रस्तुति में एम्बेड करें।

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE ऑब्जेक्ट तक पहुँचें**

स्लाइड पर पहला OLE ऑब्जेक्ट फ्रेम प्राप्त करें।

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड पर पहला OLE फ्रेम एक्सेस करें।
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE ऑब्जेक्ट हटाएँ**

स्लाइड से एम्बेड किए गए OLE ऑब्जेक्ट को हटाएँ।

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लीजिए स्लाइड पर पहला आकार OLE फ्रेम है।
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE ऑब्जेक्ट डेटा अपडेट करें**

मौजूदा OLE ऑब्जेक्ट में एम्बेड किए गए डेटा को बदलें।

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि स्लाइड पर पहला आकार OLE फ्रेम है।
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```