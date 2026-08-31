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
- 파워포인트
- 프레젠테이션
- 파이썬
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 발견하고: 파워포인트 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화하세요."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성·할당하고, 차트에 연결된 외부 워크북의 경로를 가져오며, 워크북을 사용할 수 있을 때 차트 데이터를 편집하는 방법을 시연합니다.

## **워크북에서 차트 데이터 읽고 쓰기**

Aspose.Slides는 워크북( Aspose.Cells 로 편집된 차트 데이터를 포함)에서 차트 데이터를 읽고 쓸 수 있는 메서드를 제공합니다. **참고:** 차트 데이터는 원본과 동일한 방식으로 구성되거나 유사한 구조를 가져야 합니다.

다음 Python 코드가 샘플 작업을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **워크북 수정 후 차트 레이아웃 검증**

임베디드 워크북을 수정된 워크북으로 교체하면 차트는 기존 시리즈와 카테고리 컬렉션을 그대로 유지합니다. 이 불일치로 인해 [IChart.validate_chart_layout](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichart/validate_chart_layout/)이 인덱스 범위 초과 오류로 실패할 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 카테고리를 모두 지우세요.

```python
# 워크북 스트림을 수정한 후 (예: Aspose.Cells 사용)
updated_workbook = chart_data.read_workbook_stream()

# 기존 데이터 참조를 삭제합니다.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

컬렉션을 정리하면 차트 데이터 구조가 새 워크북과 일치하게 되어 `validate_chart_layout`이 오류 없이 완료됩니다.

## **워크북 셀을 차트 데이터 레이블로 지정**

때때로 차트 레이블을 기본 데이터 워크북의 셀에서 직접 가져와야 할 때가 있습니다. Aspose.Slides는 특정 워크북 셀에 데이터 레이블을 바인딩하여 레이블 텍스트가 항상 셀 값과 동기화되도록 지원합니다. 아래 예제는 셀‑기반 레이블을 활성화하고 선택된 레이블을 차트 워크북의 사용자 정의 셀에 연결하는 방법을 보여줍니다.

1. [Presentation](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 샘플 데이터를 사용해 버블 차트를 추가합니다.
1. 차트 시리즈에 접근합니다.
1. 워크북 셀을 데이터 레이블로 사용합니다.
1. 프레젠테이션을 저장합니다.

다음 Python 코드가 워크북 셀을 차트 데이터 레이블로 설정하는 방법을 보여줍니다:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **워크시트 관리**

다음 Python 코드가 `worksheets` 속성을 사용해 워크시트 컬렉션에 접근하는 방법을 시연합니다:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **데이터 소스 유형 지정**

다음 Python 코드가 데이터 소스 유형을 지정하는 방법을 보여줍니다:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **지원되지 않는 임베디드 워크북 형식 감지**

Aspose.Slides는 차트에 임베디드될 수 있는 Excel 바이너리 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/)의 `embedded_workbook_type` 속성을 [WorkbookType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/workbooktype/) 열거형과 함께 사용하면 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # 임베디드 워크북이 .xlsb 형식이며, 지원되지 않습니다.
            continue

        # 여기에서 차트 워크북 데이터를 읽거나 수정합니다.
```

## **외부 워크북**

Aspose.Slides는 외부 워크북을 차트의 데이터 소스로 사용하는 것을 지원합니다.

### **외부 워크북 설정**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 메서드를 사용하면 외부 워크북을 차트의 데이터 소스로 지정할 수 있습니다. 이 메서드는 워크북이 이동된 경우 경로도 업데이트합니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 직접 편집할 수는 없지만, 외부 데이터 소스로는 사용할 수 있습니다. 외부 워크북에 대한 상대 경로를 제공하면 자동으로 전체 경로로 변환됩니다.

다음 Python 코드가 외부 워크북을 설정하는 방법을 보여줍니다:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # False를 전달하면 경로만 저장됩니다: 대상 워크북이 아직 존재할 필요가 없습니다.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` 메서드의 `update_chart_data` 매개변수는 Excel 워크북을 로드할지 여부를 지정합니다.

