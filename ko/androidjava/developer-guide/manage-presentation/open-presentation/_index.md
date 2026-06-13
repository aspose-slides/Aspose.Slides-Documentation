---
title: Android에서 프레젠테이션 열기
linktitle: 프레젠테이션 열기
type: docs
weight: 20
url: /ko/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 Java로 PowerPoint(.pptx, .ppt) 및 OpenDocument(.odp) 프레젠테이션을 손쉽게 열 수 있습니다—빠르고 신뢰할 수 있으며 전체 기능을 제공합니다."
---
## **소개**

처음부터 PowerPoint 프레젠테이션을 만드는 것 외에도, Aspose.Slides는 기존 프레젠테이션을 열 수 있습니다. 프레젠테이션을 로드한 후에는 해당 정보를 가져오고, 슬라이드 내용을 편집하고, 새 슬라이드를 추가하고, 기존 슬라이드를 제거하는 등 다양한 작업을 수행할 수 있습니다.

## **프레젠테이션 열기**

기존 프레젠테이션을 열려면, [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.

다음 Java 예제는 프레젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```java
// Presentation 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // 프레젠테이션의 전체 슬라이드 수를 출력합니다.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **암호가 보호된 프레젠테이션 열기**

암호가 보호된 프레젠테이션을 열어야 할 경우, [LoadOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/loadoptions/) 클래스의 [setPassword](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 메서드에 비밀번호를 전달하여 복호화 후 로드합니다. 다음 Java 코드는 이 작업을 보여줍니다:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // 복호화된 프레젠테이션에 대해 작업을 수행합니다.
} finally {
    presentation.dispose();
}
```

## **대용량 프레젠테이션 열기**

Aspose.Slides는 대용량 프레젠테이션을 로드하는 데 도움이 되는 옵션을 제공하는데, 특히 [LoadOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/loadoptions/) 클래스의 [getBlobManagementOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) 메서드가 있습니다.

다음 Java 코드는 대용량 프레젠테이션(예: 2GB)을 로드하는 방법을 보여줍니다:

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// KeepLocked 동작을 선택합니다—프레젠테이션 파일은 전체 수명 동안 잠긴 상태를 유지합니다
// Presentation 인스턴스에 대해, 메모리에 로드하거나 임시 파일에 복사할 필요는 없습니다.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // 대용량 프레젠테이션이 로드되었으며 사용할 수 있습니다. 메모리 사용량은 낮게 유지됩니다.

    // 프레젠테이션을 변경합니다.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // 프레젠테이션을 다른 파일에 저장합니다. 이 작업 중에도 메모리 사용량은 낮게 유지됩니다.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // 이렇게 하지 마십시오! 파일이 프레젠테이션 객체가 해제될 때까지 잠겨 있기 때문에 I/O 예외가 발생합니다.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// 여기에 수행해도 됩니다. 소스 파일은 이제 프레젠테이션 객체에 의해 잠겨 있지 않습니다.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
스트림을 사용할 때 일부 제한 사항을 해결하기 위해 Aspose.Slides는 스트림의 내용을 복사할 수 있습니다. 스트림에서 대용량 프레젠테이션을 로드하면 프레젠테이션이 복사되어 로드 속도가 느려질 수 있습니다. 따라서 대용량 프레젠테이션을 로드해야 할 경우 스트림보다 프레젠테이션 파일 경로를 사용하는 것을 강력히 권장합니다.

비디오, 오디오, 고해상도 이미지 등 대용량 객체를 포함하는 프레젠테이션을 만들 때는 [BLOB 관리](/slides/ko/androidjava/manage-blob/)를 사용하여 메모리 사용량을 줄일 수 있습니다.
{{%/alert %}}

## **외부 리소스 제어**

Aspose.Slides는 외부 리소스를 관리할 수 있는 [IResourceLoadingCallback](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iresourceloadingcallback/) 인터페이스를 제공합니다. 다음 Java 코드는 `IResourceLoadingCallback` 인터페이스를 사용하는 방법을 보여줍니다:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // 대체 이미지를 로드합니다.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // 바이트를 얻는 임의의 방법을 사용합니다.
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // 대체 URL을 설정합니다.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // 다른 모든 이미지를 건너뜁니다.
        return ResourceLoadingAction.Skip;
    }
}
```

## **임베드된 바이너리 객체 없이 프레젠테이션 로드**

PowerPoint 프레젠테이션에는 다음과 같은 유형의 임베드된 바이너리 객체가 포함될 수 있습니다:

- VBA 프로젝트([IPresentation.getVbaProject](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#getVbaProject--)을 통해 액세스 가능);
- OLE 객체 임베드 데이터([IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--)을 통해 액세스 가능);
- ActiveX 컨트롤 바이너리 데이터([IControl.getActiveXControlBinary](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)을 통해 액세스 가능).

[ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) 메서드를 사용하면 임베드된 바이너리 객체가 전혀 없는 상태로 프레젠테이션을 로드할 수 있습니다.

이 메서드는 잠재적으로 악의적인 바이너리 콘텐츠를 제거하는 데 유용합니다. 다음 Java 코드는 임베드된 바이너리 콘텐츠가 전혀 없는 프레젠테이션을 로드하는 방법을 보여줍니다:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // 프레젠테이션에 대해 작업을 수행합니다.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**파일이 손상되어 열 수 없는 경우 어떻게 알 수 있나요?**

로드 중에 구문 분석/형식 검증 예외가 발생합니다. 이러한 오류는 종종 잘못된 ZIP 구조나 손상된 PowerPoint 레코드를 언급합니다.

**열 때 필요한 글꼴이 누락된 경우 어떻게 되나요?**

파일은 열리지만 이후 [렌더링/내보내기](/slides/ko/androidjava/convert-presentation/) 시 글꼴이 대체될 수 있습니다. 런타임 환경에 [글꼴 대체 구성](/slides/ko/androidjava/font-substitution/) 또는 [필요한 글꼴 추가](/slides/ko/androidjava/custom-font/)를 수행하십시오.

**열 때 임베드된 미디어(비디오/오디오)는 어떻게 되나요?**

이들은 프레젠테이션 리소스로 사용 가능합니다. 미디어가 외부 경로를 통해 참조되는 경우 해당 경로가 환경에서 접근 가능하도록 하세요. 그렇지 않으면 [렌더링/내보내기](/slides/ko/androidjava/convert-presentation/) 시 미디어가 누락될 수 있습니다.