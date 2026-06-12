---
title: Converti presentazioni PowerPoint in Markdown su Android
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "Converti le diapositive PowerPoint—PPT, PPTX—in Markdown pulito con Aspose.Slides per Android via Java, automatizza la documentazione e mantieni la formattazione."
---
## **Introduzione**

Aspose.Slides consente di convertire le presentazioni PowerPoint in Markdown, il che può risultare utile per i flussi di lavoro di documentazione, la generazione di siti statici, la migrazione di contenuti e la pubblicazione di testi sotto controllo di versione. L'API supporta l'esportazione diretta da presentazioni PPT e PPTX a file MD e fornisce opzioni aggiuntive per controllare come il contenuto delle diapositive è rappresentato nel documento Markdown risultante.

È possibile esportare le presentazioni come Markdown puro, scegliere tra più varianti di Markdown come CommonMark e GitHub Flavored Markdown, e configurare come le immagini vengono gestite durante l'esportazione. Per le presentazioni che contengono contenuti visivi, Aspose.Slides consente anche di salvare le immagini in una cartella separata e fare riferimento a esse dal file Markdown generato.

Aspose.Slides supporta la conversione da presentazione a Markdown.

{{% alert color="warning" %}} 
L'esportazione da PowerPoint a Markdown è **senza immagini** per impostazione predefinita. Se desideri esportare un documento PowerPoint contenente immagini, devi impostare `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` e anche impostare il `BasePath` dove saranno salvate le immagini referenziate nel documento markdown.
{{% /alert %}} 

## **Convertire PowerPoint in Markdown**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) per rappresentare un oggetto presentazione.
2. Usa il metodo [Save ](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)per salvare l'oggetto come file markdown.

Questo codice Java mostra come convertire PowerPoint in markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertire PowerPoint in una variante di Markdown**

Aspose.Slides consente di convertire PowerPoint in markdown (contenente sintassi di base), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab e altre 17 varianti di markdown.

Questo codice Java mostra come convertire PowerPoint in CommonMark:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

Le 23 varianti di markdown supportate sono [elencate nell'enumerazione Flavor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/flavor/) dalla classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/).

## **Convertire una presentazione contenente immagini in Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/) fornisce proprietà ed enumerazioni che consentono di utilizzare determinate opzioni o impostazioni per il file markdown risultante. L'enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownexporttype/) può, ad esempio, essere impostata su valori che determinano come le immagini vengono renderizzate o gestite: `Sequential`, `TextOnly`, `Visual`.

### **Convertire le immagini in sequenza**

Se desideri che le immagini appaiano individualmente una dopo l'altra nel markdown risultante, devi scegliere l'opzione sequenziale. Questo codice Java mostra come convertire una presentazione contenente immagini in markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Convertire le immagini visualmente**

Se desideri che le immagini appaiano insieme nel markdown risultante, devi scegliere l'opzione visuale. In questo caso, le immagini saranno salvate nella directory corrente dell'applicazione (e verrà costruito un percorso relativo per esse nel documento markdown), oppure puoi specificare il percorso e il nome della cartella preferiti.

Questo codice Java dimostra l'operazione:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**I collegamenti ipertestuali sopravvivono all'esportazione in Markdown?**

Sì. I collegamenti ipertestuali nel testo sono preservati come normali link Markdown. Le transizioni delle diapositive e le animazioni non sono convertite.

**Posso accelerare la conversione eseguendola su più thread?**

Puoi parallelizzare su più file, ma [non condividere](/slides/it/androidjava/multithreading/) la stessa [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) tra i thread. Usa istanze o processi separati per file per evitare contenuti in conflitto.

**Cosa accade alle immagini—dove vengono salvate e i percorsi sono relativi?**

[Images](/slides/it/androidjava/image/) vengono esportate in una cartella dedicata, e il file Markdown le richiama con percorsi relativi per impostazione predefinita. Puoi configurare il percorso di output di base e il nome della cartella delle risorse per mantenere una struttura di repository prevedibile.