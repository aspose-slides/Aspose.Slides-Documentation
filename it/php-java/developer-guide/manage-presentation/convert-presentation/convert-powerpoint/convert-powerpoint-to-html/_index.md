---
title: Converti presentazioni PowerPoint in HTML con PHP
linktitle: PowerPoint in HTML
type: docs
weight: 30
url: /it/php-java/convert-powerpoint-to-html/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in HTML
- presentazione in HTML
- diapositiva in HTML
- PPT in HTML
- PPTX in HTML
- salva PowerPoint come HTML
- salva presentazione come HTML
- salva diapositiva come HTML
- salva PPT come HTML
- salva PPTX come HTML
- esporta PPT in HTML
- esporta PPTX in HTML
- PHP
- Aspose.Slides
description: "Converti presentazioni PowerPoint in HTML con PHP. Usa Aspose.Slides per esportare file PPT e PPTX, diapositive selezionate, note, caratteri, immagini, SVG e contenuti multimediali."
---
## **Panoramica**

Aspose.Slides per PHP tramite Java può salvare presentazioni PowerPoint come HTML senza Microsoft PowerPoint. La conversione di base consiste in un unico caricamento di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e in una chiamata `save` con [SaveFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/). Usa [HtmlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmloptions/) quando devi controllare il layout esportato, i caratteri, le immagini, le note, i commenti, l'output SVG o le risorse collegate.

Questa guida si concentra su scenari pratici di esportazione HTML:

- Esporta un'intera presentazione o diapositive selezionate.
- Genera HTML a layout fisso, responsivo o basato su SVG.
- Includi note del presentatore e commenti.
- Controlla la qualità delle immagini e i dati delle aree ritagliate.
- Incorpora caratteri o salva i file dei caratteri separatamente.
- Scegli come le risorse esterne e i file multimediali vengono scritti e referenziati.

Per impostazione predefinita, l'esportazione HTML produce un documento HTML autonomo in cui la maggior parte delle risorse è incorporata. Questo è comodo per condividere un unico file, ma può aumentare le dimensioni dell'output. Per la pubblicazione web, considera risorse esterne, DPI immagine più bassi e l'incorporamento solo dei caratteri che non sono affidabilmente disponibili nell'ambiente di destinazione.

## **Convertire una presentazione in HTML**

