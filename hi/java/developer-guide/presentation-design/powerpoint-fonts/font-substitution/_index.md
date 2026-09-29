---
title: जावा का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें
linktitle: फ़ॉन्ट प्रतिस्थापन
type: docs
weight: 70
url: /hi/java/font-substitution/
keywords:
- फ़ॉन्ट
- प्रतिस्थापन फ़ॉन्ट
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
description: "PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या परिवर्तित करते समय जावा के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट्स की जांच करें।"
---
## **सारांश**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को उपलब्ध फ़ॉन्ट का उपयोग करने देता है जब प्रस्तुति के रेंडर या रूपांतरण के दौरान किसी फ़ॉन्ट तक पहुंच संभव न हो। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति सामग्री को सौंपे गए फ़ॉन्ट को नहीं बदलता।

आप किसी विशेष फ़ॉन्ट की अनुपलब्धता पर उपयोग करने के लिए फ़ॉन्ट निर्धारित कर सकते हैं, और आप Aspose.Slides द्वारा रेंडरिंग के दौरान किए जाने वाले प्रतिस्थापनों की जांच कर सकते हैं। यह विभिन्न स्थापित फ़ॉन्ट वाले वातावरणों में आउटपुट को सुसंगत रखने में मदद करता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

प्रस्तुति के रेंडर होने पर किन फ़ॉन्टों का प्रतिस्थापन होगा, यह निर्धारित करने के लिए आप [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) मेथड का उपयोग कर सकते हैं। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट्स लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट के नाम पहचानते हैं।

निम्नलिखित Java उदाहरण प्रस्तुति के लिए सभी फ़ॉन्ट प्रतिस्थापनों की सूची देता है:

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

विशिष्ट स्लाइड्स को रेंडर करने के लिए आवश्यक प्रतिस्थापनों को ही जांचने हेतु `int[] slides` आर्ग्यूमेंट के साथ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) ओवरलोड का उपयोग करें। यह तब उपयोगी होता है जब आप प्रस्तुति के कुछ भाग को रेंडर या एक्सपोर्ट कर रहे हों, बड़े प्रस्तुति को क्रमिक रूप से जांच रहे हों, उन स्लाइड्स को ढूंढ़ रहे हों जो अनुपलब्ध फ़ॉन्ट पर निर्भर करती हैं, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या अप्रासंगिक स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर का निदान कर रहे हों।

`slides` एरे एक‑आधारित स्लाइड इंडेक्स रखता है: `1` पहली स्लाइड को पहचानता है। इसके विपरीत, [Presentation.getSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlides--) कलेक्शन एक्सेसर शून्य‑आधारित इंडेक्सिंग का उपयोग करता है, इसलिए वही स्लाइड `presentation.getSlides().get_Item(0)` के रूप में पहुँची जाती है। एरे बनाते समय इस अंतर को ध्यान में रखें ताकि ऑफ‑बाय‑वन त्रुटि न हो।

इस ओवरलोड को आप [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getFontsManager--) मेथड के माध्यम से कॉल कर सकते हैं। यह केवल चयनित स्लाइड्स को रेंडर करते समय निर्धारित किए गए प्रतिस्थापनों को लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम होते हैं। परिणाम वर्तमान फ़ॉन्ट पर्यावरण, कॉन्फ़िगर किए गए फॉलबैक नियम और [बाहरी रूप से लोड किए गए फ़ॉन्ट](/slides/hi/java/custom-font/) को दर्शाता है। प्रस्तुति रेंडर होने पर लागू होने वाले [IFontSubstRuleCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsubstrulecollection/) में संग्रहीत प्रतिस्थापना नियम प्रयोग किए जाते हैं, लेकिन परिणाम में उनका उल्लेख नहीं होता; इसके बजाय आउटपुट फ़ाइल में फ़ॉन्ट की जाँच करें।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइड द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंट्री या प्री‑फ्लाइट रिपोर्ट बनाते समय परिणामों को डुप्लिकेट हटाएँ। निम्नलिखित उदाहरण प्रत्येक प्राप्त प्रतिस्थापन की रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग्स की सॉर्टेड सूची बनाता है:

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

[IFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/) इंटरफ़ेस दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | इसकी आवश्यकता कब हो |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) बिना आर्ग्यूमेंट के | आपको पूरी प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) `int[] slides` के साथ | आपको चयनित रेंज, क्रमिक जांच या भागीय एक्सपोर्ट के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम सेट करें**

