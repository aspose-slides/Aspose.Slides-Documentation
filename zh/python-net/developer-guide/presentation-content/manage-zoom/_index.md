---
title: 使用 Python 管理演示文稿中的缩放
linktitle: 缩放
type: docs
weight: 60
url: /zh/python-net/manage-zoom/
keywords:
- 缩放
- 缩放帧
- 幻灯片缩放
- 章节缩放
- 概要缩放
- 添加缩放
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 创建并自定义缩放 — 在 PPT、PPTX 和 ODP 演示文稿中跨章节跳转、添加缩略图和过渡效果。"
---

## **概述**
PowerPoint 中的缩放功能允许您在演示文稿的特定幻灯片、章节和部分之间跳转。演示时，这种快速跨内容导航的能力可能非常有用。 

![overview](overview.png)

* 要在单个幻灯片上概括整个演示文稿，请使用[Summary Zoom](#Summary-Zoom)。
* 只显示选定的幻灯片，请使用[Slide Zoom](#Slide-Zoom)。
* 只显示单个章节，请使用[Section Zoom](#Section-Zoom)。

## **幻灯片缩放**

幻灯片缩放可以使您的演示更加动态，允许您在任意顺序自由地在幻灯片之间导航，而不会中断演示的流畅性。幻灯片缩放非常适合章节不多的简短演示，但在其他演示场景中也可以使用。

幻灯片缩放帮助您在感觉像在同一画布上时，深入查看多个信息块。 

![slidezoomsel](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了[ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/) 枚举、[ZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) 类以及 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 类中的一些方法。

### **创建缩放帧**
您可以按以下方式在幻灯片上添加缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 创建您打算链接的新的幻灯片。  
3. 为创建的幻灯片添加识别文本和背景。  
4. 将缩放帧（包含对创建的幻灯片的引用）添加到第一张幻灯片。  
5. 将修改后的演示保存为 PPTX 文件。  

下面的示例代码展示了如何在幻灯片中创建缩放帧：
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
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # 保存演示文稿
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **使用自定义图像创建缩放帧**
使用 Aspose.Slides for Python via .NET，您可以通过以下方式创建使用非幻灯片预览图像的缩放帧： 
1. 创建一个 `Presentation` 类的实例。  
2. 创建您打算链接的新幻灯片。  
3. 为创建的幻灯片添加识别文本和背景。  
4. 通过向与 Presentation 对象关联的 Images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 对象，以填充帧。  
5. 将缩放帧（包含对创建的幻灯片的引用）添加到第一张幻灯片。  
6. 将修改后的演示保存为 PPTX 文件。  

下面的 Python 代码展示了如何使用不同的图像创建缩放帧：
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
在前面的章节中，我们展示了如何创建简单的缩放帧。要创建更复杂的缩放帧，您需要更改帧的格式。可以对缩放帧应用多种格式设置。 

您可以按以下方式控制幻灯片中缩放帧的格式：

1. 创建一个 `Presentation` 类的实例。  
2. 创建要链接的新幻灯片。  
3. 为创建的幻灯片添加识别文本和背景。  
4. 将缩放帧（包含对创建的幻灯片的引用）添加到第一张幻灯片。  
5. 通过向与 Presentation 对象关联的 Images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 对象，以填充帧。  
6. 为第一个缩放帧对象设置自定义图像。  
7. 更改第二个缩放帧对象的线条格式。  
8. 移除第二个缩放帧对象图像的背景。  
5. 将修改后的演示保存为 PPTX 文件。  

下面的 Python 示例代码展示了如何更改缩放帧的格式： 
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

章节缩放是指向演示文稿中某一章节的链接。您可以使用章节缩放返回您想要重点强调的章节，或用来突出演示文稿中某些部分之间的关联。 

![seczoomsel](seczoomsel.png)

对于章节缩放对象，Aspose.Slides 提供了[SectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) 类以及 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 类中的一些方法。

### **创建章节缩放帧**

您可以按以下方式向幻灯片添加章节缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加识别背景。  
4. 创建一个您打算链接的章节。  
5. 将章节缩放帧（包含对创建的章节的引用）添加到第一张幻灯片。  
6. 将修改后的演示保存为 PPTX 文件。  

下面的 Python 代码展示了如何在幻灯片上创建缩放帧：
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

    # 添加一个 SectionZoomFrame 对象
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **使用自定义图像创建章节缩放帧**

使用 Aspose.Slides for Python，您可以通过以下方式创建使用不同幻灯片预览图像的章节缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加识别背景。  
4. 创建一个您打算链接的章节。  
5. 通过向与 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象关联的 Images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 对象，以填充帧。  
6. 将章节缩放帧（包含对创建的章节的引用）添加到第一张幻灯片。  
7. 将修改后的演示保存为 PPTX 文件。  

下面的 Python 代码展示了如何使用不同的图像创建缩放帧：
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

    # 添加一个 SectionZoomFrame 对象
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **格式化章节缩放帧**

要创建更复杂的章节缩放帧，您需要更改简单帧的格式。可以对章节缩放帧应用多种格式选项。 

您可以按以下方式控制幻灯片中章节缩放帧的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加识别背景。  
4. 创建一个您打算链接的章节。  
5. 将章节缩放帧（包含对创建的章节的引用）添加到第一张幻灯片。  
6. 更改创建的章节缩放对象的大小和位置。  
7. 通过向与 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象关联的 Images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 对象，以填充帧。  
8. 为创建的章节缩放帧对象设置自定义图像。  
9. 设置*返回链接章节的原始幻灯片*的功能。  
10. 移除章节缩放帧对象图像的背景。  
11. 更改第二个缩放帧对象的线条格式。  
12. 更改过渡持续时间。  
13. 将修改后的演示保存为 PPTX 文件。  

下面的 Python 代码展示了如何更改章节缩放帧的格式：
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

    # SectionZoomFrame 的格式化
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


## **概要缩放**

概要缩放类似于一个登陆页，展示了演示文稿中所有部分。演示时，您可以使用缩放在演示的任意位置之间跳转，顺序自如。您可以发挥创意，快进或回看演示的某些部分，而不会打断演示的流畅性。

![overview_image](summaryzoom.png)

对于概要缩放对象，Aspose.Slides 提供了[SummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomframe/)、[SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/)和[SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) 类以及 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 类中的一些方法。

### **创建概要缩放**

您可以按以下方式向幻灯片添加概要缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 为创建的幻灯片创建带有识别背景和新章节的幻灯片。  
3. 将概要缩放帧添加到第一张幻灯片。  
4. 将修改后的演示保存为 PPTX 文件。  

下面的 Python 代码展示了如何在幻灯片上创建概要缩放帧：
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # 创建幻灯片数组
    for slideNumber in range(5):
        # 添加新幻灯片到演示文稿
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

        # 将 ReturnToParent 属性设为返回到第一张幻灯片
        zoomFrame.return_to_parent = True

    # 保存演示文稿
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```


### **添加和删除概要缩放章节**

所有概要缩放帧中的章节都由 [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/) 对象表示，存储在 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) 对象中。您可以通过以下方式使用 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) 类添加或删除概要缩放章节对象：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 为创建的幻灯片创建带有识别背景和新章节的幻灯片。  
3. 将概要缩放帧添加到第一张幻灯片。  
4. 向演示文稿中添加新幻灯片和章节。  
5. 将创建的章节添加到概要缩放帧。  
6. 从概要缩放帧中移除第一章节。  
7. 将修改后的演示保存为 PPTX 文件。  

下面的 Python 代码展示了如何在概要缩放帧中添加和删除章节：
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

    # 添加章节到 Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # 从 Summary Zoom 中移除章节
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # 保存演示文稿
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **格式化概要缩放章节**

要创建更复杂的概要缩放章节对象，您需要更改简单帧的格式。可以对概要缩放章节对象应用多种格式选项。 

您可以按以下方式控制概要缩放帧中章节对象的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 为创建的幻灯片创建带有识别背景和新章节的幻灯片。  
3. 将概要缩放帧添加到第一张幻灯片。  
4. 从 `SummaryZoomSectionCollection` 中获取第一个章节对象。  
5. 通过向与 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象关联的 images 集合中添加图像，创建一个 `PPImage` 对象，以填充帧。  
6. 为创建的章节缩放帧对象设置自定义图像。  
7. 设置*返回链接章节的原始幻灯片*的功能。  
8. 更改第二个缩放帧对象的线条格式。  
9. 更改过渡持续时间。  
10. 将修改后的演示保存为 PPTX 文件。  

下面的 Python 代码展示了如何更改概要缩放章节对象的格式：
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

    # 添加一个 SummaryZoomFrame 对象
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # 获取第一个 SummaryZoomSection 对象
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # 为 SummaryZoomSection 对象设置格式
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


## **FAQ**

**我可以控制在显示目标后返回“父”幻灯片吗？**

是的。[Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) 或 [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) 具有 `return_to_parent` 行为，启用后会在访问目标内容后将观看者返回到源幻灯片。

**我可以调整 Zoom 过渡的“速度”或持续时间吗？**

是的。Zoom 支持设置 `transition_duration`，您可以控制跳转动画的时长。

**演示文稿中可以包含多少个 Zoom 对象有上限吗？**

文档中没有硬性 API 限制。实际限制取决于演示的整体复杂度和查看器的性能。您可以添加大量 Zoom 帧，但需考虑文件大小和渲染时间。