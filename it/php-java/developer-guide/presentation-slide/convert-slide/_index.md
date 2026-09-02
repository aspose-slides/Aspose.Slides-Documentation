---
title: Converti le diapositive di presentazione in immagini in PHP
linktitle: Diapositiva in immagine
type: docs
weight: 35
url: /it/php-java/convert-slide/
keywords:
- converti diapositiva
- esporta diapositiva
- diapositiva in immagine
- salva diapositiva come immagine
- diapositiva in EMF
- diapositiva in PNG
- diapositiva in JPEG
- diapositiva in bitmap
- diapositiva in TIFF
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Converti le diapositive da presentazioni PPT, PPTX e ODP in PNG, JPEG, GIF, TIFF, EMF e altri formati immagine in PHP con Aspose.Slides."
---
## **Introduzione**

Aspose.Slides for PHP via Java può renderizzare diapositive individuali da presentazioni PowerPoint e OpenDocument come PNG, JPEG, GIF, TIFF e altri formati immagine.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Seleziona la diapositiva che desideri renderizzare.
3. Se necessario, configura il rendering con la classe [RenderingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/).
4. Chiama il metodo [Slide::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage). Restituisce un oggetto [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/).
5. Chiama il metodo [IImage::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/#save) e specifica il formato di output con un valore [ImageFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/imageformat/).

## **Convertire una diapositiva in immagine PNG**

La conversione più semplice utilizza le impostazioni di rendering predefinite. L'oggetto [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) risultante può essere elaborato in memoria o salvato su file.

Il seguente esempio PHP renderizza la prima diapositiva e la salva come immagine PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Convertire diapositive in immagini con dimensioni personalizzate**

Utilizza la sovraccarico [Slide::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage) che accetta un valore [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) per renderizzare una diapositiva con dimensioni pixel esatte.

Il seguente esempio crea un'immagine JPEG 1820 × 1040:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Convertire diapositive con note e commenti in immagini**

Per impostazione predefinita, le immagini delle diapositive non includono note o commenti. Passa un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/notescommentslayoutingoptions/) al metodo [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) per controllare dove appaiono note e commenti.

Il seguente esempio posiziona note troncate sotto la diapositiva e commenti a destra:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Per la conversione diapositive‑immagine, non passare [BottomFull](https://reference.aspose.com/slides/it/php-java/aspose.slides/notespositions/) al metodo [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/it/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Le note possono contenere più testo di quanto la dimensione fissa dell'immagine possa contenere. Usa invece [BottomTruncated](https://reference.aspose.com/slides/it/php-java/aspose.slides/notespositions/).
{{% /alert %}}

## **Convertire diapositive in immagini usando le opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/) consente di controllare le dimensioni, la risoluzione e altre proprietà dell'immagine TIFF renderizzata.

Il seguente esempio renderizza la prima diapositiva come immagine TIFF 2160 × 2880 a 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Il supporto TIFF non è garantito nelle versioni Java precedenti a JDK 9.
{{% /alert %}}

## **Convertire tutte le diapositive in immagini**

Itera attraverso la collezione di diapositive per convertire l'intera presentazione in una serie di immagini. Le diapositive nascoste sono incluse a meno che non vengano saltate esplicitamente.

Il seguente esempio renderizza ogni diapositiva come immagine JPEG con fattori di scala orizzontale e verticale pari a 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Creare output Metafile avanzato**

Enhanced Metafile (EMF) è utile quando è necessario scambiare grafica vettoriale con Microsoft Office o altre applicazioni Windows che supportano i metafile Windows. A differenza di un'immagine basata su pixel, un EMF può conservare le operazioni di disegno vettoriale che si scalano senza la stessa perdita di nitidezza. Tuttavia, EMF è principalmente un formato di compatibilità per le applicazioni con supporto ai metafile Windows, non un formato di scambio universale. Inoltre, contenuti di diapositiva complessi, come immagini bitmap e alcuni effetti, possono essere memorizzati come elementi rasterizzati all'interno del contenitore metafile vettoriale.

### **Esportare una diapositiva in EMF**

Il metodo [Slide::writeAsEmf](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#writeAsEmf) scrive una diapositiva in un flusso di destinazione in formato EMF. Il seguente esempio carica una presentazione, seleziona la prima diapositiva e la scrive in un flusso di file EMF:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Il chiamante possiede il flusso passato a [Slide::writeAsEmf](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#writeAsEmf) ed è responsabile della sua chiusura, come mostrato sopra.

### **Convertire un'immagine SVG in EMF e aggiungerla a una presentazione**

Usa [SvgImage::writeAsEmf](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/#writeAsEmf) per convertire contenuto SVG in EMF. I byte risultanti possono essere aggiunti alla presentazione tramite [ImageCollection::addImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/#addImage) e posizionati su una diapositiva con [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addPictureFrame).

Il seguente esempio crea un [SvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/) dal markup SVG, lo converte in un EMF in memoria, inserisce il metafile nella prima diapositiva e salva la presentazione:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgimage/#writeAsEmf) non prende possesso del flusso di destinazione. Un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) memorizza tutti i dati generati in memoria, quindi non è necessario ripristinare la posizione prima di chiamare `toByteArray`. L'array di byte restituito rimane valido dopo la chiusura del flusso.

La generazione di EMF è disponibile sui sistemi operativi supportati dalla configurazione selezionata di Aspose.Slides for PHP via Java e JDK, ma il rendering può differire tra piattaforme quando i font o le dipendenze grafiche non sono disponibili. Installa i font usati dal contenuto sorgente o configura sostituzioni adeguate, segui i [requisiti della piattaforma](/slides/it/php-java/system-requirements/) per Aspose.Slides for PHP via Java e convalida il risultato nell'applicazione destinataria di EMF. Le applicazioni Linux e macOS spesso hanno supporto limitato o incoerente per la visualizzazione e la modifica dei metafile Windows.

## **Rendering di Emoji a Colori**

{{% alert title="Note" color="info" %}}
Per renderizzare correttamente gli emoji a colori durante la conversione delle diapositive di una presentazione in immagini, i font degli emoji usati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione utilizza **Segue UI Emoji** e questo font è assente, gli emoji potrebbero apparire in monocromatico nelle immagini generate.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No. Il metodo [Slide::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage) renderizza un'immagine statica della diapositiva e non esporta le animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì. Le diapositive nascoste possono essere renderizzate come le diapositive normali. Includile nel ciclo di elaborazione, come mostrato nell'esempio sopra.

**Ombre e altri effetti vengono preservati nelle immagini delle diapositive?**

Sì. Aspose.Slides renderizza ombre, trasparenza e altri effetti grafici supportati nelle immagini delle diapositive.