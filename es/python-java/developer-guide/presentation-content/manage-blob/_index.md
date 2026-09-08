---
title: Gestionar BLOBs de presentación en Python mediante Java para un uso eficiente de la memoria
linktitle: Gestionar BLOB
type: docs
weight: 10
url: /es/python-java/manage-blob/
keywords:
- objeto grande
- elemento grande
- archivo grande
- añadir BLOB
- exportar BLOB
- añadir imagen como BLOB
- reducir memoria
- consumo de memoria
- presentación grande
- archivo temporal
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Gestionar datos BLOB en Aspose.Slides para Python mediante Java para agilizar las operaciones con archivos PowerPoint y OpenDocument y lograr un manejo eficiente de presentaciones."
---
## **Visión general**

Aspose.Slides ofrece manejo basado en BLOB para datos binarios grandes en presentaciones, ayudando a reducir el consumo de memoria al trabajar con imágenes, audio, vídeo y archivos de presentación de gran tamaño.

Este artículo muestra cómo usar el procesamiento basado en BLOB para añadir medios grandes a una presentación, exportar medios grandes desde una presentación y cargar presentaciones grandes de forma más eficiente. También explica cómo se pueden usar archivos temporales durante el procesamiento y cómo cambiar la carpeta utilizada para almacenarlos.

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios.

Aspose.Slides for Python via Java le permite usar BLOBs para objetos de manera que se reduzca el consumo de memoria cuando intervienen archivos grandes.

{{% alert color="info" title="Nota" %}}
Para eludir ciertas limitaciones al interactuar con flujos, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo provocará la copia del contenido de la presentación y provocará una carga lenta. Por lo tanto, cuando pretenda cargar una presentación grande, le recomendamos encarecidamente que use la ruta del archivo de la presentación y no su flujo.
{{% /alert %}}

## **Usar BLOB para reducir el consumo de memoria**

### **Agregar un archivo grande mediante BLOB a una presentación**

[Aspose.Slides](/slides/es/python-java/) for Python via Java le permite agregar archivos grandes (en este caso, un archivo de vídeo grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este código Python le muestra cómo agregar un archivo de vídeo grande mediante el proceso BLOB a una presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Crear una nueva presentación a la que se añadirá el vídeo.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Mantener el flujo bloqueado porque no pretendemos acceder al archivo de vídeo.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Guardar la presentación manteniendo bajo el consumo de memoria.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Exportar un archivo grande mediante BLOB desde la presentación**

Aspose.Slides for Python via Java le permite exportar archivos grandes (en este caso, un archivo de audio o vídeo) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo de medio grande de una presentación pero no quiere que el archivo se cargue en la memoria de su computadora. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria.

Este código en Python demuestra la operación descrita:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Bloquear el archivo fuente en lugar de cargarlo en memoria.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Transferir los datos de vídeo a través de un búfer para mantener bajo el consumo de memoria.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Usar el flujo en lugar de cargar todo el vídeo en una matriz de bytes.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # Si es necesario, aplicar los mismos pasos a los archivos de audio.
finally:
    presentation.dispose()
```

### **Agregar una imagen como BLOB a una presentación**

Con los métodos de la clase [ImageCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagecollection/) puede agregar una imagen grande como flujo para que se trate como un BLOB.

Este código Python le muestra cómo agregar una imagen grande mediante el proceso BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Crear una nueva presentación a la que se añadirá la imagen.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Mantener el flujo bloqueado porque no pretendemos acceder al archivo de imagen.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Guardar la presentación manteniendo bajo el consumo de memoria.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Memoria y presentaciones grandes**

Normalmente, para cargar una presentación grande, los equipos requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del que se cargó la presentación) deja de usarse.

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de vídeo de 1,5 GB. El método estándar para cargar la presentación se describe en este código Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Pero este método consume alrededor de 1,6 GB de memoria temporal.

### **Cargar una presentación grande como BLOB**

A través del proceso que involucra un BLOB, puede cargar una presentación grande usando poca memoria. Este código Python describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Cambiar la carpeta para archivos temporales**

Cuando se usa el proceso BLOB, su equipo crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta diferente, puede cambiar la configuración de almacenamiento usando [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Nota" %}}
Al usar [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Debe crear la carpeta manualmente.
{{% /alert %}}

### **Liberar los objetos Presentation para liberar memoria**

Al procesar presentaciones grandes, asegúrese de que la instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) se libere correctamente para que la memoria que ocupaba se libere. Llame a [Presentation.dispose](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#dispose) después de terminar de usar la presentación para liberar recursos no administrados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...procesar la presentación...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Liberar explícitamente los recursos.
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y son controlados por las opciones de BLOB?**

Objetos binarios grandes como imágenes, audio y vídeo se tratan como BLOB. El archivo completo de la presentación también implica manejo de BLOB cuando se carga o guarda. Estos objetos están regidos por políticas de BLOB que le permiten gestionar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo de BLOB durante la carga de la presentación?**

Utilice [LoadOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o prohibe archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de origen.

**¿Afectan los ajustes de BLOB al rendimiento, y cómo equilibrar velocidad vs. memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria transfiere más trabajo a archivos temporales, disminuyendo la RAM a costa de I/O adicional. Use el método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/es/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) para encontrar el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones de BLOB al abrir presentaciones extremadamente grandes (p. ej., gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar el bloqueo de origen puede reducir significativamente el uso máximo de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas de BLOB al cargar desde flujos en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a los flujos: la instancia de presentación puede poseer y bloquear el flujo de entrada (según el modo de bloqueo elegido), y se usan archivos temporales cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.