---
title: 在 JavaScript 中管理 PowerPoint 演示文稿的文本字段
linktitle: 文本字段
type: docs
weight: 52
url: /zh/nodejs-java/text-fields/
keywords:
- 文本字段
- 自动文本
- 幻灯片编号
- 日期和时间
- 页眉
- 页脚
- 文本段落
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js（通过 Java）中创建、检查、修改和移除 PowerPoint 演示文稿的文本字段。保留格式并验证已保存的 PPTX 和 PPT 文件。"
---
## **概述**

文本段落由若干 Portion 组成。普通的 [Portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/) 包含字面文本；字段 Portion 还拥有一个 [Field](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/field/)，其类型标识一个自动更新的值，例如幻灯片编号或日期。两个 Portion 可以显示相同的字符，但仅有一个包含字段。

使用 [Portion.getField](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#getField) 来区分它们：普通文本返回 `null`。[Portion.addField](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#addField) 将现有 Portion 转换为字段。将标签和其动态值放在不同的 Portion 中，以免在转换值时也替换标签。

本文档介绍文本内部的字段、字段的格式化以及在 PPTX 和 PPT 中的保存方式。有关文本框和段落的内容，请参阅 [Manage Text](/slides/zh/nodejs-java/manage-text/)。

## **创建幻灯片编号字段**

以下完整示例创建一个文本框，包含字面 `Slide ` 标签，后跟自动更新的编号。它在添加字段之前设置编号的大小、粗细和颜色，然后重新打开已保存的演示文稿并检查字段类型、文本和格式。无需输入文件。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

新演示文稿从幻灯片编号 1 开始，因此文本为 `Slide 1`，两个检查均输出 `true`。重新打开后编号仍是字段，而不是字面 `1`。验证中的索引指的是本示例创建的形状和 Portion。

## **选择字段类型**

[FieldType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/) 提供以下方法用于获取预定义值。将相应的值传递给 [addField](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#addField)。

| 方法 | 目的 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | 当前幻灯片编号。 |
| [getDateTime](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/#getDateTime) | 渲染应用默认格式的日期/时间。 |
| [getDateTime1](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | 预定义的日期或组合日期/时间格式。 |
| [getDateTime10](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | 预定义的时间格式，包含秒和 12 小时制选项。 |
| [getHeader](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/#getHeader) | 页眉字段；请参见下文的占位符和格式限制。 |
| [getFooter](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/#getFooter) | 页脚字段。 |

例如，[getDateTime3](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/#getDateTime3) 表示英文的“日、完整月份名称和年份”。这些是预定义的字段格式，而不是任意的日期格式字符串。通过 [setLanguageId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) 设置的语言以及处理演示文稿的应用程序都可能影响显示结果。

## **从内部字符串创建字段**

[addField](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#addField) 的字符串重载接受内部字段标识符。当需要保留另一个应用程序提供且没有预定义值的标识符时使用它。也可以使用该标识符构造一个 [FieldType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/)。[FieldType.getInternalString](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fieldtype/#getInternalString) 可公开该标识符供检查。

此示例在文本框中存储一个应用程序特定的 `custom-report-id` 字段，回退文本为 `Report-042`。该标识符不会注册计算：Aspose.Slides 不会为未知类型生成报告 ID。必须由能够理解该标识符的应用程序提供其含义并更新其值。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

往返 PPTX 后，类型仍为 `custom-report-id`，文本仍为 `Report-042`。传入类似 `yyyy-MM-dd` 的字符串只会命名一个字段类型，而不会配置自定义日期格式。若需要固定的任意格式日期，请使用普通文本。

## **检查、修改和移除日期/时间字段**

通过 [Field.setType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/field/#setType) 更改已有字段。访问其类型前请先检查字段是否存在。要停止自动更新，调用 [Portion.removeField](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#removeField)。这会保留 Portion 及其当前文本，同时移除字段关联。如果需要特定的固定值，可在移除字段后为其赋值。

有关日期/时间字段处理的 API 设置，请参阅 [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#setCurrentDateTime)。下面的示例在将字段转换为普通文本时使用了显式的批准日期。

下载 [sample.pptx](sample.pptx) 并放置在工作目录中。文件包含两个命名的文本形状 `UpdatedAt` 和 `ApprovedDate`，每个都带有日期/时间字段，以及普通文本标签。以下示例遍历普通幻灯片上的顶层文本形状。它将日期/时间字段改为长日期格式并设为斜体，同时保留其他格式。仅 `ApprovedDate` 中的字段会变为固定文本。

批准日期为 2030 年 4 月 5 日；JavaScript 的月份索引从零开始，所以四月是 `3`。构造和格式化均使用 UTC，以保持日期独立于本地时区。

示例识别了内建的内部标识符 `datetime` 以及 `datetime1` 到 `datetime13`。组、表格、备注、版式和母版需要遍历各自的文本容器，超出本示例范围。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

重新打开后，`UpdatedAt` 的类型为 `datetime3`，仍保持动态。`ApprovedDate` 没有字段，文本为 `05 April 2030`。两个日期 Portion 均为斜体，原始的字号、粗体设置和颜色保持不变。普通文本标签未受影响。验证读取了提供的示例中两个已知形状的第一 Portion。

## **保留文本格式**

在添加字段、修改类型或移除字段时使用已有的 Portion。这些操作会保留该 Portion 的格式。使用 [Portion.getPortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#getPortionFormat) 仅更改必要的属性，示例中即对颜色或斜体进行操作。

避免仅为更新一个字段而重建整个文本框：这样可能会丢失原始 Portion 的边界及其各自的格式。同时要区分显式设置的格式与从段落、版式或主题继承的格式。更多格式化选项请参见 [Text Formatting](/slides/zh/nodejs-java/text-formatting/)。

## **字段与页眉/页脚占位符**

字段是文本 Portion 的一部分。占位符是具有特定演示角色（如页脚或幻灯片编号）的形状。向普通文本框添加字段并不会使该形状成为占位符。

页眉/页脚管理器控制幻灯片、版式和母版上占位符的文本和可见性，并会传播到从属幻灯片。即使不使用幻灯片编号占位符，在自定义文本框中放置数字字段仍可能有用。相反，改变占位符的可见性不会移除与无关文本框中的字段。

预定义的页眉和页脚类型并不会创建相应的占位符或提供其内容。特别是普通 PowerPoint 幻灯片没有页眉占位符；页眉属于备注页和讲义。不要假设任意形状中的页眉或页脚字段会自动获取占位符管理器配置的文本。有关该工作流，请参阅 [Presentation Headers and Footers](/slides/zh/nodejs-java/presentation-header-and-footer/)。

## **PPTX 与 PPT 的限制**

保存并重新打开后，请同时检查字段类型及其实际文本。保留标识符并不意味着应用程序能够计算或显示其值。

| 格式 | 字段行为和限制 |
|---|---|
| PPTX | 在字段文本旁存储内部字段标识符。进行往返检查时，预定义类型和上述使用的自定义标识符都在保存和重新打开后保留。未知的自定义类型保留其回退文本；它没有获得自动计算逻辑。其他应用可能会以不同方式处理不受支持的标识符。 |
| PPT | 使用旧版字段表示，兼容性更受限。往返检查时，幻灯片编号和预定义的日期/时间字段在保存和重新打开后仍然存在。普通幻灯片文本框中的自定义字段在重新打开时仍带有其标识符，但其文本为 `*`；同上下文中的页眉字段也产生 `*`。不要依赖自定义字段或不受支持的字段上下文保留其可见文本。 |

若需可移植、固定的输出，请在保存前将不受支持的字段转换为普通文本并显式赋予所需的值。这样可以保留所选文本，同时有意停止自动更新。若目标应用本身会重新计算字段，请同步进行测试。

## **常见问题**

**如何判断显示的数字或日期是否为字段？**  
检查 [Portion.getField](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#getField)。非空返回值即标识为字段，仅凭显示的文本无法判断。

**移除字段会删除其文本或格式吗？**  
不会。[removeField](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#removeField) 会将现有 Portion 转为普通文本。若需要特定的冻结日期或回退值，可在移除后自行赋值。

**内部字符串可以定义新的日期格式或公式吗？**  
不能。它仅标识字段类型。未知标识符不会提供求值器或日期格式模式。请使用受支持的预定义类型，或自行将值格式化为普通文本。

**为什么在保存后要再次检查演示文稿？**  
字段标识符、计算后的文本和格式是需要单独验证的要素。格式转换甚至在标识符仍在时也可能改变可见结果。