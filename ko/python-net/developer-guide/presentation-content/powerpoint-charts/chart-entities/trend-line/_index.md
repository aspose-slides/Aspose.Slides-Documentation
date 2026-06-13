---
title: Python에서 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/python-net/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항 추세선
- 거듭제곱 추세선
- 사용자 지정 추세선
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 차트에 추세선을 빠르게 추가하고 사용자 지정하세요 — 예측 정확도를 향상하고 청중을 사로잡는 실용적인 가이드와 코드 예제입니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 생성하고 차트 시리즈에 추세선을 추가하며, 지수형, 선형, 로그형, 이동 평균, 다항식 및 거듭제곱 등 여러 추세선 유형을 사용하는 방법을 보여줍니다.

또한 선 모양을 삽입하여 차트에 사용자 지정 선을 추가하는 방법을 설명하고, 앞뒤 추세선 투영 값과 PDF 또는 SVG로 내보낼 때 및 차트를 이미지로 렌더링할 때 추세선이 유지되는지에 대한 간단한 FAQ를 포함합니다.

## **추세선 추가**
Aspose.Slides for Python via .NET은 다양한 차트 추세선을 관리하기 위한 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드의 참조를 가져옵니다.
1. 원하는 유형 중 하나로 기본 데이터를 사용하여 차트를 추가합니다 (이 예제에서는 ChartType.CLUSTERED_COLUMN을 사용합니다).
1. 차트 시리즈 1에 지수형 추세선을 추가합니다.
1. 차트 시리즈 1에 선형 추세선을 추가합니다.
1. 차트 시리즈 2에 로그형 추세선을 추가합니다.
1. 차트 시리즈 2에 이동 평균 추세선을 추가합니다.
1. 차트 시리즈 3에 다항식 추세선을 추가합니다.
1. 차트 시리즈 3에 거듭제곱 추세선을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 추세선이 포함된 차트를 생성하는 데 사용됩니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 빈 프레젠테이션 생성
with slides.Presentation() as pres:

    # 클러스터드 컬럼 차트 생성
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # 차트 시리즈 1에 지수 추세선 추가
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # 차트 시리즈 1에 선형 추세선 추가
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # 차트 시리즈 2에 로그 추세선 추가
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # 차트 시리즈 2에 이동 평균 추세선 추가
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # 차트 시리즈 3에 다항식 추세선 추가
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # 차트 시리즈 3에 거듭제곱 추세선 추가
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # 프레젠테이션 저장
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **사용자 지정 선 추가**
Aspose.Slides for Python via .NET은 차트에 사용자 지정 선을 추가하기 위한 간단한 API를 제공합니다. 프레젠테이션의 선택된 슬라이드에 간단한 일반 선을 추가하려면 아래 단계에 따라 진행하십시오:

- Presentation 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- Shapes 객체가 제공하는 AddChart 메서드를 사용하여 새 차트를 생성합니다.
- Shapes 객체가 제공하는 AddAutoShape 메서드를 사용하여 선 유형의 AutoShape를 추가합니다.
- 도형 선의 색상을 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 사용자 지정 선이 포함된 차트를 생성하는 데 사용됩니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**추세선에서 'forward'와 'backward'는 무엇을 의미합니까?**

이는 추세선을 앞쪽/뒤쪽으로 연장한 길이를 의미합니다. 산점도(XY) 차트의 경우 축 단위로, 비산점도 차트의 경우 카테고리 수로 측정합니다. 값은 0 이상의 값만 허용됩니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 유지됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/ko/python-net/render-a-slide-as-an-svg-image/) 로 변환하고 차트를 이미지로 렌더링합니다. 차트의 일부인 추세선은 이러한 작업 중에 유지됩니다. 차트 자체의 이미지를 [내보내는](/slides/ko/python-net/create-shape-thumbnails/) 메서드도 제공됩니다.