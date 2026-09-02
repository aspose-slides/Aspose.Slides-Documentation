---
title: Cerca e sostituisci testo nelle presentazioni PowerPoint in .NET
linktitle: Cerca e sostituisci testo
type: docs
weight: 55
url: /it/net/search-and-replace-text/
keywords:
- ricerca testo
- evidenzia testo
- sostituisci testo
- espressione regolare
- callback risultato
- frame di testo
- report di audit
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Cerca, evidenzia e sostituisci testo nelle presentazioni PowerPoint raccogliendo ogni corrispondenza con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides for .NET può cercare, evidenziare e sostituire il testo in un singolo frame di testo o in tutta la presentazione. Ogni operazione può anche notificare un'applicazione per ogni corrispondenza tramite un callback di risultato. Questo rende possibile aggiornare una presentazione e, contemporaneamente, creare un audit trail contenente il testo corrispondente, il suo contesto, la posizione, il frame di testo e il numero della diapositiva.

Queste funzionalità sono utili per revisioni, redazioni, controlli di terminologia, pulizia di modelli e flussi di lavoro di reportistica automatica.

Negli esempi seguenti, utilizziamo un file denominato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Testo di esempio](sample_text.png)

## **Scegliere l'Ambito di Ricerca**

Usa i metodi su [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) per limitare un'operazione a un frame di testo. Usa i metodi su [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) per elaborare tutto il testo applicabile nella presentazione.

| Operazione | Un frame di testo | Intera presentazione |
|---|---|---|
| Evidenzia testo letterale | [ITextFrame.HighlightText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/highlighttext/) |
| Evidenzia corrispondenze di espressione regolare | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/highlightregex/) |
| Sostituisci testo letterale | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/replacetext/) |
| Sostituisci corrispondenze di espressione regolare | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/replaceregex/) |

## **Configurare la Corrispondenza del Testo**

Per operazioni su testo letterale, usa [TextSearchOptions](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/) per controllare la corrispondenza:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/wholewordsonly/) limita le corrispondenze a parole complete.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/casesensitive/) controlla se il caso dei caratteri deve corrispondere.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/includenotes/) include le note della diapositiva nelle operazioni di ricerca, sostituzione ed evidenziazione a livello di presentazione.

Le operazioni basate su espressioni regolari usano un `Regex` .NET, quindi le regole di corrispondenza come sensibilità al caso e confini di parola sono definite dall'espressione e dalle sue opzioni.

## **Identificare il Proprietario di un Frame di Testo**

I flussi di lavoro generici di elaborazione del testo ricevono spesso un [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) durante la ricerca, la sostituzione, la convalida o l'esportazione del testo. Usa [ITextFrame.ParentShape](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/parentshape/) e [ITextFrame.ParentCell](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/parentcell/) per determinare quale oggetto della presentazione possiede il frame di testo.

I valori attesi dipendono dal proprietario:

