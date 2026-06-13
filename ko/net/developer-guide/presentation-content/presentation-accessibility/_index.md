---
title: .NET에서 프레젠테이션 접근성 관리
linktitle: 프레젠테이션 접근성
type: docs
weight: 30
url: /ko/net/presentation-accessibility/
keywords:
- 프레젠테이션 접근성
- 장식용으로 표시
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PPT, PPTX 및 ODP 파일의 프레젠테이션 접근성 검사를 자동화하고, 스크린 리더 경험을 향상시키며 준수를 강화합니다."
---
## **소개**

프레젠테이션 접근성은 화면 읽기 프로그램, 점자 디스플레이, 키보드 전용 탐색과 같은 보조 기술을 사용하는 사람들이 시각이 있는 마우스를 사용하는 청중만큼 슬라이드를 이해하고 탐색할 수 있도록 보장합니다. 좋은 실천 방법은 명확한 읽기 순서, 유익한 시각 자료에 대한 의미 있는 대체 텍스트, 충분한 색 대비, 읽기 쉬운 타이포그래피, 설명적인 링크 텍스트, 그리고 색상이나 위치만으로 의미를 전달하지 않는 것에 중점을 둡니다. 접근성을 처음부터 계획하면 구조가 더 깔끔해지고 시각 자료가 일관되며, 모든 시청자가 별도의 우회 조치 없이 콘텐츠에 도달할 수 있습니다.

## **장식용으로 표시**

‘장식용으로 표시’ 플래그는 순수히 장식적인 시각 자료에 지정하여 스크린 리더가 이를 건너뛰게 함으로써 잡음을 줄이고 의미 있는 콘텐츠에 집중하도록 합니다. 배경, 장식 요소, 간격을 만드는 요소 등에 적용하고, 차트, 아이콘 또는 정보를 전달하는 이미지에는 절대 사용하지 마십시오. Aspose.Slides는 이 플래그를 감지 및 검증할 수 있도록 제공하여 자동 접근성 검사와 정리를 가능하게 합니다.

![장식용으로 표시](mark_as_decorative.png)

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```