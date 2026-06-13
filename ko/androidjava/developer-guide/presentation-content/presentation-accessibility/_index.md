---
title: Android에서 프레젠테이션 접근성 관리
linktitle: 프레젠테이션 접근성
type: docs
weight: 30
url: /ko/androidjava/presentation-accessibility/
keywords:
- 프레젠테이션 접근성
- 장식용으로 표시
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 Java로 사용하여 PPT, PPTX 및 ODP 파일에서 프레젠테이션 접근성 검사를 자동화하는 방법을 알아보세요—스크린 리더 경험을 향상하고 준수성을 높입니다."
---
## **개요**

프레젠테이션 접근성은 화면 읽기 프로그램, 점자 디스플레이, 또는 키보드 전용 탐색과 같은 보조 기술을 사용하는 사람들이 시각이 정상이고 마우스를 사용하는 청중만큼 슬라이드를 이해하고 탐색할 수 있도록 보장합니다. 좋은 실천 방법은 명확한 읽기 순서, 유익한 시각 자료에 대한 의미 있는 대체 텍스트, 충분한 색상 대비, 가독성 높은 타이포그래피, 설명적인 링크 텍스트, 그리고 색상이나 위치만으로 의미를 전달하지 않는 것을 중점으로 합니다. 접근성을 처음부터 계획하면 구조가 더 깔끔해지고 시각 요소가 더 일관되며, 모든 사용자가 별도의 우회 방법 없이 콘텐츠에 접근할 수 있습니다.

## **장식용으로 표시**

장식용으로 표시 플래그는 순수히 장식적인 시각 요소에 지정하여 화면 읽기 프로그램이 이를 건너뛰게 함으로써 잡음을 줄이고 의미 있는 콘텐츠에 집중할 수 있게 합니다. 배경, 장식 요소 및 간격용 이미지 등에 적용하고, 차트, 아이콘 또는 정보를 전달하는 이미지에는 절대 사용하지 마세요. Aspose.Slides는 이 플래그를 감지하고 검증할 수 있도록 노출하며, 자동화된 접근성 검사와 정리를 가능하게 합니다.

![장식용](mark_as_decorative.png)

다음 코드 샘플은 도형이 장식용으로 표시되었는지 확인하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```