---
title: Gestionar BLOBs de Presentación en JavaScript para un Uso Eficiente de la Memoria
linktitle: Gestionar BLOB
type: docs
weight: 10
url: /es/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestiona datos BLOB en JavaScript con Aspose.Slides para Node.js y optimiza las operaciones con archivos PowerPoint y OpenDocument para un manejo eficiente de presentaciones."
---
## **Descripción general**

Aspose.Slides ofrece un manejo basado en BLOB para datos binarios grandes en presentaciones, lo que ayuda a reducir el consumo de memoria al trabajar con imágenes, audio, video y archivos de presentación de gran tamaño.

Este artículo muestra cómo usar el procesamiento basado en BLOB para añadir medios de gran tamaño a una presentación, exportar medios de gran tamaño desde una presentación y cargar presentaciones grandes de forma más eficiente. También explica cómo se pueden utilizar archivos temporales durante el procesamiento y cómo cambiar la carpeta utilizada para almacenarlos.

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios. 

Aspose.Slides para Node.js a través de Java le permite usar BLOBs para objetos de forma que se reduzca el consumo de memoria cuando se manejan archivos grandes.

{{% alert title="Info" color="info" %}}
Para eludir ciertas limitaciones al interactuar con flujos, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo provocará la copia del contenido de la presentación y causará una carga lenta. Por lo tanto, cuando tenga la intención de cargar una presentación grande, le recomendamos encarecidamente que use la ruta del archivo de la presentación y no su flujo.
{{% /alert %}}

## **Usar BLOB para reducir el consumo de memoria**

### **Añadir archivo grande mediante BLOB a una presentación**

[Aspose.Slides](/slides/es/nodejs-java/) para Node.js a través de Java le permite añadir archivos grandes (en este caso, un archivo de vídeo grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este JavaScript le muestra cómo añadir un archivo de vídeo grande mediante el proceso BLOB a una presentación:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Crea una nueva presentación a la que se añadirá el vídeo
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Añadamos el vídeo a la presentación - hemos escogido el comportamiento KeepLocked porque
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

### **Exportar archivo grande mediante BLOB desde la presentación**

Aspose.Slides para Node.js a través de Java le permite exportar archivos grandes (en este caso, un archivo de audio o vídeo) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo de medios grande de una presentación pero no desea que el archivo se cargue en la memoria de su ordenador. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria.

Este código en JavaScript demuestra la operación descrita:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Bloquea el archivo fuente y NO lo carga en memoria
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// crea la instancia de Presentation, bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Guardemos cada vídeo en un archivo. Para evitar un alto consumo de memoria, necesitamos un búfer que se utilizará
    // para transferir los datos del flujo de vídeo de la presentación a un flujo para un archivo de vídeo recién creado.
    var buffer = new byte[8 * 1024];
    // Recorre los vídeos
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Abre el flujo de vídeo de la presentación. Por favor, tenga en cuenta que evitamos intencionalmente acceder a propiedades
        // como video.BinaryData - porque esta propiedad devuelve una matriz de bytes que contiene el vídeo completo, lo que entonces
        // hace que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá un Stream - y NO
        // requiere que carguemos todo el vídeo en la memoria.
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
        // El consumo de memoria se mantendrá bajo sin importar el tamaño del vídeo o de la presentación.
    }
    // Si es necesario, puedes aplicar los mismos pasos para los archivos de audio.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Añadir imagen como BLOB en la presentación**

Con los métodos de la clase [**ImageCollection**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ImageCollection) y la clase [**ImageCollection**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ImageCollection), puede añadir una imagen grande como un flujo para que se trate como un BLOB.

Este código JavaScript le muestra cómo añadir una imagen grande mediante el proceso BLOB:

```javascript
var pathToLargeImage = "large_image.jpg";
// crea una nueva presentación a la que se añadirá la imagen.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Añadamos la imagen a la presentación - elegimos el comportamiento KeepLocked porque
        // NO tenemos intención de acceder al archivo "largeImage.png".
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

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de vídeo de 1,5 GB. El método estándar para cargar la presentación se describe en este código JavaScript:

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

A través del proceso que involucra un BLOB, puede cargar una presentación grande usando poca memoria. Este código JavaScript describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

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

Cuando se usa el proceso BLOB, su ordenador crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se mantengan en una carpeta diferente, puede cambiar la configuración de almacenamiento usando `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Cuando usa `setTempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar los archivos temporales. Debe crear la carpeta manualmente. 
{{% /alert %}}

### **Liberar objetos de presentación para liberar memoria**

Al procesar presentaciones grandes, asegúrese de que la instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) se libere correctamente para que la memoria que ocupaba sea liberada. Llame a `dispose()` después de haber terminado de usar la presentación para liberar los recursos no administrados.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y se controlan mediante opciones BLOB?**

Los objetos binarios grandes, como imágenes, audio y vídeo, se tratan como BLOB. Todo el archivo de la presentación también implica manejo de BLOB cuando se carga o guarda. Estos objetos están regidos por políticas BLOB que le permiten gestionar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo de BLOB durante la carga de una presentación?**

Utilice [LoadOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o prohíbe los archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de la fuente.

**¿Afectan las configuraciones de BLOB al rendimiento y cómo equilibrar velocidad y memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria transfiere más trabajo a archivos temporales, reduciendo la RAM a costa de I/O adicional. Utilice el método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) para lograr el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones BLOB al abrir presentaciones extremadamente grandes (p. ej., gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar bloqueo de fuente pueden reducir significativamente el uso máximo de RAM y estabilizar el procesamiento de barajas muy grandes.

**¿Puedo usar políticas BLOB al cargar desde flujos en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a los flujos: la instancia de presentación puede ser propietaria y bloquear el flujo de entrada (según el modo de bloqueo elegido), y se utilizan archivos temporales cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.