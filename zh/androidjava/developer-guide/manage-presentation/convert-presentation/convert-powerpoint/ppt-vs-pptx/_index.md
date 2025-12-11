---
title: "了解差异：PPT 与 PPTX"
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
description: "通过 Java 在 Android 上使用 Aspose.Slides 对 PowerPoint 的 PPT 与 PPTX 进行比较，探讨格式差异、优势、兼容性以及转换技巧。"
---

## **什么是 PPT？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) 是二进制文件格式，即没有特殊工具无法查看其内容。第一批 PowerPoint 97-2003 版本使用 PPT 文件格式，但其可扩展性有限。

## **什么是 PPTX？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) 是一种基于 Office Open XML (ISO 29500:2008-2016, ECMA-376) 标准的新演示文稿文件格式。PPTX 是 XML 和媒体文件的归档集合。PPTX 格式易于扩展。例如，可以轻松为新图表类型或形状类型添加支持，而无需在每个新 PowerPoint 版本中更改 PPTX 格式。PPTX 格式自 PowerPoint 2007 起开始使用。

## **PPT 与 PPTX**
虽然 PPTX 提供了更广泛的功能，PPT 仍然相当流行。将 PPT 转换为 PPTX 以及相反的需求非常高。

然而，在旧 PPT 与新 PPTX 格式之间的转换是所有 Microsoft Office 格式中最复杂的挑战之一。虽然 PPT 格式的规范是开放的，但实际使用仍然困难。PowerPoint 可以在 PPT 文件中创建特殊部分（MetroBlob）来存储 PPTX 中不被 PPT 支持的信息，这些信息在旧 PowerPoint 版本中无法显示。当在现代 PowerPoint 版本中加载 PPT 文件或转换为 PPTX 格式时，这些信息可以被恢复。

Aspose.Slides 提供了一个通用接口来处理所有演示文稿格式。它允许以非常简单的方式在 PPT 与 PPTX 之间相互转换。Aspose.Slides 完全支持从 PPT 转换为 PPTX，也支持从 PPTX 转换为 PPT（但有一些限制）。我们建议在可能的情况下使用 PPTX 格式。

{{% alert color="primary" %}} 
请使用在线[**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/)检查 PPT 转 PPTX 以及 PPTX 转 PPT 转换的质量。 
{{% /alert %}} 
```java
// 实例化一个表示 PPT 文件的 Presentation 对象
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// 将 PPT 演示文稿保存为 PPTX 格式
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
了解更多[**如何将演示文稿从 PPT 转换为 PPTX**](/slides/zh/androidjava/convert-ppt-to-pptx/)。 
{{% /alert %}} 

## **FAQ**

**如果演示文稿可以正常打开且没有错误，仍然保留 PPT 格式有什么意义吗？**

如果演示文稿能够可靠打开且不需要协作或新功能，可以保留为 PPT。但为了未来的兼容性和可扩展性，最好[转换为 PPTX](/slides/zh/androidjava/convert-ppt-to-pptx/)：该格式基于开放的 OOXML 标准，且更容易被现代工具支持。

**如何决定哪些文件应优先转换为 PPTX？**

首先转换以下演示文稿：由多人编辑的；包含复杂[图表](/slides/zh/androidjava/create-chart/)、[形状](/slides/zh/androidjava/shape-manipulations/)的；用于对外沟通的；或者在[打开](/slides/zh/androidjava/open-presentation/)时触发警告的。

**在 PPT 与 PPTX 相互转换时，密码保护会被保留吗？**

只有在使用正确的转换工具并支持相应加密时，密码才会被保留。更可靠的做法是先[移除保护](/slides/zh/androidjava/password-protected-presentation/)，[转换](/slides/zh/androidjava/convert-ppt-to-pptx/)，然后根据安全策略重新应用保护。

**为什么在将 PPTX 转回 PPT 时，有些效果会消失或被简化？**

因为 PPT 不支持某些新对象/属性。PowerPoint 和工具可以将这些信息的“痕迹”存储在特殊块中以供后续恢复，但旧版本的 PowerPoint 无法渲染它们。