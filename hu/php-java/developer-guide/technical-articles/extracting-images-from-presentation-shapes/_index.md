---
title: Képek kinyerése a bemutató alakzatokból PHP-ben
linktitle: Kép az alakzatról
type: docs
weight: 100
url: /hu/php-java/extracting-images-from-presentation-shapes/
keywords:
- kinyerni a képet
- lekérni a képet
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Képek kinyerése alakzatokból PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java segítségével – gyors, kódbarát megoldás."
---
## **Áttekintés**

A prezentációban lévő képek többféle alakzattípusban jelenhetnek meg: egyszerű képkockaként, alakzatokra alkalmazott képpel töltött kitöltésként, OLE‑objektum előnézeti képként, videó‑ vagy hangkeret bélyegképeként, nagyítási képként, vagy táblázat, diagram és SmartArt alakzatokba ágyazott képekként. Az Aspose.Slides ezeket a képeket a prezentáció képgyűjteményében tárolja, amely a [ImageCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) és a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumokon keresztül érhető el.

Ha csak a prezentációba beágyazott összes képernyőforrást szeretné exportálni, iteráljon a `presentation->getImages()`‑en. Ez a cikk egy másik feladatra összpontosít: az alakzatok bejárására, hogy megtalálja, hol használják a képeket a diákon, így a mentett fájlok megőrizhetik a hasznos kontextust, például a dia számát, az alakzat pozícióját és a forrástípust (képkocka, kitöltő kép, médiaelőnézet, OLE‑előnézet vagy nagyítási kép).

{{% alert title="Tip" color="primary" %}}
Használja a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) és annak `getBinaryData()` metódusát az eredeti kódolt képadatok és fájltípus megőrzéséhez. Használja a `getImage()`‑t, ha a kimenetet egy meghatározott formátumra, például PNG‑re szeretné normalizálni.
{{% /alert %}}

## **Közös Segédmetódusok**

A lenti segédmetódusok röviden tartják a példákat. A `saveOriginalImage` az eredeti beágyazott bájtokat írja, a MIME‑típusból biztonságos kiterjesztést választ, és az SHA‑256 hash alapján kihagyja a duplikált képbiteket.

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

## **Képek kinyerése képkockákból**

Ezt a megközelítést önálló objektumként beszúrt képekhez használja. A [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) a képet a `getPictureFormat()->getPicture()->getImage()` metódusban tárolja, amely egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot ad vissza.

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

## **Képpel kitöltött alakzatokból képek kinyerése**

Az alakzatok képet használhatnak kitöltésként. Először ellenőrizze az alakzat kitöltés típusát: ha nem [FillType.Picture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/), akkor nincs kitöltő kép, amit ki lehetne nyerni. Az alábbi példa a [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) objektumokat kezeli, és minden képet PNG‑ként ment a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) és annak `getImage()` metódusa segítségével.

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

## **Előnézeti képek kinyerése OLE‑objektum keretekből**

Egy [OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) helyettesítő képpel rendelkezhet, amelyet a PowerPoint az objektum előnézeteként használ a dián. Ez a kép a `getSubstitutePictureFormat()->getPicture()->getImage()` útján érhető el. Ennek a képnek a kinyerése az előnézeti képet adja, nem a beágyazott OLE‑csomag tartalmát.

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

## **Előnézeti képek kinyerése videókeretekből**

Egy [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) szintén tárolhat előnézeti képet a `getPictureFormat()->getPicture()->getImage()` metódusban. Ez a diához megjelenő poszter vagy bélyegkép, nem egy a videófolyamból dekódolt keret.

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

## **Előnézeti képek kinyerése hangkeretekből**

Egy [AudioFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/) tárolhat egy bélyegképet a `getPictureFormat()->getPicture()->getImage()` metódusban. Ez a hangobjektushoz a diához megjelenő kép.

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

## **Képek kinyerése zoomobjektumokból**

A [ZoomFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zoomframe/) és a [SectionZoomFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sectionzoomframe/) alakzatok egyedi képeket használhatnak. Olvassa a `getZoomImage()`‑t a zoomkeretből.

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

## **Képek kinyerése összegző zoom keretekből**

A [SummaryZoomFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/summaryzoomframe/) szintén egy alakzat. A szekcióelemei egyedi képeket használhatnak, amelyeket az egyes összegző zoom szakaszok `getZoomImage()` metódusa ad vissza.

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

## **Képek kinyerése táblázat alakzatokból**

Egy [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/table/) egy alakzat. A táblázatban lévő képek általában képtöltésként vannak tárolva a táblázat celláiban.

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

## **Képek kinyerése diagram alakzatokból**

Egy [Chart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/) egy alakzat. Az alábbi példa a diagramterület képkitöltéséből nyer ki egy képet.

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

## **Képek kinyerése SmartArt alakzatokból**

Egy [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) objektum alakzat. A SmartArt elrendezésétől függően a képek tárolhatók a csomópontok felsorolás kitöltéseiben vagy a csomópont alakzatok kitöltési formátumaiban.

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

## **Képek beillesztése csoportosított alakzatokba**

A csoportosított alakzatok saját alakzategyüttesekkel rendelkeznek. A megosztott `enumerateShapes` segédnek van egy `includeGroupedShapes` beállítása. Állítsa `true`‑ra, ha a [GroupShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/groupshape/) objektumok belsejében lévő alakzatokat is meg szeretné vizsgálni. Az alábbi példa képeket nyer ki képkockákból, képpel kitöltött alakzatokból, OLE‑objektum előnézetekből, videókeret bélyegképekből és hangkeret bélyegképekből. A táblázat, diagram, SmartArt és összegző zoom képek beillesztéséhez használja újra a korábbi szakaszok speciális kinyerési logikáját, miközben ugyanazt a rekurzív alakzat bejárást alkalmazza.

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

