---
title: Python via Java를 사용한 프레젠테이션 파이 차트 맞춤
linktitle: 파이 차트
type: docs
url: /ko/python-java/pie-chart/
keywords:
- 파이 차트
- 차트 관리
- 차트 맞춤
- 차트 옵션
- 차트 설정
- 플롯 옵션
- 슬라이스 색상
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python via Java로 파이 차트를 만들고 맞춤화합니다. 보조 플롯을 구성하고, 데이터 레이블을 표시하며, PowerPoint에서 자동 슬라이스 색상을 적용합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 파이 차트를 사용하는 방법을 설명합니다. 파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 파이 차트에 자동 슬라이스 색상을 적용하는 방법을 보여줍니다.

예제에서는 차트를 슬라이드에 추가하고, 시리즈 및 레이블 설정을 조정하고, 기본 차트 데이터를 사용자 정의 범주와 값으로 교체하고, 업데이트된 프레젠테이션을 저장하는 등 차트 맞춤 작업에 중점을 둡니다.

## **파이 오브 파이 및 바 오브 파이 차트용 보조 플롯 옵션**

Aspose.Slides for Python via Java는 파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션을 지원합니다. 이 옵션들은 보조 플롯의 크기와 두 플롯 간에 데이터 포인트가 어떻게 분할되는지를 제어합니다.

다음 예제는 새 프레젠테이션에서 파이 오브 파이 차트를 만들고 데이터 포인트 값을 레이블로 표시합니다. [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) 메서드는 보조 플롯 크기를 메인 플롯의 149%로 설정합니다. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 은 백분율 기반 분할을 선택하고, [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) 은 임계값을 53%로 설정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # 값을 표시하고 보조 플롯을 구성합니다.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **보조 플롯용 범주 선택**

백분율 값에 관계없이 특정 범주를 보조 플롯에 그룹화하려면 사용자 지정 분할을 사용합니다. 예를 들어, 판매 보고서에서는 온라인과 이벤트를 함께 표시하여 독자가 두 채널을 비교할 수 있도록 할 수 있는데, 이 채널들은 전체 판매의 35%와 10%를 차지합니다.

다음과 같이 [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy)에 [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom)을 전달하고 [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints)를 통해 포인트를 선택합니다. 컬렉션의 [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) 메서드는 시리즈에서 0부터 시작하는 인덱스를 허용하며, [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem)를 사용하여 데이터 포인트 객체를 추가합니다. 이 예제에서는 인덱스 1이 온라인을 선택하고, 인덱스 3이 이벤트를 선택합니다. 파트너도 일시적으로 추가된 뒤 [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem)으로 제외됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # 기본 데이터를 채널별 판매 데이터로 교체합니다.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # 온라인을 0 기반 인덱스로, 이벤트를 데이터 포인트 객체로 선택합니다.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # 파트너를 소스 데이터를 삭제하지 않고 선택에서 제외합니다.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

온라인(35)과 이벤트(10)는 보조 플롯에서 별개의 슬라이스로 표시됩니다. 기본 플롯에서는 소매(40) 및 파트너(15)와 함께 값이 45인 하나의 결합 슬라이스로 나타납니다. 파트너를 사용자 지정 선택에서 제거하면 기본 플롯에 남으며, 차트 원본 데이터에서 해당 범주나 값을 제거하지는 않습니다.

다음 이미지에서는 PowerPoint에 저장된 프레젠테이션을 보여줍니다:

![보조 플롯에 온라인 및 이벤트가 표시되고 기본 플롯에 결합 값 45가 표시된 파이 오브 파이 차트](pie_of_pie_custom.png)

## **파이 차트 슬라이스 자동 색상 설정**

Aspose.Slides for Python via Java는 파이 차트 슬라이스에 서로 다른 색상을 자동으로 할당할 수 있습니다. 다음 예제는 가운데 제목이 있는 파이 차트를 만들고 기본 데이터를 3개의 분기별 범주와 해당 값으로 교체합니다. [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) 메서드는 값 20, 50, 30을 레이블로 표시하고, [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) 은 각 슬라이스에 개별 색상을 적용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # 중앙에 차트 제목을 추가합니다.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # 첫 번째 워크시트를 사용하여 기본 데이터를 교체합니다.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # 값을 표시하고 슬라이스에 서로 다른 색상을 할당합니다.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **자주 묻는 질문**

**파이 오브 파이 및 바 오브 파이 변형이 지원됩니까?**

예, 라이브러리는 파이 차트용 보조 플롯을 [지원합니다](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)하며, 파이 오브 파이 및 바 오브 파이 유형을 포함합니다.

**차트를 이미지(PNG 등)로만 내보낼 수 있나요?**

예, 전체 프레젠테이션을 내보내지 않고 차트 자체를 이미지(PNG 등)로 [내보낼 수 있습니다](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage).