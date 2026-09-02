---
title: 使用 Python 管理演示文稿中的标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/python-net/managing-tags-and-custom-data/
keywords:
- 文档属性
- 标签
- 自定义数据
- 自定义 XML
- 自定义 XML 部分
- XML 元数据
- ItemId
- 添加标签
- 成对值
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中管理标签和自定义 XML 数据，包括添加、读取、更新、审计和删除自定义 XML 部分。"
---
## **概述**

本文说明 Aspose.Slides 如何在 PowerPoint 演示文稿中处理标签和自定义数据。演示文稿特定的数据可以存储为标签或自定义 XML 部分。标签是简单的键值字符串对，而自定义 XML 部分可以存储结构化的元数据和应用程序特定的 XML 负载。

Aspose.Slides 提供了在演示文稿、幻灯片和形状级别添加、读取、更新、审计和删除自定义 XML 部分的 API。自定义 XML 部分对于存储文档管理标识符、工作流状态、合规元数据、模板绑定数据或其他结构化应用程序数据等信息的集成非常有用。

## **在演示文稿文件中存储数据**

PPTX 文件（扩展名为 `.pptx`）采用 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 定义了用于存储演示文稿内容及相关数据的包结构和关系。

一个演示文稿包含通过关系连接的多个部件。例如，幻灯片部件包含单个幻灯片的内容，并且可以通过 ISO/IEC 29500 定义的显式关系链接到其他部件。

自定义数据可以存储为标签（[TagCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/)）或自定义 XML 部分（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customxmlpartcollection/)）。两者均通过 [`CustomData`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customdata/) 类访问。

{{% alert color="primary" %}}
标签存储简单的字符串键值对。自定义 XML 部分存储结构化的 XML 数据，并且可以关联到演示文稿、幻灯片或形状。
{{% /alert %}}

## **使用自定义 XML 部分**

