---
title: PHP에서 프레젠테이션을 XAML로 내보내기
linktitle: 프레젠테이션을 XAML로
type: docs
weight: 30
url: /ko/php-java/export-to-xaml/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PowerPoint를 XAML로
- OpenDocument를 XAML로
- 프레젠테이션을 XAML로
- PPT를 XAML로
- PPTX를 XAML로
- ODP를 XAML로
- PPT를 XAML로 저장
- PPTX를 XAML로 저장
- ODP를 XAML로 저장
- PPT를 XAML로 내보내기
- PPTX를 XAML로 내보내기
- ODP를 XAML로 내보내기
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 슬라이드를 XAML로 변환합니다 — 레이아웃을 그대로 유지하는 빠르고 Office 없는 솔루션입니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개와 기본 설정으로 프레젠테이션을 XAML로 저장하는 방법을 보여주고, [XamlOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/)를 통해 내보내기를 사용자 지정하는 방법(숨겨진 슬라이드 내보내기 포함)을 시연합니다. 또한 대체 폰트, XAML 스택 호환성 및 숨겨진 슬라이드 내보내기 동작과 관련된 몇 가지 일반적인 질문에도 답변합니다.

## **XAML 소개**

XAML은 WPF(Windows Presentation Foundation), UWP(Univer​sal Windows Platform), Xamarin.Forms와 같은 프레임워크에서 사용자 인터페이스를 설명하는 XML 기반 마크업 언어입니다.

시각 디자이너에서 XAML 파일을 작업하거나 마크업을 직접 작성·수정할 수 있습니다.

## **기본 옵션으로 프레젠테이션을 XAML로 내보내기**

다음 PHP 예제는 기본 설정으로 프레젠테이션을 XAML로 내보내는 방법을 보여줍니다. 이 문서의 예제를 실행하기 전에 PHP Java Bridge를 초기화하고 `aspose.slides.php`를 로드하십시오. `pres.pptx`를 Java Bridge 서버의 작업 디렉터리에 두거나 해당 서버에서 접근 가능한 절대 경로를 제공하십시오.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

기본적으로 내보낸 슬라이드는 Java Bridge 서버 현재 작업 디렉터리의 `pres` 하위 폴더에 저장됩니다. 폴더는 자동으로 생성되며 필요한 이미지도 그곳에 저장됩니다.

출력 폴더 이름은 확장자를 제외한 원본 파일 이름에서 가져옵니다. `pres.pptx`의 경우 출력 파일은 `pres/Slide_1.xaml`, `pres/Slide_2.xaml` 등으로 명명됩니다. 입력 프레젠테이션에 절대 경로를 전달하더라도 출력 폴더는 입력 파일과 같은 위치가 아니라 Java Bridge 서버 현재 작업 디렉터리를 기준으로 생성됩니다.

## **사용자 지정 옵션으로 프레젠테이션을 XAML로 내보내기**

[IXamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloptions/) 인터페이스를 사용하여 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 제어할 수 있습니다.

