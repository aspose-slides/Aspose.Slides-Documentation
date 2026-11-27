---
title: Python을 사용한 프레젠테이션에서 차트 서식 지정
linktitle: 차트 서식 지정
type: docs
weight: 60
url: /ko/python-net/chart-formatting/
keywords:
- 차트 서식 지정
- 차트 서식
- 차트 엔터티
- 차트 속성
- 차트 설정
- 차트 옵션
- 글꼴 속성
- 둥근 테두리
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python(.NET)를 통해 차트 서식 지정 방법을 배우고, 사용자 정의 축, 글꼴, 숫자 형식 및 둥근 차트 테두리를 활용하여 PowerPoint 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 차트를 형식화하는 방법을 설명합니다. 축, 눈금선, 제목, 범례, 플롯 영역 및 벽 채우기와 같은 주요 차트 요소를 사용자 지정하여 차트 데이터의 모양과 가독성을 향상시키는 방법을 보여줍니다.

또한 차트 텍스트의 글꼴 속성을 설정하고, 차트 데이터에 사전 정의된 숫자 형식을 적용하며, 차트 영역에 둥근 모서리를 활성화하는 방법을 보여줍니다. 이러한 예제를 통해 프레젠테이션에서 차트의 시각적 스타일과 데이터 표시를 모두 제어하는 방법을 확인할 수 있습니다.

For separate fills and outlines on rising and falling intervals, see the [주식 차트 예제](/slides/ko/python-net/create-chart/#create-stock-charts).

## **차트 엔터티 서식 지정**

차트 제목, 축, 눈금선, 범례 및 플롯 영역을 서식 지정하려면 [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)을 사용하십시오. 이 예제는 마커와 기본 데이터를 포함한 선 차트를 생성한 다음 값 축과 범주 축에 각각 텍스트와 선 스타일을 적용합니다. 글꼴 크기와 선 굵기는 포인트 단위로 지정되며, 범주 레이블은 45도 회전됩니다.

값 축은 원본 셀과 무관하게 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)을 사용합니다. 눈금은 -2에서 15까지이며, 주요 간격은 2, 보조 간격은 0.5입니다. 이 예제는 백분율 서식과 [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/)을 천 단위로 설정한 것을 결합하므로, 이러한 설정을 데이터의 의미와 규모에 맞게 조정하십시오. 범례는 [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/)가 비활성화되어 있기 때문에 플롯 영역 외부에 유지됩니다. Back-wall 및 Floor 채우기는 [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) 및 [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/)을 통해 구성하지만, 이러한 표면은 3D 차트에서만 표시됩니다.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **차트에 대한 글꼴 속성 설정**

차트 텍스트의 기본 글꼴 크기를 [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/)을 통해 설정합니다. 이 예제는 20포인트 글꼴을 사용한 클러스터형 세로 막대 차트를 생성하고 [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/)를 통해 첫 번째 시리즈에 값 레이블을 활성화합니다. 자체 명시적인 글꼴 설정이 있는 텍스트 요소는 차트 기본 설정을 재정의할 수 있습니다.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 범례에 텍스트 프레임 서식 재사용**

범례를 슬라이드 제목과 일치시키려면 제목의 첫 번째 단락에 있는 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)을 통해 글꼴을 설정합니다. 범례의 [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/)에 대해 [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/)을 호출합니다. 이는 텍스트 프레임 설정, 첫 번째 단락의 서식 및 해당 단락의 기본 글꼴 속성을 복사합니다. 개별 구문이나 이후 단락에 직접 적용된 서식은 원본에만 국한됩니다.

예제는 굵게, 네이비 색, 26포인트 Calibri로 된 제목을 템플릿으로 사용합니다. 범례 스타일링 후에는 [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/)을 사용하여 동일한 서식을 별도의 캡션에 적용합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

저장된 프레젠테이션에서 범례와 캡션은 크기, 굵기 및 색상면에서 제목과 일치합니다. 범례는 여전히 시리즈 이름을 표시하고, 캡션은 자체 텍스트를 유지합니다. 캡션의 구문에 이미 명시적인 글꼴 크기가 지정된 경우 해당 크기가 복사된 단락 기본값보다 우선합니다.

| 복사 전 | 복사 후 |
| --- | --- |
| ![정규 검은색 범례 레이블과 검은색 캡션이 있는 분기별 매출 차트](legend-formatting-before.png) | ![더 크고 굵은 네이비 범례 레이블 및 일치하는 캡션이 있는 동일 차트](legend-formatting.png) |

## **숫자 형식 설정**

[ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/)을 사용하여 차트 워크북 셀에 내장 숫자 형식을 적용합니다. 이 예제는 기본 셀 기반 데이터가 있는 클러스터형 세로 막대 차트를 생성하고 각 시리즈 값 셀에 형식 인덱스 10(`0.00%`)을 적용합니다. 이는 기본 숫자를 변경하지 않고 워크북에서 값이 표시되는 방식을 변경합니다(예: 0.25는 25.00%로 표시). 축 및 데이터 레이블 형식은 별도로 구성할 수 있습니다.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

다음 표는 영어(미국) 로케일에 대한 대표적인 Excel 형식과 함께 내장 숫자 형식 인덱스를 나열합니다. 정확한 형식 문자열과 표시 방식은 응용 프로그램 및 로케일에 따라 다를 수 있으며, 특히 통화와 날짜의 경우에 그렇습니다. 일부 Excel 형식은 [Microsoft의 숫자 형식 구현 노트](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)에 설명된 바와 같이 OOXML 표준의 기본값과도 차이가 있을 수 있습니다.

| 인덱스 | 형식 |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **차트 영역 둥근 테두리 설정**

[Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/)을 활성화하여 차트 영역의 모서리를 둥글게 합니다. 이 예제는 클러스터형 세로 막대 차트를 생성하고 [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/)을 사용하여 외곽선을 단색 회색과 단일 선 스타일로 지정한 뒤 프레젠테이션을 저장합니다.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **기존 차트 주석 편집**

차트는 보고서 상태를 설명하는 텍스트 주석과 같은 사용자 지정 도형을 포함할 수 있습니다. 이러한 도형은 [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/)을 통해 액세스합니다. 해당 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) 컬렉션에는 차트가 소유한 도형이 포함됩니다.

차트 위에 놓인 일반 텍스트 상자는 차트의 일부처럼 보여도 슬라이드에 속합니다. [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/)을 순회하면 차트와 일반 슬라이드 도형을 찾을 수 있지만 차트 내부의 개별 도형은 열거되지 않습니다. 차트 제목과 데이터 레이블은 별도의 차트 요소이며 이 컬렉션에 포함된 사용자 지정 주석이 아닙니다.

[chart-annotations.pptx](chart-annotations.pptx)를 다운로드하여 애플리케이션 작업 디렉터리에 배치합니다. 첫 번째 슬라이드에는 "예비 결과"라는 주석이 있는 차트, 차트가 소유한 선, 그리고 "슬라이드 오버레이"라는 텍스트 상자가 포함되어 있습니다. 예제는 해당 슬라이드에서 첫 번째 차트를 찾아 보고서가 게시 준비가 되면 주석을 "최종 결과"로 변경합니다. 컬렉션이 비어 있는지 확인하고 `None`이 아니며 예상 텍스트를 포함하는 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)와 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/)만을 편집합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

선과 슬라이드 텍스트 상자는 변경되지 않은 상태로 유지됩니다. 다음 이미지는 입력과 저장·재오픈된 결과를 보여줍니다:

| 편집 전 | 편집 후 |
| --- | --- |
| ![예비 결과를 읽는 차트 주석](chart-annotations-before.png) | ![최종 결과를 읽는 차트 주석](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
예제는 최상위 차트 소유 도형만 검사합니다. 주석이 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) 내부에 있는 경우 해당 그룹의 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) 컬렉션도 검사하십시오. 중첩된 그룹에 대해 재귀적으로 반복하면서 자식 도형에 동일한 텍스트 검사를 적용합니다. 그룹 자체는 컨테이너이며 텍스트 상자로 취급하지 마십시오.
{{% /alert %}}

## **자주 묻는 질문**

**열/영역에 반투명 채우기를 적용하면서 테두리는 불투명하게 유지할 수 있나요?**

예. 채우기 투명도와 외곽선은 별도로 구성됩니다. 이는 복잡한 시각화에서 격자와 데이터의 가독성을 향상시키는 데 유용합니다.

**데이터 레이블이 겹칠 때 어떻게 처리할 수 있나요?**

글꼴 크기를 줄이고, 필수적이지 않은 레이블 구성 요소(예: 카테고리)를 비활성화하며, 레이블 위치를 조정하고, 필요에 따라 선택된 점에만 레이블을 표시하거나, 형식을 "값 + 범례"로 전환하십시오.

**시리즈에 그라디언트 또는 패턴 채우기를 적용할 수 있나요?**

예. 시리즈는 단색, 그라디언트 및 패턴 채우기를 지원합니다. 실제로는 그라디언트를 적게 사용하고, 격자와 텍스트와의 대비를 떨어뜨리는 조합은 피하십시오.