---
title: Gestionar BLOB
type: docs
weight: 10
url: /androidjava/manage-blob/
description: Gestionar BLOB en presentaciones de PowerPoint usando Java. Utilizar BLOB para reducir el consumo de memoria en presentaciones de PowerPoint usando Java. Agregar archivos grandes a través de BLOB a presentaciones de PowerPoint usando Java. Exportar archivos grandes a través de BLOB desde presentaciones de PowerPoint usando Java. Cargar una gran presentación de PowerPoint como BLOB usando Java.
---

## **Acerca de BLOB**

**BLOB** (**Objeto Binario Grande**) es generalmente un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios.

Aspose.Slides para Android a través de Java te permite utilizar BLOBs para objetos de una manera que reduce el consumo de memoria cuando se trata de archivos grandes.

{{% alert title="Información" color="info" %}}

Para sortear ciertas limitaciones al interactuar con flujos, Aspose.Slides puede copiar el contenido del flujo. Cargar una gran presentación a través de su flujo resultará en la copia del contenido de la presentación y causará una carga lenta. Por lo tanto, cuando pretendas cargar una gran presentación, te recomendamos encarecidamente que utilices la ruta del archivo de presentación y no su flujo.

{{% /alert %}}

## **Usar BLOB para Reducir el Consumo de Memoria**

### **Agregar Archivo Grande a través de BLOB a una Presentación**

[Aspose.Slides](/slides/androidjava/) para Java te permite agregar archivos grandes (en este caso, un archivo de video grande) a través de un proceso que involucra BLOBs para reducir el consumo de memoria.

Este código en Java te muestra cómo agregar un archivo de video grande a través del proceso BLOB a una presentación:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crea una nueva presentación a la que se agregará el video
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Agreguemos el video a la presentación - elegimos el comportamiento KeepLocked porque no
        // pretendemos acceder al archivo "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Guarda la presentación. Mientras se genera una gran presentación, el consumo de memoria
        // se mantiene bajo a lo largo del ciclo de vida del objeto pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Exportar Archivo Grande a Través de BLOB desde la Presentación**
Aspose.Slides para Android a través de Java te permite exportar archivos grandes (en este caso, un archivo de audio o video) a través de un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede que necesites extraer un gran archivo de medios de una presentación pero no deseas que el archivo se cargue en la memoria de tu computadora. Exportando el archivo a través del proceso BLOB, mantendrás bajo el consumo de memoria.

Este código en Java demuestra la operación descrita:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Bloquea el archivo fuente y NO lo carga en memoria
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// crea la instancia de la Presentación, bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Vamos a guardar cada video en un archivo. Para prevenir un alto uso de memoria, necesitamos un búfer que se usará
    // para transferir los datos del flujo de video de la presentación a un flujo para un archivo de video recién creado.
    byte[] buffer = new byte[8 * 1024];

    // Itera a través de los videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Abre el flujo de video de la presentación. Ten en cuenta que evitamos intencionalmente acceder a propiedades
        // como video.BinaryData - porque esta propiedad devuelve un arreglo de bytes que contiene un video completo, lo que luego
        // provoca que los bytes se carguen en la memoria. Usamos video.GetStream, que devolverá Stream - y NO
        // requiere que carguemos todo el video en la memoria.
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
        // El consumo de memoria se mantendrá bajo independientemente del tamaño del video o la presentación.
    }
    // Si es necesario, puedes aplicar los mismos pasos para archivos de audio. 
} catch (IOException e) {
} finally {
    pres.dispose();
}

```

### **Agregar Imagen como BLOB en la Presentación**
Con métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) y la clase [**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection), puedes agregar una gran imagen como un flujo para que se trate como un BLOB.

Este código en Java te muestra cómo agregar una gran imagen a través del proceso BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// crea una nueva presentación a la que se agregará la imagen.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Agreguemos la imagen a la presentación - elegimos el comportamiento KeepLocked porque no
		// pretendemos acceder al archivo "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Guarda la presentación. Mientras se genera una gran presentación, el consumo de memoria
		// se mantiene bajo a lo largo del ciclo de vida del objeto pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Memoria y Grandes Presentaciones**

Típicamente, para cargar una gran presentación, las computadoras requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del cual se cargó la presentación) deja de usarse.

Considera una gran presentación de PowerPoint (large.pptx) que contiene un archivo de video de 1.5 GB. El método estándar para cargar la presentación se describe en este código en Java:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Pero este método consume alrededor de 1.6 GB de memoria temporal.

### **Cargar una Gran Presentación como BLOB**

A través del proceso que involucra un BLOB, puedes cargar una gran presentación mientras utilizas poca memoria. Este código en Java describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

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

Cuando se utiliza el proceso BLOB, tu computadora crea archivos temporales en la carpeta predeterminada para archivos temporales. Si deseas que los archivos temporales se mantengan en una carpeta diferente, puedes cambiar la configuración de almacenamiento utilizando `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Información" color="info" %}}

Cuando utilizas `TempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Debes crear la carpeta manualmente.

{{% /alert %}}