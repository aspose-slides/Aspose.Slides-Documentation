---
title: Python으로 프레젠테이션에서 차트 워크북 관리
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
- 데이터 원본
- 외부 워크북
- 외부 데이터
- 차트 캐시
- 워크북 복구
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 발견하고, PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화하십시오."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법 및 차트 값에 대한 데이터 원본 유형을 지정하는 방법을 보여줍니다.

또한 차트 데이터 원본으로 외부 워크북을 사용하는 방법을 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북을 사용할 수 있을 때 차트 데이터를 편집하는 방법을 시연합니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 [빈 셀 표시 제어](/slides/ko/python-net/chart-series/)를 참조하여 빈 셀과 0의 차이 및 라인 차트에서 사용할 수 있는 표시 모드를 확인하십시오.

## **숨겨진 행 및 열의 데이터 포함**

[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/)을 사용하여 차트가 숨겨진 워크시트 행 및 열의 데이터를 플롯할지 여부를 제어합니다. `True`로 설정하면 보이는 셀만 플롯하고, `False`로 설정하면 보이는 셀과 숨겨진 셀을 모두 포함합니다. 이 설정은 차트 플로팅에만 영향을 주며 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[샘플 프레젠테이션](hidden-source-data.pptx)에는 첫 번째 슬라이드의 첫 번째 도형으로 열 차트가 포함되어 있습니다. 포함된 워크시트 `Sheet1`에는 소스 범위 `A1:C4`가 있습니다. 3행과 C열은 숨겨져 있지만 셀 값은 그대로 있습니다.

| 워크시트 행 | 월 | 소매 | 도매 (숨겨진 열) |
| --- | --- | --- | --- |
| 2 | 1월 | 10 | 30 |
| 3 (숨긴 행) | 2월 | 40 | 60 |
| 4 | 3월 | 20 | 50 |

[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)을 통해 소스 셀에 접근하고 [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/)을 읽어서 숨김 상태를 확인합니다. 이 속성은 읽기 전용입니다. 이 파일에서 B2는 보이고, B3은 숨겨진 행에 속하며, C2는 숨겨진 열에 속합니다; 예제는 각각 `False`, `True`, `True`를 출력합니다.

이 예제에서는 플롯 설정을 변경한 후 차트 데이터를 새로 고칩니다: 포함된 워크북을 [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)으로 유지하고 [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)으로 다시 로드합니다. 모든 셀을 포함할 때는 [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)를 사용하여 숨겨진 2월 카테고리를 포함한 전체 범위를 복원합니다. 단순히 플래그만 변경해도 이 샘플의 캐시된 차트 데이터와 카테고리 레이블을 새로 고치기에 충분하지 않습니다.

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

            # 임베드된 워크북에서 차트 데이터를 새로 고칩니다.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # 숨겨진 카테고리를 포함한 전체 소스 범위를 복원합니다.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

예제는 프레젠테이션을 두 버전으로 저장합니다: 보이는 소매 값(10 및 20)만 포함한 버전과 모든 여섯 값을 포함한 버전입니다. 아래 이미지는 저장된 프레젠테이션을 다시 열어 렌더링한 결과이며, 두 파일 모두 지정된 플롯 설정을 유지합니다. 행 3과 열 C는 두 포함된 워크북 모두에서 계속 숨겨져 있습니다.

| 보이는 셀만 (`True`) | 전체 셀 (`False`) |
| --- | --- |
| ![보이는 셀만: 1월 및 3월에 대한 소매 값 10 및 20.](hidden_cells_True.png) | ![전체 셀: 1월, 2월, 3월에 대한 소매 및 도매 값.](hidden_cells_False.png) |

