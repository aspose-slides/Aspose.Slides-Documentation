---
title: C++에서 프레젠테이션에 타원 추가
linktitle: 타원
type: docs
weight: 30
url: /ko/cpp/ellipse/
keywords:
- 타원
- 도형
- 타원 추가
- 타원 만들기
- 타원 그리기
- 서식 있는 타원
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PPT 및 PPTX 프레젠테이션에서 타원 도형을 만들고, 서식 지정하고, 조작하는 방법을 배웁니다 — C++ 코드 예제가 포함됩니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 타원 모양을 추가하는 방법을 보여줍니다. 간단한 타원 만들기, 서식이 지정된 타원 만들기, 그리고 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 과정을 다룹니다. 또한 타원 위치 및 크기 작업, 쌓기 순서 제어, 애니메이션 효과 적용과 같은 관련 질문도 간략히 언급합니다.

## **타원 만들기**
이 항목에서는 개발자에게 Aspose.Slides for C++를 사용하여 슬라이드에 타원 모양을 추가하는 방법을 소개합니다. Aspose.Slides for C++는 몇 줄의 코드만으로 다양한 형태의 도형을 그릴 수 있는 쉬운 API 세트를 제공합니다. 프레젠테이션의 선택된 슬라이드에 간단한 타원을 추가하려면 아래 단계를 따르세요:

1. [Presentation class](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)의 인스턴스를 생성합니다
1. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다
1. IShapes 객체가 제공하는 AddAutoShape 메서드를 사용해 Ellipse 타입의 AutoShape을 추가합니다
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다

아래 예제에서는 첫 번째 슬라이드에 타원을 추가했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **서식이 지정된 타원 만들기**
슬라이드에 서식이 지정된 타원을 추가하려면 아래 단계를 따르세요:

1. [Presentation class](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
1. IShapes 객체가 제공하는 AddAutoShape 메서드를 사용해 Ellipse 타입의 AutoShape을 추가합니다.
1. FillFormat 객체를 통해 Ellipse의 Fill Type을 Solid로 설정합니다.
1. FillFormat 객체의 SolidFillColor.Color 속성을 사용해 Ellipse의 색상을 설정합니다.
1. Ellipse의 선 색상을 설정합니다.
1. Ellipse 선의 너비를 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 서식이 지정된 타원을 추가했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **FAQ**

**슬라이드 단위에 대해 타원의 정확한 위치와 크기를 어떻게 지정합니까?**

좌표와 크기는 일반적으로 **포인트** 단위로 지정합니다. 예측 가능한 결과를 위해 슬라이드 크기를 기준으로 계산하고, 필요한 밀리미터나 인치를 포인트로 변환한 뒤 값을 할당하세요.

**타원을 다른 객체 위 또는 아래에 배치하려면 (쌓기 순서 제어) 어떻게 합니까?**

객체의 그리기 순서를 앞쪽으로 가져오거나 뒤쪽으로 보내어 순서를 조정합니다. 이렇게 하면 타원이 다른 객체와 겹치거나 그 아래에 있는 객체를 드러낼 수 있습니다.

**타원의 등장 또는 강조에 애니메이션을 적용하려면 어떻게 합니까?**

[Apply](/slides/ko/cpp/shape-animation/) 입장, 강조 또는 퇴장 효과를 도형에 적용하고, 트리거와 타이밍을 구성하여 애니메이션이 언제 어떻게 재생될지 지정합니다.