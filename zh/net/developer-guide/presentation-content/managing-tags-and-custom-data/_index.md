---
title: 在 .NET 中管理演示文稿的标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/net/managing-tags-and-custom-data/
keywords:
- 文档属性
- 标签
- 自定义数据
- 自定义 XML
- 自定义 XML 部分
- XML 元数据
- ItemId
- 添加标签
- 键值对
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中管理标签和自定义 XML 数据，包括添加、读取、更新、审计和删除自定义 XML 部分。"
---
## **概述**

本文说明 Aspose.Slides 如何在 PowerPoint 演示文稿中使用标签和自定义数据。特定于演示文稿的数据可以存储为标签或自定义 XML 部分。标签是简单的键值字符串对，而自定义 XML 部分可以存储结构化元数据和特定于应用程序的 XML 负载。

Aspose.Slides 提供在演示文稿、幻灯片和形状层级上添加、读取、更新、审计和删除自定义 XML 部分的 API。自定义 XML 部分对于需要在演示文稿内存储文档管理标识、工作流状态、合规元数据、模板绑定数据或其他结构化应用程序数据的集成非常有用。

## **演示文稿文件中的数据存储**

PPTX 文件——扩展名为 `.pptx` 的文件——采用 PresentationML 格式存储，属于 Office Open XML 规范的一部分。Office Open XML 定义了用于存储演示文稿内容及相关数据的包结构和关系。

演示文稿包含通过关系相连的多个部件。例如，幻灯片部件包含单个幻灯片的内容，并且可以与 ISO/IEC 29500 定义的其他部件建立显式关系。

自定义数据可以以标签（[ITagCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/itagcollection)）或自定义 XML 部分（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpartcollection)）的形式存储。两者均通过 [`ICustomData`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomdata/) 接口访问。

{{% alert color="info" %}}
标签存储简单的字符串键值对。自定义 XML 部分存储结构化 XML 数据，并且可以与演示文稿、幻灯片或形状关联。
{{% /alert %}}

## **使用自定义 XML 部分**

[`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomdata/customxmlparts/) 属性返回与特定演示文稿对象关联的自定义 XML 部分集合。例如：

- `presentation.CustomData.CustomXmlParts` 包含与演示文稿本身关联的自定义 XML 部分。
- `slide.CustomData.CustomXmlParts` 包含与特定幻灯片关联的自定义 XML 部分。
- `shape.CustomData.CustomXmlParts` 包含与特定形状关联的自定义 XML 部分。

在需要检查演示文稿中所有自定义 XML 部分（无论其关联位置）时，请使用 [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/allcustomxmlparts/)。

### **向演示文稿添加自定义 XML 部分**

使用 [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpartcollection/add/) 将 XML 数据添加到自定义 XML 部分集合。XML 必须有效且非空。

下面的示例向演示文稿级自定义数据集合添加结构化元数据：

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// 添加会自动分配标识符。仅在需要时设置特定的 GUID。
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

`Add` 方法还可以接受字节数组或流形式的 XML，这在 XML 内容已以二进制形式存在时特别有用。

### **向幻灯片或形状添加自定义 XML 部分**

自定义 XML 数据可以关联到特定幻灯片或形状，而不是整个演示文稿。当元数据仅描述单个对象（例如模板键、外部记录标识或绑定信息）时，这非常有用。

下面的示例向一个幻灯片添加一个自定义 XML 部分，并向一个形状添加另一个自定义 XML 部分：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

添加部件的层级决定了哪个对象的 `CustomData.CustomXmlParts` 集合包含对该部件的关系。演示文稿级数据适用于文档范围的元数据，幻灯片级数据适用于特定幻灯片的信息，形状级数据适用于绑定到单个形状的元数据。

### **列出并审计所有自定义 XML 部分**

使用 [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/allcustomxmlparts/) 可检索演示文稿中的所有自定义 XML 部分。每个 [`ICustomXmlPart`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpart/) 都会公开其标识符、XML 内容以及关联的命名空间模式。

下面的示例列出所有自定义 XML 部分及其命名空间模式：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpart/namespaceschemas/) 返回与自定义 XML 部件关联的 XML 模式。审计包含外部系统生成的 XML 的演示文稿时，这些信息非常有用。

### **读取和更新 XML 内容及 ItemId**

使用 [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpart/xmlasstring/) 可将 XML 作为 UTF-8 字符串处理，或使用 [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpart/xmldata/) 处理原始 XML 字节。两者均可读取和更新。

[`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpart/itemid/) 属性包含标识自定义 XML 部分在 Office Open XML 文档中的 GUID。当集成需要新标识符时，也可以更改该属性。

下面的示例更新 XML 内容并更改标识符：

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// 读取当前 XML 为文本。
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// 将 XML 更新为 UTF-8 字符串。
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData 提供相同的 XML 内容，以原始字节形式。
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// 在集成需要时替换标识符。
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

