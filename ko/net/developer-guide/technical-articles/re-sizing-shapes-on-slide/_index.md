---
title: .NET에서 프레젠테이션 슬라이드의 모양 크기 조정
type: docs
weight: 130
url: /ko/net/resizing-shapes-on-slide/
aliases:
  - /ko/net/re-sizing-shapes-on-slide/
  /net/re-sizing-shapes-on-slide/
keywords:
- 모양 크기 조정
- 모양 크기 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 슬라이드의 모양을 쉽게 크기 조정하고, 슬라이드 레이아웃 조정을 자동화하여 생산성을 높이세요."
---
## **개요**

프레젠테이션의 슬라이드 크기를 변경하면 새 치수에 맞게 모양의 크기를 조정하고 위치를 재조정해야 할 수도 있습니다. 이 문서에서는 모양을 수동으로 확대/축소하는 방법과 슬라이드, 마스터 및 레이아웃에서 표를 처리하는 방법을 보여줍니다.

## **모양 크기 조정**

각 모양의 상대적 위치와 크기를 유지하려면 새 슬라이드 너비와 원래 너비의 비율로 가로 좌표와 너비를 곱합니다. 해당 높이 비율을 사용해 세로 좌표와 높이에도 적용합니다.

첫 번째 예제는 슬라이드에 표가 포함되지 않은 프레젠테이션을 로드하고, 슬라이드 크기를 A4로 변경한 뒤 결과를 저장합니다. 이는 [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/)을 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/)와 함께 사용하여 이후 루프가 확대/축소를 제어하도록 합니다. 비율은 단위가 없으며, 모양의 위치와 크기는 포인트 단위로 측정됩니다. 너비와 높이 비율이 다르면 모양이 왜곡될 수 있으며, 모양의 크기를 변경해도 글꼴 크기는 확대/축소되지 않습니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 독립적인 가로 및 세로 배율을 계산합니다.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
표는 별도로 처리해야 합니다: 표 전체 너비와 높이를 지정하는 대신 열 너비와 행 높이를 확대/축소합니다. 셀 내용이 더 많은 공간을 필요로 하면 행 높이가 요청된 크기보다 크게 남을 수 있습니다.
{{% /alert %}}

두 번째 예제는 표를 지원하고, 크기가 조정된 프레젠테이션을 저장하기 전에 마스터 및 레이아웃뿐만 아니라 개별 슬라이드의 모양도 처리합니다. 헬퍼는 각 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)을 [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/)와 [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/)을 확대/축소하여 처리합니다. 그런 다음 전체 크기를 별도로 확대/축소하지 않고 표의 위치만 확대/축소합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 독립적인 가로 및 세로 배율을 계산합니다.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// 마스터 및 레이아웃에 정의된 모양과 개별 슬라이드의 모양 크기를 조정합니다.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // 표 크기는 열 너비와 행 높이로 제어됩니다.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **FAQ**

**슬라이드 크기를 조정한 후 모양이 왜 왜곡되거나 잘리는가?**

슬라이드 크기를 변경하면서 모양을 확대/축소하지 않으면, 모양은 원래 위치와 크기를 유지하므로 슬라이드 밖으로 넘어갈 수 있습니다. 너비와 높이를 서로 다른 비율로 확대/축소하면 모양이 왜곡될 수도 있습니다.

**제공된 코드가 모든 모양 유형에 대해 작동합니까?**

첫 번째 예제는 모양 경계를 직접 변경하며 표가 없는 슬라이드를 대상으로 합니다. 두 번째 예제는 표를 별도로 처리합니다. 이러한 예제는 글꼴 크기를 확대/축소하지 않으며 표 내용이 행 높이를 제한할 수 있으므로 결과 레이아웃, 특히 텍스트와 표를 확인해야 합니다.

**슬라이드 크기를 조정할 때 표의 크기는 어떻게 조정합니까?**

두 번째 예제와 같이 열 너비는 너비 비율로, 최소 행 높이는 높이 비율로 확대/축소한 다음 표의 위치를 확대/축소합니다.

**이 크기 조정이 마스터 슬라이드와 레이아웃 슬라이드에도 적용됩니까?**

예. 두 번째 예제는 [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/)와 각 마스터의 [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/)을 순회하며 동일한 크기 조정 논리를 모양에 적용합니다.

**크기 조정과 함께 슬라이드 방향(세로/가로)을 변경할 수 있습니까?**

예. 슬라이드 크기를 변경한 후 목표 치수를 읽기 전에 [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/)을 설정하면 확대/축소 비율이 최종 방향을 반영합니다.

**설정할 수 있는 슬라이드 크기에 제한이 있습니까?**

[SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/)을 사용하여 사용자 정의 슬라이드 치수를 지정할 수 있습니다. 지원되는 치수는 프레젠테이션 형식 및 파일을 여는 애플리케이션에 따라 달라집니다.

**고정 종횡비를 가진 모양이 왜곡되는 것을 어떻게 방지할 수 있나요?**

너비와 높이에 동일한 확대/축소 비율을 사용합니다. 원래 레이아웃을 새 슬라이드 치수에 맞추려면 너비와 높이 비율 중 더 작은 값을 너비, 높이 및 위치에 모두 적용합니다. 이렇게 하면 비율이 유지되지만 한쪽 가장자리에 사용되지 않는 공간이 남을 수 있습니다.