---
title: Estrai immagini dalle forme della presentazione in PHP
linktitle: Immagine da forma
type: docs
weight: 100
url: /it/php-java/extracting-images-from-presentation-shapes/
keywords:
- estrarre immagine
- recuperare immagine
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Estrai immagini dalle forme in presentazioni PowerPoint e OpenDocument con Aspose.Slides per PHP via Java - soluzione rapida e facile da codificare."
---
## **Panoramica**

Le immagini in una presentazione possono apparire in diversi tipi di forma: come normali riquadri immagine, come riempimenti immagine applicati a forme, come anteprime di oggetti OLE, come miniature di fotogrammi video o audio, come immagini di zoom o come immagini annidate all’interno di forme tabella, grafico e SmartArt. Aspose.Slides conserva queste immagini nella collezione di immagini della presentazione, esposta tramite gli oggetti [ImageCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/) e [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/).

Se devi solo esportare tutte le risorse immagine incorporate in una presentazione, itera su `presentation->getImages()`. Questo articolo si concentra su un compito diverso: attraversare le forme per trovare dove le immagini sono usate nelle diapositive, così i file salvati possono mantenere contesto utile come il numero della diapositiva, la posizione della forma e il tipo di origine (riquadro immagine, immagine di riempimento, anteprima multimediale, anteprima OLE o immagine di zoom).

{{% alert title="Tip" color="primary" %}}
Usa [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) e il suo metodo `getBinaryData()` per preservare i dati immagine codificati originali e il tipo di file. Usa `getImage()` quando vuoi normalizzare l’output in un formato specifico come PNG.
{{% /alert %}}

## **Metodi Helper Condivisi**

I metodi helper seguenti mantengono gli esempi brevi. `saveOriginalImage` scrive i byte incorporati originali, sceglie un’estensione sicura dal tipo MIME e salta i binari immagine duplicati mediante hash SHA-256.

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

## **Estrai Immagini da Quadri Immagine**

Usa questo approccio per le immagini inserite come oggetti autonomi. Un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) memorizza la sua immagine in `getPictureFormat()->getPicture()->getImage()`, che restituisce un oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/).

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

## **Estrai Immagini da Forme con Riempimento Immagine**

Le forme possono usare un’immagine come riempimento. Controlla prima il tipo di riempimento della forma: se non è [FillType.Picture](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/), non c’è alcuna immagine da estrarre da quel riempimento. L’esempio sotto gestisce gli oggetti [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) e salva ogni immagine come PNG tramite [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) e il suo metodo `getImage()`.

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

## **Estrai Immagini Anteprima da Quadri Oggetto OLE**

Un [OleObjectFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/oleobjectframe/) può avere un’immagine sostitutiva che PowerPoint usa come anteprima dell’oggetto su una diapositiva. Questa immagine è disponibile tramite `getSubstitutePictureFormat()->getPicture()->getImage()`. Estrarre questa immagine fornisce l’anteprima, non il contenuto del pacchetto OLE incorporato.

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

## **Estrai Immagini Anteprima da Quadri Video**

Un [VideoFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/) può anche memorizzare un’immagine di anteprima in `getPictureFormat()->getPicture()->getImage()`. Questa è la locandina o miniatura mostrata sulla diapositiva, non un fotogramma decodificato dal flusso video.

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

## **Estrai Immagini Anteprima da Quadri Audio**

Un [AudioFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/) può memorizzare una miniatura in `getPictureFormat()->getPicture()->getImage()`. Questa è l’immagine mostrata per l’oggetto audio sulla diapositiva.

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

## **Estrai Immagini da Oggetti Zoom**

Le forme [ZoomFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/zoomframe/) e [SectionZoomFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/sectionzoomframe/) possono utilizzare immagini personalizzate. Leggi `getZoomImage()` dal quadro zoom.

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

## **Estrai Immagini da Quadri Zoom Sommario**

Un [SummaryZoomFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/summaryzoomframe/) è anch’esso una forma. I suoi elementi di sezione possono usare immagini personalizzate, esposte tramite il metodo `getZoomImage()` di ciascuna sezione zoom del sommario.

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

## **Estrai Immagini da Forme Tabella**

Una [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/table/) è una forma. Le immagini in una tabella sono di solito memorizzate come riempimenti immagine nelle celle della tabella.

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

## **Estrai Immagini da Forme Grafico**

Un [Chart](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/) è una forma. L’esempio sotto estrae un’immagine dal riempimento immagine dell’area del grafico.

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

## **Estrai Immagini da Forme SmartArt**

Un oggetto [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/) è una forma. A seconda del layout SmartArt, le immagini possono essere memorizzate nei riempimenti dei punti elenco dei nodi o nei formati di riempimento delle forme dei nodi.

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

## **Includi Immagini All’interno di Forme Raggruppate**

