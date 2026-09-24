---
title: "PHP में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें"
linktitle: "पैराग्राफ प्रबंधित करें"
type: docs
weight: 40
url: /hi/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
  - "टेक्स्ट जोड़ें"
  - "पैराग्राफ जोड़ें"
  - "टेक्स्ट प्रबंधित करें"
  - "पैराग्राफ प्रबंधित करें"
  - "बुलेट प्रबंधित करें"
  - "पैराग्राफ इंडेंट"
  - "हैंगिंग इंडेंट"
  - "पैराग्राफ बुलेट"
  - "नंबर्ड सूची"
  - "बुलेटेड सूची"
  - "पैराग्राफ प्रॉपर्टीज़"
  - "HTML आयात करें"
  - "टेक्स्ट को HTML में"
  - "पैराग्राफ को HTML में"
  - "पैराग्राफ को इमेज में"
  - "टेक्स्ट को इमेज में"
  - "पैराग्राफ निर्यात करें"
  - "PowerPoint"
  - "प्रेज़ेंटेशन"
  - "PHP"
  - "Aspose.Slides"
description: "Aspose.Slides for PHP via Java का उपयोग करके पैराग्राफ, पोर्शन, बुलेट, नंबर्ड सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज बनाना और फ़ॉर्मेट करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम के रूप में प्रस्तुत करता है:

* [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) टेक्स्ट कोष्ठक (shape) में टेक्स्ट कंटेनर का प्रतिनिधित्व करता है और इसके पैराग्राफ संग्रह तक पहुंच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) टेक्स्ट फ्रेम में एक पैराग्राफ को दर्शाता है और इसके पोर्शन और पैराग्राफ-लेवल फ़ॉर्मेटिंग तक पहुंच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) पैराग्राफ के भीतर एक टेक्स्ट रन को दर्शाता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर-लेवल फ़ॉर्मेटिंग हो सकता है।

इसलिए एक पैराग्राफ कई पोर्शन का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाला टेक्स्ट रख सकता है।

## **पैराग्राफ बनाएं और फ़ॉर्मेट करें**

### **एकाधिक पोर्शन के साथ पैराग्राफ बनाएं**

