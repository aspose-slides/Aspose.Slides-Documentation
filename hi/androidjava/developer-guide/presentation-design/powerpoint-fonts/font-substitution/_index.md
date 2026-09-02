---
title: Android पर प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर करें
linktitle: फ़ॉन्ट प्रतिस्थापन
type: docs
weight: 70
url: /hi/androidjava/font-substitution/
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
- प्रस्तुतिकरण
- Android
- Java
- Aspose.Slides
description: "रेंडरिंग या प्रस्तुतियों को परिवर्तित करते समय Java के माध्यम से Android के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट की जाँच करें।"
---
## **परिचय**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को किसी उपलब्ध फ़ॉन्ट का उपयोग करने की अनुमति देता है जब प्रस्तुतिकरण को रेंडर या परिवर्तित किया जाता है और मूल फ़ॉन्ट उपलब्ध नहीं होता। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुतिकरण की सामग्री को असाइन किए गए फ़ॉन्ट को नहीं बदलता।

आप किसी विशिष्ट फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिए फ़ॉन्ट निर्धारित कर सकते हैं, और आप Aspose.Slides द्वारा रेंडरिंग के दौरान किए जाने वाले प्रतिस्थापनों की जाँच कर सकते हैं। यह विभिन्न Android डिवाइसों और विभिन्न उपलब्ध फ़ॉन्ट वाले वातावरणों में आउटपुट को सुसंगत रखने में मदद करता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

उपलब्ध फ़ॉन्ट को निर्धारित करने के लिए जब प्रस्तुतिकरण रेंडर किया जाता है तो कौन‑से फ़ॉन्ट प्रतिस्थापित किए जाएंगे, [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) मेथड का उपयोग करें। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करता है।

निम्नलिखित Java उदाहरण एक प्रस्तुतिकरण के सभी फ़ॉन्ट प्रतिस्थापन को सूचीबद्ध करता है:

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

`int[] slides` आर्ग्यूमेंट के साथ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) ओवरलोड का उपयोग करके आप केवल उन स्लाइड्स के लिए आवश्यक प्रतिस्थापनों की जाँच कर सकते हैं जिन्हें आप रेंडर करना चाहते हैं। यह तब उपयोगी होता है जब आप प्रस्तुतिकरण के किसी हिस्से को रेंडर या निर्यात कर रहे हों, बड़े प्रस्तुतिकरण को क्रमिक रूप से जांच रहे हों, उन स्लाइड्स को ढूँढ़ रहे हों जिनके लिए अनुपलब्ध फ़ॉन्ट की आवश्यकता है, Android एप्लिकेशन के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या असंबंधित स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर को निदान करना चाहते हों।

`slides` एरे में एक‑आधारित स्लाइड इंडेक्स होते हैं: `1` पहला स्लाइड दर्शाता है। इसके विपरीत, [Presentation.getSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlides--) संग्रह एक्सेसर शून्य‑आधारित इंडेक्सिंग का उपयोग करता है, इसलिए वही स्लाइड `presentation.getSlides().get_Item(0)` के रूप में पहुंचा जाता है। एरे बनाते समय इस अंतर को ध्यान में रखें ताकि ऑफ‑बाय‑वन त्रुटियों से बचा जा सके।

ओवरलोड को [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getFontsManager--) मेथड के माध्यम से कॉल करें। यह केवल चयनित स्लाइड्स को रेंडर करते समय निर्धारित किए गए प्रतिस्थापन लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम होते हैं। परिणाम वर्तमान फ़ॉन्ट वातावरण, कॉन्फ़िगर किए गए फ़ॉलबैक नियम, [IFontSubstRuleCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, और [बाहरी रूप से लोड किए गए फ़ॉन्ट](/slides/hi/androidjava/custom-font/) को प्रतिबिंबित करता है।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइड द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंट्री या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को डिडुप्लिकेट करें। निम्नलिखित उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की क्रमबद्ध सूची बनाता है:

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

[IFontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/) इंटरफ़ेस दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | कब उपयोग करें |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) बिना आर्ग्यूमेंट के | आपको पूरी प्रस्तुतिकरण के लिए प्रतिस्थापन चाहिए। |
| [getSubstitutions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) `int[] slides` के साथ | आपको चयनित रेंज, क्रमिक जांच, या आंशिक निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम निर्धारित करें**

जब स्रोत फ़ॉन्ट उपलब्ध नहीं हो तो Aspose.Slides को उपयोग करने के लिए फ़ॉन्ट निर्दिष्ट करने के लिए:

