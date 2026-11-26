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
description: "在 Aspose.Slides for .NET 中精通演示文稿属性，并简化 PowerPoint 和 OpenDocument 文件的搜索、品牌化和工作流。"
---
## **介绍**

Aspose.Slides for .NET 支持 **内置** 和 **自定义** 文档属性。使用这些属性可以读取和更新演示文稿元数据，例如作者、标题和用户定义的值。

Aspose.Slides 通过 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 接口来处理演示文稿的文档属性。该接口的实例由 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 返回。下面的示例演示如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在保存演示文稿时会管理应用程序和生产者元数据；这些字段用于标识创建输出的软件。
{{% /alert %}}

## **管理演示文稿属性**

文档属性在演示文稿内容旁存储描述性信息。它们分为两类：

- **内置属性** 包含标准元数据，例如标题、作者和文档统计信息。
- **自定义属性** 存储用户定义的名称/值对。

Aspose.Slides for .NET 提供对两类属性的访问。在 PowerPoint 中，选择 **文件 → 信息 → 属性 → 高级属性** 可检查文档元数据。对话框将信息分组到 **概述**、**统计信息**、**内容** 和 **自定义** 等选项卡中。使用 **自定义** 选项卡可以管理用户定义的属性。

## **从加密演示文稿读取公共属性**

打开密码通常同时保护演示文稿内容和文档属性。当使用 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 且设置为 `false` 加密演示文稿时，其文档属性保持公共。此时应用程序可以将 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 设置为 `true`，在不提供打开密码的情况下读取公共元数据。

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 控制 Aspose.Slides 加载的内容；它不执行任何解密操作。如果属性被加密，则在没有密码的情况下加载会失败。如果演示文稿未加密，则该选项被忽略，完整的演示文稿会被加载。

示例需要一个文档属性保持公共的加密演示文稿。它通过 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) 验证加载模式，然后通过 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 读取内置属性：

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

在此模式下，幻灯片内容不会被加载。幻灯片、母版、布局、形状、媒体及其他演示文稿对象不可用。应用程序应始终在执行需要完整演示文稿对象模型的操作之前检查 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/)。

{{% alert color="warning" title="Security" %}}
公共元数据可能会泄露作者姓名、标题、主题、关键字、公司信息、注释以及自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统明确要求在不提供密码的情况下访问时才将其保持公共。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，使用 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 加载的演示文稿仅用于读取公共元数据。Aspose.Slides 不能从仅包含元数据的对象保存更改后的属性，因为公共属性必须与加密演示文稿内部的数据保持一致。因此，更新这些属性必须使用正确的打开密码并完成完整加载。

示例需要一个具有公共文档属性且已知打开密码的加密 PPTX 演示文稿。它使用 [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) 完整打开演示文稿，更新公共内置属性并保存结果。随后使用 [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) 验证加密仍然保留，并在不提供密码的情况下重新打开公共元数据以验证新值：

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

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 接口通过强类型属性公开内置元数据，包括 [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/) 和 [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/)。本示例打开现有演示文稿并将其存储的元数据打印到控制台。值取决于输入的演示文稿；某些字段可能为空。

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

### **报告修订号和编辑时间**

要为 `presentations` 文件夹中的每个 PPTX 文件报告一行记录，可调用 [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 获取其 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 而不加载幻灯片进行编辑。`TimeSpan` 的标准 `c` 格式在持续时间超过 24 小时时会包含天数。

```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

示例输出（记录的编辑时间为 1 天 2 小时 5 分钟）：

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) 是可写的元数据。仅凭其值无法判断演示文稿保存了多少次，也不能重建其版本历史。

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) 是文件中记录的编辑时长。`00:00:00` 表示存储的时长为零，并不证明没有人编辑过演示文稿。

## **修改内置属性**

要更新内置元数据，只需为 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 暴露的可写属性赋值。本示例打开现有演示文稿，设置 [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)、[Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/)、[Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/) 和 [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/)，随后使用 [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 保存更新后的演示文稿。保存的 PPTX 将包含新的元数据。

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

## **管理超链接基准**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) 用于存储文档级的相对超链接基准。当将演示文稿及其关联文件移动到其他位置时，这非常有用。它与单个超链接的 [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) 分离：更改基准不会重写已存储的链接地址，也不会更改绝对目标。

示例需要一个同时包含相对链接（如 `target.html`）和绝对链接（如 `https://example.org/absolute.html`）的演示文稿。它读取现有基准，赋予新的基准地址，然后保存并重新打开演示文稿以检查该值。随后使用 `string.Empty` 清除基准，并在另外保存的文件中验证为空。请将示例基准地址替换为实际的链接文件所在位置。

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

两个验证消息应输出 `True`。清除基准后，单个超链接地址保持不变。

相对链接 `target.pptx` 在基准指向 `old` 文件夹时会打开 `old/target.pptx`。将基准改为 `new` 文件夹后，保存并重新打开演示文稿，同一链接会打开 `new/target.pptx`。绝对链接仍然打开原始文件。在移动演示文稿或更改基准前后，请在 PowerPoint 中测试相对链接。

## **添加自定义演示文稿属性**

自定义属性用于存储没有对应内置字段的元数据。[IDocumentProperties 索引器](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) 允许按属性名称赋值。本示例创建一个演示文稿，添加两个文本值和一个整数版本值，然后使用 [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 保存演示文稿。为已有名称赋值会替换该属性的值。

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

本示例打开包含自定义属性的演示文稿，并使用 [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) 进行遍历。 [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) 接受零基索引并返回 [IDocumentProperties 索引器](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) 使用的名称。示例打印每个原始名称和值，将所有值替换为带编号的字符串（不考虑原始类型），并保存更改。如果不存在自定义属性，循环将不做任何修改。

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

尝试在线应用程序 [**查看和编辑 PowerPoint 元数据**](https://products.aspose.app/slides/metadata) 来了解如何使用 Aspose.Slides API 操作文档属性：

[![查看和编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常见问题**

**如何从演示文稿中删除内置属性？**

内置属性是演示文稿的组成部分，不能完全删除。不过，您可以更改其值，或者在属性本身允许的情况下将其设为空。

**如果添加的自定义属性已经存在会怎样？**

如果添加的自定义属性已经存在，其现有值会被新值覆盖。无需事先删除或检查属性，Aspose.Slides 会自动更新属性的值。

**是否可以在不完整加载演示文稿的情况下访问演示文稿属性？**

可以。使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) 然后调用 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 即可在不创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。有关完整的报告示例及格式特定限制，请参阅 [构建轻量级演示文稿清单](/slides/zh/net/examine-presentation/)。

**是否可以在没有打开密码的情况下读取加密演示文稿的公共属性？**

可以。前提是演示文稿使用 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 且设置为 `false` 加密，并且在加载时将 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 设置为 `true`。

**在仅文档属性加载模式下能否更新加密的 PPTX 文件？**

不能。公共属性和加密属性的数据必须保持一致，因此在文档属性仅加载模式下更新加密 PPTX 文件需要使用正确的打开密码并完整加载演示文稿。