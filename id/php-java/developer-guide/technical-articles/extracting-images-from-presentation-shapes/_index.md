---
title: Ekstrak Gambar dari Bentuk Presentasi di PHP
linktitle: Gambar dari Bentuk
type: docs
weight: 100
url: /id/php-java/extracting-images-from-presentation-shapes/
keywords:
- ekstrak gambar
- ambil gambar
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Ekstrak gambar dari bentuk dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk PHP via Java - solusi cepat dan ramah kode."
---
## **Ikhtisar**

Gambar dalam presentasi dapat muncul dalam beberapa jenis bentuk: sebagai bingkai gambar biasa, sebagai isian gambar yang diterapkan pada bentuk, sebagai gambar pratinjau objek OLE, sebagai thumbnail bingkai video atau audio, sebagai gambar zoom, atau sebagai gambar yang bersarang di dalam bentuk tabel, diagram, dan SmartArt. Aspose.Slides menyimpan gambar‑gambar tersebut dalam koleksi gambar presentasi, yang dapat diakses melalui objek [ImageCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/imagecollection/) dan [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/).

Jika Anda hanya perlu mengekspor setiap sumber gambar yang tertanam dalam sebuah presentasi, iterasikan melalui `presentation->getImages()`. Artikel ini fokus pada tugas yang berbeda: menelusuri bentuk‑bentuk untuk menemukan di mana gambar digunakan pada slide, sehingga file yang disimpan dapat mempertahankan konteks yang berguna seperti nomor slide, posisi bentuk, dan tipe sumber (bingkai gambar, gambar isian, pratinjau media, pratinjau OLE, atau gambar zoom).

{{% alert title="Tip" color="primary" %}}
Gunakan [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dan metode `getBinaryData()`‑nya untuk mempertahankan data gambar yang terenkode asal serta tipe file. Gunakan `getImage()` bila Anda ingin menormalkan output ke format tertentu seperti PNG.
{{% /alert %}}

## **Metode Pembantu Bersama**

Metode pembantu di bawah ini membuat contoh menjadi singkat. `saveOriginalImage` menulis byte asli yang tertanam, memilih ekstensi yang aman dari tipe MIME, dan melewati duplikat data gambar berdasarkan hash SHA‑256.

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

## **Ekstrak Gambar dari Bingkai Gambar**

Gunakan pendekatan ini untuk gambar yang dimasukkan sebagai objek mandiri. Sebuah [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) menyimpan gambar dalam `getPictureFormat()->getPicture()->getImage()`, yang mengembalikan objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/).

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

## **Ekstrak Gambar dari Bentuk yang Diisi Gambar**

Bentuk dapat menggunakan gambar sebagai isian mereka. Periksa jenis isian bentuk terlebih dahulu: jika bukan [FillType.Picture](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/), tidak ada gambar yang dapat diekstrak dari isian tersebut. Contoh di bawah menangani objek [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) dan menyimpan setiap gambar sebagai PNG melalui [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dan metode `getImage()`‑nya.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Objek OLE**

Sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/) dapat memiliki gambar pengganti yang digunakan PowerPoint sebagai pratinjau objek pada slide. Gambar ini tersedia melalui `getSubstitutePictureFormat()->getPicture()->getImage()`. Mengekstrak gambar ini memberi Anda gambar pratinjau, bukan isi paket OLE yang tertanam.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Video**

Sebuah [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) juga dapat menyimpan gambar pratinjau dalam `getPictureFormat()->getPicture()->getImage()`. Ini adalah poster atau thumbnail yang ditampilkan pada slide, bukan frame yang didekode dari aliran video.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Audio**

Sebuah [AudioFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/) dapat menyimpan thumbnail dalam `getPictureFormat()->getPicture()->getImage()`. Ini adalah gambar yang ditampilkan untuk objek audio pada slide.

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

## **Ekstrak Gambar dari Objek Zoom**

Bentuk [ZoomFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/zoomframe/) dan [SectionZoomFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/sectionzoomframe/) dapat menggunakan gambar khusus. Baca `getZoomImage()` dari bingkai zoom.

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

## **Ekstrak Gambar dari Bingkai Zoom Ringkasan**

Sebuah [SummaryZoomFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/summaryzoomframe/) juga merupakan bentuk. Item bagian ringkasannya dapat menggunakan gambar khusus, yang diekspose melalui metode `getZoomImage()` masing‑masing pada bagian zoom ringkasan.

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

## **Ekstrak Gambar dari Bentuk Tabel**

Sebuah [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/table/) adalah bentuk. Gambar dalam tabel biasanya disimpan sebagai isian gambar pada sel tabel.

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

## **Ekstrak Gambar dari Bentuk Diagram**

Sebuah [Chart](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/) adalah bentuk. Contoh di bawah mengekstrak gambar dari isian gambar area diagram.

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

## **Ekstrak Gambar dari Bentuk SmartArt**

Objek [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/) adalah bentuk. Bergantung pada tata letak SmartArt, gambar dapat disimpan dalam isian peluru node atau dalam format isian bentuk node.

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

## **Sertakan Gambar di Dalam Bentuk Berkelompok**

Bentuk berkelompok memiliki koleksi bentuknya masing‑masing. Metode pembantu `enumerateShapes` memiliki opsi `includeGroupedShapes`. Atur ke `true` bila Anda ingin memeriksa bentuk di dalam objek [GroupShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/groupshape/). Contoh di bawah mengekstrak gambar dari bingkai gambar, bentuk yang diisi gambar, pratinjau objek OLE, thumbnail bingkai video, dan thumbnail bingkai audio. Untuk menyertakan gambar tabel, diagram, SmartArt, dan zoom ringkasan juga, gunakan kembali logika ekstraksi khusus dari bagian‑bagian sebelumnya sambil mempertahankan penelusuran bentuk rekursif yang sama.

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

