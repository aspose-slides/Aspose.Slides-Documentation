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
- Formato Strict Office Open XML
- modo Zip64
- refrescar miniatura
- progreso de guardado
- Python
- Aspose.Slides
description: "Descubra cómo guardar presentaciones en Python usando Aspose.Slides—exporte a PowerPoint u OpenDocument manteniendo diseños, fuentes y efectos."
---

## **Descripción general**

[Open a Presentation in Python](/slides/es/python-net/open-presentation/) describe cómo usar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contiene el contenido de una presentación. Ya sea que esté creando una presentación desde cero o modificando una existente, querrá guardarla cuando haya terminado. Con Aspose.Slides for Python, puede guardar en un **archivo** o **flujo**. Este artículo explica las diferentes formas de guardar una presentación.

## **Guardar presentaciones en archivos**

Guarde una presentación en un archivo llamando al método `save` de la clase Presentation. Pase el nombre del archivo y el formato de guardado al método. El siguiente ejemplo muestra cómo guardar una presentación con Aspose.Slides for Python.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    
    # Realizar algún trabajo aquí...

    # Guardar la presentación en un archivo.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Guardar presentaciones en flujos**

Puede guardar una presentación en un flujo pasando un flujo de salida al método `save` de la clase Presentation. Una presentación puede escribirse en muchos tipos de flujo. En el ejemplo a continuación, creamos una nueva presentación, añadimos texto a una forma y la guardamos en un flujo.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Guardar la presentación en el flujo.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```


## **Guardar presentaciones con un tipo de vista predefinido**

Aspose.Slides for Python le permite establecer la vista inicial que PowerPoint utiliza cuando se abre la presentación generada mediante la clase ViewProperties. Establezca la propiedad `last_view` a un valor de la enumeración ViewType.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```


## **Guardar presentaciones en el formato Strict Office Open XML**

Aspose.Slides le permite guardar una presentación en el formato Strict Office Open XML. Utilice la clase PptxOptions y establezca su propiedad conformance al guardar. Si establece `Conformance.ISO_29500_2008_STRICT`, el archivo de salida se guarda en el formato Strict Office Open XML.

El ejemplo a continuación crea una presentación y la guarda en el formato Strict Office Open XML.
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

Un archivo Office Open XML es un archivo ZIP que impone límites de 4 GB (2^32 bytes) en el tamaño sin comprimir de cualquier archivo, en el tamaño comprimido de cualquier archivo y en el tamaño total del archivo, y también limita el archivo a 65 535 (2^16‑1) archivos. Las extensiones del formato ZIP64 incrementan estos límites a 2^64.

La propiedad [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) le permite elegir cuándo usar las extensiones del formato ZIP64 al guardar un archivo Office Open XML.

Esta propiedad proporciona los siguientes modos:

- `IF_NECESSARY` usa las extensiones del formato ZIP64 solo si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- `NEVER` nunca usa las extensiones del formato ZIP64.
- `ALWAYS` siempre usa las extensiones del formato ZIP64.

El siguiente código demuestra cómo guardar una presentación como PPTX con las extensiones del formato ZIP64 habilitadas:
```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```


{{% alert title="NOTA" color="warning" %}}
Al guardar con `Zip64Mode.NEVER`, se lanza una [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.
{{% /alert %}}

## **Guardar presentaciones sin actualizar la miniatura**

La propiedad [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) controla la generación de miniaturas al guardar una presentación en PPTX:

- Si se establece en `True`, la miniatura se actualiza durante el guardado. Este es el valor predeterminado.
- Si se establece en `False`, la miniatura actual se conserva. Si la presentación no tiene miniatura, no se generará ninguna.

En el código a continuación, la presentación se guarda en PPTX sin actualizar su miniatura.
```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```


{{% alert title="Info" color="info" %}}
Esta opción ayuda a reducir el tiempo necesario para guardar una presentación en formato PPTX.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose ha desarrollado una [aplicación gratuita PowerPoint Splitter](https://products.aspose.app/slides/splitter) utilizando su propia API. La aplicación le permite dividir una presentación en varios archivos guardando las diapositivas seleccionadas como nuevos archivos PPTX o PPT.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se admite "guardado rápido" (guardado incremental) para que solo se escriban los cambios?**

No. Guardar crea el archivo de destino completo cada vez; el "guardado rápido" incremental no es compatible.

**¿Es seguro guardar la misma instancia de Presentation desde varios hilos?**

No. Una instancia de [Presentation] [no es segura para subprocesos](/slides/es/python-net/multithreading/); guárdela desde un solo hilo.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar?**

[Hyperlinks](/slides/es/python-net/manage-hyperlinks/) se conservan. Los archivos vinculados externamente (p. ej., videos mediante rutas relativas) no se copian automáticamente; asegúrese de que las rutas referenciadas sigan siendo accesibles.

**¿Puedo establecer/guardar metadatos del documento (Autor, Título, Empresa, Fecha)?**

Sí. Las [document properties](/slides/es/python-net/presentation-properties/) estándar son compatibles y se escribirán en el archivo al guardarlo.