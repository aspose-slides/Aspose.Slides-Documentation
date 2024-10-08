---
title: 管理缩放
type: docs
weight: 60
url: /python-net/manage-zoom/
keywords: "缩放, 缩放框, 添加缩放, 格式化缩放框, 概要缩放, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中向 PowerPoint 演示文稿添加缩放或缩放框"
---

## **概述**
PowerPoint 中的缩放允许您在演示文稿的特定幻灯片、部分和内容之间快速跳转。当您进行演示时，这种快速导航的能力可能会非常有用。

![overview](overview.png)

* 要在单个幻灯片上概述整个演示文稿，请使用 [概要缩放](#Summary-Zoom)。
* 要仅显示选定的幻灯片，请使用 [幻灯片缩放](#Slide-Zoom)。
* 要仅显示单个部分，请使用 [部分缩放](#Section-Zoom)。

## **幻灯片缩放**

幻灯片缩放可以使您的演示文稿更具动态性，允许您在所选择的幻灯片之间自由导航，而不会中断演示文稿的流程。幻灯片缩放适用于没有许多部分的简短演示，但您仍然可以在不同的演示场景中使用它们。

幻灯片缩放帮助您深入了解多个信息，同时感觉就像在单一画布上。 

![slidezoomsel](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了 [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/) 枚举、[IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) 接口，以及 [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) 接口中的一些方法。

### **创建缩放框**
您可以通过以下方式在幻灯片上添加缩放框：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 创建您打算链接的新幻灯片。
3. 为创建的幻灯片添加标识文本和背景。
4. 在第一张幻灯片中添加缩放框（包含对创建的幻灯片的引用）。
5. 将修改后的演示稿写入 PPTX 文件。

此示例代码向您展示了如何在幻灯片中创建缩放框：
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # 添加新幻灯片到演示文稿
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # 为第二张幻灯片创建背景
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # 为第二张幻灯片创建文本框
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "第二张幻灯片"

    # 为第三张幻灯片创建背景
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # 为第三张幻灯片创建文本框
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "第三张幻灯片"

    # 添加 ZoomFrame 对象
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # 保存演示文稿
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **使用自定义图像创建缩放框**
使用 Aspose.Slides for Python via .NET，您可以通过以下方法创建带有不同于幻灯片预览图像的缩放框： 
1. 创建 `Presentation` 类的实例。
2. 创建您打算链接的新幻灯片。
3. 为创建的幻灯片添加标识文本和背景。
4. 通过向与 Presentation 对象关联的图像集合添加图像来创建 [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) 对象，以用于填充框。
5. 在第一张幻灯片中添加缩放框（包含对创建的幻灯片的引用）。
6. 将修改后的演示稿写入 PPTX 文件。

此 python 代码向您展示了如何使用不同图像创建缩放框：

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # 添加新幻灯片到演示文稿
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # 为第二张幻灯片创建背景
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # 为第三张幻灯片创建文本框
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "第二张幻灯片"

    # 为缩放对象创建新图像
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # 添加 ZoomFrame 对象
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **格式化缩放框**
在前面的部分中，我们向您展示了如何创建简单的缩放框。要创建更复杂的缩放框，您必须更改框的格式。您可以在缩放框上应用多个格式设置。

您可以通过以下方式控制幻灯片中缩放框的格式：

1. 创建 `Presentation` 类的实例。
2. 创建链接的新幻灯片。
3. 为创建的幻灯片添加标识文本和背景。
4. 在第一张幻灯片中添加缩放框（包含对创建的幻灯片的引用）。
5. 通过向与 Presentation 对象关联的图像集合添加图像来创建 [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) 对象，以用于填充框。
6. 为第一个缩放框对象设置自定义图像。
7. 更改第二个缩放框对象的线条格式。
8. 从第二个缩放框对象的图像中删除背景。
9. 将修改后的演示稿写入 PPTX 文件。

此 python 示例代码向您展示了如何更改缩放框的格式：

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # 添加新幻灯片到演示文稿
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # 为第二张幻灯片创建背景
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # 为第二张幻灯片创建文本框
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "第二张幻灯片"

    # 为第三张幻灯片创建背景
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # 为第三张幻灯片创建文本框
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "第三张幻灯片"

    # 添加 ZoomFrame 对象
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # 为缩放对象创建新图像
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # 为 zoomFrame1 对象设置自定义图像
    zoomFrame1.image = image

    # 为 zoomFrame2 对象设置缩放框格式
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # 不显示 zoomFrame2 对象的背景
    zoomFrame2.show_background = False

    # 保存演示文稿
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **部分缩放**

部分缩放是您演示文稿中一个部分的链接。您可以使用部分缩放返回到您想特别强调的部分。或者，您可以使用它们来强调您演示中某些部分之间的联系。 

![seczoomsel](seczoomsel.png)

对于部分缩放对象，Aspose.Slides 提供了 [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) 接口以及 [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) 接口中的一些方法。

### **创建部分缩放框**

您可以通过以下方式在幻灯片上添加部分缩放框：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 创建新幻灯片。 
3. 为创建的幻灯片添加标识背景。
4. 创建一个您打算链接的部分。
5. 向第一张幻灯片添加部分缩放框（包含对创建的部分的引用）。
6. 将修改后的演示稿写入 PPTX 文件。

此 python 代码向您展示了如何在幻灯片上创建缩放框：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # 向演示文稿添加新幻灯片
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # 向演示文稿添加新部分
    pres.sections.add_section("部分 1", slide)

    # 添加 SectionZoomFrame 对象
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **使用自定义图像创建部分缩放框**

使用 Aspose.Slides for Python，您可以通过以下方式创建具有不同幻灯片预览图像的部分缩放框： 

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 创建新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建一个您打算链接的部分。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象关联的图像集合添加图像，创建一个 `IPPImage` 对象，以填充框。
6. 向第一张幻灯片添加部分缩放框（包含对创建的部分的引用）。
7. 将修改后的演示稿写入 PPTX 文件。

此 python 代码向您展示了如何使用不同图像创建缩放框：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # 向演示文稿添加新幻灯片
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # 向演示文稿添加新部分
    pres.sections.add_section("部分 1", slide)

    # 为缩放对象创建新图像
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # 添加 SectionZoomFrame 对象
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **格式化部分缩放框**

要创建更复杂的部分缩放框，您必须更改简单框的格式。您可以对部分缩放框应用多个格式选项。

您可以通过以下方式控制对幻灯片中部分缩放框的格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 创建新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建一个您打算链接的部分。
5. 向第一张幻灯片添加部分缩放框（包含对创建的部分的引用）。
6. 更改为创建的部分缩放对象的大小和位置。
7. 通过向与 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象关联的图像集合添加图像，创建一个 `IPPImage` 对象，以填充框。
8. 为创建的部分缩放框对象设置自定义图像。
9. 设置*从链接的部分返回到原始幻灯片*的功能。 
10. 从部分缩放框对象的图像中删除背景。
11. 更改第二个缩放框对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示稿写入 PPTX 文件。

此 python 代码向您展示了如何更改部分缩放框的格式：

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    # 向演示文稿添加新幻灯片
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 向演示文稿添加新部分
    pres.sections.add_section("部分 1", slide)

    # 添加 SectionZoomFrame 对象
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # 部分缩放框的格式
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **摘要缩放**

摘要缩放就像一个着陆页，您演示文稿的所有内容一次性显示。当您进行演示时，您可以使用缩放以任何顺序从演示文稿的一处跳转到另一处。您可以发挥创意、跳过前进，或在不打断演示文稿流程的情况下重温幻灯片展示的部分。

![overview_image](summaryzoom.png)

对于摘要缩放对象，Aspose.Slides 提供了 [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) 和 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) 接口，以及 [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) 接口中的一些方法。

### **创建摘要缩放**

您可以通过以下方式向幻灯片添加摘要缩放框：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 创建带有标识背景的新幻灯片，以及为创建的幻灯片创建的新部分。
3. 将摘要缩放框添加到第一张幻灯片。
4. 将修改后的演示稿写入 PPTX 文件。

此 python 代码向您展示了如何在幻灯片上创建摘要缩放框：

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # 创建幻灯片数组
    for slideNumber in range(5):
        # 向演示文稿添加新幻灯片
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # 为幻灯片创建背景
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # 为幻灯片创建文本框
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "幻灯片 - {num}".format(num = (slideNumber + 2))

    # 在第一张幻灯片中创建所有幻灯片的缩放对象
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # 设置 ReturnToParent 属性以返回到第一张幻灯片
        zoomFrame.return_to_parent = True

    # 保存演示文稿
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **添加和删除摘要缩放部分**

摘要缩放框中的所有部分由 [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) 对象表示，这些对象存储在 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) 对象中。您可以通过 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) 接口以以下方式添加或删除摘要缩放部分对象：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 创建带有标识背景的新幻灯片以及为创建的幻灯片创建的新部分。
3. 在第一张幻灯片中添加摘要缩放框。
4. 添加一张新幻灯片和部分到演示文稿。
5. 将创建的部分添加到摘要缩放框。
6. 从摘要缩放框中删除第一部分。
7. 将修改后的演示稿写入 PPTX 文件。

此 python 代码向您展示了如何在摘要缩放框中添加和删除部分：

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    # 向演示文稿添加新幻灯片
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 向演示文稿添加新部分
    pres.sections.add_section("部分 1", slide)

    # 向演示文稿添加新幻灯片
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 向演示文稿添加新部分
    pres.sections.add_section("部分 2", slide)

    # 添加 SummaryZoomFrame 对象
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # 向演示文稿添加新幻灯片
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 向演示文稿添加新部分
    section3 = pres.sections.add_section("部分 3", slide)

    # 向摘要缩放添加部分
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # 从摘要缩放中移除部分
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **格式化摘要缩放部分**

要创建更复杂的摘要缩放部分对象，您必须更改简单框的格式。您可以对摘要缩放部分对象应用多个格式选项。

您可以通过以下方式控制摘要缩放部分对象的格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 创建带有标识背景的新幻灯片以及为创建的幻灯片创建的新部分。
3. 在第一张幻灯片中添加摘要缩放框。
4. 从 `ISummaryZoomSectionCollection` 中获取第一个摘要缩放部分对象。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象关联的图像集合添加图像，创建一个 `IPPImage` 对象，以填充框。
6. 为创建的摘要缩放框部分对象设置自定义图像。
7. 设置*从链接的部分返回到原始幻灯片*的功能。 
8. 更改第二个缩放框对象的线条格式。
9. 更改过渡持续时间。
10. 将修改后的演示稿写入 PPTX 文件。

此 python 代码向您展示了如何更改摘要缩放部分对象的格式：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # 向演示文稿添加新幻灯片
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 向演示文稿添加新部分
    pres.sections.add_section("部分 1", slide)

    # 向演示文稿添加新幻灯片
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 向演示文稿添加新部分
    pres.sections.add_section("部分 2", slide)

    # 添加 SummaryZoomFrame 对象
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # 获取第一个 SummaryZoomSection 对象
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # SummaryZoomSection 对象的格式
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```