---
title: 在 Android 上将 PowerPoint 演示文稿转换为 Word 文档
linktitle: PowerPoint 转 Word
type: docs
weight: 110
url: /zh/androidjava/convert-powerpoint-to-word/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 Word
- 演示文稿转 Word
- 幻灯片转 Word
- PPT 转 Word
- PPTX 转 Word
- PowerPoint 转 DOCX
- 演示文稿转 DOCX
- 幻灯片转 DOCX
- PPT 转 DOCX
- PPTX 转 DOCX
- PowerPoint 转 DOC
- 演示文稿转 DOC
- 幻灯片转 DOC
- PPT 转 DOC
- PPTX 转 DOC
- 将 PPT 保存为 DOCX
- 将 PPTX 保存为 DOCX
- 导出 PPT 为 DOCX
- 导出 PPTX 为 DOCX
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 将 PowerPoint PPT 和 PPTX 幻灯片转换为可编辑的 Word 文档，精准保留布局、图像和格式。"
---

如果您计划以新方式使用演示文稿（PPT或PPTX）中的文本内容或信息，您可能会受益于将演示文稿转换为 Word（DOC或DOCX）。

* 与 Microsoft PowerPoint 相比，Microsoft Word 应用在内容方面提供了更丰富的工具或功能。
* 除了 Word 的编辑功能外，您还可以受益于增强的协作、打印和共享功能。

{{% alert color="primary" %}}

您可能想尝试我们的[**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word)，以了解从幻灯片的文本内容工作能获得什么收益。

{{% /alert %}}

## **Aspose.Slides and Aspose.Words**

要将 PowerPoint 文件（PPTX 或 PPT）转换为 Word（DOCX 或 DOCX），您需要同时使用 [Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) 和 [Aspose.Words for Android via Java](https://products.aspose.com/words/androidjava/)。

作为独立的 API，适用于 Java 的 [Aspose.Slides](https://products.aspose.app/slides) 提供了从演示文稿中提取文本的功能。

[Aspose.Words](https://docs.aspose.com/words/androidjava/) 是一个高级文档处理 API，允许应用程序在不使用 Microsoft Word 的情况下生成、修改、转换、呈现、打印文件以及执行其他文档相关任务。

## **将 PowerPoint 转换为 Word**

1. 下载 [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java) 和 [Aspose.Words for Java](https://downloads.aspose.com/words/java) 库。
2. 将 *aspose-slides-x.x-jdk16.jar* 和 *aspose-words-x.x-jdk16.jar* 添加到您的 CLASSPATH 中。
3. 使用以下代码片段将 PowerPoint 转换为 Word：
```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // 生成幻灯片图像为字节数组流
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


## **FAQ**

**需要安装哪些组件才能将 PowerPoint 和 OpenDocument 演示文稿转换为 Word 文档？**

您只需在项目中添加适用于 Android via Java 的 [Aspose.Slides](https://releases.aspose.com/slides/androidjava/) 包和适用于 Android via Java 的 [Aspose.Words](https://releases.aspose.com/words/androidjava/) 包。两个库均作为独立的 API 运行，无需安装 Microsoft Office。

**是否支持所有 PowerPoint 和 OpenDocument 演示文稿格式？**

Aspose.Slides [支持所有演示文稿格式](/slides/zh/androidjava/supported-file-formats/)，包括 PPT、PPTX、ODP 以及其他常见文件类型。这确保您能够处理使用不同版本 Microsoft PowerPoint 创建的演示稿。