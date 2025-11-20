---
title: Abrir una presentación en Python
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
description: "Abra presentaciones PowerPoint (.pptx, .ppt) y OpenDocument (.odp) sin esfuerzo con Aspose.Slides para Python a través de .NET—rápido, fiable, con todas las funciones."
---

## **Visión general**

Más allá de crear presentaciones de PowerPoint desde cero, Aspose.Slides también le permite abrir presentaciones existentes. Después de cargar una presentación, puede obtener información sobre ella, editar el contenido de las diapositivas, agregar nuevas diapositivas, eliminar las existentes y más.

## **Abrir presentaciones**

Para abrir una presentación existente, cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y pase la ruta del archivo a su constructor.

El siguiente ejemplo en Python muestra cómo abrir una presentación y obtener el recuento de diapositivas:
```python
import aspose.slides as slides

# Instancie la clase Presentation y pase una ruta de archivo a su constructor.
with slides.Presentation("sample.pptx") as presentation:
    # Imprima el número total de diapositivas en la presentación.
    print(presentation.slides.length)
```


## **Abrir presentaciones protegidas con contraseña**

Cuando necesite abrir una presentación protegida con contraseña, pase la contraseña a través de la propiedad [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) de la clase [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) para descifrarla y cargarla. El siguiente código en Python demuestra esta operación:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Realice operaciones en la presentación descifrada.
```


## **Abrir presentaciones grandes**

Aspose.Slides proporciona opciones—en particular la propiedad [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) en la clase [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)—para ayudarle a cargar presentaciones grandes.

Este código en Python demuestra cómo cargar una presentación grande (por ejemplo, 2 GB):
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Elija el comportamiento KeepLocked—el archivo de la presentación permanecerá bloqueado durante la vida útil de 
# la instancia Presentation, pero no necesita cargarse en memoria ni copiarse a un archivo temporal.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # La gran presentación se ha cargado y puede usarse, mientras el consumo de memoria sigue bajo.

    # Realice cambios en la presentación.
    presentation.slides[0].name = "Large presentation"

    # Guarde la presentación en otro archivo. El consumo de memoria sigue bajo durante esta operación.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # ¡No haga esto! Se lanzará una excepción de E/S porque el archivo está bloqueado hasta que se libere el objeto Presentation.
    os.remove(file_path)

# Está bien hacerlo aquí. El archivo origen ya no está bloqueado por el objeto Presentation.
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
Para sortear ciertas limitaciones al trabajar con streams, Aspose.Slides puede copiar el contenido de un stream. Cargar una presentación grande desde un stream hace que la presentación se copie y puede ralentizar la carga. Por lo tanto, cuando necesite cargar una presentación grande, recomendamos encarecidamente usar la ruta del archivo de la presentación en lugar de un stream.

Al crear una presentación que contiene objetos grandes (video, audio, imágenes de alta resolución, etc.), puede usar [BLOB management](/slides/es/python-net/manage-blob/) para reducir el consumo de memoria.
{{%/alert %}}

## **Controlar recursos externos**

Aspose.Slides proporciona la interfaz [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) que le permite gestionar recursos externos. El siguiente código en Python muestra cómo usar la interfaz `IResourceLoadingCallback`:
```python
# [TODO[not_supported_yet]: implementación de interfaces .NET en Python]
```


## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación de PowerPoint puede contener los siguientes tipos de objetos binarios incrustados:

- proyecto VBA (accesible a través de [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- datos incrustados de objeto OLE (accesible a través de [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- datos binarios de control ActiveX (accesible a través de [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

Usando la propiedad [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/), puede cargar una presentación sin ningún objeto binario incrustado.

Esta propiedad es útil para eliminar contenido binario potencialmente malicioso. El siguiente código en Python demuestra cómo cargar una presentación sin contenido binario incrustado:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Realice operaciones en la presentación.
```


## **Preguntas frecuentes**

**¿Cómo puedo saber que un archivo está corrupto y no se puede abrir?**

Obtendrá una excepción de validación de análisis/formato durante la carga. dichos errores a menudo mencionan una estructura ZIP no válida o registros de PowerPoint rotos.

**¿Qué ocurre si faltan fuentes requeridas al abrir?**

El archivo se abrirá, pero más adelante la [renderización/exportación](/slides/es/python-net/convert-presentation/) puede sustituir fuentes. [Configure sustituciones de fuentes](/slides/es/python-net/font-substitution/) o [agregue las fuentes requeridas](/slides/es/python-net/custom-font/) al entorno de ejecución.

**¿Qué pasa con los medios incrustados (video/audio) al abrir?**

Se convierten en recursos de la presentación. Si los medios se referencian a través de rutas externas, asegúrese de que esas rutas sean accesibles en su entorno; de lo contrario la [renderización/exportación](/slides/es/python-net/convert-presentation/) puede omitir los medios.