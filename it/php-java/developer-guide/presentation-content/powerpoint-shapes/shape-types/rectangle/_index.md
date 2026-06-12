---
title: Aggiungere rettangoli alle presentazioni in PHP
linktitle: Rettangolo
type: docs
weight: 80
url: /it/php-java/rectangle/
keywords:
- aggiungere rettangolo
- creare rettangolo
- forma rettangolare
- rettangolo semplice
- rettangolo formattato
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Migliora le tue presentazioni PowerPoint aggiungendo rettangoli con Aspose.Slides per PHP via Java — progetta e modifica le forme in modo programmato."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme rettangolari alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un rettangolo semplice, la creazione di un rettangolo formattato e il salvataggio della presentazione aggiornata come file PPTX.

Vedrai anche come applicare la formattazione di base del rettangolo, come un colore di riempimento solido, il colore della linea e la larghezza della linea. Inoltre, la sezione FAQ dell'articolo rimanda a operazioni correlate al rettangolo, tra cui angoli arrotondati, riempimenti con immagine, effetti visivi, collegamenti ipertestuali, blocchi della forma, opzioni di esportazione e proprietà effettive.

## **Aggiungere un rettangolo a una diapositiva**
Per aggiungere un rettangolo semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
- Ottenere il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) di tipo Rectangle utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addAutoShape) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/).
- Scrivere la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, è stato aggiunto un rettangolo semplice alla prima diapositiva della presentazione.

```php
  # Istanzia la classe Presentation che rappresenta il PPTX
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiungi AutoShape di tipo ellisse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Scrivi il file PPTX su disco
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungere un rettangolo formattato a una diapositiva**
Per aggiungere un rettangolo formattato a una diapositiva, segui i passaggi seguenti:

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
- Ottenere il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) di tipo Rectangle utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addAutoShape) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/).
- Impostare il [Fill Type](https://reference.aspose.com/slides/it/php-java/aspose.slides/FillType) del rettangolo su Solid.
- Impostare il colore del rettangolo utilizzando il metodo [ColorFormat::setColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/colorformat/#setColor) esposto dall'oggetto [FillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/) associato all'oggetto [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/).
- Impostare il colore delle linee del rettangolo.
- Impostare la larghezza delle linee del rettangolo.
- Scrivere la presentazione modificata come file PPTX.

I passaggi precedenti sono implementati nell'esempio riportato di seguito.

```php
  # Istanzia la classe Presentation che rappresenta il PPTX
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiungi AutoShape di tipo ellisse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Applica formattazione alla forma ellisse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Applica formattazione alla linea dell'ellisse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Scrivi il file PPTX su disco
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Come aggiungo un rettangolo con angoli arrotondati?**

Utilizzare il [shape type](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapetype/) con angolo arrotondato e regolare il raggio dell'angolo nelle proprietà della forma; l'arrotondamento può essere applicato anche per ogni angolo tramite regolazioni geometriche.

**Come riempio un rettangolo con un'immagine (texture)?**

Selezionare il [fill type](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) dell’immagine, fornire la sorgente dell’immagine e configurare le modalità di [stretching/tiling](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillmode/).

**Un rettangolo può avere ombra e bagliore?**

Sì. Sono disponibili [outer/inner shadow, glow, and soft edges](/slides/it/php-java/shape-effect/) con parametri regolabili.

**Posso trasformare un rettangolo in un pulsante con un collegamento ipertestuale?**

Sì. [Assign a hyperlink](/slides/it/php-java/manage-hyperlinks/) al clic della forma (passa a una diapositiva, file, indirizzo web o e‑mail).

**Come posso proteggere un rettangolo da spostamenti e modifiche?**

Utilizzare i blocchi della forma: è possibile vietare lo spostamento, il ridimensionamento, la selezione o la modifica del testo per preservare il layout.

**Posso convertire un rettangolo in un'immagine raster o SVG?**

Sì. È possibile [render the shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage) in un'immagine con dimensioni/scala specificate o [export it as SVG](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/writeassvg/) per utilizzo vettoriale.

**Come ottenere rapidamente le proprietà effettive di un rettangolo tenendo conto del tema e dell'ereditarietà?**

[Use the shape’s effective properties](/slides/it/php-java/shape-effective-properties/): l'API restituisce valori calcolati che tengono conto degli stili del tema, del layout e delle impostazioni locali, semplificando l'analisi della formattazione.