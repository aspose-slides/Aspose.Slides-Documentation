---
title: ".NET में प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें"
linktitle: "फ़ॉन्ट प्रतिस्थापन"
type: docs
weight: 70
url: /hi/net/font-substitution/
keywords:
- "फ़ॉन्ट"
- "प्रतिस्थापित फ़ॉन्ट"
- "फ़ॉन्ट प्रतिस्थापन"
- "फ़ॉन्ट बदलें"
- "फ़ॉन्ट प्रतिस्थापन"
- "प्रतिस्थापन नियम"
- "बदलाव नियम"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET में PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या परिवर्तित करते समय फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट की जाँच करें।"
---
## **अवलोकन**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को प्रस्तुतिकरण के रेंडर या परिवर्तित होने पर पहुँच योग्य न होने वाले फ़ॉन्ट के स्थान पर उपलब्ध फ़ॉन्ट उपयोग करने में सक्षम बनाता है। यह प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुतिकरण सामग्री में निर्धारित फ़ॉन्ट को नहीं बदलता।

आप किसी विशिष्ट फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिये फ़ॉन्ट निर्धारित कर सकते हैं, और रेंडरिंग के दौरान Aspose.Slides द्वारा किए जाने वाले प्रतिस्थापनों की जाँच कर सकते हैं। इससे विभिन्न स्थापित फ़ॉन्ट वाले पर्यावरणों में आउटपुट सुसंगत रहता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करना**

रेंडरिंग के समय कौन‑से फ़ॉन्ट प्रतिस्थापित होंगे यह निर्धारित करने के लिये [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) मेथड का उपयोग करें। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट्स लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करते हैं।

निम्नलिखित C# उदाहरण एक प्रस्तुतिकरण के सभी फ़ॉन्ट प्रतिस्थापन सूचीबद्ध करता है:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **चयनित स्लाइड्स के लिये फ़ॉन्ट प्रतिस्थापन प्राप्त करना**

`int[] slides` तर्क के साथ [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) ओवरलोड का उपयोग करके केवल विशिष्ट स्लाइड्स के रेंडरिंग के लिये आवश्यक प्रतिस्थापनों की जाँच करें। यह तब उपयोगी होता है जब आप प्रस्तुतिकरण का भाग रेंडर या निर्यात कर रहे हों, बड़े प्रस्तुतिकरण की क्रमिक जाँच कर रहे हों, उन स्लाइड्स को ढूँढ रहे हों जो अनुपलब्ध फ़ॉन्ट पर निर्भर हैं, सर्वर या कंटेनर के लिये न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या असंबंधित स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर का निदान कर रहे हों।

`slides` एरे में एक‑आधारित स्लाइड अनुक्रम होते हैं: `1` पहली स्लाइड को दर्शाता है। इसके विपरीत, [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) संग्रह इंडेक्सर शून्य‑आधारित है, इसलिए वही स्लाइड `presentation.Slides[0]` से पहुँचा जाता है। एरे बनाते समय इस अंतर का ध्यान रखें ताकि ऑफ‑बाय‑वन त्रुटि न हो।

ओवरलोड को [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) प्रॉपर्टी के माध्यम से कॉल करें। यह केवल चयनित स्लाइड्स के रेंडरिंग के दौरान निर्धारित किए गए प्रतिस्थापन लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम होते हैं। परिणाम वर्तमान फ़ॉन्ट पर्यावरण और [बाहरी रूप से लोड किए गए फ़ॉन्ट](/slides/hi/net/custom-font/) को दर्शाता है। एक [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम रेंडर किए गए आउटपुट को बदलते हैं लेकिन परिणाम में परिलक्षित नहीं होते।

एक ही प्रतिस्थापन अधिकतम एक से अधिक चयनित स्लाइड्स द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंटरी या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को डेडुप्लीकेट करें। निम्नलिखित उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की क्रमबद्ध सूची बनाता है:

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
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) बिना तर्कों के | आपको पूरे प्रस्तुतिकरण के लिये प्रतिस्थापन चाहिए। |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) `int[] slides` के साथ | आपको चयनित रेंज, क्रमिक जाँच, या भागिक निर्यात के लिये प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम सेट करना**

