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
description: "在 Aspose.Slides for Python via .NET 中精通演示文稿属性，并简化 PowerPoint 文件中的搜索、品牌和工作流。"
---
## **Introduction**

Aspose.Slides 支持两种文档属性类型：**内置**和**自定义**。这两种属性类型都可以通过 Aspose.Slides API 轻松访问和管理。

Aspose.Slides 允许您通过 [DocumentProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/) 类来处理演示文稿的文档属性。该类的实例由 [Presentation.document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/document_properties/) 属性返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
请注意，您无法对 **Application** 和 **Producer** 字段设置值，因为这些字段将显示 Aspose Ltd. 和 Aspose.Slides for Python via .NET x.x.x 的信息。
{{% /alert %}} 

## **管理演示文稿属性**

Microsoft PowerPoint 提供了向演示文稿文件添加属性的功能。这些文档属性允许在文档（演示文稿文件）中存储一些有用的信息。文档属性分为以下两类：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置**属性包含有关文档的一般信息，例如文档标题、作者姓名、文档统计信息等。**自定义**属性是用户以 **名称/值** 对的形式自行定义的属性，名称和值均由用户指定。使用 Aspose.Slides for Python via .NET，开发人员可以访问和修改内置属性以及自定义属性的值。Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。只需单击 Office 图标，然后依次选择 **Prepare | Properties | Advanced Properties** 菜单项。在选择 **Advanced Properties** 后，会出现一个对话框，允许您管理 PowerPoint 文件的文档属性。在 **Properties Dialog** 中，您可以看到多个选项卡，例如 **常规、摘要、统计信息、内容和自定义**。所有这些选项卡都用于配置与 PowerPoint 文件相关的不同信息。**自定义**选项卡用于管理 PowerPoint 文件的自定义属性。

## **读取已加密演示文稿的公共属性**

打开密码通常同时保护演示内容和文档属性。当演示文稿使用 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) 并将其设置为 `False` 加密时，文档属性保持公开。此时应用程序可以将 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/only_load_document_properties/) 设置为 `True`，在不提供打开密码的情况下读取公共元数据。

`only_load_document_properties` 控制 Aspose.Slides 加载的内容；它不进行任何解密。如果属性被包含在加密中，则在未提供密码的情况下加载会失败。如果演示文稿未加密，则该选项被忽略，完整的演示文稿将被加载。

以下示例通过 [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/zh/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) 验证加载模式，然后通过 [Presentation.document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/document_properties/) 读取内置属性：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

在此模式下，幻灯片内容不会被加载。幻灯片、母版、布局、形状、媒体及其他演示对象均不可用。应用程序应始终在执行需要完整演示对象模型的操作之前检查 `is_only_document_properties_loaded`。

{{% alert color="warning" title="Security" %}}
公共元数据可能会泄露作者姓名、标题、主题、关键字、公司信息、注释以及自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统明确要求在无需密码的情况下访问时才将其设为公开。
{{% /alert %}}

## **更新已加密演示文稿的属性**

对于已加密的 PPTX 文件，使用 `only_load_document_properties` 加载的演示文稿仅用于读取公共元数据。Aspose.Slides 无法从仅包含元数据的对象保存已更改的属性，因为公共属性必须与加密演示文稿内部的对应数据保持一致。因此，更新这些属性需要正确的打开密码并完整加载演示文稿。

以下示例使用 [LoadOptions.password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/password/) 打开演示文稿，更新公共内置属性并保存结果。随后使用 [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/is_encrypted/) 验证加密仍然保留，并在不提供密码的情况下重新打开公共元数据以验证新值：

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

如果应用程序不被允许解密或加载演示文稿内容，则必须将已加密 PPTX 文件的公共属性视为只读。

## **访问内置属性**
这些通过 **IDocumentProperties** 对象公开的属性包括：**Creator(Author)**、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最后打印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同制作者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**
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

修改演示文稿文件的内置属性与访问它们一样简单。只需为任意想要的属性赋予字符串值，即可修改属性值。下面的示例演示了如何修改演示文稿文件的内置文档属性。

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

Aspose.Slides for Python via .NET 还允许开发人员为演示文稿的文档属性添加自定义值。下面的示例展示了如何为演示文稿设置自定义属性。

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

Aspose.Slides for Python via .NET 还允许开发人员访问自定义属性的值。下面的示例展示了如何访问并修改演示文稿的所有自定义属性。

```py
import aspose.slides as slides

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # 创建与 Presentation 关联的 document_properties 对象引用
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

`get_custom_property_value` 通过其第二个参数传入的单元素列表返回值，并将存储的值转换为该列表中已有元素的类型。上例使用 `[""]`，因此读取的是字符串属性；若要读取存储为数字的属性，请传入数值占位符，例如 `[0]`——否则调用会抛出 `InvalidCastException`。

## **设置校对语言**

Aspose.Slides 提供了 `Language_Id` 属性（由 [PortionFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/) 类公开），允许您为 PowerPoint 文档设置校对语言。校对语言是 PowerPoint 检查拼写和语法的语言。

以下 Python 代码展示了如何为 PowerPoint 设置校对语言：

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

以下 Python 代码展示了如何为整个 PowerPoint 演示文稿设置默认语言：

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

尝试在线应用程序 **Aspose.Slides Metadata**，了解如何通过 Aspose.Slides API 操作文档属性：

[![查看并编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/zh/metadata)

## **FAQ**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，不能完全删除。但您可以更改其值，或者在特定属性允许的情况下将其设为空。

**如果添加的自定义属性已存在，会怎样？**

如果添加的自定义属性已经存在，其现有值会被新值覆盖。您无需事先删除或检查该属性，Aspose.Slides 会自动更新属性值。

**能否在不完整加载演示文稿的情况下访问演示属性？**

可以。使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/) 然后调用 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/read_document_properties/) 即可在不创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。参见 [构建轻量级演示文稿清单](/slides/zh/python-net/examine-presentation/) 了解完整报告示例及格式特定限制。

**是否可以在不提供打开密码的情况下读取已加密演示文稿的公共属性？**

可以。前提是演示文稿在加密时 `encrypt_document_properties` 设置为 `False`，并且使用 `only_load_document_properties` 设置为 `True` 加载。

**能否在仅文档属性模式下更新已加密的 PPTX 文件？**

不能。公共属性和加密属性的数据必须保持一致，因此更新已加密的 PPTX 文件必须使用正确的打开密码完整加载演示文稿。