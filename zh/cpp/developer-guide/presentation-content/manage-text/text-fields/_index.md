---
title: 在 C++ 中管理 PowerPoint 演示文稿的文本字段
linktitle: 文本字段
type: docs
weight: 52
url: /zh/cpp/text-fields/
keywords:
- 文本字段
- 自动文本
- 幻灯片编号
- 日期和时间
- 页眉
- 页脚
- 文本部分
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中创建、检查、修改和删除文本字段。保留格式并检查已保存的 PPTX 和 PPT 文件。"
---
## **概述**

文本段落由多个部分组成。普通的[IPortion](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/)包含文字文本；字段部分还拥有一个[IField](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifield/)，其类型标识一个自动更新的值，例如幻灯片编号或日期。两个部分可以显示相同的字符，但只有其中一个包含字段。

使用[IPortion::get_Field](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/get_field/)来区分它们：普通文本返回`nullptr`。[IPortion::AddField](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/addfield/)将现有部分转换为字段。请将标签及其动态值放在不同的部分中，以避免在转换值时同时替换标签。

本指南介绍文本中的字段、其格式以及在 PPTX 和 PPT 中保存的方法。有关文本框和段落，请参阅[Manage Text](/slides/zh/cpp/manage-text/)。

## **创建幻灯片编号字段**

下面的示例创建一个文本框，其中包含文字 `Slide ` 标签，后跟自动更新的编号。它在添加字段之前设置编号的大小、粗细和颜色，然后重新打开已保存的演示文稿并检查字段类型、文本和格式。无需输入文件。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

新演示文稿从幻灯片编号 1 开始，因此预期文本为`Slide 1`，两项检查都应输出`True`。重新打开后该编号仍是字段，而不是文字`1`。验证中的强制转换和索引指向本示例创建的形状和部分。

## **选择字段类型**

[FieldType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fieldtype/)实现了[IFieldType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifieldtype/)，并提供以下预定义值。将相应的值传递给[AddField](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/addfield/)。

| 访问器 | 目的 |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fieldtype/get_slidenumber/) | 当前幻灯片编号。 |
| [get_DateTime](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fieldtype/get_datetime/) | 在渲染应用程序的默认格式下的日期/时间。 |
| [get_DateTime1](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fieldtype/get_datetime9/) | 预定义的日期或组合日期/时间格式。 |
| [get_DateTime10](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fieldtype/get_datetime13/) | 预定义的时间格式，可选择秒和 12 小时制。 |
| [get_Header](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fieldtype/get_header/) | 页眉字段；请参阅下面的占位符和格式限制。 |
| [get_Footer](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fieldtype/get_footer/) | 页脚字段。 |

例如，[get_DateTime3](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fieldtype/get_datetime3/)提供英文的日期、完整月份名称和年份。这些是预定义的字段格式，而非任意的日期格式字符串。使用[IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_languageid/)设置的部分语言以及处理演示文稿的应用程序都可能影响显示结果。

## **从内部字符串创建字段**

[AddField](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/addfield/)的字符串重载接受内部字段标识符。当需要保留另一个应用程序提供且没有预定义值的标识符时使用它。您也可以使用该标识符构造[FieldType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fieldtype/fieldtype/)。[IFieldType::get_InternalString](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifieldtype/get_internalstring/)公开该标识符以供检查。

本示例存储了一个应用程序特定的 `custom-report-id` 字段，后备文本为 `Report-042`。无需输入文件。该标识符不会注册计算：Aspose.Slides 不会为未知类型生成报告 ID。能够理解此标识符的应用程序必须提供其含义并更新其值。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

经过此 PPTX 往返后，预期类型为 `custom-report-id`，预期文本为 `Report-042`。传入类似 `yyyy-MM-dd` 的字符串会命名一个字段类型；它不会配置自定义日期格式。若需任意格式的固定日期，请使用普通文本。

## **检查、修改和删除日期/时间字段**

通过[IField::get_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifield/get_type/)读取现有字段类型，并通过[IField::set_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifield/set_type/)更改它。访问其类型前请先检查字段是否存在。要停止自动更新，请调用[IPortion::RemoveField](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/removefield/)。此操作保留该部分及其当前文本，同时移除字段关联。如果需要特定的固定值，请在删除字段后分配该文本。

