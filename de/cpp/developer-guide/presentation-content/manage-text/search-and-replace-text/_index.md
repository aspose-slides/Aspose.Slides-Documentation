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
- Audit-Bericht
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Suchen, hervorheben und ersetzen Sie Text in PowerPoint-Präsentationen und sammeln dabei jede Übereinstimmung mit Aspose.Slides für C++."
---
## **Übersicht**

Aspose.Slides für C++ kann Text in einem einzelnen Textfeld oder über eine gesamte Präsentation hinweg suchen, hervorheben und ersetzen. Jede Operation kann außerdem eine Anwendung über jede Übereinstimmung mittels eines Ergebnis‑Callbacks informieren. Damit ist es möglich, eine Präsentation zu aktualisieren und gleichzeitig ein Prüfprotokoll zu erstellen, das den gefundenen Text, seinen Kontext, die Position, das Textfeld und die Foliennummer enthält.

Diese Funktionen sind nützlich für Überprüfungen, Schwärzungen, Terminologieprüfungen, Vorlagenbereinigung und automatisierte Reporting‑Workflows.

In den folgenden ersten Beispielen verwenden wir eine Datei mit dem Namen "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Sample text](sample_text.png)

## **Wählen Sie den Suchbereich**

Verwenden Sie Methoden von [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/), um eine Operation auf ein Textfeld zu beschränken. Verwenden Sie Methoden von [IPresentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/), um allen zutreffenden Text in der Präsentation zu verarbeiten.

| Operation | Ein Textfeld | Gesamte Präsentation |
|---|---|---|
| Literaltext hervorheben | [ITextFrame::HighlightText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/highlighttext/) |
| Übereinstimmungen von regulären Ausdrücken hervorheben | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/highlightregex/) |
| Literaltext ersetzen | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/replacetext/) |
| Übereinstimmungen von regulären Ausdrücken ersetzen | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Textabgleich konfigurieren**

Für Literaltext‑Operationen verwenden Sie [ITextSearchOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/), um den Abgleich zu steuern:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) beschränkt die Übereinstimmungen auf ganze Wörter.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) steuert, ob die Groß‑ und Kleinschreibung übereinstimmen muss.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_includenotes/) schließt Foliennotizen in die Präsentationsebene‑Suche, -Ersetzung und -Hervorhebung ein.

Reguläre‑Ausdruck‑Operationen verwenden ein `System::Text::RegularExpressions::Regex`, sodass Regeln wie Groß‑/Kleinschreibung und Wortgrenzen durch den Ausdruck und seine Optionen definiert werden.

## **Übereinstimmungsinformationen mit einem Callback sammeln**

Implementieren Sie [IFindResultCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifindresultcallback/), um für jede Übereinstimmung eine Benachrichtigung zu erhalten. Seine [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifindresultcallback/foundresult/)‑Methode liefert das zugehörige Textfeld, den Quelltext, den gefundenen Text und die Position der Übereinstimmung.

Der Callback erhält nicht direkt eine Foliennummer. Die nachstehende Implementierung leitet sie aus [ISlideComponent::get_Slide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecomponent/get_slide/) ab und behandelt zudem Text, der in Foliennotizen gefunden wird, über [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/inotesslide/get_parentslide/). Eine nullable Foliennummer ermöglicht es, dass dasselbe Ergebnis‑Modell Text zu anderen Folientypen zuzuordnen.

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

Für Ersetzungs‑Operationen enthält `FoundText` den ursprünglichen gefundenen Text, sodass der Callback exakt aufzeichnen kann, welche Begriffe ersetzt wurden.

## **Text hervorheben**

Verwenden Sie die [ITextFrame::HighlightText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlighttext/)‑Methode, um Literaltext‑Übereinstimmungen in einem Textfeld hervorzuheben. Übergeben Sie [ITextSearchOptions], um die Suche zu steuern, und einen Callback, um die Details der Übereinstimmungen zu sammeln.

Das untenstehende Code‑Beispiel hebt alle Vorkommen der Zeichen **"try"** hervor und anschließend nur das ganze Wort **"to"**. Beide Suchen melden ihre Treffer an denselben Callback.

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

Das Ergebnis:

![The highlighted text](highlighted_text.png)

## **Text mithilfe regulärer Ausdrücke hervorheben**

