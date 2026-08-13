---
title: 使用 C++ 在演示文稿中管理标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/cpp/managing-tags-and-custom-data/
keywords:
- 文档属性
- 标签
- 自定义数据
- 自定义 XML
- 自定义 XML 部件
- XML 元数据
- ItemId
- 添加标签
- 键值对
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中管理标签和自定义 XML 数据，包括添加、读取、更新、审计和删除自定义 XML 部件。"
---
## **概述**

本文解释了 Aspose.Slides 如何在 PowerPoint 演示文稿中使用标签和自定义数据。特定于演示文稿的数据可以存储为标签或自定义 XML 部件。标签是简单的键值字符串对，而自定义 XML 部件可以存储结构化的元数据和特定于应用程序的 XML 负载。

Aspose.Slides 提供了在演示文稿、幻灯片和形状层级上添加、读取、更新、审计和删除自定义 XML 部件的 API。自定义 XML 部件对于需要在演示文稿中存储文档管理标识符、工作流状态、合规元数据、模板绑定数据或其他结构化应用数据的集成非常有用。

## **演示文稿文件中的数据存储**

PPTX 文件（扩展名为 `.pptx` 的文件）采用 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 定义了用于存储演示文稿内容及相关数据的包结构和关系。

一个演示文稿包含通过关系连接的多个部件。例如，幻灯片部件包含单个幻灯片的内容，并且可以与 ISO/IEC 29500 定义的其他部件建立显式关系。

自定义数据可以存储为标签（[ITagCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itagcollection/)）或自定义 XML 部件（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icustomxmlpartcollection/)）。两者均可通过[`ICustomData`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icustomdata/)接口访问。

{{% alert color="info" %}}
标签存储简单的字符串键值对。自定义 XML 部件存储结构化的 XML 数据，并且可以关联到演示文稿、幻灯片或形状。
{{% /alert %}}

## **使用自定义 XML 部件**

`ICustomData::get_CustomXmlParts` 方法返回与特定演示文稿对象关联的自定义 XML 部件集合。例如：

- `presentation->get_CustomData()->get_CustomXmlParts()` 包含与演示文稿本身关联的自定义 XML 部件。
- `slide->get_CustomData()->get_CustomXmlParts()` 包含与特定幻灯片关联的自定义 XML 部件。
- `shape->get_CustomData()->get_CustomXmlParts()` 包含与特定形状关联的自定义 XML 部件。

当需要检查演示文稿中所有自定义 XML 部件（不论其关联位置）时，请使用 `Presentation::get_AllCustomXmlParts`。

### **向演示文稿添加自定义 XML 部件**

使用 `ICustomXmlPartCollection::Add` 将 XML 数据添加到自定义 XML 部件集合中。XML 必须有效且非空。

以下示例向演示文稿级自定义数据集合添加结构化元数据：

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add 自动分配标识符。仅在需要时才设置特定的 GUID。
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

`Add` 方法还可以接受 XML 的字节数组或流形式，这在 XML 内容已经以二进制形式存在时非常有用。

### **向幻灯片或形状添加自定义 XML 部件**

自定义 XML 数据可以关联到特定的幻灯片或形状，而不是整个演示文稿。当元数据仅描述单个对象（例如模板键、外部记录标识符或绑定信息）时，这非常有用。

以下示例向幻灯片添加一个自定义 XML 部件，并向形状添加另一个：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

添加部件的层级决定了哪个对象的 `get_CustomData()->get_CustomXmlParts()` 集合包含对该部件的关联。演示文稿级数据适用于整个文档的元数据，幻灯片级数据适用于属于特定幻灯片的信息，形状级数据适用于绑定到单个形状的元数据。

### **列出并审计所有自定义 XML 部件**

使用 `Presentation::get_AllCustomXmlParts` 可检索演示文稿中的所有自定义 XML 部件。每个 `ICustomXmlPart` 都会公开其标识符、XML 内容及关联的命名空间模式。

以下示例列出所有自定义 XML 部件及其命名空间模式：

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

`ICustomXmlPart::get_NamespaceSchemas` 返回与自定义 XML 部件关联的 XML 模式。当审计包含外部系统生成的 XML 的演示文稿时，此信息可能有用。

### **读取和更新 XML 内容及 ItemId**

使用 `ICustomXmlPart::get_XmlAsString` 和 `set_XmlAsString` 以 UTF-8 字符串形式处理 XML，或使用 `ICustomXmlPart::get_XmlData` 和 `set_XmlData` 处理原始 XML 字节。两种表示方式均可读取和更新。

`ICustomXmlPart::get_ItemId` 方法返回在 Office Open XML 文档中标识自定义 XML 部件的 GUID。当集成需要新标识符时，也可以使用 `set_ItemId` 更改该标识符。

以下示例更新 XML 内容和标识符：

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// 将当前 XML 读取为文本。
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// 将 XML 更新为 UTF-8 字符串。
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData 提供相同的 XML 内容作为原始字节。
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// 在集成需要时替换标识符。
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

