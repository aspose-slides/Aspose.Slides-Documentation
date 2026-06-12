---
title: Converti presentazioni PowerPoint in Markdown con .NET
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/net/convert-powerpoint-to-markdown/
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
- .NET
- C#
- Aspose.Slides
description: "Converti le diapositive PowerPoint—PPT, PPTX—in Markdown pulito con Aspose.Slides per .NET, automatizza la documentazione e mantieni la formattazione."
---
## **Introduzione**

Aspose.Slides consente di convertire le presentazioni PowerPoint in Markdown, il che può essere utile per flussi di lavoro di documentazione, generazione di siti statici, migrazione di contenuti e pubblicazione di testo con controllo di versione. L'API supporta l'esportazione diretta da presentazioni PPT e PPTX in file MD e offre opzioni aggiuntive per controllare come il contenuto delle diapositive viene rappresentato nel documento Markdown risultante.

Puoi esportare le presentazioni come Markdown semplice, scegliere tra diversi flavor di Markdown come CommonMark e GitHub Flavored Markdown, e configurare come le immagini vengono gestite durante l'esportazione. Per le presentazioni che contengono contenuti visivi, Aspose.Slides permette anche di salvare le immagini in una cartella separata e fare riferimento a esse dal file Markdown generato.

{{% alert color="warning" %}}
L'esportazione da PowerPoint a Markdown è **senza immagini** per impostazione predefinita. Se desideri esportare un documento PowerPoint contenente immagini, devi impostare `ExportType = MarkdownExportType.Visual` e specificare `BasePath`, dove verranno salvate le immagini referenziate nel documento Markdown.
{{% /alert %}}

## **Converti PowerPoint in Markdown**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) per rappresentare un oggetto presentazione.
2. Usa il metodo [Salva](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/methods/save)metodo per salvare l'oggetto come file markdown.

Questo codice C# mostra come convertire PowerPoint in markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **Converti PowerPoint in un flavor di Markdown**

Aspose.Slides consente di convertire PowerPoint in markdown (contenente sintassi di base), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab e altri 17 flavor di markdown.

Questo codice C# mostra come convertire PowerPoint in CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

I 23 flavor di markdown supportati sono [elencati nell'enumerazione Flavor](https://reference.aspose.com/slides/it/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) della classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Converti una presentazione contenente immagini in Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) fornisce proprietà ed enumerazioni che consentono di utilizzare determinate opzioni o impostazioni per il file markdown risultante. L'enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/), ad esempio, può essere impostata su valori che determinano come le immagini vengono renderizzate o gestite: `Sequential`, `TextOnly`, `Visual`.

### **Converti le immagini in modo sequenziale**

Se desideri che le immagini compaiano individualmente una dopo l'altra nel markdown risultante, devi scegliere l'opzione sequenziale. Questo codice C# mostra come convertire una presentazione contenente immagini in markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **Converti le immagini visualmente**

Se desideri che le immagini compaiano insieme nel markdown risultante, devi scegliere l'opzione visuale. In questo caso, le immagini saranno salvate nella directory corrente dell'applicazione (e verrà costruito un percorso relativo per esse nel documento markdown), oppure puoi specificare il percorso e il nome della cartella preferiti.

Questo codice C# dimostra l'operazione:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **FAQ**

**I collegamenti ipertestuali sopravvivono all'esportazione in Markdown?**

Sì. I [collegamenti ipertestuali](/slides/it/net/manage-hyperlinks/) nel testo sono conservati come link Markdown standard. Le [transizioni](/slides/it/net/slide-transition/) e le [animazioni](/slides/it/net/powerpoint-animation/) delle diapositive non vengono convertite.

**Posso velocizzare la conversione eseguendola su più thread?**

Puoi parallelizzare a livello di file, ma [non condividere](/slides/it/net/multithreading/) la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) tra thread. Usa istanze/processi separati per file per evitare contese.

**Cosa succede alle immagini — dove vengono salvate e i percorsi sono relativi?**

Le [immagini](/slides/it/net/image/) vengono esportate in una cartella dedicata e il file Markdown le referenzia con percorsi relativi per impostazione predefinita. Puoi configurare il percorso di output base e il nome della cartella degli asset per mantenere una struttura di repository prevedibile.