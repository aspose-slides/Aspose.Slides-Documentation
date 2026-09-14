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
- 内建属性
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
description: "在 Aspose.Slides for Python via Java 中掌握演示文稿属性，并简化 PowerPoint 与 OpenDocument 文件的搜索、品牌化和工作流程。"
---
## **简介**

Aspose.Slides 支持两种文档属性类型：**内建**和**自定义**。这两种属性类型都可以通过 Aspose.Slides API 轻松访问和管理。

Aspose.Slides 允许您通过 [DocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/) 类来处理演示文稿的文档属性。该类的实例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getDocumentProperties) 返回。下面的示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
请注意，**Application** 和 **AppVersion** 字段无法修改。Aspose.Slides 在每次保存时都会重写它们，因此保存的演示文稿始终报告为 “Aspose.Slides for Java” 以及生成它的库版本。传递给 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#setNameOfApplication) 的任何值在写入演示文稿时都会被丢弃。
{{% /alert %}}

## **PowerPoint 中的文档属性**

Microsoft PowerPoint 2007 允许您管理演示文件的文档属性。单击 Office 图标并选择 **准备 | 属性 | 高级属性**，如下所示：

|**选择高级属性菜单项**|
| :- |
|![PowerPoint 文档属性](https://i.imgur.com/ZrmuCD6.jpg)|

选择 **高级属性** 后，会出现一个对话框，您可以在其中管理 PowerPoint 文件的文档属性：

|**属性对话框**|
| :- |
|![PowerPoint 文档属性](https://i.imgur.com/LibmdQd.jpg)|

**属性对话框** 包含 **常规**、**摘要**、**统计**、**内容** 和 **自定义** 等选项卡。这些选项卡允许您配置 PowerPoint 文件的不同信息。使用 **自定义** 选项卡来管理自定义属性。

## **使用 Aspose.Slides for Python via Java 处理文档属性**

如前所述，Aspose.Slides for Python via Java 支持 **内建** 和 **自定义** 文档属性。[DocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/) 类表示与演示文件关联的文档属性。

使用 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getDocumentProperties) 访问这些属性，如下所述。

## **从加密演示文稿读取公共属性**

打开密码通常保护演示文稿内容和文档属性。通过向 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 传递 `false` 对演示文稿进行加密时，文档属性保持为公共的。随后，应用程序可以向 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 传递 `true`，在不提供打开密码的情况下读取公共元数据。

仅文档属性选项控制 Aspose.Slides 加载的内容；它不会解密任何内容。如果属性已包含在加密中，则在未提供密码的情况下加载会失败。如果演示文稿未加密，则该选项被忽略，加载完整的演示文稿。

以下示例通过 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 验证加载模式，然后通过 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getDocumentProperties) 读取内建属性：

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

在此模式下，幻灯片内容不会被加载。幻灯片、母版、布局、形状、媒体以及其他演示对象均不可用。应用程序在执行需要完整演示对象模型的操作之前，应始终检查 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="Warning" %}}
公共元数据可能会泄露作者姓名、标题、主题、关键字、公司信息、注释以及自定义值。应将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统明确要求在无密码情况下访问时才将其保持公开。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，以仅文档属性模式加载的演示文稿旨在读取公共元数据。Aspose.Slides 无法从该仅元数据对象保存已更改的属性，因为公共属性必须与加密演示文稿内部的相应数据保持一致。因此，更新这些属性需要正确的打开密码并完整加载演示文稿。

以下示例使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setPassword) 打开演示文稿，更新公共内建属性并保存结果。随后使用 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#isEncrypted) 验证加密仍然保留，并在不提供密码的情况下重新打开公共元数据以验证新值：

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

## **访问内建属性**

[DocumentProperties] 公开的内建属性包括：**Creator**（作者），**Description**，**Created**（创建日期），**Modified**（修改日期），**Printed**（最近打印日期），**LastModifiedBy**，**Keywords**，**SharedDoc**（是否在不同制作者之间共享？），**PresentationFormat**，**Subject**，以及 **Title**。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# 实例化表示演示文稿的 Presentation 类
presentation = Presentation("Presentation.pptx")
try:
    # 创建与 Presentation 关联的 DocumentProperties 对象的引用
    properties = presentation.getDocumentProperties()

    # 显示内建属性
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **修改内建属性**

修改内建属性与访问它们同样简单。使用相应的 setter 分配新值。以下示例使用 Aspose.Slides for Python via Java 修改内建文档属性。

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # 创建与 Presentation 关联的 DocumentProperties 对象的引用
    properties = presentation.getDocumentProperties()

    # 设置内建属性
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # 将演示文稿保存到文件
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此示例修改了演示文稿的内建属性，效果如下所示：

