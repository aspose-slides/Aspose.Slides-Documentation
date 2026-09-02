---
title: "Python에서 프레젠테이션의 그리기 가이드 관리"
linktitle: "그리기 가이드"
type: docs
weight: 85
url: /ko/python-net/drawing-guides/
keywords:
- "그리기 가이드"
- "수평 가이드"
- "수직 가이드"
- "정렬 가이드"
- "슬라이드 보기"
- "마스터 슬라이드"
- "레이아웃 슬라이드"
- "노트 마스터"
- "핸드아웃 마스터"
- "PowerPoint"
- "프레젠테이션"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션에 수평 및 수직 그리기 가이드를 추가하고, 액세스하며, 삭제합니다."
---
## **개요**

그리기 가이드는 조정 가능한 수평 및 수직 선으로, PowerPoint에서 프레젠테이션을 편집하는 동안 사용자가 도형을 일관되게 정렬하도록 돕습니다. 특히 응용 프로그램이 프레젠테이션을 생성하고 나중에 수동으로 다듬을 경우에 유용합니다. 응용 프로그램은 저자가 콘텐츠를 추가하거나 이동할 때 따라야 할 동일한 정렬 보조 도구를 저장할 수 있습니다.

그리기 가이드는 편집 보조 도구이며 슬라이드 콘텐츠가 아닙니다. 슬라이드 쇼나 렌더링된 출력에 나타나지 않습니다. Aspose.Slides for Python via .NET은 이를 [IDrawingGuidesCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/idrawingguidescollection/) 인터페이스를 통해 노출합니다. 가이드는 [IDrawingGuide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/idrawingguide/)로 표현되며 방향, 위치 및 색상을 가집니다.

위치는 해당 슬라이드 또는 마스터의 왼쪽 위 모서리에서부터 포인트 단위로 측정됩니다. 수직 가이드는 수평 좌표를 사용하며, 일반적으로 0에서 슬라이드 너비 사이입니다. 수평 가이드는 수직 좌표를 사용하며, 일반적으로 0에서 슬라이드 높이 사이입니다.

## **슬라이드 보기에서 가이드 추가**

[ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/)를 사용하여 일반 슬라이드를 편집하는 동안 표시되는 가이드를 관리합니다. [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ko/python-net/aspose.slides/idrawingguidescollection/add/)을 호출하고 [Orientation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/orientation/) 값과 포인트 단위 위치를 지정합니다.

다음 예제는 슬라이드 중심 오른쪽에 수직 가이드를 하나, 그 아래에 수평 가이드를 하나 추가합니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **그리기 가이드 접근**

[IDrawingGuidesCollection.count](https://reference.aspose.com/slides/ko/python-net/aspose.slides/idrawingguidescollection/count/) 속성 및 인덱서를 사용하여 기존 가이드에 접근할 수 있습니다. [IDrawingGuide.orientation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iddrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iddrawingguide/position/), [IDrawingGuide.color](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iddrawingguide/color/) 속성을 읽거나 수정할 수 있습니다.

다음 예제는 위에서 만든 프레젠테이션의 슬라이드 보기 가이드를 읽어옵니다:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **마스터 및 레이아웃 슬라이드에 가이드 추가**

슬라이드 마스터와 해당 레이아웃 슬라이드 각각은 자체 그리기 가이드 컬렉션을 가질 수 있습니다. 마스터 슬라이드에는 [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imasterslide/drawing_guides/)를, 레이아웃 슬라이드에는 [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ilayoutslide/drawing_guides/)를 사용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 수직 가이드를 하나, 첫 번째 레이아웃 슬라이드에 수평 가이드를 하나 추가합니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **노트 및 핸드아웃 마스터에 가이드 추가**

노트 마스터와 핸드아웃 마스터도 그리기 가이드를 지원합니다. 해당 컬렉션에 접근하려면 [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imasternotesslide/drawing_guides/)와 [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imasterhandoutslide/drawing_guides/)를 사용합니다. 프레젠테이션에 이러한 마스터 중 하나가 없을 경우, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) 또는 [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/)가 기본 마스터를 생성하고 반환합니다.

다음 예제는 노트 마스터에 수평 가이드를 하나, 핸드아웃 마스터에 수직 가이드를 하나 추가합니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **그리기 가이드 지우기**

[IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides/idrawingguidescollection/clear/)을 호출하여 특정 컬렉션의 모든 가이드를 제거합니다. 한 컬렉션을 비워도 다른 범위에 저장된 가이드에는 영향을 주지 않습니다.

다음 예제는 누락된 마스터를 생성하지 않고 슬라이드 보기 가이드와 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터, 핸드아웃 마스터에 있는 모든 가이드를 삭제합니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**그리기 가이드는 슬라이드 쇼나 내보낸 이미지에 나타나요?**

아니요. 그리기 가이드는 편집을 위한 정렬 보조 도구이며 프레젠테이션 콘텐츠로 렌더링되지 않습니다.

**그리기 가이드를 개별 일반 슬라이드에 직접 추가할 수 있나요?**

일반 슬라이드 편집 가이는 프레젠테이션의 슬라이드 보기 속성에 저장됩니다. 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터 및 핸드아웃 마스터용 별도의 가이드 컬렉션이 제공됩니다.

**가이드 위치에 사용되는 단위는 무엇인가요?**

위치는 포인트 단위로 지정되며, 72포인트가 1인치에 해당합니다. 수직 위치는 왼쪽 가장자리에서 측정하고, 수평 위치는 위쪽 가장자리에서 측정합니다.

**그리기 가이드를 지우면 도형이 삭제되거나 슬라이드 콘텐츠가 변경되나요?**

아니요. `clear` 메서드는 선택된 컬렉션의 가이드만 제거합니다. 도형 및 기타 슬라이드 콘텐츠는 그대로 유지됩니다.