---
title: Python에서 프레젠테이션 차트의 플롯 영역 사용자 지정
linktitle: 플롯 영역
type: docs
url: /ko/python-java/chart-plot-area/
keywords:
- 차트
- 플롯 영역
- 플롯 영역 너비
- 플롯 영역 높이
- 플롯 영역 크기
- 레이아웃 모드
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션의 차트 플롯 영역을 사용자 지정하는 방법을 알아보세요. 슬라이드 시각 효과를 손쉽게 향상시킬 수 있습니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트의 플롯 영역을 사용하는 방법을 보여줍니다. 차트 레이아웃을 검증한 후 플롯 영역의 X, Y, 너비 및 높이 값을 읽어 실제 위치와 크기를 가져오는 방법을 설명합니다.

또한 레이아웃을 수동으로 설정할 때 플롯 영역의 레이아웃 모드를 구성하는 방법을 보여줍니다. LayoutTargetType을 사용하여 플롯 영역이 내부 영역만을 기준으로 계산되는지, 축 및 축 레이블을 포함한 외부 영역을 기준으로 계산되는지를 정의합니다.

## **차트 플롯 영역의 너비와 높이 가져오기**

Aspose.Slides for Python via Java는 차트 플롯 영역의 실제 위치와 크기를 읽기 위한 간단한 API를 제공합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 액세스합니다.
1. 기본 데이터가 포함된 차트를 추가합니다.
1. 실제 값을 가져오기 전에 Chart.validateChartLayout 메서드를 호출합니다.
1. 차트 요소의 실제 X 위치(왼쪽)를 차트의 왼쪽 위 모서리를 기준으로 가져옵니다.
1. 차트 요소의 실제 Y 위치(위쪽)를 차트의 왼쪽 위 모서리를 기준으로 가져옵니다.
1. 차트 요소의 실제 너비를 가져옵니다.
1. 차트 요소의 실제 높이를 가져옵니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Presentation 클래스의 인스턴스를 생성합니다.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **차트 플롯 영역의 레이아웃 모드 설정**

Aspose.Slides for Python via Java는 차트 플롯 영역의 레이아웃 모드를 설정하기 위한 간단한 API를 제공합니다. [setLayoutTargetType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) 및 [getLayoutTargetType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) 메서드는 [ChartPlotArea](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartplotarea/) 클래스에서 사용할 수 있습니다. 플롯 영역의 레이아웃이 수동으로 정의된 경우, 이 설정은 플롯 영역을 내부(축 및 축 레이블 제외) 기준으로 레이아웃할지 외부(축 및 축 레이블 포함) 기준으로 레이아웃할지를 지정합니다. [LayoutTargetType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layouttargettype/) 열거형에 정의된 두 가지 가능한 값이 있습니다.

- [Inner](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layouttargettype/#Inner) 는 플롯 영역 크기에 눈금과 축 레이블이 제외됨을 나타냅니다.
- [Outer](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layouttargettype/#Outer) 는 플롯 영역 크기에 눈금과 축 레이블이 포함됨을 나타냅니다.

샘플 코드는 아래에 제공됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Presentation 클래스의 인스턴스를 생성합니다.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **자주 묻는 질문**

**실제 X, 실제 Y, 실제 너비 및 실제 높이는 어떤 단위로 반환됩니까?**

포인트 단위이며, 1인치 = 72포인트입니다. 이는 Aspose.Slides 좌표 단위입니다.

**Plot Area와 Chart Area는 내용 면에서 어떻게 다릅니까?**

Plot Area는 데이터 그리기 영역(시리즈, 그리드선, 추세선 등)이며, Chart Area는 주변 요소(제목, 범례 등)를 포함합니다. 3D 차트에서는 Plot Area에 벽/바닥 및 축도 포함됩니다.

**레이아웃이 수동일 때 Plot Area의 X, Y, 너비 및 높이는 어떻게 해석됩니까?**

차트 전체 크기의 비율(0–1)로 해석됩니다. 이 모드에서는 자동 배치가 비활성화되고 설정한 비율이 사용됩니다.

**범례를 추가하거나 이동한 후 Plot Area 위치가 왜 변경되었나요?**

범례는 Plot Area 외부의 차트 영역에 위치하지만 레이아웃 및 사용 가능한 공간에 영향을 미치므로 자동 배치가 적용될 경우 Plot Area가 이동할 수 있습니다. (이는 PowerPoint 차트의 일반적인 동작입니다.)