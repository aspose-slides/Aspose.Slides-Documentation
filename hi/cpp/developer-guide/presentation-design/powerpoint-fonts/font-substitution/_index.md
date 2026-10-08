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
- प्रतिस्थापन नियम
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ में PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या रूपांतरित करते समय Aspose.Slides के लिए फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट्स का निरीक्षण करें।"
---
## **अवलोकन**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को प्रस्तुतिकरण के रेंडर या रूपांतरण के समय उन फ़ॉन्टों के स्थान पर उपलब्ध फ़ॉन्ट का उपयोग करने देता है जो पहुँचा नहीं जा सकता। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति सामग्री में असाइन किए गए फ़ॉन्ट को नहीं बदलता।

आप उस फ़ॉन्ट को निर्धारित कर सकते हैं जिसका उपयोग तब किया जाए जब कोई विशेष फ़ॉन्ट उपलब्ध न हो, और आप वह प्रतिस्थापन देख सकते हैं जो Aspose.Slides रेंडरिंग के दौरान करेगा। यह विभिन्न स्थापित फ़ॉन्ट वाले वातावरणों में आउटपुट को सुसंगत रखने में मदद करता है।

यदि कोई फ़ॉन्ट उपलब्ध है लेकिन उसके पास समर्पित बोल्ड टाइपफ़ेस नहीं है, तो देखें [Handle Fonts Without a Dedicated Bold Typeface](/slides/hi/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)। वह अनुभाग PDF निर्यात के दौरान प्रभावित टेक्स्ट को रास्टराइज़ करने और टेक्स्ट चयन, खोज और स्केलिंग पर इसके प्रभावों की व्याख्या करता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

रेंडरिंग के समय किन फ़ॉन्टों को प्रतिस्थापित किया जाएगा, यह निर्धारित करने के लिए [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) मेथड का उपयोग करें। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करता है।

निम्नलिखित C++ उदाहरण एक प्रस्तुति के सभी फ़ॉन्ट प्रतिस्थापनों की सूची देता है:

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

एक `System::ArrayPtr<int32_t> slides` तर्क के साथ [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) ओवरलोड का उपयोग करें ताकि केवल उन प्रतिस्थापनों को देखा जा सके जो विशिष्ट स्लाइड्स को रेंडर करने के लिए आवश्यक हैं। यह उपयोगी है जब आप प्रस्तुति का भाग रेंडर या निर्यात कर रहे हों, बड़े प्रस्तुति को क्रमिक रूप से जांच रहे हों, उन स्लाइड्स को ढूँढ रहे हों जो अनुपलब्ध फ़ॉन्ट पर निर्भर हैं, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या अप्रासंगिक स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर को निदान कर रहे हों।

`slides` एरे एक‑आधारित स्लाइड इंडेक्स रखता है: `1` पहली स्लाइड को पहचानता है। इसके विपरीत, [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) मेथड शून्य‑आधारित इंडेक्स उपयोग करता है, इसलिए वही स्लाइड `presentation->get_Slide(0)` से पहुँची जाती है। एरे बनाते समय इस अंतर का ध्यान रखें ताकि ऑफ‑बाय‑वन त्रुटियों से बचा जा सके।

ओवरलोड को [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) मेथड के माध्यम से कॉल करें। यह केवल चयनित स्लाइड्स को रेंडर करने के दौरान निर्धारित प्रतिस्थापनों को लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम होते हैं। परिणाम वर्तमान फ़ॉन्ट वातावरण, कॉन्फ़िगर किए गए फॉलबैक नियम, [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, और [externally loaded fonts](/slides/hi/cpp/custom-font/) को प्रतिबिंबित करता है।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइड्स द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंट्री या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को डिडुप्लिकेट करें। निम्नलिखित उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग्स की सॉर्टेड सूची बनाता है:

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

[IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) इंटरफ़ेस दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | कब उपयोग करें |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) बिना तर्कों के | जब आपको पूरी प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) `System::ArrayPtr<int32_t> slides` के साथ | जब आपको चयनित रेंज, क्रमिक जांच, या भागीदार निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम निर्धारित करें**

