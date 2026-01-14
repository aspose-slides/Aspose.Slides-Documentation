---
title: 管理 PHP 中的演示文稿表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh/php-java/manage-table/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 幻灯片中创建和编辑表格。发现简洁的代码示例以简化您的表格工作流。"
---

PowerPoint 中的表格是一种高效的展示和呈现信息的方式。网格单元格（按行列排列）中的信息直观易懂。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) 类、[Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) 类以及其他类型，帮助您在各种演示文稿中创建、更新和管理表格。

## **从头创建表格**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义 `columnWidth` 数组。  
4. 定义 `rowHeight` 数组。  
5. 通过 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) 方法向幻灯片添加 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 对象。  
6. 遍历每个 [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)，为其上、下、左、右边框应用格式。  
7. 合并表格第一行的前两个单元格。  
8. 访问 [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) 的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。  
9. 向 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 添加一些文本。  
10. 保存修改后的演示文稿。

下面的 PHP 代码演示了如何在演示文稿中创建表格：
```php
  # 实例化一个表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 定义列宽和行高
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # 将表格形状添加到幻灯片
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 为每个单元格设置边框格式
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # 合并第 1 行的第 1 与第 2 个单元格
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # 向合并的单元格添加一些文本
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # 将演示文稿保存到磁盘
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **标准表格中的编号**

在标准表格中，单元格的编号方式简单且从 0 开始。表格中的第一个单元格索引为 0,0（第 0 列，第 0 行）。

例如，具有 4 列 4 行的表格的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

下面的 PHP 代码演示了如何为表格中的单元格指定编号：
```php
  # 实例化一个表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 定义列宽和行高
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # 向幻灯片添加表格形状
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 为每个单元格设置边框格式
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # 将演示文稿保存到磁盘
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **访问现有表格**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  

2. 通过索引获取包含表格的幻灯片的引用。  

3. 创建一个 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) 对象并将其设为 null。  

4. 遍历所有 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 对象，直到找到表格。  

   如果您确信当前幻灯片只包含一个表格，可以直接检查其所有形状。当形状被识别为表格时，可将其强制转换为 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) 对象。但如果幻灯片中包含多个表格，建议通过其 [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) 方法搜索所需表格。  

5. 使用 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) 对象对表格进行操作。下面的示例在表格中添加了一行新行。  

6. 保存修改后的演示文稿。

下面的 PHP 代码演示了如何访问并操作现有表格：
```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 初始化为 null 的 TableEx
    $tbl = null;
    # 遍历形状并将找到的表格设为引用
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # 设置第二行第一列的文本
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # 将修改后的演示文稿保存到磁盘
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **在表格中对齐文本**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) 对象。  
4. 从表格中获取 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 对象。  
5. 获取 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)。  
6. 垂直对齐文本。  
7. 保存修改后的演示文稿。

下面的 PHP 代码演示了如何在表格中对齐文本：
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 定义列宽和行高
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # 向幻灯片添加表格形状
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # 访问文本框
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # 为文本框创建 Paragraph 对象
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # 为段落创建 Portion 对象
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 垂直对齐文本
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # 将演示文稿保存到磁盘
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **在表格级别设置文本格式**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片中获取 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) 对象。  
4. 通过 [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) 设置文本字号。  
5. 通过 [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) 和 [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) 设置对齐方式和右边距。  
6. 通过 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) 设置文本垂直方向。  
7. 保存修改后的演示文稿。

下面的 PHP 代码演示了如何为表格中的文本应用首选的格式设置：
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation("simpletable.pptx");
  try {
    # 假设第一张幻灯片上的第一个形状是表格
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 设置表格单元格的字体高度
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # 在一次调用中设置表格单元格的文本对齐方式和右边距
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # 设置表格单元格的文本垂直类型
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便在其他表格或其他位置使用这些信息。下面的 PHP 代码演示了如何从表格预设样式中获取样式属性：
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// 更改默认的样式预设主题

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **锁定表格的宽高比**

几何图形的宽高比是其在不同维度上的尺寸比例。Aspose.Slides 提供了 [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) 方法，以便您锁定表格及其他形状的宽高比设置。

下面的 PHP 代码演示了如何锁定表格的宽高比：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// 取反

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**我可以为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

可以。表格提供了 [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) 方法，段落则有 [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/)。两者同时使用即可确保单元格内部的 RTL 顺序和渲染正确。

**如何防止用户在最终文件中移动或调整表格大小？**

使用 [shape locks](/slides/zh/php-java/applying-protection-to-presentation/) 来禁用移动、调整大小、选择等。这些锁同样适用于表格。

**是否支持在单元格内部插入图片作为背景？**

支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/)，图片会按照所选模式（拉伸或平铺）覆盖单元格区域。