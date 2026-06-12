---
title: Converti le presentazioni PowerPoint in GIF animati in PHP
linktitle: PowerPoint in GIF
type: docs
weight: 65
url: /it/php-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF animato
- conversione PowerPoint
- conversione presentazione
- conversione diapositiva
- conversione PPT
- conversione PPTX
- PowerPoint in GIF
- presentazione in GIF
- diapositiva in GIF
- PPT in GIF
- PPTX in GIF
- salva PPT come GIF
- salva PPTX come GIF
- esporta PPT come GIF
- esporta PPTX come GIF
- impostazioni predefinite
- impostazioni personalizzate
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Converti facilmente le presentazioni PowerPoint (PPT, PPTX) in GIF animati con Aspose.Slides per PHP via Java. Risultati rapidi e di alta qualità."
---
## **Panoramica**

Aspose.Slides consente di convertire presentazioni PowerPoint in file GIF animati con poche righe di codice. Questo è utile quando è necessario condividere il contenuto delle diapositive in un formato animato leggero, ampiamente supportato, che può essere incorporato in pagine web, messenger o documentazione. Questo articolo spiega come esportare una presentazione in GIF usando le impostazioni predefinite e come personalizzare l'output configurando opzioni come dimensione del fotogramma, ritardo della diapositiva e frequenza dei fotogrammi di transizione tramite [GifOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/gifoptions/).

## **Convertire le presentazioni in GIF animato usando le impostazioni predefinite**

Questo codice di esempio mostra come convertire una presentazione in GIF animato usando le impostazioni standard:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Il GIF animato verrà creato con i parametri predefiniti.

{{%  alert  title="TIP"  color="primary"  %}} 
Se preferisci personalizzare i parametri del GIF, puoi utilizzare la classe [GifOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/GifOptions). Vedi il codice di esempio di seguito.
{{% /alert %}} 

## **Convertire le presentazioni in GIF animato usando impostazioni personalizzate**
Questo codice di esempio mostra come convertire una presentazione in GIF animato usando impostazioni personalizzate:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// la dimensione del GIF risultante

    $gifOptions->setDefaultDelay(2000);// quanto tempo ogni diapositiva verrà mostrata prima di passare alla successiva

    $gifOptions->setTransitionFps(35);// aumenta gli FPS per una migliore qualità dell'animazione di transizione

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Potresti voler provare un convertitore GRATUITO [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) sviluppato da Aspose.
{{% /alert %}}

## **FAQ**

**Cosa succede se i font usati nella presentazione non sono installati sul sistema?**

Installa i font mancanti o [configura i font di fallback](/slides/it/php-java/powerpoint-fonts/). Aspose.Slides effettuerà una sostituzione, ma l'aspetto potrebbe differire. Per il branding, assicurati sempre che i caratteri richiesti siano effettivamente disponibili.

**Posso sovrapporre una filigrana sui fotogrammi GIF?**

Sì. [Aggiungi un oggetto/logo semitrasparente](/slides/it/php-java/watermark/) alla diapositiva master o alle singole diapositive prima dell'esportazione — la filigrana apparirà su ogni fotogramma.