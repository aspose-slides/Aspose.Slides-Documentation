---
title: 将PowerPoint转换为Word
type: docs
weight: 110
url: /zh/androidjava/convert-powerpoint-to-word/
keywords: "转换PowerPoint, PPT, PPTX, 演示文稿, Word, DOCX, DOC, PPTX到DOCX, PPT到DOC, PPTX到DOC, PPT到DOCX, Java, java, Aspose.Slides"
description: "在Java中将PowerPoint演示文稿转换为Word"
---

如果您计划以新方式使用演示文稿（PPT或PPTX）中的文本内容或信息，您可能会受益于将演示文稿转换为Word（DOC或DOCX）。

* 与Microsoft PowerPoint相比，Microsoft Word应用程序在内容处理方面更具工具或功能。
* 除了Word中的编辑功能，您还可以受益于增强的协作、打印和分享功能。

{{% alert color="primary" %}} 

您可能想尝试我们的[**在线演示文稿转换为Word工具**](https://products.aspose.app/slides/conversion/ppt-to-word)，以查看从幻灯片文本内容中获得的收益。 

{{% /alert %}} 

## **Aspose.Slides和Aspose.Words**

要将PowerPoint文件（PPTX或PPT）转换为Word（DOCX或DOC），您需要[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/)和[Aspose.Words for Java](https://products.aspose.com/words/java/)。

作为一个独立的API，[Aspose.Slides](https://products.aspose.app/slides) for java提供允许您从演示文稿中提取文本的功能。

[Aspose.Words](https://docs.aspose.com/words/java/)是一个先进的文档处理API，允许应用程序生成、修改、转换、呈现、打印文件，并执行其他文档相关任务，而无需使用Microsoft Word。

## **将PowerPoint转换为Word**

1. 下载[Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java)和[Aspose.Words for Java](https://downloads.aspose.com/words/java)库。
2. 将*aspose-slides-x.x-jdk16.jar*和*aspose-words-x.x-jdk16.jar*添加到您的CLASSPATH。
3. 使用以下代码片段将PowerPoint转换为Word：

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