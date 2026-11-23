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
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट रोटेशन
- रोटेशन कोण
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटॉफ़िट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण, और अधिक को कस्टमाइज़ करें।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को कैसे फ़ॉर्मेट किया जाए। इसमें बैकग्राउंड रंग, पारदर्शिता, कैरेक्टर स्पेसिंग, फ़ॉन्ट गुण, घुमाव, पैराग्राफ स्पेसिंग, ऑटॉफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर किया गया है।

जब तक अन्यथा उल्लेख न किया गया हो, उदाहरण [sample.pptx](sample.pptx) का प्रयोग करते हैं। उसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए टेक्स्ट को शामिल करता है। स्लाइड और आकार दोनों के इंडेक्स शून्य‑आधारित होते हैं। बोल्ड भागों को चुनने वाले उदाहरण प्रभावी फ़ॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में प्राप्त बोल्ड फ़ॉर्मेटिंग भी शामिल है:

![नमूना टेक्स्ट](sample_text.png)

शाब्दिक टेक्स्ट या नियमित अभिव्यक्ति मेलों को खोजने और हाइलाइट करने के लिए देखें [टेक्स्ट खोजें और बदलें](/slides/hi/php-java/search-and-replace-text/)।

## **टेक्स्ट बैकग्राउंड रंग सेट करें**

एक पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने के लिए [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए हल्के ग्रे हाइलाइट को डिफ़ॉल्ट के रूप में सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट को ओवरराइड करेंगे:

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

निम्न कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट भागों** के लिए बैकग्राउंड रंग कैसे सेट किया जाता है:

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

टेक्स्ट फ़्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) का उपयोग करें। मान केंद्रित, बाएँ‑संरेखित, दाएँ‑संरेखित, समान‑झुका आदि हो सकता है।

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

    // पैराग्राफ का संरेखण केंद्र में सेट करें.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **लाइन के भीतर फ़ॉन्ट संरेखित करें**

