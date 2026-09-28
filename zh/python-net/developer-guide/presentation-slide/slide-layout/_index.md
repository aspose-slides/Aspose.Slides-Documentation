---
title: 应用或更改 Python 中的幻灯片布局
linktitle: 幻灯片布局
type: docs
weight: 60
url: /zh/python-net/slide-layout/
keywords:
- 幻灯片布局
- 内容布局
- 占位符
- 演示文稿设计
- 幻灯片设计
- 未使用的布局
- 页脚可见性
- 标题幻灯片
- 标题和内容
- 部分标题
- 双内容
- 对比
- 仅标题
- 空白布局
- 带说明的内容
- 带说明的图片
- 标题和垂直文本
- 垂直标题和文本
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中应用、创建和修改幻灯片布局，添加占位符，删除未使用的布局，并控制页脚可见性。"
---
## **概述**

幻灯片布局定义了占位符（如标题、文本、图片、图表和表格）的位置和格式。应用布局可为幻灯片提供一致的结构，同时允许每张幻灯片包含各自的内容。

最常见的布局包括：

- **Title Slide**：包含标题和副标题占位符。
- **Title and Content**：包含标题占位符和通用内容占位符。
- **Blank**：不包含内容占位符，适用于需要手动定位每个形状的情况。

## **了解布局继承**

演示文稿有三个相关层级：

1. A [母版幻灯片](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslide/) 定义主题、共享格式、背景和公共对象。
1. A [布局幻灯片](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutslide/) 属于母版并定义特定的占位符排列。
1. A [普通幻灯片](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/) 使用一个布局并存储该幻灯片输入的内容。

普通幻灯片从其布局继承主题和格式，布局又从其母版继承。直接在普通幻灯片上设置的值会覆盖该层级继承的值。创建普通幻灯片时，其占位符形状由选定的布局生成，而输入到这些占位符的内容属于普通幻灯片。

在从布局创建幻灯片之前，请先向布局添加所需的占位符。之后向布局添加另一个占位符不会自动在已有的普通幻灯片中添加相应的占位符形状。

此关系有两个重要的后果：

- 更改布局上继承的格式或现有占位符的几何形状会更新所有依赖它的幻灯片。在编辑已在使用的布局之前，检查其依赖的幻灯片并审阅生成的演示文稿。
- 仍被幻灯片使用的布局无法删除。请先将其依赖的幻灯片重新分配到其他布局，或仅删除未使用的布局。

有关此层级最高级别的更多信息，请参阅[Slide Master](/slides/zh/python-net/slide-master/)。

要在单个幻灯片或通过共享布局隐藏继承的徽标或装饰性母版形状，请参阅[Control the Visibility of Master Graphics](/slides/zh/python-net/slide-master/)。示例比较了使用相同母版的两个幻灯片。

## **选择并应用幻灯片布局**

当演示文稿遵循标准 PowerPoint 布局定义时，请使用布局类型。布局名称可由用户编辑并可本地化，因此除非您控制源模板，否则基于名称的选择可靠性较低。

以下示例在第一个母版上查找**Title and Content**。如果该布局不可用，则有意回退到**Blank**。第二个空检查是必要的，因为演示文稿可能仅包含自定义布局。随后通过[Slide.layout_slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/layout_slide/)属性将选定的布局应用于第一个普通幻灯片。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

更改幻灯片的布局不会移除直接添加到幻灯片的普通形状。然而，占位符位置、继承的格式以及现有占位符与新布局之间的对应关系可能会改变，因此在在差异较大的布局之间切换时请检查输出。

## **添加布局幻灯片**

选择和创建是分开的操作。前面的示例仅选择了已有布局；并未创建新布局。若要创建布局，请在目标母版的布局集合上调用[MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterlayoutslidecollection/add/)方法。

以下示例始终添加一个名为`Report Title and Content`的新**Title and Content**布局，然后基于该布局添加普通幻灯片。布局名称在集合中必须唯一。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

仅在模板确实需要另一个可复用结构时才添加布局。如果已存在合适的布局，请选择并复用它，而不是创建重复的布局。

## **向布局幻灯片添加占位符**

[LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutslide/placeholder_manager/)属性提供一个[LayoutPlaceholderManager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutplaceholdermanager/)用于向布局添加占位符形状。

| PowerPoint 占位符               | `LayoutPlaceholderManager` 方法 |
| -------------------------------- | --------------------------------- |
| ![内容](content.png)             | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![内容（垂直）](contentV.png)    | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![文本](text.png)                 | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![文本（垂直）](textV.png)       | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![图片](picture.png)             | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![图表](chart.png)               | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![表格](table.png)               | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)        | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![媒体](media.png)               | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![在线图片](onlineImage.png)     | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

以下示例验证**Blank**布局是否存在，向其添加四个占位符，然后创建使用修改后布局的普通幻灯片。顺序是特意安排的：先添加占位符再创建普通幻灯片，以便 Aspose.Slides 能在该幻灯片上生成相应的占位符形状。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![布局幻灯片上的占位符](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
更改继承的格式或现有布局占位符的几何形状可能影响依赖的幻灯片。新添加的布局占位符不会回填到已有的普通幻灯片中。请在演示文稿的副本上测试布局更改，并检查每个依赖的幻灯片。
{{% /alert %}}

## **删除未使用的布局幻灯片**

使用[Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/)方法删除没有普通幻灯片引用的布局。该方法会保留仍在使用中的布局。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

若要删除特定布局，请先使用其[has_depending_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutslide/has_depending_slides/)属性或[get_depending_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutslide/get_depending_slides/)方法。重新分配所有依赖的幻灯片后再调用[LayoutSlide.remove](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutslide/remove/)。尝试删除正在使用的布局会抛出[PptxEditException](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pptxeditexception/)。

## **控制布局幻灯片的页脚可见性**

布局拥有自己的页脚、幻灯片编号和日期时间占位符。使用[LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutslide/header_footer_manager/)属性可针对单个布局控制这些占位符。这在例如内容布局需要显示页脚而标题布局不需要时非常实用。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **控制母版及其子布局的页脚可见性**

要在整个母版层级中应用一致的页脚设置，请使用[MasterSlide.header_footer_manager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslide/header_footer_manager/)属性。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslideheaderfootermanager/)的传播方法作用于母版及其依赖的布局幻灯片和普通幻灯片；它们不会仅针对单个普通幻灯片。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**母版幻灯片和布局幻灯片有什么区别？**

母版幻灯片定义演示文稿的主题和共享格式。布局幻灯片隶属于母版，定义一种可复用的占位符排列。普通幻灯片使用这些布局并存储特定于幻灯片的内容。

**我可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以。使用[add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/globallayoutslidecollection/add_clone/)方法将副本添加到目标集合。跨演示文稿复制时，还需确认源布局使用的字体、主题、图像和其他资源。

**当我修改已在使用的布局时会发生什么？**

除非在本地覆盖了受影响的格式或对象，否则依赖的幻灯片会继承布局的更改。占位符几何和继承的样式因此可能一次性在多张幻灯片上改变。编辑布局前，可使用[get_depending_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutslide/get_depending_slides/)识别受影响的幻灯片。

**如果我删除仍在使用的布局会怎样？**

Aspose.Slides 会抛出[PptxEditException](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pptxeditexception/)。请先重新分配依赖的幻灯片，或使用[remove_unused_layout_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/)仅删除未被引用的布局。