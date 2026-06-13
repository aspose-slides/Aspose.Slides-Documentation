---
title: Python에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/python-net/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 콘텐츠
- 개요 아이콘
- 수직 분할 막대 스냅
- 단일 보기
- 바 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 맞춤 설정하고 레이아웃, 확대/축소 수준 및 표시 설정을 조정하세요."
---
## **소개**

일반 보기는 세 개의 콘텐츠 영역으로 구성됩니다: 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역. 이러한 다양한 콘텐츠 영역의 위치와 관련된 속성은 애플리케이션이 보기 상태를 파일에 저장하도록 하며, 파일을 다시 열 때 프레젠테이션이 마지막으로 저장된 상태와 동일한 뷰가 유지됩니다.

속성 [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/normal_view_properties/)가 추가되어 프레젠테이션의 일반 보기 속성에 접근할 수 있습니다.

[NormalViewProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/normalviewrestoredproperties/) 클래스와 그 파생 클래스, [SplitterBarStateType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/splitterbarstatetype/) 열거형이 추가되었습니다.

## **INormalViewProperties에 대해** 

일반 보기 속성을 나타냅니다.

속성 **ShowOutlineIcons**는 일반 보기 모드의 콘텐츠 영역 중 어느 곳에서든 개요 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

속성 **SnapVerticalSplitter**는 측면 영역이 충분히 작아질 때 수직 분할 막대를 최소화된 상태로 고정할지 여부를 지정합니다.

속성 **PreferSingleView**는 사용자가 세 개의 콘텐츠 영역이 있는 표준 일반 보기보다 전체 창을 차지하는 단일 콘텐츠 영역을 선호하는지 여부를 지정합니다. 이 옵션이 활성화되면 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

속성 **VerticalBarState**와 **HorizontalBarState**는 수평 또는 수직 분할 막대가 표시될 상태를 지정합니다. 수평 분할 막대는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** 및 **SplitterBarStateType.Restored**입니다.

속성 **RestoredLeft**와 **RestoredTop**은 **VerticalBarState**와 **HorizontalBarState**에 각각 **SplitterBarStateType.Restored** 값이 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역 크기를 지정합니다.

## **INormalViewProperties 복원에 대해** 

슬라이드 영역( RestoredTop의 자식인 경우 너비, RestoredLeft의 자식인 경우 높이)의 크기를 지정합니다. 이 영역은 가변 복원 크기(최소화도 아니고 최대화도 아님)일 때 적용됩니다.

속성 **DimensionSize**는 슬라이드 영역의 크기( restoredTop의 자식인 경우 너비, restoredLeft의 자식인 경우 높이)를 지정합니다.

속성 **AutoAdjust**는 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새 크기에 맞게 보정될지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대해 **ViewProperties.NormalViewProperties** 속성에 어떻게 접근하는지 보여줍니다.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # 프레젠테이션의 보기 속성을 복원합니다
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **기본 확대/축소 값 설정**

Aspose.Slides for Python via .NET은 이제 프레젠테이션을 열 때 이미 확대/축소가 설정된 상태가 되도록 기본 확대/축소 값을 지정하는 기능을 지원합니다. 이는 프레젠테이션의 [view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)를 설정함으로써 수행할 수 있습니다. 슬라이드 보기 속성뿐만 아니라 [notes_view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/notes_view_properties/)도 프로그래밍 방식으로 설정할 수 있습니다. 이번 항목에서는 Aspose.Slides에서 프레젠테이션의 보기 속성을 설정하는 방법을 예제로 살펴보겠습니다.

보기 속성을 설정하려면 아래 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다
1. 프레젠테이션의 [view properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/)를 설정합니다
1. 프레젠테이션을 PPTX 파일로 저장합니다

아래 예제에서는 슬라이드 보기와 노트 보기 모두에 확대/축소 값을 설정했습니다.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 프레젠테이션의 보기 속성을 설정합니다
    presentation.view_properties.slide_view_properties.scale = 100 # 슬라이드 보기의 확대/축소 값(백분율)
    presentation.view_properties.notes_view_properties.scale = 100 # 노트 보기의 확대/축소 값(백분율)

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**프레젠테이션의 서로 다른 섹션에 대해 다른 보기 설정을 지정할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)은 프레젠테이션 수준에서 정의되며([Normal View](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/slide_view_properties/)), 섹션별이 아닙니다. 따라서 하나의 매개 변수 집합이 문서 전체에 적용됩니다.

**다른 사용자에게 서로 다른 보기 상태를 미리 정의할 수 있나요?**

없습니다. 설정은 파일에 저장되며 공유됩니다. 뷰어 애플리케이션이 사용자 선호도를 반영할 수는 있지만 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**새 프레젠테이션이 동일한 방식으로 열리도록 미리 정의된 View Properties를 포함한 템플릿을 만들 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들 때 동일한 초기 보기 구성을 적용할 수 있습니다.