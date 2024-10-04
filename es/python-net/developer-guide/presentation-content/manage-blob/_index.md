---
title: Gestionar BLOB
type: docs
weight: 10
url: /es/python-net/manage-blob/
keywords: "Agregar blob, Exportar blob, Agregar imagen como blob, Presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar blob a la presentación de PowerPoint en Python. Exportar blob. Agregar imagen como blob"
---

### **Acerca de BLOB**

**BLOB** (**Objeto Binario Grande**) es generalmente un artículo grande (foto, presentación, documento o medio) guardado en formatos binarios.

Aspose.Slides para Python a través de .NET te permite usar BLOBs para objetos de una manera que reduce el consumo de memoria cuando se involucran archivos grandes.

# **Usar BLOB para Reducir el Consumo de Memoria**

### **Agregar Archivo Grande a través de BLOB a una Presentación**

[Aspose.Slides](/slides/es/python-net/) para .NET te permite agregar archivos grandes (en este caso, un archivo de video grande) a través de un proceso que involucra BLOBs para reducir el consumo de memoria.

Este código de Python te muestra cómo agregar un archivo de video grande a través del proceso BLOB a una presentación:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Crea una nueva presentación a la que se agregará el video
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Agreguemos el video a la presentación - elegimos el comportamiento KeepLocked porque no
        # pretendemos acceder al archivo "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        # se mantiene bajo durante el ciclo de vida del objeto pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Exportar Archivo Grande a Través de BLOB desde la Presentación**
Aspose.Slides para Python a través de .NET te permite exportar archivos grandes (en este caso, un archivo de audio o video) a través de un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puedes necesitar extraer un archivo de medios grande de una presentación pero no quieres que el archivo se cargue en la memoria de tu computadora. Al exportar el archivo a través del proceso BLOB, logras mantener bajo el consumo de memoria.

Este código en Python demuestra la operación descrita:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Guardemos cada video en un archivo. Para prevenir un alto uso de memoria, necesitamos un búfer que se usará
	# para transferir los datos desde el flujo de video de la presentación a un flujo para un nuevo archivo de video creado.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Itera a través de los videos
    index = 0
    # Si es necesario, puedes aplicar los mismos pasos para archivos de audio. 
    for video in pres.videos:
		# Abre el flujo de video de la presentación. Por favor, nota que evitamos intencionalmente acceder a propiedades
		# como video.BinaryData - porque esta propiedad devuelve un arreglo de bytes que contiene un video completo, lo que luego
		# causa que los bytes se carguen en la memoria. Usamos video.GetStream, que devolverá Stream - y NO
		# requiere que carguemos todo el video en la memoria.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Agregar Imagen como BLOB en la Presentación**
Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) y la clase [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/), puedes agregar una imagen grande como un flujo para que sea tratada como un BLOB.

Este código de Python te muestra cómo agregar una imagen grande a través del proceso BLOB:

```py
import aspose.slides as slides

# crea una nueva presentación a la que se agregará la imagen.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Memoria y Presentaciones Grandes**

Típicamente, para cargar una presentación grande, las computadoras requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del cual se cargó la presentación) deja de usarse.

Considera una presentación grande de PowerPoint (large.pptx) que contiene un archivo de video de 1.5 GB. El método estándar para cargar la presentación se describe en este código de Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Pero este método consume alrededor de 1.6 GB de memoria temporal.

### **Cargar una Presentación Grande como BLOB**

A través del proceso que involucra un BLOB, puedes cargar una presentación grande mientras usas poca memoria. Este código de Python describe la implementación donde se utiliza el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

#### **Cambiar la Carpeta para Archivos Temporales**

Cuando se utiliza el proceso BLOB, tu computadora crea archivos temporales en la carpeta predeterminada para archivos temporales. Si deseas que los archivos temporales se mantengan en una carpeta diferente, puedes cambiar la configuración de almacenamiento usando `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}

Cuando utilizas `temp_files_root_path`, Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Debes crear la carpeta manualmente. 

{{% /alert %}}