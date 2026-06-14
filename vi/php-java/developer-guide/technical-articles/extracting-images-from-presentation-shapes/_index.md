---
title: Trích xuất hình ảnh từ các hình dạng trong bản thuyết trình bằng PHP
linktitle: Hình ảnh từ Hình dạng
type: docs
weight: 100
url: /vi/php-java/extracting-images-from-presentation-shapes/
keywords:
- trích xuất hình ảnh
- lấy hình ảnh
- PowerPoint
- OpenDocument
- bản thuyết trình
- PHP
- Aspose.Slides
description: "Trích xuất hình ảnh từ các hình dạng trong bản thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java - giải pháp nhanh, thân thiện với mã."
---
## **Tổng quan**

Các hình ảnh trong một bản thuyết trình có thể xuất hiện dưới một số loại hình dạng: như khung hình ảnh thường, như hình ảnh được dùng làm nền cho các hình dạng, như hình ảnh xem trước đối tượng OLE, như hình thu nhỏ khung video hoặc âm thanh, như hình ảnh thu phóng, hoặc như các hình ảnh lồng nhau trong các hình dạng bảng, biểu đồ và SmartArt. Aspose.Slides lưu trữ các hình ảnh này trong bộ sưu tập hình ảnh của bản thuyết trình, được truy cập thông qua các đối tượng [ImageCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/) và [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/).

Nếu bạn chỉ cần xuất mọi tài nguyên hình ảnh được nhúng trong bản thuyết trình, hãy lặp qua `presentation->getImages()`. Bài viết này tập trung vào một nhiệm vụ khác: duyệt các hình dạng để tìm nơi hình ảnh được sử dụng trên các slide, để các tệp đã lưu có thể giữ ngữ cảnh hữu ích như số slide, vị trí hình dạng và loại nguồn (khung hình ảnh, hình nền, xem trước đa phương tiện, xem trước OLE hoặc hình ảnh thu phóng).

{{% alert title="Tip" color="primary" %}}
Sử dụng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) và phương thức `getBinaryData()` của nó để bảo tồn dữ liệu hình ảnh được mã hoá ban đầu và kiểu tệp. Sử dụng `getImage()` khi bạn muốn chuẩn hoá đầu ra sang một định dạng cụ thể như PNG.
{{% /alert %}}

## **Phương thức trợ giúp dùng chung**

Các phương thức trợ giúp dưới đây giúp các ví dụ ngắn gọn. `saveOriginalImage` ghi các byte nhúng gốc, chọn phần mở rộng an toàn từ MIME type và bỏ qua các nhị phân hình ảnh trùng lặp bằng hàm băm SHA-256.

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

## **Trích xuất hình ảnh từ Khung Hình Ảnh**

Sử dụng cách tiếp cận này cho các ảnh được chèn dưới dạng đối tượng độc lập. Một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) lưu trữ ảnh của nó trong `getPictureFormat()->getPicture()->getImage()`, phương thức này trả về một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/).

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

## **Trích xuất hình ảnh từ Các Hình Dạng Được Điền Hình Ảnh**

Các hình dạng có thể sử dụng một ảnh làm nền. Đầu tiên kiểm tra kiểu nền của hình dạng: nếu không phải là [FillType.Picture](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/), thì không có ảnh nào để trích xuất từ nền đó. Ví dụ dưới đây xử lý các đối tượng [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) và lưu mỗi ảnh dưới dạng PNG thông qua [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) và phương thức `getImage()` của nó.

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

## **Trích xuất hình ảnh xem trước từ Khung Đối Tượng OLE**

Một [OleObjectFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleobjectframe/) có thể có một ảnh thay thế mà PowerPoint dùng làm xem trước đối tượng trên slide. Ảnh này có sẵn qua `getSubstitutePictureFormat()->getPicture()->getImage()`. Trích xuất ảnh này sẽ cho bạn hình ảnh xem trước, không phải nội dung gói OLE được nhúng.

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

## **Trích xuất hình ảnh xem trước từ Khung Video**

Một [VideoFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/) cũng có thể lưu trữ một ảnh xem trước trong `getPictureFormat()->getPicture()->getImage()`. Đây là poster hoặc thumbnail hiển thị trên slide, không phải một khung được giải mã từ luồng video.

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

