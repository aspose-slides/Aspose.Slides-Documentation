---
title: 使用 Python 在演示文稿中管理标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/python-java/managing-tags-and-custom-data/
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
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中管理标签和自定义 XML 数据，包括添加、读取、更新、审计和删除自定义 XML 部分。"
---
## **概述**

本文档说明了 Aspose.Slides 如何在 PowerPoint 演示文稿中使用标签和自定义数据。演示文稿特定的数据可以存储为标签或自定义 XML 部分。标签是简单的键值字符串对，而自定义 XML 部分可以存储结构化的元数据和应用程序特定的 XML 负载。

Aspose.Slides 提供了在演示文稿、幻灯片和形状级别添加、读取、更新、审计和删除自定义 XML 部分的 API。自定义 XML 部分对于存储诸如文档管理标识符、工作流状态、合规元数据、模板绑定数据或其他结构化应用程序数据等信息的集成非常有用。

## **演示文稿文件中的数据存储**

PPTX 文件——扩展名为 `.pptx` 的文件——采用 PresentationML 格式存储，这是一部分 Office Open XML 规范。Office Open XML 定义了用于存储演示文稿内容及相关数据的包结构和关系。

一个演示文稿包含多个通过关系相连的部分。例如，幻灯片部分包含单个幻灯片的内容，并且可以通过 ISO/IEC 29500 定义的显式关系链接到其他部分。

自定义数据可以作为标签（[TagCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tagcollection/)）或自定义 XML 部分（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpartcollection/)）存储。两者均通过 [CustomData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customdata/) 类访问。

{{% alert color="info" title="Note" %}}
标签存储简单的字符串键值对。自定义 XML 部分存储结构化的 XML 数据，并且可以关联到演示文稿、幻灯片或形状。
{{% /alert %}}

## **使用自定义 XML 部分**