Per esportare una presentazione in HTML, caricala con [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e salvala con [SaveFormat.Html](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Questo esempio scrive un file HTML. L'oggetto presentazione viene eliminato nel blocco `finally`, il che rilascia i handle di file e le risorse di rendering dopo l'esportazione.

## **Utilizzare HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmloptions/) è la classe di configurazione principale per l'esportazione HTML. Le impostazioni comuni includono:

- `SlidesLayoutOptions`: aggiunge note, commenti, dispense o altre informazioni di layout.
- `HtmlFormatter`: modifica la struttura del documento HTML o delega la formattazione a un controller.
- `SlideImageFormat`: cambia il modo in cui le diapositive sono rappresentate, ad esempio come SVG.
- `PicturesCompression`: controlla i DPI dell'immagine e le dimensioni dell'output.
- `DeletePicturesCroppedAreas`: mantiene o rimuove i dati delle immagini ritagliate.
- `SvgResponsiveLayout`: fa sì che il contenuto SVG esportato si adatti al suo contenitore.
- `ShowHiddenSlides`: include le diapositive nascoste quando richiesto.

Le sezioni seguenti mostrano le opzioni più comuni separatamente, così puoi combinare solo quelle necessarie al tuo flusso di lavoro.

## **Convertire diapositive selezionate in HTML**

La sovraccarico `save` che accetta numeri di diapositiva utilizza posizioni basate su indice 1. Il ciclo seguente salva ogni diapositiva in un file HTML separato.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Usa questo schema quando un sito web o un'applicazione richiede una pagina HTML per diapositiva. Se ogni diapositiva deve avere lo stesso layout, crea un'istanza di [HtmlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmloptions/) e passala a ogni chiamata `save`.

## **Creare HTML responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/it/php-java/aspose.slides/responsivehtmlcontroller/) fornisce output HTML responsivo tramite [HtmlFormatter](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmlformatter/). Usalo quando la pagina esportata deve adattarsi meglio alla larghezza del browser.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Per un layout responsivo basato su SVG, imposta `SvgResponsiveLayout` su [HtmlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmloptions/). Questo è utile quando il contenuto della diapositiva è esportato come markup SVG scalabile.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Includere note del presentatore e commenti**

Usa [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/notescommentslayoutingoptions/) tramite `HtmlOptions.SlidesLayoutOptions` per includere note del presentatore o commenti. Note e commenti sono nascosti per impostazione predefinita, a meno che non ne scegli le posizioni.

Supponi che la presentazione di origine contenga note del presentatore:

![Diapositiva con note del presentatore in PowerPoint](slide_with_notes.png)

Il codice seguente esporta il contenuto della diapositiva con le note del presentatore sotto la diapositiva.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

L'HTML esportato include l'area delle note:

![Output HTML con la diapositiva e le note del presentatore](HTML_with_notes.png)

Per esportare i commenti, imposta `CommentsPosition`, ad esempio su `CommentsPositions.Right` o `CommentsPositions.Bottom`. Se ti servono solo i commenti, ometti `NotesPosition`. Se ti servono sia le note sia i commenti, imposta entrambe le proprietà.

## **Controllare la qualità dell'immagine e le aree ritagliate**

L'esportazione HTML può comprimere le immagini delle diapositive per ridurre le dimensioni dell'output. Imposta `PicturesCompression` su un valore da [PicturesCompression](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturescompression/) quando hai bisogno di una qualità dell'immagine più alta.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Per impostazione predefinita, le aree ritagliate delle immagini possono essere rimosse dall'output esportato. Mantieni i dati ritagliati solo quando gli utenti devono poter recuperare o ispezionare quelle parti nascoste dell'immagine. Mantenerli può aumentare le dimensioni dell'HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Aggiungere CSS**

Per uno stile semplice, passa una stringa CSS a [HtmlFormatter](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmlformatter/) tramite `createDocumentFormatter`. Questo modifica il documento HTML circostante mentre Aspose.Slides continua a renderizzare il contenuto della diapositiva.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Per un'intestazione documento personalizzata, un file CSS collegato o markup personalizzato intorno a diapositive e forme, usa un controller di formattazione personalizzato e passalo a [HtmlFormatter](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmlformatter/) con `createCustomFormatter`.

## **Incorporare i caratteri**

Se l'ambiente di destinazione potrebbe non avere installati i caratteri della presentazione, incorpora i caratteri nell'HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/php-java/aspose.slides/embedallfontshtmlcontroller/). L'incorporamento migliora la fedeltà visiva ma aumenta le dimensioni dell'output.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Escludi i caratteri solo quando sei certo che i browser o i sistemi di destinazione li forniscano già. Per caratteri di brand o meno comuni, l'incorporamento è solitamente più sicuro.

## **Collegare i file dei caratteri invece di incorporarli**

Per ridurre le dimensioni del file HTML, puoi scrivere i dati dei caratteri in file WOFF separati e aggiungere regole `@font-face` all'HTML. In PHP tramite Java, questo scenario è solitamente implementato con una piccola classe di helper Java che estende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/php-java/aspose.slides/embedallfontshtmlcontroller/), scrive i byte dei caratteri in una directory di output e inietta regole `@font-face` nell'HTML generato. Compila quell'helper, aggiungilo al classpath del PHP Java Bridge e poi istanzialo da PHP con `new Java(...)`.

Quando costruisci tale helper, scegli due percorsi in modo deliberato:

- Il percorso di output del file system, dove vengono scritti i file dei caratteri generati.
- Il percorso URL, che è quello che il browser utilizza dal documento HTML per caricare tali file dei caratteri.

## **Salvare le risorse esternamente**

L'HTML autonomo è facile da spostare, ma le risorse Base64 incorporate possono rendere il file grande. Se la tua applicazione ha bisogno di file immagine esterni, fornisci un controller di collegamento/incorporamento personalizzato al costruttore di [HtmlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmloptions/).

Quando esternalizzi le risorse, scegli due percorsi in modo deliberato:

- Il percorso di output del file system, dove la tua applicazione scrive le immagini, i caratteri, l'audio o il video generati.
- Il percorso URL, che è quello che il browser utilizza dal documento HTML per caricare tali file.

Mantieni questi percorsi coerenti con il layout di distribuzione in modo che l'HTML generato possa caricare le risorse esterne dopo essere stato spostato su un server web o in un'altra directory.

## **Esportare file multimediali**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoplayerhtmlcontroller/) esporta file video e audio e scrive HTML che può riprodurli in un browser. Il suo costruttore accetta:

- `path`: la directory di output usata dall'HTML generato e dai file multimediali.
- `fileName`: il nome del file HTML in fase di generazione.
- `baseUri`: il prefisso URI assoluto usato nei collegamenti HTML ai file multimediali.

Se il file HTML è `html-output/presentation.html`, `path` dovrebbe puntare a `html-output`, e `baseUri` dovrebbe puntare alla stessa directory dal punto di vista del browser. Per l'anteprima locale, puoi costruire un URI `file:///` dalla directory di output. Per un'applicazione distribuita, usa l'URL assoluto della directory di output pubblicata.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Usa directory di output uniche per ogni lavoro di esportazione, soprattutto nelle applicazioni server. Percorsi di output condivisi possono causare la sovrascrittura di file provenienti da conversioni diverse.

## **Prestazioni e gestione delle risorse**

La conversione HTML è un'operazione di rendering, quindi i tempi di elaborazione e l'uso della memoria dipendono dal numero di diapositive, dalla risoluzione delle immagini, dai caratteri, dagli effetti, dai grafici e dai media incorporati. Valori DPI più alti di `PicturesCompression`, caratteri incorporati, output SVG e aree immagini ritagliate mantenute possono migliorare la fedeltà ma solitamente aumentano le dimensioni dell'output.

Per la conversione batch:

- Elimina prontamente ogni istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
- Usa directory di output separate per lavori separati.
- Evita di incorporare caratteri comuni a meno che la fedeltà non lo richieda.
- Riduci i DPI delle immagini quando l'HTML è destinato a anteprime o miniature.
- Mantieni insieme la presentazione di origine, l'HTML generato e le risorse esterne fino a quando i percorsi di distribuzione non siano definitivi.

## **FAQ**

**I collegamenti ipertestuali sono conservati nell'output HTML?**

Sì. I collegamenti ipertestuali della presentazione vengono esportati in HTML e rimangono cliccabili quando l'URL di destinazione è valido.

**Posso convertire presentazioni in HTML in parallelo?**

Sì, ma non condividere una sola istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) tra thread. Elabora file diversi con istanze di presentazione separate, flussi separati e directory di output separate.

