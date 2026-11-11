---
title: Python via Java에서 프레젠테이션 줌 관리
linktitle: 줌 관리
type: docs
weight: 60
url: /ko/python-java/manage-zoom/
keywords:
- 줌
- 줌 프레임
- 슬라이드 줌
- 섹션 줌
- 요약 줌
- 줌 추가
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 줌을 만들고 사용자 지정합니다 — 섹션 간 이동, 썸네일 및 전환 효과를 PowerPoint 프레젠테이션에 추가합니다."
---
## **소개**

PowerPoint 줌을 사용하면 슬라이드 쇼 중에 특정 슬라이드와 섹션 사이를 탐색할 수 있습니다. Aspose.Slides for Python via Java를 사용하면 슬라이드, 섹션 및 요약 줌을 만들고 미리 보기, 테두리 및 전환 효과를 사용자 지정할 수 있습니다.

![PowerPoint zoom overview](overview.png)

* 전체 프레젠테이션을 한 슬라이드에 요약하려면 [요약 줌](#summary-zoom)을 사용하세요.
* 선택한 슬라이드만 표시하려면 [슬라이드 줌](#slide-zoom)을 사용하세요.
* 단일 섹션만 표시하려면 [섹션 줌](#section-zoom)을 사용하세요.

## **슬라이드 줌**

슬라이드 줌은 프레젠테이션을 보다 역동적으로 만들고, 흐름을 방해하지 않으면서 원하는 순서대로 슬라이드를 자유롭게 탐색할 수 있게 해줍니다. 슬라이드 줌은 섹션이 많지 않은 짧은 프레젠테이션에 적합하지만, 다양한 프레젠테이션 시나리오에서도 사용할 수 있습니다.

슬라이드 줌을 사용하면 하나의 개요 슬라이드에서 관련 정보를 탐색할 수 있습니다.

![Selecting slides for a slide zoom](slidezoomsel.png)

슬라이드 줌 개체에 대해서는 Aspose.Slides가 [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/) 열거형, [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) 클래스 및 [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) 클래스의 메서드를 제공합니다.

### **줌 프레임 만들기**

[ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame)을 사용하여 개요 슬라이드에 개별 슬라이드에 대한 링크를 배치합니다. 이 예제는 배경이 서로 다른 두 개의 대상 슬라이드를 만들고, 각각의 미리 보기를 첫 번째 슬라이드에 추가한 뒤 프레젠테이션을 PPTX 형식으로 저장합니다. 프레임 위치와 크기는 포인트 단위로 지정됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **사용자 정의 이미지로 줌 프레임 만들기**

[ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame)에 사용자 정의 이미지를 전달하면 대상 슬라이드의 기본 미리 보기를 교체할 수 있습니다. 이 예제는 로컬 이미지를 필요로 하며, 이를 [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile)으로 로드한 뒤 [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage)을 통해 프레젠테이션에 추가합니다. 결과 프레임은 해당 이미지를 표시하면서 두 번째 슬라이드에 링크됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **줌 프레임 서식 지정**

이 예제는 두 개의 슬라이드 줌 프레임을 사용자 지정합니다. 첫 번째 프레임에는 [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage)로 로컬 이미지를 지정하고, 두 번째 프레임에는 [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat)을 사용해 5포인트의 점선-점선 핑크 테두리를 적용합니다. [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground)에 `False`를 전달하면 두 번째 프레임의 배경이 숨겨집니다. 사용자 정의 미리 보기를 위해 로컬 이미지가 필요하며, 두 프레임 모두 저장된 PPTX에서 슬라이드 대상은 유지됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **섹션 줌**

섹션 줌은 프레젠테이션의 섹션에 연결됩니다. 이를 사용해 주제를 다시 방문하거나 프레젠테이션의 다른 부분이 어떻게 연결되는지 보여줄 수 있습니다.

![Selecting a section for a section zoom](seczoomsel.png)

섹션 줌 개체에 대해서는 Aspose.Slides가 [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) 클래스 및 [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) 클래스의 메서드를 제공합니다.

### **섹션 줌 프레임 만들기**

[SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection)으로 섹션을 만든 뒤, 반환된 섹션을 [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame)에 전달합니다. 이 예제는 첫 번째 슬라이드에 섹션 줌을 배치하고, 색상이 있는 슬라이드로 시작하는 섹션에 연결합니다. 프레임 위치와 크기는 포인트 단위로 지정되며 프레젠테이션은 PPTX 형식으로 저장됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **사용자 정의 이미지로 섹션 줌 프레임 만들기**

[ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame)의 이미지 오버로드를 사용하면 대상 섹션을 변경하지 않고 사용자 정의 미리 보기를 표시할 수 있습니다. 이 예제는 로컬 이미지를 필요로 하며, 이를 [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile)으로 로드하고 [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage)을 통해 추가합니다. 저장된 프레젠테이션에는 첫 번째 슬라이드에 새로 만든 섹션에 연결된 섹션 줌이 포함됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **섹션 줌의 대상 섹션 변경**

[SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection)을 사용하면 기존 섹션 줌을 다시 만들지 않고도 대상 섹션을 재지정할 수 있습니다. 같은 프레젠테이션의 [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) 컬렉션에서 채워진 섹션을 선택합니다. 빈 섹션을 할당하면 현재 대상이 변경되지 않으므로, 할당하기 전에 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection)을 확인하십시오. 섹션에 대한 자세한 내용은 [슬라이드 섹션 관리](/slides/ko/python-java/slide-section/)를 참조하십시오.

다음 예제는 프레젠테이션 파일을 로드하는데, 여기에는 여러 개의 채워진 섹션, `Section navigation`이라는 기존 섹션 줌, 그리고 고유 이름 `Results`를 가진 섹션이 포함되어 있어야 합니다. 모든 슬라이드를 검색해 줌을 찾고, 섹션이 재정렬될 때 변할 수 있는 컬렉션 인덱스 대신 이름으로 대상 섹션을 찾습니다. 이름이 고유하지 않은 경우 [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId)를 사용해 목적지를 식별하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **섹션 줌 프레임 서식 지정**

이 예제는 섹션 줌을 100×75 포인트로 이동 및 크기 조정하고, [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage)로 로컬 이미지를 할당하며, 2.5포인트 점선-점선 갈색 테두리를 적용합니다. [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent)을 활성화해 섹션 후 원본 슬라이드로 돌아가게 하고, [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground)을 비활성화하며, [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration)을 1.5초로 설정합니다. 사용자 정의 미리 보기를 위해 로컬 이미지가 필요합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **요약 줌**

요약 줌은 프레젠테이션 섹션에 대한 개요를 제공합니다. 슬라이드 쇼 중에 이를 사용해 섹션으로 이동하거나, 앞으로 건너뛰거나, 순서를 따르지 않고 다시 주제로 돌아갈 수 있습니다.

![Selecting sections for a summary zoom](sumzoomsel.png)

요약 줌 개체에 대해서는 Aspose.Slides가 [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/), [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) 클래스와 [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) 클래스의 메서드를 제공합니다.

### **요약 줌 만들기**

[ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame)을 사용해 프레젠테이션 섹션의 개요를 생성합니다. 이 예제는 배경이 서로 다른 네 개의 섹션을 만든 뒤 첫 번째 슬라이드에 요약 줌을 추가합니다. 프레임 위치와 크기는 포인트 단위로 지정되며 결과 개요는 PPTX 프레젠테이션으로 저장됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **요약 줌 섹션 추가 및 제거**

요약 줌은 [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection)에서 [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) 객체를 저장합니다. 이 예제는 두 개의 섹션 개요를 만든 뒤 [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection)으로 세 번째 섹션을 추가하고, [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection)으로 첫 번째 섹션 항목을 제거합니다. 항목을 제거해도 프레젠테이션 섹션과 슬라이드는 그대로 유지됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 5, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **요약 줌 섹션 서식 지정**

이 예제는 [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection)에서 첫 번째 항목(인덱스 `0`)을 서식 지정합니다. [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage)를 위해 로컬 이미지가 필요하고, 1.5포인트 점선-점선 검은색 테두리를 적용하며, [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration)을 1.5초로 설정합니다. [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent)에 `False`를 전달하면 이 항목에 대해 요약 슬라이드로 자동 반환이 비활성화됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**대상 슬라이드를 표시한 후 '부모' 슬라이드로 돌아가는 것을 제어할 수 있나요?**

예. [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent)에 `True`를 전달하면 대상 콘텐츠가 표시된 후 원본 슬라이드로 돌아갑니다.

**Zoom 전환의 '속도' 또는 지속 시간을 조정할 수 있나요?**

예. [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration)을 사용해 전환 지속 시간을 초 단위로 제어할 수 있습니다.

**프레젠테이션에 포함할 수 있는 Zoom 객체 수에 제한이 있나요?**

문서화된 명확한 API 제한은 없습니다. 실질적인 제한은 프레젠테이션 복잡도와 뷰어 성능에 따라 달라집니다. 많은 Zoom 프레임을 추가할 수 있지만 파일 크기와 렌더링 시간을 고려하세요.