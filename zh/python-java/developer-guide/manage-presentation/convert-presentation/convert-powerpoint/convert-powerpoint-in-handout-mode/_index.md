---
title: 使用 Python 将 PowerPoint 演示文稿转换为讲义模式
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/python-java/convert-powerpoint-in-handout-mode/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 讲义模式
- 讲义
- PPT
- PPTX
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Python via Java 中将 PowerPoint 演示文稿转换为讲义。将多张幻灯片排列在同一页上，并使用 Aspose.Slides 导出为 PDF。"
---
## **介绍**

Aspose.Slides for Python via Java 允许您以讲义模式导出演示文稿，将多张幻灯片排列在同一页上。这对于在会议、研讨会等活动中打印演示材料非常有用。

通过[setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 方法配置布局。讲义布局受[PdfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/htmloptions/)和[TiffOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/)的支持。使用[HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/handoutlayoutingoptions/) 对象指定布局和显示设置。

要在导出前设置讲义页面尺寸和方向，请参阅[备注页面大小](/slides/zh/python-java/notes-size/)。

## **讲义模式导出**

要以讲义模式导出演示文稿，创建一个[HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/handoutlayoutingoptions/) 实例，并使用[setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 将其分配给目标导出选项。

下面的示例加载 `sample.pptx`，并以水平顺序每页四张幻灯片的方式导出为 PDF。示例包括幻灯片编号和幻灯片四周的框架，并排除批注。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# 加载演示文稿。
presentation = Presentation("sample.pptx")
try:
    # 配置讲义布局。
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # 使用所选布局将演示文稿导出为 PDF。
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
讲义布局设置适用于受支持的输出格式，如 PDF、HTML、TIFF 和渲染的图像。它们不会重新排列源演示文稿中的幻灯片顺序。
{{% /alert %}}

## **常见问题**

**在讲义模式下，每页最多可以显示多少张幻灯片缩略图？**

Aspose.Slides 支持每页最多九张缩略图。[HandoutType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/handouttype/) 预设提供每页一、二、三、四、六或九张幻灯片。四、六、九张幻灯片的预设提供水平和垂直顺序。

**我可以自定义网格，例如每页五张或八张幻灯片吗？**

不能。缩略图的数量和顺序由预定义的[HandoutType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/handouttype/) 值控制。这些讲义布局设置不支持任意网格。

**我可以在讲义输出中包含隐藏的幻灯片吗？**

可以。在目标格式的导出设置中启用隐藏幻灯片。对于 PDF，请在保存演示文稿之前调用[PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 并将参数设为 `True`。