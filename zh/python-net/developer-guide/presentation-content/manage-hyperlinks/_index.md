---
title: 使用 Python 管理演示文稿中的超链接
linktitle: 管理超链接
type: docs
weight: 20
url: /zh/python-net/manage-hyperlinks/
keywords:
- 添加 URL
- 添加超链接
- 创建超链接
- 格式化超链接
- 移除超链接
- 更新超链接
- 文本超链接
- 幻灯片超链接
- 形状超链接
- 图像超链接
- 视频超链接
- 可变超链接
- PowerPoint
- OpenDocument
- 演示文稿
- Python
description: "使用 Aspose.Slides for Python via .NET，轻松管理 PowerPoint 和 OpenDocument 演示文稿中的超链接——在几分钟内提升交互性和工作流程。"
---

## **概述**

超链接是指向外部资源、对象或数据项，或指向文件内特定位置的引用。PowerPoint 演示文稿中常见的超链接类型包括：

* 嵌入在文本、形状或媒体中的网站链接
* 幻灯片链接

Aspose.Slides for Python via .NET 在演示文稿中提供了广泛的超链接相关操作。

## **添加 URL 超链接**

本节介绍在使用 Aspose.Slides 时如何向幻灯片元素添加 URL 超链接。它涵盖了为文本、形状和图片分配链接地址，以确保演示期间的顺畅导航。

### **为文本添加 URL 超链接**

以下代码示例展示了如何为文本添加网站超链接：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **为形状或框架添加 URL 超链接**

以下代码示例展示了如何为形状添加网站超链接：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **为媒体添加 URL 超链接**

Aspose.Slides 允许您向图像、音频和视频文件添加超链接。

以下代码示例展示了如何为 **图像** 添加超链接：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 向演示文稿添加图像。
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # 使用之前添加的图像在第 1 张幻灯片上创建图片框。
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


以下代码示例展示了如何为 **音频文件** 添加超链接：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


以下代码示例展示了如何为 **视频** 添加超链接：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Tip" color="primary" %}}

您可能想了解[使用 Python 管理演示文稿中的 OLE](/slides/zh/python-net/manage-ole/)。

{{% /alert %}}

## **使用超链接创建目录**

由于超链接可以引用对象或位置，您可以使用它们来构建目录。

下面的示例代码展示了如何使用超链接创建目录：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```


## **格式化超链接**

本节展示了如何在 Aspose.Slides 中格式化超链接的外观。您将学习如何控制颜色和其他样式选项，以在文本、形状和图片之间保持超链接格式的一致性。

### **超链接颜色**

使用 [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) 类的 [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) 属性，您可以设置超链接的颜色并读取其颜色信息。此功能在 PowerPoint 2019 中引入，因而通过该属性进行的更改不适用于早期版本的 PowerPoint。

以下示例演示了如何在同一幻灯片上添加不同颜色的超链接：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```


## **从演示文稿中移除超链接**

本节解释了在使用 Aspose.Slides 时如何从演示文稿中移除超链接。您将学习如何在保留原始内容和格式的同时，清除文本、形状和图片的链接目标。

### **从文本中移除超链接**

以下示例代码展示了如何从演示文稿幻灯片上的文本中移除超链接：
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```


### **从形状或框架中移除超链接**

以下示例代码展示了如何从演示文稿幻灯片上的形状中移除超链接：
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```


## **可变超链接**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) 类是可变的。使用此类，您可以更改以下属性的值：

- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

以下代码片段展示了如何向幻灯片添加超链接并随后编辑其提示信息：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **IHyperlinkQueries 支持的属性**

您可以从演示文稿、幻灯片或包含超链接的文本中访问 [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/)。

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/)

[HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) 类支持以下方法：

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}

您可能想尝试 Aspose 提供的免费在线[PowerPoint 编辑器](https://products.aspose.app/slides/editor)。

{{% /alert %}}

## **常见问题**

**如何创建不仅指向幻灯片，还指向“节”或节的第一张幻灯片的内部导航？**

PowerPoint 中的节是幻灯片的分组；导航技术上定位到具体的幻灯片。要“导航到节”，通常链接到该节的第一张幻灯片。

**我可以将超链接附加到母版幻灯片元素上，以便在所有幻灯片上生效吗？**

可以。母版幻灯片和布局元素支持超链接。这些链接会出现在子幻灯片上，并在放映时可点击。

**导出为 PDF、HTML、图像或视频时，超链接会被保留吗？**

在[PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)和[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)中，超链接通常会被保留。导出为[图像](/slides/zh/python-net/convert-powerpoint-to-png/)和[视频](/slides/zh/python-net/convert-powerpoint-to-video/)时，由于这些格式的本质（光栅帧/视频不支持超链接），点击功能不会被保留。