값이 있는 숨겨진 셀은 빈 셀과 다릅니다. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)은 누락된 값을 표시하는 방식을 제어하지만 숨겨진 소스 데이터를 포함하거나 제외하지는 않습니다. 예제는 [빈 셀 표시 제어](/slides/ko/python-net/chart-series/#control-the-display-of-empty-cells)를 참고하십시오.

## **차트 데이터 범위 가져오기**

기존 프레젠테이션에서 워크북 데이터를 업데이트하기 전에, 차트가 사용하는 워크시트 셀을 식별하기 위해 소스 범위를 검사합니다. [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) 메서드는 현재 데이터 범위를 워크시트 한정 수식 형태로 반환합니다(예: `Sheet1!$A$1:$D$5`). 여기서 `Sheet1`은 워크시트 이름이며, `!`는 셀 범위와 구분하고, `$A$1:$D$5`는 절대 행·열 참조를 나타냅니다.

이 메서드는 차트나 워크북을 변경하지 않고 현재 범위를 읽습니다. 차트가 워크북을 데이터 원본으로 사용하지 않으면 예외가 발생합니다. 자세한 내용은 [ChartData API 참조](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)를 확인하십시오.

이 예제는 프레젠테이션을 열고 각 슬라이드의 도형을 직접 확인하여 차트를 찾습니다. 차트 이름과 소스 범위를 출력하고, 범위를 가져올 수 없으면 진단 메시지를 출력한 뒤 다음 차트로 진행합니다.

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

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides for Python via .NET은 [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) 및 [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) 메서드를 제공하여 차트 데이터 워크북(즉, Aspose.Cells로 편집된 차트 데이터 포함)을 읽고 쓸 수 있습니다. **Note** 차트 데이터는 동일한 방식으로 구성되어 있거나 원본과 유사한 구조를 가져야 합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 프레젠테이션을 사용합니다. 포함된 워크북을 스트림으로 읽고, 기존 시리즈와 카테고리를 지운 뒤 같은 워크북을 다시 씁니다. 변경 내용은 메모리에 남으며 프레젠테이션은 저장하지 않습니다.

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

임베드된 워크북을 수정된 워크북으로 교체하면 차트가 원래의 시리즈와 카테고리 컬렉션을 유지합니다. 이 불일치로 인해 [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)이 인덱스 범위 초과 오류를 발생시킬 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 카테고리를 지우십시오. 이 예제는 첫 번째 슬라이드의 첫 번째 도형인 차트를 사용합니다. 주석은 워크북 편집이 발생할 위치를 표시하며, 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리에서 레이아웃을 검증합니다.

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

컬렉션을 비우면 워크북을 다시 쓰기 전에 오래된 데이터 참조가 제거됩니다. 업데이트된 워크북에 필요한 시리즈 및 카테고리 매핑을 다시 구축한 뒤 차트를 사용하십시오.

## **워크북 셀을 차트 데이터 레이블로 설정**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다.

이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 기본 데이터가 있는 버블 차트를 추가합니다. 워크시트 0의 셀 A10:A12를 첫 번째 시리즈의 처음 세 레이블로 사용하고, 셀에서 레이블을 활성화한 뒤 업데이트된 프레젠테이션을 저장합니다.

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

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) 속성은 차트 워크북의 워크시트에 접근할 수 있게 합니다. 이 예제는 기본 데이터가 있는 파이 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

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

## **데이터 원본 유형 지정**

이 예제는 기본 데이터가 있는 3D 컬럼 차트를 만들고 두 시리즈 이름을 서로 다른 데이터 원본으로 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째는 워크시트 0의 셀 C1을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) 열거형은 각 이름의 소스를 선택합니다. 예제는 업데이트된 시리즈 이름으로 프레젠테이션을 저장합니다.

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

## **지원되지 않는 포함된 워크북 형식 감지**

Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)의 [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) 속성과 [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) 열거형을 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 있는 도형을 검사하고, 차트가 아닌 도형은 건너뛰며, .xlsb 워크북이 포함된 차트에 대해 진단 메시지를 출력합니다.

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

Aspose.Slides는 차트의 데이터 원본으로 외부 워크북을 사용하는 것을 지원합니다.

### **외부 워크북 만들기**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)와 [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)을 사용하여 포함된 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

