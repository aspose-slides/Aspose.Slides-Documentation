---
title: Extrahovat obrázky z tvarů prezentace v PHP
linktitle: Obrázek z tvaru
type: docs
weight: 100
url: /cs/php-java/extracting-images-from-presentation-shapes/
keywords:
- extrahovat obrázek
- načíst obrázek
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Extrahujte obrázky z tvarů v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java – rychlé, kódu přátelské řešení."
---
## **Přehled**

Obrázky v prezentaci se mohou objevit v několika typech tvarů: jako obyčejné rámečky obrázků, jako obrázkové výplně aplikované na tvary, jako náhledové obrázky OLE objektů, jako miniatury snímků videa nebo audia, jako obrázky přiblížení nebo jako obrázky vložené uvnitř tabulek, grafů a tvarů SmartArt. Aspose.Slides ukládá tyto obrázky do kolekce obrázků prezentace, kterou poskytují objekty [ImageCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/) a [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) .

Pokud potřebujete pouze exportovat každý obrázkový zdroj vložený v prezentaci, projděte `presentation->getImages()`. Tento článek se zaměřuje na jiný úkol: procházet tvary a zjistit, kde jsou na snímcích použity obrázky, aby uložené soubory mohly zachovat užitečný kontext, jako je číslo snímku, pozice tvaru a typ zdroje (rámeček obrázku, výplň obrázkem, náhled média, náhled OLE nebo obrázek přiblížení).

{{% alert title="Tip" color="primary" %}}
Použijte [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) a jeho metodu `getBinaryData()` k zachování původních zakódovaných dat obrázku a typu souboru. Použijte `getImage()`, pokud chcete normalizovat výstup do konkrétního formátu, například PNG.
{{% /alert %}}

## **Společné pomocné metody**

Pomocné metody níže udržují příklady stručné. `saveOriginalImage` zapisuje původní vložené bajty, vybírá bezpečnou příponu z MIME typu a přeskakuje duplicitní binární data obrázku pomocí SHA-256 hash.

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

## **Extrahovat obrázky z rámečků obrázků**

Použijte tento přístup pro obrázky vložené jako samostatné objekty. [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) ukládá svůj obrázek v `getPictureFormat()->getPicture()->getImage()`, což vrací objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) .

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

## **Extrahovat obrázky z tvarů s výplní obrázkem**

Tvar může používat obrázek jako výplň. Nejprve zkontrolujte typ výplně tvaru: pokud není [FillType.Picture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/), neexistuje žádný obrázek, který by se z výplně dal extrahovat. Níže uvedený příklad pracuje s objekty [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) a ukládá každý obrázek jako PNG pomocí [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) a její metody `getImage()` .

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

## **Extrahovat náhledové obrázky z OLE objektových rámců**

[OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/) může mít náhradní obrázek, který PowerPoint používá jako náhled objektu na snímku. Tento obrázek je dostupný pomocí `getSubstitutePictureFormat()->getPicture()->getImage()` . Extrahování tohoto obrázku vám poskytne náhledový obrázek, ne vložený obsah OLE balíčku.

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

## **Extrahovat náhledové obrázky z video rámců**

[VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) může také ukládat náhledový obrázek pomocí `getPictureFormat()->getPicture()->getImage()` . Jedná se o plakát nebo miniaturu zobrazenou na snímku, ne o snímek dekódovaný z video proudu.

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

## **Extrahovat náhledové obrázky z audio rámců**

[AudioFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/) může ukládat miniaturu pomocí `getPictureFormat()->getPicture()->getImage()` . Jedná se o obrázek zobrazený pro audio objekt na snímku.

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

## **Extrahovat obrázky z Zoom objektů**

[Tvarové objekty] [ZoomFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zoomframe/) a [SectionZoomFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sectionzoomframe/) mohou používat vlastní obrázky. Přečtěte `getZoomImage()` ze zoom rámce.

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

## **Extrahovat obrázky z Summary Zoom rámců**

[SummaryZoomFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/summaryzoomframe/) je také tvar. Jeho sekční položky mohou používat vlastní obrázky, které jsou dostupné přes metodu `getZoomImage()` každé sekce summary zoom.

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

## **Extrahovat obrázky z tabulkových tvarů**

[Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/table/) je tvar. Obrázky v tabulce jsou obvykle uloženy jako výplně obrázkem v buňkách tabulky.

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

## **Extrahovat obrázky z grafových tvarů**

[Chart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/) je tvar. Níže uvedený příklad extrahuje obrázek z výplně obrázkem oblasti grafu.

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

## **Extrahovat obrázky z SmartArt tvarů**

[SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/) objekt je tvar. V závislosti na rozložení SmartArt mohou být obrázky uloženy ve výplních odrážek uzlů nebo ve výplňových formátech uzlových tvarů.

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

## **Zahrnout obrázky uvnitř seskupených tvarů**

