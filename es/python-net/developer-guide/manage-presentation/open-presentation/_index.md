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
description: "Aprenda a abrir presentaciones PowerPoint y OpenDocument en Python, suministre contraseñas de apertura y reduzca el uso de memoria con Aspose.Slides para Python vía .NET."
---
## **Introducción**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/es/python-net/) puede cargar presentaciones PowerPoint y OpenDocument desde archivos y flujos. Después de que se carga una presentación, puedes inspeccionar su estructura, editar diapositivas, gestionar recursos y guardarla en el formato original u otro formato compatible.

El comportamiento de carga puede personalizarse mediante la clase [LoadOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/). Por ejemplo, puedes proporcionar una contraseña de apertura, mantener grandes objetos binarios fuera de la memoria o omitir datos binarios incrustados.

## **Abrir presentaciones**

Después de cargar un archivo o flujo, puedes [determinar su formato de presentación original](/slides/es/python-net/detect-presentation-source-format/) para elegir cómo procesa tu aplicación.

Para abrir una presentación existente, pasa su ruta de archivo al constructor [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/). Usa una sentencia `with` para que los manejadores de archivo, los datos temporales y otros recursos se liberen rápidamente.

El siguiente ejemplo en Python muestra cómo abrir una presentación y obtener el número de diapositivas:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Abrir presentaciones protegidas con contraseña**

Una contraseña de apertura cifra el contenido de la presentación. Para cargar la presentación completa, asigna la contraseña correcta a [LoadOptions.password](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/password/) y pasa las opciones al constructor [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/). La carga falla cuando la contraseña falta o es incorrecta.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Para la detección, validación y flujos de trabajo de cifrado de contraseñas, consulta [Presentaciones protegidas con contraseña](/slides/es/python-net/password-protected-presentation/). Si una presentación cifrada se guardó deliberadamente con propiedades de documento públicas, esas propiedades pueden leerse sin contraseña; consulta [Gestionar propiedades de la presentación](/slides/es/python-net/presentation-properties/).

## **Abrir presentaciones grandes**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/blob_management_options/) controla cómo Aspose.Slides gestiona los objetos binarios grandes (BLOB) como imágenes, audio y vídeo. Puedes mantener el archivo fuente bloqueado, permitir archivos temporales y limitar la cantidad de datos BLOB retenidos en memoria.

Este código Python muestra cómo cargar una presentación grande (por ejemplo, 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}

Con `PresentationLockingBehavior.KEEP_LOCKED`, el archivo fuente permanece bloqueado hasta que se elimine el objeto `Presentation`. No muevas, sobrescribas ni elimines el archivo fuente mientras ese objeto esté activo.

Aspose.Slides puede copiar el contenido de un flujo de entrada al cargarlo. Para presentaciones grandes, una ruta de archivo es generalmente más eficiente que un flujo. Consulta [Gestionar BLOBs](/slides/es/python-net/manage-blob/) para opciones adicionales de almacenamiento y gestión de memoria.

{{% /alert %}}

## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación puede contener datos binarios incrustados que una aplicación no necesita o no desea conservar. Los ejemplos incluyen:

- Proyectos VBA, disponibles a través de [Presentation.vba_project](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/vba_project/);
- Datos OLE incrustados, disponibles a través de [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/es/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- Datos de controles ActiveX, disponibles a través de [Control.active_x_control_binary](https://reference.aspose.com/slides/es/python-net/aspose.slides/control/active_x_control_binary/).

Establece [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) en `True` para eliminar estos datos binarios al cargar. Guarda la presentación cargada para conservar el resultado saneado.

Esta opción reduce la exposición a cargas útiles incrustadas no deseadas, pero no es un sistema completo de detección de malware ni de sanitización de contenido.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Cómo puedo saber si un archivo está dañado y no se puede abrir?**

Aspose.Slides genera una excepción de análisis o de formato durante la carga. Maneja ese error por separado del error de contraseña incorrecta para que la aplicación pueda informar la causa con precisión.

**¿Qué ocurre si faltan las fuentes requeridas?**

La presentación aún puede cargarse, pero el renderizado y la exportación pueden sustituir fuentes. Puedes [configurar la sustitución de fuentes](/slides/es/python-net/font-substitution/) o [proporcionar fuentes personalizadas](/slides/es/python-net/custom-font/) para que la salida sea más predecible.

**¿La carga de una presentación también carga sus medios incrustados?**

El audio y vídeo incrustados quedan disponibles a través del modelo de objetos de la presentación. Los recursos externos se resuelven según el comportamiento predeterminado de carga de recursos y pueden no estar disponibles si sus ubicaciones no pueden accederse.