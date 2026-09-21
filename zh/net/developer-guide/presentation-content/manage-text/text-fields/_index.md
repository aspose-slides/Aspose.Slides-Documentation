---
title: 在 .NET 中管理 PowerPoint 演示文稿的文本字段
linktitle: 文本字段
type: docs
weight: 52
url: /zh/net/text-fields/
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
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中创建、检查、修改和移除文本字段。保留格式并验证已保存的 PPTX 和 PPT 文件。"
---
## **概述**

文本段落由多个部分组成。普通的 [IPortion](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/) 包含字面文本；字段部分还拥有一个 [IField](https://reference.aspose.com/slides/zh/net/aspose.slides/ifield/)，其类型标识自动更新的值，例如幻灯片编号或日期。两个部分可以显示相同的字符，但只有一个包含字段。

使用 [IPortion.Field](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/field/) 来区分它们：普通文本的该属性为 `null`。[IPortion.AddField](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/addfield/) 将现有部分转换为字段。将标签及其动态值放在不同的部分中，以避免在转换值时同时替换标签。

本指南涵盖文本内部的字段、它们的格式以及在 PPTX 和 PPT 中的保存。有关文本框和段落，请参阅 [Manage Text](/slides/zh/net/manage-text/)。

## **创建幻灯片编号字段**

以下完整示例创建一个文本框，其中包含字面 `Slide ` 标签，后跟自动更新的编号。它在添加字段之前设置编号的大小、粗细和颜色，然后重新打开保存的演示文稿并检查字段类型、文本和格式。无需输入文件。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

新演示文稿从幻灯片编号 1 开始，因此文本为 `Slide 1`，两项检查均输出 `True`。重新打开后编号仍保持为字段，而不是字面 `1`。验证中的强制转换和索引指向本示例创建的形状和部分。

## **选择字段类型**

[FieldType](https://reference.aspose.com/slides/zh/net/aspose.slides/fieldtype/) 实现了 [IFieldType](https://reference.aspose.com/slides/zh/net/aspose.slides/ifieldtype/)，并提供以下预定义值。将相应的值传递给 [AddField](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/addfield/)。

| Value | Purpose |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/zh/net/aspose.slides/fieldtype/slidenumber/) | 当前幻灯片编号。 |
| [DateTime](https://reference.aspose.com/slides/zh/net/aspose.slides/fieldtype/datetime/) | 渲染应用程序默认格式的日期/时间。 |
| [DateTime1](https://reference.aspose.com/slides/zh/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/zh/net/aspose.slides/fieldtype/datetime9/) | 预定义的日期或组合日期/时间格式。 |
| [DateTime10](https://reference.aspose.com/slides/zh/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/zh/net/aspose.slides/fieldtype/datetime13/) | 预定义的时间格式，可选秒和 12 小时制。 |
| [Header](https://reference.aspose.com/slides/zh/net/aspose.slides/fieldtype/header/) | 页眉字段；请参阅下文的占位符和格式限制。 |
| [Footer](https://reference.aspose.com/slides/zh/net/aspose.slides/fieldtype/footer/) | 页脚字段。 |

例如，[DateTime3](https://reference.aspose.com/slides/zh/net/aspose.slides/fieldtype/datetime3/) 表示英文的日、完整月份名称和年份。这些是预定义的字段格式，而非任意 .NET 日期格式字符串。部分的 [LanguageId](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/languageid/) 以及处理演示文稿的应用程序都可能影响显示结果。

## **从内部字符串创建字段**

[AddField](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/addfield/) 的字符串重载接受内部字段标识符。当需要保留另一个应用程序提供且没有预定义值的标识符时使用它。您也可以通过该标识符构造一个 [FieldType](https://reference.aspose.com/slides/zh/net/aspose.slides/fieldtype/fieldtype/)。[IFieldType.InternalString](https://reference.aspose.com/slides/zh/net/aspose.slides/ifieldtype/internalstring/) 可公开该标识符供检查。

此示例将应用程序特定的 `custom-report-id` 字段与回退文本 `Report-042` 一起存储。该标识符不会注册计算：Aspose.Slides 不会为未知类型生成报告 ID。必须由了解此标识符的应用程序提供其含义并更新其值。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

经过此 PPTX 循环后，类型为 `custom-report-id`，文本为 `Report-042`。传入诸如 `yyyy-MM-dd` 的字符串会命名一个字段类型；它不会配置自定义日期格式。若需任意格式的固定日期，请使用普通文本。

## **检查、修改和移除日期/时间字段**

通过 [IField.Type](https://reference.aspose.com/slides/zh/net/aspose.slides/ifield/type/) 读取并更改现有字段。在访问其类型之前请检查字段是否存在。要停止自动更新，请调用 [IPortion.RemoveField](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/removefield/)。此操作在移除字段关联的同时保留该部分及其当前文本。如果需要特定的固定值，请在移除字段后分配该文本。

有关日期/时间字段处理的 API 设置，请参阅 [Presentation.CurrentDateTime](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/currentdatetime/)。下面的示例在将字段转换为普通文本时使用了显式的批准日期。

下载 [sample.pptx](sample.pptx) 并放置在工作目录中。它包含两个命名的文本形状 `UpdatedAt` 和 `ApprovedDate`，每个都有日期/时间字段，以及普通文本标签。以下示例遍历普通幻灯片的顶层文本形状。它将日期/时间字段转换为长日期格式并设为斜体，同时保留其他格式。仅 `ApprovedDate` 中的字段会变为固定文本。

示例能够识别内置的内部标识符 `datetime` 以及 `datetime1` 到 `datetime13`。组、表格、备注、版式和母版需要遍历各自的文本容器，超出本示例范围。

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

重新打开后，`UpdatedAt` 的类型为 `datetime3`，仍保持动态。`ApprovedDate` 没有字段，内容为 `05 April 2030`。两个日期部分均为斜体，且其原始字号、加粗设置和颜色保持不变。普通文本标签保持不变。验证读取了提供的示例中两个已知形状的第一段。

## **保留文本格式**

在添加字段、修改其类型或移除时，请使用现有的部分。这些操作会保留该部分的格式。使用 [IPortion.PortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/portionformat/) 仅更改所需属性，示例中对颜色或斜体的处理即如此。

避免为更新单个字段而重建整个文本框：这样可能会丢失原始部分的边界及其各自的格式。同时要区分显式设置的格式和从段落、版式或主题继承的格式。请参阅 [Text Formatting](/slides/zh/net/text-formatting/) 获取更全面的格式选项。

## **字段与页眉/页脚占位符**

字段是文本部分的一部分。占位符是具有演示文稿角色的形状，如页脚或幻灯片编号。将字段添加到普通文本框并不会使该形状变成占位符。

页眉/页脚管理器控制幻灯片、版式和母版上占位符的文本和可见性，并可向依赖的幻灯片传播。因此，即使不使用幻灯片编号占位符，在自定义文本框中使用数字字段也可能有用。相反，修改占位符的可见性并不会移除与之无关的文本框中的字段。

预定义的页眉和页脚类型并不会创建相应的占位符或提供其内容。特别是，普通的 PowerPoint 幻灯片没有页眉占位符；页眉属于备注页和讲义。不要假设任意形状中的页眉或页脚字段会自动获取占位符管理器配置的文本。有关此工作流，请参阅 [Presentation Headers and Footers](/slides/zh/net/presentation-header-and-footer/)。

## **PPTX 和 PPT 限制**

在保存并重新打开后，请检查字段类型及其生成的文本。保留标识符并不证明应用程序能够计算或显示其值。

| Format | Field behavior and limitations |
|---|---|
| PPTX | 在字段文本旁存储内部字段标识符。循环检查中，上述预定义类型和自定义标识符均在保存和重新打开后仍然存在。未知的自定义类型保留其回退文本；未获得自动计算逻辑。其他应用程序可能以不同方式处理不受支持的标识符。 |
| PPT | 使用旧版字段表示，兼容性更受限。循环检查中，幻灯片编号和预定义的日期/时间字段在保存和重新打开后仍然存在。普通幻灯片文本框中的自定义字段在重新打开时保留标识符，但其文本为 `*`；相同上下文中的页眉字段也产生 `*`。不要指望自定义字段或不受支持的字段上下文保留其可见文本。 |

为了获得可移植的固定输出，请在保存前将不受支持的字段转换为普通文本并显式分配所需的值。这样既保留了指定的文本，又有意停止自动更新。当目标应用程序的字段重新计算是工作流的一部分时，也请对其进行测试。

## **常见问题**

**如何判断显示的数字或日期是否为字段？**

检查 [IPortion.Field](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/field/)。非空值表明是字段；仅凭显示的文本无法判断。

**移除字段会同时删除其文本或格式吗？**

不会。[RemoveField](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/removefield/) 将现有部分转换为普通文本。如需特定的冻结日期或回退值，请随后分配显式的值。

**内部字符串能定义新的日期格式或公式吗？**

不能。它仅标识字段类型。未知的标识符既不提供计算器，也不提供 .NET 日期格式模式。请使用受支持的预定义类型，或自行将值格式化为普通文本。

**为什么在保存后再次检查演示文稿？**

字段标识符、计算得到的文本和格式是需要分别验证的内容。即使字段标识符仍在，格式转换也可能改变可见结果。