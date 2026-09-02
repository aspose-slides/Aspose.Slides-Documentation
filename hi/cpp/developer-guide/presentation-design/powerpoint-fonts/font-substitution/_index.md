---
title: C++ में प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें
linktitle: फ़ॉन्ट प्रतिस्थापन
type: docs
weight: 70
url: /hi/cpp/font-substitution/
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
- C++
- Aspose.Slides
description: "C++ के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और PowerPoint तथा OpenDocument प्रस्तुतियों को रेंडर या रूपांतरित करते समय प्रतिस्थापित फ़ॉन्ट देखिए।"
---
## **परिचय**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को प्रस्तुति के रेंडर या रूपांतरण के समय जब कोई फ़ॉन्ट उपलब्ध नहीं होता है, तब एक उपलब्ध फ़ॉन्ट का उपयोग करने की अनुमति देता है। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति सामग्री में निर्धारित फ़ॉन्ट को नहीं बदलता है।

आप किसी विशेष फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिए फ़ॉन्ट को परिभाषित कर सकते हैं, और आप Aspose.Slides द्वारा रेंडरिंग के दौरान किए जाने वाले प्रतिस्थापन की जाँच कर सकते हैं। यह विभिन्न स्थापित फ़ॉन्ट वाले परिवेशों में आउटपुट को सुसंगत रखने में मदद करता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

प्रस्तुति के रेंडर होने पर कौन से फ़ॉन्ट प्रतिस्थापित किए जाएंगे, यह निर्धारित करने के लिए आप [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) मेथड का उपयोग कर सकते हैं। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट्स लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करते हैं।

निम्नलिखित C++ उदाहरण प्रस्तुति के लिए सभी फ़ॉन्ट प्रतिस्थापनों की सूची देता है:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **चयनित स्लाइड्स के लिए फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

आप चयनित स्लाइड्स को रेंडर करने के लिए आवश्यक प्रतिस्थापनों को ही देखना चाहते हैं, तो आप `System::ArrayPtr<int32_t> slides` तर्क के साथ [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) ओवरलोड का उपयोग कर सकते हैं। यह तब उपयोगी होता है जब आप प्रस्तुति के भाग को रेंडर या एक्सपोर्ट कर रहे हों, बड़े प्रस्तुति को क्रमिक रूप से जांच रहे हों, उन स्लाइड्स को ढूंढ रहे हों जो अनुपलब्ध फ़ॉन्ट पर निर्भर हैं, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या असंबंधित स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर की जाँच करना चाहें।

`slides` एरे में एक-आधारित स्लाइड इंडेक्स होते हैं: `1` पहली स्लाइड को दर्शाता है। इसके विपरीत, [Presentation::get_Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slide/) मेथड शून्य-आधारित इंडेक्स का उपयोग करता है, इसलिए वही स्लाइड `presentation->get_Slide(0)` द्वारा पहुँचा जाता है। एरे बनाते समय इस अंतर को ध्यान में रखें ताकि ओफ़‑बाय‑वन त्रुटियों से बचा जा सके।

आप इस ओवरलोड को [Presentation::get_FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_fontsmanager/) मेथड के माध्यम से कॉल करते हैं। यह केवल चयनित स्लाइड्स को रेंडर करते समय निर्धारित किए गए प्रतिस्थापनों को लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम होते हैं। यह परिणाम वर्तमान फ़ॉन्ट वातावरण, कॉन्फ़िगर किए गए फ़ॉलबैक नियम, [IFontSubstRuleCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, और [externally loaded fonts](/slides/hi/cpp/custom-font/) को दर्शाता है।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइड्स द्वारा आवश्यक हो सकता है। जब आप फ़ॉन्ट इन्वेंट्री या प्री‑फ़्लाइट रिपोर्ट बनाते हैं, तो परिणामों को डिडुप्लिकेट करें। निम्नलिखित उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन की रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की क्रमबद्ध सूची बनाता है:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

[IFontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/) इंटरफ़ेस दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के हिसाब से एक चुनें:

| ओवरलोड | कब उपयोग करें |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | आपको पूरी प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [GetSubstitutions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | आपको चयनित रेंज, क्रमिक जाँच, या आंशिक निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम सेट करें**

जब स्रोत फ़ॉन्ट अनुपलब्ध हो, तो Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट को निर्दिष्ट करने के लिए:

1. प्रस्तुति लोड करें।  
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएँ।  
3. एक [FontSubstRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsubstrule/) बनाएँ जिसमें [WhenInaccessible](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsubstcondition/) शर्त हो।  
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsubstrulecollection/) में जोड़ें।  
5. [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) मेथड का उपयोग करके संग्रह को असाइन करें।  
6. प्रस्तुति को रेंडर या रूपांतरित करें।

निम्नलिखित C++ उदाहरण `SomeRareFont` के अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम की पुष्टि के लिए पहली स्लाइड को रेंडर करता है। प्रतिस्थापन फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="ध्यान दें" %}}
पूरी प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट में बिना शर्त परिवर्तन के लिए, देखें [Font Replacement](/slides/hi/cpp/font-replacement/)।
{{% /alert %}}

