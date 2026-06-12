---
title: Aggiungi ellissi alle presentazioni in PHP
linktitle: Ellisse
type: docs
weight: 30
url: /it/php-java/ellipse/
keywords:
- ellisse
- forma
- aggiungi ellisse
- crea ellisse
- disegna ellisse
- ellisse formattata
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come creare, formattare e manipolare forme ellittiche in Aspose.Slides per PHP tramite Java su presentazioni PPT e PPTX — esempi di codice inclusi."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme ellittiche alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un'ellisse semplice, la creazione di un'ellisse formattata e il salvataggio della presentazione aggiornata come file PPTX. Include anche domande correlate, come lavorare con la posizione e le dimensioni dell'ellisse, controllare l'ordine di sovrapposizione e applicare effetti di animazione.

## **Crea un'ellisse**
Per aggiungere un'ellisse semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un AutoShape di tipo Ellipse usando il metodo [addAutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addAutoShape) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/).
- Scrivi la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, abbiamo aggiunto un'ellisse alla prima diapositiva

```php
  # Istanzia la classe Presentation che rappresenta il PPTX
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiungi AutoShape di tipo ellisse
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Scrivi il file PPTX su disco
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Crea un'ellisse formattata**
Per aggiungere un'ellisse meglio formattata a una diapositiva, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un AutoShape di tipo Ellipse usando il metodo [addAutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addAutoShape) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/).
- Imposta il tipo di riempimento dell'ellisse su Solid.
- Imposta il colore dell'ellisse usando il metodo `SolidFillColor::setColor` esposto da [FillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/) associato all'oggetto [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/).
- Imposta il colore delle linee dell'ellisse.
- Imposta lo spessore delle linee dell'ellisse.
- Scrivi la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, abbiamo aggiunto un'ellisse formattata alla prima diapositiva della presentazione.

```php
  # Istanzia la classe Presentation che rappresenta il PPTX
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiungi AutoShape di tipo ellisse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Applica alcune formattazioni alla forma ellisse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Applica alcune formattazioni alla linea dell'ellisse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Scrivi il file PPTX su disco
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Come posso impostare la posizione e le dimensioni esatte di un'ellisse rispetto alle unità della diapositiva?**

Le coordinate e le dimensioni sono tipicamente specificate **in punti**. Per ottenere risultati prevedibili, basa i calcoli sulla dimensione della diapositiva e converti i millimetri o i pollici richiesti in punti prima di assegnare i valori.

**Come posso posizionare un'ellisse sopra o sotto altri oggetti (controllare l'ordine di sovrapposizione)?**

Regola l'ordine di disegno dell'oggetto portandolo in primo piano o inviandolo in secondo piano. Questo consente all'ellisse di sovrapporsi ad altri oggetti o di rivelare quelli sottostanti.

**Come posso animare l'apparizione o l'enfasi di un'ellisse?**

[Apply](/slides/it/php-java/shape-animation/) effetti di ingresso, enfasi o uscita alla forma, e configura trigger e tempistiche per orchestrare quando e come l'animazione viene eseguita.