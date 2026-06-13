---
title: PHP에서 프레젠테이션 도형에서 이미지 추출
linktitle: 도형의 이미지
type: docs
weight: 100
url: /ko/php-java/extracting-images-from-presentation-shapes/
keywords:
- 이미지 추출
- 이미지 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 도형에서 이미지를 추출합니다 - 빠르고 코드 친화적인 솔루션."
---
## **개요**

프레젠테이션의 이미지들은 여러 형태의 도형에 나타날 수 있습니다: 일반 사진 프레임, 도형에 적용된 사진 채우기, OLE 개체 미리보기 이미지, 비디오 또는 오디오 프레임 썸네일, 줌 이미지, 또는 표, 차트 및 SmartArt 도형 내부에 중첩된 이미지 등. Aspose.Slides는 이러한 이미지들을 프레젠테이션 이미지 컬렉션에 저장하며, 이는 [ImageCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagecollection/) 및 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 객체를 통해 노출됩니다.

프레젠테이션에 삽입된 모든 이미지 리소스를 내보내기만 하면 된다면 `presentation->getImages()`를 반복하면 됩니다. 이 문서에서는 다른 작업에 초점을 맞춥니다: 도형을 순회하면서 슬라이드에서 이미지가 사용된 위치를 찾아 저장된 파일에 슬라이드 번호, 도형 위치, 원본 유형(사진 프레임, 채우기 이미지, 미디어 미리보기, OLE 미리보기 또는 줌 이미지)과 같은 유용한 컨텍스트를 유지하도록 합니다.

{{% alert title="Tip" color="primary" %}}
[PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)와 그 `getBinaryData()` 메서드를 사용하면 원본 인코딩된 이미지 데이터와 파일 형식을 보존할 수 있습니다. PNG와 같은 특정 형식으로 출력을 정규화하려면 `getImage()`를 사용하십시오.
{{% /alert %}}

## **공유 헬퍼 메서드**

아래 헬퍼 메서드들은 예제를 간결하게 유지합니다. `saveOriginalImage`는 원본 삽입 바이트를 기록하고, MIME 유형으로부터 안전한 확장자를 선택하며, SHA-256 해시를 사용해 중복 이미지 바이너리를 건너뜁니다.

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

## **그림 프레임에서 이미지 추출**

독립 객체로 삽입된 사진에 이 방법을 사용하십시오. [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)은 `getPictureFormat()->getPicture()->getImage()`에 그림을 저장하며, 이는 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 객체를 반환합니다.

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

## **그림으로 채워진 도형에서 이미지 추출**

