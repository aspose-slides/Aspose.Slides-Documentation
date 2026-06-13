---
title: 프레젠테이션에서 C++를 사용하여 도넛 차트 맞춤 설정
linktitle: 도넛 차트
type: docs
weight: 30
url: /ko/cpp/doughnut-chart/
keywords:
- 도넛 차트
- 중앙 간격
- 구멍 크기
- PowerPoint
- 프레젠테이션
- С++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++용 도넛 차트를 만들고 맞춤 설정하는 방법을 알아보고, 동적인 프레젠테이션을 위해 PowerPoint 형식을 지원합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 도넛 차트를 슬라이드에 추가하고 중앙 구멍 크기를 설정한 다음 프레젠테이션을 저장하는 방법을 보여줍니다. `set_DoughnutHoleSize` 메서드에 중점을 두고 코드에서 이 차트 유형을 사용자 지정하는 데 필요한 기본 단계를 설명합니다.

## **도넛 차트의 중앙 간격 지정**
도넛 차트의 구멍 크기를 지정하려면 아래 단계를 따라 주세요:

- [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
- 슬라이드에 도넛 차트를 추가합니다.
- 도넛 차트의 구멍 크기를 지정합니다.
- 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 도넛 차트의 구멍 크기를 설정했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **자주 묻는 질문**

**다중 링을 가진 다단계 도넛을 만들 수 있나요?**

예. 단일 도넛 차트에 여러 시리즈를 추가하면 각 시리즈가 별도의 링이 됩니다. 링의 순서는 컬렉션에 있는 시리즈의 순서에 따라 결정됩니다.

**'폭발된' 도넛(분리된 슬라이스)이 지원되나요?**

예. Exploded Doughnut [chart type](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/charttype/)와 데이터 포인트에 대한 폭발 속성이 있어 개별 슬라이스를 분리할 수 있습니다.

**보고서를 위해 도넛 차트의 이미지(PNG/SVG)를 얻으려면 어떻게 해야 하나요?**

차트는 도형이며, 이를 [raster image](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getimage/)로 렌더링하거나 [SVG image](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/writeassvg/)로 내보낼 수 있습니다.