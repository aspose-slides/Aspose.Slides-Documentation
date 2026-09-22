---
title: Guardar presentaciones en Python
linktitle: Guardar presentación
type: docs
weight: 80
url: /es/python-net/save-presentation/
keywords:
- guardar PowerPoint
- guardar OpenDocument
- guardar presentación
- guardar diapositiva
- guardar PPT
- guardar PPTX
- guardar ODP
- presentación a archivo
- presentación a flujo
- tipo de vista predefinido
- Formato estricto Office Open XML
- modo Zip64
- actualizando miniatura
- progreso de guardado
- Python
- Aspose.Slides
description: "Guarde presentaciones PowerPoint y OpenDocument en archivos o flujos en Python con Aspose.Slides, y configure las opciones de salida PPTX."
---
## **Resumen**

Después de crear una presentación o [abrir una existente](/slides/es/python-net/open-presentation/), utilice el método [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/ipresentation/save/) para escribir el resultado. Aspose.Slides for Python via .NET puede guardar una presentación en un archivo o flujo en formatos PowerPoint, OpenDocument, PDF y otros. Las siguientes secciones cubren las operaciones de guardado estándar y las opciones disponibles para la salida PPTX.

## **Guardar presentaciones en archivos**

Para guardar una presentación en un archivo, pase la ruta de salida y un valor [SaveFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/saveformat/) al método [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/ipresentation/save/). El valor de formato determina el tipo de archivo que crea Aspose.Slides.

El siguiente ejemplo crea una presentación y la guarda como archivo PPTX:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Añadir o modificar el contenido de la presentación aquí.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Guardar presentaciones en su formato original**

Para ejemplos de detección de archivos y flujos, el comportamiento de presentaciones recién creadas y la distinción entre los formatos de origen y salida, consulte [Determine the Original Presentation Format](/slides/es/python-net/detect-presentation-source-format/).

En una aplicación de procesamiento por lotes, el formato de entrada puede no ser conocido de antemano. Después de cargar un archivo, lea su formato original desde la propiedad [Presentation.source_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/source_format/). Pase el valor resultante de [SourceFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/sourceformat/) a [SlideUtil.to_save_format](https://reference.aspose.com/slides/es/python-net/aspose.slides.util/slideutil/to_save_format/) para obtener el valor correspondiente de [SaveFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/saveformat/), y luego use [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/ipresentation/save/) para escribir la presentación modificada.

El siguiente ejemplo completo procesa cada archivo en un directorio de entrada, actualiza su título y lo guarda en un directorio de salida en el formato desde el que se cargó:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/es/python-net/aspose.slides.util/slideutil/to_save_format/) asigna PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP y PowerPoint XML a sus correspondientes formatos de guardado de presentación. Sólo asigna formatos de origen de presentación; no está destinado a seleccionar formatos de exportación como PDF, HTML, TIFF o imágenes. Pasar un valor de [SourceFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/sourceformat/) no compatible o inválido genera una excepción.

Los archivos heredados PPT, PPS y POT utilizan el mismo contenedor binario. Cuando una presentación de este tipo se carga desde un flujo sin extensión de archivo, un archivo PPS o POT puede identificarse como PPT. Si es necesario conservar estos subtipos heredados, mantenga el nombre de archivo original o los metadatos de formato por separado y utilícelos al elegir el nombre de archivo y formato de salida.

## **Guardar presentaciones en flujos**

Para escribir una presentación sin depender de una ruta de archivo final, pase un flujo [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) writable y un valor [SaveFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/saveformat/) al método [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/ipresentation/save/). Este enfoque es útil cuando la salida debe devolverse desde un servicio web, almacenarse en una base de datos o procesarse en memoria.

El siguiente ejemplo guarda una nueva presentación en un flujo de archivo:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Guardar presentaciones con un tipo de vista predefinido**

Puede especificar la vista en la que PowerPoint abre inicialmente una presentación guardada. Establezca la propiedad [ViewProperties.last_view](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/last_view/) a un valor [ViewType](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewtype/) antes de guardar.

El siguiente ejemplo configura la vista Slide Master como vista inicial:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Guardar presentaciones en el formato estricto Office Open XML**

