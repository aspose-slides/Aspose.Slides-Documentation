---
title: Python으로 프레젠테이션의 차트 워크북 관리
linktitle: 차트 워크북
type: docs
weight: 70
url: /ko/python-net/chart-workbook/
keywords:
- 차트 워크북
- 차트 데이터
- 워크북 셀
- 데이터 레이블
- 워크시트
- 데이터 소스
- 외부 워크북
- 외부 데이터
- 차트 캐시
- 워크북 복구
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 발견하세요: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 액세스하는 방법, 차트 값의 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 시연합니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 빈 셀과 0의 차이 및 라인 차트에서 사용 가능한 표시 모드 비교를 위해 [빈 셀 표시 제어](/slides/ko/python-net/chart-series/)를 참조하십시오.

## **숨겨진 행 및 열의 데이터 포함**

숨겨진 워크시트 행 및 열에서 데이터를 플롯할지 여부를 제어하려면 [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/)를 사용하십시오. `True` 로 설정하면 보이는 셀만 플롯하고, `False` 로 설정하면 보이는 셀과 숨겨진 셀 모두 포함합니다. 이 설정은 차트 플롯에만 영향을 주며 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[샘플 프레젠테이션](hidden-source-data.pptx)에는 첫 슬라이드의 첫 번째 도형으로 열 차트가 포함되어 있습니다. 삽입된 워크시트 `Sheet1`에는 소스 범위 `A1:C4`가 있습니다. 행 3과 열 C가 숨겨져 있지만 셀 값은 여전히 존재합니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매 (숨겨진 열) |
| --- | --- | --- | --- |
| 2 | 1월 | 10 | 30 |
| 3 (숨겨진 행) | 2월 | 40 | 60 |
| 4 | 3월 | 20 | 50 |

소스 셀에 접근하려면 [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)를 사용하고, [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/)을 읽어 숨김 상태를 확인하십시오. 이 속성은 읽기 전용입니다. 이 파일에서 B2는 보이고, B3은 숨겨진 행에 속하며, C2는 숨겨진 열에 속합니다; 예제에서는 각각 `False`, `True`, `True` 를 출력합니다.

이 예제에서는 플로팅 설정을 변경한 후 차트 데이터를 새로 고칩니다: 삽입된 워크북을 [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)으로 유지하고 [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)으로 다시 로드합니다. 모든 셀을 포함할 때는 [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)을 사용하여 숨겨진 2월 범주를 포함한 전체 범위를 복원합니다. 플래그만 변경하는 것으로는 이 샘플의 캐시된 차트 데이터와 범주 레이블을 새로 고칠 수 없습니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # 삽입된 워크북에서 차트 데이터를 새로 고칩니다.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # 숨겨진 카테고리를 포함한 전체 소스 범위를 복원합니다.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

예제는 프레젠테이션을 두 버전으로 저장합니다: 보이는 소매 값(10 및 20)만 포함한 버전과 모든 여섯 값이 포함된 버전입니다. 아래 이미지는 저장된 프레젠테이션을 다시 연 후 렌더링한 결과이며, 두 파일 모두 할당된 플로팅 설정을 유지합니다. 행 3과 열 C는 두 삽입 워크북 모두에서 여전히 숨겨져 있습니다.

| 보이는 셀만 (`True`) | 전체 셀 (`False`) |
| --- | --- |
| ![보이는 셀만: 1월 및 3월의 소매 값 10 및 20.](hidden_cells_True.png) | ![전체 셀: 1월, 2월, 3월의 소매 및 도매 값.](hidden_cells_False.png) |

