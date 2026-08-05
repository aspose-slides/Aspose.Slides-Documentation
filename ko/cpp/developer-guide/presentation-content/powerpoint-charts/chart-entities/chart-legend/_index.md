---
title: C++를 사용하여 프레젠테이션에서 차트 범례 사용자 지정
linktitle: 차트 범례
type: docs
url: /ko/cpp/chart-legend/
keywords:
- 차트 범례
- 범례 위치
- 글꼴 크기
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: Aspose.Slides for C++를 사용해 차트 범례를 맞춤 설정하여 PowerPoint 프레젠테이션을 최적화합니다.
---
## **개요**

Aspose.Slides는 PowerPoint 프레젠테이션에서 차트 범례를 사용자 지정할 수 있는 옵션을 제공합니다. 이 문서에서는 범례의 위치와 크기를 지정하고, 전체 범례의 글꼴 크기를 설정하며, 개별 범례 항목에 서식을 적용하는 방법을 보여줍니다.

FAQ에서는 비오버레이 모드를 사용하여 플롯 영역이 범례를 위해 공간을 확보하도록 하는 방법, 긴 범례 레이블을 자동으로 줄 바꿈하거나 강제 줄 바꿈을 허용하는 방법, 그리고 명시적인 텍스트와 채우기 설정을 적용하지 않을 경우 범례 서식이 프레젠테이션 테마에서 상속되도록 하는 여러 관련 동작도 다룹니다.

## **범례 위치 지정**
범례 속성을 설정하려면 아래 단계를 따르세요:

- [Presentation] 클래스의 인스턴스를 생성합니다.
- 슬라이드의 참조를 가져옵니다.
- 슬라이드에 차트를 추가합니다.
- 범례의 속성을 설정합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **범례의 글꼴 크기 설정**
Aspose.Slides for C++를 사용하면 개발자가 범례의 글꼴 크기를 설정할 수 있습니다. 아래 단계를 따르세요.

- Presentation 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 글꼴 크기를 설정합니다.
- 축 최소값을 설정합니다.
- 축 최대값을 설정합니다.
- 프레젠테이션을 디스크에 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **개별 범례 항목의 글꼴 크기 설정**
Aspose.Slides for C++를 사용하면 개발자가 개별 범례 항목의 글꼴 크기를 설정할 수 있습니다. 아래 단계를 따르세요.

- Presentation 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 범례 항목에 액세스합니다.
- 글꼴 크기를 설정합니다.
- 축 최소값을 설정합니다.
- 축 최대값을 설정합니다.
- 프레젠테이션을 디스크에 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**범례를 활성화하여 차트가 자동으로 범례를 위한 공간을 할당하고 겹치지 않게 할 수 있나요?**

예. 비오버레이 모드([set_Overlay(false)](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/legend/set_overlay/))를 사용합니다. 이 경우 플롯 영역이 축소되어 범례를 수용합니다.

**다중 라인 범례 레이블을 만들 수 있나요?**

예. 공간이 부족할 경우 긴 레이블은 자동으로 줄 바꿈됩니다; 시리즈 이름에 줄 바꿈 문자를 넣어 강제 줄 바꿈도 지원됩니다.

**범례가 프레젠테이션 테마의 색 구성표를 따르게 하려면 어떻게 해야 하나요?**

범례나 텍스트에 명시적인 색상/채우기/글꼴을 설정하지 마세요. 이렇게 하면 테마에서 상속받아 디자인이 변경될 때 올바르게 업데이트됩니다.