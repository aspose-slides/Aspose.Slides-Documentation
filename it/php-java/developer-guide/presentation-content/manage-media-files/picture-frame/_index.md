---
title: Gestire i frame immagine nelle presentazioni usando PHP
linktitle: Frame immagine
type: docs
weight: 10
url: /it/php-java/picture-frame/
keywords:
- frame immagine
- aggiungi frame immagine
- crea frame immagine
- immagine incorporata
- immagine collegata
- estrai immagine
- immagine raster
- immagine SVG
- ritaglia immagine
- elimina aree ritagliate
- comprimi immagine
- StretchOffset
- formattazione del frame immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Crea, formatta, collega, ritaglia, estrai e comprimi i frame immagine nelle presentazioni con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Un frame immagine è una forma di diapositiva che visualizza un’immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) possiede le risorse immagine incorporate attraverso la sua [ImageCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/), mentre un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) controlla la posizione, le dimensioni, la formattazione della linea, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di frame.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l’immagine alla presentazione una sola volta, conserva il [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) restituito e utilizza quella risorsa immagine quando crei i frame immagine.

I frame immagine possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono inoltre fare riferimento a immagini collegate invece di memorizzare i byte dell’immagine nella presentazione. La scelta influisce sulla portabilità, sulla dimensione del file, sull’estrazione e sul comportamento di esportazione, perciò è utile decidere come l’immagine debba essere memorizzata prima di applicare formattazioni o ottimizzazioni.

## **Aggiungere e formattare un’immagine incorporata**

Per un’immagine incorporata, aggiungi i dati immagine alla presentazione e crea un frame immagine con [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addpictureframe/). L’immagine diventa parte del pacchetto della presentazione, così la presentazione rimane autonoma quando viene spostata su un altro computer.

L’esempio seguente aggiunge un’immagine JPEG, crea un frame alle dimensioni native dell’immagine e applica la formattazione della linea e la rotazione:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il frame immagine controlla la geometria visualizzata; modificare le dimensioni del frame non cambia le dimensioni originali dei pixel memorizzati nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o comprime un’immagine in seguito.

## **Utilizzare la scala relativa**

[PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) espone la scala relativa di larghezza e altezza per il frame attraverso [setRelativeScaleWidth](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/setrelativescalewidth/) e [setRelativeScaleHeight](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Un valore di `1.0` corrisponde al 100 % della dimensione originale dell’immagine. La scala relativa è utile quando un flusso di lavoro deve conservare una relazione con la dimensione dell’immagine sorgente invece di calcolare manualmente le dimensioni finali.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La scala relativa modifica le impostazioni di scala del frame; non ricampiona né comprime l’immagine incorporata.

## **Immagini incorporate e collegate**

Un’immagine incorporata memorizza i dati immagine all’interno della presentazione ed è quindi la scelta più sicura per la portabilità e un rendering prevedibile. Un’immagine collegata memorizza un percorso esterno tramite il metodo [Picture::setLinkPathLong](https://reference.aspose.com/slides/it/php-java/aspose.slides/picture/setlinkpathlong/) invece di incorporare i dati immagine nello stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all’applicazione che apre o rende la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è disponibile, l’immagine collegata potrebbe non essere visualizzata come previsto. Per presentazioni che devono essere inviate via e‑mail, archiviate o renderizzate in ambienti isolati, le immagini incorporate sono solitamente più affidabili.

### **Aggiungere un’immagine collegata**

L’esempio seguente crea un frame immagine e lo punta a un file immagine locale. Gestisce solo il collegamento immagine; il collegamento video è un flusso multimediale separato e non è mescolato in questo esempio.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Usa i collegamenti quando la gestione dei file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze immagine interrotte è generalmente meno utile di una presentazione più grande e autonoma.

## **Estrarre immagini dai frame immagine**

Prima di estrarre un’immagine da una presentazione esistente, verifica che una forma sia realmente un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) e che contenga un’immagine incorporata. I frame immagine collegati potrebbero non contenere byte immagine estraibili nello stesso modo.

### **Estrarre un’immagine raster**

L’API immagine moderna utilizza direttamente [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/). L’esempio seguente trova la prima immagine raster incorporata su una diapositiva e la salva come PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Il salvataggio tramite [IImage::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/#save) converte l’immagine estratta nel formato di output richiesto. Se hai bisogno dei byte codificati memorizzati nella presentazione anziché di un file raster convertito, utilizza i dati binari della risorsa immagine.

### **Estrarre un’immagine SVG**

Per un’immagine SVG, il [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) espone un oggetto [SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/). Questo ti consente di recuperare i dati SVG direttamente invece di rasterizzare prima l’immagine.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Mantenere il contenuto SVG come SVG preserva la sorgente vettoriale all’interno della presentazione. Le esportazioni raster come PNG o JPEG devono necessariamente renderizzare quel contenuto vettoriale in pixel. L’esportazione della diapositiva in PDF o SVG è anch’essa un’operazione di rendering, quindi la grafica esportata non deve essere considerata una copia byte‑per‑byte dell’SVG incorporato originale; usa i dati restituiti da [SvgImage::getSvgData](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/getsvgdata/) quando è richiesto il vettoriale originale stesso.

## **Ritagliare un’immagine**

Il ritaglio cambia quale parte di un’immagine è visibile all’interno del frame. I valori di ritaglio su [PictureFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/) sono percentuali delle dimensioni dell’immagine sorgente. Il ritaglio non elimina inizialmente i pixel nascosti dall’immagine incorporata; modifica solo la regione visibile.

L’esempio seguente trova in modo sicuro un frame immagine e applica i valori di ritaglio:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Poiché i dati immagine nascosti sono ancora presenti, il ritaglio può essere modificato in seguito senza perdere i pixel originali. Se la dimensione del file è più importante della reversibilità, le aree ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i dati immagine ritagliati**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre la dimensione del file, ma è un’ottimizzazione distruttiva: dopo il salvataggio della presentazione, i pixel rimossi non sono più disponibili per un’operazione di “uncrop”.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
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
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l’immagine originale è usata anche da altri frame immagine, quei frame hanno ancora bisogno della loro risorsa esistente, quindi la cancellazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Il ritaglio di contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere immagini raster**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) riduce la risoluzione dell’immagine raster rispetto alla dimensione con cui l’immagine viene visualizzata. Può anche rimuovere le aree ritagliate nella stessa operazione. Il metodo restituisce `true` quando l’immagine è stata ridimensionata o ritagliata e `false` quando non è stato necessario alcun cambiamento.

Usa un valore predefinito di [PicturesCompression](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturescompression/) quando una risoluzione target standard è sufficiente:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

È possibile passare un valore DPI positivo personalizzato invece di un valore predefinito quando è richiesto un target specifico.

La compressione è destinata alle immagini raster. I contenuti SVG e metafile non vengono ridotti da questo flusso di compressione raster. Ricorda inoltre che una risoluzione inferiore e le regioni ritagliate eliminate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target basata sulla dimensione più grande con cui l’immagine sarà effettivamente visualizzata o esportata, invece di applicare il DPI più basso a livello globale.

## **Ispezionare gli effetti immagine**

Gli effetti immagine sono memorizzati sull’immagine usata dal frame. La collezione di trasformazioni immagine può contenere effetti come modulazione alfa fissa per la trasparenza e luminanza per luminosità e contrasto. L’esempio sotto legge in modo sicuro entrambi i tipi di effetti dal primo frame immagine su una diapositiva:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
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
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Questi effetti cambiano il modo in cui l’immagine è renderizzata nel frame; non riscrivono i byte originali dell’immagine incorporata.

## **Bloccare la geometria del frame immagine**

Le impostazioni di [PictureFrameLock](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframelock/) controllano quali operazioni di modifica sono disabilitate per un frame immagine. Per esempio, [setAspectRatioLocked](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) mantiene le proporzioni della forma durante il ridimensionamento.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il blocco si applica alla forma del frame immagine. Non forza la risorsa sorgente a essere ricampionata o permanentemente modificata con lo stesso rapporto d’aspetto.

## **Regolare i valori StretchOffset**

Quando la modalità di riempimento immagine è stretch, i valori stretch‑offset su [PictureFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/) definiscono il rettangolo di riempimento relativo al riquadro di delimitazione del frame immagine. Percentuali positive creano un rientro dal bordo, mentre percentuali negative creano un’estensione.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell’immagine sorgente è visibile; gli offset di stretch modificano il rettangolo in cui il riempimento immagine visibile è allungato.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Usa gli offset di stretch per la posizione del riempimento. Usa le proprietà di ritaglio quando l’obiettivo è nascondere i bordi dell’immagine sorgente.

## **Considerazioni su archiviazione, dimensione file ed esportazione**

I principali compromessi sono più facili da gestire quando l’archiviazione delle immagini e la formattazione dei frame immagine sono trattate separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per condivisione e rendering lato server, ma le grandi immagini raster aumentano la dimensione del PPTX e l’uso di memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dal fatto che i file esterni rimangano disponibili nei percorsi o nelle posizioni memorizzate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati fino a quando le aree ritagliate non vengono esplicitamente cancellate o rimosse durante la compressione.
- **Compressione** può ridurre notevolmente la dimensione del file per immagini raster sovradimensionate, ma sacrifica la risoluzione sorgente. Deve essere applicata dopo aver conosciuto la dimensione finale desiderata sulla diapositiva.
- **Immagini SVG** dovrebbero rimanere SVG quando la preservazione vettoriale è importante. Estrai direttamente l’SvgImage incorporato quando hai bisogno della risorsa vettoriale stessa. Le esportazioni di diapositive raster convertono sempre la diapositiva renderizzata in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) esistente quando possibile invece di caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l’ottimizzazione delle immagini è solitamente più efficace quando eseguita in modo selettivo: conserva loghi e diagrammi come contenuto vettoriale, comprimi le fotografie in base alla loro reale dimensione di visualizzazione, rimuovi i pixel ritagliati solo quando la successiva modifica non è necessaria e evita collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un frame immagine e una risorsa immagine?**

