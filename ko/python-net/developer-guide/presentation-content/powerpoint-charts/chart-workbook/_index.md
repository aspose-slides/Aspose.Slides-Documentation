---
title: Python을 사용하여 프레젠테이션에서 차트 워크북 관리
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
description: "Aspose.Slides for Python via .NET를 발견하고, PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화하십시오."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 시연합니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 빈 셀과 0의 차이 및 사용 가능한 표시 모드의 선형 차트 비교를 보려면 [Control the Display of Empty Cells](/slides/ko/python-net/chart-series/)를 참조하십시오.

## **숨겨진 행 및 열의 데이터 포함**

[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/plot_visible_cells_only/)를 사용하여 차트가 숨겨진 워크시트 행 및 열의 데이터를 플롯할지 여부를 제어합니다. `True`로 설정하면 보이는 셀만 플롯하고, `False`로 설정하면 보이는 셀과 숨겨진 셀 모두를 포함합니다. 이 설정은 차트 플롯팅에만 영향을 미치며, 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[hidden-source-data.pptx](hidden-source-data.pptx)를 다운로드하여 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드에는 첫 번째 도형으로 열 차트가 포함되어 있습니다. 포함된 워크시트 `Sheet1`에는 `A1:C4` 범위가 있습니다. 행 3과 열 C는 숨겨져 있지만 셀 값은 그대로 존재합니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매(숨겨진 열) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (숨겨진 행) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[ChartData.chart_data_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)을 통해 소스 셀에 접근하고, [ChartDataCell.is_hidden](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatacell/is_hidden/)을 읽어 숨김 상태를 확인합니다. 이 속성은 읽기 전용입니다. 이 파일에서 B2는 보이며, B3은 숨겨진 행에 속하고, C2는 숨겨진 열에 속합니다; 예제는 각각 `False`, `True`, `True`를 출력합니다.

이 예제에서는 플롯 설정을 변경한 후 차트 데이터를 새로 고칩니다: [read_workbook_stream](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)으로 포함된 워크북을 유지하고, [write_workbook_stream](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)으로 다시 로드합니다. 모든 셀을 포함할 때는 [set_range](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_range/)를 사용하여 숨겨진 February 범주를 포함한 전체 범위를 복원해야 합니다. 플래그만 변경하는 것으로는 이 샘플의 캐시된 차트 데이터와 카테고리 레이블을 새로 고치기에 충분하지 않습니다.

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

            # 임베디드 워크북에서 차트 데이터를 새로 고칩니다.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # 숨겨진 카테고리를 포함한 전체 소스 범위를 복원합니다.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

예제는 보이는 소매 값(10 및 20)만 포함한 `hidden_cells_True.pptx`와 전체 6값을 포함한 `hidden_cells_False.pptx`를 저장합니다. 아래 이미지들은 저장된 프레젠테이션을 다시 열어 렌더링한 결과이며, 두 파일 모두 지정된 플롯 설정을 유지합니다. 행 3과 열 C는 두 포함된 워크북 모두에서 숨겨진 상태로 남아 있습니다.

