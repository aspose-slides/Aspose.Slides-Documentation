---
title: Converti le diapositive PowerPoint in PNG in PHP
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/php-java/convert-powerpoint-to-png/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in PNG
- presentazione in PNG
- diapositiva in PNG
- PPT in PNG
- PPTX in PNG
- salva PPT come PNG
- salva PPTX come PNG
- esporta PPT in PNG
- esporta PPTX in PNG
- PHP
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in immagini PNG ad alta qualità rapidamente con Aspose.Slides per PHP via Java, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Questo articolo spiega come convertire le diapositive di una presentazione in immagini PNG utilizzando Aspose.Slides per PHP via Java. È possibile caricare presentazioni in formati come PPT, PPTX e ODP, renderizzare ogni diapositiva e salvarla come immagine PNG separata.

Gli esempi seguenti dimostrano il rendering alla scala predefinita, l'aumento della scala, la specifica delle dimensioni di output in pixel e la scelta di uno stile di rendering a gradiente.

## **Converti PowerPoint in PNG**

Carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e accedi alle sue diapositive tramite la collezione [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). L'esempio rende ogni diapositiva con [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) senza parametri per creare una miniatura. Quindi chiama [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) con [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) per salvare ogni diapositiva renderizzata come immagine PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
La sovraccarico senza parametri di [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) effettua il rendering a una scala di 0,2. Ad esempio, una diapositiva di 720 × 540 punti produce una miniatura di 144 × 108 pixel. Per controllare le dimensioni di output, utilizza le sovraccarichi con fattori di scala o una dimensione dell'immagine esplicita mostrata di seguito.
{{% /alert %}}

## **Converti PowerPoint in PNG con Dimensioni Personalizzate**

Passa i fattori di scala orizzontali e verticali a [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) per controllare le dimensioni renderizzate. In questo esempio, entrambi i fattori sono 2, quindi una diapositiva di 720 Г— 540 punti produce un'immagine di 1440 Г— 1080 pixel. Fattori di scala uguali preservano il rapporto d'aspetto della diapositiva. Ogni immagine viene salvata in formato PNG con [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Converti PowerPoint in PNG con Dimensione Personalizzata**

Per specificare le dimensioni di output in pixel, passa una dimensione a [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) invece dei fattori di scala. Questo esempio rende ogni diapositiva a 960 Г— 720 pixel e salva il risultato con [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Scegli dimensioni che corrispondano al rapporto d'aspetto della diapositiva per evitare lo stiramento dell'immagine.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Scegli uno Stile di Rendering a Gradiente**

Supponiamo che una diapositiva contenga riempimenti a gradiente, ma le transizioni nel PNG esportato risultino più chiare o altrimenti diverse da quelle visualizzate in PowerPoint. È possibile utilizzare il metodo [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) ereditato da [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) per scegliere come vengono renderizzati i gradienti.

Scarica [gradient-styles.pptx](gradient-styles.pptx) e posizionalo nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene due gradienti lineari: ciano verso arancione in alto e blu verso giallo in basso. Ogni gradiente ha due fermate, allo 0% e al 100%.

L'esempio seguente carica questa presentazione e renderizza la stessa prima diapositiva in entrambi i modi con [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Le immagini sottostanti mostrano l'output della stessa diapositiva, con entrambi i gradienti in ogni immagine:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienti da ciano a arancione e da blu a giallo renderizzati con Default](gradient-Default.png) | ![Gli stessi gradienti renderizzati con PowerPointUI](gradient-PowerPointUI.png) |

In questo esempio, `Default` produce colori intermedi più chiari, mentre `PowerPointUI` produce colori intermedi più scuri. La differenza dipende dai colori e dalle fermate nel gradiente.

Scegli `Default` quando l'output standard di Aspose.Slides soddisfa le tue esigenze. Prova `PowerPointUI` quando la tua priorità è corrispondere all'aspetto in PowerPoint. Confronta entrambi gli output con il risultato desiderato; nessuna modalità è universalmente preferibile.

## **FAQ**

**Come posso esportare una forma specifica, come un grafico o un'immagine, invece dell'intera diapositiva?**

Aspose.Slides supporta la [generazione di miniature per singole forme](/slides/it/php-java/create-shape-thumbnails/), consentendo di renderizzare una forma come immagine PNG.

**La conversione parallela è supportata su un server?**

Sì. Utilizza un'istanza di presentazione separata per ogni thread o processo; [non condividere una singola istanza tra thread](/slides/it/php-java/multithreading/).

**Quali sono le limitazioni della modalità di valutazione durante l'esportazione in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [altre restrizioni](/slides/it/php-java/licensing/) finché non viene applicata una licenza.