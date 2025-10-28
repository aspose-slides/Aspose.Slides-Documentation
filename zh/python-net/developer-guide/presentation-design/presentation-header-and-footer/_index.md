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
- 备注
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中添加和自定义页眉和页脚，以实现专业外观。"
---

## **概述**

Aspose.Slides for Python 允许您在演示文稿中精确控制页眉和页脚占位符的范围。页脚文本、日期/时间以及幻灯片编号从母版层级进行管理，可全局应用，也可针对单独幻灯片进行调整。页眉在备注页和讲义页上受支持，您可以通过母版备注页或各个备注页上的专用页眉和页脚管理器切换可见性并设置页眉、页脚、日期/时间和页码的文本。本文概述了更新这些占位符并在整个文稿中一致传播更改的关键模式。

## **管理页眉和页脚文本**

在本节中，您将学习如何在演示文稿中管理页眉和页脚内容——启用或修改页脚、日期和时间以及幻灯片编号。我们将简要概述这些设置的适用范围（整个演示文稿、单个幻灯片以及备注/讲义视图），并展示如何使用 Aspose.Slides API 快速且一致地更新它们。

下面的代码示例打开一个演示文稿，启用并设置页脚文本，在母版备注页上更新页眉文本，并保存文件。

```py
import aspose.slides as slides

# Function to set the header text.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Load the presentation.
with slides.Presentation("sample.pptx") as presentation:
    # Set the footer.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Access and update the header.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **在备注页上管理页眉和页脚**

在本节中，您将学习如何专门在 Aspose.Slides 的备注页上管理页眉和页脚。我们将介绍启用相关占位符、为页脚、日期/时间和页码设置文本，以及在备注母版和各个备注页之间一致地应用这些更改。

按照以下步骤操作：

1. 加载演示文稿文件。  
2. 获取母版备注页及其[页眉和页脚管理器](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/)。  
3. 在母版备注页上，为母版及所有子备注页启用页眉、页脚、幻灯片编号和日期/时间的可见性。  
4. 在母版备注页上，为母版及所有子备注页设置页眉、页脚和日期/时间的文本。  
5. 获取第一张幻灯片的备注页及其[页眉和页脚管理器](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/)。  
6. 仅对该备注页，确保页眉、页脚、幻灯片编号和日期/时间可见（打开任何未开启的项）。  
7. 仅对该备注页，设置页眉、页脚和日期/时间的文本。  
8. 以 PPTX 格式保存演示文稿。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Make the master notes slide and all child header, footer, slide number, and date/time placeholders visible.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Set text on the master notes slide and all child header, footer, and date/time placeholders.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Change header, footer, slide number, and date/time settings for the first notes slide only.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Ensure the header, footer, slide number, and date/time placeholders are visible.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Set text on the notes slide header, footer, and date/time placeholders.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题解答**

**我可以在普通幻灯片上添加“页眉”吗？**

在 PowerPoint 中，“页眉”仅适用于备注页和讲义页；在普通幻灯片上，仅支持页脚、日期/时间和幻灯片编号。Aspose.Slides 的限制与此相同：页眉仅用于备注/讲义页，幻灯片上只能使用页脚/日期时间/幻灯片编号。

**如果布局中没有页脚区域，能否“打开”其可见性？**

可以。通过页眉/页脚管理器检查可见性并根据需要启用。这些 API 指示器和方法专为占位符缺失或隐藏的情况设计。

**如何让幻灯片编号从除 1 之外的其他值开始？**

设置演示文稿的[首张幻灯片编号](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/)，随后所有编号都会重新计算。例如，可从 0 或 10 开始，并在标题幻灯片上隐藏编号。

**导出为 PDF、图像或 HTML 时，页眉/页脚会怎样？**

它们会作为演示文稿的普通文本元素进行渲染。也就是说，只要这些元素在幻灯片/备注页上可见，它们也会出现在相应的输出格式中。