## **गणितीय समीकरण फ़ॉन्ट के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान उपयोग की जाने वाली मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं। जब Aspose.Slides एक अनुपलब्ध फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है, तो ये सामान्य टेक्स्ट के लिए काम करते हैं।

Office Math समीकरणों को एक अतिरिक्त आवश्यकता होती है। यदि कोई समीकरण **Cambria Math** का उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडर करने के लिए वही फ़ॉन्ट चाहिए हो सकता है। कोई नियम जो दूसरे गणित फ़ॉन्ट, जैसे **STIX Two Math**, को प्रतिस्थापित करता है, **Cambria Math** को इस उद्देश्य के लिए बदल नहीं सकता, और रेंडरिंग अभी भी यह रिपोर्ट कर सकती है कि **Cambria Math** आवश्यक है।

ऐसी प्रस्तुति को रेंडर या रूपांतरित करने के लिए, **Cambria Math** को Aspose.Slides के लिए उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में इंस्टॉल करें या एक [external font](/slides/hi/cpp/custom-font/) के रूप में लोड करें।

यह सीमा समीकरण लेआउट पर लागू होती है। उपर्युक्त वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति टेक्स्ट पर अभी भी लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट बदलने में क्या अंतर है?**  
[Font replacement](/slides/hi/cpp/font-replacement/) इरादतन प्रस्तुति में पूरे एक फ़ॉन्ट को दूसरे में बदल देता है। फ़ॉन्ट प्रतिस्थापन तय शर्त पूरी होने पर, जैसे मूल फ़ॉन्ट उपलब्ध नहीं होने पर, रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है।

**प्रतिस्थापन नियम कब लागू होते हैं?**  
रेंडरिंग और रूपांतरण के दौरान नियम [font selection sequence](/slides/hi/cpp/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुंच नहीं पा रहा हो।

**जब फ़ॉन्ट अनुपलब्ध हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**  
Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकटतम उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम पर्यावरण में उपलब्ध फ़ॉन्ट पर निर्भर करता है।

**क्या मैं बाहरी फ़ॉन्ट लोड करके प्रतिस्थापन से बच सकता हूँ?**  
हाँ। आप [load external fonts](/slides/hi/cpp/custom-font/) कर सकते हैं ताकि Aspose.Slides रेंडरिंग और रूपांतरण के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**  
नहीं। फ़ॉन्ट प्रदान करने और उनके लाइसेंस का पालन करने की जिम्मेदारी आपके ऊपर है।

**क्या प्रतिस्थापन परिणाम Windows, Linux और macOS में अलग हो सकते हैं?**  
हाँ। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार भिन्न होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरी पर प्रतिस्थापन की आवश्यकता हो सकती है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे बनाएं?**  
हर मशीन या कंटेनर पर समान फ़ॉन्ट फ़ाइलें और संस्करण उपयोग करें, आवश्यक [load external fonts](/slides/hi/cpp/custom-font/) लोड करें, और लाइसेंस की अनुमति होने पर [embed fonts](/slides/hi/cpp/embedded-font/) का उपयोग करें। आप निर्यात से पहले अप्रत्याशित प्रतिस्थापन पहचानने के लिए [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) को भी कॉल कर सकते हैं।