| Proprietario del frame di testo | `ParentShape` | `ParentCell` |
|---|---|---|
| Un'AutoShape o altra forma contenente testo | La [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) proprietaria | `null` |
| Una cella di tabella | `null` | La [ICell](https://reference.aspose.com/slides/it/net/aspose.slides/icell/) proprietaria |

Entrambe le proprietà sono di sola lettura. La loro lettura non sposta il frame di testo né ne modifica il proprietario. Il codice generico dovrebbe verificare entrambi i valori per `null` e gestire la possibilità che nessuno dei due proprietari sia disponibile.

L'esempio seguente utilizza [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/getalltextframes/) per iterare sui frame di testo in una presentazione. Per le forme, riporta il nome della forma, il tipo di forma e la diapositiva contenente. Per le celle di tabella, riporta le coordinate di colonna e riga (indice zero) e la diapositiva contenente.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

Per il contenuto SmartArt, itera sulle forme in [ISmartArtNode.Shapes](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/ismartartnode/shapes/) e accedi a ciascuna [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/ismartartshape/textframe/). Il frame di testo può essere ricondotto alla sua forma associata tramite [ITextFrame.ParentShape](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/parentshape/), mentre [ITextFrame.ParentCell](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/parentcell/) è `null`. Pertanto, il ramo delle forme nell'esempio gestisce anche il testo proveniente dai nodi SmartArt.

## **Raccogliere le Informazioni di Corrispondenza con un Callback**

Implementa [IFindResultCallback](https://reference.aspose.com/slides/it/net/aspose.slides/ifindresultcallback/) per ricevere una notifica per ogni corrispondenza. Il suo metodo [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/it/net/aspose.slides/ifindresultcallback/foundresult/) fornisce il frame di testo correlato, il testo sorgente, il testo corrispondente e la posizione della corrispondenza.

Il callback non riceve direttamente il numero della diapositiva. L'implementazione sotto lo ricava dalla diapositiva padre e gestisce anche il testo trovato nelle note della diapositiva. Un numero di diapositiva nullable consente allo stesso modello di risultato di rappresentare testi associati ad altri tipi di diapositive.

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

Utilizza il metodo [ITextFrame.HighlightText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlighttext/) per evidenziare le corrispondenze di testo letterale in un frame di testo. Passa [TextSearchOptions](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/) per controllare la ricerca e un callback per raccogliere i dettagli della corrispondenza.

L'esempio di codice sotto evidenzia tutte le occorrenze dei caratteri **"try"** e poi evidenzia solo la parola completa **"to"**. Entrambe le ricerche riportano le loro corrispondenze allo stesso callback.

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

## **Evidenziare il Testo Usando Espressioni Regolari**

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

## **Evidenziare il Testo in Tutta la Presentazione**

Usa [Presentation.HighlightText](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/highlighttext/) e [Presentation.HighlightRegex](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/highlightregex/) per cercare tutti i frame di testo applicabili nella presentazione. L'esempio seguente evidenzia un termine letterale e tutti gli indirizzi email mantenendo raccolte di risultati separate per le due ricerche.

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

Usa [ITextFrame.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replacetext/) per testo letterale e [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replaceregex/) per sostituzioni basate su pattern. Questi metodi aggiornano il testo corrispondente all'interno del frame di testo esistente, mantenendo la formattazione delle porzioni circostanti invece di ricostruire il frame di testo da una stringa semplice.

L'esempio seguente standardizza una variante ortografica e poi sostituisce le etichette di versione. Lo stesso callback registra i termini originali corrispondenti a entrambe le operazioni.

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

Se una corrispondenza attraversa porzioni con formattazioni diverse, verifica l'output per confermare quale formattazione debba essere applicata al testo sostituito.

## **Sostituire il Testo in Tutta la Presentazione**

Usa [Presentation.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/replacetext/) e [Presentation.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/replaceregex/) per applicare le stesse operazioni a tutta la presentazione. Questo è utile per la pulizia di modelli, aggiornamenti di terminologia e redazioni.

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

## **Raggruppare le Corrispondenze per la Reportistica**

Poiché ogni risultato memorizza il numero della diapositiva e il frame di testo, le applicazioni possono raggruppare le corrispondenze per audit, reportistica o flussi di lavoro di revisione. L'esempio seguente raggruppa i risultati raccolti prima per diapositiva e poi per frame di testo:

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

**Come posso cercare solo una casella di testo invece dell'intera presentazione?**

Ottieni il frame di testo della forma e chiama [ITextFrame.HighlightText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replacetext/) o [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replaceregex/) su quel frame di testo. I metodi a livello di presentazione elaborano tutti i frame di testo applicabili invece.

**Come posso corrispondere parole complete con la corretta capitalizzazione?**

Imposta [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/wholewordsonly/) e [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/casesensitive/) su `true`, e passa le opzioni a un metodo di evidenziazione o sostituzione di testo letterale. Per le espressioni regolari, definisci i confini di parola e la sensibilità al caso direttamente nel `Regex` .NET.

**La ricerca e la sostituzione possono includere il testo nelle note della diapositiva?**

Sì. Imposta [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/it/net/aspose.slides/textsearchoptions/includenotes/) su `true` quando utilizzi un'operazione di testo letterale a livello di presentazione. L'implementazione del callback mostrata sopra mappa una corrispondenza in una diapositiva di note al suo numero di diapositiva padre.

**Come posso creare un report senza scansionare nuovamente la presentazione?**

Passa un'implementazione di [IFindResultCallback](https://reference.aspose.com/slides/it/net/aspose.slides/ifindresultcallback/) all'operazione di evidenziazione o sostituzione. Il callback riceve ogni corrispondenza durante l'esecuzione dell'operazione, così l'applicazione può memorizzare il testo sorgente, il testo corrispondente, la posizione, il frame di testo e il numero di diapositiva derivato per successivi raggruppamenti o esportazioni.

**La sostituzione del testo preserva la sua formattazione?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replacetext/) e [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/replaceregex/) modificano il testo corrispondente all'interno del frame di testo esistente e mantengono la formattazione delle porzioni circostanti. Se una corrispondenza attraversa porzioni con formattazioni diverse, ispeziona il risultato per garantire che la sostituzione utilizzi lo stile desiderato.