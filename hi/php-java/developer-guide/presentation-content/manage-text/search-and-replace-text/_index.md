---
title: PowerPoint प्रस्तुतियों में PHP के साथ टेक्स्ट खोजें और बदलें
linktitle: टेक्स्ट खोजें और बदलें
type: docs
weight: 55
url: /hi/php-java/search-and-replace-text/
keywords:
- टेक्स्ट खोजें
- टेक्स्ट हाइलाइट
- टेक्स्ट बदलें
- रेग्युलर एक्सप्रेशन
- परिणाम कॉलबैक
- टेक्स्ट फ़्रेम
- ऑडिट रिपोर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में टेक्स्ट खोजें, हाइलाइट करें और बदलें, साथ ही प्रत्येक मैच को Aspose.Slides for PHP via Java के साथ इकट्ठा करें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java किसी व्यक्तिगत टेक्स्ट फ़्रेम में या पूरी प्रस्तुति में टेक्स्ट को खोज, हाइलाइट और बदल सकता है। प्रत्येक ऑपरेशन प्रत्येक मिलान के बारे में एक परिणाम कॉलबैक के माध्यम से एप्लिकेशन को सूचित भी कर सकता है। इससे प्रस्तुति को अपडेट करने के साथ‑साथ मिले हुए टेक्स्ट, उसका संदर्भ, स्थिति, टेक्स्ट फ़्रेम और स्लाइड संख्या सहित एक ऑडिट ट्रेल बनाना संभव हो जाता है।

ये क्षमताएँ समीक्षा, रेडैक्शन, शब्दावली जाँच, टेम्प्लेट सफ़ाई और स्वचालित रिपोर्टिंग वर्कफ़्लो के लिए उपयोगी हैं।

नीचे पहले उदाहरणों में हम “sample.pptx” नामक फ़ाइल का उपयोग करते हैं, जिसमें पहले स्लाइड पर एक अकेला टेक्स्ट बॉक्स है और वह निम्नलिखित टेक्स्ट रखता है:

![नमूना पाठ](sample_text.png)

## **खोज सीमा चुनें**

एक ऑपरेशन को केवल एक टेक्स्ट फ़्रेम तक सीमित करने के लिए [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) की विधियों का प्रयोग करें। सभी लागू टेक्स्ट को प्रोसेस करने के लिए [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) की विधियों का प्रयोग करें।

| ऑपरेशन | एक टेक्स्ट फ़्रेम | पूरी प्रस्तुति |
|---|---|---|
| लिटरल टेक्स्ट को हाइलाइट करें | [TextFrame::highlightText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#highlightText) |
| रेग्युलर‑एक्सप्रेशन मैच को हाइलाइट करें | [TextFrame::highlightRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#highlightRegex) |
| लिटरल टेक्स्ट को बदलें | [TextFrame::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#replaceText) |
| रेग्युलर‑एक्सप्रेशन मैच को बदलें | [TextFrame::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#replaceRegex) |

## **पाठ मिलान कॉन्फ़िगर करें**

लिटरल‑टेक्स्ट ऑपरेशनों के लिए मिलान को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/) का प्रयोग करें:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) मैच को केवल पूर्ण शब्दों तक सीमित करता है।
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) यह नियंत्रित करता है कि अक्षर केस मेल करना आवश्यक है या नहीं।
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) प्रस्तुति‑स्तर की खोज, प्रतिस्थापन और हाइलाइटिंग में स्लाइड नोट्स को शामिल करता है।

रेग्युलर‑एक्सप्रेशन ऑपरेशनों में Java `Pattern` का उपयोग किया जाता है, इसलिए केस‑संवेदीता और शब्द सीमाएँ जैसी नियम अभिव्यक्ति और उसके फ्लैग द्वारा निर्धारित होते हैं।

## **टेक्स्ट फ़्रेम के मालिक की पहचान करें**

सामान्य टेक्स्ट‑प्रोसेसिंग वर्कफ़्लो अक्सर [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) को प्राप्त करते हैं जबकि वे खोज, प्रतिस्थापन, वैधता जाँच या निर्यात कर रहे होते हैं। टेक्स्ट फ़्रेम के मालिक को निर्धारित करने के लिए [TextFrame::getParentShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParentShape) और [TextFrame::getParentCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParentCell) का प्रयोग करें।

अपेक्षित मान मालिक के आधार पर बदलते हैं:

| टेक्स्ट फ़्रेम मालिक | `getParentShape` | `getParentCell` |
|---|---|---|
| एक AutoShape या दूसरा टेक्स्ट‑धारक आकार | मालिक‑[Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) | `null` |
| एक टेबल सेल | `null` | मालिक‑[Cell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/) |

