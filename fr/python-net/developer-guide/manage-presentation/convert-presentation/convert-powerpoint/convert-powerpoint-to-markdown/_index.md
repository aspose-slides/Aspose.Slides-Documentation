---
title: Convertir PowerPoint en Markdown dans Python
type: docs
weight: 140
url: /python-net/convert-powerpoint-to-markdown/
keywords: "Convertir PowerPoint en Markdown, Convertir ppt en md, PowerPoint, PPT, PPTX, Présentation, Markdown, Python, Aspose.Slides pour Python via .NET"
description: "Convertir PowerPoint en Markdown dans Python"
---

{{% alert color="info" %}} 

Le support de la conversion de PowerPoint en markdown a été implémenté dans [Aspose.Slides 23.7](https://docs.aspose.com/slides/python-net/aspose-slides-for-python-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

L’exportation de PowerPoint en markdown est **sans images** par défaut. Si vous souhaitez exporter un document PowerPoint contenant des images, vous devez définir `saveOptions.export_type = MarkdownExportType.VISUAL` et définir également le `base_path` où les images référencées dans le document markdown seront enregistrées.

{{% /alert %}} 

## **Convertir PowerPoint en Markdown**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour représenter un objet de présentation.
2. Utilisez la méthode [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) pour enregistrer l'objet en tant que fichier markdown.

Ce code Python vous montre comment convertir PowerPoint en markdown : 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:  
    pres.save("pres.md", slides.export.SaveFormat.MD)
```

## Convertir PowerPoint en Saveur Markdown

Aspose.Slides vous permet de convertir PowerPoint en markdown (contenant une syntaxe de base), CommonMark, markdown à saveur GitHub, Trello, XWiki, GitLab, et 17 autres saveurs de markdown.

Ce code Python vous montre comment convertir PowerPoint en CommonMark : 

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, Flavor
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    saveOptions = MarkdownSaveOptions()
    saveOptions.flavor = Flavor.COMMONMARK

    pres.save("pres.md", SaveFormat.MD, saveOptions)
```

Les 23 saveurs de markdown prises en charge sont [énumérées sous l'énumération Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) de la classe [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertir une Présentation Contenant des Images en Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) fournit des propriétés et des énumérations qui vous permettent d'utiliser certaines options ou paramètres pour le fichier markdown résultant. L’énumération [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) peut, par exemple, être définie sur des valeurs qui déterminent comment les images sont rendues ou gérées : `Sequential`, `TextOnly`, `Visual`.

### **Convertir les Images Séquentiellement**

Si vous souhaitez que les images apparaissent individuellement les unes après les autres dans le markdown résultant, vous devez choisir l'option séquentielle. Ce code Python vous montre comment convertir une présentation contenant des images en markdown : 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    markdownSaveOptions = slides.export.MarkdownSaveOptions()
    markdownSaveOptions.show_hidden_slides = True
    markdownSaveOptions.show_slide_number = True
    markdownSaveOptions.flavor = slides.export.Flavor.GITHUB
    markdownSaveOptions.export_type = slides.export.MarkdownExportType.SEQUENTIAL
    markdownSaveOptions.new_line_type = slides.export.NewLineType.WINDOWS
    
    pres.save("doc.md", [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ], slides.export.SaveFormat.MD, markdownSaveOptions)
```

### **Convertir les Images Visuellement**

Si vous souhaitez que les images apparaissent ensemble dans le markdown résultant, vous devez choisir l'option visuelle. Dans ce cas, les images seront enregistrées dans le répertoire actuel de l'application (et un chemin relatif sera construit pour elles dans le document markdown), ou vous pouvez spécifier votre chemin préféré et le nom du dossier.

Ce code Python démontre l'opération : 

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, MarkdownExportType
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    outPath = "c:\\documents"

    saveOptions = MarkdownSaveOptions()
    saveOptions.export_type = MarkdownExportType.VISUAL
    saveOptions.images_save_folder_name = "md-images"
    saveOptions.base_path = outPath

    pres.save(outPath + "\\pres.md", SaveFormat.MD, saveOptions)
```