निम्नलिखित कदम एक टेक्स्ट फ्रेम बनाते हैं जिसमें तीन पैराग्राफ होते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुंचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो और [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन रखने के लिए पर्याप्त [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन होता है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [Portion::getPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getPortionFormat--) के माध्यम से कैरेक्टर-लेवल फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रेज़ेंटेशन को सहेजें।

This PHP example implements the steps:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **बुलेटेड और नंबरड सूचियाँ बनाएं**

### **बुलेटेड या नंबरड सूची बनाएं**

बुलेट और नंबरिंग संबंधित आइटम्स को स्कैन करना आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स को [BulletFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/) के माध्यम से परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुंचें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुंचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएं।
6. एक प्रतीक बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) बनाएं।
7. [BulletFormat::setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType::Symbol](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ का टेक्स्ट, इंडेंट, बुलेट का रंग और बुलेट की ऊंचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. एक दूसरा पैराग्राफ बनाएं और [BulletFormat::setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType::Numbered](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/) पर सेट करें।
11. नंबरड बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रेज़ेंटेशन को सहेजें।

This PHP example creates a symbol bullet and a numbered bullet:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **चित्र बुलेट्स का उपयोग करें**

चित्र बुलेट्स आपको प्रतीक या नंबर की बजाय एक कस्टम इमेज उपयोग करने की सुविधा देते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुंचें।
3. एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें और उसके [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुंचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएं।
5. बुलेट इमेज लोड करें और इसे प्रेज़ेंटेशन की इमेज कलेक्शन में एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) बनाएं और उसका टेक्स्ट सेट करें।
7. [BulletFormat::setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType::Picture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/) पर सेट करें।
8. [BulletFormat::getPicture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#getPicture--) के माध्यम से इमेज निर्दिष्ट करें और बुलेट की ऊंचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रेज़ेंटेशन को सहेजें।

This PHP example creates a picture bullet:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **बहु-स्तरीय सूची बनाएं**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setDepth-short-) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जा सकता है। शीर्ष स्तर की गहराई `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) बनाएं और एक स्लाइड तक पहुंचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. चार पैराग्राफ बनाएं और उनके बुलेट प्रतीकों को कॉन्फ़िगर करें।
4. उनके [ParagraphFormat::setDepth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setDepth-short-) मानों को क्रमशः `0`, `1`, `2` और `3` पर सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेज़ेंटेशन को सहेजें।

This PHP example creates a four-level bulleted list:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **कस्टम मानों से नंबरड सूची आइटम शुरू करें**

[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) का उपयोग करके नंबरड पैराग्राफ के शुरुआती संख्या को निर्धारित किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) बनाएं और एक स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
2. शेप के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. तीन नंबरड पैराग्राफ बनाएं।
4. संबंधित पैराग्राफ के लिए [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) को क्रमशः `2`, `3` और `7` पर सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेज़ेंटेशन को सहेजें।

This PHP example assigns a custom starting number to each paragraph:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **पैराग्राफ लेआउट और अंत गुण नियंत्रित करें**

### **पहली पंक्ति का इंडेंट सेट करें**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) का उपयोग करके पैराग्राफ की पहली पंक्ति का इंडेंट नियंत्रित किया जाता है। यह विधि केवल पहले लाइन को पैराग्राफ की बाएँ मार्जिन के सापेक्ष ले जाती है। सकारात्मक मान पहली पंक्ति को दाईं ओर शिफ्ट करता है, जबकि शेष पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को ले जाने के लिए [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) का उपयोग करें। केवल पहली पंक्ति को ले जाने के लिए [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) का उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) मान लागू करता है ताकि दिखाया जा सके कि पहली पंक्ति का इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. टार्गेट स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ को हटाएं।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेज़ेंटेशन को सहेजें।

This PHP code shows you how to set a paragraph indent:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![पैराग्राफ की पहली पंक्तियों का इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों से बाईं ओर शुरू होती है। Aspose.Slides में, यह प्रभाव [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) के साथ बनाया जाता है। पैराग्राफ बॉडी के सापेक्ष पहली पंक्ति को बाएँ ले जाने के लिए नकारात्मक मान पास करें।

व्यावहारिक रूप से, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बाएँ स्थिति को परिभाषित करता है, और [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) पहली पंक्ति की स्थिति को उस मार्जिन के सापेक्ष परिभाषित करता है। हैंगिंग इंडेंट बनाने के लिए `setMarginLeft` को सकारात्मक मान और `setIndent` को नकारात्मक मान पास करें।

यह फ़ॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ों के लिए उपयोगी है जहाँ रैप्ड लाइनें पैराग्राफ बॉडी के नीचे संरेखित होनी चाहिए न कि पहली पंक्ति के पहले अक्षर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. टार्गेट स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ को हटाएं।
5. प्रत्येक पैराग्राफ के लिए [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) को सकारात्मक मान पास करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) को नकारात्मक मान पास करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेज़ेंटेशन को सहेजें।

This PHP code shows you how to set a hanging indent for a paragraph:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![पैराग्राफ का हैंगिंग इंडेंट](hanging_indent.png)

### **एंड पैराग्राफ रन प्रॉपर्टीज़ सेट करें**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) पैराग्राफ एंड मार्क की फ़ॉर्मेटिंग को नियंत्रित करता है। निम्नलिखित PHP उदाहरण दूसरे पैराग्राफ के एंड मार्क को फ़ॉन्ट साइज़ और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) लोड करें और एक स्लाइड तक पहुंचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें और उसके डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के एंड मार्क के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) बनाएं।
5. [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) और [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) सेट करें।
6. [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) के साथ फ़ॉर्मेट लागू करें और प्रेज़ेंटेशन को सहेजें।

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **रेंडर की गई पंक्तियों की गिनती**

[Paragraph::getLinesCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getLinesCount--) का उपयोग करके टेक्स्ट लेआउट के बाद एक पैराग्राफ द्वारा घिरे पंक्तियों की संख्या गिनी जा सकती है, जिसमें ऑटोमैटिक रैपिंग भी शामिल है। यह प्रेज़ेंटेशन टेम्पलेट्स में टेक्स्ट लंबाई और लेआउट की जांच करते समय उपयोगी है।

एक पैराग्राफ [TextFrame::getParagraphs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParagraphs--) में एक आइटम होता है, और वह कई रेंडर की गई पंक्तियों को घेर सकता है। पैराग्राफ के भीतर एक स्पष्ट लाइन ब्रेक नई लाइन बनाता है बिना नया पैराग्राफ बनाए। ऑटोमैटिक रैपिंग उपलब्ध चौड़ाई के आधार पर पंक्तियों को बनाता है, बिना टेक्स्ट में स्पष्ट लाइन ब्रेक डाले। इसलिए पैराग्राफ या लाइन-ब्रेक कैरेक्टर्स की गिनती रेंडर की गई पंक्तियों की संख्या नहीं देती।

निम्न उदाहरण एक टेक्स्ट शेप बनाता है, उसकी पंक्तियों की गिनती करता है, शेप को संकरी करता है, और फिर टेक्स्ट को एक छोटे स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटोफ़िट बंद है ताकि शेप की चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वचालित रूप से छोटा या शेप का आकार बदले। शेप के आयाम पॉइंट्स में हैं। अंत में, उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में पंक्तियों की गिनती को जोड़ता है।

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

इन टेक्स्ट और आयामों के साथ, शेप को संकरी करने से पंक्तियों की संख्या बढ़ती है, जबकि छोटे स्ट्रिंग से बदलने से घटती है। सटीक गिनती फ़ॉन्ट उपलब्धता, प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंटेशन, रैपिंग और ऑटोफ़िट सेटिंग्स के आधार पर बदल सकती है। टेम्पलेट की जांच करते समय लक्षित वातावरण के लिए इरादे वाले फ़ॉन्ट और लेआउट सेटिंग्स उपयोग करें।

पंक्तियों की गिनती अकेले यह निर्धारित नहीं करती कि टेक्स्ट अपने कंटेनर से बाहर निकलता है या नहीं। उपलब्ध ऊँचाई, लाइन हाईट, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटोफ़िट व्यवहार भी मायने रखते हैं; यहां तक कि एक ही लाइन भी उपलब्ध चौड़ाई को पार कर सकती है जब रैपिंग बंद हो।

## **पैराग्राफ सामग्री आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में बदलें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. एक स्लाइड तक पहुंचें और एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
3. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) को पास करें।
6. संशोधित प्रेज़ेंटेशन को सहेजें।

This PHP example imports HTML into a text frame:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं और इच्छित प्रेज़ेंटेशन लोड करें।
2. स्लाइड तक पहुंचें और वह [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) खोजें जिसमें टेक्स्ट है।
3. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुंचें।
4. प्रारंभिक पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) को कॉल करें।
5. लौटाए गए HTML स्ट्रिंग को फ़ाइल में लिखें।

This PHP example exports all paragraphs from the first text shape:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **पैराग्राफ को इमेज के रूप में रेंडर करें**

[Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage--) एकल पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) लौटाता है। परिणाम को [IImage::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/#save-java.lang.String-int-) के साथ फ़ाइल या स्ट्रीम में सहेजें। आपको कंटेनिंग शेप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ को उसके पैरेंट कलेक्शन में नहीं पाया गया, वैध रेंडरिंग बाउंड्स नहीं हैं, या रेंडर नहीं किया जा सकता है, तो [Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage--) `null` लौटा सकता है। सहेजने से पहले परिणाम जाँचें और उपयोग के बाद लौटाई गई इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

मान लीजिए हमारे पास `sample.pptx` नामक एक प्रेज़ेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप तीन पैराग्राफ वाली एक टेक्स्ट बॉक्स है।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न PHP उदाहरण एक नियमित टेक्स्ट शेप में दोवें पैराग्राफ को डिफ़ॉल्ट स्केल पर रेंडर करता है और परिणामस्वरूप PNG इमेज को सहेजता है। `finally` ब्लॉक सुनिश्चित करता है कि इमेज सही ढंग से डिस्पोज़ हो।

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

The result:

![पैराग्राफ इमेज](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करें**

[Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage-float-float-) ओवरलोड को `$scaleX` और `$scaleY` पैरामीटर पास करके क्षैतिज और ऊर्ध्वाधर स्केल फैक्टर सेट किए जा सकते हैं। नीचे दिया गया PHP उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

`1` का स्केल फैक्टर उस अक्ष को उसका डिफ़ॉल्ट पिक्सेल आकार रखता है। उदाहरण के लिए, दोनों फैक्टर्स के लिए `2` सेट करने से इमेज की चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे चार गुना पिक्सेल मिलते हैं। बड़े फैक्टर्स आमतौर पर ज़ूम या हाई-रेज़ोल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फैक्टर्स छोटे इमेज बनाते हैं जिसमें कम विवरण होता है। समान फैक्टर्स रखें ताकि पैराग्राफ का आस्पेक्ट रेशियो बना रहे; अलग-अलग क्षैतिज और ऊर्ध्वाधर फैक्टर्स आउटपुट को स्वतंत्र रूप से खींचते हैं।

[Shape::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage--) के साथ पूरा शेप रेंडर करना उपयोगी रहता है जब आउटपुट में शेप की फ़िल, बॉर्डर या अन्य विज़ुअल कॉन्टेक्स्ट शामिल होना चाहिए। केवल पैराग्राफ-ओनली इमेज के लिए, [Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage--) का उपयोग करें।

## **FAQ**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह से निष्क्रिय कर सकता हूँ?**

हाँ। रैपिंग को निष्क्रिय करने के लिए [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setWrapText-byte-) को सेट करें ताकि पंक्तियाँ टेक्स्ट फ्रेम के किनारों पर नहीं टूटें।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक सीमाएँ कैसे प्राप्त कर सकता हूँ?**

[Paragraph::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getRect--) का उपयोग करके पैराग्राफ की बाउंडिंग आयत प्राप्त करें। व्यक्तिगत पोर्शन की सीमाओं के लिए [Portion::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getRect--) देखें।

**पैराग्राफ का एलाइनमेंट (बायाँ, दायाँ, केंद्र या जस्टिफ़ाइ) नियंत्रण कहाँ किया जाता है?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setAlignment-int-) एक पैराग्राफ‑लेवल सेटिंग है और यह पूरे पैराग्राफ पर लागू होता है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेटिंग कुछ भी हो।

**क्या मैं पैराग्राफ के हिस्से के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। आप प्रत्येक पोर्शन के लिए [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) सेट कर सकते हैं, ताकि एक ही पैराग्राफ में कई भाषाओं का टेक्स्ट हो सके।