---
title: Esporta le diapositive della presentazione come immagini SVG in PHP
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /it/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- Opzioni di esportazione SVG
- SVG interattivo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Esporta le diapositive PowerPoint come immagini SVG in PHP e controlla caratteri, testo, immagini, ID ed eventi con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine basato su XML scalabile che funziona bene per la pubblicazione web, i visualizzatori di diapositive, i flussi di lavoro di accessibilità e l'elaborazione automatica post‑produzione. Aspose.Slides esporta ogni diapositiva in un file SVG separato e consente di controllare come vengono scritti testo, caratteri, immagini e gli elementi SVG.

Utilizzare [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) quando l'SVG esportato deve essere compatto, prevedibile tra i browser o pronto per l'uso interattivo.

## **Esporta una diapositiva come SVG**

Creare una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), selezionare una diapositiva e scriverla su uno stream con [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Il nome file utilizza [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) anziché l'indice del ciclo. È inoltre possibile esportare una forma singola con [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) quando un visualizzatore di diapositive o una pagina web necessita solo di quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) include il riquadro di testo nell'area di rendering, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) determina se viene applicata la rotazione del riquadro. Impostare [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) su `true` quando il testo deve essere renderizzato senza legature.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Controlla il ritaglio delle estremità di linea alle punte delle frecce**

SVG 1.1 non dispone di un'impostazione di inset del marcatore per specificare dove una linea dovrebbe fermarsi sotto una punta di freccia. Per impostazione predefinita, Aspose.Slides accorcia la linea esportata in modo che il tratto non sporga attraverso il marcatore. Chiamare [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) con `true` per disegnare il tratto fino al punto finale originale della linea. Questa impostazione influisce solo sull'output SVG. La linea mantiene la sua posizione e lunghezza nella diapositiva.

L'esempio disegna punte di freccia a triangolo e a diamante su linee di larghezza 2 e 10 punti. Esporta la stessa diapositiva due volte, modificando solo l'opzione di ritaglio.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

Il confronto mostra la punta triangolare sulla linea da 10 punti. Con il ritaglio abilitato, la punta è affilata. Con il ritaglio disabilitato, il tratto sporge attraverso i lati inclinati del marcatore lasciando un'estremità piatta.

![Triangolo ingrandito da 10 punti con punta affilata quando il ritaglio è abilitato e estremità piatta quando il ritaglio è disabilitato](line-end-cropping.png)

Nelle altre linee dell'esempio, il tratto sporgente è meno visibile sul triangolo da 2 punti. Il diamante riempito copre l'estremità del tratto a entrambe le larghezze.

## **Controlla il testo e i caratteri**

Durante l'esportazione delle diapositive in SVG, è possibile controllare se il testo rimane come testo o viene convertito in grafiche vettoriali, e come i caratteri esterni vengono inclusi o referenziati. Le opzioni seguenti aiutano a bilanciare la coerenza visiva, la selezione del testo e le dipendenze dei caratteri nell'SVG esportato.

### **Vettorizza tutto il testo**

Impostare [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) su `true` per scrivere tutto il testo della diapositiva come grafiche vettoriali. Ciò elimina le dipendenze dai caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile né ricercabile come testo SVG.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Scegli come gestire i caratteri esterni**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegliere `AddLinksToFontFiles` per referenziare file di carattere separati, `Embed` per includere i dati del carattere nell'SVG, oppure `Vectorize` per renderizzare come grafiche solo il testo che utilizza caratteri esterni. Verificare la licenza dei caratteri prima di incorporarli.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Riduci la dimensione delle immagini incorporate**

Utilizzare [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) per omettere le aree di origine ritagliate, e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) per controllare la qualità della codifica JPEG. Queste impostazioni riducono le dimensioni del file a scapito della fedeltà dell'immagine o dei dati immagine conservati.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Controlla la risoluzione di rasterizzazione dei metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) imposta il limite inferiore di risoluzione per la rasterizzazione dei metafile durante l'esportazione SVG. Usarlo per bilanciare il dettaglio e le dimensioni del file quando un'immagine EMF o WMF viene rasterizzata. Non definisce un DPI globale per l'SVG né forza ogni oggetto della diapositiva a diventare un'immagine raster.

