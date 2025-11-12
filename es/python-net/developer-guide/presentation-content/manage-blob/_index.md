---
title: Administrar BLOBs en Presentaciones con Python para un Uso Eficiente de la Memoria
linktitle: Administrar BLOB
type: docs
weight: 10
url: /es/python-net/manage-blob/
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
- Aspose.Slides
description: "Gestionar datos BLOB en Aspose.Slides para Python mediante .NET para optimizar operaciones de archivos PowerPoint y OpenDocument y manejar presentaciones de forma eficiente."
---

## **Acerca de BLOB**

**BLOB** (**Objeto Binario Grande**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios.  

Aspose.Slides for Python via .NET le permite usar BLOBs para objetos de modo que se reduzca el consumo de memoria cuando se manejan archivos grandes.  

## **Usar BLOB para reducir el consumo de memoria**

### **Añadir archivo grande mediante BLOB a una presentación**

[Aspose.Slides](/slides/es/python-net/) para .NET le permite añadir archivos grandes (en este caso, un archivo de vídeo grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.  

Este fragmento en Python le muestra cómo añadir un archivo de vídeo grande mediante el proceso BLOB a una presentación:

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

### **Exportar archivo grande mediante BLOB desde la presentación**

Aspose.Slides for Python via .NET permite exportar archivos grandes (en este caso, un archivo de audio o vídeo) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo multimedia grande de una presentación pero no desea que el archivo se cargue en la memoria del equipo. Exportando el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria.  

Este código en Python demuestra la operación descrita:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Guardemos cada vídeo en un archivo. Para evitar un alto uso de memoria, necesitamos un búfer que se usará
	# para transferir los datos del flujo de vídeo de la presentación a un flujo para un archivo de vídeo recién creado.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Itera a través de los vídeos
    index = 0
    # Si es necesario, puede aplicar los mismos pasos para archivos de audio. 
    for video in pres.videos:
		# Abre el flujo de vídeo de la presentación. Tenga en cuenta que intencionalmente evitamos acceder a propiedades
		# como video.BinaryData - porque esta propiedad devuelve un arreglo de bytes que contiene el vídeo completo, lo que entonces
		# hace que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá Stream y NO
		# requiere que carguemos todo el vídeo en la memoria.
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

### **Añadir imagen como BLOB en la presentación**

Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) y la clase [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) puede añadir una imagen grande como flujo para que sea tratada como BLOB.  

Este código Python le muestra cómo añadir una imagen grande mediante el proceso BLOB:

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

Normalmente, para cargar una presentación grande, los equipos requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del que se cargó la presentación) deja de usarse.  

Considere una presentación PowerPoint grande (large.pptx) que contiene un archivo de vídeo de 1,5 GB. El método estándar para cargar la presentación se describe en este código Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Pero este método consume alrededor de 1,6 GB de memoria temporal.  

### **Cargar una presentación grande como BLOB**

A través del proceso que involucra un BLOB, puede cargar una presentación grande usando poca memoria. Este código Python describe la implementación donde se utiliza el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

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

{{% alert title="Información" color="info" %}}
Al usar `temp_files_root_path`, Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Debe crear la carpeta manualmente.  
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y son controlados por las opciones BLOB?**  

Los objetos binarios grandes como imágenes, audio y vídeo se tratan como BLOB. También todo el archivo de la presentación implica manejo de BLOB cuando se carga o guarda. Estos objetos están regidos por políticas BLOB que permiten gestionar el uso de memoria y volcar a archivos temporales cuando sea necesario.  

**¿Dónde configuro las reglas de manejo de BLOB durante la carga de la presentación?**  

Utilice [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o no archivos temporales, define la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de la fuente.  

**¿Afectan las configuraciones de BLOB al rendimiento, y cómo equilibrar velocidad vs memoria?**  

Sí. Mantener BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria desplaza más trabajo a archivos temporales, disminuyendo la RAM a costa de I/O adicional. Ajuste el umbral [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) para lograr el equilibrio adecuado según su carga de trabajo y entorno.  

**¿Ayudan las opciones BLOB al abrir presentaciones extremadamente grandes (por ejemplo, varios gigabytes)?**  

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar el bloqueo de la fuente puede reducir significativamente el pico de RAM y estabilizar el procesamiento de presentaciones muy grandes.  

**¿Puedo usar políticas BLOB al cargar desde streams en lugar de archivos en disco?**  

Sí. Las mismas reglas se aplican a streams: la instancia de la presentación puede poseer y bloquear el stream de entrada (según el modo de bloqueo seleccionado), y se usarán archivos temporales cuando estén permitidos, manteniendo predecible el uso de memoria durante el procesamiento.