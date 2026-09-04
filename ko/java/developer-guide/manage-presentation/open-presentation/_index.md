---
title: Java에서 프레젠테이션 열기
linktitle: 프레젠테이션 열기
type: docs
weight: 20
url: /ko/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Java에서 PowerPoint 및 OpenDocument 프레젠테이션을 여는 방법, 열기 비밀번호 제공, 리소스 로딩 제어, Aspose.Slides for Java로 메모리 사용량 감소에 대해 알아보세요."
---
## **소개**

[Aspose.Slides for Java](https://products.aspose.com/slides/ko/java/)는 파일 및 스트림에서 PowerPoint 및 OpenDocument 프레젠테이션을 로드할 수 있습니다. 프레젠테이션이 로드된 후에는 구조를 검사하고, 슬라이드를 편집하고, 리소스를 관리하며, 원본 또는 다른 지원되는 형식으로 저장할 수 있습니다.

로드 동작은 [LoadOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/) 클래스를 통해 사용자 지정할 수 있습니다. 예를 들어, 열기 비밀번호를 제공하고, 큰 바이너리 객체를 Java 힙 메모리 외부에 보관하며, 외부 리소스를 제어하거나, 임베드된 바이너리 데이터를 생략할 수 있습니다.

## **프레젠테이션 열기**

기존 프레젠테이션을 열려면 파일 경로를 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 생성자에 전달합니다. 사용 후 프레젠테이션을 폐기하여 파일 핸들, 임시 데이터 및 기타 리소스가 즉시 해제되도록 합니다.

다음 Java 예제는 프레젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **비밀번호로 보호된 프레젠테이션 열기**

열기 비밀번호는 프레젠테이션 내용을 암호화합니다. 전체 프레젠테이션을 로드하려면 올바른 비밀번호를 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)에 전달하고, 해당 옵션을 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 생성자에 제공하십시오. 비밀번호가 없거나 올바르지 않으면 로드에 실패합니다.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

비밀번호 감지, 검증 및 암호화 워크플로에 대해서는 [Password‑Protect Presentations](/slides/ko/java/password-protected-presentation/)를 참조하십시오. 암호화된 프레젠테이션이 의도적으로 공개 문서 속성으로 저장된 경우, 비밀번호 없이 해당 속성을 읽을 수 있습니다; 자세히는 [Manage Presentation Properties](/slides/ko/java/presentation-properties/)를 보세요.

## **대용량 프레젠테이션 열기**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--)는 이미지, 오디오 및 비디오와 같은 대용량 바이너리 객체를 Aspose.Slides가 처리하는 방식을 제어하는 옵션을 반환합니다. 소스 파일을 잠금 상태로 유지하고, 임시 파일을 허용하며, 메모리에 유지되는 BLOB 데이터 양을 제한할 수 있습니다.

다음 Java 코드는 대용량 프레젠테이션(예: 2GB)을 로드하는 방법을 보여줍니다:

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
PresentationLockingBehavior.KeepLocked을 사용하면 프레젠테이션 인스턴스가 폐기될 때까지 소스 파일이 잠금 상태로 유지됩니다. 해당 인스턴스가 존재하는 동안 소스 파일을 이동, 덮어쓰기 또는 삭제하지 마십시오.

Aspose.Slides는 로드 중에 입력 스트림의 내용을 복사할 수 있습니다. 대용량 프레젠테이션의 경우 파일 경로가 일반적으로 스트림보다 더 효율적입니다. 추가 저장소 및 메모리 관리 옵션은 [Manage BLOBs](/slides/ko/java/manage-blob/)를 참조하십시오.
{{% /alert %}}

## **외부 리소스 제어**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-)는 [IResourceLoadingCallback](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iresourceloadingcallback/) 구현을 받아들입니다. 콜백은 대체 데이터를 제공하거나, 리소스를 재지정하거나, 기본 로더를 사용하거나, 리소스를 건너뛸 수 있습니다. 이는 프레젠테이션에 외부 이미지가 포함되어 있으며 애플리케이션 별 보안 또는 저장 규칙에 따라 해결해야 할 때 유용합니다.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **임베드된 바이너리 객체 없이 프레젠테이션 로드**

프레젠테이션에는 애플리케이션이 필요 없거나 유지하고 싶지 않은 임베드된 바이너리 데이터가 포함될 수 있습니다. 예시:

- VBA 프로젝트, [IPresentation.getVbaProject](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getVbaProject--)를 통해 사용할 수 있습니다;
- 임베드된 OLE 데이터, [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--)를 통해 사용할 수 있습니다;
- ActiveX 컨트롤 데이터, [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)를 통해 사용할 수 있습니다.

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)를 `true`로 설정하면 로드 중에 이 바이너리 데이터를 제거합니다. 정제된 결과를 유지하려면 로드된 프레젠테이션을 저장하십시오.

이 옵션은 원치 않는 임베드된 페이로드에 대한 노출을 줄여 주지만, 완전한 악성코드 탐지 또는 콘텐츠 정제 시스템은 아닙니다.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**파일이 손상되어 열 수 없는지 어떻게 알 수 있나요?**  
Aspose.Slides는 로드 중에 파싱 또는 형식 예외를 발생시킵니다. 이 실패를 잘못된 비밀번호 오류와 별도로 처리하여 애플리케이션이 원인을 정확히 보고하도록 합니다.

**필수 글꼴이 누락된 경우 어떻게 되나요?**  
프레젠테이션은 여전히 로드될 수 있지만, 렌더링 및 내보내기 시 글꼴이 대체될 수 있습니다. 출력이 보다 예측 가능하도록 하려면 [configure font substitution](/slides/ko/java/font-substitution/) 또는 [provide custom fonts](/slides/ko/java/custom-font/)를 사용할 수 있습니다.

**프레젠테이션을 로드하면 임베드된 미디어도 로드되나요?**  
임베드된 오디오와 비디오는 프레젠테이션 객체 모델을 통해 사용할 수 있게 됩니다. 외부 리소스는 구성된 리소스 로딩 동작에 따라 해결되며, 위치에 접근할 수 없을 경우 사용할 수 없을 수도 있습니다.