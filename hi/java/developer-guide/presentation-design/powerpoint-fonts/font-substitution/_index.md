---
title: जावा का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें
linktitle: फ़ॉन्ट प्रतिस्थापन
type: docs
weight: 70
url: /hi/java/font-substitution/
keywords:
- फ़ॉन्ट
- विकल्प फ़ॉन्ट
- फ़ॉन्ट प्रतिस्थापन
- फ़ॉन्ट बदलें
- फ़ॉन्ट प्रतिस्थापन
- प्रतिस्थापन नियम
- बदलाव नियम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या रूपांतरण करते समय फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट्स की जाँच करें।"
---
## **अवलोकन**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को प्रस्तुतिकरण के रेंडर या रूपांतरण के दौरान उन फ़ॉन्टों के स्थान पर उपलब्ध फ़ॉन्ट का उपयोग करने की अनुमति देता है जिन्हें पहुँच नहीं मिल पाती है। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति की सामग्री को सौंपे गए फ़ॉन्ट को नहीं बदलता है।

आप किसी विशेष फ़ॉन्ट के अनुपलब्ध होने पर उपयोग किए जाने वाले फ़ॉन्ट को परिभाषित कर सकते हैं, और आप Aspose.Slides द्वारा रेंडरिंग के दौरान किए जाने वाले प्रतिस्थापनों को निरीक्षण कर सकते हैं। यह विभिन्न स्थापित फ़ॉन्ट वाले वातावरणों में आउटपुट को सुसंगत रखने में मदद करता है।

यदि कोई फ़ॉन्ट उपलब्ध है लेकिन उसके पास समर्पित बोल्ड टाइपफेस नहीं है, तो देखें [Handle Fonts Without a Dedicated Bold Typeface](/slides/hi/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)। वह अनुभाग उल्लेख करता है कि PDF निर्यात के दौरान प्रभावित टेक्स्ट को कैसे रास्टराईज़ किया जाए और टेक्स्ट चयन, खोज और स्केलिंग पर इसके परिणाम क्या होते हैं।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

फ़ॉन्ट प्रतिस्थापन निर्धारित करने के लिए [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) मेथड का उपयोग करें जब प्रस्तुतिकरण रेंडर किया जाता है। यह मेथड उन [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट्स को लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करते हैं।

निम्नलिखित जावा उदाहरण एक प्रस्तुतिकरण के सभी फ़ॉन्ट प्रतिस्थापनों को सूचीबद्ध करता है:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **चयनित स्लाइड्स के लिए फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

`int[] slides` तर्क के साथ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) ओवरलोड का उपयोग करके केवल विशिष्ट स्लाइड्स को रेंडर करने के लिए आवश्यक प्रतिस्थापनों को निरीक्षण करें। यह तब उपयोगी होता है जब आप प्रस्तुतिकरण का कोई भाग रेंडर या निर्यात कर रहे हों, बड़े प्रस्तुतिकरण को क्रमिक रूप से जाँच रहे हों, उन स्लाइड्स को खोज रहे हों जिनमें अनुपलब्ध फ़ॉन्ट पर निर्भरता है, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या अप्रासंगिक स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर का निदान कर रहे हों।

`slides` ऐरे में एक-आधारित स्लाइड सूचकांक होते हैं: `1` पहला स्लाइड दर्शाता है। इसके विपरीत, [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) कलेक्शन एक्सेसर शून्य-आधारित इंडेक्सिंग का उपयोग करता है, इसलिए वही स्लाइड `presentation.getSlides().get_Item(0)` के रूप में पहुँचता है। इस अंतर को ऐरे बनाते समय ध्यान में रखें ताकि ऑफ‑बाय‑वन त्रुटियों से बचा जा सके।

ओवरलोड को [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) मेथड के माध्यम से कॉल करें। यह केवल चयनित स्लाइड्स को रेंडर करते समय निर्धारित प्रतिस्थापनों को लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम शामिल होते हैं। परिणाम वर्तमान फ़ॉन्ट वातावरण, कॉन्फ़िगर किए गए फ़ॉलबैक नियमों, और [externally loaded fonts](/slides/hi/java/custom-font/) को दर्शाता है। एक [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियमों को प्रस्तुतिकरण के रेंडर होने पर लागू किया जाता है, लेकिन परिणाम में उनका उल्लेख नहीं होता; इसके बजाय आउटपुट फ़ाइल में फ़ॉन्ट्स की जाँच करें।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइड्स द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंट्री या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को डिडुप्लिकेट करें। निम्नलिखित उदाहरण हर लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की सॉर्टेड सूची बनाता है:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

[IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) इंटरफ़ेस दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | कब उपयोग करें |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) बिना आर्ग्यूमेंट्स के | आपको पूरे प्रस्तुतिकरण के लिए प्रतिस्थापन चाहिए। |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) `int[] slides` के साथ | आपको चयनित रेंज, क्रमिक जाँच, या आंशिक निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम सेट करें**

