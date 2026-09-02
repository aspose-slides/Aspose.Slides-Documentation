---
title: Suche und Ersetze Text in PowerPoint-Präsentationen in C++
linktitle: Suche und Ersetze Text
type: docs
weight: 55
url: /de/cpp/search-and-replace-text/
keywords:
- Text suchen
- Text hervorheben
- Text ersetzen
- regulärer Ausdruck
- Ergebnis-Callback
- Textfeld
- Prüfbericht
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Text in PowerPoint-Präsentationen suchen, hervorheben und ersetzen, wobei jeder Treffer mit Aspose.Slides für C++ gesammelt wird."
---
## **Übersicht**

Aspose.Slides für C++ kann Text in einem einzelnen Textfeld oder in einer gesamten Präsentation suchen, hervorheben und ersetzen. Jede Operation kann zudem über einen Ergebnis‑Callback die Anwendung über jedes gefundene Vorkommen informieren. Dadurch ist es möglich, eine Präsentation zu aktualisieren und gleichzeitig ein Prüfprotokoll zu erstellen, das den gefundenen Text, dessen Kontext, Position, Textfeld und Foliennummer enthält.

Diese Funktionen sind nützlich für Überprüfungen, Schwärzungen, Terminologie‑Kontrollen, Vorlagen‑Bereinigungen und automatisierte Bericht‑Workflows.

In den ersten Beispielen unten verwenden wir die Datei **„sample.pptx“**, die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Suchbereich auswählen**

Verwenden Sie Methoden von [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/), um eine Operation auf ein Textfeld zu beschränken. Verwenden Sie Methoden von [IPresentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/), um allen anwendbaren Text in der Präsentation zu verarbeiten.

| Operation | Ein Textfeld | Gesamte Präsentation |
|---|---|---|
| Literalen Text hervorheben | [ITextFrame::HighlightText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/highlighttext/) |
| Treffer von regulären Ausdrücken hervorheben | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/highlightregex/) |
| Literalen Text ersetzen | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/replacetext/) |
| Treffer von regulären Ausdrücken ersetzen | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Textabgleich konfigurieren**

Für Operationen mit literalem Text verwenden Sie [ITextSearchOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/), um den Abgleich zu steuern:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) beschränkt Treffer auf komplette Wörter.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) legt fest, ob die Groß‑/Kleinschreibung übereinstimmen muss.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_includenotes/) schließt Folien‑Notizen in Präsentations‑Suche‑, Ersetzungs‑ und Hervorhebungs‑Operationen ein.

Operationen mit regulären Ausdrücken verwenden ein `System::Text::RegularExpressions::Regex`, sodass Abgleich‑Regeln wie Groß‑/Kleinschreibung und Wortgrenzen durch den Ausdruck und seine Optionen definiert werden.

## **Den Eigentümer eines Textfeldes ermitteln**

Allgemeine Text‑Verarbeitungs‑Workflows erhalten häufig ein [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) beim Suchen, Ersetzen, Validieren oder Exportieren von Text. Verwenden Sie [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentshape/) und [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentcell/), um zu bestimmen, welches Präsentations‑Objekt das Textfeld besitzt.

Die erwarteten Werte hängen vom Eigentümer ab:

