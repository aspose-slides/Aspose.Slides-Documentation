---
title: Suche und Ersetzen von Text in PowerPoint‑Präsentationen in .NET
linktitle: Suche und Ersetzen von Text
type: docs
weight: 55
url: /de/net/search-and-replace-text/
keywords:
- Textsuche
- Text hervorheben
- Text ersetzen
- Regulärer Ausdruck
- Ergebnis-Callback
- Textfeld
- Audit‑Bericht
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Suchen, Hervorheben und Ersetzen von Text in PowerPoint‑Präsentationen, während jeder Treffer mit Aspose.Slides für .NET gesammelt wird."
---
## **Übersicht**

Aspose.Slides for .NET kann Text in einem einzelnen Textfeld oder in der gesamten Präsentation suchen, hervorheben und ersetzen. Jeder Vorgang kann außerdem eine Anwendung über jeden Treffer mittels eines Ergebnis‑Callbacks benachrichtigen. Dadurch ist es möglich, eine Präsentation zu aktualisieren und gleichzeitig ein Prüfprotokoll zu erstellen, das den gefundenen Text, dessen Kontext, Position, Textfeld und Foliennummer enthält.

Diese Funktionen sind nützlich für Überprüfungen, Schwärzungen, Terminologie‑Prüfungen, Vorlagen‑Bereinigung und automatisierte Bericht‑Workflows.

In den ersten nachfolgenden Beispielen verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit dem folgenden Text enthält:

![Beispieltext](sample_text.png)

## **Suchbereich wählen**

Verwenden Sie Methoden auf [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/), um einen Vorgang auf ein Textfeld zu beschränken. Verwenden Sie Methoden auf [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/), um den gesamten anwendbaren Text in der Präsentation zu verarbeiten.

| Vorgang | Ein Textfeld | Gesamte Präsentation |
|---|---|---|
| [ITextFrame.HighlightText](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/highlighttext/) |
| [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/highlightregex/) |
| [ITextFrame.ReplaceText](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/replacetext/) |
| [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/replaceregex/) |

## **Textabgleich konfigurieren**

