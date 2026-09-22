---
title: Python에서 프레젠테이션 뷰 속성 검색 및 업데이트
linktitle: 뷰 속성
type: docs
weight: 80
url: /ko/python-net/presentation-view-properties/
keywords: 
- 뷰 속성
- 일반 보기
- 개요 콘텐츠
- 개요 아이콘
- 수직 스플리터 스냅
- 단일 보기
- 바 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET의 뷰 속성을 사용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 지정하고 레이아웃, 확대/축소 수준 및 표시 설정을 조정하세요."
---
## **소개**

일반 보기(normal view)는 세 개의 콘텐츠 영역으로 구성됩니다: 슬라이드 자체, 측면 콘텐츠 영역, 그리고 하단 콘텐츠 영역. 다양한 콘텐츠 영역의 위치와 관련된 속성들입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하여, 파일을 다시 열었을 때 프레젠테이션이 마지막으로 저장된 시점과 동일한 상태로 표시되게 합니다.

Property [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/normal_view_properties/)가 추가되어 프레젠테이션의 일반 보기 속성에 접근할 수 있게 되었습니다.  

[NormalViewProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/normalviewrestoredproperties/) 클래스와 그 파생 클래스, [SplitterBarStateType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/splitterbarstatetype/) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

Property **ShowOutlineIcons**은 일반 보기 모드의 어느 콘텐츠 영역에서 개요 콘텐츠를 표시할 때 아이콘을 보여줄지 여부를 지정합니다.

Property **SnapVerticalSplitter**는 측면 영역이 충분히 작아졌을 때 수직 스플리터가 최소화 상태로 스냅될지 여부를 지정합니다.

Property **PreferSingleView**는 사용자가 세 개의 콘텐츠 영역을 갖는 표준 일반 보기 대신 전체 창에 단일 콘텐츠 영역을 표시하는 것을 선호하는지 여부를 지정합니다. 이 옵션이 활성화되면 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

Property **VerticalBarState** 및 **HorizontalBarState**는 수평 또는 수직 스플리터 바가 어떤 상태로 표시되어야 하는지를 지정합니다. 수평 스플리터 바는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 스플리터 바는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized**, **SplitterBarStateType.Restored** 입니다.

Property **RestoredLeft**와 **RestoredTop**은 **VerticalBarState**와 **HorizontalBarState**에 **SplitterBarStateType.Restored** 값이 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

일반 보기에서 슬라이드 영역( RestoredTop의 자식이면 너비, RestoredLeft의 자식이면 높이)의 크기를 지정합니다. 이 영역은 가변 복원 크기(최소화도 아니고 최대화도 아닌)일 때 적용됩니다.

Property **DimensionSize**는 슬라이드 영역의 크기( restoredTop의 자식이면 너비, restoredLeft의 자식이면 높이)를 지정합니다.

Property **AutoAdjust**는 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새 크기에 맞게 자동으로 보정될지 여부를 지정합니다.

아래 예제에서는 프레젠테이션에 대한 **ViewProperties.NormalViewProperties** 속성에 어떻게 접근하는지 보여줍니다.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # 프레젠테이션의 뷰 속성을 복원합니다
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **기본 확대/축소 값 설정**

Aspose.Slides for Python via .NET은 이제 프레젠테이션을 열 때 이미 확대/축소 비율이 설정된 상태가 되도록 기본 확대/축소 값을 지정할 수 있습니다. 이는 프레젠테이션의 [view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)를 설정함으로써 수행할 수 있습니다. 슬라이드 보기 속성뿐 아니라 [notes_view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/notes_view_properties/)도 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 Aspose.Slides에서 프레젠테이션의 View Properties를 설정하는 방법을 예제로 보여줍니다.

뷰 속성을 설정하려면 다음 단계를 따르세요.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션의 [view properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/)를 설정합니다.
3. 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 슬라이드 보기와 노트 보기 모두에 확대 비율을 설정했습니다.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # 프레젠테이션의 뷰 속성을 설정합니다
    presentation.view_properties.slide_view_properties.scale = 100 # 슬라이드 보기의 확대 비율(백분율)
    presentation.view_properties.notes_view_properties.scale = 100 # 노트 보기의 확대 비율(백분율)

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **그리드 간격 설정**

[Presentation.view_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)를 사용하여 프레젠테이션 전체에 적용되는 보기 설정에 접근합니다. [ViewProperties.grid_spacing](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/grid_spacing/) 속성을 통해 기본 편집 그리드의 간격을 읽거나 변경할 수 있습니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 그리드 간격은 포인트 단위이며, 72포인트가 1인치에 해당합니다. API 문서에서 요구하는 대로 양수를 사용하세요.

다음 예제는 기존 `demo.pptx` 파일을 열어 현재 그리드 간격을 출력하고, 1/4인치 간격으로 설정한 뒤 결과를 저장합니다.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

그리드는 [drawing guides](/slides/ko/python-net/drawing-guides/)와 다릅니다. 그리드 간격은 규칙적인 간격을 제어하는 반면, 드로잉 가이드는 개별적으로 배치된 가로 또는 세로 정렬선입니다. 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변하지 않습니다.

그리드와 드로잉 가이드는 모두 편집 보조 도구이며 PDF, 이미지, SVG 또는 슬라이드 쇼에 슬라이드 콘텐츠로 렌더링되지 않습니다. 그리드 간격을 저장해도 편집기가 그리드를 표시한다는 보장은 없으며, 가시성은 뷰어 또는 편집기의 설정에 따라 달라집니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 보이지 않는 이유는?**

파일에 그리드 간격이 저장되지만, 편집기가 그리드를 표시할지는 별도로 제어합니다. 편집기의 그리드 가시성 설정을 확인하세요.

**드로잉 가이드를 삭제하면 그리드 간격이 변경되나요?**

아니요. 드로잉 가이드와 그리드 간격은 독립적인 설정입니다. 가이드를 삭제해도 저장된 그리드 간격은 그대로 유지됩니다.

**프레젠테이션의 서로 다른 섹션에 대해 별도 뷰 설정을 할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)은 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/slide_view_properties/))에서 정의되며, 섹션별로 정의되지 않으므로 문서가 열릴 때 전체 문서에 하나의 매개변수 집합이 적용됩니다.

**다른 사용자를 위해 별도의 뷰 상태를 미리 정의할 수 있나요?**

아니요. 설정은 파일에 저장되며 공유됩니다. 뷰어 애플리케이션이 사용자 환경설정을 반영할 수는 있지만, 파일 자체에는 하나의 뷰 속성 집합만 포함됩니다.

**새 프레젠테이션이 동일한 방식으로 열리도록 미리 정의된 View Properties가 포함된 템플릿을 만들 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/view_properties/)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들 때 동일한 초기 뷰 구성을 적용할 수 있습니다.