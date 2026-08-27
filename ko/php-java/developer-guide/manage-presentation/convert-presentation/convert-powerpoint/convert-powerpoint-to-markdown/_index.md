---
title: PHP에서 PowerPoint 프레젠테이션을 Markdown으로 변환
linktitle: PowerPoint를 Markdown으로 변환
type: docs
weight: 140
url: /ko/php-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 MD로
- 프레젠테이션을 MD로
- 슬라이드를 MD로
- PPT를 MD로
- PPTX를 MD로
- PowerPoint를 Markdown으로 저장
- 프레젠테이션을 Markdown으로 저장
- 슬라이드를 Markdown으로 저장
- PPT를 MD로 저장
- PPTX를 MD로 저장
- PPT를 MD로 내보내기
- PPTX를 MD로 내보내기
- Markdown 이미지 내보내기
- CDN 이미지 링크
- PowerPoint
- 프레젠테이션
- Markdown
- PHP
- Aspose.Slides
description: "PHP에서 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환하고, 내보낸 비트맵, 메타파일 및 SVG 이미지의 저장 위치와 참조를 제어합니다."
---
## **개요**

Aspose.Slides for PHP via Java은 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환하여 문서화, 정적 사이트, 콘텐츠 마이그레이션 및 버전 관리 워크플로에 사용할 수 있습니다. Markdown 형식을 선택하고, 슬라이드 콘텐츠가 렌더링되는 방식을 제어하며, 내보낸 이미지가 저장되는 위치와 생성된 Markdown이 이를 어떻게 참조하는지 결정할 수 있습니다.

기본적으로 Markdown 내보내기는 텍스트 전용 출력을 사용합니다. 시각적 콘텐츠를 내보내려면 [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/) 메서드로 [MarkdownExportType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownexporttype/) 열거형의 `Sequential` 또는 `Visual` 값을 지정합니다. `Sequential`은 슬라이드 항목을 개별적으로 순서대로 렌더링하고, `Visual`은 그룹화된 항목을 함께 유지하여 시각적 관계를 보존합니다. `TextOnly` 값은 이미지 리소스를 내보내지 않으므로 해당 모드에서는 이미지 저장 콜백이 호출되지 않습니다.

## **프레젠테이션을 Markdown으로 변환**

[Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스로 원본 파일을 로드한 뒤, [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 메서드에 [SaveFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveformat/) 열거형의 `Md` 값을 전달합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Markdown 형식 선택**

[MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/) 메서드는 출력에 사용할 Markdown 사양을 제어합니다. [Flavor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/flavor/) 열거형에는 CommonMark, GitHub Flavored Markdown 및 기타 지원되는 변형이 포함됩니다.

다음 예제는 프레젠테이션을 CommonMark 형식으로 내보냅니다:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **기본 로컬 저장 동작을 사용하여 이미지 내보내기**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/) 클래스는 로컬에 저장되는 이미지를 구성하기 위한 두 가지 메서드를 제공합니다.

- [setBasePath](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/)은 Markdown 문서와 해당 리소스의 기본 디렉터리를 지정합니다.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/)은 이미지 서브디렉터리를 지정합니다. 기본값은 `Images`입니다.

다음 예제는 시각적 콘텐츠를 렌더링하고 이미지를 `output/assets`에 저장하며, Markdown 문서에 상대 이미지 참조를 생성합니다:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

이 동작은 사용자 정의 이미지 저장 핸들러가 `false`를 반환할 때의 대체 동작으로도 사용됩니다.

## **이미지 저장 및 Markdown 링크 사용자 정의**

[MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/) 메서드를 사용하여 Markdown 내보내기 중에 발생하는 비‑SVG 비트맵 및 메타파일 리소스에 대한 콜백을 등록합니다. `MarkdownImageSavingHandler` 콜백은 [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/) 객체, 해당 [ImageFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imageformat/) 값, 그리고 하나의 요소를 가진 Java 문자열 배열 형태의 생성된 Markdown 링크를 받습니다. 제공된 형식으로 이미지를 저장하거나 업로드하고, `$link[0]`을 Markdown 출력에 표시될 참조로 교체합니다.

SVG 형식으로 발생하는 리소스는 별도로 처리됩니다. [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/) 메서드로 콜백을 등록합니다. `MarkdownSvgImageSavingHandler` 콜백은 [ISvgImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/isvgimage/) 객체와 하나의 요소를 가진 Java 문자열 배열 `$link`를 받습니다. SVG에는 `ImageFormat` 인수가 없으며, 대신 [ISvgImage::getSvgData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/isvgimage/) 메서드로 XML 데이터를 작성하거나 업로드합니다. 내보내기 모드와 시각적 그룹화에 따라 소스 프레젠테이션의 SVG가 래스터화되거나 다른 콘텐츠와 결합될 수 있으며, 결과 비‑SVG 리소스는 이미지 저장 콜백으로 전달됩니다. 모든 내보낸 시각적 리소스가 사용자 정의 처리를 필요로 할 때 두 콜백을 모두 등록하십시오.

PHP via Java에서는 각 콜백을 PHP 클래스에 구현하고 `java_closure`를 사용해 해당 객체를 해당 Java 인터페이스로 노출합니다.

