---
title: Java에서 PowerPoint 프레젠테이션을 Markdown으로 변환
linktitle: PowerPoint를 Markdown으로
type: docs
weight: 140
url: /ko/java/convert-powerpoint-to-markdown/
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
- 마크다운
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 슬라이드(PPT, PPTX)를 깔끔한 Markdown으로 변환하고, 문서 자동화와 형식 유지를 할 수 있습니다."
---
## **소개**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션을 Markdown으로 변환할 수 있으며, 이는 문서 워크플로, 정적 사이트 생성, 콘텐츠 마이그레이션 및 버전 관리 텍스트 출판에 유용합니다. API는 PPT 및 PPTX 프레젠테이션을 MD 파일로 직접 내보내는 것을 지원하며, 결과 Markdown 문서에서 슬라이드 콘텐츠가 어떻게 표시되는지 제어하는 추가 옵션을 제공합니다.

프레젠테이션을 일반 Markdown으로 내보낼 수 있고, CommonMark 및 GitHub Flavored Markdown과 같은 여러 Markdown 변형 중에서 선택할 수 있으며, 내보내기 중 이미지 처리 방식을 구성할 수 있습니다. 시각적 콘텐츠가 포함된 프레젠테이션의 경우, Aspose.Slides는 이미지를 별도의 폴더에 저장하고 생성된 Markdown 파일에서 이를 참조하도록 허용합니다.

{{% alert color="warning" %}}
PowerPoint를 markdown으로 내보낼 때 기본적으로 **이미지 없이** 내보냅니다. 이미지가 포함된 PowerPoint 문서를 내보내려면 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)`을 사용하고, markdown 문서에서 참조된 이미지가 저장될 `setBasePath`도 지정해야 합니다.
{{% /alert %}}

## **PowerPoint를 Markdown으로 변환**

1. 프레젠테이션 개체를 나타내기 위해 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. [Save ](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 메서드를 사용하여 객체를 markdown 파일로 저장합니다.

다음 Java 코드는 PowerPoint를 markdown으로 변환하는 방법을 보여줍니다:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint를 Markdown 변형으로 변환**

Aspose.Slides를 사용하면 PowerPoint를 markdown(기본 구문 포함), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab 및 기타 17개의 markdown 변형으로 변환할 수 있습니다.

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

지원되는 23개의 markdown 변형은 [MarkdownSaveOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/markdownsaveoptions/) 클래스의 [Flavor 열거형](https://reference.aspose.com/slides/ko/java/com.aspose.slides/flavor/) 아래에 나열되어 있습니다.

## **이미지가 포함된 프레젠테이션을 Markdown으로 변환**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/markdownsaveoptions/) 클래스는 결과 markdown 파일에 적용할 수 있는 다양한 속성과 열거형을 제공합니다. 예를 들어 [MarkdownExportType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/markdownexporttype/) 열거형은 이미지가 렌더링되거나 처리되는 방식을 결정하는 값(`Sequential`, `TextOnly`, `Visual`)으로 설정할 수 있습니다.

### **이미지를 순차적으로 변환**

결과 markdown에서 이미지가 하나씩 순차적으로 표시되길 원한다면 sequential 옵션을 선택해야 합니다. 다음 Java 코드는 이미지가 포함된 프레젠테이션을 markdown으로 변환하는 방법을 보여줍니다:
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

결과 markdown에서 이미지가 함께 표시되길 원한다면 visual 옵션을 선택해야 합니다. 이 경우 이미지는 애플리케이션의 현재 디렉터리에 저장되고(markdown 문서에 상대 경로가 생성됩니다), 원하는 경로와 폴더 이름을 지정할 수도 있습니다.

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

**하이퍼링크가 Markdown 내보내기에서 유지되나요?**

예. 텍스트 [하이퍼링크](/slides/ko/java/manage-hyperlinks/)는 표준 Markdown 링크로 유지됩니다. 슬라이드 [전환](/slides/ko/java/slide-transition/) 및 [애니메이션](/slides/ko/java/powerpoint-animation/)은 변환되지 않습니다.

**여러 스레드로 실행하여 변환 속도를 높일 수 있나요?**

파일 단위로 병렬 처리할 수 있지만, 스레드 간에 동일한 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 [공유하지 마세요](/slides/ko/java/multithreading/). 파일당 별도의 인스턴스/프로세스를 사용하여 경쟁을 방지하십시오.

**이미지는 어떻게 처리되나요—어디에 저장되고 경로는 상대 경로인가요?**

[이미지](/slides/ko/java/image/)는 전용 폴더에 내보내지며, 기본적으로 Markdown 파일은 상대 경로로 이를 참조합니다. 기본 출력 경로와 자산 폴더 이름을 구성하여 예측 가능한 저장소 구조를 유지할 수 있습니다.