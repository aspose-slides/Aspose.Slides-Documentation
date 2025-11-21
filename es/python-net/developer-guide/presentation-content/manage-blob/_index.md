---
title: Administrar BLOBs en presentaciones con Python para un uso eficiente de la memoria
linktitle: Administrar BLOB
type: docs
weight: 10
url: /es/python-net/manage-blob/
keywords:
- objeto grande
- elemento grande
- archivo grande
- agregar BLOB
- exportar BLOB
- agregar imagen como BLOB
- reducir memoria
- consumo de memoria
- presentación grande
- archivo temporal
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Administre los datos BLOB en Aspose.Slides para Python a través de .NET para optimizar las operaciones con archivos PowerPoint y OpenDocument y manejar presentaciones de manera eficiente."
---

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios. 

Aspose.Slides for Python a través de .NET le permite usar BLOBs para objetos de una manera que reduce el consumo de memoria cuando se manejan archivos grandes. 

## **Usar BLOB para reducir el consumo de memoria**

### **Agregar un archivo grande mediante BLOB a una presentación**

[Aspose.Slides](/slides/es/python-net/) para .NET le permite agregar archivos grandes (en este caso, un archivo de video grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este Python le muestra cómo agregar un archivo de video grande mediante el proceso BLOB a una presentación:
```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Crea una nueva presentación a la que se añadirá el vídeo
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Añadamos el vídeo a la presentación - elegimos el comportamiento KeepLocked porque no
        # pretendemos acceder al archivo "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        # se mantiene bajo durante el ciclo de vida del objeto pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```



### **Exportar un archivo grande mediante BLOB desde una presentación**
Aspose.Slides for Python a través de .NET le permite exportar archivos grandes (en este caso, un archivo de audio o video) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo multimedia grande de una presentación pero no desea que el archivo se cargue en la memoria de su computadora. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria. 

Este código en Python demuestra la operación descrita:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Guardemos cada video en un archivo. Para evitar un alto consumo de memoria, necesitamos un búfer que será usado
	# para transferir los datos del flujo de video de la presentación a un flujo para un nuevo archivo de video creado.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Recorre los videos
    index = 0
    # Si es necesario, puedes aplicar los mismos pasos para archivos de audio. 
    for video in pres.videos:
		# Abre el flujo de video de la presentación. Por favor, ten en cuenta que evitamos intencionalmente acceder a propiedades
		# como video.BinaryData - porque esta propiedad devuelve una matriz de bytes que contiene el video completo, lo que luego
		# causa que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá Stream - y NO
		#  requiere que carguemos el video completo en la memoria.
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


### **Agregar una imagen como BLOB en una presentación**
Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) y de la clase [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) puede agregar una imagen grande como flujo para que se trate como un BLOB. 

Este código Python le muestra cómo agregar una imagen grande mediante el proceso BLOB:
```py
import aspose.slides as slides

# crea una nueva presentación a la que se añadirá la imagen.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```


## **Memoria y presentaciones grandes**

Normalmente, para cargar una presentación grande, los equipos requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del cual se cargó la presentación) deja de usarse. 

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de video de 1,5 GB. El método estándar para cargar la presentación se describe en este código Python:
```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


Pero este método consume aproximadamente 1,6 GB de memoria temporal. 

### **Cargar una presentación grande como BLOB**

Mediante el proceso que involucra un BLOB, puede cargar una presentación grande usando poca memoria. Este código Python describe la implementación donde se utiliza el proceso BLOB para cargar un archivo de presentación grande (large.pptx):
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


### **Cambiar la carpeta para archivos temporales**

Cuando se usa el proceso BLOB, su equipo crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta diferente, puede cambiar la configuración de almacenamiento usando `temp_files_root_path`:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```


{{% alert title="Info" color="info" %}}
Al usar `temp_files_root_path`, Aspose.Slides no crea automáticamente una carpeta para almacenar los archivos temporales. Debe crear la carpeta manualmente. 
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y están controlados por las opciones de BLOB?**

Los objetos binarios grandes, como imágenes, audio y video, se tratan como BLOB. Todo el archivo de la presentación también implica el manejo de BLOB cuando se carga o se guarda. Estos objetos están regidos por políticas de BLOB que le permiten administrar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo de BLOB al cargar una presentación?**

Utilice [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o prohibe los archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de origen.

**¿Afectan los ajustes de BLOB al rendimiento y cómo balanceo velocidad vs memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria transfiere más trabajo a archivos temporales, disminuyendo la RAM a costa de un mayor I/O. Ajuste el umbral [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) para lograr el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones de BLOB al abrir presentaciones extremadamente grandes (p.ej., gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) están diseñados para esos escenarios: habilitar archivos temporales y usar bloqueo de origen puede reducir significativamente el uso máximo de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas de BLOB al cargar desde flujos en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a los flujos: la instancia de la presentación puede poseer y bloquear el flujo de entrada (según el modo de bloqueo elegido), y se utilizan archivos temporales cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.