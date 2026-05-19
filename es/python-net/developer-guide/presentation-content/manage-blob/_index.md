---
title: Gestionar BLOBs en presentaciones con Python para un uso eficiente de la memoria
linktitle: Gestionar BLOB
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
description: Gestiona datos BLOB en Aspose.Slides para Python vía .NET para optimizar operaciones con archivos PowerPoint y OpenDocument y lograr un manejo eficiente de presentaciones.
---
## **Visión general**

Aspose.Slides proporciona manejo basado en BLOB para datos binarios grandes en presentaciones, ayudando a reducir el consumo de memoria al trabajar con imágenes, audio, vídeo y archivos de presentación de gran tamaño.

Este artículo muestra cómo usar el procesamiento basado en BLOB para agregar medios grandes a una presentación, exportar medios grandes desde una presentación y cargar presentaciones grandes de forma más eficiente. También explica cómo se pueden usar archivos temporales durante el procesamiento y cómo cambiar la carpeta utilizada para almacenarlos.

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios.  

Aspose.Slides for Python via .NET le permite usar BLOBs para objetos de manera que se reduzca el consumo de memoria cuando se manejan archivos grandes.

## **Usar BLOB para reducir el consumo de memoria**

### **Agregar un archivo grande mediante BLOB a una presentación**

[Aspose.Slides](/slides/es/python-net/) para .NET le permite agregar archivos grandes (en este caso, un archivo de vídeo grande) mediante un proceso que implica BLOBs para reducir el consumo de memoria.

Este ejemplo en Python le muestra cómo agregar un archivo de vídeo grande mediante el proceso BLOB a una presentación:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Crea una nueva presentación a la que se añadirá el vídeo
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Añadamos el vídeo a la presentación - elegimos el comportamiento KeepLocked porque
        # no pretendemos acceder al archivo "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        # se mantiene bajo durante el ciclo de vida del objeto pres
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Exportar un archivo grande mediante BLOB desde una presentación**

Aspose.Slides for Python via .NET le permite exportar archivos grandes (en este caso, un archivo de audio o vídeo) mediante un proceso que implica BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo de medios grande de una presentación sin que el archivo se cargue en la memoria de su equipo. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria.

Este código en Python demuestra la operación descrita:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Guardemos cada vídeo en un archivo. Para evitar un alto consumo de memoria, necesitamos un búfer que se utilice
	# para transferir los datos del flujo de vídeo de la presentación a un flujo para un archivo de vídeo recién creado.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Itera a través de los vídeos
    index = 0
    # Si es necesario, puedes aplicar los mismos pasos para archivos de audio. 
    for video in pres.videos:
		# Abre el flujo de vídeo de la presentación. Por favor, ten en cuenta que evitamos intencionalmente acceder a propiedades
		# como video.BinaryData - porque esta propiedad devuelve un array de bytes que contiene el vídeo completo, lo que entonces
		# causa que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá Stream y NO
		#  requiere que carguemos el vídeo completo en la memoria.
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

### **Agregar imagen como BLOB en la presentación**

Con los métodos de la clase [**ImageCollection**](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/) puede agregar una imagen grande como flujo para que se trate como un BLOB.  

Este código en Python le muestra cómo agregar una imagen grande mediante el proceso BLOB:

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

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de vídeo de 1,5 GB. El método estándar para cargar la presentación se describe en este código Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Pero este método consume alrededor de 1,6 GB de memoria temporal.  

### **Cargar una presentación grande como BLOB**

Mediante un proceso que implica un BLOB, puede cargar una presentación grande usando poca memoria. Este código Python describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

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

Cuando se utiliza el proceso BLOB, el equipo crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta diferente, puede cambiar la configuración de almacenamiento usando `temp_files_root_path`:

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

### **Liberar objetos de presentación para liberar memoria**

Al procesar presentaciones grandes, asegúrese de que la instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) se libere correctamente para que se libere la memoria que ocupaba. La forma recomendada es usar el gestor de contexto (`with slides.Presentation(...) as presentation:`) como se muestra en los ejemplos anteriores; cierra automáticamente la presentación y libera los recursos no administrados cuando se sale del bloque.

Si crea una presentación sin un bloque `with`, llame explícitamente a `presentation.dispose()` después de haber terminado de usarla y elimine cualquier referencia restante para que el recolector de basura de Python pueda recuperar la memoria.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...procesar la presentación...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Libere explícitamente los recursos.
presentation.dispose()
```

## **FAQ**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y son controlados por las opciones de BLOB?**  

Objetos binarios grandes como imágenes, audio y vídeo se tratan como BLOB. El archivo completo de la presentación también implica manejo BLOB cuando se carga o guarda. Estos objetos están regulados por políticas BLOB que le permiten gestionar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo BLOB durante la carga de la presentación?**  

Use [LoadOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o no los archivos temporales, elige la ruta raíz para archivos temporales y selecciona el comportamiento de bloqueo de la fuente.

**¿Los ajustes BLOB afectan al rendimiento y cómo equilibrar velocidad vs. memoria?**  

Sí. Mantener BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria desplaza más trabajo a archivos temporales, disminuyendo la RAM a costa de I/O adicional. Ajuste el umbral [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/es/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) para alcanzar el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones BLOB al abrir presentaciones extremadamente grandes (p. ej., gigabytes)?**  

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar bloqueo de fuente puede reducir significativamente el uso máximo de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas BLOB al cargar desde streams en lugar de archivos en disco?**  

Sí. Las mismas reglas se aplican a streams: la instancia de presentación puede poseer y bloquear el stream de entrada (según el modo de bloqueo elegido), y se utilizan archivos temporales cuando están permitidos, manteniendo el uso de memoria predecible durante el procesamiento.