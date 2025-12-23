---
title: Administrar BLOBs de presentación en PHP para uso eficiente de la memoria
linktitle: Administrar BLOB
type: docs
weight: 10
url: /es/php-java/manage-blob/
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
- PHP
- Aspose.Slides
description: "Administre datos BLOB en Aspose.Slides para PHP vía Java para optimizar operaciones de archivos PowerPoint y OpenDocument y lograr un manejo eficiente de presentaciones."
---

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) es normalmente un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios. 

Aspose.Slides for PHP via Java le permite usar BLOBs para objetos de manera que reduzca el consumo de memoria cuando se manejan archivos grandes.

{{% alert title="Info" color="info" %}}

Para eludir ciertas limitaciones al interactuar con streams, Aspose.Slides puede copiar el contenido del stream. Cargar una presentación grande a través de su stream provocará la copia del contenido de la presentación y causará una carga lenta. Por lo tanto, cuando pretenda cargar una presentación grande, le recomendamos encarecidamente que utilice la ruta del archivo de la presentación y no su stream.

{{% /alert %}}

## **Usar BLOB para Reducir el Consumo de Memoria**

### **Agregar un Archivo Grande mediante BLOB a una Presentación**

[Aspose.Slides](/slides/es/php-java/) para Java le permite agregar archivos grandes (en este caso, un archivo de video grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este ejemplo Java le muestra cómo agregar un archivo de video grande mediante el proceso BLOB a una presentación:
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Crea una nueva presentación a la que se agregará el video
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Agreguemos el video a la presentación - elegimos el comportamiento KeepLocked porque
      # no pretendemos acceder al archivo "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
      # permanece bajo a lo largo del ciclo de vida del objeto pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Exportar un Archivo Grande mediante BLOB desde una Presentación**
Aspose.Slides for PHP via Java le permite exportar archivos grandes (en este caso, un archivo de audio o video) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo multimedia grande de una presentación pero no quiere que el archivo se cargue en la memoria de su computadora. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria.

Este código demuestra la operación descrita:
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Bloquea el archivo de origen y NO lo carga en memoria
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # crea la instancia de Presentation, bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Guardemos cada video en un archivo. Para evitar un uso alto de memoria, necesitamos un búfer que se utilizará
    # para transferir los datos del stream de video de la presentación a un stream para un archivo de video recién creado.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Itera a través de los videos
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Abre el stream de video de la presentación. Por favor, note que intencionalmente evitamos acceder a propiedades
      # como video.BinaryData - porque esta propiedad devuelve un arreglo de bytes que contiene el video completo, lo que entonces
      # hace que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá un Stream y NO
      # requiere que carguemos el video completo en memoria.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # El consumo de memoria permanecerá bajo independientemente del tamaño del video o la presentación.
    }
    # Si es necesario, puedes aplicar los mismos pasos para archivos de audio.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```



### **Agregar una Imagen como BLOB a una Presentación**
Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) y de la clase [**ImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection), puede agregar una imagen grande como stream para que se trate como un BLOB.

Este código PHP le muestra cómo agregar una imagen grande mediante el proceso BLOB:
```php
  $pathToLargeImage = "large_image.jpg";
  # crea una nueva presentación a la que se añadirá la imagen.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Agreguemos la imagen a la presentación - elegimos el comportamiento KeepLocked porque
      # NO pretendemos acceder al archivo "largeImage.png" file.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
      # permanece bajo durante el ciclo de vida del objeto pres
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Memoria y Presentaciones Grandes**

Normalmente, para cargar una presentación grande, las computadoras requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del cual se cargó la presentación) deja de ser usado. 

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de video de 1,5 GB. El método estándar para cargar la presentación se describe en este código PHP:
```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Pero este método consume alrededor de 1,6 GB de memoria temporal. 

### **Cargar una Presentación Grande como BLOB**

Mediante el proceso que involucra un BLOB, puede cargar una presentación grande usando poca memoria. Este código PHP describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Cambiar la Carpeta para Archivos Temporales**

Cuando se usa el proceso BLOB, su computadora crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta diferente, puede cambiar la configuración de almacenamiento usando `TempFilesRootPath`:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```


{{% alert title="Info" color="info" %}}

Cuando usa `TempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Tiene que crear la carpeta manualmente. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y son controlados por las opciones BLOB?**

Los objetos binarios grandes como imágenes, audio y video se tratan como BLOB. El archivo completo de la presentación también implica el manejo de BLOB cuando se carga o se guarda. Estos objetos están regidos por políticas BLOB que le permiten gestionar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo de BLOB durante la carga de la presentación?**

Use [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o prohibe archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de origen.

**¿Afectan las configuraciones de BLOB al rendimiento y cómo equilibrar velocidad vs memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero aumenta el consumo de RAM; reducir el límite de memoria transfiere más trabajo a archivos temporales, reduciendo RAM a costa de I/O adicional. Use el método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) para lograr el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones BLOB al abrir presentaciones extremadamente grandes (p.ej., gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar bloqueo de origen puede reducir significativamente el pico de uso de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas BLOB al cargar desde streams en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a los streams: la instancia de presentación puede poseer y bloquear el stream de entrada (según el modo de bloqueo elegido), y se usan archivos temporales cuando se permite, manteniendo predecible el uso de memoria durante el procesamiento.