## **Trích xuất hình ảnh xem trước từ Khung Audio**

Một [AudioFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/) có thể lưu trữ một thumbnail trong `getPictureFormat()->getPicture()->getImage()`. Đây là ảnh hiển thị cho đối tượng âm thanh trên slide.

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

## **Trích xuất hình ảnh từ Đối Tượng Zoom**

Các hình dạng [ZoomFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zoomframe/) và [SectionZoomFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sectionzoomframe/) có thể sử dụng ảnh tùy chỉnh. Đọc `getZoomImage()` từ khung zoom.

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

## **Trích xuất hình ảnh từ Khung Zoom Tổng Hợp**

Một [SummaryZoomFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/summaryzoomframe/) cũng là một hình dạng. Các mục phần của nó có thể sử dụng ảnh tùy chỉnh, được truy cập thông qua phương thức `getZoomImage()` của từng phần zoom tổng hợp.

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

## **Trích xuất hình ảnh từ Hình Dạng Bảng**

Một [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/table/) là một hình dạng. Các hình ảnh trong bảng thường được lưu trữ dưới dạng nền ảnh trong các ô bảng.

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

## **Trích xuất hình ảnh từ Hình Dạng Biểu Đồ**

Một [Chart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/) là một hình dạng. Ví dụ dưới đây trích xuất ảnh từ nền ảnh của vùng biểu đồ.

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

## **Trích xuất hình ảnh từ Hình Dạng SmartArt**

Một đối tượng [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) là một hình dạng. Tùy thuộc vào bố cục SmartArt, hình ảnh có thể được lưu trong nền các nút dạng bullet hoặc trong định dạng nền của các hình dạng nút.

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

## **Bao gồm hình ảnh trong các Hình Dạng Nhóm**

Các hình dạng nhóm chứa bộ sưu tập hình dạng riêng của chúng. Trợ giúp chung `enumerateShapes` có tùy chọn `includeGroupedShapes`. Đặt thành `true` khi bạn muốn kiểm tra các hình dạng bên trong các đối tượng [GroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/groupshape/). Ví dụ dưới đây trích xuất hình ảnh từ khung hình ảnh, các hình dạng được điền ảnh, xem trước OLE, thumbnail khung video và thumbnail khung audio. Để bao gồm cả hình ảnh bảng, biểu đồ, SmartArt và zoom tổng hợp, hãy tái sử dụng logic trích xuất chuyên biệt từ các phần trước trong khi giữ nguyên quá trình duyệt hình dạng đệ quy.

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

## **Trường Hợp Cạnh và Ghi Chú Thực Tiễn**

- **Hình ảnh trùng lặp:** Nhiều hình dạng có thể tham chiếu cùng một hình ảnh hoặc các hình ảnh riêng biệt có byte giống hệt nhau. Băm dữ liệu [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) từ `getBinaryData()` trước khi ghi tệp nếu bạn muốn một tệp đầu ra cho mỗi hình ảnh duy nhất.
- **Dữ liệu gốc vs. đầu ra đã chuyển đổi:** Lưu dữ liệu [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) từ `getBinaryData()` giữ nguyên dữ liệu JPEG, PNG, GIF, SVG, EMF hoặc WMF được nhúng. Lưu hình ảnh trả về bởi `getImage()` hữu ích khi bạn muốn một định dạng đầu ra nhất quán.
- **Kiểu nền không hỗ trợ:** Các hình dạng có nền đặc, gradient, mẫu hoặc không có nền không chứa ảnh nền. Kiểm tra [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) trước khi đọc `getPictureFillFormat()`.
- **Hình dạng nhóm:** Bộ sưu tập hình dạng cấp slide không làm phẳng các nhóm. Kiểm tra đệ quy nội dung [GroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/groupshape/) qua `getShapes()` khi nội dung nhóm quan trọng.
- **Xem trước đối tượng OLE:** Một [OleObjectFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleobjectframe/) có thể cung cấp ảnh xem trước qua `getSubstitutePictureFormat()`, nhưng ảnh này chỉ là xem trước trên slide, không phải tệp nhúng bên trong đối tượng OLE.
- **Thumbnail khung video:** Một [VideoFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/) có thể cung cấp ảnh xem trước qua `getPictureFormat()`, nhưng ảnh này chỉ là poster hiển thị trên slide, không được trích xuất từ luồng video.
- **Thumbnail khung audio:** Một [AudioFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/) có thể cung cấp biểu tượng hoặc thumbnail qua `getPictureFormat()`; nó không phải là dữ liệu âm thanh được nhúng.
- **Ảnh zoom:** Các hình dạng zoom slide, section zoom và summary zoom có thể sử dụng các đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) tùy chỉnh qua `getZoomImage()`.
- **Mô hình hình dạng lồng nhau:** Các đối tượng bảng, biểu đồ và SmartArt thực thi [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/), nhưng hình ảnh của chúng thường được lưu trong các đối tượng định dạng ô bảng, phần tử biểu đồ hoặc nút SmartArt.
- **Ảnh đã cắt hoặc biến đổi:** Truy cập [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) sẽ cho bạn tài nguyên ảnh được lưu. Nó không áp dụng việc cắt, trong suốt, đổi màu, xoay hoặc các hiệu ứng hình ảnh khác mà hình dạng đã thực hiện.

