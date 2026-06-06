---
title: 在 PHP 中从演示文稿形状提取图像
linktitle: 形状中的图像
type: docs
weight: 100
url: /zh/php-java/extracting-images-from-presentation-shapes/
keywords:
- 提取图像
- 检索图像
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，从 PowerPoint 和 OpenDocument 演示文稿的形状中提取图像 - 快速、友好的代码解决方案。"
---
## **概述**

演示文稿中的图像可以以多种形状类型出现：普通图片框、应用于形状的图片填充、OLE 对象预览图像、视频或音频帧缩略图、缩放图像，或嵌套在表格、图表和 SmartArt 形状内的图像。Aspose.Slides 将这些图像存储在演示文稿的图像集合中，可通过 [ImageCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/) 和 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 对象访问。

如果您只需要导出演示文稿中嵌入的每个图像资源，只需遍历 `presentation->getImages()`。本文侧重于另一项任务：遍历形状以查找幻灯片中使用图像的位置，从而保存的文件能够保留有用的上下文信息，如幻灯片编号、形状位置和来源类型（图片框、填充图像、媒体预览、OLE 预览或缩放图像）。

{{% alert title="Tip" color="primary" %}}
使用 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 及其 `getBinaryData()` 方法来保留原始编码的图像数据和文件类型。当需要将输出统一为特定格式（如 PNG）时，请使用 `getImage()`。
{{% /alert %}}

## **共享辅助方法**

下面的辅助方法可以让示例保持简短。`saveOriginalImage` 将写入原始嵌入的字节，根据 MIME 类型选择安全的扩展名，并通过 SHA-256 哈希跳过重复的图像二进制数据。

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

## **从图片框提取图像**

此方法适用于作为独立对象插入的图片。[PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 将图片存储在 `getPictureFormat()->getPicture()->getImage()` 中，返回一个 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 对象。

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

## **从填充图片的形状提取图像**

形状可以使用图片作为填充。首先检查形状的填充类型：如果不是 [FillType.Picture](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filltype/)，则该填充中没有可提取的图片。下面的示例处理 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/) 对象，并通过 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 及其 `getImage()` 方法将每个图像保存为 PNG。

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

## **从 OLE 对象框提取预览图像**

[OleObjectFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/oleobjectframe/) 可以拥有 PowerPoint 用作对象在幻灯片上预览的替代图片。该图片可通过 `getSubstitutePictureFormat()->getPicture()->getImage()` 获取。提取此图片得到的是预览图像，而非嵌入的 OLE 包内容。

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

## **从视频帧提取预览图像**

[VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 也可以在 `getPictureFormat()->getPicture()->getImage()` 中存储预览图像。这是幻灯片上显示的海报或缩略图，而非从视频流解码的帧。

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

## **从音频帧提取预览图像**

[AudioFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/audioframe/) 可以在 `getPictureFormat()->getPicture()->getImage()` 中存储缩略图。这是幻灯片上音频对象显示的图像。

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

## **从缩放对象提取图像**

[ZoomFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/zoomframe/) 和 [SectionZoomFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sectionzoomframe/) 形状可以使用自定义图像。请从缩放框读取 `getZoomImage()`。

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

## **从汇总缩放框提取图像**

[SummaryZoomFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/summaryzoomframe/) 同样是一个形状。其各节项目可以使用自定义图像，可通过每个汇总缩放节的 `getZoomImage()` 方法访问。

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

## **从表格形状提取图像**

[Table](https://reference.aspose.com/slides/zh/php-java/aspose.slides/table/) 是一种形状。表格中的图像通常以图片填充的形式存储在单元格中。

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

## **从图表形状提取图像**

[Chart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/) 是一种形状。下面的示例从图表区域的图片填充中提取图像。

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

## **从 SmartArt 形状提取图像**

[SmartArt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartart/) 对象是一种形状。根据 SmartArt 布局，图像可能存储在节点项目符号填充中或节点形状的填充格式中。

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

## **在组合形状中包含图像**

组合形状拥有自己的形状集合。共享的 `enumerateShapes` 辅助方法提供 `includeGroupedShapes` 选项。当需要检查 [GroupShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/groupshape/) 对象内部的形状时，将其设为 `true`。下面的示例从图片框、填充图片的形状、OLE 对象预览、视频帧缩略图和音频帧缩略图中提取图像。若要同时包括表格、图表、SmartArt 和汇总缩放图像，请复用前面章节的专用提取逻辑，并保持相同的递归形状遍历。

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

## **边缘情况和实用说明**

- **重复图像：** 多个形状可能引用同一图像，或引用字节完全相同的不同图像。如果希望每个唯一图像只输出一次文件，请在写入文件前对 `getBinaryData()` 的 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 数据进行哈希。
- **原始数据与转换后输出：** 从 `getBinaryData()` 保存 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 数据可保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 数据。使用 `getImage()` 返回的图像进行保存，则可将输出统一为一致的格式。
- **不支持的填充类型：** 实心、渐变、图案和无填充的形状不包含图片填充。在读取 `getPictureFillFormat()` 之前，请检查 [FillType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filltype/)。
- **组合形状：** 顶层幻灯片形状集合不会将组展平。需要时，请递归检查通过 `getShapes()` 获得的 [GroupShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/groupshape/) 内容。
- **OLE 对象预览：** [OleObjectFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/oleobjectframe/) 可能通过 `getSubstitutePictureFormat()` 暴露预览图像，但该图像仅是幻灯片预览，而非 OLE 对象内部的嵌入文件。
- **视频帧缩略图：** [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 可能通过 `getPictureFormat()` 暴露预览图像，但该图像仅是幻灯片上显示的海报图，而非从视频流中提取的帧。
- **音频帧缩略图：** [AudioFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/audioframe/) 可能通过 `getPictureFormat()` 暴露图标或缩略图；这并不是嵌入的音频数据。
- **缩放图像：** 幻灯片缩放、节缩放和汇总缩放形状可能通过 `getZoomImage()` 使用自定义 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 对象。
- **嵌套形状模型：** 表格、图表和 SmartArt 对象实现了 [Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/)，但它们的图像通常存储在嵌套的表格单元格、图表元素或 SmartArt 节点的格式对象中。
- **裁剪或变换的图片：** 访问 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 可获取存储的图像资源。它不包含形状应用的裁剪、透明度、重新着色、旋转或其他视觉效果的渲染。

## **常见问题**

**我能提取原始图像而不受裁剪、效果或形状变换影响吗？**

是的。访问 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 对象并将 `getBinaryData()` 的数据写入磁盘，即可保留演示文稿中存储的原始编码图像，而不是图像在幻灯片上的渲染方式。

**我能将所有提取的图像导出为 PNG 吗？**

是的。使用 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 及其 `getImage()` 方法，然后使用 [ImageFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imageformat/) 调用 `save()`，即可将输出转换为 PNG。这样可能不会保留原始文件类型或矢量数据。

**如何避免多次保存相同的图像？**

使用 `getBinaryData()` 的 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 数据的哈希，并将哈希值存入集合中。如果新图像的哈希已存在，则跳过或记录对已有输出文件的另一个引用。

**为什么某些形状没有生成图像？**

图片框、填充图片的形状、OLE 对象框、媒体框、缩放框、表格、图表和 SmartArt 对象都可能引用图像。某些形状的图像通过嵌套的格式对象暴露，因此单纯检查 `getPictureFormat()` 或形状的 `getFillFormat()` 并不总是足够。

**我能提取视频帧显示的缩略图吗？**

是的。使用 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 并读取 `getPictureFormat()->getPicture()->getImage()`，即可提取随视频帧存储的海报图像，而不是从视频文件生成的帧。

**如何确定演示文稿图像集合中的特定图像被哪些形状使用？**

Aspose.Slides 并未存储从 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 到形状的反向链接。您需要在遍历过程中构建映射：每当找到图像引用时，记录幻灯片编号、形状路径以及图像哈希或集合项。

**我能提取嵌入在 OLE 对象内部的图像，例如附加的文档吗？**

您可以从 [OleObjectFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/oleobjectframe/) 提取 OLE 对象的幻灯片预览。但该预览并非嵌入的文档本身。若要从嵌入的文件内部提取图像，需要先提取 OLE 数据并使用相应文件类型的工具进行检查。