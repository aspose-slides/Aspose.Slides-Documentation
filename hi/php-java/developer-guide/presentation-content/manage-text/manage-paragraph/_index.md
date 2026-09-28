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
- "क्रमांकित सूची"
- "बुलेटेड सूची"
- "पैराग्राफ गुण"
- "HTML आयात करें"
- "टेक्स्ट को HTML में"
- "पैराग्राफ को HTML में"
- "पैराग्राफ को इमेज में"
- "टेक्स्ट को इमेज में"
- "पैराग्राफ निर्यात करें"
- "PowerPoint"
- "प्रेजेंटेशन"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java के साथ पैराग्राफ, पोर्शन, बुलेट, क्रमांकित सूचियां, इंडेंट, HTML सामग्री और पैराग्राफ इमेज बनाना और फॉर्मेट करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम के रूप में प्रस्तुत करता है:

* [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) एक आकार में टेक्स्ट कंटेनर का प्रतिनिधित्व करता है और उसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) एक टेक्स्ट फ्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और उसके पोर्शन और पैराग्राफ-स्तरीय फॉर्मेटिंग तक पहुँच प्रदान करता है।
* [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) एक पैराग्राफ के भीतर टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन का अपना टेक्स्ट और अक्षर-स्तरीय फॉर्मेटिंग हो सकता है।

इसलिए एक पैराग्राफ कई पोर्शन का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फॉर्मेटिंग वाले टेक्स्ट को शामिल कर सकता है।

## **पैराग्राफ बनाना और फॉर्मेट करना**

### **एकाधिक पोर्शन के साथ पैराग्राफ बनाना**