출력 위치를 사용자 지정하려면 [IXamlOutputSaver](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloutputsaver/)를 구현한 Java 프록시를 제공하고 해당 구현 인스턴스를 [XamlOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/)의 [setOutputSaver](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/#setOutputSaver) 메서드에 전달하십시오.

숨겨진 슬라이드를 XAML 출력에 포함하려면 아래 PHP 예제와 같이 `true`와 함께 [setExportHiddenSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) 를 호출하십시오.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **생성된 모든 XAML 아티팩트 캡처하기**

XAML 내보내기는 내보낸 각 슬라이드에 대한 XAML 문서와 별도의 이미지 및 지원 리소스를 생성할 수 있습니다. 기본 파일 시스템 저장소 대신 이러한 아티팩트를 받으려면 사용자 지정 [IXamlOutputSaver](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloutputsaver/)를 [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/#setOutputSaver) 에 할당하십시오. XAML 옵션을 받아들이는 [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save) 오버로드를 사용하여 내보내기를 시작합니다.

PHP Java Bridge `java_closure` 함수는 PHP 객체를 Java 인터페이스로 노출합니다. 내보내기가 완료될 때까지 PHP 저장소와 프록시를 모두 유지하십시오. 인터페이스 링크는 프록시가 구현한 Java API를 가리킵니다.

### **콜백 수명 주기 이해**

내보내기 프로그램은 각각 생성된 아티팩트에 대해 [IXamlOutputSaver::save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) 를 별도로 호출합니다.

- `path`는 아티팩트를 식별하며 상대 디렉터리를 포함할 수 있습니다. XAML이 리소스를 상대 경로로 참조할 수 있으므로 이 정보를 보존하십시오.
- `data`는 아티팩트의 바이트를 포함합니다. 이미지 및 기타 바이너리 리소스는 텍스트로 디코딩해서는 안 됩니다.
- 저장소는 반환하기 전에 데이터를 보존하거나 영구 저장할 책임이 있습니다. 예제에서는 각 Java 바이트 배열을 응용 프로그램이 소유하는 PHP 바이너리 문자열로 변환합니다.
- 프레젠테이션 저장 작업이 반환되고 모든 콜백이 성공적으로 완료된 경우에만 내보내기를 성공으로 간주하십시오. 저장 오류를 무시하거나 백그라운드 쓰기를 시작하지 마십시오. 영속성이 이후에 이뤄지는 경우, 해당 단계가 성공할 때까지 전체 성공을 보고하지 않도록 하세요.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) 은 사용자 지정 저장소에도 적용됩니다. 기본값 `false`는 숨겨진 슬라이드의 XAML 문서를 제외합니다. `true`를 전달하면 숨겨진 슬라이드와 해당 내보내기에 필요한 모든 리소스가 포함됩니다. 리소스 수는 프레젠테이션마다 다르며, 슬라이드당 콜백 하나 또는 고정된 콜백 순서를 가정하지 마십시오.

### **메모리로 내보내고 아티팩트 검사하기**

이 전체 예제는 `pres.pptx`를 로드하고, 모든 아티팩트를 PHP 연관 배열의 바이너리 문자열로 수집한 뒤 이름, 유형 및 바이트 수를 출력합니다. 제공된 이름은 그대로 유지합니다. 중복 이름이 있으면 컬렉션을 무효로 처리하고 조용히 덮어쓰지 않습니다. 예제는 결과를 사용하기 전에 이를 확인합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // XAML만 선택적 검사를 위해 UTF-8 텍스트로 처리됩니다.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

확장자 검사는 검증에 유용합니다; 익숙하지 않은 리소스 유형도 모두 보존하십시오. 바이트를 저장하거나 전송할 때 그대로 유지하십시오. PHP 문자열은 바이너리 데이터를 보유할 수 있으며, 여기에는 널 바이트도 포함됩니다. XAML을 검사할 때만 문자열을 UTF-8 텍스트로 취급하고, 이미지나 리소스 바이트를 변환하지 마십시오.

### **수집된 아티팩트를 ZIP 아카이브에 패키징하기**

이 독립 예제는 내보내기를 수집하고, 이름을 검증한 뒤 원본 바이트를 ZIP 아카이브에 기록합니다. 전용 작업 디렉터리가 동시 내보내기 작업을 구분합니다. 이 예제는 ZIP 지원이 포함된 PHP Phar 확장이 필요합니다. ZIP 엔트리는 슬래시(`/`)를 사용하고 상대 디렉터리를 유지합니다. 비정상적인 이름이나 정규화 후 충돌이 발생하는 경우 전체 패키지를 기록하기 전에 거부합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

예제는 [PharData](https://www.php.net/manual/en/class.phardata.php) 를 사용하여 PHP 프로세스 작업 디렉터리에 로컬 ZIP 아카이브를 하나 기록합니다; 내보내기 프로그램 자체는 느슨한 XAML이나 이미지 파일을 기록하지 않습니다. 원격 저장소에 대해서는 수집된 바이너리 문자열을 업로드하는 단계로 아카이브 작성 단계를 교체하십시오. 내보내기 작업 식별자와 전체 상대 아티팩트 이름을 블롭 키로 사용하거나, 작업 식별자, 상대 이름 및 바이너리 데이터를 데이터베이스 행에 저장하십시오. 모든 업로드가 완료되거나 데이터베이스 트랜잭션이 커밋된 후에만 작업을 공개하십시오. 영속화에 실패하면 부분 출력을 정리하십시오.

대용량 프레젠테이션의 경우, 사용자 지정 저장소가 각 아티팩트를 직접 애플리케이션 저장소에 영속화하도록 하면 전체 내보내기를 애플리케이션 메모리에 추가로 보관하지 않아도 됩니다. 내보내기 프로그램 관점에서 각 콜백을 동기식으로 유지하십시오: 대상이 바이트를 수락한 후에만 반환하고, 실패가 호출자에게 전달되도록 하십시오.

### **리소스 이름 보존 및 참조 검증**

- 대상이 요구하는 경우 경로 구분자를 정규화하되, 상대 디렉터리는 보존하십시오. 모든 생성된 이름이 고유하고 리소스 참조가 유효하다는 것이 보장될 때만 [basename](https://www.php.net/manual/en/function.basename.php) 만 사용하십시오.
- 대상별 이름 검증을 적용하십시오. 느슨한 파일을 기록할 때는 루트 경로나 경로 이동 세그먼트를 거부하고, 대상을 절대 경로로 해결한 뒤 해당 경로가 의도된 내보내기 디렉터리 아래에 있는지(디렉터리 구분자를 포함하여) 확인하십시오. 심볼릭 링크가 쓰기를 리다이렉트할 수 없는 애플리케이션 제어 디렉터리를 사용하십시오.
- 각 내보내기 작업마다 별도의 저장소 네임스페이스와 저장소를 사용하십시오. 구분자 정규화 후 및 대상의 대소문자 민감도 규칙에 따라 충돌을 감지하십시오.
- 공개하기 전에 각 XAML 문서를 XML로 파싱하고 이미지 `Source` 또는 `ImageSource` 속성과 같은 파일 기반 리소스 참조를 검사하십시오. 각 상대 URI를 해당 XAML 아티팩트 디렉터리에 대해 해석하고, 결과 저장 이름을 정규화한 뒤 매핑 키, ZIP 엔트리 또는 저장 객체가 존재하는지 확인하십시오. 외부 URI와 XAML 마크업 표현식은 상대 파일 이름과 별도로 처리하십시오.

예를 들어, `pres/Slide_1.xaml`이 `images/image1.png`를 참조한다면, 저장된 리소스는 `pres/images/image1.png`로 존재해야 합니다. `image1.png`만 저장하면 해당 관계가 깨집니다. 객체 저장소의 경우 작업 접두사 아래에 동일한 레이아웃을 보존하고, 해당 리소스 URL이 XAML 소비자가 접근할 수 있도록 하십시오. 완료된 ZIP을 다시 열어 엔트리 이름과 리소스 바이트를 확인하고, 대상 XAML 환경에서 대표 슬라이드를 로드하여 이미지가 올바르게 해석되는지 검증하십시오.

## **FAQ**

**원본 폰트가 머신에 없을 경우 예측 가능한 폰트를 어떻게 보장할 수 있나요?**

[XamlOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/)의 [setDefaultRegularFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) 를 호출하십시오 — 내보내기 시 원본 폰트가 없을 경우 대체 폰트로 사용됩니다. 이는 생성된 XAML이 반드시 대체 폰트를 참조하거나 해당 폰트가 대상 머신에 존재한다는 것을 보장하지는 않습니다. XAML에서 참조하는 폰트가 표시되는 환경에 존재하도록 하십시오.

**내보낸 XAML이 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

Aspose.Slides는 공개 API를 통해 WPF XAML을 내보냅니다. UWP, Xamarin.Forms와 같은 다른 XAML 스택에 대한 호환성은 보장되지 않습니다. 목표 환경에서 생성된 마크업을 테스트하십시오.

**숨겨진 슬라이드가 지원되나요, 기본적으로 내보내지 않도록 하려면 어떻게 해야 하나요?**

기본적으로 숨겨진 슬라이드는 포함되지 않습니다. [setExportHiddenSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) 를 사용하여 이 동작을 제어할 수 있습니다 — 필요하지 않다면 비활성화된 상태로 유지하십시오.