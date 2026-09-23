---
title: Python via Java에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/python-java/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 콘텐츠
- 개요 아이콘
- 수직 분할기 스냅
- 단일 보기
- 바 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드를 사용자 지정하고—레이아웃, 확대/축소 수준 및 표시 설정을 조정하십시오."
---
## **소개**

일반 보기는 세 개의 콘텐츠 영역으로 구성됩니다: 슬라이드 자체, 측면 콘텐츠 영역, 그리고 하단 콘텐츠 영역. 일반 보기 속성은 이러한 콘텐츠 영역의 위치를 설명합니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하여, 다시 열었을 때 프레젠테이션이 마지막으로 저장된 상태와 동일한 보기 상태가 되도록 합니다.

프레젠테이션의 일반 보기 속성에 접근하기 위해 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getNormalViewProperties) 메소드가 추가되었습니다.

[NormalViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/) , [NormalViewRestoredProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewrestoredproperties/) 클래스와 [SplitterBarStateType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/splitterbarstatetype/) 열거형이 추가되었습니다.

## **NormalViewProperties에 대해**

일반 보기 속성을 나타냅니다.

[getShowOutlineIcons](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) 및 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 메소드는 일반 보기 모드의 어느 콘텐츠 영역에서든 개요 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

[getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) 및 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 메소드는 측면 영역이 충분히 작아질 경우 수직 분할기가 최소화된 상태에 스냅하도록 지정합니다.

[getPreferSingleView](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) 및 [setPreferSingleView](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) 메소드는 사용자가 세 개의 콘텐츠 영역이 있는 표준 일반 보기보다 전체 창에 단일 콘텐츠 영역을 보는 것을 선호하는지 여부를 지정합니다. 활성화된 경우, 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

