---
title: Converti le presentazioni PowerPoint in HTML su Android
linktitle: PowerPoint in HTML
type: docs
weight: 30
url: /it/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in HTML su Android. Usa Aspose.Slides per Android via Java per esportare file PPT e PPTX, diapositive selezionate, note, font, immagini, SVG e media."
---
## **Panoramica**

Aspose.Slides per Android via Java può salvare presentazioni PowerPoint come HTML senza Microsoft PowerPoint. La conversione di base consiste in un singolo caricamento di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e una chiamata a `save` con [SaveFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/). Usa [HtmlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/htmloptions/) quando devi controllare il layout esportato, i caratteri, le immagini, le note, i commenti, l'output SVG o le risorse collegate.

Questa guida si concentra su scenari pratici di esportazione HTML:

- Esportare un'intera presentazione o diapositive selezionate.
- Generare HTML a layout fisso, responsivo o basato su SVG.
- Includere note del relatore e commenti.
- Controllare la qualità delle immagini e i dati delle immagini ritagliate.
- Incorporare i caratteri o salvare i file dei caratteri separatamente.
- Scegliere come le risorse esterne e i file multimediali vengono scritti e referenziati.

Per impostazione predefinita, l'esportazione HTML produce un documento HTML auto‑contenuto dove la maggior parte delle risorse è incorporata. Questo è comodo per condividere un unico file, ma può aumentare le dimensioni dell'output. Per la pubblicazione web, considera risorse esterne, DPI immagine più bassi e includi solo i caratteri che non sono sicuramente disponibili nell'ambiente di destinazione.

## **Convertire una presentazione in HTML**

