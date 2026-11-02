---
title: 在 .NET 中管理演示文稿属性
linktitle: 演示文稿属性
type: docs
weight: 70
url: /zh/net/presentation-properties/
keywords:
- PowerPoint 属性
- 演示文稿属性
- 文档属性
- 内置属性
- 自定义属性
- 高级属性
- 管理属性
- 修改属性
- 文档元数据
- 编辑元数据
- 校对语言
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中精通演示文稿属性，并在您的 PowerPoint 和 OpenDocument 文件中简化搜索、品牌化和工作流。"
---
## **简介**

Aspose.Slides for .NET 支持 **内置** 和 **自定义** 文档属性。使用这些属性读取和更新演示文稿的元数据，例如作者、标题和用户定义的值。

Aspose.Slides 允许您通过 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 接口处理演示文稿文档属性。该接口的实例由 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在保存演示文稿时管理应用程序和生成者的元数据；这些字段标识创建输出的软件。
{{% /alert %}}

## **管理演示文稿属性**

文档属性在演示文稿内容旁存储描述性信息。它们分为两类：

- **内置属性** 包含标准元数据，例如标题、作者和文档统计信息。
- **自定义属性** 存储用户定义的名称/值对。

Aspose.Slides for .NET 提供对两类属性的访问。在 PowerPoint 中，选择 **文件 → 信息 → 属性 → 高级属性** 查看文档元数据。该对话框将信息分组为 **摘要**、**统计信息**、**内容** 和 **自定义** 等标签页。使用 **自定义** 标签页管理用户定义的属性。

## **读取受加密演示文稿的公共属性**

打开密码通常同时保护演示文稿内容和文档属性。当演示文稿使用 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 并将其设为 `false` 加密时，其文档属性保持公共。此时应用程序可以将 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 设为 `true`，在不提供打开密码的情况下读取公共元数据。

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 控制 Aspose.Slides 加载的内容；它不进行任何解密。如果属性已被加密，则在没有密码的情况下加载会失败。若演示文稿未加密，则此选项被忽略，完整演示文稿将被加载。

示例需要一个文档属性保持公共的已加密演示文稿。它通过 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) 验证加载模式，然后通过 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 读取内置属性：

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

在此模式下，不会加载幻灯片内容。幻灯片、母版、布局、形状、媒体及其他演示文稿对象均不可用。应用程序应始终在执行需要完整演示文稿对象模型的操作前检查 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/)。

{{% alert color="warning" title="Security" %}}
公共元数据可能泄露作者姓名、标题、主题、关键字、公司信息、注释以及自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统明确要求在无需密码的情况下访问时才将其保持公共。
{{% /alert %}}

## **更新受加密演示文稿的属性**

对于加密的 PPTX 文件，使用 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 加载的演示文稿旨在读取公共元数据。Aspose.Slides 无法从仅包含元数据的对象保存已更改的属性，因为公共属性必须与加密演示文稿内部对应的数据保持一致。因此，更新这些属性需要正确的打开密码并完整加载演示文稿。

示例需要一个具有公共文档属性且已知打开密码的加密 PPTX 演示文稿。它使用 [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) 打开完整演示文稿，更新公共内置属性并保存结果。随后使用 [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) 验证加密仍然存在，并在不提供密码的情况下重新打开公共元数据以验证新值：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

如果应用程序不被允许解密或加载演示文稿内容，则必须将加密 PPTX 文件的公共属性视为只读。

## **访问内置属性**

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 接口通过类型化属性公开内置元数据，包括 [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/) 和 [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/)。此示例打开现有演示文稿并将其存储的元数据打印到控制台。值取决于输入演示文稿；某些字段可能为空。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

## **修改内置属性**

要更新内置元数据，请为 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 暴露的可写属性赋值。此示例打开现有演示文稿，设置 [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)、[Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/)、[Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/) 和 [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/)，随后使用 [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 保存更新后的演示文稿。生成的 PPTX 将包含新的元数据。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **管理超链接基址**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) 存储文档级别的相对超链接基址。当将演示文稿及其链接文件移动到其他位置时，这非常有用。它独立于单个超链接的 [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/)：更改基址不会重写已存储的链接地址或更改绝对目标。

示例需要一个包含相对链接（如 `target.html`）和绝对链接（如 `https://example.org/absolute.html`）的演示文稿。它读取现有基址，分配新的基址地址，保存并重新打开演示文稿以检查该值。随后使用 `string.Empty` 清除基址，并在单独的保存文件中验证空值。请将示例基址替换为您的链接文件所在位置。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

两个验证消息应输出 `True`。清除基址后，单个超链接地址保持不变。

相对链接 `target.pptx` 在基址指向 `old` 文件夹时打开 `old/target.pptx`。将基址改为 `new` 文件夹后保存并重新打开演示文稿，同一链接将打开 `new/target.pptx`。绝对链接仍然打开相同文件。请在移动演示文稿或更改基址前后，在 PowerPoint 中测试您的相对链接。

## **添加自定义演示文稿属性**

自定义属性存储没有对应内置字段的元数据。[IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) 允许您通过属性名称赋值。此示例创建演示文稿，添加两个文本值和一个整数版本值，并使用 [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 保存演示文稿。为已存在的名称赋值会替换该属性的值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **访问并修改自定义属性**

此示例打开包含自定义属性的演示文稿，并使用 [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) 对其进行遍历。[GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) 接受零基索引并返回由 [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) 使用的名称。示例打印每个原始名称和值，将每个值替换为带编号的字符串（不论其原始类型），并保存更改。如果没有自定义属性，循环不会产生任何更改。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **实时示例**

尝试在线应用 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 了解如何使用 Aspose.Slides API 操作文档属性：

[![查看并编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常见问题**

**如何从演示文稿中删除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。但您可以更改其值，或在特定属性允许的情况下将其设为空。

**如果添加的自定义属性已存在会怎样？**

如果添加的自定义属性已存在，现有值将被新值覆盖。无需事先删除或检查属性，因为 Aspose.Slides 会自动更新属性的值。

**可以在不完整加载演示文稿的情况下访问演示文稿属性吗？**

可以。使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) 然后调用 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 即可在不创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。请参阅 [构建轻量级演示文稿清单](/slides/zh/net/examine-presentation/) 获取完整的报告示例以及特定格式的限制。

**是否可以在不提供打开密码的情况下读取加密演示文稿的公共属性？**

可以。演示文稿必须使用 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 并将其设为 `false` 加密，并且必须使用 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 并将其设为 `true` 加载。

**是否可以在仅文档属性模式下更新加密的 PPTX 文件？**

不行。公共属性和加密属性的数据必须保持一致，因此更新加密的 PPTX 文件需要使用正确的打开密码完整加载演示文稿。