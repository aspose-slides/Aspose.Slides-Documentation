---
title: 在 Python 中管理演示文稿超链接
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
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，在 PowerPoint 和 OpenDocument 演示文稿中添加、格式化、更新和移除超链接，提供 Python 示例。"
---
## **介绍**

超链接将演示文稿内容连接到网站或演示文稿内部的某个位置。 在 PowerPoint 中，超链接通常有两个作用：

* 从文本、形状或媒体框打开网站。
* 从目录等位置跳转到另一张幻灯片。

Aspose.Slides for Python via .NET 允许您添加这些链接，控制其外观和声音，更新属性，并将其移除。下面的示例展示了如何在单个元素上操作超链接，以及如何在演示文稿、幻灯片或文本框层级访问超链接。

{{% alert color="info" title="Note" %}}
您还可以使用[免费在线 Aspose PowerPoint 编辑器](https://products.aspose.app/slides/editor)编辑演示文稿。
{{% /alert %}}

## **添加 URL 超链接**

您可以为文本、形状或媒体框分配网站 URL。分配超链接的元素决定了可点击区域：文本部分会使所选文本可点击，形状或框则使整个对象可点击。

对于包含相对超链接的演示文稿，请参阅[管理超链接基准](/slides/zh/python-net/presentation-properties/#manage-the-hyperlink-base)以读取、更改或清除文档级基准。

### **向文本添加 URL 超链接**

要将文本链接到网站，请将[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/)分配给文本部分的[hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/)属性，如下所示。只有该文本部分会变为可点击。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **向形状和媒体框添加 URL 超链接**

将 URL 分配给矩形的[hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/)属性，使其整个区域可点击。[tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) 在鼠标悬停时向阅读者提示目标。相同的属性适用于图片、音频和视频框。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **使用超链接创建目录**

内部超链接可让阅读者从目录跳转到特定幻灯片。下面的示例使用[set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/)将第一页上的“Page 2”文本链接到第二页。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **格式化超链接**

您可以更改链接文本的颜色，在阅读者激活链接时播放或停止声音，并设置悬停时显示的提示信息。

### **颜色**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/)的[color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/)属性决定超链接是使用演示文稿的超链接颜色还是文本部分的格式。若要应用自定义文本颜色，请选择[HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/)并设置该部分的填充颜色。此功能在 PowerPoint 2019 中引入；旧版本不适用此设置。

在本例中，对第一个链接设置[color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/)后，其文本显示为红色。第二个链接保持演示文稿的超链接颜色。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **声音**

超链接可以在激活时播放声音，或停止正在播放的声音。使用以下属性配置这些行为：

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) 指定与超链接关联的音频。
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) 控制激活超链接时是否停止先前的声音。

#### **添加超链接声音**

第一页上的按钮使用[sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/)在阅读者点击前进时播放 WAV 文件中的音频。第二页的另一个按钮使用[stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/)停止播放并保持阅读者停留在该页。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **提取超链接声音**

以下示例打开上面创建的演示文稿，并通过[sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/)和[binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/)将第一个形状的超链接音频读取到内存中。

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **提示和交互设置**

在为文本或形状分配超链接后，您可以更新以下[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/)属性：

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) 设置阅读者可显示的提示文字。
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) 指定在父 HTML 框架集中目标框架（如适用）。
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) 控制激活链接时是否将其目的地加入已查看超链接列表。
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) 控制点击时是否高亮显示超链接。

## **从演示文稿中移除超链接**

使用[get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)收集包括文本段落链接在内的超链接容器，然后再对其进行更改。下面的示例从第一页移除两种激活类型。若只想移除一种类型，请仅调用[remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/)或[remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/)；移除点击操作不会删除其鼠标悬停对应操作。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

