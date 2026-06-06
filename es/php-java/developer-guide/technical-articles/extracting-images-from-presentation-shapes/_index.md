---
title: Extraer imágenes de formas de presentación en PHP
linktitle: Imagen de forma
type: docs
weight: 100
url: /es/php-java/extracting-images-from-presentation-shapes/
keywords:
- extraer imagen
- recuperar imagen
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Extrae imágenes de formas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para PHP vía Java: solución rápida y fácil de usar."
---
## **Visión general**

Las imágenes en una presentación pueden aparecer en varios tipos de forma: como marcos de imagen ordinarios, como rellenos de imagen aplicados a formas, como imágenes de vista previa de objetos OLE, como miniaturas de fotogramas de vídeo o audio, como imágenes de zoom, o como imágenes anidadas dentro de formas de tabla, gráfico y SmartArt. Aspose.Slides almacena esas imágenes en la colección de imágenes de la presentación, expuesta a través de [ImageCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagecollection/) y [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) objetos.

Si solo necesita exportar cada recurso de imagen incrustado en una presentación, itere a través de `presentation->getImages()`. Este artículo se centra en una tarea diferente: recorrer las formas para encontrar dónde se utilizan imágenes en las diapositivas, de modo que los archivos guardados puedan conservar un contexto útil como el número de diapositiva, la posición de la forma y el tipo de origen (marco de imagen, imagen de relleno, vista previa multimedia, vista previa OLE o imagen de zoom).

{{% alert title="Tip" color="primary" %}}
Utilice [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) y su método `getBinaryData()` para preservar los datos de imagen codificados originales y el tipo de archivo. Use `getImage()` cuando desee normalizar la salida a un formato específico como PNG.
{{% /alert %}}

## **Métodos auxiliares compartidos**

Los métodos auxiliares a continuación mantienen los ejemplos breves. `saveOriginalImage` escribe los bytes originales incrustados, elige una extensión segura a partir del tipo MIME y omite binarios de imagen duplicados mediante hash SHA-256.

