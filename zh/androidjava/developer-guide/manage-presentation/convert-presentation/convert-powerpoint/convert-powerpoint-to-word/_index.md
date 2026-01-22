---
title: 在 Android 上将 PowerPoint 演示文稿转换为 Word 文档
linktitle: PowerPoint 转 Word
type: docs
weight: 110
url: /zh/androidjava/convert-powerpoint-to-word/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 Word
- 演示文稿 转 Word
- 幻灯片 转 Word
- PPT 转 Word
- PPTX 转 Word
- PowerPoint 转 DOCX
- 演示文稿 转 DOCX
- 幻灯片 转 DOCX
- PPT 转 DOCX
- PPTX 转 DOCX
- PowerPoint 转 DOC
- 演示文稿 转 DOC
- 幻灯片 转 DOC
- PPT 转 DOC
- PPTX 转 DOC
- 将 PPT 保存为 DOCX
- 将 PPTX 保存为 DOCX
- 导出 PPT 为 DOCX
- 导出 PPTX 为 DOCX
- 安卓
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中将 PowerPoint PPT 和 PPTX 幻灯片转换为可编辑的 Word 文档，精确保留布局、图像和格式。"
---

如果您计划以新方式使用演示文稿（PPT 或 PPTX）中的文本内容或信息， 将演示文稿转换为 Word（DOC 或 DOCX）可能会带来帮助。

* 与 Microsoft PowerPoint 相比，Microsoft Word 应用在内容方面提供了更多的工具或功能。
* 除了 Word 中的编辑功能外，您还可以受益于增强的协作、打印和共享特性。

{{% alert color="primary" %}}
您可以尝试我们的[**演示文稿转Word在线转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，看看从幻灯片的文本内容中工作可以获得什么收益。
{{% /alert %}}

## **Aspose.Slides 与 Aspose.Words**

要将 PowerPoint 文件（PPTX 或 PPT）转换为 Word（DOCX 或 DOC），您需要同时使用 [Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) 和 [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/)。

作为独立的 API，[Aspose.Slides](https://products.aspose.app/slides) for java 提供了从演示文稿中提取文本的功能。

[Aspose.Words](https://docs.aspose.com/words/androidjava/) 是一个高级文档处理 API，允许应用程序在不使用 Microsoft Word 的情况下生成、修改、转换、渲染、打印文件以及执行其他文档相关任务。

## **将 PowerPoint 转换为 Word**

1. 下载 [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java) 和 [Aspose.Words for Java](https://downloads.aspose.com/words/java) 库。
2. 将 *aspose-slides-x.x-jdk16.jar* 和 *aspose-words-x.x-jdk16.jar* 添加到您的 CLASSPATH。
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

    // 插入幻灯片文本
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


## **常见问题**

**需要安装哪些组件才能将 PowerPoint 和 OpenDocument 演示文稿转换为 Word 文档？**

您只需将相应的 [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/androidjava/) 和 [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) 包添加到项目中。两者都是独立的 API，无需安装 Microsoft Office。

**是否支持所有 PowerPoint 和 OpenDocument 演示文稿格式？**

Aspose.Slides [支持所有演示文稿格式](/slides/zh/androidjava/supported-file-formats/)，包括 PPT、PPTX、ODP 等常见文件类型。这确保您能够处理使用不同版本 Microsoft PowerPoint 创建的演示文稿。