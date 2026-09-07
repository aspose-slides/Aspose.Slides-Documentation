---
title: 在 Python via Java 中将 PowerPoint 演示文稿转换为 Word 文档
linktitle: PowerPoint 转 Word
type: docs
weight: 110
url: /zh/python-java/convert-powerpoint-to-word/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- PowerPoint 转 Word
- 演示文稿 转 Word
- PPT 转 Word
- PPTX 转 Word
- ODP 转 Word
- PowerPoint 转 DOCX
- PPT 转 DOCX
- PPTX 转 DOCX
- PowerPoint 转 DOC
- 将 PPT 保存为 DOCX
- 将 PPTX 保存为 DOCX
- 导出 PPT 为 DOCX
- 导出 PPTX 为 DOCX
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 和 Aspose.Words 在 Python via Java 中将 PowerPoint 和 OpenDocument 演示文稿转换为 Word，结合幻灯片图像和可编辑文本。"
---
## **概述**

本文说明如何使用 Aspose.Slides for Python via Java 与 Aspose.Words for Java 将 PowerPoint 和 OpenDocument 演示文稿转换为 Word 文档。Aspose.Slides 渲染每张幻灯片并读取其文本，而 Aspose.Words 通过 JPype 创建 Word 文档。无需 Microsoft Office。

生成的文档包含幻灯片图像，随后是从该幻灯片顶层自动形状提取的可编辑文本。图像保留了幻灯片的视觉外观；单个形状、图表和表格不会转换为可编辑的 Word 对象。提取的文本不保留原始的文本格式或位置。

## **将 PowerPoint 转换为 Word**

1. 安装 [Aspose.Slides for Python via Java](/slides/zh/python-java/installation/) 和兼容的 Java 运行时。
2. 下载 [Aspose.Words for Java](https://releases.aspose.com/words/java/)。将其主要 JAR 文件放在脚本旁的 `lib` 目录中，并重命名为 `aspose-words.jar`，或在示例中调整路径以匹配您下载的文件。
3. 将输入演示文稿 `sample.pptx` 放在工作目录中。`lib/aspose-words.jar` 路径同样相对于该目录。
4. 运行以下 Python 代码以创建 `output.docx`。

示例使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 加载源文件，并使用 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 渲染幻灯片。它使用 Aspose.Words 的 [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) 将图像和文本插入 Word 文档。

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # 将幻灯片图像适配到文本区域宽度，保持其纵横比。
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # 追加来自顶层自动形状的纯文本，包括文本框。
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

每张幻灯片在新页面开始。提取的长文本或异常高的幻灯片图像可能需要额外的页面。代码仅在幻灯片之间添加分页符，并在 `finally` 块中释放演示文稿和渲染的图像。JVM 在同一 Python 进程的后续转换中保持可用。

## **常见问题**

**需要哪些库？**

使用 Aspose.Slides for Python via Java、JPype、兼容的 Java 运行时和 Aspose.Words for Java。两个 Aspose 库在同一个 JVM 中运行。Aspose.Slides 处理演示文稿；Aspose.Words 编写 Word 文档。

**我可以转换 PPT 和 ODP 文件以及 PPTX 吗？**

可以。将 `sample.pptx` 替换为 PPT 或 ODP 文件。请参阅 [Supported File Formats](/slides/zh/python-java/supported-file-formats/) 获取演示文稿输入格式。

**所有幻灯片内容在 Word 中都是可编辑的吗？**

否。每张幻灯片作为静态图像插入，顶部自动形状的纯文本随后添加在下方。此示例不会提取组内、表格、SmartArt、图表中的文本，以及演讲者备注。动画和转场也不会在 Word 文档中再现。

**我可以保存为 DOC 而不是 DOCX 吗？**

可以。将输出文件名更改为 `output.doc`。使用此保存重载时，Aspose.Words 会根据文件扩展名选择输出格式。