| 보이는 셀만 (`True`) | 모든 셀 (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

값이 있는 숨겨진 셀은 빈 셀과 다릅니다. [Chart.display_blanks_as](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/display_blanks_as/)는 누락된 값이 표시되는 방식을 제어하지만, 숨겨진 소스 데이터를 포함하거나 제외하지는 않습니다. 예시는 [Control the Display of Empty Cells](/slides/ko/python-net/chart-series/#control-the-display-of-empty-cells)에서 확인하십시오.

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides for Python via .NET은 [read_workbook_stream](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)와 [write_workbook_stream](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells 로 편집된 차트 데이터 포함)을 읽고 쓸 수 있게 합니다. **Note** 차트 데이터는 동일한 방식으로 구성되어 있거나 소스와 유사한 구조여야 합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `chart.pptx`를 엽니다. 포함된 워크북을 스트림으로 읽고, 기존 시리즈와 카테고리를 모두 지운 뒤 동일한 워크북을 다시 씁니다. 변경 사항은 메모리에 남으며, 예제는 프레젠테이션을 저장하지 않습니다.

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

수정된 워크북으로 포함된 워크북을 교체하면 차트는 원래의 시리즈와 카테고리 컬렉션을 유지합니다. 이 불일치로 인해 [Chart.validate_chart_layout](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/validate_chart_layout/)이 인덱스 범위 오류로 실패할 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 카테고리를 지우십시오. 이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `chart.pptx`가 필요합니다. 주석은 워크북 편집이 발생할 위치를 표시합니다; 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리에서 레이아웃을 검증합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # 여기에서 워크북 스트림을 수정합니다. 예를 들어 Aspose.Cells를 사용할 수 있습니다.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

컬렉션을 지우면 워크북을 다시 쓰기 전에 오래된 데이터 참조가 제거됩니다. 업데이트된 워크북에 필요한 시리즈와 카테고리 매핑을 다시 구축한 뒤 차트를 사용하십시오.

## **워크북 셀을 차트 데이터 레이블로 설정**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다. 아래 단계는 버블 차트의 레이블을 데이터 워크북 셀에 연결하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 제로 기반 인덱스로 첫 번째 슬라이드에 접근합니다.  
3. 기본 데이터가 포함된 버블 차트를 추가합니다.  
4. 차트 시리즈에 접근합니다.  
5. 워크북 셀을 데이터 레이블로 설정합니다.  
6. 프레젠테이션을 저장합니다.

이 예제는 최소 하나의 슬라이드가 포함된 `chart2.pptx`를 열고, 기본 데이터가 포함된 버블 차트를 추가합니다. 워크시트 0의 셀 A10:A12를 첫 번째 시리즈의 처음 세 레이블로 사용하고, 셀 기반 레이블을 활성화한 뒤 결과를 `resultchart.pptx`에 저장합니다.

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

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) 속성은 차트 워크북의 워크시트에 대한 접근을 제공합니다. 이 예제는 기본 데이터가 포함된 파이 차트를 생성하고 각 워크시트 이름을 콘솔에 출력합니다.

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

이 예제는 기본 데이터가 포함된 3D 컬럼 차트를 생성하고 두 개의 시리즈 이름을 서로 다른 데이터 소스로 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째 이름은 워크시트 0의 셀 C1을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/datasourcetype/) 열거형은 각 이름에 대한 소스를 선택합니다. 결과는 `pres.pptx`에 저장됩니다.

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

## **지원되지 않는 포함 워크북 형식 감지**

Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/)의 [embedded_workbook_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) 속성과 [WorkbookType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/workbooktype/) 열거형을 함께 사용하면 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 `sample.pptx`의 첫 번째 슬라이드에 있는 도형을 검사하고, 차트가 아닌 도형은 건너뛰며, 포함된 .xlsb 워크북을 가진 각 차트에 대해 진단 메시지를 출력합니다.

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

Aspose.Slides는 외부 워크북을 차트 데이터 소스로 사용하는 것을 지원합니다.

### **외부 워크북 생성**

[read_workbook_stream](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)와 [set_external_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/)을 사용하여 포함된 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

이 예제는 기본 데이터가 포함된 파이 차트를 생성하고, 워크북을 `externalWorkbook1.xlsx`에 기록한 뒤 출력 스트림을 닫고 파일을 차트 데이터 소스로 지정합니다. 연결된 프레젠테이션은 `externalWorkbook.pptx`로 저장됩니다.

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