## **Kasus Khusus dan Catatan Praktis**

- **Gambar duplikat:** Beberapa bentuk dapat merujuk pada gambar yang sama atau gambar terpisah dengan byte identik. Hash data [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dari `getBinaryData()` sebelum menulis file bila Anda menginginkan satu file output per gambar unik.
- **Data asli vs. output yang dikonversi:** Menyimpan data [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dari `getBinaryData()` mempertahankan data JPEG, PNG, GIF, SVG, EMF, atau WMF yang tertanam. Menyimpan gambar yang dikembalikan oleh `getImage()` berguna bila Anda menginginkan format output yang konsisten.
- **Jenis isian yang tidak didukung:** Bentuk dengan isian padat, gradien, pola, atau tanpa isian tidak mengandung isian gambar. Periksa [FillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) sebelum membaca `getPictureFillFormat()`.
- **Bentuk berkelompok:** Koleksi bentuk slide tingkat atas tidak meratakan grup. Periksa isi [GroupShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/groupshape/) secara rekursif melalui `getShapes()` bila konten berkelompok penting.
- **Pratinjau objek OLE:** Sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/) dapat mengekspos gambar pratinjau melalui `getSubstitutePictureFormat()`, tetapi gambar tersebut hanya pratinjau slide. Itu bukan file yang tertanam di dalam objek OLE.
- **Thumbnail bingkai video:** Sebuah [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) dapat mengekspos gambar pratinjau melalui `getPictureFormat()`, tetapi gambar tersebut hanya poster yang ditampilkan pada slide. Itu tidak diekstrak dari aliran video.
- **Thumbnail bingkai audio:** Sebuah [AudioFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/audioframe/) dapat mengekspos ikon atau thumbnail melalui `getPictureFormat()`; itu bukan data audio yang tertanam.
- **Gambar zoom:** Bentuk zoom slide, zoom bagian, dan zoom ringkasan dapat menggunakan objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) khusus melalui `getZoomImage()`.
- **Model bentuk bersarang:** Objek tabel, diagram, dan SmartArt mengimplementasikan [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/), tetapi gambar mereka sering disimpan dalam objek format sel tabel, elemen diagram, atau node SmartArt yang bersarang.
- **Gambar yang dipotong atau ditransformasi:** Mengakses [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) memberikan Anda sumber gambar yang disimpan. Itu tidak menerapkan pemotongan, transparansi, pewarnaan ulang, rotasi, atau efek visual lain yang diterapkan oleh bentuk.

## **FAQ**

**Apakah saya dapat mengekstrak gambar asli tanpa pemotongan, efek, atau transformasi bentuk?**

Ya. Akses objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dan tulis data dari `getBinaryData()` ke disk. Ini mempertahankan gambar terenkode asli yang disimpan dalam presentasi, bukan cara gambar tersebut dirender pada slide.

**Apakah saya dapat mengekspor setiap gambar yang diekstrak sebagai PNG?**

Ya. Gunakan [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dan metode `getImage()`, lalu panggil `save()` dengan [ImageFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/imageformat/). Ini mengonversi output dan mungkin tidak mempertahankan tipe file atau data vektor asli.

**Bagaimana cara menghindari menyimpan gambar yang sama lebih dari satu kali?**

Gunakan hash data [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dari `getBinaryData()` dan simpan hash‑hash tersebut dalam satu set. Jika gambar baru memiliki hash yang sudah ada, lewati atau catat referensi lain ke file output yang sudah ada.

**Mengapa beberapa bentuk tidak menghasilkan gambar?**

Bingkai gambar, bentuk yang diisi gambar, bingkai objek OLE, bingkai media, bingkai zoom, tabel, diagram, dan objek SmartArt dapat merujuk pada gambar. Beberapa tipe bentuk mengekspos gambar melalui objek format bersarang, sehingga pemeriksaan sederhana `getPictureFormat()` atau `getFillFormat()` pada bentuk tidak selalu cukup.

**Apakah saya dapat mengekstrak thumbnail yang ditampilkan untuk bingkai video?**

Ya. Gunakan [VideoFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/videoframe/) dan baca `getPictureFormat()->getPicture()->getImage()`. Ini mengekstrak poster yang disimpan bersama bingkai video, bukan frame yang dihasilkan dari file video.

**Bagaimana saya dapat menentukan bentuk mana yang menggunakan gambar tertentu dari koleksi gambar presentasi?**

Aspose.Slides tidak menyimpan tautan terbalik dari [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) ke bentuk. Bangun pemetaan selama penelusuran: setiap kali menemukan referensi gambar, catat nomor slide, jalur bentuk, dan hash atau item koleksi gambar.

**Apakah saya dapat mengekstrak gambar yang tertanam di dalam objek OLE, seperti dokumen yang dilampirkan?**

Anda dapat mengekstrak pratinjau slide objek OLE dari [OleObjectFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleobjectframe/). Namun, pratinjau tersebut bukan dokumen yang tertanam itu sendiri. Untuk mengekstrak gambar dari dalam file yang tertanam, ekstrak data OLE dan periksa dengan alat yang sesuai untuk tipe file tersebut.