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
description: "在 Aspose.Slides for .NET 中掌握演示文稿属性，并简化 PowerPoint 和 OpenDocument 文件的搜索、品牌化和工作流。"
---
## **简介**

Aspose.Slides for .NET 支持两种文档属性类型：**内置**和**自定义**。这两种属性类型都可以通过 Aspose.Slides for .NET API 轻松访问和管理。

Aspose.Slides 通过 [IDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/) 接口来处理演示文稿的文档属性。该接口的实例由 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/documentproperties/) 返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
请注意，**Application** 和 **Producer** 字段无法修改，这两个字段始终显示为 “Aspose Ltd.” 和 “Aspose.Slides for .NET x.x.x”。
{{% /alert %}} 

## **管理演示文稿属性**

Microsoft PowerPoint 提供了向演示文稿文件添加属性的功能。这些文档属性可以将有用的信息与文件一起存储。文档属性分为两类：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置**属性包含有关文档的一般信息，例如文档标题、作者姓名、文档统计信息等。

**自定义**属性由用户以 **名称/值** 对的形式定义，名称和值均由用户指定。

使用 Aspose.Slides for .NET，开发人员可以访问并修改内置属性和自定义属性。

Microsoft PowerPoint 允许用户通过单击 Office 图标，然后选择 **文件 → 信息 → 属性** 来管理文档属性。选择 **高级属性** 后，会弹出一个对话框，您可以在其中管理演示文稿文件的所有文档属性。

在 **属性** 对话框中，有多个选项卡，例如 **常规**、**摘要**、**统计**、**内容** 和 **自定义**。每个选项卡提供配置 PowerPoint 文件相关特定信息的选项。**自定义**选项卡用于管理用户定义的属性。

## **读取加密演示文稿的公共属性**

打开密码通常会保护演示文稿内容和文档属性。当演示文稿使用 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 并将其设置为 `false` 时，其文档属性保持公开。此时应用程序可以将 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 设置为 `true`，在不提供打开密码的情况下读取公共元数据。

`OnlyLoadDocumentProperties` 控制 Aspose.Slides 加载的内容；它不进行解密。如果属性已被加密，在没有密码的情况下加载将失败。如果演示文稿未加密，则该选项会被忽略，完整的演示文稿将被加载。

以下示例通过 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) 验证加载模式，然后通过 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/documentproperties/) 读取内置属性：

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

在此模式下，幻灯片内容不会被加载。幻灯片、母版、版式、形状、媒体及其他演示对象均不可用。应用程序应始终在执行需要完整演示对象模型的操作之前检查 `IsOnlyDocumentPropertiesLoaded`。

{{% alert color="warning" title="Security" %}}
公共元数据可能会泄露作者姓名、标题、主题、关键字、公司信息、注释以及自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统有特定需求必须在不提供密码的情况下访问时，才将其保持公开。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，使用 `OnlyLoadDocumentProperties` 加载的演示文稿旨在读取公共元数据。Aspose.Slides 无法保存该仅元数据对象中更改的属性，因为公共属性必须与加密演示文稿内部的对应数据保持一致。因此，更新这些属性需要正确的打开密码以及完整加载。

以下示例使用 [LoadOptions.Password](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/password/) 打开演示文稿，更新公共内置属性并保存结果。随后使用 [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/isencrypted/) 验证加密仍然保留，并在不提供密码的情况下重新打开公共元数据以验证新值：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

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

如果应用程序被禁止解密或加载演示文稿内容，则必须将加密 PPTX 文件的公共属性视为只读。

## **访问内置属性**

这些属性由 [IDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/) 接口公开，包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**SharedDoc**（指示文档是否在不同制作者之间共享）、**PresentationFormat**、**Subject**、**Title** 等。

```cs
using Aspose.Slides;

// 实例化表示演示文稿文件的 Presentation 类。
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// 获取与演示文稿关联的 IDocumentProperties 类型对象的引用。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 显示内置属性。
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **修改内置属性**

修改演示文稿文件的内置属性和访问它们一样简单。只需将字符串值赋给任意所需属性，即可更新该属性的值。下面的示例演示了如何修改演示文稿文件的内置文档属性。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示演示文稿文件的 Presentation 类。
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// 获取与演示文稿关联的 IDocumentProperties 类型对象的引用。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 设置内置属性。
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// 保存演示文稿到文件。
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **添加自定义演示文稿属性**

自定义演示文稿属性使开发人员能够在演示文稿文件中存储额外的元数据或特定信息。Aspose.Slides 让以编程方式创建和管理这些自定义属性变得轻而易举。以下示例展示了如何向演示文稿添加自定义属性。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化 Presentation 类。
using Presentation presentation = new Presentation();

// 获取与演示文稿关联的 IDocumentProperties 类型对象的引用。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 添加自定义属性。
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// 将演示文稿保存到文件。
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **访问和修改自定义属性**

Aspose.Slides 还允许开发人员访问现有的自定义属性并轻松修改其值。这一功能有助于维护准确的元数据，并支持基于用户输入或业务逻辑的动态更新。下面的示例说明了如何检索和更新演示文稿中的自定义属性值。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示 PPTX 文件的 Presentation 类。
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// 获取与演示文稿关联的 IDocumentProperties 类型对象的引用。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 访问并修改自定义属性。
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // 显示自定义属性的名称和值。
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // 修改自定义属性的值。
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// 将演示文稿保存到文件。
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **实时示例**

试试在线应用 [**查看并编辑 PowerPoint 元数据**](https://products.aspose.app/slides/zh/metadata)，了解如何使用 Aspose.Slides API 处理文档属性：

[![查看并编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/zh/metadata)

## **常见问题**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，不能完全移除。不过，您可以更改其值，或在特定属性允许的情况下将其设为空。

**如果添加的自定义属性已经存在会怎样？**

如果添加的自定义属性已经存在，其现有值将被新值覆盖。无需事先删除或检查属性，Aspose.Slides 会自动更新属性的值。

**是否可以在不完整加载演示文稿的情况下访问演示文稿属性？**

可以。使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/getpresentationinfo/) 然后调用 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 即可在不创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。有关完整报告示例和特定格式限制，请参阅 [构建轻量级演示文稿清单](/slides/zh/net/examine-presentation/)。

**是否可以在没有打开密码的情况下读取加密演示文稿的公共属性？**

可以。前提是演示文稿在加密时将 `EncryptDocumentProperties` 设置为 `false`，并且以 `OnlyLoadDocumentProperties` 为 `true` 加载。

**是否可以在仅文档属性模式下更新加密的 PPTX 文件？**

不可以。公共属性和加密属性的数据必须保持一致，因此更新加密的 PPTX 文件需要使用正确的打开密码完整加载演示文稿。