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
- 데이터 소스
- 외부 워크북
- 외부 데이터
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 발견하고, PowerPoint와 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화하세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 차트 데이터 소스로 외부 워크북을 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 시연합니다.

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides는 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터를 포함) 을 읽고 쓸 수 있는 메서드를 제공합니다. **Note:** 차트 데이터는 원본과 동일한 방식으로 구성되었거나 구조가 유사해야 합니다.

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

## **워크북 셀을 차트 데이터 레이블로 설정**

때때로 차트 레이블을 기본 데이터 워크북의 셀에서 직접 가져와야 할 경우가 있습니다. Aspose.Slides를 사용하면 특정 워크북 셀에 데이터 레이블을 바인딩하여 레이블 텍스트가 항상 셀 값과 일치하도록 할 수 있습니다. 아래 예제는 셀 기반 레이블을 활성화하고 선택된 레이블을 차트 워크북의 사용자 정의 셀에 지정하는 방법을 보여줍니다.

1. [Presentation](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 샘플 데이터가 포함된 버블 차트를 추가합니다.
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

다음 Python 코드는 `worksheets` 속성을 사용하여 워크시트 컬렉션에 접근하는 방법을 보여줍니다:

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

다음 Python 코드는 데이터 소스 유형을 지정하는 방법을 보여줍니다:

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

## **지원되지 않는 포함된 워크북 형식 감지**

Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 바이너리 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/) 의 `embedded_workbook_type` 속성과 [WorkbookType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/workbooktype/) 열거형을 함께 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다.

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
            # 포함된 워크북이 .xlsb 형식이며 지원되지 않습니다.
            continue

        # 여기서 차트 워크북 데이터를 읽거나 수정합니다.
```

## **외부 워크북**

Aspose.Slides는 차트의 데이터 소스로 외부 워크북을 사용하는 것을 지원합니다.

### **외부 워크북 설정**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 메서드를 사용하면 외부 워크북을 차트의 데이터 소스로 할당할 수 있습니다. 이 메서드는 워크북이 이동된 경우 외부 워크북 경로를 업데이트할 수도 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 편집할 수는 없지만, 해당 워크북을 외부 데이터 소스로 사용할 수는 있습니다. 외부 워크북에 대한 상대 경로를 제공하면 자동으로 전체 경로로 변환됩니다.

다음 Python 코드가 외부 워크북을 설정하는 방법을 보여줍니다:

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

- `update_chart_data`가 `False`로 설정되면 워크북 경로만 업데이트되고 차트 데이터는 로드되거나 대상 워크북에서 새로 고쳐지지 않습니다. 대상 워크북이 없거나 사용할 수 없는 경우에 이 설정을 사용합니다.
- `update_chart_data`가 `True`로 설정되면 차트 데이터가 로드되어 대상 워크북에서 업데이트됩니다.

### **외부 워크북 생성**

[read_workbook_stream](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) 및 [set_external_workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 메서드를 사용하면 새 외부 워크북을 처음부터 만들거나 내부 워크북을 외부 워크북으로 변환할 수 있습니다.

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

### **차트에 대한 외부 데이터 소스 워크북 경로 가져오기**

때때로 차트 데이터가 프레젠테이션에 포함된 데이터가 아닌 외부 Excel 워크북에 연결되어 있습니다. Aspose.Slides를 사용하면 차트의 데이터 소스를 검사하고, 외부 워크북인 경우 전체 워크북 경로를 읽을 수 있습니다.

1. [Presentation](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 차트 모양에 대한 참조를 가져옵니다.
1. 차트 데이터 소스를 나타내는 소스([ChartDataSourceType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatasourcetype/))를 얻습니다.
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

외부 워크북의 데이터를 내부 워크북을 편집하는 것과 동일한 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없는 경우 예외가 발생합니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지 또는 포함된 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [data source type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/data_source_type/)과 [path to an external workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/external_workbook_path/)이 있습니다. 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되고 있음을 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 이는 프로젝트 이동성을 높이는 데 편리하지만, 프레젠테이션이 PPTX 파일에 절대 경로를 저장한다는 점을 유의하세요.

**네트워크 리소스/공유에 위치한 워크북을 사용할 수 있나요?**

예, 이러한 워크북은 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 데이터 소스로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX 파일을 덮어쓰나요?**

아니요. 프레젠테이션은 [external file에 대한 링크](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdata/external_workbook_path/)를 저장하고 데이터를 읽을 때 해당 링크를 사용합니다. 프레젠테이션 저장 시 외부 파일 자체는 수정되지 않습니다.

**외부 파일에 비밀번호가 설정되어 있으면 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 미리 보호를 해제하거나 (예: [Aspose.Cells](/cells/python-net/)를 사용하여) 복호화된 사본을 만든 뒤 해당 사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모든 차트가 동일한 파일을 가리키면 해당 파일을 업데이트했을 때 다음에 데이터를 로드할 때 각 차트에 반영됩니다.