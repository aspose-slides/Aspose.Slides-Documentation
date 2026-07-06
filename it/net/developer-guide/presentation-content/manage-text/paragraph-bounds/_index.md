---
title: Ottieni i limiti dei paragrafi dalle presentazioni in .NET
linktitle: Limiti del paragrafo
type: docs
weight: 43
url: /it/net/paragraph-bounds/
keywords:
- limiti del paragrafo
- coordinata del paragrafo
- dimensione del paragrafo
- frame di testo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come recuperare i limiti del paragrafo in Aspose.Slides per .NET per ottimizzare il posizionamento del testo nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, le dimensioni e le coordinate dei paragrafi in Aspose.Slides. Mostra come recuperare un rettangolo del paragrafo da un [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) utilizzando [IParagraph.GetRect](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getrect/), come ottenere le coordinate del paragrafo all'interno di un frame di testo di una cella di tabella, e evidenzia dettagli importanti come le unità di misura, l'effetto del ritorno a capo del testo sui limiti, la conversione in pixel e i valori di formattazione effettiva del paragrafo.

## **Ottenere le coordinate rettangolari di un paragrafo**

Utilizza [IParagraph.GetRect](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getrect/) per ottenere il rettangolo di delimitazione di un paragrafo.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Ottenere la dimensione di un paragrafo all'interno di un TextFrame di cella di tabella**

Per ottenere la dimensione e le coordinate di un [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/) in un TextFrame di cella di tabella, utilizza [IParagraph.GetRect](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/getrect/). Il rettangolo restituito è relativo al TextFrame della cella di tabella, quindi aggiungi la posizione della tabella e l'offset della cella quando ti servono coordinate a livello di diapositiva.

Il seguente esempio ottiene i limiti del paragrafo all'interno di una cella di tabella e disegna rettangoli sulla diapositiva per visualizzare tali limiti:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**In quali unità vengono misurate le coordinate del paragrafo?**

Sono misurate in punti, dove 1 pollice equivale a 72 punti. Questo vale per tutte le coordinate e le dimensioni sulla diapositiva.

**Il ritorno a capo del testo influisce sui limiti del paragrafo?**

Sì. Se [TextFrameFormat.WrapText](https://reference.aspose.com/slides/it/net/aspose.slides/textframeformat/wraptext/) è abilitato per l'[ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/), il testo viene interrotto per adattarsi alla larghezza dell'area, il che modifica i limiti effettivi del paragrafo.

**Le coordinate del paragrafo possono essere mappate in modo affidabile sui pixel nell'immagine esportata?**

Sì. Converte i punti in pixel usando questa formula: pixel = punti × (DPI / 72). Il risultato dipende dal DPI scelto per il rendering o l'esportazione.

**Come ottengo i parametri di formattazione "effettivi" del paragrafo, tenendo conto dell'ereditarietà degli stili?**

Utilizza la [effective paragraph formatting data structure](/slides/it/net/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziatura, avvolgimento, RTL e altro.