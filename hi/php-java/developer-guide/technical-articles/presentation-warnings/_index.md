---
title: प्रस्तुतियों की चेतावनियों को PHP में संभालें
type: docs
weight: 90
url: /hi/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- चेतावनी कॉलबैक
- चेतावनी नीति
- डेटा हानि
- स्रोत भ्रष्टाचार
- संगतता समस्या
- फ़ॉन्ट प्रतिस्थापन
- डिजिटल हस्ताक्षर
- प्रेजेंटेशन लोडिंग
- प्रेजेंटेशन रेंडरिंग
- प्रेजेंटेशन रूपांतरण
- प्रेजेंटेशन सहेजना
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ प्रस्तुतियों को लोड, रेंडर, रूपांतरित और सहेजते समय चेतावनियों को एकत्रित, वर्गीकृत और कार्य करने का तरीका जानें।"
---
## **सारांश**

Aspose.Slides प्रस्तुतियों को लोड, रेंडर, कनवर्ट या सेव करते समय पुनर्प्राप्त करने योग्य समस्याओं की रिपोर्ट कर सकता है। उदाहरणों में क्षतिग्रस्त स्रोत रिकॉर्ड, ऐसी सामग्री जो संरक्षित नहीं की जा सकती, फ़ॉन्ट प्रतिस्थापन, और लक्ष्य फ़ॉर्मेट की सीमाएँ शामिल हैं। एक warning callback एप्लिकेशन को इन स्थितियों को रिकॉर्ड करने और यह तय करने की अनुमति देता है कि वर्तमान ऑपरेशन जारी रखा जा सकता है या नहीं।