[CustomData.getCustomXmlParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customdata/#getCustomXmlParts) 方法返回与特定演示文稿对象关联的自定义 XML 部分集合。例如：

- 演示文稿的 [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customdata/#getCustomXmlParts) 集合包含与演示文稿本身关联的自定义 XML 部分。
- 幻灯片的 [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customdata/#getCustomXmlParts) 集合包含与特定幻灯片关联的自定义 XML 部分。
- 形状的 [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customdata/#getCustomXmlParts) 集合包含与特定形状关联的自定义 XML 部分。

当需要检查演示文稿中所有自定义 XML 部分（不论其关联对象）时，请使用 [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getAllCustomXmlParts)。

### **向演示文稿添加自定义 XML 部分**

使用 [CustomXmlPartCollection.add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpartcollection/#add) 将 XML 数据添加到自定义 XML 部分集合中。XML 必须有效且非空。

以下示例向演示文稿级别的自定义数据集合添加结构化元数据：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add 会自动分配标识符。仅在需要时才设置特定的 UUID。
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpartcollection/#add) 方法还可以接受 XML 的字节数组或输入流，这在 XML 内容已经以二进制形式存在时非常有用。

### **向幻灯片或形状添加自定义 XML 部分**

自定义 XML 数据可以关联到特定幻灯片或形状，而不是整个演示文稿。当元数据仅描述单个对象（例如模板键、外部记录标识符或绑定信息）时，这非常有用。

以下示例向一个幻灯片添加一个自定义 XML 部分，并向一个形状添加另一个：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

添加部分的层级决定了哪个对象的 [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customdata/#getCustomXmlParts) 集合包含对该部分的关系。演示文稿级别的数据适用于全局元数据，幻灯片级别的数据适用于特定幻灯片的信息，形状级别的数据适用于单个形状的元数据。

### **列出并审计所有自定义 XML 部分**

使用 [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getAllCustomXmlParts) 检索演示文稿中的所有自定义 XML 部分。每个 [CustomXmlPart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/) 都会暴露其标识符、XML 内容以及关联的命名空间架构。

以下示例列出所有自定义 XML 部分及其命名空间架构：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) 返回与自定义 XML 部分关联的 XML 架构。当审计包含外部系统生成的 XML 的演示文稿时，此信息可能非常有用。

### **读取并更新 XML 内容和 ItemId**

使用 [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#getXmlAsString) 和 [setXmlAsString](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#setXmlAsString) 以 UTF-8 字符串形式处理 XML，或使用 [getXmlData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#getXmlData) 和 [setXmlData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#setXmlData) 以原始字节形式处理。

[CustomXmlPart.getItemId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#getItemId) 方法返回标识该自定义 XML 部分在 Office Open XML 文档中的 UUID。需要新标识符时，请使用 [setItemId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#setItemId)。

以下示例更新 XML 内容和标识符：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # 读取当前的 XML 文本。
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # 将 XML 更新为 UTF-8 字符串。
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData 提供相同的 XML 内容，以原始字节形式。
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # 在集成需要时替换标识符。
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

在调用 [setXmlAsString](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#setXmlAsString) 或 [setXmlData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#setXmlData) 时，提供有效且非空的 XML。根据应用程序是主要处理字符串还是字节数据，选择其中一种表示方式。

### **删除自定义 XML 部分**

Aspose.Slides 提供多种方式删除自定义 XML 数据：

- [CustomXmlPart.remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#remove) 从演示文稿中删除该自定义 XML 部分。
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpartcollection/#remove) 从自定义 XML 部分集合中删除特定部分。
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpartcollection/#removeAt) 删除指定集合索引处的部分。
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpartcollection/#clear) 删除特定集合中的所有部分。

以下示例通过引用删除一个演示文稿级别的自定义 XML 部分：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果已有 [CustomXmlPart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/) 并希望从演示文稿中删除该部分，而不是针对特定集合，请调用 [CustomXmlPart.remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#remove)。

也可以按索引删除项目：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **清除集合中的所有自定义 XML 部分**

当需要删除与特定演示文稿对象关联的所有自定义 XML 部分时，使用 [clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpartcollection/#clear)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpartcollection/#clear) 仅影响选定的集合。例如，清除幻灯片的集合不会清除演示文稿级或形状级的集合。

要删除演示文稿中的所有自定义 XML 部分，可遍历 [getAllCustomXmlParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getAllCustomXmlParts) 并删除每个部分：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **处理链接或共享的自定义 XML 部分**

在 Office Open XML 演示文稿中，同一个自定义 XML 部分可能被多个演示文稿对象引用。例如，一个文件可以包含来自多个幻灯片或形状指向同一底层自定义 XML 部分的关系。

共享的部分应视为一个数据对象，但具有多个引用：

- 使用 [setXmlAsString](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#setXmlAsString)、[setXmlData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#setXmlData) 或 [setItemId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#setItemId) 更新它时，会更改底层自定义 XML 部分，从而在所有引用该部分的地方生效。
- [getItemId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#getItemId) 可用于在审计对象级集合时识别相同的自定义 XML 部分。
- 从特定的 [getCustomXmlParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customdata/#getCustomXmlParts) 集合中删除部分，只会将其从该集合中移除。若要从演示文稿中完全删除该部分，请使用 [CustomXmlPart.remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#remove)。
- 在删除或替换共享部分之前，检查对象级集合，以确定是否还有其他幻灯片或形状引用该部分。

[add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpartcollection/#add) 重载会从 XML 内容创建新的自定义 XML 部分；它们不接受已有的 [CustomXmlPart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/)。因此，加载已经包含共享关系的演示文稿时最常遇到共享关系。

以下示例按 `ItemId` 审计演示文稿、幻灯片和形状级别的集合，并报告被多个位置引用的部分：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

此类审计在修改或删除由外部系统创建的演示文稿中的自定义 XML 数据之前非常有用，因为同一元数据部分可能参与多个关系。

## **获取标签的值**

在 Slides 中，标签对应于 [DocumentProperties.getKeywords](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getKeywords) 方法。以下示例代码展示了如何使用 Aspose.Slides for Python via Java 获取 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 中的标签值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **向演示文稿添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常由两项组成：

- 自定义属性的名称，例如 `MyTag`；
- 自定义属性的值，例如 `My Tag Value`。

如果需要根据特定规则或属性对演示文稿进行分类，可以添加相应的标签。例如，要对来自北美国家的演示文稿进行分类，可创建一个北美标签并将相应的国家名称作为其值。

以下示例代码展示了如何使用 Aspose.Slides for Python via Java 向 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 添加标签：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

标签也可以为 [Slide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/) 设置：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

或为单个 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 设置：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **限制**

通过 [CustomData.getTags](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customdata/#getTags) 集合添加的标签仅存储在 PowerPoint 文件中。导出为 PDF 时，它们 **不会** 转移到 PDF 的标签结构中。因此，作为标签分配的自定义标识符无法从带标签的 PDF 中检索。

**解决办法**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如，使用 [Shape.setAlternativeText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#setAlternativeText) 并设置值 `"MyId"`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **常见问题解答**

**是否可以一次性删除演示文稿、幻灯片或形状中的所有标签？**

可以。标签集合（[tag collection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tagcollection/)）支持 [clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tagcollection/#clear) 操作，一次性删除所有键值对。

**如何在不遍历整个集合的情况下，仅通过名称删除单个标签？**

在标签集合上使用 [remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tagcollection/#remove) 并传入键即可删除对应的标签。

**如何获取完整的标签名称列表以进行分析或过滤？**

使用标签集合的 [getNamesOfTags](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tagcollection/#getNamesOfTags) 方法，它返回所有标签名称的数组。

**如何找到所有自定义 XML 部分，而不论它们存储在哪里？**

使用 [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getAllCustomXmlParts) 检索演示文稿中的全部自定义 XML 部分。

**在更新自定义 XML 部分时，我应使用 [getXmlAsString]/[setXmlAsString] 还是 [getXmlData]/[setXmlData]？**

当应用程序使用 UTF-8 XML 文本时，使用 [getXmlAsString](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#getXmlAsString) 和 [setXmlAsString](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#setXmlAsString)。当 XML 已以字节数组形式存在或二进制处理更方便时，使用 [getXmlData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#getXmlData) 和 [setXmlData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/customxmlpart/#setXmlData)。两种表示方式都指向同一自定义 XML 部分的内容。