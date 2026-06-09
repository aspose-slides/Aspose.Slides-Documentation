---
title: PHP ile Sunum Şekillerinden Görselleri Çıkarma
linktitle: Şekilden Görsel
type: docs
weight: 100
url: /tr/php-java/extracting-images-from-presentation-shapes/
keywords:
- görsel çıkarma
- görsel alma
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint ve OpenDocument sunumlarındaki şekillerden görselleri çıkarın - hızlı, kod dostu bir çözüm."
---
## **Genel Bakış**

Bir sunumdaki görseller çeşitli şekil türlerinde görünebilir: normal resim çerçeveleri olarak, şekillere uygulanan resim doldurmaları olarak, OLE nesne ön izleme görselleri olarak, video veya ses çerçeve küçük resimleri olarak, yakınlaştırma görselleri olarak veya tablo, grafik ve SmartArt şekillerinin içinde iç içe geçmiş görseller olarak. Aspose.Slides bu görselleri sunum görsel koleksiyonunda depolar ve bu koleksiyon [ImageCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) ve [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesneleri aracılığıyla sunulur.

Sadece sunuma gömülü tüm görsel kaynaklarını dışa aktarmanız gerekiyorsa `presentation->getImages()` üzerinde döngü oluşturun. Bu makale farklı bir görevde odaklanır: slaytlarda görsellerin nerede kullanıldığını bulmak için şekilleri dolaşmak, böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak türü (resim çerçevesi, doldurma görseli, medya önizlemesi, OLE önizlemesi veya yakınlaştırma görseli) gibi faydalı bağlamı koruyabilir.

{{% alert title="Tip" color="primary" %}}
Orijinal kodlanmış görsel verisini ve dosya türünü korumak için [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) ve `getBinaryData()` metodunu kullanın. Çıktıyı PNG gibi belirli bir formata normalleştirmek istediğinizde `getImage()` metodunu kullanın.
{{% /alert %}}

## **Paylaşılan Yardımcı Yöntemler**

Aşağıdaki yardımcı yöntemler örnekleri kısa tutar. `saveOriginalImage` orijinal gömülü baytları yazar, MIME türünden güvenli bir uzantı seçer ve SHA-256 hash'i kullanarak yinelenen görsel ikili verilerini atlar.

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

## **Resim Çerçevelerinden Görselleri Çıkarma**

Bu yaklaşımı bağımsız nesne olarak eklenen resimler için kullanın. Bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) resmini `getPictureFormat()->getPicture()->getImage()` içinde saklar ve bu, bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi döndürür.

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

## **Resim Doldurmalı Şekillerden Görselleri Çıkarma**

Şekiller, dolgu olarak bir resim kullanabilir. Önce şeklin dolgu tipini kontrol edin: eğer [FillType.Picture](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) değilse, bu dolgudan çıkarılacak bir resim yoktur. Aşağıdaki örnek [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) nesnelerini ele alır ve her görseli [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) ve `getImage()` metodu aracılığıyla PNG olarak kaydeder.

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

## **OLE Nesne Çerçevelerinden Ön İzleme Görselleri Çıkarma**

Bir [OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) bir yerine koyma resmi içerebilir; PowerPoint bu resmi slaytta nesnenin ön izlemesi olarak kullanır. Bu görsel `getSubstitutePictureFormat()->getPicture()->getImage()` aracılığıyla elde edilir. Bu resmi çıkarmak, gömülü OLE paket içeriği değil, ön izleme görselini verir.

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

## **Video Çerçevelerinden Ön İzleme Görselleri Çıkarma**

Bir [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) ayrıca bir ön izleme görselini `getPictureFormat()->getPicture()->getImage()` içinde depolayabilir. Bu, slaytta gösterilen poster veya küçük resimdir, video akışından çözülen bir çerçeve değildir.

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

## **Ses Çerçevelerinden Ön İzleme Görselleri Çıkarma**

Bir [AudioFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/) `getPictureFormat()->getPicture()->getImage()` içinde bir küçük resim depolayabilir. Bu, slayttaki ses nesnesi için gösterilen görseldir.

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

## **Yakınlaştırma Nesnelerinden Görselleri Çıkarma**

[ZoomFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zoomframe/) ve [SectionZoomFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sectionzoomframe/) şekilleri özel görseller kullanabilir. Yakınlaştırma çerçevesinden `getZoomImage()` metodunu okuyun.

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

## **Özet Yakınlaştırma Çerçevelerinden Görselleri Çıkarma**

[SummaryZoomFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/summaryzoomframe/) de bir şekildir. Bölüm öğeleri özel görseller kullanabilir; bu görseller her özet yakınlaştırma bölümünün `getZoomImage()` metodu ile ortaya çıkar.

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

## **Tablo Şekillerinden Görselleri Çıkarma**

[Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/) bir şekildir. Tablodaki görseller genellikle tablo hücrelerindeki resim doldurmaları olarak depolanır.

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

## **Grafik Şekillerinden Görselleri Çıkarma**

[Chart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/) bir şekildir. Aşağıdaki örnek, grafik alanının resim doldurmasından bir görsel çıkarır.

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

## **SmartArt Şekillerinden Görselleri Çıkarma**

[SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) nesnesi bir şekildir. SmartArt düzenine bağlı olarak, görseller düğüm madde işareti doldurmalarında veya düğüm şekillerinin doldurma biçimlerinde depolanabilir.

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

## **Gruplanmış Şekiller İçindeki Görselleri Dahil Et**

