---
title: 在 Python 中应用或更改幻灯片布局
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
- 节标题
- 双内容
- 对比
- 仅标题
- 空白布局
- 带标题的内容
- 带标题的图片
- 标题和垂直文本
- 垂直标题和文本
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python（通过 .NET）中管理和自定义幻灯片布局。探索布局类型、占位符控制、页脚可见性以及通过 Python 代码示例进行布局操作。"
---

## **概述**

幻灯片布局定义了占位框的排列方式以及幻灯片内容的格式。它控制哪些占位符可用以及它们出现的位置。幻灯片布局帮助您快速且一致地设计演示文稿——无论是创建简单的还是更复杂的内容。PowerPoint 中最常见的幻灯片布局包括：

**Title Slide layout** – 包含两个文本占位符：一个用于标题，另一个用于副标题。

**Title and Content layout** – 在顶部提供较小的标题占位符，在其下方提供更大的占位符，用于主要内容（如文本、项目符号、图表、图像等）。

**Blank layout** – 不包含任何占位符，您可以完全自行从头设计幻灯片。

幻灯片布局是幻灯片母版的一部分，母版是定义演示文稿布局样式的顶层幻灯片。您可以通过母版访问和修改布局幻灯片——可以按类型、名称或唯一 ID 进行操作。或者，您也可以直接在演示文稿中编辑特定的布局幻灯片。

要在 Aspose.Slides for Python 中使用幻灯片布局，您可以使用：

- 属性，例如 [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) 和 [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/)，位于 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类下
- 类型，例如 [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/)、[LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) 和 [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

了解更多关于母版幻灯片的使用，请查看 [在 Python 中管理 PowerPoint 幻灯片母版](/slides/zh/python-net/slide-master/) 文章。

{{% /alert %}}

## **向演示文稿添加幻灯片布局**

若要自定义幻灯片的外观和结构，您可能需要向演示文稿中添加新的布局幻灯片。Aspose.Slides for Python 允许您检查特定布局是否已存在，必要时添加新布局，并使用该布局插入幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 访问 [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/)。
1. 检查所需的布局幻灯片是否已存在于集合中。如果不存在，则添加所需的布局幻灯片。
1. 基于新布局幻灯片添加空白幻灯片。
1. 保存演示文稿。

以下 Python 代码演示了如何向 PowerPoint 演示文稿添加幻灯片布局：
```python
import aspose.slides as slides

    # 实例化 Presentation 类以打开演示文稿文件。
    with slides.Presentation("sample.pptx") as presentation:
        # 遍历布局幻灯片类型以选择布局幻灯片。
        layout_slides = presentation.masters[0].layout_slides
        layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
        if layout_slide is None:
             layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

        if layout_slide is None:
            # 演示文稿不包含所有布局类型的情况。
            # 演示文稿文件仅包含 Blank 和 Custom 布局类型。
            # 但是，具有自定义类型的布局幻灯片可能有可识别的名称，
            # 如 “Title”、 “Title and Content”等，可用于布局幻灯片选择。
            # 也可以依赖一组占位符形状类型。
            # 例如，标题幻灯片应仅包含 Title 占位符类型，依此类推。
            for title_and_object_layout_slide in layout_slides:
                if title_and_object_layout_slide.name == "Title and Object":
                    layout_slide = title_and_object_layout_slide
                    break

            if layout_slide is None:
                for title_layout_slide in layout_slides:
                    if title_layout_slide.name == "Title":
                        layout_slide = title_layout_slide
                        break

                if layout_slide is None:
                    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                    if layout_slide is None:
                        layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

        # 使用添加的布局幻灯片插入空白幻灯片。
        presentation.slides.insert_empty_slide(0, layout_slide)

        # 将演示文稿保存到磁盘。
        presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **删除未使用的布局幻灯片**

Aspose.Slides 提供了位于 [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) 类中的 [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) 方法，以便删除不需要的未使用布局幻灯片。

以下 Python 代码展示了如何从 PowerPoint 演示文稿中删除布局幻灯片：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **向布局幻灯片添加占位符**

Aspose.Slides 提供了 [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/placeholder_manager/) 属性，允许您向布局幻灯片添加新的占位符。

该管理器包含以下占位符类型对应的方法：

| PowerPoint 占位符                 | [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) 方法 |
| --------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)           | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Content (Vertical)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Text](text.png)                 | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Text (Vertical)](textV.png)     | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Picture](picture.png)           | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Chart](chart.png)               | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Table](table.png)               | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png)         | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png)               | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Online Image](onlineimage.png)  | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

以下 Python 代码演示了如何向 Blank 布局幻灯片添加新的占位符形状：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 获取 Blank 布局幻灯片。
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # 获取布局幻灯片的占位符管理器。
    placeholder_manager = layout.placeholder_manager

    # 向 Blank 布局幻灯片添加不同的占位符。
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # 使用 Blank 布局添加新幻灯片。
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![The placeholders on the layout slide](add_placeholders.png)

## **设置布局幻灯片的页脚可见性**

在 PowerPoint 演示文稿中，页脚元素（如日期、幻灯片编号和自定义文本）可以根据幻灯片布局显示或隐藏。Aspose.Slides for Python 允许您控制这些页脚占位符的可见性。这在您希望某些布局显示页脚信息，而其他布局保持简洁时非常有用。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 按索引获取布局幻灯片的引用。
1. 将幻灯片页脚占位符设为可见。
1. 将幻灯片编号占位符设为可见。
1. 将日期时间占位符设为可见。
1. 保存演示文稿。

以下 Python 代码展示了如何设置幻灯片页脚的可见性及相关操作：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```


## **为幻灯片设置子页脚可见性**

在 PowerPoint 演示文稿中，页脚元素（如日期、幻灯片编号和自定义文本）可以在母版层面进行控制，以确保所有布局幻灯片的一致性。Aspose.Slides for Python 使您能够在母版幻灯片上设置这些页脚占位符的可见性和内容，并将这些设置传播到所有子布局幻灯片，从而在整个演示文稿中保持统一的页脚信息。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 按索引获取母版幻灯片的引用。
1. 将母版及所有子页脚占位符设为可见。
1. 将母版及所有子幻灯片编号占位符设为可见。
1. 将母版及所有子日期时间占位符设为可见。
1. 保存演示文稿。

以下 Python 代码演示了此操作：
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**主幻灯片和布局幻灯片有什么区别？**

主幻灯片定义整体主题和默认格式，而布局幻灯片为不同类型的内容定义特定的占位符排列。

**我可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以，您可以从一个演示文稿的 [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) 集合中克隆布局幻灯片，并使用 `add_clone` 方法将其插入到另一个演示文稿中。

**如果我删除仍被幻灯片使用的布局幻灯片会怎样？**

如果尝试删除仍被至少一张幻灯片引用的布局幻灯片，Aspose.Slides 将抛出 [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/)。为避免此情况，请使用 [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/)，该方法只安全地删除未被使用的布局幻灯片。