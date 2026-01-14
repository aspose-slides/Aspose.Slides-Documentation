---
title: "了解差异：PPT 与 PPTX"
linktitle: PPT 与 PPTX
type: docs
weight: 10
url: /zh/php-java/ppt-vs-pptx/
keywords:
- PPT 与 PPTX
- PPT 或 PPTX
- 传统格式
- 现代格式
- 二进制格式
- 现代标准
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "比较 PowerPoint 的 PPT 与 PPTX，使用 Aspose.Slides for PHP via Java，探讨格式差异、优势、兼容性和转换技巧。"
---

## **PPT 是什么？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) 是一种二进制文件格式，也就是说没有专门的工具无法查看其内容。最早的 PowerPoint 97-2003 版本使用 PPT 文件格式，但其可扩展性有限。

## **PPTX 是什么？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) 是一种新型的演示文稿文件格式，基于 Office Open XML (ISO 29500:2008-2016, ECMA-376) 标准。PPTX 是一组已归档的 XML 和媒体文件。PPTX 格式易于扩展。例如，可以轻松添加对新图表类型或形状类型的支持，而无需在每个新 PowerPoint 版本中更改 PPTX 格式。PPTX 格式自 PowerPoint 2007 起开始使用。

## **PPT 与 PPTX**
尽管 PPTX 提供了更广泛的功能，PPT 仍然相当流行。对 PPT 与 PPTX 相互转换的需求非常高。

然而，在旧 PPT 与新 PPTX 格式之间的转换是所有 Microsoft Office 格式中最复杂的挑战。虽然 PPT 格式的规范是公开的，但使用起来仍然困难。PowerPoint 可以在 PPT 文件中创建特殊部件（MetroBlob），用于存储 PPTX 中不受 PPT 格式支持且旧版本 PowerPoint 无法显示的信息。当 PPT 文件在现代 PowerPoint 版本中打开或转换为 PPTX 格式时，这些信息可以恢复。

Aspose.Slides 提供了通用的 API 来处理所有演示文稿格式。它可以非常简便地实现 PPT 转 PPTX 和 PPTX 转 PPT。Aspose.Slides 完全支持从 PPT 转 PPTX，并在一定限制下支持从 PPTX 转 PPT。我们建议在可能的情况下使用 PPTX 格式。

{{% alert color="primary" %}} 
使用在线 **Aspose.Slides Conversion app** 检查 PPT 转 PPTX 和 PPTX 转 PPT 转换的质量。
{{% /alert %}} 
```php
  # 实例化一个表示 PPT 文件的 Presentation 对象
  $pres = new Presentation("PPTtoPPTX.ppt");
  try {
    # 将 PPT 演示文稿保存为 PPTX 格式
    $pres->save("PPTtoPPTX_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
了解更多 **How to Convert Presentations PPT to PPTX**.(/slides/zh/php-java/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

**如果旧的 PPT 演示文稿能够正常打开，仍然保留它们有没有意义？**

如果演示文稿能够可靠打开且不需要协作或新功能，您可以继续使用 PPT。但为了未来的兼容性和可扩展性，最好 [convert to PPTX](/slides/zh/php-java/convert-ppt-to-pptx/)：该格式基于开放的 OOXML 标准，更容易被现代工具支持。

**如何决定哪些文件应优先转换为 PPTX？**

首先转换以下演示文稿：由多人编辑的；包含复杂的 [charts](/slides/zh/php-java/create-chart/)/[shapes](/slides/zh/php-java/shape-manipulations/)；用于外部沟通的；或在 [opened](/slides/zh/php-java/open-presentation/) 时出现警告的。

**在 PPT 与 PPTX 之间相互转换时，密码保护会被保留吗？**

只有在使用支持正确转换和加密的工具时，密码才会被保留。更可靠的做法是先 [remove protection](/slides/zh/php-java/password-protected-presentation/)，再 [convert](/slides/zh/php-java/convert-ppt-to-pptx/)，然后根据安全策略重新应用保护。

**为什么在 PPTX 转回 PPT 时，一些效果会消失或被简化？**

因为 PPT 不支持某些新对象/属性。PowerPoint 和工具可以将这些信息的“痕迹”存储在特殊块中以便后续恢复，但旧版本的 PowerPoint 无法渲染这些信息。