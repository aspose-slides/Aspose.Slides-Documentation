---
title: 在 JavaScript 中从演示文稿获取形状有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/nodejs-java/shape-effective-properties/
keywords:
- 形状属性
- 相机属性
- 灯光设备
- 斜角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 在 PowerPoint 演示文稿中区分本地、继承和有效的形状格式化。"
---
## **了解本地、继承和有效属性**

PowerPoint 的格式化可能来自多个来源。直接存储在对象上的值称为其 **本地值**。如果该值未设置，PowerPoint 会查看父级格式化来源，例如段落默认值、文本样式、版面或母版幻灯片、主题或演示文稿级别的默认值。这些值是 **继承值**。在解析完整层级后残留下来的值就是 **有效值**——用于渲染对象的值。

例如，文本段落可能未定义自己的字体高度。其本地[getFontHeight](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portionformat/#getFontHeight) 值为 `NaN`，表示“此处未设置”。该段落可以从其段落、演示文稿的默认文本样式或其他适用来源继承高度。对段落格式调用[getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portionformat/#getEffective) 会返回最终解析后的高度。

针对不同目的使用这两种格式化数据：

- 读取或更改本地格式对象，例如[PortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portionformat/)，当您需要控制值的定义位置时。
- 读取[PortionFormat.getEffective 返回的有效数据](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portionformat/#getEffective)，当您需要最终渲染结果时。有效数据是只读的。

在运行示例之前，请[安装 Aspose.Slides for Node.js via Java](/slides/zh/nodejs-java/installation/)。

## **比较本地、继承和有效值**

下面的完整示例创建一个形状，并在演示文稿、段落和段落（portion）级别应用字体高度。每一步都会打印在这些级别上定义的值以及同一文本段落的结果有效值。它还演示了为何在格式更改后必须重新读取有效数据。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // 读取在前面更改之后的有效数据。
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // 在两个不同层级定义继承值。
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // 本地值覆盖了两个继承值。
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // 更改继承值不会覆盖已存在的本地值。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // 清除本地值。此段落现在再次从段落继承。
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // 清除段落值。演示文稿默认值现在提供结果。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

本示例中的优先级是段落本地格式化，其次是段落格式化，最后是演示文稿默认值。其他对象可能具有不同的继承链，但原则相同：更具体的显式值优先，且[getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portionformat/#getEffective) 返回最终结果。

## **获取有效文本属性**

文本格式化分布在多个对象中：

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframeformat/#getEffective) 解析文本框属性，如边距、锚定、自动适应以及垂直文本方向。
- [TextStyle.getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textstyle/#getEffective) 解析每个文本样式级别的段落格式。
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/#getEffective) 解析段落属性，如对齐、缩进和项目符号。
- [PortionFormat.getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portionformat/#getEffective) 解析字符属性，如字体高度、字体、颜色、粗体和斜体。

对于下一个示例，`text-formatting.pptx` 必须至少包含一张幻灯片和一个带有非空文本框的[AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。AutoShape 可以出现在形状集合中的任意位置；代码会搜索合适的对象并在使用前进行验证。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **获取有效的 3D 属性**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getEffective) 返回一个有效数据对象，汇总所有解析后的 3D 设置。其[getCamera](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getCamera)、[getLightRig](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getLightRig)、[getBevelTop](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getBevelBottom) 方法公开相应的有效数据。一起读取这些相关设置可更易理解形状的最终 3D 外观。

对于本示例，`shape-3d.pptx` 必须在其第一页上至少包含一个形状。如果希望输出包含除默认值之外的值，请对该形状应用 3D 相机、灯光或斜角设置。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **获取有效的表格格式化**

表格格式化可能来源于表格样式，也可能来源于应用于整个表格、列、行或单元格的格式。对于显式定义的填充冲突，优先级为单元格、行、列，然后是整张表。单元格的有效格式即用于绘制该单元格的最终格式。

对于本示例，`table-formatting.pptx` 必须在其第一页上至少包含一个表格。该表格必须至少有一行和一列。代码会搜索[Table](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/table/)，而不是假设 `getShapes().get_Item(0)` 是表格。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

如果需要颜色而不仅仅是填充类型，请先检查有效的[getFillType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fillformat/#getFillType)，然后读取适用于该类型的方法，例如针对纯色填充的[getSolidFillColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fillformat/#getSolidFillColor)。

## **在更改后重新读取有效数据**

有效数据描述解析时的格式层级。更改可能参与该层级的任何内容后，请再次调用 `getEffective`，包括：

- 对象的本地格式；
- 段落或文本框默认值；
- 表格样式、表格、列、行或单元格格式；
- 版面或母版幻灯片的格式；
- 主题数据或演示文稿级别的默认值；
- 分配给幻灯片的版面或母版。

不要将有效数据对象作为永久快照保存。Aspose.Slides 可能在内部缓存部分有效数据，随后调用 `getEffective` 可以刷新这些数据。如果需要比较更改前后的值，请在更改之前将所需的标量值（例如字体高度、颜色、对齐方式或斜角宽度）复制到自己的变量中。

要更改值，请更新相应的本地格式对象，然后调用 `getEffective` 以验证结果。有效数据对象本身是只读的。

## **常见问题**

**如何判断是哪一级提供了有效值？**

有效数据仅包含最终值，而不指示其来源。请从最具体的层级向外检查相应的本地对象。对于文本，这可能包括段落（portion）、段落、文本框、版面、母版、主题以及演示文稿默认值。`NaN` 或 `null` 等未定义值表示搜索将继续到更高层级。

**如果没有任何层级定义属性会怎样？**

Aspose.Slides 将解析相应的 PowerPoint 或库默认值。即使没有本地对象显式定义，该解析后的值仍会出现在有效数据中。

**为什么有效值有时等于本地值？**

本地值在继承计算中获胜。当属性在对象上显式设置且没有更具体的规则覆盖时，出现这种情况是正常的。

**何时应使用本地数据而不是有效数据？**

在检查或编辑特定格式化层级时使用本地数据。在需要继承、主题规则和适用样式解析后的最终外观时使用有效数据。[完整比较示例](#compare-local-inherited-and-effective-values) 在同一工作流中演示了两者的使用。