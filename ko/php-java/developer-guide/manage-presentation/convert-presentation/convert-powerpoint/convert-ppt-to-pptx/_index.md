---
title: PHP에서 PPT를 PPTX로 변환
linktitle: PPT를 PPTX로
type: docs
weight: 20
url: /ko/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPT를 PPTX로
- PPT를 PPTX로 저장
- PPT를 PPTX로 내보내기
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 레거시 PPT 파일을 PPTX로 변환합니다. 단일 파일 및 배치 변환, 오류 처리, 정밀도에 대한 PHP 예제가 포함되어 있습니다."
---
## **개요**

PPT는 레거시 바이너리 PowerPoint 형식이며, PPTX는 최신 Open XML 형식입니다. Aspose.Slides for PHP via Java는 Microsoft PowerPoint 없이 PPT 파일을 로드하고 PPTX로 저장할 수 있습니다. 이 문서에서는 파일 하나 또는 디렉터리의 파일들을 변환하는 방법과 변환 후 확인해야 할 사항을 설명합니다.

## **PPT 파일을 PPTX로 변환**

소스 파일을 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스로 로드한 다음, [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save) 메서드를 [SaveFormat::Pptx](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveformat/#Pptx)와 함께 호출합니다. `finally` 블록은 프레젠테이션을 처리하고 리소스를 해제합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// 레거시 PPT 프레젠테이션을 로드합니다.
$presentation = new Presentation("presentation.ppt");
try {
    // 프레젠테이션을 PPTX 형식으로 저장합니다.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

파일 확장자는 자체적으로 출력 형식을 선택하지 않으며, [SaveFormat::Pptx](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveformat/#Pptx) 인수가 이를 지정합니다. 원본 PPT 파일을 유지해야 하는 경우 입력 경로와 출력 경로를 다르게 설정하십시오.

## **여러 PPT 파일 변환**

다음 예제는 하나의 디렉터리에서 모든 `.ppt` 파일을 변환합니다. 각 파일은 독립적으로 처리되므로 하나의 변환이 실패해도 나머지 배치가 중단되지 않습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

프로덕션 작업에서는 전체 예외를 로그에 기록하고, 기존 출력 파일을 덮어쓸지 여부를 결정하며, 실패한 파일 이름을 재시도 또는 검토 큐에 기록하십시오. 손상된 파일, 필요한 비밀번호 없이 열려진 암호 보호 파일, 접근 불가능한 경로, 지원되지 않는 콘텐츠는 모두 변환 실패를 초래할 수 있습니다. 암호화된 파일을 로드하는 방법은 [Password-Protected Presentations](/slides/ko/php-java/password-protected-presentation/)를 참고하십시오.

## **정밀도와 레거시 기능**

변환은 일반적으로 슬라이드, 마스터, 레이아웃, 텍스트, 도형, 이미지, 표, 차트를 보존합니다. 그러나 PPT와 PPTX는 모든 기능을 정확히 동일하게 표현하지 않습니다. PPTX에 해당하는 것이 없거나 라이브러리에서 지원되지 않는 레거시 기능은 정규화되거나 생략되거나 다르게 표시될 수 있습니다.

변환된 파일에 애니메이션, 전환, 삽입 또는 연결된 OLE 객체, ActiveX 컨트롤, 포함된 미디어, 일반적이지 않은 글꼴 또는 VBA 매크로가 포함된 경우 확인하십시오. 일반 PPTX 파일은 매크로 지원 형식이 아니므로 VBA를 유지해야 할 경우 적절한 매크로 지원 워크플로를 사용하십시오. 또한 변환된 프레젠테이션이 열리거나 렌더링될 환경에 필요한 글꼴과 외부 리소스가 존재하는지도 확인하십시오.

중요 문서의 경우, 생성된 PPTX를 프로그래밍 방식으로 다시 열어 핵심 슬라이드 수와 내용을 검사한 뒤, 의도된 뷰어에서 외관 및 슬라이드쇼 동작을 비교하십시오. 성공적인 [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save) 호출을 모든 레거시 기능이 정확히 PPTX로 변환되었다는 증거로 간주하지 마십시오.

## **PPTX를 사용해야 할 때**

프레젠테이션이 최신 PowerPoint 버전에서 편집되거나 Open XML 패키지를 사용하는 시스템과 교환되거나 레거시 바이너리 PPT보다 검토 및 복구가 쉬운 형식으로 저장될 경우 PPTX를 사용하십시오. 변환된 프레젠테이션이 정밀성 검사를 통과할 때까지 원본 PPT를 보관 또는 롤백 복사본으로 유지하십시오.

PDF, HTML, 이미지, XPS 또는 다른 출력 형식이 필요한 경우, 모든 대상이 편집 가능한 PowerPoint 기능을 유지한다고 가정하지 말고 [Convert Presentations to Multiple Formats](/slides/ko/php-java/convert-presentation/)의 형식별 안내를 따르십시오.

## **온라인 변환기**

가끔 파일을 변환하거나 빠르게 비교하려면 [online PPT to PPTX converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)를 사용할 수 있습니다. 반복 가능한 변환, 배치 처리 또는 애플리케이션 수준 오류 처리를 위해서는 PHP API를 사용하십시오.

## **관련 기사**

- [PPT와 PPTX](/slides/ko/php-java/ppt-vs-pptx/)
- [PHP에서 프레젠테이션 저장](/slides/ko/php-java/save-presentation/)
- [지원되는 파일 형식](/slides/ko/php-java/supported-file-formats/)
- [PHP에서 프레젠테이션 열기](/slides/ko/php-java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint 없이 PPT를 PPTX로 변환할 수 있나요?**

예. Aspose.Slides for PHP via Java는 Microsoft PowerPoint 없이 프레젠테이션 파일을 로드하고 저장합니다.

**PPT에서 PPTX로의 변환이 모든 내용을 정확히 보존합니까?**

일반 프레젠테이션 콘텐츠는 보존하지만, 모든 레거시 또는 지원되지 않는 기능에 대해 정확한 정밀도가 보장되지는 않습니다. 매크로, OLE 또는 ActiveX 객체, 미디어, 특수 애니메이션 또는 일반적이지 않은 글꼴이 포함된 경우 생성된 파일을 검토하십시오.

**암호 보호된 PPT 파일을 변환할 수 있나요?**

예, 파일을 로드할 때 올바른 비밀번호를 제공하면 가능합니다. 비밀번호가 없거나 잘못된 경우 로드 작업이 실패합니다.

**변환 후 PPT 파일을 삭제해야 하나요?**

중요한 뷰어와 워크플로에서 PPTX를 확인할 때까지 원본을 유지하십시오. 레거시 기능이 다르게 변환되는 경우 롤백 복사본을 제공합니다.