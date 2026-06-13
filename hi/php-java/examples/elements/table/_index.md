---
title: तालिका
type: docs
weight: 120
url: /hi/php-java/examples/elements/table/
keywords:
- तालिका
- तालिका जोड़ें
- तालिका तक पहुँचें
- तालिका हटाएँ
- कक्ष मिलाएँ
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में Aspose.Slides के साथ तालिकाएँ बनाएँ और स्वरूपित करें: डेटा डालें, कक्ष मिलाएँ, बॉर्डर को स्टाइल करें, सामग्री संरेखित करें, और PPT, PPTX और ODP के लिए आयात/निर्यात करें।"
---
**Aspose.Slides for PHP via Java** का उपयोग करके तालिकाएँ जोड़ने, उन्हें पहुँचने, हटाने और कक्षों को मर्ज करने के उदाहरण।

## **तालिका जोड़ें**

दो पंक्तियों और दो स्तम्भों वाली एक साधारण तालिका बनाएं।

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **तालिका तक पहुँचें**

स्लाइड पर पहली तालिका आकार प्राप्त करें।

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड पर पहली तालिका तक पहुँचें।
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **तालिका हटाएँ**

स्लाइड से एक तालिका हटाएँ।

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि तालिका स्लाइड पर पहला आकार है।
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **तालिका कक्षों को मिलाएँ**

एक तालिका के आसन्न कक्षों को एकल कक्ष में मिलाएँ।

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लेते हैं कि तालिका स्लाइड पर पहला आकार है।
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```