निम्न चरण एक टेक्स्ट फ्रेम बनाते हैं जिसमें तीन पैराग्राफ होते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो और [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन रखने के लिए पर्याप्त [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन होता है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. अक्षर-स्तरीय फॉर्मेटिंग को [Portion::getPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getPortionFormat--) के माध्यम से लागू करें।
9. संशोधित प्रेजेंटेशन को सहेजें।

यह PHP उदाहरण इन चरणों को लागू करता है:

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

## **बुलेटेड और क्रमांकित सूचियों को बनाना**

### **बुलेटेड या क्रमांकित सूची बनाना**

बुलेट और क्रमांकन संबंधित आइटम को आसानी से स्कैन करने में मदद करता है। Aspose.Slides में, सूची सेटिंग्स को [BulletFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/) के माध्यम से परिभाषित किया जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. सिम्बॉल बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) बनाएँ।
7. [BulletFormat::setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType::Symbol](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ टेक्स्ट, इंडेंट, बुलेट रंग, और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाएँ और [BulletFormat::setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType::Numbered](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/) पर सेट करें।
11. क्रमांकित बुलेट शैली कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रेजेंटेशन को सहेजें।

यह PHP उदाहरण एक सिम्बॉल बुलेट और एक क्रमांकित बुलेट बनाता है:

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

### **पिक्चर बुलेट का उपयोग करना**

पिक्चर बुलेट आपको सिम्बॉल या नंबर के बजाय एक कस्टम इमेज का उपयोग करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
2. इंडेक्स के माध्यम से संबंधित स्लाइड तक पहुँचें।
3. एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें और इसके [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. बुलेट इमेज लोड करें और इसे प्रेजेंटेशन की इमेज कलेक्शन में एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) बनाएँ और उसका टेक्स्ट सेट करें।
7. [BulletFormat::setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType::Picture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/) पर सेट करें।
8. [BulletFormat::getPicture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#getPicture--) के माध्यम से इमेज असाइन करें और बुलेट की ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रेजेंटेशन को सहेजें।

यह PHP उदाहरण पिक्चर बुलेट बनाता है:

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

### **बहु-स्तरीय सूची बनाना**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setDepth-short-) सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखें। शीर्ष स्तर की गहराई `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) बनाकर एक स्लाइड तक पहुँचें।
2. [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. चार पैराग्राफ बनाएँ और उनके बुलेट प्रतीकों को कॉन्फ़िगर करें।
4. उनके [ParagraphFormat::setDepth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setDepth-short-) मानों को क्रमशः `0`, `1`, `2`, और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेजेंटेशन सहेजें।

यह PHP उदाहरण चार-स्तरीय बुलेटेड सूची बनाता है:

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

### **कस्टम मूल्यों से क्रमांकित सूची आइटम शुरू करना**

किसी क्रमांकित पैराग्राफ के लिए प्रारंभिक संख्या निर्धारित करने के लिए [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) का उपयोग करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) बनाकर एक स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
2. शेप के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. तीन क्रमांकित पैराग्राफ बनाएँ।
4. संबंधित पैराग्राफ़ के लिए [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) को क्रमशः `2`, `3`, और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेजेंटेशन सहेजें।

यह PHP उदाहरण प्रत्येक पैराग्राफ को कस्टम प्रारंभिक संख्या असाइन करता है:

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

## **पैराग्राफ लेआउट और अंत गुणों को नियंत्रित करना**

### **पहली पंक्ति की इंडेंट सेट करना**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) का उपयोग करके पैराग्राफ की पहली पंक्ति की इंडेंट नियंत्रित करें। यह मेथड केवल पहली पंक्ति को पैराग्राफ के बाएँ मार्जिन के सापेक्ष हटाता है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि शेष पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

जब आपको पूरे पैराग्राफ को स्थानांतरित करना हो तो [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) उपयोग करें। केवल पहली पंक्ति को स्थानांतरित करने के लिए [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) मान लागू करता है ताकि दिखाया जा सके कि पहली पंक्ति की इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
2. टार्गेट स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएँ और उनके लिए विभिन्न [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन को सहेजें।

यह PHP कोड दर्शाता है कि कैसे पैराग्राफ इंडेंट सेट किया जाता है:

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

![पैराग्राफ़ की पहली पंक्ति की इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करना**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों के बाएँ शुरू होती है। Aspose.Slides में, आप इसे [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) के साथ बना सकते हैं। पैराग्राफ बॉडी के सापेक्ष पहली पंक्ति को बाएँ ले जाने के लिए नकारात्मक मान पास करें।

व्यावहारिक रूप से, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, और [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, `setMarginLeft` को सकारात्मक मान और `setIndent` को नकारात्मक मान पास करें।

यह फॉर्मेटिंग ग्रंथसूची, रेफ़रेंसेज़, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ों के लिए उपयोगी है जहाँ लिपटे हुए लाइनों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली पंक्ति के पहले अक्षर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
2. टार्गेट स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. प्रत्येक पैराग्राफ के लिए [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) को सकारात्मक मान पास करके पैराग्राफ बनाएँ।
6. [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setIndent-float-) को नकारात्मक मान पास करके हैंगिंग इंडेंट प्रभाव बनाएँ।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन को सहेजें।

यह PHP कोड दर्शाता है कि पैराग्राफ के लिए हैंगिंग इंडेंट कैसे सेट किया जाता है:

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

![पैराग्राफ़ की हैंगिंग इंडेंट](hanging_indent.png)

### **अंत पैराग्राफ रन गुण सेट करना**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) पैराग्राफ के अंत चिह्न की फॉर्मेटिंग को नियंत्रित करता है। निम्न PHP उदाहरण दूसरे पैराग्राफ के अंत चिह्न को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) लोड करें और एक स्लाइड तक पहुँचें।
2. एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत चिह्न के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) बनाएँ।
5. [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) और [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) सेट करें।
6. [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) के साथ फॉर्मेट असाइन करें और प्रेजेंटेशन सहेजें।

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

## **रेंडर की गई लाइन्स की गिनती**

ऑटोमैटिक रैपिंग और लाइन अंत में विराम चिह्न को प्रभावित करने वाले पैराग्राफ नियमों के लिए, देखें [Control Line Breaking](/slides/hi/php-java/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/php-java/text-formatting/#control-hanging-punctuation)。

[Paragraph::getLinesCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getLinesCount--) का उपयोग करके टेक्स्ट लेआउट के बाद पैराग्राफ द्वारा घेर ली गई लाइनों की गिनती करें, जिसमें ऑटोमैटिक रैपिंग शामिल है। यह प्रेजेंटेशन टेम्पलेट में टेक्स्ट की लंबाई और लेआउट जांचते समय उपयोगी है।

[TextFrame::getParagraphs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParagraphs--) में एक पैराग्राफ एक आइटम है, और यह कई रेंडर की गई लाइनों को ले सकता है। पैराग्राफ के भीतर एक स्पष्ट लाइन ब्रेक नई लाइन बनाता है बिना दूसरे पैराग्राफ के बनाये। ऑटोमैटिक रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों को बनाता है और टेक्स्ट में स्पष्ट लाइन ब्रेक नहीं डालता। इसलिए पैराग्राफ या लाइन-ब्रेक कैरेक्टर गिनना रेंडर की गई लाइन संख्या नहीं देता।

निम्नलिखित उदाहरण एक टेक्स्ट शैप बनाता है, इसकी लाइनों की गिनती करता है, शैप को संकीर्ण करता है, और फिर टेक्स्ट को एक छोटे स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटोफ़िट अक्षम है ताकि शैप की चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वतः छोटा किए या शैप का आकार बदलें। शैप परिमाण पॉइंट में हैं। अंत में, उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में लाइनों की कुल गिनती करता है।

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

इस टेक्स्ट और इन परिमाणों के साथ, शैप को संकीर्ण करने से लाइन गिनती बढ़ती है, जबकि टेक्स्ट को छोटे स्ट्रिंग से बदलने से वह घटती है। सटीक गिनती फ़ॉन्ट की उपलब्धता और प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंटेशन, रैपिंग और ऑटोफ़िट सेटिंग्स पर निर्भर कर सकती है। टेम्पलेट जाँचते समय लक्षित वातावरण के लिए नियत फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन गिनती यह निर्धारित नहीं करती कि टेक्स्ट कंटेनर से अधिक है या नहीं। उपलब्ध ऊँचाई, लाइन ऊँचाई, पैराग्राफ और लाइन स्पेसिंग, और ऑटोफ़िट व्यवहार भी महत्वपूर्ण हैं; यहाँ तक कि एक ही लाइन भी रैपिंग अक्षम होने पर उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्रफ़ कंटेंट आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करना**

[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में परिवर्तित करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
2. एक स्लाइड तक पहुँचें और एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
3. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ साफ़ करें।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) में पास करें।
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

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करना**

[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) का उपयोग करके पैराग्राफ की चयनित रेंज को HTML के रूप में निर्यात करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाकर वांछित प्रेजेंटेशन लोड करें।
2. स्लाइड तक पहुँचें और वह [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) खोजें जिसमें टेक्स्ट हो।
3. शेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
4. शुरूआती पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफ की संख्या के साथ [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) को कॉल करें।
5. वापसी HTML स्ट्रिंग को फ़ाइल में लिखें।

यह PHP उदाहरण पहले टेक्स्ट शैप से सभी पैराग्राफ निर्यात करता है:

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

### **पैराग्राफ को इमेज के रूप में रेंडर करना**

[Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage--) एक व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) लौटाता है। परिणाम को फ़ाइल या स्ट्रीम में [IImage::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/#save-java.lang.String-int-) से सहेजें। आपको कंटेनिंग शैप को रेंडर करने या बिटमैप को मैन्युअल रूप से क्रॉप करने की आवश्यकता नहीं है।

[Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage--) `null` भी लौट सकता है यदि पैराग्राफ अपने पैरेंट कलेक्शन में नहीं मिला, वैध रेंडरिंग बाउंड्स नहीं हैं, या रेंडर नहीं किया जा सकता। सहेजने से पहले परिणाम जांचें और उपयोग के बाद लौटाए गए इमेज को डिस्पोज करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करना**

मान लेते हैं कि हमारे पास sample.pptx नामक एक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, और पहला शैप तीन पैराग्राफ वाले टेक्स्ट बॉक्स है।

![तीन पैराग्राफ वाले टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न PHP उदाहरण डिफ़ॉल्ट स्केल पर नियमित टेक्स्ट शैप में दूसरे पैराग्राफ को रेंडर करता है और लौटाए गए इमेज को PNG फ़ॉर्मेट में सहेजता है। `finally` ब्लॉक सुनिश्चित करता है कि इमेज सही तरीके से डिस्पोज हो।

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

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करना**

हॉरिज़ॉन्टल और वर्टिकल स्केल फैक्टर सेट करने के लिए `$scaleX` और `$scaleY` पैरामीटर स्वीकार करने वाले [Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage-float-float-) ओवरलोड का उपयोग करें।

निम्न PHP उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को उसके डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

`1` का स्केल फैक्टर उस अक्ष को उसके डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फैक्टर्स के लिए `2` देने से इमेज की चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे चार गुना पिक्सेल मिलते हैं। बड़े फैक्टर्स सामान्यतः ज़ूम या हाई-रिज़ॉल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फैक्टर्स कम डिटेल के साथ छोटी इमेज बनाते हैं। समान फैक्टर्स का उपयोग करके पैराग्राफ का अनुपात बना रखें; विभिन्न हॉरिज़ॉन्टल और वर्टिकल फैक्टर्स आउटपुट को स्वतंत्र रूप से स्ट्रेच करते हैं।

जब आउटपुट में शैप की फ़िल, बॉर्डर या अन्य विज़ुअल कंटेक्स्ट शामिल होना चाहिए, तो [Shape::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage--) से पूरे शैप को रेंडर करना उपयोगी रहता है। केवल पैराग्राफ इमेज के लिए, [Paragraph::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getImage--) का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह से अक्षम कर सकता हूँ?**

हाँ। लाइनें टेक्स्ट फ्रेम के किनारों पर न टूटें, इसके लिए [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setWrapText-byte-) को अक्षम करें।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक बाउंड्स कैसे प्राप्त करूँ?**

पैराग्राफ का बाउंडिंग रेक्टैंगल प्राप्त करने के लिए [Paragraph::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getRect--) का उपयोग करें। व्यक्तिगत पोर्शन की बाउंड्स के लिए [Portion::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getRect--) उपलब्ध कराता है।

**पैराग्राफ अलाइनमेंट (बाएँ, दाएँ, सेंटर, या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setAlignment-int-) पैराग्राफ स्तर का सेटिंग है और व्यक्तिगत पोर्शन फॉर्मेटिंग की परवाह किए बिना पूरे पैराग्राफ पर लागू होता है।

**क्या मैं पैराग्राफ के किसी भाग के लिए प्रूफिंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिए [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) सेट करें, ताकि एक पैराग्राफ में कई भाषाओं का टेक्स्ट हो सके।