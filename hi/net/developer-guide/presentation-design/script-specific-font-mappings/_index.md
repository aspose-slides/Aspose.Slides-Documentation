---
title: .NET में स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट प्रबंधित करें
linktitle: स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट्स
type: docs
weight: 15
url: /hi/net/script-specific-font-mappings/
keywords:
  - स्क्रिप्ट-विशिष्ट फ़ॉन्ट
  - थीम फ़ॉन्ट मैपिंग
  - बहुभाषी प्रस्तुति
  - लेखन प्रणाली
  - साइरिलिक फ़ॉन्ट
  - अरबी फ़ॉन्ट
  - जापानी फ़ॉन्ट
  - जॉर्जियाई फ़ॉन्ट
  - थाना फ़ॉन्ट
  - PowerPoint
  - प्रस्तुति
  - .NET
  - C#
  - Aspose.Slides
description: "PowerPoint थीम में स्क्रिप्ट-विशिष्ट फ़ॉन्ट मैपिंग को निरीक्षण, जोड़ना, बदलना और हटाना, Aspose.Slides for .NET के साथ।"
---
## **अवलोकन**

एक प्रस्तुति थीम विभिन्न लेखन प्रणाली के लिए अलग-अलग फ़ॉन्ट फ़ैमिली चुन सकती है। इससे बहुभाषी पाठ, जो अभी भी थीम फ़ॉन्ट का उपयोग करता है, एक समन्वित फ़ॉन्ट योजना का पालन करता है और साइरिलिक, अरबी, जापानी, जॉर्जियाई, थाना और अन्य लिपियों के लिए उपयुक्त फ़ॉन्ट का उपयोग करता है।

थीम का [IFontScheme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/ifontscheme/) आम तौर पर शीर्षक के लिए उपयोग की जाने वाली मुख्य फ़ॉन्ट कलेक्शन और सामान्य पाठ के लिए उपयोग की जाने वाली गौण फ़ॉन्ट कलेक्शन शामिल करता है। उनके लैटिन और ईस्ट एशियन फ़ॉन्ट गुणों के अतिरिक्त, दोनों कलेक्शन लेखन‑प्रणाली टैग से फ़ॉन्ट फ़ैमिली नामों के मैपिंग को [IFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/ifonts/) इंटरफ़ेस के माध्यम से उजागर करती हैं।

यह लेख दर्शाता है कि प्रस्तुति की मास्टर थीम में उन मैपिंग को कैसे निरीक्षण और संशोधित किया जाए तथा यह कैसे सुनिश्चित किया जाए कि परिवर्तन सहेजने‑और‑पुनः‑लोड करने के बाद भी बना रहे।

## **स्क्रिप्ट टैग को समझें**

स्क्रिप्ट फ़ॉन्ट मेथड्स लेखन प्रणालियों की पहचान के लिए चार‑अक्षरीय BCP 47 स्क्रिप्ट सब‑टैग का उपयोग करते हैं। सामान्य मानों में शामिल हैं:

| स्क्रिप्ट टैग | लिपि प्रणाली |
|---|---|
| `Cyrl` | साइरिलिक |
| `Arab` | अरबी |
| `Hans` | सरल चीनी |
| `Jpan` | जापानी |
| `Geor` | जॉर्जियाई |
| `Thaa` | थाना |

ये मैपिंग थीम फ़ॉन्ट स्कीम से संबंधित हैं, व्यक्तिगत पाठ भागों से नहीं। एक प्रस्तुति मुख्य तथा गौण कलेक्शन के लिए अलग‑अलग मैपिंग परिभाषित कर सकती है, और कुछ स्क्रिप्ट्स के लिए मैपिंग को छोड़ भी सकती है।

## **स्क्रिप्ट फ़ॉन्ट मैपिंग तक पहुँचें और निरीक्षण करें**

[Presentation.MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/mastertheme/) का उपयोग करके प्रस्तुति‑स्तर की थीम तक पहुँचें। [FontScheme.Major](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/fontscheme/major/) और [FontScheme.Minor](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/fontscheme/minor/) प्रॉपर्टी दो [IFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/ifonts/) कलेक्शन लौटाती हैं।

