---
title: PHP에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드 to SVG
type: docs
weight: 50
url: /ko/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint를 SVG로
- 프레젠테이션을 SVG로
- 슬라이드를 SVG로
- PPT를 SVG로
- PPTX를 SVG로
- PPT를 SVG로 저장
- PPTX를 SVG로 저장
- PPT를 SVG로 내보내기
- PPTX를 SVG로 내보내기
- 슬라이드 렌더링
- 슬라이드 변환
- 슬라이드 내보내기
- 벡터 이미지
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 슬라이드를 SVG 이미지로 렌더링하는 방법을 알아보세요. 간단한 코드 예제로 고품질 시각 효과를 제공합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 슬라이드를 SVG 이미지로 렌더링하는 방법을 설명합니다. SVG 형식과 확장성, 접근성, 웹 개발에 적합함 등 장점을 설명합니다.

프레젠테이션 파일을 로드하고 슬라이드를 순회하며 각 슬라이드를 별도의 SVG 파일로 저장하는 방법을 배우게 됩니다. 이 문서는 PPT, PPTX, ODP, PPS 등 PowerPoint 및 OpenDocument 프레젠테이션 형식을 다루며, `Presentation` 클래스와 `writeAsSvg` 메서드를 사용해 프로그래밍 방식으로 변환하는 방법을 보여줍니다.

## **SVG 형식**

SVG(Scalable Vector Graphics의 약어)는 2차원 이미지를 렌더링하는 데 사용되는 표준 그래픽 유형 또는 형식입니다. SVG는 이미지를 XML에 벡터 형태로 저장하며, 동작이나 모양을 정의하는 세부 정보를 포함합니다.

SVG는 확장성, 인터랙티브성, 성능, 접근성, 프로그래밍 가능성 등 매우 높은 기준을 충족하는 몇 안 되는 이미지 형식 중 하나입니다. 이러한 이유로 웹 개발에서 널리 사용됩니다.

다음과 같은 경우 SVG 파일을 사용할 수 있습니다.

- **프레젠테이션을 *매우 큰 형식*으로 인쇄**하고자 할 때. SVG 이미지는 어느 해상도든 확장할 수 있습니다. 품질 저하 없이 필요할 때마다 SVG 이미지를 여러 번 크기 조정할 수 있습니다.
- **슬라이드에 있는 차트와 그래프를 *다양한 매체 또는 플랫폼*에 사용**합니다. 대부분의 뷰어가 SVG 파일을 해석할 수 있습니다.
- **가능한 가장 작은 이미지 크기로** 사용합니다. SVG 파일은 일반적으로 다른 형식의 고해상도 파일보다 작으며, 특히 비트맵(JPEG 또는 PNG) 기반 형식보다 작습니다.

## **슬라이드를 SVG 이미지로 렌더링**

Aspose.Slides for PHP via Java를 사용하면 프레젠테이션의 슬라이드를 SVG 이미지로 내보낼 수 있습니다. 다음 단계에 따라 SVG 이미지를 생성하십시오:

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션의 모든 슬라이드를 순회합니다.
3. 각 슬라이드를 FileOutputStream을 통해 개별 SVG 파일로 저장합니다.

{{% alert color="primary" %}} 
우리는 Aspose.Slides for PHP via Java의 PPT를 SVG로 변환하는 기능을 구현한 [무료 웹 애플리케이션](https://products.aspose.app/slides/ko/conversion/ppt-to-svg)을 사용해 보실 수 있습니다.
{{% /alert %}} 

다음 샘플 코드는 Aspose.Slides를 사용하여 PPT를 SVG로 변환하는 방법을 보여줍니다.

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $fileStream = new Java("java.io.FileOutputStream", "slide-" . $index . ".svg");
      try {
        $slide->writeAsSvg($fileStream);
      } finally {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**왜 브라우저마다 결과 SVG가 다르게 보일 수 있나요?**

특정 SVG 기능에 대한 지원이 브라우저 엔진마다 다르게 구현됩니다. [SVGOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/) 매개변수를 사용하면 호환성 문제를 완화할 수 있습니다.

**슬라이드뿐만 아니라 개별 도형도 SVG로 내보낼 수 있나요?**

예. 모든 [도형을 별도의 SVG로 저장](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/writeassvg/)할 수 있어 아이콘, 픽토그램 및 그래픽 재사용에 편리합니다.

**여러 슬라이드를 하나의 SVG(스트립/문서)로 결합할 수 있나요?**

표준 시나리오는 슬라이드당 하나의 SVG입니다. 여러 슬라이드를 하나의 SVG 캔버스로 결합하는 작업은 애플리케이션 수준에서 수행되는 후처리 단계입니다.