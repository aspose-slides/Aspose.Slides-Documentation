---
title: 在 PowerPoint 演示文稿中通过 Java 使用 Python 管理文本字段
linktitle: 文本字段
type: docs
weight: 52
url: /zh/python-java/text-fields/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中创建、检查、修改和删除文本字段。保留格式并验证已保存的 PPTX 和 PPT 文件。"
---
## **概述**

文本段落由多个片段组成。普通的 [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 包含字面文本；字段片段还拥有一个 [Field](https://reference.aspose.com/slides/zh/python-java/aspose.slides/field/) ，其类型标识一个会自动更新的值，例如幻灯片编号或日期。两个片段可以显示相同的字符，但只有一个包含字段。

使用 [Portion.getField](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#getField) 来区分它们：普通文本返回 `None`。使用 [Portion.addField](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#addField) 可以将现有片段转换为字段。请将标签和其动态值放在不同的片段中，以免在转换值时也替换标签。

本指南涵盖文本内部的字段、字段的格式以及在 PPTX 和 PPT 中的保存方式。有关文本框和段落的更多信息，请参阅 [Manage Text](/slides/zh/python-java/manage-text/)。

## **创建幻灯片编号字段**

以下完整示例创建一个文本框，其中包含字面 `Slide ` 标签，后面跟随自动更新的编号。它在添加字段之前设置编号的大小、粗细和颜色，然后重新打开已保存的演示文稿并检查字段类型、文本和格式。无需输入文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

新演示文稿从幻灯片编号 1 开始，因此文本为 `Slide 1`，两项检查均输出 `True`。重新打开后编号仍然是字段，而不是字面 `1`。验证中使用的索引对应本示例创建的形状和片段。

## **选择字段类型**

[FieldType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/) 提供以下方法以获取预定义值。将相应的值传递给 [addField](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#addField)。

| 方法 | 用途 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/#getSlideNumber) | 当前幻灯片编号。 |
| [getDateTime](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/#getDateTime) | 渲染应用程序默认格式的日期/时间。 |
| [getDateTime1](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/#getDateTime9) | 预定义的日期或组合日期/时间格式。 |
| [getDateTime10](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/#getDateTime13) | 预定义的时间格式，包含秒以及 12 小时制选项。 |
| [getHeader](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/#getHeader) | 标题字段；请参阅下文的占位符和格式限制。 |
| [getFooter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/#getFooter) | 页脚字段。 |

例如，[getDateTime3](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/#getDateTime3) 代表英文的“日、完整月份名称和年份”。这些是预定义的字段格式，而不是任意的 Python 日期格式字符串。使用 [setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setLanguageId) 设置的语言以及处理演示文稿的应用程序都可能影响显示结果。

## **从内部字符串创建字段**

[addField](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#addField) 的字符串重载接受内部字段标识符。当需要保留另一个应用程序提供的标识符且该标识符没有预定义值时使用它。也可以使用该标识符构造一个 [FieldType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/#FieldType)。[FieldType.getInternalString](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fieldtype/#getInternalString) 可用于检查该标识符。

本示例在演示文稿中存储了一个特定于应用程序的 `custom-report-id` 字段，回退文本为 `Report-042`。该标识符不会触发计算：Aspose.Slides 不会为未知类型生成报告 ID。能够识别该标识符的应用程序必须提供其含义并自行更新其值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

经过此 PPTX 循环后，字段类型为 `custom-report-id`，文本为 `Report-042`。如果传入 `yyyy-MM-dd` 之类的字符串，它会被识别为字段类型，而不是配置自定义日期格式。若需要固定日期的任意格式，请使用普通文本。

## **检查、修改和删除日期/时间字段**

通过 [Field.setType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/field/#setType) 更改已有字段。访问字段类型前请先检查字段是否存在。若要停止自动更新，请调用 [Portion.removeField](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#removeField)。此操作会保留片段及其当前文本，同时移除字段关联。如果需要特定的固定值，可在移除字段后将该文本赋给片段。

有关日期/时间字段处理的 API 设置，请参阅 [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#setCurrentDateTime)。下面的示例在将字段转换为普通文本时使用了显式的批准日期。

下载 [sample.pptx](sample.pptx) 并放置在工作目录中。该文件包含两个命名的文本形状，`UpdatedAt` 和 `ApprovedDate`，每个形状内部都有日期/时间字段以及普通文本标签。以下示例遍历普通幻灯片的顶层文本形状。它将日期/时间字段改为长日期格式并设为斜体，同时保留其它格式。只有 `ApprovedDate` 中的字段会被固定为文本。

示例识别内置的内部标识符 `datetime` 以及 `datetime1` 到 `datetime13`。组、表格、备注、版式和母版需要遍历各自的文本容器，超出本示例范围。

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # 使用英文月份名称，不受系统语言环境影响。
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

重新打开后，`UpdatedAt` 的类型为 `datetime3`，仍保持动态。`ApprovedDate` 没有字段，文本为 `05 April 2030`。两个日期片段均为斜体，原始的字体大小、粗体设置和颜色保持不变。普通文本标签未受影响。验证读取了提供样本中两已知形状的第一片段。

## **保留文本格式**

在添加字段、修改字段类型或移除字段时，使用已有片段。此类操作会保留该片段的格式。使用 [Portion.getPortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#getPortionFormat) 只更改所需属性，如示例中对颜色或斜体的更改。

避免为了更新单个字段而重新构建整个文本框：这样可能丢失原始片段边界及其各自的格式。同时要区分显式设置的格式与从段落、版式或主题继承的格式。有关更广泛的格式选项，请参阅 [Text Formatting](/slides/zh/python-java/text-formatting/)。

## **字段与页眉/页脚占位符**

字段是文本片段的一部分。占位符是具有演示文稿角色（例如页脚或幻灯片编号）的形状。向普通文本框添加字段不会将该形状转换为占位符。

页眉/页脚管理器控制占位符文本以及在幻灯片、版式和母版上的可见性，并会传播到依赖幻灯片。自定义文本框中的编号字段在未使用幻灯片编号占位符时仍可能有用。相反，修改占位符的可见性并不会从无关的文本框中移除字段。

预定义的页眉和页脚类型不会创建相应的占位符或提供其内容。尤其是，普通 PowerPoint 幻灯片没有页眉占位符；页眉属于备注页和讲义页。不要假设任意形状中的页眉或页脚字段会自动获取占位符管理器配置的文本。有关此工作流，请参阅 [Presentation Headers and Footers](/slides/zh/python-java/presentation-header-and-footer/)。

## **PPTX 与 PPT 限制**

保存并重新打开后，请同时检查字段类型及其生成的文本。保留标识符并不意味着应用程序能够计算或显示其值。

| 格式 | 字段行为和限制 |
|---|---|
| PPTX | 在字段文本旁存储内部字段标识符。循环检查时，预定义类型以及上文使用的自定义标识符均能在保存和重新打开后保留。未知的自定义类型保留其回退文本；不会获得自动计算逻辑。其他应用程序可能会以不同方式处理不受支持的标识符。 |
| PPT | 使用旧版字段表示，兼容性更受限制。循环检查时，幻灯片编号和预定义日期/时间字段能够在保存和重新打开后保留。普通幻灯片文本框中的自定义字段重新打开时保留标识符，但文本为 `*`；同上下文的页眉字段也产生 `*`。不要依赖自定义字段或不受支持的字段上下文保留可见文本。 |

若需可移植的固定输出，请在保存前将不受支持的字段转换为普通文本并显式赋值。这会保留所选文本，但会有意停止自动更新。若目标应用程序本身会重新计算字段，也请对其进行测试。

## **常见问题**

**如何判断显示的数字或日期是否为字段？**

检查 [Portion.getField](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#getField)。返回值非 `None` 即表明是字段；仅凭显示的文本无法判断。

**移除字段会同时移除其文本或格式吗？**

不会。[removeField](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#removeField) 将现有片段转换为普通文本。若需要特定的冻结日期或回退值，请在之后显式赋值。

**内部字符串能定义新的日期格式或公式吗？**

不能。它仅标识字段类型。未知标识符不提供计算器或 Python 日期格式模式。请使用受支持的预定义类型，或自行将值格式化为普通文本。

**为什么在保存后要再次检查演示文稿？**

字段标识符、计算后的文本以及格式是需要分别验证的独立要素。格式转换可能会改变可见结果，即使字段标识符仍然存在。