```php
use aspose\slides\FillType;
use aspose\slides\ImageFormat;

class ShapeReference
{
    public $shape;
    public $namePart;

    public function __construct($shape, $namePart)
    {
        $this->shape = $shape;
        $this->namePart = $namePart;
    }
}

function isNullJava($value)
{
    return $value == null || java_is_null($value);
}

function saveOriginalImage($image, $outputDirectory, $fileNameBase, &$savedImageHashes)
{
    if (isNullJava($image)) {
        return false;
    }

    $imageData = $image->getBinaryData();
    $imageBytes = getBinaryString($imageData);
    $imageHash = hash("sha256", $imageBytes);
    if (isset($savedImageHashes[$imageHash])) {
        return false;
    }

    $savedImageHashes[$imageHash] = true;

    $extension = getExtensionFromContentType($image->getContentType());
    $fileName = $fileNameBase . "." . $extension;
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
    file_put_contents($outputPath, $imageBytes);
    return true;
}

function saveImageAsPng($image, $outputDirectory, $fileNameBase)
{
    if (isNullJava($image)) {
        return false;
    }

    $fileName = $fileNameBase . ".png";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;

    $outputImage = $image->getImage();
    try {
        $outputImage->save($outputPath, ImageFormat::Png);
    } finally {
        if (!isNullJava($outputImage)) {
            $outputImage->dispose();
        }
    }

    return true;
}

function getPictureFillImage($fillFormat)
{
    if (isNullJava($fillFormat) || java_values($fillFormat->getFillType()) != FillType::Picture) {
        return null;
    }

    return $fillFormat->getPictureFillFormat()->getPicture()->getImage();
}

function enumerateShapes($shapes, $prefix, $includeGroupedShapes)
{
    $shapeReferences = [];
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $displayIndex = $shapeIndex + 1;
        $shapeNamePart = $prefix . "_shape_" . $displayIndex;
        $shapeReferences[] = new ShapeReference($shape, $shapeNamePart);

        if ($includeGroupedShapes && java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
            $childShapes = $shape->getShapes();
            $childReferences = enumerateShapes(
                $childShapes,
                $shapeNamePart,
                $includeGroupedShapes
            );
            $shapeReferences = array_merge($shapeReferences, $childReferences);
        }
    }

    return $shapeReferences;
}

function getBinaryString($binaryData)
{
    $bytes = java_values($binaryData);
    if (is_string($bytes)) {
        return $bytes;
    }

    $binaryString = "";
    foreach ($bytes as $byte) {
        $binaryString .= chr($byte & 0xff);
    }

    return $binaryString;
}

function getExtensionFromContentType($contentType)
{
    if ($contentType == null || strlen(trim($contentType)) == 0) {
        return "bin";
    }

    $mediaTypeParts = explode(";", $contentType);
    $mediaType = strtolower(trim($mediaTypeParts[0]));
    if ($mediaType == "image/jpeg") {
        return "jpg";
    }

    if ($mediaType == "image/png") {
        return "png";
    }

    if ($mediaType == "image/gif") {
        return "gif";
    }

    if ($mediaType == "image/bmp") {
        return "bmp";
    }

    if ($mediaType == "image/tiff") {
        return "tiff";
    }

    if ($mediaType == "image/x-emf" || $mediaType == "image/emf") {
        return "emf";
    }

    if ($mediaType == "image/x-wmf" || $mediaType == "image/wmf") {
        return "wmf";
    }

    if ($mediaType == "image/svg+xml") {
        return "svg";
    }

    if (strpos($mediaType, "image/") === 0) {
        $extension = substr($mediaType, strlen("image/"));
        return makeSafeFileNamePart($extension);
    }

    return "bin";
}

function makeSafeFileNamePart($value)
{
    return preg_replace("/[^A-Za-z0-9._-]/", "_", $value);
}
```

## **Extraer imágenes de marcos de imagen**

Utilice este enfoque para imágenes insertadas como objetos independientes. Un [PictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/) almacena su imagen en `getPictureFormat()->getPicture()->getImage()`, que devuelve un objeto [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/).

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "extracted-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $pictureFrame = $shapeReference->shape;
                $image = $pictureFrame->getPictureFormat()->getPicture()->getImage();
                saveOriginalImage($image, $outputDirectory, $shapeReference->namePart, $savedImageHashes);
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraer imágenes de formas con relleno de imagen**

Las formas pueden usar una imagen como su relleno. Compruebe primero el tipo de relleno de la forma: si no es [FillType.Picture](https://reference.aspose.com/slides/es/php-java/aspose.slides/filltype/), no hay imagen que extraer de ese relleno. El ejemplo a continuación maneja objetos [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) y guarda cada imagen como PNG mediante [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) y su método `getImage()`.

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "shape-fill-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shapeReference->shape;
                $fillFormat = $autoShape->getFillFormat();
                $image = getPictureFillImage($fillFormat);
                if (!isNullJava($image)) {
                    saveImageAsPng($image, $outputDirectory, $shapeReference->namePart);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraer imágenes de vista previa de marcos de objetos OLE**

Un [OleObjectFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/oleobjectframe/) puede tener una imagen sustituta que PowerPoint utiliza como vista previa del objeto en una diapositiva. Esta imagen está disponible a través de `getSubstitutePictureFormat()->getPicture()->getImage()`. Extraer esta imagen le proporciona la vista previa, no el contenido del paquete OLE incrustado.

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "ole-preview-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $oleObjectFrame = $shapeReference->shape;
                $image = $oleObjectFrame->getSubstitutePictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_ole_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraer imágenes de vista previa de marcos de vídeo**

Un [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) también puede almacenar una imagen de vista previa en `getPictureFormat()->getPicture()->getImage()`. Esta es el póster o miniatura que se muestra en la diapositiva, no un fotograma decodificado del flujo de vídeo.

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "video-preview-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shapeReference->shape;
                $image = $videoFrame->getPictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_video_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraer imágenes de vista previa de marcos de audio**

Un [AudioFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/audioframe/) puede almacenar una miniatura en `getPictureFormat()->getPicture()->getImage()`. Esta es la imagen que se muestra para el objeto de audio en la diapositiva.

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "audio-preview-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $audioFrame = $shapeReference->shape;
                $image = $audioFrame->getPictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_audio_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraer imágenes de objetos de zoom**

[ZoomFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/zoomframe/) y [SectionZoomFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/sectionzoomframe/) pueden usar imágenes personalizadas. Lea `getZoomImage()` del marco de zoom.

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "zoom-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.ZoomFrame"))) {
                $zoomFrame = $shapeReference->shape;
                $image = $zoomFrame->getZoomImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_zoom";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                    continue;
                }
            }

            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.SectionZoomFrame"))) {
                $sectionZoomFrame = $shapeReference->shape;
                $image = $sectionZoomFrame->getZoomImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_section_zoom";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                    continue;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraer imágenes de marcos de zoom de resumen**

