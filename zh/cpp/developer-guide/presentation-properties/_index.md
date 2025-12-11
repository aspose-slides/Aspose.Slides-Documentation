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
description: "在 Aspose.Slides for C++ 中精通演示文稿属性，简化 PowerPoint 和 OpenDocument 文件的搜索、品牌化和工作流。"
---

## **访问演示文稿属性**

正如前面所述，Aspose.Slides for C++ 支持两种文档属性，分别是 **内置** 和 **自定义** 属性。因此，开发人员可以使用 Aspose.Slides for C++ API 访问这两种属性。Aspose.Slides for C++ 提供了一个类 [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties)，该类通过 [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) 方法表示与演示文稿文件关联的文档属性。开发人员可以使用 **Presentation** 对象公开的 [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) 方法，按照下面的描述访问演示文稿文件的文档属性：

{{% alert color="primary" %}} 

请注意，您无法为 **Application** 和 **Producer** 字段设置值，因为这些字段将显示 Aspose Ltd. 和 Aspose.Slides for C++ x.x.x 的信息。

{{% /alert %}} 

Microsoft PowerPoint 提供了向演示文稿文件添加属性的功能。这些文档属性允许在文档（演示文稿文件）中存储一些有用的信息。文档属性分为以下两类：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置** 属性包含有关文档的一般信息，如文档标题、作者姓名、文档统计信息等。**自定义** 属性是用户以 **名称/值** 对形式定义的属性，名称和值均由用户自行定义。使用 Aspose.Slides for C++，开发人员可以访问和修改内置属性以及自定义属性的值。Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。只需单击 Office 图标，然后选择 **准备 | 属性 | 高级属性** 菜单项。选择 **高级属性** 后，将出现一个对话框，允许您管理 PowerPoint 文件的文档属性。在 **属性对话框** 中，您可以看到多个选项卡，如 **常规、摘要、统计、内容和自定义**。所有这些选项卡都用于配置与 PowerPoint 文件相关的不同信息。**自定义** 选项卡用于管理 PowerPoint 文件的自定义属性。

## **访问内置属性**

通过 **IDocumentProperties** 对象公开的这些属性包括：**Creator(Author)**、**Description**、**KeyWords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同制作者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **修改内置属性**

修改演示文稿文件的内置属性和访问它们一样简单。只需为任意所需属性赋予字符串值，即可修改该属性的值。下面的示例演示了如何修改演示文稿文件的内置文档属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **添加自定义演示文稿属性**

Aspose.Slides for C++ 也允许开发人员为演示文稿的文档属性添加自定义值。下面的示例展示了如何为演示文稿设置自定义属性。
``` cpp
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

Aspose.Slides for C++ 同样允许开发人员访问自定义属性的值。下面的示例展示了如何访问并修改演示文稿的所有自定义属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **设置校对语言**

Aspose.Slides 提供了 [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) 属性（由 [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) 类公开），允许您为 PowerPoint 文档设置校对语言。校对语言是用于检查 PowerPoint 中拼写和语法的语言。

下面的 C++ 代码展示了如何为 PowerPoint 设置校对语言：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Adds a new rectangle shape with text
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Checks the first portion language
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **在线示例**

尝试使用 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) 在线应用程序，了解如何通过 Aspose.Slides API 操作文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***常见问题**

**如何从演示文稿中删除内置属性？**

内置属性是演示文稿的组成部分，不能完全删除。但您可以更改其值，或在特定属性允许的情况下将其设为空。

**如果添加已存在的自定义属性会怎样？**

如果添加已存在的自定义属性，其现有值会被新值覆盖。无须事先删除或检查属性，Aspose.Slides 会自动更新属性值。

**是否可以在不完全加载演示文稿的情况下访问演示文稿属性？**

可以。您可以使用 [PresentationFactory](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/) 类的 `GetPresentationInfo` 方法访问演示文稿属性，然后利用 [IPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/) 接口提供的 `ReadDocumentProperties` 方法高效读取属性，从而节省内存并提升性能。