|**修改后内建文档属性**|
| :- |
|![PowerPoint 文档属性](https://i.imgur.com/zz1N9de.jpg)|

## **添加自定义文档属性**

Aspose.Slides for Python via Java 还允许开发人员向演示文稿添加自定义文档属性。下面的示例添加了三个自定义属性，然后查找索引 2 处存储的名称并删除该属性，因此保存的演示文稿保留了其中的两个。自定义属性按字母顺序索引，而不是添加的顺序。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # 获取文档属性
    properties = presentation.getDocumentProperties()

    # 添加自定义属性
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # 获取特定索引处的属性名称
    property_name = properties.getCustomPropertyName(2)

    # 删除选定的属性
    properties.removeCustomProperty(property_name)

    # 保存演示文稿
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**已添加的自定义文档属性**|
| :- |
|![PowerPoint 文档属性](https://i.imgur.com/HdKcxI9.png)|

## **访问并修改自定义属性**

Aspose.Slides for Python via Java 还允许开发人员访问自定义属性的值。以下示例展示了如何在演示文稿中访问并修改所有自定义属性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # 创建与 Presentation 关联的 DocumentProperties 对象的引用
    properties = presentation.getDocumentProperties()

    # 访问并修改自定义属性
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # 显示自定义属性的名称和值
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # 修改自定义属性的值
        properties.set_Item(property_name, f"New Value {i + 1}")

    # 将演示文稿保存到文件
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此示例修改了 [PPTX](https://docs.fileformat.com/presentation/pptx/) 演示文稿的自定义属性。下图显示了修改前后的演示文稿自定义属性：

|**修改前的自定义属性**|
| :- |
|![PowerPoint 文档属性](https://i.imgur.com/Ze7YHvi.jpg)|

|**修改后的自定义属性**|
| :- |
|![PowerPoint 文档属性](https://i.imgur.com/Tofu0CL.jpg)|

## **高级文档属性**

{{% alert color="info" title="Note" %}}
新增了方法 [readDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#readDocumentProperties)、[updateDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) 和 [writeBindedPresentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) 至 [PresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/)，并且 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#setLastSavedTime) 方法的行为已更改。
{{% /alert %}}

已向 [PresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/) 类添加了两个新方法 [readDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 和 [updateDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#updateDocumentProperties)。它们提供了快速访问文档属性的方式，并允许您在不加载整个演示文稿的情况下更改和更新属性。

加载属性、修改其值并更新文档的典型工作流程如下所示：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# 读取演示文稿信息
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# 获取当前属性
properties = presentation_info.readDocumentProperties()

# 设置 Author 和 Title 字段的新值
properties.setAuthor("New Author")
properties.setTitle("New Title")

# 使用新值更新演示文稿
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

还有另一种方法是使用特定演示文稿的属性作为模板来更新其他演示文稿的属性：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

可以从头创建一个新模板，然后用于更新多个演示文稿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **设置校对语言**

Aspose.Slides 提供了 [PortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/#setLanguageId) 方法，允许您为 PowerPoint 文档设置校对语言。校对语言是对演示文稿中的拼写和语法进行检查的语言。

以下 Python 代码演示了如何为 PowerPoint 设置校对语言：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # 设置校对语言的 Id

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **设置默认语言**

以下 Python 代码演示了如何为整个 PowerPoint 演示文稿设置默认语言：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # 添加一个带文本的矩形形状
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # 检查第一个段落的语言
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **实时示例**

尝试使用在线应用程序 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh/metadata) 了解如何通过 Aspose.Slides API 处理文档属性：

[![查看和编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/zh/metadata)

## **常见问题**

**如何从演示文稿中移除内建属性？**

内建属性是演示文稿的组成部分，无法完全删除。但是，您可以更改其值，或在特定属性允许的情况下将其设为空。

**如果我添加已存在的自定义属性会怎样？**

如果您添加的自定义属性已存在，其现有值将被新值覆盖。您无需事先删除或检查该属性，因为 Aspose.Slides 会自动更新属性的值。

**我能在不完整加载演示文稿的情况下访问演示文稿属性吗？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 然后调用 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 即可在不创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。有关完整的报告示例和格式特定限制，请参阅 [Build a Lightweight Presentation Inventory](/slides/zh/python-java/examine-presentation/)。

**我能在没有打开密码的情况下读取加密演示文稿的公共属性吗？**

可以。必须在演示文稿加密之前禁用文档属性加密，并且演示文稿需要以仅文档属性模式加载。

**我能在仅文档属性模式下更新加密的 PPTX 文件吗？**

不能。公共属性和加密属性的数据必须保持一致，因此更新加密的 PPTX 文件需要使用正确的打开密码完整加载演示文稿。