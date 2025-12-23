---
title: Abrir presentaciones en PHP
linktitle: Abrir presentación
type: docs
weight: 20
url: /es/php-java/open-presentation/
keywords:
- abrir PowerPoint
- abrir OpenDocument
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
description: "Abra presentaciones PowerPoint (.pptx, .ppt) y OpenDocument (.odp) sin esfuerzo con Aspose.Slides para PHP a través de Java — rápido, fiable, con todas las funciones."
---

## **Descripción general**

Más allá de crear presentaciones de PowerPoint desde cero, Aspose.Slides también le permite abrir presentaciones existentes. Después de cargar una presentación, puede obtener información sobre ella, editar el contenido de las diapositivas, agregar nuevas diapositivas, eliminar las existentes y mucho más.

## **Abrir presentaciones**

Para abrir una presentación existente, instancie la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y pase la ruta del archivo a su constructor.

El siguiente ejemplo en PHP muestra cómo abrir una presentación y obtener su recuento de diapositivas:
```php
// Instanciar la clase Presentation y pasar una ruta de archivo a su constructor.
$presentation = new Presentation("Sample.pptx");
try {
    // Imprimir el número total de diapositivas en la presentación.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```


## **Abrir presentaciones protegidas con contraseña**

Cuando necesite abrir una presentación protegida con contraseña, pase la contraseña a través del método [setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) de la clase [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) para descifrarla y cargarla. El siguiente código PHP demuestra esta operación:
```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Realizar operaciones en la presentación descifrada.
} finally {
    $presentation->dispose();
}
```


## **Abrir presentaciones de gran tamaño**

Aspose.Slides ofrece opciones—en particular el método [getBlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) de la clase [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)—para ayudarle a cargar presentaciones de gran tamaño.

El siguiente código PHP muestra cómo cargar una presentación grande (por ejemplo, 2 GB):
```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Elegir el comportamiento KeepLocked—el archivo de la presentación permanecerá bloqueado durante la vida útil de
// la instancia Presentation, pero no necesita cargarse en memoria ni copiarse a un archivo temporal.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // La gran presentación se ha cargado y puede usarse, mientras el consumo de memoria se mantiene bajo.

    // Realizar cambios en la presentación.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Guardar la presentación en otro archivo. El consumo de memoria se mantiene bajo durante esta operación.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// ¡No haga esto! Se lanzará una excepción de E/S porque el archivo está bloqueado hasta que se libere el objeto Presentation.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// Está bien hacerlo aquí. El archivo fuente ya no está bloqueado por el objeto Presentation.
unlink($filePath);
```


{{% alert color="info" title="Info" %}}
Para solucionar ciertas limitaciones al trabajar con flujos, Aspose.Slides puede copiar el contenido de un flujo. Cargar una presentación grande desde un flujo provoca que la presentación se copie y puede ralentizar la carga. Por lo tanto, cuando necesite cargar una presentación grande, recomendamos encarecidamente usar la ruta del archivo de presentación en lugar de un flujo.

Al crear una presentación que contenga objetos grandes (video, audio, imágenes de alta resolución, etc.), puede utilizar la [gestión de BLOB](/slides/es/php-java/manage-blob/) para reducir el consumo de memoria.
{{%/alert %}}

## **Controlar recursos externos**

Aspose.Slides proporciona la interfaz [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) que le permite gestionar recursos externos. El siguiente código PHP muestra cómo usar la interfaz `IResourceLoadingCallback`:
```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Cargar una imagen de sustitución.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Establecer una URL de sustitución.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Omitir todas las demás imágenes.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```


## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación de PowerPoint puede contener los siguientes tipos de objetos binarios incrustados:

- proyecto VBA (accesible mediante [Presentation.getVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject));
- datos incrustados de objetos OLE (accesibles mediante [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- datos binarios de controles ActiveX (accesibles mediante [Control.getActiveXControlBinary](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getActiveXControlBinary)).

Utilizando el método [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), puede cargar una presentación sin ningún objeto binario incrustado.

Este método es útil para eliminar contenido binario potencialmente malicioso. El siguiente código PHP demuestra cómo cargar una presentación sin contenido binario incrustado:
```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Realizar operaciones en la presentación.
} finally {
    $presentation->dispose();
}
```


## **Preguntas frecuentes**

**¿Cómo puedo saber que un archivo está corrupto y no se puede abrir?**

Recibirá una excepción de análisis/validación de formato durante la carga. Estos errores a menudo indican una estructura ZIP no válida o registros de PowerPoint dañados.

**¿Qué ocurre si faltan fuentes requeridas al abrir?**

El archivo se abrirá, pero más adelante la [renderización/exportación](/slides/es/php-java/convert-presentation/) puede sustituir fuentes. [Configure sustituciones de fuentes](/slides/es/php-java/font-substitution/) o [agregue las fuentes requeridas](/slides/es/php-java/custom-font/) al entorno de ejecución.

**¿Qué pasa con los medios incrustados (video/audio) al abrir?**

Se convierten en recursos de la presentación. Si los medios se referencian mediante rutas externas, asegúrese de que esas rutas sean accesibles en su entorno; de lo contrario, la [renderización/exportación](/slides/es/php-java/convert-presentation/) puede omitir los medios.