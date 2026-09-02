---
title: C++ में PowerPoint प्रस्तुतियों में टेक्स्ट खोजें और बदलें
linktitle: टेक्स्ट खोजें और बदलें
type: docs
weight: 55
url: /hi/cpp/search-and-replace-text/
keywords:
- टेक्स्ट खोजें
- टेक्स्ट हाइलाइट करें
- टेक्स्ट बदलें
- रेगुलर एक्सप्रेशन
- रिजल्ट कॉलबैक
- टेक्स्ट फ्रेम
- ऑडिट रिपोर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में टेक्स्ट खोजें, हाइलाइट करें और बदलें, साथ ही Aspose.Slides for C++ के साथ प्रत्येक मैच इकट्ठा करें।"
---
## **परिचय**

Aspose.Slides for C++ व्यक्तिगत टेक्स्ट फ्रेम या पूरी प्रस्तुति में टेक्स्ट को खोज, हाइलाइट और बदल सकता है। प्रत्येक ऑपरेशन परिणाम कॉलबैक के माध्यम से प्रत्येक मैच के बारे में एप्लिकेशन को सूचित भी कर सकता है। इससे प्रस्तुति को अपडेट करना और मिलान किए गए टेक्स्ट, उसका संदर्भ, स्थिति, टेक्स्ट फ्रेम और स्लाइड नंबर सहित ऑडिट ट्रेल बनाना संभव हो जाता है।

इन क्षमताओं का उपयोग समीक्षा, रेडैक्शन, शब्दावली जांच, टेम्पलेट सफ़ाई और स्वचालित रिपोर्टिंग वर्कफ़्लोज़ के लिए किया जा सकता है।

नीचे पहले उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करते हैं, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है जिसमें निम्नलिखित टेक्स्ट है:

![नमूना टेक्स्ट](sample_text.png)

## **खोज सीमा चुनें**

एक ऑपरेशन को एक टेक्स्ट फ्रेम तक सीमित करने के लिए [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) पर विधियों का उपयोग करें। प्रस्तुति में सभी लागू टेक्स्ट को प्रोसेस करने के लिए [IPresentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/) पर विधियों का उपयोग करें।

| ऑपरेशन | एक टेक्स्ट फ्रेम | पूरी प्रस्तुति |
|---|---|---|
| शाब्दिक टेक्स्ट को हाइलाइट करें | [ITextFrame::HighlightText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/highlighttext/) |
| रेगुलर एक्सप्रेशन मिलानों को हाइलाइट करें | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/highlightregex/) |
| शाब्दिक टेक्स्ट को बदलें | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/replacetext/) |
| रेगुलर एक्सप्रेशन मिलानों को बदलें | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/replaceregex/) |

## **टेक्स्ट मिलान कॉन्फ़िगर करें**

शाब्दिक-टेक्स्ट ऑपरेशनों के लिए, मिलान को नियंत्रित करने हेतु [ITextSearchOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/) का उपयोग करें:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) पूर्ण शब्दों तक मैच को सीमित करता है।
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) यह नियंत्रित करता है कि अक्षर केस मिलना चाहिए या नहीं।
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_includenotes/) प्रस्तुति‑स्तरीय खोज, प्रतिस्थापन और हाइलाइट ऑपरेशनों में स्लाइड नोट्स को शामिल करता है।

रेगुलर‑एक्सप्रेशन ऑपरेशनों में `System::Text::RegularExpressions::Regex` का उपयोग किया जाता है, इसलिए केस संवेदनशीलता और शब्द सीमाएँ जैसी मिलान नियम अभिव्यक्ति और उसकी विकल्पों द्वारा परिभाषित होते हैं।

## **कॉलबैक के साथ मैच जानकारी एकत्र करें**

प्रत्येक मैच के लिए सूचना प्राप्त करने हेतु [IFindResultCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifindresultcallback/) को लागू करें। इसके [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifindresultcallback/foundresult/) मेथड में संबंधित टेक्स्ट फ्रेम, स्रोत टेक्स्ट, मैच किया गया टेक्स्ट और मैच स्थिति प्रदान की जाती है।

