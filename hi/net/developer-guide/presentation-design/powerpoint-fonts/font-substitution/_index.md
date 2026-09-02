---
title: ".NET में प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें"
linktitle: "फ़ॉन्ट प्रतिस्थापन"
type: docs
weight: 70
url: /hi/net/font-substitution/
keywords:
- फ़ॉन्ट
- प्रतिस्थापित फ़ॉन्ट
- फ़ॉन्ट प्रतिस्थापन
- फ़ॉन्ट बदलें
- फ़ॉन्ट प्रतिस्थापन
- प्रतिस्थापन नियम
- प्रतिस्थापन नियम
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या रूपांतरित करते समय प्रतिस्थापित फ़ॉन्ट की जाँच करें।"
---
## **परिचय**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को उपलब्ध फ़ॉन्ट को उपयोग करने देता है जब प्रस्तुतिकरण रेंडर या रूपांतरीत किया जाता है और कोई फ़ॉन्ट उपलब्ध नहीं होता। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुतिकरण सामग्री को सौंपे गए फ़ॉन्ट को नहीं बदलता।

आप किसी विशेष फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिए फ़ॉन्ट को परिभाषित कर सकते हैं, और आप रेंडरिंग के दौरान Aspose.Slides द्वारा किए जाने वाले प्रतिस्थापनों को निरीक्षण कर सकते हैं। यह विभिन्न स्थापित फ़ॉन्ट वाले परिवेशों में आउटपुट को समान रखने में मदद करता है।

## **फ़ॉन्ट प्रतिस्थापनों को प्राप्त करें**

प्रस्तुतिकरण रेंडर होने पर कौन से फ़ॉन्ट प्रतिस्थापित होंगे, यह निर्धारित करने के लिए [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontsmanager/getsubstitutions/) मेथड का उपयोग करें। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करते हैं।

निम्न C# उदाहरण एक प्रस्तुतिकरण के सभी फ़ॉन्ट प्रतिस्थापनों की सूची देता है:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **चयनित स्लाइड्स के लिए फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

एक `int[] slides` आर्ग्यूमेंट के साथ [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontsmanager/getsubstitutions/) ओवरलोड का उपयोग करके केवल विशिष्ट स्लाइड्स को रेंडर करने के लिए आवश्यक प्रतिस्थापनों को जांचें। यह तब उपयोगी है जब आप प्रस्तुतिकरण का भाग रेंडर या निर्यात कर रहे हों, बड़े प्रस्तुतिकरण को क्रमशः जाँच रहे हों, उन स्लाइड्स को ढूँढ़ रहे हों जो अनुपलब्ध फ़ॉन्ट पर निर्भर हैं, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या अनावश्यक स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतरों का निदान कर रहे हों।

`slides` एरे में एक-आधारित स्लाइड इंडेक्स होते हैं: `1` पहला स्लाइड दर्शाता है। इसके विपरीत, [Presentation.Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slides/hi/) संग्रह का इंडेक्सर शून्य-आधारित है, इसलिए वही स्लाइड `presentation.Slides[0]` से पहुँचा जाता है। एरे बनाते समय इस अंतर का ध्यान रखें ताकि ऑफ‑बाई‑वन त्रुटियों से बचा जा सके।

ओवरलोड को [Presentation.FontsManager](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/fontsmanager/) प्रॉपर्टी के माध्यम से कॉल करें। यह केवल चयनित स्लाइड्स को रेंडर करते समय निर्धारित प्रतिस्थापनों को लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम शामिल होते हैं। परिणाम वर्तमान फ़ॉन्ट वातावरण, कॉन्फ़िगर किए गए फ़ॉलबैक नियम, [IFontSubstRuleCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, और [बाहरी रूप से लोड किए गए फ़ॉन्ट](/slides/hi/net/custom-font/) को प्रतिबिंबित करता है।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइड्स द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंटरी या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को ड्यूप्लिकेशन हटाएँ। निम्न उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन की रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की क्रमबद्ध सूची बनाता है:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

[IFontsManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontsmanager/) इंटरफ़ेस दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक का चयन करें:

| ओवरलोड | कब उपयोग करें |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontsmanager/getsubstitutions/) बिना आर्ग्यूमेंट के | आपको पूरे प्रस्तुतिकरण के लिए प्रतिस्थापन चाहिए। |
| [GetSubstitutions](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontsmanager/getsubstitutions/) `int[] slides` के साथ | आपको चयनित रेंज, क्रमिक जांच, या आंशिक निर्यात के लिये प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम निर्धारित करें**

