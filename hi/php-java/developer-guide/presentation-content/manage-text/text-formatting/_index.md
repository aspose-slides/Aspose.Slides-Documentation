---
title: PHP में प्रस्तुति पाठ को स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/php-java/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
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
- ऑटॉफिट गुण
- पाठ फ्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फ़ॉर्मेट और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।"
---
## **समीक्षा**

यह लेख दिखाता है कि Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को कैसे स्वरूपित किया जाए। इसमें पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटॉफिट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स शामिल हैं।

जब तक अन्यथा न कहा गया हो, उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया जाता है। उसकी पहली स्लाइड पर पहला शेप एक टेक्स्ट बॉक्स है, और उसके पहले पैराग्राफ में नीचे दिखाया गया पाठ है। स्लाइड और शेप दोनों के सूचकांक शून्य-आधारित हैं। बोल्ड भागों का चयन करने वाले उदाहरण प्रभावी स्वरूपण का उपयोग करते हैं, जिसमें विरासत में मिला बोल्ड स्वरूपण भी शामिल है:

![नमूना पाठ](sample_text.png)

शाब्दिक पाठ या रेगुलर‑एक्सप्रेशन मिलानों को खोजने और हाइलाइट करने के लिए, देखें [पाठ खोजें और बदलें](/slides/hi/php-java/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

डिफ़ॉल्ट पैराग्राफ हाइलाइट रंग सेट करने के लिए [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) का उपयोग करें, या व्यक्तिगत पाठ भागों के लिए [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए डिफ़ॉल्ट रूप से हल्का ग्रे हाइलाइट सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

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

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट** वाले **पाठ भागों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

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

![ग्रे पाठ भाग](gray_text_portions.png)

## **पाठ पैराग्राफ संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) का उपयोग करें। मान केंद्रित, बाएँ‑संरेखित, दाएँ‑संरेखित, बराबर‑बांटा आदि हो सकते हैं।

निम्न कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // पैराग्राफ की संरेखण को केंद्र में सेट करें।
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **रेखा के भीतर फ़ॉन्ट संरेखित करें**

विभिन्न फ़ॉन्ट आकार के पाठ भागों को एक रेखा के भीतर लंबवत संरेखित करने के लिए [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और उसकी प्रत्येक रेखा के भीतर संरेखण को नियंत्रित करती है।

निम्न स्वतंत्र उदाहरण एक ही स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36 और 54 पॉइंट के समान पाठ होते हैं, अलग‑अलग फ़ॉन्ट संरेखन के साथ। यह Arial का उपयोग करता है, ऑटॉफिट और रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ्रेम को एकल रेखा के लिए पर्याप्त बड़ा रखता है।

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

![Baseline, Top, Center, Bottom फ़ॉन्ट संरेखण का मिश्रित फ़ॉन्ट आकारों के साथ तुलना](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों के दृश्य किनारे बिल्कुल मेल नहीं खा सकते। उदाहरण में एक बड़े अक्षर और एक नीचे की ओर जाने वाला अक्षर दोनों शामिल हैं ताकि बेसलाइन और बॉटम संरेखन के अंतर को दिखाया जा सके। फ़ॉन्ट उपलब्धता और प्रतिस्थापन, उपयोग किए गए अक्षर, तथा फ़ॉन्ट आकारों के अंतर भी परिणाम को प्रभावित करते हैं। फ्रेम आयाम, मार्जिन, रेखा अंतराल, रैपिंग और ऑटॉफिट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) से अलग है, जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करती है, तथा [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) से भी अलग है, जो शेप के भीतर टेक्स्ट ब्लॉक को लंबवत स्थित करता है। [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट स्वरूपण व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करता है, न कि पैराग्राफ की रेखाओं के लिए फ़ॉन्ट संरेखन सेट करता है।

## **पाठ की पारदर्शिता सेट करें**

पाठ की पारदर्शिता को [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) को सौंपे गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे दिए गए उदाहरणों में `alpha = 50` 0‑255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

निम्न कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर पारदर्शिता कैसे लागू की जाए:

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

    // टेक्स्ट का फिल कलर पारदर्शी रंग पर सेट करें।
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

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट** वाले **पाठ भागों** पर पारदर्शिता कैसे लागू की जाए:

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

![पारदर्शी पाठ भाग](transparent_text_portions.png)

## **पाठ के लिए अक्षर अंतराल सेट करें**

[BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) का उपयोग करके टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को बढ़ाया या घटाया जा सकता है। नीचे के उदाहरण 3 पॉइंट अंतराल जोड़ते हैं; नकारात्मक मान पाठ को संकुचित करेंगे।

निम्न PHP कोड दिखाता है कि **पूरे पैराग्राफ** में अक्षर अंतराल कैसे बढ़ाया जाए:

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

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट** वाले **पाठ भागों** में अक्षर अंतराल कैसे बढ़ाया जाए:

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

![पाठ भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए केरनिंग निष्क्रिय करें**

कभी‑कभी Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखने वाले पाठ से थोड़ा अधिक कसकर दिखाई देता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट के लिए केरनिंग डेटा को अनदेखा करता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर आउटपुट को PowerPoint के करीब लाने के लिए, आप उन पाठ भागों के लिए केरनिंग निष्क्रिय कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। यह उदाहरण पहले स्लाइड के पहले शेप पर टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता रखता है। यह प्रभावी फ़ॉन्ट नामों को जांचता है, जिसमें विरासत में मिले फ़ॉन्ट शामिल हैं, और Roboto उपयोग करने वाले भागों के लिए 100‑पॉइंट थ्रेशहोल्ड सेट करता है। यह 100 पॉइंट से कम फ़ॉन्ट आकार वाले मिलते‑जुलते भागों के लिए केरनिंग निष्क्रिय कर देता है:

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

थ्रेशहोल्ड से नीचे के मिलते‑जुलते पाठ के लिए, यह सेटिंग केरनिंग को रोकती है और ऐसी फ़ॉन्टों के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) के द्वारा या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) के द्वारा सेट किए जा सकते हैं।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट स्वरूपण इन डिफ़ॉल्ट्स पर प्राथमिकता रखता है:

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

निम्न उदाहरण उन भागों पर 13‑पॉइंट Times New Roman, इटैलिक और डॉटेड अंडरलाइन लागू करता है जिनकी प्रभावी स्वरूपण बोल्ड है:

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

![पाठ भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्पलेट टाइपोग्राफी पुन: उत्पन्न करने या अक्षर ऊँचाई में अंतर की जाँच करने के लिए [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) का उपयोग करें। PowerPoint में सामान्यीकरण सक्षम करने से व्यक्तिगत अक्षरों को ऊर्ध्वाधर रूप से खींचा या संकुचित किया जाता है ताकि वे पाठ भाग के भीतर समान दृश्य ऊँचाई प्राप्त करें। यह विभिन्न फ़ॉन्टों में समान पाठ ऊँचाई की गारंटी नहीं देता।

गुण को स्पष्ट रूप से सक्षम या निष्क्रिय करने के लिए [NullableBool::True या False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) सेट करें। `NullableBool::NotDefined` स्थानीय सेटिंग को अनसेट छोड़ देता है ताकि भाग पैराग्राफ के [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) से मान विरासत में ले सके। इसका मतलब `False` नहीं है। लौटाए गए प्रभावी स्वरूपण डेटा पर `getNormaliseHeight` पढ़ने के लिए [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) का उपयोग करें।

निम्न स्वतंत्र उदाहरण **Arial** स्थापित होने पर चलाता है। यह दो टेक्स्ट ब्लॉक्स बनाता है जिनमें समान बड़े अक्षर, छोटे अक्षर, डेसेंडर और 54 पॉइंट पर उन्नत अक्षर होते हैं। दोनों पैराग्राफ डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम करते हैं। शीर्ष भाग स्पष्ट रूप से इसे निष्क्रिय करता है; निचला भाग इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और पैराग्राफ स्पेसिंग समान हैं, रैपिंग और ऑटॉफिट निष्क्रिय हैं ताकि तुलना सुसंगत रहे। उदाहरण `False: false` और `NotDefined: true` प्रदर्शित करता है, फिर "text_height_normalization.pptx" सहेजता है।

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

नीचे का तुलना सहेजी गई प्रस्तुति से निर्यात किया गया है। शीर्ष पंक्ति में सामान्यीकरण निष्क्रिय है (`False`); निचली पंक्ति में विरासत में मिला सक्रिय सेटिंग (`NotDefined` → `True`) है। इस दिखावे को पुन: उत्पन्न करने के लिए Arial स्थापित रखें।

![Arial 54‑पॉइंट टेक्स्ट जिसमें ऊपर सामान्यीकरण निष्क्रिय और नीचे विरासत में प्राप्त सामान्यीकरण सक्रिय है](text_height_normalization.png)

सामान्यीकरण अक्षर ऊँचाई को बदले बिना असाइन किए गए [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight) मान को बदले, जो फ़ॉन्ट आकार को पॉइंट में निर्दिष्ट करता है। पैराग्राफ [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) रेखा अंतराल नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) यह नियंत्रित करता है कि टेक्स्ट या उसका कंटेनर फिट होने के लिए कैसे समायोजित होता है। ये सेटिंग्स अलग‑अलग उद्देश्यों की सेवा करती हैं और कुल लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ स्वरूपण और विरासत के बारे में अधिक जानकारी के लिए देखें [पैराग्राफ प्रबंधित करें](/slides/hi/php-java/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू और हटाएँ**

टेक्स्ट भाग पर [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) का उपयोग करके सुधार, रद्द किए गए शब्द या पिछले मूल्यों को बिना मूल पाठ हटाए दिखाया जा सकता है। एक या दो रेखाओं के लिए क्रमशः [TextStrikethroughType::Single या Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) सेट करें।

स्ट्राइकथ्रू हटाने के लिए [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None) पास करें। यह स्थानीय प्रभाव को स्पष्ट रूप से निष्क्रिय करता है, भले ही आसपास का स्वरूपण स्ट्राइकथ्रू निर्दिष्ट करता हो। इसके विपरीत, [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) स्थानीय सेटिंग को अनिर्धारित छोड़ देता है, जिससे भाग पैराग्राफ आदि से स्वरूपण विरासत में ले सकता है। यह सुनिश्चित नहीं करता कि स्ट्राइकथ्रू हटा दिया गया है। परिणामस्वरूप स्वरूपण, जिसमें विरासत में मिले मान शामिल हैं, पढ़ने के लिए [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) का उपयोग करें।

निम्न स्वतंत्र उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पुराना मूल्य और नया मूल्य के लिए अलग‑अलग भाग होते हैं, इसलिए केवल पुराना मूल्य प्रभावित होता है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; अन्य पंक्तियों में क्रमशः सिंगल और डबल स्ट्राइकथ्रू रहता है। इस सेटिंग को बदलने से पाठ और उसके अन्य स्वरूपण, जैसे बोल्ड पुराना मूल्य, संरक्षित रहता है।

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // स्ट्राइकथ्रू लागू करें, फिर पहले पिछले मूल्य से इसे स्पष्ट रूप से हटाएँ।
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम, ऊपर से नीचे क्रमशः: कोई स्ट्राइकथ्रू नहीं, सिंगल स्ट्राइकथ्रू, और डबल स्ट्राइकथ्रू।

![स्ट्राइकथ्रू के बिना, सिंगल स्ट्राइकथ्रू और डबल स्ट्राइकथ्रू वाले पिछले मूल्य](strikethrough.png)

## **पाठ घूर्णन सेट करें**

शेप के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करें।

निम्न कोड उदाहरण शेप में टेक्स्ट अभिविन्यास को [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिक्लॉकवाइस** घुमाता है:

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

![टेक्स्ट घूर्णन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) का उपयोग करके किसी [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) के लिए कस्टम घूर्णन कोण सेट करें।

निम्न कोड उदाहरण शेप के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइस घुमाता है:

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

![कस्टम टेक्स्ट घूर्णन](custom_text_rotation.png)

## **पैराग्राफ की रेखा अंतराल सेट करें**

Aspose.Slides [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) और [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) प्रदान करता है ताकि पैराग्राफ अंतराल नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* सकारात्मक मान रेखा ऊँचाई के प्रतिशत के रूप में रेखा अंतराल निर्दिष्ट करता है।
* नकारात्मक मान रेखा अंतराल को पॉइंट में निर्दिष्ट करता है।

निम्न उदाहरण पहले पैराग्राफ के भीतर अंतराल को रेखा ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

![पैराग्राफ के भीतर रेखा अंतराल](line_spacing.png)

## **रेखा‑विच्छेदन नियंत्रित करें**

पैराग्राफ रेखा‑विच्छेदन नियम संकीर्ण टेक्स्ट ब्लॉक्स और लैटिन तथा ईस्ट एशियन पाठ मिश्रित प्रस्तुतियों में उपयोगी होते हैं। नीचे दिए गए मेथड्स [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

* [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) लैटिन रेखा‑विच्छेदन नियम नियंत्रित करता है। मिश्रित पाठ में इसे बदलने से ईस्ट एशियन पाठ व विराम चिह्नों की रैपिंग पर भी प्रभाव पड़ सकता है।
* [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ईस्ट एशियन रेखा‑विच्छेदन नियम नियंत्रित करता है, जिसमें पंक्ति की शुरुआत और अंत में अक्षरों की प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग सक्षम करता है। वे रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे रेखा‑विच्छेदन अक्षर नहीं डालते। स्पष्ट रेखा‑विच्छेदन नई पंक्ति बनाता है, जो उपलब्ध चौड़ाई से स्वतंत्र रूप से पैराग्राफ के भीतर नई पंक्ति बनाता है।

निम्न स्वतंत्र उदाहरण चीनी और लैटिन पाठ वाले संकीर्ण टेक्स्ट ब्लॉक बनाता है। यह दोनों रेखा‑विच्छेदन विकल्प स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम के साथ प्रयोग करने के लिए, दूसरे सेटिंग को स्थिर रखकर संबंधित मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun, 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन का उपयोग करता है। [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) को [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) के साथ कॉल किया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) योग्य विराम चिह्न को टेक्स्ट लाइन के दाएँ किनारे से आगे तक बढ़ने की अनुमति देता है, बजाय अगली लाइन में जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इण्डेंट से अलग है।

निम्न स्वतंत्र उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ्रेम में हैंगिंग विराम चिह्न सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर निकलता है। तुलना के लिए गुण को [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ बिंदु अलग पंक्ति में आता है। रैपिंग सक्षम है और ऑटॉफिट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न हैंग नहीं करता। ऊपर वर्णित [फ़ॉन्ट और लेआउट शर्तें](#control-line-breaking) भी इस तुलना पर लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटॉफिट सेटिंग बदलने से दिखाई देने वाला अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटॉफिट प्रकार सेट करें**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमाओं से बाहर जाने पर कैसे व्यवहार करता है। इसे उपयोग करके नियंत्रित किया जा सकता है कि टेक्स्ट छोटा हो, ओवरफ़्लो करे या शेप को स्वचालित रूप से आकार बदलें। नीचे दिया गया उदाहरण शेप को उसके टेक्स्ट के अनुरूप आकार बदलने के लिए कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है।

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

ऑटोफ़िट रैपिंग के बाद पंक्तियों की संख्या गिनने और यह देखने के लिए कि टेक्स्ट या शेप की चौड़ाई परिणाम को कैसे बदलती है, देखें [Count Rendered Lines](/slides/hi/php-java/manage-paragraph/). केवल पंक्तियों की संख्या यह संकेत नहीं देती कि टेक्स्ट कंटेनर से ओवरफ़्लो हो रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) शेप के भीतर टेक्स्ट को ऊर्ध्वाधर रूप से कैसे स्थित किया जाए, जैसे शीर्ष, मध्य या नीचे, को परिभाषित करता है। नीचे दिया गया उदाहरण टेक्स्ट को पहले शेप के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

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

[ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) और [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) का उपयोग करके पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करें। नीचे दिया गया उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट सेट करता है और 30 पॉइंट पर बाएँ‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब अक्षर वाले टेक्स्ट को प्रभावित करती हैं।

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

Aspose.Slides [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) प्रदान करता है, जो पाठ भाग के लिए प्रूफ़िंग भाषा सेट करने की अनुमति देता है। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा को निर्धारित करती है।

नीचे दिया गया उदाहरण "presentation.pptx" की आवश्यकता रखता है, जिसमें पहले शेप पर पहला टेक्स्ट बॉक्स और कम‑से‑कम एक पैराग्राफ हो। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरल चीन भाषा (`zh-CN`) को प्रूफ़िंग भाषा के रूप में असाइन करता है। परिणाम "proofing_language.pptx" में सहेजा जाता है:

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

### **भाषा मेटाडेटा कॉपी करें**

टेम्प्लेट से बहुभाषी पाठ कॉपी करते समय, दोनों [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) और [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) को संरक्षित रखें। नीचे दिया गया स्वतंत्र उदाहरण स्रोत भाग बनाता है जिसका भाषा US English और वैकल्पिक भाषा French है, और टेक्स्ट एवं पहचानकों को नई प्रस्तुति के भाग में कॉपी करता है।

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // यदि स्रोत में वैकल्पिक भाषा नहीं है, तो null गंतव्य मान को साफ कर देता है।
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

वैकल्पिक भाषा के बिना स्रोत को आज़माने के लिए, `"fr-FR"` असाइनमेंट को छोड़ दें। तब वैकल्पिक पहचानकर्ता `null` होगा, और वही कॉपी कथन उसकी अनुपस्थिति को डिफ़ॉल्ट मान जोड़े बिना संरक्षित रखेगा, भले ही गंतव्य में पहले वैकल्पिक भाषा असाइन की गई हो।

ये पहचानकर्ता भाषा मेटाडेटा के रूप में संग्रहित होते हैं। इन्हें संरक्षित करने से यह निर्धारित नहीं होता कि PowerPoint वर्तनी या व्याकरण जांच के लिए कौन-सा शब्दकोश चुनेगा।

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करके प्रस्तुति लोड या बनाते समय निर्मित टेक्स्ट की डिफ़ॉल्ट भाषा परिभाषित करें। नीचे दिया गया उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले पाठ भाग के लिए `en-US` प्रिंट करता है।

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // पाठ के साथ नया आयताकार आकार जोड़ें।
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

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle) का उपयोग करें।

नीचे दिया गया उदाहरण नई प्रस्तुति में शीर्ष‑स्तर पैराग्राफ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट रूप में सेट करता है और इसे "default_text_style.pptx" के रूप में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट स्वरूपण उन्हें ओवरराइड न कर दे।

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **ऑल‑कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से स्लाइड पर पाठ बड़े अक्षरों में दिखता है, भले ही इसे छोटे अक्षरों में टाइप किया गया हो। Aspose.Slides के साथ ऐसा पाठ भाग प्राप्त करने पर लाइब्रेरी मूल दर्ज किए गए पाठ को ही लौटाती है। प्रदर्शित पाठ से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) जांचें और जब मान `All` हो तब लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें पहले स्लाइड के पहले शेप पर एक टेक्स्ट बॉक्स हो। इसके पहले पैराग्राफ के पहले भाग में "Hello, Aspose!" है, जिस पर All Caps प्रभाव लागू है, जैसा कि नीचे दिखाया गया है।

![All Caps प्रभाव](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू होने पर टेक्स्ट कैसे निकाला जाए:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड पर तालिका में टेक्स्ट कैसे संशोधित करूँ?**

स्लाइड पर तालिका में टेक्स्ट संशोधित करने के लिए [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करके प्रत्येक कोशिका को [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) के माध्यम से अपडेट करें और पैराग्राफ स्वरूपण को [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) के माध्यम से अपडेट करें।

**मैं PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) का उपयोग करें। [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) को [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा और पारदर्शिता को कॉन्फ़िगर करें।