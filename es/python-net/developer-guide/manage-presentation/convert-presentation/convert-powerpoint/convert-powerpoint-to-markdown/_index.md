---
title: Convertir PowerPoint a Markdown en Python
type: docs
weight: 140
url: /python-net/convert-powerpoint-to-markdown/
keywords: "Convertir PowerPoint a Markdown, Convertir ppt a md, PowerPoint, PPT, PPTX, Presentación, Markdown, Python, Aspose.Slides para Python a través de .NET"
description: "Convertir PowerPoint a Markdown en Python"
---

{{% alert color="info" %}} 

El soporte para la conversión de PowerPoint a markdown se implementó en [Aspose.Slides 23.7](https://docs.aspose.com/slides/python-net/aspose-slides-for-python-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

La exportación de PowerPoint a markdown es **sin imágenes** por defecto. Si deseas exportar un documento de PowerPoint que contenga imágenes, necesitas establecer `saveOptions.export_type = MarkdownExportType.VISUAL` y también establecer el `base_path` donde se guardarán las imágenes referenciadas en el documento markdown.

{{% /alert %}} 

## **Convertir PowerPoint a Markdown**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para representar un objeto de presentación.
2. Utiliza el método [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) para guardar el objeto como un archivo markdown.

Este código en Python te muestra cómo convertir PowerPoint a markdown:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:  
    pres.save("pres.md", slides.export.SaveFormat.MD)
```

## Convertir PowerPoint a Sabor de Markdown

Aspose.Slides te permite convertir PowerPoint a markdown (que contiene sintaxis básica), CommonMark, markdown con sabor de GitHub, Trello, XWiki, GitLab y 17 otros sabores de markdown.

Este código en Python te muestra cómo convertir PowerPoint a CommonMark:

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, Flavor
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    saveOptions = MarkdownSaveOptions()
    saveOptions.flavor = Flavor.COMMONMARK

    pres.save("pres.md", SaveFormat.MD, saveOptions)
```

Los 23 sabores de markdown compatibles están [listados en la enumeración Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) de la clase [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertir Presentación Conteniendo Imágenes a Markdown**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) proporciona propiedades y enumeraciones que te permiten usar ciertas opciones o configuraciones para el archivo markdown resultante. La enumeración [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) puede establecerse en valores que determinan cómo se renderizan o manejan las imágenes: `Sequential`, `TextOnly`, `Visual`.

### **Convertir Imágenes Secuencialmente**

Si deseas que las imágenes aparezcan individualmente una tras otra en el markdown resultante, debes elegir la opción secuencial. Este código en Python te muestra cómo convertir una presentación que contiene imágenes a markdown:

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

### **Convertir Imágenes Visualmente**

Si deseas que las imágenes aparezcan juntas en el markdown resultante, debes elegir la opción visual. En este caso, las imágenes se guardarán en el directorio actual de la aplicación (y se construirá una ruta relativa para ellas en el documento markdown), o puedes especificar tu ruta y nombre de carpeta preferidos.

Este código en Python demuestra la operación:

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