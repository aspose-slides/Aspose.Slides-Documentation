---
title: Afbeeldingen extraheren uit presentatievormen in PHP
linktitle: Afbeelding uit Vorm
type: docs
weight: 100
url: /nl/php-java/extracting-images-from-presentation-shapes/
keywords:
- afbeelding extraheren
- afbeelding ophalen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Afbeeldingen extraheren uit vormen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP via Java - snelle, codevriendelijke oplossing."
---
## **Overzicht**

Afbeeldingen in een presentatie kunnen in verschillende vormtypen voorkomen: als gewone afbeeldingskaders, als afbeeldingsvullingen toegepast op vormen, als voorbeeldafbeeldingen van OLE‑objecten, als miniaturen van video‑ of audio‑kaders, als zoom‑afbeeldingen, of als afbeeldingen genesteld in tabel‑, grafiek‑ en SmartArt‑vormen. Aspose.Slides slaat die afbeeldingen op in de afbeeldingsverzameling van de presentatie, toegankelijk via [ImageCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/) en [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) objecten.

Als je alleen alle ingevoegde afbeeldingsbronnen in een presentatie wilt exporteren, doorloop je `presentation->getImages()`. Dit artikel richt zich op een andere taak: vormen doorlopen om te vinden waar afbeeldingen op dia’s worden gebruikt, zodat de opgeslagen bestanden nuttige context kunnen behouden, zoals het diapnummer, de positie van de vorm en het bron‑type (afbeeldingskader, vullingsafbeelding, mediavoorbeeld, OLE‑voorbeeld of zoom‑afbeelding).

{{% alert title="Tip" color="primary" %}}
Gebruik [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) en de methode `getBinaryData()` om de oorspronkelijke gecodeerde afbeeldingsgegevens en bestandstypen te behouden. Gebruik `getImage()` wanneer je de uitvoer wilt normaliseren naar een specifiek formaat zoals PNG.
{{% /alert %}}

## **Gedeelde hulpmethoden**

De onderstaande hulpmethoden houden de voorbeelden kort. `saveOriginalImage` schrijft de originele ingesloten bytes, kiest een veilige extensie op basis van het MIME‑type en slaat dubbele afbeeldingsbinaire bestanden over met een SHA‑256‑hash.

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

## **Afbeeldingen extraheren uit afbeeldingskaders**

Gebruik deze benadering voor afbeeldingen die als zelfstandige objecten zijn ingevoegd. Een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) slaat zijn afbeelding op in `getPictureFormat()->getPicture()->getImage()`, wat een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) object retourneert.

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

## **Afbeeldingen extraheren uit met afbeelding gevulde vormen**

Vormen kunnen een afbeelding als vulling gebruiken. Controleer eerst het vultype van de vorm: als het niet [FillType.Picture](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) is, is er geen afbeelding om uit die vulling te halen. Het onderstaande voorbeeld behandelt [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) objecten en slaat elke afbeelding op als PNG via [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) en de methode `getImage()`.

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

## **Voorbeeldafbeeldingen extraheren uit OLE‑objectkaders**

Een [OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/) kan een vervangende afbeelding hebben die PowerPoint gebruikt als voorbeeld van het object op een dia. Deze afbeelding is beschikbaar via `getSubstitutePictureFormat()->getPicture()->getImage()`. Het extraheren van deze afbeelding geeft je de voorbeeldafbeelding, niet de inhoud van het ingevoegde OLE‑pakket.

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

## **Voorbeeldafbeeldingen extraheren uit video‑kaders**

Een [VideoFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/) kan ook een voorbeeldafbeelding opslaan in `getPictureFormat()->getPicture()->getImage()`. Dit is de poster of miniatuur die op de dia wordt getoond, niet een frame dat uit de videostream is gedecodeerd.

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

## **Voorbeeldafbeeldingen extraheren uit audio‑kaders**

