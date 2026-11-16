---
title: Python via Java에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/python-java/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 내용
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
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션의 일반 보기 레이아웃, 슬라이드 및 노트 확대/축소, 그리드 간격 및 주석 표시 여부를 구성합니다."
---
## **소개**

PowerPoint의 일반 보기에서는 슬라이드가 썸네일 또는 개요용 사이드 창과 아래의 노트 창 사이에 표시됩니다. Aspose.Slides for Python via Java는 [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties)를 통해 프레젠테이션에 저장된 편집 환경 설정을 노출합니다. 여기에는 창 레이아웃, 확대/축소 수준, 그리드 간격 및 주석 표시 여부가 포함됩니다.

## **NormalViewProperties에 대하여**

[getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties)를 사용하여 [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/) 클래스를 가져옵니다. [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons)는 개요에서 슬라이드 제목 옆에 아이콘을 표시할지 여부를 제어합니다. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter)는 사용자가 사이드 창을 좁힐 때 창이 최소화된 상태로 스냅되도록 합니다. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView)는 전체 창에서 하나의 창만 표시하도록 선호도를 나타냅니다.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState)는 사이드 창과 슬라이드 사이의 구분자를 제어합니다. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState)는 노트 창 위의 구분자를 제어합니다. 두 메서드 모두 `Minimized`, `Maximized`, `Restored` 중 하나의 [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) 값을 받아들입니다.

## **NormalViewProperties 복원에 대하여**

구분자가 복원될 때, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)는 사이드 창의 저장된 크기를 제공하고 [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop)는 상단 슬라이드 영역의 저장된 크기를 제공합니다. 두 메서드 모두 [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/) 인스턴스를 반환합니다. 해당 인스턴스의 [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) 메서드는 0에서 100까지의 백분율을 받아들이며, [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust)는 창 크기가 조정될 때 편집기가 크기를 자동으로 조정할지 여부를 제어합니다.

이 예제는 기존 프레젠테이션을 업데이트합니다. 가로 구분자를 복원하고, [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop)이 반환하는 크기를 자동 조정이 활성화된 상태에서 80%로 설정하며, 세로 구분자를 최대화합니다. 또한 [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons)를 호출하여 개요 보기에서 아이콘을 표시합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **기본 확대/축소 값 설정**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties)와 [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties)는 편집기에서 독립적인 확대/축소 설정을 저장합니다. 이러한 설정은 슬라이드 크기, 슬라이드 쇼 재생, 이미지 내보내기 해상도에 영향을 주지 않습니다.

이 예제는 기존 프레젠테이션을 열고 [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale)를 호출하여 슬라이드를 편집 창에 맞춥니다. 노트 페이지의 경우 자동 스케일링을 비활성화하고 [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale)를 호출하여 고정된 80% 확대/축소를 설정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **그리드 간격 설정**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing)는 프레젠테이션 전체에 걸쳐 편집 그리드 선 사이의 거리를 설정합니다. 인치는 72포인트이며 양의 값을 받습니다. 이 예제는 기존 프레젠테이션에서 현재 그리드 간격을 출력하고, 간격을 18포인트로 설정하여 1/4인치 그리드를 저장합니다.

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

그리드는 고정된 간격으로 반복됩니다. [그리기 가이드](/slides/ko/python-java/drawing-guides/)는 개별 가로 또는 세로 위치를 표시합니다. 둘 다 편집 보조 도구이며 해당 기능을 표시하는 편집기에서만 나타납니다. 슬라이드 쇼 및 PDF, 이미지, SVG로 내보낼 때는 포함되지 않습니다.

## **프레젠테이션 열 때 주석 표시 또는 숨기기**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments)는 호환되는 편집기에서 프레젠테이션을 열 때 사용할 기본 설정을 저장합니다. 주석이 포함된 기존 프레젠테이션에 대해 이 예제는 현재 설정을 출력하고 주석이 숨겨진 사본을 저장합니다. 또한 [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView)와 [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView)를 함께 호출하여 사본이 슬라이드 보기로 열리게 합니다.

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

주석을 숨기면 텍스트, 작성자, 위치, 답글 및 상태가 그대로 유지됩니다. 주석 자체를 변경하려면 [프레젠테이션 주석](/slides/ko/python-java/presentation-comments/)를 참조하십시오. 내보내기 설정은 PDF, HTML, 이미지, 노트 또는 유인물에 주석이 표시될지를 제어합니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 숨겨지는 이유는 무엇인가요?**  
프레젠테이션은 그리드 간격을 저장합니다. 그리드를 보려면 편집기에서 그리드 표시를 활성화하십시오.

**그리기 가이드를 삭제하면 그리드 간격이 변경되나요?**  
아니요. 안내선을 추가, 이동 또는 삭제해도 그리드 간격은 변하지 않습니다.

**프레젠테이션의 서로 다른 섹션이 서로 다른 보기 설정을 가질 수 있나요?**  
아니오. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties)는 전체 프레젠테이션에 적용됩니다.

**다른 사용자를 위해 서로 다른 보기 설정을 저장할 수 있나요?**  
파일은 모든 사용자를 위한 하나의 보기 설정만 저장합니다. 편집기는 사용자의 로컬 기본 설정을 적용할 수 있습니다.

**템플릿에 보기 설정을 저장할 수 있나요?**  
예. 템플릿에서 만든 프레젠테이션은 저장된 보기 설정을 상속합니다.