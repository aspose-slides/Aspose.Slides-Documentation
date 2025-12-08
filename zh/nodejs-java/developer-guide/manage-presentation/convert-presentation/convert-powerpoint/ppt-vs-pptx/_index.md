---
title: PPT 与 PPTX
type: docs
weight: 10
url: /zh/nodejs-java/ppt-vs-pptx/
keywords: "PPT 与 PPTX"
description: "了解 Aspose.Slides 中 PPT 与 PPTX 的区别。"
---

## **什么是 PPT？**

[**PPT**](https://docs.fileformat.com/presentation/ppt/) 是一种二进制文件格式，即没有特殊工具无法查看其内容。首个 PowerPoint 97-2003 版本使用 PPT 文件格式，但其可扩展性有限。

## **什么是 PPTX？**

[**PPTX**](https://docs.fileformat.com/presentation/pptx/) 是一种基于 Office Open XML（ISO 29500:2008-2016，ECMA-376）标准的新演示文稿文件格式。PPTX 是一组已归档的 XML 和媒体文件。PPTX 格式易于扩展。例如，可以轻松添加对新图表类型或形状类型的支持，而无需在每个新 PowerPoint 版本中更改 PPTX 格式。PPTX 格式自 PowerPoint 2007 起使用。

## **PPT 与 PPTX**

虽然 PPTX 提供了更广泛的功能，PPT 仍然相当流行。将 PPT 转换为 PPTX 或相反的需求非常高。

然而，在其他 Microsoft Office 格式中，旧 PPT 与新 PPTX 之间的转换是最复杂的挑战。虽然 PPT 格式的规范是公开的，但使用起来仍然困难。PowerPoint 可以在 PPT 文件中创建特殊部分（MetroBlob）来存储 PPTX 中不受 PPT 格式支持且旧 PowerPoint 版本无法显示的信息。当在现代 PowerPoint 版本中加载 PPT 文件或转换为 PPTX 格式时，这些信息可以恢复。

Aspose.Slides 提供了一个通用类来处理所有演示文稿格式。它可以非常简单地实现 PPT 转 PPTX 和 PPTX 转 PPT 的转换。Aspose.Slides 完全支持 PPT 转 PPTX 的转换，也支持 PPTX 转 PPT，但有一些限制。我们建议尽可能使用 PPTX 格式。

{{% alert color="primary" %}} 

检查 PPT 转 PPTX 和 PPTX 转 PPT 转换的质量，请使用在线 [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/)。

{{% /alert %}} 
```javascript
// 实例化一个表示 PPT 文件的 Presentation 对象
var pres = new aspose.slides.Presentation("PPTtoPPTX.ppt");
try {
    // 将 PPT 演示文稿保存为 PPTX 格式
    pres.save("PPTtoPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
阅读更多 [**如何将演示文稿从 PPT 转换为 PPTX**.]( /slides/nodejs-java/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

**是否有必要保留可以正常打开的旧 PPT 演示文稿？**

如果演示文稿能够可靠打开且不需要协作或新功能，可以保留为 PPT。但为了未来的兼容性和可扩展性，最好 [转换为 PPTX](/slides/zh/nodejs-java/convert-ppt-to-pptx/)：该格式基于开放的 OOXML 标准，现代工具更容易支持。

**如何决定哪些文件应优先转换为 PPTX？**

首先转换以下演示文稿：由多人编辑的；包含复杂的 [图表](/slides/zh/nodejs-java/create-chart/)/[形状](/slides/zh/nodejs-java/shape-manipulations/)；用于外部通信的；或在 [打开](/slides/zh/nodejs-java/open-presentation/) 时触发警告的。

**在 PPT 与 PPTX 相互转换时，密码保护会被保留吗？**

只有在使用的工具正确转换并支持加密时，密码才会保留下来。更可靠的做法是先 [移除保护](/slides/zh/nodejs-java/password-protected-presentation/)，再 [转换](/slides/zh/nodejs-java/convert-ppt-to-pptx/)，然后根据安全策略重新应用保护。

**为何某些效果在 PPTX 转回 PPT 时消失或被简化？**

因为 PPT 不支持某些新对象/属性。PowerPoint 和工具可以将这些信息的 “痕迹” 存储在特殊块中以供以后恢复，但旧版本的 PowerPoint 无法渲染它们。