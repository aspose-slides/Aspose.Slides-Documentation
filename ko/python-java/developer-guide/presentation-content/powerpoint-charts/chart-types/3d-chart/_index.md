---
title: Python을 사용한 프레젠테이션에서 3D 차트 사용자 지정
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
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에 3D 차트를 만들 수 있습니다. Python 예제를 통해 회전, 높이 비율, 차트 깊이 및 시리즈 간 간격을 조정합니다."
---
## **개요**

Aspose.Slides for Python via Java를 사용하면 [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) 메서드를 통해 3D 차트의 뷰를 사용자 지정할 수 있습니다. 이 문서에서는 회전, 높이 비율, 깊이, 직각 축 및 시리즈 간 간격을 조정하고 프레젠테이션을 PPTX 형식으로 저장하는 방법을 보여줍니다.

## **3D 차트의 회전 및 깊이 설정**

아래 예제는 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)을 생성하고 [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart)을 사용하여 첫 번째 슬라이드에 누적 3D 열 차트를 추가합니다. 기본 시리즈와 범주를 각각 세 개의 값을 가진 두 개의 시리즈로 교체합니다. 워크시트 인덱스 `0`은 차트의 첫 번째 데이터 워크시트를 식별하고, 행 `0`은 시리즈 이름을, 열 `0`은 범주 레이블을 포함합니다.

[setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) 및 [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) 메서드는 차트의 회전을 각각 40도와 270도로 설정합니다. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents)는 차트 깊이를 너비의 150%로 설정하고, [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes)는 원근 대신 직각 축을 활성화합니다. 결과 프레젠테이션에는 이러한 3D 뷰 설정이 적용된 차트가 포함됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **3D 차트의 높이 비율 조정**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents)를 사용하여 3D 차트의 높이를 너비의 백분율로 설정합니다. 이렇게 하면 슬라이드의 차트 개체 크기를 변경하지 않고 3D 장면의 비율을 조정할 수 있습니다.

다음 예제는 기본 데이터(시리즈 3개와 범주 4개)를 가진 [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 차트를 생성합니다. 높이 비율을 50%, 100%, 200%로 설정한 세 개의 프레젠테이션을 저장합니다. 차트의 위치, 너비 및 높이는 고정된 상태로 유지됩니다. 데이터, 회전, 깊이, 시리즈 간격 및 서식은 세 파일 모두 동일하며, 높이 비율만 변경됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

다음 이미지는 동일한 .NET 예제에서 동일한 높이 설정을 보여주며 Microsoft PowerPoint를 사용해 내보낸 것입니다. 낮은 백분율은 평평한 장면을, 높은 백분율은 동일한 차트 개체 내에서 더 높은 장면을 생성합니다. PowerPoint는 또한 장면에 맞게 축 눈금 간격과 레이블 위치를 조정할 수 있습니다.

| 높이: 50% | 높이: 100% | 높이: 200% |
| --- | --- | --- |
| ![너비의 50% 높이로 설정된 3D 열 차트](height_percent_50.png) | ![너비의 100% 높이로 설정된 3D 열 차트](height_percent_100.png) | ![너비의 200% 높이로 설정된 3D 열 차트](height_percent_200.png) |

이 메서드들은 차트의 서로 다른 측면을 제어합니다:

| 메서드 | 효과 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | 3D 장면의 높이를 너비의 백분율로 표시 |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | 슬라이드에서 차트 개체의 높이(포인트) |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 3D 장면의 깊이를 너비의 백분율로 표시 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | 깊이 축을 따라 시리즈 간 간격을 마커 너비의 백분율로 표시 |

높이 설정은 실린더, 원뿔 및 피라미드 변형을 포함한 3D 열 및 막대 차트와 3D 선, 면, 파이 및 표면 차트에 영향을 줍니다. 위 비교는 검증된 `Column3D` 유형을 사용합니다. 이 설정은 2D `ClusteredColumn` 차트나 `BubbleWith3D` 차트의 모양을 변경하지 않으며, 이러한 이름은 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 클래스의 멤버입니다. 기타 차트 외형 설정은 [Chart Formatting](/slides/ko/python-java/chart-formatting/)을 참조하십시오.

## **시리즈 간 간격 조정**

[ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth)를 사용하여 3D 차트의 깊이 축을 따라 데이터 시리즈 간 거리를 마커 너비의 백분율로 제어합니다. **0~500**(포함) 값을 사용하십시오: `0`은 간격을 제거하고, 큰 값은 간격을 확대합니다. 차트 깊이가 고정된 경우, 간격을 늘리면 깊이 축을 따라 마커가 더 얇아집니다.

[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup)으로 그룹에 접근합니다. 이 설정은 해당 그룹의 모든 시리즈에 적용되며, 접근에 사용된 시리즈에만 적용되는 것이 아닙니다. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth)은 깊이 간격을 반환하고 부모 그룹의 설정을 반영합니다.

