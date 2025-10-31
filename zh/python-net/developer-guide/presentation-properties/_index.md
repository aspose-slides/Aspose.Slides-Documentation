---
title: 使用 Python 管理演示文稿属性
linktitle: 演示文稿属性
type: docs
weight: 70
url: /zh/python-net/presentation-properties/
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
- Python
- Aspose.Slides
description: 在 Aspose.Slides for Python via .NET 中掌握演示文稿属性，并在 PowerPoint 文件中简化搜索、品牌化和工作流。
---

## **关于演示文稿属性**

正如我们之前所述，Aspose.Slides for Python via .NET 支持两种文档属性，分别是**内置**属性和**自定义**属性。因此，开发者可以使用 Aspose.Slides for Python via .NET API 访问这两种属性。Aspose.Slides for Python via .NET 提供了一个类 [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) ，它通过 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 属性表示与演示文稿文件关联的文档属性。开发者可以使用 **Presentation** 对象公开的 [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) 属性来访问演示文稿文件的文档属性，如下所示：

{{% alert color="primary" %}} 
请注意，您无法为 **Application** 和 **Producer** 字段设置值，因为这些字段将显示 Aspose Ltd. 和 Aspose.Slides for Python via .NET x.x.x 的信息。
{{% /alert %}} 

## **管理演示文稿属性**

Microsoft PowerPoint 提供了一项功能，可向演示文稿文件添加一些属性。这些文档属性允许在文档（演示文稿文件）中存储一些有用的信息。文档属性分为以下两类

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置**属性包含文档的一般信息，如文档标题、作者姓名、文档统计信息等。**自定义**属性是用户以 **名称/值** 对形式定义的属性，名称和值均由用户自行定义。使用 Aspose.Slides for Python via .NET，开发者可以访问并修改内置属性以及自定义属性的值。Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。只需单击 Office 图标，然后依次选择 **准备 | 属性 | 高级属性** 菜单项。选择 **高级属性** 后，将出现一个对话框，允许您管理 PowerPoint 文件的文档属性。在 **属性对话框** 中，您可以看到诸如 **常规、摘要、统计信息、内容和自定义** 等多个选项卡页面。这些选项卡页面允许配置与 PowerPoint 文件相关的不同信息。**自定义**选项卡用于管理 PowerPoint 文件的自定义属性。

## **访问内置属性**
这些属性由 **IDocumentProperties** 对象公开，包括：**Creator(Author)**、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同生产者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**

```py
import aspose.slides as slides

# 实例化表示演示文稿的 Presentation 类
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # 创建与 Presentation 关联的对象引用
    documentProperties = pres.document_properties

    # 显示内置属性
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **修改内置属性**

修改演示文稿文件的内置属性与访问它们一样简单。只需为任意想要的属性赋予字符串值，即可修改该属性的值。下面的示例演示了如何修改演示文稿文件的内置文档属性。

```py
import aspose.slides as slides

# 实例化表示演示文稿的 Presentation 类
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # 创建与 Presentation 关联的对象引用
    documentProperties = presentation.document_properties

    # 设置内置属性
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # 将演示文稿保存到文件
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **添加自定义演示文稿属性**

Aspose.Slides for Python via .NET 还允许开发者为演示文稿的文档属性添加自定义值。下面的示例展示了如何为演示文稿设置自定义属性。

```py
import aspose.slides as slides

# 实例化 Presentation 类
with slides.Presentation() as presentation:
    # 获取文档属性
    documentProperties = presentation.document_properties

    # 添加自定义属性
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # 获取特定索引处的属性名称
    getPropertyName = documentProperties.get_custom_property_name(2)

    # 删除选定的属性
    documentProperties.remove_custom_property(getPropertyName)

    # 保存演示文稿
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **访问并修改自定义属性**

Aspose.Slides for Python via .NET 还允许开发者访问自定义属性的值。下面的示例展示了如何访问和修改演示文稿的所有自定义属性。

```py
import aspose.slides as slides

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # 创建与 Presentation 关联的 document_properties 对象引用
    documentProperties = presentation.document_properties

    # 访问并修改自定义属性
    for i in range(documentProperties.count_of_custom_properties):
        # 显示自定义属性的名称和值
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # 修改自定义属性的值
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # 将演示文稿保存到文件
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **设置校对语言**

Aspose.Slides 提供 `Language_Id` 属性（由 [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) 类公开），以便您为 PowerPoint 文档设置校对语言。校对语言是 PowerPoint 检查拼写和语法时使用的语言。

以下 Python 代码演示如何为 PowerPoint 设置校对语言：

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # 设置校对语言的 Id
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **设置默认语言**

以下 Python 代码演示如何为整个 PowerPoint 演示文稿设置默认语言：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **实时示例**

尝试在线应用程序 [**Aspose.Slides 元数据**](https://products.aspose.app/slides/metadata) 以了解如何通过 Aspose.Slides API 操作文档属性：

[![查看并编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常见问题**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。但您可以更改其值，或在特定属性允许的情况下将其设为空。

**如果添加已存在的自定义属性会怎样？**

如果添加已存在的自定义属性，其现有值将被新值覆盖。您不需要事先删除或检查该属性，因为 Aspose.Slides 会自动更新属性值。

**是否可以在不完全加载演示文稿的情况下访问演示文稿属性？**

可以，您可以使用 [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) 类的 [get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) 方法仅获取演示文稿信息，然后利用 [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) 类的 [read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) 方法高效读取属性，从而节省内存并提升性能。