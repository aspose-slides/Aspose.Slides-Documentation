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
- PowerPoint
- 프레젠테이션
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript에서 PowerPoint 슬라이드(PPT, PPTX)를 Aspose.Slides for Node.js를 사용해 Java를 통해 깔끔한 Markdown으로 변환하고, 문서 자동화와 서식 유지가 가능합니다."
---
## **소개**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션을 Markdown으로 변환할 수 있으며, 이는 문서 작업 흐름, 정적 사이트 생성, 콘텐츠 마이그레이션 및 버전 관리 텍스트 게시에 유용합니다. API는 PPT 및 PPTX 프레젠테이션을 MD 파일로 직접 내보내는 것을 지원하고, 결과 Markdown 문서에서 슬라이드 내용이 표시되는 방식을 제어하는 추가 옵션을 제공합니다.

프레젠테이션을 일반 Markdown으로 내보내거나 CommonMark 및 GitHub Flavored Markdown과 같은 여러 Markdown 변형 중에서 선택할 수 있으며, 내보내기 중 이미지 처리 방식을 구성할 수 있습니다. 시각적 콘텐츠가 포함된 프레젠테이션의 경우 Aspose.Slides는 이미지를 별도의 폴더에 저장하고 생성된 Markdown 파일에서 해당 이미지를 참조하도록 할 수도 있습니다.

{{% alert color="warning" %}} 
PowerPoint를 Markdown으로 내보낼 때 기본적으로 **이미지 없이** 출력됩니다. 이미지를 포함한 PowerPoint 문서를 내보내려면 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)`를 호출하고, Markdown 문서에 참조되는 이미지가 저장될 `BasePath`도 설정해야 합니다.
{{% /alert %}} 

## **PowerPoint를 Markdown으로 변환**

1. 프레젠테이션 개체를 나타내는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 생성합니다.  
2. 객체를 markdown 파일로 저장하려면 [save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) 메서드를 사용합니다.

다음 JavaScript 코드는 PowerPoint를 markdown으로 변환하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint를 Markdown 변형으로 변환**

Aspose.Slides를 사용하면 PowerPoint를 기본 구문을 포함한 markdown, CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab 및 기타 17가지 markdown 변형으로 변환할 수 있습니다.

다음 JavaScript 코드는 PowerPoint를 CommonMark로 변환하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

지원되는 23가지 markdown 변형은 [MarkdownSaveOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/) 클래스의 [Flavor 열거형](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/flavor/)에 **목록**되어 있습니다.

## **이미지가 포함된 프레젠테이션을 Markdown으로 변환**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownsaveoptions/) 클래스는 결과 markdown 파일에 적용할 수 있는 다양한 속성 및 열거형을 제공합니다. 예를 들어, [MarkdownExportType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markdownexporttype/) 열거형은 `Sequential`, `TextOnly`, `Visual`과 같이 이미지가 렌더링되거나 처리되는 방식을 결정하는 값으로 설정할 수 있습니다.

### **이미지를 순차적으로 변환**

결과 markdown에 이미지가 하나씩 순서대로 표시되길 원한다면 `Sequential` 옵션을 선택해야 합니다. 다음 JavaScript 코드는 이미지를 포함한 프레젠테이션을 markdown으로 변환하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **이미지를 시각적으로 변환**

결과 markdown에 이미지가 함께 표시되길 원한다면 `Visual` 옵션을 선택해야 합니다. 이 경우 이미지는 애플리케이션의 현재 디렉터리에 저장되고(그리고 markdown 문서에 상대 경로가 생성됨) 원하는 경로와 폴더명을 지정할 수도 있습니다.

다음 JavaScript 코드는 해당 작업을 시연합니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **자주 묻는 질문**

**하이퍼링크가 Markdown으로 내보내기 후에도 유지됩니까?**

예. 텍스트 [hyperlinks](/slides/ko/nodejs-java/manage-hyperlinks/)은 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/nodejs-java/slide-transition/) 및 [animations](/slides/ko/nodejs-java/powerpoint-animation/)는 변환되지 않습니다.

**다중 스레드에서 실행하여 변환 속도를 높일 수 있나요?**

파일 단위로 병렬 처리를 할 수 있지만, 스레드 간에 동일한 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 [don’t share](/slides/ko/nodejs-java/multithreading/)하지 마세요. 파일당 별도 인스턴스/프로세스를 사용하여 경쟁을 방지해야 합니다.

**이미지는 어떻게 처리됩니까? 어디에 저장되며 경로는 상대 경로입니까?**

[Images](/slides/ko/nodejs-java/image/)는 전용 폴더에 내보내지며, Markdown 파일은 기본적으로 상대 경로를 사용해 이미지를 참조합니다. 기본 출력 경로와 자산 폴더 이름을 구성하여 예측 가능한 저장소 구조를 유지할 수 있습니다.