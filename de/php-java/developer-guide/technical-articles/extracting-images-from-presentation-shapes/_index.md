---
title: Bilder aus Präsentationsformen in PHP extrahieren
linktitle: Bild aus Form
type: docs
weight: 100
url: /de/php-java/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Extrahieren Sie Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP über Java – schnelle, codefreundliche Lösung."
---
## **Übersicht**

Bilder in einer Präsentation können in verschiedenen Formen auftreten: als gewöhnliche Bildrahmen, als Bildfüllungen, die auf Formen angewendet werden, als Vorschau‑Bilder von OLE‑Objekten, als Miniaturansichten von Video‑ oder Audio‑Frames, als Zoom‑Bilder oder als in Tabellen-, Diagramm‑ und SmartArt‑Formen eingebettete Bilder. Aspose.Slides speichert diese Bilder in der Bildsammlung der Präsentation, die über die [ImageCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/) und [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) Objekte bereitgestellt wird.

Wenn Sie nur jede in einer Präsentation eingebettete Bildressource exportieren müssen, iterieren Sie über `presentation->getImages()`. Dieser Artikel konzentriert sich auf eine andere Aufgabe: das Durchlaufen von Formen, um herauszufinden, wo Bilder auf Folien verwendet werden, sodass die gespeicherten Dateien nützlichen Kontext wie Foliennummer, Position der Form und Quelltyp (Bildrahmen, Füllbild, Medienvorschau, OLE‑Vorschau oder Zoom‑Bild) behalten.

{{% alert title="Tip" color="primary" %}}
Verwenden Sie [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) und seine `getBinaryData()`‑Methode, um die ursprünglich codierten Bilddaten und den Dateityp beizubehalten. Verwenden Sie `getImage()`, wenn Sie die Ausgabe in ein bestimmtes Format wie PNG normalisieren möchten.
{{% /alert %}}

## **Gemeinsame Hilfsmethoden**

Die nachfolgenden Hilfsmethoden halten die Beispiele kurz. `saveOriginalImage` schreibt die ursprünglich eingebetteten Bytes, wählt eine sichere Erweiterung aus dem MIME‑Typ und überspringt doppelte Bild‑Binärdaten anhand eines SHA‑256‑Hashes.

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

## **Bilder aus Bildrahmen extrahieren**

Verwenden Sie diesen Ansatz für Bilder, die als eigenständige Objekte eingefügt wurden. Ein [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) speichert sein Bild in `getPictureFormat()->getPicture()->getImage()`, was ein [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) Objekt zurückgibt.

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

## **Bilder aus bildgefüllten Formen extrahieren**

Formen können ein Bild als Füllung verwenden. Prüfen Sie zuerst den Fülltyp der Form: Wenn er nicht [FillType.Picture](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) ist, gibt es kein Bild, das aus dieser Füllung extrahiert werden kann. Das nachstehende Beispiel behandelt [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) Objekte und speichert jedes Bild als PNG über [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) und dessen `getImage()`‑Methode.

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

## **Vorschau‑Bilder aus OLE‑Objekt‑Frames extrahieren**

Ein [OleObjectFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/oleobjectframe/) kann ein Ersatzbild haben, das PowerPoint als Vorschau des Objekts auf einer Folie verwendet. Dieses Bild ist über `getSubstitutePictureFormat()->getPicture()->getImage()` verfügbar. Das Extrahieren dieses Bildes liefert das Vorschau‑Bild, nicht den eingebetteten OLE‑Paketinhalt.

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

## **Vorschau‑Bilder aus Video‑Frames extrahieren**

Ein [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/) kann ebenfalls ein Vorschau‑Bild in `getPictureFormat()->getPicture()->getImage()` speichern. Dies ist das Poster‑ oder Miniaturbild, das auf der Folie angezeigt wird, nicht ein aus dem Videostream dekodierter Frame.

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

## **Vorschau‑Bilder aus Audio‑Frames extrahieren**

Ein [AudioFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/) kann ein Miniaturbild in `getPictureFormat()->getPicture()->getImage()` speichern. Dies ist das Bild, das für das Audio‑Objekt auf der Folie angezeigt wird.

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