값이 있는 숨겨진 셀은 빈 셀과 다릅니다. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)는 누락된 값이 표시되는 방식을 제어하며, 숨겨진 소스 데이터를 포함하거나 제외하지는 않습니다. 예제는 [빈 셀 표시 제어](/slides/ko/python-net/chart-series/#control-the-display-of-empty-cells)를 참고하십시오.

## **차트 데이터 범위 가져오기**

기존 프레젠테이션에서 워크북 데이터를 업데이트하기 전에, 차트가 사용하는 워크시트 셀을 식별하기 위해 소스 범위를 검사합니다. [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) 메서드는 현재 데이터 범위를 워크시트 지정 수식으로 반환합니다(예: `Sheet1!$A$1:$D$5`). 여기서 `Sheet1`은 워크시트 이름이며, `!`는 셀 범위와 구분하고, `$A$1:$D$5`는 절대 행·열 참조를 나타냅니다.

이 메서드는 차트나 워크북을 변경하지 않고 현재 범위를 읽어옵니다. 차트가 워크북을 데이터 소스로 사용하지 않으면 예외가 발생합니다. 자세한 내용은 [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)를 참조하십시오.

예제는 프레젠테이션을 열고 각 슬라이드의 도형을 직접 확인하여 차트를 찾아냅니다. 차트 이름과 소스 범위를 출력합니다. 범위를 가져올 수 없으면 진단 메시지를 출력하고 다음 차트로 진행합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **워크북에서 차트 데이터 읽고 쓰기**

Aspose.Slides for Python via .NET은 [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) 및 [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells 로 편집된 차트 데이터 포함)을 읽고 쓸 수 있습니다. **Note** 차트 데이터는 동일한 방식으로 구성되어 있거나 소스와 유사한 구조여야 합니다.

예제는 첫 슬라이드 첫 번째 도형에 차트가 포함된 프레젠테이션을 사용합니다. 삽입된 워크북을 스트림으로 읽고, 기존 시리즈와 카테고리를 지우고, 동일한 워크북을 다시 씁니다. 변경 내용은 메모리에 남으며 프레젠테이션은 저장하지 않습니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **워크북 수정 후 차트 레이아웃 검증**

삽입 워크북을 수정된 워크북으로 교체하면 차트는 원래의 시리즈 및 카테고리 컬렉션을 유지합니다. 이 불일치 때문에 [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)이 인덱스 범위 초과 오류로 실패할 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 카테고리를 지우십시오. 이 예제는 첫 슬라이드 첫 번째 도형에 차트가 있는 경우를 사용합니다. 주석은 워크북 편집이 발생할 위치를 표시합니다; 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리에서 레이아웃을 검증합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # 워크북 스트림을 여기서 수정합니다. 예를 들어 Aspose.Cells를 사용합니다.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

컬렉션을 지우면 워크북이 다시 쓰이기 전에 오래된 데이터 참조가 제거됩니다. 업데이트된 워크북에 대해 필요한 시리즈 및 카테고리 매핑을 다시 구축한 뒤 차트를 사용하십시오.

## **워크북 셀에 사용자 정의 숫자 형식 지정**

[ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/)을 사용하여 차트 삽입 워크북에서 숫자 값이 표시되는 방식을 제어할 수 있습니다. 예를 들어 보고서에 변환율을 소수점 네 자리 백분율로, 계수를 소수점 다섯 자리로 표시해야 할 수 있습니다. 두 값 모두 계산 및 차트 플롯에 사용할 수 있도록 숫자형으로 유지하십시오.

숫자 형식은 표시 방식을 변경할 뿐 저장값은 바꾸지 않습니다. 형식 `0.0000%`는 `0.125`를 `12.5000%`로 표시하지만 저장된 숫자를 `12.5`로 바꾸지는 않습니다. 마찬가지로 `0.00000`은 `0.1234567`을 `0.12346`으로 표시하지만 저장된 값은 반올림하지 않습니다. 사용자 정의 형식이 빈 문자열(`""`)인 경우 [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/)이 대신 사용됩니다.

다음 예제는 열 차트를 만들고 [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)을 통해 셀에 접근합니다. 워크시트 0의 B2에는 변환율이, C2에는 계수가 들어 있습니다. 두 셀 모두 차트 값으로 사용됩니다. 예제는 또한 소스 형식에 연결된 값 레이블을 활성화합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

워크북 셀 형식은 차트 축이나 데이터 레이블에 직접 설정된 형식과 별개입니다. 이 예제에서 각 레이블은 [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/)가 활성화되어 소스 셀 값을 표시하고, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/)가 `True`이므로 소스 숫자 형식을 따릅니다. 프레젠테이션을 저장하고 다시 연 후 레이블은 `12.5000%`와 `0.12346`을 표시합니다(아래 이미지 참조). 수직 축은 자체 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00`을 사용하고, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)가 `False`로 설정됩니다.

데이터 레이블을 독립적으로 서식 지정하려면 해당 레이블의 source‑link 플래그를 `False`로 설정하고 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/)을 지정하십시오. 이렇게 해도 워크북 셀 형식은 변경되지 않습니다. 예를 들어 독립 레이블 형식 `0.00`은 첫 값을 `0.13`으로 표시하지만 B2는 여전히 `12.5000%`를 표시합니다. 직접 레이블 서식 지정 예제는 [Chart Data Labels](/slides/ko/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels)를 참조하십시오.

![소스 연결 레이블이 12.5000%와 0.12346을 표시하고 독립적으로 서식이 지정된 숫자 축이 있는 열 차트.](custom-cell-formats.png)

## **워크북 셀을 차트 데이터 레이블로 설정**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다.

예제는 기존 프레젠테이션 첫 슬라이드에 기본 데이터가 있는 버블 차트를 추가합니다. 워크시트 0의 A10:A12 셀을 첫 번째 시리즈의 처음 세 레이블로 사용하고, 셀에서 레이블을 활성화한 뒤 업데이트된 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **워크시트 관리**

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) 속성은 차트 워크북에 포함된 워크시트에 대한 액세스를 제공합니다. 이 예제는 기본 데이터가 있는 원형 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **데이터 소스 유형 지정**

시리즈 포인트 값은 숫자 리터럴로 직접 저장할 수도 있습니다. 전체 예제는 [Set Series Values Using Numeric Literals](/slides/ko/python-net/chart-series/#set-series-values-using-numeric-literals)를 참조하십시오. 포인트 값의 소스 유형은 차트의 내부 또는 외부 워크북 구성과 별개이며, 숫자 리터럴을 사용한다고 해서 삽입 워크북이 자동으로 제거되지는 않습니다.

예제는 기본 데이터가 있는 3D 열 차트를 만들고 두 시리즈 이름을 서로 다른 데이터 소스로 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째는 워크시트 0의 C1 셀을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) 열거형은 각 이름의 소스를 선택합니다. 예제는 업데이트된 시리즈 이름을 포함하여 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **지원되지 않는 임베드 워크북 형식 감지**

Aspose.Slides는 일부 차트에 삽입될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)의 [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) 속성과 [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) 열거형을 함께 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 기존 프레젠테이션의 첫 슬라이드에 있는 도형을 검사하고, 차트가 아닌 도형을 건너뛰며, .xlsb 워크북이 삽입된 각 차트에 대해 진단 메시지를 출력합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # 지원되는 차트 워크북 데이터를 여기서 읽거나 수정합니다.
```

