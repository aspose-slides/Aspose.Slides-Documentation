---
title: .NET에서 Treemap 및 Sunburst 차트의 데이터 포인트 사용자 정의
linktitle: Treemap 및 Sunburst 차트의 데이터 포인트
type: docs
url: /ko/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- 트리맵 차트
- 선버스트 차트
- 데이터 포인트
- 레이블 색상
- 분기 색상
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 treemap 및 sunburst 차트의 데이터 포인트를 관리하는 방법을 배우세요. PowerPoint 형식과 호환됩니다."
---
## **소개**

다른 종류의 PowerPoint 차트 중에서 두 가지 “계층형” 유형이 있습니다 — **Treemap**와 **Sunburst** 차트(일명 Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph 또는 Multi Level Pie Chart). 이러한 차트는 트리 구조로 정리된 계층 데이터를 표시합니다 — 잎(leaf)에서 가지(branch) 상단까지. 잎은 시리즈 데이터 포인트로 정의되고, 각 뒤따르는 중첩 그룹 수준은 해당 카테고리로 정의됩니다. Aspose.Slides for .NET은 C#에서 Sunburst 차트와 Treemap 차트의 데이터 포인트를 서식 지정할 수 있게 합니다.

다음은 Sunburst 차트이며, Series1 열의 데이터가 잎 노드를 정의하고, 다른 열이 계층 데이터 포인트를 정의합니다:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

프레젠테이션에 새 Sunburst 차트를 추가해 보겠습니다:



```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="참고" %}} 
- [**Sunburst 차트 만들기**](/slides/ko/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

차트의 데이터 포인트를 서식 지정해야 할 경우, 다음을 사용합니다:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapointlevel) 클래스 
및 [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) 속성은 Treemap 및 Sunburst 차트의 데이터 포인트를 서식 지정할 수 있는 접근을 제공합니다. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/IChartDataPointLevelsManager) 
은 다중 수준 카테고리에 접근하기 위해 사용됩니다 — 이는 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/IChartDataPointLevel) 객체들의 컨테이너를 나타냅니다. 
기본적으로 이는 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/IChartCategoryLevelsManager) 에 대한 래퍼이며, 
데이터 포인트에 특화된 속성을 추가했습니다. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/IChartDataPointLevel) 클래스는 
두 개의 속성을 갖습니다: [**Format**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapointlevel/properties/format)와 
[**DataLabel**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapointlevel/properties/label) 
으로, 해당 설정에 접근할 수 있습니다.
## **데이터 포인트 값 표시**
“Leaf 4” 데이터 포인트의 값을 표시합니다:



```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **데이터 포인트 레이블 및 색상 설정**
“Branch 1” 데이터 레이블을 카테고리 이름 대신 시리즈 이름(“Series1”)을 표시하도록 설정하고, 텍스트 색상을 노란색으로 변경합니다:



```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **데이터 포인트 분기 색상 설정**

“Stem 4” 분기의 색상을 변경합니다:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Sunburst/Treemap 차트의 세그먼트 순서(정렬)를 변경할 수 있나요?**

아닙니다. PowerPoint는 세그먼트를 자동으로 정렬합니다(보통 내림차순 값, 시계 방향). Aspose.Slides도 이 동작을 그대로 반영합니다: 순서를 직접 변경할 수 없으며, 데이터를 사전 처리하여 원하는 순서를 구현해야 합니다.

**프레젠테이션 테마가 세그먼트와 레이블 색상에 어떤 영향을 미치나요?**

차트 색상은 프레젠테이션의 [theme/palette](/slides/ko/net/presentation-theme/)를 상속합니다. 별도로 채우기/글꼴을 명시적으로 설정하지 않으면 테마 색상이 적용됩니다. 일관된 결과를 원한다면 필요한 수준에서 고정 색상과 텍스트 서식을 지정하십시오.

**PDF/PNG로 내보낼 때 사용자 정의 분기 색상 및 레이블 설정이 유지되나요?**

예. 프레젠테이션을 내보낼 때 차트 설정(채우기, 레이블 등)은 출력 형식에 그대로 보존됩니다. Aspose.Slides는 차트 서식이 적용된 상태로 렌더링합니다.

**차트 위에 사용자 정의 오버레이를 배치하기 위해 레이블/요소의 실제 좌표를 계산할 수 있나요?**

예. 차트 레이아웃이 확정된 후에는 `ActualX`/`ActualY`가 해당 요소(예: [DataLabel](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/datalabel/))에 대해 제공되므로, 오버레이를 정확히 배치할 수 있습니다.