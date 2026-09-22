---
title: Guardar presentaciones en PHP
linktitle: Guardar presentación
type: docs
weight: 80
url: /es/php-java/save-presentation/
keywords:
- guardar PowerPoint
- guardar OpenDocument
- guardar presentación
- guardar diapositiva
- guardar PPT
- guardar PPTX
- guardar ODP
- presentación a archivo
- presentación a flujo
- tipo de vista predefinido
- Formato Strict Office Open XML
- modo Zip64
- actualizar miniatura
- progreso de guardado
- PHP
- Aspose.Slides
description: "Guardar presentaciones PowerPoint y OpenDocument en archivos o flujos en PHP con Aspose.Slides, y configurar la salida PPTX y el informe de progreso."
---
## **Descripción general**

Después de crear una presentación o [abrir una existente](/slides/es/php-java/open-presentation/), utilice el método [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) para escribir el resultado. Aspose.Slides for PHP via Java puede guardar una presentación en un archivo o flujo en formatos PowerPoint, OpenDocument, PDF y otros. Las siguientes secciones describen las operaciones de guardado estándar y las opciones disponibles para la salida PPTX.

## **Guardar presentaciones en archivos**

Para guardar una presentación en un archivo, pase la ruta de salida y un valor [SaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/) al método [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save). El valor de formato determina el tipo de archivo que crea Aspose.Slides.

El siguiente ejemplo crea una presentación y la guarda como un archivo PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Añadir o modificar el contenido de la presentación aquí.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Guardar presentaciones en su formato original**

Para ejemplos de detección de archivos y flujos, el comportamiento de presentaciones recién creadas y la distinción entre formatos de origen y de salida, consulte [Determinar el formato original de la presentación](/slides/es/php-java/detect-presentation-source-format/).

