---
title: Python에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/python-net/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 내용
- 개요 아이콘
- 수직 분할기 스냅
- 단일 보기
- 막대 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET 보기 속성을 사용하여 PPT, PPTX 및 ODP 슬라이드의 형식을 사용자 지정하고 레이아웃, 확대/축소 수준 및 표시 설정을 조정하세요."
---
## **소개**

보통 보기(normal view)는 슬라이드 자체와 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 개 영역으로 구성됩니다. 다양한 콘텐츠 영역의 위치에 관한 속성들입니다. 이 정보는 응용 프로그램이 보기 상태를 파일에 저장하도록 하여, 파일을 다시 열었을 때 프레젠테이션이 마지막으로 저장된 상태와 동일한 보기 상태가 유지됩니다.

Property [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/normal_view_properties/)는 프레젠테이션의 보통 보기 속성에 접근하기 위해 추가되었습니다.

[NormalViewProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/normalviewrestoredproperties/) 클래스와 그 파생 클래스들, 그리고 [SplitterBarStateType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/splitterbarstatetype/) 열거형이 추가되었습니다.

## **INormalViewProperties에 대해**

보통 보기 속성을 나타냅니다.

Property **ShowOutlineIcons**는 보통 보기 모드의 어떤 콘텐츠 영역에서 개요 내용을 표시할 때 응용 프로그램이 아이콘을 표시할지 여부를 지정합니다.

Property **SnapVerticalSplitter**는 측면 영역이 충분히 작아졌을 때 수직 분할기가 최소화 상태로 스냅될지 여부를 지정합니다.

Property **PreferSingleView**는 사용자가 세 개의 콘텐츠 영역이 있는 일반 보통 보기 대신 전체 창에 단일 콘텐츠 영역만 표시하는 것을 선호하는지 여부를 지정합니다. 이 옵션이 활성화되면 응용 프로그램은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

Properties **VerticalBarState** 및 **HorizontalBarState**는 수평 또는 수직 분할 막대가 표시될 상태를 지정합니다. 수평 분할 막대는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized**, **SplitterBarStateType.Restored**입니다.

Properties **RestoredLeft** 및 **RestoredTop**은 **VerticalBarState**와 **HorizontalBarState**에 **SplitterBarStateType.Restored** 값이 적용될 때 보통 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대해**

보통 보기에서 영역이 가변 복원 크기(최소화되지도 않고 최대화되지도 않음)일 때 슬라이드 영역의 크기( RestoredTop의 자식이면 너비, RestoredLeft의 자식이면 높이)를 지정합니다.

Property **DimensionSize**는 슬라이드 영역의 크기( restoredTop의 자식이면 너비, restoredLeft의 자식이면 높이)를 지정합니다.

Property **AutoAdjust**는 응용 프로그램 내에서 보기를 포함하는 창의 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 자동으로 조정될지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대한 **ViewProperties.NormalViewProperties** 속성에 어떻게 접근할 수 있는지 보여줍니다.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # 프레젠테이션의 보기 속성을 복원합니다
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **기본 확대/축소 값 설정**

Aspose.Slides for Python via .NET는 이제 프레젠테이션을 열 때 기본 확대/축소 값이 이미 설정되도록 기본 확대/축소 값을 지정할 수 있습니다. 이는 프레젠테이션의 [view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)를 설정함으로써 수행할 수 있습니다. 슬라이드 보기 속성뿐만 아니라 [notes_view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/notes_view_properties/)도 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 예제를 통해 Aspose.Slides에서 프레젠테이션의 보기 속성을 설정하는 방법을 살펴보겠습니다.

보기 속성을 설정하려면 아래 단계에 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다
1. 프레젠테이션의 [view properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/)를 설정합니다
1. 프레젠테이션을 PPTX 파일로 저장합니다

