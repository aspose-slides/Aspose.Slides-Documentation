---
title: Python을 사용하여 프레젠테이션에서 3D 차트 사용자 지정
linktitle: 3D 차트
type: docs
url: /ko/python-java/3d-chart/
keywords:
- 3D 차트
- 회전
- 깊이
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 3-D 차트를 만들고 사용자 지정하는 방법을 배우고, PPT 및 PPTX 파일을 지원하여 프레젠테이션을 강화하세요."
---
## **개요**

이 문서는 [Rotation3D](https://reference.aspose.com/slides/ko/python-java/aspose.slides/rotation3d/) 설정(예: [setRotationX](https://reference.aspose.com/slides/ko/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/ko/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/ko/python-java/aspose.slides/rotation3d/#setDepthPercents), [setRightAngleAxes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/rotation3d/#setRightAngleAxes))을 구성하여 Aspose.Slides에서 3D 차트를 사용자 지정하는 방법을 설명합니다. 프레젠테이션을 생성하고 기본 데이터가 포함된 3D 차트를 추가한 다음 필요한 3D 보기 설정을 적용하고 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 안내합니다.

## **3D 차트의 X 회전, Y 회전 및 깊이 설정**
Aspose.Slides for Python via Java는 이러한 속성을 설정하기 위한 간단한 API를 제공합니다. 다음 예제는 3D 차트의 X 회전, Y 회전 및 깊이를 설정하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 액세스합니다.
3. 기본 데이터가 포함된 차트를 추가합니다.
4. 3D 회전 속성을 설정합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # 첫 번째 슬라이드에 액세스합니다.
    slide = presentation.getSlides().get_Item(0)

    # 기본 데이터가 포함된 차트를 추가합니다.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # 차트 데이터 워크시트 인덱스를 설정합니다.
    default_worksheet_index = 0

    # 차트 데이터 워크북을 가져옵니다.
    workbook = chart.getChartData().getChartDataWorkbook()

    # 시리즈를 추가합니다.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # 카테고리를 추가합니다.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # 3D 회전 속성을 설정합니다.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # 두 번째 차트 시리즈에 액세스합니다.
    series = chart.getChartData().getSeries().get_Item(1)

    # 시리즈 데이터를 채웁니다.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # 프레젠테이션을 저장합니다.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides에서 3D 모드를 지원하는 차트 유형은 무엇인가요?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D 등 컬럼 차트의 3D 변형과 [ChartType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/charttype/) 클래스에 노출된 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 설치된 버전의 API 참조에 있는 ChartType 멤버를 확인하세요.

**보고서나 웹용으로 3D 차트의 래스터 이미지를 얻을 수 있나요?**

예. 차트를 [chart API](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage)를 통해 이미지로 내보내거나 전체 슬라이드를 [/slides/ko/python-java/convert-powerpoint-to-png/](/slides/ko/python-java/convert-powerpoint-to-png/)와 같은 형식으로 렌더링할 수 있습니다. 이는 픽셀 단위의 정확한 미리보기가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드, 웹 페이지에 삽입하려는 경우에 유용합니다.

**대용량 3D 차트를 구축하고 렌더링하는 성능은 어떠한가요?**

성능은 데이터 양과 시각적 복잡성에 따라 달라집니다. 최상의 결과를 얻으려면 3D 효과를 최소화하고, 벽 및 플롯 영역에 무거운 텍스처를 사용하지 않으며, 가능하면 시리즈당 데이터 포인트 수를 제한하고, 대상 디스플레이 또는 인쇄 요구에 맞게 적절한 해상도와 크기의 출력으로 렌더링하세요.