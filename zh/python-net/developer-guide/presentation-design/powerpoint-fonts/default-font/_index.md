---
title: 默认字体
type: docs
weight: 30
url: /python-net/default-font/
keywords: "字体, 默认字体, 渲染演示文稿, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "PowerPoint 默认字体在 Python 中的使用"
---

## **使用默认字体渲染演示文稿**
Aspose.Slides 允许您设置默认字体以渲染演示文稿为 PDF、XPS 或缩略图。本文展示如何定义 DefaultRegular Font 和 DefaultAsian Font 作为默认字体。请按照以下步骤使用 Aspose.Slides for Python via .NET API 从外部目录加载字体：

1. 创建 LoadOptions 的实例。
1. 将 DefaultRegularFont 设置为您所需的字体。在以下示例中，我使用了 Wingdings。
1. 将 DefaultAsianFont 设置为您所需的字体。我在以下示例中使用了 Wingdings。
1. 使用 Presentation 加载演示文稿并设置加载选项。
1. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

上述实现如下所示。

```py
import aspose.slides as slides

# 使用加载选项定义默认常规和亚洲字体
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