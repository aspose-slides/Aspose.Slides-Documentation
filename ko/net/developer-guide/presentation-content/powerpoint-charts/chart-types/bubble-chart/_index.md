---
title: .NET에서 프레젠테이션용 버블 차트 사용자 지정
linktitle: 버블 차트
type: docs
url: /ko/net/bubble-chart/
keywords:
- 버블 차트
- 버블 크기
- 크기 스케일링
- 크기 표현
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint에서 강력한 버블 차트를 만들고 사용자 지정하여 데이터 시각화를 손쉽게 향상시킵니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 버블 차트를 사용하는 방법을 보여줍니다. `BubbleSizeScale` 속성을 통한 버블 크기 스케일링과 `BubbleSizeRepresentation` 속성을 통한 버블 크기 값 표시 방식을 제어하는 두 가지 특정 사용자 지정 옵션을 다룹니다.

예제에서는 버블 차트를 만들고, 크기 스케일링을 조정하며, 버블 크기 표시 방식을 너비를 사용하도록 전환하는 방법을 보여줍니다. 또한 이 문서에는 “Bubble with 3-D” 차트 유형에 대한 지원을 명확히 하고, 실제 차트 제한이 성능 및 대상 PowerPoint 버전에 따라 달라짐을 언급하며, 내보내기가 Aspose.Slides 렌더링 엔진을 통해 차트의 모양을 유지한다는 내용의 짧은 FAQ 섹션도 포함됩니다.

## **버블 차트 크기 스케일링**
Aspose.Slides for .NET은 버블 차트 크기 스케일링을 지원합니다. Aspose.Slides for .NET에 **IChartSeries.BubbleSizeScale** 및 **IChartSeriesGroup.BubbleSizeScale** 속성이 추가되었습니다. 아래에 샘플 예제가 제공됩니다.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **버블 차트 크기로 데이터 표시**
**BubbleSizeRepresentation** 속성이 IChartSeries, IChartSeriesGroup 인터페이스 및 관련 클래스에 추가되었습니다. **BubbleSizeRepresentation**은 버블 차트에서 버블 크기 값이 어떻게 표시되는지를 지정합니다. 가능한 값은 **BubbleSizeRepresentationType.Area** 및 **BubbleSizeRepresentationType.Width** 입니다. 따라서 데이터를 버블 차트 크기로 표시하는 가능한 방법을 지정하기 위해 **BubbleSizeRepresentationType** 열거형이 추가되었습니다. 아래에 샘플 코드가 제공됩니다.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**"3-D 효과가 있는 버블 차트"가 지원되며 일반 차트와는 어떻게 다른가요?**  
예. 별도의 차트 유형인 "Bubble with 3-D"가 있습니다. 이 유형은 버블에 3‑D 스타일을 적용하지만 추가 축을 추가하지 않으며, 데이터는 X‑Y‑S(크기) 형태를 유지합니다. 해당 유형은 [chart type](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/charttype/) 열거형에 포함되어 있습니다.

**버블 차트에서 시리즈와 포인트 수에 제한이 있나요?**  
API 수준에서 명확한 제한은 없으며, 제한은 성능 및 대상 PowerPoint 버전에 따라 결정됩니다. 가독성과 렌더링 속도를 위해 포인트 수를 적절히 유지하는 것이 권장됩니다.

**내보내기가 버블 차트의 모양에 어떤 영향을 미치나요 (PDF, 이미지)?**  
지원되는 형식으로 내보내면 차트의 모양이 유지됩니다; 렌더링은 Aspose.Slides 엔진에 의해 수행됩니다. 래스터/벡터 형식의 경우 일반 차트 그래픽 렌더링 규칙(해상도, 안티앨리어싱)이 적용되므로 인쇄를 위해 충분한 DPI를 선택하세요.