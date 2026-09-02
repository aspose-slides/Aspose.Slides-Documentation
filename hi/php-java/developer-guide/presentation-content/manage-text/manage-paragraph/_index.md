---
title: PHP में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
  - पाठ जोड़ें
  - पैराग्राफ जोड़ें
  - पाठ प्रबंधित करें
  - पैराग्राफ प्रबंधित करें
  - बुलेट प्रबंधित करें
  - पैराग्राफ इंडेंट
  - हैंगिंग इंडेंट
  - पैराग्राफ बुलेट
  - नंबरित सूची
  - बुलेटेड सूची
  - पैराग्राफ गुण
  - HTML आयात
  - पाठ से HTML
  - पैराग्राफ से HTML
  - पैराग्राफ से इमेज
  - पाठ से इमेज
  - पैराग्राफ निर्यात
  - PowerPoint
  - प्रेजेंटेशन
  - PHP
  - Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ पैराग्राफ, पोर्शन, बुलेट, नंबरित सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज कैसे बनाएं और फ़ॉर्मेट करें, जानें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम के रूप में दर्शाता है:

* [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) एक आकार में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) एक टेक्स्ट फ्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके पोर्शन तथा पैराग्राफ‑स्तरीय फॉर्मेटिंग तक पहुँच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) एक पैराग्राफ के भीतर टेक्स्ट रन को दर्शाता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर‑स्तरीय फॉर्मेटिंग हो सकता है।

एक पैराग्राफ इस प्रकार कई पोर्शन का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फॉर्मेटिंग वाले टेक्स्ट को समाहित कर सकता है।

## **पैराग्राफ बनाएं और फ़ॉर्मेट करें**

### **कई पोर्शन के साथ पैराग्राफ बनाएं**

