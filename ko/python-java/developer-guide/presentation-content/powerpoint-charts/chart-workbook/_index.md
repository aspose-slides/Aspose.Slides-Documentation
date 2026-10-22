---
title: Python via Java를 사용한 프레젠테이션의 차트 워크북 관리
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
description: "Aspose.Slides for Python via Java를 발견하고: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화하세요."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법 및 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 검색하는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 보여줍니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 [빈 셀 표시 제어](/slides/ko/python-java/chart-series/)를 참조하십시오. 빈 셀과 0의 차이점 및 사용 가능한 표시 모드의 라인 차트 비교가 설명되어 있습니다.

## **숨겨진 행 및 열의 데이터 포함**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) 메서드를 사용하여 차트가 숨겨진 워크시트 행 및 열의 데이터를 플롯할지 여부를 제어합니다. `True`로 설정하면 보이는 셀만 플롯하고, `False`로 설정하면 보이는 셀과 숨겨진 셀을 모두 포함합니다. 이 설정은 차트 플로팅에만 영향을 미치며, 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[샘플 프레젠테이션](hidden-source-data.pptx)에는 첫 번째 슬라이드의 첫 번째 도형으로 열 차트가 포함되어 있습니다. 포함된 워크시트 `Sheet1`에는 `A1:C4` 범위가 정의되어 있습니다. 3행과 C열은 숨겨져 있지만 셀 값은 그대로 존재합니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매 (숨겨진 열) |
| --- | --- | --- | --- |
| 2 | 1월 | 10 | 30 |
| 3 (숨겨진 행) | 2월 | 40 | 60 |
| 4 | 3월 | 20 | 50 |

[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook)으로 소스 셀에 접근하고 [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden)으로 숨김 상태를 확인합니다. 이 메서드는 숨김 상태를 변경하지 않고 보고합니다. 이 예제에서 B2는 보이는 셀, B3은 숨겨진 행에 속하며, C2는 숨겨진 열에 속합니다; 각각 `False`, `True`, `True`를 출력합니다.

이 예제에서는 플롯 설정을 변경한 후 차트 데이터를 새로 고칩니다: [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream)으로 포함된 워크북을 유지하고, [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream)으로 다시 로드합니다. 모든 셀을 포함할 때는 [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange)도 사용해 숨겨진 2월 범주를 복원합니다. 단순히 플래그만 변경해도 샘플의 캐시된 차트 데이터와 범주 레이블을 새로 고칠 수 없습니다.

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

            # 임베드된 워크북에서 차트 데이터를 새로 고칩니다.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # 숨겨진 카테고리를 포함한 전체 소스 범위를 복원합니다.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

예제는 프레젠테이션을 두 버전으로 저장합니다: 보이는 소매 값(10 및 20)만 포함한 버전과 모든 여섯 값을 포함한 버전입니다. 아래 이미지가 두 플롯 모드를 보여줍니다. 3행과 C열은 두 포함된 워크북 모두에서 숨겨진 상태로 유지됩니다.

| 보이는 셀만 (`True`) | 모든 셀 (`False`) |
| --- | --- |
| ![보이는 셀만: 1월과 3월의 소매 값 10 및 20.](hidden_cells_True.png) | ![모든 셀: 1월, 2월, 3월의 소매 및 도매 값.](hidden_cells_False.png) |

