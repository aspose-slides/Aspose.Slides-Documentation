---
title: PPT 与 PPTX
type: docs
weight: 10
url: /zh/androidjava/ppt-vs-pptx/
keywords: "PPT 与 PPTX"
description: "了解 Aspose.Slides 中 PPT 与 PPTX 的区别。"
---

## **什么是 PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) 是一种二进制文件格式，即无法在没有特殊工具的情况下查看其内容。第一版 PowerPoint 97-2003 版本使用 PPT 文件格式，然而它的扩展性有限。

## **什么是 PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) 是一种新的演示文件格式，基于 Office Open XML (ISO 29500:2008-2016, ECMA-376) 标准。PPTX 是一组 XML 和媒体文件的归档集合。PPTX 格式易于扩展。例如，添加对新图表类型或形状类型的支持非常简单，而无需在每个新版本的 PowerPoint 中更改 PPTX 格式。PPTX 格式自 PowerPoint 2007 起被使用。

## **PPT 与 PPTX**
尽管 PPTX 提供了更广泛的功能，但 PPT 仍然相当受欢迎。从 PPT 转换为 PPTX 以及反向转换的需求非常高。

然而，在旧的 PPT 和新的 PPTX 格式之间的转换是所有 Microsoft Office 格式中最复杂的挑战。尽管 PPT 格式的规范是公开的，但与之合作仍然很困难。PowerPoint 可以在 PPT 文件中创建特殊部分（MetroBlob）来存储 PPTX 中的信息，而这些信息在 PPT 格式中不受支持，并且无法在旧版本的 PowerPoint 中显示。当将 PPT 文件加载到现代 PowerPoint 版本中或转换为 PPTX 格式时，这些信息可以恢复。

Aspose.Slides 提供了一个通用接口来处理所有演示格式。它允许非常简单地从 PPT 转换为 PPTX 以及从 PPTX 转换为 PPT。Aspose.Slides 完全支持从 PPT 转换为 PPTX，并且在某些限制下支持从 PPTX 转换为 PPT。我们建议尽可能使用 PPTX 格式。

{{% alert color="primary" %}} 

通过在线 [**Aspose.Slides 转换应用**](https://products.aspose.app/slides/conversion/) 检查 PPT 到 PPTX 和 PPTX 到 PPT 的转换质量。

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
阅读更多 [**如何将 PPT 演示文稿转换为 PPTX**.](/slides/zh/androidjava/convert-ppt-to-pptx/)
{{% /alert %}} 