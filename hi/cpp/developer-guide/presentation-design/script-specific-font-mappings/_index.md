---
title: C++ में स्क्रिप्ट‑विशिष्ट थीम फ़ॉन्ट्स का प्रबंधन
linktitle: स्क्रिप्ट‑विशिष्ट थीम फ़ॉन्ट्स
type: docs
weight: 15
url: /hi/cpp/script-specific-font-mappings/
keywords:
- स्क्रिप्ट‑विशिष्ट फ़ॉन्ट
- थीम फ़ॉन्ट मैपिंग
- बहुभाषी प्रस्तुति
- लेखन प्रणाली
- सायरिलिक फ़ॉन्ट
- अरबी फ़ॉन्ट
- जापानी फ़ॉन्ट
- जॉर्जियन फ़ॉन्ट
- थाना फ़ॉन्ट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "PowerPoint थीम्स में स्क्रिप्ट‑विशिष्ट फ़ॉन्ट मैपिंग्स का निरीक्षण, जोड़ना, बदलना और हटाना Aspose.Slides for C++ के साथ."
---
## **परिचय**

एक प्रस्तुतिकरण थीम विभिन्न लेखन प्रणालियों के लिए विभिन्न फ़ॉन्ट परिवार चुन सकती है। यह बहुभाषी पाठ को, जो अभी भी थीम फ़ॉन्ट्स का उपयोग करता है, एक समन्वित फ़ॉन्ट स्कीम का पालन करने की अनुमति देता है, जबकि सायरिलिक, अरबी, जापानी, जॉर्जियन, थाना और अन्य लिपियों के लिए उपयुक्त फ़ॉन्ट्स का उपयोग करता है।

थीम का [IFontScheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ifontscheme/) एक मुख्य फ़ॉन्ट संग्रह शामिल करता है, जो आमतौर पर शीर्षकों के लिए उपयोग होता है, और एक द्वितीयक फ़ॉन्ट संग्रह, जो आमतौर पर मुख्य पाठ के लिए उपयोग होता है। उनके लैटिन और ईस्ट एशियन फ़ॉन्ट गुणों के अतिरिक्त, दोनों संग्रह लेखन‑प्रणाली टैग्स से फ़ॉन्ट परिवार नामों के मैपिंग को [IFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifonts/) इंटरफ़ेस के माध्यम से उजागर करते हैं।

यह लेख दिखाता है कि प्रस्तुतिकरण की मास्टर थीम में उन मैपिंग को कैसे निरीक्षण और संशोधित किया जाए तथा यह सत्यापित किया जाए कि परिवर्तन सेव‑और‑रीलोड चक्र में बना रहे।

## **स्क्रिप्ट टैग को समझें**

स्क्रिप्ट फ़ॉन्ट मेथड्स लेखन प्रणालियों की पहचान के लिए चार‑अक्षर BCP 47 स्क्रिप्ट सबटैग्स का उपयोग करते हैं। सामान्य मानों में शामिल हैं:

| स्क्रिप्ट टैग | लेखन प्रणाली |
|---|---|
| `Cyrl` | सायरिलिक |
| `Arab` | अरबी |
| `Hans` | सरलीकृत चीनी |
| `Jpan` | जापानी |
| `Geor` | जॉर्जियन |
| `Thaa` | थाना |

ये मैपिंग थीम फ़ॉन्ट स्कीम से संबंधित होते हैं, न कि व्यक्तिगत पाठ हिस्सों से। एक प्रस्तुतिकरण मुख्य और द्वितीयक संग्रहों के लिए अलग‑अलग मैपिंग निर्धारित कर सकता है, और कुछ स्क्रिप्ट्स के लिए मैपिंग छोड़ सकता है।

## **स्क्रिप्ट फ़ॉन्ट मैपिंग तक पहुंच और निरीक्षण**

प्रस्तुतिकरण‑स्तरीय थीम तक पहुंचने के लिए [Presentation::get_MasterTheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_mastertheme/) का उपयोग करें। [FontScheme::get_Major](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/fontscheme/get_major/) और [FontScheme::get_Minor](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/fontscheme/get_minor/) मेथड्स दो [IFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifonts/) संग्रह लौटाते हैं।

