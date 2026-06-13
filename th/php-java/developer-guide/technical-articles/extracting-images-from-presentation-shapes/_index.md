---
title: สกัดภาพจากรูปร่างงานนำเสนอใน PHP
linktitle: ภาพจากรูปร่าง
type: docs
weight: 100
url: /th/php-java/extracting-images-from-presentation-shapes/
keywords:
- แยกภาพ
- ดึงภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สกัดภาพจากรูปร่างในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java - วิธีแก้ไขที่รวดเร็วและเป็นมิตรต่อโค้ด"
---
## **ภาพรวม**

ภาพในงานนำเสนอสามารถปรากฏในหลายประเภทของรูปร่าง: เป็นกรอบรูปภาพธรรมดา, เป็นการเติมรูปภาพที่ใช้กับรูปร่าง, เป็นภาพตัวอย่างของอ็อบเจ็กต์ OLE, เป็นภาพย่อของเฟรมวิดีโอหรือเสียง, เป็นภาพซูม, หรือเป็นภาพที่ซ้อนอยู่ภายในตาราง, แผนภูมิ, และรูปร่าง SmartArt. Aspose.Slides เก็บภาพเหล่านี้ในคอลเลกชันภาพของงานนำเสนอ, ซึ่งเปิดให้ใช้งานผ่านอ็อบเจ็กต์ [ImageCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) และ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) 

หากคุณต้องการส่งออกทุกทรัพยากรภาพที่ฝังอยู่ในงานนำเสนอ, ให้วนลูปผ่าน `presentation->getImages()` . บทความนี้เน้นงานที่แตกต่าง: การตรวจสอบรูปร่างเพื่อค้นหาตำแหน่งที่ใช้ภาพบนสไลด์, เพื่อให้ไฟล์ที่บันทึกได้เก็บบริบทที่มีประโยชน์เช่นหมายเลขสไลด์, ตำแหน่งรูปร่าง, และประเภทแหล่งที่มา (กรอบรูปภาพ, การเติมรูป, ตัวอย่างสื่อ, ตัวอย่าง OLE, หรือภาพซูม)

{{% alert title="Tip" color="primary" %}}
ใช้ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) และเมธอด `getBinaryData()` เพื่อรักษาข้อมูลภาพที่เข้ารหัสต้นฉบับและประเภทไฟล์ไว้. ใช้ `getImage()` เมื่อคุณต้องการทำให้รูปผลลัพธ์เป็นรูปแบบเฉพาะเช่น PNG.
{{% /alert %}}

## **เมธอดช่วยเหลือที่ใช้ร่วมกัน**

เมธอดช่วยเหลือด้านล่างทำให้ตัวอย่างสั้นลง. `saveOriginalImage` จะเขียนไบท์ของภาพที่ฝังไว้เดิม, เลือกนามสกุลที่ปลอดภัยจาก MIME type, และข้ามไบนารีภาพที่ซ้ำกันโดยใช้แฮช SHA-256

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

## **สกัดภาพจากกรอบรูปภาพ**

ใช้วิธีนี้สำหรับภาพที่แทรกเป็นอ็อบเจ็กต์แยกส่วน. [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) เก็บรูปภาพของมันใน `getPictureFormat()->getPicture()->getImage()`, ซึ่งจะคืนค่าอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/)

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

## **สกัดภาพจากรูปร่างที่เติมด้วยรูปภาพ**

รูปร่างสามารถใช้รูปภาพเป็นการเติมได้. ตรวจสอบประเภทการเติมของรูปร่างก่อน: หากไม่ใช่ [FillType.Picture](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/), จะไม่มีรูปภาพให้สกัดจากการเติมนั้น. ตัวอย่างด้านล่างจัดการกับอ็อบเจ็กต์ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) และบันทึกรูปภาพแต่ละอันเป็น PNG ผ่าน [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) และเมธอด `getImage()`

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

## **สกัดภาพตัวอย่างจากกรอบอ็อบเจ็กต์ OLE**

[OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) สามารถมีรูปภาพทดแทนที่ PowerPoint ใช้เป็นตัวอย่างของอ็อบเจ็กต์บนสไลด์. ภาพนี้สามารถเข้าถึงได้ผ่าน `getSubstitutePictureFormat()->getPicture()->getImage()`. การสกัดรูปภาพนี้จะให้ภาพตัวอย่าง, ไม่ใช่เนื้อหาแพคเกจ OLE ที่ฝังอยู่

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

## **สกัดภาพตัวอย่างจากกรอบวิดีโอ**

[VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) สามารถเก็บภาพตัวอย่างใน `getPictureFormat()->getPicture()->getImage()`. นี่คือโปสเตอร์หรือรูปย่อที่แสดงบนสไลด์, ไม่ใช่กรอบที่ถอดรหัสจากสตรีมวิดีโอ

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

## **สกัดภาพตัวอย่างจากกรอบเสียง**

[AudioFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/) สามารถเก็บรูปย่อใน `getPictureFormat()->getPicture()->getImage()`. นี่คือภาพที่แสดงสำหรับอ็อบเจ็กต์เสียงบนสไลด์

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

## **สกัดภาพจากอ็อบเจ็กต์ Zoom**

[ZoomFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/zoomframe/) และ [SectionZoomFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/sectionzoomframe/) สามารถใช้ภาพที่กำหนดเอง. อ่าน `getZoomImage()` จากกรอบซูม

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

## **สกัดภาพจาก Summary Zoom Frames**

[SummaryZoomFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/summaryzoomframe/) ก็เป็นรูปร่างเช่นกัน. รายการส่วนของมันสามารถใช้ภาพที่กำหนดเองได้, ซึ่งเปิดให้เข้าถึงผ่านเมธอด `getZoomImage()` ของแต่ละส่วนสรุปซูม

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

## **สกัดภาพจากรูปร่างตาราง**

[Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/) เป็นรูปร่าง. ภาพในตารางมักจะถูกเก็บเป็นการเติมรูปภาพในเซลล์ของตาราง

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

## **สกัดภาพจากรูปร่างแผนภูมิ**

[Chart](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/) เป็นรูปร่าง. ตัวอย่างด้านล่างสกัดภาพจากการเติมรูปภาพของพื้นที่แผนภูมิ

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

## **สกัดภาพจากรูปร่าง SmartArt**

[SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) เป็นอ็อบเจ็กต์รูปร่าง. ขึ้นอยู่กับเลย์เอาต์ของ SmartArt, ภาพอาจถูกเก็บในการเติมสัญลักษณ์หัวข้อของโหนดหรือในฟอร์แมตการเติมของรูปร่างโหนด

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

## **รวมภาพที่อยู่ภายในรูปร่างที่จัดกลุ่ม**

รูปร่างที่จัดกลุ่มมีคอลเลกชันรูปร่างของตนเอง. เมธอดช่วยเหลือ `enumerateShapes` มีตัวเลือก `includeGroupedShapes`. ตั้งค่าเป็น `true` เมื่อต้องการตรวจสอบรูปร่างภายในอ็อบเจ็กต์ [GroupShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/groupshape/) ตัวอย่างด้านล่างสกัดภาพจากกรอบรูปภาพ, รูปร่างที่เติมด้วยรูปภาพ, ตัวอย่าง OLE, ภาพย่อของกรอบวิดีโอ, และภาพย่อของกรอบเสียง. เพื่อรวมภาพจากตาราง, แผนภูมิ, SmartArt, และสรุปซูมด้วย, ให้ใช้ตรรกะการสกัดเฉพาะจากส่วนก่อนหน้าโดยคงการเดินทางรูปร่างแบบเรียกซ้ำเดิม

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

## **กรณีขอบและหมายเหตุเชิงปฏิบัติ**

- **ภาพซ้ำ:** รูปร่างหลายรูปอาจอ้างอิงภาพเดียวกันหรือภาพแยกต่างหากที่มีไบท์เหมือนกัน. แฮชข้อมูล [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) จาก `getBinaryData()` ก่อนบันทึกไฟล์หากต้องการไฟล์ผลลัพธ์หนึ่งไฟล์ต่อภาพที่ไม่ซ้ำกัน
- **ข้อมูลต้นฉบับ vs. ผลลัพธ์แปลง:** การบันทึกข้อมูล [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) จาก `getBinaryData()` จะคงการเข้ารหัส JPEG, PNG, GIF, SVG, EMF, หรือ WMF ที่ฝังอยู่. การบันทึกภาพที่คืนจาก `getImage()` มีประโยชน์เมื่อคุณต้องการรูปแบบผลลัพธ์เดียวกัน
- **ประเภทการเติมที่ไม่สนับสนุน:** รูปร่างที่ไม่มีการเติม, การเติมแบบสีเดียว, ไล่ระดับสี, หรือลวดลาย จะไม่มีรูปภาพเติม. ตรวจสอบ [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ก่อนอ่าน `getPictureFillFormat()`
- **รูปร่างที่จัดกลุ่ม:** คอลเลกชันรูปร่างระดับบนของสไลด์ไม่ได้ทำให้กลุ่มแบน. ตรวจสอบเนื้อหา [GroupShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/groupshape/) อย่างเรียกซ้ำผ่าน `getShapes()` เมื่อเนื้อหาที่จัดกลุ่มสำคัญ
- **ตัวอย่าง OLE:** [OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `getSubstitutePictureFormat()`, แต่ภาพนั้นเป็นเพียงตัวอย่างบนสไลด์ ไม่ใช่ไฟล์ที่ฝังภายในอ็อบเจ็กต์ OLE
- **ภาพย่อของกรอบวิดีโอ:** [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `getPictureFormat()`, แต่ภาพนั้นเป็นเพียงโปสเตอร์ที่แสดงบนสไลด์ ไม่ได้สกัดจากสตรีมวิดีโอ
- **ภาพย่อของกรอบเสียง:** [AudioFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/audioframe/) อาจเปิดเผยไอคอนหรือภาพย่อผ่าน `getPictureFormat()`; ไม่ใช่ข้อมูลเสียงที่ฝังอยู่
- **ภาพซูม:** รูปร่างซูมแบบสไลด์, ส่วน, และสรุปซูมอาจใช้อ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) ที่กำหนดเองผ่าน `getZoomImage()`
- **โมเดลรูปร่างซ้อนกัน:** ตาราง, แผนภูมิ, และอ็อบเจ็กต์ SmartArt ใช้ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) แต่ภาพของพวกมันมักเก็บในวัตถุฟอร์แมตของเซลล์ตาราง, องค์ประกอบแผนภูมิ, หรือโหนด SmartArt
- **รูปภาพที่ตัดหรือแปลง:** การเข้าถึง [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) จะให้ทรัพยากรรูปภาพที่เก็บไว้. มันไม่แสดงการตัด, ความโปร่งใส, การเปลี่ยนสี, การหมุน, หรือเอฟเฟกต์ภาพอื่น ๆ ที่ถูกนำไปใช้โดยรูปร่าง

## **FAQ**

**ฉันสามารถสกัดภาพต้นฉบับโดยไม่ต้องครอป, เอฟเฟกต์ หรือการแปลงรูปร่างได้หรือไม่?**

ใช่. เข้าถึงอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) แล้วเขียนข้อมูลจาก `getBinaryData()` ไปยังดิสก์. วิธีนี้จะคงภาพที่เข้ารหัสต้นฉบับที่เก็บในงานนำเสนอ, ไม่ใช่วิธีการที่ภาพแสดงบนสไลด์

