---
title: Ottieni i limiti del paragrafo dalle presentazioni in JavaScript
linktitle: Limiti del paragrafo
type: docs
weight: 43
url: /it/nodejs-java/paragraph-bounds/
keywords:
- limiti del paragrafo
- coordinate del paragrafo
- dimensione del paragrafo
- riquadro di testo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come recuperare i limiti dei paragrafi in Aspose.Slides per Node.js tramite Java per ottimizzare il posizionamento del testo nelle presentazioni PowerPowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, le dimensioni e le coordinate dei paragrafi in Aspose.Slides. Mostra come recuperare un rettangolo del paragrafo da un [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) utilizzando [Paragraph.getRect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/getrect/), come ottenere le coordinate del paragrafo all'interno di un riquadro di testo di una cella di tabella e mette in evidenza dettagli importanti come le unità di misura, l'effetto dell'interruzione automatica del testo sui limiti, la conversione in pixel e i valori di formattazione del paragrafo effettivi.

## **Ottenere le coordinate rettangolari di un paragrafo**

Usa [Paragraph.getRect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/getrect/) per ottenere il rettangolo di delimitazione di un paragrafo.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Ottenere le dimensioni di un paragrafo all'interno di un TextFrame di cella di tabella**

Per ottenere le dimensioni e le coordinate di un [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) in un TextFrame di cella di tabella, usa [Paragraph.getRect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/getrect/). Il rettangolo restituito è relativo al TextFrame della cella di tabella, quindi aggiungi la posizione della tabella e l'offset della cella quando ti servono coordinate a livello di diapositiva.

Il seguente esempio ottiene i limiti del paragrafo all'interno di una cella di tabella e disegna rettangoli sulla diapositiva per visualizzare tali limiti:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**In quali unità sono misurate le coordinate del paragrafo?**

Sono misurate in punti, dove 1 pollice equivale a 72 punti. Questo vale per tutte le coordinate e le dimensioni sulla diapositiva.

**L'interruzione automatica del testo influisce sui limiti di un paragrafo?**

Sì. Se [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/setwraptext/) è abilitato per il [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/), il testo si interrompe per adattarsi alla larghezza dell'area, il che modifica i limiti reali del paragrafo.

**È possibile mappare in modo affidabile le coordinate del paragrafo a pixel nell'immagine esportata?**

Sì. Converti i punti in pixel usando questa formula: pixel = punti x (DPI / 72). Il risultato dipende dal DPI scelto per il rendering o l'esportazione.

**Come ottenere i parametri di formattazione "effettivi" del paragrafo, tenendo conto dell'ereditarietà degli stili?**

Usa la [struttura dati di formattazione efficace del paragrafo](/slides/it/nodejs-java/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziature, interruzioni, RTL e altro.