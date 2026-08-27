---
title: C++ में PowerPoint प्रस्तुतियों में टेक्स्ट खोजें और बदलें
linktitle: टेक्स्ट खोजें और बदलें
type: docs
weight: 55
url: /hi/cpp/search-and-replace-text/
keywords:
- टेक्स्ट खोजें
- टेक्स्ट हाईलाइट करें
- टेक्स्ट बदलें
- नियमित अभिव्यक्ति
- परिणाम कॉलबैक
- टेक्स्ट फ्रेम
- ऑडिट रिपोर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ हर मिलान को एकत्र करते हुए PowerPoint प्रस्तुतियों में टेक्स्ट खोजें, हाईलाइट करें और बदलें।"
---
## **अवलोकन**

Aspose.Slides for C++ एकल टेक्स्ट फ्रेम या पूरी प्रस्तुति में टेक्स्ट को खोज, हाईलाइट और बदल सकता है। प्रत्येक ऑपरेशन परिणाम कॉलबैक के माध्यम से प्रत्येक मिलान के बारे में एप्लिकेशन को सूचित कर सकता है। इससे प्रस्तुति को अपडेट करते हुए मिलान किए गए टेक्स्ट, उसका संदर्भ, स्थिति, टेक्स्ट फ्रेम, और स्लाइड नंबर वाली ऑडिट ट्रेल बनाना संभव होता है।

इन क्षमताओं का उपयोग समीक्षा, रिडैक्शन, टर्मिनोलॉजी जांच, टेम्पलेट सफाई, और स्वचालित रिपोर्टिंग वर्कफ़्लो में किया जा सकता है।

निम्न पहले उदाहरणों में हम "sample.pptx" फ़ाइल का उपयोग करते हैं, जिसमें पहली स्लाइड पर एक टेक्स्ट बॉक्स है जिसमें निम्नलिखित टेक्स्ट है:

![उदाहरण पाठ](sample_text.png)

## **खोज का दायरा चुनें**

[ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) पर विधियों का उपयोग करके ऑपरेशन को एक टेक्स्ट फ्रेम तक सीमित करें। [IPresentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/) पर विधियों का उपयोग करके प्रस्तुति में सभी लागू टेक्स्ट को प्रोसेस करें।

| ऑपरेशन | एक टेक्स्ट फ्रेम | संपूर्ण प्रस्तुति |
|---|---|---|
| शाब्दिक टेक्स्ट को हाईलाइट करें | [ITextFrame::HighlightText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/highlighttext/) |
| रेगुलर‑एक्सप्रेशन मिलानों को हाईलाइट करें | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/highlightregex/) |
| शाब्दिक टेक्स्ट को बदलें | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/replacetext/) |
| रेगुलर‑एक्सप्रेशन मिलानों को बदलें | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/replaceregex/) |

## **टेक्स्ट मिलान को कॉन्फ़िगर करें**

शाब्दिक‑टेक्स्ट ऑपरेशनों के लिए, मिलान को नियंत्रित करने हेतु [ITextSearchOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/) का उपयोग करें:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) केवल पूर्ण शब्दों पर मिलान को सीमित करता है।
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) यह निर्धारित करता है कि अक्षर केस मेल खानी चाहिए या नहीं।
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_includenotes/) प्रस्तुति‑स्तर की खोज, प्रतिस्थापन और हाईलाइट ऑपरेशनों में स्लाइड नोट्स को शामिल करता है।

रेगुलर‑एक्सप्रेशन ऑपरेशनों में `System::Text::RegularExpressions::Regex` का उपयोग होता है, इसलिए केस‑सेंसिटिविटी और शब्द सीमाओं जैसी नियम अभिव्यक्ति और उसकी सेटिंग्स द्वारा निर्धारित होते हैं।

## **टेक्स्ट फ्रेम के मालिक की पहचान करें**