값을 포함한 숨겨진 셀은 빈 셀과 다릅니다. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) 메서드는 누락된 값이 어떻게 표시될지 제어하지만, 숨겨진 소스 데이터를 포함하거나 제외하지는 않습니다. 자세한 예시는 [빈 셀 표시 제어](/slides/ko/python-java/chart-series/#control-the-display-of-empty-cells)를 참고하십시오.

## **차트 데이터 범위 검색**

기존 프레젠테이션에서 워크북 데이터를 업데이트하기 전에, 차트가 사용하는 워크시트 셀을 파악하기 위해 소스 범위를 검사합니다. [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) 메서드는 현재 데이터 범위를 워크시트 한정 수식 형태(`Sheet1!$A$1:$D$5`)로 반환합니다. 여기서 `Sheet1`은 워크시트 이름이고, `!`는 셀 범위와 구분하며, `$A$1:$D$5`는 절대 주소를 나타냅니다.

이 메서드는 차트나 워크북을 변경하지 않고 현재 범위만 읽어들입니다. 차트가 워크북을 데이터 소스로 사용하지 않으면 `InvalidOperationException`을 발생시킵니다. 자세한 내용은 [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)를 참고하십시오.

예제는 프레젠테이션을 열고 각 슬라이드의 도형을 직접 검사하여 차트를 찾습니다. 차트 이름과 소스 범위를 출력하며, 워크북을 사용하지 않는 차트는 메시지를 출력하고 다음 차트로 넘어갑니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides for Python via Java는 [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) 및 [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) 메서드를 제공하여 차트 데이터 워크북(앱소스.Cells로 편집된 차트 데이터 포함)을 읽고 쓸 수 있습니다. **Note** 차트 데이터는 동일한 방식으로 구성되었거나 소스와 유사한 구조를 가져야 합니다.

예제는 첫 번째 슬라이드 첫 번째 도형에 차트가 포함된 프레젠테이션을 사용합니다. 포함된 워크북을 바이트 배열로 읽고, 기존 시리즈와 범주를 지운 뒤 동일한 워크북을 다시 씁니다. 변경 사항은 메모리에 남으며, 프레젠테이션은 저장되지 않습니다.

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

### **워크북 수정 후 차트 레이아웃 검증**

임베드된 워크북을 수정된 워크북으로 교체하면 차트는 기존 시리즈와 범주 컬렉션을 유지합니다. 이 불일치로 인해 [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) 검증이 인덱스 범위 초과 오류를 발생시킬 수 있습니다. 업데이트된 워크북을 차트에 쓰기 전에 기존 시리즈와 범주를 지우세요. 예제는 첫 번째 슬라이드 첫 번째 도형에 차트가 있는 경우를 사용합니다. 주석 부분에 워크북 편집이 들어가며, 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리에서 레이아웃을 검증합니다.

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

        # 여기에서 워크북 바이트를 수정합니다. 예를 들어 Aspose.Cells를 사용할 수 있습니다.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

컬렉션을 비우면 워크북이 다시 쓰이기 전에 오래된 데이터 참조가 제거됩니다. 업데이트된 워크북에 맞게 필요한 시리즈와 범주 매핑을 재구성한 뒤 차트를 사용하십시오.

## **워크북 셀에 사용자 정의 숫자 형식 지정**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) 메서드를 사용하여 차트의 임베드된 워크북에서 숫자 값이 표시되는 방식을 제어합니다. 예를 들어, 변환율은 소수점 네 자리 퍼센트 형식으로, 계수는 소수점 다섯 자리 형식으로 표시해야 할 수 있습니다. 두 값 모두 계산 및 차트 플로팅에 사용할 수 있도록 숫자형으로 유지합니다.

숫자 형식은 표시 형식만 바꾸며 저장된 값은 변경되지 않습니다. `0.0000%` 형식은 `0.125`를 `12.5000%`로 표시하지만 저장된 숫자는 `0.125` 그대로입니다. 마찬가지로 `0.00000` 형식은 `0.1234567`을 `0.12346`으로 표시하지만 저장값은 라운드되지 않습니다. 사용자 정의 형식이 빈 문자열(`""`)이면 [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat)에서 반환된 형식이 사용됩니다.

다음 예제는 열 차트를 만든 뒤 [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook)으로 셀에 접근합니다. 워크시트 0의 B2에 변환율, C2에 계수가 들어 있으며 두 셀 모두 차트 값으로 사용됩니다. 예제는 또한 소스 형식에 연결된 값 레이블을 활성화합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

워크북 셀 형식은 차트 축이나 데이터 레이블에 직접 설정한 형식과 별개입니다. 이 예제에서는 각 레이블이 [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) = `True` 로 설정되어 소스 셀 값을 표시하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) = `True` 로 설정되어 소스 숫자 형식을 따릅니다. 프레젠테이션을 저장하고 다시 연 후 레이블은 `12.5000%`와 `0.12346`을 표시합니다. 수직 축은 자체 형식 `0.00`을 [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat)로 지정하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) = `False` 로 설정했습니다.

