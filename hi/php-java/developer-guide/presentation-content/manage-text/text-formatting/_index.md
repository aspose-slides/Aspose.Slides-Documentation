---
title: PHP में प्रस्तुति टेक्स्ट को फ़ॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/php-java/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर स्पेसिंग
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट रोटेशन
- रोटेशन एंगल
- टेक्स्ट फ़्रेम
- लाइन स्पेसिंग
- ऑटोफ़िट गुण
- टेक्स्ट फ़्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में Aspose.Slides for PHP via Java का उपयोग करके टेक्स्ट को फ़ॉर्मेट और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण आदि को कस्टमाइज़ करें।"
---
## **परिचय**

यह लेख दर्शाता है कि Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को कैसे फ़ॉर्मेट किया जाए। इसमें पृष्ठभूमि रंग, पारदर्शिता, कैरेक्टर स्पेसिंग, फ़ॉन्ट गुण, रोटेशन, पैराग्राफ स्पेसिंग, ऑटोफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप, और भाषा सेटिंग्स शामिल हैं।

नीचे दिए गए उदाहरणों में हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एक टेक्स्ट बॉक्स है जिसमें निम्नलिखित टेक्स्ट है:

![उदाहरण टेक्स्ट](sample_text.png)

लिटरल टेक्स्ट या रेगुलर एक्सप्रेशन मैच को खोजने और हाइलाइट करने के लिए देखें [टेक्स्ट खोजें और बदलें](/slides/hi/php-java/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

पैराग्राफ के लिए डिफ़ॉल्ट हाईलाइट रंग सेट करने के लिए [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#getHighlightColor) का उपयोग करें।

निम्नलिखित कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें।
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![ग्रे टेक्स्ट भाग](gray_text_portions.png)

## **पाठ पैराग्राफ संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setAlignment) का उपयोग करें। मान केंद्रित, बाएँ, दाएँ, जस्टिफ़ाइड आदि हो सकते हैं।

निम्नलिखित कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

## **पाठ के लिए पारदर्शिता सेट करें**

टेक्स्ट की पारदर्शिता [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#getFillFormat) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित की जाती है। नीचे के उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण **पूरे पैराग्राफ** पर पारदर्शिता लागू करने को दर्शाता है:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // टेक्स्ट का फ़िल रंग पारदर्शी रंग में सेट करें।
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर पारदर्शिता लागू करने को दिखाता है:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // टेक्स्ट भाग की पारदर्शिता सेट करें।
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पारदर्शी टेक्स्ट भाग](transparent_text_portions.png)

## **पाठ के लिए कैरेक्टर स्पेसिंग सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच स्पेसिंग को विस्तारित या संकोचन करने के लिए [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setSpacing) का उपयोग करें।

निम्नलिखित PHP कोड दिखाता है कि **पूरे पैराग्राफ** में कैरेक्टर स्पेसिंग कैसे विस्तारित की जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // ध्यान दें: अक्षर स्पेसिंग को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // अक्षर स्पेसिंग विस्तारित करें।

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पैराग्राफ में कैरेक्टर स्पेसिंग](character_spacing_in_paragraph.png)

कोड उदाहरण नीचे दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में कैरेक्टर स्पेसिंग कैसे विस्तारित की जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // नोट: अक्षर स्पेसिंग को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            $portion->getPortionFormat()->setSpacing(3); // अक्षर स्पेसिंग विस्तारित करें।
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![टेक्स्ट भागों में कैरेक्टर स्पेसिंग](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए करनिंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखने वाले समान टेक्स्ट से थोड़ा टाइट लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए करनिंग डेटा को नजरअंदाज कर सकता है, भले ही फ़ॉन्ट में वैध करनिंग जानकारी मौजूद हो और PowerPoint सेटिंग्स में करनिंग सक्षम हो।

ऐसे मामलों में, आप उन टेक्स्ट भागों के लिए करनिंग अक्षम कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग कर रहे हैं। [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

यह सेटिंग मिलते‑जुलते टेक्स्ट भागों पर करनिंग लागू होने से रोकती है और Aspose.Slides की रेंडरिंग को PowerPoint के दृश्य आउटपुट के करीब लाने में मदद करती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) के माध्यम से या व्यक्तिगत भागों के लिए [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) के माध्यम से सेट किया जा सकता है।

निम्न कोड पूरे पैराग्राफ के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह सभी भागों में फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, और Times New Roman फ़ॉन्ट लागू करता है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर समान गुण लागू करता है:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें।
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![टेक्स्ट भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट रोटेशन सेट करें**

[TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करके शैप के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट किया जाता है।

निम्न कोड उदाहरण शैप में टेक्स्ट अभिविन्यास को `Vertical270` पर सेट करता है, जो टेक्स्ट को **90 डिग्री विपरीत दिशा में** घुमाता है:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![टेक्स्ट रोटेशन](text_rotation.png)

## **टेक्स्ट फ्रेम्स के लिए कस्टम रोटेशन सेट करें**

[TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setRotationAngle) का उपयोग करके किसी [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) के लिए कस्टम रोटेशन एंगल सेट किया जाता है।

नीचे दिया गया कोड शैप के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![कस्टम टेक्स्ट रोटेशन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides provides [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setSpaceBefore), and [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setSpaceWithin) to control paragraph spacing. These properties are used as follows:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* लाइन स्पेसिंग को पॉइंट्स में निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

निम्न कोड उदाहरण पैराग्राफ के भीतर लाइन स्पेसिंग कैसे निर्दिष्ट की जाए दिखाता है:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **टेक्स्ट फ्रेम्स के लिए ऑटोफ़िट प्रकार सेट करें**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setAutofitType) निर्धारित करता है कि जब टेक्स्ट अपने कंटेनर की सीमाओं से अधिक हो जाता है तो वह कैसे व्यवहार करता है। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि टेक्स्ट शिंक हो, ओवरफ़्लो हो, या शैप को स्वचालित रूप से री‑साइज़ करे।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **टेक्स्ट फ्रेम्स का एंकर सेट करें**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setAnchoringType) निर्धारित करता है कि टेक्स्ट शैप के भीतर वर्टिकली कैसे स्थित हो, जैसे शीर्ष, मध्य, या नीचे।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **टेक्स्ट टैबुलेशन सेट करें**

[ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) और [ParagraphFormat::getTabs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#getTabs) का उपयोग करके पैराग्राफ में टैब स्टॉप्स को कॉन्फ़िगर किया जाता है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides provides [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId), which allows you to set the proofing language for a text portion. The proofing language determines the language used for spelling and grammar checks in PowerPoint.

निम्न कोड उदाहरण टेक्स्ट भाग के लिए प्रूफ़िंग भाषा सेट करने को दर्शाता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // प्रूफ़िंग भाषा का Id सेट करें।
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करके प्रस्तुति लोड या निर्माण के दौरान निर्मित टेक्स्ट के लिए डिफ़ॉल्ट भाषा परिभाषित की जाती है।

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // पहले भाग की भाषा जाँचें।
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए, [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDefaultTextStyle) का उपयोग करें।

निम्न कोड उदाहरण नई प्रस्तुति में सभी स्लाइड्स के टेक्स्ट के लिए 14 pt आकार के बोल्ड फ़ॉन्ट को डिफ़ॉल्ट रूप से सेट करता है।

```php
$presentation = new Presentation();
try {
    // शीर्ष स्तर के पैराग्राफ फ़ॉर्मेट को प्राप्त करें।
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

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides से ऐसे टेक्स्ट भाग को प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को उसी रूप में लौटाती है जैसे वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textcaptype/) देखें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में बदलें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्न टेक्स्ट बॉक्स है।

![ऑल‑कैप्स इफ़ेक्ट](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण **ऑल‑कैप्स** इफ़ेक्ट लागू किए हुए टेक्स्ट को निकालने को दर्शाता है:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
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

**स्लाइड में तालिका के टेक्स्ट को कैसे संशोधित करें?**

स्लाइड में तालिका के टेक्स्ट को संशोधित करने के लिए [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/) का उपयोग करें। सेल्स के माध्यम से इटरेट करें और प्रत्येक सेल को [Cell::getTextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/#getTextFrame) और पैराग्राफ फ़ॉर्मेटिंग को [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getParagraphFormat) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#getFillFormat) का उपयोग करें। [FillFormat::setFillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/#setFillType) को [FillType::Gradient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।