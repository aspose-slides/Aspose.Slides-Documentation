---
title: Gestire le porzioni di testo nelle presentazioni in .NET
linktitle: Porzione di testo
type: docs
weight: 70
url: /it/net/portion/
keywords:
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come gestire le porzioni di testo nelle presentazioni PowerPoint usando Aspose.Slides per .NET, migliorando le prestazioni e la personalizzazione."
---
## **Panoramica**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare con quel frammento indipendentemente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare la posizione di un frammento di testo, applicare formattazione a solo parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

Questo articolo mostra come ottenere le coordinate dell'inizio di una porzione utilizzando il metodo `GetCoordinates()`. Evidenzia anche scenari comuni legati alle porzioni, come l'applicazione di un collegamento ipertestuale a un singolo frammento di testo, la comprensione di come la formattazione venga risolta tramite eredità di porzione, paragrafo, cornice di testo e tema, e la gestione dei casi in cui un font specificato non è disponibile. Inoltre, precisa che il riempimento del testo, il colore e la trasparenza possono essere impostati in modo diverso per singole porzioni all'interno dello stesso paragrafo.

## **Ottieni le coordinate di una porzione di testo**
Il metodo **GetCoordinates()** è stato aggiunto a IPortion e alla classe Portion, consentendo di recuperare le coordinate dell'inizio della porzione:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, puoi [assegnare un collegamento ipertestuale](/slides/it/net/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà degli stili: cosa sovrascrive una Porzione e cosa viene preso dal Paragrafo/Frame di testo?**

Le proprietà a livello di Porzione hanno la precedenza più alta. Se una proprietà non è impostata sulla [Portion](https://reference.aspose.com/slides/it/net/aspose.slides/portion/), il motore la prende dal [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/); se non è impostata neanche lì, dal [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/) o dallo stile del [theme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/theme/).

**Cosa succede se il font specificato per una Porzione è assente sulla macchina/server di destinazione?**

Vengono applicate le [regole di sostituzione dei font](/slides/it/net/font-selection-sequence/). Il testo potrebbe ridisporre: metriche, sillabazione e larghezza possono cambiare, il che è importante per il posizionamento preciso.

**Posso impostare una trasparenza o un gradiente di riempimento del testo specifici per una Porzione, indipendente dal resto del paragrafo?**

Sì, il colore, il riempimento e la trasparenza del testo a livello di [Portion](https://reference.aspose.com/slides/it/net/aspose.slides/portion/) possono differire dai frammenti adiacenti.