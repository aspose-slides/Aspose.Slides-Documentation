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
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "प्रस्तुति को रेंडर या कनवर्ट करते समय Java के माध्यम से Android के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट की जाँच करें।"
---
## **परिचय**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को प्रस्तुति को रेंडर या कनवर्ट करते समय उन फ़ॉन्टों की जगह उपलब्ध फ़ॉन्ट का उपयोग करने देता है जिन्हें एक्सेस नहीं किया जा सकता। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति की सामग्री को सौंपे गए फ़ॉन्ट को नहीं बदलता।

आप किसी विशिष्ट फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिए फ़ॉन्ट निर्धारित कर सकते हैं, और Aspose.Slides द्वारा रेंडरिंग के दौरान किए गए प्रतिस्थापनों का निरीक्षण कर सकते हैं। यह Android डिवाइसों और विभिन्न उपलब्ध फ़ॉन्ट वाले वातावरणों में आउटपुट को सुसंगत रखने में मदद करता है।

यदि कोई फ़ॉन्ट उपलब्ध है लेकिन उसकी समर्पित बोल्ड टाइपफ़ेस नहीं है, तो देखें [समर्पित बोल्ड टाइपफ़ेस के बिना फ़ॉन्ट संभालें](/slides/hi/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)। वह अनुभाग PDF निर्यात के दौरान प्रभावित टेक्स्ट को रास्टराइज़ करने और टेक्स्ट चयन, खोज और स्केलिंग पर प्रभावों को समझाता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

प्रस्तुति रेंडर होने पर कौन से फ़ॉन्ट प्रतिस्थापित किए जाएंगे, यह निर्धारित करने के लिए [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) मेथड का उपयोग करें। यह मेथड मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करने वाले [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट लौटाता है।

निम्नलिखित Java उदाहरण प्रस्तुति के सभी फ़ॉन्ट प्रतिस्थापनों को सूचीबद्ध करता है:

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

## **चुने हुए स्लाइड्स के लिए फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

विशिष्ट स्लाइड्स को रेंडर करने के लिए आवश्यक प्रतिस्थापनों का निरीक्षण करने हेतु `int[] slides` आर्ग्यूमेंट के साथ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) ओवरलोड का उपयोग करें। यह उपयोगी है जब आप प्रस्तुति का भाग रेंडर या एक्सपोर्ट कर रहे हों, बड़े प्रस्तुति को चरणबद्ध जांच रहे हों, उन स्लाइड्स को खोज रहे हों जो अनुपलब्ध फ़ॉन्ट पर निर्भर हैं, Android ऐप के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या अप्रासंगिक स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर का निदान कर रहे हों।

`slides` ऐरे एक-आधारित स्लाइड सूचकांक रखता है: `1` पहला स्लाइड दर्शाता है। इसके विपरीत, [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) कलेक्शन एक्सेसर शून्य-आधारित इंडेक्सिंग का उपयोग करता है, इसलिए वही स्लाइड `presentation.getSlides().get_Item(0)` के रूप में पहुँचा जाता है। ऐरे बनाते समय इस अंतर को ध्यान में रखें ताकि ऑफ‑बाइ‑वन त्रुटियों से बचा जा सके।

[Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) मेथड के माध्यम से ओवरलोड को कॉल करें। यह केवल चुनी गई स्लाइड्स के रेंडरिंग के दौरान निर्धारित प्रतिस्थापन लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम होते हैं। परिणाम वर्तमान फ़ॉन्ट वातावरण, कॉन्फ़िगर किए गए फॉलबैक नियमों, एक [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियमों, और [externally loaded fonts](/slides/hi/androidjava/custom-font/) को दर्शाता है।

एक ही प्रतिस्थापन एक से अधिक चुनी हुई स्लाइड द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंटरी या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को डिडुप्लीकेट करें। निम्नलिखित उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की सॉर्टेड सूची बनाता है:

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

[IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) इंटरफ़ेस दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | कब उपयोग करें |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) बिना आर्ग्यूमेंट के | आपको पूरे प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) `int[] slides` के साथ | आपको चयनित रेंज, चरणबद्ध जाँच, या आंशिक निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम सेट करें**

जब स्रोत फ़ॉन्ट अनुपलब्ध हो, तो Aspose.Slides को उपयोग करने वाले फ़ॉन्ट को निर्दिष्ट करने के लिए:

