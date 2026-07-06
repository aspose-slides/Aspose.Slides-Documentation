---
title: .NET에서 프레젠테이션의 텍스트 부분 경계 가져오기
linktitle: 부분 경계
type: docs
weight: 47
url: /ko/net/portion-bounds/
keywords:
- 텍스트 부분 경계
- 텍스트 부분
- 텍스트 조각
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 프레젠테이션에서 텍스트 부분 경계를 검색하는 방법을 배우십시오."
---
## **개요**

텍스트 부분은 단락 내에서 특정 텍스트 조각을 나타내며, 주변 콘텐츠와 독립적으로 해당 조각을 작업할 수 있게 합니다. Aspose.Slides에서는 텍스트 조각의 경계를 가져오거나, 단락의 일부분에만 서식을 적용하거나, 텍스트 동작을 보다 세밀하게 제어해야 할 때 부분을 사용할 수 있습니다.

이 문서에서는 [IPortion.GetRect](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/getrect/)을 사용하여 부분의 경계 사각형을 가져오는 방법을 보여줍니다. 또한 [IPortion.GetCoordinates](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/getcoordinates/)를 사용하여 부분의 시작 좌표를 가져오는 방법을 보여줍니다. 추가로, 단일 텍스트 조각에 하이퍼링크를 적용하거나, 서식이 부분, 단락, 텍스트 프레임 및 테마 상속을 통해 어떻게 해결되는지 이해하고, 지정된 글꼴이 없을 경우를 처리하는 등 일반적인 부분 관련 시나리오를 강조합니다.

## **텍스트 부분의 경계 가져오기**

텍스트 부분의 경계 사각형을 가져오려면 [IPortion.GetRect](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/getrect/)을 사용하십시오:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **텍스트 부분의 좌표 가져오기**

텍스트 부분의 시작 좌표를 가져오려면 [IPortion.GetCoordinates](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/getcoordinates/)을 사용하십시오:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **자주 묻는 질문**

**단일 단락 내 텍스트의 일부분에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 부분에 [하이퍼링크 지정](/slides/ko/net/manage-hyperlinks/)을 할 수 있습니다; 해당 조각만 클릭 가능하며 전체 단락은 클릭할 수 없습니다.

**스타일 상속은 어떻게 작동하나요: 부분이 무엇을 재정의하고, 무엇을 단락이나 텍스트 프레임에서 가져오나요?**

부분 수준의 속성이 가장 높은 우선순위를 가집니다. 속성이 [IPortion](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/)에 설정되지 않은 경우, Aspose.Slides는 [IParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/)에서 가져옵니다. 그곳에도 설정되지 않은 경우, Aspose.Slides는 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 또는 [theme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/theme/) 스타일을 사용합니다.

**부분에 지정된 글꼴이 대상 머신이나 서버에 없을 경우 어떻게 되나요?**

[글꼴 대체 규칙](/slides/ko/net/font-selection-sequence/)이 적용됩니다. 텍스트가 재배치될 수 있으며, 메트릭, 하이픈 처리 및 너비가 변경될 수 있어 정확한 위치 지정에 영향을 미칩니다.

**부분 별 텍스트 채우기 투명도나 그라데이션을 단락의 나머지와 독립적으로 설정할 수 있나요?**

예, [IPortion](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/) 수준에서 텍스트 색상, 채우기 및 투명도는 인접 조각과 다르게 설정할 수 있습니다.