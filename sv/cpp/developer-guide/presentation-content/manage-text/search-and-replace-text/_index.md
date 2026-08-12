---
title: Sök och ersätt text i PowerPoint-presentationer i C++
linktitle: Sök och ersätt text
type: docs
weight: 55
url: /sv/cpp/search-and-replace-text/
keywords:
- sök text
- markera text
- ersätt text
- reguljärt uttryck
- resultat callback
- textruta
- revisionsrapport
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer samtidigt som du samlar varje matchning med Aspose.Slides för C++."
---
## **Översikt**

Aspose.Slides för C++ kan söka, markera och ersätta text i ett enskilt textrutor eller i hela en presentation. Varje operation kan också meddela en applikation om varje träff via ett resultat‑callback. Detta gör det möjligt att uppdatera en presentation och samtidigt bygga ett revisionsspår som innehåller den matchade texten, dess sammanhang, position, textruta och bildnummer.

Dessa funktioner är användbara för granskning, maskering, terminologikontroller, mallrensning och automatiserade rapporteringsarbetsflöden.

I de första exemplen nedan använder vi en fil som heter "sample.pptx", vilken innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Välj sökområde**

Använd metoder på [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) för att begränsa en operation till en textruta. Använd metoder på [IPresentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/) för att bearbeta all tillämplig text i presentationen.

| Operation | En textruta | Hela presentationen |
|---|---|---|
| Markera bokstavlig text | [ITextFrame::HighlightText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/highlighttext/) |
| Markera reguljära uttryck | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/highlightregex/) |
| Ersätt bokstavlig text | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/replacetext/) |
| Ersätt reguljära uttryck | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Konfigurera textmatchning**

För bokstavliga textoperationer, använd [ITextSearchOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/) för att styra matchning:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) begränsar matchningar till hela ord.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) styr om teckenstorlek måste matcha.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_includenotes/) inkluderar bildanteckningar i presentation‑nivå sök‑, ersättnings‑ och markeringsoperationer.

Reguljära‑uttrycks‑operationer använder en `System::Text::RegularExpressions::Regex`, så matchningsregler såsom skiftlägeskänslighet och ordgränser definieras av själva uttrycket och dess alternativ.

## **Samla matchningsinformation med ett callback**

Implementera [IFindResultCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifindresultcallback/) för att ta emot en notifikation för varje match. Dess [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifindresultcallback/foundresult/) metod tillhandahåller den relaterade textrutan, källtexten, den matchade texten och matchningspositionen.

Callback‑en får inte ett bildnummer direkt. Implementeringen nedan hämtar det från [ISlideComponent::get_Slide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecomponent/get_slide/) och hanterar även text som hittas i bildanteckningar via [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inotesslide/get_parentslide). Ett nullable bildnummer möjliggör att samma resultatsmodell kan representera text som är associerad med andra bildtyper.

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

För ersättningsoperationer innehåller `FoundText` den ursprungliga matchade texten, så callbacken kan registrera exakt vilka termer som ersattes.

## **Markera text**

Använd [ITextFrame::HighlightText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlighttext/) för att markera bokstavliga textmatchningar i en textruta. Skicka [ITextSearchOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/) för att styra sökningen och ett callback för att samla matchningsdetaljer.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast hela ordet **"to"**. Båda sökningarna rapporterar sina matchningar till samma callback.

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

// Hämta den första formen från den första bilden.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Markera varje förekomst av "try" i textrutan.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Markera endast hela ordet "to".
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

Resultatet:

![Den markerade texten](highlighted_text.png)

## **Markera text med reguljära uttryck**

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlightregex/)‑metoden markerar textmatchningar som hittas av ett reguljärt uttryck i en textruta.

Följande kod markerar alla ord som innehåller sju eller fler tecken och samlar varje matchning:

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

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Markera text i hela en presentation**

Använd [IPresentation::HighlightText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/highlighttext/) och [IPresentation::HighlightRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/highlightregex/) för att söka i alla tillämpliga textrutor i en presentation. Följande exempel markerar ett bokstavligt uttryck och alla e‑postadresser samtidigt som separata resultatkollektioner behålls för de två sökningarna.

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

## **Ersätt text i en textruta**

Använd [ITextFrame::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replacetext/) för bokstavlig text och [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replaceregex/) för mönsterbaserad ersättning. Dessa metoder uppdaterar den matchade texten i den befintliga textrutan, vilket behåller formateringen på de omgivande delarna istället för att återskapa textrutan från en ren sträng.

Följande exempel standardiserar en stavningsvariant och ersätter sedan versionsetiketter. Samma callback registrerar de ursprungliga termerna som matchades av båda operationerna.

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

Om en matchning sträcker sig över delar med olika formatering, granska resultatet för att bekräfta vilken formatering som ska tillämpas på den ersatta texten.

## **Ersätt text i hela en presentation**

Använd [IPresentation::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/replacetext/) och [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/replaceregex/) för att tillämpa samma operationer i hela presentationen. Detta är användbart för mallrensning, terminologiska uppdateringar och maskering.

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

## **Gruppera matchningar för rapportering**

Eftersom varje resultat lagrar sitt bildnummer och sin textruta kan applikationer gruppera matchningar för revision, rapportering eller granskningsarbetsflöden. Följande exempel grupperar de insamlade resultaten först efter bild och sedan efter textruta:

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

## **Vanliga frågor**

**Hur kan jag söka endast i en textruta istället för i hela presentationen?**

Få formens textruta och anropa [ITextFrame::HighlightText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replacetext/) eller [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replaceregex/) på den textrutan. Metoder på presentationsnivå bearbetar alla tillämpliga textrutor istället.

**Hur kan jag matcha hela ord med korrekt kapitalisering?**

Anropa [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) och [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) med `true`, och skicka alternativen till en bokstavlig markerings‑ eller ersättningsmetod. För reguljära uttryck, definiera ordgränser och skiftlägeskänslighet i själva `System::Text::RegularExpressions::Regex`.

**Kan sökning och ersättning inkludera text i bildanteckningar?**

Ja. Anropa [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_includenotes/) med `true` när du använder en presentations‑nivå operation för bokstavlig text. Callback‑implementeringen ovan mappar en matchning i en anteckningsbild tillbaka till dess föräldrabild.

**Hur kan jag skapa en rapport utan att skanna presentationen en andra gång?**

Skicka en [IFindResultCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifindresultcallback/)‑implementering till markerings‑ eller ersättningsoperationen. Callback‑en får varje matchning medan operationen körs, så applikationen kan lagra källtext, matchad text, position, textruta och härledd bildnummer för senare gruppering eller export.

**Behåller ersättning av text dess formatering?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replacetext/) och [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replaceregex/) modifierar den matchade texten i den befintliga textrutan och behåller formateringen på de omgivande delarna. Om en matchning sträcker sig över delar med olika formatering, inspektera resultatet för att säkerställa att ersättningen använder önskad stil.