Per esportare una presentazione in HTML, caricala con [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e salvala con [SaveFormat.Html](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Questo esempio scrive un unico file HTML. L'oggetto presentazione viene eliminato nel blocco `finally`, che rilascia i handle dei file e le risorse di rendering dopo l'esportazione.

## **Usare HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/htmloptions/) è la classe di configurazione principale per l'esportazione HTML. Le impostazioni comuni includono:

- `SlidesLayoutOptions`: aggiunge note, commenti, dispense o altre informazioni di layout.
- `HtmlFormatter`: modifica la struttura del documento HTML o delega la formattazione a un controller.
- `SlideImageFormat`: modifica il modo in cui le diapositive sono rappresentate, ad esempio come SVG.
- `PicturesCompression`: controlla DPI dell'immagine e dimensione dell'output.
- `DeletePicturesCroppedAreas`: mantiene o rimuove i dati dell'immagine ritagliata.
- `SvgResponsiveLayout`: fa sì che il contenuto SVG esportato si adatti al contenitore.
- `ShowHiddenSlides`: include le diapositive nascoste quando necessario.

Le sezioni seguenti mostrano le opzioni più comuni separatamente, così puoi combinare solo quelle di cui il tuo flusso di lavoro ha bisogno.

## **Convertire diapositive selezionate in HTML**

Il sovraccarico `Presentation.save` che accetta numeri di diapositiva usa posizioni basate su 1. Il ciclo sotto salva ogni diapositiva in un file HTML separato.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Usa questo modello quando un sito web o un'applicazione necessita una pagina HTML per diapositiva. Se ogni diapositiva deve avere lo stesso layout, crea una sola istanza di [HtmlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/htmloptions/) e passala a ciascuna chiamata `save`.

## **Creare HTML responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/responsivehtmlcontroller/) fornisce output HTML responsivo tramite [HtmlFormatter](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/htmlformatter/). Usalo quando la pagina esportata deve adattarsi meglio alla larghezza del browser.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Per layout responsivo basato su SVG, imposta `SvgResponsiveLayout` su [HtmlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/htmloptions/). Questo è utile quando il contenuto della diapositiva è esportato come markup SVG scalabile.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Includere note del relatore e commenti**

Usa [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/notescommentslayoutingoptions/) tramite `HtmlOptions.SlidesLayoutOptions` per includere le note del relatore o i commenti. Note e commenti sono nascosti per impostazione predefinita a meno che non ne specifichi le posizioni.

Supponiamo che la presentazione di origine contenga note del relatore:

![Diapositiva con note del relatore in PowerPoint](slide_with_notes.png)

Il codice seguente esporta il contenuto della diapositiva con le note del relatore sotto la diapositiva.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

L'HTML esportato include l'area delle note:

![Output HTML con la diapositiva e le note del relatore](HTML_with_notes.png)

Per esportare i commenti, imposta `CommentsPosition`, ad esempio su `CommentsPositions.Right` o `CommentsPositions.Bottom`. Se ti servono solo i commenti, ometti `NotesPosition`. Se ti servono sia note sia commenti, imposta entrambe le proprietà.

## **Controllare la qualità dell'immagine e le aree ritagliate**

L'esportazione HTML può comprimere le immagini delle diapositive per ridurre le dimensioni dell'output. Imposta `PicturesCompression` su un valore da [PicturesCompression](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/picturescompression/) quando hai bisogno di una qualità dell'immagine più alta.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Per impostazione predefinita, le aree ritagliate delle immagini possono essere rimosse dall'output esportato. Mantieni i dati ritagliati solo quando gli utenti devono poter recuperarli o ispezionarli. Conservare questi dati può aumentare le dimensioni dell'HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Aggiungere CSS**

Per una stilizzazione semplice, passa una stringa CSS a `HtmlFormatter.createDocumentFormatter`. Questo modifica il documento HTML circostante mentre Aspose.Slides continua a renderizzare il contenuto della diapositiva.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Per un'intestazione di documento personalizzata, un file CSS collegato o markup personalizzato attorno a diapositive e forme, implementa [IHtmlFormattingController](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihtmlformattingcontroller/) e passalo a [HtmlFormatter](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/htmlformatter/) con `createCustomFormatter`.

## **Incorporare i caratteri**

Se l'ambiente di destinazione potrebbe non avere i caratteri della presentazione installati, incorpora i caratteri nell'HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). L'incorporazione migliora la fedeltà visiva ma aumenta le dimensioni dell'output.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Escludi i caratteri solo quando sei certo che i browser o i sistemi di destinazione li forniscano già. Per i caratteri del brand o caratteri meno comuni, l'incorporazione è generalmente più sicura.

## **Collegare i file dei caratteri invece di incorporarli**

Per ridurre le dimensioni del file HTML, puoi scrivere i dati dei caratteri in file WOFF separati e aggiungere regole `@font-face` all'HTML. L'aiutante qui sotto estende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) e sovrascrive `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

In questo esempio, i file dei caratteri vengono salvati in `html-output/fonts`, e l'HTML li riferisce con URL come `fonts/BrandFont-normal-400.woff`. Se il file HTML e i caratteri vengono distribuiti in un'altra posizione, scegli `fontUrlPrefix` in modo che corrisponda al percorso URL distribuito.

## **Salvare le risorse esternamente**

HTML auto‑contenuto è facile da spostare, ma le risorse Base64 incorporate possono rendere il file voluminoso. Se la tua applicazione necessita file immagine esterni, implementa [ILinkEmbedController](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilinkembedcontroller/) e passalo al costruttore di [HtmlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/htmloptions/).

Quando esternalizzi le risorse, scegli due percorsi in modo deliberato:

- Il percorso di output del file system, dove la tua applicazione scrive le immagini, i caratteri, l'audio o il video generati.
- Il percorso URL, che è quello utilizzato dal browser dal documento HTML per caricare quei file.

## **Esportare file multimediali**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) esporta file video e audio e scrive HTML che può riprodurli in un browser. Il suo costruttore accetta:

- `path`: la directory in cui verranno scritti i file multimediali generati.
- `fileName`: il nome del file HTML in fase di generazione.
- `baseUri`: il prefisso URI assoluto usato nei collegamenti HTML ai file multimediali.

Se il file HTML è `html-output/presentation.html` e i file multimediali sono salvati in `html-output/media`, `path` deve puntare alla directory multimediale sul disco, mentre `baseUri` deve puntare alla stessa directory dal punto di vista del browser. Per l'anteprima locale, puoi costruire un URI `file:///` dalla directory multimediale. Per un'applicazione distribuita, usa l'URL assoluto della directory multimediale pubblicata.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Utilizza directory di output uniche per ogni lavoro di esportazione, specialmente in applicazioni server. Percorsi di output condivisi possono provocare la sovrascrittura di file provenienti da conversioni diverse.