जब स्रोत फ़ॉन्ट अनुपलब्ध हो तो Aspose.Slides को उपयोग करने वाले फ़ॉन्ट को निर्दिष्ट करने के लिए:

1. प्रस्तुतिकरण लोड करें।
2. स्रोत और प्रतिस्थापन फ़ॉन्ट्स के लिए फ़ॉन्ट परिभाषाएँ बनाएँ।
3. [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) को [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/) शर्त के साथ बनाएँ।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. संग्रह को [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) मेथड का उपयोग करके असाइन करें।
6. प्रस्तुतिकरण को रेंडर या रूपांतरण करें।

निम्नलिखित जावा उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम सत्यापित करने के लिए पहला स्लाइड रेंडर करता है। प्रतिस्थापित फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
पूरा प्रस्तुतिकरण पर फ़ॉन्ट्स में बिना शर्त परिवर्तन के लिए देखें [Font Replacement](/slides/hi/java/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्ट्स के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान उपयोग की जाने वाली मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा होते हैं। वे तब काम करते हैं जब Aspose.Slides किसी अनुपलब्ध फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

ऑफ़िस मैथ समीकरणों में एक अतिरिक्त आवश्यकता होती है। यदि किसी समीकरण में **Cambria Math** उपयोग किया गया है, तो Aspose.Slides को लेआउट की गणना और रेंडर करने के लिए वही फ़ॉन्ट चाहिए हो सकता है। ऐसी नियम जो किसी अन्य गणित फ़ॉन्ट, जैसे **STIX Two Math**, को प्रतिस्थापित करते हैं, **Cambria Math** को इस उद्देश्य के लिए बदल नहीं सकते, और रेंडरिंग अभी भी यह रिपोर्ट कर सकती है कि **Cambria Math** आवश्यक है।

ऐसे प्रस्तुतिकरण को रेंडर या रूपांतरण करने के लिए, **Cambria Math** को Aspose.Slides के पास उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में स्थापित करें या एक [external font](/slides/hi/java/custom-font/) के रूप में लोड करें।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति टेक्स्ट पर अभी भी लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट प्रतिस्थापन में क्या अंतर है?**

[Font replacement](/slides/hi/java/font-replacement/) इरादतन पूरे प्रस्तुतिकरण में एक फ़ॉन्ट को दूसरे से बदल देता है। फ़ॉन्ट प्रतिस्थापन रेंडर किए गए आउटपुट के लिए तब फ़ॉन्ट चुनता है जब कॉन्फ़िगर की गई शर्त पूरी होती है, जैसे मूल फ़ॉन्ट अनुपलब्ध होना।

**प्रतिस्थापन नियम कब लागू होते हैं?**

ये नियम रेंडरिंग और रूपांतरण के दौरान [font selection sequence](/slides/hi/java/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग होता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं सकता।

**जब फ़ॉन्ट अनुपलब्ध हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे नज़दीकी उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम पर्यावरण में उपलब्ध फ़ॉन्ट्स पर निर्भर करता है।

**क्या मैं बाहरी फ़ॉन्ट लोड करके प्रतिस्थापन से बच सकता हूँ?**

हाँ। आप [load external fonts](/slides/hi/java/custom-font/) कर सकते हैं ताकि Aspose.Slides रेंडरिंग और रूपांतरण के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करना और उनके लाइसेंस का पालन करना आपका दायित्व है।

**क्या प्रतिस्थापन परिणाम Windows, Linux, और macOS में भिन्न हो सकते हैं?**

हाँ। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार अलग‑अलग होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरे पर प्रतिस्थापन की आवश्यकता बना सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे रखें?**

हर मशीन या कंटेनर पर एक ही फ़ॉन्ट फ़ाइलें और संस्करण उपयोग करें, [load required external fonts](/slides/hi/java/custom-font/) करें, और लाइसेंस की अनुमति होने पर [embed fonts](/slides/hi/java/embedded-font/) का उपयोग करें। आप निर्यात से पहले अप्रत्याशित प्रतिस्थापनों की पहचान के लिए [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) भी कॉल कर सकते हैं।