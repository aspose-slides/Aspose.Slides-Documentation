---
title: PHP में प्रस्तुति पाठ का फ़ॉर्मेट
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/php-java/text-formatting/
keywords:
- पाठ को हाइलाइट करें
- नियमित अभिव्यक्ति
- पैराग्राफ को संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घूर्णन
- घूर्णन कोण
- पाठ फ्रेम
- पंक्ति अंतराल
- ऑटॉफ़िट गुण
- पाठ फ्रेम एंकर
- पाठ टैब्यूलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फ़ॉर्मेट और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण और अधिक को अनुकूलित करें।"
---
## **परिचय**

यह लेख दिखाता है कि Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को कैसे स्वरूपित किया जाए। यह हाइलाइटिंग, पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, अनुच्छेद अंतराल, ऑटॉफ़िट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

नीचे दिए गए उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है जिसमें निम्नलिखित पाठ है:

![नमूना पाठ](sample_text.png)

## **पाठ को हाइलाइट करें**

जब आपको टेक्स्ट फ़्रेम के भीतर किसी विशिष्ट नमूने से मेल खाने वाले पाठ को हाइलाइट करना हो, तब आप [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/)`::highlightText` मेथड का उपयोग करें। यह मेथड मेल खाने वाले पाठ भागों को हाइलाइट रंग लागू करता है और इसे [TextHighlightingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/texthighlightingoptions/) के साथ उपयोग करके खोज के तरीके को नियंत्रित किया जा सकता है, उदाहरण के लिए केवल पूर्ण शब्दों के मेल के लिए।

नीचे दिया गया कोड उदाहरण अक्षर **"try"** की सभी उपस्थिति को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है।

