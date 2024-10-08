---
title: 演示属性
type: docs
weight: 70
url: /cpp/presentation-properties/
---


## **访问演示属性**
正如我们之前所述，Aspose.Slides for C++ 支持两种类型的文档属性，即 **内置** 和 **自定义** 属性。因此，开发者可以通过使用 Aspose.Slides for C++ API 访问这两种属性。Aspose.Slides for C++ 提供了一个类 [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties)，该类表示与演示文稿文件相关的文档属性，通过 [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) 方法进行访问。开发者可以使用 **Presentation** 对象暴露的 [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) 方法访问演示文稿文件的文档属性，如下所述：

{{% alert color="primary" %}} 

请注意，您无法为 **Application** 和 **Producer** 字段设置值，因为 Aspose Ltd. 和 Aspose.Slides for C++ x.x.x 将显示在这些字段中。

{{% /alert %}} 


Microsoft PowerPoint 提供了一项功能，可以为演示文稿文件添加一些属性。这些文档属性允许在文档（演示文稿文件）中存储一些有用的信息。文档属性分为两种，如下所示：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置** 属性包含有关文档的一般信息，如文档标题、作者姓名、文档统计信息等。**自定义** 属性是用户定义的 **名称/值** 对，其中名称和值均由用户定义。使用 Aspose.Slides for C++，开发者可以访问和修改内置属性以及自定义属性。Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。您只需点击 Office 图标，然后进一步选择 **准备 | 属性 | 高级属性** 菜单项。在选择 **高级属性** 菜单项后，会弹出一个对话框，允许您管理 PowerPoint 文件的文档属性。在 **属性对话框** 中，您可以看到许多选项卡页，如 **常规、摘要、统计、内容和自定义**。所有这些选项卡页允许配置与 PowerPoint 文件相关的不同类型信息。**自定义** 选项卡用于管理 PowerPoint 文件的自定义属性。


## **访问内置属性**
由 **IDocumentProperties** 对象暴露的这些属性包括：**创建者（作者）**、**描述**、**关键字**、**创建时间**（创建日期）、**修改时间**（修改日期）、**打印时间**（最后打印日期）、**最后修改者**、**关键字**、**共享文档**（是否在不同生产者之间共享？）、**演示格式**、**主题** 和 **标题**。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}
## **修改内置属性**
修改演示文件的内置属性与访问它们一样简单。您可以简单地将字符串值分配给任何所需的属性，属性值将被修改。在下面给出的示例中，我们演示了如何修改演示文件的内置文档属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **添加自定义演示属性**
Aspose.Slides for C++ 还允许开发者为演示文档属性添加自定义值。下面给出的示例展示了如何为演示文稿设置自定义属性。

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

// 移除选定属性
documentProperties->RemoveCustomProperty(getPropertyName);

// 保存演示文稿
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **访问和修改自定义演示属性**
Aspose.Slides for C++ 还允许开发者访问自定义属性的值。下面给出的示例展示了如何访问和修改演示文稿的所有这些自定义属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}


## **检查演示文稿是否已修改或创建**
Aspose.Slides for C++ 提供了一种设施来检查演示文稿是否已被修改或创建。下面给出的示例展示了如何检查演示文稿是否被创建或修改。

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"props.pptx");

auto props = info->ReadDocumentProperties();

String app = props->get_NameOfApplication();
String ver = props->get_AppVersion();
```

## **设置校对语言**

Aspose.Slides 提供了 [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) 属性（由 [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) 类暴露），允许您为 PowerPoint 文档设置校对语言。校对语言是进行拼写和语法检查的语言。

以下 C++ 代码展示了如何为 PowerPoint 设置校对语言：

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

以下 C++ 代码展示了如何为整个 PowerPoint 演示文稿设置默认语言：

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// 添加一个带文本的新矩形形状
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"新文本");

// 检查第一个部分的语言
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```