---
title: PowerPoint 프레젠테이션을 .NET에서 Markdown으로 변환
linktitle: PowerPoint를 Markdown으로
type: docs
weight: 140
url: /ko/net/convert-powerpoint-to-markdown/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 슬라이드(PPT, PPTX)를 깔끔한 Markdown으로 변환하고, 문서 작성을 자동화하며 서식을 유지합니다."
---
## **소개**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션을 Markdown으로 변환할 수 있으며, 이는 문서 작업 흐름, 정적 사이트 생성, 콘텐츠 마이그레이션 및 버전 관리 텍스트 게시에 유용합니다. API는 PPT 및 PPTX 프레젠테이션을 MD 파일로 직접 내보내는 것을 지원하며, 결과 Markdown 문서에서 슬라이드 콘텐츠가 어떻게 표시되는지를 제어하는 추가 옵션을 제공합니다.

프레젠테이션을 일반 Markdown으로 내보낼 수 있고, CommonMark 및 GitHub Flavored Markdown과 같은 여러 마크다운 변형 중에서 선택할 수 있으며, 내보내기 중 이미지 처리 방식을 구성할 수 있습니다. 시각적 콘텐츠가 포함된 프레젠테이션의 경우, Aspose.Slides는 이미지를 별도의 폴더에 저장하고 생성된 Markdown 파일에서 참조하도록 허용합니다.

{{% alert color="warning" %}}
PowerPoint를 Markdown으로 내보내는 경우 기본적으로 **이미지 없이** 내보냅니다. 이미지가 포함된 PowerPoint 문서를 내보내려면 `ExportType = MarkdownExportType.Visual`을 설정하고 `BasePath`를 지정해야 하며, 여기서 Markdown 문서에 참조된 이미지가 저장됩니다.
{{% /alert %}}

## **PowerPoint를 Markdown으로 변환**

1. 프레젠테이션 객체를 나타내는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. 객체를 markdown 파일로 저장하려면 [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/methods/save) 메서드를 사용합니다.

이 C# 코드는 PowerPoint를 markdown으로 변환하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **PowerPoint를 Markdown 변형으로 변환**

Aspose.Slides를 사용하면 PowerPoint를 기본 구문을 포함한 markdown, CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab 및 기타 17가지 markdown 변형으로 변환할 수 있습니다.

이 C# 코드는 PowerPoint를 CommonMark로 변환하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

지원되는 23가지 markdown 변형은 [Flavor 열거형](https://reference.aspose.com/slides/ko/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) 아래에 [MarkdownSaveOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 클래스에서 나열됩니다.

## **이미지가 포함된 프레젠테이션을 Markdown으로 변환**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 클래스는 결과 markdown 파일에 대해 특정 옵션이나 설정을 사용할 수 있는 속성과 열거형을 제공합니다. 예를 들어, [MarkdownExportType](https://reference.aspose.com/slides/ko/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 열거형은 이미지가 렌더링되거나 처리되는 방식을 결정하는 값으로 `Sequential`, `TextOnly`, `Visual`을 설정할 수 있습니다.

### **이미지를 순차적으로 변환**

결과 markdown에서 이미지가 하나씩 순서대로 나타나도록 하려면 순차 옵션을 선택해야 합니다. 이 C# 코드는 이미지가 포함된 프레젠테이션을 markdown으로 변환하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **이미지를 시각적으로 변환**

결과 markdown에 이미지가 함께 나타나도록 하려면 시각 옵션을 선택해야 합니다. 이 경우 이미지가 애플리케이션의 현재 디렉터리에 저장되며 (markdown 문서에 대한 상대 경로가 생성됩니다), 또는 원하는 경로와 폴더 이름을 지정할 수 있습니다.

이 C# 코드는 해당 동작을 시연합니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **FAQ**

**하이퍼링크가 Markdown으로 내보낼 때 유지되나요?**

예. 텍스트 [hyperlinks](/slides/ko/net/manage-hyperlinks/) 은 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/net/slide-transition/) 및 [animations](/slides/ko/net/powerpoint-animation/) 은 변환되지 않습니다.

**여러 스레드에서 실행하여 변환 속도를 높일 수 있나요?**

파일마다 병렬 처리할 수 있지만, 스레드 간에 동일한 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 [공유하지](/slides/ko/net/multithreading/) 마세요. 파일당 별도의 인스턴스/프로세스를 사용하여 충돌을 방지합니다.

**이미지는 어떻게 처리되나요—어디에 저장되며 경로는 상대 경로인가요?**

[Images](/slides/ko/net/image/) 은 전용 폴더에 내보내지며, 기본적으로 Markdown 파일은 상대 경로로 해당 이미지를 참조합니다. 기본 출력 경로와 자산 폴더 이름을 구성하여 예측 가능한 저장소 구조를 유지할 수 있습니다.