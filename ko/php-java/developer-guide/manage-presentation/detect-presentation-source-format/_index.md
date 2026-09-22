---
title: PHP에서 원본 프레젠테이션 형식 결정
linktitle: 소스 형식
type: docs
weight: 35
url: /ko/php-java/detect-presentation-source-format/
keywords:
- 소스 형식
- 프레젠테이션 형식 감지
- 파워포인트
- 오픈문서
- 프레젠테이션
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PHP에서 로드된 프레젠테이션의 원본 형식을 읽고, 탐지 API를 비교하며, 파일, 스트림 및 레거시 형식을 처리합니다."
---
## **개요**

프레젠테이션을 로드한 후, 원래 형식을 확인하려면 [Presentation::getSourceFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getSourceFormat) 메서드를 호출합니다. 현재 인스턴스가 로드된 형식에 따라 후속 처리에 의존하는 경우에 사용합니다.

소스 형식은 출력 파일에 선택된 [SaveFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveformat/)과는 별개입니다. 다른 형식으로 저장해도 기존 인스턴스의 소스 형식은 변경되지 않습니다.

## **파일의 소스 형식 읽기**

이 예제는 기존 `sample.pptx` 파일이 필요합니다. 파일을 로드하고 파일 이름 대신 [Presentation::getSourceFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getSourceFormat) 를 사용하여 애플리케이션 처리 정책을 선택합니다. 다른 형식을 시도하려면 입력 경로를 변경하십시오. 예제는 선택된 정책을 출력합니다; 메시지를 애플리케이션 로직으로 교체하세요.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **지원되는 값 인식**

[SourceFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sourceformat/) 클래스는 다음 프레젠테이션 형식을 구분하는 정수 상수를 정의합니다. 아래 확장자는 원래 파일 이름을 복원한 것이 아니라 일반적인 확장자입니다.

| SourceFormat 값 | 확장자 | 형식 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 프레젠테이션 |
| `Pptx` | `.pptx` | Office Open XML 프레젠테이션 |
| `Pptm` | `.pptm` | 매크로 사용 Office Open XML 프레젠테이션 |
| `Pps` | `.pps` | PowerPoint 97–2003 슬라이드 쇼 |
| `Ppsx` | `.ppsx` | Office Open XML 슬라이드 쇼 |
| `Ppsm` | `.ppsm` | 매크로 사용 Office Open XML 슬라이드 쇼 |
| `Pot` | `.pot` | PowerPoint 97–2003 템플릿 |
| `Potx` | `.potx` | Office Open XML 템플릿 |
| `Potm` | `.potm` | 매크로 사용 Office Open XML 템플릿 |
| `Odp` | `.odp` | OpenDocument 프레젠테이션 |
| `Otp` | `.otp` | OpenDocument 프레젠테이션 템플릿 |
| `Fodp` | `.fodp` | Flat XML ODF 프레젠테이션 |
| `Xml` | `.xml` | PowerPoint XML 프레젠테이션 |

## **스트림의 소스 형식 읽기**

이 예제는 기존 `sample.pps` 파일이 필요합니다. 해당 파일의 바이트를 메모리 스트림으로 읽어들여 파일 이름 없이 데이터베이스 값이나 업로드된 바이트 배열과 같은 입력을 모델링합니다. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 생성자는 스트림만 받습니다.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS, 및 POT는 동일한 기본 바이너리 형식을 사용합니다. 파일 경로로 로드할 경우 확장자가 슬라이드 쇼 또는 템플릿을 구분하는 데 도움이 될 수 있습니다. 파일 이름이 없으면 레거시 PPS 및 POT 콘텐츠가 `SourceFormat::Ppt` 로 보고될 수 있습니다; 위의 PPS 예제는 `SourceFormat::Ppt` 의 정수 값을 출력합니다.

애플리케이션이 구분을 유지해야 한다면 원본 파일 이름이나 하위 유형 메타데이터를 별도로 보관하십시오. 확장자는 이러한 레거시 하위 유형에 유용한 힌트이지만 임의의 프레젠테이션 콘텐츠를 식별하는 유일한 기준으로 사용해서는 안 됩니다.

## **로드 전후 탐지 비교**

파일을 전체 프레젠테이션 객체 모델로 로드하기 전에 검사해야 할 경우 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationfactory/#getPresentationInfo) 및 [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationinfo/#getLoadFormat) 를 사용하십시오. 이미 인스턴스가 존재할 때는 [Presentation::getSourceFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getSourceFormat) 를 사용하십시오.

