---
title: Android에서 프리젠테이션 열기
linktitle: 프리젠테이션 열기
type: docs
weight: 20
url: /ko/androidjava/open-presentation/
keywords:
- PowerPoint 열기
- 프리젠테이션 열기
- PPTX 열기
- PPT 열기
- ODP 열기
- 프리젠테이션 로드
- PPTX 로드
- PPT 로드
- ODP 로드
- 보호된 프리젠테이션
- 대용량 프리젠테이션
- 외부 리소스
- 바이너리 객체
- Android
- Java
- Aspose.Slides
description: "Android에서 PowerPoint 및 OpenDocument 프리젠테이션을 여는 방법, 열기 비밀번호 제공, 리소스 로딩 제어, 그리고 Aspose.Slides for Android via Java를 사용하여 메모리 사용량을 줄이는 방법을 배웁니다."
---
## **소개**

Aspose.Slides for Android via Java은 파일 및 스트림에서 PowerPoint 및 OpenDocument 프리젠테이션을 로드할 수 있습니다. 프리젠테이션을 로드한 후에는 구조를 검사하고, 슬라이드를 편집하고, 리소스를 관리하며 원본 또는 다른 지원 형식으로 저장할 수 있습니다.

로드 동작은 LoadOptions 클래스를 통해 맞춤 설정할 수 있습니다. 예를 들어, 열기 비밀번호를 제공하고, 대용량 바이너리 개체를 Java 힙 메모리 외부에 유지하며, 외부 리소스를 제어하거나, 임베드된 바이너리 데이터를 생략할 수 있습니다.

## **프리젠테이션 열기**

기존 프리젠테이션을 열려면 해당 파일 경로를 Presentation 생성자에 전달합니다. 파일 핸들, 임시 데이터 및 기타 리소스가 즉시 해제되도록 사용 후 프리젠테이션을 Dispose하십시오.

다음 Java 예제는 프리젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **비밀번호로 보호된 프리젠테이션 열기**

열기 비밀번호는 프리젠테이션 내용을 암호화합니다. 전체 프리젠테이션을 로드하려면 올바른 비밀번호를 LoadOptions.setPassword에 전달하고 옵션을 Presentation 생성자에 제공하십시오. 비밀번호가 없거나 올바르지 않으면 로드가 실패합니다.

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

For password detection, validation, and encryption workflows, see [Password-Protect Presentations](/slides/ko/androidjava/password-protected-presentation/). If an encrypted presentation was deliberately saved with public document properties, those properties can be read without a password; see [Manage Presentation Properties](/slides/ko/androidjava/presentation-properties/).

## **대용량 프리젠테이션 열기**

LoadOptions.getBlobManagementOptions는 이미지, 오디오 및 비디오와 같은 대용량 바이너리 객체를 Aspose.Slides가 처리하는 방식을 제어하는 옵션을 반환합니다. 원본 파일을 잠금 상태로 유지하고, 임시 파일을 허용하며, 메모리에 보관되는 BLOB 데이터 양을 제한할 수 있습니다.

다음 Java 코드는 대용량 프리젠테이션(예: 2 GB) 로드 방법을 보여줍니다:

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

{{% alert color="info" title="참고" %}}
PresentationLockingBehavior.KeepLocked를 사용하면 프리젠테이션 인스턴스를 Dispose할 때까지 원본 파일이 잠긴 상태로 유지됩니다. 해당 인스턴스가 살아 있는 동안 원본 파일을 이동, 덮어쓰기 또는 삭제하지 마십시오.

Aspose.Slides는 로드 중에 입력 스트림의 내용을 복사할 수 있습니다. 대용량 프리젠테이션의 경우 파일 경로가 일반적으로 스트림보다 효율적입니다. 추가 저장 및 메모리 관리 옵션은 [Manage BLOBs](/slides/ko/androidjava/manage-blob/)를 확인하십시오.
{{% /alert %}}

## **외부 리소스 제어**

LoadOptions.setResourceLoadingCallback은 IResourceLoadingCallback 구현을 허용합니다. 콜백은 대체 데이터를 제공하거나, 리소스를 재지정하거나, 기본 로더를 사용하거나, 리소스를 건너뛸 수 있습니다. 이는 프리젠테이션에 애플리케이션별 보안 또는 저장 규칙에 따라 해결해야 하는 외부 이미지가 포함된 경우에 유용합니다.

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

## **임베드된 바이너리 객체 없이 프리젠테이션 로드**

프리젠테이션에는 애플리케이션에 필요 없거나 유지하고 싶지 않은 임베드된 바이너리 데이터가 포함될 수 있습니다. 예시:

- VBA 프로젝트, IPresentation.getVbaProject를 통해 사용할 수 있습니다;
- 임베드된 OLE 데이터, IOleEmbeddedDataInfo.getEmbeddedFileData를 통해 사용할 수 있습니다;
- ActiveX 컨트롤 데이터, IControl.getActiveXControlBinary를 통해 사용할 수 있습니다.

로드 중에 이 바이너리 데이터를 제거하려면 LoadOptions.setDeleteEmbeddedBinaryObjects를 `true`로 설정하십시오. 정제된 결과를 유지하려면 로드된 프리젠테이션을 저장하십시오.

이 옵션은 원치 않는 임베드된 페이로드에 대한 노출을 줄이지만, 완전한 악성코드 탐지 또는 콘텐츠 정화 시스템은 아닙니다.

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

**파일이 손상되어 열 수 없다는 것을 어떻게 확인할 수 있나요?**

Aspose.Slides는 로드 중에 구문 분석 또는 형식 예외를 발생시킵니다. 잘못된 비밀번호 오류와는 별도로 해당 실패를 처리하여 애플리케이션이 원인을 정확히 보고할 수 있도록 하십시오.

**필수 폰트가 누락되면 어떻게 됩니까?**

프리젠테이션은 여전히 로드될 수 있지만, 렌더링 및 내보내기 시 폰트가 대체될 수 있습니다. 출력이 보다 예측 가능하도록 폰트 대체를 구성하거나 사용자 지정 폰트를 제공할 수 있습니다.

**프리젠테이션을 로드하면 임베드된 미디어도 로드됩니까?**

임베드된 오디오 및 비디오는 프리젠테이션 객체 모델을 통해 사용할 수 있게 됩니다. 외부 리소스는 구성된 리소스 로딩 동작에 따라 해결되며, 해당 위치에 접근할 수 없으면 사용할 수 없을 수도 있습니다.