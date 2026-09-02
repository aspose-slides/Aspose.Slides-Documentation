---
title: जावा का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर करें
linktitle: फ़ॉन्ट प्रतिस्थापन
type: docs
weight: 70
url: /hi/java/font-substitution/
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
- Java
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या रूपांतरित करते समय Aspose.Slides for Java में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट की जांच करें।"
---
## **Overview**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को प्रस्तुति के रेंडर या रूपांतरण के समय किसी अनुपलब्ध फ़ॉन्ट के स्थान पर उपलब्ध फ़ॉन्ट उपयोग करने की अनुमति देता है। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति सामग्री को सौंपे गए फ़ॉन्ट को नहीं बदलता।

आप किसी विशेष फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिए फ़ॉन्ट निर्धारित कर सकते हैं, और आप उन प्रतिस्थापनों को निरीक्षण कर सकते हैं जो Aspose.Slides रेंडरिंग के दौरान करेगा। यह विभिन्न स्थापित फ़ॉन्ट वाले वातावरणों में आउटपुट को सुसंगत रखने में मदद करता है।

## **Get Font Substitutions**

उपलब्ध फ़ॉन्टों को निर्धारित करने के लिए [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) मेथड का उपयोग करें जब प्रस्तुति रेंडर की जाती है। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट्स लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करते हैं।

निम्नलिखित Java उदाहरण एक प्रस्तुति के सभी फ़ॉन्ट प्रतिस्थापन को सूचीबद्ध करता है:

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

## **Get Font Substitutions for Selected Slides**

विशिष्ट स्लाइड्स को रेंडर करने के लिए आवश्यक प्रतिस्थापन को केवल निरीक्षण करने हेतु `int[] slides` तर्क के साथ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) ओवरलोड का प्रयोग करें। यह तब उपयोगी होता है जब आप प्रस्तुति के कुछ भाग को रेंडर या एक्सपोर्ट कर रहे हों, बड़े प्रस्तुति को क्रमिक रूप से जांच रहे हों, उन स्लाइड्स को ढूंढ़ रहे हों जिनके लिए अभिगम्य नहीं फ़ॉन्ट आवश्यक हैं, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या असंबंधित स्लाइड्स को प्रोसेस किए बिना रेंडर अंतर को निदान कर रहे हों।

`slides` एरे एक‑आधारित स्लाइड इंडेक्स रखता है: `1` प्रथम स्लाइड को पहचानता है। इसके विपरीत, [Presentation.getSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlides--) संग्रह अभिगामक शून्य‑आधारित अनुक्रमण का उपयोग करता है, इसलिए वही स्लाइड `presentation.getSlides().get_Item(0)` द्वारा पहुंची जाती है। एरे बनाते समय इस अंतर को ध्यान में रखें ताकि ऑफ‑बाय‑वन त्रुटियों से बचा जा सके।

ओवरलोड को [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getFontsManager--) मेथड के माध्यम से कॉल करें। यह केवल चयनित स्लाइड्स को रेंडर करते समय निर्धारित प्रतिस्थापनों को लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम शामिल होते हैं। परिणाम वर्तमान फ़ॉन्ट वातावरण, कॉन्फ़िगर किए गए फ़ॉलबैक नियम, [IFontSubstRuleCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, और [externally loaded fonts](/slides/hi/java/custom-font/) को प्रतिबिंबित करता है।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइड द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंट्री या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को डिडुप्लिकेट करें। निम्नलिखित उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की सॉर्टेड सूची बनाता है:

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

[IFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/) इंटरफ़ेस दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक को चुनें:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | आपको संपूर्ण प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | आपको चयनित रेंज, क्रमिक जांच, या भागिक एक्सपोर्ट के लिए प्रतिस्थापन चाहिए। |

## **Set Font Substitution Rules**

जब स्रोत फ़ॉन्ट उपलब्ध न हो तो Aspose.Slides को किस फ़ॉन्ट का उपयोग करना चाहिए, इसे निर्दिष्ट करने के लिए:

1. प्रस्तुति लोड करें।  
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएं।  
3. [WhenInaccessible](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsubstcondition/) स्थिति के साथ एक [FontSubstRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsubstrule/) बनाएं।  
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsubstrulecollection/) में जोड़ें।  
5. संग्रह को [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) मेथड का उपयोग करके असाइन करें।  
6. प्रस्तुति को रेंडर या रूपांतरित करें।

