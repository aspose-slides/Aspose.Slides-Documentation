---
title: 프레젠테이션 차트에서 Python을 사용한 오류 막대 사용자 지정
linktitle: 오류 막대
type: docs
url: /ko/python-net/error-bar/
keywords:
- 오류 막대
- 사용자 지정 값
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 차트에 오류 막대를 추가하고 사용자 지정하는 방법을 배우고, PowerPoint 및 OpenDocument 프레젠테이션에서 데이터 시각화를 최적화하십시오."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에서 오류 막대를 사용하는 방법을 설명합니다. 차트 시리즈에 오류 막대를 추가하고, X 및 Y 오류 막대 설정을 구성하며, 고정, 백분율 및 사용자 지정 값과 같은 다양한 값 유형을 적용하는 방법을 보여줍니다. 또한 해당 데이터 포인트 컬렉션을 사용하여 시리즈의 개별 데이터 포인트에 사용자 지정 오류 막대 값을 할당하는 방법을 보여줍니다. 추가로, 오류 막대가 내보내기 중에 어떻게 동작하는지, 마커 및 데이터 레이블과의 호환성, 그리고 관련 API 참조 클래스 및 열거형을 찾을 수 있는 위치에 대한 간단한 설명이 포함되어 있습니다.

## **오류 막대 추가**
Aspose.Slides for Python via .NET는 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 사용자 지정 값 유형을 사용할 때 적용됩니다. 값을 지정하려면 시리즈의 **DataPoints** 컬렉션에 있는 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 원하는 슬라이드에 버블 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 X 형식을 설정합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 Y 형식을 설정합니다.
1. 막대 값 및 형식 설정.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creating empty presentation
with slides.Presentation() as presentation:
    # Creating a bubble chart
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Adding Error bars and setting its format
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Saving presentation
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **사용자 지정 오류 막대 값 추가**
Aspose.Slides for Python via .NET는 사용자 지정 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 **IErrorBarsFormat.ValueType** 속성이 **Custom**인 경우에 적용됩니다. 값을 지정하려면 시리즈의 **DataPoints** 컬렉션에 있는 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 원하는 슬라이드에 버블 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 X 형식을 설정합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 Y 형식을 설정합니다.
1. 차트 시리즈의 개별 데이터 포인트에 접근하여 개별 시리즈 데이터 포인트에 대한 오류 막대 값을 설정합니다.
1. 막대 값 및 형식 설정.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 빈 프레젠테이션 만들기
with slides.Presentation() as presentation:
    # 버블 차트 만들기
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # 사용자 지정 오류 막대를 추가하고 형식 설정
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # 차트 시리즈 데이터 포인트에 접근하고 개별 포인트에 대한 오류 막대 값을 설정
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # 차트 시리즈 포인트에 대한 오류 막대 설정
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # 프레젠테이션 저장
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**프레젠테이션을 PDF 또는 이미지로 내보낼 때 오류 막대는 어떻게 되나요?**

오류 막대는 차트의 일부로 렌더링되며, 호환 가능한 버전 또는 렌더러를 사용한다면 변환 중 차트 서식과 함께 보존됩니다.

**오류 막대를 마커 및 데이터 레이블과 결합할 수 있나요?**

예. 오류 막대는 별도의 요소이며 마커와 데이터 레이블과 호환됩니다. 요소가 겹치는 경우 서식을 조정해야 할 수 있습니다.

**API에서 오류 막대를 다루기 위한 속성 및 열거형 목록은 어디에서 찾을 수 있나요?**

API 참조에서 찾을 수 있습니다: [ErrorBarsFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/errorbarsformat/) 클래스와 관련 열거형인 [ErrorBarType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/errorbartype/) 및 [ErrorBarValueType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/errorbarvaluetype/).