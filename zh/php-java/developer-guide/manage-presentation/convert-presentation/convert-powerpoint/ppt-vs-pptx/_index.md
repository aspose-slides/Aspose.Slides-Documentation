---
title: PPT 与 PPTX
type: docs
weight: 10
url: /zh/php-java/ppt-vs-pptx/
keywords: "PPT 与 PPTX"
description: "阅读关于 Aspose.Slides 中 PPT 与 PPTX 之间的差异。"
---


## **什么是 PPT?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) 是一种二进制文件格式，即在没有特殊工具的情况下无法查看其内容。首个 PowerPoint 97-2003 版本使用 PPT 文件格式，但其可扩展性有限。
## **什么是 PPTX?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) 是一种基于 Office Open XML（ISO 29500:2008-2016，ECMA-376）标准的新型演示文件格式。PPTX 是一组存档的 XML 和媒体文件。PPTX 格式易于扩展。例如，可以轻松添加对新图表类型或形状类型的支持，而无需在每个新的 PowerPoint 版本中更改 PPTX 格式。PPTX 格式从 PowerPoint 2007 开始使用。
## **PPT 与 PPTX**
尽管 PPTX 提供了更广泛的功能，PPT 仍然相当受欢迎。将 PPT 转换为 PPTX 及反之的需求非常高。

然而，旧版 PPT 与新版 PPTX 格式之间的转换是其他 Microsoft Office 格式中最复杂的挑战。尽管 PPT 格式的规范是开放的，但使用起来较为困难。 PowerPoint 可以在 PPT 文件中创建特殊部分（MetroBlob）以存储 PPTX 中不受 PPT 格式支持且无法在旧版 PowerPoint 中显示的信息。这些信息可以在现代 PowerPoint 版本中加载 PPT 文件或转换为 PPTX 格式时恢复。

Aspose.Slides 提供了一个通用接口，用于处理所有演示格式。它允许以非常简单的方式从 PPT 转换为 PPTX，并从 PPTX 转换为 PPT。Aspose.Slides 完全支持从 PPT 转换到 PPTX，并且在某些限制下支持从 PPTX 转换到 PPT。我们建议尽可能使用 PPTX 格式。

{{% alert color="primary" %}} 

检查 PPT 到 PPTX 和 PPTX 到 PPT 转换的质量，使用在线 [**Aspose.Slides 转换应用**](https://products.aspose.app/slides/conversion/)。

{{% /alert %}} 

```php
  # 实例化一个表示 PPT 文件的演示文稿对象
  $pres = new Presentation("PPTtoPPTX.ppt");
  try {
    # 保存 PPT 演示文稿为 PPTX 格式
    $pres->save("PPTtoPPTX_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
阅读更多 [**如何将演示文稿 PPT 转换为 PPTX**.](/slides/zh/php-java/convert-ppt-to-pptx/)
{{% /alert %}} 