```php
$presentation = new Presentation("sample.pptx");
try {
    // पहली स्लाइड से पहला आकार प्राप्त करें।
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // आकार में शब्द "try" को हाइलाइट करें।
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // आकार में शब्द "to" को हाइलाइट करें।
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![हाइलाइट किया हुआ पाठ](highlighted_text.png)

## **नियमित अभिव्यक्तियों का उपयोग करके पाठ को हाइलाइट करना**

[TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/)`::highlightRegex` मेथड नियमित अभिव्यक्ति द्वारा मिलने वाले पाठ मेलों को हाइलाइट करता है।

नीचे दिया गया कोड उदाहरण उन सभी शब्दों को हाइलाइट करता है जिनमें **सात या अधिक अक्षर** होते हैं:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // सात या अधिक अक्षर वाले सभी शब्दों को हाइलाइट करें।
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![नियमित अभिव्यक्ति का उपयोग करके हाइलाइट किया हुआ पाठ](highlighted_text_using_regex.png)

## **पाठ की पृष्ठभूमि रंग निर्धारित करें**

पैराग्राफ की डिफ़ॉल्ट पोर्शन फ़ॉर्मेट का उपयोग करके पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने के लिए [ParagraphFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/) का उपयोग करें, या व्यक्तिगत पाठ पोर्शन के लिए [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) का उपयोग करें।

निम्नलिखित कोड उदाहरण दिखाता है कि **पूरा पैराग्राफ** की पृष्ठभूमि रंग कैसे सेट किया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले पाठ पोर्शन** की पृष्ठभूमि रंग कैसे सेट किया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // टेक्स्ट पोर्शन के लिए हाइलाइट रंग सेट करें।
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![ग्रे टेक्स्ट पोर्शन](gray_text_portions.png)

## **पैराग्राफ को संरेखित करें**

[ParagraphFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/)`::setAlignment` मेथड का उपयोग करके टेक्स्ट फ्रेम के भीतर पैराग्राफ का संरेखण सेट किया जा सकता है। मान केंद्रित, बायें-संतुलित, दायें-संतुलित, उज्ज्वल आदि हो सकते हैं।

निम्नलिखित कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // पैराग्राफ का संरेखण केंद्र में सेट करें।
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **पाठ की पारदर्शिता निर्धारित करें**

पाठ की पारदर्शिता को [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) की फ़िल फ़ॉर्मेट में निर्धारित रंग के एल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0-255 स्केल पर एक ARGB एल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण **पूरा पैराग्राफ** पर पारदर्शिता लागू करने को दर्शाता है:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // पाठ के भरने के रंग को एक पारदर्शी रंग में सेट करें।
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले पाठ पोर्शन** पर पारदर्शिता कैसे लागू की जाए:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // टेक्स्ट पोर्शन की पारदर्शिता सेट करें।
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पारदर्शी टेक्स्ट पोर्शन](transparent_text_portions.png)

## **पाठ के अक्षर अंतराल को निर्धारित करें**

[BasePortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/)`::setSpacing` मेथड का उपयोग करके टेक्स्ट बॉक्स में अक्षर अंतराल को बढ़ाया या घटाया जा सकता है।

निम्न PHP कोड दिखाता है कि **पूरा पैराग्राफ** में अक्षर अंतराल को कैसे बढ़ाया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // अक्षर अंतराल को विस्तारित करें।

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले पाठ पोर्शन** में अक्षर अंतराल को कैसे बढ़ाया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            $portion->getPortionFormat()->setSpacing(3); // अक्षर अंतराल को विस्तारित करें।
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![टेक्स्ट पोर्शन में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए करनिंग निष्क्रिय करें**

किसी-कभी, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए समान पाठ से थोड़ा अधिक कसकर दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए करनिंग डेटा को नजरअंदाज़ कर सकता है, भले ही फ़ॉन्ट में मान्य करनिंग जानकारी हो और PowerPoint सेटिंग्स में करनिंग सक्षम हो।

ऐसे मामलों में रेंडर किया गया आउटपुट PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट के उपयोग वाले पाठ पोर्शन के लिए करनिंग को निष्क्रिय कर सकते हैं। [BasePortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` मेथड को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यह सेटिंग मिलते-जुलते पाठ पोर्शन पर करनिंग को लागू होने से रोकती है और Aspose.Slides रेंडरिंग को PowerPoint की दृश्य आउटपुट के साथ संरेखित करने में सहायता कर सकती है, उन फ़ॉन्ट्स के लिए जिन्हें यह PowerPoint-विशिष्ट व्यवहार प्रभावित करता है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुणों को पैराग्राफ स्तर पर [ParagraphFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/) की डिफ़ॉल्ट पोर्शन फ़ॉर्मेट के माध्यम से या व्यक्तिगत पोर्शन पर [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) के माध्यम से सेट किया जा सकता है।

निम्न कोड पूरे पैराग्राफ के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह फ़ॉन्ट आकार, बोल्ड, इटैलिक, बिंदीदार अंडरलाइन, और Times New Roman फ़ॉन्ट को पैराग्राफ के सभी पोर्शन पर लागू करता है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

