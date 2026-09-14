---
title: Python에서 프레젠테이션의 그리기 가이드 관리
linktitle: 그리기 가이드
type: docs
weight: 85
url: /ko/python-java/drawing-guides/
keywords:
- 그리기 가이드
- 수평 가이드
- 수직 가이드
- 정렬 가이드
- 슬라이드 보기
- 마스터 슬라이드
- 레이아웃 슬라이드
- 노트 마스터
- 유인물 마스터
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에서 수평 및 수직 그리기 가이드를 추가하고, 액세스하며, 삭제합니다."
---
## **개요**

그리기 가이드는 조정 가능한 수평 및 수직 라인으로, PowerPoint에서 프레젠테이션을 편집하는 동안 사용자가 도형을 일관되게 정렬하도록 도와줍니다. 특히 애플리케이션이 프레젠테이션을 생성하고 나중에 수동으로 다듬을 경우에 유용합니다. 애플리케이션은 작성자가 콘텐츠를 추가하거나 이동할 때 따라야 할 동일한 정렬 보조선을 저장할 수 있습니다.

그리기 가이드는 편집 보조 도구이며 슬라이드 콘텐츠가 아닙니다. 슬라이드 쇼나 렌더링된 출력에 나타나지 않습니다. Aspose.Slides for Python via Java는 이를 [DrawingGuidesCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/drawingguidescollection/) 클래스에서 제공합니다. 가이드는 [DrawingGuide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/drawingguide/) 로 표현되며 방향, 위치 및 색상을 가집니다.

위치는 해당 슬라이드 또는 마스터의 왼쪽 위 모서리에서 포인트 단위로 측정됩니다. 수직 가이드는 수평 좌표를 사용하며 일반적으로 0에서 슬라이드 너비 사이에 위치합니다. 수평 가이드는 수직 좌표를 사용하며 일반적으로 0에서 슬라이드 높이 사이에 위치합니다.

## **슬라이드 보기에서 가이드 추가**

[CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides)를 사용하여 일반 슬라이드를 편집할 때 표시되는 가이드를 관리합니다. [DrawingGuidesCollection.add](https://reference.aspose.com/slides/ko/python-java/aspose.slides/drawingguidescollection/#add)를 호출하고 [Orientation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/orientation/) 값과 포인트 단위 위치를 지정합니다.

다음 예제는 슬라이드 중앙 오른쪽에 수직 가이드 하나와 그 아래에 수평 가이드 하나를 추가합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **그리기 가이드 액세스**

[DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ko/python-java/aspose.slides/drawingguidescollection/#getCount) 및 [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ko/python-java/aspose.slides/drawingguidescollection/#get_Item) 메서드를 사용하면 기존 가이드를 가져올 수 있습니다. [DrawingGuide.getOrientation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/drawingguide/#getPosition), [DrawingGuide.getColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/drawingguide/#getColor) 메서드는 값을 반환하며 해당 setter 메서드를 통해 변경할 수도 있습니다.

다음 예제는 위에서 만든 프레젠테이션에서 슬라이드 보기 가이드를 읽어옵니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **마스터 및 레이아웃 슬라이드에 가이드 추가**

슬라이드 마스터와 각 레이아웃 슬라이드마다 자체 그리기 가이드 컬렉션을 가질 수 있습니다. 마스터 슬라이드에 대해서는 [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/#getDrawingGuides)를, 레이아웃 슬라이드에 대해서는 [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslide/#getDrawingGuides)를 사용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 수직 가이드를, 첫 번째 레이아웃 슬라이드에 수평 가이드를 추가합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **노트 및 유인물 마스터에 가이드 추가**

노트 마스터와 유인물 마스터도 그리기 가이드를 지원합니다. [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslide/#getDrawingGuides)와 [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides)를 사용하여 해당 컬렉션에 접근합니다. 프레젠테이션에 이러한 마스터가 포함되어 있지 않다면 `MasterNotesSlideManager.setDefaultMasterNotesSlide` 또는 `MasterHandoutSlideManager.setDefaultMasterHandoutSlide`가 기본 마스터를 생성하고 반환합니다.

다음 예제는 노트 마스터에 수평 가이드를, 유인물 마스터에 수직 가이드를 추가합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **그리기 가이드 삭제**

[DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/drawingguidescollection/#clear)를 호출하면 특정 컬렉션에 있는 모든 가이드를 제거합니다. 한 컬렉션을 비우는 것이 다른 범위에 저장된 가이드에 영향을 주지는 않습니다.

다음 예제는 슬라이드 보기 가이드와 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터, 유인물 마스터에 있는 모든 가이드를 누락된 마스터를 생성하지 않고 삭제합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**그리기 가이드는 슬라이드 쇼나 내보낸 이미지에 나타나나요?**

아니요. 그리기 가이드는 편집을 위한 정렬 보조 도구이며 프레젠테이션 콘텐츠로 렌더링되지 않습니다.

**그리기 가이드를 개별 일반 슬라이드에 직접 추가할 수 있나요?**

일반 슬라이드 편집 가이드는 프레젠테이션의 슬라이드 보기 속성에 저장됩니다. 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터, 유인물 마스터용 별도의 가이드 컬렉션이 제공됩니다.

**가이드 위치 단위는 무엇을 사용하나요?**

위치는 포인트 단위로 지정되며, 72 포인트가 1 인치에 해당합니다. 수직 위치는 왼쪽 가장자리에서 측정하고, 수평 위치는 위쪽 가장자리에서 측정합니다.

**그리기 가이드를 삭제하면 도형이 제거되거나 슬라이드 콘텐츠가 변경되나요?**

아니요. [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/drawingguidescollection/#clear) 메서드는 선택한 컬렉션의 가이드만 제거합니다. 도형 및 기타 슬라이드 콘텐츠는 그대로 유지됩니다.