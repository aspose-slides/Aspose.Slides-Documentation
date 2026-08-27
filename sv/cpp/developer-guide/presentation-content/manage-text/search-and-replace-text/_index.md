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
- textram
- revisionsrapport
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer samtidigt som varje match samlas in med Aspose.Slides för C++."
---
## **Översikt**

Aspose.Slides för C++ kan söka, markera och ersätta text i ett enskilt textram eller i hela presentationen. Varje operation kan också meddela en applikation om varje träff via ett resultat‑callback. Detta möjliggör att uppdatera en presentation och samtidigt bygga ett revisionsspår som innehåller den matchade texten, dess kontext, position, textram och bildnummer.

Dessa möjligheter är användbara för granskning, redigering, terminologikontroller, mallstädning och automatiserade rapporteringsarbetsflöden.

I de första exemplen nedan använder vi filen **"sample.pptx"**, som innehåller en enda textruta på den första bilden med följande text:

![Sample text](sample_text.png)

## **Välj söksområde**

Använd metoder på [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) för att begränsa en operation till ett textram. Använd metoder på [IPresentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/) för att bearbeta all tillämplig text i presentationen.

| Operation | Ett textram | Hela presentationen |
|---|---|---|
| Markera exakt text | [ITextFrame::HighlightText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/highlighttext/) |
| Markera reguljära‑uttrycks‑matchningar | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/highlightregex/) |
| Ersätt exakt text | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/replacetext/) |
| Ersätt reguljära‑uttrycks‑matchningar | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Konfigurera textmatchning**

För exakta‑text‑operationer, använd [ITextSearchOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/) för att styra matchning:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) begränsar matchningar till hela ord.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) styr om teckenkänslighet måste matchas.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_includenotes/) inkluderar bildanteckningar i sök‑, ersättnings‑ och markeringsoperationer på presentationsnivå.

Reguljära‑uttrycks‑operationer använder en `System::Text::RegularExpressions::Regex`, så regler som teckenkänslighet och ordgränser definieras av själva uttrycket och dess alternativ.

## **Identifiera ägaren till ett textram**

Generiska textbehandlingsarbetsflöden får ofta ett [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) medan de söker, ersätter, validerar eller exporterar text. Använd [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/get_parentshape/) och [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/get_parentcell/) för att avgöra vilket presentationsobjekt som äger textramen.

De förväntade värdena beror på ägaren:

| Ägare av textram | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| En AutoShape eller en annan text‑innehållande form | Den ägande [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/) | `nullptr` |
| En tabellcell | `nullptr` | Den ägande [ICell](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icell/) |

Båda metoderna ger skrivskyddad navigation. Att anropa dem flyttar inte textramen eller ändrar dess ägare. Generisk kod bör kontrollera båda värdena för `nullptr` och hantera möjligheten att ingen ägare finns.

Följande exempel använder [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/sv/cpp/aspose.slides.util/slideutil/getalltextframes/) för att iterera genom textramarna i en presentation. För former rapporterar det formens namn, C++‑körtidstyp och innehållande bild. För tabellceller rapporterar det nollbaserade kolumn‑ och radkoordinater samt den innehållande bilden.

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

För SmartArt‑innehåll, iterera genom formerna i [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) och nå varje [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). Textramen kan spåras till sin associerade form via [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/get_parentshape/), medan [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/get_parentcell/) returnerar `nullptr`. Därför hanterar formgrenen i exemplet även text från SmartArt‑noder.

## **Samla matchningsinformation med ett callback**

Implementera [IFindResultCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifindresultcallback/) för att ta emot en notifikation för varje match. Dess [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifindresultcallback/foundresult/)‑metod tillhandahåller den relaterade textramen, källtexten, den matchade texten och matchningspositionen.

