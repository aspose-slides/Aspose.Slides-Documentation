---
title: 在 Python 中管理 PowerPoint 演示文稿的文本字段
linktitle: 文本字段
type: docs
weight: 52
url: /zh/python-net/text-fields/
keywords:
- 文本字段
- 自动文本
- 幻灯片编号
- 日期和时间
- 页眉
- 页脚
- 文本片段
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: 使用 Aspose.Slides for Python（基于 .NET）在 PowerPoint 演示文稿中创建、检查、修改和删除文本字段。保留格式并验证保存的 PPTX 和 PPT 文件。
---
## **概述**

文本段落由若干 Portion 组成。普通的[Portion](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/)只包含文字；字段 Portion 还拥有一个[Field](https://reference.aspose.com/slides/zh/python-net/aspose.slides/field/)，其类型标识一个会自动更新的值，例如幻灯片编号或日期。两个 Portion 可以显示相同的字符，但只有一个包含字段。

使用[Portion.field](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/field/)进行区分：普通文本为`None`。[Portion.add_field](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/add_field/)可将已有 Portion 转换为字段。请将标签和其动态值放在不同的 Portion 中，这样在转换值时不会同时替换标签。

本指南涵盖文本中的字段、字段的格式以及在 PPTX 和 PPT 中的保存方式。有关文本框和段落的操作，请参阅[Manage Text](/slides/zh/python-net/manage-text/)。

## **创建幻灯片编号字段**

下面的完整示例创建一个文本框，包含文字标签`Slide `，后面跟随自动更新的数字。示例在添加字段之前设置数字的大小、粗细和颜色，然后重新打开保存的演示文稿并检查字段类型、文本及格式。无需输入文件。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

新演示文稿的起始幻灯片编号为 1，因而文本为`Slide 1`，两个检查都返回`True`。重新打开后，该数字仍为字段，而非文字`1`。验证中使用的索引对应本示例创建的形状和 Portion。

## **选择字段类型**

[FieldType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/)提供以下预定义值。将适当的值传递给[add_field](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/add_field/)。

| 值 | 用途 |
|---|---|
| [slide_number](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/slide_number/) | 当前幻灯片编号。 |
| [date_time](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/date_time/) | 渲染应用程序默认格式的日期/时间。 |
| [date_time1](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/date_time9/) | 预定义的日期或组合日期/时间格式。 |
| [date_time10](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/date_time13/) | 预定义的时间格式，包含秒和 12 小时制选项。 |
| [header](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/header/) | 页眉字段；请参阅下文的占位符和格式限制。 |
| [footer](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/footer/) | 页脚字段。 |

例如，[date_time3](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/date_time3/)表示英文的“日、完整月份名称和年份”。这些是预定义的字段格式，而不是任意的 Python 日期格式字符串。Portion 的[language_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/language_id/)以及处理演示文稿的应用程序都可能影响实际显示结果。

## **从内部字符串创建字段**

[add_field](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/add_field/)的字符串重载接受内部字段标识符。当需要保留其他应用程序提供的标识符且没有预定义值时使用它。也可以通过标识符构造一个[FieldType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/__init__)。[FieldType.internal_string](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fieldtype/internal_string/)可用于检查该标识符。

本示例在文本中存储了一个应用程序特定的 `custom-report-id` 字段，回退文字为 `Report-042`。该标识符不会触发计算：Aspose.Slides 不会为未知类型生成报告 ID。必须由能够识别该标识符的应用程序提供其含义并更新其值。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

完成 PPTX 循环后，字段类型为 `custom-report-id`，文本为 `Report-042`。如果传入类似 `%Y-%m-%d` 的字符串，只会创建一个字段类型，而不会配置自定义日期格式。若需固定日期的任意格式，请使用普通文字。

## **检查、修改和删除日期/时间字段**

通过[Field.type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/field/type/)读取并修改现有字段。访问类型前请先确认字段存在。若要停止自动更新，请调用[Portion.remove_field](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/remove_field/)。该方法保留 Portion 及其当前文字，同时移除字段关联；若需要特定的固定值，可在移除字段后自行赋值。

有关日期/时间字段处理的 API 设置，请参见[Presentation.current_date_time](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/current_date_time/)。下面的示例在将字段转换为普通文字时使用了显式的批准日期。英文月份元组使固定日期不受系统区域设置影响。

下载 [sample.pptx](sample.pptx) 并放置在工作目录中。该文件包含两个已命名的文本形状 `UpdatedAt` 和 `ApprovedDate`，每个都带有日期/时间字段，以及普通文字标签。示例遍历普通幻灯片的顶层文本形状，将日期/时间字段转换为长日期格式并设为斜体，同时保留其它格式。仅 `ApprovedDate` 中的字段会变为固定文字。

示例识别内置的内部标识符 `datetime` 和 `datetime1` 到 `datetime13`。组、表格、备注、版式和母版需要遍历各自的文本容器，超出本示例范围。

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

重新打开后，`UpdatedAt` 的类型为 `datetime3`，仍保持动态。`ApprovedDate` 没有字段，文本为 `05 April 2030`。两个日期 Portion 均为斜体，原始字体大小、粗体设置和颜色保持不变。普通文字标签未受影响。验证读取了示例中两个已知形状的第一 Portion。

## **保留文本格式**

在添加、修改或删除字段时，请对已有 Portion 进行操作。这些操作会保留该 Portion 的格式。使用[Portion.portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/portion_format/)仅更改所需属性，如示例中对颜色或斜体的处理。

避免为更新单个字段而重建整个文本框：这样可能丢失原有 Portion 的边界及其各自的格式。还需区分显式设置的格式与从段落、版式或主题继承的格式。更多格式选项请参阅[Text Formatting](/slides/zh/python-net/text-formatting/)。

## **字段与页眉/页脚占位符**

字段是文本 Portion 的一部分。占位符是具有演示文稿角色的形状，例如页脚或幻灯片编号。向普通文本框添加字段不会使该形状变成占位符。

页眉/页脚管理器控制占位符文本及其在幻灯片、版式和母版上的可见性，并可向依赖幻灯片传播。自定义文本框中的编号字段在未使用幻灯片编号占位符时仍然有用。相反，更改占位符的可见性不会移除与无关文本框中的字段。

预定义的页眉和页脚类型不会创建相应的占位符，也不会提供其内容。特别是，普通 PowerPoint 幻灯片没有页眉占位符；页眉属于备注页和讲义。不要以为在任意形状中的页眉或页脚字段会自动获取占位符管理器配置的文本。有关此工作流，请参阅[Presentation Headers and Footers](/slides/zh/python-net/presentation-header-and-footer/)。

## **PPTX 与 PPT 的限制**

保存并重新打开后，请检查字段类型及其生成的文字。保留标识符并不意味着应用程序能够计算或显示其值。

| 格式 | 字段行为与限制 |
|---|---|
| PPTX | 将内部字段标识符与字段文字一起保存。在往返检查中，预定义类型和上述自定义标识符均能在保存和重新打开后保留。未知的自定义类型保留回退文字；不会获得自动计算逻辑。其他应用程序可能会以不同方式处理不受支持的标识符。 |
| PPT | 使用旧版字段表示，兼容性更受限制。在往返检查中，幻灯片编号和预定义日期/时间字段能够保存并重新打开。普通幻灯片文本框中的自定义字段重新打开时仍带有标识符，但文字为 `*`；同上下文的页眉字段也产生 `*`。不要依赖自定义字段或不受支持的字段上下文保留其可见文字。 |

若需可移植的固定输出，请在保存前将不受支持的字段转换为普通文字并显式赋值。这会保留所选文字，但会有意停止自动更新。若目标应用程序本身会重新计算字段，也请进行相应测试。

## **常见问题**

**如何判断显示的数字或日期是否为字段？**

检查[Portion.field](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/field/)。只要返回值不是`None`，即表明该 Portion 是字段；仅凭显示的文字无法判断。

**移除字段会同时移除其文字或格式吗？**

不会。[remove_field](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/remove_field/)会将现有 Portion 转换为普通文字。若需特定的冻结日期或回退文字，可在移除后自行赋值。

**内部字符串能定义新的日期格式或公式吗？**

不能。它仅标识字段类型。未知标识符不会提供求值器或 Python 日期格式模式。请使用受支持的预定义类型，或自行将值格式化为普通文字。

**为什么在保存后要再次检查演示文稿？**

字段标识符、计算后的文字以及格式是需要分别验证的独立要素。即使字段标识符仍在，格式转换也可能改变可见结果。