PHP क्लास बनाएं जिसमें सार्वजनिक `warning` मेथड हो और उसे PHP Java Bridge के माध्यम से Java[IWarningCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarningcallback/) इंटरफ़ेस के रूप में `java_closure` का उपयोग करके एक्सपोज़ करें। [getWarningType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getWarningType--) और [getDescription](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getDescription--) मानों को देखें जो [IWarningInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/) के माध्यम से प्रदान किए जाते हैं। चेतावनी को स्वीकार करने के लिए [ReturnAction::Continue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/returnaction/#Continue) लौटाएँ या ऑपरेशन को रोकने के लिए [ReturnAction::Abort](https://reference.aspose.com/slides/hi/php-java/aspose.slides/returnaction/#Abort) लौटाएँ।

प्रेजेंटेशन खोलते समय उठाए गए चेतावनियों के लिए [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setWarningCallback) का उपयोग करें। रेंडरिंग और एक्सपोर्ट विकल्प क्लासेस [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveoptions/#setWarningCallback) को इनहेरिट करती हैं, जो स्लाइड रेंडरिंग, कनवर्ज़न और सेविंग से चेतावनियाँ प्राप्त करती हैं। क्योंकि चेतावनी स्वयं एप्लिकेशन ऑपरेशन को पहचानती नहीं है, एक संयुक्त रिपोर्ट बनाते समय प्रत्येक callback इंस्टेंस को एक ऑपरेशन स्टेज के साथ एसोसिएट करें।

## **चेतावनियाँ और अपवाद**

Java अपवाद PHP Java Bridge के जरिए PHP में एक्सपोज़ किए जाते हैं; उन्हें ऑपरेशन बाउंडरी पर पकड़ें, जैसा कि नीचे दिए गए उदाहरण में दिखाया गया है। इस लेख में मौजूद Java इंटरफ़ेस लिंक ब्रिज द्वारा उपयोग किए जाने वाले कॉन्ट्रैक्ट को वर्णित करते हैं।

एक चेतावनी वह स्थिति बताती है जिससे Aspose.Slides `ReturnAction::Continue` लौटाने पर पुनर्प्राप्त कर सकता है। एक अपवाद का अर्थ है कि अनुरोधित ऑपरेशन सामान्य रूप से पूरा नहीं हो सकता; अपवादों को चेतावनियों में परिवर्तित नहीं किया जाता और उन्हें warning policy द्वारा संभाला नहीं जा सकता।

`ReturnAction::Abort` लौटाने पर warning dispatcher वर्तमान ऑपरेशन को अपवाद उठाकर समाप्त करता है। सार्वजनिक अपवाद ऑपरेशन और प्रेजेंटेशन फ़ॉर्मेट पर निर्भर करता है। उदाहरण के लिए, लोड करने पर एक [PptxReadException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxreadexception/) या [PptReadException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptreadexception/) उत्पन्न हो सकता है, जबकि सेविंग या एक्सपोर्ट करने पर एक [PptxException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxexception/) उत्पन्न हो सकता है। ऑपरेशन की सीमा पर अपवाद को हैंडल करें और यह निर्धारित करने के लिए warning रिपोर्ट का उपयोग करें कि क्या एप्लिकेशन नीति के कारण समाप्ति हुई या किसी एक अपवाद सबटाइप या संदेश पर निर्भर किया गया। callback चेतावनी को रिकॉर्ड करके `ReturnAction::Abort` लौटाता है, जिससे कारण एप्लिकेशन के लिए उपलब्ध रह जाता है।

## **चेतावनी श्रेणियाँ**

[WarningType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/warningtype/) क्लास निम्नलिखित श्रेणियों के लिए पूर्णांक कॉन्स्टैंट प्रदान करता है:

| Warning type | Meaning | Typical policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/hi/php-java/aspose.slides/warningtype/#SourceFileCorruption) | स्रोत प्रेजेंटेशन में ऐसी भ्रष्टता है जो मूल फ़ॉर्मेट में सहेजी गई फ़ाइल को अनुपयोगी बना सकती है। | Abort. |
| [DataLoss](https://reference.aspose.com/slides/hi/php-java/aspose.slides/warningtype/#DataLoss) | लोडिंग या सेविंग के बाद टेक्स्ट, चार्ट, इमेज या अन्य डेटा अनुपलब्ध हो सकता है। | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/hi/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | प्रेजेंटेशन में महत्वपूर्ण फ़ॉर्मेटिंग खो सकता है। | कड़ाई से वैधता मोड में Abort; अन्यथा रिकॉर्ड करें और जारी रखें। |
| [MinorFormattingLoss](https://reference.aspose.com/slides/hi/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | छोटे फ़ॉर्मेटिंग अंतर हो सकते हैं। | डायग्नोस्टिक्स के लिए रिकॉर्ड करें और जारी रखें। |
| [CompatibilityIssue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/warningtype/#CompatibilityIssue) | परिणाम कुछ एप्लिकेशन या पुराने संस्करणों में सही तरीके से नहीं खुल सकता या व्यवहार नहीं कर सकता। | लॉग करें और जारी रखें, जब तक कि संगतता अनिवार्य न हो। |
| [UnexpectedContent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/warningtype/#UnexpectedContent) | स्रोत में असमर्थित या अपरिचित सामग्री है जिसका प्रभाव अभी ज्ञात नहीं है। | रिकॉर्ड करें और जारी रखें, या कड़ी नीति में इसे त्रुटि मानें। |

श्रेणी नीति निर्णय को संचालित करनी चाहिए। डायग्नोस्टिक्स के लिए [getDescription](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getDescription--) द्वारा लौटाए गए मान को स्टोर करें, लेकिन एप्लिकेशन लॉजिक में उसके शब्द पर निर्भर न रहें क्योंकि संदेश पाठ विभिन्न चेतावनी परिदृश्यों और प्रोडक्ट संस्करणों में बदल सकता है।

## **चेतावनियों को एकत्रित और वर्गीकृत करें**

निम्नलिखित उदाहरण पूरे प्रोसेसिंग पाइपलाइन के लिए एक एप्लिकेशन-लेवल रिपोर्ट का उपयोग करता है। एक अलग callback इंस्टेंस लोडिंग, रेंडरिंग, PDF कनवर्ज़न और PPTX सेविंग की चेतावनियों को लेबल करता है। नीति स्रोत भ्रष्टाचार या डेटा हानि पर Abort करती है, वैकल्पिक रूप से MajorFormattingLoss पर Abort करती है, और अन्य चेतावनियों के लिए जारी रखती है। callback चेतावनी मूल्यों को `java_values` के साथ नेटिव PHP मानों में बदलता है, फिर रिकॉर्ड और तुलना करता है।

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

यदि MajorFormattingLoss स्वीकार्य है तो `WarningPolicy` बनाते समय `abortOnMajorFormattingLoss` को `false` पास करें। संगतता मुद्दे, MinorFormattingLoss और UnexpectedContent अभी भी रिपोर्ट में रखे जाते हैं भले ही ऑपरेशन जारी रहे। यदि एप्लिकेशन को इन श्रेणियों में से किसी को भी अस्वीकार करना हो तो `WarningPolicy::getAction` को विस्तारित करें।

## **सामान्य चेतावनी परिदृश्य**

चेतावनियां वर्कफ़्लो के विभिन्न चरणों में दिखाई दे सकती हैं:

- **डिजिटल हस्ताक्षर:** एक साइन किया गया प्रेजेंटेशन लोडिंग के दौरान चेतावनी उत्पन्न कर सकता है कि उसका हस्ताक्षर प्रोसेसिंग के दौरान खो जाएगा। Aspose.Slides इस `DataLoss` स्थिति को [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationsignedwarninginfo/) के माध्यम से रिपोर्ट करता है। लोड-स्टेज callback एप्लिकेशन को फ़ाइल को अस्वीकार करने या रिपोर्टेड लॉस को स्पष्ट रूप से स्वीकार करने की अनुमति देता है।
- **फ़ॉन्ट प्रतिस्थापन:** जब कोई स्लाइड रेंडर या एक्सपोर्ट की जाती है तो अनुपलब्ध फ़ॉन्ट को बदल दिया जा सकता है। फ़ॉन्ट प्रतिस्थापन चेतावनियां `DataLoss` के रूप में रिपोर्ट होती हैं, इसलिए उपर्युक्त कड़ी नीति भी तब Abort करती है जब एप्लिकेशन कोई विशेष प्रतिस्थापन दृश्य रूप से स्वीकार्य मानता हो। इस व्यवहार को देखना है तो ऐसी इनपुट प्रेजेंटेशन का उपयोग करें जिसमें runtime में उपलब्ध न होने वाला फ़ॉन्ट हो। चेतावनी विवरण प्रतिस्थापन को पहचानता है; आवश्यक फ़ॉन्ट कॉन्फ़िगर करें या [फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/php-java/font-substitution/) सेट करें और पुनः प्रयास करें।
- **असमर्थित या अप्रत्याशित सामग्री:** लोडर ऐसे प्रेजेंटेशन रिकॉर्ड या फ़ीचर पा सकता है जिन्हें वह पहचान नहीं पाता। ऐसी चेतावनियां `UnexpectedContent` हो सकती हैं, या यदि डेटा या फ़ॉर्मेटिंग प्रभावित है तो अधिक गंभीर श्रेणी हो सकती है।
- **फ़ॉर्मेट संगतता:** किसी अन्य प्रेजेंटेशन फ़ॉर्मेट में सेव करने से फीचर हट सकते हैं या परिणाम कुछ एप्लिकेशन में अलग व्यवहार कर सकता है। उदाहरण के लिए, अधिकतम आठ से अधिक हॉरिज़ॉन्टल या वर्टिकल ड्रॉइंग गाइड्स वाला प्रेजेंटेशन लेगेसी PPT में सेव करने पर `CompatibilityIssue` रिपोर्ट करता है। सेव-स्टेज callback लॉस को रिकॉर्ड कर जारी रख सकता है, या यदि सभी गाइड्स को बनाए रखना आवश्यक है तो अस्वीकार कर सकता है।
- **लोडिंग व्यवहार:** लोडिंग विकल्प और लेगेसी व्यवहार भी चेतावनियां उत्पन्न कर सकते हैं। उदाहरण के लिए, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) उपयोग को `CompatibilityIssue` के रूप में पहचानता है।

चेतावनियां स्रोत दस्तावेज़, लक्ष्य फ़ॉर्मेट, ऑपरेशन और Aspose.Slides संस्करण पर निर्भर करती हैं। यह न मानें कि हर फ़ाइल चेतावनी उत्पन्न करेगी या कोई परिदृश्य हमेशा केवल एक ही श्रेणी में आएगा।

## **ऑपरेशन को सुरक्षित रूप से एबोर्ट करना**

जब callback `ReturnAction::Abort` लौटाता है, तो उस वस्तु का उपयोग न करें जो लोड नहीं हुई और यह न मानें कि रेंडर या सेव आउटपुट पूर्ण है। ऑपरेशन आउटपुट फ़ाइल बनाकर भी उसे पूरा किए बिना समाप्त हो सकता है।

सत्यापित परिणाम को किसी अलग पथ जैसे `validated-output.pptx` में सेव करें। मौजूदा प्रेजेंटेशन को तभी बदलें जब ऑपरेशन सफलतापूर्वक समाप्त हो, चेतावनी रिपोर्ट एप्लिकेशन नीति को संतुष्ट करे, और आउटपुट को खोला और जांचा जा सके। इससे आंशिक या अस्वीकृत परिणाम से वैध स्रोत फ़ाइल ओवरराइट होने से बचाव होता है।

खाली चेतावनी रिपोर्ट यह गारंटी नहीं देती कि हर स्रोत फीचर संरक्षित रहा है। एप्लिकेशन द्वारा आवश्यक अतिरिक्त सामग्री और विजुअल चेक लागू करें। देखें: [Open Presentations](/slides/hi/php-java/open-presentation/) और [Save Presentations](/slides/hi/php-java/save-presentation/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या warning callback हर Aspose.Slides त्रुटि को संभाल सकता है?**

नहीं। यह केवल उन पुनर्प्राप्त करने योग्य स्थितियों को संभालता है जो चेतावनी के रूप में रिपोर्ट होती हैं। callback से स्वतंत्र रूप से होने वाले अपवादों को लोडिंग, रेंडरिंग, कनवर्ज़न या सेविंग कॉल के आसपास एप्लिकेशन द्वारा संभाला जाना चाहिए।

**क्या `ReturnAction::Continue` लौटाने से समान आउटपुट की गारंटी मिलती है?**

नहीं। यह केवल प्रोसेसिंग को जारी रखने की अनुमति देता है। रिपोर्टेड स्थिति अभी भी डेटा, फ़ॉर्मेटिंग या संगतता अंतर पैदा कर सकती है, इसलिए एकत्रित चेतावनी प्रकार और विवरण की समीक्षा करें।

**एक एप्लिकेशन कैसे पहचान सकता है कि कौन सा ऑपरेशन चेतावनी उत्पन्न कर रहा है?**

प्रत्येक ऑपरेशन के लिए एक callback इंस्टेंस बनाएं और [getWarningType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getWarningType--) तथा [getDescription](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iwarninginfo/#getDescription--) द्वारा लौटाए गए मानों को एप्लिकेशन-परिभाषित स्टेज के साथ संग्रहीत करें, जैसा कि उदाहरण में दिखाया गया है।