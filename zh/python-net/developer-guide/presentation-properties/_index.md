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
description: "在 Aspose.Slides for Python via .NET 中精通演示文稿属性，并简化 PowerPoint 文件的搜索、品牌化和工作流。"
---
## **简介**

Aspose.Slides 支持两种文档属性类型：**内置**和**自定义**。这两种属性类型都可以通过 Aspose.Slides API 轻松访问和管理。

Aspose.Slides 允许您通过 [DocumentProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/) 类来处理演示文稿的文档属性。该类的实例由 [Presentation.document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/document_properties/) 属性返回。以下示例演示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
请注意，您不能为 **Application** 和 **Producer** 字段设置值，因为这些字段将显示 Aspose Ltd. 和 Aspose.Slides for Python via .NET x.x.x 的信息。
{{% /alert %}} 

## **管理演示文稿属性**

Microsoft PowerPoint 提供了向演示文稿文件添加属性的功能。这些文档属性可以将一些有用的信息与文档（演示文稿文件）一起存储。文档属性分为以下两类：

- 系统定义（内置）属性
- 用户自定义（自定义）属性

**内置**属性包含文档的一般信息，例如文档标题、作者姓名、文档统计等。**自定义**属性是用户以 **Name/Value** 键值对定义的属性，名称和值均由用户自行指定。使用 Aspose.Slides for Python via .NET，开发者可以访问和修改内置属性以及自定义属性的值。Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。您只需点击 Office 图标，然后选择 **Prepare | Properties | Advanced Properties** 菜单项。选择 **Advanced Properties** 后，会弹出一个对话框，允许您管理 PowerPoint 文件的文档属性。在 **Properties Dialog** 中，您可以看到诸如 **General、Summary、Statistics、Contents 和 Custom** 等多个选项卡。这些选项卡允许配置与 PowerPoint 文件相关的不同信息。**Custom** 选项卡用于管理 PowerPoint 文件的自定义属性。

## **访问内置属性**
这些属性由 **IDocumentProperties** 对象公开，包含：**Creator(Author)**、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同的制作者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**
```py
import aspose.slides as slides

# 实例化表示演示文稿的 Presentation 类
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
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

修改演示文稿文件的内置属性和访问它们一样简单。您只需为所需属性分配一个字符串值，即可修改属性值。下面的示例展示了如何修改演示文稿文件的内置文档属性。

```py
import aspose.slides as slides

# 实例化表示演示文稿的 Presentation 类
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
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

    # 移除选定的属性
    documentProperties.remove_custom_property(getPropertyName)

    # 保存演示文稿
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **访问并修改自定义属性**

Aspose.Slides for Python via .NET 还允许开发者访问自定义属性的值。下面的示例展示了如何访问并修改演示文稿的所有自定义属性。

```py
import aspose.slides as slides

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # 创建与演示文稿关联的 document_properties 对象引用
    documentProperties = presentation.document_properties

    # 访问并修改自定义属性
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # 显示自定义属性的名称和值
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # 修改自定义属性的值
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # 将演示文稿保存到文件
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` 通过其第二个参数传入的单元素列表返回值，并将存储的值转换为该列表中已有元素的类型。上述示例使用 `[""]`，因此读取字符串属性；若要读取存为数字的属性，请传入类似 `[0]` 的数值占位符——否则调用会抛出 `InvalidCastException`。

## **设置校对语言**

Aspose.Slides 提供 `Language_Id` 属性（由 [PortionFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/) 类公开），允许您为 PowerPoint 文档设置校对语言。校对语言是 PowerPoint 检查拼写和语法时使用的语言。

下面的 Python 代码示例演示如何为 PowerPoint 设置校对语言：

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
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

下面的 Python 代码示例演示如何为整个 PowerPoint 演示文稿设置默认语言：

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

尝试在线应用程序 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh/metadata) 了解如何通过 Aspose.Slides API 使用文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh/metadata)

## **常见问题**

**如何从演示文稿中删除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。但您可以更改其值，或在该属性允许的情况下将其设为空。

**如果添加已存在的自定义属性会怎样？**

如果添加已存在的自定义属性，其已有的值会被新值覆盖。无需事先删除或检查属性，Aspose.Slides 会自动更新属性的值。

**我能在不完全加载演示文稿的情况下访问演示文稿属性吗？**

可以。使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/) 然后调用 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/read_document_properties/) 即可在不创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 实例的情况下读取已存储的文档元数据。请参阅 [Build a Lightweight Presentation Inventory](/slides/zh/python-net/examine-presentation/) 获取完整的报告示例及特定格式的限制。