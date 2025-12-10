---
title: Gestionar BLOB de presentaciones en Java para un uso eficiente de la memoria
linktitle: Gestionar BLOB
type: docs
weight: 10
url: /es/java/manage-blob/
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
- Java
- Aspose.Slides
description: "Gestionar datos BLOB en Aspose.Slides para Java para optimizar las operaciones con archivos PowerPoint y OpenDocument y lograr un manejo eficiente de presentaciones."
---

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios. 

Aspose.Slides for Java le permite usar BLOBs para objetos de forma que se reduzca el consumo de memoria cuando se manejan archivos grandes. 

{{% alert title="Información" color="info" %}}
Para sortear ciertas limitaciones al interactuar con flujos, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo provocará la copia del contenido de la presentación y ralentizará la carga. Por lo tanto, cuando pretenda cargar una presentación grande, le recomendamos encarecidamente que utilice la ruta del archivo de la presentación y no su flujo.
{{% /alert %}}

## **Usar BLOB para Reducir el Consumo de Memoria**

### **Agregar un Archivo Grande a una Presentación mediante BLOB**

[Aspose.Slides](/slides/es/java/) for Java le permite agregar archivos grandes (en este caso, un archivo de video grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este ejemplo en Java le muestra cómo agregar un archivo de video grande mediante el proceso BLOB a una presentación:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crea una nueva presentación a la que se añadirá el video.
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Añadamos el video a la presentación - elegimos el comportamiento KeepLocked porque
        // no pretendemos acceder al archivo "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        // permanece bajo durante el ciclo de vida del objeto pres.
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **Exportar un Archivo Grande desde una Presentación mediante BLOB**
Aspose.Slides for Java le permite exportar archivos grandes (en este caso, un archivo de audio o video) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo multimedia grande de una presentación pero no quiere que el archivo se cargue en la memoria de su computadora. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria. 

Este código en Java demuestra la operación descrita:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Bloquea el archivo fuente y NO lo carga en memoria
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// crea la instancia de Presentation, bloqueando el archivo "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Guardemos cada video en un archivo. Para evitar un alto consumo de memoria, necesitamos un búfer que será usado
    // para transferir los datos del flujo de video de la presentación a un flujo para un archivo de video recién creado.
    byte[] buffer = new byte[8 * 1024];

    // Itera a través de los videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Abre el flujo de video de la presentación. Por favor, note que intencionalmente evitamos acceder a propiedades
        // como video.BinaryData - porque esta propiedad devuelve un arreglo de bytes que contiene un video completo, lo que entonces
        // causa que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá Stream - y NO
        //  requiere que carguemos todo el video en la memoria.
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
        // El consumo de memoria permanecerá bajo sin importar el tamaño del video o de la presentación.
    }
    // Si es necesario, puede aplicar los mismos pasos para archivos de audio.
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **Agregar una Imagen como BLOB a una Presentación**
Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) y la clase [**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection), puede agregar una imagen grande como flujo para que se trate como un BLOB. 

Este código en Java le muestra cómo agregar una imagen grande mediante el proceso BLOB:
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
		// permanece bajo durante el ciclo de vida del objeto pres.
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

Normalmente, para cargar una presentación grande, los ordenadores requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del cual se cargó la presentación) deja de usarse. 

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

Mediante el proceso que involucra un BLOB, puede cargar una presentación grande usando poca memoria. Este código Java describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):
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

Cuando se usa el proceso BLOB, su ordenador crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta diferente, puede cambiar la configuración de almacenamiento usando `TempFilesRootPath`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Información" color="info" %}}
Al usar `TempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Debe crear la carpeta manualmente. 
{{% /alert %}}

## **Preguntas Frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y están controlados por opciones de BLOB?**

Objetos binarios grandes como imágenes, audio y video se tratan como BLOB. El archivo completo de la presentación también implica la gestión de BLOB cuando se carga o se guarda. Estos objetos están regidos por políticas de BLOB que le permiten gestionar el uso de memoria y desbordar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo de BLOB durante la carga de una presentación?**

Use [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o prohibe archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de la fuente.

**¿Afectan las configuraciones de BLOB al rendimiento y cómo equilibrar velocidad vs. memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria desplaza más trabajo a archivos temporales, disminuyendo la RAM a costa de I/O adicional. Use el método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) para encontrar el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones de BLOB al abrir presentaciones extremadamente grandes (p. ej., varios gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar bloqueo de fuente puede reducir significativamente el uso máximo de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas de BLOB al cargar desde flujos en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a los flujos: la instancia de la presentación puede poseer y bloquear el flujo de entrada (según el modo de bloqueo elegido), y los archivos temporales se utilizan cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.