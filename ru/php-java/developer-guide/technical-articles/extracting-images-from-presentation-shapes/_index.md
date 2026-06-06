---
title: Извлечение изображений из фигур презентации на PHP
linktitle: Изображение из фигуры
type: docs
weight: 100
url: /ru/php-java/extracting-images-from-presentation-shapes/
keywords:
- извлечь изображение
- получить изображение
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Извлекайте изображения из фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java — быстрое, удобное для кода решение."
---
## **Обзор**

Изображения в презентации могут находиться в нескольких типах фигур: обычные рамки изображений, изображения, используемые как заливка фигур, изображения предварительного просмотра OLE‑объектов, миниатюры видеокадров или аудиокадров, изображения зум‑объектов, а также изображения, вложенные в таблицы, диаграммы и SmartArt‑фигуры. Aspose.Slides хранит эти изображения в коллекции изображений презентации, доступной через объекты [ImageCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/) и [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/).

Если вам нужно только экспортировать все встроенные в презентацию ресурсы‑изображения, пройдитесь по `presentation->getImages()`. Эта статья посвящена другой задаче: обходу фигур, чтобы найти, где изображения используются на слайдах, чтобы сохранённые файлы могли сохранять полезный контекст, такой как номер слайда, позиция фигуры и тип источника (рамка изображения, заливка, предварительный просмотр медиа, предварительный просмотр OLE или зум‑изображение).

{{% alert title="Tip" color="primary" %}}
Используйте [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) и его метод `getBinaryData()`, чтобы сохранить оригинальные закодированные данные изображения и тип файла. Используйте `getImage()`, когда необходимо привести вывод к определённому формату, например PNG.
{{% /alert %}}

## **Общие вспомогательные методы**

Ниже приведённые вспомогательные методы позволяют сократить примеры. `saveOriginalImage` записывает оригинальные встроенные байты, выбирает безопасное расширение из MIME‑типа и пропускает дублирующие двоичные данные изображений по хэшу SHA‑256.

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

## **Извлечение изображений из рамок изображений**

Этот подход используется для картинок, вставленных как отдельные объекты. Объект [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) хранит своё изображение в `getPictureFormat()->getPicture()->getImage()`, который возвращает объект [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/).

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

## **Извлечение изображений из фигур, заполненных картинкой**

Фигуры могут использовать картинку в качестве заливки. Сначала проверьте тип заливки фигуры: если это не [FillType.Picture](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/), из такой заливки картинку извлекать нечего. Пример ниже работает с объектами [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) и сохраняет каждое изображение как PNG через [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) и его метод `getImage()`.

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

## **Извлечение изображений предварительного просмотра из рамок OLE‑объектов**

[OleObjectFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/oleobjectframe/) может иметь заменяющую картинку, которую PowerPoint использует как предварительный просмотр объекта на слайде. Это изображение доступно через `getSubstitutePictureFormat()->getPicture()->getImage()`. Извлекая эту картинку, вы получаете лишь изображение‑превью, а не содержимое внедрённого OLE‑пакета.

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

## **Извлечение изображений предварительного просмотра из видеокадров**

[VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) также может хранить изображение‑превью в `getPictureFormat()->getPicture()->getImage()`. Это постер или миниатюра, показываемая на слайде, а не кадр, декодированный из видеопотока.

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

## **Извлечение изображений предварительного просмотра из аудиокадров**

[AudioFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/audioframe/) может хранить миниатюру в `getPictureFormat()->getPicture()->getImage()`. Это изображение, отображаемое для аудио‑объекта на слайде.

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

## **Извлечение изображений из объектов Zoom**

[ZoomFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/zoomframe/) и [SectionZoomFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sectionzoomframe/) могут использовать специальные изображения. Читайте `getZoomImage()` из зум‑рамки.

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

## **Извлечение изображений из рамок Summary Zoom**

[SummaryZoomFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/summaryzoomframe/) также является фигурой. Ее элементы‑разделы могут использовать пользовательские изображения, доступные через метод `getZoomImage()` каждого раздела Summary Zoom.

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

## **Извлечение изображений из фигур таблиц**

[Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/table/) — это фигура. Изображения в таблице обычно хранятся как заливка картинкой ячеек таблицы.

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

## **Извлечение изображений из фигур диаграмм**

[Chart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/) — это фигура. Пример ниже извлекает изображение из заливки области диаграммы.

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

## **Извлечение изображений из фигур SmartArt**

[SmartArt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartart/) — это фигура. В зависимости от макета SmartArt изображения могут храниться в заливках маркеров узлов или в форматах заливки фигур узлов.

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

## **Включение изображений внутри сгруппированных фигур**