एक कलेक्शन से सभी मैपिंग प्राप्त करने के लिए [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/hi/net/aspose.slides/fonts/getscriptfontmap/) को कॉल करें। किसी एक लेखन प्रणाली को ढूँढ़ने के लिए, उसके स्क्रिप्ट टैग के साथ [IFonts.GetScriptFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fonts/getscriptfont/) को कॉल करें। जब वह कलेक्शन अनुरोधित मैपिंग को परिभाषित नहीं करता, तो `GetScriptFont` `null` लौटाता है।

## **मैपिंग संशोधित करें और निरंतरता सत्यापित करें**

एक मैपिंग बनाने या उसके वर्तमान फ़ॉन्ट फ़ैमिली को बदलने के लिए [IFonts.SetScriptFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fonts/setscriptfont/) का उपयोग करें। मैपिंग हटाने के लिए [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fonts/removescriptfont/) का उपयोग करें।

निम्नलिखित एंड‑टू‑एंड उदाहरण सभी मौजूदा मुख्य और गौण मैपिंग पढ़ता है, जापानी मुख्य फ़ॉन्ट को देखता है, साइरिलिक मुख्य फ़ॉन्ट को बदलता है, थाना गौण मैपिंग को हटाता है, प्रस्तुति को सहेजता है, और दोनों परिवर्तन सत्यापित करने के लिए फिर से खोलता है। प्रारम्भिक थीम से हटाने के कदम को स्वतंत्र बनाने के लिए, यह उदाहरण केवल तब थाना मैपिंग बनाता है जब वह पहले से परिभाषित नहीं है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

सत्यापन सामान्य `null` व्यवहार का उपयोग करता है: हटाने के बाद सहेजे जाने पर `GetScriptFont("Thaa")` गौण कलेक्शन के लिए `null` लौटाता है।

## **थीम मैपिंग को अन्य फ़ॉन्ट सेटिंग्स से अलग करें**

स्क्रिप्ट‑विशिष्ट थीम मैपिंग फ़ॉन्ट चयन में भाग लेती है, लेकिन यह सीधे पाठ फ़ॉर्मेटिंग, प्रतिस्थापन और फ़ॉलबैक से अलग समस्या को हल करती है:

| तंत्र | उद्देश्य | थीम मैपिंग बदलने का प्रभाव |
|---|---|---|
| स्क्रिप्ट‑विशिष्ट थीम फ़ॉन्ट मैपिंग | लेखन प्रणाली के लिए मुख्य या गौण थीम फ़ॉन्ट चुनती है। | संबंधित थीम फ़ॉन्ट अभी भी उपयोग करने वाला पाठ नई मैप्ड फ़ैमिली में बदल सकता है। |
| किसी पाठ भाग को स्पष्ट रूप से असाइन किया गया फ़ॉन्ट | उस भाग पर अनुरोधित फ़ॉन्ट फ़ैमिली को सीधे सेट करता है, थीम पर निर्भर नहीं रहता। | प्रत्यक्ष फ़ॉर्मेटिंग थीम चयन को ओवरराइड करने के कारण भाग अपरिवर्तित रह सकता है। |
| फ़ॉन्ट प्रतिस्थापन | जब अनुरोधित फ़ॉन्ट उपलब्ध नहीं होता या प्रतिस्थापन नियम लागू होता है, तो फ़ॉन्ट बदलता है। | यह फ़ॉन्ट अनुरोध के बाद कार्य करता है; यह थीम की स्क्रिप्ट मैपिंग को पुनः परिभाषित नहीं करता। |
| फ़ॉलबैक फ़ॉन्ट | चयनित फ़ॉन्ट में न मौजूद glyphs को पूरा करता है, अक्सर विशिष्ट Unicode रेंज के लिए। | यह गुम glyph कवरेज को भरता है; यह संग्रहित थीम मैपिंग को नहीं बदलता। |

अंतिम दो तंत्रों के बारे में अधिक जानकारी के लिए, देखें [Font Substitution](/slides/hi/net/font-substitution/) और [Fallback Fonts](/slides/hi/net/fallback-font/)।

