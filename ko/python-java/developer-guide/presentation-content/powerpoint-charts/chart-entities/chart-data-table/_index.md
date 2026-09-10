---
title: Python을 사용하여 프레젠테이션에서 차트 데이터 테이블 맞춤 설정
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
description: "Python을 사용하여 PPT 및 PPTX용 차트 데이터 테이블을 Aspose.Slides for Python via Java와 함께 맞춤 설정하여 프레젠테이션의 효율성과 매력을 높입니다."
---
## **Overview**

이 문서에서는 Aspose.Slides에서 차트 데이터 테이블을 사용하는 방법을 설명합니다. 차트에 데이터 테이블을 표시하고 굵게 스타일 및 글꼴 높이와 같은 글꼴 속성을 설정하여 텍스트 서식을 사용자 지정하는 방법을 보여줍니다. 예제에서는 프레젠테이션을 생성하고, 차트를 추가하고, 차트 데이터 테이블을 활성화하고, 글꼴 설정을 적용한 뒤 업데이트된 프레젠테이션을 저장하는 과정을 시연합니다.

또한 차트 데이터 테이블에 범례 키를 표시하는 방법, 내보내기 시 데이터 테이블을 보존하는 방법, 기존 프레젠테이션이나 템플릿에서 로드된 차트를 사용하는 방법, 데이터 테이블이 활성화된 차트를 식별하는 방법 등에 대한 일반적인 질문에 대한 간략한 답변을 포함합니다.

## **Set Font Properties for a Chart Data Table**

Aspose.Slides for Python via Java를 사용하면 차트의 데이터 테이블을 표시하고 해당 텍스트의 글꼴 속성을 변경할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트 데이터 테이블을 표시합니다.
1. 데이터 테이블 텍스트의 굵게 스타일과 글꼴 높이를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 예제는 이러한 단계들을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# 빈 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I show small legend keys next to the values in the chart’s data table?**

예. 데이터 테이블은 [legend keys](https://reference.aspose.com/slides/ko/python-java/aspose.slides/datatable/#setShowLegendKey)를 지원하며, 이를 켜거나 끌 수 있습니다.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

예. Aspose.Slides는 차트를 슬라이드의 일부로 렌더링하므로, 내보낸 [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/ko/python-java/convert-powerpoint-to-html/)/[image](/slides/ko/python-java/convert-powerpoint-to-png/)에는 데이터 테이블이 포함된 차트가 포함됩니다.

**Are data tables supported for charts that come from a template file?**

예. 기존 프레젠테이션이나 템플릿에서 로드된 모든 차트에 대해, 차트 속성을 사용하여 데이터 테이블이 [표시되는지](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#hasDataTable)를 확인하고 변경할 수 있습니다.

**How can I quickly find which charts in a file have the data table enabled?**

각 차트의 데이터 테이블이 [표시되는지](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/#hasDataTable)를 나타내는 속성을 검사하고 슬라이드를 순회하면서 해당 테이블이 활성화된 차트를 식별합니다.