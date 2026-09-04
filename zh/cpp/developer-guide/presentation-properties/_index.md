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
description: "在 Aspose.Slides for C++ 中掌握演示文稿属性，并在您的 PowerPoint 和 OpenDocument 文件中简化搜索、品牌和工作流。"
---
## **介绍**

Aspose.Slides 支持两种文档属性类型：**内置**和**自定义**。这两种属性类型都可以通过 Aspose.Slides API 轻松访问和管理。

Aspose.Slides 允许您通过 [IDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/) 接口处理演示文稿的文档属性。该接口的实例由 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_documentproperties/) 返回。下面的示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
请注意，您无法为 **Application** 和 **Producer** 字段设置值，因为这些字段会显示 Aspose Ltd. 和 Aspose.Slides for C++ x.x.x。
{{% /alert %}} 

## **管理演示文稿属性**

Microsoft PowerPoint 提供了向演示文稿文件添加属性的功能。这些文档属性允许将一些有用的信息与文档（演示文稿文件）一起存储。文档属性分为以下两类

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置**属性包含关于文档的一般信息，如文档标题、作者姓名、文档统计等。**自定义**属性是用户以 **Name/Value** 对的形式定义的，其中名称和值均由用户自行定义。使用 Aspose.Slides for C++，开发人员可以访问和修改内置属性以及自定义属性的值。Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。只需点击 Office 图标并进一步选择 **Prepare | Properties | Advanced Properties** 菜单项。选择 **Advanced Properties** 后，会出现一个对话框，允许您管理 PowerPoint 文件的文档属性。在 **Properties Dialog** 中，您可以看到诸如 **General、Summary、Statistics、Contents 和 Custom** 等多个选项卡。这些选项卡均可配置与 PowerPoint 文件相关的不同信息。**Custom** 选项卡用于管理 PowerPoint 文件的自定义属性。

## **读取加密演示文稿的公共属性**

打开密码通常会保护演示文稿内容和文档属性。当通过将 `false` 传递给 [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) 对演示文稿进行加密时，其文档属性仍保持为公共的。此时，应用程序可以将 `true` 传递给 [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/)，在不提供打开密码的情况下读取公共元数据。

`set_OnlyLoadDocumentProperties` 控制 Aspose.Slides 加载的内容；它不会进行解密。如果属性已被加密，则在没有密码的情况下加载会失败。如果演示文稿未加密，则该选项被忽略，完整的演示文稿将被加载。

以下示例通过 [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) 验证加载模式，然后通过 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_documentproperties/) 读取内置属性：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

在此模式下，幻灯片内容不会被加载。幻灯片、母版、布局、形状、媒体以及其他演示文稿对象均不可用。应用程序在执行需要完整演示文稿对象模型的操作之前，应始终检查 `get_IsOnlyDocumentPropertiesLoaded`。

{{% alert color="warning" title="Warning" %}}
公共元数据可能泄露作者姓名、标题、主题、关键字、公司信息、注释和自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统有特定需求必须在无密码情况下访问时，才将其保持为公共。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，在调用 `set_OnlyLoadDocumentProperties(true)` 后加载的演示文稿旨在读取公共元数据。Aspose.Slides 无法从仅包含元数据的对象保存已更改的属性，因为公共属性必须与加密演示文稿内部的相应数据保持一致。因此，更新这些属性需要正确的打开密码并完整加载演示文稿。

以下示例使用 [LoadOptions::set_Password](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_password/) 打开演示文稿，更新公共内置属性并保存结果。随后使用 [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) 验证加密仍然保留，并在无密码的情况下重新打开公共元数据以验证新值：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

如果应用程序不被允许解密或加载演示文稿内容，则必须将加密 PPTX 文件的公共属性视为只读。

## **访问内置属性**

这些由 **IDocumentProperties** 对象公开的属性包括：**Creator(Author)**、**Description**、**KeyWords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同制作者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **修改内置属性**

修改演示文稿文件的内置属性与访问它们一样简单。只需为任意所需属性赋予字符串值，即可修改该属性的值。在下面的示例中，我们演示了如何修改演示文稿文件的内置文档属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **添加自定义演示文稿属性**

Aspose.Slides for C++ 也允许开发人员为演示文稿文档属性添加自定义值。下面的示例展示了如何为演示文稿设置自定义属性。

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

// 移除选定的属性
documentProperties->RemoveCustomProperty(getPropertyName);

// 保存演示文稿
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **访问和修改自定义属性**

Aspose.Slides for C++ 还允许开发人员访问自定义属性的值。下面的示例展示了如何访问并修改演示文稿的所有自定义属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **设置校对语言**

Aspose.Slides 提供了由 [PortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/portionformat/) 类公开的 [LanguageId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/baseportionformat/set_languageid/) 属性，允许您为 PowerPoint 文档设置校对语言。校对语言是 PowerPoint 中进行拼写和语法检查的语言。

以下 C++ 代码展示了如何为 PowerPoint 设置校对语言：

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

以下 C++ 代码展示了如何为整个 PowerPoint 演示文稿设置默认语言：

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

// 检查第一个段落的语言
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **实时示例**

尝试在线应用 **Aspose.Slides Metadata**，了解如何通过 Aspose.Slides API 操作文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh/metadata)

## **常见问题**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，无法完全移除。不过，您可以更改其值，或在特定属性允许的情况下将其设为空。

**如果添加已存在的自定义属性会怎样？**

如果添加已存在的自定义属性，其现有值会被新值覆盖。您无需事先删除或检查该属性，Aspose.Slides 会自动更新属性值。

**能否在不完整加载演示文稿的情况下访问演示文稿属性？**

可以。使用 [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) 然后调用 [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/)，即可在不创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。完整示例请参见 [Build a Lightweight Presentation Inventory](/slides/zh/cpp/examine-presentation/)，其中还说明了特定格式的限制。

**能否在不提供打开密码的情况下读取加密演示文稿的公共属性？**

可以。演示文稿必须是通过将 `false` 传递给 `set_EncryptDocumentProperties` 加密的，并且必须通过将 `true` 传递给 `set_OnlyLoadDocumentProperties` 加载。

**能否在仅文档属性模式下更新加密的 PPTX 文件？**

不能。公共属性和加密属性的数据必须保持一致，因此更新加密的 PPTX 文件需要使用正确的打开密码完整加载演示文稿。