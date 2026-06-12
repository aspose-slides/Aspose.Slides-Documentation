---
title: Converti le presentazioni PowerPoint in Markdown con PHP
linktitle: PowerPoint a Markdown
type: docs
weight: 140
url: /it/php-java/convert-powerpoint-to-markdown/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint a MD
- presentazione a MD
- diapositiva a MD
- PPT a MD
- PPTX a MD
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
- PHP
- Aspose.Slides
description: "Converti le diapositive PowerPoint — PPT, PPTX — in Markdown pulito con Aspose.Slides per PHP via Java, automatizza la documentazione e mantieni la formattazione."
---
## **Introduzione**

Aspose.Slides consente di convertire le presentazioni PowerPoint in Markdown, utile per flussi di lavoro di documentazione, generazione di siti statici, migrazione di contenuti e pubblicazione di testo versionata. L'API supporta l'esportazione diretta da presentazioni PPT e PPTX in file MD e offre opzioni aggiuntive per controllare come il contenuto delle diapositive è rappresentato nel documento Markdown risultante.

Puoi esportare le presentazioni come Markdown semplice, scegliere tra più varianti di Markdown come CommonMark e GitHub Flavored Markdown, e configurare come le immagini vengono gestite durante l'esportazione. Per le presentazioni che contengono contenuti visivi, Aspose.Slides permette anche di salvare le immagini in una cartella separata e referenziarle dal file Markdown generato.

{{% alert color="warning" %}}
L'esportazione da PowerPoint a Markdown è **senza immagini** per impostazione predefinita. Se desideri esportare un documento PowerPoint contenente immagini, devi impostare `ExportType = MarkdownExportType::Visual` e specificare `BasePath`, dove verranno salvate le immagini referenziate nel documento Markdown.
{{% /alert %}}

## **Convertire una presentazione in Markdown**

Questa sezione spiega come Aspose.Slides converte le presentazioni PowerPoint e OpenDocument (PPT, PPTX, ODP) in Markdown pulito, mantenendo intatta la gerarchia delle diapositive, il testo e la formattazione di base, così da poter riutilizzare il contenuto nella documentazione o in flussi di lavoro versionati senza sforzo manuale aggiuntivo.

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) per rappresentare la presentazione.  
1. Usa il metodo [save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) per esportarla come file Markdown.

Questo codice PHP mostra come convertire una presentazione PowerPoint in Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Convertire una presentazione in una variante di Markdown**

Aspose.Slides permette di convertire le presentazioni PowerPoint in Markdown con sintassi di base, nonché in CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab e altre diciassette varianti di Markdown.

Il seguente codice PHP dimostra come convertire una presentazione PowerPoint in CommonMark:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

Le 23 varianti di Markdown supportate sono elencate nell'[enumerazione Flavor](https://reference.aspose.com/slides/it/php-java/aspose.slides/flavor/).

## **Convertire una presentazione contenente immagini in Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/) espone proprietà e enumerazioni che consentono di configurare il file Markdown risultante. Per esempio, l'enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownexporttype/) specifica come le immagini vengono gestite: `Sequential`, `TextOnly` o `Visual`.

{{% alert color="warning" %}}
Per impostazione predefinita, l'esportazione da PowerPoint a Markdown **non include immagini**. Per incorporare le immagini, chiama `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` e imposta `BasePath` indicando dove salvare le immagini referenziate nel file Markdown.
{{% /alert %}}

### **Convertire le immagini in sequenza**

Se desideri che le immagini compaiano singolarmente, una dopo l'altra, nel Markdown risultante, devi scegliere l'opzione `Sequential`. Il seguente codice PHP mostra come convertire una presentazione contenente immagini in Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Convertire le immagini visivamente**

Se desideri che le immagini compaiano insieme nel Markdown risultante, devi scegliere l'opzione `Visual`. In questo caso, le immagini vengono salvate nella directory corrente dell'applicazione (e viene generato un percorso relativo per esse nel documento Markdown), o puoi specificare una directory e un nome cartella preferiti.

Il seguente codice PHP dimostra l'operazione:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**I collegamenti ipertestuali sopravvivono all'esportazione in Markdown?**

Sì. Il testo [collegamenti ipertestuali](/slides/it/php-java/manage-hyperlinks/) è preservato come collegamenti Markdown standard. Le [transizioni](/slides/it/php-java/slide-transition/) e le [animazioni](/slides/it/php-java/powerpoint-animation/) non vengono convertite.

**Posso accelerare la conversione eseguendola in più thread?**

Puoi parallelizzare su più file, ma [non condividere](/slides/it/php-java/multithreading/) la stessa [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) tra i thread. Usa istanze o processi separati per file per evitare conflitti.

**Cosa succede alle immagini — dove vengono salvate e i percorsi sono relativi?**

Le [Immagini](/slides/it/php-java/image/) vengono esportate in una cartella dedicata e il file Markdown le referenzia con percorsi relativi per impostazione predefinita. Puoi configurare il percorso di output di base e il nome della cartella delle risorse per mantenere una struttura di repository prevedibile.