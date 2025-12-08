---
title: 使用 Python 自定义演示文稿的默认字体
linktitle: 默认字体
type: docs
weight: 30
url: /zh/python-net/default-font/
keywords:
- 默认字体
- 常规字体
- 普通字体
- 亚洲字体
- PDF 导出
- XPS 导出
- 图像导出
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python 中设置默认字体，以确保 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）正确转换为 PDF、XPS 和图像。"
---

## **使用默认字体渲染演示文稿**
Aspose.Slides 允许您设置渲染演示文稿为 PDF、XPS 或缩略图的默认字体。本文展示了如何定义 DefaultRegularFont 和 DefaultAsianFont 作为默认字体。请按照以下步骤使用 Aspose.Slides for Python via .NET API 从外部目录加载字体：

1. 创建 LoadOptions 的实例。
1. 将 DefaultRegularFont 设置为您想要的字体。在下面的示例中，我使用了 Wingdings。
1. 将 DefaultAsianFont 设置为您想要的字体。示例中我使用了 Wingdings。
1. 使用 Presentation 加载演示文稿并设置加载选项。
1. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

上述实现如下所示。
```py
import aspose.slides as slides

# 使用加载选项来定义默认的常规和亚洲字体# 使用加载选项来定义默认的常规和亚洲字体
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

**default_regular_font 和 default_asian_font 到底影响什么——仅导出，还是包括缩略图、PDF、XPS、HTML 和 SVG？**

它们参与所有受支持输出的渲染管道。这包括幻灯片缩略图、[PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/python-net/convert-powerpoint-to-xps/)、[栅格图像](/slides/zh/python-net/convert-powerpoint-to-png/)、[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)、以及[SVG](/slides/zh/python-net/render-a-slide-as-an-svg-image/)，因为 Aspose.Slides 在这些目标上使用相同的布局和字形解析逻辑。

**在仅读取并保存 PPTX 而不进行任何渲染时，默认字体会被应用吗？**

不。只有在需要测量和绘制文本时，默认字体才会起作用。直接打开并保存演示文稿不会更改存储的字体运行或文件结构。默认字体在渲染或重新排版文本的操作中才会发挥作用。

**如果我添加自己的字体文件夹或从内存提供字体，它们会在选择默认字体时被考虑吗？**

是的。[Custom font sources](/slides/zh/python-net/custom-font/) 扩展了引擎可使用的可用字体族和字形目录。默认字体及任何[fallback rules](/slides/zh/python-net/fallback-font/) 将首先在这些来源中解析，从而在服务器和容器中提供更可靠的覆盖。

**默认字体会影响文本度量（字距、前进）从而影响换行和自动换行吗？**

是的。更改字体会改变字形度量，并可能在渲染期间改变换行、自动换行和分页。为了布局稳定性，请[embed the original fonts](/slides/zh/python-net/embedded-font/) 或选择度量上兼容的默认和回退字体族。

**如果演示文稿中使用的所有字体都已嵌入，设置默认字体还有意义吗？**

通常没有必要，因为[embedded fonts](/slides/zh/python-net/embedded-font/) 已经确保了外观的一致性。默认字体仍然可以作为安全网，针对嵌入子集未覆盖的字符或文件中混合了嵌入和未嵌入文本的情况。