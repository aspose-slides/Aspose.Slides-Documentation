---
title: استخراج الصور من أشكال العرض التقديمي في PHP
linktitle: صورة من الشكل
type: docs
weight: 100
url: /ar/php-java/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرجاع صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides للـ PHP عبر Java - حل سريع وملائم للبرمجة."
---
## **Overview**

يمكن أن تظهر الصور في العرض التقديمي بأنواع متعددة من الأشكال: كإطارات صور عادية، أو كملء صور يُطبق على الأشكال، أو كصور معاينة لكائنات OLE، أو كصُغَر إطارات فيديو أو صوت، أو كصور تكبير، أو كصور مدمجة داخل جداول، مخططات، وأشكال SmartArt. تقوم Aspose.Slides بتخزين هذه الصور في مجموعة صور العرض التقديمي، التي تُعرض عبر الكائنين [ImageCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/) و[PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/).

إذا كنت تحتاج فقط إلى تصدير كل الموارد الصورة المدمجة في عرض تقديمي، فقم بالتكرار عبر `presentation->getImages()`. يركز هذا المقال على مهمة مختلفة: استكشاف الأشكال للعثور على الأماكن التي تُستخدم فيها الصور على الشرائح، بحيث يمكن للملفات المحفوظة الاحتفاظ بسياق مفيد مثل رقم الشريحة، موقع الشكل، ونوع المصدر (إطار صورة، صورة ملء، معاينة وسائط، معاينة OLE، أو صورة تكبير).

{{% alert title="Tip" color="primary" %}}
استخدم [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) وطريقة `getBinaryData()` الخاصة به للحفاظ على بيانات الصورة المشفرة الأصلية ونوع الملف. استخدم `getImage()` عندما تريد توحيد الإخراج إلى تنسيق محدد مثل PNG.
{{% /alert %}}

## **Shared Helper Methods**

الطرق المساعدة أدناه تحافظ على اختصار الأمثلة. تقوم `saveOriginalImage` بكتابة البايتات المدمجة الأصلية، وتختار امتدادًا آمنًا من نوع MIME، وتتخطى صور الباينري المتكررة عبر تجزئة SHA-256.

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

## **Extract Images from Picture Frames**

استخدم هذه الطريقة للصور المُدرجة ككائنات مستقلة. تخزن [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) صورتها في `getPictureFormat()->getPicture()->getImage()`، والتي تُعيد كائنًا من نوع [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/).

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

## **Extract Images from Picture-Filled Shapes**

يمكن للأشكال أن تستخدم صورة كملء لها. افحص أولاً نوع ملء الشكل: إذا لم يكن [FillType.Picture](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/)، فلا توجد صورة لاستخراجها من ذلك الملء. المثال أدناه يتعامل مع كائنات [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) ويحفظ كل صورة كـ PNG عبر [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) وطريقة `getImage()` الخاصة به.

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

## **Extract Preview Images from OLE Object Frames**

يمكن أن يحتوي [OleObjectFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/oleobjectframe/) على صورة بديلة يستخدمها PowerPoint كمعاينة للكائن على الشريحة. تتوفر هذه الصورة عبر `getSubstitutePictureFormat()->getPicture()->getImage()`. استخراج هذه الصورة يمنحك صورة المعاينة، وليس محتويات حزمة OLE المدمجة.

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

## **Extract Preview Images from Video Frames**

يمكن أيضًا أن يخزن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) صورة معاينة في `getPictureFormat()->getPicture()->getImage()`. هذه هي الصورة أوالصورة المصغرة المعروضة على الشريحة، وليست إطارًا مُستخرجًا من تدفق الفيديو.

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

## **Extract Preview Images from Audio Frames**

يمكن أن يخزن [AudioFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/) صورة مصغرة في `getPictureFormat()->getPicture()->getImage()`. هذه هي الصورة التي تُظهر كائن الصوت على الشريحة.

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

## **Extract Images from Zoom Objects**

يمكن لأشكال [ZoomFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/zoomframe/) و[SectionZoomFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sectionzoomframe/) أن تستخدم صورًا مخصصة. اقرأ `getZoomImage()` من إطار التكبير.

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

## **Extract Images from Summary Zoom Frames**

يُعد [SummaryZoomFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/summaryzoomframe/) أيضًا شكلًا. يمكن لعناصر القسم الخاصة به أن تستخدم صورًا مخصصة، تُعرض عبر طريقة `getZoomImage()` لكل قسم تكبير ملخص.

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

## **Extract Images from Table Shapes**

يُعد [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/table/) شكلًا. تُخزن الصور في جدول عادةً كملء صور في خلايا الجدول.

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

## **Extract Images from Chart Shapes**

يُعد [Chart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/) شكلًا. المثال أدناه يستخرج صورة من ملء صورة منطقة المخطط.

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

## **Extract Images from SmartArt Shapes**

يُعد كائن [SmartArt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartart/) شكلًا. بناءً على تخطيط SmartArt، قد تُخزن الصور في ملء نقاط الرصاص للعقد أو في تنسيقات ملء أشكال العقد.

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

## **Include Images Inside Grouped Shapes**

تحتوي الأشكال المجمعة على مجموعات أشكال خاصة بها. تحتوي طريقة المساعدة المشتركة `enumerateShapes` على خيار `includeGroupedShapes`. اضبطه على `true` عندما تريد فحص الأشكال داخل كائنات [GroupShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/groupshape/). المثال أدناه يستخرج صورًا من إطارات الصور، الأشكال المملوءة بالصور، معاينات كائنات OLE، صُغَر إطارات الفيديو، وصُغَر إطارات الصوت. لتضمين صور الجداول، المخططات، SmartArt، وصور تكبير الملخص أيضًا، أعد استخدام منطق الاستخراج المتخصص من الأقسام السابقة مع الحفاظ على نفس عبور الشكل المتكرر.

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