Seskupené tvary obsahují vlastní kolekce tvarů. Sdílený pomocný nástroj `enumerateShapes` má volbu `includeGroupedShapes`. Nastavte ji na `true`, pokud chcete prozkoumávat tvary uvnitř objektů [GroupShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/groupshape/) . Níže uvedený příklad extrahuje obrázky z rámečků obrázků, tvarů s výplní obrázkem, náhledů OLE objektů, miniatur video rámců a miniatur audio rámců. Pro zahrnutí obrázků tabulek, grafů, SmartArt a summary zoom také, znovu použijte specializovanou logiku extrakce z předchozích sekcí při zachování stejného rekurzivního procházení tvarů.

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

## **Hraniční případy a praktické poznámky**

- **Duplicitní obrázky:** Více tvarů může odkazovat na stejný obrázek nebo na různé obrázky se stejnými bajty. Vytvořte hash dat [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) z `getBinaryData()` před zápisem souborů, pokud chcete jeden výstupní soubor na unikátní obrázek.
- **Původní data vs. konvertovaný výstup:** Ukládání dat [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) pomocí `getBinaryData()` zachovává vložený JPEG, PNG, GIF, SVG, EMF nebo WMF. Ukládání obrázku vráceného `getImage()` je užitečné, pokud chcete jednotný výstupní formát.
- **Nepodporované typy výplní:** Tvary s plnou, gradientní, vzorovou a žádnou výplní neobsahují výplň obrázkem. Zkontrolujte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) před čtením `getPictureFillFormat()` .
- **Seskupené tvary:** Kolekce tvarů na úrovni snímku neflattenuje skupiny. Rekurzivně kontrolujte obsah [GroupShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/groupshape/) přes `getShapes()`, pokud je důležitý obsah seskupení.
- **Náhledy OLE objektů:** [OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/) může poskytovat náhledový obrázek přes `getSubstitutePictureFormat()`, ale tento obrázek je pouze náhled na snímku. Není to vložený soubor uvnitř OLE objektu.
- **Miniatury video rámců:** [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) může poskytovat náhledový obrázek přes `getPictureFormat()`, ale tento obrázek je pouze plakát zobrazený na snímku. Není extrahován z video proudu.
- **Miniatury audio rámců:** [AudioFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/) může poskytovat ikonu nebo miniaturu přes `getPictureFormat()`; není to vložený audio data.
- **Zoom obrázky:** Snímky zoom, sekční zoom a summary zoom tvary mohou používat vlastní objekty [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přes `getZoomImage()` .
- **Vnořené modely tvarů:** Tabulky, grafy a SmartArt implementují [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/), ale jejich obrázky jsou často uloženy ve vnořených buňkách tabulky, prvcích grafu nebo formátovacích objektech uzlů SmartArt.
- **Ořezané nebo transformované obrázky:** Přístup k [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) vám dává uložený zdroj obrázku. Není to renderování ořezu, transparentnosti, překreslení, rotace nebo dalších vizuálních efektů aplikovaných tvarem.

## **Často kladené otázky**

**Mohu extrahovat původní obrázek bez ořezu, efektů nebo transformací tvaru?**

Ano. Přistupte k objektu [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) a zapište data z `getBinaryData()` na disk. To zachovává původní zakódovaný obrázek uložený v prezentaci, nikoli způsob, jak je obrázek vykreslen na snímku.

**Mohu exportovat každý extrahovaný obrázek jako PNG?**

Ano. Použijte [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) a jeho metodu `getImage()`, a poté zavolejte `save()` s [ImageFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imageformat/) . To převádí výstup a nemusí zachovat původní typ souboru nebo vektorová data.

**Jak zabránit ukládání stejného obrázku vícekrát?**

Použijte hash dat [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) z `getBinaryData()` a uchovávejte hash v množině. Pokud nový obrázek má hash, který již existuje, přeskočte jej nebo zaznamenejte další odkaz na existující výstupní soubor.

**Proč některé tvary nevytvářejí obrázek?**

Rámečky obrázků, tvary s výplní obrázkem, OLE objektové rámečky, mediální rámečky, zoom rámečky, tabulky, grafy a SmartArt objekty mohou odkazovat na obrázky. Některé typy tvarů zpřístupňují obrázky přes vnořené formátovací objekty, takže jednoduchá kontrola `getPictureFormat()` nebo `getFillFormat()` tvaru není vždy dostačující.

**Mohu extrahovat miniaturu zobrazenou pro video rámec?**

Ano. Použijte [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) a přečtěte `getPictureFormat()->getPicture()->getImage()` . To extrahuje plakátový obrázek uložený s video rámcem, nikoli snímek vygenerovaný z video souboru.

**Jak mohu určit, které tvary používají konkrétní obrázek z kolekce obrázků prezentace?**

Aspose.Slides neukládá zpětné odkazy z [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) na tvary. Během procházení vytvořte mapování: kdykoli najdete odkaz na obrázek, zaznamenejte číslo snímku, cestu tvaru a hash obrázku nebo položku kolekce.

**Mohu extrahovat obrázky vložené uvnitř OLE objektů, například připojených dokumentů?**

Můžete extrahovat náhled OLE objektu ze [OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/) . Tento náhled však není samotný vložený dokument. Pro extrahování obrázků zevnitř vloženého souboru musíte extrahovat OLE data a prozkoumat je pomocí nástrojů pro daný typ souboru.