[set_external_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 메서드를 사용하면 차트에 외부 워크북을 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북이 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 직접 편집할 수는 없지만, 외부 데이터 소스로는 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

이 예제는 작업 디렉터리에 `externalWorkbook.xlsx`가 있어야 합니다. 워크시트 `Sheet1`에는 B1에 시리즈 이름, A2:A4에 카테고리 이름, B2:B4에 숫자 값이 들어 있어야 합니다. 예제는 파이 차트를 만들고 워크북을 연결한 뒤, [set_range](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_range/)을 사용해 A1:B4 범위를 하나의 시리즈와 세 개의 카테고리로 매핑합니다. 결과는 `Presentation_with_externalWorkbook.pptx`에 저장됩니다.

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

[set_external_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/)의 `update_chart_data` 매개변수는 워크북을 로드할지 여부를 제어합니다.

* `update_chart_data`가 `False`이면 워크북 경로만 업데이트되고 차트 데이터는 로드되거나 업데이트되지 않습니다. 따라서 워크북이 없어도 작동합니다.  
* `update_chart_data`가 `True`이면 대상 워크북에서 차트 데이터가 업데이트됩니다.

다음 예제는 `update_chart_data`를 `False`로 설정하여 자리표시자 URL을 할당합니다. 파이 차트의 기본 데이터를 유지하고, 사용 불가능한 워크북을 로드하지 않은 채 프레젠테이션을 저장합니다.

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

차트에 연결된 워크북을 식별하려면 먼저 차트가 외부 데이터 소스를 사용하고 있는지 확인합니다. 사용하고 있다면 다음 단계에 따라 워크북 경로를 가져올 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.  
2. 제로 기반 인덱스로 첫 번째 슬라이드에 접근합니다.  
3. 첫 번째 도형이 차트인지 확인합니다.  
4. 차트 데이터 소스 유형을 읽습니다.  
5. 소스가 외부 워크북인 경우 경로를 읽습니다.

이 예제는 앞서 만든 `externalWorkbook.pptx`를 열고 첫 번째 슬라이드의 첫 번째 도형을 검사합니다. 차트가 외부 워크북에 연결돼 있으면 [external_workbook_path](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/external_workbook_path/)를 콘솔에 출력하고, 프레젠테이션 복사본을 `Result.pptx`로 저장합니다.

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

외부 워크북의 데이터를 내부 워크북과 동일한 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없으면 예외가 발생합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `presentation.pptx`와 접근 가능한 외부 워크북이 필요합니다. 첫 번째 시리즈의 첫 번째 데이터 포인트 값을 100으로 설정하고 `presentation_out.pptx`에 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트되므로 원본 워크북을 보존하려면 사본을 사용하십시오.

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

차트가 누락되었거나 사용할 수 없는 외부 워크북을 사용하고 있는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/)를 생성하고, 그 [spreadsheet_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/spreadsheet_options/)를 구성한 뒤, [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ko/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/)를 `True`로 설정하고 프레젠테이션을 엽니다.

다음 Python 예제는 첫 번째 슬라이드의 첫 번째 도형이 사용 불가능한 외부 워크북을 참조하는 차트인 `presentation.pptx`를 열고, [Chart.chart_data](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/chart_data/)와 [ChartData.chart_data_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)를 통해 복구된 데이터를 접근합니다:

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

외부 워크북이 없고 복구가 비활성화된 경우 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대체 방법일 때만 복구를 활성화하십시오. 캐시에는 외부 워크북이 마지막으로 프레젠테이션이 업데이트된 이후에 변경된 내용이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 포함 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [data source type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/data_source_type/)과 [external workbook path](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/external_workbook_path/)가 있으며, 소스가 외부 워크북이면 전체 경로를 읽어 외부 파일이 사용 중인지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되나요? 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 절대 경로를 PPTX 파일에 저장하므로, 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 있는 워크북을 사용할 수 있나요?**

예, 이러한 워크북은 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX 파일을 덮어쓰나요?**

프레젠테이션은 [external file link](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/external_workbook_path/)를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본 파일을 변경하지 않아야 하면 워크북 사본을 사용하십시오.

**외부 파일이 비밀번호로 보호되어 있으면 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 접근 방식은 미리 보호를 해제하거나 [Aspose.Cells](https://reference.aspose.com/cells/python-net/)를 사용해 복호화된 사본을 만든 뒤 해당 사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 같은 파일을 가리키면 해당 파일을 업데이트할 때마다 다음 데이터 로드 시 모든 차트에 반영됩니다.