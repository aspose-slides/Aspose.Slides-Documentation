---
title: Get Shape Effective Properties from Presentations on Android
linktitle: Effective Properties
type: docs
weight: 50
url: /androidjava/shape-effective-properties/
keywords:
- shape properties
- camera properties
- light rig
- bevel shape
- text frame
- text style
- font height
- fill format
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Learn how to use Aspose.Slides for Android via Java to distinguish local, inherited, and effective shape formatting in PowerPoint presentations."
---

## **Understand Local, Inherited, and Effective Properties**

PowerPoint formatting can come from several places. The value stored directly on an object is its **local value**. If that value is not set, PowerPoint looks at parent formatting sources, such as a paragraph default, a text style, a layout or master slide, a theme, or presentation-level defaults. Those values are **inherited values**. The value that remains after the entire hierarchy is resolved is the **effective value**—the value used to render the object.

For example, a text portion may not define its own font height. Its local [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) value is then `Float.NaN`, which means "not set here." The portion can inherit a height from its paragraph, the presentation's default text style, or another applicable source. Calling [getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) on the portion format returns the final resolved height.

Use the two kinds of formatting data for different purposes:

- Read or change a local format object, such as [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/), when you need to control where a value is defined.
- Read an effective data object, such as [IPortionFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformateffectivedata/), when you need the final, rendered result. Effective data is read-only.

## **Compare Local, Inherited, and Effective Values**

The following complete example creates a shape and applies font heights at the presentation, paragraph, and portion levels. Each step prints the values defined at those levels and the resulting effective value for the same text portion. It also demonstrates why effective data must be read again after formatting changes.

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

            // Define inherited values at two different levels.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // A local value on the portion overrides both inherited values.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Changing an inherited value does not override an existing local value.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Clear the local value. The portion now inherits from the paragraph again.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Clear the paragraph value. The presentation default now supplies the result.
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

        // Read effective data after the preceding changes.
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

The priority in this example is portion local formatting, then paragraph formatting, then the presentation default. Other objects can have different inheritance chains, but the principle is the same: a more specific explicit value wins, and [getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) returns the final result.

## **Get Effective Text Properties**

Text formatting is split across several objects:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--) resolves text-frame properties such as margins, anchoring, autofit, and vertical text direction.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextstyle/#getEffective--) resolves paragraph formatting for each text style level.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) resolves paragraph properties such as alignment, indentation, and bullets.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) resolves character properties such as font height, typeface, color, bold, and italic.

For the next example, `text-formatting.pptx` must contain at least one slide and one [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) with a non-empty text frame. The AutoShape can appear at any position in the shape collection; the code searches for a suitable object and validates it before use.

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

## **Get Effective 3D Properties**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getEffective--) returns one [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformateffectivedata/) object that groups all resolved 3D settings. Its [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), and [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) methods expose the corresponding effective data. Reading these related settings together makes it easier to understand the final 3D appearance of a shape.

For this example, `shape-3d.pptx` must contain at least one shape on its first slide. Apply 3D camera, lighting, or bevel settings to that shape if you want the output to contain values other than the defaults.

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

## **Get Effective Table Formatting**

Table formatting can come from the table style and from formats applied to the whole table, a column, a row, or an individual cell. For conflicts among explicitly defined fills, the priority is cell, row, column, and then whole table. The effective format of a cell is the final format used to draw that cell.

For this example, `table-formatting.pptx` must contain at least one table on its first slide. The table must have at least one row and one column. The code searches for an [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) instead of assuming that `getShapes().get_Item(0)` is a table.

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

If you need the color rather than only the fill type, first check the effective [getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--), and then read the method that applies to that type—for example, [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) for a solid fill.

## **Re-read Effective Data After Changes**

Effective data describes the formatting hierarchy at the time it is resolved. Call `getEffective` again after changing anything that can participate in that hierarchy, including:

- the object's local formatting;
- paragraph or text-frame defaults;
- a table style, table, column, row, or cell format;
- layout or master slide formatting;
- theme data or presentation-level defaults;
- the layout or master assigned to a slide.

Do not keep an effective data object as a permanent snapshot. Aspose.Slides may cache some effective data internally, and a later `getEffective` call can refresh that data. If you need to compare values before and after a change, copy the scalar values you need—such as a font height, color, alignment, or bevel width—into your own variables before making the change.

To change a value, update the appropriate local format object and then call `getEffective` to verify the result. Effective data objects themselves are read-only.

## **FAQ**

**How can I tell which level supplied an effective value?**

Effective data contains the final value, not its source. Inspect the applicable local objects from the most specific level outward. For text, this can include the portion, paragraph, text frame, layout, master, theme, and presentation defaults. Undefined values such as `Float.NaN` or `null` indicate that the search continues to another level.

**What happens when no level defines a property?**

Aspose.Slides resolves the appropriate PowerPoint or library default. That resolved value appears in the effective data even though no local object explicitly defines it.

**Why does an effective value sometimes equal the local value?**

The local value won the inheritance calculation. This is expected when the property is explicitly set on the object and no more specific rule overrides it.

**When should I use local data instead of effective data?**

Use local data to inspect or edit a specific formatting level. Use effective data when you need the final appearance after inheritance, theme rules, and applicable styles have been resolved. The [complete comparison example](#compare-local-inherited-and-effective-values) demonstrates both in the same workflow.
