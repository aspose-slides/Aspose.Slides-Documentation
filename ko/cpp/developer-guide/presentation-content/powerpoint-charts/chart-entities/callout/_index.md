---
title: C++를 사용한 프레젠테이션 차트의 콜아웃 관리
linktitle: 콜아웃
type: docs
url: /ko/cpp/callout/
keywords:
- 차트 콜아웃
- 콜아웃 사용
- 데이터 레이블
- 레이블 형식
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 간결한 코드 예제와 함께 콜아웃을 만들고 스타일링하며, PPT 및 PPTX와 호환되어 프레젠테이션 워크플로를 자동화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 데이터 레이블에 대한 콜아웃을 사용하는 방법을 설명합니다. `set_ShowLabelAsDataCallout` 메서드를 사용하여 레이블을 콜아웃으로 표시하는 방법, 도넛 차트에 대한 콜아웃 관련 레이블 설정을 구성하는 방법, 그리고 프레젠테이션을 PDF, HTML5, SVG 및 래스터 이미지 형식으로 내보낼 때 콜아웃과 그 모양이 보존된다는 점을 설명합니다.

## **콜아웃 사용**

새 속성 **ShowLabelAsDataCallout** 가 **DataLabelFormat** 클래스와 **IDataLabelFormat** 인터페이스에 추가되었습니다. 이 속성은 지정된 차트의 데이터 레이블을 데이터 콜아웃으로 표시할지 데이터 레이블로 표시할지를 결정합니다. 아래 예제에서는 콜아웃을 설정했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **도넛 차트에 콜아웃 설정**

Aspose.Slides for C++는 도넛 차트에 대한 시리즈 데이터 레이블 콜아웃 모양 설정을 지원합니다. 아래 예제가 제공됩니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**프레젠테이션을 PDF, HTML5, SVG 또는 이미지로 변환할 때 콜아웃이 보존되나요?**

예. 콜아웃은 차트 렌더링의 일부이므로 [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/ko/cpp/export-to-html5/), [SVG](/slides/ko/cpp/render-a-slide-as-an-svg-image/), 또는 [래스터 이미지](/slides/ko/cpp/convert-powerpoint-to-png/) 로 내보낼 때 슬라이드 서식과 함께 보존됩니다.

**맞춤 글꼴이 콜아웃에 적용되며, 내보낼 때 모양이 보존될 수 있나요?**

예. Aspose.Slides는 프레젠테이션에 [글꼴 임베딩](/slides/ko/cpp/embedded-font/)을 지원하며, [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/)와 같은 내보내기 시 글꼴 임베딩을 제어하여 콜아웃이 다양한 시스템에서 동일하게 표시되도록 합니다.