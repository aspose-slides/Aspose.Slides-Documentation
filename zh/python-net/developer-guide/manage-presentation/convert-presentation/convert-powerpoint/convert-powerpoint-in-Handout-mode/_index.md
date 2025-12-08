---
title: 使用 Python 将演示文稿转换为讲义模式
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 讲义模式
- 讲义
- PowerPoint
- 演示文稿
- PPT
- PPTX
- Python
- Aspose.Slides
description: "使用 Python 将演示文稿转换为讲义。设置每页幻灯片数，保留备注，使用 Aspose.Slides 导出为 PDF 或图像，并提供示例代码。免费试用。"
---

## **讲义模式导出**

Aspose.Slides 提供将演示文稿转换为多种格式的能力，包括在讲义模式下创建用于打印的讲义。此模式允许您配置多张幻灯片在单页上的显示方式，适用于会议、研讨会等活动。您可以通过在 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/), 和 [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) 类中设置 `slides_layout_options` 属性来启用此模式。

要配置讲义模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/handoutlayoutingoptions/) 对象，它决定每页放置的幻灯片数量以及其他显示参数。

下面的代码示例展示了如何在讲义模式下将演示文稿转换为 PDF。
```py
# 加载演示文稿。
with slides.Presentation("sample.pptx") as presentation:

    # 设置导出选项。
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 每页水平放置 4 张幻灯片
    slides_layout_options.print_slide_numbers = True                                 # 打印幻灯片编号
    slides_layout_options.print_frame_slide = True                                   # 为幻灯片打印框架
    slides_layout_options.print_comments = False                                     # 无评论

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # 使用所选布局将演示文稿导出为 PDF。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```


{{% alert color="warning" %}} 
请注意，`slides_layout_options` 属性仅在某些输出格式（例如 PDF、HTML、TIFF）以及渲染为图像时可用。
{{% /alert %}} 

## **常见问题**

**在讲义模式下，每页幻灯片缩略图的最大数量是多少？**

Aspose.Slides 支持的 [presets](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) 最多每页 9 个缩略图，支持水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）和 9（水平/垂直）。

**我可以自定义网格，例如每页 5 或 8 张幻灯片吗？**

不可以。缩略图的数量和排列方式严格由 [HandoutType](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) 枚举控制，不支持任意布局。

**我可以在讲义输出中包含隐藏的幻灯片吗？**

可以。请在目标格式的导出设置中启用 `show_hidden_slides` 选项，例如 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/)。