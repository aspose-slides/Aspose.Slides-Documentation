---
title: Crea miniature di forme di presentazione in PHP
linktitle: Miniature di forme
type: docs
weight: 70
url: /it/php-java/create-shape-thumbnails/
keywords:
- miniatura di forma
- immagine di forma
- renderizzare forma
- renderizzazione di forma
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Genera miniature di alta qualità delle forme dalle diapositive PowerPoint con Aspose.Slides per PHP via Java – crea e esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides è usato per creare file di presentazione in cui ogni pagina è una diapositiva. Queste diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Ma talvolta, gli sviluppatori potrebbero aver bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In tali casi, Aspose.Slides ti aiuta a generare immagini in miniatura delle forme della diapositiva. Come utilizzare questa funzionalità è descritto in questo articolo.
Questo articolo spiega come generare miniature delle diapositive in diversi modi:

- Generare una miniatura di una forma all'interno di una diapositiva.
- Generare una miniatura di una forma per una forma di diapositiva con dimensioni definite dall'utente.
- Generare una miniatura di una forma nei confini dell'aspetto di una forma.

## **Genera una Miniatura di Forma da una Diapositiva**
Per generare una miniatura di forma da qualsiasi diapositiva usando Aspose.Slides per PHP via Java, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l'immagine in miniatura della forma](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage) della diapositiva di riferimento con scala predefinita.
1. Salva l'immagine in miniatura nel formato immagine preferito.

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

## **Genera una Miniatura con Fattore di Scala Definito dall'Utente**
Per generare la miniatura di una forma di una diapositiva usando Aspose.Slides per PHP via Java, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l'immagine in miniatura della forma](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage) della diapositiva di riferimento con dimensioni definite dall'utente.
1. Salva l'immagine in miniatura nel formato immagine preferito.

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

## **Crea una Miniatura di Aspetto della Forma Basata sui Confini**
Questo metodo di creazione di miniature delle forme consente agli sviluppatori di generare una miniatura nei confini dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura della forma generata è limitata dai confini della diapositiva. Per generare una miniatura di una forma di diapositiva nei confini del suo aspetto, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine in miniatura della diapositiva di riferimento con i confini della forma come aspetto.
1. Salva l'immagine in miniatura nel formato immagine preferito.

Questo esempio di codice è basato sui passaggi sopra:

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

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/php-java/aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/writeassvg/) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i confini Shape e Appearance durante il rendering di una miniatura?**

`Shape` utilizza la geometria della forma; `Appearance` considera [effetti visivi](/slides/it/php-java/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Verrà comunque renderizzata come miniatura?**

Una forma nascosta rimane parte del modello e può essere renderizzata; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Sono supportate forme di gruppo, grafici, SmartArt e altri oggetti complessi?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/), e [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/)) può essere salvato come miniatura o come SVG.

**I font installati a livello di sistema influenzano la qualità delle miniature per le forme di testo?**

Sì. Dovresti [fornire i font richiesti](/slides/it/php-java/custom-font/) (o [configurare le sostituzioni dei font](/slides/it/php-java/font-substitution/)) per evitare fallback indesiderati e riformattazioni del testo.