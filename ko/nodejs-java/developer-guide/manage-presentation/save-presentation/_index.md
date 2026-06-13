---
title: JavaScript에서 프레젠테이션 저장
linktitle: 프레젠테이션 저장
type: docs
weight: 80
url: /ko/nodejs-java/save-presentation/
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
- 섬네일 새로 고침
- 저장 진행
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 Java를 통해 사용하여 프레젠테이션을 저장하는 방법을 알아보세요—레이아웃, 글꼴 및 효과를 유지하면서 PowerPoint 또는 OpenDocument로 내보낼 수 있습니다."
---
## **개요**

[Open Presentations in JavaScript](/slides/ko/nodejs-java/open-presentation/) 에서는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 여는 방법을 설명했습니다. 이 문서에서는 프레젠테이션을 생성하고 저장하는 방법을 설명합니다. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스에는 프레젠테이션의 내용이 포함됩니다. 처음부터 프레젠테이션을 만들든 기존 프레젠테이션을 수정하든 작업이 끝나면 저장해야 합니다. Aspose.Slides for Node.js를 사용하면 **파일**이나 **스트림**에 저장할 수 있습니다. 이 문서에서는 프레젠테이션을 저장하는 다양한 방법을 설명합니다.

## **프레젠테이션을 파일에 저장**

[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 `save` 메서드를 호출하여 프레젠테이션을 파일에 저장합니다. 메서드에 파일 이름과 저장 형식을 전달하십시오. 다음 예제는 Aspose.Slides를 사용해 프레젠테이션을 저장하는 방법을 보여줍니다.

```js
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 여기에서 작업을 수행합니다...

    // 프레젠테이션을 파일에 저장합니다.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **프레젠테이션을 스트림에 저장**

[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 `save` 메서드에 출력 스트림을 전달하여 프레젠테이션을 스트림에 저장할 수 있습니다. 프레젠테이션은 다양한 스트림 유형에 기록될 수 있습니다. 아래 예제에서는 새 프레젠테이션을 만들고 파일 스트림에 저장합니다.

```js
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // 프레젠테이션을 스트림에 저장합니다.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

Aspose.Slides는 생성된 프레젠테이션이 열릴 때 PowerPoint가 사용할 초기 보기를 [ViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/) 클래스를 통해 설정할 수 있게 합니다. [ViewType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewtype/) 열거형의 값을 사용해 [setLastView](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/#setLastView) 메서드를 호출하십시오.

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Strict Office Open XML 형식으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 프레젠테이션을 Strict Office Open XML 형식으로 저장할 수 있습니다. 저장 시 [PptxOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxoptions/) 클래스를 사용하고 그 `conformance` 속성을 설정하십시오. [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict)를 지정하면 출력 파일이 Strict Office Open XML 형식으로 저장됩니다.

아래 예제는 프레젠테이션을 생성하고 Strict Office Open XML 형식으로 저장합니다.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 프레젠테이션을 Strict Office Open XML 형식으로 저장합니다.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ZIP64 모드로 Office Open XML 형식 저장**

Office Open XML 파일은 ZIP 아카이브이며, 압축되지 않은 파일 크기, 압축된 파일 크기, 전체 아카이브 크기에 각각 4 GB(2^32 바이트) 제한과 파일 수 65 535(2^16‑1) 제한을 둡니다. ZIP64 확장 형식은 이러한 제한을 2^64까지 확장합니다.

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) 메서드를 사용하면 Office Open XML 파일을 저장할 때 ZIP64 확장 형식을 언제 사용할지 선택할 수 있습니다.

다음 모드가 지원됩니다:

- [IfNecessary](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/zip64mode/#IfNecessary) 은 프레젠테이션이 위 제한을 초과할 경우에만 ZIP64 확장 형식을 사용합니다. 기본 모드입니다.
- [Never](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/zip64mode/#Never) 은 ZIP64 확장 형식을 절대 사용하지 않습니다.
- [Always](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/zip64mode/#Always) 은 항상 ZIP64 확장 형식을 사용합니다.

아래 코드는 ZIP64 확장 형식을 활성화한 상태에서 PPTX로 프레젠테이션을 저장하는 방법을 보여줍니다.

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/zip64mode/#Never) 로 저장하는 경우, 프레젠테이션을 ZIP32 형식으로 저장할 수 없으면 [PptxException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxexception/) 이 발생합니다.
{{% /alert %}}

## **섬네일을 새로 고치지 않고 프레젠테이션 저장**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 메서드는 PPTX로 저장할 때 섬네일 생성 여부를 제어합니다:

- `true` 로 설정하면 저장 중에 섬네일이 새로 고쳐집니다. 기본값입니다.
- `false` 로 설정하면 현재 섬네일을 유지합니다. 프레젠테이션에 섬네일이 없으면 섬네일이 생성되지 않습니다.

아래 코드에서는 섬네일을 새로 고치지 않고 PPTX로 프레젠테이션을 저장합니다.

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
이 옵션은 PPTX 형식으로 저장하는 데 걸리는 시간을 줄이는 데 도움이 됩니다.
{{% /alert %}}

## **진행 상황을 백분율로 저장 업데이트**

[SaveOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveoptions/) 및 그 하위 클래스에서 [setProgressCallback](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) 메서드를 통해 저장 진행 상황 보고를 구성합니다. Java 프록시를 제공하고 해당 프록시가 [IProgressCallback](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iprogresscallback/) 인터페이스를 구현하도록 하면, 내보내기 중에 콜백이 주기적인 백분율 업데이트를 받습니다.

다음 코드 조각은 `IProgressCallback` 을 사용하는 방법을 보여줍니다.

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // 여기에서 진행률 백분율 값을 사용합니다.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose는 자체 API를 사용해 만든 무료 PowerPoint Splitter 앱([https://products.aspose.app/slides/ko/splitter](https://products.aspose.app/slides/ko/splitter))을 제공하고 있습니다. 이 앱을 사용하면 선택한 슬라이드를 새로운 PPTX 또는 PPT 파일로 저장해 프레젠테이션을 여러 파일로 분할할 수 있습니다.
{{% /alert %}}

## **FAQ**

**"빠른 저장"(증분 저장)이 지원되어 변경된 내용만 기록되나요?**

아니요. 저장 시마다 전체 대상 파일을 새로 생성하므로 증분 "빠른 저장"은 지원되지 않습니다.

**여러 스레드에서 동일한 Presentation 인스턴스를 저장해도 안전한가요?**

아니요. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스는 [/slides/ko/nodejs-java/multithreading/](/slides/ko/nodejs-java/multithreading/) 에서 설명된 바와 같이 스레드에 안전하지 않으므로 단일 스레드에서 저장해야 합니다.

**저장할 때 하이퍼링크와 외부 연결 파일은 어떻게 되나요?**

[Hyperlinks](/slides/ko/nodejs-java/manage-hyperlinks/) 은 유지됩니다. 외부 연결 파일(예: 상대 경로를 이용한 비디오)은 자동으로 복사되지 않으니 참조 경로가 계속 접근 가능하도록 해야 합니다.

**문서 메타데이터(작성자, 제목, 회사, 날짜)를 설정/저장할 수 있나요?**

예. 표준 [document properties](/slides/ko/nodejs-java/presentation-properties/) 가 지원되며 저장 시 파일에 기록됩니다.