为 `XmlAsString` 或 `XmlData` 赋值时，请提供有效且非空的 XML。根据应用程序主要处理字符串还是字节数据，选择相应的表示方式。

### **删除自定义 XML 部分**

Aspose.Slides 提供多种删除自定义 XML 数据的方式：

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpart/remove/) 从演示文稿中删除该自定义 XML 部分。
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpartcollection/remove/) 从自定义 XML 部分集合中删除指定部件。
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpartcollection/removeat/) 删除集合中指定索引处的部件。
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpartcollection/clear/) 删除特定集合中的所有部件。

下面的示例通过引用删除一个演示文稿级自定义 XML 部分：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

如果已有 `ICustomXmlPart` 实例并希望直接从演示文稿中删除该部件，而不是针对特定集合，请调用 `customXmlPart.Remove()`。

也可以通过索引删除项目：

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **清除集合中的所有自定义 XML 部分**

当需要删除与特定演示文稿对象关联的所有自定义 XML 部分时，请使用 `Clear`。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` 仅影响所选集合。例如，清除幻灯片的集合不会影响演示文稿级或形状级集合。

要删除演示文稿中的所有自定义 XML 部分，可遍历 `AllCustomXmlParts` 并逐一删除：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **处理链接或共享的自定义 XML 部分**

在 Office Open XML 演示文稿中，同一个自定义 XML 部分可能被多个演示文稿对象引用。例如，现有文件可能包含从多个幻灯片或形状到同一底层自定义 XML 部分的关系。

共享部件应视为一个数据对象，但拥有多个引用：

- 更新其 `XmlAsString`、`XmlData` 或 `ItemId` 会修改底层自定义 XML 部分，从而在所有引用处生效。
- `ItemId` 可用于在审计对象级集合时识别相同的自定义 XML 部分。
- 从特定 `CustomXmlParts` 集合中删除部件仅从该集合移除。若部件本身应从演示文稿中删除，请使用 `ICustomXmlPart.Remove()`。
- 在删除或替换共享部件之前，请检查对象级集合以确定是否还有其他幻灯片或形状引用它。

`Add` 重载会从 XML 内容创建新的自定义 XML 部分；它们不接受已有的 `ICustomXmlPart`。因此，共享关系最常在加载已包含此类部件的演示文稿时出现。

下面的示例按 `ItemId` 审计演示文稿、幻灯片和形状级集合，并报告在多个位置被引用的部件：

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

在对外部系统生成的演示文稿修改或删除自定义 XML 数据之前进行此类审计非常有用，因为同一元数据部件可能参与多个关系。

## **获取标签的值**

在 Slides 中，标签对应 `IDocumentProperties.Keywords` 属性。以下示例代码演示如何使用 Aspose.Slides for .NET 获取 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 的标签值：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **向演示文稿添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常由两项组成：

- 自定义属性的名称，例如 `MyTag`；
- 自定义属性的值，例如 `My Tag Value`。

如果需要根据特定规则或属性对演示文稿进行分类，可添加相应的标签。例如，要对来自北美国家的演示文稿进行分类，可创建一个北美标签并将相应的国家名称设为其值。

以下示例代码演示如何使用 Aspose.Slides for .NET 向 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 添加标签：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

标签也可以为 [Slide](https://reference.aspose.com/slides/zh/net/aspose.slides/slide) 设置：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

或者为单个 [Shape](https://reference.aspose.com/slides/zh/net/aspose.slides/shape) 设置：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **限制**

通过 `CustomData.Tags` 集合添加的标签仅存储在 PowerPoint 文件中。导出为 PDF 时，它们 **不会** 转移到 PDF 的标签结构。因此，作为标签分配的自定义标识符无法从带标签的 PDF 中检索。

**解决方法**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如 `shape.AlternativeText = "MyId"`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **常见问题**

**我可以一次性删除演示文稿、幻灯片或形状中的所有标签吗？**

是的。[`TagCollection`](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/) 支持 [`Clear`](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/clear/) 操作，可一次性删除所有键值对。

**如何在不遍历整个集合的情况下，仅通过标签名称删除单个标签？**

在 [`TagCollection`](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/) 上使用 [`Remove(name)`](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/remove/) 可通过键删除标签。

**如何获取完整的标签名称列表以进行分析或过滤？**

在标签集合上调用 [`GetNamesOfTags`](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/getnamesoftags/)；它会返回所有标签名称的数组。

**如何查找所有自定义 XML 部分，而不考虑它们存储的位置？**

使用 [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/allcustomxmlparts/) 可检索演示文稿中的所有自定义 XML 部分。

**在更新自定义 XML 部分时，我应该使用 `XmlAsString` 还是 `XmlData`？**

当应用程序处理 UTF-8 XML 文本时使用 `XmlAsString`。当 XML 已以字节数组形式存在或更倾向于二进制处理时使用 `XmlData`。两者都表示同一自定义 XML 部分的内容。