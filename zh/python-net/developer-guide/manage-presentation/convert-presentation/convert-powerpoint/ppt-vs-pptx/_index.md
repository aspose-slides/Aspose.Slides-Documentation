---
title: PPT 与 PPTX
type: docs
weight: 10
url: /zh/python-net/ppt-vs-pptx/
keywords: "PPT 与 PPTX, PPT 或 PPTX, PowerPoint 演示文稿, 格式, Python"
description: "有关 PowerPoint 演示文稿格式。PPT 与 PPTX。Python 中的差异"
---

## **什么是 PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) 是一种二进制文件格式，即没有特殊工具无法查看其内容。第一版 PowerPoint 97-2003 版本使用 PPT 文件格式，但其可扩展性有限。

## **什么是 PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) 是一种基于 Office Open XML (ISO 29500:2008-2016, ECMA-376) 标准的新演示文件格式。PPTX 是一组归档的 XML 和媒体文件。PPTX 格式易于扩展。例如，支持新增图表类型或形状类型很简单，而无需在每个新 PowerPoint 版本中更改 PPTX 格式。PPTX 格式自 PowerPoint 2007 开始使用。

## **PPT 与 PPTX**
尽管 PPTX 提供了更广泛的功能，但 PPT 仍然相当受欢迎。从 PPT 转换到 PPTX 以及反向转换的需求非常高。

然而，旧的 PPT 和新的 PPTX 格式之间的转换是其他 Microsoft Office 格式中最复杂的挑战。尽管 PPT 格式的规格是开放的，但与它一起工作是困难的。PowerPoint 可以在 PPT 文件中创建特殊部分（MetroBlob）来存储 PPTX 中不受 PPT 格式支持的信息，并且无法在旧的 PowerPoint 版本中显示。这些信息可以在将 PPT 文件加载到现代 PowerPoint 版本或转换为 PPTX 格式时恢复。

Aspose.Slides 提供了一个通用接口，可以处理所有演示格式。它允许以非常简单的方式从 PPT 转换为 PPTX 和从 PPTX 转换为 PPT。Aspose.Slides 完全支持从 PPT 到 PPTX 的转换，并且也支持从 PPTX 到 PPT 的转换，尽管存在一些限制。我们建议在可能的情况下使用 PPTX 格式。

{{% alert color="primary" %}} 

使用在线 [**Aspose.Slides 转换应用**](https://products.aspose.app/slides/conversion/) 检查 PPT 到 PPTX 和 PPTX 到 PPT 转换的质量。

{{% /alert %}} 

```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 对象
pres = slides.Presentation("PPTtoPPTX.ppt")

# 将 PPTX 演示文稿保存为 PPTX 格式
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
阅读更多 [**如何将演示文稿从 PPT 转换为 PPTX**.](/slides/zh/python-net/convert-ppt-to-pptx/)
{{% /alert %}} 