Scaricare [metafile-rasterization.pptx](metafile-rasterization.pptx), che contiene un'immagine EMF con linee diagonali ravvicinate. L'esempio seguente esporta la sua prima diapositiva a tre risoluzioni di rasterizzazione tramite [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Tutte le altre impostazioni di esportazione rimangono identiche in modo che i risultati possano essere confrontati.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

Nell'output, l'EMF è diventato un PNG incorporato in ogni SVG. Le seguenti misurazioni sono relative alla presentazione fornita; non rappresentano una formula generale per convertire DPI in dimensioni pixel.

| Risoluzione rasterizzazione metafile DPI | Dimensioni PNG incorporato | Dimensione file SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Il confronto sotto mostra la stessa area del raster incorporato alla stessa dimensione di visualizzazione ingrandita. Le linee diagonali mostrano una pixelazione visibile a 72 DPI e bordi più lisci a risoluzioni più alte, mentre il file SVG aumenta. Incrementare il valore non migliora necessariamente ogni dettaglio né cambia ogni immagine esportata.

![Dettaglio ingrandito di linee diagonali a 72, 150 e 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) controlla la riduzione della risoluzione delle immagini e può mascherare l'effetto della modifica della risoluzione di rasterizzazione del metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) controlla la qualità della codifica JPEG, non la risoluzione di rasterizzazione del metafile.

## **Assegna ID stabili a forme e testo**

Fornire un callback di formattazione a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) per impostare [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) per ogni forma SVG. Il callback può anche impostare i valori [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) sugli elementi `tspan` di testo.

PhpJavaBridge non può invocare un callback PHP da `writeAsSvg` quando è in modalità stream. Inserire la logica di formattazione in una piccola classe di supporto Java, compilarla e aggiungere il file JAR risultante al classpath del bridge. L'aiutante può utilizzare [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId), che è stabile per la durata della forma, e un contatore ripetibile per i suoi tratti di testo. Vedere l'[implementazione Java di `StableSvgIdController`](/slides/it/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) per il codice di supporto.

Dopo aver aggiunto la classe compilata `com.example.slides.StableSvgIdController` al classpath del bridge, istanziarla da PHP e assegnarla a `SVGOptions`:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Aggiungi gestori di eventi SVG**

In un callback di formattazione, chiamare [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) con un valore [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) per aggiungere un gestore di eventi JavaScript a una forma esportata. Assegnare il callback con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) e definire la funzione JavaScript nella pagina o nel documento SVG che ospita il risultato.

Come per gli ID stabili, implementare il callback in un helper Java quando PhpJavaBridge utilizza la modalità stream. L'[implementazione Java di `SvgEventController`](/slides/it/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) assegna un ID e un gestore `OnClick` a una forma denominata `ActionButton`. Compilare tale helper, aggiungerlo al classpath del bridge come `com.example.slides.SvgEventController`, e usarlo da PHP come segue:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

La pagina host può definire la funzione JavaScript referenziata dal gestore. L'assegnazione di ID e gestori di eventi abilita i visualizzatori di diapositive, miglioramenti di accessibilità e altri flussi di lavoro SVG interattivi.

## **FAQ**

**Quando dovrei usare [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) invece di [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Utilizzare [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) quando tutto il testo deve essere indipendente dai caratteri. Utilizzare [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafiche.

**Qual è il modo migliore per rendere un SVG più piccolo?**

Iniziare comprimendo le immagini incorporate, eliminando le aree di immagine ritagliate e scegliendo file di caratteri collegati quando l'ambiente di destinazione può servirli. Testare il risultato perché una risoluzione immagine più bassa, una qualità JPEG inferiore e il testo vettorizzato comportano ciascuno compromessi diversi di qualità e dimensione.

**Posso modificare gli elementi SVG esportati dopo l'esportazione?**

Sì. Assegnare ID tramite un callback di formattazione, quindi selezionare gli elementi SVG corrispondenti nel proprio strumento di post‑elaborazione o script del browser.