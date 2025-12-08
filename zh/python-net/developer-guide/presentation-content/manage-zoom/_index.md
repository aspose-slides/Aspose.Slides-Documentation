---
title: 使用 Python 在演示文稿中管理缩放
linktitle: 缩放
type: docs
weight: 60
url: /zh/python-net/manage-zoom/
keywords:
- 缩放
- 缩放帧
- 幻灯片缩放
- 章节缩放
- 摘要缩放
- 添加缩放
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 创建和自定义缩放 — 在 PPT、PPTX 和 ODP 演示文稿中在章节之间跳转，添加缩略图和过渡效果。"
---

## **概述**
PowerPoint 中的缩放功能允许您在演示文稿的特定幻灯片、章节和部分之间来回跳转。在演示时，这种快速导航内容的能力可能非常有用。

![overview](overview.png)

* 要在单张幻灯片上概括整个演示文稿，请使用[Summary Zoom](#Summary-Zoom)。
* 仅显示选定幻灯片，请使用[Slide Zoom](#Slide-Zoom)。
* 仅显示单个章节，请使用[Section Zoom](#Section-Zoom)。

## **幻灯片缩放**

幻灯片缩放可以使您的演示更具活力，允许您自由选择任意顺序在幻灯片之间导航，而不会打断演示的流程。幻灯片缩放非常适合章节不多的短篇演示，但在其他演示场景中同样可用。

幻灯片缩放帮助您在感觉像是单一画布的环境中深入多个信息片段。

![slidezoomsel](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了 [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/) 枚举、[IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) 接口以及在 [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) 接口中的一些方法。

### **创建缩放帧**
您可以按以下方式在幻灯片上添加缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 创建您打算链接的新幻灯片。
3. 为创建的幻灯片添加标识文本和背景。
4. 在第一张幻灯片中添加缩放帧（包含对创建的幻灯片的引用）。
5. 将修改后的演示文稿写入为 PPTX 文件。

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #添加新幻灯片到演示文稿
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # 为第二张幻灯片创建背景
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # 为第二张幻灯片创建文本框
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # 为第三张幻灯片创建背景
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # 为第三张幻灯片创建文本框
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Add ZoomFrame objects
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # 保存演示文稿
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **使用自定义图像创建缩放帧**
使用 Aspose.Slides for Python via .NET，您可以按以下方式创建使用非幻灯片预览图像的缩放帧：

1. 创建 `Presentation` 类的实例。
2. 创建您打算链接的新幻灯片。
3. 为创建的幻灯片添加标识文本和背景。
4. 通过向与 Presentation 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) 对象，以填充帧。
5. 在第一张幻灯片中添加缩放帧（包含对创建的幻灯片的引用）。
6. 将修改后的演示文稿写入为 PPTX 文件。

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #添加一个新幻灯片到演示文稿
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # 为第二张幻灯片创建背景
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # 为第三张幻灯片创建文本框
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # 为缩放对象创建新图像
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #添加 ZoomFrame 对象
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **格式化缩放帧**
在前面的章节中，我们向您展示了如何创建简单的缩放帧。要创建更复杂的缩放帧，需要修改帧的格式。可以对缩放帧应用多种格式设置。

您可以按以下方式控制幻灯片中缩放帧的格式：

1. 创建 `Presentation` 类的实例。
2. 创建要链接的新幻灯片。
3. 为创建的幻灯片添加标识文本和背景。
4. 在第一张幻灯片中添加缩放帧（包含对创建的幻灯片的引用）。
5. 通过向与 Presentation 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) 对象，以填充帧。
6. 为第一个缩放帧对象设置自定义图像。
7. 更改第二个缩放帧对象的线条格式。
8. 去除第二个缩放帧对象图像的背景。
9. 将修改后的演示文稿写入为 PPTX 文件。

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #添加新幻灯片到演示文稿
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # 为第二张幻灯片创建背景
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # 为第二张幻灯片创建文本框
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # 为第三张幻灯片创建背景
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # 为第三张幻灯片创建文本框
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #添加 ZoomFrame 对象
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # 为缩放对象创建新图像
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # 为 zoomFrame1 对象设置自定义图像
    zoomFrame1.image = image

    # 为 zoomFrame2 对象设置缩放帧格式
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # 不显示 zoomFrame2 对象的背景
    zoomFrame2.show_background = False

    # 保存演示文稿
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```


## **章节缩放**

章节缩放是指向演示文稿中某个章节的链接。您可以使用章节缩放返回需要特别强调的章节，或用于突出演示文稿中各部分之间的关联。

![seczoomsel](seczoomsel.png)

对于章节缩放对象，Aspose.Slides 提供了 [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) 接口以及在 [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) 接口中的一些方法。

### **创建章节缩放帧**
您可以按以下方式在幻灯片上添加章节缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 创建一张新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建一个您打算链接缩放帧的新章节。
5. 在第一张幻灯片中添加章节缩放帧（包含对创建的章节的引用）。
6. 将修改后的演示文稿写入为 PPTX 文件。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #添加一个新幻灯片到演示文稿
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # 添加一个新章节到演示文稿
    pres.sections.add_section("Section 1", slide)

    # 添加 SectionZoomFrame 对象
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **使用自定义图像创建章节缩放帧**
使用 Aspose.Slides for Python，您可以按以下方式创建使用不同幻灯片预览图像的章节缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 创建一张新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建一个您打算链接缩放帧的新章节。
5. 通过向与 Presentation 对象关联的 Images 集合中添加图像，创建一个 `IPPImage` 对象，以填充帧。
6. 在第一张幻灯片中添加章节缩放帧（包含对创建的章节的引用）。
7. 将修改后的演示文稿写入为 PPTX 文件。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #添加一个新幻灯片到演示文稿
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # 添加一个新章节到演示文稿
    pres.sections.add_section("Section 1", slide)

    # 为缩放对象创建新图像
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # 添加 SectionZoomFrame 对象
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **格式化章节缩放帧**
要创建更复杂的章节缩放帧，需要修改简单帧的格式。可以对章节缩放帧应用多种格式选项。

您可以按以下方式在幻灯片中控制章节缩放帧的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 创建一张新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建一个您打算链接缩放帧的新章节。
5. 在第一张幻灯片中添加章节缩放帧（包含对创建的章节的引用）。
6. 更改创建的章节缩放对象的大小和位置。
7. 通过向与 Presentation 对象关联的 Images 集合中添加图像，创建一个 `IPPImage` 对象，以填充帧。
8. 为创建的章节缩放帧对象设置自定义图像。
9. 设置*从链接章节返回原始幻灯片*的功能。
10. 去除章节缩放帧对象图像的背景。
11. 更改第二个缩放帧对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入为 PPTX 文件。

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #添加一个新幻灯片到演示文稿
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 添加一个新章节到演示文稿
    pres.sections.add_section("Section 1", slide)

    # 添加 SectionZoomFrame 对象
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # SectionZoomFrame 的格式设置
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

摘要缩放类似于一个着陆页，展示演示文稿的所有部分。演示时，您可以使用缩放在演示文稿的任意位置之间任意顺序跳转。您可以创意地前进、跳过或重新访问幻灯片内容，而不会中断演示的流程。

![overview_image](summaryzoom.png)

对于摘要缩放对象，Aspose.Slides 提供了 [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) 和 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) 接口以及在 [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) 接口中的一些方法。

### **创建摘要缩放**
您可以按以下方式在幻灯片上添加摘要缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 为创建的幻灯片创建带有标识背景和新章节的幻灯片。
3. 将摘要缩放帧添加到第一张幻灯片。
4. 将修改后的演示文稿写入为 PPTX 文件。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # 创建幻灯片数组
    for slideNumber in range(5):
        #添加新幻灯片到演示文稿
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # 为幻灯片创建背景
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # 为幻灯片创建文本框
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # 为第一张幻灯片中的所有幻灯片创建缩放对象
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # 设置 ReturnToParent 属性以返回到第一张幻灯片
        zoomFrame.return_to_parent = True

    # 保存演示文稿
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```


### **添加和移除摘要缩放章节**
所有摘要缩放帧中的章节均由 [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) 对象表示，这些对象存储在 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) 对象中。您可以通过 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) 接口按以下方式添加或移除摘要缩放章节对象：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 为创建的幻灯片创建带有标识背景和新章节的幻灯片。
3. 将摘要缩放帧添加到第一张幻灯片。
4. 向演示文稿中添加新幻灯片和章节。
5. 将创建的章节添加到摘要缩放帧。
6. 从摘要缩放帧中移除第一章节。
7. 将修改后的演示文稿写入为 PPTX 文件。

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #添加一个新幻灯片到演示文稿
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 添加一个新章节到演示文稿
    pres.sections.add_section("Section 1", slide)

    #添加一个新幻灯片到演示文稿
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 添加一个新章节到演示文稿
    pres.sections.add_section("Section 2", slide)

    # 添加 SummaryZoomFrame 对象
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #添加一个新幻灯片到演示文稿
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 添加一个新章节到演示文稿
    section3 = pres.sections.add_section("Section 3", slide)

    # 向 Summary Zoom 添加章节
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # 从 Summary Zoom 删除章节
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **格式化摘要缩放章节**
要创建更复杂的摘要缩放章节对象，需要修改简单帧的格式。可以对摘要缩放章节对象应用多种格式选项。

