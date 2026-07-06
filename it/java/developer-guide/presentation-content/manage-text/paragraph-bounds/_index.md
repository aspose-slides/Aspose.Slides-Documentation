---
title: Ottieni i limiti dei paragrafi dalle presentazioni in Java
linktitle: Limiti del paragrafo
type: docs
weight: 43
url: /it/java/paragraph-bounds/
keywords:
- limiti del paragrafo
- coordinate del paragrafo
- dimensione del paragrafo
- frame di testo
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come recuperare i limiti dei paragrafi in Aspose.Slides per Java per ottimizzare il posizionamento del testo nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, le dimensioni e le coordinate dei paragrafi in Aspose.Slides. Mostra come recuperare un rettangolo del paragrafo da un [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) utilizzando [IParagraph.getRect](https://reference.aspose.com/slides/it/java/com.aspose.slides/IParagraph#getRect--), come ottenere le coordinate del paragrafo all'interno di un frame di testo di una cella di tabella e mette in evidenza dettagli importanti come le unità di misura, l'effetto del ritorno a capo del testo sui limiti, la conversione in pixel e i valori di formattazione effettiva del paragrafo.

## **Ottenere le coordinate rettangolari di un paragrafo**

Utilizza [IParagraph.getRect](https://reference.aspose.com/slides/it/java/com.aspose.slides/IParagraph#getRect--) per ottenere il rettangolo di delimitazione di un paragrafo.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Ottenere le dimensioni di un paragrafo all'interno di un TextFrame di cella di tabella**

Per ottenere le dimensioni e le coordinate di un [IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/) in un frame di testo di una cella di tabella, usa [IParagraph.getRect](https://reference.aspose.com/slides/it/java/com.aspose.slides/IParagraph#getRect--). Il rettangolo restituito è relativo al frame di testo della cella di tabella, quindi aggiungi la posizione della tabella e lo spostamento della cella quando ti servono le coordinate a livello di diapositiva.

L'esempio seguente ottiene i limiti del paragrafo all'interno di una cella di tabella e disegna rettangoli sulla diapositiva per visualizzare quei limiti:

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

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

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

**In quali unità sono misurate le coordinate dei paragrafi?**

Sono misurate in punti, dove 1 pollice equivale a 72 punti. Questo vale per tutte le coordinate e le dimensioni nella diapositiva.

**Il ritorno a capo del testo influisce sui limiti di un paragrafo?**

Sì. Se [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) è abilitato per il [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/), il testo si interrompe per adattarsi alla larghezza dell'area, modificando i limiti effettivi del paragrafo.

**Le coordinate dei paragrafi possono essere mappate in modo affidabile ai pixel nell'immagine esportata?**

Sì. Converte i punti in pixel usando questa formula: pixel = punti × (DPI / 72). Il risultato dipende dal DPI scelto per il rendering o l'esportazione.

**Come posso ottenere i parametri di formattazione "effettiva" del paragrafo, tenendo conto dell'ereditarietà di stile?**

Usa la [effective paragraph formatting data structure](/slides/it/java/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziatura, avvolgimento, RTL e altro.