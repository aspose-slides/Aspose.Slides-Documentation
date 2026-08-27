---
title: Converti le presentazioni PowerPoint in Markdown con JavaScript
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in MD
- presentazione in MD
- diapositiva in MD
- PPT in MD
- PPTX in MD
- salva PowerPoint come Markdown
- salva presentazione come Markdown
- salva diapositiva come Markdown
- salva PPT come MD
- salva PPTX come MD
- esporta PPT in MD
- esporta PPTX in MD
- esportazione immagine Markdown
- link immagine CDN
- PowerPoint
- presentazione
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le presentazioni PPT e PPTX in Markdown con JavaScript e controlla dove vengono salvate e referenziate le immagini bitmap, metafile e SVG esportate."
---
## **Panoramica**

Aspose.Slides per Node.js via Java può convertire presentazioni PPT e PPTX in Markdown per documentazione, siti statici, migrazione di contenuti e flussi di lavoro di controllo versione. È possibile scegliere un tipo di Markdown, controllare come viene renderizzato il contenuto delle diapositive e decidere dove vengono memorizzate le immagini esportate e come il Markdown generato le fa riferimento.

Per impostazione predefinita, l'esportazione Markdown utilizza output solo testo. Per esportare contenuti visivi, impostare il tipo di esportazione con il metodo [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/) su `Sequential` o `Visual` dall'enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` rende gli elementi della diapositiva separatamente e in ordine, mentre `Visual` mantiene gli elementi raggruppati insieme per preservare la loro relazione visiva. Il valore `TextOnly` non emette risorse immagine, quindi le callback di salvataggio immagine non vengono invocate in quella modalità.

## **Convertire una presentazione in Markdown**

Carica il file sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/), quindi chiama il metodo [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) con il valore `Md` dall'enumerazione [SaveFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Selezionare un tipo di Markdown**

Il metodo [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/) controlla la specifica Markdown usata per l'output. L'enumerazione [Flavor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/flavor/) include CommonMark, GitHub Flavored Markdown e altre varianti supportate.

Il seguente esempio esporta una presentazione in CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Esportare le immagini usando il comportamento predefinito di salvataggio locale**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/) fornisce due metodi per configurare le immagini salvate localmente:

- [setBasePath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/) specifica la directory di base per il documento Markdown e le sue risorse.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/) specifica la sotto‑directory delle immagini. Il suo valore predefinito è `Images`.

Il seguente esempio rende il contenuto visivo, scrive le immagini su `output/assets` e crea riferimenti immagine relativi nel documento Markdown:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Questo comportamento funge anche da fallback quando un handler personalizzato di salvataggio immagine restituisce `false`.

## **Personalizzare il salvataggio delle immagini e i link Markdown**

Utilizza il metodo [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/) per registrare una callback per le risorse bitmap e metafile non SVG emesse durante l'esportazione Markdown. La sua callback `MarkdownImageSavingHandler` riceve l'oggetto [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/), il suo valore [ImageFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imageformat/) e il link Markdown generato come array di stringhe a un elemento. Salva o carica l'immagine con il formato fornito e sostituisci `link[0]` con il riferimento che deve apparire nell'output Markdown.

Le risorse emesse in formato SVG vengono gestite separatamente. Registra una callback con il metodo [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/). La sua callback `MarkdownSvgImageSavingHandler` riceve un oggetto `ISvgImage` e l'array `link` a un elemento. Un SVG non ha argomento `ImageFormat`; scrivi o carica i suoi dati XML dal metodo `ISvgImage.getSvgData`. A seconda della modalità di esportazione e del raggruppamento visivo, un SVG nella presentazione di origine può essere rasterizzato o combinato con altri contenuti; la risorsa non SVG risultante viene poi passata alla callback di salvataggio immagine. Registra entrambe le callback quando ogni risorsa visiva esportata richiede un'elaborazione personalizzata.

In Node.js, crea implementazioni di queste interfacce di callback con `java.newProxy`.

Il valore di ritorno del handler determina chi elabora l'immagine:

- Restituisci `true` dopo che il handler ha salvato, caricato, trasformato o altrimenti elaborato l'immagine e ha assegnato un valore valido a `link[0]`. Aspose.Slides scrive quel valore nel documento Markdown e non esegue il salvataggio locale predefinito.
- Restituisci `false` per consentire ad Aspose.Slides di salvare l'immagine localmente e generare il suo link secondo i valori impostati da [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Importante" %}}
Un handler che restituisce `true` si assume la responsabilità dell'immagine. Se restituisce `true` senza assegnare un link valido e non vuoto, l'esportazione fallisce con un `InvalidOperationException`.
{{% /alert %}}

### **Salvare le immagini in una directory di origine CDN e usare URL esterni**

L'esempio seguente tratta `cdn-origin/presentations/quarterly-report` come una directory di origine CDN montata o sincronizzata. Ogni handler estrae il nome file generato, salva l'immagine in quella directory personalizzata e sostituisce il riferimento locale generato con un URL CDN pubblico. L'esempio stesso non effettua alcun upload di rete: l'URL diventa valido solo dopo che la directory è montata come origine CDN o i suoi file sono pubblicati sul CDN. Per lo storage di oggetti, sostituisci la scrittura su file system con l'operazione di upload dell'SDK di storage e assegna `link[0]` solo dopo che l'upload ha avuto successo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Il handler bitmap restituisce deliberatamente `false` per le immagini più piccole di 128 × 128 pixel, così Aspose.Slides salva tali immagini in `output/fallback-images` usando il comportamento predefinito. Risorse bitmap e metafile più grandi, così come le risorse SVG, sono gestite dal codice personalizzato. Per esempio, un riferimento locale generato come `fallback-images/image1.png` diventa `https://cdn.example.com/presentations/quarterly-report/image1.png`. I handler usano percorsi del sistema operativo solo quando scrivono file; i link scritti nel Markdown usano le barre oblique e i nomi file con escape URL. Applica la stessa regola quando costruisci link relativi: usa `/`, non il separatore di directory specifico della piattaforma.

