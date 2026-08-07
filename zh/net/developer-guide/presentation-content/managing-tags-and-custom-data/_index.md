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

本文阐述了 Aspose.Slides 在 PowerPoint 演示文稿中如何使用标签和自定义数据。演示文稿特定的数据可以存储为标签或自定义 XML 部分。标签是简单的键值字符串对，而自定义 XML 部分可以存储结构化元数据和应用程序特定的 XML 负载。

Aspose.Slides 提供了在演示文稿、幻灯片和形状级别添加、读取、更新、审计和删除自定义 XML 部分的 API。自定义 XML 部分对于存储文档管理标识符、工作流状态、合规元数据、模板绑定数据或其他结构化应用程序数据等信息的集成非常有用。

## **演示文稿文件中的数据存储**

PPTX 文件——扩展名为 `.pptx` 的文件——采用 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 定义了用于存储演示文稿内容及相关数据的包结构和关系。

一个演示文稿包含通过关系连接的多个部件。例如，幻灯片部件包含单个幻灯片的内容，并且可以具有 ISO/IEC 29500 定义的到其他部件的显式关系。

自定义数据可以存储为标签（[ITagCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/itagcollection)）或自定义 XML 部件（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpartcollection)）。两者均可通过 [`ICustomData`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomdata/) 接口访问。

{{% alert color="primary" %}}
标签存储简单的字符串键值对。自定义 XML 部件存储结构化的 XML 数据，并且可以与演示文稿、幻灯片或形状关联。
{{% /alert %}}

## **使用自定义 XML 部分**

[`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomdata/customxmlparts/) 属性返回与特定演示文稿对象关联的自定义 XML 部分集合。例如：

- `presentation.CustomData.CustomXmlParts` 包含与演示文稿本身关联的自定义 XML 部分。
- `slide.CustomData.CustomXmlParts` 包含与特定幻灯片关联的自定义 XML 部分。
- `shape.CustomData.CustomXmlParts` 包含与特定形状关联的自定义 XML 部分。

在需要检查演示文稿中所有自定义 XML 部分（无论它们关联到何处）时，请使用 [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/allcustomxmlparts/)。

### **向演示文稿添加自定义 XML 部分**

使用 [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpartcollection/add/) 将 XML 数据添加到自定义 XML 部分集合。XML 必须有效且非空。

以下示例向演示文稿级别的自定义数据集合添加结构化元数据：

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

// Add 自动分配标识符。仅在需要时设置特定的 GUID。
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

`Add` 方法还可以接受字节数组或流形式的 XML，这在 XML 内容已经以二进制形式可用时非常有用。

### **向幻灯片或形状添加自定义 XML 部分**

自定义 XML 数据可以关联到特定幻灯片或形状，而不是整个演示文稿。这在元数据仅描述单个对象（如模板键、外部记录标识符或绑定信息）时非常有用。

以下示例向一个幻灯片添加一个自定义 XML 部分，向一个形状添加另一个自定义 XML 部分：

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

添加部件的层级决定了哪个对象的 `CustomData.CustomXmlParts` 集合包含对该部件的关系。演示文稿级别的数据适用于全局元数据，幻灯片级别的数据适用于属于特定幻灯片的信息，形状级别的数据适用于绑定到单个形状的元数据。

### **列出并审计所有自定义 XML 部分**

使用 [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/allcustomxmlparts/) 可检索演示文稿中的所有自定义 XML 部分。每个 [`ICustomXmlPart`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpart/) 都会公开其标识符、XML 内容以及关联的命名空间模式。

以下示例列出所有自定义 XML 部分及其命名空间模式：

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

`ICustomXmlPart.NamespaceSchemas` 返回与自定义 XML 部分关联的 XML 模式。在审计包含外部系统生成的 XML 的演示文稿时，这些信息非常有用。

### **读取并更新 XML 内容和 ItemId**

使用 [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpart/xmlasstring/) 以 UTF-8 字符串形式处理 XML，或使用 [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpart/xmldata/) 处理原始 XML 字节。两个属性均可读取和更新。

[`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpart/itemid/) 属性包含标识自定义 XML 部分在 Office Open XML 文档中的 GUID。需要新标识符时也可以更改它。

以下示例更新 XML 内容并更改标识符：

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// 以文本形式读取当前 XML。
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// 以 UTF-8 字符串更新 XML。
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData 以原始字节形式提供相同的 XML 内容。
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// 在集成需要时替换标识符。
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

在为 `XmlAsString` 或 `XmlData` 赋值时，请提供有效且非空的 XML。根据应用程序主要处理字符串还是字节数据，选择相应的表示方式。

### **删除自定义 XML 部分**

