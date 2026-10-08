---
title: PHP का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें
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
description: "PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या रूपांतरण करते समय, Java के माध्यम से PHP के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट का निरीक्षण करें।"
---
## **अवलोकन**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को उपलब्ध फ़ॉन्ट का उपयोग करने देता है जब कोई फ़ॉन्ट प्रस्तुति को रेंडर या रूपांतरित करने के दौरान उपलब्ध नहीं रहता। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति सामग्री को असाइन किए गए फ़ॉन्ट को नहीं बदलता।

आप किसी विशिष्ट फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिए फ़ॉन्ट निर्धारित कर सकते हैं, और आप Aspose.Slides द्वारा रेंडरिंग के दौरान किए जाने वाले प्रतिस्थापनों की जांच कर सकते हैं। इससे विभिन्न स्थापित फ़ॉन्ट वाले वातावरणों में आउटपुट सुसंगत रहने में मदद मिलती है।

यदि कोई फ़ॉन्ट उपलब्ध है लेकिन उसका समर्पित बोल्ड टाइपफ़ेस नहीं है, तो देखें [Handle Fonts Without a Dedicated Bold Typeface](/slides/hi/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)। वह अनुभाग समझाता है कि PDF निर्यात के दौरान प्रभावीत टेक्स्ट को कैसे रास्टराइज़ किया जाए और टेक्स्ट चयन, खोज और स्केलिंग पर क्या प्रभाव पड़ेगा।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

फ़ॉन्ट प्रतिस्थापन निर्धारित करने के लिए [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) मेथड का उपयोग करें। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट्स लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करते हैं।

निम्नलिखित PHP उदाहरण एक प्रस्तुति के सभी फ़ॉन्ट प्रतिस्थापनों को सूचीबद्ध करता है:

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

चयनित स्लाइड्स के लिए केवल आवश्यक प्रतिस्थापनों की जांच करने हेतु [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) ओवरलोड को `int[] slides` आर्ग्यूमेंट के साथ उपयोग करें। यह तब उपयोगी होता है जब आप प्रस्तुति के केवल हिस्से को रेंडर या निर्यात कर रहे हों, बड़ी प्रस्तुति को क्रमिक रूप से जांच रहे हों, उन स्लाइड्स को ढूँढ़ रहे हों जो अनुपलब्ध फ़ॉन्ट पर निर्भर हैं, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या अनावश्यक स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर का निदान करना चाहते हों।

`slides` ऐरे में एक-आधारित स्लाइड इंडेक्स होते हैं: `1` पहली स्लाइड को दर्शाता है। इसके विपरीत, [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) कलेक्शन एक्सेसर शून्य-आधारित इंडेक्सिंग का उपयोग करता है, इसलिए वही स्लाइड `$presentation->getSlides()->get_Item(0)` के रूप में पहुँची जाती है। ऐरे बनाते समय इस अंतर को ध्यान में रखें ताकि ऑफ‑बाय‑वन त्रुटियों से बचा जा सके।

ओवरलोड को [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/) मेथड के माध्यम से कॉल करें। यह केवल चयनित स्लाइड्स को रेंडर करते समय निर्धारित प्रतिस्थापन लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम शामिल होते हैं। परिणाम वर्तमान फ़ॉन्ट वातावरण, कॉन्फ़िगर किए गए फ़ॉलबैक नियम, [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, और [externally loaded fonts](/slides/hi/php-java/custom-font/) को दर्शाता है।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइड्स द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंट्री या प्री‑फ्लाइट रिपोर्ट बनाते समय परिणामों को डिडुप्लिकेट करें। निम्न उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की सॉर्टेड सूची बनाता है:

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

[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) क्लास दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | कब उपयोग करें |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) बिना आर्ग्यूमेंट के | आपको पूरी प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) `int[] slides` के साथ | आपको चयनित रेंज, क्रमिक जांच, या आंशिक निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम सेट करें**

