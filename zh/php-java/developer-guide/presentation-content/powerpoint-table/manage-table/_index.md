---
title: 管理表格
type: docs
weight: 10
url: /zh/php-java/manage-table/
keywords: "表格，创建表格，访问表格，表格纵横比，PowerPoint演示文稿，Java，Aspose.Slides for PHP via Java"
description: "在PowerPoint演示文稿中创建和管理表格"
---

在PowerPoint中，表格是一种高效展示和表现信息的方式。网格单元格中的信息（按行和列排列）简单明了，易于理解。

Aspose.Slides提供了[Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table)类，[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)接口，[Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)类，[ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/)接口以及其他类型，允许您创建、更新和管理各种演示文稿中的表格。

## **从头创建表格**

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义一个`columnWidth`数组。
4. 定义一个`rowHeight`数组。
5. 通过[addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-)方法将[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)对象添加到幻灯片中。
6. 遍历每个[ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/)，为上下左右边框应用格式。
7. 合并表格第一行的前两个单元格。
8. 访问[ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/)的[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。
9. 在[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)中添加一些文本。
10. 保存修改过的演示文稿。

以下PHP代码展示了如何在演示文稿中创建表格：

```php
  # 实例化代表PPTX文件的Presentation类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 定义列宽和行高
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # 向幻灯片添加表格形状
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 设置每个单元格的边框格式
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
    # 合并第1行的单元格1和2
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # 向合并单元格添加文本
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("合并单元格");
    # 保存演示文稿到磁盘
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **标准表格中的编号**

在标准表格中，单元格的编号是简单而从零开始的。表格中的第一个单元格的索引为0,0（列0，行0）。

例如，具有4列和4行的表格中单元格的编号如下所示：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下PHP代码展示了如何为表格中的单元格指定编号：

```php
  # 实例化代表PPTX文件的Presentation类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 定义列宽和行高
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # 向幻灯片添加表格形状
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 设置每个单元格的边框格式
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
    # 保存演示文稿到磁盘
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **访问现有的表格**

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。

2. 通过索引获取包含表格的幻灯片的引用。 

3. 创建一个[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)对象，并将其设置为null。

4. 遍历所有[IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/)对象，直到找到表格。

   如果您怀疑正在处理的幻灯片只包含一个表格，您可以简单检查它包含的所有形状。当一个形状被识别为表格时，您可以将其强制转换为[Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table)对象。但是，如果您正在处理的幻灯片包含多个表格，那么最好通过其[setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-)查找所需的表格。

5. 使用[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)对象操作表格。在下面的示例中，我们向表格添加了一行。

6. 保存修改后的演示文稿。

以下PHP代码展示了如何访问并操作现有表格：

```php
  # 实例化代表PPTX文件的Presentation类
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 初始化null的TableEx
    $tbl = null;
    # 遍历形状并将查找到的表格设置为引用
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # 设置第二行第一列的文本
        $tbl->get_Item(0, 1)->getTextFrame()->setText("新");
      }
    }
    # 保存修改后的演示文稿到磁盘
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **在表格中对齐文本**

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向幻灯片添加一个[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)对象。
4. 从表格中访问[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)对象。
5. 访问[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)的[IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/)。
6. 垂直对齐文本。
7. 保存修改后的演示文稿。

以下PHP代码展示了如何在表格中对齐文本：

```php
  # 创建Presentation类的实例
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
    # 为文本框创建段落对象
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # 为段落创建部分对象
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("这里的文本");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 垂直对齐文本
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # 保存演示文稿到磁盘
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **在表级别设置文本格式**

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 通过索引获取幻灯片的引用。 
3. 从幻灯片中访问一个[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)对象。
4. 为文本设置[setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-)。
5. 设置[setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-)和[setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-)。
6. 设置[setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。
7. 保存修改后的演示文稿。 

以下PHP代码展示了如何将您喜欢的格式选项应用于表格中的文本：

```php
  # 创建Presentation类的实例
  $pres = new Presentation("simpletable.pptx");
  try {
    # 假设第一张幻灯片的第一个形状是一个表格
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 设置表格单元格的字体高度
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # 一次性设置表格单元格的文本对齐和右边距
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

Aspose.Slides允许您检索表格的样式属性，以便您可以将这些细节用于其他表格或其他地方。以下PHP代码展示了如何从表格预设样式中获取样式属性：

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

几何形状的纵横比是其不同维度的大小比例。Aspose.Slides提供了[**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-)属性，以允许您锁定表格和其他形状的纵横比设置。

以下PHP代码展示了如何锁定表格的纵横比：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("锁定纵横比设置: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// 取反

    echo("锁定纵横比设置: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```