जब स्रोत फ़ॉन्ट उपलब्ध नहीं हो, तो Aspose.Slides को कौन सा फ़ॉन्ट उपयोग करना चाहिए, यह निर्दिष्ट करने के लिए:

1. प्रस्तुति लोड करें।
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएं।
3. [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) को [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/) शर्त के साथ बनाएं।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) मेथड का उपयोग करके संग्रह को असाइन करें।
6. प्रस्तुति को रेंडर या रूपांतरित करें।

निम्नलिखित C++ उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम सत्यापित करने के लिए पहली स्लाइड को रेंडर करता है। प्रतिस्थापित फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

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

{{% alert color="info" title="Note" %}}
पूरी प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट को बिना शर्त बदलने के लिए, देखें [Font Replacement](/slides/hi/cpp/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्ट के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान उपयोग किए जाने वाले मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं। वे सामान्य टेक्स्ट के लिए काम करते हैं जब Aspose.Slides एक असुलभ फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

Office Math समीकरणों में अतिरिक्त आवश्यकता होती है। यदि कोई समीकरण **Cambria Math** का उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडर करने के लिए वही फ़ॉन्ट चाहिए हो सकता है। कोई नियम जो किसी अन्य गणित फ़ॉन्ट, जैसे **STIX Two Math**, को प्रतिस्थापित करता है, वह इस उद्देश्य के लिए **Cambria Math** को बदल नहीं सकता, और रेंडरिंग अभी भी रिपोर्ट कर सकती है कि **Cambria Math** आवश्यक है।

ऐसी प्रस्तुति को रेंडर या रूपांतरित करने के लिए, **Cambria Math** को Aspose.Slides के लिए उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में स्थापित करें या एक [external font](/slides/hi/cpp/custom-font/) के रूप में लोड करें।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति टेक्स्ट पर अभी भी लागू होते हैं।

## **FAQ**

**फ़ॉन्ट रिप्लेसमेंट और फ़ॉन्ट प्रतिस्थापन में क्या अंतर है?**

[Font replacement](/slides/hi/cpp/font-replacement/) इरादतन पूरे प्रस्तुति में एक फ़ॉन्ट को दूसरे से बदलता है। फ़ॉन्ट प्रतिस्थापन तब रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है जब कॉन्फ़िगर की गई शर्त पूरी होती है, जैसे मूल फ़ॉन्ट उपलब्ध न हो।

**प्रतिस्थापन नियम कब लागू होते हैं?**

नियम रेंडरिंग और रूपांतरण के दौरान [font selection sequence](/slides/hi/cpp/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं सकता।

**जब फ़ॉन्ट अनुपलब्ध हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकटतम उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम वातावरण में उपलब्ध फ़ॉन्टों पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिए बाहरी फ़ॉन्ट लोड कर सकता हूँ?**

हां। आप [load external fonts](/slides/hi/cpp/custom-font/) कर सकते हैं ताकि Aspose.Slides रेंडरिंग और रूपांतरण के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करने और उनके लाइसेंस का पालन करने की जिम्मेदारी आपके पास है।

**क्या प्रतिस्थापन परिणाम Windows, Linux, और macOS में भिन्न हो सकते हैं?**

हां। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार अलग होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरे पर प्रतिस्थापन की आवश्यकता पैदा कर सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे बनाएं?**

हर मशीन या कंटेनर पर समान फ़ॉन्ट फ़ाइलें और संस्करण रखें, [load required external fonts](/slides/hi/cpp/custom-font/) करें, और लाइसेंस की अनुमति मिलने पर [embed fonts](/slides/hi/cpp/embedded-font/) करें। आप निर्यात से पहले अप्रत्याशित प्रतिस्थापन की पहचान करने के लिए [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) भी कॉल कर सकते हैं।