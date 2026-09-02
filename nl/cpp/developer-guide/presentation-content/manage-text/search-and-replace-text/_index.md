---
title: Zoeken en vervangen van tekst in PowerPoint-presentaties in C++
linktitle: Zoeken en vervangen van tekst
type: docs
weight: 55
url: /nl/cpp/search-and-replace-text/
keywords:
- tekst zoeken
- tekst markeren
- tekst vervangen
- reguliere expressie
- resultaat callback
- tekstkader
- auditrapport
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Zoek, markeer en vervang tekst in PowerPoint-presentaties terwijl elke overeenkomst wordt verzameld met Aspose.Slides for C++."
---
## **Overzicht**

Aspose.Slides for C++ kan tekst zoeken, markeren en vervangen in een individueel tekstkader of in de volledige presentatie. Elke bewerking kan een applicatie ook op de hoogte stellen van elke overeenkomst via een result‑callback. Hierdoor is het mogelijk een presentatie bij te werken en tegelijkertijd een audit‑trail op te bouwen met de gevonden tekst, de context, positie, het tekstkader en het dia‑nummer.

Deze mogelijkheden zijn handig voor review, redactie, terminologiecontroles, sjabloonsopschoning en geautomatiseerde rapportage‑workflows.

In de eerste onderstaande voorbeelden gebruiken we een bestand genaamd “sample.pptx”, dat een enkele tekstvak op de eerste dia bevat met de volgende tekst:

![Sample text](sample_text.png)

## **Kies de zoekscope**

Gebruik methoden op [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) om een bewerking te beperken tot één tekstkader. Gebruik methoden op [IPresentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/) om alle toepasselijke tekst in de presentatie te verwerken.

| Bewerkning | Eén tekstkader | Hele presentatie |
|---|---|---|
| Letterlijke tekst markeren | [ITextFrame::HighlightText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/highlighttext/) |
| Reguliere‑expressie‑overeenkomsten markeren | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/highlightregex/) |
| Letterlijke tekst vervangen | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/replacetext/) |
| Reguliere‑expressie‑overeenkomsten vervangen | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Configureer tekstopmatching**

Voor bewerkingen met letterlijke tekst, gebruik [ITextSearchOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/) om het zoeken te regelen:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) beperkt overeenkomsten tot volledige woorden.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) bepaalt of hoofdlettergevoeligheid vereist is.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_includenotes/) neemt notities van dia’s op in zoek-, vervang‑ en markeerbewerkingen op presentatieniveau.

Bewerkingen met reguliere expressies gebruiken een `System::Text::RegularExpressions::Regex`, dus regels zoals hoofdlettergevoeligheid en woordgrenzen worden gedefinieerd door de expressie en haar opties.

## **Identificeer de eigenaar van een tekstkader**

Generieke tekstverwerkings‑workflows ontvangen vaak een [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) tijdens zoeken, vervangen, valideren of exporteren. Gebruik [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_parentshape/) en [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_parentcell/) om te bepalen welk presentatie‑object eigenaar is van het tekstkader.

De verwachte waarden hangen af van de eigenaar:

| Eigenaar van tekstkader | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| Een AutoShape of een andere vorm die tekst bevat | De eigenaar‑[IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) | `nullptr` |
| Een tabelcel | `nullptr` | De eigenaar‑[ICell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icell/) |

Beide methoden bieden alleen‑lezen navigatie. Ze verplaatsen het tekstkader of wijzigen de eigenaar niet. Generieke code dient beide waarden op `nullptr` te controleren en rekening te houden met de mogelijkheid dat geen van beide beschikbaar is.

Het volgende voorbeeld gebruikt [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/getalltextframes/) om door de tekstkaders in een presentatie te itereren. Voor vormen meldt het de vormnaam, C++‑runtime‑type en de bijbehorende dia. Voor tabelcellen meldt het de kolom‑ en rij‑coördinaten (nul‑gebaseerd) en de bijbehorende dia.

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

