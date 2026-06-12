---
title: Recuperare i limiti del paragrafo dalle presentazioni in Java
linktitle: Paragrafo
type: docs
weight: 60
url: /it/java/paragraph/
keywords:
- limiti del paragrafo
- limiti della porzione di testo
- coordinate del paragrafo
- coordinate della porzione
- dimensione del paragrafo
- dimensione della porzione di testo
- frame di testo
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come recuperare i limiti dei paragrafi e delle porzioni di testo in Aspose.Slides per Java per ottimizzare il posizionamento del testo nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, le dimensioni e le coordinate dei paragrafi e delle porzioni di testo in Aspose.Slides. Mostra come recuperare il rettangolo di un paragrafo in un `TextFrame` utilizzando `getRect()`, come ottenere le coordinate di paragrafo e porzione all'interno di un text frame di una cella di tabella e evidenzia dettagli importanti come le unità di misura, l'effetto dell'avvolgimento del testo sui limiti, la conversione in pixel e i valori di formattazione effettiva del paragrafo.

## **Ottenere le coordinate di Paragrafo e Porzione in un TextFrame**
Utilizzando Aspose.Slides per Java, gli sviluppatori possono ora ottenere le coordinate rettangolari del Paragraph all'interno della raccolta di paragrafi di TextFrame. Consente anche di ottenere [le coordinate della porzione](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPortion#getCoordinates--) all'interno della raccolta di porzioni di un paragrafo. In questo argomento dimostreremo, con l'aiuto di un esempio, come ottenere le coordinate rettangolari per un paragrafo insieme alla posizione della porzione all'interno di un paragrafo.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Ottenere le coordinate rettangolari di un Paragrafo**
Utilizzando il metodo [**getRect()**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IParagraph#getRect--) gli sviluppatori possono ottenere il rettangolo dei limiti del paragrafo.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ottenere le dimensioni di un Paragrafo e di una Porzione all'interno di un TextFrame di cella di tabella**

Per ottenere le dimensioni e le coordinate di una [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/Portion) o di un [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/Paragraph) in un text frame di una cella di tabella, è possibile utilizzare i metodi [IPortion.getRect](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPortion#getRect--) e [IParagraph.getRect](https://reference.aspose.com/slides/it/java/com.aspose.slides/IParagraph#getRect--).

Questo esempio di codice dimostra l'operazione descritta:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**In quali unità vengono restituite le coordinate di un paragrafo e delle porzioni di testo?**

In punti, dove 1 pollice = 72 punti. Questo vale per tutte le coordinate e le dimensioni nella diapositiva.

**Il word wrapping influisce sui limiti di un paragrafo?**

Sì. Se [wrapping](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframeformat/#setWrapText-byte-) è abilitato nel [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/), il testo si interrompe per adattarsi alla larghezza dell'area, modificando i limiti effettivi del paragrafo.

**Le coordinate del paragrafo possono essere mappate in modo affidabile a pixel nell'immagine esportata?**

Sì. Converti i punti in pixel usando: pixel = punti × (DPI / 72). Il risultato dipende dal DPI scelto per il rendering/esportazione.

**Come posso ottenere i parametri di formattazione "effettiva" del paragrafo, tenendo conto dell'ereditarietà dello stile?**

Utilizza la [effective paragraph formatting data structure](/slides/it/java/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziatura, avvolgimento, RTL e altro.