## **Prestazioni e gestione delle risorse**

La conversione HTML è un'operazione di rendering, quindi i tempi di elaborazione e l'uso della memoria dipendono dal numero di diapositive, dalla risoluzione delle immagini, dai caratteri, dagli effetti, dai grafici e dai media incorporati. Valori DPI più alti per `PicturesCompression`, caratteri incorporati, output SVG e aree immagini ritagliate mantenute possono migliorare la fedeltà ma solitamente aumentano le dimensioni dell'output.

Per conversione batch:

- Elimina tempestivamente ogni istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
- Usa directory di output separate per lavori separati.
- Evita di incorporare i caratteri comuni a meno che la fedeltà non lo richieda.
- Abbassa DPI delle immagini quando l'HTML è destinato a preview o miniature.
- Mantieni la presentazione di origine, l'HTML generato e le risorse esterne insieme finché i percorsi di distribuzione non sono definitivi.

## **FAQ**

**I collegamenti ipertestuali vengono mantenuti nell'output HTML?**

Sì. I collegamenti ipertestuali della presentazione sono esportati in HTML e rimangono cliccabili quando l'URL di destinazione è valido.

**Posso convertire presentazioni in HTML in parallelo?**

Sì, ma non condividere una singola istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) tra thread. Processa file diversi con istanze di presentazione separate, stream separati e directory di output separate. Vedi le [linee guida sul multithreading](/slides/it/androidjava/multithreading/) per i dettagli.

**Un oggetto Presentation è thread‑safe?**

No. Un'unica istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) dovrebbe essere caricata, modificata, salvata ed eliminata su un solo thread. Per lavoro parallelo, crea un'istanza indipendente per thread o processo.

**Perché il file HTML generato è grande?**

L'esportazione predefinita può incorporare risorse direttamente nell'HTML. Caratteri incorporati, immagini ad alta DPI, media, contenuto SVG e aree immagini ritagliate mantenute aumentano anche le dimensioni. Usa risorse esterne, escludi i caratteri comuni dall'incorporazione e abbassa `PicturesCompression` quando una dimensione più piccola è più importante della massima fedeltà.

**Perché una dimensione del carattere in PowerPoint come 24 pt appare come 17,999819 pt in HTML?**

Ciò può accadere perché PowerPoint e HTML usano modelli DPI diversi. PowerPoint memorizza le dimensioni del testo in punti tipografici basati su 72 DPI, mentre il layout HTML è basato sui pixel CSS in un modello a 96 DPI. Quando Aspose.Slides esporta una presentazione in HTML, la dimensione del carattere viene tradotta tra questi sistemi, e la conversione può introdurre piccole differenze di arrotondamento.

Questi valori non indicano un reale cambiamento visuale della dimensione del carattere. Sono solo un effetto collaterale matematico della conversione delle metriche di testo tra PowerPoint e HTML.

**Come devo scegliere baseUri per l'esportazione dei media?**

Scegli `baseUri` dal punto di vista del browser e passalo come URI assoluto. Per l'anteprima locale, puoi derivarlo dalla directory di output con `mediaDirectory.toUri().toString()`. Per la distribuzione, usa l'URL assoluto della directory multimediale pubblicata. Il percorso file system `path` e il `baseUri` del browser non devono essere la stessa stringa, ma devono descrivere la stessa posizione della risorsa.

**Posso includere diapositive nascoste?**

Sì. Imposta `ShowHiddenSlides` su `true` su [HtmlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/htmloptions/) quando le diapositive nascoste devono essere esportate.