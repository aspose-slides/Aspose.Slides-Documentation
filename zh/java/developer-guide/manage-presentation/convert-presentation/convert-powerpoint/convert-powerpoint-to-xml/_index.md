---
title: 在 Java 中将 PowerPoint 演示文稿转换为 XML
linktitle: PowerPoint 转 XML
type: docs
weight: 145
url: /zh/java/convert-powerpoint-to-xml/
keywords:
- 将 PowerPoint 转换为 XML
- 将演示文稿转换为 XML
- PPT 转 XML
- PPTX 转 XML
- ODP 转 XML
- PowerPoint XML 演示文稿
- SaveFormat.Xml
- 将演示文稿保存为 XML
- 导出演示文稿为 XML
- XML 流
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 Java 中将 PowerPoint 和 OpenDocument 演示文稿转换为 PowerPoint XML 文件或流。"
---
## **概述**

Aspose.Slides for Java 可以将 PowerPoint 演示文稿转换为 PowerPoint XML 演示文稿格式。当您需要文本形式的表示以检查演示文稿结构、排除生成文档的故障、在自动化测试中比较输出，或将 XML 用于替代演示文稿包的工作流时，XML 输出非常有用。

使用带有 `Xml` 值的 [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法，`Xml` 来自 [SaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/) 类。您可以将结果直接写入文件或流。

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` 创建一个 PowerPoint XML 演示文稿。它不会提取存储在 PPTX 包中的各个 Office Open XML 部分。如果需要获取精确的 PPTX 包部分，例如 `ppt/presentation.xml` 或单独的幻灯片 XML 文件，请检查 PPTX 包本身。
{{% /alert %}}

## **将演示文稿转换为 XML 文件**

使用 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类加载源演示文稿，然后将输出路径和 `SaveFormat.Xml` 传递给 [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-)。源可以是任何受支持的加载格式，如 PPT、PPTX 或 ODP。

下面的示例将 PPTX 演示文稿转换为 XML 文件：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **将 XML 输出写入流**

在 XML 必须保留在内存中或传递给其他组件（如 Web 服务、存储提供程序或 XML 处理管道）时，使用 [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) 的流重载。下面的示例将结果写入 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html)，并获取生成的 XML 字节数组：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // 将 xmlData 传递给工作流中的下一个组件。
} finally {
    presentation.dispose();
}
```

## **将 XML 与演示文稿和导出格式进行比较**

根据结果的使用方式选择输出格式：

| 格式 | 输出 | 常见用途 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 演示文稿 | 检查结构、排除故障、比较生成的输出以及基于 XML 的集成 |
| PPT (`.ppt`) | 传统二进制演示文稿文件 | 与旧版 PowerPoint 工作流兼容 |
| PPTX (`.pptx`) | 包含多个部分的 Office Open XML 包 | 常规 PowerPoint 编辑和演示文稿交换 |
| PDF 或 TIFF | 固定布局页面或多页图像 | 查看、打印和归档 |
| PNG、JPEG 或 SVG | 单个幻灯片的渲染表示 | 缩略图、预览和图像资产 |
| HTML 或 HTML5 | 面向 Web 的演示文稿输出 | 浏览器查看和 Web 发布 |

与 PPT 和 PPTX 不同，XML 输出主要用于检查和数据导向的工作流。与 PDF、TIFF、HTML 和幻灯片图像格式不同，XML 表示的是演示文稿数据，而不是将幻灯片渲染为页面或视觉资产。[支持的文件格式](/slides/zh/java/supported-file-formats/) 表格列出了 Aspose.Slides 能够加载、导入、保存或渲染的所有格式。

## **常见问题**

**`SaveFormat.Xml` 与保存 PPTX 文件是一样的吗？**  
不一样。PPTX 是一个包含多个 Office Open XML 部分的包，而 `SaveFormat.Xml` 会创建一个 PowerPoint XML 演示文稿文件。

**我可以在不在磁盘上创建文件的情况下保存 XML 输出吗？**  
可以。将可写流传递给 [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-)。例如，使用 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) 进行内存处理。

**Aspose.Slides 能再次加载导出的 XML 文件吗？**  
可以。将 XML 文件或流传递给 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 构造函数。随后 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSourceFormat--) 将返回 `SourceFormat.Xml`。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 会对该格式报告 `LoadFormat.Unknown`，因此不要使用它来判断 XML 文件是否可以打开。

**XML 转换会将每张幻灯片渲染为页面或图像吗？**  
不会。XML 转换写入的是结构化的演示文稿数据。若需页面导向的输出，请使用 PDF 或 TIFF；若需单张幻灯片图像，请使用 PNG、JPEG 或 SVG。