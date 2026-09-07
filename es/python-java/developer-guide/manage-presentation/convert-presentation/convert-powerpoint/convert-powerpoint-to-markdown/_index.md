---
title: Convertir presentaciones de PowerPoint a Markdown en Python mediante Java
linktitle: PowerPoint a Markdown
type: docs
weight: 140
url: /es/python-java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "Convertir presentaciones PPT y PPTX a Markdown en Python mediante Java y controlar dónde se guardan y referencian las imágenes exportadas de mapa de bits, metafile y SVG."
---
## **Descripción general**

Aspose.Slides for Python via Java puede convertir presentaciones PPT y PPTX a Markdown para documentación, sitios estáticos, migración de contenido y flujos de trabajo de control de versiones. Puede elegir un sabor de Markdown, controlar cómo se renderiza el contenido de las diapositivas y decidir dónde se almacenan las imágenes exportadas y cómo el Markdown generado las referencia.

Por defecto, la exportación a Markdown usa salida solo de texto. Para exportar contenido visual, establezca el tipo de exportación con el método [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/#setExportType) al valor `Sequential` o `Visual` de la enumeración [MarkdownExportType](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownexporttype/). `Sequential` renderiza los elementos de la diapositiva por separado y en orden, mientras que `Visual` mantiene los elementos agrupados juntos para conservar su relación visual. El valor `TextOnly` no emite recursos de imagen, por lo que los callbacks de guardado de imágenes no se invocan en ese modo.

## **Convertir una presentación a Markdown**

Cargue el archivo fuente con la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y luego llame al método [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) con el valor `Md` de la enumeración [SaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Cada ejemplo lee `presentation.pptx` desde el directorio de trabajo actual. Instale Aspose.Slides for Python via Java y un tiempo de ejecución Java compatible antes de ejecutar los ejemplos. Inicie la JVM una vez por proceso de Python.

## **Seleccionar un sabor de Markdown**

El método [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/#setFlavor) controla la especificación de Markdown utilizada para la salida. La enumeración [Flavor](https://reference.aspose.com/slides/es/python-java/aspose.slides/flavor/) incluye CommonMark, GitHub Flavored Markdown y otras variantes compatibles.

El siguiente ejemplo exporta una presentación como CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Exportar imágenes usando el comportamiento predeterminado de guardado local**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/) proporciona dos métodos para configurar la guardado local de imágenes:

- [setBasePath](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/#setBasePath) especifica el directorio base para el documento Markdown y sus recursos.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) especifica la subcarpeta de imágenes. Su valor predeterminado es `Images`.

El siguiente ejemplo renderiza contenido visual, escribe imágenes en `output/assets` y crea referencias de imagen relativas en el documento Markdown:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Este comportamiento también sirve como alternativa cuando un manejador de guardado de imágenes personalizado devuelve `False`.

## **Personalizar el guardado de imágenes y los enlaces Markdown**

Utilice el método [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/) para registrar un callback para recursos de mapa de bits y metafile que no sean SVG emitidos durante la exportación a Markdown. Su callback `MarkdownImageSavingHandler` recibe el objeto de imagen, su valor [ImageFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/imageformat/) y el enlace Markdown generado como un parámetro `String[]` de un solo elemento. Guarde o cargue la imagen con el formato suministrado y reemplace `link[0]` por la referencia que debe aparecer en la salida Markdown.

Los recursos emitidos en formato SVG se manejan por separado. Registre un callback con el método [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/). Su callback `MarkdownSvgImageSavingHandler` recibe un objeto [SvgImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgimage/) y el parámetro `String[] link` de un solo elemento. Un SVG no tiene argumento `ImageFormat`; escriba o cargue sus datos XML mediante el método [SvgImage.getSvgData](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgimage/#getSvgData). Dependiendo del modo de exportación y del agrupamiento visual, un SVG en la presentación fuente puede rasterizarse o combinarse con otro contenido; el recurso resultante que no sea SVG se pasa entonces al callback de guardado de imágenes. Registre ambos callbacks cuando cada recurso visual exportado requiera procesamiento personalizado.

El valor de retorno del manejador determina quién procesa la imagen:

- Devuelva `True` después de que el manejador haya guardado, cargado, transformado o procesado la imagen y haya asignado un valor válido a `link[0]`. Aspose.Slides escribe ese valor en el documento Markdown y no realiza su guardado local predeterminado.
- Devuelva `False` para que Aspose.Slides guarde la imagen localmente y genere su enlace según los valores establecidos con [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/#setBasePath) y [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Important" %}}
Un manejador que devuelve `True` asume la responsabilidad de la imagen. Si devuelve `True` sin asignar un enlace válido y no vacío, la exportación falla con una `InvalidOperationException`.
{{% /alert %}}

En Python, registre estos callbacks con `jpype.JProxy`, implementando la interfaz de callback Java a través de su método `invoke`. El argumento `link` es una matriz mutable de cadenas Java: convierta `link[0]` a una cadena Python antes de procesarla y, a continuación, asigne la URL de sustitución de nuevo a `link[0]`.

### **Guardar imágenes en un directorio de origen CDN y usar URLs externas**

El siguiente ejemplo trata `cdn-origin/presentations/quarterly-report` como un directorio de origen CDN montado o sincronizado. Cada manejador extrae el nombre de archivo generado, guarda la imagen en ese directorio personalizado y sustituye la referencia local generada por una URL pública del CDN. El propio ejemplo no realiza ninguna carga de red: la URL solo será válida después de que el directorio esté montado como origen CDN o sus archivos se publiquen en el CDN. Para almacenamiento de objetos, reemplace la escritura en el sistema de archivos por la operación de carga del SDK de almacenamiento y asigne `link[0]` solo después de que la carga sea exitosa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

El manejador de mapas de bits devuelve deliberadamente `False` para imágenes menores de 128 × 128 píxeles, por lo que Aspose.Slides guarda esas imágenes en `output/fallback-images` usando el comportamiento predeterminado. Los recursos de mapas de bits y metafile más grandes, así como los recursos SVG, son gestionados por el código personalizado. Por ejemplo, una referencia local generada como `fallback-images/image1.png` pasa a `https://cdn.example.com/presentations/quarterly-report/image1.png`. Los manejadores usan rutas del sistema operativo solo al escribir archivos; los enlaces escritos en Markdown utilizan barras diagonales (`/`) y nombres de archivo escapados en URL. Aplique la misma regla al crear enlaces relativos: use `/`, no el separador de directorios específico de la plataforma.

## **Preguntas frecuentes**

**¿Puede un único manejador procesar tanto imágenes raster como imágenes SVG?**

No. Use [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/) para los recursos de mapa de bits y metafile emitidos y [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/) para los recursos emitidos como SVG. El primero proporciona un objeto de imagen y un valor [ImageFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/imageformat/); el segundo proporciona un objeto [SvgImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgimage/) cuyo datos SVG pueden leerse con [SvgImage.getSvgData](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgimage/#getSvgData). Un SVG fuente que se rasteriza durante la exportación se procesa mediante el callback de guardado de imágenes en su lugar.

**¿Qué ocurre cuando un manejador de guardado de imágenes devuelve `False`?**

Aspose.Slides utiliza su comportamiento predeterminado de guardado local. La ubicación de la imagen y la referencia generada están controladas por los valores establecidos con [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/#setBasePath) y [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/es/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**¿Puede un manejador proporcionar una URL sin guardar la imagen localmente?**

Sí. El manejador puede cargar la imagen en almacenamiento de objetos o pasarla a otro servicio, asignar la URL resultante a `link[0]` y devolver `True`. El manejador debe completar el procesamiento por sí mismo; devolver `True` impide el guardado local predeterminado.

**¿Por qué la exportación a Markdown lanza una `InvalidOperationException` desde un manejador?**

Esta excepción se produce cuando el manejador devuelve `True` pero no proporciona un enlace válido. Asigne la ruta relativa o la URL externa que debe escribirse en Markdown antes de devolver `True`.

**¿Qué separador de ruta deben usar los enlaces de imagen?**

Use barras diagonales (`/`) en los enlaces Markdown y URLs. Use `pathlib.Path` solo para rutas del sistema de archivos y luego construya o normalice la referencia Markdown por separado.

**¿Se conservan los hipervínculos durante la exportación a Markdown?**

Sí. Los [hipervínculos](/slides/es/python-java/manage-hyperlinks/) de texto se conservan como enlaces Markdown estándar. Las [transiciones](/slides/es/python-java/slide-transition/) y [animaciones](/slides/es/python-java/powerpoint-animation/) de diapositivas no se convierten.

**¿Pueden las presentaciones convertirse a Markdown en paralelo?**

Puede procesar diferentes archivos de presentación en paralelo, pero no comparta la misma instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) entre hilos. Siga las [directrices de multihilo](/slides/es/python-java/multithreading/) y use una instancia independiente para cada archivo.