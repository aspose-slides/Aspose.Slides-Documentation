---
title: استخراج تصاویر از اشکال ارائه در PHP
linktitle: تصویر از شكل
type: docs
weight: 100
url: /fa/php-java/extracting-images-from-presentation-shapes/
keywords:
- استخراج تصویر
- بازیابی تصویر
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "تصاویر را از اشکال در ارائه‌های پاورپوینت و OpenDocument با Aspose.Slides برای PHP از طریق Java استخراج کنید - راه‌حل سریع و مناسب برای کدنویسی."
---
## **بررسی کلی**

تصاویر در یک ارائه می‌توانند در انواع مختلف اشکال ظاهر شوند: به صورت قاب‌های تصویر عادی، به صورت پر کردن تصویر اعمال‌شده به اشکال، به عنوان تصاویر پیش‌نمایش اشیاء OLE، به عنوان تصویرهای کوچک فریم‌های ویدیو یا صدا، به عنوان تصاویر بزرگ‌نمایی، یا به عنوان تصاویری که در داخل جدول، نمودار و اشکال SmartArt تو در تو هستند. Aspose.Slides این تصاویر را در مجموعه تصویر ارائه ذخیره می‌کند که از طریق اشیاء [ImageCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) و [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) در دسترس است.

اگر فقط نیاز دارید همه منابع تصویری جاسازی‌شده در یک ارائه را برون‌ریزی کنید، از حلقه `presentation->getImages()` استفاده کنید. این مقاله بر روی وظیفه‌ای متفاوت تمرکز دارد: مرور اشکال برای یافتن مکان استفاده از تصاویر در اسلایدها، به طوری که فایل‌های ذخیره‌شده بتوانند زمینه مفیدی مانند شماره اسلاید، موقعیت شکل و نوع منبع (قاب تصویر، تصویر پر کردن، پیش‌نمایش رسانه، پیش‌نمایش OLE یا تصویر بزرگ‌نمایی) را حفظ کنند.

{{% alert title="نکته" color="primary" %}}
از [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) و متد `getBinaryData()` آن استفاده کنید تا داده‌های تصویر کدگذاری‌شده اصلی و نوع فایل حفظ شود. هنگامی که می‌خواهید خروجی را به فرمتی خاص مانند PNG نرمال کنید، از `getImage()` استفاده کنید.
{{% /alert %}}

## **روش‌های کمکی مشترک**

متدهای کمکی زیر طول مثال‌ها را کوتاه نگه می‌دارند. `saveOriginalImage` بایت‌های اصلی جاسازی‌شده را می‌نویسد، پسوند مناسبی بر اساس نوع MIME انتخاب می‌کند و باینری‌های تصویر تکراری را بر اساس هش SHA‑256 به‌دست‌آمده نادیده می‌گیرد.

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

## **استخراج تصاویر از قاب‌های تصویر**

از این روش برای تصاویری که به‌عنوان اشیاء مستقل وارد شده‌اند، استفاده کنید. یک [PictureFrame] تصویر خود را در `getPictureFormat()->getPicture()->getImage()` ذخیره می‌کند که یک شیء [PPImage] بر می‌گرداند.

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

## **استخراج تصاویر از اشکال پر شده با تصویر**

اشکال می‌توانند یک تصویر را به عنوان پرکننده خود استفاده کنند. ابتدا نوع پرکننده shape را بررسی کنید: اگر برابر با [FillType.Picture] نباشد، تصویری برای استخراج از آن پرکننده وجود ندارد. مثال زیر اشیاء [AutoShape] را پردازش می‌کند و هر تصویر را به‌صورت PNG از طریق [PPImage] و متد `getImage()` آن ذخیره می‌گیرد.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های شیء OLE**

یک [OleObjectFrame] می‌تواند تصویری جایگزین داشته باشد که PowerPoint به عنوان پیش‌نمایش شیء روی اسلاید استفاده می‌کند. این تصویر از طریق `getSubstitutePictureFormat()->getPicture()->getImage()` در دسترس است. استخراج این تصویر پیش‌نمایش را به شما می‌دهد، نه محتویات بسته OLE جاسازی‌شده.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های ویدیو**

یک [VideoFrame] نیز می‌تواند یک تصویر پیش‌نمایش را در `getPictureFormat()->getPicture()->getImage()` ذخیره کند. این تصویر پوستر یا تصویر کوچک نمایش داده‌شده روی اسلاید است و فریمی از جریان ویدیو استخراج‌شده نیست.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های صوتی**

