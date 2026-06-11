---
title: Extrahera bilder från presentationsformer i PHP
linktitle: Bild från form
type: docs
weight: 100
url: /sv/php-java/extracting-images-from-presentation-shapes/
keywords:
- extrahera bild
- hämta bild
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Extrahera bilder från former i PowerPoint och OpenDocument presentationer med Aspose.Slides för PHP via Java - snabb, kodvänlig lösning."
---
## **Översikt**

Bilder i en presentation kan visas i flera formtyper: som vanliga bildramar, som bildfyllningar som appliceras på former, som förhandsgranskningsbilder för OLE‑objekt, som miniatyrer för video‑ eller ljudramar, som zoom‑bilder eller som bilder inbäddade i tabell‑, diagram‑ och SmartArt‑former. Aspose.Slides lagrar dessa bilder i presentationens bildsamling, som exponeras via [ImageCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/) och [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objekt.

Om du bara behöver exportera varje bildresurs som är inbäddad i en presentation, iterera genom `presentation->getImages()`. Denna artikel fokuserar på en annan uppgift: att gå igenom former för att hitta var bilder används på bilderna, så att de sparade filerna kan behålla användbar kontext såsom bildnummer, formposition och källtyp (bildram, fyllningsbild, media‑förhandsgranskning, OLE‑förhandsgranskning eller zoom‑bild).

{{% alert title="Tip" color="primary" %}}Använd [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) och dess `getBinaryData()`‑metod för att bevara den ursprungliga kodade bilddatan och filtypen. Använd `getImage()` när du vill normalisera utdata till ett specifikt format, till exempel PNG.{{% /alert %}}

## **Gemensamma hjälpfunktioner**

Hjälpfunktionerna nedan håller exemplen korta. `saveOriginalImage` skriver de ursprungliga inbäddade bytesen, väljer en säker filändelse från MIME‑typen och hoppar över dubbletter av bildbinärer genom SHA‑256‑hash.

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

## **Extrahera bilder från bildramar**

Använd detta tillvägagångssätt för bilder som har infogats som fristående objekt. En [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) lagrar sin bild i `getPictureFormat()->getPicture()->getImage()`, vilket returnerar ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objekt.

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

## **Extrahera bilder från bildfyllda former**

Former kan använda en bild som fyllning. Kontrollera först formens fyllningstyp: om den inte är [FillType.Picture](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/), finns det ingen bild att extrahera från den fyllningen. Exemplet nedan hanterar [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/)-objekt och sparar varje bild som PNG via [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) och dess `getImage()`‑metod.

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

## **Extrahera förhandsgranskningsbilder från OLE‑objektramar**

En [OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/) kan ha en ersättningsbild som PowerPoint använder som objektets förhandsgranskning på en bild. Denna bild är tillgänglig via `getSubstitutePictureFormat()->getPicture()->getImage()`. Att extrahera denna bild ger dig förhandsgranskningsbilden, inte innehållet i det inbäddade OLE‑paketet.

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

## **Extrahera förhandsgranskningsbilder från videoramar**

En [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) kan också lagra en förhandsgranskningsbild i `getPictureFormat()->getPicture()->getImage()`. Detta är affischen eller miniatyren som visas på bilden, inte en ram avkodad från videoströmmen.

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

## **Extrahera förhandsgranskningsbilder från ljudramar**

En [AudioFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/) kan lagra en miniatyr i `getPictureFormat()->getPicture()->getImage()`. Detta är bilden som visas för ljudobjektet på bilden.

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

## **Extrahera bilder från zoom‑objekt**

[ZoomFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zoomframe/) och [SectionZoomFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sectionzoomframe/)‑former kan använda anpassade bilder. Läs `getZoomImage()` från zoom‑ramen.

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

## **Extrahera bilder från sammanfattnings‑zoom‑ramar**

En [SummaryZoomFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/summaryzoomframe/) är också en form. Dess sektionsobjekt kan använda anpassade bilder, som exponeras via varje sammanfattnings‑zoom‑sektionens `getZoomImage()`‑metod.

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

## **Extrahera bilder från tabellformer**

Ett [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/table/) är en form. Bilder i en tabell lagras vanligtvis som bildfyllningar i tabellceller.

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

## **Extrahera bilder från diagramformer**

Ett [Chart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/) är en form. Exemplet nedan extraherar en bild från diagrammets område‑fyllning.

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

## **Extrahera bilder från SmartArt‑former**

Ett [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartart/)-objekt är en form. Beroende på SmartArt‑layout kan bilder lagras i nod‑punktsfyllningar eller i fyllningsformaten för nodformer.

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

## **Inkludera bilder i grupperade former**

Grupperade former innehåller sina egna form‑samlingar. Den gemensamma hjälpfunktionen `enumerateShapes` har ett alternativ `includeGroupedShapes`. Sätt det till `true` när du vill inspektera former inuti [GroupShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/groupshape/)-objekt. Exemplet nedan extraherar bilder från bildramar, bildfyllda former, OLE‑objekt‑förhandsgranskningar, videominibilder och ljudminiatyrer. För att också inkludera tabell-, diagram‑, SmartArt‑ och sammanfattnings‑zoom‑bilder, återanvänd den specialiserade extraktionslogiken från de föregående avsnitten medan du behåller samma rekursiva form‑traversering.

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

## **Särskilda fall och praktiska anteckningar**

- **Dubblettbilder:** Flera former kan referera till samma bild eller separata bilder med identiska bytes. Hasha [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-data från `getBinaryData()` innan du skriver filer om du vill ha en utdatafil per unik bild.
- **Ursprunglig data vs. konverterad utdata:** Att spara [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-data från `getBinaryData()` bevarar den inbäddade JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ eller WMF‑datan. Att spara bilden som returneras av `getImage()` är användbart när du vill ha ett enhetligt utformat format.
- **Ej stödda fyllningstyper:** Solid, gradient, pattern och ingen‑fyllning‑former innehåller ingen bildfyllning. Kontrollera [FillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/) innan du läser `getPictureFillFormat()`.
- **Grupperade former:** Den översta bild‑form‑samlingen plattar inte till grupper. Inspektera rekursivt [GroupShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/groupshape/)-innehållet via `getShapes()` när grupperat innehåll är relevant.
- **OLE‑objekt‑förhandsgranskningar:** En [OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/) kan exponera en förhandsgranskningsbild via `getSubstitutePictureFormat()`, men den bilden är endast bildens förhandsgranskning. Den är inte den inbäddade filen i OLE‑objektet.
- **Videominibilder:** En [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) kan exponera en förhandsgranskningsbild via `getPictureFormat()`, men den bilden är endast affischen som visas på bilden. Den extraheras inte från videoströmmen.
- **Ljudminiatyrer:** En [AudioFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/) kan exponera en ikon eller miniatyr via `getPictureFormat()`; den är inte den inbäddade ljuddatan.
- **Zoom‑bilder:** Bild‑zoom‑, sektion‑zoom‑ och sammanfattnings‑zoom‑former kan använda anpassade [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objekt via `getZoomImage()`.
- **Nästlade formmodeller:** Tabell-, diagram‑ och SmartArt‑objekt implementerar [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/), men deras bilder lagras ofta i nästlade tabellcell‑, diagram‑ eller SmartArt‑nodformat‑objekt.
- **Beskurna eller transformerade bilder:** Att åtkomma [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) ger dig den lagrade bildresursen. Det renderar inte beskärning, transparens, omfärgning, rotation eller andra visuella effekter som appliceras av formen.

## **Vanliga frågor**

**Kan jag extrahera den ursprungliga bilden utan beskärning, effekter eller formtransformeringar?**

Ja. Åtkomst [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objektet och skriv data från `getBinaryData()` till disk. Detta bevarar den ursprungligt kodade bilden som lagras i presentationen, inte hur bilden renderas på bilden.

**Kan jag exportera varje extraherad bild som PNG?**

Ja. Använd [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) och dess `getImage()`‑metod, och anropa sedan `save()` med [ImageFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imageformat/). Detta konverterar utdata och kan leda till att den ursprungliga filtypen eller vektordata inte bevaras.

**Hur undviker jag att spara samma bild mer än en gång?**

Använd en hash av [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-data från `getBinaryData()` och håll hasharna i en uppsättning. Om en ny bild har en hash som redan finns, hoppa över den eller registrera en annan referens till den befintliga utdatafilen.

**Varför producerar vissa former ingen bild?**

Bildramar, bildfyllda former, OLE‑objektramar, media‑ramar, zoom‑ramar, tabeller, diagram och SmartArt‑objekt kan referera till bilder. Vissa formtyper exponerar bilder via nästlade formateringsobjekt, så en enkel kontroll av `getPictureFormat()` eller `getFillFormat()` är inte alltid tillräcklig.

**Kan jag extrahera miniatyren som visas för en videoram?**

Ja. Använd [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) och läs `getPictureFormat()->getPicture()->getImage()`. Detta extraherar affisch‑bilden som lagras med videoramen, inte en ram genererad från videofilen.

**Hur kan jag avgöra vilka former som använder en specifik bild från presentationens bildsamling?**

Aspose.Slides lagrar inte omvända länkar från [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) till former. Bygg en karta under traverseringen: när du hittar en bildreferens, registrera bildnumret, formens sökväg och bildens hash eller samlings‑item.

**Kan jag extrahera bilder som är inbäddade i OLE‑objekt, till exempel bifogade dokument?**

Du kan extrahera OLE‑objektets bild‑förhandsgranskning från [OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/). Den förhandsgranskningen är dock inte det inbäddade dokumentet i sig. För att extrahera bilder från den inbäddade filen, extrahera OLE‑datan och inspektera den med verktyg för den filtypen.