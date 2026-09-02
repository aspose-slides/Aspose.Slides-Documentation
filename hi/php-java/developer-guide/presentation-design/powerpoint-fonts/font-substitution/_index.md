---
title: PHP का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर करें
linktitle: फ़ॉन्ट प्रतिस्थापन
type: docs
weight: 70
url: /hi/php-java/font-substitution/
keywords:
- फ़ॉन्ट
- प्रतिस्थापित फ़ॉन्ट
- फ़ॉन्ट प्रतिस्थापन
- फ़ॉन्ट बदलें
- फ़ॉन्ट प्रतिस्थापन
- प्रतिस्थापन नियम
- बदलाव नियम
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या रूपांतरित करते समय Java के माध्यम से PHP के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट की जाँच करें।"
---
## **समीक्षा**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को प्रस्तुति रेंडर या रूपांतरण के दौरान पहुंच योग्य नहीं होने वाले फ़ॉन्ट की जगह एक उपलब्ध फ़ॉन्ट उपयोग करने की अनुमति देता है। यह प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति सामग्री को असाइन किए गए फ़ॉन्ट को बदलता नहीं है।

आप किसी विशेष फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिए फ़ॉन्ट निर्धारित कर सकते हैं, और रेंडरिंग के दौरान Aspose.Slides द्वारा किए जाने वाले प्रतिस्थापनों की जाँच कर सकते हैं। यह विभिन्न स्थापित फ़ॉन्ट वाले पर्यावरण में आउटपुट को सुसंगत रखने में मदद करता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

फ़ॉन्ट प्रतिस्थापन निर्धारित करने के लिए [FontsManager::getSubstitutions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/getsubstitutions/) मेथड का उपयोग करें जब प्रस्तुति रेंडर की जाती है। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करता है।

निम्न PHP उदाहरण एक प्रस्तुति के सभी फ़ॉन्ट प्रतिस्थापनों को सूचीबद्ध करता है:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **चयनित स्लाइड्स के लिए फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

चयनित स्लाइड्स को रेंडर करने के लिए आवश्यक केवल प्रतिस्थापनों को देखना चाहते हैं तो [FontsManager::getSubstitutions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/getsubstitutions/) मेथड को `int[] slides` आर्ग्यूमेंट के साथ ओवरलोड करें। यह तब उपयोगी होता है जब आप प्रस्तुति का हिस्सा रेंडर या एक्सपोर्ट कर रहे हों, बड़ी प्रस्तुति को क्रमबद्ध रूप से जाँच रहे हों, उन स्लाइड्स को खोज रहे हों जो अनुपलब्ध फ़ॉन्ट पर निर्भर हैं, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या अनावश्यक स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर को निदान करना चाहते हों।

`slides` एरे में एक‑आधारित स्लाइड इंडेक्स होते हैं: `1` पहले स्लाइड को दर्शाता है। इसके विपरीत, [Presentation::getSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSlides) कलेक्शन एक्सेसर शून्य‑आधारित इंडेक्सिंग का उपयोग करता है, इसलिए वही स्लाइड `$presentation->getSlides()->get_Item(0)` द्वारा पहुँची जाती है। एरे बनाते समय इस अंतर का ध्यान रखें ताकि ऑफ‑बाय‑वन त्रुटि न हो।

ओवरलोड को कॉल करने के लिए [Presentation::getFontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getFontsManager) मेथड का उपयोग करें। यह केवल चयनित स्लाइड्स को रेंडर करते समय निर्धारित प्रतिस्थापनों को लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम होते हैं। परिणाम वर्तमान फ़ॉन्ट पर्यावरण, कॉन्फ़िगर किए गए फॉलबैक नियम, [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, और [externally loaded fonts](/slides/hi/php-java/custom-font/) को प्रतिबिंबित करता है।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइड्स द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंटरी या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को डेडुप्लीकेट करें। नीचे दिया गया उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर विशिष्ट फ़ॉन्ट मैपिंग की क्रमबद्ध सूची बनाता है:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/) क्लास दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | कब उपयोग करें |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/getsubstitutions/) (कोई आर्ग्यूमेंट नहीं) | जब आपको पूरी प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [getSubstitutions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/getsubstitutions/) `int[] slides` के साथ | जब आपको चयनित रेंज, क्रमिक जाँच, या भागीय निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम सेट करें**

