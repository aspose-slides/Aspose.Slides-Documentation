---
title: 使用 Python 将 PowerPoint 演示文稿转换为 Word 文档
linktitle: PowerPoint 转 Word
type: docs
weight: 110
url: /zh/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint 转 DOCX
- OpenDocument 转 DOCX
- 演示文稿 转 DOCX
- 幻灯片 转 DOCX
- PPT 转 DOCX
- PPTX 转 DOCX
- ODP 转 DOCX
- PowerPoint 转 DOC
- OpenDocument 转 DOC
- 演示文稿 转 DOC
- 幻灯片 转 DOC
- PPT 转 DOC
- PPTX 转 DOC
- ODP 转 DOC
- PowerPoint 转 Word
- OpenDocument 转 Word
- 演示文稿 转 Word
- 幻灯片 转 Word
- PPT 转 Word
- PPTX 转 Word
- ODP 转 Word
- 转换 PowerPoint
- 转换 OpenDocument
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- 转换 ODP
- Python
- Aspose.Slides
description: 使用 Aspose.Slides for Python via .NET，轻松将 PowerPoint 和 OpenDocument 演示文稿转换为 Word 文档。我们的分步指南附带示例 Python 代码，为希望简化文档工作流的开发者提供解决方案。
---

## **概述**

本文为开发人员提供了使用 Aspose.Slides for Python via .NET 和 Aspose.Words for Python via .NET 将 PowerPoint 和 OpenDocument 演示文稿转换为 Word 文档的解决方案。分步指南将带您完成转换过程的每个阶段。

## **将演示文稿转换为Word文档**

按照以下说明将 PowerPoint 或 OpenDocument 演示文稿转换为 Word 文档：

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类并加载演示文稿文件。
2. 实例化 [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) 和 [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) 类以生成 Word 文档。
3. 使用 [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) 属性将 Word 文档的页面大小设置为与演示文稿相同。
4. 使用 [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) 属性设置 Word 文档的页边距。
5. 使用 [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) 属性遍历所有演示文稿幻灯片。
    - 使用来自 [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 类的 `get_image` 方法生成幻灯片图像并将其保存到内存流。
    - 使用来自 [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) 类的 `insert_image` 方法将幻灯片图像添加到 Word 文档。
6. 将 Word 文档保存为文件。

假设我们有一个名为 “sample.pptx” 的演示文稿，如下所示：

![PowerPoint 演示文稿](PowerPoint.png)

```py
import aspose.slides as slides
import aspose.words as words

# 加载演示文稿文件。
with slides.Presentation("sample.pptx") as presentation:

    # 创建 Document 和 DocumentBuilder 对象。
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # 在 Word 文档中设置页面大小。
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # 在 Word 文档中设置页边距。
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # 遍历所有演示文稿幻灯片。
    for slide in presentation.slides:

        # 生成幻灯片图像并保存到内存流。
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # 将幻灯片图像添加到 Word 文档。
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # 将 Word 文档保存为文件。
    document.save("output.docx")
```


结果：

![Word 文档](Word.png)

{{% alert color="primary" %}} 
尝试我们的 [**在线 PPT 转 Word 转换器**](https://products.aspose.app/slides/conversion/ppt-to-word) ，了解将 PowerPoint 和 OpenDocument 演示文稿转换为 Word 文档可以获得的好处。 
{{% /alert %}}

## **常见问题**

**需要安装哪些组件才能将 PowerPoint 和 OpenDocument 演示文稿转换为 Word 文档？**

只需在 Python 项目中添加 [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) 和 [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) 相应的包即可。这两个包均作为独立 API 工作，无需安装 Microsoft Office。

**是否支持所有 PowerPoint 和 OpenDocument 演示文稿格式？**

Aspose.Slides for Python .NET [支持所有演示文稿格式](/slides/zh/python-net/supported-file-formats/)，包括 PPT、PPTX、ODP 等常见文件类型。这确保您可以处理在不同版本的 Microsoft PowerPoint 中创建的演示文稿。