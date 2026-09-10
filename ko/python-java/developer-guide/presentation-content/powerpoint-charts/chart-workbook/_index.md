---
title: Python을 사용해 Java로 프레젠테이션의 차트 워크북 관리
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
description: "Python을 위한 Aspose.Slides를 Java를 통해 소개합니다: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 간소화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법을 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용할 수 있을 때 차트 데이터를 편집하는 방법을 설명합니다.

## **워크북에서 차트 데이터 읽고 쓰기**
Aspose.Slides는 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터를 포함)을 읽고 쓸 수 있는 [readWorkbookStream](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#readWorkbookStream) 및 [writeWorkbookStream](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#writeWorkbookStream) 메서드를 제공합니다. **Note** 차트 데이터는 동일한 방식으로 구성되어 있거나 원본과 유사한 구조를 가져야 합니다.

다음 Python 코드는 샘플 작업을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **워크북 수정 후 차트 레이아웃 검증**
임베디드 워크북을 수정된 워크북으로 교체하면 차트는 원래의 시리즈 및 카테고리 컬렉션을 유지합니다. 이 불일치로 인해 [Chart.validateChartLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#validateChartLayout) 메서드가 `ArgumentOutOfRangeException`(매개변수: index)을 발생시킬 수 있습니다. 예외를 피하려면 업데이트된 워크북을 차트에 다시 기록하기 **전** 기존 시리즈와 카테고리를 모두 지우세요.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# 수정 후 워크북을 읽습니다 (예: Aspose.Cells 사용).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # 기존 데이터 참조를 삭제합니다.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

컬렉션을 지우면 차트 데이터 구조가 새로운 워크북과 일치하게 되어 [validateChartLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#validateChartLayout) 메서드가 오류 없이 완료됩니다.

## **워크북 셀을 차트 데이터 레이블로 설정**
1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 데이터가 포함된 버블 차트를 추가합니다.  
1. 차트 시리즈에 접근합니다.  
1. 워크북 셀을 데이터 레이블로 설정합니다.  
1. 프레젠테이션을 저장합니다.

다음 Python 코드는 워크북 셀을 차트 데이터 레이블로 설정하는 방법을 보여줍니다:

```python
import jpile
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
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
다음 Python 코드는 [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdataworkbook/#getWorksheets) 메서드를 사용해 워크시트 컬렉션에 접근하는 작업을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **데이터 소스 유형 지정**
다음 Python 코드는 데이터 소스 유형을 지정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **지원되지 않는 임베디드 워크북 형식 감지**
Aspose.Slides는 일부 차트에 임베디드될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [ChartData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/)의 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) 메서드와 [WorkbookType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/workbooktype/) 열거형을 함께 사용해 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다.

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
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # 임베디드 워크북이 .xlsb 형식이며, 지원되지 않습니다.
            continue
        # 여기서 차트 워크북 데이터를 읽거나 수정합니다.
finally:
    presentation.dispose()
```

### **외부 워크북 생성**
[readWorkbookStream](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#readWorkbookStream) 및 [setExternalWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#setExternalWorkbook) 메서드를 사용해 새 외부 워크북을 만들거나 내부 워크북을 외부 워크북으로 전환할 수 있습니다.

다음 Python 코드는 외부 워크북 생성 과정을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **외부 워크북 설정**
[setExternalWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#setExternalWorkbook) 메서드를 사용해 차트에 외부 워크북을 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북의 경로가 이동된 경우 경로를 업데이트하는 데도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 편집할 수는 없지만, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

다음 Python 코드는 외부 워크북을 설정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#setExternalWorkbook) 메서드의 두 번째(`bool`) 매개변수는 Excel 워크북을 로드할지 여부를 지정합니다.

* 값이 `False`이면 워크북 경로만 업데이트되고 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않습니다. 대상 워크북이 존재하지 않거나 사용할 수 없는 상황에서 이 설정을 사용할 수 있습니다.  
* 값이 `True`이면 차트 데이터가 대상 워크북에서 업데이트됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **차트의 외부 데이터 소스 워크북 경로 가져오기**
1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 차트 도형에 대한 객체를 생성합니다.  
1. 차트 데이터 소스를 나타내는 [ChartDataSourceType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatasourcetype/) 객체를 생성합니다.  
1. 외부 워크북 데이터 소스 유형과 동일한 소스 유형에 따라 관련 조건을 지정합니다.

다음 Python 코드는 해당 작업을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **차트 데이터 편집**
외부 워크북의 데이터를 내부 워크북을 편집하듯이 수정할 수 있습니다. 외부 워크북을 로드할 수 없을 경우 예외가 발생합니다.

다음 Python 코드는 설명된 프로세스의 구현 예시입니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **차트 캐시에서 워크북 복구**
차트가 누락되었거나 사용할 수 없는 외부 워크북을 사용 중인 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 통해 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/)를 생성하고 [SpreadsheetOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/spreadsheetoptions/)를 구성한 뒤 프레젠테이션을 열기 전에 `True`와 함께 [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ko/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) 메서드를 호출합니다.

다음 Python 예제는 외부 워크북을 사용할 수 없는 차트를 포함한 프레젠테이션을 열고 [Chart.getChartData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#getChartData) 및 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getChartDataWorkbook)를 통해 복구된 데이터를 액세스하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # 여기서 복구된 워크북 데이터를 읽거나 수정합니다.
finally:
    presentation.dispose()
```

외부 워크북을 사용할 수 없고 복구가 비활성화된 경우 Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대체 방법일 때만 복구를 활성화하세요. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 임베디드 워크북에 연결되어 있는지 확인할 수 있습니까?**  
예. 차트에는 [데이터 소스 유형](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getDataSourceType)과 [외부 워크북 경로](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)가 있습니다. 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용 중인지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장됩니까?**  
예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 이는 프로젝트 이식성을 높여 주지만, 프레젠테이션은 절대 경로를 PPTX 파일에 저장한다는 점을 유념하십시오.

**네트워크 리소스/공유에 있는 워크북을 사용할 수 있습니까?**  
예, 해당 워크북을 외부 데이터 소스로 사용할 수 있습니다. 다만 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX 파일을 덮어쓰나요?**  
아니오. 프레젠테이션은 [외부 파일에 대한 링크](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)를 저장하고 데이터를 읽을 때만 사용합니다. 프레젠테이션을 저장해도 외부 파일 자체는 수정되지 않습니다.

**외부 파일에 비밀번호가 걸려 있으면 어떻게 해야 하나요?**  
Aspose.Slides는 링크 시 비밀번호를 받지 않습니다. 일반적인 방법은 사전에 보호를 해제하거나, 예를 들어 [Aspose.Cells](/cells/python-java/)를 사용해 복호화된 복사본을 만든 후 그 복사본에 링크하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**  
예. 각 차트는 자체 링크를 저장합니다. 모두 동일한 파일을 가리키면 해당 파일을 업데이트할 때마다 다음 데이터 로드 시 모든 차트에 반영됩니다.