[`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customdata/custom_xml_parts/) 属性返回与特定演示文稿对象关联的自定义 XML 部分集合。例如：

- `presentation.custom_data.custom_xml_parts` 包含与整个演示文稿关联的自定义 XML 部分。
- `slide.custom_data.custom_xml_parts` 包含与特定幻灯片关联的自定义 XML 部分。
- `shape.custom_data.custom_xml_parts` 包含与特定形状关联的自定义 XML 部分。

当需要检查演示文稿中所有自定义 XML 部分（不论其关联位置）时，请使用 [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/all_custom_xml_parts/)。

### **向演示文稿添加自定义 XML 部分**

使用 [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customxmlpartcollection/add/) 向自定义 XML 部分集合添加 XML 数据。XML 必须有效且非空。

以下示例向演示文稿级别的自定义数据集合添加结构化元数据：

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add 会自动分配标识符。仅在需要时设置特定的 GUID。
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

`add` 方法还可以接受字节数组或流形式的 XML，这在 XML 已经以二进制形式可用时非常有用。

### **向幻灯片或形状添加自定义 XML 部分**

自定义 XML 数据可以关联到特定幻灯片或形状，而不是整个演示文稿。当元数据仅描述单个对象（例如模板键、外部记录标识符或绑定信息）时，这非常有用。

以下示例向一个幻灯片添加一个自定义 XML 部分，向一个形状添加另一个自定义 XML 部分：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

添加部件的层级决定了哪个对象的 `custom_data.custom_xml_parts` 集合包含对该部件的关系。演示文稿级数据适用于文档范围的元数据，幻灯片级数据适用于属于特定幻灯片的信息，形状级数据适用于绑定到单个形状的元数据。

### **列出并审计所有自定义 XML 部分**

使用 [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/all_custom_xml_parts/) 检索演示文稿中的所有自定义 XML 部分。每个 [`CustomXmlPart`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customxmlpart/) 都会公开其标识符、XML 内容以及关联的命名空间模式。

以下示例列出所有自定义 XML 部分及其命名空间模式：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customxmlpart/namespace_schemas/) 返回与该自定义 XML 部分关联的 XML 模式。在审计包含外部系统生成 XML 的演示文稿时，此信息非常有用。

### **读取和更新 XML 内容以及 ItemId**

使用 [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customxmlpart/xml_as_string/) 以 UTF-8 字符串形式操作 XML，或使用 [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customxmlpart/xml_data/) 处理原始 XML 字节。两个属性均可读取和更新。

[`CustomXmlPart.item_id`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customxmlpart/item_id/) 属性包含用于在 Office Open XML 文档中标识自定义 XML 部分的 GUID。集成需要新标识符时也可以更改它。

以下示例更新 XML 内容和标识符：

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # 读取当前 XML 为文本。
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # 将 XML 更新为 UTF-8 字符串。
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data 提供相同的 XML 内容，以原始字节形式。
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # 当集成需要时替换标识符。
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

为 `xml_as_string` 或 `xml_data` 赋值时，请提供有效且非空的 XML。根据应用程序主要处理字符串还是字节数据，选择一种表示方式即可。

### **删除自定义 XML 部分**

Aspose.Slides 提供多种删除自定义 XML 数据的方法：

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customxmlpart/remove/) 从演示文稿中删除该自定义 XML 部分。
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customxmlpartcollection/remove/) 从自定义 XML 部分集合中删除指定部件。
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customxmlpartcollection/remove_at/) 删除集合中指定索引处的部件。
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/customxmlpartcollection/clear/) 删除特定集合中的所有部件。

以下示例通过引用删除一个演示文稿级别的自定义 XML 部分：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

如果已经拥有 `CustomXmlPart` 并希望直接从演示文稿中删除该部件，而不是定位到特定集合，请调用 `custom_xml_part.remove()`。

也可以通过索引删除项目：

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **清除集合中的所有自定义 XML 部分**

当需要删除与特定演示文稿对象关联的所有自定义 XML 部分时，请使用 `clear`。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` 仅影响所选集合。例如，清除幻灯片的集合不会清除演示文稿级或形状级的集合。

若要删除演示文稿中的所有自定义 XML 部分，可遍历 `all_custom_xml_parts` 并逐个删除：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **处理链接或共享的自定义 XML 部分**

在 Office Open XML 演示文稿中，同一个自定义 XML 部分可以被多个演示文稿对象引用。例如，现有文件可能包含来自多个幻灯片或形状指向同一底层自定义 XML 部分的关系。

共享部件应视为一个数据对象，具有多个引用：

- 更新其 `xml_as_string`、`xml_data` 或 `item_id` 会改变底层自定义 XML 部分，因此更改会在所有引用处生效。
- `item_id` 可用于在审计对象级集合时识别同一自定义 XML 部分。
- 从特定 `custom_xml_parts` 集合中移除部件仅会从该集合中删除。若部件本身需要从演示文稿中移除，请使用 `CustomXmlPart.remove()`。
- 在删除或替换共享部件之前，检查对象级集合以确定是否还有其他幻灯片或形状引用它。

`add` 重载方法从 XML 内容创建新自定义 XML 部分；它们不接受现有的 `CustomXmlPart`。因此，共享关系通常在加载已包含该关系的演示文稿时出现。

以下示例通过 `item_id` 审计演示文稿、幻灯片和形状级集合，并报告被多个位置引用的部件：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

在对外部系统创建的演示文稿中的自定义 XML 数据进行修改或删除之前进行此类审计非常有用，因为同一元数据部件可能参与多个关系。

## **获取标签值**

在 Slides 中，标签对应 `DocumentProperties.keywords` 属性。以下示例代码展示了如何使用 Aspose.Slides for Python via .NET 获取 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 的标签值：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **向演示文稿添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常包含两个项目：

- 自定义属性的名称，例如 `MyTag`；
- 自定义属性的值，例如 `My Tag Value`。

如果需要依据特定规则或属性对演示文稿进行分类，可添加相应的标签。例如，想要对北美国家的演示文稿进行归类，可创建 “NorthAmerican” 标签并将相应国家设为其值。

以下示例代码展示了如何使用 Aspose.Slides for Python via .NET 向 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 添加标签：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

标签也可以为 [Slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/) 设置：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

或为单个 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/) 设置：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **限制**

通过 `custom_data.tags` 集合添加的标签仅存储在 PowerPoint 文件中。导出为 PDF 时，它们 **不会** 转移到 PDF 的标签结构。因此，作为标签的自定义标识符无法从已标记的 PDF 中检索。

**解决办法**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如 `shape.alternative_text = "MyId"`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **常见问答**

**我能否一次性删除演示文稿、幻灯片或形状中的所有标签？**

可以。[tag collection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/clear/) 操作，可一次性删除所有键值对。

**如何在不遍历整个集合的情况下，仅凭名称删除单个标签？**

在 [TagCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/) 上使用 [remove(name)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/remove/) 即可按键删除标签。

**如何获取全部标签名称以进行分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/) 上调用 [get_names_of_tags](https://reference.aspose.com/slides/zh/python-net/aspose.slides/tagcollection/get_names_of_tags/) 会返回所有标签名称的数组。

**如何查找所有自定义 XML 部分，而不论它们存放在哪里？**

使用 [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/all_custom_xml_parts/) 可检索演示文稿中的所有自定义 XML 部分。

**在更新自定义 XML 部分时，我该使用 `xml_as_string` 还是 `xml_data`？**

当应用程序处理 UTF-8 XML 文本时使用 `xml_as_string`；当 XML 已以字节数组形式可用或更倾向于二进制处理时使用 `xml_data`。两个属性表示的是同一自定义 XML 部分的内容。