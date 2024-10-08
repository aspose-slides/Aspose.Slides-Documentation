---
title: 将 PowerPoint 转换为 Word
type: docs
weight: 110
url: /java/convert-powerpoint-to-word/
keywords: "将 PowerPoint 转换, PPT, PPTX, 演示文稿, Word, DOCX, DOC, PPTX 到 DOCX, PPT 到 DOC, PPTX 到 DOC, PPT 到 DOCX, Java, java, Aspose.Slides"
description: "在 Java 中将 PowerPoint 演示文稿转换为 Word"
---

如果您计划以新的方式使用演示文稿（PPT 或 PPTX）中的文本内容或信息，您可能会受益于将演示文稿转换为 Word（DOC 或 DOCX）。

* 与 Microsoft PowerPoint 相比，Microsoft Word 应用程序在内容方面更具工具或功能。
* 除了 Word 中的编辑功能，您还可以受益于增强的协作、打印和共享功能。

{{% alert color="primary" %}} 

您可能想尝试我们的 [**在线演示文稿转 Word 转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，看看您能从幻灯片中的文本内容中获得什么。

{{% /alert %}} 

## **Aspose.Slides 和 Aspose.Words**

要将 PowerPoint 文件（PPTX 或 PPT）转换为 Word（DOCX 或 DOCX），您需要 [Aspose.Slides for Java](https://products.aspose.com/slides/java/) 和 [Aspose.Words for Java](https://products.aspose.com/words/java/)。

作为一个独立的 API，[Aspose.Slides](https://products.aspose.app/slides) for java 提供了允许您从演示文稿中提取文本的功能。

[Aspose.Words](https://docs.aspose.com/words/java/) 是一个高级文档处理 API，允许应用程序生成、修改、转换、渲染、打印文件，并执行其他与文档相关的任务，无需使用 Microsoft Word。

## **将 PowerPoint 转换为 Word**

1. 下载 [Aspose.Slides for Java](https://downloads.aspose.com/slides/java) 和 [Aspose.Words for Java](https://downloads.aspose.com/words/java) 库。
2. 将 *aspose-slides-x.x-jdk16.jar* 和 *aspose-words-x.x-jdk16.jar* 添加到您的 CLASSPATH。
3. 使用此代码片段将 PowerPoint 转换为 Word：

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // 生成幻灯片图像作为字节数组流
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // 插入幻灯片的文本
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```