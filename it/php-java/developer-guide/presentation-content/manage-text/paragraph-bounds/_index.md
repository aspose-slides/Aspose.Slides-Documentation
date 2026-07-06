---
title: Ottieni i limiti dei paragrafi dalle presentazioni in PHP
linktitle: Limiti del paragrafo
type: docs
weight: 43
url: /it/php-java/paragraph-bounds/
keywords:
- limiti del paragrafo
- coordinate del paragrafo
- dimensione del paragrafo
- frame di testo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come recuperare i limiti dei paragrafi in Aspose.Slides per PHP tramite Java per ottimizzare il posizionamento del testo nelle presentazioni PowerPowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, le dimensioni e le coordinate dei paragrafi in Aspose.Slides. Mostra come recuperare un rettangolo di un paragrafo da un [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) utilizzando [Paragraph::getRect](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/getrect/), come ottenere le coordinate del paragrafo all'interno di un text frame di una cella di tabella e mette in evidenza dettagli importanti quali le unità di misura, l'effetto del word wrap sui limiti, la conversione dei punti in pixel e i valori di formattazione “effettiva” del paragrafo.

## **Ottenere le coordinate rettangolari di un paragrafo**

Utilizza [Paragraph::getRect](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/getrect/) per ottenere il rettangolo di delimitazione di un paragrafo.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **Ottenere le dimensioni di un paragrafo all'interno di un TextFrame di cella di tabella**

Per ottenere le dimensioni e le coordinate di un [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/) in un text frame di una cella di tabella, utilizza [Paragraph::getRect](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/getrect/). Il rettangolo restituito è relativo al text frame della cella di tabella, quindi aggiungi la posizione della tabella e l'offset della cella quando ti servono coordinate a livello di diapositiva.

Il seguente esempio ottiene i limiti del paragrafo all'interno di una cella di tabella e disegna rettangoli sulla diapositiva per visualizzare tali limiti:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**In quali unità sono misurate le coordinate dei paragrafi?**

Sono misurate in punti, dove 1 pollice corrisponde a 72 punti. Questo vale per tutte le coordinate e le dimensioni sulla diapositiva.

**Il word wrap influisce sui limiti di un paragrafo?**

Sì. Se [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/setwraptext/) è abilitato per il [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/), il testo viene interrotto per adattarsi alla larghezza dell'area, il che modifica i limiti reali del paragrafo.

**Le coordinate del paragrafo possono essere mappate in modo affidabile ai pixel nell'immagine esportata?**

Sì. Converte i punti in pixel usando questa formula: pixel = punti × (DPI / 72). Il risultato dipende dal DPI scelto per il rendering o l'esportazione.

**Come posso ottenere i parametri di formattazione “effettiva” del paragrafo, tenendo conto dell'ereditarietà degli stili?**

Utilizza la [effective paragraph formatting data structure](/slides/it/php-java/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziature, avvolgimento, RTL e altro.