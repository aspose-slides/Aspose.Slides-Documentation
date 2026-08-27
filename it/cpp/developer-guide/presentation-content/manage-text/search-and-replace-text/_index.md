---
title: Ricerca e Sostituzione del Testo in Presentazioni PowerPoint in C++
linktitle: Ricerca e Sostituzione del Testo
type: docs
weight: 55
url: /it/cpp/search-and-replace-text/
keywords:
- ricerca testo
- evidenzia testo
- sostituisci testo
- espressione regolare
- callback risultato
- fotogramma di testo
- rapporto di audit
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Cerca, evidenzia e sostituisci il testo nelle presentazioni PowerPoint raccogliendo ogni corrispondenza con Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides per C++ può cercare, evidenziare e sostituire testo in un singolo fotogramma di testo o in un’intera presentazione. Ogni operazione può anche notificare l’applicazione per ogni corrispondenza tramite un callback di risultato. Questo rende possibile aggiornare una presentazione e allo stesso tempo creare una traccia di audit contenente il testo corrispondente, il contesto, la posizione, il fotogramma di testo e il numero della diapositiva.

Queste funzionalità sono utili per revisioni, redazioni, controlli di terminologia, pulizia di modelli e flussi di lavoro di reportistica automatizzata.

Nei primi esempi seguenti, usiamo un file chiamato “sample.pptx”, che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Testo di esempio](sample_text.png)

## **Scegliere l’Ambito della Ricerca**

Usa i metodi di [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) per limitare un’operazione a un fotogramma di testo. Usa i metodi di [IPresentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/) per elaborare tutto il testo applicabile nella presentazione.

| Operazione | Un fotogramma di testo | Intera presentazione |
|---|---|---|
| Evidenziare testo letterale | [ITextFrame::HighlightText](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/highlighttext/) |
| Evidenziare corrispondenze con espressione regolare | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/highlightregex/) |
| Sostituire testo letterale | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/replacetext/) |
| Sostituire corrispondenze con espressione regolare | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Configurare la Corrispondenza del Testo**

Per le operazioni su testo letterale, usa [ITextSearchOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextsearchoptions/) per controllare la corrispondenza:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) limita le corrispondenze a parole complete.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) controlla se il caso dei caratteri deve corrispondere.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextsearchoptions/set_includenotes/) include le note della diapositiva nelle operazioni di ricerca, sostituzione ed evidenziazione a livello di presentazione.

Le operazioni con espressioni regolari utilizzano un `System::Text::RegularExpressions::Regex`, quindi regole come la sensibilità al caso e i confini di parola sono definiti dall’espressione e dalle sue opzioni.

## **Identificare il Proprietario di un Fotogramma di Testo**

I flussi di lavoro generici di elaborazione del testo ricevono spesso un [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) durante la ricerca, la sostituzione, la convalida o l’esportazione del testo. Usa [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_parentshape/) e [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_parentcell/) per determinare quale oggetto della presentazione possiede il fotogramma di testo.

I valori attesi dipendono dal proprietario:

| Proprietario del fotogramma di testo | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| Un’AutoShape o un’altra forma contenente testo | La [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) proprietaria | `nullptr` |
| Una cella di tabella | `nullptr` | La [ICell](https://reference.aspose.com/slides/it/cpp/aspose.slides/icell/) proprietaria |

Entrambi i metodi forniscono una navigazione in sola lettura. Chiamarli non sposta il fotogramma di testo né ne modifica il proprietario. Il codice generico dovrebbe verificare entrambi i valori per `nullptr` e gestire la possibilità che nessuno dei due proprietari sia disponibile.

L’esempio seguente usa [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/slideutil/getalltextframes/) per iterare sui fotogrammi di testo in una presentazione. Per le forme, stampa il nome della forma, il tipo runtime C++ e la diapositiva contenente. Per le celle di tabella, stampa le coordinate colonna‑riga (basate su zero) e la diapositiva contenente.

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

Per i contenuti SmartArt, itera sulle forme in [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) e accedi a ciascuna [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). Il fotogramma di testo può essere tracciato alla forma associata tramite [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_parentshape/), mentre [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_parentcell/) restituisce `nullptr`. Pertanto, il ramo della forma nell’esempio gestisce anche il testo proveniente da nodi SmartArt.

## **Raccogliere le Informazioni sulla Corrispondenza con un Callback**

Implementa [IFindResultCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifindresultcallback/) per ricevere una notifica per ogni corrispondenza. Il suo metodo [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifindresultcallback/foundresult/) fornisce il fotogramma di testo correlato, il testo sorgente, il testo corrispondente e la posizione della corrispondenza.

Il callback non riceve direttamente il numero della diapositiva. L’implementazione sotto lo ricava da [ISlideComponent::get_Slide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecomponent/get_slide/) e gestisce anche il testo trovato nelle note della diapositiva tramite [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/inotesslide/get_parentslide/). Un numero di diapositiva nullable consente al medesimo modello di risultato di rappresentare testo associato ad altri tipi di diapositive.

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

Per le operazioni di sostituzione, `FoundText` contiene il testo originale corrispondente, così il callback può registrare esattamente quali termini sono stati sostituiti.

## **Evidenziare il Testo**

Usa il metodo [ITextFrame::HighlightText](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/highlighttext/) per evidenziare le corrispondenze di testo letterale in un fotogramma di testo. Passa [ITextSearchOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextsearchoptions/) per controllare la ricerca e un callback per raccogliere i dettagli della corrispondenza.

L’esempio di codice sotto evidenzia tutte le occorrenze della sequenza **"try"** e poi evidenzia solo la parola intera **"to"**. Entrambe le ricerche segnalano le corrispondenze allo stesso callback.

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

// Ottieni la prima forma dalla prima diapositiva.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Evidenzia ogni occorrenza di "try" nel fotogramma di testo.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Evidenzia solo la parola intera "to".
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

Il risultato:

![Il testo evidenziato](highlighted_text.png)

## **Evidenziare il Testo con Espressioni Regolari**

Il metodo [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/highlightregex/) evidenzia le corrispondenze trovate da un’espressione regolare in un fotogramma di testo.

Il codice seguente evidenzia tutte le parole contenenti sette o più caratteri e raccoglie ogni corrispondenza:

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

Il risultato:

![Il testo evidenziato usando l’espressione regolare](highlighted_text_using_regex.png)

## **Evidenziare il Testo in un’Intera Presentazione**

Usa [IPresentation::HighlightText](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/highlighttext/) e [IPresentation::HighlightRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/highlightregex/) per cercare tutti i fotogrammi di testo applicabili in una presentazione. L’esempio seguente evidenzia un termine letterale e tutti gli indirizzi email mantenendo collezioni di risultati separate per le due ricerche.

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

## **Sostituire il Testo in un Fotogramma di Testo**

Usa [ITextFrame::ReplaceText](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/replacetext/) per testo letterale e [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/replaceregex/) per sostituzioni basate su pattern. Questi metodi aggiornano il testo corrispondente all’interno del fotogramma di testo esistente, mantenendo la formattazione della porzione circostante invece di ricostruire il fotogramma da una stringa semplice.

L’esempio seguente standardizza una variante ortografica e poi sostituisce le etichette di versione. Lo stesso callback registra i termini originali corrispondenti a entrambe le operazioni.

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

Se una corrispondenza attraversa porzioni con formattazione diversa, verifica l’output per confermare quale formattazione applicare al testo sostituito.

## **Sostituire il Testo in un’Intera Presentazione**

Usa [IPresentation::ReplaceText](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/replacetext/) e [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/replaceregex/) per applicare le stesse operazioni a tutta la presentazione. Questo è utile per la pulizia di modelli, aggiornamenti di terminologia e redazioni.

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

## **Raggruppare le Corrispondenze per la Reportistica**

Poiché ogni risultato conserva il numero della diapositiva e il fotogramma di testo, le applicazioni possono raggruppare le corrispondenze per audit, reportistica o flussi di lavoro di revisione. L’esempio seguente raggruppa i risultati raccolti prima per diapositiva e poi per fotogramma di testo:

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

**Come posso cercare solo una casella di testo invece dell’intera presentazione?**

Ottieni il fotogramma di testo della forma e chiama [ITextFrame::HighlightText](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/replacetext/) o [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/replaceregex/) su quel fotogramma di testo. I metodi a livello di presentazione elaborano tutti i fotogrammi di testo applicabili.

**Come posso corrispondere parole intere con la corretta capitalizzazione?**

Chiama [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) e [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) con `true`, e passa le opzioni a un metodo di evidenziazione o sostituzione di testo letterale. Per le espressioni regolari, definisci i confini di parola e la sensibilità al caso direttamente nel `System::Text::RegularExpressions::Regex`.

**La ricerca e la sostituzione possono includere il testo nelle note delle diapositive?**

Sì. Chiama [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextsearchoptions/set_includenotes/) con `true` quando usi un’operazione di testo letterale a livello di presentazione. L’implementazione del callback mostrata sopra mappa una corrispondenza in una diapositiva di note al numero della diapositiva padre.

**Come posso creare un report senza scansionare nuovamente la presentazione?**

Passa un’implementazione di [IFindResultCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifindresultcallback/) all’operazione di evidenziazione o sostituzione. Il callback riceve ogni corrispondenza durante l’esecuzione dell’operazione, così l’applicazione può memorizzare il testo sorgente, il testo corrispondente, la posizione, il fotogramma di testo e il numero di diapositiva derivato per successivi raggruppamenti o esportazioni.

**La sostituzione del testo preserva la sua formattazione?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/replacetext/) e [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/replaceregex/) modificano il testo corrispondente all’interno del fotogramma di testo esistente e conservano la formattazione della porzione circostante. Se una corrispondenza attraversa porzioni con formattazione diversa, verifica il risultato per assicurarti che la sostituzione utilizzi lo stile desiderato.