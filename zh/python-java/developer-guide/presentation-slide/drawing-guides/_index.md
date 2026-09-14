---
title: 在 Python 中管理演示文稿的绘图参考线
linktitle: 绘图参考线
type: docs
weight: 85
url: /zh/python-java/drawing-guides/
keywords:
- 绘图参考线
- 水平参考线
- 垂直参考线
- 对齐参考线
- 幻灯片视图
- 母版幻灯片
- 布局幻灯片
- 备注母版
- 讲义母版
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中添加、访问和清除水平和垂直绘图参考线。"
---
## **概述**

绘图参考线是可调节的水平和垂直线，可帮助用户在 PowerPoint 中编辑演示文稿时保持形状的一致对齐。它们在应用程序生成演示文稿后需要手动精细化时尤为有用：应用程序可以保存相同的对齐辅助，作者在添加或移动内容时应遵循这些辅助。

绘图参考线是编辑辅助，而不是幻灯片内容。它们不会出现在幻灯片放映或渲染输出中。Aspose.Slides for Python via Java 通过 [DrawingGuidesCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/drawingguidescollection/) 类公开它们。参考线由 [DrawingGuide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/drawingguide/) 表示，具有方向、位置和颜色。

位置以点为单位，从相关幻灯片或母版的左上角测量。垂直参考线使用水平坐标，通常在零到幻灯片宽度之间。水平参考线使用垂直坐标，通常在零到幻灯片高度之间。

## **将参考线添加到幻灯片视图**

使用 [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) 来管理在编辑普通幻灯片时显示的参考线。使用 [DrawingGuidesCollection.add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/drawingguidescollection/#add) 并传入 [Orientation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/orientation/) 值以及以点为单位的位置。

以下示例在幻灯片中心右侧添加一条垂直参考线，并在其下方添加一条水平参考线：

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

## **访问绘图参考线**

[DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/zh/python-java/aspose.slides/drawingguidescollection/#getCount) 和 [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/zh/python-java/aspose.slides/drawingguidescollection/#get_Item) 方法提供对现有参考线的访问。[DrawingGuide.getOrientation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/drawingguide/#getOrientation)、[DrawingGuide.getPosition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/drawingguide/#getPosition) 和 [DrawingGuide.getColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/drawingguide/#getColor) 方法返回的值也可以通过相应的 setter 方法进行更改。

以下示例读取上述创建的演示文稿中的幻灯片视图参考线：

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

## **将参考线添加到母版和布局幻灯片**

幻灯片母版及其每个布局幻灯片都可以拥有自己的绘图参考线集合。对母版幻灯片使用 [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterslide/#getDrawingGuides)，对布局幻灯片使用 [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layoutslide/#getDrawingGuides)。

以下示例向第一张母版幻灯片添加一条垂直参考线，并向第一张布局幻灯片添加一条水平参考线：

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

## **将参考线添加到备注和讲义母版**

备注母版和讲义母版同样支持绘图参考线。使用 [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslide/#getDrawingGuides) 和 [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) 访问它们的集合。如果演示文稿不包含其中之一的母版，`MasterNotesSlideManager.setDefaultMasterNotesSlide` 或 `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` 将创建默认母版并返回它。

以下示例向备注母版添加一条水平参考线，并向讲义母版添加一条垂直参考线：

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

## **清除绘图参考线**

调用 [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/drawingguidescollection/#clear) 可删除特定集合中的所有参考线。清除一个集合不会影响存放在其他范围中的参考线。

以下示例在不创建缺失母版的情况下，清除幻灯片视图参考线以及母版幻灯片、布局幻灯片、备注母版和讲义母版上的所有参考线：

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

## **常见问题**

**绘图参考线会出现在幻灯片放映或导出图像中吗？**

不会。绘图参考线是用于编辑的对齐辅助，未作为演示内容进行渲染。

**是否可以直接将绘图参考线添加到单个普通幻灯片？**

普通幻灯片的编辑参考线存储在演示文稿的幻灯片视图属性中。幻灯片母版、布局幻灯片、备注母版和讲义母版各有独立的参考线集合。

**参考线位置使用哪种单位？**

位置以点（point）为单位指定，72 点等于一英寸。垂直位置从左边缘测量，水平位置从顶部边缘测量。

**清除绘图参考线会删除形状或更改幻灯片内容吗？**

不会。[DrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/drawingguidescollection/#clear) 方法仅删除所选集合中的参考线。形状和其他幻灯片内容保持不变。