在使用 `set_XmlAsString` 或 `set_XmlData` 赋值 XML 时，请提供有效且非空的 XML。根据应用程序是主要处理字符串还是字节数据，选择相应的表示方式。

### **删除自定义 XML 部件**

Aspose.Slides 提供了多种删除自定义 XML 数据的方式：

- `ICustomXmlPart::Remove` 从演示文稿中删除自定义 XML 部件。
- `ICustomXmlPartCollection::Remove` 从自定义 XML 部件集合中删除特定部件。
- `ICustomXmlPartCollection::RemoveAt` 删除集合中指定索引处的部件。
- `ICustomXmlPartCollection::Clear` 删除特定集合中的所有部件。

以下示例通过引用删除一个演示文稿级自定义 XML 部件：

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

如果已有 `ICustomXmlPart`，并希望直接从演示文稿中删除该部件而不是针对特定集合，请调用 `customXmlPart->Remove()`。

也可以通过索引删除项目：

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **清除集合中的所有自定义 XML 部件**

当需要删除与特定演示文稿对象关联的所有自定义 XML 部件时，请使用 `Clear`。

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` 只影响选定的集合。例如，清除幻灯片的集合不会清除演示文稿级或形状级集合。

若要删除演示文稿中的所有自定义 XML 部件，可遍历 `get_AllCustomXmlParts()` 并逐个删除：

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **处理链接或共享的自定义 XML 部件**

在 Office Open XML 演示文稿中，同一个自定义 XML 部件可以被多个演示文稿对象引用。例如，一个已有文件可能包含多个幻灯片或形状到同一底层自定义 XML 部件的关系。

共享的部件应视为拥有多个引用的单一数据对象：

- 使用 `set_XmlAsString`、`set_XmlData` 或 `set_ItemId` 更新它会更改底层自定义 XML 部件，因而在所有引用该部件的地方都会生效。
- 在审计对象级集合时，可使用 `get_ItemId()` 来识别相同的自定义 XML 部件。
- 从特定的 `get_CustomXmlParts()` 集合中删除部件，只会将其从该集合中移除。若需将部件本身从演示文稿中删除，请使用 `ICustomXmlPart::Remove()`。
- 在删除或替换共享部件之前，请检查对象级集合，以确定是否还有其他幻灯片或形状引用它。

`Add` 的重载会从 XML 内容创建新的自定义 XML 部件；它们不接受已有的 `ICustomXmlPart`。因此，共享关系通常在加载已包含这些部件的演示文稿时出现。

以下示例按 `ItemId` 审计演示文稿、幻灯片和形状级别的集合，并报告被多个位置引用的部件：

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

此类审计在修改或删除外部系统创建的演示文稿中的自定义 XML 数据之前非常有用，因为相同的元数据部件可能参与多个关系。

## **获取标签的值**

在 Slides 中，标签对应于 `IDocumentProperties::get_Keywords` 属性。以下示例代码展示了如何使用 Aspose.Slides for C++ 获取 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 的标签值：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **向演示文稿添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常由两项组成：

- 自定义属性的名称，例如 `MyTag`；
- 自定义属性的值，例如 `My Tag Value`。

如果需要基于特定规则或属性对演示文稿进行分类，可以添加相应的标签。例如，要对来自北美国家的演示文稿进行分类，可以创建一个北美标签并将相应的国家设为其值。

以下示例代码展示了如何使用 Aspose.Slides for C++ 向 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 添加标签：

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

标签也可以为 [Slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slide/) 设置：

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

或者为单个 [Shape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/) 设置：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **限制**

通过 `get_CustomData()->get_Tags()` 集合添加的标签仅存储在 PowerPoint 文件中。导出为 PDF 时，它们 **不会** 转移到 PDF 的标签结构中。因此，作为标签分配的自定义标识符无法从带标签的 PDF 中检索。

**解决方案**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如 `shape->set_AlternativeText(u\"MyId\")`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **常见问题**

**我能一次性删除演示文稿、幻灯片或形状中的所有标签吗？**

可以。[tag collection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/) 支持 [Clear](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/clear/) 操作，可一次删除所有键值对。

**如何仅通过名称删除单个标签，而无需遍历整个集合？**

使用 [Remove(name)](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/remove/) 在 [TagCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/) 上通过键删除标签。

**如何获取全部标签名称列表以进行分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/) 上使用 [GetNamesOfTags](https://reference.aspose.com/slides/zh/cpp/aspose.slides/tagcollection/getnamesoftags/)，它会返回所有标签名称的数组。

**如何查找所有自定义 XML 部件，无论它们存储在何处？**

使用 `Presentation::get_AllCustomXmlParts` 可检索演示文稿中的所有自定义 XML 部件。

**在更新自定义 XML 部件时，我应该使用 `get_XmlAsString`/`set_XmlAsString` 还是 `get_XmlData`/`set_XmlData`？**

当应用程序处理 UTF-8 XML 文本时，使用 `get_XmlAsString` 和 `set_XmlAsString`。当 XML 已以字节数组形式存在或二进制处理更方便时，使用 `get_XmlData` 和 `set_XmlData`。这两种表示方式都指向同一自定义 XML 部件的 XML 内容。