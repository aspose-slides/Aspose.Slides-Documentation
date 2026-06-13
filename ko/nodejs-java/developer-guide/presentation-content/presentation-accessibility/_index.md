---
title: JavaScript에서 프리젠테이션 접근성 관리
linktitle: 프리젠테이션 접근성
type: docs
weight: 30
url: /ko/nodejs-java/presentation-accessibility/
keywords:
- 프리젠테이션 접근성
- 장식용으로 표시
- PowerPoint
- OpenDocument
- 프리젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 PPT, PPTX 및 ODP 파일의 프리젠테이션 접근성 검사를 자동화하고 화면 읽기 프로그램 경험을 개선하며 규정 준수를 높입니다."
---
## **개요**

프리젠테이션 접근성은 화면 읽기 프로그램, 점자 디스플레이, 키보드 전용 탐색과 같은 보조 기술을 사용하는 사람들이 시각이 정상이고 마우스를 사용하는 관객만큼 슬라이드를 이해하고 탐색할 수 있도록 보장합니다. 좋은 실천 방법은 명확한 읽기 순서, 정보 시각 자료에 대한 의미 있는 대체 텍스트, 충분한 색상 대비, 읽기 쉬운 타이포그래피, 설명적인 링크 텍스트, 그리고 색상이나 위치만으로 의미를 전달하지 않는 것에 중점을 둡니다. 접근성을 처음부터 계획하면 구조가 더 깔끔해지고 시각적 일관성이 높아지며, 별도의 우회 조치 없이 모든 시청자에게 도달하는 콘텐츠가 만들어집니다.

## **장식용으로 표시**

‘장식용으로 표시’ 플래그는 순수히 장식적인 시각 요소에 지정되어 화면 읽기 프로그램이 이를 건너뛰게 함으로써 잡음을 줄이고 의미 있는 콘텐츠에 집중하도록 합니다. 배경, 장식 요소, 간격을 만드는 요소 등에 적용하고, 차트, 아이콘 또는 정보를 전달하는 이미지에는 절대 적용하지 마십시오. Aspose.Slides는 이 플래그를 감지하고 검증할 수 있도록 제공하여 자동 접근성 검사와 정리를 가능하게 합니다.

![장식용으로 표시](mark_as_decorative.png)

다음 코드 샘플은 도형이 장식용으로 표시되었는지 확인하는 방법을 보여줍니다.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```