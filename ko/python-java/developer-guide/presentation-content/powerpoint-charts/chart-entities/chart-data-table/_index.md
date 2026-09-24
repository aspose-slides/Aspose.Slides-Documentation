---
title: Python을 사용한 프레젠테이션에서 차트 데이터 테이블 사용자 지정
linktitle: 데이터 테이블
type: docs
url: /ko/python-java/chart-data-table/
keywords:
- 차트 데이터
- 데이터 테이블
- 글꼴 속성
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션의 차트 데이터 테이블 글꼴, 테두리 및 범례 키를 사용자 지정합니다."
---
## **Overview**

Aspose.Slides for Python via Java을 사용하면 차트의 데이터 테이블을 표시하고 텍스트 서식, 테두리 및 범례 키를 사용자 지정할 수 있습니다. 이 문서에서는 테이블을 활성화하고, 텍스트를 서식 지정하며, 각 유형의 테두리를 제어하고, 범례 키를 표시하거나 숨기는 방법을 설명합니다. 예제는 구성된 차트를 PPTX 파일에 저장합니다.

## **Set Font Properties**

차트의 데이터 테이블을 표시하려면 `True`를 [setDataTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setDataTable)에 전달합니다. 테이블에 접근하고 텍스트 서식을 구성하려면 [getChartDataTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#getChartDataTable)를 사용합니다.

1. 프레젠테이션을 로드하려면 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 사용합니다.
2. 첫 번째 슬라이드에 클러스터형 열 차트를 추가합니다.
3. 차트의 데이터 테이블을 활성화합니다.
4. [setFontBold](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setFontBold)로 굵은 텍스트를 활성화하고 20포인트 텍스트를 위해 `20`을 [setFontHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setFontHeight)에 전달합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 예제는 작업 디렉터리에 최소 한 개 슬라이드가 포함된 `test.pptx` 파일이 필요합니다. 위치 (50, 50)에 기본 데이터가 있는 차트를 추가하고, 너비 600포인트, 높이 400포인트로 지정합니다. 저장된 `output.pptx`에는 데이터 테이블이 활성화되고 지정된 글꼴 설정이 적용된 차트가 포함됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Customize Data Table Borders**

[Chart.setDataTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setDataTable)으로 테이블을 활성화하고 [Chart.getChartDataTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#getChartDataTable)을 통해 접근합니다. 세 가지 유형의 테두리를 독립적으로 제어할 수 있습니다:

- [setBorderHorizontal](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datatable/#setBorderHorizontal)은 가로 셀 테두리를 제어합니다.
- [setBorderVertical](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datatable/#setBorderVertical)은 세로 셀 테두리를 제어합니다.
- [setBorderOutline](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datatable/#setBorderOutline)은 테이블의 외부 테두리를 제어합니다.

각 메서드에 `True`를 전달하면 해당 테두리를 표시하고, `False`를 전달하면 숨깁니다. 다음 예제는 기본 데이터가 있는 클러스터형 열 차트를 생성하고, 가로 테두리와 외부 테두리를 표시하며, 세로 테두리를 숨깁니다. 입력 파일이 필요하지 않습니다. 차트의 위치와 크기는 포인트 단위로 지정됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

아래 비교는 네 가지 경우 모두 동일한 차트 데이터와 범례 키 설정을 사용합니다. 모든 테두리를 활성화한 상태에서 각 변형은 하나의 테두리 설정만 비활성화합니다. 왼쪽 아래 변형이 예제의 테두리 설정과 일치합니다.

![모든 테두리가 활성화된 차트 데이터 테이블, 가로 테두리 없음, 세로 테두리 없음, 외부 테두리 없음](data-table-borders.png)

## **Show or Hide Legend Keys**

범례 키는 데이터 테이블의 시리즈 이름 옆에 있는 작은 색상 표시기입니다. 독자가 각 테이블 행을 차트 시리즈와 매칭하는 데 도움이 됩니다. 이 표시기를 표시하려면 `True`를 [setShowLegendKey](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datatable/#setShowLegendKey)에 전달하고, 숨기려면 `False`를 전달합니다.

차트의 별도 범례는 [Chart.setLegend](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setLegend)으로 제어됩니다. 이러한 설정은 독립적이며, 별도 범례를 숨겨도 데이터 테이블 내부의 키는 숨겨지지 않고, 테이블의 키를 숨겨도 별도 범례는 숨겨지지 않습니다.

다음 예제는 기본 데이터가 있는 차트를 생성하고, 데이터 테이블을 활성화한 뒤 별도 범례를 숨기면서 테이블 내부에 범례 키를 표시합니다. 모든 테이블 테두리는 명시적으로 활성화됩니다. 입력 프레젠테이션이 필요하지 않습니다. 테이블의 키만 숨기려면 [setShowLegendKey](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datatable/#setShowLegendKey)에 `False`를 전달합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

아래 비교는 범례 키가 활성화된 경우와 비활성화된 경우의 동일한 테이블을 보여줍니다. 모든 테두리는 계속 활성화되고, 별도 차트 범례는 두 경우 모두 숨겨집니다.

![왼쪽에 범례 키가 표시되고 오른쪽에 숨겨진 차트 데이터 테이블](data-table-legend-keys.png)

## **FAQ**

**Can I show legend keys in a chart's data table?**  
예. 범례 키를 표시하려면 `True`를 [setShowLegendKey](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datatable/#setShowLegendKey)에 전달하고, 숨기려면 `False`를 전달합니다.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**  
예. Aspose.Slides는 차트와 표시된 데이터 테이블을 슬라이드의 일부로 렌더링하여 [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/ko/python-java/convert-powerpoint-to-html/), [이미지](/slides/ko/python-java/convert-powerpoint-to-png/)로 내보냅니다.

**Can I work with data tables in charts loaded from a template?**  
예. 기존 프레젠테이션이나 템플릿에서 로드한 차트의 경우, [hasDataTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#hasDataTable)와 [setDataTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#setDataTable)를 사용하여 데이터 테이블이 표시되는지 확인하거나 변경할 수 있습니다.

**How can I find charts that have a data table enabled?**  
각 슬라이드의 도형을 순회하면서 차트를 식별하고, 해당 차트의 [hasDataTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#hasDataTable) 메서드를 호출합니다. `True`값은 데이터 테이블이 활성화되어 있음을 나타냅니다.