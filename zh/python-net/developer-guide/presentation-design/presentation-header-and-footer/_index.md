---
title: 使用 Python 管理演示文稿的页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/python-net/developer-guide/presentation-design/presentation-header-and-footer/
keywords:
- header
- header text
- footer
- footer text
- set header
- set footer
- handout
- notes
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "通过 .NET 的 Aspose.Slides for Python 为 PowerPoint 和 OpenDocument 演示文稿添加并自定义页眉和页脚，以实现专业外观。"
---

## **概述**

Aspose.Slides for Python 允许您在整个演示文稿中精确控制页眉和页脚占位符的范围。页脚文本、日期/时间以及幻灯片编号在母版级别进行管理，可全局应用或针对单个幻灯片进行调整。页眉在备注页和讲义页上受支持，您可以通过母版备注幻灯片或单个备注幻灯片上的专用页眉和页脚管理器切换可见性，并为页眉、页脚、日期/时间和页码设置文本。本文概述了更新这些占位符并在整个文稿中一致传播更改的关键模式。

## **管理页眉和页脚文本**

本节将介绍如何在演示文稿中管理页眉和页脚内容——启用或修改页脚、日期时间和幻灯片编号。我们将简要概述这些设置的应用范围（整个演示文稿、单个幻灯片以及备注/讲义视图），并展示如何使用 Aspose.Slides API 快速且一致地进行更新。

下面的代码示例打开一个演示文稿，启用并设置页脚文本，更新母版备注幻灯片上的页眉文本，并保存文件。

```py
import aspose.slides as slides

# 设置页眉文本的函数。
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# 加载演示文稿。
with slides.Presentation("sample.pptx") as presentation:
    # 设置页脚。
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # 访问并更新页眉。
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # 保存演示文稿。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **管理备注幻灯片上的页眉和页脚**

本节将介绍如何在 Aspose.Slides 中专门管理备注幻灯片的页眉和页脚。我们将覆盖启用相关占位符、为页脚、日期/时间和页码设置文本，并在备注母版和各个备注页面上始终如一地应用这些更改。

请按以下步骤操作：

1. 加载演示文稿文件。  
2. 获取母版备注幻灯片及其[页眉和页脚管理器](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/)。  
3. 在母版备注幻灯片上，为母版及所有子备注幻灯片启用“页眉、页脚、幻灯片编号和日期/时间”的可见性。  
4. 在母版备注幻灯片上，为母版及所有子备注幻灯片设置页眉、页脚和日期/时间的文本。  
5. 获取第一张演示文稿幻灯片的备注幻灯片及其[页眉和页脚管理器](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/)。  
6. 仅对该第一张备注幻灯片，确保页眉、页脚、幻灯片编号和日期/时间可见（打开任何已关闭的项）。  
7. 仅对该第一张备注幻灯片，设置页眉、页脚和日期/时间的文本。  
8. 以 PPTX 格式保存演示文稿。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # 使母版备注幻灯片及所有子页眉、页脚、幻灯片编号和日期/时间占位符可见。
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # 在母版备注幻灯片及所有子页眉、页脚和日期/时间占位符上设置文本。
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # 仅更改第一张备注幻灯片的页眉、页脚、幻灯片编号和日期/时间设置。
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # 确保页眉、页脚、幻灯片编号和日期/时间占位符可见。
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # 在备注幻灯片的页眉、页脚和日期/时间占位符上设置文本。
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # 保存演示文稿。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问答**

**可以在普通幻灯片上添加“页眉”吗？**

在 PowerPoint 中，“页眉”仅存在于备注页和讲义页；在普通幻灯片上，仅支持页脚、日期/时间和幻灯片编号。Aspose.Slides 的行为与此保持一致：页眉仅用于备注/讲义，普通幻灯片仅支持页脚/日期时间/幻灯片编号。

**如果布局中没有页脚区域，能否“打开”它的可见性？**

可以。通过页眉/页脚管理器检查可见性，并在需要时启用。这些 API 指标和方法专为占位符缺失或被隐藏的情况设计。

**如何让幻灯片编号从除 1 之外的其他值开始？**

设置演示文稿的[首张幻灯片编号](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/)；之后所有编号会重新计算。例如，可以从 0 或 10 开始，并在标题页上隐藏编号。

**导出为 PDF/图像/HTML 时，页眉/页脚会怎样？**

它们会作为演示文稿的常规文本元素进行渲染。也就是说，只要这些元素在幻灯片/备注页面上可见，它们也会出现在输出的相应格式中。