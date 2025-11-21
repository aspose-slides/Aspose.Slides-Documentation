---
title: Gestionar Blob
type: docs
weight: 10
url: /es/nodejs-java/manage-blob/
description: Administrar Blob en una presentación de PowerPoint usando JavaScript. Usar Blob para reducir el consumo de memoria en una presentación de PowerPoint usando JavaScript. Añadir un archivo grande mediante Blob a una presentación de PowerPoint usando JavaScript. Exportar un archivo grande mediante Blob desde una presentación de PowerPoint usando JavaScript. Cargar una presentación de PowerPoint grande como Blob usando JavaScript.
---

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios.  

Aspose.Slides for Node.js via Java le permite usar BLOBs para objetos de manera que reduzca el consumo de memoria cuando se manejan archivos grandes.

{{% alert title="Información" color="info" %}}
Para evitar ciertas limitaciones al interactuar con flujos, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo provocará la copia del contenido de la presentación y causará una carga lenta. Por lo tanto, cuando pretenda cargar una presentación grande, le recomendamos encarecidamente que utilice la ruta del archivo de la presentación y no su flujo.
{{% /alert %}}

## **Usar BLOB para reducir el consumo de memoria**

### **Agregar un archivo grande mediante BLOB a una presentación**

[Aspose.Slides](/slides/es/nodejs-java/) for Node.js via Java le permite agregar archivos grandes (en este caso, un archivo de video grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este JavaScript le muestra cómo agregar un archivo de video grande mediante el proceso BLOB a una presentación:
```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Crea una nueva presentación a la que se añadirá el video
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Añadamos el video a la presentación - elegimos el comportamiento KeepLocked porque
        // no tenemos intención de acceder al archivo "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        // se mantiene bajo durante el ciclo de vida del objeto pres
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Exportar archivo grande mediante BLOB desde una presentación**

Aspose.Slides for Node.js via Java le permite exportar archivos grandes (en este caso, un archivo de audio o video) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo multimedia grande de una presentación pero no desea que el archivo se cargue en la memoria de su ordenador. Exportando el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria.

Este código en JavaScript demuestra la operación descrita:
```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Bloquea el archivo fuente y NO lo carga en memoria
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// Crea la instancia de Presentation y bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Guardemos cada video en un archivo. Para evitar un alto uso de memoria, necesitamos un búfer que se utilizará
    // para transferir los datos del flujo de video de la presentación a un flujo de un archivo de video recién creado.
    var buffer = new byte[8 * 1024];
    // Recorre los videos
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Abre el flujo de video de la presentación. Por favor, note que evitamos intencionalmente acceder a propiedades
        // como video.BinaryData - porque esta propiedad devuelve un arreglo de bytes que contiene un video completo, lo que entonces
        // hace que los bytes se carguen en memoria. Usamos video.GetStream, que devuelve un Stream - y NO
        // requiere que carguemos el video completo en la memoria.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
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
    // Si es necesario, puede aplicar los mismos pasos para archivos de audio.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```


### **Agregar imagen como BLOB en una presentación**

Con los métodos de la clase [**ImageCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) y la clase [**ImageCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection), puede agregar una imagen grande como flujo para que se trate como un BLOB.

Este código JavaScript le muestra cómo agregar una imagen grande mediante el proceso BLOB:
```javascript
var pathToLargeImage = "large_image.jpg";
// crea una nueva presentación a la que se añadirá la imagen.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Añadamos la imagen a la presentación - elegimos el comportamiento KeepLocked porque
        // NO pretendemos acceder al archivo "largeImage.png" file.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        // se mantiene bajo durante el ciclo de vida del objeto pres
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Memoria y presentaciones grandes**

Normalmente, para cargar una presentación grande, los equipos requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del que se cargó la presentación) deja de usarse.  

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de video de 1,5 GB. El método estándar para cargar la presentación se describe en este código JavaScript:
```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Pero este método consume alrededor de 1,6 GB de memoria temporal.  

### **Cargar una presentación grande como BLOB**

Mediante el proceso que involucra un BLOB, puede cargar una presentación grande usando poca memoria. Este código JavaScript describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Cambiar la carpeta para archivos temporales**

Cuando se utiliza el proceso BLOB, su computadora crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta diferente, puede cambiar la configuración de almacenamiento usando `setTempFilesRootPath`:
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Información" color="info" %}}
Cuando usa `setTempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar los archivos temporales. Debe crear la carpeta manualmente. 
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y son controlados por opciones BLOB?**

Los objetos binarios grandes como imágenes, audio y video se tratan como BLOB. El archivo completo de la presentación también implica manejo de BLOB cuando se carga o guarda. Estos objetos están gobernados por políticas BLOB que le permiten gestionar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo de BLOB durante la carga de una presentación?**

Utilice [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o no los archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de la fuente.

**¿Los ajustes de BLOB afectan el rendimiento y cómo equilibro velocidad vs memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero aumenta el consumo de RAM; reducir el límite de memoria desplaza más trabajo a archivos temporales, disminuyendo la RAM a costa de I/O adicional. Use el método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) para lograr el equilibrio adecuado para su carga de trabajo y entorno.

**¿Las opciones BLOB ayudan al abrir presentaciones extremadamente grandes (p.ej., gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar bloqueo de fuente pueden reducir significativamente el uso máximo de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas BLOB al cargar desde streams en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a los streams: la instancia de la presentación puede poseer y bloquear el stream de entrada (según el modo de bloqueo elegido), y se utilizan archivos temporales cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.