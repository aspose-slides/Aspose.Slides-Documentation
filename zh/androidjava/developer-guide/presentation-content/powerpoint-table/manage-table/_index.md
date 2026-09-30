---
title: 管理 Android 上的演示文稿表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh/androidjava/manage-table/
keywords:
- 添加表格
- 创建表格
- 访问表格
- 宽高比
- 对齐文本
- 文本格式化
- 表格样式
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 PowerPoint 幻灯片中创建和编辑表格。了解简洁的 Java 代码示例，以简化您的表格工作流。"
---
## **简介**

PowerPoint 中的表格将信息组织成行和列，便于阅读和比较数值。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 接口、[Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) 类、[ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) 接口以及其他类型，帮助您在演示文稿中创建、更新和管理表格。

## **从头创建表格**

通过指定位置、列宽和行高来创建表格。将其添加到幻灯片后，您可以设置单元格边框、合并单元格以及插入文本。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义以点为单位的列宽数组。
4. 定义以点为单位的行高数组。
5. 通过 [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法向幻灯片添加 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 对象。
6. 遍历每个 [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) 为其上、下、左、右边框设置格式。
7. 合并表格第一行的前两个单元格。
8. 通过其 [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) 方法访问合并后的单元格。
9. 设置合并单元格中的文本。
10. 保存修改后的演示文稿。

下面的示例在 (100, 50) 点位置创建一个三列五行的表格，使用宽度为 5 点的红色边框，合并第一行的前两个单元格，并将结果保存为 `table.pptx`。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **标准表格中的编号方式**

在标准表格中，单元格索引从零开始，采用 (列, 行) 的顺序。第一个单元格的索引为 (0, 0)。

例如，具有 4 列 4 行的表格的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此示例创建上图所示的 4 × 4 表格，列宽和行高均为 70 点，单元格边框为宽度 5 点的红色。坐标显示单元格索引；示例保持单元格为空并将表格保存为 `StandardTables_out.pptx`。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **访问已有表格**

表格存储在幻灯片的形状集合中。遍历形状集合以定位表格，然后使用 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 接口读取或更新其单元格。

1. 使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取包含表格的幻灯片引用。
3. 遍历 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 对象，并在发现表格时停止。如果幻灯片包含多个表格，可使用 [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) 来识别所需的表格。
4. 更新目标单元格中的文本。
5. 保存修改后的演示文稿。

下面的示例打开 `UpdateExistingTable.pptx`，并在第一张幻灯片上找到第一个表格。它将第 0 列第 1 行的单元格设置为 `New`，并将结果保存为 `table1_out.pptx`。输入文件必须至少包含一张幻灯片，且该幻灯片上的第一个表格必须至少有一列两行。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

要在现有表格中调整行高并了解实际高度为何可能超过请求的最小值，请参阅 [Control Row Height](/slides/zh/androidjava/manage-rows-and-columns/#control-row-height)。

## **查找拥有 TextFrame 的单元格**

当通用文本处理代码从表格中获取到一个 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) 时，使用 [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) 方法获取所属的 [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/)。对于表格单元格的 TextFrame，[ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) 返回所有者，而 [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) 返回 `null`，即使表格本身是一个形状。

单元格坐标可通过只读的 [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) 和 [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) 方法获取。[ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) 还提供只读的导航：它返回所有者但不更改所有权。使用前请始终检查返回的单元格是否为 `null`。

有关完整示例（识别表格单元格和形状所有者，包括与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/androidjava/search-and-replace-text/)。

## **在表格中对齐文本**

您可以控制单个单元格的垂直锚点和文本方向。本节示例将第一个单元格中的文本居中，并将其旋转 270 度。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 对象。
4. 从表格中获取 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) 对象。
5. 获取第一个 [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) 并设置其文本和颜色。
6. 使用 [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) 和 [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) 设置单元格的垂直锚点和文本方向。
7. 保存修改后的演示文稿。

本示例创建一个 4 × 4 表格，列宽为 120 点，行高为 100 点。它格式化单元格 (0, 0) 中的文本，在第一行的其余单元格中添加数值，并将结果保存为 `Vertical_Align_Text_out.pptx`。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格级别设置文本格式**

使用 [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) 可对表格中所有单元格应用文本格式。其重载接受段落、部分和文本框格式，使您无需遍历单元格即可设置这些属性。

1. 使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取幻灯片的引用。
3. 从幻灯片获取 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 对象。
4. 使用 [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) 设置文本的字体大小。
5. 使用 [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 和 [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) 设置段落对齐方式和右边距。
6. 使用 [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) 设置文本方向。
7. 保存修改后的演示文稿。

下面的示例打开 `table.pptx`（该文件必须至少包含一张幻灯片，且第一形状是表格），将字体大小设为 25 点，段落右对齐并使用 20 点右边距，使文本垂直显示。格式化后的演示文稿保存为 `result.pptx`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **获取表格样式属性**

使用 [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) 读取表格的预设样式，使用 [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) 进行设置。此示例对一个表格应用 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/)，打印预设值，并将相同的预设应用于第二个表格。两个表格均保存于 `table-style.pptx`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **锁定表格的宽高比**

表格的宽高比是其宽度与高度的比例。使用 [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) 可锁定该比例。

下面的示例打开 `pres.pptx`（该文件必须至少包含一张幻灯片，且第一形状是表格），打印当前锁定状态，启用宽高比锁定，打印更新后的状态 (`true`)，并将结果保存为 `pres-out.pptx`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**我可以为整个表格及其单元格内的文本启用从右到左 (RTL) 阅读方向吗？**

可以。表格提供了 [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) 方法，段落则有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-)。两者结合使用可确保单元格内正确的 RTL 顺序和渲染。

**如何防止用户在最终文件中移动或调整表格的大小？**

使用 [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) 可禁用移动、缩放、选择等操作。这些锁同样适用于表格。

**是否支持在单元格内部将图像作为背景插入？**

支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/)，图像将按照所选模式（拉伸或平铺）覆盖单元格区域。