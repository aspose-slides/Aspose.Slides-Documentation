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
- 수직 스플리터 스냅
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
description: "Python via Java용 Aspose.Slides의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드를 맞춤 설정하고 레이아웃, 확대 수준 및 표시 설정을 조정하세요."
---
## **소개**

일반 보기에는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 개 콘텐츠 영역이 있습니다. 일반 보기 속성은 이러한 콘텐츠 영역의 위치를 설명합니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하며, 다시 열 때 프레젠테이션이 마지막으로 저장된 상태와 동일한 보기 상태가 됩니다.

프레젠테이션의 일반 보기 속성에 접근하기 위해 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getNormalViewProperties) 메서드가 추가되었습니다.

[NormalViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/) , [NormalViewRestoredProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewrestoredproperties/) , 및 [SplitterBarStateType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/splitterbarstatetype/) 열거형이 추가되었습니다.

## **NormalViewProperties에 대해**

일반 보기 속성을 나타냅니다.

[getShowOutlineIcons](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) 및 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) 메서드는 일반 보기 모드의 콘텐츠 영역 중 하나에 개요 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

[getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) 및 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) 메서드는 측면 영역이 충분히 작아질 때 수직 스플리터가 최소화된 상태로 스냅될지 여부를 지정합니다.

[getPreferSingleView](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) 및 [setPreferSingleView](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) 메서드는 사용자가 세 개의 콘텐츠 영역이 있는 표준 일반 보기 대신 전체 창 단일 콘텐츠 영역을 선호하는지 여부를 지정합니다. 활성화된 경우 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

[getVerticalBarState](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 메서드는 수평 또는 수직 스플리터 바가 표시될 상태를 지정합니다. 수평 스플리터 바는 슬라이드를 아래쪽 콘텐츠 영역과 구분하고, 수직 스플리터 바는 슬라이드를 측면 콘텐츠 영역과 구분합니다. 가능한 값은 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ko/python-java/aspose.slides/splitterbarstatetype/#Minimized) , [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ko/python-java/aspose.slides/splitterbarstatetype/#Maximized) 및 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/python-java/aspose.slides/splitterbarstatetype/#Restored) 입니다.

[getRestoredLeft](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 및 [getRestoredTop](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 메서드는 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/python-java/aspose.slides/splitterbarstatetype/#Restored) 값을 [getVerticalBarState](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) 에 적용했을 때 일반 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **NormalViewProperties 복원에 대해**

일반 보기에서 영역이 가변 복원 크기(최소화되지도 최대화되지도 않음)일 때 슬라이드 영역( [getRestoredTop](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 의 자식인 경우 너비, [getRestoredLeft](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 의 자식인 경우 높이)의 크기를 지정합니다.

[getDimensionSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) 메서드는 슬라이드 영역( [getRestoredTop](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredTop) 의 자식인 경우 너비, [getRestoredLeft](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) 의 자식인 경우 높이)의 크기를 지정합니다.

[getAutoAdjust](https://reference.aspose.com/slides/ko/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) 메서드는 애플리케이션 내에서 보기를 포함하는 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정되어야 하는지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대해 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getNormalViewProperties) 에 접근하는 방법을 보여줍니다.

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

## **기본 확대값 설정**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java는 프레젠테이션이 열릴 때 이미 적용되는 기본 확대/축소 값을 설정하는 것을 지원합니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/)를 설정함으로써 수행할 수 있습니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getSlideViewProperties)와 [getNotesViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getNotesViewProperties)를 프로그래밍 방식으로 구성할 수 있습니다. 이 항목에서는 예제를 통해 [Aspose.Slides](/slides/ko/)에서 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)의 [View Properties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/)를 설정하는 방법을 살펴보겠습니다.

{{% /alert %}}

보기 속성을 설정하려면 다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
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

## **FAQ**

**프레젠테이션의 서로 다른 섹션에 대해 다른 보기 설정을 할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getViewProperties) 은 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#getSlideViewProperties))에 정의되며 섹션별이 아니라 전체 문서에 하나의 매개변수 집합이 적용됩니다.

**다른 사용자에 대해 미리 정의된 다양한 보기 상태를 설정할 수 있나요?**

아니요. 설정은 파일에 저장되며 공유됩니다. 뷰어 애플리케이션은 사용자 기본 설정을 따를 수 있지만 파일 자체는 하나의 보기 속성 집합만 포함합니다.

**새 프레젠테이션이 동일한 방식으로 열리도록 미리 정의된 View Properties가 포함된 템플릿을 만들 수 있나요?**

네. [view properties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getViewProperties) 가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새로운 문서를 만들 때 동일한 초기 보기 구성을 사용할 수 있습니다.