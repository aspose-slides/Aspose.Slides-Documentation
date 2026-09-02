---
title: PHP में स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट प्रबंधित करें
linktitle: स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट
type: docs
weight: 15
url: /hi/php-java/script-specific-font-mappings/
keywords:
- स्क्रिप्ट-विशिष्ट फ़ॉन्ट
- थीम फ़ॉन्ट मानचित्रण
- बहुभाषी प्रस्तुति
- लेखन प्रणाली
- सिरिलिक फ़ॉन्ट
- अरबी फ़ॉन्ट
- जापानी फ़ॉन्ट
- जॉर्जियन फ़ॉन्ट
- थाना फ़ॉन्ट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP वाया Java के साथ PowerPoint थीम में स्क्रिप्ट-विशिष्ट फ़ॉन्ट मानचित्रों को जांचें, जोड़ें, बदलें और हटाएँ।"
---
## **परिचय**

एक प्रस्तुति थीम विभिन्न लेखन प्रणालियों के लिए विभिन्न फ़ॉन्ट परिवार चुन सकती है। यह मल्टीलिंगुअल टेक्स्ट को, जो अभी भी थीम फ़ॉन्ट का उपयोग करता है, एक समन्वित फ़ॉन्ट योजना का पालन करने की अनुमति देता है, जबकि सिरिलिक, अरबी, जापानी, जॉर्जियन, थाना और अन्य स्क्रिप्टों के लिए उपयुक्त फ़ॉन्ट का उपयोग करता है।

थीम का [FontScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontscheme/) एक प्रमुख फ़ॉन्ट संग्रह शामिल करता है, जिसे आमतौर पर शीर्षक के लिए उपयोग किया जाता है, और एक मामूली फ़ॉन्ट संग्रह, जिसे आमतौर पर मुख्य पाठ के लिए उपयोग किया जाता है। उनकी लैटिन और ईस्ट एशियन फ़ॉन्ट सेटिंग्स के अतिरिक्त, दोनों [Fonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fonts/) संग्रह लेखन‑प्रणाली टैग से फ़ॉन्ट परिवार नामों के मानचित्र दिखाते हैं।

यह लेख दिखाता है कि प्रस्तुति के मास्टर थीम में इन मानचित्रों का निरीक्षण और संशोधन कैसे करें और यह सत्यापित करें कि परिवर्तन संचित‑और‑पुनः‑लोड चक्र में बने रहें।

## **स्क्रिप्ट टैग को समझें**

स्क्रिप्ट फ़ॉन्ट मेथड्स लेखन प्रणालियों की पहचान करने के लिए चार‑अक्षरीय BCP 47 स्क्रिप्ट सबटैग का उपयोग करते हैं। सामान्य मान नीचे दिए गए हैं:

| स्क्रिप्ट टैग | लेखन प्रणाली |
|---|---|
| `Cyrl` | सिरिलिक |
| `Arab` | अरबी |
| `Hans` | सरलीकृत चीनी |
| `Jpan` | जापानी |
| `Geor` | जॉर्जियन |
| `Thaa` | थाना |

ये मानचित्र थीम फ़ॉन्ट स्कीम का हिस्सा हैं, न कि व्यक्तिगत टेक्स्ट भागों का। एक प्रस्तुति प्रमुख और मामूली संग्रहों के लिए अलग‑अलग मानचित्र परिभाषित कर सकती है, और कुछ स्क्रिप्टों के लिए मानचित्र को छोड़ भी सकती है।

## **स्क्रिप्ट फ़ॉन्ट मानचित्रों तक पहुँचें और जांचें**

