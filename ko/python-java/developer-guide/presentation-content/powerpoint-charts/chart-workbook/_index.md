---
title: Python via Java를 사용한 프레젠테이션 차트 워크북 관리
linktitle: 차트 워크북
type: docs
weight: 70
url: /ko/python-java/chart-workbook/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 발견하고, PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 간소화하세요."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법 및 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 시연합니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 [빈 셀 표시 제어](/slides/ko/python-java/chart-series/)에서 빈 셀과 0의 차이점 및 사용 가능한 표시 모드의 라인 차트 비교를 확인하십시오.

## **숨김 행 및 열의 데이터 포함**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) 를 사용하여 차트가 숨겨진 워크시트 행 및 열의 데이터를 플롯할지 여부를 제어합니다. `True` 로 설정하면 보이는 셀만 플롯하고, `False` 로 설정하면 보이는 셀과 숨김 셀을 모두 포함합니다. 이 설정은 차트 플롯에만 영향을 주며 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[hidden-source-data.pptx](hidden-source-data.pptx)를 다운로드하여 작업 디렉터리에 두십시오. 첫 번째 슬라이드에는 첫 번째 도형으로 열 차트가 포함되어 있습니다. 포함된 워크시트 `Sheet1`에는 다음 소스 범위 `A1:C4`가 있습니다. 3행과 C열은 숨겨져 있지만 해당 셀에는 여전히 값이 들어 있습니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매(숨김 열) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (숨김 행) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 를 통해 소스 셀에 접근하고 [ChartDataCell.isHidden](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatacell/#isHidden) 을 읽어 숨김 상태를 확인하십시오. 이 메서드는 상태를 변경하지 않고 숨김 상태만 반환합니다. 이 파일에서 B2는 보이며, B3은 숨김 행에 속하고, C2는 숨김 열에 속하므로 예제는 각각 `False`, `True`, `True` 를 출력합니다.