निम्न चरण एक टेक्स्ट फ्रेम बनाते हैं जिसमें तीन पैराग्राफ होते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो अतिरिक्त [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन रखने के लिये पर्याप्त [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से एक खाली पोर्शन मौजूद है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [Portion::getPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getPortionFormat--) के माध्यम से कैरेक्टर‑स्तरीय फॉर्मेटिंग लागू करें।
9. संशोधित प्रेजेंटेशन को सहेजें।

यह PHP उदाहरण उपरोक्त चरणों को लागू करता है:

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

## **बुलेटेड और नंबरेड सूची बनाएं**

### **बुलेटेड या नंबरेड सूची बनाएं**

बुलेट्स और नंबरिंग संबंधित आइटम्स को स्कैन करना आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स को [BulletFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/) द्वारा परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. एक प्रतीक बुलेट के लिये एक [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) बनाएं।
7. [BulletFormat::setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType::Symbol](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/) पर सेट करें और बुलेट अक्षर निर्दिष्ट करें।
8. पैराग्राफ का टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाकर [BulletFormat::setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType::Numbered](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/) पर सेट करें।
11. नंबर्ड बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रेजेंटेशन को सहेजें।

यह PHP उदाहरण एक प्रतीक बुलेट और एक नंबर्ड बुलेट बनाता है:

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

चित्र बुलेट्स आपको प्रतीक या संख्या की बजाय कस्टम इमेज उपयोग करने की अनुमति देते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें और उसके [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. बुलेट इमेज को लोड करें और इसे प्रेजेंटेशन की इमेज कलेक्शन में एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) बनाएं और उसका टेक्स्ट सेट करें।
7. [BulletFormat::setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType::Picture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/) पर सेट करें।
8. [BulletFormat::getPicture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#getPicture--) के माध्यम से इमेज असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रेजेंटेशन को सहेजें।

यह PHP उदाहरण चित्र बुलेट बनाता है:

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

### **बहु‑स्तरीय सूची बनाएं**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setDepth-short-) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रख सकते हैं। शीर्ष स्तर की डेप्थ `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) बनाएं और किसी स्लाइड तक पहुँचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
3. चार पैराग्राफ बनाएं और उनके बुलेट प्रतीकों को कॉन्फ़िगर करें।
4. उनके [ParagraphFormat::setDepth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setDepth-short-) मान क्रमशः `0`, `1`, `2` और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेजेंटेशन को सहेजें।

यह PHP उदाहरण चार‑स्तरीय बुलेटेड सूची बनाता है:

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

### **कस्टम प्रारम्भिक मानों के साथ नंबर्ड सूची आइटम्स शुरू करें**

[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) का उपयोग करके नंबर्ड पैराग्राफ के लिये प्रारम्भिक संख्या निर्धारित कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) बनाएं और एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) को स्लाइड में जोड़ें।
2. आकार के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
3. तीन नंबर्ड पैराग्राफ बनाएं।
4. संबंधित पैराग्राफ के लिये [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) को क्रमशः `2`, `3` और `7` पर सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेजेंटेशन को सहेजें।

यह PHP उदाहरण प्रत्येक पैराग्राफ को कस्टम प्रारम्भिक नंबर असाइन करता है:

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

## **पैराग्राफ लेआउट और एंड प्रॉपर्टीज़ को नियंत्रित करें**

### **पहली पंक्ति का इंडेंट सेट करें**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) का उपयोग करके पैराग्राफ की पहली पंक्ति का इंडेंट नियंत्रित किया जाता है। यह विधि केवल पैराग्राफ के बाएँ मार्जिन के सापेक्ष पहली पंक्ति को शिफ्ट करती है। सकारात्मक मान पहली पंक्ति को दाईं ओर ले जाता है, जबकि बाकी पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

जब आपको पूरी पैराग्राफ को स्थानांतरित करना हो, तो [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) इस्तेमाल करें। केवल पहली पंक्ति को शिफ्ट करने हेतु [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) उपयोग करें।

निम्न उदाहरण कई पैराग्राफ बनाता है और विभिन्न [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) मान लागू करता है ताकि दिखा सके कि पहली पंक्ति का इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग की इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. कई पैराग्राफ बनाएं और उनके लिये विभिन्न [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन को सहेजें।

यह PHP कोड दर्शाता है कि पैराग्राफ इंडेंट कैसे सेट करें:

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

परिणाम:

![परिच्छेदों की पहली पंक्ति का इंडेंट](first_line_indent.png)

### **हैङ्गिंग इंडेंट सेट करें**

हैङ्गिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों से बाईं ओर शुरू होती है। Aspose.Slides में, आप इसे [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) के साथ नकारात्मक मान देकर प्राप्त कर सकते हैं।

व्यावहारिक रूप से, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, जबकि [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) पहली पंक्ति की स्थिति को उस मार्जिन के सापेक्ष निर्धारित करता है। हैङ्गिंग इंडेंट बनाने के लिये, `setMarginLeft` को सकारात्मक मान और `setIndent` को नकारात्मक मान दें।

यह फ़ॉर्मेटिंग बिब्लियोग्राफी, रेफ़रेंसेज़, शब्दकोश एंट्रीज़ आदि में उपयोगी होती है जहाँ रैप की गई पंक्तियों को पैराग्राफ बॉडी के नीचे संरेखित करना आवश्यक होता है, न कि पहली पंक्ति के पहले अक्षर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग की इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. प्रत्येक पैराग्राफ के लिये [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) को सकारात्मक मान सेट करके पैराग्राफ बनाएं।
6. हैङ्गिंग इंडेंट प्रभाव के लिये [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) को नकारात्मक मान दें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन को सहेजें।

यह PHP कोड दर्शाता है कि पैराग्राफ के लिये हैङ्गिंग इंडेंट कैसे सेट करें:

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

परिणाम:

![परिच्छेदों का हैङ्गिंग इंडेंट](hanging_indent.png)

### **एंड पैराग्राफ रन प्रॉपर्टीज़ सेट करें**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) पैराग्राफ के अंत चिह्न का फॉर्मेट नियंत्रित करता है। नीचे दिया PHP उदाहरण दूसरा पैराग्राफ के अंत चिह्न को फॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) लोड करें और किसी स्लाइड तक पहुँचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत चिह्न के लिये एक [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) बनाएं।
5. [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) और [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) सेट करें।
6. फॉर्मेट को [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) के साथ असाइन करें और प्रेजेंटेशन को सहेजें।

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

## **पैराग्राफ कंटेंट की आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में परिवर्तित किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग की इंस्टेंस बनाएं।
2. एक स्लाइड तक पहुँचें और एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
3. आकार के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) को पास करें।
6. संशोधित प्रेजेंटेशन को सहेजें।

यह PHP उदाहरण HTML को टेक्स्ट फ्रेम में आयात करता है:

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

[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) की इंस्टेंस बनाकर इच्छित प्रेजेंटेशन लोड करें।
2. स्लाइड तक पहुँचें और उस [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) को खोजें जिसमें टेक्स्ट है।
3. आकार के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
4. प्रारम्भ पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफ की संख्या के साथ [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) को कॉल करें।
5. प्राप्त HTML स्ट्रिंग को फ़ाइल में लिखें।

यह PHP उदाहरण पहली टेक्स्ट शेप से सभी पैराग्राफ निर्यात करता है:

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

[Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage--) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) लौटाता है। इस परिणाम को फ़ाइल या स्ट्रीम में [IImage::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/#save-java.lang.String-int-) से सहेजें। आपको संपूर्ण शेप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ पैरेंट कलेक्शन में नहीं मिला, वैध रेंडरिंग बॉउंड्स नहीं हैं, या रेंडर नहीं हो सकता तो [Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage--) `null` लौटा सकता है। सहेजने से पहले परिणाम चेक करें और उपयोग के बाद इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

मान लीजिए हमारे पास `sample.pptx` नामक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, तथा पहला शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न PHP उदाहरण डिफ़ॉल्ट स्केल पर दूसरे पैराग्राफ को रेंडर करता है और PNG फ़ॉर्मेट में इमेज सहेजता है। `finally` ब्लॉक इमेज को सही तरीके से डिस्पोज़ करता है।

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

परिणाम:

![पैराग्राफ इमेज](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करें**

[Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage-float-float-) ओवरलोड का उपयोग करके `$scaleX` और `$scaleY` पैरामीटर के साथ क्षैतिज और लंबवत स्केल फ़ैक्टर सेट किए जा सकते हैं। नीचे दिया PHP उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, तथा परिणाम को PNG इमेज के रूप में सहेजता है।

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

स्केल फ़ैक्टर `1` अक्ष को उसकी डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिये, दोनों फ़ैक्टर को `2` करने पर इमेज की चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट आकार के दो गुना हो जाती है, जिससे कुल पिक्सेल चार गुना हो जाते हैं। बड़े फ़ैक्टर ज़ूम या हाई‑रेज़ॉल्यूशन आउटपुट के लिये तेज़ टेक्स्ट देते हैं, पर मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फ़ैक्टर छोटी इमेज कम विवरण के साथ बनाते हैं। समान फ़ैक्टर रखकर पैराग्राफ का aspect ratio संरक्षित किया जा सकता है; अलग‑अलग क्षैतिज‑लंबवत फ़ैक्टर आउटपुट को स्वतंत्र रूप से स्ट्रेच करते हैं।

पूरे शेप को [Shape::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage--) से रेंडर करना तब उपयोगी होता है जब आउटपुट में शेप का भराव, बॉर्डर या अन्य दृश्य संदर्भ भी शामिल होना चाहिए। केवल पैराग्राफ‑इमेज के लिये [Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage--) का उपयोग करें।

## **FAQ**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह बंद कर सकता हूँ?**

हाँ। लाइन रैपिंग को बंद करने के लिये [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setWrapText-byte-) को सेट करें।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक बॉउंडरी कैसे प्राप्त करूँ?**

[Paragraph::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getRect--) का उपयोग करके पैराग्राफ की बाउंडिंग रेक्टेंगल प्राप्त करें। व्यक्तिगत पोर्शन की बॉउंडरी के लिये [Portion::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getRect--) उपयोग किया जाता है।

**पैराग्राफ एलाइमेंट (बाएँ, दाएँ, केंद्र या जस्टिफाई) कहाँ नियंत्रित होता है?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setAlignment-int-) एक पैराग्राफ‑स्तर की सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेट कुछ भी हो।

**क्या मैं पैराग्राफ के कुछ भाग के लिये प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिये [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) सेट करें, जिससे एक पैराग्राफ में कई भाषाओं का टेक्स्ट हो सकता है।