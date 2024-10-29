---
title: 演示文稿属性
type: docs
weight: 70
url: /zh/python-net/presentation-properties/
keywords: "PowerPoint 属性, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "Python 中的 PowerPoint 演示文稿属性"
---


## **实时示例**
尝试 [**Aspose.Slides 元数据**](https://products.aspose.app/slides/metadata) 在线应用程序，查看如何通过 Aspose.Slides API 操作文档属性：

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **关于演示文稿属性**
正如我们之前所述，Aspose.Slides for Python via .NET 支持两种文档属性，即 **内置** 和 **自定义** 属性。因此，开发人员可以使用 Aspose.Slides for Python via .NET API 访问这两种属性。Aspose.Slides for Python via .NET 提供了一个类 [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/)，表示与演示文稿文件相关联的文档属性，通过 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 属性。开发人员可以使用 **Presentation** 对象公开的 [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) 属性来访问演示文稿文件的文档属性，如下所述：



{{% alert color="primary" %}} 

请注意，您无法设置 **Application** 和 **Producer** 字段的值，因为这些字段将显示 Aspose Ltd. 和 Aspose.Slides for Python via .NET x.x.x。

{{% /alert %}} 


## **管理演示文稿属性**
Microsoft PowerPoint 提供了一项功能，可以向演示文稿文件添加一些属性。这些文档属性允许在文档（演示文稿文件）中存储一些有用的信息。文档属性分为两种，如下所示：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置** 属性包含有关文档的一般信息，如文档标题、作者姓名、文档统计数据等。**自定义** 属性是用户定义的**名称/值**对，其中名称和值均由用户定义。使用 Aspose.Slides for Python via .NET，开发人员可以访问和修改内置属性及自定义属性的值。Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。您只需单击 Office 图标，然后进一步选择 **准备 | 属性 | 高级属性** 菜单项。选择 **高级属性** 菜单项后，会弹出一个对话框，您可以在其中管理 PowerPoint 文件的文档属性。在 **属性对话框** 中，您可以看到许多选项卡页面，如 **常规、摘要、统计、内容和自定义**。所有这些选项卡页面允许配置与 PowerPoint 文件相关的不同类型的信息。**自定义** 选项卡用于管理 PowerPoint 文件的自定义属性。
## **访问内置属性**
这些属性由 **IDocumentProperties** 对象公开，包括：**Creator(作者)**、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最后打印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同的生产者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**
```py
import aspose.slides as slides

# 实例化表示演示文稿的 Presentation 类
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # 创建与演示文稿相关的对象引用
    documentProperties = pres.document_properties

    # 显示内置属性
    print("类别 : " + documentProperties.category)
    print("当前状态 : " + documentProperties.content_status)
    print("创建日期 : " + str(documentProperties.created_time))
    print("作者 : " + documentProperties.author)
    print("描述 : " + documentProperties.comments)
    print("关键词 : " + documentProperties.keywords)
    print("最后修改者 : " + documentProperties.last_saved_by)
    print("主管 : " + documentProperties.manager)
    print("修改日期 : " + str(documentProperties.last_saved_time))
    print("演示文稿格式 : " + documentProperties.presentation_format)
    print("最后打印日期 : " + str(documentProperties.last_printed))
    print("是否在生产者之间共享 : " + str(documentProperties.shared_doc))
    print("主题 : " + documentProperties.subject)
    print("标题 : " + documentProperties.title)
```
## **修改内置属性**
修改演示文稿文件的内置属性与访问它们一样简单。您只需将字符串值分配给任何所需的属性，该属性值将被修改。在下面给出的示例中，我们演示了如何修改演示文稿文件的内置文档属性。

```py
import aspose.slides as slides

# 实例化表示演示文稿的 Presentation 类
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # 创建与演示文稿相关的对象引用
    documentProperties = presentation.document_properties

    # 设置内置属性
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "修改演示文稿属性"
    documentProperties.subject = "Aspose 主题"
    documentProperties.comments = "Aspose 描述"
    documentProperties.manager = "Aspose 经理"

    # 将演示文稿保存到文件
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **添加自定义演示文稿属性**
Aspose.Slides for Python via .NET 还允许开发人员为演示文稿文档属性添加自定义值。下面给出了一个示例，显示如何为演示文稿设置自定义属性。

```py
import aspose.slides as slides

# 实例化演示文稿类
with slides.Presentation() as presentation:
    # 获取文档属性
    documentProperties = presentation.document_properties

    # 添加自定义属性
    documentProperties.set_custom_property_value("新自定义", 12)
    documentProperties.set_custom_property_value("我的名字", "Mudassir")
    documentProperties.set_custom_property_value("自定义", 124)

    # 获取特定索引处的属性名称
    getPropertyName = documentProperties.get_custom_property_name(2)

    # 移除所选属性
    documentProperties.remove_custom_property(getPropertyName)

    # 保存演示文稿
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **访问和修改自定义属性**
Aspose.Slides for Python via .NET 还允许开发人员访问自定义属性的值。下面有一个示例，展示了如何访问和修改演示文稿的所有这些自定义属性。

```py
import aspose.slides as slides

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # 创建与演示文稿相关的 document_properties 对象引用
    documentProperties = presentation.document_properties

    # 访问和修改自定义属性
    for i in range(documentProperties.count_of_custom_properties):
        # 显示自定义属性的名称和值
        print("自定义属性名称 : " + documentProperties.get_custom_property_name(i))
        print("自定义属性值 : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # 修改自定义属性的值
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "新值 " + str(i + 1))
    # 将演示文稿保存到文件
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **检查演示文稿是否已修改或创建**
Aspose.Slides for Python via .NET 提供了一种检查演示文稿是否已修改或创建的功能。下面给出了一个示例，展示了如何检查演示文稿是否已创建或修改。

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info(path + "AccessModifyingProperties.pptx")
props = info.read_document_properties()

print(props.name_of_application)
print(props.app_version)
```

## **设置校对语言**

Aspose.Slides 提供了 `Language_Id` 属性（由 [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) 类公开），允许您为 PowerPoint 文档设置校对语言。校对语言是检查 PowerPoint 中拼写和语法的语言。

以下 Python 代码展示了如何为 PowerPoint 设置校对语言：

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

以下 Python 代码展示了如何为整个 PowerPoint 演示文稿设置默认语言：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "新文本"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```