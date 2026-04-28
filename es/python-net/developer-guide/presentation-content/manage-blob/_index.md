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
description: "Gestionar datos BLOB en Aspose.Slides para Python mediante .NET para optimizar operaciones con archivos PowerPoint y OpenDocument y lograr un manejo eficiente de presentaciones."
---
## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios.  

Aspose.Slides para Python mediante .NET le permite utilizar BLOBs para objetos de forma que reduce el consumo de memoria cuando se manejan archivos grandes.  

## **Usar BLOB para reducir el consumo de memoria**

### **Agregar un archivo grande mediante BLOB a una presentación**

Aspose.Slides para .NET le permite agregar archivos grandes (en este caso, un archivo de video de gran tamaño) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este fragmento de Python muestra cómo agregar un archivo de video grande mediante el proceso BLOB a una presentación:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Crea una nueva presentación a la que se añadirá el vídeo
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Añadamos el vídeo a la presentación - elegimos el comportamiento KeepLocked porque
        # no tenemos intención de acceder al archivo "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        # permanece bajo a lo largo del ciclo de vida del objeto pres
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Exportar un archivo grande mediante BLOB desde una presentación**
Aspose.Slides para Python mediante .NET le permite exportar archivos grandes (en este caso, un archivo de audio o video) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo multimedia grande de una presentación pero no desea que el archivo se cargue en la memoria de su ordenador. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria. 

Este código en Python muestra la operación descrita:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Guardemos cada vídeo en un archivo. Para evitar un uso elevado de memoria, necesitamos un búfer que se usará
	# para transferir los datos del flujo de vídeo de la presentación a un flujo para un archivo de vídeo recién creado.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Recorre los vídeos
    index = 0
    # Si es necesario, puede aplicar los mismos pasos a los archivos de audio.
    for video in pres.videos:
		# Abre el flujo de vídeo de la presentación. Tenga en cuenta que evitamos intencionadamente acceder a propiedades
		# como video.BinaryData, porque esa propiedad devuelve una matriz de bytes que contiene todo el vídeo, lo que
		# obliga a cargar los bytes en memoria. Usamos video.GetStream, que devuelve un Stream y NO
		# requiere cargar todo el vídeo en la memoria.
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

### **Agregar una imagen como BLOB en la presentación**
Con los métodos de la clase [**ImageCollection**](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/), puede agregar una imagen grande como flujo para que sea tratada como un BLOB. 

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

Normalmente, para cargar una presentación grande, los ordenadores requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del que se cargó la presentación) deja de utilizarse. 

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de video de 1,5 GB. El método estándar para cargar la presentación se describe en este código Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Sin embargo, este método consume alrededor de 1,6 GB de memoria temporal. 

### **Cargar una presentación grande como BLOB**

Mediante el proceso que implica un BLOB, puede cargar una presentación grande utilizando poca memoria. Este código Python describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

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

Cuando se usa el proceso BLOB, el ordenador crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta distinta, puede cambiar la configuración de almacenamiento usando `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
Cuando utiliza `temp_files_root_path`, Aspose.Slides no crea automáticamente una carpeta para almacenar los archivos temporales. Debe crear la carpeta manualmente. 
{{% /alert %}}

### **Eliminar objetos de presentación para liberar memoria**

Al procesar presentaciones grandes, asegúrese de que la instancia `Presentation` se elimine correctamente para que la memoria que ocupaba se libere. La forma recomendada es usar el gestor de contexto (`with slides.Presentation(...) as presentation:`) como se muestra en los ejemplos anteriores; cierra automáticamente la presentación y libera los recursos no administrados al salir del bloque.

Si crea una presentación sin un bloque `with`, llame explícitamente a `presentation.dispose()` después de haberla usado y elimine cualquier referencia restante para que el recolector de basura de Python pueda recuperar la memoria.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")
# ...procese la presentación...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)
# Libere explícitamente los recursos.
presentation.dispose()
```

## **FAQ**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y se controlan mediante opciones BLOB?**  
Los objetos binarios grandes, como imágenes, audio y video, se tratan como BLOB. Todo el archivo de la presentación también implica la gestión de BLOB al cargarse o guardarse. Estos objetos están regidos por políticas BLOB que le permiten controlar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de gestión de BLOB al cargar una presentación?**  
Utilice [LoadOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/blobmanagementoptions/). Allí establece el límite de memoria para BLOB, permite o prohíbe los archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de la fuente.

**¿Afectan los ajustes de BLOB al rendimiento y cómo equilibrar velocidad vs memoria?**  
Sí. Mantener BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria transfiere más trabajo a archivos temporales, reduciendo la RAM a costa de mayor I/O. Ajuste el umbral [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/es/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) para lograr el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones BLOB al abrir presentaciones extremadamente grandes (p. ej., de varios gigabytes)?**  
Sí. [BlobManagementOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/blobmanagementoptions/) están diseñados para esos escenarios: habilitar archivos temporales y usar el bloqueo de la fuente puede reducir significativamente el consumo máximo de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas BLOB al cargar desde streams en lugar de archivos en disco?**  
Sí. Las mismas reglas se aplican a los streams: la instancia de presentación puede poseer y bloquear el stream de entrada (según el modo de bloqueo seleccionado), y se utilizan archivos temporales cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.