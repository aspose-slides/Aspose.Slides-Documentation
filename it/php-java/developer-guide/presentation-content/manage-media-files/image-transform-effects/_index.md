---
title: Gestire gli effetti di trasformazione delle immagini nelle presentazioni con PHP
linktitle: Effetti di trasformazione immagine
type: docs
weight: 11
url: /it/php-java/image-transform-effects/
keywords:
- trasformazione immagine
- effetto immagine
- luminosità
- contrasto
- scala di grigi
- duotono
- tinta
- HSL
- sostituzione colore
- sfocatura
- trasparenza
- effetto alfa
- catena di effetti
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Applica, concatena, ispeziona, rimuovi e verifica gli effetti di trasformazione immagine per i riquadri immagine con Aspose.Slides per PHP tramite Java."
---
## **Panoramica**

Aspose.Slides rappresenta le regolazioni delle immagini come una collezione ordinata di operazioni di trasformazione dell’immagine. Per un riquadro immagine, inizia con il [Picture](https://reference.aspose.com/slides/it/php-java/aspose.slides/picture/) del riquadro e accedi a [Picture::getImageTransform](https://reference.aspose.com/slides/it/php-java/aspose.slides/picture/getimagetransform/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/) restituita consente di aggiungere, enumerare, ispezionare, rimuovere e cancellare gli effetti senza riscrivere i byte dell’immagine originale.

Questo articolo dimostra un flusso di lavoro completo per luminosità e contrasto, trasformazioni di colore, sfocatura, trasparenza, catene di effetti ordinate, valori effettivi, rimozione e verifica di round‑trip PPTX.

## **Comprendere la proprietà degli effetti e il riuso delle immagini**

Una risorsa immagine e l’immagine che la visualizza sono oggetti diversi:

- [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) memorizza o fa riferimento ai dati dell’immagine sorgente di proprietà della presentazione.
- [Picture](https://reference.aspose.com/slides/it/php-java/aspose.slides/picture/) appartiene a un riempimento immagine e fa riferimento a una risorsa immagine mentre memorizza la collezione di trasformazioni dell’immagine.
- [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) è la forma della diapositiva che possiede il relativo riempimento immagine, la geometria, le impostazioni di ritaglio e altre formattazioni a livello di riquadro.

Pertanto, le operazioni di trasformazione dell’immagine non modificano i byte in [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/). Quando lo stesso `PPImage` viene passato più di una volta a [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addpictureframe/), ogni nuovo riquadro immagine riceve il proprio `Picture` e la propria collezione di trasformazioni. Applicare la scala di grigi a un riquadro non rende gli altri riquadri in scala di grigi, anche se tutti riutilizzano la stessa risorsa immagine incorporata.

Lo stesso modello `Picture::getImageTransform` è usato anche da altri riempimenti immagine, come uno sfondo forma o diapositiva. Gli esempi seguenti si concentrano sui riquadri immagine.

## **Usare intervalli di parametri e unità validi**

I metodi dimostrati usano i seguenti intervalli semantici e unità. Mantieni i valori in questi intervalli anche se una versione specifica della libreria non rifiuta immediatamente ogni valore fuori intervallo; il formato di destinazione della presentazione può normalizzare, omettere o rifiutare dati non validi durante il salvataggio o quando PowerPoint apre il file.

| Operazione | Parametri | Intervallo valido e unità |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | da `-100` a `100`, percentuale; `0` lascia il componente invariato. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Nessuno | Nessun parametro numerico. L’alfa rimane invariato. |
| [addDuotoneEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Due colori per pixel scuri e chiari. I canali RGB e alfa in `java.awt.Color` usano valori da `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | La tonalità è da `0` (incluso) a `360` (escluso), in gradi; la quantità è da `-100` a `100`, percentuale. |
| [addHSLEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | La tonalità è da `0` (incluso) a `360` (escluso), in gradi; saturazione e luminanza sono da `-100` a `100`, percentuale. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Il colore di sostituzione usa valori di canale da `0` a `255`. I valori alfa esistenti rimangono invariati. |
| [addBlurEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Il raggio è non negativo e si misura in punti; `grow` è un Booleano che controlla se il contenuto sfocato può estendersi oltre i bordi originali. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Percentuale non negativa. Usa `0`‑`100` per la scalatura opacità ordinaria: `0` è completamente trasparente e `100` preserva l’alfa esistente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | Da `0` a `100`, percentuale di opacità. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | Da `0` a `100`, percentuale di soglia alfa. I valori al di sotto diventano trasparenti; i valori pari o superiori diventano opachi. |

Per la modulazione alfa fissa, trasparenza e opacità sono complementari. Ad esempio, il 35 % di trasparenza corrisponde a una modulazione alfa del 65 %.

## **Applicare luminosità e contrasto**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) restituisce un’operazione [Luminance](https://reference.aspose.com/slides/it/php-java/aspose.slides/luminance/). Le impostazioni scalari vengono fornite al momento della creazione dell’operazione. [Luminance::getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/luminance/geteffective/) restituisce valori calcolati, di sola lettura, che possono essere ispezionati o registrati.

L’esempio seguente aumenta la luminosità del 15 % e il contrasto del 20 %, quindi genera un’anteprima senza modificare l’immagine incorporata:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` è l’effetto standard di luminosità e contrasto di DrawingML. Quando tali impostazioni devono rimanere modificabili dopo un round‑trip PPTX, riapri la presentazione salvata e verifica sia il tipo di operazione sia i suoi valori effettivi.

## **Applicare trasformazioni di colore**

Gli effetti colore possono essere applicati indipendentemente a diversi riquadri immagine che riutilizzano la stessa risorsa. L’esempio seguente crea cinque riquadri e applica scala di grigi, duotono, tinta, regolazione HSL e sostituzione colore.

[Duotone](https://reference.aspose.com/slides/it/php-java/aspose.slides/duotone/) contiene due parametri colore modificabili indipendentemente: `color1` mappa i pixel scuri, mentre `color2` mappa i pixel chiari. Questo lo rende un esempio utile di effetto le cui impostazioni sono più complesse di un singolo valore scalare.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) sostituisce il colore di ogni pixel con un colore fisso preservando l’alfa. È diverso da [addColorChangeEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), che mappa un colore sorgente a un altro e espone entrambi i formati colore sorgente e destinazione.

## **Aggiungere sfocatura, trasparenza ed effetti alfa**

[addBlurEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) influisce su tutti i canali colore, incluso l’alfa. Imposta `grow` a `true` quando il bordo sfocato può estendersi oltre i confini originali dell’immagine.

Per trasparenza uniforme, usa [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Moltiplica ogni valore alfa esistente, così i pixel parzialmente trasparenti rimangono proporzionalmente differenti. [addAlphaReplaceEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) assegna invece un unico valore alfa a tutti i pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) converte l’alfa in due livelli basati su una soglia.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Altre operazioni alfa senza parametri includono [addAlphaCeilingEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), che rende ogni alfa diverso da zero completamente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), che rende ogni alfa inferiore al 100 % completamente trasparente; e [addAlphaInverseEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), che cambia l’alfa in `100% - alpha`.

## **Costruire una catena di effetti ordinata**

Ogni metodo `add...Effect` aggiunge una nuova operazione alla fine della collezione. Il renderer usa la collezione come pipeline ordinata: l’output dell’operazione 0 diventa l’input dell’operazione 1, e così via. Di conseguenza, le stesse operazioni in un ordine diverso possono produrre un’immagine differente.

Ad esempio, scala di grigi seguita da tinta rimuove prima le informazioni cromatiche e poi ricolora il risultato di luminanza. Tinta seguita da scala di grigi rimuove nuovamente la tinta. Allo stesso modo, la sostituzione alfa può sovrascrivere i valori alfa calcolati da operazioni precedenti, mentre la modulazione alfa preserva le loro differenze relative.

L’esempio seguente costruisce una catena di quattro operazioni, la salva come PPTX, riapre la presentazione, verifica sia i tipi di operazione sia il loro ordine, e rende il risultato riaperto:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

La collezione non impone una matrice di compatibilità che limiti operazioni colore, alfa e sfocatura a catene separate. Possono essere combinate, ma le combinazioni non sono sempre utili. Una sostituzione colore fissa elimina la variazione RGB prodotta da effetti colore precedenti; la scala di grigi dopo duotono rimuove i due colori selezionati; e le operazioni alfa di tipo ceiling, floor, replacement o bi‑level possono scartare i dettagli alfa creati in precedenza. Costruisci la catena secondo la sequenza di elaborazione dei pixel desiderata invece di trattare gli elementi come flag di formattazione non ordinati.

## **Ispezionare valori modificabili ed effettivi**

Un’operazione modificabile è l’oggetto memorizzato in `Picture::getImageTransform`. A seconda dell’effetto, può esporre membri scrivibili direttamente. Ad esempio, [Blur](https://reference.aspose.com/slides/it/php-java/aspose.slides/blur/) espone i valori scrivibili `radius` e `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/it/php-java/aspose.slides/alphamodulatefixed/) espone un valore scrivibile `amount`, e [AlphaBiLevel](https://reference.aspose.com/slides/it/php-java/aspose.slides/alphabilevel/) espone `threshold`. Gli effetti colore come [Duotone](https://reference.aspose.com/slides/it/php-java/aspose.slides/duotone/) espongono oggetti [ColorFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/colorformat/) mutabili.

Alcune operazioni, tra cui [Luminance](https://reference.aspose.com/slides/it/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/it/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/it/php-java/aspose.slides/tint/), e [AlphaReplace](https://reference.aspose.com/slides/it/php-java/aspose.slides/alphareplace/), non espongono i loro scalari di creazione come proprietà scrivibili. Per modificare tali impostazioni, rimuovi l’operazione e aggiungi una sostituzione nella posizione richiesta.

I dati effettivi restituiti da `getEffective()` sono calcolati e di sola lettura. Sono utili per risolvere colori dipendenti dal tema e leggere i valori normalizzati che il renderer utilizza, ma non costituiscono un’ulteriore superficie di modifica. L’esempio seguente enumera la catena e ispeziona i valori effettivi dove l’API corrispondente li fornisce:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Gli effetti senza parametri come scala di grigi, alpha ceiling e alpha inverse hanno comunque un oggetto di dati effettivi, ma non ci sono impostazioni scalari da stampare. La loro presenza e posizione nella collezione sono le informazioni importanti.

## **Rimuovere o cancellare le trasformazioni immagine**

Usa [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/removeat/) per rimuovere un’operazione per indice. Poiché gli indici si spostano dopo la rimozione, cerca prima il target e rimuovilo dopo l’enumerazione. Usa [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagetransformoperationcollection/clear/) per eliminare l’intera catena.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Rimuovere o cancellare le trasformazioni modifica solo la formattazione dell’immagine. Non elimina, ricomprime o altera in altro modo la risorsa [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) riutilizzata.

## **Considerare i formati di presentazione e i target di esportazione**

Le trasformazioni immagine hanno origine in DrawingML, quindi PPTX è il formato modificabile preferito per le catene di effetti. Anche con PPTX, non ogni operazione ha la stessa portabilità:

- Le operazioni standard di DrawingML come luminance, grayscale, duotone, tint, HSL, blur e le comuni operazioni alfa hanno la miglior possibilità di sopravvivere a un round‑trip PPTX. Riapri sempre il file generato e ispeziona la collezione quando la preservazione è un requisito.
- Il formato binario PPT precede il modello completo di effetti DrawingML. Il salvataggio in PPT può omettere operazioni non supportate, ridurre una catena a un sotto‑insieme supportato o approssimare l’aspetto. Non usare PPT come formato di verifica per una catena modificabile complessa.
- Il rendering in PNG, JPEG, TIFF, PDF, SVG, HTML o altri output visivi applica la catena supportata all’aspetto renderizzato. Questi output non contengono una `ImageTransformOperationCollection` modificabile; i formati raster appiattiscono il risultato in pixel, e le esportazioni documento o vettoriali memorizzano la propria rappresentazione di rendering.
- Gli effetti non rendono un’immagine collegata autonoma. Il rendering di un’immagine collegata dipende comunque dalla disponibilità della risorsa collegata al caricamento della presentazione.

Diversi consumatori di presentazioni possono rendere casi limite in modo diverso, specialmente quando sono combinate più operazioni alfa o di quantizzazione colore. Per output critici, testa sia il round‑trip modificabile sia il formato di esportazione finale con la stessa versione di Aspose.Slides usata in produzione.

## **FAQ**

**Le trasformazioni immagine modificano i dati dell’immagine incorporata?**

No. Le operazioni appartengono al `Picture` usato dal riempimento immagine. I byte sottostanti di `PPImage` rimangono invariati.

**Due riquadri immagine che riutilizzano la stessa immagine condividono i loro effetti?**

No. Riutilizzare un `PPImage` evita dati immagine duplicati, ma ciascun riquadro immagine ha normalmente un `Picture` separato e una collezione di trasformazioni immagine distinta.

**È possibile combinare effetti colore, sfocatura e alfa?**

Sì. La collezione li accetta in una singola catena ordinata. Considera cosa fa ogni operazione sull’output della precedente, poiché le operazioni di sostituzione e soglia possono scartare dettagli colore o alfa precedenti.

**Perché i valori effettivi sono di sola lettura?**

I dati effettivi rappresentano valori calcolati usati per il rendering, inclusi i colori risolti. Modifica l’operazione memorizzata nella collezione di trasformazioni dove esistono membri scrivibili; altrimenti rimuovila e aggiungi una sostituzione con nuovi parametri di creazione.

**Quale formato devo usare per preservare una catena di trasformazioni?**

Usa PPTX e verifica il file riaprendolo. Il vecchio PPT non può rappresentare l’intero modello di effetti DrawingML, e i formati di esportazione renderizzati preservano l’aspetto ma non le operazioni di trasformazione modificabili.