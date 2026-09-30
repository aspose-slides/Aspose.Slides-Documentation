---
title: 使用 Java 管理 PowerPoint 表格中的行和列
linktitle: 行和列
type: docs
weight: 20
url: /zh/java/manage-rows-and-columns/
keywords:
- 表格行
- 表格列
- 第一行
- 表头
- 克隆行
- 克隆列
- 复制行
- 复制列
- 删除行
- 删除列
- 行文字格式化
- 列文字格式化
- 表格样式
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 管理 PowerPoint 表格的行和列，加速演示文稿的编辑和数据更新。"
---
## **介绍**

Aspose.Slides for Java 允许您通过 [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) 类和 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) 接口在 PowerPoint 演示文稿中管理表格结构和格式。您可以指定标题行，克隆或删除行和列，并对整行或整列应用文本格式。

本文使用 Java 示例解释这些操作。它还展示了如何检索表格的样式预设以便重复使用。表格的行列索引从零开始。

## **控制行高**

使用 [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) 设置行的最小高度（单位：点）。这只是下限，而不是固定高度。[IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) 返回实际高度。通过 [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--) 访问行。

示例加载 [row-height-input.pptx](row-height-input.pptx)，其中的表格是第一张幻灯片的第一个形状。其第一行起始高度为 70 点。单元格使用 18 点 Arial 字体、自动换行，并且上下外边距为 6 点；第二列的较长文本会换成多行。示例将最小高度提升至 100 点，然后降低至 20 点，在每次更改后打印实际高度，并保存两个结果。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

使用提供的演示文稿时，增加最小值会为行添加空间。降低最小值会移除该额外空间，但实际高度仍大于 20 点，因为文本和单元格外边距需要更多空间。仅仅降低最小值无法将行高度压低到内容所需空间以下。

几个因素会影响实际高度：

- **文本和字体大小：** 更长的文本、显式换行或更大的字体可能需要更多的垂直空间。
- **换行和列宽：** 启用换行后，使用 [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) 减小列宽会产生更多行。更宽的列可以减小垂直所需空间。
- **单元格外边距：** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) 和 [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) 添加垂直空间。[ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) 和 [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) 减少文本可用宽度，可能导致额外换行。

对于此不含合并单元格的表格，所需垂直空间最多的单元格决定整行内容驱动的下限。要让行更短，可能需要缩短文本、减小字体大小或外边距，或加宽列宽。

下方的图像展示了相同缩放比例下的同一表格。在示例结果中，实际高度分别为 70、100 和 55.2 点：最终行仍高于其 20 点的最小值。确切的文本度量可能会因环境中可用的字体而有所不同。下载保存的结果：[increased minimum](row-height-increased.pptx) 和 [decreased minimum](row-height-decreased.pptx)。

| 原始：最小 70 点，实际 70 点 | 增加：最小 100 点，实际 100 点 | 减少：最小 20 点，实际 55.2 点 |
| --- | --- | --- |
| ![原始表格，第一行 70 点。](row-height-before.png) | ![表格，将第一行最小高度增加到 100 点后的效果。](row-height-increased.png) | ![表格，将第一行最小高度降低到 20 点后的效果；换行文本使行仍高于最小值。](row-height-decreased.png) |

## **将第一行设为标题**

使用 [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) 方法标记第一行为标题格式。其外观取决于应用于表格的表格样式。

1. 使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片。
3. 获取存放在该幻灯片第一个形状中的表格。
4. 为其第一行启用标题格式。
5. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中的表格是第一张幻灯片的第一个形状。它为第一行启用标题格式并保存为 `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **克隆表格行或列**

克隆行或列以重用其内容和格式。您可以将副本追加到表格末尾，或插入到指定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片。
3. 定义列宽和行高。
4. 使用 [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法添加表格。
5. 克隆所需的行。
6. 克隆所需的列。
7. 保存修改后的演示文稿。

示例需要至少包含一张幻灯片的 `Test.pptx`。它创建一个三列五行的表格，尺寸以点为单位。它将第一行和第一列的副本追加，然后在索引 3（即第四个位置）插入第二行和第二列的副本。生成的表格拥有七行五列。`false` 参数禁用对相邻合并行或列的克隆；此表格没有合并单元格。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **从表格中删除行或列**

删除表格中不再需要的行或列。删除后，后续行或列的索引会相应移动。

1. 使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类创建演示文稿。
2. 访问第一张幻灯片。
3. 定义列宽和行高。
4. 使用 [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法添加表格。
5. 删除第二行和第二列。
6. 保存修改后的演示文稿。

此示例创建一个 3×3 表格，并删除索引为 1 的行和列，生成的 2×2 表格保存在 `TestTable_out.pptx` 中。尺寸以点为单位。`false` 参数禁用对相邻合并行或列的删除；此表格没有合并单元格。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格行级别设置文本格式**

对整行应用文本格式以保持单元格一致。您可以设置字体属性、段落格式和文本方向，而无需逐个单元格进行格式化。

1. 使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类加载演示文稿。
2. 获取第一张幻灯片上的表格。
3. 对第一行使用 [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-)。
4. 对第一行使用 [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 和 [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-)。
5. 对第二行使用 [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)。
6. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中的表格是第一张幻灯片的第一个形状且至少有两行。它为第一行设置 25 点文本、右对齐以及 20 点的右段落外边距，然后在第二行设置垂直文本。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格列级别设置文本格式**

对整列应用文本格式以保持单元格一致。您可以设置字体属性、段落格式和文本方向，而无需逐个单元格进行格式化。

1. 使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类加载演示文稿。
2. 获取第一张幻灯片上的表格。
3. 对第一列使用 [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-)。
4. 对第一列使用 [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 和 [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-)。
5. 对第二列使用 [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)。
6. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中的表格是第一张幻灯片的第一个形状且至少有两列。它为第一列设置 25 点文本、右对齐以及 20 点的右段落外边距，然后在第二列设置垂直文本。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **获取表格样式属性**

使用 [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) 方法检索应用于表格的预设样式，以便在另一表格中重复使用。这识别的是预设，而不是单元格的个别格式覆盖。

示例创建一个表格，应用 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1)，然后读取该预设。它输出对应于 `DarkStyle1` 的整数值，并将表格保存为 `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**我可以将 PowerPoint 主题/样式应用于已创建的表格吗？**

可以。表格会继承幻灯片/版面/母版的主题，且仍然可以在该主题之上覆盖填充、边框和文本颜色。

**我可以像在 Excel 中一样对表格行进行排序吗？**

不能，Aspose.Slides 表格没有内置的排序或筛选功能。请先在内存中对数据进行排序，然后按该顺序重新填充表格行。

**我可以在保持特定单元格自定义颜色的同时使用分段（条纹）列吗？**

可以。启用分段列后，可对特定单元格进行局部格式覆盖；单元格级别的格式会优先于表格样式。