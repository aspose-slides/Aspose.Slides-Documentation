---
title: "PHP में प्रस्तुति टेक्स्ट को फॉर्मेट करें"
linktitle: "टेक्स्ट फ़ॉर्मेटिंग"
type: docs
weight: 50
url: /hi/php-java/text-formatting/
keywords:
- "पैराग्राफ संरेखित"
- "टेक्स्ट शैली"
- "टेक्स्ट पृष्ठभूमि"
- "टेक्स्ट पारदर्शिता"
- "अक्षर अंतराल"
- "फ़ॉन्ट गुण"
- "फ़ॉन्ट परिवार"
- "टेक्स्ट घूर्णन"
- "घूर्णन कोण"
- "टेक्स्ट फ्रेम"
- "लाइन स्पेसिंग"
- "ऑटोफ़िट गुण"
- "टेक्स्ट फ्रेम एंकर"
- "टेक्स्ट टैबुलेशन"
- "डिफ़ॉल्ट भाषा"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को कस्टमाइज़ करें।"
---
## **अवलोकन**

यह लेख PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट करने के तरीके को Aspose.Slides for PHP via Java का उपयोग करके दर्शाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटोफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

नीचे के उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें प्रथम स्लाइड पर एक ही टेक्स्ट बॉक्स है जिसमें निम्नलिखित टेक्स्ट है:

![नमूना टेक्स्ट](sample_text.png)

टेक्स्ट खोजें और बदलें](/slides/hi/php-java/search-and-replace-text/).

## **टेक्स्ट पृष्ठभूमि रंग सेट करें**

