---
title: Convertir presentaciones PowerPoint a Markdown en Python
linktitle: PowerPoint a Markdown
type: docs
weight: 140
url: /es/python-net/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a MD
- presentación a MD
- diapositiva a MD
- PPT a MD
- PPTX a MD
- guardar PowerPoint como Markdown
- guardar presentación como Markdown
- guardar diapositiva como Markdown
- guardar PPT como MD
- guardar PPTX como MD
- exportar PPT a MD
- exportar PPTX a MD
- exportación de imágenes Markdown
- enlaces de imágenes CDN
- PowerPoint
- presentación
- Markdown
- Python
- Python a través de .NET
- Aspose.Slides
description: "Convertir presentaciones PPT y PPTX a Markdown en Python y controlar dónde se guardan las imágenes exportadas y cómo el Markdown generado las referencia."
---
## **Visión general**

Aspose.Slides for Python via .NET puede convertir presentaciones PPT y PPTX a Markdown para documentación, sitios estáticos, migración de contenidos y flujos de trabajo de control de versiones. Puedes elegir un sabor de Markdown, controlar cómo se renderiza el contenido de las diapositivas y decidir dónde se almacenan las imágenes exportadas y cómo el Markdown generado las referencia.

De forma predeterminada, la exportación a Markdown utiliza salida sólo de texto. Para exportar contenido visual, establece la propiedad [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/markdownsaveoptions/export_type/) en el valor `SEQUENTIAL` o `VISUAL` de la enumeración [MarkdownExportType](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/markdownexporttype/). `SEQUENTIAL` renderiza los elementos de la diapositiva por separado y en orden, mientras que `VISUAL` mantiene los elementos agrupados juntos para preservar su relación visual. El valor `TEXT_ONLY` no genera recursos de imagen.

## **Convertir una presentación a Markdown**

Carga el archivo origen con la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y luego llama al método [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/ipresentation/save/) con el valor `MD` de la enumeración [SaveFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Seleccionar un sabor de Markdown**

La propiedad [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/markdownsaveoptions/flavor/) controla la especificación de Markdown utilizada para la salida. La enumeración [Flavor](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/flavor/) incluye CommonMark, GitHub Flavored Markdown y otras variantes admitidas.

El siguiente ejemplo exporta una presentación como CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Exportar imágenes usando el comportamiento predeterminado de guardado local**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/markdownsaveoptions/) ofrece dos propiedades para imágenes guardadas localmente:

- [base_path](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/markdownsaveoptions/base_path/) especifica el directorio base para el documento Markdown y sus recursos.
- [images_save_folder_name](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) especifica el subdirectorio de imágenes. Su valor predeterminado es `Images`.

El siguiente ejemplo renderiza contenido visual, escribe imágenes en `output/assets` y crea referencias de imagen relativas en el documento Markdown:

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

Aspose.Slides crea el subdirectorio de imágenes cuando la exportación genera recursos de imagen, pero la aplicación debe crear `base_path` antes de guardar el archivo Markdown.

## **Preparar Markdown e imágenes para publicación**

Aspose.Slides for Python via .NET no expone los callbacks de guardado de imágenes de .NET para reemplazar cada enlace de imagen generado durante la exportación. En su lugar, exporta el documento Markdown y su carpeta de imágenes a un directorio de publicación, y luego publica ese directorio sin cambiar su estructura relativa.

El siguiente ejemplo prepara `cdn-origin/presentations/quarterly-report` como un directorio de publicación montado o sincronizado. El propio ejemplo no realiza ninguna carga a la red: los enlaces generados se vuelven válidos después de que el directorio se publique en el sitio o ubicación CDN previsto.

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

Publica `presentation.md` junto con el directorio `assets`. El documento Markdown usa referencias de imagen relativas, por lo que ambos elementos deben mantener la misma relación en el destino. Si un sistema de publicación requiere URL externas absolutas, reescribe los enlaces generados como un paso de post‑procesado separado después de que todos los archivos de imagen se hayan publicado.

## **FAQ**

**¿Pueden los callbacks de Python personalizar archivos de imagen y enlaces individuales durante la exportación a Markdown?**

No. Aspose.Slides for Python via .NET no expone los callbacks .NET `ImageSaving` y `SvgImageSaving`. Configura la salida local con [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/markdownsaveoptions/base_path/) y [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), luego publica o post‑procesa los recursos generados.

**¿Dónde se guardan las imágenes exportadas?**

La ubicación de las imágenes está controlada por [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/markdownsaveoptions/base_path/) y [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). El documento Markdown referencia esas imágenes con rutas relativas.

**¿Qué separador de rutas deben usar los enlaces de imagen?**

Utiliza barras diagonales (/) en los enlaces y URL de Markdown. Usa `os.path.join` solo para rutas del sistema de archivos y normaliza cualquier enlace creado durante el post‑procesado por separado.

**¿Se conservan los hipervínculos durante la exportación a Markdown?**

Sí. El texto [hyperlinks](/slides/es/python-net/manage-hyperlinks/) se conserva como enlaces Markdown estándar. Las [transitions](/slides/es/python-net/slide-transition/) y [animations](/slides/es/python-net/powerpoint-animation/) de las diapositivas no se convierten.

**¿Se pueden convertir presentaciones a Markdown en paralelo?**

Puedes procesar diferentes archivos de presentación en paralelo, pero no compartas la misma instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) entre hilos. Sigue las [multithreading guidelines](/slides/es/python-net/multithreading/) y usa una instancia separada para cada archivo.