कॉलबैक सीधे स्लाइड नंबर नहीं प्राप्त करता। नीचे दिया गया कार्यान्वयन इसे [ISlideComponent::get_Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecomponent/get_slide/) से प्राप्त करता है और [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inotesslide/get_parentslide/) के माध्यम से नोट्स स्लाइड में मिला टेक्स्ट भी संभालता है। एक nullable स्लाइड नंबर समान परिणाम मॉडल को अन्य स्लाइड प्रकारों से जुड़े टेक्स्ट का प्रतिनिधित्व करने की अनुमति देता है।

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        SharedPtr<IBaseSlide> baseSlide = textFrame->get_Slide();
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

प्रतिस्थापन ऑपरेशनों के लिए, `FoundText` में मूल मिलान किया गया टेक्स्ट होता है, इसलिए कॉलबैक ठीक-ठीक रिकॉर्ड कर सकता है कि कौन से शब्द बदले गए।

## **टेक्स्ट को हाइलाइट करें**

[ITextFrame::HighlightText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlighttext/) मेथड का उपयोग करके टेक्स्ट फ्रेम में शाब्दिक‑टेक्स्ट मैच को हाइलाइट करें। खोज को नियंत्रित करने हेतु [ITextSearchOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/) पास करें और मैच विवरण एकत्र करने के लिए कॉलबैक प्रदान करें।

नीचे दिया गया कोड उदाहरण सभी **"try"** अक्षरों की घटनाओं को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है। दोनों खोजें अपने मैच को समान कॉलबैक को रिपोर्ट करती हैं।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Get the first shape from the first slide.
 // पहला आकार पहले स्लाइड से प्राप्त करें।
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
 // टेक्स्ट फ़्रेम में "try" के सभी प्रकटनों को हाइलाइट करें।
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
 // केवल पूर्ण शब्द "to" को हाइलाइट करें।
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![हाइलाइट किया गया टेक्स्ट](highlighted_text.png)

## **रेगुलर एक्सप्रेशन का उपयोग करके टेक्स्ट को हाइलाइट करें**

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlightregex/) मेथड रेगुलर एक्सप्रेशन द्वारा खोजे गए टेक्स्ट मैच को टेक्स्ट फ्रेम में हाइलाइट करता है।

निम्नलिखित कोड सात या अधिक अक्षरों वाले सभी शब्दों को हाइलाइट करता है और प्रत्येक मैच को एकत्र करता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![रेगुलर एक्सप्रेशन का उपयोग करके हाइलाइट किया गया टेक्स्ट](highlighted_text_using_regex.png)

## **पूरी प्रस्तुति में टेक्स्ट को हाइलाइट करें**

[IPresentation::HighlightText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/highlighttext/) और [IPresentation::HighlightRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/highlightregex/) का उपयोग करके प्रस्तुति में सभी लागू टेक्स्ट फ्रेम को खोजें। नीचे दिया गया उदाहरण एक शाब्दिक शब्द और सभी ई‑मेल पते को हाइलाइट करता है तथा दो खोजों के लिए अलग-अलग परिणाम संग्रह रखता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **टेक्स्ट फ्रेम में टेक्स्ट को बदलें**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replacetext/) का उपयोग शाब्दिक टेक्स्ट के लिए और [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replaceregex/) का उपयोग पैटर्न‑आधारित प्रतिस्थापन के लिए करें। ये मेथड मौजूदा टेक्स्ट फ्रेम में मिलान किए गए टेक्स्ट को अपडेट करते हैं, जिससे आस‑पास के भागों का फॉर्मेट बरकरार रहता है, बजाय पूरे टेक्स्ट फ्रेम को साधारण स्ट्रिंग से पुनः बनाये जाने के।

निम्नलिखित उदाहरण वर्तनी वैरिएंट को मानकीकृत करता है और फिर संस्करण लेबल को बदलता है। समान कॉलबैक दोनों ऑपरेशनों द्वारा मिलाए गए मूल शब्दों को रिकॉर्ड करता है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

