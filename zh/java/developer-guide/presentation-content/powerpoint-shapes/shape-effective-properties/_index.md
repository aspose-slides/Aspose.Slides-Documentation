---
title: 获取 Java 中演示文稿的形状实际属性
linktitle: 实际属性
type: docs
weight: 50
url: /zh/java/shape-effective-properties/
keywords:
- 形状属性
- 相机属性
- 灯光装置
- 斜角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Java 在 PowerPoint 演示文稿中区分本地、继承和实际的形状格式。"
---
## **理解本地、继承和实际属性**

PowerPoint 的格式可以来源于多个地方。直接存储在对象上的值称为 **本地值**。如果未设置该值，PowerPoint 会查看父级格式来源，如段落默认、文本样式、布局或母版幻灯片、主题或演示文稿级别的默认值。这些值是 **继承值**。在整个层次解析后剩余的值是 **实际值**——用于渲染对象的值。

例如，文本片段可能未定义自己的字体高度。其本地 [getFontHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) 值为 `Float.NaN`，表示“此处未设置”。该片段可以从其段落、演示文稿的默认文本样式或其他适用来源继承高度。对片段格式调用 [getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportionformat/#getEffective--) 将返回最终解析的高度。

针对不同目的使用这两种格式数据：

- 读取或更改本地格式对象，例如 [IPortionFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportionformat/)，当您需要控制值定义的位置时。
- 读取实际数据对象，例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportionformateffectivedata/)，当您需要最终渲染结果时。实际数据是只读的。

## **比较本地、继承和实际值**

下面的完整示例创建一个形状，并在演示文稿、段落和片段级别应用字体高度。每一步都会打印这些级别定义的值以及相同文本片段的实际值。它还演示了为何在格式更改后必须重新读取实际数据。

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // 在两个不同层次上定义继承值。
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // 部分上的本地值会覆盖两个继承值。
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // 更改继承值不会覆盖已存在的本地值。
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // 清除本地值。该部分现在再次从段落继承。
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // 清除段落值。演示文稿默认值现在提供结果。
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // 在前面的更改后读取实际数据。
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

此示例中的优先级是片段本地格式，其次是段落格式，最后是演示文稿默认。其他对象可能有不同的继承链，但原理相同：更具体的显式值优先，并且 [getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportionformat/#getEffective--) 返回最终结果。

## **获取实际文本属性**

文本格式分布在多个对象中：

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#getEffective--) 解析文本框属性，例如边距、锚点、自动适应和垂直文本方向。
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextstyle/#getEffective--) 解析每个文本样式级别的段落格式。
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#getEffective--) 解析段落属性，如对齐、缩进和项目符号。
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportionformat/#getEffective--) 解析字符属性，例如字体高度、字形、颜色、粗体和斜体。

对于下一个示例，`text-formatting.pptx` 必须至少包含一张幻灯片和一个带有非空文本框的 [AutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/autoshape/)。AutoShape 可以位于形状集合的任何位置；代码将在使用前搜索合适的对象并进行验证。

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **获取实际 3D 属性**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getEffective--) 返回一个 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformateffectivedata/) 对象，汇总所有已解析的 3D 设置。其 [getCamera](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--)、[getLightRig](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--)、[getBevelTop](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) 方法公开相应的实际数据。一起读取这些相关设置可更容易理解形状的最终 3D 外观。

对于此示例，`shape-3d.pptx` 必须在其第一张幻灯片上至少包含一个形状。如果希望输出包含非默认值，请对该形状应用 3D 相机、灯光或斜角设置。

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **获取实际表格格式**

表格格式可以来源于表格样式，也可以来源于应用于整个表格、列、行或单元格的格式。对于显式定义的填充冲突，优先级顺序为单元格、行、列，然后是整个表格。单元格的实际格式是用于绘制该单元格的最终格式。

对于此示例，`table-formatting.pptx` 必须在其第一张幻灯片上至少包含一个表格。该表格必须至少有一行和一列。代码会搜索 [ITable](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itable/) ，而不是假设 `getShapes().get_Item(0)` 是表格。

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

如果您需要颜色而不仅是填充类型，请先检查实际的 [getFillType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifillformateffectivedata/#getFillType--)，然后读取适用于该类型的方法，例如对实心填充使用 [getSolidFillColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--)。

## **在更改后重新读取实际数据**

实际数据描述了解析时的格式层次结构。在更改可能参与该层次结构的任何内容后，请再次调用 `getEffective`，包括：

- 对象的本地格式；
- 段落或文本框默认值；
- 表格样式、表格、列、行或单元格格式；
- 布局或母版幻灯片格式；
- 主题数据或演示文稿级别的默认值；
- 分配给幻灯片的布局或母版。

不要将实际数据对象作为永久快照保留。Aspose.Slides 可能在内部缓存部分实际数据，后续的 `getEffective` 调用可以刷新该数据。如果需要比较更改前后的值，请在更改之前将所需的标量值（例如字体高度、颜色、对齐方式或斜角宽度）复制到自己的变量中。

若要更改值，请更新相应的本地格式对象，然后调用 `getEffective` 以验证结果。实际数据对象本身是只读的。

## **常见问题**

**我如何判断是哪一级提供了实际值？**

实际数据仅包含最终值，而不指明其来源。请从最具体的级别向外检查相应的本地对象。对于文本，这可能包括片段、段落、文本框、布局、母版、主题和演示文稿默认值。未定义的值，如 `Float.NaN` 或 `null`，表示搜索会继续到更高一级。

**如果没有任何级别定义属性会怎样？**

Aspose.Slides 会解析相应的 PowerPoint 或库默认值。即使没有本地对象显式定义，该解析后的值也会出现在实际数据中。

**为什么实际值有时等于本地值？**

本地值在继承计算中获胜。当属性在对象上显式设置且没有更具体的规则覆盖时，这种情况是正常的。

**何时应使用本地数据而不是实际数据？**

使用本地数据来检查或编辑特定的格式层级。需要在继承、主题规则和适用样式解析后获得最终外观时，请使用实际数据。 [完整比较示例](#compare-local-inherited-and-effective-values) 在同一工作流中演示了两者的使用。