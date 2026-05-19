---
title: Gestionar BLOBs de presentación en Java para un uso eficiente de la memoria
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
description: "Gestionar datos BLOB en Aspose.Slides para Java para agilizar operaciones con archivos PowerPoint y OpenDocument y lograr una manipulación eficiente de presentaciones."
---
## **Visión general**

Aspose.Slides ofrece un manejo basado en BLOB para datos binarios grandes en presentaciones, ayudando a reducir el consumo de memoria al trabajar con imágenes, audio, vídeo y archivos de presentación de gran tamaño.

Este artículo muestra cómo usar el procesamiento basado en BLOB para añadir medios grandes a una presentación, exportar medios grandes desde una presentación y cargar presentaciones grandes de forma más eficiente. También explica cómo se pueden utilizar archivos temporales durante el procesamiento y cómo cambiar la carpeta utilizada para almacenarlos.

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios. 

Aspose.Slides para Java permite usar BLOBs para objetos de manera que se reduzca el consumo de memoria cuando se manejan archivos grandes. 

{{% alert title="Info" color="info" %}}
Para evitar ciertas limitaciones al interactuar con flujos, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo provocará la copia del contenido de la presentación y causará una carga lenta. Por lo tanto, cuando pretenda cargar una presentación grande, le recomendamos encarecidamente que use la ruta del archivo de presentación y no su flujo.
{{% /alert %}}

## **Usar BLOB para reducir el consumo de memoria**

### **Añadir un archivo grande mediante BLOB a una presentación**

[Aspose.Slides](/slides/es/java/) para Java permite añadir archivos grandes (en este caso, un archivo de vídeo grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este ejemplo en Java le muestra cómo añadir un archivo de vídeo grande mediante el proceso BLOB a una presentación:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crea una nueva presentación a la que se añadirá el vídeo
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Añadamos el vídeo a la presentación - elegimos el comportamiento KeepLocked porque
        // no tenemos intención de acceder al archivo "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        // permanece bajo a lo largo del ciclo de vida del objeto pres
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Exportar un archivo grande mediante BLOB desde la presentación**

Aspose.Slides para Java permite exportar archivos grandes (en este caso, un archivo de audio o vídeo) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo de medio grande de una presentación pero no quiere que el archivo se cargue en la memoria de su ordenador. Al exportar el archivo mediante el proceso BLOB, el consumo de memoria se mantiene bajo. 

Este código en Java demuestra la operación descrita:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Bloquea el archivo fuente y NO lo carga en memoria
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// crea la instancia de Presentation, bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Guardemos cada vídeo en un archivo. Para evitar un uso elevado de memoria, necesitamos un búfer que será usado
    // para transferir los datos del flujo de vídeo de la presentación a un flujo para un nuevo archivo de vídeo creado.
    byte[] buffer = new byte[8 * 1024];

    // Recorre los vídeos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Abre el flujo de vídeo de la presentación. Por favor, tenga en cuenta que evitamos intencionalmente acceder a propiedades
        // como video.BinaryData - porque esta propiedad devuelve un array de bytes que contiene el vídeo completo, lo que entonces
        // hace que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá un Stream - y NO
        //  requiere que carguemos todo el vídeo en la memoria.
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
        // El consumo de memoria permanecerá bajo sin importar el tamaño del vídeo o de la presentación.
    }
    // Si es necesario, puede aplicar los mismos pasos para archivos de audio. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Añadir una imagen como BLOB a una presentación**

Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/es/java/com.aspose.slides/IImageCollection) y la clase [**ImageCollection** ](https://reference.aspose.com/slides/es/java/com.aspose.slides/ImageCollection) puede añadir una imagen grande como flujo para que sea tratada como un BLOB. 

Este código en Java le muestra cómo añadir una imagen grande mediante el proceso BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// crea una nueva presentación a la que se añadirá la imagen.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Añadamos la imagen a la presentación - elegimos el comportamiento KeepLocked porque
		// NO tenemos intención de acceder al archivo "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
		// permanece bajo a lo largo del ciclo de vida del objeto pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Memoria y presentaciones grandes**

Normalmente, para cargar una presentación grande, los ordenadores requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del que se cargó la presentación) deja de usarse. 

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de vídeo de 1,5 GB. El método estándar para cargar la presentación se describe en este código Java:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Pero este método consume alrededor de 1,6 GB de memoria temporal. 

### **Cargar una presentación grande como BLOB**

A través del proceso que involucra un BLOB, puede cargar una presentación grande usando poca memoria. Este código Java describe la implementación donde se utiliza el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

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

### **Cambiar la carpeta para archivos temporales**

Cuando se usa el proceso BLOB, el ordenador crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta diferente, puede cambiar la configuración de almacenamiento mediante `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Al usar `TempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar los archivos temporales. Debe crear la carpeta manualmente. 
{{% /alert %}}

### **Desechar objetos Presentation para liberar memoria**

Al procesar presentaciones grandes, asegúrese de que la instancia de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) se deseche correctamente para que se libere la memoria que ocupaba. Llame a `dispose()` después de haber terminado de usar la presentación para liberar recursos no administrados.

```java
Presentation presentation = new Presentation("large.pptx");

// ...procesar la presentación...
presentation.save("large.pdf", SaveFormat.Pdf);

// Liberar recursos explícitamente.
presentation.dispose();
```

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y se controlan mediante opciones de BLOB?**

Objetos binarios grandes como imágenes, audio y vídeo se tratan como BLOB. Todo el archivo de la presentación también implica manejo de BLOB cuando se carga o guarda. Estos objetos están gobernados por políticas de BLOB que le permiten gestionar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo de BLOB durante la carga de una presentación?**

Utilice [LoadOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o niega archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de la fuente.

**¿Los ajustes de BLOB afectan al rendimiento y cómo equilibrar velocidad vs memoria?**

Sí. Mantener los BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria transfiere más trabajo a archivos temporales, disminuyendo la RAM a costa de I/O adicional. Use el método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/es/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) para encontrar el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones de BLOB al abrir presentaciones extremadamente grandes (p. ej., gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar bloqueo de fuente pueden reducir significativamente el pico de uso de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas de BLOB al cargar desde flujos en vez de archivos en disco?**

Sí. Las mismas reglas se aplican a los flujos: la instancia de presentación puede ser propietaria y bloquear el flujo de entrada (según el modo de bloqueo elegido), y se usan archivos temporales cuando están permitidos, manteniendo el uso de memoria predecible durante el procesamiento.