## **Edge Cases and Practical Notes**

- **Duplicate images:** قد تشير عدة أشكال إلى نفس الصورة أو إلى صور منفصلة ذات بايتات متطابقة. احسب تجزئة بيانات [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) من `getBinaryData()` قبل كتابة الملفات إذا كنت تريد ملف إخراج واحد لكل صورة فريدة.
- **Original data vs. converted output:** حفظ بيانات [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) من `getBinaryData()` يحافظ على بيانات JPEG أو PNG أو GIF أو SVG أو EMF أو WMF المدمجة. حفظ الصورة المسترجعة عبر `getImage()` مفيد عندما تريد تنسيق إخراج موحد.
- **Unsupported fill types:** لا تحتوي الأشكال الصلبة، المتدرجة، النمطية، أو غير المملوءة على ملء صورة. تحقق من [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) قبل قراءة `getPictureFillFormat()`.
- **Grouped shapes:** لا تقوم مجموعة أشكال الشريحة العليا بتسطيح المجموعات. افحص محتوى [GroupShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/groupshape/) بشكل متكرر عبر `getShapes()` عندما يكون المحتوى المجمّع مهمًا.
- **OLE object previews:** قد يُظهر [OleObjectFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/oleobjectframe/) صورة معاينة عبر `getSubstitutePictureFormat()`، لكن هذه الصورة هي مجرد معاينة الشريحة ولا تمثل الملف المدمج داخل كائن OLE.
- **Video frame thumbnails:** قد يُظهر [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) صورة معاينة عبر `getPictureFormat()`، ولكن هذه الصورة هي الملصق المعروض على الشريحة وليست مستخرجة من تدفق الفيديو.
- **Audio frame thumbnails:** قد يُظهر [AudioFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/) أيقونة أو صورة مصغرة عبر `getPictureFormat()`؛ هي ليست بيانات الصوت المدمجة.
- **Zoom images:** قد تستخدم أشكال تكبير الشريحة، تكبير القسم، وتكبير الملخص صورًا مخصصة من نوع [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) عبر `getZoomImage()`.
- **Nested shape models:** تُطبق كائنات الجدول، المخطط، وSmartArt الواجهة [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/)، لكن صورها غالبًا ما تُخزن في كائنات تنسيق خلية الجدول المتداخلة، أو عنصر المخطط، أو تنسيق عقدة SmartArt.
- **Cropped or transformed pictures:** الوصول إلى [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) يمنحك المورد الصورة المخزن. لا يُظهر الاقتصاص، الشفافية، إعادة الصبغ، الدوران، أو أي تأثيرات بصرية أخرى يطبقها الشكل.

## **FAQ**

**هل يمكنني استخراج الصورة الأصلية دون الاقتصاص أو التأثيرات أو تحولات الشكل؟**

نعم. احصل على كائن [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) واكتب البيانات من `getBinaryData()` إلى القرص. هذا يحافظ على الصورة المشفرة الأصلية المخزنة في العرض التقديمي، وليس الطريقة التي تُعرض بها الصورة على الشريحة.

**هل يمكنني تصدير كل صورة مستخرجة كـ PNG؟**

نعم. استخدم [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) وطريقة `getImage()` الخاصة به، ثم استدعِ `save()` مع [ImageFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imageformat/). سيؤدي ذلك إلى تحويل الإخراج وقد لا يحافظ على نوع الملف الأصلي أو البيانات المتجهة.

**كيف أتجنب حفظ نفس الصورة أكثر من مرة؟**

استخدم تجزئة بيانات [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) من `getBinaryData()` واحتفظ بالتجزئات في مجموعة. إذا وجدت صورة جديدة لها تجزئة موجودة مسبقًا، فتخطها أو سجِّل إشارة أخرى إلى ملف الإخراج الموجود.

**لماذا لا تُنتج بعض الأشكال صورة؟**

يمكن لإطارات الصور، الأشكال المملوءة بالصور، إطارات كائنات OLE، إطارات الوسائط، إطارات التكبير، الجداول، المخططات، وكائنات SmartArt أن تشير إلى صور. بعض أنواع الأشكال تُظهر الصور عبر كائنات تنسيق متداخلة، لذا فحص `getPictureFormat()` أو `getFillFormat()` وحدهما قد لا يكون كافيًا.

**هل يمكنني استخراج الصورة المصغرة المعروضة لإطار الفيديو؟**

نعم. استخدم [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) واقرأ `getPictureFormat()->getPicture()->getImage()`. هذا يستخرج صورة الملصق المخزنة مع إطار الفيديو، وليس إطارًا مُستخرجًا من ملف الفيديو.

**كيف يمكنني تحديد أي الأشكال تستخدم صورة معينة من مجموعة صور العرض التقديمي؟**

لا تخزن Aspose.Slides روابط عكسية من [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) إلى الأشكال. قم بإنشاء خريطة أثناء الاستعراض: كلما وجدت مرجع صورة، سجِّل رقم الشريحة، مسار الشكل، وتجزئة الصورة أو عنصر المجموعة.

**هل يمكنني استخراج الصور المدمجة داخل كائنات OLE، مثل المستندات المرفقة؟**

يمكنك استخراج معاينة الشريحة لكائن OLE عبر [OleObjectFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/oleobjectframe/). إلا أن هذه المعاينة ليست المستند المدمج نفسه. لاستخراج الصور من داخل الملف المدمج، استخرج بيانات OLE وافحصها بأدوات مناسبة لنوع ذلك الملف.