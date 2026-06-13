---
title: 잉크
type: docs
weight: 180
url: /ko/net/examples/elements/ink/
keywords:
- 잉크
- 잉크 접근
- 잉크 제거
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 잉크 작업: 스트로크를 그리기, 가져오기 및 편집, 색상 및 너비 조정, C# 예제를 사용해 PPT, PPTX 및 ODP로 내보내기."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 기존 잉크 모양에 접근하고 이를 제거하는 예제를 제공합니다.

> ❗ **Note:** 잉크 모양은 특수 장치로부터 사용자의 입력을 나타냅니다. Aspose.Slides는 프로그래밍 방식으로 새로운 잉크 스트로크를 만들 수 없지만, 기존 잉크를 읽고 수정할 수 있습니다.

## **잉크 접근**

슬라이드의 첫 번째 잉크 모양에서 태그를 읽습니다.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // 필요에 따라 tagName을 사용합니다.
        }
    }
}
```

## **잉크 제거**

슬라이드에 잉크 모양이 있는 경우 이를 삭제합니다.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```