## **Câu Hỏi Thường Gặp**

**Tôi có thể trích xuất ảnh gốc mà không cắt, hiệu ứng hay biến đổi hình dạng không?**

Có. Truy cập đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) và ghi dữ liệu từ `getBinaryData()` ra đĩa. Điều này bảo tồn ảnh được mã hoá gốc trong bản thuyết trình, không phải cách ảnh được hiển thị trên slide.

**Tôi có thể xuất mọi ảnh đã trích xuất dưới dạng PNG không?**

Có. Sử dụng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) và phương thức `getImage()` của nó, sau đó gọi `save()` với [ImageFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imageformat/). Điều này sẽ chuyển đổi đầu ra và có thể không giữ nguyên kiểu tệp gốc hoặc dữ liệu vector.

**Làm thế nào để tránh lưu cùng một ảnh nhiều lần?**

Sử dụng hàm băm dữ liệu [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) từ `getBinaryData()` và lưu các giá trị băm trong một tập hợp. Nếu một ảnh mới có băm đã tồn tại, bỏ qua nó hoặc ghi lại tham chiếu khác tới tệp đầu ra hiện có.

**Tại sao một số hình dạng không tạo ra ảnh?**

Khung hình ảnh, các hình dạng được điền ảnh, khung OLE, khung đa phương tiện, khung zoom, bảng, biểu đồ và đối tượng SmartArt có thể tham chiếu ảnh. Một số kiểu hình dạng cung cấp ảnh qua các đối tượng định dạng lồng nhau, vì vậy việc kiểm tra đơn giản `getPictureFormat()` hoặc `getFillFormat()` của hình dạng không luôn đủ.

**Tôi có thể trích xuất thumbnail hiển thị cho khung video không?**

Có. Sử dụng [VideoFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/) và đọc `getPictureFormat()->getPicture()->getImage()`. Điều này trích xuất ảnh poster được lưu cùng với khung video, không phải một khung được tạo ra từ tệp video.

**Làm sao tôi biết hình dạng nào sử dụng một ảnh cụ thể từ bộ sưu tập ảnh của bản thuyết trình?**

Aspose.Slides không lưu liên kết ngược từ [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) tới các hình dạng. Hãy xây dựng một bản đồ trong quá trình duyệt: mỗi khi bạn tìm thấy một tham chiếu ảnh, ghi lại số slide, đường dẫn hình dạng và băm ảnh hoặc mục trong bộ sưu tập.

**Tôi có thể trích xuất ảnh được nhúng trong OLE, chẳng hạn như tài liệu đính kèm, không?**

Bạn có thể trích xuất ảnh xem trước slide của đối tượng OLE từ [OleObjectFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleobjectframe/). Tuy nhiên, ảnh xem trước này không phải là tài liệu được nhúng. Để trích xuất ảnh từ bên trong tệp nhúng, hãy trích xuất dữ liệu OLE và kiểm tra nó bằng các công cụ phù hợp với loại tệp đó.