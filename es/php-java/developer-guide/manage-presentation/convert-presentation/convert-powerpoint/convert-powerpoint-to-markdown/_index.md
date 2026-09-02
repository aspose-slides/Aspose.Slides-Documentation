---
title: Convertir presentaciones de PowerPoint a Markdown en PHP
linktitle: PowerPoint a Markdown
type: docs
weight: 140
url: /es/php-java/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a MD
- presentación a MD
- diapositiva a MD
- PPT a MD
- PPTX a MD
- guardar PowerPoint como Markdown
- guardar presentación como Markdown
- guardar diapositiva como Markdown
- guardar PPT como MD
- guardar PPTX como MD
- exportar PPT a MD
- exportar PPTX a MD
- exportación de imágenes en Markdown
- enlaces de imágenes CDN
- PowerPoint
- presentación
- Markdown
- PHP
- Aspose.Slides
description: "Convertir presentaciones PPT y PPTX a Markdown en PHP y controlar dónde se guardan y referencian las imágenes exportadas (bitmap, metafile y SVG)."
---
## **Descripción general**

Aspose.Slides for PHP a través de Java puede convertir presentaciones PPT y PPTX a Markdown para documentación, sitios estáticos, migración de contenido y flujos de trabajo de control de versiones. Puede elegir un sabor de Markdown, controlar cómo se renderiza el contenido de las diapositivas y decidir dónde se almacenan las imágenes exportadas y cómo el Markdown generado las referencia.

De forma predeterminada, la exportación a Markdown utiliza salida solo de texto. Para exportar contenido visual, establezca el tipo de exportación con el método [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/) al valor `Sequential` o `Visual` de la enumeración [MarkdownExportType](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownexporttype/). `Sequential` renderiza los elementos de la diapositiva por separado y en orden, mientras que `Visual` mantiene los elementos agrupados juntos para preservar su relación visual. El valor `TextOnly` no genera recursos de imagen, por lo que los callbacks de guardado de imágenes no se invocan en ese modo.

## **Convertir una presentación a Markdown**

Cargue el archivo fuente con la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/), y luego llame al método [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) con el valor `Md` de la enumeración [SaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Seleccionar un sabor de Markdown**

El método [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/) controla la especificación de Markdown utilizada para la salida. La enumeración [Flavor](https://reference.aspose.com/slides/es/php-java/aspose.slides/flavor/) incluye CommonMark, GitHub Flavored Markdown y otras variantes admitidas.

El siguiente ejemplo exporta una presentación como CommonMark:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Exportar imágenes utilizando el comportamiento predeterminado de guardado local**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/) proporciona dos métodos para configurar imágenes guardadas localmente:

- [setBasePath](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/) especifica el directorio base para el documento Markdown y sus recursos.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/) especifica el subdirectorio de imágenes. Su valor predeterminado es `Images`.

El siguiente ejemplo renderiza contenido visual, escribe imágenes en `output/assets` y crea referencias de imagen relativas en el documento Markdown:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Este comportamiento también sirve como alternativa cuando un controlador personalizado de guardado de imágenes devuelve `false`.

## **Personalizar el guardado de imágenes y los enlaces Markdown**

Utilice el método [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/) para registrar un callback para recursos bitmap y metafile no SVG emitidos durante la exportación a Markdown. Su callback `MarkdownImageSavingHandler` recibe el objeto [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/), su valor [ImageFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/imageformat/) y el enlace Markdown generado como una matriz de cadena Java de un solo elemento. Guarde o cargue la imagen con el formato proporcionado, y reemplace `$link[0]` con la referencia que debe aparecer en la salida Markdown.