Für Vorgänge mit literalem Text verwenden Sie [TextSearchOptions](https://reference.aspose.com/slides/de/net/aspose.slides/textsearchoptions/), um das Matching zu steuern:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/de/net/aspose.slides/textsearchoptions/wholewordsonly/) beschränkt Treffer auf vollständige Wörter.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/de/net/aspose.slides/textsearchoptions/casesensitive/) steuert, ob die Groß‑ und Kleinschreibung übereinstimmen muss.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/de/net/aspose.slides/textsearchoptions/includenotes/) bezieht Foliennotizen in Such‑, Ersetz‑ und Hervorhebungs‑Vorgänge auf Präsentationsebene ein.

Vorgänge mit regulären Ausdrücken verwenden ein .NET‑`Regex`, sodass Regeln wie Groß‑/Kleinschreibung und Wortgrenzen durch den Ausdruck und seine Optionen festgelegt werden.

## **Trefferinformationen mit einem Callback sammeln**

Implementieren Sie [IFindResultCallback](https://reference.aspose.com/slides/de/net/aspose.slides/ifindresultcallback/), um für jeden Treffer eine Benachrichtigung zu erhalten. Seine Methode [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/de/net/aspose.slides/ifindresultcallback/foundresult/) liefert das zugehörige Textfeld, den Quelltext, den gefundenen Text und die Trefferposition.

Der Callback erhält nicht direkt eine Foliennummer. Die nachstehende Implementierung leitet sie aus der übergeordneten Folie ab und verarbeitet zudem Text, der in Foliennotizen gefunden wird. Eine nullable Foliennummer ermöglicht es dem gleichen Ergebnis‑Modell, Text zu repräsentieren, der anderen Folientypen zugeordnet ist.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

Bei Ersetz‑Vorgängen enthält `FoundText` den ursprünglichen gefundenen Text, sodass der Callback exakt festhalten kann, welche Begriffe ersetzt wurden.

## **Text hervorheben**

Verwenden Sie die Methode [ITextFrame.HighlightText](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/highlighttext/), um literal‑Text‑Treffer in einem Textfeld hervorzuheben. Übergeben Sie [TextSearchOptions](https://reference.aspose.com/slides/de/net/aspose.slides/textsearchoptions/) , um die Suche zu steuern, und einen Callback, um Trefferdetails zu sammeln.

Das folgende Codebeispiel hebt alle Vorkommen der Zeichen **"try"** hervor und anschließend nur das komplette Wort **"to"**. Beide Suchen melden ihre Treffer an denselben Callback.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Hole das erste Shape von der ersten Folie.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Hebe jedes Vorkommen von "try" im Textfeld hervor.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Hebe nur das vollständige Wort "to" hervor.
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

![Der hervorgehobene Text](highlighted_text.png)

## **Text mit regulären Ausdrücken hervorheben**

Die Methode [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/highlightregex/) hebt Text‑Treffer hervor, die durch einen regulären Ausdruck in einem Textfeld gefunden wurden.

Der folgende Code hebt alle Wörter mit sieben oder mehr Zeichen hervor und sammelt jeden Treffer:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

![Der hervorgehobene Text mit dem regulären Ausdruck](highlighted_text_using_regex.png)

## **Text in einer gesamten Präsentation hervorheben**

Verwenden Sie [Presentation.HighlightText](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/highlighttext/) und [Presentation.HighlightRegex](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/highlightregex/), um alle anwendbaren Textfelder in einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen literal‑Begriff und alle E‑Mail‑Adressen hervor, wobei separate Ergebnis‑Sammlungen für die beiden Suchen beibehalten werden.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **Text in einem Textfeld ersetzen**

Verwenden Sie [ITextFrame.ReplaceText](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/replacetext/) für literalen Text und [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/replaceregex/) für ersatzbasierte Muster. Diese Methoden aktualisieren den gefundenen Text im bestehenden Textfeld, wobei die umgebende Formatierung erhalten bleibt, anstatt das Textfeld aus einem einfachen String neu zu erstellen.

Das folgende Beispiel standardisiert eine Schreibvariante und ersetzt anschließend Versionsbezeichnungen. Derselbe Callback protokolliert die ursprünglichen Begriffe, die von beiden Vorgängen gefunden wurden.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

Falls ein Treffer Teile mit unterschiedlicher Formatierung umfasst, überprüfen Sie die Ausgabe, um festzustellen, welche Formatierung auf den ersetzten Text angewendet werden soll.

## **Text in einer gesamten Präsentation ersetzen**

Verwenden Sie [Presentation.ReplaceText](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/replacetext/) und [Presentation.ReplaceRegex](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/replaceregex/), um dieselben Vorgänge über die gesamte Präsentation anzuwenden. Dies ist nützlich für die Vorlagen‑Bereinigung, Terminologie‑Aktualisierungen und Schwärzungen.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **Treffer für Berichte gruppieren**

Da jedes Ergebnis seine Foliennummer und sein Textfeld speichert, können Anwendungen Treffer für Prüf‑, Bericht‑ oder Überprüfungs‑Workflows gruppieren. Das folgende Beispiel gruppiert die gesammelten Ergebnisse zuerst nach Folie und anschließend nach Textfeld:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **FAQ**

**Wie kann ich nur ein Textfeld anstatt der gesamten Präsentation durchsuchen?**

Rufen Sie das Textfeld der Form ab und rufen Sie [ITextFrame.HighlightText](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/replacetext/) oder [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/replaceregex/) für dieses Textfeld auf. Methoden auf Presentation‑Ebene verarbeiten stattdessen alle anwendbaren Textfelder.

**Wie kann ich komplette Wörter mit korrekter Groß‑ und Kleinschreibung abgleichen?**

Setzen Sie [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/de/net/aspose.slides/textsearchoptions/wholewordsonly/) und [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/de/net/aspose.slides/textsearchoptions/casesensitive/) auf `true` und übergeben Sie die Optionen an eine literal‑Text‑Hervorhebungs‑ oder Ersetzungs‑Methode. Bei regulären Ausdrücken definieren Sie Wortgrenzen und Groß‑/Kleinschreibung direkt im .NET‑`Regex`.

**Können Suche und Ersetzung Text in Foliennotizen einbeziehen?**

Ja. Setzen Sie [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/de/net/aspose.slides/textsearchoptions/includenotes/) auf `true`, wenn Sie eine literal‑Text‑Operation auf Präsentationsebene verwenden. Die oben gezeigte Callback‑Implementierung ordnet einen Treffer in einer Notizfolie wieder ihrer übergeordneten Foliennummer zu.

**Wie kann ich einen Bericht erstellen, ohne die Präsentation ein zweites Mal zu durchsuchen?**

Übergeben Sie eine Implementierung von [IFindResultCallback](https://reference.aspose.com/slides/de/net/aspose.slides/ifindresultcallback/) an die Hervorhebungs‑ oder Ersetzungs‑Operation. Der Callback erhält jeden Treffer, während der Vorgang läuft, sodass die Anwendung den Quelltext, den gefundenen Text, die Position, das Textfeld und die abgeleitete Foliennummer für spätere Gruppierung oder den Export speichern kann.

**Erhält das Ersetzen von Text seine Formatierung bei?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/replacetext/) und [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/replaceregex/) ändern den gefundenen Text innerhalb des bestehenden Textfeldes und behalten die umgebende Formatierung bei. Wenn ein Treffer Teile mit unterschiedlicher Formatierung umfasst, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung den gewünschten Stil verwendet.