जब स्रोत फ़ॉन्ट उपलब्ध न हो, तो Aspose.Slides को कौन सा फ़ॉन्ट उपयोग करना चाहिए, इसे निर्दिष्ट करने के लिए:

1. प्रस्तुतिकरण लोड करें।
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएँ।
3. [FontSubstRule](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsubstrule/) को [WhenInaccessible](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsubstcondition/) शर्त के साथ बनाएँ।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. संग्रह को [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/fontsubstrulelist/) प्रॉपर्टी को असाइन करें।
6. प्रस्तुतिकरण को रेंडर या रूपांतरीत करें।

निम्न C# उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम सत्यापित करने के लिये पहला स्लाइड रेंडर करता है। प्रतिस्थापित फ़ॉन्ट Aspose.Slides के लिये उपलब्ध होना चाहिए।

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
पूरे प्रस्तुतिकरण में उपयोग किए जाने वाले फ़ॉन्ट को बिना शर्त बदलने के लिये, देखें [Font Replacement](/slides/hi/net/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्ट के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान उपयोग किए जाने वाले मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं। वे सामान्य टेक्स्ट के लिये काम करते हैं जब Aspose.Slides अनुपलब्ध फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

ऑफ़िस गणित समीकरणों में अतिरिक्त आवश्यकता होती है। यदि कोई समीकरण **Cambria Math** उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडरिंग के लिये ठीक वही फ़ॉन्ट चाहिए। कोई भी नियम जो दूसरे गणित फ़ॉन्ट, जैसे **STIX Two Math**, को प्रतिस्थापित करता है, वह **Cambria Math** को इस प्रयोजन के लिये बदल नहीं सकता, और रेंडरिंग अभी भी रिपोर्ट कर सकता है कि **Cambria Math** आवश्यक है।

ऐसे प्रस्तुतिकरण को रेंडर या रूपांतरीत करने के लिये, **Cambria Math** को Aspose.Slides के लिये उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में स्थापित करें या एक [बाहरी फ़ॉन्ट](/slides/hi/net/custom-font/) के रूप में लोड करें।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुतिकरण टेक्स्ट पर अभी भी लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट प्रतिस्थापन में क्या अंतर है?**

[Font replacement](/slides/hi/net/font-replacement/) जानबूझकर पूरे प्रस्तुतिकरण में एक फ़ॉन्ट को दूसरे से बदलता है। फ़ॉन्ट प्रतिस्थापन उस शर्त के मिलने पर रेंडर किए गए आउटपुट के लिये फ़ॉन्ट चुनता है, जैसे जब मूल फ़ॉन्ट उपलब्ध नहीं होता।

**प्रतिस्थापन नियम कब लागू होते हैं?**

नियम रेंडरिंग और रूपांतरण के दौरान [font selection sequence](/slides/hi/net/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं सकता।

**यदि फ़ॉन्ट अनुपलब्ध है और कोई प्रतिस्थापन नियम कॉन्फ़िगर नहीं है तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकट उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम पर्यावरण में उपलब्ध फ़ॉन्ट पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिये बाहरी फ़ॉन्ट लोड कर सकता हूँ?**

हाँ। आप [load external fonts](/slides/hi/net/custom-font/) कर सकते हैं ताकि Aspose.Slides रेंडरिंग और रूपांतरण के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करने और उनके लाइसेंस का पालन करने की जिम्मेदारी आपके ऊपर है।

**क्या प्रतिस्थापन परिणाम Windows, Linux और macOS में अलग हो सकते हैं?**

हां। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार अलग होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरे पर प्रतिस्थापन की आवश्यकता बना सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे बनाऊँ?**

हर मशीन या कंटेनर पर समान फ़ॉन्ट फ़ाइलें और संस्करण प्रयोग करें, आवश्यक बाहरी फ़ॉन्ट लोड करें [/slides/hi/net/custom-font/], और लाइसेंस अनुमति देने पर फ़ॉन्ट एम्बेड करें [/slides/hi/net/embedded-font/]। आप निर्यात से पहले [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontsmanager/getsubstitutions/) को कॉल करके अनपेक्षित प्रतिस्थापनों की पहचान भी कर सकते हैं।