Voor SmartArt‑inhoud, iterateer door de vormen in [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) en benader elke [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). Het tekstkader kan via [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_parentshape/) naar de bijbehorende vorm worden getraceerd, terwijl [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr` retourneert. Daarom behandelt de vorm‑tak in het voorbeeld ook tekst uit SmartArt‑nodes.

## **Verzamel overeenkomsteninformatie met een callback**

Implementeer [IFindResultCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifindresultcallback/) om een melding te ontvangen voor elke overeenkomst. De methode [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifindresultcallback/foundresult/) levert het bijbehorende tekstkader, de brontekst, de gevonden tekst en de positie van de overeenkomst.

De callback ontvangt geen dia‑nummer rechtstreeks. De implementatie hieronder haalt dit af van [ISlideComponent::get_Slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecomponent/get_slide/) en verwerkt tevens tekst die gevonden is in notities via [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inotesslide/get_parentslide/). Een nullable dia‑nummer maakt het mogelijk om hetzelfde resultaatsmodel te gebruiken voor tekst geassocieerd met andere type dia’s.

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

Voor vervangingsbewerkingen bevat `FoundText` de oorspronkelijk gevonden tekst, zodat de callback exact kan registreren welke termen zijn vervangen.

## **Tekst markeren**

Gebruik de methode [ITextFrame::HighlightText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlighttext/) om letterlijke‑tekstoplossingen in een tekstkader te markeren. Geef [ITextSearchOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/) door om het zoeken te sturen en een callback om de details van de overeenkomsten te verzamelen.

Het code‑voorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en vervolgens alleen het volledige woord **"to"**. Beide zoekopdrachten rapporteren hun resultaten aan dezelfde callback.

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

// Haal de eerste vorm van de eerste dia op.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Markeer elk voorkomen van "try" in het tekstkader.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Markeer alleen het volledige woord "to".
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

Het resultaat:

![The highlighted text](highlighted_text.png)

## **Tekst markeren met reguliere expressies**

De methode [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlightregex/) markeert tekstovereenkomsten die door een reguliere expressie in een tekstkader worden gevonden.

De volgende code markeert alle woorden van zeven of meer tekens en verzamelt elke overeenkomst:

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

Het resultaat:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Tekst markeren in een hele presentatie**

Gebruik [IPresentation::HighlightText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/highlighttext/) en [IPresentation::HighlightRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/highlightregex/) om alle toepasselijke tekstkaders in een presentatie te doorzoeken. Het volgende voorbeeld markeert een letterlijke term en alle e‑mailadressen, terwijl er aparte resultaatsverzamelingen worden bijgehouden voor beide zoekopdrachten.

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

## **Tekst vervangen in een tekstkader**

Gebruik [ITextFrame::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replacetext/) voor letterlijke tekst en [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replaceregex/) voor patroon‑gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstkader, waardoor de opmaak van het omringende gedeelte behouden blijft in plaats van het tekstkader opnieuw op te bouwen vanuit een platte string.

Het volgende voorbeeld normaliseert een spellingvariant en vervangt vervolgens versielabels. Dezelfde callback registreert de oorspronkelijke termen die door beide bewerkingen zijn gevonden.

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

Als één overeenkomst delen met verschillende opmaak bestrijkt, controleer dan de uitvoer om te bevestigen welke opmaak op de vervangende tekst moet worden toegepast.

## **Tekst vervangen in een hele presentatie**

Gebruik [IPresentation::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/replacetext/) en [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/replaceregex/) om dezelfde bewerkingen op de volledige presentatie toe te passen. Dit is nuttig voor sjabloonsopschoning, terminologie‑updates en redactie.

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

## **Groeperen van overeenkomsten voor rapportage**

Omdat elk resultaat zijn dia‑nummer en tekstkader opslaat, kunnen applicaties overeenkomsten groeperen voor audit, rapportage of review‑workflows. Het volgende voorbeeld groepeert de verzamelde resultaten eerst per dia en vervolgens per tekstkader:

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

**Hoe kan ik slechts één tekstvak doorzoeken in plaats van de volledige presentatie?**

Haal het tekstkader van de vorm op en roep [ITextFrame::HighlightText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replacetext/) of [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replaceregex/) aan op dat tekstkader. Methoden op presentatieniveau verwerken alle toepasselijke tekstkaders.

**Hoe kan ik volledige woorden matchen met de juiste hoofdletters?**

Roep [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) en [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) aan met `true` en geef de opties door aan een markeer‑ of vervangingsmethode voor letterlijke tekst. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid in de `System::Text::RegularExpressions::Regex` zelf.

**Kunnen zoeken en vervangen tekst in notities van dia’s omvatten?**

Ja. Roep [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_includenotes/) aan met `true` bij een presentatieniveau‑bewerking voor letterlijke tekst. De callback‑implementatie hierboven mapt een overeenkomst in een notities‑dia terug naar het bijbehorende dia‑nummer.

**Hoe kan ik een rapport maken zonder de presentatie een tweede keer te scannen?**

Geef een implementatie van [IFindResultCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifindresultcallback/) door aan de markeer‑ of vervangingsbewerking. De callback ontvangt elke overeenkomst terwijl de bewerking draait, zodat de applicatie de brontekst, gevonden tekst, positie, tekstkader en afgeleide dia‑nummer kan opslaan voor latere groepering of export.

**Behoudt vervangen tekst zijn opmaak?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replacetext/) en [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replaceregex/) wijzigen de gevonden tekst binnen het bestaande tekstkader en behouden de opmaak van het omringende gedeelte. Als een overeenkomst delen met verschillende opmaak omvat, inspecteer dan het resultaat om zeker te zijn dat de vervanging de gewenste stijl gebruikt.