[Presentation.MasterTheme](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/mastertheme/) में मैपिंग बदलने से केवल वही सामग्री प्रभावित होती है जिसकी प्रभावी फ़ॉर्मेटिंग अभी भी उस थीम पर निर्भर करती है। जब दिखाई देने वाला परिणाम प्रस्तुति‑स्तर की मैपिंग का पालन नहीं करता, तो मास्टर, लेआउट या स्लाइड पर ओवरराइड, या स्पष्ट रूप से असाइन किया गया फ़ॉन्ट जांचें।

## **मैप्ड फ़ॉन्ट उपलब्ध कराएँ और परिणाम सत्यापित करें**

स्क्रिप्ट मैपिंग केवल फ़ॉन्ट फ़ैमिली नाम संग्रहीत करती है; यह संबंधित फ़ॉन्ट फ़ाइल को स्थापित या लोड नहीं करती। निरंतर रेंडरिंग और निर्यात के लिए, प्रत्येक मैप्ड फ़ॉन्ट को या तो पर्यावरण में स्थापित होना चाहिए या Aspose.Slides को एक कस्टम स्रोत के माध्यम से प्रदान किया जाना चाहिए, जैसे [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) या [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/documentlevelfontsources/)। उपलब्ध लोडिंग विकल्पों के लिए देखें [Custom Fonts](/slides/hi/net/custom-font/)।

सहेजी गई मैपिंग को सत्यापित करना केवल यह पुष्टि करता है कि थीम परिभाषा बनी रही। यह यह नहीं सिद्ध करता कि फ़ॉन्ट उपलब्ध है, सभी आवश्यक glyphs रखता है, या वांछित लेआउट उत्पन्न करता है। प्रत्येक आवश्यक लेखन प्रणाली के प्रतिनिधि पाठ को छवि या PDF में रेंडर करें और आउटपुट की जाँच करें। यह लापता फ़ॉन्ट, अधूरी glyph कवरेज, फ़ॉलबैक व्यवहार, और लेआउट परिवर्तन को प्रस्तुति वितरण से पहले पकड़ता है। रेंडरिंग और निर्यात उदाहरणों के लिए देखें [Convert PowerPoint Presentations](/slides/hi/net/convert-powerpoint/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**`GetScriptFont` उन स्थितियों में क्या लौटाता है जब स्क्रिप्ट मैप्ड नहीं होती?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fonts/getscriptfont/) `null` लौटाता है जब अनुरोधित स्क्रिप्ट मैपिंग उस मुख्य या गौण फ़ॉन्ट कलेक्शन में परिभाषित नहीं होती।

**`SetScriptFont` स्क्रिप्ट पहले से मौजूद होने पर दूसरा मैपिंग जोड़ता है?**

नहीं। [IFonts.SetScriptFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fonts/setscriptfont/) तब मैपिंग बनाता है जब वह अनुपस्थित होती है और जब वही स्क्रिप्ट टैग पहले से मौजूद हो तो मैप्ड फ़ॉन्ट फ़ैमिली को प्रतिस्थापित करता है।

**किसी थीम मैपिंग के बदलने पर कुछ पाठ क्यों नहीं बदलता?**

पाठ के पास स्पष्ट रूप से असाइन किया गया फ़ॉन्ट हो सकता है, वह ओवरराइड के माध्यम से अलग थीम विरासत में ले सकता है, या रेंडरिंग के दौरान प्रतिस्थापन या फ़ॉलबैक से प्रभावित हो सकता है। प्रस्तुति‑स्तर की स्क्रिप्ट मैपिंग केवल उन पाठों को नियंत्रित करती है जिनकी प्रभावी फ़ॉर्मेटिंग अभी भी उस थीम फ़ॉन्ट कलेक्शन की ओर इशारा करती है।

**सहेजने और फिर खोलने से बहुभाषी आउटपुट की वैधता पर्याप्त है?**

नहीं। पुनः‑खोलना केवल थीम डेटा की निरंतरता की पुष्टि करता है। इसके अतिरिक्त प्रत्येक आवश्यक लेखन प्रणाली से प्रतिनिधि पाठ को रेंडर करके यह पुष्टि करें कि मैप्ड फ़ॉन्ट उपलब्ध हैं और आवश्यक glyphs रखती हैं।