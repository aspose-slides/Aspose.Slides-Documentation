---
title: .NET 프레젠테이션에서 단락 경계 가져오기
linktitle: 단락
type: docs
weight: 60
url: /ko/net/paragraph/
keywords:
- 단락 경계
- 텍스트 구간 경계
- 단락 좌표
- 구간 좌표
- 단락 크기
- 텍스트 구간 크기
- 텍스트 프레임
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 단락 및 텍스트 구간 경계를 검색하여 PowerPoint 프레젠테이션의 텍스트 위치를 최적화하는 방법을 배웁니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 단락 및 텍스트 구간의 경계, 크기 및 좌표를 얻는 방법을 설명합니다. `GetRect()`를 사용하여 `TextFrame`에서 단락의 사각형을 가져오는 방법, 표 셀 텍스트 프레임 내부의 단락 및 구간 좌표를 가져오는 방법을 보여주며, 측정 단위, 텍스트 줄바꿈이 경계에 미치는 영향, 픽셀 변환, 그리고 실제 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **텍스트 프레임에서 단락 및 구간 좌표 가져오기**
.NET용 Aspose.Slides를 사용하면 개발자가 이제 TextFrame의 단락 컬렉션 내부에 있는 Paragraph의 사각형 좌표를 얻을 수 있습니다. 또한 단락의 구간 컬렉션 내부에 있는 구간의 좌표도 가져올 수 있습니다. 이 항목에서는 예제를 통해 단락의 사각형 좌표와 단락 내 구간의 위치를 가져오는 방법을 시연합니다.

## **단락의 사각형 좌표 가져오기**
새 메서드 **GetRect()**가 추가되었습니다. 이 메서드를 사용하면 단락 경계 사각형을 가져올 수 있습니다.

```c#
// 프레젠테이션 파일을 나타내는 Presentation 개체를 인스턴스화합니다
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **표 셀 텍스트 프레임 내부의 단락 및 구간 크기 가져오기**
표 셀 텍스트 프레임에서 [구간](https://reference.aspose.com/slides/ko/net/aspose.slides/portion) 또는 [단락](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph) 크기와 좌표를 가져오려면, [IPortion.GetRect](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/methods/getrect) 및 [IParagraph.GetRect](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/methods/getrect) 메서드를 사용할 수 있습니다.

이 샘플 코드는 설명된 작업을 보여줍니다:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **자주 묻는 질문**

**단락 및 텍스트 구간에 대한 좌표는 어떤 단위로 반환됩니까?**

포인트 단위이며, 1인치 = 72포인트입니다. 이는 슬라이드의 모든 좌표와 치수에 적용됩니다.

**단어 줄바꿈이 단락의 경계에 영향을 줍니까?**

예. [wrapping](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat/wraptext/)이 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/)에서 활성화된 경우, 텍스트가 영역 너비에 맞게 나뉘어 단락의 실제 경계가 변경됩니다.

**단락 좌표를 내보낸 이미지의 픽셀로 신뢰성 있게 매핑할 수 있습니까?**

예. 포인트를 픽셀로 변환하려면 다음 공식을 사용합니다: pixels = points × (DPI / 72). 결과는 렌더링/내보내기 시 선택한 DPI에 따라 달라집니다.

**"effective" 단락 서식 매개변수를 스타일 상속을 고려하여 어떻게 얻나요?**

[효과적인 단락 서식 데이터 구조](/slides/ko/net/shape-effective-properties/)를 사용하십시오; 들여쓰기, 간격, 줄바꿈, RTL 및 기타 항목에 대한 최종 통합 값을 반환합니다.