---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर करें
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
description: "PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या रूपांतरित करते समय Java के माध्यम से Node.js के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट्स की जांच करें।"
---
## **अवलोकन**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को एक उपलब्ध फ़ॉन्ट का उपयोग करने की अनुमति देता है जब प्रस्तुति को रेंडर या रूपांतरित किया जाता है और मूल फ़ॉन्ट उपलब्ध नहीं होता। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति सामग्री को असाइन किए गए फ़ॉन्ट को नहीं बदलता।

आप किसी विशेष फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिए फ़ॉन्ट को परिभाषित कर सकते हैं, और आप Aspose.Slides द्वारा रेंडरिंग के दौरान किए जाने वाले प्रतिस्थापनों की जाँच कर सकते हैं। यह विभिन्न स्थापित फ़ॉन्ट वाले वातावरणों में आउटपुट को निरंतर रखने में मदद करता है।

यदि कोई फ़ॉन्ट उपलब्ध है लेकिन उसमें समर्पित बोल्ड टाइपफ़ेस नहीं है, तो देखें [समर्पित बोल्ड टाइपफ़ेस के बिना फ़ॉन्ट को संभालें](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)। वह अनुभाग PDF निर्यात के दौरान प्रभावित पाठ को रास्टराइज़ करने और पाठ चयन, खोज और स्केलिंग के परिणामों को समझाता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

प्रेज़ेंटेशन के रेंडर होने पर कौन से फ़ॉन्ट प्रतिस्थापित होंगे, यह निर्धारित करने के लिए आप [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) मेथड का उपयोग कर सकते हैं। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट्स लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करते हैं।

निम्नलिखित JavaScript उदाहरण प्रस्तुति के सभी फ़ॉन्ट प्रतिस्थापन को सूचीबद्ध करता है:

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

## **चयनित स्लाइडों के लिए फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

आप [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) ओवरलोड को स्लाइड इंडेक्स की एक array के साथ उपयोग करके केवल विशिष्ट स्लाइडों को रेंडर करने के लिए आवश्यक प्रतिस्थापनों की जांच कर सकते हैं। यह उपयोगी है जब आप प्रस्तुति का केवल हिस्सा रेंडर या निर्यात कर रहे हों, बड़े प्रस्तुति को क्रमबद्ध रूप से जाँच रहे हों, उन स्लाइडों को ढूँढ़ रहे हों जो अनुपलब्ध फ़ॉन्ट पर निर्भर हैं, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या असंबंधित स्लाइडों को प्रोसेस किए बिना रेंडरिंग अंतर को निदान कर रहे हों।

ओवरलोड एक Java मूल `int[]` की अपेक्षा करता है। इसे `java.newArray("int", [...])` के साथ बनाएँ; एक सामान्य JavaScript array को `Integer[]` में बदल दिया जाता है और यह ओवरलोड से मेल नहीं खाता।

यह array एक‑आधारित स्लाइड इंडेक्स रखता है: `1` पहला स्लाइड दर्शाता है। इसके विपरीत, [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) संग्रह अभिगमकर्ता शून्य‑आधारित अनुक्रमणिका उपयोग करता है, इसलिए वही स्लाइड `presentation.getSlides().get_Item(0)` के रूप में पहुँचता है। इस अंतर को ध्यान में रखें ताकि array बनाते समय ऑफ‑बाय‑वन त्रुटि न हो।

ओवरलोड को [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/) के माध्यम से कॉल करें। यह केवल चयनित स्लाइडों को रेंडर करने के दौरान निर्धारित प्रतिस्थापन लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम शामिल होते हैं। परिणाम वर्तमान फ़ॉन्ट वातावरण, कॉन्फ़िगर की गई फॉलबैक नियम, एक [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, और [बाहरी फ़ॉन्ट](/slides/hi/nodejs-java/custom-font/) को दर्शाता है।

एक ही प्रतिस्थापन अधिक से अधिक चयनित स्लाइडों द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंट्री या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को डिडुप्लिकेट करें। निम्नलिखित उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग्स की सॉर्टेड सूची बनाता है:

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

[FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) क्लास दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | कब उपयोग करें |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) बिना किसी तर्क के | आपको सम्पूर्ण प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) एक Java `int[]` स्लाइड इंडेक्स के साथ | आपको चयनित रेंज, क्रमबद्ध जाँच, या आंशिक निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम सेट करें**

