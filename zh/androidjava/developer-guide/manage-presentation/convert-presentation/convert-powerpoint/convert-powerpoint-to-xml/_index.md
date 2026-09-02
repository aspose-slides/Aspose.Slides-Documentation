---
title: 在 Android 上将 PowerPoint 演示文稿转换为 XML
linktitle: PowerPoint 转 XML
type: docs
weight: 145
url: /zh/androidjava/convert-powerpoint-to-xml/
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
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 演示文稿转换为 PowerPoint XML 文件或流。"
---
## **概述**

Aspose.Slides for Android via Java 可以将 PowerPoint 演示文稿转换为 PowerPoint XML 演示文稿格式。XML 输出在需要基于文本的表示以检查演示结构、排查生成的文档、在自动化测试中比较输出，或与使用 XML 而非演示包的工作流集成时非常有用。

使用 [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法并传入 [SaveFormat.Xml](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveformat/#Xml)。您可以将结果直接写入文件或流。

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` 会创建 PowerPoint XML 演示文稿。它不会提取 PPTX 包内存储的各个 Office Open XML 部分。如果您需要确切的 PPTX 包部分，例如 `ppt/presentation.xml` 或单个幻灯片 XML 文件，请检查 PPTX 包本身。
{{% /alert %}}

## **将演示文稿转换为 XML 文件**

使用 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类加载源演示文稿，然后将输出路径和 [SaveFormat.Xml](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveformat/#Xml) 传递给 [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)。源可以是任何受支持的加载格式，例如 PPT、PPTX 或 ODP。

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

当 XML 必须保持在内存中或传递给其他组件（如 Web 服务、存储提供方或 XML 处理管道）时，使用 [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) 的流重载。以下示例将结果写入 [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) 并获取生成的 XML 字节数组：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // 将 xmlData 传递给工作流中的下一个组件。
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **比较 XML 与演示文稿及导出格式**

根据结果的使用方式选择输出格式：

| 格式 | 输出 | 常见用途 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 演示文稿 | 检查结构、排查问题、比较生成的输出以及基于 XML 的集成 |
| PPT (`.ppt`) | 旧版二进制演示文稿文件 | 与旧 PowerPoint 工作流的兼容性 |
| PPTX (`.pptx`) | 包含多个部分的 Office Open XML 包 | 常规 PowerPoint 编辑和演示文稿交换 |
| PDF or TIFF | 固定布局页面或多页图像 | 查看、打印和归档 |
| PNG, JPEG, or SVG | 单个幻灯片的渲染表示 | 缩略图、预览和图像资产 |
| HTML or HTML5 | 面向 Web 的演示输出 | 浏览器查看和 Web 发布 |

与 PPT 和 PPTX 不同，XML 输出主要用于检查和数据导向的工作流。与 PDF、TIFF、HTML 和幻灯片图像格式不同，XML 只表示演示数据，而不将幻灯片渲染为页面或视觉资产。[supported file formats](/slides/zh/androidjava/supported-file-formats/) 表列出了 PowerPoint XML 演示文稿仅作为保存格式出现，因此在工作流需要将导出的文件重新加载回 Aspose.Slides 进行后续编辑时请勿使用它。

## **常见问题**

**`SaveFormat.Xml` 与保存 PPTX 文件是一样的吗？**

不是。PPTX 是包含多个 Office Open XML 部分的包，而 `SaveFormat.Xml` 仅创建 PowerPoint XML 演示文稿文件。

**我可以在不创建磁盘文件的情况下保存 XML 输出吗？**

可以。将可写流传递给 [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-)。例如，使用 [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) 进行内存处理。

**Aspose.Slides 能再次加载导出的 XML 文件吗？**

不能。PowerPoint XML 演示文稿目前仅支持保存，不支持加载。需要回环编辑时请使用 PPTX 或其他受支持的演示格式。

**XML 转换会将每个幻灯片渲染为页面或图像吗？**

不会。XML 转换仅写入结构化的演示数据。若需页面式输出请使用 PDF 或 TIFF，若需单个幻灯片图像请使用 PNG、JPEG 或 SVG。