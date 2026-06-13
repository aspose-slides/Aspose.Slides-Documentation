---
title: C++에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/cpp/presentation-view-properties/
keywords:
- 보기 속성
- 표준 보기
- 개요 콘텐츠
- 개요 아이콘
- 수직 스플리터 스냅
- 단일 보기
- 바 상태
- 차원 크기
- 자동 조정
- 기본 줌
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 보기 속성을 사용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 지정하고 레이아웃, 줌 수준 및 표시 설정을 조정하세요."
---
## **소개**

일반 보기에는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 가지 콘텐츠 영역이 포함됩니다. 다양한 콘텐츠 영역의 위치와 관련된 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하여, 파일을 다시 열 때 프레젠테이션이 마지막으로 저장된 시점과 동일한 상태로 보기가 복원됩니다.

Method [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iviewproperties/get_normalviewproperties/)가 추가되어 프레젠테이션의 일반 보기 속성에 접근할 수 있게 되었습니다.  

[INormalViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inormalviewrestoredproperties/) 인터페이스와 해당 파생 인터페이스, 열거형 [SplitterBarStateType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/splitterbarstatetype/)가 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

속성 **ShowOutlineIcons**는 일반 보기 모드의 콘텐츠 영역 중 하나에 개요 콘텐츠를 표시할 때 애플리케이션이 아이콘을 표시해야 하는지 여부를 지정합니다.

속성 **SnapVerticalSplitter**는 측면 영역이 충분히 작아질 경우 수직 스플리터가 최소화된 상태로 스냅되는지 여부를 지정합니다.

속성 **PreferSingleView**는 사용자가 세 개의 콘텐츠 영역이 있는 표준 일반 보기 대신 전체 창 단일 콘텐츠 영역을 선호하는지 여부를 지정합니다. 활성화된 경우 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

속성 **VerticalBarState**와 **HorizontalBarState**는 수평 또는 수직 스플리터 바가 표시되어야 할 상태를 지정합니다. 수평 스플리터 바는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 스플리터 바는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized**, **SplitterBarStateType.Restored**입니다.

속성 **RestoredLeft**와 **RestoredTop**은 **VerticalBarState**와 **HorizontalBarState**에 각각 **SplitterBarStateType.Restored** 값이 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

일반 보기에서 영역이 가변 복원 크기(최소화되지도 않고 최대화되지도 않음)일 때 슬라이드 영역( RestoredTop의 자식이면 너비, RestoredLeft의 자식이면 높이)의 크기를 지정합니다.

속성 **DimensionSize**는 슬라이드 영역의 크기( RestoredTop의 자식이면 너비, RestoredLeft의 자식이면 높이)를 지정합니다.

속성 **AutoAdjust**는 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새 크기에 맞게 보정되어야 하는지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대해 **ViewProperties.NormalViewProperties** 속성에 어떻게 접근할 수 있는지 보여줍니다.

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// 프레젠테이션의 보기 속성을 복원합니다
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **기본 줌 값 설정**

Aspose.Slides for C++는 이제 프레젠테이션을 열었을 때 이미 줌이 설정된 기본 줌 값을 지정할 수 있도록 지원합니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/)를 설정함으로써 수행할 수 있습니다. 슬라이드 보기 속성 및 [get_NotesViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/get_notesviewproperties/)도 프로그래밍으로 설정할 수 있습니다. 이 항목에서는 예제를 통해 Aspose.Slides에서 프레젠테이션의 보기 속성을 설정하는 방법을 살펴보겠습니다.

보기 속성을 설정하려면 아래 단계에 따라 주세요:

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션의 보기 [Properties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/)를 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 슬라이드 보기와 노트 보기 모두에 대해 줌 값을 설정했습니다.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// 프레젠테이션의 보기 속성을 설정합니다
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // 슬라이드 보기의 줌 값을 백분율로 지정
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // 노트 보기의 줌 값을 백분율로 지정

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Can I set different view settings for different sections of a presentation?**

[View settings](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_viewproperties/)는 프레젠테이션 수준에서 정의되며([Normal View](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), 섹션별이 아니라 전체 문서에 하나의 매개변수 집합이 적용됩니다.

**Can I predefine different view states for different users?**

아니요. 설정은 파일에 저장되어 공유됩니다. 뷰어 애플리케이션이 사용자 환경설정을 반영할 수는 있지만 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**Can I prepare a template with predefined View Properties so new presentations open the same way?**

예. [view properties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_viewproperties/)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새로운 문서를 만들면 동일한 초기 보기 구성을 갖게 할 수 있습니다.