- `update_chart_data`가 `False`이면 워크북 경로만 업데이트되고 차트 데이터는 로드·갱신되지 않습니다. 대상 워크북이 없거나 사용할 수 없을 때 이 설정을 사용하세요.
- `update_chart_data`가 `True`(기본값)이면 차트 데이터가 대상 워크북에서 로드·갱신됩니다. 해당 워크북을 열 수 없으면 "External workbook is not available" 메시지와 함께 예외가 발생합니다.

### **외부 워크북 만들기**

[read_workbook_stream](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)와 [set_external_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 메서드를 사용하면 새 외부 워크북을 처음부터 만들거나 내부 워크북을 외부 워크북으로 변환할 수 있습니다.

다음 Python 코드가 외부 워크북 생성 과정을 보여줍니다:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **차트의 외부 데이터 소스 워크북 경로 가져오기**

때때로 차트 데이터가 프레젠테이션에 임베디드된 데이터가 아니라 외부 Excel 워크북에 연결되어 있습니다. Aspose.Slides를 사용하면 차트의 데이터 소스를 검사하고, 외부 워크북인 경우 전체 워크북 경로를 읽어올 수 있습니다.

1. [Presentation](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 차트 셰이프에 대한 참조를 가져옵니다.
1. 차트 데이터 소스를 나타내는 [ChartDataSourceType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatasourcetype/)를 획득합니다.
1. 소스 유형이 외부 워크북 데이터 소스 유형과 일치하는지 확인합니다.

다음 Python 코드가 해당 작업을 시연합니다:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **차트 데이터 편집**

외부 워크북의 데이터를 내부 워크북과 같은 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없으면 예외가 발생합니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **차트 캐시에서 워크북 복구**

외부 워크북이 없거나 사용할 수 없는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/)을 만든 뒤, 프레젠테이션을 열기 전에 [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/spreadsheet_options/)를 통해 [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ko/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/)를 활성화합니다.

다음 Python 예제가 외부 워크북이 없을 때 차트가 참조하는 데이터를 복구하고, 복구된 데이터를 [Chart.chart_data](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/chart_data/)와 [ChartData.chart_data_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)를 통해 접근하는 과정을 보여줍니다:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # 복구된 워크북 데이터를 여기서 읽거나 수정합니다.
```

외부 워크북이 없고 복구가 비활성화된 경우 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대체 방안일 때만 복구를 활성화하십시오. 캐시에는 외부 워크북이 프레젠테이션에 마지막으로 저장된 이후에 변경된 내용이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 임베디드 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [data source type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/data_source_type/)과 [external workbook path](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/external_workbook_path/)가 있습니다. 소스가 외부 워크북이면 전체 경로를 읽어 외부 파일이 사용되고 있음을 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 이는 프로젝트 이동성을 높여 주지만, 프레젠테이션 파일(PPTX)에는 절대 경로가 저장된다는 점을 유의하세요.

**네트워크 공유/리소스에 있는 워크북을 사용할 수 있나요?**

예. 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 다만 Aspose.Slides에서는 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**프레젠테이션 저장 시 외부 XLSX 파일이 덮어쓰기 되나요?**

차트 데이터를 편집한 경우에만 그렇습니다. 프레젠테이션은 [external file link](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/external_workbook_path/)를 저장하고 읽을 때만 사용하므로 열고 저장하는 과정에서 워크북 자체는 변경되지 않습니다. 그러나 차트 데이터를 통해 변경한 값은 프레젠테이션 저장 시 외부 워크북에 다시 기록됩니다. 원본 파일을 그대로 두어야 하면 복사본을 사용하세요.

**외부 파일이 암호로 보호되어 있으면 어떻게 해야 하나요?**

Aspose.Slides는 링크 시 비밀번호 입력을 받지 않습니다. 일반적인 해결책은 미리 보호를 해제하거나, 예를 들어 [Aspose.Cells](/cells/python-net/) 등을 사용해 복호화된 사본을 만든 뒤 해당 사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 같은 파일을 가리키면 파일이 업데이트될 때마다 다음 데이터 로드 시 각 차트에 반영됩니다.