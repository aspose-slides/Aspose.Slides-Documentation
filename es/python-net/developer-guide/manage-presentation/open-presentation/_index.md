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
description: "Abrir presentaciones PowerPoint (.pptx, .ppt) y OpenDocument (.odp) sin esfuerzo con Aspose.Slides para Python a través de .NET: rápido, fiable y con todas las funcionalidades."
---

## **Resumen**

Más allá de crear presentaciones de PowerPoint desde cero, Aspose.Slides también le permite abrir presentaciones existentes. Después de cargar una presentación, puede obtener información sobre ella, editar el contenido de las diapositivas, añadir nuevas diapositivas, eliminar las existentes y mucho más.

## **Abrir presentaciones**

Para abrir una presentación existente, instancia la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y pasa la ruta del archivo a su constructor.

El siguiente ejemplo en Python muestra cómo abrir una presentación y obtener el número de diapositivas:
```python
import aspose.slides as slides

# Instanciar la clase Presentation y pasar una ruta de archivo a su constructor.
with slides.Presentation("sample.pptx") as presentation:
    # Imprimir el número total de diapositivas de la presentación.
    print(presentation.slides.length)
```


## **Abrir presentaciones protegidas con contraseña**

Cuando necesite abrir una presentación protegida con contraseña, pase la contraseña a través de la propiedad [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) de la clase [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) para descifrarla y cargarla. El siguiente código Python muestra esta operación:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Realizar operaciones en la presentación descifrada.
```


## **Abrir presentaciones grandes**

Aspose.Slides ofrece opciones —en particular la propiedad [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) en la clase [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)—para ayudarle a cargar presentaciones grandes.

Este código Python demuestra cómo cargar una presentación grande (por ejemplo, 2 GB):
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Elija el comportamiento KeepLocked—el archivo de presentación permanecerá bloqueado durante la vida útil de 
# la instancia Presentation, pero no necesita cargarse en memoria ni copiarse a un archivo temporal.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # La presentación grande se ha cargado y puede usarse, mientras el consumo de memoria sigue bajo.

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
Para sortear ciertas limitaciones al trabajar con flujos, Aspose.Slides puede copiar el contenido de un flujo. Cargar una presentación grande desde un flujo provoca que la presentación se copie y puede ralentizar la carga. Por lo tanto, cuando necesite cargar una presentación grande, recomendamos encarecidamente usar la ruta del archivo de la presentación en lugar de un flujo.

Al crear una presentación que contiene objetos grandes (vídeo, audio, imágenes de alta resolución, etc.), puede utilizar la [gestión de BLOB](/slides/es/python-net/manage-blob/) para reducir el consumo de memoria.
{{%/alert %}}

## **Controlar recursos externos**

Aspose.Slides proporciona la clase [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) que le permite gestionar recursos externos. El siguiente código Python muestra cómo usar la clase `IResourceLoadingCallback`:
```python
# [TODO[not_supported_yet]: implementación en python de interfaces .NET]
```


## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación de PowerPoint puede contener los siguientes tipos de objetos binarios incrustados:

- Proyecto VBA (accesible a través de [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- Datos incrustados de objetos OLE (accesibles a través de [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- Datos binarios de controles ActiveX (accesibles a través de [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

Utilizando la propiedad [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/), puede cargar una presentación sin ningún objeto binario incrustado.

Esta propiedad es útil para eliminar contenido binario potencialmente malicioso. El siguiente código Python demuestra cómo cargar una presentación sin contenido binario incrustado:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Realizar operaciones en la presentación.
```


## **Preguntas frecuentes**

**¿Cómo puedo saber si un archivo está corrupto y no se puede abrir?**

Obtendrá una excepción de validación de análisis/formato durante la carga. Estos errores a menudo indican una estructura ZIP no válida o registros de PowerPoint dañados.

**¿Qué ocurre si faltan fuentes requeridas al abrir?**

El archivo se abrirá, pero posteriormente la [representación/exportación](/slides/es/python-net/convert-presentation/) puede sustituir fuentes. [Configure sustituciones de fuentes](/slides/es/python-net/font-substitution/) o [añada las fuentes requeridas](/slides/es/python-net/custom-font/) al entorno de ejecución.

**¿Qué pasa con los medios incrustados (vídeo/audio) al abrir?**

Se convierten en recursos de la presentación. Si los medios se referencian mediante rutas externas, asegúrese de que esas rutas sean accesibles en su entorno; de lo contrario, la [representación/exportación](/slides/es/python-net/convert-presentation/) puede omitir los medios.