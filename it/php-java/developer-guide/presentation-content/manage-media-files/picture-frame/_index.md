---
title: Gestisci i riquadri immagine nelle presentazioni con PHP
linktitle: Riquadro immagine
type: docs
weight: 10
url: /it/php-java/picture-frame/
keywords:
- riquadro immagine
- aggiungi riquadro immagine
- crea riquadro immagine
- immagine incorporata
- immagine collegata
- estrai immagine
- immagine raster
- immagine SVG
- ritaglia immagine
- elimina aree ritagliate
- comprime immagine
- StretchOffset
- formattazione riquadro immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Crea, formatta, collega, ritaglia, estrae e comprime i riquadri immagine nelle presentazioni con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Un picture frame è una forma di diapositiva che visualizza un'immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) possiede risorse immagine incorporate tramite la sua [ImageCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/), mentre un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) controlla la posizione, le dimensioni, la formattazione della linea, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di cornice.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l'immagine alla presentazione una sola volta, conserva il [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) restituito e usa quella risorsa immagine quando crei i picture frame.

I picture frame possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono inoltre riferirsi a immagini collegate anziché memorizzare i byte dell'immagine nella presentazione. La scelta influisce su portabilità, dimensione del file, estrazione e comportamento di esportazione, perciò è utile decidere come l'immagine debba essere archiviata prima di applicare formattazioni o ottimizzazioni.

## **Aggiungere e formattare un'immagine incorporata**

Per un'immagine incorporata, aggiungi i dati immagine alla presentazione e crea un picture frame con [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addpictureframe/). L'immagine diventa parte del pacchetto della presentazione, così la presentazione rimane autonoma quando viene spostata su un altro computer.

L'esempio seguente aggiunge un'immagine JPEG, crea una cornice con le dimensioni native dell'immagine e applica la formattazione della linea e la rotazione:

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

La cornice controlla la geometria visualizzata; modificare la dimensione della cornice non cambia le dimensioni in pixel originali memorizzate nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime un'immagine in seguito.

## **Utilizzare la scala relativa**

[PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) espone la scala di larghezza e altezza relativa per la cornice tramite [setRelativeScaleWidth](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/setrelativescalewidth/) e [setRelativeScaleHeight](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Un valore di `1.0` corrisponde al 100 % della dimensione originale dell'immagine. La scala relativa è utile quando un flusso di lavoro deve preservare una relazione con la dimensione dell'immagine di origine invece di calcolare manualmente le dimensioni finali.

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

La scala relativa modifica le impostazioni di scala della cornice; non ricampiona né comprime l'immagine incorporata.

## **Immagini incorporate e collegate**

Un'immagine incorporata memorizza i dati immagine all'interno della presentazione e rappresenta quindi la scelta più sicura per la portabilità e il rendering prevedibile. Un'immagine collegata memorizza un percorso esterno tramite il metodo [Picture::setLinkPathLong](https://reference.aspose.com/slides/it/php-java/aspose.slides/picture/setlinkpathlong/) anziché incorporare i dati immagine nello stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all'applicazione che apre o rende la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è disponibile, l'immagine collegata potrebbe non essere visualizzata come previsto. Per presentazioni che devono essere inviate via e‑mail, archiviate o renderizzate in ambienti isolati, le immagini incorporate sono solitamente più affidabili.

### **Aggiungere un'immagine collegata**

L'esempio seguente crea un picture frame e lo punta a un file immagine locale. Si occupa solo del collegamento immagine; il collegamento video è un flusso di lavoro multimediale separato e non è mescolato in questo esempio.

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

Usa collegamenti quando la gestione dei file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze immagine rotte è solitamente meno utile di una presentazione più grande e autonoma.

## **Estrarre immagini da picture frame**

Prima di estrarre un'immagine da una presentazione esistente, verifica che una forma sia effettivamente un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) e che contenga un'immagine incorporata. I picture frame collegati potrebbero non contenere byte immagine estraibili nello stesso modo.

### **Estrarre un'immagine raster**

L'API immagine moderna utilizza direttamente [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/). L'esempio seguente trova la prima immagine raster incorporata su una diapositiva e la salva come PNG:

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

Il salvataggio tramite [IImage::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/#save) converte l'immagine estratta nel formato di output richiesto. Se hai bisogno dei byte codificati memorizzati nella presentazione invece di un file raster convertito, usa i dati binari della risorsa immagine.

### **Estrarre un'immagine SVG**

Per un'immagine SVG, il [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) espone un oggetto [SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/). Questo consente di recuperare direttamente i dati SVG invece di rasterizzare prima l'immagine.

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

Mantenere il contenuto SVG come SVG preserva la sorgente vettoriale all'interno della presentazione. Le esportazioni raster come PNG o JPEG rendono necessariamente quel contenuto vettoriale in pixel. L'esportazione della diapositiva in PDF o SVG è anch'essa un'operazione di rendering, quindi la grafica esportata non dovrebbe essere trattata come una copia byte‑per‑byte dell'SVG originale; usa i dati di [SvgImage::getSvgData](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/getsvgdata/) quando è necessario il vettore originale stesso.

## **Ritagliare un'immagine**

Il ritaglio modifica quale parte di un'immagine è visibile all'interno della cornice. I valori di ritaglio su [PictureFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/) sono percentuali delle dimensioni dell'immagine di origine. Il ritaglio non elimina inizialmente i pixel nascosti dall'immagine incorporata; cambia solo la regione visibile.

L'esempio seguente individua in modo sicuro un picture frame e applica i valori di ritaglio:

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

Poiché i dati immagine nascosti sono ancora presenti, il ritaglio può essere modificato in seguito senza perdere i pixel originali. Se la dimensione del file è più importante della reversibilità, le regioni ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i dati dell'immagine ritagliata**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre la dimensione del file, ma è un'ottimizzazione distruttiva: dopo il salvataggio della presentazione i pixel rimossi non sono più disponibili per un'operazione di "undo" del ritaglio.

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

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l'immagine originale è anche usata da altri picture frame, quelle cornici hanno ancora bisogno della loro risorsa esistente, quindi l'eliminazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Il ritaglio di contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere immagini raster**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) riduce la risoluzione dell'immagine raster rispetto alla dimensione con cui l'immagine viene visualizzata. Può anche rimuovere le regioni ritagliate nella stessa operazione. Il metodo restituisce `true` quando l'immagine è stata ridimensionata o ritagliata e `false` quando non è stato necessario alcun cambiamento.

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

È possibile passare un valore DPI positivo personalizzato al posto di un valore predefinito quando è richiesto un target specifico.

La compressione è destinata alle immagini raster. Il contenuto SVG e metafile non viene ridotto da questo workflow di compressione raster. Ricorda inoltre che risoluzioni più basse e regioni ritagliate eliminate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target basata sulla dimensione più grande alla quale l'immagine verrà effettivamente visualizzata o esportata, anziché applicare il DPI più basso globalmente.

## **Gestire gli effetti di trasformazione dell'immagine**

Per un flusso di lavoro completo che copre luminosità, contrasto, trasformazioni colore, sfocatura, effetti alfa, catene ordinate, ispezione, rimozione e verifica round‑trip, vedere [Image Transform Effects](/php-java/image-transform-effects/).

## **Bloccare la geometria del picture frame**

Le impostazioni di [PictureFrameLock](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframelock/) controllano quali operazioni di modifica sono disabilitate per un picture frame. Ad esempio, [setAspectRatioLocked](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) preserva le proporzioni della forma mentre viene ridimensionata.

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

Il blocco si applica alla forma del picture frame. Non forza l'immagine di origine a essere ricampionata o modificata permanentemente per avere lo stesso rapporto d'aspetto.

## **Regolare i valori StretchOffset**

Quando la modalità di riempimento immagine è stretch, i valori stretch‑offset su [PictureFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/) definiscono il rettangolo di riempimento relativo al riquadro di delimitazione del picture frame. Percentuali positive creano un'inset da un bordo, mentre percentuali negative creano un'outset.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell'immagine di origine è visibile; gli offset di stretch modificano il rettangolo in cui il riempimento immagine visibile viene allungato.

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

Usa gli offset di stretch per il posizionamento del riempimento. Usa le proprietà di ritaglio quando l'obiettivo è nascondere i bordi dell'immagine di origine.

## **Considerazioni su archiviazione, dimensione file ed esportazione**

I principali compromessi sono più facili da gestire quando l'archiviazione delle immagini e la formattazione dei picture frame sono trattati separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per condivisione e rendering lato server, ma le grandi immagini raster aumentano la dimensione del PPTX e l'uso di memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dalla disponibilità dei file esterni nei percorsi o nelle posizioni memorizzate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati finché le aree ritagliate non sono esplicitamente eliminate o rimosse durante la compressione.
- **Compressione** può ridurre significativamente la dimensione del file per immagini raster sovradimensionate, ma sacrifica la risoluzione di origine. Deve essere applicata dopo aver determinato la dimensione finale desiderata nella diapositiva.
- **Immagini SVG** dovrebbero rimanere SVG quando la preservazione vettoriale è importante. Estrai l'SVG incorporato direttamente quando ti serve la risorsa vettoriale stessa. Le esportazioni raster della diapositiva convertono sempre la diapositiva renderizzata in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) esistente quando possibile invece di caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l'ottimizzazione delle immagini è solitamente più efficace quando eseguita in modo selettivo: mantieni loghi e diagrammi come contenuto vettoriale, comprimi le foto in base alla loro reale dimensione di visualizzazione, rimuovi i pixel ritagliati solo quando non è necessaria una successiva modifica e evita i collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un picture frame e una risorsa immagine?**

Un [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) rappresenta una risorsa immagine associata alla presentazione. Un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) è una forma su una diapositiva che visualizza un'immagine e memorizza la geometria e la formattazione a livello di cornice, come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza accesso a risorse esterne. Collega le immagini solo quando mantenere i file immagine fuori dal PPTX è intenzionale e le posizioni esterne possono essere gestite in modo affidabile.

**Il ritaglio riduce la dimensione del file PPTX?**

Non di per sé. Le impostazioni di ritaglio normali nascondono parti dell'immagine di origine ma mantengono i pixel sottostanti. Usa [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) o la compressione dell'immagine con rimozione delle aree ritagliate quando quei pixel possono essere eliminati definitivamente.

**Posso ripristinare la qualità dell'immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata e la rimozione delle regioni ritagliate scarta dati immagine. Conserva l'immagine sorgente originale al di fuori della presentazione se in futuro potresti aver bisogno di modifiche ad alta risoluzione.

**Come dovrebbero essere gestite le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L'[SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/) incorporato può essere estratto direttamente. Il rendering di una diapositiva in un formato raster come PNG o JPEG rasterizza l'SVG come parte dell'immagine della diapositiva.

**Come posso evitare cast non sicuri durante la lettura delle diapositive esistenti?**

Verifica il tipo di forma prima di utilizzare i membri specifici del picture frame. Un controllo `java_instanceof` contro [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) evita cast non validi e consente al codice di gestire le diapositive che non contengono picture frame.