## **외부 워크북**

Aspose.Slides는 외부 워크북을 차트의 데이터 소스로 사용하는 것을 지원합니다.

### **외부 워크북 만들기**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) 및 [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)을 사용하여 삽입 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

예제는 기본 데이터가 있는 원형 차트를 만들고 워크북을 내보냅니다. 외부 워크북을 차트 데이터 소스로 할당하기 전에 출력 스트림을 닫고, 링크된 프레젠테이션을 저장합니다.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **외부 워크북 설정**

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 메서드를 사용하면 외부 워크북을 차트의 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북 경로가 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북 데이터를 직접 편집할 수는 없지만, 외부 데이터 소스로는 사용할 수 있습니다. 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

예제는 워크시트 `Sheet1`에 B1에 시리즈 이름, A2:A4에 범주 이름, B2:B4에 숫자 값을 가진 외부 워크북을 사용합니다. 원형 차트를 만들고, 워크북을 연결한 뒤, [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)을 사용해 A1:B4를 하나의 시리즈와 세 범주에 매핑합니다. 링크된 차트와 함께 프레젠테이션을 저장합니다.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)의 `update_chart_data` 매개변수는 워크북을 로드할지 여부를 제어합니다.

* `update_chart_data`가 `False`이면 워크북 경로만 업데이트됩니다. 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않으므로 워크북이 없어도 됩니다.
* `update_chart_data`가 `True`이면 차트 데이터가 대상 워크북에서 업데이트됩니다.

