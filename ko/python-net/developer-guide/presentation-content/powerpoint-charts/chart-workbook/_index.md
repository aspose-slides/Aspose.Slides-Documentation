---
title: Python을 사용한 프레젠테이션에서 차트 워크북 관리
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
description: "Aspose.Slides for Python via .NET을 발견하세요: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 액세스하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성 및 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 보여줍니다.

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides는 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터를 포함) 을 읽고 쓸 수 있는 메서드를 제공합니다. **Note:** 차트 데이터는 동일한 방식으로 정리되어 있거나 원본과 유사한 구조여야 합니다.

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

## **워크북 셀을 차트 데이터 레이블로 설정**

때때로 기본 데이터 워크북의 셀에서 직접 가져온 차트 레이블이 필요합니다. Aspose.Slides를 사용하면 데이터 레이블을 특정 워크북 셀에 바인딩하여 레이블 텍스트가 항상 셀의 값을 반영하도록 할 수 있습니다. 아래 예제는 셀값 기반 레이블을 활성화하고 선택된 레이블을 차트 워크북의 사용자 지정 셀에 연결하는 방법을 보여줍니다.

1. [Presentation](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 샘플 데이터를 사용하여 버블 차트를 추가합니다.
4. 차트 시리즈에 액세스합니다.
5. 워크북 셀을 데이터 레이블로 사용합니다.
6. 프레젠테이션을 저장합니다.

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

다음 Python 코드에서는 `worksheets` 속성을 사용하여 워크시트 컬렉션에 접근하는 방법을 보여줍니다.

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

다음 Python 코드는 데이터 소스 유형을 지정하는 방법을 보여줍니다.

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

Aspose.Slides는 일부 차트에 임베드될 수 있는 Excel 바이너리 워크북(.xlsb) 형식을 지원하지 않습니다. 지원되지 않는 형식을 감지하고 해당 차트를 건너뛰려면 [ChartData](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/) 의 `embedded_workbook_type` 속성을 [WorkbookType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/workbooktype/) 열거형과 함께 사용할 수 있습니다.

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

        # 여기서 차트 워크북 데이터를 읽거나 수정합니다.
```

## **외부 워크북**

Aspose.Slides는 차트의 데이터 소스로 외부 워크북을 사용하는 것을 지원합니다.

### **외부 워크북 설정**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 메서드를 사용하면 외부 워크북을 차트의 데이터 소스로 할당할 수 있습니다. 이 메서드는 워크북이 이동된 경우 외부 워크북의 경로를 업데이트할 수도 있습니다.

원격 위치 또는 리소스에 저장된 워크북의 데이터를 편집할 수는 없지만, 여전히 해당 워크북을 외부 데이터 소스로 사용할 수 있습니다. 외부 워크북에 대한 상대 경로를 제공하면 자동으로 전체 경로로 변환됩니다.

다음 Python 코드는 외부 워크북을 설정하는 방법을 보여줍니다:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`update_chart_data` 매개변수는 [set_external_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 메서드에서 Excel 워크북을 로드할지 여부를 지정합니다.

- `update_chart_data` 가 `False` 로 설정되면 워크북 경로만 업데이트되고 차트 데이터는 대상 워크북에서 로드되거나 새로 고쳐지지 않습니다. 대상 워크북이 존재하지 않거나 사용할 수 없을 때 이 설정을 사용합니다.
- `update_chart_data` 가 `True` 로 설정되면 차트 데이터가 로드되고 대상 워크북에서 업데이트됩니다.

### **외부 워크북 만들기**

[read_workbook_stream](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) 및 [set_external_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 메서드를 사용하면 외부 워크북을 처음부터 만들거나 내부 워크북을 외부 워크북으로 변환할 수 있습니다.

다음 Python 코드는 외부 워크북 생성 프로세스를 보여줍니다:

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

때때로 차트 데이터가 프레젠테이션에 내장된 데이터가 아니라 외부 Excel 워크북에 연결되어 있습니다. Aspose.Slides를 사용하면 차트의 데이터 소스를 검사하고, 외부 워크북인 경우 전체 워크북 경로를 읽을 수 있습니다.

1. [Presentation](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 차트 도형에 대한 참조를 가져옵니다.
4. 차트 데이터 소스를 나타내는 소스([ChartDataSourceType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatasourcetype/))를 가져옵니다.
5. 소스 유형이 외부 워크북 데이터 소스 유형과 일치하는지 확인합니다.

다음 Python 코드는 해당 작업을 보여줍니다:

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

외부 워크북의 데이터를 내부 워크북을 편집하듯이 편집할 수 있습니다. 외부 워크북을 로드할 수 없으면 예외가 발생합니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **차트 캐시에서 워크북 복구**

차트가 누락되었거나 사용할 수 없는 외부 워크북을 사용하는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 사용하여 차트 워크북을 재구성할 수 있습니다. 프레젠테이션을 열기 전에 [LoadOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/)을 생성하고, [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/spreadsheet_options/)를 통해 [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ko/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/)를 활성화합니다.

다음 Python 예제는 차트가 사용할 수 없는 외부 워크북을 참조하는 프레젠테이션을 열고, [Chart.chart_data](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/chart_data/) 및 [ChartData.chart_data_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)을 통해 복구된 데이터에 접근합니다:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # 여기서 복구된 워크북 데이터를 읽거나 수정합니다.
```

외부 워크북을 사용할 수 없고 복구가 비활성화된 경우, Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용해도 괜찮은 경우에만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있기 때문입니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 내장 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [data source type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/data_source_type/) 및 [external workbook path](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/external_workbook_path/)가 있습니다. 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되고 있는지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 이는 프로젝트 이동성을 위해 편리하지만, 프레젠테이션이 PPTX 파일에 절대 경로를 저장한다는 점을 유의하십시오.

**네트워크 리소스/공유에 위치한 워크북을 사용할 수 있나요?**

예, 해당 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**Aspose.Slides가 프레젠테이션을 저장할 때 외부 XLSX를 덮어쓰나요?**

아니오. 프레젠테이션은 [link to the external file](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/external_workbook_path/)을 저장하고 데이터를 읽는 데 사용합니다. 프레젠테이션을 저장할 때 외부 파일 자체는 수정되지 않습니다.

**외부 파일에 비밀번호가 걸려 있는 경우 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 미리 보호를 해제하거나 복호화된 복사본(예: [Aspose.Cells](/cells/python-net/) 사용)을 준비한 뒤 해당 복사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 같은 파일을 가리키는 경우, 해당 파일을 업데이트하면 다음에 데이터를 로드할 때 각 차트에 반영됩니다.