이 예제에서는 플롯 설정을 변경한 후 차트 데이터를 새로 고칩니다: [readWorkbookStream](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#readWorkbookStream) 으로 포함된 워크북을 유지하고, [writeWorkbookStream](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#writeWorkbookStream) 으로 다시 로드합니다. 모든 셀을 포함할 때는 [setRange](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#setRange) 도 사용하여 숨겨진 February 카테고리를 포함한 전체 범위를 복원합니다. 플래그만 변경하는 것으로는 이 샘플의 캐시된 차트 데이터와 카테고리 레이블이 새로 고쳐지지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # 포함된 워크북에서 차트 데이터를 새로 고칩니다.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # 숨김 카테고리를 포함한 전체 소스 범위를 복원합니다.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

예제는 보이는 소매 값(10 및 20)만 포함한 `hidden_cells_True.pptx`와 모든 여섯 값을 포함한 `hidden_cells_False.pptx`를 저장합니다. 아래 이미지가 두 플롯 모드를 보여줍니다. 행 3과 열 C는 두 포함 워크북 모두에서 숨김 상태로 유지됩니다.

| 보이는 셀만 (`True`) | 모든 셀 (`False`) |
| --- | --- |
| ![보이는 셀만: 1월과 3월의 소매 값 10 및 20.](hidden_cells_True.png) | ![모든 셀: 1월, 2월, 3월의 소매 및 도매 값.](hidden_cells_False.png) |

값을 포함한 숨김 셀은 빈 셀과 다릅니다. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setDisplayBlanksAs) 은 누락된 값이 표시되는 방식을 제어하지만 숨김 소스 데이터를 포함하거나 제외하지는 않습니다. 예제는 [빈 셀 표시 제어](/slides/ko/python-java/chart-series/#control-the-display-of-empty-cells)를 참조하십시오.

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides for Python via Java는 [readWorkbookStream](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#readWorkbookStream) 및 [writeWorkbookStream](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#writeWorkbookStream) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells 로 편집된 차트 데이터 포함 )을 읽고 쓸 수 있습니다. **참고** 차트 데이터는 동일한 방식으로 구성되어 있거나 소스와 유사한 구조여야 합니다.

이 예제는 첫 번째 슬라이드 첫 번째 도형으로 차트가 포함된 `chart.pptx`를 엽니다. 포함된 워크북을 바이트 배열로 읽고, 기존 시리즈와 카테고리를 지운 뒤 동일한 워크북을 다시 씁니다. 변경 내용은 메모리에 남으며, 예제는 프레젠테이션을 저장하지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **워크북 수정 후 차트 레이아웃 확인**

포함된 워크북을 수정된 워크북으로 교체하면 차트는 원래의 시리즈와 카테고리 컬렉션을 유지합니다. 이 불일치 때문에 [Chart.validateChartLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#validateChartLayout) 가 인덱스 범위 초과 오류로 실패할 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 카테고리를 지우십시오. 이 예제는 첫 번째 슬라이드 첫 번째 도형으로 차트가 있는 `chart.pptx`가 필요합니다. 주석은 워크북 편집이 이뤄질 위치를 표시하며, 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리 내에서 레이아웃을 검증합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # 여기서 워크북 바이트를 수정하세요, 예를 들어 Aspose.Cells를 사용하여.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

컬렉션을 비우면 워크북이 다시 쓰이기 전에 오래된 데이터 참조가 제거됩니다. 업데이트된 워크북에 필요한 시리즈와 카테고리 매핑을 재구성한 뒤 차트를 사용하십시오.

## **워크북 셀을 차트 데이터 레이블로 설정**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다. 다음 단계는 버블 차트의 레이블을 데이터 워크북의 셀에 연결하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 제로 기반 인덱스로 첫 번째 슬라이드에 접근합니다.
1. 기본 데이터가 있는 버블 차트를 추가합니다.
1. 차트 시리즈에 접근합니다.
1. 워크북 셀을 데이터 레이블로 설정합니다.
1. 프레젠테이션을 저장합니다.

이 예제는 차트가 포함된 최소 하나의 슬라이드가 있는 `chart2.pptx`를 열고 기본 데이터가 있는 버블 차트를 추가합니다. 워크시트 0의 셀 A10:A12를 첫 번째 시리즈의 처음 세 레이블에 사용하고, 셀 기반 레이블을 활성화한 뒤 결과를 `resultchart.pptx`에 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **워크시트 관리**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdataworkbook/#getWorksheets) 메서드는 차트 워크북의 워크시트에 접근할 수 있게 해줍니다. 이 예제는 기본 데이터가 있는 파이 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **데이터 소스 유형 지정**

이 예제는 기본 데이터가 있는 3D 컬럼 차트를 만들고 두 시리즈 이름을 서로 다른 데이터 소스로 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째 이름은 워크시트 0의 셀 C1을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datasourcetype/) 열거형은 각 이름의 소스를 선택합니다. 결과는 `pres.pptx`에 저장됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **지원되지 않는 포함 워크북 형식 감지**

Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 바이너리 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/) 에서 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) 메서드와 [WorkbookType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/workbooktype/) 열거형을 함께 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 `sample.pptx`의 첫 번째 슬라이드에 있는 도형을 검사하고, 차트가 아닌 도형은 건너뛰며, 포함된 .xlsb 워크북이 있는 차트마다 진단 메시지를 출력합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # 지원되는 차트 워크북 데이터를 여기서 읽거나 수정하세요.
finally:
    presentation.dispose()
