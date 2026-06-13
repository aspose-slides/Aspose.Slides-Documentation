---
title: 헤더 및 바닥글
type: docs
weight: 220
url: /ko/net/examples/elements/header-footer/
keywords:
- 헤더 바닥글
- 헤더 바닥글 추가
- 헤더 바닥글 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 슬라이드 헤더와 바닥글을 제어합니다: C# 예제를 통해 PPT, PPTX 및 ODP에서 날짜, 슬라이드 번호 및 사용자 지정 텍스트를 추가합니다."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 바닥글을 추가하고 날짜 및 시간 자리 표시자를 업데이트하는 방법을 보여줍니다.

## **바닥글 추가**

슬라이드의 바닥글 영역에 텍스트를 추가하고 표시되도록 합니다.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **날짜 및 시간 업데이트**

슬라이드의 날짜 및 시간 자리 표시자를 수정합니다.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```