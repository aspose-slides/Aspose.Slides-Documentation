---
title: Gestionar BLOBs de presentaciones en PHP para un uso eficiente de la memoria
linktitle: Gestionar BLOB
type: docs
weight: 10
url: /es/php-java/manage-blob/
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
- PHP
- Aspose.Slides
description: "Gestionar datos BLOB en Aspose.Slides para PHP a través de Java para simplificar operaciones de archivos PowerPoint y OpenDocument para un manejo eficiente de presentaciones."
---
## **Resumen**

Aspose.Slides ofrece manejo basado en BLOB para datos binarios grandes en presentaciones, lo que ayuda a reducir el consumo de memoria al trabajar con imágenes, audio, vídeo y archivos de presentación de gran tamaño.

Este artículo muestra cómo usar el procesamiento basado en BLOB para agregar medios grandes a una presentación, exportar medios grandes desde una presentación y cargar presentaciones grandes de forma más eficiente. También explica cómo se pueden usar archivos temporales durante el procesamiento y cómo cambiar la carpeta utilizada para almacenarlos.

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios.

Aspose.Slides for PHP via Java le permite utilizar BLOBs para objetos de una manera que reduce el consumo de memoria cuando se manejan archivos grandes.

{{% alert title="Información" color="info" %}}
Para sortear ciertas limitaciones al interactuar con flujos, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo provocará la copia del contenido de la presentación y ocasionará una carga lenta. Por lo tanto, cuando pretenda cargar una presentación grande, le recomendamos encarecidamente que use la ruta del archivo de la presentación y no su flujo.
{{% /alert %}}

## **Usar BLOB para reducir el consumo de memoria**

### **Agregar un archivo grande mediante BLOB a una presentación**

[Aspose.Slides](/slides/es/php-java/) for Java le permite agregar archivos grandes (en este caso, un archivo de vídeo grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este ejemplo en Java le muestra cómo agregar un archivo de vídeo grande mediante el proceso BLOB a una presentación:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Crea una nueva presentación a la que se añadirá el vídeo
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Añadamos el vídeo a la presentación - elegimos el comportamiento KeepLocked porque
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

### **Exportar un archivo grande mediante BLOB desde una presentación**

Aspose.Slides for PHP via Java le permite exportar archivos grandes (en este caso, un archivo de audio o vídeo) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo multimedia grande de una presentación pero no desea que el archivo se cargue en la memoria de su equipo. Exportando el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria.

Este código demuestra la operación descrita:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Bloquea el archivo fuente y NO lo carga en memoria
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Crea la instancia de Presentation y bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Guardemos cada video en un archivo. Para evitar un alto uso de memoria, necesitamos un búfer que se usará
    # para transferir los datos del flujo de video de la presentación a un flujo para un nuevo archivo de video.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Recorre los videos
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Abre el flujo de video de la presentación. Tenga en cuenta que evitamos intencionalmente acceder a propiedades
      # como video.BinaryData - porque esta propiedad devuelve una matriz de bytes que contiene el video completo, lo que
      # hace que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá Stream - y NO
      # requiere que carguemos todo el video en la memoria.
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
      # El consumo de memoria seguirá bajo sin importar el tamaño del video o de la presentación.
    }
    # Si es necesario, puede aplicar los mismos pasos para los archivos de audio.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Agregar una imagen como BLOB a una presentación**

Con los métodos de la clase [ImageCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagecollection/) puede agregar una imagen grande como flujo para que sea tratada como BLOB.

Este código PHP le muestra cómo agregar una imagen grande mediante el proceso BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # crea una nueva presentación a la que se añadirá la imagen.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Añadamos la imagen a la presentación - elegimos el comportamiento KeepLocked porque
      # NO pretendemos acceder al archivo "largeImage.png" file.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
      # permanece bajo a lo largo del ciclo de vida del objeto pres
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

## **Memoria y presentaciones grandes**

Normalmente, para cargar una presentación grande, los equipos requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del que se cargó la presentación) deja de usarse.

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de vídeo de 1,5 GB. El método estándar para cargar la presentación se describe en este código PHP:

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

### **Cargar una presentación grande como BLOB**

Mediante el proceso que involucra un BLOB, puede cargar una presentación grande utilizando poca memoria. Este código PHP describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

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

### **Cambiar la carpeta para archivos temporales**

Cuando se usa el proceso BLOB, su equipo crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se mantengan en una carpeta diferente, puede cambiar la configuración de almacenamiento usando `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Información" color="info" %}}
Al usar `setTempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar los archivos temporales. Usted debe crear la carpeta manualmente.
{{% /alert %}}

### **Liberar objetos Presentation para liberar memoria**

Al procesar presentaciones grandes, asegúrese de que la instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) se libere correctamente para que se libere la memoria que ocupaba. Llame a `dispose()` después de haber terminado de usar la presentación para liberar recursos no administrados.

```php
$presentation = new Presentation("large.pptx");

# ...procese la presentación...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Libere explícitamente los recursos.
$presentation->dispose();
```

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y están controlados por las opciones de BLOB?**

Objetos binarios grandes como imágenes, audio y vídeo se tratan como BLOB. El archivo completo de la presentación también implica manejo BLOB cuando se carga o guarda. Estos objetos están regidos por políticas BLOB que le permiten gestionar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo BLOB durante la carga de la presentación?**

Utilice [LoadOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o prohíbe archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de la fuente.

**¿Afectan los ajustes BLOB al rendimiento y cómo equilibrar velocidad vs. memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero aumenta el consumo de RAM; reducir el límite de memoria desplaza más trabajo a archivos temporales, reduciendo la RAM a costa de I/O adicional. Use el método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/es/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) para encontrar el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones BLOB al abrir presentaciones extremadamente grandes (por ejemplo, varios gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar bloqueo de fuente puede reducir significativamente el pico de uso de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas BLOB al cargar desde flujos en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a los flujos: la instancia de presentación puede poseer y bloquear el flujo de entrada (según el modo de bloqueo elegido), y se usan archivos temporales cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.