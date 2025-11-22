---
title: Convertir presentaciones de PowerPoint a Markdown en Python
linktitle: PowerPoint a Markdown
type: docs
weight: 140
url: /es/python-net/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint a Markdown
- convertir OpenDocument a Markdown
- convertir presentación a Markdown
- convertir diapositiva a Markdown
- convertir PPT a Markdown
- convertir PPTX a Markdown
- convertir ODP a Markdown
- convertir PowerPoint a MD
- convertir OpenDocument a MD
- convertir presentación a MD
- convertir diapositiva a MD
- convertir PPT a MD
- convertir PPTX a MD
- convertir ODP a MD
- PowerPoint
- OpenDocument
- presentación
- Markdown
- Python
- Aspose.Slides
description: "Convertir diapositivas de PowerPoint y OpenDocument - PPT, PPTX, ODP - a Markdown limpio con Aspose.Slides para Python a través de .NET, automatice la documentación y mantenga el formato."
---

## **Convertir presentaciones a Markdown**

El ejemplo a continuación muestra la forma más sencilla de convertir una presentación de PowerPoint a Markdown usando Aspose.Slides para Python a través de .NET con la configuración predeterminada.

1. Instanciar una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para cargar la presentación.
1. Llamar a `save` para exportarla como un archivo Markdown.

Utilice el fragmento de Python a continuación para realizar la conversión:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```


## **Convertir presentaciones a formato Markdown**

Aspose.Slides le permite convertir presentaciones a formatos Markdown, incluidos Markdown básico, CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab y 17 sabores de Markdown más.

El siguiente ejemplo en Python muestra cómo convertir una presentación de PowerPoint a CommonMark:
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```


Los 23 sabores de Markdown compatibles se enumeran en la enumeración [Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) de la clase [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertir presentaciones con imágenes a Markdown**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) proporciona propiedades y enumeraciones que le permiten configurar el archivo Markdown resultante. Por ejemplo, la enumeración [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) controla cómo se manejan las imágenes: `SEQUENTIAL`, `TEXT_ONLY` o `VISUAL`.

### **Convertir imágenes secuencialmente**

Si desea que las imágenes aparezcan individualmente—una tras otra—en el Markdown generado, elija la opción `SEQUENTIAL`. El ejemplo en Python a continuación muestra cómo convertir una presentación con imágenes a Markdown.
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


### **Convertir imágenes visualmente**

Si desea que las imágenes aparezcan juntas en el Markdown resultante, elija la opción `VISUAL`. En este modo, las imágenes se guardan en el directorio actual de la aplicación (y el documento Markdown usa rutas relativas), o puede especificar una ruta de salida y un nombre de carpeta personalizados.

El ejemplo en Python a continuación demuestra esta operación:
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

**¿Los hipervínculos sobreviven a la exportación a Markdown?**

Sí. Los hipervínculos de texto [hyperlinks](/slides/es/python-net/manage-hyperlinks/) se conservan como enlaces Markdown estándar. Las transiciones de diapositiva [transitions](/slides/es/python-net/slide-transition/) y las animaciones [animations](/slides/es/python-net/powerpoint-animation/) no se convierten.

**¿Puedo acelerar la conversión ejecutándola en varios hilos?**

Puede paralelizar por archivos, pero [don’t share](/slides/es/python-net/multithreading/) la misma instancia de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) entre hilos. Use instancias o procesos separados por archivo para evitar contención.

**¿Qué ocurre con las imágenes—dónde se guardan y son rutas relativas?**

Las [Images](/slides/es/python-net/image/) se exportan a una carpeta dedicada, y el archivo Markdown las referencia con rutas relativas de forma predeterminada. Puede configurar la ruta base de salida y el nombre de la carpeta de recursos para mantener una estructura de repositorio predecible.