---
title: "Python via Java를 사용한 프레젠테이션의 파이 차트 맞춤 설정"
linktitle: "파이 차트"
type: docs
url: /ko/python-java/pie-chart/
keywords:
- "파이 차트"
- "차트 관리"
- "차트 맞춤 설정"
- "차트 옵션"
- "차트 설정"
- "플롯 옵션"
- "슬라이스 색상"
- "PowerPoint"
- "프레젠테이션"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides를 사용한 Python via Java로 파이 차트를 만들고 맞춤 설정하는 방법을 배우고, PowerPoint로 내보내어 몇 초 만에 데이터 스토리텔링을 강화하세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 파이 차트를 사용하는 방법을 설명합니다. 파이 차트의 Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 파이 차트에 대해 자동 슬라이스 색상을 활성화하는 방법을 보여줍니다.

예제에서는 차트를 슬라이드에 추가하고, 시리즈와 레이블 설정을 조정하며, 기본 차트 데이터를 사용자 정의 범주 및 값으로 교체하고, 업데이트된 프레젠테이션을 저장하는 등 실용적인 차트 사용자 지정 단계에 중점을 둡니다.

## **Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션**

Aspose.Slides for Python via Java는 Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션을 지원합니다. 이 섹션에서는 Aspose.Slides를 사용하여 해당 옵션을 지정하는 방법을 보여줍니다. 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 개체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트의 보조 플롯 옵션을 지정합니다.
1. 프레젠테이션을 디스크에 씁니다.

다음 예제는 Pie of Pie 차트의 다양한 속성을 설정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

    # Presentation 클래스의 인스턴스를 생성합니다.
presentation = Presentation()
try:
        # 슬라이드에 차트를 추가합니다.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

        # 다양한 속성을 설정합니다.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

        # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **자동 파이 차트 슬라이스 색상 설정**

Aspose.Slides for Python via Java는 자동 파이 차트 슬라이스 색상을 설정하기 위한 간단한 API를 제공합니다. 다음 예제는 이러한 설정을 적용하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 액세스합니다.
1. 기본 데이터가 있는 차트를 추가합니다.
1. 차트 제목을 설정합니다.
1. 차트 데이터 워크시트의 인덱스를 설정합니다.
1. 차트 데이터 워크북을 가져옵니다.
1. 기본 시리즈와 범주를 삭제합니다.
1. 새 범주를 추가합니다.
1. 새 시리즈를 추가합니다.
1. 새 시리즈가 값을 표시하도록 설정합니다.

수정된 프레젠테이션을 PPTX 파일에 씁니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Presentation 클래스의 인스턴스를 생성합니다.
presentation = Presentation()
try:
    # 기본 데이터가 있는 차트를 추가합니다.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # 차트 제목을 설정합니다.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # 차트 데이터 워크시트의 인덱스를 설정합니다.
    default_worksheet_index = 0

    # 차트 데이터 워크북을 가져옵니다.
    workbook = chart.getChartData().getChartDataWorkbook()

    # 기본 시리즈와 범주를 삭제합니다.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # 새 범주를 추가합니다.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # 새 시리즈를 추가합니다.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # 시리즈 데이터를 채웁니다.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # 새 시리즈가 값을 표시하도록 설정합니다.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**'Pie of Pie' 및 'Bar of Pie' 변형이 지원됩니까?**

예, 라이브러리는 [supports](https://reference.aspose.com/slides/ko/python-java/aspose.slides/charttype/) 파이 차트에 대한 보조 플롯을 지원하며, 여기에는 'Pie of Pie'와 'Bar of Pie' 유형이 포함됩니다.

**차트를 이미지(예: PNG)로만 내보낼 수 있습니까?**

예, 전체 프레젠테이션 없이 차트 자체를 이미지(예: PNG)로 [export the chart itself as an image](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage) 할 수 있습니다.