아래 예제에서는 슬라이드 보기와 노트 보기 모두에 확대/축소 값을 설정했습니다.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # 프레젠테이션의 보기 속성을 설정합니다
    presentation.view_properties.slide_view_properties.scale = 100 # 슬라이드 보기의 확대 비율(백분율) 값
    presentation.view_properties.notes_view_properties.scale = 100 # 노트 보기의 확대 비율(백분율) 값

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **그리드 간격 설정**

[Presentation.view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [ViewProperties.grid_spacing](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/grid_spacing/) 속성은 기본 편집 그리드의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 그리드 간격은 포인트 단위이며, 72포인트가 1인치에 해당합니다. API 문서에서 요구하는 대로 양수 값을 사용하십시오.

다음 예제는 기존 `demo.pptx` 파일을 열어 현재 그리드 간격을 출력하고, 1/4인치 간격으로 설정한 뒤 결과를 저장합니다.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

그리드는 [drawing guides](/slides/ko/python-net/drawing-guides/)와 다릅니다. 그리드 간격은 규칙적인 간격을 제어하는 반면, 드로잉 가이드는 개별적으로 배치된 수평 또는 수직 정렬선입니다. 드로잉 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변경되지 않습니다.

그리드와 드로잉 가이드는 모두 편집 보조 도구이며 PDF, 이미지, SVG 또는 슬라이드 쇼에 슬라이드 콘텐츠로 렌더링되지 않습니다. 그리드 간격을 저장한다고 해서 편집기가 그리드를 표시한다는 보장은 없으며, 표시 여부는 뷰어 또는 편집기의 설정에 따라 달라집니다.

## **프레젠테이션 열 때 주석 표시 또는 숨기기**

[Presentation.view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [ViewProperties.show_comments](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/show_comments/)를 읽거나 변경하여 PowerPoint 또는 다른 호환 편집기에서 프레젠테이션을 열 때 주석을 표시할지 여부에 대한 기본 설정을 저장합니다.

이 설정은 저장된 보기 기본 설정만 제어합니다. 주석을 추가, 제거, 편집 또는 해결하지 않으며, 주석을 숨겨도 내용, 작성자, 위치, 답글 및 상태는 유지됩니다. 주석 자체를 변경하는 작업에 대해서는 [Presentation Comments](/slides/ko/python-net/presentation-comments/)를 참조하십시오.

다음 예제는 주석이 포함된 기존 `comments.pptx` 파일이 필요합니다. 현재 가시성 설정을 출력하고, 주석을 숨기도록 요청한 뒤 주석을 제거하지 않은 새로운 PPTX 파일을 저장합니다. 또한 [ViewProperties.last_view](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/last_view/)를 [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewtype/)로 설정하여 초기 편집 보기를 주석 가시성과 함께 구성합니다.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

이 설정은 주석이 PDF, HTML, 이미지, 노트 또는 유인물 내보내기에 포함되는지를 결정하지 않습니다. 관련 내보내기 옵션은 별도로 구성하십시오.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 보이지 않는 이유는 무엇인가요?**

파일에 그리드 간격이 저장되지만 편집기가 그리드를 표시할지는 편집기 설정에 따라 달라집니다. 편집기의 그리드 가시성 설정을 확인하십시오.

**드로잉 가이드를 삭제하면 그리드 간격이 변경됩니까?**

아니요. 드로잉 가이드와 그리드 간격은 독립적인 설정이며, 가이드를 삭제해도 저장된 그리드 간격은 변하지 않습니다.

**프레젠테이션의 서로 다른 섹션에 대해 다른 보기 설정을 지정할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)은 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/slide_view_properties/))에서 정의되며 섹션별로는 지정할 수 없으므로 한 세트의 매개변수가 문서 전체에 적용됩니다.

**다른 사용자에 대해 서로 다른 보기 상태를 미리 정의할 수 있나요?**

아니요. 설정은 파일에 저장되고 공유됩니다. 뷰어 애플리케이션이 사용자 기본 설정을 반영할 수는 있지만 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**새 프레젠테이션이 동일한 방식으로 열리도록 미리 정의된 View Properties가 포함된 템플릿을 만들 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들 때 동일한 초기 보기 구성을 적용할 수 있습니다.