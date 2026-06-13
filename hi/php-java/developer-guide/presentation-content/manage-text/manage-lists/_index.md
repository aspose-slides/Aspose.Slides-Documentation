---
title: Presentations में PHP का उपयोग करके बुलेटेड और नंबरड सूचियों को प्रबंधित करें
linktitle: सूचियों को प्रबंधित करें
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
- बहुस्तरीय सूची
- बुलेट बनाएं
- बुलेट जोड़ें
- सूची जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, बहुस्तरीय और क्रमांकित सूचियों को बनाने और स्वरूपित करने के बारे में सीखें।"
---
## **सारांश**

Aspose.Slides for PHP via Java आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और संख्यात्मक सूचियां बनाने और स्वरूपित करने की अनुमति देता है। एक सूची आइटम वह पैराग्राफ है जिसका बुलेट सेटिंग्स उसके पैराग्राफ फ़ॉर्मेट के माध्यम से नियंत्रित होते हैं।

उपरोक्त सूची सेटिंग्स को एक्सेस करने के लिए [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getParagraphFormat--) मेथड का उपयोग करें। मुख्य प्रवेश बिंदु है [ParagraphFormat.getBullet](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#getBullet--) , जो एक [BulletFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/) ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ आप बुलेट प्रकार, प्रतीक, चित्र, रंग, आकार, क्रमांक शैली, और प्रारंभिक संख्या सेट कर सकते हैं।

यह लेख दिखाता है कि कैसे:

- कस्टम प्रतीक के साथ बुलेटेड सूची बनाएं
- चित्र बुलेट बनाएं
- पैराग्राफ गहराई सेट करके मल्टीलेवल सूची बनाएं
- संख्यात्मक सूची बनाएं
- मौजूदा प्रस्तुति में सूची स्वरूपण को जांचें और बदलें

## **बुलेटेड सूची बनाएं**

बुलेटेड सूची बनाने के लिए, एक [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) में [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) ऑब्जेक्ट जोड़ें और [BulletFormat.setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/#Symbol) पर सेट करें। फिर आप बुलेट की उपस्थिति को नियंत्रित करने के लिए [BulletFormat.setChar](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#getColor--), और [BulletFormat.setHeight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setHeight-float-) सेट कर सकते हैं।

निम्नलिखित PHP कोड एक स्लाइड में बुलेटेड सूची बनाने का प्रदर्शन करता है:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

परिणाम:

![प्रतीक बुलेट्स](symbol_bullets.png)

## **संख्यात्मक सूची बनाएं**

जब आइटमों का क्रम महत्वपूर्ण हो तो संख्यात्मक सूचियों का उपयोग करें। [BulletFormat.setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/#Numbered) पर सेट करें। आप [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) के साथ क्रमांक शैली चुन सकते हैं या यदि सूची 1 से अलग मान से शुरू होनी चाहिए तो [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) सेट कर सकते हैं।

निम्नलिखित PHP कोड एक स्लाइड में संख्यात्मक सूची बनाने का तरीका दर्शाता है:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

परिणाम:

![संख्यात्मक बुलेट्स](numbered_bullets.png)

## **चित्र बुलेट बनाएं**

Aspose.Slides आपको सामान्य बुलेट प्रतीक को छवि से बदलने की अनुमति देता है। चित्र बुलेट्स सरल छवियों के साथ सबसे बेहतर काम करते हैं जो छोटे आकार में भी पठनीय रहें, जैसे आइकन या छोटे पारदर्शी PNG फ़ाइलें।

{{% alert color="primary" %}}
आदर्श रूप से, यदि आप सामान्य बुलेट प्रतीक को छवि से बदलने की योजना बना रहे हैं, तो पारदर्शी पृष्ठभूमि वाली एक सरल ग्राफिक्स चुनना सबसे बेहतर है। ऐसी छवियां कस्टम बुलेट प्रतीकों के रूप में अच्छी तरह काम करती हैं।

ध्यान रखें कि छवि बहुत छोटे आकार में स्केल किया जाएगा। इसलिए, हम दृढ़ता से सलाह देते हैं कि ऐसी छवि चुनें जो सूची में बुलेट के रूप में उपयोग होने पर भी स्पष्ट और दृश्य रूप से प्रभावी बनी रहे।
{{% /alert %}}

चित्र बुलेट बनाने के लिए, एक छवि को [Presentation.getImages](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getImages--) में जोड़ें और लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट को [BulletFormat.getPicture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#getPicture--) को असाइन करें। छवि असाइन करने से पहले [BulletFormat.setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/#setType-int-) को [BulletType.Picture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/#Picture) पर सेट करें।

मान लीजिए हमारे पास "image.png" है:

![बुलेट्स के लिए चित्र](picture_for_bullets.png)

निम्नलिखित PHP कोड एक स्लाइड में चित्र बुलेट्स बनाने का तरीका दर्शाता है:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

परिणाम:

![चित्र बुलेट्स](picture_bullets.png)

## **बहुस्तरीय सूची बनाएं**

सूची आइटमों को विभिन्न स्तरों पर रखने के लिए [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setDepth-short-) का उपयोग करें। स्तर 0 शीर्ष स्तर है, स्तर 1 उसके नीचे नेस्टेड है, और इसी प्रकार आगे।

निम्नलिखित PHP कोड बहुस्तरीय बुलेटेड सूची बनाने का तरीका दर्शाता है:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

परिणाम:

![बहुस्तरीय सूची](multilevel_list.png)

## **मौजूदा सूची बदलें**

मौजूदा प्रस्तुति में सूची स्वरूपण बदलने के लिए, लक्षित पैराग्राफ तक पहुँचें और उसके [ParagraphFormat.getBullet](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#getBullet--) सेटिंग्स को अपडेट करें। सूचियां बनाने के लिए उपयोग की गई वही प्रॉपर्टीज़ PPT, PPTX, या ODP फ़ाइल से लोड की गई सूचियों को निरीक्षण या संशोधित करने के लिए भी इस्तेमाल की जा सकती हैं।

निम्नलिखित PHP कोड एक टेक्स्ट फ्रेम में पहले पैराग्राफ को संख्यात्मक सूची शैली में बदलता है:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बुलेटेड और संख्यात्मक सूचियों को PDF या चित्रों में निर्यात किया जा सकता है?**

हां। Aspose.Slides सूची स्वरूपण को बरकरार रखता है जब लक्ष्य स्वरूप संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं को समर्थन देता है।

**क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?**

हां। प्रस्तुति लोड करें, लक्षित पैराग्राफ तक पहुँचें, उसके [ParagraphFormat.getBullet](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#getBullet--) सेटिंग्स की जाँच या अपडेट करें, और प्रस्तुति को सहेजें।

**क्या सूचियों में गैर-लैटिन पाठ हो सकता है?**

हां। सूची आइटम टेक्स्ट में यूनिकोड अक्षर हो सकते हैं, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियां बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट उन अक्षरों को समर्थन देते हैं जिनकी आपको आवश्यकता है।