Aspose.Slides 提供多种方式删除自定义 XML 数据：

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpart/remove/) 从演示文稿中删除该自定义 XML 部分。
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpartcollection/remove/) 从自定义 XML 部分集合中删除特定部件。
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpartcollection/removeat/) 删除指定索引处的部件。
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/zh/net/aspose.slides/icustomxmlpartcollection/clear/) 删除特定集合中的所有部件。

以下示例通过引用删除一个演示文稿级别的自定义 XML 部分：

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

如果已经拥有 `ICustomXmlPart` 实例并希望直接从演示文稿中删除该部件，而不是针对特定集合进行操作，请调用 `customXmlPart.Remove()`。

也可以按索引删除项目：

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **清除集合中的所有自定义 XML 部分**

当需要删除与特定演示文稿对象关联的全部自定义 XML 部分时，请使用 `Clear`。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` 仅影响所选集合。例如，清除幻灯片的集合并不会清除演示文稿级别或形状级别的集合。

若要删除演示文稿中的每一个自定义 XML 部分，可遍历 `AllCustomXmlParts` 并逐一删除：

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

在 Office Open XML 演示文稿中，同一个自定义 XML 部分可以被多个演示文稿对象引用。例如，现有文件可能包含多个幻灯片或形状指向同一底层自定义 XML 部分的关系。

共享部件应视为具有多个引用的单一数据对象：

- 更新其 `XmlAsString`、`XmlData` 或 `ItemId` 会更改底层自定义 XML 部分，因此更改会在所有引用该部件的地方生效。
- `ItemId` 可用于在审计对象级别的集合时识别相同的自定义 XML 部分。
- 从特定 `CustomXmlParts` 集合中删除部件，仅会将其从该集合中移除。若需将部件本身从演示文稿中删除，请使用 `ICustomXmlPart.Remove()`。
- 在删除或替换共享部件之前，检查对象级别的集合以确定是否还有其他幻灯片或形状引用它。

`Add` 重载仅从 XML 内容创建新的自定义 XML 部分，不接受已有的 `ICustomXmlPart`。因此，共享关系通常在加载已包含此类关系的演示文稿时出现。

以下示例按 `ItemId` 审计演示文稿、幻灯片和形状级别的集合，并报告被多个位置引用的部件：

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

此类审计在修改或删除外部系统创建的演示文稿中的自定义 XML 数据之前非常有价值，因为相同的元数据部件可能参与多个关系。

## **获取标签值**

在 Slides 中，标签对应 `IDocumentProperties.Keywords` 属性。下面的示例代码演示了如何使用 Aspose.Slides for .NET 获取 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 的标签值：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **向演示文稿添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常由两项组成：

- 自定义属性的名称，例如 `MyTag`；
- 自定义属性的值，例如 `My Tag Value`。

如果需要根据特定规则或属性对演示文稿进行分类，可以添加相应的标签。例如，要对来自北美国家的演示文稿进行分类，可创建一个北美标签并将相应的国家名称设为其值。

下面的示例代码展示了如何使用 Aspose.Slides for .NET 为 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 添加标签：

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

或为单个 [Shape](https://reference.aspose.com/slides/zh/net/aspose.slides/shape) 设置：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **限制**

通过 `CustomData.Tags` 集合添加的标签仅存储在 PowerPoint 文件中。导出为 PDF 时，它们 **不会** 转移到 PDF 的标签结构。因此，作为标签分配的自定义标识符无法从已标记的 PDF 中检索。

**解决方法**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如 `shape.AlternativeText = "MyId"`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **常见问题**

**我能否一次性删除演示文稿、幻灯片或形状中的所有标签？**

可以。[tag collection](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/) 支持 [Clear](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/clear/) 操作，可一次性删除所有键值对。

**如何在不遍历整个集合的情况下，仅通过名称删除单个标签？**

在 [TagCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/) 上使用 [Remove(name)](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/remove/) 即可根据键删除标签。

**如何获取全部标签名称列表以进行分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/) 上使用 [GetNamesOfTags](https://reference.aspose.com/slides/zh/net/aspose.slides/tagcollection/getnamesoftags/)，它会返回所有标签名称的数组。

**如何查找所有自定义 XML 部分，而不管它们存储在何处？**

使用 [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/allcustomxmlparts/) 可检索演示文稿中的全部自定义 XML 部分。

**在更新自定义 XML 部分时，应使用 `XmlAsString` 还是 `XmlData`？**

当应用程序主要处理 UTF-8 XML 文本时使用 `XmlAsString`。当 XML 已以字节数组形式存在或二进制处理更方便时使用 `XmlData`。两者都表示同一自定义 XML 部分的内容。