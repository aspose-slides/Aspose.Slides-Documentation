---
title: 在 Python via Java 中管理簡報縮放
linktitle: 管理縮放
type: docs
weight: 60
url: /zh-hant/python-java/manage-zoom/
keywords:
- 縮放
- 縮放框架
- 投影片縮放
- 章節縮放
- 摘要縮放
- 新增縮放
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 建立並自訂縮放 — 在 PowerPoint 簡報中在章節之間跳轉、加入縮圖與轉場效果。"
---
## **簡介**

PowerPoint 縮放功能允許您在投影片放映期間在特定投影片和章節之間導覽。使用 Aspose.Slides for Python via Java，您可以建立投影片縮放、章節縮放和摘要縮放，並自訂它們的預覽、框線和轉場效果。

![PowerPoint 縮放概觀](overview.png)

* 要在單一投影片上概述整個簡報，請使用[Summary Zoom](#summary-zoom)。
* 若只顯示所選投影片，請使用[Slide Zoom](#slide-zoom)。
* 若只顯示單一章節，請使用[Section Zoom](#section-zoom)。

## **投影片縮放**

投影片縮放可以讓您的簡報更具動態性，允許您在任意順序自由導覽投影片而不會中斷簡報的流程。投影片縮放非常適合章節較少的簡短簡報，但在其他簡報情境中仍可使用。

投影片縮放讓您從單一概觀投影片探索相關資訊。

![選取投影片以建立投影片縮放](slidezoomsel.png)

對於投影片縮放物件，Aspose.Slides 提供 [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/) 列舉、[ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) 類別，以及 [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) 類別上的方法。

### **建立縮放框架**

使用 [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) 在概觀投影片上放置指向個別投影片的連結。本範例建立兩個具有不同背景和標籤的目標投影片，然後在第一張投影片加入每個投影片的預覽，並將簡報儲存為 PPTX。框架的位置與尺寸以點 (points) 為單位指定。

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

### **使用自訂影像建立縮放框架**

將自訂影像傳遞給 [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) 以取代目標投影片的預設預覽。本範例需要本機影像，使用 [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) 載入，並透過 [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) 新增至簡報。產生的框架會顯示該影像，同時仍連結至第二張投影片。

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

### **格式化縮放框架**

本範例自訂兩個投影片縮放框架。它透過 [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) 為第一個框架指定本機影像，並透過 [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) 為第二個框架設定五點、虛點線、粉紅色的框線。將 `False` 傳遞給 [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) 會隱藏第二個框架的背景。自訂預覽需要本機影像；兩個框架在儲存的 PPTX 中仍保留其投影片目標。

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

## **章節縮放**

章節縮放會連結至簡報中的特定章節。可用來重新檢視主題或展示簡報不同部分之間的關聯。

![選取章節以建立章節縮放](seczoomsel.png)

對於章節縮放物件，Aspose.Slides 提供 [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) 類別以及 [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) 類別上的方法。

### **建立章節縮放框架**

使用 [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection) 建立章節，然後將回傳的章節傳遞給 [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame)。本範例在第一張投影片上放置章節縮放，並將其連結至以彩色投影片開始的章節。框架的位置與尺寸以點為單位指定，簡報儲存為 PPTX。

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

### **使用自訂影像建立章節縮放框架**

使用自訂影像的 [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) 讓您在不變更目的章節的情況下顯示自訂預覽。本範例需要本機影像，透過 [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) 載入，並使用 [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) 新增。儲存的簡報在第一張投影片包含一個連結至新建立章節的章節縮放。

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

### **變更章節縮放的目標章節**

使用 [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection) 可在不重新建立的情況下重新指向現有的章節縮放。從同一簡報的 [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) 集合中選取已填充的章節。指派空的章節會保留當前目標不變，因此在指派前請先檢查 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection)。更多關於章節的資訊，請參閱[管理投影片章節](/slides/zh-hant/python-java/slide-section/)。

以下範例載入一個簡報檔案，該檔案必須包含多個已填充章節、一個名為 `Section navigation` 的現有章節縮放，以及一個唯一名稱為 `Results` 的章節。它會在所有投影片中搜尋縮放，並以名稱而非可能因章節重排而變動的集合索引來找到目標。如果名稱不唯一，請改用 [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId) 來辨識目標。

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

### **格式化章節縮放框架**

本範例將章節縮放移動並調整大小為 100 x 75 點，透過 [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) 指派本機影像，並套用 2.5 點、虛點線、棕色框線。它啟用 [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) 以在章節結束後返回來源投影片，停用 [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground)，並將 [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) 設為 1.5 秒。自訂預覽需要本機影像。

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

## **摘要縮放**

摘要縮放提供簡報章節的概觀。於投影片放映期間，您可使用它跳轉至章節、快進或重新檢視主題，而不必遵循投影片順序。

![選取章節以建立摘要縮放](sumzoomsel.png)

對於摘要縮放物件，Aspose.Slides 提供 [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/)、[SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) 與 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) 類別，以及 [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) 類別上的方法。

### **建立摘要縮放**

使用 [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame) 建立簡報章節的概觀。本範例建立四個具有不同投影片背景的章節，並在第一張投影片加入摘要縮放。框架的位置與尺寸以點為單位指定，最終概觀儲存為 PPTX 簡報。

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

### **新增與移除摘要縮放章節**

摘要縮放將其 [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) 物件儲存在 [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) 中。本範例建立兩個章節的概觀，使用 [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) 新增第三個章節，並使用 [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection) 移除第一個章節的條目。移除條目後，簡報的章節及其投影片仍保持完整。

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

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

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

### **格式化摘要縮放章節**

本範例格式化 [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) 中的第一個條目，使用零基索引 `0`。它需要本機影像以供 [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) 使用，套用 1.5 點、虛點線、黑色框線，並將 [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) 設為 1.5 秒。將 `False` 傳遞給 [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) 會停用此條目自動返回摘要投影片的功能。

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

## **常見問題**

**顯示目標後，我可以控制返回「父」投影片嗎？**

可以。呼叫 [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) 並傳入 `True`，即可在顯示目標內容後返回來源投影片。

**我可以調整縮放轉場的「速度」或持續時間嗎？**

可以。使用 [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) 以秒為單位控制轉場持續時間。

**簡報中可包含的縮放物件數量有限制嗎？**

文件中未記載嚴格的 API 限制。實際上限取決於簡報的整體複雜度及檢視器的效能。雖然可以加入大量縮放框架，但仍需考量檔案大小與渲染時間。