您可以按以下方式在摘要缩放帧中控制摘要缩放章节对象的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 为创建的幻灯片创建带有标识背景和新章节的幻灯片。
3. 将摘要缩放帧添加到第一张幻灯片。
4. 从 `ISummaryZoomSectionCollection` 获取第一个对象的摘要缩放章节对象。
5. 通过向与 Presentation 对象关联的 images 集合中添加图像，创建一个 `IPPImage` 对象，以填充帧。
6. 为创建的章节缩放帧对象设置自定义图像。
7. 设置*从链接章节返回原始幻灯片*的功能。
8. 更改第二个缩放帧对象的线条格式。
9. 更改过渡持续时间。
10. 将修改后的演示文稿写入为 PPTX 文件。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #添加一个新幻灯片到演示文稿
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 添加一个新章节到演示文稿
    pres.sections.add_section("Section 1", slide)

    #添加一个新幻灯片到演示文稿
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 添加一个新章节到演示文稿
    pres.sections.add_section("Section 2", slide)

    # 添加 SummaryZoomFrame 对象
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # 获取第一个 SummaryZoomSection 对象
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # 对 SummaryZoomSection 对象进行格式设置
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


## **常见问题**

**在显示目标后，我能控制返回到“父”幻灯片吗？**

是的。[Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) 或 [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) 具有 `return_to_parent` 行为，启用后会在观看者访问目标内容后将其送回原始幻灯片。

**我可以调整 Zoom 过渡的“速度”或持续时间吗？**

可以。Zoom 支持设置 `transition_duration`，从而控制跳转动画的时长。

**演示文稿中可以包含多少个 Zoom 对象是否有限制？**

文档中未列出硬性 API 限制。实际限制取决于演示文稿的整体复杂度和查看器的性能。您可以添加大量 Zoom 帧，但需考虑文件大小和渲染时间。