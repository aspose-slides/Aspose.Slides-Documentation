---
title: Abrir presentaciones en Python
linktitle: Abrir presentaciones
type: docs
weight: 20
url: /es/python-net/open-presentation/
keywords:
- abrir PowerPoint
- abrir presentación
- abrir PPTX
- abrir PPT
- abrir ODP
- cargar presentación
- cargar PPTX
- cargar PPT
- cargar ODP
- presentación protegida
- presentación grande
- recurso externo
- objeto binario
- Python
- Aspose.Slides
description: "Abra presentaciones PowerPoint (.pptx, .ppt) y OpenDocument (.odp) sin esfuerzo con Aspose.Slides para Python vía .NET: rápido, fiable, con todas las funciones."
---
## **Introducción**

Más allá de crear presentaciones de PowerPoint desde cero, Aspose.Slides también permite abrir presentaciones existentes. Después de cargar una presentación, puedes obtener información sobre ella, editar el contenido de las diapositivas, añadir nuevas diapositivas, eliminar las existentes y mucho más.

## **Abrir presentaciones**

Para abrir una presentación existente, instancia la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y pasa la ruta del archivo a su constructor.

El siguiente ejemplo en Python muestra cómo abrir una presentación y obtener el número de diapositivas:

```python
import aspose.slides as slides

# Instanciar la clase Presentation y pasar una ruta de archivo a su constructor.
with slides.Presentation("sample.pptx") as presentation:
    # Imprimir el número total de diapositivas en la presentación.
    print(presentation.slides.length)
```

## **Abrir presentaciones protegidas con contraseña**

Cuando necesites abrir una presentación protegida con contraseña, pasa la contraseña mediante la propiedad [password](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/password/) de la clase [LoadOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/) para descifrarla y cargarla. El siguiente fragmento de código Python demuestra esta operación:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Realizar operaciones en la presentación descifrada.
```

## **Abrir presentaciones de gran tamaño**

Aspose.Slides ofrece opciones—en particular la propiedad [blob_management_options](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/blob_management_options/) de la clase [LoadOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/)—para ayudar a cargar presentaciones de gran tamaño.

Este código Python muestra cómo cargar una presentación grande (por ejemplo, 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Elija el comportamiento KeepLocked: el archivo de la presentación permanecerá bloqueado durante la vida útil de 
# la instancia Presentation, pero no necesita cargarse en memoria ni copiarse a un archivo temporal.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # La presentación grande se ha cargado y puede usarse, mientras el consumo de memoria sigue bajo.

    # Realizar cambios en la presentación.
    presentation.slides[0].name = "Large presentation"

    # Guardar la presentación en otro archivo. El consumo de memoria sigue bajo durante esta operación.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # No haga esto! Se lanzará una excepción de E/S porque el archivo está bloqueado hasta que el objeto Presentation sea eliminado.
    os.remove(file_path)

# Está bien hacerlo aquí. El archivo origen ya no está bloqueado por el objeto Presentation.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
Para evitar ciertas limitaciones al trabajar con streams, Aspose.Slides puede copiar el contenido de un stream. Cargar una presentación grande desde un stream hace que la presentación se copie y puede ralentizar la carga. Por lo tanto, cuando necesites cargar una presentación grande, recomendamos encarecidamente usar la ruta del archivo de la presentación en lugar de un stream.

Al crear una presentación que contenga objetos grandes (vídeo, audio, imágenes de alta resolución, etc.), puedes utilizar la [gestión de BLOB](/slides/es/python-net/manage-blob/) para reducir el consumo de memoria.
{{%/alert %}}

## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación de PowerPoint puede contener los siguientes tipos de objetos binarios incrustados:

- Proyecto VBA (accesible a través de [Presentation.vba_project](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/vba_project/));
- Datos incrustados de objeto OLE (accesibles a través de [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/es/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- Datos binarios de control ActiveX (accesibles a través de [Control.active_x_control_binary](https://reference.aspose.com/slides/es/python-net/aspose.slides/control/active_x_control_binary/)).

Mediante la propiedad [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) puedes cargar una presentación sin objetos binarios incrustados.

Esta propiedad es útil para eliminar contenido binario potencialmente malicioso. El siguiente código Python muestra cómo cargar una presentación sin contenido binario incrustado:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Realizar operaciones en la presentación.
```

## **Preguntas frecuentes**

**¿Cómo puedo saber si un archivo está corrupto y no se puede abrir?**

Obtendrás una excepción de validación de análisis/formato durante la carga. Estos errores suelen mencionar una estructura ZIP no válida o registros de PowerPoint dañados.

**¿Qué ocurre si faltan fuentes requeridas al abrir la presentación?**

El archivo se abrirá, pero más tarde la [renderización/exportación](/slides/es/python-net/convert-presentation/) puede sustituir fuentes. [Configura sustituciones de fuentes](/slides/es/python-net/font-substitution/) o [añade las fuentes necesarias](/slides/es/python-net/custom-font/) al entorno de ejecución.

**¿Qué pasa con los medios incrustados (vídeo/audio) al abrir?**

Se convierten en recursos de la presentación. Si los medios se hacen referencia mediante rutas externas, asegúrate de que esas rutas sean accesibles en tu entorno; de lo contrario, la [renderización/exportación](/slides/es/python-net/convert-presentation/) puede omitir los medios.