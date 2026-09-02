---
title: Crea miniature delle forme di presentazione in PHP
linktitle: Miniature delle forme
type: docs
weight: 70
url: /it/php-java/create-shape-thumbnails/
keywords:
- miniatura forma
- immagine forma
- renderizzare forma
- rendering forma
- limiti visivi
- limiti forma
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Genera miniature di forma ad alta qualità dalle diapositive PowerPoint con Aspose.Slides per PHP tramite Java – crea ed esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides viene utilizzato per creare file di presentazione in cui ogni pagina è una diapositiva. Queste diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Tuttavia, a volte gli sviluppatori potrebbero aver bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In questi casi, Aspose.Slides ti aiuta a generare immagini miniature delle forme della diapositiva. Come utilizzare questa funzionalità è descritto in questo articolo.

Questo articolo spiega come generare miniature di diapositive in diversi modi:

- Generare una miniatura di una forma all'interno di una diapositiva.
- Generare una miniatura di una forma per una forma della diapositiva con dimensioni definite dall'utente.
- Generare una miniatura di una forma nei limiti dell'aspetto di una forma.

## **Generare una Miniatura di Forma da una Diapositiva**
Per generare una miniatura di forma da qualsiasi diapositiva utilizzando Aspose.Slides per PHP tramite Java, esegui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva utilizzando il suo ID o indice.
1. [Ottieni l'immagine miniatura della forma](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage) della diapositiva di riferimento alla scala predefinita.
1. Salva l'immagine miniatura nel formato immagine preferito.

Questo esempio di codice mostra come generare una miniatura di forma da una diapositiva:

```php
  # Istanzia una classe Presentation che rappresenta il file di presentazione
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Crea un'immagine a scala intera
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Salva l'immagine su disco in formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Generare una Miniatura con Fattore di Scala Definito dall'Utente**
Per generare la miniatura della forma di una diapositiva utilizzando Aspose.Slides per PHP tramite Java, esegui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva utilizzando il suo ID o indice.
1. [Ottieni l'immagine miniatura della forma](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage) della diapositiva di riferimento con dimensioni definite dall'utente.
1. Salva l'immagine miniatura nel formato immagine preferito.

Questo esempio di codice mostra come generare una miniatura di forma basata su un fattore di scala definito:

```php
  # Istanzia una classe Presentation che rappresenta il file di presentazione
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Crea un'immagine a scala intera
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Salva l'immagine su disco in formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Creare una Miniatura di Forma Basata sui Limiti dell'Aspetto**
Questo metodo di creazione di miniature di forme permette agli sviluppatori di generare una miniatura nei limiti dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura della forma generata è limitata dai limiti della diapositiva. Per generare una miniatura di una forma di diapositiva nei limiti del suo aspetto, esegui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva utilizzando il suo ID o indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con i limiti della forma come aspetto.
1. Salva l'immagine miniatura nel formato immagine preferito.

Questo esempio di codice si basa sui passaggi precedenti:

```php
  # Istanzia una classe Presentation che rappresenta il file di presentazione
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Crea un'immagine a scala intera
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Salva l'immagine su disco in formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ottenere i Limiti Visivi Reali di una Forma**

Le proprietà del frame di [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/)—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` e `Shape::getHeight()`—descrivono il rettangolo memorizzato nel modello della presentazione. Il contenuto effettivamente renderizzato può estendersi oltre quel frame o occupare un rettangolo allineato agli assi diverso. Rotazione, contorni, punte delle frecce, layout e overflow del testo, geometria SmartArt generata e altri effetti di rendering possono tutti modificare l'area occupata.

Usa [Shape::getVisualBounds](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getVisualBounds) per calcolare quell'area occupata senza creare un'immagine. Il metodo restituisce un [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) nelle coordinate della diapositiva. Il rettangolo restituito non è ritagliato alla diapositiva, quindi le sue coordinate possono essere negative quando il contenuto si estende oltre l'origine della diapositiva.

Il seguente esempio ottiene e confronta i limiti del frame e quelli visivi:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

La stessa [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) può essere usata per allineare forme vicine al suo bordo sinistro, destro, superiore o inferiore; riservare spazio sufficiente in un layout generato; o rilevare contenuti al di fuori di una zona consentita. I limiti visivi sono particolarmente utili per SmartArt, caselle di testo, frecce, immagini, forme ruotate e forme di gruppo, dove il frame memorizzato potrebbe non rappresentare il risultato renderizzato completo.

Usa [Shape::getVisualBounds](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getVisualBounds) quando hai bisogno di coordinate per il layout o la convalida e non ti serve una bitmap. Usa [Shape::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage) quando devi renderizzare la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` dimensiona l'immagine dai limiti della forma, includendo le impostazioni del contorno, mentre `ShapeThumbnailBounds::Appearance` la dimensiona dall'aspetto della forma e limita il risultato ai limiti della diapositiva. Al contrario, `Shape::getVisualBounds` restituisce solo il rettangolo calcolato e non lo ritaglia alla diapositiva.

## **FAQ**

**Quali formati immagine possono essere utilizzati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/php-java/aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/writeassvg/) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti Shape e Appearance durante il rendering di una miniatura?**

`Shape` utilizza la geometria della forma; `Appearance` tiene conto dei [effetti visivi](/slides/it/php-java/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Viene comunque renderizzata come miniatura?**

Una forma nascosta rimane parte del modello e può essere renderizzata; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Le forme di gruppo, i grafici, SmartArt e altri oggetti complessi sono supportati?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/) e [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/)) può essere salvato come miniatura o come SVG.

**I font installati nel sistema influiscono sulla qualità delle miniature per le forme di testo?**

Sì. Dovresti [fornire i font richiesti](/slides/it/php-java/custom-font/) (o [configurare le sostituzioni dei font](/slides/it/php-java/font-substitution/)) per evitare ricadute indesiderate e il riarrangiamento del testo.