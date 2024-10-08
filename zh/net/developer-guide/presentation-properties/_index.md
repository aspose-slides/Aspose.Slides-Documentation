---
title: 演示文稿属性 - 在 C# 中访问或修改 PowerPoint 演示文稿属性
linktitle: 演示文稿属性
type: docs
weight: 70
url: /zh/net/presentation-properties/
keywords: "如何在powerpoint中删除最后修改者, PowerPoint属性, PowerPoint演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "C# 或 .NET 中的 PowerPoint 演示文稿属性"
---


## **实时示例**
尝试 [**Aspose.Slides 元数据**](https://products.aspose.app/slides/metadata) 在线应用程序，查看如何通过 Aspose.Slides API 处理文档属性：

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **关于演示文稿属性**
如前所述，Aspose.Slides for .NET 支持两种类型的文档属性，即 **内置** 和 **自定义** 属性。因此，开发人员可以使用 Aspose.Slides for .NET API 访问这两种属性。Aspose.Slides for .NET 提供了一个类 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties)，它表示与演示文稿文件关联的文档属性，通过 [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/properties/index) 属性进行访问。开发人员可以使用 **Presentation** 对象暴露的 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties) 属性访问演示文稿文件的文档属性，如下所述：



{{% alert color="primary" %}} 

请注意，您无法为 **Application** 和 **Producer** 字段设置值，因为 Aspose Ltd. 和 Aspose.Slides for .NET x.x.x 将显示在这些字段中。

{{% /alert %}} 


## **管理演示文稿属性**
Microsoft PowerPoint 提供了向演示文稿文件添加某些属性的功能。这些文档属性允许一些有用的信息与文档（演示文稿文件）一起存储。文档属性分为以下两种：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置** 属性包含有关文档的一般信息，例如文档标题、作者姓名、文档统计信息等。**自定义** 属性是由用户定义的 **名称/值** 对，其中名称和值均由用户定义。使用 Aspose.Slides for .NET，开发人员可以访问和修改内置属性以及自定义属性的值。Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。您需要做的就是点击 Office 图标，然后选择 Microsoft PowerPoint 2007 的 **准备 | 属性 | 高级属性** 菜单项。在选择 **高级属性** 菜单项后，将出现一个对话框，允许您管理 PowerPoint 文件的文档属性。在 **属性对话框** 中，您可以看到许多选项卡，如 **常规、摘要、统计、内容和自定义**。所有这些选项卡允许配置与 PowerPoint 文件相关的不同信息。**自定义** 选项卡用于管理 PowerPoint 文件的自定义属性。
## **访问内置属性**
这些通过 **IDocumentProperties** 对象暴露的属性包括：**Creator(作者)**、**描述**、**关键词**、**创建**（创建日期）、**修改**（修改日期）、**打印**（最后打印日期）、**LastModifiedBy**、**关键词**、**SharedDoc**（是否在不同的生产者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessBuiltinProperties-AccessBuiltinProperties.cs" >}}
## **修改内置属性**
修改演示文稿文件的内置属性和访问它们一样简单。您只需为任何所需属性分配一个字符串值，属性值将被修改。在下面的示例中，我们演示了如何修改演示文稿文件的内置文档属性。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-ModifyBuiltinProperties-ModifyBuiltinProperties.cs" >}}

## **添加自定义演示文稿属性**
Aspose.Slides for .NET 还允许开发人员为演示文稿文档属性添加自定义值。以下示例展示了如何为演示文稿设置自定义属性。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AddCustomDocumentProperties-AddCustomDocumentProperties.cs" >}}

## **访问和修改自定义属性**
Aspose.Slides for .NET 还允许开发人员访问自定义属性的值。以下示例展示了如何访问和修改演示文稿的所有这些自定义属性。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessModifyingProperties-AccessModifyingProperties.cs" >}}

## **检查演示文稿是否已修改或创建**
Aspose.Slides for .NET 提供了一种检查演示文稿是否被修改或创建的功能。以下示例展示了如何检查演示文稿是否被创建或修改。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-CheckPresentationCreatedorModifed-CheckPresentationCreatedorModifed.cs" >}}

设置默认语言

## **设置校对语言**

Aspose.Slides 提供了 [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) 属性（由 [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) 类暴露），允许您为 PowerPoint 文档设置校对语言。校对语言是检查 PowerPoint 中拼写和语法的语言。

以下 C# 代码展示了如何为 PowerPoint 设置校对语言：

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // 设置校对语言的 Id
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **设置默认语言**

以下 C# 代码展示了如何为整个 PowerPoint 演示文稿设置默认语言： 

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // 添加新的带文本的矩形形状
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "新文本";
    
    // 检查第一个部分的语言
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```