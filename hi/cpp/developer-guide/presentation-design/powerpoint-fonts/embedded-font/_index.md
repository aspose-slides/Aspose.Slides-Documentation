---
title: C++ में प्रस्तुतियों में फ़ॉन्ट एम्बेड करना
linktitle: एम्बेडेड फ़ॉन्ट्स
type: docs
weight: 40
url: /hi/cpp/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एम्बेड करें
- फ़ॉन्ट एम्बेडिंग
- एम्बेडेड फ़ॉन्ट प्राप्त करें
- एम्बेडेड फ़ॉन्ट जोड़ें
- एम्बेडेड फ़ॉन्ट हटाएँ
- एम्बेडेड फ़ॉन्ट संपीड़ित करें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: Aspose.Slides for C++ के साथ PowerPoint में एम्बेडेड फ़ॉन्ट्स का प्रबंधन करें। फ़ॉन्ट जोड़ें, प्राप्त करें, हटाएँ और फ़ाइल आकार को कम करने तथा पाठ का रूप बनाए रखने के लिए फ़ॉन्ट्स को संपीड़ित करें।
---
## **परिचय**

एम्बेडेड फ़ॉन्ट्स फ़ॉन्ट डेटा को PowerPoint प्रस्तुति के भीतर संग्रहीत करते हैं। जब कोई व्यूअर एम्बेडेड फ़ॉन्ट्स का समर्थन करता है, तो वह लक्ष्य सिस्टम पर स्थापित न होने वाले फ़ॉन्ट्स का उपयोग करके भी पाठ को प्रदर्शित कर सकता है। यह लाइन ब्रेक, पाठ_spacing, और स्लाइड लेआउट को संरक्षित रखने में मदद करता है।

Aspose.Slides for C++ आपको एम्बेडेड फ़ॉन्ट्स को प्राप्त करने, जोड़ने और हटाने की अनुमति देता है, यह आप एक [Presentation::get_FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_fontsmanager/) मेथड का उपयोग करके एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) पर कर सकते हैं। आप प्रस्तुति द्वारा उपयोग न किए गए अक्षरों को हटाकर एम्बेडेड फ़ॉन्ट डेटा का आकार भी कम कर सकते हैं।

निम्नलिखित उदाहरण PPTX फ़ाइलों के साथ काम करते हैं। फ़ॉन्ट को एम्बेड करने से पहले, सुनिश्चित करें कि उसका फ़ॉन्ट डेटा Aspose.Slides के लिए उपलब्ध है और उसका लाइसेंस एम्बेडिंग की अनुमति देता है।

## **एम्बेडेड फ़ॉन्ट्स प्राप्त करें और हटाएँ**

एक प्रस्तुति में संग्रहीत फ़ॉन्ट्स की सूची प्राप्त करने के लिए आप [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) का उपयोग कर सकते हैं। किसी फ़ॉन्ट को हटाने के लिए, उस सूची से एक फ़ॉन्ट को [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/removeembeddedfont/) को पास करें, फिर प्रस्तुति को सहेजें।

निम्नलिखित उदाहरण `EmbeddedFonts.pptx` में एम्बेडेड फ़ॉन्ट्स की सूची देता है और यदि Calibri मौजूद है तो उसे हटाता है:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

एक एम्बेडेड फ़ॉन्ट को हटाने से उसका संग्रहीत फ़ॉन्ट डेटा हट जाता है; यह टेक्स्ट को सौंपे गए फ़ॉन्ट को बदलता नहीं है। यदि फ़ॉन्ट लक्ष्य सिस्टम पर स्थापित है, तो टेक्स्ट अभी भी उसका उपयोग कर सकता है। अन्यथा, रेंडरिंग के लिए [फ़ॉन्ट प्रतिस्थापन](/slides/hi/cpp/font-substitution/) की आवश्यकता हो सकती है, जो लेआउट को प्रभावित कर सकता है।

## **फ़ॉन्ट डेटा और एम्बेडिंग अनुमतियों की जांच**

फ़ॉन्ट्स को एम्बेड करने से पहले जांचने के लिए आप [IFontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/) इंटरफ़ेस का उपयोग कर सकते हैं। प्रस्तुति में उपयोग किए गए फ़ॉन्ट्स को प्राप्त करने के लिए आप [IFontsManager::GetFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/getfonts/) को कॉल करें। प्रत्येक फ़ॉन्ट के लिए, एक [IFontData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontdata/) ऑब्जेक्ट और आवश्यक [FontStyleType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontstyletype/) मान को [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/getfontbytes/) को पास करें। यह मेथड उस फ़ॉन्ट शैली के लिए बाइनरी डेटा लौटाता है, या जब अनुरोधित फ़ॉन्ट या शैली उपलब्ध नहीं होती है तो `nullptr` लौटाता है। इस `nullptr` परिणाम को [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/) में पास न करें, क्योंकि यह मेथड बाइट ऐरे की आवश्यकता रखता है।