निम्नलिखित Java उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम सत्यापित करने के लिए पहली स्लाइड को रेंडर करता है। प्रतिस्थापित फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

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
पूरी प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट को बिना शर्त बदलने के लिए, देखें [Font Replacement](/slides/hi/java/font-replacement/)।
{{% /alert %}}

## **Limitations for Math Equation Fonts**

फ़ॉन्ट प्रतिस्थापन नियम मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं जो रेंडरिंग और रूपांतर में उपयोग की जाती है। वे नियमित टेक्स्ट के लिए काम करते हैं जब Aspose.Slides एक अभिगम्य नहीं फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

Office Math समीकरणों में अतिरिक्त आवश्यकता होती है। यदि कोई समीकरण **Cambria Math** का उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडर करने के लिए वही फ़ॉन्ट आवश्यक हो सकता है। ऐसा नियम जो किसी अन्य गणित फ़ॉन्ट, जैसे **STIX Two Math**, को प्रतिस्थापित करता है, **Cambria Math** को इस उद्देश्य के लिए नहीं बदल सकता, और रेंडरिंग अभी भी रिपोर्ट कर सकती है कि **Cambria Math** आवश्यक है।

ऐसी प्रस्तुति को रेंडर या रूपांतरित करने के लिए, **Cambria Math** को Aspose.Slides के लिए उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में इंस्टॉल करें या एक [external font](/slides/hi/java/custom-font/) के रूप में लोड करें।

यह प्रतिबंध समीकरण लेआउट पर लागू होता है। ऊपर वर्णित प्रतिस्थापन नियम अभी भी सामान्य प्रस्तुति टेक्स्ट पर लागू होते हैं।

## **FAQ**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट प्रतिस्थापन में क्या अंतर है?**

[Font replacement](/slides/hi/java/font-replacement/) जानबूझकर प्रस्तुति में एक फ़ॉन्ट को दूसरे फ़ॉन्ट में बदलता है। फ़ॉन्ट प्रतिस्थापन तब रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है जब कॉन्फ़िगर की गई स्थिति पूरी होती है, जैसे मूल फ़ॉन्ट अनुपलब्ध हो।

**प्रतिस्थापन नियम कब लागू होते हैं?**

ये नियम रेंडरिंग और रूपांतरण के दौरान [font selection sequence](/slides/hi/java/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं सकता।

**जब फ़ॉन्ट गायब हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे नज़दीकी उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम वातावरण में उपलब्ध फ़ॉन्टों पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिए बाहरी फ़ॉन्ट लोड कर सकता हूँ?**

हां। आप [load external fonts](/slides/hi/java/custom-font/) कर सकते हैं ताकि Aspose.Slides उन्हें रेंडरिंग और रूपांतरण के दौरान उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करने और उनके लाइसेंस का अनुपालन करने की जिम्मेदारी आपके ऊपर है।

**क्या प्रतिस्थापन परिणाम Windows, Linux और macOS में भिन्न हो सकते हैं?**

हां। ऑपरेटिंग सिस्टम के अनुसार स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान अलग होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरे पर प्रतिस्थापन की आवश्यकता पैदा कर सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे रखें?**

हर मशीन या कंटेनर पर एक ही फ़ॉन्ट फ़ाइलें और संस्करण उपयोग करें, [load required external fonts](/slides/hi/java/custom-font/) करें, और लाइसेंस की अनुमति होने पर [embed fonts](/slides/hi/java/embedded-font/) करें। आप निर्यात से पहले अप्रत्याशित प्रतिस्थापन पहचानने के लिए [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) को भी कॉल कर सकते हैं।