---
title: Administrar BLOBs de presentación en Java para un uso eficiente de la memoria
linktitle: Administrar BLOB
type: docs
weight: 10
url: /es/java/manage-blob/
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
- Java
- Aspose.Slides
description: "Administre datos BLOB en Aspose.Slides para Java para optimizar operaciones de archivos PowerPoint y OpenDocument y manejar presentaciones de forma eficiente."
---

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios. 

Aspose.Slides for Java le permite usar BLOBs para objetos de manera que reduzca el consumo de memoria cuando se manejan archivos grandes. 

{{% alert title="Info" color="info" %}}
Para sortear ciertas limitaciones al interactuar con streams, Aspose.Slides puede copiar el contenido del stream. Cargar una presentación grande a través de su stream provocará la copia del contenido de la presentación y causará una carga lenta. Por lo tanto, cuando tenga la intención de cargar una presentación grande, recomendamos encarecidamente que use la ruta del archivo de la presentación y no su stream.
{{% /alert %}}

## **Usar BLOB para Reducir el Consumo de Memoria**

### **Agregar un Archivo Grande mediante BLOB a una Presentación**

[Aspose.Slides](/slides/es/java/) for Java permite agregar archivos grandes (en este caso, un archivo de video grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este ejemplo en Java muestra cómo agregar un archivo de video grande mediante el proceso BLOB a una presentación:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crea una nueva presentación a la que se añadirá el video
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Añadamos el video a la presentación - elegimos el comportamiento KeepLocked porque
        // no pretendemos acceder al archivo "veryLargeVideo.avi" file.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        // se mantiene bajo durante el ciclo de vida del objeto pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **Exportar un Archivo Grande mediante BLOB desde una Presentación**
Aspose.Slides for Java permite exportar archivos grandes (en este caso, un archivo de audio o video) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo multimedia grande de una presentación pero no quiere que el archivo se cargue en la memoria de su computadora. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria. 

Este código en Java demuestra la operación descrita:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Bloquea el archivo fuente y NO lo carga en memoria
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Crea la instancia de Presentation, bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Guardemos cada vídeo en un archivo. Para evitar un alto uso de memoria, necesitamos un búfer que se utilizará
    // para transferir los datos del flujo de vídeo de la presentación a un flujo para un archivo de vídeo recién creado.
    byte[] buffer = new byte[8 * 1024];

    // Recorre los vídeos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Abre el flujo de vídeo de la presentación. Por favor, tenga en cuenta que evitamos intencionalmente acceder a propiedades
        // como video.BinaryData - porque esta propiedad devuelve un array de bytes que contiene un vídeo completo, lo que luego
        // causa que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá Stream - y NO
        //  requiere que carguemos el vídeo completo en la memoria.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // El consumo de memoria se mantendrá bajo independientemente del tamaño del vídeo o de la presentación.
    }
    // Si es necesario, puede aplicar los mismos pasos para archivos de audio. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **Agregar Imagen como BLOB en la Presentación**
Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) y la clase [**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection), puede agregar una imagen grande como stream para que se trate como un BLOB. 

Este código en Java muestra cómo agregar una imagen grande mediante el proceso BLOB:
```java
String pathToLargeImage = "large_image.jpg";

// crea una nueva presentación a la que se añadirá la imagen.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Añadamos la imagen a la presentación - elegimos el comportamiento KeepLocked porque
		// NO pretendemos acceder al archivo "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
		// se mantiene bajo durante el ciclo de vida del objeto pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


## **Memoria y Presentaciones Grandes**

Normalmente, para cargar una presentación grande, los equipos requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del cual se cargó la presentación) deja de utilizarse. 

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de video de 1,5 GB. El método estándar para cargar la presentación se describe en este código Java:
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


Pero este método consume alrededor de 1,6 GB de memoria temporal. 

### **Cargar una Presentación Grande como BLOB**

A través del proceso que involucra un BLOB, puede cargar una presentación grande usando poca memoria. Este código Java describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Cambiar la Carpeta para Archivos Temporales**

Cuando se usa el proceso BLOB, su computadora crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta diferente, puede cambiar la configuración de almacenamiento usando `TempFilesRootPath`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
Al usar `TempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Tiene que crear la carpeta manualmente. 
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y se controlan mediante las opciones de BLOB?**

Objetos binarios grandes como imágenes, audio y video se tratan como BLOB. El archivo completo de la presentación también implica manejo de BLOB cuando se carga o se guarda. Estos objetos están regidos por políticas de BLOB que le permiten gestionar el uso de memoria y el desbordamiento a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo de BLOB durante la carga de la presentación?**

Utilice [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o prohíbe archivos temporales, elige la ruta raíz para archivos temporales y selecciona el comportamiento de bloqueo de la fuente.

**¿Afectan la configuración de BLOB al rendimiento y cómo equilibrar velocidad y memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero aumenta el consumo de RAM; reducir el límite de memoria desplaza más trabajo a archivos temporales, reduciendo la RAM a costa de I/O adicional. Use el método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) para lograr el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones de BLOB al abrir presentaciones extremadamente grandes (p. ej., varios gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar bloqueo de fuente puede reducir significativamente el uso máximo de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas de BLOB al cargar desde streams en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a los streams: la instancia de la presentación puede poseer y bloquear el stream de entrada (según el modo de bloqueo elegido), y se usan archivos temporales cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.