یک [AudioFrame] می‌تواند تصویر کوچک را در `getPictureFormat()->getPicture()->getImage()` ذخیره کند. این تصویر برای شیء صوتی روی اسلاید نمایش داده می‌شود.

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

## **استخراج تصاویر از اشیاء زوم**

اشکال [ZoomFrame] و [SectionZoomFrame] می‌توانند از تصاویر سفارشی استفاده کنند. با استفاده از `getZoomImage()` از فریم زوم تصویر را بخوانید.

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

## **استخراج تصاویر از فریم‌های زوم خلاصه**

[SummaryZoomFrame] نیز یک شکل است. آیتم‌های بخش آن می‌توانند از تصاویر سفارشی استفاده کنند که از طریق متد `getZoomImage()` هر بخش زوم خلاصه در دسترس هستند.

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

## **استخراج تصاویر از اشکال جدول**

[Table] یک شکل است. تصاویر داخل جدول معمولاً به‌عنوان پرکننده‌های تصویر در سلول‌های جدول ذخیره می‌شوند.

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

## **استخراج تصاویر از اشکال نمودار**

[Chart] یک شکل است. مثال زیر تصویری را از پرکننده تصویر ناحیه نمودار استخراج می‌کند.

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

## **استخراج تصاویر از اشکال SmartArt**

یک شیء [SmartArt] یک شکل است. بسته به چیدمان SmartArt، تصاویر ممکن است در پرکننده‌های نقطه‌گذاری گره یا در فرمت‌های پرکننده‌ی شکل‌های گره ذخیره شوند.

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

## **گنجاندن تصاویر داخل اشکال گروهی**

اشکال گروهی دارای مجموعه‌های شکل خودشان هستند. کمکی مشترک `enumerateShapes` گزینه `includeGroupedShapes` دارد. وقتی می‌خواهید اشکال داخل اشیاء [GroupShape] را بررسی کنید، این گزینه را به `true` تنظیم کنید. مثال زیر تصاویر را از قاب‌های تصویر، اشکال پر شده با تصویر، پیش‌نمایش‌های شیء OLE، تصویرهای کوچک فریم‌های ویدیو و تصویرهای کوچک فریم‌های صوتی استخراج می‌کند. برای گنجاندن تصاویر جدول، نمودار, SmartArt و زوم خلاصه نیز، منطق استخراج ویژه از بخش‌های قبلی را باز استفاده کنید و همان مرور بازگشتی اشکال را حفظ کنید.

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

## **موارد خاص و نکات عملی**

- **تصاویر تکراری:** چندین شکل ممکن است به همان تصویر یا به تصاویر جداگانه‌ای با بایت‌های یکسان ارجاع دهند. قبل از نوشتن فایل‌ها، داده‌های [PPImage] را با استفاده از `getBinaryData()` هش کنید اگر می‌خواهید برای هر تصویر منحصر به‌فرد یک فایل خروجی داشته باشید.
- **داده اصلی در مقابل خروجی تبدیل‌شده:** ذخیره داده‌های [PPImage] از `getBinaryData()` داده‌های JPEG، PNG، GIF، SVG، EMF یا WMF جاسازی‌شده را حفظ می‌کند. ذخیره تصویری که توسط `getImage()` برگردانده می‌شود زمانی مفید است که می‌خواهید خروجی یک قالب ثابت داشته باشید.
- **انواع پرکننده پشتیبانی‌نشده:** اشکال با پرکنندهٔ ثابت، گرادیان، الگو یا بدون پرکننده شامل پرکنندهٔ تصویری نیستند. قبل از خواندن `getPictureFillFormat()`، [FillType] را بررسی کنید.
- **اشکال گروهی:** مجموعهٔ اشکال اسلاید در سطح بالا گروه‌ها را صاف (flatten) نمی‌کند. وقتی محتوای گروهی مهم است، به‌صورت بازگشتی محتویات [GroupShape] را از طریق `getShapes()` بررسی کنید.
- **پیش‌نمایش اشیاء OLE:** یک [OleObjectFrame] ممکن است تصویر پیش‌نمایشی از طریق `getSubstitutePictureFormat()` ارائه دهد، اما این تصویر فقط پیش‌نمایش اسلاید است و فایل جاسازی‌شده داخل شیء OLE نیست.
- **تصویرهای کوچک فریم ویدیو:** یک [VideoFrame] ممکن است تصویر پیش‌نمایشی از طریق `getPictureFormat()` ارائه دهد، اما این تصویر فقط پوستر نمایش داده‌شده روی اسلاید است و از جریان ویدیو استخراج نمی‌شود.
- **تصویرهای کوچک فریم صوتی:** یک [AudioFrame] ممکن است یک نماد یا تصویر کوچک از طریق `getPictureFormat()` ارائه دهد؛ این دادهٔ صوتی جاسازی‌شده نیست.
- **تصاویر زوم:** اشکال زوم اسلاید، زوم بخش و زوم خلاصه ممکن است از اشیاء سفارشی [PPImage] از طریق `getZoomImage()` استفاده کنند.
- **مدل‌های اشکال تو در تو:** اشیاء جدول، نمودار و SmartArt از [Shape] پیاده‌سازی می‌شوند، اما تصاویر آن‌ها اغلب در سلول‌های جدول تو در تو، عنصر نمودار یا شیء فرمت‌گذاری گرهٔ SmartArt ذخیره می‌شوند.
- **تصاویر برش‌خورده یا تغییر شکل یافته:** دسترسی به [PPImage] به شما منبع تصویر ذخیره‌شده را می‌دهد. این تصویر برش، شفافیت، تغییر رنگ، چرخش یا سایر اثرات بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **پرسش‌های متداول**