## **Bilder aus Zoom‑Objekten extrahieren**

[ZoomFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/zoomframe/) und [SectionZoomFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/sectionzoomframe/) Formen können benutzerdefinierte Bilder verwenden. Lesen Sie `getZoomImage()` vom Zoom‑Frame.

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

## **Bilder aus Summary‑Zoom‑Frames extrahieren**

Ein [SummaryZoomFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/summaryzoomframe/) ist ebenfalls eine Form. Seine Abschnittselemente können benutzerdefinierte Bilder verwenden, die über die `getZoomImage()`‑Methode jedes Summary‑Zoom‑Abschnitts bereitgestellt werden.

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

## **Bilder aus Tabellen‑Formen extrahieren**

Eine [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/table/) ist eine Form. Bilder in einer Tabelle werden normalerweise als Bildfüllungen in Tabellenzellen gespeichert.

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

## **Bilder aus Diagramm‑Formen extrahieren**

Ein [Chart](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/) ist eine Form. Das nachstehende Beispiel extrahiert ein Bild aus der Bildfüllung des Diagrammbereichs.

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

## **Bilder aus SmartArt‑Formen extrahieren**

Ein [SmartArt](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartart/) Objekt ist eine Form. Je nach SmartArt‑Layout können Bilder in den Aufzählungs‑Füllungen der Knoten oder in den Füllformaten der Knotennformen gespeichert sein.

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

## **Bilder in gruppierten Formen einbeziehen**

Gruppierte Formen besitzen eigene Formsammlungen. Der gemeinsam genutzte Hilfs‑methoden‑Helper `enumerateShapes` hat eine Option `includeGroupedShapes`. Setzen Sie sie auf `true`, wenn Sie Formen innerhalb von [GroupShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/groupshape/) Objekten untersuchen möchten. Das nachstehende Beispiel extrahiert Bilder aus Bildrahmen, bildgefüllten Formen, OLE‑Objekt‑Vorschauen, Video‑Frame‑Miniaturansichten und Audio‑Frame‑Miniaturansichten. Um zusätzlich Tabellen-, Diagramm‑, SmartArt‑ und Summary‑Zoom‑Bilder einzubeziehen, verwenden Sie die spezialisierte Extraktionslogik aus den vorherigen Abschnitten und behalten dabei die gleiche rekursive Form‑durchquerung bei.

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

## **Randfälle und praktische Hinweise**

- **Doppelte Bilder:** Mehrere Formen können dasselbe Bild referenzieren oder separate Bilder mit identischen Bytes besitzen. Hashen Sie [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)‑Daten aus `getBinaryData()` bevor Sie Dateien schreiben, wenn Sie eine Ausgabedatei pro einzigartigem Bild wünschen.
- **Originaldaten vs. konvertierte Ausgabe:** Das Speichern von [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)‑Daten aus `getBinaryData()` bewahrt das eingebettete JPEG, PNG, GIF, SVG, EMF oder WMF. Das Speichern des Bildes, das von `getImage()` zurückgegeben wird, ist nützlich, wenn Sie ein konsistentes Ausgabeformat benötigen.
- **Nicht unterstützte Fülltypen:** Solide, Farbverlauf-, Muster‑ und Keine‑Füll‑Formen enthalten keine Bildfüllung. Prüfen Sie [FillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) bevor Sie `getPictureFillFormat()` lesen.
- **Gruppierte Formen:** Die oberste Folien‑Formsammlung flacht Gruppen nicht ab. Durchlaufen Sie rekursiv den Inhalt von [GroupShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/groupshape/) über `getShapes()`, wenn gruppierter Inhalt von Bedeutung ist.
- **OLE‑Objekt‑Vorschauen:** Ein [OleObjectFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/oleobjectframe/) kann ein Vorschau‑Bild über `getSubstitutePictureFormat()` bereitstellen, aber dieses Bild ist nur die Folien‑Vorschau. Es ist nicht die eingebettete Datei im OLE‑Objekt.
- **Video‑Frame‑Miniaturansichten:** Ein [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/) kann ein Vorschau‑Bild über `getPictureFormat()` bereitstellen, aber dieses Bild ist nur das auf der Folie angezeigte Poster. Es wird nicht aus dem Videostream extrahiert.
- **Audio‑Frame‑Miniaturansichten:** Ein [AudioFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/) kann ein Symbol oder Miniaturbild über `getPictureFormat()` bereitstellen; es ist nicht das eingebettete Audiodaten.
- **Zoom‑Bilder:** Slide‑Zoom, Section‑Zoom und Summary‑Zoom‑Formen können benutzerdefinierte [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)‑Objekte über `getZoomImage()` verwenden.
- **Verschachtelte Form‑Modelle:** Tabellen-, Diagramm‑ und SmartArt‑Objekte implementieren [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/), aber ihre Bilder sind häufig in verschachtelten Tabellenzellen‑, Diagrammelement‑ oder SmartArt‑Knoten‑Formatierungsobjekten gespeichert.
- **Zugeschnittene oder transformierte Bilder:** Der Zugriff auf [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) liefert die gespeicherte Bildressource. Es wird nicht das Zuschneiden, die Transparenz, das Umfärben, die Drehung oder andere visuelle Effekte, die von der Form angewendet werden, gerendert.

