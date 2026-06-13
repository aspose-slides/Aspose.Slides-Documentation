---
title: C++에서 프레젠테이션에 사각형 추가
linktitle: 사각형
type: docs
weight: 80
url: /ko/cpp/rectangle/
keywords:
- 사각형 추가
- 사각형 만들기
- 사각형 도형
- 간단한 사각형
- 서식이 지정된 사각형
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 사각형을 추가함으로써 PowerPoint 프레젠테이션을 강화하고, 프로그래밍 방식으로 도형을 손쉽게 디자인하고 수정할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 사각형 도형을 추가하는 방법을 보여줍니다. 간단한 사각형 만들기, 서식이 지정된 사각형 만들기, 그리고 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 과정을 포함합니다.

## **간단한 사각형 만들기**
이전 항목들과 마찬가지로 이번에도 도형 추가에 대해 다루며, 여기서는 사각형(Rectangle) 도형을 설명합니다. 이 항목에서는 개발자가 Aspose.Slides for C++를 사용하여 슬라이드에 간단하거나 서식이 지정된 사각형을 추가하는 방법을 설명합니다. 프레젠테이션의 선택된 슬라이드에 간단한 사각형을 추가하려면 아래 단계대로 진행하십시오.

1. [Presentation class](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)의 인스턴스를 생성합니다.  
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.  
3. IShapes 객체가 제공하는 AddAutoShape 메서드를 사용해 Rectangle 유형의 IAutoShape을 추가합니다.  
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 간단한 사각형을 추가했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **서식이 지정된 사각형 만들기**
슬라이드에 서식이 지정된 사각형을 추가하려면 아래 단계대로 진행하십시오.

1. [Presentation class](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)의 인스턴스를 생성합니다.  
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.  
3. IShapes 객체가 제공하는 AddAutoShape 메서드를 사용해 Rectangle 유형의 IAutoShape을 추가합니다.  
4. 사각형의 채우기 유형을 Solid(실선)으로 설정합니다.  
5. IShape 객체에 연결된 FillFormat 개체가 제공하는 SolidFillColor.Color 속성을 사용해 사각형의 색상을 설정합니다.  
6. 사각형 선의 색상을 설정합니다.  
7. 사각형 선의 두께를 설정합니다.  
8. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  
위 단계는 아래 예제에서 구현되었습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**모서리가 둥근 사각형을 추가하려면 어떻게 해야 하나요?**

둥근 모서리 [shape type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapetype/)을 사용하고 도형 속성에서 코너 반경을 조정합니다; 기하학적 조정을 통해 각 코너마다 개별적으로 라운딩을 적용할 수도 있습니다.

**이미지(텍스처)로 사각형을 채우려면 어떻게 해야 하나요?**

픽처 [fill type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/filltype/)을 선택하고 이미지 소스를 제공한 뒤, [stretching/tiling modes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/picturefillmode/)를 구성합니다.

**사각형에 그림자와 광원을 추가할 수 있나요?**

예. [Outer/inner shadow, glow, and soft edges](/slides/ko/cpp/shape-effect/)를 사용할 수 있으며 파라미터를 조정할 수 있습니다.

**사각형을 하이퍼링크가 있는 버튼으로 만들 수 있나요?**

예. 도형 클릭 시 슬라이드, 파일, 웹 주소 또는 이메일로 이동하도록 [Assign a hyperlink](/slides/ko/cpp/manage-hyperlinks/)을 지정합니다.

**사각형이 이동하거나 변경되는 것을 방지하려면 어떻게 해야 하나요?**

[Use shape locks](/slides/ko/cpp/applying-protection-to-presentation/)를 사용하면 이동, 크기 조정, 선택 또는 텍스트 편집을 금지하여 레이아웃을 보호할 수 있습니다.

**사각형을 래스터 이미지나 SVG로 변환할 수 있나요?**

예. 지정된 크기/비율로 이미지를 생성하기 위해 [render the shape](http://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getimage/)을 호출하거나, 벡터용으로 [export it as SVG](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/writeassvg/)할 수 있습니다.

**테마와 상속을 고려한 사각형의 실제(효과적) 속성을 빠르게 가져오려면 어떻게 해야 하나요?**

[Use the shape’s effective properties](/slides/ko/cpp/shape-effective-properties/)를 이용하면 API가 테마 스타일, 레이아웃 및 로컬 설정을 반영한 계산된 값을 반환하므로 서식 분석이 간편해집니다.