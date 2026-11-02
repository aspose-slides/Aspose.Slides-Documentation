---
title: 在 Python 中管理演示文稿属性
linktitle: 演示文稿属性
type: docs
weight: 70
url: /zh/python-java/presentation-properties/
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
description: "在 Aspose.Slides for Python via Java 中精通演示文稿属性，并在您的 PowerPoint 和 OpenDocument 文件中简化搜索、品牌化和工作流。"
---
## **介绍**

Aspose.Slides for Python via Java 支持 **内置** 和 **自定义** 文档属性。使用这些属性读取和更新演示文稿的元数据，例如作者、标题和用户定义的值。

Aspose.Slides 允许您通过 [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) 类来处理演示文稿的文档属性。该类的实例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) 返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在保存演示文稿时会管理应用程序和生成者的元数据；这些字段标识创建输出的软件。
{{% /alert %}}

## **管理演示文稿属性**

文档属性在演示内容旁存储描述性信息。它们分为两类：

- **内置属性** 包含标准元数据，例如标题、作者和文档统计信息。
- **自定义属性** 存储用户定义的名称/值对。

Aspose.Slides for Python via Java 提供对这两类属性的访问。在 PowerPoint 中，选择 **文件 → 信息 → 属性 → 高级属性** 以检查文档元数据。对话框将信息分组到 **摘要**、**统计**、**内容** 和 **自定义** 等标签页。使用 **自定义** 标签页来管理用户定义的属性。

## **从加密演示文稿读取公共属性**

打开密码通常会保护演示文稿内容和文档属性。当在调用 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 并传入 `False` 后对演示文稿进行加密时，其文档属性仍保持为公共的。此时应用程序可以调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 并传入 `True`，在无需提供打开密码的情况下读取公共元数据。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 控制 Aspose.Slides 加载的内容；它不会进行解密。如果属性被加密，未提供密码加载会失败。如果演示文稿未加密，则该选项被忽略，完整的演示文稿会被加载。

示例需要一个文档属性保持公共的加密演示文稿。它通过 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 验证加载模式，然后通过 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) 读取内置属性：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

在此模式下，幻灯片内容不会被加载。幻灯片、母版、布局、形状、媒体及其他演示对象均不可用。应用程序在执行需要完整演示对象模型的操作前，应始终检查 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="Warning" %}}
公共元数据可能泄露作者姓名、标题、主题、关键字、公司信息、注释和自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统有特定需求必须在不使用密码的情况下访问时，才将其保持公共。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，在调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 并传入 `True` 后加载的演示文稿仅用于读取公共元数据。Aspose.Slides 无法从仅包含元数据的对象保存已更改的属性，因为公共属性必须与加密演示文稿内部的相应数据保持一致。因此，更新这些属性需要正确的打开密码并完成完整加载。

示例需要一个具有公共文档属性且已知打开密码的加密 PPTX 演示文稿。它使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) 打开完整演示文稿，更新公共内置属性并保存结果。随后使用 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) 验证加密仍然保留，并在不提供密码的情况下重新打开公共元数据以验证新值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

如果应用程序不被允许解密或加载演示文稿内容，则必须将加密 PPTX 文件的公共属性视为只读。

## **访问内置属性**

[DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) 类通过 getter 方法公开内置元数据，包括 [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor)、[getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) 和 [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime)。此示例打开现有演示文稿并将其存储的元数据打印到控制台。值取决于输入的演示文稿；某些字段可能为空。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **修改内置属性**

要更新内置元数据，请对由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) 返回的对象使用 setter 方法。此示例打开现有演示文稿，调用 [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor)、[setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle)、[setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject)、[setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) 和 [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager)，随后使用 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 保存更新后的演示文稿。保存的 PPTX 包含新元数据。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **管理超链接基准**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) 返回文档级别的相对超链接基准。使用 [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) 可以更改或清除它。当将演示文稿及其链接文件移动到其他位置时，这非常有用。它与单个超链接的 [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) 是分离的：更改基准不会重写已存储的链接地址或更改绝对目标。

示例需要一个包含相对链接（例如 `target.html`）和绝对链接（例如 `https://example.org/absolute.html`）的演示文稿。它读取现有基准，分配新的基准地址，并保存后重新打开演示文稿以检查该值。随后使用空字符串清除基准，并在另一个保存的文件中验证空值。请将示例基准地址替换为您的链接文件所在位置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

两个验证消息应打印 `True`。清除基准后，单个超链接地址保持不变。

当基准指向 `old` 文件夹时，指向 `target.pptx` 的相对链接会打开 `old/target.pptx`。将基准更改为 `new` 文件夹后，保存并重新打开演示文稿，同一链接会打开 `new/target.pptx`。绝对链接仍然打开相同的文件。请在 PowerPoint 中在移动演示文稿或更改基准前后测试您的相对链接。

## **添加自定义演示文稿属性**

自定义属性存储没有对应内置字段的元数据。[DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) 方法允许您通过属性名称赋值。此示例创建一个演示文稿，添加两个文本值和一个整数版本值（使用 `jpype.JInt` 传递 Java 整数），并使用 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 保存演示文稿。为已存在的名称赋值会替换该属性的值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **访问和修改自定义属性**

此示例打开包含自定义属性的演示文稿，并使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) 遍历它们。 [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) 接受从零开始的索引并返回由 [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) 使用的名称。示例打印每个原始名称和值，将所有值替换为带编号的字符串（不论其原始类型），并保存更改。如果没有自定义属性，循环不会进行任何更改。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **实时示例**

试用在线应用程序 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 了解如何使用 Aspose.Slides API 操作文档属性：

[![查看并编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常见问题**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，不能完全移除。但您可以更改其值，或在该属性允许的情况下将其设置为空。

**如果添加已存在的自定义属性会怎样？**

如果添加的自定义属性已存在，其现有值会被新值覆盖。您无需事先删除或检查该属性，Aspose.Slides 会自动更新属性的值。

**是否可以在不完整加载演示文稿的情况下访问演示文稿属性？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 然后调用 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 即可在不创建 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。完整的报告示例及格式特定限制请参阅 [Build a Lightweight Presentation Inventory](/slides/zh/python-java/examine-presentation/)。

**是否可以在不提供打开密码的情况下读取加密演示文稿的公共属性？**

可以。演示文稿必须是在调用 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 并传入 `False` 后进行加密，并且在调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 并传入 `True` 后加载。

**是否可以在仅文档属性模式下更新加密的 PPTX 文件？**

不能。公共属性和加密属性数据必须保持一致，因此更新加密的 PPTX 文件需要使用正确的打开密码加载完整的演示文稿。