---
title: PHP में प्रस्तुतियों से पैराग्राफ बाउंड्स प्राप्त करें
linktitle: पैराग्राफ
type: docs
weight: 60
url: /hi/php-java/paragraph/
keywords:
- पैराग्राफ बाउंड्स
- टेक्स्ट पोर्शन बाउंड्स
- पैराग्राफ निर्देशांक
- पोर्शन निर्देशांक
- पैराग्राफ आकार
- टेक्स्ट पोर्शन आकार
- टेक्स्ट फ्रेम
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में पैराग्राफ और टेक्स्ट-पोर्शन बाउंड्स प्राप्त करने का तरीका सीखें ताकि PowerPoint प्रस्तुतियों में टेक्स्ट की स्थिति को अनुकूलित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पैराग्राफ़ और टेक्स्ट पोर्शन के बाउंड्स, आकार, और निर्देशांक प्राप्त करने के तरीकों को समझाता है। यह `getRect()` का उपयोग करके `TextFrame` में पैराग्राफ़ का आयत प्राप्त करने, टेबल सेल टेक्स्ट फ़्रेम के भीतर पैराग्राफ़ और पोर्शन के निर्देशांक प्राप्त करने, और मापन इकाइयाँ, टेक्स्ट रैपिंग का बाउंड्स पर प्रभाव, पिक्सेल रूपांतरण, तथा प्रभावी पैराग्राफ़ फ़ॉर्मेटिंग मान जैसी महत्वपूर्ण विवरणों को उजागर करता है।

## **TextFrame में पैराग्राफ़ और पोर्शन के निर्देशांक प्राप्त करें**
Aspose.Slides for PHP via Java का उपयोग करके, डेवलपर्स अब TextFrame के पैराग्राफ़ कलेक्शन के भीतर पैराग्राफ़ के आयताकार निर्देशांक प्राप्त कर सकते हैं। यह आपको पैराग्राफ़ के पोर्शन कलेक्शन के भीतर [पोर्टियन के निर्देशांक](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getCoordinates) प्राप्त करने की भी अनुमति देता है। इस विषय में, हम एक उदाहरण की मदद से दिखाएंगे कि कैसे पैराग्राफ़ के आयताकार निर्देशांक और उसके भीतर पोर्शन की स्थिति प्राप्त की जा सकती है।

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **पैराग्राफ़ के आयताकार निर्देशांक प्राप्त करें**
[**getRect()**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getRect) मेथड का उपयोग करके डेवलपर्स पैराग्राफ़ के बाउंड्स आयत प्राप्त कर सकते हैं।

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टेबल सेल TextFrame के भीतर पैराग्राफ़ और पोर्शन का आकार प्राप्त करें**
टेबल सेल टेक्स्ट फ्रेम में [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Portion) या [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Paragraph) का आकार और निर्देशांक प्राप्त करने के लिए, आप [Portion::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getRect) और [Paragraph::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getRect) मेथड का उपयोग कर सकते हैं।

यह नमूना कोड वर्णित कार्य को दर्शाता है:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**पैराग्राफ़ और टेक्स्ट पोर्शन के लिए लौटाए गए निर्देशांक किस इकाइयों में मापे जाते हैं?**  
पॉइंट्स में, जहाँ 1 इंच = 72 पॉइंट्स। यह स्लाइड पर सभी निर्देशांक और आयामों पर लागू होता है।

**क्या शब्द रैपिंग पैराग्राफ़ के बाउंड्स को प्रभावित करती है?**  
हाँ। यदि [wrapping](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/setwraptext/) को [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) में सक्षम किया गया है, तो टेक्स्ट क्षेत्र की चौड़ाई के अनुसार टूटता है, जिससे पैराग्राफ़ के वास्तविक बाउंड्स बदल जाते हैं।

**क्या पैराग्राफ़ के निर्देशांक को निर्यातित छवि में पिक्सेल में विश्वसनीय रूप से मैप किया जा सकता है?**  
हाँ। पॉइंट्स को पिक्सेल में इस प्रकार रूपांतरित करें: pixels = points × (DPI / 72)। परिणाम रेंडरिंग/निर्यात के लिए चुने गए DPI पर निर्भर करता है।

**"effective" पैराग्राफ़ फ़ॉर्मेटिंग पैरामीटर, शैली उत्तराधिकार को ध्यान में रखते हुए, कैसे प्राप्त करें?**  
इसके लिए [effective paragraph formatting data structure](/slides/hi/php-java/shape-effective-properties/) का उपयोग करें; यह इंडेंट, स्पेसिंग, रैपिंग, RTL, आदि के लिए अंतिम सम्मिलित मान लौटाता है।