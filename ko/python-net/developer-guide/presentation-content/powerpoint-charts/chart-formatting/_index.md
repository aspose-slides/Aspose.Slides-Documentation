---
title: Python을 사용한 프레젠테이션에서 차트 서식 지정
linktitle: 차트 서식 지정
type: docs
weight: 60
url: /ko/python-net/chart-formatting/
keywords:
- 차트 서식 지정
- 차트 서식
- 차트 개체
- 차트 속성
- 차트 설정
- 차트 옵션
- 글꼴 속성
- 둥근 테두리
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 .NET을 통해 차트 서식 지정 방법을 배우고, 전문적이고 시각적으로 돋보이는 스타일로 PowerPoint 또는 OpenDocument 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 차트를 서식 지정하는 방법을 설명합니다. 축, 눈금선, 제목, 범례, 플롯 영역 및 벽 채우기와 같은 핵심 차트 요소를 사용자 지정하여 차트 데이터의 모양과 가독성을 개선하는 방법을 보여줍니다.

또한 차트 텍스트의 글꼴 속성을 설정하고, 차트 데이터에 사전 설정 및 사용자 지정 숫자 형식을 적용하며, 차트 영역에 둥근 모서리를 활성화하는 방법을 시연합니다. 이러한 예제를 통해 프레젠테이션의 차트 시각 스타일과 데이터 표시를 모두 제어하는 방법을 확인할 수 있습니다.

## **차트 요소 서식 지정**

Aspose.Slides for Python은 개발자가 처음부터 슬라이드에 사용자 지정 차트를 추가할 수 있도록 합니다. 이 섹션에서는 범주 축 및 값 축을 포함한 다양한 차트 요소를 서식 지정하는 방법을 설명합니다.

Aspose.Slides는 차트 요소를 관리하고 사용자 지정 서식을 적용하기 위한 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 원하는 유형(이 예에서는 `ChartType.LINE_WITH_MARKERS`)의 기본 데이터를 사용하여 차트를 추가합니다.
1. 차트의 값 축에 접근하고 다음을 설정합니다:
   1. 값 축 주요 눈금선에 대한 **선 서식**을 설정합니다.
   1. 값 축 보조 눈금선에 대한 **선 서식**을 설정합니다.
   1. 값 축에 대한 **숫자 서식**을 설정합니다.
   1. 값 축에 대한 **최소, 최대, 주요 및 보조 단위**를 설정합니다.
   1. 값 축 레이블에 대한 **텍스트 속성**을 설정합니다.
   1. 값 축에 대한 **제목**을 설정합니다.
   1. 값 축에 대한 **선 서식**을 설정합니다.
1. 차트의 범주 축에 접근하고 다음을 설정합니다:
   1. 범주 축 주요 눈금선에 대한 **선 서식**을 설정합니다.
   1. 범주 축 보조 눈금선에 대한 **선 서식**을 설정합니다.
   1. 범주 축 레이블에 대한 **텍스트 속성**을 설정합니다.
   1. 범주 축에 대한 **제목**을 설정합니다.
   1. 범주 축에 대한 **레이블 위치 지정**을 설정합니다.
   1. 범주 축 레이블에 대한 **회전 각도**를 설정합니다.
1. 차트 범례에 접근하고 **텍스트 속성**을 설정합니다.
1. 차트와 겹치지 않도록 차트 범례를 표시합니다.
1. 차트의 **보조 값 축**에 접근하고 다음을 설정합니다:
   1. 보조 **값 축**을 활성화합니다.
   1. 보조 값 축에 대한 **선 서식**을 설정합니다.
   1. 보조 값 축에 대한 **숫자 서식**을 설정합니다.
   1. 보조 값 축에 대한 **최소, 최대, 주요 및 보조 단위**를 설정합니다.
