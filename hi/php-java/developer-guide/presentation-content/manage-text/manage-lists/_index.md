---
title: PHP का उपयोग करके प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों का प्रबंधन
linktitle: सूचियों का प्रबंधन
type: docs
weight: 60
url: /hi/php-java/manage-lists/
keywords:
- बुलेट
- बुलेटेड सूची
- क्रमांकित सूची
- प्रतीक बुलेट
- चित्र बुलेट
- कस्टम बुलेट
- बहु-स्तरीय सूची
- बुलेट बनाएं
- बुलेट जोड़ें
- सूची जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, बहु-स्तरीय और क्रमांकित सूचियों को बनाना और स्वरूपित करना सीखें।"
---
## **समीक्षा**

Aspose.Slides for PHP via Java आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और नंबर वाले सूचियों को बनाने और स्वरूपित करने की अनुमति देता है। एक सूची आइटम एक पैराग्राफ है जिसका बुलेट सेटिंग्स उसके पैराग्राफ फ़ॉर्मेट के माध्यम से नियंत्रित होती हैं।

पैराग्राफ-स्तर की सूची सेटिंग्स तक पहुंचने के लिए [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) मेथड का उपयोग करें। मुख्य प्रवेश बिंदु है [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) जो एक [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ, आप बुलेट प्रकार, प्रतीक, चित्र, रंग, आकार, नंबरिंग शैली, और प्रारंभिक संख्या सेट कर सकते हैं।

यह लेख दिखाता है कि कैसे:
- कस्टम प्रतीक के साथ बुलेटेड सूची बनाएं
- चित्र बुलेट बनाएं
- पैराग्राफ गहराई सेट करके मल्टीलेवल सूची बनाएं
- नंबर वाली सूची बनाएं
- मौजूदा प्रस्तुति में सूची स्वरूपण की जांच और परिवर्तन करें
- पैराग्राफ टेक्स्ट के साथ वास्तविक सूची मार्कर और संख्याएँ पढ़ें

## **बुलेटेड सूची बनाएँ**

बुलेटेड सूची बनाने के लिए, [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) ऑब्जेक्ट्स को एक [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) में जोड़ें और [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) को [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol) पर सेट करें। फिर आप बुलेट रूप को नियंत्रित करने के लिए [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar), [BulletFormat::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getColor), और [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) सेट कर सकते हैं।

निम्नलिखित PHP कोड स्लाइड में बुलेटेड सूची बनाने का प्रदर्शन करता है:

```php
use aspose\slides\BulletType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![प्रतीक बुलेट](symbol_bullets.png)

## **नंबर वाली सूची बनाएँ**

जब आइटम्स का क्रम महत्वपूर्ण हो तो नंबर वाली सूचियों का उपयोग करें। [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) को [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Numbered) पर सेट करें। आप [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) के साथ नंबरिंग फ़ॉर्मेट चुन सकते हैं या यदि सूची 1 से अलग मान से शुरू होनी चाहिए तो [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) सेट कर सकते हैं।

निम्नलिखित PHP कोड स्लाइड में नंबर वाली सूची बनाने का उदाहरण दिखाता है:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![नंबर वाले बुलेट](numbered_bullets.png)

## **चित्र बुलेट बनाएँ**

Aspose.Slides आपको नियमित बुलेट प्रतीक को इमेज से बदलने की अनुमति देता है। चित्र बुलेट सबसे अच्छी तरह सरल छवियों के साथ काम करती हैं जो छोटे आकार में भी पठनीय रहती हैं, जैसे आइकॉन या छोटे पारदर्शी PNG फ़ाइलें।

{{% alert color="info" title="Note" %}}
आदर्श रूप से, यदि आप नियमित बुलेट प्रतीक को इमेज से बदलने की योजना बनाते हैं, तो पारदर्शी पृष्ठभूमि के साथ एक साधारण ग्राफिक चुनना सबसे अच्छा है। ऐसी छवियां कस्टम बुलेट प्रतीक के रूप में अच्छी तरह काम करती हैं।

ध्यान रखें कि छवि को बहुत छोटे आकार में स्केल किया जाएगा। इसलिए हम दृढ़ता से अनुशंसा करते हैं कि ऐसी छवि चुनें जो सूची में बुलेट के रूप में उपयोग होने पर स्पष्ट और दृश्य रूप से प्रभावी बनी रहे।
{{% /alert %}}

चित्र बुलेट बनाने के लिए, [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getImages) में एक छवि जोड़ें और लौटाए गए [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) ऑब्जेक्ट को [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture) को असाइन करें। छवि असाइन करने से पहले, [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) को [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) पर सेट करें।

मान लीजिए हमारे पास एक "image.png" है:

![बुलेट्स के लिए चित्र](picture_for_bullets.png)

निम्नलिखित PHP कोड स्लाइड में चित्र बुलेट बनाने का तरीका दिखाता है:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![चित्र बुलेट](picture_bullets.png)

## **बहु-स्तरीय सूची बनाएँ**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) का उपयोग करके सूची आइटम्स को विभिन्न स्तरों पर रखें। स्तर 0 शीर्ष स्तर है, स्तर 1 उसके नीचे नेस्टेड होता है, आदि।

निम्नलिखित PHP कोड बहु-स्तरीय बुलेटेड सूची बनाने का उदाहरण दिखाता है:

```php
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![बहु-स्तरीय सूची](multilevel_list.png)

## **मौजूदा सूची बदलें**

मौजूदा प्रस्तुति में सूची स्वरूपण बदलने के लिए, लक्ष्य पैराग्राफ तक पहुंचें और उसके [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) सेटिंग्स को अपडेट करें। सूचियों को बनाने के लिए इस्तेमाल किए गए वही प्रॉपर्टीज़ PPT, PPTX, या ODP फ़ाइल से लोड की गई सूचनाओं की जांच या संशोधित करने के लिए उपयोग किए जा सकते हैं।

निम्नलिखित PHP कोड टेक्स्ट फ्रेम में पहले पैराग्राफ को नंबर वाली सूची शैली में बदलता है:

```php
use aspose\slides\BulletType;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **वास्तविक बुलेट मान पढ़ें**

प्रस्तुति सामग्री निकालते समय, सूची मार्करों को पैराग्राफ टेक्स्ट के साथ रखें। प्रभावी बुलेट फ़ॉर्मेट प्राप्त करने के लिए [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getEffective) को कॉल करें और [ParagraphFormatEffectiveData::getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) तक पहुंचें। [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) पढ़ने से पहले उसके [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) जांचें।

नंबर वाली सूचियों के लिए, इन तीन मानों में अंतर करें:
- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) स्वरूप निर्धारित करता है, जैसे अवधि के साथ अरबी संख्या या लोअरकेस अक्षर।
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) नंबर वाले पैराग्राफों के समूह की शुरुआती संख्या निर्दिष्ट करता है।
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) किसी विशेष पैराग्राफ के लिए स्वरूपित मार्कर लौटाता है। उदाहरण के लिए, 5 से शुरू होने वाली सूची में दूसरा आइटम `6.` लौटाएगा।

प्रत्येक पैराग्राफ के साथ [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDepth) को संरक्षित रखें ताकि उसकी नेस्टिंग स्तर बनी रहे। वास्तविक मार्कर पूर्ण पदानुक्रम को एन्कोड नहीं करता: एक नेस्टेड आइटम `c.` लौटाएगा, न कि `6.c.` जैसा संयुक्त लेबल।

निम्नलिखित स्व-समाहित उदाहरण सूचियाँ बनाता है, उन्हें प्रस्तुति में सहेजता है, और प्रस्तुति को पुनः लोड करके प्रत्येक पैराग्राफ का टेक्स्ट, गहराई, बुलेट प्रकार और वास्तविक मान रिपोर्ट करता है। छोटा नीला चित्र मार्कर इनलाइन SVG से बनाया गया है।

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 440, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    // बिना बाहरी इमेज फ़ाइल के चित्र मार्कर बनाएं।
    $svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    $bulletImage = $presentation->getImages()->addImage($svg);

    $black = new Java("java.awt.Color", 0, 0, 0);
    $addParagraph = function ($text, $depth, $type, $start, $style) use ($textFrame, $bulletImage, $black) {
        $paragraph = new Paragraph();
        $paragraph->setText($text);

        $format = $paragraph->getParagraphFormat();
        $format->setDepth($depth);
        $format->setMarginLeft(30 + $depth * 40);
        $format->setIndent(-28);
        $format->setSpaceAfter(8);
        $format->getDefaultPortionFormat()->setFontHeight(22);
        $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $format->getBullet()->setType($type);
        $format->getBullet()->setBulletHardColor(NullableBool::True);
        $format->getBullet()->getColor()->setColor($black);
        if ($type == BulletType::Numbered) {
            $format->getBullet()->setNumberedBulletStyle($style);
            $format->getBullet()->setNumberedBulletStartWith($start);
        } else if ($type == BulletType::Symbol) {
            $format->getBullet()->setChar("\u{2022}");
        } else if ($type == BulletType::Picture) {
            $format->getBullet()->getPicture()->setImage($bulletImage);
        }

        $textFrame->getParagraphs()->add($paragraph);
    };

    $addParagraph("First item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Second item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    $addParagraph("Back to top level", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Symbol marker", 0, BulletType::Symbol, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("No bullet", 0, BulletType::None, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Picture marker", 0, BulletType::Picture, 1, NumberedBulletStyle::BulletArabicPeriod);
    $presentation->save("actual_bullet_values.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    $loadedShape = $loadedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Text | Depth | Type | Actual value\n";
    $paragraphs = $loadedShape->getTextFrame()->getParagraphs();
    for ($i = 0; $i < java_values($paragraphs->getCount()); $i++) {
        $paragraph = $paragraphs->get_Item($i);
        $bullet = $paragraph->getParagraphFormat()->getEffective()->getBullet();
        switch (java_values($bullet->getType())) {
            case BulletType::Numbered:
            case BulletType::Symbol:
                $marker = $bullet->getActualBulletValue();
                break;
            case BulletType::None:
                $marker = "null (no bullet)";
                break;
            case BulletType::Picture:
                $marker = "null (image required)";
                break;
            default:
                $marker = "unsupported bullet type";
                break;
        }
        $typeNames = [BulletType::Numbered => "Numbered", BulletType::Symbol => "Symbol", BulletType::None => "None", BulletType::Picture => "Picture"];
        $typeName = $typeNames[java_values($bullet->getType())] ?? "Unknown";
        echo $paragraph->getText() . " | " . $paragraph->getParagraphFormat()->getDepth() . " | " . $typeName . " | " . $marker . "\n";
    }
} finally {
    $loadedPresentation->dispose();
}
```

नीचे स्रोत सूचियाँ दी गई हैं।

![सूचियाँ जो 5 से शुरू होती हैं, नेस्टेड अक्षर और रोमन-नंबर आइटम, एक प्रतीक_MARKर, बुलेट के बिना पैराग्राफ, और एक नीला चित्र MARKर](actual_bullet_values.png)

रिपोर्ट PowerPoint में प्रदर्शित MARKरों से मेल खाती है:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

[BulletType::None और BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/) के लिए, [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) `null` लौटाता है, खाली स्ट्रिंग नहीं। इन प्रकारों को अलग-अलग संभालें: पहला कोई MARKर नहीं रखता, जबकि दूसरा बुलेट इमेज को अलग से निकालने की आवश्यकता होती है। एक चित्र बुलेट केवल टेक्स्ट MARKर निकालकर फिर से नहीं बनाया जा सकता।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बुलेटेड और नंबर वाली सूचियों को PDF या इमेज में निर्यात किया जा सकता है?**  
हां। Aspose.Slides सूची स्वरूपण को बनाए रखता है जब लक्ष्य फ़ॉर्मेट संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं का समर्थन करता है।

**क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?**  
हां। प्रस्तुति लोड करें, लक्ष्य पैराग्राफ तक पहुंचें, उसके [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) सेटिंग्स की जांच या अद्यतन करें, और प्रस्तुति को सहेजें।

**क्या सूचियों में गैर-लैटिन टेक्स्ट हो सकता है?**  
हां। सूची आइटम टेक्स्ट यूनिकोड अक्षर रख सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियों को बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट आवश्यक अक्षरों को समर्थन देते हों।