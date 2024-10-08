---
title: 管理表格
type: docs
weight: 10
url: /java/manage-table/
keywords: "表格, 创建表格, 访问表格, 表格纵横比, PowerPoint 演示文稿, Java, Aspose.Slides for Java"
description: "在 Java 中创建和管理 PowerPoint 演示文稿中的表格"
---

在 PowerPoint 中，表格是一种有效显示和呈现信息的方式。网格中的信息（按行和列排列）简单明了，易于理解。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table) 类、[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) 接口、[Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) 类、[ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) 接口和其他类型，允许您在各种演示文稿中创建、更新和管理表格。

## **从头创建表格**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义一个 `columnWidth` 的数组。
4. 定义一个 `rowHeight` 的数组。
5. 通过 [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) 方法将一个 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) 对象添加到幻灯片。
6. 遍历每个 [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) 以应用格式设置到上、下、左、右边框。
7. 合并表格第一行的前两个单元格。
8. 访问 [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) 的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/)。
9. 向 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) 添加一些文本。
10. 保存修改后的演示文稿。

以下 Java 代码展示了如何在演示文稿中创建一个表格：

```java
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定义列宽和行高
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // 将表格形状添加到幻灯片
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 设置每个单元格的边框格式
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
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
    // 合并第一行的单元格 1 和 2
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // 向合并单元格添加文本
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("合并单元格");

    // 将演示文稿保存到磁盘
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **标准表格中的编号**

在标准表格中，单元格的编号简单且以零为基数。表格中的第一个单元格的索引为 0,0（列 0，行 0）。

例如，在一个有 4 列和 4 行的表格中，单元格的编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 Java 代码展示了如何指定表格中单元格的编号：

```java
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定义列宽和行高
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 将表格形状添加到幻灯片
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

    // 将演示文稿保存到磁盘
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问现有表格**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。

2. 通过索引获取包含表格的幻灯片的引用。

3. 创建一个 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) 对象并将其设置为 null。

4. 遍历所有的 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 对象，直到找到表格。

   如果您怀疑您处理的幻灯片中包含一个单一表格，您可以简单地检查它包含的所有形状。当某个形状被识别为表格时，您可以将其强制转换为 [Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table) 对象。但是如果您处理的幻灯片中包含多个表格，那么您最好通过它的 [setAlternativeText(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) 来搜索您需要的表格。

5. 使用 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) 对象与表格进行交互。在下面的示例中，我们向表格添加了一行。

6. 保存修改后的演示文稿。

以下 Java 代码展示了如何访问并操作现有表格：

```java
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 初始化 null TableEx
    ITable tbl = null;

    // 遍历形状并设置找到的表格的引用
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // 设置第二行第一列的文本
            tbl.get_Item(0, 1).getTextFrame().setText("新");
        }
    }
    
    // 将修改后的演示文稿保存到磁盘
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **对表格中的文本进行对齐**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向幻灯片添加一个 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) 对象。 
4. 从表格中访问一个 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) 对象。 
5. 访问 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/)。
6. 垂直对齐文本。
7. 保存修改后的演示文稿。

以下 Java 代码展示了如何对表格中的文本进行对齐：

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 定义列宽和行高
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // 将表格形状添加到幻灯片
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // 访问文本框
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // 为文本框创建段落对象
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // 为段落创建文字部分对象
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("文本在这里");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // 垂直对齐文本
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // 保存演示文稿到磁盘
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在表格级别设置文本格式**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 从幻灯片中访问一个 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) 对象。
4. 设置文本的 [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-)。
5. 设置 [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 和 [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-)。
6. 设置 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)。
7. 保存修改后的演示文稿。 

以下 Java 代码展示了如何将您喜欢的格式选项应用到表格中的文本：

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation("simpletable.pptx");
try {
    // 假设第一张幻灯片上的第一个形状是一个表格
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // 设置表格单元格的字体高度
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // 设置表格单元格的文本对齐和右边距
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // 设置表格单元格的文本纵向类型
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便您可以将这些细节用于另一个表格或其他地方。以下 Java 代码展示了如何从表格预设样式中获取样式属性：

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // 修改默认样式预设主题 
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **锁定表格的纵横比**

几何形状的纵横比是其在不同维度上的尺寸比例。Aspose.Slides 提供了 [**setAspectRatioLocked**](https://reference.aspose.com/slides/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) 属性，允许您锁定表格和其他形状的纵横比设置。

以下 Java 代码展示了如何锁定表格的纵横比：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("锁定纵横比设置: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // 反转

    System.out.println("锁定纵横比设置: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```