도형은 그림을 채우기로 사용할 수 있습니다. 먼저 도형의 채우기 유형을 확인하십시오: [FillType.Picture](https://reference.aspose.com/slides/ko/php-java/aspose.slides/filltype/)이 아닌 경우 해당 채우기에서 추출할 그림이 없습니다. 아래 예제는 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 객체를 처리하고, 각 이미지를 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)와 그 `getImage()` 메서드를 통해 PNG로 저장합니다.

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

## **OLE 개체 프레임에서 미리보기 이미지 추출**

[OleObjectFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleobjectframe/)은 PowerPoint가 슬라이드에서 개체의 미리보기로 사용하는 대체 그림을 가질 수 있습니다. 이 이미지는 `getSubstitutePictureFormat()->getPicture()->getImage()`를 통해 얻을 수 있습니다. 이 그림을 추출하면 임베디드 OLE 패키지 내용이 아닌 미리보기 이미지를 얻습니다.

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

## **비디오 프레임에서 미리보기 이미지 추출**

[VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/)은 `getPictureFormat()->getPicture()->getImage()`에 미리보기 이미지를 저장할 수도 있습니다. 이는 슬라이드에 표시되는 포스터 또는 썸네일이며, 비디오 스트림에서 디코딩한 프레임이 아닙니다.

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

## **오디오 프레임에서 미리보기 이미지 추출**

[AudioFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/)은 `getPictureFormat()->getPicture()->getImage()`에 썸네일을 저장할 수 있습니다. 이는 슬라이드에 표시되는 오디오 개체의 이미지입니다.

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

## **줌 객체에서 이미지 추출**

[ZoomFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/zoomframe/) 및 [SectionZoomFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sectionzoomframe/) 도형은 사용자 지정 이미지를 사용할 수 있습니다. 줌 프레임에서 `getZoomImage()`를 읽으십시오.

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

## **요약 줌 프레임에서 이미지 추출**

[SummaryZoomFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/summaryzoomframe/)도 도형입니다. 해당 섹션 항목들은 사용자 지정 이미지를 사용할 수 있으며, 각 요약 줌 섹션의 `getZoomImage()` 메서드로 노출됩니다.

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

## **표 도형에서 이미지 추출**

[Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/table/)은 도형입니다. 표 내의 이미지는 일반적으로 표 셀의 사진 채우기로 저장됩니다.

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

## **차트 도형에서 이미지 추출**

[Chart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/)은 도형입니다. 아래 예제는 차트 영역의 사진 채우기에서 이미지를 추출합니다.

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

## **SmartArt 도형에서 이미지 추출**

[SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/) 객체는 도형입니다. SmartArt 레이아웃에 따라 이미지는 노드 글머리표 채우기 또는 노드 도형의 채우기 형식에 저장될 수 있습니다.

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

## **그룹화된 도형 내부 이미지 포함**

그룹화된 도형은 자체 도형 컬렉션을 포함합니다. 공유된 `enumerateShapes` 헬퍼에는 `includeGroupedShapes` 옵션이 있습니다. [GroupShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/groupshape/) 객체 내부의 도형을 검사하려면 이를 `true`로 설정하십시오. 아래 예제는 사진 프레임, 사진 채워진 도형, OLE 개체 미리보기, 비디오 프레임 썸네일 및 오디오 프레임 썸네일에서 이미지를 추출합니다. 표, 차트, SmartArt 및 요약 줌 이미지까지 포함하려면 이전 섹션의 특수 추출 로직을 재사용하면서 동일한 재귀적 도형 순회를 유지하십시오.

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

## **경우별 고려 사항 및 실용적 참고 사항**

- **중복 이미지:** 여러 도형이 동일한 이미지를 참조하거나 바이트가 동일한 별개의 이미지를 가질 수 있습니다. 고유 이미지당 하나의 출력 파일을 원한다면 파일을 작성하기 전에 `getBinaryData()`의 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 데이터를 해시하십시오.
- **원본 데이터 vs. 변환된 출력:** `getBinaryData()`의 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 데이터를 저장하면 삽입된 JPEG, PNG, GIF, SVG, EMF 또는 WMF 데이터를 보존합니다. 일관된 출력 형식을 원한다면 `getImage()`가 반환하는 이미지를 저장하는 것이 유용합니다.
- **지원되지 않는 채우기 유형:** 단색, 그라디언트, 패턴 및 채우기 없음 도형은 사진 채우기를 포함하지 않습니다. `getPictureFillFormat()`을 읽기 전에 [FillType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/filltype/)을 확인하십시오.
- **그룹화된 도형:** 최상위 슬라이드 도형 컬렉션은 그룹을 평탄화하지 않습니다. 그룹화된 콘텐츠가 중요할 때 `getShapes()`를 통해 [GroupShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/groupshape/) 내용을 재귀적으로 검사하십시오.
- **OLE 개체 미리보기:** [OleObjectFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleobjectframe/)은 `getSubstitutePictureFormat()`을 통해 미리보기 이미지를 제공할 수 있지만, 해당 이미지는 슬라이드 미리보기일 뿐이며 OLE 개체 내부에 삽입된 파일은 아닙니다.
- **비디오 프레임 썸네일:** [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/)은 `getPictureFormat()`을 통해 미리보기 이미지를 제공할 수 있지만, 해당 이미지는 슬라이드에 표시되는 포스터일 뿐이며 비디오 스트림에서 추출된 것이 아닙니다.
- **오디오 프레임 썸네일:** [AudioFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/)은 `getPictureFormat()`을 통해 아이콘이나 썸네일을 제공할 수 있지만, 이는 삽입된 오디오 데이터가 아닙니다.
- **줌 이미지:** 슬라이드 줌, 섹션 줌 및 요약 줌 도형은 `getZoomImage()`를 통해 사용자 지정 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 객체를 사용할 수 있습니다.
- **중첩 도형 모델:** 표, 차트 및 SmartArt 객체는 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/)을 구현하지만, 해당 이미지들은 종종 중첩된 표 셀, 차트 요소 또는 SmartArt 노드 서식 객체에 저장됩니다.
- **잘라내기 또는 변형된 사진:** [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)에 접근하면 저장된 이미지 리소스를 얻을 수 있지만, 도형이 적용한 잘라내기, 투명도, 재색상, 회전 또는 기타 시각 효과는 렌더링되지 않습니다.