Een [AudioFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/) kan een miniatuur opslaan in `getPictureFormat()->getPicture()->getImage()`. Dit is de afbeelding die wordt getoond voor het audio‑object op de dia.

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

## **Afbeeldingen extraheren uit zoom‑objecten**

[ZoomFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zoomframe/) en [SectionZoomFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sectionzoomframe/) vormen kunnen aangepaste afbeeldingen gebruiken. Lees `getZoomImage()` van het zoom‑frame.

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

## **Afbeeldingen extraheren uit samenvattende zoomkaders**

Een [SummaryZoomFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/summaryzoomframe/) is ook een vorm. De sectie‑items kunnen aangepaste afbeeldingen gebruiken, toegankelijk via de `getZoomImage()`‑methode van elke samenvattende zoom‑sectie.

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

## **Afbeeldingen extraheren uit tabel‑vormen**

Een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/) is een vorm. Afbeeldingen in een tabel worden meestal opgeslagen als afbeeldingsvullingen in tabelcellen.

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

## **Afbeeldingen extraheren uit grafiek‑vormen**

Een [Chart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/) is een vorm. Het onderstaande voorbeeld haalt een afbeelding uit de afbeeldingsvulling van het grafiekgebied.

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

## **Afbeeldingen extraheren uit SmartArt‑vormen**

Een [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/) object is een vorm. Afhankelijk van de SmartArt‑lay-out kunnen afbeeldingen worden opgeslagen in de vulvullingen van knooppunt‑bolletjes of in de vulformaten van knooppunt‑vormen.

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

## **Afbeeldingen opnemen in gegroepeerde vormen**

Gegroepeerde vormen bevatten hun eigen vormverzamelingen. De gedeelde `enumerateShapes`‑helper heeft een `includeGroupedShapes`‑optie. Stel deze in op `true` wanneer je vormen binnen [GroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/groupshape/) objecten wilt inspecteren. Het onderstaande voorbeeld haalt afbeeldingen uit afbeeldingskaders, met afbeelding gevulde vormen, OLE‑objectvoorbeelden, video‑kader‑miniaturen en audio‑kader‑miniaturen. Om ook tabel‑, grafiek‑, SmartArt‑ en samenvattende zoom‑afbeeldingen op te nemen, hergebruik je de gespecialiseerde extractielogica uit de voorgaande secties terwijl je dezelfde recursieve vormtraversie behoudt.

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

## **Randgevallen en praktische opmerkingen**

- **Dupliceerde afbeeldingen:** Meerdere vormen kunnen verwijzen naar dezelfde afbeelding of naar verschillende afbeeldingen met identieke bytes. Hash [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) data van `getBinaryData()` voordat je bestanden schrijft als je één uitvoerbestand per unieke afbeelding wilt.
- **Originele data vs. geconverteerde uitvoer:** Het opslaan van [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) data via `getBinaryData()` behoudt de ingebedde JPEG, PNG, GIF, SVG, EMF of WMF data. Het opslaan van de afbeelding die wordt geretourneerd door `getImage()` is handig wanneer je een consistent uitvoerformaat wilt.
- **Niet‑ondersteunde vultypen:** Vaste, verloop-, patroon‑ en geen‑vullingen bevatten geen afbeeldingsvulling. Controleer [FillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) voordat je `getPictureFillFormat()` leest.
- **Gegroepeerde vormen:** De bovenliggende dia‑vormverzameling flatten‑t groepen niet. Inspecteer recursief de inhoud van [GroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/groupshape/) via `getShapes()` wanneer gegroepeerde inhoud van belang is.
- **OLE‑objectvoorbeelden:** Een [OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/) kan een voorbeeldafbeelding blootleggen via `getSubstitutePictureFormat()`, maar die afbeelding is enkel het dia‑voorbeeld. Het is niet het ingevoegde bestand binnen het OLE‑object.
- **Video‑kader‑miniaturen:** Een [VideoFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/) kan een voorbeeldafbeelding blootleggen via `getPictureFormat()`, maar die afbeelding is enkel de poster die op de dia wordt getoond. Het wordt niet uit de videostream gehaald.
- **Audio‑kader‑miniaturen:** Een [AudioFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/) kan een pictogram of miniatuur blootleggen via `getPictureFormat()`; het is niet de ingebedde audiogegevens.
- **Zoom‑afbeeldingen:** Slide‑zoom, sectie‑zoom en samenvattende zoom‑vormen kunnen aangepaste [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) objecten gebruiken via `getZoomImage()`.
- **Geneste vormmodellen:** Tabel‑, grafiek‑ en SmartArt‑objecten implementeren [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/), maar hun afbeeldingen worden vaak opgeslagen in geneste tabelcellen, grafiekelementen of SmartArt‑knooppunt‑opmaakobjecten.
- **Bijsneden of getransformeerde afbeeldingen:** Toegang tot [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) geeft je de opgeslagen afbeeldingsresource. Het rendert geen bijsnijden, transparantie, herkleuring, rotatie of andere visuele effecten die op de vorm zijn toegepast.