1. प्रस्तुतिकरण लोड करें।
2. स्रोत और प्रतिस्थापित फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएं।
3. [WhenInaccessible](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsubstcondition/) शर्त के साथ एक [FontSubstRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsubstrule/) बनाएं।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. संग्रह को [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) मेथड द्वारा असाइन करें।
6. प्रस्तुतिकरण को रेंडर या परिवर्तित करें।

निम्नलिखित Java उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम सत्यापित करने के लिए पहला स्लाइड रेंडर करता है। प्रतिस्थापित फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

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
पूरे प्रस्तुतिकरण में उपयोग किए जाने वाले फ़ॉन्ट को बिना शर्त बदलने के लिए, देखें [Font Replacement](/slides/hi/androidjava/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्ट के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान उपयोग की जाने वाली मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं। ये सामान्य पाठ के लिए काम करते हैं जब Aspose.Slides अनुपलब्ध फ़ॉन्ट को नियत फ़ॉन्ट से बदल सकता है।

Office Math समीकरणों की एक अतिरिक्त आवश्यकता होती है। यदि कोई समीकरण **Cambria Math** का उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडरिंग के लिए ठीक वही फ़ॉन्ट चाहिए हो सकता है। एक नियम जो किसी अन्य गणित फ़ॉन्ट, जैसे **STIX Two Math**, को प्रतिस्थापित करता है, वह इस प्रयोजन के लिए **Cambria Math** की जगह नहीं ले सकता, और रेंडरिंग अभी भी यह रिपोर्ट कर सकता है कि **Cambria Math** आवश्यक है।

ऐसे प्रस्तुतिकरण को रेंडर या रूपांतरित करने के लिए, **Cambria Math** को Aspose.Slides के लिए उपलब्ध कराएं। इसे एक [बाहरी फ़ॉन्ट](/slides/hi/androidjava/custom-font/) के रूप में लोड करें ताकि एप्लिकेशन रेंडरिंग और रूपांतरण के दौरान इसका उपयोग कर सके।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति पाठ पर अभी भी लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट प्रतिस्थापन (replacement) में क्या अंतर है?**

[Font replacement](/slides/hi/androidjava/font-replacement/) पूरे प्रस्तुतिकरण में एक फ़ॉन्ट को दूसरे में इरादतन बदलता है। फ़ॉन्ट प्रतिस्थापन तब रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है जब कॉन्फ़िगर की गई शर्त पूरी होती है, जैसे मूल फ़ॉन्ट उपलब्ध नहीं होने पर।

**प्रतिस्थापन नियम कब लागू होते हैं?**

इन नियमों का भाग [फ़ॉन्ट चयन क्रम](/slides/hi/androidjava/font-selection-sequence/) में रेंडरिंग और रूपांतरण के दौरान होता है। `WhenInaccessible` के साथ, नियम केवल तभी उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं सकता।

**जब फ़ॉन्ट अनुपलब्ध हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकटतम उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम वातावरण में उपलब्ध फ़ॉन्ट पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिए बाहरी फ़ॉन्ट लोड कर सकता हूँ?**

हाँ। आप [बाहरी फ़ॉन्ट लोड कर सकते हैं](/slides/hi/androidjava/custom-font/) ताकि Aspose.Slides उन्हें रेंडरिंग और रूपांतरण के दौरान उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करना और उनके लाइसेंस का पालन करना आपका उत्तरदायित्व है।

**क्या प्रतिस्थापन परिणाम Android डिवाइसों के बीच अलग हो सकते हैं?**

हाँ। विभिन्न Android संस्करणों, डिवाइसों और विक्रेताओं में उपलब्ध सिस्टम फ़ॉन्ट अलग हो सकते हैं, इसलिए एक वातावरण में उपलब्ध फ़ॉन्ट दूसरे में प्रतिस्थापन की आवश्यकता पड़ सकती है।

**मैं Android डिवाइसों के बीच फ़ॉन्ट चयन को सुसंगत कैसे बना सकता हूँ?**

आवश्यक फ़ॉन्ट फ़ाइलें एप्लिकेशन के साथ समान रूप से पैकेज करें, उन्हें [बाहरी फ़ॉन्ट के रूप में लोड करें](/slides/hi/androidjava/custom-font/), और लाइसेंस की अनुमति होने पर [फ़ॉन्ट एम्बेड करें](/slides/hi/androidjava/embedded-font/)। निर्यात से पहले अप्रत्याशित प्रतिस्थापनों की पहचान करने के लिए आप [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) को भी कॉल कर सकते हैं।