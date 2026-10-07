---
title: 在 Android 上管理演示文稿中的表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/androidjava/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 移除边框
- 拆分单元格
- 单元格中的图像
- 背景颜色
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides for Android（Java）管理 PowerPoint 表格单元格：识别合并单元格、移除边框、拆分单元格，并设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您访问和修改 PowerPoint 演示文稿中的表格单元格。本文介绍如何识别合并的表格单元格、移除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格的背景颜色，以及在表格单元格内添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿保存为 PPTX 文件。

Aspose.Slides 使用从零开始的索引以 `(column, row)` 的顺序访问表格单元格。

## **标识合并的表格单元格**

示例打开现有演示文稿并将第一张幻灯片上的第一个形状作为表格访问。它假设幻灯片和形状存在且该形状为表格。然后遍历所有行和列，并使用 [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) 来识别合并区域中的单元格。对于每个匹配项，它以 `row;column` 顺序打印单元格坐标、[getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)、[getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--)，以及区域的起始坐标，[getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--)，和 [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--)。

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

创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 并使用 [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 在其第一张幻灯片上添加表格。列宽、行高和表格位置以点为单位指定。示例将所有四条单元格边框设置为 [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)，使其不可见。

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

## **合并表格单元格**

使用 [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) 将矩形范围的表格单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包括指定范围之外的单元格；`false` 将合并限制在该范围内。

示例创建一个 4×4 表格，列宽和行高均为 70 点，然后合并位于 `(1, 1)` 到 `(2, 2)` 的四个中心单元格。合并后的单元格跨越两列两行，而表格的底层网格仍保留四列四行。要访问合并单元格的内容或格式，请使用其左上位置：本例中为 `table.get_Item(1, 1)`。合并范围内的其他位置仍然是表格网格的一部分，因此范围之外单元格的索引保持不变。

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

在前面的示例中合并单元格会保留表格的网格。拆分单元格可能会引入新的网格列并更改其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

本例创建一个 4×4 表格，列宽和行高为 70 点，并在单元格 `(1, 1)` 上调用 [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-)。将单元格 70 点宽度的一半传入，以创建两个等宽单元格。

拆分后，这两半分别通过 `table.get_Item(1, 1)` 和 `table.get_Item(2, 1)` 访问。表格网格现在有五列：原本位于第 2 列和第 3 列的单元格分别移动到第 3 列和第 4 列。行索引保持不变。拆分后访问单元格时请使用这些更新后的列索引。

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

### **按行或列跨度拆分合并单元格**

要为数据填充准备合并的模板单元格，可使用 [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) 按现有行边界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) 按列边界拆分。

`index` 参数在拆分的上部计算行数，或在左部计算列数；它相对于合并区域：

- 行拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)。
- 列拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--)。

示例假设演示文稿的第一张幻灯片的第一个形状是表格，并且 `(1, 2)` 与 `(1, 3)` 垂直合并。从下方位置开始，它使用 [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) 和 [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) 定位起点并检查两个跨度。随后 `splitByRowSpan(1)` 将第 2 行和第 3 行分离用于产品名称。对于水平的两列合并，则改用 `splitByColSpan(1)`。

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

        // 检索拆分后表格中生成的单元格。
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

表格网格及其周围单元格的索引保持不变。通过坐标检索生成的单元格；此处两个单元格的跨度均为 1，且 [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) 返回 `false`。在一次拆分后，较大的区域仍可部分保持合并状态。

原始文本及其格式保留在上（或左）单元格；新单元格为空，但继承了填充、边框和边距等单元格格式。拆分后填充单元格并显式设置所需的文本格式。

保存的演示文稿包含分别为 "Product A" 和 "Product B" 的单元格，保留了模板的单元格格式。详见 [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/)。

## **更改表格单元格背景颜色**

本例创建一个列宽 150 点、行高 50 点的表格。它使用 [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) 选择实心填充，并将 [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) 返回的颜色设置为红色，以用于第 3 列第 4 行的单元格 `(2, 3)`。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **在表格单元格内添加图像**

在运行本示例前，请将输入图像放置在工作目录中。它使用 [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) 加载图像，并通过 [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) 将其添加到演示文稿的图像集合中。随后将该图像分配给表格中第一个单元格 `(0, 0)` 的图片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) 会拉伸图像以填满单元格，可能会改变其宽高比。列宽和行高以点为单位。图像加载后在 `finally` 块中被释放。

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

**我可以为单个单元格的不同边设置不同的线条粗细和样式吗？**

是的。[上](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[下](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[左](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[右](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) 边框具有独立的属性，因此每一侧的粗细和样式可以不同。

**如果在将图片设为单元格背景后更改列/行大小，图像会怎样？**

行为取决于 [填充模式](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/)。使用拉伸时，图像会调整到新的单元格；使用平铺时，平铺会重新计算。

**我可以为单元格的全部内容分配超链接吗？**

[超链接](/slides/zh/androidjava/manage-hyperlinks/) 在单元格的文本框内部的文本（段落）级别或整个表格/形状级别设置。实际上，您可以将链接分配给单元格中的某一段落或全部文本。

**我可以在单个单元格内设置不同的字体吗？**

是的。单元格的文本框支持 [文字段](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/)（运行），可独立设置字体系列、样式、大小和颜色。