**آیا می‌توانم تصویر اصلی را بدون برش، افکت‌ها یا تبدیل‌های شکل استخراج کنم؟**  
بله. به شیء [PPImage] دسترسی پیدا کنید و داده‌های `getBinaryData()` را روی دیسک بنویسید. این کار تصویر کدگذاری‌شدهٔ اصلی ذخیره‌شده در ارائه را حفظ می‌کند، نه نحوهٔ رندر تصویر بر روی اسلاید.

**آیا می‌توانم هر تصویر استخراج‌شده را به‌صورت PNG برون‌ریزی کنم؟**  
بله. از [PPImage] و متد `getImage()` آن استفاده کنید، سپس با [ImageFormat] متد `save()` را فراخوانی کنید. این کار خروجی را به فرمت دیگری تبدیل می‌کند و ممکن است نوع فایل اصلی یا داده‌های برداری را حفظ نکند.

**چگونه می‌توانم از ذخیرهٔ یک تصویر بیش از یک بار جلوگیری کنم؟**  
از یک هش برای داده‌های [PPImage] به‌دست‌آمده از `getBinaryData()` استفاده کنید و هش‌ها را در یک مجموعه نگه دارید. اگر تصویری جدید هش موجودی داشته باشد، آن را نادیده بگیرید یا یک مرجع دیگر به فایل خروجی موجود ثبت کنید.

**چرا برخی اشکال تصویری تولید نمی‌کنند؟**  
قاب‌های تصویر، اشکال پر شده با تصویر، فریم‌های شیء OLE، فریم‌های رسانه‌ای، فریم‌های زوم، جدول‌ها، نمودارها و اشیاء SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع شکل‌ها تصاویر را از طریق اشیاء فرمت‌بندی تو در تو ارائه می‌دهند، بنابراین یک بررسی ساده با `getPictureFormat()` یا `getFillFormat()` شکل همیشه کافی نیست.

**آیا می‌توانم تصویر کوچک نشان‌داده‌شده برای فریم ویدیو را استخراج کنم؟**  
بله. از [VideoFrame] استفاده کنید و `getPictureFormat()->getPicture()->getImage()` را بخوانید. این کار تصویر پوستر ذخیره‌شده با فریم ویدیو را استخراج می‌کند، نه فریمی که از فایل ویدیو تولید شده باشد.

**چگونه می‌توانم تعیین کنم کدام اشکال از یک تصویر خاص در مجموعه تصویر ارائه استفاده می‌کنند؟**  
Aspose.Slides لینک‌های معکوسی از [PPImage] به اشکال ذخیره نمی‌کند. در طول مرور یک نگاشت بسازید: هرگاه به یک ارجاع تصویر برخوردید، شماره اسلاید، مسیر شکل و هش تصویر یا آیتم مجموعه را ثبت کنید.

**آیا می‌توانم تصاویر جاسازی‌شده داخل اشیاء OLE، مانند اسناد پیوست‌شده، را استخراج کنم؟**  
می‌توانید پیش‌نمایش اسلاید شیء OLE را از [OleObjectFrame] استخراج کنید. اما این پیش‌نمایش خود سند جاسازی‌شده نیست. برای استخراج تصاویر از داخل فایل جاسازی‌شده، داده‌های OLE را استخراج کرده و با ابزارهای مناسب آن نوع فایل بررسی کنید.