## **자주 묻는 질문**

**원본 이미지를 잘라내기, 효과 또는 도형 변형 없이 추출할 수 있나요?**

예. [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 객체에 접근하여 `getBinaryData()`의 데이터를 디스크에 기록하십시오. 이렇게 하면 프레젠테이션에 저장된 원본 인코딩 이미지가 보존되며, 슬라이드에서 이미지가 렌더링되는 방식은 반영되지 않습니다.

**추출한 모든 이미지를 PNG로 내보낼 수 있나요?**

예. [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)와 그 `getImage()` 메서드를 사용하고, 이어서 [ImageFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imageformat/)을 사용해 `save()`를 호출하십시오. 이렇게 하면 출력이 변환되며 원본 파일 형식이나 벡터 데이터가 보존되지 않을 수 있습니다.

**같은 이미지를 여러 번 저장하지 않으려면 어떻게 해야 하나요?**

[PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)의 `getBinaryData()` 데이터를 해시하고 해시 집합에 보관하십시오. 새로운 이미지의 해시가 이미 존재한다면 해당 이미지를 건너뛰거나 기존 출력 파일에 대한 다른 참조를 기록하십시오.

**왜 일부 도형에서는 이미지가 생성되지 않나요?**

사진 프레임, 사진 채워진 도형, OLE 개체 프레임, 미디어 프레임, 줌 프레임, 표, 차트 및 SmartArt 객체는 이미지를 참조할 수 있습니다. 일부 도형 유형은 중첩된 서식 객체를 통해 이미지를 노출하므로 단순히 `getPictureFormat()` 또는 도형 `getFillFormat()`을 확인하는 것만으로는 충분하지 않을 수 있습니다.

**비디오 프레임에 표시되는 썸네일을 추출할 수 있나요?**

예. [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/)을 사용하고 `getPictureFormat()->getPicture()->getImage()`를 읽으십시오. 이는 비디오 프레임에 저장된 포스터 이미지를 추출하는 것이며, 비디오 파일에서 생성된 프레임이 아닙니다.

**프레젠테이션 이미지 컬렉션에서 특정 이미지를 사용하는 도형을 어떻게 확인할 수 있나요?**

Aspose.Slides는 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)에서 도형으로의 역링크를 저장하지 않습니다. 순회 중에 매핑을 구축하십시오: 이미지 참조를 찾을 때마다 슬라이드 번호, 도형 경로 및 이미지 해시 또는 컬렉션 항목을 기록하십시오.

**첨부 문서와 같은 OLE 개체 내부에 삽입된 이미지를 추출할 수 있나요?**

[OleObjectFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleobjectframe/)에서 OLE 개체의 슬라이드 미리보기를 추출할 수 있습니다. 그러나 해당 미리보기는 삽입된 문서 자체가 아닙니다. 삽입된 파일 내부의 이미지를 추출하려면 OLE 데이터를 추출한 뒤 해당 파일 유형에 맞는 도구로 검사하십시오.