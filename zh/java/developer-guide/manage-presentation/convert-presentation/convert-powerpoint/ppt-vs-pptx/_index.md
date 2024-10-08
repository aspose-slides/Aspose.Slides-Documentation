---
title: PPT与PPTX
type: docs
weight: 10
url: /java/ppt-vs-pptx/
keywords: "PPT与PPTX"
description: "了解Aspose.Slides中PPT与PPTX的区别。"
---

## **什么是PPT？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) 是一种二进制文件格式，即在没有特殊工具的情况下无法查看其内容。 第一个PowerPoint 97-2003版本使用PPT文件格式，但其扩展性有限。
## **什么是PPTX？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) 是一种新的演示文件格式，基于Office Open XML（ISO 29500:2008-2016，ECMA-376）标准。 PPTX是一个归档的XML和媒体文件集。 PPTX格式易于扩展。例如，轻松添加对新图表类型或形状类型的支持，而无需在每个新PowerPoint版本中更改PPTX格式。 PPTX格式自PowerPoint 2007起使用。
## **PPT与PPTX**
尽管PPTX提供了更广泛的功能，但PPT仍然相当受欢迎。转换PPT与PPTX之间的需求非常高。

然而，旧的PPT与新的PPTX格式之间的转换是其他Microsoft Office格式中最复杂的挑战。尽管PPT格式的规范是开放的，但与之打交道是困难的。PowerPoint可以在PPT文件中创建特殊部分（MetroBlob）以存储PPTX中不受PPT格式支持且无法在旧PowerPoint版本中显示的信息。当PPT文件在现代PowerPoint版本中加载或转换为PPTX格式时，可以恢复这些信息。

Aspose.Slides提供了一个通用接口来处理所有演示格式。它允许以非常简单的方式从PPT转换为PPTX和从PPTX转换为PPT。Aspose.Slides完全支持从PPT到PPTX的转换，并且在某些限制下也支持从PPTX到PPT的转换。我们建议在可能的情况下使用PPTX格式。

{{% alert color="primary" %}} 

使用在线 [**Aspose.Slides转换应用**](https://products.aspose.app/slides/conversion/) 检查PPT到PPTX和PPTX到PPT转换的质量。

{{% /alert %}} 

```java
// 初始化一个表示PPT文件的Presentation对象
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// 将PPT演示转换为PPTX格式
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
阅读更多 [**如何将演示文稿从PPT转换为PPTX**。](/slides/java/convert-ppt-to-pptx/)
{{% /alert %}}