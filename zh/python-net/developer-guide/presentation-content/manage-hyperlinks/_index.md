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
- 删除超链接
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
description: "使用 Aspose.Slides for Python via .NET，通过 Python 示例在 PowerPoint 和 OpenDocument 演示文稿中添加、格式化、更新和删除超链接。"
---
## **介绍**

超链接将演示内容连接到网站或演示文稿中的位置。在 PowerPoint 中，超链接通常有两个用途：

* 从文本、形状或媒体帧打开网站。
* 从目录等位置导航到另一张幻灯片。

Aspose.Slides for Python via .NET 允许您添加这些链接，控制其外观和声音，更新其属性，并将其删除。下面的示例展示了如何在单个元素上使用超链接，以及如何在演示文稿、幻灯片或文字框层级访问超链接。

{{% alert color="info" title="注意" %}}
您还可以使用[免费在线 Aspose PowerPoint 编辑器](https://products.aspose.app/slides/zh/editor)编辑演示文稿。
{{% /alert %}}

## **添加 URL 超链接**

您可以将网站 URL 分配给文本、形状或媒体帧。分配超链接的元素决定了可点击的区域：文本部分链接所选文本，而形状或帧则链接整个幻灯片对象。

### **向文本添加 URL 超链接**

要将文本链接到网站，请将一个[超链接]({{guid}})分配给文本部分的[hyperlink_click]({{guid}})属性，如下所示。只有该文本部分会变为可点击。

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

### **向形状和媒体帧添加 URL 超链接**

要使形状或帧可点击，请设置其[hyperlink_click]({{guid}})属性。超链接属于对象本身，而不是其中的文本部分。

相同的做法适用于图片、音频和视频帧：将超链接分配给帧，并在需要时设置链接的[tooltip]({{guid}})。

下面的示例使一个矩形可点击：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **使用超链接创建目录**

内部超链接允许读者从目录跳转到特定幻灯片。以下示例使用[set_internal_hyperlink_click]({{guid}})将第一页上的“第 2 页”文本链接到第二页。

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

### **颜色**

[Hyperlink]({{guid}})的[color_source]({{guid}})属性决定超链接是使用演示文稿的超链接颜色还是文本部分的格式。要应用自定义文本颜色，请选择[HyperlinkColorSource.PORTION_FORMAT]({{guid}})并设置该部分的填充颜色。此功能在 PowerPoint 2019 中引入；旧版本不支持此设置。

下面的示例在同一幻灯片上添加了两个文本超链接。第一个使用红色文本填充，第二个保留默认超链接颜色。

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

超链接可以在激活时播放声音，或停止已在播放的声音。使用以下属性配置这些行为：

- [Hyperlink.sound]({{guid}}) 指定与超链接关联的音频。
- [Hyperlink.stop_sound_on_click]({{guid}}) 控制激活超链接时是否停止先前的声音。

#### **添加超链接声音**

下面的示例加载 `sampleaudio.wav` 并将其关联到第一页上的一个按钮。单击按钮会播放声音并跳转到下一页。该页上的第二个形状在单击时停止先前的声音，但不执行跳转操作。

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

下面的示例打开上述创建的演示文稿，并通过[sound]({{guid}})和[binary_data]({{guid}})将第一个形状的超链接音频读取到内存中。

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

在为文本或形状分配超链接后，您可以更新以下[Hyperlink]({{guid}})属性：

- [tooltip]({{guid}}) 设置查看者在悬停时显示的提示文本。
- [target_frame]({{guid}}) 指定父 HTML frameset 中的目标框架（如果适用）。
- [history]({{guid}}) 控制激活链接时是否将其目标添加到已查看超链接列表。
- [highlight_click]({{guid}}) 控制点击时是否高亮显示超链接。

## **从演示文稿中删除超链接**

使用[get_any_hyperlinks]({{guid}})收集包括文字部分链接在内的所有超链接容器，然后再对其进行修改。下面的示例从第一页同时删除点击和鼠标悬停两种激活方式。若只删除一种，请仅调用[remove_hyperlink_click]({{guid}})或[remove_hyperlink_mouse_over]({{guid}})；删除点击操作不会删除其对应的鼠标悬停操作。

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

若要无条件删除，调用[remove_all_hyperlinks]({{guid}})可一次性在选定范围内删除两种激活方式。有关针对母版、版式和备注的选择性清理，请参阅[报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks)。

## **构建完整的超链接清单**

在分发演示文稿之前，先清点其交互操作及网络链接。[get_any_hyperlinks]({{guid}})返回[IHyperlinkContainer]({{guid}})对象，而不是 URL 字符串的平面列表。检查每个容器的[hyperlink_click]({{guid}})和[hyperlink_mouse_over]({{guid}})。它们是独立的：同一容器可以同时暴露两种操作，因此完整报告每个容器可能需要两行。

仅在形状层级扫描超链接会遗漏附加在文字部分的链接。请改为查询相应的范围，并保留返回的容器，以便后续更新或删除其操作。

### **查询演示文稿、幻灯片和文本框范围**

[HyperlinkQueries]({{guid}})类可通过[Presentation.hyperlink_queries]({{guid}})、[BaseSlide.hyperlink_queries]({{guid}})和[TextFrame.hyperlink_queries]({{guid}})访问。每个范围支持相同的查询：

- [get_hyperlink_clicks]({{guid}}) 返回具有点击操作的容器。
- [get_hyperlink_mouse_overs]({{guid}}) 返回具有鼠标悬停操作的容器。
- [get_any_hyperlinks]({{guid}}) 返回具有任一或两种操作的容器。

下面的示例创建 `hyperlink-audit-input.pptx`，其中包含外部点击链接、文件鼠标悬停链接、内部幻灯片导航、文字鼠标悬停链接以及宏操作。示例不执行任何这些操作。相同的三个查询在每个范围都可使用；计数描述的是容器数量，而非操作总数。文字框范围不包括包围形状本身的链接。

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

在此示例中，演示文稿和幻灯片查询各报告三个位点击容器、两个鼠标悬停容器以及三个任意操作容器。文字框查询在每个类别中报告一个容器。

### **对操作和目标进行分类**

使用[Hyperlink.action_type]({{guid}})在解析目标之前先解释操作类型。[HyperlinkActionType]({{guid}})的取值覆盖了除网页导航之外的多种情况：

| 值 | 审计含义 |
| --- | --- |
| `HYPERLINK` | 外部超链接；检查 URL 及其协议。 |
| `JUMP_SPECIFIC_SLIDE` | 跳转到特定幻灯片的内部导航。 |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | 内置幻灯片放映导航，在放映上下文中解析。 |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | 结束当前放映或启动自定义放映。 |
| `START_MACRO` | 执行宏。 |
| `START_PROGRAM` | 启动程序。 |
| `OPEN_FILE`, `OPEN_PRESENTATION` | 打开文件或其他演示文稿；需与网页 URL 分别审查。 |
| `START_STOP_MEDIA` | 开始或停止媒体播放。 |
| `NO_ACTION`, `UNKNOWN` | 无导航操作，或未知需要审查的操作。 |

从[external_url]({{guid}})读取外部目标，从[target_slide]({{guid}})读取特定内部目标。内部操作和内置命令可能没有外部 URL；空 URL 并不表示容器没有操作。当[external_url_original]({{guid}})与规范化 URL 不同时时请保留，并在可用时包含[tooltip]({{guid}})。

### **报告、清理和验证超链接**

以下 Python 示例读取已有演示文稿（使用上面创建的文件），写入 `hyperlink-audit.json`，应用策略，保存为 `hyperlink-sanitized.pptx`，并重新打开检查两种激活方式。示例在修改前收集容器，并在每个幻灯片范围只查询一次以避免重复处理。演示文稿查询覆盖普通幻灯片；若要对整个包进行清点，示例还查询普通幻灯片、母版、版式、备注以及可能存在的备注和讲义母版。

报告记录基于 1 的幻灯片索引和[slide_id]({{guid}})（若可用）。收集器在每个返回的容器旁保留所属幻灯片和范围。母版、版式和备注没有普通幻灯片索引，使用其范围标识。形状容器和文字部分格式容器单独标记；其他容器类型保留其运行时类型名称。每个容器获得报告本地 ID，以便关联其两个操作。

此限制性策略只允许绝对 HTTPS URL 和有效的内部幻灯片目标。它会拒绝宏、程序、文件操作、其他放映操作、未知操作以及除 HTTPS 之外的 URL 方案。这些拒绝是策略决定，而非 Aspose.Slides 的安全判定。仅 HTTPS 并不意味着可信：请为您的应用添加主机白名单和其他检查。原始和规范化的外部 URL 都会被检查。示例仅审计元数据，不会跟随链接或执行操作。

若需整改，容器的[hyperlink_manager]({{guid}})支持[set_external_hyperlink_click]({{guid}})、[remove_hyperlink_click]({{guid}})和[remove_hyperlink_mouse_over]({{guid}})。在此示例中，受限的外部点击链接被替换为固定的 HTTPS 登录页；其他受限的点击和受限的鼠标悬停操作分别被删除。将 `replace_external_clicks` 设置为 `False` 可删除所有策略违规项。请在部署前选择由应用拥有的替代页面。

报告的导出标记使用保守的 PDF 审查策略：将鼠标悬停操作以及除外部链接或特定幻灯片跳转外的任何操作标记为可能不受支持。这是一种审查提示，而非功能测试或对未标记链接在导出后仍可用的保证。受支持的[PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)和[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)导出可能会保留超链接，具体取决于操作、导出选项和查看器。栅格[图像](/slides/zh/python-net/convert-powerpoint-to-png/)和[视频](/slides/zh/python-net/convert-powerpoint-to-video/)无法保留交互式超链接；在审计这些输出时请标记每个操作。

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
    # 查询每个幻灯片范围一次，并保留其拥有者与每个容器关联。
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

使用上述输入，报告包含五行操作。文件鼠标悬停链接和宏点击被删除，HTTPS 链接和内部幻灯片导航保留。验证阶段打印零个违规操作。包含受限外部点击 URL 的输入还会触发替换分支。一个允许的点击加上受限的鼠标悬停会保留其点击操作。

此选择性清理不同于[remove_all_hyperlinks]({{guid}})，后者在选定范围内无论策略如何都移除两种激活方式。此处的验证仅检查超链接操作，不会删除嵌入的 VBA 项目、OLE 对象或其他活动内容，也不对导出的 PDF 或 HTML 文件进行验证。

## **常见问题**

**如何链接到某个分节或其第一张幻灯片？**

PowerPoint 中的分节用于分组幻灯片，但内部超链接只能定位到单个幻灯片。若要实现分节导航，请链接到该分节的第一张幻灯片。

**我可以将超链接附加到母版幻灯片元素，使其在所有幻灯片上工作吗？**

可以。母版幻灯片和版式元素都支持超链接。使用相应母版或版式的幻灯片在放映时会保留这些链接。

**导出为 PDF、HTML、图像或视频时，超链接会被保留吗？**

支持的 PDF 和 HTML 导出可能会保留超链接；栅格图像和视频则不能保留交互式超链接。请参阅[报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks)中的导出注意事项。