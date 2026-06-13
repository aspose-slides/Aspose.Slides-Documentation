---
title: PHP에서 프레젠테이션 열기
linktitle: 프레젠테이션 열기
type: docs
weight: 20
url: /ko/php-java/open-presentation/
keywords:
- PowerPoint 열기
- OpenDocument 열기
- 프레젠테이션 열기
- PPTX 열기
- PPT 열기
- ODP 열기
- 프레젠테이션 로드
- PPTX 로드
- PPT 로드
- ODP 로드
- 보호된 프레젠테이션
- 대용량 프레젠테이션
- 외부 리소스
- 바이너리 객체
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides로 PowerPoint(.pptx, .ppt)와 OpenDocument(.odp) 프레젠테이션을 손쉽게 열 수 있습니다 — 빠르고 신뢰성 있으며 완전한 기능을 제공합니다."
---
## **소개**

스크래치에서 PowerPoint 프레젠테이션을 만드는 것뿐만 아니라, Aspose.Slides는 기존 프레젠테이션을 열 수도 있습니다. 프레젠테이션을 로드한 후에는 해당 정보을 가져오고, 슬라이드 내용을 편집하고, 새 슬라이드를 추가하거나 기존 슬라이드를 제거하는 등 다양한 작업을 수행할 수 있습니다.

## **프레젠테이션 열기**

기존 프레젠테이션을 열려면 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.

다음 PHP 예제는 프레젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```php
// Presentation 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.
$presentation = new Presentation("Sample.pptx");
try {
    // 프레젠테이션의 슬라이드 총 개수를 출력합니다.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **암호로 보호된 프레젠테이션 열기**

암호가 보호된 프레젠테이션을 열어야 할 경우, [LoadOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/) 클래스의 [setPassword](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setPassword) 메서드를 통해 암호를 전달하여 복호화하고 로드할 수 있습니다. 다음 PHP 코드가 이 작업을 시연합니다:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // 복호화된 프레젠테이션에 대한 작업을 수행합니다.
} finally {
    $presentation->dispose();
}
```

## **대용량 프레젠테이션 열기**

Aspose.Slides는 특히 [LoadOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/) 클래스의 [getBlobManagementOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) 메서드와 같은 옵션을 제공하여 대용량 프레젠테이션을 로드하는 데 도움을 줍니다.

다음 PHP 코드는 대용량 프레젠테이션(예: 2 GB)을 로드하는 방법을 보여줍니다:

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// KeepLocked 동작을 선택합니다—프레젠테이션 파일이 전체 수명 동안 잠긴 상태로 유지됩니다
// Presentation 인스턴스 동안은 메모리에 로드되거나 임시 파일에 복사될 필요가 없습니다.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // 대용량 프레젠테이션이 로드되었으며 사용할 수 있습니다. 메모리 사용량은 낮게 유지됩니다.

    // 프레젠테이션을 수정합니다.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // 프레젠테이션을 다른 파일로 저장합니다. 이 작업 동안 메모리 사용량은 낮게 유지됩니다.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// 이렇게 하지 마세요! 프레젠테이션 객체가 해제될 때까지 파일이 잠겨 있어 I/O 예외가 발생합니다.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// 여기서는 수행해도 괜찮습니다. 원본 파일은 이제 프레젠테이션 객체에 의해 잠겨 있지 않습니다.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
스트림을 사용할 때 발생하는 특정 제한을 우회하기 위해 Aspose.Slides는 스트림 내용이 복사될 수 있습니다. 스트림에서 대용량 프레젠테이션을 로드하면 프레젠테이션이 복사되어 로드 속도가 느려질 수 있습니다. 따라서 대용량 프레젠테이션을 로드해야 할 경우 스트림 대신 프레젠테이션 파일 경로를 사용하는 것을 강력히 권장합니다.

대용량 객체(비디오, 오디오, 고해상도 이미지 등)를 포함하는 프레젠테이션을 만들 때는 [BLOB management](/slides/ko/php-java/manage-blob/)를 사용하여 메모리 사용량을 줄일 수 있습니다.
{{%/alert %}}

## **외부 리소스 제어**

Aspose.Slides는 외부 리소스를 관리할 수 있는 [IResourceLoadingCallback](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iresourceloadingcallback/) 인터페이스를 제공합니다. 다음 PHP 코드는 `IResourceLoadingCallback` 인터페이스를 사용하는 방법을 보여줍니다:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // 대체 이미지를 로드합니다.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // 대체 URL을 설정합니다.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // 다른 모든 이미지를 건너뜁니다.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **임베디드 바이너리 객체 없이 프레젠테이션 로드하기**

PowerPoint 프레젠테이션에는 다음과 같은 유형의 임베디드 바이너리 객체가 포함될 수 있습니다:

- VBA 프로젝트([Presentation.getVbaProject](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getVbaProject))에 액세스 가능;
- OLE 객체 임베디드 데이터([OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData))에 액세스 가능;
- ActiveX 컨트롤 바이너리 데이터([Control.getActiveXControlBinary](https://reference.aspose.com/slides/ko/php-java/aspose.slides/control/#getActiveXControlBinary))에 액세스 가능.

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 메서드를 사용하면 임베디드 바이너리 객체가 전혀 없는 상태로 프레젠테이션을 로드할 수 있습니다.

이 메서드는 잠재적으로 악성인 바이너리 콘텐츠를 제거하는 데 유용합니다. 다음 PHP 코드는 임베디드 바이너리 콘텐츠가 전혀 없는 프레젠테이션을 로드하는 방법을 시연합니다:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // 프레젠테이션에 대한 작업을 수행합니다.
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**파일이 손상되어 열 수 없다는 것을 어떻게 알 수 있나요?**

로드 중에 구문 분석/포맷 검증 예외가 발생합니다. 이러한 오류는 종종 잘못된 ZIP 구조나 손상된 PowerPoint 레코드를 언급합니다.

**필수 폰트가 누락된 경우 어떻게 됩니까?**

파일은 열리지만 이후 [렌더링/내보내기](/slides/ko/php-java/convert-presentation/) 시 폰트가 대체될 수 있습니다. 런타임 환경에 [폰트 대체 구성](/slides/ko/php-java/font-substitution/)을 하거나 [필요한 폰트를 추가](/slides/ko/php-java/custom-font/)하십시오.

**열 때 임베디드 미디어(비디오/오디오)는 어떻게 처리됩니까?**

미디어는 프레젠테이션 리소스로 사용할 수 있게 됩니다. 미디어가 외부 경로를 통해 참조되는 경우 해당 경로가 환경에서 접근 가능하도록 해야 하며, 그렇지 않으면 [렌더링/내보내기](/slides/ko/php-java/convert-presentation/)에서 미디어가 누락될 수 있습니다.