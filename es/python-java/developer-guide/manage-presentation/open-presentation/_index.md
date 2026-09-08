---
title: Abrir presentaciones en Python mediante Java
linktitle: Abrir presentación
type: docs
weight: 20
url: /es/python-java/open-presentation/
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
- Java
- Aspose.Slides
description: "Aprende a abrir presentaciones de PowerPoint y OpenDocument en Python mediante Java, proporcionar contraseñas de apertura, controlar la carga de recursos y reducir el uso de memoria con Aspose.Slides para Python mediante Java."
---
## **Introducción**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/es/python-java/) puede cargar presentaciones de PowerPoint y OpenDocument a partir de archivos y flujos. Después de cargar una presentación, puedes inspeccionar su estructura, editar diapositivas, gestionar recursos y guardarla en el formato original o en otro compatible.

El comportamiento de carga puede personalizarse mediante la clase [LoadOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/). Por ejemplo, puedes proporcionar una contraseña de apertura, mantener objetos binarios grandes fuera de la memoria del heap de Java, controlar recursos externos o omitir datos binarios incrustados.

## **Abrir presentaciones**

Para abrir una presentación existente, pasa su ruta de archivo al constructor de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/). Desecha la presentación después de usarla para que los manejadores de archivo, los datos temporales y otros recursos se liberen rápidamente.

El siguiente ejemplo en Python muestra cómo abrir una presentación y obtener el número de diapositivas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Abrir presentaciones protegidas con contraseña**

Una contraseña de apertura cifra el contenido de la presentación. Para cargar la presentación completa, pasa la contraseña correcta a [LoadOptions.setPassword](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setPassword) y proporciona las opciones al constructor de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/). La carga falla cuando la contraseña falta o es incorrecta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

Para la detección de contraseñas, validación y flujos de trabajo de cifrado, consulta [Password-Protect Presentations](/slides/es/python-java/password-protected-presentation/). Si una presentación cifrada se guardó deliberadamente con propiedades de documento públicas, esas propiedades pueden leerse sin contraseña; consulta [Manage Presentation Properties](/slides/es/python-java/presentation-properties/).

## **Abrir presentaciones grandes**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) devuelve opciones que controlan cómo Aspose.Slides maneja objetos binarios grandes como imágenes, audio y vídeo. Puedes mantener el archivo fuente bloqueado, permitir archivos temporales y limitar la cantidad de datos BLOB retenidos en memoria.

El siguiente código Python muestra cómo cargar una presentación grande (por ejemplo, 2 GB):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Con [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked), el archivo fuente permanece bloqueado hasta que la instancia de la presentación se deseche. No muevas, sobrescribas ni elimines el archivo fuente mientras esa instancia esté viva.

Aspose.Slides puede copiar el contenido de un flujo de entrada mientras lo carga. Para presentaciones grandes, una ruta de archivo suele ser más eficiente que un flujo. Consulta [Manage BLOBs](/slides/es/python-java/manage-blob/) para opciones adicionales de almacenamiento y gestión de memoria.
{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) acepta un proxy JPype que implementa la interfaz de devolución de llamada de carga de recursos de Java. La devolución de llamada puede suministrar datos de reemplazo, redirigir un recurso, usar el cargador predeterminado o omitir el recurso. Esto resulta útil cuando las presentaciones contienen imágenes externas que deben resolverse según reglas de seguridad o almacenamiento específicas de la aplicación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación puede contener datos binarios incrustados que una aplicación no necesita o no quiere conservar. Ejemplos incluyen:

- proyectos VBA, accesibles mediante [Presentation.getVbaProject](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getVbaProject);
- datos OLE incrustados, accesibles mediante [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- datos de controles ActiveX, accesibles mediante [Control.getActiveXControlBinary](https://reference.aspose.com/slides/es/python-java/aspose.slides/control/#getActiveXControlBinary).

Configura [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) a `True` para eliminar esos datos binarios al cargar. Guarda la presentación cargada para conservar el resultado sanitizado.

Esta opción reduce la exposición a cargas útiles incrustadas no deseadas, pero no constituye un sistema completo de detección de malware o de sanitización de contenido.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Cómo puedo saber que un archivo está corrupto y no se puede abrir?**

Aspose.Slides lanza una excepción de análisis o de formato durante la carga. Maneja ese fallo por separado del error de contraseña incorrecta para que la aplicación pueda informar la causa con precisión.

**¿Qué ocurre si faltan fuentes requeridas?**

La presentación aún puede cargarse, pero la representación y la exportación pueden sustituir fuentes. Puedes [configurar la sustitución de fuentes](/slides/es/python-java/font-substitution/) o [proporcionar fuentes personalizadas](/slides/es/python-java/custom-font/) para que la salida sea más predecible.

**¿Cargar una presentación también carga sus medios incrustados?**

Los audio y vídeo incrustados quedan disponibles a través del modelo de objetos de la presentación. Los recursos externos se resuelven según el comportamiento de carga de recursos configurado y pueden no estar disponibles si sus ubicaciones no pueden accederse.