सामान्य टेक्स्ट‑प्रसंस्करण वर्कफ़्लो अक्सर एक [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) प्राप्त करते हैं जबकि खोज, प्रतिस्थापन, मान्यकरण या निर्यात किया जाता है। टेक्स्ट फ्रेम के मालिक को निर्धारित करने हेतु [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentshape/) और [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentcell/) का उपयोग करें।

अपेक्षित मान मालिक पर निर्भर करते हैं:

| टेक्स्ट फ्रेम मालिक | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| एक AutoShape या अन्य टेक्स्ट‑धारक आकृति | मालिक वाला [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) | `nullptr` |
| एक तालिका कोशिका | `nullptr` | मालिक वाली [ICell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icell/) |

दोनों विधियां केवल‑पढ़ने योग्य नेविगेशन प्रदान करती हैं। इन्हें कॉल करने से टेक्स्ट फ्रेम नहीं चलता और न ही उसका मालिक बदलता है। सामान्य कोड को दोनों मानों को `nullptr` के लिए जांचना चाहिए और इस संभावना को संभालना चाहिए कि कोई भी मालिक उपलब्ध न हो।

निम्न उदाहरण में [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/getalltextframes/) का उपयोग करके प्रस्तुति में सभी टेक्स्ट फ्रेमों पर इटरेट किया गया है। आकृतियों के लिए यह आकृति का नाम, C++ रन‑टाइम टाइप, और सम्मिलित स्लाइड को रिपोर्ट करता है। तालिका कोशिकाओं के लिए यह शून्य‑आधारित कॉलम और पंक्ति निर्देशांक तथा सम्मिलित स्लाइड को रिपोर्ट करता है।

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using Aspose::Slides::Presentation;
using Aspose::Slides::Util::SlideUtil;
using System::AsCast;
using System::Console;
using System::MakeObject;
using System::String;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto textFrames = SlideUtil::GetAllTextFrames(presentation, false);

for (const auto& textFrame : textFrames)
{
    auto ownerShape = textFrame->get_ParentShape();
    if (ownerShape != nullptr)
    {
        auto shapeName = String::IsNullOrEmpty(ownerShape->get_Name()) ? u"(unnamed)" : ownerShape->get_Name();
        auto shapeType = ownerShape->GetType().get_Name();
        auto baseSlide = ownerShape->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Shape: {0}; type: {1}; {2}", shapeName, shapeType, slideLabel);
        continue;
    }

    auto ownerCell = textFrame->get_ParentCell();
    if (ownerCell != nullptr)
    {
        auto baseSlide = ownerCell->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Table cell: column {0}, row {1}; {2}", ownerCell->get_FirstColumnIndex(), ownerCell->get_FirstRowIndex(), slideLabel);
        continue;
    }

    Console::WriteLine(u"The text frame owner is not available as a shape or table cell.");
}
```

SmartArt सामग्री के लिए, [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) में आकृतियों पर इटरेट करें और प्रत्येक [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) तक पहुँचें। टेक्स्ट फ्रेम को इसके संबंधित आकृति से [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentshape/) के माध्यम से ट्रेस किया जा सकता है, जबकि [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr` लौटाता है। इसलिए उदाहरण में आकृति शाखा SmartArt नोड्स से आए टेक्स्ट को भी संभालती है।

## **कॉलबैक के साथ मैच जानकारी एकत्र करें**

हर मैच पर सूचना प्राप्त करने के लिए [IFindResultCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifindresultcallback/) को लागू करें। इसका [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifindresultcallback/foundresult/) मेथड संबंधित टेक्स्ट फ्रेम, स्रोत टेक्स्ट, मिलान किया गया टेक्स्ट, और मिलान स्थिति प्रदान करता है।