{{% alert color="info" title="Note" %}}
`JAVA_PREFER_VALUES`를 활성화한 상태에서 `Java.inc`를 로드하기 전에 PHP/Java Bridge를 초기화하십시오. [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 메서드는 `void`를 반환하며, 브리지의 기본 스트림 모드에서는 대기 중인 호출 중에 PHP 콜백을 호출할 수 없습니다. 아래 완전한 예제에는 필요한 초기화 코드가 포함돼 있습니다.
{{% /alert %}}

핸들러 반환값에 따라 이미지 처리가 결정됩니다.

- 핸들러가 이미지를 저장·업로드·변환하거나 기타 처리를 수행하고 `$link[0]`에 유효한 값을 할당한 뒤 `true`를 반환하면, Aspose.Slides는 해당 값을 Markdown 문서에 쓰고 기본 로컬 저장을 수행하지 않습니다.
- `false`를 반환하면 Aspose.Slides가 이미지를 로컬에 저장하고, [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/)와 [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/)에 설정된 값에 따라 링크를 생성합니다.

{{% alert color="warning" title="Important" %}}
`true`를 반환한 핸들러는 이미지에 대한 책임을 집니다. 유효하고 비어 있지 않은 링크를 할당하지 않고 `true`를 반환하면 `InvalidOperationException`이 발생해 내보내기가 실패합니다.
{{% /alert %}}

### **CDN 원본 디렉터리에 이미지 저장 및 외부 URL 사용**

다음 예제는 `cdn-origin/presentations/quarterly-report` 디렉터리를 마운트되거나 동기화된 CDN 원본 디렉터리로 간주합니다. 각 핸들러는 생성된 파일 이름을 추출하여 해당 사용자 정의 디렉터리에 이미지를 저장하고, 생성된 로컬 참조를 공개 CDN URL로 교체합니다. 샘플 자체는 네트워크 업로드를 수행하지 않으며, 디렉터리가 CDN 원본으로 마운트되거나 파일이 CDN에 게시된 후에만 URL이 유효해집니다. 객체 저장소를 사용하는 경우 파일 시스템 쓰기를 저장소 SDK의 업로드 작업으로 교체하고, 업로드가 성공한 뒤에만 `$link[0]`을 할당하십시오.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

비트맵 핸들러는 128 × 128 픽셀보다 작은 이미지는 `false`를 반환하도록 의도적으로 구현되어 있어 Aspose.Slides가 기본 동작으로 `output/fallback-images`에 저장합니다. 더 큰 비트맵·메타파일 리소스와 SVG 리소스는 사용자 정의 코드가 처리합니다. 예를 들어, `fallback-images/image1.png`와 같은 로컬 참조는 `https://cdn.example.com/presentations/quarterly-report/image1.png`로 바뀝니다. 핸들러는 파일을 쓸 때만 운영 체제 경로 구분자를 사용하고, Markdown에 쓰이는 링크는 슬래시(`/`)와 URL‑인코딩된 파일 이름을 사용합니다. 상대 링크를 만들 때도 동일하게 `/`를 사용하고 플랫폼별 구분자를 사용하지 마십시오.

## **FAQ**

**하나의 핸들러가 래스터 이미지와 SVG 이미지를 모두 처리할 수 있나요?**

아니오. 비트맵·메타파일 리소스는 [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/)를, SVG 리소스는 [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/)를 사용하십시오. 전자는 [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/) 객체와 [ImageFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imageformat/) 값을 제공하고, 후자는 [ISvgImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/isvgimage/) 객체와 그 SVG 데이터를 읽을 수 있는 [ISvgImage::getSvgData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/isvgimage/)를 제공합니다. 내보내기 중에 래스터화된 소스 SVG는 이미지 저장 콜백으로 처리됩니다.

**이미지 저장 핸들러가 `false`를 반환하면 어떻게 됩니까?**

Aspose.Slides는 기본 로컬 저장 동작을 사용합니다. 이미지 위치와 생성된 참조는 [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/) 및 [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/)에 설정된 값에 따라 제어됩니다.

**핸들러가 이미지를 로컬에 저장하지 않고 URL만 제공할 수 있나요?**

예. 핸들러가 이미지를 객체 저장소에 업로드하거나 다른 서비스에 전달하고, 결과 URL을 `$link[0]`에 할당한 뒤 `true`를 반환하면 됩니다. 이 경우 핸들러가 직접 처리를 완료해야 하며, `true` 반환은 기본 로컬 저장을 방지합니다.

**핸들러에서 `InvalidOperationException`이 발생하는 이유는 무엇입니까?**

핸들러가 `true`를 반환했지만 유효한 링크를 제공하지 않을 때 발생합니다. `true`를 반환하기 전에 Markdown에 기록될 상대 경로나 외부 URL을 `$link[0]`에 할당하십시오.

**이미지 링크에 어떤 경로 구분자를 사용해야 합니까?**

Markdown 링크와 URL에서는 슬래시(`/`)를 사용하십시오. 파일 시스템 경로에서는 `DIRECTORY_SEPARATOR`를 사용하고, Markdown 참조는 별도로 슬래시 기반 경로로 구성하십시오.

**Markdown 내보내기 시 하이퍼링크가 보존됩니까?**

예. 텍스트 [hyperlinks](/slides/ko/php-java/manage-hyperlinks/)는 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/php-java/slide-transition/)와 [animations](/slides/ko/php-java/powerpoint-animation/)는 변환되지 않습니다.

**프레젠테이션을 병렬로 Markdown으로 변환할 수 있나요?**

다른 프레젠테이션 파일들을 병렬로 처리할 수 있지만, 동일한 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 공유하지 마십시오. [멀티스레딩 가이드라인](/slides/ko/php-java/multithreading/)을 따르고 파일당 별도 인스턴스를 사용하십시오.