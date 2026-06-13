---
title: C++을 사용한 프레젠테이션에서 슬라이드 전환 관리
linktitle: 슬라이드 전환
type: docs
weight: 80
url: /ko/cpp/slide-transition/
keywords:
- 슬라이드 전환
- 슬라이드 전환 추가
- 슬라이드 전환 적용
- 고급 슬라이드 전환
- Morph 전환
- 전환 유형
- 전환 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 슬라이드 전환을 맞춤 설정하는 방법을 알아보고, PowerPoint 및 OpenDocument 프레젠테이션에 대한 단계별 가이드를 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션에서 슬라이드 전환을 관리하는 방법을 설명합니다. 슬라이드에 전환 유형을 적용하고, 클릭 시 또는 지정된 시간 후에 진행되는 전환 동작을 구성하며, 자동 진행을 확인하고 해제하고, Morph 전환 및 해당 유형을 사용하고, 전환 효과 옵션을 설정하는 방법을 보여줍니다. 예제에서는 프레젠테이션을 로드하거나 생성하고, 선택한 슬라이드의 전환 설정을 수정한 다음 결과를 PPTX 파일로 저장하는 과정을 시연합니다. 또한 전환 속도, 전환 사운드, 여러 슬라이드에 동일한 전환 적용, 현재 슬라이드에 설정된 전환 확인과 같은 일반적인 질문에 답변합니다.

## **슬라이드 전환 추가**
보다 쉽게 이해할 수 있도록 Aspose.Slides for C++를 사용하여 간단한 슬라이드 전환을 관리하는 방법을 시연했습니다. 개발자는 슬라이드에 다양한 전환 효과를 적용할 뿐만 아니라 이러한 전환 효과의 동작을 사용자 지정할 수 있습니다. 간단한 슬라이드 전환 효과를 만들려면 아래 단계를 따르세요.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. Aspose.Slides for C++에서 제공하는 전환 효과 중 하나를 TransitionType 열거형을 통해 선택하여 슬라이드에 슬라이드 전환 유형을 적용합니다.
1. 수정된 프레젠테이션 파일을 기록합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **고급 슬라이드 전환 추가**
위 섹션에서는 간단한 전환 효과만 적용했습니다. 이제 해당 전환 효과를 보다 개선하고 제어하려면 아래 단계를 따르세요.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. Aspose.Slides for C++에서 제공하는 전환 효과 중 하나를 선택하여 슬라이드에 슬라이드 전환 유형을 적용합니다.
1. 전환을 클릭 시 진행(Advance On Click), 지정된 시간 후 진행(Advance After Time) 또는 두 가지 모두로 설정할 수 있습니다.
1. 슬라이드 전환이 클릭 시 진행으로 설정된 경우, 마우스를 클릭해야 전환이 진행됩니다. 또한 Advance After Time 속성이 설정된 경우, 지정된 시간이 경과하면 전환이 자동으로 진행됩니다.
1. 수정된 프레젠테이션을 프레젠테이션 파일로 기록합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Morph 전환**
Aspose.Slides for C++는 이제 Morph 전환을 지원합니다. 이는 PowerPoint 2019에 도입된 새로운 Morph 전환을 구현한 것입니다. Morph 전환을 사용하면 한 슬라이드에서 다음 슬라이드로 부드러운 움직임을 애니메이션화할 수 있습니다. 이 문서에서는 개념과 Morph 전환 사용 방법을 설명합니다. Morph 전환을 효과적으로 사용하려면 최소 하나의 공통 객체가 있는 두 슬라이드가 필요합니다. 가장 쉬운 방법은 슬라이드를 복제한 다음 두 번째 슬라이드에서 객체를 다른 위치로 이동하는 것입니다.

다음 코드 조각은 텍스트가 있는 슬라이드 복제본을 프레젠테이션에 추가하고 두 번째 슬라이드에 Morph 유형 전환을 설정하는 방법을 보여줍니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Morph 전환 유형**
새로운 Aspose.Slides.SlideShow.TransitionMorphType 열거형이 추가되었습니다. 이는 다양한 Morph 슬라이드 전환 유형을 나타냅니다.

TransitionMorphType 열거형에는 세 가지 멤버가 있습니다.

- ByObject: 도형을 분할할 수 없는 개체로 간주하여 Morph 전환이 수행됩니다.
- ByWord: 가능한 경우 단어 단위로 텍스트를 전송하면서 Morph 전환이 수행됩니다.
- ByChar: 가능한 경우 문자 단위로 텍스트를 전송하면서 Morph 전환이 수행됩니다.

다음 코드 조각은 슬라이드에 Morph 전환을 설정하고 Morph 유형을 변경하는 방법을 보여줍니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **전환 효과 설정**
Aspose.Slides for C++는 검은색에서, 왼쪽에서, 오른쪽에서 등과 같은 전환 효과 설정을 지원합니다. 전환 효과를 설정하려면 다음 단계를 따르세요.

- Presentation 클래스의 인스턴스를 생성합니다.
- 슬라이드에 대한 참조를 가져옵니다.
- 전환 효과를 설정합니다.
- 프레젠테이션을 PPTX 파일로 기록합니다.

아래 예제에서는 전환 효과를 설정했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**슬라이드 전환의 재생 속도를 제어할 수 있나요?**

예. 전환의 [speed](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/)을 [TransitionSpeed](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/transitionspeed/) 설정(예: slow/medium/fast)으로 지정합니다.

**전환에 오디오를 첨부하고 반복 재생하도록 할 수 있나요?**

예. 전환에 사운드를 삽입하고 sound mode 및 looping과 같은 설정(예: [set_Sound](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/))을 통해 동작을 제어할 수 있습니다. 또한 [set_SoundIsBuiltIn](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) 및 [set_SoundName](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)과 같은 메타데이터를 사용할 수 있습니다.

**모든 슬라이드에 동일한 전환을 가장 빠르게 적용하려면 어떻게 해야 하나요?**

각 슬라이드의 전환 설정에 원하는 전환 유형을 구성하면 됩니다. 전환은 슬라이드별로 저장되므로 모든 슬라이드에 동일한 유형을 적용하면 일관된 결과를 얻을 수 있습니다.

**현재 슬라이드에 설정된 전환을 어떻게 확인할 수 있나요?**

슬라이드의 [transition settings](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseslide/get_slideshowtransition/)을 검사하고 해당 [transition type](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/slideshowtransition/get_type/)을 읽으면 적용된 효과를 정확히 확인할 수 있습니다.