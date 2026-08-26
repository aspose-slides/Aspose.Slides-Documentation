---
title: 在 .NET 中检索和更新演示文稿信息
linktitle: 演示文稿信息
type: docs
weight: 30
url: /zh/net/examine-presentation/
keywords:
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- 更新属性
- 检查 PPTX
- 检查 PPT
- 检查 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 .NET 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快的洞察和更智能的内容审计。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中检查演示文稿信息。它说明了如何在不加载完整文件的情况下确定演示文稿的当前格式，读取其文档属性，并在需要时更新这些属性。

示例基于 [PresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationinfo/) 和 [DocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/documentproperties/) API，演示了处理演示文稿元数据的常见操作。

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解该演示文稿当前的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查其格式。请参阅以下 C# 代码：

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **获取演示文稿属性**

以下 C# 代码展示了如何获取演示文稿属性（有关演示文稿的信息）：

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// 省略
```

您可能想查看 [DocumentProperties 类下的属性](https://reference.aspose.com/slides/zh/net/aspose.slides/documentproperties/#properties)。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) 方法，允许您修改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下代码示例展示了如何编辑某些演示文稿属性：

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

更改文档属性后的结果如下所示。

![PowerPoint 演示文稿的更改后文档属性](output_properties.png)

## **有用的链接**

要获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接有用：

- [密码保护演示文稿](/slides/zh/net/password-protected-presentation/)
- [写保护演示文稿](/slides/zh/net/write-protected-presentation/)

## **常见问题**

**如何检查字体是否已嵌入以及具体是哪几种？**

在演示文稿级别查找 [embedded-font information](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsmanager/getembeddedfonts/)，然后将这些条目与 [实际在内容中使用的字体](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsmanager/getfonts/) 进行比对，以确定哪些字体对渲染至关重要。

**如何快速判断文件是否包含隐藏幻灯片以及数量？**

遍历 [slide collection](https://reference.aspose.com/slides/zh/net/aspose.slides/slidecollection/)，检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/hidden/)。

**我能检测是否使用了自定义幻灯片尺寸和方向，以及它们是否与默认值不同吗？**

可以。将当前的 [slide size](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/slidesize/) 和方向与标准预设进行比较；这有助于预判打印和导出时的行为。

**是否有快捷方式查看图表是否引用外部数据源？**

可以。遍历所有 [charts](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chart/)，检查它们的 [data source](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/datasourcetype/)，并记录数据是内部的还是基于链接的，包括任何断开的链接。

**如何评估可能导致渲染或 PDF 导出变慢的“沉重”幻灯片？**

对于每张幻灯片，统计对象数量并查找大尺寸图像、透明度、阴影、动画和多媒体等因素；给出一个大致的复杂度评分，以标记潜在的性能热点。