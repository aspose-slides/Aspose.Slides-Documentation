---
title: 프레젠테이션에서 Python으로 버블 차트 사용자 지정
linktitle: 버블 차트
type: docs
url: /ko/python-net/bubble-chart/
keywords:
- 버블 차트
- 버블 크기
- 크기 스케일링
- 크기 표시
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET을 사용하여 PowerPoint 및 OpenDocument에서 강력한 버블 차트를 만들고 사용자 지정하여 데이터 시각화를 쉽게 향상시킵니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 버블 차트를 사용하는 방법을 보여줍니다. `bubble_size_scale` 속성을 통한 버블 크기 스케일링과 `bubble_size_representation` 속성을 통한 버블 크기 값 표시 방식을 두 가지 맞춤 옵션으로 다룹니다.

예제에서는 버블 차트를 생성하고, 크기 스케일링을 조정하며, 버블 크기 표시 방식을 너비로 전환하는 방법을 설명합니다. 또한 “3‑D 버블 차트” 지원 여부를 명확히 하고, 실제 차트 제한은 성능 및 대상 PowerPoint 버전에 따라 달라진다는 점, 그리고 내보내기가 Aspose.Slides 렌더링 엔진을 통해 차트 모양을 유지한다는 내용을 포함한 간단한 FAQ 섹션이 포함되어 있습니다.

## **버블 차트 크기 스케일링**
Aspose.Slides for Python via .NET은 버블 차트 크기 스케일링을 지원합니다. Aspose.Slides for Python via .NET **ChartSeries.bubble_size_scale** 및 **ChartSeriesGroup.bubble_size_scale** 속성이 추가되었습니다. 아래 예제가 제공됩니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **데이터를 버블 차트 크기로 표시**
**bubble_size_representation** 속성이 ChartSeries, ChartSeriesGroup 클래스에 추가되었습니다. **bubble_size_representation**은 버블 차트에서 버블 크기 값이 어떻게 표시되는지를 지정합니다. 가능한 값은 **BubbleSizeRepresentationType.AREA**와 **BubbleSizeRepresentationType.WIDTH**입니다. 따라서 데이터를 버블 차트 크기로 표시할 수 있는 방법을 지정하는 **BubbleSizeRepresentationType** 열거형도 추가되었습니다. 아래에 샘플 코드가 제공됩니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**“3‑D 효과가 있는 버블 차트”가 지원되며 일반 차트와 어떻게 다른가요?**

예, 별도의 차트 유형인 “Bubble with 3-D”가 있습니다. 이 유형은 버블에 3‑D 스타일을 적용하지만 추가 축을 만들지는 않으며 데이터는 X‑Y‑S(크기) 형태를 유지합니다. 해당 유형은 [chart type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/charttype/) 열거형에 포함됩니다.

**버블 차트의 시리즈 및 포인트 수에 제한이 있나요?**

API 수준에서 강제적인 제한은 없으며, 제한은 성능 및 대상 PowerPoint 버전에 따라 결정됩니다. 가독성과 렌더링 속도를 위해 포인트 수를 적절히 유지하는 것이 권장됩니다.

**내보내기가 버블 차트의 모양에 어떤 영향을 미치나요 (PDF, 이미지 등)?**

지원되는 형식으로 내보내면 차트의 모양이 유지됩니다. 렌더링은 Aspose.Slides 엔진이 수행합니다. 래스터/벡터 형식 모두 일반 차트 그래픽 렌더링 규칙(해상도, 안티앨리어싱 등)이 적용되므로 인쇄용으로 충분한 DPI를 선택해야 합니다.