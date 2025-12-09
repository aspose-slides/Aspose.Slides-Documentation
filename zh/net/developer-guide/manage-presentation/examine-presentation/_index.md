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
description: "使用 .NET 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快速的洞察和更智能的内容审计。"
---

Aspose.Slides for .NET 允许您检查演示文稿，以了解其属性和行为。

{{% alert title="Info" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) and [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) classes contain the properties and methods used in operations here.

{{% /alert %}} 

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解当前演示文稿使用的是哪种格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查其格式。参见以下 C# 代码：
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **获取演示文稿属性**

以下 C# 代码演示了如何获取演示文稿属性（有关演示文稿的信息）：
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// 省略
```


您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) 类下的属性。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) 方法，允许您修改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下示例代码演示了如何编辑部分演示文稿属性：
```c#
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

## **有用链接**

若想获取有关演示文稿及其安全属性的更多信息，以下链接可能对您有帮助：

- [检查演示文稿是否加密](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [检查演示文稿是否受写保护（只读）](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [在加载演示文稿之前检查其是否受密码保护](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [确认用于保护演示文稿的密码](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **常见问题**

**如何检查字体是否已嵌入以及具体哪些字体？**

在演示文稿级别查找 [embedded-font 信息](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/)，然后将这些条目与 [实际在内容中使用的字体集合](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) 进行比较，以确定哪些字体对渲染至关重要。

**如何快速判断文件中是否存在隐藏幻灯片以及数量？**

遍历 [slide collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/)，检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/)。

**我能检测是否使用了自定义幻灯片尺寸和方向，并且它们是否与默认值不同吗？**

可以。将当前的 [slide size](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) 和方向与标准预设进行比较；这有助于预测打印和导出时的行为。

**有没有快速方法查看图表是否引用了外部数据源？**

可以。遍历所有 [charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)，检查它们的 [data source](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/)，并记录数据是内部的还是基于链接的，包括任何断开的链接。

**如何评估可能导致渲染或 PDF 导出变慢的“重量”幻灯片？**

对于每个幻灯片，统计对象数量并查找大尺寸图像、透明度、阴影、动画和多媒体；为其分配一个粗略的复杂度分数，以标记潜在的性能热点。