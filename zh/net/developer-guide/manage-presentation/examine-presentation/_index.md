---
title: 检查演示文稿
type: docs
weight: 30
url: /zh/net/examine-presentation/
keywords:
- PowerPoint
- 演示文稿
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- PPTX
- PPT
- C#
- Csharp
- .NET
description: "在 C# 或 .NET 中读取和修改 PowerPoint 演示文稿属性"
---

Aspose.Slides for .NET 允许您检查演示文稿，以了解其属性并理解其行为。

{{% alert title="信息" color="info" %}} 

[PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) 和 [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) 类包含在此处操作中使用的属性和方法。

{{% /alert %}} 

## **检查演示文稿格式**

在处理演示文稿之前，您可能想要找出当前演示文稿的格式（PPT、PPTX、ODP等）。

您可以在不加载演示文稿的情况下检查其格式。请看以下 C# 代码：

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **获取演示文稿属性**

以下 C# 代码展示了如何获取演示文稿属性（关于演示文稿的信息）：

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

您可能希望查看 [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) 类下的属性。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) 方法，允许您对演示文稿属性进行更改。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下代码示例展示了如何编辑一些演示文稿属性：

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "我的标题";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

更改文档属性的结果如下所示。

![PowerPoint 演示文稿的更改文档属性](output_properties.png)

## **有用链接**

要获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接很有用：

- [检查演示文稿是否加密](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [检查演示文稿是否为写保护（只读）](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [在加载之前检查演示文稿是否受密码保护](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [确认用于保护演示文稿的密码](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)