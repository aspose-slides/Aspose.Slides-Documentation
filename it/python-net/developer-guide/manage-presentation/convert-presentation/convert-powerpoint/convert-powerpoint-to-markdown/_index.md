---
title: Converti le presentazioni PowerPoint in Markdown con Python
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/python-net/convert-powerpoint-to-markdown/
keywords:
- Converti PowerPoint in Markdown
- Converti OpenDocument in Markdown
- Converti presentazione in Markdown
- Converti diapositiva in Markdown
- Converti PPT in Markdown
- Converti PPTX in Markdown
- Converti ODP in Markdown
- Converti PowerPoint in MD
- Converti OpenDocument in MD
- Converti presentazione in MD
- Converti diapositiva in MD
- Converti PPT in MD
- Converti PPTX in MD
- Converti ODP in MD
- PowerPoint
- OpenDocument
- presentazione
- Markdown
- Python
- Aspose.Slides
description: "Converti diapositive PowerPoint e OpenDocument — PPT, PPTX, ODP — in Markdown pulito con Aspose.Slides per Python via .NET, automatizza la documentazione e mantieni la formattazione."
---
## **Introduzione**

Aspose.Slides consente di convertire le presentazioni PowerPoint in Markdown, utile per flussi di lavoro di documentazione, generazione di siti statici, migrazione di contenuti e pubblicazione di testi versionati. L'API supporta l'esportazione diretta da presentazioni PPT e PPTX a file MD e offre opzioni aggiuntive per controllare come il contenuto delle diapositive viene rappresentato nel documento Markdown risultante.

È possibile esportare le presentazioni come Markdown semplice, scegliere tra diversi flavor di Markdown come CommonMark e GitHub Flavored Markdown, e configurare come le immagini vengono gestite durante l'esportazione. Per le presentazioni che contengono contenuti visivi, Aspose.Slides consente anche di salvare le immagini in una cartella separata e di fare riferimento ad esse dal file Markdown generato.

{{% alert color="warning" %}}

L'esportazione da PowerPoint a Markdown è **senza immagini** per impostazione predefinita. Se desideri esportare un documento PowerPoint contenente immagini, devi impostare `export_type = MarkdownExportType.VISUAL` e specificare `base_path`, dove verranno salvate le immagini a cui fa riferimento il documento Markdown.

{{% /alert %}}

## **Convertire le presentazioni in Markdown**

L'esempio seguente mostra il modo più semplice per convertire una presentazione PowerPoint in Markdown utilizzando Aspose.Slides per Python via .NET con le impostazioni predefinite.

1. Istanziare un [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per caricare la presentazione.
1. Chiamare `save` per esportarla come file Markdown.

Usa lo snippet Python seguente per eseguire la conversione:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Convertire le presentazioni in un flavor di Markdown**

Aspose.Slides consente di convertire le presentazioni in formati Markdown, inclusi Markdown di base, CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab e altri 17 flavor di Markdown.

L'esempio Python seguente mostra come convertire una presentazione PowerPoint in CommonMark:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

La 23 flavor di Markdown supportate sono elencate nell'enumerazione [Flavor](https://reference.aspose.com/slides/it/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) della classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertire le presentazioni con immagini in Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) fornisce proprietà ed enumerazioni che consentono di configurare il file Markdown risultante. Ad esempio, l'enum [MarkdownExportType](https://reference.aspose.com/slides/it/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) controlla come le immagini vengono gestite: `SEQUENTIAL`, `TEXT_ONLY` o `VISUAL`.

### **Convertire le immagini in sequenza**

Se desideri che le immagini appaiano singolarmente—una dopo l'altra—nel Markdown generato, scegli l'opzione `SEQUENTIAL`. L'esempio Python seguente mostra come convertire una presentazione con immagini in Markdown.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **Convertire le immagini visivamente**

Se desideri che le immagini appaiano insieme nel Markdown risultante, scegli l'opzione `VISUAL`. In questa modalità, le immagini vengono salvate nella directory corrente dell'applicazione (e il documento Markdown utilizza percorsi relativi), oppure è possibile specificare un percorso di output personalizzato e un nome di cartella.

L'esempio Python seguente dimostra questa operazione:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **FAQ**

**I collegamenti ipertestuali rimangono nell'esportazione in Markdown?**

Sì. I [collegamenti ipertestuali](/slides/it/python-net/manage-hyperlinks/) nel testo vengono conservati come link Markdown standard. Le [transizioni](/slides/it/python-net/slide-transition/) e le [animazioni](/slides/it/python-net/powerpoint-animation/) delle diapositive non vengono convertite.

**Posso velocizzare la conversione eseguendola in più thread?**

La conversione può essere parallelizzata a livello di file, ma [non condividere](/slides/it/python-net/multithreading/) la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) tra thread. Usa istanze/processi separati per ogni file per evitare contese.

**Cosa succede alle immagini—dove vengono salvate e i percorsi sono relativi?**

Le [immagini](/slides/it/python-net/image/) vengono esportate in una cartella dedicata e il file Markdown le riferisce con percorsi relativi per impostazione predefinita. È possibile configurare il percorso di output base e il nome della cartella delle risorse per mantenere una struttura del repository prevedibile.