---
title: 管理行和列
type: docs
weight: 20
url: /zh/androidjava/manage-rows-and-columns/
keywords: "表格, 表格行和列, PowerPoint 演示文稿, Java, Aspose.Slides for Android via Java"
description: "在 Java 中管理 PowerPoint 演示文稿中的表格行和列"
---

为了让您能够在 PowerPoint 演示文稿中管理表格的行和列，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) 接口和许多其他类型。

## **将第一行设置为标题**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例并加载演示文稿。
2. 通过索引获取幻灯片的引用。 
3. 创建一个 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) 对象并将其设置为 null。
4. 遍历所有 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 对象以找到相关的表格。
5. 将表格的第一行设置为其标题。 

以下 Java 代码演示如何将表格的第一行设置为其标题：

```java
// 实例化 Presentation 类
Presentation pres = new Presentation("table.pptx");
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 初始化 null 的 TableEx
    ITable tbl = null;

    // 遍历形状并设置对表格的引用
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            // 将表格的第一行设置为其标题
            tbl.setFirstRow(true);
        }
    }
    
    // 将演示文稿保存到磁盘
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **克隆表格的行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例并加载演示文稿，
2. 通过索引获取幻灯片的引用。 
3. 定义一个 `columnWidth` 数组。
4. 定义一个 `rowHeight` 数组。
5. 通过 [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法将 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) 对象添加到幻灯片中。
6. 克隆表格行。
7. 克隆表格列。
8. 保存修改后的演示文稿。

以下 Java 代码演示如何克隆 PowerPoint 表格的行或列：

```java
 // 实例化 Presentation 类
Presentation pres = new Presentation("Test.pptx");
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定义具有宽度的列和具有高度的行
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 向幻灯片添加表格形状
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 向行 1 单元 1 添加文本
    table.get_Item(0, 0).getTextFrame().setText("行 1 单元 1");

    // 向行 1 单元 2 添加文本
    table.get_Item(1, 0).getTextFrame().setText("行 1 单元 2");

    // 在表格末尾克隆行 1
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // 向行 2 单元 1 添加文本
    table.get_Item(0, 1).getTextFrame().setText("行 2 单元 1");

    // 向行 2 单元 2 添加文本
    table.get_Item(1, 1).getTextFrame().setText("行 2 单元 2");

    // 将行 2 克隆为表格的第 4 行
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // 在末尾克隆第一列
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // 在第 4 列索引克隆第二列
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // 将演示文稿保存到磁盘
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **从表格中删除行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例并加载演示文稿，
2. 通过索引获取幻灯片的引用。 
3. 定义一个 `columnWidth` 数组。
4. 定义一个 `rowHeight` 数组。
5. 通过 [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法将 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) 对象添加到幻灯片中。
6. 删除表格行。
7. 删除表格列。
8. 保存修改后的演示文稿。 

以下 Java 代码演示如何从表格中删除行或列：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置表格行级别的文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例并加载演示文稿，
2. 通过索引获取幻灯片的引用。 
3. 从幻灯片中访问相关的 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) 对象。
4. 设置第一行单元格的 [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)。
5. 设置第一行单元格的 [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 和 [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-)。
6. 设置第二行单元格的 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)。
7. 保存修改后的演示文稿。

这段 Java 代码演示了操作过程。

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 假设第一张幻灯片上的第一个形状是一个表格
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // 设置第一行单元格的字体高度
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // 设置第一行单元格的文本对齐和右边距
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // 设置第二行单元格的文本垂直类型
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // 将演示文稿保存到磁盘
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置表格列级别的文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例并加载演示文稿，
2. 通过索引获取幻灯片的引用。 
3. 从幻灯片中访问相关的 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) 对象。
4. 设置第一列单元格的 [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)。
5. 设置第一列单元格的 [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 和 [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-)。
6. 设置第二列单元格的 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)。
7. 保存修改后的演示文稿。 

这段 Java 代码演示了操作过程：

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 假设第一张幻灯片上的第一个形状是一个表格
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 设置第一列单元格的字体高度
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // 一次调用设置第一列单元格的文本对齐和右边距
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // 设置第二列单元格的文本垂直类型
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便您可以将这些细节用于另一个表格或其他地方。以下 Java 代码演示如何从表格预设样式获取样式属性：

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // 更改默认样式预设主题
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```