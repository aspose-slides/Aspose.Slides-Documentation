---
title: Recupera i limiti delle porzioni di testo da presentazioni in .NET
linktitle: Limiti della porzione
type: docs
weight: 47
url: /it/net/portion-bounds/
keywords:
- limiti porzione testo
- porzione di testo
- parte di testo
- coordinate di testo
- posizione del testo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come recuperare i limiti delle porzioni di testo nelle presentazioni PowerPoint usando Aspose.Slides per .NET."
---
## **Panoramica**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare su quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario ottenere i confini di un frammento di testo, applicare formattazione solo a parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

Questo articolo mostra come ottenere il rettangolo di delimitazione di una porzione utilizzando [IPortion.GetRect](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/getrect/). Mostra inoltre come ottenere le coordinate dell'inizio di una porzione tramite [IPortion.GetCoordinates](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/getcoordinates/). Inoltre, evidenzia scenari comuni legati alle porzioni, come l'applicazione di un collegamento ipertestuale a un singolo frammento di testo, la comprensione di come la formattazione venga risolta tramite ereditarietà di porzione, paragrafo, riquadro di testo e tema, e la gestione dei casi in cui un carattere specificato non è disponibile.

## **Ottenere i confini di una porzione di testo**

Utilizzare [IPortion.GetRect](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/getrect/) per recuperare il rettangolo di delimitazione di una porzione di testo:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Ottenere le coordinate di una porzione di testo**

Utilizzare [IPortion.GetCoordinates](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/getcoordinates/) per recuperare le coordinate dell'inizio di una porzione di testo:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a parte del testo all'interno di un singolo paragrafo?**

Sì, è possibile [assegnare un collegamento ipertestuale](/slides/it/net/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà degli stili: cosa sovrascrive una porzione e cosa viene prelevato da un paragrafo o da un riquadro di testo?**

Le proprietà a livello di porzione hanno la precedenza più alta. Se una proprietà non è impostata su [IPortion](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/), Aspose.Slides la prende da [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/). Se non è impostata nemmeno lì, Aspose.Slides utilizza lo stile di [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) o del [tema](https://reference.aspose.com/slides/it/net/aspose.slides.theme/theme/).

** Cosa succede se il carattere specificato per una porzione è assente sulla macchina o sul server di destinazione?**

Entrano in vigore le [regole di sostituzione dei caratteri](/slides/it/net/font-selection-sequence/). Il testo potrebbe subire un riorganizzazione: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o un gradiente di riempimento del testo a livello di porzione in modo indipendente dal resto del paragrafo?**

Sì, colore, riempimento e trasparenza del testo a livello di [IPortion](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/) possono differire dai frammenti vicini.