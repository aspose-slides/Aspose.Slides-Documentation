---
title: 管理超链接
type: docs
weight: 20
url: /zh/python-net/manage-hyperlinks/
keywords: "添加超链接, PowerPoint演示文稿, PowerPoint超链接, 文本超链接, 幻灯片超链接, 图形超链接, 图片超链接, 视频超链接, Python"
description: "在Python中向PowerPoint演示文稿添加超链接"
---

超链接是对某个对象、数据或某个位置的引用。这些是PowerPoint演示文稿中常见的超链接：

* 文本、图形或媒体中的网站链接
* 幻灯片链接

Aspose.Slides for Python via .NET允许您执行涉及演示文稿中超链接的多项任务。

{{% alert color="primary" %}} 

您可能想查看Aspose简单的[免费在线PowerPoint编辑器。](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **添加URL超链接**

### **向文本添加URL超链接**

下面的Python代码演示了如何向文本添加网站超链接：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: 文件格式API")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "超过70%的财富100强公司信任Aspose API"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32
    
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **向图形或框架添加URL超链接**

下面的Python示例代码演示了如何向图形添加网站超链接：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "超过70%的财富100强公司信任Aspose API"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

### **向媒体添加URL超链接**

Aspose.Slides允许您向图片、音频和视频文件添加超链接。

下面的示例代码演示了如何向**图片**添加超链接：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # 向演示文稿添加图像
    with open("img.jpeg", "rb") as fs:
        data = fs.read()
        image = pres.images.add_image(data)
        
        # 基于之前添加的图像在幻灯片1上创建图片框架
        pictureFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

        pictureFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        pictureFrame.hyperlink_click.tooltip = "超过70%的财富100强公司信任Aspose API"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

下面的代码示例演示了如何向**音频文件**添加超链接：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("audio.mp3", "rb") as fs:
        data = fs.read()
        audio = pres.audios.add_audio(data)
        
        audioFrame = pres.slides[0].shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

        audioFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        audioFrame.hyperlink_click.tooltip = "超过70%的财富100强公司信任Aspose API"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

下面的代码示例演示了如何向**视频**添加超链接：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("video.avi", "rb") as fs:
        data = fs.read()
        video = pres.videos.add_video(data)
        
        videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 100, 100, video)

        videoFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        videoFrame.hyperlink_click.tooltip = "超过70%的财富100强公司信任Aspose API"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert  title="提示"  color="primary"  %}} 

您可能想查看 *[管理OLE](https://docs.aspose.com/slides/python-net/manage-ole/)*。

{{% /alert %}}



## **使用超链接创建目录**

由于超链接允许您添加对对象或位置的引用，因此您可以使用它们创建目录。

下面的示例代码展示了如何创建带有超链接的目录：

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
    paragraph.text = "幻灯片2的标题 .......... "

    linkPortion = slides.Portion()
    linkPortion.text = "第2页"
    linkPortion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(linkPortion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```



## **格式化超链接**

### **颜色**

通过[IHyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)接口中的[color_source](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)属性，您可以设置超链接的颜色，并从超链接中获取颜色信息。此功能首次在PowerPoint 2019中引入，因此涉及该属性的更改不适用于旧版本的PowerPoint。

下面的示例代码演示了在同一幻灯片中添加不同颜色的超链接的操作：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("这是一个彩色超链接的示例。")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.fill_type = slides.FillType.SOLID
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("这是一个普通超链接的示例。")
    shape2.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```



## **删除演示文稿中的超链接**

### **从文本中删除超链接**

下面的Python代码演示了如何从演示文稿幻灯片中的文本中删除超链接：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    portion.portion_format.hyperlink_manager.remove_hyperlink_click()
    pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **从图形或框架中删除超链接**

下面的Python代码演示了如何从演示文稿幻灯片中的图形中删除超链接：

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as pres:
   slide = pres.slides[0]
   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()
   pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```



## **可变超链接**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink)类是可变的。使用此类，您可以更改以下属性的值：

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.History](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)

下面的代码片段展示了如何向幻灯片添加超链接并稍后编辑其工具提示：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: 文件格式API")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "超过70%的财富100强公司信任Aspose API"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```




## **IHyperlinkQueries中的受支持属性**

您可以从定义超链接的演示文稿、幻灯片或文本中访问IHyperlinkQueries。

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)

IHyperlinkQueries类支持以下方法和属性：

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)