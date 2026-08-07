---
title: PHP를 사용한 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/php-java/image/
keywords:
- 이미지 추가
- 그림 추가
- 비트맵 추가
- 이미지 교체
- 그림 교체
- 웹에서
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- 외부 SVG 리소스
- SVG 해결자
- 연결된 SVG 이미지
- SVG 폰트
- EMF 추가
- WMF 추가
- TIFF 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Java를 통한 PHP용 Aspose.Slides로 PowerPoint 및 OpenDocument의 이미지 관리를 간소화하여 성능을 최적화하고 워크플로를 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 보다 흥미롭고 시각적으로 매력적으로 만듭니다. Microsoft PowerPoint에서 파일, 인터넷 또는 기타 소스에서 슬라이드에 그림을 삽입할 수 있습니다. 마찬가지로 Aspose.Slides를 사용하면 여러 방법으로 프레젠테이션 슬라이드에 이미지를 추가할 수 있습니다.

{{% alert  title="Tip" color="primary" %}} 
Aspose는 무료 변환기—[JPEG를 PowerPoint로](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG를 PowerPoint로](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 이미지를 빠르게 프레젠테이션으로 만들 수 있습니다. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
이미지를 그림 프레임으로 추가하고 싶다면—특히 크기 조정, 효과 적용, 기타 표준 서식 옵션을 사용할 계획이라면—[그림 프레임](/slides/ko/php-java/picture-frame/)을 참조하십시오. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 다음 페이지를 참조하십시오: [이미지를 JPG로 변환](https://products.aspose.com/slides/ko/php-java/conversion/image-to-jpg/), [JPG를 이미지로 변환](https://products.aspose.com/slides/ko/php-java/conversion/jpg-to-image/), [JPG를 PNG로 변환](https://products.aspose.com/slides/ko/php-java/conversion/jpg-to-png/), [PNG를 JPG로 변환](https://products.aspose.com/slides/ko/php-java/conversion/png-to-jpg/), [PNG를 SVG로 변환](https://products.aspose.com/slides/ko/php-java/conversion/png-to-svg/), 및 [SVG를 PNG로 변환](https://products.aspose.com/slides/ko/php-java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides는 JPEG, PNG, BMP, GIF 등과 같은 일반적인 이미지 형식을 지원합니다. 

## **슬라이드에 로컬에 저장된 이미지 추가**

컴퓨터에 저장된 하나 이상의 이미지를 프레젠테이션 슬라이드에 추가할 수 있습니다. 다음 PHP 샘플 코드는 슬라이드에 이미지를 추가하는 방법을 보여줍니다:
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **웹에서 슬라이드에 이미지 추가**

슬라이드에 추가하려는 이미지가 컴퓨터에 저장되어 있지 않은 경우, 웹에서 직접 추가할 수 있습니다. 
다음 PHP 샘플 코드는 웹에서 이미지를 가져와 슬라이드에 추가하는 방법을 보여줍니다:
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **슬라이드 마스터에 이미지 추가**

슬라이드 마스터는 해당 마스터를 사용하는 슬라이드의 테마와 레이아웃과 같은 정보를 저장하고 제어합니다. 슬라이드 마스터에 이미지를 추가하면 해당 마스터를 기반으로 하는 모든 슬라이드에 이미지가 나타납니다. 
다음 PHP 샘플 코드는 슬라이드 마스터에 이미지를 추가하는 방법을 보여줍니다:
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **슬라이드 배경으로 이미지 추가**

하나 이상의 슬라이드 배경으로 사진을 사용할 수 있습니다. 자세한 내용은 *[슬라이드 배경으로 이미지 설정](/slides/ko/php-java/presentation-background/#setting-images-as-background-for-slides)*을 참조하십시오.

## **프레젠테이션에 SVG 추가**

SVG 콘텐츠는 [SvgImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgimage/) 클래스를 사용하여 프레젠테이션에 추가할 수 있습니다. 결과 SVG 이미지 객체는 프레젠테이션 이미지 컬렉션에 추가된 후 그림 프레임을 만드는 데 사용할 수 있습니다. 
다음 PHP 예제는 자체 포함된 SVG 문자열을 가져옵니다. 이 SVG에서 사용되는 모든 이미지, 스타일 및 기타 리소스가 SVG 콘텐츠에 직접 포함됩니다.
```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **외부 리소스가 있는 SVG 콘텐츠 가져오기**

디자인 도구, 다이어그램 편집기, 아이콘 시스템 및 웹 파이프라인에서 내보낸 SVG 파일은 SVG 문서 외부에 저장된 리소스를 참조할 수 있습니다. 예를 들어, SVG는 `images/photo.png`와 같은 이미지 링크, CSS `url(...)` 값 또는 폰트 URL을 포함할 수 있습니다. 
이러한 SVG 콘텐츠를 가져오려면 [ExternalResourceResolver](https://reference.aspose.com/slides/ko/php-java/aspose.slides/externalresourceresolver/) 구현을 만들고 이를 기본 URI와 함께 적절한 [SvgImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgimage/) 생성자에 전달하십시오. 기본 URI는 SVG 문서의 위치를 식별하고 상대 링크를 해결하는 데 사용됩니다. 
SVG 이미지 객체는 가져온 SVG에 대한 정보를 액세스할 수 있게 합니다:
- `getSvgContent()`는 SVG 마크업을 문자열로 반환합니다.
- `getSvgData()`는 SVG 콘텐츠를 바이트 배열로 반환합니다.
- `getBaseUri()`는 상대 링크에 사용되는 기본 URI를 반환합니다.
- `getExternalResourceResolver()`는 SVG 이미지에 할당된 리소스 해결자를 반환합니다.

### **외부 리소스 해결자 구현**

해결자는 두 가지 메서드를 가집니다:
- `resolveUri`는 기본 URI와 상대 리소스 링크를 결합하여 절대 URI를 반환합니다. 링크를 해결할 수 없거나 허용되지 않을 경우 `null`을 반환합니다.
- `getEntity`는 절대 리소스 URI에 대한 읽기 가능한 스트림을 반환합니다. 리소스가 없거나 차단되었거나 사용할 수 없는 경우 `null`을 반환합니다. 필요한 경우 대체 스트림도 반환할 수 있습니다.

다음 해결자는 허용된 로컬 디렉터리에서만 연결된 리소스를 로드합니다. 네트워크 리소스와 허용된 디렉터리 외부 경로는 차단됩니다. 해결되지 않은 이미지 링크에 대해서는 선택적 대체 이미지가 반환됩니다.
```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // 이 해결자는 의도적으로 로컬 파일만 허용합니다.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // 이미지 리소스에 대해서만 대체를 사용합니다. 이미지 스트림을 반환하는
            // 누락된 폰트나 스타일시트에 대해서는 유효하지 않습니다.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **SVG 가져오기 중 연결된 리소스 해결**

`assets/diagram.svg`에 다음과 같은 상대 참조가 포함되어 있다고 가정합니다:
```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

다음 PHP 예제는 SVG 파일 URI를 기본 URI로 전달하고 사용자 지정 해결자를 제공합니다. 해결자는 상대 이미지 링크를 절대 URI로 변환하고 Aspose.Slides가 SVG를 처리하는 동안 연결된 리소스를 포함하는 스트림을 반환합니다.
```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// 기본 URI는 SVG 문서의 위치를 나타냅니다.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// SVG 이미지 객체는 원본 콘텐츠, 이진 데이터, 기본 URI 및 해결자를 노출합니다.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`SvgImage` 클래스는 SVG 데이터를 바이트 배열 또는 입력 스트림으로 받아들이는 오버로드와 외부 리소스 해결자 및 기본 URI를 함께 사용할 수 있는 오버로드도 제공합니다.

{{% alert title="Important" color="warning" %}}
리소스 해결자는 Aspose.Slides가 SVG를 처리하고 렌더링하는 동안 외부 리소스를 사용할 수 있게 합니다. 이는 원본 SVG 마크업을 수정하거나 해결된 리소스를 자동으로 포함하지 않습니다.

SVG 이미지를 프레젠테이션 이미지 컬렉션에 추가하면 PPTX 파일에 원본 SVG 표현과 래스터 대체 이미지가 모두 포함될 수 있습니다. 생성된 대체 이미지에는 연결된 리소스가 나타날 수 있지만 `images/photo.png`와 같은 상대 링크는 저장된 SVG에 그대로 남아 있습니다. 원본 외부 리소스를 사용할 수 없을 경우 네이티브 SVG 표현을 렌더링하는 애플리케이션은 연결된 콘텐츠를 생략할 수 있습니다.
{{% /alert %}}

### **휴대용 SVG 그림 만들기**

외부 파일에 의존하지 않는 SVG 그림을 만들려면 `SvgImage`를 만들기 전에 SVG를 자체 포함 형태로 만들십시오. 예를 들어, 연결된 이미지 URL을 이미지 데이터를 포함한 `data:` URI로 교체합니다:
```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

필요한 모든 리소스가 SVG 콘텐츠에 포함된 후 `SvgImage`를 생성하고 프레젠테이션 이미지 컬렉션에 추가한 다음 이전 예제와 같이 그림 프레임에 삽입합니다.

### **누락되거나 차단된 리소스 처리**

`resolveUri`에서 리소스 URI가 유효하지 않거나 금지되었거나 해결할 수 없을 때 `null`을 반환하십시오. `getEntity`에서 리소스를 읽을 수 없을 때 `null`을 반환하십시오. 가능한 경우 Aspose.Slides는 해당 리소스 없이도 SVG 처리을 계속합니다.

누락된 리소스에 대해 대체 스트림을 반환할 수 있지만 해당 콘텐츠는 요청된 리소스 타입과 호환되어야 합니다. 예를 들어, 누락된 이미지에 대해서만 이미지 스트림을 반환하고, 폰트나 스타일시트에 대해서는 반환하지 않십시오.

{{% alert title="Security" color="warning" %}}
신뢰할 수 없는 SVG 파일에서 임의의 파일 경로나 무제한 네트워크 URL을 해결하지 마십시오. 허용된 스킴, 디렉터리 및 호스트를 제한하십시오. 네트워크 리소스의 경우 연결 시간 초과, 응답 크기 제한 및 콘텐츠 검증도 적용하십시오.
{{% /alert %}}

## **SVG를 도형 집합으로 변환**

Aspose.Slides는 PowerPoint에서 제공하는 기능과 유사하게 SVG를 도형 집합으로 변환할 수 있습니다:
![PowerPoint Popup Menu](img_01_01.png)

이 기능은 [ShapeCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/) 클래스의 [addGroupShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addgroupshape/) 메서드에 대한 오버로드로 제공되며, 첫 번째 매개변수로 [SvgImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgimage/) 객체를 받습니다.

다음 PHP 샘플 코드는 이 메서드를 사용하여 SVG 파일을 도형 집합으로 변환하는 방법을 보여줍니다:
```php
// 소스 SVG 파일 이름.
$svgFileName = "sample.svg";

// 출력 프레젠테이션 파일 이름.
$outPptxPath = "presentation.pptx";

// 새 프레젠테이션을 생성합니다.
$presentation = new Presentation();
try {
    // SVG 파일 내용을 읽습니다.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // SvgImage 객체를 생성합니다.
    $svgImage = new SvgImage($svgContent);

    // 슬라이드 크기를 가져옵니다.
    $slideSize = $presentation->getSlideSize()->getSize();

    // SVG 이미지를 도형 그룹으로 변환하고 슬라이드 크기에 맞게 확대/축소합니다.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // 프레젠테이션을 PPTX 형식으로 저장합니다.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **슬라이드에 EMF 이미지 추가**

Aspose.Slides for PHP via Java를 사용하면 Aspose.Cells를 통해 Excel 워크시트에서 EMF 이미지를 생성하고 이를 프레젠테이션 슬라이드에 추가할 수 있습니다.

다음 PHP 샘플 코드는 이를 수행하는 방법을 보여줍니다:
```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// 워크북을 스트림에 저장합니다.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // 파일을 그대로 추가하여 그림이 래스터화되지 않고 벡터 EMF로 유지되도록 합니다.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **이미지 컬렉션에서 이미지 교체**

Aspose.Slides를 사용하면 프레젠테이션 이미지 컬렉션에 저장된 이미지(슬라이드 도형이 사용하는 이미지 포함)를 교체할 수 있습니다. 이 섹션에서는 컬렉션의 이미지를 업데이트하는 여러 방법을 설명합니다. 원시 바이트 데이터, [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/) 인스턴스, 또는 컬렉션에 이미 존재하는 다른 이미지를 사용하여 이미지를 교체할 수 있습니다.

다음 단계를 따르십시오:
1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스를 사용하여 이미지를 포함한 프레젠테이션 파일을 로드합니다.
2. 파일에서 새 이미지를 로드하여 바이트 배열에 저장합니다.
3. 바이트 배열을 사용하여 대상 이미지를 새 이미지로 교체합니다.
4. 두 번째 방법에서는 이미지를 [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/) 객체에 로드한 뒤 해당 객체로 대상 이미지를 교체합니다.
5. 세 번째 방법에서는 프레젠테이션 이미지 컬렉션에 이미 존재하는 이미지를 사용하여 대상 이미지를 교체합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```php
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("sample.pptx");
try {
    // 첫 번째 방법.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // 두 번째 방법.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // 세 번째 방법.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // 프레젠테이션을 파일에 저장합니다.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose의 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 사용하면 텍스트를 쉽게 애니메이션화하고 GIF로 만들 수 있습니다. 
{{% /alert %}}

## **FAQ**

**삽입 후 원본 이미지 해상도가 유지됩니까?**

예. 원본 픽셀은 보존되지만 최종 모습은 슬라이드에서 [picture](/slides/ko/php-java/picture-frame/)가 어떻게 조정되는지와 저장 시 적용되는 압축에 따라 달라집니다.

**한 번에 수십 개 슬라이드에 있는 동일한 로고를 교체하는 가장 좋은 방법은 무엇인가요?**

로고를 마스터 슬라이드 또는 레이아웃에 배치하고 프레젠테이션 이미지 컬렉션에서 교체하십시오—업데이트가 해당 리소스를 사용하는 모든 요소에 전파됩니다.

**삽입된 SVG를 편집 가능한 도형으로 변환할 수 있나요?**

예. SVG를 도형 그룹으로 변환하면 개별 파트를 표준 도형 속성으로 편집할 수 있습니다.

**여러 슬라이드에 한 번에 이미지를 배경으로 설정하려면 어떻게 해야 하나요?**

마스터 슬라이드 또는 해당 레이아웃에서 [이미지를 배경으로 지정](/slides/ko/php-java/presentation-background/)하면 해당 마스터/레이아웃을 사용하는 모든 슬라이드에 배경이 적용됩니다.

**많은 그림 때문에 프레젠테이션 파일이 너무 커지는 것을 어떻게 방지할 수 있나요?**

중복 대신 단일 이미지 리소스를 재사용하고, 적절한 해상도를 선택하며, 저장 시 압축을 적용하고, 필요에 따라 반복되는 그래픽을 마스터에 유지하십시오.