किसी संग्रह से सभी मैपिंग प्राप्त करने के लिए [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fonts/getscriptfontmap/) को कॉल करें। किसी एक लेखन प्रणाली को देख पाने के लिए, उसके स्क्रिप्ट टैग के साथ [Fonts::GetScriptFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fonts/getscriptfont/) को कॉल करें। जब वह संग्रह अनुरोधित मैपिंग को परिभाषित नहीं करता है, तब `GetScriptFont` एक null स्ट्रिंग लौटाता है।

## **मैपिंग को संशोधित करें और निरंतरता सत्यापित करें**

[Fonts::SetScriptFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fonts/setscriptfont/) का उपयोग करके एक मैपिंग बनाएं या उसकी वर्तमान फ़ॉन्ट परिवार को बदलें। मैपिंग को हटाने के लिए [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fonts/removescriptfont/) का उपयोग करें।

निम्नलिखित अंत‑से‑अंत उदाहरण सभी मौजूदा मुख्य और द्वितीयक मैपिंग को पढ़ता है, जापानी मुख्य फ़ॉन्ट को देखता है, सायरिलिक मुख्य फ़ॉन्ट को बदलता है, थाना द्वितीयक मैपिंग को हटाता है, प्रस्तुतिकरण को सहेजता है, और दोनों परिवर्तन को सत्यापित करने के लिये इसे फिर से खोलता है। हटाने के चरण को प्रारंभिक थीम से स्वतंत्र बनाने के लिये, उदाहरण पहले थाना मैपिंग तभी बनाता है जब वह पहले से परिभाषित नहीं है।

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

सत्यापन सामान्य लुकअप के समान null‑string व्यवहार का उपयोग करता है: हटाने को सहेजने के बाद, `GetScriptFont(u"Thaa")` द्वितीयक संग्रह के लिये एक null स्ट्रिंग लौटाता है।

## **थीम मैपिंग को अन्य फ़ॉन्ट सेटिंग्स से अलग करें**

स्क्रिप्ट‑विशिष्ट थीम मैपिंग फ़ॉन्ट चयन में भाग लेती हैं, लेकिन वे प्रत्यक्ष पाठ फॉर्मेटिंग, प्रतिस्थापन और फ़ॉलबैक से अलग समस्या का समाधान करती हैं:

| तंत्र | उद्देश्य | थीम मैपिंग बदलने का प्रभाव |
|---|---|---|
| स्क्रिप्ट‑विशिष्ट थीम फ़ॉन्ट मैपिंग | किसी लेखन प्रणाली के लिये मुख्य या द्वितीयक थीम फ़ॉन्ट चुनता है। | पाठ जो अभी भी संबंधित थीम फ़ॉन्ट का उपयोग करता है, नई मैप्ड फ़ॉन्ट परिवार में बदल सकता है। |
| स्पष्ट रूप से पाठ भाग को सौंपा गया फ़ॉन्ट | उस भाग पर अनुरोधित फ़ॉन्ट परिवार को स्थापित करता है, थीम पर निर्भर रहने के बजाय। | भाग अपरिवर्तित रह सकता है क्योंकि उसकी प्रत्यक्ष फॉर्मेटिंग थीम चयन को ओवरराइड करती है। |
| फ़ॉन्ट प्रतिस्थापन | जब फ़ॉन्ट उपलब्ध नहीं होता या कोई प्रतिस्थापन नियम लागू होता है, तब अनुरोधित फ़ॉन्ट को बदलता है। | यह फ़ॉन्ट के अनुरोध के बाद कार्य करता है; यह थीम की स्क्रिप्ट मैपिंग को पुनःपरिभाषित नहीं करता। |
| फ़ॉन्ट फ़ॉलबैक | चुने हुए फ़ॉन्ट में न मौजूद ग्लिफ़ प्रदान करता है, अक्सर विशिष्ट यूनिकोड रेंजों के लिये। | यह अनुपलब्ध ग्लिफ़ को भरता है; यह संग्रहीत थीम मैपिंग को नहीं बदलता। |

अंतिम दो तंत्रों के बारे में अधिक जानकारी के लिये, देखें [Font Substitution](/slides/hi/cpp/font-substitution/) और [Fallback Fonts](/slides/hi/cpp/fallback-font/).

