---
title: Python을 사용한 프레젠테이션 차트의 오류 막대 맞춤 설정
linktitle: 오류 막대
type: docs
url: /ko/python-java/error-bar/
keywords:
- 오류 막대
- 사용자 지정 값
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 차트에 오류 막대를 추가하고 맞춤 설정하는 방법을 배우고, PowerPoint 프레젠테이션의 데이터 시각화를 최적화하세요."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 차트에서 오류 막대를 사용하는 방법을 설명합니다. 차트 시리즈에 오류 막대를 추가하고 X 및 Y 오류 막대 설정을 구성하며 고정, 백분율 및 사용자 정의 값과 같은 다양한 값 유형을 적용하는 방법을 보여줍니다.

또한 시리즈의 개별 데이터 포인트 컬렉션을 사용하여 사용자 정의 오류 막대 값을 지정하는 방법을 시연합니다. 또한 오류 막대가 내보내기 중에 어떻게 동작하는지, 마커 및 데이터 레이블과의 호환성, 그리고 관련 API 참조 클래스 및 열거형을 찾을 수 있는 위치에 대한 간단한 주석을 포함합니다.

## **오류 막대 추가**

Aspose.Slides for Python via Java는 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 다음 샘플 코드는 고정 및 백분율 값 유형을 사용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 원하는 슬라이드에 버블 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 X 형식을 설정합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 Y 형식을 설정합니다.
1. 오류 막대 값과 서식을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Presentation 클래스의 인스턴스를 생성합니다.
presentation = Presentation()
try:
    # 버블 차트를 생성합니다.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # 오류 막대를 추가하고 서식을 설정합니다.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # 프레젠테이션을 저장합니다.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **사용자 정의 오류 막대 값 추가**

Aspose.Slides for Python via Java는 사용자 정의 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 다음 샘플 코드는 [getValueType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/errorbarsformat/#getValueType) 메서드가 [ErrorBarValueType.Custom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/errorbarvaluetype/#Custom) 값을 반환할 때 적용됩니다. 값을 지정하려면 시리즈 메서드 [getDataPoints](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseries/#getDataPoints) 가 반환하는 컬렉션에서 특정 데이터 포인트에 대해 [getErrorBarsCustomValues](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) 를 사용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 원하는 슬라이드에 버블 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 X 형식을 설정합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 Y 형식을 설정합니다.
1. 차트 시리즈의 개별 데이터 포인트에 접근하여 해당 오류 막대 값을 설정합니다.
1. 오류 막대 값과 서식을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Presentation 클래스의 인스턴스를 생성합니다.
presentation = Presentation()
try:
    # 버블 차트를 생성합니다.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # 사용자 정의 오류 막대를 추가하고 서식을 설정합니다.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # 차트 시리즈 데이터 포인트에 접근하고 오류 막대 값 소스를 구성합니다.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # 차트 시리즈 데이터 포인트에 대한 오류 막대 값을 설정합니다.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # 프레젠테이션을 저장합니다.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**프레젠테이션을 PDF 또는 이미지로 내보낼 때 오류 막대는 어떻게 되나요?**

호환 가능한 버전이나 렌더러를 사용하는 경우 오류 막대는 차트의 일부로 렌더링되어 차트 서식과 함께 변환 시 보존됩니다.

**오류 막대를 마커 및 데이터 레이블과 결합할 수 있나요?**

예. 오류 막대는 별개의 요소이며 마커 및 데이터 레이블과 호환됩니다. 요소가 겹치는 경우 서식을 조정해야 할 수 있습니다.

**API에서 오류 막대를 사용하기 위한 속성 및 클래스 목록은 어디서 찾을 수 있나요?**

API 참조에서 확인할 수 있습니다: [ErrorBarsFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/errorbarsformat/) 클래스와 관련 클래스인 [ErrorBarType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/errorbartype/) 및 [ErrorBarValueType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/errorbarvaluetype/).