---
title: Python에서 Treemap 및 Sunburst 차트의 데이터 포인트 사용자 정의
linktitle: Treemap 및 Sunburst 차트의 데이터 포인트
type: docs
url: /ko/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- 트리맵 차트
- 선버스트 차트
- 데이터 포인트
- 레이블 색상
- 분기 색상
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 트리맵 및 선버스트 차트의 데이터 포인트를 관리하는 방법을 배우고, PowerPoint 및 OpenDocument 형식과 호환됩니다."
---
## **소개**

다른 PowerPoint 차트 유형 중에서 계층 구조를 갖는 두 가지 차트가 있습니다—**Treemap** 및 **Sunburst** (Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph, Multi-Level Pie Chart 등으로도 알려짐). 이러한 차트는 트리 형태로 구성된 계층 데이터를 표시합니다—잎에서부터 가지의 상단까지. 잎은 시리즈 데이터 포인트로 정의되고, 각 후속 중첩 그룹 레벨은 해당 카테고리로 정의됩니다. Aspose.Slides for Python via .NET을 사용하면 Python에서 Sunburst 차트와 Treemap의 데이터 포인트를 서식 지정할 수 있습니다.

아래는 Series1 열의 데이터가 잎 노드를 정의하고, 다른 열이 계층 데이터 포인트를 정의하는 Sunburst 차트입니다:

![Sunburst 차트 예시](sunburst_example.png)

프레젠테이션에 새로운 Sunburst 차트를 추가해 보겠습니다:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="See also" %}}
- [**Create Sunburst Charts**](/slides/ko/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

차트 데이터 포인트를 서식 지정해야 하는 경우 다음 API를 사용하십시오:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointlevel/), 그리고 [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) 속성. 이들은 Treemap 및 Sunburst 차트의 데이터 포인트 서식에 대한 접근을 제공합니다. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointlevelsmanager/)는 다중 레벨 카테고리에 접근하기 위해 사용되며, [ChartDataPointLevel](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointlevel/) 객체의 컨테이너를 나타냅니다. 본질적으로 [ChartCategoryLevelsManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartcategorylevelsmanager/)의 래퍼이며 데이터 포인트에 특화된 추가 속성을 제공합니다. [ChartDataPointLevel](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointlevel/) 유형은 두 가지 속성—[format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointlevel/format/) 및 [label](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatapointlevel/label/)—을 노출하여 해당 설정에 접근할 수 있게 합니다.

## **데이터 포인트 값 표시**

이 섹션에서는 Treemap 및 Sunburst 차트에서 개별 데이터 포인트의 값을 표시하는 방법을 보여줍니다. 선택한 포인트에 값 레이블을 활성화하는 방법을 확인할 수 있습니다.

"Leaf 4" 데이터 포인트의 값을 표시합니다:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![데이터 포인트 값](data_point_value.png)

## **데이터 포인트에 레이블 및 색상 설정**

이 섹션에서는 Treemap 및 Sunburst 차트에서 개별 데이터 포인트에 대한 사용자 정의 레이블과 색상을 설정하는 방법을 보여줍니다. 특정 데이터 포인트에 접근하고, 레이블을 할당하고, 중요한 노드를 강조하기 위해 단색 채우기를 적용하는 방법을 배웁니다.

"Branch 1" 데이터 레이블을 카테고리 이름 대신 시리즈 이름("Series1")을 표시하도록 설정하고, 텍스트 색상을 노란색으로 지정합니다:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![데이터 포인트 레이블 및 색상](data_point_color.png)

## **데이터 포인트에 대한 분기 색상 설정**

분기 색상을 사용하면 Treemap 및 Sunburst 차트에서 부모와 자식 노드가 시각적으로 그룹화되는 방식을 제어할 수 있습니다. 이 섹션에서는 특정 데이터 포인트에 대한 사용자 정의 분기 색상을 설정하여 중요한 하위 트리를 강조하고 차트 가독성을 향상시키는 방법을 보여줍니다.

"Stem 4" 분기의 색상을 변경합니다:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![분기 색상](branch_color.png)

## **FAQ**

**Sunburst/Treemap에서 세그먼트의 순서(정렬)를 변경할 수 있나요?**

아니요. PowerPoint는 세그먼트를 자동으로 정렬합니다(일반적으로 값이 큰 순서대로 시계 방향). Aspose.Slides도 동일하게 동작합니다: 순서를 직접 변경할 수 없으며, 데이터를 사전에 처리하여 원하는 순서를 구현해야 합니다.

**프레젠테이션 테마가 세그먼트와 레이블 색상에 어떤 영향을 미치나요?**

차트 색상은 명시적으로 채우기/글꼴을 설정하지 않는 한 프레젠테이션의 [theme/palette](/slides/ko/python-net/presentation-theme/)를 상속합니다. 일관된 결과를 얻으려면 필요한 수준에서 단색 채우기와 텍스트 서식을 고정하십시오.

**PDF/PNG로 내보낼 때 사용자 정의 분기 색상 및 레이블 설정이 유지되나요?**

예. 프레젠테이션을 내보낼 경우 차트 설정(채우기, 레이블)이 출력 형식에 보존됩니다. 이는 Aspose.Slides가 차트 서식을 적용한 상태로 렌더링하기 때문입니다.

**차트 위에 사용자 정의 오버레이를 배치하기 위해 레이블/요소의 실제 좌표를 계산할 수 있나요?**

예. 차트 레이아웃이 검증된 후에는 요소에 대해 `actual_x`/`actual_y`가 제공됩니다(예: [DataLabel](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datalabel/)). 이를 통해 오버레이를 정확하게 배치할 수 있습니다.