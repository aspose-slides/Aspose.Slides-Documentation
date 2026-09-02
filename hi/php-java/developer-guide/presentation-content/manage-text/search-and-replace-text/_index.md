---
title: "PHP में PowerPoint प्रस्तुतियों में टेक्स्ट खोजें और बदलें"
linktitle: "टेक्स्ट खोजें और बदलें"
type: docs
weight: 55
url: /hi/php-java/search-and-replace-text/
keywords:
- "टेक्स्ट खोजें"
- "टेक्स्ट हाईलाइट करें"
- "टेक्स्ट बदलें"
- "रेग्युलर एक्सप्रेशन"
- "परिणाम कॉलबैक"
- "टेक्स्ट फ्रेम"
- "ऑडिट रिपोर्ट"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट खोजें, हाईलाइट करें और बदलें, और प्रत्येक मिलान को एकत्रित करें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java व्यक्तिगत टेक्स्ट फ्रेम या पूरी प्रस्तुति में टेक्स्ट को खोज, हाईलाइट और बदल सकता है। प्रत्येक ऑपरेशन परिणाम कॉलबैक के माध्यम से प्रत्येक मिलान के बारे में एप्लिकेशन को सूचित भी कर सकता है। इससे प्रस्तुति को अपडेट करना और साथ ही मिलान किए गए टेक्स्ट, उसका संदर्भ, स्थिति, टेक्स्ट फ्रेम और स्लाइड नंबर शामिल एक ऑडिट ट्रेल बनाना संभव हो जाता है।

इन क्षमताओं का उपयोग समीक्षा, संशोधन, शब्दावली जाँच, टेम्पलेट सफाई और स्वचालित रिपोर्टिंग वर्कफ़्लो के लिए किया जा सकता है।

नीचे पहले उदाहरणों में हम "sample.pptx" नामक फ़ाइल का उपयोग करते हैं, जिसमें पहली स्लाइड पर निम्नलिखित टेक्स्ट वाले एकल टेक्स्ट बॉक्स शामिल है:

![उदाहरण टेक्स्ट](sample_text.png)

## **खोज दायरा चुनें**

[TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) के मेथड्स का उपयोग करके ऑपरेशन को एक टेक्स्ट फ्रेम तक सीमित करें। [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) के मेथड्स का उपयोग करके प्रस्तुति में सभी लागू टेक्स्ट को प्रोसेस करें।

| ऑपरेशन | एक टेक्स्ट फ्रेम | पूरी प्रस्तुति |
|---|---|---|
| सच्चा टेक्स्ट हाईलाइट करें | [TextFrame::highlightText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#highlightText) |
| रेग्युलर एक्सप्रेशन मिलानों को हाईलाइट करें | [TextFrame::highlightRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#highlightRegex) |
| सच्चा टेक्स्ट बदलें | [TextFrame::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#replaceText) |
| रेग्युलर एक्सप्रेशन मिलानों को बदलें | [TextFrame::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#replaceRegex) |

## **टेक्स्ट मिलान कॉन्फ़िगर करें**

सच्चा टेक्स्ट ऑपरेशनों के लिए, मिलान को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/) का उपयोग करें:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) मिलानों को पूर्ण शब्दों तक सीमित करता है।
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) यह नियंत्रित करता है कि अक्षर केस मेल खानी चाहिए या नहीं।
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) प्रस्तुति-स्तर की खोज, प्रतिस्थापन और हाईलाइट ऑपरेशनों में स्लाइड नोट्स को शामिल करता है।

रेग्युलर एक्सप्रेशन ऑपरेशनों में Java `Pattern` का उपयोग किया जाता है, इसलिए केस संवेदनशीलता और शब्द सीमा जैसी मिलान नियम अभिव्यक्ति और उसकी फ्लैग्स द्वारा परिभाषित होते हैं।

## **कॉलबैक से मिलान जानकारी एकत्र करें**