जब स्रोत फ़ॉन्ट उपलब्ध न हो तो Aspose.Slides को उपयोग करने वाले फ़ॉन्ट को निर्दिष्ट करने के लिए:

1. प्रस्तुति लोड करें।
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएं।
3. [WhenInaccessible](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsubstcondition/) शर्त के साथ एक [FontSubstRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsubstrule/) बनाएं।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) मेथड का उपयोग करके संग्रह को असाइन करें।
6. प्रस्तुति को रेंडर या रूपांतरित करें।

निम्नलिखित Java उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम की पुष्टि करने हेतु पहली स्लाइड को रेंडर करता है। प्रतिस्थापन फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

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
पूरी प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट्स में बिना शर्त परिवर्तन के लिए, Font Replacement देखें।
{{% /alert %}}

## **मैथ समीकरण फ़ॉन्ट्स के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान प्रयोग की जाने वाली मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं। वे सामान्य टेक्स्ट के लिए काम करते हैं जब Aspose.Slides किसी इनएक्सेसिबल फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

Office Math समीकरणों के लिए एक अतिरिक्त आवश्यकता होती है। यदि किसी समीकरण में **Cambria Math** उपयोग किया गया है, तो समीकरण लेआउट की गणना और रेंडरिंग के लिए Aspose.Slides को बिल्कुल वही फ़ॉन्ट चाहिए। **STIX Two Math** जैसा कोई अन्य गणित फ़ॉन्ट प्रतिस्थापित करने वाला नियम **Cambria Math** को इस उद्देश्य के लिये बदल नहीं सकता, और रेंडरिंग अभी भी यह रिपोर्ट कर सकता है कि **Cambria Math** आवश्यक है।

ऐसी प्रस्तुति को रेंडर या रूपांतरित करने हेतु, **Cambria Math** को Aspose.Slides के लिए उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में स्थापित करें या एक [बाहरी फ़ॉन्ट](/slides/hi/java/custom-font/) के रूप में लोड करें।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति टेक्स्ट पर अभी भी लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट रिप्लेसमेंट में क्या अंतर है?**  
[फ़ॉन्ट रिप्लेसमेंट](/slides/hi/java/font-replacement/) पूरी प्रस्तुति में एक फ़ॉन्ट को जानबूझकर दूसरे फ़ॉन्ट से बदलता है। फ़ॉन्ट प्रतिस्थापन तब रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है जब निर्धारित शर्त पूरी हो, जैसे कि मूल फ़ॉन्ट उपलब्ध न हो।

**प्रतिस्थापन नियम कब लागू होते हैं?**  
ये नियम रेंडरिंग और रूपांतरण के दौरान [फ़ॉन्ट चयन अनुक्रम](/slides/hi/java/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुंच नहीं सकता।

**जब फ़ॉन्ट उपलब्ध नहीं है और कोई प्रतिस्थापन नियम कॉन्फ़िगर नहीं है तो क्या होता है?**  
Aspose.Slides अपनी फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकटतम उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम पर्यावरण में उपलब्ध फ़ॉन्ट्स पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिए बाहरी फ़ॉन्ट लोड कर सकता हूँ?**  
हां। आप [बाहरी फ़ॉन्ट लोड कर सकते हैं](/slides/hi/java/custom-font/) ताकि Aspose.Slides रेंडरिंग और रूपांतरण के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**  
नहीं। फ़ॉन्ट प्रदान करने और उनके लाइसेंस का पालन करने की जिम्मेदारी आपके ऊपर है।

**क्या प्रतिस्थापन परिणाम Windows, Linux और macOS में अलग हो सकते हैं?**  
हां। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार भिन्न होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरे पर प्रतिस्थापन की आवश्यकता पैदा कर सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे रखें?**  
हर मशीन या कंटेनर पर समान फ़ॉन्ट फाइलें और संस्करण रखें, [आवश्यक बाहरी फ़ॉन्ट लोड करें](/slides/hi/java/custom-font/), और लाइसेंस अनुमति देने पर [फ़ॉन्ट एम्बेड करें](/slides/hi/java/embedded-font/)। आप निर्यात से पहले अनपेक्षित प्रतिस्थापनों की पहचान करने हेतु [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) भी कॉल कर सकते हैं।