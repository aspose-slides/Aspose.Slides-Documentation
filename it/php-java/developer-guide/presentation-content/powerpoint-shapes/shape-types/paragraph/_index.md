---
title: Recupera i limiti del paragrafo dalle presentazioni in PHP
linktitle: Paragrafo
type: docs
weight: 60
url: /it/php-java/paragraph/
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
- PHP
- Aspose.Slides
description: "Scopri come recuperare i limiti del paragrafo e della porzione di testo in Aspose.Slides per PHP tramite Java per ottimizzare il posizionamento del testo nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, le dimensioni e le coordinate di paragrafi e porzioni di testo in Aspose.Slides. Mostra come recuperare il rettangolo di un paragrafo in un `TextFrame` usando `getRect()`, come ottenere le coordinate di paragrafo e porzione all'interno di un frame di testo di una cella di tabella, e evidenzia dettagli importanti come le unità di misura, l'effetto del ritorno a capo sul limite, la conversione in pixel e i valori di formattazione effettiva del paragrafo.

## **Ottenere le coordinate di Paragrafo e Porzione in un TextFrame**
Utilizzando Aspose.Slides per PHP tramite Java, gli sviluppatori possono ora ottenere le coordinate rettangolari per il Paragraph all'interno della collezione di paragrafi del TextFrame. Consente inoltre di ottenere [le coordinate della porzione](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#getCoordinates) all'interno della collezione di porzioni di un paragrafo. In questo argomento, dimostreremo con l'aiuto di un esempio come ottenere le coordinate rettangolari per il paragrafo insieme alla posizione della porzione all'interno del paragrafo.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **Ottenere le coordinate rettangolari di un Paragrafo**
Utilizzando il metodo [**getRect()**](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/#getRect) gli sviluppatori possono ottenere il rettangolo dei limiti del paragrafo.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ottenere le dimensioni di un Paragrafo e di una Porzione all'interno di un TextFrame di cella di tabella**
Per ottenere le dimensioni e le coordinate della [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/Portion) o del [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/Paragraph) in un frame di testo di una cella di tabella, è possibile utilizzare i metodi [Portion::getRect](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#getRect) e [Paragraph::getRect](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/#getRect).

Questo codice di esempio dimostra l'operazione descritta:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**In quale unità vengono restituite le coordinate per un paragrafo e le porzioni di testo?**  
In punti, dove 1 pollice = 72 punti. Questo vale per tutte le coordinate e le dimensioni nella diapositiva.

**Il ritorno a capo influisce sui limiti di un paragrafo?**  
Sì. Se il [wrapping](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/setwraptext/) è abilitato nel [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/), il testo viene interrotto per adattarsi alla larghezza dell'area, il che modifica i limiti reali del paragrafo.

**Le coordinate del paragrafo possono essere mappate in modo affidabile ai pixel nell'immagine esportata?**  
Sì. Converti i punti in pixel usando: pixel = punti × (DPI / 72). Il risultato dipende dal DPI scelto per il rendering/esportazione.

**Come posso ottenere i parametri di formattazione "efficace" del paragrafo, tenendo conto dell'ereditarietà dello stile?**  
Utilizza la [effective paragraph formatting data structure](/slides/it/php-java/shape-effective-properties/); restituisce i valori consolidati finali per rientri, spaziatura, avvolgimento, RTL e altro.