Los recursos emitidos en formato SVG se manejan por separado. Registre un callback con el método [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/). Su callback `MarkdownSvgImageSavingHandler` recibe un objeto [ISvgImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/isvgimage/) y la matriz de cadena Java de un solo elemento `$link`. Un SVG no tiene argumento `ImageFormat`; escriba o cargue sus datos XML desde el método [ISvgImage::getSvgData](https://reference.aspose.com/slides/es/php-java/aspose.slides/isvgimage/) en su lugar. Dependiendo del modo de exportación y del agrupamiento visual, un SVG en la presentación origen puede rasterizarse o combinarse con otro contenido; el recurso resultante que no es SVG se pasa entonces al callback de guardado de imágenes. Registre ambos callbacks cuando cada recurso visual exportado requiera un procesamiento personalizado.

En PHP a través de Java, implemente cada callback en una clase PHP y use `java_closure` para exponer ese objeto como la interfaz Java correspondiente.

{{% alert color="info" title="Note" %}}
Inicialice el puente PHP/Java con `JAVA_PREFER_VALUES` habilitado antes de cargar `Java.inc`. El método [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) devuelve `void`, y el modo de flujo predeterminado del puente no puede invocar un callback PHP durante esa llamada encolada. El ejemplo completo a continuación incluye la inicialización requerida.
{{% /alert %}}

El valor devuelto por el controlador determina quién procesa la imagen:

- Devuelva `true` después de que el controlador haya guardado, subido, transformado o procesado de otro modo la imagen y haya asignado un valor válido a `$link[0]`. Aspose.Slides escribe ese valor en el documento Markdown y no realiza su guardado local predeterminado.
- Devuelva `false` para que Aspose.Slides guarde la imagen localmente y genere su enlace según los valores establecidos por [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/) y [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Un controlador que devuelve `true` asume la responsabilidad de la imagen. Si devuelve `true` sin asignar un enlace válido y no vacío, la exportación falla con una `InvalidOperationException`.
{{% /alert %}}

### **Guardar imágenes en un directorio de origen CDN y usar URLs externas**

El siguiente ejemplo trata `cdn-origin/presentations/quarterly-report` como un directorio de origen CDN montado o sincronizado. Cada controlador extrae el nombre de archivo generado, guarda la imagen en ese directorio personalizado y reemplaza la referencia local generada con una URL pública del CDN. El propio ejemplo no realiza ninguna carga de red: la URL solo se vuelve válida después de que el directorio se monte como origen CDN o sus archivos se publiquen en el CDN. Para almacenamiento de objetos, reemplace la escritura en el sistema de archivos con la operación de carga del SDK de almacenamiento y asigne `$link[0]` solo después de que la carga tenga éxito.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

El controlador bitmap devuelve deliberadamente `false` para imágenes menores de 128 × 128 píxeles, por lo que Aspose.Slides guarda esas imágenes en `output/fallback-images` usando el comportamiento predeterminado. Los recursos bitmap y metafile más grandes, así como los recursos SVG, son manejados por el código personalizado. Por ejemplo, una referencia local generada como `fallback-images/image1.png` se convierte en `https://cdn.example.com/presentations/quarterly-report/image1.png`. Los controladores usan rutas del sistema operativo solo al escribir archivos; los enlaces escritos en Markdown usan barras diagonales y nombres de archivo codificados en URL. Aplique la misma regla al construir enlaces relativos: use `/`, no el separador de directorios específico de la plataforma.

## **Preguntas frecuentes**

**¿Puede un único controlador procesar tanto imágenes raster como imágenes SVG?**

No. Use [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/) para los recursos bitmap y metafile emitidos y [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/) para los recursos emitidos como SVG. El primero provee un objeto [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/) y un valor [ImageFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/imageformat/); el segundo provee un objeto [ISvgImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/isvgimage/) cuyos datos SVG pueden leerse con [ISvgImage::getSvgData](https://reference.aspose.com/slides/es/php-java/aspose.slides/isvgimage/). Un SVG fuente que se rasteriza durante la exportación es procesado por el callback de guardado de imágenes en su lugar.

**¿Qué ocurre cuando un controlador de guardado de imágenes devuelve `false`?**

Aspose.Slides usa su comportamiento de guardado local predeterminado. La ubicación de la imagen y la referencia generada están controladas por los valores establecidos con [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/) y [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/es/php-java/aspose.slides/markdownsaveoptions/).

**¿Puede un controlador proporcionar una URL sin guardar la imagen localmente?**

Sí. El controlador puede cargar la imagen a un almacenamiento de objetos o pasarla a otro servicio, asignar la URL resultante a `$link[0]` y devolver `true`. El controlador debe completar el procesamiento por sí mismo; devolver `true` impide el guardado local predeterminado.

**¿Por qué la exportación a Markdown lanza una `InvalidOperationException` desde un controlador?**

Esta excepción ocurre cuando el controlador devuelve `true` pero no proporciona un enlace válido. Asigne la ruta relativa o la URL externa que debe escribirse en Markdown antes de devolver `true`.

**¿Qué separador de rutas deben usar los enlaces de imágenes?**

Use barras diagonales (`/`) en los enlaces Markdown y URLs. Use `DIRECTORY_SEPARATOR` solo para rutas del sistema de archivos, y luego construya o normalice la referencia Markdown por separado.

**¿Se conservan los hipervínculos durante la exportación a Markdown?**

Sí. El texto [hyperlinks](/slides/es/php-java/manage-hyperlinks/) se conserva como enlaces Markdown estándar. Las [transitions](/slides/es/php-java/slide-transition/) y [animations](/slides/es/php-java/powerpoint-animation/) de las diapositivas no se convierten.

**¿Pueden las presentaciones convertirse a Markdown en paralelo?**

Puede procesar diferentes archivos de presentación en paralelo, pero no comparta la misma instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) entre hilos. Siga las [multithreading guidelines](/slides/es/php-java/multithreading/) y use una instancia separada para cada archivo.