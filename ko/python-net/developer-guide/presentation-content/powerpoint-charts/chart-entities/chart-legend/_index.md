---
title: Python을 사용하여 프레젠테이션에서 차트 범례 맞춤 설정
linktitle: 차트 범례
type: docs
url: /ko/python-net/chart-legend/
keywords:
- 차트 범례
- 범례 위치
- 글꼴 크기
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 차트 범례를 맞춤 설정하고, PowerPoint 프레젠테이션을 최적화합니다."
---
## **개요**

Aspose.Slides for Python via .NET은 PowerPoint 프레젠테이션에서 차트 범례를 사용자 정의할 수 있는 옵션을 제공합니다. 이 문서에서는 범례의 위치와 크기를 지정하고, 전체 범례의 글꼴 크기를 설정하며, 개별 범례 항목을 서식 지정하고, 선택된 항목을 숨기거나 복원하는 방법을 보여줍니다.

FAQ에서는 범례를 위한 공간을 예약하는 것, 다중 라인 레이블 표시, 프레젠테이션 테마에서 서식 상속 등에 관한 동작을 다룹니다.

## **범례 위치 지정**

범례의 [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), 및 [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) 속성을 사용하여 차트 차원의 일부 비율로 위치와 크기를 지정합니다.

이 예제는 프레젠테이션을 만든 다음 기본 데이터가 포함된 클러스터형 열 차트를 첫 번째 슬라이드에 추가합니다. 원하는 범례 오프셋과 크기를 차트의 너비와 높이로 나누어 상대값으로 변환합니다. 범례는 차트 왼쪽 위 모서리에서 50포인트 떨어져 위치하고 크기는 100 × 100포인트입니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # 차트에 대한 범례의 위치와 크기를 상대적으로 지정합니다.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **범례의 글꼴 크기 설정**

범례의 [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/)을 사용하여 텍스트 서식에 접근하고 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/)를 포인트 단위로 설정합니다.

이 예제는 기본 데이터가 있는 차트를 만들고 범례 텍스트를 20포인트로 설정합니다. 또한 수직 축에 대한 자동 경계를 비활성화하고 범위를 -5에서 10으로 설정합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **개별 범례 항목의 글꼴 크기 설정**

범례의 [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) 컬렉션을 사용하여 특정 항목의 서식에 접근합니다. 항목 인덱스는 0부터 시작하므로 인덱스 `1`은 두 번째 항목을 의미합니다.

이 예제는 기본 데이터에 최소 두 개의 시리즈가 포함된 클러스터형 열 차트를 생성합니다. 두 번째 범례 항목을 굵게, 기울임꼴, 20포인트 파란색 텍스트로 서식 지정합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **개별 범례 항목 숨기기**

보조 시리즈를 범례에서 제외하되 데이터는 표시하려면 [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/)을 `True`로 설정하고 [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/)를 통해 지정합니다. 이렇게 하면 선택한 범례 항목만 숨겨지고 시리즈나 데이터 포인트는 제거되지 않습니다. 반면에 [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/)를 `False`로 설정하면 전체 범례가 숨겨집니다.

아래 예제는 기본 데이터를 사용하여 여러 시리즈가 포함된 클러스터형 열 차트를 생성합니다. 두 번째 시리즈의 범례 항목(인덱스 `1`)을 숨기고 프레젠테이션을 저장합니다. 그런 다음 [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/)를 `False`로 설정하여 항목을 복원하고 두 번째 사본을 저장합니다. 두 파일 모두에서 열은 계속 표시됩니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # 차트 데이터를 변경하지 않고 동일한 항목을 복원합니다.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

아래 비교는 모든 항목이 보이는 차트와 두 번째 항목이 숨겨진 차트를 보여줍니다. 두 번째 시리즈의 열은 그대로 유지됩니다.

![모든 범례 항목이 보이는 차트와 2번 시리즈의 범례 항목이 숨겨진 차트 비교; 모든 열은 보존됩니다.](hide-legend-entry.png)

열, 막대 및 선 차트에서는 범례 항목이 시리즈를 식별합니다. 파이 차트에서는 개별 데이터 포인트(조각)를 식별하므로 선택된 조각에 대해 [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/)를 사용합니다. API는 `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE`, `BAR_OF_PIE` 차트 유형에 대해 이 데이터 포인트 속성을 문서화합니다. 도넛 차트에는 적용되지 않으므로 가정하지 마십시오.

## **FAQ**

**차트가 범례 위에 겹쳐 표시하지 않고 범례를 위한 공간을 할당하도록 할 수 있나요?**

예. [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/)를 `False`로 설정하면 범례가 플롯 영역과 겹치는 대신 공간을 예약합니다.

**다중 라인 범례 레이블을 만들 수 있나요?**

예. 가용 너비가 충분하지 않을 때 긴 레이블은 자동으로 줄바꿈됩니다. 시리즈 이름에 개행 문자를 넣어 직접 줄바꿈을 지정할 수도 있습니다.

**범례가 프레젠테이션 테마의 색 구성표를 따르게 하려면 어떻게 해야 하나요?**

범례의 색상, 채우기 및 글꼴을 설정하지 않으면 테마 서식을 상속받습니다. 명시적인 서식 지정은 해당 테마 설정을 덮어씁니다.