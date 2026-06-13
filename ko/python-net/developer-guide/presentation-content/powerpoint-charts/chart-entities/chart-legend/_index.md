---
title: Python을 사용한 프레젠테이션에서 차트 범례 맞춤 설정
linktitle: 차트 범례
type: docs
url: /ko/python-net/chart-legend/
keywords:
- 차트 범례
- 범례 위치
- 글꼴 크기
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 차트 범례를 맞춤 설정하고 PowerPoint 및 OpenDocument 프레젠테이션을 최적화합니다."
---
## **개요**

Aspose.Slides for Python은 차트 범례를 완전히 제어할 수 있어 데이터 레이블을 명확하고 프레젠테이션에 적합하게 만들 수 있습니다. 범례를 표시하거나 숨길 수 있으며, 슬라이드에서 위치를 선택하고 플롯 영역과 겹치지 않도록 레이아웃을 조정할 수 있습니다. API를 사용하면 텍스트와 마커를 스타일링하고, 패딩과 배경을 미세 조정하며, 테두리와 채우기를 테마에 맞게 포맷할 수 있습니다. 개발자는 개별 범례 항목에 접근하여 이름을 바꾸거나 필터링할 수 있어 가장 관련성이 높은 시리즈만 표시하도록 할 수 있습니다. 이러한 기능을 통해 차트는 읽기 쉬우며 일관되고 프레젠테이션 디자인 기준에 맞게 정렬됩니다.

## **범례 위치 지정**

Aspose.Slides를 사용하면 차트 범례가 표시되는 위치와 슬라이드 레이아웃에 어떻게 맞출지를 빠르게 제어할 수 있습니다. 범례를 정확히 배치하는 방법을 알아보세요.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 차트를 추가합니다.
1. 범례 속성을 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:

    # 슬라이드에 대한 참조를 가져옵니다.
    slide = presentation.slides[0]

    # 슬라이드에 클러스터된 열 차트를 추가합니다.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # 범례 속성을 설정합니다.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **범례 글꼴 크기 설정**

차트 범례는 설명하는 데이터만큼 읽기 쉬워야 합니다. 이 섹션에서는 프레젠테이션의 타이포그래피에 맞추고 접근성을 향상시키기 위해 범례의 글꼴 크기를 조정하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 차트를 만듭니다.
1. 글꼴 크기를 설정합니다.
1. 프레젠테이션을 디스크에 저장합니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **범례 항목의 글꼴 크기 설정**

Aspose.Slides를 사용하면 차트 범례의 개별 항목을 포맷하여 외관을 세밀하게 조정할 수 있습니다. 아래 예제는 특정 범례 항목을 대상으로 하여 나머지 범례는 변경하지 않고 속성을 설정하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 차트를 만듭니다.
1. 범례 항목에 접근합니다.
1. 항목 속성을 설정합니다.
1. 프레젠테이션을 디스크에 저장합니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**차트를 오버레이하지 않고 자동으로 범례를 위한 공간을 할당하도록 할 수 있나요?**

예. 비오버레이 모드([overlay](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/legend/overlay/) = `false`)를 사용합니다; 이 경우 플롯 영역이 줄어들어 범례를 수용합니다.

**다중 행 범례 레이블을 만들 수 있나요?**

예. 공간이 충분하지 않을 때 긴 레이블은 자동으로 줄바꿈됩니다; 강제 줄바꿈은 시리즈 이름에 newline 문자를 사용하여 지원됩니다.

**범례가 프레젠테이션 테마의 색 구성표를 따르도록 하려면 어떻게 해야 하나요?**

범례나 텍스트에 명시적인 색상/채우기/글꼴을 설정하지 마세요. 그러면 테마에서 상속받아 디자인이 변경될 때 자동으로 업데이트됩니다.