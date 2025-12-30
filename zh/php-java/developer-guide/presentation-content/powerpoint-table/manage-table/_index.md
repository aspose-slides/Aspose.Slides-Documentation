---
title: 在PHP中管理演示文稿表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh/php-java/manage-table/
keywords:
- 添加表格
- 创建表格
- 访问表格
- 纵横比
- 对齐文本
- 文本格式化
- 表格样式
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 幻灯片中创建和编辑表格。发现简洁的代码示例，以简化您的表格工作流程。"
---

PowerPoint 中的表格是一种高效的显示和呈现信息的方式。以行列排列的单元格网格中的信息直观且易于理解。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) 类、[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 接口、[Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) 类、[ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) 接口以及其他类型，帮助您在各种演示文稿中创建、更新和管理表格。

## **从头创建表格**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义 `columnWidth` 数组。  
4. 定义 `rowHeight` 数组。  
5. 通过 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) 方法向幻灯片添加 [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 对象。  
6. 遍历每个 [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) ，对其上、下、左、右边框进行格式设置。  
7. 合并表格第一行的前两个单元格。  
8. 访问 [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/)" 的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。  
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
    # 向幻灯片添加表格形状
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
    # 合并第1行的第1和第2个单元格
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # 向合并后的单元格添加一些文本
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

在标准表格中，单元格的编号方式简单且从零开始。表格中的第一个单元格索引为 0,0（第 0 列，第 0 行）。

例如，拥有 4 列 4 行的表格的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

下面的 PHP 代码演示了如何为表格单元格指定编号：
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

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取包含表格的幻灯片引用。  
3. 创建 [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 对象并将其设为 null。  
4. 遍历所有 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) 对象，直至找到表格。  
   如果您认为当前幻灯片只包含一个表格，您可以直接检查其所有形状。当形状被识别为表格时，可将其强制转换为 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) 对象。但是，如果幻灯片包含多个表格，建议通过其 [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-) 方法搜索所需的表格。  
5. 使用 [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 对象对表格进行操作。在下面的示例中，我们向表格添加了一行新行。  
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
    # 遍历形状并设置对找到的表格的引用
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # 为第二行的第一列设置文本
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


## **对齐表格中的文本**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加 [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 对象。  
4. 从表格中访问 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) 对象。  
5. 访问该 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) 的 [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/)。  
6. 垂直对齐文本。  
7. 保存修改后的演示文稿。

下面的 PHP 代码演示了如何对齐表格中的文本：
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
    # 获取文本框
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


## **在表格层面设置文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片中访问 [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 对象。  
4. 为文本设置 [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-)。  
5. 设置 [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) 和 [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-)。  
6. 设置 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。  
7. 保存修改后的演示文稿。

下面的 PHP 代码演示了如何将首选的格式选项应用于表格中的文本：
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
    # 一次性设置表格单元格的文本对齐方式和右侧边距
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

Aspose.Slides 允许您检索表格的样式属性，以便在其他表格或其他地方使用这些细节。下面的 PHP 代码演示了如何从表格预设样式中获取样式属性：
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// 更改默认样式预设主题

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **锁定表格的纵横比**

几何形状的纵横比是其在不同维度上的尺寸比例。Aspose.Slides 提供了 [**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) 属性，以便您锁定表格及其他形状的纵横比设置。

下面的 PHP 代码演示了如何锁定表格的纵横比：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**我可以为整个表格及其单元格中的文本启用从右到左（RTL）阅读方向吗？**

可以。表格提供了 [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) 方法，段落则拥有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/)。两者结合可确保表格内部单元格的 RTL 顺序和渲染正确。

**如何防止用户在最终文件中移动或调整表格的大小？**

使用 [shape locks](/slides/zh/php-java/applying-protection-to-presentation/) 禁用移动、缩放、选择等。这些锁同样适用于表格。

**是否支持在单元格内部插入图像作为背景？**

是的。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/)，图像会根据所选模式（拉伸或平铺）覆盖单元格区域。