---
title: Extrair Imagens de Formas de Apresentação em PHP
linktitle: Imagem de Forma
type: docs
weight: 100
url: /pt/php-java/extracting-images-from-presentation-shapes/
keywords:
- extrair imagem
- recuperar imagem
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Extrair imagens de formas em apresentações PowerPoint e OpenDocument com Aspose.Slides para PHP via Java - solução rápida e amigável ao código."
---
## **Visão geral**

Imagens em uma apresentação podem aparecer em vários tipos de forma: como quadros de imagem ordinários, como preenchimentos de imagem aplicados a formas, como imagens de visualização de objetos OLE, como miniaturas de quadros de vídeo ou áudio, como imagens de zoom ou como imagens aninhadas dentro de formas de tabela, gráfico e SmartArt. Aspose.Slides armazena essas imagens na coleção de imagens da apresentação, exposta através dos objetos [ImageCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagecollection/) e [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/).

Se você só precisa exportar todos os recursos de imagem incorporados em uma apresentação, iterar por `presentation->getImages()`. Este artigo foca em uma tarefa diferente: percorrer formas para encontrar onde as imagens são usadas nos slides, para que os arquivos salvos possam manter contexto útil, como número do slide, posição da forma e tipo de origem (quadro de imagem, imagem de preenchimento, pré‑visualização de mídia, pré‑visualização OLE ou imagem de zoom).

{{% alert title="Dica" color="primary" %}}

Use [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) e seu método `getBinaryData()` para preservar os dados de imagem codificados originais e o tipo de arquivo. Use `getImage()` quando quiser normalizar a saída para um formato específico, como PNG.

{{% /alert %}}

## **Métodos auxiliares compartilhados**

Os métodos auxiliares abaixo mantêm os exemplos curtos. `saveOriginalImage` grava os bytes incorporados originais, escolhe uma extensão segura a partir do tipo MIME e ignora binários de imagem duplicados por hash SHA‑256.

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

## **Extrair imagens de quadros de imagem**

Use esta abordagem para imagens inseridas como objetos autônomos. Um [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/) armazena sua imagem em `getPictureFormat()->getPicture()->getImage()`, que devolve um objeto [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/).

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

## **Extrair imagens de formas preenchidas com imagem**

Formas podem usar uma imagem como preenchimento. Verifique primeiro o tipo de preenchimento da forma: se não for [FillType.Picture](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/), não há imagem para extrair desse preenchimento. O exemplo abaixo trata objetos [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) e salva cada imagem como PNG através de [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) e seu método `getImage()`.

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

## **Extrair imagens de pré‑visualização de quadros de objeto OLE**

Um [OleObjectFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/oleobjectframe/) pode ter uma imagem substituta que o PowerPoint usa como pré‑visualização do objeto no slide. Essa imagem está disponível por meio de `getSubstitutePictureFormat()->getPicture()->getImage()`. Extrair essa imagem fornece a pré‑visualização, não o conteúdo do pacote OLE incorporado.

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

## **Extrair imagens de pré‑visualização de quadros de vídeo**

Um [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/) também pode armazenar uma imagem de pré‑visualização em `getPictureFormat()->getPicture()->getImage()`. Esta é o pôster ou miniatura exibida no slide, não um quadro decodificado do fluxo de vídeo.

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

## **Extrair imagens de pré‑visualização de quadros de áudio**

Um [AudioFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/) pode armazenar uma miniatura em `getPictureFormat()->getPicture()->getImage()`. Esta é a imagem mostrada para o objeto de áudio no slide.

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

## **Extrair imagens de objetos de zoom**

Formas [ZoomFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/zoomframe/) e [SectionZoomFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sectionzoomframe/) podem usar imagens personalizadas. Leia `getZoomImage()` do quadro de zoom.

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

## **Extrair imagens de quadros de zoom resumido**

Um [SummaryZoomFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/summaryzoomframe/) também é uma forma. Seus itens de seção podem usar imagens personalizadas, expostas através do método `getZoomImage()` de cada seção de zoom resumido.

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

## **Extrair imagens de formas de tabela**

Uma [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/table/) é uma forma. Imagens em uma tabela geralmente são armazenadas como preenchimentos de imagem nas células da tabela.

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

## **Extrair imagens de formas de gráfico**

Um [Chart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/) é uma forma. O exemplo abaixo extrai uma imagem do preenchimento de imagem da área do gráfico.

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

## **Extrair imagens de formas SmartArt**

Um objeto [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/) é uma forma. Dependendo do layout do SmartArt, as imagens podem estar armazenadas nos preenchimentos de marcadores de nós ou nos formatos de preenchimento das formas dos nós.

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

## **Incluir imagens dentro de formas agrupadas**

