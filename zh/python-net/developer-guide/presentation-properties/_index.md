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
description: "在 Aspose.Slides for Python via .NET 中掌握演示文稿属性，并在 PowerPoint 文件中简化搜索、品牌化和工作流。"
---
## **简介**

Aspose.Slides for Python via .NET 支持 **内置** 和 **自定义** 文档属性。使用这些属性读取和更新演示文稿元数据，例如作者、标题和用户定义的值。

Aspose.Slides 允许您通过 [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 类来处理演示文稿的文档属性。该类的实例通过 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) 获得。下面的示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在保存演示文稿时会管理应用程序和生产者元数据；这些字段用于标识创建输出的软件。
{{% /alert %}}

## **管理演示文稿属性**

文档属性在演示文稿内容旁边存储描述性信息。它们分为两类：

- **内置属性** 包含标准元数据，例如标题、作者和文档统计信息。
- **自定义属性** 存储用户定义的名称/值对。

Aspose.Slides for Python via .NET 提供对这两类属性的访问。在 PowerPoint 中，选择 **文件 → 信息 → 属性 → 高级属性** 以检查文档元数据。对话框将信息分组到 **摘要**、**统计信息**、**内容** 和 **自定义** 等选项卡。使用 **自定义** 选项卡来管理用户定义的属性。

## **读取加密演示文稿的公共属性**

打开密码通常会保护演示文稿内容和文档属性。 当使用 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) 并将其设置为 `False` 对演示文稿进行加密时，其文档属性保持为公共。 此时应用程序可以将 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 设置为 `True`，在不提供打开密码的情况下读取公共元数据。

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 控制 Aspose.Slides 加载的内容；它不会进行任何解密。如果属性被加密，未提供密码加载将失败。若演示文稿未加密，则此选项被忽略，完整演示文稿将被加载。

示例需要一个文档属性保持公共的加密演示文稿。它通过 [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) 验证加载模式，然后通过 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) 读取内置属性：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

在此模式下，幻灯片内容不会被加载。幻灯片、母版、布局、形状、媒体及其他演示文稿对象均不可用。应用程序在执行需要完整演示文稿对象模型的操作之前，应始终检查 [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/)。

{{% alert color="warning" title="Security" %}}
公共元数据可能会泄露作者姓名、标题、主题、关键字、公司信息、注释和自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统明确需要在不提供密码的情况下访问时才将其保持公开。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，使用 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 加载的演示文稿仅用于读取公共元数据。Aspose.Slides 无法从仅包含元数据的对象中保存更改的属性，因为公共属性必须与加密演示文稿内部的相应数据保持一致。因此，更新这些属性需要正确的打开密码并完整加载演示文稿。

示例需要一个具有公共文档属性且已知打开密码的加密 PPTX 演示文稿。它使用 [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) 打开完整的演示文稿，更新公共内置属性并保存结果。随后使用 [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) 验证加密仍然保留，并在不提供密码的情况下重新打开公共元数据以验证新值：

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
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

如果应用程序不被允许解密或加载演示文稿内容，则必须将加密 PPTX 文件的公共属性视为只读。

## **访问内置属性**

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 类通过类型化属性公开内置元数据，包括 [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)、[DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) 和 [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/)。此示例打开现有演示文稿并将其存储的元数据打印到控制台。值取决于输入的演示文稿；某些字段可能为空。

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **修改内置属性**

要更新内置元数据，请为 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) 暴露的可写属性赋值。此示例打开现有演示文稿，设置 [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)、[DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/)、[DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/)、[DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) 和 [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/)，然后使用 [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 保存更新后的演示文稿。保存的 PPTX 包含新的元数据。

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **管理超链接基址**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) 保存文档级别的相对超链接基址。当把演示文稿及其关联文件移动到其他位置时，这非常有用。它与单个超链接的 [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) 分离：更改基址不会重写已存储的链接地址或更改绝对目标。

示例需要一个包含相对链接（例如 `target.html`）和指向文件或网站的绝对链接的演示文稿。它读取现有基址，分配新的基址，然后保存并重新打开演示文稿以检查该值。随后使用 `""` 清除基址，并在另一个保存的文件中验证为空值。请将示例基址替换为您链接文件所在的位置。

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

两个验证消息应输出 `True`。清除基址后，单个超链接地址保持不变。

当基址指向 `old` 文件夹时，指向 `target.pptx` 的相对链接会打开 `old/target.pptx`。将基址更改为 `new` 文件夹后，保存并重新打开演示文稿，同一链接会打开 `new/target.pptx`。绝对链接仍然打开相同的文件。请在 PowerPoint 中在移动演示文稿或更改基址前后测试您的相对链接。

## **添加自定义演示文稿属性**

自定义属性存储没有对应内置字段的元数据。[DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) 方法允许您按属性名称分配值。此示例创建一个演示文稿，添加两个文本值和一个整数版本值，并使用 [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 保存演示文稿。为已存在的名称赋值会替换该属性的值。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **访问和修改自定义属性**

此示例打开包含自定义属性的演示文稿，并使用 [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) 进行遍历。 [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) 接受从零开始的索引并返回由 [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) 使用的名称。示例需要一个所有自定义属性均为字符串的演示文稿。它打印每个原始名称和值，用带编号的字符串替换每个值，并保存更改。如果没有自定义属性，则循环不进行任何更改。

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) 通过作为第二参数传入的单元素列表返回值。占位符必须与存储属性的类型匹配：字符串使用 `[""]`，整数使用 `[0]`。类型不匹配会抛出 `InvalidCastException`；请根据自定义属性的模式选择相应的占位符。

## **实时示例**

尝试在线应用程序 [**查看并编辑 PowerPoint 元数据**](https://products.aspose.app/slides/metadata) 以了解如何使用 Aspose.Slides API 操作文档属性：

[![查看并编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常见问题**

**如何从演示文稿中删除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。不过，您可以更改它们的值，或在特定属性允许的情况下将其设为空。

**如果添加已经存在的自定义属性会怎样？**

如果添加已经存在的自定义属性，其现有值将被新值覆盖。您无需先删除或检查属性，因为 Aspose.Slides 会自动更新属性的值。

**是否可以在不完整加载演示文稿的情况下访问演示文稿属性？**

可以。使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) 然后 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) 可在不创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。请参阅 [Build a Lightweight Presentation Inventory](/slides/zh/python-net/examine-presentation/) 获取完整的报告示例及格式特定限制。

**我能在不提供打开密码的情况下读取加密演示文稿的公共属性吗？**

可以。演示文稿必须使用 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) 设置为 `False` 进行加密，并且加载时必须将 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 设置为 `True`。

**我能在仅文档属性模式下更新加密的 PPTX 文件吗？**

不能。公共和加密的属性数据必须保持一致，因此在文档属性仅模式下更新加密的 PPTX 文件需要使用正确的打开密码完整加载演示文稿。