---
title: 在 C# 中管理 PowerPoint 演示文稿属性
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
- 访问属性
- 修改属性
- 管理属性
- 文档元数据
- 编辑元数据
- 校对语言
- PowerPoint
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "了解如何在 C# 中使用 Aspose.Slides for .NET 轻松管理、读取和编辑 PowerPoint 文档属性。提升生产力并自动化工作流程！"
---

## **概述**

Aspose.Slides for .NET 支持两种文档属性类型：**内置**和**自定义**。这两种属性类型都可以通过 Aspose.Slides for .NET API 轻松访问和管理。

要处理文档属性，Aspose.Slides 提供了 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 接口，可通过 [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/documentproperties/) 属性访问。开发者可以利用 `Presentation` 对象的 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 接口，轻松读取、修改和管理演示文稿属性，如下例所示。

{{% alert color="primary" %}} 
请注意，**Application** 和 **Producer** 字段无法修改，因为这些字段始终显示为“Aspose Ltd.”和“Aspose.Slides for .NET x.x.x”。  
{{% /alert %}} 

## **管理演示文稿属性**

Microsoft PowerPoint 提供了向演示文稿文件添加属性的功能。这些文档属性可将有用的信息与文件一起存储。文档属性有两种类型：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置**属性包含有关文档的一般信息，如文档标题、作者姓名、文档统计信息等。

**自定义**属性由用户以 **名称/值** 对的形式定义，名称和值均由用户指定。

使用 Aspose.Slides for .NET，开发者可以访问并修改内置和自定义属性。

Microsoft PowerPoint 允许用户通过点击 Office 图标，然后选择 **文件 → 信息 → 属性** 来管理文档属性。选择 **高级属性** 后，会弹出一个对话框，在其中可以管理演示文稿文件的所有文档属性。

在 **属性** 对话框中，有多个选项卡，如 **常规**、**摘要**、**统计信息**、**内容** 和 **自定义**。每个选项卡提供配置 PowerPoint 文件特定信息类型的选项。**自定义**选项卡用于管理用户定义的属性。

## **访问内置属性**

这些属性由 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 接口公开，包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**SharedDoc**（指示文档是否在不同生产者之间共享）、**PresentationFormat**、**Subject**、**Title** 等等。  
```cs
// 实例化表示演示文稿文件的 Presentation 类。
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
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

修改演示文稿文件的内置属性与访问它们同样简单。只需为任意所需属性赋予字符串值，即可更新属性的值。下面的示例演示了如何修改演示文稿文件的内置文档属性。  
```cs
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

// 将演示文稿保存到文件。
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```


## **添加自定义演示文稿属性**

自定义演示文稿属性使开发者能够在演示文稿文件中存储额外的元数据或特定信息。Aspose.Slides 让以编程方式创建和管理这些自定义属性变得轻松。以下示例演示了如何向演示文稿添加自定义属性。  
```cs
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

Aspose.Slides 还允许开发者访问现有的自定义属性并轻松修改其值。此功能有助于维护准确的元数据，并支持基于用户输入或业务逻辑的动态更新。下面的示例说明了如何检索和更新演示文稿中的自定义属性值。  
```cs
// 实例化表示 PPTX 文件的 Presentation 类。
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
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

尝试在线应用程序 [**查看和编辑 PowerPoint 元数据**](https://products.aspose.app/slides/metadata) ，了解如何使用 Aspose.Slides API 处理文档属性：

[![查看和编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***常见问题**

**如何从演示文稿中删除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。不过，您可以更改其值，或在特定属性允许的情况下将其设为空。

**如果添加已存在的自定义属性会怎样？**

如果添加的自定义属性已经存在，其原有值将被新值覆盖。无需事先删除或检查属性，Aspose.Slides 会自动更新属性值。

**我可以在不完全加载演示文稿的情况下访问属性吗？**

可以。您可以使用 [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) 类的 `GetPresentationInfo` 方法获取演示文稿信息，然后利用 [IPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/) 接口提供的 `ReadDocumentProperties` 方法高效读取属性，从而节省内存并提升性能。