Gruplanmış şekiller kendi şekil koleksiyonlarını içerir. Paylaşılan `enumerateShapes` yardımcı metodunda `includeGroupedShapes` seçeneği bulunur. [GroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/groupshape/) nesneleri içindeki şekilleri incelemek istediğinizde bunu `true` olarak ayarlayın. Aşağıdaki örnek, resim çerçevelerinden, resim doldurmalı şekillerden, OLE nesne ön izlemelerinden, video çerçeve küçük resimlerinden ve ses çerçeve küçük resimlerinden görselleri çıkarır. Tablo, grafik, SmartArt ve özet yakınlaştırma görsellerini de dahil etmek için önceki bölümlerdeki özel çıkarma mantığını aynı yinelemeli şekil taramasını koruyarak yeniden kullanın.

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

## **Köşe Durumları ve Pratik Notlar**

- **Duplicate images:** Birden çok şekil aynı görsele veya aynı baytlara sahip ayrı görsellere referans verebilir. Tekil görsel başına bir çıktı dosyası istiyorsanız dosyaları yazmadan önce `getBinaryData()` üzerinden [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) verisini hash'leyin.
- **Original data vs. converted output:** Orijinal JPEG, PNG, GIF, SVG, EMF veya WMF verisini korumak için [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) verisini `getBinaryData()` ile kaydetmek, `getImage()` ile elde edilen görüntüyü kaydetmek ise çıktıyı tutarlı bir formata dönüştürmek için uygundur.
- **Unsupported fill types:** Solid, gradient, pattern ve no‑fill şekiller resim doldurması içermez. `getPictureFillFormat()` okurmadan önce [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) kontrol edin.
- **Grouped shapes:** Üst düzey slayt şekil koleksiyonu grupları düzleştirmez. Grup içeriği önemli olduğunda [GroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/groupshape/) içeriğini `getShapes()` ile yinelemeli olarak inceleyin.
- **OLE object previews:** Bir [OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) `getSubstitutePictureFormat()` aracılığıyla bir ön izleme görseli sunabilir, ancak bu sadece slayt ön izlemesidir. OLE nesnesinin içinde gömülü dosya değildir.
- **Video frame thumbnails:** Bir [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) `getPictureFormat()` aracılığıyla bir ön izleme görseli sunabilir, ancak bu sadece slaytta gösterilen posterdir. Video akışından çıkarılan bir çerçeve değildir.
- **Audio frame thumbnails:** Bir [AudioFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/) `getPictureFormat()` aracılığıyla bir simge veya küçük resim sunabilir; bu gömülü ses verisi değildir.
- **Zoom images:** Slayt yakınlaştırma, bölüm yakınlaştırma ve özet yakınlaştırma şekilleri `getZoomImage()` aracılığıyla özel [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesneleri kullanabilir.
- **Nested shape models:** Tablo, grafik ve SmartArt nesneleri [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) arayüzünü uygular, ancak görselleri genellikle iç içe tablo hücresi, grafik öğesi veya SmartArt düğüm biçimlendirme nesnelerinde depolanır.
- **Cropped or transformed pictures:** [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) erişmek, depolanmış görsel kaynağını verir. Kesme, şeffaflık, renk değiştirme, döndürme veya şekil tarafından uygulanan diğer görsel etkileri uygulamaz.

## **SSS**

**Orijinal resmi kırpma, efektler veya şekil dönüşümleri olmadan çıkarabilir miyim?**

Evet. [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesine erişin ve `getBinaryData()` verisini diske yazın. Bu, sunumda depolanmış orijinal kodlanmış görseli korur, slaytta nasıl render edildiği değil.

**Çıkarılan her görseli PNG olarak dışa aktarabilir miyim?**

Evet. [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) ve `getImage()` metodunu kullanın, ardından [ImageFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imageformat/) ile `save()` çağırın. Bu, çıktıyı dönüştürür ve orijinal dosya türü veya vektör verisini korumayabilir.

**Aynı görseli birden fazla kez kaydetmekten nasıl kaçınabilirim?**

`getBinaryData()` üzerinden elde edilen [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) verisinin hash'ini bir sette tutun. Yeni bir görselin hash'i zaten mevcutsa, dosyayı atlayın veya mevcut çıktıya başka bir referans kaydedin.

**Neden bazı şekiller görsel üretmiyor?**

Resim çerçeveleri, resim doldurmalı şekiller, OLE nesne çerçeveleri, medya çerçeveleri, yakınlaştırma çerçeveleri, tablolar, grafikler ve SmartArt nesneleri görsellere referans verebilir. Bazı şekil tipleri görselleri iç içe biçimlendirme nesneleri üzerinden sunar, bu yüzden basit bir `getPictureFormat()` veya `getFillFormat()` kontrolü her zaman yeterli olmayabilir.

**Video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?**

Evet. [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) kullanın ve `getPictureFormat()->getPicture()->getImage()` okuyun. Bu, video çerçevesiyle birlikte depolanan poster görselini çıkarır, video dosyasından oluşturulan bir çerçeve değildir.

**Sunum görsel koleksiyonundaki belirli bir görseli hangi şekiller kullandığını nasıl belirleyebilirim?**

Aspose.Slides, [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesinden şekillere ters bağlantılar saklamaz. Gezinme sırasında bir harita oluşturun: bir görsel referansı bulduğunuzda slayt numarasını, şekil yolunu ve görsel hash'ini veya koleksiyon öğesini kaydedin.

**OLE nesneleri içinde gömülü, ekli belgeler gibi görselleri çıkarabilir miyim?**

[OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) üzerinden nesnenin slayt ön izlemesini çıkarabilirsiniz. Ancak bu ön izleme, gömülü belgeyi içermez. Gömülü dosyanın içindeki görselleri çıkarmak için OLE verisini dışa aktarın ve o dosya türü için uygun araçlarla inceleyin.