Formas agrupadas contêm suas próprias coleções de formas. O auxiliar compartilhado `enumerateShapes` tem uma opção `includeGroupedShapes`. Defina‑a como `true` quando quiser inspecionar formas dentro de objetos [GroupShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/groupshape/). O exemplo abaixo extrai imagens de quadros de imagem, formas preenchidas com imagem, pré‑visualizações de objetos OLE, miniaturas de quadros de vídeo e miniaturas de quadros de áudio. Para incluir também imagens de tabelas, gráficos, SmartArt e zoom resumido, reutilize a lógica de extração especializada das seções anteriores mantendo a mesma travessia recursiva de formas.

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

## **Casos extremos e observações práticas**

- **Imagens duplicadas:** Várias formas podem referenciar a mesma imagem ou imagens distintas com bytes idênticos. Faça hash dos dados de [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) a partir de `getBinaryData()` antes de gravar arquivos se quiser um arquivo de saída por imagem única.
- **Dados originais vs. saída convertida:** Salvar os dados de [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) de `getBinaryData()` preserva o JPEG, PNG, GIF, SVG, EMF ou WMF incorporado. Salvar a imagem retornada por `getImage()` é útil quando você deseja um formato de saída consistente.
- **Tipos de preenchimento não suportados:** Formas de preenchimento sólido, gradiente, padrão ou sem preenchimento não contêm um preenchimento de imagem. Verifique [FillType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/) antes de ler `getPictureFillFormat()`.
- **Formas agrupadas:** A coleção de formas de slide de nível superior não achata grupos. Inspecione recursivamente o conteúdo de [GroupShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/groupshape/) através de `getShapes()` quando o conteúdo agrupado for relevante.
- **Pré‑visualizações de objetos OLE:** Um [OleObjectFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/oleobjectframe/) pode expor uma imagem de pré‑visualização via `getSubstitutePictureFormat()`, mas essa imagem é apenas a pré‑visualização do slide. Não é o arquivo incorporado dentro do objeto OLE.
- **Miniaturas de quadros de vídeo:** Um [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/) pode expor uma imagem de pré‑visualização via `getPictureFormat()`, mas essa imagem é apenas o pôster exibido no slide. Não é extraída do fluxo de vídeo.
- **Miniaturas de quadros de áudio:** Um [AudioFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audioframe/) pode expor um ícone ou miniatura via `getPictureFormat()`; não são os dados de áudio incorporados.
- **Imagens de zoom:** Formas de zoom de slide, zoom de seção e zoom resumido podem usar objetos [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) personalizados via `getZoomImage()`.
- **Modelos de forma aninhados:** Objetos de tabela, gráfico e SmartArt implementam [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/), mas suas imagens costumam estar armazenadas em objetos de formatação de célula de tabela, elemento de gráfico ou nó de SmartArt.
- **Imagens recortadas ou transformadas:** Acessar [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) fornece o recurso de imagem armazenado. Não renderiza recortes, transparência, recoloração, rotação ou outros efeitos visuais aplicados pela forma.

## **Perguntas frequentes**

**Posso extrair a imagem original sem recortes, efeitos ou transformações da forma?**

Sim. Acesse o objeto [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) e grave os dados de `getBinaryData()` no disco. Isso preserva a imagem codificada original armazenada na apresentação, não a forma como a imagem é renderizada no slide.

**Posso exportar todas as imagens extraídas como PNG?**

Sim. Use [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) e seu método `getImage()`, e então chame `save()` com [ImageFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imageformat/). Isso converte a saída e pode não preservar o tipo de arquivo original ou dados vetoriais.

**Como evito salvar a mesma imagem mais de uma vez?**

Use um hash dos dados de [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) obtidos de `getBinaryData()` e mantenha os hashes em um conjunto. Se uma nova imagem tiver um hash que já exista, ignore‑a ou registre outra referência ao arquivo de saída existente.

**Por que algumas formas não produzem uma imagem?**

Quadros de imagem, formas preenchidas com imagem, quadros de objeto OLE, quadros de mídia, quadros de zoom, tabelas, gráficos e objetos SmartArt podem referenciar imagens. Alguns tipos de forma expõem imagens através de objetos de formatação aninhados, portanto uma simples verificação de `getPictureFormat()` ou `getFillFormat()` da forma nem sempre é suficiente.

**Posso extrair a miniatura exibida para um quadro de vídeo?**

Sim. Use [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/) e leia `getPictureFormat()->getPicture()->getImage()`. Isso extrai a imagem de pôster armazenada com o quadro de vídeo, não um quadro gerado a partir do arquivo de vídeo.

**Como posso determinar quais formas usam uma imagem específica da coleção de imagens da apresentação?**

Aspose.Slides não armazena links reversos de [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) para formas. Construa um mapeamento durante a travessia: sempre que encontrar uma referência de imagem, registre o número do slide, caminho da forma e hash da imagem ou item da coleção.

**Posso extrair imagens incorporadas dentro de objetos OLE, como documentos anexados?**

Você pode extrair a pré‑visualização de slide do objeto OLE a partir de [OleObjectFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/oleobjectframe/). Contudo, essa pré‑visualização não é o documento incorporado em si. Para extrair imagens de dentro do arquivo incorporado, extraia os dados OLE e inspecione‑os com ferramentas adequadas ao tipo de arquivo.