[Presentation::getMasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getMasterTheme) का उपयोग करके प्रस्तुति‑स्तरीय थीम प्राप्त करें। [MasterTheme::getFontScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontscheme/#getMajor), और [FontScheme::getMinor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontscheme/#getMinor) मेथड्स दोनों [Fonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fonts/) संग्रहों तक पहुँच प्रदान करते हैं।

[Fonts::getScriptFontMap](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fonts/#getScriptFontMap) को कॉल करके किसी संग्रह से सभी मानचित्र प्राप्त करें। किसी एक लेखन प्रणाली को खोजने के लिए, उसके स्क्रिप्ट टैग के साथ [Fonts::getScriptFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fonts/#getScriptFont) को कॉल करें। `Fonts::getScriptFont` `null` लौटाता है जब वह संग्रह अनुरोधित मानचित्र को परिभाषित नहीं करता।

## **मानचित्रों को संशोधित करें और स्थायित्व सत्यापित करें**

[Fonts::setScriptFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fonts/#setScriptFont) का उपयोग करके मानचित्र बनाएं या वर्तमान फ़ॉन्ट परिवार को बदलें। मानचित्र हटाने के लिए [Fonts::removeScriptFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fonts/#removeScriptFont) का उपयोग करें।

निम्नलिखित एंड‑टू‑एंड उदाहरण सभी मौजूदा प्रमुख और मामूली मानचित्र पढ़ता है, जापानी प्रमुख फ़ॉन्ट खोजता है, सिरिलिक प्रमुख फ़ॉन्ट बदलता है, थाना मामूली मानचित्र हटाता है, प्रस्तुति सहेजता है, और दोनों परिवर्तन सत्यापित करने के लिए पुनः खोलता है। हटाने की प्रक्रिया को शुरुआती थीम से स्वतंत्र बनाने के लिए, यह उदाहरण केवल तब थाना मानचित्र बनाता है जब वह पहले से परिभाषित नहीं है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

सत्यापन सामान्य `null` व्यवहार का उपयोग करता है जैसे सामान्य लुक‑अप में: हटाने के बाद सहेजा गया, `Fonts::getScriptFont("Thaa")` मामूली संग्रह के लिए `null` लौटाता है।

## **थीम मानचित्रों को अन्य फ़ॉन्ट सेटिंग्स से अलग करें**

स्क्रिप्ट‑विशिष्ट थीम मानचित्र फ़ॉन्ट चयन में भाग लेते हैं, लेकिन वे प्रत्यक्ष टेक्स्ट फ़ॉर्मेटिंग, प्रतिस्थापन और फ़ॉलबैक की तुलना में अलग समस्या हल करते हैं:

| तंत्र | उद्देश्य | थीम मानचित्र बदलने का प्रभाव |
|---|---|---|
| स्क्रिप्ट‑विशिष्ट थीम फ़ॉन्ट मानचित्र | लेखन प्रणाली के लिए प्रमुख या मामूली थीम फ़ॉन्ट चुनता है। | पाठ जो अभी भी संबंधित थीम फ़ॉन्ट का उपयोग करता है, नई मानचित्रित परिवार में हल हो सकता है। |
| पाठ भाग को स्पष्ट रूप से सौंपा गया फ़ॉन्ट | थीम पर निर्भर रहने के बजाय उस भाग पर अनुरोधित फ़ॉन्ट परिवार को स्थिर करता है। | भाग अपरिवर्तित रह सकता है क्योंकि उसकी प्रत्यक्ष फॉर्मेटिंग थीम चयन को ओवरराइड करती है। |
| फ़ॉन्ट प्रतिस्थापन | जब अनुरोधित फ़ॉन्ट उपलब्ध नहीं होता या जब प्रतिस्थापन नियम लागू होता है, तब उस फ़ॉन्ट को बदलता है। | यह फ़ॉन्ट अनुरोधित होने के बाद कार्य करता है; यह थीम के स्क्रिप्ट मानचित्र को पुनः परिभाषित नहीं करता। |
| फ़ॉन्ट फ़ॉलबैक | चुने हुए फ़ॉन्ट में न मौजूद ग्लिफ़ प्रदान करता है, अक्सर विशिष्ट यूनिकोड रेंज के लिए। | यह लापता ग्लिफ़ कवरेज को भरता है; यह संग्रहीत थीम मानचित्र को बदलता नहीं है। |

पिछले दो तंत्रों के बारे में अधिक जानकारी के लिए देखें [Font Substitution](/slides/hi/php-java/font-substitution/) और [Fallback Fonts](/slides/hi/php-java/fallback-font/)।

[Presentation::getMasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getMasterTheme) में मानचित्र बदलने से केवल उन सामग्री पर असर पड़ता है जिनका प्रभावी फॉर्मेटिंग अभी भी उस थीम पर निर्भर है। जब दृश्य परिणाम प्रस्तुति‑स्तरीय मानचित्र का पालन नहीं करता, तो उन स्तरों की जाँच करें जहाँ टेक्स्ट एक मास्टर, लेआउट या स्लाइड से ओवरराइड प्राप्त कर सकता है, या जहाँ स्पष्ट रूप से फ़ॉन्ट सौंपा गया हो।

## **मैप किए गए फ़ॉन्ट उपलब्ध कराएँ और परिणाम सत्यापित करें**

स्क्रिप्ट मानचित्र केवल फ़ॉन्ट परिवार नाम संग्रहीत करता है; यह संबंधित फ़ॉन्ट फ़ाइल को स्थापित या लोड नहीं करता। सुसंगत रेंडरिंग और निर्यात के लिए, प्रत्येक मैप किया गया फ़ॉन्ट वातावरण में स्थापित होना चाहिए या Aspose.Slides को कस्टम स्रोत जैसे [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#loadExternalFonts) या [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) के माध्यम से उपलब्ध कराया जाना चाहिए। उपलब्ध लोडिंग विकल्पों के लिए देखें [Custom Fonts](/slides/hi/php-java/custom-font/)।

सहेजे गए मानचित्र की पुष्टि केवल यह सिद्ध करती है कि थीम परिभाषा संरक्षित रही। यह नहीं दर्शाता कि फ़ॉन्ट उपलब्ध है, सभी आवश्यक ग्लिफ़ शामिल हैं, या इच्छित लेआउट उत्पन्न करता है। प्रत्येक आवश्यक लेखन प्रणाली के प्रतिनिधि टेक्स्ट को इमेज या PDF में रेंडर करें और आउटपुट की जांच करें। इससे अनुपलब्ध फ़ॉन्ट, अधूरे ग्लिफ़ कवरेज, फ़ॉलबैक व्यवहार और लेआउट परिवर्तन का पता चलता है, प्रस्तुति के वितरित होने से पहले। रेंडरिंग और निर्यात उदाहरणों के लिए देखें [Convert PowerPoint Presentations](/slides/hi/php-java/convert-powerpoint/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब कोई स्क्रिप्ट मानचित्रित नहीं है तो `Fonts::getScriptFont` क्या लौटाता है?**  
[Fonts::getScriptFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fonts/#getScriptFont) `null` लौटाता है जब अनुरोधित स्क्रिप्ट मानचित्र उस प्रमुख या मामूली फ़ॉन्ट संग्रह में परिभाषित नहीं होता।

**क्या `Fonts::setScriptFont` स्क्रिप्ट पहले से मौजूद होने पर दूसरा मानचित्र जोड़ता है?**  
नहीं। [Fonts::setScriptFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fonts/#setScriptFont) मानचित्र बनाता है जब वह अनुपलब्ध हो और वही स्क्रिप्ट टैग पहले से मौजूद होने पर मैप किए गए फ़ॉन्ट परिवार को बदल देता है।

**क्यों थीम मानचित्र बदलने से कुछ टेक्स्ट नहीं बदला?**  
टेक्स्ट में स्पष्ट रूप से सौंपा गया फ़ॉन्ट हो सकता है, ओवरराइड के माध्यम से अलग थीम विरासत में मिल सकती है, या रेंडरिंग के दौरान प्रतिस्थापन या फ़ॉलबैक का असर हो सकता है। प्रस्तुति‑स्तरीय स्क्रिप्ट मानचित्र केवल उन टेक्स्ट को नियंत्रित करता है जिनका प्रभावी फॉर्मेटिंग अभी भी उस थीम फ़ॉन्ट संग्रह को संदर्भित करता है।

**क्या सहेजना और पुनः खोलना मल्टी‑लिंगुअल आउटपुट को मान्य करने के लिए पर्याप्त है?**  
नहीं। पुनः खोलने से केवल थीम डेटा की स्थायित्व की पुष्टि होती है। साथ ही प्रत्येक आवश्यक लेखन प्रणाली से प्रतिनिधि टेक्स्ट को रेंडर करें ताकि यह सुनिश्चित हो सके कि मैप किए गए फ़ॉन्ट उपलब्ध हैं और आवश्यक ग्लिफ़ शामिल हैं।