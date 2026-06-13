---
title: PHP에서 프레젠테이션 접근성 관리
linktitle: 프레젠테이션 접근성
type: docs
weight: 30
url: /ko/php-java/presentation-accessibility/
keywords:
- 프레젠테이션 접근성
- 장식으로 표시
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides가 PPT, PPTX 및 ODP 파일에서 프레젠테이션 접근성 검사를 자동화하도록 도와줍니다—스크린 리더 경험을 향상하고 규정 준수를 강화합니다."
---
## **개요**

프레젠테이션 접근성은 화면 판독기, 점자 디스플레이, 또는 키보드 전용 탐색과 같은 보조 기술을 사용하는 사람들이 시각이 있고 마우스를 사용하는 청중만큼 효과적으로 슬라이드를 이해하고 탐색할 수 있도록 보장합니다. 좋은 관행은 명확한 읽기 순서, 유용한 시각 자료에 대한 의미 있는 대체 텍스트, 충분한 색상 대비, 읽기 쉬운 타이포그래피, 설명적인 링크 텍스트, 그리고 색상이나 위치만으로 의미를 전달하는 것을 피하는 데 중점을 둡니다. 접근성을 처음부터 계획하면 더 깔끔한 구조, 보다 일관된 시각 요소, 그리고 별도의 우회 조치 없이 모든 시청자에게 도달하는 콘텐츠를 얻을 수 있습니다.

## **장식으로 표시**

장식으로 표시 플래그는 순수히 장식적인 시각 요소에 사용되어 화면 판독기가 이를 건너뛰게 함으로써 잡음을 줄이고 의미 있는 콘텐츠에 집중하도록 합니다. 배경, 장식 요소 및 간격용 요소에 적용하고 차트, 아이콘 또는 정보를 전달하는 이미지에는 절대 적용하지 마십시오. Aspose.Slides는 이 플래그를 감지 및 검증하기 위해 제공하여 자동 접근성 검증 및 정리를 가능하게 합니다.

![장식으로 표시](mark_as_decorative.png)

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Is shape decorative: " . ($shape->isDecorative() ? "true" : "false") . "\n";
} finally {
    $presentation->dispose();
}
```