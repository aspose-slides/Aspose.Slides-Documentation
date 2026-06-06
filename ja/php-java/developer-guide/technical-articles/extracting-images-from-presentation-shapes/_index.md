---
title: PHP でプレゼンテーションの形状から画像を抽出
linktitle: 形状からの画像
type: docs
weight: 100
url: /ja/php-java/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP 用 Aspose.Slides (Java 経由) を使用して、PowerPoint および OpenDocument プレゼンテーションの形状から画像を抽出する - 簡単でコードフレンドリーなソリューション。"
---
## **概要**

プレゼンテーション内の画像は、さまざまな形状タイプで表示されます: 通常の画像フレームとして、形状に適用された画像フィルとして、OLE オブジェクトのプレビュー画像として、ビデオまたはオーディオ フレームのサムネイルとして、ズーム画像として、またはテーブル、チャート、SmartArt 形状の内部にネストされた画像としてです。Aspose.Slides はそれらの画像をプレゼンテーションの画像コレクションに保存し、[ImageCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagecollection/) および [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) オブジェクトとして公開します。

プレゼンテーションに埋め込まれたすべての画像リソースをエクスポートするだけでよい場合は、`presentation->getImages()` を反復処理してください。このドキュメントは別のタスクに焦点を当てます。スライド上で画像が使用されている場所を形状を走査して特定し、保存したファイルにスライド番号、形状の位置、元のタイプ（画像フレーム、フィル画像、メディアプレビュー、OLE プレビュー、またはズーム画像）といった有用なコンテキストを保持できるようにします。

{{% alert title="Tip" color="primary" %}}
元のエンコードされた画像データとファイルタイプを保持するには、[PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) とその `getBinaryData()` メソッドを使用します。出力を PNG のような特定の形式に正規化したい場合は `getImage()` を使用してください。
{{% /alert %}}

## **共有ヘルパーメソッド**

以下のヘルパーメソッドはサンプルを簡潔に保ちます。`saveOriginalImage` は元の埋め込みバイトを書き込み、MIME タイプから安全な拡張子を選択し、SHA-256 ハッシュにより重複する画像バイナリをスキップします。

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

## **画像フレームから画像を抽出**

単体オブジェクトとして挿入された画像にこの方法を使用します。[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) は `getPictureFormat()->getPicture()->getImage()` に画像を保持し、[PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) オブジェクトを返します。

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

## **画像で塗りつぶされた形状から画像を抽出**

形状は画像を塗りとして使用できます。まず形状の塗りタイプを確認してください: それが [FillType.Picture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filltype/) でない場合、その塗りから抽出できる画像はありません。以下の例は [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) オブジェクトを扱い、[PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) とその `getImage()` メソッドを使用して各画像を PNG として保存します。

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

## **OLE オブジェクト フレームからプレビュー画像を抽出**

[OleObjectFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/oleobjectframe/) は、PowerPoint がスライド上でオブジェクトのプレビューとして使用する代替画像を持つことがあります。この画像は `getSubstitutePictureFormat()->getPicture()->getImage()` で取得できます。この画像を抽出すると、埋め込み OLE パッケージの内容ではなく、プレビュー画像が得られます。

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

## **ビデオフレームからプレビュー画像を抽出**

[VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) も `getPictureFormat()->getPicture()->getImage()` にプレビュー画像を格納できます。これはスライド上に表示されるポスターまたはサムネイルであり、ビデオストリームからデコードされたフレームではありません。

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

## **オーディオフレームからプレビュー画像を抽出**

[AudioFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/) は `getPictureFormat()->getPicture()->getImage()` にサムネイルを格納できます。これはスライド上でオーディオオブジェクトに表示される画像です。

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

## **ズームオブジェクトから画像を抽出**

[ZoomFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/zoomframe/) と [SectionZoomFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sectionzoomframe/) 形状はカスタム画像を使用できます。ズームフレームから `getZoomImage()` を読み取ります。

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

## **サマリーズームフレームから画像を抽出**

[SummaryZoomFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/summaryzoomframe/) も形状です。そのセクション項目はカスタム画像を使用でき、各サマリーズームセクションの `getZoomImage()` メソッドで取得できます。

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

## **テーブル形状から画像を抽出**

[Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/table/) は形状です。テーブル内の画像は通常、セルの画像フィルとして保存されます。

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

## **チャート形状から画像を抽出**

[Chart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/) は形状です。以下の例はチャート領域の画像フィルから画像を抽出します。

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

## **SmartArt 形状から画像を抽出**

[SmartArt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartart/) オブジェクトは形状です。SmartArt のレイアウトによっては、画像がノードの箇条書きフィルに格納されたり、ノード形状の塗りフォーマットに格納されたりします。

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

## **グループ化された形状内の画像を含める**

