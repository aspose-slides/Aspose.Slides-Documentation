---
title: PHP에서 프레젠테이션 차트 내보내기
linktitle: 차트 내보내기
type: docs
weight: 90
url: /ko/php-java/export-chart/
keywords:
- 차트
- 이미지 차트 변환
- 차트를 이미지로
- 차트 이미지 추출
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 프레젠테이션 차트를 내보내는 방법을 배우고, PPT 및 PPTX 형식을 지원하며, 보고서를 모든 워크플로에 효율적으로 통합하세요."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션의 차트를 이미지로 내보낼 수 있습니다. 이 문서에서는 차트에서 이미지를 가져와 저장하는 방법을 보여주며, PowerPoint 프레젠테이션 외부에서 차트 시각 자료를 재사용해야 할 때 유용합니다.

## **차트 이미지 가져오기**
Aspose.Slides for PHP via Java는 특정 차트의 이미지를 추출하는 기능을 제공합니다. 아래 샘플 예제가 제공됩니다.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**차트를 래스터 이미지가 아니라 벡터(SVG) 형식으로 내보낼 수 있나요?**

예. 차트는 도형이며, 해당 내용을 SVG로 저장하려면 [shape-to-SVG 저장 방법](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/writeassvg/)을 사용할 수 있습니다.

**내보낸 차트의 정확한 픽셀 크기를 어떻게 지정할 수 있나요?**

크기 또는 스케일을 지정할 수 있는 image-rendering 오버로드를 사용하십시오—라이브러리는 지정된 치수/스케일로 객체를 렌더링하는 것을 지원합니다.

**내보낸 후 레이블 및 범례의 폰트가 잘못 표시되면 어떻게 해야 하나요?**

[필요한 폰트 로드](/slides/ko/php-java/custom-font/)를 [FontsLoader](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/)를 통해 수행하면 차트 렌더링 시 메트릭 및 텍스트 모양이 보존됩니다.

**내보내기가 PowerPoint 테마, 스타일 및 효과를 반영하나요?**

예. Aspose.Slides의 렌더러는 프레젠테이션의 서식(테마, 스타일, 채우기, 효과)을 따르므로 차트의 외관이 유지됩니다.

**차트 이미지 외에 사용할 수 있는 렌더링/내보내기 기능은 어디에서 확인할 수 있나요?**

출력 대상([PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/ko/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/ko/php-java/convert-powerpoint-to-xps/), [HTML](/slides/ko/php-java/convert-powerpoint-to-html/) 등) 및 관련 렌더링 옵션은 [API](https://reference.aspose.com/slides/ko/php-java/aspose.slides/)/[문서](/slides/ko/php-java/convert-powerpoint/)에서 확인하십시오.