**ฉันสามารถส่งออกภาพที่สกัดทั้งหมดเป็น PNG ได้หรือไม่?**

ใช่. ใช้ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) และเมธอด `getImage()` จากนั้นเรียก `save()` พร้อม [ImageFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/imageformat/). วิธีนี้จะเปลี่ยนรูปเป็น PNG แต่บางครั้งอาจไม่คงประเภทไฟล์ต้นฉบับหรือข้อมูลเวกเตอร์

**ฉันจะหลีกเลี่ยงการบันทึกภาพเดียวกันหลายครั้งได้อย่างไร?**

ใช้แฮชของข้อมูล [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) จาก `getBinaryData()` แล้วเก็บแฮชเหล่านั้นในชุด (set). หากภาพใหม่มีแฮชที่มีอยู่แล้ว, ให้ข้ามหรือบันทึกการอ้างอิงไปยังไฟล์ผลลัพธ์ที่มีอยู่

**ทำไมบางรูปร่างจึงไม่สร้างภาพได้?**

กรอบรูปภาพ, รูปร่างที่เติมด้วยรูป, กรอบอ็อบเจ็กต์ OLE, กรอบสื่อ, กรอบซูม, ตาราง, แผนภูมิ, และอ็อบเจ็กต์ SmartArt สามารถอ้างอิงภาพได้. รูปร่างบางประเภทเปิดเผยภาพผ่านวัตถุฟอร์แมตที่ซ้อนกัน, ดังนั้นการตรวจสอบเพียง `getPictureFormat()` หรือ `getFillFormat()` ของรูปร่างอาจไม่เพียงพอ

**ฉันสามารถสกัดภาพย่อที่แสดงของกรอบวิดีโอได้หรือไม่?**

ใช่. ใช้ [VideoFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoframe/) แล้วอ่าน `getPictureFormat()->getPicture()->getImage()`. วิธีนี้จะสกัดภาพโปสเตอร์ที่เก็บไว้กับกรอบวิดีโอ, ไม่ใช่เฟรมที่สร้างจากไฟล์วิดีโอ

**ฉันจะกำหนดรูปร่างที่ใช้ภาพเฉพาะจากคอลเลกชันภาพของงานนำเสนอได้อย่างไร?**

Aspose.Slides ไม่เก็บลิงก์ย้อนกลับจาก [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) ไปยังรูปร่าง. ให้สร้างแผนที่ระหว่างการเดินทาง: เมื่อใดก็ตามที่พบการอ้างอิงภาพ, ให้บันทึกหมายเลขสไลด์, เส้นทางรูปร่าง, และแฮชหรือรายการจากคอลเลกชัน

**ฉันสามารถสกัดภาพที่ฝังอยู่ภายในอ็อบเจ็กต์ OLE, เช่นเอกสารที่แนบมาด้วยได้หรือไม่?**

คุณสามารถสกัดภาพตัวอย่างของอ็อบเจ็กต์ OLE จาก [OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) ได้, แต่ภาพตัวอย่างนั้นไม่ใช่เอกสารที่ฝังอยู่. หากต้องการสกัดภาพจากไฟล์ที่ฝังอยู่, จำเป็นต้องสกัดข้อมูล OLE แล้วตรวจสอบด้วยเครื่องมือที่เหมาะสมกับประเภทไฟล์นั้น.