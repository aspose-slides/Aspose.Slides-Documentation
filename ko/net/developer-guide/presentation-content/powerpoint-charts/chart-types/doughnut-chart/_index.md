---
title: ".NET에서 프레젠테이션용 도넛 차트 사용자 정의"
linktitle: "도넛 차트"
type: docs
weight: 30
url: /ko/net/doughnut-chart/
keywords:
- 도넛 차트
- 중앙 간격
- 구멍 크기
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 도넛 차트를 만들고 사용자 정의하는 방법을 알아보세요. 동적 프레젠테이션을 위한 PowerPoint 형식을 지원합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 도넛 차트를 슬라이드에 추가하고, 중앙 구멍의 크기를 설정하고, 프레젠테이션을 저장하는 방법을 보여줍니다. `DoughnutHoleSize` 설정에 초점을 맞추고 이 차트 유형을 코드에서 사용자 정의하기 위해 필요한 기본 단계를 시연합니다.

또한 여러 시리즈를 사용하여 여러 개의 링을 만들고, 폭발된 도넛 차트를 다루며, 차트를 래스터 이미지 또는 SVG로 내보내는 등 관련 도넛 차트 시나리오를 다루는 짧은 FAQ를 포함합니다.

## **도넛 차트에서 중앙 구멍 지정**

도넛 차트의 구멍 크기를 지정하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
- 슬라이드에 도넛 차트를 추가합니다.
- 도넛 차트의 구멍 크기를 지정합니다.
- 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 도넛 차트의 구멍 크기를 설정했습니다.

```c#
 // Presentation 클래스의 인스턴스를 생성합니다
 Presentation presentation = new Presentation();

 IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
 chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

 // 프레젠테이션을 디스크에 저장합니다
 presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**다중 링을 가진 다단계 도넛을 만들 수 있나요?**

예. 단일 도넛 차트에 여러 시리즈를 추가하면 각 시리즈가 별도의 링이 됩니다. 링 순서는 컬렉션 내 시리즈 순서에 따라 결정됩니다.

**"폭발된" 도넛(분리된 슬라이스)이 지원되나요?**

예. Exploded Doughnut [chart type](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/charttype/)과 데이터 포인트에 대한 폭발 속성이 있어 개별 슬라이스를 분리할 수 있습니다.

**보고서를 위해 도넛 차트의 이미지(PNG/SVG)를 얻으려면 어떻게 해야 하나요?**

차트는 도형이므로 [raster image](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/getimage/)로 렌더링하거나 차트를 [SVG image](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/writeassvg/)로 내보낼 수 있습니다.