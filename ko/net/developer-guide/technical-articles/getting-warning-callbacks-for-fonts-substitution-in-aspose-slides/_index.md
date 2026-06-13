---
title: .NET에서 글꼴 대체에 대한 경고 콜백 가져오기
type: docs
weight: 120
url: /ko/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 경고 콜백
- 글꼴 대체
- 렌더링 프로세스
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 글꼴 대체에 대한 경고 콜백을 가져오고 PowerPoint 및 OpenDocument 프레젠테이션을 정확하게 표시하는 방법을 배우십시오."
---
## **소개**

Aspose.Slides for .NET은 렌더링 중에 필요한 글꼴이 머신에 없을 때 글꼴 대체에 대한 경고 콜백을 받을 수 있게 합니다. 이러한 콜백은 누락되었거나 접근할 수 없는 글꼴 문제를 진단하는 데 도움이 됩니다.

## **경고 콜백 활성화**

Aspose.Slides for .NET은 프레젠테이션 슬라이드를 렌더링할 때 경고 콜백을 받기 위한 간단한 API를 제공합니다. 다음 단계에 따라 경고 콜백을 구성하십시오:

1. 경고를 처리하기 위해 [IWarningCallback](https://reference.aspose.com/slides/ko/net/aspose.slides.warnings/iwarningcallback/) 인터페이스를 구현하는 사용자 정의 콜백 클래스를 생성합니다.
1. [RenderingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmloptions/) 등의 옵션 클래스를 사용하여 경고 콜백을 설정합니다.
1. 대상 머신에 없는 글꼴을 사용하는 프레젠테이션을 로드합니다.
1. 슬라이드 썸네일을 생성하거나 프레젠테이션을 내보내어 영향을 확인합니다.

**사용자 정의 경고 콜백 클래스:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// 예시 출력:
//
// 폰트가 XYZ에서 {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}} 로 대체됩니다
```

**슬라이드 썸네일 생성:**

```c#
// 슬라이드 렌더링 중 글꼴 관련 경고를 처리하기 위한 경고 콜백을 설정합니다.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// 지정된 파일 경로에서 프레젠테이션을 로드합니다.
using var presentation = new Presentation("sample.pptx");

// 프레젠테이션의 각 슬라이드에 대한 썸네일 이미지를 생성합니다.
foreach (var slide in presentation.Slides)
{
    // 지정된 렌더링 옵션을 사용하여 슬라이드 썸네일 이미지를 가져옵니다.
    using var image = slide.GetImage(options);
    // ...
}
```

**PDF 형식으로 내보내기:**

```c#
// PDF 내보내기 중 글꼴 관련 경고를 처리하기 위한 경고 콜백을 설정합니다.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// 지정된 파일 경로에서 프레젠테이션을 로드합니다.
using var presentation = new Presentation("sample.pptx");

// 프레젠테이션을 PDF로 내보냅니다.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**HTML 형식으로 내보내기:**

```c#
// HTML 내보내기 중 글꼴 관련 경고를 처리하기 위한 경고 콜백을 설정합니다.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// 지정된 파일 경로에서 프레젠테이션을 로드합니다.
using var presentation = new Presentation("sample.pptx");

// 프레젠테이션을 HTML 형식으로 내보냅니다.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```