## **Különleges esetek és gyakorlati megjegyzések**

- **Duplikált képek:** Több alakzat hivatkozhat ugyanarra a képre vagy különálló képekre, amelyek azonos bájtokkal rendelkeznek. Hash‑elje a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) adatot a `getBinaryData()`‑ból a fájlok írása előtt, ha egy kimeneti fájlt szeretne minden egyedi képhez.
- **Eredeti adatok vs. konvertált kimenet:** A [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) adatának a `getBinaryData()`‑ból történő mentése megőrzi a beágyazott JPEG, PNG, GIF, SVG, EMF vagy WMF adatot. A `getImage()` által visszaadott kép mentése akkor hasznos, ha egységes kimeneti formátumra, például PNG‑re van szükség.
- **Nem támogatott kitöltéstípusok:** Szilárd, gradient, minta és nincs kitöltés alakzatok nem tartalmaznak képtöltést. Ellenőrizze a [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/)‑t a `getPictureFillFormat()` olvasása előtt.
- **Csoportosított alakzatok:** A felső szintű diá alakzategyűttes nem laposítja a csoportokat. Rekurzívan vizsgálja meg a [GroupShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/groupshape/) tartalmat a `getShapes()`‑on keresztül, ha a csoportosított tartalom fontos.
- **OLE‑objektum előnézetek:** Egy [OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) egy előnézeti képet adhat meg a `getSubstitutePictureFormat()`‑on keresztül, de ez a kép csak a dia előnézete. Nem a beágyazott fájl az OLE‑objektumban.
- **Videókeret bélyegképek:** Egy [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) egy előnézeti képet adhat a `getPictureFormat()`‑on keresztül, de ez a kép csak a diához tartozó poszter. Nem a videófolyamból származik.
- **Hangkeret bélyegképek:** Egy [AudioFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/) egy ikont vagy bélyegképet adhat a `getPictureFormat()`‑on keresztül; ez nem a beágyazott hangadat.
- **Zoom képek:** Dia zoom, szekció zoom és összegző zoom alakzatok egyedi [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumokat használhatnak a `getZoomImage()`‑on keresztül.
- **Beágyazott alakzati modellek:** A táblázat, diagram és SmartArt objektumok a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) implementálják, de képeik gyakran beágyazott táblacella, diagramelem vagy SmartArt csomópont formázási objektumban vannak tárolva.
- **Vágott vagy átalakított képek:** A [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) elérése a tárolt képadatot adja. Nem jeleníti meg a vágást, átlátszóságot, újraszínezést, forgatást vagy egyéb vizuális hatásokat, amelyeket az alakzat alkalmaz.

## **GYIK**

**Kinyerhetem az eredeti képet vágás, effektus vagy alakzatformálás nélkül?**

Igen. Hozzáfér a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumhoz, és a `getBinaryData()` adatot lemezre írja. Ez megőrzi a prezentációban tárolt eredeti kódolt képet, nem pedig a dián megjelenő renderelt változatot.

**Exportálhatom minden kinyert képet PNG‑ként?**

Igen. Használja a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) és annak `getImage()` metódusát, majd hívja meg a `save()`‑t a [ImageFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imageformat/) segítségével. Ez konvertálja a kimenetet, és előfordulhat, hogy nem őrzi meg az eredeti fájltípust vagy vektoradatokat.

**Hogyan kerülhetem el, hogy ugyanazt a képet többször mentsem?**

Használjon hash‑et a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) adatból a `getBinaryData()`‑ból, és tárolja a hash‑eket egy halmazban. Ha egy új kép hash‑e már létezik, hagyja ki, vagy rögzítsen egy másik hivatkozást a meglévő kimeneti fájlra.

**Miért nem ad ki képet néhány alakzat?**

A képkockák, képpel kitöltött alakzatok, OLE‑objektum keretek, média keretek, zoom keretek, táblázatok, diagramok és SmartArt objektumok hivatkozhatnak képekre. Néhány alakzattípus beágyazott formázási objektumokon keresztül teszi elérhetővé a képeket, ezért egy egyszerű `getPictureFormat()` vagy alakzat `getFillFormat()` ellenőrzés nem mindig elegendő.

**Kinyerhetem a videókerethez tartozó bélyegképet?**

Igen. Használja a [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektumot, és olvassa a `getPictureFormat()->getPicture()->getImage()`‑t. Ez kinyeri a videókerethez tárolt posztert, nem egy a videófájlból generált keretet.

**Hogyan határozhatom meg, mely alakzatok használnak egy adott képet a prezentáció képgyűjteményéből?**

Az Aspose.Slides nem tárol visszacsatolási hivatkozásokat a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/)‑től az alakzatok felé. A bejárás során építsen fel egy leképezést: ha képhivatkozást talál, rögzítse a dia számát, az alakzat útvonalát, valamint a kép hash‑ét vagy a gyűjtemény elemét.

**Kinyerhetek beágyazott képeket OLE‑objektumokból, például csatolt dokumentumokból?**

Kinyerheti az OLE‑objektum diáprezentációs előnézetét a [OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) segítségével. Azonban ez az előnézet nem maga a beágyazott dokumentum. A beágyazott fájlon belüli képek kinyeréséhez először az OLE‑adatokat kell kinyerni, majd a megfelelő eszközökkel elemezni a fájl típusát.