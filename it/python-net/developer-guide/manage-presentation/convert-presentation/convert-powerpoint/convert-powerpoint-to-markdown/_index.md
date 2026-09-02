---
title: Converti presentazioni PowerPoint in Markdown con Python
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/python-net/convert-powerpoint-to-markdown/
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
- collegamenti immagine CDN
- PowerPoint
- presentazione
- Markdown
- Python
- Python tramite .NET
- Aspose.Slides
description: "Converti presentazioni PPT e PPTX in Markdown con Python e controlla dove vengono salvate le immagini esportate e come il Markdown generato le riferisce."
---
## **Panoramica**

Aspose.Slides per Python via .NET può convertire presentazioni PPT e PPTX in Markdown per documentazione, siti statici, migrazione di contenuti e flussi di lavoro di controllo versione. È possibile scegliere un flavor Markdown, controllare come vengono renderizzati i contenuti delle diapositive e decidere dove vengono salvate le immagini esportate e come il Markdown generato le riferisce.

Per impostazione predefinita, l'esportazione Markdown utilizza output solo testuale. Per esportare contenuti visivi, impostare la proprietà [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/markdownsaveoptions/export_type/) sul valore `SEQUENTIAL` o `VISUAL` dell'enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/markdownexporttype/). `SEQUENTIAL` rende gli elementi delle diapositive separatamente e in ordine, mentre `VISUAL` mantiene gli elementi raggruppati insieme per preservare la loro relazione visiva. Il valore `TEXT_ONLY` non genera risorse immagine.

## **Convertire una presentazione in Markdown**

Caricare il file sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/), quindi chiamare il metodo [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/ipresentation/save/) con il valore `MD` dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Selezionare un flavor Markdown**

La proprietà [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/markdownsaveoptions/flavor/) controlla la specifica Markdown utilizzata per l'output. L'enumerazione [Flavor](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/flavor/) include CommonMark, GitHub Flavored Markdown e altre varianti supportate.

Il seguente esempio esporta una presentazione come CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Esportare le immagini usando il comportamento predefinito di salvataggio locale**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/markdownsaveoptions/) fornisce due proprietà per le immagini salvate localmente:

- [base_path](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/markdownsaveoptions/base_path/) specifica la directory di base per il documento Markdown e le sue risorse.
- [images_save_folder_name](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) specifica la sottodirectory delle immagini. Il suo valore predefinito è `Images`.

Il seguente esempio rende contenuti visivi, scrive le immagini in `output/assets` e crea riferimenti immagine relativi nel documento Markdown:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides crea la sottodirectory delle immagini quando l'esportazione produce risorse immagine, ma l'applicazione deve creare `base_path` prima di salvare il file Markdown.

## **Preparare Markdown e immagini per la pubblicazione**

Aspose.Slides per Python via .NET non espone i callback .NET di salvataggio immagine per sostituire ciascun collegamento immagine generato durante l'esportazione. Invece, esportare il documento Markdown e la sua cartella di immagini in una directory di pubblicazione, quindi pubblicare tale directory senza modificare la sua struttura relativa.

Il seguente esempio prepara `cdn-origin/presentations/quarterly-report` come directory di pubblicazione montata o sincronizzata. L'esempio stesso non esegue alcun upload di rete: i collegamenti generati diventano validi dopo che la directory è stata pubblicata nel sito o nella posizione CDN prevista.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Pubblicare `presentation.md` insieme alla directory `assets`. Il documento Markdown utilizza riferimenti immagine relativi, quindi entrambi gli elementi devono mantenere la stessa relazione nella destinazione. Se un sistema di pubblicazione richiede URL esterni assoluti, riscrivere i collegamenti generati come passaggio di post‑elaborazione separato dopo che tutti i file immagine sono stati pubblicati.

## **FAQ**

**È possibile personalizzare i file immagine individuali e i collegamenti tramite callback Python durante l'esportazione Markdown?**

No. Aspose.Slides per Python via .NET non espone i callback .NET `ImageSaving` e `SvgImageSaving`. Configurare l'output locale con [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/markdownsaveoptions/base_path/) e [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), quindi pubblicare o post‑elaborare le risorse generate.

**Dove vengono salvate le immagini esportate?**

La posizione delle immagini è controllata da [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/markdownsaveoptions/base_path/) e [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). Il documento Markdown fa riferimento a quelle immagini con percorsi relativi.

**Quale separatore di percorso dovrebbero utilizzare i collegamenti alle immagini?**

Usare le barre oblique (`/`) nei collegamenti Markdown e negli URL. Utilizzare `os.path.join` solo per percorsi del file system e normalizzare separatamente qualsiasi collegamento creato durante la post‑elaborazione.

**I collegamenti ipertestuali vengono preservati durante l'esportazione Markdown?**

Sì. I [collegamenti ipertestuali](/slides/it/python-net/manage-hyperlinks/) nel testo sono conservati come collegamenti Markdown standard. Le [transizioni](/slides/it/python-net/slide-transition/) e le [animazioni](/slides/it/python-net/powerpoint-animation/) delle diapositive non sono convertite.

**È possibile convertire le presentazioni in Markdown in parallelo?**

È possibile elaborare diversi file di presentazione in parallelo, ma non condividere la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) tra thread. Seguire le [linee guida sul multithreading](/slides/it/python-net/multithreading/) e utilizzare un'istanza separata per ogni file.