Сгруппированные фигуры содержат собственные коллекции фигур. Общий вспомогательный метод `enumerateShapes` имеет параметр `includeGroupedShapes`. Установите его в `true`, когда необходимо исследовать фигуры внутри объектов [GroupShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/groupshape/). Пример ниже извлекает изображения из рамок картинок, фигур с заливкой картинкой, превью OLE‑объектов, миниатюр видеокадров и аудиокадров. Чтобы также включить изображения из таблиц, диаграмм, SmartArt и Summary Zoom, переиспользуйте специализированную логику извлечения из соответствующих разделов, сохраняя тот же рекурсивный обход фигур.

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

## **Особые случаи и практические замечания**

- **Дублирующие изображения:** Одни и те же изображения могут использовать несколько фигур или разные изображения с одинаковыми байтами. Хешируйте данные [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) из `getBinaryData()` перед записью файлов, если хотите иметь один файл на уникальное изображение.
- **Исходные данные vs преобразованный вывод:** Сохранение данных [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) через `getBinaryData()` сохраняет встроенный JPEG, PNG, GIF, SVG, EMF или WMF. Сохранение изображения, полученного через `getImage()`, удобно, когда нужен единый формат вывода.
- **Неподдерживаемые типы заливок:** Сплошные, градиентные, шаблонные и беззаливные фигуры не содержат картинку‑заливку. Проверяйте [FillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) перед вызовом `getPictureFillFormat()`.
- **Сгруппированные фигуры:** Коллекция фигур верхнего уровня слайда не развёртывает группы. Рекурсивно проверяйте содержимое [GroupShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/groupshape/) через `getShapes()`, когда важен вложенный контент.
- **Превью OLE‑объектов:** [OleObjectFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/oleobjectframe/) может предоставлять изображение‑превью через `getSubstitutePictureFormat()`, но это лишь превью для слайда, а не встроенный файл OLE‑объекта.
- **Миниатюры видеокадров:** [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) может предоставлять превью через `getPictureFormat()`, но это лишь постер, отображаемый на слайде, а не кадр из видеопотока.
- **Миниатюры аудиокадров:** [AudioFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/audioframe/) может предоставлять иконку или миниатюру через `getPictureFormat()`; это не встроенные аудиоданные.
- **Изображения зум‑объектов:** Фигуры зум‑слайда, секции и Summary Zoom могут использовать пользовательские объекты [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) через `getZoomImage()`.
- **Вложенные модели фигур:** Объекты таблиц, диаграмм и SmartArt реализуют [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/), но их изображения часто хранятся во вложенных объектах форматирования ячеек таблицы, элементов диаграммы или узлов SmartArt.
- **Обрезанные или преобразованные картинки:** Доступ к [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) даёт вам хранимый ресурс изображения. Он не учитывает обрезку, прозрачность, перекрасску, поворот или другие визуальные эффекты, применённые фигурой.

## **FAQ**

**Можно ли извлечь оригинальное изображение без обрезки, эффектов и трансформаций фигуры?**

Да. Обратитесь к объекту [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) и запишите данные из `getBinaryData()` на диск. Это сохраняет оригинальное закодированное изображение, хранящееся в презентации, а не способ его отображения на слайде.

**Можно ли экспортировать каждое извлечённое изображение в формате PNG?**

Да. Используйте [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) и его метод `getImage()`, затем вызовите `save()` с параметром [ImageFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imageformat/). Это преобразует вывод и может не сохранять оригинальный тип файла или векторные данные.

**Как избежать многократного сохранения одного и того же изображения?**

Вычислите хеш данных [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) из `getBinaryData()` и храните хеши в наборе. Если новое изображение имеет уже существующий хеш, пропустите его или запишите дополнительную ссылку на уже созданный файл.

**Почему некоторые фигуры не дают изображения?**

Рамки картинок, фигуры с заливкой картинкой, OLE‑рамки, медиа‑рамки, зум‑рамки, таблицы, диаграммы и SmartArt могут ссылаться на изображения. Некоторые типы фигур раскрывают изображения через вложенные объекты форматирования, поэтому простая проверка `getPictureFormat()` или `getFillFormat()` может быть недостаточной.

**Можно ли извлечь миниатюру, показываемую для видеокадра?**

Да. Используйте [VideoFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoframe/) и читайте `getPictureFormat()->getPicture()->getImage()`. Это извлекает постер, хранящийся вместе с видеокадром, а не кадр, сгенерированный из видеофайла.

**Как определить, какие фигуры используют конкретное изображение из коллекции изображений презентации?**

Aspose.Slides не хранит обратные ссылки от [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) к фигурам. Постройте отображение во время обхода: каждый раз, когда находите ссылку на изображение, фиксируйте номер слайда, путь к фигуре и хеш изображения или элемент коллекции.

**Можно ли извлечь изображения, встроенные в OLE‑объекты, например вложенные документы?**

Вы можете извлечь превью OLE‑объекта из [OleObjectFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/oleobjectframe/). Однако это превью не является самим вложенным документом. Чтобы извлечь изображения из вложенного файла, нужно экспортировать данные OLE и проанализировать их специализированными инструментами для соответствующего типа файла.