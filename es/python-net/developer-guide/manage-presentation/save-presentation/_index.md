---
title: Guardar presentaciones en Python
linktitle: Guardar presentaciones
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
- formato Strict Office Open XML
- modo Zip64
- actualización de miniatura
- progreso de guardado
- Python
- Aspose.Slides
description: "Descubra cómo guardar presentaciones en Python usando Aspose.Slides—exportar a PowerPoint o OpenDocument manteniendo diseños, fuentes y efectos."
---
## **Visión general**

[Open a Presentation in Python](/slides/es/python-net/open-presentation/) describió cómo usar la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) contiene el contenido de una presentación. Tanto si crea una presentación desde cero como si modifica una existente, querrá guardarla cuando haya terminado. Con Aspose.Slides for Python, puede guardar en un **archivo** o **flujo**. Este artículo explica las diferentes formas de guardar una presentación.

## **Guardar presentaciones en archivos**

Guarde una presentación en un archivo llamando al método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/). Pase el nombre del archivo y el formato de guardado al método. El siguiente ejemplo muestra cómo guardar una presentación con Aspose.Slides for Python.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    
    # Realizar algún trabajo aquí...

    # Guardar la presentación en un archivo.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Guardar presentaciones en flujos**

Puede guardar una presentación en un flujo pasando un flujo de salida al método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/). Una presentación puede escribirse en muchos tipos de flujos. En el ejemplo siguiente, creamos una nueva presentación y la guardamos en un flujo de archivo.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Guardar la presentación en el flujo.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Guardar presentaciones con un tipo de vista predefinido**

Aspose.Slides for Python le permite establecer la vista inicial que PowerPoint usa cuando se abre la presentación generada mediante la clase [ViewProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewproperties/). Establezca la propiedad `last_view` con un valor de la enumeración [ViewType](https://reference.aspose.com/slides/es/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Guardar presentaciones en el formato Strict Office Open XML**

Aspose.Slides le permite guardar una presentación en el formato Strict Office Open XML. Utilice la clase [PptxOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pptxoptions/) y establezca su propiedad `conformance` al guardar. Si establece `Conformance.ISO_29500_2008_STRICT`, el archivo de salida se guarda en el formato Strict Office Open XML.

El ejemplo siguiente crea una presentación y la guarda en el formato Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    # Guardar la presentación en el formato Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo Office Open XML es un archivo ZIP que impone límites de 4 GB (2^32 bytes) en el tamaño sin comprimir de cualquier archivo, el tamaño comprimido de cualquier archivo y el tamaño total del archivo, y también limita el archivo a 65 535 (2^16‑1) archivos. Las extensiones del formato ZIP64 aumentan esos límites a 2^64.

La propiedad [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) le permite elegir cuándo usar las extensiones del formato ZIP64 al guardar un archivo Office Open XML.

Esta propiedad ofrece los siguientes modos:

- `IF_NECESSARY` usa extensiones del formato ZIP64 solo si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- `NEVER` nunca usa extensiones del formato ZIP64.
- `ALWAYS` siempre usa extensiones del formato ZIP64.

El siguiente código muestra cómo guardar una presentación como archivo PPTX con las extensiones del formato ZIP64 habilitadas:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTA" color="warning" %}}
Al guardar con `Zip64Mode.NEVER`, se lanza una [PptxException](https://reference.aspose.com/slides/es/python-net/aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.
{{% /alert %}}

## **Guardar presentaciones en formato Office Open XML con niveles de compresión**

Al trabajar con presentaciones grandes, puede ajustar el nivel de compresión para equilibrar el tamaño del archivo y el tiempo de procesamiento. Según sus requisitos, puede preferir un procesamiento más rápido o archivos de salida más pequeños.

Aspose.Slides proporciona la propiedad [PptxOptions.compression_level](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pptxoptions/compression_level/) que le permite especificar el nivel de compresión utilizado al guardar una presentación en formato Office Open XML.

Los siguientes niveles de compresión están disponibles:

- [**NONE**](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/compressionlevel/): No se aplica compresión. Los archivos se almacenan tal cual.
- [**LEVEL1**](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/compressionlevel/): El nivel de compresión más rápido con la menor relación de compresión.
- [**LEVEL2**](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/compressionlevel/): Compresión más rápida con una relación de compresión ligeramente mejor que **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/compressionlevel/): Ofrece mejor compresión que **LEVEL2** con un impacto moderado en el tiempo de procesamiento.
- [**LEVEL4**](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/compressionlevel/): Ofrece mejor compresión que **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/compressionlevel/): Ofrece una compresión mejorada respecto a **LEVEL4** con tiempo de procesamiento adicional.
- [**LEVEL6**](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/compressionlevel/): Compresión estándar que ofrece un buen equilibrio entre la velocidad de procesamiento y el tamaño del archivo. Este es el *nivel de compresión predeterminado*.
- [**LEVEL7**](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/compressionlevel/): Ofrece mejor compresión que **LEVEL6** con un procesamiento más lento.
- [**LEVEL8**](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/compressionlevel/): Ofrece mejor compresión que **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/compressionlevel/): Compresión máxima. Produce el archivo más pequeño al costo del tiempo de procesamiento más largo.

El siguiente ejemplo muestra cómo guardar una presentación como archivo PPTX *sin compresión*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Este ejemplo muestra cómo guardar una presentación como archivo PPTX con *compresión máxima*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Guardar presentaciones sin actualizar la miniatura**

La propiedad [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) controla la generación de miniaturas al guardar una presentación en PPTX:

- Si se establece en `True`, la miniatura se actualiza durante el guardado. Este es el valor predeterminado.
- Si se establece en `False`, se conserva la miniatura actual. Si la presentación no tiene miniatura, no se genera ninguna.

En el código siguiente, la presentación se guarda en PPTX sin actualizar su miniatura.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Información" color="info" %}}
Esta opción ayuda a reducir el tiempo necesario para guardar una presentación en formato PPTX.
{{% /alert %}}

{{% alert title="Información" color="info" %}}
Aspose ha desarrollado una [aplicación gratuita PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) usando su propia API. La aplicación le permite dividir una presentación en varios archivos guardando las diapositivas seleccionadas como nuevos archivos PPTX o PPT.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se admite el “guardado rápido” (guardado incremental) para que solo se escriban los cambios?**

No. Cada vez que se guarda se crea el archivo completo; el “guardado rápido” incremental no está soportado.

**¿Es seguro en cuanto a subprocesos guardar la misma instancia de Presentation desde varios hilos?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) [no es segura para subprocesos](/slides/es/python-net/multithreading/); guárdela desde un único hilo.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar?**

[Los hipervínculos](/slides/es/python-net/manage-hyperlinks/) se conservan. Los archivos vinculados externamente (p. ej., vídeos mediante rutas relativas) no se copian automáticamente; asegúrese de que las rutas referenciadas sigan siendo accesibles.

**¿Puedo establecer/guardar los metadatos del documento (Autor, Título, Empresa, Fecha)?**

Sí. Las [propiedades estándar del documento](/slides/es/python-net/presentation-properties/) son compatibles y se escribirán en el archivo al guardarlo.