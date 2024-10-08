---
title: 管理单元格
type: docs
weight: 30
url: /zh/java/manage-cells/
keywords: "表格, 合并单元格, 拆分单元格, 表格单元格中的图像, Java, Aspose.Slides for Java"
description: "Java 中 PowerPoint 演示文稿中的表格单元格"
---


## **识别合并的表格单元格**
1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 从第一个幻灯片中获取表格。
3. 迭代表格的行和列以查找合并单元格。
4. 当找到合并单元格时打印消息。

以下 Java 代码演示了如何识别演示文稿中的合并表格单元格：

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // 假设 Slide#0.Shape#0 是一个表格
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("单元格 %d;%d 是合并单元格的一部分，RowSpan=%d 和 ColSpan=%d，起始于单元格 %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **移除表格单元格边框**
1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义一个具有宽度的列数组。
4. 定义一个具有高度的行数组。
5. 通过 [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) 方法向幻灯片添加表格。
6. 迭代每个单元格以清除上、下、右和左边框。
7. 将修改后的演示文稿保存为 PPTX 文件。

以下 Java 代码演示了如何从表格单元格中移除边框：

```java
// 实例化代表 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一个幻灯片
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // 定义具有宽度的列和高度的行
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 向幻灯片添加表格形状
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 设置每个单元格的边框格式
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // 将 PPTX 写入磁盘
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **合并单元格中的编号**
如果我们合并单元格 (1, 1) x (2, 1) 和 (1, 2) x (2, 2)，结果表格将被编号。此 Java 代码演示了该过程：

```java
// 实例化代表 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一个幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定义具有宽度的列和高度的行
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 向幻灯片添加表格形状
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 设置每个单元格的边框格式
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // 合并单元格 (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // 合并单元格 (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

然后我们进一步合并单元格，通过合并 (1, 1) 和 (1, 2)。结果是一个表格，其中包含一个大型合并单元格在其中心：

```java
// 实例化代表 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一个幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定义具有宽度的列和高度的行
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 向幻灯片添加表格形状
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 设置每个单元格的边框格式
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // 合并单元格 (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // 合并单元格 (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // 合并单元格 (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// 将 PPTX 文件写入磁盘
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **拆分单元格中的编号**
在前面的示例中，当表格单元格被合并时，其他单元格中的编号或数字系统没有改变。

这次，我们将使用一个普通的表格（没有合并单元格的表格），然后尝试拆分单元格 (1,1) 来获得一个特殊的表格。您可能想关注这个表格的编号，这被认为是奇怪的。然而，这就是 Microsoft PowerPoint 为表格单元格编号的方式，Aspose.Slides 也以同样的方式操作。

以下 Java 代码演示了我们所描述的过程：

```java
// 实例化代表 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一个幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定义具有宽度的列和高度的行
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 向幻灯片添加表格形状
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 设置每个单元格的边框格式
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // 合并单元格 (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // 合并单元格 (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // 拆分单元格 (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // 将 PPTX 文件写入磁盘
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改表格单元格背景颜色**

以下 Java 代码演示了如何更改表格单元格的背景颜色：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // 创建一个新表格
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // 设置单元格的背景颜色 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **在表格单元格中添加图像**

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义一个具有宽度的列数组。
4. 定义一个具有高度的行数组。
5. 通过 [AddTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) 方法向幻灯片添加表格。
6. 创建一个 `Images` 对象来保存图像文件。
7. 将 `IImage` 图像添加到 `IPPImage` 对象。
8. 将表格单元格的 `FillFormat` 设置为 `Picture`。
9. 将图像添加到表格的第一个单元格。
10. 将修改后的演示文稿保存为 PPTX 文件。

以下 Java 代码演示了如何在创建表格时将图像放置在表格单元格中：

```java
// 实例化代表 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一个幻灯片
    ISlide islide = pres.getSlides().get_Item(0);

    // 定义具有宽度的列和高度的行
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // 向幻灯片添加表格形状
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // 使用图像文件创建一个 IPPImage 对象
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 将图像添加到第一个表格单元格
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 将 PPTX 文件保存到磁盘
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```