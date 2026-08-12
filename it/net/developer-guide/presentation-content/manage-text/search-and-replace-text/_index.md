---
title: "Cerca e Sostituisci Testo in Presentazioni PowerPoint in .NET"
linktitle: "Cerca e Sostituisci Testo"
type: docs
weight: 55
url: /it/net/search-and-replace-text/
keywords:
- "cerca testo"
- "evidenzia testo"
- "sostituisci testo"
- "espressione regolare"
- "callback di risultato"
- "frame di testo"
- "rapporto di audit"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Cerca, evidenzia e sostituisci testo nelle presentazioni PowerPoint raccogliendo ogni corrispondenza con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides per .NET può cercare, evidenziare e sostituire il testo in un singolo frame di testo o in un'intera presentazione. Ogni operazione può anche notificare un'applicazione per ogni corrispondenza tramite un callback di risultato. Questo consente di aggiornare una presentazione e contemporaneamente creare una traccia di audit contenente il testo corrispondente, il suo contesto, la posizione, il frame di testo e il numero della diapositiva.

Queste funzionalità sono utili per revisioni, redazioni, controlli della terminologia, pulizia dei modelli e flussi di lavoro di reportistica automatizzata.

Nei primi esempi seguenti, utilizziamo un file denominato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente testo:

![Testo di esempio](sample_text.png)

## **Scegliere l'Ambito di Ricerca**

Utilizza i metodi su [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) per limitare un'operazione a un singolo frame di testo. Utilizza i metodi su [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) per elaborare tutto il testo applicabile nella presentazione.

| Operazione | Un singolo frame di testo | Intera presentazione |
|---|---|---|
| Evidenziare testo letterale | [ITextFrame.HighlightText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/highlighttext/) |
| Evidenziare corrispondenze di espressione regolare | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/highlightregex/) |
| Sostituire testo letterale | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/replacetext/) |
| Sostituire corrispondenze di espressione regolare | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/replaceregex/) |

## **Configurare la Corrispondenza del Testo**

Per le operazioni su testo letterale, utilizza [TextSearchOptions](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/) per controllare la corrispondenza:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/wholewordsonly/) limita le corrispondenze a parole complete.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/casesensitive/) controlla se il caso dei caratteri deve corrispondere.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/includenotes/) include le note delle diapositive nelle operazioni di ricerca, sostituzione ed evidenziazione a livello di presentazione.

Le operazioni con espressioni regolari usano un `Regex` .NET, quindi le regole di corrispondenza come la sensibilità al caso e i confini di parola sono definiti dall'espressione e dalle sue opzioni.

## **Raccogliere le Informazioni di Corrispondenza con un Callback**