[EmbeddingLevel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/embeddinglevel/) एक फ्लैग्स एन्‍युमरेशन है जो फ़ॉन्ट में संग्रहीत एम्बेडिंग प्रतिबंधों को दर्शाता है:
- `Installable` एम्बेडिंग और किसी अन्य सिस्टम पर स्थायी स्थापना की अनुमति देता है, फ़ॉन्ट लाइसेंस के अधीन।
- `Restricted` एम्बेडिंग को रोकता है जब तक कि फ़ॉन्ट के कानूनी मालिक से अनुमति न ले ली जाए, जब यह केवल उपयोग-अनुमति फ्लैग हो।
- `PreviewPrint` दृश्य और प्रिंटिंग के लिए अस्थायी उपयोग की अनुमति देता है; फ़ॉन्ट शामिल करने वाले दस्तावेज़ को केवल-पढ़ने योग्य होना चाहिए।
- `Editable` अस्थायी उपयोग की अनुमति देता है और दस्तावेज़ को संपादित और सहेजा जा सकता है।
- `NoSubsetting` एक अतिरिक्त प्रतिबंध है जो ग्लिफ़ के केवल एक उपसमुच्चय को एम्बेड करने से रोकता है। जब यह फ्लैग मौजूद हो, तो सभी अक्षरों को एम्बेड करें।
- `BitmapOnly` एक अतिरिक्त प्रतिबंध है जो केवल बिटमैप स्ट्राइक्स को एम्बेड करने की अनुमति देता है, आउटलाइन डेटा नहीं। यदि फ़ॉन्ट में कोई बिटमैप स्ट्राइक्स नहीं हैं, तो इसे एम्बेड नहीं किया जा सकता।

पहले चार मान उपयोग अनुमति का वर्णन करते हैं, जबकि `NoSubsetting` और `BitmapOnly` को उनके साथ संयोजित किया जा सकता है। संशोधकों की जाँच बिटवाइज़ ऑपरेशन्स के साथ करें। क्योंकि `Installable` शून्य है, उपयोग-अनुमति बिट्स को मास्क करें और परिणाम को `Installable` से तुलना करें। वर्तमान फ़ॉन्ट्स को अधिकतम एक उपयोग-अनुमति बिट सेट करना चाहिए। यदि पुराने फ़ॉन्ट्स में एक से अधिक बिट सेट हैं, तो नीचे दिया गया हेल्पर सबसे कम प्रतिबंधित अनुमति चुनता है: `Editable`, फिर `PreviewPrint`, फिर `Restricted`।

निम्नलिखित उदाहरण `GetFonts` द्वारा लौटाए गए प्रत्येक फ़ॉन्ट के सामान्य, बोल्ड, इटैलिक और बोल्ड-इटैलिक डेटा का ऑडिट करता है। यह अनुपलब्ध शैलियों, प्रतिबंधित फ़ॉन्ट्स, केवल-बिटमैप फ़ॉन्ट्स, प्रीव्यू और प्रिंट तक सीमित फ़ॉन्ट्स (क्योंकि आउटपुट अभी भी संपादन योग्य रहता है), तथा पहले से एम्बेडेड फ़ॉन्ट्स को छोड़ देता है। यदि किसी उपलब्ध शैली में `NoSubsetting` है, तो वह फ़ॉन्ट परिवार के सभी अक्षरों को एम्बेड करता है।

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

यह जांच प्रत्येक फ़ॉन्ट फ़ाइल में एन्कोडेड प्रतिबंधों की रिपोर्ट करती है। यह किसी लाइसेंस को प्रदान नहीं करती, न ही यह सिद्ध करती है कि आपने फ़ॉन्ट कानूनी रूप से प्राप्त किया है, और एम्बेडेड कॉपी वितरित करने से पहले फ़ॉन्ट के लाइसेंस समझौते की जाँच को प्रतिस्थापित नहीं करती।

## **एंबेडेड फ़ॉन्ट्स जोड़ें**

[IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/addembeddedfont/) का उपयोग करके आप एक फ़ॉन्ट को एम्बेड कर सकते हैं। इसके ओवरलोड्स या तो एक [IFontData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontdata/) ऑब्जेक्ट या फ़ॉन्ट डेटा वाली बाइट ऐरे स्वीकार करते हैं। [EmbedFontCharacters](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/embedfontcharacters/) एन्‍युमरेशन यह नियंत्रित करता है कि किन अक्षरों को शामिल किया जाए:
- [All](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/embedfontcharacters/) फ़ॉन्ट में सभी अक्षरों को एम्बेड करता है। इस विकल्प का उपयोग तब करें जब प्राप्तकर्ताओं को प्रस्तुति को संपादित करने और नया टेक्स्ट दर्ज करने की आवश्यकता हो।
- [OnlyUsed](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/embedfontcharacters/) केवल प्रस्तुति में उपयोग किए गए अक्षरों को एम्बेड करता है जिससे फ़ाइल आकार कम हो जाता है। इस विकल्प को अंतिम प्रस्तुति के लिए चुनें जिसका मुख्य उद्देश्य दर्शक होना है।

निम्नलिखित उदाहरण [IFontsManager::GetFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/getfonts/) का उपयोग करके `Fonts.pptx` में उपयोग किए गए फ़ॉन्ट्स को प्राप्त करता है और उन फ़ॉन्ट्स को एम्बेड करता है जो पहले से एम्बेडेड नहीं हैं। जोड़ने के लिये फ़ॉन्ट्स को उस मशीन पर उपलब्ध होना चाहिए जहाँ कोड चल रहा है। मौजूदा एम्बेडेड फ़ॉन्ट्स अपने वर्तमान अक्षर सेट को बनाए रखते हैं।

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **एंबेडेड फ़ॉन्ट्स संपीड़ित करें**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) अप्रयुक्त अक्षरों को हटाकर एम्बेडेड फ़ॉन्ट डेटा को कम करता है। यह पहले से एम्बेडेड फ़ॉन्ट्स पर काम करता है, इसलिए आकार में कमी इस बात पर निर्भर करती है कि प्रस्तुति में कितना अप्रयुक्त फ़ॉन्ट डेटा है।

निम्नलिखित उदाहरण `EmbeddedFonts.pptx` में फ़ॉन्ट्स को संपीड़ित करता है और परिणाम को अलग फ़ाइल के रूप में सहेजता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

यदि प्राप्तकर्ताओं को बाद में टेक्स्ट जोड़ने की आवश्यकता हो, तो मूल फ़ाइल को रखें। संपीड़न के दौरान हटाए गए अक्षर अब एम्बेडेड फ़ॉन्ट से उपलब्ध नहीं रहेंगे, भले ही आपने मूल रूप से सभी अक्षर एम्बेड किए हों।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जाँच सकता हूँ कि एम्बेडेड फ़ॉन्ट रेंडरिंग के दौरान भी प्रतिस्थापित होगा या नहीं?**

प्रस्तुति को रेंडर करने वाले पर्यावरण में आप [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontsmanager/getsubstitutions/) को कॉल करके देख सकते हैं कि Aspose.Slides कौन से फ़ॉन्ट को बदल देगा। साथ ही [फ़ॉन्ट प्रतिस्थापन](/slides/hi/cpp/font-substitution/) सेटिंग्स और [फ़ॉन्ट फ़ॉलबैक](/slides/hi/cpp/fallback-font/) नियमों की जाँच करें। फ़ॉलबैक अनुपलब्ध अक्षरों को संभालता है, इसलिए फ़ॉन्ट को एम्बेड करने से उन अक्षरों का समाधान नहीं होता जो फ़ॉन्ट में मूलतः उपस्थित नहीं हैं।

**क्या मुझे Arial और Calibri जैसे सामान्य फ़ॉन्ट्स को एम्बेड करना चाहिए?**

निर्णय लक्ष्य पर्यावरण पर आधारित होना चाहिए। यदि आवश्यक फ़ॉन्ट्स प्रत्येक मशीन पर उपलब्ध हैं जो प्रस्तुति को खोलती या रेंडर करती है, तो उन्हें एम्बेड करने से फ़ाइल आकार अनावश्यक रूप से बढ़ सकता है। यदि प्राप्तकर्ताओं या सर्वरों में ये फ़ॉन्ट्स नहीं हो सकते हैं, तो उन्हें एम्बेड करने से इच्छित दिखावट को संरक्षित रखने में मदद मिलती है, बशर्ते उनके लाइसेंस ऐसा करने की अनुमति दें।