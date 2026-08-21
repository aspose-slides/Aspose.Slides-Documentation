---
title: 在 Python 中管理演示文稿的绘图参考线
linktitle: 绘图参考线
type: docs
weight: 85
url: /zh/python-net/drawing-guides/
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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中添加、访问和清除水平和垂直绘图参考线。"
---
## **概述**

绘图参考线是可调节的水平和垂直线，可帮助用户在 PowerPoint 中编辑演示文稿时始终保持形状对齐。它们在应用程序生成演示文稿后需手动细化时尤其有用：应用程序可以保存相同的对齐辅助，作者在添加或移动内容时应遵循这些辅助。

绘图参考线是编辑辅助，而非幻灯片内容。它们不会出现在幻灯片放映或渲染输出中。Aspose.Slides for Python via .NET 通过[IDrawingGuidesCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/idrawingguidescollection/)接口公开这些参考线。参考线由[IDrawingGuide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/idrawingguide/)表示，具有方向、位置和颜色。

位置以点为单位，从相关幻灯片或母版的左上角测量。垂直参考线使用水平坐标，通常在0到幻灯片宽度之间。水平参考线使用垂直坐标，通常在0到幻灯片高度之间。

## **将参考线添加到幻灯片视图**

使用[ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/)来管理在编辑普通幻灯片时显示的参考线。调用[IDrawingGuidesCollection.add](https://reference.aspose.com/slides/zh/python-net/aspose.slides/idrawingguidescollection/add/)，并提供一个[Orientation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/orientation/)值和以点为单位的位置。

以下示例在幻灯片中心右侧添加一条垂直参考线，并在其下方添加一条水平参考线：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **访问绘图参考线**

[IDrawingGuidesCollection.count](https://reference.aspose.com/slides/zh/python-net/aspose.slides/idrawingguidescollection/count/)属性和索引器可用于访问现有参考线。[IDrawingGuide.orientation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/idrawingguide/orientation/)、[IDrawingGuide.position](https://reference.aspose.com/slides/zh/python-net/aspose.slides/idrawingguide/position/)和[IDrawingGuide.color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/idrawingguide/color/)属性可以读取或修改。

以下示例读取上述创建的演示文稿中的幻灯片视图参考线：

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **将参考线添加到母版和布局幻灯片**

幻灯片母版及其每个布局幻灯片都可以拥有各自的绘图参考线集合。对母版幻灯片使用[IMasterSlide.drawing_guides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imasterslide/drawing_guides/)，对布局幻灯片使用[ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ilayoutslide/drawing_guides/)。

以下示例向第一个母版幻灯片添加一条垂直参考线，并向第一个布局幻灯片添加一条水平参考线：

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

## **将参考线添加到备注和讲义母版**

备注母版和讲义母版同样支持绘图参考线。使用[IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imasternotesslide/drawing_guides/)和[IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imasterhandoutslide/drawing_guides/)访问它们的集合。如果演示文稿不包含这些母版之一，可调用[IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/)或[IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/)创建默认母版并返回它。

以下示例向备注母版添加一条水平参考线，并向讲义母版添加一条垂直参考线：

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

## **清除绘图参考线**

调用[IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides/idrawingguidescollection/clear/)可删除特定集合中的所有参考线。清除一个集合不会影响存放在其他范围中的参考线。

以下示例在不创建缺失母版的前提下，清除幻灯片视图参考线以及幻灯片母版、布局幻灯片、备注母版和讲义母版上的所有参考线：

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

## **常见问题**

**绘图参考线会出现在幻灯片放映或导出图像中吗？**

不会。绘图参考线是用于编辑的对齐辅助，不会作为演示内容进行渲染。

**可以直接向单个普通幻灯片添加绘图参考线吗？**

普通幻灯片的编辑参考线存储在演示文稿的幻灯片视图属性中。幻灯片母版、布局幻灯片、备注母版和讲义母版各自拥有单独的参考线集合。

**参考线位置使用什么单位？**

位置以点为单位指定，72 点等于一英寸。垂直位置相对于左边缘测量，水平位置相对于顶边缘测量。

**清除绘图参考线会删除形状或更改幻灯片内容吗？**

不会。`clear` 方法仅移除所选集合中的参考线，形状和其他幻灯片内容保持不变。