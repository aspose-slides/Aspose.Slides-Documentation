---
title: .NET में प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर करें
linktitle: फ़ॉन्ट प्रतिस्थापन
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
- बदलाव नियम
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और PowerPoint तथा OpenDocument प्रस्तुतियों को रेंडर या रूपांतरित करते समय प्रतिस्थापित फ़ॉन्ट की जाँच करें।"
---
## **अवलोकन**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को प्रस्तुति के रेंडर या रूपांतरण के दौरान उन फ़ॉन्ट्स की जगह उपलब्ध फ़ॉन्ट उपयोग करने की अनुमति देता है, जिन्हें एक्सेस नहीं किया जा सकता। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति सामग्री को सौंपे गए फ़ॉन्ट को नहीं बदलता।

आप किसी विशेष फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिए फ़ॉन्ट परिभाषित कर सकते हैं, और आप Aspose.Slides द्वारा रेंडरिंग के दौरान किए गए प्रतिस्थापनों की जाँच कर सकते हैं। यह विभिन्न स्थापित फ़ॉन्ट्स वाले वातावरणों में आउटपुट को सुसंगत रखने में मदद करता है।

यदि कोई फ़ॉन्ट उपलब्ध है लेकिन उसका समर्पित बोल्ड टाइपफ़ेस नहीं है, तो देखें [डेडिकेटेड बोल्ड टाइपफ़ेस के बिना फ़ॉन्ट्स को संभालें](/slides/hi/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)। वह अनुभाग पीडीएफ निर्यात के दौरान प्रभावित टेक्स्ट को रास्टराइज़ करने और टेक्स्ट चयन, खोज और स्केलिंग पर परिणामों को समझाता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

रेंडरिंग के दौरान कौन से फ़ॉन्ट्स प्रतिस्थापित किए जाएंगे, यह निर्धारित करने के लिए [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) मेथड का उपयोग करें। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) वस्तुओं को लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करते हैं।

निम्नलिखित C# उदाहरण प्रस्तुति के लिए सभी फ़ॉन्ट प्रतिस्थापनों को सूचीबद्ध करता है:

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

विशिष्ट स्लाइड्स को रेंडर करने के लिए आवश्यक केवल उन प्रतिस्थापनों की जाँच करने हेतु `int[] slides` तर्क के साथ [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) ओवरलोड का उपयोग करें। यह तब उपयोगी होता है जब आप प्रस्तुति के किसी भाग को रेंडर या निर्यात कर रहे हों, बड़ी प्रस्तुति को क्रमिक रूप से जाँच रहे हों, उन स्लाइड्स को ढूँढ रहे हों जो अनुपलब्ध फ़ॉन्ट्स पर निर्भर हैं, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या अनसंबंधित स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर का निदान कर रहे हों।

`slides` ऐरे एक-आधारित स्लाइड अनुक्रमांक रखता है: `1` पहली स्लाइड को पहचानता है। इसके विपरीत, [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) संग्रह इंडेक्सर शून्य-आधारित है, इसलिए वही स्लाइड `presentation.Slides[0]` के रूप में पहुँची जाती है। ऐरे बनाते समय इस अंतर का ध्यान रखें ताकि ऑफ-बाय-वन त्रुटियों से बचा जा सके।

ओवरलोड को [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) प्रॉपर्टी के माध्यम से कॉल करें। यह केवल चयनित स्लाइड्स को रेंडर करते समय निर्धारित प्रतिस्थापन लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) वस्तु है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम होते हैं। परिणाम वर्तमान फ़ॉन्ट वातावरण और [externally loaded fonts](/slides/hi/net/custom-font/) को दर्शाता है। एक [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम रेंडर किए गए आउटपुट को बदलते हैं लेकिन परिणाम में प्रतिबिंबित नहीं होते।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइड्स द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंट्री या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को डिडुप्लिकेट करें। निम्नलिखित उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की सॉर्टेड सूची बनाता है:

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

[IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) इंटरफ़ेस दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | कब उपयोग करें |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) बिना तर्कों के | आपको पूरी प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) `int[] slides` के साथ | आपको चयनित रेंज, क्रमिक जाँच, या भागीय निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम सेट करें**

