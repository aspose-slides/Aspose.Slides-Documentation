---
title: .NET에서 프레젠테이션의 단락 경계 가져오기
linktitle: 단락 경계
type: docs
weight: 43
url: /ko/net/paragraph-bounds/
keywords:
- 단락 경계
- 단락 좌표
- 단락 크기
- 텍스트 프레임
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 단락 경계를 가져오는 방법을 배우고 PowerPoint 프레젠테이션의 텍스트 위치를 최적화하세요."
---
## **개요**

이 문서는 Aspose.Slides에서 단락의 경계, 크기 및 좌표를 가져오는 방법을 설명합니다. [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)을 사용하여 [IParagraph.GetRect](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/getrect/)로 단락 사각형을 검색하는 방법, 표 셀 텍스트 프레임 내부의 단락 좌표를 얻는 방법을 보여 주며, 측정 단위, 텍스트 래핑이 경계에 미치는 영향, 픽셀 변환, 효과적인 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **단락의 사각형 좌표 가져오기**

[IParagraph.GetRect](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/getrect/)를 사용하여 단락의 경계 사각형을 가져옵니다.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **표 셀 TextFrame 내부 단락의 크기 가져오기**

표 셀 텍스트 프레임에서 [IParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/)의 크기와 좌표를 가져오려면 [IParagraph.GetRect](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/getrect/)를 사용합니다. 반환된 사각형은 표 셀 텍스트 프레임을 기준으로 하므로 슬라이드 수준 좌표가 필요할 때 표 위치와 셀 오프셋을 추가해야 합니다.

다음 예제는 표 셀 내부의 단락 경계를 가져와 슬라이드에 사각형을 그려 해당 경계를 시각화합니다:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**단락 좌표는 어떤 단위로 측정되나요?**

단락 좌표는 포인트 단위로 측정되며, 1인치는 72포인트에 해당합니다. 이는 슬라이드의 모든 좌표와 치수에 적용됩니다.

**단어 래핑이 단락의 경계에 영향을 미칩니까?**

예. [TextFrameFormat.WrapText](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat/wraptext/)가 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)에 대해 활성화된 경우, 텍스트가 영역 너비에 맞게 줄바꿈되어 단락의 실제 경계가 변경됩니다.

**단락 좌표를 내보낸 이미지의 픽셀에 신뢰성 있게 매핑할 수 있나요?**

예. 포인트를 픽셀로 변환하려면 다음 수식을 사용합니다: pixels = points × (DPI / 72). 결과는 렌더링 또는 내보내기에 선택된 DPI에 따라 달라집니다.

**스타일 상속을 고려한 "effective" 단락 서식 매개변수를 어떻게 가져오나요?**

[효과적인 단락 서식 데이터 구조](/slides/ko/net/shape-effective-properties/)를 사용합니다; 들여쓰기, 간격, 래핑, RTL 등에 대한 최종 통합 값을 반환합니다.