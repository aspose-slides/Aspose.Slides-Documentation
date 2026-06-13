---
title: Python으로 프레젠테이션에서 도넛 차트 맞춤 설정
linktitle: 도넛 차트
type: docs
weight: 30
url: /ko/python-net/doughnut-chart/
keywords:
- 도넛 차트
- 중앙 틈
- 구멍 크기
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python(.NET)를 사용하여 도넛 차트를 만들고 맞춤화하는 방법을 알아보고, PowerPoint 및 OpenDocument 형식을 지원하는 동적인 프레젠테이션을 구현합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 도넛 차트를 슬라이드에 추가하고, 중앙 구멍 크기를 설정한 뒤 프레젠테이션을 저장하는 방법을 보여줍니다. `doughnut_hole_size` 설정에 초점을 맞추고, 코드에서 이 차트 유형을 사용자 지정하는 데 필요한 기본 단계를 시연합니다.

또한 여러 시리즈를 사용해 여러 링을 만들고, 폭발된 도넛 차트를 작업하며, 차트를 래스터 이미지 또는 SVG로 내보내는 등 도넛 차트와 관련된 시나리오를 다루는 짧은 FAQ도 포함합니다.

## **도넛 차트에서 중앙 틈 지정**

도넛 차트의 구멍 크기를 지정하려면 아래 단계에 따라 진행하십시오:

- [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
- 슬라이드에 도넛 차트를 추가합니다.
- 도넛 차트의 구멍 크기를 지정합니다.
- 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 도넛 차트의 구멍 크기를 설정했습니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation 클래스의 인스턴스 생성
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # 프레젠테이션을 디스크에 저장
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**다중 링을 가진 다중 레벨 도넛을 만들 수 있나요?**

예. 단일 도넛 차트에 여러 시리즈를 추가하면 각 시리즈가 별도의 링이 됩니다. 링 순서는 컬렉션에 있는 시리즈 순서에 따라 결정됩니다.

**"폭발된" 도넛(분리된 슬라이스)이 지원되나요?**

예. Exploded Doughnut [chart type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/charttype/)이 있으며 데이터 포인트에 폭발 속성이 있어 개별 슬라이스를 분리할 수 있습니다.

**보고서를 위해 도넛 차트의 이미지(PNG/SVG)를 얻으려면 어떻게 해야 하나요?**

차트는 도형이며, 이를 [raster image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_image/)로 렌더링하거나 [SVG image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/write_as_svg/)로 내보낼 수 있습니다.