[getVerticalBarState](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 메소드는 수평 또는 수직 분할 바가 표시될 상태를 지정합니다. 수평 분할 바는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 분할 바는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ko/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ko/python-java/aspose.slides/splitterbarstatetype/#Maximized) 및 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/python-java/aspose.slides/splitterbarstatetype/#Restored)입니다.

[getRestoredLeft](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 및 [getRestoredTop](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 메소드는 각각 [getVerticalBarState](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getVerticalBarState)와 [getHorizontalBarState](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState)에 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/python-java/aspose.slides/splitterbarstatetype/#Restored) 값이 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **NormalViewProperties 복원에 대하여**

해당 영역이 가변 복원 크기(최소화되지도, 최대화되지도 않음)를 가질 때 일반 보기의 슬라이드 영역( [getRestoredTop](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredTop)의 자식인 경우 너비, [getRestoredLeft](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)의 자식인 경우 높이)의 크기를 지정합니다.

[getDimensionSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) 메소드는 슬라이드 영역의 크기( [getRestoredTop](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredTop)의 자식인 경우 너비, [getRestoredLeft](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)의 자식인 경우 높이)를 지정합니다.

[getAutoAdjust](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) 메소드는 애플리케이션 내에서 보기를 포함하는 창의 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정되어야 하는지를 지정합니다.

아래 예제는 프레젠테이션에 대해 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getNormalViewProperties)에 접근하는 방법을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # 프레젠테이션의 보기 속성을 복원합니다.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **기본 확대/축소 값 설정**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java는 프레젠테이션이 열릴 때 이미 적용되는 기본 확대/축소 값을 설정하는 것을 지원합니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/)를 설정함으로써 수행할 수 있습니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getSlideViewProperties)와 [getNotesViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getNotesViewProperties)를 프로그래밍 방식으로 구성할 수 있습니다. 이 항목에서는 Aspose.Slides에서 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)의 [View Properties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/)를 설정하는 방법을 예제로 살펴봅니다.
{{% /alert %}}

보기 속성을 설정하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)의 [View Properties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/)를 설정합니다.
3. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.

아래 예제에서는 슬라이드 보기와 노트 보기 모두에 대한 확대/축소 값을 설정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # 프레젠테이션의 보기 속성을 설정합니다.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # 슬라이드 보기용 확대 비율.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # 노트 보기용 확대 비율.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **그리드 간격 설정**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getViewProperties)를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getGridSpacing) 및 [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#setGridSpacing) 메소드는 기본 편집 그리드의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 그리드 간격은 포인트 단위로 지정되며, 72 포인트가 1인치에 해당합니다. API 문서에서 요구하는 대로 양수 값을 사용하십시오.

다음 예제는 기존 `demo.pptx`를 열고 현재 그리드 간격을 출력한 뒤, 1/4인치 간격으로 설정하고 결과를 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

그리드는 [drawing guides](/slides/ko/python-java/drawing-guides/)와 다릅니다. 그리드 간격은 일정한 간격을 제어하는 반면, 드로잉 가이드는 개별적으로 위치가 지정된 수평 또는 수직 정렬선입니다. 드로잉 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변경되지 않습니다.

그리드와 드로잉 가이드는 모두 편집 보조 도구이며, PDF, 이미지, SVG 또는 슬라이드 쇼에서 슬라이드 콘텐츠로 렌더링되지 않습니다. 그리드 간격을 저장했다고 해서 편집기에서 그리드가 표시된다는 보장은 없으며, 가시성은 뷰어나 편집기의 설정에 따라 달라집니다.

## **프레젠테이션 열 때 댓글 보이기/숨기기**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getViewProperties)를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [ViewProperties.getShowComments](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getShowComments) 및 [ViewProperties.setShowComments](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#setShowComments)를 사용하여 PowerPoint 또는 기타 호환 편집기에서 프레젠테이션을 열 때 댓글을 표시할지 여부에 대한 저장된 기본 설정을 읽거나 변경합니다.

이 설정은 저장된 보기 기본 설정만 제어하며, 댓글을 추가, 삭제, 편집 또는 해결하지는 않습니다. 댓글을 숨기면 내용, 작성자, 위치, 답글 및 상태가 유지됩니다. 댓글 자체를 변경하는 작업에 대해서는 [Presentation Comments](/slides/ko/python-java/presentation-comments/)를 참고하십시오.

다음 예제는 댓글이 포함된 기존 `comments.pptx`가 필요합니다. 현재 가시성 설정을 출력하고, 댓글을 숨기도록 요청한 뒤, 댓글을 제거하지 않은 새로운 PPTX를 저장합니다. 또한 [ViewProperties.setLastView](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#setLastView)와 [ViewType.SlideView](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewtype/#SlideView)를 사용하여 댓글 가시성와 함께 초기 편집 보기를 구성합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 설정은 PDF, HTML, 이미지, 노트 또는 유인물 내보내기에 댓글이 포함되는지를 결정하지 않습니다. 관련 내보내기 별 옵션을 별도로 구성하십시오.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 보이지 않는 이유는 무엇인가요?**

파일에는 그리드 간격이 저장되지만, 그리드를 표시할지는 편집기가 제어합니다. 편집기의 그리드 표시 설정을 확인하십시오.

**드로잉 가이드를 삭제하면 그리드 간격이 변경되나요?**

아니요. 드로잉 가이드와 그리드 간격은 독립적인 설정입니다. 가이드를 삭제해도 저장된 그리드 간격은 변경되지 않습니다.

**프레젠테이션의 서로 다른 섹션에 대해 다른 보기 설정을 지정할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getViewProperties)은 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getSlideViewProperties))에서 정의되며 섹션별이 아니라 문서가 열릴 때 전체 문서에 하나의 파라미터 집합이 적용됩니다.

**다른 사용자에 대해 서로 다른 보기 상태를 미리 정의할 수 있나요?**

아니요. 설정은 파일에 저장되어 공유됩니다. 뷰어 애플리케이션이 사용자 선호도를 반영할 수는 있지만 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**미리 정의된 View Properties가 포함된 템플릿을 준비하여 새로운 프레젠테이션이 동일한 방식으로 열리게 할 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getViewProperties)가 프레젠테이션 수준에 저장되므로, 템플릿에 이를 포함시켜 새 문서를 만들면 동일한 초기 보기 구성을 사용할 수 있습니다.