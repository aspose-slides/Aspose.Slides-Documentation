---
title: Renderizza le diapositive di presentazione come immagini SVG in PHP
linktitle: Diapositiva in SVG
type: docs
weight: 50
url: /it/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- opzioni di esportazione SVG
- SVG interattivo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Esporta le diapositive PowerPoint come immagini SVG in PHP e controlla font, testo, immagini, ID ed eventi con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine basato su XML scalabile che funziona bene per la pubblicazione web, i visualizzatori di diapositive, i flussi di lavoro di accessibilità e l'elaborazione posteriore automatizzata. Aspose.Slides esporta ogni diapositiva in un file SVG separato e consente di controllare come vengono scritti testo, font, immagini e elementi SVG.

Utilizza [SVGOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/) quando l'SVG esportato deve essere compatto, prevedibile tra i browser o pronto per un uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/), seleziona una diapositiva e scrivila in uno stream con [Slide.writeAsSvg](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#writeAsSvg). L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

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

Il nome file utilizza [Slide.getSlideNumber](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getSlideNumber) anziché l'indice del ciclo. È inoltre possibile esportare una forma individuale con [Shape.writeAsSvg](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#writeAsSvg) quando un visualizzatore di diapositive o una pagina web richiede solo quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#setUseFrameSize) include il riquadro di testo nell'area di rendering, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#setUseFrameRotation) determina se la rotazione del riquadro viene applicata. Imposta [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) su `true` quando il testo deve essere renderizzato senza legature.

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

## **Controlla testo e caratteri**

### **Vettorizza tutto il testo**

Imposta [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#setVectorizeText) su `true` per scrivere tutto il testo della diapositiva come grafica vettoriale. Questo elimina le dipendenze dai font e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile o ricercabile come testo SVG.

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

### **Scegli come gestire i font esterni**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgexternalfontshandling/) per i font caricati esternamente. Scegli `AddLinksToFontFiles` per fare riferimento a file di font separati, `Embed` per includere i dati del font nell'SVG, o `Vectorize` per renderizzare solo il testo che utilizza font esterni come grafica. Verifica la licenza dei font prima di includerli.

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

Usa [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#setPicturesCompression) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) per omettere le aree di origine ritagliate e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#setJpegQuality) per controllare la qualità di codifica JPEG. Queste impostazioni riducono le dimensioni del file a scapito della fedeltà dell'immagine o dei dati immagine conservati.

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

## **Assegna ID stabili a forme e testo**

Fornisci un callback di formattazione a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#setShapeFormattingController) per impostare [SvgShape.setId](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgshape/#setId) per ogni forma SVG. Il callback può anche impostare i valori [SvgTSpan.setId](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgtspan/#setId) sugli elementi `tspan` del testo.

PhpJavaBridge non può invocare un callback PHP da `writeAsSvg` quando viene eseguito in modalità stream. Inserisci la logica di formattazione in una piccola classe helper Java, compilala e aggiungi il file JAR risultato al classpath del bridge. L'helper può utilizzare [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getOfficeInteropShapeId), che è stabile per la durata della forma, e un contatore ripetibile per i relativi `tspan` di testo. Vedi l'[implementazione Java di `StableSvgIdController`](/slides/it/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) per il codice helper.

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

In un callback di formattazione, chiama [SvgShape.setEventHandler](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgshape/#setEventHandler) passando un valore [SvgEvent](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgevent/) per aggiungere un gestore di eventi JavaScript a una forma esportata. Assegna il callback con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#setShapeFormattingController) e definisci la funzione JavaScript nella pagina o nel documento SVG che ospita il risultato.

Come per gli ID stabili, implementa il callback in un helper Java quando PhpJavaBridge utilizza la modalità stream. L'[implementazione Java di `SvgEventController`](/slides/it/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) assegna un ID e un gestore `OnClick` a una forma chiamata `ActionButton`. Compila quell'helper, aggiungilo al classpath del bridge come `com.example.slides.SvgEventController` e usalo da PHP come segue:

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

La pagina host può definire la funzione JavaScript a cui fa riferimento il gestore. L'assegnazione di ID e gestori di eventi consente visualizzatori di diapositive, miglioramenti di accessibilità e altri flussi di lavoro SVG interattivi.

## **FAQ**

**Quando dovrei usare [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#setVectorizeText) invece di [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgexternalfontshandling/)?**

Utilizza [SVGOptions.setVectorizeText] quando tutto il testo deve essere indipendente dai font. Utilizza [SvgExternalFontsHandling.Vectorize] quando solo il testo che utilizza font esterni deve essere convertito in grafica.

**Qual è il modo migliore per rendere un SVG più piccolo?**

Inizia comprimendo le immagini incorporate, eliminando le aree di immagine ritagliate e scegliendo file di font collegati quando l'ambiente di destinazione può servirli. Testa il risultato perché una risoluzione immagine più bassa, una qualità JPEG inferiore e il testo vettorizzato hanno ciascuno compromessi diversi tra qualità e dimensione.

**Posso modificare gli elementi SVG esportati dopo l'esportazione?**

Sì. Assegna ID tramite un callback di formattazione, quindi seleziona gli elementi SVG corrispondenti nel tuo strumento di post-elaborazione o nello script del browser.