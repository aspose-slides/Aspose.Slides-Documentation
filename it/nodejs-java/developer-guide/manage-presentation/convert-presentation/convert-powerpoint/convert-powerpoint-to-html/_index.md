---
title: Converti le presentazioni PowerPoint in HTML con Node.js
linktitle: PowerPoint in HTML
type: docs
weight: 30
url: /it/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in HTML con Node.js. Utilizza Aspose.Slides per Node.js tramite Java per esportare file PPT e PPTX, diapositive selezionate, note, font, immagini, SVG e media."
---
## **Panoramica**

Aspose.Slides per Node.js tramite Java può salvare le presentazioni PowerPoint come HTML senza Microsoft PowerPoint. La conversione di base consiste in un singolo caricamento di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e una chiamata `save` con [SaveFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/). Usa [HtmlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmloptions/) quando è necessario controllare il layout esportato, i caratteri, le immagini, le note, i commenti, l'output SVG o le risorse collegate.

Questa guida si concentra su scenari pratici di esportazione HTML:

- Esporta un'intera presentazione o diapositive selezionate.
- Genera HTML a layout fisso, responsive o basato su SVG.
- Includi note del relatore e commenti.
- Controlla la qualità dell'immagine e i dati delle aree ritagliate.
- Incorpora i font o salva i file dei font separatamente.
- Scegli come le risorse esterne e i file multimediali vengono scritti e referenziati.

Di default, l'esportazione HTML produce un documento HTML autonomo in cui la maggior parte delle risorse è incorporata. Questo è comodo per condividere un unico file, ma può aumentare le dimensioni dell'output. Per la pubblicazione web, considera risorse esterne, DPI immagine più bassi e l'incorporazione solo dei font che non sono affidabilmente disponibili nell'ambiente di destinazione.

## **Converti una Presentazione in HTML**