## **Veelgestelde vragen**

**Kan ik de originele afbeelding extraheren zonder bijsnijden, effecten of vormtransformaties?**

Ja. Toegang tot het [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) object en schrijf de data van `getBinaryData()` naar schijf. Dit behoudt de originele gecodeerde afbeelding die in de presentatie is opgeslagen, niet de weergave van de afbeelding op de dia.

**Kan ik elke geëxtraheerde afbeelding als PNG exporteren?**

Ja. Gebruik [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) en de methode `getImage()`, en roep vervolgens `save()` aan met [ImageFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imageformat/). Dit converteert de uitvoer en behoudt mogelijk niet het originele bestandstype of vector data.

**Hoe voorkom ik dat dezelfde afbeelding meerdere keren wordt opgeslagen?**

Gebruik een hash van de [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) data uit `getBinaryData()` en bewaar de hashes in een set. Als een nieuwe afbeelding een hash heeft die al bestaat, sla die dan over of registreer een extra verwijzing naar het bestaande uitvoerbestand.

**Waarom leveren sommige vormen geen afbeelding?**

Afbeeldingskaders, met afbeelding gevulde vormen, OLE‑objectkaders, mediakaders, zoom‑kaders, tabellen, grafieken en SmartArt‑objecten kunnen afbeeldingen refereren. Sommige vormtypen exposeren afbeeldingen via geneste opmaakobjecten, dus een simpele controle op `getPictureFormat()` of `getFillFormat()` van de vorm is niet altijd voldoende.

**Kan ik de miniatuur die wordt getoond voor een video‑frame extraheren?**

Ja. Gebruik [VideoFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/) en lees `getPictureFormat()->getPicture()->getImage()`. Dit haalt de poster‑afbeelding op die met het video‑frame is opgeslagen, niet een frame dat is gegenereerd uit het videobestand.

**Hoe kan ik bepalen welke vormen een specifieke afbeelding uit de afbeeldingsverzameling van de presentatie gebruiken?**

Aspose.Slides slaat geen terugkoppeling op van [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) naar vormen. Bouw een mapping op tijdens de traversie: wanneer je een afbeelding‑referentie vindt, noteer je het diapnummer, het vormpad en de afbeelding‑hash of collectie‑item.

**Kan ik afbeeldingen extraheren die zijn ingebed in OLE‑objecten, zoals bijgevoegde documenten?**

Je kunt het dia‑voorbeeld van het OLE‑object extraheren via [OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/). Dat voorbeeld is echter niet het ingebedde document zelf. Om afbeeldingen uit het ingebedde bestand te halen, moet je de OLE‑data extraheren en deze inspecteren met tools die geschikt zijn voor dat bestandstype.