जब स्रोत फ़ॉन्ट उपलब्ध न हो तो Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट को निर्दिष्ट करने के लिये:

1. प्रस्तुतिकरण लोड करें।
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिये फ़ॉन्ट परिभाषाएँ बनाएं।
3. [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) को [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) शर्त के साथ बनायें।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. संग्रह को [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) प्रॉपर्टी को असाइन करें।
6. प्रस्तुतिकरण को रेंडर या परिवर्तित करें।

निम्नलिखित C# उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम सत्यापित करने के लिये पहली स्लाइड को रेंडर करता है। प्रतिस्थापन फ़ॉन्ट Aspose.Slides के लिये उपलब्ध होना चाहिए।

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
पूरे प्रस्तुतिकरण में उपयोग किए जाने वाले फ़ॉन्ट को बिना शर्त बदलने के लिये, देखें [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्ट की सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान प्रयुक्त मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा होते हैं। वे नियमित टेक्स्ट के लिये काम करते हैं जब Aspose.Slides एक अनुपलब्ध फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

Office Math समीकरणों के लिये अतिरिक्त आवश्यकता होती है। यदि कोई समीकरण **Cambria Math** का उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडरिंग के लिये वही फ़ॉन्ट चाहिए। ऐसा नियम जो किसी अन्य गणित फ़ॉन्ट, जैसे **STIX Two Math**, को प्रतिस्थापित करता है, **Cambria Math** को इस उद्देश्य के लिये नहीं बदल सकता, और रेंडरिंग अभी भी रिपोर्ट कर सकती है कि **Cambria Math** आवश्यक है।

ऐसे प्रस्तुतिकरण को रेंडर या रूपांतरित करने के लिये, Aspose.Slides को **Cambria Math** उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में स्थापित करें या एक [बाहरी फ़ॉन्ट](/slides/hi/net/custom-font/) के रूप में लोड करें।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुतिकरण टेक्स्ट पर अभी भी लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट प्रतिस्थापन के बीच अंतर क्या है?**

[फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-replacement/) प्रस्तुतिकरण में पूरे फ़ॉन्ट को इरादा पूर्वक बदलता है। फ़ॉन्ट प्रतिस्थापन रेंडर किए गए आउटपुट के लिये एक फ़ॉन्ट का चयन करता है जब निर्धारित शर्त पूरी होते हैं, जैसे मूल फ़ॉन्ट अनुपलब्ध होना।

**प्रतिस्थापन नियम कब लागू होते हैं?**

ये नियम रेंडरिंग और रूपांतरण के दौरान [फ़ॉन्ट चयन क्रम](/slides/hi/net/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं पा रहा हो।

**जब फ़ॉन्ट अनुपलब्ध हो और कोई प्रतिस्थापन नियम निर्धारित न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकटतम उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम पर्यावरण में उपलब्ध फ़ॉन्ट पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने हेतु बाहरी फ़ॉन्ट लोड कर सकता हूँ?**

हां। आप [बाहरी फ़ॉन्ट लोड](/slides/hi/net/custom-font/) कर सकते हैं ताकि Aspose.Slides रेंडरिंग और रूपांतरण के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करने और उनके लाइसेंस का पालन करने की जिम्मेदारी आपके पास है।

**क्या प्रतिस्थापन परिणाम Windows, Linux और macOS में अलग हो सकते हैं?**

हां। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार अलग होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरे पर प्रतिस्थापन की आवश्यकता हो सकती है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे बनाऊँ?**

हर मशीन या कंटेनर पर समान फ़ॉन्ट फ़ाइलें और संस्करण उपयोग करें, [आवश्यक बाहरी फ़ॉन्ट लोड](/slides/hi/net/custom-font/) करें, और जब लाइसेंस अनुमति दे तो [फ़ॉन्ट एंबेड](/slides/hi/net/embedded-font/) करें। आप निर्यात से पहले अप्रत्याशित प्रतिस्थापन पहचानने के लिये भी [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) को कॉल कर सकते हैं।