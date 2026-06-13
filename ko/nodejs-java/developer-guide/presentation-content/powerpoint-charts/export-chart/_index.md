---
title: JavaScript를 사용한 프레젠테이션 차트 내보내기
linktitle: 차트 내보내기
type: docs
weight: 90
url: /ko/nodejs-java/export-chart/
keywords:
- 차트
- 차트를 이미지로
- 차트 이미지
- 차트 이미지 추출
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션 차트를 내보내는 방법을 배우고, PPT 및 PPTX 형식을 지원하며, 보고서를 모든 워크플로에 효율적으로 통합할 수 있습니다."
---
## **Overview**

Aspose.Slides는 프레젠테이션에서 차트를 이미지로 내보낼 수 있게 합니다. 이 문서에서는 차트에서 이미지를 추출하고 저장하는 방법을 보여줍니다. 이는 PowerPoint 프레젠테이션 외부에서 차트 시각 요소를 재사용해야 할 때 유용합니다.

## **Get Chart Image**

Aspose.Slides for Node.js via Java는 특정 차트의 이미지를 추출하는 기능을 제공합니다. 아래 예제가 제공됩니다.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**차트를 래스터 이미지가 아니라 벡터(SVG)로 내보낼 수 있나요?**

예. 차트는 도형이며, 해당 내용을 [shape-to-SVG 저장 방법](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/writeassvg/)을 사용해 SVG로 저장할 수 있습니다.

**내보낸 차트의 정확한 크기를 픽셀 단위로 어떻게 설정하나요?**

크기 또는 배율을 지정할 수 있는 image-rendering 오버로드를 사용하십시오. 라이브러리는 지정된 차원/배율로 객체를 렌더링하는 것을 지원합니다.

**내보낸 후 레이블 및 범례의 글꼴이 잘못 표시되면 어떻게 해야 하나요?**

[필요한 글꼴을 로드](/slides/ko/nodejs-java/custom-font/)하고 [FontsLoader](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsloader/)를 사용하면 차트 렌더링 시 메트릭과 텍스트 모양이 보존됩니다.

**내보내기가 PowerPoint 테마, 스타일 및 효과를 유지하나요?**

예. Aspose.Slides의 렌더러는 프레젠테이션의 서식(테마, 스타일, 채우기, 효과)을 따르므로 차트의 외관이 유지됩니다.

**차트 이미지를 넘어선 사용 가능한 렌더링/내보내기 기능은 어디서 찾을 수 있나요?**

출력 대상([PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/ko/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/ko/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/ko/nodejs-java/convert-powerpoint-to-html/) 등)을 위해 [API](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/)/[문서](/slides/ko/nodejs-java/convert-powerpoint/)를 확인하고 관련 렌더링 옵션을 살펴보세요.