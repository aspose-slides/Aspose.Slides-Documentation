---
title: 使用 Python 管理演示文稿的页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/python-net/presentation-header-and-footer/
keywords:
- 页眉
- 页眉文本
- 页脚
- 页脚文本
- 设置页眉
- 设置页脚
- 讲义
- 注释
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 管理幻灯片、注释页和讲义上的页脚、日期时间、幻灯片编号和页眉占位符。"
---
## **概述**

PowerPoint 根据页面类型使用不同的页眉和页脚占位符。Aspose.Slides for Python via .NET 让您通过页眉/页脚管理器类控制这些占位符的文本和可见性。

可用的占位符取决于作用范围：

| 作用范围 | 页眉 | 页脚 | 日期/时间 | 幻灯片/页码 |
|---|---|---|---|---|
| 常规幻灯片 | 否 | 是 | 是 | 是 |
| 注释母版 | 是 | 是 | 是 | 是 |
| 注释幻灯片 | 是 | 是 | 是 | 是 |
| 讲义母版 | 是 | 是 | 是 | 是 |

常规演示文稿幻灯片没有页眉占位符。页眉仅在注释页和讲义页上可用。对于常规幻灯片，请使用页脚、日期/时间和幻灯片编号占位符。

更改的作用范围取决于您使用的管理器。[`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slideheaderfootermanager/) 类控制单个常规幻灯片。[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/notesslideheaderfootermanager/) 类控制单个注释幻灯片。母版和布局管理器还可以将设置传播到从属幻灯片，而[`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) 类控制讲义母版。

## **在常规幻灯片上设置页脚、日期/时间和幻灯片编号**

对于常规幻灯片，基本工作流程是访问每张幻灯片的页眉/页脚管理器，设置页脚和日期/时间文本，启用所需的占位符，然后保存演示文稿。幻灯片编号由演示文稿生成，您只需控制其可见性。

使用[`set_footer_text`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/)和[`set_date_time_text`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/)设置文本，使用[`set_footer_visibility`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/)、[`set_date_time_visibility`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/)和[`set_slide_number_visibility`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/)显示相应的占位符。

以下端到端示例将相同的页脚、日期/时间文本和幻灯片编号可见性应用于所有常规幻灯片：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

如果只需更新一张幻灯片，请直接通过[`slides`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/slides/zh/)集合访问该幻灯片，而不是遍历整个集合。

## **在注释母版上设置页眉和页脚**

注释母版定义注释页的通用格式和占位符行为。希望仅更改注释母版本身时，请使用[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslideheaderfootermanager/) 类。

以下示例在注释母版上设置页眉、页脚和日期/时间文本，并使该母版上所有受支持的占位符可见：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

演示文稿可能不包含注释母版，请在更改之前检查返回值是否为`None`。

## **将注释母版设置应用于子注释幻灯片**

注释母版可以将页眉和页脚设置应用于自身以及所有从属注释幻灯片。当需要在注释层次结构中统一设置时，请使用[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslideheaderfootermanager/)的专用传播方法。

例如，[`set_header_and_child_headers_text`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/)和[`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/)更新注释母版页眉以及所有子页眉。对应的方法也适用于页脚、日期/时间和幻灯片编号。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

上述传播方法包括[`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/)、[`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/)、[`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/)、[`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/)和[`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/)。

## **在单个注释幻灯片上设置页眉和页脚**

注释幻灯片属于特定的常规幻灯片。希望仅自定义该注释页时，请使用其[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/notesslideheaderfootermanager/) 类。

[`add_notes_slide`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/notesslidemanager/add_notes_slide/)方法返回当前幻灯片的注释幻灯片，如果不存在则创建。以下示例配置与第一张演示文稿幻灯片关联的注释页：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

如果先从注释母版传播设置，然后再更改单个注释幻灯片，后续的每张幻灯片设置可以独立自定义该注释页。

## **在讲义母版上设置页眉和页脚**

讲义页使用讲义母版的页眉、页脚、日期/时间和页码占位符。与注释页不同，讲义设置通过讲义母版而非单个讲义幻灯片管理。

使用[`master_handout_slide`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/)属性访问讲义母版。如果不存在，请调用[`set_default_master_handout_slide`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/)创建默认讲义母版。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **理解作用范围和继承**

选择与您要更改的作用范围相匹配的页眉/页脚管理器：

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slideheaderfootermanager/) 更改单个常规幻灯片的页脚、日期/时间和幻灯片编号设置。
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/layoutslideheaderfootermanager/) 控制布局幻灯片，可将支持的设置传播到从属幻灯片。
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslideheaderfootermanager/) 控制普通幻灯片母版，可将支持的设置传播到从属幻灯片。
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslideheaderfootermanager/) 控制注释母版，并可将设置传播到所有从属注释幻灯片。
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/notesslideheaderfootermanager/) 更改单个注释幻灯片，并支持页眉占位符以及页脚、日期/时间和幻灯片编号。
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) 更改讲义母版，支持所有四种占位符类型。

当相同设置应在整个层次结构中生效时，请使用母版或布局的传播功能。需要对单页进行本地设置时，请使用单个幻灯片或注释幻灯片管理器。

## **常见问题**

**我可以在常规幻灯片上添加页眉吗？**

不能。PowerPoint 未为常规幻灯片定义页眉占位符。在常规幻灯片上使用页脚、日期/时间和幻灯片编号占位符。页眉占位符在注释页和讲义页上可用。

**如果页脚、日期/时间或幻灯片编号占位符不可见怎么办？**

使用相应的页眉/页脚管理器检查其可见性并在需要时启用。例如，[`is_footer_visible`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) 报告页脚占位符是否存在，[`set_footer_visibility`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) 更改其可见性。

**如何让幻灯片编号从除 1 之外的值开始？**

设置演示文稿的[`first_slide_number`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/first_slide_number/)属性。幻灯片编号占位符随后使用更新后的编号序列。

**导出为 PDF、图像或 HTML 时，页眉和页脚会怎样？**

可见的页眉和页脚元素会与演示文稿的其余内容一起在输出格式中渲染。它们的外观取决于导出的页面类型以及相应的占位符可见性设置。