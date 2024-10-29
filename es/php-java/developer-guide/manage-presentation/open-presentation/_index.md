---
title: Presentación Abierta
linktitle: Presentación Abierta
type: docs
weight: 20
url: /es/php-java/open-presentation/
keywords: "Abrir PowerPoint, PPTX, PPT, Presentación Abierta, Cargar Presentación, Java"
description: "Abrir o cargar presentación PPT, PPTX, ODP "
---

Además de crear presentaciones de PowerPoint desde cero, Aspose.Slides te permite abrir presentaciones existentes. Después de cargar una presentación, puedes obtener información sobre la presentación, editar la presentación (contenido en sus diapositivas), agregar nuevas diapositivas o eliminar las existentes, etc. 

## Presentación Abierta

Para abrir una presentación existente, simplemente debes instanciar la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y pasar la ruta del archivo (de la presentación que deseas abrir) a su constructor.

Este código PHP te muestra cómo abrir una presentación y también averiguar cuántas diapositivas contiene:

```php
  # Instancia la clase Presentation y pasa la ruta del archivo a su constructor
  $pres = new Presentation("Presentation.pptx");
  try {
    # Imprime el número total de diapositivas presentes en la presentación
    echo($pres->getSlides()->size());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Abrir Presentación Protegida por Contraseña**

Cuando tengas que abrir una presentación protegida por contraseña, puedes pasar la contraseña a través de la propiedad [Password](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getPassword--) (de la clase [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)) para descifrar la presentación y cargarla. Este código PHP demuestra la operación:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("TU_CONTRASEÑA");
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
    # Realiza alguna operación con la presentación descifrada
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Abrir Presentación Grande

Aspose.Slides proporciona opciones (la propiedad [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) en particular) bajo la clase [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions) para permitirte cargar presentaciones grandes.

Este Java demuestra una operación en la que se carga una presentación grande (digamos de 2GB de tamaño):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(0);
  $pres = new Presentation("veryLargePresentation.pptx", $loadOptions);
  try {
    # La presentación grande ha sido cargada y puede ser utilizada, pero el consumo de memoria sigue siendo bajo.
    # realiza cambios en la presentación.
    $pres->getSlides()->get_Item(0)->setName("Presentación muy grande");
    # La presentación se guardará en otro archivo. El consumo de memoria se mantiene bajo durante la operación
    $pres->save("veryLargePresentation-copy.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="info" title="Info" %}}

Para eludir ciertas limitaciones al interactuar con un flujo, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo resultará en la copia del contenido de la presentación y causará una carga lenta. Por lo tanto, cuando pretendas cargar una presentación grande, te recomendamos encarecidamente que utilices la ruta del archivo de la presentación y no su flujo.

Cuando quieras crear una presentación que contenga objetos grandes (video, audio, imágenes grandes, etc.), puedes utilizar la [facilidad de Blob](https://docs.aspose.com/slides/php-java/manage-blob/) para reducir el consumo de memoria.

{{%/alert %}} 

## Cargar Presentación

Aspose.Slides proporciona [IResourceLoadingCallback](https://reference.aspose.com/slides/php-java/aspose.slides/iresourceloadingcallback/) con un único método que te permite gestionar recursos externos. Este código PHP te muestra cómo usar la interfaz `IResourceLoadingCallback`:

```php

class ImageLoadingHandler {
    function resourceLoading($args) {
      if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
        # carga una imagen de sustitución
        $file = new Java("java.io.File", "aspose-logo.jpg");
        $Array = new JavaClass("java.lang.reflect.Array");
        $Byte = new JavaClass("java.lang.Byte");
        $imageBytes = $Array->newInstance($Byte, $Array->getLength($file));
        try {
            $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
            $dis->readFully($imageBytes);
        } finally {
            if (!java_is_null($dis)) $dis->close();
        }
          $args->setData($imageBytes);
          return ResourceLoadingAction::UserProvided;
      } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
        # establece la url de sustitución
        $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
        return ResourceLoadingAction::Default;
      }
      # omite todas las demás imágenes
      return ResourceLoadingAction::Skip;
    }
  }

  $opts = new LoadOptions();
  $loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));
  $opts->setResourceLoadingCallback($loadingHandler);
  $pres = new Presentation("presentation.pptx", $opts);
```

## Cargar Presentación Sin Objetos Binarios Incorporados

La presentación de PowerPoint puede contener los siguientes tipos de objetos binarios incorporados:

- Proyecto VBA ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- Datos de objeto OLE incrustados ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Datos binarios de control ActiveX ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

Usando la propiedad [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), puedes cargar la presentación sin ningún objeto binario incorporado.

Esta propiedad puede ser útil para eliminar contenido binario potencialmente malicioso.

El código demuestra cómo cargar y guardar una presentación sin ningún contenido de malware:

```java
  $loadOptions = new LoadOptions();
  $loadOptions->setDeleteEmbeddedBinaryObjects(true);

  $pres = new Presentation("malware.ppt", $loadOptions);
  try {
    $pres->save("clean.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null(pres)) { 
      $pres->dispose();
    }
  }
```

## Abrir y Guardar Presentación

Pasos para Abrir y Guardar Presentación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y pasa el archivo que deseas abrir.
2. Guarda la presentación.

```php
  # Instancia un objeto Presentation que representa un archivo PPT
  $pres = new Presentation();
  try {
    # ...hacer algún trabajo aquí...
    # Guarda tu presentación en un archivo
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```