पैराग्राफ के लिए डिफ़ॉल्ट हाईलाइट रंग सेट करने हेतु [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) का उपयोग करें, या व्यक्तिगत टेक्स्ट हिस्सों के लिए [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#getHighlightColor) का उपयोग करें।

निम्नलिखित कोड उदाहरण दिखाता है कि **पूरा पैराग्राफ** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

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

![धूसर पैराग्राफ](gray_paragraph.png)

निम्नलिखित कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

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
            // टेक्स्ट हिस्से के लिए हाइलाइट रंग सेट करें।
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![धूसर टेक्स्ट हिस्से](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ को संरेखित करें**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setAlignment) का उपयोग करके टेक्स्ट फ़्रेम के भीतर पैराग्राफ का संरेखण सेट करें। मान केंद्रित, बाएँ-संरेखित, दाएँ-संरेखित, न्यायसंगत आदि हो सकता है।

निम्नलिखित कोड उदाहरण दिखाता है कि पैराग्राफ को **केन्द्र** में कैसे संरेखित किया जाए:

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

## **टेक्स्ट के लिए पारदर्शिता सेट करें**

टेक्स्ट पारदर्शिता को [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#getFillFormat) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

निम्नलिखित कोड उदाहरण दिखाता है कि **पूरा पैराग्राफ** पर पारदर्शिता कैसे लागू की जाए:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // टेक्स्ट के फ़िल रंग को पारदर्शी रंग पर सेट करें।
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

निम्नलिखित कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** पर पारदर्शिता कैसे लागू की जाए:

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
            // टेक्स्ट हिस्से की पारदर्शिता सेट करें।
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

![पारदर्शी टेक्स्ट हिस्से](transparent_text_portions.png)

## **टेक्स्ट के लिए कैरेक्टर स्पेसिंग सेट करें**

[BasePortionFormat::setSpacing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setSpacing) का उपयोग करके टेक्स्ट बॉक्स में अक्षरों के बीच स्पेसिंग को विस्तारित या घटाया जा सकता है।

निम्नलिखित PHP कोड दिखाता है कि **पूरा पैराग्राफ** में कैरेक्टर स्पेसिंग को कैसे विस्तारित किया जाए:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // अक्षर अंतराल बढ़ाएँ।

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

निम्नलिखित कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** में अक्षर अंतराल को कैसे विस्तारित किया जाए:

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
            // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            $portion->getPortionFormat()->setSpacing(3); // अक्षर अंतराल बढ़ाएँ।
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![टेक्स्ट हिस्सों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए केरनिंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए समान टेक्स्ट की तुलना में थोड़ा टाइट लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर देता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर किया गया आउटपुट PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले टेक्स्ट हिस्सों के लिए केरनिंग को निष्क्रिय कर सकते हैं। [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) को वास्तविक फ़ॉन्ट आकार से काफी बड़ी मान पर सेट करें:

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

यह सेटिंग मेल खाने वाले टेक्स्ट हिस्सों पर केरनिंग लागू होने से रोकती है और इस PowerPoint-विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) के माध्यम से या व्यक्तिगत हिस्सों पर [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्नलिखित कोड पूरे पैराग्राफ के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, तथा Times New Roman फ़ॉन्ट को पैराग्राफ के सभी हिस्सों पर लागू करता है।

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

![पैराग्राफ के लिए फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्नलिखित कोड उदाहरण समान गुणों को **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** पर लागू करता है:

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
            // टेक्स्ट हिस्से के लिए फ़ॉन्ट गुण सेट करें।
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

![टेक्स्ट हिस्सों के लिए फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट घूर्णन सेट करें**

[TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करके आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करें।

निम्नलिखित कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को `Vertical270` पर सेट करता है, जो टेक्स्ट को **घड़ी की सूइयों के विपरीत 90 डिग्री** घुमाता है:

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

![टेक्स्ट घूर्णन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setRotationAngle) का उपयोग करके एक [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) के लिए कस्टम घूर्णन कोण सेट करें।

निम्नलिखित कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइज़ घुमाता है:

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

![कस्टम टेक्स्ट घूर्णन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setSpaceBefore), और [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setSpaceWithin) प्रदान करता है जिससे पैराग्राफ स्पेसिंग को नियंत्रित किया जा सकता है। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* लाइन स्पेसिंग को पॉइंट्स में निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

निम्नलिखित कोड उदाहरण दिखाता है कि पैराग्राफ के भीतर लाइन स्पेसिंग कैसे निर्दिष्ट की जाए:

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

## **टेक्स्ट फ्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setAutofitType) निर्धारित करता है कि जब टेक्स्ट अपने कंटेनर की सीमाओं से अधिक हो जाए तो वह कैसे व्यवहार करता है। इसका उपयोग यह नियंत्रित करने के लिए करें कि टेक्स्ट सिकुड़ता है, ओवरफ़्लो होता है, या आकार को स्वचालित रूप से पुनः आकार देता है।

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

ऑटोमैटिक रैपिंग के बाद लाइनों की गिनती करने और देखेंगे कि टेक्स्ट या आकार की चौड़ाई बदलने से परिणाम कैसे बदलता है, इसके लिए देखें [रेंडर किए गए लाइनों की गिनती](/slides/hi/php-java/manage-paragraph/). केवल लाइन गिनती यह संकेत नहीं देती कि टेक्स्ट कंटेनर को ओवरफ़्लो कर रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setAnchoringType) यह परिभाषित करता है कि टेक्स्ट को आकार के भीतर लंबवत कैसे स्थित किया जाए, उदाहरण के लिए शीर्ष, मध्य, या नीचे पर।

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

एक पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) और [ParagraphFormat::getTabs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#getTabs) का उपयोग करें।

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

![पैराग्राफ टैब](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId) प्रदान करता है, जो आपको टेक्स्ट हिस्से के लिए प्रूफ़िंग भाषा सेट करने की अनुमति देता है। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिए उपयोग की जाने वाली भाषा को निर्धारित करती है।

निम्नलिखित कोड उदाहरण दिखाता है कि टेक्स्ट हिस्से के लिए प्रूफ़िंग भाषा कैसे सेट की जाए:

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

लोड या प्रस्तुति बनाते समय निर्मित टेक्स्ट के लिए डिफ़ॉल्ट भाषा को परिभाषित करने हेतु [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करें।

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // पहले हिस्से की भाषा जाँचें।
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रेजेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए, [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDefaultTextStyle) का उपयोग करें।

निम्नलिखित कोड उदाहरण दिखाता है कि नई प्रस्तुति में सभी स्लाइड्स के सभी टेक्स्ट के लिए 14 पॉइंट आकार के डिफ़ॉल्ट बोल्ड फ़ॉन्ट को कैसे सेट किया जाए।

```php
$presentation = new Presentation();
try {
    // शीर्ष स्तर पैराग्राफ फ़ॉर्मेट प्राप्त करें।
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

## **All-Caps प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखाई देता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसे टेक्स्ट हिस्से को प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को ठीक उसी रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल कराने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textcaptype/) जांचें और जब मान `All` हो तो लौटाई गई स्ट्रिंग को बड़े अक्षरों में परिवर्तित करें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![All Caps प्रभाव](all_caps_effect.png)

निम्नलिखित कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू टेक्स्ट को कैसे निकाला जाए:

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

**स्लाइड पर तालिका में टेक्स्ट को कैसे संशोधित करें?**

स्लाइड पर तालिका में टेक्स्ट को संशोधित करने के लिए, [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करके प्रत्येक सेल को [Cell::getTextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/#getTextFrame) के माध्यम से अपडेट करें और पैराग्राफ फ़ॉर्मेटिंग को [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getParagraphFormat) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करें?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए, [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#getFillFormat) का उपयोग करें। [FillFormat::setFillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/#setFillType) को [FillType::Gradient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।