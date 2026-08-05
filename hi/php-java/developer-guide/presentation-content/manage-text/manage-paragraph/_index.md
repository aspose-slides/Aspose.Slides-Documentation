---
title: PHP में PowerPoint टेक्स्ट पैराग्राफ़ का प्रबंधन
linktitle: पैराग्राफ़ का प्रबंधन
type: docs
weight: 40
url: /hi/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
keywords:
- टेक्स्ट जोड़ें
- पैराग्राफ़ जोड़ें
- टेक्स्ट प्रबंधित करें
- पैराग्राफ़ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ़ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ़ बुलेट
- क्रमांकित सूची
- बुलेटेड सूची
- पैराग्राफ़ गुण
- HTML आयात
- टेक्स्ट से HTML
- पैराग्राफ़ से HTML
- पैराग्राफ़ से छवि
- टेक्स्ट से छवि
- पैराग्राफ़ निर्यात
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ पैराग्राफ़ फ़ॉर्मेटिंग में माहिर बनें — PPT, PPTX, और ODP प्रस्तुतियों में संरेखण, अंतराल और शैली को अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides उन सभी क्लासों को प्रदान करता है जो आपको PowerPoint टेक्स्ट, पैराग्राफ और पोर्शन के साथ काम करने के लिए आवश्यक हैं।

* Aspose.Slides [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) क्लास प्रदान करता है जिससे आप पैराग्राफ को दर्शाने वाले ऑब्जेक्ट जोड़ सकते हैं। एक `TextFame` ऑब्जेक्ट में एक या कई पैराग्राफ हो सकते हैं (प्रत्येक पैराग्राफ कैरिज रिटर्न द्वारा बनाया जाता है)।
* Aspose.Slides [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) क्लास प्रदान करता है जिससे आप पोर्शन को दर्शाने वाले ऑब्जेक्ट जोड़ सकते हैं। एक `Paragraph` ऑब्जेक्ट में एक या कई पोर्शन (पोर्शन ऑब्जेक्ट का संग्रह) हो सकते हैं।
* Aspose.Slides [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) क्लास प्रदान करता है जिससे आप टेक्स्ट और उनके फॉर्मेटिंग गुणों को दर्शाने वाले ऑब्जेक्ट जोड़ सकते हैं।

एक `Paragraph` ऑब्जेक्ट अपने अंतर्निहित `Portion` ऑब्जेक्ट्स के माध्यम से विभिन्न फॉर्मेटिंग गुणों वाले टेक्स्ट को संभाल सकता है।

## **एकाधिक पैराग्राफ़ जोड़ें जिनमें कई पोर्शन हों**

इन चरणों में दिखाया गया है कि कैसे 3 पैराग्राफ़ वाला टेक्स्ट फ़्रेम जोड़ें और प्रत्येक पैराग्राफ़ में 3 पोर्शन हों:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. स्लाइड के इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) से जुड़ा ITextFrame प्राप्त करें।
5. दो [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) ऑब्जेक्ट बनाएं और उन्हें [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) की पैराग्राफ़ कलेक्शन में जोड़ें।
6. प्रत्येक नए `Paragraph` के लिए तीन [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) ऑब्जेक्ट बनाएं (डिफ़ॉल्ट Paragraph के लिए दो Portion ऑब्जेक्ट) और प्रत्येक `Portion` ऑब्जेक्ट को संबंधित `Paragraph` की पोर्शन कलेक्शन में जोड़ें।
7. प्रत्येक पोर्शन के लिए कुछ टेक्स्ट सेट करें।
8. `Portion` ऑब्जेक्ट द्वारा प्रदान किए गए फॉर्मेटिंग गुणों का उपयोग करके प्रत्येक पोर्शन पर अपनी पसंदीदा फॉर्मेटिंग लागू करें।
9. संशोधित प्रेजेंटेशन को सहेजें।

