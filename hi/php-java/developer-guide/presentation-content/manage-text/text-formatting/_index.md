---
title: PHP में प्रस्तुति पाठ को स्वरूपित करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/php-java/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घूर्णन
- घूर्णन कोण
- टेक्स्ट फ्रेम
- लाइन अंतराल
- ऑटोफिट प्रॉपर्टी
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में Aspose.Slides for PHP via Java का उपयोग करके पाठ को फ़ॉर्मेट और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को कैसे फॉर्मेट करें। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, अनुच्छेद अंतराल, ऑटोफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप, और भाषा सेटिंग्स को कवर करता है।

जब तक अलग नहीं कहा गया हो, उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। उसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए टेक्स्ट को रखता है। स्लाइड और आकार दोनों की सूचकांक शून्य‑आधारित हैं। उन उदाहरणों में जो बोल्ड भागों का चयन करते हैं, प्रभावी फॉर्मेटिंग का उपयोग किया जाता है, जिसमें विरासत में मिले बोल्ड फॉर्मेटिंग भी शामिल है:

![Sample text](sample_text.png)

सही टेक्स्ट या रेगुलर‑एक्सप्रेशन मिलान को खोजने और हाइलाइट करने के लिए देखें [टेक्स्ट खोजें और बदलें](/slides/hi/php-java/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

डिफ़ॉल्ट हाइलाइट रंग सेट करने के लिए [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए हल्के ग्रे हाइलाइट को डिफ़ॉल्ट के रूप में सेट करता है। व्यक्तिगत भागों में स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

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

![The gray paragraph](gray_paragraph.png)

निम्नलिखित कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए पृष्ठभूमि रंग कैसे सेट करें:

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

![The gray text portions](gray_text_portions.png)

## **पाठ अनुच्छेदों को संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) का उपयोग करें। मान को केन्द्रित, बाएँ‑समान, दाएँ‑समान, समरूप आदि हो सकता है।

निम्न कोड उदाहरण पैराग्राफ को **केन्द्र** में संरेखित करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // पैराग्राफ की संरेखण को मध्य में सेट करें।
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The aligned paragraph](aligned_paragraph.png)

## **एक पंक्ति में फ़ॉन्ट संरेखित करें**

एक पंक्ति में विभिन्न फ़ॉन्ट आकार वाले टेक्स्ट भागों को लंबवत संरेखित करने के लिए [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) का प्रयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक पंक्तियों में संरेखण को नियंत्रित करती है।

निम्न स्वतंत्र उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36, और 54 पॉइंट के समान टेक्स्ट होते हैं, लेकिन फ़ॉन्ट संरेखण अलग‑अलग है। यह Arial का उपयोग करता है, ऑटोफिट और रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ्रेम को एक पंक्ति के लिये पर्याप्त बड़ा रखता है।

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स पर आधारित है, इसलिए व्यक्तिगत अक्षरों के दृश्यमान किनारे बिल्कुल सटीक नहीं हो सकते। उदाहरण में बड़े अक्षर और एक नीचे की ओर गिरने वाला अक्षर शामिल है जिससे बेसलाइन और नीचे संरेखण का अंतर स्पष्ट हो। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, प्रयुक्त अक्षर, और फ़ॉन्ट आकार में अंतर परिणाम को प्रभावित करता है। फ्रेम आकार, मार्जिन, पंक्तिक अंतर, रैपिंग, और ऑटोफिट भी लेआउट को प्रभावित करते हैं; तुलना के लिये वही फ़ॉन्ट और लेआउट सेटिंग्स उपयोग करें।

यह सेटिंग [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) से अलग है, जो आयताकार पैराग्राफ संरेखण को नियंत्रित करता है, तथा [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) से भी, जो आकार के भीतर टेक्स्ट ब्लॉक को लंबवत स्थित करता है। [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) द्वारा सुपरस्क्रिप्ट और सबस्क्रिप्ट फॉर्मेटिंग व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करती है, न कि पैराग्राफ की पंक्तियों के फ़ॉन्ट संरेखण को सेट करती है।

## **टेक्स्ट की पारदर्शिता सेट करें**

टेक्स्ट की पारदर्शिता को [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` 0‑255 स्केल पर ARGB अल्फा‑चैनल मान है, न कि पारदर्शी प्रतिशत।

निम्न कोड उदाहरण पूरे पैराग्राफ पर पारदर्शिता लागू करता है:

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

    // पाठ के भरने का रंग पारदर्शी रंग में सेट करें।
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![The transparent paragraph](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर पारदर्शिता लागू करता है:

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

![The transparent text portions](transparent_text_portions.png)

## **टेक्स्ट के लिए अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच के अंतर को बढ़ाने या घटाने के लिये [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) का उपयोग करें। उदाहरण 3 पॉइंट अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकुचित करते हैं।

निम्न PHP कोड पूरे पैराग्राफ में अक्षर अंतराल बढ़ाता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल बढ़ाता है:

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

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिये कर्निंग निष्क्रिय करें**

कभी‑कभी Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखने वाले टेक्स्ट से थोड़ा अधिक सघन दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिये कर्निंग डेटा को अनदेखा कर देता है, भले ही फ़ॉन्ट में वैध कर्निंग जानकारी हो और PowerPoint सेटिंग्स में कर्निंग सक्षम हो।

ऐसे मामलों में, आप उन टेक्स्ट भागों के लिये कर्निंग निष्क्रिय कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। यह उदाहरण पहली स्लाइड के पहले आकार पर टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता रखता है। यह प्रभावी फ़ॉन्ट नामों को जाँचता है, विरासत में मिले फ़ॉन्ट सहित, और Roboto प्रयोग करने वाले भागों के लिये 100‑पॉइंट थ्रेसहोल्ड सेट करता है। इस थ्रेसहोल्ड से नीचे के भागों के लिये कर्निंग निष्क्रिय हो जाता है:

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

इस सेटिंग से थ्रेसहोल्ड से नीचे के टेक्स्ट में कर्निंग नहीं होगा और इस प्रकार PowerPoint‑विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट्स के लिये Aspose.Slides के रेंडरिंग को PowerPoint के दृश्य आउटपुट के करीब लाने में मदद मिलती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) के माध्यम से पैराग्राफ स्तर पर या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक, और डॉटेड अंडरलाइन के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट फॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता लेती है:

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

    // पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें.
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

![The font properties for the paragraph](font_properties_for_paragraph.png)

निम्न उदाहरण 13‑पॉइंट Times New Roman, इटैलिक, और डॉटेड अंडरलाइन को उन भागों पर लागू करता है जिनकी प्रभावी फॉर्मेटिंग बोल्ड है:

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

![The font properties for text portions](font_properties_for_text_portions.png)

## **टेक्स्ट घूर्णन सेट करें**

[TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करके आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट किया जा सकता है।

निम्न कोड उदाहरण टेक्स्ट अभिविन्यास को [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री घड़ी की दिशा के विपरीत** घुमा देता है:

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

![The text rotation](text_rotation.png)

## **टेक्स्ट फ्रेम के लिये कस्टम घूर्णन सेट करें**

[TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) का उपयोग करके किसी [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) के लिये कस्टम घूर्णन कोण सेट किया जा सकता है।

निम्न कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमा देता है:

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

![The custom text rotation](custom_text_rotation.png)

## **पैराग्राफ की पंक्ति अंतराल सेट करें**

Aspose.Slides निम्न प्रॉपर्टीज़ प्रदान करता है: [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore), और [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) ताकि पैराग्राफ अंतराल को नियंत्रित किया जा सके। इनका उपयोग इस प्रकार है:

* लाइन अंतराल को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिये सकारात्मक मान उपयोग करें।
* लाइन अंतराल को पॉइंट में निर्दिष्ट करने के लिये नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहली पैराग्राफ के भीतर अंतराल को लाइन ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

![The line spacing within the paragraph](line_spacing.png)

## **पंक्ति विभाजन नियंत्रित करें**

पैराग्राफ पंक्ति‑भंग नियम संकीर्ण टेक्स्ट ब्लॉकों और लैटिन व पूर्वी एशियाई टेक्स्ट के मिश्रण वाले प्रस्तुतियों में उपयोगी होते हैं। निम्न मेथड्स [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) लैटिन पंक्ति‑भंग नियम को नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से निकटवर्ती पूर्वी एशियाई टेक्स्ट और विराम चिह्न के रैपिंग स्थान भी बदल सकता है।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) पूर्वी एशियाई पंक्ति‑भंग नियम को नियंत्रित करता है, जिसमें पंक्ति की शुरुआत व अंत में अक्षर प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। वे रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे पंक्ति‑भंग अक्षर नहीं डालते। एक स्पष्ट पंक्ति‑भंग नया लाइन बनाता है, उपलब्ध चौड़ाई से स्वतंत्र।

निम्न स्वतंत्र उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चीनी व लैटिन टेक्स्ट दोनों हैं। यह दोनों पंक्ति‑भंग विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। प्रत्येक नियम को प्रयोग करने के लिये, दूसरे सेटिंग को स्थिर रखते हुए संबंधित मान को बदलें। उदाहरण 24‑पॉइंट Arial व SimSun का उपयोग करता है, 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ। [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) को [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) के साथ कॉल किया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

## **हैंगिंग विराम चिह्न नियंत्रित करें**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) योग्य विराम चिह्न को टेक्स्ट लाइन के दाहिने किनारे से आगे विस्तारित करने देता है, बजाय अगले लाइन में स्थित होने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्वतंत्र उदाहरण 100‑पॉइंट‑चौड़े टेक्स्ट फ्रेम में हैंगिंग विराम चिह्न को सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial एवं शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर निकल जाता है। तुलना के लिये गुण को [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ बिंदु एक अलग लाइन पर दिखेगा। रैपिंग सक्षम है और ऑटोफिट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न हैंग नहीं कर सकता। ऊपर वर्णित [फ़ॉन्ट व लेआउट शर्तें](#control-line-breaking) भी इस तुलना पर लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन, या ऑटोफिट सेटिंग बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिये ऑटोफिट प्रकार सेट करें**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमा से बाहर निकलने पर कैसे व्यवहार करता है। इसका प्रयोग करके आप तय कर सकते हैं कि टेक्स्ट घटे, ओवरफ़्लो हो या आकार को स्वतः पुनःआकारित करे। निम्न उदाहरण आकार को उसके टेक्स्ट के अनुसार पुनःआकारित करता है और परिणाम "autofit_type.pptx" में सहेजता है।

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

स्वचालित रैपिंग के बाद लाइनों की गणना करने और देखना चाहते हैं कि टेक्स्ट या आकार की चौड़ाई परिणाम को कैसे बदलती है, तो देखें [Count Rendered Lines](/slides/hi/php-java/manage-paragraph/)। लाइनों की गिनती केवल यह दर्शाती नहीं कि टेक्स्ट कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ्रेम की एंकर सेट करें**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) परिभाषित करता है कि आकार के भीतर टेक्स्ट को लंबवत कैसे स्थित किया जाता है, उदाहरण के लिये शीर्ष, मध्य या नीचे। निम्न उदाहरण टेक्स्ट को पहले आकार के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

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

पराग्राफ में टैब स्टॉप को कॉन्फ़िगर करने के लिये [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) और [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑समान टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

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

![The paragraph tabs](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) प्रदान करता है, जिससे आप टेक्स्ट भाग की प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा PowerPoint में वर्तनी व व्याकरण जाँच हेतु प्रयुक्त भाषा निर्धारित करती है।

निम्न उदाहरण को "presentation.pptx" की आवश्यकता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है और कम से कम एक पैराग्राफ है। यह पहला पैराग्राफ "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और प्रूफिंग भाषा के रूप में सरलित चीनी (`zh-CN`) असाइन करता है। परिणाम "proofing_language.pptx" में सहेजा जाता है:

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

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करके प्रस्तुति लोड या बनाते समय बनाए जाने वाले टेक्स्ट की डिफ़ॉल्ट भाषा निर्धारित करें। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिये `en-US` प्रिंट करता है।

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // पहले भाग की भाषा जांचें।
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फॉर्मेटिंग लागू करने के लिये [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle) का प्रयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर के पैराग्राफ के लिये 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट के रूप में सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फॉर्मेटिंग उन्हें ओवरराइड न कर दे।

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // शीर्ष स्तर के पैराग्राफ स्वरूप प्राप्त करें।
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

## **ऑल‑कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही इसे छोटे अक्षरों में टाइप किया गया हो। Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करने पर लाइब्रेरी टेक्स्ट को उसी रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मिलाने के लिये, [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) को जांचें और यदि मान `All` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। उसके पहले पैराग्राफ के पहले भाग में "Hello, Aspose!" है, जिस पर All Caps प्रभाव लागू किया गया है, जैसा कि नीचे दिखाया गया है।

![The All Caps effect](all_caps_effect.png)

निम्न कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू किए हुए टेक्स्ट को कैसे निकालें:

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

**मैं स्लाइड पर तालिका में टेक्स्ट कैसे संशोधित करूँ?**

स्लाइड पर तालिका में टेक्स्ट संशोधित करने के लिये [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) का उपयोग करें। सेल्स के माध्यम से iterate करें और प्रत्येक सेल को [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) तथा पैराग्राफ फॉर्मेटिंग को [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) से अपडेट करें।

**PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

ग्रेडिएंट रंग लागू करने के लिये [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) का उपयोग करें। [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) को [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।