Callback‑en får inte ett bildnummer direkt. Implementeringen nedan härleder det från [ISlideComponent::get_Slide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecomponent/get_slide/) och hanterar även text som hittas i bildanteckningar via [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inotesslide/get_parentslide/). Ett nullable bildnummer tillåter att samma resultatmodell representerar text kopplad till andra bildtyper.

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

För ersättningsoperationer innehåller `FoundText` den ursprungliga matchade texten, så callback‑en kan registrera exakt vilka termer som ersattes.

## **Markera text**

Använd metoden [ITextFrame::HighlightText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlighttext/) för att markera exakta‑text‑matchningar i ett textram. Skicka in [ITextSearchOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/) för att styra sökningen och ett callback för att samla matchningsdetaljer.

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

// Markera varje förekomst av "try" i textramen.
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

![The highlighted text](highlighted_text.png)

## **Markera text med reguljära uttryck**

Metoden [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlightregex/) markerar texter som hittas av ett reguljärt uttryck i ett textram.

Följande kod markerar alla ord som innehåller sju eller fler tecken och samlar varje match:

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Markera text i hela presentationen**

Använd [IPresentation::HighlightText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/highlighttext/) och [IPresentation::HighlightRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/highlightregex/) för att söka i alla tillämpliga textramar i en presentation. Följande exempel markerar ett exakt begrepp och alla e‑postadresser samtidigt som resultatsamlingarna hålls separata för de två sökningarna.

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

## **Ersätta text i ett textram**

Använd [ITextFrame::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replacetext/) för exakt text och [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replaceregex/) för mönsterbaserad ersättning. Dessa metoder uppdaterar den matchade texten inom det befintliga textramet, vilket bevarar formateringen av omgivande delar istället för att bygga om textramet från en ren sträng.

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

Om en matchning spänner över delar med olika formatering, granska utdata för att bekräfta vilken formatering som ska tillämpas på den ersatta texten.

## **Ersätta text i hela presentationen**

Använd [IPresentation::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/replacetext/) och [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/replaceregex/) för att tillämpa samma operationer på hela presentationen. Detta är användbart för mallstädning, terminologiuppdateringar och redigering.

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

Eftersom varje resultat lagrar sitt bildnummer och textram kan applikationer gruppera matchningar för revisions‑, rapporterings‑ eller granskningsarbetsflöden. Följande exempel grupperar de insamlade resultaten först efter bild och sedan efter textram:

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

**Hur kan jag söka bara i en textruta istället för i hela presentationen?**

Hämta formens textram och anropa [ITextFrame::HighlightText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replacetext/) eller [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replaceregex/) på den textramen. Metoder på presentationsnivå behandlar alla tillämpliga textramar istället.

**Hur kan jag matcha hela ord med korrekt versalisering?**

Anropa [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) och [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) med `true`, och skicka alternativen till en exakt‑text‑markerings‑ eller ersättningsmetod. För reguljära uttryck definiera ordgränser och teckenkänslighet i själva `System::Text::RegularExpressions::Regex`.

**Kan sökning och ersättning inkludera text i bildanteckningar?**

Ja. Anropa [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/set_includenotes/) med `true` när du använder en exakt‑text‑operation på presentationsnivå. Callback‑implementeringen ovan mappar en matchning i en anteckningsbild tillbaka till dess föräldrabilddnummer.

**Hur kan jag skapa en rapport utan att skanna presentationen en andra gång?**

Skicka en [IFindResultCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifindresultcallback/)‑implementation till markerings‑ eller ersättningsoperationen. Callback‑en får varje matchning medan operationen körs, så applikationen kan lagra källtext, matchad text, position, textram och härlett bildnummer för senare gruppering eller export.

**Bevarar ersättning av text dess formatering?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replacetext/) och [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/replaceregex/) modifierar den matchade texten inom det befintliga textramet och behåller formateringen på omgivande delar. Om en matchning spänner över segment med olika formatering, inspektera resultatet för att säkerställa att ersättningen använder önskad stil.