---
title: JavaScript का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें
linktitle: फ़ॉन्ट प्रतिस्थापन
type: docs
weight: 70
url: /hi/nodejs-java/font-substitution/
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
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या परिवर्तित करते समय Node.js के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट्स की जांच करें।"
---
## **अवलोकन**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को उस फ़ॉन्ट के स्थान पर उपलब्ध फ़ॉन्ट उपयोग करने की अनुमति देता है जिसे प्रस्तुति रेंडर या परिवर्तित करते समय पहुँच नहीं सकता। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति की सामग्री को सौंपे गए फ़ॉन्ट को नहीं बदलता।

आप किसी विशेष फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिए फ़ॉन्ट निर्धारित कर सकते हैं, और आप Aspose.Slides द्वारा रेंडरिंग के दौरान किए गए प्रतिस्थापनों की जांच कर सकते हैं। यह विभिन्न स्थापित फ़ॉन्ट्स वाले वातावरणों में आउटपुट को सुसंगत रखने में मदद करता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

फ़ॉन्ट प्रतिस्थापन निर्धारित करने के लिए [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) मेथड का उपयोग करें जब प्रस्तुति रेंडर की जाती है। यह मेथड उन [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट्स को लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करते हैं।

नीचे दिया गया JavaScript उदाहरण प्रस्तुति के सभी फ़ॉन्ट प्रतिस्थापनों को सूचीबद्ध करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **चयनित स्लाइड्स के लिए फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

केवल विशिष्ट स्लाइड्स को रेंडर करने के लिए आवश्यक प्रतिस्थापन की जाँच करने हेतु [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) ओवरलोड को स्लाइड इंडेक्स की सरणी के साथ उपयोग करें। यह तब उपयोगी होता है जब आप प्रस्तुति का केवल हिस्सा रेंडर या एक्सपोर्ट कर रहे हों, बड़े प्रस्तुति को चरणबद्ध रूप से जांच रहे हों, उन स्लाइड्स को ढूँढ़ रहे हों जो अनुपलब्ध फ़ॉन्ट पर निर्भर हैं, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या अप्रासंगिक स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर की जाँच कर रहे हों।

ओवरलोड एक Java primitive `int[]` की अपेक्षा करता है। इसे `java.newArray("int", [...])` से बनाएँ; एक सामान्य JavaScript सरणी `Integer[]` में बदलती है और इस ओवरलोड से मेल नहीं खाती।

सरणी में एक‑आधारित स्लाइड इंडेक्स होते हैं: `1` पहली स्लाइड को दर्शाता है। इसके विपरीत, [Presentation.getSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslides/) कलेक्शन एक्सेसर शून्य‑आधारित इंडेक्सिंग का उपयोग करता है, इसलिए वही स्लाइड `presentation.getSlides().get_Item(0)` से एक्सेस की जाती है। इस अंतर को याद रखें ताकि ऑफ‑बाय‑वन त्रुटियों से बचा जा सके।

ओवरलोड को [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getfontsmanager/) के माध्यम से कॉल करें। यह केवल चयनित स्लाइड्स को रेंडर करते समय निर्धारित प्रतिस्थापनों को लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम होते हैं। परिणाम वर्तमान फ़ॉन्ट पर्यावरण, कॉन्फ़िगर किए गए फ़ॉलबैक नियम, [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, और [externally loaded fonts](/slides/hi/nodejs-java/custom-font/) को दर्शाता है।

एक ही प्रतिस्थापन अधिक से अधिक चयनित स्लाइड्स द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंटरी या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को ड्यूडुप्लीकेट करें। नीचे दिया गया उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की सॉर्टेड सूची बनाता है:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/) क्लास दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | उपयोग कब करें |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) बिना आर्ग्युमेंट के | आपको पूरी प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [getSubstitutions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) स्लाइड इंडेक्स की Java `int[]` के साथ | आपको चयनित रेंज, चरणबद्ध जांच, या भागीय एक्सपोर्ट के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम निर्धारित करें**

जब स्रोत फ़ॉन्ट उपलब्ध न हो तो Aspose.Slides को किस फ़ॉन्ट का उपयोग करना चाहिए, इसे निर्दिष्ट करने के लिए:

