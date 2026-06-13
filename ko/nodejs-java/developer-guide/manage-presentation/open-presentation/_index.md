---
title: JavaScript에서 프레젠테이션 열기
linktitle: 프레젠테이션 열기
type: docs
weight: 20
url: /ko/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 Java를 통해 PowerPoint(.pptx, .ppt) 및 OpenDocument(.odp) 프레젠테이션을 손쉽게 열 수 있습니다—빠르고, 신뢰할 수 있으며, 모든 기능을 갖추고 있습니다."
---
## **소개**

PowerPoint 프레젠테이션을 처음부터 만드는 것 외에도, Aspose.Slides는 기존 프레젠테이션을 열 수 있습니다. 프레젠테이션을 로드한 후에는 해당 정보를 검색하고, 슬라이드 내용을 편집하고, 새 슬라이드를 추가하고, 기존 슬라이드를 제거하는 등 다양한 작업을 수행할 수 있습니다.

## **프레젠테이션 열기**

기존 프레젠테이션을 열려면, [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.

다음 JavaScript 예제는 프레젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```js
// Presentation 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // 프레젠테이션의 총 슬라이드 수를 출력합니다.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **비밀번호로 보호된 프레젠테이션 열기**

비밀번호로 보호된 프레젠테이션을 열어야 할 경우, [LoadOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/) 클래스의 [setPassword](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setPassword) 메서드를 통해 비밀번호를 전달하여 복호화하고 로드합니다. 다음 JavaScript 코드는 이 작업을 보여줍니다:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // 복호화된 프레젠테이션에 대한 작업을 수행합니다.
} finally {
    presentation.dispose();
}
```

## **대용량 프레젠테이션 열기**

Aspose.Slides는 특히 [LoadOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/) 클래스의 [getBlobManagementOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) 메서드를 통해 대용량 프레젠테이션을 로드하는 데 도움이 되는 옵션을 제공합니다.

다음 JavaScript 코드는 대용량 프레젠테이션(예: 2 GB)을 로드하는 예시를 보여줍니다:

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// KeepLocked 동작을 선택합니다—프레젠테이션 파일이 인스턴스 전체 동안 잠긴 상태로 유지됩니다
// 프레젠테이션 인스턴스이며, 메모리로 로드되거나 임시 파일에 복사될 필요가 없습니다.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // 대용량 프레젠테이션이 로드되었으며 사용할 수 있습니다. 메모리 사용량은 낮게 유지됩니다.
    
    // 프레젠테이션을 수정합니다.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // 프레젠테이션을 다른 파일에 저장합니다. 이 작업 중에도 메모리 사용량은 낮게 유지됩니다.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // 이렇게 하지 마세요! 프레젠테이션 객체가 해제될 때까지 파일이 잠겨 있어 I/O 예외가 발생합니다.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// 여기서 수행해도 됩니다. 소스 파일이 이제 프레젠테이션 객체에 의해 잠겨 있지 않습니다.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
스트림을 사용할 때 발생할 수 있는 일부 제한을 회피하기 위해 Aspose.Slides가 스트림 내용을 복사할 수 있습니다. 스트림에서 대용량 프레젠테이션을 로드하면 프레젠테이션이 복사되어 로드 속도가 느려질 수 있습니다. 따라서 대용량 프레젠테이션을 로드해야 할 경우 스트림 대신 프레젠테이션 파일 경로를 사용하는 것을 강력히 권장합니다.

대용량 객체(비디오, 오디오, 고해상도 이미지 등)를 포함하는 프레젠테이션을 만들 때는 [BLOB 관리](/slides/ko/nodejs-java/manage-blob/)를 사용하여 메모리 사용량을 줄일 수 있습니다.
{{%/alert %}}

## **외부 리소스 제어**

Aspose.Slides는 외부 리소스를 관리할 수 있게 해주는 [IResourceLoadingCallback](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iresourceloadingcallback/) 인터페이스를 제공합니다. 다음 JavaScript 코드는 `IResourceLoadingCallback` 인터페이스를 사용하는 방법을 보여줍니다:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // 교체 이미지를 로드합니다.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // 교체 URL을 설정합니다.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // 다른 모든 이미지를 건너뜁니다.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **임베드된 바이너리 객체 없이 프레젠테이션 로드**

PowerPoint 프레젠테이션에는 다음과 같은 유형의 임베드된 바이너리 객체가 포함될 수 있습니다:

- VBA 프로젝트 ( [Presentation.getVbaProject](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getVbaProject) 에서 접근 가능);
- OLE 객체 임베드 데이터 ( [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 에서 접근 가능);
- ActiveX 컨트롤 바이너리 데이터 ( [Control.getActiveXControlBinary](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/control/#getActiveXControlBinary) 에서 접근 가능).

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 메서드를 사용하면 임베드된 바이너리 객체가 전혀 없는 상태로 프레젠테이션을 로드할 수 있습니다.

이 메서드는 잠재적으로 악성인 바이너리 콘텐츠를 제거하는 데 유용합니다. 다음 JavaScript 코드는 임베드된 바이너리 콘텐츠 없이 프레젠테이션을 로드하는 방법을 보여줍니다:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // 프레젠테이션에 대한 작업을 수행합니다.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**파일이 손상되어 열 수 없다는 것을 어떻게 알 수 있나요?**

로드 중에 구문 분석/형식 검증 예외가 발생합니다. 이러한 오류는 종종 잘못된 ZIP 구조 또는 손상된 PowerPoint 레코드를 언급합니다.

**열 때 필요한 글꼴이 누락되면 어떻게 되나요?**

파일은 열리지만, 이후 [렌더링/내보내기](/slides/ko/nodejs-java/convert-presentation/) 단계에서 글꼴이 대체될 수 있습니다. 런타임 환경에 [글꼴 대체 구성](/slides/ko/nodejs-java/font-substitution/) 또는 [필요한 글꼴 추가](/slides/ko/nodejs-java/custom-font/)를 수행하십시오.

**열 때 임베드된 미디어(비디오/오디오)는 어떻게 되나요?**

이들은 프레젠테이션 리소스로 사용 가능합니다. 미디어가 외부 경로로 참조되는 경우 해당 경로가 환경에서 접근 가능하도록 하세요; 그렇지 않으면 [렌더링/내보내기](/slides/ko/nodejs-java/convert-presentation/) 단계에서 미디어가 누락될 수 있습니다.