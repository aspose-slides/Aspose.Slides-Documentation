---
title: PHP에서 프레젠테이션 경고 처리
type: docs
weight: 90
url: /ko/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 경고 콜백
- 경고 정책
- 데이터 손실
- 소스 손상
- 호환성 문제
- 글꼴 대체
- 디지털 서명
- 프레젠테이션 로드
- 프레젠테이션 렌더링
- 프레젠테이션 변환
- 프레젠테이션 저장
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 프레젠테이션을 로드, 렌더링, 변환 및 저장하는 동안 경고를 수집, 분류 및 처리하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides는 프레젠테이션을 로드, 렌더링, 변환 또는 저장하는 동안 복구 가능한 문제를 보고할 수 있습니다. 예에는 손상된 원본 레코드, 보존할 수 없는 콘텐츠, 글꼴 대체 및 대상 형식의 제한이 포함됩니다. 경고 콜백을 사용하면 애플리케이션이 이러한 조건을 기록하고 현재 작업을 계속할지 여부를 결정할 수 있습니다.

PHP 클래스를 `warning` 공개 메서드와 함께 생성하고 이를 PHP Java Bridge를 통해 Java [IWarningCallback](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarningcallback/) 인터페이스로 `java_closure`를 사용해 노출합니다. [IWarningInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/)를 통해 제공되는 [getWarningType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/#getWarningType--) 및 [getDescription](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/#getDescription--) 값을 확인합니다. 경고를 받아들일 경우 [ReturnAction::Continue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/returnaction/#Continue) 를 반환하고, 작업을 중지하려면 [ReturnAction::Abort](https://reference.aspose.com/slides/ko/php-java/aspose.slides/returnaction/#Abort) 를 반환합니다.

프레젠테이션을 열 때 발생하는 경고는 [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setWarningCallback) 로 처리합니다. 렌더링 및 내보내기 옵션 클래스는 슬라이드 렌더링, 변환 및 저장 시 발생하는 경고를 수신하는 [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveoptions/#setWarningCallback) 를 상속합니다. 경고 자체가 애플리케이션 작업을 식별하지 않으므로, 결합된 보고서를 만들 때 각 콜백 인스턴스를 작업 단계와 연결하십시오.

## **경고 및 예외**

Java 예외는 PHP Java Bridge를 통해 PHP에 노출됩니다; 아래 예제와 같이 작업 경계에서 이를 잡아야 합니다. 이 문서의 Java 인터페이스 링크는 브리지에서 사용되는 콜백 계약을 설명합니다.

경고는 콜백이 `ReturnAction::Continue` 를 반환하면 Aspose.Slides가 복구할 수 있는 조건을 설명합니다. 예외는 요청된 작업을 정상적으로 완료할 수 없음을 의미하며, 예외는 경고로 변환되지 않으며 경고 정책으로 처리할 수 없습니다.

`ReturnAction::Abort` 를 반환하면 경고 디스패처가 예외를 발생시켜 현재 작업을 종료하도록 요청합니다. 공개 예외는 작업 및 프레젠테이션 형식에 따라 달라집니다. 예를 들어, 로드 시에는 [PptxReadException](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptxreadexception/) 또는 [PptReadException](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptreadexception/) 이 발생할 수 있고, 저장 또는 내보내기 시에는 [PptxException](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptxexception/) 이 발생할 수 있습니다. 작업 경계에서 예외를 처리하고, 경고 보고서를 사용해 애플리케이션 정책이 종료 원인인지 판단하십시오. 콜백은 `ReturnAction::Abort` 를 반환하기 전에 경고를 기록하므로 이유가 애플리케이션에 남습니다.

## **경고 범주**

[WarningType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/warningtype/) 클래스는 다음 범주에 대한 정수 상수를 제공합니다.

| 경고 유형 | 의미 | 일반 정책 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ko/php-java/aspose.slides/warningtype/#SourceFileCorruption) | 원본 프레젠테이션에 손상이 있어 원본 형식으로 저장된 문서를 사용할 수 없게 될 수 있습니다. | 중단. |
| [DataLoss](https://reference.aspose.com/slides/ko/php-java/aspose.slides/warningtype/#DataLoss) | 로드 또는 저장 후 텍스트, 차트, 이미지 또는 기타 데이터가 누락될 수 있습니다. | 중단. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ko/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | 프레젠테이션이 중요한 서식 손실을 겪을 수 있습니다. | 엄격한 검증 모드에서는 중단; 그렇지 않으면 기록하고 계속. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ko/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | 제한적인 서식 차이가 발생할 수 있습니다. | 진단을 위해 기록하고 계속. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/warningtype/#CompatibilityIssue) | 결과가 일부 애플리케이션이나 이전 버전에서 열리거나 정상 동작하지 않을 수 있습니다. | 호환성이 필수적이지 않다면 로그를 남기고 계속. |
| [UnexpectedContent](https://reference.aspose.com/slides/ko/php-java/aspose.slides/warningtype/#UnexpectedContent) | 원본에 지원되지 않거나 인식되지 않은 콘텐츠가 포함되어 영향이 아직 알려지지 않았습니다. | 기록하고 계속하거나, 엄격한 정책에서는 오류로 처리. |

카테고리는 정책 결정을 주도해야 합니다. 진단을 위해 [getDescription](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/#getDescription--) 로 반환된 값을 저장하지만, 메시지 텍스트는 시나리오 및 제품 버전에 따라 달라질 수 있으므로 로직에서는 사용하지 마세요.

## **경고 수집 및 분류**

다음 예제는 전체 처리 파이프라인에 대한 하나의 애플리케이션 수준 보고서를 사용합니다. 별도의 콜백 인스턴스가 로드, 렌더링, PDF 변환 및 PPTX 저장 단계의 경고에 라벨을 붙입니다. 정책은 원본 손상 또는 데이터 손실 시 중단하고, 필요에 따라 주요 서식 손실 시에도 중단하며, 다른 경고는 계속합니다. 콜백은 `java_values` 로 경고 값을 PHP 네이티브 값으로 변환한 뒤 기록 및 비교합니다.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

`WarningPolicy` 를 구성할 때 주요 서식 차이가 허용된다면 `abortOnMajorFormattingLoss` 에 `false` 를 전달합니다. 호환성 문제, 소규모 서식 손실 및 예상치 못한 콘텐츠는 작업이 계속되더라도 보고서에 그대로 남습니다. 애플리케이션이 해당 카테고리를 모두 거부해야 한다면 `WarningPolicy::getAction` 을 확장하십시오.

## **일반적인 경고 시나리오**

경고는 워크플로우의 다양한 단계에서 나타날 수 있습니다:

- **디지털 서명:** 서명된 프레젠테이션을 로드하는 동안 서명이 처리 중에 손실될 것이라는 경고가 발생할 수 있습니다. Aspose.Slides는 이 `DataLoss` 조건을 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationsignedwarninginfo/) 로 보고합니다. 로드 단계 콜백을 사용해 파일을 거부하거나 보고된 손실을 명시적으로 수락할 수 있습니다.
- **글꼴 대체:** 슬라이드가 렌더링되거나 내보내질 때 사용할 수 없는 글꼴이 다른 글꼴로 교체될 수 있습니다. 글꼴 대체 경고는 `DataLoss` 로 보고되므로, 앞서 정의한 엄격한 정책은 해당 교체가 시각적으로 허용 가능하더라도 중단합니다. 런타임에 사용할 수 없는 글꼴이 포함된 입력 프레젠테이션을 사용해 이 동작을 확인하십시오. 경고 설명에 대체 글꼴이 표시되므로 필요한 글꼴을 설치하거나 [글꼴 대체 규칙](/slides/ko/php-java/font-substitution/)을 구성한 뒤 다시 시도하십시오.
- **지원되지 않거나 예상치 못한 콘텐츠:** 로더가 인식하지 못하는 프레젠테이션 레코드나 기능을 만나면 경고가 발생할 수 있습니다. 이러한 경고는 `UnexpectedContent` 또는 데이터·서식에 영향을 미치는 경우 더 심각한 범주를 사용할 수 있습니다.
- **형식 호환성:** 다른 프레젠테이션 형식으로 저장하면 기능이 누락되거나 일부 애플리케이션에서 동작이 달라질 수 있습니다. 예를 들어, 8개 초과의 수평 또는 수직 그리기 가이드를 포함한 프레젠테이션을 기존 PPT 형식으로 저장하면 `CompatibilityIssue` 가 보고됩니다. 저장 단계 콜백은 손실을 기록하고 계속하거나, 모든 가이드를 유지해야 한다면 거부할 수 있습니다.
- **로드 동작:** 로드 옵션 및 레거시 동작도 경고를 생성할 수 있습니다. 예를 들어, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) 은 구식 프레젠테이션 잠금 동작 사용을 `CompatibilityIssue` 로 식별합니다.

경고는 원본 문서, 대상 형식, 작업 및 Aspose.Slides 버전에 따라 다릅니다. 모든 파일이 경고를 발생시킨다거나 시나리오가 하나의 범주에만 매핑된다고 가정하지 마세요.

## **중단된 작업을 안전하게 처리**

콜백이 `ReturnAction::Abort` 를 반환하면 로드에 실패한 객체를 사용하지 말고, 렌더링 또는 저장 결과가 완전하다고 가정하지 마십시오. 작업은 출력 파일을 생성했지만 아직 완성되지 않은 상태에서 종료될 수 있습니다.

검증된 결과는 `validated-output.pptx` 와 같이 별도 경로에 저장하십시오. 작업이 성공적으로 완료되고 경고 보고서가 정책을 만족하며 출력 파일을 열어 확인할 수 있을 때만 기존 프레젠테이션을 교체하십시오. 이렇게 하면 부분적으로 생성되었거나 거부된 결과가 유효한 소스 파일을 덮어쓰는 일을 방지할 수 있습니다.

빈 경고 보고서는 모든 소스 기능이 보존되었다는 보장이 아닙니다. 애플리케이션에서 요구하는 추가 콘텐츠 및 시각 검사를 수행하십시오. 또한 [프레젠테이션 열기](/slides/ko/php-java/open-presentation/) 와 [프레젠테이션 저장](/slides/ko/php-java/save-presentation/) 도 참고하십시오.

## **FAQ**

**경고 콜백이 모든 Aspose.Slides 오류를 처리할 수 있나요?**

아니요. 콜백은 경고로 보고되는 복구 가능한 상황만 처리합니다. 콜백과 무관하게 발생하는 예외는 로드, 렌더링, 변환 또는 저장 호출을 둘러싼 애플리케이션 코드에서 처리해야 합니다.

**`ReturnAction::Continue` 를 반환하면 동일한 출력이 보장되나요?**

아니요. 이는 처리 계속을 허용할 뿐이며, 보고된 상황으로 인해 데이터, 서식 또는 호환성 차이가 발생할 수 있습니다. 수집된 경고 유형 및 설명을 검토하십시오.

**애플리케이션이 경고를 발생시킨 작업을 어떻게 식별하나요?**

예제와 같이 각 작업마다 콜백 인스턴스를 만들고, [getWarningType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/#getWarningType--) 및 [getDescription](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarninginfo/#getDescription--) 로 반환된 값과 함께 애플리케이션 정의 단계 정보를 저장하십시오.