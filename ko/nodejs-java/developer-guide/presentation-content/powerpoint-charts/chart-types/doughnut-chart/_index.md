---
title: JavaScript를 사용하여 프레젠테이션에서 도넛 차트 사용자 지정
linktitle: 도넛 차트
type: docs
weight: 30
url: /ko/nodejs-java/doughnut-chart/
keywords:
- 도넛 차트
- 중심 간격
- 구멍 크기
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용해 도넛 차트를 만들고 사용자 지정하는 방법을 알아보고, 동적 프레젠테이션을 위한 PowerPoint 형식을 지원합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 도넛 차트를 슬라이드에 추가하고, 중심 구멍의 크기를 설정한 후 프레젠테이션을 저장하는 방법을 보여줍니다. `setDoughnutHoleSize` 메서드에 초점을 맞추고 코드에서 이 차트 유형을 사용자 지정하기 위해 필요한 기본 단계들을 설명합니다.

또한 여러 시리즈를 사용해 여러 개의 링을 만들거나, 폭발된 도넛 차트를 사용하고, 차트를 래스터 이미지 또는 SVG로 내보내는 등 도넛 차트와 관련된 짧은 FAQ도 포함하고 있습니다.

## **도넛 차트의 중심 간격 변경**

도넛 차트의 구멍 크기를 지정하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 개체를 인스턴스화합니다.
2. 슬라이드에 도넛 차트를 추가합니다.
3. 도넛 차트의 구멍 크기를 지정합니다.
4. 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 도넛 차트의 구멍 크기를 설정했습니다.

```javascript
// Presentation 클래스 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **자주 묻는 질문**

**다중 링이 있는 다단계 도넛 차트를 만들 수 있나요?**

예. 단일 도넛 차트에 여러 시리즈를 추가하면 각 시리즈가 별도의 링이 됩니다. 링 순서는 컬렉션에 있는 시리즈의 순서에 따라 결정됩니다.

**“폭발된” 도넛(분리된 슬라이스)을 지원하나요?**

예. Exploded Doughnut [chart type](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/charttype/)과 데이터 포인트에 대한 폭발 속성이 있어 개별 슬라이스를 분리할 수 있습니다.

**보고서를 위해 도넛 차트의 이미지(PNG/SVG)를 얻으려면 어떻게 해야 하나요?**

차트는 도형이므로 [raster image](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getImage)로 렌더링하거나 차트를 [SVG image](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/writeassvg/)로 내보낼 수 있습니다.