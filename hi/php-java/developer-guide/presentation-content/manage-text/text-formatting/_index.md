---
title: "PHP में प्रस्तुति टेक्स्ट को फ़ॉर्मेट करें"
linktitle: "टेक्स्ट फ़ॉर्मेटिंग"
type: docs
weight: 50
url: /hi/php-java/text-formatting/
keywords:
- "पैराग्राफ संरेखित करें"
- "टेक्स्ट शैली"
- "टेक्स्ट पृष्ठभूमि"
- "टेक्स्ट पारदर्शिता"
- "अक्षर अंतराल"
- "फ़ॉन्ट प्रॉपर्टीज़"
- "फ़ॉन्ट परिवार"
- "टेक्स्ट रोटेशन"
- "रोटेशन एंगल"
- "टेक्स्ट फ्रेम"
- "लाइन स्पेसिंग"
- "ऑटोफ़िट प्रॉपर्टी"
- "टेक्स्ट फ्रेम एंकर"
- "टेक्स्ट टैबुलेशन"
- "डिफ़ॉल्ट भाषा"
- PowerPoint
- OpenDocument
- "प्रस्तुति"
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण आदि को कस्टमाइज़ करें।"
---
## **Overview**

यह लेख Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट करने का तरीका दिखाता है। यह बैकग्राउंड रंग, ट्रांसपरेंसी, कैरेक्टर स्पेसिंग, फ़ॉन्ट प्रॉपर्टीज़, रोटेशन, पैराग्राफ स्पेसिंग, ऑटोफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप्स और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा नहीं बताया गया है, उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। उसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए टेक्स्ट को सम्मिलित करता है। स्लाइड और आकार दोनों के इंडेक्स शून्य‑आधारित हैं। वे उदाहरण जो बोल्ड भागों को चुनते हैं प्रभावी फ़ॉर्मेटिंग का उपयोग करते हैं, जिसमें वंशागत बोल्ड फ़ॉर्मेटिंग भी शामिल है:

![नमूना पाठ](sample_text.png)

शाब्दिक टेक्स्ट या रेगुलर एक्सप्रेशन मैच को खोजने और हाइलाइट करने के लिए, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/php-java/search-and-replace-text/)।

## **टेक्स्ट बैकग्राउंड रंग सेट करें**