1. प्रस्तुति को लोड करें।
2. स्रोत और प्रतिस्थापित फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएँ।
3. [WhenInaccessible](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsubstcondition/) शर्त के साथ एक [FontSubstRule](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsubstrule/) बनाएँ।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. संग्रह को [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) मेथड का उपयोग करके असाइन करें।
6. प्रस्तुति को रेंडर या परिवर्तित करें।

नीचे दिया गया JavaScript उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर पहले स्लाइड को रेंडर करके परिणाम सत्यापित करता है। प्रतिस्थापित फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
पूरी प्रस्तुति में प्रयुक्त फ़ॉन्ट्स को बिना शर्त बदलने के लिए, देखें [Font Replacement](/slides/hi/nodejs-java/font-replacement/)।
{{% /alert %}}

## **गणितीय समीकरण फ़ॉन्ट्स के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और परिवर्तित करने के दौरान इस्तेमाल होने वाली मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा होते हैं। ये नियमित टेक्स्ट के लिए काम करते हैं जब Aspose.Slides अनुपलब्ध फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

ऑफ़िस मैथ समीकरणों में अतिरिक्त आवश्यकताएँ होती हैं। यदि कोई समीकरण **Cambria Math** का उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडर करने के लिए बिल्कुल वही फ़ॉन्ट चाहिए हो सकता है। किसी अन्य गणित फ़ॉन्ट, जैसे **STIX Two Math**, को प्रतिस्थापित करने वाला नियम **Cambria Math** को इस उद्देश्य के लिए नहीं बदल सकता, और रेंडरिंग अभी भी यह दर्शा सकती है कि **Cambria Math** आवश्यक है।

ऐसी प्रस्तुति को रेंडर या परिवर्तित करने हेतु, **Cambria Math** को Aspose.Slides के लिए उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में इंस्टॉल करें या एक [external font](/slides/hi/nodejs-java/custom-font/) के रूप में लोड करें।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति टेक्स्ट पर अभी भी लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट परिवर्तन में क्या अंतर है?**

[Font replacement](/slides/hi/nodejs-java/font-replacement/) प्रस्तुति में एक फ़ॉन्ट को पूरे दस्तावेज़ में दूसरे फ़ॉन्ट से जानबूझकर बदलता है। फ़ॉन्ट प्रतिस्थापन रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है जब विशिष्ट शर्त पूरी होती है, जैसे मूल फ़ॉन्ट उपलब्ध न होना।

**प्रतिस्थापन नियम कब लागू होते हैं?**

नियम रेंडरिंग और परिवर्तित करने के दौरान [font selection sequence](/slides/hi/nodejs-java/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग होता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं सकता।

**जब फ़ॉन्ट अनुपलब्ध हो और कोई प्रतिस्थापन नियम न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे नज़दीकी उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम पर्यावरण में उपलब्ध फ़ॉन्ट्स पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिए बाहरी फ़ॉन्ट लोड कर सकता हूँ?**

हां। आप [external fonts](/slides/hi/nodejs-java/custom-font/) लोड कर सकते हैं ताकि Aspose.Slides उन्हें रेंडरिंग और परिवर्तित करने के दौरान उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करना और उनके लाइसेंस का पालन करना आपकी ज़िम्मेदारी है।

**क्या प्रतिस्थापन परिणाम Windows, Linux, और macOS में अलग हो सकते हैं?**

हां। स्थापित फ़ॉन्ट्स और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार अलग होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरे पर प्रतिस्थापन की आवश्यकता पैदा कर सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे बनाऊँ?**

हर मशीन या कंटेनर पर समान फ़ॉन्ट फ़ाइलें और संस्करण उपयोग करें, आवश्यक [external fonts](/slides/hi/nodejs-java/custom-font/) लोड करें, और लाइसेंस अनुमति देने पर [embed fonts](/slides/hi/nodejs-java/embedded-font/) करें। आप निर्यात से पहले अप्रत्याशित प्रतिस्थापनों की पहचान के लिए [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) भी कॉल कर सकते हैं।