जब स्रोत फ़ॉन्ट अनुपलब्ध हो तो Aspose.Slides को उपयोग करने योग्य फ़ॉन्ट निर्दिष्ट करने के लिए:

1. प्रस्तुति लोड करें।
2. स्रोत और प्रतिस्थापन फ़ॉन्ट्स के लिए फ़ॉन्ट परिभाषाएँ बनाएं।
3. एक [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) को [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) शर्त के साथ बनाएं।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. संग्रह को [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) प्रॉपर्टी को असाइन करें।
6. प्रस्तुति को रेंडर या रूपांतरित करें।

निम्नलिखित C# उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम की पुष्टि करने के लिए पहली स्लाइड को रेंडर करता है। प्रतिस्थापित फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

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
एक प्रस्तुति में उपयोग होने वाले फ़ॉन्ट्स में बिना शर्त परिवर्तन के लिए, देखें [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्ट्स के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान उपयोग की जाने वाली मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं। वे नियमित टेक्स्ट के लिए काम करते हैं जब Aspose.Slides एक अनुपलब्ध फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

ऑफ़िस मैथ समीकरणों में एक अतिरिक्त आवश्यकता होती है। यदि कोई समीकरण **Cambria Math** का उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडर करने के लिए ठीक वही फ़ॉन्ट चाहिए हो सकता है। कोई नियम जो **STIX Two Math** जैसे अन्य गणित फ़ॉन्ट को प्रतिस्थापित करता है, इस उद्देश्य के लिए **Cambria Math** को बदल नहीं सकता, और रेंडरिंग अभी भी रिपोर्ट कर सकता है कि **Cambria Math** आवश्यक है।

ऐसी प्रस्तुति को रेंडर या रूपांतरित करने के लिए, **Cambria Math** को Aspose.Slides के लिए उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में स्थापित करें या इसे एक [external font](/slides/hi/net/custom-font/) के रूप में लोड करें।

यह सीमा समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम अभी भी नियमित प्रस्तुति टेक्स्ट पर लागू होते हैं।

## **FAQ**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट प्रतिस्थापन में क्या अंतर है?**

[फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-replacement/) जानबूझकर पूरी प्रस्तुति में एक फ़ॉन्ट को दूसरे से बदल देता है। फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर की गई शर्त पूरी होने पर, जैसे मूल फ़ॉन्ट अनुपलब्ध होने पर, रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है।

**प्रतिस्थापन नियम कब लागू होते हैं?**

नियम रेंडरिंग और रूपांतरण के दौरान [font selection sequence](/slides/hi/net/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुंच नहीं सकता।

**जब फ़ॉन्ट गायब है और कोई प्रतिस्थापन नियम कॉन्फ़िगर नहीं है तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकटतम उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम पर्यावरण में उपलब्ध फ़ॉन्ट्स पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिए बाहरी फ़ॉन्ट लोड कर सकता हूँ?**

हाँ। आप [load external fonts](/slides/hi/net/custom-font/) कर सकते हैं ताकि Aspose.Slides रेंडरिंग और रूपांतरण के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट्स प्रदान करने और उनके लाइसेंस की अनुपालन की जिम्मेदारी आपके ऊपर है।

**क्या प्रतिस्थापन परिणाम Windows, Linux, और macOS में भिन्न हो सकते हैं?**

हाँ। स्थापित फ़ॉन्ट्स और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार भिन्न होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरे मशीन पर प्रतिस्थापन की आवश्यकता पैदा कर सकता है।

**बैच रूपांतरणों में फ़ॉन्ट चयन को सुसंगत कैसे बनाऊँ?**

हर मशीन या कंटेनर पर वही फ़ॉन्ट फ़ाइलें और संस्करण उपयोग करें, [load required external fonts](/slides/hi/net/custom-font/) करें, और लाइसेंस अनुमति दे तो [embed fonts](/slides/hi/net/embedded-font/) करें। आप निर्यात से पहले अनपेक्षित प्रतिस्थापनों की पहचान करने के लिए [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) को भी कॉल कर सकते हैं।