[Presentation::get_MasterTheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_mastertheme/) में मैपिंग बदलने का प्रभाव केवल उन सामग्री पर पड़ता है जिनका प्रभावी फॉर्मेटिंग अभी भी उस थीम पर निर्भर है। पाठ एक मास्टर, लेआउट, या स्लाइड से थीम ओवरराइड को विरासत में ले सकता है, या स्पष्ट रूप से सौंपा गया फ़ॉन्ट उपयोग कर सकता है। जब दृश्यमान परिणाम प्रस्तुतिकरण‑स्तरीय मैपिंग का पालन नहीं करता, तो उन स्तरों का निरीक्षण करें।

## **मैप्ड फ़ॉन्ट उपलब्ध कराएँ और परिणाम को मान्य करें**

एक स्क्रिप्ट मैपिंग फ़ॉन्ट परिवार नाम संग्रहीत करती है; यह संबंधित फ़ॉन्ट फ़ाइल को स्थापित या लोड नहीं करती। सुसंगत रेंडरिंग और निर्यात के लिये, प्रत्येक मैप्ड फ़ॉन्ट को पर्यावरण में स्थापित होना चाहिए या Aspose.Slides को एक कस्टम स्रोत के माध्यम से प्रदान किया जाना चाहिए, जैसे [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) या [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). उपलब्ध लोडिंग विकल्पों के लिये देखें [Custom Fonts](/slides/hi/cpp/custom-font/).

सहेजी गई मैपिंग की जाँच केवल यह पुष्टि करती है कि थीम परिभाषा बनी रही। यह यह सिद्ध नहीं करता कि फ़ॉन्ट उपलब्ध है, सभी आवश्यक ग्लिफ़ शामिल हैं, या इच्छित लेआउट बनाता है। प्रत्येक आवश्यक लेखन प्रणाली के लिये प्रतिनिधि पाठ को छवि या PDF में रेंडर करें और आउटपुट का निरीक्षण करें। इससे गायब फ़ॉन्ट, अधूरे ग्लिफ़ कवरेज, फ़ॉलबैक व्यवहार, और प्रस्तुति वितरित होने से पहले लेआउट परिवर्तन पकड़े जाते हैं। रेंडरिंग और निर्यात उदाहरणों के लिये देखें [Convert PowerPoint Presentations](/slides/hi/cpp/convert-powerpoint/).

## **बारंबार पूछे जाने वाले प्रश्न**

**`GetScriptFont` स्क्रिप्ट न मैप होने पर क्या लौटाता है?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fonts/getscriptfont/) तब null स्ट्रिंग लौटाता है जब अनुरोधित स्क्रिप्ट मैपिंग उस मुख्य या द्वितीयक फ़ॉन्ट संग्रह में परिभाषित नहीं होती।

**`SetScriptFont` स्क्रिप्ट मौजूद होने पर दूसरा मैपिंग जोड़ता है?**

नहीं। [Fonts::SetScriptFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fonts/setscriptfont/) तब मैपिंग बनाता है जब वह अनुपलब्ध हो और समान स्क्रिप्ट टैग पहले से मौजूद होने पर मैप्ड फ़ॉन्ट परिवार को बदल देता है।

**क्यों थीम मैपिंग बदलने से कुछ पाठ नहीं बदलता?**

पाठ में स्पष्ट रूप से सौंपा गया फ़ॉन्ट हो सकता है, ओवरराइड के माध्यम से अलग थीम को विरासत में ले सकता है, या रेंडरिंग के दौरान प्रतिस्थापन या फ़ॉलबैक से प्रभावित हो सकता है। प्रस्तुतिकरण‑स्तरीय स्क्रिप्ट मैपिंग केवल उन पाठ को नियंत्रित करती है जिनका प्रभावी फॉर्मेटिंग अभी भी उस थीम फ़ॉन्ट संग्रह को संदर्भित करता है।

**क्या सहेजना और फिर खोलना बहुभाषी आउटपुट को मान्य करने के लिये पर्याप्त है?**

नहीं। फिर खोलना थीम डेटा की निरंतरता की पुष्टि करता है। साथ ही प्रत्येक आवश्यक लेखन प्रणाली से प्रतिनिधि पाठ को रेंडर करें यह पुष्टि करने के लिये कि मैप्ड फ़ॉन्ट उपलब्ध हैं और आवश्यक ग्लिफ़ शामिल हैं।