---
title: JavaScript에서 PowerPoint 프레젠테이션을 Markdown으로 변환
linktitle: PowerPoint를 Markdown으로
type: docs
weight: 140
url: /ko/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 MD로
- 프레젠테이션을 MD로
- 슬라이드를 MD로
- PPT를 MD로
- PPTX를 MD로
- PowerPoint를 Markdown으로 저장
- 프레젠테이션을 Markdown으로 저장
- 슬라이드를 Markdown으로 저장
- PPT를 MD로 저장
- PPTX를 MD로 저장
- PPT를 MD로 내보내기
- PPTX를 MD로 내보내기
- Markdown 이미지 내보내기
- CDN 이미지 링크
- PowerPoint
- 프레젠테이션
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript에서 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환하고, 내보낸 비트맵, 메타파일 및 SVG 이미지가 저장되고 참조되는 위치를 제어합니다."
---
## **개요**

Aspose.Slides for Node.js via Java는 문서화, 정적 사이트, 콘텐츠 마이그레이션 및 버전 제어 워크플로우를 위해 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환할 수 있습니다. Markdown 형식을 선택하고, 슬라이드 내용이 렌더링되는 방식을 제어하며, 내보낸 이미지가 저장되는 위치와 생성된 Markdown이 해당 이미지를 참조하는 방식을 결정할 수 있습니다.

기본적으로 Markdown 내보내기는 텍스트 전용 출력을 사용합니다. 시각적 콘텐츠를 내보내려면 [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/) 메서드로 [MarkdownExportType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownexporttype/) 열거형의 `Sequential` 또는 `Visual` 값을 지정합니다. `Sequential`은 슬라이드 항목을 별도로 순서대로 렌더링하고, `Visual`은 그룹화된 항목을 함께 유지하여 시각적 관계를 보존합니다. `TextOnly` 값은 이미지 리소스를 내보내지 않으므로 해당 모드에서는 이미지 저장 콜백이 호출되지 않습니다.

## **프레젠테이션을 Markdown으로 변환**

[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스로 소스 파일을 로드한 다음, [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 메서드에 [SaveFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveformat/) 열거형의 `Md` 값을 전달합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Markdown 형식 선택**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/) 메서드는 출력에 사용할 Markdown 사양을 제어합니다. [Flavor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/flavor/) 열거형에는 CommonMark, GitHub Flavored Markdown 및 기타 지원되는 변형이 포함됩니다.

다음 예제는 프레젠테이션을 CommonMark 형식으로 내보냅니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **기본 로컬 저장 동작으로 이미지 내보내기**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/) 클래스는 로컬에 저장된 이미지를 구성하기 위한 두 가지 메서드를 제공합니다.

- [setBasePath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/)는 Markdown 문서와 해당 리소스의 기본 디렉터리를 지정합니다.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/)는 이미지 하위 디렉터리를 지정합니다. 기본값은 `Images`입니다.

다음 예제는 시각적 콘텐츠를 렌더링하고, 이미지를 `output/assets`에 기록하며, Markdown 문서에 상대 이미지 참조를 생성합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

이 동작은 사용자 지정 이미지 저장 핸들러가 `false`를 반환할 때의 대체 동작이기도 합니다.

## **이미지 저장 및 Markdown 링크 사용자 지정**

[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/) 메서드를 사용하여 Markdown 내보내기 중에 발생하는 비 SVG 비트맵 및 메타파일 리소스에 대한 콜백을 등록합니다. 해당 `MarkdownImageSavingHandler` 콜백은 [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/) 객체, 그 [ImageFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/imageformat/) 값, 그리고 한 요소 문자열 배열로 전달된 생성된 Markdown 링크를 받습니다. 제공된 형식으로 이미지를 저장하거나 업로드하고, `link[0]`을 Markdown 출력에 나타나야 할 참조로 교체합니다.

SVG 형식으로 내보내지는 리소스는 별도로 처리됩니다. [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/) 메서드로 콜백을 등록합니다. 해당 `MarkdownSvgImageSavingHandler` 콜백은 `ISvgImage` 객체와 한 요소 `link` 배열을 받습니다. SVG에는 `ImageFormat` 인수가 없으며, 대신 `ISvgImage.getSvgData` 메서드에서 XML 데이터를 기록하거나 업로드합니다. 내보내기 모드와 시각적 그룹화에 따라 소스 프레젠테이션의 SVG가 래스터화되거나 다른 콘텐츠와 결합될 수 있으며, 결과 비 SVG 리소스는 이미지 저장 콜백에 전달됩니다. 모든 내보낸 시각적 리소스에 사용자 지정 처리가 필요할 경우 두 콜백을 모두 등록하십시오.

Node.js에서는 `java.newProxy`를 사용하여 이러한 콜백 인터페이스 구현을 생성합니다.

핸들러 반환 값에 따라 이미지 처리 주체가 결정됩니다.