이 예제는 기본 데이터가 있는 파이 차트를 만들고 워크북을 내보냅니다. 외부 워크북을 차트 데이터 원본으로 할당하기 전에 출력 스트림을 닫고, 연결된 프레젠테이션을 저장합니다.

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 메서드를 사용하면 차트의 데이터 원본으로 외부 워크북을 할당할 수 있습니다. 이 메서드는 외부 워크북이 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 직접 편집할 수는 없지만, 이러한 워크북을 외부 데이터 원본으로 사용할 수 있습니다. 상대 경로가 제공되면 자동으로 절대 경로로 변환됩니다.

이 예제는 워크시트 `Sheet1`에 B1에 시리즈 이름, A2:A4에 카테고리 이름, B2:B4에 숫자 값을 가진 외부 워크북을 사용합니다. 파이 차트를 만든 뒤 워크북을 연결하고, [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)을 사용하여 A1:B4를 하나의 시리즈와 세 개의 카테고리로 매핑합니다. 연결된 차트와 함께 프레젠테이션을 저장합니다.

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

다음 예제는 `update_chart_data`를 `False`로 설정하고 자리 표시자 URL을 할당합니다. 파이 차트의 기본 데이터를 유지하고, 사용할 수 없는 워크북을 로드하지 않은 채 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **차트의 외부 데이터 원본 워크북 경로 가져오기**

차트에 연결된 워크북을 식별하려면 차트가 외부 데이터 원본을 사용하는지 확인하고 워크북 경로를 가져옵니다.

이 예제는 외부 워크북이 연결된 프레젠테이션의 첫 번째 슬라이드 첫 번째 도형을 검사합니다. 차트가 외부 워크북에 연결된 경우 [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)을 콘솔에 출력하고 프레젠테이션 복사본을 저장합니다.

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

외부 워크북의 데이터를 내부 워크북과 동일한 방법으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없으면 예외가 발생합니다.

이 예제는 첫 번째 슬라이드 첫 번째 도형인 차트를 사용하며, 접근 가능한 외부 워크북에 연결됩니다. 첫 번째 시리즈의 첫 번째 데이터 포인트 값을 100으로 설정하고 업데이트된 프레젠테이션을 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트되므로 원본 워크북을 보존하려면 복사본을 사용하십시오.

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

차트가 누락되었거나 사용할 수 없는 외부 워크북을 사용하고 있는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)를 생성하고, 해당의 [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/)를 구성한 뒤, [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/)를 `True`로 설정하고 프레젠테이션을 엽니다.

다음 Python 예제는 첫 번째 슬라이드 첫 번째 도형인 차트에 대해 사용할 수 없는 외부 워크북을 참조하는 경우 워크북 데이터를 복구합니다. 복구된 데이터에 [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/)와 [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)를 사용합니다.

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

        # 복구된 워크북 데이터를 여기서 읽거나 수정합니다.
    else:
        print("The first shape is not a chart.")
```

외부 워크북이 사용할 수 없고 복구가 비활성화된 경우 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대체 방법일 때만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 임베드된 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)과 [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)이 있으며, 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되고 있는지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로를 지원하나요? 그리고 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 PPTX 파일에 절대 경로를 저장하므로 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 있는 워크북을 사용할 수 있나요?**

예, 이러한 워크북을 외부 데이터 원본으로 사용할 수 있습니다. 그러나 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX 파일을 덮어쓰나요?**

프레젠테이션은 [external file에 대한 링크](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본 파일을 변경하지 않아야 한다면 워크북 사본을 사용하십시오.

**외부 파일이 비밀번호로 보호되어 있으면 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 사전에 보호를 해제하거나, [Aspose.Cells](https://reference.aspose.com/cells/python-net/)와 같은 도구로 복호화된 사본을 만든 뒤 해당 사본에 연결하는 것입니다.

**여러 차트가 같은 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 동일한 파일을 가리키면 해당 파일을 업데이트했을 때 다음 데이터 로드 시 각 차트에 반영됩니다.