Para crear un archivo PPTX que cumpla con el perfil Strict de Office Open XML, cree una instancia de [PptxOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pptxoptions/) y establezca su propiedad [conformance](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pptxoptions/conformance/) a `Conformance.ISO_29500_2008_STRICT`. Luego pase las opciones al método [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/ipresentation/save/).

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo ZIP estándar limita el tamaño comprimido y sin comprimir de cada entrada, el tamaño total del archivo y el número de entradas. Dado que un archivo PPTX es un archivo ZIP, una presentación muy grande puede superar esos límites. Las extensiones ZIP64 aumentan los límites de tamaño y número de entradas aplicables.

Utilice la propiedad [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) para controlar si Aspose.Slides escribe extensiones ZIP64:

- `IF_NECESSARY` utiliza ZIP64 sólo cuando la presentación supera los límites estándar de ZIP. Este es el modo predeterminado.
- `NEVER` desactiva las extensiones ZIP64.
- `ALWAYS` siempre escribe extensiones ZIP64.

El siguiente ejemplo siempre habilita las extensiones ZIP64 para la presentación de salida:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Advertencia" %}}
Si se utiliza `Zip64Mode.NEVER` y la presentación no cabe dentro de los límites estándar de ZIP, la operación de guardado genera una [PptxException](https://reference.aspose.com/slides/es/python-net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Guardar presentaciones en formato Office Open XML con niveles de compresión**

Para la salida PPTX, puede equilibrar la velocidad de guardado contra el tamaño del archivo configurando la propiedad [PptxOptions.compression_level](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pptxoptions/compression_level/). La enumeración [CompressionLevel](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/compressionlevel/) proporciona los siguientes valores:

- `NONE` almacena los datos sin compresión.
- `LEVEL1` ofrece la compresión más rápida y la salida comprimida más grande.
- `LEVEL2` a `LEVEL5` favorecen progresivamente una salida más pequeña sobre la velocidad de guardado.
- `LEVEL6` equilibra la velocidad de guardado y el tamaño del archivo. Este es el nivel predeterminado.
- `LEVEL7` y `LEVEL8` favorecen aún más una salida más pequeña sobre la velocidad de guardado.
- `LEVEL9` ofrece la compresión más fuerte y requiere el mayor tiempo de procesamiento.

El siguiente ejemplo guarda una presentación sin compresión:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

El siguiente ejemplo utiliza el nivel máximo de compresión:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Guardar presentaciones sin actualizar la miniatura**

Cuando una presentación se guarda como PPTX, la propiedad [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) controla la miniatura del documento:

- `True` regenera la miniatura durante la operación de guardado. Este es el valor predeterminado.
- `False` conserva la miniatura existente. Si la presentación no tiene miniatura, Aspose.Slides no genera una.

El siguiente ejemplo guarda una presentación sin actualizar su miniatura:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Nota" %}}
Desactivar la actualización de la miniatura puede reducir el tiempo necesario para guardar un archivo PPTX.
{{% /alert %}}

{{% alert color="info" title="Nota" %}}
Aspose ofrece un [PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) gratuito creado con la API Aspose.Slides. Guarda diapositivas seleccionadas de una presentación como archivos PPT o PPTX separados.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Aspose.Slides admite guardado incremental o “fast save”?**

No. Cada operación de guardado escribe un archivo de salida completo en lugar de actualizar sólo las partes modificadas.

**¿Pueden varios hilos guardar la misma instancia de Presentation?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) [no es segura para subprocesos](/slides/es/python-net/multithreading/). Acceda y guarde cada instancia sólo desde un hilo a la vez.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente cuando guardo una presentación?**

Los [hipervínculos](/slides/es/python-net/manage-hyperlinks/) permanecen en la presentación. Aspose.Slides no copia los archivos vinculados externamente, por lo que la presentación guardada debe poder seguir accediendo a sus ubicaciones.

**¿Puedo guardar metadatos del documento como autor, título, empresa y fecha de creación?**

Sí. Establezca las [propiedades del documento](/slides/es/python-net/presentation-properties/) correspondientes antes de guardar, y Aspose.Slides las escribe en el archivo de salida.