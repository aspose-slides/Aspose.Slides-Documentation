---
title: Aggiungi forme di linea alle presentazioni in PHP
linktitle: Linea
type: docs
weight: 50
url: /it/php-java/Line/
keywords:
- linea
- crea linea
- aggiungi linea
- linea semplice
- configura linea
- personalizza linea
- stile tratteggio
- punta della freccia
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Impara a manipolare la formattazione delle linee nelle presentazioni PowerPoint con Aspose.Slides per PHP via Java. Scopri proprietà, metodi ed esempi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere forme di linea alle diapositive PowerPoint in modo programmatico. Questo articolo mostra come creare una linea semplice e come personalizzarla affinché appaia come una freccia.

Imparerai come aggiungere una forma di linea a una diapositiva, regolare il suo aspetto visivo e salvare la presentazione aggiornata. Gli esempi si concentrano su impostazioni pratiche di formattazione della linea come stile, larghezza, modello di tratteggio, opzioni di punta della freccia e colore di riempimento.

## **Creare una linea semplice**

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) .
- Ottieni il riferimento di una diapositiva usando il suo Index.
- Aggiungi un'AutoShape di tipo Line utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addAutoShape) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/) .
- Scrivi la presentazione modificata come file PPTX.

Nell'esempio seguente, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

```php
  # Istanziare la classe PresentationEx che rappresenta il file PPTX
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiungi un'AutoShape di tipo linea
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Scrivi il PPTX su disco
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Creare una linea a forma di freccia**

Aspose.Slides per PHP via Java consente anche agli sviluppatori di configurare alcune proprietà della linea per renderla più attraente. Proviamo a configurare alcune proprietà di una linea per farla apparire come una freccia. Segui i passaggi seguenti per farlo:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) .
- Ottieni il riferimento di una diapositiva usando il suo Index.
- Aggiungi un'AutoShape di tipo Line utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addAutoShape) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/) .
- Imposta lo [Line Style](https://reference.aspose.com/slides/it/php-java/aspose.slides/LineStyle) su uno degli stili offerti da Aspose.Slides per PHP via Java.
- Imposta la larghezza della linea.
- Imposta lo [Dash Style](https://reference.aspose.com/slides/it/php-java/aspose.slides/LineDashStyle) della linea su uno degli stili offerti da Aspose.Slides per PHP via Java.
- Imposta lo [Arrow Head Style](https://reference.aspose.com/slides/it/php-java/aspose.slides/LineArrowheadStyle) e la [Length](https://reference.aspose.com/slides/it/php-java/aspose.slides/LineArrowheadLength) del punto di inizio della linea.
- Imposta lo [Arrow Head Style](https://reference.aspose.com/slides/it/php-java/aspose.slides/LineArrowheadStyle) e la [Length](https://reference.aspose.com/slides/it/php-java/aspose.slides/LineArrowheadLength) del punto finale della linea.
- Scrivi la presentazione modificata come file PPTX.

```php
  # Istanziare la classe PresentationEx che rappresenta il file PPTX
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiungi un'AutoShape di tipo linea
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Applica qualche formattazione sulla linea
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Scrivi il PPTX su disco
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso convertire una linea normale in un connettore in modo che si "agganci" alle forme?**

No. Una linea normale (un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) di tipo [Line](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapetype/)) non diventa automaticamente un connettore. Per farla agganciare alle forme, usa il tipo [Connector](https://reference.aspose.com/slides/it/php-java/aspose.slides/connector/) dedicato e le [API corrispondenti](/slides/it/php-java/connector/) per le connessioni.

**Cosa devo fare se le proprietà di una linea sono ereditate dal tema e risulta difficile determinarne i valori finali?**

[Leggi le proprietà effettive](/slides/it/php-java/shape-effective-properties/) attraverso `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — queste tengono già conto dell'ereditarietà e degli stili del tema.

**Posso bloccare una linea contro la modifica (spostamento, ridimensionamento)?**

Sì. Le forme forniscono [oggetti di blocco](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/getautoshapelock/) che consentono di vietare le operazioni di modifica.