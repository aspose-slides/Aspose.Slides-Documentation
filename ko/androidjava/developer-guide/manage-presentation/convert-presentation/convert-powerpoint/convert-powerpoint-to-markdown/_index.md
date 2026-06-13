---
title: Android에서 PowerPoint 프레젠테이션을 Markdown으로 변환
linktitle: PowerPoint를 Markdown으로
type: docs
weight: 140
url: /ko/androidjava/convert-powerpoint-to-markdown/
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
- 파워포인트
- 프레젠테이션
- 마크다운
- 안드로이드
- 자바
- Aspose.Slides
description: "Aspose.Slides for Android를 Java로 사용하여 PowerPoint 슬라이드(PPT, PPTX)를 깔끔한 Markdown으로 변환하고, 문서화를 자동화하며 서식을 유지합니다."
---
## **소개**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션을 Markdown으로 변환할 수 있으며, 이는 문서화 워크플로, 정적 사이트 생성, 콘텐츠 마이그레이션 및 버전 관리 텍스트 게시에 유용합니다. API는 PPT 및 PPTX 프레젠테이션을 MD 파일로 직접 내보내는 기능을 제공하고, 슬라이드 내용이 생성된 Markdown 문서에 어떻게 표시될지 제어할 수 있는 추가 옵션을 제공합니다.

프레젠테이션을 일반 Markdown으로 내보내거나 CommonMark, GitHub Flavored Markdown 등 여러 Markdown 변형 중에서 선택할 수 있으며, 내보내기 중 이미지 처리 방식을 구성할 수 있습니다. 시각적 콘텐츠가 포함된 프레젠테이션의 경우 Aspose.Slides는 이미지를 별도 폴더에 저장하고 생성된 Markdown 파일에서 해당 이미지를 참조하도록 할 수 있습니다.

Aspose.Slides는 프레젠테이션‑to‑markdown 변환을 지원합니다.

{{% alert color="warning" %}} 

PowerPoint를 Markdown으로 내보낼 때 기본적으로 **이미지가 포함되지 않습니다**. 이미지가 포함된 PowerPoint 문서를 내보내려면 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)`을 설정하고, Markdown 문서에서 참조되는 이미지가 저장될 `BasePath`도 지정해야 합니다.

{{% /alert %}} 

## **PowerPoint를 Markdown으로 변환**

1. 프레젠테이션 객체를 나타내는 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.  
2. [Save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 메서드를 사용해 객체를 Markdown 파일로 저장합니다.

다음 Java 코드는 PowerPoint를 Markdown으로 변환하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint를 다양한 Markdown 변형으로 변환**

Aspose.Slides를 사용하면 PowerPoint를 기본 구문이 포함된 Markdown, CommonMark, GitHub Flavored Markdown, Trello, XWiki, GitLab 및 기타 17개의 Markdown 변형으로 변환할 수 있습니다.

다음 Java 코드는 PowerPoint를 CommonMark로 변환하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

지원되는 23개의 Markdown 변형은 [Flavor 열거형](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/flavor/)에 나와 있으며, 이는 [MarkdownSaveOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/) 클래스에서 확인할 수 있습니다.

## **이미지가 포함된 프레젠테이션을 Markdown으로 변환**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/) 클래스는 결과 Markdown 파일에 적용할 수 있는 다양한 속성과 열거형을 제공합니다. 예를 들어, [MarkdownExportType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownexporttype/) 열거형은 `Sequential`, `TextOnly`, `Visual` 값으로 설정해 이미지가 렌더링되거나 처리되는 방식을 결정할 수 있습니다.

### **이미지를 순차적으로 변환**

이미지를 결과 Markdown에 하나씩 차례대로 표시하려면 Sequential 옵션을 선택해야 합니다. 다음 Java 코드는 이미지가 포함된 프레젠테이션을 Markdown으로 변환하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **이미지를 시각적으로 변환**

이미지를 결과 Markdown에 함께 표시하려면 Visual 옵션을 선택해야 합니다. 이 경우 이미지는 애플리케이션 현재 디렉터리에 저장되고(그리고 Markdown 문서에 상대 경로가 생성됨) 원하는 경로와 폴더 이름을 지정할 수도 있습니다.

다음 Java 코드는 해당 작업을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**하이퍼링크가 Markdown으로 내보내진 후에도 유지되나요?**

예. 텍스트 [hyperlinks](/slides/ko/androidjava/manage-hyperlinks/)는 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/androidjava/slide-transition/)와 [animations](/slides/ko/androidjava/powerpoint-animation/)은 변환되지 않습니다.

**여러 스레드에서 실행하여 변환 속도를 높일 수 있나요?**

파일별로 병렬 처리는 가능하지만, 동일한 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 인스턴스를 스레드 간에 공유하지 마세요. 파일당 별도 인스턴스/프로세스를 사용해 경쟁을 피하십시오.

**이미지는 어떻게 처리되며, 저장 위치와 경로는 어떻게 되나요?**

[Images](/slides/ko/androidjava/image/)는 전용 폴더에 내보내지며, Markdown 파일은 기본적으로 상대 경로로 이미지를 참조합니다. 기본 출력 경로와 자산 폴더 이름을 구성해 예측 가능한 저장소 구조를 유지할 수 있습니다.