दोनों विधियाँ केवल‑पढ़ने योग्य नेविगेशन प्रदान करती हैं। इन्हें कॉल करने से टेक्स्ट फ़्रेम नहीं चलता और न ही उसका मालिक बदलता है। सामान्य कोड को दोनों मानों को `java_is_null` के साथ जाँचना चाहिए और इस संभावना को संभालना चाहिए कि कोई भी मालिक उपलब्ध न हो।

निम्न उदाहरण में [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideutil/#getAllTextFrames) का उपयोग करके प्रस्तुति के सभी टेक्स्ट फ़्रेमों पर इटररेट किया गया है। आकारों के लिए यह आकार का नाम, Java रन‑टाइम प्रकार और शामिल स्लाइड को रिपोर्ट करता है। टेबल सेल्स के लिए यह शून्य‑आधारित कॉलम और पंक्ति निर्देशांक तथा शामिल स्लाइड को रिपोर्ट करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

SmartArt सामग्री के लिए, [SmartArtNode::getShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnode/#getShapes) में आकारों पर इटररेट करें और प्रत्येक [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartshape/#getTextFrame) तक पहुँचें। टेक्स्ट फ़्रेम को उसका संबंधित आकार [TextFrame::getParentShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParentShape) द्वारा ट्रेस किया जा सकता है, जबकि [TextFrame::getParentCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParentCell) `null` लौटाता है। इसलिए, उदाहरण में आकार शाखा SmartArt नोड्स से मिलने वाले टेक्स्ट को भी संभालती है।

## **कॉलबैक के साथ मैच जानकारी एकत्र करें**

हाइलाइटिंग या प्रतिस्थापन विधि को एक Java प्रॉक्सी कॉलबैक पास करें ताकि हर मैच पर एक सूचना प्राप्त की जा सके। कॉलबैक विधि संबंधित टेक्स्ट फ़्रेम, स्रोत टेक्स्ट, मिलाए गए टेक्स्ट और मैच पोज़िशन को प्राप्त करती है।

कॉलबैक सीधे स्लाइड संख्या नहीं प्राप्त करता। नीचे दिया गया कार्यान्वयन इसे पैरेंट स्लाइड से व्युत्पन्न करता है और स्लाइड नोट्स में मिले टेक्स्ट को भी संभालता है। परिणाम एरे में `null` तब उपयोग किया जाता है जब टेक्स्ट किसी अन्य स्लाइड प्रकार से जुड़ा हो।

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
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

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

इस PHP ऑब्जेक्ट का एक प्रॉक्सी बनाकर इसे ऑपरेशन को पास करने से पहले तैयार करें:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

प्रतिस्थापन ऑपरेशनों के लिए, `foundText` मूल मिलाए गए टेक्स्ट को रखता है, इसलिए कॉलबैक ठीक‑ठीक रिकॉर्ड कर सकता है कि कौन‑से शब्द बदले गए।

## **पाठ को हाइलाइट करें**

[TextFrame::highlightText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightText) विधि का प्रयोग करके टेक्स्ट फ़्रेम में लिटरल‑टेक्स्ट मैच को हाइलाइट करें। खोज को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/) पास करें।

नीचे दिया गया कोड उदाहरण सभी "**try**" अक्षरों को हाइलाइट करता है और फिर केवल पूर्ण शब्द "**to**" को हाइलाइट करता है।

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

    // टेक्स्ट फ़्रेम में "try" की प्रत्येक उत्पत्ति को हाइलाइट करें।
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

    // केवल पूर्ण शब्द "to" को हाइलाइट करें।
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

![हाइलाइट किया गया पाठ](highlighted_text.png)

## **रेग्युलर एक्सप्रेशन का उपयोग करके पाठ को हाइलाइट करें**

[TextFrame::highlightRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightRegex) विधि टेक्स्ट फ़्रेम में रेग्युलर एक्सप्रेशन द्वारा पाए गए टेक्स्ट मैच को हाइलाइट करती है।

निम्न कोड सभी सात या अधिक अक्षर वाले शब्दों को हाइलाइट करता है:

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

![रेग्युलर एक्सप्रेशन द्वारा हाइलाइट किया गया पाठ](highlighted_text_using_regex.png)

## **एक प्रस्तुति में पूरे पाठ को हाइलाइट करें**

[Presentation::highlightText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#highlightText) और [Presentation::highlightRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#highlightRegex) का उपयोग करके प्रस्तुति के सभी लागू टेक्स्ट फ़्रेमों पर खोज करें। निम्न उदाहरण एक लिटरल शब्द और सभी ई‑मेल पते को हाइलाइट करता है:

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

## **टेक्स्ट फ़्रेम में टेक्स्ट बदलें**

लिटरल टेक्स्ट के लिए [TextFrame::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceText) और पैटर्न‑आधारित प्रतिस्थापन के लिए [TextFrame::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceRegex) का प्रयोग करें। ये विधियाँ मौजूदा टेक्स्ट फ़्रेम के भीतर मिलाए गए टेक्स्ट को अपडेट करती हैं, जिससे आसपास के भागों का फ़ॉर्मेटिंग बरकरार रहता है और पूरे फ़्रेम को साधारण स्ट्रिंग से फिर से नहीं बनाना पड़ता।

निम्न उदाहरण एक वर्तनी विविधता को मानकीकृत करता है और फिर संस्करण लेबल को बदलता है:

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

यदि एक मैच विभिन्न फ़ॉर्मेटिंग वाले भागों पर फैला हो, तो आउटपुट की जाँच करें कि प्रतिस्थापन टेक्स्ट पर कौन‑सा फ़ॉर्मेट लागू होना चाहिए।

## **एक प्रस्तुति में पूरे टेक्स्ट को बदलें**

[Presentation::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#replaceText) और [Presentation::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#replaceRegex) का प्रयोग करके समान ऑपरेशन पूरे प्रस्तुति में लागू करें। यह टेम्प्लेट सफ़ाई, शब्दावली अद्यतन और रेडैक्शन के लिए उपयोगी है।

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

## **रिपोर्टिंग के लिए मैच समूहित करें**

चूँकि प्रत्येक परिणाम अपनी स्लाइड संख्या और टेक्स्ट फ़्रेम संग्रहीत करता है, एप्लिकेशन ऑडिट, रिपोर्टिंग या रिव्यू वर्कफ़्लो के लिए मैच को समूहित कर सकते हैं। नीचे दिया गया उदाहरण पहले स्लाइड के अनुसार और फिर टेक्स्ट फ़्रेम के अनुसार एकत्रित परिणामों को समूहित करता है:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी प्रस्तुति के बजाय केवल एक टेक्स्ट बॉक्स को कैसे खोजूँ?**

आकार के टेक्स्ट फ़्रेम को प्राप्त करें और उस टेक्स्ट फ़्रेम पर [TextFrame::highlightText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceText) या [TextFrame::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceRegex) को कॉल करें। प्रस्तुति‑स्तर की विधियाँ सभी लागू टेक्स्ट फ़्रेमों को प्रोसेस करती हैं।

**मैं पूरे शब्दों को सही केसिंग के साथ कैसे मिलाऊँ?**

[TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) और [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) को `true` सेट करें, और विकल्पों को लिटरल‑टेक्स्ट हाइलाइटिंग या प्रतिस्थापन विधि में पास करें। रेग्युलर एक्सप्रेशन के लिए, शब्द सीमाएँ और केस‑संवेदीता को स्वयं Java `Pattern` में परिभाषित करें।

**क्या खोज और प्रतिस्थापन स्लाइड नोट्स के टेक्स्ट को भी शामिल कर सकते हैं?**

हां। प्रस्तुति‑स्तर की लिटरल‑टेक्स्ट ऑपरेशन का उपयोग करते समय [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) को `true` सेट करें।

**मैं रिपोर्ट कैसे बना सकता हूँ बिना प्रस्तुति को दोबारा स्कैन किए?**

हाइलाइटिंग या प्रतिस्थापन ऑपरेशन को एक Java प्रॉक्सी कॉलबैक पास करें। यह ऑपरेशन चलने के दौरान हर मैच प्राप्त करता है, जिससे एप्लिकेशन स्रोत टेक्स्ट, मिलाए गए टेक्स्ट, स्थिति, टेक्स्ट फ़्रेम और व्युत्पन्न स्लाइड संख्या को बाद में समूहित या निर्यात करने हेतु संग्रहीत कर सकता है।

**क्या टेक्स्ट बदलने से उसका फ़ॉर्मेटिंग बना रहता है?**

[TextFrame::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceText) और [TextFrame::replaceRegex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#replaceRegex) मौजूद टेक्स्ट फ़्रेम के भीतर मिलाए गए टेक्स्ट को संशोधित करते हैं और आसपास के भागों का फ़ॉर्मेटिंग बरकरार रखते हैं। यदि एक मैच विभिन्न फ़ॉर्मेटिंग वाले भागों पर फैला हो, तो परिणाम की जाँच करें ताकि प्रतिस्थापन वांछित शैली का उपयोग करे।