- 핸들러가 이미지를 저장, 업로드, 변환하거나 기타 방식으로 처리하고 `link[0]`에 유효한 값을 할당한 후 `true`를 반환합니다. Aspose.Slides는 해당 값을 Markdown 문서에 기록하고 기본 로컬 저장을 수행하지 않습니다.
- `false`를 반환하면 Aspose.Slides가 이미지를 로컬에 저장하고, [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/) 및 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/)에 설정된 값에 따라 링크를 생성합니다.

{{% alert color="warning" title="Important" %}}
`true`를 반환하는 핸들러는 이미지에 대한 책임을 집니다. 유효하고 비어 있지 않은 링크를 할당하지 않은 채 `true`를 반환하면 `InvalidOperationException`이 발생하여 내보내기가 실패합니다.
{{% /alert %}}

### **CDN 원본 디렉터리로 이미지 저장 및 외부 URL 사용**

다음 예제는 `cdn-origin/presentations/quarterly-report`를 마운트되거나 동기화된 CDN 원본 디렉터리로 취급합니다. 각 핸들러는 생성된 파일 이름을 추출하고, 이미지를 해당 사용자 지정 디렉터리에 저장한 뒤, 생성된 로컬 참조를 공개 CDN URL로 교체합니다. 샘플 자체는 네트워크 업로드를 수행하지 않으며, 디렉터리가 CDN 원본으로 마운트되거나 파일이 CDN에 배포된 후에만 URL이 유효해집니다. 객체 스토리지를 사용할 경우 파일 시스템 쓰기를 스토리지 SDK의 업로드 작업으로 교체하고, 업로드가 성공한 후에만 `link[0]`을 할당하십시오.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

비트맵 핸들러는 128 × 128 픽셀보다 작은 이미지는 의도적으로 `false`를 반환하므로 Aspose.Slides가 해당 이미지를 `output/fallback-images`에 기본 동작으로 저장합니다. 더 큰 비트맵 및 메타파일 리소스와 SVG 리소스는 사용자 지정 코드로 처리됩니다. 예를 들어, `fallback-images/image1.png`와 같은 로컬 참조는 `https://cdn.example.com/presentations/quarterly-report/image1.png`가 됩니다. 핸들러는 파일을 쓸 때만 OS 경로 구분자를 사용하고, Markdown에 기록되는 링크는 슬래시(`/`)와 URL 인코딩된 파일 이름을 사용합니다. 상대 링크를 구성할 때도 `/`를 사용하고 플랫폼 별 디렉터리 구분자를 사용하지 마십시오.

## **FAQ**

**하나의 핸들러가 래스터 이미지와 SVG 이미지를 모두 처리할 수 있나요?**

아니요. 비트맵 및 메타파일 리소스는 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/)을, SVG로 내보내는 리소스는 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/)을 사용하십시오. 전자는 [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/) 객체와 [ImageFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/imageformat/) 값을 제공하고, 후자는 `ISvgImage` 객체와 SVG 데이터를 읽을 수 있는 `ISvgImage.getSvgData` 메서드를 제공합니다. 내보내기 중에 래스터화된 소스 SVG는 이미지 저장 콜백으로 처리됩니다.

**이미지 저장 핸들러가 `false`를 반환하면 어떻게 되나요?**

Aspose.Slides는 기본 로컬 저장 동작을 사용합니다. 이미지 위치와 생성된 참조는 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/) 및 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/)에 설정된 값에 따라 제어됩니다.

**핸들러가 이미지를 로컬에 저장하지 않고 URL만 제공할 수 있나요?**

예. 핸들러가 이미지를 객체 스토리지에 업로드하거나 다른 서비스에 전달하고, 결과 URL을 `link[0]`에 할당한 뒤 `true`를 반환할 수 있습니다. 이 경우 핸들러가 자체적으로 처리를 완료해야 하며, `true` 반환은 기본 로컬 저장을 방지합니다.

**핸들러에서 `InvalidOperationException`이 발생하는 이유는?**

핸들러가 `true`를 반환했지만 유효한 링크를 제공하지 않았을 때 발생합니다. `true`를 반환하기 전에 Markdown에 기록될 상대 경로나 외부 URL을 `link[0]`에 할당하십시오.

**이미지 링크에 어떤 경로 구분자를 사용해야 하나요?**

Markdown 링크와 URL에서는 슬래시(`/`)를 사용하십시오. 파일 시스템 경로를 구성할 때만 `path.join` 등을 사용하고, Markdown 참조는 별도로 정규화합니다.

**하이퍼링크가 Markdown 내보내기 시 보존되나요?**

예. 텍스트 [hyperlinks](/slides/ko/nodejs-java/manage-hyperlinks/)는 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/nodejs-java/slide-transition/) 및 [animations](/slides/ko/nodejs-java/powerpoint-animation/)는 변환되지 않습니다.

**프레젠테이션을 병렬로 Markdown으로 변환할 수 있나요?**

다른 프레젠테이션 파일을 병렬로 처리할 수 있지만, 동일한 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 스레드 간에 공유하지 마십시오. [멀티스레딩 가이드라인](/slides/ko/nodejs-java/multithreading/)을 따르고 파일마다 별도 인스턴스를 사용하십시오.