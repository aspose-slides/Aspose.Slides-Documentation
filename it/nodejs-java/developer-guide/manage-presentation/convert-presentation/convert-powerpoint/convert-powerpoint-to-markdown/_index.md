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
- PowerPoint
- presentazione
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le diapositive PowerPoint in JavaScript - PPT, PPTX - in Markdown pulito con Aspose.Slides per Node.js via Java, automatizza la documentazione e mantieni la formattazione."
---
## **Introduzione**

Aspose.Slides consente di convertire le presentazioni PowerPoint in Markdown, il che può essere utile per flussi di lavoro di documentazione, generazione di siti statici, migrazione di contenuti e pubblicazione di testo versionata. L'API supporta l'esportazione diretta da presentazioni PPT e PPTX a file MD e fornisce opzioni aggiuntive per controllare come il contenuto delle diapositive viene rappresentato nel documento Markdown risultante.

È possibile esportare le presentazioni come Markdown semplice, scegliere tra più varianti di Markdown come CommonMark e GitHub Flavored Markdown, e configurare come le immagini vengono gestite durante l'esportazione. Per le presentazioni che contengono contenuti visivi, Aspose.Slides consente anche di salvare le immagini in una cartella separata e di fare riferimento ad esse dal file Markdown generato.

{{% alert color="warning" %}} 
L'esportazione da PowerPoint a markdown è **senza immagini** per impostazione predefinita. Se desideri esportare un documento PowerPoint contenente immagini, devi chiamare `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` e impostare anche il `BasePath` dove saranno salvate le immagini referenziate nel documento markdown.
{{% /alert %}} 

## **Converti PowerPoint in Markdown**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) per rappresentare un oggetto presentazione.
2. Utilizza il metodo [save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) per salvare l'oggetto come file markdown.

Questo codice JavaScript mostra come convertire PowerPoint in markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Converti PowerPoint in una variante di Markdown**

Aspose.Slides consente di convertire PowerPoint in markdown (contenente sintassi di base), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab e altre 17 varianti di markdown.

Questo codice JavaScript mostra come convertire PowerPoint in CommonMark:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Le 23 varianti di markdown supportate sono [elencate nella enumerazione Flavor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/flavor/) della classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Converti presentazione contenente immagini in Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownsaveoptions/) fornisce proprietà ed enumerazioni che consentono di utilizzare determinate opzioni o impostazioni per il file markdown risultante. L'enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markdownexporttype/), ad esempio, può essere impostata su valori che determinano come le immagini vengono renderizzate o gestite: `Sequential`, `TextOnly`, `Visual`.

### **Converti immagini in sequenza**

Se desideri che le immagini compaiano individualmente una dopo l'altra nel markdown risultante, devi scegliere l'opzione sequenziale. Questo codice JavaScript mostra come convertire una presentazione contenente immagini in markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Converti immagini visivamente**

Se desideri che le immagini compaiano insieme nel markdown risultante, devi scegliere l'opzione visiva. In questo caso, le immagini saranno salvate nella directory corrente dell'applicazione (e nel documento markdown verrà creato un percorso relativo), oppure puoi specificare il percorso e il nome della cartella preferiti.

Questo codice JavaScript dimostra l'operazione:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**I collegamenti ipertestuali sopravvivono all'esportazione in Markdown?**

Sì. I [collegamenti ipertestuali](/slides/it/nodejs-java/manage-hyperlinks/) nel testo vengono conservati come normali link Markdown. Le [transizioni](/slides/it/nodejs-java/slide-transition/) e le [animazioni](/slides/it/nodejs-java/powerpoint-animation/) delle diapositive non vengono convertite.

**Posso velocizzare la conversione eseguendola su più thread?**

Puoi parallelizzare su più file, ma [non condividere](/slides/it/nodejs-java/multithreading/) la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) tra thread. Usa istanze/processi separati per file per evitare conflitti.

**Cosa succede alle immagini—dove vengono salvate e i percorsi sono relativi?**

[Immagini](/slides/it/nodejs-java/image/) vengono esportate in una cartella dedicata e il file Markdown le riferisce con percorsi relativi per impostazione predefinita. Puoi configurare il percorso di output di base e il nome della cartella delle risorse per mantenere una struttura di repository prevedibile.