हाइलाइटिंग या रिप्लेसमेंट मेथड को एक Java प्रॉक्सी कॉलबैक पास करें ताकि प्रत्येक मिलान के लिए नोटिफिकेशन प्राप्त हो सके। कॉलबैक मेथड संबंधित टेक्स्ट फ्रेम, स्रोत टेक्स्ट, मिलान किया गया टेक्स्ट और मिलान की स्थिति प्राप्त करता है।

कॉलबैक को सीधे स्लाइड नंबर नहीं मिलता। नीचे दिया गया इम्प्लीमेंटेशन इसे पैरेंट स्लाइड से निकालता है और स्लाइड नोट्स में मिले टेक्स्ट को भी हैंडल करता है। जब टेक्स्ट किसी अन्य स्लाइड प्रकार से जुड़ा होता है तो परिणाम एरे `null` उपयोग करता है।

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentSlide = $textFrame->getSlide();
        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

ऑपरेशन में पास करने से पहले इस PHP ऑब्जेक्ट का प्रॉक्सी बनाएं:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

रिप्लेसमेंट ऑपरेशनों के लिए, `foundText` में मूल मिलान किया गया टेक्स्ट होता है, इसलिए कॉलबैक सही तौर पर रिकॉर्ड कर सकता है कि कौन से शब्द बदले गए।

## **टेक्स्ट को हाईलाइट करें**

[TextFrame::highlightText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightText) मेथड का उपयोग करके टेक्स्ट फ्रेम में सच्चा टेक्स्ट मिलानों को हाईलाइट करें। खोज को नियंत्रित करने के लिए [TextSearchOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/) पास करें।

नीचे दिया गया कोड उदाहरण अक्षर **"try"** के सभी occurrences को हाईलाइट करता है और फिर केवल संपूर्ण शब्द **"to"** को हाईलाइट करता है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // टेक्स्ट फ्रेम में "try" की प्रत्येक घटना को हाईलाइट करें।
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // केवल संपूर्ण शब्द "to" को हाईलाइट करें।
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

परिणाम:

![हाइलाइट किया गया टेक्स्ट](highlighted_text.png)

## **रेग्युलर एक्सप्रेशन से टेक्स्ट को हाईलाइट करें**

[TextFrame::highlightRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightRegex) मेथड टेक्स्ट फ्रेम में रेग्युलर एक्सप्रेशन द्वारा पाए गए टेक्स्ट मिलानों को हाईलाइट करता है।

निम्नलिखित कोड सात या अधिक अक्षर वाले सभी शब्दों को हाईलाइट करता है:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

परिणाम:

![रेग्युलर एक्सप्रेशन से हाईलाइट किया गया टेक्स्ट](highlighted_text_using_regex.png)

## **पूरी प्रस्तुति में टेक्स्ट को हाईलाइट करें**

