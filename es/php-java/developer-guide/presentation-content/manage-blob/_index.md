---
title: Gestionar Blob
type: docs
weight: 10
url: /php-java/manage-blob/
description: Gestionar Blob en Presentaciones de PowerPoint utilizando PHP. Utilizar Blob para reducir el consumo de memoria en Presentaciones de PowerPoint utilizando PHP. Agregar archivos grandes a través de Blob a Presentaciones de PowerPoint utilizando PHP. Exportar archivos grandes a través de Blob desde Presentaciones de PowerPoint utilizando PHP. Cargar una gran Presentación de PowerPoint como Blob utilizando PHP.
---

## **Acerca de BLOB**

**BLOB** (**Objeto Binario Grande**) es generalmente un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios. 

Aspose.Slides para PHP a través de Java te permite usar BLOBs para objetos de una manera que reduce el consumo de memoria cuando están involucrados archivos grandes.

{{% alert title="Información" color="info" %}}

Para eludir ciertas limitaciones al interactuar con flujos, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo resultará en la copia del contenido de la presentación y causará una carga lenta. Por lo tanto, cuando pretendas cargar una gran presentación, te recomendamos encarecidamente que utilices la ruta del archivo de presentación y no su flujo.

{{% /alert %}}

## **Usar BLOB para Reducir el Consumo de Memoria**

### **Agregar Archivos Grandes a través de BLOB a una Presentación**

[Aspose.Slides](/slides/php-java/) para Java te permite agregar archivos grandes (en este caso, un gran archivo de video) a través de un proceso que involucra BLOBs para reducir el consumo de memoria.

Este Java te muestra cómo agregar un gran archivo de video a través del proceso BLOB a una presentación:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Crea una nueva presentación a la que se añadirá el video
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Vamos a agregar el video a la presentación - elegimos el comportamiento KeepLocked porque no
      # pretendemos acceder al archivo "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Guarda la presentación. Mientras se exporta una gran presentación, el consumo de memoria
      # se mantendrá bajo a lo largo del ciclo de vida del objeto pres
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


### **Exportar Archivos Grandes a través de BLOB desde la Presentación**
Aspose.Slides para PHP a través de Java te permite exportar archivos grandes (en este caso, un archivo de audio o video) a través de un proceso que involucra BLOBs desde presentaciones. Por ejemplo, es posible que necesites extraer un gran archivo multimedia de una presentación pero no desees que el archivo se cargue en la memoria de tu computadora. Al exportar el archivo a través del proceso BLOB, puedes mantener bajo el consumo de memoria.

Este código demuestra la operación descrita:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Bloquea el archivo fuente y NO lo carga en memoria
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # crea la instancia de la Presentación, bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Vamos a guardar cada video en un archivo. Para prevenir un alto uso de memoria, necesitamos un búfer que será utilizado
    # para transferir los datos del flujo de video de la presentación a un flujo para un nuevo archivo de video creado.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Itera a través de los videos
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Abre el flujo de video de la presentación. Por favor, nota que intencionalmente evitamos acceder a propiedades
      # como video.BinaryData - porque esta propiedad devuelve un arreglo de bytes que contiene un video completo, lo que luego
      # causa que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá Stream - y NO
      # requiere que carguemos el video completo en la memoria.
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
      # El consumo de memoria permanecerá bajo independientemente del tamaño del video o presentación.
    }
    # Si es necesario, puedes aplicar los mismos pasos para archivos de audio.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Agregar Imagen como BLOB en la Presentación**
Con métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) y la clase [**ImageCollection** ](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection), puedes agregar una imagen grande como un flujo para que sea tratada como un BLOB.

Este código PHP te muestra cómo agregar una imagen grande a través del proceso BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # crea una nueva presentación a la que se añadirá la imagen.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Vamos a agregar la imagen a la presentación - elegimos el comportamiento KeepLocked porque no
      # pretendemos acceder al archivo "largeImage.png".
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Guarda la presentación. Mientras se exporta una gran presentación, el consumo de memoria
      # se mantendrá bajo a lo largo del ciclo de vida del objeto pres
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

## **Memoria y Grandes Presentaciones**

Típicamente, para cargar una gran presentación, las computadoras requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del cual se cargó la presentación) deja de ser utilizado. 

Considera una gran presentación de PowerPoint (large.pptx) que contiene un archivo de video de 1.5 GB. El método estándar para cargar la presentación se describe en este código PHP:

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

Pero este método consume alrededor de 1.6 GB de memoria temporal. 

### **Cargar una Gran Presentación como BLOB**

A través del proceso que involucra un BLOB, puedes cargar una gran presentación utilizando poca memoria. Este código PHP describe la implementación donde se utiliza el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

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

Cuando se utiliza el proceso BLOB, tu computadora crea archivos temporales en la carpeta por defecto para archivos temporales. Si deseas que los archivos temporales se mantengan en una carpeta diferente, puedes cambiar la configuración para almacenamiento utilizando `TempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Información" color="info" %}}

Cuando utilizas `TempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Debes crear la carpeta manualmente. 

{{% /alert %}}