이 설정은 실린더, 원뿔 및 피라미드 변형을 포함한 3D 열 및 막대 차트와 3D 선 및 면 차트에 영향을 줍니다. 외관은 시리즈가 깊이, 클러스터링 또는 누적 방식으로 배열되는지에 따라 달라집니다. 개별 시리즈 간 간격을 명확히 비교하려면 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 클래스의 `ChartType.Column3D`를 사용하십시오.

이 메서드들은 차트의 서로 다른 측면을 제어합니다:

| 메서드 | 효과 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | 깊이 축을 따라 시리즈 간 간격을 마커 너비의 백분율로 표시 |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | 인접한 막대 또는 열 클러스터 간 간격을 막대 또는 열 너비의 백분율로 표시 |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 차트 전체 깊이를 차트 너비의 백분율로 표시 |

다음 독립형 예제는 기본 차트 데이터(시리즈 3개와 범주 4개)를 사용합니다. 데이터, 회전, 간격 너비 및 차트 깊이가 동일한 두 개의 프레젠테이션을 저장하며, 간격 깊이만 변경됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

다음 이미지는 동일한 .NET 예제에서 동일한 간격 깊이 설정을 보여주며 Microsoft PowerPoint를 사용해 내보낸 것입니다.

| 간격 깊이: 0% | 간격 깊이: 500% |
| --- | --- |
| ![깊이 축을 따라 시리즈 간 간격이 없는 3D 열 차트](gap_depth_0.png) | ![깊이 축을 따라 시리즈 간 500% 간격이 있는 3D 열 차트](gap_depth_500.png) |

## **3D 시리즈 유형 및 막대 모양 변경**

클러스터드 실린더 차트에서 첫 번째 시리즈는 실린더형 막대 모양으로 시작합니다. 예제에서는 각 변경 전후에 [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType)과 [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape)에서 반환되는 정수 값을 출력합니다. 표는 해당 상수 이름을 제공합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 첫 번째 시리즈에 대한 변경 | 시리즈 유형 | 막대 모양 |
| --- | --- | --- |
| 차트 생성 | `ClusteredCylinder` | `Cylinder` |
| 시리즈 유형을 `ClusteredCone`로 설정 | `ClusteredCone` | `Cone` |
| 막대 모양을 `Box`로 설정 | `ClusteredColumn3D` | `Box` |

`Box` 모양으로 설정하면 시리즈 유형도 `ClusteredColumn3D`로 변경됩니다. 코드가 시리즈 유형에 따라 분기한다면, 모양을 변경한 후 `series.getType()`을 호출하십시오. 할당 전에 캐시된 값은 여전히 `ClusteredCone` 분기를 선택할 수 있습니다.

![PowerPoint 비교 이미지: 첫 번째 시리즈가 왼쪽부터 실린더, 원뿔, 직사각형 열로 표시됨](series-shapes.png)

## **FAQ**

**Aspose.Slides에서 3D 모드를 지원하는 차트 유형은 무엇인가요?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D 및 100% Stacked Column 3D를 포함한 열 차트의 3D 변형과 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 클래스를 통해 제공되는 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 설치된 버전의 API 참조에서 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 멤버를 확인하십시오.

**보고서나 웹용 3D 차트의 래스터 이미지를 얻을 수 있나요?**

예. [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage)를 사용하거나 [전체 슬라이드 렌더링](/slides/ko/python-java/convert-powerpoint-to-png/)하여 PNG 또는 JPEG와 같은 형식으로 차트를 이미지로 내보낼 수 있습니다. 이는 래스터 미리보기가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드 또는 웹 페이지에 삽입하려는 경우에 유용합니다.

**대규모 3D 차트를 구축하고 렌더링하는 성능은 어떠한가요?**

성능은 데이터 양과 시각적 복잡도에 따라 달라집니다. 최상의 결과를 얻으려면 3D 효과를 최소화하고, 벽 및 플롯 영역에 무거운 텍스처를 사용하지 않으며, 가능하면 시리즈당 데이터 포인트 수를 제한하고, 대상 디스플레이나 인쇄 요구에 맞는 적절한 해상도와 크기로 출력하도록 렌더링하십시오.