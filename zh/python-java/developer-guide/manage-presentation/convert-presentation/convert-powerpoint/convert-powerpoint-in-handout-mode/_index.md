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
description: "使用 Java 通过 Python 将 PowerPoint 演示文稿转换为讲义。将多张幻灯片排列在每页，并使用 Aspose.Slides 导出为 PDF。"
---
## **介绍**

Aspose.Slides for Python via Java 允许您以讲义模式导出演示文稿，在单页上排列多张幻灯片。这对于为会议、研讨会等活动打印演示材料非常有用。

通过 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 方法配置布局。讲义布局受到 [PdfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/htmloptions/) 和 [TiffOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/) 的支持。使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/handoutlayoutingoptions/) 对象指定布局和显示设置。

## **讲义模式导出**

要以讲义模式导出演示文稿，请创建一个 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/handoutlayoutingoptions/) 实例，并通过 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 将其分配给目标导出选项。

以下示例加载 `sample.pptx` 并将其导出为 PDF，每页水平排列四张幻灯片。示例包括幻灯片编号和幻灯片周围的边框，并排除评论。

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
讲义布局设置适用于受支持的输出格式，例如 PDF、HTML、TIFF 和渲染图像。它们不会重新排列源演示文稿中的幻灯片顺序。
{{% /alert %}}

## **常见问题**

**在讲义模式下每页最多可以显示多少个幻灯片缩略图？**

Aspose.Slides 最多支持每页九个缩略图。[HandoutType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/handouttype/) 预设提供每页 1、2、3、4、6 或 9 张幻灯片的布局。四、六、九张幻灯片的预设支持水平和垂直排序。

**我可以自定义网格，例如每页五张或八张幻灯片吗？**

不能。缩略图的数量和排序由预定义的 [HandoutType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/handouttype/) 值控制。这些讲义布局设置不支持任意网格。

**我可以在讲义输出中包含隐藏的幻灯片吗？**

可以。在目标格式的导出设置中启用隐藏幻灯片。对于 PDF，请在保存演示文稿之前调用 [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 并传入 `True`。