1. 첫 번째 차트 시리즈를 보조 값 축에 플롯합니다.
1. 차트 뒷면 채우기 색상을 설정합니다.
1. 차트 플롯 영역 채우기 색상을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:

    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 샘플 차트를 추가합니다.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # 차트 제목을 설정합니다.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # 값 축에 대한 주요 눈금선 서식을 설정합니다.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # 값 축에 대한 보조 눈금선 서식을 설정합니다.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # 값 축 숫자 서식을 설정합니다.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # 값 축 최대값, 최소값, 주요 단위 및 보조 단위를 설정합니다.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # 값 축 텍스트 속성을 설정합니다.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # 값 축 제목을 설정합니다.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # 범주 축에 대한 주요 눈금선 서식을 설정합니다.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # 범주 축에 대한 보조 눈금선 서식을 설정합니다.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # 범주 축 텍스트 속성을 설정합니다.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # 범주 축 제목을 설정합니다.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # 범주 축 레이블 위치를 설정합니다.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # 범주 축 레이블 회전 각도를 설정합니다.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # 범례 텍스트 속성을 설정합니다.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # 차트에 겹쳐서 차트 범례를 표시합니다.
    chart.legend.overlay = True
                
    # 차트 뒷벽 색상을 설정합니다.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # 플롯 영역 색상을 설정합니다.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # 프레젠테이션을 저장합니다.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 글꼴 속성 설정**

Aspose.Slides for Python은 차트에 대한 글꼴 관련 속성 설정을 지원합니다. 아래 단계에 따라 차트 글꼴 속성을 구성합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 개체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 글꼴 높이를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

아래에 샘플 코드가 제공됩니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **숫자 서식 설정**

Aspose.Slides for Python은 차트 데이터 서식을 관리하기 위한 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 얻습니다.
1. 원하는 유형의 기본 데이터를 사용하여 차트를 추가합니다.
1. 사용 가능한 사전 설정 값 중에서 사전 설정 숫자 서식을 설정합니다.
1. 각 시리즈의 차트 데이터 셀을 순회하면서 숫자 서식을 설정합니다.
1. 프레젠테이션을 저장합니다.
1. 사용자 지정 숫자 서식을 설정합니다.
1. 각 시리즈의 차트 데이터 셀을 순회하면서 다른 숫자 서식을 설정합니다.
1. 프레젠테이션을 저장합니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 기본 클러스터형 컬럼 차트를 추가합니다.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # 사전 설정 숫자 서식을 설정합니다.
    # 각 차트 시리즈를 순회합니다.
    for series in chart.chart_data.series:
        # 시리즈의 각 데이터 포인트를 순회합니다.
        for cell in series.data_points:
            # 숫자 서식을 설정합니다.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # 프레젠테이션을 저장합니다.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

사용 가능한 사전 설정 숫자 서식 및 해당 인덱스는 아래에 나열되어 있습니다.

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **차트 영역에 둥근 테두리 설정**

Aspose.Slides for Python은 `Chart.has_rounded_corners` 속성을 사용하여 차트 영역을 구성하는 것을 지원합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 개체를 인스턴스화합니다.
2. 슬라이드에 차트를 추가합니다.
3. 차트의 채우기 유형 및 채우기 색상을 설정합니다.
4. 둥근 모서리 속성을 `True` 로 설정합니다.
5. 수정된 프레젠테이션을 저장합니다.

아래에 샘플이 제공됩니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**열/영역에 반투명 채우기를 적용하면서 테두리는 불투명하게 유지할 수 있나요?**

예. 채우기 투명도와 외곽선은 별도로 구성됩니다. 이는 복잡한 시각화에서 격자와 데이터의 가독성을 개선하는 데 유용합니다.

**레이블이 겹칠 경우 어떻게 처리하나요?**

글꼴 크기를 줄이거나, 불필요한 레이블 요소(예: 카테고리)를 비활성화하고, 레이블 오프셋/위치를 조정하며, 필요에 따라 선택된 포인트에만 레이블을 표시하거나 “값 + 범례” 형식으로 전환합니다.

**시리즈에 그라디언트 또는 패턴 채우기를 적용할 수 있나요?**

예. 일반적으로 단색과 그라디언트/패턴 채우기가 모두 제공됩니다. 실제로는 그라디언트를 적게 사용하고, 격자와 텍스트 대비를 저하시킬 수 있는 조합은 피하는 것이 좋습니다.