Implementa [IFindResultCallback](https://reference.aspose.com/slides/it/net/aspose.slides/ifindresultcallback/) per ricevere una notifica per ogni corrispondenza. Il suo metodo [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/it/net/aspose.slides/ifindresultcallback/foundresult/) fornisce il frame di testo correlato, il testo sorgente, il testo corrispondente e la posizione della corrispondenza.

Il callback non riceve direttamente il numero della diapositiva. L'implementazione sotto lo ricava dalla diapositiva genitore e gestisce anche il testo trovato nelle note della diapositiva. Un numero di diapositiva nullable consente allo stesso modello di risultato di rappresentare testo associato ad altri tipi di diapositiva.

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

Per le operazioni di sostituzione, `FoundText` contiene il testo originale corrispondente, così il callback può registrare esattamente quali termini sono stati sostituiti.

## **Evidenziare il Testo**

Usa il metodo [ITextFrame.HighlightText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlighttext/) per evidenziare le corrispondenze di testo letterale in un frame di testo. Passa [TextSearchOptions](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/) per controllare la ricerca e un callback per raccogliere i dettagli della corrispondenza.

Il codice di esempio sotto evidenzia tutte le occorrenze dei caratteri **"try"** e poi evidenzia solo la parola completa **"to"**. Entrambe le ricerche segnalano le loro corrispondenze allo stesso callback.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Ottieni la prima forma dalla prima diapositiva.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Evidenzia ogni occorrenza di "try" nel frame di testo.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Evidenzia solo la parola completa "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Il risultato:

![Il testo evidenziato](highlighted_text.png)

## **Evidenziare il Testo Usando le Espressioni Regolari**

Il metodo [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlightregex/) evidenzia le corrispondenze di testo trovate da un'espressione regolare in un frame di testo.

Il codice seguente evidenzia tutte le parole contenenti sette o più caratteri e raccoglie ogni corrispondenza:

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

Il risultato:

![Il testo evidenziato usando l'espressione regolare](highlighted_text_using_regex.png)

## **Evidenziare il Testo in un'Intera Presentazione**

Usa [Presentation.HighlightText](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/highlighttext/) e [Presentation.HighlightRegex](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/highlightregex/) per cercare tutti i frame di testo applicabili in una presentazione. L'esempio seguente evidenzia un termine letterale e tutti gli indirizzi email mantenendo collezioni di risultati separate per le due ricerche.

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

## **Sostituire il Testo in un Frame di Testo**

Usa [ITextFrame.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replacetext/) per testo letterale e [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replaceregex/) per sostituzione basata su pattern. questi metodi aggiornano il testo corrispondente all'interno del frame di testo esistente, mantenendo la formattazione della porzione circostante invece di ricostruire il frame di testo da una stringa semplice.

L'esempio seguente uniforma una variante ortografica e poi sostituisce le etichette di versione. Lo stesso callback registra i termini originali corrispondenti in entrambe le operazioni.

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

Se una corrispondenza comprende porzioni con formattazioni diverse, verifica l'output per confermare quale formattazione deve essere applicata al testo di sostituzione.

## **Sostituire il Testo su un'Intera Presentazione**

Usa [Presentation.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/replacetext/) e [Presentation.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/replaceregex/) per applicare le stesse operazioni su tutta la presentazione. Questo è utile per la pulizia dei modelli, aggiornamenti di terminologia e redazione.

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

## **Raggruppare le Corrispondenze per il Reporting**

Poiché ogni risultato memorizza il numero della diapositiva e il frame di testo, le applicazioni possono raggruppare le corrispondenze per audit, reporting o flussi di lavoro di revisione. L'esempio seguente raggruppa i risultati raccolti prima per diapositiva e poi per frame di testo:

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

**Come posso cercare solo in una casella di testo anziché nell'intera presentazione?**

Ottieni il frame di testo della forma e chiama [ITextFrame.HighlightText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replacetext/) o [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replaceregex/) su quel frame di testo. I metodi a livello di presentazione elaborano tutti i frame di testo applicabili invece.

**Come posso corrispondere parole complete con la corretta capitalizzazione?**

Imposta [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/wholewordsonly/) e [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/casesensitive/) su `true`, e passa le opzioni a un metodo di evidenziazione o sostituzione di testo letterale. Per le espressioni regolari, definisci i confini di parola e la sensibilità al caso direttamente nell'`Regex` .NET.

**La ricerca e la sostituzione possono includere il testo nelle note delle diapositive?**

Sì. Imposta [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/includenotes/) su `true` quando utilizzi un'operazione di testo letterale a livello di presentazione. L'implementazione del callback mostrata sopra mappa una corrispondenza in una diapositiva di note al numero della diapositiva genitore.

**Come posso creare un report senza scansionare nuovamente la presentazione?**

Passa un'implementazione di [IFindResultCallback](https://reference.aspose.com/slides/it/net/aspose.slides/ifindresultcallback/) all'operazione di evidenziazione o sostituzione. Il callback riceve ogni corrispondenza mentre l'operazione è in esecuzione, così l'applicazione può memorizzare il testo sorgente, il testo corrispondente, la posizione, il frame di testo e il numero di diapositiva derivato per un successivo raggruppamento o esportazione.

**La sostituzione del testo preserva la sua formattazione?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replacetext/) e [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replaceregex/) modificano il testo corrispondente all'interno del frame di testo esistente e mantengono la formattazione della porzione circostante. Se una corrispondenza comprende porzioni con formattazioni diverse, ispeziona il risultato per assicurarti che la sostituzione utilizzi lo stile desiderato.