| Eigentümer des Textfeldes | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| Eine AutoShape oder ein anderes text‑enthaltendes Shape | Das zugehörige [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) | `nullptr` |
| Eine Tabellenzelle | `nullptr` | Das zugehörige [ICell](https://reference.aspose.com/slides/de/cpp/aspose.slides/icell/) |

Beide Methoden bieten nur Lese‑Navigation. Ihr Aufruf bewegt das Textfeld nicht und ändert keinen Eigentümer. Generischer Code sollte beide Werte auf `nullptr` prüfen und den Fall behandeln, dass keiner der Eigentümer verfügbar ist.

Das folgende Beispiel verwendet [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/slideutil/getalltextframes/), um alle Textfelder einer Präsentation zu durchlaufen. Für Shapes gibt es den Shape‑Namen, den C++‑Laufzeit‑Typ und die zugehörige Folie aus. Für Tabellenzellen werden die null‑basierten Spalten‑ und Zeilenkoordinaten sowie die zugehörige Folie ausgegeben.

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

Für SmartArt‑Inhalte iterieren Sie über die Shapes in [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) und greifen auf jedes [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) zu. Das Textfeld lässt sich über [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentshape/) zum zugehörigen Shape zurückverfolgen, während [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr` zurückgibt. Daher behandelt der Shape‑Zweig im Beispiel ebenfalls Text aus SmartArt‑Knoten.

## **Trefferinformationen mit einem Callback sammeln**

Implementieren Sie [IFindResultCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifindresultcallback/), um für jeden Treffer eine Benachrichtigung zu erhalten. Seine Methode [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifindresultcallback/foundresult/) liefert das zugehörige Textfeld, den Quelltext, den gefundenen Text und die Trefferposition.

Der Callback erhält keine Folien‑Nummer direkt. Die nachfolgende Implementierung leitet sie aus [ISlideComponent::get_Slide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecomponent/get_slide/) ab und behandelt zudem Text, der in Folien‑Notizen gefunden wurde, über [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/inotesslide/get_parentslide/). Eine nullable Folien‑Nummer ermöglicht es, dasselbe Ergebnis‑Modell auch für Text zu verwenden, der zu anderen Folientypen gehört.

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

Bei Ersetzungs‑Operationen enthält `FoundText` den ursprünglich gefundenen Text, sodass der Callback exakt festhalten kann, welche Begriffe ersetzt wurden.

## **Text hervorheben**

Verwenden Sie die Methode [ITextFrame::HighlightText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlighttext/), um literal‑Text‑Treffer in einem Textfeld hervorzuheben. Übergeben Sie [ITextSearchOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/), um die Suche zu steuern, und einen Callback, um Treffer‑Details zu sammeln.

Das nachstehende Codebeispiel hebt alle Vorkommen des Zeichens **„try“** hervor und markiert anschließend nur das komplette Wort **„to“**. Beide Suchen melden ihre Treffer an denselben Callback.

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

// Erhalte das erste Shape von der ersten Folie.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Hervorheben jedes Vorkommens von "try" im Textfeld.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Nur das komplette Wort "to" hervorheben.
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

Das Ergebnis:

![Der hervorgehobene Text](highlighted_text.png)

## **Text mit regulären Ausdrücken hervorheben**

Die Methode [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlightregex/) hebt Text‑Treffer hervor, die durch einen regulären Ausdruck in einem Textfeld gefunden wurden.

Der folgende Code hebt alle Wörter mit sieben oder mehr Zeichen hervor und sammelt jeden Treffer:

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

Das Ergebnis:

![Der hervorgehobene Text mit regulärem Ausdruck](highlighted_text_using_regex.png)

## **Text in der gesamten Präsentation hervorheben**

Verwenden Sie [IPresentation::HighlightText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/highlighttext/) und [IPresentation::HighlightRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/highlightregex/), um alle anwendbaren Textfelder einer Präsentation zu durchsuchen. Das nachfolgende Beispiel hebt einen literal‑Begriff und alle E‑Mail‑Adressen hervor, wobei für die beiden Suchen separate Ergebnis‑Sammlungen verwendet werden.

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

## **Text in einem Textfeld ersetzen**

Verwenden Sie [ITextFrame::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replacetext/) für literal‑Text und [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replaceregex/) für pattern‑basiertes Ersetzen. Diese Methoden aktualisieren den gefundenen Text innerhalb des bestehenden Textfeldes, sodass die umgebende Formatierung beibehalten wird, anstatt das Textfeld aus einem reinen String neu zu erstellen.

Das folgende Beispiel vereinheitlicht eine Rechtschreibvariante und ersetzt anschließend Versions‑Labels. Der gleiche Callback zeichnet die ursprünglichen Begriffe auf, die von beiden Operationen gefunden wurden.

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

Wenn ein Treffer über Textteile mit unterschiedlicher Formatierung erstreckt, prüfen Sie die Ausgabe, um sicherzustellen, welche Formatierung auf den ersetzten Text angewendet werden soll.

## **Text in der gesamten Präsentation ersetzen**

Verwenden Sie [IPresentation::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/replacetext/) und [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/replaceregex/), um dieselben Operationen über die gesamte Präsentation hinweg anzuwenden. Das ist nützlich für Vorlagen‑Bereinigung, Terminologie‑Updates und Schwärzungen.

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

## **Treffer für Berichte gruppieren**

Da jedes Ergebnis seine Folien‑Nummer und das Textfeld speichert, können Anwendungen Treffer für Prüf‑, Bericht‑ oder Review‑Workflows gruppieren. Das folgende Beispiel gruppiert die gesammelten Ergebnisse zuerst nach Folie und anschließend nach Textfeld:

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

**Wie kann ich nur ein Textfeld statt der gesamten Präsentation durchsuchen?**

Holen Sie sich das Textfeld des Shapes und rufen Sie [ITextFrame::HighlightText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replacetext/) oder [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replaceregex/) für dieses Textfeld auf. Methoden auf Präsentationsebene verarbeiten alle anwendbaren Textfelder.

**Wie kann ich komplette Wörter mit korrekter Groß‑/Kleinschreibung abgleichen?**

Rufen Sie [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) und [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) mit `true` auf und übergeben Sie die Optionen an eine literal‑Text‑Hervorhebungs‑ oder Ersetzungs‑Methode. Bei regulären Ausdrücken definieren Sie Wortgrenzen und Groß‑/Kleinschreibung im `System::Text::RegularExpressions::Regex` selbst.

**Können Suche und Ersetzung Text in Folien‑Notizen einbeziehen?**

Ja. Rufen Sie [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_includenotes/) mit `true` auf, wenn Sie eine literal‑Text‑Operation auf Präsentationsebene ausführen. Die oben gezeigte Callback‑Implementierung ordnet ein Treffer‑Ergebnis in einer Notiz‑Folien zurück zur übergeordneten Folien‑Nummer zu.

**Wie erstelle ich einen Bericht, ohne die Präsentation ein zweites Mal zu durchsuchen?**

Übergeben Sie eine [IFindResultCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifindresultcallback/)-Implementierung an die Hervorhebungs‑ oder Ersetzungs‑Operation. Der Callback erhält jeden Treffer während der Ausführung, sodass die Anwendung Quelltext, gefundenen Text, Position, Textfeld und abgeleitete Folien‑Nummer für spätere Gruppierung oder Export speichern kann.

**Behält das Ersetzen von Text dessen Formatierung bei?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replacetext/) und [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replaceregex/) ändern den gefundenen Text innerhalb des bestehenden Textfeldes und behalten die umgebende Formatierung bei. Wenn ein Treffer über Teile mit unterschiedlicher Formatierung reicht, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung die gewünschte Formatierung verwendet.