यदि कोई मैच कई अलग-अलग फॉर्मेट वाले हिस्सों को कवर करता है, तो आउटपुट की जाँच करें यह सुनिश्चित करने के लिए कि प्रतिस्थापन टेक्स्ट पर कौन सा फॉर्मेट लागू होना चाहिए।

## **पूरी प्रस्तुति में टेक्स्ट को बदलें**

[IPresentation::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/replacetext/) और [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/replaceregex/) का उपयोग करके समान ऑपरेशनों को पूरी प्रस्तुति में लागू करें। यह टेम्पलेट सफ़ाई, शब्दावली अपडेट और रेडैक्शन के लिए उपयोगी है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **रिपोर्टिंग के लिए मैच समूहित करें**

चूँकि प्रत्येक परिणाम अपना स्लाइड नंबर और टेक्स्ट फ्रेम संग्रहीत करता है, एप्लिकेशन ऑडिट, रिपोर्टिंग या समीक्षा वर्कफ़्लोज़ के लिए मैच को समूहित कर सकते हैं। नीचे दिया गया उदाहरण पहले स्लाइड और फिर टेक्स्ट फ्रेम के अनुसार एकत्रित परिणामों को समूहित करता है:

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **FAQ**

**मैं पूरी प्रस्तुति के बजाय केवल एक टेक्स्ट बॉक्स को कैसे खोज सकता हूँ?**

शेप के टेक्स्ट फ्रेम को प्राप्त करें और उस टेक्स्ट फ्रेम पर [ITextFrame::HighlightText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replacetext/), या [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replaceregex/) को कॉल करें। प्रस्तुति‑स्तरीय मेथड सभी लागू टेक्स्ट फ्रेम को प्रोसेस करते हैं।

**मैं सही कैपिटलाइज़ेशन के साथ पूर्ण शब्दों को कैसे मैच करूँ?**

[ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) और [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) को `true` के साथ कॉल करें, और विकल्पों को शाब्दिक‑टेक्स्ट हाइलाइट या प्रतिस्थापन मेथड को पास करें। रेगुलर एक्सप्रेशन के लिए, `System::Text::RegularExpressions::Regex` में स्वयं शब्द सीमाएँ और केस संवेदनशीलता परिभाषित करें।

**क्या खोज और प्रतिस्थापन स्लाइड नोट्स में टेक्स्ट को शामिल कर सकता है?**

हाँ। जब प्रस्तुति‑स्तरीय शाब्दिक‑टेक्स्ट ऑपरेशन इस्तेमाल हो रहा हो, तो [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_includenotes/) को `true` के साथ कॉल करें। ऊपर दिखाए गए कॉलबैक कार्यान्वयन में नोट्स स्लाइड के मैच को उसके पैरेंट स्लाइड नंबर से मैप किया जाता है।

**मैं प्रस्तुति को दूसरी बार स्कैन किए बिना रिपोर्ट कैसे बना सकता हूँ?**

[IFindResultCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifindresultcallback/) कार्यान्वयन को हाइलाइट या प्रतिस्थापन ऑपरेशन में पास करें। कॉलबैक ऑपरेशन के चलने के दौरान प्रत्येक मैच प्राप्त करता है, जिससे एप्लिकेशन स्रोत टेक्स्ट, मैच किया गया टेक्स्ट, स्थिति, टेक्स्ट फ्रेम और व्युत्पन्न स्लाइड नंबर को बाद में समूहित या निर्यात करने के लिए संग्रहीत कर सके।

**क्या टेक्स्ट को बदलने से उसका फॉर्मेट बरकरार रहता है?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replacetext/) और [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replaceregex/) मिलान किए गए टेक्स्ट को मौजूदा टेक्स्ट फ्रेम के भीतर संशोधित करते हैं और आस‑पास के भागों का फॉर्मेट बरकरार रखते हैं। यदि कोई मैच विभिन्न फॉर्मेट वाले हिस्सों को कवर करता है, तो परिणाम की जांच करें यह सुनिश्चित करने के लिए कि प्रतिस्थापन वांछित स्टाइल का उपयोग करे।