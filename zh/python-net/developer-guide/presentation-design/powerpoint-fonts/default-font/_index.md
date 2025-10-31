---
title: 使用 Python 自定义演示文稿的默认字体
linktitle: 默认字体
type: docs
weight: 30
url: /zh/python-net/default-font/
keywords:
- 默认字体
- 常规字体
- 正常字体
- 亚洲字体
- PDF 导出
- XPS 导出
- 图像导出
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: 在 Aspose.Slides for Python 中设置默认字体，以确保 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）正确转换为 PDF、XPS 和图像。
---

## **使用默认字体渲染演示文稿**

Aspose.Slides 允许您设置在将演示文稿渲染为 PDF、XPS 或缩略图时使用的默认字体。本文展示如何定义 DefaultRegularFont 和 DefaultAsianFont 作为默认字体。请按照以下步骤使用 Aspose.Slides for Python 通过 .NET API 从外部目录加载字体：

1. 创建一个 LoadOptions 实例。  
2. 将 DefaultRegularFont 设置为您想要的字体。在以下示例中，我使用了 Wingdings。  
3. 将 DefaultAsianFont 设置为您想要的字体。我在下面的示例中也使用了 Wingdings。  
4. 使用 Presentation 加载演示文稿，并设置加载选项。  
5. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

实现如下：

```py
import aspose.slides as slides

# 使用加载选项定义默认的常规和亚洲字体# 使用加载选项定义默认的常规和亚洲字体
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# 加载演示文稿
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # 生成幻灯片缩略图
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # 生成 PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # 生成 XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **常见问题**

**default_regular_font 和 default_asian_font 到底影响什么——仅导出，还是也包括缩略图、PDF、XPS、HTML 和 SVG？**  
它们参与所有支持的输出的渲染管线。这包括幻灯片缩略图、[PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/python-net/convert-powerpoint-to-xps/)、[光栅图像](/slides/zh/python-net/convert-powerpoint-to-png/)、[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)、以及[SVG](/slides/zh/python-net/render-a-slide-as-an-svg-image/)，因为 Aspose.Slides 在这些目标上使用相同的布局和字形解析逻辑。

**仅读取并保存 PPTX 而不进行任何渲染时，会应用默认字体吗？**  
不会。默认字体只在需要测量和绘制文本时才重要。直接打开后保存演示文稿不会更改存储的字体运行或文件结构。默认字体在渲染或重新排版文本的操作中才会起作用。

**如果我添加自己的字体文件夹或从内存提供字体，它们会在选择默认字体时被考虑吗？**  
会。[自定义字体源](/slides/zh/python-net/custom-font/) 扩展了引擎可用的字体族和字形目录。默认字体和任何[回退规则](/slides/zh/python-net/fallback-font/) 将首先在这些来源中进行解析，从而在服务器和容器中提供更可靠的覆盖。

**默认字体会影响文本度量（字距、前进宽度），从而影响换行和自动换行吗？**  
会。更改字体会改变字形度量，可能在渲染过程中导致换行、自动换行和分页的变化。为保证布局稳定，建议[嵌入原始字体](/slides/zh/python-net/embedded-font/) 或选择度量兼容的默认和回退字体族。

**如果演示文稿中使用的所有字体都已嵌入，设置默认字体还有意义吗？**  
通常没有必要，因为[嵌入字体](/slides/zh/python-net/embedded-font/) 已经确保了一致的外观。默认字体仍然作为安全网，以防嵌入子集未覆盖的字符，或文件中混合了嵌入和未嵌入的文本时使用。