Die [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlightregex/)‑Methode hebt Text‑Übereinstimmungen hervor, die durch einen regulären Ausdruck in einem Textfeld gefunden wurden.

Das folgende Beispiel hebt alle Wörter mit sieben oder mehr Zeichen hervor und sammelt jede Übereinstimmung:

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Text über eine gesamte Präsentation hinweg hervorheben**

Verwenden Sie [IPresentation::HighlightText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/highlighttext/) und [IPresentation::HighlightRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/highlightregex/), um alle zutreffenden Textfelder in einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen Literalbegriff und alle E‑Mail‑Adressen hervor, wobei separate Ergebnis‑Sammlungen für die beiden Suchen geführt werden.

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

Verwenden Sie [ITextFrame::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replacetext/) für Literaltext und [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replaceregex/) für ersatzbasierte Muster. Diese Methoden aktualisieren den gefundenen Text innerhalb des bestehenden Textfelds, wodurch die umgebende Formatierung erhalten bleibt, anstatt das Textfeld aus einem reinen String neu zu erstellen.

Das folgende Beispiel vereinheitlicht eine Rechtschreibvariante und ersetzt anschließend Versionsbezeichnungen. Derselbe Callback zeichnet die ursprünglichen Begriffe auf, die von beiden Operationen gefunden wurden.

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

Falls eine Übereinstimmung über Textteile mit unterschiedlicher Formatierung hinweg reicht, prüfen Sie die Ausgabe, um zu bestätigen, welche Formatierung auf den Ersetzungstext angewendet werden soll.

## **Text über eine gesamte Präsentation hinweg ersetzen**

Verwenden Sie [IPresentation::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/replacetext/) und [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/replaceregex/), um dieselben Operationen über die gesamte Präsentation anzuwenden. Dies ist nützlich für Vorlagenbereinigung, Terminologie‑Updates und Schwärzungen.

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

## **Übereinstimmungen für Reporting gruppieren**

Da jedes Ergebnis seine Foliennummer und sein Textfeld speichert, können Anwendungen die Treffer für Audits, Berichte oder Review‑Workflows gruppieren. Das folgende Beispiel gruppiert die gesammelten Ergebnisse zuerst nach Folie und dann nach Textfeld:

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

**Wie kann ich nur ein Textfeld anstatt der gesamten Präsentation durchsuchen?**

Rufen Sie das Textfeld der Shape ab und verwenden Sie [ITextFrame::HighlightText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replacetext/) oder [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replaceregex/) für dieses Textfeld. Methoden auf Präsentationsebene verarbeiten alle zutreffenden Textfelder.

**Wie kann ich vollständige Wörter mit korrekter Groß‑ und Kleinschreibung abgleichen?**

Rufen Sie [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) und [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) mit `true` auf und übergeben Sie die Optionen an eine Literaltext‑Hervorhebungs‑ oder Ersetzungs‑Methode. Bei regulären Ausdrücken definieren Sie Wortgrenzen und Groß‑/Kleinschreibung im `System::Text::RegularExpressions::Regex` selbst.

**Können Suche und Ersetzung Text in Foliennotizen einschließen?**

Ja. Rufen Sie [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextsearchoptions/set_includenotes/) mit `true` auf, wenn Sie eine Literaltext‑Operation auf Präsentationsebene verwenden. Die oben gezeigte Callback‑Implementierung ordnet eine Übereinstimmung in einer Notizfolie ihrer übergeordneten Foliennummer zu.

**Wie kann ich einen Bericht erstellen, ohne die Präsentation ein zweites Mal zu scannen?**

Übergeben Sie eine [IFindResultCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifindresultcallback/)-Implementierung an die Hervorhebungs‑ oder Ersetzungs‑Operation. Der Callback erhält jede Übereinstimmung während der Ausführung, sodass die Anwendung Quelltext, gefundenen Text, Position, Textfeld und abgeleitete Foliennummer für spätere Gruppierung oder Export speichern kann.

**Erhält das Ersetzen von Text dessen Formatierung?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replacetext/) und [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/replaceregex/) ändern den gefundenen Text innerhalb des bestehenden Textfelds und behalten die umgebende Formatierung bei. Falls eine Übereinstimmung über Textteile mit unterschiedlicher Formatierung hinweg reicht, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung den gewünschten Stil verwendet.