एक पैराग्राफ के लिए डिफ़ॉल्ट हाईलाइट रंग सेट करने हेतु [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#getHighlightColor) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए लाइट ग्रे हाईलाइट को डिफ़ॉल्ट के रूप में सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाईलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए बैकग्राउंड रंग कैसे सेट करें:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

## **टेक्स्ट पैराग्राफ संरेखित करें**

टेक्स्ट फ़्रेम के भीतर पैराग्राफ का संरेखण सेट करने के लिए [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setAlignment) का उपयोग करें। मान केंद्रित, बाएँ‑संरेखित, दाएँ‑संरेखित, जस्टिफ़ाइड आदि हो सकते हैं।

निम्न कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाये:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

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

## **टेक्स्ट के लिए ट्रांसपेरेन्सी सेट करें**

टेक्स्ट की ट्रांसपेरेन्सी को [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#getFillFormat) को असाइन किए गए रंग के अल्फा घटक से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0‑255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि प्रतिशत।

नीचे दिया गया कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर ट्रांसपेरेन्सी कैसे लागू की जाए:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर ट्रांसपेरेन्सी कैसे लागू की जाए:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

## **टेक्स्ट के लिए कैरेक्टर स्पेसिंग सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच स्पेसिंग को बढ़ाने या घटाने के लिए [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setSpacing) का उपयोग करें। उदाहरण 3 पॉइंट की स्पेसिंग जोड़ते हैं; नकारात्मक मान टेक्स्ट को कसे हुए बनाते हैं।

निम्न PHP कोड दिखाता है कि **पूरे पैराग्राफ** में कैरेक्टर स्पेसिंग को कैसे बढ़ाया जाए:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // अक्षर अंतराल बढ़ाएँ।

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पैराग्राफ में कैरेक्टर स्पेसिंग](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में कैरेक्टर स्पेसिंग को कैसे बढ़ाया जाए:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            $portion->getPortionFormat()->setSpacing(3); // अक्षर अंतराल बढ़ाएँ।
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![टेक्स्ट भागों में कैरेक्टर स्पेसिंग](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए समान टेक्स्ट से थोड़ा टाइट लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को नजरअंदाज कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर आउटपुट को PowerPoint के करीब लाने के लिए, आप उन टेक्स्ट भागों के लिए केरनिंग निष्क्रिय कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। यह उदाहरण पहले स्लाइड की पहली शैप में एक टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता रखता है। यह प्रभावी फ़ॉन्ट नामों, जिसमें वंशागत फ़ॉन्ट भी शामिल हैं, की जाँच करता है, और Roboto का उपयोग करने वाले भागों के लिए 100 पॉइंट थ्रेशोल्ड सेट करता है। यह 100 पॉइंट से कम फ़ॉन्ट आकार वाले मेल खाते भागों के लिए केरनिंग निष्क्रिय करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

थ्रेशोल्ड से नीचे के मेल खाते टेक्स्ट के लिए, यह सेटिंग केरनिंग को रोकती है और ऐसे फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट प्रॉपर्टीज़ प्रबंधित करें**

फ़ॉन्ट प्रॉपर्टीज़ को पैराग्राफ स्तर पर [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) के माध्यम से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) के माध्यम से सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman सेट करता है जिसमें बोल्ड, इटैलिक और डॉटेड अंडरलाइन फ़ॉर्मेटिंग है। व्यक्तिगत भागों पर स्पष्ट फ़ॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता लेती है:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // पैराग्राफ के लिए फ़ॉन्ट प्रॉपर्टी सेट करें।
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

![पैराग्राफ के फ़ॉन्ट प्रॉपर्टीज़](font_properties_for_paragraph.png)

निम्न उदाहरण उन भागों पर 13‑पॉइंट Times New Roman, इटैलिक फ़ॉर्मेटिंग, और डॉटेड अंडरलाइन लागू करता है जिनकी प्रभावी फ़ॉर्मेटिंग बोल्ड है:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // टेक्स्ट भाग के लिए फ़ॉन्ट प्रॉपर्टी सेट करें।
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

![टेक्स्ट भागों के फ़ॉन्ट प्रॉपर्टीज़](font_properties_for_text_portions.png)

## **टेक्स्ट रोटेशन सेट करें**

शैप के भीतर एक पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करें।

निम्न कोड उदाहरण शैप में टेक्स्ट अभिविन्यास को [TextVerticalType::Vertical270](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textverticaltype/) पर सेट करता है, जिससे टेक्स्ट **90 डिग्री विपरीत दिशा में** घुमाया जाता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

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

[TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setRotationAngle) का उपयोग करके एक [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) के लिए कस्टम रोटेशन एंगल सेट करें।

नीचे दिया गया कोड उदाहरण शैप के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइज़ घुमाता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

Aspose.Slides पैराग्राफ स्पेसिंग को नियंत्रित करने के लिए [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setSpaceBefore) और [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/#setSpaceWithin) प्रदान करता है। इन प्रॉपर्टीज़ का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के भीतर स्पेसिंग को लाइन की ऊँचाई के 200% (डबल स्पेसिंग) पर सेट करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **लाइन ब्रेकिंग नियंत्रित करें**

नैरो टेक्स्ट ब्लॉक्स और लैटिन तथा ईस्ट एशियन टेक्स्ट मिश्रित प्रस्तुतियों में पैराग्राफ लाइन‑ब्रेकिंग नियम उपयोगी होते हैं। निम्न मेथड्स [ParagraphFormat] से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [setLatinLineBreak] लैटिन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से निकट के ईस्ट एशियन टेक्स्ट और विराम चिह्नों के रैप स्थान भी बदल सकते हैं।
- [setEastAsianLineBreak] ईस्ट एशियन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों की प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/#setWrapText) को प्रतिस्थापित नहीं करते; वे रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक कैरेक्टर नहीं डालते। एक स्पष्ट लाइन ब्रेक उपलब्ध चौड़ाई से स्वतंत्र होकर पैराग्राफ में नई लाइन बनाता है।

निम्न स्वनिर्भर उदाहरण चीनी और लैटिन टेक्स्ट वाला एक संकीर्ण टेक्स्ट ब्लॉक बनाता है। यह दोनों लाइन‑ब्रेकिंग विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" को सेव करता है। किसी भी नियम का प्रयोग करने के लिए, संबंधित मान को बदलें जबकि अन्य सेटिंग्स को स्थिर रखें। उदाहरण 24‑पॉइंट Arial और SimSun का उपयोग 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ करता है। [TextFrameFormat::setAutofitType] को [TextAutofitType::None] के साथ बुलाया जाता है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **हैंगिंग पंचुएशन नियंत्रित करें**

[ParagraphFormat::setHangingPunctuation] योग्य पंचुएशन को टेक्स्ट लाइन के दाएँ किनारे से आगे विस्तार करने देता है, बजाय अगले लाइन में जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्वनिर्भर उदाहरण 100‑पॉइंट चौड़े टेक्स्ट फ्रेम में हैंगिंग पंचुएशन को सक्षम करता है और "hanging_punctuation.pptx" को सेव करता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से आगे बढ़ता है। तुलना के लिए प्रॉपर्टी को [NullableBool::False] सेट करें: इन सेटिंग्स के साथ बिंदु एक अलग लाइन लेता है। रैपिंग सक्षम है और ऑटोफ़िट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

हर पंचुएशन मार्क हैंग नहीं हो सकता। दृश्य परिणाम फ़ॉन्ट उपलब्धता और लेआउट पर निर्भर करता है: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफ़िट सेटिंग्स बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ्रेम्स के लिए ऑटोफ़िट टाइप सेट करें**

[TextFrameFormat::setAutofitType] निर्धारित करता है कि कंटेनर की सीमाओं से अधिक टेक्स्ट का व्यवहार कैसे हो। इसे उपयोग करके आप तय कर सकते हैं कि टेक्स्ट सिकुड़े, ओवरफ़्लो हो, या शैप स्वतः रीसाइज़ हो। निम्न उदाहरण शैप को उसके टेक्स्ट के फिट होने के लिए रीसाइज़ करने के लिए कॉन्फ़िगर करता है और परिणाम को "autofit_type.pptx" में सेव करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

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

स्वचालित रैपिंग के बाद लाइनों की गिनती करने और यह देखने के लिए कि टेक्स्ट या शैप चौड़ाई परिणाम को कैसे बदलती है, देखें [रेंडर्ड लाइन्स गिनें](/slides/hi/php-java/manage-paragraph/). केवल लाइनों की संख्या यह नहीं दर्शाती कि टेक्स्ट कंटेनर से ओवरफ़्लो हो रहा है या नहीं।

## **टेक्स्ट फ्रेम्स का एंकर सेट करें**

[TextFrameFormat::setAnchoringType] परिभाषित करता है कि टेक्स्ट को शैप के अंदर लंबवत कैसे स्थित किया जाए, जैसे ऊपर, मध्य या नीचे। निम्न उदाहरण टेक्स्ट को पहले शैप के नीचे एंकर करता है और परिणाम को "text_anchor.pptx" में सेव करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

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

[ParagraphFormat::setDefaultTabSize] और [ParagraphFormat::getTabs] का उपयोग करके पैराग्राफ में टैब स्टॉप्स को कॉन्फ़िगर करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट सेट करता है और 30 पॉइंट पर बाएं संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

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

Aspose.Slides [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId) प्रदान करता है, जो टेक्स्ट भाग के लिए प्रूफ़िंग भाषा सेट करने दे सकता है। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न उदाहरण को "presentation.pptx" की आवश्यकता है जिसमें पहली स्लाइड पर एक टेक्स्ट बॉक्स और कम से कम एक पैराग्राफ हो। यह पहले पैराग्राफ की सामग्री को "1。" से प्रतिस्थापित करता है, फ़ॉन्ट को SimSun सेट करता है, और प्रूफ़िंग भाषा के रूप में Simplified Chinese (`zh-CN`) असाइन करता है। परिणाम को "proofing_language.pptx" में सेव करता है:

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

लोडिंग या प्रस्तुति बनाते समय बनाए गए टेक्स्ट के लिए डिफ़ॉल्ट भाषा निर्धारित करने हेतु [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करें। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के साथ एक प्रस्तुति बनाता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिए `en-US` प्रिंट करता है।

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // नया आयताकार शैप टेक्स्ट के साथ जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // पहले भाग की भाषा जांचें।
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रेजेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए, [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDefaultTextStyle) का उपयोग करें।

निम्न उदाहरण एक नई प्रस्तुति में टॉप‑लेवल पैराग्राफ़ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट सेट करता है और इसे "default_text_style.pptx" में सेव करता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **All-Caps प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। Aspose.Slides के साथ ऐसे टेक्स्ट भाग को पुनः प्राप्त करने पर, लाइब्रेरी टेक्स्ट को बिल्कुल उसी रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textcaptype/) जांचें और जब मान `All` हो तो लौटाई गई स्ट्रिंग को बड़े अक्षरों में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। उसके पहले पैराग्राफ के पहले भाग में "Hello, Aspose!" है, जिस पर All Caps प्रभाव लागू है, जैसा कि नीचे दिखाया गया है।

![All Caps प्रभाव](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू टेक्स्ट को कैसे निकाला जाए:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

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

## **FAQ**

**मैं स्लाइड पर टेबल के टेक्स्ट को कैसे संशोधित करूँ?**

स्लाइड पर टेबल के टेक्स्ट को संशोधित करने के लिए, [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/) का उपयोग करें। सेल्स पर इटरेशन करें और प्रत्येक सेल को [Cell::getTextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/#getTextFrame) और पैराग्राफ फ़ॉर्मेटिंग को [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/#getParagraphFormat) के माध्यम से अपडेट करें।

**मैं PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए, [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#getFillFormat) का उपयोग करें। [FillFormat::setFillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/#setFillType) को [FillType::Gradient](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा, तथा ट्रांसपेरेन्सी को कॉन्फ़िगर करें।