---
title: 将 PowerPoint 转换为 Word
type: docs
weight: 110
url: /zh/python-net/convert-powerpoint-to-word/
keywords: "转换 PowerPoint, PPT, PPTX, 演示文稿, Word, DOCX, DOC, PPTX 到 DOCX, PPT 到 DOC, PPTX 到 DOC, PPT 到 DOCX, Python, Aspose.Slides"
description: "在 Python 中将 PowerPoint 演示文稿转换为 Word"
---

如果您计划以新方式使用演示文稿（PPT 或 PPTX）中的文本内容或信息，您可能会从将演示文稿转换为 Word（DOC 或 DOCX）中受益。

* 与 Microsoft PowerPoint 相比，Microsoft Word 应用程序更具备处理内容的工具或功能。 
* 除了 Word 中的编辑功能外，您还可以受益于增强的协作、打印和共享功能。

{{% alert color="primary" %}} 

您可能想尝试我们的 [**演示文稿到 Word 在线转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，看看从幻灯片中处理文本内容可以带来什么收益。

{{% /alert %}} 

## **Aspose.Slides 和 Aspose.Words**

要将 PowerPoint 文件（PPTX 或 PPT）转换为 Word（DOCX 或 DOCX），您需要同时使用 [Aspose.Slides for Python via .NET](https://products.aspose.com/slides/python-net/) 和 [Aspose.Words for Python via .NET](https://products.aspose.com/words/python-net/)。

作为一个独立的 API，[Aspose.Slides](https://products.aspose.com/slides/python-net/) for Python via .NET 提供了允许您从演示文稿中提取文本的功能。

[Aspose.Words](https://products.aspose.com/words/python-net/) 是一个先进的文档处理 API，允许应用程序生成、修改、转换、渲染、打印文件，以及在不使用 Microsoft Word 的情况下执行其他文档相关的任务。

## **在 Python 中将 PowerPoint 转换为 Word**

1. 将这些命名空间添加到您的 program.py 文件中：

```py
import aspose.slides as slides
import aspose.words as words
```

2. 使用以下代码片段将 PowerPoint 转换为 Word：

```py
with slides.Presentation("sample.pptx") as presentation:
    doc = words.Document()
    builder = words.DocumentBuilder(doc)

    for index in range(presentation.slides.length):
        slide = presentation.slides[index]

        file_name = "slide_{i}.png".format(i=index)

        # 生成幻灯片图像
        with slide.get_image(1, 1) as image:
            image.save(file_name, slides.ImageFormat.PNG)

        builder.insert_image(file_name)

        for shape in slide.shapes:
            # 插入幻灯片的文本
            if type(shape) is slides.AutoShape:
                builder.writeln(shape.text_frame.text)

        builder.insert_break(words.BreakType.PAGE_BREAK)
    doc.save("output.docx")
```