```

## **외부 워크북**

Aspose.Slides는 외부 워크북을 차트의 데이터 소스로 사용하는 것을 지원합니다.

### **외부 워크북 생성**

[readWorkbookStream](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#readWorkbookStream) 과 [setExternalWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#setExternalWorkbook) 을 사용하여 포함된 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

이 예제는 기본 데이터가 있는 파이 차트를 만들고 워크북을 `externalWorkbook1.xlsx`에 기록한 뒤 파일 쓰기를 완료하고 해당 파일을 차트 데이터 소스로 할당합니다. 연결된 프레젠테이션을 `externalWorkbook.pptx`에 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **외부 워크북 설정**

[setExternalWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#setExternalWorkbook) 메서드를 사용하면 외부 워크북을 차트의 데이터 소스로 지정할 수 있습니다. 이 메서드는 외부 워크북의 경로가 이동된 경우 경로를 업데이트하는 용도로도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 직접 편집할 수는 없지만, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 절대 경로로 변환됩니다.

이 예제는 작업 디렉터리에 `externalWorkbook.xlsx`가 있어야 합니다. 워크시트 `Sheet1`에는 B1에 시리즈 이름, A2:A4에 카테고리 이름, B2:B4에 숫자 값이 들어 있어야 합니다. 예제는 파이 차트를 만들고 워크북을 연결한 뒤 [setRange](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#setRange) 를 사용해 A1:B4 범위를 하나의 시리즈와 세 개의 카테고리로 매핑합니다. 결과는 `Presentation_with_externalWorkbook.pptx`에 저장됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#setExternalWorkbook) 의 `updateChartData` 매개변수는 워크북을 로드할지 여부를 제어합니다.

* `updateChartData` 가 `False`이면 워크북 경로만 업데이트됩니다. 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않으므로 워크북이 없어도 됩니다.
* `updateChartData` 가 `True`이면 차트 데이터가 대상 워크북에서 업데이트됩니다.

다음 예제는 `updateChartData` 를 `False` 로 설정하고 자리표시자 URL을 할당합니다. 파이 차트의 기본 데이터를 유지하고 워크북을 로드하지 않은 채 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **차트의 외부 데이터 소스 워크북 경로 가져오기**

차트에 연결된 워크북을 식별하려면 먼저 차트가 외부 데이터 소스를 사용하는지 확인합니다. 사용 중이라면 다음 단계에 따라 워크북 경로를 가져올 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 제로 기반 인덱스로 첫 번째 슬라이드에 접근합니다.
1. 첫 번째 도형이 차트인지 확인합니다.
1. 차트 데이터 소스 유형을 읽습니다.
1. 소스가 외부 워크북이면 경로를 읽습니다.

이 예제는 앞의 예제에서 만든 `externalWorkbook.pptx` 를 열고 첫 번째 슬라이드의 첫 번째 도형을 검사합니다. 차트가 외부 워크북에 연결된 경우 콘솔에 [getExternalWorkbookPath](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) 을 출력합니다. 그런 다음 프레젠테이션 복사본을 `Result.pptx` 로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **차트 데이터 편집**

외부 워크북의 데이터를 내부 워크북과 동일한 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없으면 예외가 발생합니다.

이 예제는 첫 번째 슬라이드 첫 번째 도형에 차트가 포함된 `presentation.pptx` 와 접근 가능한 외부 워크북이 필요합니다. 첫 번째 시리즈의 첫 번째 데이터 포인트 셀 기반 값을 100으로 설정하고 프레젠테이션을 `presentation_out.pptx` 로 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트되므로 원본 워크북을 보존하려면 복사본을 사용하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **차트 캐시에서 워크북 복구**

차트가 누락되었거나 사용할 수 없는 외부 워크북을 사용하고 있는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터에서 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/) 를 생성하고, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) 를 호출한 뒤, [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ko/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) 를 `True` 로 설정하고 프레젠테이션을 엽니다.

다음 Python 예제는 첫 번째 슬라이드 첫 번째 도형이 사용할 수 없는 외부 워크북을 참조하는 차트인 `presentation.pptx` 를 열고, [Chart.getChartData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#getChartData) 와 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 를 통해 복구된 데이터를 접근합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # 여기서 복구된 워크북 데이터를 읽거나 수정하세요.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

외부 워크북을 사용할 수 없고 복구가 비활성화된 경우 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대체 방안일 때만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 포함된 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [데이터 소스 유형](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getDataSourceType) 과 [외부 워크북 경로](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) 가 있습니다. 소스가 외부 워크북이면 전체 경로를 읽어 외부 파일이 사용 중인지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 절대 경로를 PPTX 파일에 저장하므로 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 있는 워크북을 사용할 수 있나요?**

예. 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서는 원격 워크북을 직접 편집하는 것을 지원하지 않으며, 소스로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX를 덮어쓰나요?**

프레젠테이션은 [외부 파일에 대한 링크](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) 를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본 파일을 그대로 유지해야 하면 워크북 복사본을 사용하십시오.

**외부 파일에 비밀번호가 설정되어 있으면 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 미리 보호를 해제하거나 [Aspose.Cells](https://reference.aspose.com/cells/python-java/) 등을 사용해 복호화된 복사본을 만든 뒤 해당 복사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 같은 파일을 가리키면 해당 파일을 업데이트했을 때 다음 데이터 로드 시 각 차트에 반영됩니다.