```php
# एक Presentation क्लास का इंस्टेंस बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है
$pres = new Presentation();
try {
    # पहली स्लाइड तक पहुँच रहे हैं
    $slide = $pres->getSlides()->get_Item(0);
    # Rectangle प्रकार का AutoShape जोड़ें
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # AutoShape का TextFrame एक्सेस करें
    $tf = $ashp->getTextFrame();
    # विभिन्न टेक्स्ट फ़ॉर्मेट वाले पैराग्राफ़ और पोर्शन बनाएं
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # PPTX को डिस्क पर लिखें
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **पैराग्राफ बुलेट्स को प्रबंधित करें**

बुलेट सूची आपको जानकारी को शीघ्र और कुशलता से व्यवस्थित व प्रस्तुत करने में मदद करती है। बुलेटेड पैराग्राफ़ हमेशा पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. स्लाइड के इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. चयनित स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. ऑटोशेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ़ उदाहरण बनाएँ।
7. पैराग्राफ़ के लिए बुलेट `Type` को `Symbol` सेट करें और बुलेट कैरेक्टर निर्धारित करें।
8. पैराग्राफ़ का `Text` सेट करें।
9. बुलेट के लिए पैराग्राफ़ `Indent` सेट करें।
10. बुलेट के लिए एक रंग सेट करें।
11. बुलेट की ऊँचाई सेट करें।
12. नए पैराग्राफ़ को `TextFrame` पैराग्राफ़ कलेक्शन में जोड़ें।
13. दूसरा पैराग्राफ़ जोड़ें और चरण 7‑13 में दिए गए प्रक्रिया को दोहराएँ।
14. प्रेजेंटेशन को सहेजें।

```php
# एक Presentation क्लास का इंस्टेंस बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
$pres = new Presentation();
try {
    # पहली स्लाइड तक पहुँचता है
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape जोड़ता और एक्सेस करता है
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # autoshape का टेक्स्ट फ़्रेम एक्सेस करता है
    $txtFrm = $aShp->getTextFrame();
    # डिफ़ॉल्ट पैराग्राफ़ को हटाता है
    $txtFrm->getParagraphs()->removeAt(0);
    # एक पैराग्राफ़ बनाता है
    $para = new Paragraph();
    # पैराग्राफ़ बुलेट शैली और प्रतीक सेट करता है
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # पैराग्राफ़ का टेक्स्ट सेट करता है
    $para->setText("Welcome to Aspose.Slides");
    # बुलेट इंडेंट सेट करता है
    $para->getParagraphFormat()->setIndent(25);
    # बुलेट रंग सेट करता है
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// IsBulletHardColor को true सेट करें ताकि अपनी बुलेट रंग उपयोग हो

    # बुलेट की ऊँचाई सेट करता है
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ता है
    $txtFrm->getParagraphs()->add($para);
    # दूसरा पैराग्राफ़ बनाता है
    $para2 = new Paragraph();
    # पैराग्राफ़ बुलेट प्रकार और शैली सेट करता है
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # पैराग्राफ़ टेक्स्ट जोड़ता है
    $para2->setText("This is numbered bullet");
    # बुलेट इंडेंट सेट करता है
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// IsBulletHardColor को true सेट करें ताकि अपनी बुलेट रंग उपयोग हो

    # बुलेट की ऊँचाई सेट करता है
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ता है
    $txtFrm->getParagraphs()->add($para2);
    # संशोधित प्रेजेंटेशन को सहेजता है
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **चित्र बुलेट्स को प्रबंधित करें**

बुलेट सूची आपको जानकारी को शीघ्र और कुशलता से व्यवस्थित व प्रस्तुत करने में मदद करती है। चित्र पैराग्राफ़ पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. स्लाइड के इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. ऑटोशेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ़ उदाहरण बनाएँ।
7. [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) में छवि लोड करें।
8. बुलेट प्रकार को [Picture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bullettype/#Picture) पर सेट करें और छवि निर्धारित करें।
9. पैराग्राफ़ `Text` सेट करें।
10. बुलेट के लिए पैराग्राफ़ `Indent` सेट करें।
11. बुलेट के लिए एक रंग सेट करें।
12. बुलेट की ऊँचाई सेट करें।
13. नए पैराग्राफ़ को `TextFrame` पैराग्राफ़ कलेक्शन में जोड़ें।
14. दूसरा पैराग्राफ़ जोड़ें और पिछली चरणों के आधार पर प्रक्रिया दोहराएँ।
15. संशोधित प्रेजेंटेशन को सहेजें।

```php
# एक Presentation क्लास का इंस्टेंस बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
$presentation = new Presentation();
try {
    # पहली स्लाइड तक पहुँचता है
    $slide = $presentation->getSlides()->get_Item(0);
    # बुलेट्स के लिए इमेज का इंस्टेंस बनाता है
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # AutoShape जोड़ता और एक्सेस करता है
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # AutoShape के टेक्स्टफ़्रेम तक पहुँचता है
    $textFrame = $autoShape->getTextFrame();
    # डिफ़ॉल्ट पैराग्राफ़ को हटाता है
    $textFrame->getParagraphs()->removeAt(0);
    # एक नया पैराग्राफ़ बनाता है
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # पैराग्राफ़ बुलेट शैली और इमेज सेट करता है
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # बुलेट की ऊँचाई सेट करता है
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ता है
    $textFrame->getParagraphs()->add($paragraph);
    # प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजता है
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # प्रेजेंटेशन को PPT फ़ाइल के रूप में सहेजता है
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **बहुस्तरीय बुलेट्स को प्रबंधित करें**

बुलेट सूची आपको जानकारी को शीघ्र और कुशलता से व्यवस्थित व प्रस्तुत करने में मदद करती है। बहुस्तरीय बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. स्लाइड के इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. नई स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. ऑटोशेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ़ बनाएं और गहराई को 0 पर सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ़ बनाएं और गहराई को 1 पर सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ़ बनाएं और गहराई को 2 पर सेट करें।
9. `Paragraph` क्लास के माध्यम से चौथा पैराग्राफ़ बनाएं और गहराई को 3 पर सेट करें।
10. नए पैराग्राफ़ को `TextFrame` पैराग्राफ़ कलेक्शन में जोड़ें।
11. संशोधित प्रेजेंटेशन को सहेजें।

```php
# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
$pres = new Presentation();
try {
    # पहली स्लाइड तक पहुँचता है
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape जोड़ता और एक्सेस करता है
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # बनाए गए AutoShape के टेक्स्ट फ़्रेम तक पहुँचता है
    $text = $aShp->addTextFrame("");
    # डिफ़ॉल्ट पैराग्राफ़ को साफ़ करता है
    $text->getParagraphs()->clear();
    # पहला पैराग्राफ़ जोड़ता है
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # बुलेट स्तर सेट करता है
    $para1->getParagraphFormat()->setDepth(0);
    # दूसरा पैराग्राफ़ जोड़ता है
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # बुलेट स्तर सेट करता है
    $para2->getParagraphFormat()->setDepth(1);
    # तीसरा पैराग्राफ़ जोड़ता है
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # बुलेट स्तर सेट करता है
    $para3->getParagraphFormat()->setDepth(2);
    # चौथा पैराग्राफ़ जोड़ता है
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # बुलेट स्तर सेट करता है
    $para4->getParagraphFormat()->setDepth(3);
    # पैराग्राफ़ को कलेक्शन में जोड़ता है
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # प्रस्तुतिकरण को PPTX फ़ाइल के रूप में लिखता है
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **कस्टम क्रमांकित सूची के साथ पैराग्राफ को प्रबंधित करें**

[BulletFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/) क्लास [setNumberedBulletStartWith](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) जैसे मेथड प्रदान करता है जो आपको कस्टम नंबरिंग या फॉर्मेटिंग के साथ पैराग्राफ को प्रबंधित करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. पैराग्राफ़ वाले स्लाइड तक पहुँचें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. ऑटोशेप के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ़ बनाएं और [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) को 2 पर सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ़ बनाएं और `NumberedBulletStartWith` को 3 पर सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ़ बनाएं और `NumberedBulletStartWith` को 7 पर सेट करें।
9. नए पैराग्राफ़ को `TextFrame` पैराग्राफ़ कलेक्शन में जोड़ें।
10. संशोधित प्रेजेंटेशन को सहेजें।

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # बनाए गए autoshape के टेक्स्ट फ्रेम तक पहुँचता है
    $textFrame = $shape->getTextFrame();
    # डिफ़ॉल्ट मौजूदा पैराग्राफ़ को हटाता है
    $textFrame->getParagraphs()->removeAt(0);
    # पहली सूची
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **पैराग्राफ के प्रथम-पंक्ति इंडेंट को सेट करें**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setindent/) मेथड का उपयोग करके आप पैराग्राफ़ की प्रथम‑पंक्ति इंडेंट नियंत्रित कर सकते हैं। यह मेथड केवल प्रथम पंक्ति को पैराग्राफ़ के बाएँ मार्जिन के सापेक्ष स्थानांतरित करता है। सकारात्मक मान प्रथम पंक्ति को दाएँ शिफ्ट करता है, जबकि शेष पंक्तियाँ पैराग्राफ़ बॉडी के साथ संरेखित रहती हैं।

यदि आपको पूरी पैराग्राफ़ को स्थानांतरित करना है तो [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setmarginleft/) उपयोग करें। यदि केवल प्रथम‑पंक्ति को स्थानांतरित करना है तो [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setindent/) उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ़ बनाता है और विभिन्न इंडेंट मान लागू करता है ताकि दिखाया जा सके कि प्रथम‑पंक्ति इंडेंट पैराग्राफ़ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. आकार में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ़ को हटाएँ।
5. कई पैराग्राफ़ बनाएं और उनके लिए विभिन्न [Indent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setindent/) मान सेट करें।
6. पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन को सहेजें।

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
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

![पैराग्राफ़ों का प्रथम‑पंक्ति इंडेंट](first_line_indent.png)

## **पैराग्राफ के हैंगिंग इंडेंट को सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ़ लेआउट है जिसमें पहली पंक्ति बाकी पंक्तियों से बाईं ओर शुरू होती है। Aspose.Slides में, आप इस प्रभाव को [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setindent/) मेथड से बना सकते हैं। पहली पंक्ति को बाएँ ले जाने के लिए इंडेंट को नकारात्मक मान पर सेट करें।

वास्तव में, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setmarginleft/) पैराग्राफ़ बॉडी की बायीं स्थिति को परिभाषित करता है, और [ParagraphFormat::setIndent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setindent/) पहली पंक्ति की स्थिति को उस मार्जिन के सापेक्ष परिभाषित करता है। हैंगिंग इंडेंट बनाने के लिए, `MarginLeft` को सकारात्मक मान और `Indent` को नकारात्मक मान सेट करें।

यह फॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ के लिए उपयोगी है जहाँ रैप्ड पंक्तियों को पैराग्राफ़ बॉडी के नीचे संरेखित होना चाहिए न कि पहली पंक्ति के पहले अक्षर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. आकार में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ़ को हटाएँ।
5. प्रत्येक पैराग्राफ़ के लिए एक सकारात्मक [MarginLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setmarginleft/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए एक नकारात्मक [Indent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setindent/) मान सेट करें।
7. पैराग्राफ़ को टेक्स्ट फ़्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन को सहेजें।

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![पैराग्राफ़ों का हैंगिंग इंडेंट](hanging_indent.png)

## **एंड पैराग्राफ रन गुणों को प्रबंधित करें**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. स्थिति के माध्यम से पैराग्राफ़ वाले स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
1. आयत में दो पैराग्राफ़ के साथ एक [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) जोड़ें।
1. पैराग्राफ़ के लिए फ़ॉन्ट हाईट और फ़ॉन्ट प्रकार सेट करें।
1. पैराग्राफ़ के एंड गुण सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **पैराग्राफ में HTML टेक्स्ट आयात करें**

Aspose.Slides पैराग्राफ़ में HTML टेक्स्ट आयात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. स्लाइड के इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
4. `AutoShape` के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें और जोड़ें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ़ को हटाएँ।
6. टेक्स्टरीडर में स्रोत HTML फ़ाइल पढ़ें।
7. [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ़ बनाएं।
8. पढ़े हुए TextReader की सामग्री को TextFrame की [ParagraphCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphcollection/) में जोड़ें।
9. संशोधित प्रेजेंटेशन को सहेजें।

```php
# खाली प्रस्तुति इंस्टेंस बनाएँ
$pres = new Presentation();
try {
    # प्रस्तुति की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    $slide = $pres->getSlides()->get_Item(0);
    # HTML सामग्री को समायोजित करने के लिए AutoShape जोड़ें
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # आकार में टेक्स्ट फ़्रेम जोड़ें
    $ashape->addTextFrame("");
    # जोड़े गए टेक्स्ट फ़्रेम में सभी पैराग्राफ़ साफ़ करें
    $ashape->getTextFrame()->getParagraphs()->clear();
    # स्ट्रीम रीडर का उपयोग करके HTML फ़ाइल लोड करें
    $tr = new StreamReader("file.html");
    # टेक्स्ट फ़्रेम में HTML स्ट्रीम रीडर से टेक्स्ट जोड़ें
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # प्रस्तुति को सहेजें
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

Aspose.Slides पैराग्राफ़ में मौजूद टेक्स्ट को HTML में निर्यात करने के लिए उन्नत समर्थन प्रदान करता है।

1. इच्छित प्रेजेंटेशन को लोड करके [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. स्लाइड के इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. HTML में निर्यात की जाने वाली टेक्स्ट वाले आकार तक पहुँचें।
4. आकार के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
5. `StreamWriter` का एक उदाहरण बनाएं और नई HTML फ़ाइल जोड़ें।
6. StreamWriter को प्रारंभिक इंडेक्स प्रदान करें और अपनी पसंदीदा पैराग्राफ़ निर्यात करें।

```php
# प्रस्तुति फ़ाइल लोड करें
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # प्रस्तुति की डिफ़ॉल्ट पहली स्लाइड तक पहुँचें
    $slide = $pres->getSlides()->get_Item(0);
    # इच्छित इंडेक्स
    $index = 0;
    # जोड़े गए आकार तक पहुँच रहे हैं
    $ashape = $slide->getShapes()->get_Item($index);
    # आउटपुट HTML फ़ाइल बना रहे हैं
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # पहला पैराग्राफ़ HTML के रूप में निकाल रहे हैं
    # पैराग्राफ़ डेटा को HTML में लिख रहे हैं, पैराग्राफ़ की शुरुआत इंडेक्स और कॉपी किए जाने वाले कुल पैराग्राफ़ प्रदान करके
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **एक पैराग्राफ को छवि के रूप में सहेजें**

इस भाग में, हम दो उदाहरणों का अन्वेषण करेंगे जो दर्शाते हैं कि कैसे [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) क्लास द्वारा प्रतिनिधित्व किए गए टेक्स्ट पैराग्राफ़ को छवि के रूप में सहेजा जा सकता है। दोनों उदाहरणों में आकार से छवि प्राप्त करने, पैराग्राफ़ के बाउंड्स की गणना करने और इसे बिटमैप छवि के रूप में निर्यात करने की प्रक्रिया शामिल है। इन तरीकों से आप PowerPoint प्रेजेंटेशन से विशिष्ट टेक्स्ट भाग निकालकर अलग-अलग छवियों के रूप में सहेज सकते हैं, जो विभिन्न परिदृश्यों में उपयोगी हो सकता है।

मान लेते हैं कि हमारे पास sample.pptx नामक एक प्रेजेंटेशन फ़ाइल है, जिसमें एक स्लाइड है और पहला आकार एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ़ हैं।

![तीन पैराग्राफ़ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

**उदाहरण 1**

इस उदाहरण में, हम दूसरे पैराग्राफ़ को छवि के रूप में प्राप्त करते हैं। इसके लिए हम पहले स्लाइड के आकार से छवि निकालते हैं और फिर आकार के टेक्स्ट फ़्रेम में दूसरे पैराग्राफ़ के बाउंड्स की गणना करते हैं। पैराग्राफ़ को फिर एक नई बिटमैप छवि पर पुनः ड्रॉ किया जाता है, जिसे PNG फ़ॉर्मेट में सहेजा जाता है। यह विधि तब उपयोगी होती है जब आपको विशिष्ट पैराग्राफ़ को अलग छवि के रूप में सहेजना हो और टेक्स्ट के आयाम व फ़ॉर्मेटिंग को बनाए रखना हो।

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // आकार को मेमोरी में बिटमैप के रूप में सहेजें।
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // मेमोरी से एक आकार बिटमैप बनाएं।
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // दूसरे पैराग्राफ़ की सीमाओं की गणना करें।
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // आउटपुट चित्र के लिए समन्वय और आकार की गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // केवल पैराग्राफ़ बिटमैप प्राप्त करने के लिए आकार बिटमैप को काटें।
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

परिणाम:

![पैराग्राफ़ छवि](paragraph_to_image_output.png)

**उदाहरण 2**

इस उदाहरण में, हम पिछले दृष्टिकोण को स्केलिंग फ़ैक्टर जोड़कर विस्तारित करते हैं। आकार को प्रेजेंटेशन से निकालते हैं और `2` के स्केल फ़ैक्टर के साथ छवि के रूप में सहेजते हैं। इससे निर्यात किए गए पैराग्राफ़ की उच्च रिजॉल्यूशन प्राप्त होती है। फिर पैराग्राफ़ बाउंड्स को स्केल को ध्यान में रखकर गणना किया जाता है। स्केलिंग तब उपयोगी होती है जब अधिक विस्तृत छवि की आवश्यकता हो, जैसे उच्च-गुणवत्ता वाले मुद्रण सामग्री में उपयोग के लिए।

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // आकार को मेमोरी में स्केलिंग के साथ बिटमैप के रूप में सहेजें।
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // मेमोरी से आकार बिटमैप बनाएं।
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // दूसरे पैराग्राफ़ की सीमाओं की गणना करें।
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // आउटपुट छवि के लिए समन्वय और आकार की गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // केवल पैराग्राफ़ बिटमैप प्राप्त करने के लिए आकार बिटमैप को काटें।
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ़्रेम के भीतर लाइन रैपिंग को पूरी तरह बंद कर सकता हूँ?**

हाँ। टेक्स्ट फ़्रेम की रैपिंग सेटिंग ([setWrapText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/setwraptext/)) को बंद करके लाइन रैपिंग को निष्क्रिय कर सकते हैं ताकि लाइनों को फ़्रेम के किनारों पर नहीं तोड़ा जाए।

**मैं किसी विशेष पैराग्राफ़ की स्लाइड पर सटीक बाउंड्स कैसे प्राप्त कर सकता हूँ?**

आप पैराग्राफ़ (और यहाँ तक कि एकल पोर्शन) का बाउंडिंग रेक्टेंगल प्राप्त कर सकते हैं जिससे उसके सटीक स्थान और आकार का पता चलता है।

**पैराग्राफ़ एलाइनमेंट (बाएँ/दाएँ/केंद्र/जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[Alignment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setalignment/) एक पैराग्राफ‑लेवल सेटिंग है जो [ParagraphFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/) में परिभाषित है; यह पूरे पैराग्राफ़ पर लागू होता है, चाहे व्यक्तिगत पोर्शन का फॉर्मेट कुछ भी हो।

**क्या मैं पैराग्राफ़ के केवल एक भाग (उदाहरण के लिए एक शब्द) के लिए स्पेल‑चेक भाषा सेट कर सकता हूँ?**

हाँ। भाषा पोर्शन स्तर पर सेट की जाती है ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId)), इसलिए एक ही पैराग्राफ़ में कई भाषाएँ साथ‑साथ मौजूद हो सकती हैं।