如需无条件移除，[remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) 在一次调用中移除所选范围内的两种激活类型。若要有选择地清理并覆盖母版、布局和备注，请参阅[报告、清理并验证超链接](#report-sanitize-and-verify-hyperlinks)。

### **在替换 SmartArt 文本前清除超链接**

当在现有 SmartArt 节点中替换段落时，清除其文本段落可能会留下旧的超链接。通过[SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/)获取段落。清除其段落前，调用位于节点形状文本框的[hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/)的[remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)以移除该框中所有超链接，包括其他段落中的链接。

在 `SmartArtHyperlink.pptx` 中，第一页的第三个形状是一幅 SmartArt 图形。示例替换了其第四个节点的第一段落。该节点的第一个形状显示该段落。

在添加两段后，示例使用[get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/)读取它们的有效格式。有效的[hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/)属性返回第一段的新超链接，第二段返回 `None`。

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # None
```

## **构建完整的超链接清单**

在分发演示文稿之前，清点其交互操作以及网页链接。[get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) 返回[IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) 对象，而不是 URL 字符串的平面列表。检查每个容器上的[hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/)和[hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/)。它们是独立的：同一容器可以同时暴露两种操作，因此完整报告需要每个容器最多两行。

仅扫描形状层级的超链接可能会错过附加在文本段落上的链接。请查询适当的范围，并保留返回的容器，以便后续更新或移除其操作。

### **查询演示文稿、幻灯片和文本框范围**

[HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) 类可通过[Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)、[BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)和[TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/)访问。每个范围支持相同的查询：

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) 返回带有点击操作的容器。
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) 返回带有鼠标悬停操作的容器。
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) 返回带有任意或两种操作的容器。

此示例为形状及其文字分配点击和鼠标悬停操作，并为另一个按钮分配宏操作。它将[get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)返回的容器数量与每种激活类型的计数进行比较。文本框查询仅统计文本中的链接。包含的形状自身的操作出现在幻灯片和演示文稿查询中。

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

在本例中，演示文稿和幻灯片查询各报告三个点击容器、两个鼠标悬停容器以及三个任意操作容器。文本框查询在每个类别中报告一个容器。

### **对操作和目的地进行分类**

使用[Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/)在解释目的地之前先解释操作。[HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) 的取值覆盖了除网页导航之外的更多场景：

| 值 | 审计含义 |
| --- | --- |
| `HYPERLINK` | 外部超链接；检查 URL 及其方案。 |
| `JUMP_SPECIFIC_SLIDE` | 跳转到特定幻灯片的内部导航。 |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | 内置幻灯片放映导航，在放映上下文中解析。 |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | 结束当前放映或启动自定义放映。 |
| `START_MACRO` | 执行宏。 |
| `START_PROGRAM` | 启动程序。 |
| `OPEN_FILE`, `OPEN_PRESENTATION` | 打开文件或其他演示文稿；需单独审查，区别于网页 URL。 |
| `START_STOP_MEDIA` | 启动或停止媒体播放。 |
| `NO_ACTION`, `UNKNOWN` | 无导航操作，或需复审的未识别操作。 |

通过[external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/)读取外部目的地，通过[target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/)读取特定内部目的地。内部操作和内置命令可能没有外部 URL；空 URL 并不意味着容器没有操作。若[external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) 与规范化 URL 不同，请保留原始值，并在可用时包括[tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/)。

### **报告、清理并验证超链接**

此示例打开前述演示文稿，并为每个操作写入一条 JSON 记录。它使用[get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)收集普通幻灯片、母版、布局和备注（包括备注母版和讲义母版）中的容器。为避免重复处理，每个范围查询一次，应用下述策略后重新打开保存的演示文稿以检查点击和鼠标悬停操作。

报告记录基于 1 的幻灯片索引和[slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/)（如有）。收集器保留所属幻灯片和范围信息。母版、布局和备注没有普通幻灯片索引，以其范围标识。形状容器和文本段落格式容器单独标记；其他容器类型保留其运行时类型名称。每个容器获得报告本地 ID，以便关联其两个操作。

本限制性应用策略仅允许绝对 HTTPS URL 和有效的内部幻灯片目标。它会拒绝宏、程序、文件操作、其他放映操作、未知操作以及其他 URL 方案。这些拒绝是策略决策，不代表 Aspose.Slides 的安全性判断。仅 HTTPS 并不等同于信任：请为您的应用添加主机白名单和其他检查。原始和规范化的外部 URL 都会被检查。示例在不跟随链接或执行操作的情况下审计元数据。

若需修复，容器的[hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) 支持[set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/)、[remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/)以及[remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/)。这里，将被禁止的外部点击链接替换为固定的 HTTPS 着陆页；其他被禁止的点击和鼠标悬停操作则独立移除。将 `replace_external_clicks` 设置为 `False` 可删除所有策略违规项。请在部署前选择由应用拥有的替换页面。

报告的导出标记采用保守的 PDF 审核策略：将鼠标悬停操作以及除外部链接或特定幻灯片跳转之外的任何操作标记为可能不受支持。这是审阅提示，而非功能测试或对未标记链接在导出后仍能存活的保证。受支持的[PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)和[HTML](/slides/zh/python-net/convert-powerpoint-to-html/) 导出可能会保留超链接，取决于操作、导出选项和查看器。光栅[图片](/slides/zh/python-net/convert-powerpoint-to-png/)和[视频](/slides/zh/python-net/convert-powerpoint-to-video/) 则无法保留交互式超链接；在对这些输出进行审计时请标记每个操作。

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # 查询每个幻灯片范围一次，并保留每个容器的所有者。
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

使用上述输入创建的报告包含五行操作。文件鼠标悬停链接和宏点击被移除，而 HTTPS 链接和内部幻灯片导航保留。验证输出零个违规操作。包含被禁止外部点击 URL 的输入还演示了替换分支。一个容器具有允许的点击和被禁止的鼠标悬停时，仅保留其点击操作。

此选择性清理不同于[remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)，后者在所选范围内不考虑策略，移除两种激活类型。此处的验证仅检查超链接操作；它不会移除嵌入的 VBA 项目、OLE 对象或其他活动内容，也不验证导出的 PDF 或 HTML 文件。

## **常见问题**

**如何链接到某个章节或其第一张幻灯片？**

PowerPoint 中的章节将幻灯片分组，但内部超链接只能定位到单个幻灯片。若要实现章节导航，请链接到该章节的第一张幻灯片。

**我可以将超链接附加到母版幻灯片元素，使其在所有幻灯片上都有效吗？**

可以。母版幻灯片和布局元素支持超链接。这些元素上的链接在使用相应母版或布局的幻灯片放映期间可用。

**导出为 PDF、HTML、图片或视频时会保留超链接吗？**

受支持的 PDF 和 HTML 导出可能会保留超链接；光栅图片和视频则不能。请参阅[报告、清理并验证超链接](#report-sanitize-and-verify-hyperlinks)中的导出注意事项。