有关日期/时间字段处理的 API 设置，请参阅[Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/set_currentdatetime/)。下面的示例在将字段转换为普通文本时使用明确的批准日期。

下载 [sample.pptx](sample.pptx) 并放置在工作目录中。它包含两个命名的文本形状，`UpdatedAt` 和 `ApprovedDate`，每个都有日期/时间字段，以及普通文本标签。下面的示例遍历常规幻灯片的顶层文本形状。它将日期/时间字段更改为长日期格式并设为斜体，同时保留其他格式。仅 `ApprovedDate` 中的字段会变为固定文本。

示例识别内置的内部标识符 `datetime` 以及 `datetime1` 至 `datetime13`。组、表格、备注、布局和母版需要遍历各自的文本容器，超出本示例范围。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

重新打开后，`UpdatedAt` 应具有类型 `datetime3` 并保持动态。`ApprovedDate` 应没有字段且内容为 `05 April 2030`。两个日期部分均为斜体，且原始的字体大小、粗体设置和颜色保持不变。普通文本标签保持不变。验证读取了提供的示例中这两个已知形状的第一部分。

## **保留文本格式**

在添加字段、修改其类型或删除字段时，请使用现有的部分。这些操作会保留该部分的格式。使用[IPortion::get_PortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/get_portionformat/)仅更改所需属性，正如示例中对颜色或斜体的处理。

避免仅为更新单个字段而重建整个文本框：这样可能会丢失原始部分的边界及其各自的格式。还要区分显式设置的格式和从段落、布局或主题继承的格式。请参阅[Text Formatting](/slides/zh/cpp/text-formatting/)了解更广泛的格式选项。

## **字段与页眉/页脚占位符**

字段是文本部分的一部分。占位符是具有演示角色的形状，例如页脚或幻灯片编号。向普通文本框添加字段不会使该形状变成占位符。

页眉/页脚管理器控制幻灯片、布局和母版上占位符的文本和可见性，并会传播到从属幻灯片。因此，即使不使用幻灯片编号占位符，在自定义文本框中使用数字字段仍然有用。相反，修改占位符的可见性不会删除与其无关的文本框中的字段。

预定义的页眉和页脚类型不会创建相应的占位符或提供其内容。特别是，普通的 PowerPoint 幻灯片没有页眉占位符；页眉属于备注页和讲义页。不要假设任意形状中的页眉或页脚字段会自动获取通过占位符管理器配置的文本。有关此工作流，请参阅[Presentation Headers and Footers](/slides/zh/cpp/presentation-header-and-footer/)。

## **PPTX 与 PPT 限制**

保存并重新打开后，需要检查字段类型及其生成的文本。保留标识符并不能证明应用程序能够计算或显示其值。

| 格式 | 字段行为和限制 |
|---|---|
| PPTX | 存储内部字段标识符及其字段文本。使用上述示例在保存并重新打开后检查预定义类型和自定义标识符。未知的自定义类型不会获得自动计算逻辑。其他应用程序可能会以不同方式处理不受支持的标识符。 |
| PPT | 使用传统的字段表示，兼容性更受限。幻灯片编号和预定义日期/时间字段采用传统表示。不受支持的自定义字段或普通幻灯片文本框中的页眉字段可能显示为 `*`。不要依赖自定义字段或不受支持的字段上下文保留其可见文本。 |

若需可移植的固定输出，请在保存前将不受支持的字段转换为普通文本并显式赋予所需值。这会保留所选文本，但有意停止自动更新。当目标应用程序自身的字段重新计算是工作流的一部分时，也请进行测试。

## **常见问题**

**如何判断显示的数字或日期是否为字段？**

检查[IPortion::get_Field](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/get_field/)。非空值表明是字段，仅凭显示的文本无法判断。

**删除字段会删除其文本或格式吗？**

不会。[RemoveField](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/removefield/)将现有部分转换为普通文本。如果需要特定的冻结日期或后备值，请随后分配显式值。

**内部字符串能定义新的日期格式或公式吗？**

不能。它仅标识字段类型。未知标识符不提供求值器或日期格式模式。请使用受支持的预定义类型或自行将值格式化为普通文本。

**为什么在保存后再次检查演示文稿？**

字段标识符、计算得到的文本和格式是需要分别验证的内容。格式转换可能会改变可见结果，即使字段标识符仍在。