グループ化された形状は独自の形状コレクションを持ちます。共有 `enumerateShapes` ヘルパーには `includeGroupedShapes` オプションがあります。グループ形状内の形状を調べたい場合は `true` に設定してください。[GroupShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/groupshape/) オブジェクト内の形状を検査します。以下の例は画像フレーム、画像で塗りつぶされた形状、OLE オブジェクトプレビュー、ビデオフレームサムネイル、オーディオフレームサムネイルから画像を抽出します。テーブル、チャート、SmartArt、サマリーズーム画像も含めるには、前述のセクションの専用抽出ロジックを再利用しつつ、同じ再帰的形状走査を保持してください。

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

## **エッジケースと実用的な注意点**

- **重複画像:** 複数の形状が同じ画像を参照したり、バイトが同一の別々の画像を参照したりすることがあります。ユニークな画像ごとに 1 つの出力ファイルにしたい場合は、ファイルを書き出す前に `getBinaryData()` から取得した [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) データをハッシュしてください。
- **元データと変換後出力:** `getBinaryData()` から取得した [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) データを保存すると、埋め込まれた JPEG、PNG、GIF、SVG、EMF、または WMF データが保持されます。`getImage()` が返す画像を保存すると、出力形式を統一したい場合に便利です。
- **サポートされない塗りタイプ:** 単色、グラデーション、パターン、ノーフィルの形状には画像フィルが含まれません。[FillType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filltype/) を確認してから `getPictureFillFormat()` を読み取ってください。
- **グループ形状:** スライドの最上位形状コレクションはグループをフラット化しません。グループ化されたコンテンツが重要な場合は、`getShapes()` を通じて [GroupShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/groupshape/) の内容を再帰的に検査してください。
- **OLE オブジェクトプレビュー:** [OleObjectFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/oleobjectframe/) は `getSubstitutePictureFormat()` を通じてプレビュー画像を公開することがありますが、その画像はスライド上のプレビューにすぎません。OLE オブジェクト内部に埋め込まれたファイルそのものではありません。
- **ビデオフレームサムネイル:** [VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) は `getPictureFormat()` を通じてプレビュー画像を公開することがありますが、その画像はスライド上に表示されるポスターであり、ビデオストリームから抽出されたフレームではありません。
- **オーディオフレームサムネイル:** [AudioFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audioframe/) は `getPictureFormat()` を通じてアイコンやサムネイルを公開することがありますが、埋め込まれたオーディオデータそのものではありません。
- **ズーム画像:** スライドズーム、セクションズーム、サマリーズームの形状は `getZoomImage()` を介してカスタム [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) オブジェクトを使用できる場合があります。
- **入れ子になった形状モデル:** テーブル、チャート、SmartArt オブジェクトは [Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) を実装しますが、画像はしばしば入れ子になったテーブルセル、チャート要素、または SmartArt ノードの書式設定オブジェクトに格納されます。
- **切り抜きまたは変形された画像:** [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) にアクセスすると、保存された画像リソースそのものが取得できます。形状が適用した切り抜き、透明度、再着色、回転、その他の視覚効果はレンダリングされません。

## **FAQ**

**元の画像を切り抜きやエフェクト、形状変換なしで抽出できますか？**

はい。`getBinaryData()` から取得したデータを書き出すことで、プレゼンテーションに保存された元のエンコード画像を保持できます。スライド上でのレンダリング方法は反映されません。

**抽出したすべての画像を PNG 形式でエクスポートできますか？**

はい。[PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) とその `getImage()` メソッドを使用し、[ImageFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imageformat/) と共に `save()` を呼び出してください。これにより出力が PNG に変換されますが、元のファイルタイプやベクターデータは保持されない可能性があります。

**同じ画像を複数回保存しないようにするには？**

`getBinaryData()` から取得した [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) データのハッシュを作成し、ハッシュ集合で管理します。新しい画像のハッシュが既に存在する場合は保存をスキップするか、既存の出力ファイルへの別参照として記録してください。

**一部の形状が画像を生成しないのはなぜですか？**

画像フレーム、画像で塗りつぶされた形状、OLE オブジェクトフレーム、メディアフレーム、ズームフレーム、テーブル、チャート、SmartArt オブジェクトは画像を参照できますが、形状タイプによっては画像がネストされた書式設定オブジェクトを通してのみ取得できるため、単純な `getPictureFormat()` や `getFillFormat()` のチェックだけでは不十分な場合があります。

**ビデオフレームのサムネイル画像を抽出できますか？**

はい。[VideoFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoframe/) を使用し、`getPictureFormat()->getPicture()->getImage()` を読み取ります。これによりビデオフレームに保存されたポスター画像が抽出されますが、ビデオファイルから生成されたフレームではありません。

**プレゼンテーション画像コレクションから特定の画像を使用している形状を特定するには？**

Aspose.Slides は [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) から形状への逆リンクを保持していません。走査中に画像参照を検出したら、スライド番号、形状パス、画像ハッシュまたはコレクション項目を記録してマッピングを構築してください。

**OLE オブジェクト内部に埋め込まれた画像（例: 添付文書）を抽出できますか？**

[OleObjectFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/oleobjectframe/) からはスライドプレビュー画像のみ抽出できます。埋め込まれた文書自体の画像を取得するには、OLE データを抽出し、対象ファイルタイプに適したツールで内部を解析する必要があります。