Un [SummaryZoomFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/summaryzoomframe/) también es una forma. Sus elementos de sección pueden usar imágenes personalizadas, expuestas a través del método `getZoomImage()` de cada sección de zoom de resumen.

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "summary-zoom-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.SummaryZoomFrame"))) {
                $summaryZoomFrame = $shapeReference->shape;
                $summaryZoomCollection = $summaryZoomFrame->getSummaryZoomCollection();
                $sectionCount = java_values($summaryZoomCollection->size());
                for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
                    $summaryZoomSection = $summaryZoomCollection->get_Item($sectionIndex);
                    $image = $summaryZoomSection->getZoomImage();
                    if (!isNullJava($image)) {
                        $displayIndex = $sectionIndex + 1;
                        $fileNameBase = $shapeReference->namePart . "_summary_zoom_" . $displayIndex;
                        saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraer imágenes de formas de tabla**

Una [Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/table/) es una forma. Las imágenes en una tabla suelen almacenarse como rellenos de imagen en las celdas de la tabla.

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "table-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, true);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.Table"))) {
                $table = $shapeReference->shape;
                $rowCount = java_values($table->getRows()->size());
                $columnCount = java_values($table->getColumns()->size());
                for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++) {
                    for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++) {
                        $cell = $table->get_Item($columnIndex, $rowIndex);
                        $fillFormat = $cell->getCellFormat()->getFillFormat();
                        $image = getPictureFillImage($fillFormat);
                        if (!isNullJava($image)) {
                            $displayRow = $rowIndex + 1;
                            $displayColumn = $columnIndex + 1;
                            $fileNameBase = $shapeReference->namePart . "_cell_" . $displayRow . "_" . $displayColumn;
                            saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                        }
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraer imágenes de formas de gráfico**

Un [Chart](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/) es una forma. El ejemplo a continuación extrae una imagen del relleno de imagen del área del gráfico.

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "chart-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, true);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.Chart"))) {
                $chart = $shapeReference->shape;
                $fillFormat = $chart->getFillFormat();
                $image = getPictureFillImage($fillFormat);
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_chart_area";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraer imágenes de formas SmartArt**

Un objeto [SmartArt](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartart/) es una forma. Dependiendo del diseño de SmartArt, las imágenes pueden almacenarse en los rellenos de viñetas de los nodos o en los formatos de relleno de las formas de los nodos.

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "smartart-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, true);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $smartArt = $shapeReference->shape;
                $allNodes = $smartArt->getAllNodes();
                $nodeCount = java_values($allNodes->size());
                for ($nodeIndex = 0; $nodeIndex < $nodeCount; $nodeIndex++) {
                    $node = $allNodes->get_Item($nodeIndex);
                    $bulletFillFormat = $node->getBulletFillFormat();
                    $bulletImage = getPictureFillImage($bulletFillFormat);
                    if (!isNullJava($bulletImage)) {
                        $displayNode = $nodeIndex + 1;
                        $fileNameBase = $shapeReference->namePart . "_smartart_node_" . $displayNode . "_bullet";
                        saveOriginalImage($bulletImage, $outputDirectory, $fileNameBase, $savedImageHashes);
                    }

                    $nodeShapes = $node->getShapes();
                    $nodeShapeCount = java_values($nodeShapes->size());
                    for ($nodeShapeIndex = 0; $nodeShapeIndex < $nodeShapeCount; $nodeShapeIndex++) {
                        $nodeShape = $nodeShapes->get_Item($nodeShapeIndex);
                        $fillFormat = $nodeShape->getFillFormat();
                        $image = getPictureFillImage($fillFormat);
                        if (!isNullJava($image)) {
                            $displayNode = $nodeIndex + 1;
                            $displayNodeShape = $nodeShapeIndex + 1;
                            $fileNameBase = $shapeReference->namePart . "_smartart_node_" . $displayNode . "_shape_" . $displayNodeShape;
                            saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                        }
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Incluir imágenes dentro de formas agrupadas**

Las formas agrupadas contienen sus propias colecciones de formas. El auxiliar compartido `enumerateShapes` tiene una opción `includeGroupedShapes`. Establézcala en `true` cuando quiera inspeccionar las formas dentro de objetos [GroupShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/groupshape/). El ejemplo a continuación extrae imágenes de marcos de imagen, formas con relleno de imagen, vistas previas de objetos OLE, miniaturas de marcos de vídeo y miniaturas de marcos de audio. Para incluir también imágenes de tablas, gráficos, SmartArt y zoom de resumen, reutilice la lógica de extracción especializada de las secciones anteriores manteniendo el mismo recorrido recursivo de formas.

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "all-shape-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, true);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $oleObjectFrame = $shapeReference->shape;
                $image = $oleObjectFrame->getSubstitutePictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_ole_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }

                continue;
            }

            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shapeReference->shape;
                $image = $videoFrame->getPictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_video_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }

                continue;
            }

            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $audioFrame = $shapeReference->shape;
                $image = $audioFrame->getPictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_audio_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }

                continue;
            }

            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $pictureFrame = $shapeReference->shape;
                $image = $pictureFrame->getPictureFormat()->getPicture()->getImage();
                saveOriginalImage($image, $outputDirectory, $shapeReference->namePart, $savedImageHashes);
                continue;
            }

            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shapeReference->shape;
                $fillFormat = $autoShape->getFillFormat();
                $image = getPictureFillImage($fillFormat);
                if (!isNullJava($image)) {
                    saveOriginalImage($image, $outputDirectory, $shapeReference->namePart, $savedImageHashes);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Casos límite y notas prácticas**

- **Imágenes duplicadas:** Varias formas pueden referenciar la misma imagen o imágenes distintas con bytes idénticos. Haga hash de los datos de [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) mediante `getBinaryData()` antes de escribir los archivos si desea un archivo de salida por cada imagen única.
- **Datos originales vs. salida convertida:** Guardar los datos de [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) mediante `getBinaryData()` preserva los datos JPEG, PNG, GIF, SVG, EMF o WMF incrustados. Guardar la imagen devuelta por `getImage()` es útil cuando desea un formato de salida consistente.
- **Tipos de relleno no soportados:** Los tipos sólido, degradado, patrón y sin relleno no contienen una imagen de relleno. Compruebe [FillType](https://reference.aspose.com/slides/es/php-java/aspose.slides/filltype/) antes de leer `getPictureFillFormat()`.
- **Formas agrupadas:** La colección de formas de nivel superior de la diapositiva no aplana los grupos. Inspeccione recursivamente el contenido de [GroupShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/groupshape/) mediante `getShapes()` cuando el contenido agrupado sea relevante.
- **Vistas previas de objetos OLE:** Un [OleObjectFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/oleobjectframe/) puede exponer una imagen de vista previa mediante `getSubstitutePictureFormat()`, pero esa imagen es solo la vista previa de la diapositiva. No es el archivo incrustado dentro del objeto OLE.
- **Miniaturas de marcos de vídeo:** Un [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) puede exponer una imagen de vista previa mediante `getPictureFormat()`, pero esa imagen es solo el póster mostrado en la diapositiva. No se extrae del flujo de vídeo.
- **Miniaturas de marcos de audio:** Un [AudioFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/audioframe/) puede exponer un icono o miniatura mediante `getPictureFormat()`; no son los datos de audio incrustados.
- **Imágenes de zoom:** Las formas de zoom de diapositiva, zoom de sección y zoom de resumen pueden usar objetos [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) personalizados mediante `getZoomImage()`.
- **Modelos de forma anidados:** Los objetos de tabla, gráfico y SmartArt implementan [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/), pero sus imágenes a menudo se almacenan en objetos de formato anidados de celdas de tabla, elementos de gráfico o nodos de SmartArt.
- **Imágenes recortadas o transformadas:** Acceder a [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) le proporciona el recurso de imagen almacenado. No renderiza recortes, transparencia, recoloración, rotación u otros efectos visuales aplicados por la forma.

## **Preguntas frecuentes**

**¿Puedo extraer la imagen original sin recortes, efectos o transformaciones de forma?**

Sí. Acceda al objeto [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) y escriba los datos de `getBinaryData()` en disco. Esto preserva la imagen codificada original almacenada en la presentación, no la forma en que la imagen se muestra en la diapositiva.

**¿Puedo exportar cada imagen extraída como PNG?**

Sí. Utilice [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) y su método `getImage()`, y luego llame a `save()` con [ImageFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/imageformat/). Esto convierte la salida y puede no conservar el tipo de archivo original ni los datos vectoriales.

**¿Cómo evito guardar la misma imagen más de una vez?**

Utilice un hash de los datos de [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) obtenidos con `getBinaryData()` y mantenga los hashes en un conjunto. Si una nueva imagen tiene un hash que ya existe, omítala o registre otra referencia al archivo de salida existente.

**¿Por qué algunas formas no generan una imagen?**

Los marcos de imagen, las formas con relleno de imagen, los marcos de objetos OLE, los marcos multimedia, los marcos de zoom, las tablas, los gráficos y los objetos SmartArt pueden referenciar imágenes. Algunos tipos de forma exponen imágenes mediante objetos de formato anidados, por lo que una simple comprobación de `getPictureFormat()` o `getFillFormat()` no siempre basta.

**¿Puedo extraer la miniatura mostrada para un marco de vídeo?**

Sí. Utilice [VideoFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoframe/) y lea `getPictureFormat()->getPicture()->getImage()`. Esto extrae la imagen de póster almacenada con el marco de vídeo, no un fotograma generado a partir del archivo de vídeo.

**¿Cómo puedo determinar qué formas usan una imagen específica de la colección de imágenes de la presentación?**

Aspose.Slides no almacena enlaces inversos de [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) a las formas. Construya un mapeo durante el recorrido: cada vez que encuentre una referencia a una imagen, registre el número de diapositiva, la ruta de la forma y el hash o el elemento de la colección de la imagen.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

Puede extraer la vista previa de diapositiva del objeto OLE mediante [OleObjectFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/oleobjectframe/). Sin embargo, esa vista previa no es el documento incrustado en sí. Para extraer imágenes del archivo incrustado, extraiga los datos OLE y examínelos con herramientas adecuadas para ese tipo de archivo.