데이터 레이블을 독립적으로 서식 지정하려면 해당 레이블의 소스 연결 플래그를 `False` 로 설정하고 [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) 로 형식을 지정합니다. 이는 워크북 셀 형식에는 영향을 주지 않습니다. 예를 들어 독립 레이블 형식 `0.00` 은 첫 값을 `0.13` 로 표시하지만 B2는 여전히 `12.5000%` 를 표시합니다. 직접 레이블 서식 지정에 대한 내용은 [차트 데이터 레이블](/slides/ko/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels)을 참고하십시오.

아래 이미지는 프레젠테이션을 저장한 뒤 다시 연 후 렌더링된 결과입니다:

![소스 연결 레이블이 12.5000%와 0.12346을 표시하고, 독립적으로 서식 지정된 숫자 축을 가진 열 차트.](custom-cell-formats.png)

## **워크북 셀을 차트 데이터 레이블로 사용**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다.

예제는 기존 프레젠테이션 첫 번째 슬라이드에 기본 데이터가 포함된 버블 차트를 추가합니다. 워크시트 0의 A10:A12 셀을 첫 번째 시리즈의 처음 세 레이블로 사용하고, 셀 기반 레이블을 활성화한 뒤 업데이트된 프레젠테이션을 저장합니다.

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) 메서드는 차트 워크북에 포함된 워크시트에 접근할 수 있게 해줍니다. 예제는 기본 데이터가 포함된 파이 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

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

시리즈 포인트 값은 숫자 리터럴로 직접 저장될 수도 있습니다. 전체 예제는 [숫자 리터럴을 사용한 시리즈 값 설정](/slides/ko/python-java/chart-series/#set-series-values-using-numeric-literals)을 참고하십시오. 포인트 값의 소스 유형은 차트의 내부 또는 외부 워크북 구성과 별개이며, 숫자 리터럴을 사용한다고 해서 임베드된 워크북이 자동으로 제거되지는 않습니다.

예제는 기본 데이터가 포함된 3D 열 차트를 만들고, 서로 다른 데이터 소스를 사용해 두 시리즈 이름을 설정합니다. 첫 번째 이름은 문자열 리터럴이며, 두 번째 이름은 워크시트 0의 C1 셀을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) 열거형으로 각 이름의 소스를 선택합니다. 예제는 업데이트된 시리즈 이름을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

## **지원되지 않는 임베드 워크북 형식 감지**

Aspose.Slides는 일부 차트에 임베드될 수 있는 Excel 바이너리 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)의 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) 메서드와 [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) 열거형을 함께 사용해 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 예제는 기존 프레젠테이션 첫 번째 슬라이드의 도형을 검사하고, 차트가 아닌 도형은 건너뛰며, .xlsb 워크북이 임베드된 차트에 대해 진단 메시지를 출력합니다.

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
        # 지원되는 차트 워크북 데이터를 여기서 읽거나 수정합니다.
finally:
    presentation.dispose()
