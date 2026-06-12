---
title: Converti le presentazioni PowerPoint in Markdown con Java
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "Converti le diapositive PowerPoint—PPT, PPTX—in Markdown pulito con Aspose.Slides per Java, automatizza la documentazione e mantieni la formattazione."
---
## **Introduzione**

Aspose.Slides consente di convertire le presentazioni PowerPoint in Markdown, il che può essere utile per flussi di lavoro di documentazione, generazione di siti statici, migrazione di contenuti e pubblicazione di testi sotto controllo di versione. L'API supporta l'esportazione diretta da presentazioni PPT e PPTX in file MD e fornisce opzioni aggiuntive per controllare come il contenuto delle diapositive viene rappresentato nel documento Markdown risultante.

È possibile esportare le presentazioni come Markdown semplice, scegliere tra più varianti di Markdown come CommonMark e GitHub Flavored Markdown, e configurare come le immagini vengono gestite durante l'esportazione. Per le presentazioni che contengono contenuti visivi, Aspose.Slides consente anche di salvare le immagini in una cartella separata e di riferirle dal file Markdown generato.

{{% alert color="warning" %}}
L'esportazione da PowerPoint a markdown è **senza immagini** per impostazione predefinita. Se desideri esportare un documento PowerPoint contenente immagini, devi usare `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` e anche utilizzare `setBasePath` dove verranno salvate le immagini riferite nel documento markdown.
{{% /alert %}}

## **Converti PowerPoint in Markdown**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) per rappresentare un oggetto presentazione.
2. Usa il metodo [Salva](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) per salvare l'oggetto come file markdown.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Converti PowerPoint in Variante Markdown**

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

Le 23 varianti di markdown supportate sono [elencate sotto l'enumerazione Flavor](https://reference.aspose.com/slides/it/java/com.aspose.slides/flavor/) nella classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/).

## **Converti una Presentazione con Immagini in Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/) fornisce proprietà ed enumerazioni che consentono di utilizzare determinate opzioni o impostazioni per il file markdown risultante. L'enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownexporttype/), ad esempio, può essere impostata su valori che determinano come le immagini vengono rese o gestite: `Sequential`, `TextOnly`, `Visual`.

### **Converti le Immagini Sequenzialmente**

Se desideri che le immagini compaiano individualmente una dopo l'altra nel markdown risultante, devi scegliere l'opzione sequenziale. Questo codice Java mostra come convertire una presentazione con immagini in markdown:

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

### **Converti le Immagini Visivamente**

Se desideri che le immagini compaiano insieme nel markdown risultante, devi scegliere l'opzione visuale. In questo caso, le immagini verranno salvate nella directory corrente dell'applicazione (e verrà costruito un percorso relativo per esse nel documento markdown), oppure puoi specificare il percorso e il nome della cartella preferiti.

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

Sì. I [collegamenti ipertestuali](/slides/it/java/manage-hyperlinks/) nel testo vengono conservati come normali link Markdown. Le [transizioni](/slides/it/java/slide-transition/) e le [animazioni](/slides/it/java/powerpoint-animation/) delle diapositive non vengono convertite.

**Posso velocizzare la conversione eseguendola in più thread?**

Puoi parallelizzare tra file, ma [non condividere](/slides/it/java/multithreading/) la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) tra thread. Usa istanze/processi separati per file per evitare conflitti.

**Cosa succede alle immagini — dove vengono salvate e i percorsi sono relativi?**

Le [immagini](/slides/it/java/image/) vengono esportate in una cartella dedicata e il file Markdown le riferisce con percorsi relativi per impostazione predefinita. Puoi configurare il percorso di output di base e il nome della cartella degli asset per mantenere una struttura di repository prevedibile.