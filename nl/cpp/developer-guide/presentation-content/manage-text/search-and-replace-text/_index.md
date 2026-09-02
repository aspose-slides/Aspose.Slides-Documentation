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
- resultaat-callback
- tekstframe
- auditrapport
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Zoek, markeer en vervang tekst in PowerPoint-presentaties terwijl u elke overeenkomst verzamelt met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides for C++ kan tekst zoeken, markeren en vervangen in een enkel tekstframe of in de volledige presentatie. Elke bewerking kan bovendien een applicatie informeren over elke overeenkomst via een result‑callback. Hierdoor kan een presentatie worden bijgewerkt terwijl tegelijk een audit‑trail wordt opgebouwd met de gevonden tekst, context, positie, tekstframe en slide‑nummer.

Deze mogelijkheden zijn handig voor review, redactie, terminologiecontroles, sjabloon‑opschoning en geautomatiseerde rapportage‑workflows.

In de eerste voorbeelden hieronder gebruiken we een bestand genaamd “sample.pptx”, dat op de eerste dia één tekstvak bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Kies de zoekscope**

Gebruik methoden op [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) om een bewerking te beperken tot één tekstframe. Gebruik methoden op [IPresentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/) om alle toepasselijke tekst in de presentatie te verwerken.

| Bewerking | Eén tekstframe | Hele presentatie |
|---|---|---|
| Letterlijke tekst markeren | [ITextFrame::HighlightText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/highlighttext/) |
| Reguliere‑expressie‑overeenkomsten markeren | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/highlightregex/) |
| Letterlijke tekst vervangen | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/replacetext/) |
| Reguliere‑expressie‑overeenkomsten vervangen | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Configureren van tekstreeks**

Voor letterlijke‑tekst bewerkingen, gebruik [ITextSearchOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/) om het zoeken te sturen:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) beperkt overeenkomsten tot volledige woorden.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) bepaalt of hoofdlettergevoeligheid vereist is.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_includenotes/) neemt notities op in zoeken, vervangen en markeren op presentatieniveau.

Reguliere‑expressie bewerkingen gebruiken een `System::Text::RegularExpressions::Regex`, zodat regels zoals hoofdlettergevoeligheid en woordgrenzen worden bepaald door de expressie en zijn opties.

## **Verzamel overeenkomende informatie met een callback**

Implementeer [IFindResultCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifindresultcallback/) om een melding te ontvangen voor elke overeenkomst. De methode [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifindresultcallback/foundresult/) levert het bijbehorende tekstframe, de brontekst, de gevonden tekst en de positie van de overeenkomst.

De callback ontvangt geen slide‑nummer direct. De implementatie hieronder haalt dit af van [ISlideComponent::get_Slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecomponent/get_slide/) en verwerkt ook tekst gevonden in notities via [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inotesslide/get_parentslide/). Een nullable slide‑nummer maakt het mogelijk om hetzelfde resultaatmodel te gebruiken voor tekst die aan andere slide‑types is gekoppeld.

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

Voor vervangingsbewerkingen bevat `FoundText` de originele gevonden tekst, zodat de callback exact kan registreren welke termen werden vervangen.

## **Tekst markeren**

Gebruik de methode [ITextFrame::HighlightText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlighttext/) om letterlijke‑tekst overeenkomsten in een tekstframe te markeren. Geef [ITextSearchOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/) door om het zoeken te sturen en een callback om de details van elke overeenkomst te verzamelen.

De code‑voorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en daarna alleen het volledige woord **"to"**. Beide zoekacties rapporteren hun resultaten aan dezelfde callback.

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

Het resultaat:

![De gemarkeerde tekst](highlighted_text.png)

## **Tekst markeren met reguliere expressies**

De methode [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlightregex/) markeert tekstovereenkomsten die worden gevonden door een reguliere expressie in een tekstframe.

De volgende code markeert alle woorden met zeven of meer tekens en verzamelt elke overeenkomst:

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

![De gemarkeerde tekst met de reguliere expressie](highlighted_text_using_regex.png)

## **Tekst markeren in een presentatie**

Gebruik [IPresentation::HighlightText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/highlighttext/) en [IPresentation::HighlightRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/highlightregex/) om alle toepasselijke tekstframes in een presentatie te doorzoeken. Het volgende voorbeeld markeert een letterlijke term en alle e‑mailadressen, met afzonderlijke resultaatsverzamelingen voor de twee zoekacties.

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

## **Tekst vervangen in een tekstframe**

Gebruik [ITextFrame::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replacetext/) voor letterlijke tekst en [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replaceregex/) voor patroon‑gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstframe, waardoor de opmaak van de omringende delen behouden blijft in plaats van het tekstframe opnieuw op te bouwen vanuit een onopgemaakte tekenreeks.

Het volgende voorbeeld normaliseert een spellingvariant en vervangt daarna versielabels. Dezelfde callback registreert de originele termen die door beide bewerkingen zijn gevonden.

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

Als een overeenkomst zich uitstrekt over delen met verschillende opmaak, controleer dan de uitvoer om te bevestigen welke opmaak moet worden toegepast op de vervangende tekst.

## **Tekst vervangen in een presentatie**

Gebruik [IPresentation::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/replacetext/) en [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/replaceregex/) om dezelfde bewerkingen over de volledige presentatie uit te voeren. Dit is nuttig voor sjabloon‑opschoning, terminologie‑updates en redactie.

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

## **Groepeer overeenkomsten voor rapportage**

Omdat elk resultaat zijn slide‑nummer en tekstframe opslaat, kunnen applicaties overeenkomsten groeperen voor audit, rapportage of review‑workflows. Het volgende voorbeeld groepeert de verzamelde resultaten eerst per slide en vervolgens per tekstframe:

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

**Hoe kan ik zoeken in slechts één tekstvak in plaats van de hele presentatie?**

Haal het tekstframe van de vorm op en roep [ITextFrame::HighlightText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replacetext/) of [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replaceregex/) aan op dat tekstframe. Methoden op presentatieniveau verwerken alle toepasselijke tekstframes.

**Hoe kan ik volledige woorden vinden met de juiste hoofdlettergebruik?**

Roep [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) en [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) aan met `true` en geef de opties door aan een letterlijke‑tekst markeer‑ of vervangingsmethode. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid direct in de `System::Text::RegularExpressions::Regex`.

**Kunnen zoeken en vervangen ook tekst in notities omvatten?**

Ja. Roep [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/set_includenotes/) aan met `true` wanneer je een letterlijke‑tekst bewerking op presentatieniveau uitvoert. De callback‑implementatie hierboven mappt een overeenkomst in een notitieslide terug naar het bijbehorende slide‑nummer.

**Hoe kan ik een rapport maken zonder de presentatie nogmaals te scannen?**

Geef een [IFindResultCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifindresultcallback/)‑implementatie door aan de markeer‑ of vervangingsbewerking. De callback ontvangt elke overeenkomst terwijl de bewerking loopt, zodat de applicatie de brontekst, gevonden tekst, positie, tekstframe en afgeleide slide‑nummer kan opslaan voor later groeperen of exporteren.

**Behoudt het vervangen van tekst de opmaak?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replacetext/) en [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/replaceregex/) wijzigen de gevonden tekst binnen het bestaande tekstframe en behouden de opmaak van de omliggende delen. Als een overeenkomst zich uitstrekt over delen met verschillende opmaak, inspecteer dan het resultaat om te verzekeren dat de vervanging de gewenste stijl gebruikt.