जब स्रोत फ़ॉन्ट उपलब्ध न हो तो Aspose.Slides को किस फ़ॉन्ट का उपयोग करना चाहिए, इसे निर्दिष्ट करने के लिए:

1. प्रस्तुति लोड करें।  
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएँ।  
3. [WhenInaccessible](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsubstcondition/) शर्त के साथ एक [FontSubstRule](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsubstrule/) बनाएँ।  
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsubstrulecollection/) में जोड़ें।  
5. [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) मेथड का उपयोग करके कलेक्शन असाइन करें।  
6. प्रस्तुति को रेंडर या रूपांतरित करें।

निम्न PHP उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम की पुष्टि करने के लिए प्रथम स्लाइड को रेंडर करता है। प्रतिस्थापन फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
पूरी प्रस्तुति में उपयोग किए गए फ़ॉन्ट को बिना शर्त बदलने के लिए, देखें [Font Replacement](/slides/hi/php-java/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्ट के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान उपयोग किए जाने वाले मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं। वे सामान्य टेक्स्ट के लिए काम करते हैं जब Aspose.Slides एक अनुपलब्ध फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

Office Math समीकरणों में अतिरिक्त आवश्यकता होती है। यदि किसी समीकरण में **Cambria Math** का उपयोग हुआ है, तो समीकरण लेआउट की गणना और रेंडरिंग के लिए Aspose.Slides को ठीक वही फ़ॉन्ट चाहिए। कोई भी नियम जो **STIX Two Math** जैसे अन्य गणित फ़ॉन्ट को प्रतिस्थापित करता है, **Cambria Math** को बदल नहीं सकता, और रेंडरिंग अभी भी कहेगी कि **Cambria Math** आवश्यक है।

ऐसे प्रस्तुति को रेंडर या रूपांतरित करने के लिए, Aspose.Slides को **Cambria Math** उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में इंस्टॉल करें या एक [external font](/slides/hi/php-java/custom-font/) के रूप में लोड करें।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति टेक्स्ट पर अभी भी लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट बदलाव में क्या अंतर है?**

[Font replacement](/slides/hi/php-java/font-replacement/) प्रस्तुति में एक फ़ॉन्ट को पूरी तरह से दूसरे फ़ॉन्ट से बदलता है। फ़ॉन्ट प्रतिस्थापन तब रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है जब कॉन्फ़िगर की गई शर्त पूरी होती है, जैसे मूल फ़ॉन्ट अनुपलब्ध होना।

**प्रतिस्थापन नियम कब लागू होते हैं?**

रेंडरिंग और रूपांतरण के दौरान नियम [फ़ॉन्ट चयन क्रम](/slides/hi/php-java/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` शर्त के साथ, नियम केवल तभी उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुंच नहीं पा रहा हो।

**जब कोई फ़ॉन्ट अनुपलब्ध हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे नज़दीकी उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम पर्यावरण में उपलब्ध फ़ॉन्टों पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिए बाहरी फ़ॉन्ट लोड कर सकता हूँ?**

हाँ। आप [बाहरी फ़ॉन्ट लोड कर सकते हैं](/slides/hi/php-java/custom-font/) ताकि Aspose.Slides रेंडरिंग और रूपांतरण के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करने और उनके लाइसेंस का पालन करने की ज़िम्मेदारी आपके ऊपर है।

**क्या प्रतिस्थापन परिणाम Windows, Linux और macOS में अलग हो सकते हैं?**

हाँ। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार बदलते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरे पर प्रतिस्थापन की आवश्यकता पैदा कर सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे रखें?**

हर मशीन या कंटेनर पर एक ही फ़ॉन्ट फ़ाइलें और संस्करण रखें, आवश्यक [बाहरी फ़ॉन्ट लोड](/slides/hi/php-java/custom-font/) करें, और लाइसेंस की अनुमति होने पर [फ़ॉन्ट एम्बेड](/slides/hi/php-java/embedded-font/) करें। निर्यात से पहले [FontsManager::getSubstitutions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/getsubstitutions/) को कॉल करके अप्रत्याशित प्रतिस्थापन पहचान सकते हैं।