नीचे दिया गया कोड उदाहरण समान गुणों को **बोल्ड फ़ॉन्ट वाले टेक्स्ट पोर्शन** पर लागू करता है:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // टेक्स्ट पोर्शन के लिए फ़ॉन्ट गुण सेट करें।
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![टेक्स्ट पोर्शन के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ घूर्णन निर्धारित करें**

[TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` मेथड का उपयोग करके आकृति के भीतर पूर्वनिर्धारित पाठ अभिविन्यास सेट किया जाता है।

निम्न कोड उदाहरण आकृति में पाठ अभिविन्यास को `Vertical270` पर सेट करता है, जो पाठ को **90 डिग्री घड़ी की विपरीत दिशा** में घुमाता है:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पाठ घूर्णन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन निर्धारित करें**

[TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/)`::setRotationAngle` मेथड का उपयोग करके एक [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) के लिए कस्टम घूर्णन कोन सेट किया जाता है।

नीचे दिया गया कोड उदाहरण आकृति के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![कस्टम टेक्स्ट घूर्णन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग निर्धारित करें**

Aspose.Slides [ParagraphFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore`, और `ParagraphFormat::setSpaceWithin` मेथड प्रदान करता है जिससे पैराग्राफ स्पेसिंग को नियंत्रित किया जा सकता है। ये मेथड इस प्रकार उपयोग किए जाते हैं:

* रेखा ऊँचाई का प्रतिशत निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* पॉइंट में रेखा स्पेसिंग निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

निम्न कोड उदाहरण दिखाता है कि पैराग्राफ के भीतर लाइन स्पेसिंग कैसे निर्दिष्ट की जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **टेक्स्ट फ्रेम के लिए ऑटॉफ़िट प्रकार निर्धारित करें**

[TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/)`::setAutofitType` मेथड निर्धारित करता है कि जब पाठ अपने कंटेनर की सीमाओं से अधिक हो जाए तो वह कैसे व्यवहार करता है। इसका उपयोग यह नियंत्रित करने के लिए किया जाता है कि पाठ छोटा हो, ओवरफ़्लो हो, या आकृति को स्वतः पुनः आकार दे।

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **टेक्स्ट फ्रेम के एंकर को निर्धारित करें**

[TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/)`::setAnchoringType` मेथड यह निर्धारित करता है कि आकृति के भीतर पाठ को लंबवत कैसे स्थित किया जाए, जैसे शीर्ष, मध्य या निचले भाग में।

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **टेक्स्ट टैबुलेशन निर्धारित करें**

[ParagraphFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` मेथड और इसकी टैब्स कलेक्शन का उपयोग करके पैराग्राफ में टैब स्टॉप को कॉन्फ़िगर किया जाता है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफिंग भाषा निर्धारित करें**

Aspose.Slides [BasePortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/)`::setLanguageId` मेथड प्रदान करता है, जिससे आप एक टेक्स्ट पोर्शन के लिए प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न कोड उदाहरण दिखाता है कि टेक्स्ट पोर्शन के लिए प्रूफिंग भाषा कैसे सेट की जाए:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // प्रूफिंग भाषा की ID सेट करें।
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **डिफ़ॉल्ट भाषा निर्धारित करें**

[LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` मेथड का उपयोग करके प्रस्तुति लोड या बनाते समय निर्मित टेक्स्ट की डिफ़ॉल्ट भाषा निर्धारित की जा सकती है।

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // टेक्स्ट के साथ एक नया आयताकार आकार जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // पहले पोर्शन की भाषा जांचें।
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट शैली निर्धारित करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए, आप [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) की डिफ़ॉल्ट टेक्स्ट शैली का उपयोग कर सकते हैं।

निम्न कोड उदाहरण दिखाता है कि नई प्रस्तुति में सभी स्लाइड्स के टेक्स्ट के लिए 14 pt आकार के डिफ़ॉल्ट बोल्ड फ़ॉन्ट को कैसे सेट किया जाए।

```php
$presentation = new Presentation();
try {
    // शीर्ष स्तर का पैराग्राफ फ़ॉर्मेट प्राप्त करें।
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **All-Caps इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में, **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा पाठ पोर्शन प्राप्त करते हैं, तो लाइब्रेरी ठीक उसी तरह टेक्स्ट लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textcaptype/) को देखें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदल दें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![All Caps इफ़ेक्ट](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **All Caps** इफ़ेक्ट लागू किए हुए टेक्स्ट को कैसे निकाला जाए:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

आउटपुट:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड पर तालिका में पाठ को कैसे संशोधित करें?**

स्लाइड पर तालिका में पाठ को संशोधित करने के लिए, आप [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/) का उपयोग करें। सेल्स के माध्यम से इटरेट करें और प्रत्येक सेल को [Cell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/) के टेक्स्ट फ्रेम और पैराग्राफ फ़ॉर्मेट के माध्यम से अपडेट करें, तथा [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) के पैराग्राफ फ़ॉर्मेट का उपयोग करें।

**PowerPoint स्लाइड में पाठ पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए, आप [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) की फ़िल फ़ॉर्मेट का उपयोग करें। [FillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) के फ़िल टाइप को [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) `Gradient` पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।