---
title: PHP에서 프레젠테이션 저장
linktitle: 프레젠테이션 저장
type: docs
weight: 80
url: /ko/php-java/save-presentation/
keywords:
- PowerPoint 저장
- OpenDocument 저장
- 프레젠테이션 저장
- 슬라이드 저장
- PPT 저장
- PPTX 저장
- ODP 저장
- 파일에 프레젠테이션
- 스트림에 프레젠테이션
- 미리 정의된 보기 유형
- Strict Office Open XML 형식
- Zip64 모드
- 썸네일 새로 고침
- 저장 진행
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 Java와 함께 사용하여 프레젠테이션을 저장하는 방법을 알아보세요 — 레이아웃, 글꼴 및 효과를 유지하면서 PowerPoint 또는 OpenDocument로 내보냅니다."
---
## **개요**

[PHP에서 프레젠테이션 열기](/slides/ko/php-java/open-presentation/)에서는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 여는 방법을 설명합니다. 이 문서에서는 프레젠테이션을 만들고 저장하는 방법을 설명합니다. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스는 프레젠테이션의 내용을 포함합니다. 처음부터 프레젠테이션을 만들든 기존 프레젠테이션을 수정하든, 완료되면 저장해야 합니다. Aspose.Slides for PHP를 사용하면 **파일** 또는 **스트림**에 저장할 수 있습니다. 이 문서에서는 프레젠테이션을 저장하는 다양한 방법을 설명합니다.

## **프레젠테이션을 파일에 저장**

[Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 `save` 메서드를 호출하여 프레젠테이션을 파일에 저장합니다. 메서드에 파일 이름과 저장 형식을 전달합니다. 다음 예제는 Aspose.Slides를 사용해 프레젠테이션을 저장하는 방법을 보여줍니다.

```php
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation();
try {
    // 여기서 작업을 수행합니다...

    // 프레젠테이션을 파일에 저장합니다.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **프레젠테이션을 스트림에 저장**

출력 스트림을 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 `save` 메서드에 전달하여 프레젠테이션을 스트림에 저장할 수 있습니다. 프레젠테이션은 다양한 스트림 유형으로 기록될 수 있습니다. 아래 예제에서는 새 프레젠테이션을 만들고 파일 스트림에 저장합니다.

```php
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // 프레젠테이션을 스트림에 저장합니다.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 [ViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/) 클래스를 통해 생성된 프레젠테이션이 열릴 때 PowerPoint가 사용하는 초기 보기를 설정할 수 있습니다. [ViewType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewtype/) 열거형의 값을 사용하여 [setLastView](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/#setLastView) 메서드를 호출합니다.

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Strict Office Open XML 형식으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 Strict Office Open XML 형식으로 프레젠테이션을 저장할 수 있습니다. 저장할 때 [PptxOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptxoptions/) 클래스를 사용하고 conformance 속성을 설정합니다. [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ko/php-java/aspose.slides/conformance/#Iso29500_2008_Strict)를 설정하면 출력 파일이 Strict Office Open XML 형식으로 저장됩니다.

아래 예제는 프레젠테이션을 만들고 Strict Office Open XML 형식으로 저장합니다.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation();
try {
    // 프레젠테이션을 Strict Office Open XML 형식으로 저장합니다.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Zip64 모드에서 Office Open XML 형식으로 프레젠테이션 저장**

Office Open XML 파일은 ZIP 아카이브이며, 압축되지 않은 파일 크기, 압축된 파일 크기 및 아카이브 전체 크기에 4 GB(2^32 바이트) 제한을 적용하고, 아카이브에 포함될 수 있는 파일 수를 65,535(2^16‑1)개로 제한합니다. ZIP64 형식 확장은 이러한 제한을 2^64까지 높입니다.

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptxoptions/#setZip64Mode) 메서드를 사용하면 Office Open XML 파일을 저장할 때 ZIP64 형식 확장을 언제 사용할지 선택할 수 있습니다.

이 메서드는 다음 모드와 함께 사용할 수 있습니다:

- [IfNecessary](https://reference.aspose.com/slides/ko/php-java/aspose.slides/zip64mode/#IfNecessary) 은(는) 프레젠테이션이 위 제한을 초과할 경우에만 ZIP64 형식 확장을 사용합니다. 기본 모드입니다.
- [Never](https://reference.aspose.com/slides/ko/php-java/aspose.slides/zip64mode/#Never) 은(는) ZIP64 형식 확장을 절대 사용하지 않습니다.
- [Always](https://reference.aspose.com/slides/ko/php-java/aspose.slides/zip64mode/#Always) 은(는) 항상 ZIP64 형식 확장을 사용합니다.

다음 코드는 ZIP64 형식 확장이 활성화된 상태로 PPTX로 프레젠테이션을 저장하는 방법을 보여줍니다:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="주의" color="warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/ko/php-java/aspose.slides/zip64mode/#Never) 로 저장하면 프레젠테이션을 ZIP32 형식으로 저장할 수 없을 경우 [PptxException](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptxexception/) 이 발생합니다.
{{% /alert %}}

## **썸네일을 새로 고치지 않고 프레젠테이션 저장**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 메서드는 PPTX로 프레젠테이션을 저장할 때 썸네일 생성 여부를 제어합니다:

- `true` 로 설정하면 저장 중에 썸네일이 새로 고쳐집니다. 기본값입니다.
- `false` 로 설정하면 현재 썸네일이 유지됩니다. 프레젠테이션에 썸네일이 없으면 새로 생성되지 않습니다.

아래 코드에서는 썸네일을 새로 고치지 않고 PPTX로 프레젠테이션을 저장합니다.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="정보" color="info" %}}
이 옵션은 PPTX 형식으로 프레젠테이션을 저장하는 데 걸리는 시간을 줄이는 데 도움이 됩니다.
{{% /alert %}}

## **진행 상황을 백분율로 업데이트**

저장 진행 보고는 [SaveOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveoptions/)와 그 하위 클래스의 [setProgressCallback](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveoptions/#setProgressCallback) 메서드를 통해 구성합니다. [IProgressCallback](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iprogresscallback/) 인터페이스를 구현하는 Java 프록시를 제공하면, 내보내기 동안 콜백이 주기적인 백분율 업데이트를 받습니다.

다음 코드 스니펫은 `IProgressCallback` 사용 방법을 보여줍니다.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // 여기에서 진행률 백분율 값을 사용합니다.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="정보" color="info" %}}
Aspose는 자체 API를 사용하여 [무료 PowerPoint 분할기 앱](https://products.aspose.app/slides/ko/splitter)을 개발했습니다. 이 앱을 사용하면 선택한 슬라이드를 새로운 PPTX 또는 PPT 파일로 저장하여 프레젠테이션을 여러 파일로 분할할 수 있습니다.
{{% /alert %}}

## **FAQ**

**"fast save"(증분 저장)가 지원되어 변경된 부분만 기록되나요?**

아니요. 저장할 때마다 전체 대상 파일이 생성되며, 증분 "fast save"는 지원되지 않습니다.

**여러 스레드에서 동일한 Presentation 인스턴스를 저장해도 스레드 안전합니까?**

아니요. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 인스턴스는 [스레드 안전하지 않음](/slides/ko/php-java/multithreading/)으로, 단일 스레드에서 저장해야 합니다.

**하이퍼링크와 외부 연결 파일은 저장 시 어떻게 처리되나요?**

[Hyperlinks](/slides/ko/php-java/manage-hyperlinks/) 은(는) 보존됩니다. 외부 링크 파일(예: 상대 경로를 사용하는 비디오)은 자동으로 복사되지 않으므로, 참조된 경로가 계속 접근 가능하도록 해야 합니다.

**문서 메타데이터(작성자, 제목, 회사, 날짜 등)를 설정/저장할 수 있나요?**

예. 표준 [문서 속성](/slides/ko/php-java/presentation-properties/)이 지원되며, 저장 시 파일에 기록됩니다.