जब स्रोत फ़ॉन्ट उपलब्ध नहीं हो तो Aspose.Slides को कौन सा फ़ॉन्ट उपयोग करना चाहिए, इसे निर्दिष्ट करने के लिए:

1. प्रस्तुति लोड करें।
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएं।
3. एक [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) को [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/) कंडीशन के साथ बनाएं।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. संग्रह को [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) मेथड के द्वारा असाइन करें।
6. प्रस्तुति को रेंडर या रूपांतरित करें।

निम्नलिखित PHP उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम को सत्यापित करने के लिए पहली स्लाइड को रेंडर करता है। प्रतिस्थापित फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

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
पूरी प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट को बिना शर्त बदलने के लिए देखें [Font Replacement](/slides/hi/php-java/font-replacement/)।
{{% /alert %}}

## **मैथ समीकरण फ़ॉन्ट के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान उपयोग की जाने वाली मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा होते हैं। वे नियमित टेक्स्ट के लिए काम करते हैं जब Aspose.Slides किसी पहुँच‑से‑बाहरी फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

ऑफ़िस मैथ समीकरणों में अतिरिक्त आवश्यकता होती है। यदि कोई समीकरण **Cambria Math** का उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडरिंग के लिए वही फ़ॉन्ट चाहिए हो सकता है। कोई भी नियम जो **STIX Two Math** जैसे अन्य गणितीय फ़ॉन्ट को प्रतिस्थापित करता है, वह इस उद्देश्य के लिए **Cambria Math** को बदल नहीं सकता, और रेंडरिंग अभी भी यह रिपोर्ट कर सकती है कि **Cambria Math** आवश्यक है।

ऐसी प्रस्तुति को रेंडर या रूपांतरित करने के लिए **Cambria Math** को Aspose.Slides के लिए उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में स्थापित करें या इसे एक [external font](/slides/hi/php-java/custom-font/) के रूप में लोड करें।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम अभी भी नियमित प्रस्तुति टेक्स्ट पर लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट रिप्लेसमेंट में क्या अंतर है?**

[Font replacement](/slides/hi/php-java/font-replacement/) पूरे प्रस्तुति में एक फ़ॉन्ट को जानबूझकर दूसरे फ़ॉन्ट से बदलता है। फ़ॉन्ट प्रतिस्थापन तब रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है जब निर्धारित शर्त पूरी होती है, जैसे मूल फ़ॉन्ट अनुपलब्ध हो।

**प्रतिस्थापन नियम कब लागू होते हैं?**

ये नियम रेंडरिंग और रूपांतरण के दौरान [font selection sequence](/slides/hi/php-java/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं सकता।

**जब फ़ॉन्ट गायब हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकटतम उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम वातावरण में उपलब्ध फ़ॉन्ट पर निर्भर करता है।

**क्या मैं बाह्य फ़ॉन्ट लोड करके प्रतिस्थापन से बच सकता हूँ?**

हाँ। आप [load external fonts](/slides/hi/php-java/custom-font/) करके Aspose.Slides को रेंडरिंग और रूपांतरण के दौरान उनका उपयोग करने दे सकते हैं।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करना और उनके लाइसेंस का पालन करना आपका दायित्व है।

**क्या Windows, Linux और macOS में प्रतिस्थापन परिणाम अलग‑अलग हो सकते हैं?**

हाँ। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार भिन्न होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरी मशीन पर प्रतिस्थापन की आवश्यकता पैदा कर सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे बनाऊँ?**

हर मशीन या कंटेनर पर समान फ़ॉन्ट फ़ाइलें और संस्करण रखें, आवश्यक [external fonts](/slides/hi/php-java/custom-font/) लोड करें, और लाइसेंस अनुमति दे तो [embed fonts](/slides/hi/php-java/embedded-font/) का उपयोग करें। आप निर्यात से पहले अप्रत्याशित प्रतिस्थापनों की पहचान करने के लिए [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) को भी कॉल कर सकते हैं।