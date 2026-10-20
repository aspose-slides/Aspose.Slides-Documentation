---
title: .NET에서 프레젠테이션 슬라이드의 도형 크기 조정
type: docs
weight: 130
url: /ko/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /ko/net/re-sizing-shapes-on-slide/
keywords:
- 도형 크기 조정
- 도형 크기 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드의 도형을 쉽게 크기 조정하고, 슬라이드 레이아웃 조정을 자동화하며 생산성을 향상시킵니다."
---
## **개요**

프레젠테이션의 슬라이드 크기를 변경하면 새 치수에 맞게 도형을 크기 조정하고 위치를 재배치해야 할 수도 있습니다. 이 문서에서는 도형을 수동으로 확대/축소하는 방법과 슬라이드, 마스터 및 레이아웃에 있는 표를 처리하는 방법을 보여줍니다.

## **도형 크기 조정**

프레젠테이션의 슬라이드에 표가 없고 슬라이드 크기를 A4로 변경한 후 결과를 저장하는 첫 번째 예제를 로드합니다. 이 예제는 [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/)을 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/)과 함께 사용하여 이후 루프에서 확대/축소를 제어합니다. 비율은 단위가 없으며 도형 위치와 크기는 포인트 단위로 측정됩니다. 너비와 높이 비율을 다르게 적용하면 도형이 왜곡될 수 있으며, 도형의 크기를 변경해도 폰트 크기는 확대/축소되지 않습니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 독립적인 가로 및 세로 스케일 계수를 계산합니다.
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
표는 별도로 처리해야 합니다. 전체 표의 너비와 높이를 지정하는 대신 열 너비와 행 높이를 각각 확대/축소합니다. 셀 내용이 더 많은 공간을 필요로 하면 행 높이가 요청한 것보다 크게 남을 수 있습니다.
{{% /alert %}}

두 번째 예제는 표를 지원하고 마스터와 레이아웃의 도형은 물론 개별 슬라이드의 도형도 크기 조정 후 저장합니다. 이 예제의 도우미는 각 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)을 처리하면서 [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/)과 [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/)을 확대/축소합니다. 그런 다음 표 전체 크기를 별도로 확대/축소하지 않고 표의 위치만 확대/축소합니다.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 독립적인 가로 및 세로 스케일 계수를 계산합니다.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// 마스터와 레이아웃 및 개별 슬라이드에 정의된 도형을 크기 조정합니다.
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
            // 표 차원은 열 너비와 행 높이에 의해 제어됩니다.
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

**슬라이드 크기를 조정한 후 도형이 왜곡되거나 잘리나요?**

슬라이드 크기를 확대/축소 없이 변경하면 도형은 원래 위치와 크기를 유지하므로 슬라이드 밖으로 넘어갈 수 있습니다. 너비와 높이를 다른 비율로 확대/축소하면 도형이 왜곡될 수도 있습니다.

**제공된 코드가 모든 도형 유형에 적용되나요?**

첫 번째 예제는 도형 경계를 직접 변경하며 표가 없는 슬라이드에 사용하도록 설계되었습니다. 두 번째 예제는 표를 별도로 처리합니다. 이러한 예제는 폰트 크기를 확대/축소하지 않으므로 텍스트와 표를 특히 확인해야 합니다. 표 내용이 행 높이를 제한할 수 있습니다.

**슬라이드를 크기 조정할 때 표는 어떻게 크기 조정하나요?**

열 너비를 너비 비율로, 최소 행 높이를 높이 비율로 확대/축소한 다음 표의 위치를 확대/축소합니다. 이는 두 번째 예제에 나와 있습니다.

**마스터 슬라이드와 레이아웃 슬라이드에도 이 크기 조정이 적용되나요?**

예. 두 번째 예제는 [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/)와 각 마스터의 [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/)를 반복하면서 동일한 크기 조정 논리를 적용합니다.

**슬라이드 크기 조정과 함께 슬라이드 방향(세로/가로)을 변경할 수 있나요?**

예. 슬라이드 크기를 변경한 후 [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/)을 설정하고 대상 치수를 읽기 전에 설정하면 최종 방향에 맞는 확대/축소 비율이 적용됩니다.

**설정할 수 있는 슬라이드 크기에 제한이 있나요?**

[SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/)을 사용하여 사용자 지정 슬라이드 치수를 지정할 수 있습니다. 지원되는 치수는 프레젠테이션 형식 및 파일을 여는 응용 프로그램에 따라 달라집니다.

**고정 비율을 가진 도형이 왜곡되는 것을 방지하려면 어떻게 해야 하나요?**

너비와 높이에 동일한 확대/축소 비율을 사용하십시오. 원래 레이아웃을 새 슬라이드 치수에 맞추려면 너비와 높이 비율 중 작은 값을 두 차원과 위치 모두에 적용합니다. 이렇게 하면 비율이 유지되지만 한쪽 가장자리에는 사용되지 않은 공간이 남을 수 있습니다.