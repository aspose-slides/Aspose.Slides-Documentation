---
title: 在 C++ 中管理演示文稿属性
linktitle: 演示文稿属性
type: docs
weight: 70
url: /zh/cpp/presentation-properties/
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
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中掌握演示文稿属性，并在您的 PowerPoint 和 OpenDocument 文件中简化搜索、品牌化和工作流。"
---
## **介绍**

Aspose.Slides 支持两种文档属性类型：**内置**和**自定义**。这两种属性类型都可以通过 Aspose.Slides API 轻松访问和管理。

Aspose.Slides 允许您通过 [IDocumentProperties](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_document_properties) 接口处理演示文稿的文档属性。该接口的实例由 [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_documentproperties/) 方法返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
请注意，您无法对 **Application** 和 **Producer** 字段设置值，因为这些字段将显示 Aspose Ltd. 和 Aspose.Slides for C++ x.x.x 的信息。
{{% /alert %}} 

## **管理演示文稿属性**

Microsoft PowerPoint 提供了向演示文稿文件添加属性的功能。这些文档属性允许将一些有用的信息与文档（演示文稿文件）一起存储。文档属性分为以下两类

- 系统定义（内置）属性
- 用户自定义（自定义）属性

**Built-in** 属性包含有关文档的一般信息，例如文档标题、作者姓名、文档统计等。**Custom** 属性是用户以 **Name/Value** 键值对形式定义的属性，其中名称和值均由用户定义。使用 Aspose.Slides for C++，开发人员可以访问和修改内置属性以及自定义属性的值。Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。您只需点击 Office 图标，然后在 Microsoft PowerPoint 2007 中选择 **Prepare | Properties | Advanced Properties** 菜单项。选择 **Advanced Properties** 菜单项后，会出现一个对话框，允许您管理 PowerPoint 文件的文档属性。在 **Properties Dialog** 中，您可以看到诸如 **General, Summary, Statistics, Contents and Custom** 等多个选项卡。这些选项卡都可以配置与 PowerPoint 文件相关的不同信息。**Custom** 选项卡用于管理 PowerPoint 文件的自定义属性。

## **访问内置属性**

这些属性由 **IDocumentProperties** 对象提供，包括：**Creator(Author)**、**Description**、**KeyWords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同的制作者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **修改内置属性**

修改演示文稿文件的内置属性与访问它们同样简便。您只需为任意所需属性分配字符串值，即可修改属性值。在下面的示例中，我们演示了如何修改演示文稿文件的内置文档属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **添加自定义演示文稿属性**

Aspose.Slides for C++ 还允许开发人员为演示文稿的文档属性添加自定义值。下面的示例展示了如何为演示文稿设置自定义属性。

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 实例化 Presentation 类
auto presentation = System::MakeObject<Presentation>();

// 获取文档属性
auto documentProperties = presentation->get_DocumentProperties();

// 添加自定义属性
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// 获取特定索引处的属性名称
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// 删除选定的属性
documentProperties->RemoveCustomProperty(getPropertyName);

// 保存演示文稿
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **访问和修改自定义属性**

Aspose.Slides for C++ 还允许开发人员访问自定义属性的值。下面的示例展示了如何访问和修改演示文稿的所有自定义属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **设置校对语言**

Aspose.Slides 提供了 [LanguageId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/baseportionformat/set_languageid/) 属性（由 [PortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/portionformat/) 类公开），以允许您为 PowerPoint 文档设置校对语言。校对语言是 PowerPoint 检查拼写和语法的语言。

下面的 C++ 代码展示了如何为 PowerPoint 设置校对语言：

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// 设置校对语言的 ID

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **设置默认语言**

下面的 C++ 代码展示了如何为整个 PowerPoint 演示文稿设置默认语言：

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// 添加一个带文本的新矩形形状
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// 检查第一个文本块的语言
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **实时示例**

尝试在线应用程序 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh/metadata) 以了解如何通过 Aspose.Slides API 处理文档属性：

[![查看并编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/zh/metadata)

## **常见问题**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，不能完全删除。不过，您可以更改其值，或在该属性允许的情况下将其设为空。

**如果添加已存在的自定义属性会怎样？**

如果添加的自定义属性已存在，其原有值将被新值覆盖。您无需事先删除或检查属性，Aspose.Slides 会自动更新属性值。

**是否可以在不完整加载演示文稿的情况下访问演示文稿属性？**

可以。使用 [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) 然后使用 [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 来在不创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。完整的报告示例及格式特定限制请参见 [Build a Lightweight Presentation Inventory](/slides/zh/cpp/examine-presentation/)。