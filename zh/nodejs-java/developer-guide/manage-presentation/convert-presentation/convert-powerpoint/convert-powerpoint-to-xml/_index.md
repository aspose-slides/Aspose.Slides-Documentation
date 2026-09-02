---
title: 在 JavaScript 中将 PowerPoint 演示文稿转换为 XML
linktitle: PowerPoint 转 XML
type: docs
weight: 145
url: /zh/nodejs-java/convert-powerpoint-to-xml/
keywords:
- 将 PowerPoint 转换为 XML
- 将演示文稿转换为 XML
- PPT 转 XML
- PPTX 转 XML
- ODP 转 XML
- PowerPoint XML 演示文稿
- SaveFormat.Xml
- 将演示文稿保存为 XML
- 将演示文稿导出为 XML
- XML 流
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 JavaScript 中将 PowerPoint 和 OpenDocument 演示文稿转换为 PowerPoint XML 文件或流。"
---
## **概述**

Aspose.Slides for Node.js via Java 可以将 PowerPoint 演示文稿转换为 PowerPoint XML 演示文稿格式。当您需要文本化表示以检查演示文稿结构、排查生成的文档、在自动化测试中比较输出，或将 XML 集成到而非演示文稿包的工作流中时，XML 输出非常有用。

使用 [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save) 方法，并将来自 [SaveFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/) 枚举的 `Xml` 值作为参数。您可以将结果直接写入文件或流中。

{{% alert color="info" title="注意" %}}
`SaveFormat.Xml` 创建 PowerPoint XML 演示文稿。它不会提取 PPTX 包内存储的各个 Office Open XML 部分。如果您需要确切的 PPTX 包部件，例如 `ppt/presentation.xml` 或单个幻灯片 XML 文件，请检查 PPTX 包本身。
{{% /alert %}}

## **将演示文稿转换为 XML 文件**

使用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类加载源演示文稿，然后将输出路径和 `SaveFormat.Xml` 传递给 [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save)。源文件可以是任何受支持的加载格式，例如 PPT、PPTX 或 ODP。

下面的示例将 PPTX 演示文稿转换为 XML 文件：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **将 XML 输出写入流**

当 XML 必须保留在内存中或传递给其他组件（如 Web 服务、存储提供程序或 XML 处理管道）时，请使用 [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save) 的流重载。下面的示例将结果写入 Java `ByteArrayOutputStream`，并将生成的数据复制到 Node.js `Buffer`：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // 将 xmlBuffer 传递给工作流中的下一个组件。
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **将 XML 与演示文稿及导出格式进行比较**

根据结果的使用方式选择输出格式：

| 格式 | 输出 | 典型用法 |
| --- | --- | --- |
| PowerPoint XML（`.xml`） | PowerPoint XML 演示文稿 | 检查结构、排查问题、比较生成的输出以及基于 XML 的集成 |
| PPT（`.ppt`） | 旧版二进制演示文稿文件 | 兼容旧版 PowerPoint 工作流 |
| PPTX（`.pptx`） | 包含多个部件的 Office Open XML 包 | 常规 PowerPoint 编辑和演示文稿交换 |
| PDF or TIFF | 固定布局页面或多页图像 | 查看、打印和归档 |
| PNG, JPEG, or SVG | 单个幻灯片的渲染表示 | 缩略图、预览和图像资产 |
| HTML or HTML5 | 面向 Web 的演示输出 | 浏览器查看和网络发布 |

与 PPT 和 PPTX 不同，XML 输出主要用于检查和面向数据的工作流。与 PDF、TIFF、HTML 以及幻灯片图像格式不同，XML 代表的是演示数据，而不是将幻灯片渲染为页面或视觉资源。[supported file formats](/slides/zh/nodejs-java/supported-file-formats/) 表格将 PowerPoint XML 演示文稿列为仅保存格式，因此在工作流需要将导出的文件重新加载到 Aspose.Slides 进行后续编辑时，请勿使用它。

## **常见问题**

**`SaveFormat.Xml` 与保存 PPTX 文件相同吗？**

否。PPTX 是一个包含多个 Office Open XML 部件的包，而 `SaveFormat.Xml` 创建的是 PowerPoint XML 演示文稿文件。

**我可以在不在磁盘上创建文件的情况下保存 XML 输出吗？**

是。将可写流传递给 [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save)。例如，使用 Java `ByteArrayOutputStream`，并将其数据复制到 Node.js `Buffer` 以进行内存处理。

**Aspose.Slides 能再次加载导出的 XML 文件吗？**

否。目前仅支持将 PowerPoint XML 演示文稿保存，而不支持加载。需要往返编辑时请使用 PPTX 或其他受支持的演示文稿格式。

**XML 转换会将每个幻灯片渲染为页面或图像吗？**

否。XML 转换仅写入结构化的演示数据。若需面向页面的输出，请使用 PDF 或 TIFF；若需单个幻灯片图像，请使用 PNG、JPEG 和 SVG。