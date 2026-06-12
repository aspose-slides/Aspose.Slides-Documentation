---
title: Ottieni i limiti del paragrafo dalle presentazioni in .NET
linktitle: Paragrafo
type: docs
weight: 60
url: /it/net/paragraph/
keywords:
- limiti del paragrafo
- limiti della porzione di testo
- coordinata del paragrafo
- coordinata della porzione
- dimensione del paragrafo
- dimensione della porzione di testo
- frame di testo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come recuperare i limiti del paragrafo e della porzione di testo in Aspose.Slides per .NET per ottimizzare il posizionamento del testo nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, le dimensioni e le coordinate di paragrafi e porzioni di testo in Aspose.Slides. Mostra come recuperare il rettangolo di un paragrafo in un `TextFrame` usando `GetRect()`, come ottenere le coordinate di paragrafo e porzione all'interno di un text frame di una cella di tabella, e mette in evidenza dettagli importanti come le unità di misura, l'effetto dell'andamento del testo sui limiti, la conversione in pixel e i valori di formattazione del paragrafo effettivi.

## **Ottieni le coordinate di Paragrafo e Porzione in un TextFrame**
Utilizzando Aspose.Slides per .NET, gli sviluppatori possono ora ottenere le coordinate rettangolari per Paragraph all'interno della collezione di paragrafi di TextFrame. Consente inoltre di ottenere le coordinate della porzione all'interno della collezione di porzioni di un paragrafo. In questo argomento dimostreremo, con l'aiuto di un esempio, come ottenere le coordinate rettangolari per un paragrafo insieme alla posizione della porzione all'interno di un paragrafo.

## **Ottieni le coordinate rettangolari di un Paragrafo**
È stato aggiunto il nuovo metodo **GetRect()**. Consente di ottenere il rettangolo dei limiti del paragrafo.

```c#
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Ottieni le dimensioni di un Paragrafo e di una Porzione all'interno di un TextFrame di cella di tabella**

Per ottenere le dimensioni e le coordinate di [Portion](https://reference.aspose.com/slides/it/net/aspose.slides/portion) o [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph) in un text frame di una cella di tabella, è possibile utilizzare i metodi [IPortion.GetRect](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/methods/getrect) e [IParagraph.GetRect](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/methods/getrect).

Questo codice di esempio dimostra l'operazione descritta:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **FAQ**

**In quali unità vengono restituiti le coordinate per un paragrafo e le porzioni di testo?**

In punti, dove 1 pollice = 72 punti. Questo vale per tutte le coordinate e le dimensioni sulla diapositiva.

**L'andamento del testo influisce sui limiti di un paragrafo?**

Sì. Se il [wrapping](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat/wraptext/) è abilitato nel [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/), il testo si interrompe per adattarsi alla larghezza dell'area, modificando i limiti reali del paragrafo.

**Le coordinate del paragrafo possono essere mappate in modo affidabile a pixel nell'immagine esportata?**

Sì. Converti i punti in pixel usando: pixels = points × (DPI / 72). Il risultato dipende dal DPI scelto per il rendering/esportazione.

**Come posso ottenere i parametri di formattazione "effettivi" del paragrafo, tenendo conto dell'ereditarietà di stile?**

Utilizza la [effective paragraph formatting data structure](/slides/it/net/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziatura, avvolgimento, RTL e altro.