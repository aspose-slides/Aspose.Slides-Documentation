---
title: PHP에서 프레젠테이션 열기
linktitle: 프레젠테이션 열기
type: docs
weight: 20
url: /ko/php-java/open-presentation/
keywords:
- PowerPoint 열기
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
description: "PHP에서 PowerPoint 및 OpenDocument 프레젠테이션을 여는 방법, 열기 비밀번호 제공, 리소스 로딩 제어, 그리고 Aspose.Slides for PHP via Java를 사용하여 메모리 사용량을 줄이는 방법을 학습합니다."
---
## **소개**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/ko/php-java/)는 파일 및 스트림에서 PowerPoint 및 OpenDocument 프레젠테이션을 로드할 수 있습니다. 프레젠테이션을 로드한 후에는 구조를 검사하고, 슬라이드를 편집하며, 리소스를 관리하고, 원본 또는 다른 지원 형식으로 저장할 수 있습니다.

로드 동작은 [LoadOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/) 클래스를 통해 맞춤 설정할 수 있습니다. 예를 들어, 열기 비밀번호를 제공하거나, 큰 바이너리 객체를 Java 힙 메모리 외부에 보관하거나, 외부 리소스를 제어하거나, 임베드된 바이너리 데이터를 생략할 수 있습니다.

## **프레젠테이션 열기**

파일 또는 스트림을 로드한 후에는 [원본 프레젠테이션 형식 확인](/slides/ko/php-java/detect-presentation-source-format/)을 통해 애플리케이션이 이를 어떻게 처리할지 선택할 수 있습니다.

기존 프레젠테이션을 열려면 해당 파일 경로를 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 생성자에 전달하세요. 사용 후에는 프레젠테이션을 해제하여 파일 핸들, 임시 데이터 및 기타 리소스가 즉시 해제되도록 해야 합니다.

다음 PHP 예제는 프레젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **비밀번호로 보호된 프레젠테이션 열기**

열기 비밀번호는 프레젠테이션 내용을 암호화합니다. 전체 프레젠테이션을 로드하려면 올바른 비밀번호를 [LoadOptions::setPassword](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setPassword)에 전달하고 해당 옵션을 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 생성자에 제공하세요. 비밀번호가 없거나 틀리면 로드가 실패합니다.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

비밀번호 감지, 검증 및 암호화 워크플로에 대해서는 [Password-Protect Presentations](/slides/ko/php-java/password-protected-presentation/)를 참조하세요. 암호화된 프레젠테이션이 공개 문서 속성을 포함하도록 저장된 경우, 비밀번호 없이 해당 속성을 읽을 수 있습니다. 자세한 내용은 [Manage Presentation Properties](/slides/ko/php-java/presentation-properties/)를 확인하십시오.

## **대용량 프레젠테이션 열기**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) 메서드는 이미지, 오디오, 비디오와 같은 대용량 바이너리 객체를 Aspose.Slides가 어떻게 처리할지 제어하는 옵션을 반환합니다. 소스 파일을 잠금 상태로 유지하거나, 임시 파일을 허용하거나, 메모리에 유지되는 BLOB 데이터 양을 제한할 수 있습니다.

다음 PHP 코드는 2 GB와 같은 대용량 프레젠테이션을 로드하는 방법을 보여줍니다:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked)을 사용하면 프레젠테이션 인스턴스가 해제될 때까지 소스 파일이 잠긴 상태로 유지됩니다. 해당 인스턴스가 살아 있는 동안 소스 파일을 이동, 덮어쓰기 또는 삭제하지 마십시오.

Aspose.Slides는 로드 중에 입력 스트림의 내용을 복사할 수 있습니다. 대용량 프레젠테이션의 경우 파일 경로가 일반적으로 스트림보다 효율적입니다. 추가 저장 및 메모리 관리 옵션은 [Manage BLOBs](/slides/ko/php-java/manage-blob/)를 확인하십시오.
{{% /alert %}}

## **외부 리소스 제어**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback)은 PHP/Java Bridge를 통해 Java의 [IResourceLoadingCallback](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iresourceloadingcallback/) 인터페이스 구현을 받아들입니다. 콜백을 사용하여 교체 데이터를 제공하거나, 리소스를 재지정하거나, 기본 로더를 사용하거나, 리소스를 건너뛸 수 있습니다. 이는 프레젠테이션에 포함된 외부 이미지가 애플리케이션 고유의 보안 또는 저장 규칙에 따라 해결되어야 할 때 유용합니다.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **임베드된 바이너리 객체가 없는 프레젠테이션 로드**

프레젠테이션에 애플리케이션이 필요 없거나 보관하고 싶지 않은 임베드된 바이너리 데이터가 포함될 수 있습니다. 예시:

- VBA 프로젝트, [Presentation::getVbaProject](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getVbaProject)로 접근 가능;
- 임베드된 OLE 데이터, [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData)로 접근 가능;
- ActiveX 컨트롤 데이터, [Control::getActiveXControlBinary](https://reference.aspose.com/slides/ko/php-java/aspose.slides/control/#getActiveXControlBinary)로 접근 가능.

[LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects)를 `true`로 설정하면 로드 중에 이러한 바이너리 데이터를 제거합니다. 로드된 프레젠테이션을 저장하여 정제된 결과를 지속하십시오.

이 옵션은 원하지 않는 임베드된 페이로드에 대한 노출을 감소시키지만, 완전한 악성코드 탐지 또는 콘텐츠 정화 시스템은 아닙니다.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**파일이 손상되어 열 수 없다는 것을 어떻게 알 수 있나요?**

Aspose.Slides는 로드 중에 구문 분석 또는 형식 예외를 발생시킵니다. 잘못된 비밀번호 오류와는 별도로 해당 실패를 처리하여 애플리케이션이 원인을 정확히 보고할 수 있도록 하세요.

**필수 글꼴이 누락되면 어떻게 되나요?**

프레젠테이션은 여전히 로드되지만 렌더링 및 내보내기 시 글꼴이 대체될 수 있습니다. 출력이 더 예측 가능하도록 [글꼴 대체 구성](/slides/ko/php-java/font-substitution/)하거나 [맞춤 글꼴 제공](/slides/ko/php-java/custom-font/)을 사용할 수 있습니다.

**프레젠테이션을 로드하면 임베드된 미디어도 함께 로드되나요?**

임베드된 오디오와 비디오는 프레젠테이션 객체 모델을 통해 사용할 수 있게 됩니다. 외부 리소스는 구성된 리소스 로딩 동작에 따라 해결되며, 해당 위치에 접근할 수 없으면 사용할 수 없습니다.