## **FAQ**

**Kann ich das Originalbild ohne Zuschneiden, Effekte oder Form‑Transformationen extrahieren?**

Ja. Greifen Sie auf das [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)‑Objekt zu und schreiben Sie die Daten aus `getBinaryData()` auf die Festplatte. Damit wird das ursprünglich codierte Bild, das in der Präsentation gespeichert ist, beibehalten und nicht die Art, wie das Bild auf der Folie gerendert wird.

**Kann ich jedes extrahierte Bild als PNG exportieren?**

Ja. Verwenden Sie [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) und seine `getImage()`‑Methode und rufen Sie dann `save()` mit [ImageFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/imageformat/) auf. Damit wird die Ausgabe konvertiert und möglicherweise der ursprüngliche Dateityp oder Vektor‑Daten gehen verloren.

**Wie vermeide ich, dass dasselbe Bild mehrmals gespeichert wird?**

Verwenden Sie einen Hash der [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)‑Daten aus `getBinaryData()` und speichern Sie die Hashes in einer Menge. Wenn ein neues Bild einen bereits existierenden Hash hat, überspringen Sie es oder verzeichnen Sie einen weiteren Verweis auf die bestehende Ausgabedatei.

**Warum erzeugen einige Formen kein Bild?**

Bildrahmen, bildgefüllte Formen, OLE‑Objekt‑Frames, Medien‑Frames, Zoom‑Frames, Tabellen, Diagramme und SmartArt‑Objekte können Bilder referenzieren. Einige Formtypen stellen Bilder über verschachtelte Formatierungsobjekte bereit, sodass ein einfacher `getPictureFormat()`‑ oder `getFillFormat()`‑Check nicht immer ausreicht.

**Kann ich die für einen Video‑Frame angezeigte Miniaturansicht extrahieren?**

Ja. Verwenden Sie [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/) und lesen Sie `getPictureFormat()->getPicture()->getImage()`. Damit wird das Poster‑Bild extrahiert, das mit dem Video‑Frame gespeichert ist, nicht ein Frame, der aus der Videodatei generiert wird.

**Wie kann ich feststellen, welche Formen ein bestimmtes Bild aus der Bildsammlung der Präsentation verwenden?**

Aspose.Slides speichert keine Rückverweise von [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) zu Formen. Erstellen Sie während der Durchquerung ein Mapping: Immer wenn Sie eine Bildreferenz finden, protokollieren Sie die Foliennummer, den Formpfad und den Bild‑Hash oder das Sammlungs‑Element.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?**

Sie können die Vorschau des OLE‑Objekts aus [OleObjectFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/oleobjectframe/) extrahieren. Diese Vorschau ist jedoch nicht das eingebettete Dokument selbst. Um Bilder aus der eingebetteten Datei zu extrahieren, müssen Sie die OLE‑Daten extrahieren und sie mit entsprechenden Werkzeugen für diesen Dateityp untersuchen.