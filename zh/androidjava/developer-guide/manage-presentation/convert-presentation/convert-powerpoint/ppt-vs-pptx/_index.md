---
title: "理解差异：PPT 与 PPTX"
linktitle: PPT 与 PPTX
type: docs
weight: 10
url: /zh/androidjava/ppt-vs-pptx/
keywords:
- PPT 与 PPTX
- PPT 或 PPTX
- 传统格式
- 现代格式
- 二进制格式
- 现代标准
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "通过 Aspose.Slides for Android（Java），比较 PowerPoint 的 PPT 与 PPTX，探讨格式差异、优势、兼容性及转换技巧。"
---
## **概述**

本文解释了 PPT 和 PPTX 格式之间的差异。它将 PPT 描述为 PowerPoint 97–2003 使用的传统二进制格式，而 PPTX 则被呈现为基于 Office Open XML 的现代格式，提供更大的灵活性，更适合扩展演示功能。本文还概述了在这些格式之间转换的关键方面，包括兼容性考虑，并展示了如何使用 Aspose.Slides 执行此类转换。总体而言，建议尽可能使用 PPTX。

## **PPT 是什么？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) 是二进制文件格式，即没有特殊工具无法查看其内容。首个 PowerPoint 97-2003 版本使用 PPT 文件格式，但其可扩展性有限。

## **PPTX 是什么？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) 是一种新的演示文件格式，基于 Office Open XML（ISO 29500:2008-2016，ECMA-376）标准。PPTX 是一组归档的 XML 和媒体文件。PPTX 格式易于扩展。例如，可以轻松添加对新图表类型或形状类型的支持，而无需在每个新 PowerPoint 版本中更改 PPTX 格式。PPTX 格式自 PowerPoint 2007 起开始使用。

## **PPT 与 PPTX**
尽管 PPTX 提供了更广泛的功能，PPT 仍然相当受欢迎。对 PPT 与 PPTX 之间相互转换的需求很高。

然而，在其他 Microsoft Office 格式中，旧 PPT 与新 PPTX 格式之间的转换是最复杂的挑战。虽然 PPT 格式的规范是开放的，但使用起来仍然困难。PowerPoint 可以在 PPT 文件中创建特殊部件（MetroBlob），以存储 PPTX 中不受 PPT 格式支持且在旧 PowerPoint 版本中无法显示的信息。当在现代 PowerPoint 版本中加载 PPT 文件或转换为 PPTX 格式时，这些信息可以被恢复。

Aspose.Slides 提供了一个通用接口来处理所有演示文稿格式。它可以非常简单地实现从 PPT 到 PPTX 以及从 PPTX 到 PPT 的转换。Aspose.Slides 完全支持从 PPT 到 PPTX 的转换，并且在一些限制下也支持从 PPTX 到 PPT 的转换。我们建议在可能的情况下使用 PPTX 格式。

{{% alert color="info" %}} 
使用在线[**Aspose.Slides Conversion app**](https://products.aspose.app/slides/zh/conversion/)检查 PPT 到 PPTX 和 PPTX 到 PPT 转换的质量。
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
阅读更多 [**如何将演示文稿从 PPT 转换为 PPTX**.](/slides/zh/androidjava/convert-ppt-to-pptx/)
{{% /alert %}} 

## **常见问题**

### 如果演示文稿可以正常打开且没有错误，保留旧的 PPT 有意义吗？
如果演示文稿能够可靠打开且无需协作或新功能，您可以保留为 PPT。但为确保未来的兼容性和可扩展性，最好[转换为 PPTX](/slides/zh/androidjava/convert-ppt-to-pptx/)：该格式基于开放的 OOXML 标准，更易被现代工具支持。

### 我该如何决定哪些文件应优先转换为 PPTX？
首先转换以下演示文稿：由多人编辑的；包含复杂的[charts](/slides/zh/androidjava/create-chart/)/[shapes](/slides/zh/androidjava/shape-manipulations/)；用于外部沟通的；或在[opened](/slides/zh/androidjava/open-presentation/)时触发警告的。

### 从 PPT 转换为 PPTX 再返回时，密码保护会保留吗？
密码仅在使用正确的转换并且工具支持加密时才能保留。更可靠的做法是[remove protection](/slides/zh/androidjava/password-protected-presentation/)、[convert](/slides/zh/androidjava/convert-ppt-to-pptx/)，然后根据安全策略重新应用保护。

### 为什么在将 PPTX 转回 PPT 时，一些效果会消失或被简化？
因为 PPT 不支持某些新对象/属性。PowerPoint 和工具可以将这些信息的“痕迹”存储在特殊块中以供以后恢复，但旧版本的 PowerPoint 无法呈现它们。