कॉलबैक सीधे स्लाइड नंबर नहीं प्राप्त करता। नीचे दिया गया कार्यान्वयन इसे [ISlideComponent::get_Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecomponent/get_slide/) से प्राप्त करता है और साथ ही [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/inotesslide/get_parentslide/) के माध्यम से नोट्स स्लाइड में मिले टेक्स्ट को भी संभालता है। nullable स्लाइड नंबर समान परिणाम मॉडल को अन्य स्लाइड प्रकारों से जुड़े टेक्स्ट को दर्शाने की अनुमति देता है।

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
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
        auto parentShape = textFrame->get_ParentShape();
        auto parentCell = textFrame->get_ParentCell();
        SharedPtr<IBaseSlide> baseSlide;

        if (parentShape != nullptr)
        {
            baseSlide = parentShape->get_Slide();
        }
        else if (parentCell != nullptr)
        {
            baseSlide = parentCell->get_Slide();
        }
        else
        {
            baseSlide = textFrame->get_Slide();
        }

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

प्रतिस्थापन ऑपरेशनों के लिए, `FoundText` मूल मिलान किए गए टेक्स्ट को रखता है, जिससे कॉलबैक सटीक रूप से रिकॉर्ड कर सकता है कि किन शब्दों को बदला गया।

## **टेक्स्ट को हाईलाइट करें**

एक टेक्स्ट फ्रेम में शाब्दिक‑टेक्स्ट मिलानों को हाईलाइट करने के लिए [ITextFrame::HighlightText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlighttext/) मेथड का प्रयोग करें। खोज को नियंत्रित करने के लिए [ITextSearchOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/) पास करें और मैच विवरण एकत्र करने के लिए एक कॉलबैक प्रदान करें।

नीचे दिया गया कोड उदाहरण सभी **"try"** अक्षरों की घटनाओं को हाईलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाईलाइट करता है। दोनों खोजें समान कॉलबैक को अपने मैच लौटाती हैं।

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
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
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

![हाइलाइट किया गया पाठ](highlighted_text.png)

## **रेगुलर एक्सप्रेशन्स के साथ टेक्स्ट को हाईलाइट करें**

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlightregex/) मेथड एक रेगुलर एक्सप्रेशन द्वारा पाए गए टेक्स्ट मिलानों को टेक्स्ट फ्रेम में हाईलाइट करता है।

निम्न कोड सभी सात या अधिक अक्षरों वाले शब्दों को हाईलाइट करता है और प्रत्येक मिलान को एकत्र करता है:

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

![रेगुलर एक्सप्रेशन के साथ हाइलाइट किया गया पाठ](highlighted_text_using_regex.png)

## **पूरे प्रस्तुति में टेक्स्ट को हाईलाइट करें**

[IPresentation::HighlightText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/highlighttext/) और [IPresentation::HighlightRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/highlightregex/) का उपयोग करके प्रस्तुति में सभी लागू टेक्स्ट फ्रेमों को खोजें। नीचे दिया गया उदाहरण एक शाब्दिक शब्द और सभी ई‑मेल पतों को अलग-अलग परिणाम संग्रहों के साथ हाईलाइट करता है।

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

शाब्दिक टेक्स्ट के लिए [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replacetext/) और पैटर्न‑आधारित प्रतिस्थापन के लिए [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replaceregex/) का उपयोग करें। ये मेथड मौजूदा टेक्स्ट फ्रेम के भीतर मिलान किए गए टेक्स्ट को अपडेट करते हैं, जिससे आसपास के फ़ॉर्मेट को बरकरार रखा जाता है, न कि शुद्ध स्ट्रिंग से फ्रेम को पुनः निर्मित किया जाता है।

निम्न उदाहरण एक वर्तनी रूपांतर को मानकीकृत करता है और फिर संस्करण लेबल बदलता है। वही कॉलबैक दोनों ऑपरेशनों द्वारा मिलाए गए मूल शब्दों को रिकॉर्ड करता है।

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