다음 예제는 `update_chart_data`를 `False`로 설정하고 자리 표시자 URL을 할당합니다. 이 경우 원형 차트는 기본 데이터를 유지하고, 사용할 수 없는 워크북을 로드하지 않은 채 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **차트의 외부 데이터 소스 워크북 경로 가져오기**

차트에 연결된 워크북을 확인하려면 차트가 외부 데이터 소스를 사용하는지 확인하고 워크북 경로를 가져옵니다.

예제는 외부 워크북이 연결된 프레젠테이션의 첫 슬라이드 첫 번째 도형을 검사합니다. 해당 도형이 외부 워크북에 연결된 차트인 경우 [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)를 콘솔에 출력하고, 프레젠테이션 사본을 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **차트 데이터 편집**

외부 워크북의 데이터를 내부 워크북과 동일한 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없는 경우 예외가 발생합니다.

예제는 첫 슬라이드 첫 번째 도형에 있는 차트가 접근 가능한 외부 워크북에 연결되어 있다고 가정합니다. 첫 번째 시리즈의 첫 번째 데이터 포인트 값을 100으로 설정하고 업데이트된 프레젠테이션을 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트되므로 원본 워크북을 보존하려면 복사본을 사용하십시오.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **차트 캐시에서 워크북 복구**

차트가 존재하지 않거나 사용할 수 없는 외부 워크북을 사용하고 있을 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)를 생성하고, 해당 옵션의 [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/)를 구성한 뒤, [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/)를 `True`로 설정하고 프레젠테이션을 엽니다.

다음 Python 예제는 첫 슬라이드 첫 번째 도형에 있는 차트가 사용할 수 없는 외부 워크북을 참조하는 경우 워크북 데이터를 복구합니다. 복구된 데이터는 [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/)와 [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)를 통해 접근합니다:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # 여기에서 복구된 워크북 데이터를 읽거나 수정합니다.
    else:
        print("The first shape is not a chart.")
```

외부 워크북이 사용 불가능하고 복구가 비활성화된 경우 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 경우에만 복구를 활성화하십시오. 캐시는 외부 워크북이 마지막으로 프레젠테이션이 업데이트된 이후에 변경된 내용을 포함하지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지 임베드된 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)와 [external workbook path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)가 있습니다; 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용 중인지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 절대 경로를 PPTX 파일에 저장하므로 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 위치한 워크북을 사용할 수 있나요?**

예, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서는 원격 워크북을 직접 편집하는 것을 지원하지 않으며, 소스로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX를 덮어쓰나요?**

프레젠테이션은 [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)을 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본 워크북을 변경하지 않아야 하면 워크북 사본을 사용하십시오.

**외부 파일이 비밀번호로 보호된 경우 어떻게 해야 하나요?**

Aspose.Slides는 링크 시 비밀번호를 받지 않습니다. 일반적인 방법은 미리 보호를 해제하거나, 예를 들어 [Aspose.Cells](https://reference.aspose.com/cells/python-net/)를 사용해 복호화된 사본을 만든 뒤 해당 사본에 링크하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 같은 파일을 가리키면 해당 파일을 업데이트할 때마다 다음 데이터 로드 시 모든 차트에 반영됩니다.