विभिन्न फ़ॉन्ट आकार वाले टेक्स्ट भागों को लाइन में लंबवत संरेखित करने के लिए [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक लाइन के भीतर संरेखण को नियंत्रित करती है।

निम्न स्व-समावेशी उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36 और 54 पॉइंट का समान टेक्स्ट होता है, लेकिन फ़ॉन्ट संरेखण अलग‑अलग होता है। यह Arial का उपयोग करता है, ऑटॉफ़िट और व्रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ़्रेम को केवल एक लाइन के लिये पर्याप्त बड़ा रखता है।

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

![Baseline, Top, Center, और Bottom फ़ॉन्ट संरेखण की तुलना (मिश्रित फ़ॉन्ट आकार के साथ)](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों की दृश्य किनारे पूरी तरह से मेल नहीं भी खा सकते। उदाहरण में एक बड़ा अक्षर और एक डिसेंडर दोनों शामिल हैं ताकि बेसलाइन और बॉटम संरेखण में अंतर स्पष्ट हो सके। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकार में अंतर परिणाम को प्रभावित करते हैं। फ़्रेम आयाम, मार्जिन, लाइन स्पेसिंग, व्रैपिंग और ऑटॉफ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) (जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करता है) और [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) (जो आकार के भीतर टेक्स्ट ब्लॉक को लंबवत स्थित करता है) से अलग है। [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) का उपयोग करके लागू किए गए सुपरस्क्रिप्ट और सबस्क्रिप्ट फ़ॉर्मेटिंग व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करती है, न कि पैराग्राफ की लाइनों के लिए फ़ॉन्ट संरेखण सेट करती है।

## **टेक्स्ट की पारदर्शिता सेट करें**

टेक्स्ट पारदर्शिता को [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे दिए उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

निम्न कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर कैसे पारदर्शिता लागू की जाए:

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

    // टेक्स्ट का फ़िल रंग पारदर्शी रंग पर सेट करें.
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

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट भागों** पर कैसे पारदर्शिता लागू की जाए:

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
            // टेक्स्ट भाग की पारदर्शिता सेट करें.
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

टेक्स्ट बॉक्स में अक्षरों के बीच की स्पेसिंग को विस्तारित या संकुचित करने के लिए [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) का उपयोग करें। उदाहरण 3 पॉइंट की स्पेसिंग जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकुचित करेंगे।

निम्न PHP कोड दिखाता है कि **पूरे पैराग्राफ** में कैरेक्टर स्पेसिंग को कैसे विस्तारित किया जाए:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // नोट: कैरेक्टर स्पेसिंग को संकुचित करने के लिये नकारात्मक मान उपयोग करें.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // कैरेक्टर स्पेसिंग बढ़ाएँ.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![पैराग्राफ में कैरेक्टर स्पेसिंग](character_spacing_in_paragraph.png)

निम्न कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट भागों** में कैरेक्टर स्पेसिंग को कैसे विस्तारित किया जाए:

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
            // नोट: कैरेक्टर स्पेसिंग को संकुचित करने के लिये नकारात्मक मान उपयोग करें.
            $portion->getPortionFormat()->setSpacing(3); // कैरेक्टर स्पेसिंग बढ़ाएँ.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![टेक्स्ट भागों में कैरेक्टर स्पेसिंग](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए करनिंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए समान टेक्स्ट से थोड़ा अधिक कसकर लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट के लिए करनिंग डेटा को अनदेखा कर देता है, भले ही फ़ॉन्ट में वैध करनिंग जानकारी हो और PowerPoint सेटिंग्स में करनिंग सक्षम हो।

ऐसे मामलों में PowerPoint के अधिक निकट रेंडरिंग प्राप्त करने के लिए, आप उन टेक्स्ट भागों के लिए करनिंग निष्क्रिय कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। यह उदाहरण "presentation.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। यह प्रभावी फ़ॉन्ट नामों (विरासत में प्राप्त फ़ॉन्ट सहित) को जांचता है और Roboto का उपयोग करने वाले भागों के लिए 100‑पॉइंट थ्रेशहोल्ड सेट करता है। इससे 100 पॉइंट से छोटे फ़ॉन्ट आकार वाले मिलते‑जुलते भागों की करनिंग निष्क्रिय हो जाएगी:

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

इस थ्रेशहोल्ड से नीचे वाले मिलते‑जुलते टेक्स्ट के लिए, यह सेटिंग करनिंग को रोकती है और Aspose.Slides की रेंडरिंग को उन फ़ॉन्टों के लिए PowerPoint के दृश्य आउटपुट से अधिक मेल खाने में मदद कर सकती है, जिनमें यह PowerPoint‑विशिष्ट व्यवहार होता है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) के माध्यम से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) के माध्यम से सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक, और डॉटेड अंडरलाइन फ़ॉर्मेटिंग के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट फ़ॉर्मेटिंग इन डिफ़ॉल्ट्स को ओवरराइड करेगी।

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

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण 13‑पॉइंट Times New Roman, इटैलिक फ़ॉर्मेटिंग, और डॉटेड अंडरलाइन को उन भागों पर लागू करता है जिनकी प्रभावी फ़ॉर्मेटिंग बोल्ड है:

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
            // टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें.
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

## **टेक्स्ट ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्पलेट टाइपोग्राफी दोहराते समय या कैरेक्टर ऊँचाई में अंतर की जाँच करते समय [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) का उपयोग करें। PowerPoint में समानिकरण को सक्षम करने से व्यक्तिगत अक्षरों को लंबवत खींचा या संकुचित किया जाता है ताकि वे टेक्स्ट भाग के भीतर समान दृश्य ऊँचाई रख सकें। यह विभिन्न फ़ॉन्टों के बीच समान टेक्स्ट ऊँचाई की गारंटी नहीं देता।

गुण को स्पष्ट रूप से सक्षम या निष्क्रिय करने के लिये [NullableBool::True or False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) सेट करें। `NullableBool::NotDefined` स्थानीय सेटिंग को अनसेट छोड़ देता है, ताकि भाग पैराग्राफ की [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) से मान विरासत में ले सके। इसका अर्थ `False` नहीं है। परिणामी बूलियन मान प्राप्त करने के लिये [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) को कॉल करके `getNormaliseHeight` पढ़ें।

निम्न स्व‑समावेशी उदाहरण **Arial** स्थापित होने की आवश्यकता रखता है। यह दो टेक्स्ट ब्लॉकों को बनाता है, जिनमें समान बड़े अक्षर, छोटे अक्षर, डिसेंडर, और एक्सेंटेड अक्षर 54 पॉइंट पर होते हैं। दोनों पैराग्राफ डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम करते हैं। ऊपर वाला भाग स्पष्ट रूप से इसे निष्क्रिय करता है; नीचे वाला भाग इसे विरासत में लेता है। फ़्रेम आकार, मार्जिन, और पैराग्राफ स्पेसिंग समान हैं, व्रैपिंग और ऑटॉफ़िट निष्क्रिय हैं ताकि तुलना संगत रहे। उदाहरण `False: false` और `NotDefined: true` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है।

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

