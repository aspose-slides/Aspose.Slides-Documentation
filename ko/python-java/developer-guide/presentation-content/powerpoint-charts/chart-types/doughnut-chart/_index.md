---
title: Python via Java를 사용하여 프레젠테이션에서 도넛 차트 맞춤화
linktitle: 도넛 차트
type: docs
weight: 30
url: /ko/python-java/doughnut-chart/
keywords:
- 도넛 차트
- 중앙 간격
- 구멍 크기
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python via Java용 Aspose.Slides에서 도넛 차트를 만들고 맞춤화하는 방법을 확인하고, 동적 프레젠테이션을 위한 PowerPoint 형식을 지원합니다."
---
## **Overview**

이 문서에서는 차트를 슬라이드에 추가하고, 중심 구멍 크기를 설정하며, 프레젠테이션을 저장하는 방법을 통해 Aspose.Slides에서 도넛 차트를 사용하는 방법을 보여줍니다. 이 문서는 [setDoughnutHoleSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) 메서드에 중점을 두고, 코드에서 이 차트 유형을 사용자 지정하는 데 필요한 기본 단계를 설명합니다.

또한 여러 시리즈를 사용해 여러 링을 만들기, 폭발형 도넛 차트 사용, 차트를 래스터 이미지 또는 SVG로 내보내는 등 도넛 차트와 관련된 시나리오를 다루는 간단한 FAQ를 포함합니다.

## **Specify the Center Gap in a Doughnut Chart**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java는 도넛 차트의 구멍 크기를 지정하는 것을 지원합니다. 이 섹션에서는 예제를 통해 구멍 크기를 지정하는 방법을 보여줍니다.
{{% /alert %}}

도넛 차트의 구멍 크기를 지정하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체를 인스턴스화합니다.
1. 슬라이드에 도넛 차트를 추가합니다.
1. 도넛 차트의 구멍 크기를 지정합니다.
1. 프레젠테이션을 디스크에 저장합니다.

다음 예제는 도넛 차트의 구멍 크기를 설정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Presentation 클래스의 인스턴스를 생성합니다.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I create a multi-level doughnut with multiple rings?**

예. 단일 도넛 차트에 여러 시리즈를 추가하면 각 시리즈가 별도의 링이 됩니다. 링의 순서는 컬렉션에 있는 시리즈 순서에 따라 결정됩니다.

**Is an "exploded" doughnut (separated slices) supported?**

예. Exploded Doughnut [chart type](https://reference.aspose.com/slides/ko/python-java/aspose.slides/charttype/) 차트 유형과 데이터 포인트에 대한 폭발 속성이 있으며, 개별 조각을 분리할 수 있습니다.

**How can I get an image of a doughnut chart (PNG/SVG) for a report?**

차트는 [shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/)이며, 이를 [raster image](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage)로 렌더링하거나 차트를 SVG 이미지로 내보낼 수 있습니다.