**L'oggetto Presentation è thread-safe?**

No. Una singola istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) dovrebbe essere caricata, modificata, salvata ed eliminata su un unico thread. Per lavori paralleli, crea un'istanza indipendente per thread o processo.

**Perché il file HTML generato è grande?**

L'esportazione predefinita può incorporare risorse direttamente nell'HTML. Caratteri incorporati, immagini ad alta DPI, media, contenuto SVG e aree immagini ritagliate mantenute aumentano le dimensioni. Usa risorse esterne, escludi i caratteri comuni dall'incorporamento e riduci `PicturesCompression` quando è più importante un output più piccolo che la massima fedeltà.

**Perché una dimensione carattere di PowerPoint come 24 pt appare come 17.999819 pt in HTML?**

Questo può accadere perché PowerPoint e HTML usano modelli DPI diversi. PowerPoint memorizza le dimensioni del testo in punti tipografici basati su 72 DPI, mentre il layout HTML è basato su pixel CSS in un modello a 96 DPI. Quando Aspose.Slides esporta una presentazione in HTML, la dimensione del carattere viene tradotta tra questi sistemi e la conversione può introdurre piccole differenze di arrotondamento.

Questi valori non indicano una reale variazione visiva della dimensione del carattere. Sono solo un effetto collaterale matematico della conversione delle metriche del testo da PowerPoint a HTML.

**Come devo scegliere baseUri per l'esportazione dei media?**

Scegli `baseUri` dal punto di vista del browser e passalo come URI assoluto. Per l'anteprima locale, puoi derivarlo dalla directory di output con un URI file Java. Per la distribuzione, usa l'URL assoluto della directory multimediale pubblicata. Il percorso di file system `path` e il `baseUri` del browser non devono essere la stessa stringa, ma devono descrivere la stessa posizione della risorsa.

**Posso includere diapositive nascoste?**

Sì. Imposta `ShowHiddenSlides` su `true` su [HtmlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmloptions/) quando le diapositive nascoste devono essere esportate.