नीचे की तुलना सहेजे गए प्रस्तुतिकरण से निर्यात की गई है। ऊपर की पंक्ति में सामान्यीकरण निष्क्रिय (`False`) है; नीचे की पंक्ति में यह विरासत में मिला (`NotDefined` → `True`) है। इस दिखावट को पुन: उत्पन्न करने के लिये Arial स्थापित रखें।

![Arial 54‑पॉइंट टेक्स्ट जिसमें ऊपर सामान्यीकरण निष्क्रिय और नीचे विरासत में सामान्यीकरण सक्षम है](text_height_normalization.png)

सामान्यीकरण कैरेक्टर ऊँचाई को बदले बिना असाइन किए गए [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight) मान को बदले, जो फ़ॉन्ट आकार पॉइंट में निर्दिष्ट करता है। पैराग्राफ [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) लाइन स्पेसिंग को नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) टेक्स्ट या उसके कंटेनर को फिट करने के लिये समायोजित करता है। ये सेटिंग्स अलग‑अलग उद्देश्यों के लिये हैं और कुल लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ फ़ॉर्मेटिंग और विरासत के बारे में अधिक जानकारी के लिये देखें [पैराग्राफ प्रबंधन](/slides/hi/php-java/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू और हटाएँ**

टेक्स्ट भाग पर [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) का उपयोग करके निरस्तीकरण, रद्द शब्द, या पिछले मूल्यों को हटाए बिना दिखाया जा सकता है। एक या दो रेखाओं के लिये क्रमशः [TextStrikethroughType::Single or Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) सेट करें।

स्ट्राइकथ्रू हटाने के लिये [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None) पास करें। यह प्रभाव को स्पष्ट रूप से निष्क्रिय करता है, भले ही आसपास की फ़ॉर्मेटिंग स्ट्राइकथ्रू निर्दिष्ट करे। इसके विपरीत, [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) स्थानीय सेटिंग को अनिर्धारित छोड़ देता है, जिससे भाग पैराग्राफ जैसी विरासत फ़ॉर्मेटिंग ले सकता है। यह गारंटी नहीं देता कि स्ट्राइकथ्रू हट गया है। परिणामी फ़ॉर्मेटिंग, जिसमें विरासत मान भी शामिल हैं, पढ़ने के लिये [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) का उपयोग करें।

निम्न स्व‑समावेशी उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पूर्व मूल्य, और वर्तमान मूल्य के लिये अलग‑अलग भाग होते हैं, इसलिए केवल पूर्व मूल्य प्रभावित होता है। पहली पंक्ति में स्ट्राइकथ्रू लागू किया गया और फिर हटाया गया; अन्य पंक्तियों में क्रमशः सिंगल और डबल स्ट्राइकथ्रू रहता है। इस सेटिंग को बदलने से टेक्स्ट और उसके अन्य फ़ॉर्मेटिंग (जैसे बोल्ड पूर्व मूल्य) संरक्षित रहते हैं।

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

परिणाम, ऊपर से नीचे: कोई स्ट्राइकथ्रू नहीं, सिंगल स्ट्राइकथ्रू, और डबल स्ट्राइकथ्रू।

![पहले मूल्य बिना स्ट्राइकथ्रू, सिंगल स्ट्राइकथ्रू, और डबल स्ट्राइकथ्रू के साथ](strikethrough.png)

## **टेक्स्ट रोटेशन सेट करें**

[TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करके आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट किया जाता है।

निम्न कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री घड़ी की विपरीत दिशा** में घुमाता है:

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

## **वर्टिकल टेक्स्ट में अंक एक साथ प्रदर्शित करें**

दो-अंकों की संख्या को वर्टिकल जापानी लेबल में साथ रखने के लिये, दोनों अंक को एक ही टेक्स्ट भाग में रखें और उस भाग पर [BasePortionFormat::setKumimoji](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKumimoji) कॉल करें। यह उदाहरण [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical) और दोनों लेबल के लिये 40‑पॉइंट MS Gothic का उपयोग करता है। केवल संख्यात्मक भाग को पास किया गया [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) मान अलग है।

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 120;

    foreach ([NullableBool::True, NullableBool::False] as $kumimoji) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 48, 120, 420);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $frame = $label->addTextFrame("");
        $frame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::EastAsianVertical);

        $paragraph = $frame->getParagraphs()->get_Item(0);
        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $font = new FontData("MS Gothic");
        $format->setLatinFont($font);
        $format->setEastAsianFont($font);
        $format->setFontHeight(40);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($black);

        $digits = new Portion("12");
        $digits->getPortionFormat()->setKumimoji($kumimoji);

        $portions = $paragraph->getPortions();
        $portions->clear();
        $portions->add(new Portion("令和"));
        $portions->add($digits);
        $portions->add(new Portion("年"));

        $x += 240;
    }
    $presentation->save("vertical_date.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint में बाईं लेबल (`True`) अंक को upright रखती है और 和 और 年 के बीच साइड‑बाय‑साइड दिखाती है। दाईं लेबल (`False`) में युग्म 90 डिग्री घड़ी की दिशा में घुमा रहता है। दोनों लेबल में आसपास के जापानी अक्षर upright रहते हैं।

![PowerPoint में वर्टिकल तिथि लेबल की तुलना – बाएँ में upright अंक और दाएँ में घुमा हुआ अंक](vertical_date.png)

## **टेक्स्ट फ्रेम के लिये कस्टम रोटेशन सेट करें**

[TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) का उपयोग करके [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) के लिये कस्टम रोटेशन एंगल सेट किया जा सकता है।

निम्न कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

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

Aspose.Slides [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore), और [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) प्रदान करता है, जिससे पैराग्राफ स्पेसिंग को नियंत्रित किया जा सकता है। ये गुण इस प्रकार उपयोग होते हैं:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिये धनात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिये ऋणात्मक मान उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ की भीतर स्पेसिंग को लाइन की ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

पैराग्राफ लाइन‑ब्रेकिंग नियम संकरी टेक्स्ट ब्लॉकों और मिश्रित लैटिन‑और‑ईस्ट एशियन टेक्स्ट वाले प्रस्तुतियों में उपयोगी होते हैं। निम्न विधियां [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होती हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) लैटिन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित टेक्स्ट में इसको बदलने से पड़ोसी ईस्ट एशियन टेक्स्ट और विराम चिह्नों के रैपिंग स्थान भी बदल सकते हैं।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ईस्ट एशियन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ़्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। वे लेआउट को प्रभावित करते हैं जब रैपिंग होती है; वे लाइन‑ब्रेक अक्षर नहीं डालते। एक स्पष्ट लाइन‑ब्रेक पैराग्राफ के भीतर नई लाइन को स्वतंत्र रूप से मजबूर करता है, उपलब्ध चौड़ाई की परवाह किए बिना।

निम्न स्व‑समावेशी उदाहरण संकरी टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन टेक्स्ट दोनों होते हैं। यह दोनों लाइन‑ब्रेक विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम को प्रयोग करने के लिये, दूसरे सेटिंग को स्थिर रख कर संबंधित मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun, 160‑पॉइंट फ़्रेम चौड़ाई, तथा क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन शून्य के साथ उपयोग करता है। [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) को [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) के साथ कॉल किया जाता है, ताकि टेक्स्ट आकार और फ़्रेम आयाम स्थिर रहें।

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

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) योग्य विराम चिह्न को टेक्स्ट लाइन के दायें किनारे से बाहर विस्तारित करने की अनुमति देता है, बजाय अगले लाइन में ले जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्व‑समावेशी उदाहरण 100‑पॉइंट‑वाइड टेक्स्ट फ़्रेम में हैंगिंग विराम चिह्न सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन शून्य के साथ, अंतिम अवधि "sentence" के बाद रहती है और दायें टेक्स्ट किनारे से बाहर निकलती है। तुलना के लिये प्रॉपर्टी को [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ अवधि अलग लाइन ले लेती है। रैपिंग सक्षम है और ऑटॉफ़िट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

सभी विराम चिह्न हैंग नहीं सकते। ऊपर वर्णित [फ़ॉन्ट और लेआउट शर्तें](#control-line-breaking) इस तुलना पर भी लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटॉफ़िट सेटिंग बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ़्रेम के लिये ऑटॉफ़िट टाइप सेट करें**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) निर्धारित करता है कि कंटेनर की सीमा से बाहर जाने पर टेक्स्ट कैसे व्यवहार करता है। इसे उपयोग करके आप नियंत्रित कर सकते हैं कि टेक्स्ट सिकुड़ना चाहिए, ओवरफ़्लो होना चाहिए, या आकार स्वयं स्वचालित रूप से पुनः आकारित होना चाहिए। निम्न उदाहरण आकार को उसके टेक्स्ट के अनुसार पुनः आकारित करने के लिये कॉन्फ़िगर करता है और परिणाम को "autofit_type.pptx" में सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofototype(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

स्वचालित रैपिंग के बाद लाइनों की गिनती और टेक्स्ट या आकार की चौड़ाई के परिवर्तन से परिणाम देखना चाहते हैं, तो देखें [रेंडर्ड लाइनों की गिनती](/slides/hi/php-java/manage-paragraph/)। केवल लाइनों की गिनती यह संकेत नहीं देती कि टेक्स्ट अपने कंटेनर से ओवरफ़्लो हो रहा है या नहीं।

## **टेक्स्ट फ़्रेम का एंकर सेट करें**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) यह निर्धारित करता है कि टेक्स्ट आकार के भीतर लंबवत किस स्थान पर स्थित हो – जैसे शीर्ष, मध्य, या नीचे। निम्न उदाहरण टेक्स्ट को पहली आकार के नीचे एंकर करता है और परिणाम को "text_anchor.pptx" में सहेजता है।

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

पैराग्राफ में टैब स्टॉप को कॉन्फ़िगर करने के लिये [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) और [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर एक बाएँ‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब अक्षर वाले टेक्स्ट को प्रभावित करती हैं।

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

Aspose.Slides [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) प्रदान करता है, जिससे आप टेक्स्ट भाग के लिये प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिये प्रयुक्त भाषा को निर्धारित करती है।

निम्न उदाहरण को "presentation.pptx" की आवश्यकता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है और कम से कम एक पैराग्राफ है। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरलित चीनी प्रूफ़िंग भाषा (`zh-CN`) असाइन करता है। फिर परिणाम को "proofing_language.pptx" में सहेजता है:

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

    // प्रूफ़िंग भाषा का Id सेट करें.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **भाषा मेटाडेटा कॉपी करें**

जब मल्टी‑लिंगुअल टेक्स्ट को टेम्पलेट से कॉपी किया जाता है, तो दोनों [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) और [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) को संरक्षित करें। निम्न स्व‑समावेशी उदाहरण स्रोत भाग को US English को उसकी भाषा और French को वैकल्पिक भाषा के रूप में बनाता है और टेक्स्ट तथा पहचानकर्ताओं को नई प्रस्तुति के एक भाग में कॉपी करता है।

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
    // यदि स्रोत में कोई वैकल्पिक भाषा नहीं है, तो null गंतव्य मान को साफ़ कर देगा।
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यदि वैकल्पिक भाषा के बिना स्रोत का परीक्षण करना है, तो `"fr-FR"` असाइनमेंट को छोड़ दें। वैकल्पिक पहचानकर्ता तब `null` रहेगा, और वही कॉपी कथन उसकी अनुपस्थिति को डिफ़ॉल्ट मान पेश किए बिना संरक्षित करता है, भले ही लक्ष्य में पहले वैकल्पिक भाषा असाइन की गई हो।

ये पहचानकर्ता भाषा मेटाडेटा के रूप में संग्रहीत होते हैं। इन्हें संरक्षित करने से यह निर्धारित नहीं होता कि PowerPoint वर्तनी या व्याकरण जाँच के लिये कौन‑सा शब्दकोश चुनेगा।

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करके प्रस्तुति लोड या बनाते समय बनाए गए टेक्स्ट के लिये डिफ़ॉल्ट भाषा परिभाषित करें। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिये `en-US` प्रिंट करता है।

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // एक नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // पहले भाग की भाषा जाँचें।
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिये [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तरीय पैराग्राफ के लिये 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट के रूप में सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // शीर्ष स्तर पैराग्राफ फ़ॉर्मेट प्राप्त करें.
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

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसे टेक्स्ट भाग को पुनः प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को बिल्कुल उसी रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिये, [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) जाँचें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। उसके पहले पैराग्राफ के पहले भाग में "Hello, Aspose!" है, जिस पर All Caps प्रभाव लागू है, जैसा कि नीचे दिखाया गया है।

![ऑल‑कैप्स प्रभाव](all_caps_effect.png)

निम्न कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू हुए टेक्स्ट को कैसे निकाला जाए:

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

**मैं स्लाइड पर तालिका में टेक्स्ट कैसे बदलूँ?**

स्लाइड पर तालिका में टेक्स्ट बदलने के लिये [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) का उपयोग करें। कोशिकाओं के माध्यम से इटरटे करें और प्रत्येक कोशिका को [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) के द्वारा अपडेट करें तथा पैराग्राफ फ़ॉर्मेटिंग को [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) से बदलें।

**मैं PowerPoint स्लाइड पर टेक्स्ट के लिये ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिये [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) का उपयोग करें। [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) को [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, और पारदर्शिता को कॉन्फ़िगर करें।