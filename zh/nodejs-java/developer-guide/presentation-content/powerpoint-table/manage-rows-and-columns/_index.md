---
title: 管理行和列
type: docs
weight: 20
url: /zh/nodejs-java/manage-rows-and-columns/
keywords: "表格, 表格行和列, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "在 PowerPoint 演示文稿中使用 JavaScript 管理表格的行和列"
---

为了让您在 PowerPoint 演示文稿中管理表格的行和列，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 类、[Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) 类以及许多其他类型。

## **Set First Row as Header**
### **将首行设为标题**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例并加载演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 创建一个 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) 对象并将其设为 null。  
4. 遍历所有 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 对象以查找相关表格。  
5. 将表格的第一行设为标题行。  

下面的 JavaScript 代码演示了如何将表格的第一行设为标题：
```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // 访问第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 初始化 null TableEx
    var tbl = null;
    // 遍历形状并设置对表格的引用
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // 将表格的首行设为标题
            tbl.setFirstRow(true);
        }
    }
    // 将演示文稿保存到磁盘
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Clone Table's Row or Column**
### **克隆表格的行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例并加载演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 定义 `columnWidth` 数组。  
4. 定义 `rowHeight` 数组。  
5. 通过 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) 方法向幻灯片添加 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) 对象。  
6. 克隆表格行。  
7. 克隆表格列。  
8. 保存修改后的演示文稿。  

下面的 JavaScript 代码演示了如何克隆 PowerPoint 表格的行或列：
```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // 访问第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 定义列宽和行高
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // 在幻灯片上添加表格形状
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 为第1行第1列添加文本
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // 为第1行第2列添加文本
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // 在表格末尾克隆第1行
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // 为第2行第1列添加文本
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // 为第2行第2列添加文本
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // 将第2行克隆为表格第4行
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // 在末尾克隆第一列
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // 在第4列位置克隆第2列
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // 将演示文稿保存到磁盘
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Remove Row or Column from Table**
### **从表格中删除行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例并加载演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 定义 `columnWidth` 数组。  
4. 定义 `rowHeight` 数组。  
5. 通过 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) 方法向幻灯片添加 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) 对象。  
6. 删除表格行。  
7. 删除表格列。  
8. 保存修改后的演示文稿。  

下面的 JavaScript 代码演示了如何从表格中删除行或列：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Set Text Formatting on Table Row Level**
### **在表格行级别设置文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例并加载演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片中获取相关的 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) 对象。  
4. 为首行单元格调用 [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)。  
5. 为首行单元格调用 [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 和 [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)。  
6. 为第二行单元格调用 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。  
7. 保存修改后的演示文稿。  

下面的 JavaScript 代码演示了该操作：
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 假设第一张幻灯片上的第一个形状是表格
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 设置首行单元格的字体高度
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // 设置首行单元格的文本对齐方式和右边距
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // 设置第二行单元格的文本垂直类型
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // 将演示文稿保存到磁盘
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Set Text Formatting on Table Column Level**
### **在表格列级别设置文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例并加载演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片中获取相关的 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) 对象。  
4. 为首列单元格调用 [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)。  
5. 为首列单元格调用 [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 和 [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)。  
6. 为第二列单元格调用 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。  
7. 保存修改后的演示文稿。  

下面的 JavaScript 代码演示了该操作：
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 假设第一张幻灯片上的第一个形状是表格
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 设置第一列单元格的字体高度
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // 一次性设置第一列单元格的文本对齐方式和右边距
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // 设置第二列单元格的文本垂直类型
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Get Table Style Properties**
### **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便在其他表格或其他位置使用这些细节。下面的 JavaScript 代码展示了如何获取表格预设样式的属性：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// 更改默认的样式预设主题
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**
### **常见问题解答**

**是否可以将 PowerPoint 主题/样式应用于已创建的表格？**

可以。表格会继承幻灯片/布局/母版的主题，您仍然可以在此基础上覆盖填充、边框和文字颜色。

**是否可以像 Excel 那样对表格行进行排序？**

不能，Aspose.Slides 表格没有内置的排序或筛选功能。请先在内存中对数据进行排序，然后按照该顺序重新填充表格行。

**是否可以在保持特定单元格自定义颜色的同时使用条纹列？**

可以。启用条纹列后，可对特定单元格进行本地格式覆盖；单元格级别的格式会优先于表格样式。