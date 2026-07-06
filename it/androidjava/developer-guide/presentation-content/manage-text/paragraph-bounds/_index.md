---
title: Ottenere i limiti del paragrafo dalle presentazioni su Android
linktitle: Limiti del paragrafo
type: docs
weight: 43
url: /it/androidjava/paragraph-bounds/
keywords:
- limiti del paragrafo
- coordinate del paragrafo
- dimensione del paragrafo
- frame di testo
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come recuperare i limiti del paragrafo in Aspose.Slides per Android tramite Java per ottimizzare il posizionamento del testo nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, le dimensioni e le coordinate dei paragrafi in Aspose.Slides. Mostra come recuperare un rettangolo del paragrafo da un [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) usando [IParagraph.getRect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraph#getRect--), come ottenere le coordinate del paragrafo all'interno di un text frame di cella di tabella e evidenzia dettagli importanti come le unità di misura, l'effetto dell'avvolgimento del testo sui limiti, la conversione in pixel e i valori di formattazione del paragrafo "effettivi".

## **Ottenere le coordinate rettangolari di un paragrafo**

Usa [IParagraph.getRect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraph#getRect--) per ottenere il rettangolo di delimitazione di un paragrafo.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Ottenere le dimensioni di un paragrafo all'interno di un TextFrame di cella di tabella**

Per ottenere le dimensioni e le coordinate di un [IParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/) in un text frame di cella di tabella, usa [IParagraph.getRect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraph#getRect--). Il rettangolo restituito è relativo al text frame della cella, quindi aggiungi la posizione della tabella e l'offset della cella quando ti servono coordinate a livello di diapositiva.

L'esempio seguente ottiene i limiti del paragrafo all'interno di una cella di tabella e disegna rettangoli sulla diapositiva per visualizzare tali limiti:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**In quali unità vengono misurate le coordinate del paragrafo?**

Sono misurate in punti, dove 1 pollice corrisponde a 72 punti. Questo vale per tutte le coordinate e le dimensioni nella diapositiva.

**L'avvolgimento del testo influisce sui limiti del paragrafo?**

Sì. Se [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) è abilitato per l'[ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/), il testo viene interrotto per adattarsi alla larghezza dell'area, il che modifica i limiti effettivi del paragrafo.

**Le coordinate del paragrafo possono essere mappate in modo affidabile a pixel nell'immagine esportata?**

Sì. Converti i punti in pixel usando questa formula: pixel = punti × (DPI / 72). Il risultato dipende dal DPI scelto per il rendering o l'esportazione.

**Come ottenere i parametri di formattazione del paragrafo "effettivi", tenendo conto dell'ereditarietà dello stile?**

Usa la [effective paragraph formatting data structure](/slides/it/androidjava/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziature, avvolgimento, RTL e altro.