```

## **외부 워크북**

Aspose.Slides는 차트의 데이터 소스로 외부 워크북을 사용하는 것을 지원합니다.

### **외부 워크북 만들기**

[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream)와 [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) 메서드를 사용해 임베드된 차트 워크북을 파일로 내보낸 뒤 차트를 해당 외부 워크북에 연결합니다.

예제는 기본 데이터가 포함된 파이 차트를 만들고 워크북을 내보냅니다. 파일 쓰기가 완료된 후 외부 워크북을 차트 데이터 소스로 할당하고, 연결된 프레젠테이션을 저장합니다.

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

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) 메서드를 사용하면 차트에 외부 워크북을 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북이 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북 데이터는 편집할 수 없지만, 외부 데이터 소스로는 계속 사용할 수 있습니다. 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

예제는 워크시트 이름이 `Sheet1`인 외부 워크북을 사용합니다. 해당 워크시트에는 B1에 시리즈 이름, A2:A4에 범주 이름, B2:B4에 숫자 값이 들어 있습니다. 예제는 파이 차트를 만들고 워크북을 연결한 뒤 [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange)으로 A1:B4를 하나의 시리즈와 세 개의 범주에 매핑합니다. 연결된 차트와 함께 프레젠테이션을 저장합니다.

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

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) 의 `updateChartData` 매개변수는 워크북 로드 여부를 제어합니다.

* `updateChartData` 가 `False`이면 워크북 경로만 업데이트됩니다. 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않으므로 워크북이 없어도 됩니다.
* `updateChartData` 가 `True`이면 차트 데이터가 대상 워크북에서 업데이트됩니다.

다음 예제는 `updateChartData` 를 `False` 로 설정하고 자리표시자 URL을 할당합니다. 파이 차트의 기본 데이터를 유지하며, 워크북을 로드하지 않고 프레젠테이션을 저장합니다.

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

차트에 연결된 워크북을 확인하려면 차트가 외부 데이터 소스를 사용하는지 검사하고 워크북 경로를 가져옵니다.

예제는 외부 워크북에 연결된 차트가 있는 프레젠테이션의 첫 번째 슬라이드 첫 번째 도형을 검사합니다. 차트가 외부 워크북에 연결된 경우 [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) 를 콘솔에 출력하고, 프레젠테이션 복사본을 저장합니다.

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

예제는 첫 번째 슬라이드 첫 번째 도형에 있는 차트가 접근 가능한 외부 워크북에 연결된 경우를 사용합니다. 첫 번째 시리즈 첫 번째 데이터 포인트의 셀 기반 값을 100으로 설정하고 업데이트된 프레젠테이션을 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트되므로, 원본 워크북을 보존하려면 복사본을 사용하십시오.

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

차트가 존재하지 않거나 사용할 수 없는 외부 워크북을 사용하고 있다면, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/)를 만든 뒤 [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) 를 호출하고, [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) 를 `True` 로 설정한 뒤 프레젠테이션을 엽니다.

다음 Python 예제는 첫 번째 슬라이드 첫 번째 도형에 있는 차트가 사용 불가능한 외부 워크북을 참조하는 경우 워크북 데이터를 복구합니다. 복구된 데이터는 [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) 와 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 를 통해 접근합니다:

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

        # 복구된 워크북 데이터를 여기서 읽거나 수정합니다.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

외부 워크북이 사용 불가능하고 복구가 비활성화된 경우 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 경우에만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 임베드 워크북에 연결되어 있는지 확인할 수 있나요?**

네. 차트는 [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType)과 [external workbook 경로](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)를 가지고 있습니다. 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되고 있음을 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

네. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 절대 경로를 PPTX 파일에 저장하므로, 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 있는 워크북을 사용할 수 있나요?**

네, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX를 덮어쓰나요?**

프레젠테이션은 [external file에 대한 링크](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본 워크북을 변경하지 않아야 한다면 복사본을 사용하십시오.

**외부 파일에 비밀번호가 걸려 있으면 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 미리 보호를 제거하거나, [Aspose.Cells](https://reference.aspose.com/cells/python-java/) 등을 사용해 복호화된 복사본을 만든 뒤 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

네. 각 차트는 자체 링크를 저장합니다. 모두 동일한 파일을 가리키면 해당 파일을 업데이트했을 때 다음에 데이터가 로드될 때 모든 차트에 반영됩니다.