---
title: PPT vs PPTX
type: docs
weight: 10
url: /zh/net/ppt-vs-pptx/
keywords: "PPT vs PPTX, PPT 或 PPTX, PowerPoint 演示文稿, 格式, C#, Csharp, .NET"
description: "关于 PowerPoint 演示文稿格式。PPT vs PPTX。C# 或 .NET 中的差异"
---


## **什么是 PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) 是一种二进制文件格式，即无法在没有特殊工具的情况下查看其内容。第一版 PowerPoint 97-2003 使用 PPT 文件格式，但其扩展性有限。
## **什么是 PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) 是一种基于 Office Open XML（ISO 29500:2008-2016，ECMA-376）标准的新演示文件格式。PPTX 是一组归档的 XML 和媒体文件。PPTX 格式易于扩展。例如，可以轻松添加对新图表类型或形状类型的支持，而无需在每个新 PowerPoint 版本中更改 PPTX 格式。PPTX 格式从 PowerPoint 2007 开始使用。

## **PPT vs PPTX**
尽管 PPTX 提供了更广泛的功能，PPT 仍然相当受欢迎。转换 PPT 至 PPTX 及反之的需求也非常高。

然而，旧的 PPT 与新的 PPTX 格式之间的转换是其他 Microsoft Office 格式中最复杂的挑战。尽管 PPT 格式的规范是公开的，但与其合作是困难的。PowerPoint 可以在 PPT 文件中创建特殊部分（MetroBlob）来存储 PPTX 中不受 PPT 格式支持且无法在旧版本 PowerPoint 中显示的信息。当 PPT 文件在现代 PowerPoint 版本中加载或转换为 PPTX 格式时，可以恢复这些信息。

Aspose.Slides 提供了一个通用接口来处理所有演示格式。它允许以非常简单的方式将 PPT 转换为 PPTX，并将 PPTX 转换为 PPT。Aspose.Slides 完全支持从 PPT 转换到 PPTX，并且在某些限制下也支持从 PPTX 转换到 PPT。我们建议在可能的情况下使用 PPTX 格式。

{{% alert color="primary" %}} 

通过在线 [**Aspose.Slides 转换应用**](https://products.aspose.app/slides/conversion/) 检查 PPT 到 PPTX 以及 PPTX 到 PPT 的转换质量。

{{% /alert %}} 

```c#
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// 将 PPTX 演示文稿保存为 PPTX 格式
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 
阅读更多 [**如何将演示文稿从 PPT 转换为 PPTX**.](/slides/zh/net/convert-ppt-to-pptx/)
{{% /alert %}} 