यदि एक मिलान विभिन्न फ़ॉर्मेट वाले भागों को कवर करता है, तो आउटपुट की जाँच करें ताकि यह सुनिश्चित हो सके कि प्रतिस्थापन टेक्स्ट पर किस फ़ॉर्मेट को लागू किया जाना चाहिए।

## **पूरे प्रस्तुति में टेक्स्ट को बदलें**

[IPresentation::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/replacetext/) और [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/replaceregex/) का उपयोग करके समान ऑपरेशनों को पूरे प्रस्तुति में लागू करें। यह टेम्पलेट सफाई, टर्मिनोलॉजी अपडेट और रिडैक्शन के लिए उपयोगी है।

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

## **रिपोर्टिंग के लिए मिलानों को समूहित करें**

चूंकि हर परिणाम अपने स्लाइड नंबर और टेक्स्ट फ्रेम को संग्रहीत करता है, एप्लिकेशन ऑडिट, रिपोर्टिंग या समीक्षा वर्कफ़्लो के लिए मिलानों को समूहित कर सकते हैं। नीचे दिया गया उदाहरण पहले स्लाइड द्वारा और फिर टेक्स्ट फ्रेम द्वारा एकत्रित परिणामों को समूहित करता है:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी प्रस्तुति के बजाय केवल एक टेक्स्ट बॉक्स को कैसे खोजूँ?**

आकार (shape) की टेक्स्ट फ्रेम प्राप्त करें और उस टेक्स्ट फ्रेम पर [ITextFrame::HighlightText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replacetext/), या [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replaceregex/) को कॉल करें। प्रस्तुति‑स्तर की विधियां सभी लागू टेक्स्ट फ्रेमों को प्रोसेस करती हैं।

**मैं पूर्ण शब्दों को सही कैपिटलाइज़ेशन के साथ कैसे मिलाऊँ?**

[ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) और [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) को `true` के साथ कॉल करें, और विकल्पों को शाब्दिक‑टेक्स्ट हाईलाइट या प्रतिस्थापन मेथड में पास करें। रेगुलर एक्सप्रेशन के लिए, शब्द सीमाएं और केस‑सेंसिटिविटी को स्वयं `System::Text::RegularExpressions::Regex` में परिभाषित करें।

**क्या खोज और प्रतिस्थापन में स्लाइड नोट्स का टेक्स्ट भी शामिल हो सकता है?**

हां। प्रस्तुति‑स्तर की शाब्दिक‑टेक्स्ट ऑपरेशन के दौरान [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/set_includenotes/) को `true` सेट करें। ऊपर दिखाया गया कॉलबैक नोट्स स्लाइड में मिले मैच को उसके पैरेंट स्लाइड नंबर में मैप करता है।

**मैं बिना प्रस्तुति को दोबारा स्कैन किए रिपोर्ट कैसे बनाऊँ?**

हाइलाइट या प्रतिस्थापन ऑपरेशन में एक [IFindResultCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifindresultcallback/) कार्यान्वयन पास करें। कॉलबैक ऑपरेशन चलते समय हर मैच प्राप्त करता है, जिससे एप्लिकेशन स्रोत टेक्स्ट, मिलान किया गया टेक्स्ट, स्थिति, टेक्स्ट फ्रेम और व्युत्पन्न स्लाइड नंबर को बाद में समूहित या निर्यात करने के लिए संग्रहीत कर सकता है।

**क्या टेक्स्ट को बदलने से उसका फ़ॉर्मेट बना रहता है?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replacetext/) और [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/replaceregex/) मौजूदा टेक्स्ट फ्रेम के भीतर मिलान किए गए टेक्स्ट को संशोधित करते हैं और आसपास के भागों का फ़ॉर्मेट बनाए रखते हैं। यदि एक मिलान विभिन्न फ़ॉर्मेट वाले भागों को कवर करता है, तो सुनिश्चित करने के लिये परिणाम का निरीक्षण करें कि प्रतिस्थापन वांछित शैली को अपनाता है।