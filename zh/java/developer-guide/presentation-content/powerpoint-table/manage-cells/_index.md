---
title: 在演示文稿中使用 Java 管理表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/java/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 移除边框
- 拆分单元格
- 单元格中的图像
- 背景颜色
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 Java 中管理 PowerPoint 表格单元格：识别合并单元格、移除边框、拆分单元格，并设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您访问和修改 PowerPoint 演示文稿中的表格单元格。本文解释了如何识别合并的表格单元格、移除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格的背景颜色以及在表格单元格中添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿保存为 PPTX 文件。

Aspose.Slides 使用从零开始的索引，以 `(列, 行)` 的顺序访问表格单元格。

## **识别合并的表格单元格**

示例打开现有演示文稿，并将第一张幻灯片上的第一个形状作为表格访问。它假设幻灯片和形状存在且该形状是表格。然后遍历所有行和列，使用 [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) 来识别合并区域中的单元格。对于每个匹配，它以 `row;column` 的顺序打印单元格坐标、[getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)、[getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--) 以及区域的起始坐标，[getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) 和 [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--)。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **移除表格单元格边框**

创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 并使用 [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 将表格添加到其第一张幻灯片。列宽、行高和表格位置以点为单位指定。示例将所有四个单元格边框设置为 [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)，使其不可见。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加对角线单元格边框**

使用 [getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) 从左上角绘制一条线到右下角，使用 [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) 从左下角绘制一条线到右上角。对角线可用于标记角标题；两个对角线可以形成 X，标记单元格不适用。

每条对角线都是一个 [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/)。在其 [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) 中，使用 [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 选择 [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 并通过 [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) 选择颜色。使用 [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) 以点为单位设置线宽。

示例在同一行创建了三个单元格：一个红色向下的对角线、一个蓝色向上的对角线，以及两个对角线。它保持顶部、底部、左侧和右侧单元格边框不变。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A diagonal 是一种格式属性，而不是单元格拆分。每个单元格保留一个文本框，可通过 [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) 访问；对角线两侧的区域不能独立编辑。

保存的表格，在 Microsoft PowerPoint 中呈现如下：

![三个表格单元格显示从左上到右下的红色对角线、从左下到右上的蓝色对角线以及形成 X 的两条对角线。](diagonal-cell-borders.png)

*从左到右：向下的对角线（红色，3 pt），向上的对角线（蓝色，5 pt），以及两条对角线。*

## **合并表格单元格**

使用 [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) 将矩形范围的表格单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包含范围之外的单元格；`false` 将合并限制在该范围内。

示例创建一个 4×4 表格，列宽和行高为 70 点，然后合并位于 `(1, 1)` 到 `(2, 2)` 的四个中心单元格。合并后的单元格跨越两列两行，而表格的底层网格仍保留四列四行。要访问合并单元格的内容或格式，在本例中使用其左上位置：`table.get_Item(1, 1)`。合并范围内的其他位置仍是表格网格的一部分，因此范围外单元格的索引保持不变。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **拆分表格单元格**

在前面的示例中合并单元格会保留表格的网格。拆分单元格可能会引入新的网格列，并更改其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

此示例创建一个 4×4 表格，列宽和行高为 70 点，并对单元格 `(1, 1)` 调用 [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-)。将单元格 70 点宽度的一半传入，以创建两个等宽单元格。

拆分后，这两个半单元格可通过 `table.get_Item(1, 1)` 和 `table.get_Item(2, 1)` 访问。表格网格现在有五列：原本在第 2、3 列的单元格分别移动到第 3、4 列。行索引保持不变。拆分后访问单元格时请使用这些更新后的列索引。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![一个未合并的 70 点单元格拆分为两个 35 点单元格，新增第五列网格并将其右侧的索引向右移动。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*宽度拆分影响单元格 (1, 1)，使用从零开始的 (列, 行) 索引。其他行保持单元格跨越两个新列位置。*
<!-- visual-explanation:manage-cells:end -->

### **按行或列跨度拆分合并的单元格**

为了为数据填充准备合并的模板单元格，使用 [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) 按现有行边界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) 按列边界拆分。

`index` 参数计数拆分上部的行或左部的列；它相对于合并区域：

- 行拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)。
- 列拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)。

示例假设演示文稿的第一张幻灯片的第一个形状是表格，其中 `(1, 2)` 和 `(1, 3)` 垂直合并。从较低的位置开始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) 和 [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) 定位起点，并检查两个跨度。`splitByRowSpan(1)` 随后将第 2 行和第 3 行分离用于产品名称。对于水平的两列合并，使用 `splitByColSpan(1)` 替代。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // 从表格中检索拆分后的结果单元格。
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

表格网格和周围单元格索引保持不变。通过坐标检索生成的单元格；此处两者的跨度均为 1，且 [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) 返回 `false`。更大的区域在一次拆分后仍可能部分保持合并。

原始文本及其格式保留在上方（或左侧）单元格；新单元格为空，但继承单元格的格式，如填充、边框和边距。拆分后填充单元格并显式设置任何需要的文本格式。

保存的演示文稿包含单独的 “Product A” 和 “Product B” 单元格，保留了模板的单元格格式。请参阅 [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) 了解详情。

### **按特定高度拆分单元格**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) 以点为单位获取上部的高度。 [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) 以现有网格行数获取上部的行数。要在右侧列中将一个 40 点的单元格居中，可从单元格的实际高度减去 40，然后将剩余空间在上方和下方平均分配。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };
    
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

第一次拆分添加了一行网格，并在单元格 `(1, 1)` 中留下了下方的 90 点。第二次拆分将该单元格分为一个 40 点的中间单元格和一个 50 点的底部单元格。右侧列现在有三个单元格，分别从上到下高度为 50、40、50 点。左侧单元格跨越所有三行，保持原始的 140 点高度。

![左侧单元格跨越整个表格高度，右侧有三个单元格，其中中间单元格位于中心。](split-by-height.png)

## **更改表格单元格背景颜色**

此示例创建一个列宽 150 点、行高 50 点的表格。它使用 [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 选择实心填充，并为第 `(2, 3)` 单元格（第 3 列第 4 行）设置通过 [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) 返回的颜色为红色。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格单元格中添加图像**

在运行此示例之前，将输入图像放置在工作目录中。它使用 [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) 加载图像，并使用 [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) 将其添加到演示文稿的图像集合中。然后将该图像分配给单元格 `(0, 0)`（表格的第一个单元格）的图片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) 将图像拉伸以填满单元格，可能会改变其宽高比。列宽和行高以点为单位。加载的图像在添加到演示文稿后于 `finally` 块中释放。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**我可以为单个单元格的不同边设置不同的线粗细和样式吗？**

可以。[top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) 边框具有独立的属性，因此每一侧的粗细和样式可以不同。

**在将图片设为单元格背景后，如果更改列/行大小，图像会怎样？**

行为取决于 [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/)。使用 stretch 时，图像会适应新的单元格；使用 tile 时，平铺会重新计算。

**我可以为单元格的全部内容分配超链接吗？**

[Hyperlinks](/slides/zh/java/manage-hyperlinks/) 在单元格的文本框内部的文本（片段）级别或在整个表格/形状级别设置。实际操作中，您可以将链接分配给片段或单元格中的全部文本。

**我可以在单个单元格内设置不同的字体吗？**

可以。单元格的文本框支持 [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)（文本段落），其格式（字体系列、样式、大小和颜色）可以独立设置。