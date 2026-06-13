---
title: C++ 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/cpp/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 거듭제곱 추세선
- 맞춤 추세선
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 차트에 추세선을 빠르게 추가하고 사용자 지정하는 실용적인 가이드 — 청중을 사로잡으세요."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 만드는 방법, 차트 시리즈에 추세선을 추가하는 방법 및 지수, 선형, 로그, 이동 평균, 다항식 및 거듭제곱 등 다양한 추세선 유형을 활용하는 방법을 보여줍니다.

또한 선 모양을 삽입하여 차트에 사용자 지정 선을 추가하는 방법을 설명하고, 앞뒤 추세선 투영값 및 PDF 또는 SVG로 내보내거나 차트를 이미지로 렌더링할 때 추세선이 유지되는지에 대한 짧은 FAQ를 포함합니다.

## **추세선 추가**
Aspose.Slides for C++는 다양한 차트 추세선을 관리하기 위한 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. 기본 데이터와 원하는 유형 중 하나를 사용하여 차트를 추가합니다(이 예에서는 ChartType.ClusteredColumn을 사용합니다).
4. 차트 시리즈 1에 대한 지수 추세선을 추가합니다.
5. 차트 시리즈 1에 대한 선형 추세선을 추가합니다.
6. 차트 시리즈 2에 대한 로그 추세선을 추가합니다.
7. 차트 시리즈 2에 대한 이동 평균 추세선을 추가합니다.
8. 차트 시리즈 3에 대한 다항식 추세선을 추가합니다.
9. 차트 시리즈 3에 대한 거듭제곱 추세선을 추가합니다.
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 추세선이 포함된 차트를 만드는 예시입니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **사용자 지정 선 추가**
Aspose.Slides for C++는 차트에 사용자 지정 선을 추가하기 위한 간단한 API를 제공합니다. 프레젠테이션의 선택된 슬라이드에 단순한 직선 선을 추가하려면 다음 단계에 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- Shapes 객체가 제공하는 AddChart 메서드를 사용하여 새 차트를 생성합니다.
- Shapes 객체가 제공하는 AddAutoShape 메서드를 사용하여 선 유형의 AutoShape를 추가합니다.
- 도형 선의 색상을 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 사용자 지정 선이 포함된 차트를 만드는 예시입니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**추세선에서 'forward'와 'backward'는 무엇을 의미합니까?**

앞뒤 추세선은 앞쪽/뒤쪽으로 투영된 추세선의 길이를 의미합니다. 산점도(XY) 차트에서는 축 단위로, 비산점도 차트에서는 카테고리 수로 표시됩니다. 음수 값은 허용되지 않습니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 유지됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/ko/cpp/render-a-slide-as-an-svg-image/) 로 변환하고 차트를 이미지로 렌더링합니다. 차트의 일부인 추세선은 이러한 작업 중에 유지됩니다. 차트 자체의 이미지를 [내보내는](/slides/ko/cpp/create-shape-thumbnails/) 메서드도 제공됩니다.