Un [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) rappresenta una risorsa immagine associata alla presentazione. Un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) è una forma su una diapositiva che visualizza un’immagine e memorizza geometria e formattazione a livello di frame come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza accesso a risorse esterne. Collega le immagini solo quando è intenzionale tenere i file immagine fuori dal PPTX e le posizioni esterne possono essere mantenute in modo affidabile.

**Il ritaglio riduce la dimensione del file PPTX?**

Non di per sé. Le impostazioni di ritaglio normale nascondono parti dell’immagine sorgente ma mantengono i pixel sottostanti. Usa [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) o la compressione dell’immagine con rimozione delle aree ritagliate quando quei pixel possono essere scartati definitivamente.

**Posso ripristinare la qualità dell’immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata e la rimozione delle regioni ritagliate elimina i dati immagine. Conserva l’immagine sorgente originale al di fuori della presentazione se in futuro potrebbe essere necessario un editing ad alta risoluzione.

**Come devono essere gestite le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L’[SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/) incorporato può essere estratto direttamente. Renderizzare una diapositiva in un formato raster come PNG o JPEG rasterizza l’SVG come parte dell’immagine della diapositiva.

**Come posso evitare cast non sicuri quando leggo diapositive esistenti?**

Verifica il tipo di forma prima di utilizzare membri specifici del frame immagine. Un controllo `java_instanceof` contro [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) evita cast non validi e permette al codice di gestire le diapositive che non contengono frame immagine.