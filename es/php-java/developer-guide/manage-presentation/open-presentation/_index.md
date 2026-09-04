---
title: Abrir presentaciones en PHP
linktitle: Abrir presentación
type: docs
weight: 20
url: /es/php-java/open-presentation/
keywords:
- abrir PowerPoint
- abrir presentación
- abrir PPTX
- abrir PPT
- abrir ODP
- cargar presentación
- cargar PPTX
- cargar PPT
- cargar ODP
- presentación protegida
- presentación grande
- recurso externo
- objeto binario
- PHP
- Aspose.Slides
description: "Aprenda cómo abrir presentaciones PowerPoint y OpenDocument en PHP, proporcionar contraseñas de apertura, controlar la carga de recursos y reducir el uso de memoria con Aspose.Slides para PHP mediante Java."
---
## **Introducción**

[Aspose.Slides para PHP mediante Java](https://products.aspose.com/slides/es/php-java/) puede cargar presentaciones PowerPoint y OpenDocument desde archivos y flujos. Después de cargar una presentación, puede inspeccionar su estructura, editar diapositivas, gestionar recursos y guardarla en el formato original u otro formato compatible.

El comportamiento de carga puede personalizarse mediante la clase [LoadOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/). Por ejemplo, puede proporcionar una contraseña de apertura, mantener los objetos binarios grandes fuera de la memoria del montón de Java, controlar los recursos externos o omitir los datos binarios incrustados.

## **Abrir presentaciones**

Para abrir una presentación existente, pase su ruta de archivo al constructor [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/). Libere la presentación después de su uso para que los manejadores de archivo, los datos temporales y otros recursos se liberen rápidamente.

El siguiente ejemplo en PHP muestra cómo abrir una presentación y obtener el número de diapositivas:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Abrir presentaciones protegidas con contraseña**

Una contraseña de apertura cifra el contenido de la presentación. Para cargar la presentación completa, pase la contraseña correcta a [LoadOptions::setPassword](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setPassword) y proporcione las opciones al constructor [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/). La carga falla cuando la contraseña falta o es incorrecta.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

Para los flujos de detección, validación y cifrado de contraseñas, consulte [Password-Protect Presentations](/slides/es/php-java/password-protected-presentation/). Si una presentación cifrada se guardó deliberadamente con propiedades de documento públicas, esas propiedades pueden leerse sin una contraseña; consulte [Manage Presentation Properties](/slides/es/php-java/presentation-properties/).

## **Abrir presentaciones grandes**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) devuelve opciones que controlan cómo Aspose.Slides maneja objetos binarios grandes, como imágenes, audio y vídeo. Puede mantener el archivo fuente bloqueado, permitir archivos temporales y limitar la cantidad de datos BLOB retenidos en memoria.

El siguiente código PHP muestra cómo cargar una presentación grande (por ejemplo, 2 GB):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Nota" %}}
Con [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), el archivo fuente permanece bloqueado hasta que la instancia de la presentación se libere. No mueva, sobrescriba ni elimine el archivo fuente mientras esa instancia esté activa.

Aspose.Slides puede copiar el contenido de un flujo de entrada al cargarlo. Para presentaciones grandes, una ruta de archivo es, por lo tanto, generalmente más eficiente que un flujo. Consulte [Manage BLOBs](/slides/es/php-java/manage-blob/) para opciones adicionales de almacenamiento y gestión de memoria.
{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) acepta una implementación de la interfaz Java [IResourceLoadingCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/iresourceloadingcallback/) mediante PHP/Java Bridge. La devolución de llamada puede proporcionar datos de sustitución, redirigir un recurso, usar el cargador predeterminado o omitir el recurso. Esto es útil cuando las presentaciones contienen imágenes externas que deben resolverse de acuerdo con reglas específicas de seguridad o almacenamiento de la aplicación.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación puede contener datos binarios incrustados que una aplicación no necesita o no desea conservar. Los ejemplos incluyen:

- Proyectos VBA, disponibles a través de [Presentation::getVbaProject](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getVbaProject);
- Datos OLE incrustados, disponibles a través de [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/es/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- Datos de controles ActiveX, disponibles a través de [Control::getActiveXControlBinary](https://reference.aspose.com/slides/es/php-java/aspose.slides/control/#getActiveXControlBinary).

Establezca [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) en `true` para eliminar estos datos binarios durante la carga. Guarde la presentación cargada para conservar el resultado sanitizado.

Esta opción reduce la exposición a cargas útiles incrustadas no deseadas, pero no es un sistema completo de detección de malware o de sanitización de contenido.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Cómo puedo saber que un archivo está corrupto y no puede abrirse?**

Aspose.Slides lanza una excepción de análisis o de formato durante la carga. Maneje esa falla por separado de un error de contraseña incorrecta para que la aplicación pueda informar la causa con precisión.

**¿Qué ocurre si faltan fuentes necesarias?**

La presentación aún puede cargarse, pero la representación y la exportación pueden sustituir fuentes. Puede [configure font substitution](/slides/es/php-java/font-substitution/) o [provide custom fonts](/slides/es/php-java/custom-font/) para que la salida sea más predecible.

**¿La carga de una presentación también carga sus medios incrustados?**

El audio y vídeo incrustados están disponibles a través del modelo de objetos de la presentación. Los recursos externos se resuelven de acuerdo con el comportamiento de carga de recursos configurado y pueden no estar disponibles si sus ubicaciones no pueden accederse.

{{% /alert %}}