En una aplicación de procesamiento por lotes, el formato de entrada puede no conocerse de antemano. Después de cargar un archivo, lea su formato original mediante el método [Presentation::getSourceFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSourceFormat). Pase el valor resultante [SourceFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/sourceformat/) a [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideutil/#toSaveFormat) para obtener el valor [SaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/) correspondiente, y luego use [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) para escribir la presentación modificada.

El siguiente ejemplo completo procesa cada archivo en un directorio de entrada, actualiza su título y lo guarda en un directorio de salida en el formato con el que se cargó:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideutil/#toSaveFormat) asigna PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP y PowerPoint XML a sus respectivos formatos de guardado de presentación. Sólo asigna formatos de origen de presentación; no está pensado para seleccionar formatos de exportación como PDF, HTML, TIFF o imágenes. Pasar un valor [SourceFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/sourceformat/) no compatible o inválido produce una [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Los archivos heredados PPT, PPS y POT utilizan el mismo contenedor binario. Cuando una presentación de este tipo se carga desde un flujo sin extensión de archivo, un archivo PPS o POT puede identificarse como PPT. Si es necesario conservar estos subtipos heredados, retenga el nombre de archivo original o los metadatos de formato por separado y úselos al elegir el nombre de archivo y el formato de salida.

## **Guardar presentaciones en flujos**

Para escribir una presentación sin depender de una ruta de archivo final, pase un flujo escribible y un valor [SaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/) al método [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save). Este enfoque es útil cuando la salida debe devolverse desde un servicio web, almacenarse en una base de datos o procesarse en memoria.

El siguiente ejemplo guarda una nueva presentación en un flujo de archivo:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Guardar presentaciones con un tipo de vista predefinido**

Puede especificar la vista en la que PowerPoint abre inicialmente una presentación guardada. Use el método [ViewProperties::setLastView](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/#setLastView) con un valor [ViewType](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewtype/) antes de guardar.

El siguiente ejemplo configura la vista Slide Master como vista inicial:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Guardar presentaciones en el formato Strict Office Open XML**

Para crear un archivo PPTX que cumpla el perfil Strict de Office Open XML, cree una instancia de [PptxOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxoptions/) y utilice su método [PptxOptions::setConformance](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxoptions/#setConformance) con [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/es/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Luego pase las opciones al método [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo ZIP estándar limita el tamaño comprimido y descomprimido de cada entrada, el tamaño total del archivo y el número de entradas. Dado que un archivo PPTX es un archivo ZIP, una presentación muy grande puede superar esos límites. Las extensiones ZIP64 aumentan los límites de tamaño y número de entradas aplicables.

Utilice el método [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxoptions/#setZip64Mode) para controlar si Aspose.Slides escribe extensiones ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/es/php-java/aspose.slides/zip64mode/#IfNecessary) usa ZIP64 solo cuando la presentación supera los límites estándar de ZIP. Este es el modo predeterminado.
- [Never](https://reference.aspose.com/slides/es/php-java/aspose.slides/zip64mode/#Never) desactiva las extensiones ZIP64.
- [Always](https://reference.aspose.com/slides/es/php-java/aspose.slides/zip64mode/#Always) siempre escribe extensiones ZIP64.

El siguiente ejemplo siempre habilita las extensiones ZIP64 para la presentación de salida:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Si se usa [Zip64Mode::Never](https://reference.aspose.com/slides/es/php-java/aspose.slides/zip64mode/#Never) y la presentación no cabe dentro de los límites estándar de ZIP, la operación de guardado lanza una [PptxException](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Guardar presentaciones en formato Office Open XML con niveles de compresión**

Para la salida PPTX, puede equilibrar la velocidad de guardado con el tamaño del archivo usando el método [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxoptions/#setCompressionLevel). La clase [CompressionLevel](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/) proporciona estos valores:

- [None](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#None) almacena los datos sin compresión.
- [Level1](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level1) ofrece la compresión más rápida y el archivo comprimido más grande.
- [Level2](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level2) a [Level5](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level5) favorecen progresivamente un archivo más pequeño sobre la velocidad de guardado.
- [Level6](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level6) equilibra la velocidad de guardado y el tamaño del archivo. Este es el nivel predeterminado.
- [Level7](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level7) y [Level8](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level8) favorecen aún más un archivo más pequeño sobre la velocidad de guardado.
- [Level9](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level9) ofrece la compresión más fuerte y requiere más tiempo de procesamiento.

El siguiente ejemplo guarda una presentación sin compresión:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

El siguiente ejemplo usa el nivel máximo de compresión:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Guardar presentaciones sin actualizar la miniatura**

Cuando una presentación se guarda como PPTX, el método [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla su miniatura de documento:

- `true` regenera la miniatura durante la operación de guardado. Este es el valor predeterminado.
- `false` conserva la miniatura existente. Si la presentación no tiene miniatura, Aspose.Slides no genera una.

El siguiente ejemplo guarda una presentación sin actualizar su miniatura:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Desactivar la actualización de la miniatura puede reducir el tiempo necesario para guardar un archivo PPTX.
{{% /alert %}}

## **Guardar actualizaciones de progreso en porcentaje**

Para supervisar una operación de guardado, proporcione un proxy Java que implemente la interfaz [IProgressCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprogresscallback/) y pase el proxy al método [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides entonces llama al método [IProgressCallback::reporting](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprogresscallback/#reporting-double-) con valores de progreso durante la exportación.

El siguiente ejemplo informa del progreso de una exportación PDF en la consola:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose ofrece un [PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) gratuito construido con la API Aspose.Slides. Guarda diapositivas seleccionadas de una presentación como archivos PPT o PPTX separados.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Aspose.Slides admite guardado incremental o “fast save”?**

No. Cada operación de guardado escribe un archivo de salida completo en lugar de actualizar solo las partes modificadas.

**¿Pueden varios hilos guardar la misma instancia de Presentation?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) [no es segura para subprocesos](/slides/es/php-java/multithreading/). Acceda y guarde cada instancia sólo desde un hilo a la vez.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar una presentación?**

[Hyperlinks](/slides/es/php-java/manage-hyperlinks/) permanecen en la presentación. Aspose.Slides no copia los archivos vinculados externamente, por lo que la presentación guardada debe seguir pudiendo acceder a sus ubicaciones.

**¿Puedo guardar metadatos del documento como autor, título, empresa y fecha de creación?**

Sí. Establezca las [propiedades del documento](/slides/es/php-java/presentation-properties/) apropiadas antes de guardar, y Aspose.Slides las escribe en el archivo de salida.