---
title: PHP में प्रस्तुतियों से पैराग्राफ सीमाएँ प्राप्त करें
linktitle: पैराग्राफ सीमाएँ
type: docs
weight: 43
url: /hi/php-java/paragraph-bounds/
keywords:
- पैराग्राफ सीमाएँ
- पैराग्राफ निर्देशांक
- पैराग्राफ आकार
- टेक्स्ट फ़्रेम
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में पैराग्राफ सीमाओं को प्राप्त करके PowerPoint प्रस्तुतियों में टेक्स्ट पोजिशनिंग को अनुकूलित करना सीखें।"
---
## **परिचय**

यह लेख Aspose.Slides में परिच्छेदों की सीमाएँ, आकार और निर्देशांक प्राप्त करने के तरीकों को समझाता है। यह दिखाता है कि कैसे [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) से [Paragraph::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/getrect/) का उपयोग करके एक परिच्छेद आयत प्राप्त किया जा सकता है, टेबल सेल टेक्स्ट फ़्रेम के भीतर परिच्छेद के निर्देशांक कैसे प्राप्त करें, और माप इकाइयाँ, टेक्स्ट रैपिंग का सीमाओं पर प्रभाव, पिक्सेल रूपांतरण, तथा प्रभावी परिच्छेद फ़ॉर्मेटिंग मान जैसे महत्वपूर्ण विवरणों को उजागर करता है।

## **परिच्छेद के आयताकार निर्देशांक प्राप्त करें**

[Paragraph::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/getrect/) का उपयोग करके परिच्छेद का बाउंडिंग आयत प्राप्त करें।

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **टेबल सेल TextFrame के भीतर परिच्छेद का आकार प्राप्त करें**

टेबल सेल टेक्स्ट फ़्रेम में एक [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) का आकार और निर्देशांक प्राप्त करने के लिए [Paragraph::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/getrect/) का उपयोग करें। लौटाया गया आयत टेबल सेल टेक्स्ट फ़्रेम के सापेक्ष होता है, इसलिए स्लाइड-स्तर के निर्देशांक चाहिए होते हैं तो तालिका की स्थिति और सेल ऑफ़सेट जोड़ें।

निम्न उदाहरण टेबल सेल के भीतर परिच्छेद की सीमाओं को प्राप्त करता है और स्लाइड पर उन सीमाओं को दर्शाने के लिए आयतें बनाता है:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**परिच्छेद निर्देशांक किस इकाई में मापे जाते हैं?**

उनकी माप पॉइंट्स में की जाती है, जहाँ 1 इंच = 72 पॉइंट्स। यह स्लाइड पर सभी निर्देशांक और आयामों पर लागू होता है।

**क्या शब्द रैपिंग से परिच्छेद की सीमाएँ प्रभावित होती हैं?**

हां। यदि [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/setwraptext/) को [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) के लिए सक्रिय किया गया है, तो टेक्स्ट क्षेत्र की चौड़ाई के अनुसार टूट जाता है, जिससे परिच्छेद की वास्तविक सीमाएँ बदल जाती हैं।

**क्या प्रकाशित छवि में परिच्छेद निर्देशांक को विश्वसनीय रूप से पिक्सेल में मैप किया जा सकता है?**

हां। इस सूत्र का उपयोग करके पॉइंट्स को पिक्सेल में बदलें: पिक्सेल = पॉइंट्स × (DPI / 72)। परिणाम रेंडरिंग या निर्यात के लिए चुने गए DPI पर निर्भर करता है।

**स्टाइल विरासत को ध्यान में रखते हुए "प्रभावी" परिच्छेद फ़ॉर्मेटिंग पैरामीटर कैसे प्राप्त करें?**

[effective paragraph formatting data structure](/slides/hi/php-java/shape-effective-properties/) का उपयोग करें; यह इंडेंट, स्पेसिंग, रैपिंग, RTL और अन्य के लिए अंतिम एकीकृत मान लौटाता है।