1. प्रस्तुति लोड करें।
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएं।
3. [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/) स्थिति के साथ एक [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) बनाएं।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) मेथड का उपयोग करके कलेक्शन असाइन करें।
6. प्रस्तुति को रेंडर या कनवर्ट करें।

निम्नलिखित Java उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम की पुष्टि के लिए पहला स्लाइड रेंडर करता है। प्रतिस्थापित फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

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
पूरे प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट को बिना शर्त बदलने के लिए देखें [Font Replacement](/slides/hi/androidjava/font-replacement/)।
{{% /alert %}}

## **मैथ समीकरण फ़ॉन्ट्स के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और कन्वर्ज़न के दौरान उपयोग की जाने वाली मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं। वे तब काम करते हैं जब Aspose.Slides नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट के साथ अपर्याप्त फ़ॉन्ट को बदल सकता है।

Office Math समीकरणों के लिए अतिरिक्त आवश्यकता होती है। यदि कोई समीकरण **Cambria Math** का उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडर करने के लिए उसी फ़ॉन्ट की आवश्यकता हो सकती है। किसी अन्य गणित फ़ॉन्ट, जैसे **STIX Two Math**, को प्रतिस्थापित करने वाला नियम इस उद्देश्य के लिए **Cambria Math** को बदल नहीं सकता, और रेंडरिंग फिर भी रिपोर्ट कर सकती है कि **Cambria Math** आवश्यक है।

ऐसी प्रस्तुति को रेंडर या कनवर्ट करने के लिए, **Cambria Math** को Aspose.Slides के लिए उपलब्ध बनाएं। इसे एक [external font](/slides/hi/androidjava/custom-font/) के रूप में लोड करें ताकि एप्लिकेशन रेंडरिंग और कन्वर्ज़न के दौरान इसका उपयोग कर सके।

यह सीमा समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति टेक्स्ट पर अभी भी लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट प्रतिस्थापन (substitution) में अंतर क्या है?**

[Font replacement](/slides/hi/androidjava/font-replacement/) प्रस्तुति में एक फ़ॉन्ट को जानबूझकर दूसरे फ़ॉन्ट से बदलता है। फ़ॉन्ट प्रतिस्थापन तब रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है जब कॉन्फ़िगर किया गया शर्त पूरी होती है, जैसे मूल फ़ॉन्ट उपलब्ध न हो।

**प्रतिस्थापन नियम कब लागू होते हैं?**

ये नियम रेंडरिंग और कन्वर्ज़न के दौरान [font selection sequence](/slides/hi/androidjava/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुंच नहीं पा रहा हो।

**जब फ़ॉन्ट अनुपलब्ध हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकटतम उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम पर्यावरण में उपलब्ध फ़ॉन्ट पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिए बाहरी फ़ॉन्ट लोड कर सकता हूँ?**

हाँ। आप [load external fonts](/slides/hi/androidjava/custom-font/) कर सकते हैं ताकि Aspose.Slides रेंडरिंग और कन्वर्ज़न के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करने और उनके लाइसेंस का अनुपालन करने की जिम्मेदारी आपके ऊपर है।

**क्या प्रतिस्थापन परिणाम Android डिवाइसों के बीच भिन्न हो सकते हैं?**

हाँ। उपलब्ध सिस्टम फ़ॉन्ट Android संस्करण, डिवाइस और विक्रेताओं के बीच भिन्न हो सकते हैं, इसलिए एक पर्यावरण में उपलब्ध फ़ॉन्ट दूसरे में प्रतिस्थापन की आवश्यकता पड़ सकती है।

**मैं Android डिवाइसों में फ़ॉन्ट चयन को सुसंगत कैसे बनाऊँ?**

एक ही आवश्यक फ़ॉन्ट फ़ाइलों को एप्लिकेशन के साथ पैकेज करें, लाइसेंस की अनुमति होने पर उन्हें [load them as external fonts](/slides/hi/androidjava/custom-font/) और [embed fonts](/slides/hi/androidjava/embedded-font/) करें। आप निर्यात से पहले अनपेक्षित प्रतिस्थापनों की पहचान करने के लिए [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) भी कॉल कर सकते हैं।