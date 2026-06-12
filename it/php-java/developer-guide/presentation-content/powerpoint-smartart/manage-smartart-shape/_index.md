---
title: Gestisci le grafiche SmartArt nelle presentazioni con PHP
linktitle: Grafica SmartArt
type: docs
weight: 20
url: /it/php-java/manage-smartart-shape/
keywords:
- oggetto SmartArt
- grafica SmartArt
- stile SmartArt
- colore SmartArt
- crea SmartArt
- aggiungi SmartArt
- modifica SmartArt
- cambia SmartArt
- accedi a SmartArt
- tipo di layout SmartArt
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Automatizza la creazione, modifica e stilizzazione di SmartArt in PowerPoint con PHP usando Aspose.Slides, con esempi di codice concisi e linee guida focalizzate sulle prestazioni."
---
## **Panoramica**

Aspose.Slides consente di creare e gestire grafiche SmartArt nelle presentazioni PowerPoint in modo programmato. Questo articolo spiega come aggiungere una forma SmartArt a una diapositiva, accedere alle forme SmartArt esistenti, trovare SmartArt per un tipo di layout specifico e aggiornare l’aspetto visivo modificando lo stile SmartArt o lo stile colore.

Gli esempi mostrano come lavorare con le forme SmartArt tramite la collezione di forme della diapositiva della presentazione, verificare se una forma è SmartArt e quindi modificare o ispezionare le sue proprietà.

## **Crea una forma SmartArt**
Aspose.Slides for PHP via Java ha fornito un’API per creare forme SmartArt. Per creare una forma SmartArt in una diapositiva, segui i passaggi seguenti:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Ottieni il riferimento di una diapositiva utilizzando il suo indice.
1. Aggiungi una forma SmartArt impostando il suo [LayoutType](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArtLayoutType).
1. Salva la presentazione modificata come file PPTX.

```php
  # Istanzia la classe Presentation
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiungi forma SmartArt
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Salvataggio della presentazione
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: forma SmartArt aggiunta alla diapositiva**|

## **Accedi a una forma SmartArt su una diapositiva**
Il codice seguente verrà utilizzato per accedere alle forme SmartArt aggiunte nella diapositiva della presentazione. Nel codice di esempio attraverseremo ogni forma all’interno della diapositiva e verificheremo se è una forma [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArt). Se la forma è di tipo SmartArt la castiamo a istanza **SmartArt**.

```php
  # Carica la presentazione desiderata
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Scorri ogni forma all'interno della prima diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verifica se la forma è di tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Esegui il cast della forma a SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accedi a una forma SmartArt con un particolare tipo di layout**
Il codice di esempio seguente aiuterà ad accedere alla forma [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArt) con un particolare LayoutType. Nota che non è possibile modificare il LayoutType di SmartArt poiché è di sola lettura e viene impostato solo quando la forma SmartArt viene aggiunta.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) e carica la presentazione contenente la forma SmartArt.
1. Ottieni il riferimento della prima diapositiva utilizzando il suo indice.
1. Attraversa ogni forma all’interno della prima diapositiva.
1. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArt) e castala a SmartArt se lo è.
1. Controlla la forma SmartArt con il LayoutType specifico ed esegui le operazioni necessarie.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Scorri ogni forma all'interno della prima diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verifica se la forma è di tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Esegui il cast della forma a SmartArtEx
        $smart = $shape;
        # Verifica il layout di SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modifica lo stile di una forma SmartArt**
In questo esempio impareremo a cambiare lo stile rapido per qualsiasi forma SmartArt.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) e carica la presentazione contenente la forma SmartArt.
1. Ottieni il riferimento della prima diapositiva utilizzando il suo indice.
1. Attraversa ogni forma all’interno della prima diapositiva.
1. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArt) e castala a SmartArt se lo è.
1. Trova la forma SmartArt con lo stile specifico.
1. Imposta il nuovo stile per la forma SmartArt.
1. Salva la Presentazione.

```php
  # Istanzia la classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Ottieni la prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Scorri ogni forma all'interno della prima diapositiva
    foreach($slide->getShapes() as $shape) {
      # Verifica se la forma è di tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Esegui il cast della forma a SmartArtEx
        $smart = $shape;
        # Verifica lo stile SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Modifica lo stile SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Salvataggio della presentazione
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: forma SmartArt con stile modificato**|

## **Modifica lo stile colore di una forma SmartArt**
In questo esempio impareremo a cambiare lo stile colore per qualsiasi forma SmartArt. Il codice di esempio accederà alla forma SmartArt con uno stile colore specifico e ne cambierà lo stile.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) e carica la presentazione contenente la forma SmartArt.
1. Ottieni il riferimento della prima diapositiva utilizzando il suo indice.
1. Attraversa ogni forma all’interno della prima diapositiva.
1. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArt) e castala a SmartArt se lo è.
1. Trova la forma SmartArt con lo stile colore specifico.
1. Imposta il nuovo stile colore per la forma SmartArt.
1. Salva la Presentazione.

```php
  # Istanzia la classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Ottieni la prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Scorri ogni forma all'interno della prima diapositiva
    foreach($slide->getShapes() as $shape) {
      # Verifica se la forma è di tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Esegui il cast della forma a SmartArtEx
        $smart = $shape;
        # Verifica il tipo di colore SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Modifica il tipo di colore SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Salvataggio della presentazione
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: forma SmartArt con stile colore modificato**|

## **FAQ**

**Posso animare SmartArt come un unico oggetto?**

Sì. SmartArt è una forma, quindi è possibile applicare [animazioni standard](/slides/it/php-java/powerpoint-animation/) tramite l’API delle animazioni (entrata, uscita, enfasi, percorsi di movimento) proprio come per altre forme.

**Come posso trovare uno SmartArt specifico su una diapositiva se non conosco il suo ID interno?**

Imposta e utilizza il Testo alternativo (AltText) e cerca la forma per quel valore—questo è il metodo consigliato per individuare la forma target.

**Posso raggruppare SmartArt con altre forme?**

Sì. È possibile raggruppare SmartArt con altre forme (immagini, tabelle, ecc.) e poi [manipolare il gruppo](/slides/it/php-java/group/).

**Come ottengo un’immagine di uno SmartArt specifico (ad es. per un’anteprima o un report)?**

Esporta una miniatura/immagine della forma; la libreria può [renderizzare forme individuali](/slides/it/php-java/create-shape-thumbnails/) in file raster (PNG/JPG/TIFF).

**L’aspetto di SmartArt verrà preservato durante la conversione dell’intera presentazione in PDF?**

Sì. Il motore di rendering punta a un’alta fedeltà per [esportazione PDF](/slides/it/php-java/convert-powerpoint-to-pdf/), con una gamma di opzioni di qualità e compatibilità.