Per esportare una presentazione in HTML, caricala con [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e salvala con [SaveFormat.Html](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Questo esempio scrive un file HTML. L'oggetto presentazione viene eliminato nel blocco `finally`, che rilascia i handle dei file e le risorse di rendering dopo l'esportazione.

## **Utilizza HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmloptions/) è la classe di configurazione principale per l'esportazione HTML. Le impostazioni comuni includono:

- `SlidesLayoutOptions`: aggiunge note, commenti, dispense o altre informazioni di layout.
- `HtmlFormatter`: modifica la struttura del documento HTML o delega la formattazione a un controller.
- `SlideImageFormat`: cambia il modo in cui le diapositive sono rappresentate, ad esempio come SVG.
- `PicturesCompression`: controlla DPI dell'immagine e dimensione dell'output.
- `DeletePicturesCroppedAreas`: mantiene o rimuove i dati delle immagini ritagliate.
- `SvgResponsiveLayout`: fa sì che il contenuto SVG esportato si adatti al contenitore.
- `ShowHiddenSlides`: include le diapositive nascoste quando necessario.

Le sezioni seguenti mostrano le opzioni più comuni separatamente così puoi combinare solo quelle necessarie al tuo flusso di lavoro.

## **Converti Diapositive Selezionate in HTML**

Il sovraccarico `Presentation.save` che accetta i numeri delle diapositive utilizza posizioni basate su indice 1. Il ciclo sotto salva ogni diapositiva in un file HTML separato.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Usa questo modello quando un sito web o un'applicazione necessitano di una pagina HTML per diapositiva. Se ogni diapositiva deve avere lo stesso layout, crea un'istanza di [HtmlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmloptions/) e passala a ogni chiamata `save`.

## **Crea HTML Responsive**

[ResponsiveHtmlController](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/responsivehtmlcontroller/) fornisce output HTML responsive tramite [HtmlFormatter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmlformatter/). Usalo quando la pagina esportata deve adattarsi meglio alla larghezza del browser.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Per un layout responsive basato su SVG, imposta `SvgResponsiveLayout` su [HtmlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmloptions/). Questo è utile quando il contenuto della diapositiva è esportato come markup SVG scalabile.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Includi Note del Relatore e Commenti**

Usa [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notescommentslayoutingoptions/) tramite `HtmlOptions.setSlidesLayoutOptions` per includere note del relatore o commenti. Note e commenti sono nascosti per impostazione predefinita a meno che non ne scegli le posizioni.

Supponi che la presentazione sorgente contenga note del relatore:

![Diapositiva con note del relatore in PowerPoint](slide_with_notes.png)

Il codice seguente esporta il contenuto della diapositiva con le note del relatore sotto la diapositiva.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

L'HTML esportato include l'area delle note:

![Output HTML con la diapositiva e le note del relatore](HTML_with_notes.png)

Per esportare i commenti, imposta `CommentsPosition`, ad esempio su `CommentsPositions.Right` o `CommentsPositions.Bottom`. Se ti servono solo i commenti, ometti `NotesPosition`. Se ti servono sia note sia commenti, imposta entrambe le proprietà.

## **Controlla Qualità Immagine e Aree Ritagliate**

L'esportazione HTML può comprimere le immagini delle diapositive per ridurre le dimensioni dell'output. Imposta `PicturesCompression` a un valore da [PicturesCompression](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturescompression/) quando hai bisogno di una qualità immagine più alta.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Di default, le aree ritagliate delle immagini possono essere rimosse dall'output esportato. Mantieni i dati ritagliati solo quando gli utenti devono poter recuperarli o ispezionarli. Conservare questi dati può aumentare la dimensione dell'HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Aggiungi CSS**

Per una stilizzazione semplice, passa una stringa CSS a `HtmlFormatter.createDocumentFormatter`. Questo modifica il documento HTML circostante mentre Aspose.Slides continua a renderizzare il contenuto della diapositiva.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Per un'intestazione di documento personalizzata, un file CSS collegato o markup personalizzato attorno a diapositive e forme, utilizza [HtmlFormatter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmlformatter/) con un controller di formattazione.

## **Incorpora Font**

Se l'ambiente di destinazione potrebbe non avere i font della presentazione installati, incorpora i font nell'HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). L'incorporazione migliora la fedeltà visiva ma aumenta la dimensione dell'output.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Escludi i font solo quando sei sicuro che i browser o i sistemi di destinazione li forniscano già. Per font di brand o font meno comuni, l'incorporazione è solitamente più sicura.

## **Collega File Font Invece di Incorporarli**

Per ridurre la dimensione del file HTML, puoi scrivere i dati dei font in file WOFF separati e aggiungere regole `@font-face` all'HTML. In Node.js tramite Java, questo scenario è solitamente implementato con una piccola classe helper Java che estende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), scrive i byte del font in una directory di output e inietta le regole `@font-face` nell'HTML generato. Compila quell'helper, aggiungilo al classpath del modulo Node.js e poi istanzialo da JavaScript con `java.newInstanceSync`.

Quando costruisci tale helper, scegli due percorsi in modo deliberato:

- Il percorso di output del file system, dove sono scritti i file font generati.
- Il percorso URL, che è quello che il browser utilizza dal documento HTML per caricare quei file font.

## **Salva Risorse Esterne**

L'HTML autonomo è facile da spostare, ma le risorse Base64 incorporate possono rendere il file grande. Se la tua applicazione richiede file immagine, font, audio o video esterni, usa un controller di esportazione che scrive le risorse in una directory scelta e genera URL visibili dal browser. Mantieni il percorso del file system e il percorso URL allineati con il layout di distribuzione.

## **Esporta File Multimediali**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) esporta file video e audio e scrive HTML che può riprodurli in un browser. Il suo costruttore accetta:

- `path`: la directory dove saranno scritti i file multimediali generati.
- `fileName`: il nome del file HTML in generazione.
- `baseUri`: il prefisso URI assoluto usato nei collegamenti HTML ai file multimediali.

Se il file HTML è `html-output/presentation.html` e i file multimediali sono salvati in `html-output/media`, `path` deve puntare alla directory media sul disco, mentre `baseUri` deve puntare alla stessa directory dal punto di vista del browser. Per un'anteprima locale, puoi costruire un URI `file:///` dalla directory dei media. Per un'applicazione distribuita, usa l'URL assoluto della directory media pubblicata.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Usa directory di output che siano uniche per ciascun lavoro di esportazione, specialmente nelle applicazioni server. Percorsi di output condivisi possono provocare la sovrascrittura di file provenienti da conversioni diverse.

## **Prestazioni e Gestione delle Risorse**

La conversione HTML è un'operazione di rendering, quindi il tempo di elaborazione e l'uso della memoria dipendono dal numero di diapositive, dalla risoluzione delle immagini, dai font, dagli effetti, dai grafici e dai media incorporati. Valori DPI più alti per `PicturesCompression`, font incorporati, output SVG e aree ritagliate mantenute possono migliorare la fedeltà ma solitamente aumentano le dimensioni dell'output.

Per la conversione batch:

- Elimina prontamente ogni istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
- Usa directory di output separate per lavori distinti.
- Evita di incorporare font comuni a meno che la fedeltà visiva lo richieda.
- Riduci DPI dell'immagine quando l'HTML è destinato a preview o miniature.
- Mantieni la presentazione sorgente, l'HTML generato e le risorse esterne insieme fino a quando i percorsi di distribuzione non sono definitivi.

## **FAQ**

**I collegamenti ipertestuali sono preservati nell'output HTML?**

Sì. I collegamenti ipertestuali della presentazione sono esportati in HTML e rimangono cliccabili quando l'URL di destinazione è valido.

**Posso convertire presentazioni in HTML in parallelo?**

Sì, ma non condividere un'istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) tra i worker. Elabora file diversi con istanze di presentazione separate, stream separati e directory di output separate. Consulta la [guida al multithreading](/slides/it/nodejs-java/multithreading/) per i dettagli.

**È un oggetto Presentation thread-safe?**

No. Un'unica istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) dovrebbe essere caricata, modificata, salvata ed eliminata in un unico worker. Per il lavoro parallelo, crea un'istanza indipendente per ogni worker o processo.

**Perché il file HTML generato è grande?**

L'esportazione predefinita può incorporare risorse direttamente nell'HTML. Font incorporati, immagini ad alta DPI, media, contenuto SVG e aree ritagliate mantenute aumentano la dimensione. Usa risorse esterne, escludi i font comuni dall'incorporazione e riduci `PicturesCompression` quando è più importante ridurre la dimensione dell'output rispetto alla massima fedeltà.

**Perché una dimensione del font in PowerPoint come 24 pt appare come 17.999819 pt in HTML?**

Ciò può avvenire perché PowerPoint e HTML usano modelli DPI diversi. PowerPoint memorizza le dimensioni del testo in punti tipografici basati su 72 DPI, mentre il layout HTML si basa su pixel CSS in un modello a 96 DPI. Quando Aspose.Slides esporta una presentazione in HTML, la dimensione del font viene tradotta tra questi sistemi e la conversione può introdurre piccole differenze di arrotondamento.

Questi valori non indicano una reale variazione visiva della dimensione del font. Sono solo un effetto collaterale matematico della conversione delle metriche del testo tra PowerPoint e HTML.

**Come dovrei scegliere baseUri per l'esportazione dei media?**

Scegli `baseUri` dal punto di vista del browser e passalo come URI assoluto. Per un'anteprima locale, puoi derivarlo dalla directory di output con un URI `file:///`. Per la distribuzione, usa l'URL assoluto della directory media pubblicata. Il percorso di file system `path` e il `baseUri` del browser non devono essere la stessa stringa, ma devono descrivere la stessa posizione delle risorse.

**Posso includere diapositive nascoste?**

Sì. Imposta `ShowHiddenSlides` su `true` su [HtmlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmloptions/) quando le diapositive nascoste devono essere esportate.