---
title: C++에서 프레젠테이션 접근성 관리
linktitle: 프레젠테이션 접근성
type: docs
weight: 30
url: /ko/cpp/presentation-accessibility/
keywords:
- 프레젠테이션 접근성
- 장식용으로 표시
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++가 PPT, PPTX 및 ODP 파일에서 프레젠테이션 접근성 검사를 자동화하는 방법을 알아보세요—스크린 리더 경험을 향상하고 호환성을 높입니다."
---
## **Overview**

프레젠테이션 접근성은 스크린 리더, 점자 디스플레이, 키보드 전용 탐색과 같은 보조 기술을 사용하는 사람들이 시각이 있는 마우스를 사용하는 청중만큼 슬라이드를 이해하고 탐색할 수 있도록 보장합니다. 좋은 실천은 명확한 읽기 순서, 유익한 시각 자료에 대한 의미 있는 대체 텍스트, 충분한 색상 대비, 읽기 쉬운 타이포그래피, 설명적인 링크 텍스트, 그리고 색상이나 위치만으로 의미를 전달하는 것을 피하는 데 중점을 둡니다. 접근성을 처음부터 계획하면 더 깔끔한 구조, 일관된 시각 자료, 그리고 별도의 우회 방법 없이 모든 시청자에게 도달하는 콘텐츠를 얻을 수 있습니다.

## **Mark as Decorative**

‘장식용으로 표시’는 순수하게 장식적인 시각 요소에 플래그를 지정하여 스크린 리더가 이를 건너뛰게 함으로써 잡음을 줄이고 의미 있는 콘텐츠에 집중하도록 합니다. 배경, 장식, 간격 요소 등에 적용하고 차트, 아이콘, 정보를 전달하는 이미지에는 절대 적용하지 마십시오. Aspose.Slides는 이 플래그를 감지 및 검증할 수 있도록 제공하여 자동 접근성 검사와 정리를 가능하게 합니다.

![Mark as Decorative](mark_as_decorative.png)

다음 코드 샘플은 모양이 장식용으로 표시되었는지 판단하는 방법을 보여줍니다.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```