---
title: 在 Python via Java 中指定默认演示文稿字体
linktitle: 默认字体
type: docs
weight: 30
url: /zh/python-java/default-font/
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中设置默认字体，以确保 PowerPoint (PPT, PPTX) 和 OpenDocument (ODP) 正确转换为 PDF、XPS 和图像。"
---
## **概述**

Aspose.Slides 允许您指定在呈现演示文稿时使用的默认字体。此功能在生成幻灯片缩略图或将演示文稿导出为 PDF、XPS 等格式时非常有用。默认字体需在加载演示文稿之前通过 [LoadOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/) 进行配置。

[setDefaultRegularFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) 方法定义常规文本的默认字体，而 [setDefaultAsianFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) 方法定义亚洲文本的默认字体。设置这些选项后，演示文稿即可使用指定的字体加载并渲染。

## **使用默认字体渲染演示文稿**

Aspose.Slides 让您可以为将演示文稿渲染为 PDF、XPS 或缩略图时设定默认字体。本节演示如何使用 Aspose.Slides for Python via Java 为常规文本和亚洲文本定义默认字体：

1. 创建一个 [LoadOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/) 实例。
1. 使用 [setDefaultRegularFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) 指定所需的字体。以下示例使用 Wingdings。
1. 使用 [setDefaultAsianFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) 指定所需的字体。以下示例同样使用 Wingdings。
1. 使用带有加载选项的 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 加载演示文稿。
1. 生成幻灯片缩略图、PDF 和 XPS 以验证结果。

下面的示例实现了上述步骤：

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# 使用加载选项来定义默认的常规字体和亚洲字体。
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# 加载演示文稿。
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # 生成幻灯片缩略图。
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # 将图像保存到磁盘。
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # 生成 PDF。
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # 生成 XPS 文档。
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **常见问题解答**

**默认的常规字体和亚洲字体到底影响什么——仅导出，还是包括缩略图、PDF、XPS、HTML 和 SVG？**

它们参与所有受支持输出的渲染管道。包括幻灯片缩略图、[PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/python-java/convert-powerpoint-to-xps/)、[光栅图像](/slides/zh/python-java/convert-powerpoint-to-png/)、[HTML](/slides/zh/python-java/convert-powerpoint-to-html/) 和 [SVG](/slides/zh/python-java/render-a-slide-as-an-svg-image/)，因为 Aspose.Slides 在这些目标上使用相同的布局和字形解析逻辑。

**在仅读取并保存 PPTX 而不进行任何渲染时，默认字体会被应用吗？**

不会。默认字体仅在需要测量和绘制文本时生效。纯粹的打开—保存操作不会更改存储的字体运行或文件结构。默认字体在渲染或重新排版文本的操作中才会发挥作用。

**如果我添加了自己的字体文件夹或从内存中提供字体，这些会在选择默认字体时被考虑吗？**

会。[自定义字体源](/slides/zh/python-java/custom-font/) 会扩展引擎可用的字体族和字形目录。默认字体和任何 [回退规则](/slides/zh/python-java/fallback-font/) 将首先在这些来源中进行解析，从而在服务器和容器环境中提供更可靠的覆盖。

**默认字体会影响文本度量（字距、前进宽度），从而影响换行和自动换行吗？**

会。更换字体会改变字形度量，可能在渲染期间导致换行、自动换行和分页的变化。为保持布局稳定，建议 [嵌入原始字体](/slides/zh/python-java/embedded-font/) 或选择在度量上兼容的默认和回退字体族。

**如果演示文稿中使用的所有字体都已嵌入，设置默认字体还有意义吗？**

通常没有必要，因为 [嵌入字体](/slides/zh/python-java/embedded-font/) 已经保证了一致的外观。不过默认字体仍然可以作为字符未被嵌入子集覆盖或文件混合了嵌入和未嵌入文本时的安全网。