Le forme raggruppate contengono le proprie collezioni di forme. Il helper condiviso `enumerateShapes` ha un’opzione `includeGroupedShapes`. Impostala a `true` quando vuoi ispezionare le forme all’interno di oggetti [GroupShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/groupshape/). L’esempio sotto estrae immagini da quadri immagine, forme con riempimento immagine, anteprime oggetti OLE, miniature di quadri video e miniature di quadri audio. Per includere anche le immagini di tabelle, grafici, SmartArt e zoom sommario, riutilizza la logica di estrazione specializzata delle sezioni precedenti mantenendo la stessa traversata ricorsiva delle forme.

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

## **Casi Limite e Note Pratiche**

- **Immagini duplicate:** più forme possono fare riferimento alla stessa immagine o a immagini separate con byte identici. Esegui l’hash dei dati [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) da `getBinaryData()` prima di scrivere i file se desideri un file di output per ogni immagine unica.
- **Dati originali vs output convertito:** Salvare i dati [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) da `getBinaryData()` preserva i dati JPEG, PNG, GIF, SVG, EMF o WMF incorporati. Salvare l’immagine restituita da `getImage()` è utile quando vuoi un formato di output coerente.
- **Tipi di riempimento non supportati:** Le forme con riempimento solido, sfumato, a trama o senza riempimento non contengono un riempimento immagine. Controlla [FillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) prima di leggere `getPictureFillFormat()`.
- **Forme raggruppate:** La collezione di forme di livello superiore della diapositiva non appiattisce i gruppi. Ispeziona ricorsivamente il contenuto di [GroupShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/groupshape/) tramite `getShapes()` quando il contenuto raggruppato è rilevante.
- **Anteprime oggetti OLE:** Un [OleObjectFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/oleobjectframe/) può esporre un’immagine di anteprima tramite `getSubstitutePictureFormat()`, ma quell’immagine è solo l’anteprima della diapositiva. Non è il file incorporato all’interno dell’oggetto OLE.
- **Miniature quadri video:** Un [VideoFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/) può esporre un’immagine di anteprima tramite `getPictureFormat()`, ma quell’immagine è solo la locandina mostrata sulla diapositiva. Non è estratta dal flusso video.
- **Miniature quadri audio:** Un [AudioFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/) può esporre un’icona o una miniatura tramite `getPictureFormat()`; non è il dato audio incorporato.
- **Immagini zoom:** Le forme di zoom diapositiva, zoom sezione e zoom sommario possono utilizzare oggetti [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) personalizzati tramite `getZoomImage()`.
- **Modelli di forma annidati:** Gli oggetti tabella, grafico e SmartArt implementano [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/), ma le loro immagini sono spesso memorizzate in oggetti di formattazione annidati di celle, elementi del grafico o nodi SmartArt.
- **Immagini ritagliate o trasformate:** Accedere a [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) ti fornisce la risorsa immagine memorizzata. Non rende il ritaglio, la trasparenza, la recolorizzazione, la rotazione o altri effetti visivi applicati dalla forma.

## **FAQ**

**Posso estrarre l’immagine originale senza ritagli, effetti o trasformazioni della forma?**

Sì. Accedi all’oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) e scrivi i dati da `getBinaryData()` su disco. Questo preserva l’immagine codificata originale memorizzata nella presentazione, non il modo in cui l’immagine è resa sulla diapositiva.

**Posso esportare ogni immagine estratta come PNG?**

Sì. Usa [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) e il suo metodo `getImage()`, quindi chiama `save()` con [ImageFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/imageformat/). Questo converte l’output e può non preservare il tipo di file originale o i dati vettoriali.

**Come evito di salvare la stessa immagine più di una volta?**

Usa un hash dei dati [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) ottenuto da `getBinaryData()` e tieni gli hash in un set. Se una nuova immagine ha un hash già presente, salta l’operazione o registra un’altra referenza al file di output esistente.

**Perché alcune forme non producono un’immagine?**

I quadri immagine, le forme con riempimento immagine, i quadri oggetto OLE, i quadri multimediali, i quadri zoom, le tabelle, i grafici e gli oggetti SmartArt possono fare riferimento a immagini. Alcuni tipi di forma espongono immagini tramite oggetti di formattazione annidati, quindi un semplice controllo `getPictureFormat()` o `getFillFormat()` sulla forma non è sempre sufficiente.

**Posso estrarre la miniatura mostrata per un quadro video?**

Sì. Usa [VideoFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/) e leggi `getPictureFormat()->getPicture()->getImage()`. Questo estrae l’immagine di locandina memorizzata con il quadro video, non un fotogramma generato dal file video.

**Come posso determinare quali forme usano una specifica immagine dalla collezione di immagini della presentazione?**

Aspose.Slides non memorizza collegamenti inversi da [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) a forme. Costruisci una mappatura durante la traversata: ogni volta che trovi un riferimento a un’immagine, registra il numero della diapositiva, il percorso della forma e l’hash dell’immagine o l’elemento della collezione.

**Posso estrarre le immagini incorporate all’interno di oggetti OLE, come documenti allegati?**

Puoi estrarre l’anteprima diapositiva dell’oggetto OLE da [OleObjectFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/oleobjectframe/). Tuttavia, quell’anteprima non è il documento incorporato stesso. Per estrarre le immagini da dentro il file incorporato, estrai i dati OLE e ispezionali con gli strumenti appropriati per quel tipo di file.