이 예제는 `sample.pptx`가 필요하며 각각 `LoadFormat::Pptx`와 `SourceFormat::Pptx`의 정수 값을 출력합니다. 실제 환경에서는 처리 단계에 맞는 API를 선택하십시오; 이미 로드된 프레젠테이션은 소스 형식을 얻기 위해 별도의 검사를 수행할 필요가 없습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

결과는 서로 다른 클래스의 상수를 사용합니다: [LoadFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadformat/) 및 [SourceFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sourceformat/). 숫자 값을 비교하거나 모든 형식이 동일한 탐지 결과를 가진다고 가정하지 마십시오. PowerPoint XML은 로드 전에는 `LoadFormat::Unknown` 로, 로드 후에는 `SourceFormat::Xml` 로 보고될 수 있습니다.

## **소스와 출력 형식을 구분 유지**

이 예제는 `sample.pptx`가 필요하고 `converted.odp`를 작성합니다. 원본 인스턴스를 저장하기 전후에 `SourceFormat::Pptx` 의 정수 값을 출력합니다. ODP 출력에서 로드된 새 인스턴스만 `Odp` 를 보고합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

`new Presentation()` 으로 처음부터 만든 프레젠테이션은 `SourceFormat::Pptx` 를 보고합니다. 입력 파일이 없으며, 이는 새로 만든 인스턴스의 기본값일 뿐 PPTX 파일이 로드되었다는 증거가 아닙니다. 구분이 필요하다면 애플리케이션이 인스턴스를 생성했는지 로드했는지 별도로 추적하십시오.

## **소스 형식을 확장자로 매핑**

다음 예제는 `sample.pptx`가 필요합니다. 현재 지원되는 모든 [SourceFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sourceformat/) 값을 입력 파일 이름을 파싱하지 않고 일반적인 확장자로 매핑합니다. 대체 로직은 인식되지 않은 값에 확장자를 조용히 할당하는 것을 방지합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

이 매핑은 파일을 변환하거나 스트림 로드 중에 손실된 레거시 PPS/POT 하위 유형을 복구하지 않습니다. 실제 저장 시에는 [SaveFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveformat/) 을 명시적으로 선택하거나 [원본 형식으로 프레젠테이션 저장](/slides/ko/php-java/save-presentation/#save-presentations-in-their-original-format) 에 표시된 변환을 사용하십시오.

## **저장 및 재열기로 형식 검증**

이 독립 실행형 예제는 프레젠테이션을 생성하고 작업 디렉터리에 세 개의 파일을 작성하며 동일한 이름의 파일을 덮어씁니다. 각 출력 파일을 경로와 메모리 스트림 모두를 통해 다시 엽니다. PPTX와 ODP의 경우 두 경로 모두 저장된 형식을 보고합니다. PPS의 경우 경로로 로드하면 `Pps` 를, 파일 이름 없이 같은 바이트를 로드하면 `Ppt` 를 보고합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

다음 표는 일치하는 확장자를 가진 프레젠테이션에 대한 소스 형식 식별을 요약합니다. 이름은 상수를 나타내며 PHP 예제는 해당 정수 값을 출력합니다:

| 저장 형식 | 파일 경로에서의 SourceFormat | 이름 없는 스트림에서의 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` 각각 | 파일 경로와 동일 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` 각각 | 파일 경로와 동일 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` 각각 | 파일 경로와 동일 |
| ODP, OTP | `Odp`, `Otp` 각각 | 파일 경로와 동일 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

이름 없는 스트림에서는 PPS/POT 콘텐츠가 `Ppt` 로 식별됩니다. 표는 형식 식별을 설명하며, 변환 중 모든 프레젠테이션 기능이 보존된다는 의미는 아닙니다.

## **FAQ**

**PPTX에서 로드한 프레젠테이션을 ODP로 저장하면 소스 형식이 변경합니까?**

아니요. 기존 인스턴스는 여전히 `Pptx` 를 보고합니다. 저장된 ODP 파일에서 로드한 인스턴스는 `Odp` 를 보고합니다.

**스트림이 레거시 프레젠테이션, 슬라이드 쇼 및 템플릿을 항상 구분할 수 있습니까?**

아니요. PPT, PPS, 및 POT는 바이너리 형식을 공유합니다. 구분이 필요할 경우 파일 이름이나 하위 유형 메타데이터를 별도로 보관하십시오.

**프레젠테이션이 이미 로드된 경우 어떤 API를 사용해야 합니까?**

[Presentation::getSourceFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getSourceFormat) 을 사용하십시오. 로드 전 검사를 위해서는 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationfactory/#getPresentationInfo) 를 사용하십시오.