जब स्रोत फ़ॉन्ट उपलब्ध नहीं हो तो Aspose.Slides को उपयोग करने के लिए फ़ॉन्ट निर्दिष्ट करने के लिए:

1. प्रस्तुति को लोड करें।
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएं।
3. एक [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) को [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/) शर्त के साथ बनाएं।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. संग्रह को [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) मेथड का उपयोग करके असाइन करें।
6. प्रस्तुति को रेंडर या रूपांतरित करें।

निम्नलिखित JavaScript उदाहरण `SomeRareFont` उपलब्ध न होने पर `Arial` को प्रतिस्थापित करता है, और फिर पहले स्लाइड को रेंडर करके परिणाम की जाँच करता है। प्रतिस्थापन फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

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
प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट को बिना शर्त बदलने के लिए, देखें [Font Replacement](/slides/hi/nodejs-java/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्टों के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान उपयोग की जाने वाली मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं। वे नियमित पाठ के लिए काम करते हैं जब Aspose.Slides निर्दिष्ट नियम के अनुसार एक उपलब्ध फ़ॉन्ट से अनुपलब्ध फ़ॉन्ट को बदल सकता है।

Office Math समीकरणों में अतिरिक्त आवश्यकता होती है। यदि कोई समीकरण **Cambria Math** का उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडर करने के लिए ठीक वही फ़ॉन्ट चाहिए हो सकता है। कोई नियम जो किसी अन्य गणित फ़ॉन्ट, जैसे **STIX Two Math**, को प्रतिस्थापित करता है, वह इस उद्देश्य के लिए **Cambria Math** को बदल नहीं सकता, और रेंडरिंग अभी भी रिपोर्ट कर सकती है कि **Cambria Math** आवश्यक है।

ऐसी प्रस्तुति को रेंडर या रूपांतरित करने के लिए, **Cambria Math** को Aspose.Slides के लिए उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में स्थापित करें या इसे एक [बाहरी फ़ॉन्ट](/slides/hi/nodejs-java/custom-font/) के रूप में लोड करें।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति पाठ पर अभी भी लागू होते हैं।

## **FAQ**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट बदलने में क्या अंतर है?**

[Font replacement](/slides/hi/nodejs-java/font-replacement/) पूरे प्रस्तुति में एक फ़ॉन्ट को जानबूझकर दूसरे फ़ॉन्ट से बदलता है। फ़ॉन्ट प्रतिस्थापन तब रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है जब निर्धारित शर्त पूरी होती है, जैसे मूल फ़ॉन्ट अनुपलब्ध होना।

**प्रतिस्थापन नियम कब लागू होते हैं?**

नियम रेंडरिंग और रूपांतरण के दौरान [फ़ॉन्ट चयन क्रम](/slides/hi/nodejs-java/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब प्रयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं सकता।

**जब फ़ॉन्ट अनुपलब्ध हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकटतम उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम वातावरण में उपलब्ध फ़ॉन्ट पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिए बाहरी फ़ॉन्ट लोड कर सकता हूँ?**

हाँ। आप [बाहरी फ़ॉन्ट](/slides/hi/nodejs-java/custom-font/) लोड कर सकते हैं ताकि Aspose.Slides उन्हें रेंडरिंग और रूपांतरण के दौरान उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करने और उनके लाइसेंस का पालन करने की जिम्मेदारी आपके ऊपर है।

**क्या प्रतिस्थापन परिणाम Windows, Linux और macOS में अलग-अलग हो सकते हैं?**

हाँ। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार अलग होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरे पर प्रतिस्थापन की आवश्यकता पैदा कर सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे बनाऊँ?**

हर मशीन या कंटेनर पर समान फ़ॉन्ट फ़ाइलें और संस्करण रखें, आवश्यक [बाहरी फ़ॉन्ट](/slides/hi/nodejs-java/custom-font/) लोड करें, और लाइसेंस अनुमति दे तो [फ़ॉन्ट एम्बेड](/slides/hi/nodejs-java/embedded-font/) करें। आप निर्यात से पहले अप्रत्याशित प्रतिस्थापन पहचानने के लिए [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) भी कॉल कर सकते हैं।