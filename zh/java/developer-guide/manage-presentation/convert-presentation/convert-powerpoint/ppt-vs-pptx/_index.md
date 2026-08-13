---
title: "了解区别：PPT 与 PPTX"
linktitle: PPT 与 PPTX
type: docs
weight: 10
url: /zh/java/ppt-vs-pptx/
keywords:
- PPT 与 PPTX
- PPT 或 PPTX
- 传统格式
- 现代格式
- 二进制格式
- 现代标准
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 对 PowerPoint 的 PPT 与 PPTX 进行比较，探讨格式差异、优势、兼容性和转换技巧。"
---
## **概述**

本文解释了 PPT 与 PPTX 格式之间的差异。它将 PPT 描述为 PowerPoint 97–2003 使用的传统二进制格式，而 PPTX 则作为基于 Office Open XML 的现代格式，提供更大的灵活性并更适合扩展演示功能。文章还概述了在这两种格式之间转换的关键要点，包括兼容性考虑，并展示了如何使用 Aspose.Slides 执行此类转换。一般情况下，建议尽可能使用 PPTX。

## **什么是 PPT？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) 是一种二进制文件格式，换句话说，没有特殊工具无法查看其内容。PowerPoint 97-2003 版本最初使用 PPT 格式，但其可扩展性受到限制。

## **什么是 PPTX？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) 是一种基于 Office Open XML（ISO 29500:2008-2016，ECMA-376）标准的新演示文件格式。PPTX 是由 XML 与媒体文件组成的归档集合，易于扩展。例如，可以轻松为新图表类型或形状类型添加支持，而无需在每个新 PowerPoint 版本中修改 PPTX 格式。PPTX 格式自 PowerPoint 2007 开始使用。

## **PPT 与 PPTX 的比较**
虽然 PPTX 提供了更广泛的功能，PPT 仍然相当流行。对 PPT 与 PPTX 之间相互转换的需求非常高。

然而，在所有 Microsoft Office 格式中，旧 PPT 与新 PPTX 之间的转换是最复杂的挑战。尽管 PPT 格式的规范是公开的，但实际操作仍然困难。PowerPoint 可以在 PPT 文件中创建特殊部分（MetroBlob），用于存储 PPTX 中 PPT 格式不支持的信息，这些信息在旧版本 PowerPoint 中无法显示。加载到现代 PowerPoint 版本或转换为 PPTX 格式时，这些信息可以被恢复。

Aspose.Slides 提供统一的接口来处理所有演示格式。它能够以非常简单的方式实现 PPT 到 PPTX 以及 PPTX 到 PPT 的转换。Aspose.Slides 完全支持从 PPT 转换为 PPTX，也支持从 PPTX 转换为 PPT（但有一定限制）。我们建议在可能的情况下使用 PPTX 格式。

{{% alert color="info" %}} 
检查 PPT 转 PPTX 和 PPTX 转 PPT 转换的质量，请使用在线[**Aspose.Slides Conversion app**](https://products.aspose.app/slides/zh/conversion/)。
{{% /alert %}} 

```java
import com.aspose.slides.*;

// 实例化一个表示 PPT 文件的 Presentation 对象
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// 将 PPT 演示文稿保存为 PPTX 格式
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
阅读更多[**How to Convert Presentations PPT to PPTX**.](/slides/zh/java/convert-ppt-to-pptx/)
{{% /alert %}} 

## **常见问题**

### 是否还有必要保留可以正常打开且没有错误的旧 PPT 演示文稿？

如果演示文稿能够可靠打开且不需要协作或使用新功能，可以继续保留 PPT。但为了未来的兼容性和可扩展性，最好[convert to PPTX](/slides/zh/java/convert-ppt-to-pptx/)：该格式基于开放的 OOXML 标准，更容易被现代工具支持。

### 如何决定哪些文件应优先转换为 PPTX？

优先转换以下演示文稿：多人编辑的；包含复杂[charts](/slides/zh/java/create-chart/)[/shapes](/slides/zh/java/shape-manipulations/)的；用于外部交流的；或在[opened](/slides/zh/java/open-presentation/)时触发警告的。

### 将 PPT 转换为 PPTX 再转换回 PPT 时，密码保护会被保留吗？

只有在使用支持正确转换和加密的工具时，密码才会被保留下来。更可靠的做法是先[remove protection](/slides/zh/java/password-protected-presentation/)，然后[convert](/slides/zh/java/convert-ppt-to-pptx/)，最后按照安全策略重新应用保护。

### 为什么某些效果在 PPTX 转回 PPT 时会消失或被简化？

因为 PPT 不支持某些新对象/属性。PowerPoint 和其他工具可以将这些信息的“痕迹”存储在特殊块中以便以后恢复，但旧版本的 PowerPoint 无法渲染这些信息。