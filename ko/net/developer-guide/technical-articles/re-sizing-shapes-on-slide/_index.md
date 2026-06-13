---
title: .NET에서 프레젠테이션 슬라이드의 도형 크기 조정
type: docs
weight: 130
url: /ko/net/re-sizing-shapes-on-slide/
keywords:
- 도형 크기 조정
- 도형 크기 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 도형을 손쉽게 크기 조정하고, 슬라이드 레이아웃 조정을 자동화하여 생산성을 향상시킵니다."
---
## **개요**

Aspose.Slides for .NET 고객이 가장 많이 묻는 질문 중 하나는 슬라이드 크기가 변경될 때 데이터가 잘리지 않도록 도형의 크기를 어떻게 조정하냐는 것입니다. 이 짧은 기술 문서에서는 그 방법을 보여줍니다.

## **도형 크기 조정**

슬라이드 크기가 변경될 때 도형이 뒤틀리지 않도록 하려면, 각 도형의 위치와 크기를 새 슬라이드 레이아웃에 맞게 업데이트하십시오.

```c#
// 프레젠테이션 파일을 로드합니다.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 원본 슬라이드 크기를 가져옵니다.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 기존 도형을 스케일링하지 않고 슬라이드 크기를 변경합니다.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 새로운 슬라이드 크기를 가져옵니다.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // 모든 슬라이드의 도형을 크기 조정하고 위치를 재설정합니다.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // 도형 크기를 스케일링합니다.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // 도형 위치를 스케일링합니다.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
슬라이드에 표가 포함된 경우 위 코드는 올바르게 작동하지 않습니다. 이 경우 표의 각 셀을 개별적으로 크기 조정해야 합니다.
{{% /alert %}}

표가 포함된 슬라이드를 크기 조정하려면 아래 코드를 사용하십시오. 표의 경우 너비나 높이를 설정하는 것이 특수한 경우이며, 전체 표 크기를 변경하려면 행 높이와 열 너비를 각각 조정해야 합니다.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 원본 슬라이드 크기를 가져옵니다.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 기존 도형을 스케일링하지 않고 슬라이드 크기를 변경합니다.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // 새로운 슬라이드 크기를 가져옵니다.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // 도형 크기를 스케일링합니다.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // 도형 위치를 스케일링합니다.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // 도형 크기를 스케일링합니다.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // 도형 위치를 스케일링합니다.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // 도형 크기를 스케일링합니다.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // 도형 위치를 스케일링합니다.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **자주 묻는 질문**

**슬라이드 크기를 조정한 뒤 도형이 왜 왜곡되거나 잘리는가?**

슬라이드 크기를 조정하면 스케일을 명시적으로 변경하지 않는 한 도형은 기존 위치와 크기를 유지합니다. 이로 인해 내용이 잘리거나 도형이 뒤틀릴 수 있습니다.

**제공된 코드가 모든 도형 유형에 적용되는가?**

기본 예제는 대부분의 도형 유형(텍스트 상자, 이미지, 차트 등)에서 작동합니다. 그러나 표의 경우 행과 열을 별도로 처리해야 하며, 표의 높이와 너비는 개별 셀의 크기에 의해 결정됩니다.

**슬라이드 크기를 조정할 때 표는 어떻게 크기 조정하는가?**

표의 모든 행과 열을 순회하면서 높이와 너비를 비례적으로 조정해야 합니다. 두 번째 코드 예제에 나와 있는 대로 구현하십시오.

**이 크기 조정이 마스터 슬라이드와 레이아웃 슬라이드에도 적용되는가?**

예, 적용됩니다. 또한 [Masters](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/masters/)와 [LayoutSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/layoutslides/)을 순회하면서 해당 슬라이드의 도형에도 동일한 스케일링 로직을 적용해야 프레젠테이션 전체의 일관성을 유지할 수 있습니다.

**슬라이드의 방향(세로/가로)을 동시에 변경할 수 있는가?**

예. [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/ko/net/aspose.slides/islidesize/orientation/)을 설정하여 방향을 변경할 수 있습니다. 레이아웃을 유지하려면 스케일링 로직을 적절히 조정하십시오.

**설정할 수 있는 슬라이드 크기에 제한이 있는가?**

Aspose.Slides는 사용자 정의 크기를 지원하지만, 매우 큰 크기는 성능 저하나 특정 PowerPoint 버전과의 호환성 문제를 일으킬 수 있습니다.

**고정 종횡비 도형이 왜곡되는 것을 어떻게 방지할 수 있는가?**

스케일링하기 전에 도형의 `AspectRatioLocked` 속성을 확인하십시오. 잠겨 있는 경우 개별적으로 스케일링하지 말고 너비와 높이를 비례적으로 조정하십시오.