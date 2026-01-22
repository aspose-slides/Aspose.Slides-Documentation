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
description: "使用 Aspose.Slides for Android 在 PowerPoint 幻灯片中创建和编辑表格。发现简洁的 Java 示例代码，简化您的表格工作流。"
---

PowerPoint 中的表格是显示和呈现信息的高效方式。以网格单元格（按行列排列）的形式呈现的信息直观且易于理解。

Aspose.Slides 提供了[Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table)类、[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)接口、[Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/)类、[ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/)接口以及其他类型，以便您在各种演示文稿中创建、更新和管理表格。

## **从头创建表格**

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义 `columnWidth` 数组。  
4. 定义 `rowHeight` 数组。  
5. 通过[addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-)方法向幻灯片添加[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)对象。  
6. 遍历每个[ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/)，对上、下、左、右边框应用格式设置。  
7. 合并表格第一行的前两个单元格。  
8. 访问[ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/)的[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/)。  
9. 向[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/)添加一些文本。  
10. 保存修改后的演示文稿。

下面的 Java 代码展示了如何在演示文稿中创建表格：
```java
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定义列宽和行高
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // 向幻灯片添加表格形状
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 为每个单元格设置边框格式
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
    // 合并第 1 行的第 1 与第 2 个单元格
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // 向合并后的单元格添加文本
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // 将演示文稿保存到磁盘
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **标准表格的编号**

在标准表格中，单元格的编号是直接且从零开始的。表格中的第一个单元格索引为 0,0（第 0 列，第 0 行）。

例如，具有 4 列 4 行的表格单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

下面的 Java 代码展示了如何为表格中的单元格指定编号：
```java
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定义列宽和行高
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 向幻灯片添加表格形状
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 为每个单元格设置边框格式
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

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。  
2. 通过索引获取包含该表格的幻灯片的引用。  
3. 创建一个[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)对象并将其设为 null。  
4. 遍历所有[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)对象，直到找到表格。  
   如果您怀疑当前幻灯片只包含一个表格，可以直接检查其所有形状。当形状被识别为表格时，可以将其强制转换为[Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table)对象。但如果幻灯片包含多个表格，则最好通过其[setAlternativeText(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-)属性搜索所需的表格。  
5. 使用[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)对象对表格进行操作。在下面的示例中，我们向表格添加了一行新行。  
6. 保存修改后的演示文稿。

下面的 Java 代码展示了如何访问和操作现有表格：
```java
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 初始化为 null 的 TableEx
    ITable tbl = null;

    // 遍历形状并将引用指向找到的表格
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // 为第二行的第一列设置文本
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // 将修改后的演示文稿保存到磁盘
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **对齐表格中的文本**

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)对象。  
4. 从表格访问[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)对象。  
5. 访问[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)的[IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/)。  
6. 垂直对齐文本。  
7. 保存修改后的演示文稿。

下面的 Java 代码展示了如何在表格中对齐文本：
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 定义列宽和行高
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // 向幻灯片添加表格形状
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // 访问文本框
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // 为文本框创建 Paragraph 对象
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // 为段落创建 Portion 对象
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // 垂直对齐文本
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // 将演示文稿保存到磁盘
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **在表格级别设置文本格式**

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片访问[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)对象。  
4. 设置文本的[setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)。  
5. 设置[setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-)和[setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-)。  
6. 设置[setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)。  
7. 保存修改后的演示文稿。

下面的 Java 代码展示了如何将首选的格式选项应用到表格中的文本：
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation("simpletable.pptx");
try {
    // 假设第一张幻灯片上的第一个形状是表格
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // 设置表格单元格的字体高度
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // 一次调用设置表格单元格的文本对齐方式和右边距
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // 设置表格单元格的文本垂直类型
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便在其他表格或其他位置使用这些细节。下面的 Java 代码展示了如何从表格预设样式中获取样式属性：
```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // 更改默认的样式预设主题
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **锁定表格的宽高比**

几何形状的宽高比是其在不同维度上的尺寸比例。Aspose.Slides 提供了[**setAspectRatioLocked**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-)属性，以便您锁定表格及其他形状的宽高比设置。

下面的 Java 代码展示了如何锁定表格的宽高比：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // 取反

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**我能为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

是的。表格提供了[setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-)方法，段落则有[ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-)。同时使用这两者可确保单元格内部的 RTL 顺序和渲染正确。

**我该如何防止用户在最终文件中移动或调整表格大小？**

使用形状锁定可禁用移动、调整大小、选择等。这些锁定同样适用于表格。

**是否支持在单元格内插入图像作为背景？**

支持。您可以为单元格设置[picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/)，图像将根据所选模式（拉伸或平铺）覆盖单元格区域。