[Presentation::highlightText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#highlightText) और [Presentation::highlightRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#highlightRegex) का उपयोग करके प्रस्तुति में सभी लागू टेक्स्ट फ्रेम को खोजें। नीचे दिया गया उदाहरण एक सच्चा शब्द और सभी ईमेल पतों को हाईलाइट करता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **टेक्स्ट फ्रेम में टेक्स्ट बदलें**

सच्चा टेक्स्ट के लिए [TextFrame::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceText) और पैटर्न-आधारित रिप्लेसमेंट के लिए [TextFrame::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceRegex) का उपयोग करें। ये मेथड मौजूदा टेक्स्ट फ्रेम के भीतर मिलान किए गए टेक्स्ट को अपडेट करते हैं, जिससे आसपास के हिस्से का फॉर्मेटिंग बरकरार रहता है और पूरे स्ट्रिंग से टेक्स्ट फ्रेम को पुनः बनाना नहीं पड़ता।

निम्नलिखित उदाहरण एक वर्तनी वैरिएंट को मानकीकृत करता है और फिर संस्करण लेबल को बदलता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

यदि कोई मिलान विभिन्न फॉर्मेटिंग वाले हिस्सों को कवर करता है, तो आउटपुट की समीक्षा करें और पुष्टि करें कि कौन सा फॉर्मेटिंग रिप्लेसमेंट टेक्स्ट पर लागू होना चाहिए।

## **पूरी प्रस्तुति में टेक्स्ट बदलें**

[Presentation::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#replaceText) और [Presentation::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#replaceRegex) का उपयोग करके प्रस्तुति में समान ऑपरेशनों को लागू करें। यह टेम्पलेट सफाई, शब्दावली अपडेट और संशोधन के लिए उपयोगी है।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **रिपोर्टिंग के लिए मिलानों को समूहित करें**

चूंकि प्रत्येक परिणाम अपना स्लाइड नंबर और टेक्स्ट फ्रेम स्टोर करता है, एप्लिकेशन ऑडिट, रिपोर्टिंग या रिव्यू वर्कफ़्लो के लिए मिलानों को समूहित कर सकते हैं। नीचे दिया गया उदाहरण पहले स्लाइड और फिर टेक्स्ट फ्रेम के आधार पर संग्रहीत परिणामों को समूहित करता है:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **प्रश्नोत्तर**

**मैं पूरी प्रस्तुति के बजाय केवल एक टेक्स्ट बॉक्स को कैसे खोज सकता हूँ?**

शेप के टेक्स्ट फ्रेम को प्राप्त करें और उस टेक्स्ट फ्रेम पर [TextFrame::highlightText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceText) या [TextFrame::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceRegex) को कॉल करें। प्रस्तुति-स्तर के मेथड सभी लागू टेक्स्ट फ्रेम को प्रोसेस करते हैं।

**मैं सही केसिंग के साथ पूर्ण शब्दों को कैसे मिलान कर सकता हूँ?**

[TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) और [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) को `true` सेट करें, और इन विकल्पों को सच्चा-टेक्स्ट हाईलाइटिंग या रिप्लेसमेंट मेथड में पास करें। रेग्युलर एक्सप्रेशन्स के लिए, शब्द सीमा और केस संवेदनशीलता को Java `Pattern` में स्वयं परिभाषित करें।

**क्या खोज और रिप्लेसमेंट स्लाइड नोट्स में टेक्स्ट को शामिल कर सकते हैं?**

हाँ। जब आप प्रस्तुति-स्तर पर सच्चा-टेक्स्ट ऑपरेशन उपयोग करते हैं, तो [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) को `true` सेट करें।

**मैं प्रस्तुति को दूसरी बार स्कैन किए बिना रिपोर्ट कैसे बना सकता हूँ?**

हाइलाइटिंग या रिप्लेसमेंट ऑपरेशन में एक Java प्रॉक्सी कॉलबैक पास करें। यह ऑपरेशन चलते समय प्रत्येक मिलान प्राप्त करता है, इसलिए एप्लिकेशन स्रोत टेक्स्ट, मिलान किया गया टेक्स्ट, स्थिति, टेक्स्ट फ्रेम और निकाले गए स्लाइड नंबर को बाद में समूहित करने या निर्यात करने के लिए संग्रहीत कर सकता है।

**क्या टेक्स्ट को बदलने से उसका फॉर्मेटिंग बरकरार रहता है?**

[TextFrame::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceText) और [TextFrame::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceRegex) मौजूदा टेक्स्ट फ्रेम के भीतर मिलान किए गए टेक्स्ट को संशोधित करते हैं और आसपास के हिस्से की फॉर्मेटिंग बरकरार रखते हैं। यदि कोई मिलान विभिन्न फॉर्मेटिंग वाले हिस्सों को कवर करता है, तो परिणाम की जांच करें और सुनिश्चित करें कि रिप्लेसमेंट वांछित शैली का उपयोग करता है।