## **FAQ**

**Un handler può elaborare sia immagini raster che immagini SVG?**

No. Usa [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/) per le risorse bitmap e metafile emesse e [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/) per le risorse emesse come SVG. Il primo fornisce un oggetto [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) e un valore [ImageFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imageformat/); il secondo fornisce un oggetto `ISvgImage` i cui dati SVG possono essere letti con `ISvgImage.getSvgData`. Un SVG di origine rasterizzato durante l'esportazione viene elaborato dalla callback di salvataggio immagine.

**Cosa succede quando un handler di salvataggio immagine restituisce `false`?**

Aspose.Slides utilizza il suo comportamento predefinito di salvataggio locale. La posizione dell'immagine e il riferimento generato sono controllati dai valori impostati con [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/).

**Un handler può fornire un URL senza salvare l'immagine localmente?**

Sì. Il handler può caricare l'immagine su uno storage di oggetti o passarla a un altro servizio, assegnare l'URL risultante a `link[0]` e restituire `true`. Il handler deve completare l'elaborazione da solo; restituire `true` impedisce il salvataggio locale predefinito.

**Perché l'esportazione Markdown genera un `InvalidOperationException` da parte di un handler?**

Questa eccezione si verifica quando il handler restituisce `true` ma non fornisce un link valido. Assegna il percorso relativo o l'URL esterno che deve essere scritto nel Markdown prima di restituire `true`.

**Quale separatore di percorso devono utilizzare i link alle immagini?**

Usa le barre oblique nei link Markdown e negli URL. Usa `path.join` solo per i percorsi del file system, quindi costruisci o normalizza il riferimento Markdown separatamente.

**I collegamenti ipertestuali vengono preservati durante l'esportazione Markdown?**

Sì. I [collegamenti ipertestuali](/slides/it/nodejs-java/manage-hyperlinks/) nel testo vengono preservati come link Markdown standard. Le [transizioni](/slides/it/nodejs-java/slide-transition/) e le [animazioni](/slides/it/nodejs-java/powerpoint-animation/) delle diapositive non vengono convertite.

**Le presentazioni possono essere convertite in Markdown in parallelo?**

È possibile elaborare diversi file di presentazione in parallelo, ma non condividere la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) tra thread. Segui le [linee guida per il multithreading](/slides/it/nodejs-java/multithreading/) e utilizza un'istanza separata per ogni file.